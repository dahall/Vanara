using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;
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
		private static readonly Dictionary<HWND, BasicMessageWindow> s_lookup = new Dictionary<HWND, BasicMessageWindow>();
		private static readonly WindowProc s_WndProc = new WindowProc(WndProc);
		private bool isDisposed;

		/// <summary>The safe handle of the registered and created window.</summary>
		protected SafeHWND hWnd;

		/// <summary>Initializes a new instance of the <see cref="BasicMessageWindow"/> class.</summary>
		/// <param name="callback">
		/// Specifies the callback method to use to process messages. A <see langword="null"/> value will just use <c>DefWindowProc</c>.
		/// </param>
		public BasicMessageWindow(WindowProc callback = null)
		{
			Callback = callback;
			ClassName = "MessageWindowBaseClass+" + Guid.NewGuid().ToString();

			CreateWindow();
		}

		/// <summary>Finalizes an instance of the <see cref="BasicMessageWindow"/> class.</summary>
		~BasicMessageWindow()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: false);
		}

		/// <summary>Gets or sets the callback method used to filter window messages.</summary>
		/// <value>The callback method.</value>
		public WindowProc Callback { get; set; }

		/// <summary>Gets the name of the class.</summary>
		/// <value>The name of the class.</value>
		public string ClassName { get; private set; }

		/// <summary>Gets the handle.</summary>
		/// <value>The handle.</value>
		public HWND Handle => hWnd;

		/// <summary>Returns the value of the handle field.</summary>
		/// <returns>An IntPtr representing the value of the handle field.</returns>
		public IntPtr DangerousGetHandle() => ((IHandle)hWnd).DangerousGetHandle();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Method used to create the window. When overriding, the <c>hWnd</c> field must be set to the handle of the created window.
		/// </summary>
		protected virtual void CreateWindow()
		{
			var wc = new WNDCLASSEX
			{
				cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
				lpfnWndProc = s_WndProc,
				hInstance = GetModuleHandle(),
				lpszClassName = ClassName,
			};

			RegisterClassEx(wc);

			using var pinnedThisPtr = new PinnedObject(this);
			hWnd = CreateWindowEx(lpClassName: ClassName, lpWindowName: "", hWndParent: HWND.HWND_MESSAGE, lpParam: pinnedThisPtr);
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
			hWnd.Dispose();
			UnregisterClass(ClassName, GetModuleHandle());
			ClassName = null;
		}

		private static IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			BasicMessageWindow hwndWrapper = null;

			if (msg == (uint)WindowMessage.WM_CREATE)
			{
				var createStruct = lParam.ToStructure<CREATESTRUCT>();
				GCHandle gcHandle = GCHandle.FromIntPtr(createStruct.lpCreateParams);
				hwndWrapper = (BasicMessageWindow)gcHandle.Target;
				s_lookup.Add(hwnd, hwndWrapper);
			}
			else if (!s_lookup.TryGetValue(hwnd, out hwndWrapper))
			{
				return DefWindowProc(hwnd, msg, wParam, lParam);
			}

			if (hwndWrapper is null)
				throw new InvalidOperationException();

			var ret = (hwndWrapper.Callback ?? DefWindowProc)(hwnd, msg, wParam, lParam);

			if (msg == (uint)WindowMessage.WM_NCDESTROY)
			{
				hwndWrapper.Dispose(true);
				System.GC.SuppressFinalize(hwndWrapper);
			}

			return ret;
		}
	}
}