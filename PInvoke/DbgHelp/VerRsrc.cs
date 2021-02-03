using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class WinVer
	{
		/// <summary>The general type of file.</summary>
		[PInvokeData("verrsrc.h", MSDNShortId = "NS:verrsrc.tagVS_FIXEDFILEINFO")]
		public enum VFT : uint
		{
			/// <summary>The file type is unknown to the system.</summary>
			VFT_UNKNOWN = 0x00000000,

			/// <summary>The file contains an application.</summary>
			VFT_APP = 0x00000001,

			/// <summary>The file contains a DLL.</summary>
			VFT_DLL = 0x00000002,

			/// <summary>
			/// The file contains a device driver. If dwFileType is VFT_DRV, dwFileSubtype contains a more specific description of the driver.
			/// </summary>
			VFT_DRV = 0x00000003,

			/// <summary>
			/// The file contains a font. If dwFileType is VFT_FONT, dwFileSubtype contains a more specific description of the font file.
			/// </summary>
			VFT_FONT = 0x00000004,

			/// <summary/>
			VFT_VXD = 0x00000005,

			/// <summary>The file contains a static-link library.</summary>
			VFT_STATIC_LIB = 0x00000007,
		}

		/// <summary>The function of the file.</summary>
		[PInvokeData("verrsrc.h", MSDNShortId = "NS:verrsrc.tagVS_FIXEDFILEINFO")]
		public enum VFT2 : uint
		{
			/// <summary>The file contains a communications driver.</summary>
			VFT2_DRV_COMM = 0x0000000A,

			/// <summary>The file contains a display driver.</summary>
			VFT2_DRV_DISPLAY = 0x00000004,

			/// <summary>The file contains an installable driver.</summary>
			VFT2_DRV_INSTALLABLE = 0x00000008,

			/// <summary>The file contains a keyboard driver.</summary>
			VFT2_DRV_KEYBOARD = 0x00000002,

			/// <summary>The file contains a language driver.</summary>
			VFT2_DRV_LANGUAGE = 0x00000003,

			/// <summary>The file contains a mouse driver.</summary>
			VFT2_DRV_MOUSE = 0x00000005,

			/// <summary>The file contains a network driver.</summary>
			VFT2_DRV_NETWORK = 0x00000006,

			/// <summary>The file contains a printer driver.</summary>
			VFT2_DRV_PRINTER = 0x00000001,

			/// <summary>The file contains a sound driver.</summary>
			VFT2_DRV_SOUND = 0x00000009,

			/// <summary>The file contains a system driver.</summary>
			VFT2_DRV_SYSTEM = 0x00000007,

			/// <summary>The file contains a versioned printer driver.</summary>
			VFT2_DRV_VERSIONED_PRINTER = 0x0000000C,

			/// <summary>The driver type is unknown by the system.</summary>
			VFT2_UNKNOWN = 0x00000000,

			/// <summary>The file contains a raster font.</summary>
			VFT2_FONT_RASTER = 0x00000001,

			/// <summary>The file contains a TrueType font.</summary>
			VFT2_FONT_TRUETYPE = 0x00000003,

			/// <summary>The file contains a vector font.</summary>
			VFT2_FONT_VECTOR = 0x00000002,
		}

		/// <summary>The operating system for which this file was designed.</summary>
		[PInvokeData("verrsrc.h", MSDNShortId = "NS:verrsrc.tagVS_FIXEDFILEINFO")]
		public enum VOS : uint
		{
			/// <summary>The operating system for which the file was designed is unknown to the system.</summary>
			VOS_UNKNOWN = 0x00000000,

			/// <summary>The file was designed for MS-DOS.</summary>
			VOS_DOS = 0x00010000,

			/// <summary>The file was designed for 16-bit OS/2.</summary>
			VOS_OS216 = 0x00020000,

			/// <summary>The file was designed for 32-bit OS/2.</summary>
			VOS_OS232 = 0x00030000,

			/// <summary>The file was designed for Windows NT.</summary>
			VOS_NT = 0x00040000,

			/// <summary>The file was designed for Windows CE.</summary>
			VOS_WINCE = 0x00050000,

			/// <summary/>
			VOS__BASE = 0x00000000,

			/// <summary>The file was designed for 16-bit Windows.</summary>
			VOS__WINDOWS16 = 0x00000001,

			/// <summary>The file was designed for 16-bit Presentation Manager.</summary>
			VOS__PM16 = 0x00000002,

			/// <summary>The file was designed for 32-bit Presentation Manager.</summary>
			VOS__PM32 = 0x00000003,

			/// <summary>The file was designed for 32-bit Windows.</summary>
			VOS__WINDOWS32 = 0x00000004,

			/// <summary>The file was designed for 16-bit Windows running on MS-DOS.</summary>
			VOS_DOS_WINDOWS16 = 0x00010001,

			/// <summary>The file was designed for 32-bit Windows running on MS-DOS.</summary>
			VOS_DOS_WINDOWS32 = 0x00010004,

			/// <summary>The file was designed for 16-bit Presentation Manager running on 16-bit OS/2.</summary>
			VOS_OS216_PM16 = 0x00020002,

			/// <summary>The file was designed for 32-bit Presentation Manager running on 32-bit OS/2.</summary>
			VOS_OS232_PM32 = 0x00030003,

			/// <summary>The file was designed for Windows NT.</summary>
			VOS_NT_WINDOWS32 = 0x00040004,
		}

		/// <summary>Contains a bitmask that specifies the Boolean attributes of the file.</summary>
		[PInvokeData("verrsrc.h", MSDNShortId = "NS:verrsrc.tagVS_FIXEDFILEINFO")]
		[Flags]
		public enum VS_FF : uint
		{
			/// <summary>The file contains debugging information or is compiled with debugging features enabled.</summary>
			VS_FF_DEBUG = 0x00000001,

			/// <summary>The file is a development version, not a commercially released product.</summary>
			VS_FF_PRERELEASE = 0x00000002,

			/// <summary>The file has been modified and is not identical to the original shipping file of the same version number.</summary>
			VS_FF_PATCHED = 0x00000004,

			/// <summary>
			/// The file was not built using standard release procedures. If this flag is set, the StringFileInfo structure should contain a
			/// PrivateBuild entry.
			/// </summary>
			VS_FF_PRIVATEBUILD = 0x00000008,

			/// <summary>
			/// The file's version structure was created dynamically; therefore, some of the members in this structure may be empty or
			/// incorrect. This flag should never be set in a file's VS_VERSIONINFO data.
			/// </summary>
			VS_FF_INFOINFERRED = 0x00000010,

			/// <summary>
			/// The file was built by the original company using standard release procedures but is a variation of the normal file of the
			/// same version number. If this flag is set, the StringFileInfo structure should contain a SpecialBuild entry.
			/// </summary>
			VS_FF_SPECIALBUILD = 0x00000020,
		}

		/// <summary>Contains version information for a file. This information is language and code page independent.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/verrsrc/ns-verrsrc-vs_fixedfileinfo typedef struct tagVS_FIXEDFILEINFO { DWORD
		// dwSignature; DWORD dwStrucVersion; DWORD dwFileVersionMS; DWORD dwFileVersionLS; DWORD dwProductVersionMS; DWORD
		// dwProductVersionLS; DWORD dwFileFlagsMask; DWORD dwFileFlags; DWORD dwFileOS; DWORD dwFileType; DWORD dwFileSubtype; DWORD
		// dwFileDateMS; DWORD dwFileDateLS; } VS_FIXEDFILEINFO;
		[PInvokeData("verrsrc.h", MSDNShortId = "NS:verrsrc.tagVS_FIXEDFILEINFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct VS_FIXEDFILEINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Contains the value 0xFEEF04BD. This is used with the <c>szKey</c> member of the VS_VERSIONINFO structure when searching a
			/// file for the <c>VS_FIXEDFILEINFO</c> structure.
			/// </para>
			/// </summary>
			public uint dwSignature;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The binary version number of this structure. The high-order word of this member contains the major version number, and the
			/// low-order word contains the minor version number.
			/// </para>
			/// </summary>
			public uint dwStrucVersion;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The most significant 32 bits of the file's binary version number. This member is used with <c>dwFileVersionLS</c> to form a
			/// 64-bit value used for numeric comparisons.
			/// </para>
			/// </summary>
			public uint dwFileVersionMS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The least significant 32 bits of the file's binary version number. This member is used with <c>dwFileVersionMS</c> to form a
			/// 64-bit value used for numeric comparisons.
			/// </para>
			/// </summary>
			public uint dwFileVersionLS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The most significant 32 bits of the binary version number of the product with which this file was distributed. This member
			/// is used with <c>dwProductVersionLS</c> to form a 64-bit value used for numeric comparisons.
			/// </para>
			/// </summary>
			public uint dwProductVersionMS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The least significant 32 bits of the binary version number of the product with which this file was distributed. This member
			/// is used with <c>dwProductVersionMS</c> to form a 64-bit value used for numeric comparisons.
			/// </para>
			/// </summary>
			public uint dwProductVersionLS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Contains a bitmask that specifies the valid bits in <c>dwFileFlags</c>. A bit is valid only if it was defined when the file
			/// was created.
			/// </para>
			/// </summary>
			public VS_FF dwFileFlagsMask;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Contains a bitmask that specifies the Boolean attributes of the file. This member can include one or more of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VS_FF_DEBUG 0x00000001L</term>
			/// <term>The file contains debugging information or is compiled with debugging features enabled.</term>
			/// </item>
			/// <item>
			/// <term>VS_FF_INFOINFERRED 0x00000010L</term>
			/// <term>
			/// The file's version structure was created dynamically; therefore, some of the members in this structure may be empty or
			/// incorrect. This flag should never be set in a file's VS_VERSIONINFO data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VS_FF_PATCHED 0x00000004L</term>
			/// <term>The file has been modified and is not identical to the original shipping file of the same version number.</term>
			/// </item>
			/// <item>
			/// <term>VS_FF_PRERELEASE 0x00000002L</term>
			/// <term>The file is a development version, not a commercially released product.</term>
			/// </item>
			/// <item>
			/// <term>VS_FF_PRIVATEBUILD 0x00000008L</term>
			/// <term>
			/// The file was not built using standard release procedures. If this flag is set, the StringFileInfo structure should contain a
			/// PrivateBuild entry.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VS_FF_SPECIALBUILD 0x00000020L</term>
			/// <term>
			/// The file was built by the original company using standard release procedures but is a variation of the normal file of the
			/// same version number. If this flag is set, the StringFileInfo structure should contain a SpecialBuild entry.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public VS_FF dwFileFlags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The operating system for which this file was designed. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VOS_DOS 0x00010000L</term>
			/// <term>The file was designed for MS-DOS.</term>
			/// </item>
			/// <item>
			/// <term>VOS_NT 0x00040000L</term>
			/// <term>The file was designed for Windows NT.</term>
			/// </item>
			/// <item>
			/// <term>VOS__WINDOWS16 0x00000001L</term>
			/// <term>The file was designed for 16-bit Windows.</term>
			/// </item>
			/// <item>
			/// <term>VOS__WINDOWS32 0x00000004L</term>
			/// <term>The file was designed for 32-bit Windows.</term>
			/// </item>
			/// <item>
			/// <term>VOS_OS216 0x00020000L</term>
			/// <term>The file was designed for 16-bit OS/2.</term>
			/// </item>
			/// <item>
			/// <term>VOS_OS232 0x00030000L</term>
			/// <term>The file was designed for 32-bit OS/2.</term>
			/// </item>
			/// <item>
			/// <term>VOS__PM16 0x00000002L</term>
			/// <term>The file was designed for 16-bit Presentation Manager.</term>
			/// </item>
			/// <item>
			/// <term>VOS__PM32 0x00000003L</term>
			/// <term>The file was designed for 32-bit Presentation Manager.</term>
			/// </item>
			/// <item>
			/// <term>VOS_UNKNOWN 0x00000000L</term>
			/// <term>The operating system for which the file was designed is unknown to the system.</term>
			/// </item>
			/// </list>
			/// <para>
			/// An application can combine these values to indicate that the file was designed for one operating system running on another.
			/// The following <c>dwFileOS</c> values are examples of this, but are not a complete list.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VOS_DOS_WINDOWS16 0x00010001L</term>
			/// <term>The file was designed for 16-bit Windows running on MS-DOS.</term>
			/// </item>
			/// <item>
			/// <term>VOS_DOS_WINDOWS32 0x00010004L</term>
			/// <term>The file was designed for 32-bit Windows running on MS-DOS.</term>
			/// </item>
			/// <item>
			/// <term>VOS_NT_WINDOWS32 0x00040004L</term>
			/// <term>The file was designed for Windows NT.</term>
			/// </item>
			/// <item>
			/// <term>VOS_OS216_PM16 0x00020002L</term>
			/// <term>The file was designed for 16-bit Presentation Manager running on 16-bit OS/2.</term>
			/// </item>
			/// <item>
			/// <term>VOS_OS232_PM32 0x00030003L</term>
			/// <term>The file was designed for 32-bit Presentation Manager running on 32-bit OS/2.</term>
			/// </item>
			/// </list>
			/// </summary>
			public VOS dwFileOS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The general type of file. This member can be one of the following values. All other values are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VFT_APP 0x00000001L</term>
			/// <term>The file contains an application.</term>
			/// </item>
			/// <item>
			/// <term>VFT_DLL 0x00000002L</term>
			/// <term>The file contains a DLL.</term>
			/// </item>
			/// <item>
			/// <term>VFT_DRV 0x00000003L</term>
			/// <term>
			/// The file contains a device driver. If dwFileType is VFT_DRV, dwFileSubtype contains a more specific description of the driver.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VFT_FONT 0x00000004L</term>
			/// <term>
			/// The file contains a font. If dwFileType is VFT_FONT, dwFileSubtype contains a more specific description of the font file.
			/// </term>
			/// </item>
			/// <item>
			/// <term>VFT_STATIC_LIB 0x00000007L</term>
			/// <term>The file contains a static-link library.</term>
			/// </item>
			/// <item>
			/// <term>VFT_UNKNOWN 0x00000000L</term>
			/// <term>The file type is unknown to the system.</term>
			/// </item>
			/// <item>
			/// <term>VFT_VXD 0x00000005L</term>
			/// <term>The file contains a virtual device.</term>
			/// </item>
			/// </list>
			/// </summary>
			public VFT dwFileType;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The function of the file. The possible values depend on the value of <c>dwFileType</c>. For all values of <c>dwFileType</c>
			/// not described in the following list, <c>dwFileSubtype</c> is zero.
			/// </para>
			/// <para>If <c>dwFileType</c> is <c>VFT_DRV</c>, <c>dwFileSubtype</c> can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VFT2_DRV_COMM 0x0000000AL</term>
			/// <term>The file contains a communications driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_DISPLAY 0x00000004L</term>
			/// <term>The file contains a display driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_INSTALLABLE 0x00000008L</term>
			/// <term>The file contains an installable driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_KEYBOARD 0x00000002L</term>
			/// <term>The file contains a keyboard driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_LANGUAGE 0x00000003L</term>
			/// <term>The file contains a language driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_MOUSE 0x00000005L</term>
			/// <term>The file contains a mouse driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_NETWORK 0x00000006L</term>
			/// <term>The file contains a network driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_PRINTER 0x00000001L</term>
			/// <term>The file contains a printer driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_SOUND 0x00000009L</term>
			/// <term>The file contains a sound driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_SYSTEM 0x00000007L</term>
			/// <term>The file contains a system driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_DRV_VERSIONED_PRINTER 0x0000000CL</term>
			/// <term>The file contains a versioned printer driver.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_UNKNOWN 0x00000000L</term>
			/// <term>The driver type is unknown by the system.</term>
			/// </item>
			/// </list>
			/// <para>If <c>dwFileType</c> is <c>VFT_FONT</c>, <c>dwFileSubtype</c> can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VFT2_FONT_RASTER 0x00000001L</term>
			/// <term>The file contains a raster font.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_FONT_TRUETYPE 0x00000003L</term>
			/// <term>The file contains a TrueType font.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_FONT_VECTOR 0x00000002L</term>
			/// <term>The file contains a vector font.</term>
			/// </item>
			/// <item>
			/// <term>VFT2_UNKNOWN 0x00000000L</term>
			/// <term>The font type is unknown by the system.</term>
			/// </item>
			/// </list>
			/// <para>
			/// If <c>dwFileType</c> is <c>VFT_VXD</c>, <c>dwFileSubtype</c> contains the virtual device identifier included in the virtual
			/// device control block.
			/// </para>
			/// <para>All <c>dwFileSubtype</c> values not listed here are reserved.</para>
			/// </summary>
			public VFT2 dwFileSubtype;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The most significant 32 bits of the file's 64-bit binary creation date and time stamp.</para>
			/// </summary>
			public uint dwFileDateMS;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The least significant 32 bits of the file's 64-bit binary creation date and time stamp.</para>
			/// </summary>
			public uint dwFileDateLS;
		}
	}
}