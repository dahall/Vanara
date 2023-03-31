using NUnit.Framework;
using System;
using System.Diagnostics;
using Vanara.Extensions;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ThreadPoolApiSetTests
{
	[Test]
	public void QuerySetThreadpoolStackInformationTest()
	{
		using SafePTP_POOL pool = CreateThreadpool();
		Assert.That(pool, ResultIs.ValidHandle);
		Assert.That(QueryThreadpoolStackInformation(pool, out TP_POOL_STACK_INFORMATION si), ResultIs.Successful);
		Assert.That(si.StackReserve.Value, Is.Not.Zero);
		Assert.That(SetThreadpoolStackInformation(pool, si), ResultIs.Successful);
	}

	[Test]
	public void ThreadpoolIoWorkTimerTest()
	{
		InitializeThreadpoolEnvironment(out PTP_CALLBACK_ENVIRON CallBackEnviron);

		// Create a custom, dedicated thread pool.
		using SafePTP_POOL pool = CreateThreadpool();
		Assert.That(pool, ResultIs.ValidHandle);

		// The thread pool is made persistent simply by setting both the minimum and maximum threads to 1.
		SetThreadpoolThreadMaximum(pool, 1);
		Assert.That(SetThreadpoolThreadMinimum(pool, 1), ResultIs.Successful);

		// Create a cleanup group for this thread pool.
		using SafePTP_CLEANUP_GROUP cleanupgroup = CreateThreadpoolCleanupGroup();
		Assert.That(cleanupgroup, ResultIs.ValidHandle);
		cleanupgroup.AutoCloseMembers = true;

		// Associate the callback environment with our thread pool.
		CallBackEnviron.SetThreadpoolCallbackPool(pool);

		// Associate the cleanup group with our thread pool. Objects created with the same callback environment as the cleanup
		// group become members of the cleanup group.
		CallBackEnviron.SetThreadpoolCallbackCleanupGroup(cleanupgroup, null);

		// Create work with the callback environment.
		PTP_WORK work = SafePTP_CLEANUP_GROUP.CreateWork(MyWorkCallback, default, CallBackEnviron);
		Assert.That(work, ResultIs.ValidHandle);

		// Submit the work to the pool. Because this was a pre-allocated work item (using CreateThreadpoolWork), it is guaranteed
		// to execute.
		SubmitThreadpoolWork(work);

		// Create a timer with the same callback environment.
		PTP_TIMER timer = SafePTP_CLEANUP_GROUP.CreateTimer(MyTimerCallback, default, CallBackEnviron);
		Assert.That(timer, ResultIs.ValidHandle);

		// Set the timer to fire in one second.
		System.Runtime.InteropServices.ComTypes.FILETIME FileDueTime = TimeSpan.FromSeconds(-1).ToFileTimeStruct();
		Assert.That(SetThreadpoolTimerEx(timer, FileDueTime, 0, 0), Is.False);
		Assert.That(IsThreadpoolTimerSet(timer), Is.True);

		using (SafeHFILE hFile = CreateFile(TestCaseSources.SmallFile, FileAccess.FILE_GENERIC_READ, System.IO.FileShare.Read, null, System.IO.FileMode.Open, FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED))
		using (SafePTP_IO io = CreateThreadpoolIo(hFile, MyIoCallback, default, CallBackEnviron))
		{
			Assert.That(io, ResultIs.ValidHandle);
			StartThreadpoolIo(io);
			WaitForThreadpoolIoCallbacks(io, true);
		}

		// Delay for the timer to be fired
		Sleep(1500);

		void MyIoCallback(PTP_CALLBACK_INSTANCE Instance, IntPtr Context, IntPtr Overlapped, uint IoResult, UIntPtr NumberOfBytesTransferred, PTP_IO Io)
		{
			Debug.Write("MyIoCallback: I/O has fired.\n");
			CancelThreadpoolIo(Io);
		}

		// Thread pool timer callback function template
		void MyTimerCallback(PTP_CALLBACK_INSTANCE a, IntPtr b, PTP_TIMER c) => Debug.Write("MyTimerCallback: timer has fired.\n");

		// This is the thread pool work callback function.
		void MyWorkCallback(PTP_CALLBACK_INSTANCE a, IntPtr b, PTP_WORK c)
		{
			CallbackMayRunLong(a);
			Debug.Write("MyWorkCallback: Task performed.\n");
		}
	}

	[Test]
	public void ThreadpoolWaitTest()
	{
		SafeEventHandle retEvent;
		// Create an auto-reset event.
		using (SafeEventHandle hEvent = CreateEvent(null, false, false, null))
		using (retEvent = CreateEvent(null, false, false, null))
		{
			Assert.That(hEvent, ResultIs.ValidHandle);

			using SafePTP_WAIT Wait = CreateThreadpoolWait(MyWaitCallback);
			Assert.That(Wait, ResultIs.ValidHandle);

			// Need to re-register the event with the wait object each time before signaling the event to trigger the wait callback.
			for (int i = 0; i < 5; i++)
			{
				SetThreadpoolWait(Wait, hEvent);

				SetEvent(hEvent);

				// Delay for the waiter thread to act if necessary.
				Sleep(500);

				// Block here until the callback function is done executing.
				WaitForThreadpoolWaitCallbacks(Wait, false);

				// Ensure that callback return event is signaled.
				WaitForSingleObject(retEvent, INFINITE);
			}

			SetThreadpoolWait(Wait);
		}

		// Thread pool wait callback function template
		void MyWaitCallback(PTP_CALLBACK_INSTANCE a, IntPtr b, PTP_WAIT c, uint d)
		{
			Debug.Write("MyWaitCallback: wait is over.\n");
			Sleep(200);
			SetEventWhenCallbackReturns(a, retEvent);
		}
	}

	[Test]
	public void TrySubmitThreadpoolCallbackTest()
	{
		Assert.That(TrySubmitThreadpoolCallback((i, c) =>
		{
			Debug.WriteLine("SimpleCallback from TrySubmitThreadpoolCallback");
			DisassociateCurrentThreadFromCallback(i);
		}), Is.True); ;
	}
}