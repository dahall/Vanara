using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SynchApiTests
{
	[Test]
	public void ConditionVariableTest()
	{
		const int BUFFER_SIZE = 10;
		const int PRODUCER_SLEEP_TIME_MS = 50;
		const int CONSUMER_SLEEP_TIME_MS = 200;

		int[] Buffer = new int[BUFFER_SIZE];
		int LastItemProduced = 0;
		uint QueueSize = 0, QueueStartOffset = 0, TotalItemsProduced = 0, TotalItemsConsumed = 0;
		bool StopRequested = false;
		Random rand = new();

		InitializeConditionVariable(out CONDITION_VARIABLE BufferNotEmpty);
		InitializeConditionVariable(out CONDITION_VARIABLE BufferNotFull);
		InitializeCriticalSection(out CRITICAL_SECTION BufferLock);

		using SafeHTHREAD hProducer1 = CreateThread(null, 0, ProducerThreadProc, (IntPtr)1L, 0, out _),
			hConsumer1 = CreateThread(null, 0, ConsumerThreadProc, (IntPtr)1L, 0, out _),
			hConsumer2 = CreateThread(null, 0, ConsumerThreadProc, (IntPtr)2L, 0, out _);
		SleepEx(5000, false);

		EnterCriticalSection(ref BufferLock);
		StopRequested = true;
		LeaveCriticalSection(ref BufferLock);

		WakeAllConditionVariable(ref BufferNotFull);
		WakeAllConditionVariable(ref BufferNotEmpty);

		WaitForMultipleObjects(new[] { hProducer1, hConsumer1, hConsumer2 }, true, INFINITE);

		TestContext.WriteLine("TotalItemsProduced: {0}, TotalItemsConsumed: {1}", TotalItemsProduced, TotalItemsConsumed);

		uint ProducerThreadProc(IntPtr p)
		{
			long ProducerId = p.ToInt64();

			while (true)
			{
				// Produce a new item.
				Sleep((uint)rand.Next(PRODUCER_SLEEP_TIME_MS));

				int Item = InterlockedIncrement(ref LastItemProduced);

				EnterCriticalSection(ref BufferLock);

				while (QueueSize == BUFFER_SIZE && !StopRequested)
				{
					// Buffer is full - sleep so consumers can get items.
					SleepConditionVariableCS(ref BufferNotFull, ref BufferLock, INFINITE);
				}

				if (StopRequested)
				{
					LeaveCriticalSection(ref BufferLock);
					break;
				}

				// Insert the item at the end of the queue and increment size.
				Buffer[(QueueStartOffset + QueueSize) % BUFFER_SIZE] = Item;
				QueueSize++;
				TotalItemsProduced++;

				System.Diagnostics.Debug.Write($"Producer {ProducerId}: item {Item}, queue size {QueueSize}\r\n");

				LeaveCriticalSection(ref BufferLock);

				// If a consumer is waiting, wake it.
				WakeConditionVariable(ref BufferNotEmpty);
			}

			System.Diagnostics.Debug.Write($"Producer {ProducerId} exiting\r\n");
			return 0;
		}

		uint ConsumerThreadProc(IntPtr p)
		{
			long ConsumerId = p.ToInt64();

			while (true)
			{
				EnterCriticalSection(ref BufferLock);

				while (QueueSize == 0 && !StopRequested)
				{
					// Buffer is empty - sleep so producers can create items.
					SleepConditionVariableCS(ref BufferNotEmpty, ref BufferLock, INFINITE);
				}

				if (StopRequested && QueueSize == 0)
				{
					LeaveCriticalSection(ref BufferLock);
					break;
				}

				// Consume the first available item.
				int Item = Buffer[QueueStartOffset];

				QueueSize--;
				QueueStartOffset++;
				TotalItemsConsumed++;

				if (QueueStartOffset == BUFFER_SIZE)
				{
					QueueStartOffset = 0;
				}

				System.Diagnostics.Debug.Write($"Consumer {ConsumerId}: item {Item}, queue size {QueueSize}\r\n");

				LeaveCriticalSection(ref BufferLock);

				// If a producer is waiting, wake it.

				WakeConditionVariable(ref BufferNotFull);

				// Simulate processing of the item.

				Sleep((uint)rand.Next(CONSUMER_SLEEP_TIME_MS));
			}

			System.Diagnostics.Debug.Write($"Consumer {ConsumerId} exiting\r\n");
			return 0;
		}
	}

	[Test]
	public void ConditionVariableTest2()
	{
		InitializeSRWLock(out SRWLOCK cond_rwlock);
		InitializeConditionVariable(out CONDITION_VARIABLE start_condition);
		bool wake_all = false;
		int cnt = 0;

		try
		{
			SafeHTHREAD[] ghThreads = new SafeHTHREAD[5];
			for (int i = 0; i < ghThreads.Length; i++)
			{
				ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
				Assert.That(ghThreads[i].IsNull, Is.False);
			}

			AcquireSRWLockExclusive(ref cond_rwlock);
			// set the flag to true, then wake all threads
			wake_all = true;
			WakeAllConditionVariable(ref start_condition);

			ReleaseSRWLockExclusive(ref cond_rwlock);

			WaitForMultipleObjects(ghThreads, true, INFINITE);
			foreach (SafeHTHREAD t in ghThreads) t.Dispose();

			Assert.That(cnt, Is.EqualTo(ghThreads.Length));
		}
		finally
		{
		}

		uint ThreadProc(IntPtr _)
		{
			AcquireSRWLockShared(ref cond_rwlock);

			// main thread sets wake_all to true and calls WakeAllConditionVariable()
			// so this thread should start doing the work (?)
			while (!wake_all)
				SleepConditionVariableSRW(ref start_condition, ref cond_rwlock, INFINITE, CONDITION_VARIABLE_FLAGS.CONDITION_VARIABLE_LOCKMODE_SHARED);

			InterlockedIncrement(ref cnt);
			return 0;
		}
	}

	[Test]
	public void CriticalSectionAndSpinCountTest()
	{
		Assert.That(InitializeCriticalSectionAndSpinCount(out CRITICAL_SECTION critSect, 400), ResultIs.Successful);
		try
		{
			using SafeHTHREAD hThread = CreateThread(null, 0, ThreadProc, default, 0, out _);
			WaitForSingleObject(hThread, INFINITE);
			Assert.That(GetExitCodeThread(hThread, out uint c), ResultIs.Successful);
			Assert.That(c, Is.Zero);
		}
		finally
		{
			DeleteCriticalSection(ref critSect);
		}

		uint ThreadProc(IntPtr _)
		{
			if (TryEnterCriticalSection(ref critSect))
			{
				Sleep(5);
				LeaveCriticalSection(ref critSect);
				return 0;
			}
			return 1;
		}
	}

	[Test]
	public void CriticalSectionExTest()
	{
		Assert.That(InitializeCriticalSectionEx(out CRITICAL_SECTION critSect, 400, CRITICAL_SECTION_FLAGS.CRITICAL_SECTION_FLAG_NO_DEBUG_INFO), ResultIs.Successful);
		try
		{
			using SafeHTHREAD hThread = CreateThread(null, 0, ThreadProc, default, 0, out _);
			WaitForSingleObject(hThread, INFINITE);
			Assert.That(GetExitCodeThread(hThread, out uint c), ResultIs.Successful);
			Assert.That(c, Is.Zero);
		}
		finally
		{
			DeleteCriticalSection(ref critSect);
		}

		uint ThreadProc(IntPtr _)
		{
			EnterCriticalSection(ref critSect);
			Sleep(5);
			LeaveCriticalSection(ref critSect);
			return 0;
		}
	}

	[Test]
	public void CriticalSectionTest()
	{
		InitializeCriticalSection(out CRITICAL_SECTION critSect);
		SetCriticalSectionSpinCount(ref critSect, 400);
		try
		{
			using SafeHTHREAD hThread = CreateThread(null, 0, ThreadProc, default, 0, out _);
			WaitForSingleObject(hThread, INFINITE);
			Assert.That(GetExitCodeThread(hThread, out uint c), ResultIs.Successful);
			Assert.That(c, Is.Zero);
		}
		finally
		{
			DeleteCriticalSection(ref critSect);
		}

		uint ThreadProc(IntPtr _)
		{
			EnterCriticalSection(ref critSect);
			Sleep(5);
			LeaveCriticalSection(ref critSect);
			return 0;
		}
	}

	[Test]
	public void EventExTest()
	{
		const string name = "myEvent";
		const int THREADCOUNT = 4;

		// Create an unnamed waitable timer.
		using SafeEventHandle ghWriteEvent = CreateEventEx(null, name, CREATE_EVENT_FLAGS.CREATE_EVENT_MANUAL_RESET, (uint)SynchronizationObjectAccess.EVENT_ALL_ACCESS);
		Assert.That(ghWriteEvent.IsNull, Is.False);

		// Create multiple threads to read from the buffer.
		SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
		for (int i = 0; i < THREADCOUNT; i++)
		{
			ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
			Assert.That(ghThreads[i].IsNull, Is.False);
		}

		TestContext.Write("Main thread writing to the shared buffer...\n");

		// Set ghWriteEvent to signaled
		if (!SetEvent(ghWriteEvent))
		{
			TestContext.Write("SetEvent failed ({0})\n", GetLastError());
			return;
		}

		TestContext.Write("Main thread waiting for threads to exit...\n");

		// The handle for each thread is signaled when the thread is terminated.
		switch (WaitForMultipleObjects(ghThreads, true, INFINITE))
		{
			// All thread objects were signaled
			case WAIT_STATUS.WAIT_OBJECT_0:
				TestContext.Write("All threads ended, cleaning up for application exit...\n");
				break;

			// An error occurred
			default:
				TestContext.Write("WaitForMultipleObjects failed ({0})\n", GetLastError());
				return;
		}

		// Close thread handles
		foreach (SafeHTHREAD t in ghThreads)
			t.Dispose();

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			TestContext.Write("Thread {0} waiting for write event...\n", id);

			using (SafeEventHandle hEvent = OpenEvent((uint)SynchronizationObjectAccess.EVENT_ALL_ACCESS, false, name))
			{
				switch (WaitForSingleObject(hEvent, INFINITE))
				{
					// Event object was signaled
					case WAIT_STATUS.WAIT_OBJECT_0:
						TestContext.Write("Thread {0} reading from buffer\n", id);
						break;

					// An error occurred
					default:
						TestContext.Write("Wait error ({0})\n", GetLastError());
						return 0;
				}
			}

			TestContext.Write("Thread {0} exiting\n", id);
			return 1;
		}
	}

	[Test]
	public void EventTest()
	{
		const string name = "myEvent";
		const int THREADCOUNT = 4;

		// Create an unnamed waitable timer.
		SafeEventHandle ghWriteEvent;
		using (ghWriteEvent = CreateEvent(null, true, false, name))
		{
			Assert.That(ghWriteEvent.IsNull, Is.False);

			// Create multiple threads to read from the buffer.
			SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
			for (int i = 0; i < THREADCOUNT; i++)
			{
				ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
				Assert.That(ghThreads[i].IsNull, Is.False);
			}

			TestContext.Write("Main thread writing to the shared buffer...\n");

			// Set ghWriteEvent to signaled
			Assert.That(SetEvent(ghWriteEvent), ResultIs.Successful);

			TestContext.Write("Main thread waiting for threads to exit...\n");

			// The handle for each thread is signaled when the thread is terminated.
			switch (WaitForMultipleObjects(ghThreads, true, INFINITE))
			{
				// All thread objects were signaled
				case WAIT_STATUS.WAIT_OBJECT_0:
					TestContext.Write("All threads ended, cleaning up for application exit...\n");
					break;

				// An error occurred
				default:
					TestContext.Write("WaitForMultipleObjects failed ({0})\n", GetLastError());
					return;
			}

			// Close thread handles
			foreach (SafeHTHREAD t in ghThreads)
				t.Dispose();

			Assert.That(ResetEvent(ghWriteEvent), ResultIs.Successful);
			Assert.That(PulseEvent(ghWriteEvent), ResultIs.Successful);
		}

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			TestContext.Write("Thread {0} waiting for write event...\n", id);

			switch (WaitForSingleObject(ghWriteEvent, INFINITE))
			{
				// Event object was signaled
				case WAIT_STATUS.WAIT_OBJECT_0:
					TestContext.Write("Thread {0} reading from buffer\n", id);
					break;

				// An error occurred
				default:
					TestContext.Write("Wait error ({0})\n", GetLastError());
					return 0;
			}

			TestContext.Write("Thread {0} exiting\n", id);
			return 1;
		}
	}

	[Test]
	public void MutexExTest()
	{
		const string name = "myMutex";
		const int THREADCOUNT = 4;

		// Create a mutex with no initial owner
		using SafeMutexHandle ghMutex = CreateMutexEx(null, name, 0, (uint)SynchronizationObjectAccess.MUTEX_ALL_ACCESS);
		Assert.That(ghMutex.IsNull, Is.False);

		// Create worker threads
		SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
		for (int i = 0; i < THREADCOUNT; i++)
		{
			ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
			Assert.That(ghThreads[i].IsNull, Is.False);
		}

		// Wait for all threads to terminate using plain handles
		HTHREAD[] hThreads = Array.ConvertAll(ghThreads, h => (HTHREAD)h);
		WaitForMultipleObjectsEx(hThreads, true, INFINITE, false);

		// Close thread and mutex handles
		foreach (SafeHTHREAD t in ghThreads)
		{
			TestContext.WriteLine($"Thread {GetThreadId(t)} completed with code {(GetExitCodeThread(t, out uint c) ? c : 0U)}");
			t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			// Request ownership of mutex.
			using SafeMutexHandle hMut = OpenMutex((uint)SynchronizationObjectAccess.MUTEX_ALL_ACCESS, false, name);
			if (hMut.IsNull) return (uint)Win32Error.GetLastError();
			for (int i = 0; i < 20; i++)
			{
				switch (WaitForSingleObject(hMut, INFINITE))
				{
					// The thread got ownership of the mutex
					case WAIT_STATUS.WAIT_OBJECT_0:
						TestContext.Write("Thread {0} writing to database...\n", id);
						if (!ReleaseMutex(hMut)) return (uint)Win32Error.GetLastError();
						break;

					// The thread got ownership of an abandoned mutex The database is in an indeterminate state
					case WAIT_STATUS.WAIT_ABANDONED:
						return 0;
				}
			}
			return 1;
		}
	}

	[Test]
	public void MutexTest()
	{
		const string name = "myMutex";
		const int THREADCOUNT = 4;

		// Create a mutex with no initial owner
		using SafeMutexHandle ghMutex = CreateMutex(null, false, name);
		Assert.That(ghMutex.IsNull, Is.False);

		// Create worker threads
		SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
		for (int i = 0; i < THREADCOUNT; i++)
		{
			ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
			Assert.That(ghThreads[i].IsNull, Is.False);
		}

		// Wait for all threads to terminate
		WaitForMultipleObjects(ghThreads, true, INFINITE);

		// Close thread and mutex handles
		foreach (SafeHTHREAD t in ghThreads)
		{
			TestContext.WriteLine($"Thread {GetThreadId(t)} completed with code {(GetExitCodeThread(t, out uint c) ? c : 0U)}");
			t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			// Request ownership of mutex.
			using SafeMutexHandle hMut = OpenMutex((uint)SynchronizationObjectAccess.MUTEX_ALL_ACCESS, false, name);
			if (hMut.IsNull) return (uint)Win32Error.GetLastError();
			for (int i = 0; i < 20; i++)
			{
				switch (WaitForSingleObject(hMut, INFINITE))
				{
					// The thread got ownership of the mutex
					case WAIT_STATUS.WAIT_OBJECT_0:
						TestContext.Write("Thread {0} writing to database...\n", id);
						if (!ReleaseMutex(hMut)) return (uint)Win32Error.GetLastError();
						break;

					// The thread got ownership of an abandoned mutex The database is in an indeterminate state
					case WAIT_STATUS.WAIT_ABANDONED:
						return 0;
				}
			}
			return 1;
		}
	}

	[Test]
	public void SemaphoreExTest()
	{
		const string name = "mySema4";
		const int THREADCOUNT = 12;

		// Create a mutex with no initial owner
		using SafeSemaphoreHandle ghSemaphore = CreateSemaphoreEx(null, 10, 10, name, 0, (uint)SynchronizationObjectAccess.SEMAPHORE_ALL_ACCESS);
		Assert.That(ghSemaphore.IsNull, Is.False);

		// Create worker threads
		SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
		for (int i = 0; i < THREADCOUNT; i++)
		{
			ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
			Assert.That(ghThreads[i].IsNull, Is.False);
		}

		// Wait for all threads to terminate
		WaitForMultipleObjects(ghThreads, true, INFINITE);

		// Close thread and mutex handles
		foreach (SafeHTHREAD t in ghThreads)
		{
			TestContext.WriteLine($"Thread {GetThreadId(t)} completed with code {(GetExitCodeThread(t, out uint c) ? c : 0U)}");
			t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			using SafeSemaphoreHandle hSem = OpenSemaphore((uint)SynchronizationObjectAccess.SEMAPHORE_ALL_ACCESS, false, name);
			if (hSem.IsNull) return (uint)Win32Error.GetLastError();
			bool loop = true;
			while (loop)
			{
				// Try to enter the semaphore gate.
				switch (WaitForSingleObject(hSem, 0))
				{
					// The semaphore object was signaled.
					case WAIT_STATUS.WAIT_OBJECT_0:
						TestContext.Write("Thread {0} wait succeeded.\n", id);
						loop = false;
						// Simulate thread spending time on task
						Sleep(5);
						// Release the semaphore when task is finished
						if (!ReleaseSemaphore(hSem, 1, out int _)) return (uint)Win32Error.GetLastError();
						break;

					// The semaphore was nonsignaled, so a time-out occurred.
					case WAIT_STATUS.WAIT_TIMEOUT:
						break;
				}
			}
			return 1;
		}
	}

	[Test]
	public void SemaphoreTest()
	{
		const string name = "mySema4";
		const int THREADCOUNT = 12;

		// Create a mutex with no initial owner
		using SafeSemaphoreHandle ghSemaphore = CreateSemaphore(null, 10, 10, name);
		Assert.That(ghSemaphore.IsNull, Is.False);

		// Create worker threads
		SafeHTHREAD[] ghThreads = new SafeHTHREAD[THREADCOUNT];
		for (int i = 0; i < THREADCOUNT; i++)
		{
			ghThreads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
			Assert.That(ghThreads[i].IsNull, Is.False);
		}

		// Wait for all threads to terminate
		WaitForMultipleObjects(ghThreads, true, INFINITE);

		// Close thread and mutex handles
		foreach (SafeHTHREAD t in ghThreads)
		{
			TestContext.WriteLine($"Thread {GetThreadId(t)} completed with code {(GetExitCodeThread(t, out uint c) ? c : 0U)}");
			t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			uint id = GetCurrentThreadId();

			using SafeSemaphoreHandle hSem = OpenSemaphore((uint)SynchronizationObjectAccess.SEMAPHORE_ALL_ACCESS, false, name);
			if (hSem.IsNull) return (uint)Win32Error.GetLastError();
			bool loop = true;
			while (loop)
			{
				// Try to enter the semaphore gate.
				switch (WaitForSingleObject(hSem, 0))
				{
					// The semaphore object was signaled.
					case WAIT_STATUS.WAIT_OBJECT_0:
						TestContext.Write("Thread {0} wait succeeded.\n", id);
						loop = false;
						// Simulate thread spending time on task
						Sleep(5);
						// Release the semaphore when task is finished
						if (!ReleaseSemaphore(hSem, 1, out int _)) return (uint)Win32Error.GetLastError();
						break;

					// The semaphore was nonsignaled, so a time-out occurred.
					case WAIT_STATUS.WAIT_TIMEOUT:
						break;
				}
			}
			return 1;
		}
	}

	[Test]
	public void SRWLockTest()
	{
		InitializeSRWLock(out SRWLOCK srwlock);

		Assert.That(TryAcquireSRWLockExclusive(ref srwlock), Is.True);
		ReleaseSRWLockExclusive(ref srwlock);

		AcquireSRWLockExclusive(ref srwlock);
		ReleaseSRWLockExclusive(ref srwlock);

		Assert.That(TryAcquireSRWLockShared(ref srwlock), Is.True);
		ReleaseSRWLockShared(ref srwlock);

		AcquireSRWLockShared(ref srwlock);
		ReleaseSRWLockShared(ref srwlock);
	}

	[Test]
	public void SyncBarrierTest()
	{
		const int MAX_SLEEP_MS = 32;
		int dwMinThreads = Environment.ProcessorCount;
		int dwMaxThreads = dwMinThreads * 4;
		uint dwNumLoops = 50U;
		SYNCHRONIZATION_BARRIER gBarrier;
		int gErrorCount = 0;
		SafeEventHandle gStartEvent;
		(int threadCount, int trueCount, int falseCount, uint loops, SYNC_BARRIER_FLAGS flags) p;
		Random rand = new();

		/* Test invalid parameters */
		Assert.That(InitializeSynchronizationBarrier(out _, 0, -1), ResultIs.Failure);
		Assert.That(InitializeSynchronizationBarrier(out _, -1, -1), ResultIs.Failure);
		Assert.That(InitializeSynchronizationBarrier(out _, 1, -2), ResultIs.Failure);

		/* Functional tests */
		TestSynchBarrierWithFlags(0, dwMaxThreads, dwNumLoops);
		TestSynchBarrierWithFlags(SYNC_BARRIER_FLAGS.SYNCHRONIZATION_BARRIER_FLAGS_SPIN_ONLY, dwMinThreads, dwNumLoops);
		TestSynchBarrierWithFlags(SYNC_BARRIER_FLAGS.SYNCHRONIZATION_BARRIER_FLAGS_BLOCK_ONLY, dwMaxThreads, dwNumLoops);

		void TestSynchBarrierWithFlags(SYNC_BARRIER_FLAGS dwFlags, int dwThreads, uint dwLoops)
		{
			p = (0, 0, 0, dwLoops, dwFlags);

			Assert.That(InitializeSynchronizationBarrier(out gBarrier, dwThreads, -1), ResultIs.Successful);
			try
			{
				using (gStartEvent = CreateEvent(null, true, false, null))
				{
					Assert.That(gStartEvent.IsNull, Is.False);

					SafeHTHREAD[] threads = new SafeHTHREAD[dwThreads];
					int i;
					for (i = 0; i < dwThreads; i++)
					{
						threads[i] = CreateThread(null, 0, test_synch_barrier_thread, default, 0, out _);
						Assert.That(threads[i].IsNull, Is.False);
					}

					if (!SetEvent(gStartEvent))
					{
						TestContext.WriteLine($"SetEvent(gStartEvent) failed with error = {Win32Error.GetLastError()}");
						InterlockedIncrement(ref gErrorCount);
					}

					while (i-- > 0)
					{
						WAIT_STATUS dwStatus;
						if (WAIT_STATUS.WAIT_OBJECT_0 != (dwStatus = WaitForSingleObject(threads[i], INFINITE)))
						{
							TestContext.WriteLine($"WaitForSingleObject(thread[{i}] unexpectedly returned {dwStatus} (error = {Win32Error.GetLastError()})");
							InterlockedIncrement(ref gErrorCount);
						}

						threads[i].Dispose();
					}
				}
			}
			finally
			{
				DeleteSynchronizationBarrier(ref gBarrier);
			}

			Assert.That(p.threadCount, Is.EqualTo(dwThreads));
			Assert.That(p.trueCount, Is.EqualTo(dwLoops));
			Assert.That(p.falseCount, Is.EqualTo(dwLoops * (dwThreads - 1)));
		}

		uint test_synch_barrier_thread(IntPtr _)
		{
			InterlockedIncrement(ref p.threadCount);

			/* wait for start event from main */
			if (WaitForSingleObject(gStartEvent, INFINITE) != WAIT_STATUS.WAIT_OBJECT_0)
			{
				InterlockedIncrement(ref gErrorCount);
				return 1;
			}

			for (int i = 0; i < p.loops && gErrorCount == 0; i++)
			{
				/* simulate different execution times before the barrier */
				Sleep((uint)rand.Next(MAX_SLEEP_MS));

				if (EnterSynchronizationBarrier(ref gBarrier, p.flags))
					InterlockedIncrement(ref p.trueCount);
				else
					InterlockedIncrement(ref p.falseCount);
			}

			return 0;
		}
	}

	[Test]
	public void TimerQueueTest()
	{
		SafeEventHandle gDoneEvent;
		bool? timerOrWaitFired = null;

		// Use an event object to track the TimerRoutine execution
		using (gDoneEvent = CreateEvent(null, true, false, null))
		{
			Assert.That(gDoneEvent.IsNull, Is.False);

			// Create the timer queue.
			using SafeTimerQueueHandle hTimerQueue = CreateTimerQueue();
			Assert.That(hTimerQueue.IsNull, Is.False);

			// Set a timer to call the timer routine in 4 seconds.
			Assert.That(CreateTimerQueueTimer(out TimerQueueTimerHandle hTimer, hTimerQueue, TimerRoutine, default, 4000, 0, 0), ResultIs.Successful);

			// TODO: Do other useful work here

			// Wait for the timer-queue thread to complete using an event object. The thread will signal the event at that time.
			Assert.That(WaitForSingleObject(gDoneEvent, INFINITE), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));

			Assert.That(timerOrWaitFired.HasValue, Is.True);
			Assert.That(timerOrWaitFired!.Value, Is.True);
		}

		void TimerRoutine(IntPtr lpParameter, bool TimerOrWaitFired)
		{
			timerOrWaitFired = TimerOrWaitFired;
			SetEvent(gDoneEvent);
		}
	}

	[Test]
	public void WaitableTimerExTest()
	{
		// Create an unnamed waitable timer.
		using SafeWaitableTimerHandle hTimer = CreateWaitableTimerEx(null, null, CREATE_WAITABLE_TIMER_FLAG.CREATE_WAITABLE_TIMER_MANUAL_RESET, (uint)SynchronizationObjectAccess.TIMER_ALL_ACCESS);
		Assert.That(hTimer.IsNull, Is.False);

		// Set a timer to wait for 2 seconds.
		FILETIME liDueTime = TimeSpan.FromSeconds(2).ToFileTimeStruct();
		Assert.That(SetWaitableTimerEx(hTimer, liDueTime, 0, null, default, new REASON_CONTEXT("Because"), 50), ResultIs.Successful);

		// Wait for the timer.
		Assert.That(WaitForSingleObject(hTimer, INFINITE), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
	}

	[Test]
	public void WaitableTimerTest()
	{
		const string tName = "myTimer";

		// Create an unnamed waitable timer.
		using SafeWaitableTimerHandle hTimer = CreateWaitableTimer(null, true, tName);
		Assert.That(hTimer.IsNull, Is.False);

		new System.Threading.Thread(ThreadProc).Start();

		// Set a timer to wait for 2 seconds.
		FILETIME liDueTime = TimeSpan.FromSeconds(2).ToFileTimeStruct();
		Assert.That(SetWaitableTimer(hTimer, liDueTime, 0, null, default, false), ResultIs.Successful);

		// Wait for the timer.
		Assert.That(WaitForSingleObject(hTimer, INFINITE), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));

		// Set a timer to wait for 2 seconds.
		Assert.That(SetWaitableTimer(hTimer, liDueTime), ResultIs.Successful);
		Assert.That(CancelWaitableTimer(hTimer), ResultIs.Successful);

		void ThreadProc()
		{
			using SafeWaitableTimerHandle hThrTimer = OpenWaitableTimer((uint)SynchronizationObjectAccess.TIMER_ALL_ACCESS, false, tName);
			Assert.That(hThrTimer.IsNull, Is.False);
		}
	}

	[Test]
	public void InitOnceSyncTest()
	{
		const int ctxVal = 1 << INIT_ONCE_CTX_RESERVED_BITS;
		SafeEventHandle gStartEvent;
		INIT_ONCE gInitOnce = default;
		int initCount = 0;

		using (gStartEvent = CreateEvent(null, true, false, null))
		{
			Assert.That(gStartEvent.IsNull, Is.False);

			SafeHTHREAD[] threads = new SafeHTHREAD[10];
			for (int i = 0; i < threads.Length; i++)
			{
				threads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
				Assert.That(threads[i].IsNull, Is.False);
			}

			Assert.That(SetEvent(gStartEvent), ResultIs.Successful);

			WaitForMultipleObjects(threads, true, INFINITE);

			Assert.That(threads.Select(t => GetExitCodeThread(t, out uint c) ? c : 0), Has.All.EqualTo(ctxVal));
			Assert.That(initCount, Is.EqualTo(1));

			foreach (SafeHTHREAD t in threads) t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			if (WaitForSingleObject(gStartEvent, INFINITE) != WAIT_STATUS.WAIT_OBJECT_0)
				return 0;
			InitOnceExecuteOnce(ref gInitOnce, InitFunc, default, out IntPtr ctx);
			return (uint)ctx.ToInt32();
		}

		bool InitFunc(ref INIT_ONCE InitOnce, IntPtr Parameter, out IntPtr Context)
		{
			//Sleep(500);
			Context = (IntPtr)ctxVal;
			InterlockedIncrement(ref initCount);
			return true;
		}
	}

	[Test]
	public void InitOnceSyncNoCallbackTest()
	{
		const int ctxVal = 1 << INIT_ONCE_CTX_RESERVED_BITS;
		SafeEventHandle gStartEvent;

		InitOnceInitialize(out INIT_ONCE gInitOnce);
		using (gStartEvent = CreateEvent(null, true, false, null))
		{
			Assert.That(gStartEvent.IsNull, Is.False);

			SafeHTHREAD[] threads = new SafeHTHREAD[10];
			for (int i = 0; i < threads.Length; i++)
			{
				threads[i] = CreateThread(null, 0, ThreadProc, default, 0, out _);
				Assert.That(threads[i].IsNull, Is.False);
			}

			Assert.That(SignalObjectAndWait(gStartEvent, threads[0], INFINITE, false), ResultIs.Value(WAIT_STATUS.WAIT_OBJECT_0));

			WaitForMultipleObjects(threads, true, INFINITE);

			Assert.That(threads.Select(t => GetExitCodeThread(t, out uint c) ? c : 0), Has.All.EqualTo(ctxVal));

			foreach (SafeHTHREAD t in threads) t.Dispose();
		}

		uint ThreadProc(IntPtr _)
		{
			// Start all threads at the same time
			if (WaitForSingleObject(gStartEvent, INFINITE) != WAIT_STATUS.WAIT_OBJECT_0)
				return 0;
			InitOnceBeginInitialize(ref gInitOnce, 0, out bool pending, out IntPtr ctx);
			if (pending)
			{
				IntPtr newctx = (IntPtr)ctxVal;
				InitOnceComplete(ref gInitOnce, 0, newctx);
				return (uint)newctx.ToInt32();
			}
			return (uint)ctx.ToInt32();
		}
	}

	[Test]
	public void InterlockedCompareExchangeTest()
	{
		const int dest = 128;
		int destVar = dest;
		Assert.That(InterlockedCompareExchange(ref destVar, 64, dest), Is.EqualTo(dest));
		Assert.That(destVar, Is.EqualTo(64));
	}

	[Test]
	public unsafe void WakeByWaitOnAddressTest()
	{
		uint g_ulState = 0;
		int cnt = 0;

		SafeHTHREAD[] threads = new SafeHTHREAD[10];
		for (int i = 0; i < threads.Length; i++)
		{
			threads[i] = CreateThread(null, 0, ThreadProc, &g_ulState, 0, out _);
			Assert.That(threads[i].IsNull, Is.False);
		}

		for (int i = threads.Length / 2; i >= 0; i--)
		{
			g_ulState = (uint)i;
			if (g_ulState == 0)
			{
				WakeByAddressAll(&g_ulState);
				break;
			}
			WakeByAddressSingle(&g_ulState);
		}
		WaitForMultipleObjects(threads, true, INFINITE);

		foreach (SafeHTHREAD t in threads) t.Dispose();

		Assert.That(cnt, Is.EqualTo(threads.Length));

		unsafe uint ThreadProc(void* pState)
		{
			uint ulUndesire = 0;
			WaitOnAddress(pState, &ulUndesire, sizeof(uint), INFINITE);
			InterlockedIncrement(ref cnt);
			return 0;
		}
	}
}