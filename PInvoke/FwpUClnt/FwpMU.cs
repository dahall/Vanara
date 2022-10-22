﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>The <c>FWPM_CALLOUT_CHANGE_CALLBACK0</c> function is used to add custom behavior to the callout change notification process.</summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmCalloutSubscribeChanges0 function.</para>
	/// </param>
	/// <param name="change">
	/// <para>Type: FWPM_CALLOUT_CHANGE0*</para>
	/// <para>The change notification information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmCalloutSubscribeChanges0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_CALLOUT_CHANGE_CALLBACK0</c> is a specific implementation of FWPM_CALLOUT_CHANGE_CALLBACK. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_callout_change_callback0 FWPM_CALLOUT_CHANGE_CALLBACK0
	// FwpmCalloutChangeCallback0; void FwpmCalloutChangeCallback0( [in] void *context, [in] const FWPM_CALLOUT_CHANGE0 *change ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_CALLOUT_CHANGE_CALLBACK0")]
	public delegate void FWPM_CALLOUT_CHANGE_CALLBACK0([In, Optional] IntPtr context, in FWPM_CALLOUT_CHANGE0 change);

	/// <summary>The <c>FWPM_CONNECTION_CALLBACK0</c> function is used to add custom behavior to the connection object subscription process.</summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmConnectionSubscribe0 function.</para>
	/// </param>
	/// <param name="eventType">
	/// <para>Type: FWPM_CONNECTION_EVENT_TYPE</para>
	/// <para>The type of connection object change event.</para>
	/// </param>
	/// <param name="connection">
	/// <para>Type: FWPM_CONNECTION0*</para>
	/// <para>The connection object change information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>Call FwpmConnectionSubscribe0 to register this callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_connection_callback0 FWPM_CONNECTION_CALLBACK0
	// FwpmConnectionCallback0; void FwpmConnectionCallback0( [in, out] void *context, [in] FWPM_CONNECTION_EVENT_TYPE eventType, [in] const
	// FWPM_CONNECTION0 *connection ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_CONNECTION_CALLBACK0")]
	public delegate void FWPM_CONNECTION_CALLBACK0([In, Out, Optional] IntPtr context, FWPM_CONNECTION_EVENT_TYPE eventType, in FWPM_CONNECTION0 connection);

	/// <summary>
	/// <para>
	/// A callback function, which you implement, that is invoked with notifications regarding changes to dynamic keyword address
	/// (FW_DYNAMIC_KEYWORD_ADDRESS0) objects. See FwpmDynamicKeywordSubscribe0.
	/// </para>
	/// <para>For more info, and code examples, see Firewall dynamic keywords.</para>
	/// </summary>
	/// <param name="notification">
	/// <para>Type: _In_opt_ <c>void*</c></para>
	/// <para>Not used.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: _In_opt_ <c>void*</c></para>
	/// <para>The value you pass to FwpmDynamicKeywordSubscribe0 as the context argument.</para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_dynamic_keyword_callback0 FWPM_DYNAMIC_KEYWORD_CALLBACK0
	// FwpmDynamicKeywordCallback0; void FwpmDynamicKeywordCallback0( void *notification, void *context ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_DYNAMIC_KEYWORD_CALLBACK0")]
	public delegate void FWPM_DYNAMIC_KEYWORD_CALLBACK0([In, Optional] IntPtr notification, [In, Optional] IntPtr context);

	/// <summary>The <c>FWPM_FILTER_CHANGE_CALLBACK0</c> function is used to added custom behavior to the filter change notification process.</summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter passed to the FwpmFilterSubscribeChanges0 function.</para>
	/// </param>
	/// <param name="change">
	/// <para>Type: FWPM_FILTER_CHANGE0*</para>
	/// <para>The change notification information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmFilterSubscribeChanges0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_FILTER_CHANGE_CALLBACK0</c> is a specific implementation of FWPM_FILTER_CHANGE_CALLBACK. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_filter_change_callback0 FWPM_FILTER_CHANGE_CALLBACK0
	// FwpmFilterChangeCallback0; void FwpmFilterChangeCallback0( [in] void *context, [in] const FWPM_FILTER_CHANGE0 *change ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_FILTER_CHANGE_CALLBACK0")]
	public delegate void FWPM_FILTER_CHANGE_CALLBACK0([In, Optional] IntPtr context, in FWPM_FILTER_CHANGE0 change);

	/// <summary>
	/// <para>The <c>FWPM_NET_EVENT_CALLBACK0</c> function is used to add custom behavior to the net event subscription process.</para>
	/// <para>
	/// <c>Note</c><c>FWPM_NET_EVENT_CALLBACK0</c> is the specific implementation of FWPM_NET_EVENT_CALLBACK used in Windows 7. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FWPM_NET_EVENT_CALLBACK1 is available.
	/// </para>
	/// </summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmNetEventSubscribe0 function.</para>
	/// </param>
	/// <param name="event">
	/// <para>Type: FWPM_NET_EVENT1*</para>
	/// <para>The net event information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>Call FwpmNetEventSubscribe0 to register this callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_net_event_callback0 FWPM_NET_EVENT_CALLBACK0
	// FwpmNetEventCallback0; void FwpmNetEventCallback0( [in, out] void *context, [in] const FWPM_NET_EVENT1 *event ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_NET_EVENT_CALLBACK0")]
	public delegate void FWPM_NET_EVENT_CALLBACK0([In, Out, Optional] IntPtr context, in FWPM_NET_EVENT1 @event);

	/// <summary>
	/// <para>The <c>FWPM_NET_EVENT_CALLBACK1</c> function is used to add custom behavior to the net event subscription process.</para>
	/// <para>
	/// <c>Note</c><c>FWPM_NET_EVENT_CALLBACK1</c> is the specific implementation of FWPM_NET_EVENT_CALLBACK used in Windows 8 and later. See
	/// WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7,
	/// FWPM_NET_EVENT_CALLBACK0 is available.
	/// </para>
	/// </summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmNetEventSubscribe1 function.</para>
	/// </param>
	/// <param name="event">
	/// <para>Type: <c>const FWPM_NET_EVENT2*</c></para>
	/// <para>The net event information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>Call FwpmNetEventSubscribe1 to register this callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_net_event_callback1 FWPM_NET_EVENT_CALLBACK1
	// FwpmNetEventCallback1; void FwpmNetEventCallback1( [in, out] void *context, [in] const FWPM_NET_EVENT2 *event ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_NET_EVENT_CALLBACK1")]
	public delegate void FWPM_NET_EVENT_CALLBACK1([In, Out, Optional] IntPtr context, in FWPM_NET_EVENT2 @event);

	/// <summary>
	/// <para>The <c>FWPM_NET_EVENT_CALLBACK2</c> function is used to add custom behavior to the net event subscription process.</para>
	/// <para>
	/// <c>Note</c><c>FWPM_NET_EVENT_CALLBACK2</c> is the specific implementation of FWPM_NET_EVENT_CALLBACK used in Windows 10, version 1607
	/// and later. See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8,
	/// FWPM_NET_EVENT_CALLBACK1 is available. For Windows 7, FWPM_NET_EVENT_CALLBACK0 is available.
	/// </para>
	/// </summary>
	/// <param name="context">
	/// Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmNetEventSubscribe2 function.
	/// </param>
	/// <param name="event">The net event information.</param>
	/// <returns>None</returns>
	/// <remarks>Call FwpmNetEventSubscribe2 to register this callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_net_event_callback2 FWPM_NET_EVENT_CALLBACK2
	// FwpmNetEventCallback2; void FwpmNetEventCallback2( [in, out] void *context, [in] const FWPM_NET_EVENT3 *event ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_NET_EVENT_CALLBACK2")]
	public delegate void FWPM_NET_EVENT_CALLBACK2([In, Out, Optional] IntPtr context, in FWPM_NET_EVENT3 @event);

	/// <summary>
	/// The <c>FWPM_PROVIDER_CHANGE_CALLBACK0</c> function is used to add custom behavior to the provider change notification process.
	/// </summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>
	/// Optional context pointer. It contains the value of the <c>context</c> parameter passed to the FwpmProviderSubscribeChanges0 function.
	/// </para>
	/// </param>
	/// <param name="change">
	/// <para>Type: FWPM_PROVIDER_CHANGE0*</para>
	/// <para>The change notification information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmProviderSubscribeChanges0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_PROVIDER_CHANGE_CALLBACK0</c> is a specific implementation of FWPM_PROVIDER_CHANGE_CALLBACK. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_provider_change_callback0 FWPM_PROVIDER_CHANGE_CALLBACK0
	// FwpmProviderChangeCallback0; void FwpmProviderChangeCallback0( [in] void *context, [in] const FWPM_PROVIDER_CHANGE0 *change ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_PROVIDER_CHANGE_CALLBACK0")]
	public delegate void FWPM_PROVIDER_CHANGE_CALLBACK0([In, Optional] IntPtr context, in FWPM_PROVIDER_CHANGE0 change);

	/// <summary>
	/// The <c>FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0</c> function is used to add custom behavior to the provider context change notification process.
	/// </summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>
	/// Optional context pointer. It contains the value of the <c>context</c> parameter passed to the FwpmProviderContextSubscribeChanges0 function.
	/// </para>
	/// </param>
	/// <param name="change">
	/// <para>Type: FWPM_PROVIDER_CONTEXT_CHANGE0*</para>
	/// <para>The change notification information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmProviderContextSubscribeChanges0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0</c> is a specific implementation of FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_provider_context_change_callback0
	// FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0 FwpmProviderContextChangeCallback0; void FwpmProviderContextChangeCallback0( [in] void
	// *context, [in] const FWPM_PROVIDER_CONTEXT_CHANGE0 *change ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0")]
	public delegate void FWPM_PROVIDER_CONTEXT_CHANGE_CALLBACK0([In, Optional] IntPtr context, in FWPM_PROVIDER_CONTEXT_CHANGE0 change);

	/// <summary>
	/// The <c>FWPM_SUBLAYER_CHANGE_CALLBACK0</c> function is used to added custom behavior to the sublayer change notification process.
	/// </summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmSubLayerSubscribeChanges0 function.</para>
	/// </param>
	/// <param name="change">
	/// <para>Type: FWPM_SUBLAYER_CHANGE0*</para>
	/// <para>The change notification information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmSubLayerSubscribeChanges0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_SUBLAYER_CHANGE_CALLBACK0</c> is a specific implementation of FWPM_SUBLAYER_CHANGE_CALLBACK. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_sublayer_change_callback0 FWPM_SUBLAYER_CHANGE_CALLBACK0
	// FwpmSublayerChangeCallback0; void FwpmSublayerChangeCallback0( [in] void *context, [in] const FWPM_SUBLAYER_CHANGE0 *change ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_SUBLAYER_CHANGE_CALLBACK0")]
	public delegate void FWPM_SUBLAYER_CHANGE_CALLBACK0([In, Optional] IntPtr context, in FWPM_SUBLAYER_CHANGE0 change);

	/// <summary>The <c>FWPM_SYSTEM_PORTS_CALLBACK0</c> function is used to add custom behavior to the system port subscription process.</summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmSystemPortsSubscribe0 function.</para>
	/// </param>
	/// <param name="sysPorts">
	/// <para>Type: FWPM_SYSTEM_PORTS0*</para>
	/// <para>The system port information.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>Call FwpmSystemPortsSubscribe0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_SYSTEM_PORTS_CALLBACK0</c> is a specific implementation of FWPM_SYSTEM_PORTS_CALLBACK. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_system_ports_callback0 FWPM_SYSTEM_PORTS_CALLBACK0
	// FwpmSystemPortsCallback0; void FwpmSystemPortsCallback0( [in, out] void *context, [in] const FWPM_SYSTEM_PORTS0 *sysPorts ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_SYSTEM_PORTS_CALLBACK0")]
	public delegate void FWPM_SYSTEM_PORTS_CALLBACK0([In, Out, Optional] IntPtr context, in FWPM_SYSTEM_PORTS0 sysPorts);

	/// <summary>The <c>FWPM_VSWITCH_EVENT_CALLBACK0</c> function is used to add custom behavior to the vSwitch event subscription process.</summary>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. It contains the value of the <c>context</c> parameter of the FwpmvSwitchEventSubscribe0 function.</para>
	/// </param>
	/// <param name="vSwitchEvent">
	/// <para>Type: FWPM_VSWITCH_EVENT0*</para>
	/// <para>The vSwitch event information.</para>
	/// </param>
	/// <returns>This callback function does not return a value.</returns>
	/// <remarks>
	/// <para>Call FwpmvSwitchEventSubscribe0 to register this callback function.</para>
	/// <para>
	/// <c>FWPM_VSWITCH_EVENT_CALLBACK0</c> is a specific implementation of FWPM_VSWITCH_EVENT_CALLBACK. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-fwpm_vswitch_event_callback0 FWPM_VSWITCH_EVENT_CALLBACK0
	// FwpmVswitchEventCallback0; DWORD FwpmVswitchEventCallback0( [in, out] void *context, [in] const FWPM_VSWITCH_EVENT0 *vSwitchEvent ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.FWPM_VSWITCH_EVENT_CALLBACK0")]
	public delegate uint FWPM_VSWITCH_EVENT_CALLBACK0([In, Out, Optional] IntPtr context, in FWPM_VSWITCH_EVENT0 vSwitchEvent);

	/// <summary>
	/// The <c>IPSEC_KEY_MANAGER_DICTATE_KEY0</c> function is used by the Trusted Intermediary Agent (TIA) to dictate keys for the SA being negotiated.
	/// </summary>
	/// <param name="inboundSaDetails">Information about the inbound SA.</param>
	/// <param name="outboundSaDetails">Information about the outbound SA.</param>
	/// <param name="keyingModuleGenKey">
	/// <see langword="true"/> if the keying module should randomly generate keys in the event that the TIA is unable to supply keys;
	/// otherwise, <see langword="false"/>.
	/// </param>
	/// <returns>
	/// <para>Type: <strong>DWORD</strong></para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code/value</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><strong>ERROR_SUCCESS</strong><br/> 0</description>
	/// <description>The keys were successsfully dictated.</description>
	/// </item>
	/// <item>
	/// <description><strong>FWP_E_* error code</strong><br/> 0x80320001—0x80320039 <br/></description>
	/// <description>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</description>
	/// </item>
	/// <item>
	/// <description><strong>RPC_* error code</strong><br/> 0x80010001—0x80010122 <br/></description>
	/// <description>Failure to communicate with the remote or local firewall engine.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Call IPsecKeyManagerAddAndRegister0 to invoke this function pointer. If the weight specified in
	/// IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0 for a TIA is higher than that of any peer, <c>IPSEC_KEY_MANAGER_DICTATE_KEY0</c> will be invoked.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-ipsec_key_manager_dictate_key0 IPSEC_KEY_MANAGER_DICTATE_KEY0
	// IpsecKeyManagerDictateKey0; DWORD IpsecKeyManagerDictateKey0( IPSEC_SA_DETAILS1 *inboundSaDetails, IPSEC_SA_DETAILS1
	// *outboundSaDetails, BOOL *keyingModuleGenKey ) {...}
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.IPSEC_KEY_MANAGER_DICTATE_KEY0")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate Win32Error IPSEC_KEY_MANAGER_DICTATE_KEY0(ref IPSEC_SA_DETAILS1 inboundSaDetails, ref IPSEC_SA_DETAILS1 outboundSaDetails,
		[MarshalAs(UnmanagedType.Bool)] out bool keyingModuleGenKey);

	/// <summary>
	/// The <c>IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0</c> function indicates whether the Trusted Intermediary Agent (TIA) will dictate the
	/// keys for the SA being negotiated.
	/// </summary>
	/// <param name="ikeTraffic">Specifies the traffic for which keys should be set or retrieved.</param>
	/// <param name="willDictateKey"><see langword="true"/> if the TIA will dictate the keys; otherwise, <see langword="false"/>.</param>
	/// <param name="weight">Specifies the weight that this TIA should be given compared to any peers.</param>
	/// <remarks>
	/// <para>Call IPsecKeyManagerAddAndRegister to register this function pointer.</para>
	/// <para>If the TIA wants to dictate the keys, and its weight is higher than that of any peers, IPsec will subsequently call IPSEC_KEY_MANAGER_DICTATE_KEY0.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-ipsec_key_manager_key_dictation_check0
	// IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0 IpsecKeyManagerKeyDictationCheck0; void IpsecKeyManagerKeyDictationCheck0( [in] const
	// IKEEXT_TRAFFIC0 *ikeTraffic, [out] BOOL *willDictateKey, [out] UINT32 *weight ) {...}
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0(in IKEEXT_TRAFFIC0 ikeTraffic, [MarshalAs(UnmanagedType.Bool)] out bool willDictateKey,
		out uint weight);

	/// <summary>
	/// The IPSEC_KEY_MANAGER_NOTIFY_KEY0 function is used to notify Trusted Intermediary Agents (TIAs) of the keys for the SA being negotiated.
	/// </summary>
	/// <param name="inboundSa">Information about the inbound SA.</param>
	/// <param name="outboundSa">Information about the outbound SA.</param>
	/// <remarks>Call IPsecKeyManagerAddAndRegister to register this function pointer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-ipsec_key_manager_notify_key0 IPSEC_KEY_MANAGER_NOTIFY_KEY0
	// IpsecKeyManagerNotifyKey0; void IpsecKeyManagerNotifyKey0( [in] const IPSEC_SA_DETAILS1 *inboundSa, [in] const IPSEC_SA_DETAILS1
	// *outboundSa ) {...}
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.IPSEC_KEY_MANAGER_NOTIFY_KEY0")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void IPSEC_KEY_MANAGER_NOTIFY_KEY0(in IPSEC_SA_DETAILS1 inboundSa, in IPSEC_SA_DETAILS1 outboundSa);

	/// <summary>
	/// The <c>IPSEC_SA_CONTEXT_CALLBACK0</c> function is used to add custom behavior to the IPsec security association (SA) context
	/// subscription process.
	/// </summary>
	/// <remarks>Call IPsecSaContextSubscribe0 to register this callback function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nc-fwpmu-ipsec_sa_context_callback0 IPSEC_SA_CONTEXT_CALLBACK0
	// IpsecSaContextCallback0; void IpsecSaContextCallback0( [in, out] void *context, [in] const IPSEC_SA_CONTEXT_CHANGE0 *change ) {...}
	[PInvokeData("fwpmu.h", MSDNShortId = "NC:fwpmu.IPSEC_SA_CONTEXT_CALLBACK0")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void IPSEC_SA_CONTEXT_CALLBACK0([In, Out] IntPtr context, in IPSEC_SA_CONTEXT_CHANGE0 change);

	internal delegate Win32Error ArrayFunc(HFWPENG engineHandle, HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries, out uint numEntriesReturned);

	internal delegate Win32Error CreateEnumHandleFunc(HFWPENG engineHandle, IntPtr enumTemplate, out HANDLE enumHandle);

	internal delegate Win32Error DestroyEnumHandleFunc(HFWPENG engineHandle, HANDLE enumHandle);

	internal delegate Win32Error GetById<TIn>(HFWPENG engineHandle, TIn id, out SafeFwpmMem value) where TIn : struct;

	internal delegate Win32Error GetByKey(HFWPENG engineHandle, in Guid key, out SafeFwpmMem value);

	internal delegate Win32Error GetSubs(HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>Flags for <c>FwpmDynamicKeywordSubscribe0</c>.</summary>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmDynamicKeywordSubscribe0")]
	[Flags]
	public enum FWPM_NOTIFY : ulong
	{
		/// <summary>
		/// Notifications will be delivered only for objects that have the FW_DYNAMIC_KEYWORD_ADDRESS_FLAGS_AUTO_RESOLVE flag set.
		/// </summary>
		FWPM_NOTIFY_ADDRESSES_AUTO_RESOLVE = 0x01,

		/// <summary>
		/// Notifications will be delivered only for objects that don't have the FW_DYNAMIC_KEYWORD_ADDRESS_FLAGS_AUTO_RESOLVE flag set.
		/// </summary>
		FWPM_NOTIFY_ADDRESSES_NON_AUTO_RESOLVE = 0x02,

		/// <summary/>
		FWPM_NOTIFY_ADDRESSES_ALL = FWPM_NOTIFY_ADDRESSES_AUTO_RESOLVE | FWPM_NOTIFY_ADDRESSES_NON_AUTO_RESOLVE,

		/// <summary/>
		FWPM_NOTIFY_GRANULAR = 0x04,
	}

	/// <summary>Flags for <c>FwpmIPsecTunnelAdd</c>.</summary>
	[Flags]
	public enum FWPM_TUNNEL_FLAG : uint
	{
		/// <summary>Adds a point-to-point tunnel to the system.</summary>
		FWPM_TUNNEL_FLAG_POINT_TO_POINT = 0x00000001,

		/// <summary>Enables virtual interface-based IPsec tunnel mode.</summary>
		FWPM_TUNNEL_FLAG_ENABLE_VIRTUAL_IF_TUNNELING = 0x00000002,

		/// <summary>Reserved.</summary>
		FWPM_TUNNEL_FLAG_RESERVED0 = 0x00000004,
	}

	/// <summary>Flags for <c>FwpmTransactionBegin0</c>.</summary>
	[Flags]
	public enum FWPM_TXN : uint
	{
		/// <summary>Begin read-only transaction.</summary>
		FWPM_TXN_READ_ONLY = 0x00000001
	}

	/// <summary>IPsec SA flag</summary>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextUpdate0")]
	[Flags]
	public enum IPSEC_SA_BUNDLE_UPDATE : ulong
	{
		/// <summary>Updates the [IPSEC_SA_DETAILS1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_details1) structure.</summary>
		IPSEC_SA_DETAILS_UPDATE_TRAFFIC = 0x01,

		/// <summary>Updates the [IPSEC_SA_DETAILS1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_details1) structure.</summary>
		IPSEC_SA_DETAILS_UPDATE_UDP_ENCAPSULATION = 0x02,

		/// <summary>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</summary>
		IPSEC_SA_BUNDLE_UPDATE_FLAGS = 0x04,

		/// <summary>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</summary>
		IPSEC_SA_BUNDLE_UPDATE_NAP_CONTEXT = 0x08,

		/// <summary>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</summary>
		IPSEC_SA_BUNDLE_UPDATE_KEY_MODULE_STATE = 0x10,

		/// <summary>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</summary>
		IPSEC_SA_BUNDLE_UPDATE_PEER_V4_PRIVATE_ADDRESS = 0x20,

		/// <summary>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</summary>
		IPSEC_SA_BUNDLE_UPDATE_MM_SA_ID = 0x40,
	}

	internal static Win32Error FwpmGenericEnum<TElem, TTemplate>(CreateEnumHandleFunc create, ArrayFunc enum0, DestroyEnumHandleFunc destroy,
			[In] HFWPENG engineHandle, out SafeFwpmArray<TElem> entries, TTemplate? template = null) where TElem : struct where TTemplate : struct
	{
		entries = new(IntPtr.Zero, 0, true);
		using SafeCoTaskMemStruct<TTemplate> pTempl = template;
		Win32Error err = create(engineHandle, pTempl, out HANDLE hEnum);
		if (err.Succeeded)
		{
			try
			{
				err = enum0(engineHandle, hEnum, Kernel32.INFINITE, out SafeFwpmMem mem, out var c);
				entries = new(mem, c, true);
				return err;
			}
			finally
			{
				_=destroy(engineHandle, hEnum);
			}
		}
		return err;
	}

	internal static Win32Error FwpmGenericGetById<T, TIn>(GetById<TIn> func, HFWPENG engineHandle, TIn id, out SafeFwpmStruct<T> value) where T : struct where TIn : struct
	{
		Win32Error err = func(engineHandle, id, out SafeFwpmMem mem);
		value = mem;
		return err;
	}

	internal static Win32Error FwpmGenericGetByKey<T>(GetByKey func, HFWPENG engineHandle, in Guid key, out SafeFwpmStruct<T> value) where T : struct
	{
		Win32Error err = func(engineHandle, key, out SafeFwpmMem mem);
		value = mem;
		return err;
	}

	internal static Win32Error FwpmGenericGetSubs<T>(GetSubs func, HFWPENG engineHandle, out SafeFwpmArray<T> entries) where T : struct
	{
		Win32Error err = func(engineHandle, out SafeFwpmMem mem, out var c);
		entries = new(mem, c);
		return err;
	}

	/// <summary>Provides a handle to a callout change subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPCALLOUTCHANGE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPCALLOUTCHANGE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPCALLOUTCHANGE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPCALLOUTCHANGE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPCALLOUTCHANGE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPCALLOUTCHANGE h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPCALLOUTCHANGE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPCALLOUTCHANGE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPCALLOUTCHANGE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPCALLOUTCHANGE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPCALLOUTCHANGE h1, HFWPCALLOUTCHANGE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPCALLOUTCHANGE h1, HFWPCALLOUTCHANGE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPCALLOUTCHANGE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a connection event.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPCONNEVENT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPCONNEVENT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPCONNEVENT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPCONNEVENT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPCONNEVENT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPCONNEVENT h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPCONNEVENT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPCONNEVENT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPCONNEVENT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPCONNEVENT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPCONNEVENT h1, HFWPCONNEVENT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPCONNEVENT h1, HFWPCONNEVENT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPCONNEVENT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a FWP Session Engine.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPENG : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPENG"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPENG(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPENG"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPENG NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPENG h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPENG"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPENG h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPENG"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPENG(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPENG h1, HFWPENG h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPENG h1, HFWPENG h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPENG h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a subscriptor for dynamic keywords.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMDYNKEYSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMDYNKEYSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMDYNKEYSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMDYNKEYSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMDYNKEYSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMDYNKEYSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMDYNKEYSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMDYNKEYSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMDYNKEYSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMDYNKEYSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMDYNKEYSUB h1, HFWPMDYNKEYSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMDYNKEYSUB h1, HFWPMDYNKEYSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMDYNKEYSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a filter subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMFILTERSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMFILTERSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMFILTERSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMFILTERSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMFILTERSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMFILTERSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMFILTERSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMFILTERSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMFILTERSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMFILTERSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMFILTERSUB h1, HFWPMFILTERSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMFILTERSUB h1, HFWPMFILTERSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMFILTERSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a network event.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMNETEVTSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMNETEVTSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMNETEVTSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMNETEVTSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMNETEVTSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMNETEVTSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMNETEVTSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMNETEVTSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMNETEVTSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMNETEVTSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMNETEVTSUB h1, HFWPMNETEVTSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMNETEVTSUB h1, HFWPMNETEVTSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMNETEVTSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a provider context subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMPROVCTXSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMPROVCTXSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMPROVCTXSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMPROVCTXSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMPROVCTXSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMPROVCTXSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMPROVCTXSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMPROVCTXSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMPROVCTXSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMPROVCTXSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMPROVCTXSUB h1, HFWPMPROVCTXSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMPROVCTXSUB h1, HFWPMPROVCTXSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMPROVCTXSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a provider subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMPROVSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMPROVSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMPROVSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMPROVSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMPROVSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMPROVSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMPROVSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMPROVSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMPROVSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMPROVSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMPROVSUB h1, HFWPMPROVSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMPROVSUB h1, HFWPMPROVSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMPROVSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a SubLayer subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMSUBLAYERSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMSUBLAYERSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMSUBLAYERSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMSUBLAYERSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMSUBLAYERSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMSUBLAYERSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMSUBLAYERSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMSUBLAYERSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMSUBLAYERSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMSUBLAYERSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMSUBLAYERSUB h1, HFWPMSUBLAYERSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMSUBLAYERSUB h1, HFWPMSUBLAYERSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMSUBLAYERSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a switch event subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMSWITCHEVTSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMSWITCHEVTSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMSWITCHEVTSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMSWITCHEVTSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMSWITCHEVTSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMSWITCHEVTSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMSWITCHEVTSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMSWITCHEVTSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMSWITCHEVTSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMSWITCHEVTSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMSWITCHEVTSUB h1, HFWPMSWITCHEVTSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMSWITCHEVTSUB h1, HFWPMSWITCHEVTSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMSWITCHEVTSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a system ports subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFWPMSYSPORTSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFWPMSYSPORTSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFWPMSYSPORTSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFWPMSYSPORTSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFWPMSYSPORTSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFWPMSYSPORTSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFWPMSYSPORTSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFWPMSYSPORTSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFWPMSYSPORTSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPMSYSPORTSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFWPMSYSPORTSUB h1, HFWPMSYSPORTSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFWPMSYSPORTSUB h1, HFWPMSYSPORTSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFWPMSYSPORTSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to an IPSec key manager registration.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HIPSECKEYMGRREG : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HIPSECKEYMGRREG"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HIPSECKEYMGRREG(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HIPSECKEYMGRREG"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HIPSECKEYMGRREG NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HIPSECKEYMGRREG h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HIPSECKEYMGRREG"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HIPSECKEYMGRREG h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIPSECKEYMGRREG"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HIPSECKEYMGRREG(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HIPSECKEYMGRREG h1, HIPSECKEYMGRREG h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HIPSECKEYMGRREG h1, HIPSECKEYMGRREG h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HIPSECKEYMGRREG h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a IPsec SA context subscription.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HIPSECSACTXSUB : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HIPSECSACTXSUB"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HIPSECSACTXSUB(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HIPSECSACTXSUB"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HIPSECSACTXSUB NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HIPSECSACTXSUB h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HIPSECSACTXSUB"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HIPSECSACTXSUB h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIPSECSACTXSUB"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HIPSECSACTXSUB(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HIPSECSACTXSUB h1, HIPSECSACTXSUB h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HIPSECSACTXSUB h1, HIPSECSACTXSUB h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HIPSECSACTXSUB h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// The <c>IPSEC_KEY_MANAGER_CALLBACKS0</c> structure specifies the set of callbacks which should be invoked by IPsec at various stages
	/// of SA negotiation
	/// </summary>
	/// <remarks>
	/// If the <c>IPSEC_KEY_MANAGER_FLAG_DICTATE_KEY</c> flag is set, all three callbacks must be specified; otherwise, only the
	/// <c>keyNotify</c> callback should be specified.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/ns-fwpmu-ipsec_key_manager_callbacks0 typedef struct
	// _IPSEC_KEY_MANAGER_CALLBACKS0 { GUID reserved; UINT32 flags; IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0 keyDictationCheck;
	// IPSEC_KEY_MANAGER_DICTATE_KEY0 keyDictation; IPSEC_KEY_MANAGER_NOTIFY_KEY0 keyNotify; } IPSEC_KEY_MANAGER_CALLBACKS0;
	[PInvokeData("fwpmu.h", MSDNShortId = "NS:fwpmu._IPSEC_KEY_MANAGER_CALLBACKS0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPSEC_KEY_MANAGER_CALLBACKS0
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>Reserved for system use.</para>
		/// </summary>
		public Guid reserved;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Reserved for system use.</para>
		/// </summary>
		public uint flags;

		/// <summary>
		/// <para>Type: <c>IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0</c></para>
		/// <para>
		/// Specifies that the Trusted Intermediary Agent (TIA) will dictate the keys for the SA being negotiated. Only used if the
		/// <c>IPSEC_DICTATE_KEY</c> flag is set.
		/// </para>
		/// </summary>
		public IPSEC_KEY_MANAGER_KEY_DICTATION_CHECK0 keyDictationCheck;

		/// <summary>
		/// <para>Type: <c>IPSEC_KEY_MANAGER_DICTATE_KEY0</c></para>
		/// <para>Allows the TIA to dictate the keys for the SA being negotiated. Only used if the <c>IPSEC_DICTATE_KEY</c> flag is set.</para>
		/// </summary>
		public IPSEC_KEY_MANAGER_DICTATE_KEY0 keyDictation;

		/// <summary>
		/// <para>Type: <c>IPSEC_KEY_MANAGER_NOTIFY_KEY0</c></para>
		/// <para>Notifies the TIA of the keys for the SA being negotiated.</para>
		/// </summary>
		public IPSEC_KEY_MANAGER_NOTIFY_KEY0 keyNotify;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for memory returned by FWP functions that is disposed using <see cref="FwpmFreeMemory0"/>.</summary>
	public class SafeFwpmArray<T> : SafeHANDLE, IReadOnlyList<T> where T : struct
	{
		private readonly bool byRef;

		internal SafeFwpmArray(IntPtr preexistingHandle, SizeT count, bool byRef = false) : base(preexistingHandle, true)
		{
			Count = count; this.byRef = byRef;
		}

		internal SafeFwpmArray(SafeFwpmMem preexistingHandle, SizeT count, bool byRef = false) : this(preexistingHandle.ReleaseOwnership(), count, byRef)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeFwpmMem"/> class.</summary>
		private SafeFwpmArray() : base(IntPtr.Zero, true) { }

		/// <inheritdoc/>
		public int Count { get; private set; }

		/// <inheritdoc/>
		public T this[int index] => index >= 0 && index < Count ? Enumerate().ElementAt(index) : throw new ArgumentOutOfRangeException(nameof(index));

		/// <inheritdoc/>
		public IEnumerator<T> GetEnumerator() => Enumerate().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { FwpmFreeMemory0(ref handle); handle = default; return true; }

		private IEnumerable<T> Enumerate() => byRef ? handle.ToIEnum<IntPtr>(Count).Select(p => p.Convert<T>(uint.MaxValue, CharSet.Unicode)) : handle.ToIEnum<T>(Count);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for memory returned by FWP functions that is disposed using <see cref="FwpmFreeMemory0"/>.</summary>
	public class SafeFwpmMem : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeFwpmMem"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeFwpmMem(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeFwpmMem"/> class.</summary>
		private SafeFwpmMem() : base(IntPtr.Zero, true) { }

		/// <summary>Performs an explicit conversion from <see cref="SafeFwpmMem"/> to <see cref="PSECURITY_DESCRIPTOR"/>.</summary>
		/// <param name="h">The safe handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator PSECURITY_DESCRIPTOR(SafeFwpmMem h) => h.handle;

		/// <summary>Extracts an array of elements from this memory.</summary>
		/// <typeparam name="T">The type of the array element to return.</typeparam>
		/// <param name="elemCount">The element count.</param>
		/// <param name="byRef">
		/// if set to <see langword="true"/> the array is extracted from a list of pointers to <typeparamref name="T"/>, rather than an array
		/// of elements.
		/// </param>
		/// <returns>An array of type <typeparamref name="T"/> of length <paramref name="elemCount"/>.</returns>
		public T[] ToArray<T>(SizeT elemCount, bool byRef) => byRef ? Array.ConvertAll(handle.ToArray<IntPtr>(elemCount) ?? new IntPtr[0], p => p.Convert<T>(uint.MaxValue, CharSet.Unicode)) : handle.ToArray<T>(elemCount) ?? new T[0];

		/// <summary>Extracts a structure from this memory.</summary>
		/// <typeparam name="T">The type of the structure to extract.</typeparam>
		/// <returns>The structure or <see langword="null"/> if the handle is invalid.</returns>
		public T? ToStructure<T>() where T : struct => handle.ToNullableStructure<T>();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { FwpmFreeMemory0(ref handle); handle = default; return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for memory returned by FWP functions that is disposed using <see cref="FwpmFreeMemory0"/>.</summary>
	public class SafeFwpmStruct<T> : SafeHANDLE where T : struct
	{
		internal SafeFwpmStruct(IntPtr preexistingHandle) : base(preexistingHandle, true)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeFwpmMem"/> class.</summary>
		private SafeFwpmStruct() : base(IntPtr.Zero, true) { }

		/// <summary>Gets the nullable value of the structue pointed to in memory.</summary>
		/// <value>The value.</value>
		public T? Value => handle.ToNullableStructure<T>();

		/// <summary>Performs an implicit conversion from <see cref="SafeFwpmMem"/> to <see cref="SafeFwpmStruct{T}"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeFwpmStruct<T>(SafeFwpmMem p) => new(p.ReleaseOwnership());

		/// <summary>Performs an implicit conversion from <see cref="SafeFwpmStruct{T}"/> to <typeparamref name="T"/>.</summary>
		/// <param name="h">The safe handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator T(SafeFwpmStruct<T> h) => h.Value.GetValueOrDefault();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { FwpmFreeMemory0(ref handle); handle = default; return true; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HFWPENG"/> that is disposed using <see cref="FwpmEngineClose0"/>.</summary>
	public class SafeHFWPENG : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHFWPENG"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHFWPENG(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHFWPENG"/> class.</summary>
		private SafeHFWPENG() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHFWPENG"/> to <see cref="HFWPENG"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFWPENG(SafeHFWPENG h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => FwpmEngineClose0(handle).Succeeded;
	}
}