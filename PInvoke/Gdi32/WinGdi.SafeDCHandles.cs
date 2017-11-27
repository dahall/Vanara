using System;
using System.Drawing;
using Microsoft.Win32.SafeHandles;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>A SafeHandle to track DC handles.</summary>
		public class SafeDCHandle : SafeHandleZeroOrMinusOneIsInvalid
		{
			/// <summary>A null handle.</summary>
			public static readonly SafeDCHandle Null = new SafeDCHandle(IntPtr.Zero);

			private readonly IDeviceContext idc;

			/// <summary>Initializes a new instance of the <see cref="SafeDCHandle"/> class.</summary>
			/// <param name="hDC">The handle to the DC.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to have the native handle released when this safe handle is disposed or finalized; <see langword="false"/> otherwise.
			/// </param>
			public SafeDCHandle(IntPtr hDC, bool ownsHandle = true) : base(ownsHandle)
			{
				SetHandle(hDC);
			}

			/// <summary>Initializes a new instance of the <see cref="SafeDCHandle"/> class.</summary>
			/// <param name="dc">An <see cref="IDeviceContext"/> instance.</param>
			public SafeDCHandle(IDeviceContext dc) : base(true)
			{
				if (dc == null) return;
				idc = dc;
				SetHandle(dc.GetHdc());
			}

			/// <summary>Gets the screen compatible device context handle.</summary>
			/// <value>The screen compatible device context handle.</value>
			public static SafeDCHandle ScreenCompatibleDCHandle => new SafeDCHandle(CreateCompatibleDC(IntPtr.Zero));

			/// <summary>Performs an explicit conversion from <see cref="SafeDCHandle"/> to <see cref="Graphics"/>.</summary>
			/// <param name="hdc">The HDC.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator Graphics(SafeDCHandle hdc) => Graphics.FromHdc(hdc.handle);

			/// <summary>Performs an implicit conversion from <see cref="Graphics"/> to <see cref="SafeDCHandle"/>.</summary>
			/// <param name="graphics">The <see cref="Graphics"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SafeDCHandle(Graphics graphics) => new SafeDCHandle(graphics);

			/// <summary>Gets the compatible device context handle.</summary>
			/// <returns></returns>
			public SafeDCHandle GetCompatibleDCHandle() => new SafeDCHandle(CreateCompatibleDC(handle));

			/// <inheritdoc/>
			protected override bool ReleaseHandle()
			{
				if (idc == null)
					return DeleteDC(handle);
				idc.ReleaseHdc();
				return true;
			}
		}

		public class SafeDCObjectHandle : SafeHandleZeroOrMinusOneIsInvalid
		{
			private readonly SafeDCHandle hDC;
			private readonly IntPtr hOld;

			public SafeDCObjectHandle(SafeDCHandle hdc, IntPtr hObj) : base(true)
			{
				if (hdc == null || hdc.IsInvalid) return;
				hDC = hdc;
				hOld = SelectObject(hdc, hObj);
				SetHandle(hObj);
			}

			protected override bool ReleaseHandle()
			{
				SelectObject(hDC, hOld);
				return DeleteObject(handle);
			}
		}
	}
}