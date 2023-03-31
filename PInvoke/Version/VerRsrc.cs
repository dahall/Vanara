using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class VersionDll
{
	/// <summary>Controls which MUI DLLs (if any) from which the version resource is extracted.</summary>
	[PInvokeData("verrsrc.h")]
	[Flags]
	public enum FILE_VER_GET : uint
	{
		/// <summary>
		/// Loads the entire version resource (both strings and binary version information) from the corresponding MUI file, if available.
		/// </summary>
		FILE_VER_GET_LOCALISED = 0x01,

		/// <summary>
		/// Loads the version resource strings from the corresponding MUI file, if available, and loads the binary version information
		/// (VS_FIXEDFILEINFO) from the corresponding language-neutral file, if available.
		/// </summary>
		FILE_VER_GET_NEUTRAL = 0x02,

		/// <summary>
		/// Indicates a preference for version.dll to attempt to preload the image outside of the loader lock to avoid contention. This
		/// flag does not change the behavior or semantics of the function.
		/// </summary>
		FILE_VER_GET_PREFETCHED = 0x04
	}

	/// <summary>Return codes for <c>VerFindFile</c>.</summary>
	[PInvokeData("verrsrc.h")]
	[Flags]
	public enum VFF : uint
	{
		/// <summary>The currently installed version of the file is not in the recommended destination.</summary>
		VFF_CURNEDEST = 0x0001,

		/// <summary>
		/// The system is using the currently installed version of the file; therefore, the file cannot be overwritten or deleted.
		/// </summary>
		VFF_FILEINUSE = 0x0002,

		/// <summary>
		/// At least one of the buffers was too small to contain the corresponding string. An application should check the output
		/// buffers to determine which buffer was too small.
		/// </summary>
		VFF_BUFFTOOSMALL = 0x0004,
	}

	/// <summary>Flags for <c>VerFindFile</c>.</summary>
	[PInvokeData("verrsrc.h")]
	[Flags]
	public enum VFFF : uint
	{
		/// <term>
		/// The source file can be shared by multiple applications. An application can use this information to determine where the file
		/// should be copied.
		/// </term>
		VFFF_ISSHAREDFILE = 0x0001,
	}

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

	/// <summary>The return value for <see cref="VerInstallFile"/> that indicates exceptions.</summary>
	[PInvokeData("verrsrc.h")]
	[Flags]
	public enum VIF : uint
	{
		/// <summary>
		/// The szTmpFile buffer was too small to contain the name of the temporary source file. When the function returns,
		/// lpuTmpFileLen contains the size of the buffer required to hold the filename.
		/// </summary>
		VIF_BUFFTOOSMALL = 0x00040000,

		/// <summary>The function cannot create the temporary file. The specific error may be described by another flag.</summary>
		VIF_CANNOTCREATE = 0x00000800,

		/// <summary>
		/// The function cannot delete the destination file, or cannot delete the existing version of the file located in another
		/// directory. If the VIF_TEMPFILE bit is set, the installation failed, and the destination file probably cannot be deleted.
		/// </summary>
		VIF_CANNOTDELETE = 0x00001000,

		/// <summary>The existing version of the file could not be deleted and VIFF_DONTDELETEOLD was not specified.</summary>
		VIF_CANNOTDELETECUR = 0x00004000,

		/// <summary>The function cannot load the cabinet file.</summary>
		VIF_CANNOTLOADCABINET = 0x00100000,

		/// <summary>The function cannot load the compressed file.</summary>
		VIF_CANNOTLOADLZ32 = 0x00080000,

		/// <summary>
		/// The function cannot read the destination (existing) files. This prevents the function from examining the file's attributes.
		/// </summary>
		VIF_CANNOTREADDST = 0x00020000,

		/// <summary>The function cannot read the source file. This could mean that the path was not specified properly.</summary>
		VIF_CANNOTREADSRC = 0x00010000,

		/// <summary>The function cannot rename the temporary file, but already deleted the destination file.</summary>
		VIF_CANNOTRENAME = 0x00002000,

		/// <summary>
		/// The new file requires a code page that cannot be displayed by the version of the system currently running. This error can be
		/// overridden by calling VerInstallFile with the VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_DIFFCODEPG = 0x00000010,

		/// <summary>
		/// The new and preexisting files have different language or code-page values. This error can be overridden by calling
		/// VerInstallFile again with the VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_DIFFLANG = 0x00000008,

		/// <summary>
		/// The new file has a different type, subtype, or operating system from the preexisting file. This error can be overridden by
		/// calling VerInstallFile again with the VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_DIFFTYPE = 0x00000020,

		/// <summary>The preexisting file is in use by the system and cannot be deleted.</summary>
		VIF_FILEINUSE = 0x00000080,

		/// <summary>
		/// The new and preexisting files differ in one or more attributes. This error can be overridden by calling VerInstallFile again
		/// with the VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_MISMATCH = 0x00000002,

		/// <summary>
		/// The function cannot complete the requested operation due to insufficient memory. Generally, this means the application ran
		/// out of memory attempting to expand a compressed file.
		/// </summary>
		VIF_OUTOFMEMORY = 0x00008000,

		/// <summary>The function cannot create the temporary file due to insufficient disk space on the destination drive.</summary>
		VIF_OUTOFSPACE = 0x00000100,

		/// <summary>A read, create, delete, or rename operation failed due to a sharing violation.</summary>
		VIF_SHARINGVIOLATION = 0x00000400,

		/// <summary>
		/// The file to install is older than the preexisting file. This error can be overridden by calling VerInstallFile again with
		/// the VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_SRCOLD = 0x00000004,

		/// <summary>
		/// The temporary copy of the new file is in the destination directory. The cause of failure is reflected in other flags.
		/// </summary>
		VIF_TEMPFILE = 0x00000001,

		/// <summary>
		/// The preexisting file is write-protected. This error can be overridden by calling VerInstallFile again with the
		/// VIFF_FORCEINSTALL flag set.
		/// </summary>
		VIF_WRITEPROT = 0x00000040,
	}

	/// <summary>The flags for <see cref="VerInstallFile"/>.</summary>
	[PInvokeData("verrsrc.h")]
	[Flags]
	public enum VIFF : uint
	{
		/// <summary>
		/// Installs the file regardless of mismatched version numbers. The function checks only for physical errors during installation.
		/// </summary>
		VIFF_FORCEINSTALL = 0x0001,

		/// <summary>
		/// Installs the file without deleting the previously installed file, if the previously installed file is not in the destination directory.
		/// </summary>
		VIFF_DONTDELETEOLD = 0x0002,

		/// <summary>A read, create, delete, or rename operation failed due to an access violation.</summary>
		VIF_ACCESSVIOLATION = 0x00000200,
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