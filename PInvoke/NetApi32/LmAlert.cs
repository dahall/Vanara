using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>An administrator's intervention is required.</summary>
	public const string ALERT_ADMIN_EVENT = "ADMIN";

	/// <summary>An entry was added to the error log.</summary>
	public const string ALERT_ERRORLOG_EVENT = "ERRORLOG";

	/// <summary>A user or application received a broadcast message.</summary>
	public const string ALERT_MESSAGE_EVENT = "MESSAGE";

	/// <summary>A print job completed or a print error occurred.</summary>
	public const string ALERT_PRINT_EVENT = "PRINTING";

	/// <summary>An application or resource was used.</summary>
	public const string ALERT_USER_EVENT = "USER";

	/// <summary>Name of mailslot to send alert notifications</summary>
	public const string ALERTER_MAILSLOT = "\\\\.\\MAILSLOT\\Alerter";

	/// <summary>A bitmask describing the status of the print job.</summary>
	[PInvokeData("lmalert.h", MSDNShortId = "f2fd87bc-abde-43c0-b29d-d43cc5f038b8")]
	[Flags]
	public enum PRJOB
	{
		/// <summary>The print job is in the queue waiting to be scheduled.</summary>
		PRJOB_QS_QUEUED = 0,

		/// <summary>The print job is in the queue, but it has been paused. (When a job is paused, it cannot be scheduled.)</summary>
		PRJOB_QS_PAUSED = 1,

		/// <summary>The print job is in the process of being spooled.</summary>
		PRJOB_QS_SPOOLING = 2,

		/// <summary>The job is currently printing.</summary>
		PRJOB_QS_PRINTING = 3,

		/// <summary>The job has completed printing.</summary>
		PRJOB_COMPLETE = 0x4,

		/// <summary>The destination printer requires an operator's intervention.</summary>
		PRJOB_INTERV = 0x8,

		/// <summary>There is an error at the destination printer.</summary>
		PRJOB_ERROR = 0x10,

		/// <summary>The destination printer is offline.</summary>
		PRJOB_DESTOFFLINE = 0x20,

		/// <summary>The destination printer is paused.</summary>
		PRJOB_DESTPAUSED = 0x40,

		/// <summary>A printing alert should be raised.</summary>
		PRJOB_NOTIFY = 0x80,

		/// <summary>The destination printer is out of paper.</summary>
		PRJOB_DESTNOPAPER = 0x100,

		/// <summary>The printing job is being deleted.</summary>
		PRJOB_DELETED = 0x8000,
	}

	/// <summary>
	/// The <c>ALERT_OTHER_INFO</c> macro returns a pointer to the alert-specific data in an alert message. The data follows a STD_ALERT
	/// structure, and can be an ADMIN_OTHER_INFO, a PRINT_OTHER_INFO, or a USER_OTHER_INFO structure.
	/// </summary>
	/// <param name="x">Pointer to a <c>STD_ALERT</c> structure that was specified in a call to the NetAlertRaise function.</param>
	/// <remarks>
	/// <para>The <c>ALERT_OTHER_INFO</c> macro is defined as follows:</para>
	/// <para>
	/// See NetAlertRaise for a code sample that uses the <c>ALERT_OTHER_INFO</c> macro to retrieve a pointer to the
	/// <c>ADMIN_OTHER_INFO</c> structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/nf-lmalert-alert_other_info void ALERT_OTHER_INFO( x );
	[PInvokeData("lmalert.h", MSDNShortId = "e7bcc306-4b44-4230-96aa-a4717bb1fb11")]
	public static IntPtr ALERT_OTHER_INFO(IntPtr x) => x.Offset(Marshal.SizeOf(typeof(STD_ALERT)));

	/// <summary>
	/// The <c>ALERT_VAR_DATA</c> macro returns a pointer to the variable-length portion of an alert message. Variable-length data can
	/// follow an ADMIN_OTHER_INFO, a PRINT_OTHER_INFO, or a USER_OTHER_INFO structure.
	/// </summary>
	/// <param name="p">
	/// Pointer to an <c>ADMIN_OTHER_INFO</c>, a <c>PRINT_OTHER_INFO</c>, or a <c>USER_OTHER_INFO</c> structure that was specified in a
	/// call to the NetAlertRaise function or the NetAlertRaiseEx function.
	/// </param>
	/// <remarks>
	/// <para>The <c>ALERT_VAR_DATA</c> macro is defined as follows:</para>
	/// <para>
	/// See NetAlertRaise and NetAlertRaiseEx for code samples that use the <c>ALERT_VAR_DATA</c> macro to retrieve a pointer to the
	/// variable-length data in an alert message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/nf-lmalert-alert_var_data void ALERT_VAR_DATA( p );
	[PInvokeData("lmalert.h", MSDNShortId = "ff71fb3d-8c01-47ac-93f2-108b1f49e2da")]
	public static IntPtr ALERT_VAR_DATA<T>(IntPtr p) where T : struct => p.Offset(Marshal.SizeOf(typeof(T)));

	/// <summary>
	/// <para>[This function is not supported as of Windows Vista because the alerter service is not supported.]</para>
	/// <para>The <c>NetAlertRaise</c> function notifies all registered clients when a particular event occurs.</para>
	/// <para>
	/// To simplify sending an alert message, you can call the extended function NetAlertRaiseEx instead. <c>NetAlertRaiseEx</c> does not
	/// require that you specify a STD_ALERT structure.
	/// </para>
	/// </summary>
	/// <param name="AlertType">
	/// <para>
	/// A pointer to a constant string that specifies the alert class (type of alert) to raise. This parameter can be one of the
	/// following predefined values, or a user-defined alert class for network applications. The event name for an alert can be any text string.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ALERT_ADMIN_EVENT</term>
	/// <term>An administrator's intervention is required.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_ERRORLOG_EVENT</term>
	/// <term>An entry was added to the error log.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_MESSAGE_EVENT</term>
	/// <term>A user or application received a broadcast message.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_PRINT_EVENT</term>
	/// <term>A print job completed or a print error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_USER_EVENT</term>
	/// <term>An application or resource was used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Buffer">
	/// <para>
	/// A pointer to the data to send to the clients listening for the interrupting message. The data should begin with a fixed-length
	/// STD_ALERT structure followed by additional message data in one ADMIN_OTHER_INFO, ERRLOG_OTHER_INFO, PRINT_OTHER_INFO, or
	/// USER_OTHER_INFO structure. Finally, the buffer should include any required variable-length information. For more information, see
	/// the code sample in the following Remarks section.
	/// </para>
	/// <para>
	/// The calling application must allocate and free the memory for all structures and variable data. For more information, see Network
	/// Management Function Buffers.
	/// </para>
	/// </param>
	/// <param name="BufferSize">The size, in bytes, of the message buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>
	/// If the function fails, the return value is a system error code and a can be one of the following error codes. For a list of all
	/// possible error codes, see System Error Codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the AlertEventName parameter is NULL or an empty string, the Buffer parameter
	/// is NULL, or the BufferSize parameter is less than the size of the STD_ALERT structure plus the fixed size for the additional
	/// message data structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The request is not supported. This error is returned on Windows Vista and later since the Alerter service is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the <c>NetAlertRaise</c> function.</para>
	/// <para>
	/// The alerter service must be running on the client computer when you call the <c>NetAlertRaise</c> function, or the function fails
	/// with ERROR_FILE_NOT_FOUND.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to raise an administrative alert by calling the <c>NetAlertRaise</c> function and
	/// specifying STD_ALERT and ADMIN_OTHER_INFO structures. First, the sample calculates the size of the message buffer. Then it
	/// allocates the buffer with a call to the GlobalAlloc function. The code assigns values to the members of the <c>STD_ALERT</c> and
	/// the <c>ADMIN_OTHER_INFO</c> portions of the buffer. The sample retrieves a pointer to the <c>ADMIN_OTHER_INFO</c> structure by
	/// calling the ALERT_OTHER_INFO macro. It also retrieves a pointer to the variable data portion of the buffer by calling the
	/// ALERT_VAR_DATA macro. Finally, the code sample frees the memory allocated for the buffer with a call to the GlobalFree function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/nf-lmalert-netalertraise NET_API_STATUS NET_API_FUNCTION
	// NetAlertRaise( LPCWSTR AlertType, LPVOID Buffer, DWORD BufferSize );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmalert.h", MSDNShortId = "11367a72-c21d-4044-98cf-a7a30cc43a8b")]
	public static extern Win32Error NetAlertRaise([MarshalAs(UnmanagedType.LPWStr)] string AlertType, IntPtr Buffer, uint BufferSize);

	/// <summary>
	/// <para>[This function is not supported as of Windows Vista because the alerter service is not supported.]</para>
	/// <para>
	/// The <c>NetAlertRaiseEx</c> function notifies all registered clients when a particular event occurs. You can call this extended
	/// function to simplify the sending of an alert message because <c>NetAlertRaiseEx</c> does not require that you specify a STD_ALERT structure.
	/// </para>
	/// </summary>
	/// <param name="AlertType">
	/// <para>
	/// A pointer to a constant string that specifies the alert class (type of alert) to raise. This parameter can be one of the
	/// following predefined values, or a user-defined alert class for network applications. (The event name for an alert can be any text string.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ALERT_ADMIN_EVENT</term>
	/// <term>An administrator's intervention is required.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_ERRORLOG_EVENT</term>
	/// <term>An entry was added to the error log.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_MESSAGE_EVENT</term>
	/// <term>A user or application received a broadcast message.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_PRINT_EVENT</term>
	/// <term>A print job completed or a print error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ALERT_USER_EVENT</term>
	/// <term>An application or resource was used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="VariableInfo">
	/// <para>
	/// A pointer to the data to send to the clients listening for the interrupting message. The data should consist of one
	/// ADMIN_OTHER_INFO, ERRLOG_OTHER_INFO, PRINT_OTHER_INFO, or USER_OTHER_INFO structure followed by any required variable-length
	/// information. For more information, see the code sample in the following Remarks section.
	/// </para>
	/// <para>
	/// The calling application must allocate and free the memory for all structures and variable data. For more information, see Network
	/// Management Function Buffers.
	/// </para>
	/// </param>
	/// <param name="VariableInfoSize">The number of bytes of variable information in the buffer pointed to by the VariableInfo parameter.</param>
	/// <param name="ServiceName">A pointer to a constant string that specifies the name of the service raising the interrupting message.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>
	/// If the function fails, the return value is a system error code and a can be one of the following error codes. For a list of all
	/// possible error codes, see System Error Codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the AlertEventName parameter is NULL or an empty string, the ServiceName
	/// parameter is NULL or an empty string, the VariableInfo parameter is NULL, or the VariableInfoSize parameter is greater than 512
	/// minus the size of the STD_ALERT structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The request is not supported. This error is returned on Windows Vista and later since the Alerter service is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the <c>NetAlertRaiseEx</c> function.</para>
	/// <para>
	/// The alerter service must be running on the client computer when you call the <c>NetAlertRaiseEx</c> function, or the function
	/// fails with ERROR_FILE_NOT_FOUND.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to raise the following types of interrupting messages (alerts) by calling the
	/// <c>NetAlertRaiseEx</c> function:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>An administrative alert by specifying an ADMIN_OTHER_INFO structure</term>
	/// </item>
	/// <item>
	/// <term>A print alert by specifying a PRINT_OTHER_INFO structure</term>
	/// </item>
	/// <item>
	/// <term>A user alert by specifying a USER_OTHER_INFO structure</term>
	/// </item>
	/// </list>
	/// <para>
	/// In each instance the code assigns values to the members of the relevant alert information structure. Following this, the sample
	/// retrieves a pointer to the portion of the message buffer that follows the structure by calling the ALERT_VAR_DATA macro. The code
	/// also fills in the variable-length strings in this portion of the buffer. Finally, the sample calls <c>NetAlertRaiseEx</c> to send
	/// the alert.
	/// </para>
	/// <para>
	/// Note that the calling application must allocate and free the memory for all structures and variable-length data in an alert
	/// message buffer.
	/// </para>
	/// <para>
	/// To pass a user-defined structure and valid strings in a user alert, you must create an event message file and link it with your
	/// application. You must also register the application in the <c>EventMessageFile</c> subkey in the <c>EventLog</c> section of the
	/// registry. If you do not register the application, the user alert will contain the information you pass in the variable-length
	/// strings that follow the USER_OTHER_INFO structure. For more information about <c>EventMessageFile</c>, see Event Logging.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/nf-lmalert-netalertraiseex NET_API_STATUS NET_API_FUNCTION
	// NetAlertRaiseEx( LPCWSTR AlertType, LPVOID VariableInfo, DWORD VariableInfoSize, LPCWSTR ServiceName );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmalert.h", MSDNShortId = "9762f0d6-0022-4e05-b2d8-6223d7bbb2c8")]
	public static extern Win32Error NetAlertRaiseEx([MarshalAs(UnmanagedType.LPWStr)] string AlertType, IntPtr VariableInfo, uint VariableInfoSize, [MarshalAs(UnmanagedType.LPWStr)] string ServiceName);

	/// <summary>
	/// The <c>ADMIN_OTHER_INFO</c> structure contains error message information. The NetAlertRaise and NetAlertRaiseEx functions use the
	/// <c>ADMIN_OTHER_INFO</c> structure to specify information when raising an administrator's interrupting message.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Variable-length data follows the <c>ADMIN_OTHER_INFO</c> structure in the alert message buffer if you specify one or more strings
	/// in the <c>alrtad_numstrings</c> member. The calling application must allocate and free the memory for all structures and
	/// variable-length data in an alert message buffer.
	/// </para>
	/// <para>See NetAlertRaise and NetAlertRaiseEx for code samples that demonstrate how to raise an administrative alert.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/ns-lmalert-_admin_other_info typedef struct _ADMIN_OTHER_INFO { DWORD
	// alrtad_errcode; DWORD alrtad_numstrings; } ADMIN_OTHER_INFO, *PADMIN_OTHER_INFO, *LPADMIN_OTHER_INFO;
	[PInvokeData("lmalert.h", MSDNShortId = "43119dcf-7d04-4e3b-b1dc-20e814fbdc2f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADMIN_OTHER_INFO
	{
		/// <summary>Specifies the error code for the new message written to the message log.</summary>
		public uint alrtad_errcode;

		/// <summary>Specifies the number (0-9) of consecutive Unicode strings written to the message log.</summary>
		public uint alrtad_numstrings;
	}

	/// <summary>
	/// The <c>ERRLOG_OTHER_INFO</c> structure contains error log information. The NetAlertRaise and NetAlertRaiseEx functions use the
	/// <c>ERRLOG_OTHER_INFO</c> structure to specify information when adding a new entry to the error log.
	/// </summary>
	/// <remarks>
	/// The calling application must allocate and free the memory for all structures and variable-length data in an alert message buffer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/ns-lmalert-_errlog_other_info typedef struct _ERRLOG_OTHER_INFO {
	// DWORD alrter_errcode; DWORD alrter_offset; } ERRLOG_OTHER_INFO, *PERRLOG_OTHER_INFO, *LPERRLOG_OTHER_INFO;
	[PInvokeData("lmalert.h", MSDNShortId = "832ebe88-e1c4-4ce3-8057-922419b577f7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ERRLOG_OTHER_INFO
	{
		/// <summary>Specifies the error code that was written to the error log.</summary>
		public uint alrter_errcode;

		/// <summary>Specifies the offset for the new entry in the error log.</summary>
		public uint alrter_offset;
	}

	/// <summary>
	/// The <c>PRINT_OTHER_INFO</c> structure contains information about a print job. The NetAlertRaise and NetAlertRaiseEx functions use
	/// the <c>PRINT_OTHER_INFO</c> structure to specify information when a job has finished printing, or when a printer needs intervention.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Additional variable-length data follows the <c>PRINT_OTHER_INFO</c> structure in the alert message buffer. The information is in
	/// the form of contiguous null-terminated character strings, as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>String</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>computername</term>
	/// <term>The computer that submitted the print job.</term>
	/// </item>
	/// <item>
	/// <term>username</term>
	/// <term>The user who submitted the print job.</term>
	/// </item>
	/// <item>
	/// <term>queuename</term>
	/// <term>The print queue to which the job was submitted.</term>
	/// </item>
	/// <item>
	/// <term>destination</term>
	/// <term>The printer destination (device) to which the print job was routed.</term>
	/// </item>
	/// <item>
	/// <term>status</term>
	/// <term>The status of the print job.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The calling application must allocate and free the memory for all structures and variable-length data in an alert message buffer.
	/// </para>
	/// <para>See NetAlertRaiseEx for a code sample that demonstrates how to raise a print alert.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/ns-lmalert-_print_other_info typedef struct _PRINT_OTHER_INFO { DWORD
	// alrtpr_jobid; DWORD alrtpr_status; DWORD alrtpr_submitted; DWORD alrtpr_size; } PRINT_OTHER_INFO, *PPRINT_OTHER_INFO, *LPPRINT_OTHER_INFO;
	[PInvokeData("lmalert.h", MSDNShortId = "f2fd87bc-abde-43c0-b29d-d43cc5f038b8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINT_OTHER_INFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The identification number of the print job.</para>
		/// </summary>
		public uint alrtpr_jobid;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A bitmask describing the status of the print job.</para>
		/// <para>You can obtain the overall status of the job by checking PRJOB_QSTATUS (bits 0 and 1).</para>
		/// <para>Possible values for the print job status are listed in the Lmalert.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRJOB_QS_QUEUED 0</term>
		/// <term>The print job is in the queue waiting to be scheduled.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_QS_PAUSED 1</term>
		/// <term>The print job is in the queue, but it has been paused. (When a job is paused, it cannot be scheduled.)</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_QS_SPOOLING 2</term>
		/// <term>The print job is in the process of being spooled.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_QS_PRINTING 3</term>
		/// <term>The job is currently printing.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the print job is in the PRJOB_QS_PRINTING state, you can check bits 2 through 8 for the device's status (PRJOB_DEVSTATUS).
		/// Bit 15 is also meaningful.
		/// </para>
		/// <para>Possible values for the device's status are listed in the Lmalert.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PRJOB_COMPLETE 0x4</term>
		/// <term>The job has completed printing.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_INTERV 0x8</term>
		/// <term>The destination printer requires an operator's intervention.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_ERROR 0x10</term>
		/// <term>There is an error at the destination printer.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_DESTOFFLINE 0x20</term>
		/// <term>The destination printer is offline.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_DESTPAUSED 0x40</term>
		/// <term>The destination printer is paused.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_NOTIFY 0x80</term>
		/// <term>A printing alert should be raised.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_DESTNOPAPER 0x100</term>
		/// <term>The destination printer is out of paper.</term>
		/// </item>
		/// <item>
		/// <term>PRJOB_DELETED 0x8000</term>
		/// <term>The printing job is being deleted.</term>
		/// </item>
		/// </list>
		/// </summary>
		public PRJOB alrtpr_status;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The time at which the print job was submitted. This value is stored as the number of seconds that have elapsed since
		/// 00:00:00, January 1, 1970, GMT.
		/// </para>
		/// </summary>
		public uint alrtpr_submitted;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the print job.</para>
		/// </summary>
		public uint alrtpr_size;
	}

	/// <summary>
	/// The <c>STD_ALERT</c> structure contains the time and date when a significant event occurred. The structure also contains an alert
	/// class and the name of the application that is raising the alert message. You must specify the <c>STD_ALERT</c> structure when you
	/// send an alert message using the NetAlertRaise function.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>STD_ALERT</c> structure must be followed by one ADMIN_OTHER_INFO, ERRLOG_OTHER_INFO, PRINT_OTHER_INFO, or USER_OTHER_INFO
	/// structure. These structures can optionally be followed by variable-length data. The calling application must allocate the memory
	/// for all structures and variable-length data in an alert message buffer.
	/// </para>
	/// <para>
	/// See NetAlertRaise for a code sample that raises an administrative alert using a <c>STD_ALERT</c> structure and an
	/// ADMIN_OTHER_INFO structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/ns-lmalert-_std_alert typedef struct _STD_ALERT { DWORD
	// alrt_timestamp; WCHAR alrt_eventname[EVLEN + 1]; WCHAR alrt_servicename[SNLEN + 1]; } STD_ALERT, *PSTD_ALERT, *LPSTD_ALERT;
	[PInvokeData("lmalert.h", MSDNShortId = "daa4594f-e59e-4f05-8183-677bee4ea446")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STD_ALERT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The time and date of the event. This value is stored as the number of seconds that have elapsed since 00:00:00, January 1,
		/// 1970, GMT.
		/// </para>
		/// </summary>
		public uint alrt_timestamp;

		/// <summary>
		/// <para>Type: <c>WCHAR[EVLEN + 1]</c></para>
		/// <para>
		/// A Unicode string indicating the alert class (type of event). This parameter can be one of the following predefined values, or
		/// another alert class that you have defined for network applications. (The event name for an alert can be any text string.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ALERT_ADMIN_EVENT</term>
		/// <term>An administrator's intervention is required.</term>
		/// </item>
		/// <item>
		/// <term>ALERT_ERRORLOG_EVENT</term>
		/// <term>An entry was added to the error log.</term>
		/// </item>
		/// <item>
		/// <term>ALERT_MESSAGE_EVENT</term>
		/// <term>A user or application received a broadcast message.</term>
		/// </item>
		/// <item>
		/// <term>ALERT_PRINT_EVENT</term>
		/// <term>A print job completed or a print error occurred.</term>
		/// </item>
		/// <item>
		/// <term>ALERT_USER_EVENT</term>
		/// <term>An application or resource was used.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
		public string alrt_eventname;

		/// <summary>
		/// <para>Type: <c>WCHAR[SNLEN + 1]</c></para>
		/// <para>A Unicode string indicating the service application that is raising the alert message.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
		public string alrt_servicename;
	}

	/// <summary>
	/// The <c>USER_OTHER_INFO</c> structure contains user error code information. The NetAlertRaise and NetAlertRaiseEx functions use
	/// the <c>USER_OTHER_INFO</c> structure to specify information about an event or condition of interest to a user.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Additional variable-length data follows the <c>USER_OTHER_INFO</c> structure in the alert message buffer. The information is in
	/// the form of contiguous null-terminated character strings, as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>String</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>username</term>
	/// <term>The user who created the session.</term>
	/// </item>
	/// <item>
	/// <term>computername</term>
	/// <term>The computer that created the session.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The calling application must allocate and free the memory for all structures and variable-length data in an alert message buffer.
	/// </para>
	/// <para>See NetAlertRaiseEx for a code sample that demonstrates how to raise a user alert.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmalert/ns-lmalert-_user_other_info typedef struct _USER_OTHER_INFO { DWORD
	// alrtus_errcode; DWORD alrtus_numstrings; } USER_OTHER_INFO, *PUSER_OTHER_INFO, *LPUSER_OTHER_INFO;
	[PInvokeData("lmalert.h", MSDNShortId = "2f6bd906-fdab-410a-8856-4482e047371f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USER_OTHER_INFO
	{
		/// <summary>Specifies the error code for the new message in the message log.</summary>
		public uint alrtus_errcode;

		/// <summary>Specifies the number (0-9) of consecutive Unicode strings in the message log.</summary>
		public uint alrtus_numstrings;
	}
}