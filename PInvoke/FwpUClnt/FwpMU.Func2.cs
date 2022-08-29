namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>
	/// <para>
	/// Requests the delivery of notifications regarding changes to particular dynamic keyword address (FW_DYNAMIC_KEYWORD_ADDRESS0) objects.
	/// Based on the flag passed in, notifications can be raised for only a subset of the addresses.
	/// </para>
	/// <para>For more info, and code examples, see Firewall dynamic keywords.</para>
	/// </summary>
	/// <param name="flags">
	/// <para>Type: _In_ <c>DWORD</c></para>
	/// <para>The following flags are defined in
	/// <code>fwpmu.h</code>
	/// .
	/// </para>
	/// <para>
	/// <c>FWPM_NOTIFY_ADDRESSES_AUTO_RESOLVE</c> indicates that notifications will be delivered only for objects that have the
	/// FW_DYNAMIC_KEYWORD_ADDRESS_FLAGS_AUTO_RESOLVE flag set.
	/// </para>
	/// <para>
	/// <c>FWPM_NOTIFY_ADDRESSES_NON_AUTO_RESOLVE</c> indicates that notifications will be delivered only for objects that don't have the
	/// FW_DYNAMIC_KEYWORD_ADDRESS_FLAGS_AUTO_RESOLVE flag set.
	/// </para>
	/// <para><c>FWPM_NOTIFY_ADDRESSES_AUTO_RESOLVE</c> indicates that notifications will be delivered for all dynamic keyword address objects.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: _In_ <c>FWPM_DYNAMIC_KEYWORD_CALLBACK0</c></para>
	/// <para>A pointer to a callback function that you implement, which will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: _In_opt_ <c>void*</c></para>
	/// <para>An optional context pointer. This pointer is passed to the callback function.</para>
	/// </param>
	/// <param name="subscriptionHandle">
	/// <para>Type: _Out_ <c>HANDLE*</c></para>
	/// <para>The address of a handle, which is populated with a handle to the newly created subscription.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>If the function succeeds, then it returns <c>ERROR_SUCCESS</c>. Otherwise, it returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The <c>flags</c> value is zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Notifications for AutoResolve dynamic keyword addresses are delivered when an object is added or deleted.</para>
	/// <para>Notifications for non-AutoResolve dynamic keyword addresses are delivered when an object is added, deleted, or updated.</para>
	/// <para>
	/// No data is provided to the callback function. You can use the <c>Enumeration</c> API if you need information about what has changed
	/// on the system.
	/// </para>
	/// <para>
	/// You're responsible for closing the handle when you no longer need subscription. You must do so by calling the
	/// FwpmDynamicKeywordUnsubscribe0 function.
	/// </para>
	/// <para>
	/// Your implementation of FWPM_DYNAMIC_KEYWORD_CALLBACK0 should react to changes in dynamic keyword address objects quickly, because it
	/// is scheduled on a ThreadPool thread, and could affect other wait operations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmdynamickeywordsubscribe0 DWORD FwpmDynamicKeywordSubscribe0(
	// DWORD flags, FWPM_DYNAMIC_KEYWORD_CALLBACK0 callback, void *context, HANDLE *subscriptionHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmDynamicKeywordSubscribe0")]
	public static extern Win32Error FwpmDynamicKeywordSubscribe0(FWPM_NOTIFY flags, [In] FWPM_DYNAMIC_KEYWORD_CALLBACK0 callback,
		[In, Optional] IntPtr context, out HFWPMDYNKEYSUB subscriptionHandle);

	/// <summary>
	/// <para>
	/// Cancels the delivery of notifications regarding changes to particular dynamic keyword address (FW_DYNAMIC_KEYWORD_ADDRESS0) objects.
	/// </para>
	/// <para>For more info, and code examples, see Firewall dynamic keywords.</para>
	/// </summary>
	/// <param name="subscriptionHandle">
	/// <para>Type: _In_ <c>HANDLE</c></para>
	/// <para>The subscription handle that was returned from FwpmDynamicKeywordSubscribe0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>If the function succeeds, then it returns <c>ERROR_SUCCESS</c>.</para>
	/// </returns>
	/// <remarks><c>FwpmDynamicKeywordUnsubscribe0</c> waits for all callback functions to complete before returning.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmdynamickeywordunsubscribe0 DWORD FwpmDynamicKeywordUnsubscribe0(
	// HANDLE subscriptionHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmDynamicKeywordUnsubscribe0")]
	public static extern Win32Error FwpmDynamicKeywordUnsubscribe0(HFWPMDYNKEYSUB subscriptionHandle);

	/// <summary>The <c>FwpmEngineGetOption0</c> function retrieves a filter engine option.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="option">
	/// <para>Type: FWPM_ENGINE_OPTION</para>
	/// <para>The option to be retrieved.</para>
	/// </param>
	/// <param name="value">
	/// <para>Type: FWP_VALUE0**</para>
	/// <para>The option value. The data type contained in the <c>value</c> parameter will be <c>FWP_UINT32</c>.</para>
	/// <para>If <c>option</c> is <c>FWPM_ENGINE_COLLECT_NET_EVENTS</c>, <c>value</c> will be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Network events are not being collected.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Network events are being collected.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS</c>, <c>value</c> will be a bitwise combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_MCAST</c> 1</term>
	/// <term>Inbound multicast network events are being collected.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_BCAST</c> 2</term>
	/// <term>Inbound broadcast network events are not being collected.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_PACKET_QUEUING</c> (available only in Windows 8 and Windows Server 2012), <c>value</c> will be one
	/// of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_NONE</c> 0</term>
	/// <term>No packet queuing is enabled.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_INBOUND</c> 1</term>
	/// <term>Inbound packet queuing is enabled.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_OUTBOUND</c> 2</term>
	/// <term>Outbound packet queuing is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_MONITOR_IPSEC_CONNECTIONS</c> (available only in Windows 8 and Windows Server 2012), <c>value</c>
	/// will be one of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The IPsec Connection Monitoring feature is disabled. No IPsec connection events or notifications are being logged.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The IPsec Connection Monitoring feature is enabled. New IPsec connection events and notifications are being logged.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_TXN_WATCHDOG_TIMEOUT_IN_MSEC</c> (available only in Windows 8 and Windows Server 2012),
	/// <c>value</c> will be the time in milliseconds that specifies the maximum duration for a single WFP transaction. Transactions taking
	/// longer than this duration will trigger a watchdog event.
	/// </para>
	/// <para>The <c>FWPM_ENGINE_NAME_CACHE</c> option is reserved for internal use.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The option was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter engine. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmEngineGetOption0</c> is a specific implementation of FwpmEngineGetOption. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example illustrates the use of <c>FwpmEngineGetOption0</c> to determine if network events are being collected.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") void main() { HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; FWPM_ENGINE_OPTION option = FWPM_ENGINE_COLLECT_NET_EVENTS; FWP_VALUE0* fwpValue = NULL; result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) { printf("FwpmEngineOpen0 failed.\n"); return; } result = FwpmEngineGetOption0( engineHandle, option, &amp;fwpValue); if (result != ERROR_SUCCESS) { printf("FwpmEngineGetOption0 failed.\n"); return; } else if(fwpValue-&gt;type == FWP_UINT32) { if(fwpValue-&gt;uint32 == 1 ) printf("Network events are being collected.\n"); else printf("Network events are NOT being collected.\n"); } else printf("Unexpected data type received.\n"); FwpmFreeMemory0((void**)&amp;fwpValue); return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmenginegetoption0 DWORD FwpmEngineGetOption0( [in] HFWPENG
	// engineHandle, [in] FWPM_ENGINE_OPTION option, [out] FWP_VALUE0 **value );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineGetOption0")]
	public static extern Win32Error FwpmEngineGetOption0([In] HFWPENG engineHandle, [In] FWPM_ENGINE_OPTION option, out SafeFwpmMem value);

	/// <summary>The <c>FwpmEngineGetOption0</c> function retrieves a filter engine option.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="option">
	/// <para>Type: FWPM_ENGINE_OPTION</para>
	/// <para>The option to be retrieved.</para>
	/// </param>
	/// <param name="value">
	/// <para>Type: FWP_VALUE0**</para>
	/// <para>The option value. The data type contained in the <c>value</c> parameter will be <c>FWP_UINT32</c>.</para>
	/// <para>If <c>option</c> is <c>FWPM_ENGINE_COLLECT_NET_EVENTS</c>, <c>value</c> will be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Network events are not being collected.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Network events are being collected.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS</c>, <c>value</c> will be a bitwise combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_MCAST</c> 1</term>
	/// <term>Inbound multicast network events are being collected.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_BCAST</c> 2</term>
	/// <term>Inbound broadcast network events are not being collected.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_PACKET_QUEUING</c> (available only in Windows 8 and Windows Server 2012), <c>value</c> will be one
	/// of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_NONE</c> 0</term>
	/// <term>No packet queuing is enabled.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_INBOUND</c> 1</term>
	/// <term>Inbound packet queuing is enabled.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_OUTBOUND</c> 2</term>
	/// <term>Outbound packet queuing is enabled.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_MONITOR_IPSEC_CONNECTIONS</c> (available only in Windows 8 and Windows Server 2012), <c>value</c>
	/// will be one of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The IPsec Connection Monitoring feature is disabled. No IPsec connection events or notifications are being logged.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The IPsec Connection Monitoring feature is enabled. New IPsec connection events and notifications are being logged.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>option</c> is <c>FWPM_ENGINE_TXN_WATCHDOG_TIMEOUT_IN_MSEC</c> (available only in Windows 8 and Windows Server 2012),
	/// <c>value</c> will be the time in milliseconds that specifies the maximum duration for a single WFP transaction. Transactions taking
	/// longer than this duration will trigger a watchdog event.
	/// </para>
	/// <para>The <c>FWPM_ENGINE_NAME_CACHE</c> option is reserved for internal use.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The option was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter engine. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmEngineGetOption0</c> is a specific implementation of FwpmEngineGetOption. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example illustrates the use of <c>FwpmEngineGetOption0</c> to determine if network events are being collected.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") void main() { HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; FWPM_ENGINE_OPTION option = FWPM_ENGINE_COLLECT_NET_EVENTS; FWP_VALUE0* fwpValue = NULL; result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) { printf("FwpmEngineOpen0 failed.\n"); return; } result = FwpmEngineGetOption0( engineHandle, option, &amp;fwpValue); if (result != ERROR_SUCCESS) { printf("FwpmEngineGetOption0 failed.\n"); return; } else if(fwpValue-&gt;type == FWP_UINT32) { if(fwpValue-&gt;uint32 == 1 ) printf("Network events are being collected.\n"); else printf("Network events are NOT being collected.\n"); } else printf("Unexpected data type received.\n"); FwpmFreeMemory0((void**)&amp;fwpValue); return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmenginegetoption0 DWORD FwpmEngineGetOption0( [in] HFWPENG
	// engineHandle, [in] FWPM_ENGINE_OPTION option, [out] FWP_VALUE0 **value );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineGetOption0")]
	public static Win32Error FwpmEngineGetOption0<TOut>([In] HFWPENG engineHandle, [In] FWPM_ENGINE_OPTION option, out TOut value) where TOut : struct
	{
		Win32Error err = FwpmEngineGetOption0(engineHandle, option, out SafeFwpmMem val);
		value = val.ToStructure<TOut>().GetValueOrDefault();
		return err;
	}

	/// <summary>The <c>FwpmEngineGetSecurityInfo0</c> function retrieves a copy of the security descriptor for the filter engine.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to retrieve.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The owner security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The primary group security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The discretionary access control list (DACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The system access control list (SACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="securityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR*</c></para>
	/// <para>The returned security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned <c>securityDescriptor</c> parameter must be freed through a call to FwpmFreeMemory0. The other four (optional) returned
	/// parameters must not be freed, as they point to addresses within the <c>securityDescriptor</c> parameter.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 GetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>GetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmEngineGetSecurityInfo0</c> is a specific implementation of FwpmEngineGetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example illustrates initialization of a security descriptor object using <c>FwpmEngineGetSecurityInfo0</c>.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") void main() { HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; PSECURITY_DESCRIPTOR securityDescriptor; SECURITY_INFORMATION securityInfo = OWNER_SECURITY_INFORMATION; // Several functions that use the SECURITY_DESCRIPTOR structure require that this // structure be aligned on a valid pointer boundary in memory. These boundaries // vary depending on the type of processor used. securityDescriptor = (PSECURITY_DESCRIPTOR) malloc(sizeof(SECURITY_DESCRIPTOR)); result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) { printf("FwpmEngineOpen0 failed.\n"); return; } result = FwpmEngineGetSecurityInfo0( engineHandle, securityInfo, NULL, NULL, NULL, NULL, &amp;securityDescriptor); if (result != ERROR_SUCCESS) { printf("FwpmEngineGetSecurityInfo0 failed.\n"); return; } return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmenginegetsecurityinfo0 DWORD FwpmEngineGetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out,
	// optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineGetSecurityInfo0")]
	public static extern Win32Error FwpmEngineGetSecurityInfo0([In] HFWPENG engineHandle, [In] SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>The <c>FwpmEngineSetOption0</c> function changes the filter engine settings.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="option">
	/// <para>Type: FWPM_ENGINE_OPTION</para>
	/// <para>The option to be set.</para>
	/// </param>
	/// <param name="newValue">
	/// <para>Type: FWP_VALUE0*</para>
	/// <para>The new option value. The data type contained in the <c>newValue</c> parameter should be <c>FWP_UINT32</c>.</para>
	/// <para>When <c>option</c> is <c>FWPM_ENGINE_COLLECT_NET_EVENTS</c>, <c>newValue</c> should be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Do not collect network events.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>Collect network events. This is the default setting.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When <c>option</c> is <c>FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS</c>, <c>newValue</c> should be either 0 (zero) or a bitwise
	/// combination of the following values.
	/// </para>
	/// <para>
	/// <c>Note</c> If <c>newValue</c> is 0 the collection of inbound multicast and broadcast events is disabled. This is the default setting.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_MCAST</c> 1</term>
	/// <term>Collect inbound multicast network events.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_NET_EVENT_KEYWORD_INBOUND_BCAST</c> 2</term>
	/// <term>Collect inbound broadcast network events.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When <c>option</c> is <c>FWPM_ENGINE_PACKET_QUEUING</c> (available only in Windows 8 and Windows Server 2012), <c>newValue</c> should
	/// be one of the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_NONE</c> 0</term>
	/// <term>Do not enable packet queuing.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_INBOUND</c> 1</term>
	/// <term>Enable inbound packet queuing.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_ENGINE_OPTION_PACKET_QUEUE_OUTBOUND</c> 2</term>
	/// <term>Enable outbound packet queuing.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When <c>option</c> is <c>FWPM_ENGINE_MONITOR_IPSEC_CONNECTIONS</c> (available only in Windows 8 and Windows Server 2012),
	/// <c>newValue</c> should be the following. ( <c>FwpmEngineSetOption0</c> may be used to enable connections, but will fail with
	/// <c>FWP_E_STILL_ON ERROR</c> when attempting to disable it.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// The IPsec Connection Monitoring feature will be enabled. New IPsec connection events will be logged as well as notifications sent.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// When <c>option</c> is <c>FWPM_ENGINE_TXN_WATCHDOG_TIMEOUT_IN_MSEC</c> (available only in Windows 8 and Windows Server 2012),
	/// <c>newValue</c> should be the time in milliseconds that specifies the maximum duration for a single WFP transaction. Transactions
	/// taking longer than this duration will trigger a watchdog event.
	/// </para>
	/// <para>The <c>FWPM_ENGINE_NAME_CACHE</c> option is reserved for internal use.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The option was set successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// This function cannot be called from within a dynamic session. It will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See Object
	/// Management for more information about sessions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_WRITE access to the filter engine. See Access Control for more information.</para>
	/// <para>The default settings for network event collection are as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Outbound, all (unicast, multicast, and broadcast) events are collected.</term>
	/// </item>
	/// <item>
	/// <term>Inbound, only unicast events are collected.</term>
	/// </item>
	/// </list>
	/// <para>Network event collection settings persist across reboots.</para>
	/// <para>To collect inbound broadcast and/or multicast network events,</para>
	/// <list type="number">
	/// <item>
	/// <term>Call <c>FwpmEngineSetOption0</c> with <c>option</c> set to FWPM_ENGINE_COLLECT_NET_EVENTS and <c>newValue</c> set to 1.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call <c>FwpmEngineSetOption0</c> with <c>option</c> set to FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS and <c>newValue</c> parameter set
	/// to FWPM_NET_EVENT_KEYWORD_INBOUND_MCAST and/or FWPM_NET_EVENT_KEYWORD_INBOUND_BCAST.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To stop collecting inbound broadcast and/or multicast network events,</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Call <c>FwpmEngineSetOption0</c> with <c>option</c> set to FWPM_ENGINE_NET_EVENT_MATCH_ANY_KEYWORDS and <c>newValue</c> parameter set
	/// to 0 (zero).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Disabling and re-enabling of network event collection (FWPM_ENGINE_COLLECT_NET_EVENTS) does not reset the collection of inbound
	/// broadcast and multicast events.
	/// </para>
	/// <para>
	/// <c>FwpmEngineSetOption0</c> is a specific implementation of FwpmEngineSetOption. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmenginesetoption0 DWORD FwpmEngineSetOption0( [in] HFWPENG
	// engineHandle, [in] FWPM_ENGINE_OPTION option, [in] const FWP_VALUE0 *newValue );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineSetOption0")]
	public static extern Win32Error FwpmEngineSetOption0([In] HFWPENG engineHandle, [In] FWPM_ENGINE_OPTION option, in FWP_VALUE0 newValue);

	/// <summary>
	/// The <c>FwpmEngineSetSecurityInfo0</c> function sets specified security information in the security descriptor of the filter engine.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to set.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The owner's security identifier (SID) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The group's SID to be set in the security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The discretionary access control list (DACL) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The system access control list (SACL) to be set in the security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was set successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>FwpmEngineSetSecurityInfo0</c> cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See
	/// Object Management for more information about transactions.
	/// </para>
	/// <para>
	/// <c>FwpmEngineSetSecurityInfo0</c> behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access
	/// rights as described in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmEngineSetSecurityInfo0</c> is a specific implementation of FwpmEngineSetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmenginesetsecurityinfo0 DWORD FwpmEngineSetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup,
	// [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineSetSecurityInfo0")]
	public static extern Win32Error FwpmEngineSetSecurityInfo0([In] HFWPENG engineHandle, [In] SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>The <c>FwpmFilterAdd0</c> function adds a new filter object to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="filter">
	/// <para>Type: <c>FWPM_FILTER0</c>*</para>
	/// <para>The filter object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>SECURITY_DESCRIPTOR</c></para>
	/// <para>Security information about the filter object.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c>*</para>
	/// <para>The runtime identifier for this filter.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0</term>
	/// <term>The filter was successfully added.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_SECURITY_DESCR 0x8007053A</term>
	/// <term>The security descriptor structure is invalid. Or, a filter condition contains a security descriptor in absolute format.</term>
	/// </item>
	/// <item>
	/// <term>FWP_E_CALLOUT_NOTIFICATION_FAILED 0x80320037</term>
	/// <term>The caller added a callout filter and the callout returned an error from its notification routine.</term>
	/// </item>
	/// <item>
	/// <term>FWP_E_* error code 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term>RPC_* error code 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>FwpmFilterAdd0</c> adds the filter to the specified sub-layer at every filtering layer in the system.</para>
	/// <para>Some fields in the FWPM_FILTER0 structure are assigned by the system, not the caller, and are ignored in the call to <c>FwpmFilterAdd0</c>.</para>
	/// <para>If the caller supplies a <c>NULL</c> security descriptor, the system will assign a default security descriptor.</para>
	/// <para>
	/// To block connections to particular locations, add a FWP_ACTION_BLOCK filter specifying the local address at the
	/// FWPM_LAYER_ALE_AUTH_CONNECT_V* layer, or add a <c>FWP_ACTION_BLOCK</c> filter without specifying the local address at the
	/// <c>FWPM_LAYER_ALE_RESOURCE_ASSIGNMENT_V</c>* layer.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// If a local address is specified at the resource assignment layer, an implicit bind would succeed because address, address type, and
	/// port may come back as FWP_EMPTY.
	/// </para>
	/// </para>
	/// <para>
	/// The FWPM_FILTER0 structure can label a filter as a boot-time or persistent filter. Boot-time filters are added to the Base Filtering
	/// Engine (BFE) when the TCP/IP driver starts, and are removed once the BFE finishes initialization. Persistent objects are added when
	/// the BFE starts.
	/// </para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>The caller needs the following access rights:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>FWPM_ACTRL_ADD access to the filter's container</term>
	/// </item>
	/// <item>
	/// <term>FWPM_ACTRL_ADD_LINK access to the provider (if any)</term>
	/// </item>
	/// <item>
	/// <term>FWPM_ACTRL_ADD_LINK access to the applicable layer</term>
	/// </item>
	/// <item>
	/// <term>FWPM_ACTRL_ADD_LINK access to the applicable sub-layer</term>
	/// </item>
	/// <item>
	/// <term>FWPM_ACTRL_ADD_LINK access to the callout (if any)</term>
	/// </item>
	/// <item>
	/// <term>FWPM_ACTRL_ADD_LINK access to the provider context (if any).</term>
	/// </item>
	/// </list>
	/// <para>See Access Control for more information.</para>
	/// <para>To add a filter that references a callout, invoke the functions in the following order.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Call FwpsCalloutRegister0 (documented in the Windows Driver Kit (WDK)), to register the callout with the filter engine.</term>
	/// </item>
	/// <item>
	/// <term>Call FwpmCalloutAdd0 to add the callout to the system.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>FwpmFilterAdd0</c> to add the filter that references the callout to the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// By default filters that reference callouts that have been added but have not yet registered with the filter engine are treated as
	/// Block filters.
	/// </para>
	/// <para>
	/// <c>FwpmFilterAdd0</c> is a specific implementation of FwpmFilterAdd. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following C++ example shows how to initialize and add a filter using <c>FwpmFilterAdd0</c> that specifically blocks traffic on IP
	/// V4 for all applications.
	/// </para>
	/// <para>
	/// <code> // Add filter to block traffic on IP V4 for all applications. // FWPM_FILTER0 fwpFilter; FWPM_SUBLAYER0 fwpFilterSubLayer; RtlZeroMemory(&amp;fwpFilter, sizeof(FWPM_FILTER0)); fwpFilter.layerKey = FWPM_LAYER_ALE_AUTH_RECV_ACCEPT_V4; fwpFilter.action.type = FWP_ACTION_BLOCK; if (&amp;fwpFilterSubLayer.subLayerKey != NULL) fwpFilter.subLayerKey = fwpFilterSubLayer.subLayerKey; fwpFilter.weight.type = FWP_EMPTY; // auto-weight. fwpFilter.numFilterConditions = 0; // this applies to all application traffic fwpFilter.displayData.name = L"Receive/Accept Layer Block"; fwpFilter.displayData.description = L"Filter to block all inbound connections."; printf("Adding filter to block all inbound connections.\n"); result = FwpmFilterAdd0(engineHandle, &amp;fwpFilter, NULL, NULL); if (result != ERROR_SUCCESS) printf("FwpmFilterAdd0 failed. Return value: %d.\n", result); else printf("Filter added successfully.\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilteradd0 DWORD FwpmFilterAdd0( [in] HFWPENG engineHandle, [in]
	// const FWPM_FILTER0 *filter, [in, optional] PSECURITY_DESCRIPTOR sd, [out, optional] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterAdd0")]
	public static extern Win32Error FwpmFilterAdd0([In] HFWPENG engineHandle, in FWPM_FILTER0 filter, [In, Optional] PSECURITY_DESCRIPTOR sd,
		out ulong id);

	/// <summary>The <c>FwpmFilterCreateEnumHandle0</c> function creates a handle used to enumerate a set of filter objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_FILTER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>The handle for filter enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was created successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all filters are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmFilterCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmFilterCreateEnumHandle0</c> and FwpmFilterEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmFilterDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the filters' containers and <c>FWPM_ACTRL_READ</c> access to the filters. Only filters to
	/// which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmFilterCreateEnumHandle0</c> is a specific implementation of FwpmFilterCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltercreateenumhandle0 DWORD FwpmFilterCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const FWPM_FILTER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterCreateEnumHandle0")]
	public static extern Win32Error FwpmFilterCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_FILTER_ENUM_TEMPLATE0 enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmFilterCreateEnumHandle0</c> function creates a handle used to enumerate a set of filter objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_FILTER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>The handle for filter enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was created successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all filters are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmFilterCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmFilterCreateEnumHandle0</c> and FwpmFilterEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmFilterDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the filters' containers and <c>FWPM_ACTRL_READ</c> access to the filters. Only filters to
	/// which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmFilterCreateEnumHandle0</c> is a specific implementation of FwpmFilterCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltercreateenumhandle0 DWORD FwpmFilterCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const FWPM_FILTER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterCreateEnumHandle0")]
	public static extern Win32Error FwpmFilterCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmFilterDeleteById0</c> function removes a filter object from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>Runtime identifier for the object being removed from the system. This value is returned by the FwpmFilterAdd0 function.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filter was successfully deleted.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// This function can be called within a dynamic session if the corresponding object was added during the same session. If this function
	/// is called for an object that was added during a different dynamic session, it will fail with <c>FWP_E_WRONG_SESSION</c>. If this
	/// function is called for an object that was not added during a dynamic session, it will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>.
	/// </para>
	/// <para>The caller needs DELETE access to the filter. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterDeleteById0</c> is a specific implementation of FwpmFilterDeleteById. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterdeletebyid0 DWORD FwpmFilterDeleteById0( [in] HFWPENG
	// engineHandle, [in] UINT64 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterDeleteById0")]
	public static extern Win32Error FwpmFilterDeleteById0([In] HFWPENG engineHandle, ulong id);

	/// <summary>The <c>FwpmFilterDeleteByKey0</c> function removes a filter object from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the object being removed from the system. This is the same GUID that was specified when the application called
	/// FwpmFilterAdd0 for this object.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filter was successfully deleted.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// This function can be called within a dynamic session if the corresponding object was added during the same session. If this function
	/// is called for an object that was added during a different dynamic session, it will fail with <c>FWP_E_WRONG_SESSION</c>. If this
	/// function is called for an object that was not added during a dynamic session, it will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>.
	/// </para>
	/// <para>The caller needs DELETE access to the filter. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterDeleteByKey0</c> is a specific implementation of FwpmFilterDeleteByKey. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterdeletebykey0 DWORD FwpmFilterDeleteByKey0( [in] HFWPENG
	// engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterDeleteByKey0")]
	public static extern Win32Error FwpmFilterDeleteByKey0([In] HFWPENG engineHandle, in Guid key);

	/// <summary>The <c>FwpmFilterDestroyEnumHandle0</c> function frees a handle returned by FwpmFilterCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a filter enumeration created by a call to FwpmFilterCreateEnumHandle0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was successfully deleted.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>FwpmFilterDestroyEnumHandle0</c> is a specific implementation of FwpmFilterDestroyEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterdestroyenumhandle0 DWORD FwpmFilterDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterDestroyEnumHandle0")]
	public static extern Win32Error FwpmFilterDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmFilterEnum0</c> function returns the next page of results from the filter enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a filter enumeration created by a call to FwpmFilterCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of filter objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_FILTER0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of filter objects returned.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filters were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the <c>numEntriesReturned</c> is less than the <c>numEntriesRequested</c>, the enumeration is exhausted.</para>
	/// <para>The returned array of entries (but not the individual entries themselves) must be freed by a call to FwpmFreeMemory0.</para>
	/// <para>A subsequent call using the same enumeration handle will return the next set of items following those in the last output buffer.</para>
	/// <para><c>FwpmFilterEnum0</c> works on a snapshot of the filters taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmFilterEnum0</c> is a specific implementation of FwpmFilterEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterenum0 DWORD FwpmFilterEnum0( [in] HFWPENG engineHandle,
	// [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_FILTER0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterEnum0")]
	public static extern Win32Error FwpmFilterEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>The <c>FwpmFilterEnum0</c> function returns the next page of results from the filter enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_FILTER0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_FILTER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filters were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all filters are returned.</para>
	/// <para><c>FwpmFilterEnum0</c> works on a snapshot of the filters taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmFilterEnum0</c> is a specific implementation of FwpmFilterEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterenum0 DWORD FwpmFilterEnum0( [in] HFWPENG engineHandle,
	// [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_FILTER0 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterEnum0")]
	public static Win32Error FwpmFilterEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_FILTER0> entries, FWPM_FILTER_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmFilterCreateEnumHandle0, FwpmFilterEnum0, FwpmFilterDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmFilterGetById0</c> function retrieves a filter object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A runtime identifier for the desired object. This identifier was received from the system when the application called FwpmFilterAdd0
	/// for this object.
	/// </para>
	/// </param>
	/// <param name="filter">
	/// <para>Type: FWPM_FILTER0**</para>
	/// <para>The filter information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filter was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterGetById0</c> is a specific implementation of FwpmFilterGetById. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltergetbyid0 DWORD FwpmFilterGetById0( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [out] FWPM_FILTER0 **filter );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterGetById0")]
	public static Win32Error FwpmFilterGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<FWPM_FILTER0> filter) =>
		FwpmGenericGetById(FwpmFilterGetById0, engineHandle, id, out filter);

	/// <summary>The <c>FwpmFilterGetByKey0</c> function retrieves a filter object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the filter. This GUID was specified in the <c>filterKey</c> member of the <c>filter</c> parameter when the
	/// application called FwpmFilterAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="filter">
	/// <para>Type: FWPM_FILTER0**</para>
	/// <para>The filter information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The filter was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterGetByKey0</c> is a specific implementation of FwpmFilterGetByKey. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltergetbykey0 DWORD FwpmFilterGetByKey0( [in] HFWPENG
	// engineHandle, [in] const GUID *key, [out] FWPM_FILTER0 **filter );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterGetByKey0")]
	public static Win32Error FwpmFilterGetByKey0([In] HFWPENG engineHandle, in Guid key, out SafeFwpmStruct<FWPM_FILTER0> filter) =>
		FwpmGenericGetByKey(FwpmFilterGetByKey0, engineHandle, key, out filter);

	/// <summary>The <c>FwpmFilterGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a filter object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the filter. This GUID was specified in the <c>filterKey</c> member of the <c>filter</c> parameter when the
	/// application called FwpmFilterAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to retrieve.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The owner security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The primary group security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The discretionary access control list (DACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The system access control list (SACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="securityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR*</c></para>
	/// <para>The returned security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// filters container.
	/// </para>
	/// <para>
	/// The returned <c>securityDescriptor</c> parameter must be freed through a call to FwpmFreeMemory0. The other four (optional) returned
	/// parameters must not be freed, as they point to addresses within the <c>securityDescriptor</c> parameter.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 GetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>GetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmFilterGetSecurityInfoByKey0</c> is a specific implementation of FwpmFilterGetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltergetsecurityinfobykey0 DWORD
	// FwpmFilterGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmFilterGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmFilterSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a filter object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the filter. This GUID was specified in the <c>filterKey</c> member of the <c>filter</c> parameter when the
	/// application called FwpmFilterAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to set.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The owner's security identifier (SID) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The group's SID to be set in the security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The discretionary access control list (DACL) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The system access control list (SACL) to be set in the security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was set successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// filters container.
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// This function can be called within a dynamic session if the corresponding object was added during the same session. If this function
	/// is called for an object that was added during a different dynamic session, it will fail with <c>FWP_E_WRONG_SESSION</c>. If this
	/// function is called for an object that was not added during a dynamic session, it will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmFilterSetSecurityInfoByKey0</c> is a specific implementation of FwpmFilterSetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltersetsecurityinfobykey0 DWORD
	// FwpmFilterSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmFilterSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmFilterSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a particular filter.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_FILTER_SUBSCRIPTION0*</para>
	/// <para>The notifications to be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_FILTER_CHANGE_CALLBACK0</c></para>
	/// <para>The function pointer that will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the change.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle to the newly created subscription.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The subscription was created successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Subscribers do not receive notifications for changes made with the same session handle used to subscribe. This is because subscribers
	/// only need to see changes made by others since they already know which changes they made themselves.
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the filter's container and <c>FWPM_ACTRL_READ</c> access to the filter. The
	/// subscriber will only get notifications for filters to which it has <c>FWPM_ACTRL_READ</c> access. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmFilterSubscribeChanges0</c> is a specific implementation of FwpmFilterSubscribeChanges. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltersubscribechanges0 DWORD FwpmFilterSubscribeChanges0( [in]
	// HFWPENG engineHandle, [in] const FWPM_FILTER_SUBSCRIPTION0 *subscription, [in] FWPM_FILTER_CHANGE_CALLBACK0 callback, [in, optional]
	// void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterSubscribeChanges0")]
	public static extern Win32Error FwpmFilterSubscribeChanges0([In] HFWPENG engineHandle, in FWPM_FILTER_SUBSCRIPTION0 subscription,
		[In] FWPM_FILTER_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMFILTERSUB changeHandle);

	/// <summary>The <c>FwpmFilterSubscriptionsGet0</c> function retrieves an array of all the current filter change notification subscriptions.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_FILTER_SUBSCRIPTION0***</para>
	/// <para>The current filter change notification subscriptions.</para>
	/// </param>
	/// <param name="numEntries">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of entries returned.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The subscriptions were retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The returned array (but not the individual entries in the array) must be freed through a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterSubscriptionsGet0</c> is a specific implementation of FwpmFilterSubscriptionsGet. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltersubscriptionsget0 DWORD FwpmFilterSubscriptionsGet0( [in]
	// HFWPENG engineHandle, [out] FWPM_FILTER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterSubscriptionsGet0")]
	public static extern Win32Error FwpmFilterSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>The <c>FwpmFilterSubscriptionsGet0</c> function retrieves an array of all the current filter change notification subscriptions.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_FILTER_SUBSCRIPTION0***</para>
	/// <para>The current filter change notification subscriptions.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The subscriptions were retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The returned array (but not the individual entries in the array) must be freed through a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the filter's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmFilterSubscriptionsGet0</c> is a specific implementation of FwpmFilterSubscriptionsGet. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfiltersubscriptionsget0 DWORD FwpmFilterSubscriptionsGet0( [in]
	// HFWPENG engineHandle, [out] FWPM_FILTER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterSubscriptionsGet0")]
	public static Win32Error FwpmFilterSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_FILTER_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmFilterSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmFilterUnsubscribeChanges0</c> function is used to cancel a filter change subscription and stop receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed change notification. This is the handle returned by the call to FwpmFilterSubscribeChanges0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The subscription was deleted successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the callback is currently being invoked, this function will not return until it completes. Thus, when calling this function, you
	/// must not hold any locks that the callback may also try to acquire lest you deadlock.
	/// </para>
	/// <para>
	/// It is not necessary to unsubscribe before closing a session; all subscriptions are automatically canceled when the subscribing
	/// session terminates.
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// <c>FwpmFilterUnsubscribeChanges0</c> is a specific implementation of FwpmFilterUnsubscribeChanges. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfilterunsubscribechanges0 DWORD FwpmFilterUnsubscribeChanges0(
	// [in] HFWPENG engineHandle, [in] HANDLE changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFilterUnsubscribeChanges0")]
	public static extern Win32Error FwpmFilterUnsubscribeChanges0([In] HFWPENG engineHandle, [In] HFWPMFILTERSUB changeHandle);

	/// <summary>The <c>FwpmGetAppIdFromFileName0</c> function retrieves an application identifier from a file name.</summary>
	/// <param name="fileName">
	/// <para>Type: <c>const wchar_t*</c></para>
	/// <para>File name from which the application identifier will be retrieved.</para>
	/// </param>
	/// <param name="appId">
	/// <para>Type: FWP_BYTE_BLOB**</para>
	/// <para>The retrieved application identifier.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The application identifier was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>
	/// <c>FwpmGetAppIdFromFileName0</c> is a specific implementation of FwpmGetAppIdFromFileName. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example shows how to retrieve an application identifier using <c>FwpmGetAppIdFromFileName0</c>.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") // Hard-coded file name for demonstration purposes. #define FILE_PATH1 L"C:\\Program Files\\SomeAppFolder\\SomeApplication.exe" int main() { DWORD result = ERROR_SUCCESS; FWP_BYTE_BLOB *fwpApplicationByteBlob = NULL; printf("Retrieving Id for application to allow through firewall.\n"); result = FwpmGetAppIdFromFileName0(FILE_PATH1, &amp;fwpApplicationByteBlob); if (result != ERROR_SUCCESS) { printf("FwpmGetAppIdFromFileName failed (%d).\n", result); return result; } else { printf("The Id is: %d\n", fwpApplicationByteBlob-&gt;data); } return 0; } // ----------------------------------------------------------------------</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmgetappidfromfilename0 DWORD FwpmGetAppIdFromFileName0( [in]
	// PCWSTR fileName, [out] FWP_BYTE_BLOB **appId );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmGetAppIdFromFileName0")]
	public static Win32Error FwpmGetAppIdFromFileName0([MarshalAs(UnmanagedType.LPWStr)] string fileName, out byte[] appId)
	{
		Win32Error err = FwpmGetAppIdFromFileName0(fileName, out SafeFwpmMem mem);
		FWP_BYTE_BLOB blob = mem.ToStructure<FWP_BYTE_BLOB>().GetValueOrDefault();
		appId = err.Succeeded ? blob.data.ToArray<byte>((int)blob.size) : null;
		return err;
	}

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd1</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd1</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, FwpmIPsecTunnelAdd0 is
	/// available. For Windows 8, FwpmIPsecTunnelAdd2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPsec tunnel flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_POINT_TO_POINT</c></term>
	/// <term>Adds a point-to-point tunnel to the system.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_ENABLE_VIRTUAL_IF_TUNNELING</c></term>
	/// <term>Enables virtual interface-based IPsec tunnel mode.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1*</para>
	/// <para>The Quick Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="numFilterConditions">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of filter conditions present in the <c>filterConditions</c> parameter.</para>
	/// </param>
	/// <param name="filterConditions">
	/// <para>Type: <c>const FWPM_FILTER_CONDITION0*</c></para>
	/// <para>Array of filter conditions that describe the traffic which should be tunneled by IPsec.</para>
	/// </param>
	/// <param name="keyModKey">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Pointer to a GUID that uniquely identifies the keying module key.</para>
	/// <para>
	/// If the caller supplies this parameter, only that keying module will be used for the tunnel. Otherwise, the default keying policy applies.
	/// </para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>The security information associated with the IPsec tunnel.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The IPsec tunnel mode policy was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_INVALID_PARAMETER</c> 0x80320035</term>
	/// <term>FWPM_TUNNEL_FLAG_POINT_TO_POINT was not set and conditions other than local/remote address were specified.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd1 DWORD FwpmIPsecTunnelAdd1( [in] HFWPENG
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT1 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT1
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional] const GUID
	// *keyModKey, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd1")]
	public static extern Win32Error FwpmIPsecTunnelAdd1([In] HFWPENG engineHandle, FWPM_TUNNEL_FLAG flags, in FWPM_PROVIDER_CONTEXT1 mainModePolicy,
		in FWPM_PROVIDER_CONTEXT1 tunnelPolicy, uint numFilterConditions,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		in Guid keyModKey, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd1</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd1</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, FwpmIPsecTunnelAdd0 is
	/// available. For Windows 8, FwpmIPsecTunnelAdd2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPsec tunnel flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_POINT_TO_POINT</c></term>
	/// <term>Adds a point-to-point tunnel to the system.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_ENABLE_VIRTUAL_IF_TUNNELING</c></term>
	/// <term>Enables virtual interface-based IPsec tunnel mode.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1*</para>
	/// <para>The Quick Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="numFilterConditions">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of filter conditions present in the <c>filterConditions</c> parameter.</para>
	/// </param>
	/// <param name="filterConditions">
	/// <para>Type: <c>const FWPM_FILTER_CONDITION0*</c></para>
	/// <para>Array of filter conditions that describe the traffic which should be tunneled by IPsec.</para>
	/// </param>
	/// <param name="keyModKey">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Pointer to a GUID that uniquely identifies the keying module key.</para>
	/// <para>
	/// If the caller supplies this parameter, only that keying module will be used for the tunnel. Otherwise, the default keying policy applies.
	/// </para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>The security information associated with the IPsec tunnel.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The IPsec tunnel mode policy was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_INVALID_PARAMETER</c> 0x80320035</term>
	/// <term>FWPM_TUNNEL_FLAG_POINT_TO_POINT was not set and conditions other than local/remote address were specified.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd1 DWORD FwpmIPsecTunnelAdd1( [in] HANDLE
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT1 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT1
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional] const GUID
	// *keyModKey, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd1")]
	public static extern Win32Error FwpmIPsecTunnelAdd1([In] HFWPENG engineHandle, FWPM_TUNNEL_FLAG flags, [In, Optional] IntPtr mainModePolicy,
		in FWPM_PROVIDER_CONTEXT1 tunnelPolicy, uint numFilterConditions,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		[In, Optional] GuidPtr keyModKey, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd2</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd2</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmIPsecTunnelAdd1 is
	/// available. For Windows Vista, FwpmIPsecTunnelAdd0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPsec tunnel flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_POINT_TO_POINT</c></term>
	/// <term>Adds a point-to-point tunnel to the system.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_ENABLE_VIRTUAL_IF_TUNNELING</c></term>
	/// <term>Enables virtual interface-based IPsec tunnel mode.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2*</para>
	/// <para>The Quick Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="numFilterConditions">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of filter conditions present in the <c>filterConditions</c> parameter.</para>
	/// </param>
	/// <param name="filterConditions">
	/// <para>Type: FWPM_FILTER_CONDITION0*</para>
	/// <para>Array of filter conditions that describe the traffic which should be tunneled by IPsec.</para>
	/// </param>
	/// <param name="keyModKey">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Pointer to a GUID that uniquely identifies the keying module key.</para>
	/// <para>
	/// If the caller supplies this parameter, only that keying module will be used for the tunnel. Otherwise, the default keying policy applies.
	/// </para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>The security information associated with the IPsec tunnel.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The IPsec tunnel mode policy was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_INVALID_PARAMETER</c> 0x80320035</term>
	/// <term>FWPM_TUNNEL_FLAG_POINT_TO_POINT was not set and conditions other than local/remote address were specified.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd2 DWORD FwpmIPsecTunnelAdd2( [in] HFWPENG
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT2 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT2
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional] const GUID
	// *keyModKey, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd2")]
	public static extern Win32Error FwpmIPsecTunnelAdd2([In] HFWPENG engineHandle, [In] FWPM_TUNNEL_FLAG flags, in FWPM_PROVIDER_CONTEXT2 mainModePolicy,
		in FWPM_PROVIDER_CONTEXT2 tunnelPolicy, uint numFilterConditions,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		in Guid keyModKey, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd2</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd2</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmIPsecTunnelAdd1 is
	/// available. For Windows Vista, FwpmIPsecTunnelAdd0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPsec tunnel flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_POINT_TO_POINT</c></term>
	/// <term>Adds a point-to-point tunnel to the system.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_TUNNEL_FLAG_ENABLE_VIRTUAL_IF_TUNNELING</c></term>
	/// <term>Enables virtual interface-based IPsec tunnel mode.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2*</para>
	/// <para>The Quick Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="numFilterConditions">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of filter conditions present in the <c>filterConditions</c> parameter.</para>
	/// </param>
	/// <param name="filterConditions">
	/// <para>Type: FWPM_FILTER_CONDITION0*</para>
	/// <para>Array of filter conditions that describe the traffic which should be tunneled by IPsec.</para>
	/// </param>
	/// <param name="keyModKey">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Pointer to a GUID that uniquely identifies the keying module key.</para>
	/// <para>
	/// If the caller supplies this parameter, only that keying module will be used for the tunnel. Otherwise, the default keying policy applies.
	/// </para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>The security information associated with the IPsec tunnel.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The IPsec tunnel mode policy was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_INVALID_PARAMETER</c> 0x80320035</term>
	/// <term>FWPM_TUNNEL_FLAG_POINT_TO_POINT was not set and conditions other than local/remote address were specified.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd2 DWORD FwpmIPsecTunnelAdd2( [in] HFWPENG
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT2 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT2
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional] const GUID
	// *keyModKey, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd2")]
	public static extern Win32Error FwpmIPsecTunnelAdd2([In] HFWPENG engineHandle, [In] FWPM_TUNNEL_FLAG flags, [In, Optional] IntPtr mainModePolicy,
		in FWPM_PROVIDER_CONTEXT2 tunnelPolicy, uint numFilterConditions,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		[In, Optional] GuidPtr keyModKey, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>
	/// The <c>FwpmIPsecTunnelDeleteByKey0</c> function removes an Internet Protocol Security (IPsec) tunnel mode policy from the system.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the IPsec tunnel. This GUID was specified in the <c>providerContextKey</c> member of the <c>tunnelPolicy</c>
	/// parameter of the FwpmIPsecTunnelAdd0 function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The IPsec tunnel mode policy was successfully deleted.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// <c>FwpmIPsecTunnelDeleteByKey0</c> is a specific implementation of FwpmIPsecTunnelDeleteByKey. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneldeletebykey0 DWORD FwpmIPsecTunnelDeleteByKey0( [in]
	// HFWPENG engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelDeleteByKey0")]
	public static extern Win32Error FwpmIPsecTunnelDeleteByKey0([In] HFWPENG engineHandle, [In] in Guid key);

	/// <summary>The <c>FwpmLayerCreateEnumHandle0</c> function creates a handle used to enumerate a set of layer objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_LAYER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for the layer enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was created successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all layers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmLayerCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmLayerCreateEnumHandle0</c> and FwpmLayerEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to the FwpmLayerDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the layers' containers and <c>FWPM_ACTRL_READ</c> access to the layers. Only layers to
	/// which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmLayerCreateEnumHandle0</c> is a specific implementation of FwpmLayerCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayercreateenumhandle0 DWORD FwpmLayerCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const FWPM_LAYER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerCreateEnumHandle0")]
	public static extern Win32Error FwpmLayerCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_LAYER_ENUM_TEMPLATE0 enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmLayerCreateEnumHandle0</c> function creates a handle used to enumerate a set of layer objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_LAYER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for the layer enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was created successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all layers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmLayerCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmLayerCreateEnumHandle0</c> and FwpmLayerEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to the FwpmLayerDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the layers' containers and <c>FWPM_ACTRL_READ</c> access to the layers. Only layers to
	/// which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmLayerCreateEnumHandle0</c> is a specific implementation of FwpmLayerCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayercreateenumhandle0 DWORD FwpmLayerCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const FWPM_LAYER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerCreateEnumHandle0")]
	public static extern Win32Error FwpmLayerCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmLayerDestroyEnumHandle0</c> function frees a handle returned by FwpmFilterCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a layer enumeration created by a call to FwpmLayerCreateEnumHandle0.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The enumerator was successfully deleted.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>FwpmLayerDestroyEnumHandle0</c> is a specific implementation of FwpmLayerDestroyEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayerdestroyenumhandle0 DWORD FwpmLayerDestroyEnumHandle0( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerDestroyEnumHandle0")]
	public static extern Win32Error FwpmLayerDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmLayerEnum0</c> function returns the next page of results from the layer enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a layer enumeration created by a call to FwpmLayerCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of layer entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_LAYER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of layer entries returned.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The layers were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the <c>numEntriesReturned</c> is less than the <c>numEntriesRequested</c>, the enumeration is exhausted.</para>
	/// <para>The returned array of entries (but not the individual entries themselves) must be freed by a call to FwpmFreeMemory0.</para>
	/// <para>A subsequent call using the same enumeration handle will return the next set of items following those in the last output buffer.</para>
	/// <para>
	/// <c>FwpmLayerEnum0</c> is a specific implementation of FwpmLayerEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayerenum0 DWORD FwpmLayerEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_LAYER0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerEnum0")]
	public static extern Win32Error FwpmLayerEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>The <c>FwpmLayerEnum0</c> function returns the next page of results from the layer enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_LAYER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_LAYER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The layers were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all layers are returned.</para>
	/// <para>
	/// <c>FwpmLayerEnum0</c> is a specific implementation of FwpmLayerEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayerenum0 DWORD FwpmLayerEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_LAYER0 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerEnum0")]
	public static Win32Error FwpmLayerEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_LAYER0> entries, FWPM_LAYER_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmLayerCreateEnumHandle0, FwpmLayerEnum0, FwpmLayerDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmLayerGetById0</c> function retrieves a layer object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT16</c></para>
	/// <para>
	/// Identifier of the desired layer. For a list of possible values, see Run-time Filtering Layer Identifiers in the WDK documentation for
	/// Windows Filtering Platform.
	/// </para>
	/// </param>
	/// <param name="layer">
	/// <para>Type: FWPM_LAYER0**</para>
	/// <para>The layer information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The layer was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the layer. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmLayerGetById0</c> is a specific implementation of FwpmLayerGetById. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayergetbyid0 DWORD FwpmLayerGetById0( [in] HFWPENG
	// engineHandle, [in] UINT16 id, [out] FWPM_LAYER0 **layer );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerGetById0")]
	public static Win32Error FwpmLayerGetById0([In] HFWPENG engineHandle, [In] ushort id, out SafeFwpmStruct<FWPM_LAYER0> layer) =>
		FwpmGenericGetById(FwpmLayerGetById0, engineHandle, id, out layer);

	/// <summary>The <c>FwpmLayerGetByKey0</c> function retrieves a layer object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the layer. See Filtering Layer Identifiers for a list of possible GUID values.</para>
	/// </param>
	/// <param name="layer">
	/// <para>Type: FWPM_LAYER0**</para>
	/// <para>The layer information.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The layer was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The caller must free the returned object by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the layer. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmLayerGetByKey0</c> is a specific implementation of FwpmLayerGetByKey. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayergetbykey0 DWORD FwpmLayerGetByKey0( [in] HFWPENG
	// engineHandle, [in] const GUID *key, [out] FWPM_LAYER0 **layer );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerGetByKey0")]
	public static Win32Error FwpmLayerGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_LAYER0> layer) =>
		FwpmGenericGetByKey(FwpmLayerGetByKey0, engineHandle, key, out layer);

	/// <summary>The <c>FwpmLayerGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a layer object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the layer. See Filtering Layer Identifiers for a list of possible GUID values.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to retrieve.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The owner security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The primary group security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The discretionary access control list (DACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The system access control list (SACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="securityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR*</c></para>
	/// <para>The returned security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// layers container.
	/// </para>
	/// <para>
	/// The returned <c>securityDescriptor</c> parameter must be freed through a call to FwpmFreeMemory0. The other four (optional) returned
	/// parameters must not be freed, as they point to addresses within the <c>securityDescriptor</c> parameter.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 GetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>GetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmLayerGetSecurityInfoByKey0</c> is a specific implementation of FwpmLayerGetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayergetsecurityinfobykey0 DWORD FwpmLayerGetSecurityInfoByKey0(
	// [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner,
	// [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmLayerGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>The <c>FwpmLayerGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a layer object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the layer. See Filtering Layer Identifiers for a list of possible GUID values.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to retrieve.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The owner security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>PSID*</c></para>
	/// <para>The primary group security identifier (SID) in the returned security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The discretionary access control list (DACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>PACL*</c></para>
	/// <para>The system access control list (SACL) in the returned security descriptor.</para>
	/// </param>
	/// <param name="securityDescriptor">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR*</c></para>
	/// <para>The returned security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// layers container.
	/// </para>
	/// <para>
	/// The returned <c>securityDescriptor</c> parameter must be freed through a call to FwpmFreeMemory0. The other four (optional) returned
	/// parameters must not be freed, as they point to addresses within the <c>securityDescriptor</c> parameter.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 GetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>GetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmLayerGetSecurityInfoByKey0</c> is a specific implementation of FwpmLayerGetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayergetsecurityinfobykey0 DWORD FwpmLayerGetSecurityInfoByKey0(
	// [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner,
	// [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmLayerGetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmLayerSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a layer object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the layer. See Filtering Layer Identifiers for a list of possible GUID values.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to set.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The owner's security identifier (SID) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The group's SID to be set in the security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The discretionary access control list (DACL) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The system access control list (SACL) to be set in the security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was set successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// layers container.
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmLayerSetSecurityInfoByKey0</c> is a specific implementation of FwpmLayerSetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayersetsecurityinfobykey0 DWORD FwpmLayerSetSecurityInfoByKey0(
	// [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner,
	// [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmLayerSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmLayerSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a layer object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the layer. See Filtering Layer Identifiers for a list of possible GUID values.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to set.</para>
	/// </param>
	/// <param name="sidOwner">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The owner's security identifier (SID) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sidGroup">
	/// <para>Type: <c>const SID*</c></para>
	/// <para>The group's SID to be set in the security descriptor.</para>
	/// </param>
	/// <param name="dacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The discretionary access control list (DACL) to be set in the security descriptor.</para>
	/// </param>
	/// <param name="sacl">
	/// <para>Type: <c>const ACL*</c></para>
	/// <para>The system access control list (SACL) to be set in the security descriptor.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The security descriptor was set successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>key</c> parameter is <c>NULL</c> or if it is a <c>NULL</c> GUID, this function manages the security information of the
	/// layers container.
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmLayerSetSecurityInfoByKey0</c> is a specific implementation of FwpmLayerSetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmlayersetsecurityinfobykey0 DWORD FwpmLayerSetSecurityInfoByKey0(
	// [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner,
	// [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmLayerSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmLayerSetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmFilterGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem filter);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmFilterGetByKey0([In] HFWPENG engineHandle, in Guid key, out SafeFwpmMem filter);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmGetAppIdFromFileName0([MarshalAs(UnmanagedType.LPWStr)] string fileName, out SafeFwpmMem appId);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmLayerGetById0([In] HFWPENG engineHandle, [In] ushort id, out SafeFwpmMem layer);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmLayerGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem layer);
}