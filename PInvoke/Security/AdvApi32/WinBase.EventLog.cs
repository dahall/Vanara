namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary/>
	public const uint ELF_LOG_SIGNATURE = 0x654c664c;

	/// <summary>Flags used by <see cref="GetEventLogInformation(HEVENTLOG, EVENTLOG_INFO, IntPtr, uint, out uint)"/>.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "627e0af2-3ce6-47fe-89c6-d7c0483cb94b")]
	public enum EVENTLOG_INFO : uint
	{
		/// <summary>
		/// Indicate whether the specified log is full. The lpBuffer parameter will contain an <see cref="EVENTLOG_FULL_INFORMATION"/> structure.
		/// </summary>
		EVENTLOG_FULL_INFO = 0
	}

	/// <summary>Saves the specified event log to a backup file. The function does not clear the event log.</summary>
	/// <param name="hEventLog">A handle to the open event log. The OpenEventLog function returns this handle.</param>
	/// <param name="lpBackupFileName">The absolute or relative path of the backup file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The <c>BackupEventLog</c> function fails with the ERROR_PRIVILEGE_NOT_HELD error if the user does not have the SE_BACKUP_NAME privilege.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-backupeventloga BOOL BackupEventLogA( HANDLE hEventLog,
	// LPCSTR lpBackupFileName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "5cfd5bad-4401-4abd-9e81-5f139e4ecf73")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BackupEventLog(HEVENTLOG hEventLog, string lpBackupFileName);

	/// <summary>Clears the specified event log, and optionally saves the current copy of the log to a backup file.</summary>
	/// <param name="hEventLog">A handle to the event log to be cleared. The OpenEventLog function returns this handle.</param>
	/// <param name="lpBackupFileName">
	/// <para>The absolute or relative path of the backup file. If this file already exists, the function fails.</para>
	/// <para>If the lpBackupFileName parameter is <c>NULL</c>, the event log is not backed up.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The <c>ClearEventLog</c>
	/// function can fail if the event log is empty or the backup file already exists.
	/// </para>
	/// </returns>
	/// <remarks>After this function returns, any handles that reference the cleared event log cannot be used to read the log.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-cleareventloga BOOL ClearEventLogA( HANDLE hEventLog,
	// LPCSTR lpBackupFileName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "b66896f6-baee-43c4-9d9b-5663c164d092")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClearEventLog(HEVENTLOG hEventLog, [Optional] string? lpBackupFileName);

	/// <summary>Closes the specified event log.</summary>
	/// <param name="hEventLog">
	/// A handle to the event log to be closed. The OpenEventLog or OpenBackupEventLog function returns this handle.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-closeeventlog BOOL CloseEventLog( HANDLE hEventLog );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "cb98a0cf-8ee9-4d78-8508-efae1d43a91d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseEventLog(HEVENTLOG hEventLog);

	/// <summary>Closes the specified event log.</summary>
	/// <param name="hEventLog">A handle to the event log. The RegisterEventSource function returns this handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deregistereventsource BOOL DeregisterEventSource( HANDLE
	// hEventLog );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "f5d1f4b0-5320-4aec-a129-cafff6f1fed1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeregisterEventSource(HEVENTLOG hEventLog);

	/// <summary>Retrieves information about the specified event log.</summary>
	/// <param name="hEventLog">A handle to the event log. The OpenEventLog or RegisterEventSource function returns this handle.</param>
	/// <param name="dwInfoLevel">
	/// The level of event log information to return.
	/// <para>This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_FULL_INFO</term>
	/// <term>Indicate whether the specified log is full. The lpBuffer parameter will contain an <see cref="EVENTLOG_FULL_INFORMATION"/> structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpBuffer">
	/// An application-allocated buffer that receives the event log information. The format of this data depends on the value of the
	/// dwInfoLevel parameter.
	/// </param>
	/// <param name="cbBufSize">The size of the lpBuffer buffer, in bytes.</param>
	/// <param name="pcbBytesNeeded">
	/// The function sets this parameter to the required buffer size for the requested information, regardless of whether the function
	/// succeeds. Use this value if the function fails with <c>ERROR_INSUFFICIENT_BUFFER</c> to allocate a buffer of the correct size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-geteventloginformation BOOL GetEventLogInformation( HANDLE
	// hEventLog, DWORD dwInfoLevel, LPVOID lpBuffer, DWORD cbBufSize, LPDWORD pcbBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "627e0af2-3ce6-47fe-89c6-d7c0483cb94b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetEventLogInformation(HEVENTLOG hEventLog, EVENTLOG_INFO dwInfoLevel, IntPtr lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>Retrieves information about the specified event log.</summary>
	/// <param name="hEventLog">A handle to the event log. The OpenEventLog or RegisterEventSource function returns this handle.</param>
	/// <param name="lpBuffer">
	/// An application-allocated buffer that receives the event log information. The format of this data depends on the value of the
	/// dwInfoLevel parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-geteventloginformation BOOL GetEventLogInformation( HANDLE
	// hEventLog, DWORD dwInfoLevel, LPVOID lpBuffer, DWORD cbBufSize, LPDWORD pcbBytesNeeded );
	[PInvokeData("winbase.h", MSDNShortId = "627e0af2-3ce6-47fe-89c6-d7c0483cb94b")]
	public static bool GetEventLogInformation(HEVENTLOG hEventLog, out EVENTLOG_FULL_INFORMATION lpBuffer) => GetEventLogInformation(hEventLog, 0, out lpBuffer, sizeof(uint), out _);

	/// <summary>Retrieves the number of records in the specified event log.</summary>
	/// <param name="hEventLog">A handle to the open event log. The OpenEventLog or OpenBackupEventLog function returns this handle.</param>
	/// <param name="NumberOfRecords">A pointer to a variable that receives the number of records in the specified event log.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The oldest record in an event log is not necessarily record number 1. To determine the oldest record number in an event log, use
	/// the GetOldestEventLogRecord function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnumberofeventlogrecords BOOL
	// GetNumberOfEventLogRecords( HANDLE hEventLog, PDWORD NumberOfRecords );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "80cc8735-26a2-4ad3-a111-28f2c0c52e98")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNumberOfEventLogRecords(HEVENTLOG hEventLog, out uint NumberOfRecords);

	/// <summary>Retrieves the absolute record number of the oldest record in the specified event log.</summary>
	/// <param name="hEventLog">A handle to the open event log. The OpenEventLog or OpenBackupEventLog function returns this handle.</param>
	/// <param name="OldestRecord">
	/// A pointer to a variable that receives the absolute record number of the oldest record in the specified event log.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The oldest record in an event log is not necessarily record number 1. For more information, see Event Log Records.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Querying for Event Information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getoldesteventlogrecord BOOL GetOldestEventLogRecord(
	// HANDLE hEventLog, PDWORD OldestRecord );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "2f64f82b-a5f5-4701-844b-5979a0124414")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetOldestEventLogRecord(HEVENTLOG hEventLog, out uint OldestRecord);

	/// <summary>
	/// Enables an application to receive notification when an event is written to the specified event log. When the event is written to
	/// the log, the specified event object is set to the signaled state.
	/// </summary>
	/// <param name="hEventLog">A handle to an event log. The OpenEventLog function returns this handle.</param>
	/// <param name="hEvent">
	/// A handle to a manual-reset or auto-reset event object. Use the CreateEvent function to create the event object.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NotifyChangeEventLog</c> function does not work with remote handles. If the hEventLog parameter is the handle to an event
	/// log on a remote computer, <c>NotifyChangeEventLog</c> returns zero, and GetLastError returns <c>ERROR_INVALID_HANDLE</c>.
	/// </para>
	/// <para>
	/// If the thread is not waiting on the event when the system calls PulseEvent, the thread will not receive the notification.
	/// Therefore, you should create a separate thread to wait for notifications.
	/// </para>
	/// <para>
	/// The system will continue to notify you of changes until you close the handle to the event log. To close the event log, use the
	/// CloseEventLog or DeregisterEventSource function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Receiving Event Notification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-notifychangeeventlog BOOL NotifyChangeEventLog( HANDLE
	// hEventLog, HANDLE hEvent );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "12b9a7bf-2aad-48b7-8cfd-a72b353ba2b2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool NotifyChangeEventLog(HEVENTLOG hEventLog, Kernel32.SafeEventHandle hEvent);

	/// <summary>Opens a handle to a backup event log created by the BackupEventLog function.</summary>
	/// <param name="lpUNCServerName">
	/// The Universal Naming Convention (UNC) name of the remote server on which this operation is to be performed. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="lpFileName">The full path of the backup file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the backup event log.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the backup filename specifies a remote server, the lpUNCServerName parameter must be <c>NULL</c>.</para>
	/// <para>
	/// When this function is used on Windows Vista and later computers, only backup event logs that were saved with the
	/// <c>BackupEventLog</c> function on Windows Vista and later computers can be opened.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-openbackupeventloga HANDLE OpenBackupEventLogA( LPCSTR
	// lpUNCServerName, LPCSTR lpFileName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "cfef0912-9d35-44aa-a1d3-f9bb37213ce0")]
	public static extern SafeHEVENTLOG OpenBackupEventLog([Optional] string? lpUNCServerName, string lpFileName);

	/// <summary>Opens a handle to the specified event log.</summary>
	/// <param name="lpUNCServerName">
	/// The Universal Naming Convention (UNC) name of the remote server on which the event log is to be opened. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="lpSourceName">
	/// <para>The name of the log.</para>
	/// <para>
	/// If you specify a custom log and it cannot be found, the event logging service opens the <c>Application</c> log; however, there
	/// will be no associated message or category string file.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to an event log.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To close the handle to the event log, use the CloseEventLog function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Querying for Event Information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-openeventloga HANDLE OpenEventLogA( LPCSTR
	// lpUNCServerName, LPCSTR lpSourceName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "6cd8797a-aeaf-4603-b43c-b1ff45b6200a")]
	public static extern SafeHEVENTLOG OpenEventLog([Optional] string? lpUNCServerName, string lpSourceName);

	/// <summary>
	/// Reads the specified number of entries from the specified event log. The function can be used to read log entries in chronological
	/// or reverse chronological order.
	/// </summary>
	/// <param name="hEventLog">A handle to the event log to be read. The OpenEventLog function returns this handle.</param>
	/// <param name="dwReadFlags">
	/// <para>
	/// Use the following flag values to indicate how to read the log file. This parameter must include one of the following values (the
	/// flags are mutually exclusive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_SEEK_READ 0x0002</term>
	/// <term>
	/// Begin reading from the record specified in the dwRecordOffset parameter. This option may not work with large log files if the
	/// function cannot determine the log file's size. For details, see Knowledge Base article, 177199.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_SEQUENTIAL_READ 0x0001</term>
	/// <term>Read the records sequentially.</term>
	/// </item>
	/// </list>
	/// <para>
	/// You must specify one of the following flags to indicate the direction for successive read operations (the flags are mutually exclusive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_FORWARDS_READ 0x0004</term>
	/// <term>The log is read in chronological order (oldest to newest).</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_BACKWARDS_READ 0x0008</term>
	/// <term>The log is read in reverse chronological order (newest to oldest).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRecordOffset">
	/// The record number of the log-entry at which the read operation should start. This parameter is ignored unless dwReadFlags
	/// includes the <c>EVENTLOG_SEEK_READ</c> flag.
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// An application-allocated buffer that will receive one or more EVENTLOGRECORD structures. This parameter cannot be <c>NULL</c>,
	/// even if the nNumberOfBytesToRead parameter is zero.
	/// </para>
	/// <para>The maximum size of this buffer is 0x7ffff bytes.</para>
	/// </param>
	/// <param name="nNumberOfBytesToRead">
	/// The size of the lpBuffer buffer, in bytes. This function will read as many log entries as will fit in the buffer; the function
	/// will not return partial entries.
	/// </param>
	/// <param name="pnBytesRead">A pointer to a variable that receives the number of bytes read by the function.</param>
	/// <param name="pnMinNumberOfBytesNeeded">
	/// A pointer to a variable that receives the required size of the lpBuffer buffer. This value is valid only this function returns
	/// zero and GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>When this function returns successfully, the read position in the event log is adjusted by the number of records read.</para>
	/// <para>
	/// <c>Note</c> The configured file name for this source may also be the configured file name for other sources (several sources can
	/// exist as subkeys under a single log). Therefore, this function may return events that were logged by more than one source.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Querying for Event Information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-readeventloga BOOL ReadEventLogA( HANDLE hEventLog, DWORD
	// dwReadFlags, DWORD dwRecordOffset, LPVOID lpBuffer, DWORD nNumberOfBytesToRead, DWORD *pnBytesRead, DWORD
	// *pnMinNumberOfBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "10b37174-661a-4dc6-a7fe-752739494156")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadEventLog(HEVENTLOG hEventLog, EVENTLOG_READ dwReadFlags, uint dwRecordOffset, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint pnBytesRead, out uint pnMinNumberOfBytesNeeded);

	/// <summary>
	/// Reads the specified number of entries from the specified event log. The function can be used to read log entries in chronological
	/// or reverse chronological order.
	/// </summary>
	/// <param name="hEventLog">A handle to the event log to be read. The OpenEventLog function returns this handle.</param>
	/// <param name="dwReadFlags">
	/// <para>
	/// Use the following flag values to indicate how to read the log file. This parameter must include one of the following values (the
	/// flags are mutually exclusive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_SEEK_READ 0x0002</term>
	/// <term>
	/// Begin reading from the record specified in the dwRecordOffset parameter. This option may not work with large log files if the
	/// function cannot determine the log file's size. For details, see Knowledge Base article, 177199.
	/// </term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_SEQUENTIAL_READ 0x0001</term>
	/// <term>Read the records sequentially.</term>
	/// </item>
	/// </list>
	/// <para>
	/// You must specify one of the following flags to indicate the direction for successive read operations (the flags are mutually exclusive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_FORWARDS_READ 0x0004</term>
	/// <term>The log is read in chronological order (oldest to newest).</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_BACKWARDS_READ 0x0008</term>
	/// <term>The log is read in reverse chronological order (newest to oldest).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwRecordOffset">
	/// The record number of the log-entry at which the read operation should start. This parameter is ignored unless dwReadFlags
	/// includes the <c>EVENTLOG_SEEK_READ</c> flag.
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// An application-allocated buffer that will receive one or more EVENTLOGRECORD structures. This parameter cannot be <c>NULL</c>,
	/// even if the nNumberOfBytesToRead parameter is zero.
	/// </para>
	/// <para>The maximum size of this buffer is 0x7ffff bytes.</para>
	/// </param>
	/// <param name="nNumberOfBytesToRead">
	/// The size of the lpBuffer buffer, in bytes. This function will read as many log entries as will fit in the buffer; the function
	/// will not return partial entries.
	/// </param>
	/// <param name="pnBytesRead">A pointer to a variable that receives the number of bytes read by the function.</param>
	/// <param name="pnMinNumberOfBytesNeeded">
	/// A pointer to a variable that receives the required size of the lpBuffer buffer. This value is valid only this function returns
	/// zero and GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>When this function returns successfully, the read position in the event log is adjusted by the number of records read.</para>
	/// <para>
	/// <c>Note</c> The configured file name for this source may also be the configured file name for other sources (several sources can
	/// exist as subkeys under a single log). Therefore, this function may return events that were logged by more than one source.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Querying for Event Information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-readeventloga BOOL ReadEventLogA( HANDLE hEventLog, DWORD
	// dwReadFlags, DWORD dwRecordOffset, LPVOID lpBuffer, DWORD nNumberOfBytesToRead, DWORD *pnBytesRead, DWORD
	// *pnMinNumberOfBytesNeeded );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "10b37174-661a-4dc6-a7fe-752739494156")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadEventLog(HEVENTLOG hEventLog, EVENTLOG_READ dwReadFlags, uint dwRecordOffset, SafePEVENTLOGRECORD lpBuffer, uint nNumberOfBytesToRead, out uint pnBytesRead, out uint pnMinNumberOfBytesNeeded);

	/// <summary>
	/// <para>Retrieves a registered handle to the specified event log.</para>
	/// </summary>
	/// <param name="lpUNCServerName">
	/// <para>
	/// The Universal Naming Convention (UNC) name of the remote server on which this operation is to be performed. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="lpSourceName">
	/// <para>
	/// The name of the event source whose handle is to be retrieved. The source name must be a subkey of a log under the <c>Eventlog</c>
	/// registry key. Note that the <c>Security</c> log is for system use only.
	/// </para>
	/// <para>
	/// <c>Note</c> This string must not contain characters prohibited in XML Attributes, with the exception of XML Escape sequences such
	/// as <c>&amp;lt &amp;gl</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the event log.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>The function returns <c>ERROR_ACCESS_DENIED</c> if lpSourceName specifies the <c>Security</c> event log.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the source name cannot be found, the event logging service uses the <c>Application</c> log. Although events will be reported ,
	/// the events will not include descriptions because there are no message and category message files for looking up descriptions
	/// related to the event identifiers.
	/// </para>
	/// <para>To close the handle to the event log, use the DeregisterEventSource function.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Reporting an Event.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-registereventsourcea HANDLE RegisterEventSourceA( LPCSTR
	// lpUNCServerName, LPCSTR lpSourceName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "53706f83-6bc9-45d6-981c-bd0680d7bc08")]
	public static extern SafeHEVENTSOURCE RegisterEventSource([Optional] string? lpUNCServerName, string lpSourceName);

	/// <summary>Writes an entry at the end of the specified event log.</summary>
	/// <param name="hEventLog">
	/// <para>A handle to the event log. The RegisterEventSource function returns this handle.</para>
	/// <para>
	/// As of Windows XP with SP2, this parameter cannot be a handle to the <c>Security</c> log. To write an event to the <c>Security</c>
	/// log, use the AuthzReportSecurityEvent function.
	/// </para>
	/// </param>
	/// <param name="wType">
	/// <para>The type of event to be logged. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EVENTLOG_SUCCESS 0x0000</term>
	/// <term>Information event</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_AUDIT_FAILURE 0x0010</term>
	/// <term>Failure Audit event</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_AUDIT_SUCCESS 0x0008</term>
	/// <term>Success Audit event</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_ERROR_TYPE 0x0001</term>
	/// <term>Error event</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_INFORMATION_TYPE 0x0004</term>
	/// <term>Information event</term>
	/// </item>
	/// <item>
	/// <term>EVENTLOG_WARNING_TYPE 0x0002</term>
	/// <term>Warning event</term>
	/// </item>
	/// </list>
	/// <para>For more information about event types, see Event Types.</para>
	/// </param>
	/// <param name="wCategory">
	/// The event category. This is source-specific information; the category can have any value. For more information, see Event Categories.
	/// </param>
	/// <param name="dwEventID">
	/// The event identifier. The event identifier specifies the entry in the message file associated with the event source. For more
	/// information, see Event Identifiers.
	/// </param>
	/// <param name="lpUserSid">
	/// A pointer to the current user's security identifier. This parameter can be <c>NULL</c> if the security identifier is not required.
	/// </param>
	/// <param name="wNumStrings">
	/// The number of insert strings in the array pointed to by the lpStrings parameter. A value of zero indicates that no strings are present.
	/// </param>
	/// <param name="dwDataSize">
	/// The number of bytes of event-specific raw (binary) data to write to the log. If this parameter is zero, no event-specific data is present.
	/// </param>
	/// <param name="lpStrings">
	/// <para>
	/// A pointer to a buffer containing an array of null-terminated strings that are merged into the message before Event Viewer
	/// displays the string to the user. This parameter must be a valid pointer (or <c>NULL</c>), even if wNumStrings is zero. Each
	/// string is limited to 31,839 characters.
	/// </para>
	/// <para><c>Prior to Windows Vista:</c> Each string is limited to 32K characters.</para>
	/// </param>
	/// <param name="lpRawData">
	/// A pointer to the buffer containing the binary data. This parameter must be a valid pointer (or <c>NULL</c>), even if the
	/// dwDataSize parameter is zero.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero, indicating that the entry was written to the log.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError, which returns one of the
	/// following extended error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// One of the parameters is not valid. This error is returned on Windows Server 2003 if the message data to be logged is too large.
	/// This error is returned by the RPC server on Windows Server 2003 if the dwDataSize parameter is larger than 261,991 (0x3ff67).
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory resources are available to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BOUND</term>
	/// <term>
	/// The array bounds are invalid. This error is returned if the message data to be logged is too large. On Windows Vista and later,
	/// this error is returned if the dwDataSize parameter is larger than 61,440 (0xf000).
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_X_BAD_STUB_DATA</term>
	/// <term>
	/// The stub received bad data. This error is returned on Windows XP if the message data to be logged is too large. This error is
	/// returned by the RPC server on Windows XP, if the dwDataSize parameter is larger than 262,143 (0x3ffff).
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is used to log an event. The entry is written to the end of the configured log for the source identified by the
	/// hEventLog parameter. The <c>ReportEvent</c> function adds the time, the entry's length, and the offsets before storing the entry
	/// in the log. To enable the function to add the user name, you must supply the user's SID in the lpUserSid parameter.
	/// </para>
	/// <para>
	/// There are different size limits on the size of the message data that can be logged depending on the version of Windows used by
	/// both the client where the application is run and the server where the message is logged. The server is determined by the
	/// lpUNCServerName parameter passed to the RegisterEventSource function. Different errors are returned when the size limit is
	/// exceeded that depend on the version of Windows.
	/// </para>
	/// <para>
	/// If the string that you log contains %n, where n is an integer value (for example, %1), the event viewer treats it as an insertion
	/// string. Because an IPv6 address can contain this character sequence, you must provide a format specifier (!S!) to log an event
	/// message that contains an IPv6 address. This specifier tells the formatting code to use the string literally and not perform any
	/// further expansions (for example, "my IPv6 address is: %1!S!").
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Reporting an Event.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-reporteventa BOOL ReportEventA( HANDLE hEventLog, WORD
	// wType, WORD wCategory, DWORD dwEventID, PSID lpUserSid, WORD wNumStrings, DWORD dwDataSize, LPCSTR *lpStrings, LPVOID lpRawData );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "e39273c3-9e42-41a1-9ec1-1cdff2ab7b55")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReportEvent(HEVENTLOG hEventLog, EVENTLOG_TYPE wType, ushort wCategory, uint dwEventID, PSID lpUserSid, ushort wNumStrings, uint dwDataSize,
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 5)] string[] lpStrings, IntPtr lpRawData);

	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetEventLogInformation(HEVENTLOG hEventLog, uint dwInfoLevel, out EVENTLOG_FULL_INFORMATION lpBuffer, uint cbBufSize, out uint pcbBytesNeeded);

	/// <summary>Indicates whether the event log is full.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_eventlog_full_information typedef struct
	// _EVENTLOG_FULL_INFORMATION { DWORD dwFull; } EVENTLOG_FULL_INFORMATION, *LPEVENTLOG_FULL_INFORMATION;
	[PInvokeData("winbase.h", MSDNShortId = "3ca41d6b-51a6-4226-89be-ab2c37628289")]
	[StructLayout(LayoutKind.Sequential)]
	public struct EVENTLOG_FULL_INFORMATION
	{
		/// <summary>Indicates whether the event log is full. If the log is full, this member is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool dwFull;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HEVENTLOG"/> that is disposed using <see cref="DeregisterEventSource"/>.</summary>
	[AutoSafeHandle("DeregisterEventSource(handle)", typeof(HEVENTLOG))]
	public partial class SafeHEVENTSOURCE { }
}