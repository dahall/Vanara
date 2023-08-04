using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Contains information about an icon or a cursor.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public sealed class ICONINFO : IDisposable
	{
		/// <summary>
		/// Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies an icon; FALSE specifies a cursor.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIcon;

		/// <summary>
		/// The x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the icon,
		/// and this member is ignored.
		/// </summary>
		public int xHotspot;

		/// <summary>
		/// The y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the
		/// icon, and this member is ignored.
		/// </summary>
		public int yHotspot;

		/// <summary>
		/// The icon bitmask bitmap. If this structure defines a black and white icon, this bitmask is formatted so that the upper half
		/// is the icon AND bitmask and the lower half is the icon XOR bitmask. Under this condition, the height should be an even
		/// multiple of two. If this structure defines a color icon, this mask only defines the AND bitmask of the icon.
		/// </summary>
		public HBITMAP hbmMask;

		/// <summary>
		/// A handle to the icon color bitmap. This member can be optional if this structure defines a black and white icon. The AND
		/// bitmask of hbmMask is applied with the SRCAND flag to the destination; subsequently, the color bitmap is applied (using XOR)
		/// to the destination by using the SRCINVERT flag.
		/// </summary>
		public HBITMAP hbmColor;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			if (!hbmMask.IsNull) DeleteObject(hbmMask);
			if (!hbmColor.IsNull) DeleteObject(hbmColor);
		}
	}
}