namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from wcmapi.h.</summary>
public static partial class WcmApi
{
	/// <summary>The highest version of the Wi-Fi Direct API the client supports.</summary>
	public const uint WCM_UNKNOWN_DATAPLAN_STATUS = uint.MaxValue;

	/// <summary>The <c>WCM_CONNECTION_COST</c> enumerated type determines the connection cost type and flags.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ne-wcmapi-wcm_connection_cost typedef enum _WCM_CONNECTION_COST {
	// WCM_CONNECTION_COST_UNKNOWN, WCM_CONNECTION_COST_UNRESTRICTED, WCM_CONNECTION_COST_FIXED, WCM_CONNECTION_COST_VARIABLE,
	// WCM_CONNECTION_COST_OVERDATALIMIT, WCM_CONNECTION_COST_CONGESTED, WCM_CONNECTION_COST_ROAMING,
	// WCM_CONNECTION_COST_APPROACHINGDATALIMIT } WCM_CONNECTION_COST, *PWCM_CONNECTION_COST;
	[PInvokeData("wcmapi.h", MSDNShortId = "1ab36082-3394-42e3-aee3-01df5e211ba7")]
	[Flags]
	public enum WCM_CONNECTION_COST
	{
		/// <summary>Connection cost information is not available.</summary>
		WCM_CONNECTION_COST_UNKNOWN = 0x0,

		/// <summary>The connection is unlimited and has unrestricted usage constraints.</summary>
		WCM_CONNECTION_COST_UNRESTRICTED = 0x1,

		/// <summary>Usage counts toward a fixed allotment of data which the user has already paid for (or agreed to pay for).</summary>
		WCM_CONNECTION_COST_FIXED = 0x2,

		/// <summary>The connection cost is on a per-byte basis.</summary>
		WCM_CONNECTION_COST_VARIABLE = 0x4,

		/// <summary>The connection has exceeded its data limit.</summary>
		WCM_CONNECTION_COST_OVERDATALIMIT = 0x10000,

		/// <summary>The connection is throttled due to high traffic.</summary>
		WCM_CONNECTION_COST_CONGESTED = 0x20000,

		/// <summary>The connection is outside of the home network.</summary>
		WCM_CONNECTION_COST_ROAMING = 0x40000,

		/// <summary>The connection is approaching its data limit.</summary>
		WCM_CONNECTION_COST_APPROACHINGDATALIMIT = 0x80000,
	}

	/// <summary>The <c>WCM_CONNECTION_COST_SOURCE</c> enumerated type specifies the source that provides connection cost information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ne-wcmapi-wcm_connection_cost_source typedef enum
	// _WCM_CONNECTION_COST_SOURCE { WCM_CONNECTION_COST_SOURCE_DEFAULT, WCM_CONNECTION_COST_SOURCE_GP, WCM_CONNECTION_COST_SOURCE_USER,
	// WCM_CONNECTION_COST_SOURCE_OPERATOR } WCM_CONNECTION_COST_SOURCE, *PWCM_CONNECTION_COST_SOURCE;
	[PInvokeData("wcmapi.h", MSDNShortId = "cd9e5562-dd50-46fc-be11-0ea89e6933c0")]
	public enum WCM_CONNECTION_COST_SOURCE
	{
		/// <summary>Default source.</summary>
		WCM_CONNECTION_COST_SOURCE_DEFAULT,

		/// <summary>The source for the connection cost is Group Policy.</summary>
		WCM_CONNECTION_COST_SOURCE_GP,

		/// <summary>The source for the connection cost is the user.</summary>
		WCM_CONNECTION_COST_SOURCE_USER,

		/// <summary>The source for the connection cost is the operator.</summary>
		WCM_CONNECTION_COST_SOURCE_OPERATOR,
	}

	/// <summary>The <c>WCM_MEDIA_TYPE</c> enumerated type specifies the type of media for a connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ne-wcmapi-wcm_media_type typedef enum _WCM_MEDIA_TYPE {
	// wcm_media_unknown, wcm_media_ethernet, wcm_media_wlan, wcm_media_mbn, wcm_media_invalid, wcm_media_max } WCM_MEDIA_TYPE, *PWCM_MEDIA_TYPE;
	[PInvokeData("wcmapi.h", MSDNShortId = "76617f35-c7a1-49ff-a630-482f2fe45dd7")]
	public enum WCM_MEDIA_TYPE
	{
		/// <summary>Unknown media.</summary>
		wcm_media_unknown,

