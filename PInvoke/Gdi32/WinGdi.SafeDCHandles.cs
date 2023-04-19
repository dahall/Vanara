using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Provides a selection context for graphics objects.</summary>
	/// <example>
	/// <code language="cs" title="Using a pen and brush">
	/// using (var screenDC = SafeHDC.ScreenCompatibleDCHandle)
	/// {
	/// var brush = CreateSolidBrush(Color.Red);
	/// using (new GdiObjectContext(screenDC, brush))
	/// {
	/// // Do brush stuff
	/// }
	///
	/// var pen = CreatePen(PS_SOLID, 1, Color.Black);
	/// // Alternatively, call the SelectObject method on the SafeHDC object
	/// using (screenDC.SelectObject(pen))
	/// {
	/// // Do pen stuff
	/// }
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
			if (hdc.IsNull) throw new ArgumentNullException(nameof(hdc), "Device context cannot be null.");
			hDC = hdc;
			hOld = SelectObject(hdc, hObj);
		}

		/// <inheritdoc/>
		void IDisposable.Dispose() => SelectObject(hDC, hOld);
	}

	/// <summary>
	/// Provides a <see cref="System.Runtime.InteropServices.SafeHandle"/> to a graphics bitmap object that releases a created HBITMAP instance at disposal using DeleteObject.
	/// </summary>
	public class SafeHBITMAP : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHBITMAP"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHBITMAP(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHBITMAP() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHBITMAP Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHBITMAP"/> to <see cref="HBITMAP"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBITMAP(SafeHBITMAP h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHBITMAP"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHBITMAP h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HBRUSH instance at disposal using DeleteObject.
	/// </summary>
	public class SafeHBRUSH : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHBRUSH"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHBRUSH(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHBRUSH() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHBRUSH Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHBRUSH"/> to <see cref="HBRUSH"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HBRUSH(SafeHBRUSH h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHBRUSH"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHBRUSH h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}

	/// <summary>A SafeHandle to track DC handles.</summary>
	public class SafeHDC : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHDC"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHDC(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHDC() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHDC Null = new(IntPtr.Zero, false);

		/// <summary>Gets the screen compatible device context handle.</summary>
		/// <value>The screen compatible device context handle.</value>
		public static SafeHDC ScreenCompatibleDCHandle => CreateCompatibleDC(HDC.NULL);

		/// <summary>Performs an implicit conversion from <see cref="SafeHDC"/> to <see cref="HDC"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDC(SafeHDC h) => h.handle;

		/// <summary>Gets the compatible device context handle.</summary>
		/// <returns>A device context handle.</returns>
		public SafeHDC GetCompatibleDCHandle() => CreateCompatibleDC(handle);

		/// <summary>Creates a context into which a graphics object is selected.</summary>
		/// <param name="hObject">The graphics object to select.</param>
		/// <returns>A selection context for the graphics object.</returns>
		public GdiObjectContext SelectObject(HGDIOBJ hObject) => new(handle, hObject);

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteDC(handle);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HFONT instance at disposal using DeleteObject.
	/// </summary>
	public class SafeHFONT : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHFONT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHFONT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHFONT() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHFONT Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHFONT"/> to <see cref="HFONT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFONT(SafeHFONT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHFONT"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHFONT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a graphics color palette object that releases a created HPALETTE instance at disposal
	/// using DeleteObject.
	/// </summary>
	public class SafeHPALETTE : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHPALETTE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPALETTE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHPALETTE() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHPALETTE Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHPALETTE"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHPALETTE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHPALETTE"/> to <see cref="HPALETTE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPALETTE(SafeHPALETTE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HPEN instance at disposal using DeleteObject.
	/// </summary>
	public class SafeHPEN : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHPEN"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPEN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHPEN() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHPEN Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHPEN"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHPEN h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHPEN"/> to <see cref="HPEN"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPEN(SafeHPEN h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> to a graphics bitmap object that releases a created HRGN instance at disposal using DeleteObject.
	/// </summary>
	public class SafeHRGN : SafeHANDLE, IGraphicsObjectHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHRGN"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHRGN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		private SafeHRGN() : base() { }

		/// <summary>A NULL value for this handle.</summary>
		public static readonly SafeHRGN Null = new(IntPtr.Zero, false);

		/// <summary>Performs an implicit conversion from <see cref="SafeHRGN"/> to <see cref="HGDIOBJ"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGDIOBJ(SafeHRGN h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHRGN"/> to <see cref="HRGN"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRGN(SafeHRGN h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(this);
	}
}