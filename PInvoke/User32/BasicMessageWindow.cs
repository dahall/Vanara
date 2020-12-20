using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>Simple window to process messages.</summary>
	/// <seealso cref="System.MarshalByRefObject"/>
	/// <seealso cref="System.IDisposable"/>
	/// <seealso cref="Vanara.PInvoke.IHandle"/>
	public class BasicMessageWindow : MarshalByRefObject, IDisposable, IHandle
	{
		private SafeHWND hwnd;
		private bool isDisposed;

		/// <summary>Initializes a new instance of the <see cref="BasicMessageWindow"/> class.</summary>
		/// <param name="callback">
		/// Specifies the callback method to use to process messages. A <see langword="null"/> value will just use <c>DefWindowProc</c>.
		/// </param>
		public BasicMessageWindow(WindowProc callback = null)
		{
			Callback = callback;
			ClassName = $"MessageWindowBase+{Guid.NewGuid()}";

			hwnd = CreateWindow();
		}

		/// <summary>Finalizes an instance of the <see cref="BasicMessageWindow"/> class.</summary>
		~BasicMessageWindow() => Dispose(false);

		/// <summary>Gets or sets the callback method used to filter window messages.</summary>
		/// <value>The callback method.</value>
		public WindowProc Callback { get; set; }

		/// <summary>Gets the name of the class.</summary>
		/// <value>The name of the class.</value>
		public string ClassName { get; private set; }

		/// <summary>Gets the handle.</summary>
		/// <value>The handle.</value>
		public HWND Handle => hwnd;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		/// <summary>Returns the value of the handle field.</summary>
		/// <returns>An IntPtr representing the value of the handle field.</returns>
		IntPtr IHandle.DangerousGetHandle() => (IntPtr)Handle;

		/// <summary>
		/// Method used to create the window. When overriding, the <c>hWnd</c> field must be set to the handle of the created window.
		/// </summary>
		protected virtual SafeHWND CreateWindow()
		{
			if (0 == RegisterClassEx(new WNDCLASSEX { cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)), lpfnWndProc = WndProc, hInstance = GetModuleHandle(), lpszClassName = ClassName }))
				Win32Error.ThrowLastError();
			return Win32Error.ThrowLastErrorIfInvalid(CreateWindowEx(lpClassName: ClassName, lpWindowName: ClassName, hWndParent: HWND.HWND_MESSAGE));
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (isDisposed)
				return;

			isDisposed = true;

			hwnd?.Dispose();

			UnregisterClass(ClassName, GetModuleHandle());
			ClassName = null;
		}

		private IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			var ret = (Callback ?? DefWindowProc).Invoke(hwnd, msg, wParam, lParam);

			if (msg == (uint)WindowMessage.WM_NCDESTROY)
				Dispose(true);

			return ret;
		}
	}
}