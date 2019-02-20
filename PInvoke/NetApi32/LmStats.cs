using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		public const string SERVICE_SERVER = "LanmanServer";
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
		/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
		/// allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
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
		// NetStatisticsGet( LPTSTR ServerName, LPTSTR Service, DWORD Level, DWORD Options, LPBYTE *Buffer );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmstats.h", MSDNShortId = "d0e51d8a-2f54-42ca-9759-0da82c1f0f55")]
		public static extern Win32Error NetStatisticsGet([Optional] string ServerName, string Service, uint Level, [Optional] uint Options, out SafeNetApiBuffer Buffer);

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

		/// <summary>
		/// <para>Contains statistical information about the specified workstation.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmstats/ns-lmstats-_stat_workstation_0 typedef struct _STAT_WORKSTATION_0 {
		// DWORD stw0_start; DWORD stw0_numNCB_r; DWORD stw0_numNCB_s; DWORD stw0_numNCB_a; DWORD stw0_fiNCB_r; DWORD stw0_fiNCB_s; DWORD
		// stw0_fiNCB_a; DWORD stw0_fcNCB_r; DWORD stw0_fcNCB_s; DWORD stw0_fcNCB_a; DWORD stw0_sesstart; DWORD stw0_sessfailcon; DWORD
		// stw0_sessbroke; DWORD stw0_uses; DWORD stw0_usefail; DWORD stw0_autorec; DWORD stw0_bytessent_r_lo; DWORD stw0_bytessent_r_hi;
		// DWORD stw0_bytesrcvd_r_lo; DWORD stw0_bytesrcvd_r_hi; DWORD stw0_bytessent_s_lo; DWORD stw0_bytessent_s_hi; DWORD
		// stw0_bytesrcvd_s_lo; DWORD stw0_bytesrcvd_s_hi; DWORD stw0_bytessent_a_lo; DWORD stw0_bytessent_a_hi; DWORD stw0_bytesrcvd_a_lo;
		// DWORD stw0_bytesrcvd_a_hi; DWORD stw0_reqbufneed; DWORD stw0_bigbufneed; } STAT_WORKSTATION_0, *PSTAT_WORKSTATION_0, *LPSTAT_WORKSTATION_0;
		[PInvokeData("lmstats.h", MSDNShortId = "7a29fe54-fd15-499d-b255-f49025421861")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STAT_WORKSTATION_0
		{
			public uint stw0_start;
			public uint stw0_numNCB_r;
			public uint stw0_numNCB_s;
			public uint stw0_numNCB_a;
			public uint stw0_fiNCB_r;
			public uint stw0_fiNCB_s;
			public uint stw0_fiNCB_a;
			public uint stw0_fcNCB_r;
			public uint stw0_fcNCB_s;
			public uint stw0_fcNCB_a;
			public uint stw0_sesstart;
			public uint stw0_sessfailcon;
			public uint stw0_sessbroke;
			public uint stw0_uses;
			public uint stw0_usefail;
			public uint stw0_autorec;
			public uint stw0_bytessent_r_lo;
			public uint stw0_bytessent_r_hi;
			public uint stw0_bytesrcvd_r_lo;
			public uint stw0_bytesrcvd_r_hi;
			public uint stw0_bytessent_s_lo;
			public uint stw0_bytessent_s_hi;
			public uint stw0_bytesrcvd_s_lo;
			public uint stw0_bytesrcvd_s_hi;
			public uint stw0_bytessent_a_lo;
			public uint stw0_bytessent_a_hi;
			public uint stw0_bytesrcvd_a_lo;
			public uint stw0_bytesrcvd_a_hi;
			public uint stw0_reqbufneed;
			public uint stw0_bigbufneed;
		}
	}
}