		/// <summary>Ethernet.</summary>
		wcm_media_ethernet,

		/// <summary>WLAN.</summary>
		wcm_media_wlan,

		/// <summary>Mobile broadband.</summary>
		wcm_media_mbn,

		/// <summary>Invalid type.</summary>
		wcm_media_invalid,

		/// <summary>Maximum value for testing purposes.</summary>
		wcm_media_max,
	}

	/// <summary>The <c>WCM_PROPERTY</c> enumerated type specifies a property of a connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ne-wcmapi-wcm_property typedef enum _WCM_PROPERTY {
	// wcm_global_property_domain_policy, wcm_global_property_minimize_policy, wcm_global_property_roaming_policy,
	// wcm_global_property_powermanagement_policy, wcm_intf_property_connection_cost, wcm_intf_property_dataplan_status,
	// wcm_intf_property_hotspot_profile } WCM_PROPERTY, *PWCM_PROPERTY;
	[PInvokeData("wcmapi.h", MSDNShortId = "4cb5f7aa-2f06-4a8a-814d-f8e01b496fb9")]
	public enum WCM_PROPERTY
	{
		/// <summary>Domain policy.</summary>
		[CorrespondingType(typeof(WCM_POLICY_VALUE))]
		wcm_global_property_domain_policy,

		/// <summary>Minimize policy.</summary>
		[CorrespondingType(typeof(WCM_POLICY_VALUE))]
		wcm_global_property_minimize_policy,

		/// <summary>Roaming policy.</summary>
		[CorrespondingType(typeof(WCM_POLICY_VALUE))]
		wcm_global_property_roaming_policy,

		/// <summary>Power management policy.</summary>
		[CorrespondingType(typeof(WCM_POLICY_VALUE))]
		wcm_global_property_powermanagement_policy,

		/// <summary>The cost level and flags for the connection</summary>
		[CorrespondingType(typeof(WCM_CONNECTION_COST_DATA))]
		wcm_intf_property_connection_cost,

		/// <summary>The plan data associated with the new cost.</summary>
		[CorrespondingType(typeof(WCM_DATAPLAN_STATUS))]
		wcm_intf_property_dataplan_status,

		/// <summary>The hotspot profile.</summary>
		[CorrespondingType(typeof(string))]
		wcm_intf_property_hotspot_profile,
	}

	/// <summary>The <c>WcmFreeMemory</c> function is used to release memory resources allocated by the WCM functions.</summary>
	/// <param name="pMemory">Pointer to the memory to be freed.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmfreememory void WcmFreeMemory( __deallocate(Mem)PVOID
	// pMemory );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "43377f58-9702-472d-874a-898f29b743d8")]
	public static extern void WcmFreeMemory(IntPtr pMemory);

