using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.Qwave;

namespace Vanara.PInvoke;

/// <summary>Items from Traffic.dll.</summary>
public static partial class Traffic
{
	/// <summary>The current traffic control version.</summary>
	public const uint CURRENT_TCI_VERSION = 0x0002;

	private const string Lib_Traffic = "traffic.dll";

	private const int MAX_STRING_LENGTH = 256;

	/// <summary>
	/// <para>
	/// The <c>ClAddFlowComplete</c> function is used by traffic control to notify the client of the completion of its previous call to the
	/// TcAddFlow function.
	/// </para>
	/// <para>
	/// The <c>ClAddFlowComplete</c> callback function is optional. If this function is not specified, TcAddFlow will block until it completes.
	/// </para>
	/// </summary>
	/// <param name="ClFlowCtx">
	/// Client provided–flow context handle. This can be the container used to hold an arbitrary client-defined context for this instance of
	/// the client. This value will be the same as the value provided by the client during its corresponding call to TcAddFlow.
	/// </param>
	/// <param name="Status">
	/// <para>
	/// Completion status for the TcAddFlow request. This value may be any of the return values possible for the <c>TcAddFlow</c> function,
	/// with the exception of ERROR_SIGNAL_PENDING.
	/// </para>
	/// <para><c>Note</c> Use of the <c>ClAddFlowComplete</c> function requires administrative privilege.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nc-traffic-tci_add_flow_complete_handler TCI_ADD_FLOW_COMPLETE_HANDLER
	// TciAddFlowCompleteHandler; void TciAddFlowCompleteHandler( [in] HANDLE ClFlowCtx, [in] ULONG Status ) {...}
	[PInvokeData("traffic.h", MSDNShortId = "NC:traffic.TCI_ADD_FLOW_COMPLETE_HANDLER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void TCI_ADD_FLOW_COMPLETE_HANDLER([In] IntPtr ClFlowCtx, Win32Error Status);

	/// <summary>
	/// <para>
	/// The <c>ClDeleteFlowComplete</c> function is used by traffic control to notify the client of the completion of its previous call to
	/// the TcDeleteFlow function.
	/// </para>
	/// <para>
	/// The <c>ClDeleteFlowComplete</c> callback function is optional. If this function is not specified, TcDeleteFlow will block until it completes.
	/// </para>
	/// </summary>
	/// <param name="ClFlowCtx">
	/// Client provided–flow context handle. This can be the container used to hold an arbitrary client-defined context for this instance of
	/// the client. This value will be the same as the value provided by the client during its corresponding call to TcDeleteFlow.
	/// </param>
	/// <param name="Status">
	/// <para>
	/// Completion status for the TcDeleteFlow request. This value may be any of the return values possible for the <c>TcDeleteFlow</c>
	/// function, with the exception of ERROR_SIGNAL_PENDING.
	/// </para>
	/// <para><c>Note</c> Use of the <c>ClDeleteFlowComplete</c> function requires administrative privilege.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nc-traffic-tci_del_flow_complete_handler TCI_DEL_FLOW_COMPLETE_HANDLER
	// TciDelFlowCompleteHandler; void TciDelFlowCompleteHandler( [in] HANDLE ClFlowCtx, [in] ULONG Status ) {...}
	[PInvokeData("traffic.h", MSDNShortId = "NC:traffic.TCI_DEL_FLOW_COMPLETE_HANDLER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void TCI_DEL_FLOW_COMPLETE_HANDLER([In] IntPtr ClFlowCtx, Win32Error Status);

	/// <summary>
	/// <para>
	/// The <c>ClModifyFlowComplete</c> function is used by traffic control to notify the client of the completion of its previous call to
	/// the TcModifyFlow function.
	/// </para>
	/// <para>
	/// The <c>ClModifyFlowComplete</c> callback function is optional. If this function is not specified, TcModifyFlow will block until it completes.
	/// </para>
	/// </summary>
	/// <param name="ClFlowCtx">
	/// Client provided–flow context handle. This can be the container used to hold an arbitrary client-defined context for this instance of
	/// the client. This value will be the same as the value provided by the client during its corresponding call to TcModifyFlow.
	/// </param>
	/// <param name="Status">
	/// <para>
	/// Completion status for the TcModifyFlow request. This value may be any of the return values possible for the <c>TcModifyFlow</c>
	/// function, with the exception of ERROR_SIGNAL_PENDING.
	/// </para>
	/// <para><c>Note</c> Use of the <c>ClModifyFlowComplete</c> function requires administrative privilege.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nc-traffic-tci_mod_flow_complete_handler TCI_MOD_FLOW_COMPLETE_HANDLER
	// TciModFlowCompleteHandler; void TciModFlowCompleteHandler( [in] HANDLE ClFlowCtx, [in] ULONG Status ) {...}
	[PInvokeData("traffic.h", MSDNShortId = "NC:traffic.TCI_MOD_FLOW_COMPLETE_HANDLER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void TCI_MOD_FLOW_COMPLETE_HANDLER([In] IntPtr ClFlowCtx, Win32Error Status);

	/// <summary>
	/// <para>
	/// The <c>ClNotifyHandler</c> function is used by traffic control to notify the client of various traffic control–specific events,
	/// including the deletion of flows, changes in filter parameters, or the closing of an interface.
	/// </para>
	/// <para>The <c>ClNotifyHandler</c> callback function should be exposed by all clients using traffic control services.</para>
	/// </summary>
	/// <param name="ClRegCtx">
	/// Client registration context, provided to traffic control by the client with the client's call to the TcRegisterClient function.
	/// </param>
	/// <param name="ClIfcCtx">
	/// Client interface context, provided to traffic control by the client with the client's call to the TcOpenInterface function. Note that
	/// during a TC_NOTIFY_IFC_UP event, <c>ClIfcCtx</c> is not available and will be set to <c>NULL</c>.
	/// </param>
	/// <param name="Event">Describes the notification event. See the Remarks section for a list of notification events.</param>
	/// <param name="SubCode">Handle used to further qualify a notification event. See Note below for 64-bit for Windows programming issues.</param>
	/// <param name="BufSize">Size of the buffer included with the notification event, in bytes.</param>
	/// <param name="Buffer">Buffer containing the detailed event information associated with <c>Event</c> and <c>SubCode</c>.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Notification events may require the traffic control client to take particular action or respond appropriately, for example, removing
	/// filters or enumerating flows for affected interfaces.
	/// </para>
	/// <para>The following table describes the various notification events.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Event</term>
	/// <term>SubCode</term>
	/// <term>Buffer contents</term>
	/// <term>Remarks</term>
	/// </listheader>
	/// <item>
	/// <term>TC_NOTIFY_IFC_UP</term>
	/// <term>None</term>
	/// <term>Interface name of the new interface</term>
	/// <term>A new traffic control interface is coming up, and the list of addresses is indicated.</term>
	/// </item>
	/// <item>
	/// <term>TC_NOTIFY_IFC_CLOSE</term>
	/// <term>Reason for close</term>
	/// <term>Interface name of the closed interface</term>
	/// <term>
	/// Indicates an interface that was opened by the client is being closed by the system. Note that the interface and its supported flows
	/// and filters are closed by the system upon return from the notification handler. The client does not need to close the interface,
	/// delete flows, or delete filters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TC_NOTIFY_IFC_CHANGE</term>
	/// <term>None</term>
	/// <term>New parameter value</term>
	/// <term>
	/// Used to notify clients that have registered for interface change notification through the <c>NotifyChange</c> parameter of the
	/// TcQueryInterface function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TC_NOTIFY_PARAM_CHANGED</term>
	/// <term>Pointer to the GUID for a traffic control parameter queried using the TcQueryInterface function.</term>
	/// <term>New parameter value</term>
	/// <term>This event is notified as a result of a change in a parameter previously queried with the <c>NotifyChange</c> flag set.</term>
	/// </item>
	/// <item>
	/// <term>TC_NOTIFY_FLOW_CLOSE</term>
	/// <term><c>ClFlowCtx</c></term>
	/// <term/>
	/// <term>Indicates system closure of a client-created flow. The system deletes all associated filters.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Use of the <c>ClNotifyHandler</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nc-traffic-tci_notify_handler TCI_NOTIFY_HANDLER TciNotifyHandler; void
	// TciNotifyHandler( [in] HANDLE ClRegCtx, [in] HANDLE ClIfcCtx, [in] ULONG Event, [in] HANDLE SubCode, [in] ULONG BufSize, [in] PVOID
	// Buffer ) {...}
	[PInvokeData("traffic.h", MSDNShortId = "NC:traffic.TCI_NOTIFY_HANDLER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void TCI_NOTIFY_HANDLER([In] IntPtr ClRegCtx, [In] IntPtr ClIfcCtx, TC_NOTIFY Event, [In] IntPtr SubCode,
		uint BufSize, [In] IntPtr Buffer);

	/// <summary>Describes the notification event.</summary>
	[PInvokeData("traffic.h", MSDNShortId = "NC:traffic.TCI_NOTIFY_HANDLER")]
	public enum TC_NOTIFY : uint
	{
		/// <summary>A new traffic control interface is coming up, and the list of addresses is indicated.</summary>
		TC_NOTIFY_IFC_UP = 1,

		/// <summary>
		/// Indicates an interface that was opened by the client is being closed by the system. Note that the interface and its supported
		/// flows and filters are closed by the system upon return from the notification handler. The client does not need to close the
		/// interface, delete flows, or delete filters.
		/// </summary>
		TC_NOTIFY_IFC_CLOSE = 2,

		/// <summary>
		/// Used to notify clients that have registered for interface change notification through the NotifyChange parameter of the
		/// TcQueryInterface function.
		/// </summary>
		TC_NOTIFY_IFC_CHANGE = 3,

		/// <summary>This event is notified as a result of a change in a parameter previously queried with the NotifyChange flag set.</summary>
		TC_NOTIFY_PARAM_CHANGED = 4,

		/// <summary>Indicates system closure of a client-created flow. The system deletes all associated filters.</summary>
		TC_NOTIFY_FLOW_CLOSE = 5,
	}

	/// <summary>
	/// <para>
	/// The <c>TcAddFilter</c> function associates a new filter with an existing flow that allows packets matching the filter to be directed
	/// to the associated flow.
	/// </para>
	/// <para>
	/// Filters include a pattern and a mask. The pattern specifies particular parameter values, while the mask specifies which parameters
	/// and parameter subfields apply to a given filter. When a pattern/mask combination is applied to a set of packets, matching packets are
	/// directed to the flow to which the corresponding filter is associated.
	/// </para>
	/// <para>
	/// Traffic control returns a handle to the newly added filter, in the pFilterHandle parameter, by which clients can refer to the added
	/// filter. Pending flows, such as those processing a TcAddFlow or TcModifyFlow request for which a callback routine has not been
	/// completed, cannot have filters associated to them; only flows that have been completed and are stable can apply associated filters.
	/// </para>
	/// <para>
	/// The relationship between filters and flows is many to one. Multiple filters can be applied to a single flow; however, a filter can
	/// only apply to one flow. For example, flow A can have filters X, Y and Z applied to it, but as long as flow A is active, filters X, Y
	/// and Z cannot apply to any other flows.
	/// </para>
	/// </summary>
	/// <param name="FlowHandle">Handle for the flow, as received from a previous call to the TcAddFlow function.</param>
	/// <param name="pGenericFilter">Pointer to a description of the filter to be installed.</param>
	/// <param name="pFilterHandle">
	/// Pointer to a buffer where traffic control returns the filter handle. This filter handle is used by the client in subsequent calls to
	/// refer to the added filter.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The flow handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_ADDRESS_TYPE</c></term>
	/// <term>An invalid address type has been provided.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DUPLICATE_FILTER</c></term>
	/// <term>An identical filter exists on a flow on this interface.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILTER_CONFLICT</c></term>
	/// <term>A conflicting filter exists on a flow on this interface.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT READY</c></term>
	/// <term>The flow is either being installed, modified, or deleted, and is not in a state that accepts filters.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Filters can be of different types. They are typically used to filter packets belonging to different network layers. Filter types
	/// installed on an interface generally correspond to the address types of the network layer addresses associated with the interface. The
	/// address type should be specified in the filter structure.
	/// </para>
	/// <para>
	/// Filters may be rejected for various reasons, including possible conflicts with the requested filter as well as filters already
	/// associated with the flow. Error codes specific to traffic control are provided to help the user diagnose the reason behind a
	/// rejection to the <c>TcAddFilter</c> function.
	/// </para>
	/// <para><c>Note</c> Use of the <c>TcAddFilter</c> function requires administrative privilege.</para>
	/// <para>In Windows Vista, overlapping and identical filters can be created. In these situations, the more specific filter takes precedence.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcaddfilter ULONG TcAddFilter( [in] HANDLE FlowHandle, [in]
	// PTC_GEN_FILTER pGenericFilter, [out] PHANDLE pFilterHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcAddFilter")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcAddFilter([In] HFLOW FlowHandle, in TC_GEN_FILTER pGenericFilter, out SafeHFILTER pFilterHandle);

	/// <summary>
	/// <para>
	/// The <c>TcAddFlow</c> function adds a new flow on the specified interface. Note that the successful addition of a flow does not
	/// necessarily indicate a change in the way traffic is handled; traffic handling changes are effected by attaching a filter to the added
	/// flow, using the TcAddFilter function.
	/// </para>
	/// <para>
	/// Traffic control clients that have registered an <c>AddFlowComplete</c> handler (a mechanism for allowing traffic control to call the
	/// ClAddFlowComplete callback function in order to alert clients of completed flow additions) can expect a return value of
	/// ERROR_SIGNAL_PENDING. For more information, see Traffic Control Objects.
	/// </para>
	/// </summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface on which the flow is to be added. This handle is obtained by a previous call to the
	/// TcOpenInterface function.
	/// </param>
	/// <param name="ClFlowCtx">Client provided–flow context handle. Used subsequently by traffic control when referring to the added flow.</param>
	/// <param name="Flags">Reserved for future use. Must be set to zero.</param>
	/// <param name="pGenericFlow">Pointer to a description of the flow being installed.</param>
	/// <param name="pFlowHandle">
	/// Pointer to a location into which traffic control will return the flow handle. This flow handle should be used in subsequent calls to
	/// traffic control to refer to the installed flow.
	/// </param>
	/// <returns>
	/// <para>
	/// There are many reasons why a request to add a flow might be rejected. Error codes returned by traffic control from calls to
	/// <c>TcAddFlow</c> are provided to aid in determining the reason for rejection.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SIGNAL_PENDING</c></term>
	/// <term>
	/// The function is being executed asynchronously; the client will be called back through the client-exposed ClAddFlowComplete function
	/// when the flow has been added or when the process has been completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The interface handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SERVICE_TYPE</c></term>
	/// <term>An unspecified or bad <c>INTSERV</c> service type has been provided.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TOKEN_RATE</c></term>
	/// <term>An unspecified or bad TOKENRATE value has been provided.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PEAK_RATE</c></term>
	/// <term>The PEAKBANDWIDTH value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SD_MODE</c></term>
	/// <term>The SHAPEDISCARDMODE is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_QOS_PRIORITY</c></term>
	/// <term>The priority value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TRAFFIC_CLASS</c></term>
	/// <term>The traffic class value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are not enough resources to accommodate the requested flow.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TC_OBJECT_LENGTH_INVALID</c></term>
	/// <term>Bad length specified for the TC objects.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_DIFFSERV_FLOW</c></term>
	/// <term>Applies to Diffserv flows. Indicates that the QOS_DIFFSERV object was passed with an invalid parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DS_MAPPING_EXISTS</c></term>
	/// <term>
	/// Applies to Diffserv flows. Indicates that the QOS_DIFFSERV_RULE specified in TC_GEN_FLOW already applies to an existing flow on the interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SHAPE_RATE</c></term>
	/// <term>The QOS_SHAPING_RATE object was passed with an invalid <c>ShapingRate</c> member.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_DS_CLASS</c></term>
	/// <term>The QOS_DS_CLASS is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NETWORK_UNREACHABLE</c></term>
	/// <term>The network cable is not plugged into the adapter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>TcAddFlow</c> function returns ERROR_SIGNAL_PENDING, the ClAddFlowComplete function will be called on a different thread
	/// than the thread that called the <c>TcAddFlow</c> function.
	/// </para>
	/// <para>
	/// Only the addition of a filter will affect traffic control. However, the addition of a flow will cause resources to be committed
	/// within traffic control components. This enables traffic control to prepare for handling traffic on the added flow.
	/// </para>
	/// <para>
	/// Traffic control may delete a flow for various reasons, including the inability to accommodate the flow due to bandwidth restrictions,
	/// and adjusted policy requirements. Clients are notified of deleted flows through the ClNotifyHandler callback function, with the
	/// TC_NOTIFY_FLOW_CLOSE event.
	/// </para>
	/// <para><c>Note</c> Use of the <c>TcAddFlow</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcaddflow ULONG TcAddFlow( [in] HANDLE IfcHandle, [in] HANDLE
	// ClFlowCtx, [in] ULONG Flags, [in] PTC_GEN_FLOW pGenericFlow, [out] PHANDLE pFlowHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcAddFlow")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcAddFlow([In] HIFC IfcHandle, [In] IntPtr ClFlowCtx, [Optional] uint Flags,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<TC_GEN_FLOW>))]
		TC_GEN_FLOW pGenericFlow, out SafeHFLOW pFlowHandle);

	/// <summary>
	/// The <c>TcCloseInterface</c> function closes an interface previously opened with a call to TcOpenInterface. All flows and filters on a
	/// particular interface should be closed before closing the interface with a call to <c>TcCloseInterface</c>.
	/// </summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface to be closed. This handle is obtained by a previous call to the TcOpenInterface function.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The interface handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TC_SUPPORTED_OBJECTS_EXIST</c></term>
	/// <term>Not all flows have been deleted for this interface.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Regardless of whether <c>TcCloseInterface</c> is called, an interface will be closed following a TC_NOTIFY_IFC_CLOSE notification
	/// event. If the <c>TcCloseInterface</c> function is called with the handle of an interface that has already been closed, the handle
	/// will be invalidated and <c>TcCloseInterface</c> will return ERROR_INVALID_HANDLE.
	/// </para>
	/// <para><c>Note</c> Use of <c>TcCloseInterface</c> requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tccloseinterface ULONG TcCloseInterface( [in] HANDLE IfcHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcCloseInterface")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcCloseInterface([In] HIFC IfcHandle);

	/// <summary>The <c>TcDeleteFilter</c> function deletes a filter previously added with the TcAddFilter function.</summary>
	/// <param name="FilterHandle">Handle to the filter to be deleted, as received in a previous call to the TcAddFilter function.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The filter handle is invalid.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Use of the <c>TcDeleteFilter</c> function requires administrative privilege.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcdeletefilter ULONG TcDeleteFilter( [in] HANDLE FilterHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcDeleteFilter")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcDeleteFilter([In] HFILTER FilterHandle);

	/// <summary>
	/// <para>
	/// The <c>TcDeleteFlow</c> function deletes a flow that has been added with the TcAddFlow function. Clients should delete all filters
	/// associated with a flow before deleting it, otherwise, an error will be returned and the function will not delete the flow.
	/// </para>
	/// <para>
	/// Traffic control clients that have registered a <c>DeleteFlowComplete</c> handler (a mechanism for allowing traffic control to call
	/// the ClDeleteFlowComplete callback function to alert clients of completed flow deletions) can expect a return value of ERROR_SIGNAL_PENDING.
	/// </para>
	/// </summary>
	/// <param name="FlowHandle">Handle for the flow, as received from a previous call to the TcAddFlow function.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SIGNAL_PENDING</c></term>
	/// <term>
	/// The function is being executed asynchronously; the client will be called back through the client-exposed ClDeleteFlowComplete
	/// function when the flow has been added, or when the process has been completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The flow handle is invalid or <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_READY</c></term>
	/// <term>Action performed on the flow by a previous function call to TcModifyFlow, TcDeleteFlow, or TcAddFlow has not yet completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TC_SUPPORTED_OBJECTS_EXIST</c></term>
	/// <term>At least one filter associated with this flow exists.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>TcDeleteFlow</c> function returns ERROR_SIGNAL_PENDING, the ClDeleteFlowComplete function will be called on a different
	/// thread than the thread that called the <c>TcDeleteFlow</c> function.
	/// </para>
	/// <para><c>Note</c> Use of the <c>TcDeleteFlow</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcdeleteflow ULONG TcDeleteFlow( [in] HANDLE FlowHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcDeleteFlow")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcDeleteFlow([In] HFLOW FlowHandle);

	/// <summary>
	/// The <c>TcDeregisterClient</c> function deregisters a client with the Traffic Control Interface (TCI). Before deregistering, a client
	/// must delete each installed flow and filter with the TcDeleteFlow and TcDeleteFilter functions, and close all open interfaces with the
	/// TcCloseInterface function, respectively.
	/// </summary>
	/// <param name="ClientHandle">Handle assigned to the client through the previous call to the TcRegisterClient function.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>Invalid interface handle, or the handle was set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TC_SUPPORTED_OBJECTS_EXIST</c></term>
	/// <term>Interfaces are still open for this client. all interfaces must be closed to deregister a client.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Once a client calls <c>TcDeregisterClient</c>, the only traffic control function the client is allowed to call is TcRegisterClient.</para>
	/// <para><c>Note</c> Use of the <c>TcDeregisterClient</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcderegisterclient ULONG TcDeregisterClient( [in] HANDLE
	// ClientHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcDeregisterClient")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcDeregisterClient([In] HCLIENT ClientHandle);

	/// <summary>
	/// <para>The <c>TcEnumerateFlows</c> function enumerates installed flows and their associated filters on an interface.</para>
	/// <para>
	/// The process of returning flow enumeration often consists of multiple calls to the <c>TcEnumerateFlows</c> function. The process of
	/// receiving flow information from <c>TcEnumerateFlows</c> can be compared to reading through a book in multiple sittings, where a
	/// certain number of pages are read at one time, a bookmark is placed where reading stops, reading is resumed at the bookmark, and
	/// continues until the book is finished.
	/// </para>
	/// <para>
	/// The <c>TcEnumerateFlows</c> function fills the <c>Buffer</c> parameter with as many flow enumerations as the buffer can hold, then
	/// returns a handle in the pEnumToken parameter that internally bookmarks where the enumeration stopped. Subsequent calls to
	/// <c>TcEnumerateFlows</c> must then pass the returned <c>pEnumToken</c> value to instruct traffic control where to resume flow
	/// enumeration information. When all flows have been enumerated, <c>pEnumToken</c> will be <c>NULL</c>.
	/// </para>
	/// </summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface on which flows are to be enumerated. This handle is obtained by a previous call to the
	/// TcOpenInterface function.
	/// </param>
	/// <param name="pEnumHandle">
	/// <para>Pointer to the enumeration token, used internally by traffic control to maintain returned flow information state.</para>
	/// <para>
	/// For input of the initial call to <c>TcEnumerateFlows</c>, <c>pEnumToken</c> should be set to <c>NULL</c>. For input on subsequent
	/// calls, <c>pEnumToken</c> must be the value returned as the <c>pEnumToken</c> OUT parameter from the immediately preceding call to <c>TcEnumerateFlows</c>.
	/// </para>
	/// <para>For output, <c>pEnumToken</c> is the refreshed enumeration token that must be used in the following call to <c>TcEnumerateFlows</c>.</para>
	/// </param>
	/// <param name="pFlowCount">
	/// Pointer to the number of requested or returned flows. For input, this parameter designates the number of requested flows or it can be
	/// set to <c>0xFFFF</c> to request all flows. For output, <c>pFlowCount</c> returns the number of flows actually returned in <c>Buffer</c>.
	/// </param>
	/// <param name="pBufSize">
	/// Pointer to the size of the client-provided buffer or the number of bytes used by traffic control. For input, points to the size of
	/// <c>Buffer</c>, in bytes. For output, points to the actual amount of buffer space, in bytes, written or needed with flow enumerations.
	/// </param>
	/// <param name="Buffer">
	/// Pointer to the buffer containing flow enumerations. See ENUMERATION_BUFFER for more information about flow enumerations.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>Invalid interface handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the pointers is <c>NULL</c>, or <c>pFlowCount</c> or <c>pBufSize</c> are set to zero.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer is too small to store even a single flow's information and attached filters.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_DATA</c></term>
	/// <term>The enumeration token is no longer valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Do not request zero flows, or pass a buffer with a size equal to zero or pointer to a <c>NULL</c>.</para>
	/// <para>
	/// If an enumeration token pointer has been invalidated by traffic control (due to the deletion of a flow), continuing to enumerate
	/// flows is not allowed, and the call will return ERROR_INVALID_DATA. Under this circumstance, the process of enumeration must start
	/// over. This circumstance can occur when the next flow to be enumerated is deleted while enumeration is in progress.
	/// </para>
	/// <para>To get the total number of flows for a given interface, call TcQueryInterface and specify <c>GUID_QOS_FLOW_COUNT</c>.</para>
	/// <para><c>Note</c> Use of the <c>TcEnumerateFlows</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcenumerateflows ULONG TcEnumerateFlows( [in] HANDLE IfcHandle,
	// [in, out] PHANDLE pEnumHandle, [in, out] PULONG pFlowCount, [in, out] PULONG pBufSize, [out] PENUMERATION_BUFFER Buffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcEnumerateFlows")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcEnumerateFlows([In] HIFC IfcHandle, ref HFLOWENUM pEnumHandle, ref uint pFlowCount, ref uint pBufSize, [Out] IntPtr Buffer);

	/// <summary>
	/// <para>The <c>TcEnumerateFlows</c> function enumerates installed flows and their associated filters on an interface.</para>
	/// <para>
	/// The process of returning flow enumeration often consists of multiple calls to the <c>TcEnumerateFlows</c> function. The process of
	/// receiving flow information from <c>TcEnumerateFlows</c> can be compared to reading through a book in multiple sittings, where a
	/// certain number of pages are read at one time, a bookmark is placed where reading stops, reading is resumed at the bookmark, and
	/// continues until the book is finished.
	/// </para>
	/// <para>
	/// The <c>TcEnumerateFlows</c> function fills the <c>Buffer</c> parameter with as many flow enumerations as the buffer can hold, then
	/// returns a handle in the pEnumToken parameter that internally bookmarks where the enumeration stopped. Subsequent calls to
	/// <c>TcEnumerateFlows</c> must then pass the returned <c>pEnumToken</c> value to instruct traffic control where to resume flow
	/// enumeration information. When all flows have been enumerated, <c>pEnumToken</c> will be <c>NULL</c>.
	/// </para>
	/// </summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface on which flows are to be enumerated. This handle is obtained by a previous call to the
	/// TcOpenInterface function.
	/// </param>
	/// <param name="pFlowCount">The number of requested flows or it can be set to <c>0xFFFF</c> to request all flows.</param>
	/// <returns>An allocated buffer with the <see cref="ENUMERATION_BUFFER"/> contents.</returns>
	/// <remarks>
	/// <para>Do not request zero flows.</para>
	/// <para>
	/// If an enumeration token pointer has been invalidated by traffic control (due to the deletion of a flow), continuing to enumerate
	/// flows is not allowed, and the call will return ERROR_INVALID_DATA. Under this circumstance, the process of enumeration must start
	/// over. This circumstance can occur when the next flow to be enumerated is deleted while enumeration is in progress.
	/// </para>
	/// <para>To get the total number of flows for a given interface, call TcQueryInterface and specify <c>GUID_QOS_FLOW_COUNT</c>.</para>
	/// <para><c>Note</c> Use of the <c>TcEnumerateFlows</c> function requires administrative privilege.</para>
	/// </remarks>
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcEnumerateFlows")]
	public static ENUMERATION_BUFFER_MGD TcEnumerateFlows(HIFC IfcHandle, uint pFlowCount = 0xFFFF)
	{
		HFLOWENUM hEnum = default;
		uint bufSz = 1024, cnt;
		SafeCoTaskMemHandle buf = new(bufSz);
		Win32Error err;
		do
		{
			cnt = pFlowCount;
			buf.Size = bufSz;
			err = TcEnumerateFlows(IfcHandle, ref hEnum, ref cnt, ref bufSz, buf);
		} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
		err.ThrowIfFailed();
		return cnt > 0 ? new(buf) : default;
	}

	/// <summary>
	/// The <c>TcEnumerateInterfaces</c> function enumerates all traffic control–enabled network interfaces. Clients are notified of
	/// interface changes through the ClNotifyHandler function.
	/// </summary>
	/// <param name="ClientHandle">
	/// Handle used by traffic control to identify the client. Clients receive handles when registering with traffic control through the
	/// TcRegisterClient function.
	/// </param>
	/// <param name="pBufferSize">
	/// Pointer to a value indicating the size of the buffer. For input, this value is the size of the buffer, in bytes, allocated by the
	/// caller. For output, this value is the actual size of the buffer, in bytes, used or needed by traffic control. A value of zero on
	/// output indicates that no traffic control interfaces are available, indicating that the QOS Packet Scheduler is not installed.
	/// </param>
	/// <param name="InterfaceBuffer">Pointer to the buffer containing the returned list of interface descriptors.</param>
	/// <returns>
	/// <para>Successful completion returns the device name of the interface.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The client handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters is <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The buffer is too small to enumerate all interfaces. If this error is returned, the correct (required) size of the buffer is passed
	/// back in <c>pBufferSize</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The client calling the <c>TcEnumerateInterfaces</c> function must first allocate a buffer, then pass the buffer to traffic control
	/// through <c>InterfaceBuffer</c>. Traffic control returns a pointer to an array of interface descriptors in <c>InterfaceBuffer</c>.
	/// Each interface descriptor contains two elements:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The traffic control interface's identifying text string.</term>
	/// </item>
	/// <item>
	/// <term>The network address list descriptor currently associated with the interface.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The network address list descriptor includes the media type, as well as a list of network addresses. The media type determines how
	/// the network address list should be interpreted:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// For connectionless media such as a LAN, the network address list contains all the protocol-specific addresses associated with the interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term>For connection-oriented media such as a WAN, the network address list contains an even number of network addresses:</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Use of the <c>TcEnumerateInterfaces</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcenumerateinterfaces ULONG TcEnumerateInterfaces( [in] HANDLE
	// ClientHandle, [in, out] PULONG pBufferSize, [out] PTC_IFC_DESCRIPTOR InterfaceBuffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcEnumerateInterfaces")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcEnumerateInterfaces([In] HCLIENT ClientHandle, ref uint pBufferSize, [Out] IntPtr InterfaceBuffer);

	/// <summary>
	/// The <c>TcEnumerateInterfaces</c> function enumerates all traffic control–enabled network interfaces. Clients are notified of
	/// interface changes through the ClNotifyHandler function.
	/// </summary>
	/// <param name="ClientHandle">Handle used by traffic control to identify the client. Clients receive handles when registering with traffic control through the
	/// TcRegisterClient function.</param>
	/// <returns>
	/// A sequence of <see cref="TC_IFC_DESCRIPTOR" /> structures with information about each interface.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each interface descriptor contains two elements:
	/// </para>
	/// <list type="bullet">
	///   <item>
	///     <term>The traffic control interface's identifying text string.</term>
	///   </item>
	///   <item>
	///     <term>The network address list descriptor currently associated with the interface.</term>
	///   </item>
	/// </list>
	/// <para>
	/// The network address list descriptor includes the media type, as well as a list of network addresses. The media type determines how
	/// the network address list should be interpreted:
	/// </para>
	/// <list type="bullet">
	///   <item>
	///     <term>
	/// For connectionless media such as a LAN, the network address list contains all the protocol-specific addresses associated with the interface.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	///       <para>For connection-oriented media such as a WAN, the network address list contains an even number of network addresses:</para>
	///       <list type="bullet">
	///         <item>
	///           <term>The first address in each pair represents the local (source) address of the interface.</term>
	///         </item>
	///         <item>
	///           <term>The second address in each pair represents the remote (destination) address of the interface.</term>
	///         </item>
	///       </list>
	///     </term>
	///   </item>
	/// </list>
	/// <para>
	///   <c>Note</c> Use of the <c>TcEnumerateInterfaces</c> function requires administrative privilege.</para>
	/// </remarks>
	public static IEnumerable<TC_IFC_DESCRIPTOR> TcEnumerateInterfaces([In] HCLIENT ClientHandle)
	{
		uint sz = 1024 * 2;
		SafeCoTaskMemHandle buf = new(sz);
		Win32Error err;
		do
		{
			buf.Size = sz;
			err = TcEnumerateInterfaces(ClientHandle, ref sz, buf);
		} while (err == Win32Error.ERROR_INSUFFICIENT_BUFFER);
		err.ThrowIfFailed();
		if (sz == 0)
			yield break;

		int offset = 0;
		TC_IFC_DESCRIPTOR d = GetDesc(offset);
		do
		{
			yield return d;
			d = GetDesc(offset += (int)d.Length);
		} while (d.Length > 0);

		TC_IFC_DESCRIPTOR GetDesc(int offset)
		{
			var desc = buf.ToStructure<TC_IFC_DESCRIPTOR>(offset);
			desc.AddressListDesc.AddressList = buf.ToStructure<NETWORK_ADDRESS_LIST>(offset + TC_IFC_DESCRIPTOR.NetAddrListOffset);
			return desc;
		}
	}

	/// <summary>
	/// The <c>TcGetFlowName</c> function provides the name of a flow that has been created by the calling client. Flow properties and other
	/// characteristics of flows are provided based on the name of a flow. Flow names can also be retrieved by a call to the TcEnumerateFlows function.
	/// </summary>
	/// <param name="FlowHandle">Handle for the flow.</param>
	/// <param name="StrSize">Size of the string buffer provided in <c>pFlowName</c>.</param>
	/// <param name="pFlowName">Pointer to the output buffer holding the flow name.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The flow handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer is too small to contain the results.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Use of the <c>TcGetFlowName</c> function requires administrative privilege.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The traffic.h header defines TcGetFlowName as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcgetflownamea ULONG TcGetFlowNameA( [in] HANDLE FlowHandle,
	// [in] ULONG StrSize, [out] LPSTR pFlowName );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcGetFlowNameA")]
	[DllImport(Lib_Traffic, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern Win32Error TcGetFlowName([In] HFLOW FlowHandle, uint StrSize, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder pFlowName);

	/// <summary>
	/// <para>
	/// The <c>TcModifyFlow</c> function modifies an existing flow. When calling <c>TcModifyFlow</c>, new <c>Flowspec</c> parameters and any
	/// traffic control objects should be filled.
	/// </para>
	/// <para>
	/// Traffic control clients that have registered a ModifyFlowComplete handler (a mechanism for allowing traffic control to call the
	/// ClModifyFlowComplete callback function in order to alert clients of completed flow modifications) can expect a return value of ERROR_SIGNAL_PENDING.
	/// </para>
	/// </summary>
	/// <param name="FlowHandle">Handle for the flow, as received from a previous call to the TcAddFlow function.</param>
	/// <param name="pGenericFlow">Pointer to a description of the flow modifications.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SIGNAL_PENDING</c></term>
	/// <term>
	/// The function is being executed asynchronously; the client will be called back through the client-exposed ClModifyFlowComplete
	/// function when the flow has been added, or when the process has been completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The interface handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_READY</c></term>
	/// <term>Action performed on the flow by a previous function call to the TcAddFlow, TcModifyFlow, or TcDeleteFlow has not yet completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SERVICE_TYPE</c></term>
	/// <term>An unspecified or bad intserv service type has been provided.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TOKEN_RATE</c></term>
	/// <term>An unspecified or bad <c>TokenRate</c> value has been provided.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PEAK_RATE</c></term>
	/// <term>The <c>PeakBandwidth</c> value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SD_MODE</c></term>
	/// <term>The <c>ShapeDiscardMode</c> is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_QOS_PRIORITY</c></term>
	/// <term>The priority value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TRAFFIC_CLASS</c></term>
	/// <term>The traffic class value is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SYSTEM_RESOURCES</c></term>
	/// <term>There are not enough resources to accommodate the requested flow.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TC_OBJECT_LENGTH_INVALID</c></term>
	/// <term>Bad length specified for the TC objects.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_DIFFSERV_FLOW</c></term>
	/// <term>Applies to Diffserv flows. Indicates that the QOS_DIFFSERV object was passed with an invalid parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DS_MAPPING_EXISTS</c></term>
	/// <term>
	/// Applies to Diffserv flows. Indicates that the QOS_DIFFSERV_RULE specified in TC_GEN_FLOW already applies to an existing flow on the interface.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SHAPE_RATE</c></term>
	/// <term>The QOS_SHAPING_RATE was passed with an invalid ShapeRate.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_DS_CLASS</c></term>
	/// <term>QOS_DS_CLASS is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NETWORK_UNREACHABLE</c></term>
	/// <term>The network cable is not plugged into the adapter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>TcModifyFlow</c> function returns ERROR_SIGNAL_PENDING, the ClModifyFlowComplete function will be called on a different
	/// thread than the thread that called the <c>TcModifyFlow</c> function.
	/// </para>
	/// <para><c>Note</c> Use of the <c>TcModifyFlow</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcmodifyflow ULONG TcModifyFlow( [in] HANDLE FlowHandle, [in]
	// PTC_GEN_FLOW pGenericFlow );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcModifyFlow")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcModifyFlow([In] HFLOW FlowHandle,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<TC_GEN_FLOW>))]
		TC_GEN_FLOW pGenericFlow);

	/// <summary>
	/// The <c>TcOpenInterface</c> function opens an interface. The <c>TcOpenInterface</c> function identifies and opens an interface based
	/// on its text string, which is available from a call to TcEnumerateInterfaces. Once an interface is opened, the client must be prepared
	/// to receive notification regarding the open interface, through traffic control's use of the interface context.
	/// </summary>
	/// <param name="pInterfaceName">
	/// Pointer to the text string identifying the interface to be opened. This text string is part of the information returned in a previous
	/// call to TcEnumerateInterfaces.
	/// </param>
	/// <param name="ClientHandle">
	/// Handle used by traffic control to identify the client, obtained through the <c>pClientHandle</c> parameter of the client's call to TcRegisterClient.
	/// </param>
	/// <param name="ClIfcCtx">
	/// Client's interface–context handle for the opened interface. Used as a callback parameter by traffic control when communicating with
	/// the client about the opened interface. This can be a container to hold an arbitrary client-defined context for this instance of the interface.
	/// </param>
	/// <param name="pIfcHandle">
	/// Pointer to the buffer where traffic control can return an interface handle. The interface handle returned to <c>pIfcHandle</c> must
	/// be used by the client to identify the interface in subsequent calls to traffic control.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters is <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>Traffic control failed to find an interface with the name provided in <c>pInterfaceName</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The client handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Use of the <c>TcOpenInterface</c> function requires administrative privilege.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The traffic.h header defines TcOpenInterface as an alias which automatically selects the ANSI or Unicode version of this function
	/// based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcopeninterfacew ULONG TcOpenInterfaceW( [in] LPWSTR
	// pInterfaceName, [in] HANDLE ClientHandle, [in] HANDLE ClIfcCtx, [out] PHANDLE pIfcHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcOpenInterfaceW")]
	[DllImport(Lib_Traffic, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern Win32Error TcOpenInterface([MarshalAs(UnmanagedType.LPTStr)] string pInterfaceName, [In] HCLIENT ClientHandle, [In] IntPtr ClIfcCtx, out SafeHIFC pIfcHandle);

	/// <summary>
	/// The <c>TcQueryFlow</c> function queries traffic control for the value of a specific flow parameter based on the name of the flow. The
	/// name of a flow can be retrieved from the TcEnumerateFlows function or from the TcGetFlowName function.
	/// </summary>
	/// <param name="pFlowName">Name of the flow being queried.</param>
	/// <param name="pGuidParam">
	/// Pointer to the globally unique identifier (GUID) that corresponds to the flow parameter of interest. A list of traffic control's
	/// GUIDs can be found in GUID.
	/// </param>
	/// <param name="pBufferSize">
	/// Pointer to the size of the client-provided buffer or the number of bytes used by traffic control. For input, points to the size of
	/// <c>Buffer</c>, in bytes. For output, points to the actual amount of buffer space written with returned flow-parameter data, in bytes.
	/// </param>
	/// <param name="Buffer">Pointer to the client-provided buffer in which the returned flow parameter is written.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The provided buffer is too small to hold the results.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>The requested GUID is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_GUID_NOT_FOUND</c></term>
	/// <term>The device did not register for this GUID.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_INSTANCE_NOT_FOUND</c></term>
	/// <term>The instance name was not found, likely because the flow or the interface is in the process of being closed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Use of the <c>TcQueryFlow</c> function requires administrative privilege.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The traffic.h header defines TcQueryFlow as an alias which automatically selects the ANSI or Unicode version of this function based
	/// on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcqueryflowa ULONG TcQueryFlowA( [in] LPSTR pFlowName, [in]
	// LPGUID pGuidParam, [in, out] PULONG pBufferSize, [out] PVOID Buffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcQueryFlowA")]
	[DllImport(Lib_Traffic, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern Win32Error TcQueryFlow([MarshalAs(UnmanagedType.LPTStr)] string pFlowName, in Guid pGuidParam, ref uint pBufferSize, [Out] IntPtr Buffer);

	/// <summary>
	/// The <c>TcQueryInterface</c> function queries traffic control for related per-interface parameters. A traffic control parameter is
	/// queried by providing its globally unique identifier (GUID). Setting the <c>NotifyChange</c> parameter to <c>TRUE</c> enables event
	/// notification on the specified GUID, after which notification events are sent to a client whenever the queried parameter changes.
	/// GUIDs for which clients can request notification are found in the GUID entry; the column titled "Notification" denotes which GUIDs
	/// are available for notification.
	/// </summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface to be queried. This handle is obtained by a previous call to the TcOpenInterface function.
	/// </param>
	/// <param name="pGuidParam">
	/// Pointer to the globally unique identifier (GUID) that corresponds to the traffic control parameter being queried.
	/// </param>
	/// <param name="NotifyChange">
	/// Used to request notifications from traffic control for the parameter being queried. If <c>TRUE</c>, traffic control will notify the
	/// client, through the ClNotifyHandler function, upon changes to the parameter corresponding to the GUID provided in <c>pGuidParam</c>.
	/// Notifications are off by default.
	/// </param>
	/// <param name="pBufferSize">
	/// Indicates the size of the buffer, in bytes. For input, this value is the size of the buffer allocated by the caller. For output, this
	/// value is the actual size of the buffer, in bytes, used by traffic control.
	/// </param>
	/// <param name="Buffer">Pointer to a client-allocated buffer into which returned data will be written.</param>
	/// <returns>
	/// <para>
	/// Note that, with regard to a requested notification state, only a return value of NO_ERROR will result in the application of the
	/// requested notification state. If a return value other than NO_ERROR is returned from a call to the <c>TcQueryInterface</c> function,
	/// the requested change in notification state will not be accepted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>Invalid interface handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>Invalid or <c>NULL</c> parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer is too small to store the results.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>Querying for the GUID provided is not supported on the provided interface.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_GUID_NOT_FOUND</c></term>
	/// <term>The device did not register for this GUID.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_INSTANCE_NOT_FOUND</c></term>
	/// <term>The instance name was not found, likely because the interface is in the process of being closed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks><c>Note</c> Use of the <c>TcQueryInterface</c> function requires administrative privilege.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcqueryinterface ULONG TcQueryInterface( [in] HANDLE IfcHandle,
	// [in] LPGUID pGuidParam, [in] BOOLEAN NotifyChange, [in, out] PULONG pBufferSize, [out] PVOID Buffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcQueryInterface")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcQueryInterface([In] HIFC IfcHandle, in Guid pGuidParam, [MarshalAs(UnmanagedType.U1)] bool NotifyChange, ref uint pBufferSize, [Out] IntPtr Buffer);

	/// <summary>
	/// <para>
	/// The <c>TcRegisterClient</c> function is used to register a client with the traffic control interface (TCI). The
	/// <c>TcRegisterClient</c> function must be the first function call a client makes to the TCI.
	/// </para>
	/// <para>
	/// Client registration provides callback routines that allow the TCI to complete either client-initiated operations or asynchronous
	/// events. Upon successful registration, the caller of the <c>TcRegisterClient</c> function must be ready to have any of its TCI
	/// handlers called. See Entry Points Exposed by Clients of the Traffic Control Interface for more information.
	/// </para>
	/// </summary>
	/// <param name="TciVersion">
	/// Traffic control version expected by the client, included to ensure compatibility between traffic control and the client. Clients can
	/// pass CURRENT_TCI_VERSION, defined in Traffic.h.
	/// </param>
	/// <param name="ClRegCtx">
	/// Client registration context. <c>ClRegCtx</c> is returned when the client's notification handler function is called. This can be a
	/// container to hold an arbitrary client-defined context for this instance of the interface.
	/// </param>
	/// <param name="ClientHandlerList">
	/// Pointer to a list of client-supplied handlers. Client-supplied handlers are used for notification events and asynchronous
	/// completions. Each completion routine is optional, with the exception of the notification handler. Setting the notification handler to
	/// <c>NULL</c> will return an ERROR_INVALID_PARAMETER.
	/// </param>
	/// <param name="pClientHandle">Pointer to the buffer that traffic control uses to return a registration handle to the client.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters is <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INCOMPATIBLE_TCI_VERSION</c></term>
	/// <term>The TCI version is wrong.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_OPEN_FAILED</c></term>
	/// <term>Traffic control failed to open a system device. The likely cause is insufficient privileges.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_TOO_MANY_CLIENTS</c></term>
	/// <term>
	/// Traffic Control was unable to register with the kernel component GPC. The likely cause is too many traffic control clients are
	/// currently connected. <c>Windows 2000:</c> This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Some of the return codes can be found in tcerror.h.</para>
	/// <para><c>Note</c> Use of the <c>TcRegisterClient</c> function requires administrative privilege.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcregisterclient ULONG TcRegisterClient( [in] ULONG TciVersion,
	// [in] HANDLE ClRegCtx, [in] PTCI_CLIENT_FUNC_LIST ClientHandlerList, [out] PHANDLE pClientHandle );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcRegisterClient")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcRegisterClient(uint TciVersion, [In] IntPtr ClRegCtx,
		in TCI_CLIENT_FUNC_LIST ClientHandlerList, out SafeHCLIENT pClientHandle);

	/// <summary>The <c>TcSetFlow</c> function sets individual parameters for a given flow.</summary>
	/// <param name="pFlowName">
	/// Name of the flow being set. The value for this parameter is obtained by a previous call to the TcEnumerateFlows function or the
	/// TcGetFlowName function.
	/// </param>
	/// <param name="pGuidParam">
	/// Pointer to the globally unique identifier (GUID) that corresponds to the parameter to be set. A list of available GUIDs can be found
	/// in GUID.
	/// </param>
	/// <param name="BufferSize">Size of the client-provided buffer, in bytes.</param>
	/// <param name="Buffer">
	/// Pointer to a client-provided buffer. Buffer must contain the value to which the traffic control parameter provided in
	/// <c>pGuidParam</c> should be set.
	/// </param>
	/// <returns>
	/// <para>The <c>TcSetFlow</c> function has the following return values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_READY</c></term>
	/// <term>The flow is currently being modified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>The buffer size was insufficient for the GUID.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>Invalid parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>Setting the GUID for the provided flow is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_INSTANCE_NOT_FOUND</c></term>
	/// <term>The instance name was not found, likely due to the flow or the interface being in the process of being closed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_GUID_NOT_FOUND</c></term>
	/// <term>The device did not register for this GUID.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Use of the <c>TcSetFlow</c> function requires administrative privilege.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The traffic.h header defines TcSetFlow as an alias which automatically selects the ANSI or Unicode version of this function based on
	/// the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not encoding-neutral
	/// can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcsetflowa ULONG TcSetFlowA( [in] LPSTR pFlowName, [in] LPGUID
	// pGuidParam, [in] ULONG BufferSize, [in] PVOID Buffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcSetFlowA")]
	[DllImport(Lib_Traffic, SetLastError = false, CharSet = CharSet.Auto)]
	public static extern Win32Error TcSetFlow([MarshalAs(UnmanagedType.LPTStr)] string pFlowName, in Guid pGuidParam, uint BufferSize, [In] IntPtr Buffer);

	/// <summary>The <c>TcSetInterface</c> function sets individual parameters for a given interface.</summary>
	/// <param name="IfcHandle">
	/// Handle associated with the interface to be set. This handle is obtained by a previous call to the TcOpenInterface function.
	/// </param>
	/// <param name="pGuidParam">
	/// Pointer to the globally unique identifier (GUID) that corresponds to the parameter to be set. A list of available GUIDs can be found
	/// in GUID.
	/// </param>
	/// <param name="BufferSize">Size of the client-provided buffer, in bytes.</param>
	/// <param name="Buffer">
	/// Pointer to a client-provided buffer. <c>Buffer</c> must contain the value to which the traffic control parameter provided in
	/// <c>pGuidParam</c> should be set.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>The function executed without errors.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>Invalid interface handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>Invalid parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>Setting the GUID for the provided interface is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_INSTANCE_NOT_FOUND</c></term>
	/// <term>The GUID is not available.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WMI_GUID_NOT_FOUND</c></term>
	/// <term>The device did not register for this GUID.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> Use of the <c>TcSetInterface</c> function requires administrative privilege. The list of GUIDs that can be set is
	/// explained in GUID.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/nf-traffic-tcsetinterface ULONG TcSetInterface( [in] HANDLE IfcHandle,
	// [in] LPGUID pGuidParam, [in] ULONG BufferSize, [in] PVOID Buffer );
	[PInvokeData("traffic.h", MSDNShortId = "NF:traffic.TcSetInterface")]
	[DllImport(Lib_Traffic, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error TcSetInterface([In] HIFC IfcHandle, in Guid pGuidParam, uint BufferSize, [In] IntPtr Buffer);

	/// <summary>
	/// The <c>ADDRESS_LIST_DESCRIPTOR</c> structure provides network address descriptor information for a given interface. For
	/// point-to-point media such as WAN connections, the list is a pair of addresses, the first of which is always the local or source
	/// address, the second of which is the remote or destination address. Note that the members of <c>ADDRESS_LIST_DESCRIPTOR</c> are
	/// defined in Ntddndis.h.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-address_list_descriptor typedef struct _ADDRESS_LIST_DESCRIPTOR
	// { ULONG MediaType; NETWORK_ADDRESS_LIST AddressList; } ADDRESS_LIST_DESCRIPTOR, *PADDRESS_LIST_DESCRIPTOR;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._ADDRESS_LIST_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ADDRESS_LIST_DESCRIPTOR
	{
		/// <summary>Media type of the interface.</summary>
		public uint MediaType;

		/// <summary>Pointer to the address list for the interface. The <c>NETWORK_ADDRESS_LIST</c> structure is defined in Ntddndis.h.</summary>
		//[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<SafeAnysizeStructMarshaler<NETWORK_ADDRESS_LIST>>), MarshalCookie = "AddressCount")]
		public NETWORK_ADDRESS_LIST AddressList;
	}

	/// <summary>
	/// The <c>ENUMERATION_BUFFER</c> structure contains information specific to a given flow, including flow name, the number of filters
	/// associated with the flow, and an array of filters associated with the flow.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-enumeration_buffer typedef struct _ENUMERATION_BUFFER { ULONG
	// Length; ULONG OwnerProcessId; USHORT FlowNameLength; WCHAR FlowName[MAX_STRING_LENGTH]; PTC_GEN_FLOW pFlow; ULONG NumberOfFilters;
	// TC_GEN_FILTER GenericFilter[1]; } ENUMERATION_BUFFER, *PENUMERATION_BUFFER;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._ENUMERATION_BUFFER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ENUMERATION_BUFFER
	{
		/// <summary>Number of bytes from the beginning of the <c>ENUMERATION_BUFFER</c> to the next <c>ENUMERATION_BUFFER</c>.</summary>
		public uint Length;

		/// <summary>Identifies the owner of the process.</summary>
		public uint OwnerProcessId;

		/// <summary>Specifies the length of the <c>FlowName</c> member.</summary>
		public ushort FlowNameLength;

		/// <summary>Array of WCHAR characters, of length <c>MAX_STRING_LENGTH</c>, that specifies the flow name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_STRING_LENGTH)]
		public string FlowName;

		/// <summary>
		/// Pointer to the corresponding <see cref="TC_GEN_FLOW"/> structure. This structure is placed immediately after the array of
		/// TC_GEN_FILTERS and is included in <c>Length</c>.
		/// </summary>
		public IntPtr pFlow;

		/// <summary>The corresponding <see cref="TC_GEN_FLOW"/> structure.</summary>
		public TC_GEN_FLOW Flow => pFlow.ToStructure<TC_GEN_FLOW>();

		/// <summary>Specifies the number of filters associated with the flow.</summary>
		public uint NumberOfFilters;

		/// <summary>
		/// <para>
		/// Array of TC_GEN_FILTER structures. The number of elements in the array corresponds to the number of filters attached to the
		/// specified flow. Note that in order to enumerate through the array of <c>TC_GEN_FILTER</c> structures, you need to increment the
		/// pointer to the current <c>TC_GEN_FILTER</c> by using the following:
		/// </para>
		/// <para><c>sizeof(TC_GEN_FILTER) + 2 * [the pattern size of the current TC_GEN_FILTER structure].</c></para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public TC_GEN_FILTER[] GenericFilter;
	}

	/// <summary>
	/// The <c>ENUMERATION_BUFFER</c> structure contains information specific to a given flow, including flow name, the number of filters
	/// associated with the flow, and an array of filters associated with the flow.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-enumeration_buffer typedef struct _ENUMERATION_BUFFER { ULONG
	// Length; ULONG OwnerProcessId; USHORT FlowNameLength; WCHAR FlowName[MAX_STRING_LENGTH]; PTC_GEN_FLOW pFlow; ULONG NumberOfFilters;
	// TC_GEN_FILTER GenericFilter[1]; } ENUMERATION_BUFFER, *PENUMERATION_BUFFER;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._ENUMERATION_BUFFER")]
	public class ENUMERATION_BUFFER_MGD
	{
		private ENUMERATION_BUFFER_MGD() { }

		internal ENUMERATION_BUFFER_MGD(IntPtr ptr)
		{
			var buf = ptr.ToStructure<ENUMERATION_BUFFER>();
			OwnerProcessId = buf.OwnerProcessId;
			FlowName = buf.FlowName;
			Flow = buf.Flow;

			List<TC_GEN_FILTER_MGD_BASE> filters = new((int)buf.NumberOfFilters);
			var fptr = ptr.Offset(Marshal.OffsetOf(typeof(ENUMERATION_BUFFER), "GenericFilter").ToInt64());
			for (int i = 0; i < buf.NumberOfFilters; i++)
			{
				TC_GEN_FILTER f = fptr.ToStructure<TC_GEN_FILTER>();
				filters.Add(f.AddressType switch
				{
					NDIS_PROTOCOL_ID.NDIS_PROTOCOL_ID_TCP_IP => new TC_GEN_FILTER_MGD<IP_PATTERN>(f),
					NDIS_PROTOCOL_ID.NDIS_PROTOCOL_ID_IPX => new TC_GEN_FILTER_MGD<IPX_PATTERN>(f),
					_ => new TC_GEN_FILTER_MGD_UNK(f),
				});
				fptr = fptr.Offset(Marshal.SizeOf(typeof(TC_GEN_FILTER)) + f.PatternSize * 2);
			}
			GenericFilter = filters;
		}

		/// <summary>Identifies the owner of the process.</summary>
		public uint OwnerProcessId { get; }

		/// <summary>Specifies the flow name.</summary>
		public string FlowName { get; }

		/// <summary>The corresponding <see cref="TC_GEN_FLOW"/> structure.</summary>
		public TC_GEN_FLOW Flow { get; }

		/// <summary>
		/// List of TC_GEN_FILTER structures. The number of elements in the array corresponds to the number of filters attached to the
		/// specified flow.
		/// </summary>
		public IReadOnlyList<TC_GEN_FILTER_MGD_BASE> GenericFilter { get; }
	}

	/// <summary>Provides a handle to a traffic control client.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HCLIENT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCLIENT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCLIENT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCLIENT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCLIENT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HCLIENT h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HCLIENT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCLIENT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCLIENT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCLIENT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCLIENT h1, HCLIENT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCLIENT h1, HCLIENT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HCLIENT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a traffic filter.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFILTER : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFILTER"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFILTER(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFILTER"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFILTER NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFILTER h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFILTER"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFILTER h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFILTER"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFILTER(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFILTER h1, HFILTER h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFILTER h1, HFILTER h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFILTER h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a traffic flow.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFLOW : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFLOW"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFLOW(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFLOW"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFLOW NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFLOW h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFLOW"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFLOW h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFLOW"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFLOW(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFLOW h1, HFLOW h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFLOW h1, HFLOW h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFLOW h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a flow enumeration.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HFLOWENUM : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HFLOWENUM"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HFLOWENUM(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HFLOWENUM"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HFLOWENUM NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HFLOWENUM h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HFLOWENUM"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HFLOWENUM h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HFLOWENUM"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFLOWENUM(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HFLOWENUM h1, HFLOWENUM h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HFLOWENUM h1, HFLOWENUM h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HFLOWENUM h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a traffic interface.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HIFC : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HIFC"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HIFC(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HIFC"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HIFC NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HIFC h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HIFC"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HIFC h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HIFC"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HIFC(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HIFC h1, HIFC h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HIFC h1, HIFC h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HIFC h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// The <c>IP_PATTERN</c> structure applies a specific pattern or corresponding mask for the IP protocol. The <c>IP_PATTERN</c> structure
	/// designation is used by the traffic control interface in the application of packet filters.
	/// </summary>
	/// <remarks>The following macros are defined in Traffic.h to make it easier to reference the members of the union:</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-ip_pattern typedef struct _IP_PATTERN { ULONG Reserved1; ULONG
	// Reserved2; ULONG SrcAddr; ULONG DstAddr; union { struct { USHORT s_srcport; USHORT s_dstport; } S_un_ports; struct { UCHAR s_type;
	// UCHAR s_code; USHORT filler; } S_un_icmp; ULONG S_Spi; } S_un; UCHAR ProtocolId; UCHAR Reserved3[3]; } IP_PATTERN, *PIP_PATTERN;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._IP_PATTERN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IP_PATTERN
	{
		/// <summary>Reserved for future use.</summary>
		public uint Reserved1;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved2;

		/// <summary>Source address.</summary>
		public uint SrcAddr;

		/// <summary>Destination address.</summary>
		public uint DstAddr;

		/// <summary/>
		public UNION S_un;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary>Service provider interface.</summary>
			[FieldOffset(0)]
			public uint S_Spi;

			/// <summary>Source port and destination port.</summary>
			[FieldOffset(0)]
			public PORTS S_un_ports;

			/// <summary>ICMP message type and ICMP message code.</summary>
			[FieldOffset(0)]
			public ICMP S_un_icmp;

			/// <summary>Source port and destination port.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PORTS
			{
				/// <summary>The source port.</summary>
				public ushort s_srcport;

				/// <summary>The destination port.</summary>
				public ushort s_dstport;
			}

			/// <summary>ICMP message type and ICMP message code.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ICMP
			{
				/// <summary>The ICMP message type.</summary>
				public byte s_type;

				/// <summary>The ICMP message code.</summary>
				public byte s_code;

				/// <summary/>
				public ushort filler;
			}
		}

		/// <summary>Protocol identifier.</summary>
		private byte ProtocolId;

		/// <summary>Reserved for future use.</summary>
		public byte Reserved3_1, Reserved3_2, Reserved3_3;
	}

	/// <summary>
	/// The <c>IPX_PATTERN</c> structure applies a specific pattern or corresponding mask for the IPX protocol. The <c>IPX_PATTERN</c>
	/// structure designation is used by the traffic control interface in the application of packet filters.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-ipx_pattern typedef struct _IPX_PATTERN { struct { ULONG
	// NetworkAddress; UCHAR NodeAddress[6]; USHORT Socket; } Src; __unnamed_struct_141c_4 Dest; } IPX_PATTERN, *PIPX_PATTERN;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._IPX_PATTERN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IPX_PATTERN
	{
		/// <summary/>
		public IPX Src;

		/// <summary/>
		public IPX Dest;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct IPX
		{
			/// <summary/>
			public uint NetworkAddress;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public byte[] NodeAddress;

			/// <summary/>
			public ushort Socket;
		}
	}

	/// <summary>
	/// The <c>TC_GEN_FILTER</c> structure creates a filter that matches a certain set of packet attributes or criteria, which can
	/// subsequently be used to associate packets that meet the attribute criteria with a particular flow. The <c>TC_GEN_FILTER</c> structure
	/// uses its <c>AddressType</c> member to indicate a specific filter type to apply to the filter.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-tc_gen_filter typedef struct _TC_GEN_FILTER { USHORT
	// AddressType; ULONG PatternSize; PVOID Pattern; PVOID Mask; } TC_GEN_FILTER, *PTC_GEN_FILTER;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_GEN_FILTER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TC_GEN_FILTER
	{
		/// <summary>
		/// Defines the filter type to be applied with the filter, as defined in Ntddndis.h. With the designation of a specific filter in
		/// <c>AddressType</c>, the generic filter structure <c>TC_GEN_FILTER</c> provides a specific filter type.
		/// </summary>
		public NDIS_PROTOCOL_ID AddressType;

		/// <summary>Size of the <c>Pattern</c> member, in bytes.</summary>
		public uint PatternSize;

		/// <summary>
		/// Indicates the specific format of the pattern to be applied to the filter, such as IP_PATTERN. The pattern specifies which bits of
		/// a given packet should be evaluated when determining whether a packet is included in the filter.
		/// </summary>
		public IntPtr Pattern;

		/// <summary>
		/// A bitmask applied to the bits designated in the <c>Pattern</c> member. The application of the <c>Mask</c> member to the
		/// <c>Pattern</c> member determines which bits in the <c>Pattern</c> member are significant (should be applied to the filter
		/// criteria). Note that the <c>Mask</c> member must be of the same type as the <c>Pattern</c> member.
		/// </summary>
		public IntPtr Mask;
	}

	/// <summary>
	/// The <c>TC_GEN_FILTER</c> structure creates a filter that matches a certain set of packet attributes or criteria, which can
	/// subsequently be used to associate packets that meet the attribute criteria with a particular flow. The <c>TC_GEN_FILTER</c> structure
	/// uses its <c>AddressType</c> member to indicate a specific filter type to apply to the filter.
	/// </summary>
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_GEN_FILTER")]
	public class TC_GEN_FILTER_MGD_BASE
	{
		/// <summary>
		/// Defines the filter type to be applied with the filter, as defined in Ntddndis.h. With the designation of a specific filter in
		/// <c>AddressType</c>, the generic filter structure <c>TC_GEN_FILTER</c> provides a specific filter type.
		/// </summary>
		public NDIS_PROTOCOL_ID AddressType;
	}

	/// <summary>
	/// The <c>TC_GEN_FILTER</c> structure creates a filter that matches a certain set of packet attributes or criteria, which can
	/// subsequently be used to associate packets that meet the attribute criteria with a particular flow. The <c>TC_GEN_FILTER</c> structure
	/// uses its <c>AddressType</c> member to indicate a specific filter type to apply to the filter.
	/// </summary>
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_GEN_FILTER")]
	public class TC_GEN_FILTER_MGD_UNK : TC_GEN_FILTER_MGD_BASE
	{
		/// <summary>
		/// Indicates the specific format of the pattern to be applied to the filter, such as IP_PATTERN. The pattern specifies which bits of
		/// a given packet should be evaluated when determining whether a packet is included in the filter.
		/// </summary>
		public byte[] Pattern;

		/// <summary>
		/// A bitmask applied to the bits designated in the <c>Pattern</c> member. The application of the <c>Mask</c> member to the
		/// <c>Pattern</c> member determines which bits in the <c>Pattern</c> member are significant (should be applied to the filter
		/// criteria). Note that the <c>Mask</c> member must be of the same type as the <c>Pattern</c> member.
		/// </summary>
		public byte[] Mask;

		internal TC_GEN_FILTER_MGD_UNK(in TC_GEN_FILTER f)
		{
			AddressType = f.AddressType;
			Pattern = f.Pattern.ToArray<byte>((int)f.PatternSize);
			Mask = f.Mask.ToArray<byte>((int)f.PatternSize);
		}
	}

	/// <summary>
	/// The <c>TC_GEN_FILTER</c> structure creates a filter that matches a certain set of packet attributes or criteria, which can
	/// subsequently be used to associate packets that meet the attribute criteria with a particular flow. The <c>TC_GEN_FILTER</c> structure
	/// uses its <c>AddressType</c> member to indicate a specific filter type to apply to the filter.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-tc_gen_filter typedef struct _TC_GEN_FILTER { USHORT
	// AddressType; ULONG PatternSize; PVOID Pattern; PVOID Mask; } TC_GEN_FILTER, *PTC_GEN_FILTER;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_GEN_FILTER")]
	public class TC_GEN_FILTER_MGD<T> : TC_GEN_FILTER_MGD_BASE where T : struct
	{
		/// <summary>
		/// Indicates the specific format of the pattern to be applied to the filter, such as IP_PATTERN. The pattern specifies which bits of
		/// a given packet should be evaluated when determining whether a packet is included in the filter.
		/// </summary>
		public T Pattern;

		/// <summary>
		/// A bitmask applied to the bits designated in the <c>Pattern</c> member. The application of the <c>Mask</c> member to the
		/// <c>Pattern</c> member determines which bits in the <c>Pattern</c> member are significant (should be applied to the filter
		/// criteria). Note that the <c>Mask</c> member must be of the same type as the <c>Pattern</c> member.
		/// </summary>
		public T Mask;

		internal TC_GEN_FILTER_MGD(in TC_GEN_FILTER f)
		{
			AddressType = f.AddressType;
			Pattern = f.Pattern.ToStructure<T>();
			Mask = f.Mask.ToStructure<T>();
		}
	}

	/// <summary>
	/// The <c>TC_GEN_FLOW</c> structure creates a generic flow for use with the traffic control interface. The flow is customized through
	/// the members of this structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-tc_gen_flow typedef struct _TC_GEN_FLOW { FLOWSPEC
	// SendingFlowspec; FLOWSPEC ReceivingFlowspec; ULONG TcObjectsLength; QOS_OBJECT_HDR TcObjects[1]; } TC_GEN_FLOW, *PTC_GEN_FLOW;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_GEN_FLOW")]
	public class TC_GEN_FLOW : IVanaraMarshaler
	{
		/// <summary>FLOWSPEC structure for the sending direction of the flow.</summary>
		public FLOWSPEC SendingFlowspec;

		/// <summary>FLOWSPEC structure for the receiving direction of the flow.</summary>
		public FLOWSPEC ReceivingFlowspec;

		/// <summary>
		/// <para>
		/// Buffer that contains an array of traffic control objects specific to the given flow. The <c>TcObjects</c> member can contain
		/// objects from the list of currently supported objects. Definitions of these objects can be found in Qos.h and Traffic.h:
		/// </para>
		/// <para>QOS_DS_CLASS</para>
		/// <para>QOS_TRAFFIC_CLASS</para>
		/// <para>QOS_DIFFSERV</para>
		/// <para>QOS_SD_MODE</para>
		/// <para>QOS_SHAPING_RATE</para>
		/// <para>QOS_OBJECT_END_OF_LIST</para>
		/// </summary>
		public IQoSObjectHdr[] TcObjects;

		SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(INT_TC_GEN_FLOW));

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object managedObject)
		{
			if (managedObject is not TC_GEN_FLOW f)
				throw new ArgumentException("Only objects of type TC_GEN_FLOW can be marshaled.");
			int objLen = f.TcObjects?.Length ?? 0;
			SafeCoTaskMemStruct<INT_TC_GEN_FLOW> pFlow = new(new INT_TC_GEN_FLOW() { SendingFlowspec = f.SendingFlowspec, ReceivingFlowspec = f.ReceivingFlowspec, TcObjectsLength = objLen });
			pFlow.Size += f.TcObjects?.Sum(o => Marshal.SizeOf(o.GetType())) ?? 0;
			if (objLen > 0)
			{
				var oPtr = pFlow.GetFieldAddress(nameof(TcObjects));
				for (int i = 0; i < objLen; i++)
				{
					oPtr.Write(f.TcObjects[i]);
					oPtr = oPtr.Offset(Marshal.SizeOf(f.TcObjects[i].GetType()));
				}
			}
			return pFlow;
		}

		object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			var f = pNativeData.ToStructure<INT_TC_GEN_FLOW>(allocatedBytes);
			TC_GEN_FLOW ret = new() { SendingFlowspec = f.SendingFlowspec, ReceivingFlowspec = f.ReceivingFlowspec, TcObjects = new IQoSObjectHdr[f.TcObjectsLength] };
			var ptr = pNativeData.Offset(Marshal.OffsetOf(typeof(INT_TC_GEN_FLOW), nameof(TcObjects)).ToInt64());
			for (int i = 0; i < f.TcObjectsLength; i++)
			{
				var e = ptr.Convert<QOS_OBJ_TYPE>(4);
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(e).First();
				ret.TcObjects[i] = (IQoSObjectHdr)Marshal.PtrToStructure(ptr, t);
			}
			return ret;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct INT_TC_GEN_FLOW
		{
			public FLOWSPEC SendingFlowspec;

			public FLOWSPEC ReceivingFlowspec;

			public int TcObjectsLength;

			public QOS_OBJECT_HDR TcObjects;
		}
	}

	/// <summary>The <c>TC_IFC_DESCRIPTOR</c> structure is an interface identifier used to enumerate interfaces.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-tc_ifc_descriptor typedef struct _TC_IFC_DESCRIPTOR { ULONG
	// Length; LPWSTR pInterfaceName; LPWSTR pInterfaceID; ADDRESS_LIST_DESCRIPTOR AddressListDesc; } TC_IFC_DESCRIPTOR, *PTC_IFC_DESCRIPTOR;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TC_IFC_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TC_IFC_DESCRIPTOR
	{
		/// <summary>Number of bytes from the beginning of the <c>TC_IFC_DESCRIPTOR</c> to the next <c>TC_IFC_DESCRIPTOR</c>.</summary>
		public uint Length;

		/// <summary>
		/// Pointer to a zero-terminated Unicode string representing the name of the packet shaper interface. This name is used in subsequent
		/// TC API calls to reference the interface.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pInterfaceName;

		/// <summary>Pointer to a zero-terminated Unicode string naming the DeviceName of the interface.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pInterfaceID;

		/// <summary>Network address list descriptor.</summary>
		public ADDRESS_LIST_DESCRIPTOR AddressListDesc;

		internal static readonly int NetAddrListOffset = Marshal.OffsetOf(typeof(TC_IFC_DESCRIPTOR), "AddressListDesc").ToInt32() + Marshal.OffsetOf(typeof(ADDRESS_LIST_DESCRIPTOR), "AddressList").ToInt32();
	}

	/// <summary>
	/// The <c>TCI_CLIENT_FUNC_LIST</c> structure is used by the traffic control interface to register and then access client-callback
	/// functions. Each member of <c>TCI_CLIENT_FUNC_LIST</c> is a pointer to the client provided–callback function.
	/// </summary>
	/// <remarks>Any member of the <c>TCI_CLIENT_FUNC_LIST</c> structure can be <c>NULL</c> except <c>ClNotifyHandler</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/traffic/ns-traffic-tci_client_func_list typedef struct _TCI_CLIENT_FUNC_LIST {
	// TCI_NOTIFY_HANDLER ClNotifyHandler; TCI_ADD_FLOW_COMPLETE_HANDLER ClAddFlowCompleteHandler; TCI_MOD_FLOW_COMPLETE_HANDLER
	// ClModifyFlowCompleteHandler; TCI_DEL_FLOW_COMPLETE_HANDLER ClDeleteFlowCompleteHandler; } TCI_CLIENT_FUNC_LIST, *PTCI_CLIENT_FUNC_LIST;
	[PInvokeData("traffic.h", MSDNShortId = "NS:traffic._TCI_CLIENT_FUNC_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TCI_CLIENT_FUNC_LIST
	{
		/// <summary>Pointer to the client-callback function ClNotifyHandler.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public TCI_NOTIFY_HANDLER ClNotifyHandler;

		/// <summary>Pointer to the client-callback function ClAddFlowComplete.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public TCI_ADD_FLOW_COMPLETE_HANDLER ClAddFlowCompleteHandler;

		/// <summary>Pointer to the client-callback function ClModifyFlowComplete.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public TCI_MOD_FLOW_COMPLETE_HANDLER ClModifyFlowCompleteHandler;

		/// <summary>Pointer to the client-callback function ClDeleteFlowComplete.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public TCI_DEL_FLOW_COMPLETE_HANDLER ClDeleteFlowCompleteHandler;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCLIENT"/> that is disposed using <see cref="TcDeregisterClient"/>.</summary>
	public class SafeHCLIENT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHCLIENT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHCLIENT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHCLIENT"/> class.</summary>
		private SafeHCLIENT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHCLIENT"/> to <see cref="HCLIENT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCLIENT(SafeHCLIENT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => TcDeregisterClient(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HFILTER"/> that is disposed using <see cref="TcDeleteFilter"/>.</summary>
	public class SafeHFILTER : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHFILTER"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHFILTER(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHFILTER"/> class.</summary>
		private SafeHFILTER() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHFILTER"/> to <see cref="HFILTER"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFILTER(SafeHFILTER h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => TcDeleteFilter(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HFLOW"/> that is disposed using <see cref="TcDeleteFlow"/>.</summary>
	public class SafeHFLOW : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHFLOW"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHFLOW(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHFLOW"/> class.</summary>
		private SafeHFLOW() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHFLOW"/> to <see cref="HFLOW"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HFLOW(SafeHFLOW h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => TcDeleteFlow(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HIFC"/> that is disposed using <see cref="TcCloseInterface"/>.</summary>
	public class SafeHIFC : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHIFC"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHIFC(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHIFC"/> class.</summary>
		private SafeHIFC() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHIFC"/> to <see cref="HIFC"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HIFC(SafeHIFC h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => TcCloseInterface(handle).Succeeded;
	}
}