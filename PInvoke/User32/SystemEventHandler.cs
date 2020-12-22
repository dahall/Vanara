using System;
using System.Collections.Generic;
using System.Threading;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>
	/// An event handler that is dependent on window messages. This class works on both windowed and console applications, creating a
	/// threaded message pump if needed.
	/// <para>
	/// To use, derive a class and override the <see cref="MessageFilter"/> method. When handling the message, use the <see
	/// cref="RaiseEvent(Guid, object[])"/> method to call the event.
	/// </para>
	/// <para>
	/// Delegates can be registered and unregistered using unique GUID values via the <see cref="AddEvent(Guid, Delegate)"/> and <see
	/// cref="RemoveEvent(Guid, Delegate)"/> methods.
	/// </para>
	/// </summary>
	/// <seealso cref="System.IDisposable"/>
	public abstract class SystemEventHandler : IDisposable
	{
		private static ManualResetEvent eventWindowReady;
		private static Thread windowThread;
		private readonly Dictionary<Guid, Delegate> eventHandles = new Dictionary<Guid, Delegate>();
		private readonly object lockObj = new object();
		private bool disposedValue;
		private BasicMessageWindow msgWindow;

		/// <summary>Initializes a new instance of the <see cref="SystemEventHandler"/> class.</summary>
		protected SystemEventHandler()
		{
			if (Thread.GetDomain().GetData(".appDomain") != null)
				throw new InvalidOperationException("System events not supported.");

			if (!UserSession.IsInteractive || Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
			{
				Init();
			}
			else
			{
				ThreadRunning = new ManualResetEvent(false);
				eventWindowReady = new ManualResetEvent(false);
				windowThread = new Thread(MTAThreadProc) { IsBackground = true, Name = typeof(SystemEventHandler).FullName };
				windowThread.Start(this);
				eventWindowReady.WaitOne();
			}
		}

		/// <summary>Finalizes an instance of the <see cref="SystemEventHandler"/> class.</summary>
		~SystemEventHandler()
		{
			Dispose(false);
		}

		/// <summary>Gets the message window handle which can be used to register for messaged events.</summary>
		/// <value>The message window handle.</value>
		protected HWND MessageWindowHandle => msgWindow?.Handle ?? HWND.NULL;

		private ManualResetEvent ThreadRunning { get; set; }

		/// <summary>Adds a delegate and its associated key to the handler list.</summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The delegate value.</param>
		public void AddEvent(Guid key, Delegate value)
		{
			lock (lockObj)
			{
				if (!eventHandles.TryGetValue(key, out Delegate h))
				{
					eventHandles.Add(key, value);
					OnEventAdd(key);
				}
				else
				{
					eventHandles[key] = Delegate.Combine(h, value);
				}
			}
		}

		/// <summary>Removes a delegate and its associated key to the handler list.</summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The delegate value.</param>
		public void RemoveEvent(Guid key, Delegate value)
		{
			lock (lockObj)
			{
				if (eventHandles.TryGetValue(key, out Delegate h))
				{
					h = Delegate.Remove(h, value);
					if (h is null || h.GetInvocationList().Length == 0)
					{
						eventHandles.Remove(key);
						OnEventRemove(key);
					}
					else
					{
						eventHandles[key] = h;
					}
				}
				else
				{
					OnEventRemove(key);
				}
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (ThreadRunning != null && IsWindow(MessageWindowHandle))
					{
						PostMessage(MessageWindowHandle, (uint)WindowMessage.WM_QUIT);
						ThreadRunning.WaitOne(5000);
						ThreadRunning = null;
					}
				}

				msgWindow.Dispose();

				disposedValue = true;
			}
		}

		/// <summary>Determines whether the specified key has a delegate handler in its list.</summary>
		/// <param name="key">The key.</param>
		/// <returns><see langword="true"/> if the specified key exists; otherwise, <see langword="false"/>.</returns>
		protected bool HasKey(Guid key)
		{
			lock (lockObj)
				return eventHandles.ContainsKey(key);
		}

		/// <summary>Provides access to the WndProc listening for messages.</summary>
		/// <param name="hwnd">A handle to the window procedure that received the message.</param>
		/// <param name="msg">The message.</param>
		/// <param name="wParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
		/// <param name="lParam">Additional message information. The content of this parameter depends on the value of the Msg parameter.</param>
		/// <param name="lReturn">The return value is the result of the message processing and depends on the message.</param>
		/// <returns>
		/// <see langword="true"/> if this message should be considered handled; or <see langword="false"/> to pass the message along to
		/// <see cref="DefWindowProc"/>.
		/// </returns>
		protected abstract bool MessageFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn);

		/// <summary>Called when an event has been added.</summary>
		/// <param name="key">The event key.</param>
		protected virtual void OnEventAdd(Guid key)
		{
		}

		/// <summary>Called when an event has been removed.</summary>
		/// <param name="key">The event key.</param>
		protected virtual void OnEventRemove(Guid key)
		{
		}

		/// <summary>Calls the delegate list associated with the key, passing the supplied parameters.</summary>
		/// <param name="key">The key.</param>
		/// <param name="args">The arguments.</param>
		/// <returns>The value returned by the call to the delegate list.</returns>
		/// <exception cref="InvalidOperationException">Event for {key} is not registered.</exception>
		protected object RaiseEvent(Guid key, params object[] args)
		{
			Delegate h;
			lock (lockObj)
			{
				if (!eventHandles.TryGetValue(key, out h))
					throw new InvalidOperationException($"Event for {key} is not registered.");
			}
			return h.DynamicInvoke(args);
		}

		private static void MTAThreadProc(object param)
		{
			var handler = (SystemEventHandler)param;
			try
			{
				handler.Init();
				eventWindowReady.Set();
				if (!handler.MessageWindowHandle.IsNull)
				{
					var keepRunning = true;
					while (keepRunning)
					{
						var ret = MsgWaitForMultipleObjectsEx(0, null, 100, QS.QS_ALLINPUT, MWMO.MWMO_INPUTAVAILABLE);
						if (ret == (uint)WAIT_STATUS.WAIT_TIMEOUT)
						{
							Thread.Sleep(1);
						}
						else
						{
							while (PeekMessage(out MSG msg, wRemoveMsg: PM.PM_REMOVE))
							{
								if (msg.message == (uint)WindowMessage.WM_QUIT)
								{
									keepRunning = false;
									break;
								}
								TranslateMessage(msg);
								DispatchMessage(msg);
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				eventWindowReady.Set();
				if (e is not (ThreadInterruptedException or ThreadAbortException))
					System.Diagnostics.Debug.Fail("Unexpected thread exception in SystemEventHandler thread.", e.ToString());
			}

			handler.ThreadRunning.Set();
		}

		private void Init()
		{
			msgWindow = new BasicMessageWindow(MessageFilter);
		}
	}

	internal static class UserSession
	{
		private static bool isUserInteractive;
		private static HWINSTA processWinStation;

		public static bool IsInteractive
		{
			get
			{
				if (Environment.OSVersion.Platform == System.PlatformID.Win32NT)
				{
					HWINSTA hwinsta = GetProcessWindowStation();
					if (!hwinsta.IsNull && processWinStation != hwinsta)
					{
						using var flags = new SafeCoTaskMemStruct<USEROBJECTFLAGS>();
						isUserInteractive = !GetUserObjectInformation((IntPtr)hwinsta, UserObjectInformationType.UOI_FLAGS, flags, flags.Size, out _) || (flags.Value.dwFlags & 0x0001 /*WSF_VISIBLE*/) != 0;
						processWinStation = hwinsta;
					}
				}
				else
				{
					isUserInteractive = true;
				}
				return isUserInteractive;
			}
		}
	}
}