	/// <summary>
	/// The <c>WcmGetProfileList</c> function retrieves a list of profiles in preferred order, descending from the most preferred to the
	/// least preferred. The list includes all WCM-managed auto-connect profiles across all WCM-managed media types.
	/// </summary>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="ppProfileList">
	/// <para>Type: <c>PWCM_PROFILE_INFO_LIST*</c></para>
	/// <para>The list of profiles.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmgetprofilelist DWORD WcmGetProfileList( PVOID pReserved,
	// WCM_PROFILE_INFO_LIST **ppProfileList );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "ceef4e74-3c67-4267-a82a-9912c039f41c")]
	public static extern Win32Error WcmGetProfileList([Optional] IntPtr pReserved,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(WcmMarshaler<WCM_PROFILE_INFO_LIST>))] out WCM_PROFILE_INFO_LIST ppProfileList);

	/// <summary>The <c>WcmQueryProperty</c> function retrieves the value of a specified WCM property.</summary>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to query. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The name of the profile. If querying a non-global property ( <c>connection_cost</c>, <c>dataplan_status</c>, or
	/// <c>hotspot_profile</c>), the profile must be specified or the call will fail.
	/// </para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to query.</para>
	/// </param>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="pdwDataSize">
	/// <para>Type: <c>PDWORD</c></para>
	/// <para>The size of the returned property value.</para>
	/// </param>
	/// <param name="ppData">
	/// <para>Type: <c>PBYTE*</c></para>
	/// <para>The returned property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the ppData parameter will vary, depending on which property is being queried. This table shows the
	/// data type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Contains zero-length output.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmqueryproperty DWORD WcmQueryProperty( const GUID
	// *pInterface, LPCWSTR strProfileName, WCM_PROPERTY Property, PVOID pReserved, PDWORD pdwDataSize, PBYTE *ppData );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "07c0993e-2892-4908-be3f-d24210ccc300")]
	public static extern Win32Error WcmQueryProperty(in Guid pInterface, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strProfileName,
		WCM_PROPERTY Property, [Optional] IntPtr pReserved, out uint pdwDataSize, out SafeWcmMemory ppData);

	/// <summary>The <c>WcmQueryProperty</c> function retrieves the value of a specified WCM property.</summary>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to query. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The name of the profile. If querying a non-global property ( <c>connection_cost</c>, <c>dataplan_status</c>, or
	/// <c>hotspot_profile</c>), the profile must be specified or the call will fail.
	/// </para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to query.</para>
	/// </param>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="pdwDataSize">
	/// <para>Type: <c>PDWORD</c></para>
	/// <para>The size of the returned property value.</para>
	/// </param>
	/// <param name="ppData">
	/// <para>Type: <c>PBYTE*</c></para>
	/// <para>The returned property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the ppData parameter will vary, depending on which property is being queried. This table shows the
	/// data type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Contains zero-length output.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmqueryproperty DWORD WcmQueryProperty( const GUID
	// *pInterface, LPCWSTR strProfileName, WCM_PROPERTY Property, PVOID pReserved, PDWORD pdwDataSize, PBYTE *ppData );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "07c0993e-2892-4908-be3f-d24210ccc300")]
	public static extern Win32Error WcmQueryProperty([Optional] IntPtr pInterface, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strProfileName,
		WCM_PROPERTY Property, [Optional] IntPtr pReserved, out uint pdwDataSize, out SafeWcmMemory ppData);

	/// <summary>The <c>WcmQueryProperty</c> function retrieves the value of a specified WCM property.</summary>
	/// <typeparam name="T">The type of the requested property.</typeparam>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to query. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The name of the profile. If querying a non-global property ( <c>connection_cost</c>, <c>dataplan_status</c>, or
	/// <c>hotspot_profile</c>), the profile must be specified or the call will fail.
	/// </para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to query.</para>
	/// </param>
	/// <param name="ppData">The returned property value.</param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the ppData parameter will vary, depending on which property is being queried. This table shows the
	/// data type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Contains zero-length output.</term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("wcmapi.h", MSDNShortId = "07c0993e-2892-4908-be3f-d24210ccc300")]
	public static Win32Error WcmQueryProperty<T>(WCM_PROPERTY Property, [Optional] Guid? pInterface, [Optional] string? strProfileName, out T? ppData)
	{
		ppData = default;
		if (!CorrespondingTypeAttribute.CanGet(Property, typeof(T)))
			return Win32Error.ERROR_DATATYPE_MISMATCH;

		SafeCoTaskMemStruct<Guid> pi = pInterface;
		var res = WcmQueryProperty(pi, strProfileName, Property, default, out var sz, out var mem);
		if (res.Succeeded)
		{
			if (typeof(T).IsValueType)
				ppData = mem.ToStructure<T>(sz);
			else if (typeof(T) == typeof(string))
				ppData = (T?)(object?)mem.ToString(sz);
			else
				return Win32Error.ERROR_DATATYPE_MISMATCH;
		}
		return res;
	}

	/// <summary>The <c>WcmSetProfileList</c> function reorders a profile list or a subset of a profile list.</summary>
	/// <param name="pProfileList">
	/// <para>Type: <c>WCM_PROFILE_INFO_LIST*</c></para>
	/// <para>
	/// The list of profiles to be reordered, provided in the preferred order (descending from the most preferred to the least preferred).
	/// </para>
	/// </param>
	/// <param name="dwPosition">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Specifies the position in the list to start the reorder.</para>
	/// </param>
	/// <param name="fIgnoreUnknownProfiles">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// True if any profiles in pProfileList which do not exist should be ignored; the call will proceed with the remainder of the list.
	/// False if the call should fail without modifying the profile order if any profiles in pProfileList do not exist.
	/// </para>
	/// </param>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmsetprofilelist DWORD WcmSetProfileList(
	// WCM_PROFILE_INFO_LIST *pProfileList, DWORD dwPosition, BOOL fIgnoreUnknownProfiles, PVOID pReserved );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "c5efb2e8-c4c4-4e13-9f7a-ea2a40744655")]
	public static extern Win32Error WcmSetProfileList([In] WCM_PROFILE_INFO_LIST pProfileList, uint dwPosition,
		[MarshalAs(UnmanagedType.Bool)] bool fIgnoreUnknownProfiles, [Optional] IntPtr pReserved);

	/// <summary>The <c>WcmSetProperty</c> function sets the value of a WCM property.</summary>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to set. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The profile name.</para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to set.</para>
	/// </param>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="dwDataSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size of the new property value.</para>
	/// </param>
	/// <param name="pbData">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>The new property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the pbData parameter will vary, depending on which property is being set. This table shows the data
	/// type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Variable-length XML string. See the HotSpotProfile schema for more information.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmsetproperty DWORD WcmSetProperty( const GUID *pInterface,
	// LPCWSTR strProfileName, WCM_PROPERTY Property, PVOID pReserved, DWORD dwDataSize, const BYTE *pbData );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "79985d5e-a6a1-447c-b12e-11c6022c19a6")]
	public static extern Win32Error WcmSetProperty(in Guid pInterface, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strProfileName,
		WCM_PROPERTY Property, [Optional] IntPtr pReserved, uint dwDataSize, [In, Optional] IntPtr pbData);

	/// <summary>The <c>WcmSetProperty</c> function sets the value of a WCM property.</summary>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to set. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The profile name.</para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to set.</para>
	/// </param>
	/// <param name="pReserved">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="dwDataSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The size of the new property value.</para>
	/// </param>
	/// <param name="pbData">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>The new property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the pbData parameter will vary, depending on which property is being set. This table shows the data
	/// type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Variable-length XML string. See the HotSpotProfile schema for more information.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/nf-wcmapi-wcmsetproperty DWORD WcmSetProperty( const GUID *pInterface,
	// LPCWSTR strProfileName, WCM_PROPERTY Property, PVOID pReserved, DWORD dwDataSize, const BYTE *pbData );
	[DllImport(Lib.Wcmapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wcmapi.h", MSDNShortId = "79985d5e-a6a1-447c-b12e-11c6022c19a6")]
	public static extern Win32Error WcmSetProperty([Optional] IntPtr pInterface, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? strProfileName,
		WCM_PROPERTY Property, [Optional] IntPtr pReserved, uint dwDataSize, [In, Optional] IntPtr pbData);

	/// <summary>The <c>WcmSetProperty</c> function sets the value of a WCM property.</summary>
	/// <typeparam name="T">The type of the value to set.</typeparam>
	/// <param name="pInterface">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>The interface to set. For global properties, this parameter is NULL.</para>
	/// </param>
	/// <param name="strProfileName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The profile name.</para>
	/// </param>
	/// <param name="Property">
	/// <para>Type: <c>WCM_PROPERTY</c></para>
	/// <para>The WCM property to set.</para>
	/// </param>
	/// <param name="data">
	/// <para>Type: <c>const BYTE*</c></para>
	/// <para>The new property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The type of data stored in the pbData parameter will vary, depending on which property is being set. This table shows the data
	/// type of each property.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Data type</term>
	/// </listheader>
	/// <item>
	/// <term>wcm_global_property_domain_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_minimize_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_roaming_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_global_property_powermanagement_policy</term>
	/// <term>WCM_POLICY_VALUE</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_connection_cost</term>
	/// <term>WCM_CONNECTION_COST_DATA</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_dataplan_status</term>
	/// <term>WCM_DATAPLAN_STATUS</term>
	/// </item>
	/// <item>
	/// <term>wcm_intf_property_hotspot_profile</term>
	/// <term>Variable-length XML string. See the HotSpotProfile schema for more information.</term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("wcmapi.h", MSDNShortId = "79985d5e-a6a1-447c-b12e-11c6022c19a6")]
	public static Win32Error WcmSetProperty<T>(WCM_PROPERTY Property, [Optional] Guid? pInterface, [Optional] string? strProfileName, in T data)
	{
		using var mem = data is string s ? new SafeCoTaskMemHandle(s) : SafeCoTaskMemHandle.CreateFromStructure(data);
		if (pInterface.HasValue)
			return WcmSetProperty(pInterface.Value, strProfileName, Property, default, mem.Size, mem);
		return WcmSetProperty(IntPtr.Zero, strProfileName, Property, default, mem.Size, mem);
	}

	/// <summary>The <c>WCM_BILLING_CYCLE_INFO</c> structure specifies information about the billing cycle.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_billing_cycle_info typedef struct WCM_BILLING_CYCLE_INFO
	// { FILETIME StartDate; WCM_TIME_INTERVAL Duration; BOOL Reset; } WCM_BILLING_CYCLE_INFO;
	[PInvokeData("wcmapi.h", MSDNShortId = "5cfcdfb7-aa33-4582-ba17-e1a305b830f5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_BILLING_CYCLE_INFO
	{
		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>Specifies the start date of the cycle.</para>
		/// </summary>
		public FILETIME StartDate;

		/// <summary>
		/// <para>Type: <c>WCM_TIME_INTERVAL</c></para>
		/// <para>Specifies the billing cycle duration.</para>
		/// </summary>
		public WCM_TIME_INTERVAL Duration;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// True if at the end of the billing cycle, a new billing cycle of the same duration will start. False if the service will
		/// terminate at the end of the billing cycle.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool Reset;
	}

	/// <summary>The <c>WCM_CONNECTION_COST_DATA</c> structure specifies information about a connection cost.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_connection_cost_data typedef struct
	// _WCM_CONNECTION_COST_DATA { DWORD ConnectionCost; WCM_CONNECTION_COST_SOURCE CostSource; } WCM_CONNECTION_COST_DATA, *PWCM_CONNECTION_COST_DATA;
	[PInvokeData("wcmapi.h", MSDNShortId = "18fcc708-74b1-408f-a7ee-64455742324d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_CONNECTION_COST_DATA
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the connection cost type.</para>
		/// <para>This must include one (and only one) of the following flags:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WCM_CONNECTION_COST_UNKNOWN 0x0</term>
		/// <term>Connection cost information is not available.</term>
		/// </item>
		/// <item>
		/// <term>WCM_CONNECTION_COST_UNRESTRICTED 0x1</term>
		/// <term>The connection is unlimited and has unrestricted usage constraints.</term>
		/// </item>
		/// <item>
		/// <term>WCM_CONNECTION_COST_FIXED 0x2</term>
		/// <term>Usage counts toward a fixed allotment of data which the user has already paid for (or agreed to pay for).</term>
		/// </item>
		/// <item>
		/// <term>WCM_CONNECTION_COST_VARIABLE 0x4</term>
		/// <term>The connection cost is on a per-byte basis.</term>
		/// </item>
		/// </list>
		/// <para>And may include any combination of the following flags:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WCM_CONNECTION_COST_OVERDATALIMIT 0x10000</term>
		/// <term>The connection has exceeded its data limit.</term>
		/// </item>
		/// <item>
		/// <term>WCM_CONNECTION_COST_CONGESTED 0x20000</term>
		/// <term>The connection is throttled due to high traffic.</term>
		/// </item>
		/// <item>
		/// <term>WCM_CONNECTION_COST_ROAMING 0x40000</term>
		/// <term>The connection is outside of the home network.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WCM_CONNECTION_COST ConnectionCost;

		/// <summary>
		/// <para>Type: <c>WCM_CONNECTION_COST_SOURCE</c></para>
		/// <para>Specifies the cost source.</para>
		/// </summary>
		public WCM_CONNECTION_COST_SOURCE CostSource;
	}

	/// <summary>The <c>WCM_DATAPLAN_STATUS</c> structure specifies subscription information for a network connection.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_dataplan_status typedef struct _WCM_DATAPLAN_STATUS {
	// WCM_USAGE_DATA UsageData; DWORD DataLimitInMegabytes; DWORD InboundBandwidthInKbps; DWORD OutboundBandwidthInKbps;
	// WCM_BILLING_CYCLE_INFO BillingCycle; DWORD MaxTransferSizeInMegabytes; DWORD Reserved; } WCM_DATAPLAN_STATUS, *PWCM_DATAPLAN_STATUS;
	[PInvokeData("wcmapi.h", MSDNShortId = "6ed0f05c-a9f8-49bb-9fb0-b91af8594d76")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_DATAPLAN_STATUS
	{
		/// <summary>
		/// <para>Type: <c>WCM_USAGE_DATA</c></para>
		/// <para>Contains usage data.</para>
		/// </summary>
		public WCM_USAGE_DATA UsageData;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the data limit, in megabytes.</para>
		/// </summary>
		public uint DataLimitInMegabytes;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the inbound bandwidth, in kilobits per second.</para>
		/// </summary>
		public uint InboundBandwidthInKbps;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the outbound bandwidth, in kilobits per second.</para>
		/// </summary>
		public uint OutboundBandwidthInKbps;

		/// <summary>
		/// <para>Type: <c>WCM_BILLING_CYCLE_INFO</c></para>
		/// <para>Contains information about the billing cycle.</para>
		/// </summary>
		public WCM_BILLING_CYCLE_INFO BillingCycle;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the maximum size of a file that can be transferred, in megabytes.</para>
		/// </summary>
		public uint MaxTransferSizeInMegabytes;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Reserved.</para>
		/// </summary>
		public uint Reserved;
	}

	/// <summary>The <c>WCM_POLICY_VALUE</c> structure contains information about the current value of a policy.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_policy_value typedef struct _WCM_POLICY_VALUE { BOOL
	// fValue; BOOL fIsGroupPolicy; } WCM_POLICY_VALUE, *PWCM_POLICY_VALUE;
	[PInvokeData("wcmapi.h", MSDNShortId = "0f259661-723b-4c76-8652-c86e0b8c9ebf")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_POLICY_VALUE
	{
		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the policy is enabled; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fValue;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if the current value was provided by Group Policy; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fIsGroupPolicy;
	}

	/// <summary>The <c>WCM_PROFILE_INFO</c> structure contains information about a specific profile.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_profile_info typedef struct _WCM_PROFILE_INFO { WCHAR
	// strProfileName[WCM_MAX_PROFILE_NAME]; GUID AdapterGUID; WCM_MEDIA_TYPE Media; } WCM_PROFILE_INFO, *PWCM_PROFILE_INFO;
	[PInvokeData("wcmapi.h", MSDNShortId = "bf917afa-c6c5-408a-bd34-b4a4c7b991b9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WCM_PROFILE_INFO
	{
		/// <summary>
		/// <para>Type: <c>WCHAR[WCM_MAX_PROFILE_NAME]</c></para>
		/// <para>The profile name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string strProfileName;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>The GUID of the adapter.</para>
		/// </summary>
		public Guid AdapterGUID;

		/// <summary>
		/// <para>Type: <c>WCM_MEDIA_TYPE</c></para>
		/// <para>The media type for the profile.</para>
		/// </summary>
		public WCM_MEDIA_TYPE Media;
	}

	/// <summary>The <c>WCM_PROFILE_INFO_LIST</c> structure contains a list of profiles in preferred order.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_profile_info_list typedef struct _WCM_PROFILE_INFO_LIST {
	// DWORD dwNumberOfItems; #if ... WCM_PROFILE_INFO *ProfileInfo[]; #else WCM_PROFILE_INFO ProfileInfo[1]; #endif }
	// WCM_PROFILE_INFO_LIST, *PWCM_PROFILE_INFO_LIST;
	[PInvokeData("wcmapi.h", MSDNShortId = "73ddb610-233a-470b-900d-ae62a1e7121a")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<WCM_PROFILE_INFO_LIST>), nameof(dwNumberOfItems))]
	[StructLayout(LayoutKind.Sequential)]
	public class WCM_PROFILE_INFO_LIST
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of profiles in the list.</para>
		/// </summary>
		public uint dwNumberOfItems;

		/// <summary>
		/// <para>Type: <c>WCM_PROFILE_INFO[1]</c></para>
		/// <para>Information about each profile.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WCM_PROFILE_INFO[] ProfileInfo = new WCM_PROFILE_INFO[1];
	}

	/// <summary>The <c>WCM_TIME_INTERVAL</c> structure defines a time interval.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_time_interval typedef struct _WCM_TIME_INTERVAL { WORD
	// wYear; WORD wMonth; WORD wDay; WORD wHour; WORD wMinute; WORD wSecond; WORD wMilliseconds; } WCM_TIME_INTERVAL;
	[PInvokeData("wcmapi.h", MSDNShortId = "7744a577-5f3d-4cdd-b74d-a1430ea20b37")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_TIME_INTERVAL
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Years.</para>
		/// </summary>
		public ushort wYear;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Months.</para>
		/// </summary>
		public ushort wMonth;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Days.</para>
		/// </summary>
		public ushort wDay;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Hours.</para>
		/// </summary>
		public ushort wHour;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Minutes.</para>
		/// </summary>
		public ushort wMinute;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Seconds.</para>
		/// </summary>
		public ushort wSecond;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>Milliseconds.</para>
		/// </summary>
		public ushort wMilliseconds;
	}

	/// <summary>The <c>WCM_USAGE_DATA</c> structure contains information related to connection usage.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcmapi/ns-wcmapi-wcm_usage_data typedef struct _WCM_USAGE_DATA { DWORD
	// UsageInMegabytes; FILETIME LastSyncTime; } WCM_USAGE_DATA, *PWCM_USAGE_DATA;
	[PInvokeData("wcmapi.h", MSDNShortId = "c6a483cf-d392-495f-854d-ccc782b30aa5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCM_USAGE_DATA
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The connection usage, in megabytes.</para>
		/// </summary>
		public uint UsageInMegabytes;

		/// <summary>
		/// <para>Type: <c>FILETIME</c></para>
		/// <para>Specifies the last time that usage information was reconciled with the carrier's billing system.</para>
		/// </summary>
		public FILETIME LastSyncTime;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for WCM memory that is disposed using <see cref="WcmFreeMemory"/>.</summary>
	public class SafeWcmMemory : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeWcmMemory"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeWcmMemory(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWcmMemory"/> class.</summary>
		private SafeWcmMemory() : base() { }

		/// <summary>Converts this memory to a string value.</summary>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory.</param>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public string? ToString(SizeT allocatedBytes) => StringHelper.GetString(handle, CharSet.Unicode, allocatedBytes);

		/// <summary>
		/// Marshals data from an unmanaged block of memory to a newly allocated managed object of the type specified by a generic type parameter.
		/// </summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory.</param>
		/// <returns>A managed object that contains the requested data.</returns>
		public T? ToStructure<T>(SizeT allocatedBytes = default) => handle.ToStructure<T>(allocatedBytes);

		/// <summary>Performs an implicit conversion from <see cref="SafeWcmMemory"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="mem">The memory.</param>
		/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
		public static implicit operator IntPtr(SafeWcmMemory mem) => mem.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WcmFreeMemory(handle); return true; }
	}

	internal class WcmMarshaler<T> : ICustomMarshaler
	{
		private WcmMarshaler(string _)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns></returns>
		public static ICustomMarshaler GetInstance(string cookie) => new WcmMarshaler<T>(cookie);

		void ICustomMarshaler.CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

		void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) => WcmFreeMemory(pNativeData);

		int ICustomMarshaler.GetNativeDataSize() => -1;

		IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData) => (typeof(T) == typeof(string) ? (object?)StringHelper.GetString(pNativeData, CharSet.Unicode) : pNativeData.ToStructure<T>()) ?? new object();
	}
}