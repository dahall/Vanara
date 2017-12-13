using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>Contains information about an icon or a cursor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public sealed class ICONINFO : IDisposable
		{
			/// <summary>Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies an icon; FALSE specifies a cursor.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIcon;
			/// <summary>
			/// The x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the icon, and this member is ignored.
			/// </summary>
			public int xHotspot;
			/// <summary>
			/// The y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot spot is always in the center of the icon, and this member
			/// is ignored.
			/// </summary>
			public int yHotspot;
			/// <summary>
			/// The icon bitmask bitmap. If this structure defines a black and white icon, this bitmask is formatted so that the upper half is the icon AND
			/// bitmask and the lower half is the icon XOR bitmask. Under this condition, the height should be an even multiple of two. If this structure defines
			/// a color icon, this mask only defines the AND bitmask of the icon.
			/// </summary>
			public IntPtr hbmMask;
			/// <summary>
			/// A handle to the icon color bitmap. This member can be optional if this structure defines a black and white icon. The AND bitmask of hbmMask is
			/// applied with the SRCAND flag to the destination; subsequently, the color bitmap is applied (using XOR) to the destination by using the SRCINVERT flag.
			/// </summary>
			public IntPtr hbmColor;

			/// <summary>Gets the color bitmap associated with the icon.</summary>
			public Bitmap Bitmap => Image.FromHbitmap(hbmColor);

			/// <summary>Gets the AND bitmap mask associated with the icon.</summary>
			public Bitmap Mask => Image.FromHbitmap(hbmMask);

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				if (hbmMask != IntPtr.Zero) DeleteObject(hbmMask);
				if (hbmColor != IntPtr.Zero) DeleteObject(hbmColor);
			}
		}

		/// <summary>Retrieves information about the specified icon or cursor.</summary>
		/// <param name="hIcon">A handle to the icon or cursor. To retrieve information about a standard icon or cursor, specify one of the following values.</param>
		/// <param name="info">A pointer to an ICONINFO structure. The function fills in the structure's members.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero and the function fills in the members of the specified ICONINFO structure. If the function
		/// fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern bool GetIconInfo(IntPtr hIcon, [In, Out] ICONINFO info);
	}
}
 