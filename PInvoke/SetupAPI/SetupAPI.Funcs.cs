using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the SetupAPI.dll</summary>
	public static partial class SetupAPI
	{
		private const string Lib_SetupAPI = "SetupAPI.dll";

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
		public static extern void InstallHinfSection(HWND Window, HINSTANCE ModuleHandle, [MarshalAs(UnmanagedType.LPTStr)] string CommandLine,
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
		public static extern uint SetupBackupError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string DialogTitle,
			[MarshalAs(UnmanagedType.LPTStr)] string SourceFile, [MarshalAs(UnmanagedType.LPTStr)] string TargetFile, Win32Error Win32ErrorCode, IDF Style);

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
		public static extern bool SetupCommitFileQueue([Optional] HWND Owner, HSPFILEQ QueueHandle, PSP_FILE_CALLBACK MsgHandler, IntPtr Context);

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
		public static extern uint SetupCopyError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string DialogTitle,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string DiskName, [MarshalAs(UnmanagedType.LPTStr)] string PathToSource,
			[MarshalAs(UnmanagedType.LPTStr)] string SourceFile, [Optional, MarshalAs(UnmanagedType.LPTStr)] string TargetPathFile,
			Win32Error Win32ErrorCode, IDF Style, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder PathBuffer, uint PathBufferSize, out uint PathRequiredSize);

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
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string OEMSourceMediaLocation, uint OEMSourceMediaType, CopyStyle CopyStyle,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder DestinationInfFileName, uint DestinationInfFileNameSize, out uint RequiredSize,
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
		public static extern uint SetupDeleteError(HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPTStr)] string DialogTitle,
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
		public static extern bool SetupEnumInfSections(HINF InfHandle, uint Index, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder Buffer, uint Size, out uint SizeNeeded);

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
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string Key, out INFCONTEXT Context);

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
		public static extern bool SetupFindNextMatchLine(in INFCONTEXT ContextIn, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Key, out INFCONTEXT ContextOut);

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
		/// <code>typedef VOID (WINAPI* MYFREEFUNC)(LPVOID lpBuff); MYFREEFUNC MyFree; HMODULE hDll=NULL; hDll = GetModuleHandle("SETUPAPI.DLL"); MyFree = (MYFREEFUNC)GetProcAddress(hDll, "MyFree"); ... other code here to prepare file queue ... PTSTR lpActualSourceFileName; SetupGetFileCompressionInfo(...,&amp;lpActualSourceFileName,...,...,...); ... MyFree(lpActualSourceFileName);</code>
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
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string InfClass, INF_STYLE InfStyle, out uint ErrorLine);

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDSKSPC"/> that is disposed using <see cref="SetupDestroyDiskSpaceList"/>.</summary>
		public class SafeHDSKSPC : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHDSKSPC"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHDSKSPC(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHDSKSPC"/> class.</summary>
			private SafeHDSKSPC() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHDSKSPC"/> to <see cref="HDSKSPC"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HDSKSPC(SafeHDSKSPC h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => SetupDestroyDiskSpaceList(handle);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HINF"/> that is disposed using <see cref="SetupCloseInfFile"/>.</summary>
		public class SafeHINF : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHINF"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHINF(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHINF"/> class.</summary>
			private SafeHINF() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHINF"/> to <see cref="HINF"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HINF(SafeHINF h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SetupCloseInfFile(handle); return true; }
		}

		/*
		SetupFreeSourceListA
		SetupFreeSourceListW
		SetupGetBinaryField
		SetupGetFieldCount
		SetupGetFileCompressionInfoExA
		SetupGetFileCompressionInfoExW
		SetupGetFileQueueCount
		SetupGetFileQueueFlags
		SetupGetInfDriverStoreLocationA
		SetupGetInfDriverStoreLocationW
		SetupGetInfFileListA
		SetupGetInfFileListW
		SetupGetInfInformationA
		SetupGetInfInformationW
		SetupGetInfPublishedNameA
		SetupGetInfPublishedNameW
		SetupGetIntField
		SetupGetLineByIndexA
		SetupGetLineByIndexW
		SetupGetLineCountA
		SetupGetLineCountW
		SetupGetLineTextA
		SetupGetLineTextW
		SetupGetMultiSzFieldA
		SetupGetMultiSzFieldW
		SetupGetNonInteractiveMode
		SetupGetSourceFileLocationA
		SetupGetSourceFileLocationW
		SetupGetSourceFileSizeA
		SetupGetSourceFileSizeW
		SetupGetSourceInfoA
		SetupGetSourceInfoW
		SetupGetStringFieldA
		SetupGetStringFieldW
		SetupGetTargetPathA
		SetupGetTargetPathW
		SetupGetThreadLogToken
		SetupInitDefaultQueueCallback
		SetupInitDefaultQueueCallbackEx
		SetupInitializeFileLogA
		SetupInitializeFileLogW
		SetupInstallFileA
		SetupInstallFileExA
		SetupInstallFileExW
		SetupInstallFilesFromInfSectionA
		SetupInstallFilesFromInfSectionW
		SetupInstallFileW
		SetupInstallFromInfSectionA
		SetupInstallFromInfSectionW
		SetupInstallServicesFromInfSectionA
		SetupInstallServicesFromInfSectionExA
		SetupInstallServicesFromInfSectionExW
		SetupInstallServicesFromInfSectionW
		SetupIterateCabinetA
		SetupIterateCabinetW
		SetupLogErrorA
		SetupLogErrorW
		SetupLogFileA
		SetupLogFileW
		SetupOpenAppendInfFileA
		SetupOpenAppendInfFileW
		SetupOpenFileQueue
		SetupOpenLog
		SetupOpenMasterInf
		SetupPromptForDiskA
		SetupPromptForDiskW
		SetupPromptReboot
		SetupQueryDrivesInDiskSpaceListA
		SetupQueryDrivesInDiskSpaceListW
		SetupQueryFileLogA
		SetupQueryFileLogW
		SetupQueryInfFileInformationA
		SetupQueryInfFileInformationW
		SetupQueryInfOriginalFileInformationA
		SetupQueryInfOriginalFileInformationW
		SetupQueryInfVersionInformationA
		SetupQueryInfVersionInformationW
		SetupQuerySourceListA
		SetupQuerySourceListW
		SetupQuerySpaceRequiredOnDriveA
		SetupQuerySpaceRequiredOnDriveW
		SetupQueueCopyA
		SetupQueueCopyIndirectA
		SetupQueueCopyIndirectW
		SetupQueueCopySectionA
		SetupQueueCopySectionW
		SetupQueueCopyW
		SetupQueueDefaultCopyA
		SetupQueueDefaultCopyW
		SetupQueueDeleteA
		SetupQueueDeleteSectionA
		SetupQueueDeleteSectionW
		SetupQueueDeleteW
		SetupQueueRenameA
		SetupQueueRenameSectionA
		SetupQueueRenameSectionW
		SetupQueueRenameW
		SetupRemoveFileLogEntryA
		SetupRemoveFileLogEntryW
		SetupRemoveFromDiskSpaceListA
		SetupRemoveFromDiskSpaceListW
		SetupRemoveFromSourceListA
		SetupRemoveFromSourceListW
		SetupRemoveInstallSectionFromDiskSpaceListA
		SetupRemoveInstallSectionFromDiskSpaceListW
		SetupRemoveSectionFromDiskSpaceListA
		SetupRemoveSectionFromDiskSpaceListW
		SetupRenameErrorA
		SetupRenameErrorW
		SetupScanFileQueueA
		SetupScanFileQueueW
		SetupSetDirectoryIdA
		SetupSetDirectoryIdExA
		SetupSetDirectoryIdExW
		SetupSetDirectoryIdW
		SetupSetFileQueueAlternatePlatformA
		SetupSetFileQueueAlternatePlatformW
		SetupSetFileQueueFlags
		SetupSetNonInteractiveMode
		SetupSetPlatformPathOverrideA
		SetupSetPlatformPathOverrideW
		SetupSetSourceListA
		SetupSetSourceListW
		SetupSetThreadLogToken
		SetupTermDefaultQueueCallback
		SetupTerminateFileLog
		SetupUninstallNewlyCopiedInfs
		SetupUninstallOEMInfA
		SetupUninstallOEMInfW
		SetupVerifyInfFileA
		SetupVerifyInfFileW
		SetupWriteTextLog
		SetupWriteTextLogError
		SetupWriteTextLogInfLine
		*/
	}
}