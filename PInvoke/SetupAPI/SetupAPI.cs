using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Items from the SetupAPI.dll</summary>
	public static partial class SetupAPI
	{
		/// <summary>Suite mask used by <see cref="SP_ALTPLATFORM_INFO_V3.SuiteMask"/>.</summary>
		public const ushort SP_ALTPLATFORM_FLAGS_SUITE_MASK = 0x0002;

		/// <summary>Flag value for <see cref="SP_ALTPLATFORM_INFO_V2.Flags"/> indicating post-XP use.</summary>
		public const ushort SP_ALTPLATFORM_FLAGS_VERSION_RANGE = 0x0001;

		private const int LINE_LEN = 256;
		private const int MAX_INF_SECTION_NAME_LENGTH = 255; // For Windows 9x compatibility, INF section names should be constrained to 32 characters.
		private const int MAX_INF_STRING_LENGTH = 4096; // Actual maximum size of an INF string (including string substitutions).
		private const int MAX_INSTALLWIZARD_DYNAPAGES = 20;
		private const int MAX_INSTRUCTION_LEN = 256;
		private const int MAX_LABEL_LEN = 30;
		private const int MAX_PATH = 260; // Redefined here to avoid linking Kernel32
		private const int MAX_SERVICE_NAME_LEN = 256;
		private const int MAX_SUBTITLE_LEN = 256;
		private const int MAX_TITLE_LEN = 60;

		/// <summary>Define maximum length of a machine name in the format expected by ConfigMgr32 CM_Connect_Machine (i.e., "\\\\MachineName\0").</summary>
		private const int SP_MAX_MACHINENAME_LENGTH = MAX_PATH + 3;

		/// <summary>
		/// A callback routine that displays a progress bar for the device detection operation. The callback routine is supplied by the
		/// device installation component that sends the DIF_DETECT request. The callback has the following prototype:
		/// </summary>
		/// <param name="ProgressNotifyParam">
		/// An opaque "handle" that identifies the detection operation. This value is supplied by the device installation component that
		/// sent the DIF_DETECT request.
		/// </param>
		/// <param name="DetectComplete">
		/// A value between 0 and 100 that indicates the percent completion. The class installer increments this value at various stages of
		/// its detection activities, to notify the user of its progress.
		/// </param>
		/// <returns></returns>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DETECTDEVICE_PARAMS")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate BOOL PDETECT_PROGRESS_NOTIFY([In] IntPtr ProgressNotifyParam, uint DetectComplete);

		/// <summary>Values for copy and queue-related APIs.</summary>
		[PInvokeData("setupapi.h")]
		[Flags]
		public enum CopyStyle : uint
		{
			/// <summary>Delete the source file upon successful copy. The caller is not notified if the deletion fails.</summary>
			SP_COPY_DELETESOURCE = 0x0000001,

			/// <summary>Copy the file only if doing so would overwrite a file at the destination path. The caller is not notified.</summary>
			SP_COPY_REPLACEONLY = 0x0000002,

			/// <summary>
			/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than
			/// an existing copy on the target.
			/// <para>
			/// The file version information used during version checks is that specified in the dwFileVersionMS and dwFileVersionLS members
			/// of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does not have version resources,
			/// or if they have identical version information, the source file is considered newer.
			/// </para>
			/// <para>
			/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel
			/// the copy. If CopyMsgHandler is not specified, the file is not copied.
			/// </para>
			/// </summary>
			SP_COPY_NEWER_OR_SAME = 0x0000004,

			/// <summary>
			/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
			/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
			/// </summary>
			SP_COPY_NEWER_ONLY = 0x0010000,

			/// <summary>
			/// Check whether the target file exists, and if so, notify the caller who may veto the copy. If CopyMsgHandler is not
			/// specified, the file is not overwritten.
			/// </summary>
			SP_COPY_NOOVERWRITE = 0x0000008,

			/// <summary>
			/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
			/// appropriate). For example, copying f:\x86\cmd.ex_ to \\install\temp results in a target file of \\install\temp\cmd.ex_. If
			/// the SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called
			/// \\install\temp\cmd.exe. The file name part of DestinationName, if specified, is stripped and replaced with the file name of
			/// the source file. When SP_COPY_NODECOMP is specified, no language or version information can be checked.
			/// </summary>
			SP_COPY_NODECOMP = 0x0000010,

			/// <summary>
			/// Examine each file being copied to see if its language differs from the language of any existing file already on the target.
			/// If so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified,
			/// the file is not copied.
			/// </summary>
			SP_COPY_LANGUAGEAWARE = 0x0000020,

			/// <summary>SourceFile is a full source path. Do not look it up in the SourceDisksNames section of the INF file.</summary>
			SP_COPY_SOURCE_ABSOLUTE = 0x0000040,

			/// <summary>
			/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the SourceDisksNames
			/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
			/// </summary>
			SP_COPY_SOURCEPATH_ABSOLUTE = 0x0000080,

			/// <summary>If the target exists, behave as if it is in-use and queue the file for copying on the next system reboot.</summary>
			SP_COPY_FORCE_IN_USE = 0x0000200,

			/// <summary>If the file was in-use during the copy operation, alert the user that the system needs to be rebooted.</summary>
			SP_COPY_IN_USE_NEEDS_REBOOT = 0x0000100,

			/// <summary>Do not give the user the option to skip a file.</summary>
			SP_COPY_NOSKIP = 0x0000400,

			/// <summary>Check whether the target file exists, and if so, the file is not overwritten. The caller is not notified.</summary>
			SP_COPY_FORCE_NOOVERWRITE = 0x0001000,

			/// <summary>
			/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
			/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
			/// </summary>
			SP_COPY_FORCE_NEWER = 0x0002000,

			/// <summary>
			/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
			/// </summary>
			SP_COPY_WARNIFSKIP = 0x0004000,

			/// <summary>The current source file is continued in another cabinet file.</summary>
			SP_FLAG_CABINETCONTINUATION = 0x0000800,

			/// <summary>Do not offer the user the option to browse.</summary>
			SP_COPY_NOBROWSE = 0x0008000,

			/// <summary>was: SP_COPY_SOURCE_SIS_MASTER (deprecated)</summary>
			SP_COPY_RESERVED = 0x0020000,

			/// <summary>
			/// The specified .inf file's corresponding catalog files is copied to %windir%\Inf. If this flag is specified, the destination
			/// filename information is entered upon successful return if the specified .inf file already exists in the Inf directory.
			/// </summary>
			SP_COPY_OEMINF_CATALOG_ONLY = 0x0040000,

			/// <summary>File must be present upon reboot (i.e., it's needed by the loader); this flag implies a reboot.</summary>
			SP_COPY_REPLACE_BOOT_FILE = 0x0080000,

			/// <summary>never prune this file</summary>
			SP_COPY_NOPRUNE = 0x0100000,

			/// <summary>Used when calling SetupCopyOemInf</summary>
			SP_COPY_OEM_F6_INF = 0x0200000,

			/// <summary>similar to SP_COPY_NODECOMP</summary>
			SP_COPY_ALREADYDECOMP = 0x0400000,

			/// <summary>BuildLab or WinSE signed</summary>
			SP_COPY_WINDOWS_SIGNED = 0x1000000,

			/// <summary>Used with the signature flag</summary>
			SP_COPY_PNPLOCKED = 0x2000000,

			/// <summary>If file in use, try to rename the target first</summary>
			SP_COPY_IN_USE_TRY_RENAME = 0x4000000,

			/// <summary>Referred by CopyFiles of inbox inf</summary>
			SP_COPY_INBOX_INF = 0x8000000,

			/// <summary>Copy using hardlink, if possible</summary>
			SP_COPY_HARDLINK = 0x10000000,
		}

		/// <summary>
		/// <para>
		/// In Windows Vista and later versions of Windows, the DEVPROPTYPE data type represents the property-data-type identifier that
		/// specifies the data type of a device property value in the unified device property model.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A property-data-type identifier represents a combination of a <c>base data type</c> and a <c>property-data-type modifier</c>. A
		/// property-data-type identifier is property-specific, and generally can represent a single fixed-length base-data-type value, a
		/// single variable-length base-data-type value, an array of fixed-length base-data-type values, or a list of variable-length
		/// base-data-type values.
		/// </para>
		/// <para>
		/// The device property functions that retrieve or set a device property take a PropertyType parameter that retrieves or supplies
		/// the property-data-type identifier for a device property. For example, <c>SetupDiGetDeviceProperty</c> and
		/// <c>SetupDiSetDeviceProperty</c> retrieve and set a device property for a device instance.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/ff543546(v=vs.85)
		[PInvokeData("Devpropdef.h")]
		[Flags]
		public enum DEVPROPTYPE : uint
		{
			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPEMOD_ARRAY identifier represents a property-data-type
			/// modifier that can be combined with the <c>base-data-type identifiers</c> to create a property-data-type identifier that
			/// represents an array of base-data-type values.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPEMOD_ARRAY identifier can be combined only with the fixed-length base-data-type identifiers (
			/// <c>DEVPROPTYPE</c> values) that are associated with data. The DEVPROP_TYPEMOD_ARRAY identifier cannot be combined with
			/// <c>DEVPROP_TYPE_EMPTY</c>, <c>DEVPROP_TYPE_NULL</c>, or any of the variable-length base-data-type identifiers.
			/// </para>
			/// <para>
			/// To create a property-data-type identifier that represents an array of base-data-type values, perform a bitwise OR between
			/// DEVPROP_TYPEMOD_ARRAY and the corresponding DEVPROP_TYPE_Xxx identifier. For example, to specify an array of unsigned bytes,
			/// perform the following bitwise OR: (DEVPROP_TYPEMOD_ARRAY | <c>DEVPROP_TYPE_BYTE</c>).
			/// </para>
			/// <para>The size, in bytes, of an array of base-data-type values is the size, in bytes, of the array.</para>
			/// <para>
			/// For information about how to create a property-data-type identifier that represents a REG_MULTI_SZ list of NULL-terminated
			/// Unicode strings, see <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// </remarks>
			DEVPROP_TYPEMOD_ARRAY = 0x00001000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPEMOD_LIST identifier represents a property-data-type modifier
			/// that can be combined only with the <c>base-data-type identifiers</c><c>DEVPROP_TYPE_STRING</c> and
			/// <c>DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING</c> to create a property-data-type identifier that represents a REG_MULTI_SZ list
			/// of NULL-terminated Unicode strings.
			/// </summary>
			/// <remarks>
			/// <para>
			/// DEVPROP_TYPEMOD_LIST cannot be combined with <c>DEVPROP_TYPE_EMPTY</c>, <c>DEVPROP_TYPE_NULL</c>,
			/// <c>DEVPROP_TYPE_SECURITY_DESCRIPTOR</c>, or any of the fixed length base-data-type identifiers.
			/// </para>
			/// <para>
			/// To create a property-data-type identifier that represents a string list, perform a bitwise OR between the
			/// DEVPROP_TYPEMOD_LIST property-data-type modifier and the corresponding DEVPROP_TYPE_Xxx identifier. For example, to specify
			/// a REG_MULTI_SZ list of Unicode strings, perform the following bitwise OR: (DEVPROP_TYPEMOD_LIST | DEVPROP_TYPE_STRING).
			/// </para>
			/// <para>
			/// The size of a REG_MULTI_SZ list of NULL-terminated Unicode strings is size of the list including the final <c>NULL</c> that
			/// terminated the list.
			/// </para>
			/// <para>
			/// For information about how to create a property-data-type identifier that represents an array of fixed length data values,
			/// see <c>DEVPROP_TYPEMOD_ARRAY</c>.
			/// </para>
			/// </remarks>
			DEVPROP_TYPEMOD_LIST = 0x00002000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_EMPTY identifier represents a special base-data-type
			/// identifier that indicates that a property does not exist.
			/// </summary>
			/// <remarks>
			/// <para>Use this base-data-type identifier with the device property functions to delete a property.</para>
			/// <para>If a device property function returns this base-data-type identifier, the property does not exist.</para>
			/// <para>
			/// <c>DEVPROP_TYPE_EMPTY</c> cannot be combined with the property-data-type modifiers <c>DEVPROP_TYPEMOD_ARRAY</c> or <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// <para>Deleting a Property</para>
			/// <para>To delete a property, call the corresponding SetupDiSetXxx property function and set the function parameters as follows:</para>
			/// <para>
			/// If DEVPROP_TYPE_EMPTY is used in an attempt to delete a property that does not exist, the delete operation will fail, and a
			/// call to GetLastError will return ERROR_NOT_FOUND.
			/// </para>
			/// <para>Retrieving a Property that Does Not Exist</para>
			/// <para>
			/// A call to a SetupDiGetXxx property function that attempts to retrieve a device property that does not exist will fail, and a
			/// subsequent call to GetLastError will return ERROR_NOT_FOUND. The called SetupAPI property function will set the
			/// *PropertyType parameter to DEVPROP_TYPE_EMPTY.
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_EMPTY = 0x00000000,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_NULL identifier represents a special base-data-type
			/// identifier that indicates that a device property exists. However, that the property has no value that is associated with the property.
			/// </summary>
			/// <remarks>
			/// <para>
			/// Use this base-property-type identifier with the device property functions to delete the value that is associated with a
			/// device property.
			/// </para>
			/// <para>
			/// If a device property function returns this base data type, the property exists, but the property has no value that is
			/// associated with it.
			/// </para>
			/// <para>
			/// The DEVPROP_TYPE_NULL identifier cannot be combined with the property-data-type modifiers <c>DEVPROP_TYPEMOD_ARRAY</c> or <c>DEVPROP_TYPEMOD_LIST</c>.
			/// </para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_NULL, call the corresponding <c>SetupDiSetXxx</c> property function and
			/// set the function parameters as follows:
			/// </para>
			/// <para><c>Retrieving a Property of this Type</c></para>
			/// <para>
			/// A call to a <c>SetupDiGetXxx</c> property function that attempts to retrieve a device property that has no value will
			/// succeed and set the *PropertyType parameter to DEVPROP_TYPE_NULL.
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_NULL = 0x00000001,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BYTE identifier represents the base-data-type identifier
			/// that indicates the data type is a SBYTE-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SBYTE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_BYTE, call the corresponding <c>SetupDiSetXxx</c> property function, and
			/// set the function parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(sbyte))]
			DEVPROP_TYPE_SBYTE = 0x00000002,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BYTE identifier represents the base-data-type identifier
			/// that indicates the data type is a BYTE-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_BYTE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_BYTE, call the corresponding SetupDiSetXxx property function, setting the
			/// function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(byte))]
			DEVPROP_TYPE_BYTE = 0x00000003,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT16 identifier represents the base-data-type identifier
			/// that indicates the data type is a SHORT-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SHORT can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT16, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(short))]
			DEVPROP_TYPE_INT16 = 0x00000004,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_UINT16 identifier represents the base-data-type identifier
			/// that indicates that the data type is a USHORT-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT16 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT16, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(ushort))]
			DEVPROP_TYPE_UINT16 = 0x00000005,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT32 identifier represents the base-data-type identifier
			/// that indicates that the data type is a LONG-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_INT32 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT32, call the corresponding <c>SetupDiSetXxx</c> property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(int))]
			DEVPROP_TYPE_INT32 = 0x00000006,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_UINT32 identifier represents the base-data-type identifier
			/// that indicates that the data type is a ULONG-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT32 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT32, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(uint))]
			DEVPROP_TYPE_UINT32 = 0x00000007,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a LONG64-typed signed integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_INT64 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_INT64, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(long))]
			DEVPROP_TYPE_INT64 = 0x00000008,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a ULONG64-typed unsigned integer.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_UINT64 can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_UINT64, call the corresponding <c>SetupDiSetXxx</c> property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(ulong))]
			DEVPROP_TYPE_UINT64 = 0x00000009,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a FLOAT-typed IEEE floating-point number.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_FLOAT can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para><c>Setting a Property of this Type</c></para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_FLOAT, call the corresponding SetupDiSetXxx property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(float))]
			DEVPROP_TYPE_FLOAT = 0x0000000A,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DOUBLE identifier represents the base-data-type identifier
			/// that indicates that the data type is a DOUBLE-typed IEEE floating-point number.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DOUBLE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DOUBLE, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(double))]
			DEVPROP_TYPE_DOUBLE = 0x0000000B,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_INT64 identifier represents the base-data-type identifier
			/// that indicates that the data type is a DECIMAL-typed value.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DECIMAL can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose data type is DEVPROP_TYPE_DECIMAL, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DECIMAL))]
			DEVPROP_TYPE_DECIMAL = 0x0000000C,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_GUID identifier represents the base-data-type identifier
			/// that indicates that the data type is a GUID-typed globally unique identifier (GUID).
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_GUID can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_GUID, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(Guid))]
			DEVPROP_TYPE_GUID = 0x0000000D,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_CURRENCY identifier represents the base-data-type
			/// identifier that indicates that the data type is a CURRENCY-typed value.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_CURRENCY can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_CURRENCY, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(CY))]
			DEVPROP_TYPE_CURRENCY = 0x0000000E,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DATE property type represents the base-data-type identifier
			/// that indicates that the data type is a DOUBLE-typed value that specifies the number of days since December 31, 1899. For
			/// example, January 1, 1900, is 1.0; January 2, 1900, is 2.0; and so on.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_DATE can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DATE, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DATE))]
			DEVPROP_TYPE_DATE = 0x0000000F,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_FILETIME property type represents the base-data-type
			/// identifier that indicates that the data type is a FILETIME-typed value.
			/// </summary>
			/// <remarks>
			/// <para>We recommend that all time values be represented in Coordinated Universal Time (UTC) units.</para>
			/// <para>DEVPROP_TYPE_FILETIME can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_FILETIME, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(FILETIME))]
			DEVPROP_TYPE_FILETIME = 0x00000010,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BOOLEAN property type represents the base-data-type
			/// identifier that indicates that the data type is a DEVPROP_BOOLEAN-typed Boolean value.
			/// </summary>
			/// <remarks>
			/// <para>The DEVPROP_BOOLEAN data type and valid Boolean values are defined as follows:</para>
			/// <para>
			/// <code>typedef CHAR DEVPROP_BOOLEAN, *PDEVPROP_BOOLEAN; #define DEVPROP_TRUE ((DEVPROP_BOOLEAN)-1) #define DEVPROP_FALSE ((DEVPROP_BOOLEAN) 0)</code>
			/// </para>
			/// <para>DEVPROP_TYPE_BOOLEAN can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_BOOLEAN, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(BOOLEAN))]
			DEVPROP_TYPE_BOOLEAN = 0x00000011,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_STRING property type represents the base-data-type
			/// identifier that indicates that the data type is a NULL-terminated Unicode string.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_STRING can be combined only with the <c>DEVPROP_TYPEMOD_LIST</c> property-data-type modifier.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING, call the corresponding <c>SetupDiSetXxx</c> property
			/// function, setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_STRING = 0x00000012,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_STRING_LIST property type represents the base-data-type
			/// identifier that indicates that the data type is a REG_MULTI_SZ-typed list of Unicode strings.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_STRING_LIST cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING_LIST, call the corresponding <c>SetupDiSetXxx</c> property
			/// function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			DEVPROP_TYPE_STRING_LIST = DEVPROP_TYPE_STRING | DEVPROP_TYPEMOD_LIST,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_SECURITY_DESCRIPTOR identifier represents the
			/// base-data-type identifier that indicates the data type is a variable-length, self-relative, SECURITY_DESCRIPTOR-typed,
			/// security descriptor.
			/// </summary>
			/// <remarks>
			/// <para>DEVPROP_TYPE_SECURITY_DESCRIPTOR cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_SECURITY_DESCRIPTOR, call the corresponding <c>SetupDiSetXxx</c>
			/// property function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			DEVPROP_TYPE_SECURITY_DESCRIPTOR = 0x00000013,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING identifier represents the
			/// base-data-type identifier that indicates the data type is a NULL-terminated Unicode string that contains a security
			/// descriptor in the Security Descriptor Definition Language (SDDL) format.
			/// </summary>
			/// <remarks>
			/// <para>
			/// DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING can be combined only with the <c>DEVPROP_TYPEMOD_LIST</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING, call the corresponding
			/// <c>SetupDiSetXxx</c> property function and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING = 0x00000014,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DEVPROPKEY identifier represents the base-data-type
			/// identifier that indicates the data type is a DEVPROPKEY-typed device property key.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPE_DEVPROPKEY property type can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DEVPROPKEY, call the corresponding SetupDiSetXxx property function
			/// and set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DEVPROPKEY))]
			DEVPROP_TYPE_DEVPROPKEY = 0x00000015,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_DEVPROPTYPE identifier represents the base-data-type
			/// identifier that indicates the data type is a DEVPROPTYPE-typed value.
			/// </summary>
			/// <remarks>
			/// <para>
			/// The DEVPROP_TYPE_DEVPROPTYPE property type can be combined only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.
			/// </para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_DEVPROPTYPE, call the corresponding SetupDiSetXxx property function,
			/// setting the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(DEVPROPTYPE))]
			DEVPROP_TYPE_DEVPROPTYPE = 0x00000016,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_TYPE_BINARY identifier represents the base-data-type identifier
			/// that indicates that the data type is an array of BYTE-typed unsigned values.
			/// </summary>
			/// <remarks>
			/// <para>The DEVPROP_TYPE_BINARY property type cannot be combined with the property-data-type modifiers.</para>
			/// <para>Setting a Property of this Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_BINARY, call the corresponding SetupDiSetXxx property function and
			/// set the function input parameters as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(byte[]))]
			DEVPROP_TYPE_BINARY = DEVPROP_TYPE_BYTE | DEVPROP_TYPEMOD_ARRAY,

			/// <summary>
			/// The DEVPROP_TYPE_ERROR identifier represents the base-data-type identifier for the Microsoft Win32 error code values that
			/// are defined in WINERROR.H.
			/// </summary>
			/// <remarks>
			/// <para>
			/// In Windows Vista and later versions of Windows, the unified device property model also defines a
			/// <c>DEVPROP_TYPE_NTSTATUS</c> base-data-type identifier for NTSTATUS error code values.
			/// </para>
			/// <para>You can combine DEVPROP_TYPE_ERROR only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_ERROR, call the corresponding SetupDiSetXxx property function and set
			/// the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Descriptive Text for a Win32 Error Code Value</para>
			/// <para>
			/// To retrieve the descriptive text that is associated with a Win32 error code, call the <c>FormatMessage</c> function
			/// (documented in the Windows SDK) as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(Win32Error))]
			DEVPROP_TYPE_ERROR = 0x00000017,

			/// <summary>
			/// The DEVPROP_TYPE_NTSTATUS identifier represents the base-data-type identifier for the NTSTATUS status code values that are
			/// defined in Ntstatus.h.
			/// </summary>
			/// <remarks>
			/// <para>
			/// In Windows Vista and later versions of Windows, the unified device property model also defines a <c>DEVPROP_TYPE_ERROR</c>
			/// base-data-type identifier for Microsoft Win32 error code values.
			/// </para>
			/// <para>You can combine DEVPROP_TYPE_NTSTATUS only with the <c>DEVPROP_TYPEMOD_ARRAY</c> property-data-type modifier.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_NTSTATUS, call the corresponding <c>SetupDiSet</c> Xxx property
			/// function and set the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Descriptive Text for a NTSTATUS Error Code Value</para>
			/// <para>
			/// To retrieve the descriptive text that is associated with an NTSTATUS error code value, call the <c>FormatMessage</c>
			/// function (documented in the Windows SDK) as follows:
			/// </para>
			/// </remarks>
			[CorrespondingType(typeof(NTStatus))]
			DEVPROP_TYPE_NTSTATUS = 0x00000018,

			/// <summary>
			/// The DEVPROP_TYPE_STRING_INDIRECT identifier represents the base-data-type identifier for a NULL-terminated Unicode string
			/// that contains an indirect string reference.
			/// </summary>
			/// <remarks>
			/// <para>
			/// An indirect string reference describes a string resource that contains the actual string. The indirect string reference can
			/// appear in one of the following formats:
			/// </para>
			/// <para>
			/// <c>@</c>[path <c>\</c>]FileName <c>,-</c> ResourceID Windows extracts the string from the module that is specified by the
			/// path and FileName entries, and the resource identifier of the string is supplied by the ResourceID entry (excluding the
			/// required minus sign). The string resource is loaded from the module resource section that best matches one of the caller's
			/// preferred UI languages. The path entry is optional. If you specify the path entry, the module must be located in a directory
			/// that is in the system-defined search path.
			/// </para>
			/// <para>
			/// <c>@</c> InfName <c>,%</c> strkey <c>%</c> Windows extracts the string from the INF <c>Strings</c> section of the INF file
			/// in the %SystemRoot%\inf directory whose name is supplied by the InfName entry. The strkey token identifier should match the
			/// key of a line in the <c>Strings</c> section that best matches one of the caller's preferred UI languages. If no
			/// language-specific <c>Strings</c> sections exist, Windows uses the default <c>Strings</c> section.
			/// </para>
			/// <para>You cannot combine DEVPROP_TYPE_STRING_INDIRECT with any of the property-data-type modifiers.</para>
			/// <para>Setting a Property of This Type</para>
			/// <para>
			/// To set a property whose base data type is DEVPROP_TYPE_STRING_INDIRECT, call the corresponding <c>SetupDiSet</c> Xxx
			/// property function and set the function input parameters as follows:
			/// </para>
			/// <para>Retrieving the Value of This Property Type</para>
			/// <para>
			/// When an application calls a <c>SetupDiGet</c> Xxx property function to retrieve the value of a property of this base data
			/// type, Windows tries to locate the actual string that the property references. If Windows can retrieve the actual string, it
			/// returns the actual string to the caller and identifies the base data type of the retrieved property as
			/// <c>DEVPROP_TYPE_STRING</c>. Otherwise, Windows returns the indirect string reference and identifies the base data type of
			/// the retrieved property as DEVPROP_TYPE_STRING_INDIRECT.
			/// </para>
			/// <para>Localizing Static Text</para>
			/// <para>
			/// Starting with Windows Vista you can localize custom and standard string-type PnP static-text properties using resources from
			/// a PE image's string or resource tables by setting static-text property types to DEVPROP_TYPE_STRING_INDIRECT. You can also
			/// add non-localized replacement-string data that can be formatted into the static text.
			/// </para>
			/// <para>
			/// Strings located in a PE image's STRINGTABLE resource (as typically performed by LoadString) should use the following format:
			/// </para>
			/// <para>"@"System32\mydll.dll,-21[;Fallback" String]"</para>
			/// <para>"@System32\mydll.dll,-21[;Fallback String with %1, %2, … to %n[;(Arg1,Arg2,…,ArgN)]]"</para>
			/// <para>
			/// Strings located in a PE images's message-table resource (as typically performed by RtlFindMessage, more commonly used in
			/// drivers) should use the following format:
			/// </para>
			/// <para>"@System32\drivers\mydriver.sys,#21[;Fallback String]"</para>
			/// <para>"@System32\drivers\mydriver.sys,#21[;Fallback String with %1, %2, … to %n[;(Arg1,Arg2,…,ArgN)]]"</para>
			/// <para>
			/// A "Fallback String" is optional but useful because it can be returned if the resource can’t be found or loaded. The fallback
			/// string is also returned to non-interactive system processes that are not impersonating a user, and as such cannot show
			/// localized text to users anyways.
			/// </para>
			/// <para>
			/// This technique enables you to localize static-text pulled from the string or message table resource that best matches the
			/// caller’s locale.
			/// </para>
			/// <para>
			/// Windows will format the trailing arguments into the string (or the fallback string) when they are retrieved from the
			/// respective resource table, much as in the same manner as RtlFormatMessage does.
			/// </para>
			/// <para>
			/// Custom and standard string-type PnP static-text is localized when you set the property by loading the resource from the
			/// component performing the set operation, which typically happens under the system default locale for system-level components.
			/// </para>
			/// <para>Note: PE images can use either resource table type (STRINGTABLE resources, or message-table resources).</para>
			/// </remarks>
			[CorrespondingType(typeof(string))]
			DEVPROP_TYPE_STRING_INDIRECT = 0x00000019,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_MASK_TYPE mask can be combined in a bitwise AND with a
			/// property-data-type identifier to extract the <c>base-data-type identifier</c> from a property-data-type identifier.
			/// </summary>
			/// <remarks>
			/// <para>This mask cannot be used as a base-data-type identifier, a property-data-type modifier, or a property-data-type identifier.</para>
			/// <para>
			/// For information about how to extract the DEVPROP_TYPEMOD_Xxx <c>property-data-type modifier</c> from a property-data-type
			/// identifier, see <c>DEVPROP_MASK_TYPEMOD</c>.
			/// </para>
			/// </remarks>
			DEVPROP_MASK_TYPE = 0x00000FFF,

			/// <summary>
			/// In Windows Vista and later versions of Windows, the DEVPROP_MASK_TYPEMOD mask can be combined in a bitwise AND with a
			/// property-data-type identifier to extract the DEVPROP_TYPEMOD_Xxx <c>property-data-type modifier</c> from a
			/// property-data-type identifier.
			/// </summary>
			/// <remarks>
			/// <para>This mask cannot be used as a base-data-type identifier, a property-data-type modifier, or property-data-type identifier.</para>
			/// <para>
			/// For information about how to extract the <c>base-data-type identifier</c> from a property-data-type identifier, see <c>DEVPROP_MASK_TYPE</c>.
			/// </para>
			/// </remarks>
			DEVPROP_MASK_TYPEMOD = 0x0000F000,
		}

		/// <summary>
		/// Flags that control installation and user interface operations. Some flags can be set before sending the device installation
		/// request while other flags are set automatically during the processing of some requests.
		/// </summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVINSTALL_PARAMS_A")]
		[Flags]
		public enum DI_FLAGS : uint
		{
			/// <summary>
			/// Set to allow support for OEM disks. If this flag is set, the operating system presents a "Have Disk" button on the Select
			/// Device page. This flag is set, by default, in system-supplied wizards.
			/// </summary>
			DI_SHOWOEM = 0x00000001,

			/// <summary>show compatibility list</summary>
			DI_SHOWCOMPAT = 0x00000002,

			/// <summary>show class list</summary>
			DI_SHOWCLASS = 0x00000004,

			/// <summary>both class and compat list shown</summary>
			DI_SHOWALL = 0x00000007,

			/// <summary>Set to disable creation of a new copy queue. Use the caller-supplied copy queue in SP_DEVINSTALL_PARAMS. <c>FileQueue</c>.</summary>
			DI_NOVCP = 0x00000008,

			/// <summary>
			/// Set if SetupDiBuildDriverInfoList has already built a list of compatible drivers for this device. If this list has already
			/// been built, it contains all the driver information and this flag is always set. SetupDiDestroyDriverInfoList clears this
			/// flag when it deletes a compatible driver list.
			/// <para>
			/// This flag is only set in device installation parameters that are associated with a particular device information element,
			/// not in parameters for a device information set as a whole.
			/// </para>
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// </summary>
			DI_DIDCOMPAT = 0x00000010,

			/// <summary>
			/// Set if SetupDiBuildDriverInfoList has already built a list of the drivers for this class of device. If this list has already
			/// been built, it contains all the driver information and this flag is always set. SetupDiDestroyDriverInfoList clears this
			/// flag when it deletes a list of drivers for a class.
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// </summary>
			DI_DIDCLASS = 0x00000020,

			/// <summary>No UI for resources if possible flags returned by DiInstallDevice to indicate need to reboot/restart</summary>
			DI_AUTOASSIGNRES = 0x00000040,

			/// <summary>The same as DI_NEEDREBOOT.</summary>
			DI_NEEDRESTART = 0x00000080,

			/// <summary>
			/// For NT-based operating systems, this flag is set if the device requires that the computer be restarted after device
			/// installation or a device state change. A class installer or co-installer can set this flag at any time during device
			/// installation, if the installer determines that a restart is necessary.
			/// </summary>
			DI_NEEDREBOOT = 0x00000100,

			/// <summary>
			/// Set to disable browsing when the user is selecting an OEM disk path. A device installation application sets this flag to
			/// constrain a user to only installing from the installation media location.
			/// </summary>
			DI_NOBROWSE = 0x00000200,

			/// <summary>
			/// Set by SetupDiBuildDriverInfoList if a list of drivers for a device setup class contains drivers that are provided by
			/// multiple manufacturers.
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// </summary>
			DI_MULTMFGS = 0x00000400,

			/// <summary>Set if device disabled Flags for Device/Class Properties</summary>
			DI_DISABLED = 0x00000800,

			/// <summary></summary>
			DI_GENERALPAGE_ADDED = 0x00001000,

			/// <summary>
			/// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied resource
			/// properties page. If this flag is set, the operating system does not display the system-supplied resource page.
			/// </summary>
			DI_RESOURCEPAGE_ADDED = 0x00002000,

			/// <summary>
			/// Set by Device Manager if a device's properties were changed, which requires an update of the installer's user interface.
			/// </summary>
			DI_PROPERTIES_CHANGE = 0x00004000,

			/// <summary>
			/// Set to indicate that the Select Device page should list drivers in the order in which they appear in the INF file, instead
			/// of sorting them alphabetically.
			/// </summary>
			DI_INF_IS_SORTED = 0x00008000,

			/// <summary>
			/// Set if installers and other device installation components should only search the INF file specified by
			/// SP_DEVINSTALL_PARAMS. <c>DriverPath</c>. If this flag is set, <c>DriverPath</c> contains the path of a single INF file
			/// instead of a path of a directory.
			/// </summary>
			DI_ENUMSINGLEINF = 0x00010000,

			/// <summary>
			/// Set if the configuration manager should not be called to remove or reenumerate devices during the execution of certain
			/// device installation functions (for example, SetupDiInstallDevice).
			/// <para>
			/// If this flag is set, device installation applications, class installers, and co-installers must not call the following functions:
			/// </para>
			/// <para>
			/// CM_Reenumerate_DevNode CM_Reenumerate_DevNode_Ex CM_Query_And_Remove_SubTree CM_Query_And_Remove_SubTree_Ex CM_Setup_DevNode
			/// CM_Setup_DevNode_Ex CM_Set_HW_Prof_Flags CM_Set_HW_Prof_Flags_Ex CM_Enable_DevNode CM_Enable_DevNode_Ex CM_Disable_DevNode CM_Disable_DevNode_Ex
			/// </para>
			/// </summary>
			DI_DONOTCALLCONFIGMG = 0x00020000,

			/// <summary>
			/// Set if the device should be installed in a disabled state by default. To be recognized, this flag must be set before Windows
			/// calls the default handler for the DIF_INSTALLDEVICE request.
			/// </summary>
			DI_INSTALLDISABLED = 0x00040000,

			/// <summary>
			/// Set to force SetupDiBuildDriverInfoList to build a device's list of compatible drivers from its class driver list instead of
			/// the INF file.
			/// </summary>
			DI_COMPAT_FROM_CLASS = 0x00080000,

			/// <summary>
			/// Set to use the Class Install parameters. SetupDiSetClassInstallParams sets this flag when the caller specifies parameters
			/// and clears the flag when the caller specifies a <c>NULL</c> parameters pointer.
			/// </summary>
			DI_CLASSINSTALLPARAMS = 0x00100000,

			/// <summary>
			/// Set if SetupDiCallClassInstaller should not perform any default action if the class installer returns ERR_DI_DO_DEFAULT or
			/// there is not a class installer.
			/// </summary>
			DI_NODI_DEFAULTACTION = 0x00200000,

			/// <summary>
			/// Set if the device installer functions must be silent and use default choices wherever possible. Class installers and
			/// co-installers must not display any UI if this flag is set.
			/// </summary>
			DI_QUIETINSTALL = 0x00800000,

			/// <summary>Set if device installation applications and components, such as SetupDiInstallDevice, should skip file copying.</summary>
			DI_NOFILECOPY = 0x01000000,

			/// <summary>Force files to be copied from install path</summary>
			DI_FORCECOPY = 0x02000000,

			/// <summary>
			/// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied driver
			/// properties page. If this flag is set, the operating system does not display the system-supplied driver page.
			/// </summary>
			DI_DRIVERPAGE_ADDED = 0x04000000,

			/// <summary>
			/// Set if a class installer or co-installer supplied strings that should be used during SetupDiSelectDevice.
			/// <para>The following flags are read-only (only set by the OS):</para>
			/// </summary>
			DI_USECI_SELECTSTRINGS = 0x08000000,

			/// <summary>Override INF flags</summary>
			DI_OVERRIDE_INFFLAGS = 0x10000000,

			/// <summary>No Enable/Disable in General Props</summary>
			[Obsolete]
			DI_PROPS_NOCHANGEUSAGE = 0x20000000,

			/// <summary>No small icons in select device dialogs</summary>
			[Obsolete]
			DI_NOSELECTICONS = 0x40000000,

			/// <summary>
			/// Set to prevent SetupDiInstallDevice from writing the INF-specified hardware IDs and compatible IDs to the device properties
			/// for the device node (devnode). This flag should only be set for root-enumerated devices.
			/// <para>This flag overrides the DI_FLAGSEX_ALWAYSWRITEIDS flag.</para>
			/// </summary>
			DI_NOWRITE_IDS = 0x80000000,
		}

		/// <summary>
		/// Additional flags that provide control over installation and user interface operations. Some flags can be set before calling the
		/// device installer functions while other flags are set automatically during the processing of some functions.
		/// </summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVINSTALL_PARAMS_A")]
		[Flags]
		public enum DI_FLAGSEX : uint
		{
			/// <summary>
			/// <para>If set, include drivers that were marked "Exclude From Select."</para>
			/// <para>
			/// For example, if this flag is set, SetupDiSelectDevice displays drivers that have the Exclude From Select state and
			/// SetupDiBuildDriverInfoList includes Exclude From Select drivers in the requested driver list.
			/// </para>
			/// <para>
			/// A driver is "Exclude From Select" if either it is marked <c>ExcludeFromSelect</c> in the INF file or it is a driver for a
			/// device whose whole setup class is marked <c>NoInstallClass</c> or <c>NoUseClass</c> in the class installer INF. Drivers for
			/// PnP devices are typically "Exclude From Select"; PnP devices should not be manually installed. To build a list of driver
			/// files for a PnP device a caller of <c>SetupDiBuildDriverInfoList</c> must set this flag.
			/// </para>
			/// </summary>
			DI_FLAGSEX_ALLOWEXCLUDEDDRVS = 0x00000800,

			/// <summary/>
			DI_FLAGSEX_ALTPLATFORM_DRVSEARCH = 0x10000000,

			/// <summary>
			/// <para>
			/// If set and the DI_NOWRITE_IDS flag is clear, always write hardware and compatible IDs to the device properties for the
			/// devnode. This flag should only be set for root-enumerated devices.
			/// </para>
			/// </summary>
			DI_FLAGSEX_ALWAYSWRITEIDS = 0x00000200,

			/// <summary>
			/// <para>
			/// If set, <c>SetupDiBuildDriverInfoList</c> appends a new driver list to an existing list. This flag is relevant when
			/// searching multiple locations.
			/// </para>
			/// </summary>
			DI_FLAGSEX_APPENDDRIVERLIST = 0x00040000,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_BACKUPONREPLACE = 0x00100000,

			/// <summary>
			/// <para>Set by the operating system if a class installer failed to load or start. This flag is read-only.</para>
			/// </summary>
			DI_FLAGSEX_CI_FAILED = 0x00000004,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_DEVICECHANGE = 0x00000100,

			/// <summary>
			/// <para>Windows has built a list of driver nodes that are compatible with the device. This flag is read-only.</para>
			/// </summary>
			DI_FLAGSEX_DIDCOMPATINFO = 0x00000020,

			/// <summary>
			/// <para>
			/// Windows has built a list of driver nodes that includes all the drivers that are listed in the INF files of the specified
			/// setup class. If the specified setup class is <c>NULL</c> because the HDEVINFO set or device has no associated class, the
			/// list includes all driver nodes from all available INF files. This flag is read-only.
			/// </para>
			/// </summary>
			DI_FLAGSEX_DIDINFOLIST = 0x00000010,

			/// <summary>
			/// <para>
			/// If set, build the driver list from INF(s) retrieved from the URL that is specified in SP_DEVINSTALL_PARAMS.
			/// <c>DriverPath</c>. If the <c>DriverPath</c> is an empty string, use the Windows Update website.
			/// </para>
			/// <para>
			/// Currently, the operating system does not support URLs. Use this flag to direct <c>SetupDiBuildDriverInfoList</c> to search
			/// the Windows Update website.
			/// </para>
			/// <para>Do not set this flag if DI_QUIETINSTALL is set.</para>
			/// </summary>
			DI_FLAGSEX_DRIVERLIST_FROM_URL = 0x00200000,

			/// <summary>
			/// <para>
			/// If set, do not include old Internet drivers when building a driver list. This flag should be set any time that you are
			/// building a list of potential drivers for a device. You can clear this flag if you are just getting a list of drivers
			/// currently installed for a device.
			/// </para>
			/// </summary>
			DI_FLAGSEX_EXCLUDE_OLD_INET_DRIVERS = 0x00800000,

			/// <summary>
			/// <para>
			/// If set, SetupDiBuildClassInfoList will check for class inclusion filters. This means that a device will not be included in
			/// the class list if its class is marked as NoInstallClass.
			/// </para>
			/// </summary>
			DI_FLAGSEX_FILTERCLASSES = 0x00000040,

			/// <summary>
			/// <para>
			/// (Windows XP and later.) If set, SetupDiBuildDriverInfoList includes "similar" drivers when building a class driver list. A
			/// "similar" driver is one for which one of the hardware IDs or compatible IDs in the INF file partially (or completely)
			/// matches one of the hardware IDs or compatible IDs of the hardware.
			/// </para>
			/// </summary>
			DI_FLAGSEX_FILTERSIMILARDRIVERS = 0x02000000,

			/// <summary>Class/co-installer wants to get a DIF_FINISH_INSTALL action in client context.</summary>
			DI_FLAGSEX_FINISHINSTALL_ACTION = 0x00000008,

			/// <summary>
			/// <para>If set, installation is occurring during initial system setup. This flag is read-only.</para>
			/// </summary>
			DI_FLAGSEX_IN_SYSTEM_SETUP = 0x00010000,

			/// <summary>
			/// <para>
			/// If set, the driver was obtained from the Internet. Windows will not use the device's INF to install future devices because
			/// Windows cannot guarantee that it can retrieve the driver files again from the Internet.
			/// </para>
			/// </summary>
			DI_FLAGSEX_INET_DRIVER = 0x00020000,

			/// <summary>
			/// <para>
			/// (Windows XP and later.) If set, SetupDiBuildDriverInfoList includes only the currently installed driver when creating a list
			/// of class drivers or device-compatible drivers.
			/// </para>
			/// </summary>
			DI_FLAGSEX_INSTALLEDDRIVER = 0x04000000,

			/// <summary>Don't remove identical driver nodes from the class list</summary>
			DI_FLAGSEX_NO_CLASSLIST_NODE_MERGE = 0x08000000,

			/// <summary>
			/// <para>
			/// Do not process the <c>AddReg</c> and <c>DelReg</c> entries for the device's hardware and software (driver) keys. That is,
			/// the <c>AddReg</c> and <c>DelReg</c> entries in the INF file DDInstall and DDInstall <c>.HW</c> sections.
			/// </para>
			/// </summary>
			DI_FLAGSEX_NO_DRVREG_MODIFY = 0x00008000,

			/// <summary>Obsolete.</summary>
			[Obsolete]
			DI_FLAGSEX_NOUIONQUERYREMOVE = 0x00001000,

			/// <summary>
			/// <para>
			/// If set, an installer added their own page for the power properties dialog. The operating system will not display the
			/// system-supplied power properties page. This flag is only relevant if the device supports power management.
			/// </para>
			/// </summary>
			DI_FLAGSEX_POWERPAGE_ADDED = 0x01000000,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_PREINSTALLBACKUP = 0x00080000,

			/// <summary>
			/// <para>
			/// If set, the user made changes to one or more device property sheets. The property-page provider typically sets this flag.
			/// </para>
			/// <para>
			/// When the user closes the device property sheet, Device Manager checks the DI_FLAGSEX_PROPCHANGE_PENDING flag. If it is set,
			/// Device Manager clears this flag, sets the DI_PROPERTIES_CHANGE flag, and sends a DIF_PROPERTYCHANGE request to the
			/// installers to notify them that something has changed.
			/// </para>
			/// </summary>
			DI_FLAGSEX_PROPCHANGE_PENDING = 0x00000400,

			/// <summary>Tell SetupDiBuildDriverInfoList to do a recursive search</summary>
			DI_FLAGSEX_RECURSIVESEARCH = 0x40000000,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_RESERVED1 = 0x00400000,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_RESERVED2 = 0x00000001,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_RESERVED3 = 0x00000002,

			/// <summary>Reserved.</summary>
			DI_FLAGSEX_RESERVED4 = 0x00004000,

			/// <summary>Only restart the device drivers are being installed on as opposed to restarting all devices using those drivers.</summary>
			DI_FLAGSEX_RESTART_DEVICE_ONLY = 0x20000000,

			/// <summary>Tell SetupDiBuildDriverInfoList to do a "published INF" search</summary>
			DI_FLAGSEX_SEARCH_PUBLISHED_INFS = 0x80000000,

			/// <summary>
			/// <para>
			/// Set if the installation failed. If this flag is set, the SetupDiInstallDevice function just sets the FAILEDINSTALL flag in
			/// the device's <c>ConfigFlags</c> registry value. If DI_FLAGSEX_SETFAILEDINSTALL is set, co-installers must return NO_ERROR in
			/// response to DIF_INSTALLDEVICE, while class installers must return NO_ERROR or ERROR_DI_DO_DEFAULT.
			/// </para>
			/// </summary>
			DI_FLAGSEX_SETFAILEDINSTALL = 0x00000080,

			/// <summary>
			/// <para>
			/// Filter INF files on the device's setup class when building a list of compatible drivers. If a device's setup class is known,
			/// setting this flag reduces the time that is required to build a list of compatible drivers when searching INF files that are
			/// not precompiled. This flag is ignored if DI_COMPAT_FROM_CLASS is set.
			/// </para>
			/// </summary>
			DI_FLAGSEX_USECLASSFORCOMPAT = 0x00002000,
		}

		/// <summary>
		/// <para>
		/// This section describes the device installation requests that device installation applications send to class installers and
		/// co-installers. Each request is represented by a device installation function (DIF) code The DIF code constants are defined in
		/// the Setupapi.h header file.
		/// </para>
		/// <para>
		/// Installers that handle these requests include class installers, class co-installers, and device co-installers. Some installers
		/// are provided by Microsoft and some are provided by OEMs and third-party vendors.
		/// </para>
		/// <para>
		/// Device installation applications send DIF codes to installers by calling <c>SetupDiCallClassInstaller</c>, which in turn calls
		/// the installer's entry point function. The DIF code is one of the parameters to the installer's entry point function; other
		/// parameters provide additional input. For more information about these parameters, see Handling DIF Codes.
		/// </para>
		/// <para>For information about how to write co-installers, see Writing a Co-installer.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/previous-versions/ff541307(v=vs.85)
		[PInvokeData("setupapi.h")]
		public enum DI_FUNCTION : uint
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			DIF_SELECTDEVICE = 0x00000001,
			DIF_INSTALLDEVICE = 0x00000002,
			DIF_ASSIGNRESOURCES = 0x00000003,
			DIF_PROPERTIES = 0x00000004,
			DIF_REMOVE = 0x00000005,
			DIF_FIRSTTIMESETUP = 0x00000006,
			DIF_FOUNDDEVICE = 0x00000007,
			DIF_SELECTCLASSDRIVERS = 0x00000008,
			DIF_VALIDATECLASSDRIVERS = 0x00000009,
			DIF_INSTALLCLASSDRIVERS = 0x0000000A,
			DIF_CALCDISKSPACE = 0x0000000B,
			DIF_DESTROYPRIVATEDATA = 0x0000000C,
			DIF_VALIDATEDRIVER = 0x0000000D,
			DIF_DETECT = 0x0000000F,
			DIF_INSTALLWIZARD = 0x00000010,
			DIF_DESTROYWIZARDDATA = 0x00000011,
			DIF_PROPERTYCHANGE = 0x00000012,
			DIF_ENABLECLASS = 0x00000013,
			DIF_DETECTVERIFY = 0x00000014,
			DIF_INSTALLDEVICEFILES = 0x00000015,
			DIF_UNREMOVE = 0x00000016,
			DIF_SELECTBESTCOMPATDRV = 0x00000017,
			DIF_ALLOW_INSTALL = 0x00000018,
			DIF_REGISTERDEVICE = 0x00000019,
			DIF_NEWDEVICEWIZARD_PRESELECT = 0x0000001A,
			DIF_NEWDEVICEWIZARD_SELECT = 0x0000001B,
			DIF_NEWDEVICEWIZARD_PREANALYZE = 0x0000001C,
			DIF_NEWDEVICEWIZARD_POSTANALYZE = 0x0000001D,
			DIF_NEWDEVICEWIZARD_FINISHINSTALL = 0x0000001E,
			DIF_UNUSED1 = 0x0000001F,
			DIF_INSTALLINTERFACES = 0x00000020,
			DIF_DETECTCANCEL = 0x00000021,
			DIF_REGISTER_COINSTALLERS = 0x00000022,
			DIF_ADDPROPERTYPAGE_ADVANCED = 0x00000023,
			DIF_ADDPROPERTYPAGE_BASIC = 0x00000024,
			DIF_RESERVED1 = 0x00000025,
			DIF_TROUBLESHOOTER = 0x00000026,
			DIF_POWERMESSAGEWAKE = 0x00000027,
			DIF_ADDREMOTEPROPERTYPAGE_ADVANCED = 0x00000028,
			DIF_UPDATEDRIVER_UI = 0x00000029,
			DIF_FINISHINSTALL_ACTION = 0x0000002A,
			DIF_RESERVED2 = 0x00000030,

			[Obsolete]
			DIF_MOVEDEVICE = 0x0000000E,

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>Flags that indicate the scope of the device removal.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_REMOVEDEVICE_PARAMS")]
		public enum DI_REMOVEDEVICE : uint
		{
			/// <summary>Make this change in all hardware profiles. Remove information about the device from the registry.</summary>
			DI_REMOVEDEVICE_GLOBAL = 0x00000001,

			/// <summary>
			/// Make this change to only the hardware profile specified by <c>HwProfile</c>. this flag only applies to root-enumerated
			/// devices. When Windows removes the device from the last hardware profile in which it was configured, Windows performs a
			/// global removal.
			/// </summary>
			DI_REMOVEDEVICE_CONFIGSPECIFIC = 0x00000002,
		}

		/// <summary>A flag that indicates the scope of the unremove operation.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_UNREMOVEDEVICE_PARAMS")]
		public enum DI_UNREMOVEDEVICE
		{
			/// <summary>A flag that indicates the scope of the unremove operation.</summary>
			DI_UNREMOVEDEVICE_CONFIGSPECIFIC = 0x00000002
		}

		/// <summary>
		/// Flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in the list.
		/// </summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiBuildClassInfoList")]
		[Flags]
		public enum DIBCI : uint
		{
			/// <summary>Exclude a class if it has the <c>NoInstallClass</c> value entry in its registry key.</summary>
			DIBCI_NOINSTALLCLASS = 0x00000001,

			/// <summary>Exclude a class if it has the <c>NoDisplayClass</c> value entry in its registry key.</summary>
			DIBCI_NODISPLAYCLASS = 0x00000002
		}

		/// <summary>A variable that controls how the device information element is created.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoA")]
		[Flags]
		public enum DICD : uint
		{
			/// <summary>
			/// If this flag is specified, DeviceName contains only a Root-enumerated device ID and the system uses that ID to generate a
			/// full device instance ID for the new device information element.
			/// </summary>
			DICD_GENERATE_ID = 0x00000001,

			/// <summary>
			/// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with
			/// the device information set. In addition, if there is a selected driver for the device information set, that same driver is
			/// selected for the new device information element.
			/// </summary>
			DICD_INHERIT_CLASSDRVS = 0x00000002
		}

		/// <summary>Specifies whether the class is a device setup class or a device interface class.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassPropertyW")]
		public enum DICLASSPROP
		{
			/// <para>ClassGuid specifies a device setup class. This flag cannot be used with DICLASSPROP_INTERFACE.</para>
			DICLASSPROP_INSTALLER = 0x00000001,

			/// <para>ClassGuid specifies a device interface class. This flag cannot be used with DICLASSPROP_INSTALLER.</para>
			DICLASSPROP_INTERFACE = 0x00000002,
		}

		/// <summary>State change action.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_PROPCHANGE_PARAMS")]
		public enum DICS : uint
		{
			/// <summary>
			/// <para>The device is being enabled.</para>
			/// <para>For this state change, Windows enables the device if the <c>DICS_FLAG_GLOBAL</c> flag is specified.</para>
			/// <para>
			/// If the <c>DICS_FLAG_CONFIGSPECIFIC</c> flag is specified and the current hardware profile is specified then Windows enables
			/// the device. If the <c>DICS_FLAG_CONFIGSPECIFIC</c> is specified and not the current hardware profile then Windows sets some
			/// flags in the registry and does not change the device's state. Windows will change the device state when the specified
			/// profile becomes the current profile.
			/// </para>
			/// </summary>
			DICS_ENABLE = 0x00000001,

			/// <summary>
			/// <para>The device is being disabled.</para>
			/// <para>For this state change, Windows disables the device if the <c>DICS_FLAG_GLOBAL</c> flag is specified.</para>
			/// <para>
			/// If the <c>DICS_FLAG_CONFIGSPECIFIC</c> flag is specified and the current hardware profile is specified then Windows disables
			/// the device. If the <c>DICS_FLAG_CONFIGSPECIFIC</c> is specified and not the current hardware profile then Windows sets some
			/// flags in the registry and does not change the device's state.
			/// </para>
			/// </summary>
			DICS_DISABLE = 0x00000002,

			/// <summary>
			/// <para>The properties of the device have changed.</para>
			/// <para>
			/// For this state change, Windows ignores the <c>Scope</c> information as long it is a valid value, and stops and restarts the device.
			/// </para>
			/// </summary>
			DICS_PROPCHANGE = 0x00000003,

			/// <summary>
			/// <para>The device is being started (if the request is for the currently active hardware profile).</para>
			/// <para><c>DICS_START</c> must be <c>DICS_FLAG_CONFIGSPECIFIC</c>. You cannot perform that change globally.</para>
			/// <para>
			/// Windows only starts the device if the current hardware profile is specified. Otherwise, Windows sets a registry flag and
			/// does not change the state of the device.
			/// </para>
			/// </summary>
			DICS_START = 0x00000004,

			/// <summary>
			/// <para>
			/// Windows only stops the device if the current hardware profile is specified. Otherwise, Windows sets a registry flag and does
			/// not change the state of the device.
			/// </para>
			/// <para>
			/// Components should not specify DICS_STOP or DICS_START. Instead, they should use DICS_PROPCHANGE to stop and restart a device
			/// to cause changes in the device's configuration to take effect.
			/// </para>
			/// </summary>
			DICS_STOP = 0x00000005,
		}

		/// <summary>Flags that specify the scope of a device property change.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_PROPCHANGE_PARAMS")]
		[Flags]
		public enum DICS_FLAG : uint
		{
			/// <summary>Make the change in all hardware profiles.</summary>
			DICS_FLAG_GLOBAL = 0x00000001,

			/// <summary>Make the change in the specified profile only.</summary>
			DICS_FLAG_CONFIGSPECIFIC = 0x00000002,

			/// <summary>The following flag is obsolete:</summary>
			[Obsolete]
			DICS_FLAG_CONFIGGENERAL = 0x00000004,
		}

		/// <summary>A flag value that indicates how the requested information should be returned.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetCustomDevicePropertyA")]
		[Flags]
		public enum DICUSTOMDEVPROP : uint
		{
			/// <summary>
			/// If set, the function retrieves both device instance-specific property values and hardware ID-specific property values,
			/// concatenated as a REG_MULTI_SZ-typed string. (For more information, see the <c>Remarks</c> section on this reference page.)
			/// </summary>
			DICUSTOMDEVPROP_MERGE_MULTISZ = 0x00000001
		}

		/// <summary>A flag that indicates one of the following types of property sheets.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevPropertySheetsA")]
		public enum DIGCDP_FLAG
		{
			/// <summary>
			/// Basic property sheets. Supported only in Microsoft Windows 95 and Windows 98. Do not use in Windows 2000 and later versions
			/// of Windows.
			/// </summary>
			DIGCDP_FLAG_BASIC = 0x00000001,

			/// <summary>Advanced property sheets.</summary>
			DIGCDP_FLAG_ADVANCED = 0x00000002,

			/// <summary>Not implemented.</summary>
			DIGCDP_FLAG_REMOTE_BASIC = 0x00000003,

			/// <summary>Advanced property sheets on a remote computer.</summary>
			DIGCDP_FLAG_REMOTE_ADVANCED = 0x00000004,
		}

		/// <summary>Specifies control options that filter the device information elements that are added to the device information set.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevsW")]
		[Flags]
		public enum DIGCF : uint
		{
			/// <summary>
			/// Return only the device that is associated with the system default device interface, if one is set, for the specified device
			/// interface classes.
			/// </summary>
			DIGCF_DEFAULT = 0x00000001,

			/// <summary>Return only devices that are currently present in a system.</summary>
			DIGCF_PRESENT = 0x00000002,

			/// <summary>Return a list of installed devices for all device setup classes or all device interface classes.</summary>
			DIGCF_ALLCLASSES = 0x00000004,

			/// <summary>Return only devices that are a part of the current hardware profile.</summary>
			DIGCF_PROFILE = 0x00000008,

			/// <summary>
			/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags
			/// parameter if the Enumerator parameter specifies a device instance ID.
			/// </summary>
			DIGCF_DEVICEINTERFACE = 0x00000010,
		}

		/// <summary>The type of registry key to be opened.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenClassRegKeyExA")]
		public enum DIOCR : uint
		{
			/// <summary>Open a setup class key. If ClassGuid is <c>NULL</c>, open the root key of the class installer branch.</summary>
			DIOCR_INSTALLER = 0x00000001,

			/// <summary>Open an interface class key. If ClassGuid is <c>NULL</c>, open the root key of the interface class branch.</summary>
			DIOCR_INTERFACE = 0x00000002
		}

		/// <summary>Controls how the device information element is opened.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDeviceInfoA")]
		[Flags]
		public enum DIOD : uint
		{
			/// <summary>
			/// <para>
			/// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with
			/// the device information set. In addition, if there is a selected driver for the device information set, that same driver is
			/// selected for the new device information element.
			/// </para>
			/// <para>
			/// If the device information element was already present, its class driver list, if any, is replaced with the inherited list.
			/// </para>
			/// </summary>
			DIOD_INHERIT_CLASSDRVS = 0x00000002,

			/// <summary>
			/// If this flag is specified and the device had been marked for pending removal, the operating system cancels the pending removal.
			/// </summary>
			DIOD_CANCEL_REMOVE = 0x00000004
		}

		/// <summary>Flags that determine how the device interface element is to be opened.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiOpenDeviceInterfaceW")]
		[Flags]
		public enum DIODI : uint
		{
			/// <summary>
			/// Specifies that the device information element for the underlying device will not be created if that element is not already
			/// present in the specified device information set. For more information, see the following <c>Remarks</c> section.
			/// </summary>
			DIODI_NO_ADD = 0x00000001,
		}

		/// <summary>The type of registry storage key to create.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDevRegKeyA")]
		[Flags]
		public enum DIREG : uint
		{
			/// <summary>Create a hardware key for the device.</summary>
			DIREG_DEV = 0x00000001,

			/// <summary>Create a software key for the device.</summary>
			DIREG_DRV = 0x00000002,

			/// <summary>Create both a software and hardware key for the device.</summary>
			DIREG_BOTH = 0x00000004,
		}

		/// <summary>These flags control the drawing operation.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDrawMiniIcon")]
		[Flags]
		public enum DMI : uint
		{
			/// <summary>Draw the mini-icon's mask into HDC.</summary>
			DMI_MASK = 0x00000001,

			/// <summary>
			/// Use the system color index specified in the HIWORD of Flags as the background color. If this flag is not set, COLOR_WINDOW
			/// is used.
			/// </summary>
			DMI_BKCOLOR = 0x00000002,

			/// <summary>If set, <c>SetupDiDrawMiniIcon</c> uses the supplied rectangle and stretches the icon to fit.</summary>
			DMI_USERECT = 0x00000004,
		}

		/// <summary>Flags that control functions operating on this driver.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DRVINSTALL_PARAMS")]
		[Flags]
		public enum DNF : uint
		{
			/// <summary>
			/// <para>
			/// If set, this flag prevents the driver node from being enumerated, regardless of the client that is performing the enumeration.
			/// </para>
			/// </summary>
			DNF_ALWAYSEXCLUDEFROMLIST = 0x00080000,

			/// <summary>
			/// <para>This driver's INF file is signed by an Authenticode signature. This flag is read-only to installers.</para>
			/// <para>For more information, see Using SetupAPI to Verify Driver Authenticode Signatures.</para>
			/// </summary>
			DNF_AUTHENTICODE_SIGNED = 0x00020000,

			/// <summary>
			/// <para>Do not use this driver. Installers can read and write this flag.</para>
			/// <para>If this flag is set, SetupDiSelectBestCompatDrv and SetupDiSelectDevice ignore this driver.</para>
			/// <para>
			/// A class installer or co-installer can set this flag to prevent Windows from listing the driver in the Select Driver dialog
			/// box. An installer might set this flag when it handles a DIF_SELECTDEVICE or DIF_SELECTBESTCOMPATDRV request, for example.
			/// </para>
			/// </summary>
			DNF_BAD_DRIVER = 0x00000800,

			/// <summary>
			/// <para>This driver is a basic driver. This flag is read-only to installers.</para>
			/// </summary>
			DNF_BASIC_DRIVER = 0x00010000,

			/// <summary>
			/// <para>This driver is a class driver. This flag is read-only to installers.</para>
			/// </summary>
			DNF_CLASS_DRIVER = 0x00000020,

			/// <summary>
			/// <para>This driver is a compatible driver. This flag is read-only to installers.</para>
			/// </summary>
			DNF_COMPATIBLE_DRIVER = 0x00000040,

			/// <summary>
			/// <para>
			/// There are other providers supplying drivers that have the same description as this driver. This flag is read-only to installers.
			/// </para>
			/// </summary>
			DNF_DUPDESC = 0x00000001,

			/// <summary>
			/// <para>There are other providers supplying drivers that have the same version as this driver. This flag is read-only to installers.</para>
			/// </summary>
			DNF_DUPDRIVERVER = 0x00008000,

			/// <summary>
			/// <para>
			/// There are other providers supplying drivers that have the same description as this driver. The only difference between this
			/// driver and its match is the driver date. This flag is read-only to installers.
			/// </para>
			/// <para>
			/// If this flag is set, Windows displays the driver date and driver version next to the driver so that the user can distinguish
			/// it from its match.
			/// </para>
			/// </summary>
			DNF_DUPPROVIDER = 0x00001000,

			/// <summary>
			/// <para>Do not display this driver in any driver-select dialogs.</para>
			/// </summary>
			DNF_EXCLUDEFROMLIST = 0x00000004,

			/// <summary>
			/// <para>This driver node is derived from an INF file that was included with this version of Windows.</para>
			/// </summary>
			DNF_INBOX_DRIVER = 0x00100000,

			/// <summary>
			/// <para>This driver came from the Internet or from Windows Update. This flag is read-only to installers.</para>
			/// <para>
			/// If you call SetupCopyOEMInf you must specify the SPOST_URL flag so that when Windows copies this INF into the
			/// %SystemRoot%\inf directory Windows will mark it as an Internet INF. If you omit this step then Windows will attempt to use
			/// this device to install other devices. The resulting problem is that Windows does not have the source files any longer and
			/// will end up prompting the user with an invalid path.
			/// </para>
			/// </summary>
			DNF_INET_DRIVER = 0x00000080,

			/// <summary>
			/// <para>This flag is read-only to installers, and is set if any of the following conditions are true:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>The driver has a WHQL release signature.</term>
			/// </item>
			/// <item>
			/// <term>The driver is an inbox driver.</term>
			/// </item>
			/// <item>
			/// <term>The driver has an Authenticode signature.</term>
			/// </item>
			/// </list>
			/// <para>For more information, see Driver Signing.</para>
			/// </summary>
			DNF_INF_IS_SIGNED = 0x00002000,

			/// <summary>
			/// <para>This driver node is currently installed for the device. This flag is read-only to installers.</para>
			/// </summary>
			DNF_INSTALLEDDRIVER = 0x00040000,

			/// <summary>
			/// <para>
			/// This driver comes from a legacy INF file. This flag is valid only for the NT-based operating system. This flag is read-only
			/// to installers.
			/// </para>
			/// </summary>
			DNF_LEGACYINF = 0x00000010,

			/// <summary>
			/// <para>Set if no physical driver is to be installed for this logical driver.</para>
			/// </summary>
			DNF_NODRIVER = 0x00000008,

			/// <summary>
			/// <para>Reserved.</para>
			/// </summary>
			DNF_OEM_F6_INF = 0x00004000,

			/// <summary>
			/// <para>
			/// This driver came from the Internet, but Windows does not currently have access to its source files. This flag is read-only
			/// to installers.
			/// </para>
			/// <para>
			/// The system will not install a driver marked with this flag because Windows does not have the source files and would end up
			/// prompting the user with an invalid path. The INF for such a driver can be used for everything except for installing devices.
			/// </para>
			/// </summary>
			DNF_OLD_INET_DRIVER = 0x00000400,

			/// <summary>
			/// <para>This driver currently/previously controlled the associated device. This flag is read-only to installers.</para>
			/// </summary>
			DNF_OLDDRIVER = 0x00000002,

			/// <summary>
			/// <para>
			/// Set this flag if the driver package is only part of the software solution that is needed to operate the device. In this
			/// case, the driver package requires the installation of additional software.
			/// </para>
			/// <para>For more information, see the following Remarks section.</para>
			/// </summary>
			DNF_REQUESTADDITIONALSOFTWARE = 0x00200000,
		}

		/// <summary>A value indicating the type of compression used.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileCompressionInfoA")]
		[Flags]
		public enum FILE_COMPRESSION : uint
		{
			/// <summary>The source file is not compressed with a recognized compression algorithm.</summary>
			FILE_COMPRESSION_NONE = 0,

			/// <summary>The source file is compressed with LZ compression.</summary>
			FILE_COMPRESSION_WINLZA = 1,

			/// <summary>The source file is compressed with MSZIP compression.</summary>
			FILE_COMPRESSION_MSZIP = 2,

			/// <summary>The source file is compressed with Windows Cabinet compression.</summary>
			FILE_COMPRESSION_NTCAB = 3,
		}

		/// <summary>Type of file operation to be added to the list.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddSectionToDiskSpaceListA")]
		public enum FILEOP
		{
			/// <summary>A file copy operation.</summary>
			FILEOP_COPY = 0,

			/// <summary>A file rename operation.</summary>
			FILEOP_RENAME = 1,

			/// <summary>A file delete operation.</summary>
			FILEOP_DELETE = 2,

			/// <summary>A file backup operation.</summary>
			FILEOP_BACKUP = 3,
		}

		/// <summary>File operation return code.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDefaultQueueCallbackA")]
		public enum FILEOP_RESULT
		{
			/// <summary>Aborts the operation.</summary>
			FILEOP_ABORT = 0,

			/// <summary>Performs the file operation.</summary>
			FILEOP_DOIT = 1,

			/// <summary>Skips the operation.</summary>
			FILEOP_SKIP = 2,

			/// <summary>Retries the operation.</summary>
			FILEOP_RETRY = FILEOP_DOIT,

			/// <summary>Gets a new path for the operation.</summary>
			FILEOP_NEWPATH = 4,
		}

		/// <summary>Flags that control display formatting and behavior of the dialog box.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupBackupErrorA")]
		[Flags]
		public enum IDF : uint
		{
			/// <summary>Do not display the browse option.</summary>
			IDF_NOBROWSE = 0x00000001,

			/// <summary>Do not display the skip file option.</summary>
			IDF_NOSKIP = 0x00000002,

			/// <summary>
			/// Do not display the details option.
			/// <para>If this flag is set, the TargetPathFile and Win32ErrorCode parameters can be omitted.</para>
			/// </summary>
			IDF_NODETAILS = 0x00000004,

			/// <summary>Do not check for compressed versions of the source file.</summary>
			IDF_NOCOMPRESSED = 0x00000008,

			/// <summary>Check for the file/disk before displaying the prompt dialog box, and, if present, return DPROMPT_SUCCESS immediately.</summary>
			IDF_CHECKFIRST = 0x00000100,

			/// <summary>Prevent the dialog box from beeping to get the user's attention when it first appears.</summary>
			IDF_NOBEEP = 0x00000200,

			/// <summary>Prevent the dialog box from becoming the foreground window.</summary>
			IDF_NOFOREGROUND = 0x00000400,

			/// <summary>Warns the user that skipping a file can affect the installation.</summary>
			IDF_WARNIFSKIP = 0x00000800,

			/// <summary/>
			IDF_NOREMOVABLEMEDIAPROMPT = 0x00001000,

			/// <summary/>
			IDF_USEDISKNAMEASPROMPT = 0x00002000,

			/// <summary>The operation source is a disk that a hardware manufacturer provides.</summary>
			IDF_OEMDISK = 0x80000000,
		}

		/// <summary>Style of the INF file.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_INF_INFORMATION")]
		public enum INF_STYLE
		{
			/// <summary>Specifies that the style of the INF file is unrecognized or nonexistent.</summary>
			INF_STYLE_NONE = 0x00000000,

			/// <summary>A legacy INF file format.</summary>
			INF_STYLE_OLDNT = 0x00000001,

			/// <summary>A Windows INF file format.</summary>
			INF_STYLE_WIN4 = 0x00000002,
		}

		/// <summary>Flags for <see cref="SetupGetInfInformation(HFILE, INFINFO, IntPtr, uint, out uint)"/>.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfInformationA")]
		public enum INFINFO : uint
		{
			/// <summary>
			/// InfSpec is an INF handle. A single INF handle may reference multiple INF files if they have been append-loaded together. If
			/// it does, the structure returned by this function contains multiple sets of information.
			/// </summary>
			INFINFO_INF_SPEC_IS_HINF = 1,

			/// <summary>The string specified for InfSpec is a full path. No further processing is performed on InfSpec.</summary>
			INFINFO_INF_NAME_IS_ABSOLUTE = 2,

			/// <summary>
			/// Search the default locations for the INF file specified for InfSpec, which is assumed to be a filename only. The default
			/// locations are %windir%\inf, followed by %windir%\system32.
			/// </summary>
			INFINFO_DEFAULT_SEARCH = 3,

			/// <summary>Same as INFINFO_DEFAULT_SEARCH, except the default locations are searched in reverse order.</summary>
			INFINFO_REVERSE_DEFAULT_SEARCH = 4,

			/// <summary>Search for the INF in each of the directories listed in the DevicePath value entry under the following: <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion</c></summary>
			INFINFO_INF_PATH_LIST_SEARCH = 5,
		}

		/// <summary>Flags for <see cref="SetupConfigureWmiFromInfSection"/>.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupConfigureWmiFromInfSectionA")]
		[Flags]
		public enum SCWMI : uint
		{
			/// <summary>
			/// If and only if this flag is set does the security information passed to this function override any security information set
			/// elsewhere in the INF file. If this flag does not exist and no security information exists in the INF file, the security is set.
			/// </summary>
			SCWMI_CLOBBER_SECURITY = 0x00000001
		}

		/// <summary>Flags that control the behavior of the file copy operation.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFileA")]
		[Flags]
		public enum SP_COPY : uint
		{
			/// <summary>Deletes the source file upon successful copy. The caller is not notified if the delete operation fails.</summary>
			SP_COPY_DELETESOURCE = 0x0000001,

			/// <summary>
			/// Copies the file only if doing so would overwrite a file at the destination path. If the target does not exist, the function
			/// returns FALSE and GetLastError returns NO_ERROR.
			/// </summary>
			SP_COPY_REPLACEONLY = 0x0000002,

			/// <summary>
			/// Examines each file being copied to see if its version resources indicate that it is either the same version or not newer
			/// than an existing copy on the target. The file version information used during version checks is that specified in the
			/// dwFileVersionMS and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one
			/// of the files does not have version resources, or if they have identical version information, the source file is considered
			/// newer. If the source file is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may
			/// cancel the copy operation. If CopyMsgHandler is not specified, the file is not copied.
			/// </summary>
			SP_COPY_NEWER = 0x0000004,

			/// <summary>
			/// Examines each file being copied to see if its version resources indicate that it is either the same version or not newer
			/// than an existing copy on the target. The file version information used during version checks is that specified in the
			/// dwFileVersionMS and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one
			/// of the files does not have version resources, or if they have identical version information, the source file is considered
			/// newer. If the source file is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may
			/// cancel the copy operation. If CopyMsgHandler is not specified, the file is not copied.
			/// </summary>
			SP_COPY_NEWER_OR_SAME = SP_COPY_NEWER,

			/// <summary>
			/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not
			/// specified, the file is not overwritten.
			/// </summary>
			SP_COPY_NOOVERWRITE = 0x0000008,

			/// <summary>
			/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
			/// appropriate). For example, copying F:\x86\cmd.ex_ to \\install\temp results in a target file of \\install\temp\cmd.ex_. If
			/// the SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called
			/// \\install\temp\cmd.exe. The file name part of DestinationName, if specified, is stripped and replaced with the file name of
			/// the source file. When SP_COPY_NODECOMP is specified, no language or version information can be checked.
			/// </summary>
			SP_COPY_NODECOMP = 0x0000010,

			/// <summary>
			/// Examine each file being copied to see if its language differs from the language of any existing file already on the target.
			/// If so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified,
			/// the file is not copied.
			/// </summary>
			SP_COPY_LANGUAGEAWARE = 0x0000020,

			/// <summary>SourceFile is a full source path. Do not look it up in the SourceDisksNames section of the INF file.</summary>
			SP_COPY_SOURCE_ABSOLUTE = 0x0000040,

			/// <summary>
			/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the SourceDisksNames
			/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
			/// </summary>
			SP_COPY_SOURCEPATH_ABSOLUTE = 0x0000080,

			/// <summary>If the file was in use during the copy operation, alert the user that the system requires a reboot.</summary>
			SP_COPY_IN_USE_NEEDS_REBOOT = 0x0000100,

			/// <summary>If the target exists, behaves as if it is in use and queues the file for copying on the next system restart.</summary>
			SP_COPY_FORCE_IN_USE = 0x0000200,

			/// <summary>Do not give the user the option to skip a file.</summary>
			SP_COPY_NOSKIP = 0x0000400,

			/// <summary>The current source file is continued in another cabinet file.</summary>
			SP_FLAG_CABINETCONTINUATION = 0x0000800,

			/// <summary>Checks whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</summary>
			SP_COPY_FORCE_NOOVERWRITE = 0x0001000,

			/// <summary>
			/// Examines each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
			/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not
			/// notified. The function returns FALSE, and GetLastError returns NO_ERROR.
			/// </summary>
			SP_COPY_FORCE_NEWER = 0x0002000,

			/// <summary>
			/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
			/// </summary>
			SP_COPY_WARNIFSKIP = 0x0004000,

			/// <summary>Do not offer the user the option to browse.</summary>
			SP_COPY_NOBROWSE = 0x0008000,

			/// <summary>
			/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
			/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
			/// </summary>
			SP_COPY_NEWER_ONLY = 0x0010000,

			/// <summary>Reserved.</summary>
			SP_COPY_RESERVED = 0x0020000,

			/// <summary>
			/// The specified .inf file's corresponding catalog files is copied to %windir%\Inf. If this flag is specified, the destination
			/// filename information is entered upon successful return if the specified .inf file already exists in the Inf directory.
			/// </summary>
			SP_COPY_OEMINF_CATALOG_ONLY = 0x0040000,

			/// <summary>file must be present upon reboot (i.e., it's needed by the loader); this flag implies a reboot</summary>
			SP_COPY_REPLACE_BOOT_FILE = 0x0080000,

			/// <summary>never prune this file</summary>
			SP_COPY_NOPRUNE = 0x0100000,

			/// <summary>Used when calling SetupCopyOemInf</summary>
			SP_COPY_OEM_F6_INF = 0x0200000,

			/// <summary>similar to SP_COPY_NODECOMP</summary>
			SP_COPY_ALREADYDECOMP = 0x0400000,

			/// <summary>BuildLab or WinSE signed</summary>
			SP_COPY_WINDOWS_SIGNED = 0x1000000,

			/// <summary>Used with the signature flag</summary>
			SP_COPY_PNPLOCKED = 0x2000000,

			/// <summary>If file in use, try to rename the target first</summary>
			SP_COPY_IN_USE_TRY_RENAME = 0x4000000,

			/// <summary>Referred by CopyFiles of inbox inf</summary>
			SP_COPY_INBOX_INF = 0x8000000,

			/// <summary>Copy using hardlink, if possible</summary>
			SP_COPY_HARDLINK = 0x10000000,
		}

		/// <summary>A value that identifies the property to be retrieved.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassRegistryPropertyA")]
		public enum SPCRP
		{
			/// <summary>
			/// (Windows Vista and later) The function returns a REG_MULTI_SZ list of the service names of the upper filter drivers that are
			/// installed for the device setup class.
			/// </summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPCRP_UPPERFILTERS = 0x00000011,

			/// <summary>
			/// (Windows Vista and later) The function returns a REG_MULTI_SZ list of the service names of the lower filter drivers that are
			/// installed for the device setup class.
			/// </summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPCRP_LOWERFILTERS = 0x00000012,

			/// <summary>
			/// The function returns the device's security descriptor as a SECURITY_DESCRIPTOR structure in self-relative format (described
			/// in the Microsoft Windows SDK documentation).
			/// </summary>
			[CorrespondingType(typeof(byte[]))]
			SPCRP_SECURITY = 0x00000017,

			/// <summary>
			/// The function returns the device's security descriptor as a text string. For information about security descriptor strings,
			/// see Security Descriptor Definition Language (Windows). For information about the format of security descriptor strings, see
			/// Security Descriptor Definition Language (Windows).
			/// </summary>
			[CorrespondingType(typeof(string))]
			SPCRP_SECURITY_SDS = 0x00000018,

			/// <summary>
			/// The function returns a DWORD value that represents the device type for the class. For more information, see Specifying
			/// Device Types.
			/// </summary>
			[CorrespondingType(typeof(FILE_DEVICE))]
			SPCRP_DEVTYPE = 0x00000019,

			/// <summary>
			/// The function returns a DWORD value indicating whether users can obtain exclusive access to devices for this class. The
			/// returned value is one if exclusive access is allowed, or zero otherwise.
			/// </summary>
			[CorrespondingType(typeof(BOOL))]
			SPCRP_EXCLUSIVE = 0x0000001A,

			/// <summary>
			/// The function returns flags indicating device characteristics for the class. For a list of characteristics flags, see the
			/// DeviceCharacteristics parameter to IoCreateDevice.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			SPCRP_CHARACTERISTICS = 0x0000001B,
		}

		/// <summary>The type of driver represented by this structure.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DRVINFO_DATA_V2_A")]
		public enum SPDIT : uint
		{
			/// <summary>This structure represents no driver.</summary>
			SPDIT_NODRIVER = 0x00000000,

			/// <summary>This structure represents a class driver.</summary>
			SPDIT_CLASSDRIVER = 0x00000001,

			/// <summary>This structure represents a compatible driver.</summary>
			SPDIT_COMPATDRIVER = 0x00000002,
		}

		/// <summary>Specifies the property to be retrieved or set.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceRegistryPropertyA")]
		public enum SPDRP
		{
			/// <summary>The function retrieves the device's address.</summary>
			[CorrespondingType(typeof(uint))]
			SPDRP_ADDRESS = 0x0000001C,

			/// <summary>The function retrieves the device's bus number.</summary>
			[CorrespondingType(typeof(uint))]
			SPDRP_BUSNUMBER = 0x00000015,

			/// <summary>The function retrieves the GUID for the device's bus type.</summary>
			[CorrespondingType(typeof(Guid))]
			SPDRP_BUSTYPEGUID = 0x00000013,

			/// <summary>
			/// The function retrieves a bitwise OR of the following CM_DEVCAP_Xxx flags in a DWORD. The device capabilities that are
			/// represented by these flags correspond to the device capabilities that are represented by the members of the
			/// DEVICE_CAPABILITIES structure. The CM_DEVCAP_Xxx constants are defined in Cfgmgr32.h.
			/// <list type="table">
			/// <listheader>
			/// <term>CM_DEVCAP_Xxx flag</term>
			/// <term>Corresponding DEVICE_CAPABILITIES structure member</term>
			/// </listheader>
			/// <item>
			/// <term>CM_DEVCAP_LOCKSUPPORTED</term>
			/// <term>LockSupported</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_EJECTSUPPORTED</term>
			/// <term>EjectSupported</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_REMOVABLE</term>
			/// <term>Removable</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_DOCKDEVICE</term>
			/// <term>DockDevice</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_UNIQUEID</term>
			/// <term>UniqueID</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_SILENTINSTALL</term>
			/// <term>SilentInstall</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_RAWDEVICEOK</term>
			/// <term>RawDeviceOK</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_SURPRISEREMOVALOK</term>
			/// <term>SurpriseRemovalOK</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_HARDWAREDISABLED</term>
			/// <term>HardwareDisabled</term>
			/// </item>
			/// <item>
			/// <term>CM_DEVCAP_NONDYNAMIC</term>
			/// <term>NonDynamic</term>
			/// </item>
			/// </list>
			/// </summary>
			[CorrespondingType(typeof(CM_DEVCAP))]
			SPDRP_CAPABILITIES = 0x0000000F,

			/// <summary>
			/// The function retrieves a bitwise OR of a device's characteristics flags in a DWORD. For a description of these flags, which
			/// are defined in Wdm.h and Ntddk.h, see the DeviceCharacteristics parameter of the IoCreateDevice function.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			SPDRP_CHARACTERISTICS = 0x0000001B,

			/// <summary>The function retrieves a REG_SZ string that contains the device setup class of a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_CLASS = 0x00000007,

			/// <summary>The function retrieves a REG_SZ string that contains the GUID that represents the device setup class of a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_CLASSGUID = 0x00000008,

			/// <summary>
			/// The function retrieves a REG_MULTI_SZ string that contains the list of compatible IDs for a device. For information about
			/// compatible IDs, see Device Identification Strings.
			/// </summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPDRP_COMPATIBLEIDS = 0x00000002,

			/// <summary>
			/// The function retrieves a bitwise OR of a device's configuration flags in a DWORD value. The configuration flags are
			/// represented by the CONFIGFLAG_Xxx bitmasks that are defined in Regstr.h.
			/// </summary>
			[CorrespondingType(typeof(CONFIGFLAG))]
			SPDRP_CONFIGFLAGS = 0x0000000A,

			/// <summary>
			/// (Windows XP and later) The function retrieves a CM_POWER_DATA structure that contains the device's power management information.
			/// </summary>
			[CorrespondingType(typeof(CM_POWER_DATA))]
			SPDRP_DEVICE_POWER_DATA = 0x0000001E,

			/// <summary>The function retrieves a REG_SZ string that contains the description of a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_DEVICEDESC = 0x00000000,

			/// <summary>
			/// The function retrieves a DWORD value that represents the device's type. For more information, see Specifying Device Types.
			/// </summary>
			[CorrespondingType(typeof(FILE_DEVICE))]
			SPDRP_DEVTYPE = 0x00000019,

			/// <summary>
			/// The function retrieves a string that identifies the device's software key (sometimes called the driver key). For more
			/// information about driver keys, see Registry Trees and Keys for Devices and Drivers.
			/// </summary>
			[CorrespondingType(typeof(string))]
			SPDRP_DRIVER = 0x00000009,

			/// <summary>The function retrieves a REG_SZ string that contains the name of the device's enumerator.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_ENUMERATOR_NAME = 0x00000016,

			/// <summary>
			/// The function retrieves a DWORD value that indicates whether a user can obtain exclusive use of the device. The returned
			/// value is one if exclusive use is allowed, or zero otherwise. For more information, see IoCreateDevice.
			/// </summary>
			[CorrespondingType(typeof(BOOL))]
			SPDRP_EXCLUSIVE = 0x0000001A,

			/// <summary>The function retrieves a REG_SZ string that contains the friendly name of a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_FRIENDLYNAME = 0x0000000C,

			/// <summary>
			/// The function retrieves a REG_MULTI_SZ string that contains the list of hardware IDs for a device. For information about
			/// hardware IDs, see Device Identification Strings.
			/// </summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPDRP_HARDWAREID = 0x00000001,

			/// <summary>
			/// (Windows XP and later) The function retrieves a DWORD value that indicates the installation state of a device. The
			/// installation state is represented by one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h. The
			/// CM_INSTALL_STATE_Xxx values correspond to the DEVICE_INSTALL_STATE enumeration values.
			/// </summary>
			[CorrespondingType(typeof(CM_INSTALL_STATE))]
			SPDRP_INSTALL_STATE = 0x00000022,

			/// <summary>The function retrieves the device's legacy bus type as an INTERFACE_TYPE value (defined in Wdm.h and Ntddk.h).</summary>
			[CorrespondingType(typeof(INTERFACE_TYPE))]
			SPDRP_LEGACYBUSTYPE = 0x00000014,

			/// <summary>The function retrieves a REG_SZ string that contains the hardware location of a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_LOCATION_INFORMATION = 0x0000000D,

			/// <summary>
			/// (Windows Server 2003 and later) The function retrieves a REG_MULTI_SZ string that represents the location of the device in
			/// the device tree.
			/// </summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPDRP_LOCATION_PATHS = 0x00000023,

			/// <summary>The function retrieves a REG_MULTI_SZ string that contains the names of a device's lower-filter drivers.</summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPDRP_LOWERFILTERS = 0x00000012,

			/// <summary>The function retrieves a REG_SZ string that contains the name of the device manufacturer.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_MFG = 0x0000000B,

			/// <summary>
			/// The function retrieves a REG_SZ string that contains the name that is associated with the device's PDO. For more
			/// information, see IoCreateDevice.
			/// </summary>
			[CorrespondingType(typeof(string))]
			SPDRP_PHYSICAL_DEVICE_OBJECT_NAME = 0x0000000E,

			/// <summary>
			/// (Windows XP and later) The function retrieves the device's current removal policy as a DWORD that contains one of the
			/// CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
			/// </summary>
			[CorrespondingType(typeof(CM_REMOVAL_POLICY))]
			SPDRP_REMOVAL_POLICY = 0x0000001F,

			/// <summary>
			/// (Windows XP and later) The function retrieves the device's hardware-specified default removal policy as a DWORD that
			/// contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
			/// </summary>
			[CorrespondingType(typeof(CM_REMOVAL_POLICY))]
			SPDRP_REMOVAL_POLICY_HW_DEFAULT = 0x00000020,

			/// <summary>
			/// (Windows XP and later) The function retrieves the device's override removal policy (if it exists) from the registry, as a
			/// DWORD that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
			/// </summary>
			[CorrespondingType(typeof(CM_REMOVAL_POLICY))]
			SPDRP_REMOVAL_POLICY_OVERRIDE = 0x00000021,

			/// <summary>The function retrieves a SECURITY_DESCRIPTOR structure for a device.</summary>
			[CorrespondingType(typeof(byte[]))]
			SPDRP_SECURITY = 0x00000017,

			/// <summary>
			/// The function retrieves a REG_SZ string that contains the device's security descriptor. For information about security
			/// descriptor strings, see Security Descriptor Definition Language (Windows). For information about the format of security
			/// descriptor strings, see Security Descriptor Definition Language (Windows).
			/// </summary>
			[CorrespondingType(typeof(string))]
			SPDRP_SECURITY_SDS = 0x00000018,

			/// <summary>The function retrieves a REG_SZ string that contains the service name for a device.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_SERVICE = 0x00000004,

			/// <summary>
			/// The function retrieves a DWORD value set to the value of the <c>UINumber</c> member of the device's DEVICE_CAPABILITIES structure.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			SPDRP_UI_NUMBER = 0x00000010,

			/// <summary>The function retrieves a format string (REG_SZ) used to display the <c>UINumber</c> value.</summary>
			[CorrespondingType(typeof(string))]
			SPDRP_UI_NUMBER_DESC_FORMAT = 0x0000001D,

			/// <summary>The function retrieves a REG_MULTI_SZ string that contains the names of a device's upper filter drivers.</summary>
			[CorrespondingType(typeof(System.Collections.Generic.IEnumerable<string>))]
			[CorrespondingType(typeof(string[]))]
			SPDRP_UPPERFILTERS = 0x00000011,

			/// <summary>Base ContainerID (R)</summary>
			[CorrespondingType(typeof(Guid))]
			SPDRP_BASE_CONTAINERID = 0x00000024,
		}

		/// <summary>Flags for <see cref="SetupCreateDiskSpaceList"/>.</summary>
		[Flags]
		public enum SPDSL : uint
		{
			/// <summary>
			/// File operations added to the list will ignore files that already exist on the disk. For example, if the disk contains a
			/// 5000-byte file, C:\MyDir\MyFile, and you add a Copy operation to the disk-space list for a new version, C:\MyDir\MyFile,
			/// that is 6500 bytes, the space required will be 6500 bytes (instead of 1500 bytes, which is the value returned if you do not
			/// set SPDSL_IGNORE_DISK).
			/// </summary>
			SPDSL_IGNORE_DISK = 0x00000001,

			/// <summary/>
			SPDSL_DISALLOW_NEGATIVE_ADJUST = 0x00000002,
		}

		/// <summary>Controls the log file initialization.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInitializeFileLogA")]
		[Flags]
		public enum SPFILELOG : uint
		{
			/// <summary>
			/// Use the system file log. The user must be an Administrator to specify this option unless SPFILELOG_QUERYONLY is specified
			/// and LogFileName is not specified. Do not specify SPFILELOG_SYSTEMLOG in combination with SPFILELOG_FORCENEW.
			/// </summary>
			SPFILELOG_SYSTEMLOG = 0x00000001,

			/// <summary>
			/// If the log file exists, overwrite it. If the log file exists and this flag is not specified, any new files that are
			/// installed are added to the list in the existing log file. Do not specify in combination with SPFILELOG_SYSTEMLOG.
			/// </summary>
			SPFILELOG_FORCENEW = 0x00000002,

			/// <summary>Open the log file for querying only.</summary>
			SPFILELOG_QUERYONLY = 0x00000004,
		}

		/// <summary>Notification of a queue action.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDefaultQueueCallbackA")]
		public enum SPFILENOTIFY : uint
		{
			/// <summary>Started queued file operations.</summary>
			SPFILENOTIFY_STARTQUEUE = 0x00000001,

			/// <summary>Finished queued file operations.</summary>
			SPFILENOTIFY_ENDQUEUE = 0x00000002,

			/// <summary>Started a copy, rename, or delete subqueue.</summary>
			SPFILENOTIFY_STARTSUBQUEUE = 0x00000003,

			/// <summary>Finished a copy, rename, or delete subqueue.</summary>
			SPFILENOTIFY_ENDSUBQUEUE = 0x00000004,

			/// <summary>Started a delete operation.</summary>
			SPFILENOTIFY_STARTDELETE = 0x00000005,

			/// <summary>Finished a delete operation.</summary>
			SPFILENOTIFY_ENDDELETE = 0x00000006,

			/// <summary>Encountered an error while deleting a file.</summary>
			SPFILENOTIFY_DELETEERROR = 0x00000007,

			/// <summary>Started a rename operation.</summary>
			SPFILENOTIFY_STARTRENAME = 0x00000008,

			/// <summary>Finished a rename operation.</summary>
			SPFILENOTIFY_ENDRENAME = 0x00000009,

			/// <summary>Encountered an error while renaming a file.</summary>
			SPFILENOTIFY_RENAMEERROR = 0x0000000a,

			/// <summary>Started a copy operation.</summary>
			SPFILENOTIFY_STARTCOPY = 0x0000000b,

			/// <summary>Finished a copy operation.</summary>
			SPFILENOTIFY_ENDCOPY = 0x0000000c,

			/// <summary>Encountered an error while copying a file.</summary>
			SPFILENOTIFY_COPYERROR = 0x0000000d,

			/// <summary>New media is required.</summary>
			SPFILENOTIFY_NEEDMEDIA = 0x0000000e,

			/// <summary>A node in the file queue has been scanned.</summary>
			SPFILENOTIFY_QUEUESCAN = 0x0000000f,

			/// <summary></summary>
			SPFILENOTIFY_CABINETINFO = 0x00000010,

			/// <summary>A file is encountered in the cabinet.</summary>
			SPFILENOTIFY_FILEINCABINET = 0x00000011,

			/// <summary>The current file is continued in the next cabinet.</summary>
			SPFILENOTIFY_NEEDNEWCABINET = 0x00000012,

			/// <summary>The file has been extracted from the cabinet.</summary>
			SPFILENOTIFY_FILEEXTRACTED = 0x00000013,

			/// <summary>The file was in use, and the current operation has been delayed until the system is rebooted.</summary>
			SPFILENOTIFY_FILEOPDELAYED = 0x00000014,

			/// <summary>Started a backup operation.</summary>
			SPFILENOTIFY_STARTBACKUP = 0x00000015,

			/// <summary>Encountered an error while copying a file.</summary>
			SPFILENOTIFY_BACKUPERROR = 0x00000016,

			/// <summary>Finished a backup operation.</summary>
			SPFILENOTIFY_ENDBACKUP = 0x00000017,

			/// <summary>A node in the file queue has been scanned.</summary>
			SPFILENOTIFY_QUEUESCAN_EX = 0x00000018,

			/// <summary>The registration or unregistration of the file has started.</summary>
			SPFILENOTIFY_STARTREGISTRATION = 0x00000019,

			/// <summary>The registration or unregistration of the file has finished.</summary>
			SPFILENOTIFY_ENDREGISTRATION = 0x00000020,

			/// <summary>A node in the file queue has been scanned.</summary>
			SPFILENOTIFY_QUEUESCAN_SIGNERINFO = 0x00000040,

			/// <summary>Existing target file is in a different language than the source.</summary>
			SPFILENOTIFY_LANGMISMATCH = 0x00010000,

			/// <summary>Target file exists.</summary>
			SPFILENOTIFY_TARGETEXISTS = 0x00020000,

			/// <summary>Existing target file is newer than source.</summary>
			SPFILENOTIFY_TARGETNEWER = 0x00040000,
		}

		/// <summary>Controls what actions to perform.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFromInfSectionA")]
		[Flags]
		public enum SPINST : uint
		{
			/// <summary>
			/// This flag is only used when installing a device driver.
			/// <para>
			/// Perform logical configuration operations ( <c>LogConf</c> lines in the <c>Install</c> section being processed). This flag is
			/// only used if DeviceInfoSet and DeviceInfoData are specified.
			/// </para>
			/// <para>
			/// For more information about installing device drivers, <c>LogConf</c>, DeviceInfoSet, or DeviceInfoData, see the DDK
			/// Programmer's Guide.
			/// </para>
			/// </summary>
			SPINST_LOGCONFIG = 0x00000001,

			/// <summary>Perform INI-file operations ( <c>UpdateInis</c>, <c>UpdateIniFields</c> lines in the Install section being processed).</summary>
			SPINST_INIFILES = 0x00000002,

			/// <summary>Perform registry operations ( <c>AddReg</c>, <c>DelReg</c> lines in the <c>Install</c> section being processed).</summary>
			SPINST_REGISTRY = 0x00000004,

			/// <summary>Perform INI-file to registry operations ( <c>Ini2Reg</c> lines in the <c>Install</c> section being processed).</summary>
			SPINST_INI2REG = 0x00000008,

			/// <summary>
			/// Perform file operations ( <c>CopyFiles</c>, <c>DelFiles</c>, <c>RenFiles</c> lines in the <c>Install</c> section being processed).
			/// </summary>
			SPINST_FILES = 0x00000010,

			/// <summary/>
			SPINST_BITREG = 0x00000020,

			/// <summary>
			/// To send a notification to the callback routine when registering a file, include SPINST_REGISTERCALLBACKAWARE plus
			/// SPINST_REGSVR in Flags. The caller must also specify the MsgHandler parameter.
			/// </summary>
			SPINST_REGSVR = 0x00000040,

			/// <summary>
			/// To send a notification to the callback routine when unregistering a file, include SPINST_REGISTERCALLBACKAWARE plus
			/// SPINST_UNREGSVR in the Flags. The caller must also specify the MsgHandler parameter.
			/// </summary>
			SPINST_UNREGSVR = 0x00000080,

			/// <summary/>
			SPINST_PROFILEITEMS = 0x00000100,

			/// <summary/>
			SPINST_COPYINF = 0x00000200,

			/// <summary/>
			SPINST_PROPERTIES = 0x00000400,

			/// <summary/>
			SPINST_SINGLESECTION = 0x00010000,

			/// <summary/>
			SPINST_LOGCONFIG_IS_FORCED = 0x00020000,

			/// <summary/>
			SPINST_LOGCONFIGS_ARE_OVERRIDES = 0x00040000,

			/// <summary>
			/// When using the <c>RegisterDlls</c> INF directive to self-register DLLs on Windows 2000, callers of
			/// <c>SetupInstallFromInfSection</c> may receive notifications on each file as it is registered or unregistered. To send a
			/// SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION notification to the callback routine, include
			/// SPINST_REGISTERCALLBACKAWARE plus either SPINST_REGSVR or SPINST_UNREGSVR. The caller must also set the MsgHandler parameter.
			/// </summary>
			SPINST_REGISTERCALLBACKAWARE = 0x00080000,

			/// <summary/>
			SPINST_DEVICEINSTALL = 0x00100000,
		}

		/// <summary>Flags for <see cref="SP_DEVICE_INTERFACE_DATA"/>.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVICE_INTERFACE_DATA")]
		[Flags]
		public enum SPINT : uint
		{
			/// <summary>The interface is active (enabled).</summary>
			SPINT_ACTIVE = 0x00000001,

			/// <summary>The interface is the default interface for the device class.</summary>
			SPINT_DEFAULT = 0x00000002,

			/// <summary>The interface is removed.</summary>
			SPINT_REMOVED = 0x00000004
		}

		/// <summary>The property sheet page to add to the property sheet.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_PROPSHEETPAGE_REQUEST")]
		public enum SPPSR : uint
		{
			/// <summary>Specifies the Resource Selection page supplied by the SetupAPI DLL.</summary>
			SPPSR_SELECT_DEVICE_RESOURCES = 1,

			/// <summary>
			/// Specifies a page that is supplied by the device's BasicProperties32 provider. That is, an installer or other component that
			/// supplied page(s) in response to a DIF_ADDPROPERTYPAGE_BASIC installation request.
			/// </summary>
			SPPSR_ENUM_BASIC_DEVICE_PROPERTIES,

			/// <summary>
			/// Specifies a page that is supplied by the class and/or the device's EnumPropPages32 provider. That is, an installer or other
			/// component that supplied page(s) in response to a DIF_ADDPROPERTYPAGE_ADVANCED installation request.
			/// </summary>
			SPPSR_ENUM_ADV_DEVICE_PROPERTIES,
		}

		/// <summary>Flags/FlagMask for use with SetupSetFileQueueFlags and returned by SetupGetFileQueueFlags.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileQueueFlags")]
		[Flags]
		public enum SPQ_FLAG : uint
		{
			/// <summary>If this flag is set, SetupCommitFileQueue issues backup notifications.</summary>
			SPQ_FLAG_BACKUP_AWARE = 0x00000001,

			/// <summary>
			/// If set, SetupCommitFileQueue will fail with ERROR_SET_SYSTEM_RESTORE_POINT if the user elects to proceed with an unsigned
			/// queue committal. This allows the caller to set a system restore point, then re-commit the file queue.
			/// </summary>
			SPQ_FLAG_ABORT_IF_UNSIGNED = 0x00000002,

			/// <summary>If set, at least one file was replaced by a different version</summary>
			SPQ_FLAG_FILES_MODIFIED = 0x00000004,

			/// <summary>
			/// If set then always do a shuffle move. A shuffle move will first try to copy the source over the destination file, but if the
			/// destination file is in use it will rename the destination file to a temp name and queue the temp name for deletion. It will
			/// then be free to copy the source to the destination name. It is considered an error if the destination file can't be renamed
			/// for some reason.
			/// </summary>
			SPQ_FLAG_DO_SHUFFLEMOVE = 0x00000008,
		}

		/// <summary>A flag value that controls how the device is registered.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiRegisterDeviceInfo")]
		[Flags]
		public enum SPRDI : uint
		{
			/// <summary>
			/// Search for a previously-existing device instance that corresponds to the device that is represented by DeviceInfoData. If
			/// this flag is not specified, the device instance is registered regardless of whether a device instance already exists for it.
			/// </summary>
			SPRDI_FIND_DUPS = 0x00000001
		}

		/// <summary>
		/// For a SPFILENOTIFY_STARTREGISTRATION notification, this member is not used and should be set to SPREG_SUCCESS. For a
		/// SPFILENOTIFY_ENDREGISTRATION notification, set to one of the following failure codes that indicate the result of registration.
		/// </summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_REGISTER_CONTROL_STATUSA")]
		public enum SPREG : uint
		{
			/// <summary>The file was successfully registered or unregistered. WinError not used.</summary>
			SPREG_SUCCESS = 0x00000000,

			/// <summary>LoadLibrary failed for the file. WinError contains an extended error code from the component.</summary>
			SPREG_LOADLIBRARY = 0x00000001,

			/// <summary>GetProcAddress failed for the file. WinError contains an extended error code from the component.</summary>
			SPREG_GETPROCADDR = 0x00000002,

			/// <summary>DLLRegisterServer entry point returned failure. WinError contains an extended error code from the component.</summary>
			SPREG_REGSVR = 0x00000003,

			/// <summary>DLLInstall entry point returned failure. WinError contains an extended error code from the component.</summary>
			SPREG_DLLINSTALL = 0x00000004,

			/// <summary>The file registration or unregistration exceeded the specified timeout. WinError is set to ERROR_TIMEOUT.</summary>
			SPREG_TIMEOUT = 0x00000005,

			/// <summary>
			/// File registration or unregistration failed for an unknown reason. WinError indicates an extended error code from the component.
			/// </summary>
			SPREG_UNKNOWN = 0xFFFFFFFF,
		}

		/// <summary>Indicates what information is desired.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceInfoA")]
		public enum SRCINFO
		{
			/// <summary>The path specified for the source. This is not a full path, but the path relative to the installation root.</summary>
			SRCINFO_PATH = 1,

			/// <summary>The tag file that identifies the source media, or if cabinets are used, the name of the cabinet file.</summary>
			SRCINFO_TAGFILE = 2,

			/// <summary>A description for the media.</summary>
			SRCINFO_DESCRIPTION = 3,

			/// <summary/>
			SRCINFO_FLAGS = 4,
		}

		/// <summary>List to which the source will be appended.</summary>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddToSourceListA")]
		[Flags]
		public enum SRCLIST : uint
		{
			/// <summary>
			/// The specified list is temporary and will be the only list accessible to the current process until
			/// SetupCancelTemporarySourceList is called or SetSourceList is called again. <note>Important: If a temporary list is set,
			/// sources are not added to or deleted from the system or user lists, even if subsequent calls to SetupAddToSourceList or
			/// SetupRemoveFromSourceList explicitly specify those lists.</note>
			/// </summary>
			SRCLIST_TEMPORARY = 0x00000001,

			/// <summary>
			/// The user is not allowed to add or change sources when SetupPromptForDisk is used. This flag is typically used in combination
			/// with the SRCLIST_TEMPORARY flag.
			/// </summary>
			SRCLIST_NOBROWSE = 0x00000002,

			/// <summary>Add the source to the per-system list. The caller must be an administrator.</summary>
			SRCLIST_SYSTEM = 0x00000010,

			/// <summary>Add the source to the per-user list.</summary>
			SRCLIST_USER = 0x00000020,

			/// <summary>
			/// If the caller is an administrator, the source is added to the per-system list; if the caller is not a member of the
			/// administrators local group, the source is added to the per-user list for the current user.
			/// </summary>
			/// <summary>
			/// <c>Note</c> If a temporary list is currently in use (see SetupSetSourceList), the preceding flags are ignored and the source
			/// is added to the temporary list.
			/// </summary>
			SRCLIST_SYSIFADMIN = 0x00000040,

			/// <summary>Remove all subdirectories of the source.</summary>
			SRCLIST_SUBDIRS = 0x00000100,

			/// <summary>
			/// Add the source to the end of the list. If this flag is not specified, the source is added to the beginning of the list.
			/// </summary>
			SRCLIST_APPEND = 0x00000200,

			/// <summary>
			/// Normally, all paths are stripped of a platform-specific component if it is the final component. For example, a path stored
			/// in the registry as f:\x86 is returned as f:. If this flag is specified, the platform-specific component is not stripped.
			/// </summary>
			SRCLIST_NOSTRIPPLATFORM = 0x00000400,
		}

		/// <summary>Extracts a value from memory of the type specified.</summary>
		/// <param name="pType">Type of the value to extract.</param>
		/// <param name="mem">The memory handle holding the value.</param>
		/// <returns>An object of the specified type.</returns>
		public static object GetObject(this DEVPROPTYPE pType, ISafeMemoryHandle mem) => GetObject(pType, mem.DangerousGetHandle(), mem.Size);

		/// <summary>Extracts a value from memory of the type specified.</summary>
		/// <param name="pType">Type of the value to extract.</param>
		/// <param name="mem">The pointer to the memory holding the value.</param>
		/// <param name="memSize">Size of the allocated memory.</param>
		/// <returns>An object of the specified type.</returns>
		public static object GetObject(this DEVPROPTYPE pType, IntPtr mem, SizeT memSize)
		{
			switch (pType)
			{
				case DEVPROPTYPE.DEVPROP_TYPE_EMPTY:
				case DEVPROPTYPE.DEVPROP_TYPE_NULL:
					return null;
				case DEVPROPTYPE.DEVPROP_TYPE_SBYTE:
				case DEVPROPTYPE.DEVPROP_TYPE_BYTE:
				case DEVPROPTYPE.DEVPROP_TYPE_INT16:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT16:
				case DEVPROPTYPE.DEVPROP_TYPE_INT32:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT32:
				case DEVPROPTYPE.DEVPROP_TYPE_INT64:
				case DEVPROPTYPE.DEVPROP_TYPE_UINT64:
				case DEVPROPTYPE.DEVPROP_TYPE_FLOAT:
				case DEVPROPTYPE.DEVPROP_TYPE_DOUBLE:
				case DEVPROPTYPE.DEVPROP_TYPE_DECIMAL:
				case DEVPROPTYPE.DEVPROP_TYPE_GUID:
				case DEVPROPTYPE.DEVPROP_TYPE_FILETIME:
				case DEVPROPTYPE.DEVPROP_TYPE_CURRENCY:
				case DEVPROPTYPE.DEVPROP_TYPE_DATE:
				case DEVPROPTYPE.DEVPROP_TYPE_STRING:
				case DEVPROPTYPE.DEVPROP_TYPE_DEVPROPKEY:
				case DEVPROPTYPE.DEVPROP_TYPE_DEVPROPTYPE:
				case DEVPROPTYPE.DEVPROP_TYPE_ERROR:
				case DEVPROPTYPE.DEVPROP_TYPE_NTSTATUS:
				case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING:
				case DEVPROPTYPE.DEVPROP_TYPE_BINARY:
					return mem.Convert(memSize, CorrespondingTypeAttribute.GetCorrespondingTypes(pType).First());
				case DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST:
				case DEVPROPTYPE.DEVPROP_TYPEMOD_LIST | DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING:
					return mem.ToStringEnum(CharSet.Auto, 0, memSize).ToArray();
				case DEVPROPTYPE.DEVPROP_TYPE_BOOLEAN:
					return mem.ToStructure<BOOLEAN>(memSize).Value;
				case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR:
					return new System.Security.AccessControl.RawSecurityDescriptor(mem.ToArray<byte>(memSize, 0, memSize), 0);
				case DEVPROPTYPE.DEVPROP_TYPE_STRING_INDIRECT:
					return Environment.ExpandEnvironmentVariables(StringHelper.GetString(mem, CharSet.Auto, memSize));
				default:
					if (pType.IsFlagSet(DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY))
					{
						var elemtype = CorrespondingTypeAttribute.GetCorrespondingTypes(pType.ClearFlags(DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY)).First();
						var elemsz = Marshal.SizeOf(elemtype);
						return mem.ToArray(elemtype, memSize / elemsz, 0, memSize);
					}
					break;
			}
			throw new ArgumentException($"Unable to convert to {pType}.");
		}

		/// <summary>Splits the provided <see cref="DEVPROPTYPE"/> value into its parts.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The type and modifier.</returns>
		public static (DEVPROPTYPE type, DEVPROPTYPE mod) Split(this DEVPROPTYPE value) => (value & DEVPROPTYPE.DEVPROP_MASK_TYPE, value & DEVPROPTYPE.DEVPROP_MASK_TYPEMOD);

		/// <summary>
		/// The <c>CABINET_INFO</c> structure stores information about a cabinet file. The SetupIterateCabinet function specifies this
		/// structure as a parameter when it sends a SPFILENOTIFY_NEEDNEWCABINET notification to the cabinet callback routine.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-cabinet_info_a typedef struct _CABINET_INFO_A { PCSTR
		// CabinetPath; PCSTR CabinetFile; PCSTR DiskName; USHORT SetId; USHORT CabinetNumber; } CABINET_INFO_A, *PCABINET_INFO_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._CABINET_INFO_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CABINET_INFO
		{
			/// <summary>Path to the cabinet file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string CabinetPath;

			/// <summary>Name of the cabinet file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string CabinetFile;

			/// <summary>Name of the source media that contains the cabinet file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string DiskName;

			/// <summary>Identifier of the current set. This number is generated by the software that builds the cabinet.</summary>
			public ushort SetId;

			/// <summary>
			/// Number of the cabinet. This number is generated by the software that builds the cabinet and is generally a zero- or 1-based
			/// index indicating the ordinal of the position of the cabinet within a set.
			/// </summary>
			public ushort CabinetNumber;
		}

		/// <summary>
		/// The <c>FILE_IN_CABINET_INFO</c> structure provides information about a file found in the cabinet. The SetupIterateCabinet
		/// function sends this structure as one of the parameters when it sends a SPFILENOTIFY_FILEINCABINET notification to the cabinet
		/// callback routine.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-file_in_cabinet_info_a typedef struct
		// _FILE_IN_CABINET_INFO_A { PCSTR NameInCabinet; DWORD FileSize; DWORD Win32Error; WORD DosDate; WORD DosTime; WORD DosAttribs;
		// CHAR FullTargetName[MAX_PATH]; } FILE_IN_CABINET_INFO_A, *PFILE_IN_CABINET_INFO_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._FILE_IN_CABINET_INFO_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILE_IN_CABINET_INFO
		{
			/// <summary>File name as it exists within the cabinet file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string NameInCabinet;

			/// <summary>Uncompressed size of the file in the cabinet, in bytes.</summary>
			public uint FileSize;

			/// <summary>If an error occurs, this member is the system error code. If no error has occurred, it is NO_ERROR.</summary>
			public Win32Error Win32Error;

			/// <summary>Date that the file was last saved.</summary>
			public ushort DosDate;

			/// <summary>MS-DOS time stamp of the file in the cabinet.</summary>
			public ushort DosTime;

			/// <summary>Attributes of the file in the cabinet.</summary>
			public ushort DosAttribs;

			/// <summary>Target path and file name.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string FullTargetName;
		}

		/// <summary>
		/// The <c>FILEPATHS</c> structure stores source and target path information. The setup functions send the <c>FILEPATHS</c>
		/// structure as a parameter in several of the notifications sent to callback routines. For more information, see Notifications.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-filepaths_a typedef struct _FILEPATHS_A { PCSTR Target;
		// PCSTR Source; UINT Win32Error; DWORD Flags; } FILEPATHS_A, *PFILEPATHS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._FILEPATHS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILEPATHS
		{
			/// <summary>Path to the target file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Target;

			/// <summary>
			/// Path to the source file. This member is not used when the <c>FILEPATHS</c> structure is used with a file delete operation.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Source;

			/// <summary>If an error occurs, this member is the system error code. If no error has occurred, it is NO_ERROR.</summary>
			public Win32Error Win32Error;

			/// <summary>
			/// <para>Additional information that depends on the notification sent with the <c>FILEPATHS</c> structure.</para>
			/// <para>
			/// For SPFILENOTIFY_COPYERROR notifications, <c>Flags</c> specifies dialog box behavior and can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SP_COPY_NOBROWSE</term>
			/// <term>Do not offer the user the option to browse.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NOSKIP</term>
			/// <term>Do not offer the user the option to skip the file.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_WARNIFSKIP</term>
			/// <term>Inform the user that skipping the file may affect the installation.</term>
			/// </item>
			/// </list>
			/// <para>
			/// For SPFILENOTIFY_FILEOPDELAYED notifications, <c>Flags</c> specifies the type of file operation delayed and can be one of
			/// the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FILEOP_COPY</term>
			/// <term>A file copy operation was delayed.</term>
			/// </item>
			/// <item>
			/// <term>FILEOP_DELETE</term>
			/// <term>A file delete operation was delayed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;
		}

		/// <summary>
		/// The <c>FILEPATHS_SINGNERINFO</c> structure stores source and target path information, and also file signature information. The
		/// setup functions send <c>FILEPATHS_SIGNERINFO</c> as a parameter in several of the notifications sent to callback routines. For
		/// more information, see Notifications.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-filepaths_signerinfo_a typedef struct
		// _FILEPATHS_SIGNERINFO_A { PCSTR Target; PCSTR Source; UINT Win32Error; DWORD Flags; PCSTR DigitalSigner; PCSTR Version; PCSTR
		// CatalogFile; } FILEPATHS_SIGNERINFO_A, *PFILEPATHS_SIGNERINFO_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._FILEPATHS_SIGNERINFO_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct FILEPATHS_SIGNERINFO
		{
			/// <summary>Path to the target file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Target;

			/// <summary>Path to the source file. This member is not used when the FILEPATHS structure is used with a file delete operation.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Source;

			/// <summary>If an error occurs, this member is the system error code. If no error has occurred, it is NO_ERROR.</summary>
			public Win32Error Win32Error;

			/// <summary>
			/// <para>Additional information that depends on the notification sent with the <c>FILEPATHS_SIGNERINFO</c> structure.</para>
			/// <para>
			/// For SPFILENOTIFY_COPYERROR notifications, <c>Flags</c> specifies dialog box behavior and can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SP_COPY_NOBROWSE</term>
			/// <term>Do not offer the user the option to browse.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NOSKIP</term>
			/// <term>Do not offer the user the option to skip the file.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_WARNIFSKIP</term>
			/// <term>Inform the user that skipping the file may affect the installation.</term>
			/// </item>
			/// </list>
			/// <para>
			/// For SPFILENOTIFY_FILEOPDELAYED notifications, <c>Flags</c> specifies the type of file operation delayed and can be one of
			/// the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FILEOP_COPY</term>
			/// <term>A file copy operation was delayed.</term>
			/// </item>
			/// <item>
			/// <term>FILEOP_DELETE</term>
			/// <term>A file delete operation was delayed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>Digital signer of the file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string DigitalSigner;

			/// <summary>Version of the file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Version;

			/// <summary>Catalog file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string CatalogFile;
		}

		/// <summary>Provides a handle to a device information set.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HDEVINFO : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HDEVINFO"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HDEVINFO(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HDEVINFO"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HDEVINFO NULL => new HDEVINFO(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HDEVINFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HDEVINFO h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDEVINFO"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HDEVINFO(IntPtr h) => new HDEVINFO(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HDEVINFO h1, HDEVINFO h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HDEVINFO h1, HDEVINFO h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HDEVINFO h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a disk-space list.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HDSKSPC : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HDSKSPC"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HDSKSPC(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HDSKSPC"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HDSKSPC NULL => new HDSKSPC(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HDSKSPC"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HDSKSPC h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HDSKSPC"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HDSKSPC(IntPtr h) => new HDSKSPC(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HDSKSPC h1, HDSKSPC h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HDSKSPC h1, HDSKSPC h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HDSKSPC h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an open INF file.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HINF : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HINF"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HINF(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HINF"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HINF NULL => new HINF(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HINF"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HINF h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HINF"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HINF(IntPtr h) => new HINF(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HINF h1, HINF h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HINF h1, HINF h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HINF h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a file queue.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HSPFILEQ : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HSPFILEQ"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HSPFILEQ(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HSPFILEQ"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HSPFILEQ NULL => new HSPFILEQ(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HSPFILEQ"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HSPFILEQ h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSPFILEQ"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSPFILEQ(IntPtr h) => new HSPFILEQ(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HSPFILEQ h1, HSPFILEQ h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HSPFILEQ h1, HSPFILEQ h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HSPFILEQ h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// The <c>INFCONTEXT</c> structure stores context information that functions such as SetupGetLineText use to navigate INF files.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-infcontext typedef struct _INFCONTEXT { PVOID Inf; PVOID
		// CurrentInf; UINT Section; UINT Line; } INFCONTEXT, *PINFCONTEXT;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._INFCONTEXT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INFCONTEXT
		{
			/// <summary>Handle to the INF file returned by <see cref="SetupOpenInfFile"/>.</summary>
			public HINF Inf;

			/// <summary>
			/// Pointer to the current INF file. The <c>Inf</c> member may point to multiple files if they were appended to the open INF
			/// file using SetupOpenAppendInfFile.
			/// </summary>
			public HINF CurrentInf;

			/// <summary>Section in the current INF file.</summary>
			public uint Section;

			/// <summary>
			/// <para>Line of the current section in the INF file.</para>
			/// <para>
			/// <c>Note</c> The setup functions use this structure internally and it must not be accessed or modified by applications. It is
			/// included here for informational purposes only.
			/// </para>
			/// </summary>
			public uint Line;
		}

		/// <summary>The <c>SOURCE_MEDIA</c> structure is used with the SPFILENOTIFY_NEEDMEDIA notification to pass source media information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-source_media_a typedef struct _SOURCE_MEDIA_A { PCSTR
		// Reserved; PCSTR Tagfile; PCSTR Description; PCSTR SourcePath; PCSTR SourceFile; DWORD Flags; } SOURCE_MEDIA_A, *PSOURCE_MEDIA_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SOURCE_MEDIA_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SOURCE_MEDIA
		{
			/// <summary>This member is not currently used.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Reserved;

			/// <summary>Optional tag file that can be used to identify the source media.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Tagfile;

			/// <summary>Human-readable description of the source media.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Description;

			/// <summary>Path to the source that needs the new media.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourcePath;

			/// <summary>Source file to be retrieved from the new media.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourceFile;

			/// <summary>
			/// <para>Copy style information that modifies how errors are handled. This member can be one or more of the following values.</para>
			/// <para>SP_COPY_WARNIFSKIP</para>
			/// <para>Inform the user that skipping the file may affect the installation.</para>
			/// <para>SP_COPY_NOSKIP</para>
			/// <para>Do not offer the user the option to skip the file.</para>
			/// <para>SP_FLAG_CABINETCONTINUATION</para>
			/// <para>The current source file is continued in another cabinet file.</para>
			/// <para>SP_COPY_NOBROWSE</para>
			/// <para>Do not offer the user the option to browse.</para>
			/// </summary>
			public CopyStyle Flags;
		}

		/// <summary>
		/// <para>This structure is used to pass information for an alternate platform to SetupQueryInfOriginalFileInformation.</para>
		/// <para>
		/// Setup implicitly uses the <c>SP_ALTPLATFORM_INFO_V1</c> structure if USE_SP_ALTPLATFORM_INFO_V1 is set to 1 or if _WIN32_WINNT
		/// is less than or equal to 0x500. This version is for use with Windows 2000.
		/// </para>
		/// <para>
		/// Setup implicitly uses the SP_ALTPLATFORM_INFO_V2 structure if USE_SP_ALTPLATFORM_INFO_V1 is 0 or undefined and _WIN32_WINNT is
		/// set to 0x501.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_altplatform_info_v1 typedef struct
		// _SP_ALTPLATFORM_INFO_V1 { DWORD cbSize; DWORD Platform; DWORD MajorVersion; DWORD MinorVersion; WORD ProcessorArchitecture; WORD
		// Reserved; } SP_ALTPLATFORM_INFO_V1, *PSP_ALTPLATFORM_INFO_V1;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_ALTPLATFORM_INFO_V1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_ALTPLATFORM_INFO_V1
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>Operating system. This must be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_WINDOWS</term>
			/// <term>Legacy operating systems.</term>
			/// </item>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_NT</term>
			/// <term>Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, or Windows 2000.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PlatformID Platform;

			/// <summary>Major version of the operating system.</summary>
			public uint MajorVersion;

			/// <summary>Minor version of the operating system.</summary>
			public uint MinorVersion;

			/// <summary>
			/// Processor architecture. This must be PROCESSOR_ARCHITECTURE_INTEL, PROCESSOR_ARCHITECTURE_ALPHA,
			/// PROCESSOR_ARCHITECTURE_IA64, PROCESSOR_ARCHITECTURE_ALPHA64.
			/// </summary>
			public ProcessorArchitecture ProcessorArchitecture;

			/// <summary>Must be set to zero.</summary>
			public ushort Reserved;
		}

		/// <summary>
		/// <para>The <c>SP_ALTPLATFORM_INFO_V2</c> structure is used to pass information for an alternate platform to SetupQueryInfOriginalFileInformation.</para>
		/// <para>
		/// Setup uses the <c>SP_ALTPLATFORM_INFO_V2</c> structure if USE_SP_ALTPLATFORM_INFO_V1 is 0 or undefined and _WIN32_WINNT is set
		/// to 0x501. <c>FirstValidatedMajorVersion</c> and <c>FirstValidatedMinorVersion</c> are only available with
		/// <c>SP_ALTPLATFORM_INFO_V2</c> and for use with Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP.
		/// </para>
		/// <para>
		/// Setup uses the SP_ALTPLATFORM_INFO_V1 structure if USE_SP_ALTPLATFORM_INFO_V1 is set to 1 or if _WIN32_WINNT is less than or
		/// equal to 0x500. <c>FirstValidatedMajorVersion</c> and <c>FirstValidatedMinorVersion</c> are not available with <c>SP_ALTPLATFORM_INFO_V1</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_altplatform_info_v2 typedef struct
		// _SP_ALTPLATFORM_INFO_V2 { DWORD cbSize; DWORD Platform; DWORD MajorVersion; DWORD MinorVersion; WORD ProcessorArchitecture; union
		// { WORD Reserved; WORD Flags; } DUMMYUNIONNAME; DWORD FirstValidatedMajorVersion; DWORD FirstValidatedMinorVersion; }
		// SP_ALTPLATFORM_INFO_V2, *PSP_ALTPLATFORM_INFO_V2;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_ALTPLATFORM_INFO_V2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_ALTPLATFORM_INFO_V2
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>Operating system. This member must be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_WINDOWS</term>
			/// <term>Legacy operating systems.</term>
			/// </item>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_NT</term>
			/// <term>Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, or Windows 2000.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PlatformID Platform;

			/// <summary>Major version of the operating system.</summary>
			public uint MajorVersion;

			/// <summary>Minor version of the operating system.</summary>
			public uint MinorVersion;

			/// <summary>
			/// Processor architecture. This must be PROCESSOR_ARCHITECTURE_INTEL, PROCESSOR_ARCHITECTURE_ALPHA,
			/// PROCESSOR_ARCHITECTURE_IA64, PROCESSOR_ARCHITECTURE_ALPHA64.
			/// </summary>
			public ProcessorArchitecture ProcessorArchitecture;

			/// <summary>
			/// For Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP, this member must be set to
			/// SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMajorVersion</c> and <c>FirstValidatedMinorVersion</c>. This
			/// member must be set to zero for Windows 2000.
			/// </summary>
			public ushort Flags;

			/// <summary>
			/// Major version of the oldest previous operating system for which this package's digital signature is valid. For example, if
			/// the alternate platform is VER_PLATFORM_WIN32_NT, version 5.1, and you want a driver package signed with a 5.0 osattr to also
			/// be valid, set MajorVersion to 5, MinorVersion to 1, <c>FirstValidatedMajorVersion</c> to 5, and
			/// <c>FirstValidatedMinorVersion</c> 0. To validate packages signed for any previous operating system, specify 0 for these
			/// fields. To only validate against the target alternate platform, specify the same values as those in the MajorVersion and
			/// MinorVersion fields. Available with Windows XP or later only. The Flags member must be set to
			/// SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMajorVersion</c>.
			/// </summary>
			public uint FirstValidatedMajorVersion;

			/// <summary>
			/// Minor version of the oldest previous operating system for which this package's digital signature is valid. For information
			/// see <c>FirstValidatedMajorVersion</c>. Available with Windows Server 2003 or Windows XP. The <c>Flags</c> member must be set
			/// to SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMinorVersion</c>.
			/// </summary>
			public uint FirstValidatedMinorVersion;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("setupapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_ALTPLATFORM_INFO_V3
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>Operating system. This member must be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_WINDOWS</term>
			/// <term>Legacy operating systems.</term>
			/// </item>
			/// <item>
			/// <term>VER_PLATFORM_WIN32_NT</term>
			/// <term>Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, or Windows 2000.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PlatformID Platform;

			/// <summary>Major version of the operating system.</summary>
			public uint MajorVersion;

			/// <summary>Minor version of the operating system.</summary>
			public uint MinorVersion;

			/// <summary>
			/// Processor architecture. This must be PROCESSOR_ARCHITECTURE_INTEL, PROCESSOR_ARCHITECTURE_ALPHA,
			/// PROCESSOR_ARCHITECTURE_IA64, PROCESSOR_ARCHITECTURE_ALPHA64.
			/// </summary>
			public ProcessorArchitecture ProcessorArchitecture;

			/// <summary>
			/// For Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP, this member must be set to
			/// SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMajorVersion</c> and <c>FirstValidatedMinorVersion</c>. This
			/// member must be set to zero for Windows 2000.
			/// </summary>
			public ushort Flags;

			/// <summary>
			/// Major version of the oldest previous operating system for which this package's digital signature is valid. For example, if
			/// the alternate platform is VER_PLATFORM_WIN32_NT, version 5.1, and you want a driver package signed with a 5.0 osattr to also
			/// be valid, set MajorVersion to 5, MinorVersion to 1, <c>FirstValidatedMajorVersion</c> to 5, and
			/// <c>FirstValidatedMinorVersion</c> 0. To validate packages signed for any previous operating system, specify 0 for these
			/// fields. To only validate against the target alternate platform, specify the same values as those in the MajorVersion and
			/// MinorVersion fields. Available with Windows XP or later only. The Flags member must be set to
			/// SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMajorVersion</c>.
			/// </summary>
			public uint FirstValidatedMajorVersion;

			/// <summary>
			/// Minor version of the oldest previous operating system for which this package's digital signature is valid. For information
			/// see <c>FirstValidatedMajorVersion</c>. Available with Windows Server 2003 or Windows XP. The <c>Flags</c> member must be set
			/// to SP_ALTPLATFORM_FLAGS_VERSION_RANGE to use <c>FirstValidatedMinorVersion</c>.
			/// </summary>
			public uint FirstValidatedMinorVersion;

			/// <summary>
			/// specify non-zero value (e.g. VER_NT_WORKSTATION) in ProductType to use field, and/or specify SP_ALTPLATFORM_FLAGS_SUITE_MASK
			/// in Flags to use SuiteMask field, which may be zero.
			/// <para>
			/// Product type and suite mask of alternate platform. Used to select matching decorated install sections within driver packages
			/// that target specific product variants of the OS. For example, for only Server products with the Enterprise or Small Business
			/// suite classification, use ProductType VER_NT_SERVER with SuiteMask VER_SUITE_ENTERPRISE and VER_SUITE_SMALLBUSINESS.
			/// </para>
			/// </summary>
			public byte ProductType;

			/// <summary>
			/// specify non-zero value (e.g. VER_NT_WORKSTATION) in ProductType to use field, and/or specify SP_ALTPLATFORM_FLAGS_SUITE_MASK
			/// in Flags to use SuiteMask field, which may be zero.
			/// <para>
			/// Product type and suite mask of alternate platform. Used to select matching decorated install sections within driver packages
			/// that target specific product variants of the OS. For example, for only Server products with the Enterprise or Small Business
			/// suite classification, use ProductType VER_NT_SERVER with SuiteMask VER_SUITE_ENTERPRISE and VER_SUITE_SMALLBUSINESS.
			/// </para>
			/// </summary>
			public ushort SuiteMask;

			/// <summary>
			/// Build number of alternate platform. Used to select matching decorated install sections within driver packages that target a
			/// minimal build number with the specified OS MajorVersion/MinorVersion. If no specific minimal build number targeting is
			/// required, a value of zero should be specified. Note that this capability is only supported on certain builds of 10.0 and later.
			/// </summary>
			public uint BuildNumber;
		}

		/// <summary>An SP_CLASSIMAGELIST_DATA structure describes a class image list.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_classimagelist_data typedef struct
		// _SP_CLASSIMAGELIST_DATA { DWORD cbSize; HIMAGELIST ImageList; ULONG_PTR Reserved; } SP_CLASSIMAGELIST_DATA, *PSP_CLASSIMAGELIST_DATA;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_CLASSIMAGELIST_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_CLASSIMAGELIST_DATA
		{
			/// <summary>The size, in bytes, of the SP_CLASSIMAGE_DATA structure.</summary>
			public uint cbSize;

			/// <summary>A handle to the class image list.</summary>
			public HIMAGELIST ImageList;

			/// <summary>Reserved. For internal use only.</summary>
			public IntPtr Reserved;
		}

		// SuiteMask
		/// <summary>
		/// An SP_CLASSINSTALL_HEADER is the first member of any class install parameters structure. It contains the device installation
		/// request code that defines the format of the rest of the install parameters structure.
		/// </summary>
		/// <remarks>
		/// <para>
		/// When a component allocates a class install parameters structure, it typically initializes the header fields of the structure.
		/// Such a component sets the <c>InstallFunction</c> member to the DIF code for the installation request and sets <c>cbSize</c> to
		/// the size of the SP_CLASSINSTALL_HEADER structure. For example:
		/// </para>
		/// <para>
		/// <code>SP_REMOVEDEVICE_PARAMS RemoveDeviceParams; RemoveDeviceParams.ClassInstallHeader.cbSize = sizeof(SP_CLASSINSTALL_HEADER); RemoveDeviceParams.ClassInstallHeader.InstallFunction = DIF_REMOVE;</code>
		/// </para>
		/// <para>A component must set the <c>InstallFunction</c> member before passing a class install parameters structure to SetupDiSetClassInstallParams.</para>
		/// <para>
		/// However, a component does not have to set this field when passing class install parameters to SetupDiGetClassInstallParams. This
		/// function sets the <c>InstallFunction</c> member in the structure it passes back to the caller. It sets <c>InstallFunction</c> to
		/// the DIF_XXX code for the currently active device installation request.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_classinstall_header typedef struct
		// _SP_CLASSINSTALL_HEADER { DWORD cbSize; DI_FUNCTION InstallFunction; } SP_CLASSINSTALL_HEADER, *PSP_CLASSINSTALL_HEADER;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_CLASSINSTALL_HEADER")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_CLASSINSTALL_HEADER
		{
			/// <summary>The size, in bytes, of the SP_CLASSINSTALL_HEADER structure.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>The device installation request (DIF code) for the class install parameters structure.</para>
			/// <para>
			/// DIF codes have the format DIF_XXX and are defined in Setupapi.h. See Device Installation Function Codes for a complete
			/// description of DIF codes.
			/// </para>
			/// </summary>
			public DI_FUNCTION InstallFunction;
		}

		/// <summary>An SP_DETECTDEVICE_PARAMS structure corresponds to a DIF_DETECT installation request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_detectdevice_params typedef struct
		// _SP_DETECTDEVICE_PARAMS { SP_CLASSINSTALL_HEADER ClassInstallHeader; PDETECT_PROGRESS_NOTIFY DetectProgressNotify; PVOID
		// ProgressNotifyParam; } SP_DETECTDEVICE_PARAMS, *PSP_DETECTDEVICE_PARAMS;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DETECTDEVICE_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_DETECTDEVICE_PARAMS
		{
			/// <summary>An install request header that contains the size of the header and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// A callback routine that displays a progress bar for the device detection operation. The callback routine is supplied by the
			/// device installation component that sends the DIF_DETECT request.
			/// </summary>
			public PDETECT_PROGRESS_NOTIFY DetectProgressNotify;

			/// <summary>The opaque <c>ProgressNotifyParam</c> "handle" that the class installer passes to the progress callback routine.</summary>
			public IntPtr ProgressNotifyParam;
		}

		/// <summary>An SP_DEVICE_INTERFACE_DATA structure defines a device interface in a device information set.</summary>
		/// <remarks>
		/// A SetupAPI function that takes an instance of the SP_DEVICE_INTERFACE_DATA structure as a parameter verifies whether the
		/// <c>cbSize</c> member of the supplied structure is equal to the size, in bytes, of the structure. If the <c>cbSize</c> member is
		/// not set correctly, the function will fail and set an error code of ERROR_INVALID_USER_BUFFER.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_data typedef struct
		// _SP_DEVICE_INTERFACE_DATA { DWORD cbSize; GUID InterfaceClassGuid; DWORD Flags; ULONG_PTR Reserved; } SP_DEVICE_INTERFACE_DATA, *PSP_DEVICE_INTERFACE_DATA;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVICE_INTERFACE_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_DEVICE_INTERFACE_DATA
		{
			/// <summary>The size, in bytes, of the SP_DEVICE_INTERFACE_DATA structure. For more information, see the Remarks section.</summary>
			public uint cbSize;

			/// <summary>The GUID for the class to which the device interface belongs.</summary>
			public Guid InterfaceClassGuid;

			/// <summary>
			/// <para>Can be one or more of the following:</para>
			/// <para>SPINT_ACTIVE</para>
			/// <para>The interface is active (enabled).</para>
			/// <para>SPINT_DEFAULT</para>
			/// <para>The interface is the default interface for the device class.</para>
			/// <para>SPINT_REMOVED</para>
			/// <para>The interface is removed.</para>
			/// </summary>
			public SPINT Flags;

			/// <summary>Reserved. Do not use.</summary>
			public UIntPtr Reserved;
		}

		/// <summary>An SP_DEVICE_INTERFACE_DETAIL_DATA structure contains the path for a device interface.</summary>
		/// <remarks>
		/// <para>An SP_DEVICE_INTERFACE_DETAIL_DATA structure identifies the path for a device interface in a device information set.</para>
		/// <para>
		/// <c>SetupDi</c> Xxx functions that take an SP_DEVICE_INTERFACE_DETAIL_DATA structure as a parameter verify that the <c>cbSize</c>
		/// member of the supplied structure is equal to the size, in bytes, of the structure. If the <c>cbSize</c> member is not set
		/// correctly for an input parameter, the function will fail and set an error code of ERROR_INVALID_PARAMETER. If the <c>cbSize</c>
		/// member is not set correctly for an output parameter, the function will fail and set an error code of ERROR_INVALID_USER_BUFFER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_detail_data_a typedef struct
		// _SP_DEVICE_INTERFACE_DETAIL_DATA_A { DWORD cbSize; CHAR DevicePath[ANYSIZE_ARRAY]; } SP_DEVICE_INTERFACE_DETAIL_DATA_A, *PSP_DEVICE_INTERFACE_DETAIL_DATA_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVICE_INTERFACE_DETAIL_DATA_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			/// <summary>
			/// The size, in bytes, of the SP_DEVICE_INTERFACE_DETAIL_DATA structure. For more information, see the following Remarks section.
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// A NULL-terminated string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
			/// </summary>
			public char DevicePath;

			/// <summary>A default value for this structure with the <see cref="cbSize"/> value set appropriately.</summary>
			public static readonly SP_DEVICE_INTERFACE_DETAIL_DATA Default = new SP_DEVICE_INTERFACE_DETAIL_DATA { cbSize = IntPtr.Size == 4 ? 4U + (uint)Marshal.SystemDefaultCharSize : 8U };
		}

		/// <summary>An SP_DEVINFO_DATA structure defines a device instance that is a member of a device information set.</summary>
		/// <remarks>
		/// <para>
		/// An SP_DEVINFO_DATA structure identifies a device in a device information set. For example, when Windows sends a
		/// DIF_INSTALLDEVICE request to a class installer and co-installers, it includes a handle to a device information set and a pointer
		/// to an SP_DEVINFO_DATA that specifies the particular device. In addition to DIF requests, this structure is also used in some
		/// <c>SetupDi</c> Xxx functions.
		/// </para>
		/// <para>
		/// <c>SetupDi</c> Xxx functions that take an SP_DEVINFO_DATA structure as a parameter verify that the <c>cbSize</c> member of the
		/// supplied structure is equal to the size, in bytes, of the structure. If the <c>cbSize</c> member is not set correctly for an
		/// input parameter, the function will fail and set an error code of ERROR_INVALID_PARAMETER. If the <c>cbSize</c> member is not set
		/// correctly for an output parameter, the function will fail and set an error code of ERROR_INVALID_USER_BUFFER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_devinfo_data typedef struct _SP_DEVINFO_DATA { DWORD
		// cbSize; GUID ClassGuid; DWORD DevInst; ULONG_PTR Reserved; } SP_DEVINFO_DATA, *PSP_DEVINFO_DATA;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVINFO_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_DEVINFO_DATA
		{
			/// <summary>The size, in bytes, of the SP_DEVINFO_DATA structure. For more information, see the following Remarks section.</summary>
			public uint cbSize;

			/// <summary>The GUID of the device's setup class.</summary>
			public Guid ClassGuid;

			/// <summary>
			/// <para>An opaque handle to the device instance (also known as a handle to the devnode).</para>
			/// <para>
			/// Some functions, such as <c>SetupDi</c> Xxx functions, take the whole SP_DEVINFO_DATA structure as input to identify a device
			/// in a device information set. Other functions, such as <c>CM</c> _Xxx functions like CM_Get_DevNode_Status, take this
			/// <c>DevInst</c> handle as input.
			/// </para>
			/// </summary>
			public uint DevInst;

			/// <summary>Reserved. For internal use only.</summary>
			public IntPtr Reserved;
		}

		/// <summary>
		/// An SP_DEVINFO_LIST_DETAIL_DATA structure contains information about a device information set, such as its associated setup class
		/// GUID (if it has an associated setup class).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_devinfo_list_detail_data_w typedef struct
		// _SP_DEVINFO_LIST_DETAIL_DATA_W { DWORD cbSize; GUID ClassGuid; HANDLE RemoteMachineHandle; WCHAR
		// RemoteMachineName[SP_MAX_MACHINENAME_LENGTH]; } SP_DEVINFO_LIST_DETAIL_DATA_W, *PSP_DEVINFO_LIST_DETAIL_DATA_W;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVINFO_LIST_DETAIL_DATA_W")]
