namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary/>
	public const string SERVICE_SERVER = "LanmanServer";

	/// <summary/>
	public const string SERVICE_WORKSTATION = "LanmanWorkstation";

	/// <summary>Retrieves operating statistics for a service. Currently, only the workstation and server services are supported.</summary>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the server on which the function is to execute. If this parameter
	/// is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="Service">
	/// Pointer to a string that specifies the name of the service about which to get the statistics. Only the values
	/// <c>SERVICE_SERVER</c> and <c>SERVICE_WORKSTATION</c> are currently allowed.
	/// </param>
	/// <param name="Level">
	/// <para>Specifies the information level of the data. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Return statistics about a workstation or a server. The bufptr parameter points to a STAT_WORKSTATION_0 or a STAT_SERVER_0 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Options">This parameter must be zero.</param>
	/// <param name="Buffer">
	/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer
	/// is allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
	/// Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// No special group membership is required to obtain workstation statistics. Only members of the Administrators or Server Operators
	/// local group can successfully execute the <c>NetStatisticsGet</c> function on a remote server.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmstats/nf-lmstats-netstatisticsget NET_API_STATUS NET_API_FUNCTION
	// NetStatisticsGet( StrPtrAuto ServerName, StrPtrAuto Service, DWORD Level, DWORD Options, LPBYTE *Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmstats.h", MSDNShortId = "d0e51d8a-2f54-42ca-9759-0da82c1f0f55")]
	public static extern Win32Error NetStatisticsGet([Optional] string? ServerName, string Service, uint Level, [Optional] uint Options, out SafeNetApiBuffer Buffer);

	/// <summary>
	/// <para>Contains statistical information about the server.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmstats/ns-lmstats-_stat_server_0 typedef struct _STAT_SERVER_0 { DWORD
	// sts0_start; DWORD sts0_fopens; DWORD sts0_devopens; DWORD sts0_jobsqueued; DWORD sts0_sopens; DWORD sts0_stimedout; DWORD
	// sts0_serrorout; DWORD sts0_pwerrors; DWORD sts0_permerrors; DWORD sts0_syserrors; DWORD sts0_bytessent_low; DWORD
	// sts0_bytessent_high; DWORD sts0_bytesrcvd_low; DWORD sts0_bytesrcvd_high; DWORD sts0_avresponse; DWORD sts0_reqbufneed; DWORD
	// sts0_bigbufneed; } STAT_SERVER_0, *PSTAT_SERVER_0, *LPSTAT_SERVER_0;
	[PInvokeData("lmstats.h", MSDNShortId = "7eb4e4a9-f4db-4702-a4ad-2d8bfac9f9ce")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STAT_SERVER_0
	{
		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the time when statistics collection started (or when the statistics were last
		/// cleared). The value is stored as the number of seconds that have elapsed since 00:00:00, January 1, 1970, GMT. To calculate
		/// the length of time that statistics have been collected, subtract the value of this member from the present time.
		/// </para>
		/// </summary>
		public uint sts0_start;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the number of times a file is opened on a server. This includes the number of times
		/// named pipes are opened.
		/// </para>
		/// </summary>
		public uint sts0_fopens;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of times a server device is opened.</para>
		/// </summary>
		public uint sts0_devopens;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of server print jobs spooled.</para>
		/// </summary>
		public uint sts0_jobsqueued;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of times the server session started.</para>
		/// </summary>
		public uint sts0_sopens;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of times the server session automatically disconnected.</para>
		/// </summary>
		public uint sts0_stimedout;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of times the server sessions failed with an error.</para>
		/// </summary>
		public uint sts0_serrorout;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of server password violations.</para>
		/// </summary>
		public uint sts0_pwerrors;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of server access permission errors.</para>
		/// </summary>
		public uint sts0_permerrors;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the number of server system errors.</para>
		/// </summary>
		public uint sts0_syserrors;

		/// <summary>
		/// <para>Specifies the low-order DWORD of the number of server bytes sent to the network.</para>
		/// </summary>
		public uint sts0_bytessent_low;

		/// <summary>
		/// <para>Specifies the high-order DWORD of the number of server bytes sent to the network.</para>
		/// </summary>
		public uint sts0_bytessent_high;

		/// <summary>
		/// <para>Specifies the low-order DWORD of the number of server bytes received from the network.</para>
		/// </summary>
		public uint sts0_bytesrcvd_low;

		/// <summary>
		/// <para>Specifies the high-order DWORD of the number of server bytes received from the network.</para>
		/// </summary>
		public uint sts0_bytesrcvd_high;

		/// <summary>
		/// <para>Specifies a DWORD value that indicates the average server response time (in milliseconds).</para>
		/// </summary>
		public uint sts0_avresponse;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the number of times the server required a request buffer but failed to allocate one.
		/// This value indicates that the server parameters may need adjustment.
		/// </para>
		/// </summary>
		public uint sts0_reqbufneed;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the number of times the server required a big buffer but failed to allocate one. This
		/// value indicates that the server parameters may need adjustment.
		/// </para>
		/// </summary>
		public uint sts0_bigbufneed;
	}

	/// <summary>Contains statistical information about the specified workstation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/lmstats/ns-lmstats-stat_workstation_0~r1 typedef struct _STAT_WORKSTATION_0 {
	// LARGE_INTEGER StatisticsStartTime; LARGE_INTEGER BytesReceived; LARGE_INTEGER SmbsReceived; LARGE_INTEGER
	// PagingReadBytesRequested; LARGE_INTEGER NonPagingReadBytesRequested; LARGE_INTEGER CacheReadBytesRequested; LARGE_INTEGER
	// NetworkReadBytesRequested; LARGE_INTEGER BytesTransmitted; LARGE_INTEGER SmbsTransmitted; LARGE_INTEGER
	// PagingWriteBytesRequested; LARGE_INTEGER NonPagingWriteBytesRequested; LARGE_INTEGER CacheWriteBytesRequested; LARGE_INTEGER
	// NetworkWriteBytesRequested; DWORD InitiallyFailedOperations; DWORD FailedCompletionOperations; DWORD ReadOperations; DWORD
	// RandomReadOperations; DWORD ReadSmbs; DWORD LargeReadSmbs; DWORD SmallReadSmbs; DWORD WriteOperations; DWORD
	// RandomWriteOperations; DWORD WriteSmbs; DWORD LargeWriteSmbs; DWORD SmallWriteSmbs; DWORD RawReadsDenied; DWORD RawWritesDenied;
	// DWORD NetworkErrors; DWORD Sessions; DWORD FailedSessions; DWORD Reconnects; DWORD CoreConnects; DWORD Lanman20Connects; DWORD
	// Lanman21Connects; DWORD LanmanNtConnects; DWORD ServerDisconnects; DWORD HungSessions; DWORD UseCount; DWORD FailedUseCount;
	// DWORD CurrentCommands; } STAT_WORKSTATION_0, *PSTAT_WORKSTATION_0, *LPSTAT_WORKSTATION_0;
	[PInvokeData("lmstats.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STAT_WORKSTATION_0
	{
		/// <summary>
		/// Specifies the time statistics collection started. This member also indicates when statistics for the workstations were last
		/// cleared. The value is stored as the number of seconds elapsed since 00:00:00, January 1, 1970.
		/// </summary>
		public long StatisticsStartTime;

		/// <summary>Specifies the total number of bytes received by the workstation.</summary>
		public long BytesReceived;

		/// <summary>Specifies the total number of server message blocks (SMBs) received by the workstation.</summary>
		public long SmbsReceived;

		/// <summary>Specifies the total number of bytes that have been read by paging I/O requests.</summary>
		public long PagingReadBytesRequested;

		/// <summary>Specifies the total number of bytes that have been read by non-paging I/O requests.</summary>
		public long NonPagingReadBytesRequested;

		/// <summary>Specifies the total number of bytes that have been read by cache I/O requests.</summary>
		public long CacheReadBytesRequested;

		/// <summary>Specifies the total amount of bytes that have been read by disk I/O requests.</summary>
		public long NetworkReadBytesRequested;

		/// <summary>Specifies the total number of bytes transmitted by the workstation.</summary>
		public long BytesTransmitted;

		/// <summary>Specifies the total number of SMBs transmitted by the workstation.</summary>
		public long SmbsTransmitted;

		/// <summary>Specifies the total number of bytes that have been written by paging I/O requests.</summary>
		public long PagingWriteBytesRequested;

		/// <summary>Specifies the total number of bytes that have been written by non-paging I/O requests.</summary>
		public long NonPagingWriteBytesRequested;

		/// <summary>Specifies the total number of bytes that have been written by cache I/O requests.</summary>
		public long CacheWriteBytesRequested;

		/// <summary>Specifies the total number of bytes that have been written by disk I/O requests.</summary>
		public long NetworkWriteBytesRequested;

		/// <summary>Specifies the total number of network operations that failed to begin.</summary>
		public uint InitiallyFailedOperations;

		/// <summary>Specifies the total number of network operations that failed to complete.</summary>
		public uint FailedCompletionOperations;

		/// <summary>Specifies the total number of read operations initiated by the workstation.</summary>
		public uint ReadOperations;

		/// <summary>Specifies the total number of random access reads initiated by the workstation.</summary>
		public uint RandomReadOperations;

		/// <summary>Specifies the total number of read requests the workstation has sent to servers.</summary>
		public uint ReadSmbs;

		/// <summary>
		/// Specifies the total number of read requests the workstation has sent to servers that are greater than twice the size of the
		/// server's negotiated buffer size.
		/// </summary>
		public uint LargeReadSmbs;

		/// <summary>
		/// Specifies the total number of read requests the workstation has sent to servers that are less than 1/4 of the size of the
		/// server's negotiated buffer size.
		/// </summary>
		public uint SmallReadSmbs;

		/// <summary>Specifies the total number of write operations initiated by the workstation.</summary>
		public uint WriteOperations;

		/// <summary>Specifies the total number of random access writes initiated by the workstation.</summary>
		public uint RandomWriteOperations;

		/// <summary/>
		public uint WriteSmbs;

		/// <summary>
		/// Specifies the total number of write requests the workstation has sent to servers that are greater than twice the size of the
		/// server's negotiated buffer size.
		/// </summary>
		public uint LargeWriteSmbs;

		/// <summary>
		/// Specifies the total number of write requests the workstation has sent to servers that are less than 1/4 of the size of the
		/// server's negotiated buffer size.
		/// </summary>
		public uint SmallWriteSmbs;

		/// <summary/>
		public uint RawReadsDenied;

		/// <summary>Specifies the total number of raw write requests made by the workstation that have been denied.</summary>
		public uint RawWritesDenied;

		/// <summary>Specifies the total number of network errors received by the workstation.</summary>
		public uint NetworkErrors;

		/// <summary/>
		public uint Sessions;

		/// <summary>Specifies the number of times the workstation attempted to create a session but failed.</summary>
		public uint FailedSessions;

		/// <summary>Specifies the total number of connections that have failed.</summary>
		public uint Reconnects;

		/// <summary>Specifies the total number of connections to servers supporting the PCNET dialect that have succeeded.</summary>
		public uint CoreConnects;

		/// <summary>Specifies the total number of connections to servers supporting the LanManager 2.0 dialect that have succeeded.</summary>
		public uint Lanman20Connects;

		/// <summary>Specifies the total number of connections to servers supporting the LanManager 2.1 dialect that have succeeded.</summary>
		public uint Lanman21Connects;

		/// <summary>Specifies the total number of connections to servers supporting the NTLM dialect that have succeeded.</summary>
		public uint LanmanNtConnects;

		/// <summary>Specifies the number of times the workstation was disconnected by a network server.</summary>
		public uint ServerDisconnects;

		/// <summary>Specifies the total number of sessions that have expired on the workstation.</summary>
		public uint HungSessions;

		/// <summary>Specifies the total number of network connections established by the workstation.</summary>
		public uint UseCount;

		/// <summary>Specifies the total number of failed network connections for the workstation.</summary>
		public uint FailedUseCount;

		/// <summary>Specifies the number of current requests that have not been completed.</summary>
		public uint CurrentCommands;
	}
}