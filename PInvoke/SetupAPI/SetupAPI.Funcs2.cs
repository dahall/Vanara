using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Items from the SetupAPI.dll</summary>
public static partial class SetupAPI
{
	/// <summary>Severity of the message.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupLogErrorA")]
	public enum LogSeverity
	{
		/// <summary>Information</summary>
		LogSevInformation = 0x00000000,

		/// <summary>Warning</summary>
		LogSevWarning = 0x00000001,

		/// <summary>Error</summary>
		LogSevError = 0x00000002,

		/// <summary>Fatal error</summary>
		LogSevFatalError = 0x00000003,
	}

	/// <summary>Flags for <see cref="SetupSetDirectoryIdEx"/>.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetDirectoryIdExA")]
	[Flags]
	public enum SETDIRID : uint
	{
		/// <summary>Indicate that the Directory does not specify a full path.</summary>
		SETDIRID_NOT_FULL_PATH = 0x00000001
	}

	/// <summary>Indicates what information should be returned to the DataOut buffer.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryFileLogA")]
	public enum SetupFileLogInfo
	{
		/// <summary>Name of the source file as it exists on the source media</summary>
		SetupFileLogSourceFilename,

		/// <summary>A checksum value used by the system log</summary>
		SetupFileLogChecksum,

		/// <summary>Name of the tag file of the media source containing the source file</summary>
		SetupFileLogDiskTagfile,

		/// <summary>The human-readable description of the media where the source file resides</summary>
		SetupFileLogDiskDescription,

		/// <summary>Additional information associated with the logged file</summary>
		SetupFileLogOtherInfo,
	}

	/// <summary>Flags for <see cref="SetupLogFile"/>.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupLogFileA")]
	[Flags]
	public enum SPLOGFILE : uint
	{
		/// <summary>
		/// Meaningful only for the system log and indicates that the file is not supplied by Microsoft. This parameter can be used to
		/// convert an existing file's entry, such as when an OEM overwrites a Microsoft-supplied system file.
		/// </summary>
		SPFILELOG_OEMFILE = 0x00000001,
	}

	/// <summary>Flags to combine to control the file queue scan operation.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupScanFileQueueA")]
	[Flags]
	public enum SPQ_SCAN : uint
	{
		/// <summary>Target files in the copy queue are already present on the target.</summary>
		SPQ_SCAN_FILE_PRESENCE = 0x00000001,

		/// <summary>
		/// Target files in the copy queue are already present on the target with valid signatures. Available with Windows 2000 and
		/// later versions.
		/// </summary>
		SPQ_SCAN_FILE_VALIDITY = 0x00000002,

		/// <summary>
		/// Callback routine for each node of the queue. If the callback routine returns a nonzero value, the queue processing stops and
		/// SetupScanFileQueue returns zero. Issue a SPFILENOTIFY_QUEUESCAN notification code and a pass a pointer to the target path as Param1.
		/// </summary>
		SPQ_SCAN_USE_CALLBACK = 0x00000004,

		/// <summary>
		/// Callback routine for each node of the queue. If the callback routine returns a nonzero value, the queue processing stops and
		/// SetupScanFileQueue returns zero. Issue a SPFILENOTIFY_QUEUESCAN_EX notification and pass a pointer to a FILEPATHS structure
		/// as Param1. SPQ_SCAN_USE_CALLBACKEX also checks that the file has a valid signature. Available starting with Windows 2000. On
		/// Windows XP only, you can turn off signature checking by combining this flag with SPQ_SCAN_FILE_PRESENCE.
		/// </summary>
		SPQ_SCAN_USE_CALLBACKEX = 0x00000008,

		/// <summary>
		/// Flag specified when all files in the queue pass the check for valid signatures. SetupScanFileQueue informs the user that the
		/// operation requires files that are already present on the target. This flag is ignored if SPQ_SCAN_FILE_PRESENCE or
		/// SPQ_SCAN_FILE_VALIDITY is not specified. This flag may not be used with SPQ_SCAN_PRUNE_COPY_QUEUE or SPQ_SCAN_PRUNE_DELREN.
		/// </summary>
		SPQ_SCAN_INFORM_USER = 0x00000010,

		/// <summary>
		/// Combined with SPQ_SCAN_FILE_PRESENCE, removes present entries from the copy queue. When combined with
		/// SPQ_SCAN_FILE_VALIDITY, removes signed entries from the copy queue. Available starting with Windows 2000. On Windows XP
		/// only, files that are also specified in the delete queue or rename queues are not pruned unless SPQ_SCAN_PRUNE_DELREN is specified.
		/// </summary>
		SPQ_SCAN_PRUNE_COPY_QUEUE = 0x00000020,

		/// <summary>
		/// Available starting with Windows XP. Issues SPFILENOTIFY_QUEUESCAN_SIGNERINFO notification and passes a pointer to a
		/// FILEPATHS_SIGNERINFO structure as Param1. Checks each file for a valid signature and reports signature information through
		/// the callback function.
		/// </summary>
		SPQ_SCAN_USE_CALLBACK_SIGNERINFO = 0x00000040,

		/// <summary>
		/// Combined with SPQ_SCAN_FILE_PRESENCE or SPQ_SCAN_FILE_VALIDITY, removes entries in the delete or rename queue that are also
		/// in the copy queue. When combined with SPQ_SCAN_PRUNE_COPY_QUEUE, limits files that are removed from the copy queue to files
		/// that are not in the delete or rename queues. Available starting with Windows XP.
		/// </summary>
		SPQ_SCAN_PRUNE_DELREN = 0x00000080,

		/// <summary/>
		SPQ_SCAN_FILE_PRESENCE_WITHOUT_SOURCE = 0x00000100,

		/// <summary/>
		SPQ_SCAN_FILE_COMPARISON = 0x00000200,

		/// <summary/>
		SPQ_SCAN_ACTIVATE_DRP = 0x00000400,
	}

	/// <summary>The controls for the installation of each service in the specified section.</summary>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallServicesFromInfSectionA")]
	[Flags]
	public enum SPSVCINST : uint
	{
		/// <summary>AddService section: move the service tag to the front of its group order list.</summary>
		SPSVCINST_TAGTOFRONT = 0x001,

		/// <summary>AddService section: Mark this service as the function driver for the device being installed.</summary>
		SPSVCINST_ASSOCSERVICE = 0x002,

		/// <summary>DelService section: delete the event log entry.</summary>
		SPSVCINST_DELETEEVENTLOGENTRY = 0x004,

		/// <summary>AddService section: do not overwrite the display name if one already exists.</summary>
		SPSVCINST_NOCLOBBER_DISPLAYNAME = 0x008,

		/// <summary>AddService section: do not overwrite the start type value if the service already exists.</summary>
		SPSVCINST_NOCLOBBER_STARTTYPE = 0x010,

		/// <summary>AddService section: do not overwrite the error control value if the service already exists.</summary>
		SPSVCINST_NOCLOBBER_ERRORCONTROL = 0x020,

		/// <summary>AddService section: do not overwrite the load order group if it already exists.</summary>
		SPSVCINST_NOCLOBBER_LOADORDERGROUP = 0x040,

		/// <summary>AddService section: do not overwrite the dependencies list if it already exists.</summary>
		SPSVCINST_NOCLOBBER_DEPENDENCIES = 0x080,

		/// <summary>AddService section: mark this service as the function driver for the device being installed.</summary>
		SPSVCINST_NOCLOBBER_DESCRIPTION = 0x100,

		/// <summary>DelService section: Stop the associated service specified in the entry before deleting the service.</summary>
		SPSVCINST_STOPSERVICE = 0x200,

		/// <summary>
		/// AddService section: Security settings the service are overwritten if the service already exists in the system.
		/// <para>Note Available starting with Windows Server 2003 and Windows XP.</para>
		/// </summary>
		SPSVCINST_CLOBBER_SECURITY = 0x400,

		/// <summary>
		/// AddService section: Start the service after the service is installed. This flag cannot be used to start a service that
		/// implements a Plug and Play (PnP) function driver or filter driver for a device. Otherwise, this flag can be used to start a
		/// user-mode or kernel-mode service that is managed by the Service Control Manager (SCM.)
		/// <para>Note Available starting with Windows Server 2008 and Windows Vista.</para>
		/// </summary>
		SPSVCINST_STARTSERVICE = 0x800,

		/// <summary>
		/// AddService section: Do not overwrite the given service's required privileges if the service already exists in the system.
		/// <para>Note Available starting with Windows Server 2008 R2 and Windows 7.</para>
		/// </summary>
		SPSVCINST_NOCLOBBER_REQUIREDPRIVILEGES = 0x1000,

		/// <summary>AddService section: don't overwrite triggers if they already exist.</summary>
		SPSVCINST_NOCLOBBER_TRIGGERS = 0x00002000,

		/// <summary>AddService section: don't overwrite service SID type if it already exists.</summary>
		SPSVCINST_NOCLOBBER_SERVICESIDTYPE = 0x00004000,

		/// <summary>AddService section: don't overwrite delayed auto start if it already exists.</summary>
		SPSVCINST_NOCLOBBER_DELAYEDAUTOSTART = 0x00008000,
	}

