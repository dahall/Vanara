namespace Vanara.PInvoke;

/// <summary>Items from Dhcpcsvc6.dll and Dhcpcsvc.dll.</summary>
public static partial class Dhcp
{
	private const string Lib_Dhcpcsvc6 = "dhcpcsvc6.dll";

	/// <summary>DHCP V6 options.</summary>
	[PInvokeData("dhcpcsdk.h")]
	public enum DHCPV6_OPTION_ID : uint
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		DHCPV6_OPTION_CLIENTID = 1,
		DHCPV6_OPTION_SERVERID = 2,
		DHCPV6_OPTION_IA_NA = 3,
		DHCPV6_OPTION_IA_TA = 4,
		DHCPV6_OPTION_ORO = 6,
		DHCPV6_OPTION_PREFERENCE = 7,
		DHCPV6_OPTION_UNICAST = 12,
		DHCPV6_OPTION_RAPID_COMMIT = 14,
		DHCPV6_OPTION_USER_CLASS = 15,
		DHCPV6_OPTION_VENDOR_CLASS = 16,
		DHCPV6_OPTION_VENDOR_OPTS = 17,
		DHCPV6_OPTION_RECONF_MSG = 19,
		DHCPV6_OPTION_SIP_SERVERS_NAMES = 21,
		DHCPV6_OPTION_SIP_SERVERS_ADDRS = 22,
		DHCPV6_OPTION_DNS_SERVERS = 23,
		DHCPV6_OPTION_DOMAIN_LIST = 24,
		DHCPV6_OPTION_IA_PD = 25,
		DHCPV6_OPTION_NIS_SERVERS = 27,
		DHCPV6_OPTION_NISP_SERVERS = 28,
		DHCPV6_OPTION_NIS_DOMAIN_NAME = 29,
		DHCPV6_OPTION_NISP_DOMAIN_NAME = 30,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>The <c>StatusCode</c> enum contains status codes for IPv6 operations.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ne-dhcpv6csdk-statuscode typedef enum { STATUS_NO_ERROR,
	// STATUS_UNSPECIFIED_FAILURE, STATUS_NO_BINDING, STATUS_NOPREFIX_AVAIL } StatusCode;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NE:dhcpv6csdk.__unnamed_enum_0")]
	public enum StatusCode
	{
		/// <summary/>
		STATUS_NO_ERROR,

		/// <summary/>
		STATUS_UNSPECIFIED_FAILURE,

		/// <summary/>
		STATUS_NO_BINDING,

		/// <summary/>
		STATUS_NOPREFIX_AVAIL,
	}

	/// <summary>
	/// The <c>Dhcpv6CApiCleanup</c> function enables DHCPv6 to properly clean up resources allocated throughout the use of DHCPv6
	/// function calls. The <c>Dhcpv6CApiCleanup</c> function must only be called if a previous call to Dhcpv6CApiInitialize executed successfully.
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6capicleanup void Dhcpv6CApiCleanup();
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6CApiCleanup")]
	public static extern void Dhcpv6CApiCleanup();

	/// <summary>
	/// The <c>Dhcpv6CApiInitialize</c> function must be the first function call made by users of DHCPv6. The function prepares the
	/// system for all other DHCPv6 function calls. Other DHCPv6 functions should only be called if the <c>Dhcpv6CApiInitialize</c>
	/// function executes successfully.
	/// </summary>
	/// <param name="Version">
	/// Pointer to the DHCPv6 version implemented by the client. If a valid pointer is passed, the DHCPv6 client will be returned
	/// through it.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS upon successful completion.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6capiinitialize void Dhcpv6CApiInitialize(
	// LPDWORD Version );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6CApiInitialize")]
	public static extern void Dhcpv6CApiInitialize(out uint Version);

	/// <summary>The Dhcpv6ReleasePrefix function releases a prefix previously acquired with the <c>Dhcpv6RequestPrefix</c> function.</summary>
	/// <param name="adapterName">Name of the adapter on which the PD request must be sent.</param>
	/// <param name="classId">
	/// <para>Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to use to send on the wire.</para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="leaseInfo">Pointer to a DHCPV6CAPIPrefixLeaseInformation structure that is used to release the prefix.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Release messages sent as the result of the call to this function must contain the following values for the <c>T1</c> and
	/// <c>T2</c> fields of the DHCPV6CAPIPrefixLeaseInformation structure supplied in the prefixleaseInfo parameter:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>T1</c>: the renewal time for the prefix, in seconds specified as absolute time values.</term>
	/// </item>
	/// <item>
	/// <term><c>T2</c>: the rebind time of the prefix, in seconds specified as absolute time values.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6releaseprefix DWORD Dhcpv6ReleasePrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID classId, LPDHCPV6PrefixLeaseInformation leaseInfo );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6ReleasePrefix")]
	public static extern Win32Error Dhcpv6ReleasePrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, in DHCPV6CAPI_CLASSID classId,
		in DHCPV6PrefixLeaseInformation leaseInfo);

