using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		/// <summary>The information level to use to retrieve platform-specific information.</summary>
		[PInvokeData("lmwksta.h", MSDNShortId = "c705dadd-cf55-44d9-bf36-09e078112479")]
		public enum PLATFORM_ID
		{
			/// <summary>The MS-DOS platform.</summary>
			PLATFORM_ID_DOS = 300,

			/// <summary>The OS/2 platform.</summary>
			PLATFORM_ID_OS2 = 400,

			/// <summary>The Windows NT platform.</summary>
			PLATFORM_ID_NT = 500,

			/// <summary>The OSF platform.</summary>
			PLATFORM_ID_OSF = 600,

			/// <summary>The VMS platform.</summary>
			PLATFORM_ID_VMS = 700,
		}

		/// <summary>The <c>NetWkstaGetInfo</c> function returns information about the configuration of a workstation.</summary>
		/// <param name="servername">
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>100</term>
		/// <term>
		/// Return information about the workstation environment, including platform-specific information, the name of the domain and the
		/// local computer, and information concerning the operating system. The bufptr parameter points to a WKSTA_INFO_100 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>101</term>
		/// <term>
		/// In addition to level 100 information, return the path to the LANMAN directory. The bufptr parameter points to a WKSTA_INFO_101 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>102</term>
		/// <term>
		/// In addition to level 101 information, return the number of users who are logged on to the local computer. The bufptr parameter
		/// points to a WKSTA_INFO_102 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
		/// allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
		/// Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
		/// access is allowed or denied based on the ACL for the securable object. To enable anonymous access, the user Anonymous must be a
		/// member of the "Pre-Windows 2000 compatible access" group. This is because anonymous tokens do not include the Everyone group SID
		/// by default. If you call this function on a member server or workstation, all authenticated users can view the information.
		/// Anonymous access is also permitted if the EveryoneIncludesAnonymous policy setting allows anonymous access. Anonymous access is
		/// always permitted for level 100. If you call this function at level 101, authenticated users can view the information. Members of
		/// the Administrators, and the Server, System and Print Operator local groups can view information at levels 102 and 502. For more
		/// information about restricting anonymous access, see Security Requirements for the Network Management Functions. For more
		/// information on ACLs, ACEs, and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
		/// denied based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and
		/// members of the " Pre-Windows 2000 compatible access" group to view the information. By default, the "Pre-Windows 2000 compatible
		/// access" group includes Everyone as a member. This enables anonymous access to the information if the system allows anonymous
		/// access. If you call this function on a member server or workstation, all authenticated users can view the information. Anonymous
		/// access is also permitted if the RestrictAnonymous policy setting allows anonymous access.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information,see
		/// Using the Windows Headers.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about the configuration elements for a workstation using a
		/// call to the <c>NetWkstaGetInfo</c> function. The sample calls <c>NetWkstaGetInfo</c>, specifying information level 102 (
		/// WKSTA_INFO_102). If the call succeeds, the sample prints information about the workstation. Finally, the code sample frees the
		/// memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstagetinfo NET_API_STATUS NET_API_FUNCTION
		// NetWkstaGetInfo( LMSTR servername, DWORD level, OUT LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "08777069-1afd-4482-8090-c65ef0bec1ea")]
		public static extern Win32Error NetWkstaGetInfo([Optional] string servername, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>
		/// The <c>NetWkstaSetInfo</c> function configures a workstation with information that remains in effect after the system has been reinitialized.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>100</term>
		/// <term>
		/// Windows NT: Specifies information about a workstation environment, including platform-specific information, the names of the
		/// domain and the local computer, and information concerning the operating system. The buffer parameter points to a WKSTA_INFO_100
		/// structure. The wk100_computername and wk100_langroup fields of this structure cannot be set by calling this function. To set
		/// these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>101</term>
		/// <term>
		/// Windows NT: In addition to level 100 information, specifies the path to the LANMAN directory. The buffer parameter points to a
		/// WKSTA_INFO_101 structure. The wk101_computername and wk101_langroup fields of this structure cannot be set by calling this
		/// function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>102</term>
		/// <term>
		/// Windows NT: In addition to level 101 information, specifies the number of users who are logged on to the local computer. The
		/// buffer parameter points to a WKSTA_INFO_102 structure. The wk102_computername and wk102_langroup fields of this structure cannot
		/// be set by calling this function. To set these values, call SetComputerName/SetComputerNameEx or NetJoinDomain, respectively.
		/// </term>
		/// </item>
		/// <item>
		/// <term>502</term>
		/// <term>
		/// Windows NT: The buffer parameter points to a WKSTA_INFO_502 structure that contains information about the workstation environment.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Do not set levels 1010-1013, 1018, 1023, 1027, 1028, 1032, 1033, 1035, or 1041-1062.</para>
		/// </param>
		/// <param name="buffer">
		/// A pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// A pointer to a value that receives the index of the first member of the workstation information structure that causes the
		/// ERROR_INVALID_PARAMETER error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see
		/// the Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid. For more information, see the following Remarks section.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Only members of the Administrators group can successfully execute the <c>NetWkstaSetInfo</c> function on a remote server.</para>
		/// <para>
		/// The <c>NetWkstaSetInfo</c> function calls the workstation service on the local system or a remote system. Only a limited number
		/// of members of the WKSTA_INFO_502 structure can actually be changed using the <c>NetWkstaSetInfo</c> function. No errors are
		/// returned if a member is set that is ignored by the workstation service. The workstation service is primarily configured using
		/// settings in the registry.
		/// </para>
		/// <para>
		/// The NetWkstaUserSetInfo function can be used instead of the <c>NetWkstaSetInfo</c> function to set configuration information on
		/// the local system. The <c>NetWkstaUserSetInfo</c> function calls the Local Security Authority (LSA).
		/// </para>
		/// <para>
		/// If the <c>NetWkstaSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the workstation information structure that is invalid. (A workstation information structure begins with WKSTA_INFO_ and
		/// its format is specified by the level parameter.) The following table lists the values that can be returned in the parm_err
		/// parameter and the corresponding structure member that is in error. (The prefix wki*_ indicates that the member can begin with
		/// multiple prefixes, for example, wki100_ or wki402_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>WKSTA_PLATFORM_ID_PARMNUM</term>
		/// <term>wki*_platform_id</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_COMPUTERNAME_PARMNUM</term>
		/// <term>wki*_computername</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LANGROUP_PARMNUM</term>
		/// <term>wki*_langroup</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_VER_MAJOR_PARMNUM</term>
		/// <term>wki*_ver_major</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_VER_MINOR_PARMNUM</term>
		/// <term>wki*_ver_minor</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGGED_ON_USERS_PARMNUM</term>
		/// <term>wki*_logged_on_users</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LANROOT_PARMNUM</term>
		/// <term>wki*_lanroot</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGON_DOMAIN_PARMNUM</term>
		/// <term>wki*_logon_domain</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_LOGON_SERVER_PARMNUM</term>
		/// <term>wki*_logon_server</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARWAIT_PARMNUM</term>
		/// <term>wki*_char_wait</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARTIME_PARMNUM</term>
		/// <term>wki*_collection_time</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_CHARCOUNT_PARMNUM</term>
		/// <term>wki*_maximum_collection_count</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_KEEPCONN_PARMNUM</term>
		/// <term>wki*_keep_conn</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_KEEPSEARCH_PARMNUM</term>
		/// <term>wki*_keep_search</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXCMDS_PARMNUM</term>
		/// <term>wki*_max_cmds</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMWORKBUF_PARMNUM</term>
		/// <term>wki*_num_work_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXWRKCACHE_PARMNUM</term>
		/// <term>wki*_max_wrk_cache</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SESSTIMEOUT_PARMNUM</term>
		/// <term>wki*_sess_timeout</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZERROR_PARMNUM</term>
		/// <term>wki*_siz_error</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMALERTS_PARMNUM</term>
		/// <term>wki*_num_alerts</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMSERVICES_PARMNUM</term>
		/// <term>wki*_num_services</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_ERRLOGSZ_PARMNUM</term>
		/// <term>wki*_errlog_sz</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_PRINTBUFTIME_PARMNUM</term>
		/// <term>wki*_print_buf_time</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMCHARBUF_PARMNU</term>
		/// <term>wki*_num_char_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZCHARBUF_PARMNUM</term>
		/// <term>wki*_siz_char_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_WRKHEURISTICS_PARMNUM</term>
		/// <term>wki*_wrk_heuristics</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAILSLOTS_PARMNUM</term>
		/// <term>wki*_mailslots</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_MAXTHREADS_PARMNUM</term>
		/// <term>wki*_max_threads</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_SIZWORKBUF_PARMNUM</term>
		/// <term>wki*_siz_work_buf</term>
		/// </item>
		/// <item>
		/// <term>WKSTA_NUMDGRAMBUF_PARMNUM</term>
		/// <term>wki*_num_dgram_buf</term>
		/// </item>
		/// </list>
		/// <para>
		/// The workstation service parameter settings are stored in the registry, not in the LanMan.ini file used prveiously by LAN Manager.
		/// The <c>NetWkstaSetInfo</c> function does not change the values in the LanMan.ini file. When the workstation service is stopped
		/// and restarted, workstation parameters are reset to the default values specified in the registry (unless they are overwritten by
		/// command-line parameters). Values set by previous calls to <c>NetWkstaSetInfo</c> can be overwritten when workstation parameters
		/// are reset.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set the session time-out value associated with a workstation using a call to the
		/// <c>NetServerSetInfo</c> function. (The session time-out is the number of seconds the server waits before disconnecting an
		/// inactive session.) The code specifies information level 502 (WKSTA_INFO_502).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstasetinfo NET_API_STATUS NET_API_FUNCTION
		// NetWkstaSetInfo( LMSTR servername, DWORD level, LPBYTE buffer, OUT LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "d746b6c9-5ef1-4174-a84f-44e4e50200cd")]
		public static extern Win32Error NetWkstaSetInfo([Optional] string servername, uint level, IntPtr buffer, out uint parm_err);

		/// <summary>
		/// <para>
		/// [This function is obsolete. To change the default settings for transport protocols manually, use the <c>Local Area Connection
		/// Properties</c> dialog box in the <c>Network and Dial-Up Connections</c> folder.]
		/// </para>
		/// <para>Not supported.</para>
		/// <para>
		/// The <c>NetWkstaTransportAdd</c> function binds (or connects) the redirector to the transport. The redirector is the software on
		/// the client computer which generates file requests to the server computer.
		/// </para>
		/// </summary>
		/// <param name="servername">
		/// <para>
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </para>
		/// <para>This string must begin with \.</para>
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies workstation transport protocol information. The buf parameter points to a WKSTA_TRANSPORT_INFO_0 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first parameter that causes the ERROR_INVALID_PARAMETER error. If this
		/// parameter is <c>NULL</c>, the index is not returned on error.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter, which indicates what level of data structure information is available, is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Only members of the Administrators local group can successfully execute the <c>NetWkstaTransportAdd</c> function.</para>
		/// <para>
		/// If the <c>NetWkstaTransportAdd</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the
		/// member of the <c>WKSTA_TRANSPORT_INFO_0</c> structure that is invalid. The following table lists the values that can be returned
		/// in the parm_err parameter and the corresponding structure member that is in error.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>TRANSPORT_QUALITYOFSERVICE_PARMNUM</term>
		/// <term>wkti0_quality_of_service</term>
		/// </item>
		/// <item>
		/// <term>TRANSPORT_NAME_PARMNUM</term>
		/// <term>wkti0_transport_name</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstatransportadd NET_API_STATUS NET_API_FUNCTION
		// NetWkstaTransportAdd( LPTSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "016060ea-eae1-421f-b708-5c2ddd2000c1")]
		public static extern Win32Error NetWkstaTransportAdd([Optional] string servername, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// <para>
		/// [This function is obsolete. To change the default settings for transport protocols manually, use the <c>Local Area Connection
		/// Properties</c> dialog box in the <c>Network and Dial-Up Connections</c> folder.]
		/// </para>
		/// <para>Not supported.</para>
		/// <para>
		/// The <c>NetWkstaTransportDel</c> function unbinds the transport protocol from the redirector. (The redirector is the software on
		/// the client computer that generates file requests to the server computer.)
		/// </para>
		/// </summary>
		/// <param name="servername">
		/// <para>
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </para>
		/// <para>This string must begin with \.</para>
		/// </param>
		/// <param name="transportname">Pointer to a string that specifies the name of the transport protocol to disconnect from the redirector.</param>
		/// <param name="ucond">
		/// <para>
		/// Specifies the level of force to use when disconnecting the transport protocol from the redirector. This parameter can be one of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USE_NOFORCE</term>
		/// <term>Fail the disconnection if open files exist on the connection.</term>
		/// </item>
		/// <item>
		/// <term>USE_FORCE</term>
		/// <term>Fail the disconnection if open files exist on the connection.</term>
		/// </item>
		/// <item>
		/// <term>USE_LOTS_OF_FORCE</term>
		/// <term>Close any open files and delete the connection.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UseNotFound</term>
		/// <term>The network connection does not exist.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>Only members of the Administrators local group can successfully execute the <c>NetWkstaTransportDel</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstatransportdel NET_API_STATUS NET_API_FUNCTION
		// NetWkstaTransportDel( IN LMSTR servername, IN LMSTR transportname, IN DWORD ucond );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "6d0ec459-8d7b-41fe-96dd-203e6a42164f")]
		public static extern Win32Error NetWkstaTransportDel([Optional] string servername, string transportname, uint ucond);

		/// <summary>
		/// The <c>NetWkstaTransportEnum</c> function supplies information about transport protocols that are managed by the redirector,
		/// which is the software on the client computer that generates file requests to the server computer.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>The level of information requested for the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return workstation transport protocol information. The bufptr parameter points to an array of WKSTA_TRANSPORT_INFO_0 structures.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer
		/// is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
		/// function fails with <c>ERROR_MORE_DATA</c> or <c>NERR_BufTooSmall</c>.
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function allocates the
		/// amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes that
		/// the function returns. If the buffer size is insufficient to hold all entries, the function returns <c>ERROR_MORE_DATA</c> or
		/// <c>NERR_BufTooSmall</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// Note that applications should consider this value only as a hint.
		/// </param>
		/// <param name="resume_handle">The resume handle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>
		/// The level parameter, which indicates what level of data structure information is available, is invalid. This error is returned if
		/// the level parameter is specified as a value other than zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more parameters was invalid. This error is returned if the bufptr or the entriesread parameters are NULL pointers.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to process the request.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if a remote server was specified in servername parameter, and this request
		/// is not supported on the remote server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_BufTooSmall</term>
		/// <term>
		/// More entries are available. Specify a large enough buffer to receive all entries. This error code is defined in the Lmerr.h
		/// header file.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>No special group membership is required to successfully execute the <c>NetWkstaTransportEnum</c> function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstatransportenum NET_API_STATUS NET_API_FUNCTION
		// NetWkstaTransportEnum( LPTSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
		// totalentries, LPDWORD resume_handle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "08bd22a9-00a7-4563-9353-c070ca9b2500")]
		public static extern Win32Error NetWkstaTransportEnum([Optional] string servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

		/// <summary>
		/// The <c>NetWkstaUserEnum</c> function lists information about all users currently logged on to the workstation. This list includes
		/// interactive, service and batch logons.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of users currently logged on to the workstation. The bufptr parameter points to an array of WKSTA_USER_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the names of the current users and the domains accessed by the workstation. The bufptr parameter points to an array of
		/// WKSTA_USER_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
		/// allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
		/// function fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// Specifies the preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates
		/// the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes
		/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// Note that applications should consider this value only as a hint.
		/// </param>
		/// <param name="resumehandle">
		/// Pointer to a value that contains a resume handle which is used to continue an existing search. The handle should be zero on the
		/// first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, no resume handle is stored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Note that since the <c>NetWkstaUserEnum</c> function lists entries for service and batch logons, as well as for interactive
		/// logons, the function can return entries for users who have logged off a workstation. This can occur, for example, when a user
		/// calls a service that impersonates the user. In this instance, <c>NetWkstaUserEnum</c> returns an entry for the user until the
		/// service stops impersonating the user.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> If you call this function on a domain controller that is running Active Directory,
		/// access is allowed or denied based on the ACL for the securable object. To enable anonymous access, the user Anonymous must be a
		/// member of the "Pre-Windows 2000 compatible access" group. This is because anonymous tokens do not include the Everyone group SID
		/// by default. If you call this function on a member server or workstation, all authenticated users can view the information.
		/// Anonymous access is also permitted if the RestrictAnonymous policy setting permits anonymous access. If the RestrictAnonymous
		/// policy setting does not permit anonymous access, only an administrator can successfully execute the function. Members of the
		/// Administrators, and the Server, System and Print Operator local groups can also view information. For more information about
		/// restricting anonymous access, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs,
		/// and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// <c>Windows 2000:</c> If you call this function on a domain controller that is running Active Directory, access is allowed or
		/// denied based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and
		/// members of the " Pre-Windows 2000 compatible access" group to view the information. By default, the "Pre-Windows 2000 compatible
		/// access" group includes Everyone as a member. This enables anonymous access to the information if the system allows anonymous
		/// access. If you call this function on a member server or workstation, all authenticated users can view the information. Anonymous
		/// access is also permitted if the RestrictAnonymous policy setting allows anonymous access.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information,see
		/// Using the Windows Headers.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to list information about all users currently logged on to a workstation using a call
		/// to the <c>NetWkstaUserEnum</c> function. The sample calls <c>NetWkstaUserEnum</c>, specifying information level 0 (
		/// WKSTA_USER_INFO_0). The sample loops through the entries and prints the names of the users logged on to a workstation. Finally,
		/// the code sample frees the memory allocated for the information buffer, and prints the total number of users enumerated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstauserenum NET_API_STATUS NET_API_FUNCTION
		// NetWkstaUserEnum( LMSTR servername, IN DWORD level, LPBYTE *bufptr, IN DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
		// totalentries, LPDWORD resumehandle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "42eaeb70-3ce8-4eae-b20b-4729db90a7ef")]
		public static extern Win32Error NetWkstaUserEnum([Optional] string servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resumehandle);

		/// <summary>
		/// The <c>NetWkstaUserGetInfo</c> function returns information about the currently logged-on user. This function must be called in
		/// the context of the logged-on user.
		/// </summary>
		/// <param name="reserved">This parameter must be set to <c>NULL</c>.</param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the name of the user currently logged on to the workstation. The bufptr parameter points to a WKSTA_USER_INFO_0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return information about the workstation, including the name of the current user and the domains accessed by the workstation. The
		/// bufptr parameter points to a WKSTA_USER_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1101</term>
		/// <term>Return domains browsed by the workstation. The bufptr parameter points to a WKSTA_USER_INFO_1101 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the buffer that receives the data. The format of this data depends on the value of the bufptr parameter. This buffer
		/// is allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
		/// Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// The system ran out of memory resources. Either the network manager configuration is incorrect, or the program is running on a
		/// system with insufficient memory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetWkstaUserGetInfo</c> function only works locally.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about the currently logged-on user using a call to the
		/// <c>NetWkstaUserGetInfo</c> function. The sample calls <c>NetWkstaUserGetInfo</c>, specifying information level 1 (
		/// WKSTA_USER_INFO_1). If the call succeeds, the sample prints information about the logged-on user. Finally, the sample frees the
		/// memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstausergetinfo NET_API_STATUS NET_API_FUNCTION
		// NetWkstaUserGetInfo( LMSTR reserved, DWORD level, OUT LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "25ec7a49-fd26-4105-823b-a257a57f724e")]
		public static extern Win32Error NetWkstaUserGetInfo([Optional] string reserved, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>
		/// The <c>NetWkstaUserSetInfo</c> function sets the user-specific information about the configuration elements for a workstation.
		/// </summary>
		/// <param name="reserved">This parameter must be set to zero.</param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the workstation, including the name of the current user and the domains accessed by the workstation.
		/// The buf parameter points to a WKSTA_USER_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1101</term>
		/// <term>Specifies domains browsed by the workstation. The buf parameter points to a WKSTA_USER_INFO_1101 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first parameter that causes the ERROR_INVALID_PARAMETER error. If this
		/// parameter is <c>NULL</c>, the index is not returned on error.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>NetWkstaUserSetInfo</c> function only works locally. Administrator group membership is required.</para>
		/// <para>
		/// Domain names in the <c>wkui1101_oth_domains</c> member of the WKSTA_USER_INFO_1101 structure are separated by spaces. An empty
		/// list is valid. A <c>NULL</c> pointer means to leave the member unmodified. The <c>wkui1101_oth_domains</c> member cannot be set
		/// with MS-DOS. When setting this element, <c>NetWkstaUserSetInfo</c> rejects the request if the name list was invalid or if a name
		/// could not be added to one or more of the network adapters managed by the system.
		/// </para>
		/// <para>
		/// If the <c>NetWkstaUserSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the
		/// member of the workstation user information structure that is invalid. (A workstation user information structure begins with
		/// WKSTA_USER_INFO_ and its format is specified by the level parameter.) The following table lists the value that can be returned in
		/// the parm_err parameter and the corresponding structure member that is in error. (The prefix wkui*_ indicates that the member can
		/// begin with multiple prefixes, for example, wkui0_ or wkui1_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>WKSTA_OTH_DOMAINS_PARMNUM</term>
		/// <term>wkui*_oth_domains</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set user-specific information for a workstation using a call to the
		/// <c>NetWkstaUserSetInfo</c> function, specifying information level 1101 ( WKSTA_USER_INFO_1101).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/nf-lmwksta-netwkstausersetinfo NET_API_STATUS NET_API_FUNCTION
		// NetWkstaUserSetInfo( LMSTR reserved, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("lmwksta.h", MSDNShortId = "d48667a3-5ae9-4a7d-9af6-14f08835940d")]
		public static extern Win32Error NetWkstaUserSetInfo([Optional] string reserved, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// The <c>WKSTA_INFO_100</c> structure contains information about a workstation environment, including platform-specific
		/// information, the names of the domain and the local computer, and information concerning the operating system.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_info_100 typedef struct _WKSTA_INFO_100 { DWORD
		// wki100_platform_id; LMSTR wki100_computername; LMSTR wki100_langroup; DWORD wki100_ver_major; DWORD wki100_ver_minor; }
		// WKSTA_INFO_100, *PWKSTA_INFO_100, *LPWKSTA_INFO_100;
		[PInvokeData("lmwksta.h", MSDNShortId = "c705dadd-cf55-44d9-bf36-09e078112479")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_100
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The information level to use to retrieve platform-specific information.</para>
			/// <para>Possible values for this member are listed in the Lmcons.h header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PLATFORM_ID_DOS 300</term>
			/// <term>The MS-DOS platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OS2 400</term>
			/// <term>The OS/2 platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_NT 500</term>
			/// <term>The Windows NT platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OSF 600</term>
			/// <term>The OSF platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_VMS 700</term>
			/// <term>The VMS platform.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PLATFORM_ID wki100_platform_id;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the local computer.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki100_computername;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the domain to which the computer belongs.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki100_langroup;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The major version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki100_ver_major;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The minor version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki100_ver_minor;
		}

		/// <summary>
		/// The <c>WKSTA_INFO_101</c> structure contains information about a workstation environment, including platform-specific
		/// information, the name of the domain and the local computer, and information concerning the operating system.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_info_101 typedef struct _WKSTA_INFO_101 { DWORD
		// wki101_platform_id; LMSTR wki101_computername; LMSTR wki101_langroup; DWORD wki101_ver_major; DWORD wki101_ver_minor; LMSTR
		// wki101_lanroot; } WKSTA_INFO_101, *PWKSTA_INFO_101, *LPWKSTA_INFO_101;
		[PInvokeData("lmwksta.h", MSDNShortId = "2b692d40-6229-45ef-9ec6-ee464bba0696")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_101
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The information level to use to retrieve platform-specific information.</para>
			/// <para>Possible values for this member are listed in the Lmcons.h header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PLATFORM_ID_DOS 300</term>
			/// <term>The MS-DOS platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OS2 400</term>
			/// <term>The OS/2 platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_NT 500</term>
			/// <term>The Windows NT platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OSF 600</term>
			/// <term>The OSF platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_VMS 700</term>
			/// <term>The VMS platform.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PLATFORM_ID wki101_platform_id;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the local computer.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki101_computername;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the domain to which the computer belongs.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki101_langroup;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The major version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki101_ver_major;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The minor version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki101_ver_minor;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string that contains the path to the LANMAN directory.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki101_lanroot;
		}

		public struct WKSTA_INFO_1010
		{
			public uint wki1010_char_wait;
		}

		public struct WKSTA_INFO_1011
		{
			public uint wki1011_collection_time;
		}

		public struct WKSTA_INFO_1012
		{
			public uint wki1012_maximum_collection_count;
		}

		public struct WKSTA_INFO_1013
		{
			public uint wki1013_keep_conn;
		}

		public struct WKSTA_INFO_1018
		{
			public uint wki1018_sess_timeout;
		}

		/// <summary>
		/// The <c>WKSTA_INFO_102</c> structure contains information about a workstation environment, including platform-specific
		/// information, the name of the domain and the local computer, and information concerning the operating system.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_info_102 typedef struct _WKSTA_INFO_102 { DWORD
		// wki102_platform_id; LMSTR wki102_computername; LMSTR wki102_langroup; DWORD wki102_ver_major; DWORD wki102_ver_minor; LMSTR
		// wki102_lanroot; DWORD wki102_logged_on_users; } WKSTA_INFO_102, *PWKSTA_INFO_102, *LPWKSTA_INFO_102;
		[PInvokeData("lmwksta.h", MSDNShortId = "01607fb5-c433-439c-aaaa-3736697f7c07")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_102
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The information level to use to retrieve platform-specific information.</para>
			/// <para>Possible values for this member are listed in the Lmcons.h header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PLATFORM_ID_DOS 300</term>
			/// <term>The MS-DOS platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OS2 400</term>
			/// <term>The OS/2 platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_NT 500</term>
			/// <term>The Windows NT platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_OSF 600</term>
			/// <term>The OSF platform.</term>
			/// </item>
			/// <item>
			/// <term>PLATFORM_ID_VMS 700</term>
			/// <term>The VMS platform.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PLATFORM_ID wki102_platform_id;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the local computer.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki102_computername;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string specifying the name of the domain to which the computer belongs.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki102_langroup;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The major version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki102_ver_major;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The minor version number of the operating system running on the computer.</para>
			/// </summary>
			public uint wki102_ver_minor;

			/// <summary>
			/// <para>Type: <c>LMSTR</c></para>
			/// <para>A pointer to a string that contains the path to the LANMAN directory.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wki102_lanroot;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of users who are logged on to the local computer.</para>
			/// </summary>
			public uint wki102_logged_on_users;
		}

		public struct WKSTA_INFO_1023
		{
			public uint wki1023_siz_char_buf;
		}

		public struct WKSTA_INFO_1027
		{
			public uint wki1027_errlog_sz;
		}

		public struct WKSTA_INFO_1028
		{
			public uint wki1028_print_buf_time;
		}

		public struct WKSTA_INFO_1032
		{
			public uint wki1032_wrk_heuristics;
		}

		public struct WKSTA_INFO_1033
		{
			public uint wki1033_max_threads;
		}

		public struct WKSTA_INFO_1041
		{
			public uint wki1041_lock_quota;
		}

		public struct WKSTA_INFO_1042
		{
			public uint wki1042_lock_increment;
		}

		public struct WKSTA_INFO_1043
		{
			public uint wki1043_lock_maximum;
		}

		public struct WKSTA_INFO_1044
		{
			public uint wki1044_pipe_increment;
		}

		public struct WKSTA_INFO_1045
		{
			public uint wki1045_pipe_maximum;
		}

		public struct WKSTA_INFO_1046
		{
			public uint wki1046_dormant_file_limit;
		}

		public struct WKSTA_INFO_1047
		{
			public uint wki1047_cache_file_timeout;
		}

		public struct WKSTA_INFO_1048
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1048_use_opportunistic_locking;
		}

		public struct WKSTA_INFO_1049
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1049_use_unlock_behind;
		}

		public struct WKSTA_INFO_1050
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1050_use_close_behind;
		}

		public struct WKSTA_INFO_1051
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1051_buf_named_pipes;
		}

		public struct WKSTA_INFO_1052
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1052_use_lock_read_unlock;
		}

		public struct WKSTA_INFO_1053
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1053_utilize_nt_caching;
		}

		public struct WKSTA_INFO_1054
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1054_use_raw_read;
		}

		public struct WKSTA_INFO_1055
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1055_use_raw_write;
		}

		public struct WKSTA_INFO_1056
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1056_use_write_raw_data;
		}

		public struct WKSTA_INFO_1057
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1057_use_encryption;
		}

		public struct WKSTA_INFO_1058
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1058_buf_files_deny_write;
		}

		public struct WKSTA_INFO_1059
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1059_buf_read_only_files;
		}

		public struct WKSTA_INFO_1060
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1060_force_core_create_mode;
		}

		public struct WKSTA_INFO_1061
		{
			[MarshalAs(UnmanagedType.Bool)] public bool wki1061_use_512_byte_max_transfer;
		}

		public struct WKSTA_INFO_1062
		{
			public uint wki1062_read_ahead_throughput;
		}

		/// <summary>
		/// Down-level NetWkstaGetInfo and NetWkstaSetInfo. DOS specific workstation information - admin or domain operator access
		/// </summary>
		[PInvokeData("lmwksta.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_302
		{
			public uint wki302_char_wait;
			public uint wki302_collection_time;
			public uint wki302_maximum_collection_count;
			public uint wki302_keep_conn;
			public uint wki302_keep_search;
			public uint wki302_max_cmds;
			public uint wki302_num_work_buf;
			public uint wki302_siz_work_buf;
			public uint wki302_max_wrk_cache;
			public uint wki302_sess_timeout;
			public uint wki302_siz_error;
			public uint wki302_num_alerts;
			public uint wki302_num_services;
			public uint wki302_errlog_sz;
			public uint wki302_print_buf_time;
			public uint wki302_num_char_buf;
			public uint wki302_siz_char_buf;
			public string wki302_wrk_heuristics;
			public uint wki302_mailslots;
			public uint wki302_num_dgram_buf;
		}

		/// <summary>
		/// Down-level NetWkstaGetInfo and NetWkstaSetInfo. OS/2 specific workstation information - admin or domain operator access
		/// </summary>
		[PInvokeData("lmwksta.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_402
		{
			public uint wki402_char_wait;
			public uint wki402_collection_time;
			public uint wki402_maximum_collection_count;
			public uint wki402_keep_conn;
			public uint wki402_keep_search;
			public uint wki402_max_cmds;
			public uint wki402_num_work_buf;
			public uint wki402_siz_work_buf;
			public uint wki402_max_wrk_cache;
			public uint wki402_sess_timeout;
			public uint wki402_siz_error;
			public uint wki402_num_alerts;
			public uint wki402_num_services;
			public uint wki402_errlog_sz;
			public uint wki402_print_buf_time;
			public uint wki402_num_char_buf;
			public uint wki402_siz_char_buf;
			public string wki402_wrk_heuristics;
			public uint wki402_mailslots;
			public uint wki402_num_dgram_buf;
			public uint wki402_max_threads;
		}

		/// <summary>The <c>WKSTA_INFO_502</c> structure is obsolete. The structure contains information about a workstation environment.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_info_502 typedef struct _WKSTA_INFO_502 { DWORD
		// wki502_char_wait; DWORD wki502_collection_time; DWORD wki502_maximum_collection_count; DWORD wki502_keep_conn; DWORD
		// wki502_max_cmds; DWORD wki502_sess_timeout; DWORD wki502_siz_char_buf; DWORD wki502_max_threads; DWORD wki502_lock_quota; DWORD
		// wki502_lock_increment; DWORD wki502_lock_maximum; DWORD wki502_pipe_increment; DWORD wki502_pipe_maximum; DWORD
		// wki502_cache_file_timeout; DWORD wki502_dormant_file_limit; DWORD wki502_read_ahead_throughput; DWORD wki502_num_mailslot_buffers;
		// DWORD wki502_num_srv_announce_buffers; DWORD wki502_max_illegal_datagram_events; DWORD
		// wki502_illegal_datagram_event_reset_frequency; BOOL wki502_log_election_packets; BOOL wki502_use_opportunistic_locking; BOOL
		// wki502_use_unlock_behind; BOOL wki502_use_close_behind; BOOL wki502_buf_named_pipes; BOOL wki502_use_lock_read_unlock; BOOL
		// wki502_utilize_nt_caching; BOOL wki502_use_raw_read; BOOL wki502_use_raw_write; BOOL wki502_use_write_raw_data; BOOL
		// wki502_use_encryption; BOOL wki502_buf_files_deny_write; BOOL wki502_buf_read_only_files; BOOL wki502_force_core_create_mode; BOOL
		// wki502_use_512_byte_max_transfer; } WKSTA_INFO_502, *PWKSTA_INFO_502, *LPWKSTA_INFO_502;
		[PInvokeData("lmwksta.h", MSDNShortId = "716e700a-e464-47ec-a2df-74c03597ac6d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_INFO_502
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of seconds the computer waits for a remote resource to become available.</para>
			/// </summary>
			public uint wki502_char_wait;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of milliseconds the computer collects data before sending the data to a character device resource. The workstation
			/// waits the specified time or collects the number of characters specified by the <c>wki502_maximum_collection_count</c> member,
			/// whichever comes first.
			/// </para>
			/// </summary>
			public uint wki502_collection_time;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of bytes of information the computer collects before sending the data to a character device resource. The
			/// workstation collects the specified number of bytes or waits the period of time specified by the <c>wki502_collection_time</c>
			/// member, whichever comes first.
			/// </para>
			/// </summary>
			public uint wki502_maximum_collection_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of seconds the server maintains an inactive connection to a server's resource.</para>
			/// </summary>
			public uint wki502_keep_conn;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of simultaneous network device driver commands that can be sent to the network.</para>
			/// </summary>
			public uint wki502_max_cmds;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of seconds the server waits before disconnecting an inactive session.</para>
			/// </summary>
			public uint wki502_sess_timeout;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum size, in bytes, of a character pipe buffer and device buffer.</para>
			/// </summary>
			public uint wki502_siz_char_buf;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The number of threads the computer can dedicate to the network.</para>
			/// </summary>
			public uint wki502_max_threads;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_lock_quota;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_lock_increment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_lock_maximum;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_pipe_increment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_pipe_maximum;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_cache_file_timeout;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_dormant_file_limit;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_read_ahead_throughput;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_num_mailslot_buffers;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_num_srv_announce_buffers;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_max_illegal_datagram_events;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint wki502_illegal_datagram_event_reset_frequency;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_log_election_packets;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_opportunistic_locking;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_unlock_behind;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_close_behind;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_buf_named_pipes;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_lock_read_unlock;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_utilize_nt_caching;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_raw_read;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_raw_write;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_write_raw_data;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_encryption;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_buf_files_deny_write;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_buf_read_only_files;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_force_core_create_mode;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wki502_use_512_byte_max_transfer;
		}

		/// <summary>
		/// The <c>WKSTA_TRANSPORT_INFO_0</c> structure contains information about the workstation transport protocol, such as Wide Area
		/// Network (WAN) or NetBIOS.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_transport_info_0 typedef struct
		// _WKSTA_TRANSPORT_INFO_0 { DWORD wkti0_quality_of_service; DWORD wkti0_number_of_vcs; LMSTR wkti0_transport_name; LMSTR
		// wkti0_transport_address; BOOL wkti0_wan_ish; } WKSTA_TRANSPORT_INFO_0, *PWKSTA_TRANSPORT_INFO_0, *LPWKSTA_TRANSPORT_INFO_0;
		[PInvokeData("lmwksta.h", MSDNShortId = "e7afe2a3-f729-4fd5-afc3-d3ffbd09e884")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_TRANSPORT_INFO_0
		{
			/// <summary>
			/// Specifies a value that determines the search order of the transport protocol with respect to other transport protocols. The
			/// highest value is searched first.
			/// </summary>
			public uint wkti0_quality_of_service;

			/// <summary>Specifies the number of clients communicating with the server using this transport protocol.</summary>
			public uint wkti0_number_of_vcs;

			/// <summary>Specifies the device name of the transport protocol.</summary>
			public string wkti0_transport_name;

			/// <summary>
			/// <para>Specifies the address of the server on this transport protocol.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkti0_transport_address;

			/// <summary>
			/// <para>
			/// This member is ignored by the NetWkstaTransportAdd function. For the NetWkstaTransportEnum function, this member indicates
			/// whether the transport protocol is a WAN transport protocol. This member is set to <c>TRUE</c> for NetBIOS/TCIP; it is set to
			/// <c>FALSE</c> for NetBEUI and NetBIOS/IPX.
			/// </para>
			/// <para>
			/// Certain legacy networking protocols, including NetBEUI, will no longer be supported. For more information, see Network
			/// Protocol Support in Windows.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool wkti0_wan_ish;
		}

		/// <summary>The <c>WKSTA_USER_INFO_0</c> structure contains the name of the user on a specified workstation.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_user_info_0 typedef struct _WKSTA_USER_INFO_0 {
		// LMSTR wkui0_username; } WKSTA_USER_INFO_0, *PWKSTA_USER_INFO_0, *LPWKSTA_USER_INFO_0;
		[PInvokeData("lmwksta.h", MSDNShortId = "8bd8d8c7-4558-46cb-ab46-a2197d53e9f7")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_USER_INFO_0
		{
			/// <summary>
			/// <para>Specifies the name of the user currently logged on to the workstation.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui0_username;
		}

		/// <summary>
		/// The <c>WKSTA_USER_INFO_1</c> structure contains user information as it pertains to a specific workstation. The information
		/// includes the name of the current user and the domains accessed by the workstation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_user_info_1 typedef struct _WKSTA_USER_INFO_1 {
		// LMSTR wkui1_username; LMSTR wkui1_logon_domain; LMSTR wkui1_oth_domains; LMSTR wkui1_logon_server; } WKSTA_USER_INFO_1,
		// *PWKSTA_USER_INFO_1, *LPWKSTA_USER_INFO_1;
		[PInvokeData("lmwksta.h", MSDNShortId = "a30747de-6cb0-41dc-95a7-be3d471056d5")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_USER_INFO_1
		{
			/// <summary>
			/// <para>Specifies the name of the user currently logged on to the workstation.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui1_username;

			/// <summary>
			/// <para>Specifies the name of the domain in which the user is currently logged on.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui1_logon_domain;

			/// <summary>
			/// <para>Specifies the list of operating system domains browsed by the workstation. The domain names are separated by blanks.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui1_oth_domains;

			/// <summary>
			/// <para>Specifies the name of the server that authenticated the user.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui1_logon_server;
		}

		/// <summary>The <c>WKSTA_USER_INFO_1101</c> structure contains information about the domains accessed by a workstation.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmwksta/ns-lmwksta-_wksta_user_info_1101 typedef struct _WKSTA_USER_INFO_1101
		// { LMSTR wkui1101_oth_domains; } WKSTA_USER_INFO_1101, *PWKSTA_USER_INFO_1101, *LPWKSTA_USER_INFO_1101;
		[PInvokeData("lmwksta.h", MSDNShortId = "88772ba2-046b-4b03-ae02-d851075e4363")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WKSTA_USER_INFO_1101
		{
			/// <summary>
			/// <para>Specifies the list of operating system domains browsed by the workstation. The domain names are separated by blanks.</para>
			/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
			/// </summary>
			public string wkui1101_oth_domains;
		}
	}
}