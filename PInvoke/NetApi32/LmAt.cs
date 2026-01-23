namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>Flags used by AT structures.</summary>
	[PInvokeData("lmat.h", MSDNShortId = "eb0bf696-53ca-432a-b04c-5e0b6a61a0fd")]
	[Flags]
	public enum AtJobFlags : byte
	{
		/// <summary>
		/// If you set this flag, the job runs, and continues to run, on each day for which a corresponding bit is set in the DaysOfMonth
		/// member or the DaysOfWeek member. The job is not deleted after it executes.
		/// <para>
		/// If this flag is clear, the job runs only once for each bit set in these members. The job is deleted after it executes once.
		/// </para>
		/// </summary>
		JOB_RUN_PERIODICALLY = 0x01,

		/// <summary>
		/// If this flag is set, it indicates that the schedule service failed to successfully execute the job the last time it was
		/// scheduled to run.
		/// </summary>
		JOB_EXEC_ERROR = 0x02,

		/// <summary>
		/// If this flag is set, it indicates that the job is scheduled to execute on the current day; the value of the JobTime member is
		/// greater than the current time of day at the computer where the job is queued.
		/// </summary>
		JOB_RUNS_TODAY = 0x04,

		/// <summary>
		/// If you set this flag, the job executes at the first occurrence of JobTime member at the computer where the job is queued.
		/// <para>Setting this flag is equivalent to setting the bit for the current day in the DaysOfMonth member.</para>
		/// </summary>
		JOB_ADD_CURRENT_DATE = 0x08,

		/// <summary>If you set this flag, the job does not run interactively. If this flag is clear, the job runs interactively.</summary>
		JOB_NONINTERACTIVE = 0x10,

		/// <summary>Valid input flags.</summary>
		JOB_INPUT_FLAGS = (JOB_RUN_PERIODICALLY | JOB_ADD_CURRENT_DATE | JOB_NONINTERACTIVE),

		/// <summary>Valid output flags.</summary>
		JOB_OUTPUT_FLAGS = (JOB_RUN_PERIODICALLY | JOB_EXEC_ERROR | JOB_RUNS_TODAY | JOB_NONINTERACTIVE)
	}

	/// <summary>
	/// <para>[ <c>NetScheduleJobAdd</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
	/// <para>]</para>
	/// <para>
	/// The <c>NetScheduleJobAdd</c> function submits a job to run at a specified future time and date. This function requires that the
	/// schedule service be started on the computer to which the job is submitted.
	/// </para>
	/// </summary>
	/// <param name="Servername">
	/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
	/// If this parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="Buffer">
	/// A pointer to an AT_INFO structure describing the job to submit. For more information about scheduling jobs using different job
	/// properties, see the following Remarks section and Network Management Function Buffers.
	/// </param>
	/// <param name="JobId">
	/// A pointer that receives a job identifier for the newly submitted job. This entry is valid only if the function returns successfully.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Normally only members of the local Administrators group on the computer where the schedule job is being added can successfully
	/// execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote server, then
	/// only members of the local Administrators group on the remote server can successfully execute this function.
	/// </para>
	/// <para>
	/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
	/// Operators group can also successfully execute this function.
	/// </para>
	/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
	/// <para>
	/// The following are examples of how to schedule jobs using different properties supported by the <c>NetScheduleJobAdd</c> function.
	/// </para>
	/// <para>To schedule a job that executes once:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>DaysOfMonth</c> member of the AT_INFO structure to zero.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DaysOfWeek</c> member of the AT_INFO structure to zero.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>JobTime</c> member of the AT_INFO structure to the time the job should execute.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The job executes at the time specified by the <c>JobTime</c> member of the AT_INFO structure pointed to by the Buffer parameter.
	/// After the job executes, it is deleted.
	/// </para>
	/// <para>To schedule and delete a job that executes multiple times:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the appropriate bits in the <c>DaysOfMonth</c> member of the AT_INFO structure or</term>
	/// </item>
	/// <item>
	/// <term>Set the appropriate bits in the <c>DaysOfWeek</c> member of the AT_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>JobTime</c> member of the AT_INFO structure to the time the job should execute.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> You do not need to set both the <c>DaysOfMonth</c> and the <c>DaysOfWeek</c> members of the AT_INFO structure.</para>
	/// <para>
	/// The job executes at the time specified by the <c>JobTime</c> member of the AT_INFO structure pointed to by the Buffer parameter,
	/// once for each day set in the <c>DaysOfMonth</c> or <c>DaysOfWeek</c> members of the AT_INFO structure. After each job executes,
	/// the corresponding bit is cleared. When the last bit is cleared, the job is deleted.
	/// </para>
	/// <para>To schedule a job that executes periodically:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the appropriate bits in the <c>DaysOfMonth</c> member of the AT_INFO structure or</term>
	/// </item>
	/// <item>
	/// <term>Set the appropriate bits in the <c>DaysOfWeek</c> member of the AT_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>JobTime</c> member of the AT_INFO structure to the time the job should execute.</term>
	/// </item>
	/// <item>
	/// <term>Set the job submission flag JOB_RUN_PERIODICALLY in the <c>Flags</c> member of the AT_INFO structure.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> You do not need to set both the <c>DaysOfMonth</c> and the <c>DaysOfWeek</c> members of the AT_INFO structure.</para>
	/// <para>
	/// The job will execute periodically, at the time specified by the <c>JobTime</c> member of the AT_INFO structure pointed to by the
	/// Buffer parameter, on each day set in the <c>DaysOfMonth</c> or <c>DaysOfWeek</c> member of the AT_INFO structure. The job will
	/// not be deleted as a result of the repeated executions. The only way to delete the job is by an explicit call to the
	/// NetScheduleJobDel function.
	/// </para>
	/// <para>See the AT_INFO structure for a description of the <c>DaysOfWeek</c>, <c>DaysOfMonth</c>, and job property bitmasks.</para>
	/// <para>
	/// On Windows 2000, the earlier AT service and the Task Scheduler were combined. The Task Scheduler service was only accurate to the
	/// minute. Therefore, the <c>NetScheduleJobAdd</c> function only uses hours and minutes specified in the <c>JobTime</c> member of
	/// the AT_INFO structure when a job is scheduled to run.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, the precision for the Task Scheduler was increased to the second. Therefore, the
	/// <c>NetScheduleJobAdd</c> function uses only the hours, minutes, and seconds specified in the <c>JobTime</c> member of the AT_INFO
	/// structure when a job is scheduled to run.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/nf-lmat-netschedulejobadd NET_API_STATUS NET_API_FUNCTION
	// NetScheduleJobAdd( IN LPCWSTR Servername, IN LPBYTE Buffer, OUT LPDWORD JobId );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmat.h", MSDNShortId = "813d13ba-abe1-4b14-88c7-87ba88a42a3b")]
	public static extern Win32Error NetScheduleJobAdd([Optional] string? Servername, in AT_INFO Buffer, out uint JobId);

	/// <summary>
	/// <para>[ <c>NetScheduleJobDel</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
	/// <para>]</para>
	/// <para>
	/// The <c>NetScheduleJobDel</c> function deletes a range of jobs queued to run at a computer. This function requires that the
	/// schedule service be started at the computer to which the job deletion request is being sent.
	/// </para>
	/// </summary>
	/// <param name="Servername">
	/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
	/// If this parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="MinJobId">The minimum job identifier. Jobs with a job identifier smaller than MinJobId will not be deleted.</param>
	/// <param name="MaxJobId">The maximum job identifier. Jobs with a job identifier larger than MaxJobId will not be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Normally only members of the local Administrators group on the computer where the schedule job is being deleted can successfully
	/// execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote server, then
	/// only members of the local Administrators group on the server can successfully execute this function.
	/// </para>
	/// <para>
	/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
	/// Operators group can also successfully execute this function.
	/// </para>
	/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
	/// <para>Call the NetScheduleJobEnum function to retrieve the job identifier for one or more scheduled jobs.</para>
	/// <para>The <c>NetScheduleJobDel</c> function deletes all jobs whose job identifiers are in the range MinJobId through MaxJobId.</para>
	/// <para>
	/// To delete all scheduled jobs at the server, you can call <c>NetScheduleJobDel</c> specifying MinJobId equal to 0 and MaxJobId
	/// equal to – 1. To delete one job, specify the job's identifier for both the MinJobId parameter and the MaxJobId parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/nf-lmat-netschedulejobdel NET_API_STATUS NET_API_FUNCTION
	// NetScheduleJobDel( IN LPCWSTR Servername, IN DWORD MinJobId, IN DWORD MaxJobId );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmat.h", MSDNShortId = "5ae668ab-f51d-457e-a239-2ec16a0e5a55")]
	public static extern Win32Error NetScheduleJobDel([Optional] string? Servername, uint MinJobId, uint MaxJobId);

	/// <summary>
	/// <para>[ <c>NetScheduleJobEnum</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
	/// <para>]</para>
	/// <para>
	/// The <c>NetScheduleJobEnum</c> function lists the jobs queued on a specified computer. This function requires that the schedule
	/// service be started.
	/// </para>
	/// </summary>
	/// <param name="Servername">
	/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
	/// If this parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="PointerToBuffer">
	/// A pointer to the buffer that receives the data. The return information is an array of AT_ENUM structures. The buffer is allocated
	/// by the system and must be freed using a single call to the NetApiBufferFree function. Note that you must free the buffer even if
	/// the function fails with ERROR_MORE_DATA.
	/// </param>
	/// <param name="PrefferedMaximumLength">
	/// A value that indicates the preferred maximum length of the returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the
	/// function allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict
	/// the number of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// ERROR_MORE_DATA. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="EntriesRead">A pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="TotalEntries">
	/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="ResumeHandle">
	/// A pointer to a value that contains a resume handle which is used to continue a job enumeration. The handle should be zero on the
	/// first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, then no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Normally only members of the local Administrators group on the computer where the schedule job is being enumerated can
	/// successfully execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote
	/// server, then only members of the local Administrators group on the server can successfully execute this function.
	/// </para>
	/// <para>
	/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
	/// Operators group can also successfully execute this function.
	/// </para>
	/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
	/// <para>
	/// Each entry returned contains an AT_ENUM structure. The value of the <c>JobId</c> member can be used when calling functions that
	/// require a job identifier parameter, such as the NetScheduleJobDel function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/nf-lmat-netschedulejobenum NET_API_STATUS NET_API_FUNCTION
	// NetScheduleJobEnum( IN LPCWSTR Servername, OUT LPBYTE *PointerToBuffer, IN DWORD PrefferedMaximumLength, OUT LPDWORD EntriesRead,
	// OUT LPDWORD TotalEntries, IN OUT LPDWORD ResumeHandle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmat.h", MSDNShortId = "e3384414-6a15-4979-bed4-6f94f046474a")]
	public static extern Win32Error NetScheduleJobEnum([Optional] string? Servername, out SafeNetApiBuffer PointerToBuffer, uint PrefferedMaximumLength, out uint EntriesRead, out uint TotalEntries, ref uint ResumeHandle);

	/// <summary>
	/// <para>[ <c>NetScheduleJobGetInfo</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.</para>
	/// <para>]</para>
	/// <para>
	/// The <c>NetScheduleJobGetInfo</c> function retrieves information about a particular job queued on a specified computer. This
	/// function requires that the schedule service be started.
	/// </para>
	/// </summary>
	/// <param name="Servername">
	/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
	/// If this parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="JobId">A value that indicates the identifier of the job for which to retrieve information.</param>
	/// <param name="PointerToBuffer">
	/// A pointer to the buffer that receives the AT_INFO structure describing the specified job. This buffer is allocated by the system
	/// and must be freed using the NetApiBufferFree function. For more information, see Network Management Function Buffers and Network
	/// Management Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Normally only members of the local Administrators group on the computer where the schedule job is being enumerated can
	/// successfully execute this function. If the server name passed in the string pointed to by the Servername parameter is a remote
	/// server, then only members of the local Administrators group on the server can successfully execute this function.
	/// </para>
	/// <para>
	/// If the following registry value has the least significant bit set (for example, 0x00000001), then users belonging to the Server
	/// Operators group can also successfully execute this function.
	/// </para>
	/// <para><c>HKLM\System\CurrentControlSet\Control\Lsa\SubmitControl</c></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/nf-lmat-netschedulejobgetinfo NET_API_STATUS NET_API_FUNCTION
	// NetScheduleJobGetInfo( IN LPCWSTR Servername, IN DWORD JobId, OUT LPBYTE *PointerToBuffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmat.h", MSDNShortId = "44589715-edab-4737-9e49-6f491fd44c28")]
	public static extern Win32Error NetScheduleJobGetInfo([Optional] string? Servername, uint JobId, out SafeNetApiBuffer PointerToBuffer);

	/// <summary>
	/// <para>
	/// The <c>AT_ENUM</c> structure contains information about a submitted job. The NetScheduleJobEnum function uses this structure to
	/// enumerate and return information about an entire queue of submitted jobs.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// For more information about setting the bit flags to schedule jobs that execute once, jobs that execute multiple times, and jobs
	/// that execute periodically without deletion, see the NetScheduleJobAdd function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/ns-lmat-_at_enum typedef struct _AT_ENUM { DWORD JobId; DWORD_PTR
	// JobTime; DWORD DaysOfMonth; UCHAR DaysOfWeek; UCHAR Flags; StrPtrUni Command; } AT_ENUM, *PAT_ENUM, *LPAT_ENUM;
	[PInvokeData("lmat.h", MSDNShortId = "ed7c5171-b8aa-4a9a-8f31-4d914bcad0b1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AT_ENUM
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The job identifier of a submitted (queued) job.</para>
		/// </summary>
		public uint JobId;

		/// <summary>
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// A pointer to the time of day at which the job is scheduled to run. The time is the local time at a computer on which the
		/// schedule service is running; it is measured from midnight, and is expressed in milliseconds.
		/// </para>
		/// </summary>
		public IntPtr JobTime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags representing the days of the month. For each bit that is set, the scheduled job will run at the time
		/// specified by the <c>JobTime</c> member, on the corresponding day of the month. Bit 0 corresponds to the first day of the
		/// month, and so on.
		/// </para>
		/// <para>
		/// The value of the bitmask is zero if the job was scheduled to run only once, at the first occurrence specified in the
		/// <c>JobTime</c> member
		/// </para>
		/// </summary>
		public uint DaysOfMonth;

		/// <summary>
		/// <para>Type: <c>UCHAR</c></para>
		/// <para>
		/// A set of bit flags representing the days of the week. For each bit that is set, the scheduled job will run at the time
		/// specified by the <c>JobTime</c> member, on the corresponding day of the week. Bit 0 corresponds to Monday, and so on.
		/// </para>
		/// <para>
		/// The value of the bitmask is zero if the job was scheduled to run only once, at the first occurrence specified in the
		/// <c>JobTime</c> member.
		/// </para>
		/// </summary>
		public byte DaysOfWeek;

		/// <summary>
		/// <para>Type: <c>UCHAR</c></para>
		/// <para>A set of bit flags describing job properties. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_RUN_PERIODICALLY</term>
		/// <term>This flag is equal to its original value, that is, the value when the job was submitted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_EXEC_ERROR</term>
		/// <term>
		/// If this flag is set, it indicates that the schedule service failed to successfully execute the job the last time it was
		/// scheduled to run.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_RUNS_TODAY</term>
		/// <term>
		/// If this flag is set, it indicates that the job is scheduled to execute on the current day; the value of the JobTime member is
		/// greater than the current time of day at the computer where the job is queued.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_NONINTERACTIVE</term>
		/// <term>This flag is equal to its original value, that is, the value when the job was submitted.</term>
		/// </item>
		/// </list>
		/// </summary>
		public AtJobFlags Flags;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string that contains the name of the command, batch program, or binary file to execute.</para>
		/// </summary>
		public string Command;
	}

	/// <summary>
	/// <para>
	/// The <c>AT_INFO</c> structure contains information about a job. The NetScheduleJobAdd function uses the structure to specify
	/// information when scheduling a job. The NetScheduleJobGetInfo function uses the structure to retrieve information about a job that
	/// has already been submitted.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// For more information about scheduling jobs that execute once, jobs that execute multiple times, and jobs that execute
	/// periodically without deletion, see NetScheduleJobAdd.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmat/ns-lmat-_at_info typedef struct _AT_INFO { DWORD_PTR JobTime; DWORD
	// DaysOfMonth; UCHAR DaysOfWeek; UCHAR Flags; StrPtrUni Command; } AT_INFO, *PAT_INFO, *LPAT_INFO;
	[PInvokeData("lmat.h", MSDNShortId = "eb0bf696-53ca-432a-b04c-5e0b6a61a0fd")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct AT_INFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// A pointer to a value that indicates the time of day at which the job is scheduled to run. The time is the local time at a
		/// computer on which the schedule service is running; it is measured from midnight, and is expressed in milliseconds.
		/// </para>
		/// </summary>
		public IntPtr JobTime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags representing the days of the month. For each bit that is set, the scheduled job will run at the time
		/// specified by the <c>JobTime</c> member, on the corresponding day of the month. Bit 0 corresponds to the first day of the
		/// month, and so on.
		/// </para>
		/// <para>
		/// The value of the bitmask is zero if the job was scheduled to run only once, at the first occurrence specified by the
		/// <c>JobTime</c> member.
		/// </para>
		/// </summary>
		public uint DaysOfMonth;

		/// <summary>
		/// <para>Type: <c>UCHAR</c></para>
		/// <para>
		/// A set of bit flags representing the days of the week. For each bit that is set, the scheduled job will run at the time
		/// specified by the <c>JobTime</c> member, on the corresponding day of the week. Bit 0 corresponds to Monday, and so on.
		/// </para>
		/// <para>
		/// The value of the bitmask is zero if the job was scheduled to run only once, at the first occurrence specified by the
		/// <c>JobTime</c> member.
		/// </para>
		/// </summary>
		public byte DaysOfWeek;

		/// <summary>
		/// <para>Type: <c>UCHAR</c></para>
		/// <para>A set of bit flags describing job properties.</para>
		/// <para>When you submit a job using a call to the NetScheduleJobAdd function, you can specify one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_RUN_PERIODICALLY</term>
		/// <term>
		/// If you set this flag, the job runs, and continues to run, on each day for which a corresponding bit is set in the DaysOfMonth
		/// member or the DaysOfWeek member. The job is not deleted after it executes. If this flag is clear, the job runs only once for
		/// each bit set in these members. The job is deleted after it executes once.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_ADD_CURRENT_DATE</term>
		/// <term>
		/// If you set this flag, the job executes at the first occurrence of JobTime member at the computer where the job is queued.
		/// Setting this flag is equivalent to setting the bit for the current day in the DaysOfMonth member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_NONINTERACTIVE</term>
		/// <term>If you set this flag, the job does not run interactively. If this flag is clear, the job runs interactively.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When you call NetScheduleJobGetInfo to retrieve job information, the function can return one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_RUN_PERIODICALLY</term>
		/// <term>This flag is equal to its original value, that is, the value when the job was submitted.</term>
		/// </item>
		/// <item>
		/// <term>JOB_EXEC_ERROR</term>
		/// <term>
		/// If this flag is set, it indicates that the schedule service failed to successfully execute the job the last time it was
		/// scheduled to run.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_RUNS_TODAY</term>
		/// <term>
		/// If this flag is set, it indicates that the job is scheduled to execute on the current day; the value of the JobTime member is
		/// greater than the current time of day at the computer where the job is queued.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_NONINTERACTIVE</term>
		/// <term>This flag bit is equal to its original value, that is, the value when the job was submitted.</term>
		/// </item>
		/// </list>
		/// </summary>
		public AtJobFlags Flags;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string that contains the name of the command, batch program, or binary file to execute.</para>
		/// </summary>
		public string Command;
	}
}