	/// <summary>The Dhcpv6ReleasePrefix function releases a prefix previously acquired with the <c>Dhcpv6RequestPrefix</c> function.</summary>
	/// <param name="adapterName">Name of the adapter on which the PD request must be sent.</param>
	/// <param name="classId">
	/// <para>Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to use to send on the wire.</para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="leaseInfo">Pointer to a DHCPV6CAPIPrefixLeaseInformation structure that is used to release the prefix.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Release messages sent as the result of the call to this function must contain the following values for the <c>T1</c> and
	/// <c>T2</c> fields of the DHCPV6CAPIPrefixLeaseInformation structure supplied in the prefixleaseInfo parameter:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>T1</c>: the renewal time for the prefix, in seconds specified as absolute time values.</term>
	/// </item>
	/// <item>
	/// <term><c>T2</c>: the rebind time of the prefix, in seconds specified as absolute time values.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6releaseprefix DWORD Dhcpv6ReleasePrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID classId, LPDHCPV6PrefixLeaseInformation leaseInfo );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6ReleasePrefix")]
	public static extern Win32Error Dhcpv6ReleasePrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, [In, Optional] IntPtr classId,
		in DHCPV6PrefixLeaseInformation leaseInfo);

	/// <summary>The <c>Dhcpv6RenewPrefix</c> function renews a prefix previously acquired with the Dhcpv6RequestPrefix function.</summary>
	/// <param name="adapterName">GUID of the adapter on which the prefix renewal must be sent.</param>
	/// <param name="pclassId">
	/// <para>
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to send on the wire. This parameter is
	/// can be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="prefixleaseInfo">Pointer to a DHCPV6PrefixLeaseInformation structure that contains the prefix lease information.</param>
	/// <param name="pdwTimeToWait">
	/// Contains the number of seconds a requesting application needs to wait before calling the <c>Dhcpv6RenewPrefix</c> function to
	/// renew its acquired prefixes. A value of 0xFFFFFFFF indicates that the application does not need to renew its lease.
	/// </param>
	/// <param name="bValidatePrefix">
	/// Specifies to the DHCPv6 client whether or not to send a REBIND in order to validate the prefix bindings. <c>TRUE</c> indicates
	/// that a REBIND is required. <c>FALSE</c> indicates RENEW is required.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>Returned if the API responds with more prefixes than there is memory allocated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6renewprefix DWORD Dhcpv6RenewPrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID pclassId, LPDHCPV6PrefixLeaseInformation prefixleaseInfo, DWORD *pdwTimeToWait, DWORD
	// bValidatePrefix );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RenewPrefix")]
	public static extern Win32Error Dhcpv6RenewPrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, in DHCPV6CAPI_CLASSID pclassId,
		ref DHCPV6PrefixLeaseInformation prefixleaseInfo, out uint pdwTimeToWait, [MarshalAs(UnmanagedType.Bool)] bool bValidatePrefix);

	/// <summary>The <c>Dhcpv6RenewPrefix</c> function renews a prefix previously acquired with the Dhcpv6RequestPrefix function.</summary>
	/// <param name="adapterName">GUID of the adapter on which the prefix renewal must be sent.</param>
	/// <param name="pclassId">
	/// <para>
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to send on the wire. This parameter is
	/// can be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="prefixleaseInfo">Pointer to a DHCPV6PrefixLeaseInformation structure that contains the prefix lease information.</param>
	/// <param name="pdwTimeToWait">
	/// Contains the number of seconds a requesting application needs to wait before calling the <c>Dhcpv6RenewPrefix</c> function to
	/// renew its acquired prefixes. A value of 0xFFFFFFFF indicates that the application does not need to renew its lease.
	/// </param>
	/// <param name="bValidatePrefix">
	/// Specifies to the DHCPv6 client whether or not to send a REBIND in order to validate the prefix bindings. <c>TRUE</c> indicates
	/// that a REBIND is required. <c>FALSE</c> indicates RENEW is required.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>Returned if the API responds with more prefixes than there is memory allocated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6renewprefix DWORD Dhcpv6RenewPrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID pclassId, LPDHCPV6PrefixLeaseInformation prefixleaseInfo, DWORD *pdwTimeToWait, DWORD
	// bValidatePrefix );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RenewPrefix")]
	public static extern Win32Error Dhcpv6RenewPrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, [In, Optional] IntPtr pclassId,
		ref DHCPV6PrefixLeaseInformation prefixleaseInfo, out uint pdwTimeToWait, [MarshalAs(UnmanagedType.Bool)] bool bValidatePrefix);

	/// <summary>The Dhcpv6RequestParams function requests options from the DHCPv6 client cache or directly from the DHCPv6 server.</summary>
	/// <param name="forceNewInform">
	/// If this value is set to <c>TRUE</c>, any available cached information will be ignored and new information will be requested.
	/// Otherwise, the request is only sent if there is no cached information.
	/// </param>
	/// <param name="reserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="adapterName">GUID of the adapter for which this request is meant. This parameter must not be <c>NULL</c>.</param>
	/// <param name="classId">
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to use to send on the wire. This
	/// parameter is optional.
	/// </param>
	/// <param name="recdParams">A DHCPV6CAPI_PARAMS_ARRAY structure that contains the parameters to be received from the DHCPV6 server.</param>
	/// <param name="buffer">A buffer to contain information returned by some pointers in recdParams.</param>
	/// <param name="pSize">
	/// Size of the buffer. When the function returns ERROR_MORE_DATA, this parameter will contain the size, in bytes, required to
	/// complete the operation. If the function is successful, this parameter contains the number of bytes used.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The call to this API was made with insufficient memory allocated for the Buffer parameter, while pSize contains the actual
	/// memory size required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6requestparams DWORD Dhcpv6RequestParams( BOOL
	// forceNewInform, LPVOID reserved, LPWSTR adapterName, LPDHCPV6CAPI_CLASSID classId, DHCPV6CAPI_PARAMS_ARRAY recdParams, LPBYTE
	// buffer, LPDWORD pSize );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RequestParams")]
	public static extern Win32Error Dhcpv6RequestParams([MarshalAs(UnmanagedType.Bool)] bool forceNewInform, [In, Optional] IntPtr reserved,
		[MarshalAs(UnmanagedType.LPWStr)] string adapterName, in DHCPV6CAPI_CLASSID classId, [In, Out] DHCPV6CAPI_PARAMS_ARRAY recdParams,
		[In] IntPtr buffer, ref uint pSize);

	/// <summary>The Dhcpv6RequestParams function requests options from the DHCPv6 client cache or directly from the DHCPv6 server.</summary>
	/// <param name="forceNewInform">
	/// If this value is set to <c>TRUE</c>, any available cached information will be ignored and new information will be requested.
	/// Otherwise, the request is only sent if there is no cached information.
	/// </param>
	/// <param name="reserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="adapterName">GUID of the adapter for which this request is meant. This parameter must not be <c>NULL</c>.</param>
	/// <param name="classId">
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to use to send on the wire. This
	/// parameter is optional.
	/// </param>
	/// <param name="recdParams">A DHCPV6CAPI_PARAMS_ARRAY structure that contains the parameters to be received from the DHCPV6 server.</param>
	/// <param name="buffer">A buffer to contain information returned by some pointers in recdParams.</param>
	/// <param name="pSize">
	/// Size of the buffer. When the function returns ERROR_MORE_DATA, this parameter will contain the size, in bytes, required to
	/// complete the operation. If the function is successful, this parameter contains the number of bytes used.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The call to this API was made with insufficient memory allocated for the Buffer parameter, while pSize contains the actual
	/// memory size required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6requestparams DWORD Dhcpv6RequestParams( BOOL
	// forceNewInform, LPVOID reserved, LPWSTR adapterName, LPDHCPV6CAPI_CLASSID classId, DHCPV6CAPI_PARAMS_ARRAY recdParams, LPBYTE
	// buffer, LPDWORD pSize );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RequestParams")]
	public static extern Win32Error Dhcpv6RequestParams([MarshalAs(UnmanagedType.Bool)] bool forceNewInform, [In, Optional] IntPtr reserved,
		[MarshalAs(UnmanagedType.LPWStr)] string adapterName, [In, Optional] IntPtr classId, [In, Out] DHCPV6CAPI_PARAMS_ARRAY recdParams,
		[In] IntPtr buffer, ref uint pSize);

	/// <summary>The <c>Dhcpv6RequestPrefix</c> function requests a specific prefix.</summary>
	/// <param name="adapterName">GUID of the adapter on which the prefix request must be sent.</param>
	/// <param name="pclassId">
	/// <para>
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to send on the wire. This parameter is optional.
	/// </para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="prefixleaseInfo">
	/// <para>Pointer to a DHCPV6PrefixLeaseInformation structure that contains the prefix lease information.</para>
	/// <para>The following members of the DHCPV6PrefixLeaseInformation structure must follow these guidelines.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>DHCPV6PrefixLeaseInformation member</term>
	/// <term>Consideration</term>
	/// </listheader>
	/// <item>
	/// <term>nPrefixes</term>
	/// <term>
	/// Must contain a maximum value of 10. The caller should have the memory allocated in the prefixArray member based on the number of
	/// prefixes specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>iaid</term>
	/// <term>
	/// A unique positive number assigned to this member. This same value should be reused if this function is called again.This
	/// mandatory value must be set by the calling application.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ServerIdLen</term>
	/// <term>
	/// Must contain a maximum value of 128. The caller must have the memory allocated in the ServerId member based on the specified
	/// ServerIdLen value.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The caller must follow these considerations when assigning the values of the <c>nPrefixes</c>, <c>iaid</c>, and
	/// <c>ServerIdLen</c> members of the DHCPV6PrefixLeaseInformation structure. Based on these values, memory must also be properly
	/// allocated to the <c>ServerId</c> and <c>PrefixArray</c> members before the <c>Dhcpv6RequestPrefix</c> function is called.
	/// </para>
	/// </param>
	/// <param name="pdwTimeToWait">
	/// Contains the number of seconds a requesting application needs to wait before calling the Dhcpv6RenewPrefix function to renew its
	/// acquired prefixes. A value of 0xFFFFFFFF indicates that the application does not need to renew its lease.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The value of the nPrefixes or the ServerIdLen member specified is less than the number of prefixes available from the server or
	/// the available server ID length. Increase the nPrefixes or the ServerIdLen member and make sure the corresponding memory has been
	/// allocated properly before calling the Dhcpv6RequestPrefix function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6requestprefix DWORD Dhcpv6RequestPrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID pclassId, LPDHCPV6PrefixLeaseInformation prefixleaseInfo, DWORD *pdwTimeToWait );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RequestPrefix")]
	public static extern Win32Error Dhcpv6RequestPrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, in DHCPV6CAPI_CLASSID pclassId,
		ref DHCPV6PrefixLeaseInformation prefixleaseInfo, out uint pdwTimeToWait);

	/// <summary>The <c>Dhcpv6RequestPrefix</c> function requests a specific prefix.</summary>
	/// <param name="adapterName">GUID of the adapter on which the prefix request must be sent.</param>
	/// <param name="pclassId">
	/// <para>
	/// Pointer to a DHCPV6CAPI_CLASSID structure that contains the binary ClassId information to send on the wire. This parameter is optional.
	/// </para>
	/// <para>
	/// <c>Note</c> DHCPv6 Option Code 15 (0x000F) is not supported by this API. Typically, the User Class option is used by a client to
	/// identify the type or category of user or application it represents. A server selects the configuration information for the
	/// client based on the classes identified in this option.
	/// </para>
	/// </param>
	/// <param name="prefixleaseInfo">
	/// <para>Pointer to a DHCPV6PrefixLeaseInformation structure that contains the prefix lease information.</para>
	/// <para>The following members of the DHCPV6PrefixLeaseInformation structure must follow these guidelines.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>DHCPV6PrefixLeaseInformation member</term>
	/// <term>Consideration</term>
	/// </listheader>
	/// <item>
	/// <term>nPrefixes</term>
	/// <term>
	/// Must contain a maximum value of 10. The caller should have the memory allocated in the prefixArray member based on the number of
	/// prefixes specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>iaid</term>
	/// <term>
	/// A unique positive number assigned to this member. This same value should be reused if this function is called again.This
	/// mandatory value must be set by the calling application.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ServerIdLen</term>
	/// <term>
	/// Must contain a maximum value of 128. The caller must have the memory allocated in the ServerId member based on the specified
	/// ServerIdLen value.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The caller must follow these considerations when assigning the values of the <c>nPrefixes</c>, <c>iaid</c>, and
	/// <c>ServerIdLen</c> members of the DHCPV6PrefixLeaseInformation structure. Based on these values, memory must also be properly
	/// allocated to the <c>ServerId</c> and <c>PrefixArray</c> members before the <c>Dhcpv6RequestPrefix</c> function is called.
	/// </para>
	/// </param>
	/// <param name="pdwTimeToWait">
	/// Contains the number of seconds a requesting application needs to wait before calling the Dhcpv6RenewPrefix function to renew its
	/// acquired prefixes. A value of 0xFFFFFFFF indicates that the application does not need to renew its lease.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The value of the nPrefixes or the ServerIdLen member specified is less than the number of prefixes available from the server or
	/// the available server ID length. Increase the nPrefixes or the ServerIdLen member and make sure the corresponding memory has been
	/// allocated properly before calling the Dhcpv6RequestPrefix function again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if one of the following conditions are true:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The AdapterName is not in the correct format. It should be in this format: {00000000-0000-0000-0000-000000000000}.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/nf-dhcpv6csdk-dhcpv6requestprefix DWORD Dhcpv6RequestPrefix( LPWSTR
	// adapterName, LPDHCPV6CAPI_CLASSID pclassId, LPDHCPV6PrefixLeaseInformation prefixleaseInfo, DWORD *pdwTimeToWait );
	[DllImport(Lib_Dhcpcsvc6, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NF:dhcpv6csdk.Dhcpv6RequestPrefix")]
	public static extern Win32Error Dhcpv6RequestPrefix([MarshalAs(UnmanagedType.LPWStr)] string adapterName, [In, Optional] IntPtr pclassId,
		ref DHCPV6PrefixLeaseInformation prefixleaseInfo, out uint pdwTimeToWait);

	/// <summary>The <c>DHCPV6CAPI_CLASSID</c> structure defines an IPv6 client class ID.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ns-dhcpv6csdk-dhcpv6capi_classid typedef struct _DHCPV6CAPI_CLASSID
	// { ULONG Flags; #if ... LPBYTE Data; #else LPBYTE Data; #endif ULONG nBytesData; } DHCPV6CAPI_CLASSID, *PDHCPV6CAPI_CLASSID, *LPDHCPV6CAPI_CLASSID;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NS:dhcpv6csdk._DHCPV6CAPI_CLASSID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPV6CAPI_CLASSID
	{
		/// <summary>Reserved for future use. Must be set to 0.</summary>
		public uint Flags;

		/// <summary>Class ID binary data.</summary>
		public IntPtr Data;

		/// <summary>Size of <c>Data</c>, in bytes.</summary>
		public uint nBytesData;
	}

	/// <summary>A <c>DHCPV6CAPI_PARAMS</c> structure contains a requested parameter.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ns-dhcpv6csdk-dhcpv6capi_params typedef struct _DHCPV6CAPI_PARAMS {
	// ULONG Flags; ULONG OptionId; BOOL IsVendor; LPBYTE Data; DWORD nBytesData; } DHCPV6CAPI_PARAMS, *PDHCPV6CAPI_PARAMS, *LPDHCPV6CAPI_PARAMS;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NS:dhcpv6csdk._DHCPV6CAPI_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPV6CAPI_PARAMS
	{
		/// <summary>Reserved for future use.</summary>
		public uint Flags;

		/// <summary>
		/// <para>Identifier for the DHCPv6 parameter being requested.</para>
		/// <para>DHCPV6_OPTION_CLIENTID</para>
		/// <para>DHCPV6_OPTION_SERVERID</para>
		/// <para>DHCPV6_OPTION_IA_NA</para>
		/// <para>DHCPV6_OPTION_IA_TA</para>
		/// <para>DHCPV6_OPTION_ORO</para>
		/// <para>DHCPV6_OPTION_PREFERENCE</para>
		/// <para>DHCPV6_OPTION_UNICAST</para>
		/// <para>DHCPV6_OPTION_RAPID_COMMIT</para>
		/// <para>DHCPV6_OPTION_USER_CLASS</para>
		/// <para>DHCPV6_OPTION_VENDOR_CLASS</para>
		/// <para>DHCPV6_OPTION_VENDOR_OPTS</para>
		/// <para>DHCPV6_OPTION_RECONF_MSG</para>
		/// <para>DHCPV6_OPTION_SIP_SERVERS_NAMES</para>
		/// <para>DHCPV6_OPTION_SIP_SERVERS_ADDRS</para>
		/// <para>DHCPV6_OPTION_DNS_SERVERS</para>
		/// <para>DHCPV6_OPTION_DOMAIN_LIST</para>
		/// <para>DHCPV6_OPTION_IA_PD</para>
		/// <para>DHCPV6_OPTION_NIS_SERVERS</para>
		/// <para>DHCPV6_OPTION_NISP_SERVERS</para>
		/// <para>DHCPV6_OPTION_NIS_DOMAIN_NAME</para>
		/// <para>DHCPV6_OPTION_CLIENTIDNISP_DOMAIN_NAME</para>
		/// </summary>
		public DHCPV6_OPTION_ID OptionId;

		/// <summary>This option is set to <c>TRUE</c> if this parameter is vendor-specific. Otherwise, it is <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsVendor;

		/// <summary>Contains the actual parameter data.</summary>
		public IntPtr Data;

		/// <summary>Size of the <c>Data</c> member, in bytes.</summary>
		public uint nBytesData;
	}

	/// <summary>The <c>DHCPV6CAPI_PARAMS_ARRAY</c> structure contains an array of requested parameters.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ns-dhcpv6csdk-dhcpv6capi_params_array typedef struct
	// _DHCPV6CAPI_PARAMS_ARRAY { ULONG nParams; LPDHCPV6CAPI_PARAMS Params; } DHCPV6CAPI_PARAMS_ARRAY, *PDHCPV6CAPI_PARAMS_ARRAY, *LPDHCPV6CAPI_PARAMS_ARRAY;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NS:dhcpv6csdk._DHCPV6CAPI_PARAMS_ARRAY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPV6CAPI_PARAMS_ARRAY
	{
		/// <summary>Number of parameters in the array.</summary>
		public uint nParams;

		/// <summary>Pointer to a DHCPV6CAPI_PARAMS structure that contains a parameter.</summary>
		public IntPtr /*LPDHCPV6CAPI_PARAMS*/ Params;
	}

	/// <summary>The <c>DHCPV6Prefix</c> contains an IPv6 prefix.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ns-dhcpv6csdk-dhcpv6prefix typedef struct _DHCPV6Prefix { UCHAR
	// prefix[16]; DWORD prefixLength; DWORD preferredLifeTime; DWORD validLifeTime; StatusCode status; } DHCPV6Prefix, *PDHCPV6Prefix, *LPDHCPV6Prefix;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NS:dhcpv6csdk._DHCPV6Prefix")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPV6Prefix
	{
		/// <summary>128 bit prefix.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] prefix;

		/// <summary>Length of the prefix.</summary>
		public uint prefixLength;

		/// <summary>Preferred lifetime of the prefix, in seconds.</summary>
		public uint preferredLifeTime;

		/// <summary>The valid lifetime of the prefix in seconds.</summary>
		public uint validLifeTime;

		/// <summary>The status code returned.</summary>
		public StatusCode status;
	}

	/// <summary>The <c>DHCPV6PrefixLeaseInformation</c> structure contains information about a prefix lease.</summary>
	/// <remarks>
	/// In a prefix delegation scenario, the validation of lease lifetime values (specific status codes, <c>T1</c>, <c>T2</c>,
	/// <c>MaxLeaseExpirationTime</c>, and <c>LastRenewalTime</c>) are performed by the calling API, rather than the application
	/// consuming the data, as the latter might interpret these values differently.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpv6csdk/ns-dhcpv6csdk-dhcpv6prefixleaseinformation typedef struct
	// _DHCPV6PrefixLeaseInformation { DWORD nPrefixes; LPDHCPV6Prefix prefixArray; DWORD iaid; time_t T1; time_t T2; time_t
	// MaxLeaseExpirationTime; time_t LastRenewalTime; StatusCode status; LPBYTE ServerId; DWORD ServerIdLen; }
	// DHCPV6PrefixLeaseInformation, *PDHCPV6PrefixLeaseInformation, *LPDHCPV6PrefixLeaseInformation;
	[PInvokeData("dhcpv6csdk.h", MSDNShortId = "NS:dhcpv6csdk._DHCPV6PrefixLeaseInformation")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPV6PrefixLeaseInformation
	{
		/// <summary>Number of prefixes.</summary>
		public uint nPrefixes;

		/// <summary>Pointer to a list DHCPV6Prefix structures that contain the prefixes requested or returned by the server.</summary>
		public IntPtr /*LPDHCPV6Prefix*/ prefixArray;

		/// <summary>Identity Association identifier for the prefix operation.</summary>
		public uint iaid;

		/// <summary>The renewal time for the prefix, in seconds.</summary>
		public time_t T1;

		/// <summary>The rebind time of the prefix, in seconds.</summary>
		public time_t T2;

		/// <summary>The maximum lease expiration time of all the prefix leases in this structure.</summary>
		public time_t MaxLeaseExpirationTime;

		/// <summary>The time at which the last renewal for the prefixes occurred.</summary>
		public time_t LastRenewalTime;

		/// <summary>
		/// <para>
		/// Status code returned by the server for the IAPD. The following codes can be returned by the DHCP server for prefix
		/// delegation scenarios:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_NO_ERROR 0</term>
		/// <term>The prefix was successfully leased or renewed.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_UNSPECIFIED_FAILURE 1</term>
		/// <term>The lease or renewal action failed for an unspecified reason.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_BINDING 3</term>
		/// <term>The DHCPv6 server does not have a binding for the prefix.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NOPREFIX_AVAIL 6</term>
		/// <term>The DHCPv6 server does not have a prefix availble to offer the requesting client.</term>
		/// </item>
		/// </list>
		/// </summary>
		public StatusCode status;

		/// <summary>The server DUID from which the prefix is received. This data is used in subsequent renews.</summary>
		public IntPtr ServerId;

		/// <summary>The length of the above DUID data.</summary>
		public uint ServerIdLen;
	}
}