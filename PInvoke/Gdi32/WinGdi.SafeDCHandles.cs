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
	/// <seealso cref="IDisposable"/>
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
		void IDisposable.Dispose()
		{
			SelectObject(hDC, hOld);
			GC.SuppressFinalize(this);
		}
	}

	/// <summary>A safe handle for a graphics object that releases at disposal using DeleteObject.</summary>
	/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
	/// <seealso cref="Vanara.PInvoke.IGraphicsObjectHandle"/>
	/// <remarks>Initializes a new instance of the <see cref="SafeGraphicsObjectHandle"/> class.</remarks>
	/// <param name="preexistingHandle">An <see cref="T:System.IntPtr" /> object that represents the pre-existing handle to use.</param>
	/// <param name="ownsHandle"><see langword="true" /> to reliably release the handle during the finalization phase; otherwise, <see langword="false" /> (not recommended).</param>
	public abstract class SafeGraphicsObjectHandle(IntPtr preexistingHandle, bool ownsHandle = true) : SafeHANDLE(preexistingHandle, ownsHandle), IGraphicsObjectHandle
	{
		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => DeleteObject(handle);
	}

	public partial class SafeHDC
	{
		/// <summary>Gets the screen compatible device context handle.</summary>
		/// <value>The screen compatible device context handle.</value>
		public static SafeHDC ScreenCompatibleDCHandle => CreateCompatibleDC(HDC.NULL);

		/// <summary>Gets the compatible device context handle.</summary>
		/// <returns>A device context handle.</returns>
		public SafeHDC GetCompatibleDCHandle() => CreateCompatibleDC(handle);

		/// <summary>Creates a context into which a graphics object is selected.</summary>
		/// <param name="hObject">The graphics object to select.</param>
		/// <returns>A selection context for the graphics object.</returns>
		public GdiObjectContext SelectObject(HGDIOBJ hObject) => new(handle, hObject);
	}
}