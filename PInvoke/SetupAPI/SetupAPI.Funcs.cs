namespace Vanara.PInvoke;

/// <summary>Items from the SetupAPI.dll</summary>
public static partial class SetupAPI
{
	private const string Lib_SetupAPI = "setupapi.dll";

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The FileCallback callback function is used by a few setup functions. The <c>PSP_FILE_CALLBACK</c> type defines a pointer to this
	/// callback function. FileCallback is a placeholder for the application-defined function name.
	/// </para>
	/// <para>For more information, see Notifications, Creating a Custom Queue Callback Routine, and Creating a Cabinet Callback Routine.</para>
	/// </summary>
	/// <param name="Context">The context information about the queue notification that is returned to the callback function.</param>
	/// <param name="Notification">The event that triggers the call to the callback function.</param>
	/// <param name="Param1">The additional notification information. The value is dependent on the notification that is being returned.</param>
	/// <param name="Param2">The additional notification information. The value is dependent on the notification that is being returned.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nc-setupapi-psp_file_callback_a PSP_FILE_CALLBACK_A PspFileCallbackA;
	// UINT PspFileCallbackA( PVOID Context, UINT Notification, UINT_PTR Param1, UINT_PTR Param2 ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[PInvokeData("setupapi.h", MSDNShortId = "NC:setupapi.PSP_FILE_CALLBACK_A")]
	public delegate uint PSP_FILE_CALLBACK(IntPtr Context, uint Notification, IntPtr Param1, IntPtr Param2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// <c>InstallHinfSection</c> is an entry-point function exported by Setupapi.dll that you can use to execute a section of an .inf
	/// file. <c>InstallHinfSection</c> can be invoked by calling the Rundll32.exe utility as described in the Remarks section.
	/// </para>
	/// <para>The prototype for the <c>InstallHinfSection</c> function follows the form of all entry-point functions used with Rundll32.exe.</para>
	/// <para>
	/// If a file is copied or modified, the caller of this function is required have privileges to write into the target directory. If
	/// there are any services being installed, the caller of this function is required have access to the Service Control Manager.
	/// </para>
	/// </summary>
	/// <param name="Window">The parent window handle. Typically hwnd is Null.</param>
	/// <param name="ModuleHandle">Reserved and should be Null.</param>
	/// <param name="CommandLine">Pointer to buffer containing the command line. You should use a null-terminated string.</param>
	/// <param name="ShowCommand">Reserved and should be zero.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Note that three exports exist: <c>InstallHinfSection</c> (for RunDll32), <c>InstallHinfSectionA</c>, and <c>InstallHinfSectionW</c>.</para>
	/// <para>
	/// To run an <c>Install</c> section of a specified .inf file, you can invoke <c>InstallHinfSection</c> with the Rundll32.exe by
	/// using the following syntax.
	/// </para>
	/// <para><c>RUNDLL32.EXE SETUPAPI.DLL,InstallHinfSection</c>&lt;section&gt;&lt;mode&gt;&lt;path&gt;</para>
	/// <para>This passes "&lt;section&gt;&lt;mode&gt;&lt;path&gt;" to CmdLineBuffer.</para>
	/// <para>
	/// Alternatively, your program may call <c>InstallHinfSection</c>, <c>InstallHinfSectionA</c>, or <c>InstallHinfSectionW</c>
	/// directly, setting the CmdLineBuffer parameter to the following.
	/// </para>
	/// <para>
	/// <code>"&lt;section&gt; &lt;mode&gt; &lt;path&gt;"</code>
	/// </para>
	/// <para>
	/// Where path is the full path to the .inf file, mode is the reboot mode parameter, and section is any <c>Install</c> section in
	/// the .inf file. The comma separator between SETUPAPI.DLL and <c>InstallHinfSection</c> on the command line is required. Note that
	/// there cannot be any white space on the command line between the comma and SETUPAPI.DLL or <c>InstallHinfSection</c>.
	/// </para>
	/// <para>It is recommended that you specify the full path to the .inf file as path.</para>
	/// <para>You may specify any <c>Install</c> section in the .inf file as section. No spaces are allowed.</para>
	/// <para>
	/// You should use a combination of the following values for mode. You must include 128 to set the default path of the installation
	/// to the location of the INF, otherwise a system-provided INF is assumed. Add values to specify rebooting. Note that only the
	/// values 128 or 132 are recommended, other values may cause the computer to reboot unnecessarily or not reboot when it required.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>System provided INF.</term>
	/// </item>
	/// <item>
	/// <term>128</term>
	/// <term>Set the default path of the installation to the location of the INF. This is the typical setting.</term>
	/// </item>
	/// <item>
	/// <term>+0</term>
	/// <term>Never reboot the computer.</term>
	/// </item>
	/// <item>
	/// <term>+1</term>
	/// <term>Reboot the computer in all cases.</term>
	/// </item>
	/// <item>
	/// <term>+2</term>
	/// <term>Always ask the users if they want to reboot.</term>
	/// </item>
	/// <item>
	/// <term>+3</term>
	/// <term>Reboot the computer if necessary without asking user for permission.</term>
	/// </item>
	/// <item>
	/// <term>+4</term>
	/// <term>If a reboot of the computer is necessary, ask the user for permission before rebooting.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For example, the following command line runs the DefaultInstall section of the Shell.inf file. If Setup determines a reboot is
	/// required, the user is will be prompted with a "Reboot the computer, Yes/No" dialog box.
	/// </para>
	/// <para><c>RUNDLL32.EXE SETUPAPI.DLL,InstallHinfSection DefaultInstall 132 C:\WINDOWS\INF\SHELL.INF</c></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-installhinfsectiona void InstallHinfSectionA( HWND
	// Window, HINSTANCE ModuleHandle, PCSTR CommandLine, INT ShowCommand );
	[DllImport(Lib_SetupAPI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.InstallHinfSectionA")]
	public static extern void InstallHinfSection([Optional] HWND Window, [Optional] HINSTANCE ModuleHandle, [MarshalAs(UnmanagedType.LPTStr)] string CommandLine,
		ShowWindowCommand ShowCommand);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupAddInstallSectionToDiskSpaceList</c> function searches for <c>CopyFile</c> and <c>DelFile</c> lines in an
	/// <c>Install</c> section of an INF file. The function then adds the file operations specified in those sections to a disk-space list.
	/// </para>
	/// </summary>
	/// <param name="DiskSpace">Handle to a disk-space list.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>Install</c> section to be searched. If ListInfHandle is not specified, the INF
	/// file must also contain the section specified by SectionName.
	/// </param>
	/// <param name="LayoutInfHandle">
	/// This parameter, if specified, provides the handle to the INF file that contains the <c>SourceDisksFiles</c> sections. Otherwise
	/// that section is assumed to exist in the INF file specified by InfHandle.
	/// </param>
	/// <param name="SectionName">
	/// Name of the Install section to be added to the disk-space list. You should use a null-terminated string.
	/// </param>
	/// <param name="Reserved1">Must be zero.</param>
	/// <param name="Reserved2">Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>This function requires a Windows INF file. Some older INF file formats may not be supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupaddinstallsectiontodiskspacelista WINSETUPAPI BOOL
	// SetupAddInstallSectionToDiskSpaceListA( HDSKSPC DiskSpace, HINF InfHandle, HINF LayoutInfHandle, PCSTR SectionName, PVOID
	// Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddInstallSectionToDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupAddInstallSectionToDiskSpaceList(HDSKSPC DiskSpace, HINF InfHandle, [Optional] HINF LayoutInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string SectionName, IntPtr Reserved1 = default, uint Reserved2 = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupAddSectionToDiskSpaceList</c> function adds to a disk-space list all the file delete or copy operations listed in a
	/// <c>Copy Files</c> or <c>Delete Files</c> section of an INF file.
	/// </para>
	/// <para>Target disk compression is ignored by this function. Files are assumed to occupy their full size on the target disk.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list.</param>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains the <c>SourceDisksFiles</c> section. If ListInfHandle is not specified, this INF file
	/// must also contain the section named by SectionName.
	/// </param>
	/// <param name="ListInfHandle">
	/// Optional handle to an open INF file that contains the section specified by SectionName. Otherwise, InfHandle is assumed to
	/// contain this section.
	/// </param>
	/// <param name="SectionName">
	/// Name of the <c>Copy Files</c> or <c>Delete Files</c> section that contains the file operations to add to the disk-space list.
	/// Use a null-terminated string.
	/// </param>
	/// <param name="Operation">
	/// <para>Type of file operation to be added to the list. This parameter can be one of the following values.</para>
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
	/// <remarks>This function requires a Windows INF file. Some older INF file formats may not be supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupaddsectiontodiskspacelista WINSETUPAPI BOOL
	// SetupAddSectionToDiskSpaceListA( HDSKSPC DiskSpace, HINF InfHandle, HINF ListInfHandle, PCSTR SectionName, UINT Operation, PVOID
	// Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddSectionToDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupAddSectionToDiskSpaceList(HDSKSPC DiskSpace, HINF InfHandle, [Optional] HINF ListInfHandle,
		[MarshalAs(UnmanagedType.LPTStr)] string SectionName, FILEOP Operation, IntPtr Reserved1 = default, uint Reserved2 = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupAddToDiskSpaceList</c> function adds a single delete or copy operation to a disk-space list. To add all the file
	/// operations in a section of an INF file, use either SetupAddSectionToDiskSpaceList, or SetupAddInstallSectionToDiskSpaceList.
	/// </para>
	/// <para>Target disk compression is ignored by this function. Files are assumed to occupy their full size on the target disk.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list.</param>
	/// <param name="TargetFilespec">
	/// File name of the file to be added to the disk-space list. You should use a null-terminated string that specifies a fully
	/// qualified path. Otherwise, the path must be relative to the current directory.
	/// </param>
	/// <param name="FileSize">
	/// Uncompressed size of the file as it will exist in the target directory, in bytes. You can use SetupGetSourceFileSize to retrieve
	/// this information from an INF file. This parameter is ignored for FILEOP_DELETE operations.
	/// </param>
	/// <param name="Operation">
	/// <para>File operation to be added to the list. This parameter can be one of the following values.</para>
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
	/// <term>FILEOP_COPY.</term>
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
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupaddtodiskspacelista WINSETUPAPI BOOL
	// SetupAddToDiskSpaceListA( HDSKSPC DiskSpace, PCSTR TargetFilespec, LONGLONG FileSize, UINT Operation, PVOID Reserved1, UINT
	// Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddToDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupAddToDiskSpaceList(HDSKSPC DiskSpace, [MarshalAs(UnmanagedType.LPTStr)] string TargetFilespec, long FileSize,
		FILEOP Operation, IntPtr Reserved1 = default, uint Reserved2 = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupAddToSourceList</c> function appends a value to the list of installation sources for either the current user or the
	/// system. If the value already exists, it is removed first, so that duplicate entries are not created.
	/// </para>
	/// <para>A caller of this function is required have administrative privileges, otherwise the function fails.</para>
	/// </summary>
	/// <param name="Flags">
	/// <para>List to which the source will be appended. This parameter can be any combination of the following values.</para>
	/// <para>SRCLIST_SYSTEM</para>
	/// <para>Add the source to the per-system list. The caller must be an administrator.</para>
	/// <para>SRCLIST_USER</para>
	/// <para>Add the source to the per-user list.</para>
	/// <para>SRCLIST_SYSIFADMIN</para>
	/// <para>
	/// If the caller is an administrator, the source is added to the per-system list; if the caller is not a member of the
	/// administrators local group, the source is added to the per-user list for the current user.
	/// </para>
	/// <para>
	/// <c>Note</c> If a temporary list is currently in use (see SetupSetSourceList), the preceding flags are ignored and the source is
	/// added to the temporary list.
	/// </para>
	/// <para>SRCLIST_APPEND</para>
	/// <para>Add the source to the end of the list. If this flag is not specified, the source is added to the beginning of the list.</para>
	/// </param>
	/// <param name="Source">Pointer to the source to be added to the list. You should use a null-terminated string.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupaddtosourcelista WINSETUPAPI BOOL
	// SetupAddToSourceListA( DWORD Flags, PCSTR Source );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAddToSourceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupAddToSourceList(SRCLIST Flags, [MarshalAs(UnmanagedType.LPTStr)] string Source);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupAdjustDiskSpaceList</c> function adjusts the amount of required space for a specified drive.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to a disk-space list.</param>
	/// <param name="DriveRoot">
	/// Specifies a valid Win32 drive root. An entry is added to the disk-space list if the specified drive is not currently in the
	/// disk-space list.
	/// </param>
	/// <param name="Amount">
	/// Specifies the amount of space to add or remove. Use a negative number to remove space and use a positive number to add space.
	/// </param>
	/// <param name="Reserved1">Unused, must be zero.</param>
	/// <param name="Reserved2">Unused, must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupadjustdiskspacelista WINSETUPAPI BOOL
	// SetupAdjustDiskSpaceListA( HDSKSPC DiskSpace, LPCSTR DriveRoot, LONGLONG Amount, PVOID Reserved1, UINT Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupAdjustDiskSpaceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupAdjustDiskSpaceList(HDSKSPC DiskSpace, [MarshalAs(UnmanagedType.LPTStr)] string DriveRoot, long Amount,
		IntPtr Reserved1 = default, uint Reserved2 = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupBackupError</c> function generates a dialog box that informs the user of a backup error.</para>
	/// </summary>
	/// <param name="hwndParent">Handle to the parent window for this dialog box.</param>
	/// <param name="DialogTitle">
	/// Optional pointer to a <c>null</c>-terminated string specifying the error dialog box title. If this parameter is <c>NULL</c>, the
	/// default title of "Backup Error" (localized) is used.
	/// </param>
	/// <param name="SourceFile">
	/// Pointer to a <c>null</c>-terminated string specifying the full path of the source file that is being backed up.
	/// </param>
	/// <param name="TargetFile">
	/// Optional pointer to a <c>null</c>-terminated string specifying the full path of the backup name of the file. This parameter can
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="Win32ErrorCode">If an error occurs, this member is the system error code. If no error has occurred, it is NO_ERROR.</param>
	/// <param name="Style">
	/// <para>Flags that control display formatting and behavior of the dialog box. This parameter can be one of the following flags.</para>
	/// <para>IDF_NOBEEP</para>
	/// <para>Prevent the dialog box from beeping to get the user's attention when it first appears.</para>
	/// <para>IDF_NOFOREGROUND</para>
	/// <para>Prevent the dialog box from becoming the foreground window.</para>
	/// </param>
	/// <returns>
	/// <para>This function returns one of the following values.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupbackuperrora WINSETUPAPI UINT SetupBackupErrorA(
	// HWND hwndParent, PCSTR DialogTitle, PCSTR SourceFile, PCSTR TargetFile, UINT Win32ErrorCode, DWORD Style );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupBackupErrorA")]
	public static extern uint SetupBackupError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DialogTitle,
		[MarshalAs(UnmanagedType.LPTStr)] string SourceFile, [MarshalAs(UnmanagedType.LPTStr)] string? TargetFile, Win32Error Win32ErrorCode, IDF Style);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupCancelTemporarySourceList</c> function cancels any temporary list and no-browse behavior and reestablishes standard
	/// list behavior.
	/// </para>
	/// </summary>
	/// <returns>
	/// If a temporary list was in effect, the return value is a nonzero value. Otherwise, the return value is zero. To get extended
	/// error information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcanceltemporarysourcelist WINSETUPAPI BOOL SetupCancelTemporarySourceList();
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCancelTemporarySourceList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupCancelTemporarySourceList();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCloseFileQueue</c> function destroys a setup file queue.</para>
	/// </summary>
	/// <param name="QueueHandle">Handle to an open setup file queue.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// The <c>SetupCloseFileQueue</c> function does not flush the queue; pending operations are not performed. To commit a file queue
	/// before closing it call SetupCommitFileQueue.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupclosefilequeue WINSETUPAPI BOOL SetupCloseFileQueue(
	// HSPFILEQ QueueHandle );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCloseFileQueue")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupCloseFileQueue(HSPFILEQ QueueHandle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupCloseInfFile</c> function closes the INF file opened by a call to SetupOpenInfFile. This function closes any INF
	/// files appended to it by calling SetupOpenAppendInfFile.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">Handle to the INF file to be closed.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcloseinffile WINSETUPAPI VOID SetupCloseInfFile(
	// HINF InfHandle );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCloseInfFile")]
	public static extern void SetupCloseInfFile(HINF InfHandle);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCloseLog</c> function closes the log files.</para>
	/// </summary>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>The log files are located in the Windows directory, and the file names are Setupact.log and Setuperr.log.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcloselog WINSETUPAPI VOID SetupCloseLog();
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCloseLog")]
	public static extern void SetupCloseLog();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCommitFileQueue</c> function performs file operations queued on a setup file queue.</para>
	/// <para>
	/// The best practice is to collect all the required file operations for the file queue and commit the queue only once because a
	/// file queue cannot be reused after it has been committed. If additional processing of the queue is required after it has been
	/// committed, the handle to the queue should be closed and a new file queue created. For more information, see Committing a Queue.
	/// </para>
	/// <para>If a file is modified, the caller of this function is required have privileges to write into the target directory.</para>
	/// </summary>
	/// <param name="Owner">Optional handle to a window to use as the parent of any progress dialog boxes.</param>
	/// <param name="QueueHandle">Handle to a setup file queue, as returned by SetupOpenFileQueue.</param>
	/// <param name="MsgHandler">
	/// Pointer to an optional callback routine to be notified of various significant events that are in the queue processing. For more
	/// information, see Default Queue Callback Routine or FileCallback If the callback routine is <c>null</c>,
	/// <c>SetupCommitFileQueue</c> returns <c>TRUE</c> and the error is 0 or NO_ERROR.
	/// </param>
	/// <param name="Context">
	/// Value that is passed to the callback function supplied by the MsgHandler parameter. If the default callback routine has been
	/// specified as MsgHandler, this context must be the context returned from SetupInitDefaultQueueCallback or SetupInitDefaultQueueCallbackEx.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The callback routine specified in MsgHandler should be compatible with the parameters that <c>SetupCommitFileQueue</c> passed to
	/// it during a queue commit.
	/// </para>
	/// <para>
	/// If Unicode is defined in your callback application, and you specify MsgHandler as the default queue callback routine, the
	/// callback routine will expect Unicode parameters. Otherwise, the default queue callback routine will expect ANSI parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcommitfilequeuea WINSETUPAPI BOOL
	// SetupCommitFileQueueA( HWND Owner, HSPFILEQ QueueHandle, PSP_FILE_CALLBACK_A MsgHandler, PVOID Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCommitFileQueueA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupCommitFileQueue([Optional] HWND Owner, HSPFILEQ QueueHandle, PSP_FILE_CALLBACK? MsgHandler, IntPtr Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupConfigureWmiFromInfSection</c> function configures the security of the WMI data that is exposed by an INF file when
	/// passed to the [DDInstall.WMI] section.
	/// </para>
	/// <para>
	/// It is used to establish security when the version of SetupAPI on the system does not natively support the WMI security
	/// information provided in the DDInstall section of the INF file.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">A handle to an open INF file.</param>
	/// <param name="SectionName">
	/// Name of the section in the INF file that contains WMI security information. This should be in the form of[DDinstall.WMI].
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be set as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SCWMI_CLOBBER_SECURITY 0x0001</term>
	/// <term>
	/// If and only if this flag is set does the security information passed to this function override any security information set
	/// elsewhere in the INF file. If this flag does not exist and no security information exists in the INF file, the security is set.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>This function returns WINSETUPAPI BOOL.</returns>
	/// <remarks>
	/// In previous SetupAPI versions, WMI information in INF files is exposed to all users, and access could only be limited by
	/// correctly writing binary data to a registry key. Current versions read and process WMI security information provided by the
	/// DDInstall section of an INF file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupconfigurewmifrominfsectiona WINSETUPAPI BOOL
	// SetupConfigureWmiFromInfSectionA( HINF InfHandle, PCSTR SectionName, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupConfigureWmiFromInfSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupConfigureWmiFromInfSection(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string SectionName, SCWMI Flags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCopyError</c> function generates a dialog box to notify a user of a copy file error.</para>
	/// </summary>
	/// <param name="hwndParent">The handle to the parent window for this dialog box.</param>
	/// <param name="DialogTitle">
	/// <para>An optional pointer to a <c>null</c>-terminated string that specifies the dialog box title.</para>
	/// <para>
	/// This parameter can be <c>NULL</c>. If this parameter is <c>NULL</c>, the default title of "Copy Error" (localized to the system
	/// language) is used.
	/// </para>
	/// </param>
	/// <param name="DiskName">
	/// <para>An optional pointer to a <c>null</c>-terminated string that specifies the name of the disk to insert.</para>
	/// <para>
	/// This parameter can be <c>NULL</c>. If this parameter is <c>NULL</c>, the default name "(Unknown)" (localized to the system
	/// language) is used.
	/// </para>
	/// </param>
	/// <param name="PathToSource">
	/// <para>A pointer to the path component of the source file where an operation fails, for example, F:\x86.</para>
	/// <para>Use a <c>null</c>-terminated string.</para>
	/// </param>
	/// <param name="SourceFile">
	/// <para>A pointer to a <c>null</c>-terminated string that specifies the filename part of the file where an operation fails.</para>
	/// <para>
	/// Use a <c>null</c>-terminated string. This filename is displayed if the user clicks on the <c>Details</c> or <c>Browse</c>
	/// buttons. The <c>SetupCopyError</c> function looks for the file that uses its compressed form names. Therefore, you can pass
	/// cmd.exe and not worry that the file actually exists as cmd.ex_ on the source media.
	/// </para>
	/// </param>
	/// <param name="TargetPathFile">
	/// <para>
	/// An optional pointer to a <c>null</c>-terminated string that specifies the full path of the target file for rename and copy operations.
	/// </para>
	/// <para>
	/// Use a <c>null</c>-terminated string. This parameter can be <c>NULL</c>. If TargetPathFile is not specified, "(Unknown)"
	/// (localized to the system language) is used.
	/// </para>
	/// </param>
	/// <param name="Win32ErrorCode">
	/// <para>If an error occurs, this member is the System Error Code.</para>
	/// <para>If an error does not occur, it is NO_ERROR.</para>
	/// </param>
	/// <param name="Style">
	/// <para>The flags that control display formatting and behavior of a dialog box.</para>
	/// <para>This parameter can be one of the following flags.</para>
	/// <para>IDF_NOBROWSE</para>
	/// <para>Do not display the browse option.</para>
	/// <para>IDF_NOSKIP</para>
	/// <para>Do not display the skip file option.</para>
	/// <para>IDF_NODETAILS</para>
	/// <para>Do not display the details option.</para>
	/// <para>If this flag is set, the TargetPathFile and Win32ErrorCode parameters can be omitted.</para>
	/// <para>IDF_NOCOMPRESSED</para>
	/// <para>Do not check for compressed versions of the source file.</para>
	/// <para>IDF_OEMDISK</para>
	/// <para>The operation source is a disk that a hardware manufacturer provides.</para>
	/// <para>IDF_NOBEEP</para>
	/// <para>Prevents the dialog box from beeping to get the user's attention when it first appears.</para>
	/// <para>IDF_NOFOREGROUND</para>
	/// <para>Prevents the dialog box from becoming the foreground window.</para>
	/// <para>IDF_WARNIFSKIP</para>
	/// <para>Warns the user that skipping a file can affect the installation.</para>
	/// </param>
	/// <param name="PathBuffer">
	/// <para>
	/// An optional pointer to a variable in which this function returns the path (not including the filename) of the location that a
	/// user specifies in the dialog box. You should use a null-terminated string.
	/// </para>
	/// <para>
	/// The <c>null</c>-terminated string should not exceed the size of the destination buffer. To avoid insufficient buffer errors,
	/// PathBuffer should be at least MAX_PATH. For more information, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="PathBufferSize">
	/// <para>The size of the buffer that PathBuffer points to, in characters.</para>
	/// <para>The buffer size should be at least MAX_PATH characters, including the <c>null</c> terminator.</para>
	/// </param>
	/// <param name="PathRequiredSize">
	/// An optional pointer to a variable in which this function returns the required buffer size, in characters, including the
	/// <c>null</c> terminator.
	/// </param>
	/// <returns>
	/// <para>The function returns one of the following values.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a PathBuffer of <c>NULL</c> and a PathBufferSize of 0 (zero), the function puts the buffer size
	/// that is needed to hold the specified data into the variable pointed to by PathRequiredSize.
	/// </para>
	/// <para>If the function succeeds, the return value is NO_ERROR. Otherwise, the return value is one of the specified values.</para>
	/// <para>To avoid insufficient buffer errors, ReturnBuffer should be at least MAX_PATH.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcopyerrora WINSETUPAPI UINT SetupCopyErrorA( HWND
	// hwndParent, PCSTR DialogTitle, PCSTR DiskName, PCSTR PathToSource, PCSTR SourceFile, PCSTR TargetPathFile, UINT Win32ErrorCode,
	// DWORD Style, PSTR PathBuffer, DWORD PathBufferSize, PDWORD PathRequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCopyErrorA")]
	public static extern uint SetupCopyError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DialogTitle,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? DiskName, [MarshalAs(UnmanagedType.LPTStr)] string PathToSource,
		[MarshalAs(UnmanagedType.LPTStr)] string SourceFile, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? TargetPathFile,
		Win32Error Win32ErrorCode, IDF Style, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? PathBuffer, uint PathBufferSize, out uint PathRequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCopyOEMInf</c> function copies a specified .inf file to the %windir%/Inf directory.</para>
	/// <para>A caller of this function is required have administrative privileges, otherwise the function fails.</para>
	/// </summary>
	/// <param name="SourceInfFileName">
	/// Full path to the source .inf file. You should use a null-terminated string. This path should not exceed <c>MAX_PATH</c> in size,
	/// including the terminating <c>NULL</c>.
	/// </param>
	/// <param name="OEMSourceMediaLocation">
	/// Source location information to be stored in the precompiled .inf (.pnf). This location information is specific to the source
	/// media type specified. You should use a null-terminated string. This path should not exceed <c>MAX_PATH</c> in size, including
	/// the terminating <c>NULL</c>.
	/// </param>
	/// <param name="OEMSourceMediaType">
	/// <para>Source media type referenced by the location information. This parameter may be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPOST_NONE</term>
	/// <term>No source media information is stored in the .pnf file. The value of OEMSourceMediaLocation is ignored in this case.</term>
	/// </item>
	/// <item>
	/// <term>SPOST_PATH</term>
	/// <term>
	/// OEMSourceMediaLocation contains a path to the source media. For example, if the media is on a floppy, this path might be "A:\".
	/// If OEMSourceMediaLocation is NULL, the path is assumed to be the path where the .inf is located. If the .inf has a corresponding
	/// .pnf in that location, the .pnf file's source media information is transferred to the destination .pnf file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPOST_URL</term>
	/// <term>
	/// OEMSourceMediaLocation contains a universal resource locator (URL) that specifies the Internet location from where the
	/// .inf/driver files were retrieved. If OEMSourceMediaLocation is NULL, it is assumed that the default Code Download Manager
	/// location was used.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Specifies how the .inf file is copied into the .inf directory. The following flags can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SP_COPY_DELETESOURCE</term>
	/// <term>Delete source file on successful copy.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_REPLACEONLY</term>
	/// <term>
	/// Copy only if this file already exists in the Inf directory. This flag could be used to update the source location information
	/// for an existing .inf.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NOOVERWRITE</term>
	/// <term>
	/// Copy only if the specified files do not currently exist in the Inf directory. If the .inf does currently exist, this API fails
	/// and GetLastError returns ERROR_FILE_EXISTS. In this case, the existing .inf file's filename is placed into the appropriate field
	/// in the destination .inf file's information output buffers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_OEMINF_CATALOG_ONLY</term>
	/// <term>
	/// The specified .inf file's corresponding catalog files is copied to %windir%\Inf. If this flag is specified, the destination
	/// filename information is entered upon successful return if the specified .inf file already exists in the Inf directory.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DestinationInfFileName">
	/// Pointer to a buffer to receive the .inf file name assigned to it at the time it was copied to the Inf directory. The buffer, if
	/// specified, should typically be <c>MAX_PATH</c> in length. If the SP_COPY_NOOVERWRITE flag is specified and the
	/// <c>SetupCopyOEMInf</c> function fails with a return code of ERROR_FILE_EXISTS, this buffer contains the name of the existing
	/// .inf file. If the SP_COPY_OEMINF_CATALOG_ONLY flag is specified, this buffer contains the destination .inf filename if the .inf
	/// file is already present in the Inf directory. Otherwise, this buffer is set to the empty string. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="DestinationInfFileNameSize">
	/// Size of the DestinationInfFileName buffer, in characters, or zero if the buffer is not specified. If DestinationInfFileName is
	/// specified and this buffer size is less than the size required to return the destination .inf filename (including full path),
	/// this function fails. In this case GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <param name="RequiredSize">
	/// Pointer to a variable that receives the size (in characters) required to store the destination .inf file name including a
	/// terminating <c>NULL</c>. If the SP_COPY_OEMINF_CATALOG_ONLY flag is specified, this variable receives a string length only if
	/// the .inf file already exists in the Inf directory. Otherwise, this variable is set to zero. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="DestinationInfFileNameComponent">
	/// Pointer to a string that is set upon successful return (or ERROR_FILE_EXISTS) to point to the beginning of the filename
	/// component of the path stored in the DestinationInfFileName parameter. If the SP_COPY_OEMINF_CATALOG_ONLY flag is specified, the
	/// DestinationInfFileName parameter may be an empty string. In this case, the character pointer is set to <c>NULL</c> upon
	/// successful return. This parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>This function returns WINSETUPAPI BOOL.</returns>
	/// <remarks>
	/// <para>
	/// The <c>SetupCopyOEMInf</c> function copies a specified .inf file into the %windir%\Inf directory. <c>SetupCopyOEMInf</c> does
	/// not recopy the file if it finds that a binary image of the specified .inf file already exists in the Inf directory with the same
	/// name or a name of the form OEM*.inf. When <c>SetupCopyOEMInf</c> copies a file, it renames the copied file to OEM*.inf. Name
	/// provided is unique and cannot be predicted.
	/// </para>
	/// <para><c>SetupCopyOEMInf</c> uses the following procedure to determine if the .inf file already exists in the Inf directory:</para>
	/// <para>
	/// All .inf files with names of the form OEM*.inf are enumerated and any files that have the same file size as the specified .inf
	/// file are binary compared.
	/// </para>
	/// <para>
	/// The Inf directory is searched for the source filename of the .inf file. If an .inf file of the same name exists and is the same
	/// size as that of the specified .inf file, the two files are binary compared to determine if they are identical.
	/// </para>
	/// <para>
	/// If the specified .inf file already exists a further check is performed to determine if the specified .inf file contains a
	/// CatalogFile= entry in its [Version] section. If it does, the .inf files's %windir%\Inf primary filename with a ".cat" extension
	/// is used to determine if the catalog is already installed. If there is a catalog installed, but it is not the same as the catalog
	/// associated with the source .inf, this is not considered to be a match and enumerations continue. It is possible to have multiple
	/// identical .inf files with unique catalogs contained in %windir%\Inf directory. If an existing match is not found, the .inf and
	/// .cat files are installed under a new and unique name.
	/// </para>
	/// <para>OEM .inf files that do not specify a CatalogFile= entry are considered invalid with respect to digital signature verification.</para>
	/// <para>
	/// In cases where the .inf file must be copied to the %windir%\Inf directory, any digital signature verification failures are reported.
	/// </para>
	/// <para>
	/// If the .inf and .cat files already exist, these existing filenames are used and the file replacement behavior is based on the
	/// specified CopyStyle flags. Replacement behavior refers only to the source media information stored in the .pnf. Existing .inf,
	/// .pnf, and .cat files are not modified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcopyoeminfa WINSETUPAPI BOOL SetupCopyOEMInfA( PCSTR
	// SourceInfFileName, PCSTR OEMSourceMediaLocation, DWORD OEMSourceMediaType, DWORD CopyStyle, PSTR DestinationInfFileName, DWORD
	// DestinationInfFileNameSize, PDWORD RequiredSize, PSTR *DestinationInfFileNameComponent );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCopyOEMInfA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupCopyOEMInf([MarshalAs(UnmanagedType.LPTStr)] string SourceInfFileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? OEMSourceMediaLocation, uint OEMSourceMediaType, CopyStyle CopyStyle,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? DestinationInfFileName, uint DestinationInfFileNameSize, out uint RequiredSize,
		[MarshalAs(UnmanagedType.LPTStr)] out StrPtrAuto DestinationInfFileNameComponent);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupCreateDiskSpaceList</c> function creates a disk-space list.</para>
	/// </summary>
	/// <param name="Reserved1">Unused, must be zero.</param>
	/// <param name="Reserved2">Unused, must be zero.</param>
	/// <param name="Flags">
	/// <para>This parameter can be the following value.</para>
	/// <para>SPDSL_IGNORE_DISK</para>
	/// <para>
	/// File operations added to the list will ignore files that already exist on the disk. For example, if the disk contains a
	/// 5000-byte file, C:\MyDir\MyFile, and you add a Copy operation to the disk-space list for a new version, C:\MyDir\MyFile, that is
	/// 6500 bytes, the space required will be 6500 bytes (instead of 1500 bytes, which is the value returned if you do not set SPDSL_IGNORE_DISK).
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the disk-space list.</para>
	/// <para>If the function fails, it returns null. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupcreatediskspacelista WINSETUPAPI HDSKSPC
	// SetupCreateDiskSpaceListA( PVOID Reserved1, DWORD Reserved2, UINT Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupCreateDiskSpaceListA")]
	public static extern SafeHDSKSPC SetupCreateDiskSpaceList([In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2, SPDSL Flags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupDecompressOrCopyFile</c> function copies a file, decompressing it if necessary.</para>
	/// <para>If a file is copied, the caller of this function is required have privileges to write into the target directory.</para>
	/// </summary>
	/// <param name="SourceFileName">
	/// File name of the file to be copied. You should use a <c>null</c>-terminated string. This parameter can be <c>NULL</c>. If
	/// CompressionType is not specified and the <c>SetupDecompressOrCopyFile</c> function does not find the file specified in
	/// SourceFileName, the function searches for the file with up to two alternate, "compressed-form" names. For example, if the file
	/// is F:\x86\cmd.exe and it is not found, the function searches for F:\x86\cmd.ex_ and, if that is not found, F:\x86\cmd.ex$ is
	/// searched for. If CompressionType is specified, no additional processing is performed on the filename; the file must exist
	/// exactly as specified or the function fails.
	/// </param>
	/// <param name="TargetFileName">
	/// Exact name of the target file that will be created by decompressing or copying the source file. You should use a
	/// <c>null</c>-terminated string.
	/// </param>
	/// <param name="CompressionType">
	/// Optional pointer to the compression type used on the source file. You can determine the compression type by calling
	/// SetupGetFileCompressionInfo. If this value is FILE_COMPRESSION_NONE, the file is copied (not decompressed) regardless of any
	/// compression in use on the source. If CompressionType is not specified, this routine determines the compression type automatically.
	/// </param>
	/// <returns>
	/// <para>The <c>SetupDecompressOrCopyFile</c> function returns a system error code that indicates the outcome of the operation.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdecompressorcopyfilea WINSETUPAPI DWORD
	// SetupDecompressOrCopyFileA( PCSTR SourceFileName, PCSTR TargetFileName, PUINT CompressionType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDecompressOrCopyFileA")]
	public static extern uint SetupDecompressOrCopyFile([MarshalAs(UnmanagedType.LPTStr)] string SourceFileName,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetFileName, in FILE_COMPRESSION CompressionType);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupDecompressOrCopyFile</c> function copies a file, decompressing it if necessary.</para>
	/// <para>If a file is copied, the caller of this function is required have privileges to write into the target directory.</para>
	/// </summary>
	/// <param name="SourceFileName">
	/// File name of the file to be copied. You should use a <c>null</c>-terminated string. This parameter can be <c>NULL</c>. If
	/// CompressionType is not specified and the <c>SetupDecompressOrCopyFile</c> function does not find the file specified in
	/// SourceFileName, the function searches for the file with up to two alternate, "compressed-form" names. For example, if the file
	/// is F:\x86\cmd.exe and it is not found, the function searches for F:\x86\cmd.ex_ and, if that is not found, F:\x86\cmd.ex$ is
	/// searched for. If CompressionType is specified, no additional processing is performed on the filename; the file must exist
	/// exactly as specified or the function fails.
	/// </param>
	/// <param name="TargetFileName">
	/// Exact name of the target file that will be created by decompressing or copying the source file. You should use a
	/// <c>null</c>-terminated string.
	/// </param>
	/// <param name="CompressionType">
	/// Optional pointer to the compression type used on the source file. You can determine the compression type by calling
	/// SetupGetFileCompressionInfo. If this value is FILE_COMPRESSION_NONE, the file is copied (not decompressed) regardless of any
	/// compression in use on the source. If CompressionType is not specified, this routine determines the compression type automatically.
	/// </param>
	/// <returns>
	/// <para>The <c>SetupDecompressOrCopyFile</c> function returns a system error code that indicates the outcome of the operation.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdecompressorcopyfilea WINSETUPAPI DWORD
	// SetupDecompressOrCopyFileA( PCSTR SourceFileName, PCSTR TargetFileName, PUINT CompressionType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDecompressOrCopyFileA")]
	public static extern uint SetupDecompressOrCopyFile([MarshalAs(UnmanagedType.LPTStr)] string SourceFileName,
		[MarshalAs(UnmanagedType.LPTStr)] string TargetFileName, [In] IntPtr CompressionType = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupDefaultQueueCallback</c> function is the default queue callback routine included with the Setup API. You can use it
	/// to process notifications sent by the SetupCommitFileQueue function.
	/// </para>
	/// </summary>
	/// <param name="Context">
	/// Pointer to the context initialized by the SetupInitDefaultQueueCallback or SetupInitDefaultQueueCallbackEx functions.
	/// </param>
	/// <param name="Notification">
	/// <para>Notification of a queue action. This parameter can be one of the values shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPFILENOTIFY_STARTQUEUE</term>
	/// <term>Started queued file operations.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_ENDQUEUE</term>
	/// <term>Finished queued file operations.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_STARTSUBQUEUE</term>
	/// <term>Started a copy, rename, or delete subqueue.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_ENDSUBQUEUE</term>
	/// <term>Finished a copy, rename, or delete subqueue.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_STARTRENAME</term>
	/// <term>Started a rename operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_ENDRENAME</term>
	/// <term>Finished a rename operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_RENAMEERROR</term>
	/// <term>Encountered an error while renaming a file.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_STARTDELETE</term>
	/// <term>Started a delete operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_ENDDELETE</term>
	/// <term>Finished a delete operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_DELETEERROR</term>
	/// <term>Encountered an error while deleting a file.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_STARTCOPY</term>
	/// <term>Started a copy operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_ENDCOPY</term>
	/// <term>Finished a copy operation.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_COPYERROR</term>
	/// <term>Encountered an error while copying a file.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_NEEDMEDIA</term>
	/// <term>New media is required.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_LANGMISMATCH</term>
	/// <term>Existing target file is in a different language than the source.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_TARGETEXISTS</term>
	/// <term>Target file exists.</term>
	/// </item>
	/// <item>
	/// <term>SPFILENOTIFY_TARGETNEWER</term>
	/// <term>Existing target file is newer than source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Param1">
	/// Additional message information. The content of this parameter depends on the value of the Notification parameter.
	/// </param>
	/// <param name="Param2">
	/// Additional message information. The content of this parameter depends on the value of the Notification parameter.
	/// </param>
	/// <returns>
	/// <para>Returns an unsigned integer to SetupCommitFileQueue that can be the one of the values shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>FILEOP_ABORT</term>
	/// <term>Aborts the operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_DOIT</term>
	/// <term>Performs the file operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_SKIP</term>
	/// <term>Skips the operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_RETRY</term>
	/// <term>Retries the operation.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_NEWPATH</term>
	/// <term>Gets a new path for the operation.</term>
	/// </item>
	/// </list>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetupDefaultQueueCallback</c> function is usually only called explicitly by a custom queue callback routine. The custom
	/// callback handles a subset of the queue commit notifications and calls the <c>SetupDefaultQueueCallback</c> function to handle
	/// the rest of the notifications.
	/// </para>
	/// <para>For more information see, Queue Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdefaultqueuecallbacka WINSETUPAPI UINT
	// SetupDefaultQueueCallbackA( PVOID Context, UINT Notification, UINT_PTR Param1, UINT_PTR Param2 );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDefaultQueueCallbackA")]
	public static extern FILEOP_RESULT SetupDefaultQueueCallback([In] IntPtr Context, SPFILENOTIFY Notification, [In] IntPtr Param1, [In] IntPtr Param2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupDeleteError</c> function generates a dialog box that informs the user of a delete error.</para>
	/// </summary>
	/// <param name="hwndParent">Handle to the parent window for this dialog box.</param>
	/// <param name="DialogTitle">
	/// Optional pointer to a <c>null</c>-terminated string specifying the error dialog box title. If this parameter is <c>NULL</c>, the
	/// default title of "Delete Error" (localized) is used.
	/// </param>
	/// <param name="File">
	/// Pointer to a <c>null</c>-terminated string specifying the full path of the file on which the delete operation failed.
	/// </param>
	/// <param name="Win32ErrorCode">The system error code encountered during the file operation.</param>
	/// <param name="Style">
	/// <para>Flags that control display formatting and behavior of the dialog box. This parameter can be one of the following flags.</para>
	/// <para>IDF_NOBEEP</para>
	/// <para>Prevent the dialog box from beeping to get the user's attention when it first appears.</para>
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
	/// The setupapi.h header defines SetupDeleteError as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdeleteerrora WINSETUPAPI UINT SetupDeleteErrorA(
	// HWND hwndParent, PCSTR DialogTitle, PCSTR File, UINT Win32ErrorCode, DWORD Style );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDeleteErrorA")]
	public static extern uint SetupDeleteError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DialogTitle,
		[MarshalAs(UnmanagedType.LPTStr)] string File, Win32Error Win32ErrorCode, IDF Style);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupDestroyDiskSpaceList</c> function destroys a disk-space list and releases the resources allocated to it.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list to be deconstructed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdestroydiskspacelist WINSETUPAPI BOOL
	// SetupDestroyDiskSpaceList( HDSKSPC DiskSpace );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDestroyDiskSpaceList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDestroyDiskSpaceList(HDSKSPC DiskSpace);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The SetupDuplicateDiskSpaceList function duplicates a disk-space list as a new independent disk-space list.</para>
	/// </summary>
	/// <param name="DiskSpace">Handle to the disk-space list to be duplicated.</param>
	/// <param name="Reserved1">Unused, must be zero.</param>
	/// <param name="Reserved2">Unused, must be zero.</param>
	/// <param name="Flags">Unused, must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the new disk-space list.</para>
	/// <para>If the function fails, it returns null. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupDuplicateDiskSpaceList as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupduplicatediskspacelista WINSETUPAPI HDSKSPC
	// SetupDuplicateDiskSpaceListA( HDSKSPC DiskSpace, PVOID Reserved1, DWORD Reserved2, UINT Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDuplicateDiskSpaceListA")]
	public static extern SafeHDSKSPC SetupDuplicateDiskSpaceList(HDSKSPC DiskSpace, IntPtr Reserved1 = default, uint Reserved2 = default, uint Flags = default);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupEnumInfSections</c> function retrieves section names from an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">Handle to the INF file that is to be queried.</param>
	/// <param name="Index">
	/// The zero-based index of the section name to retrieve. This index may not correspond to the order of sections as they appear in
	/// the INF file.
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a buffer that receives the section name. You can call the function once to get the required buffer size, allocate the
	/// necessary memory, and then call the function a second time to retrieve the name. Using this technique, you can avoid errors
	/// caused by an insufficient buffer size. This parameter is optional. For more information, see the Remarks section.
	/// </param>
	/// <param name="Size">
	/// Size of the buffer pointed to by ReturnBuffer in characters. This number includes the terminating <c>NULL</c> character.
	/// </param>
	/// <param name="SizeNeeded">
	/// Pointer to a location that receives the required size of the buffer pointed to by ReturnBuffer. The size is specified as the
	/// number of characters required to store the section name, including the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// <para>
	/// GetLastError returns <c>ERROR_NO_MORE_ITEMS</c> if the value of <c>EnumerationIndex</c> is greater than or equal to the number
	/// of sections names in the INF file.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can enumerate all unique section names in the INF file. If a section name appears more than once in an INF file,
	/// the function returns the name only once using a single enumeration index. To return all section names in the INF file, call the
	/// function beginning with an enumeration index of zero and then make repeated calls to the function while incrementing the index
	/// until the function returns <c>FALSE</c> and GetLastError returns <c>ERROR_NO_MORE_ITEMS</c>. Your application should not rely on
	/// the section names being returned in any order based on the enumeration index.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupEnumInfSections as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupenuminfsectionsa WINSETUPAPI BOOL
	// SetupEnumInfSectionsA( HINF InfHandle, UINT Index, PSTR Buffer, UINT Size, UINT *SizeNeeded );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupEnumInfSectionsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupEnumInfSections(HINF InfHandle, uint Index, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? Buffer, uint Size, out uint SizeNeeded);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupFindFirstLine</c> function locates a line in the specified section of an INF file. If the Key parameter is
	/// <c>NULL</c>, <c>SetupFindFirstLine</c> returns the first line of the section.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">Handle to the INF file to query.</param>
	/// <param name="Section">Pointer to a <c>null</c>-terminated string specifying the section of the INF files to search in.</param>
	/// <param name="Key">
	/// Optional pointer to a <c>null</c>-terminated string specifying the key to search for within the section. The
	/// <c>null</c>-terminated string should not exceed the size of the destination buffer. This parameter can be <c>NULL</c>. If Key is
	/// <c>NULL</c>, the first line in the section is returned.
	/// </param>
	/// <param name="Context">
	/// Pointer to a structure that receives the context information used internally by the INF handle. Applications must not overwrite
	/// values in this structure.
	/// </param>
	/// <returns>If the function could not find a line, the return value is zero. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// If the InfHandle parameter references multiple INF files that have been appended together using SetupOpenAppendInfFile, the
	/// <c>SetupFindFirstLine</c> function searches across the specified section in all of the files referenced by the specified HINF.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupFindFirstLine as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupfindfirstlinea WINSETUPAPI BOOL SetupFindFirstLineA(
	// HINF InfHandle, PCSTR Section, PCSTR Key, PINFCONTEXT Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupFindFirstLineA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupFindFirstLine(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string Section,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, out INFCONTEXT Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupFindNextLine</c> returns the location of the next line in an INF file section relative to ContextIn.Line.</para>
	/// </summary>
	/// <param name="ContextIn">Pointer to the INF file context retrieved by a call to the SetupFindFirstLine function.</param>
	/// <param name="ContextOut">
	/// Pointer to a variable in which this function returns the context of the found line. ContextOut can point to ContextIn if the
	/// caller wishes.
	/// </param>
	/// <returns>
	/// If this function finds the next line, the return value is a nonzero value. Otherwise, the return value is zero. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// If ContextIn.Line references multiple INF files that have been appended together using SetupOpenAppendInfFile, this function
	/// searches across the specified section in all files referenced by the HINF to locate the next line.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupfindnextline WINSETUPAPI BOOL SetupFindNextLine(
	// PINFCONTEXT ContextIn, PINFCONTEXT ContextOut );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupFindNextLine")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupFindNextLine(in INFCONTEXT ContextIn, out INFCONTEXT ContextOut);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupFindNextMatchLine</c> function returns the location of the next line in an INF file relative to ContextIn.Line that
	/// matches a specified key.
	/// </para>
	/// </summary>
	/// <param name="ContextIn">Pointer to an INF file context, as retrieved by a call to the SetupFindFirstLine function.</param>
	/// <param name="Key">
	/// If this optional parameter is specified, it supplies a key to match. This parameter should be a null-terminated string. This
	/// parameter can be Null. If Key is not specified, the <c>SetupFindNextMatchLine</c> function is equivalent to the
	/// SetupFindNextLine function.
	/// </param>
	/// <param name="ContextOut">
	/// Pointer to a variable in which this function returns the context of the found line. ContextOut can point to ContextIn if the
	/// caller wishes.
	/// </param>
	/// <returns>
	/// The function returns a nonzero value if it finds a matching line. Otherwise, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If ContextIn.Inf references multiple INF files that have been appended together using SetupOpenAppendInfFile, the
	/// <c>SetupFindNextMatchLine</c> function searches across the specified section in all files referenced by the HINF to locate the
	/// next matching line.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupFindNextMatchLine as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupfindnextmatchlinea WINSETUPAPI BOOL
	// SetupFindNextMatchLineA( PINFCONTEXT ContextIn, PCSTR Key, PINFCONTEXT ContextOut );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupFindNextMatchLineA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupFindNextMatchLine(in INFCONTEXT ContextIn, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, out INFCONTEXT ContextOut);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupFreeSourceList</c> function frees the system resources allocated to a source list.</para>
	/// </summary>
	/// <param name="List">
	/// Pointer to an array of sources from SetupQuerySourceList. The <c>null</c>-terminated string should not exceed the size of the
	/// destination buffer. When the function returns, this pointer is set to <c>NULL</c>.
	/// </param>
	/// <param name="Count">Number of sources in the list.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupFreeSourceList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupfreesourcelista WINSETUPAPI BOOL
	// SetupFreeSourceListA( PCSTR **List, UINT Count );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupFreeSourceListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupFreeSourceList(IntPtr List, uint Count);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetBinaryField</c> function retrieves binary data from a line in an INF file section, from the specified field to
	/// the end of the line.
	/// </para>
	/// </summary>
	/// <param name="Context">INF context for the line.</param>
	/// <param name="FieldIndex">
	/// The 1-based index of the starting field within the specified line from which the binary data should be retrieved. The binary
	/// data is built from each field, starting at this point to the end of the line. Each field corresponds to 1 byte and is in
	/// hexadecimal notation. A FieldIndex of zero is not valid with this function.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer that receives the binary data. You should ensure the destination buffer is the same size or larger
	/// than the source buffer. You can call the function once to get the required buffer size, allocate the necessary memory, and then
	/// call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer
	/// size. See the Remarks section.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This number includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to ReturnBuffer, in characters. This
	/// number includes the <c>null</c> terminator. If the size needed is larger than the value specified by ReturnBufferSize, the
	/// function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// GetLastError returns ERROR_INVALID_DATA if a field that <c>SetupGetBinaryField</c> retrieves is not a valid hexadecimal number
	/// in the range 0-FF.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>To better understand how this function works, consider the following line from an INF file.</para>
	/// <para>
	/// <code>X=34,FF,00,13</code>
	/// </para>
	/// <para>
	/// If <c>SetupGetBinaryField</c> was called on the preceding line, the binary values 34, FF, 00, and 13 would be put into the
	/// buffer specified by ReturnBuffer.
	/// </para>
	/// <para>
	/// For the Unicode version of this function, the buffer sizes ReturnBufferSize and RequiredSize are specified in number of
	/// characters. This number includes the <c>null</c> terminator. For the ANSI version of this function, the sizes are specified in
	/// number of bytes.
	/// </para>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// Thus, you can call the function once to get the required buffer size, allocate the necessary memory, and then call the function
	/// a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetbinaryfield WINSETUPAPI BOOL SetupGetBinaryField(
	// PINFCONTEXT Context, DWORD FieldIndex, PBYTE ReturnBuffer, DWORD ReturnBufferSize, LPDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetBinaryField")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetBinaryField(in INFCONTEXT Context, uint FieldIndex, [Out, Optional] IntPtr ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetFieldCount</c> function retrieves the number of fields in the specified line in an INF file.</para>
	/// </summary>
	/// <param name="Context">Pointer to the context for a line in an INF file.</param>
	/// <returns>
	/// This function returns the number of fields on the line. If Context is invalid, 0 is returned. To get extended error information,
	/// call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetfieldcount WINSETUPAPI DWORD SetupGetFieldCount(
	// PINFCONTEXT Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFieldCount")]
	public static extern uint SetupGetFieldCount(in INFCONTEXT Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetFileCompressionInfo</c> function examines a physical file to determine if it is compressed and gets its full
	/// path, size, and the size of the uncompressed target file.
	/// </para>
	/// <para>
	/// Note that this function is obsolete and has been replaced by SetupGetFileCompressionInfoEx. Do not use
	/// <c>SetupGetFileCompressionInfo</c>, instead always use <c>SetupGetFileCompressionInfoEx</c>.
	/// </para>
	/// </summary>
	/// <param name="SourceFileName">
	/// File name of the file about which information is required. If the file is not found on the source media exactly as named, the
	/// file is searched for with up to two alternate "compressed-form" names. For example, if the file is F:\x86\cmd.exe and it is not
	/// found, F:\mpis\cmd.ex_ is searched for and, if that is not found, a search is done for F:\x86\cmd.ex$. You should use a
	/// null-terminated string.
	/// </param>
	/// <param name="ActualSourceFileName">
	/// Pointer to a variable that receives the full path of the file that it has been able to locate. The caller can free the pointer
	/// with a call to <c>LocalFree</c>. The path is valid only if the function returns NO_ERROR. Note that if the version of
	/// SetupAPI.dll is less than 5.0.2195, then the caller needs to use the exported function <c>MyFree</c> from SetupAPI to free the
	/// memory allocated by this function, rather then using <c>LocalFree</c>. See the Remarks section.
	/// </param>
	/// <param name="SourceFileSize">
	/// Pointer to a variable in which this function returns the size of the file in its current form which is the current size of the
	/// file named by ActualSourceFileName. The size is determined by examining the source file; it is not retrieved from an INF file.
	/// The source file size is valid only if the function returns NO_ERROR.
	/// </param>
	/// <param name="TargetFileSize">
	/// Pointer to a variable in which this function returns the size the file will occupy when it is uncompressed or copied. If the
	/// file is not compressed, this value will be the same as SourceFileSize. The size is determined by examining the file; it is not
	/// retrieved from an INF file. The target file size is valid only if the function returns NO_ERROR.
	/// </param>
	/// <param name="CompressionType">
	/// <para>
	/// Pointer to a variable in which this function returns a value indicating the type of compression used on ActualSourceFileName.
	/// The compression type is valid only if the function returns NO_ERROR. The value can be one of the following flags.
	/// </para>
	/// <para>FILE_COMPRESSION_NONE</para>
	/// <para>The source file is not compressed with a recognized compression algorithm.</para>
	/// <para>FILE_COMPRESSION_WINLZA</para>
	/// <para>The source file is compressed with LZ compression.</para>
	/// <para>FILE_COMPRESSION_MSZIP</para>
	/// <para>The source file is compressed with MSZIP compression.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns a system error code that indicates the outcome of the file search. The error code can be one of the
	/// following values.
	/// </para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Do not use <c>SetupGetFileCompressionInfo</c>, instead always use SetupGetFileCompressionInfoEx.</para>
	/// <para>
	/// Because <c>SetupGetFileCompressionInfo</c> determines the compression by referencing the physical file, your setup application
	/// should ensure that the file is present before calling <c>SetupGetFileCompressionInfo</c>.
	/// </para>
	/// <para>
	/// Note that if the version of SetupAPI.dll is less than 5.0.2195, then the caller needs to use the exported function <c>MyFree</c>
	/// from SetupAPI to free the memory allocated by this function, rather then using <c>LocalFree</c>. If the call to <c>LocalFree</c>
	/// causes an Access Violation, you should solve the problem by using <c>MyFree</c>.
	/// </para>
	/// <para>The following is an example of how to obtain the <c>MyFree</c> function from the SetupAPI.dll:</para>
	/// <para>
	/// <code>typedef VOID (WINAPI* MYFREEFUNC)(LPVOID lpBuff);
	/// MYFREEFUNC MyFree;
	/// HMODULE hDll=NULL;
	/// hDll = GetModuleHandle("SETUPAPI.DLL");
	/// MyFree = (MYFREEFUNC)GetProcAddress(hDll, "MyFree");
	/// ...
	/// other code here to prepare file queue
	/// ...
	/// PTSTR lpActualSourceFileName;
	/// SetupGetFileCompressionInfo(...,&amp;lpActualSourceFileName,...,...,...);
	/// ...
	/// MyFree(lpActualSourceFileName);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetfilecompressioninfoa WINSETUPAPI DWORD
	// SetupGetFileCompressionInfoA( PCSTR SourceFileName, PSTR *ActualSourceFileName, PDWORD SourceFileSize, PDWORD TargetFileSize,
	// PUINT CompressionType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileCompressionInfoA")]
	public static extern uint SetupGetFileCompressionInfo([MarshalAs(UnmanagedType.LPTStr)] string SourceFileName,
		[MarshalAs(UnmanagedType.LPTStr)] out string ActualSourceFileName, out uint SourceFileSize, out uint TargetFileSize,
		out FILE_COMPRESSION CompressionType);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetFileCompressionInfoEx</c> function examines a potentially compressed file and gets the type of compression, the
	/// file's full path (including file name), the compressed size, and the size of the uncompressed target file. The caller of the
	/// function passes in the name of the file to be examined and pointers to locations for the buffer and buffer size to receive the
	/// returned file name and path.
	/// </para>
	/// <para>
	/// To determine the size of the buffer for the returned path and file name, you can call <c>SetupGetFileCompressionInfoEx</c> with
	/// ActualSourceFileNameBuffer specified <c>Null</c> and ActualSourceFileNameLen containing 0. The function succeeds and on return
	/// fills in RequiredBufferLen.
	/// </para>
	/// </summary>
	/// <param name="SourceFileName">
	/// File name of the potentially compressed file to be examined. If the file is not found on the source media exactly as named,
	/// Setup searches for up to two alternate names. For example; if Setup does not find F:\x86\cmd.exe, it searches for
	/// F:\mpis\cmd.ex_ and if that name is not found, it searches for F:\x86\cmd.ex$.
	/// </param>
	/// <param name="ActualSourceFileNameBuffer">
	/// Pointer to a buffer that receives the actual file name and path if this parameter is not <c>NULL</c>. This is valid only if the
	/// function returns NO_ERROR.
	/// </param>
	/// <param name="ActualSourceFileNameBufferLen">
	/// Size of the buffer specified by ActualSourceFileNameBuffer, in characters. You would typically use a buffer size of MAX_PATH. If
	/// ActualSourceFileNameLen is too small, the function fails with ERROR_INSUFFICIENT_BUFFER. ActualSourceFileNameLen must contain
	/// zero if ActualSourceFileNameBuffer is <c>NULL</c>.
	/// </param>
	/// <param name="RequiredBufferLen">
	/// Size of the file name and full path including the terminating <c>NULL</c>, if this parameter is not <c>NULL</c>. If
	/// ActualSourceFileNameBuffer is <c>NULL</c> and ActualSourceFileNameLen is zero, the function succeeds but fills in
	/// RequiredBufferLen. This parameter is valid only if the function returns NO_ERROR or ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <param name="SourceFileSize">
	/// Pointer to a variable in which this function returns the size of the file in its current form, which is the current size of the
	/// file named by ActualSourceFileNameBuffer. The size is determined by examining the source file; it is not retrieved from an INF
	/// file. The source file size is valid only if the function returns NO_ERROR or ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <param name="TargetFileSize">
	/// Pointer to a variable in which this function returns the size that the file will occupy when it is uncompressed or copied. If
	/// the file is not compressed, this value will be the same as SourceFileSize. The size is determined by examining the file; it is
	/// not retrieved from an INF file. The target file size is valid only if the function returns NO_ERROR or ERROR_INSUFFICIENT_BUFFER.
	/// </param>
	/// <param name="CompressionType">
	/// <para>
	/// Pointer to a variable in which this function returns a value indicating the type of compression used on ActualSourceFileName.
	/// The compression type is valid only if the function returns NO_ERROR or ERROR_INSUFFICIENT_BUFFER. This parameter value can be
	/// one of the following flags.
	/// </para>
	/// <para>FILE_COMPRESSION_NONE</para>
	/// <para>The source file is not compressed with a recognized compression algorithm.</para>
	/// <para>FILE_COMPRESSION_WINLZA</para>
	/// <para>The source file is compressed with LZ compression.</para>
	/// <para>FILE_COMPRESSION_MSZIP</para>
	/// <para>The source file is compressed with MSZIP compression.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c> (nonzero).</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c> (zero). The function can also return one of the following system error codes.
	/// </para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because <c>SetupGetFileCompressionInfoEx</c> determines the compression by examining the physical file, your setup application
	/// should ensure that the file is present before calling <c>SetupGetFileCompressionInfoEx</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetFileCompressionInfoEx as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetfilecompressioninfoexa WINSETUPAPI BOOL
	// SetupGetFileCompressionInfoExA( PCSTR SourceFileName, PSTR ActualSourceFileNameBuffer, DWORD ActualSourceFileNameBufferLen,
	// PDWORD RequiredBufferLen, PDWORD SourceFileSize, PDWORD TargetFileSize, PUINT CompressionType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileCompressionInfoExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetFileCompressionInfoEx([MarshalAs(UnmanagedType.LPTStr)] string SourceFileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? ActualSourceFileNameBuffer, uint ActualSourceFileNameBufferLen,
		out uint RequiredBufferLen, out uint SourceFileSize, out uint TargetFileSize, out uint CompressionType);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetFileQueueCount</c> function gets the count from a setup file queue.</para>
	/// </summary>
	/// <param name="FileQueue">Handle to an open setup file queue.</param>
	/// <param name="SubQueueFileOp">
	/// <para>Flag that specifies which subqueue count to be returned.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILEOP_COPY</term>
	/// <term>Return the number of entries in the copy subqueue.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_RENAME</term>
	/// <term>Return the number of entries in the rename subqueue.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_DELETE</term>
	/// <term>Return the number of entries in the delete subqueue.</term>
	/// </item>
	/// <item>
	/// <term>FILEOP_BACKUP</term>
	/// <term>Return the number of entries in the backup subqueue.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="NumOperations">Count from the setup file queue.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetfilequeuecount WINSETUPAPI BOOL
	// SetupGetFileQueueCount( HSPFILEQ FileQueue, UINT SubQueueFileOp, PUINT NumOperations );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileQueueCount")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetFileQueueCount(HSPFILEQ FileQueue, FILEOP SubQueueFileOp, out uint NumOperations);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetFileQueueFlags</c> function gets the flags from a setup file queue.</para>
	/// </summary>
	/// <param name="FileQueue">Handle to an open setup file queue.</param>
	/// <param name="Flags">
	/// <para>Pointer to location that contains the flag set with SetupSetFileQueueFlags and returned by <c>SetupGetFileQueueFlags</c>.</para>
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
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetfilequeueflags WINSETUPAPI BOOL
	// SetupGetFileQueueFlags( HSPFILEQ FileQueue, PDWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetFileQueueFlags")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetFileQueueFlags(HSPFILEQ FileQueue, out SPQ_FLAG Flags);

	/// <summary>
	/// The <c>SetupGetInfDriverStoreLocation</c> function retrieves the fully qualified file name (directory path and file name) of an
	/// INF file in the driver store that corresponds to a specified INF file in the system INF file directory or a specified INF file
	/// in the driver store.
	/// </summary>
	/// <param name="FileName">
	/// <para>
	/// A pointer to a NULL-terminated string that contains the name, and optionally the full directory path, of an INF file in the
	/// system INF file directory. Alternatively, this parameter is a pointer to a NULL-terminated string that contains the fully
	/// qualified file name (directory path and file name) of an INF file in the driver store.
	/// </para>
	/// <para>For more information about how to specify the INF file, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="AlternatePlatformInfo">Reserved for system use.</param>
	/// <param name="LocaleName">Reserved for system use.</param>
	/// <param name="ReturnBuffer">
	/// A pointer to a buffer in which the function returns a NULL-terminated string that contains the fully qualified file name of the
	/// specified INF file. This parameter can be set to <c>NULL</c>. The maximum supported path size is MAX_PATH. For information about
	/// how to determine the required size of the buffer, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="ReturnBufferSize">The size, in characters, of the buffer supplied by ReturnBuffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the size, in characters, of the ReturnBuffer buffer. This parameter is
	/// optional and can be set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If <c>SetupGetInfDriverStoreLocation</c> succeeds, the function returns <c>TRUE</c>; otherwise, the function returns
	/// <c>FALSE</c>. To obtain extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// If the size, in characters, of the fully qualified file name of the requested INF file, including a null-terminator, is greater
	/// than ReturnBufferSize, the function will fail, and a call to GetLastError will return ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine the size of the return buffer that is required to contain the fully qualified file name of the specified INF file
	/// in the driver store, call <c>SetupGetInfDriverStoreLocation</c> and set ReturnBuffer to <c>NULL</c>, ReturnBufferSize to zero,
	/// and supply RequiredSize. <c>SetupGetInfDriverStoreLocation</c> will return the required buffer size in RequiredSize.
	/// </para>
	/// <para>
	/// When device installation preinstalls a driver package in the driver store, it creates two copies of the driver package INF file.
	/// Device installation installs one copy in the system INF directory and assigns that copy of the INF file a unique published file
	/// name of the form OEMnnn.inf. Device installation installs a second copy of the INF file in the driver store and assigns that
	/// copy the original INF file name.
	/// </para>
	/// <para>
	/// <c>SetupGetInfDriverStoreLocation</c> returns the fully qualified file name of the INF file in the driver store that matches the
	/// INF file, if any, that is supplied by FileName. Filename must specify the file name, and optionally the directory path, of an
	/// INF file in the system INF directory. Alternatively, Filename must specify the fully qualified file name of an INF file in the
	/// driver store.
	/// </para>
	/// <para>
	/// For example, assume that the INF file for a driver package is Myinf.inf, and that for this driver package, device installation
	/// installs the INF file OEM1.inf in the system INF directory C:\Windows\inf. Further assume that device installation installs the
	/// corresponding INF file copy C:\windows\system32\driverstore\filerepository\myinf_12345678\myinf.inf in the driver store. In this
	/// case, the function returns C:\windows\system32\driverstore\filerepository\myinf_12345678\myinf.inf if FileName supplies one of
	/// the following strings: OEM1.inf, C:\Windows\inf\OEM1.inf, or C:\windows\system32\driverstore\filerepository\myinf_12345678\myinf.inf.
	/// </para>
	/// <para>
	/// Class installers and co-installers can use <c>SetupGetInfDriverStoreLocation</c> to access files in a driver package that is
	/// preinstalled in the driver store. To determine the path of the driver package in the driver store, the installer does the following:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Call SetupDiGetDriverInfoDetail to retrieve a SP_DRVINFO_DETAIL_DATA structure for a driver. The <c>InfFileName</c> member of
	/// this structure contains the fully qualified file name of the driver INF file in the system INF directory.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>SetupGetInfDriverStoreLocation</c> and supply the fully qualified file name of the driver INF file that was retrieved by
	/// calling <c>SetupDiGetDriverInfoDetail</c>. <c>SetupGetInfDriverStoreLocation</c> will return the fully qualified file name of
	/// the driver INF file in the driver store. The directory path part of the fully qualified file name of the INF file is the path of
	/// the driver package files.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c><c>SetupGetInfDriverStoreLocation</c> does not process the contents of the INF file that is specified in FileName.
	/// You cannot use this function to perform a content-specific search for an INF file in the driver store.
	/// </para>
	/// <para>
	/// Call the SetupGetInfPublishedName function to retrieve the fully qualified file name of an INF file in the system INF file
	/// directory that corresponds to a specified INF file in the system INF file directory or a specified file in the driver store.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetInfDriverStoreLocation as an alias which automatically selects the ANSI or Unicode version
	/// of this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with
	/// code that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetinfdriverstorelocationa WINSETUPAPI BOOL
	// SetupGetInfDriverStoreLocationA( PCSTR FileName, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PCSTR LocaleName, PSTR ReturnBuffer,
	// DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfDriverStoreLocationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetInfDriverStoreLocation([MarshalAs(UnmanagedType.LPTStr)] string FileName,
		[In, Optional] IntPtr AlternatePlatformInfo, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? LocaleName,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetInfFileList</c> function returns a list of INF files located in a caller-specified directory to a call-supplied buffer.
	/// </para>
	/// </summary>
	/// <param name="DirectoryPath">
	/// Optional pointer to a <c>null</c>-terminated string containing the path of the directory in which to search. If this value is
	/// <c>NULL</c>, the %windir%\inf directory is used.
	/// </param>
	/// <param name="InfStyle">
	/// <para>Type of INF file to search for. May be a combination of the following flags.</para>
	/// <para>INF_STYLE_OLDNT</para>
	/// <para>A legacy INF file format.</para>
	/// <para>INF_STYLE_WIN4</para>
	/// <para>A Windows INF file format.</para>
	/// </param>
	/// <param name="ReturnBuffer">
	/// If not <c>NULL</c>, points to a buffer in which this function returns the list of all INF files of the desired styles that were
	/// found in the specified subdirectory. File names are <c>null</c>-terminated, with an extra <c>null</c> at the end of the list.
	/// The <c>null</c>-terminated string should not exceed the size of the destination buffer. You can call the function once to get
	/// the required buffer size, allocate the necessary memory, and then call the function a second time to retrieve the data. Using
	/// this technique, you can avoid errors due to an insufficient buffer size. The filenames do not include the path. See the Remarks section.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by the ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator. If
	/// ReturnBuffer is not specified, ReturnBufferSize is ignored.
	/// </param>
	/// <param name="RequiredSize">
	/// If not <c>NULL</c>, points to a variable in which this function returns the required size for the buffer pointed to by the
	/// ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator. If ReturnBuffer is specified and the size
	/// needed is larger than ReturnBufferSize, the function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
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
	/// If multiple INF file styles are returned by this function, the style of a particular INF file can be determined by calling the
	/// SetupGetInfInformation function
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetInfFileList as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetinffilelista WINSETUPAPI BOOL
	// SetupGetInfFileListA( PCSTR DirectoryPath, DWORD InfStyle, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfFileListA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetInfFileList([Optional, MarshalAs(UnmanagedType.LPTStr)] string? DirectoryPath, INF_STYLE InfStyle,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetUpGetInfInformation</c> function returns the SP_INF_INFORMATION structure for the specified INF file to a buffer.</para>
	/// </summary>
	/// <param name="InfSpec">Handle or a file name for an INF file, depending on the value of SearchControl.</param>
	/// <param name="SearchControl">
	/// <para>This parameter can be one of the following constants.</para>
	/// <para>INFINFO_INF_SPEC_IS_HINF</para>
	/// <para>
	/// InfSpec is an INF handle. A single INF handle may reference multiple INF files if they have been append-loaded together. If it
	/// does, the structure returned by this function contains multiple sets of information.
	/// </para>
	/// <para>INFINFO_INF_NAME_IS_ABSOLUTE</para>
	/// <para>The string specified for InfSpec is a full path. No further processing is performed on InfSpec.</para>
	/// <para>INFINFO_DEFAULT_SEARCH</para>
	/// <para>
	/// Search the default locations for the INF file specified for InfSpec, which is assumed to be a filename only. The default
	/// locations are %windir%\inf, followed by %windir%\system32.
	/// </para>
	/// <para>INFINFO_REVERSE_DEFAULT_SEARCH</para>
	/// <para>Same as INFINFO_DEFAULT_SEARCH, except the default locations are searched in reverse order.</para>
	/// <para>INFINFO_INF_PATH_LIST_SEARCH</para>
	/// <para>Search for the INF in each of the directories listed in the DevicePath value entry under the following: <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion</c></para>
	/// </param>
	/// <param name="ReturnBuffer">
	/// <para>If not <c>NULL</c>, points to a buffer in which this function returns the <see cref="SP_INF_INFORMATION"/> structure.</para>
	/// <para>
	/// You can call the function one time to get the required buffer size, allocate the necessary memory, and then call the function a
	/// second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size. For more
	/// information, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ReturnBufferSize">Size of ReturnBuffer, in bytes.</param>
	/// <param name="RequiredSize">
	/// <para>
	/// If not <c>NULL</c>, points to a variable in which this function returns the required size, in bytes, for the buffer pointed to
	/// by ReturnBuffer.
	/// </para>
	/// <para>
	/// If ReturnBuffer is specified and the size needed is larger than ReturnBufferSize, the function fails and a call to GetLastError
	/// returns ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// <para>If the INF file cannot be located, the function returns <c>FALSE</c> and a subsequent call to GetLastError returns ERROR_FILE_NOT_FOUND.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of 0 (zero), the function puts the buffer
	/// size needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds, the return value
	/// is a nonzero value. Otherwise, the return value is 0 (zero), and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetInfInformation as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetinfinformationa WINSETUPAPI BOOL
	// SetupGetInfInformationA( LPCVOID InfSpec, DWORD SearchControl, PSP_INF_INFORMATION ReturnBuffer, DWORD ReturnBufferSize, PDWORD
	// RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetInfInformation(HFILE InfSpec, INFINFO SearchControl, [Out, Optional] IntPtr ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetUpGetInfInformation</c> function returns the SP_INF_INFORMATION structure for the specified INF file to a buffer.</para>
	/// </summary>
	/// <param name="InfSpec">Handle or a file name for an INF file, depending on the value of SearchControl.</param>
	/// <param name="SearchControl">
	/// <para>This parameter can be one of the following constants.</para>
	/// <para>INFINFO_INF_SPEC_IS_HINF</para>
	/// <para>
	/// InfSpec is an INF handle. A single INF handle may reference multiple INF files if they have been append-loaded together. If it
	/// does, the structure returned by this function contains multiple sets of information.
	/// </para>
	/// <para>INFINFO_INF_NAME_IS_ABSOLUTE</para>
	/// <para>The string specified for InfSpec is a full path. No further processing is performed on InfSpec.</para>
	/// <para>INFINFO_DEFAULT_SEARCH</para>
	/// <para>
	/// Search the default locations for the INF file specified for InfSpec, which is assumed to be a filename only. The default
	/// locations are %windir%\inf, followed by %windir%\system32.
	/// </para>
	/// <para>INFINFO_REVERSE_DEFAULT_SEARCH</para>
	/// <para>Same as INFINFO_DEFAULT_SEARCH, except the default locations are searched in reverse order.</para>
	/// <para>INFINFO_INF_PATH_LIST_SEARCH</para>
	/// <para>Search for the INF in each of the directories listed in the DevicePath value entry under the following: <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion</c></para>
	/// </param>
	/// <param name="ReturnBuffer">
	/// <para>If not <c>NULL</c>, points to a buffer in which this function returns the <see cref="SP_INF_INFORMATION"/> structure.</para>
	/// <para>
	/// You can call the function one time to get the required buffer size, allocate the necessary memory, and then call the function a
	/// second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size. For more
	/// information, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ReturnBufferSize">Size of ReturnBuffer, in bytes.</param>
	/// <param name="RequiredSize">
	/// <para>
	/// If not <c>NULL</c>, points to a variable in which this function returns the required size, in bytes, for the buffer pointed to
	/// by ReturnBuffer.
	/// </para>
	/// <para>
	/// If ReturnBuffer is specified and the size needed is larger than ReturnBufferSize, the function fails and a call to GetLastError
	/// returns ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// <para>If the INF file cannot be located, the function returns <c>FALSE</c> and a subsequent call to GetLastError returns ERROR_FILE_NOT_FOUND.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of 0 (zero), the function puts the buffer
	/// size needed to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds, the return value
	/// is a nonzero value. Otherwise, the return value is 0 (zero), and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetInfInformation as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetinfinformationa WINSETUPAPI BOOL
	// SetupGetInfInformationA( LPCVOID InfSpec, DWORD SearchControl, PSP_INF_INFORMATION ReturnBuffer, DWORD ReturnBufferSize, PDWORD
	// RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetInfInformation([MarshalAs(UnmanagedType.LPTStr)] string InfSpec, INFINFO SearchControl, [Out, Optional] IntPtr ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupGetInfPublishedName</c> function retrieves the fully qualified file name (directory path and file name) of an INF
	/// file in the system INF file directory that corresponds to a specified INF file in the driver store or a specified INF file in
	/// the system INF file directory.
	/// </summary>
	/// <param name="DriverStoreLocation">
	/// A pointer to a NULL-terminated string that contains the fully qualified file name (directory path and file name) of an INF file
	/// in the driver store. Alternatively, this parameter is a pointer to a NULL-terminated string that contains the name, and
	/// optionally the full directory path, of an INF file in the system INF file directory. For more information about how to specify
	/// the INF file, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="ReturnBuffer">
	/// A pointer to the buffer in which <c>SetupGetInfPublishedName</c> returns a NULL-terminated string that contains the fully
	/// qualified file name of the specified INF file in the system INF directory. The maximum path size is MAX_PATH. This pointer can
	/// be set to <c>NULL</c>. For information about how to determine the required size of the return buffer, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="ReturnBufferSize">The size, in characters, of the buffer supplied by ReturnBuffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the size, in characters, of the ReturnBuffer buffer. This parameter is
	/// optional and can be set to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If <c>SetupGetInfPublishedName</c> succeeds, the function returns <c>TRUE</c>; otherwise, the function returns <c>FALSE</c>. To
	/// obtain extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// If the size, in characters, of the fully qualified file name of the requested INF file, including a null-terminator, is greater
	/// than ReturnBufferSize, the function will fail, and a call to GetLastError will return ERROR_INSUFFICIENT_BUFFER.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine the size of the return buffer that is required to contain the fully qualified file name of the specified INF file
	/// in the system INF directory, call <c>SetupGetInfPublishedName</c> and set ReturnBuffer to <c>NULL</c>, ReturnBufferSize to zero,
	/// and supply RequiredSize. <c>SetupGetInfPublishedName</c> will return the required buffer size in RequiredSize.
	/// </para>
	/// <para>
	/// When device installation preinstalls a driver package in the driver store, it creates two copies of the driver package INF file.
	/// Device installation adds one copy to the system INF directory and assigns that copy of the INF file a unique published file name
	/// of the form OEMnnn.inf. Device installation adds a second copy of the INF file to the driver store and assigns that copy the
	/// original INF file name.
	/// </para>
	/// <para>
	/// <c>SetupGetInfPublishedName</c> returns the fully qualified file name of the INF file in the system INF file directory that
	/// matches the INF file, if any, that is supplied by DriverStoreLocation. DriverStoreLocation must specify the fully qualified file
	/// name of an INF file in the driver store or must specify the file name, and optionally the directory path, of an INF file in the
	/// system INF directory. For example, assume that the INF file for a driver package is myinf.inf, and that for this driver package,
	/// device installation installs the INF file OEM1.inf in the system INF directory C:\Windows\inf. Further assume that device
	/// installation installs the corresponding INF file copy C:\windows\system32\driverstore\filerepository\myinf_12345678\myinf.inf in
	/// the driver store. In this case, the function returns C:\Windows\inf\OEM1.inf if DriverStoreLocation supplies one of the
	/// following strings: C:\windows\system32\driverstore\filerepository\myinf_12345678\myinf.inf, OEM1.inf, or C:\Windows\inf\OEM1.inf.
	/// </para>
	/// <para>
	/// Call the SetupGetInfDriverStoreLocation function to retrieve the fully qualified file name of an INF file in the driver store
	/// that corresponds to a specified INF file in the system INF file directory or a specified file in the driver store.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetInfPublishedName as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetinfpublishednamea WINSETUPAPI BOOL
	// SetupGetInfPublishedNameA( PCSTR DriverStoreLocation, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetInfPublishedNameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetInfPublishedName([MarshalAs(UnmanagedType.LPTStr)] string DriverStoreLocation,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetIntField</c> function retrieves an integer value from the specified field of a line in an INF file.</para>
	/// </summary>
	/// <param name="Context">Pointer to the context for a line in an INF file.</param>
	/// <param name="FieldIndex">
	/// <para>The 1-based index of the field within the specified line from which the integer should be retrieved.</para>
	/// <para>
	/// A FieldIndex of 0 can be used to retrieve an integer key (For example, consider the following INF line, 431 = 1, 2, 4. The value
	/// 431 would be put into the variable pointed at by IntegerValue if <c>SetupGetIntField</c> was called with a FieldIndex of 0).
	/// </para>
	/// </param>
	/// <param name="IntegerValue">
	/// Pointer to a variable that receives the integer. If the field is not an integer, the function fails and a call to GetLastError
	/// returns ERROR_INVALID_DATA.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The integer field may start with a positive (+) or negative (-) sign. It will be interpreted as a decimal number, unless
	/// prefixed in the file with 0x or 0X, in which case it is hexadecimal.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetintfield WINSETUPAPI BOOL SetupGetIntField(
	// PINFCONTEXT Context, DWORD FieldIndex, PINT IntegerValue );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetIntField")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetIntField(in INFCONTEXT Context, uint FieldIndex, out int IntegerValue);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetLineByIndex</c> function locates a line by its index value in the specified section in the INF file.</para>
	/// </summary>
	/// <param name="InfHandle">Handle to the INF file.</param>
	/// <param name="Section">Pointer to a null-terminated string specifying the section of the INF file to search.</param>
	/// <param name="Index">
	/// Index of the line to be located. The total number of lines in a particular section can be found with a call to SetupGetLineCount.
	/// </param>
	/// <param name="Context">Pointer to a variable that receives the context information for the found line.</param>
	/// <returns>
	/// If the function succeeds, the return value is a nonzero value. If the function fails, the return value is zero. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If InfHandle references multiple INF files that have been appended together using SetupOpenAppendInfFile, this function searches
	/// across the specified section in all files referenced by the HINF to locate the indexed line.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetLineByIndex as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetlinebyindexa WINSETUPAPI BOOL
	// SetupGetLineByIndexA( HINF InfHandle, PCSTR Section, DWORD Index, PINFCONTEXT Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetLineByIndexA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetLineByIndex(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string Section, uint Index, out INFCONTEXT Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetLineCount</c> function returns the number of lines in a specified section of an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">Handle to the INF file.</param>
	/// <param name="Section">Pointer to a null-terminated string that specifies the section in which you want to count the lines.</param>
	/// <returns>
	/// <para>
	/// If InfHandle references multiple INF files that have been appended using SetupOpenAppendInfFile, this function returns the sum
	/// of the lines in all of the INF files containing the specified section. A return value of 0 specifies an empty section. If the
	/// section does not exist, the function returns –1.
	/// </para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetLineCount as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetlinecounta WINSETUPAPI LONG SetupGetLineCountA(
	// HINF InfHandle, PCSTR Section );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetLineCountA")]
	public static extern int SetupGetLineCount(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string Section);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetLineText</c> function returns the contents of a line in an INF file in a compact form. The line to retrieve can
	/// be specified by an INFCONTEXT structure returned from a SetupFindLineXXX function, or by explicitly passing in the INF handle,
	/// section, and key of the desired line.
	/// </para>
	/// </summary>
	/// <param name="Context">
	/// Context for a line in an INF file whose text is to be retrieved. This parameter can be <c>NULL</c>. If Context is <c>NULL</c>,
	/// InfHandle, Section, and Key must all be specified.
	/// </param>
	/// <param name="InfHandle">
	/// Handle to the INF file to query. This parameter can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If
	/// Context is <c>NULL</c>, InfHandle, Section, and Key must all be specified.
	/// </param>
	/// <param name="Section">
	/// Pointer to a <c>null</c>-terminated string that specifies the section that contains the key name of the line whose text is to be
	/// retrieved. This parameter can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If Context is <c>NULL</c>,
	/// InfHandle, Section, and Key must be specified.
	/// </param>
	/// <param name="Key">
	/// Pointer to a <c>null</c>-terminated string that contains the key name whose associated string is to be retrieved. This parameter
	/// can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If Context is <c>NULL</c>, InfHandle, Section, and
	/// Key must be specified.
	/// </param>
	/// <param name="ReturnBuffer">
	/// If not <c>NULL</c>, ReturnBuffer points to a buffer in which this function returns the contents of the line. The
	/// <c>null</c>-terminated string must not exceed the size of the destination buffer. You can call the function once to get the
	/// required buffer size, allocate the necessary memory, and then call the function a second time to retrieve the data. Using this
	/// technique, you can avoid errors due to an insufficient buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by the ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// If not <c>NULL</c>, points to a variable in which this function returns the required size for the buffer pointed to by the
	/// ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator. If ReturnBuffer is specified and the size
	/// required is larger than the value specified in the ReturnBufferSize parameter, the function fails and does not store data in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// required to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// This function returns the contents of a line in a compact format. All extraneous white space is removed and multi-line values
	/// are converted into a single contiguous string. For example, this line:
	/// </para>
	/// <para>
	/// <code>HKLM, , PointerClass0, 1 \ ; This is a comment 01, 02, 03</code>
	/// </para>
	/// <para>would be returned as:</para>
	/// <para>
	/// <code>HKLM,,PointerClass0,1,01,02,03</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetLineText as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetlinetexta WINSETUPAPI BOOL SetupGetLineTextA(
	// PINFCONTEXT Context, HINF InfHandle, PCSTR Section, PCSTR Key, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetLineTextA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetLineText(in INFCONTEXT Context, [In, Optional] HINF InfHandle, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? Section,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? Key, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetLineText</c> function returns the contents of a line in an INF file in a compact form. The line to retrieve can
	/// be specified by an INFCONTEXT structure returned from a SetupFindLineXXX function, or by explicitly passing in the INF handle,
	/// section, and key of the desired line.
	/// </para>
	/// </summary>
	/// <param name="Context">
	/// Context for a line in an INF file whose text is to be retrieved. This parameter can be <c>NULL</c>. If Context is <c>NULL</c>,
	/// InfHandle, Section, and Key must all be specified.
	/// </param>
	/// <param name="InfHandle">
	/// Handle to the INF file to query. This parameter can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If
	/// Context is <c>NULL</c>, InfHandle, Section, and Key must all be specified.
	/// </param>
	/// <param name="Section">
	/// Pointer to a <c>null</c>-terminated string that specifies the section that contains the key name of the line whose text is to be
	/// retrieved. This parameter can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If Context is <c>NULL</c>,
	/// InfHandle, Section, and Key must be specified.
	/// </param>
	/// <param name="Key">
	/// Pointer to a <c>null</c>-terminated string that contains the key name whose associated string is to be retrieved. This parameter
	/// can be <c>NULL</c>. This parameter is used only if Context is <c>NULL</c>. If Context is <c>NULL</c>, InfHandle, Section, and
	/// Key must be specified.
	/// </param>
	/// <param name="ReturnBuffer">
	/// If not <c>NULL</c>, ReturnBuffer points to a buffer in which this function returns the contents of the line. The
	/// <c>null</c>-terminated string must not exceed the size of the destination buffer. You can call the function once to get the
	/// required buffer size, allocate the necessary memory, and then call the function a second time to retrieve the data. Using this
	/// technique, you can avoid errors due to an insufficient buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by the ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// If not <c>NULL</c>, points to a variable in which this function returns the required size for the buffer pointed to by the
	/// ReturnBuffer parameter, in characters. This includes the <c>null</c> terminator. If ReturnBuffer is specified and the size
	/// required is larger than the value specified in the ReturnBufferSize parameter, the function fails and does not store data in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called with a ReturnBuffer of <c>NULL</c> and a ReturnBufferSize of zero, the function puts the buffer size
	/// required to hold the specified data into the variable pointed to by RequiredSize. If the function succeeds in this, the return
	/// value is a nonzero value. Otherwise, the return value is zero and extended error information can be obtained by calling GetLastError.
	/// </para>
	/// <para>
	/// This function returns the contents of a line in a compact format. All extraneous white space is removed and multi-line values
	/// are converted into a single contiguous string. For example, this line:
	/// </para>
	/// <para>
	/// <code>HKLM, , PointerClass0, 1 \ ; This is a comment 01, 02, 03</code>
	/// </para>
	/// <para>would be returned as:</para>
	/// <para>
	/// <code>HKLM,,PointerClass0,1,01,02,03</code>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetLineText as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetlinetexta WINSETUPAPI BOOL SetupGetLineTextA(
	// PINFCONTEXT Context, HINF InfHandle, PCSTR Section, PCSTR Key, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetLineTextA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetLineText([In, Optional] IntPtr Context, [In] HINF InfHandle, [In, MarshalAs(UnmanagedType.LPTStr)] string Section,
		[In, MarshalAs(UnmanagedType.LPTStr)] string Key, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetMultiSzField</c> function retrieves multiple strings stored in a line of an INF file, from the specified field to
	/// the end of the line.
	/// </para>
	/// </summary>
	/// <param name="Context">Pointer to the context for a line in an INF file.</param>
	/// <param name="FieldIndex">
	/// The 1-based index of the starting field within the specified line from which the strings should be retrieved. The string list is
	/// built from each field starting at this point to the end of the line. A FieldIndex of zero is not valid with this function.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a character buffer that receives the strings. Each string is <c>null</c>-terminated, with an extra
	/// <c>null</c> at the end of the string list. The <c>null</c>-terminated string should not exceed the size of the destination
	/// buffer. You can call the function once to get the required buffer size, allocate the necessary memory, and then call the
	/// function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size. See
	/// the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the size required for the buffer pointed to by ReturnBuffer, in characters. This
	/// includes the <c>null</c> terminator. If the size needed is larger than the value specified by ReturnBufferSize, the function
	/// fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
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
	/// <c>SetupGetMultiSzField</c> should not be used to iterate through string values on an INF line. Instead you should use
	/// SetupGetStringField. <c>SetupGetMultiSzField</c> returns a value in the format of REG_MULTI_SZ. This is an array of
	/// <c>null</c>-terminated strings terminated by an extra <c>null</c> character. This format does not allow zero-length strings. If
	/// the list of strings contains any zero-length strings, <c>SetupGetMultiSzField</c> will return prematurely when it encounters the
	/// first blank string value.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetMultiSzField as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetmultiszfielda WINSETUPAPI BOOL
	// SetupGetMultiSzFieldA( PINFCONTEXT Context, DWORD FieldIndex, PSTR ReturnBuffer, DWORD ReturnBufferSize, LPDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetMultiSzFieldA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetMultiSzField(in INFCONTEXT Context, uint FieldIndex, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupGetNonInteractiveMode</c> function returns the value of a SetupAPI non-interactive flag that indicates whether the
	/// caller's process can interact with a user through user interface components, such as dialog boxes.
	/// </summary>
	/// <returns>
	/// <c>SetupGetNonInteractiveMode</c> returns <c>TRUE</c> if the caller's process cannot display interactive user interface
	/// elements, such as dialog boxes. Otherwise, the function returns <c>FALSE</c>, which indicates that the process can display
	/// interactive user interface elements.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Installation applications and co-installers can use this function to determine whether the current process can display
	/// interactive user interface elements such as dialog boxes. SetupAPI runs a class installer or a co-installer either in an
	/// interactive or in a non-interactive process, depending on which DIF code SetupAPI is processing.
	/// </para>
	/// <para>
	/// An installation application can call SetupSetNonInteractiveMode to set the SetupAPI non-interactive flag that controls whether
	/// SetupAPI can display interactive user interface elements in the caller's context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetnoninteractivemode WINSETUPAPI BOOL SetupGetNonInteractiveMode();
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetNonInteractiveMode")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetNonInteractiveMode();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetSourceFileLocation</c> function retrieves the location of a source file listed in an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Handle to the INF file that contains the <c>SourceDisksNames</c> and <c>SourceDisksFiles</c> sections. If platform-specific
	/// sections exist for the user's system (for example, <c>SourceDisksNames.x86</c> and <c>SourceDisksFiles.x86</c>), the
	/// platform-specific section will be used.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to the context of a line in a <c>Copy Files</c> section for which the full source path is to be retrieved. If
	/// this parameter is <c>NULL</c>, FileName is searched for in the <c>SourceDisksFiles</c> section of the INF file specified by InfHandle.
	/// </param>
	/// <param name="FileName">
	/// Optional pointer to a <c>null</c>-terminated string containing the filename (no path) for which to return the full source
	/// location. This parameter can be <c>NULL</c>, but either FileName or InfContext must be specified.
	/// </param>
	/// <param name="SourceId">
	/// Pointer to a variable that receives the source identifier of the media where the file is located from the
	/// <c>SourceDisksNames</c> section of the INF file.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer to receive the relative source path. The source path does not include the filename itself, nor does
	/// it include a drive letter/network share name. The path does not start or end with a backslash (), so the empty string specifies
	/// the root directory. You should use a <c>null</c>-terminated string buffer. The <c>null</c>-terminated string should not exceed
	/// the size of the destination buffer. You can call the function once to get the required buffer size, allocate the necessary
	/// memory, and then call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an
	/// insufficient buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This number includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to by the ReturnBuffer parameter, in
	/// characters. This number includes the <c>null</c> terminator. If the required size is larger than the value specified by
	/// ReturnBufferSize, the function fails and GetLastError returns ERROR_INSUFFICIENT_BUFFER.
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
	/// The setupapi.h header defines SetupGetSourceFileLocation as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetsourcefilelocationa WINSETUPAPI BOOL
	// SetupGetSourceFileLocationA( HINF InfHandle, PINFCONTEXT InfContext, PCSTR FileName, PUINT SourceId, PSTR ReturnBuffer, DWORD
	// ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceFileLocationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetSourceFileLocation(HINF InfHandle, in INFCONTEXT InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? FileName,
		out uint SourceId, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetSourceFileLocation</c> function retrieves the location of a source file listed in an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Handle to the INF file that contains the <c>SourceDisksNames</c> and <c>SourceDisksFiles</c> sections. If platform-specific
	/// sections exist for the user's system (for example, <c>SourceDisksNames.x86</c> and <c>SourceDisksFiles.x86</c>), the
	/// platform-specific section will be used.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to the context of a line in a <c>Copy Files</c> section for which the full source path is to be retrieved. If
	/// this parameter is <c>NULL</c>, FileName is searched for in the <c>SourceDisksFiles</c> section of the INF file specified by InfHandle.
	/// </param>
	/// <param name="FileName">
	/// Optional pointer to a <c>null</c>-terminated string containing the filename (no path) for which to return the full source
	/// location. This parameter can be <c>NULL</c>, but either FileName or InfContext must be specified.
	/// </param>
	/// <param name="SourceId">
	/// Pointer to a variable that receives the source identifier of the media where the file is located from the
	/// <c>SourceDisksNames</c> section of the INF file.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer to receive the relative source path. The source path does not include the filename itself, nor does
	/// it include a drive letter/network share name. The path does not start or end with a backslash (), so the empty string specifies
	/// the root directory. You should use a <c>null</c>-terminated string buffer. The <c>null</c>-terminated string should not exceed
	/// the size of the destination buffer. You can call the function once to get the required buffer size, allocate the necessary
	/// memory, and then call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an
	/// insufficient buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This number includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to by the ReturnBuffer parameter, in
	/// characters. This number includes the <c>null</c> terminator. If the required size is larger than the value specified by
	/// ReturnBufferSize, the function fails and GetLastError returns ERROR_INSUFFICIENT_BUFFER.
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
	/// The setupapi.h header defines SetupGetSourceFileLocation as an alias which automatically selects the ANSI or Unicode version of
	/// this function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code
	/// that not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see
	/// Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetsourcefilelocationa WINSETUPAPI BOOL
	// SetupGetSourceFileLocationA( HINF InfHandle, PINFCONTEXT InfContext, PCSTR FileName, PUINT SourceId, PSTR ReturnBuffer, DWORD
	// ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceFileLocationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetSourceFileLocation(HINF InfHandle, [In, Optional] IntPtr InfContext, [MarshalAs(UnmanagedType.LPTStr)] string FileName,
		out uint SourceId, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetSourceFileSize</c> function reads the uncompressed size of a source file listed in an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Handle to the loaded INF file that contains the <c>SourceDisksNames</c> and <c>SourceDisksFiles</c> sections. If
	/// platform-specific sections exist for the user's system (for example, <c>SourceDisksNames.x86</c> and
	/// <c>SourceDisksFiles.x86</c>), the platform-specific section will be used.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to a context for a line in a <c>Copy Files</c> section for which the size is to be retrieved. If InfContext is
	/// <c>NULL</c>, the FileName parameter is used.
	/// </param>
	/// <param name="FileName">
	/// Optional pointer to a <c>null</c>-terminated string containing the filename (no path) for which to return the size. If this
	/// parameter is <c>NULL</c> as well as InfContext, then the Section parameter is used.
	/// </param>
	/// <param name="Section">
	/// Optional pointer to a <c>null</c>-terminated string containing the name of a <c>Copy Files</c> section. If this parameter is
	/// specified, the total size of all files listed in the section is computed.
	/// </param>
	/// <param name="FileSize">Pointer to a variable that receives the size, in bytes, of the specified file(s).</param>
	/// <param name="RoundingFactor">
	/// Optional value for rounding file sizes. All file sizes are rounded up to a multiple of this number before being added to the
	/// total size. Rounding is useful for more exact determinations of the space that a file will occupy on a given volume, because it
	/// allows the caller to have file sizes rounded up to a multiple of the cluster size. Rounding does not occur unless RoundingFactor
	/// is specified.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>One and only one of the optional parameters, InfContext, FileName, and Section, must be specified.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetSourceFileSize as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetsourcefilesizea WINSETUPAPI BOOL
	// SetupGetSourceFileSizeA( HINF InfHandle, PINFCONTEXT InfContext, PCSTR FileName, PCSTR Section, PDWORD FileSize, UINT
	// RoundingFactor );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceFileSizeA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetSourceFileSize(HINF InfHandle, in INFCONTEXT InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? FileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Section, out uint FileSize, uint RoundingFactor = 0);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetSourceFileSize</c> function reads the uncompressed size of a source file listed in an INF file.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Handle to the loaded INF file that contains the <c>SourceDisksNames</c> and <c>SourceDisksFiles</c> sections. If
	/// platform-specific sections exist for the user's system (for example, <c>SourceDisksNames.x86</c> and
	/// <c>SourceDisksFiles.x86</c>), the platform-specific section will be used.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to a context for a line in a <c>Copy Files</c> section for which the size is to be retrieved. If InfContext is
	/// <c>NULL</c>, the FileName parameter is used.
	/// </param>
	/// <param name="FileName">
	/// Optional pointer to a <c>null</c>-terminated string containing the filename (no path) for which to return the size. If this
	/// parameter is <c>NULL</c> as well as InfContext, then the Section parameter is used.
	/// </param>
	/// <param name="Section">
	/// Optional pointer to a <c>null</c>-terminated string containing the name of a <c>Copy Files</c> section. If this parameter is
	/// specified, the total size of all files listed in the section is computed.
	/// </param>
	/// <param name="FileSize">Pointer to a variable that receives the size, in bytes, of the specified file(s).</param>
	/// <param name="RoundingFactor">
	/// Optional value for rounding file sizes. All file sizes are rounded up to a multiple of this number before being added to the
	/// total size. Rounding is useful for more exact determinations of the space that a file will occupy on a given volume, because it
	/// allows the caller to have file sizes rounded up to a multiple of the cluster size. Rounding does not occur unless RoundingFactor
	/// is specified.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>One and only one of the optional parameters, InfContext, FileName, and Section, must be specified.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetSourceFileSize as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetsourcefilesizea WINSETUPAPI BOOL
	// SetupGetSourceFileSizeA( HINF InfHandle, PINFCONTEXT InfContext, PCSTR FileName, PCSTR Section, PDWORD FileSize, UINT
	// RoundingFactor );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceFileSizeA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetSourceFileSize(HINF InfHandle, [In, Optional] IntPtr InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? FileName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Section, out uint FileSize, uint RoundingFactor = 0);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetSourceInfo</c> function retrieves the path, tag file, or media description for a source listed in an INF file.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">
	/// Handle to an open INF file that contains a <c>SourceDisksNames</c> section. If platform-specific sections exist for the user's
	/// system (for example, <c>SourceDisksNames.x86</c>), the platform-specific section will be used.
	/// </param>
	/// <param name="SourceId">Identifier for a source media. This value is used to search by key in the <c>SourceDisksNames</c> section.</param>
	/// <param name="InfoDesired">
	/// <para>
	/// Indicates what information is desired. Only one value may be specified per function call, and they cannot be combined. The
	/// following types of information can be retrieved from a <c>SourceDisksNames</c> section.
	/// </para>
	/// <para>SRCINFO_PATH</para>
	/// <para>The path specified for the source. This is not a full path, but the path relative to the installation root.</para>
	/// <para>SRCINFO_TAGFILE</para>
	/// <para>The tag file that identifies the source media, or if cabinets are used, the name of the cabinet file.</para>
	/// <para>SRCINFO_DESCRIPTION</para>
	/// <para>A description for the media.</para>
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer to receive the retrieved information. Path returns are guaranteed not to end with . You should use
	/// a <c>null</c>-terminated string. The <c>null</c>-terminated string should not exceed the size of the destination buffer. You can
	/// call the function once to get the required buffer size, allocate the necessary memory, and then call the function a second time
	/// to retrieve the data. See the Remarks section. Using this technique, you can avoid errors due to an insufficient buffer size.
	/// This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer specified by ReturnBuffer, in characters. This
	/// includes the <c>null</c> terminator. If ReturnBuffer is specified and the actual size needed is larger than the value specified
	/// by ReturnBufferSize, the function fails and a call to GetLastError returns ERROR_INSUFFICIENT_BUFFER.
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
	/// The setupapi.h header defines SetupGetSourceInfo as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetsourceinfoa WINSETUPAPI BOOL SetupGetSourceInfoA(
	// HINF InfHandle, UINT SourceId, UINT InfoDesired, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetSourceInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetSourceInfo(HINF InfHandle, uint SourceId, SRCINFO InfoDesired,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>The <c>SetupGetStringField</c> function retrieves a string from the specified field of a line in an INF file.</para>
	/// </summary>
	/// <param name="Context">Pointer to the context for a line in an INF file.</param>
	/// <param name="FieldIndex">
	/// The 1-based index of the field within the specified line from which the string should be retrieved. Use a FieldIndex of 0 to
	/// retrieve a string key, if present.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to a buffer that receives the <c>null</c>-terminated string. You should ensure the destination buffer is the
	/// same size or larger than the source buffer. This parameter can be <c>NULL</c>. See the Remarks section.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to by the ReturnBuffer parameter, in
	/// characters. If ReturnBuffer is specified and the actual size needed is larger than the value specified by ReturnBufferSize, the
	/// function fails and does not store the string in the buffer. In this case, a call to GetLastError returns
	/// ERROR_INSUFFICIENT_BUFFER. For the Unicode version of this function, the required size is in characters. This includes the
	/// <c>null</c> terminator.
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
	/// You can call the function once to get the required buffer size, allocate the necessary memory, and then call the function a
	/// second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient buffer size.
	/// </para>
	/// <para>
	/// Note that the maximum length of any single string specified in an INF Strings section is 512 characters, including the
	/// terminating <c>NULL</c>. If the string length is greater than 512 it will be truncated and no error will be returned. The
	/// maximum length of any concatenated string created from one or more %strkey% tokens is 4096 characters.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupGetStringField as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetstringfielda WINSETUPAPI BOOL
	// SetupGetStringFieldA( PINFCONTEXT Context, DWORD FieldIndex, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetStringFieldA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetStringField(in INFCONTEXT Context, uint FieldIndex, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer,
		uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetTargetPath</c> function determines the target directory for a file list section. The file list section can be a
	/// <c>Copy Files</c> section, a <c>Delete Files</c> section, or a <c>Rename Files</c> section. All the files in the section must be
	/// in a single directory that is listed in a <c>DestinationDirs</c> section of the INF file.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">Handle to the load INF file that contains a <c>DestinationDirs</c> section.</param>
	/// <param name="InfContext">
	/// Optional pointer to an INF context that specifies a line in a file list section whose destination directory is to be retrieved.
	/// If InfContext is <c>NULL</c>, then the Section parameter is used.
	/// </param>
	/// <param name="Section">
	/// Optional parameter that specifies the name of a section of the INF file whose handle is InfHandle. <c>SetupGetTargetPath</c>
	/// retrieves the target directory for this section. The Section parameter is ignored if InfContext is specified. If neither
	/// InfContext nor Section is specified, the function retrieves the default target path from the INF file. You should use a
	/// <c>null</c>-terminated string.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to buffer to receive the fully qualified target path. The path is guaranteed not to end with . You should use a
	/// <c>null</c>-terminated string. You can call the function once to get the required buffer size, allocate the necessary memory,
	/// and then call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient
	/// buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to by ReturnBuffer, in characters. This
	/// includes the <c>null</c> terminator. If the actual size needed is larger than the value specified by ReturnBufferSize, the
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
	/// The setupapi.h header defines SetupGetTargetPath as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgettargetpatha WINSETUPAPI BOOL SetupGetTargetPathA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR Section, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetTargetPathA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetTargetPath(HINF InfHandle, in INFCONTEXT InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Section,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder? ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupGetTargetPath</c> function determines the target directory for a file list section. The file list section can be a
	/// <c>Copy Files</c> section, a <c>Delete Files</c> section, or a <c>Rename Files</c> section. All the files in the section must be
	/// in a single directory that is listed in a <c>DestinationDirs</c> section of the INF file.
	/// </para>
	/// </summary>
	/// <param name="InfHandle">Handle to the load INF file that contains a <c>DestinationDirs</c> section.</param>
	/// <param name="InfContext">
	/// Optional pointer to an INF context that specifies a line in a file list section whose destination directory is to be retrieved.
	/// If InfContext is <c>NULL</c>, then the Section parameter is used.
	/// </param>
	/// <param name="Section">
	/// Optional parameter that specifies the name of a section of the INF file whose handle is InfHandle. <c>SetupGetTargetPath</c>
	/// retrieves the target directory for this section. The Section parameter is ignored if InfContext is specified. If neither
	/// InfContext nor Section is specified, the function retrieves the default target path from the INF file. You should use a
	/// <c>null</c>-terminated string.
	/// </param>
	/// <param name="ReturnBuffer">
	/// Optional pointer to buffer to receive the fully qualified target path. The path is guaranteed not to end with . You should use a
	/// <c>null</c>-terminated string. You can call the function once to get the required buffer size, allocate the necessary memory,
	/// and then call the function a second time to retrieve the data. Using this technique, you can avoid errors due to an insufficient
	/// buffer size. See the Remarks section. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ReturnBufferSize">
	/// Size of the buffer pointed to by ReturnBuffer, in characters. This includes the <c>null</c> terminator.
	/// </param>
	/// <param name="RequiredSize">
	/// Optional pointer to a variable that receives the required size for the buffer pointed to by ReturnBuffer, in characters. This
	/// includes the <c>null</c> terminator. If the actual size needed is larger than the value specified by ReturnBufferSize, the
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
	/// The setupapi.h header defines SetupGetTargetPath as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgettargetpatha WINSETUPAPI BOOL SetupGetTargetPathA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR Section, PSTR ReturnBuffer, DWORD ReturnBufferSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetTargetPathA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupGetTargetPath(HINF InfHandle, [In, Optional] IntPtr InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Section,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder ReturnBuffer, uint ReturnBufferSize, out uint RequiredSize);

	/// <summary>The <c>SetupGetThreadLogToken</c> function retrieves the log token for the thread from which this function was called.</summary>
	/// <returns>
	/// <c>SetupGetThreadLogToken</c> returns the log token for the thread from which the function was called. If a log token is not set
	/// for the thread, <c>SetupGetThreadLogToken</c> returns the system-defined log token LOGTOKEN_UNSPECIFIED.
	/// </returns>
	/// <remarks>
	/// <para>To set a log token for a thread, call SetupSetThreadLogToken.</para>
	/// <para>For more information about log tokens, see Log Tokens.</para>
	/// <para>For more information about using log tokens, see Setting and Getting a Log Token for a Thread.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupgetthreadlogtoken WINSETUPAPI SP_LOG_TOKEN SetupGetThreadLogToken();
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupGetThreadLogToken")]
	public static extern ulong SetupGetThreadLogToken();

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInitDefaultQueueCallback</c> function initializes the context used by the default queue callback routine included
	/// with the Setup API.
	/// </para>
	/// </summary>
	/// <param name="OwnerWindow">Handle to the window to use as the parent of any dialog boxes generated by the default callback routine.</param>
	/// <returns>
	/// <para>Pointer to the context used by the default queue callback routine.</para>
	/// <para>If the call to <c>SetupInitDefaultQueueCallback</c> fails, the function returns a PVOID value of null.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// Regardless of whether you initialized the context used by the default queue callback routine with
	/// <c>SetupInitDefaultQueueCallback</c> or SetupInitDefaultQueueCallbackEx, after the queued operations have finished processing,
	/// call SetupTermDefaultQueueCallback to release the resources allocated in initializing the context structure. For more
	/// information, see Initializing and Terminating the Callback Context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinitdefaultqueuecallback WINSETUPAPI PVOID
	// SetupInitDefaultQueueCallback( HWND OwnerWindow );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInitDefaultQueueCallback")]
	public static extern IntPtr SetupInitDefaultQueueCallback([In, Optional] HWND OwnerWindow);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInitDefaultQueueCallbackEx</c> function initializes the context used by the default queue callback routine included
	/// with the Setup API in the same manner as SetupInitDefaultQueueCallback, except that an additional window is provided to the
	/// callback function to accept progress messages.
	/// </para>
	/// </summary>
	/// <param name="OwnerWindow">Handle to the window to use as the parent of any dialog boxes generated by the default callback routine.</param>
	/// <param name="AlternateProgressWindow">
	/// Handle to a window that receives the progress messages. To prevent progress messages from being displayed, you can specify this
	/// parameter to be INVALID_HANDLE_VALUE.
	/// </param>
	/// <param name="ProgressMessage">
	/// Message that is sent to AlternateProgressWindow when the copy queue is started, and each time a file is copied.
	/// </param>
	/// <param name="Reserved1">First message parameter that is sent to the AlternateProgressWindow by the default callback routine.</param>
	/// <param name="Reserved2">Second message parameter that is sent to the AlternateProgressWindow by the default callback routine.</param>
	/// <returns>
	/// <c>SetupInitDefaultQueueCallbackEx</c> returns a pointer to the context used by the default queue callback routine. This
	/// function can only fail if there is insufficient memory. If this function fails, it returns <c>NULL</c> and does not set the
	/// last-error code for the thread.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the queue starts to commit the copy subqueue, the default queue callback routine sends a message to the window specified in
	/// AlternateProgressWindow. Reserved1 has the value 0, and Reserved2 contains a pointer to the number of enqueued file copy operations.
	/// </para>
	/// <para>
	/// For each file copy operation completed, the default queue callback routine sends a message to AlternateProgressWindow, which can
	/// be used to 'tick' the progress bar. Reserved1 has the value 1, and Reserved2 is zero.
	/// </para>
	/// <para>
	/// <c>SetupInitDefaultQueueCallbackEx</c> can be used to get the default behavior for disk prompting, error handling, and so on,
	/// and also provide a gauge embedded in a wizard page or other specialized dialog box.
	/// </para>
	/// <para>
	/// Regardless of whether you initialized the context used by the default queue callback routine with SetupInitDefaultQueueCallback
	/// or <c>SetupInitDefaultQueueCallbackEx</c>, after the queued operations have finished processing, call
	/// SetupTermDefaultQueueCallback to release the resources allocated in initializing the context structure. For more information see
	/// Initializing and Terminating the Callback Context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinitdefaultqueuecallbackex WINSETUPAPI PVOID
	// SetupInitDefaultQueueCallbackEx( HWND OwnerWindow, HWND AlternateProgressWindow, UINT ProgressMessage, DWORD Reserved1, PVOID
	// Reserved2 );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInitDefaultQueueCallbackEx")]
	public static extern IntPtr SetupInitDefaultQueueCallbackEx([In, Optional] HWND OwnerWindow, [In, Optional] HWND AlternateProgressWindow, uint ProgressMessage,
		[In, Optional] uint Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInitializeFileLog</c> function initializes a file to record installation operations and outcomes. This can be the
	/// system log, where the system tracks the files installed as part of Windows, or any other file.
	/// </para>
	/// </summary>
	/// <param name="LogFileName">
	/// Optional pointer to the file name of the file to use as the log file. You should use a <c>null</c>-terminated string. The
	/// LogFileName parameter must be specified if Flags does not include SPFILELOG_SYSTEMLOG. The LogFileName parameter must not be
	/// specified if Flags includes SPFILELOG_SYSTEMLOG. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>Controls the log file initialization. This parameter can be a combination of the following values.</para>
	/// <para>SPFILELOG_SYSTEMLOG</para>
	/// <para>
	/// Use the system file log. The user must be an Administrator to specify this option unless SPFILELOG_QUERYONLY is specified and
	/// LogFileName is not specified. Do not specify SPFILELOG_SYSTEMLOG in combination with SPFILELOG_FORCENEW.
	/// </para>
	/// <para>SPFILELOG_FORCENEW</para>
	/// <para>
	/// If the log file exists, overwrite it. If the log file exists and this flag is not specified, any new files that are installed
	/// are added to the list in the existing log file. Do not specify in combination with SPFILELOG_SYSTEMLOG.
	/// </para>
	/// <para>SPFILELOG_QUERYONLY</para>
	/// <para>Open the log file for querying only.</para>
	/// </param>
	/// <returns>
	/// The function returns the handle to the log file if it is successful. Otherwise, the return value is INVALID_HANDLE_VALUE and the
	/// logged error can be retrieved by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInitializeFileLog as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinitializefileloga WINSETUPAPI HSPFILELOG
	// SetupInitializeFileLogA( PCSTR LogFileName, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInitializeFileLogA")]
	public static extern SafeHSPFILELOG SetupInitializeFileLog([Optional, MarshalAs(UnmanagedType.LPTStr)] string? LogFileName, SPFILELOG Flags);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallFile</c> function installs a file as specified either by an INFCONTEXT returned by SetupFindXXXLine or
	/// explicitly by the file name and path.
	/// </para>
	/// <para>If a file is copied, the caller of this function must have write privileges into the target directory.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Optional pointer to the handle to an INF file that contains SourceDisksNames and SourceDisksFiles sections. If platform-specific
	/// sections exist for the user's system (for example, SourceDisksNames.x86 and SourceDisksFiles.x86), the platform-specific section
	/// will be used. If InfContext is null and CopyStyle includes SP_COPY_SOURCE_ABSOLUTE or SP_COPY_SOURCEPATH_ABSOLUTE, InfHandle is ignored.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to the context of a line in a Copy Files section in an INF file. The routine looks up this file in the
	/// SourceDisksFiles section of InfHandle to get file copy information. If InfHandle is not specified, SourceFile must be.
	/// </param>
	/// <param name="SourceFile">
	/// Optional pointer to the file name (no path) of the file to copy. The file is looked up in the SourceDisksFiles section. The
	/// SourceFile parameter must be specified if InfContext is not. SourceFile is ignored if InfContext is specified.
	/// </param>
	/// <param name="SourcePathRoot">
	/// Optional pointer to the root path for the file to be copied (for example, A:\ or F:). Paths in the SourceDisksNames section are
	/// appended to this path. The SourcePathRoot parameter is ignored if CopyStyle includes the SP_COPY_SOURCE_ABSOLUTE flag.
	/// </param>
	/// <param name="DestinationName">
	/// Optional pointer to the file name only (no path) of the target file. This parameter can be null to indicate that the target file
	/// should have the same name as the source file. If InfContext is not specified, DestinationName supplies the full path and file
	/// name for the target.
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation. These flags may be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SP_COPY_DELETESOURCE</term>
	/// <term>Deletes the source file upon successful copy. The caller is not notified if the delete operation fails.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_REPLACEONLY</term>
	/// <term>
	/// Copies the file only if doing so would overwrite a file at the destination path. If the target does not exist, the function
	/// returns FALSE and GetLastError returns NO_ERROR.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NEWER_OR_SAME</term>
	/// <term>
	/// Examines each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target. The file version information used during version checks is that specified in the dwFileVersionMS
	/// and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does not
	/// have version resources, or if they have identical version information, the source file is considered newer. If the source file
	/// is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may cancel the copy operation. If
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
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NODECOMP</term>
	/// <term>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying F:\x86\cmd.ex_ to \\install\temp results in a target file of \\install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \\install\temp\cmd.exe.
	/// The file name part of DestinationName, if specified, is stripped and replaced with the file name of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
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
	/// <term>If the target exists, behaves as if it is in use and queues the file for copying on the next system restart.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_NOOVERWRITE</term>
	/// <term>Checks whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_NEWER</term>
	/// <term>
	/// Examines each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not
	/// notified. The function returns FALSE, and GetLastError returns NO_ERROR.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CopyMsgHandler">
	/// Optional pointer to a callback function to be notified of various conditions that may arise during the file copy operation.
	/// </param>
	/// <param name="Context">Optional pointer to a caller-defined value that is passed as the first parameter of the callback function.</param>
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
	/// If a UNC directory is specified as the target directory of a file installation, you must ensure it exists before you call
	/// <c>SetupInstallFile</c>. The setup functions do not check for the existence of nor create UNC directories. If the target UNC
	/// directory does not exist, the file installation will fail.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfilea WINSETUPAPI BOOL SetupInstallFileA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR SourceFile, PCSTR SourcePathRoot, PCSTR DestinationName, DWORD CopyStyle,
	// PSP_FILE_CALLBACK_A CopyMsgHandler, PVOID Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFile([In, Optional] HINF InfHandle, in INFCONTEXT InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceFile,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourcePathRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DestinationName,
		SP_COPY CopyStyle, [Optional] PSP_FILE_CALLBACK? CopyMsgHandler, [In, Optional] IntPtr Context);

	/// <summary>
	/// <para>
	/// [This function is available for use in the operating systems indicated in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. SetupAPI should no longer be used for installing applications. Instead, use the Windows
	/// Installer for developing application installers. SetupAPI continues to be used for installing device drivers.]
	/// </para>
	/// <para>
	/// The <c>SetupInstallFile</c> function installs a file as specified either by an INFCONTEXT returned by SetupFindXXXLine or
	/// explicitly by the file name and path.
	/// </para>
	/// <para>If a file is copied, the caller of this function must have write privileges into the target directory.</para>
	/// </summary>
	/// <param name="InfHandle">
	/// Optional pointer to the handle to an INF file that contains SourceDisksNames and SourceDisksFiles sections. If platform-specific
	/// sections exist for the user's system (for example, SourceDisksNames.x86 and SourceDisksFiles.x86), the platform-specific section
	/// will be used. If InfContext is null and CopyStyle includes SP_COPY_SOURCE_ABSOLUTE or SP_COPY_SOURCEPATH_ABSOLUTE, InfHandle is ignored.
	/// </param>
	/// <param name="InfContext">
	/// Optional pointer to the context of a line in a Copy Files section in an INF file. The routine looks up this file in the
	/// SourceDisksFiles section of InfHandle to get file copy information. If InfHandle is not specified, SourceFile must be.
	/// </param>
	/// <param name="SourceFile">
	/// Optional pointer to the file name (no path) of the file to copy. The file is looked up in the SourceDisksFiles section. The
	/// SourceFile parameter must be specified if InfContext is not. SourceFile is ignored if InfContext is specified.
	/// </param>
	/// <param name="SourcePathRoot">
	/// Optional pointer to the root path for the file to be copied (for example, A:\ or F:). Paths in the SourceDisksNames section are
	/// appended to this path. The SourcePathRoot parameter is ignored if CopyStyle includes the SP_COPY_SOURCE_ABSOLUTE flag.
	/// </param>
	/// <param name="DestinationName">
	/// Optional pointer to the file name only (no path) of the target file. This parameter can be null to indicate that the target file
	/// should have the same name as the source file. If InfContext is not specified, DestinationName supplies the full path and file
	/// name for the target.
	/// </param>
	/// <param name="CopyStyle">
	/// <para>Flags that control the behavior of the file copy operation. These flags may be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SP_COPY_DELETESOURCE</term>
	/// <term>Deletes the source file upon successful copy. The caller is not notified if the delete operation fails.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_REPLACEONLY</term>
	/// <term>
	/// Copies the file only if doing so would overwrite a file at the destination path. If the target does not exist, the function
	/// returns FALSE and GetLastError returns NO_ERROR.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NEWER_OR_SAME</term>
	/// <term>
	/// Examines each file being copied to see if its version resources indicate that it is either the same version or not newer than an
	/// existing copy on the target. The file version information used during version checks is that specified in the dwFileVersionMS
	/// and dwFileVersionLS members of a VS_FIXEDFILEINFO structure, as filled in by the version functions. If one of the files does not
	/// have version resources, or if they have identical version information, the source file is considered newer. If the source file
	/// is not newer or equal in version, and CopyMsgHandler is specified, the caller is notified and may cancel the copy operation. If
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
	/// Check whether the target file exists, and, if so, notify the caller who may veto the copy. If CopyMsgHandler is not specified,
	/// the file is not overwritten.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_NODECOMP</term>
	/// <term>
	/// Do not decompress the file. When this flag is set, the target file is not given the uncompressed form of the source name (if
	/// appropriate). For example, copying F:\x86\cmd.ex_ to \\install\temp results in a target file of \\install\temp\cmd.ex_. If the
	/// SP_COPY_NODECOMP flag was not specified, the file would be decompressed and the target would be called \\install\temp\cmd.exe.
	/// The file name part of DestinationName, if specified, is stripped and replaced with the file name of the source file. When
	/// SP_COPY_NODECOMP is specified, no language or version information can be checked.
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
	/// <term>If the target exists, behaves as if it is in use and queues the file for copying on the next system restart.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_NOOVERWRITE</term>
	/// <term>Checks whether the target file exists, and, if so, the file is not overwritten. The caller is not notified.</term>
	/// </item>
	/// <item>
	/// <term>SP_COPY_FORCE_NEWER</term>
	/// <term>
	/// Examines each file being copied to see if its version resources (or time stamps for non-image files) indicate that it is not
	/// newer than an existing copy on the target. If the file being copied is not newer, the file is not copied. The caller is not
	/// notified. The function returns FALSE, and GetLastError returns NO_ERROR.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CopyMsgHandler">
	/// Optional pointer to a callback function to be notified of various conditions that may arise during the file copy operation.
	/// </param>
	/// <param name="Context">Optional pointer to a caller-defined value that is passed as the first parameter of the callback function.</param>
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
	/// If a UNC directory is specified as the target directory of a file installation, you must ensure it exists before you call
	/// <c>SetupInstallFile</c>. The setup functions do not check for the existence of nor create UNC directories. If the target UNC
	/// directory does not exist, the file installation will fail.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The setupapi.h header defines SetupInstallFile as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
	/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
	/// for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupinstallfilea WINSETUPAPI BOOL SetupInstallFileA(
	// HINF InfHandle, PINFCONTEXT InfContext, PCSTR SourceFile, PCSTR SourcePathRoot, PCSTR DestinationName, DWORD CopyStyle,
	// PSP_FILE_CALLBACK_A CopyMsgHandler, PVOID Context );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupInstallFileA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupInstallFile([In, Optional] HINF InfHandle, [In, Optional] IntPtr InfContext, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourceFile,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? SourcePathRoot, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? DestinationName,
		SP_COPY CopyStyle, [Optional] PSP_FILE_CALLBACK? CopyMsgHandler, [In, Optional] IntPtr Context);
}