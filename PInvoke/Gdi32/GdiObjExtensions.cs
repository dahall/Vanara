using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

/// <summary>Extension methods to convert GdiObj handle variants to their .NET equivalents.</summary>
public static class GdiObjExtensions
{
	/// <summary>Converts the generic GDI object handle to a specific handle.</summary>
	/// <typeparam name="T">The handle type to which to convert.</typeparam>
	/// <param name="hObj">The generic GDI object handle.</param>
	/// <returns>The converted handle of type <typeparamref name="T"/>.</returns>
	/// <exception cref="ArgumentException">The conversion type specified is not valid for the supplied GDI object.</exception>
	public static T ConvertTo<T>(this IGraphicsObjectHandle hObj) where T : IGraphicsObjectHandle
	{
		var ot = GetObjectType(hObj.DangerousGetHandle());
		if (ot == 0) Win32Error.ThrowLastError();
		if (!CorrespondingTypeAttribute.CanGet(ot, typeof(T)))
			throw new ArgumentException($"The conversion type specified is not valid for the supplied GDI object.");
		return (T)(object)hObj.DangerousGetHandle();
	}

	/// <summary>Draws on a device context (<see cref="SafeHDC"/>) via a DIB section. This is useful when you need to draw on a transparent background.</summary>
	/// <param name="hdc">The device context.</param>
	/// <param name="bounds">The bounds of the device context to paint.</param>
	/// <param name="drawMethod">The draw method.</param>
	public static void DrawViaDIB(this SafeHDC hdc, in RECT bounds, Action<SafeHDC, RECT> drawMethod) => DrawViaDIB((HDC)hdc, bounds, drawMethod);

	/// <summary>Draws on a device context (<see cref="HDC"/>) via a DIB section. This is useful when you need to draw on a transparent background.</summary>
	/// <param name="hdc">The device context.</param>
	/// <param name="bounds">The bounds of the device context to paint.</param>
	/// <param name="drawMethod">The draw method.</param>
	public static void DrawViaDIB(this in HDC hdc, in RECT bounds, Action<SafeHDC, RECT> drawMethod)
	{
		// Create a memory DC so we can work off screen
		using var memoryHdc = CreateCompatibleDC(hdc);
		// Create a device-independent bitmap and select it into our DC
		using var info = new SafeBITMAPINFO(bounds.Width, -bounds.Height);
		using (memoryHdc.SelectObject(CreateDIBSection(hdc, info, DIBColorMode.DIB_RGB_COLORS, out var pBits)))
		{
			// Call method
			drawMethod(memoryHdc, bounds);

			// Copy to foreground
			BitBlt(hdc, bounds.Left, bounds.Top, bounds.Width, bounds.Height, memoryHdc, 0, 0, RasterOperationMode.SRCCOPY);
		}
	}

	/// <summary>Determines whether the bitmap is a bottom-up DIB.</summary>
	/// <param name="hbmp">The handle of the bitmap to assess.</param>
	/// <returns><see langword="true"/> if the specified bitmap is a bottom-up DIB; otherwise, <see langword="false"/>.</returns>
	public static bool IsBottomUpDIB(this in HBITMAP hbmp)
	{
		var dibSz = Marshal.SizeOf(typeof(DIBSECTION));
		using var mem = GetObject(hbmp, dibSz);
		return mem.Size == dibSz && mem.ToStructure<DIBSECTION>().dsBmih.biHeight > 0;
	}

	/// <summary>Determines whether the bitmap is a bottom-up DIB.</summary>
	/// <param name="hbmp">The handle of the bitmap to assess.</param>
	/// <returns><see langword="true"/> if the specified bitmap is a bottom-up DIB; otherwise, <see langword="false"/>.</returns>
	public static bool IsDIB(this in HBITMAP hbmp)
	{
		var dibSz = Marshal.SizeOf(typeof(DIBSECTION));
		using var mem = GetObject(hbmp, dibSz);
		return mem.Size == dibSz;
	}
}