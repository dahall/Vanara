namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>The <c>FwpmSessionCreateEnumHandle0</c> function creates a handle used to enumerate a set of session objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SESSION_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for filter enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all session objects are returned.</para>
	/// <para>The caller must free the returned handle by a call to the FwpmSessionDestroyEnumHandle0.</para>
	/// <para>
	/// <c>FwpmSessionCreateEnumHandle0</c> cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See
	/// Object Management for more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ENUM access to the filter engine. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSessionCreateEnumHandle0</c> is a specific implementation of FwpmSessionCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsessioncreateenumhandle0 DWORD FwpmSessionCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_SESSION_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSessionCreateEnumHandle0")]
	public static extern Win32Error FwpmSessionCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_SESSION_ENUM_TEMPLATE0 enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmSessionCreateEnumHandle0</c> function creates a handle used to enumerate a set of session objects.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SESSION_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for filter enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all session objects are returned.</para>
	/// <para>The caller must free the returned handle by a call to the FwpmSessionDestroyEnumHandle0.</para>
	/// <para>
	/// <c>FwpmSessionCreateEnumHandle0</c> cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See
	/// Object Management for more information about transactions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ENUM access to the filter engine. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSessionCreateEnumHandle0</c> is a specific implementation of FwpmSessionCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsessioncreateenumhandle0 DWORD FwpmSessionCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_SESSION_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSessionCreateEnumHandle0")]
	public static extern Win32Error FwpmSessionCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate,
		out HANDLE enumHandle);

	/// <summary>The <c>FwpmSessionDestroyEnumHandle0</c> function frees a handle returned by FwpmSessionCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a session enumeration created by a call to FwpmSessionCreateEnumHandle0.</para>
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
	/// <c>FwpmSessionDestroyEnumHandle0</c> is a specific implementation of FwpmSessionDestroyEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsessiondestroyenumhandle0 DWORD FwpmSessionDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSessionDestroyEnumHandle0")]
	public static extern Win32Error FwpmSessionDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmSessionEnum0</c> function returns the next page of results from the session enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a session enumeration created by a call to FwpmSessionCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of session entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SESSION0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of session objects returned.</para>
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
	/// <term>The sessions were enumerated successfully.</term>
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
	/// <para><c>FwpmSessionEnum0</c> works on a snapshot of the sessions taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmSessionEnum0</c> is a specific implementation of FwpmSessionEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsessionenum0 DWORD FwpmSessionEnum0( [in] HFWPENG engineHandle,
	// [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_SESSION0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSessionEnum0")]
	public static extern Win32Error FwpmSessionEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>The <c>FwpmSessionEnum0</c> function returns the next page of results from the session enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SESSION0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SESSION_ENUM_TEMPLATE0*</para>
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
	/// <term>The sessions were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all session objects are returned.</para>
	/// <para><c>FwpmSessionEnum0</c> works on a snapshot of the sessions taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmSessionEnum0</c> is a specific implementation of FwpmSessionEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsessionenum0 DWORD FwpmSessionEnum0( [in] HFWPENG engineHandle,
	// [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_SESSION0 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSessionEnum0")]
	public static Win32Error FwpmSessionEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_SESSION0> entries, FWPM_SESSION_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmSessionCreateEnumHandle0, FwpmSessionEnum0, FwpmSessionDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmSubLayerAdd0</c> function adds a new sublayer to the system.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subLayer">
	/// <para>Type: FWPM_SUBLAYER0*</para>
	/// <para>The sublayer to be added.</para>
	/// </param>
	/// <param name="sd">
	/// <para>Type: <c>PSECURITY_DESCRIPTOR</c></para>
	/// <para>Security information for the sublayer object.</para>
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
	/// <term>The sublayer was successfully added.</term>
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
	/// This function cannot be called from within a read-only transaction. It will fail with <c>FWP_E_INCOMPATIBLE_TXN</c>. See Object
	/// Management for more information about transactions.
	/// </para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ADD access to the sublayers's container and <c>FWPM_ACTRL_ADD_LINK</c> access to the provider (if any).
	/// See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmSubLayerAdd0</c> is a specific implementation of FwpmSubLayerAdd. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example illustrates initialization of a sublayer object and adding the sublayer key to a filter object.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;rpc.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") #pragma comment(lib, "Rpcrt4.lib") void main() { FWPM_FILTER0 fwpFilter; FWPM_SUBLAYER0 fwpFilterSubLayer; HFWPENG engineHandle = NULL; DWORD result = ERROR_SUCCESS; RPC_STATUS rpcStatus = RPC_S_OK; memset(&amp;fwpFilterSubLayer, 0, sizeof(fwpFilterSubLayer)); rpcStatus = UuidCreate(&amp;fwpFilterSubLayer.subLayerKey); if (RPC_S_OK != rpcStatus) { printf("UuidCreate failed (%d).\n", rpcStatus); return; } result = FwpmEngineOpen0( NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle ); if (result != ERROR_SUCCESS) { printf("FwpmEngineOpen0 failed.\n"); return; } fwpFilterSubLayer.displayData.name = L"MyFilterSublayer"; fwpFilterSubLayer.displayData.description = L"My filter sublayer"; fwpFilterSubLayer.flags = 0; fwpFilterSubLayer.weight = 0x100; printf("Adding filter sublayer.\n"); result = FwpmSubLayerAdd0(engineHandle, &amp;fwpFilterSubLayer, NULL); if (result != ERROR_SUCCESS) { printf("FwpmSubLayerAdd0 failed (%d).\n", result); return; } // Add sublayer key to a filter. memset(&amp;fwpFilter, 0, sizeof(FWPM_FILTER0)); if (&amp;fwpFilterSubLayer.subLayerKey != NULL) fwpFilter.subLayerKey = fwpFilterSubLayer.subLayerKey; // Finish initializing filter... return; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayeradd0 DWORD FwpmSubLayerAdd0( [in] HFWPENG engineHandle,
	// [in] const FWPM_SUBLAYER0 *subLayer, [in, optional] PSECURITY_DESCRIPTOR sd );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerAdd0")]
	public static extern Win32Error FwpmSubLayerAdd0([In] HFWPENG engineHandle, in FWPM_SUBLAYER0 subLayer, [In, Optional] PSECURITY_DESCRIPTOR sd);

	/// <summary>The <c>FwpmSubLayerCreateEnumHandle0</c> function creates a handle used to enumerate a set of sublayers.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SUBLAYER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for sublayer enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all sublayers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmSubLayerCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmSubLayerCreateEnumHandle0</c> and FwpmSubLayerEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmSubLayerDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the sublayers' containers and <c>FWPM_ACTRL_READ</c> access to the sub-layers. Only
	/// sublayers to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmSubLayerCreateEnumHandle0</c> is a specific implementation of FwpmSubLayerCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayercreateenumhandle0 DWORD FwpmSubLayerCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_SUBLAYER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerCreateEnumHandle0")]
	public static extern Win32Error FwpmSubLayerCreateEnumHandle0([In] HFWPENG engineHandle, in FWPM_SUBLAYER_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmSubLayerCreateEnumHandle0</c> function creates a handle used to enumerate a set of sublayers.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SUBLAYER_ENUM_TEMPLATE0*</para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Handle for sublayer enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all sublayers are returned.</para>
	/// <para>
	/// The enumerator is not "live", meaning it does not reflect changes made to the system after the call to
	/// <c>FwpmSubLayerCreateEnumHandle0</c> returns. If you need to ensure that the results are current, you must call
	/// <c>FwpmSubLayerCreateEnumHandle0</c> and FwpmSubLayerEnum0 from within the same explicit transaction.
	/// </para>
	/// <para>The caller must free the returned handle by a call to FwpmSubLayerDestroyEnumHandle0.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM access to the sublayers' containers and <c>FWPM_ACTRL_READ</c> access to the sub-layers. Only
	/// sublayers to which the caller has <c>FWPM_ACTRL_READ</c> access will be returned. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmSubLayerCreateEnumHandle0</c> is a specific implementation of FwpmSubLayerCreateEnumHandle. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayercreateenumhandle0 DWORD FwpmSubLayerCreateEnumHandle0(
	// [in] HFWPENG engineHandle, [in, optional] const FWPM_SUBLAYER_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerCreateEnumHandle0")]
	public static extern Win32Error FwpmSubLayerCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>FwpmSubLayerDeleteByKey0</c> function deletes a sublayer from the system by its key.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>
	/// Unique identifier of the sublayer to be removed from the system. This is the same GUID that was specified when the application called FwpmSubLayerAdd0.
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
	/// <term>The sublayer was successfully deleted.</term>
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
	/// <para>The caller needs DELETE access to the sub-layer. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSubLayerDeleteByKey0</c> is a specific implementation of FwpmSubLayerDeleteByKey. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayerdeletebykey0 DWORD FwpmSubLayerDeleteByKey0( [in]
	// HFWPENG engineHandle, [in] const GUID *key );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerDeleteByKey0")]
	public static extern Win32Error FwpmSubLayerDeleteByKey0([In] HFWPENG engineHandle, in Guid key);

	/// <summary>The <c>FwpmSubLayerDestroyEnumHandle0</c> function frees a handle returned by FwpmSubLayerCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of a sublayer enumeration created by a call to FwpmSubLayerCreateEnumHandle0.</para>
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
	/// <c>FwpmSubLayerDestroyEnumHandle0</c> is a specific implementation of FwpmSubLayerDestroyEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayerdestroyenumhandle0 DWORD FwpmSubLayerDestroyEnumHandle0(
	// [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerDestroyEnumHandle0")]
	public static extern Win32Error FwpmSubLayerDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>The <c>FwpmSubLayerEnum0</c> function returns the next page of results from the sublayer enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for a sublayer enumeration created by a call to FwpmSubLayerCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of sublayer entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SUBLAYER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of sublayer objects returned.</para>
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
	/// <term>The sublayers were enumerated successfully.</term>
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
	/// <para><c>FwpmSubLayerEnum0</c> works on a snapshot of the sublayers taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmSubLayerEnum0</c> is a specific implementation of FwpmSubLayerEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayerenum0 DWORD FwpmSubLayerEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_SUBLAYER0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerEnum0")]
	public static extern Win32Error FwpmSubLayerEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries,
		out uint numEntriesReturned);

	/// <summary>The <c>FwpmSubLayerEnum0</c> function returns the next page of results from the sublayer enumerator.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SUBLAYER0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: FWPM_SUBLAYER_ENUM_TEMPLATE0*</para>
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
	/// <term>The sublayers were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all sublayers are returned.</para>
	/// <para><c>FwpmSubLayerEnum0</c> works on a snapshot of the sublayers taken at the time the enumeration handle was created.</para>
	/// <para>
	/// <c>FwpmSubLayerEnum0</c> is a specific implementation of FwpmSubLayerEnum. See WFP Version-Independent Names and Targeting Specific
	/// Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayerenum0 DWORD FwpmSubLayerEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] FWPM_SUBLAYER0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerEnum0")]
	public static Win32Error FwpmSubLayerEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_SUBLAYER0> entries, FWPM_SUBLAYER_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(FwpmSubLayerCreateEnumHandle0, FwpmSubLayerEnum0, FwpmSubLayerDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>FwpmSubLayerGetByKey0</c> function retrieves a sublayer by its key.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the sublayer. This is the same GUID that was specified when the application called FwpmSubLayerAdd0.</para>
	/// </param>
	/// <param name="subLayer">
	/// <para>Type: FWPM_SUBLAYER0**</para>
	/// <para>The sublayer information.</para>
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
	/// <term>The sublayer was retrieved successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the sublayer. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSubLayerGetByKey0</c> is a specific implementation of FwpmSubLayerGetByKey. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayergetbykey0 DWORD FwpmSubLayerGetByKey0( [in] HFWPENG
	// engineHandle, [in] const GUID *key, [out] FWPM_SUBLAYER0 **subLayer );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerGetByKey0")]
	public static Win32Error FwpmSubLayerGetByKey0([In] HFWPENG engineHandle, in Guid key, out SafeFwpmStruct<FWPM_SUBLAYER0> subLayer) =>
		FwpmGenericGetByKey(FwpmSubLayerGetByKey0, engineHandle, key, out subLayer);

	/// <summary>The <c>FwpmSubLayerGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a sublayer.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the sublayer. This must be the same GUID that was specified when the application called FwpmSubLayerAdd0.</para>
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
	/// sublayers container.
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
	/// <c>FwpmSubLayerGetSecurityInfoByKey0</c> is a specific implementation of FwpmSubLayerGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayergetsecurityinfobykey0 DWORD
	// FwpmSubLayerGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmSubLayerGetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>The <c>FwpmSubLayerGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor for a sublayer.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the sublayer. This must be the same GUID that was specified when the application called FwpmSubLayerAdd0.</para>
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
	/// sublayers container.
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
	/// <c>FwpmSubLayerGetSecurityInfoByKey0</c> is a specific implementation of FwpmSubLayerGetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayergetsecurityinfobykey0 DWORD
	// FwpmSubLayerGetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerGetSecurityInfoByKey0")]
	public static extern Win32Error FwpmSubLayerGetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmSubLayerSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a sublayer.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the sublayer. This must be the same GUID that was specified when the application called FwpmSubLayerAdd0.</para>
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
	/// sublayers container.
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
	/// <c>FwpmSubLayerSetSecurityInfoByKey0</c> is a specific implementation of FwpmSubLayerSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayersetsecurityinfobykey0 DWORD
	// FwpmSubLayerSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmSubLayerSetSecurityInfoByKey0([In] HFWPENG engineHandle, in Guid key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmSubLayerSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor of a sublayer.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="key">
	/// <para>Type: <c>const GUID*</c></para>
	/// <para>Unique identifier of the sublayer. This must be the same GUID that was specified when the application called FwpmSubLayerAdd0.</para>
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
	/// sublayers container.
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
	/// <c>FwpmSubLayerSetSecurityInfoByKey0</c> is a specific implementation of FwpmSubLayerSetSecurityInfoByKey. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayersetsecurityinfobykey0 DWORD
	// FwpmSubLayerSetSecurityInfoByKey0( [in] HFWPENG engineHandle, [in, optional] const GUID *key, [in] SECURITY_INFORMATION securityInfo,
	// [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerSetSecurityInfoByKey0")]
	public static extern Win32Error FwpmSubLayerSetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr key, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmSubLayerSubscribeChanges0</c> function is used to request the delivery of notifications regarding changes in a particular sublayer.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: FWPM_SUBLAYER_SUBSCRIPTION0*</para>
	/// <para>The notifications to be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_SUBLAYER_CHANGE_CALLBACK0</c></para>
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
	/// The caller needs FWPM_ACTRL_SUBSCRIBE access to the sublayer's container and <c>FWPM_ACTRL_READ</c> access to the sub-layer. The
	/// subscriber will only get notifications for sublayers to which it has <c>FWPM_ACTRL_READ</c> access. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmSubLayerSubscribeChanges0</c> is a specific implementation of FwpmSubLayerSubscribeChanges. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayersubscribechanges0 DWORD FwpmSubLayerSubscribeChanges0(
	// [in] HFWPENG engineHandle, [in] const FWPM_SUBLAYER_SUBSCRIPTION0 *subscription, [in] FWPM_SUBLAYER_CHANGE_CALLBACK0 callback, [in,
	// optional] void *context, [out] HANDLE *changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerSubscribeChanges0")]
	public static extern Win32Error FwpmSubLayerSubscribeChanges0([In] HFWPENG engineHandle, in FWPM_SUBLAYER_SUBSCRIPTION0 subscription,
		[In] FWPM_SUBLAYER_CHANGE_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMSUBLAYERSUB changeHandle);

	/// <summary>
	/// The <c>FwpmSubLayerSubscriptionsGet0</c> function retrieves an array of all the current sub-layer change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SUBLAYER_SUBSCRIPTION0***</para>
	/// <para>The current sublayer change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the sublayer's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSubLayerSubscriptionsGet0</c> is a specific implementation of FwpmSubLayerSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayersubscriptionsget0 DWORD FwpmSubLayerSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_SUBLAYER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerSubscriptionsGet0")]
	public static extern Win32Error FwpmSubLayerSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>FwpmSubLayerSubscriptionsGet0</c> function retrieves an array of all the current sub-layer change notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: FWPM_SUBLAYER_SUBSCRIPTION0***</para>
	/// <para>The current sublayer change notification subscriptions.</para>
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
	/// <para>The caller needs FWPM_ACTRL_READ access to the sublayer's container. See Access Control for more information.</para>
	/// <para>
	/// <c>FwpmSubLayerSubscriptionsGet0</c> is a specific implementation of FwpmSubLayerSubscriptionsGet. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayersubscriptionsget0 DWORD FwpmSubLayerSubscriptionsGet0(
	// [in] HFWPENG engineHandle, [out] FWPM_SUBLAYER_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerSubscriptionsGet0")]
	public static Win32Error FwpmSubLayerSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<FWPM_SUBLAYER_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(FwpmSubLayerSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>FwpmSubLayerUnsubscribeChanges0</c> function is used to cancel a sublayer change subscription and stop receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="changeHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed change notification. This is the returned handle from the call to FwpmSubLayerSubscribeChanges0.</para>
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
	/// <c>FwpmSubLayerUnsubscribeChanges0</c> is a specific implementation of FwpmSubLayerUnsubscribeChanges. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsublayerunsubscribechanges0 DWORD
	// FwpmSubLayerUnsubscribeChanges0( [in] HFWPENG engineHandle, [in] HANDLE changeHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSubLayerUnsubscribeChanges0")]
	public static extern Win32Error FwpmSubLayerUnsubscribeChanges0([In] HFWPENG engineHandle, [In] HFWPMSUBLAYERSUB changeHandle);

	/// <summary>The <c>FwpmSystemPortsGet0</c> function retrieves an array of all of the system port types.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Optional handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="sysPorts">
	/// <para>Type: FWPM_SYSTEM_PORTS0**</para>
	/// <para>The array of system port types.</para>
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
	/// <c>FwpmSystemPortsGet0</c> is a specific implementation of FwpmSystemPortsGet. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsystemportsget0 DWORD FwpmSystemPortsGet0( [in, optional]
	// HFWPENG engineHandle, [out] FWPM_SYSTEM_PORTS0 **sysPorts );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSystemPortsGet0")]
	public static Win32Error FwpmSystemPortsGet0([In, Optional] HFWPENG engineHandle, out SafeFwpmStruct<FWPM_SYSTEM_PORTS0> sysPorts)
	{
		Win32Error err = FwpmSystemPortsGet0(engineHandle, out SafeFwpmMem mem);
		sysPorts = mem;
		return err;
	}

	/// <summary>
	/// The <c>FwpmSystemPortsSubscribe0</c> function is used to request the delivery of notifications regarding a particular system port.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="reserved">
	/// <para>Type: <c>void*</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_SYSTEM_PORTS_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the system port.</para>
	/// </param>
	/// <param name="sysPortsHandle">
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
	/// <para>
	/// <c>FwpmSystemPortsSubscribe0</c> is a specific implementation of FwpmSystemPortsSubscribe. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsystemportssubscribe0 DWORD FwpmSystemPortsSubscribe0( [in,
	// optional] HFWPENG engineHandle, void *reserved, [in] FWPM_SYSTEM_PORTS_CALLBACK0 callback, [in, optional] void *context, [out] HANDLE
	// *sysPortsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSystemPortsSubscribe0")]
	public static extern Win32Error FwpmSystemPortsSubscribe0([In, Optional] HFWPENG engineHandle, [In, Optional] IntPtr reserved,
		[In] FWPM_SYSTEM_PORTS_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMSYSPORTSUB sysPortsHandle);

	/// <summary>The <c>FwpmSystemPortsUnsubscribe0</c> function is used to cancel a system port subscription and stop receiving notifications.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="sysPortsHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed system port notification. This is the returned handle from the call to FwpmSystemPortsSubscribe0.</para>
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
	/// Unsubscribing with an invalid object handle will result in a return value of ERROR_SUCCESS, but the actual subscription will persist
	/// until the unsubscribe API is called with valid parameters.
	/// </para>
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
	/// <c>FwpmSystemPortsUnsubscribe0</c> is a specific implementation of FwpmSystemPortsUnsubscribe. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmsystemportsunsubscribe0 DWORD FwpmSystemPortsUnsubscribe0( [in,
	// optional] HFWPENG engineHandle, [in, out] HANDLE sysPortsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmSystemPortsUnsubscribe0")]
	public static extern Win32Error FwpmSystemPortsUnsubscribe0([In, Optional] HFWPENG engineHandle, [In, Out] HFWPMSYSPORTSUB sysPortsHandle);

	/// <summary>The <c>FwpmTransactionAbort0</c> function causes the current transaction within the current session to abort and rollback.</summary>
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
	/// <term>The transaction was aborted.</term>
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
	/// <para>This function can only be called from within a transaction. Otherwise, it will fail with <c>FWP_E_NO_TXN_IN_PROGRESS</c>.</para>
	/// <para>
	/// <c>FwpmTransactionAbort0</c> is a specific implementation of FwpmTransactionAbort. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmtransactionabort0 DWORD FwpmTransactionAbort0( [in] HFWPENG
	// engineHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmTransactionAbort0")]
	public static extern Win32Error FwpmTransactionAbort0([In] HFWPENG engineHandle);

	/// <summary>The <c>FwpmTransactionBegin0</c> function begins an explicit transaction within the current session.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Transaction flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Begin read/write transaction.</term>
	/// </item>
	/// <item>
	/// <term><c>FWPM_TXN_READ_ONLY</c></term>
	/// <term>Begin read-only transaction.</term>
	/// </item>
	/// </list>
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
	/// <term>The transaction was started successfully.</term>
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
	/// For a read-only transaction, the caller needs FWPM_ACTRL_BEGIN_READ_TXN access to the filter engine. For a read/write transaction,
	/// the caller needs <c>FWPM_ACTRL_BEGIN_WRITE_TXN</c> access to the filter engine. See Access Control for more information.
	/// </para>
	/// <para>
	/// <c>FwpmTransactionBegin0</c> is a specific implementation of FwpmTransactionBegin. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following C++ example illustrates wrapping the FwpmFilterAdd0 function in an FWP transaction.</para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;fwpmu.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "Fwpuclnt.lib") void main() { HFWPENG engineHandle = NULL; FWPM_FILTER0 fwpFilter; RtlZeroMemory(&amp;fwpFilter, sizeof(FWPM_FILTER0)); fwpFilter.layerKey = FWPM_LAYER_ALE_AUTH_RECV_ACCEPT_V4; fwpFilter.action.type = FWP_ACTION_BLOCK; fwpFilter.weight.type = FWP_EMPTY; fwpFilter.numFilterConditions = 0; DWORD result = ERROR_SUCCESS; DWORD fwpTxStatus = ERROR_SUCCESS; printf("Opening filter engine.\n"); result = FwpmEngineOpen0(NULL, RPC_C_AUTHN_WINNT, NULL, NULL, &amp;engineHandle); if (result != ERROR_SUCCESS) { printf("FwpmEngineOpen0 failed (%d).\n", result); return; } printf("Adding filter to permit traffic for Application 1.\n"); fwpTxStatus = FwpmTransactionBegin0(engineHandle, NULL); if (fwpTxStatus != ERROR_SUCCESS) { printf("FwpmTransactionBegin0 failed (%d).\n", fwpTxStatus); return; } result = FwpmFilterAdd0(engineHandle, &amp;fwpFilter, NULL, NULL); if (result != ERROR_SUCCESS) { printf("FwpmFilterAdd0 failed (%d).\n", result); return; } result = FwpmTransactionCommit0(engineHandle); if (result != ERROR_SUCCESS) { printf("FwpmTransactionCommit0 failed (%d).\n", result); return; } else { printf("Filter transaction (adding a filter) committed successfully.\n"); } return; } // ----------------------------------------------------------------------</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmtransactionbegin0 DWORD FwpmTransactionBegin0( [in] HFWPENG
	// engineHandle, [in] UINT32 flags );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmTransactionBegin0")]
	public static extern Win32Error FwpmTransactionBegin0([In] HFWPENG engineHandle, [In] FWPM_TXN flags);

	/// <summary>The <c>FwpmTransactionCommit0</c> function commits the current transaction within the current session.</summary>
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
	/// <term>The transaction was committed successfully.</term>
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
	/// <para>This function can only be called from within a transaction. Otherwise, it will fail with <c>FWP_E_NO_TXN_IN_PROGRESS</c>.</para>
	/// <para>
	/// <c>FwpmTransactionCommit0</c> is a specific implementation of FwpmTransactionCommit. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmtransactioncommit0 DWORD FwpmTransactionCommit0( [in] HFWPENG
	// engineHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmTransactionCommit0")]
	public static extern Win32Error FwpmTransactionCommit0([In] HFWPENG engineHandle);

	/// <summary>The <c>FwpmvSwitchEventsGetSecurityInfo0</c> function retrieves a copy of the security descriptor for a vSwitch event.</summary>
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
	/// <para>
	/// <c>FwpmvSwitchEventsGetSecurityInfo0</c> is a specific implementation of FwpmvSwitchEventsGetSecurityInfo. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmvswitcheventsgetsecurityinfo0 DWORD
	// FwpmvSwitchEventsGetSecurityInfo0( [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out] PSID *sidOwner, [out] PSID
	// *sidGroup, [out] PACL *dacl, [out] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmvSwitchEventsGetSecurityInfo0")]
	public static extern Win32Error FwpmvSwitchEventsGetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>FwpmvSwitchEventsSetSecurityInfo0</c> function sets specified security information in the security descriptor for a vSwitch event.
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
	/// <para>
	/// <c>FwpmvSwitchEventsSetSecurityInfo0</c> is a specific implementation of FwpmvSwitchEventsSetSecurityInfo. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmvswitcheventssetsecurityinfo0 DWORD
	// FwpmvSwitchEventsSetSecurityInfo0( [in] HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID
	// *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmvSwitchEventsSetSecurityInfo0")]
	public static extern Win32Error FwpmvSwitchEventsSetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>FwpmvSwitchEventSubscribe0</c> function is used to request the delivery of notifications regarding a particular vSwitch event.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: <c>const FWPM_VSWITCH_EVENT_SUBSCRIPTION0*</c></para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>FWPM_VSWITCH_EVENT_CALLBACK0</c></para>
	/// <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
	/// </param>
	/// <param name="context">
	/// <para>Type: <c>void*</c></para>
	/// <para>Optional context pointer. This pointer is passed to the <c>callback</c> function along with details of the event.</para>
	/// </param>
	/// <param name="subscriptionHandle">
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
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the virtual switch event's container.</para>
	/// <para>
	/// <c>FwpmvSwitchEventSubscribe0</c> is a specific implementation of FwpmvSwitchEventSubscribe. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmvswitcheventsubscribe0 DWORD FwpmvSwitchEventSubscribe0( [in]
	// HFWPENG engineHandle, [in] const FWPM_VSWITCH_EVENT_SUBSCRIPTION0 *subscription, [in] FWPM_VSWITCH_EVENT_CALLBACK0 callback, [in,
	// optional] void *context, [out] HANDLE *subscriptionHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmvSwitchEventSubscribe0")]
	public static extern Win32Error FwpmvSwitchEventSubscribe0([In] HFWPENG engineHandle, in FWPM_VSWITCH_EVENT_SUBSCRIPTION0 subscription,
		[In] FWPM_VSWITCH_EVENT_CALLBACK0 callback, [In, Optional] IntPtr context, out HFWPMSWITCHEVTSUB subscriptionHandle);

	/// <summary>The <c>FwpmvSwitchEventUnsubscribe0</c> function is used to cancel a vSwitch event subscription and stop receiving notifications.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscriptionHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed event notification. This is the returned handle from the call to FwpmvSwitchEventSubscribe0.</para>
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
	/// <c>FwpmvSwitchEventUnsubscribe0</c> is a specific implementation of FwpmvSwitchEventUnsubscribe. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-fwpmvswitcheventunsubscribe0 DWORD FwpmvSwitchEventUnsubscribe0(
	// [in] HFWPENG engineHandle, [in, out] HANDLE subscriptionHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.FwpmvSwitchEventUnsubscribe0")]
	public static extern Win32Error FwpmvSwitchEventUnsubscribe0([In] HFWPENG engineHandle, [In, Out] HFWPMSWITCHEVTSUB subscriptionHandle);

	/// <summary>
	/// <para>
	/// The <c>IkeextGetStatistics0</c> function retrieves Internet Key Exchange (IKE) and Authenticated Internet Protocol (AuthIP) statistics.
	/// </para>
	/// <para>
	/// <c>Note</c><c>IkeextGetStatistics0</c> is the specific implementation of IkeextGetStatistics used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IkeextGetStatistics1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="ikeextStatistics">
	/// <para>Type: IKEEXT_STATISTICS0*</para>
	/// <para>The top-level object of IKE/AuthIP statistics organization.</para>
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
	/// <term>The information was retrieved successfully.</term>
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
	/// The caller needs FWPM_ACTRL_READ_STATS access to the IKE/AuthIP security associations database. See Access Control for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextgetstatistics0 DWORD IkeextGetStatistics0( [in] HFWPENG
	// engineHandle, [out] IKEEXT_STATISTICS0 *ikeextStatistics );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextGetStatistics0")]
	public static extern Win32Error IkeextGetStatistics0([In] HFWPENG engineHandle, out IKEEXT_STATISTICS0 ikeextStatistics);

	/// <summary>
	/// <para>
	/// The <c>IkeextGetStatistics1</c> function retrieves Internet Key Exchange (IKE) and Authenticated Internet Protocol (AuthIP) statistics.
	/// </para>
	/// <para>
	/// <c>Note</c><c>IkeextGetStatistics1</c> is the specific implementation of IkeextGetStatistics used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IkeextGetStatistics0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="ikeextStatistics">
	/// <para>Type: IKEEXT_STATISTICS1*</para>
	/// <para>The top-level object of IKE/AuthIP statistics organization.</para>
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
	/// <term>The information was retrieved successfully.</term>
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
	/// The caller needs FWPM_ACTRL_READ_STATS access to the IKE/AuthIP security associations database. See Access Control for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextgetstatistics1 DWORD IkeextGetStatistics1( [in] HFWPENG
	// engineHandle, [out] IKEEXT_STATISTICS1 *ikeextStatistics );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextGetStatistics1")]
	public static extern Win32Error IkeextGetStatistics1([In] HFWPENG engineHandle, out IKEEXT_STATISTICS1 ikeextStatistics);

	/// <summary>
	/// The <c>IkeextSaCreateEnumHandle0</c> function creates a handle used to enumerate a set of Internet Key Exchange (IKE) and
	/// Authenticated Internet Protocol (AuthIP) security association (SA) objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IKEEXT_SA_ENUM_TEMPLATE0*</para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle of the newly created enumeration.</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IKE/AuthIP SA objects are returned.</para>
	/// <para>The caller must call IkeextSaDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM and <c>FWPM_ACTRL_READ</c> access to the IKE/AuthIP security associations database. See Access
	/// Control for more information.
	/// </para>
	/// <para>
	/// <c>IkeextSaCreateEnumHandle0</c> is a specific implementation of IkeextSaCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsacreateenumhandle0 DWORD IkeextSaCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const IKEEXT_SA_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaCreateEnumHandle0")]
	public static extern Win32Error IkeextSaCreateEnumHandle0([In] HFWPENG engineHandle, in IKEEXT_SA_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IkeextSaCreateEnumHandle0</c> function creates a handle used to enumerate a set of Internet Key Exchange (IKE) and
	/// Authenticated Internet Protocol (AuthIP) security association (SA) objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IKEEXT_SA_ENUM_TEMPLATE0*</para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle of the newly created enumeration.</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IKE/AuthIP SA objects are returned.</para>
	/// <para>The caller must call IkeextSaDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM and <c>FWPM_ACTRL_READ</c> access to the IKE/AuthIP security associations database. See Access
	/// Control for more information.
	/// </para>
	/// <para>
	/// <c>IkeextSaCreateEnumHandle0</c> is a specific implementation of IkeextSaCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsacreateenumhandle0 DWORD IkeextSaCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const IKEEXT_SA_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaCreateEnumHandle0")]
	public static extern Win32Error IkeextSaCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IkeextSaDbGetSecurityInfo0</c> function retrieves a copy of the security descriptor for a security association (SA) database.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
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
	/// <c>IkeextSaDbGetSecurityInfo0</c> is a specific implementation of IkeextSaDbGetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsadbgetsecurityinfo0 DWORD IkeextSaDbGetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out,
	// optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaDbGetSecurityInfo0")]
	public static extern Win32Error IkeextSaDbGetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>IkeextSaDbSetSecurityInfo0</c> function sets specified security information in the security descriptor of the IKE/AuthIP
	/// security association database.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
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
	/// <term>The security information was set successfully.</term>
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
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>IkeextSaDbSetSecurityInfo0</c> is a specific implementation of IkeextSaDbSetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsadbsetsecurityinfo0 DWORD IkeextSaDbSetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup,
	// [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaDbSetSecurityInfo0")]
	public static extern Win32Error IkeextSaDbSetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>The <c>IkeextSaDeleteById0</c> function removes a security association (SA) from the database.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>The SA identifier.</para>
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
	/// <term>The SA was removed successfully.</term>
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
	/// <c>IkeextSaDeleteById0</c> is a specific implementation of IkeextSaDeleteById. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsadeletebyid0 DWORD IkeextSaDeleteById0( [in] HFWPENG
	// engineHandle, [in] UINT64 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaDeleteById0")]
	public static extern Win32Error IkeextSaDeleteById0([In] HFWPENG engineHandle, ulong id);

	/// <summary>The <c>IkeextSaDestroyEnumHandle0</c> function frees a handle returned by IkeextSaCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine generated by a previous call to FwpmEngineOpen0.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the enumeration to destroy. Previously created by a call to IkeextSaCreateEnumHandle0.</para>
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
	/// <term>The enumeration was deleted successfully.</term>
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
	/// <c>IkeextSaDestroyEnumHandle0</c> is a specific implementation of IkeextSaDestroyEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsadestroyenumhandle0 DWORD IkeextSaDestroyEnumHandle0( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaDestroyEnumHandle0")]
	public static extern Win32Error IkeextSaDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>
	/// <para>The <c>IkeextSaEnum0</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum0</c> is the specific implementation of IkeextSaEnum used in Windows Vista. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaEnum1 is available. For Windows 8,
	/// IkeextSaEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IKE/AuthIP SA enumeration. Call IkeextSaCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS0***</para>
	/// <para>Addresses of the enumeration entries.</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para><c>IkeextSaEnum0</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum0 DWORD IkeextSaEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum0")]
	public static extern Win32Error IkeextSaEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IkeextSaEnum0</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum0</c> is the specific implementation of IkeextSaEnum used in Windows Vista. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaEnum1 is available. For Windows 8,
	/// IkeextSaEnum2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IKEEXT_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IKE/AuthIP SA objects are returned.</para>
	/// <para><c>IkeextSaEnum0</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum0 DWORD IkeextSaEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS0 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum0")]
	public static Win32Error IkeextSaEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<IKEEXT_SA_DETAILS0> entries, IKEEXT_SA_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IkeextSaCreateEnumHandle0, IkeextSaEnum0, IkeextSaDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IkeextSaEnum1</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum1</c> is the specific implementation of IkeextSaEnum used in Windows 7. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 8, IkeextSaEnum2 is available. For Windows Vista,
	/// IkeextSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IKE/AuthIP SA enumeration. Call IkeextSaCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS1***</para>
	/// <para>Addresses of the enumeration entries.</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para><c>IkeextSaEnum1</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum1 DWORD IkeextSaEnum1( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS1 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum1")]
	public static extern Win32Error IkeextSaEnum1([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IkeextSaEnum1</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum1</c> is the specific implementation of IkeextSaEnum used in Windows 7. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 8, IkeextSaEnum2 is available. For Windows Vista,
	/// IkeextSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS1***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IKEEXT_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IKE/AuthIP SA objects are returned.</para>
	/// <para><c>IkeextSaEnum1</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum1 DWORD IkeextSaEnum1( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS1 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum1")]
	public static Win32Error IkeextSaEnum1([In] HFWPENG engineHandle, out SafeFwpmArray<IKEEXT_SA_DETAILS1> entries, IKEEXT_SA_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IkeextSaCreateEnumHandle0, IkeextSaEnum1, IkeextSaDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IkeextSaEnum2</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum2</c> is the specific implementation of IkeextSaEnum used in Windows 8. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaEnum1 is available. For Windows Vista,
	/// IkeextSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IKE/AuthIP SA enumeration. Call IkeextSaCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS2***</para>
	/// <para>Addresses of the enumeration entries.</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para><c>IkeextSaEnum2</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum2 DWORD IkeextSaEnum2( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS2 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum2")]
	public static extern Win32Error IkeextSaEnum2([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IkeextSaEnum2</c> function returns the next page of results from the IKE/AuthIP security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaEnum2</c> is the specific implementation of IkeextSaEnum used in Windows 8. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaEnum1 is available. For Windows Vista,
	/// IkeextSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IKEEXT_SA_DETAILS2***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IKEEXT_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IKE/AuthIP SA objects are returned.</para>
	/// <para><c>IkeextSaEnum2</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsaenum2 DWORD IkeextSaEnum2( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IKEEXT_SA_DETAILS2 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaEnum2")]
	public static Win32Error IkeextSaEnum2([In] HFWPENG engineHandle, out SafeFwpmArray<IKEEXT_SA_DETAILS2> entries, IKEEXT_SA_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IkeextSaCreateEnumHandle0, IkeextSaEnum2, IkeextSaDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IkeextSaGetById0</c> function retrieves an IKE/AuthIP security association (SA) from the database.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaGetById0</c> is the specific implementation of IkeextSaGetById used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaGetById1 is
	/// available. For Windows 8, IkeextSaGetById2 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>The SA identifier.</para>
	/// </param>
	/// <param name="sa">
	/// <para>Type: IKEEXT_SA_DETAILS0**</para>
	/// <para>Address of the SA details.</para>
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
	/// <term>The SA was retrieved successfully.</term>
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
	/// <para>The caller must free <c>sa</c> by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the IKE/AuthIP security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsagetbyid0 DWORD IkeextSaGetById0( [in] HFWPENG engineHandle,
	// [in] UINT64 id, [out] IKEEXT_SA_DETAILS0 **sa );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaGetById0")]
	public static Win32Error IkeextSaGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<IKEEXT_SA_DETAILS0> sa) =>
		FwpmGenericGetById(IkeextSaGetById0, engineHandle, id, out sa);

	/// <summary>
	/// <para>The <c>IkeextSaGetById1</c> function retrieves an IKE/AuthIP security association (SA) from the database.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaGetById1</c> is the specific implementation of IkeextSaGetById used in Windows 7. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows 8, IkeextSaGetById2 is available. For Windows
	/// Vista, IkeextSaGetById0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>The SA identifier.</para>
	/// </param>
	/// <param name="saLookupContext">
	/// <para>Type: <c>GUID*</c></para>
	/// <para>
	/// Optional pointer to the SA lookup context propagated from the SA to data connections flowing over that SA. It is made available to
	/// any application that queries socket security properties using the Winsock API WSAQuerySocketSecurity function, allowing the
	/// application to obtain detailed IPsec authentication information for its connection.
	/// </para>
	/// </param>
	/// <param name="sa">
	/// <para>Type: IKEEXT_SA_DETAILS1**</para>
	/// <para>Address of the SA details.</para>
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
	/// <term>The SA was retrieved successfully.</term>
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
	/// <para>The caller must free <c>sa</c> by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the IKE/AuthIP security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsagetbyid1 DWORD IkeextSaGetById1( [in] HFWPENG engineHandle,
	// [in] UINT64 id, [in, optional] GUID *saLookupContext, [out] IKEEXT_SA_DETAILS1 **sa );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaGetById1")]
	public static Win32Error IkeextSaGetById1([In] HFWPENG engineHandle, ulong id, Guid? saLookupContext, out SafeFwpmStruct<IKEEXT_SA_DETAILS1> sa)
	{
		using SafeCoTaskMemStruct<Guid> pCtx = saLookupContext;
		Win32Error err = IkeextSaGetById1(engineHandle, id, (IntPtr)pCtx, out SafeFwpmMem mem);
		sa = mem;
		return err;
	}

	/// <summary>
	/// <para>The <c>IkeextSaGetById2</c> function retrieves an IKE/AuthIP security association (SA) from the database.</para>
	/// <para>
	/// <c>Note</c><c>IkeextSaGetById2</c> is the specific implementation of IkeextSaGetById used in Windows 8. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows 7, IkeextSaGetById1 is available. For Windows
	/// Vista, IkeextSaGetById0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>The SA identifier.</para>
	/// </param>
	/// <param name="saLookupContext">
	/// <para>Type: <c>GUID*</c></para>
	/// <para>
	/// Optional pointer to the SA lookup context propagated from the SA to data connections flowing over that SA. It is made available to
	/// any application that queries socket security properties using the Winsock API WSAQuerySocketSecurity function, allowing the
	/// application to obtain detailed IPsec authentication information for its connection.
	/// </para>
	/// </param>
	/// <param name="sa">
	/// <para>Type: IKEEXT_SA_DETAILS2**</para>
	/// <para>Address of the SA details.</para>
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
	/// <term>The SA was retrieved successfully.</term>
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
	/// <para>The caller must free <c>sa</c> by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the IKE/AuthIP security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ikeextsagetbyid2 DWORD IkeextSaGetById2( [in] HFWPENG engineHandle,
	// [in] UINT64 id, [in, optional] GUID *saLookupContext, [out] IKEEXT_SA_DETAILS2 **sa );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IkeextSaGetById2")]
	public static Win32Error IkeextSaGetById2([In] HFWPENG engineHandle, ulong id, Guid? saLookupContext, out SafeFwpmStruct<IKEEXT_SA_DETAILS2> sa)
	{
		using SafeCoTaskMemStruct<Guid> pCtx = saLookupContext;
		Win32Error err = IkeextSaGetById2(engineHandle, id, (IntPtr)pCtx, out SafeFwpmMem mem);
		sa = mem;
		return err;
	}

	/// <summary>
	/// The <c>IPsecDospGetSecurityInfo0</c> function retrieves a copy of the security descriptor for the IPsec DoS Protection database.
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
	/// <c>IPsecDospGetSecurityInfo0</c> is a specific implementation of IPsecDospGetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospgetsecurityinfo0 DWORD IPsecDospGetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out,
	// optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospGetSecurityInfo0")]
	public static extern Win32Error IPsecDospGetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>The <c>IPsecDospGetStatistics0</c> function retrieves Internet Protocol Security (IPsec) DoS Protection statistics.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="idpStatistics">
	/// <para>Type: IPSEC_DOSP_STATISTICS0*</para>
	/// <para>Top-level object of IPsec DoS Protection statistics organization.</para>
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
	/// <term>The IPsec DoS Protection statistics were successfully returned.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ_STATS access to the IPsec DoS Protection component. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecDospGetStatistics0</c> is a specific implementation of IPsecDospGetStatistics. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospgetstatistics0 DWORD IPsecDospGetStatistics0( [in] HFWPENG
	// engineHandle, [out] IPSEC_DOSP_STATISTICS0 *idpStatistics );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospGetStatistics0")]
	public static extern Win32Error IPsecDospGetStatistics0([In] HFWPENG engineHandle, out IPSEC_DOSP_STATISTICS0 idpStatistics);

	/// <summary>
	/// The <c>IPsecDospSetSecurityInfo0</c> function sets specified security information in the security descriptor of the IPsec DoS
	/// Protection database.
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
	/// <term>The security information was set successfully.</term>
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
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>IPsecDospSetSecurityInfo0</c> is a specific implementation of IPsecDospSetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospsetsecurityinfo0 DWORD IPsecDospSetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup,
	// [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospSetSecurityInfo0")]
	public static extern Win32Error IPsecDospSetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>
	/// The <c>IPsecDospStateCreateEnumHandle0</c> function creates a handle used to enumerate a set of IPsec DoS Protection objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_DOSP_STATE_ENUM_TEMPLATE0*</c></para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for the newly created enumeration.</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec DoS Protection objects are returned.</para>
	/// <para>The caller must call IPsecDospStateDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>The caller needs FWPM_ACTRL_READ_STATS access to the IPsec DoS Protection component. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecDospStateCreateEnumHandle0</c> is a specific implementation of IPsecDospStateCreateEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospstatecreateenumhandle0 DWORD
	// IPsecDospStateCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const IPSEC_DOSP_STATE_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospStateCreateEnumHandle0")]
	public static extern Win32Error IPsecDospStateCreateEnumHandle0([In] HFWPENG engineHandle, in IPSEC_DOSP_STATE_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IPsecDospStateCreateEnumHandle0</c> function creates a handle used to enumerate a set of IPsec DoS Protection objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_DOSP_STATE_ENUM_TEMPLATE0*</c></para>
	/// <para>Template for selectively restricting the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for the newly created enumeration.</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec DoS Protection objects are returned.</para>
	/// <para>The caller must call IPsecDospStateDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>The caller needs FWPM_ACTRL_READ_STATS access to the IPsec DoS Protection component. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecDospStateCreateEnumHandle0</c> is a specific implementation of IPsecDospStateCreateEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospstatecreateenumhandle0 DWORD
	// IPsecDospStateCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const IPSEC_DOSP_STATE_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospStateCreateEnumHandle0")]
	public static extern Win32Error IPsecDospStateCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>IPsecDospStateDestroyEnumHandle0</c> function frees a handle returned by IPsecDospStateCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the enumeration to destroy. Previously created by a call to IPsecDospStateCreateEnumHandle0.</para>
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
	/// <term>The enumeration was deleted successfully.</term>
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
	/// <c>IPsecDospStateDestroyEnumHandle0</c> is a specific implementation of IPsecDospStateDestroyEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospstatedestroyenumhandle0 DWORD
	// IPsecDospStateDestroyEnumHandle0( [in] HFWPENG engineHandle, [in, out] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospStateDestroyEnumHandle0")]
	public static extern Win32Error IPsecDospStateDestroyEnumHandle0([In] HFWPENG engineHandle, [In, Out] HANDLE enumHandle);

	/// <summary>
	/// The <c>IPsecDospStateEnum0</c> function returns the next page of results from the IPsec DoS Protection state enumerator. Each IPsec
	/// DoS Protection state entry corresponds to a flow that has successfully passed the IPsec DoS Protection authentication checks.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IPsec DoS Protection enumeration. Call IPsecDospStateCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_DOSP_STATE0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntries">
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
	/// <term>The results were enumerated successfully.</term>
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
	/// <para>If the <c>numEntries</c> is less than the <c>numEntriesRequested</c>, the enumeration is exhausted.</para>
	/// <para>The returned array of entries (but not the individual entries themselves) must be freed by a call to FwpmFreeMemory0.</para>
	/// <para>A subsequent call using the same enumeration handle will return the next set of items following those in the last output buffer.</para>
	/// <para>
	/// <c>IPsecDospStateEnum0</c> is a specific implementation of IPsecDospStateEnum. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospstateenum0 DWORD IPsecDospStateEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_DOSP_STATE0 ***entries, [out] UINT32 *numEntries );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospStateEnum0")]
	public static extern Win32Error IPsecDospStateEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntries);

	/// <summary>
	/// The <c>IPsecDospStateEnum0</c> function returns the next page of results from the IPsec DoS Protection state enumerator. Each IPsec
	/// DoS Protection state entry corresponds to a flow that has successfully passed the IPsec DoS Protection authentication checks.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_DOSP_STATE0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_DOSP_STATE_ENUM_TEMPLATE0*</c></para>
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
	/// <term>The results were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec DoS Protection objects are returned.</para>
	/// <para>
	/// <c>IPsecDospStateEnum0</c> is a specific implementation of IPsecDospStateEnum. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecdospstateenum0 DWORD IPsecDospStateEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_DOSP_STATE0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecDospStateEnum0")]
	public static Win32Error IPsecDospStateEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_DOSP_STATE0> entries, IPSEC_DOSP_STATE_ENUM_TEMPLATE0? enumTemplate = null) =>
		FwpmGenericEnum(IPsecDospStateCreateEnumHandle0, IPsecDospStateEnum0, IPsecDospStateDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IPsecGetStatistics0</c> function retrieves Internet Protocol Security (IPsec) statistics.</para>
	/// <para>
	/// <c>Note</c><c>IPsecGetStatistics0</c> is the specific implementation of IPsecGetStatistics used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecGetStatistics1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="ipsecStatistics">
	/// <para>Type: IPSEC_STATISTICS0*</para>
	/// <para>Top-level object of IPsec statistics organization.</para>
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
	/// <term>The IPsec statistics were successfully retrieved.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ_STATS access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecgetstatistics0 DWORD IPsecGetStatistics0( [in] HFWPENG
	// engineHandle, [out] IPSEC_STATISTICS0 *ipsecStatistics );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecGetStatistics0")]
	public static extern Win32Error IPsecGetStatistics0([In] HFWPENG engineHandle, out IPSEC_STATISTICS0 ipsecStatistics);

	/// <summary>
	/// <para>The <c>IPsecGetStatistics1</c> function retrieves Internet Protocol Security (IPsec) statistics.</para>
	/// <para>
	/// <c>Note</c><c>IPsecGetStatistics1</c> is the specific implementation of IPsecGetStatistics used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecGetStatistics0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="ipsecStatistics">
	/// <para>Type: IPSEC_STATISTICS1*</para>
	/// <para>Top-level object of IPsec statistics organization.</para>
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
	/// <term>The IPsec statistics were successfully retrieved.</term>
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
	/// <para>The caller needs FWPM_ACTRL_READ_STATS access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecgetstatistics1 DWORD IPsecGetStatistics1( [in] HFWPENG
	// engineHandle, [out] IPSEC_STATISTICS1 *ipsecStatistics );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecGetStatistics1")]
	public static extern Win32Error IPsecGetStatistics1([In] HFWPENG engineHandle, out IPSEC_STATISTICS1 ipsecStatistics);

	/// <summary>The <c>IPsecKeyManagerAddAndRegister0</c> function registers a Trusted Intermediary Agent (TIA) with IPsec.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="keyManager">
	/// <para>Type: <c>const IPSEC_KEY_MANAGER0*</c></para>
	/// <para>The set of key management callbacks which IPsec will invoke.</para>
	/// </param>
	/// <param name="keyManagerCallbacks">
	/// <para>Type: <c>const IPSEC_KEY_MANAGER_CALLBACKS0*</c></para>
	/// <para>The set of callbacks which should be invoked by IPsec at various stages of SA negotiation.</para>
	/// </param>
	/// <param name="keyMgmtHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of the newly created registration.</para>
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
	/// <term>The TIA was successfully registered.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_* error code</c> 0x80320001—0x80320039</term>
	/// <term>A Windows Filtering Platform (WFP) specific error. See WFP Error Codes for details.</term>
	/// </item>
	/// <item>
	/// <term><c>RPC_* error code</c> 0x80010001—0x80010122</term>
	/// <term>Failure to communicate with the remote or local firewall engine.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_ALREADY_EXISTS</c> 0x80320009L</term>
	/// <term>The TIA was not registered successfully because another TIA has already been registered to dictate keys.</term>
	/// </item>
	/// <item>
	/// <term><c>FWP_E_INVALID_INTERVAL</c> 0x80320021L</term>
	/// <term>The TIA was not registered successfully because <c>keyDictationTimeoutHint</c> exceeded the maximum allowed value of 10 seconds.</term>
	/// </item>
	/// <item>
	/// <term><c>SEC_E_CANNOT_INSTALL</c> 0x80090307L</term>
	/// <term>
	/// The TIA was not registered successfully because the binary image has not set the <c>IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY</c> property.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the <c>IPSEC_KEY_MANAGER_FLAG_DICTATE_KEY</c> flag is set for <c>keyManager</c>, all three callback members of
	/// <c>keyManagerCallbacks</c> must be specified; otherwise, only the <c>keyNotify</c> callback should be specified
	/// </para>
	/// <para>
	/// This function cannot be called from within a transaction. It will fail with <c>FWP_E_TXN_IN_PROGRESS</c>. See Object Management for
	/// more information about transactions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipseckeymanageraddandregister0 DWORD IPsecKeyManagerAddAndRegister0(
	// [in] HFWPENG engineHandle, [in] const IPSEC_KEY_MANAGER0 *keyManager, [in] const IPSEC_KEY_MANAGER_CALLBACKS0 *keyManagerCallbacks,
	// [out] HANDLE *keyMgmtHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecKeyManagerAddAndRegister0")]
	public static extern Win32Error IPsecKeyManagerAddAndRegister0([In] HFWPENG engineHandle, in IPSEC_KEY_MANAGER0 keyManager,
		in IPSEC_KEY_MANAGER_CALLBACKS0 keyManagerCallbacks, out HIPSECKEYMGRREG keyMgmtHandle);

	/// <summary>
	/// The <c>IPsecKeyManagerGetSecurityInfoByKey0</c> function retrieves a copy of the security descriptor that controls access to the key manager.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="reserved">
	/// <para>Type: <c>const void*</c></para>
	/// <para>Reserved. Must be set to NULL.</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipseckeymanagergetsecurityinfobykey0 DWORD
	// IPsecKeyManagerGetSecurityInfoByKey0( [in] HFWPENG engineHandle, const void *reserved, [in] SECURITY_INFORMATION securityInfo, [out,
	// optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out, optional] PACL *dacl, [out, optional] PACL *sacl, [out]
	// PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecKeyManagerGetSecurityInfoByKey0")]
	public static extern Win32Error IPsecKeyManagerGetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr reserved, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>IPsecKeyManagerSetSecurityInfoByKey0</c> function sets specified security information in the security descriptor that controls
	/// access to the key manager.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="reserved">
	/// <para>Type: <c>const void*</c></para>
	/// <para>Reserved. Should be specified as NULL.</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipseckeymanagersetsecurityinfobykey0 DWORD
	// IPsecKeyManagerSetSecurityInfoByKey0( [in] HFWPENG engineHandle, const void *reserved, [in] SECURITY_INFORMATION securityInfo, [in,
	// optional] const SID *sidOwner, [in, optional] const SID *sidGroup, [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecKeyManagerSetSecurityInfoByKey0")]
	public static extern Win32Error IPsecKeyManagerSetSecurityInfoByKey0([In] HFWPENG engineHandle, [In, Optional] IntPtr reserved, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>The <c>IPsecKeyManagersGet0</c> function returns a list of current Trusted Intermediary Agents (TIAs).</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: <c>IPSEC_KEY_MANAGER0***</c></para>
	/// <para>All of the current TIAs.</para>
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
	/// <term>The list of current TIAs was successfully returned.</term>
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
	/// <remarks>The returned array of entries (but not the individual entries themselves) must be freed by a call to FwpmFreeMemory0.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipseckeymanagersget0 DWORD IPsecKeyManagersGet0( [in] HFWPENG
	// engineHandle, [out] IPSEC_KEY_MANAGER0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecKeyManagersGet0")]
	public static Win32Error IPsecKeyManagersGet0([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_KEY_MANAGER0> entries) =>
		FwpmGenericGetSubs(IPsecKeyManagersGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>IPsecKeyManagerUnregisterAndDelete0</c> function unregisters a Trusted Intermediary Agent (TIA) which had previously been
	/// registered with IPsec.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="keyMgmtHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Address of the previously created registration.</para>
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
	/// <term>The TIA was successfully unregistered.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipseckeymanagerunregisteranddelete0 DWORD
	// IPsecKeyManagerUnregisterAndDelete0( [in] HFWPENG engineHandle, [in] HANDLE keyMgmtHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecKeyManagerUnregisterAndDelete0")]
	public static extern Win32Error IPsecKeyManagerUnregisterAndDelete0([In] HFWPENG engineHandle, [In] HIPSECKEYMGRREG keyMgmtHandle);

	/// <summary>
	/// <para>The <c>IPsecSaContextAddInbound0</c> function adds an inbound IPsec security association (SA) bundle to an existing SA context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextAddInbound0</c> is the specific implementation of IPsecSaContextAddInbound used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextAddInbound1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>Identifier for the existing IPsec SA context. This is the value returned in the <c>id</c> parameter by the call to IPsecSaContextCreate0.</para>
	/// </param>
	/// <param name="inboundBundle">
	/// <para>Type: IPSEC_SA_BUNDLE0*</para>
	/// <para>The inbound IPsec SA bundle to be added to the SA context.</para>
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
	/// <term>The IPsec SA bundle was successfully added to the SA context.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextaddinbound0 DWORD IPsecSaContextAddInbound0( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [in] const IPSEC_SA_BUNDLE0 *inboundBundle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextAddInbound0")]
	public static extern Win32Error IPsecSaContextAddInbound0([In] HFWPENG engineHandle, ulong id, in IPSEC_SA_BUNDLE0 inboundBundle);

	/// <summary>
	/// <para>The <c>IPsecSaContextAddInbound1</c> function adds an inbound IPsec security association (SA) bundle to an existing SA context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextAddInbound1</c> is the specific implementation of IPsecSaContextAddInbound used in Windows 7 and later.
	/// See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista,
	/// IPsecSaContextAddInbound0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>Identifier for the existing IPsec SA context. This is the value returned in the <c>id</c> parameter by the call to IPsecSaContextCreate1.</para>
	/// </param>
	/// <param name="inboundBundle">
	/// <para>Type: IPSEC_SA_BUNDLE1*</para>
	/// <para>The inbound IPsec SA bundle to be added to the SA context.</para>
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
	/// <term>The IPsec SA bundle was successfully added to the SA context.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextaddinbound1 DWORD IPsecSaContextAddInbound1( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [in] const IPSEC_SA_BUNDLE1 *inboundBundle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextAddInbound1")]
	public static extern Win32Error IPsecSaContextAddInbound1([In] HFWPENG engineHandle, ulong id, in IPSEC_SA_BUNDLE1 inboundBundle);

	/// <summary>
	/// <para>The <c>IPsecSaContextAddOutbound0</c> function adds an outbound IPsec security association (SA) bundle to an existing SA context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextAddOutbound0</c> is the specific implementation of IPsecSaContextAddOutbound used in Windows Vista. See
	/// WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextAddOutbound1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>Identifier for the existing IPsec SA context. This is the value returned in the <c>id</c> parameter by the call to IPsecSaContextCreate0.</para>
	/// </param>
	/// <param name="outboundBundle">
	/// <para>Type: IPSEC_SA_BUNDLE0*</para>
	/// <para>The outbound IPsec SA bundle to be added to the SA context.</para>
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
	/// <term>The IPsec SA bundle was successfully added to the SA context.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextaddoutbound0 DWORD IPsecSaContextAddOutbound0( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [in] const IPSEC_SA_BUNDLE0 *outboundBundle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextAddOutbound0")]
	public static extern Win32Error IPsecSaContextAddOutbound0([In] HFWPENG engineHandle, ulong id, in IPSEC_SA_BUNDLE0 outboundBundle);

	/// <summary>
	/// <para>The <c>IPsecSaContextAddOutbound1</c> function adds an outbound IPsec security association (SA) bundle to an existing SA context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextAddOutbound1</c> is the specific implementation of IPsecSaContextAddOutbound used in Windows 7 and later.
	/// See WFP Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista,
	/// IPsecSaContextAddOutbound0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>Identifier for the existing IPsec SA context. This is the value returned in the <c>id</c> parameter by the call to IPsecSaContextCreate1.</para>
	/// </param>
	/// <param name="outboundBundle">
	/// <para>Type: IPSEC_SA_BUNDLE1*</para>
	/// <para>The outbound IPsec SA bundle to be added to the SA context.</para>
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
	/// <term>The IPsec SA bundle was successfully added to the SA context.</term>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextaddoutbound1 DWORD IPsecSaContextAddOutbound1( [in]
	// HFWPENG engineHandle, [in] UINT64 id, [in] const IPSEC_SA_BUNDLE1 *outboundBundle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextAddOutbound1")]
	public static extern Win32Error IPsecSaContextAddOutbound1([In] HFWPENG engineHandle, ulong id, in IPSEC_SA_BUNDLE1 outboundBundle);

	/// <summary>
	/// <para>The <c>IPsecSaContextCreate0</c> function creates an IPsec security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextCreate0</c> is the specific implementation of IPsecSaContextCreate used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextCreate1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="outboundTraffic">
	/// <para>Type: IPSEC_TRAFFIC0*</para>
	/// <para>The outbound traffic of the SA.</para>
	/// </param>
	/// <param name="inboundFilterId">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>
	/// Optional filter identifier of the cached inbound filter corresponding to the <c>outboundTraffic</c> parameter specified by the
	/// caller. Base filtering engine (BFE) may cache the inbound filter identifier and return the cached value, if available. Caller must
	/// handle the case when BFE does not have a cached value, in which case this parameter will be set to 0.
	/// </para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>The identifier of the IPsec SA context.</para>
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
	/// <term>The IPsec SA context was created successfully.</term>
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
	/// This function cannot be called from within a dynamic session. The call will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See
	/// Object Management for more information about dynamic sessions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextcreate0 DWORD IPsecSaContextCreate0( [in] HFWPENG
	// engineHandle, [in] const IPSEC_TRAFFIC0 *outboundTraffic, [out, optional] UINT64 *inboundFilterId, [out] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextCreate0")]
	public static extern Win32Error IPsecSaContextCreate0([In] HFWPENG engineHandle, in IPSEC_TRAFFIC0 outboundTraffic, out ulong inboundFilterId, out ulong id);

	/// <summary>
	/// <para>The <c>IPsecSaContextCreate1</c> function creates an IPsec security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextCreate1</c> is the specific implementation of IPsecSaContextCreate used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextCreate0
	/// is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="outboundTraffic">
	/// <para>Type: IPSEC_TRAFFIC1*</para>
	/// <para>The outbound traffic of the SA.</para>
	/// </param>
	/// <param name="virtualIfTunnelInfo">
	/// <para>Type: IPSEC_VIRTUAL_IF_TUNNEL_INFO0*</para>
	/// <para>Details related to virtual interface tunneling.</para>
	/// </param>
	/// <param name="inboundFilterId">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>
	/// Optional filter identifier of the cached inbound filter corresponding to the <c>outboundTraffic</c> parameter specified by the
	/// caller. Base filtering engine (BFE) may cache the inbound filter identifier and return the cached value, if available. Caller must
	/// handle the case when BFE does not have a cached value, in which case this parameter will be set to 0.
	/// </para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>The identifier of the IPsec SA context.</para>
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
	/// <term>The IPsec SA context was created successfully.</term>
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
	/// This function cannot be called from within a dynamic session. The call will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See
	/// Object Management for more information about dynamic sessions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextcreate1 DWORD IPsecSaContextCreate1( [in] HFWPENG
	// engineHandle, [in] const IPSEC_TRAFFIC1 *outboundTraffic, [in, optional] const IPSEC_VIRTUAL_IF_TUNNEL_INFO0 *virtualIfTunnelInfo,
	// [out, optional] UINT64 *inboundFilterId, [out] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextCreate1")]
	public static extern Win32Error IPsecSaContextCreate1([In] HFWPENG engineHandle, in IPSEC_TRAFFIC1 outboundTraffic,
		in IPSEC_VIRTUAL_IF_TUNNEL_INFO0 virtualIfTunnelInfo, out ulong inboundFilterId, out ulong id);

	/// <summary>
	/// <para>The <c>IPsecSaContextCreate1</c> function creates an IPsec security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextCreate1</c> is the specific implementation of IPsecSaContextCreate used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextCreate0
	/// is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="outboundTraffic">
	/// <para>Type: IPSEC_TRAFFIC1*</para>
	/// <para>The outbound traffic of the SA.</para>
	/// </param>
	/// <param name="virtualIfTunnelInfo">
	/// <para>Type: IPSEC_VIRTUAL_IF_TUNNEL_INFO0*</para>
	/// <para>Details related to virtual interface tunneling.</para>
	/// </param>
	/// <param name="inboundFilterId">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>
	/// Optional filter identifier of the cached inbound filter corresponding to the <c>outboundTraffic</c> parameter specified by the
	/// caller. Base filtering engine (BFE) may cache the inbound filter identifier and return the cached value, if available. Caller must
	/// handle the case when BFE does not have a cached value, in which case this parameter will be set to 0.
	/// </para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64*</c></para>
	/// <para>The identifier of the IPsec SA context.</para>
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
	/// <term>The IPsec SA context was created successfully.</term>
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
	/// This function cannot be called from within a dynamic session. The call will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See
	/// Object Management for more information about dynamic sessions.
	/// </para>
	/// <para>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextcreate1 DWORD IPsecSaContextCreate1( [in] HFWPENG
	// engineHandle, [in] const IPSEC_TRAFFIC1 *outboundTraffic, [in, optional] const IPSEC_VIRTUAL_IF_TUNNEL_INFO0 *virtualIfTunnelInfo,
	// [out, optional] UINT64 *inboundFilterId, [out] UINT64 *id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextCreate1")]
	public static extern Win32Error IPsecSaContextCreate1([In] HFWPENG engineHandle, in IPSEC_TRAFFIC1 outboundTraffic,
		[In, Optional] IntPtr virtualIfTunnelInfo, out ulong inboundFilterId, out ulong id);

	/// <summary>
	/// The <c>IPsecSaContextCreateEnumHandle0</c> function creates a handle used to enumerate a set of IPsec security association (SA)
	/// context objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for SA context enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para>The caller must call IPsecSaContextDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM and <c>FWPM_ACTRL_READ</c> access to the IPsec security associations database. See Access Control
	/// for more information.
	/// </para>
	/// <para>
	/// <c>IPsecSaContextCreateEnumHandle0</c> is a specific implementation of IPsecSaContextCreateEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextcreateenumhandle0 DWORD
	// IPsecSaContextCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextCreateEnumHandle0")]
	public static extern Win32Error IPsecSaContextCreateEnumHandle0([In] HFWPENG engineHandle, in IPSEC_SA_CONTEXT_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IPsecSaContextCreateEnumHandle0</c> function creates a handle used to enumerate a set of IPsec security association (SA)
	/// context objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0*</c></para>
	/// <para>Template to selectively restrict the enumeration.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE*</c></para>
	/// <para>Address of a <c>HANDLE</c> variable. On function return, it contains the handle for SA context enumeration.</para>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para>The caller must call IPsecSaContextDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_ENUM and <c>FWPM_ACTRL_READ</c> access to the IPsec security associations database. See Access Control
	/// for more information.
	/// </para>
	/// <para>
	/// <c>IPsecSaContextCreateEnumHandle0</c> is a specific implementation of IPsecSaContextCreateEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextcreateenumhandle0 DWORD
	// IPsecSaContextCreateEnumHandle0( [in] HFWPENG engineHandle, [in, optional] const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0 *enumTemplate, [out]
	// HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextCreateEnumHandle0")]
	public static extern Win32Error IPsecSaContextCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>The <c>IPsecSaContextDeleteById0</c> function deletes an IPsec security association (SA) context.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>
	/// A runtime identifier for the object being removed from the system. This identifier was received from the system when the application
	/// called IPsecSaContextCreate0.
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
	/// <term>The IPsec SA context was successfully deleted.</term>
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
	/// This function cannot be called from within a dynamic session. The call will fail with <c>FWP_E_DYNAMIC_SESSION_IN_PROGRESS</c>. See
	/// Object Management for more information about dynamic sessions.
	/// </para>
	/// <para>The caller needs DELETE access to the IPsec security associations database. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecSaContextDeleteById0</c> is a specific implementation of IPsecSaContextDeleteById. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextdeletebyid0 DWORD IPsecSaContextDeleteById0( [in]
	// HFWPENG engineHandle, [in] UINT64 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextDeleteById0")]
	public static extern Win32Error IPsecSaContextDeleteById0([In] HFWPENG engineHandle, ulong id);

	/// <summary>The <c>IPsecSaContextDestroyEnumHandle0</c> function frees a handle returned by IPsecSaContextCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of an IPsec security association (SA) context enumeration returned by IPsecSaContextCreateEnumHandle0.</para>
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
	/// <c>IPsecSaContextDestroyEnumHandle0</c> is a specific implementation of IPsecSaContextDestroyEnumHandle. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextdestroyenumhandle0 DWORD
	// IPsecSaContextDestroyEnumHandle0( [in] HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextDestroyEnumHandle0")]
	public static extern Win32Error IPsecSaContextDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>
	/// <para>The <c>IPsecSaContextEnum0</c> function returns the next page of results from the IPsec security association (SA) context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextEnum0</c> is the specific implementation of IPsecSaContextEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextEnum1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an SA context enumeration returned by IPsecSaContextCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of SA contexts requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_CONTEXT0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of SA contexts returned.</para>
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
	/// <term>The IPsec SA contexts were enumerated successfully.</term>
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextenum0 DWORD IPsecSaContextEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_CONTEXT0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextEnum0")]
	public static extern Win32Error IPsecSaContextEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IPsecSaContextEnum0</c> function returns the next page of results from the IPsec security association (SA) context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextEnum0</c> is the specific implementation of IPsecSaContextEnum used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextEnum1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_CONTEXT0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0*</c></para>
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
	/// <term>The IPsec SA contexts were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextenum0 DWORD IPsecSaContextEnum0( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_CONTEXT0 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextEnum0")]
	public static Win32Error IPsecSaContextEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_SA_CONTEXT0> entries, IPSEC_SA_CONTEXT_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IPsecSaContextCreateEnumHandle0, IPsecSaContextEnum0, IPsecSaContextDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IPsecSaContextEnum1</c> function returns the next page of results from the IPsec security association (SA) context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextEnum1</c> is the specific implementation of IPsecSaContextEnum used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an SA context enumeration returned by IPsecSaContextCreateEnumHandle0.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Number of SA contexts requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_CONTEXT1***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="numEntriesReturned">
	/// <para>Type: <c>UINT32*</c></para>
	/// <para>The number of SA contexts returned.</para>
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
	/// <term>The IPsec SA contexts were enumerated successfully.</term>
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextenum1 DWORD IPsecSaContextEnum1( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_CONTEXT1 ***entries, [out] UINT32
	// *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextEnum1")]
	public static extern Win32Error IPsecSaContextEnum1([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested, out SafeFwpmMem entries,
		out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IPsecSaContextEnum1</c> function returns the next page of results from the IPsec security association (SA) context enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextEnum1</c> is the specific implementation of IPsecSaContextEnum used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_CONTEXT1***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: <c>const IPSEC_SA_CONTEXT_ENUM_TEMPLATE0*</c></para>
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
	/// <term>The IPsec SA contexts were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextenum1 DWORD IPsecSaContextEnum1( [in] HFWPENG
	// engineHandle, [in] HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_CONTEXT1 ***entries, [out] UINT32
	// *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextEnum1")]
	public static Win32Error IPsecSaContextEnum1([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_SA_CONTEXT1> entries, IPSEC_SA_CONTEXT_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IPsecSaContextCreateEnumHandle0, IPsecSaContextEnum1, IPsecSaContextDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>The <c>IPsecSaContextExpire0</c> function indicates that an IPsec security association (SA) context should be expired.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for SA context. This identifier was received from the system when the application called IPsecSaContextCreate0.</para>
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
	/// <term>The IPsec SA context was successfully expired.</term>
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
	/// When an SA context is expired, the corresponding outbound SA gets deleted immediately, whereas the inbound SA deletion is postponed
	/// for a minute. This allows the processing of any inbound IPsec protected traffic that may still be on the wire.
	/// </para>
	/// <para>The caller needs DELETE access to the IPsec security associations database. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecSaContextExpire0</c> is a specific implementation of IPsecSaContextExpire. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextexpire0 DWORD IPsecSaContextExpire0( [in] HFWPENG
	// engineHandle, [in] UINT64 id );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextExpire0")]
	public static extern Win32Error IPsecSaContextExpire0([In] HFWPENG engineHandle, ulong id);

	/// <summary>
	/// <para>The <c>IPsecSaContextGetById0</c> function retrieves an IPsec security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextGetById0</c> is the specific implementation of IPsecSaContextGetById used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextGetById1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for the SA context. This identifier was received from the system when the application called IPsecSaContextCreate0.</para>
	/// </param>
	/// <param name="saContext">
	/// <para>Type: IPSEC_SA_CONTEXT0**</para>
	/// <para>Address of the IPsec SA context.</para>
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
	/// <term>The IPsec SA context was successfully retrieved.</term>
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
	/// <para>The caller must free the returned object, <c>saContext</c>, by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextgetbyid0 DWORD IPsecSaContextGetById0( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [out] IPSEC_SA_CONTEXT0 **saContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextGetById0")]
	public static Win32Error IPsecSaContextGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<IPSEC_SA_CONTEXT0> saContext) =>
		FwpmGenericGetById(IPsecSaContextGetById0, engineHandle, id, out saContext);

	/// <summary>
	/// <para>The <c>IPsecSaContextGetById1</c> function retrieves an IPsec security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextGetById1</c> is the specific implementation of IPsecSaContextGetById used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextGetById0
	/// is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for the SA context. This identifier was received from the system when the application called IPsecSaContextCreate0.</para>
	/// </param>
	/// <param name="saContext">
	/// <para>Type: IPSEC_SA_CONTEXT1**</para>
	/// <para>Address of the IPsec SA context.</para>
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
	/// <term>The IPsec SA context was successfully retrieved.</term>
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
	/// <para>The caller must free the returned object, <c>saContext</c>, by a call to FwpmFreeMemory0.</para>
	/// <para>The caller needs FWPM_ACTRL_READ access to the IPsec security associations database. See Access Control for more information.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextgetbyid1 DWORD IPsecSaContextGetById1( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [out] IPSEC_SA_CONTEXT1 **saContext );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextGetById1")]
	public static Win32Error IPsecSaContextGetById1([In] HFWPENG engineHandle, ulong id, out SafeFwpmStruct<IPSEC_SA_CONTEXT1> saContext) =>
		FwpmGenericGetById(IPsecSaContextGetById1, engineHandle, id, out saContext);

	/// <summary>
	/// <para>The <c>IPsecSaContextGetSpi0</c> function retrieves the security parameters index (SPI) for a security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextGetSpi0</c> is the specific implementation of IPsecSaContextGetSpi used in Windows Vista. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows 7 and later,
	/// IPsecSaContextGetSpi1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for the SA context. This identifier was received from the system when the application called IPsecSaContextCreate0.</para>
	/// </param>
	/// <param name="getSpi">
	/// <para>Type: IPSEC_GETSPI0*</para>
	/// <para>The inbound IPsec traffic.</para>
	/// </param>
	/// <param name="inboundSpi">
	/// <para>Type: <c>IPSEC_SA_SPI*</c></para>
	/// <para>The inbound SA SPI. The <c>IPSEC_SA_SPI</c> data type maps to the <c>UINT32</c> data type.</para>
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
	/// <term>The SPI for the IPsec SA context was retrieved successfully.</term>
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
	/// <remarks>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextgetspi0 DWORD IPsecSaContextGetSpi0( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [in] const IPSEC_GETSPI0 *getSpi, [out] IPSEC_SA_SPI *inboundSpi );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextGetSpi0")]
	public static extern Win32Error IPsecSaContextGetSpi0([In] HFWPENG engineHandle, ulong id, in IPSEC_GETSPI0 getSpi, out uint inboundSpi);

	/// <summary>
	/// <para>The <c>IPsecSaContextGetSpi1</c> function retrieves the security parameters index (SPI) for a security association (SA) context.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaContextGetSpi1</c> is the specific implementation of IPsecSaContextGetSpi used in Windows 7 and later. See WFP
	/// Version-Independent Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaContextGetSpi0
	/// is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for the SA context. This identifier was received from the system when the application called IPsecSaContextCreate1.</para>
	/// </param>
	/// <param name="getSpi">
	/// <para>Type: IPSEC_GETSPI1*</para>
	/// <para>The inbound IPsec traffic.</para>
	/// </param>
	/// <param name="inboundSpi">
	/// <para>Type: <c>IPSEC_SA_SPI*</c></para>
	/// <para>The inbound SA SPI. The <c>IPSEC_SA_SPI</c> data type maps to the <c>UINT32</c> data type.</para>
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
	/// <term>The SPI for the IPsec SA context was retrieved successfully.</term>
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
	/// <remarks>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextgetspi1 DWORD IPsecSaContextGetSpi1( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [in] const IPSEC_GETSPI1 *getSpi, [out] IPSEC_SA_SPI *inboundSpi );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextGetSpi1")]
	public static extern Win32Error IPsecSaContextGetSpi1([In] HFWPENG engineHandle, ulong id, in IPSEC_GETSPI1 getSpi, out uint inboundSpi);

	/// <summary>The <c>IPsecSaContextSetSpi0</c> function sets the security parameters index (SPI) for a security association (SA) context.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>UINT64</c></para>
	/// <para>A runtime identifier for the SA context. This identifier was received from the system when the application called IPsecSaContextCreate1.</para>
	/// </param>
	/// <param name="getSpi">
	/// <para>Type: IPSEC_GETSPI1*</para>
	/// <para>The inbound IPsec traffic.</para>
	/// </param>
	/// <param name="inboundSpi">
	/// <para>Type: <c>IPSEC_SA_SPI</c></para>
	/// <para>The inbound SA SPI. The <c>IPSEC_SA_SPI</c> data type maps to the <c>UINT32</c> data type.</para>
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
	/// <term>The SPI for the IPsec SA context was set successfully.</term>
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
	/// <para>The caller needs FWPM_ACTRL_ADD access to the IPsec security associations database. See Access Control for more information.</para>
	/// <para>
	/// <c>IPsecSaContextSetSpi0</c> is a specific implementation of IPsecSaContextSetSpi. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextsetspi0 DWORD IPsecSaContextSetSpi0( [in] HFWPENG
	// engineHandle, [in] UINT64 id, [in] const IPSEC_GETSPI1 *getSpi, [in] IPSEC_SA_SPI inboundSpi );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextSetSpi0")]
	public static extern Win32Error IPsecSaContextSetSpi0([In] HFWPENG engineHandle, ulong id, in IPSEC_GETSPI1 getSpi, uint inboundSpi);

	/// <summary>
	/// The <c>IPsecSaContextSubscribe0</c> function is used to request the delivery of notifications regarding a particular IPsec security
	/// association (SA) context.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="subscription">
	/// <para>Type: <c>const IPSEC_SA_CONTEXT_SUBSCRIPTION0*</c></para>
	/// <para>The notifications which will be delivered.</para>
	/// </param>
	/// <param name="callback">
	/// <para>Type: <c>IPSEC_SA_CONTEXT_CALLBACK0</c></para>
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
	/// <para>The caller needs FWPM_ACTRL_SUBSCRIBE access to the IPsec SA context's container.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextsubscribe0 DWORD IPsecSaContextSubscribe0( [in]
	// HFWPENG engineHandle, [in] const IPSEC_SA_CONTEXT_SUBSCRIPTION0 *subscription, [in] IPSEC_SA_CONTEXT_CALLBACK0 callback, [in,
	// optional] void *context, [out] HANDLE *eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextSubscribe0")]
	public static extern Win32Error IPsecSaContextSubscribe0([In] HFWPENG engineHandle, in IPSEC_SA_CONTEXT_SUBSCRIPTION0 subscription,
		[In] IPSEC_SA_CONTEXT_CALLBACK0 callback, [In, Optional] IntPtr context, out HIPSECSACTXSUB eventsHandle);

	/// <summary>
	/// The <c>IPsecSaContextSubscriptionsGet0</c> function retrieves an array of all the current IPsec security association (SA) change
	/// notification subscriptions.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: <c>IPSEC_SA_CONTEXT_SUBSCRIPTION0***</c></para>
	/// <para>The current IPsec SA notification subscriptions.</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextsubscriptionsget0 DWORD
	// IPsecSaContextSubscriptionsGet0( [in] HFWPENG engineHandle, [out] IPSEC_SA_CONTEXT_SUBSCRIPTION0 ***entries, [out] UINT32 *numEntries );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextSubscriptionsGet0")]
	public static Win32Error IPsecSaContextSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_SA_CONTEXT_SUBSCRIPTION0> entries) =>
		FwpmGenericGetSubs(IPsecSaContextSubscriptionsGet0, engineHandle, out entries);

	/// <summary>
	/// The <c>IPsecSaContextUnsubscribe0</c> function is used to cancel an IPsec security association (SA) change subscription and stop
	/// receiving change notifications.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="eventsHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the subscribed SA change notification. This is the returned handle from the call to IPsecSaContextSubscribe0.</para>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextunsubscribe0 DWORD IPsecSaContextUnsubscribe0( [in]
	// HFWPENG engineHandle, [in, out] HANDLE eventsHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextUnsubscribe0")]
	public static extern Win32Error IPsecSaContextUnsubscribe0([In] HFWPENG engineHandle, [In, Out] HIPSECSACTXSUB eventsHandle);

	/// <summary>The <c>IPsecSaContextUpdate0</c> function updates an IPsec security association (SA) context.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>Flags indicating the specific field in the IPSEC_SA_CONTEXT1 structure that is being updated.</para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPsec SA flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>IPSEC_SA_DETAILS_UPDATE_TRAFFIC</c></term>
	/// <term>Updates the [IPSEC_SA_DETAILS1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_details1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_DETAILS_UPDATE_UDP_ENCAPSULATION</c></term>
	/// <term>Updates the [IPSEC_SA_DETAILS1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_details1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_BUNDLE_UPDATE_FLAGS</c></term>
	/// <term>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_BUNDLE_UPDATE_NAP_CONTEXT</c></term>
	/// <term>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_BUNDLE_UPDATE_KEY_MODULE_STATE</c></term>
	/// <term>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_BUNDLE_UPDATE_PEER_V4_PRIVATE_ADDRESS</c></term>
	/// <term>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</term>
	/// </item>
	/// <item>
	/// <term><c>IPSEC_SA_BUNDLE_UPDATE_MM_SA_ID</c></term>
	/// <term>Updates the [IPSEC_SA_BUNDLE1](/windows/desktop/api/ipsectypes/ns-ipsectypes-ipsec_sa_bundle1) structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="newValues">
	/// <para>Type: IPSEC_SA_CONTEXT1*</para>
	/// <para>An inbound and outbound SA pair.</para>
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
	/// <term>The IPsec SA context was updated successfully.</term>
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
	/// <c>IPsecSaContextUpdate0</c> is a specific implementation of IPsecSaContextUpdate. See WFP Version-Independent Names and Targeting
	/// Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacontextupdate0 DWORD IPsecSaContextUpdate0( [in] HFWPENG
	// engineHandle, [in] UINT64 flags, [in] const IPSEC_SA_CONTEXT1 *newValues );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaContextUpdate0")]
	public static extern Win32Error IPsecSaContextUpdate0([In] HFWPENG engineHandle, [In] IPSEC_SA_BUNDLE_UPDATE flags, in IPSEC_SA_CONTEXT1 newValues);

	/// <summary>
	/// The <c>IPsecSaCreateEnumHandle0</c> function creates a handle used to enumerate a set of Internet Protocol Security (IPsec) security
	/// association (SA) objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IPSEC_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para>The caller must call IPsecSaDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_READ and <c>FWPM_ACTRL_ENUM</c> access to the IPsec security associations database. See Access Control
	/// for more information.
	/// </para>
	/// <para>
	/// <c>IPsecSaCreateEnumHandle0</c> is a specific implementation of IPsecSaCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacreateenumhandle0 DWORD IPsecSaCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const IPSEC_SA_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaCreateEnumHandle0")]
	public static extern Win32Error IPsecSaCreateEnumHandle0([In] HFWPENG engineHandle, in IPSEC_SA_ENUM_TEMPLATE0 enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IPsecSaCreateEnumHandle0</c> function creates a handle used to enumerate a set of Internet Protocol Security (IPsec) security
	/// association (SA) objects.
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IPSEC_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The enumeration was created successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para>The caller must call IPsecSaDestroyEnumHandle0 to free the returned handle.</para>
	/// <para>
	/// The caller needs FWPM_ACTRL_READ and <c>FWPM_ACTRL_ENUM</c> access to the IPsec security associations database. See Access Control
	/// for more information.
	/// </para>
	/// <para>
	/// <c>IPsecSaCreateEnumHandle0</c> is a specific implementation of IPsecSaCreateEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsacreateenumhandle0 DWORD IPsecSaCreateEnumHandle0( [in]
	// HFWPENG engineHandle, [in, optional] const IPSEC_SA_ENUM_TEMPLATE0 *enumTemplate, [out] HANDLE *enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaCreateEnumHandle0")]
	public static extern Win32Error IPsecSaCreateEnumHandle0([In] HFWPENG engineHandle, [In, Optional] IntPtr enumTemplate, out HANDLE enumHandle);

	/// <summary>
	/// The <c>IPsecSaDbGetSecurityInfo0</c> function retrieves a copy of the security descriptor for the IPsec security association (SA) database.
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
	/// <c>IPsecSaDbGetSecurityInfo0</c> is a specific implementation of IPsecSaDbGetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsadbgetsecurityinfo0 DWORD IPsecSaDbGetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [out, optional] PSID *sidOwner, [out, optional] PSID *sidGroup, [out,
	// optional] PACL *dacl, [out, optional] PACL *sacl, [out] PSECURITY_DESCRIPTOR *securityDescriptor );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaDbGetSecurityInfo0")]
	public static extern Win32Error IPsecSaDbGetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		out PSID sidOwner, out PSID sidGroup, out PACL dacl, out PACL sacl, out SafeFwpmMem securityDescriptor);

	/// <summary>
	/// The <c>IPsecSaDbSetSecurityInfo0</c> function sets specified security information in the security descriptor of the IPsec security
	/// association database.
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
	/// <term>The security information was set successfully.</term>
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
	/// This function behaves like the standard Win32 SetSecurityInfo function. The caller needs the same standard access rights as described
	/// in the <c>SetSecurityInfo</c> reference topic.
	/// </para>
	/// <para>
	/// <c>IPsecSaDbSetSecurityInfo0</c> is a specific implementation of IPsecSaDbSetSecurityInfo. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsadbsetsecurityinfo0 DWORD IPsecSaDbSetSecurityInfo0( [in]
	// HFWPENG engineHandle, [in] SECURITY_INFORMATION securityInfo, [in, optional] const SID *sidOwner, [in, optional] const SID *sidGroup,
	// [in, optional] const ACL *dacl, [in, optional] const ACL *sacl );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaDbSetSecurityInfo0")]
	public static extern Win32Error IPsecSaDbSetSecurityInfo0([In] HFWPENG engineHandle, SECURITY_INFORMATION securityInfo,
		[In, Optional] PSID sidOwner, [In, Optional] PSID sidGroup, [In, Optional] PACL dacl, [In, Optional] PACL sacl);

	/// <summary>The <c>IPsecSaDestroyEnumHandle0</c> function frees a handle returned by IPsecSaCreateEnumHandle0.</summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle of the enumeration to destroy. Previously created by a call to IPsecSaCreateEnumHandle0.</para>
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
	/// <term>The enumeration was deleted successfully.</term>
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
	/// <c>IPsecSaDestroyEnumHandle0</c> is a specific implementation of IPsecSaDestroyEnumHandle. See WFP Version-Independent Names and
	/// Targeting Specific Versions of Windows for more information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsadestroyenumhandle0 DWORD IPsecSaDestroyEnumHandle0( [in]
	// HFWPENG engineHandle, [in] HANDLE enumHandle );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaDestroyEnumHandle0")]
	public static extern Win32Error IPsecSaDestroyEnumHandle0([In] HFWPENG engineHandle, [In] HANDLE enumHandle);

	/// <summary>
	/// <para>The <c>IPsecSaEnum0</c> function returns the next page of results from the IPsec security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaEnum0</c> is the specific implementation of IPsecSaEnum used in Windows Vista. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 7 and later, IPsecSaEnum1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IPsec SA enumeration. Call IPsecSaCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_DETAILS0***</para>
	/// <para>Addresses of the enumeration entries.</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para><c>IPsecSaEnum0</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsaenum0 DWORD IPsecSaEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_DETAILS0 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaEnum0")]
	public static extern Win32Error IPsecSaEnum0([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IPsecSaEnum0</c> function returns the next page of results from the IPsec security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaEnum0</c> is the specific implementation of IPsecSaEnum used in Windows Vista. See WFP Version-Independent Names
	/// and Targeting Specific Versions of Windows for more information. For Windows 7 and later, IPsecSaEnum1 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_DETAILS0***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IPSEC_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para><c>IPsecSaEnum0</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsaenum0 DWORD IPsecSaEnum0( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_DETAILS0 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaEnum0")]
	public static Win32Error IPsecSaEnum0([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_SA_DETAILS0> entries, IPSEC_SA_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IPsecSaCreateEnumHandle0, IPsecSaEnum0, IPsecSaDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	/// <summary>
	/// <para>The <c>IPsecSaEnum1</c> function returns the next page of results from the IPsec security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaEnum1</c> is the specific implementation of IPsecSaEnum used in Windows 7 and later. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="enumHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an IPsec SA enumeration. Call IPsecSaCreateEnumHandle0 to obtain an enumeration handle.</para>
	/// </param>
	/// <param name="numEntriesRequested">
	/// <para>Type: <c>UINT32</c></para>
	/// <para>The number of enumeration entries requested.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_DETAILS1***</para>
	/// <para>Addresses of the enumeration entries.</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para><c>IPsecSaEnum1</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsaenum1 DWORD IPsecSaEnum1( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_DETAILS1 ***entries, [out] UINT32 *numEntriesReturned );
	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaEnum1")]
	public static extern Win32Error IPsecSaEnum1([In] HFWPENG engineHandle, [In] HANDLE enumHandle, uint numEntriesRequested,
		out SafeFwpmMem entries, out uint numEntriesReturned);

	/// <summary>
	/// <para>The <c>IPsecSaEnum1</c> function returns the next page of results from the IPsec security association (SA) enumerator.</para>
	/// <para>
	/// <c>Note</c><c>IPsecSaEnum1</c> is the specific implementation of IPsecSaEnum used in Windows 7 and later. See WFP Version-Independent
	/// Names and Targeting Specific Versions of Windows for more information. For Windows Vista, IPsecSaEnum0 is available.
	/// </para>
	/// </summary>
	/// <param name="engineHandle">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>Handle for an open session to the filter engine. Call FwpmEngineOpen0 to open a session to the filter engine.</para>
	/// </param>
	/// <param name="entries">
	/// <para>Type: IPSEC_SA_DETAILS1***</para>
	/// <para>Addresses of the enumeration entries.</para>
	/// </param>
	/// <param name="enumTemplate">
	/// <para>Type: IPSEC_SA_ENUM_TEMPLATE0*</para>
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
	/// <term>The SAs were enumerated successfully.</term>
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
	/// <para>If <c>enumTemplate</c> is <c>NULL</c>, all IPsec SA objects are returned.</para>
	/// <para><c>IPsecSaEnum1</c> works on a snapshot of the SAs taken at the time the enumeration handle was created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/fwpmu/nf-fwpmu-ipsecsaenum1 DWORD IPsecSaEnum1( [in] HFWPENG engineHandle, [in]
	// HANDLE enumHandle, [in] UINT32 numEntriesRequested, [out] IPSEC_SA_DETAILS1 ***entries, [out] UINT32 *numEntriesReturned );
	[PInvokeData("fwpmu.h", MSDNShortId = "NF:fwpmu.IPsecSaEnum1")]
	public static Win32Error IPsecSaEnum1([In] HFWPENG engineHandle, out SafeFwpmArray<IPSEC_SA_DETAILS1> entries, IPSEC_SA_ENUM_TEMPLATE0? enumTemplate) =>
		FwpmGenericEnum(IPsecSaCreateEnumHandle0, IPsecSaEnum1, IPsecSaDestroyEnumHandle0, engineHandle, out entries, enumTemplate);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmSubLayerGetByKey0([In] HFWPENG engineHandle, in Guid key, out SafeFwpmMem subLayer);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error FwpmSystemPortsGet0([In, Optional] HFWPENG engineHandle, out SafeFwpmMem sysPorts);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IkeextSaGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem sa);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IkeextSaGetById1([In] HFWPENG engineHandle, ulong id, [In, Optional] IntPtr saLookupContext, out SafeFwpmMem sa);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IkeextSaGetById2([In] HFWPENG engineHandle, ulong id, [In, Optional] IntPtr saLookupContext, out SafeFwpmMem sa);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IPsecKeyManagersGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IPsecSaContextGetById0([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem saContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IPsecSaContextGetById1([In] HFWPENG engineHandle, ulong id, out SafeFwpmMem saContext);

	[DllImport(Lib_Fwpuclnt, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error IPsecSaContextSubscriptionsGet0([In] HFWPENG engineHandle, out SafeFwpmMem entries, out uint numEntries);
}