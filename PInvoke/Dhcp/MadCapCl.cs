using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from Dhcpcsvc.dll for Multicast Address Dynamic Client Allocation Protocol (MADCAP).</summary>
	public static partial class MADCAP
	{
		/// <summary>Required length of the buffer for <see cref="MCAST_CLIENT_UID"/>.</summary>
		public const int MCAST_CLIENT_ID_LEN = 17;

		private const string Lib_Dhcpcsvc = "Dhcpcsvc.dll";

		/// <summary>
		/// The <c>McastApiCleanup</c> function deallocates resources that are allocated with McastApiStartup. The <c>McastApiCleanup</c>
		/// function must only be called after a successful call to <c>McastApiStartup</c>.
		/// </summary>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastapicleanup void McastApiCleanup();
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastApiCleanup")]
		public static extern void McastApiCleanup();

		/// <summary>
		/// The <c>McastApiStartup</c> function facilitates MADCAP-version negotiation between requesting clients and the version of MADCAP
		/// implemented on the system. Calling <c>McastApiStartup</c> allocates necessary resources; it must be called before any other
		/// MADCAP client functions are called.
		/// </summary>
		/// <param name="Version">
		/// <para>Pointer to the version of multicast (MCAST) that the client wishes to use.</para>
		/// <para>[out] Pointer to the version of MCAST implemented on the system.</para>
		/// </param>
		/// <returns>
		/// If the client requests a version of MADCAP that is not supported by the system, the <c>McastApiStartup</c> function returns
		/// ERROR_NOT_SUPPORTED. If resources fail to be allocated for the function call, ERROR_NO_SYSTEM_RESOURCES is returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Clients can specify which version they want to use in the pVersion parameter. If the system's implementation supports the
		/// requested MCAST version, the function call succeeds. If the system's implementation does not support the requested version, the
		/// function fails with MCAST_API_CURRENT_VERSION.
		/// </para>
		/// <para>
		/// The client can automatically negotiate the first version of MCAST (MCAST_API_VERSION_1) by setting the pVersion parameter to zero.
		/// </para>
		/// <para>
		/// The <c>McastApiStartup</c> function always returns the most recent version of MADCAP available on the system
		/// (MCAST_API_CURRENT_VERSION) in pVersion, enabling clients to discover the most recent version implemented on the system.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastapistartup DWORD McastApiStartup( PDWORD Version );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastApiStartup")]
		public static extern Win32Error McastApiStartup(out uint Version);

		/// <summary>The <c>McastEnumerateScopes</c> function enumerates multicast scopes available on the network.</summary>
		/// <param name="AddrFamily">
		/// Specifies the address family to be used in enumeration, in the form of an IPNG_ADDRESS structure. Use AF_INET for IPv4 addresses
		/// and AF_INET6 for IPv6 addresses.
		/// </param>
		/// <param name="ReQuery">
		/// Enables a caller to query a list again. Set this parameter to <c>TRUE</c> if the list is to be queried more than once.
		/// Otherwise, set it to <c>FALSE</c>.
		/// </param>
		/// <param name="pScopeList">
		/// <para>
		/// Pointer to a buffer used for storing scope list information, in the form of an MCAST_SCOPE_ENTRY structure. The return value of
		/// pScopeList depends on its input value, and on the value of the buffer to which it points:
		/// </para>
		/// <para>If pScopeList is a valid pointer on input, the scope list is returned.</para>
		/// <para>If pScopeList is <c>NULL</c> on input, the length of the buffer required to hold the scope list is returned.</para>
		/// <para>
		/// If the buffer pointed to in pScopeList is <c>NULL</c> on input, <c>McastEnumerateScopes</c> forces a repeat querying of scope
		/// lists from MCAST servers.
		/// </para>
		/// <para>
		/// To determine the size of buffer required to hold scope list data, set pScopeList to <c>NULL</c> and pScopeLen to a non-
		/// <c>NULL</c> value. The <c>McastEnumerateScopes</c> function will then return ERROR_SUCCESS and store the size of the scope list
		/// data, in bytes, in pScopeLen.
		/// </para>
		/// </param>
		/// <param name="pScopeLen">
		/// <para>
		/// Pointer to a value used to communicate the size of data or buffer space in pScopeList. On input, pScopeLen points to the size,
		/// in bytes, of the buffer pointed to by pScopeList. On return, pScopeLen points to the size of the data copied to pScopeList.
		/// </para>
		/// <para>
		/// The pScopeLen parameter cannot be <c>NULL</c>. If the buffer pointed to by pScopeList is not large enough to hold the scope list
		/// data, <c>McastEnumerateScopes</c> returns ERROR_MORE_DATA and stores the required buffer size, in bytes, in pScopeLen.
		/// </para>
		/// <para>
		/// To determine the size of buffer required to hold scope list data, set pScopeList to <c>NULL</c> and pScopeLen to a non-
		/// <c>NULL</c> value. The <c>McastEnumerateScopes</c> function will then return ERROR_SUCCESS and store the size of the scope list
		/// data, in bytes, in pScopeLen.
		/// </para>
		/// </param>
		/// <param name="pScopeCount">Pointer to the number of scopes returned in pScopeList.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
		/// <para>
		/// If the buffer pointed to by pScopeList is too small to hold the scope list, the <c>McastEnumerateScopes</c> function returns
		/// ERROR_MORE_DATA, and stores the required buffer size, in bytes, in pScopeLen.
		/// </para>
		/// <para>
		/// If the McastApiStartup function has not been called (it must be called before any other MADCAP client functions may be called),
		/// the <c>McastEnumerateScopes</c> function returns ERROR_NOT_READY.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <c>McastEnumerateScopes</c> function queries multicast scopes for each network interface, and the interface on which the
		/// scope is retrieved is returned as part of the pScopeList parameter. Therefore, on multihomed computers it is possible that some
		/// scopes will get listed multiple times, once for each interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastenumeratescopes DWORD McastEnumerateScopes(
		// IP_ADDR_FAMILY AddrFamily, BOOL ReQuery, PMCAST_SCOPE_ENTRY pScopeList, PDWORD pScopeLen, PDWORD pScopeCount );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastEnumerateScopes")]
		public static extern Win32Error McastEnumerateScopes(System.Net.Sockets.AddressFamily AddrFamily, [MarshalAs(UnmanagedType.Bool)] bool ReQuery,
			ref MCAST_SCOPE_ENTRY pScopeList, ref uint pScopeLen, out uint pScopeCount);

		/// <summary>The <c>McastEnumerateScopes</c> function enumerates multicast scopes available on the network.</summary>
		/// <param name="AddrFamily">
		/// Specifies the address family to be used in enumeration, in the form of an IPNG_ADDRESS structure. Use AF_INET for IPv4 addresses
		/// and AF_INET6 for IPv6 addresses.
		/// </param>
		/// <param name="ReQuery">
		/// Enables a caller to query a list again. Set this parameter to <c>TRUE</c> if the list is to be queried more than once.
		/// Otherwise, set it to <c>FALSE</c>.
		/// </param>
		/// <param name="pScopeList">
		/// <para>
		/// Pointer to a buffer used for storing scope list information, in the form of an MCAST_SCOPE_ENTRY structure. The return value of
		/// pScopeList depends on its input value, and on the value of the buffer to which it points:
		/// </para>
		/// <para>If pScopeList is a valid pointer on input, the scope list is returned.</para>
		/// <para>If pScopeList is <c>NULL</c> on input, the length of the buffer required to hold the scope list is returned.</para>
		/// <para>
		/// If the buffer pointed to in pScopeList is <c>NULL</c> on input, <c>McastEnumerateScopes</c> forces a repeat querying of scope
		/// lists from MCAST servers.
		/// </para>
		/// <para>
		/// To determine the size of buffer required to hold scope list data, set pScopeList to <c>NULL</c> and pScopeLen to a non-
		/// <c>NULL</c> value. The <c>McastEnumerateScopes</c> function will then return ERROR_SUCCESS and store the size of the scope list
		/// data, in bytes, in pScopeLen.
		/// </para>
		/// </param>
		/// <param name="pScopeLen">
		/// <para>
		/// Pointer to a value used to communicate the size of data or buffer space in pScopeList. On input, pScopeLen points to the size,
		/// in bytes, of the buffer pointed to by pScopeList. On return, pScopeLen points to the size of the data copied to pScopeList.
		/// </para>
		/// <para>
		/// The pScopeLen parameter cannot be <c>NULL</c>. If the buffer pointed to by pScopeList is not large enough to hold the scope list
		/// data, <c>McastEnumerateScopes</c> returns ERROR_MORE_DATA and stores the required buffer size, in bytes, in pScopeLen.
		/// </para>
		/// <para>
		/// To determine the size of buffer required to hold scope list data, set pScopeList to <c>NULL</c> and pScopeLen to a non-
		/// <c>NULL</c> value. The <c>McastEnumerateScopes</c> function will then return ERROR_SUCCESS and store the size of the scope list
		/// data, in bytes, in pScopeLen.
		/// </para>
		/// </param>
		/// <param name="pScopeCount">Pointer to the number of scopes returned in pScopeList.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns ERROR_SUCCESS.</para>
		/// <para>
		/// If the buffer pointed to by pScopeList is too small to hold the scope list, the <c>McastEnumerateScopes</c> function returns
		/// ERROR_MORE_DATA, and stores the required buffer size, in bytes, in pScopeLen.
		/// </para>
		/// <para>
		/// If the McastApiStartup function has not been called (it must be called before any other MADCAP client functions may be called),
		/// the <c>McastEnumerateScopes</c> function returns ERROR_NOT_READY.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <c>McastEnumerateScopes</c> function queries multicast scopes for each network interface, and the interface on which the
		/// scope is retrieved is returned as part of the pScopeList parameter. Therefore, on multihomed computers it is possible that some
		/// scopes will get listed multiple times, once for each interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastenumeratescopes DWORD McastEnumerateScopes(
		// IP_ADDR_FAMILY AddrFamily, BOOL ReQuery, PMCAST_SCOPE_ENTRY pScopeList, PDWORD pScopeLen, PDWORD pScopeCount );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastEnumerateScopes")]
		public static extern Win32Error McastEnumerateScopes(System.Net.Sockets.AddressFamily AddrFamily, [MarshalAs(UnmanagedType.Bool)] bool ReQuery,
			[In, Optional] IntPtr pScopeList, ref uint pScopeLen, out uint pScopeCount);

		/// <summary>
		/// The <c>McastGenUID</c> function generates a unique identifier, subsequently used by clients to request and renew addresses.
		/// </summary>
		/// <param name="pRequestID">
		/// Pointer to the MCAST_CLIENT_UID structure into which the unique identifier is stored. The size of the buffer to which pRequestID
		/// points must be at least MCAST_CLIENT_ID_LEN in size.
		/// </param>
		/// <returns>The <c>McastGenUID</c> function returns the status of the operation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastgenuid DWORD McastGenUID( LPMCAST_CLIENT_UID
		// pRequestID );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastGenUID")]
		public static extern Win32Error McastGenUID(ref MCAST_CLIENT_UID pRequestID);

		/// <summary>The <c>McastReleaseAddress</c> function releases leased multicast addresses from the MCAST server.</summary>
		/// <param name="AddrFamily">
		/// Designates the address family. Use AF_INET for Internet Protocol version 4 (IPv4), and AF_INET6 for Internet Protocol version 6 (IPv6).
		/// </param>
		/// <param name="pRequestID">Unique identifier used when the address or addresses were initially obtained.</param>
		/// <param name="pReleaseRequest">
		/// Pointer to the MCAST_LEASE_REQUEST structure containing multicast parameters associated with the release request.
		/// </param>
		/// <returns>The <c>McastReleaseAddress</c> function returns the status of the operation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastreleaseaddress DWORD McastReleaseAddress(
		// IP_ADDR_FAMILY AddrFamily, LPMCAST_CLIENT_UID pRequestID, PMCAST_LEASE_REQUEST pReleaseRequest );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastReleaseAddress")]
		public static extern Win32Error McastReleaseAddress(System.Net.Sockets.AddressFamily AddrFamily, in MCAST_CLIENT_UID pRequestID,
			in MCAST_LEASE_REQUEST pReleaseRequest);

		/// <summary>The <c>McastRenewAddress</c> function renews one or more multicast addresses from a MADCAP server.</summary>
		/// <param name="AddrFamily">
		/// Designates the address family. Use AF_INET for Internet Protocol version 4 (IPv4), and AF_INET6 for Internet Protocol version 6 (IPv6).
		/// </param>
		/// <param name="pRequestID">Unique identifier used when the address or addresses were initially obtained.</param>
		/// <param name="pRenewRequest">Pointer to the MCAST_LEASE_REQUEST structure containing multicast renew–request parameters.</param>
		/// <param name="pRenewResponse">
		/// Pointer to a buffer containing response parameters for the multicast address–renew request, in the form of an
		/// MCAST_LEASE_RESPONSE structure. The caller is responsible for allocating sufficient buffer space for the <c>pAddrBuf</c> member
		/// of the <c>MCAST_LEASE_RESPONSE</c> structure to hold the requested number of addresses; the caller is also responsible for
		/// setting the pointer to that buffer.
		/// </param>
		/// <returns>The <c>McastRenewAddress</c> function returns the status of the operation.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastrenewaddress DWORD McastRenewAddress( IP_ADDR_FAMILY
		// AddrFamily, LPMCAST_CLIENT_UID pRequestID, PMCAST_LEASE_REQUEST pRenewRequest, PMCAST_LEASE_RESPONSE pRenewResponse );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastRenewAddress")]
		public static extern Win32Error McastRenewAddress(System.Net.Sockets.AddressFamily AddrFamily, in MCAST_CLIENT_UID pRequestID,
			in MCAST_LEASE_REQUEST pRenewRequest, ref MCAST_LEASE_RESPONSE pRenewResponse);

		/// <summary>The <c>McastRequestAddress</c> function requests one or more multicast addresses from a MADCAP server.</summary>
		/// <param name="AddrFamily">
		/// Specifies the address family to be used in the request, in the form of an IPNG_ADDRESS structure. Use AF_INET for IPv4 addresses
		/// and AF_INET6 for IPv6 addresses.
		/// </param>
		/// <param name="pRequestID">
		/// Pointer to a unique identifier for the request, in the form of an MCAST_CLIENT_UID structure. Clients are responsible for
		/// ensuring that each request contains a unique identifier; unique identifiers can be obtained by calling the McastGenUID function.
		/// </param>
		/// <param name="pScopeCtx">
		/// Pointer to the context of the scope from which the address is to be allocated, in the form of an MCAST_SCOPE_CTX structure. The
		/// scope context must be retrieved by calling the McastEnumerateScopes function prior to calling the <c>McastRequestAddress</c> function.
		/// </param>
		/// <param name="pAddrRequest">Pointer to the MCAST_LEASE_REQUEST structure containing multicast lease–request parameters.</param>
		/// <param name="pAddrResponse">
		/// Pointer to a buffer containing response parameters for the multicast address request, in the form of an MCAST_LEASE_RESPONSE
		/// structure. The caller is responsible for allocating sufficient buffer space for the pAddrBuf member of the
		/// <c>MCAST_LEASE_RESPONSE</c> structure to hold the requested number of addresses; the caller is also responsible for setting the
		/// pointer to that buffer.
		/// </param>
		/// <returns>The <c>McastRequestAddress</c> function returns the status of the operation.</returns>
		/// <remarks>
		/// Before the <c>McastRequestAddress</c> function is called, the scope context must be retrieved by calling the
		/// McastEnumerateScopes function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/nf-madcapcl-mcastrequestaddress DWORD McastRequestAddress(
		// IP_ADDR_FAMILY AddrFamily, LPMCAST_CLIENT_UID pRequestID, PMCAST_SCOPE_CTX pScopeCtx, PMCAST_LEASE_REQUEST pAddrRequest,
		// PMCAST_LEASE_RESPONSE pAddrResponse );
		[DllImport(Lib_Dhcpcsvc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("madcapcl.h", MSDNShortId = "NF:madcapcl.McastRequestAddress")]
		public static extern Win32Error McastRequestAddress(System.Net.Sockets.AddressFamily AddrFamily, in MCAST_CLIENT_UID pRequestID,
			in MCAST_SCOPE_CTX pScopeCtx, in MCAST_LEASE_REQUEST pAddrRequest, ref MCAST_LEASE_RESPONSE pAddrResponse);

		/// <summary>
		/// The <c>IPNG_ADDRESS</c> union provides Internet Protocol version 4 (IPv4) and Internet Protocol version 6 (IPv6) addresses.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-ipng_address typedef union _IPNG_ADDRESS { DWORD
		// IpAddrV4; BYTE IpAddrV6[16]; } IPNG_ADDRESS, *PIPNG_ADDRESS;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._IPNG_ADDRESS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IPNG_ADDRESS
		{
			/// <summary>Internet Protocol (IP) address, in version 6 format (IPv6).</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] IpAddrV6;

			/// <summary>Internet Protocol (IP) address, in version 4 format (IPv4).</summary>
			public uint IpAddrV4
			{
				get => BitConverter.ToUInt32(IpAddrV6, 0);
				set => Array.Copy(BitConverter.GetBytes(value), IpAddrV6, 4);
			}
		}

		/// <summary>The <c>MCAST_CLIENT_UID</c> structure describes the unique client identifier for each multicast request.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-mcast_client_uid typedef struct _MCAST_CLIENT_UID {
		// LPBYTE ClientUID; DWORD ClientUIDLength; } MCAST_CLIENT_UID, *LPMCAST_CLIENT_UID;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._MCAST_CLIENT_UID")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MCAST_CLIENT_UID
		{
			/// <summary>Buffer containing the unique client identifier.</summary>
			public IntPtr ClientUID;

			/// <summary>Size of the <c>ClientUID</c> member, in bytes.</summary>
			public uint ClientUIDLength;
		}

		/// <summary>
		/// The <c>MCAST_LEASE_REQUEST</c> structure defines the request, renew, or release parameters for a given multicast scope. In the
		/// MCAST_API_VERSION_1 implementation, only one IP address may be allocated at a time.
		/// </summary>
		/// <remarks>
		/// In MCAST_API_VERSION_1 version, <c>MaxLeaseStartTime</c>, <c>MinLeaseDuration</c>, and <c>MinAddrCount</c> members are ignored.
		/// Clients should still set appropriate values for these members, however, to take advantage of their implementation in future updates.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-mcast_lease_request typedef struct _MCAST_LEASE_REQUEST {
		// LONG LeaseStartTime; LONG MaxLeaseStartTime; DWORD LeaseDuration; DWORD MinLeaseDuration; IPNG_ADDRESS ServerAddress; WORD
		// MinAddrCount; WORD AddrCount; PBYTE pAddrBuf; } MCAST_LEASE_REQUEST, *PMCAST_LEASE_REQUEST;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._MCAST_LEASE_REQUEST")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MCAST_LEASE_REQUEST
		{
			/// <summary>
			/// Requested start time, in seconds, for the multicast scope lease elapsed since midnight of January 1, 1970, coordinated
			/// universal time. To request the current time as the lease start time, set <c>LeaseStartTime</c> to zero.
			/// </summary>
			public int LeaseStartTime;

			/// <summary>
			/// Maximum start time, in seconds, elapsed since midnight of January 1, 1970, coordinated universal time, that the client is
			/// willing to accept.
			/// </summary>
			public int MaxLeaseStartTime;

			/// <summary>
			/// Duration of the lease request, in seconds. To request the default lease duration, set both <c>LeaseDuration</c> and
			/// <c>MinLeaseDuration</c> to zero.
			/// </summary>
			public uint LeaseDuration;

			/// <summary>Minimum lease duration, in seconds, that the client is willing to accept.</summary>
			public uint MinLeaseDuration;

			/// <summary>
			/// Internet Protocol (IP) address of the server on which the lease is to be requested or renewed, in the form of an
			/// IPNG_ADDRESS structure. If the IP address of the server is unknown, such as when using this structure in an
			/// McastRequestAddress function call, set <c>ServerAddress</c> to zero.
			/// </summary>
			public IPNG_ADDRESS ServerAddress;

			/// <summary>Minimum number of IP addresses the client is willing to accept.</summary>
			public ushort MinAddrCount;

			/// <summary>Number of requested IP addresses. Note that the value of this member dictates the size of <c>pAddrBuf</c>.</summary>
			public ushort AddrCount;

			/// <summary>
			/// Pointer to a buffer containing the requested IP addresses. For IPv4 addresses, the <c>pAddrBuf</c> member points to 4-byte
			/// addresses; for IPv6 addresses, the <c>pAddrBuf</c> member points to 16-byte addresses. If no specific addresses are
			/// requested, set <c>pAddrBuf</c> to <c>NULL</c>.
			/// </summary>
			public IntPtr pAddrBuf;
		}

		/// <summary>The <c>MCAST_LEASE_RESPONSE</c> structure is used to respond to multicast lease requests.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-mcast_lease_response typedef struct _MCAST_LEASE_RESPONSE
		// { LONG LeaseStartTime; LONG LeaseEndTime; IPNG_ADDRESS ServerAddress; WORD AddrCount; PBYTE pAddrBuf; } MCAST_LEASE_RESPONSE, *PMCAST_LEASE_RESPONSE;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._MCAST_LEASE_RESPONSE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MCAST_LEASE_RESPONSE
		{
			/// <summary>
			/// Start time, in seconds, for the multicast scope lease elapsed since midnight of January 1, 1970, coordinated universal time.
			/// </summary>
			public int LeaseStartTime;

			/// <summary>
			/// Expiration time, in seconds of the multicast scope lease elapsed since midnight of January 1, 1970, coordinated universal time.
			/// </summary>
			public int LeaseEndTime;

			/// <summary>
			/// Internet Protocol (IP) address of the server on which the lease request has been granted or renewed, in the form of an
			/// IPNG_ADDRESS structure.
			/// </summary>
			public IPNG_ADDRESS ServerAddress;

			/// <summary>
			/// Number of IP addresses that are granted or renewed with the lease. Note that the value of this member dictates the size of <c>pAddrBuf</c>.
			/// </summary>
			public ushort AddrCount;

			/// <summary>
			/// Pointer to a buffer containing the granted IP addresses. For IPv4 addresses, the <c>pAddrBuf</c> member points to 4-byte
			/// addresses; for IPv6 addresses, the <c>pAddrBuf</c> member points to 16-byte addresses.
			/// </summary>
			public IntPtr pAddrBuf;
		}

		/// <summary>
		/// The <c>MCAST_SCOPE_CTX</c> structure defines the scope context for programmatic interaction with multicast addresses. The
		/// <c>MCAST_SCOPE_CTX</c> structure is used by various MADCAP functions as a handle for allocating, renewing, or releasing MADCAP addresses.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-mcast_scope_ctx typedef struct _MCAST_SCOPE_CTX {
		// IPNG_ADDRESS ScopeID; IPNG_ADDRESS Interface; IPNG_ADDRESS ServerID; } MCAST_SCOPE_CTX, *PMCAST_SCOPE_CTX;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._MCAST_SCOPE_CTX")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MCAST_SCOPE_CTX
		{
			/// <summary>Identifier for the multicast scope, in the form of an IPNG_ADDRESS structure.</summary>
			public IPNG_ADDRESS ScopeID;

			/// <summary>Interface on which the multicast scope is available, in the form of an IPNG_ADDRESS structure.</summary>
			public IPNG_ADDRESS Interface;

			/// <summary>Internet Protocol (IP) address of the MADCAP server, in the form of an IPNG_ADDRESS structure.</summary>
			public IPNG_ADDRESS ServerID;
		}

		/// <summary>The <c>MCAST_SCOPE_ENTRY</c> structure provides a complete set of information about a given multicast scope.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/madcapcl/ns-madcapcl-mcast_scope_entry typedef struct _MCAST_SCOPE_ENTRY {
		// MCAST_SCOPE_CTX ScopeCtx; IPNG_ADDRESS LastAddr; DWORD TTL; UNICODE_STRING ScopeDesc; } MCAST_SCOPE_ENTRY, *PMCAST_SCOPE_ENTRY;
		[PInvokeData("madcapcl.h", MSDNShortId = "NS:madcapcl._MCAST_SCOPE_ENTRY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MCAST_SCOPE_ENTRY
		{
			/// <summary>Handle for the multicast scope, in the form of an MCAST_SCOPE_CTX structure.</summary>
			public MCAST_SCOPE_CTX ScopeCtx;

			/// <summary>Internet Protocol (IP) address of the last address in the scope, in the form of an IPNG_ADDRESS structure.</summary>
			public IPNG_ADDRESS LastAddr;

			/// <summary>Time To Live (TTL) value of the scope.</summary>
			public uint TTL;

			/// <summary>Description of the scope, in human readable, user-friendly format.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string ScopeDesc;
		}
	}
}