	/// <summary>Flags for <see cref="SetupUninstallOEMInf"/>.</summary>
	[Flags]
	public enum SUOI : uint
	{
		/// <summary>
		/// The SetupUninstallOEMInf function first checks whether there are any devices installed using the .inf file. A device does
		/// not need to be present to be detected as using the .inf file. If this flag is not set and the function finds a currently
		/// installed device that was installed using this .inf file, the .inf file is not removed. If this flag is set, the .inf file
		/// is removed whether the function finds a device that was installed with this .inf file.
		/// </summary>
		SUOI_FORCEDELETE = 0x0001
	}

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallFileEx</c> function installs a file as specified either by an INFCONTEXT returned by SetupFindXXXLine or
	/// explicitly by the filename and path information. This function is the same as SetupInstallFile, except that a <c>BOOL</c> is
	/// returned that indicates whether the file was in use.
	/// </para>
	/// <para>If a file is copied, the caller of this function is required to have privileges to write into the target directory.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Optional pointer to the handle to an INF file that contains the SourceDisksNames and SourceDisksFiles sections. If
	/// platform-specific sections exist for the user's system (for example, SourceDisksNames.x86 and SourceDisksFiles.x86), the
	/// platform-specific section are used. If InfContext is not specified and CopyStyle includes SP_COPY_SOURCE_ABSOLUTE or
	/// SP_COPY_SOURCEPATH_ABSOLUTE, InfHandle is ignored.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to context for a line in a Copy Files section in an INF file. The routine looks this file up in the
	/// SourceDisksFiles section of InfHandle to get file copy information. If InfContext is not specified, SourceFile must be.
	/// </param>
	/// <param name="SourceFile">
	/// Optional pointer to the filename (no path) of the file to copy. The file is looked up in the SourceDisksFiles section. The
	/// SourceFile parameter must be specified if InfContext is not. However, SourceFile is ignored if InfContext is specified.
	/// </param>
	/// <param name="SourcePathRoot">
	/// Optional pointer to the root path for the file to be copied (for example, A:\ or F:). Paths in the SourceDisksNames section are
	/// appended to this path. The SourcePathRoot parameter is ignored if CopyStyle includes the SP_COPY_SOURCE_ABSOLUTE flag.
	/// </param>
	/// <param name="DestinationName">
	/// Optional pointer to a new name for the copied file. If InfContext is specified, DestinationName supplies the filename only (no
	/// path) of the target file. This parameter can be <c>NULL</c> to indicate that the target file should have the same name as the
	/// source file. If InfContext is not specified, DestinationName supplies the full target path and filename for the target.
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation.</para>
	/// <para>These flags can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SP_COPY_DELETESOURCE</term>
	/// <term>Delete the source file upon successful copy. The caller is not notified if the delete fails.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_REPLACEONLY</term>
	/// <term>Copy the file only if doing so overwrites a file at the destination path.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NEWER_OR_SAME</term>
	/// <term>
	/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target. The file version information used during version checks is that specified in the dwFileVersionMS
	/// and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does not
	/// have version resources, or if they have identical version information, the source file is considered newer. If the source file
	/// is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If
	/// CopyMsgHandler is not specified, the file is not copied.
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
	/// Check whether the target file exists, and if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NODECOMP</term>
	/// <term>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying "f:\x86\cmd.ex_" to "\\install\temp" results in a target file of "\\install\temp\cmd.ex_". If
	/// the SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called
	/// "\\install\temp\cmd.exe". The filename part of DestinationName, if specified, is stripped and replaced with the filename of the
	/// source file. When SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_LANGUAGEAWARE</term>
	/// <term>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_SOURCE_ABSOLUTE</term>
	/// <term>SourceFile is a full source path. Do not look it up in the SourceDisksNames section of the INF file.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_SOURCEPATH_ABSOLUTE</term>
	/// <term>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the SourceDisksNames section of
	/// the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_IN_USE</term>
	/// <term>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_IN_USE_NEEDS_REBOOT</term>
	/// <term>If the file was in use during the copy operation, alert the user that the system requires a reboot.</term>
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
	/// </param>
	/// <param name="CopyMsgHandler">
	/// Optional pointer to a callback function to be notified of various conditions that may arise during the file copy.
	/// </param>
	/// <param name="Context">Pointer to a caller-defined value that is passed as the first parameter of the callback function.</param>
	/// <param name="FileWasInUse">
	/// Pointer to a variable in which this function returns a flag that indicates whether the file was in use. This parameter is required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If GetLastError returns NO_ERROR, the file copy operation was not completed. The file may not have been copied because the file
	/// copy operation was unnecessary or because the file callback function returned <c>FALSE</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API is typically used when installing new versions of system files that are likely to be in use. It updates a <c>BOOL</c>
	/// value that indicates whether the file was in use. If the file was in use, then the file copy operation is postponed until the
	/// system is rebooted.
	/// </para>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file installation, you must ensure it exists before you call
	/// <c>SetupInstallFileEx</c>. The setup functions do not check for the existence of and do not create UNC directories. If the
	/// target UNC directory does not exist, the file installation fails.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFileEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfileexa WINSETUPAPI BOOL SetupInstallFileExA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR SourceFile, PCSTR SourcePathRoot, PCSTR DestinationName, DWORD CopyStyle,
	// PSP_FILE_CALLBACK_A CopyMsgHandler, PVOID Context, PBOOL FileWasInUse );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFileExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFileEx([In, Optional] HINF InfHandle, in INFCONTEXT InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceFile,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourcePathRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DestinationName, SP_COPY CopyStyle,
		[Optional] PSP_FILE_CALLBACK? CopyMsgHandler, [In, Optional] IntPtr Context, [MarshalAs(UnmanagedType.Bool)] out bool FileWasInUse);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallFileEx</c> function installs a file as specified either by an INFCONTEXT returned by SetupFindXXXLine or
	/// explicitly by the filename and path information. This function is the same as SetupInstallFile, except that a <c>BOOL</c> is
	/// returned that indicates whether the file was in use.
	/// </para>
	/// <para>If a file is copied, the caller of this function is required to have privileges to write into the target directory.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Optional pointer to the handle to an INF file that contains the SourceDisksNames and SourceDisksFiles sections. If
	/// platform-specific sections exist for the user's system (for example, SourceDisksNames.x86 and SourceDisksFiles.x86), the
	/// platform-specific section are used. If InfContext is not specified and CopyStyle includes SP_COPY_SOURCE_ABSOLUTE or
	/// SP_COPY_SOURCEPATH_ABSOLUTE, InfHandle is ignored.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to context for a line in a Copy Files section in an INF file. The routine looks this file up in the
	/// SourceDisksFiles section of InfHandle to get file copy information. If InfContext is not specified, SourceFile must be.
	/// </param>
	/// <param name="SourceFile">
	/// Optional pointer to the filename (no path) of the file to copy. The file is looked up in the SourceDisksFiles section. The
	/// SourceFile parameter must be specified if InfContext is not. However, SourceFile is ignored if InfContext is specified.
	/// </param>
	/// <param name="SourcePathRoot">
	/// Optional pointer to the root path for the file to be copied (for example, A:\ or F:). Paths in the SourceDisksNames section are
	/// appended to this path. The SourcePathRoot parameter is ignored if CopyStyle includes the SP_COPY_SOURCE_ABSOLUTE flag.
	/// </param>
	/// <param name="DestinationName">
	/// Optional pointer to a new name for the copied file. If InfContext is specified, DestinationName supplies the filename only (no
	/// path) of the target file. This parameter can be <c>NULL</c> to indicate that the target file should have the same name as the
	/// source file. If InfContext is not specified, DestinationName supplies the full target path and filename for the target.
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation.</para>
	/// <para>These flags can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SP_COPY_DELETESOURCE</term>
	/// <term>Delete the source file upon successful copy. The caller is not notified if the delete fails.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_REPLACEONLY</term>
	/// <term>Copy the file only if doing so overwrites a file at the destination path.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NEWER_OR_SAME</term>
	/// <term>
	/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target. The file version information used during version checks is that specified in the dwFileVersionMS
	/// and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does not
	/// have version resources, or if they have identical version information, the source file is considered newer. If the source file
	/// is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If
	/// CopyMsgHandler is not specified, the file is not copied.
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
	/// Check whether the target file exists, and if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NODECOMP</term>
	/// <term>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying "f:\x86\cmd.ex_" to "\\install\temp" results in a target file of "\\install\temp\cmd.ex_". If
	/// the SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called
	/// "\\install\temp\cmd.exe". The filename part of DestinationName, if specified, is stripped and replaced with the filename of the
	/// source file. When SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_LANGUAGEAWARE</term>
	/// <term>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_SOURCE_ABSOLUTE</term>
	/// <term>SourceFile is a full source path. Do not look it up in the SourceDisksNames section of the INF file.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_SOURCEPATH_ABSOLUTE</term>
	/// <term>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the SourceDisksNames section of
	/// the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_IN_USE</term>
	/// <term>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_IN_USE_NEEDS_REBOOT</term>
	/// <term>If the file was in use during the copy operation, alert the user that the system requires a reboot.</term>
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
	/// </param>
	/// <param name="CopyMsgHandler">
	/// Optional pointer to a callback function to be notified of various conditions that may arise during the file copy.
	/// </param>
	/// <param name="Context">Pointer to a caller-defined value that is passed as the first parameter of the callback function.</param>
	/// <param name="FileWasInUse">
	/// Pointer to a variable in which this function returns a flag that indicates whether the file was in use. This parameter is required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If GetLastError returns NO_ERROR, the file copy operation was not completed. The file may not have been copied because the file
	/// copy operation was unnecessary or because the file callback function returned <c>FALSE</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API is typically used when installing new versions of system files that are likely to be in use. It updates a <c>BOOL</c>
	/// value that indicates whether the file was in use. If the file was in use, then the file copy operation is postponed until the
	/// system is rebooted.
	/// </para>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file installation, you must ensure it exists before you call
	/// <c>SetupInstallFileEx</c>. The setup functions do not check for the existence of and do not create UNC directories. If the
	/// target UNC directory does not exist, the file installation fails.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFileEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfileexa WINSETUPAPI BOOL SetupInstallFileExA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR SourceFile, PCSTR SourcePathRoot, PCSTR DestinationName, DWORD CopyStyle,
	// PSP_FILE_CALLBACK_A CopyMsgHandler, PVOID Context, PBOOL FileWasInUse );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFileExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFileEx([In, Optional] HINF InfHandle, [In, Optional] IntPtr InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceFile,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourcePathRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DestinationName, SP_COPY CopyStyle,
		[Optional] PSP_FILE_CALLBACK? CopyMsgHandler, [In, Optional] IntPtr Context, [MarshalAs(UnmanagedType.Bool)] out bool FileWasInUse);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallFilesFromInfSection</c> function queues all the files for an installation that are specified in the Copy
	/// Files, Delete Files, and Rename Files sections that are listed by an Install section.
	/// </para>
	/// <para>If a file is modified, the caller of this function is required to have privileges to write to the target directory.</para>
	/// </summary>
	/// <param name="InfHandle">The handle to an INF file that contains the section to be installed.</param>
	/// <param name="LayoutInfHandle">
	/// <para>An optional pointer to a handle to the INF file that contains the SourceDisksFiles and SourceDisksNames sections.</para>
	/// <para>If LayoutInfHandle is not specified, then the SourceDisksFiles and SourceDisksNames sections from InfHandle are used.</para>
	/// </param>
	/// <param name="FileQueue">The handle to the queue where installation operations are to be added.</param>
	/// <param name="SectionName">
	/// <para>
	/// The name of the Install section in the InfHandle parameter that lists the Copy Files, Delete Files, and Rename Files sections
	/// that contain the files to install.
	/// </para>
	/// <para>Use a <c>null</c>-terminated string.</para>
	/// </param>
	/// <param name="SourceRootPath">
	/// <para>An optional pointer to a root path to the source files to copy, for example, A:\ or \pegasus\win\install.</para>
	/// <para>Use a <c>null</c>-terminated string.</para>
	/// </param>
	/// <param name="CopyFlags">
	/// <para>An optional pointer to a set of flags that control the behavior of the file copy operation.</para>
	/// <para>The flags can be a combination of the following values.</para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Deletes the source file when the copy task succeeds.</para>
	/// <para>The caller is not notified if a delete task fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copies a file only to overwrite a file at the destination path.</para>
	/// <para>SP_COPY_NEWER_OR_SAME</para>
	/// <para>
	/// Examines each file that is copied to determine whether the version resources indicate that it is the same version, or not newer
	/// than an existing copy on the target.
	/// </para>
	/// <para>If the source file is not a newer or equal version, the function notifies the caller who can cancel the copy.</para>
	/// <para>
	/// The file version information that is used during version checks is specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the Win32 version functions.
	/// </para>
	/// <para>
	/// If one of the files does not have version resources, or if they have identical version information, the source file is
	/// considered newer.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examines each file that is being copied to determine whether its version resources indicate that it is not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>If the source file is newer but not equal in version to the existing target, the file is copied.</para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>Checks to determine whether or not the target file exists.</para>
	/// <para>If the target file exists, the function notifies the caller who can cancel the copy.</para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>Does not decompress a file.</para>
	/// <para>
	/// When this flag is set, the target file is not given the uncompressed form of the source name, for example, if you copy
	/// f:\x86\cmd.ex_ to \install\temp the result is the following target file: \install\temp\cmd.ex_.
	/// </para>
	/// <para>If the SP_COPY_NODECOMP flag is not specified, the file is decompressed and the target is called \install\temp\cmd.exe.</para>
	/// <para>
	/// The filename part of DestinationName, if specified, is deleted and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, language and version information cannot be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examines each file that is being copied to determine whether or not the language is different from the language of any existing
	/// file already on the target.
	/// </para>
	/// <para>If the language is different, the function notifies the caller who can cancel the copy task.</para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path.</para>
	/// <para>Do not look it up in the SourceDisksNames section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>SourcePathRoot is the full path part of the source file.</para>
	/// <para>
	/// Ignore the relative source that is specified in the SourceDisksNames section of the INF file for the source media where the file
	/// is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>Queues the file for copying on the next system reboot, if the target exists and is being used.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>Alerts the user that the system needs to be rebooted, if the file is being used during a copy operation.</para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Does not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>
	/// Checks to determine whether or not the target file exists, and if the target exists, the file is not overwritten and the caller
	/// is not notified.
	/// </para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examines each file that is being copied to identify that its version resources (or time stamps for non-image files) indicate
	/// that it is not newer than an existing copy on the target.
	/// </para>
	/// <para>If the file that is being copied is not newer, the file is not copied, and the caller is not notified.</para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>Warns that skipping a file may affect an installation if the user tries to skip a file.</para>
	/// <para>Use this flag for system-critical files.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupInstallFilesFromInfSection</c> can be called multiple times to queue the files that are specified in multiple INF
	/// sections. After the queue is committed successfully and the files are copied, renamed, and/or deleted,
	/// SetupInstallFromInfSection can be called to perform registry and INI installation operations.
	/// </para>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file installation, you must ensure that the UNC directory exists
	/// before you call <c>SetupInstallFilesFromInfSection</c>. The setup functions do not check for the existence of directories and do
	/// not create UNC directories. If the target UNC directory does not exist, the file installation fails.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFilesFromInfSection as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfilesfrominfsectiona WINSETUPAPI BOOL
	// SetupInstallFilesFromInfSectionA( HINF InfHandle, HINF LayoutInfHandle, HSPFILEQ FileQueue, PCSTR SectionName, PCSTR
	// SourceRootPath, UINT CopyFlags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFilesFromInfSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFilesFromInfSection(HINF InfHandle, [In, Optional] HINF LayoutInfHandle, HSPFILEQ FileQueue,
		[MarshalAs(UnmanagedType.LPTStr)] string SectionName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath, [Optional] SP_COPY CopyFlags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupInstallFromInfSection</c> function carries out all the directives in an INF file <c>Install</c> section.</para>
	/// <para>
	/// If the registry or file is modified, the caller of this function is required have privileges to write into the system or target directory.
	/// </para>
	/// </summary>
	/// <param name="Owner">
	/// Optional pointer to the window handle to the window that owns any dialog boxes that are generated during installation, such as
	/// for disk prompting or file copying. If Owner is not specified, these dialog boxes become top-level windows.
	/// </param>
	/// <param name="InfHandle">Handle to the INF file that contains the section to be processed.</param>
	/// <param name="SectionName">Name of the <c>Install</c> section in the INF file to process.</param>
	/// <param name="Flags">
	/// <para>Controls what actions to perform. The flags can be a combination of the following values.</para>
	/// <para>SPINST_INIFILES</para>
	/// <para>Perform INI-file operations ( <c>UpdateInis</c>, <c>UpdateIniFields</c> lines in the Install section being processed).</para>
	/// <para>SPINST_REGISTRY</para>
	/// <para>Perform registry operations ( <c>AddReg</c>, <c>DelReg</c> lines in the <c>Install</c> section being processed).</para>
	/// <para>SPINST_INI2REG</para>
	/// <para>Perform INI-file to registry operations ( <c>Ini2Reg</c> lines in the <c>Install</c> section being processed).</para>
	/// <para>SPINST_LOGCONFIG</para>
	/// <para>This flag is only used when installing a device driver.</para>
	/// <para>
	/// Perform logical configuration operations ( <c>LogConf</c> lines in the <c>Install</c> section being processed). This flag is
	/// only used if DeviceInfoSet and DeviceInfoData are specified.
	/// </para>
	/// <para>
	/// For more information about installing device drivers, <c>LogConf</c>, DeviceInfoSet, or DeviceInfoData, see the DDK Programmer's Guide.
	/// </para>
	/// <para>SPINST_FILES</para>
	/// <para>
	/// Perform file operations ( <c>CopyFiles</c>, <c>DelFiles</c>, <c>RenFiles</c> lines in the <c>Install</c> section being processed).
	/// </para>
	/// <para>SPINST_ALL</para>
	/// <para>Perform all installation operations.</para>
	/// <para>SPINST_REGISTERCALLBACKAWARE</para>
	/// <para>
	/// When using the <c>RegisterDlls</c> INF directive to self-register DLLs on Windows 2000, callers of
	/// <c>SetupInstallFromInfSection</c> may receive notifications on each file as it is registered or unregistered. To send a
	/// SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION notification to the callback routine, include
	/// SPINST_REGISTERCALLBACKAWARE plus either SPINST_REGSVR or SPINST_UNREGSVR. The caller must also set the MsgHandler parameter.
	/// </para>
	/// <para>SPINST_REGSVR</para>
	/// <para>
	/// To send a notification to the callback routine when registering a file, include SPINST_REGISTERCALLBACKAWARE plus SPINST_REGSVR
	/// in Flags. The caller must also specify the MsgHandler parameter.
	/// </para>
	/// <para>SPINST_UNREGSVR</para>
	/// <para>
	/// To send a notification to the callback routine when unregistering a file, include SPINST_REGISTERCALLBACKAWARE plus
	/// SPINST_UNREGSVR in the Flags. The caller must also specify the MsgHandler parameter.
	/// </para>
	/// </param>
	/// <param name="RelativeKeyRoot">
	/// Optional parameter that must be specified if Flags includes SPINST_REGISTRY or SPINST_INI2REG. Handle to a registry key to be
	/// used as the root when the INF file specifies HKR as the key. Note that this parameter is ignored if
	/// <c>SetupInstallFromInfSection</c> is called with the optional DeviceInfoSet and DeviceInfoData set.
	/// </param>
	/// <param name="SourceRootPath">
	/// Source root for file copies. An example would be A:\ or \pegasus\win\install. If Flags includes SPINST_FILES, and SourceRootPath
	/// is NULL, the system provides a default root path.
	/// </param>
	/// <param name="CopyFlags">
	/// <para>
	/// Optional parameter that must be specified if Flags includes SPINST_FILES. Specifies flags to be passed to the
	/// SetupQueueCopySection function when files are queued for copy. These flags may be a combination of the following values.
	/// </para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Delete the source file upon successful copy. The caller is not notified if the delete fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copy the file only if doing so would overwrite a file at the destination path.</para>
	/// <para>SP_COPY_NEWER_OR_SAME</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>
	/// The file version information used during version checks is that specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does
	/// not have version resources, or if they have identical version information, the source file is considered newer.
	/// </para>
	/// <para>
	/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel the
	/// copy. If CopyMsgHandler is not specified, the file is not copied.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
	/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
	/// </para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying f:/x86\cmd.ex_ to \install\temp results in a target file of \install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \install\temp\cmd.exe.
	/// The filename part of DestinationName, if specified, is stripped and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path. Do not look it up in the <c>SourceDisksNames</c> section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the <c>SourceDisksNames</c>
	/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>
	/// If the file was in use during the copy operation inform the user that the system needs to be rebooted. This flag is only used
	/// when later calling SetupPromptReboot or SetupScanFileQueue.
	/// </para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Do not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>Check whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
	/// </para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>
	/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
	/// </para>
	/// </param>
	/// <param name="MsgHandler">
	/// <para>
	/// Pointer to the callback routine. The callback routine must be in the format of FileCallback. See Notifications for more information.
	/// </para>
	/// <para>
	/// This parameter is optional only if the Flags parameter does not include SPINST_FILES, SPINST_REGISTERCALLBACKAWARE plus
	/// SPINST_REGSVR, or SPINST_UNREGSVR.
	/// </para>
	/// <para>
	/// MsgHandler must be set if Flags includes SPINST_FILES. In this case, notification is sent to the callback routine when the file
	/// queue is committed with SetupCommitFileQueue.
	/// </para>
	/// <para>
	/// MsgHandler must be set if Flags includes SPINST_REGISTERCALLBACKAWARE plus SPINST_REGSVR or SPINST_UNREGSVR. In this case a
	/// SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION is sent to the callback routine once each time a file is
	/// registered or unregistered using the <c>RegisterDlls</c> INF directive on Windows 2000.
	/// </para>
	/// </param>
	/// <param name="Context">
	/// Value to be passed to the callback function when the file queue built by this routine internally is committed via
	/// SetupCommitFileQueue. The Context parameter is optional only if the Flags parameter does not include SPINST_FIlLES. This
	/// parameter must be specified if Flags includes SPINST_FIlLES.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// Optional pointer to a handle to a device information set. For more information about the Device Installer setup functions, see
	/// the DDK Programmer's Guide.
	/// </param>
	/// <param name="DeviceInfoData">
	/// Optional pointer to a pointer to the <c>SP_DEVINFO_DATA</c> structure that provides a context to a specific element in the set
	/// specified by DeviceInfoSet. For more information about the Device Installer setup functions, see the DDK Programmer's Guide.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before you call
	/// <c>SetupInstallFromInfSection</c>. The setup functions do not check for the existence of and do not create UNC directories. If
	/// the target UNC directory does not exist, the file installation will fail.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFromInfSection as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfrominfsectiona WINSETUPAPI BOOL
	// SetupInstallFromInfSectionA( HWND Owner, HINF InfHandle, PCSTR SectionName, UINT Flags, HKEY RelativeKeyRoot, PCSTR
	// SourceRootPath, UINT CopyFlags, PSP_FILE_CALLBACK_A MsgHandler, PVOID Context, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA
	// DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFromInfSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFromInfSection([In, Optional] HWND Owner, HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName,
		SPINST Flags, [In, Optional] HKEY RelativeKeyRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath, [Optional] SP_COPY CopyFlags,
		[In, Optional] PSP_FILE_CALLBACK? MsgHandler, [In, Optional] IntPtr Context, [In, Optional] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupInstallFromInfSection</c> function carries out all the directives in an INF file <c>Install</c> section.</para>
	/// <para>
	/// If the registry or file is modified, the caller of this function is required have privileges to write into the system or target directory.
	/// </para>
	/// </summary>
	/// <param name="Owner">
	/// Optional pointer to the window handle to the window that owns any dialog boxes that are generated during installation, such as
	/// for disk prompting or file copying. If Owner is not specified, these dialog boxes become top-level windows.
	/// </param>
	/// <param name="InfHandle">Handle to the INF file that contains the section to be processed.</param>
	/// <param name="SectionName">Name of the <c>Install</c> section in the INF file to process.</param>
	/// <param name="Flags">
	/// <para>Controls what actions to perform. The flags can be a combination of the following values.</para>
	/// <para>SPINST_INIFILES</para>
	/// <para>Perform INI-file operations ( <c>UpdateInis</c>, <c>UpdateIniFields</c> lines in the Install section being processed).</para>
	/// <para>SPINST_REGISTRY</para>
	/// <para>Perform registry operations ( <c>AddReg</c>, <c>DelReg</c> lines in the <c>Install</c> section being processed).</para>
	/// <para>SPINST_INI2REG</para>
	/// <para>Perform INI-file to registry operations ( <c>Ini2Reg</c> lines in the <c>Install</c> section being processed).</para>
	/// <para>SPINST_LOGCONFIG</para>
	/// <para>This flag is only used when installing a device driver.</para>
	/// <para>
	/// Perform logical configuration operations ( <c>LogConf</c> lines in the <c>Install</c> section being processed). This flag is
	/// only used if DeviceInfoSet and DeviceInfoData are specified.
	/// </para>
	/// <para>
	/// For more information about installing device drivers, <c>LogConf</c>, DeviceInfoSet, or DeviceInfoData, see the DDK Programmer's Guide.
	/// </para>
	/// <para>SPINST_FILES</para>
	/// <para>
	/// Perform file operations ( <c>CopyFiles</c>, <c>DelFiles</c>, <c>RenFiles</c> lines in the <c>Install</c> section being processed).
	/// </para>
	/// <para>SPINST_ALL</para>
	/// <para>Perform all installation operations.</para>
	/// <para>SPINST_REGISTERCALLBACKAWARE</para>
	/// <para>
	/// When using the <c>RegisterDlls</c> INF directive to self-register DLLs on Windows 2000, callers of
	/// <c>SetupInstallFromInfSection</c> may receive notifications on each file as it is registered or unregistered. To send a
	/// SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION notification to the callback routine, include
	/// SPINST_REGISTERCALLBACKAWARE plus either SPINST_REGSVR or SPINST_UNREGSVR. The caller must also set the MsgHandler parameter.
	/// </para>
	/// <para>SPINST_REGSVR</para>
	/// <para>
	/// To send a notification to the callback routine when registering a file, include SPINST_REGISTERCALLBACKAWARE plus SPINST_REGSVR
	/// in Flags. The caller must also specify the MsgHandler parameter.
	/// </para>
	/// <para>SPINST_UNREGSVR</para>
	/// <para>
	/// To send a notification to the callback routine when unregistering a file, include SPINST_REGISTERCALLBACKAWARE plus
	/// SPINST_UNREGSVR in the Flags. The caller must also specify the MsgHandler parameter.
	/// </para>
	/// </param>
	/// <param name="RelativeKeyRoot">
	/// Optional parameter that must be specified if Flags includes SPINST_REGISTRY or SPINST_INI2REG. Handle to a registry key to be
	/// used as the root when the INF file specifies HKR as the key. Note that this parameter is ignored if
	/// <c>SetupInstallFromInfSection</c> is called with the optional DeviceInfoSet and DeviceInfoData set.
	/// </param>
	/// <param name="SourceRootPath">
	/// Source root for file copies. An example would be A:\ or \pegasus\win\install. If Flags includes SPINST_FILES, and SourceRootPath
	/// is NULL, the system provides a default root path.
	/// </param>
	/// <param name="CopyFlags">
	/// <para>
	/// Optional parameter that must be specified if Flags includes SPINST_FILES. Specifies flags to be passed to the
	/// SetupQueueCopySection function when files are queued for copy. These flags may be a combination of the following values.
	/// </para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Delete the source file upon successful copy. The caller is not notified if the delete fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copy the file only if doing so would overwrite a file at the destination path.</para>
	/// <para>SP_COPY_NEWER_OR_SAME</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>
	/// The file version information used during version checks is that specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does
	/// not have version resources, or if they have identical version information, the source file is considered newer.
	/// </para>
	/// <para>
	/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel the
	/// copy. If CopyMsgHandler is not specified, the file is not copied.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
	/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
	/// </para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying f:/x86\cmd.ex_ to \install\temp results in a target file of \install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \install\temp\cmd.exe.
	/// The filename part of DestinationName, if specified, is stripped and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path. Do not look it up in the <c>SourceDisksNames</c> section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the <c>SourceDisksNames</c>
	/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>
	/// If the file was in use during the copy operation inform the user that the system needs to be rebooted. This flag is only used
	/// when later calling SetupPromptReboot or SetupScanFileQueue.
	/// </para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Do not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>Check whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
	/// </para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>
	/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
	/// </para>
	/// </param>
	/// <param name="MsgHandler">
	/// <para>
	/// Pointer to the callback routine. The callback routine must be in the format of FileCallback. See Notifications for more information.
	/// </para>
	/// <para>
	/// This parameter is optional only if the Flags parameter does not include SPINST_FILES, SPINST_REGISTERCALLBACKAWARE plus
	/// SPINST_REGSVR, or SPINST_UNREGSVR.
	/// </para>
	/// <para>
	/// MsgHandler must be set if Flags includes SPINST_FILES. In this case, notification is sent to the callback routine when the file
	/// queue is committed with SetupCommitFileQueue.
	/// </para>
	/// <para>
	/// MsgHandler must be set if Flags includes SPINST_REGISTERCALLBACKAWARE plus SPINST_REGSVR or SPINST_UNREGSVR. In this case a
	/// SPFILENOTIFY_STARTREGISTRATION or SPFILENOTIFY_ENDREGISTRATION is sent to the callback routine once each time a file is
	/// registered or unregistered using the <c>RegisterDlls</c> INF directive on Windows 2000.
	/// </para>
	/// </param>
	/// <param name="Context">
	/// Value to be passed to the callback function when the file queue built by this routine internally is committed via
	/// SetupCommitFileQueue. The Context parameter is optional only if the Flags parameter does not include SPINST_FIlLES. This
	/// parameter must be specified if Flags includes SPINST_FIlLES.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// Optional pointer to a handle to a device information set. For more information about the Device Installer setup functions, see
	/// the DDK Programmer's Guide.
	/// </param>
	/// <param name="DeviceInfoData">
	/// Optional pointer to a pointer to the <c>SP_DEVINFO_DATA</c> structure that provides a context to a specific element in the set
	/// specified by DeviceInfoSet. For more information about the Device Installer setup functions, see the DDK Programmer's Guide.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before you call
	/// <c>SetupInstallFromInfSection</c>. The setup functions do not check for the existence of and do not create UNC directories. If
	/// the target UNC directory does not exist, the file installation will fail.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFromInfSection as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfrominfsectiona WINSETUPAPI BOOL
	// SetupInstallFromInfSectionA( HWND Owner, HINF InfHandle, PCSTR SectionName, UINT Flags, HKEY RelativeKeyRoot, PCSTR
	// SourceRootPath, UINT CopyFlags, PSP_FILE_CALLBACK_A MsgHandler, PVOID Context, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA
	// DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFromInfSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFromInfSection([In, Optional] HWND Owner, HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName,
		SPINST Flags, [In, Optional] HKEY RelativeKeyRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath, [Optional] SP_COPY CopyFlags,
		[In, Optional] PSP_FILE_CALLBACK? MsgHandler, [In, Optional] IntPtr Context, [In, Optional] HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallServicesFromInfSection</c> function performs service installation and deletion operations that are specified
	/// in the <c>Service Install</c> sections listed in the <c>Service</c> section of an INF file.
	/// </para>
	/// <para>A caller of this function is required to have access to the Service Control Manager, and privileges to modify services.</para>
	/// </summary>
	/// <param name="InfHandle">A handle to the INF file that contains the <c>Service</c> section.</param>
	/// <param name="SectionName">The name of the <c>Service</c> section to process. You should use a null-terminated string.</param>
	/// <param name="Flags">
	/// <para>The controls for the installation of each service in the specified section.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPSVCINST_TAGTOFRONT 0x001</term>
	/// <term>AddService section: move the service tag to the front of its group order list.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_DELETEEVENTLOGENTRY 0x004</term>
	/// <term>DelService section: delete the event log entry.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DISPLAYNAME 0x008</term>
	/// <term>AddService section: do not overwrite the display name if one already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_STARTTYPE 0x010</term>
	/// <term>AddService section: do not overwrite the start type value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_ERRORCONTROL 0x020</term>
	/// <term>AddService section: do not overwrite the error control value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_LOADORDERGROUP 0x040</term>
	/// <term>AddService section: do not overwrite the load order group if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DEPENDENCIES 0x080</term>
	/// <term>AddService section: do not overwrite the dependencies list if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DESCRIPTION 0x100</term>
	/// <term>AddService section: mark this service as the function driver for the device being installed.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STOPSERVICE 0x200</term>
	/// <term>DelService section: Stop the associated service specified in the entry before deleting the service.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_CLOBBER_SECURITY 0x400</term>
	/// <term>AddService section: Security settings the service are overwritten if the service already exists in the system.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STARTSERVICE 0x800</term>
	/// <term>
	/// AddService section: Start the service after the service is installed. This flag cannot be used to start a service that
	/// implements a Plug and Play (PnP) function driver or filter driver for a device. Otherwise, this flag can be used to start a
	/// user-mode or kernel-mode service that is managed by the Service Control Manager (SCM.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_REQUIREDPRIVILEGES 0x1000</term>
	/// <term>AddService section: Do not overwrite the given service's required privileges if the service already exists in the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. The function calls <c>SetLastError</c> with ERROR_SUCCESS_REBOOT_REQUIRED
	/// if a reboot of the system is required.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallServicesFromInfSection as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallservicesfrominfsectiona WINSETUPAPI BOOL
	// SetupInstallServicesFromInfSectionA( HINF InfHandle, PCSTR SectionName, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallServicesFromInfSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallServicesFromInfSection(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName, SPSVCINST Flags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallServicesFromInfSectionEx</c> function performs service installation and deletion operations that are
	/// specified in the <c>Service Install</c> sections listed in the <c>Service</c> section of an INF file.
	/// </para>
	/// <para>A caller of this function is required to have access to the Service Control Manager, and privileges to modify services.</para>
	/// </summary>
	/// <param name="InfHandle">A handle to the INF file that contains the <c>Service</c> section.</param>
	/// <param name="SectionName">The name of the <c>Service</c> section to process. You should use a null-terminated string.</param>
	/// <param name="Flags">
	/// <para>The controls for the installation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPSVCINST_TAGTOFRONT 0x001</term>
	/// <term>Move the service tag to the front of its group order list.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_ASSOCSERVICE 0x002</term>
	/// <term>AddService section: Mark this service as the function driver for the device being installed.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_DELETEEVENTLOGENTRY 0x004</term>
	/// <term>Delete the event log entry for a specified service.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DISPLAYNAME 0x008</term>
	/// <term>Do not overwrite the display name if one already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_STARTTYPE 0x010</term>
	/// <term>Do not overwrite the start type value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_ERRORCONTROL 0x020</term>
	/// <term>Do not overwrite the error control value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_LOADORDERGROUP 0x040</term>
	/// <term>Do not overwrite the load order group if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DEPENDENCIES 0x080</term>
	/// <term>Do not overwrite the dependencies list if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DESCRIPTION 0x100</term>
	/// <term>AddService section: mark this service as the function driver for the device being installed.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STOPSERVICE 0x200</term>
	/// <term>DelService section: Stop the associated service specified in the entry before deleting the service.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_CLOBBER_SECURITY 0x400</term>
	/// <term>AddService section: Security settings the service are overwritten if the service already exists in the system.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STARTSERVICE 0x800</term>
	/// <term>
	/// AddService section: Start the service after the service is installed. This flag cannot be used to start a service that
	/// implements a Plug and Play (PnP) function driver or filter driver for a device. Otherwise, this flag can be used to start a
	/// user-mode or kernel-mode service that is managed by the Service Control Manager (SCM.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_REQUIREDPRIVILEGES 0x1000</term>
	/// <term>AddService section: Do not overwrite the given service's required privileges if the service already exists in the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// <para>
	/// An optional pointer to a handle to a device information set. For more information, see the DDK Programmer's Guide. (This
	/// resource may not be available in some languages
	/// </para>
	/// <para>and countries.)</para>
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>
	/// An optional pointer to the <c>SP_DEVINFO_DATA</c> structure that provides a context to a specific element in the set that
	/// DeviceInfoSet specifies. For more information, see the DDK Programmer's Guide. (This resource may not be available in some languages
	/// </para>
	/// <para>and countries.)</para>
	/// </param>
	/// <param name="Reserved1">Reserved.</param>
	/// <param name="Reserved2">Reserved.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. The function calls <c>SetLastError</c> with ERROR_SUCCESS_REBOOT_REQUIRED
	/// if a reboot of the system is required.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallServicesFromInfSectionEx as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallservicesfrominfsectionexa WINSETUPAPI BOOL
	// SetupInstallServicesFromInfSectionExA( HINF InfHandle, PCSTR SectionName, DWORD Flags, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA
	// DeviceInfoData, PVOID Reserved1, PVOID Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallServicesFromInfSectionExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallServicesFromInfSectionEx(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName, SPSVCINST Flags,
		[In, Optional] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, [In, Optional] IntPtr Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallServicesFromInfSectionEx</c> function performs service installation and deletion operations that are
	/// specified in the <c>Service Install</c> sections listed in the <c>Service</c> section of an INF file.
	/// </para>
	/// <para>A caller of this function is required to have access to the Service Control Manager, and privileges to modify services.</para>
	/// </summary>
	/// <param name="InfHandle">A handle to the INF file that contains the <c>Service</c> section.</param>
	/// <param name="SectionName">The name of the <c>Service</c> section to process. You should use a null-terminated string.</param>
	/// <param name="Flags">
	/// <para>The controls for the installation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPSVCINST_TAGTOFRONT 0x001</term>
	/// <term>Move the service tag to the front of its group order list.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_ASSOCSERVICE 0x002</term>
	/// <term>AddService section: Mark this service as the function driver for the device being installed.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_DELETEEVENTLOGENTRY 0x004</term>
	/// <term>Delete the event log entry for a specified service.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DISPLAYNAME 0x008</term>
	/// <term>Do not overwrite the display name if one already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_STARTTYPE 0x010</term>
	/// <term>Do not overwrite the start type value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_ERRORCONTROL 0x020</term>
	/// <term>Do not overwrite the error control value if the service already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_LOADORDERGROUP 0x040</term>
	/// <term>Do not overwrite the load order group if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DEPENDENCIES 0x080</term>
	/// <term>Do not overwrite the dependencies list if it already exists.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_DESCRIPTION 0x100</term>
	/// <term>AddService section: mark this service as the function driver for the device being installed.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STOPSERVICE 0x200</term>
	/// <term>DelService section: Stop the associated service specified in the entry before deleting the service.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_CLOBBER_SECURITY 0x400</term>
	/// <term>AddService section: Security settings the service are overwritten if the service already exists in the system.</term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_STARTSERVICE 0x800</term>
	/// <term>
	/// AddService section: Start the service after the service is installed. This flag cannot be used to start a service that
	/// implements a Plug and Play (PnP) function driver or filter driver for a device. Otherwise, this flag can be used to start a
	/// user-mode or kernel-mode service that is managed by the Service Control Manager (SCM.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPSVCINST_NOCLOBBER_REQUIREDPRIVILEGES 0x1000</term>
	/// <term>AddService section: Do not overwrite the given service's required privileges if the service already exists in the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// <para>
	/// An optional pointer to a handle to a device information set. For more information, see the DDK Programmer's Guide. (This
	/// resource may not be available in some languages
	/// </para>
	/// <para>and countries.)</para>
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>
	/// An optional pointer to the <c>SP_DEVINFO_DATA</c> structure that provides a context to a specific element in the set that
	/// DeviceInfoSet specifies. For more information, see the DDK Programmer's Guide. (This resource may not be available in some languages
	/// </para>
	/// <para>and countries.)</para>
	/// </param>
	/// <param name="Reserved1">Reserved.</param>
	/// <param name="Reserved2">Reserved.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. The function calls <c>SetLastError</c> with ERROR_SUCCESS_REBOOT_REQUIRED
	/// if a reboot of the system is required.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallServicesFromInfSectionEx as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallservicesfrominfsectionexa WINSETUPAPI BOOL
	// SetupInstallServicesFromInfSectionExA( HINF InfHandle, PCSTR SectionName, DWORD Flags, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA
	// DeviceInfoData, PVOID Reserved1, PVOID Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallServicesFromInfSectionExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallServicesFromInfSectionEx(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName, SPSVCINST Flags,
		[In, Optional] HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, [In, Optional] IntPtr Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupIterateCabinet</c> function iterates through all the files in a cabinet and sends a notification to a callback
	/// function for each file found.
	/// </para>
	/// </summary>
	/// <param name="CabinetFile">Cabinet (.CAB) file to iterate through.</param>
	/// <param name="Reserved">Not currently used.</param>
	/// <param name="MsgHandler">
	/// Pointer to a FileCallback routine that will process the notifications <c>SetupIterateCabinet</c> returns as it iterates through
	/// the files in the cabinet file. The callback routine may then return a value specifying whether to decompress, copy, or skip the file.
	/// </param>
	/// <param name="Context">
	/// Context value that is passed into the routine specified in MsgHandler. This enables the callback routine to track values between
	/// notifications, without having to use global variables.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupIterateCabinet as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupiteratecabineta WINSETUPAPI BOOL
	// SetupIterateCabinetA( PCSTR CabinetFile, DWORD Reserved, PSP_FILE_CALLBACK_A MsgHandler, PVOID Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupIterateCabinetA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupIterateCabinet([MarshalAs(UnmanagedType.LPTStr)] string CabinetFile, [Optional] uint Reserved,
		PSP_FILE_CALLBACK MsgHandler, IntPtr Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupLogError</c> function writes an error message to a log file. It is meant to be used during the installation of
	/// Windows, but it is always available. It is not intended to be used after the operating system is installed — the event log
	/// should be used instead.
	/// </para>
	/// </summary>
	/// <param name="MessageString">
	/// Pointer to the string that should be saved to Setup's log. The message must end with a return-linefeed combination (\r\n). You
	/// should use a null-terminated string. The null-terminated string should not exceed the size of the destination buffer. The
	/// message is always saved to the action log, setupact.log. If Severity is <c>LogSevWarning</c>, <c>LogSevError</c>, or
	/// <c>LogSevFatalError</c>, Setup also saves the message to the error log, setuperr.log. Both logs are stored in the Windows directory.
	/// </param>
	/// <param name="Severity">
	/// Severity of the message, one of the following: <c>LogSevInformation</c>, <c>LogSevWarning</c>, <c>LogSevError</c>, or <c>LogSevFatalError</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <list type="bullet">
	/// <item>
	/// <term>The action log is intended for recording all modifications made to the system during installation of Windows.</term>
	/// </item>
	/// <item>
	/// <term>The error log is intended for errors during installation of Windows only.</term>
	/// </item>
	/// <item>
	/// <term>The MessageString parameter may be formatted further by Setup (though it does no additional processing now).</term>
	/// </item>
	/// <item>
	/// <term>The error log will be presented to the user at the end of system setup.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupLogError as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuplogerrora WINSETUPAPI BOOL SetupLogErrorA( LPCSTR
	// MessageString, LogSeverity Severity );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupLogErrorA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupLogError([MarshalAs(UnmanagedType.LPTStr)] string MessageString, LogSeverity Severity);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupLogFile</c> function adds an entry to the log file.</para>
	/// </summary>
	/// <param name="FileLogHandle">
	/// Handle to the file log as returned by SetupInitializeFileLog. The caller must not have passed SPFILELOG_QUERYONLY when the log
	/// file was initialized.
	/// </param>
	/// <param name="LogSectionName">
	/// Optional pointer to the name for a logical grouping of names within the log file. You should use a <c>null</c>-terminated
	/// string. Required if SPFILELOG_SYSTEMLOG was not passed when the file log was initialized. Otherwise, this parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="SourceFilename">
	/// Name of the file as it exists on the source media from which it was installed. This name should be in whatever format is
	/// meaningful to the caller. You should use a <c>null</c>-terminated string.
	/// </param>
	/// <param name="TargetFilename">
	/// Name of the file as it exists on the target. This name should be in whatever format is meaningful to the caller. You should use
	/// a <c>null</c>-terminated string.
	/// </param>
	/// <param name="Checksum">Optional pointer to a checksum value. Required for the system log.</param>
	/// <param name="DiskTagfile">
	/// Optional pointer to the tagfile for the media from which the file was installed. You should use a <c>null</c>-terminated string.
	/// The <c>null</c>-terminated string should not exceed the size of the destination buffer. Ignored for the system log if
	/// SPFILELOG_OEMFILE is not specified. Required for the system log if SPFILELOG_OEMFILE is specified. Otherwise, this parameter can
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="DiskDescription">
	/// Optional pointer to the human-readable description of the media from which the file was installed. You should use a
	/// <c>null</c>-terminated string. Ignored for the system log if SPFILELOG_OEMFILE is not specified in the Flags parameter. Required
	/// for the system log if SPFILELOG_OEMFILE is specified in the Flags parameter. Otherwise, this parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="OtherInfo">
	/// Optional pointer to additional information to be associated with the file. You should use a <c>null</c>-terminated string. This
	/// parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// This parameter can be SPFILELOG_OEMFILE, which is meaningful only for the system log and indicates that the file is not supplied
	/// by Microsoft. This parameter can be used to convert an existing file's entry, such as when an OEM overwrites a
	/// Microsoft-supplied system file.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupLogFile as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuplogfilea WINSETUPAPI BOOL SetupLogFileA( HSPFILELOG
	// FileLogHandle, PCSTR LogSectionName, PCSTR SourceFilename, PCSTR TargetFilename, DWORD Checksum, PCSTR DiskTagfile, PCSTR
	// DiskDescription, PCSTR OtherInfo, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupLogFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupLogFile(HSPFILELOG FileLogHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? LogSectionName,
		[MarshalAs(UnmanagedType.LPTStr)] string SourceFilename, [MarshalAs(UnmanagedType.LPTStr)] string TargetFilename, [Optional] uint Checksum,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? DiskTagfile, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DiskDescription,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? OtherInfo, SPLOGFILE Flags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupOpenAppendInfFile</c> function appends the information in an INF file to an INF file previously opened by SetupOpenInfFile.
	/// </para>
	/// </summary>
	/// <param name="FileName">
	/// If not <c>NULL</c>, FileName points to a <c>null</c>-terminated string containing the name (and optionally the path) of the INF
	/// file to be opened. If the filename does not contain path separator characters, it is searched for, first in the %windir%\inf
	/// directory, and then in the %windir%\system32 directory. If the filename contains path separator characters, it is assumed to be
	/// a full path specification and no further processing is performed on it. If FileName is <c>NULL</c>, the INF filename is
	/// retrieved from the LayoutFile value of the <c>Version</c> section in the existing INF file. The same search logic is applied to
	/// the filename retrieved from the LayoutFile key.
	/// </param>
	/// <param name="InfHandle">Existing INF handle to which this INF file will be appended.</param>
	/// <param name="ErrorLine">
	/// Optional pointer to a variable to which this function returns the (1-based) line number where an error occurred during loading
	/// of the INF file. This value is generally reliable only if GetLastError does not return ERROR_NOT_ENOUGH_MEMORY. If an
	/// out-of-memory condition does occur, ErrorLine may be 0.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If FileName was not specified and there was no LayoutFile value in the <c>Version</c> section of the existing INF File,
	/// GetLastError returns ERROR_INVALID_DATA.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function requires a Windows INF file. Some older INF file formats may not be supported. In this case, the function returns
	/// <c>FALSE</c> and GetLastError will return ERROR_INVALID_PARAMETER. The main purpose of this function is to combine an INF file
	/// with the source file location information contained in the file specified in the LayoutFile entry of the <c>Version</c> section
	/// (typically, LAYOUT.INF).
	/// </para>
	/// <para>The ERROR_WRONG_INF_STYLE may also be returned by <c>SetupOpenAppendInfFile</c> if the INF file uses an older format.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupOpenAppendInfFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupopenappendinffilea WINSETUPAPI BOOL
	// SetupOpenAppendInfFileA( PCSTR FileName, HINF InfHandle, PUINT ErrorLine );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupOpenAppendInfFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupOpenAppendInfFile([Optional, MarshalAs(UnmanagedType.LPTStr)] string? FileName, HINF InfHandle, out uint ErrorLine);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupOpenFileQueue</c> function creates a setup file queue.</para>
	/// </summary>
	/// <returns>
	/// If the function succeeds, it returns a handle to a setup file queue. If there is not enough memory to create the queue, the
	/// function returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// After the file queue has been committed and is no longer needed, SetupCloseFileQueue should be called to release the resources
	/// allocated during <c>SetupOpenFileQueue</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupopenfilequeue WINSETUPAPI HSPFILEQ SetupOpenFileQueue();
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupOpenFileQueue")]
	public static extern SafeHSPFILEQ SetupOpenFileQueue();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupOpenInfFile</c> function opens an INF file and returns a handle to it.</para>
	/// </summary>
	/// <param name="FileName">
	/// Pointer to a null-terminated string containing the name (and optional path) of the INF file to be opened. If the filename does
	/// not contain path separator characters, it is searched for, first in the %windir%\inf directory, and then in the
	/// %windir%\system32 directory. If the filename contains path separator characters, it is assumed to be a full path specification
	/// and no further processing is performed on it.
	/// </param>
	/// <param name="InfClass">
	/// Optional pointer to a null-terminated string containing the class of INF file desired. This string must match the Class value of
	/// the <c>Version</c> section (for example, Class=Net). If there is no entry in the Class value, but there is an entry for
	/// ClassGUID in the <c>Version</c> section, the corresponding class name for that GUID is retrieved and used for the comparison.
	/// </param>
	/// <param name="InfStyle">
	/// <para>Style of INF file to open or search for. This parameter can be a combination of the following flags.</para>
	/// <para>INF_STYLE_OLDNT</para>
	/// <para>A legacy INF file format.</para>
	/// <para>INF_STYLE_WIN4</para>
	/// <para>A Windows INF file format.</para>
	/// </param>
	/// <param name="ErrorLine">
	/// Optional pointer to a variable to which this function returns the (1-based) line number where an error occurred during loading
	/// of the INF file. This value is generally reliable only if GetLastError does not return ERROR_NOT_ENOUGH_MEMORY. If an
	/// out-of-memory condition does occur, ErrorLine may be 0.
	/// </param>
	/// <returns>
	/// The function returns a handle to the opened INF file if it is successful. Otherwise, the return value is INVALID_HANDLE_VALUE.
	/// Extended error information can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the load fails because the INF file type does not match InfClass, the function returns INVALID_HANDLE_VALUE and a call to
	/// GetLastError returns ERROR_CLASS_MISMATCH.
	/// </para>
	/// <para>
	/// If multiple INF file styles are specified, the style of the INF file opened can be determined by calling the
	/// SetupGetInfInformation function.
	/// </para>
	/// <para>
	/// Because there may be more than one class GUID with the same class name, callers interested in INF files of a particular class
	/// (that is, a particular class GUID) should retrieve the ClassGUID value from the INF file by calling SetupQueryInfVersionInformation.
	/// </para>
	/// <para>
	/// For legacy INF files, the InfClass string must match the type specified in the OptionType value of the <c>Identification</c>
	/// section in the INF file (for example, OptionType=NetAdapter).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupopeninffilea WINSETUPAPI HINF SetupOpenInfFileA(
	// PCSTR FileName, PCSTR InfClass, DWORD InfStyle, PUINT ErrorLine );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupOpenInfFileA")]
	public static extern SafeHINF SetupOpenInfFile([MarshalAs(UnmanagedType.LPTStr)] string FileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? InfClass, INF_STYLE InfStyle, out uint ErrorLine);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupOpenLog</c> function opens the log files.</para>
	/// </summary>
	/// <param name="Erase">Must be FALSE.</param>
	/// <returns><c>TRUE</c> if the log file can be opened. <c>FALSE</c> if an error occurs. To get the error code, call GetLastError.</returns>
	/// <remarks>The log files are located in the Windows directory, and the file names are Setupact.log and Setuperr.log.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupopenlog WINSETUPAPI BOOL SetupOpenLog( BOOL Erase );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupOpenLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupOpenLog([MarshalAs(UnmanagedType.Bool)] bool Erase);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupOpenMasterInf</c> function opens the master INF file that contains file and layout information for files shipped
	/// with Windows.
	/// </para>
	/// </summary>
	/// <returns>
	/// If <c>SetupOpenMasterInf</c> is successful, it returns a handle to the opened INF file that contains file/layout information for
	/// files shipped with Windows. Otherwise, the return value is INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupopenmasterinf WINSETUPAPI HINF SetupOpenMasterInf();
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupOpenMasterInf")]
	public static extern HINF SetupOpenMasterInf();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupPromptForDisk</c> function displays a dialog box that prompts the user for a disk.</para>
	/// </summary>
	/// <param name="hwndParent">Handle to the parent window for this dialog box.</param>
	/// <param name="DialogTitle">
	/// Optional pointer to a <c>null</c>-terminated string specifying the dialog title. If this parameter is <c>NULL</c>, the default
	/// of ""%s--Files Needed"" (localized) is used. The "%s" is replaced with the text retrieved from the parent window. If no text is
	/// retrieved from the parent window, the title is "Files Needed".
	/// </param>
	/// <param name="DiskName">
	/// Optional pointer to a <c>null</c>-terminated string specifying the name of the disk to insert. If this parameter is <c>NULL</c>,
	/// the default "(Unknown)" (localized) is used.
	/// </param>
	/// <param name="PathToSource">
	/// Optional pointer to a <c>null</c>-terminated string specifying the path part of the expected location of the file, for example,
	/// F:\x86. If not specified, the path where <c>SetupPromptForDisk</c> most recently located a file is used. If that list is empty,
	/// a system default is used.
	/// </param>
	/// <param name="FileSought">
	/// Pointer to a <c>null</c>-terminated string specifying the name of the file needed (filename part only). The filename is
	/// displayed if the user clicks on the <c>Browse</c> button. This routine looks for the file using its compressed form names;
	/// therefore, you can pass cmd.exe and not worry that the file actually exists as cmd.ex_ on the source media.
	/// </param>
	/// <param name="TagFile">
	/// <para>
	/// Optional pointer to a <c>null</c>-terminated string specifying a tag file (filename part only) that identifies the presence of a
	/// particular removable media volume. If the currently selected path would place the file on removable media and a tag file is
	/// specified, <c>SetupPromptForDisk</c> looks for the tag file at the root of the drive to determine whether to continue.
	/// </para>
	/// <para>
	/// For example, if PathToSource is A:\x86, the tagfile is disk1.tag, and the user types B:\x86 into the edit control of the prompt
	/// dialog box, the routine looks for B:\disk1.tag to determine whether to continue. If the tag file is not found, the function
	/// looks for the tagfile using PathToSource.
	/// </para>
	/// <para>
	/// If a tag file is not specified, removable media works just like non-removable media and FileSought is looked for before continuing.
	/// </para>
	/// </param>
	/// <param name="DiskPromptStyle">
	/// <para>Specifies the behavior of the dialog box. This parameter can be a combination of the following flags.</para>
	/// <para>IDF_CHECKFIRST</para>
	/// <para>Check for the file/disk before displaying the prompt dialog box, and, if present, return DPROMPT_SUCCESS immediately.</para>
	/// <para>IDF_NOBEEP</para>
	/// <para>Prevent the dialog box from beeping to get the user's attention when it first appears.</para>
	/// <para>IDF_NOBROWSE</para>
	/// <para>Do not display the browse option.</para>
	/// <para>IDF_NOCOMPRESSED</para>
	/// <para>Do not check for compressed versions of the source file.</para>
	/// <para>IDF_NODETAILS</para>
	/// <para>Do not display detail information.</para>
	/// <para>IDF_NOFOREGROUND</para>
	/// <para>Prevent the dialog box from becoming the foreground window.</para>
	/// <para>IDF_NOSKIP</para>
	/// <para>Do not display the skip option.</para>
	/// <para>IDF_OEMDISK</para>
	/// <para>Prompt for a disk supplied by a hardware manufacturer.</para>
	/// <para>IDF_WARNIFSKIP</para>
	/// <para>Warn the user that skipping a file may affect the installation.</para>
	/// </param>
	/// <param name="PathBuffer">
	/// Optional pointer to a buffer that, upon return, receives the path (no filename) of the location specified by the user through
	/// the dialog box. You should use a <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of
	/// the destination buffer. You can call the function once to get the required buffer size, allocate the necessary memory, and then
	/// call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer
	/// size. See the Remarks section.
	/// </param>
	/// <param name="PathBufferSize">
	/// Size of the buffer pointed to by PathBuffer, in characters. It should be at least MAX_PATH long. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="PathRequiredSize">
	/// Optional pointer to a variable that receives the required size for PathBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following values.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a PathBuffer of <c>NULL</c> and a PathBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by PathRequiredSize. If the function succeeds in this, the return
	/// value is NO_ERROR. Otherwise, the return value is one of the values described in the Return Values section.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupPromptForDisk as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuppromptfordiska WINSETUPAPI UINT SetupPromptForDiskA(
	// HWND hwndParent, PCSTR DialogTitle, PCSTR DiskName, PCSTR PathToSource, PCSTR FileSought, PCSTR TagFile, DWORD DiskPromptStyle,
	// StrPtrAnsi PathBuffer, DWORD PathBufferSize, PDWORD PathRequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupPromptForDiskA")]
	public static extern uint SetupPromptForDisk(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DialogTitle,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? DiskName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? PathToSource,
		[MarshalAs(UnmanagedType.LPTStr)] string FileSought, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? TagFile, IDF DiskPromptStyle,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? PathBuffer, uint PathBufferSize, out uint PathRequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupPromptReboot</c> function asks the user if he wants to reboot the system, optionally dependent on whether any files
	/// in a committed file queue were in use during a file operation. If the user answers "yes" to the prompt, shutdown is initiated
	/// before this routine returns.
	/// </para>
	/// </summary>
	/// <param name="FileQueue">
	/// Optional pointer to a handle to the file queue upon which to base the decision about whether shutdown is necessary. If FileQueue
	/// is not specified, <c>SetupPromptReboot</c> assumes shutdown is necessary and asks the user what to do.
	/// </param>
	/// <param name="Owner">Handle for the parent window to own windows created by this function.</param>
	/// <param name="ScanOnly">
	/// <para>Indicates whether or not to prompt the user when <c>SetupPromptReboot</c> is called.</para>
	/// <para>
	/// If <c>TRUE</c>, the user is never asked about rebooting, and system shutdown is not initiated. In this case, FileQueue must be
	/// specified. If <c>FALSE</c>, the user is asked about rebooting, as previously described.
	/// </para>
	/// <para>Use ScanOnly to determine if shutdown is necessary separately from actually initiating a shutdown.</para>
	/// </param>
	/// <returns>
	/// <para>The function returns a combination of the following flags or –1 if an error occurs.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuppromptreboot WINSETUPAPI INT SetupPromptReboot(
	// HSPFILEQ FileQueue, HWND Owner, BOOL ScanOnly );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupPromptReboot")]
	public static extern int SetupPromptReboot([In, Optional] HSPFILEQ FileQueue, [In, Optional] HWND Owner, [MarshalAs(UnmanagedType.Bool)] bool ScanOnly);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueryDrivesInDiskSpaceList</c> function fills a buffer with a list of the drives referenced by the file operations
	/// listed in the disk-space list.
	/// </para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list.</param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer that receives the drive specifications, such as "X:" or "\server\share". You should use a
	/// <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of the destination buffer. This
	/// parameter can be <c>NULL</c>. If this parameter is not specified and no error occurs, the function returns a nonzero value and
	/// RequiredSize receives the buffer size required to hold the drive specifications.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed by ReturnBuffer, in characters. This includes the <c>null</c> terminator. This parameter is ignored
	/// if ReturnBuffer is not specified.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the size of the buffer required to hold the <c>null</c>-terminated list of drives,
	/// in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If the GetLastError function returns ERROR_INSUFFICIENT_BUFFER, ReturnBuffer was specified, but ReturnBufferSize indicated that
	/// the supplied buffer was too small.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryDrivesInDiskSpaceList as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupquerydrivesindiskspacelista WINSETUPAPI BOOL
	// SetupQueryDrivesInDiskSpaceListA( HDSKSPC DiskSpace, StrPtrAnsi ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryDrivesInDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryDrivesInDiskSpaceList(HDSKSPC DiskSpace, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueryFileLog</c> function returns information from a setup file log.</para>
	/// </summary>
	/// <param name="FileLogHandle">Handle to the file log as returned by SetupInitializeFileLog.</param>
	/// <param name="LogSectionName">
	/// Optional pointer to the section name for the log file in a format that is meaningful to the caller. You should use a
	/// <c>null</c>-terminated string. Required for non-system logs. If no LogSectionName is specified for a system log, a default is supplied.
	/// </param>
	/// <param name="TargetFilename">
	/// Name of the file for which log information is desired. You should use a <c>null</c>-terminated string.
	/// </param>
	/// <param name="DesiredInfo">
	/// <para>
	/// Indicates what information should be returned to the DataOut buffer. This parameter can be one of the following enumerated values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SetupFileLogSourceFile name</term>
	/// <term>Name of the source file as it exists on the source media</term>
	/// </item>
	/// <item>
	/// <term>SetupFileLogChecksum</term>
	/// <term>A checksum value used by the system log</term>
	/// </item>
	/// <item>
	/// <term>SetupFileLogDiskTagfile</term>
	/// <term>Name of the tag file of the media source containing the source file</term>
	/// </item>
	/// <item>
	/// <term>SetupFileLogDiskDescription</term>
	/// <term>The human-readable description of the media where the source file resides</term>
	/// </item>
	/// <item>
	/// <term>SetupFileLogOtherInfo</term>
	/// <term>Additional information associated with the logged file</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the value of DesiredInfo is greater than <c>SetupFileLogOtherInfo</c> the function will fail, and GetLastError will return ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="DataOut">
	/// Optional pointer to a buffer in which this function returns the requested information for the file. You should use a
	/// <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of the destination buffer. You can
	/// call the function once to get the required buffer size, allocate the necessary memory, and then call the function a second time
	/// to retrieve the data. See the Remarks section. Using this technique, you can avoid errors due to an insufficient buffer size.
	/// Not all information is provided for every file. An error is not returned if an empty entry for the file exists in the log. This
	/// parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the DataOut buffer, in characters. This includes the <c>null</c> terminator. If the buffer is too small and DataOut is
	/// specified, data is not stored in the buffer and the function returns zero. If DataOut is not specified, the ReturnBufferSize
	/// parameter is ignored.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size of DataOut, in characters. This number includes the <c>null</c> terminator.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a DataOut of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// If the value of DesiredInfo is greater than <c>SetupFileLogOtherInfo</c> the function will fail, and GetLastError will return ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryFileLog as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryfileloga WINSETUPAPI BOOL SetupQueryFileLogA(
	// HSPFILELOG FileLogHandle, PCSTR LogSectionName, PCSTR TargetFilename, SetupFileLogInfo DesiredInfo, StrPtrAnsi DataOut, DWORD
	// ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryFileLogA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryFileLog(HSPFILELOG FileLogHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? LogSectionName,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetFilename, SetupFileLogInfo DesiredInfo, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? DataOut,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueryInfFileInformation</c> function returns an INF filename from an SP_INF_INFORMATION structure to a buffer.</para>
	/// </summary>
	/// <param name="InfInformation">
	/// Pointer to an SP_INF_INFORMATION structure returned from a call to the SetupGetInfInformation function.
	/// </param>
	/// <param name="InfIndex">
	/// Index of the constituent INF filename to retrieve. This index can be in the range [0, InfInformation.InfCount). Meaning that the
	/// values zero through, but not including, InfInformation.InfCount are valid.
	/// </param>
	/// <param name="ReturnBuffer">
	/// If not <c>NULL</c>, ReturnBuffer is a pointer to a buffer in which this function returns the full INF filename. You should use a
	/// <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of the destination buffer. You can
	/// call the function once to get the required buffer size, allocate the necessary memory, and then call the function a second time
	/// to retrieve the data. See the Remarks section. Using this technique, you can avoid errors due to an insufficient buffer size.
	/// This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by the ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// If not <c>NULL</c>, pointer to a variable that receives the required size for the ReturnBuffer buffer, in characters. This
	/// includes the <c>null</c> terminator. If ReturnBuffer is specified and the actual size is larger than ReturnBufferSize, the
	/// function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryInfFileInformation as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryinffileinformationa WINSETUPAPI BOOL
	// SetupQueryInfFileInformationA( PSP_INF_INFORMATION InfInformation, UINT InfIndex, StrPtrAnsi ReturnBuffer, DWORD ReturnBufferSize,
	// PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryInfFileInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryInfFileInformation(in SP_INF_INFORMATION InfInformation, uint InfIndex,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueryInfOriginalFileInformation</c> function returns the original name of an OEM INF file.</para>
	/// </summary>
	/// <param name="InfInformation">
	/// Pointer to an SP_INF_INFORMATION structure returned from a call to the SetupGetInfInformation function.
	/// </param>
	/// <param name="InfIndex">
	/// Index of the constituent INF file name to retrieve. This index can be in the range [0, InfInformation.InfCount). Meaning that
	/// the values zero through, but not including, InfInformation.InfCount are valid.
	/// </param>
	/// <param name="AlternatePlatformInfo">
	/// Optional pointer to an SP_ALTPLATFORM_INFO_V1 or SP_ALTPLATFORM_INFO_V2 structure used to pass information for an alternate
	/// platform to <c>SetupQueryInfOriginalFileInformation</c>.
	/// </param>
	/// <param name="OriginalFileInfo">
	/// Pointer to an SP_ORIGINAL_FILE_INFO structure that receives the original INF file name and catalog file information returned by <c>SetupQueryInfOriginalFileInformation</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryInfOriginalFileInformation as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryinforiginalfileinformationa WINSETUPAPI BOOL
	// SetupQueryInfOriginalFileInformationA( PSP_INF_INFORMATION InfInformation, UINT InfIndex, PSP_ALTPLATFORM_INFO
	// AlternatePlatformInfo, PSP_ORIGINAL_FILE_INFO_A OriginalFileInfo );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryInfOriginalFileInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryInfOriginalFileInformation(in SP_INF_INFORMATION InfInformation, uint InfIndex,
		in SP_ALTPLATFORM_INFO AlternatePlatformInfo, out SP_ORIGINAL_FILE_INFO OriginalFileInfo);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueryInfOriginalFileInformation</c> function returns the original name of an OEM INF file.</para>
	/// </summary>
	/// <param name="InfInformation">
	/// Pointer to an SP_INF_INFORMATION structure returned from a call to the SetupGetInfInformation function.
	/// </param>
	/// <param name="InfIndex">
	/// Index of the constituent INF file name to retrieve. This index can be in the range [0, InfInformation.InfCount). Meaning that
	/// the values zero through, but not including, InfInformation.InfCount are valid.
	/// </param>
	/// <param name="AlternatePlatformInfo">
	/// Optional pointer to an SP_ALTPLATFORM_INFO_V1 or SP_ALTPLATFORM_INFO_V2 structure used to pass information for an alternate
	/// platform to <c>SetupQueryInfOriginalFileInformation</c>.
	/// </param>
	/// <param name="OriginalFileInfo">
	/// Pointer to an SP_ORIGINAL_FILE_INFO structure that receives the original INF file name and catalog file information returned by <c>SetupQueryInfOriginalFileInformation</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryInfOriginalFileInformation as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryinforiginalfileinformationa WINSETUPAPI BOOL
	// SetupQueryInfOriginalFileInformationA( PSP_INF_INFORMATION InfInformation, UINT InfIndex, PSP_ALTPLATFORM_INFO
	// AlternatePlatformInfo, PSP_ORIGINAL_FILE_INFO_A OriginalFileInfo );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryInfOriginalFileInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryInfOriginalFileInformation(in SP_INF_INFORMATION InfInformation, uint InfIndex,
		[In, Optional] IntPtr AlternatePlatformInfo, out SP_ORIGINAL_FILE_INFO OriginalFileInfo);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueryInfVersionInformation</c> function returns INF file version information from an SP_INF_INFORMATION structure to
	/// a buffer.
	/// </para>
	/// </summary>
	/// <param name="InfInformation">
	/// Pointer to an SP_INF_INFORMATION structure previously returned from a call to the SetupGetInfInformation function.
	/// </param>
	/// <param name="InfIndex">
	/// Index of the constituent INF file to retrieve version information from. This index can be in the range [0,
	/// InfInformation.InfCount). Meaning that the values zero through, but not including, InfInformation.InfCount are valid.
	/// </param>
	/// <param name="Key">
	/// Optional pointer to a <c>null</c>-terminated string containing the key name whose associated string is to be retrieved. If this
	/// parameter is <c>NULL</c>, all resource keys are copied to the supplied buffer. Each string is <c>null</c>-terminated, with an
	/// extra <c>null</c> at the end of the list.
	/// </param>
	/// <param name="ReturnBuffer">
	/// If not <c>NULL</c>, ReturnBuffer points to a call-supplied character buffer in which this function returns the INF file style.
	/// You should use a <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of the destination
	/// buffer. You can call the function once to get the required buffer size, allocate the necessary memory, and then call the
	/// function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size. See
	/// the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by the ReturnBuffer parameter, in characters. This number includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// If not <c>NULL</c>, pointer to a variable that receives the size required for the buffer pointed to by the ReturnBuffer
	/// parameter, in characters. This number includes the <c>null</c> terminator. If ReturnBuffer is specified and the actual size is
	/// larger than the value specified by ReturnBufferSize, the function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// If <c>SetupQueryInfVersionInformation</c> is called on a legacy INF file , then version information is generated from the legacy
	/// INF file in the following manner:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The OptionType key in the <c>Identification</c> section of the legacy file is returned as the Class key value.</term>
	/// </item>
	/// <item>
	/// <term>The FileType key in the <c>Signature</c> section of the legacy INF file becomes the Signature key value.</term>
	/// </item>
	/// <item>
	/// <term>If the value of the FileType key of the legacy INF file is MICROSOFT_FILE, then the Provider key value is set to "Microsoft".</term>
	/// </item>
	/// </list>
	/// <para>The following table summarizes how the information is translated before it is passed into the SP_INF_INFORMATION structure.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Legacy file information</term>
	/// <term>Windows INF information</term>
	/// </listheader>
	/// <item>
	/// <term/>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>(if the FileType is MICROSOFT_FILE)</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueryInfVersionInformation as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryinfversioninformationa WINSETUPAPI BOOL
	// SetupQueryInfVersionInformationA( PSP_INF_INFORMATION InfInformation, UINT InfIndex, PCSTR Key, StrPtrAnsi ReturnBuffer, DWORD
	// ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueryInfVersionInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueryInfVersionInformation(in SP_INF_INFORMATION InfInformation, uint InfIndex,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQuerySourceList</c> function queries the current list of installation sources. The list is built from the system and
	/// user-specific lists, and potentially overridden by a temporary list (see SetupSetSourceList).
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Specifies which list to query. This parameter can be any combination of the following values.</para>
	/// <para>SRCLIST_SYSTEM</para>
	/// <para>Query the system list.</para>
	/// <para>SRCLIST_USER</para>
	/// <para>Query the per-user list.</para>
	/// <para>
	/// <c>Note</c> If the system and the user lists are both retrieved, they are merged with those items in the system list that appear first.
	/// </para>
	/// <para><c>Note</c> If none of the preceding flags are specified, the entire current (merged) list is returned.</para>
	/// <para>SRCLIST_NOSTRIPPLATFORM</para>
	/// <para>
	/// Normally, all paths are stripped of a platform-specific component if it is the final component. For example, a path stored in
	/// the registry as f:\x86 is returned as f:. If this flag is specified, the platform-specific component is not stripped.
	/// </para>
	/// </param>
	/// <param name="List">
	/// Pointer to a variable in which this function returns a pointer to an array of sources. Use a null-terminated string. The caller
	/// must free this array with a call to SetupFreeSourceList.
	/// </param>
	/// <param name="Count">Pointer to a variable in which this function returns the number of sources in the list.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQuerySourceList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupquerysourcelista WINSETUPAPI BOOL
	// SetupQuerySourceListA( DWORD Flags, PCSTR **List, PUINT Count );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQuerySourceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQuerySourceList(SRCLIST Flags, out IntPtr List, out uint Count);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQuerySourceList</c> function queries the current list of installation sources. The list is built from the system and
	/// user-specific lists, and potentially overridden by a temporary list (see SetupSetSourceList).
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Specifies which list to query. This parameter can be any combination of the following values.</para>
	/// <para>SRCLIST_SYSTEM</para>
	/// <para>Query the system list.</para>
	/// <para>SRCLIST_USER</para>
	/// <para>Query the per-user list.</para>
	/// <para>
	/// <c>Note</c> If the system and the user lists are both retrieved, they are merged with those items in the system list that appear first.
	/// </para>
	/// <para><c>Note</c> If none of the preceding flags are specified, the entire current (merged) list is returned.</para>
	/// <para>SRCLIST_NOSTRIPPLATFORM</para>
	/// <para>
	/// Normally, all paths are stripped of a platform-specific component if it is the final component. For example, a path stored in
	/// the registry as f:\x86 is returned as f:. If this flag is specified, the platform-specific component is not stripped.
	/// </para>
	/// </param>
	/// <param name="List">Returns a pointer to an array of sources.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupquerysourcelista WINSETUPAPI BOOL
	// SetupQuerySourceListA( DWORD Flags, PCSTR **List, PUINT Count );
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQuerySourceListA")]
	public static bool SetupQuerySourceList(SRCLIST Flags, out string[] List)
	{
		List = new string[0];
		if (!SetupQuerySourceList(Flags, out var list, out var count))
			return false;
		try
		{
			List = list.ToStringEnum((int)count).WhereNotNull().ToArray();
			return true;
		}
		finally
		{
			SetupFreeSourceList(list, count);
		}
	}

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQuerySpaceRequiredOnDrive</c> function examines a disk space list to determine the space that is required to perform
	/// all the file operations listed for a specific drive.
	/// </para>
	/// </summary>
	/// <param name="DiskSpace">The handle to a disk space list.</param>
	/// <param name="DriveSpec">
	/// <para>A pointer to a null-terminated string that specifies the drive where space information is to be returned.</para>
	/// <para>This should be in the form "x:" or "\server\share".</para>
	/// </param>
	/// <param name="SpaceRequired">
	/// <para>
	/// If the function succeeds, this parameter receives the amount of additional space that is required to process all the file
	/// operations listed in the disk space list for the drive that DriveSpec specifies.
	/// </para>
	/// <para>
	/// The <c>SetupQuerySpaceRequiredOnDrive</c> function calculates the additional space required on the target drive by checking for
	/// preexisting versions of the files on the target drive.
	/// </para>
	/// <para>
	/// For example, if a file operation copies a 2000-byte file, FIRST.EXE, to the directory, C:\MYPROG, the
	/// <c>SetupQuerySpaceRequiredOnDrive</c> function automatically checks for a preexisting version of that file in that directory. If
	/// a preexisting version of C:\MYPROG\FIRST.EXE has a file size of 500 bytes, the additional space required on the drive C for that
	/// operation is 1500 bytes.
	/// </para>
	/// <para>
	/// The value received can be 0 (zero) or a negative number, if additional space is not required, or if space is freed on the target drive.
	/// </para>
	/// <para>
	/// If FIRST.EXE in the preceding example is being deleted from the drive C, the amount of space required is 2000 bytes, or the
	/// space freed on drive C.
	/// </para>
	/// <para>
	/// If the preexisting version has a file size of 5000 bytes, then the disk space required to replace it with the 2000-byte
	/// FIRST.EXE is 3000 bytes.
	/// </para>
	/// <para>File sizes are rounded to disk cluster boundaries.</para>
	/// </param>
	/// <param name="Reserved1">Reserved; must be 0 (zero).</param>
	/// <param name="Reserved2">Reserved; must be 0 (zero).</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero value and SpaceRequired receives the amount of space required by the
	/// file operations listed in the current disk space list.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_DRIVE</term>
	/// <term>The specified drive is not on the disk-space list.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified DiskSpace handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified DriveSpec string is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQuerySpaceRequiredOnDrive as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueryspacerequiredondrivea WINSETUPAPI BOOL
	// SetupQuerySpaceRequiredOnDriveA( HDSKSPC DiskSpace, PCSTR DriveSpec, LONGLONG *SpaceRequired, PVOID Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQuerySpaceRequiredOnDriveA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQuerySpaceRequiredOnDrive(HDSKSPC DiskSpace, [MarshalAs(UnmanagedType.LPTStr)] string DriveSpec,
		out long SpaceRequired, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueueCopy</c> function adds a single file copy operation to a setup file queue.</para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="SourceRootPath">
	/// Pointer to a <c>null</c>-terminated string that specifies the root of the source for this copy, such as A:.
	/// </param>
	/// <param name="SourcePath">
	/// Pointer to a <c>null</c>-terminated string that specifies the path relative to SourceRootPath where the file can be found. This
	/// parameter may be <c>NULL</c>.
	/// </param>
	/// <param name="SourceFilename">
	/// Pointer to a <c>null</c>-terminated string that specifies the file name part of the file to be copied.
	/// </param>
	/// <param name="SourceDescription">
	/// Pointer to a <c>null</c>-terminated string that specifies a description of the source media to be used during disk prompts. This
	/// parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="SourceTagfile">
	/// Pointer to a <c>null</c>-terminated string that specifies a tag file whose presence at SourceRootPath indicates the presence of
	/// the source media. This parameter may be <c>NULL</c>. If not specified, the file itself will be used as the tag file if required.
	/// </param>
	/// <param name="TargetDirectory">
	/// Pointer to a <c>null</c>-terminated string that specifies the directory where the file is to be copied.
	/// </param>
	/// <param name="TargetFilename">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the target file. This parameter may be <c>NULL</c>. If not
	/// specified, the target file will have the same name as the source file.
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Specifies the behavior of the file copy operation. This parameter may be a combination of the following values.</para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Delete the source file upon successful copy. The caller is not notified if the delete fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copy the file only if doing so would overwrite a file at the destination path. The caller is not notified.</para>
	/// <para>SP_COPY_NEWER_OR SAME</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>
	/// The file version information used during version checks is that specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does
	/// not have version resources, or if they have identical version information, the source file is considered newer.
	/// </para>
	/// <para>
	/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel the
	/// copy. If CopyMsgHandler is not specified, the file is not copied.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
	/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
	/// </para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying f:\x86\cmd.ex_ to \install\temp results in a target file of \install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \install\temp\cmd.exe.
	/// The filename part of DestinationName, if specified, is stripped and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path. Do not look it up in the <c>SourceDisksNames</c> section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the <c>SourceDisksNames</c>
	/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>If the file was in use during the copy operation, alert the user that the system needs to be rebooted.</para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Do not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>Check whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
	/// </para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>
	/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before the queue is
	/// committed. The setup functions do not check for the existence of and do not create UNC directories. If the target UNC directory
	/// does not exist, the file copy will fail.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueCopy as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuecopya WINSETUPAPI BOOL SetupQueueCopyA(
	// HSPFILEQ QueueHandle, PCSTR SourceRootPath, PCSTR SourcePath, PCSTR SourceFilename, PCSTR SourceDescription, PCSTR SourceTagfile,
	// PCSTR TargetDirectory, PCSTR TargetFilename, DWORD CopyStyle );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueCopyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueCopy(HSPFILEQ QueueHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourcePath, [MarshalAs(UnmanagedType.LPTStr)] string SourceFilename,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceDescription, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceTagfile,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetDirectory, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetFilename, SP_COPY CopyStyle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueueCopyIndirect</c> function is an extended form of SetupQueueCopy passing additional parameters as a structure
	/// (SP_FILE_COPY_PARAMS). Other than this, the behavior is identical.
	/// </para>
	/// </summary>
	/// <param name="CopyParams">Pointer to a SP_FILE_COPY_PARAMS structure that describes the file copy operation.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is an nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before the queue is
	/// committed. The setup functions do not check for the existence of and do not create UNC directories. If the target UNC directory
	/// does not exist, the file copy will fail.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueCopyIndirect as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuecopyindirecta WINSETUPAPI BOOL
	// SetupQueueCopyIndirectA( PSP_FILE_COPY_PARAMS_A CopyParams );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueCopyIndirectA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueCopyIndirect(in SP_FILE_COPY_PARAMS CopyParams);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueueCopySection</c> function places all the files in a section of an INF file in a setup queue for copying. The
	/// section must be in the correct <c>Copy Files</c> format and the INF file must contain <c>SourceDisksFiles</c> and
	/// <c>SourceDisksNames</c> sections (or have had the INF files containing those sections appended).
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="SourceRootPath">
	/// Pointer to a null-terminated string that specifies the root of the source for this copy, such as A:.
	/// </param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>SourceDisksFiles</c> and <c>SourceDisksNames</c> sections. If ListInfHandle is
	/// not specified, InfHandle contains the section names. If platform-specific sections exist for the user's system (for example,
	/// SourceDisksNames.x86 and SourceDisksFiles.x86), the platform-specific section will be used.
	/// </param>
	/// <param name="ListInfHandle">
	/// Optional handle to an open INF file that contains the section to queue for copying. If ListInfHandle is not specified, InfHandle
	/// is assumed to contain the section.
	/// </param>
	/// <param name="Section">Pointer to a null-terminated string that specifies the name of the section to be queued for copy.</param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation. These flags may be a combination of the following values.</para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Delete the source file upon successful copy. The caller is not notified if the delete fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copy the file only if doing so would overwrite a file at the destination path.</para>
	/// <para>SP_COPY_NEWER_OR_SAME</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is either equal in version or not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>
	/// The file version information used during version checks is that specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does
	/// not have version resources, or if they have identical version information, the source file is considered newer.
	/// </para>
	/// <para>
	/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel the
	/// copy. If CopyMsgHandler is not specified, the file is not copied.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
	/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
	/// </para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying f:\x86s\cmd.ex_ to \install\temp results in a target file of \install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \install\temp\cmd.exe.
	/// The filename part of DestinationName, if specified, is stripped and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path. Do not look it up in the <c>SourceDisksNames</c> section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the <c>SourceDisksNames</c>
	/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>If the file was in use during the copy operation, alert the user that the system needs to be rebooted.</para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Do not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>Check whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
	/// </para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>
	/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before the queue is
	/// committed. The setup functions do not check for the existence of and do not create UNC directories. If the target UNC directory
	/// does not exist, the file copy will fail.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueCopySection as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuecopysectiona WINSETUPAPI BOOL
	// SetupQueueCopySectionA( HSPFILEQ QueueHandle, PCSTR SourceRootPath, HINF InfHandle, HINF ListInfHandle, PCSTR Section, DWORD
	// CopyStyle );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueCopySectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueCopySection(HSPFILEQ QueueHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath,
		HINF InfHandle, [In, Optional] HINF ListInfHandle, [MarshalAs(UnmanagedType.LPTStr)] string Section, SP_COPY CopyStyle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueueDefaultCopy</c> function adds a single file to a setup file queue for copying, using the default source media
	/// and destination as specified in an INF file.
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>SourceDisksFiles</c> and <c>SourceDisksNames</c> sections. If platform-specific
	/// sections exist for the user's system (for example, <c>SourceDisksNames.x86</c> and <c>SourceDisksFiles.x86</c>), the
	/// platform-specific section will be used.
	/// </param>
	/// <param name="SourceRootPath">
	/// Pointer to a null-terminated string that specifies the root directory of the source for this copy such as A:.
	/// </param>
	/// <param name="SourceFilename">Pointer to a null-terminated string that specifies the file name of the file to be copied.</param>
	/// <param name="TargetFilename">Pointer to a null-terminated string that specifies the file name of the target file.</param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation. These flags may be a combination of the following values.</para>
	/// <para>SP_COPY_DELETESOURCE</para>
	/// <para>Delete the source file upon successful copy. The caller is not notified if the delete fails.</para>
	/// <para>SP_COPY_REPLACEONLY</para>
	/// <para>Copy the file only if doing so would overwrite a file at the destination path.</para>
	/// <para>SP_COPY_NEWER_OR_SAME</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is either equal in version or not newer than an
	/// existing copy on the target.
	/// </para>
	/// <para>
	/// The file version information used during version checks is that specified in the <c>dwFileVersionMS</c> and
	/// <c>dwFileVersionLS</c> members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does
	/// not have version resources, or if they have identical version information, the source file is considered newer.
	/// </para>
	/// <para>
	/// If the source file is not equal in version or newer, and CopyMsgHandler is specified, the caller is notified and may cancel the
	/// copy. If CopyMsgHandler is not specified, the file is not copied.
	/// </para>
	/// <para>SP_COPY_NEWER_ONLY</para>
	/// <para>
	/// Examine each file being copied to see if its version resources indicate that it is not newer than an existing copy on the
	/// target. If the source file is newer but not equal in version to the existing target, the file is copied.
	/// </para>
	/// <para>SP_COPY_NOOVERWRITE</para>
	/// <para>
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </para>
	/// <para>SP_COPY_NODECOMP</para>
	/// <para>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying f:\x86\cmd.ex_ to \install\temp results in a target file of \install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \install\temp\cmd.exe.
	/// The filename part of DestinationName, if specified, is stripped and replaced with the filename of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
	/// </para>
	/// <para>SP_COPY_LANGUAGEAWARE</para>
	/// <para>
	/// Examine each file being copied to see if its language differs from the language of any existing file already on the target. If
	/// so, and CopyMsgHandler is specified, the caller is notified and may cancel the copy. If CopyMsgHandler is not specified, the
	/// file is not copied.
	/// </para>
	/// <para>SP_COPY_SOURCE_ABSOLUTE</para>
	/// <para>SourceFile is a full source path. Do not look it up in the <c>SourceDisksNames</c> section of the INF file.</para>
	/// <para>SP_COPY_SOURCEPATH_ABSOLUTE</para>
	/// <para>
	/// SourcePathRoot is the full path part of the source file. Ignore the relative source specified in the <c>SourceDisksNames</c>
	/// section of the INF file for the source media where the file is located. This flag is ignored if SP_COPY_SOURCE_ABSOLUTE is specified.
	/// </para>
	/// <para>SP_COPY_FORCE_IN_USE</para>
	/// <para>If the target exists, behave as if it is in use and queue the file for copying on the next system reboot.</para>
	/// <para>SP_COPY_IN_USE_NEEDS_REBOOT</para>
	/// <para>If the file was in use during the copy operation, alert the user that the system needs to be rebooted.</para>
	/// <para>SP_COPY_NOSKIP</para>
	/// <para>Do not give the user the option to skip a file.</para>
	/// <para>SP_COPY_FORCE_NOOVERWRITE</para>
	/// <para>Check whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</para>
	/// <para>SP_COPY_FORCE_NEWER</para>
	/// <para>
	/// Examine each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not notified.
	/// </para>
	/// <para>SP_COPY_WARNIFSKIP</para>
	/// <para>
	/// If the user tries to skip a file, warn them that skipping a file may affect the installation. (Used for system-critical files.)
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a UNC directory is specified as the target directory of a file copy operation, you must ensure it exists before the queue is
	/// committed. The setup functions do not check for the existence of and do not create UNC directories. If the target UNC directory
	/// does not exist, the file copy will fail.
	/// </para>
	/// <para>
	/// The default destination used by this function is specified by the <c>DefaultDestDir</c> key in the <c>DestinationDirs</c>
	/// section of an INF file.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueDefaultCopy as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuedefaultcopya WINSETUPAPI BOOL
	// SetupQueueDefaultCopyA( HSPFILEQ QueueHandle, HINF InfHandle, PCSTR SourceRootPath, PCSTR SourceFilename, PCSTR TargetFilename,
	// DWORD CopyStyle );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueDefaultCopyA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueDefaultCopy(HSPFILEQ QueueHandle, HINF InfHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceRootPath,
		[MarshalAs(UnmanagedType.LPTStr)] string SourceFilename, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetFilename, SP_COPY CopyStyle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueueDelete</c> function places an individual file delete operation on a setup file queue.</para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="PathPart1">
	/// Pointer to a <c>null</c>-terminated string that specifies the first part of the path of the file to be deleted. If PathPart2 is
	/// <c>NULL</c>, PathPart1 is the full path of the file to be deleted.
	/// </param>
	/// <param name="PathPart2">
	/// Pointer to a <c>null</c>-terminated string that specifies the second part of the path of the file to be deleted. This parameter
	/// may be <c>NULL</c>. This is appended to PathPart1 to form the full path of the file to be deleted. The function checks for and
	/// collapses duplicated path separators when it combines PathPart1 and PathPart2.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Because delete operations are assumed to take place on fixed media, the user will not be prompted when the queue is committed.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueDelete as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuedeletea WINSETUPAPI BOOL SetupQueueDeleteA(
	// HSPFILEQ QueueHandle, PCSTR PathPart1, PCSTR PathPart2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueDeleteA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueDelete(HSPFILEQ QueueHandle, [MarshalAs(UnmanagedType.LPTStr)] string PathPart1,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? PathPart2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueueDeleteSection</c> function queues all the files in a section of an INF file for deletion. The section must be
	/// in the correct <c>Delete Files</c> format and the INF file must contain a <c>DestinationDirs</c> section.
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>DestinationDirs</c> section. If ListInfHandle is not specified, InfHandle
	/// contains the section name.
	/// </param>
	/// <param name="ListInfHandle">
	/// Optional handle to an open INF file that contains the section to queue for deletion. If ListInfHandle is not specified,
	/// InfHandle is assumed to contain the section name.
	/// </param>
	/// <param name="Section">Pointer to a null-terminated string that specifies the name of the section to be queued for deletion.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueDeleteSection as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuedeletesectiona WINSETUPAPI BOOL
	// SetupQueueDeleteSectionA( HSPFILEQ QueueHandle, HINF InfHandle, HINF ListInfHandle, PCSTR Section );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueDeleteSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueDeleteSection(HSPFILEQ QueueHandle, HINF InfHandle, [In, Optional] HINF ListInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string Section);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupQueueRename</c> function places an individual file rename operation on a setup file queue.</para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="SourcePath">
	/// Pointer to a null-terminated string that specifies the source path of the file to be renamed. If SourceFileName is not
	/// specified, SourcePath is assumed to be the full path.
	/// </param>
	/// <param name="SourceFilename">
	/// Pointer to a null-terminated string that specifies the file name part of the file to be renamed. If not specified, SourcePath is
	/// the full path.
	/// </param>
	/// <param name="TargetPath">
	/// Pointer to a null-terminated string that specifies the target directory. When this parameter is specified, the rename operation
	/// is actually a move operation. If TargetPath is not specified, the file is renamed but remains in its current location.
	/// </param>
	/// <param name="TargetFilename">Pointer to a null-terminated string that specifies the new name for the source file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Because rename operations are assumed to take place on fixed media, the user will not be prompted when the queue is committed.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueRename as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuerenamea WINSETUPAPI BOOL SetupQueueRenameA(
	// HSPFILEQ QueueHandle, PCSTR SourcePath, PCSTR SourceFilename, PCSTR TargetPath, PCSTR TargetFilename );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueRenameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueRename(HSPFILEQ QueueHandle, [MarshalAs(UnmanagedType.LPTStr)] string SourcePath,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceFilename, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetPath,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetFilename);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupQueueRenameSection</c> function queues a section in an INF file for renaming. The section must be in the correct
	/// rename list section format and the INF file must contain a <c>DestinationDirs</c> section.
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="InfHandle">
	/// Handle to the INF file that contains the <c>DestinationDirs</c> section. If ListInfHandle is not specified, InfHandle contains
	/// the section name.
	/// </param>
	/// <param name="ListInfHandle">
	/// Optional handle to an INF file that contains the section to queue for renaming. If ListInfHandle is not specified, InfHandle is
	/// assumed to contain the section name.
	/// </param>
	/// <param name="Section">Name of the section to be queued for renaming.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You cannot queue file moves with <c>SetupQueueRenameSection</c> because the form of a rename list section limits section
	/// renaming to within the same directory.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupQueueRenameSection as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupqueuerenamesectiona WINSETUPAPI BOOL
	// SetupQueueRenameSectionA( HSPFILEQ QueueHandle, HINF InfHandle, HINF ListInfHandle, PCSTR Section );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupQueueRenameSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupQueueRenameSection(HSPFILEQ QueueHandle, HINF InfHandle, [In, Optional] HINF ListInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string Section);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupRemoveFileLogEntry</c> function removes an entry or section from a file log.</para>
	/// </summary>
	/// <param name="FileLogHandle">
	/// Handle to the file log as returned by SetupInitializeFileLog. The caller must not have passed SPFILELOG_QUERYONLY when the log
	/// file was initialized.
	/// </param>
	/// <param name="LogSectionName">
	/// Pointer to a <c>null</c>-terminated string that specifies the name for a logical grouping of names within the log file. Required
	/// for non-system logs. Otherwise, LogSectionName may be <c>NULL</c>.
	/// </param>
	/// <param name="TargetFilename">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the file as it exists on the target. This name should be
	/// in whatever format is meaningful to the caller. If <c>NULL</c>, the section specified by LogSectionName is removed. The main
	/// section cannot be removed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRemoveFileLogEntry as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupremovefilelogentrya WINSETUPAPI BOOL
	// SetupRemoveFileLogEntryA( HSPFILELOG FileLogHandle, PCSTR LogSectionName, PCSTR TargetFilename );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRemoveFileLogEntryA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupRemoveFileLogEntry(HSPFILELOG FileLogHandle, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? LogSectionName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetFilename);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupRemoveFromDiskSpaceList</c> function removes a file delete or copy operation from a disk-space list.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to a disk-space list.</param>
	/// <param name="TargetFilespec">
	/// Pointer to a null-terminated string that specifies the file name of the file to remove from the disk-space list. This is
	/// typically a fully qualified path. Otherwise, the path must be relative to the current directory.
	/// </param>
	/// <param name="Operation">
	/// <para>File operation to be removed from the list. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILEOP_DELETE</term>
	/// <term>A file delete operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_COPY</term>
	/// <term>A file copy operation.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved1">Must be zero.</param>
	/// <param name="Reserved2">Must be zero.</param>
	/// <returns>
	/// <para>
	/// If the file was not in the list, the <c>SetupRemoveFromDiskSpaceList</c> function returns a nonzero value and GetLastError
	/// returns ERROR_INVALID_DRIVE or ERROR_INVALID_NAME. If the file was in the list then upon success the routine returns a nonzero
	/// value and <c>GetLastError</c> returns NO_ERROR.
	/// </para>
	/// <para>If the routine fails for some other reason, it returns zero and GetLastError returns extended error information.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRemoveFromDiskSpaceList as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupremovefromdiskspacelista WINSETUPAPI BOOL
	// SetupRemoveFromDiskSpaceListA( HDSKSPC DiskSpace, PCSTR TargetFilespec, UINT Operation, PVOID Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRemoveFromDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupRemoveFromDiskSpaceList(HDSKSPC DiskSpace, [MarshalAs(UnmanagedType.LPTStr)] string TargetFilespec,
		FILEOP Operation, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupRemoveFromSourceList</c> function removes a value from the list of installation sources for either the current user
	/// or the system. The system and user lists are merged at run time.
	/// </para>
	/// <para>A caller of this function is required have administrative privileges, otherwise the function fails.</para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Specifies which source to remove from the list. This parameter can be any combination of the following values.</para>
	/// <para>SRCLIST_SYSTEM</para>
	/// <para>Remove the source to the per-system list. The caller must be an administrator.</para>
	/// <para>SRCLIST_USER</para>
	/// <para>Remove the source to the per-user list.</para>
	/// <para>SRCLIST_SYSIFADMIN</para>
	/// <para>
	/// If the caller is an administrator, the source is removed from the per-system list; if the caller is not an administrator, the
	/// source is removed from the per-user list for the current user.
	/// </para>
	/// <para>
	/// <c>Note</c> If a temporary list is currently in use (see SetupSetSourceList), the preceding flags are ignored and the source is
	/// removed from the temporary list.
	/// </para>
	/// <para>SRCLIST_SUBDIRS</para>
	/// <para>Remove all subdirectories of the source.</para>
	/// </param>
	/// <param name="Source">Pointer to a null-terminated string that specifies the source to remove from the list.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRemoveFromSourceList as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupremovefromsourcelista WINSETUPAPI BOOL
	// SetupRemoveFromSourceListA( DWORD Flags, PCSTR Source );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRemoveFromSourceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupRemoveFromSourceList(SRCLIST Flags, [MarshalAs(UnmanagedType.LPTStr)] string Source);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupRemoveInstallSectionFromDiskSpaceList</c> function searches an <c>Install</c> section of an INF file for
	/// <c>CopyFiles</c> and <c>DelFiles</c> lines, and removes the file operations specified in those sections from a disk-space list.
	/// </para>
	/// </summary>
	/// <param name="DiskSpace">Handle to a disk-space list.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>Install</c> section. If LayoutInfHandle is not specified, the INF file must also
	/// contain the section specified by SectionName.
	/// </param>
	/// <param name="LayoutInfHandle">
	/// Optional handle to the INF file that contains the <c>SourceDisksFiles</c> sections. Otherwise, that section is assumed to exist
	/// in the INF file specified by InfHandle.
	/// </param>
	/// <param name="SectionName">
	/// Pointer to a null-terminated string that specifies the name of the section to be added to the disk-space list.
	/// </param>
	/// <param name="Reserved1">Must be zero.</param>
	/// <param name="Reserved2">Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRemoveInstallSectionFromDiskSpaceList as an alias which automatically selects the ANSI or
	/// Unicode version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the
	/// encoding-neutral alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors.
	/// For more information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupremoveinstallsectionfromdiskspacelista WINSETUPAPI
	// BOOL SetupRemoveInstallSectionFromDiskSpaceListA( HDSKSPC DiskSpace, HINF InfHandle, HINF LayoutInfHandle, PCSTR SectionName,
	// PVOID Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRemoveInstallSectionFromDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupRemoveInstallSectionFromDiskSpaceList(HDSKSPC DiskSpace, HINF InfHandle, [In, Optional] HINF LayoutInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string SectionName, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupRemoveSectionFromDiskSpaceList</c> function removes the file delete or copy operations listed in a <c>Copy Files</c>
	/// section of an INF file from a disk-space list.
	/// </para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>SourceDisksFiles</c> section. If ListInfHandle is not specified, this INF file
	/// must also contain the section specified by SectionName.
	/// </param>
	/// <param name="ListInfHandle">
	/// Optional handle to an open INF file that contains the section to remove from the disk-space list. Otherwise, InfHandle must
	/// contain the section specified by SectionName.
	/// </param>
	/// <param name="SectionName">
	/// Pointer to a null-terminated string that specifies the name of the <c>Copy Files</c> or <c>Delete Files</c> section to remove
	/// from the disk-space list.
	/// </param>
	/// <param name="Operation">
	/// <para>File operation to remove from the list. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILEOP_DELETE</term>
	/// <term>A file delete operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_COPY</term>
	/// <term>A file copy operation.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved1">Must be zero.</param>
	/// <param name="Reserved2">Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The file operations removed by the <c>SetupRemoveSectionFromDiskSpaceList</c> function are typically those that have been added
	/// to the list by using the SetupAddSectionToDiskSpaceList function, though this is not a requirement. The
	/// <c>SetupRemoveSectionFromDiskSpaceList</c> function ignores files in the INF section that are not listed in the disk-space list.
	/// </para>
	/// <para>This function requires a Windows INF file. Some older INF file formats may not be supported.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRemoveSectionFromDiskSpaceList as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupremovesectionfromdiskspacelista WINSETUPAPI BOOL
	// SetupRemoveSectionFromDiskSpaceListA( HDSKSPC DiskSpace, HINF InfHandle, HINF ListInfHandle, PCSTR SectionName, UINT Operation,
	// PVOID Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRemoveSectionFromDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupRemoveSectionFromDiskSpaceList(HDSKSPC DiskSpace, HINF InfHandle, [In, Optional] HINF ListInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string SectionName, FILEOP Operation, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>RenameError</c> function generates a dialog box that informs the user of a file renaming error.</para>
	/// </summary>
	/// <param name="hwndParent">Handle to the parent window for this dialog box.</param>
	/// <param name="DialogTitle">
	/// Pointer to a <c>null</c>-terminated string that specifies the error dialog box title. This parameter may be <c>NULL</c>. If this
	/// parameter is <c>NULL</c>, the default title of "Rename Error" (localized) is used.
	/// </param>
	/// <param name="SourceFile">
	/// Pointer to a <c>null</c>-terminated string that specifies the full path of the source file on which the operation failed.
	/// </param>
	/// <param name="TargetFile">
	/// Pointer to a <c>null</c>-terminated string that specifies the full path of the target file on which the operation failed.
	/// </param>
	/// <param name="Win32ErrorCode">The system error code encountered during the file operation.</param>
	/// <param name="Style">
	/// <para>Specifies display formatting and behavior of the dialog box. This parameter can be one of the following flags.</para>
	/// <para>IDF_NOBEEP</para>
	/// <para>Prevent the dialog box from beeping when it first appears.</para>
	/// <para>IDF_NOFOREGROUND</para>
	/// <para>Prevent the dialog box from becoming the foreground window.</para>
	/// </param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupRenameError as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuprenameerrora WINSETUPAPI UINT SetupRenameErrorA(
	// HWND hwndParent, PCSTR DialogTitle, PCSTR SourceFile, PCSTR TargetFile, UINT Win32ErrorCode, DWORD Style );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupRenameErrorA")]
	public static extern uint SetupRenameError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DialogTitle,
		[MarshalAs(UnmanagedType.LPTStr)] string SourceFile, [MarshalAs(UnmanagedType.LPTStr)] string TargetFile, Win32Error Win32ErrorCode, IDF Style);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupScanFileQueue</c> function scans a setup file queue, performing an operation on each node in its copy list. The
	/// operation is specified by a set of flags. This function can be called either before or after the queue has been committed.
	/// </para>
	/// </summary>
	/// <param name="FileQueue">Handle to the setup file queue whose copy list is to be scanned or iterated.</param>
	/// <param name="Flags">
	/// <para>
	/// Flags to combine to control the file queue scan operation. Note that either SPQ_SCAN_FILE_PRESENCE, SPQ_SCAN_USE_CALLBACK,
	/// SPQ_SCAN_USE_CALLBACKEX, or SPQ_SCAN_FILE_VALIDITY must be specified.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPQ_SCAN_FILE_PRESENCE</term>
	/// <term>Target files in the copy queue are already present on the target.</term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_FILE_VALIDITY</term>
	/// <term>
	/// Target files in the copy queue are already present on the target with valid signatures. Available with Windows 2000 and later versions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_USE_CALLBACK</term>
	/// <term>
	/// Callback routine for each node of the queue. If the callback routine returns a nonzero value, the queue processing stops and
	/// SetupScanFileQueue returns zero. Issue a SPFILENOTIFY_QUEUESCAN notification code and a pass a pointer to the target path as Param1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_USE_CALLBACKEX</term>
	/// <term>
	/// Callback routine for each node of the queue. If the callback routine returns a nonzero value, the queue processing stops and
	/// SetupScanFileQueue returns zero. Issue a SPFILENOTIFY_QUEUESCAN_EX notification and pass a pointer to a FILEPATHS structure as
	/// Param1. SPQ_SCAN_USE_CALLBACKEX also checks that the file has a valid signature. Available starting with Windows 2000. On
	/// Windows XP only, you can turn off signature checking by combining this flag with SPQ_SCAN_FILE_PRESENCE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_INFORM_USER</term>
	/// <term>
	/// Flag specified when all files in the queue pass the check for valid signatures. SetupScanFileQueue informs the user that the
	/// operation requires files that are already present on the target. This flag is ignored if SPQ_SCAN_FILE_PRESENCE or
	/// SPQ_SCAN_FILE_VALIDITY is not specified. This flag may not be used with SPQ_SCAN_PRUNE_COPY_QUEUE or SPQ_SCAN_PRUNE_DELREN.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_PRUNE_COPY_QUEUE</term>
	/// <term>
	/// Combined with SPQ_SCAN_FILE_PRESENCE, removes present entries from the copy queue. When combined with SPQ_SCAN_FILE_VALIDITY,
	/// removes signed entries from the copy queue. Available starting with Windows 2000. On Windows XP only, files that are also
	/// specified in the delete queue or rename queues are not pruned unless SPQ_SCAN_PRUNE_DELREN is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_USE_CALLBACK_SIGNERINFO</term>
	/// <term>
	/// Available starting with Windows XP. Issues SPFILENOTIFY_QUEUESCAN_SIGNERINFO notification and passes a pointer to a
	/// FILEPATHS_SIGNERINFO structure as Param1. Checks each file for a valid signature and reports signature information through the
	/// callback function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPQ_SCAN_PRUNE_DELREN</term>
	/// <term>
	/// Combined with SPQ_SCAN_FILE_PRESENCE or SPQ_SCAN_FILE_VALIDITY, removes entries in the delete or rename queue that are also in
	/// the copy queue. When combined with SPQ_SCAN_PRUNE_COPY_QUEUE, limits files that are removed from the copy queue to files that
	/// are not in the delete or rename queues. Available starting with Windows XP.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Window">
	/// Optional handle to the window to own dialog boxes that are presented. This parameter is not used if the Flags parameter does not
	/// contain SPQ_SCAN_FILE_PRESENCE or if Flags does not contain SPQ_SCAN_INFORM_USER.
	/// </param>
	/// <param name="CallbackRoutine">
	/// <para>
	/// Optional pointer to a FileCallback callback function to be called on each node of the copy queue. The notification code passed
	/// to the callback function is SPFILENOTIFY_QUEUESCAN. This parameter is required if Flags includes SPQ_SCAN_USE_CALLBACK.
	/// </para>
	/// <para>
	/// <c>Note</c> You must supply the callback routine specified by CallbackRoutine. The default queue callback routine does not
	/// support <c>SetupScanFileQueue</c>.
	/// </para>
	/// </param>
	/// <param name="CallbackContext">
	/// Optional pointer to a context that contains caller-defined data passed to the callback routine pointed to by CallbackRoutine.
	/// </param>
	/// <param name="Result">Pointer to a variable that receives the result of the scan operation.</param>
	/// <returns>
	/// <para>The function returns a nonzero value if all nodes in the queue were processed.</para>
	/// <para>
	/// If the SPQ_SCAN_USE_CALLBACK flag was set, the value in Result is 0. The callback routine specified by CallbackRoutine is sent
	/// the notification SPFILENOTIFY_QUEUESCAN. CallbackRoutine.Param1 specifies a pointer to an array that contains the target path
	/// information. The pointer has been cast to an unsigned integer and must be recast to a TCHAR array of MAX_PATH elements before a
	/// callback routine can access the information. CallbackRoutine.Param2 is set to SPQ_DELAYED_COPY if the current queue node is in
	/// use and cannot be copied until the system is restarted. Otherwise, CallbackRoutine.Param2 takes the value 0.
	/// </para>
	/// <para>
	/// If SPQ_SCAN_USE_CALLBACK was not set, Result indicates whether the queue passed the presence or validity check as shown in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// The queue failed the check or it passed the check, but SPQ_SCAN_INFORM_USER was specified and the user wants new copies of the files.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// The queue passed the check and, if SPQ_SCAN_INFORM_USER was specified, the user indicated that copying is not required. The copy
	/// queue is empty and there are no elements on the delete or rename queues, so the caller can skip queue commit.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// The queue passed the check and, if SPQ_SCAN_INFORM_USER was specified, the user indicated that copying is not required. The copy
	/// queue is empty, but there are elements on the delete or rename queues, so the caller cannot skip queue commit.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The function returns zero if an error occurred or the callback function returned nonzero. If Result is nonzero, it is the value
	/// returned by the callback function that stopped queue processing. If Result is zero, extended error information can be retrieved
	/// by a call to GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupScanFileQueue as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupscanfilequeuea WINSETUPAPI BOOL SetupScanFileQueueA(
	// HSPFILEQ FileQueue, DWORD Flags, HWND Window, PSP_FILE_CALLBACK_A CallbackRoutine, PVOID CallbackContext, PDWORD Result );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupScanFileQueueA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupScanFileQueue(HSPFILEQ FileQueue, SPQ_SCAN Flags, [In, Optional] HWND Window,
		[In, Optional] PSP_FILE_CALLBACK? CallbackRoutine, [In, Optional] IntPtr CallbackContext, out uint Result);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupSetDirectoryId</c> function associates a directory identifier in an INF file with a specific directory.</para>
	/// </summary>
	/// <param name="InfHandle">A handle for a loaded INF file.</param>
	/// <param name="Id">
	/// A directory identifier (DIRID) to use for an association. This parameter can be <c>NULL</c>. This DIRID must be greater than or
	/// equal to DIRID_USER. If an association already exists for this DIRID, it is overwritten. If Id is <c>NULL</c>, the Directory
	/// parameter is ignored, and the current set of user-defined DIRIDs is deleted.
	/// </param>
	/// <param name="Directory">
	/// A pointer to a <c>null</c>-terminated string that specifies the directory path to associate with Id. This parameter can be
	/// <c>NULL</c>. If Directory is <c>NULL</c>, any directory associated with Id is unassociated. No error results if Id is not
	/// currently associated with a directory.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupSetDirectoryId</c> can be used prior to queuing file copy operations to specify a target location that is only known at runtime.
	/// </para>
	/// <para>
	/// After setting the directory identifier, this function traverses all appended INF files, and if any of them have unresolved
	/// string substitutions, the function attempts to re-apply string substitution to them based on the new DIRID mapping. Because of
	/// this, some INF values may change after calling <c>SetupSetDirectoryId</c>.
	/// </para>
	/// <para>DIRID_ABSOLUTE_16BIT is not a valid value for Id, which ensures compatibility with 16-bit setup.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetDirectoryId as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetdirectoryida WINSETUPAPI BOOL
	// SetupSetDirectoryIdA( HINF InfHandle, DWORD Id, PCSTR Directory );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetDirectoryIdA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetDirectoryId(HINF InfHandle, [Optional] uint Id, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Directory);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupSetDirectoryIdEx</c> function associates a directory identifier in an INF file with a specific directory.</para>
	/// </summary>
	/// <param name="InfHandle">A handle for a loaded INF file.</param>
	/// <param name="Id">
	/// A directory identifier (DIRID) to use for an association. This parameter can be <c>NULL</c>. This DIRID must be greater than or
	/// equal to DIRID_USER. If an association already exists for this DIRID, it is overwritten. If Id is zero, the Directory parameter
	/// is ignored, and the current set of user-defined DIRIDs is deleted.
	/// </param>
	/// <param name="Directory">
	/// A pointer to a <c>null</c>-terminated string that specifies the directory path to associate with Id. This parameter can be
	/// <c>NULL</c>. If Directory is <c>NULL</c>, any directory associated with Id is unassociated. No error results if Id is not
	/// currently associated with a directory.
	/// </param>
	/// <param name="Flags">
	/// This parameter can be set to <c>SETDIRID_NOT_FULL_PATH</c> (1) to indicate that the Directory does not specify a full path.
	/// </param>
	/// <param name="Reserved1">If the value of this parameter is not zero the function returns ERROR_INVALID_PARAMETER.</param>
	/// <param name="Reserved2">If the value of this parameter is not zero the function returns ERROR_INVALID_PARAMETER.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupSetDirectoryIdEx</c> can be used prior to queuing file copy operations to specify a target location that is only known
	/// at runtime.
	/// </para>
	/// <para>
	/// After setting the directory identifier, this function traverses all appended INF files, and if any of them have unresolved
	/// string substitutions, the function attempts to re-apply string substitution to them based on the new DIRID mapping. Because of
	/// this, some INF values may change after calling <c>SetupSetDirectoryIdEx</c>.
	/// </para>
	/// <para>DIRID_ABSOLUTE_16BIT is not a valid value for Id, which ensures compatibility with 16-bit setup.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetDirectoryIdEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetdirectoryidexa WINSETUPAPI BOOL
	// SetupSetDirectoryIdExA( HINF InfHandle, DWORD Id, PCSTR Directory, DWORD Flags, DWORD Reserved1, PVOID Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetDirectoryIdExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetDirectoryIdEx(HINF InfHandle, [Optional] uint Id, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Directory,
		SETDIRID Flags, [In, Optional] uint Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupSetFileQueueAlternatePlatform</c> function associates the file queue with a target platform that is different from
	/// the platform running the function. This is done to enable for non-native signature verification.
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to an open setup file queue.</param>
	/// <param name="AlternatePlatformInfo">
	/// Optional pointer to an SP_ALTPLATFORM_INFO structure passing information about the alternate platform. On Windows 2000, the
	/// <c>cbSize</c> member of this structure must be set to sizeof(SP_ALTPLATFORM_INFO_V1). On Windows Server 2003 or Windows XP, the
	/// <c>cbSize</c> member of this structure must be set to sizeof(SP_ALTPLATFORM_INFO_V2).
	/// </param>
	/// <param name="AlternateDefaultCatalogFile">
	/// Pointer to a <c>null</c>-terminated string that specifies a catalog that validates any INF files. This parameter may be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetFileQueueAlternatePlatform as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetfilequeuealternateplatforma WINSETUPAPI BOOL
	// SetupSetFileQueueAlternatePlatformA( HSPFILEQ QueueHandle, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PCSTR
	// AlternateDefaultCatalogFile );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetFileQueueAlternatePlatformA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetFileQueueAlternatePlatform(HSPFILEQ QueueHandle, in SP_ALTPLATFORM_INFO AlternatePlatformInfo,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? AlternateDefaultCatalogFile);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupSetFileQueueAlternatePlatform</c> function associates the file queue with a target platform that is different from
	/// the platform running the function. This is done to enable for non-native signature verification.
	/// </para>
	/// </summary>
	/// <param name="QueueHandle">Handle to an open setup file queue.</param>
	/// <param name="AlternatePlatformInfo">
	/// Optional pointer to an SP_ALTPLATFORM_INFO structure passing information about the alternate platform. On Windows 2000, the
	/// <c>cbSize</c> member of this structure must be set to sizeof(SP_ALTPLATFORM_INFO_V1). On Windows Server 2003 or Windows XP, the
	/// <c>cbSize</c> member of this structure must be set to sizeof(SP_ALTPLATFORM_INFO_V2).
	/// </param>
	/// <param name="AlternateDefaultCatalogFile">
	/// Pointer to a <c>null</c>-terminated string that specifies a catalog that validates any INF files. This parameter may be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetFileQueueAlternatePlatform as an alias which automatically selects the ANSI or Unicode
	/// version of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral
	/// alias with code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more
	/// information, see Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetfilequeuealternateplatforma WINSETUPAPI BOOL
	// SetupSetFileQueueAlternatePlatformA( HSPFILEQ QueueHandle, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PCSTR
	// AlternateDefaultCatalogFile );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetFileQueueAlternatePlatformA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetFileQueueAlternatePlatform(HSPFILEQ QueueHandle, [In, Optional] IntPtr AlternatePlatformInfo,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? AlternateDefaultCatalogFile);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupSetFileQueueFlags</c> function sets the flags on a setup file queue.</para>
	/// </summary>
	/// <param name="FileQueue">Handle to an open setup file queue.</param>
	/// <param name="FlagMask">
	/// <para>Mask of valid flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPQ_FLAG_VALID 0x001</term>
	/// <term>Mask for use with SPQ_FLAG_BACKUP_AWARE.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags for use with <c>SetupSetFileQueueFlags</c> and returned by SetupGetFileQueueFlags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPQ_FLAG_BACKUP_AWARE 0x001</term>
	/// <term>If this flag is set, SetupCommitFileQueue issues backup notifications.</term>
	/// </item>
	/// <item>
	/// <term>SPQ_FLAG_ABORT_IF_UNSIGNED 0X002</term>
	/// <term>For internal use only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is (0) zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetfilequeueflags WINSETUPAPI BOOL
	// SetupSetFileQueueFlags( HSPFILEQ FileQueue, DWORD FlagMask, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetFileQueueFlags")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetFileQueueFlags(HSPFILEQ FileQueue, SPQ_FLAG FlagMask, SPQ_FLAG Flags);

	/// <summary>
	/// The <c>SetupSetNonInteractiveMode</c> function sets a non-interactive SetupAPI flag that determines whether SetupAPI can
	/// interact with a user in the caller's context.
	/// </summary>
	/// <param name="NonInteractiveFlag">
	/// The Boolean value of the non-interactive flag. If NonInteractive is set to <c>TRUE</c>, SetupAPI runs in a non-interactive user
	/// mode and if NonInteractive is set to <c>FALSE</c>, SetupAPI runs in an interactive user mode.
	/// </param>
	/// <returns><c>SetupSetNonInteractiveMode</c> returns the previous setting of the non-interactive flag.</returns>
	/// <remarks>
	/// <para>
	/// Installation applications and co-installers can use this function to control whether SetupAPI can display interactive user
	/// interface elements, such as dialog boxes, in the caller's context.
	/// </para>
	/// <para>
	/// An installation application or an installer can call SetupGetNonInteractiveMode to retrieve the current value of the
	/// non-interactive flag.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetnoninteractivemode WINSETUPAPI BOOL
	// SetupSetNonInteractiveMode( BOOL NonInteractiveFlag );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetNonInteractiveMode")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetNonInteractiveMode([MarshalAs(UnmanagedType.Bool)] bool NonInteractiveFlag);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupSetPlatformPathOverride</c> function is used to set a platform path override for a target machine when working with
	/// INFs from a different machine. As such, it can refer to a different platform than it is currently running on. For dealing with
	/// media sources, it can refer to platforms that are no longer supported, such as Alpha, MIPS, and PPC. It removes the platform
	/// path override if none is specified.
	/// </para>
	/// </summary>
	/// <param name="Override">
	/// Pointer to a <c>null</c>-terminated string that contains the replacement platform information. For example, "alpha" or "x86".
	/// This parameter may be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// If GetLastError returns ERROR_NOT_ENOUGH_MEMORY, <c>SetupSetPlatformPathOverride</c> was unable to store the Override string.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetPlatformPathOverride</c> is used to change the source path when queuing files. If a platform path override has been set by
	/// a call to <c>SetPlatformPathOverride</c>, any setup function that queues file copy operations will examine the final component
	/// of the source path and if the final component matches the name of the user's platform, replace it with the override string set
	/// by <c>SetPlatformPathOverride</c>.
	/// </para>
	/// <para>
	/// For example, consider a MIPS-platform machine where the platform has been set to Alpha by a call to
	/// <c>SetPlatformPathOverride</c>. After the platform path override has been set, a file copy operation is queued with a source
	/// path of \pop\top\baz\mips\x.exe, the path will be changed to \pop\top\baz\alpha\x.exe.
	/// </para>
	/// <para>The paths of file copy operations queued before the path override is set are not changed.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetPlatformPathOverride as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetplatformpathoverridea WINSETUPAPI BOOL
	// SetupSetPlatformPathOverrideA( PCSTR Override );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetPlatformPathOverrideA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetPlatformPathOverride([Optional, MarshalAs(UnmanagedType.LPTStr)] string? Override);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupSetSourceList</c> function allows the caller to set the list of installation sources for either the current user or
	/// the system (common to all users).
	/// </para>
	/// </summary>
	/// <param name="Flags">
	/// <para>Specifies the type of list. This parameter can be a combination of the following values.</para>
	/// <para>SRCLIST_SYSTEM</para>
	/// <para>
	/// The list is the per-system Most Recently Used (MRU) list stored in the registry. The caller must be a member of the
	/// administrators local group.
	/// </para>
	/// <para>SRCLIST_USER</para>
	/// <para>The list is the per-user MRU list stored in the registry.</para>
	/// <para>SRCLIST_TEMPORARY</para>
	/// <para>
	/// The specified list is temporary and will be the only list accessible to the current process until SetupCancelTemporarySourceList
	/// is called or <c>SetSourceList</c> is called again.
	/// </para>
	/// <para>
	/// <c>Important</c> If a temporary list is set, sources are not added to or deleted from the system or user lists, even if
	/// subsequent calls to SetupAddToSourceList or SetupRemoveFromSourceList explicitly specify those lists.
	/// </para>
	/// <para><c>Note</c> One of the SRCLIST_SYSTEM, SRCLIST_USER, or SRCLIST_TEMPORARY flags must be specified.</para>
	/// <para>SRCLIST_NOBROWSE</para>
	/// <para>
	/// The user is not allowed to add or change sources when SetupPromptForDisk is used. This flag is typically used in combination
	/// with the SRCLIST_TEMPORARY flag.
	/// </para>
	/// </param>
	/// <param name="SourceList">Pointer to an array of strings to use as the source list, as specified by the Flags parameter.</param>
	/// <param name="SourceCount">Number of elements in the array pointed to by SourceList.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupSetSourceList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetsourcelista WINSETUPAPI BOOL SetupSetSourceListA(
	// DWORD Flags, PCSTR *SourceList, UINT SourceCount );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetSourceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupSetSourceList(SRCLIST Flags, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 2)] string[] SourceList, uint SourceCount);

	/// <summary>
	/// The <c>SetupSetThreadLogToken</c> function sets the log context, as represented by a log token for the thread from which this
	/// function was called. A subsequent call to SetupGetThreadLogToken made within the same thread retrieves the log token that was
	/// most recently set for the thread.
	/// </summary>
	/// <param name="LogToken">A log token that is either a system-defined log token or was returned by SetupGetThreadLogToken.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// <c>SetupSetThreadLogToken</c> establishes a log context for the thread from which the function was called. The log context is
	/// represented by a log token, which can be retrieved by calling SetupGetThreadLogToken.
	/// </para>
	/// <para>For more information about log tokens, see Log Tokens.</para>
	/// <para>For more information about using log tokens, see Setting and Getting a Log Token for a Thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupsetthreadlogtoken WINSETUPAPI VOID
	// SetupSetThreadLogToken( SP_LOG_TOKEN LogToken );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupSetThreadLogToken")]
	public static extern void SetupSetThreadLogToken(ulong LogToken);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupTermDefaultQueueCallback</c> function is called after a queue has finished committing. It frees resources allocated
	/// by previous calls to SetupInitDefaultQueueCallback or SetupInitDefaultQueueCallbackEx.
	/// </para>
	/// </summary>
	/// <param name="Context">Pointer to the context used by the default callback routine.</param>
	/// <returns>
	/// <para>Does not return a value.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Regardless of whether you initialized the context used by the default queue callback routine with SetupInitDefaultQueueCallback
	/// or SetupInitDefaultQueueCallbackEx, after the queued operations have finished processing, call
	/// <c>SetupTermDefaultQueueCallback</c> to release the resources allocated in initializing the context structure. For more
	/// information see Initializing and Terminating the Callback Context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setuptermdefaultqueuecallback WINSETUPAPI VOID
	// SetupTermDefaultQueueCallback( PVOID Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupTermDefaultQueueCallback")]
	public static extern void SetupTermDefaultQueueCallback(IntPtr Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupTerminateFileLog</c> function releases resources associated with a file log.</para>
	/// </summary>
	/// <param name="FileLogHandle">Handle to the log file as returned by a call to <see cref="SetupInitializeFileLog"/>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupterminatefilelog WINSETUPAPI BOOL
	// SetupTerminateFileLog( HSPFILELOG FileLogHandle );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupTerminateFileLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupTerminateFileLog(HSPFILELOG FileLogHandle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupUninstallNewlyCopiedInfs</c> function uninstalls INF files (.inf), precompiled INF files (.pnf), and catalog files
	/// (.cat) that are previously installed during the committal of the specified file queue.
	/// </para>
	/// <para>A caller of this function must have administrative privileges; otherwise, the function fails.</para>
	/// </summary>
	/// <param name="FileQueue">
	/// Handle to an open and committed file queue. This queue contains the newly installed INF, PNF, or CAT files that
	/// <c>SetupUninstallNewlyCopiedInfs</c> uninstalls.
	/// </param>
	/// <param name="Flags">
	/// Flags to use with <c>SetupUninstallNewlyCopiedInfs</c>. No flags are defined currently. This parameter must be 0 (zero).
	/// </param>
	/// <param name="Reserved">Reserved. This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// If the parameters passed in are valid, the return value is <c>TRUE</c> (nonzero), which does not necessarily mean that any INFs
	/// are uninstalled.
	/// </para>
	/// <para>
	/// If some of the parameters passed in are invalid, the return value is <c>FALSE</c> (zero). To get extended error information,
	/// call GetLastError.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupuninstallnewlycopiedinfs WINSETUPAPI BOOL
	// SetupUninstallNewlyCopiedInfs( HSPFILEQ FileQueue, DWORD Flags, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupUninstallNewlyCopiedInfs")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupUninstallNewlyCopiedInfs(HSPFILEQ FileQueue, [Optional] uint Flags, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupUninstallOEMInf</c> function uninstalls a specified .inf file and any associated .pnf file. If the .inf file was
	/// installed with a catalog for signing drivers, the catalog is also removed. A caller of this function must have administrative
	/// privileges, otherwise the function fails.
	/// </para>
	/// </summary>
	/// <param name="InfFileName">File name, without path, of the .inf file in the Windows Inf directory that is to be uninstalled.</param>
	/// <param name="Flags">
	/// <para>This parameter can be set as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SUOI_FORCEDELETE 0x0001</term>
	/// <term>
	/// The SetupUninstallOEMInf function first checks whether there are any devices installed using the .inf file. A device does not
	/// need to be present to be detected as using the .inf file. If this flag is not set and the function finds a currently installed
	/// device that was installed using this .inf file, the .inf file is not removed. If this flag is set, the .inf file is removed
	/// whether the function finds a device that was installed with this .inf file.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved">Set to <c>null</c>.</param>
	/// <returns>This function returns WINSETUPAPI BOOL.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupUninstallOEMInf as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupuninstalloeminfa WINSETUPAPI BOOL
	// SetupUninstallOEMInfA( PCSTR InfFileName, DWORD Flags, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupUninstallOEMInfA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupUninstallOEMInf([MarshalAs(UnmanagedType.LPTStr)] string InfFileName, SUOI Flags, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupVerifyInfFile</c> function verifies the digital signature of the specified INF file by using its corresponding
	/// catalog. The verification can be performed against an alternate platform.
	/// </para>
	/// </summary>
	/// <param name="InfName">The name of the INF file to be verified. This name may include a path.</param>
	/// <param name="AltPlatformInfo">
	/// An optional pointer to a SP_ALTPLATFORM_INFO_V2 structure that contains information about the alternate platform to use when
	/// validating the INF file. This parameter can be Null.
	/// </param>
	/// <param name="InfSignerInfo">
	/// A pointer to an SP_INF_SIGNER_INFO structure that receives information about the INF digital signature, that is, if it is signed.
	/// </param>
	/// <returns>This function returns WINSETUPAPI BOOL.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupVerifyInfFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupverifyinffilea WINSETUPAPI BOOL SetupVerifyInfFileA(
	// PCSTR InfName, PSP_ALTPLATFORM_INFO AltPlatformInfo, PSP_INF_SIGNER_INFO_A InfSignerInfo );
	[DllImport(Lib_SetupAPI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupVerifyInfFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupVerifyInfFile([MarshalAs(UnmanagedType.LPTStr)] string InfName, in SP_ALTPLATFORM_INFO AltPlatformInfo,
		ref SP_INF_SIGNER_INFO_V2 InfSignerInfo);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupVerifyInfFile</c> function verifies the digital signature of the specified INF file by using its corresponding
	/// catalog. The verification can be performed against an alternate platform.
	/// </para>
	/// </summary>
	/// <param name="InfName">The name of the INF file to be verified. This name may include a path.</param>
	/// <param name="AltPlatformInfo">
	/// An optional pointer to a SP_ALTPLATFORM_INFO_V2 structure that contains information about the alternate platform to use when
	/// validating the INF file. This parameter can be Null.
	/// </param>
	/// <param name="InfSignerInfo">
	/// A pointer to an SP_INF_SIGNER_INFO structure that receives information about the INF digital signature, that is, if it is signed.
	/// </param>
	/// <returns>This function returns WINSETUPAPI BOOL.</returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupVerifyInfFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupverifyinffilea WINSETUPAPI BOOL SetupVerifyInfFileA(
	// PCSTR InfName, PSP_ALTPLATFORM_INFO AltPlatformInfo, PSP_INF_SIGNER_INFO_A InfSignerInfo );
	[DllImport(Lib_SetupAPI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupVerifyInfFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupVerifyInfFile([MarshalAs(UnmanagedType.LPTStr)] string InfName, [In, Optional] IntPtr AltPlatformInfo,
		ref SP_INF_SIGNER_INFO_V2 InfSignerInfo);

	/// <summary>The <c>SetupWriteTextLog</c> function writes a log entry in a SetupAPI text log.</summary>
	/// <param name="LogToken">A log token that is either a system-defined log token or was returned by SetupGetThreadLogToken.</param>
	/// <param name="Category">
	/// A DWORD-typed value that indicates the event category for the log entry. The event categories that can be specified for a log
	/// entry are the same as those that can be enabled for a text log. For a list of event categories, see Enabling Event Categories
	/// for a SetupAPI Text Log.
	/// </param>
	/// <param name="Flags">
	/// <para>A DWORD-typed value that is a bitwise OR of flag values, which specify the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The event level for the log entry. The event levels that can be specified for a log entry are the same as those that can be
	/// enabled for a text log. For a list of event level flags, see Setting the Event Level for a SetupAPI Text Log.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Whether to include a time stamp in the log entry. The time stamp flag value is TXTLOG_TIMESTAMP.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The change, if any, to the indentation depth of the section and the current log entry. For information about how to use the
	/// indentation flags, see Writing Indented Log Entries.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="MessageStr">
	/// A pointer to a NULL-terminated constant string that contains a <c>printf</c>-compatible format string, which specifies the
	/// formatted message to include in the log entry. The comma-separated parameter list that follows MessageStr must match the format
	/// specifiers in the format string.
	/// </param>
	/// <param name="args">
	/// A comma-separated parameter list that matches the format specifiers in the format string that is supplied by MessageStr.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// If the value of LogToken was returned by a call to SetupGetThreadLogToken and the corresponding text log section can be found,
	/// <c>SetupWriteTextLog</c> writes the log entry in that text log section. If <c>SetupWriteTextLog</c> cannot locate the section,
	/// <c>SetupWriteTextLog</c> writes the log entry in the corresponding text log, but does not include the log entry in a section.
	/// </para>
	/// <para>
	/// If the value of LogToken is one of the system-defined log tokens listed in the following table, <c>SetupWriteTextLog</c>
	/// performs the write operation that is indicated for that log token.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>System-defined log token</term>
	/// <term>Write operation</term>
	/// </listheader>
	/// <item>
	/// <term>LOGTOKEN_NOLOG</term>
	/// <term>The log entry is not written to any text log.</term>
	/// </item>
	/// <item>
	/// <term>LOG_TOKEN_UNSPECIFIED</term>
	/// <term>The log entry is written to the application installation text log. The log entry is not included in a text log section.</term>
	/// </item>
	/// <item>
	/// <term>LOGTOKEN_SETUPAPI_APPLOG</term>
	/// <term>The log entry is written to the application installation text log. The log entry is not included in a text log section.</term>
	/// </item>
	/// <item>
	/// <term>LOGTOKEN_SETUPAPI_DEVLOG</term>
	/// <term>The log entry is written to the device installation text log. The log entry is not included in a text log section.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Setting the value of LogToken to one of the system-defined log tokens does not change the value of the current log
	/// token for the thread.
	/// </para>
	/// <para>In addition, <c>SetupWriteTextLog</c> does not write a log entry when any of the following are true:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The event level set for the text log is less than the event level that is specified for the log entry.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The event category for the log entry is not enabled for the text log. For more information about event categories, see Enabling
	/// Event Categories for a Text Log.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The maximum length, in characters, of a log entry is 336.</para>
	/// <para>To write information about a SetupAPI-specific error or a Win32 error in a text log, an application can use SetupWriteTextLogError.</para>
	/// <para>For general information about writing log entries in the SetupAPI text logs, see SetupAPI Logging (Windows Vista and Later).</para>
	/// <para>For more information about the operation of <c>SetupWriteTextLog</c>, see Calling SetupWriteTextLog.</para>
	/// <para>For more information about log tokens, see Log Tokens.</para>
	/// <para>For more information about using log tokens, see Setting and Getting a Log Token for a Thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupwritetextlog WINSETUPAPI VOID SetupWriteTextLog(
	// SP_LOG_TOKEN LogToken, DWORD Category, DWORD Flags, PCSTR MessageStr, ... );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupWriteTextLog")]
	public static extern void SetupWriteTextLog(ulong LogToken, uint Category, uint Flags, [MarshalAs(UnmanagedType.LPStr)] string MessageStr, IntPtr args);

	/// <summary>
	/// The <c>SetupWriteTextLogError</c> function writes information about a SetupAPI-specific error or a Win32 system error to a
	/// SetupAPI text log.
	/// </summary>
	/// <param name="LogToken">A log token that is either a system-defined log token or was returned by SetupGetThreadLogToken.</param>
	/// <param name="Category">
	/// A value of type DWORD that indicates the event category for the log entry. The event categories that can be specified for a log
	/// entry are the same as those that can be enabled for a text log. For a list of event categories, see Enabling Event Categories
	/// for a SetupAPI Text Log.
	/// </param>
	/// <param name="LogFlags">
	/// <para>A value of type DWORD that is a bitwise OR of flag values, which specify the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The event level for the log entry. The event levels that can be specified for a log entry are the same as those that can be
	/// enabled for a text log. For a list of event level flags, see Setting the Event Level for a Text Log.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Whether to include a time stamp in the log entry. The time stamp flag value is TXTLOG_TIMESTAMP.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The change, if any, to the indentation depth of the section and the current log entry. For information about how to use the
	/// indentation flags, see Writing Indented Log Entries.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Error">
	/// A SetupAPI-specific error code or a Win32 error code. The SetupAPI-specific error codes are listed in Setupapi.h. The Win32
	/// error codes are listed in Winerror.h.
	/// </param>
	/// <param name="MessageStr">
	/// A pointer to a NULL-terminated constant string that contains a <c>printf</c>-compatible format string, which specifies the
	/// formatted message to include in the log entry.
	/// </param>
	/// <param name="args">
	/// A comma-separated parameter list that matches the format specifiers in the format string that is supplied by MessageStr.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// If an installation application has a SetupAPI-specific error code or a Win32 error code that is associated with an installation
	/// error, the application can call <c>SetupWriteTextLogError</c> instead of SetupWriteTextLog to write two entries into a text log.
	/// The first entry will be the same as that written by <c>SetupWriteTextLog</c> and the second entry will log the error code and a
	/// user-friendly description of the error.
	/// </para>
	/// <para>
	/// The log token, event category, and flags that a caller supplies affect the operation of <c>SetupWriteTextLogError</c> is the
	/// same manner as that described for <c>SetupWriteTextLog</c>.
	/// </para>
	/// <para><c>SetupWriteTextLogError</c> writes the first log entry in the following format:</para>
	/// <para>entry-prefix time_stamp categoryindentation formatted-message</para>
	/// <para><c>SetupWriteTextLogError</c> writes the second log entry in the following format:</para>
	/// <para>entry-prefix time_stamp category indentation <c>Error:</c> error-numbererror-description</para>
	/// <para>Where:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The entry-prefix, time-stamp, category, indentation, and formatted-message fields are the same as those described in Format of a
	/// Text Log Section Body.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The error-number field contains the error number.</term>
	/// </item>
	/// <item>
	/// <term>The error-description field contains a user-friendly description of the error.</term>
	/// </item>
	/// </list>
	/// <para>For general information about writing log entries in the SetupAPI text logs, see SetupAPI Logging (Windows Vista).</para>
	/// <para>For more information about the operation of <c>SetupWriteTextLogError</c>, see Calling SetupWriteTextLogError.</para>
	/// <para>For more information about log tokens, see Log Tokens.</para>
	/// <para>For more information about using log tokens, see Setting and Getting a Log Token for a Thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupwritetextlogerror WINSETUPAPI VOID
	// SetupWriteTextLogError( SP_LOG_TOKEN LogToken, DWORD Category, DWORD LogFlags, DWORD Error, PCSTR MessageStr, ... );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupWriteTextLogError")]
	public static extern void SetupWriteTextLogError(ulong LogToken, uint Category, uint LogFlags, uint Error, [MarshalAs(UnmanagedType.LPStr)] string MessageStr, IntPtr args);

	/// <summary>
	/// The <c>SetupWriteTextLogInfLine</c> function writes a log entry in a SetupAPI text log that contains the text of a specified INF
	/// file line.
	/// </summary>
	/// <param name="LogToken">A log token that is either a system-defined log token or was returned by SetupGetThreadLogToken.</param>
	/// <param name="Flags">
	/// <para>A value of type DWORD that is a bitwise OR of flag values, which specify the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The event level for the log entry. The event levels that can be specified for a log entry are the same as those that can be
	/// enabled for a text log. For a list of event level flags, see Setting the Event Level for a SetupAPI Text Log.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Whether to include a time stamp in the log entry. The time stamp flag value is TXTLOG_TIMESTAMP.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The change, if any, to the indentation depth of the section and the current log entry. For information about how to use the
	/// indentation flags, see Writing Indented Log Entries.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="InfHandle">
	/// A handle to the INF file that includes the line of text to be written to the text log. A handle to an INF file is obtained by
	/// calling <c>SetupOpenInfFile</c>, which is documented in the Platform SDK.
	/// </param>
	/// <param name="Context">
	/// A pointer to an INF file context that specifies the line of text to be written to the text log. An INF file context for a line
	/// is obtained by calling the <c>SetupFind</c> Xxx <c>Line</c> functions. For information about INF files and an INF file context,
	/// see the information that is provided in the Platform SDK about using INF files, obtaining an INF file context, and the
	/// INFCONTEXT structure.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c>SetupWriteTextLogInfLine</c> writes a log entry in the following format:</para>
	/// <para>entry-prefix time-stamp <c>inf:</c> indentation inf-line-text <c>(</c> inf-file-name <c>line</c> line-number <c>)</c></para>
	/// <para>Where:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The entry-prefix and time-stamp fields are the same as those described in Format of a Text Log Section Body.</term>
	/// </item>
	/// <item>
	/// <term>The inf-line-text field contains the text of the specified INF file line.</term>
	/// </item>
	/// <item>
	/// <term>The inf-file-name field contains the name of the INF file that contains the specified INF file line.</term>
	/// </item>
	/// <item>
	/// <term>The line-number field contains the line number of the specified line in the INF file.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The log token and flags that a caller supplies affect the operation of <c>SetupWriteTextLogInfLine</c> in the same manner as
	/// that described for SetupWriteTextLog and SetupWriteTextLogError. In addition, <c>SetupWriteTextLogInfLine</c> uses the event
	/// category TXTLOG_INF.
	/// </para>
	/// <para>For general information about writing log entries in the SetupAPI text logs, see SetupAPI Logging (Windows Vista).</para>
	/// <para>For more information about the operation of <c>SetupWriteTextLogInfLine</c>, see Calling SetupWriteTextLogInfLine.</para>
	/// <para>For more information about the various types of log tokens, see Log Tokens.</para>
	/// <para>For more information about using log tokens, see Setting and Getting a Log Token for a Thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupwritetextloginfline WINSETUPAPI VOID
	// SetupWriteTextLogInfLine( SP_LOG_TOKEN LogToken, DWORD Flags, HINF InfHandle, PINFCONTEXT Context );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupWriteTextLogInfLine")]
	public static extern void SetupWriteTextLogInfLine(ulong LogToken, uint Flags, HINF InfHandle, in INFCONTEXT Context);

	/// <summary>
	/// An SP_ALTPLATFORM_INFO structure specifies, for a given computer, the version of the operating system and the computer's
	/// processor architecture.
	/// </summary>
	/// <remarks>
	/// For information about the major and minor version numbers of the operating system, see the Microsoft Windows SDK documentation
	/// for <c>GetVersionEx</c> and OSVERSIONINFO.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/windows/hardware/previsioning-framework/ff552338(v=vs.85) typedef struct {
	// DWORD cbSize; DWORD Platform; DWORD MajorVersion; DWORD MinorVersion; WORD ProcessorArchitecture; WORD Reserved; }
	// SP_ALTPLATFORM_INFO, *PSP_ALTPLATFORM_INFO;
	[PInvokeData("Setupapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_ALTPLATFORM_INFO
	{
		/// <summary>
		/// Specifies the size, in bytes, of an SP_ALTPLATFORM_INFO structure. Starting with Windows XP, the cbSize member of this
		/// structure must be set to sizeof(SP_ALTPLATFORM_INFO_V2). For all earlier versions of Windows, the cbSize member of this
		/// structure must be set to sizeof(SP_ALTPLATFORM_INFO_V1).
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Specifies one of the following operating system constants.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Platform constant</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>VER_PLATFORM_WIN32_WINDOWS</description>
		/// <description>Windows 95/98/Millennium(Me) versions</description>
		/// </item>
		/// <item>
		/// <description>VER_PLATFORM_WIN32_NT</description>
		/// <description>Windows NT 4.0 and later versions of the NT-based operating system</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint Platform;

		/// <summary>Specifies the major version number of the operating system.</summary>
		public uint MajorVersion;

		/// <summary>Specifies the minor version number of the operating system.</summary>
		public uint MinorVersion;

		/// <summary>
		/// <para>Specifies one of the following processor architecture constants.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Processor architecture constant</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>PROCESSOR_ARCHITECTURE_INTEL</description>
		/// <description>The alternative platform is an x86-based processor architecture.</description>
		/// </item>
		/// <item>
		/// <description>PROCESSOR_ARCHITECTURE_AMD64</description>
		/// <description>The alternative platform is an x64-based processor architecture.</description>
		/// </item>
		/// <item>
		/// <description>PROCESSOR_ARCHITECTURE_IA64</description>
		/// <description>The alternative platform is an Itanium-based processor architecture.</description>
		/// </item>
		/// <item>
		/// <description>PROCESSOR_ARCHITECTURE_ALPHA</description>
		/// <description>
		/// The alternative platform is an Alpha processor architecture that is running Windows NT 4.0. Only a system that is running
		/// Windows 2000 Print Server or Windows XP Professional Print Server can specify this value.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public ProcessorArchitecture ProcessorArchitecture;

		/// <summary>Must be set to zero.</summary>
		public ushort Reserved;
	}
}