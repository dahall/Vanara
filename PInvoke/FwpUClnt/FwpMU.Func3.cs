namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>The <c>FwpmNetEventsGetSecurityInfo0</c> function retrieves a copy of the security descriptor for a network event object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="securityInfo">
	/// <para>Type: <c>SECURITY_INFORMATION</c></para>
	/// <para>The type of security information to retrieve.</para>
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
	/// <c>FwpmNetEventsGetSecurityInfo0</c> is a specific implementation of FwpmNetEventsGetSecurityInfo. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsgetsecurityinfo0 DWORD FwpmNetEventsGetSecurityInfo0(
	// [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup,
	// [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventsGetSecurityInfo0")]
	public static extern Win32Error FwpmNetEventsGetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmNetEventsSetSecurityInfo0</c> function sets specified security information in the security descriptor of a network event object.
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
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>
	/// This function cannot be called from within a dynamic session. It will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See Object
	/// Management for more information about sessions.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>FwpmNetEventsSetSecurityInfo0</c> is a specific implementation of FwpmNetEventsSetSecurityInfo. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventssetsecurityinfo0 DWORD FwpmNetEventsSetSecurityInfo0(
	// [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID
	// *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventsSetSecurityInfo0")]
	public static extern Win32Error FwpmNetEventsSetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// <para>The <c>FwpmNetEventSubscribe0</c> function is used to request the delivery of notifications regarding a particular net event.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventSubscribe0</c> is the specific implementation of FwpmNetEventSubscribe used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmNetEventSubscribe1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_NET_EVENT_SUBSCRIPTION0*</para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_NET_EVENT_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the event.</para>
	/// </param>
	/// <param name="eventsHandle">
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
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the net event's container.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsubscribe0 DWORD FwpmNetEventSubscribe0( [in] HFWPENG
	// engineHandle, [in] const FWPM_NET_EVENT_SUBSCRIPTION0 *subscription, [in] FWPM_NET_EVENT_CALLBACK0 callback, [in, optional] void
	// *context, [out] HANDLE *eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventSubscribe0")]
	public static extern Win32Error FwpmNetEventSubscribe0([In] HFWPENG engineHandle, in FWPM_NET_EVENT_SUBSCRIPTION0 subscription,
		[In] FWPM_NET_EVENT_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMNETEVTSUB eventsHandle);

	/// <summary>
	/// <para>The <c>FwpmNetEventSubscribe1</c> function is used to request the delivery of notifications regarding a particular net event.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventSubscribe1</c> is the specific implementation of FwpmNetEventSubscribe used in Windows 8 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmNetEventSubscribe0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_NET_EVENT_SUBSCRIPTION0*</para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_NET_EVENT_CALLBACK1</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the event.</para>
	/// </param>
	/// <param name="eventsHandle">
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
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the net event's container.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsubscribe1 DWORD FwpmNetEventSubscribe1( [in] HFWPENG
	// engineHandle, [in] const FWPM_NET_EVENT_SUBSCRIPTION0 *subscription, [in] FWPM_NET_EVENT_CALLBACK1 callback, [in, optional] void
	// *context, [out] HANDLE *eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventSubscribe1")]
	public static extern Win32Error FwpmNetEventSubscribe1([In] HFWPENG engineHandle, in FWPM_NET_EVENT_SUBSCRIPTION0 subscription,
		[In] FWPM_NET_EVENT_CALLBACK1 callback, [In, Optional] IntPtr context, out HFWPMNETEVTSUB eventsHandle);

	/// <summary>
	/// <para>The <c>FwpmNetEventSubscribe2</c> function is used to request the delivery of notifications regarding a particular net event.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventSubscribe2</c> is the specific implementation of <c>FwpmNetEventSubscribe</c> used in Windows 10, version
	/// 1607 and later. See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8,
	/// FwpmNetEventSubscribe1 is available. For Windows 7, FwpmNetEventSubscribe0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.
	/// </param>
	/// <param name="subscription">The notifications which will be delivered.</param>
	/// <param name="callback">Function pointer that will be invoked when a notification is ready for delivery.</param>
	/// <param name="context">
	/// Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the event.
	/// </param>
	/// <param name="eventsHandle">Handle to the newly created subscription.</param>
	/// <returns>
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
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the net event's container.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsubscribe2 DWORD FwpmNetEventSubscribe2( [in] HFWPENG
	// engineHandle, [in] const FWPM_NET_EVENT_SUBSCRIPTION0 *subscription, [in] FWPM_NET_EVENT_CALLBACK2 callback, [in, optional] void
	// *context, [out] HANDLE *eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventSubscribe2")]
	public static extern Win32Error FwpmNetEventSubscribe2([In] HFWPENG engineHandle, in FWPM_NET_EVENT_SUBSCRIPTION0 subscription,
		[In] FWPM_NET_EVENT_CALLBACK2 callback, [In, Optional] IntPtr context, out HFWPMNETEVTSUB eventsHandle);

	/// <summary>The <c>FwpmNetEventSubscriptionsGet0</c> function retrieves an array of all the current net event notification subscriptions.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT_SUBSCRIPTION0***</para>
	/// <para>The current net event notification subscriptions.</para>
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
	/// <para>
	/// <c>FwpmNetEventSubscriptionsGet0</c> is a specific implementation of FwpmNetEventSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsubscriptionsget0 DWORD FwpmNetEventSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_NET_EVENT_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventSubscriptionsGet0")]
	public static extern Win32Error FwpmNetEventSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>FwpmNetEventSubscriptionsGet0</c> function retrieves an array of all the current net event notification subscriptions.
	/// </summary>
	/// <param name="engineHandle"><para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para></param>
	/// <param name="entries"><para>Type: FWPM_NET_EVENT_SUBSCRIPTION0***</para>
	/// <para>The current net event notification subscriptions.</para></param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	///   <listheader>
	///     <term>Return code/value</term>
	///     <term>Description</term>
	///   </listheader>
	///   <item>
	///     <term>
	///       <c>ERROR_SUCCESS</c> 0</term>
	///     <term>The subscriptions were retrieved successfully.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	///     <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>RPC_* error code</c> 0x80010001—0x80010122</term>
	///     <term>Failure to communicate with the remote or local firewall engine.</term>
	///   </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The returned array (but not the individual entries in the array) must be freed through a call to FwpmFreeMemory0.</para>
	/// <para>
	///   <c>FwpmNetEventSubscriptionsGet0</c> is a specific implementation of FwpmNetEventSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventsubscriptionsget0 DWORD FwpmNetEventSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_NET_EVENT_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventSubscriptionsGet0")]
	public static Win32Error FwpmNetEventSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_NET_EVENT_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmNetEventSubscriptionsGet0, engineHandle, out entries);

	/// <summary>The <c>FwpmNetEventUnsubscribe0</c> function is used to cancel a net event subscription and stop receiving notifications.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="eventsHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed event notification. This is the returned handle from the call to FwpmNetEventSubscribe0.</para>
	/// <para>This may be <c>NULL</c>, in which case the function will have no effect.</para>
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
	/// <c>FwpmNetEventUnsubscribe0</c> is a specific implementation of FwpmNetEventUnsubscribe. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventunsubscribe0 DWORD FwpmNetEventUnsubscribe0( [in]
	// HFWPENG engineHandle, [in, out] HANDLE eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventUnsubscribe0")]
	public static extern Win32Error FwpmNetEventUnsubscribe0([In] HFWPENG engineHandle, [In, Out] HFWPMNETEVTSUB eventsHandle);

	/// <summary>The <c>FwpmProviderAdd0</c> function adds a new provider to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="provider">
	/// <para>Type: FWPM_PROVIDER0*</para>
	/// <para>The provider object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Security information for the provider object.</para>
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
	/// <term>The provider was successfully added.</term>
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
	/// <para>If the caller supplies a null security descriptor, the system will assign a default security descriptor.</para>
	/// <para>
	/// Boot-time objects are added to the Base Filtering Engine (BFE) when the TCP/IP driver starts, and are removed once the BFE finishes
	/// initialization. Persistent objects are added when the BFE starts. If a policy provider has a persistent policy that is not intended
	/// to be enforced if its associated service is disabled, the caller can specify an optional service name in the FWPM_PROVIDER0
	/// structure. This service then owns the persistent policy object. At start, the BFE only adds the following types of persistent objects
	/// to the system.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The object is not associated with a provider.</term>
	/// </item>
	/// <item>
	/// <term>The object has an associated provider that does not specify a service name.</term>
	/// </item>
	/// <item>
	/// <term>The object has an associated provider and an associated service set to auto-start.</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ADD access to the provider's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderAdd0</c> is a specific implementation of FwpmProviderAdd. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovideradd0 DWORD FwpmProviderAdd0( [in] HFWPENG engineHandle,
	// [in] const FWPM_PROVIDER0 *provider, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderAdd0")]
	public static extern Win32Error FwpmProviderAdd0([In] HFWPENG engineHandle, in FWPM_PROVIDER0 provider, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>The <c>FwpmProviderContextAdd0</c> function adds a new provider context to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0*</para>
	/// <para>The provider context object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Security information associated with the provider context object.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>Pointer to a variable that receives a runtime identifier for this provider context.</para>
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
	/// <term>The provider context was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c> 0x32</term>
	/// <term>
	/// The [FWPM_IPSEC_IKE_MM_CONTEXT](/windows/desktop/api/fwpmtypes/ne-fwpmtypes-fwpm_provider_context_type)and the
	/// [IKEEXT_IPV6_CGA](/windows/desktop/api/iketypes/ne-iketypes-ikeext_authentication_method_type) authentication method in the
	/// <c>authenticationMethods</c> array, but cryptographically generated address (CGA) is not enabled in the registry.
	/// </term>
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
	/// Some fields in the FWPM_PROVIDER_CONTEXT0 structure are assigned by the system, not the caller, and are ignored in the call to <c>FwpmProviderContextAdd0</c>.
	/// </para>
	/// <para>If the caller supplies a <c>NULL</c> security descriptor, the system will assign a default security descriptor.</para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ADD access to the provider context's container and <c>FWPM_ACTRL_ADD_LINK</c> access to the provider (if
	/// any). See Access Control for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextadd0 DWORD FwpmProviderContextAdd0( [in] HFWPENG
	// engineHandle, [in] const FWPM_PROVIDER_CONTEXT0 *providerContext, [in, optional] PSECURITY_DESCRIPTOR sd, [out, optional] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextAdd0")]
	public static extern Win32Error FwpmProviderContextAdd0([In] HFWPENG engineHandle, in FWPM_PROVIDER_CONTEXT0 providerContext,
		[In, Optional] PSECURITY_DESCRIPTOR sd, out ulong id);

	/// <summary>The <c>FwpmProviderContextAdd1</c> function adds a new provider context to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1*</para>
	/// <para>The provider context object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Security information associated with the provider context object.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>Pointer to a variable that receives a runtime identifier for this provider context.</para>
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
	/// <term>The provider context was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c> 0x32</term>
	/// <term>
	/// The [IKEEXT_IPV6_CGA](/windows/desktop/api/iketypes/ne-iketypes-ikeext_authentication_method_type) authentication method in the
	/// <c>authenticationMethods</c> array, but cryptographically generated address (CGA) is not enabled in the registry.
	/// </term>
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
	/// Some fields in the FWPM_PROVIDER_CONTEXT1 structure are assigned by the system, not the caller, and are ignored in the call to <c>FwpmProviderContextAdd1</c>.
	/// </para>
	/// <para>If the caller supplies a <c>NULL</c> security descriptor, the system will assign a default security descriptor.</para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ADD access to the provider context's container and <c>FWPM_ACTRL_ADD_LINK</c> access to the provider (if
	/// any). See Access Control for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextadd1 DWORD FwpmProviderContextAdd1( [in] HFWPENG
	// engineHandle, [in] const FWPM_PROVIDER_CONTEXT1 *providerContext, [in, optional] PSECURITY_DESCRIPTOR sd, [out, optional] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextAdd1")]
	public static extern Win32Error FwpmProviderContextAdd1([In] HFWPENG engineHandle, in FWPM_PROVIDER_CONTEXT1 providerContext,
		[In, Optional] PSECURITY_DESCRIPTOR sd, out ulong id);

	/// <summary>
	/// <para>The <c>FwpmProviderContextAdd2</c> function adds a new provider context to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextAdd2</c> is the specific implementation of FwpmProviderContextAdd used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextAdd1 is
	/// available. For Windows Vista, FwpmProviderContextAdd0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2*</para>
	/// <para>The provider context object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Security information associated with the provider context object.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>Pointer to a variable that receives a runtime identifier for this provider context.</para>
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
	/// <term>The provider context was successfully added.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c> 0x32</term>
	/// <term>
	/// The [FWPM_IPSEC_IKE_MM_CONTEXT](/windows/desktop/api/fwpmtypes/ne-fwpmtypes-fwpm_provider_context_type)and the
	/// [IKEEXT_IPV6_CGA](/windows/desktop/api/iketypes/ne-iketypes-ikeext_authentication_method_type) authentication method in the
	/// <c>authenticationMethods</c> array, but cryptographically generated address (CGA) is not enabled in the registry.
	/// </term>
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
	/// Some fields in the FWPM_PROVIDER_CONTEXT2 structure are assigned by the system, not the caller, and are ignored in the call to <c>FwpmProviderContextAdd2</c>.
	/// </para>
	/// <para>If the caller supplies a <c>NULL</c> security descriptor, the system will assign a default security descriptor.</para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ADD access to the provider context's container and <c>FWPM_ACTRL_ADD_LINK</c> access to the provider (if
	/// any). See Access Control for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextadd2 DWORD FwpmProviderContextAdd2( [in] HFWPENG
	// engineHandle, [in] const FWPM_PROVIDER_CONTEXT2 *providerContext, [in, optional] PSECURITY_DESCRIPTOR sd, [out, optional] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextAdd2")]
	public static extern Win32Error FwpmProviderContextAdd2([In] HFWPENG engineHandle, in FWPM_PROVIDER_CONTEXT2 providerContext,
		[In, Optional] PSECURITY_DESCRIPTOR sd, out ulong id);

	/// <summary>The <c>FwpmProviderContextCreateEnumHandle0</c> function creates a handle used to enumerate a set of provider contexts.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for provider context enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all provider contexts are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmProviderContextCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmProviderContextCreateEnumHandle0</c> and FwpmProviderContextEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmProviderContextDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the provider contexts' containers and <c>FWPM_ACTRL_READ</c> access to the provider
	/// contexts. Only provider contexts to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderContextCreateEnumHandle0</c> is a specific implementation of FwpmProviderContextCreateEnumHandle. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextcreateenumhandle0 DWORD
	// FwpmProviderContextCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0
	// *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextCreateEnumHandle0")]
	public static extern Win32Error FwpmProviderContextCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0 enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmProviderContextCreateEnumHandle0</c> function creates a handle used to enumerate a set of provider contexts.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for provider context enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all provider contexts are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmProviderContextCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmProviderContextCreateEnumHandle0</c> and FwpmProviderContextEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmProviderContextDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the provider contexts' containers and <c>FWPM_ACTRL_READ</c> access to the provider
	/// contexts. Only provider contexts to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderContextCreateEnumHandle0</c> is a specific implementation of FwpmProviderContextCreateEnumHandle. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextcreateenumhandle0 DWORD
	// FwpmProviderContextCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0
	// *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextCreateEnumHandle0")]
	public static extern Win32Error FwpmProviderContextCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmProviderContextDeleteById0</c> function removes a provider context from the system .</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A runtime identifier for the object being removed from the system. This is the runtime identifier that was received from the system
	/// when the application called FwpmProviderContextAdd0 for this object.
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
	/// <term>The provider context was successfully deleted.</term>
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
	/// <para>The caller needs DELETE access to the provider context. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderContextDeleteById0</c> is a specific implementation of FwpmProviderContextDeleteById. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextdeletebyid0 DWORD FwpmProviderContextDeleteById0(
	// [in] HFWPENG engineHandle, [in] UINT64 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextDeleteById0")]
	public static extern Win32Error FwpmProviderContextDeleteById0([In] HFWPENG engineHandle, ulong id);

	/// <summary>The <c>FwpmProviderContextDeleteByKey0</c> function removes a provider context from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the object being removed from the system. This is a pointer to the same GUID that was specified when the
	/// application called FwpmProviderContextAdd0 for this object.
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
	/// <term>The provider context was successfully deleted.</term>
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
	/// <para>The caller needs DELETE access to the provider context. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderContextDeleteByKey0</c> is a specific implementation of FwpmProviderContextDeleteByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextdeletebykey0 DWORD
	// FwpmProviderContextDeleteByKey0( [in] HFWPENG engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextDeleteByKey0")]
	public static extern Win32Error FwpmProviderContextDeleteByKey0([In] HFWPENG engineHandle, [In] in Guid key);

	/// <summary>The <c>FwpmProviderContextDestroyEnumHandle0</c> function frees a handle returned by FwpmProviderContextCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a provider context enumeration created by a call to FwpmProviderContextCreateEnumHandle0.</para>
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
	/// <c>FwpmProviderContextDestroyEnumHandle0</c> is a specific implementation of FwpmProviderContextDestroyEnumHandle. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextdestroyenumhandle0 DWORD
	// FwpmProviderContextDestroyEnumHandle0( [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextDestroyEnumHandle0")]
	public static extern Win32Error FwpmProviderContextDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum0</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextEnum0</c> is the specific implementation of FwpmProviderContextEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextEnum1 is
	/// available. For Windows 8, FwpmProviderContextEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a provider context enumeration created by a call to FwpmProviderContextCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of provider context objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0***</para>
	/// <para>The returned provider context objects.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of provider context objects returned.</para>
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
	/// <term>The provider contexts were enumerated successfully.</term>
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
	/// <para><c>FwpmProviderContextEnum0</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum0 DWORD FwpmProviderContextEnum0( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum0")]
	public static extern Win32Error FwpmProviderContextEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum0</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	///   <c>Note</c>
	///   <c>FwpmProviderContextEnum0</c> is the specific implementation of FwpmProviderContextEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextEnum1 is
	/// available. For Windows 8, FwpmProviderContextEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle"><para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para></param>
	/// <param name="entries"><para>Type: FWPM_PROVIDER_CONTEXT0***</para>
	/// <para>The returned provider context objects.</para></param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	///   <listheader>
	///     <term>Return code/value</term>
	///     <term>Description</term>
	///   </listheader>
	///   <item>
	///     <term>
	///       <c>ERROR_SUCCESS</c> 0</term>
	///     <term>The provider contexts were enumerated successfully.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	///     <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>RPC_* error code</c> 0x80010001—0x80010122</term>
	///     <term>Failure to communicate with the remote or local firewall engine.</term>
	///   </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all provider contexts are returned.</para>
	/// <para>
	///   <c>FwpmProviderContextEnum0</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum0 DWORD FwpmProviderContextEnum0( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum0")]
	public static Win32Error FwpmProviderContextEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT0> entries, FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmProviderContextCreateEnumHandle0, FwpmProviderContextEnum0, FwpmProviderContextDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum1</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextEnum1</c> is the specific implementation of FwpmProviderContextEnum used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmProviderContextEnum2 is
	/// available. For Windows Vista, FwpmProviderContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a provider context enumeration created by a call to FwpmProviderContextCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of provider context objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1***</para>
	/// <para>The returned provider context objects.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of provider context objects returned.</para>
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
	/// <term>The provider contexts were enumerated successfully.</term>
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
	/// <para><c>FwpmProviderContextEnum1</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum1 DWORD FwpmProviderContextEnum1( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT1 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum1")]
	public static extern Win32Error FwpmProviderContextEnum1([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum1</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	///   <c>Note</c>
	///   <c>FwpmProviderContextEnum1</c> is the specific implementation of FwpmProviderContextEnum used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmProviderContextEnum2 is
	/// available. For Windows Vista, FwpmProviderContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle"><para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para></param>
	/// <param name="entries"><para>Type: FWPM_PROVIDER_CONTEXT1***</para>
	/// <para>The returned provider context objects.</para></param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	///   <listheader>
	///     <term>Return code/value</term>
	///     <term>Description</term>
	///   </listheader>
	///   <item>
	///     <term>
	///       <c>ERROR_SUCCESS</c> 0</term>
	///     <term>The provider contexts were enumerated successfully.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	///     <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>RPC_* error code</c> 0x80010001—0x80010122</term>
	///     <term>Failure to communicate with the remote or local firewall engine.</term>
	///   </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all provider contexts are returned.</para>
	/// <para>
	///   <c>FwpmProviderContextEnum1</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum1 DWORD FwpmProviderContextEnum1( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT1 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum1")]
	public static Win32Error FwpmProviderContextEnum1([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT1> entries, FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmProviderContextCreateEnumHandle0, FwpmProviderContextEnum1, FwpmProviderContextDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum2</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextEnum2</c> is the specific implementation of FwpmProviderContextEnum used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextEnum1 is
	/// available. For Windows Vista, FwpmProviderContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a provider context enumeration created by a call to FwpmProviderContextCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of provider context objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2***</para>
	/// <para>The returned provider context objects.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of provider context objects returned.</para>
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
	/// <term>The provider contexts were enumerated successfully.</term>
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
	/// <para><c>FwpmProviderContextEnum2</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum2 DWORD FwpmProviderContextEnum2( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT2 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum2")]
	public static extern Win32Error FwpmProviderContextEnum2([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmProviderContextEnum2</c> function returns the next page of results from the provider context enumerator.</para>
	/// <para>
	///   <c>Note</c>
	///   <c>FwpmProviderContextEnum2</c> is the specific implementation of FwpmProviderContextEnum used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextEnum1 is
	/// available. For Windows Vista, FwpmProviderContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle"><para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para></param>
	/// <param name="entries"><para>Type: FWPM_PROVIDER_CONTEXT2***</para>
	/// <para>The returned provider context objects.</para></param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	///   <listheader>
	///     <term>Return code/value</term>
	///     <term>Description</term>
	///   </listheader>
	///   <item>
	///     <term>
	///       <c>ERROR_SUCCESS</c> 0</term>
	///     <term>The provider contexts were enumerated successfully.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	///     <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	///   </item>
	///   <item>
	///     <term>
	///       <c>RPC_* error code</c> 0x80010001—0x80010122</term>
	///     <term>Failure to communicate with the remote or local firewall engine.</term>
	///   </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all provider contexts are returned.</para>
	/// <para>
	///   <c>FwpmProviderContextEnum2</c> works on a snapshot of the provider contexts taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextenum2 DWORD FwpmProviderContextEnum2( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER_CONTEXT2 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextEnum2")]
	public static Win32Error FwpmProviderContextEnum2([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT2> entries, FWPM_PROVIDER_CONTEXT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmProviderContextCreateEnumHandle0, FwpmProviderContextEnum2, FwpmProviderContextDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmProviderContextGetById0</c> function retrieves a provider context.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextGetById0</c> is the specific implementation of FwpmProviderContextGetById used in Windows Vista. See
	/// WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7,
	/// FwpmProviderContextGetById1 is available. For Windows 8, FwpmProviderContextGetById2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A run-time identifier for the desired object. This must be the run-time identifier that was received from the system when the
	/// application called FwpmProviderContextAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbyid0 DWORD FwpmProviderContextGetById0( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [out] FWPM_PROVIDER_CONTEXT0 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetById0")]
	public static Win32Error FwpmProviderContextGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT0> providerContext) =>
		FwpmGenericGetById(FwpmProviderContextGetById0, engineHandle, id, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem providerContext);

	/// <summary>
	/// <para>The <c>FwpmProviderContextGetById1</c> function retrieves a provider context.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextGetById1</c> is the specific implementation of FwpmProviderContextGetById used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmProviderContextGetById2
	/// is available. For Windows Vista, FwpmProviderContextGetById0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A run-time identifier for the desired object. This must be the run-time identifier that was received from the system when the
	/// application called FwpmProviderContextAdd1 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbyid1 DWORD FwpmProviderContextGetById1( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [out] FWPM_PROVIDER_CONTEXT1 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetById1")]
	public static Win32Error FwpmProviderContextGetById1([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT1> providerContext) =>
		FwpmGenericGetById(FwpmProviderContextGetById1, engineHandle, id, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetById1([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem providerContext);

	/// <summary>
	/// <para>The <c>FwpmProviderContextGetById2</c> function retrieves a provider context.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextGetById2</c> is the specific implementation of FwpmProviderContextGetById used in Windows 8. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmProviderContextGetById1
	/// is available. For Windows Vista, FwpmProviderContextGetById0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A run-time identifier for the desired object. This must be the run-time identifier that was received from the system when the
	/// application called FwpmProviderContextAdd2 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbyid2 DWORD FwpmProviderContextGetById2( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [out] FWPM_PROVIDER_CONTEXT2 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetById2")]
	public static Win32Error FwpmProviderContextGetById2([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT2> providerContext) =>
		FwpmGenericGetById(FwpmProviderContextGetById2, engineHandle, id, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetById2([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem providerContext);

	/// <summary>The <c>FwpmProviderContextGetByKey0</c> function retrieves a provider context.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Pointer to a GUID that uniquely identifies the provider context. This is a pointer to the same GUID that was specified when the
	/// application called FwpmProviderContextAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbykey0 DWORD FwpmProviderContextGetByKey0(
	// [in] HFWPENG engineHandle, [in] const GUID *key, [out] FWPM_PROVIDER_CONTEXT0 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetByKey0")]
	public static Win32Error FwpmProviderContextGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT0> providerContext) =>
		FwpmGenericGetByKey(FwpmProviderContextGetByKey0, engineHandle, key, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem providerContext);

	/// <summary>The <c>FwpmProviderContextGetByKey1</c> function retrieves a provider context.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Pointer to a GUID that uniquely identifies the provider context. This is a pointer to the same GUID that was specified when the
	/// application called FwpmProviderContextAdd1 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT1**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbykey1 DWORD FwpmProviderContextGetByKey1(
	// [in] HFWPENG engineHandle, [in] const GUID *key, [out] FWPM_PROVIDER_CONTEXT1 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetByKey1")]
	public static Win32Error FwpmProviderContextGetByKey1([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT1> providerContext) =>
		FwpmGenericGetByKey(FwpmProviderContextGetByKey1, engineHandle, key, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetByKey1([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem providerContext);

	/// <summary>
	/// <para>The <c>FwpmProviderContextGetByKey2</c> function retrieves a provider context.</para>
	/// <para>
	/// <c>Note</c><c>FwpmProviderContextGetByKey2</c> is the specific implementation of FwpmProviderContextGetByKey used in Windows 8. See
	/// WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7,
	/// FwpmProviderContextGetByKey1 is available. For Windows Vista, FwpmProviderContextGetByKey0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Pointer to a GUID that uniquely identifies the provider context. This is a pointer to the same GUID that was specified when the
	/// application called FwpmProviderContextAdd2 for this object.
	/// </para>
	/// </param>
	/// <param name="providerContext">
	/// <para>Type: FWPM_PROVIDER_CONTEXT2**</para>
	/// <para>The provider context information.</para>
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
	/// <term>The provider context was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetbykey2 DWORD FwpmProviderContextGetByKey2(
	// [in] HFWPENG engineHandle, [in] const GUID *key, [out] FWPM_PROVIDER_CONTEXT2 **providerContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetByKey2")]
	public static Win32Error FwpmProviderContextGetByKey2([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_PROVIDER_CONTEXT2> providerContext) =>
		FwpmGenericGetByKey(FwpmProviderContextGetByKey2, engineHandle, key, out providerContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderContextGetByKey2([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem providerContext);

	/// <summary>
	/// The <c>FwpmProviderContextGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a provider context object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider context. This is a pointer to the same GUID that was specified when the application called
	/// FwpmProviderContextAdd0 for this object.
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
	/// provider contexts container.
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
	/// <c>FwpmProviderContextGetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderContextGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetsecurityinfobykey0 DWORD
	// FwpmProviderContextGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION
	// securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl,
	// [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderContextGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmProviderContextGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a provider context object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider context. This is a pointer to the same GUID that was specified when the application called
	/// FwpmProviderContextAdd0 for this object.
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
	/// provider contexts container.
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
	/// <c>FwpmProviderContextGetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderContextGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextgetsecurityinfobykey0 DWORD
	// FwpmProviderContextGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION
	// securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl,
	// [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderContextGetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmProviderContextSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a
	/// provider context object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider context object. This is a pointer to the same GUID that was specified when the application called
	/// FwpmProviderContextAdd0 for this object.
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
	/// provider contexts container.
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
	/// <c>FwpmProviderContextSetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderContextSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextsetsecurityinfobykey0 DWORD
	// FwpmProviderContextSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION
	// securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional]
	// const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderContextSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmProviderContextSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a
	/// provider context object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider context object. This is a pointer to the same GUID that was specified when the application called
	/// FwpmProviderContextAdd0 for this object.
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
	/// provider contexts container.
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
	/// <c>FwpmProviderContextSetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderContextSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextsetsecurityinfobykey0 DWORD
	// FwpmProviderContextSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION
	// securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional]
	// const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderContextSetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmProviderContextSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a
	/// particular provider context.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: <c>const FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0*</c></para>
	/// <para>The notifications to be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
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
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the provider context's container and <c>FWPM_ACTRL_READ</c> access to the provider
	/// context. The subscriber will only get notifications for provider contexts to which it has <c>FWPM_ACTRL_READ</c> access. See Access
	/// Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderContextSubscribeChanges0</c> is a specific implementation of FwpmProviderContextSubscribeChanges. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextsubscribechanges0 DWORD
	// FwpmProviderContextSubscribeChanges0( [in] HFWPENG engineHandle, [in] const FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0 *subscription, [in]
	// FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0 callback, [in, optional] void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextSubscribeChanges0")]
	public static extern Win32Error FwpmProviderContextSubscribeChanges0([In] HFWPENG engineHandle, in FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0 subscription,
		[In] FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMPROVCTXSUB changeHandle);

	/// <summary>
	/// The <c>FwpmProviderContextSubscriptionsGet0</c> function retrieves an array of all the current provider context change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: <c>FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0***</c></para>
	/// <para>The current provider context change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderContextSubscriptionsGet0</c> is a specific implementation of FwpmProviderContextSubscriptionsGet. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextsubscriptionsget0 DWORD
	// FwpmProviderContextSubscriptionsGet0( [in] HFWPENG engineHandle, [out] FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0 ***entries, [out] UINT32
	// *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextSubscriptionsGet0")]
	public static extern Win32Error FwpmProviderContextSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>FwpmProviderContextSubscriptionsGet0</c> function retrieves an array of all the current provider context change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: <c>FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0***</c></para>
	/// <para>The current provider context change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider context's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderContextSubscriptionsGet0</c> is a specific implementation of FwpmProviderContextSubscriptionsGet. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextsubscriptionsget0 DWORD
	// FwpmProviderContextSubscriptionsGet0( [in] HFWPENG engineHandle, [out] FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0 ***entries, [out] UINT32
	// *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextSubscriptionsGet0")]
	public static Win32Error FwpmProviderContextSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER_CONTEXT_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmProviderContextSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmProviderContextUnsubscribeChanges0</c> function is used to cancel a provider context change subscription and stop
	/// receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed change notification. This is the handle returned by FwpmProviderContextSubscribeChanges0.</para>
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
	/// <c>FwpmProviderContextUnsubscribeChanges0</c> is a specific implementation of FwpmProviderContextUnsubscribeChanges. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercontextunsubscribechanges0 DWORD
	// FwpmProviderContextUnsubscribeChanges0( [in] HFWPENG engineHandle, [in] HANDLE changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderContextUnsubscribeChanges0")]
	public static extern Win32Error FwpmProviderContextUnsubscribeChanges0([In] HFWPENG engineHandle, [In] HFWPMPROVCTXSUB changeHandle);

	/// <summary>The <c>FwpmProviderCreateEnumHandle0</c> function creates a handle used to enumerate a set of providers.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_PROVIDER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for provider enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all providers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmProviderCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmProviderCreateEnumHandle0</c> and FwpmProviderEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmProviderDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the providers' containers and <c>FWPM_ACTRL_READ</c> access to the providers. Only
	/// providers to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderCreateEnumHandle0</c> is a specific implementation of FwpmProviderCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercreateenumhandle0 DWORD FwpmProviderCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderCreateEnumHandle0")]
	public static extern Win32Error FwpmProviderCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_PROVIDER_ENUM_TEMPLATE0 enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmProviderCreateEnumHandle0</c> function creates a handle used to enumerate a set of providers.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_PROVIDER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for provider enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all providers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmProviderCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmProviderCreateEnumHandle0</c> and FwpmProviderEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmProviderDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the providers' containers and <c>FWPM_ACTRL_READ</c> access to the providers. Only
	/// providers to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderCreateEnumHandle0</c> is a specific implementation of FwpmProviderCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidercreateenumhandle0 DWORD FwpmProviderCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderCreateEnumHandle0")]
	public static extern Win32Error FwpmProviderCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmProviderDeleteByKey0</c> function removes a provider from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the object being removed from the system. This is the same GUID that was specified when the application called FwpmProviderAdd0.
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
	/// <term>The provider was successfully deleted.</term>
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
	/// <para>The caller needs DELETE access to the provider. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderDeleteByKey0</c> is a specific implementation of FwpmProviderDeleteByKey. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmproviderdeletebykey0 DWORD FwpmProviderDeleteByKey0( [in]
	// HFWPENG engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderDeleteByKey0")]
	public static extern Win32Error FwpmProviderDeleteByKey0([In] HFWPENG engineHandle, [In] in Guid key);

	/// <summary>The <c>FwpmProviderDestroyEnumHandle0</c> function frees a handle returned by FwpmProviderCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a provider enumeration created by a call to FwpmProviderCreateEnumHandle0.</para>
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
	/// <c>FwpmProviderDestroyEnumHandle0</c> is a specific implementation of FwpmProviderDestroyEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmproviderdestroyenumhandle0 DWORD FwpmProviderDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderDestroyEnumHandle0")]
	public static extern Win32Error FwpmProviderDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmProviderEnum0</c> function returns the next page of results from the provider enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a provider enumeration created by a call to FwpmProviderCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of provider entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of provider objects returned.</para>
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
	/// <term>The providers were enumerated successfully.</term>
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
	/// <para><c>FwpmProviderEnum0</c> works on a snapshot of the providers taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmProviderEnum0</c> is a specific implementation of FwpmProviderEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmproviderenum0 DWORD FwpmProviderEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderEnum0")]
	public static extern Win32Error FwpmProviderEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>The <c>FwpmProviderEnum0</c> function returns the next page of results from the provider enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_PROVIDER_ENUM_TEMPLATE0*</para>
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
	/// <term>The providers were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all providers are returned.</para>
	/// <para><c>FwpmProviderEnum0</c> works on a snapshot of the providers taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmProviderEnum0</c> is a specific implementation of FwpmProviderEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmproviderenum0 DWORD FwpmProviderEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_PROVIDER0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderEnum0")]
	public static Win32Error FwpmProviderEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER0> entries, FWPM_PROVIDER_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmProviderCreateEnumHandle0, FwpmProviderEnum0, FwpmProviderDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmProviderGetByKey0</c> function retrieves a provider.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>A runtime identifier for the desired object. This is the same GUID that was specified when the application called FwpmProviderAdd0.</para>
	/// </param>
	/// <param name="provider">
	/// <para>Type: FWPM_PROVIDER0**</para>
	/// <para>The provider information.</para>
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
	/// <term>The provider was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderGetByKey0</c> is a specific implementation of FwpmProviderGetByKey. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidergetbykey0 DWORD FwpmProviderGetByKey0( [in] HFWPENG
	// engineHandle, [in] const GUID *key, [out] FWPM_PROVIDER0 **provider );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderGetByKey0")]
	public static Win32Error FwpmProviderGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_PROVIDER0> provider) =>
		FwpmGenericGetByKey(FwpmProviderGetByKey0, engineHandle, key, out provider);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmProviderGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem provider);

	/// <summary>The <c>FwpmProviderGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a provider object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique key of the object of interest. This must be the same GUID that was specified when the application called FwpmProviderAdd0 for
	/// this object.
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
	/// providers container.
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
	/// <c>FwpmProviderGetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidergetsecurityinfobykey0 DWORD
	// FwpmProviderGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>The <c>FwpmProviderGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a provider object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique key of the object of interest. This must be the same GUID that was specified when the application called FwpmProviderAdd0 for
	/// this object.
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
	/// providers container.
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
	/// <c>FwpmProviderGetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidergetsecurityinfobykey0 DWORD
	// FwpmProviderGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderGetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmProviderSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a provider object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider. This is the same GUID that was specified when the application called FwpmProviderAdd0 for this object.
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
	/// providers container.
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
	/// <c>FwpmProviderSetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersetsecurityinfobykey0 DWORD
	// FwpmProviderSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmProviderSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a provider object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the provider. This is the same GUID that was specified when the application called FwpmProviderAdd0 for this object.
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
	/// providers container.
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
	/// <c>FwpmProviderSetSecurityInfoByKey0</c> is a specific implementation of FwpmProviderSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersetsecurityinfobykey0 DWORD
	// FwpmProviderSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmProviderSetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmProviderSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a particular provider.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_PROVIDER_SUBSCRIPTION0*</para>
	/// <para>The notifications to be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_PROVIDER_CHANGE_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
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
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the provider's container and <c>FWPM_ACTRL_READ</c> access to the provider. The
	/// subscriber will only get notifications for providers to which it has <c>FWPM_ACTRL_READ</c> access. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderSubscribeChanges0</c> is a specific implementation of FwpmProviderSubscribeChanges. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersubscribechanges0 DWORD FwpmProviderSubscribeChanges0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_SUBSCRIPTION0 *subscription, [in] FWPM_PROVIDER_CHANGE_CALLBACK0
	// callback, [in, optional] void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSubscribeChanges0")]
	public static extern Win32Error FwpmProviderSubscribeChanges0([In] HFWPENG engineHandle, in FWPM_PROVIDER_SUBSCRIPTION0 subscription,
		[In] FWPM_PROVIDER_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMPROVSUB changeHandle);

	/// <summary>
	/// The <c>FwpmProviderSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a particular provider.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_PROVIDER_SUBSCRIPTION0*</para>
	/// <para>The notifications to be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_PROVIDER_CHANGE_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
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
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the provider's container and <c>FWPM_ACTRL_READ</c> access to the provider. The
	/// subscriber will only get notifications for providers to which it has <c>FWPM_ACTRL_READ</c> access. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmProviderSubscribeChanges0</c> is a specific implementation of FwpmProviderSubscribeChanges. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersubscribechanges0 DWORD FwpmProviderSubscribeChanges0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_PROVIDER_SUBSCRIPTION0 *subscription, [in] FWPM_PROVIDER_CHANGE_CALLBACK0
	// callback, [in, optional] void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSubscribeChanges0")]
	public static extern Win32Error FwpmProviderSubscribeChanges0([In] HFWPENG engineHandle, [In, Optional] IntPtr subscription,
		[In] FWPM_PROVIDER_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMPROVSUB changeHandle);

	/// <summary>
	/// The <c>FwpmProviderSubscriptionsGet0</c> function retrieves an array of all the current provider change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER_SUBSCRIPTION0***</para>
	/// <para>The current provider change notification subscriptions.</para>
	/// </param>
	/// <param name="numEntries">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>Pointer to an <c>UINT32</c> variable that will contain the number of entries returned.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderSubscriptionsGet0</c> is a specific implementation of FwpmProviderSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersubscriptionsget0 DWORD FwpmProviderSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_PROVIDER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSubscriptionsGet0")]
	public static extern Win32Error FwpmProviderSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>FwpmProviderSubscriptionsGet0</c> function retrieves an array of all the current provider change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_PROVIDER_SUBSCRIPTION0***</para>
	/// <para>The current provider change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the provider's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmProviderSubscriptionsGet0</c> is a specific implementation of FwpmProviderSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmprovidersubscriptionsget0 DWORD FwpmProviderSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_PROVIDER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderSubscriptionsGet0")]
	public static Win32Error FwpmProviderSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_PROVIDER_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmProviderSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmProviderUnsubscribeChanges0</c> function is used to cancel a provider change subscription and stop receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed change notification. This is the handle returned by the call to FwpmProviderSubscribeChanges0.</para>
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
	/// <c>FwpmProviderUnsubscribeChanges0</c> is a specific implementation of FwpmProviderUnsubscribeChanges. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmproviderunsubscribechanges0 DWORD
	// FwpmProviderUnsubscribeChanges0( [in] HFWPENG engineHandle, [in] HANDLE changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmProviderUnsubscribeChanges0")]
	public static extern Win32Error FwpmProviderUnsubscribeChanges0([In] HFWPENG engineHandle, [In] HFWPMPROVSUB changeHandle);
}