#if x64
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
#else
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
#endif
		public struct SP_DEVINFO_LIST_DETAIL_DATA
		{
			/// <summary>The size, in bytes, of the SP_DEVINFO_LIST_DETAIL_DATA structure.</summary>
			public uint cbSize;

			/// <summary>
			/// The setup class GUID that is associated with the device information set or GUID_NULL if there is no associated setup class.
			/// </summary>
			public Guid ClassGuid;

			/// <summary>
			/// <para>
			/// If the device information set is for a remote computer, this member is a configuration manager machine handle for the remote
			/// computer. If the device information set is for the local computer, this member is <c>NULL</c>.
			/// </para>
			/// <para>
			/// This is typically the parameter that components use to access the remote computer. The <c>RemoteMachineName</c> contains a
			/// string, in case the component requires the name of the remote computer.
			/// </para>
			/// </summary>
			public HANDLE RemoteMachineHandle;

			/// <summary>
			/// A NULL-terminated string that contains the name of the remote computer. If the device information set is for the local
			/// computer, this member is an empty string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SP_MAX_MACHINENAME_LENGTH)]
			public string RemoteMachineName;
		}

		/// <summary>
		/// An SP_DEVINSTALL_PARAMS structure contains device installation parameters associated with a particular device information
		/// element or associated globally with a device information set.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_devinstall_params_a typedef struct
		// _SP_DEVINSTALL_PARAMS_A { DWORD cbSize; DWORD Flags; DWORD FlagsEx; HWND hwndParent; PSP_FILE_CALLBACK InstallMsgHandler; PVOID
		// InstallMsgHandlerContext; HSPFILEQ FileQueue; ULONG_PTR ClassInstallReserved; DWORD Reserved; CHAR DriverPath[MAX_PATH]; }
		// SP_DEVINSTALL_PARAMS_A, *PSP_DEVINSTALL_PARAMS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVINSTALL_PARAMS_A")]
