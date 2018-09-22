using System;
using System.Drawing;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>Provides a selection context for graphics objects.</summary>
		/// <example>
		/// <code language="cs" title="Using a pen and brush">
		/// using (var screenDC = SafeHDC.ScreenCompatibleDCHandle)
		/// {
		///    var brush = CreateSolidBrush(Color.Red);
		///    using (new GdiObjectContext(screenDC, brush))
		///    {
		///       // Do brush stuff
		///    }
		///	   
		///    var pen = CreatePen(PS_SOLID, 1, Color.Black);
		///    // Alternatively, call the SelectObject method on the SafeHDC object
		///    using (screenDC.SelectObject(pen))
		///    {
		///       // Do pen stuff
		///    }
		/// }
		/// </code>
		/// </example>
		/// <seealso cref="System.IDisposable"/>
		public class GdiObjectContext : IDisposable
		{
			private readonly HDC hDC;
			private readonly HGDIOBJ hOld;

			/// <summary>Initializes a new instance of the <see cref="GdiObjectContext"/> class.</summary>
			/// <param name="hdc">The HDC into which <paramref name="hObj"/> is selected.</param>
			/// <param name="hObj">The graphics object to select.</param>
			/// <exception cref="ArgumentNullException">hdc - Device context cannot be null.</exception>
			public GdiObjectContext(HDC hdc, HGDIOBJ hObj)
			{
				if (hdc == null || hdc.IsInvalid) throw new ArgumentNullException(nameof(hdc), "Device context cannot be null.");
				hDC = hdc;
				hOld = SelectObject(hdc, hObj);
			}

			/// <summary>Initializes a new instance of the <see cref="GdiObjectContext"/> class.</summary>
			/// <param name="hdc">The device context into which <paramref name="hObj"/> is selected.</param>
			/// <param name="hObj">The graphics object to select.</param>
			/// <exception cref="ArgumentNullException">dc - Device context cannot be null.</exception>
			public GdiObjectContext(IDeviceContext dc, HGDIOBJ hObj) : this(new SafeHDC(dc ?? throw new ArgumentNullException(nameof(dc), "Device context cannot be null.")), hObj) { }

			/// <inheritdoc/>
			void IDisposable.Dispose() => SelectObject(hDC, hOld);
		}

		/// <summary>A SafeHandle to track DC handles.</summary>
		public class SafeHDC : HDC
		{
			private readonly IDeviceContext idc;

			/// <summary>Initializes a new instance of the <see cref="SafeHDC"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHDC(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHDC"/> class.</summary>
			/// <param name="dc">An <see cref="IDeviceContext"/> instance.</param>
			public SafeHDC(IDeviceContext dc) : base(IntPtr.Zero)
			{
				if (dc == null) return;
				idc = dc;
				SetHandle(dc.GetHdc());
			}

			/// <summary>Gets the screen compatible device context handle.</summary>
			/// <value>The screen compatible device context handle.</value>
			public static SafeHDC ScreenCompatibleDCHandle => CreateCompatibleDC(NULL);

			/// <summary>Performs an explicit conversion from <see cref="SafeHDC"/> to <see cref="Graphics"/>.</summary>
			/// <param name="hdc">The HDC.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator Graphics(SafeHDC hdc) => Graphics.FromHdc(hdc.handle);

			/// <summary>Performs an implicit conversion from <see cref="Graphics"/> to <see cref="SafeHDC"/>.</summary>
			/// <param name="graphics">The <see cref="Graphics"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SafeHDC(Graphics graphics) => new SafeHDC(graphics);

			/// <summary>Gets the compatible device context handle.</summary>
			/// <returns></returns>
			public SafeHDC GetCompatibleDCHandle() => CreateCompatibleDC(this);

			/// <summary>Creates a context into which a graphics object is selected.</summary>
			/// <param name="hObject">The graphics object to select.</param>
			/// <returns>A selection context for the graphics object.</returns>
			public GdiObjectContext SelectObject(HGDIOBJ hObject) => new GdiObjectContext(this, hObject);

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle()
			{
				if (idc == null)
					return DeleteDC(this);
				idc.ReleaseHdc();
				return true;
			}
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics object that releases a created HGDIOBJ instance at disposal using DeleteObject.
		/// </summary>
		public abstract class SafeHGDIOBJ : HGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHGDIOBJ"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			protected SafeHGDIOBJ(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteObject(this);
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HBITMAP instance at disposal using DeleteObject.
		/// </summary>
		public class SafeHBITMAP : SafeHGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHBITMAP"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHBITMAP(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			new public static SafeHBITMAP NULL => new SafeHBITMAP(IntPtr.Zero);

			/// <summary>Creates a managed <see cref="System.Drawing.Bitmap"/> from this HBITMAP instance.</summary>
			/// <returns>A managed bitmap instance.</returns>
			public Bitmap ToBitmap() => IsInvalid ? null : (Bitmap)Image.FromHbitmap(handle).Clone();
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HBRUSH instance at disposal using DeleteObject.
		/// </summary>
		public class SafeHBRUSH : SafeHGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHBRUSH"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHBRUSH(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			new public static SafeHBRUSH NULL => new SafeHBRUSH(IntPtr.Zero);

			/// <summary>Creates a managed <see cref="System.Drawing.Brush"/> from this HBRUSH instance.</summary>
			/// <returns>A managed brush instance.</returns>
			public Brush ToBrush() => IsInvalid ? null : new NativeBrush(this);

			private class NativeBrush : Brush
			{
				public NativeBrush(SafeHBRUSH hBrush)
				{
					var lb = GetObject<LOGBRUSH>(hBrush);
					var b2 = CreateBrushIndirect(ref lb);
					SetNativeBrush(b2.DangerousGetHandle());
					b2.SetHandleAsInvalid();
				}

				public override object Clone() => this;
			}
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HFONT instance at disposal using DeleteObject.
		/// </summary>
		public class SafeHFONT : SafeHGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHFONT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHFONT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			new public static SafeHFONT NULL => new SafeHFONT(IntPtr.Zero);
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HPEN instance at disposal using DeleteObject.
		/// </summary>
		public class SafeHPEN : SafeHGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHPEN"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPEN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			new public static SafeHPEN NULL => new SafeHPEN(IntPtr.Zero);
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HRGN instance at disposal using DeleteObject.
		/// </summary>
		public class SafeHRGN : SafeHGDIOBJ
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHRGN"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHRGN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGDIOBJ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			new public static SafeHRGN NULL => new SafeHRGN(IntPtr.Zero);
		}
	}
}