using System;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	// This class encapsulates the management of a message loop for an application. It supports queing a callback to the application via the
	// message loop to enable the app to return from a call and continue processing that call later. This behavior is needed when
	// implementing a shell verb as verbs must not block the caller.
	//
	// Notes: The ComObject derived class should call QueueNonBlockingCallback in its invoke function, for example IExecuteCommand::Execute()
	// or IDropTarget::Drop() passing a method that will complete the initialization work.
	internal class ComMessageLoop
	{
		// This timer is used to exit the message loop if the the application is activated but not invoked. This is needed if there is a
		// failure when the verb is being invoked due to low resources or some other uncommon reason. Without this the app would not exit in
		// this case. This timer needs to be canceled once the app learns that it has should remain running.
		protected const uint cTimeout = 30 * 1000;

		private Action appCallback;
		private IntPtr postTimerId;      // timer id used to to queue a callback to the app
		private IntPtr timeoutTimerId;   // timer id used to exit the app if the app is not called back within a certain time

		public ComMessageLoop() => timeoutTimerId = SetTimer(default, default, cTimeout, null);

		// Cancel the timeout timer. This should be called when the appliation knows that it wants to keep running, for example when it
		// recieves the incomming call to invoke the verb, this is done implictly when the app queues a callback.
		public void CancelTimeout()
		{
			if (postTimerId != default)
			{
				KillTimer(default, timeoutTimerId);
				timeoutTimerId = default;
			}
		}

		public void QueueAppCallback(Action callback)
		{
			// queue a callback on OnAppCallback() by setting a timer of zero seconds
			appCallback = callback;
			postTimerId = SetTimer(default, default, 0, null);
			if (postTimerId != default)
				CancelTimeout();
		}

		public void Quit(int exitCode = 0)
		{
			CancelTimeout();
			PostQuitMessage(exitCode);
		}

		public void RunMessageLoop()
		{
			const uint WM_TIMER = 0x0113;
			while (GetMessage(out var msg, default, 0, 0))
			{
				if (msg.message == WM_TIMER)
				{
					KillTimer(default, msg.wParam);    // all are one shot timers

					if (msg.wParam == timeoutTimerId)
					{
						timeoutTimerId = IntPtr.Zero;
					}
					else if (msg.wParam == postTimerId)
					{
						postTimerId = IntPtr.Zero;
						appCallback?.Invoke();
						appCallback = null;
					}
					PostQuitMessage(0);
				}

				TranslateMessage(msg);
				DispatchMessage(msg);
			}
		}
	}
}