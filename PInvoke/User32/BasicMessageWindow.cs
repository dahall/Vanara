using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>A filter method that handles messages sent to a window.</summary>
/// <param name="hwnd">A handle to the window.</param>
/// <param name="msg">The MSG.</param>
/// <param name="wParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
/// <param name="lParam">Additional message information. The contents of this parameter depend on the value of the uMsg parameter.</param>
/// <param name="lReturn">The return value is the result of the message processing and depends on the message sent.</param>
/// <returns>
/// <see langword="true"/> if the message is handled and <see cref="DefWindowProc(HWND, uint, IntPtr, IntPtr)"/> should not be called; <see
/// langword="false"/> otherwise.
/// </returns>
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public delegate bool BasicMessageWindowFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn);

/// <summary>Simple window to process messages.</summary>
/// <seealso cref="MarshalByRefObject"/>
/// <seealso cref="IDisposable"/>
/// <seealso cref="IHandle"/>
public class BasicMessageWindow : MarshalByRefObject, IDisposable, IHandle
{
	private readonly WeakReference weakSelfRef;
	private SafeHWND? hwnd;
	private bool isDisposed;
	private WindowClass? wCls;

	/// <summary>Initializes a new instance of the <see cref="BasicMessageWindow"/> class.</summary>
	/// <param name="callback">Specifies the callback method to use to process messages.</param>
	public BasicMessageWindow(BasicMessageWindowFilter? callback = null)
	{
		MessageFilter = callback;
		weakSelfRef = new WeakReference(this);
		hwnd = CreateWindow();
	}

	/// <summary>Finalizes an instance of the <see cref="BasicMessageWindow"/> class.</summary>
	~BasicMessageWindow() => Dispose(false);

	/// <summary>Gets the handle.</summary>
	/// <value>The handle.</value>
	public HWND Handle => hwnd ?? HWND.NULL;

	/// <summary>Gets or sets the callback method used to filter window messages.</summary>
	/// <value>The callback method.</value>
	public BasicMessageWindowFilter? MessageFilter { get; set; }

	/// <summary>Gets the name of the class.</summary>
	/// <value>The name of the class.</value>
	public string? ClassName => wCls?.ClassName;

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
		lock (this)
		{
			if (!Handle.IsNull)
				throw new InvalidOperationException("Window handle already exists.");
			wCls = new WindowClass($"{GetType().Name}+{Guid.NewGuid()}", default, WndProc, hbrBkgd: WindowClass.NullBrush);
			return Win32Error.ThrowLastErrorIfInvalid(CreateWindowEx(0, wCls.ClassName, hWndParent: HWND.HWND_MESSAGE, hInstance: wCls.wc.hInstance));
		}
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

		hwnd?.Dispose(); // Calls DestroyWindow
		hwnd = null;
		wCls?.Unregister();
	}

	private IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		if (msg == (uint)WindowMessage.WM_NCCREATE)
			return (IntPtr)1;
		return !weakSelfRef.IsAlive || weakSelfRef.Target is null || MessageFilter is null || !MessageFilter.Invoke(hwnd, msg, wParam, lParam, out IntPtr lRet)
			? DefWindowProc(hwnd, msg, wParam, lParam)
			: lRet;
	}
}
