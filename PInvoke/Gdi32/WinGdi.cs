using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		[PInvokeData("Wingdi.h")]
		public const int LF_FACESIZE = 32;

		[PInvokeData("Wingdi.h")]
		public const int LF_FULLFACESIZE = 64;

		/// <summary>Brush style used by <see cref="LOGBRUSH.lbStyle"/>.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ded2c7a4-2248-4d01-95c6-ab4050719094")]
		public enum BrushStyle : uint
		{
			/// <summary>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERN, the lbHatch member
			/// contains a handle to a packed DIB. For more information, see discussion in lbHatch.
			/// </summary>
			BS_DIBPATTERN = 5,

			/// <summary>See BS_DIBPATTERN.</summary>
			BS_DIBPATTERN8X8 = 8,

			/// <summary>
			/// A pattern brush defined by a device-independent bitmap (DIB) specification. If lbStyle is BS_DIBPATTERNPT, the lbHatch member
			/// contains a pointer to a packed DIB. For more information, see discussion in lbHatch.
			/// </summary>
			BS_DIBPATTERNPT = 6,

			/// <summary>Hatched brush.</summary>
			BS_HATCHED = 2,

			/// <summary>Hollow brush.</summary>
			BS_HOLLOW = 1,

			/// <summary>Not supported.</summary>
			BS_INDEXED = 4,

			/// <summary>Not supported.</summary>
			BS_MONOPATTERN = 9,

			/// <summary>Same as BS_HOLLOW.</summary>
			BS_NULL = 1,

			/// <summary>Pattern brush defined by a memory bitmap.</summary>
			BS_PATTERN = 3,

			/// <summary>See BS_PATTERN.</summary>
			BS_PATTERN8X8 = 7,

			/// <summary>Solid brush.</summary>
			BS_SOLID = 0
		}

		/// <summary>The DC layout used by the <see cref="SetLayout"/> function.</summary>
		[PInvokeData("Wingdi.h", MSDNShortId = "dd162979")]
		public enum DCLayout
		{
			/// <summary>Indicates that on return, the <see cref="SetLayout"/> has failed.</summary>
			GDI_ERROR = -1,

			/// <summary>Sets the default horizontal layout to be right to left.</summary>
			LAYOUT_RTL = 1,

			/// <summary>Sets the default horizontal layout to be bottom to top.</summary>
			LAYOUT_BTT = 2,

			/// <summary>Sets the default horizontal layout to be vertical before horizontal.</summary>
			LAYOUT_VBH = 4,

			/// <summary>Disables any reflection during BitBlt and StretchBlt operations.</summary>
			LAYOUT_BITMAPORIENTATIONPRESERVED = 8,
		}

		/// <summary>Device state flags.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "9a7813fe-358a-44eb-99da-c63f98d055c3")]
		[Flags]
		public enum DISPLAY_DEVICE_FLAGS
		{
			/// <summary>
			/// The DISPLAY_DEVICE_ACTIVE specifies whether a monitor is presented as being "on" by the respective GDI view. Windows Vista:
			/// EnumDisplayDevices will only enumerate monitors that can be presented as being "on."
			/// </summary>
			DISPLAY_DEVICE_ACTIVE = 0x00000001,

			/// <summary>The display device is attached.</summary>
			DISPLAY_DEVICE_ATTACHED = 0x00000002,

			/// <summary>The display device attached to desktop</summary>
			DISPLAY_DEVICE_ATTACHED_TO_DESKTOP = 0x00000001,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_MULTI_DRIVER = 0x00000002,

			/// <summary>
			/// The primary desktop is on the device. For a system with a single display card, this is always set. For a system with multiple
			/// display cards, only one device can have this set.
			/// </summary>
			DISPLAY_DEVICE_PRIMARY_DEVICE = 0x00000004,

			/// <summary>
			/// Represents a pseudo device used to mirror application drawing for remoting or other purposes. An invisible pseudo monitor is
			/// associated with this device. For example, NetMeeting uses it. Note that GetSystemMetrics (SM_MONITORS) only accounts for
			/// visible display monitors.
			/// </summary>
			DISPLAY_DEVICE_MIRRORING_DRIVER = 0x00000008,

			/// <summary>The device is VGA compatible.</summary>
			DISPLAY_DEVICE_VGA_COMPATIBLE = 0x00000010,

			/// <summary>The device is removable; it cannot be the primary display.</summary>
			DISPLAY_DEVICE_REMOVABLE = 0x00000020,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_ACC_DRIVER = 0x00000040,

			/// <summary>The device has more display modes than its output devices support.</summary>
			DISPLAY_DEVICE_MODESPRUNED = 0x08000000,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_RDPUDD = 0x01000000,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_REMOTE = 0x04000000,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_DISCONNECT = 0x02000000,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_TS_COMPATIBLE = 0x00200000,

			/// <summary>Undocumented.</summary>
			DISPLAY_DEVICE_UNSAFE_MODES_ON = 0x00080000,
		}

		/// <summary>Hatch style used by <see cref="LOGBRUSH.lbHatchStyle"/>.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "ded2c7a4-2248-4d01-95c6-ab4050719094")]
		public enum HatchStyle : uint
		{
			/// <summary>A 45-degree upward, left-to-right hatch</summary>
			HS_BDIAGONAL = 3,

			/// <summary>Horizontal and vertical cross-hatch</summary>
			HS_CROSS = 4,

			/// <summary>45-degree crosshatch</summary>
			HS_DIAGCROSS = 5,

			/// <summary>A 45-degree downward, left-to-right hatch</summary>
			HS_FDIAGONAL = 2,

			/// <summary>Horizontal hatch</summary>
			HS_HORIZONTAL = 0,

			/// <summary>Vertical hatch</summary>
			HS_VERTICAL = 1
		}

		/// <summary>Flags specifying how to perform the character set translation.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "0e6e81f1-ec7b-42ba-8706-a352349fa6ab")]
		public enum TCI
		{
			/// <summary>Source contains the character set value in the low word, and 0 in the high word.</summary>
			TCI_SRCCHARSET = 1,

			/// <summary>Source is a code page identifier in the low word and 0 in the high word.</summary>
			TCI_SRCCODEPAGE = 2,

			/// <summary>
			/// Source is the code page bitfield portion of a FONTSIGNATURE structure. On input this should have only one Windows code-page
			/// bit set, either for an ANSI code page value or for a common ANSI and OEM value (for OEM values, bits 32-63 must be clear). On
			/// output, this has only one bit set. If the TCI_SRCFONTSIG value is given, the lpSrc parameter must be the address of the
			/// code-page bitfield. If any other TCI_ value is given, the lpSrc parameter must be a value not an address.
			/// </summary>
			TCI_SRCFONTSIG = 3,

			/// <summary>
			/// Windows 2000: Source is the locale identifier (LCID) or language identifier of the keyboard layout. If it is a language
			/// identifier, the value is in the low word.
			/// </summary>
			TCI_SRCLOCALE = 0x1000
		}

		/// <summary>
		/// <para>
		/// The <c>GetCharWidth</c> function retrieves the widths, in logical coordinates, of consecutive characters in a specified range
		/// from the current font.
		/// </para>
		/// <para>
		/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should call the
		/// GetCharWidth32 function, which provides more accurate results.
		/// </para>
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="iFirst">The first character in the group of consecutive characters.</param>
		/// <param name="iLast">The last character in the group of consecutive characters, which must not precede the specified first character.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the character widths, in logical coordinates.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>GetCharWidth</c> cannot be used on TrueType fonts. To retrieve character widths for TrueType fonts, use GetCharABCWidths.</para>
		/// <para>
		/// The range is inclusive; that is, the returned widths include the widths of the characters specified by the iFirstChar and
		/// iLastChar parameters.
		/// </para>
		/// <para>If a character does not exist in the current font, it is assigned the width of the default character.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidtha
		// BOOL GetCharWidthA( HDC hdc, UINT iFirst, UINT iLast, LPINT lpBuffer );
		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("wingdi.h", MSDNShortId = "be29c195-cf67-45d5-8a46-ac572afb756d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCharWidth(HDC hdc, uint iFirst, uint iLast, [Out] int[] lpBuffer);

		/// <summary>
		/// <para>Retrieves a character set identifier for the font that is currently selected into a specified device context.</para>
		/// <para><c>Note</c> A call to this function is equivalent to a call to GetTextCharsetInfo passing <c>NULL</c> for the data buffer.</para>
		/// </summary>
		/// <param name="hdc">
		/// Handle to a device context. The function obtains a character set identifier for the font that is selected into this device context.
		/// </param>
		/// <returns>
		/// <para>
		/// If successful, returns a value identifying the character set of the font that is currently selected into the specified device
		/// context. The following character set identifiers are defined:
		/// </para>
		/// <para>If the function fails, it returns DEFAULT_CHARSET.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharset int GetTextCharset( HDC hdc );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "11040353-a2ea-42fe-aa89-3438ffc1fea6")]
		public static extern CharacterSetUint GetTextCharset(HDC hdc);

		/// <summary>Retrieves information about the character set of the font that is currently selected into a specified device context.</summary>
		/// <param name="hdc">
		/// Handle to a device context. The function obtains information about the font that is selected into this device context.
		/// </param>
		/// <param name="lpSig">
		/// <para>Pointer to a FONTSIGNATURE data structure that receives font-signature information.</para>
		/// <para>
		/// If a TrueType font is currently selected into the device context, the FONTSIGNATURE structure receives information that
		/// identifies the code page and Unicode subranges for which the font provides glyphs.
		/// </para>
		/// <para>
		/// If a font other than TrueType is currently selected into the device context, the FONTSIGNATURE structure receives zeros. In this
		/// case, the application should use the TranslateCharsetInfo function to obtain generic font-signature information for the character set.
		/// </para>
		/// <para>
		/// The lpSig parameter specifies <c>NULL</c> if the application does not require the FONTSIGNATURE information. In this case, the
		/// application can also call the GetTextCharset function, which is equivalent to calling <c>GetTextCharsetInfo</c> with lpSig set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwFlags">Reserved; must be set to 0.</param>
		/// <returns>
		/// <para>
		/// If successful, returns a value identifying the character set of the font currently selected into the specified device context.
		/// The following character set identifiers are defined:
		/// </para>
		/// <para>If the function fails, the return value is DEFAULT_CHARSET.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharsetinfo int GetTextCharsetInfo( HDC hdc,
		// LPFONTSIGNATURE lpSig, DWORD dwFlags );
		[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "1c8c114a-b261-457c-b541-4648a8f38ee8")]
		public static extern CharacterSetUint GetTextCharsetInfo(HDC hdc, out FONTSIGNATURE lpSig, uint dwFlags = 0);

		/// <summary>Translates character set information and sets all members of a destination structure to appropriate values.</summary>
		/// <param name="lpSrc">
		/// Pointer to the <c>fsCsb</c> member of a FONTSIGNATURE structure if dwFlags is set to TCI_SRCFONTSIG. Otherwise, this parameter is
		/// set to a DWORD value indicating the source.
		/// </param>
		/// <param name="lpCs">Pointer to a CHARSETINFO structure that receives the translated character set information.</param>
		/// <param name="dwFlags">
		/// <para>Flags specifying how to perform the translation. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TCI_SRCCHARSET</term>
		/// <term>Source contains the character set value in the low word, and 0 in the high word.</term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCCODEPAGE</term>
		/// <term>Source is a code page identifier in the low word and 0 in the high word.</term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCFONTSIG</term>
		/// <term>
		/// Source is the code page bitfield portion of a FONTSIGNATURE structure. On input this should have only one Windows code-page bit
		/// set, either for an ANSI code page value or for a common ANSI and OEM value (for OEM values, bits 32-63 must be clear). On output,
		/// this has only one bit set. If the TCI_SRCFONTSIG value is given, the lpSrc parameter must be the address of the code-page
		/// bitfield. If any other TCI_ value is given, the lpSrc parameter must be a value not an address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCLOCALE</term>
		/// <term>
		/// Windows 2000: Source is the locale identifier (LCID) or language identifier of the keyboard layout. If it is a language
		/// identifier, the value is in the low word.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call GetLastError.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-translatecharsetinfo BOOL TranslateCharsetInfo( DWORD *lpSrc,
		// LPCHARSETINFO lpCs, DWORD dwFlags );
		[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0e6e81f1-ec7b-42ba-8706-a352349fa6ab")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TranslateCharsetInfo(ref uint lpSrc, out CHARSETINFO lpCs, TCI dwFlags);

		/// <summary>Translates character set information and sets all members of a destination structure to appropriate values.</summary>
		/// <param name="lpSrc">
		/// Pointer to the <c>fsCsb</c> member of a FONTSIGNATURE structure if dwFlags is set to TCI_SRCFONTSIG. Otherwise, this parameter is
		/// set to a DWORD value indicating the source.
		/// </param>
		/// <param name="lpCs">Pointer to a CHARSETINFO structure that receives the translated character set information.</param>
		/// <param name="dwFlags">
		/// <para>Flags specifying how to perform the translation. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TCI_SRCCHARSET</term>
		/// <term>Source contains the character set value in the low word, and 0 in the high word.</term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCCODEPAGE</term>
		/// <term>Source is a code page identifier in the low word and 0 in the high word.</term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCFONTSIG</term>
		/// <term>
		/// Source is the code page bitfield portion of a FONTSIGNATURE structure. On input this should have only one Windows code-page bit
		/// set, either for an ANSI code page value or for a common ANSI and OEM value (for OEM values, bits 32-63 must be clear). On output,
		/// this has only one bit set. If the TCI_SRCFONTSIG value is given, the lpSrc parameter must be the address of the code-page
		/// bitfield. If any other TCI_ value is given, the lpSrc parameter must be a value not an address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TCI_SRCLOCALE</term>
		/// <term>
		/// Windows 2000: Source is the locale identifier (LCID) or language identifier of the keyboard layout. If it is a language
		/// identifier, the value is in the low word.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call GetLastError.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-translatecharsetinfo BOOL TranslateCharsetInfo( DWORD *lpSrc,
		// LPCHARSETINFO lpCs, DWORD dwFlags );
		[DllImport(Lib.Gdi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wingdi.h", MSDNShortId = "0e6e81f1-ec7b-42ba-8706-a352349fa6ab")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TranslateCharsetInfo(IntPtr lpSrc, out CHARSETINFO lpCs, TCI dwFlags);

		/// <summary>Contains information about a character set.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-charsetinfo typedef struct tagCHARSETINFO { UINT ciCharset;
		// UINT ciACP; FONTSIGNATURE fs; } CHARSETINFO, *PCHARSETINFO, *NPCHARSETINFO, *LPCHARSETINFO;
		[PInvokeData("wingdi.h", MSDNShortId = "4f815f53-9fac-41f3-9493-bd8d68cff543")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CHARSETINFO
		{
			/// <summary>Character set value.</summary>
			public uint ciCharset;

			/// <summary>Windows ANSI code page identifier. For a list of identifiers, see Code Page Identifiers.</summary>
			public uint ciACP;

			/// <summary>
			/// A FONTSIGNATURE structure that identifies the Unicode subrange and the specific Windows ANSI character set/code page. Only
			/// one code page will be set when this structure is set by the function.
			/// </summary>
			public FONTSIGNATURE fs;
		}

		/// <summary>
		/// The <c>DISPLAY_DEVICE</c> structure receives information about the display device specified by the iDevNum parameter of the
		/// EnumDisplayDevices function.
		/// </summary>
		/// <remarks>
		/// The four string members are set based on the parameters passed to EnumDisplayDevices. If the lpDevice param is <c>NULL</c>, then
		/// DISPLAY_DEVICE is filled in with information about the display adapter(s). If it is a valid device name, then it is filled in
		/// with information about the monitor(s) for that device.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-_display_devicea typedef struct _DISPLAY_DEVICEA { DWORD cb;
		// CHAR DeviceName[32]; CHAR DeviceString[128]; DWORD StateFlags; CHAR DeviceID[128]; CHAR DeviceKey[128]; } DISPLAY_DEVICEA,
		// *PDISPLAY_DEVICEA, *LPDISPLAY_DEVICEA;
		[PInvokeData("wingdi.h", MSDNShortId = "9a7813fe-358a-44eb-99da-c63f98d055c3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAY_DEVICE
		{
			/// <summary>Size, in bytes, of the <c>DISPLAY_DEVICE</c> structure. This must be initialized prior to calling EnumDisplayDevices.</summary>
			public uint cb;

			/// <summary>An array of characters identifying the device name. This is either the adapter device or the monitor device.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DeviceName;

			/// <summary>
			/// An array of characters containing the device context string. This is either a description of the display adapter or of the
			/// display monitor.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceString;

			/// <summary>
			/// <para>Device state flags. It can be any reasonable combination of the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DISPLAY_DEVICE_ACTIVE</term>
			/// <term>
			/// DISPLAY_DEVICE_ACTIVE specifies whether a monitor is presented as being "on" by the respective GDI view. Windows Vista:
			/// EnumDisplayDevices will only enumerate monitors that can be presented as being "on."
			/// </term>
			/// </item>
			/// <item>
			/// <term>DISPLAY_DEVICE_MIRRORING_DRIVER</term>
			/// <term>
			/// Represents a pseudo device used to mirror application drawing for remoting or other purposes. An invisible pseudo monitor is
			/// associated with this device. For example, NetMeeting uses it. Note that GetSystemMetrics (SM_MONITORS) only accounts for
			/// visible display monitors.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DISPLAY_DEVICE_MODESPRUNED</term>
			/// <term>The device has more display modes than its output devices support.</term>
			/// </item>
			/// <item>
			/// <term>DISPLAY_DEVICE_PRIMARY_DEVICE</term>
			/// <term>
			/// The primary desktop is on the device. For a system with a single display card, this is always set. For a system with multiple
			/// display cards, only one device can have this set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DISPLAY_DEVICE_REMOVABLE</term>
			/// <term>The device is removable; it cannot be the primary display.</term>
			/// </item>
			/// <item>
			/// <term>DISPLAY_DEVICE_VGA_COMPATIBLE</term>
			/// <term>The device is VGA compatible.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DISPLAY_DEVICE_FLAGS StateFlags;

			/// <summary>Not used.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceID;

			/// <summary>Reserved.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string DeviceKey;

			/// <summary>Gets an empty structure with the <see cref="cb"/> set to the size of the structure.</summary>
			public static readonly DISPLAY_DEVICE Default = new DISPLAY_DEVICE { cb = (uint)Marshal.SizeOf(typeof(DISPLAY_DEVICE)) };
		}
	}
}