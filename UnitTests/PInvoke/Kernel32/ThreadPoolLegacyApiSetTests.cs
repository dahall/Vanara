using NUnit.Framework;
using System.Diagnostics;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ThreadPoolLegacyApiSetTests
{
	[Test]
	public void QueueUserWorkItemTest()
	{
		int cnt = 0;
		InitializeCriticalSection(out CRITICAL_SECTION g_cs);

		try
		{
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)1, WT.WT_EXECUTEDEFAULT), ResultIs.Successful);
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)2, WT.WT_EXECUTEINIOTHREAD), ResultIs.Successful);
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)3, WT.WT_EXECUTEINLONGTHREAD), ResultIs.Successful);
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)1, WT.WT_EXECUTEINTIMERTHREAD), ResultIs.Successful);
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)2, WT.WT_EXECUTEINUITHREAD), ResultIs.Successful);
			Assert.That(QueueUserWorkItem(ThreadProc, (IntPtr)3, WT.WT_EXECUTEINWAITTHREAD), ResultIs.Successful);
		}
		finally
		{
			//while (cnt < 6)
			//	Sleep(500);
			DeleteCriticalSection(ref g_cs);
		}

		uint ThreadProc(IntPtr c)
		{
			for (int i = 0; i <= 5; i++)
			{
				//EnterCriticalSection(ref g_cs);
				Debug.WriteLine($"Thread {0} (id: {1}) is {2}", c.ToInt32(), GetCurrentThreadId(), i);
				//LeaveCriticalSection(ref g_cs);
				InterlockedIncrement(ref cnt);
			}
			return 0;
		}
	}

	[Test]
	public void RegisterWaitForSingleObjectTest()
	{
		SafeEventHandle hCmplEvt;
		DateTime start = DateTime.Now;
		using (SafeEventHandle hEvent = CreateEvent(null, true, false, null))
		using (hCmplEvt = CreateEvent(null, true, false, null))
		{
			Debug.WriteLine("Register wait proc...");
			Assert.That(RegisterWaitForSingleObject(out SafeRegisteredWaitHandle hWait, hEvent, WaitProc, default, 3000, WT_SET_MAX_THREADPOOL_THREADS(WT.WT_EXECUTEONLYONCE, 503)), ResultIs.Successful);
			using (hWait)
			{
				hWait.WaitForAllFunctions = true;
				Sleep(1000);
				Assert.That(hEvent.Set(), ResultIs.Successful);
			}
			Debug.WriteLine($"{(DateTime.Now - start).TotalSeconds} Exiting wait proc...");
		}

		void WaitProc(IntPtr lpParameter, bool TimerOrWaitFired)
		{
			Debug.WriteLine($"{(DateTime.Now - start).TotalSeconds} In wait proc (TimerOrWaitFired={TimerOrWaitFired})...");
		}
	}

	[Test]
	public void TimerQueueTest()
	{
		// Use an event object to track the TimerRoutine execution
		SafeEventHandle gDoneEvent;
		using (gDoneEvent = CreateEvent(null, true, false, null))
		{
			Assert.That(gDoneEvent, ResultIs.ValidHandle);

			// Create the timer queue.
			using SafeTimerQueueHandle hTimerQueue = CreateTimerQueue();
			Assert.That(hTimerQueue, ResultIs.ValidHandle);

			// Establish that all callback functions are complete before disposing.
			hTimerQueue.CompletionEvent = SafeEventHandle.InvalidHandle;

			// Set a timer to call the timer routine in 2 then 1 second.
			Assert.That(CreateTimerQueueTimer(out TimerQueueTimerHandle hTimer, hTimerQueue, TimerRoutine, default, 2000), ResultIs.Successful);
			Assert.That(ChangeTimerQueueTimer(hTimerQueue, hTimer, 1000, 0), ResultIs.Successful);

			// TODO: Do other useful work here

			// Wait for the timer-queue thread to complete using an event object. The thread will signal the event at that time.
			Assert.That(WaitForSingleObject(gDoneEvent, INFINITE), ResultIs.Value(WAIT_STATUS.WAIT_OBJECT_0));

			// Forceably delete the timer.
			Assert.That(DeleteTimerQueueTimer(hTimerQueue, hTimer, SafeEventHandle.Null), ResultIs.Successful);
		}

		void TimerRoutine(IntPtr lpParam, bool TimerOrWaitFired)
		{
			SetEvent(gDoneEvent);
		}
	}
}