#if x64
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
#else
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
#endif
		public struct SP_DEVINSTALL_PARAMS
		{
			/// <summary>The size, in bytes, of the SP_DEVINSTALL_PARAMS structure.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>
			/// Flags that control installation and user interface operations. Some flags can be set before sending the device installation
			/// request while other flags are set automatically during the processing of some requests. <c>Flags</c> can be a combination of
			/// the following values.
			/// </para>
			/// <para>
			/// The flag values are listed in groups: writable by device installation applications and installers, read-only (only set by
			/// the OS), reserved, and obsolete. The first group lists flags that are writable:
			/// </para>
			/// <para>DI_CLASSINSTALLPARAMS</para>
			/// <para>
			/// Set to use the Class Install parameters. SetupDiSetClassInstallParams sets this flag when the caller specifies parameters
			/// and clears the flag when the caller specifies a <c>NULL</c> parameters pointer.
			/// </para>
			/// <para>DI_COMPAT_FROM_CLASS</para>
			/// <para>
			/// Set to force SetupDiBuildDriverInfoList to build a device's list of compatible drivers from its class driver list instead of
			/// the INF file.
			/// </para>
			/// <para>DI_DRIVERPAGE_ADDED</para>
			/// <para>
			/// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied driver
			/// properties page. If this flag is set, the operating system does not display the system-supplied driver page.
			/// </para>
			/// <para>DI_DONOTCALLCONFIGMG</para>
			/// <para>
			/// Set if the configuration manager should not be called to remove or reenumerate devices during the execution of certain
			/// device installation functions (for example, SetupDiInstallDevice).
			/// </para>
			/// <para>
			/// If this flag is set, device installation applications, class installers, and co-installers must not call the following functions:
			/// </para>
			/// <para>
			/// CM_Reenumerate_DevNode CM_Reenumerate_DevNode_Ex CM_Query_And_Remove_SubTree CM_Query_And_Remove_SubTree_Ex CM_Setup_DevNode
			/// CM_Setup_DevNode_Ex CM_Set_HW_Prof_Flags CM_Set_HW_Prof_Flags_Ex CM_Enable_DevNode CM_Enable_DevNode_Ex CM_Disable_DevNode CM_Disable_DevNode_Ex
			/// </para>
			/// <para>DI_ENUMSINGLEINF</para>
			/// <para>
			/// Set if installers and other device installation components should only search the INF file specified by
			/// SP_DEVINSTALL_PARAMS. <c>DriverPath</c>. If this flag is set, <c>DriverPath</c> contains the path of a single INF file
			/// instead of a path of a directory.
			/// </para>
			/// <para>DI_INF_IS_SORTED</para>
			/// <para>
			/// Set to indicate that the Select Device page should list drivers in the order in which they appear in the INF file, instead
			/// of sorting them alphabetically.
			/// </para>
			/// <para>DI_INSTALLDISABLED</para>
			/// <para>
			/// Set if the device should be installed in a disabled state by default. To be recognized, this flag must be set before Windows
			/// calls the default handler for the DIF_INSTALLDEVICE request.
			/// </para>
			/// <para>DI_NEEDREBOOT</para>
			/// <para>
			/// For NT-based operating systems, this flag is set if the device requires that the computer be restarted after device
			/// installation or a device state change. A class installer or co-installer can set this flag at any time during device
			/// installation, if the installer determines that a restart is necessary.
			/// </para>
			/// <para>DI_NEEDRESTART</para>
			/// <para>The same as DI_NEEDREBOOT.</para>
			/// <para>DI_NOBROWSE</para>
			/// <para>
			/// Set to disable browsing when the user is selecting an OEM disk path. A device installation application sets this flag to
			/// constrain a user to only installing from the installation media location.
			/// </para>
			/// <para>DI_NODI_DEFAULTACTION</para>
			/// <para>
			/// Set if SetupDiCallClassInstaller should not perform any default action if the class installer returns ERR_DI_DO_DEFAULT or
			/// there is not a class installer.
			/// </para>
			/// <para>DI_NOFILECOPY</para>
			/// <para>Set if device installation applications and components, such as SetupDiInstallDevice, should skip file copying.</para>
			/// <para>DI_NOVCP</para>
			/// <para>Set to disable creation of a new copy queue. Use the caller-supplied copy queue in SP_DEVINSTALL_PARAMS. <c>FileQueue</c>.</para>
			/// <para>DI_NOWRITE_IDS</para>
			/// <para>
			/// Set to prevent SetupDiInstallDevice from writing the INF-specified hardware IDs and compatible IDs to the device properties
			/// for the device node (devnode). This flag should only be set for root-enumerated devices.
			/// </para>
			/// <para>This flag overrides the DI_FLAGSEX_ALWAYSWRITEIDS flag.</para>
			/// <para>DI_PROPERTIES_CHANGE</para>
			/// <para>Set by Device Manager if a device's properties were changed, which requires an update of the installer's user interface.</para>
			/// <para>DI_QUIETINSTALL</para>
			/// <para>
			/// Set if the device installer functions must be silent and use default choices wherever possible. Class installers and
			/// co-installers must not display any UI if this flag is set.
			/// </para>
			/// <para>DI_RESOURCEPAGE_ADDED</para>
			/// <para>
			/// Set by a class installer or co-installer if the installer supplies a page that replaces the system-supplied resource
			/// properties page. If this flag is set, the operating system does not display the system-supplied resource page.
			/// </para>
			/// <para>DI_SHOWOEM</para>
			/// <para>
			/// Set to allow support for OEM disks. If this flag is set, the operating system presents a "Have Disk" button on the Select
			/// Device page. This flag is set, by default, in system-supplied wizards.
			/// </para>
			/// <para>DI_USECI_SELECTSTRINGS</para>
			/// <para>Set if a class installer or co-installer supplied strings that should be used during SetupDiSelectDevice.</para>
			/// <para>The following flags are read-only (only set by the OS):</para>
			/// <para>DI_DIDCLASS</para>
			/// <para>
			/// Set if SetupDiBuildDriverInfoList has already built a list of the drivers for this class of device. If this list has already
			/// been built, it contains all the driver information and this flag is always set. SetupDiDestroyDriverInfoList clears this
			/// flag when it deletes a list of drivers for a class.
			/// </para>
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// <para>DI_DIDCOMPAT</para>
			/// <para>
			/// Set if SetupDiBuildDriverInfoList has already built a list of compatible drivers for this device. If this list has already
			/// been built, it contains all the driver information and this flag is always set. SetupDiDestroyDriverInfoList clears this
			/// flag when it deletes a compatible driver list.
			/// </para>
			/// <para>
			/// This flag is only set in device installation parameters that are associated with a particular device information element,
			/// not in parameters for a device information set as a whole.
			/// </para>
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// <para>DI_MULTMFGS</para>
			/// <para>
			/// Set by SetupDiBuildDriverInfoList if a list of drivers for a device setup class contains drivers that are provided by
			/// multiple manufacturers.
			/// </para>
			/// <para>This flag is read-only. Only the operating system sets this flag.</para>
			/// <para>The following flags are reserved:</para>
			/// <para>DI_AUTOASSIGNRES</para>
			/// <para>DI_DISABLED</para>
			/// <para>DI_FORCECOPY</para>
			/// <para>DI_GENERALPAGE_ADDED</para>
			/// <para>DI_OVERRIDE_INFFLAGS</para>
			/// <para>DI_SHOWALL</para>
			/// <para>DI_SHOWCLASS</para>
			/// <para>DI_SHOWCOMPAT</para>
			/// <para>The following flags are obsolete:</para>
			/// <para>DI_NOSELECTICONS</para>
			/// <para>DI_PROPS_NOCHANGEUSAGE</para>
			/// </summary>
			public DI_FLAGS Flags;

			/// <summary>
			/// <para>
			/// Additional flags that provide control over installation and user interface operations. Some flags can be set before calling
			/// the device installer functions while other flags are set automatically during the processing of some functions.
			/// <c>FlagsEx</c> can be a combination of the following values.
			/// </para>
			/// <para>
			/// The flag values are listed in groups: writable by device installation applications and installers, read-only (only set by
			/// the OS), reserved, and obsolete.
			/// </para>
			/// <para>The first group lists flags that are writable:</para>
			/// <para>DI_FLAGSEX_ALLOWEXCLUDEDDRVS</para>
			/// <para>If set, include drivers that were marked "Exclude From Select."</para>
			/// <para>
			/// For example, if this flag is set, SetupDiSelectDevice displays drivers that have the Exclude From Select state and
			/// SetupDiBuildDriverInfoList includes Exclude From Select drivers in the requested driver list.
			/// </para>
			/// <para>
			/// A driver is "Exclude From Select" if either it is marked <c>ExcludeFromSelect</c> in the INF file or it is a driver for a
			/// device whose whole setup class is marked <c>NoInstallClass</c> or <c>NoUseClass</c> in the class installer INF. Drivers for
			/// PnP devices are typically "Exclude From Select"; PnP devices should not be manually installed. To build a list of driver
			/// files for a PnP device a caller of <c>SetupDiBuildDriverInfoList</c> must set this flag.
			/// </para>
			/// <para>DI_FLAGSEX_ALWAYSWRITEIDS</para>
			/// <para>
			/// If set and the DI_NOWRITE_IDS flag is clear, always write hardware and compatible IDs to the device properties for the
			/// devnode. This flag should only be set for root-enumerated devices.
			/// </para>
			/// <para>DI_FLAGSEX_APPENDDRIVERLIST</para>
			/// <para>
			/// If set, <c>SetupDiBuildDriverInfoList</c> appends a new driver list to an existing list. This flag is relevant when
			/// searching multiple locations.
			/// </para>
			/// <para>DI_FLAGSEX_DRIVERLIST_FROM_URL</para>
			/// <para>
			/// If set, build the driver list from INF(s) retrieved from the URL that is specified in SP_DEVINSTALL_PARAMS.
			/// <c>DriverPath</c>. If the <c>DriverPath</c> is an empty string, use the Windows Update website.
			/// </para>
			/// <para>
			/// Currently, the operating system does not support URLs. Use this flag to direct <c>SetupDiBuildDriverInfoList</c> to search
			/// the Windows Update website.
			/// </para>
			/// <para>Do not set this flag if DI_QUIETINSTALL is set.</para>
			/// <para>DI_FLAGSEX_EXCLUDE_OLD_INET_DRIVERS</para>
			/// <para>
			/// If set, do not include old Internet drivers when building a driver list. This flag should be set any time that you are
			/// building a list of potential drivers for a device. You can clear this flag if you are just getting a list of drivers
			/// currently installed for a device.
			/// </para>
			/// <para>DI_FLAGSEX_FILTERCLASSES</para>
			/// <para>
			/// If set, SetupDiBuildClassInfoList will check for class inclusion filters. This means that a device will not be included in
			/// the class list if its class is marked as NoInstallClass.
			/// </para>
			/// <para>DI_FLAGSEX_FILTERSIMILARDRIVERS</para>
			/// <para>
			/// (Windows XP and later.) If set, SetupDiBuildDriverInfoList includes "similar" drivers when building a class driver list. A
			/// "similar" driver is one for which one of the hardware IDs or compatible IDs in the INF file partially (or completely)
			/// matches one of the hardware IDs or compatible IDs of the hardware.
			/// </para>
			/// <para>DI_FLAGSEX_INET_DRIVER</para>
			/// <para>
			/// If set, the driver was obtained from the Internet. Windows will not use the device's INF to install future devices because
			/// Windows cannot guarantee that it can retrieve the driver files again from the Internet.
			/// </para>
			/// <para>DI_FLAGSEX_INSTALLEDDRIVER</para>
			/// <para>
			/// (Windows XP and later.) If set, SetupDiBuildDriverInfoList includes only the currently installed driver when creating a list
			/// of class drivers or device-compatible drivers.
			/// </para>
			/// <para>DI_FLAGSEX_NO_DRVREG_MODIFY</para>
			/// <para>
			/// Do not process the <c>AddReg</c> and <c>DelReg</c> entries for the device's hardware and software (driver) keys. That is,
			/// the <c>AddReg</c> and <c>DelReg</c> entries in the INF file DDInstall and DDInstall <c>.HW</c> sections.
			/// </para>
			/// <para>DI_FLAGSEX_POWERPAGE_ADDED</para>
			/// <para>
			/// If set, an installer added their own page for the power properties dialog. The operating system will not display the
			/// system-supplied power properties page. This flag is only relevant if the device supports power management.
			/// </para>
			/// <para>DI_FLAGSEX_PROPCHANGE_PENDING</para>
			/// <para>
			/// If set, the user made changes to one or more device property sheets. The property-page provider typically sets this flag.
			/// </para>
			/// <para>
			/// When the user closes the device property sheet, Device Manager checks the DI_FLAGSEX_PROPCHANGE_PENDING flag. If it is set,
			/// Device Manager clears this flag, sets the DI_PROPERTIES_CHANGE flag, and sends a DIF_PROPERTYCHANGE request to the
			/// installers to notify them that something has changed.
			/// </para>
			/// <para>DI_FLAGSEX_SETFAILEDINSTALL</para>
			/// <para>
			/// Set if the installation failed. If this flag is set, the SetupDiInstallDevice function just sets the FAILEDINSTALL flag in
			/// the device's <c>ConfigFlags</c> registry value. If DI_FLAGSEX_SETFAILEDINSTALL is set, co-installers must return NO_ERROR in
			/// response to DIF_INSTALLDEVICE, while class installers must return NO_ERROR or ERROR_DI_DO_DEFAULT.
			/// </para>
			/// <para>DI_FLAGSEX_USECLASSFORCOMPAT</para>
			/// <para>
			/// Filter INF files on the device's setup class when building a list of compatible drivers. If a device's setup class is known,
			/// setting this flag reduces the time that is required to build a list of compatible drivers when searching INF files that are
			/// not precompiled. This flag is ignored if DI_COMPAT_FROM_CLASS is set.
			/// </para>
			/// <para>The following flags are read-only; only the operating system sets these flags:</para>
			/// <para>DI_FLAGSEX_CI_FAILED</para>
			/// <para>Set by the operating system if a class installer failed to load or start. This flag is read-only.</para>
			/// <para>DI_FLAGSEX_DIDCOMPATINFO</para>
			/// <para>Windows has built a list of driver nodes that are compatible with the device. This flag is read-only.</para>
			/// <para>DI_FLAGSEX_DIDINFOLIST</para>
			/// <para>
			/// Windows has built a list of driver nodes that includes all the drivers that are listed in the INF files of the specified
			/// setup class. If the specified setup class is <c>NULL</c> because the HDEVINFO set or device has no associated class, the
			/// list includes all driver nodes from all available INF files. This flag is read-only.
			/// </para>
			/// <para>DI_FLAGSEX_IN_SYSTEM_SETUP</para>
			/// <para>If set, installation is occurring during initial system setup. This flag is read-only.</para>
			/// <para>The following flags are reserved:</para>
			/// <para>DI_FLAGSEX_BACKUPONREPLACE</para>
			/// <para>DI_FLAGSEX_DEVICECHANGE</para>
			/// <para>DI_FLAGSEX_OLDINF_IN_CLASSLIST</para>
			/// <para>DI_FLAGSEX_PREINSTALLBACKUP</para>
			/// <para>DI_FLAGSEX_USEOLDINFSEARCH</para>
			/// <para>The following flags are obsolete:</para>
			/// <para>DI_FLAGSEX_AUTOSELECTRANK0</para>
			/// <para>DI_FLAGSEX_NOUIONQUERYREMOVE</para>
			/// </summary>
			public DI_FLAGSEX FlagsEx;

			/// <summary>Window handle that will own the user interface dialogs related to this device.</summary>
			public HWND hwndParent;

			/// <summary>
			/// Callback used to handle events during file copying. An installer can use a callback, for example, to perform special
			/// processing when committing a file queue.
			/// </summary>
			public PSP_FILE_CALLBACK InstallMsgHandler;

			/// <summary>Private data that is used by the <c>InstallMsgHandler</c> callback.</summary>
			public IntPtr InstallMsgHandlerContext;

			/// <summary>
			/// <para>A handle to a caller-supplied file queue where file operations should be queued but not committed.</para>
			/// <para>
			/// If you associate a file queue with a device information set (SetupDiSetDeviceInstallParams), you must disassociate the queue
			/// from the device information set before you delete the device information set. If you fail to disassociate the file queue,
			/// Windows cannot decrement its reference count on the device information set and cannot free the memory.
			/// </para>
			/// <para>This queue is only used if the DI_NOVCP flag is set, indicating that file operations should be enqueued but not committed.</para>
			/// </summary>
			public HSPFILEQ FileQueue;

			/// <summary>A pointer for class-installer data. Co-installers must not use this field.</summary>
			public IntPtr ClassInstallReserved;

			/// <summary>Reserved. For internal use only.</summary>
			public uint Reserved;

			/// <summary>This path is used by the SetupDiBuildDriverInfoList function.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string DriverPath;
		}

		/// <summary>
		/// An SP_DRVINFO_DATA structure contains information about a driver. This structure is a member of a driver information list that
		/// can be associated with a particular device instance or globally with a device information set.
		/// </summary>
		/// <remarks>
		/// <para>
		/// In SetupAPI.h, this structure equates to either SP_DRVINFO_DATA_V1 or SP_DRVINFO_DATA_V2, based on whether you include the
		/// following line in your source code:
		/// </para>
		/// <para>
		/// <code>#define USE_SP_DRVINFO_DATA_V1 1</code>
		/// </para>
		/// <para>
		/// Define this identifier only if your component must run on Windows 98 or Millennium Edition, or on Windows NT. If your component
		/// is run only in Windows 2000 and later versions of Windows, do not define the identifier. If the identifier is not defined,
		/// SP_DRVINFO_DATA_V2 is used.
		/// </para>
		/// <para>SP_DRVINFO_DATA_V1 does not contain <c>DriverDate</c> and <c>DriverVersion</c> members.</para>
		/// <para>
		/// <c>SetupDi</c> Xxx functions that take an SP_DRVINFO_DATA structure as a parameter verify that the <c>cbSize</c> member of the
		/// supplied structure is equal to the size, in bytes, of the structure. If the <c>cbSize</c> member is not set correctly for an
		/// input parameter, the function will fail and set an error code of ERROR_INVALID_PARAMETER. If the <c>cbSize</c> member is not set
		/// correctly for an output parameter, the function will fail and set an error code of ERROR_INVALID_USER_BUFFER.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_drvinfo_data_v2_a typedef struct _SP_DRVINFO_DATA_V2_A
		// { DWORD cbSize; DWORD DriverType; ULONG_PTR Reserved; CHAR Description[LINE_LEN]; CHAR MfgName[LINE_LEN]; CHAR
		// ProviderName[LINE_LEN]; FILETIME DriverDate; DWORDLONG DriverVersion; } SP_DRVINFO_DATA_V2_A, *PSP_DRVINFO_DATA_V2_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DRVINFO_DATA_V2_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DRVINFO_DATA_V2
		{
			/// <summary>
			/// The size, in bytes, of the SP_DRVINFO_DATA structure. For more information, see the Remarks section in this topic.
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>The type of driver represented by this structure. Must be one of the following values:</para>
			/// <para>SPDIT_CLASSDRIVER</para>
			/// <para>This structure represents a class driver.</para>
			/// <para>SPDIT_COMPATDRIVER</para>
			/// <para>This structure represents a compatible driver.</para>
			/// </summary>
			public SPDIT DriverType;

			/// <summary>Reserved. For internal use only.</summary>
			public IntPtr Reserved;

			/// <summary>A NULL-terminated string that describes the device supported by this driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
			public string Description;

			/// <summary>A NULL-terminated string that contains the name of the manufacturer of the device supported by this driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
			public string MfgName;

			/// <summary>
			/// A NULL-terminated string giving the provider of this driver. This is typically the name of the organization that creates the
			/// driver or INF file. <c>ProviderName</c> can be an empty string.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
			public string ProviderName;

			/// <summary>
			/// Date of the driver. From the <c>DriverVer</c> entry in the INF file. See the INF DDInstall Section for more information
			/// about the <c>DriverVer</c> entry.
			/// </summary>
			public FILETIME DriverDate;

			/// <summary>Version of the driver. From the <c>DriverVer</c> entry in the INF file.</summary>
			public ulong DriverVersion;
		}

		/// <summary>An SP_DRVINFO_DETAIL_DATA structure contains detailed information about a particular driver information structure.</summary>
		/// <remarks>
		/// <para>The hardware ID and compatible IDs for a device are specified in the INF Models section in the following order:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The first ID (if specified) is the hardware ID for the device.</term>
		/// </item>
		/// <item>
		/// <term>The remaining IDs (if specified) are compatible IDs for the device.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When you parse the <c>HardwareID</c> buffer, you must ensure that you correctly determine the end of the data in the buffer. Be
		/// aware that the buffer is not necessarily double NULL terminated.
		/// </para>
		/// <para>
		/// For example, depending on how the list of hardware ID and compatible IDs are specified in the INF Models section, the
		/// <c>HardwareID</c> buffer can resemble any of the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>\0</term>
		/// </item>
		/// <item>
		/// <term>&lt;HWID&gt;\0</term>
		/// </item>
		/// <item>
		/// <term>&lt;HWID&gt;\0&lt;COMPATID_1&gt;\0...&lt;COMPATID_N&gt;\0\0</term>
		/// </item>
		/// <item>
		/// <term>\0&lt;COMPATID_1&gt;\0...&lt;COMPATID_N&gt;\0\0</term>
		/// </item>
		/// </list>
		/// <para>
		/// An algorithm to correctly parse this buffer must use the <c>CompatIDsOffset</c> and <c>CompatIDsLength</c> fields to extract the
		/// hardware ID and compatible IDs, as shown in the following code example:
		/// </para>
		/// <para>
		/// <code>// parse the hardware ID, if it exists if (CompatIDsOffset &gt; 1) { // Parse for hardware ID from index 0. // This is a single NULL-terminated string } // Parse the compatible IDs, if they exist if (CompatIDsLength &gt; 0) { // Parse for list of compatible IDs from CompatIDsOffset. // This is a double NULL-terminated list of strings (i.e. MULTI-SZ) }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_drvinfo_detail_data_a typedef struct
		// _SP_DRVINFO_DETAIL_DATA_A { DWORD cbSize; FILETIME InfDate; DWORD CompatIDsOffset; DWORD CompatIDsLength; ULONG_PTR Reserved;
		// CHAR SectionName[LINE_LEN]; CHAR InfFileName[MAX_PATH]; CHAR DrvDescription[LINE_LEN]; CHAR HardwareID[ANYSIZE_ARRAY]; }
		// SP_DRVINFO_DETAIL_DATA_A, *PSP_DRVINFO_DETAIL_DATA_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DRVINFO_DETAIL_DATA_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_DRVINFO_DETAIL_DATA
		{
			/// <summary>The size, in bytes, of the SP_DRVINFO_DETAIL_DATA structure.</summary>
			public uint cbSize;

			/// <summary>Date of the INF file for this driver.</summary>
			public FILETIME InfDate;

			/// <summary>
			/// <para>The offset, in characters, from the beginning of the <c>HardwareID</c> buffer where the CompatIDs list begins.</para>
			/// <para>
			/// This value can also be used to determine whether there is a hardware ID that precedes the CompatIDs list. If this value is
			/// greater than 1, the first string in the <c>HardwareID</c> buffer is the hardware ID. If this value is less than or equal to
			/// 1, there is no hardware ID.
			/// </para>
			/// </summary>
			public uint CompatIDsOffset;

			/// <summary>
			/// <para>
			/// The length, in characters, of the CompatIDs list starting at offset <c>CompatIDsOffset</c> from the beginning of the
			/// <c>HardwareID</c> buffer.
			/// </para>
			/// <para>
			/// If <c>CompatIDsLength</c> is nonzero, the CompatIDs list contains one or more NULL-terminated strings with an additional
			/// NULL character at the end of the list.
			/// </para>
			/// <para>
			/// If <c>CompatIDsLength</c> is zero, the CompatIDs list is empty. In that case, there is no additional NULL character at the
			/// end of the list.
			/// </para>
			/// </summary>
			public uint CompatIDsLength;

			/// <summary>Reserved. For internal use only.</summary>
			public IntPtr Reserved;

			/// <summary>
			/// A NULL-terminated string that contains the name of the INF DDInstall section for this driver. This must be the basic
			/// DDInstall section name, such as <c>InstallSec</c>, without any OS/architecture-specific extensions.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
			public string SectionName;

			/// <summary>A NULL-terminated string that contains the full-qualified name of the INF file for this driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string InfFileName;

			/// <summary>A NULL-terminated string that describes the driver.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
			public string DrvDescription;

			/// <summary>
			/// <para>
			/// A buffer that contains a list of IDs (a single hardware ID followed by a list of compatible IDs). These IDs correspond to
			/// the hardware ID and compatible IDs in the INF Models section.
			/// </para>
			/// <para>Each ID in the list is a NULL-terminated string.</para>
			/// <para>
			/// If the hardware ID exists (that is, if <c>CompatIDsOffset</c> is greater than one), this single NULL-terminated string is
			/// found at the beginning of the buffer.
			/// </para>
			/// <para>
			/// If the CompatIDs list is not empty (that is, if <c>CompatIDsLength</c> is not zero), the CompatIDs list starts at offset
			/// <c>CompatIDsOffset</c> from the beginning of this buffer, and is terminated with an additional NULL character at the end of
			/// the list.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string HardwareID;
		}

		/// <summary>
		/// An SP_DRVINSTALL_PARAMS structure contains driver installation parameters associated with a particular driver information element.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7, an installer or co-installer can set the DNF_REQUESTADDITIONALSOFTWARE flag to indicate that the driver
		/// package requires additional software that may or not be installed in the computer.
		/// </para>
		/// <para>
		/// After the driver package for the device is installed, the Plug and Play (PnP) manager performs the following steps if the
		/// installer sets the DNF_REQUESTADDITIONALSOFTWARE flag:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The PnP manager generates a Problem Report and Solution (PRS) error report with the type of <c>RequestAddtionalSoftware</c>.
		/// This report contains information about the specific hardware ID of the device and the system architecture of the computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If there is a solution that is provided by the independent hardware vendor (IHV) for the device-specific software, the solution
		/// is downloaded to the computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the device-specific software is not installed on the computer, the PnP manager presents the solution to the user and provides
		/// a link to download the software. The user can then choose to download and install this software by following the instructions
		/// presented in the solution.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The installer does not have to set the DNF_REQUESTADDITIONALSOFTWARE flag if the INF file for the driver package has
		/// set the <c>RequestAdditionalSoftware</c> flag in the INF ControlFlags Section.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_drvinstall_params typedef struct _SP_DRVINSTALL_PARAMS
		// { DWORD cbSize; DWORD Rank; DWORD Flags; DWORD_PTR PrivateData; DWORD Reserved; } SP_DRVINSTALL_PARAMS, *PSP_DRVINSTALL_PARAMS;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DRVINSTALL_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_DRVINSTALL_PARAMS
		{
			/// <summary>The size, in bytes, of the SP_DRVINSTALL_PARAMS structure.</summary>
			public uint cbSize;

			/// <summary>The rank match of this driver. Ranges from 0 to n, where 0 is the most compatible.</summary>
			public uint Rank;

			/// <summary>
			/// <para>Flags that control functions operating on this driver. Can be a combination of the following:</para>
			/// <para>DNF_ALWAYSEXCLUDEFROMLIST (Windows Vista and later versions of Windows)</para>
			/// <para>
			/// If set, this flag prevents the driver node from being enumerated, regardless of the client that is performing the enumeration.
			/// </para>
			/// <para>DNF_AUTHENTICODE_SIGNED (Windows Server 2003 and later versions of Windows)</para>
			/// <para>This driver's INF file is signed by an Authenticode signature. This flag is read-only to installers.</para>
			/// <para>For more information, see Using SetupAPI to Verify Driver Authenticode Signatures.</para>
			/// <para>DNF_BAD_DRIVER</para>
			/// <para>Do not use this driver. Installers can read and write this flag.</para>
			/// <para>If this flag is set, SetupDiSelectBestCompatDrv and SetupDiSelectDevice ignore this driver.</para>
			/// <para>
			/// A class installer or co-installer can set this flag to prevent Windows from listing the driver in the Select Driver dialog
			/// box. An installer might set this flag when it handles a DIF_SELECTDEVICE or DIF_SELECTBESTCOMPATDRV request, for example.
			/// </para>
			/// <para>DNF_BASIC_DRIVER (Windows XP and later versions of Windows)</para>
			/// <para>This driver is a basic driver. This flag is read-only to installers.</para>
			/// <para>DNF_CLASS_DRIVER</para>
			/// <para>This driver is a class driver. This flag is read-only to installers.</para>
			/// <para>DNF_COMPATIBLE_DRIVER</para>
			/// <para>This driver is a compatible driver. This flag is read-only to installers.</para>
			/// <para>DNF_DUPDESC</para>
			/// <para>
			/// There are other providers supplying drivers that have the same description as this driver. This flag is read-only to installers.
			/// </para>
			/// <para>DNF_DUPDRIVERVER (Windows XP and later versions of Windows)</para>
			/// <para>There are other providers supplying drivers that have the same version as this driver. This flag is read-only to installers.</para>
			/// <para>DNF_DUPPROVIDER</para>
			/// <para>
			/// There are other providers supplying drivers that have the same description as this driver. The only difference between this
			/// driver and its match is the driver date. This flag is read-only to installers.
			/// </para>
			/// <para>
			/// If this flag is set, Windows displays the driver date and driver version next to the driver so that the user can distinguish
			/// it from its match.
			/// </para>
			/// <para>DNF_EXCLUDEFROMLIST</para>
			/// <para>Do not display this driver in any driver-select dialogs.</para>
			/// <para>DNF_INBOX_DRIVER (Windows Vista and later versions of Windows)</para>
			/// <para>This driver node is derived from an INF file that was included with this version of Windows.</para>
			/// <para>DNF_INET_DRIVER</para>
			/// <para>This driver came from the Internet or from Windows Update. This flag is read-only to installers.</para>
			/// <para>
			/// If you call SetupCopyOEMInf you must specify the SPOST_URL flag so that when Windows copies this INF into the
			/// %SystemRoot%\inf directory Windows will mark it as an Internet INF. If you omit this step then Windows will attempt to use
			/// this device to install other devices. The resulting problem is that Windows does not have the source files any longer and
			/// will end up prompting the user with an invalid path.
			/// </para>
			/// <para>DNF_INF_IS_SIGNED (Windows XP and later versions of Windows)</para>
			/// <para>This flag is read-only to installers, and is set if any of the following conditions are true:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>The driver has a WHQL release signature.</term>
			/// </item>
			/// <item>
			/// <term>The driver is an inbox driver.</term>
			/// </item>
			/// <item>
			/// <term>The driver has an Authenticode signature.</term>
			/// </item>
			/// </list>
			/// <para>For more information, see</para>
			/// <para>Driver Signing</para>
			/// <para>.</para>
			/// <para>DNF_INSTALLEDDRIVER (Windows Vista and later versions of Windows)</para>
			/// <para>This driver node is currently installed for the device. This flag is read-only to installers.</para>
			/// <para>DNF_LEGACYINF</para>
			/// <para>
			/// This driver comes from a legacy INF file. This flag is valid only for the NT-based operating system. This flag is read-only
			/// to installers.
			/// </para>
			/// <para>DNF_NODRIVER</para>
			/// <para>Set if no physical driver is to be installed for this logical driver.</para>
			/// <para>DNF_OEM_F6_INF (Windows XP and later versions of Windows)</para>
			/// <para>Reserved.</para>
			/// <para>DNF_OLD_INET_DRIVER</para>
			/// <para>
			/// This driver came from the Internet, but Windows does not currently have access to its source files. This flag is read-only
			/// to installers.
			/// </para>
			/// <para>
			/// The system will not install a driver marked with this flag because Windows does not have the source files and would end up
			/// prompting the user with an invalid path. The INF for such a driver can be used for everything except for installing devices.
			/// </para>
			/// <para>DNF_OLDDRIVER</para>
			/// <para>This driver currently/previously controlled the associated device. This flag is read-only to installers.</para>
			/// <para>DNF_REQUESTADDITIONALSOFTWARE (Windows 7 and later versions of Windows)</para>
			/// <para>
			/// Set this flag if the driver package is only part of the software solution that is needed to operate the device. In this
			/// case, the driver package requires the installation of additional software.
			/// </para>
			/// <para>For more information, see the following Remarks section.</para>
			/// </summary>
			public DNF Flags;

			/// <summary>A field a class installer can use to store private data. Co-installers should not use this field.</summary>
			public IntPtr PrivateData;

			/// <summary>Reserved. For internal use only.</summary>
			public uint Reserved;
		}

		/// <summary>The <c>SP_FILE_COPY_PARAMS</c> structure describes a single file copy operation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_file_copy_params_a typedef struct
		// _SP_FILE_COPY_PARAMS_A { DWORD cbSize; HSPFILEQ QueueHandle; PCSTR SourceRootPath; PCSTR SourcePath; PCSTR SourceFilename; PCSTR
		// SourceDescription; PCSTR SourceTagfile; PCSTR TargetDirectory; PCSTR TargetFilename; DWORD CopyStyle; HINF LayoutInf; PCSTR
		// SecurityDescriptor; } SP_FILE_COPY_PARAMS_A, *PSP_FILE_COPY_PARAMS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_FILE_COPY_PARAMS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_FILE_COPY_PARAMS
		{
			/// <summary>
			/// Size of the structure, in bytes. Set to the value:
			/// <code>sizeof(SP_FILE_COPY_PARAMS)</code>
			/// .
			/// </summary>
			public uint cbSize;

			/// <summary>Handle to a setup file queue, as returned by SetupOpenFileQueue.</summary>
			public HSPFILEQ QueueHandle;

			/// <summary>Optional pointer to the root of the source for this copy, such as A:.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourceRootPath;

			/// <summary>Optional pointer to the path relative to <c>SourceRootPath</c> where the file can be found.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourcePath;

			/// <summary>File name part of the file to be copied.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourceFilename;

			/// <summary>Optional pointer to a description of the source media to be used during disk prompts.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourceDescription;

			/// <summary>
			/// Optional pointer to a tag file whose presence at <c>SourceRootPath</c> indicates the presence of the source media. If not
			/// specified, the file itself will be used as the tag file if required.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SourceTagfile;

			/// <summary>Directory where the file is to be copied.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string TargetDirectory;

			/// <summary>
			/// Optional pointer to the name of the target file. If not specified, the target file will have the same name as the source file.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string TargetFilename;

			/// <summary>
			/// <para>Flags that control the behavior of the file copy operation. These flags may be a combination of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SP_COPY_DELETESOURCE</term>
			/// <term>Delete the source file upon successful copy. The caller is not notified if the deletion fails.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_REPLACEONLY</term>
			/// <term>Copy the file only if doing so would overwrite a file at the destination path. The caller is not notified.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NEWER_OR_SAME</term>
			/// <term>
			/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than
			/// an existing copy on the target. The file version information used during version checks is that specified in the
			/// dwFileVersionMS and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one
			/// of the files does not have version resources, or if they have identical version information, the source file is considered
			/// newer. If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may
			/// cancel the copy. If CopyMsgHandler is not specified, the file is not copied.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NEWER_ONLY</term>
			/// <term>
			/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
			/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NOOVERWRITE</term>
			/// <term>
			/// Check whether the target file exists, and if so, notify the caller who may veto the copy. If CopyMsgHandler is not
			/// specified, the file is not overwritten.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NODECOMP</term>
			/// <term>
			/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
			/// appropriate). For example, copying f:\x86\cmd.ex_ to \\install\temp results in a target file of \\install\temp\cmd.ex_. If
			/// the SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called
			/// \\install\temp\cmd.exe. The file name part of DestinationName, if specified, is stripped and replaced with the file name of
			/// the source file. When SP_COPY_NODECOMP is specified, no language or version information can be checked.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_LANGUAGEAWARE</term>
			/// <term>
			/// Examine each file being copied to see if its language differs from the language of any existing file already on the target.
			/// If so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified,
			/// the file is not copied.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_SOURCE_ABSOLUTE</term>
			/// <term>SourceFile is a full source path. Do not look it up in the SourceDisksNames section of the INF file.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_SOURCEPATH_ABSOLUTE</term>
			/// <term>
			/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the SourceDisksNames
			/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_FORCE_IN_USE</term>
			/// <term>If the target exists, behave as if it is in-use and queue the file for copying on the next system reboot.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_IN_USE_NEEDS_REBOOT</term>
			/// <term>If the file was in-use during the copy operation, alert the user that the system needs to be rebooted.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_NOSKIP</term>
			/// <term>Do not give the user the option to skip a file.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_FORCE_NOOVERWRITE</term>
			/// <term>Check whether the target file exists, and if so, the file is not overwritten. The caller is not notified.</term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_FORCE_NEWER</term>
			/// <term>
			/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
			/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SP_COPY_WARNIFSKIP</term>
			/// <term>
			/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public CopyStyle CopyStyle;

			/// <summary>Handle to the INF to use to obtain source information.</summary>
			public HINF LayoutInf;

			/// <summary>An optional Security Descriptor String specifying the ACL to apply to the file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string SecurityDescriptor;
		}

		/// <summary>
		/// The <c>SP_INF_INFORMATION</c> structure stores information about an INF file, including the style, number of constituent INF
		/// files, and version data.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_inf_information typedef struct _SP_INF_INFORMATION {
		// DWORD InfStyle; DWORD InfCount; BYTE VersionData[ANYSIZE_ARRAY]; } SP_INF_INFORMATION, *PSP_INF_INFORMATION;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_INF_INFORMATION")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<SP_INF_INFORMATION>), nameof(InfCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_INF_INFORMATION
		{
			/// <summary>
			/// <para>Style of the INF file. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>INF_STYLE_NONE</term>
			/// <term>Specifies that the style of the INF file is unrecognized or nonexistent.</term>
			/// </item>
			/// <item>
			/// <term>INF_STYLE_OLDNT</term>
			/// <term>A legacy INF file format.</term>
			/// </item>
			/// <item>
			/// <term>INF_STYLE_WIN4</term>
			/// <term>A Windows INF file format.</term>
			/// </item>
			/// </list>
			/// </summary>
			public INF_STYLE InfStyle;

			/// <summary>Number of constituent INF files.</summary>
			public uint InfCount;

			/// <summary>Stores information from the <c>Version</c> section of an INF file in an array of <c>ANYSIZE_ARRAY</c> bytes.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] VersionData;
		}

		/// <summary>The <c>SP_INF_SIGNER_INFO</c> structure stores information about an INF file's digital signature.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_inf_signer_info_v1_a typedef struct
		// _SP_INF_SIGNER_INFO_V1_A { DWORD cbSize; CHAR CatalogFile[MAX_PATH]; CHAR DigitalSigner[MAX_PATH]; CHAR
		// DigitalSignerVersion[MAX_PATH]; } SP_INF_SIGNER_INFO_V1_A, *PSP_INF_SIGNER_INFO_V1_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_INF_SIGNER_INFO_V1_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_INF_SIGNER_INFO_V1
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>Path to the catalog file, stored in an array of maximum size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string CatalogFile;

			/// <summary>Path to the digital signer of the file, stored in an array of maximum size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string DigitalSigner;

			/// <summary>Version of the digital signer, stored in an array of size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string DigitalSignerVersion;
		}

		/// <summary>The <c>SP_INF_SIGNER_INFO</c> structure stores information about an INF file's digital signature.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_inf_signer_info_v2_a typedef struct
		// _SP_INF_SIGNER_INFO_V2_A { DWORD cbSize; CHAR CatalogFile[MAX_PATH]; CHAR DigitalSigner[MAX_PATH]; CHAR
		// DigitalSignerVersion[MAX_PATH]; DWORD SignerScore; } SP_INF_SIGNER_INFO_V2_A, *PSP_INF_SIGNER_INFO_V2_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_INF_SIGNER_INFO_V2_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_INF_SIGNER_INFO_V2
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>Path to the catalog file, stored in an array of maximum size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string CatalogFile;

			/// <summary>Path to the digital signer of the file, stored in an array of maximum size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string DigitalSigner;

			/// <summary>Version of the digital signer, stored in an array of size MAX_PATH characters.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string DigitalSignerVersion;

			/// <summary/>
			public uint SignerScore;
		}

		/// <summary>
		/// An SP_NEWDEVICEWIZARD_DATA structure is used by installers to extend the operation of the hardware installation wizard by adding
		/// custom pages. It is used with DIF_NEWDEVICEWIZARD_XXX installation requests.
		/// </summary>
		/// <remarks>SP_ADDPROPERTYPAGE_DATA is an alias for this structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_newdevicewizard_data typedef struct
		// _SP_NEWDEVICEWIZARD_DATA { SP_CLASSINSTALL_HEADER ClassInstallHeader; DWORD Flags; HPROPSHEETPAGE
		// DynamicPages[MAX_INSTALLWIZARD_DYNAPAGES]; DWORD NumDynamicPages; HWND hwndWizardDlg; } SP_NEWDEVICEWIZARD_DATA, *PSP_NEWDEVICEWIZARD_DATA;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_NEWDEVICEWIZARD_DATA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_NEWDEVICEWIZARD_DATA
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>Reserved. Must be zero.</summary>
			public uint Flags;

			/// <summary>An array of property sheet page handles. An installer can add the handles of custom wizard pages to this array.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_INSTALLWIZARD_DYNAPAGES)]
			public HPROPSHEETPAGE[] DynamicPages;

			/// <summary>
			/// <para>The number of pages that are added to the <c>DynamicPages</c> array.</para>
			/// <para>
			/// Because the array index is zero-based, this value is also the index to the next free entry in the array. For example, if
			/// there are 3 pages in the array, <c>DynamicPages[</c> 3 <c>]</c> is the next entry for an installer to use.
			/// </para>
			/// </summary>
			public uint NumDynamicPages;

			/// <summary>The handle to the top-level window of the hardware installation wizard .</summary>
			public HWND hwndWizardDlg;
		}

		/// <summary>
		/// The <c>SP_ORIGINAL_FILE_INFO</c> structure receives the original INF file name and catalog file information returned by SetupQueryInfOriginalFileInformation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_original_file_info_a typedef struct
		// _SP_ORIGINAL_FILE_INFO_A { DWORD cbSize; CHAR OriginalInfName[MAX_PATH]; CHAR OriginalCatalogName[MAX_PATH]; }
		// SP_ORIGINAL_FILE_INFO_A, *PSP_ORIGINAL_FILE_INFO_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_ORIGINAL_FILE_INFO_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_ORIGINAL_FILE_INFO
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>Original file name of the INF file stored in array of size MAX_PATH.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string OriginalInfName;

			/// <summary>Catalog name of the INF file stored in array of size MAX_PATH.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string OriginalCatalogName;
		}

		/// <summary>An SP_POWERMESSAGEWAKE_PARAMS structure corresponds to a DIF_POWERMESSAGEWAKE installation request.</summary>
		/// <remarks>Windows only sends the DIF_POWERMESSAGEWAKE request if the drivers for the device support power management.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_powermessagewake_params_a typedef struct
		// _SP_POWERMESSAGEWAKE_PARAMS_A { SP_CLASSINSTALL_HEADER ClassInstallHeader; CHAR *PowerMessageWake[LINE_LEN 2]; }
		// SP_POWERMESSAGEWAKE_PARAMS_A, *PSP_POWERMESSAGEWAKE_PARAMS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_POWERMESSAGEWAKE_PARAMS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_POWERMESSAGEWAKE_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// Buffer that contains a string of custom text. Windows displays this text on the power management page of the device
			/// properties display in Device Manager.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN * 2)]
			public string PowerMessageWake;
		}

		/// <summary>An SP_PROPCHANGE_PARAMS structure corresponds to a DIF_PROPERTYCHANGE installation request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_propchange_params typedef struct _SP_PROPCHANGE_PARAMS
		// { SP_CLASSINSTALL_HEADER ClassInstallHeader; DWORD StateChange; DWORD Scope; DWORD HwProfile; } SP_PROPCHANGE_PARAMS, *PSP_PROPCHANGE_PARAMS;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_PROPCHANGE_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_PROPCHANGE_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// <para>State change action. Can be one of the following values:</para>
			/// <para>DICS_ENABLE</para>
			/// <para>The device is being enabled.</para>
			/// <para>For this state change, Windows enables the device if the <c>DICS_FLAG_GLOBAL</c> flag is specified.</para>
			/// <para>
			/// If the <c>DICS_FLAG_CONFIGSPECIFIC</c> flag is specified and the current hardware profile is specified then Windows enables
			/// the device. If the <c>DICS_FLAG_CONFIGSPECIFIC</c> is specified and not the current hardware profile then Windows sets some
			/// flags in the registry and does not change the device's state. Windows will change the device state when the specified
			/// profile becomes the current profile.
			/// </para>
			/// <para>DICS_DISABLE</para>
			/// <para>The device is being disabled.</para>
			/// <para>For this state change, Windows disables the device if the <c>DICS_FLAG_GLOBAL</c> flag is specified.</para>
			/// <para>
			/// If the <c>DICS_FLAG_CONFIGSPECIFIC</c> flag is specified and the current hardware profile is specified then Windows disables
			/// the device. If the <c>DICS_FLAG_CONFIGSPECIFIC</c> is specified and not the current hardware profile then Windows sets some
			/// flags in the registry and does not change the device's state.
			/// </para>
			/// <para>DICS_PROPCHANGE</para>
			/// <para>The properties of the device have changed.</para>
			/// <para>
			/// For this state change, Windows ignores the <c>Scope</c> information as long it is a valid value, and stops and restarts the device.
			/// </para>
			/// <para>DICS_START</para>
			/// <para>The device is being started (if the request is for the currently active hardware profile).</para>
			/// <para><c>DICS_START</c> must be <c>DICS_FLAG_CONFIGSPECIFIC</c>. You cannot perform that change globally.</para>
			/// <para>
			/// Windows only starts the device if the current hardware profile is specified. Otherwise, Windows sets a registry flag and
			/// does not change the state of the device.
			/// </para>
			/// <para>DICS_STOP</para>
			/// <para>
			/// The device is being stopped. The driver stack will be unloaded and the CSCONFIGFLAG_DO_NOT_START flag will be set for the device.
			/// </para>
			/// <para><c>DICS_STOP</c> must be <c>DICS_FLAG_CONFIGSPECIFIC</c>. You cannot perform that change globally.</para>
			/// <para>
			/// Windows only stops the device if the current hardware profile is specified. Otherwise, Windows sets a registry flag and does
			/// not change the state of the device.
			/// </para>
			/// <para>
			/// Components should not specify DICS_STOP or DICS_START. Instead, they should use DICS_PROPCHANGE to stop and restart a device
			/// to cause changes in the device's configuration to take effect.
			/// </para>
			/// </summary>
			public DICS StateChange;

			/// <summary>
			/// <para>Flags that specify the scope of a device property change. Can be one of the following:</para>
			/// <para>DICS_FLAG_GLOBAL</para>
			/// <para>Make the change in all hardware profiles.</para>
			/// <para>DICS_FLAG_CONFIGSPECIFIC</para>
			/// <para>Make the change in the specified profile only.</para>
			/// <para>The following flag is obsolete:</para>
			/// <para>DICS_FLAG_CONFIGGENERAL</para>
			/// </summary>
			public DICS_FLAG Scope;

			/// <summary>Supplies the hardware profile ID for profile-specific changes. Zero specifies the current hardware profile.</summary>
			public uint HwProfile;
		}

		/// <summary>
		/// <para>
		/// An SP_PROPSHEETPAGE_REQUEST structure can be passed as the first parameter (lpv) to the <c>ExtensionPropSheetPageProc</c> entry
		/// point in the SetupAPI DLL. <c>ExtensionPropSheetPageProc</c> is used to retrieve a handle to a specified property sheet page.
		/// </para>
		/// <para>For information about <c>ExtensionPropSheetPageProc</c> and related functions, see the Microsoft Windows SDK documentation.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The component that is retrieving the property pages calls SetupAPI's <c>ExtensionPropSheetPageProc</c> function and passes in a
		/// pointer to a SP_PROPSHEETPAGE_REQUEST structure, the address of their <c>AddPropSheetPageProc</c> function, and some private
		/// data. The property sheet provider calls the <c>AddPropSheetPageProc</c> routine for each property sheet it provides.
		/// </para>
		/// <para>The following code excerpt shows how to retrieve one page, the SetupAPI's Resource Selection page:</para>
		/// <para>
		/// <code>{ DWORD Err; HINSTANCE hLib; FARPROC PropSheetExtProc; HPROPSHEETPAGE hPages[2]; . . . if(!(hLib = GetModuleHandle(TEXT("setupapi.dll")))) { return GetLastError(); } if(!(PropSheetExtProc = GetProcAddress(hLib, "ExtensionPropSheetPageProc"))) { Err = GetLastError(); FreeLibrary(hLib); return Err; } PropPageRequest.cbSize = sizeof(SP_PROPSHEETPAGE_REQUEST); PropPageRequest.PageRequested = SPPSR_SELECT_DEVICE_RESOURCES; PropPageRequest.DeviceInfoSet = DeviceInfoSet; PropPageRequest.DeviceInfoData = DeviceInfoData; if(!PropSheetExtProc(&amp;PropPageRequest, AddPropSheetPageProc, &amp;hPages[1])) { Err = ERROR_INVALID_PARAMETER; FreeLibrary(hLib); return Err; } . . . }</code>
		/// </para>
		/// <para>The <c>AddPropSheetPageProc</c> for the previous excerpt would be something like the following:</para>
		/// <para>
		/// <code>BOOL CALLBACK AddPropSheetPageProc( IN HPROPSHEETPAGE hpage, IN LPARAM lParam ) { *((HPROPSHEETPAGE *)lParam) = hpage; return TRUE; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_propsheetpage_request typedef struct
		// _SP_PROPSHEETPAGE_REQUEST { DWORD cbSize; DWORD PageRequested; HDEVINFO DeviceInfoSet; PSP_DEVINFO_DATA DeviceInfoData; }
		// SP_PROPSHEETPAGE_REQUEST, *PSP_PROPSHEETPAGE_REQUEST;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_PROPSHEETPAGE_REQUEST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_PROPSHEETPAGE_REQUEST
		{
			/// <summary>The size, in bytes, of the SP_PROPSHEETPAGE_REQUEST structure.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>The property sheet page to add to the property sheet. Can be one of the following values:</para>
			/// <para>SPPSR_SELECT_DEVICE_RESOURCES</para>
			/// <para>Specifies the Resource Selection page supplied by the SetupAPI DLL.</para>
			/// <para>SPPSR_ENUM_BASIC_DEVICE_PROPERTIES</para>
			/// <para>
			/// Specifies a page that is supplied by the device's BasicProperties32 provider. That is, an installer or other component that
			/// supplied page(s) in response to a DIF_ADDPROPERTYPAGE_BASIC installation request.
			/// </para>
			/// <para>SPPSR_ENUM_ADV_DEVICE_PROPERTIES</para>
			/// <para>
			/// Specifies a page that is supplied by the class and/or the device's EnumPropPages32 provider. That is, an installer or other
			/// component that supplied page(s) in response to a DIF_ADDPROPERTYPAGE_ADVANCED installation request.
			/// </para>
			/// </summary>
			public SPPSR PageRequested;

			/// <summary>The handle for the device information set that contains the device being installed.</summary>
			public HDEVINFO DeviceInfoSet;

			/// <summary>A pointer to an SP_DEVINFO_DATA structure for the device being installed.</summary>
			public IntPtr DeviceInfoData;
		}

		/// <summary>
		/// <para>
		/// The <c>SP_REGISTER_CONTROL_STATUS</c> structure contains information about a file being registered or unregistered using the
		/// <c>RegisterDlls</c> INF directive to self-register DLLs on Windows 2000.
		/// </para>
		/// <para>
		/// When SetupInstallFromInfSection sends a SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION notification to the
		/// callback routine, the caller must provide a pointer to a <c>SP_REGISTER_CONTROL_STATUS</c> structure in the MsgHandler parameter.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_register_control_statusa typedef struct
		// _SP_REGISTER_CONTROL_STATUSA { DWORD cbSize; PCSTR FileName; DWORD Win32Error; DWORD FailureCode; } SP_REGISTER_CONTROL_STATUSA, *PSP_REGISTER_CONTROL_STATUSA;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_REGISTER_CONTROL_STATUSA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_REGISTER_CONTROL_STATUS
		{
			/// <summary/>
			public uint cbSize;

			/// <summary>Fully qualified path of the file being registered or unregistered.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string FileName;

			/// <summary>
			/// For an SPFILENOTIFY_STARTREGISTRATION notification, this member is not used and should be set to NO_ERROR. For a
			/// SPFILENOTIFY_ENDREGISTRATION notification, set to a system error code.
			/// </summary>
			public Win32Error Win32Error;

			/// <summary>
			/// <para>
			/// For a SPFILENOTIFY_STARTREGISTRATION notification, this member is not used and should be set to SPREG_SUCCESS. For a
			/// SPFILENOTIFY_ENDREGISTRATION notification, set to one of the following failure codes that indicate the result of registration.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SPREG_SUCCESS</term>
			/// <term>The file was successfully registered or unregistered. WinError not used.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_LOADLIBRARY</term>
			/// <term>LoadLibrary failed for the file. WinError contains an extended error code from the component.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_GETPROCADDR</term>
			/// <term>GetProcAddress failed for the file. WinError contains an extended error code from the component.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_REGSVR</term>
			/// <term>DLLRegisterServer entry point returned failure. WinError contains an extended error code from the component.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_DLLINSTALL</term>
			/// <term>DLLInstall entry point returned failure. WinError contains an extended error code from the component.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_TIMEOUT</term>
			/// <term>The file registration or unregistration exceeded the specified timeout. WinError is set to ERROR_TIMEOUT.</term>
			/// </item>
			/// <item>
			/// <term>SPREG_UNKNOWN</term>
			/// <term>
			/// File registration or unregistration failed for an unknown reason. WinError indicates an extended error code from the component.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public SPREG FailureCode;
		}

		/// <summary>An SP_REMOVEDEVICE_PARAMS structure corresponds to the DIF_REMOVE installation request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_removedevice_params typedef struct
		// _SP_REMOVEDEVICE_PARAMS { SP_CLASSINSTALL_HEADER ClassInstallHeader; DWORD Scope; DWORD HwProfile; } SP_REMOVEDEVICE_PARAMS, *PSP_REMOVEDEVICE_PARAMS;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_REMOVEDEVICE_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_REMOVEDEVICE_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// <para>Flags that indicate the scope of the device removal. Can be one of the following values:</para>
			/// <para>DI_REMOVEDEVICE_GLOBAL</para>
			/// <para>Make this change in all hardware profiles. Remove information about the device from the registry.</para>
			/// <para>DI_REMOVEDEVICE_CONFIGSPECIFIC</para>
			/// <para>
			/// Make this change to only the hardware profile specified by <c>HwProfile</c>. this flag only applies to root-enumerated
			/// devices. When Windows removes the device from the last hardware profile in which it was configured, Windows performs a
			/// global removal.
			/// </para>
			/// </summary>
			public DI_REMOVEDEVICE Scope;

			/// <summary>The hardware profile ID for profile-specific changes. Zero specifies the current hardware profile.</summary>
			public uint HwProfile;
		}

		/// <summary>An SP_SELECTDEVICE_PARAMS structure corresponds to a DIF_SELECTDEVICE installation request.</summary>
		/// <remarks>
		/// <para>
		/// If an installer sets fields in this structure to be used during driver selection, the installer must also set the
		/// DI_USECI_SELECTSTRINGS flag in the SP_DEVINSTALL_PARAMS.
		/// </para>
		/// <para>The following screen shot shows a sample Select Device dialog box and identifies the strings an installer can supply.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_selectdevice_params_a typedef struct
		// _SP_SELECTDEVICE_PARAMS_A { SP_CLASSINSTALL_HEADER ClassInstallHeader; CHAR Title[MAX_TITLE_LEN]; CHAR
		// Instructions[MAX_INSTRUCTION_LEN]; CHAR ListLabel[MAX_LABEL_LEN]; CHAR SubTitle[MAX_SUBTITLE_LEN]; BYTE Reserved[2]; }
		// SP_SELECTDEVICE_PARAMS_A, *PSP_SELECTDEVICE_PARAMS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_SELECTDEVICE_PARAMS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_SELECTDEVICE_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// Buffer that contains an installer-provided window title for driver-selection windows. Windows uses this title for the window
			/// title for the Select Device dialogs.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_TITLE_LEN)]
			public string Title;

			/// <summary>Buffer that contains an installer-provided select-device instructions.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_INSTRUCTION_LEN)]
			public string Instructions;

			/// <summary>Buffer that contains an installer-provided label for the list of drivers from which the user can select.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_LABEL_LEN)]
			public string ListLabel;

			/// <summary>
			/// Buffer that contains an installer-provided subtitle used in select-device wizards. This string is not used in select dialogs.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SUBTITLE_LEN)]
			public string SubTitle;

			/// <summary>Reserved. For internal use only.</summary>
			public ushort Reserved;
		}

		/// <summary>An SP_TROUBLESHOOTER_PARAMS structure corresponds to a DIF_TROUBLESHOOTER installation request.</summary>
		/// <remarks>An installer fills in this structure in response to a DIF_TROUBLESHOOTER request.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_troubleshooter_params_a typedef struct
		// _SP_TROUBLESHOOTER_PARAMS_A { SP_CLASSINSTALL_HEADER ClassInstallHeader; CHAR ChmFile[MAX_PATH]; CHAR
		// HtmlTroubleShooter[MAX_PATH]; } SP_TROUBLESHOOTER_PARAMS_A, *PSP_TROUBLESHOOTER_PARAMS_A;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_TROUBLESHOOTER_PARAMS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SP_TROUBLESHOOTER_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>
			/// Optionally specifies a string buffer that contains the path of a CHM file. The CHM file contains HTML help topics with
			/// troubleshooting information. The path must be fully qualified if the file is not in default system help directory (%SystemRoot%\help).
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string ChmFile;

			/// <summary>
			/// Optionally specifies a string buffer that contains the path of a topic in the <c>ChmFile</c>. This parameter identifies the
			/// page of the <c>ChmFile</c> that Windows should display first.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string HtmlTroubleShooter;
		}

		/// <summary>An SP_UNREMOVEDEVICE_PARAMS structure corresponds to a DIF_UNREMOVE installation request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_unremovedevice_params typedef struct
		// _SP_UNREMOVEDEVICE_PARAMS { SP_CLASSINSTALL_HEADER ClassInstallHeader; DWORD Scope; DWORD HwProfile; } SP_UNREMOVEDEVICE_PARAMS, *PSP_UNREMOVEDEVICE_PARAMS;
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_UNREMOVEDEVICE_PARAMS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SP_UNREMOVEDEVICE_PARAMS
		{
			/// <summary>An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.</summary>
			public SP_CLASSINSTALL_HEADER ClassInstallHeader;

			/// <summary>A flag that indicates the scope of the unremove operation. This flag must always be set to DI_UNREMOVEDEVICE_CONFIGSPECIFIC.</summary>
			public DI_UNREMOVEDEVICE Scope;

			/// <summary>The hardware profile ID for profile-specific changes. Zero specifies the current hardware profile.</summary>
			public uint HwProfile;
		}

		/// <summary>An SP_DEVICE_INTERFACE_DETAIL_DATA structure contains the path for a device interface.</summary>
		/// <remarks>
		/// <para>An SP_DEVICE_INTERFACE_DETAIL_DATA structure identifies the path for a device interface in a device information set.</para>
		/// <para>
		/// <c>SetupDi</c> Xxx functions that take an SP_DEVICE_INTERFACE_DETAIL_DATA structure as a parameter verify that the <c>cbSize</c>
		/// member of the supplied structure is equal to the size, in bytes, of the structure. If the <c>cbSize</c> member is not set
		/// correctly for an input parameter, the function will fail and set an error code of ERROR_INVALID_PARAMETER. If the <c>cbSize</c>
		/// member is not set correctly for an output parameter, the function will fail and set an error code of ERROR_INVALID_USER_BUFFER.
		/// </para>
		/// </remarks>
		[PInvokeData("setupapi.h", MSDNShortId = "NS:setupapi._SP_DEVICE_INTERFACE_DETAIL_DATA_A")]
		public class SafeSP_DEVICE_INTERFACE_DETAIL_DATA : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			/// <summary>Get an instance that represents the <see langword="null"/> value.</summary>
			public static readonly SafeSP_DEVICE_INTERFACE_DETAIL_DATA Null = new SafeSP_DEVICE_INTERFACE_DETAIL_DATA();

			/// <summary>Initializes a new instance of the <see cref="SafeSP_DEVICE_INTERFACE_DETAIL_DATA"/> class.</summary>
			/// <param name="size">The size of memory to allocate, in bytes.</param>
			public SafeSP_DEVICE_INTERFACE_DETAIL_DATA(SizeT size) : base(size)
			{
				Marshal.StructureToPtr(SP_DEVICE_INTERFACE_DETAIL_DATA.Default, handle, false);
			}

			private SafeSP_DEVICE_INTERFACE_DETAIL_DATA() : base(IntPtr.Zero, 0, false)
			{
			}

			/// <summary>
			/// A NULL-terminated string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
			/// </summary>
			public string DevicePath => StringHelper.GetString(handle.Offset(4), CharSet.Auto, Size - 4);
		}
	}
}