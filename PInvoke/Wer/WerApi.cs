using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.DbgHelp;
using static Vanara.PInvoke.Kernel32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Wer
	{
		/// <summary>The type of report store to open.</summary>
		[PInvokeData("werapi.h")]
		public enum REPORT_STORE_TYPES
		{
			/// <summary>Undocumented.</summary>
			E_STORE_USER_ARCHIVE = 0,

			/// <summary>Undocumented.</summary>
			E_STORE_USER_QUEUE = 1,

			/// <summary>Opens the store of error reports that have already been sent to Microsoft.</summary>
			E_STORE_MACHINE_ARCHIVE = 2,

			/// <summary>Opens the queue of all error reports on the machine that have not yet been sent to Microsoft.</summary>
			E_STORE_MACHINE_QUEUE = 3,

			/// <summary>Undocumented.</summary>
			E_STORE_INVALID = 4
		}

		/// <summary>The consent status.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "1433862e-5cf6-4d31-9fd9-137b7b86ec57")]
		public enum WER_CONSENT
		{
			/// <summary>The user was not asked for consent.</summary>
			WerConsentNotAsked = 1,

			/// <summary>The user has approved the submission request.</summary>
			WerConsentApproved = 2,

			/// <summary>The user has denied the submission request.</summary>
			WerConsentDenied = 3,

			/// <summary>The user is always asked to submit the request.</summary>
			WerConsentAlwaysPrompt = 4,
		}

		/// <summary>Flags used by <see cref="WerReportAddDump"/>.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "b40dac44-f7c5-43f0-876d-6f97c26bf461")]
		[Flags]
		public enum WER_DUMP
		{
			/// <summary>If the report is being queued, do not include a heap dump. Using this flag saves disk space.</summary>
			WER_DUMP_NOHEAP_ONQUEUE = 1,

			/// <summary>Undocumented.</summary>
			WER_DUMP_AUXILIARY = 2
		}

		/// <summary>A mask that controls which options are valid in <see cref="WER_DUMP_CUSTOM_OPTIONS"/>.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "6ea32573-ac1a-4f9b-b4ba-b5767927924f")]
		[Flags]
		public enum WER_DUMP_MASK : uint
		{
			WER_DUMP_MASK_DUMPTYPE = 1 << 0,
			WER_DUMP_MASK_ONLY_THISTHREAD = 1 << 1,
			WER_DUMP_MASK_THREADFLAGS = 1 << 2,
			WER_DUMP_MASK_THREADFLAGS_EX = 1 << 3,
			WER_DUMP_MASK_OTHERTHREADFLAGS = 1 << 4,
			WER_DUMP_MASK_OTHERTHREADFLAGS_EX = 1 << 5,
			WER_DUMP_MASK_PREFERRED_MODULESFLAGS = 1 << 6,
			WER_DUMP_MASK_OTHER_MODULESFLAGS = 1 << 7,
			WER_DUMP_MASK_PREFERRED_MODULE_LIST = 1 << 8,
		}

		public enum WER_DUMP_TYPE
		{
			WerDumpTypeNone = 0,
			WerDumpTypeMicroDump = 1,
			WerDumpTypeMiniDump = 2,
			WerDumpTypeHeapDump = 3,
			WerDumpTypeTriageDump = 4,
			WerDumpTypeMax = 5
		}

		/// <summary>The identifier of the parameter to be set.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "accf423d-6f03-41e2-b5e9-4a0b630bc918")]
		public enum WER_P
		{
			WER_P0 = 0,
			WER_P1 = 1,
			WER_P2 = 2,
			WER_P3 = 3,
			WER_P4 = 4,
			WER_P5 = 5,
			WER_P6 = 6,
			WER_P7 = 7,
			WER_P8 = 8,
			WER_P9 = 9,
		}

		/// <summary>Flags for <see cref="WerReportSubmit"/>.</summary>
		[PInvokeData("werapi.h", MSDNShortId = "1433862e-5cf6-4d31-9fd9-137b7b86ec57")]
		[Flags]
		public enum WER_SUBMIT
		{
			/// <summary>Honor any recovery registration for the application. For more information, see RegisterApplicationRecoveryCallback.</summary>
			WER_SUBMIT_HONOR_RECOVERY = 1,

			/// <summary>Honor any restart registration for the application. For more information, see RegisterApplicationRestart.</summary>
			WER_SUBMIT_HONOR_RESTART = 2,

			/// <summary>
			/// Add the report to the WER queue without notifying the user. The report is queued only—reporting (sending the report to
			/// Microsoft) occurs later based on the user's consent level.
			/// </summary>
			WER_SUBMIT_QUEUE = 4,

			/// <summary>Show the debug button.</summary>
			WER_SUBMIT_SHOW_DEBUG = 8,

			/// <summary>Add the data registered by WerSetFlags, WerRegisterFile, and WerRegisterMemoryBlock to the report.</summary>
			WER_SUBMIT_ADD_REGISTERED_DATA = 16,

			/// <summary>Spawn another process to submit the report. The calling thread is blocked until the function returns.</summary>
			WER_SUBMIT_OUTOFPROCESS = 32,

			/// <summary>Do not display the close dialog box for the critical report.</summary>
			WER_SUBMIT_NO_CLOSE_UI = 64,

			/// <summary>
			/// Do not queue the report. If there is adequate user consent the report is sent to Microsoft immediately; otherwise, the report
			/// is discarded. You may use this flag for non-critical reports.
			/// <para>
			/// The report is discarded for any action that would require the report to be queued. For example, if the computer is offline
			/// when you submit the report, the report is discarded. Also, if there is insufficient consent (for example, consent was
			/// required for the data portion of the report), the report is discarded.
			/// </para>
			/// </summary>
			WER_SUBMIT_NO_QUEUE = 128,

			/// <summary>Do not archive the report.</summary>
			WER_SUBMIT_NO_ARCHIVE = 256,

			/// <summary>The initial UI is minimized and flashing.</summary>
			WER_SUBMIT_START_MINIMIZED = 512,

			/// <summary>
			/// Spawn another process to submit the report and return from this function call immediately. Note that the contents of the
			/// pSubmitResult parameter are undefined and there is no way to query when the reporting completes or the completion status.
			/// </summary>
			WER_SUBMIT_OUTOFPROCESS_ASYNC = 1024,

			/// <summary>
			/// Bypass data throttling for the report.
			/// <para>Windows 7 or earlier: This parameter is not available.</para>
			/// </summary>
			WER_SUBMIT_BYPASS_DATA_THROTTLING = 2048,

			/// <summary>Archive only the parameters; the cab is discarded</summary>
			WER_SUBMIT_ARCHIVE_PARAMETERS_ONLY = 4096,

			/// <summary>Always send the machine ID, regardless of the consent the report was submitted with</summary>
			WER_SUBMIT_REPORT_MACHINE_ID = 8192,

			/// <summary>Bypass power-related throttling (when on battery)</summary>
			WER_SUBMIT_BYPASS_POWER_THROTTLING = 16384,

			/// <summary>Bypass network-related throttling (when on restricted networks)</summary>
			WER_SUBMIT_BYPASS_NETWORK_COST_THROTTLING = 32768
		}

		/// <summary>Adds the specified application to the list of applications that are to be excluded from error reporting.</summary>
		/// <param name="pwzExeName">
		/// A pointer to a Unicode string that specifies the name of the executable file for the application, including the file name
		/// extension. The maximum length of this path is MAX_PATH characters.
		/// </param>
		/// <param name="bAllUsers">
		/// If this parameter is <c>TRUE</c>, the application name is added to the list of excluded applications for all users. Otherwise, it
		/// is only added to the list of excluded applications for the current user.
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The process does not have permissions to update the list in the registry. See the Remarks section for additional information.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If bAllUsers is <c>TRUE</c>, the list of excluded applications is stored under the HKEY_LOCAL_MACHINE registry hive. The calling
		/// process must have permissions to write to the HKLM registry hive. If bAllUsers is <c>FALSE</c>, the list of excluded applications
		/// is stored under the HKEY_CURRENT_USER registry hive.
		/// </para>
		/// <para>To remove the application from the list of excluded applications, call the WerRemoveExcludedApplication function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-weraddexcludedapplication HRESULT WerAddExcludedApplication(
		// PCWSTR pwzExeName, BOOL bAllUsers );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "ac1ec373-868f-4634-8658-4253d4f5923a")]
		public static extern HRESULT WerAddExcludedApplication([MarshalAs(UnmanagedType.LPWStr)] string pwzExeName, [MarshalAs(UnmanagedType.Bool)] bool bAllUsers);

		/// <summary>
		/// Frees up the memory used to store a report key string. This should be called after each successive call to
		/// WerStoreGetFirstReportKey or WerStoreGetNextReportKey, once the particular report key string has been used and is no longer needed.
		/// </summary>
		/// <param name="pwszStr">The string to be freed (value set to <c>NULL</c>).</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werfreestring void WerFreeString( PCWSTR pwszStr );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "748AEFD4-3310-4BC1-A3DA-CFACBA31F2FC")]
		public static extern void WerFreeString([MarshalAs(UnmanagedType.LPWStr)] string pwszStr);

		/// <summary>Removes the specified application from the list of applications that are to be excluded from error reporting.</summary>
		/// <param name="pwzExeName">
		/// <para>
		/// A pointer to a Unicode string that specifies the name of the executable file for the application, including the file name
		/// extension. The maximum length of this path is MAX_PATH characters.
		/// </para>
		/// <para>
		/// This file must have been excluded using the WerAddExcludedApplication function or <c>WerRemoveExcludedApplication</c> fails.
		/// </para>
		/// </param>
		/// <param name="bAllUsers">
		/// If this parameter is <c>TRUE</c>, the application name is removed from the list of excluded applications for all users.
		/// Otherwise, it is only removed from the list of excluded applications for the current user.
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The process does not have access to update the list in the registry. See the Remarks section for additional information.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function removes applications that were added to the excluded applications list using the WerAddExcludedApplication function.
		/// </para>
		/// <para>
		/// If bAllUsers is <c>TRUE</c>, the list of excluded applications is stored under the HKEY_LOCAL_MACHINE registry hive. The calling
		/// process must have permissions to write to HKLM registry hive. If bAllUsers is <c>FALSE</c>, the list of excluded applications is
		/// stored under the HKEY_CURRENT_USER registry hive.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werremoveexcludedapplication HRESULT
		// WerRemoveExcludedApplication( PCWSTR pwzExeName, BOOL bAllUsers );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "e7bab01b-a09c-4b06-a233-34ed63f75857")]
		public static extern HRESULT WerRemoveExcludedApplication([MarshalAs(UnmanagedType.LPWStr)] string pwzExeName, [MarshalAs(UnmanagedType.Bool)] bool bAllUsers);

		/// <summary>Adds a dump of the specified type to the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <param name="hProcess">
		/// A handle to the process for which the report is being generated. This handle must have the STANDARD_RIGHTS_READ and
		/// PROCESS_QUERY_INFORMATION access rights.
		/// </param>
		/// <param name="hThread">
		/// A handle to the thread of hProcess for which the report is being generated. If dumpType is WerDumpTypeMicro, this parameter is
		/// required. For other dump types, this parameter may be <c>NULL</c>.
		/// </param>
		/// <param name="dumpType">
		/// <para>The type of minidump. This parameter can be one of the following values from the <c>WER_DUMP_TYPE</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerDumpTypeHeapDump</term>
		/// <term>
		/// An extended minidump that contains additional data such as the process memory. This type is equivalent to creating a minidump
		/// with the following options:
		/// </term>
		/// </item>
		/// <item>
		/// <term>WerDumpTypeMicroDump</term>
		/// <term>
		/// A limited minidump that contains only a stack trace. This type is equivalent to creating a minidump with the following options:
		/// </term>
		/// </item>
		/// <item>
		/// <term>WerDumpTypeMiniDump</term>
		/// <term>A minidump. This type is equivalent to creating a minidump with the following options:</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pExceptionParam">A pointer to a WER_EXCEPTION_INFORMATION structure that specifies exception information.</param>
		/// <param name="pDumpCustomOptions">
		/// A pointer to a WER_DUMP_CUSTOM_OPTIONS structure that specifies custom minidump options. If this parameter is <c>NULL</c>, the
		/// standard minidump information is collected.
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be 0 or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_DUMP_NOHEAP_ONQUEUE</term>
		/// <term>If the report is being queued, do not include a heap dump. Using this flag saves disk space.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		/// <remarks>
		/// <para>Use this function only for generic reporting—it has no effect on operating system crash or no-response reporting.</para>
		/// <para>
		/// If the server asks for a mini dump and you specify <c>WerDumpTypeHeapDump</c> for the dumpType parameter, WER will not send the
		/// heap dump to the Watson server. However, if the server asks for a heap dump and the dumpType is <c>WerDumpTypeMiniDump</c>, WER
		/// will send the mini dump to the server. Thus, it is recommended that you set dumpType to <c>WerDumpTypeMiniDump</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportadddump HRESULT WerReportAddDump( HREPORT
		// hReportHandle, HANDLE hProcess, HANDLE hThread, WER_DUMP_TYPE dumpType, PWER_EXCEPTION_INFORMATION pExceptionParam,
		// PWER_DUMP_CUSTOM_OPTIONS pDumpCustomOptions, DWORD dwFlags );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "b40dac44-f7c5-43f0-876d-6f97c26bf461")]
		public static extern HRESULT WerReportAddDump(HREPORT hReportHandle, HPROCESS hProcess, HTHREAD hThread, WER_DUMP_TYPE dumpType, in WER_EXCEPTION_INFORMATION pExceptionParam, in WER_DUMP_CUSTOM_OPTIONS pDumpCustomOptions, WER_DUMP dwFlags);

		/// <summary>Adds a file to the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <param name="pwzPath">
		/// A pointer to a Unicode string that contains the full path to the file to be added. This path can use environment variables. The
		/// maximum length of this path is MAX_PATH characters.
		/// </param>
		/// <param name="repFileType">
		/// <para>The type of file. This parameter can be one of the following values from the <c>WER_FILE_TYPE</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerFileTypeHeapdump</term>
		/// <term>An extended minidump that contains additional data such as the process memory.</term>
		/// </item>
		/// <item>
		/// <term>WerFileTypeMicrodump</term>
		/// <term>A limited minidump that contains only a stack trace.</term>
		/// </item>
		/// <item>
		/// <term>WerFileTypeMinidump</term>
		/// <term>A minidump file.</term>
		/// </item>
		/// <item>
		/// <term>WerFileTypeOther</term>
		/// <term>Any other type of file. This file will always get added to the cab (but only if the server asks for a cab).</term>
		/// </item>
		/// <item>
		/// <term>WerFileTypeUserDocument</term>
		/// <term>
		/// The document in use by the application at the time of the event. The document is added only if the server is asks for this type
		/// of document.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFileFlags">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_FILE_ANONYMOUS_DATA</term>
		/// <term>The file does not contain personal information that could be used to identify or contact the user.</term>
		/// </item>
		/// <item>
		/// <term>WER_FILE_DELETE_WHEN_DONE</term>
		/// <term>Automatically delete the file after the report is submitted.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)</term>
		/// <term>The specified file does not exist.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</term>
		/// <term>The specified file is a user-document and is stored on an encrypted file-system; this combination is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Although this function can also be used to add memory dumps (using specific flags) to the error report, the preferred function to
		/// use for adding memory dumps is WerReportAddDump. You should use this function only if you want to collect the dump yourself and
		/// then add it to the report.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportaddfile HRESULT WerReportAddFile( HREPORT
		// hReportHandle, PCWSTR pwzPath, WER_FILE_TYPE repFileType, DWORD dwFileFlags );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "4b2c2060-a193-4168-90fc-afb95c160569")]
		public static extern HRESULT WerReportAddFile(HREPORT hReportHandle, [MarshalAs(UnmanagedType.LPWStr)] string pwzPath, WER_FILE_TYPE repFileType, WER_REGISTER_FILE_FLAGS dwFileFlags);

		/// <summary>Closes the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportclosehandle HRESULT WerReportCloseHandle( HREPORT
		// hReportHandle );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "b7326003-cd25-4988-9ed4-31c2e030beec")]
		public static extern HRESULT WerReportCloseHandle(HREPORT hReportHandle);

		/// <summary>Creates a problem report that describes an application event.</summary>
		/// <param name="pwzEventType">A pointer to a Unicode string that specifies the name of the event.</param>
		/// <param name="repType">
		/// <para>The type of report. This parameter can be one of the following values from the <c>WER_REPORT_TYPE</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerReportApplicationCrash 2</term>
		/// <term>An error that has caused the application to stop running has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportApplicationHang 3</term>
		/// <term>An error that has caused the application to stop responding has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportInvalid 5</term>
		/// <term>An error that has called out a return that is not valid has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportKernel 4</term>
		/// <term>An error in the kernel has occurred.</term>
		/// </item>
		/// <item>
		/// <term>WerReportCritical 1</term>
		/// <term>
		/// A critical error, such as a crash or non-response, has occurred. By default, processes that experience a critical error are
		/// terminated or restarted.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WerReportNonCritical 0</term>
		/// <term>
		/// An error that is not critical has occurred. This type of report shows no UI; the report is silently queued. It may then be sent
		/// silently to the server in the background if adequate user consent is available.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pReportInformation">A pointer to a WER_REPORT_INFORMATION structure that specifies information for the report.</param>
		/// <param name="phReportHandle">A handle to the report. If the function fails, this handle is <c>NULL</c>.</param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		/// <remarks>
		/// <para>Use the following functions to specify additional information to be submitted:</para>
		/// <para>
		/// WerReportAddDump WerReportAddFile WerReportSetParameter To submit the information, call the WerReportSubmit function. When you
		/// have finished with the report handle, call the WerReportCloseHandle function.
		/// </para>
		/// <para>
		/// Applications can also indicate that they would like the opportunity to recover data or restart on failure. For more information,
		/// see Application Recovery and Restart.
		/// </para>
		/// <para>To view the reports submitted by your application, go to Windows Quality Online Services.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportcreate HRESULT WerReportCreate( PCWSTR pwzEventType,
		// WER_REPORT_TYPE repType, PWER_REPORT_INFORMATION pReportInformation, HREPORT *phReportHandle );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("werapi.h", MSDNShortId = "41f68dde-5e43-45a6-8e0b-3ae0c6180e8b")]
		public static extern HRESULT WerReportCreate(string pwzEventType, WER_REPORT_TYPE repType, in WER_REPORT_INFORMATION pReportInformation, out SafeHREPORT phReportHandle);

		/// <summary>Sets the parameters that uniquely identify an event for the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <param name="dwparamID">
		/// <para>The identifier of the parameter to be set. This parameter can be one of the following values.</para>
		/// <para>WER_P0</para>
		/// <para>WER_P1</para>
		/// <para>WER_P2</para>
		/// <para>WER_P3</para>
		/// <para>WER_P4</para>
		/// <para>WER_P5</para>
		/// <para>WER_P6</para>
		/// <para>WER_P7</para>
		/// <para>WER_P8</para>
		/// <para>WER_P9</para>
		/// </param>
		/// <param name="pwzName">
		/// A pointer to a Unicode string that contains the name of the parameter. If this parameter is <c>NULL</c>, the default name is Px,
		/// where x matches the integer portion of the value specified in dwparamID.
		/// </param>
		/// <param name="pwzValue">The parameter value.</param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_HANDLE</term>
		/// <term>The specified handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>WER_E_LENGTH_EXCEEDED</term>
		/// <term>The length of one or more string arguments has exceeded its limit.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Each report supports parameters P0 through P9. This function sets one parameter at a time. If parameter Px is set, then all
		/// parameters from P0 and Px must be set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportsetparameter HRESULT WerReportSetParameter( HREPORT
		// hReportHandle, DWORD dwparamID, PCWSTR pwzName, PCWSTR pwzValue );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "accf423d-6f03-41e2-b5e9-4a0b630bc918")]
		public static extern HRESULT WerReportSetParameter(HREPORT hReportHandle, WER_P dwparamID, [MarshalAs(UnmanagedType.LPWStr)] string pwzName, [MarshalAs(UnmanagedType.LPWStr)] string pwzValue);

		/// <summary>Sets the user interface options for the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <param name="repUITypeID">
		/// <para>
		/// The user interface element to be customized. This parameter can be one of the following values from the <c>WER_REPORT_UI</c>
		/// enumeration type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerUIAdditionalDataDlgHeader</term>
		/// <term>The instructions for the additional data dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUICloseDlgBody</term>
		/// <term>The contents of the close dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUICloseDlgButtonText</term>
		/// <term>The text for the button in the close dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUICloseDlgHeader</term>
		/// <term>The main instructions for the close dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUICloseText</term>
		/// <term>The text for the link to just terminate the application.</term>
		/// </item>
		/// <item>
		/// <term>WerUIConsentDlgBody</term>
		/// <term>The contents of the consent dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUIConsentDlgHeader</term>
		/// <term>The main instructions for the consent dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUIIconFilePath</term>
		/// <term>The icon to be displayed in the consent dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WerUIOfflineSolutionCheckText</term>
		/// <term>The text for the link to check for a solution when offline.</term>
		/// </item>
		/// <item>
		/// <term>WerUIOnlineSolutionCheckText</term>
		/// <term>The text for the link to check for a solution when online.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwzValue">
		/// A pointer to a Unicode string that specifies the custom text. For more information, see the description of repUITypeID.
		/// </param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportsetuioption HRESULT WerReportSetUIOption( HREPORT
		// hReportHandle, WER_REPORT_UI repUITypeID, PCWSTR pwzValue );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "c8816782-faec-490e-898f-a40df8fb205b")]
		public static extern HRESULT WerReportSetUIOption(HREPORT hReportHandle, WER_REPORT_UI repUITypeID, [MarshalAs(UnmanagedType.LPWStr)] string pwzValue);

		/// <summary>Submits the specified report.</summary>
		/// <param name="hReportHandle">A handle to the report. This handle is returned by the WerReportCreate function.</param>
		/// <param name="consent">
		/// <para>The consent status. This parameter can be one of the following values from the <c>WER_CONSENT</c> enumeration type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerConsentAlwaysPrompt 4</term>
		/// <term>The user is always asked to submit the request.</term>
		/// </item>
		/// <item>
		/// <term>WerConsentApproved 2</term>
		/// <term>The user has approved the submission request.</term>
		/// </item>
		/// <item>
		/// <term>WerConsentDenied 3</term>
		/// <term>The user has denied the submission request.</term>
		/// </item>
		/// <item>
		/// <term>WerConsentMax 5</term>
		/// <term>The maximum value for the WER_CONSENT enumeration type.</term>
		/// </item>
		/// <item>
		/// <term>WerConsentNotAsked 1</term>
		/// <term>The user was not asked for consent.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WER_SUBMIT_ADD_REGISTERED_DATA 16</term>
		/// <term>Add the data registered by WerSetFlags, WerRegisterFile, and WerRegisterMemoryBlock to the report.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_HONOR_RECOVERY 1</term>
		/// <term>Honor any recovery registration for the application. For more information, see RegisterApplicationRecoveryCallback.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_HONOR_RESTART 2</term>
		/// <term>Honor any restart registration for the application. For more information, see RegisterApplicationRestart.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_NO_ARCHIVE 256</term>
		/// <term>Do not archive the report.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_NO_CLOSE_UI 64</term>
		/// <term>Do not display the close dialog box for the critical report.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_NO_QUEUE 128</term>
		/// <term>
		/// Do not queue the report. If there is adequate user consent the report is sent to Microsoft immediately; otherwise, the report is
		/// discarded. You may use this flag for non-critical reports. The report is discarded for any action that would require the report
		/// to be queued. For example, if the computer is offline when you submit the report, the report is discarded. Also, if there is
		/// insufficient consent (for example, consent was required for the data portion of the report), the report is discarded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_OUTOFPROCESS 32</term>
		/// <term>Spawn another process to submit the report. The calling thread is blocked until the function returns.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_OUTOFPROCESS_ASYNC 1024</term>
		/// <term>
		/// Spawn another process to submit the report and return from this function call immediately. Note that the contents of the
		/// pSubmitResult parameter are undefined and there is no way to query when the reporting completes or the completion status.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_QUEUE 4</term>
		/// <term>
		/// Add the report to the WER queue without notifying the user. The report is queued only—reporting (sending the report to Microsoft)
		/// occurs later based on the user's consent level.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_SHOW_DEBUG 8</term>
		/// <term>Show the debug button.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_START_MINIMIZED 512</term>
		/// <term>The initial UI is minimized and flashing.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_BYPASS_DATA_THROTTLING 2048</term>
		/// <term>Bypass data throttling for the report. Windows 7 or earlier: This parameter is not available.</term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_ARCHIVE_PARAMETERS_ONLY 4096</term>
		/// <term>
		/// Archive only the parameters; the cab is discarded. This flag overrides the ConfigureArchive WER setting. Windows 7 or earlier:
		/// This parameter is not available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WER_SUBMIT_REPORT_MACHINE_ID 8192</term>
		/// <term>
		/// Always send the unique, 128-bit computer identifier with the report, regardless of the consent with which the report was
		/// submitted. See Remarks for additional information. Windows 7 or earlier: This parameter is not available.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pSubmitResult">
		/// <para>
		/// The result of the submission. This parameter can be one of the following values from the <c>WER_SUBMIT_RESULT</c> enumeration type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WerCustomAction 9</term>
		/// <term>Error reporting can be customized.</term>
		/// </item>
		/// <item>
		/// <term>WerDisabled 5</term>
		/// <term>Error reporting was disabled.</term>
		/// </item>
		/// <item>
		/// <term>WerDisabledQueue 7</term>
		/// <term>Queuing was disabled.</term>
		/// </item>
		/// <item>
		/// <term>WerReportAsync 8</term>
		/// <term>The report was asynchronous.</term>
		/// </item>
		/// <item>
		/// <term>WerReportCancelled 6</term>
		/// <term>The report was canceled.</term>
		/// </item>
		/// <item>
		/// <term>WerReportDebug 3</term>
		/// <term>The Debug button was clicked.</term>
		/// </item>
		/// <item>
		/// <term>WerReportFailed 4</term>
		/// <term>The report submission failed.</term>
		/// </item>
		/// <item>
		/// <term>WerReportQueued 1</term>
		/// <term>The report was queued.</term>
		/// </item>
		/// <item>
		/// <term>WerReportUploaded 2</term>
		/// <term>The report was uploaded.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>This function returns <c>S_OK</c> on success or an error code on failure.</returns>
		/// <remarks>
		/// <para>
		/// After the application calls this function, WER collects the specified data. If the consent parameter is WerConsentApproved, it
		/// submits the report to Microsoft. If consent is WerConsentNotAsked, WER displays the consent dialog box. To determine the
		/// submission status, check the pSubmitResult parameter.
		/// </para>
		/// <para>In the event of a critical application event, applications that have registered for restart will be restarted.</para>
		/// <para>The computer identifier is sent with the report when</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The consent used to send the report does not come from the application. For example, the report was submitted with consent status
		/// set to WerConsentNotAsked.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The report was submitted with the WER_SUBMIT_REPORT_MACHINE_ID flag set.</term>
		/// </item>
		/// </list>
		/// <para>To view the reports submitted by your application, go to Windows Quality Online Services.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werreportsubmit HRESULT WerReportSubmit( HREPORT
		// hReportHandle, WER_CONSENT consent, DWORD dwFlags, PWER_SUBMIT_RESULT pSubmitResult );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "1433862e-5cf6-4d31-9fd9-137b7b86ec57")]
		public static extern HRESULT WerReportSubmit(HREPORT hReportHandle, WER_CONSENT consent, WER_SUBMIT dwFlags, out WER_SUBMIT_RESULT pSubmitResult);

		/// <summary>Closes the collection of stored reports.</summary>
		/// <param name="hReportStore">The error report store to close (previously retrieved with WerStoreOpen).</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoreclose void WerStoreClose( HREPORTSTORE hReportStore );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "C34FBA67-5267-471C-B1AA-87BFC5725831")]
		public static extern void WerStoreClose(HREPORTSTORE hReportStore);

		/// <summary>Gets a reference to the first report in the report store.</summary>
		/// <param name="hReportStore">The error report store (previously retrieved with WerStoreOpen).</param>
		/// <param name="ppszReportKey">
		/// A pointer to the report key string. On a successful call, this will point to the retrieved report key.
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALID_ARG</term>
		/// <term>One of the arguments is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_FILES</term>
		/// <term>There are no error reports in the store.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoregetfirstreportkey HRESULT WerStoreGetFirstReportKey(
		// HREPORTSTORE hReportStore, PCWSTR *ppszReportKey );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "E4732B60-BFBE-4916-83A6-5F031D267913")]
		public static extern HRESULT WerStoreGetFirstReportKey(HREPORTSTORE hReportStore, [MarshalAs(UnmanagedType.LPWStr)] out string ppszReportKey);

		/// <summary>Gets a reference to the next report in the error report store.</summary>
		/// <param name="hReportStore">The error report store (previously retrieved with WerStoreOpen).</param>
		/// <param name="ppszReportKey">
		/// A pointer to the report key string. On a successful call, this will point to the retrieved report key.
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALID_ARG</term>
		/// <term>One of the arguments is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_FILES</term>
		/// <term>There are no more error reports in the store.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoregetnextreportkey HRESULT WerStoreGetNextReportKey(
		// HREPORTSTORE hReportStore, PCWSTR *ppszReportKey );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "781D54A9-6F51-445E-89A8-A0C944081B81")]
		public static extern HRESULT WerStoreGetNextReportKey(HREPORTSTORE hReportStore, [MarshalAs(UnmanagedType.LPWStr)] out string ppszReportKey);

		/// <summary>Opens the collection of stored error reports.</summary>
		/// <param name="repStoreType">The type of report store to open. See Remarks for details.</param>
		/// <param name="phReportStore">A pointer to a report store. On a successful call, this will point to the retrieved report store.</param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is not a valid value.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A storeType value of <c>E_STORE_MACHINE_QUEUE</c> opens the queue of all error reports on the machine that have not yet been sent
		/// to Microsoft. A value of <c>E_STORE_MACHINE_ARCHIVE</c> opens the store of error reports that have already been sent.
		/// </para>
		/// <para>
		/// The Windows Error Report (WER) Store is the queue of error reports that have been marked to be sent to Microsoft but have not yet
		/// been uploaded. The upload of an error report can be postponed under a number of circumstances. The WerStore functions allow
		/// developers to access the stored reports and query the status of each one.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstoreopen HRESULT WerStoreOpen( REPORT_STORE_TYPES
		// repStoreType, PHREPORTSTORE phReportStore );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "FA7E0EC6-00F1-45E2-BE34-D732965FBA15")]
		public static extern HRESULT WerStoreOpen(REPORT_STORE_TYPES repStoreType, out SafeHREPORTSTORE phReportStore);

		/// <summary>Retrieves metadata about a report in the store.</summary>
		/// <param name="hReportStore">The error report store (previously retrieved with WerStoreOpen).</param>
		/// <param name="pszReportKey">
		/// The string identifying which report is being queried (previously retrieved with WerStoreGetFirstReportKey or WerStoreGetNextReportKey).
		/// </param>
		/// <param name="pReportMetadata">
		/// A pointer to the report store metadata in the form of a WER_REPORT_METADATA_V2 structure. The field <c>SizeOfFileNames</c> should
		/// be set to 0 during the first call. The function updates this field with the required size to hold the file names associated with
		/// the report. The field <c>FileNames</c> should then be allocated with <c>SizeOfFileNames</c> bytes and the function should be
		/// called again to get all of the file names.
		/// </param>
		/// <returns>
		/// <para>This function returns <c>S_OK</c> on success or an error code on failure, including the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALID_ARG</term>
		/// <term>One of the arguments is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// There is not enough memory available to retrieve the metadata. In this case, the caller should allocate memory of size
		/// SizeOfFileNames for the FileNames field, found in the WER_REPORT_METADATA_V2 structure, and call the function again.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/nf-werapi-werstorequeryreportmetadatav2 HRESULT
		// WerStoreQueryReportMetadataV2( HREPORTSTORE hReportStore, PCWSTR pszReportKey, PWER_REPORT_METADATA_V2 pReportMetadata );
		[DllImport(Lib.Wer, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("werapi.h", MSDNShortId = "ADF6619C-1F3E-4AFF-9E25-4F6F83D1353C")]
		public static extern HRESULT WerStoreQueryReportMetadataV2(HREPORTSTORE hReportStore, [MarshalAs(UnmanagedType.LPWStr)] string pszReportKey, out WER_REPORT_METADATA_V2 pReportMetadata);

		/// <summary>Provides a handle to a problem report.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HREPORT : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HREPORT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HREPORT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HREPORT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HREPORT NULL => new HREPORT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HREPORT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HREPORT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREPORT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORT(IntPtr h) => new HREPORT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HREPORT h1, HREPORT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HREPORT h1, HREPORT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HREPORT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a error report store.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HREPORTSTORE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HREPORTSTORE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HREPORTSTORE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HREPORTSTORE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HREPORTSTORE NULL => new HREPORTSTORE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HREPORTSTORE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HREPORTSTORE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREPORTSTORE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORTSTORE(IntPtr h) => new HREPORTSTORE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HREPORTSTORE h1, HREPORTSTORE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HREPORTSTORE h1, HREPORTSTORE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HREPORTSTORE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Specifies custom minidump information to be collected by the WerReportAddDump function.</summary>
		/// <remarks>
		/// <para>
		/// The flags specified in this structure have a direct correlation to flags passed in the MiniDumpCallback callback function (see
		/// MiniDumpWriteDump) when WER generates the dump file.
		/// </para>
		/// <para>
		/// If the minidump's callback input type is <c>ThreadCallback</c> (see the <c>CallbackType</c> member of MINIDUMP_CALLBACK_INPUT),
		/// the <c>ThreadWriteFlags</c> member of MINIDUMP_CALLBACK_OUTPUT is set to the flags specified in the
		/// <c>dwExceptionThreadFlags</c>, <c>dwExceptionThreadExFlags</c>, <c>dwOtherThreadFlags</c>, or <c>dwOtherThreadExFlags</c>
		/// members. If the callback is for the crashing thread, the <c>dwExceptionThreadFlags</c> or <c>dwExceptionThreadExFlags</c> flags
		/// are used; otherwise, the <c>dwOtherThreadFlags</c> or <c>dwOtherThreadExFlags</c> flags are used.
		/// </para>
		/// <para>
		/// If the callback input type is <c>ModuleCallback</c>, the <c>ModuleWriteFlags</c> member of MINIDUMP_CALLBACK_OUTPUT is set to the
		/// flags specified in the <c>dwPreferredModuleFlags</c> or <c>dwOtherModuleFlags</c> members. If the callback is for a module on the
		/// preferred modules list, the <c>dwPreferredModuleFlags</c> flags are used; otherwise, the <c>dwOtherModuleFlags</c> flags are used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/ns-werapi-_wer_dump_custom_options typedef struct
		// _WER_DUMP_CUSTOM_OPTIONS { DWORD dwSize; DWORD dwMask; DWORD dwDumpFlags; BOOL bOnlyThisThread; DWORD dwExceptionThreadFlags;
		// DWORD dwOtherThreadFlags; DWORD dwExceptionThreadExFlags; DWORD dwOtherThreadExFlags; DWORD dwPreferredModuleFlags; DWORD
		// dwOtherModuleFlags; WCHAR wzPreferredModuleList[WER_MAX_PREFERRED_MODULES_BUFFER]; } WER_DUMP_CUSTOM_OPTIONS, *PWER_DUMP_CUSTOM_OPTIONS;
		[PInvokeData("werapi.h", MSDNShortId = "6ea32573-ac1a-4f9b-b4ba-b5767927924f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_DUMP_CUSTOM_OPTIONS
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>
			/// <para>A mask that controls which options are valid in this structure. You can specify one or more of the following values:</para>
			/// <para>WER_DUMP_MASK_DUMPTYPE</para>
			/// <para>WER_DUMP_MASK_ONLY_THISTHREAD</para>
			/// <para>WER_DUMP_MASK_OTHER_MODULESFLAGS</para>
			/// <para>WER_DUMP_MASK_OTHERTHREADFLAGS</para>
			/// <para>WER_DUMP_MASK_OTHERTHREADFLAGS_EX</para>
			/// <para>WER_DUMP_MASK_PREFERRED_MODULE_LIST</para>
			/// <para>WER_DUMP_MASK_PREFERRED_MODULESFLAGS</para>
			/// <para>WER_DUMP_MASK_THREADFLAGS</para>
			/// <para>WER_DUMP_MASK_THREADFLAGS_EX</para>
			/// </summary>
			public WER_DUMP_MASK dwMask;

			/// <summary>
			/// <para>The type information to include in the minidump. You can specify one or more of the MINIDUMP_TYPE flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_DUMPTYPE.</para>
			/// </summary>
			public MINIDUMP_TYPE dwDumpFlags;

			/// <summary>
			/// If this member is <c>TRUE</c> and <c>dwMask</c> contains WER_DUMP_MASK_ONLY_THISTHREAD, the minidump is to be collected only
			/// for the calling thread.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool bOnlyThisThread;

			/// <summary>
			/// <para>The type of thread information to include in the minidump. You can specify one or more of the THREAD_WRITE_FLAGS flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_THREADFLAGS.</para>
			/// </summary>
			public THREAD_WRITE_FLAGS dwExceptionThreadFlags;

			/// <summary>
			/// <para>The type of thread information to include in the minidump. You can specify one or more of the THREAD_WRITE_FLAGS flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_OTHERTHREADFLAGS.</para>
			/// </summary>
			public THREAD_WRITE_FLAGS dwOtherThreadFlags;

			/// <summary>
			/// <para>The type of thread information to include in the minidump. You can specify one or more of the THREAD_WRITE_FLAGS flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_THREADFLAGS_EX.</para>
			/// </summary>
			public THREAD_WRITE_FLAGS dwExceptionThreadExFlags;

			/// <summary>
			/// <para>The type of thread information to include in the minidump. You can specify one or more of the THREAD_WRITE_FLAGS flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_OTHERTHREADFLAGS_EX.</para>
			/// </summary>
			public THREAD_WRITE_FLAGS dwOtherThreadExFlags;

			/// <summary>
			/// <para>
			/// The type of module information to include in the minidump for modules specified in the <c>wzPreferredModuleList</c> member.
			/// You can specify one or more of the MODULE_WRITE_FLAGS flags.
			/// </para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_PREFERRED_MODULESFLAGS.</para>
			/// </summary>
			public MODULE_WRITE_FLAGS dwPreferredModuleFlags;

			/// <summary>
			/// <para>The type of module information to include in the minidump. You can specify one or more of the MODULE_WRITE_FLAGS flags.</para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_OTHER_MODULESFLAGS.</para>
			/// </summary>
			public MODULE_WRITE_FLAGS dwOtherModuleFlags;

			/// <summary>
			/// <para>
			/// A list of module names (do not include the path) to which the <c>dwPreferredModuleFlags</c> flags apply. Each name must be
			/// null-terminated, and the list must be terminated with two null characters (for example, module1.dll\0module2.dll\0\0).
			/// </para>
			/// <para>
			/// To specify that all modules are preferred, set this member to "*\0\0". If you include * in a list with other module names,
			/// the * is ignored.
			/// </para>
			/// <para>This member is valid only if <c>dwMask</c> contains WER_DUMP_MASK_PREFERRED_MODULE_LIST.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string wzPreferredModuleList;

			/// <summary>A default instance with the size field set.</summary>
			public static readonly WER_DUMP_CUSTOM_OPTIONS Default = new WER_DUMP_CUSTOM_OPTIONS { dwSize = (uint)Marshal.SizeOf(typeof(WER_DUMP_CUSTOM_OPTIONS)) };
		}

		/// <summary>Contains exception information for the WerReportAddDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/ns-werapi-_wer_exception_information typedef struct
		// _WER_EXCEPTION_INFORMATION { PEXCEPTION_POINTERS pExceptionPointers; BOOL bClientPointers; } WER_EXCEPTION_INFORMATION, *PWER_EXCEPTION_INFORMATION;
		[PInvokeData("werapi.h", MSDNShortId = "4548068a-e654-40c9-9654-c5178575b42c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WER_EXCEPTION_INFORMATION
		{
			/// <summary>A pointer to an EXCEPTION_POINTERS structure.</summary>
			public IntPtr pExceptionPointers;

			/// <summary>
			/// A process (calling process) can provide error reporting functionality for another process (client process). If this member is
			/// <c>TRUE</c>, the exception pointer is located inside the address space of the client process. If this member is <c>FALSE</c>,
			/// the exception pointer is located inside the address space of the calling process.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool bClientPointers;
		}

		/// <summary>Contains information used by the WerReportCreate function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/ns-werapi-wer_report_information typedef struct _WER_REPORT_INFORMATION
		// { DWORD dwSize; HANDLE hProcess; WCHAR wzConsentKey[64]; WCHAR wzFriendlyEventName[128]; WCHAR wzApplicationName[128]; WCHAR
		// wzApplicationPath[MAX_PATH]; WCHAR wzDescription[512]; HWND hwndParent; } WER_REPORT_INFORMATION, *PWER_REPORT_INFORMATION;
		[PInvokeData("werapi.h", MSDNShortId = "3efe2b43-53ac-48e3-bc39-4a9fe6041fca")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_REPORT_INFORMATION
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>
			/// A handle to the process for which the report is being generated. If this member is <c>NULL</c>, this is the calling process.
			/// </summary>
			public HPROCESS hProcess;

			/// <summary>
			/// The name used to look up consent settings. If this member is empty, the default is the name specified by the pwzEventType
			/// parameter of WerReportCreate.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
			public string wzConsentKey;

			/// <summary>The display name. If this member is empty, the default is the name specified by pwzEventType parameter of WerReportCreate.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string wzFriendlyEventName;

			/// <summary>The name of the application. If this parameter is empty, the default is the base name of the image file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string wzApplicationName;

			/// <summary>The full path to the application.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string wzApplicationPath;

			/// <summary>
			/// A description of the problem. This description is displayed in <c>Problem Reports and Solutions</c> on Windows Vista or the
			/// problem reports pane of the <c>Action Center</c> on Windows 7.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
			public string wzDescription;

			/// <summary>A handle to the parent window.</summary>
			public HWND hwndParent;

			/// <summary>A default instance with the size field set.</summary>
			public static readonly WER_REPORT_INFORMATION Default = new WER_REPORT_INFORMATION { dwSize = (uint)Marshal.SizeOf(typeof(WER_REPORT_INFORMATION)) };
		}

		/// <summary>Contains information about an error report generated by Windows Error Reporting.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/werapi/ns-werapi-_wer_report_metadata_v2 typedef struct _WER_REPORT_METADATA_V2
		// { WER_REPORT_SIGNATURE Signature; GUID BucketId; GUID ReportId; FILETIME CreationTime; ULONGLONG SizeInBytes; WCHAR
		// CabId[MAX_PATH]; DWORD ReportStatus; GUID ReportIntegratorId; DWORD NumberOfFiles; DWORD SizeOfFileNames; WCHAR *FileNames; }
		// WER_REPORT_METADATA_V2, *PWER_REPORT_METADATA_V2;
		[PInvokeData("werapi.h", MSDNShortId = "037170B1-B2DF-402F-A9E6-48C7693C9A93")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_REPORT_METADATA_V2
		{
			/// <summary>
			/// A structure containing the signature of the report. The signature consists of the event name and event parameters present.
			/// </summary>
			public WER_REPORT_SIGNATURE Signature;

			/// <summary>
			/// A hash of the signature. Can be used to cross reference with other crash reports with the same signature (currently not implemented).
			/// </summary>
			public Guid BucketId;

			/// <summary>A locally unique identifier for the report.</summary>
			public Guid ReportId;

			/// <summary>A UTC time stamp of when the report was created.</summary>
			public FILETIME CreationTime;

			/// <summary>
			/// The size (on disk) of the individual report and its constituent files. This value only counts files directly contained in a report.
			/// </summary>
			public ulong SizeInBytes;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string CabId;

			/// <summary>The detailed status of the report. Use the ReportStatus decoder to track this bit-field.</summary>
			public uint ReportStatus;

			/// <summary>The integrator ID of the report.</summary>
			public Guid ReportIntegratorId;

			/// <summary>The number of data files included in the report.</summary>
			public uint NumberOfFiles;

			/// <summary>
			/// The total size of the file name fields, in count of <c>WCHAR</c> s, including the terminating character for each name and one
			/// more at the end of the record.
			/// </summary>
			public uint SizeOfFileNames;

			/// <summary>A pointer to hold the names of the files included in the report. It is in the format: FileName001\0FileName002\0\FileName003\0\0.</summary>
			public IntPtr _FileNames;

			/// <summary>The files included in the report.</summary>
			public IEnumerable<string> FileNames => _FileNames.ToStringEnum(CharSet.Unicode, 0, (int)SizeOfFileNames);
		}

		[PInvokeData("werapi.h", MSDNShortId = "037170B1-B2DF-402F-A9E6-48C7693C9A93")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_REPORT_PARAMETER
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
			public string Name;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string Value;
		}

		[PInvokeData("werapi.h", MSDNShortId = "037170B1-B2DF-402F-A9E6-48C7693C9A93")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WER_REPORT_SIGNATURE
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
			public string EventName;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			public WER_REPORT_PARAMETER[] Parameters;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HREPORT"/> that is disposed using <see cref="WerReportClose"/>.</summary>
		public class SafeHREPORT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHREPORT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHREPORT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHREPORT"/> class.</summary>
			private SafeHREPORT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHREPORT"/> to <see cref="HREPORT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORT(SafeHREPORT h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WerReportCloseHandle(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HREPORTSTORE"/> that is disposed using <see cref="WerCloseStoreClose"/>.</summary>
		public class SafeHREPORTSTORE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHREPORTSTORE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHREPORTSTORE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHREPORTSTORE"/> class.</summary>
			private SafeHREPORTSTORE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHREPORTSTORE"/> to <see cref="HREPORTSTORE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREPORTSTORE(SafeHREPORTSTORE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { WerStoreClose(handle); return true; }
		}
	}
}