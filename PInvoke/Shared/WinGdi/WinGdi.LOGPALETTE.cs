#nullable enable
using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

/// <summary>The alpha intensity value for the palette entry.</summary>
[PInvokeData("wingdi.h")]
[Flags]
public enum PC : byte
{
	/// <summary>
	/// Specifies that the low-order word of the logical palette entry designates a hardware palette index. This flag allows the
	/// application to show the contents of the display device palette.
	/// </summary>
	PC_EXPLICIT = 0x2,

	/// <summary>
	/// Specifies that the color be placed in an unused entry in the system palette instead of being matched to an existing color in
	/// the system palette. If there are no unused entries in the system palette, the color is matched normally. Once this color is
	/// in the system palette, colors in other logical palettes can be matched to this color.
	/// </summary>
	PC_NOCOLLAPSE = 0x4,

	/// <summary>
	/// Specifies that the logical palette entry be used for palette animation. This flag prevents other windows from matching colors
	/// to the palette entry since the color frequently changes. If an unused system-palette entry is available, the color is placed
	/// in that entry. Otherwise, the color is not available for animation.
	/// </summary>
	PC_RESERVED = 0x1,
}

/// <summary>The <c>LOGPALETTE</c> structure defines a logical palette.</summary>
/// <remarks>
/// The colors in the palette-entry table should appear in order of importance because entries earlier in the logical palette are
/// most likely to be placed in the system palette.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-taglogpalette typedef struct tagLOGPALETTE { WORD
// palVersion; WORD palNumEntries; PALETTEENTRY palPalEntry[1]; } LOGPALETTE, *PLOGPALETTE, *NPLOGPALETTE, *LPLOGPALETTE;
[PInvokeData("wingdi.h", MSDNShortId = "99d70a0e-ac61-4a88-a500-66443e7882ad")]
[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<LOGPALETTE>), nameof(palNumEntries))]
[StructLayout(LayoutKind.Sequential)]
public class LOGPALETTE
{
	/// <summary>The version number of the system.</summary>
	public ushort palVersion;

	/// <summary>The number of entries in the logical palette.</summary>
	public ushort palNumEntries;

	/// <summary>Specifies an array of PALETTEENTRY structures that define the color and usage of each entry in the logical palette.</summary>
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public PALETTEENTRY[]? palPalEntry;
}

/// <summary>Specifies the color and usage of an entry in a logical palette.</summary>
// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagpaletteentry typedef struct tagPALETTEENTRY { BYTE peRed;
// BYTE peGreen; BYTE peBlue; BYTE peFlags; } PALETTEENTRY, *PPALETTEENTRY, *LPPALETTEENTRY;
[PInvokeData("wingdi.h")]
[StructLayout(LayoutKind.Sequential)]
public struct PALETTEENTRY
{
	/// <summary>
	/// <para>Type: <c>BYTE</c></para>
	/// <para>The red intensity value for the palette entry.</para>
	/// </summary>
	public byte peRed;

	/// <summary>
	/// <para>Type: <c>BYTE</c></para>
	/// <para>The green intensity value for the palette entry.</para>
	/// </summary>
	public byte peGreen;

	/// <summary>
	/// <para>Type: <c>BYTE</c></para>
	/// <para>The blue intensity value for the palette entry.</para>
	/// </summary>
	public byte peBlue;

	/// <summary>
	/// <para>Type: <c>BYTE</c></para>
	/// <para>
	/// The alpha intensity value for the palette entry. Note that as of DirectX 8, this member is treated differently than
	/// documented for Windows.
	/// </para>
	/// </summary>
	public PC peFlags;
}