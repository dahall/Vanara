using static Vanara.PInvoke.Rpc;

namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>The <c>FwpmCalloutAdd0</c> function adds a new callout object to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="callout">
	/// <para>Type: FWPM_CALLOUT0*</para>
	/// <para>The callout object to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>The security information associated with the callout.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>Runtime identifier for this callout.</para>
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
	/// <term>The callout was successfully added.</term>
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
	/// <para>
	/// Some fields in the FWPM_CALLOUT0 structure are assigned by the system, not the caller, and are ignored in the call to
	/// <c>FwpmCalloutAdd0</c>. If the caller supplies a null security descriptor, the system will assign a default security descriptor.
	/// </para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ADD access to the callout's container, <c>FWPM_ACTRL_ADD_LINK</c> access to the provider (if any), and
	/// <c>FWPM_ACTRL_ADD_LINK</c> access to the applicable layer. See Access Control for more information.
	/// </para>
	/// <para>To add a filter that references a callout, invoke the functions in the following order.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Call FwpsCalloutRegister (documented in the Windows Driver Kit (WDK)), to register the callout with the filter engine.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>FwpmCalloutAdd0</c> to add the callout to the system.</term>
	/// </item>
	/// <item>
	/// <term>Call FwpmFilterAdd0 to add the filter that references the callout to the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// By default filters that reference callouts that have been added but have not yet registered with the filter engine are treated as
	/// Block filters.
	/// </para>
	/// <para>
	/// <c>FwpmCalloutAdd0</c> is a specific implementation of FwpmCalloutAdd. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutadd0 DWORD FwpmCalloutAdd0( [in] HFWPENG engineHandle,
	// [in] const FWPM_CALLOUT0 *callout, [in, optional] PSECURITY_DESCRIPTOR sd, [out, optional] UINT32 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutAdd0")]
	public static extern Win32Error FwpmCalloutAdd0([In] HFWPENG engineHandle, in FWPM_CALLOUT0 callout, [In, Optional] PSECURITY_DESCRIPTOR sd,
		out uint id);

	/// <summary>The <c>FwpmCalloutCreateEnumHandle0</c> function creates a handle used to enumerate a set of callout objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CALLOUT_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle of the newly created enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all callout objects are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmCalloutCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmCalloutCreateEnumHandle0</c> and FwpmCalloutEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must call FwpmCalloutDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the callouts' containers and <c>FWPM_ACTRL_READ</c> access to the callouts. Only callouts
	/// to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmCalloutCreateEnumHandle0</c> is a specific implementation of FwpmCalloutCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutcreateenumhandle0 DWORD FwpmCalloutCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_CALLOUT_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutCreateEnumHandle0")]
	public static extern Win32Error FwpmCalloutCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_CALLOUT_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmCalloutCreateEnumHandle0</c> function creates a handle used to enumerate a set of callout objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CALLOUT_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle of the newly created enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all callout objects are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmCalloutCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmCalloutCreateEnumHandle0</c> and FwpmCalloutEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must call FwpmCalloutDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the callouts' containers and <c>FWPM_ACTRL_READ</c> access to the callouts. Only callouts
	/// to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmCalloutCreateEnumHandle0</c> is a specific implementation of FwpmCalloutCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutcreateenumhandle0 DWORD FwpmCalloutCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_CALLOUT_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutCreateEnumHandle0")]
	public static extern Win32Error FwpmCalloutCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmCalloutDeleteById0</c> function removes a callout object from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>
	/// The runtime identifier for the callout being removed from the system. This identifier was received from the system when the
	/// application called FwpmCalloutAdd0 for this object.
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
	/// <term>The callout was successfully deleted.</term>
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
	/// An applications's callouts cannot be removed from the system as long as there are filters in the system that specify the callouts for
	/// an action.
	/// </para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// This function can be called within a dynamic session if the corresponding object was added during the same session. If this function
	/// is called for an object that was added during a different dynamic session, it will fail with <c>FWP_E_WRONG_SESSION</c>. If this
	/// function is called for an object that was not added during a dynamic session, it will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>.
	/// </para>
	/// <para>The caller needs DELETE access to the callout. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutDeleteById0</c> is a specific implementation of FwpmCalloutDeleteById. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutdeletebyid0 DWORD FwpmCalloutDeleteById0( [in] HANDLE
	// engineHandle, [in] UINT32 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutDeleteById0")]
	public static extern Win32Error FwpmCalloutDeleteById0([In] HFWPENG engineHandle, uint id);

	/// <summary>The <c>FwpmCalloutDeleteByKey0</c> function removes a callout object from the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the callout being removed from the system. This GUID was specified in the <c>calloutKey</c> member of the
	/// <c>callout</c> parameter when the application called FwpmCalloutAdd0 for this object.
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
	/// <term>The callout was successfully deleted.</term>
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
	/// An applications's callouts cannot be removed from the system as long as there are filters in the system that specify the callouts for
	/// an action.
	/// </para>
	/// <para>
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// This function can be called within a dynamic session if the corresponding object was added during the same session. If this function
	/// is called for an object that was added during a different dynamic session, it will fail with <c>FWP_E_WRONG_SESSION</c>. If this
	/// function is called for an object that was not added during a dynamic session, it will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>.
	/// </para>
	/// <para>The caller needs DELETE access to the callout. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutDeleteByKey0</c> is a specific implementation of FwpmCalloutDeleteByKey. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutdeletebykey0 DWORD FwpmCalloutDeleteByKey0( [in] HANDLE
	// engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutDeleteByKey0")]
	public static extern Win32Error FwpmCalloutDeleteByKey0([In] HFWPENG engineHandle, in Guid key);

	/// <summary>The <c>FwpmCalloutDestroyEnumHandle0</c> function frees a handle returned by FwpmCalloutCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a callout enumeration created by a call to FwpmCalloutCreateEnumHandle0.</para>
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
	/// <c>FwpmCalloutDestroyEnumHandle0</c> is a specific implementation of FwpmCalloutDestroyEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutdestroyenumhandle0 DWORD FwpmCalloutDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutDestroyEnumHandle0")]
	public static extern Win32Error FwpmCalloutDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmCalloutEnum0</c> function returns the next page of results from the callout enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a callout enumeration created by a call to FwpmCalloutCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of callout objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWP_CALLOUT0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of callouts returned.</para>
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
	/// <term>The callouts were enumerated successfully.</term>
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
	/// <para><c>FwpmCalloutEnum0</c> works on a snapshot of the callouts taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmCalloutEnum0</c> is a specific implementation of FwpmCalloutEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutenum0 DWORD FwpmCalloutEnum0( [in] HFWPENG engineHandle,
	// [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_CALLOUT0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutEnum0")]
	public static extern Win32Error FwpmCalloutEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries,
		out uint numEntriesReturned);

	/// <summary>The <c>FwpmCalloutEnum0</c> function returns the next page of results from the callout enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWP_CALLOUT0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CALLOUT_ENUM_TEMPLATE0*</para>
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
	/// <term>The callouts were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all callout objects are returned.</para>
	/// <para><c>FwpmCalloutEnum0</c> works on a snapshot of the callouts taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmCalloutEnum0</c> is a specific implementation of FwpmCalloutEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutEnum0")]
	public static Win32Error FwpmCalloutEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_CALLOUT0> entries, FWPM_CALLOUT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmCalloutCreateEnumHandle0, FwpmCalloutEnum0, FwpmCalloutDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmCalloutGetById0</c> function retrieves a callout object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>
	/// The runtime identifier for the callout. This identifier was received from the system when the application called FwpmCalloutAdd0 for
	/// this object.
	/// </para>
	/// </param>
	/// <param name="callout">
	/// <para>Type: FWPM_CALLOUT0**</para>
	/// <para>Information about the state associated with the callout.</para>
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
	/// <term>The callout was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the callout. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutGetById0</c> is a specific implementation of FwpmCalloutGetById. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutgetbyid0 DWORD FwpmCalloutGetById0( [in] HANDLE
	// engineHandle, [in] UINT32 id, [out] FWPM_CALLOUT0 **callout );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutGetById0")]
	public static Win32Error FwpmCalloutGetById0([In] HFWPENG engineHandle, uint id, out SafeFwpmStruct<FWPM_CALLOUT0> callout) =>
		FwpmGenericGetById(FwpmCalloutGetById0, engineHandle, id, out callout);

	/// <summary>The <c>FwpmCalloutGetByKey0</c> function retrieves a callout object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the callout. This GUID was specified in the <c>calloutKey</c> member of the <c>callout</c> parameter when the
	/// application called FwpmCalloutAdd0 for this object.
	/// </para>
	/// </param>
	/// <param name="callout">
	/// <para>Type: FWPM_CALLOUT0**</para>
	/// <para>Information about the state associated with the callout.</para>
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
	/// <term>The callout was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the callout. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutGetByKey0</c> is a specific implementation of FwpmCalloutGetByKey. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutgetbykey0 DWORD FwpmCalloutGetByKey0( [in] HANDLE
	// engineHandle, [in] const GUID *key, [out] FWPM_CALLOUT0 **callout );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutGetByKey0")]
	public static Win32Error FwpmCalloutGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmStruct<FWPM_CALLOUT0> callout) =>
		FwpmGenericGetByKey(FwpmCalloutGetByKey0, engineHandle, key, out callout);

	/// <summary>The <c>FwpmCalloutGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a callout object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Pointer to a GUID that uniquely identifies the callout. This GUID was specified in the <c>calloutKey</c> member of the <c>callout</c>
	/// parameter when the application called FwpmCalloutAdd0 for this object.
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
	/// callouts container.
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
	/// <c>FwpmCalloutGetSecurityInfoByKey0</c> is a specific implementation of FwpmCalloutGetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutgetsecurityinfobykey0 DWORD
	// FwpmCalloutGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmCalloutGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, [In] SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmCalloutSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a callout object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Pointer to a GUID that uniquely identifies the callout. This GUID was specified in the <c>calloutKey</c> member of the <c>callout</c>
	/// parameter when the application called FwpmCalloutAdd0 for this object.
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
	/// callouts container.
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
	/// <c>FwpmCalloutSetSecurityInfoByKey0</c> is a specific implementation of FwpmCalloutSetSecurityInfoByKey. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutsetsecurityinfobykey0 DWORD
	// FwpmCalloutSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmCalloutSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, [In] SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmCalloutSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a particular callout.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_CALLOUT_SUBSCRIPTION0*</para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_CALLOUT_CHANGE_CALLBACK0</c></para>
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
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the callout's container and <c>FWPM_ACTRL_READ</c> access to the callout. The
	/// subscriber will only get notifications for callouts to which it has <c>FWPM_ACTRL_READ</c> access. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmCalloutSubscribeChanges0</c> is a specific implementation of FwpmCalloutSubscribeChanges. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutsubscribechanges0 DWORD FwpmCalloutSubscribeChanges0(
	// [in] HFWPENG engineHandle, [in] const FWPM_CALLOUT_SUBSCRIPTION0 *subscription, [in] FWPM_CALLOUT_CHANGE_CALLBACK0 callback, [in,
	// optional] void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutSubscribeChanges0")]
	public static extern Win32Error FwpmCalloutSubscribeChanges0([In] HFWPENG engineHandle, in FWPM_CALLOUT_SUBSCRIPTION0 subscription,
		[In] FWPM_CALLOUT_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPCALLOUTCHANGE changeHandle);

	/// <summary>The <c>FwpmCalloutSubscriptionsGet0</c> function retrieves an array of all the current callout change notification subscriptions.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CALLOUT_SUBSCRIPTION0***</para>
	/// <para>Addresses of the current callout change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the callout's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutSubscriptionsGet0</c> is a specific implementation of FwpmCalloutSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutsubscriptionsget0 DWORD FwpmCalloutSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_CALLOUT_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutSubscriptionsGet0")]
	public static extern Win32Error FwpmCalloutSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>The <c>FwpmCalloutSubscriptionsGet0</c> function retrieves an array of all the current callout change notification subscriptions.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CALLOUT_SUBSCRIPTION0***</para>
	/// <para>Addresses of the current callout change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the callout's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmCalloutSubscriptionsGet0</c> is a specific implementation of FwpmCalloutSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutSubscriptionsGet0")]
	public static Win32Error FwpmCalloutSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_CALLOUT_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmCalloutSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmCalloutUnsubscribeChanges0</c> function is used to cancel a callout change subscription and stop receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed change notification. This is the handle returned by the call to FwpmCalloutSubscribeChanges0.</para>
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
	/// If the callback is currently being invoked, this function will not return until the callback completes. Thus, when calling this
	/// function, you must not hold any locks that the callback may also try to acquire lest you deadlock.
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
	/// <c>FwpmCalloutUnsubscribeChanges0</c> is a specific implementation of FwpmCalloutUnsubscribeChanges. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmcalloutunsubscribechanges0 DWORD FwpmCalloutUnsubscribeChanges0(
	// [in] HFWPENG engineHandle, [in] HANDLE changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmCalloutUnsubscribeChanges0")]
	public static extern Win32Error FwpmCalloutUnsubscribeChanges0([In] HFWPENG engineHandle, [In] HFWPCALLOUTCHANGE changeHandle);

	/// <summary>The <c>FwpmConnectionCreateEnumHandle0</c> function creates a handle used to enumerate a set of connection objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CONNECTION_ENUM_TEMPLATE0*</para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for the enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all connection objects are returned.</para>
	/// <para>The caller must free the returned handle by a call to FwpmConnectionDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the connection objects' containers and <c>FWPM_ACTRL_READ</c> access to the connection
	/// objects. See Access Control for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectioncreateenumhandle0 DWORD
	// FwpmConnectionCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const FWPM_CONNECTION_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionCreateEnumHandle0")]
	public static extern Win32Error FwpmConnectionCreateEnumHandle0([In] HFWPENG engineHandle,
		in FWPM_CONNECTION_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmConnectionCreateEnumHandle0</c> function creates a handle used to enumerate a set of connection objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CONNECTION_ENUM_TEMPLATE0*</para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for the enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all connection objects are returned.</para>
	/// <para>The caller must free the returned handle by a call to FwpmConnectionDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the connection objects' containers and <c>FWPM_ACTRL_READ</c> access to the connection
	/// objects. See Access Control for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectioncreateenumhandle0 DWORD
	// FwpmConnectionCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const FWPM_CONNECTION_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionCreateEnumHandle0")]
	public static extern Win32Error FwpmConnectionCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmConnectionDestroyEnumHandle0</c> function frees a handle returned by FwpmConnectionCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a connection object enumeration created by a call to FwpmProviderContextCreateEnumHandle0.</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectiondestroyenumhandle0 DWORD
	// FwpmConnectionDestroyEnumHandle0( [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionDestroyEnumHandle0")]
	public static extern Win32Error FwpmConnectionDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmConnectionEnum0</c> function returns the next page of results from the connection object enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a provider context enumeration created by a call to FwpmConnectionCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of connection objects requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CONNECTION0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">Type: <c>UINT32*</c></param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The connection objects were enumerated successfully.</term>
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
	/// <para><c>FwpmConnectionEnum0</c> works on a snapshot of the connection objects taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionenum0 DWORD FwpmConnectionEnum0( [in] HANDLE
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_CONNECTION0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionEnum0")]
	public static extern Win32Error FwpmConnectionEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>The <c>FwpmConnectionEnum0</c> function returns the next page of results from the connection object enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CONNECTION0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_CONNECTION_ENUM_TEMPLATE0*</para>
	/// <para>Template for selectively restricting the enumeration.</para>
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
	/// <term>The connection objects were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all connection objects are returned.</para>
	/// <para><c>FwpmConnectionEnum0</c> works on a snapshot of the connection objects taken at the time the enumeration handle was created.</para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionEnum0")]
	public static Win32Error FwpmConnectionEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_CONNECTION0> entries, FWPM_CONNECTION_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmConnectionCreateEnumHandle0, FwpmConnectionEnum0, FwpmConnectionDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmConnectionGetById0</c> function retrieves a connection object.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>The run-time identifier for the connection.</para>
	/// </param>
	/// <param name="connection">
	/// <para>Type: FWPM_CONNECTION0**</para>
	/// <para>The connection information.</para>
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
	/// <term>The connection object was retrieved successfully.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectiongetbyid0 DWORD FwpmConnectionGetById0( [in] HANDLE
	// engineHandle, [in] UINT64 id, [out] FWPM_CONNECTION0 **connection );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionGetById0")]
	public static Win32Error FwpmConnectionGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<FWPM_CONNECTION0> connection) =>
		FwpmGenericGetById(FwpmConnectionGetById0, engineHandle, id, out connection);

	/// <summary>
	/// The <c>FwpmConnectionGetSecurityInfo0</c> function retrieves a copy of the security descriptor for a connection object change event.
	/// </summary>
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
	/// <term>The security descriptor was successfully retrieved.</term>
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
	/// The returned <c>securityDescriptor</c> parameter must be freed through a call to FwpmFreeMemory0. The other four returned parameters
	/// must not be freed, as they point to addresses within the <c>securityDescriptor</c> parameter.
	/// </para>
	/// <para>
	/// This function behaves like the standard Win32 GetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>GetSecurityInfo</c> reference topic.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectiongetsecurityinfo0 DWORD FwpmConnectionGetSecurityInfo0(
	// [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out] PSID *sidOwner, [out] PSID *sidGroup, [out] PACL *dacl, [out]
	// PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionGetSecurityInfo0")]
	public static extern Win32Error FwpmConnectionGetSecurityInfo0([In] HFWPENG engineHandle, [In] SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmConnectionSetSecurityInfo0</c> function sets specified security information in the security descriptor for a connection
	/// object change event.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
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
	/// <term>The security information was successfully set.</term>
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionsetsecurityinfo0 DWORD FwpmConnectionSetSecurityInfo0(
	// [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID
	// *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionSetSecurityInfo0")]
	public static extern Win32Error FwpmConnectionSetSecurityInfo0([In] HFWPENG engineHandle, [In] SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmConnectionSubscribe0</c> function is used to request the delivery of notifications about changes to a connection object.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_CONNECTION_SUBSCRIPTION0*</para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_CONNECTION_CALLBACK0</c></para>
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
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the connection object's container.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionsubscribe0 DWORD FwpmConnectionSubscribe0( [in] HANDLE
	// engineHandle, [in] const FWPM_CONNECTION_SUBSCRIPTION0 *subscription, [in] FWPM_CONNECTION_CALLBACK0 callback, [in, optional] void
	// *context, [out] HANDLE *eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionSubscribe0")]
	public static extern Win32Error FwpmConnectionSubscribe0([In] HFWPENG engineHandle, in FWPM_CONNECTION_SUBSCRIPTION0 subscription,
		[In] FWPM_CONNECTION_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPCONNEVENT eventsHandle);

	/// <summary>
	/// The <c>FwpmConnectionSubscriptionsGet0</c> function retrieves an array of all the current connection object change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CONNECTION_SUBSCRIPTION0***</para>
	/// <para>The current connection object notification subscriptions.</para>
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
	/// <remarks>The returned array (but not the individual entries in the array) must be freed through a call to FwpmFreeMemory0.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionsubscriptionsget0 DWORD
	// FwpmConnectionSubscriptionsGet0( [in] HFWPENG engineHandle, [out] FWPM_CONNECTION_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionSubscriptionsGet0")]
	public static extern Win32Error FwpmConnectionSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>FwpmConnectionSubscriptionsGet0</c> function retrieves an array of all the current connection object change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_CONNECTION_SUBSCRIPTION0***</para>
	/// <para>The current connection object notification subscriptions.</para>
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
	/// <remarks>The returned array (but not the individual entries in the array) must be freed through a call to FwpmFreeMemory0.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionsubscriptionsget0 DWORD
	// FwpmConnectionSubscriptionsGet0( [in] HFWPENG engineHandle, [out] FWPM_CONNECTION_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionSubscriptionsGet0")]
	public static Win32Error FwpmConnectionSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_CONNECTION_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmConnectionSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmConnectionUnsubscribe0</c> function is used to cancel a connection object change event subscription and stop receiving notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="eventsHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed event notification. This is the returned handle from the call to FwpmConnectionSubscribe0.</para>
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmconnectionunsubscribe0 DWORD FwpmConnectionUnsubscribe0( [in]
	// HFWPENG engineHandle, [in, out] HANDLE eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmConnectionUnsubscribe0")]
	public static extern Win32Error FwpmConnectionUnsubscribe0([In] HFWPENG engineHandle, [In, Out] HFWPCONNEVENT eventsHandle);

	/// <summary>The <c>FwpmEngineClose0</c> function closes a session to a filter engine.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
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
	/// <term>The session was closed successfully.</term>
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
	/// After an application has completed adding or removing system objects, it may call the <c>FwpmEngineClose0</c> function to close the
	/// open session to the filter engine.
	/// </para>
	/// <para>A filter engine session is also closed when a client process terminates.</para>
	/// <para>If this function is called with a transaction in progress, the transaction will be aborted.</para>
	/// <para>
	/// <c>FwpmEngineClose0</c> is a specific implementation of FwpmEngineClose. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmengineclose0 DWORD FwpmEngineClose0( [in] HFWPENG engineHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineClose0")]
	public static extern Win32Error FwpmEngineClose0([In] HFWPENG engineHandle);

	/// <summary>The <c>FwpmEngineOpen0</c> function opens a session to the filter engine.</summary>
	/// <param name="serverName">
	/// <para>Type: <c>const wchar_t*</c></para>
	/// <para>This value must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="authnService">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Specifies the authentication service to use. Allowed services are RPC_C_AUTHN_WINNT and RPC_C_AUTHN_DEFAULT.</para>
	/// </param>
	/// <param name="authIdentity">
	/// <para>Type: <c>SEC_WINNT_AUTH_IDENTITY_W*</c></para>
	/// <para>
	/// The authentication and authorization credentials for accessing the filter engine. This pointer is optional and can be <c>NULL</c>. If
	/// this pointer is <c>NULL</c>, the calling thread's credentials are used.
	/// </para>
	/// </param>
	/// <param name="session">
	/// <para>Type: FWPM_SESSION0*</para>
	/// <para>Session-specific parameters for the session being opened. This pointer is optional and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for the open session to the filter engine.</para>
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
	/// <term>The session was started successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_ALREADY_EXISTS</c> 0x80320009</term>
	/// <term>A session with the specified <c>sessionKey</c> is already opened.</term>
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
	/// A user application must call <c>FwpmEngineOpen0</c> to obtain a handle for open session to the filter engine before adding or
	/// removing any filter objects. A handle for an open session to the filter engine is also required for most of the other Windows
	/// Filtering Platform management functions.
	/// </para>
	/// <para>The session is automatically closed when the program ends. To explicitly close a session, call FwpmEngineClose0.</para>
	/// <para>
	/// If <c>session</c>. <c>flags</c> is set to <c>FWPM_SESSION_FLAG_DYNAMIC</c>, any WFP objects added during the session are
	/// automatically deleted when the session ends. If the session is not dynamic, the caller needs to explicitly delete all WFP objects
	/// added during the session.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_OPEN access to the filter engine. See Access Control for more information.</para>
	/// <para><c>FwpmEngineOpen0</c> is intended for use in non-impersonated mode only.</para>
	/// <para>
	/// <c>FwpmEngineOpen0</c> is a specific implementation of FwpmEngineOpen. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example uses <c>FwpmEngineOpen0</c> to open a filter session.</para>
	/// <para>
	/// <code>// Open a session to the filter engine HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; printf("Opening the filter engine.\n"); result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) printf("FwpmEngineOpen0 failed. Return value: %d.\n", result); else printf("Filter engine opened successfully.\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmengineopen0 DWORD FwpmEngineOpen0( [in, optional] const wchar_t
	// *serverName, [in] UINT32 authnService, [in, optional] SEC_WINNT_AUTH_IDENTITY_W *authIdentity, [in, optional] const FWPM_SESSION0
	// *session, [out] HANDLE *engineHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineOpen0")]
	public static extern Win32Error FwpmEngineOpen0([Optional] string? serverName, RPC_C_AUTHN authnService,
		in SEC_WINNT_AUTH_IDENTITY authIdentity, in FWPM_SESSION0 session, out SafeHFWPENG engineHandle);

	/// <summary>The <c>FwpmEngineOpen0</c> function opens a session to the filter engine.</summary>
	/// <param name="serverName">
	/// <para>Type: <c>const wchar_t*</c></para>
	/// <para>This value must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="authnService">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Specifies the authentication service to use. Allowed services are RPC_C_AUTHN_WINNT and RPC_C_AUTHN_DEFAULT.</para>
	/// </param>
	/// <param name="authIdentity">
	/// <para>Type: <c>SEC_WINNT_AUTH_IDENTITY_W*</c></para>
	/// <para>
	/// The authentication and authorization credentials for accessing the filter engine. This pointer is optional and can be <c>NULL</c>. If
	/// this pointer is <c>NULL</c>, the calling thread's credentials are used.
	/// </para>
	/// </param>
	/// <param name="session">
	/// <para>Type: FWPM_SESSION0*</para>
	/// <para>Session-specific parameters for the session being opened. This pointer is optional and can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for the open session to the filter engine.</para>
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
	/// <term>The session was started successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_ALREADY_EXISTS</c> 0x80320009</term>
	/// <term>A session with the specified <c>sessionKey</c> is already opened.</term>
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
	/// A user application must call <c>FwpmEngineOpen0</c> to obtain a handle for open session to the filter engine before adding or
	/// removing any filter objects. A handle for an open session to the filter engine is also required for most of the other Windows
	/// Filtering Platform management functions.
	/// </para>
	/// <para>The session is automatically closed when the program ends. To explicitly close a session, call FwpmEngineClose0.</para>
	/// <para>
	/// If <c>session</c>. <c>flags</c> is set to <c>FWPM_SESSION_FLAG_DYNAMIC</c>, any WFP objects added during the session are
	/// automatically deleted when the session ends. If the session is not dynamic, the caller needs to explicitly delete all WFP objects
	/// added during the session.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_OPEN access to the filter engine. See Access Control for more information.</para>
	/// <para><c>FwpmEngineOpen0</c> is intended for use in non-impersonated mode only.</para>
	/// <para>
	/// <c>FwpmEngineOpen0</c> is a specific implementation of FwpmEngineOpen. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example uses <c>FwpmEngineOpen0</c> to open a filter session.</para>
	/// <para>
	/// <code>// Open a session to the filter engine HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; printf("Opening the filter engine.\n"); result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) printf("FwpmEngineOpen0 failed. Return value: %d.\n", result); else printf("Filter engine opened successfully.\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmengineopen0 DWORD FwpmEngineOpen0( [in, optional] const wchar_t
	// *serverName, [in] UINT32 authnService, [in, optional] SEC_WINNT_AUTH_IDENTITY_W *authIdentity, [in, optional] const FWPM_SESSION0
	// *session, [out] HANDLE *engineHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmEngineOpen0")]
	public static extern Win32Error FwpmEngineOpen0([Optional] string? serverName, RPC_C_AUTHN authnService,
		[In, Optional] IntPtr authIdentity, [In, Optional] IntPtr session, out SafeHFWPENG engineHandle);

	/// <summary>
	/// The <c>FwpmFreeMemory0</c> function is used to release memory resources allocated by the Windows Filtering Platform (WFP) functions.
	/// </summary>
	/// <param name="p">
	/// <para>Type: <c>void**</c></para>
	/// <para>Address of the pointer to be freed.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><c>FwpmFreeMemory0</c> is used to free memory returned by the various <c>Fwpm*</c> functions, such as <c>FwpmFilterGetByKey0</c>.</para>
	/// <para>
	/// <c>Fwpm*</c> functions that return a HANDLE, such as <c>FwpmCalloutCreateEnumHandle0</c>, have specific functions to release memory.
	/// </para>
	/// <para>If the caller passes a pointer that is not valid, the behavior is undefined.</para>
	/// <para>
	/// <c>FwpmFreeMemory0</c> is a specific implementation of FwpmFreeMemory. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmfreememory0 void FwpmFreeMemory0( [in, out] void **p );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmFreeMemory0")]
	public static extern void FwpmFreeMemory0(ref IntPtr p);

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd0</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd0</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmIPsecTunnelAdd1 is
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
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0*</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd0 DWORD FwpmIPsecTunnelAdd0( [in] HANDLE
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT0 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT0
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional]
	// PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd0")]
	public static extern Win32Error FwpmIPsecTunnelAdd0([In] HFWPENG engineHandle, FWPM_TUNNEL_FLAG flags,
		in FWPM_PROVIDER_CONTEXT0 mainModePolicy, in FWPM_PROVIDER_CONTEXT0 tunnelPolicy,
		uint numFilterConditions, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		[In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>
	/// <para>The <c>FwpmIPsecTunnelAdd0</c> function adds a new Internet Protocol Security (IPsec) tunnel mode policy to the system.</para>
	/// <para>
	/// <c>Note</c><c>FwpmIPsecTunnelAdd0</c> is the specific implementation of FwpmIPsecTunnelAdd used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmIPsecTunnelAdd1 is
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
	/// </list>
	/// </param>
	/// <param name="mainModePolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0*</para>
	/// <para>The Main Mode policy for the IPsec tunnel.</para>
	/// </param>
	/// <param name="tunnelPolicy">
	/// <para>Type: FWPM_PROVIDER_CONTEXT0*</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmipsectunneladd0 DWORD FwpmIPsecTunnelAdd0( [in] HANDLE
	// engineHandle, [in] UINT32 flags, [in, optional] const FWPM_PROVIDER_CONTEXT0 *mainModePolicy, [in] const FWPM_PROVIDER_CONTEXT0
	// *tunnelPolicy, [in] UINT32 numFilterConditions, [in] const FWPM_FILTER_CONDITION0 *filterConditions, [in, optional]
	// PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmIPsecTunnelAdd0")]
	public static extern Win32Error FwpmIPsecTunnelAdd0([In] HFWPENG engineHandle, FWPM_TUNNEL_FLAG flags,
		[In, Optional] IntPtr mainModePolicy, in FWPM_PROVIDER_CONTEXT0 tunnelPolicy, uint numFilterConditions,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] FWPM_FILTER_CONDITION0[] filterConditions,
		[In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>The <c>FwpmNetEventCreateEnumHandle0</c> function creates a handle used to enumerate a set of network events.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>The handle for network event enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>The caller must call FwpmNetEventDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ENUM access to the events' containers. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmNetEventCreateEnumHandle0</c> is a specific implementation of FwpmNetEventCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventcreateenumhandle0 DWORD FwpmNetEventCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_NET_EVENT_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventCreateEnumHandle0")]
	public static extern Win32Error FwpmNetEventCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_NET_EVENT_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmNetEventCreateEnumHandle0</c> function creates a handle used to enumerate a set of network events.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>The handle for network event enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>The caller must call FwpmNetEventDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ENUM access to the events' containers. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmNetEventCreateEnumHandle0</c> is a specific implementation of FwpmNetEventCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventcreateenumhandle0 DWORD FwpmNetEventCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_NET_EVENT_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventCreateEnumHandle0")]
	public static extern Win32Error FwpmNetEventCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmNetEventDestroyEnumHandle0</c> function frees a handle returned by FwpmNetEventCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a network event enumeration created by a call to FwpmNetEventCreateEnumHandle0.</para>
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
	/// <c>FwpmNetEventDestroyEnumHandle0</c> is a specific implementation of FwpmNetEventDestroyEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventdestroyenumhandle0 DWORD FwpmNetEventDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventDestroyEnumHandle0")]
	public static extern Win32Error FwpmNetEventDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum0</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum0</c> is the specific implementation of FwpmNetEventEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmNetEventEnum1 is
	/// available. For Windows 8, FwpmNetEventEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a network event enumeration created by a call to FwpmNetEventCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of enumeration entries returned.</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>
	/// A subsequent call that uses the same <c>enumHandle</c> parameter will return the next set of events following those in the current
	/// <c>entries</c> buffer.
	/// </para>
	/// <para>
	/// <c>FwpmNetEventEnum0</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventenum0 DWORD FwpmNetEventEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_NET_EVENT0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum0")]
	public static extern Win32Error FwpmNetEventEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum0</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum0</c> is the specific implementation of FwpmNetEventEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmNetEventEnum1 is
	/// available. For Windows 8, FwpmNetEventEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT0***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>
	/// <c>FwpmNetEventEnum0</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum0")]
	public static Win32Error FwpmNetEventEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_NET_EVENT0> entries, FWPM_NET_EVENT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmNetEventCreateEnumHandle0, FwpmNetEventEnum0, FwpmNetEventDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum1</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum1</c> is the specific implementation of FwpmNetEventEnum used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmNetEventEnum2 is
	/// available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a network event enumeration created by a call to FwpmNetEventCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The nmber of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT1***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of enumeration entries returned.</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>
	/// A subsequent call that uses the same <c>enumHandle</c> parameter will return the next set of events following those in the current
	/// <c>entries</c> buffer.
	/// </para>
	/// <para>
	/// <c>FwpmNetEventEnum1</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventenum1 DWORD FwpmNetEventEnum1( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_NET_EVENT1 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum1")]
	public static extern Win32Error FwpmNetEventEnum1([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum1</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum1</c> is the specific implementation of FwpmNetEventEnum used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8, FwpmNetEventEnum2 is
	/// available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT1***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>
	/// <c>FwpmNetEventEnum1</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum1")]
	public static Win32Error FwpmNetEventEnum1([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_NET_EVENT1> entries, FWPM_NET_EVENT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmNetEventCreateEnumHandle0, FwpmNetEventEnum1, FwpmNetEventDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum2</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum2</c> is the specific implementation of FwpmNetEventEnum used in Windows 8 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmNetEventEnum1 is
	/// available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a network event enumeration created by a call to FwpmNetEventCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT2***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of enumeration entries returned.</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>
	/// A subsequent call that uses the same <c>enumHandle</c> parameter will return the next set of events following those in the current
	/// <c>entries</c> buffer.
	/// </para>
	/// <para>
	/// <c>FwpmNetEventEnum2</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventenum2 DWORD FwpmNetEventEnum2( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_NET_EVENT2 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum2")]
	public static extern Win32Error FwpmNetEventEnum2([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum2</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum2</c> is the specific implementation of FwpmNetEventEnum used in Windows 8 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, FwpmNetEventEnum1 is
	/// available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_NET_EVENT2***</para>
	/// <para>Addresses of enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
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
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>
	/// <c>FwpmNetEventEnum2</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum2")]
	public static Win32Error FwpmNetEventEnum2([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_NET_EVENT2> entries, FWPM_NET_EVENT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmNetEventCreateEnumHandle0, FwpmNetEventEnum2, FwpmNetEventDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum3</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum3</c> s the specific implementation of <c>FwpmNetEventEnum</c> used in Windows 10, version 1607 and
	/// later. See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8,
	/// FwpmNetEventEnum2 is available. For Windows 7, FwpmNetEventEnum1 is available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.
	/// </param>
	/// <param name="enumHandle">Handle for a network event enumeration created by a call to FwpmNetEventCreateEnumHandle0.</param>
	/// <param name="numEntriesRequested">The number of enumeration entries requested.</param>
	/// <param name="entries">Addresses of enumeration entries.</param>
	/// <param name="numEntriesReturned">The number of enumeration entries returned.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>
	/// A subsequent call that uses the same <c>enumHandle</c> parameter will return the next set of events following those in the current
	/// <c>entries</c> buffer.
	/// </para>
	/// <para>
	/// <c>FwpmNetEventEnum3</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmneteventenum3 DWORD FwpmNetEventEnum3( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_NET_EVENT3 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum3")]
	public static extern Win32Error FwpmNetEventEnum3([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>FwpmNetEventEnum3</c> function returns the next page of results from the network event enumerator.</para>
	/// <para>
	/// <c>Note</c><c>FwpmNetEventEnum3</c> s the specific implementation of <c>FwpmNetEventEnum</c> used in Windows 10, version 1607 and
	/// later. See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 8,
	/// FwpmNetEventEnum2 is available. For Windows 7, FwpmNetEventEnum1 is available. For Windows Vista, FwpmNetEventEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.
	/// </param>
	/// <param name="entries">Addresses of enumeration entries.</param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_NET_EVENT_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c> 0</term>
	/// <term>The network events were enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_NET_EVENTS_DISABLED</c> 0x80320013</term>
	/// <term>The collection of network diagnostic events is disabled. Call FwpmEngineSetOption0 to enable it.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all network event objects are returned.</para>
	/// <para>
	/// <c>FwpmNetEventEnum3</c> returns only events that were logged prior to the creation of the <c>enumHandle</c> parameter. See Logging
	/// for more information.
	/// </para>
	/// </remarks>
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmNetEventEnum3")]
	public static Win32Error FwpmNetEventEnum3([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_NET_EVENT3> entries, FWPM_NET_EVENT_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmNetEventCreateEnumHandle0, FwpmNetEventEnum3, FwpmNetEventDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmCalloutGetById0([In] HFWPENG engineHandle, uint id, out SafeFwpmMem callout);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmCalloutGetByKey0([In] HFWPENG engineHandle, [In] in Guid key, out SafeFwpmMem callout);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmConnectionGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem connection);
}