namespace Vanara.PInvoke;

public static partial class NdfApi
{
	/// <summary/>
	[PInvokeData("ndhelper.h", MSDNShortId = "NS:ndhelper.tagDiagnosticsInfo")]
	[Flags]
	public enum DF : uint
	{
		/// <summary/>
		DF_IMPERSONATION = 0x80000000,

		/// <summary/>
		DF_TRACELESS = 0x40000000,
	}

	/// <summary>
	/// The <c>DIAGNOSIS_STATUS</c> enumeration describes the result of a hypothesis submitted to a helper class in which the health of a
	/// component has been determined.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ne-ndhelper-diagnosis_status typedef enum tagDIAGNOSIS_STATUS {
	// DS_NOT_IMPLEMENTED = 0, DS_CONFIRMED, DS_REJECTED, DS_INDETERMINATE, DS_DEFERRED, DS_PASSTHROUGH } DIAGNOSIS_STATUS;
	[PInvokeData("ndhelper.h", MSDNShortId = "NE:ndhelper.tagDIAGNOSIS_STATUS")]
	public enum DIAGNOSIS_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>A helper class is not implemented</para>
		/// </summary>
		DS_NOT_IMPLEMENTED,

		/// <summary>The helper class has confirmed a problem existing in its component.</summary>
		DS_CONFIRMED,

		/// <summary>The helper class has determined that no problem exists.</summary>
		DS_REJECTED,

		/// <summary>The helper class is unable to determine whether there is a problem.</summary>
		DS_INDETERMINATE,

		/// <summary>The helper class is unable to perform the diagnosis at this time.</summary>
		DS_DEFERRED,

		/// <summary>
		/// <para>The helper class has identified hypotheses to investigate further, but did not identify any problems in its own component.</para>
		/// <para>Equivalent to</para>
		/// <para>DS_INDETERMINATE</para>
		/// <para>, but is later updated to</para>
		/// <para>DS_REJECTED</para>
		/// <para>if no hypothesis is confirmed.</para>
		/// <para><c>Note</c> Available only in Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		DS_PASSTHROUGH,
	}

	/// <summary>The <c>PROBLEM_TYPE</c> enumeration describes the type of problem a helper class indicates is present.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ne-ndhelper-problem_type typedef enum tagPROBLEM_TYPE { PT_INVALID = 0,
	// PT_LOW_HEALTH = 1, PT_LOWER_HEALTH = 2, PT_DOWN_STREAM_HEALTH = 4, PT_HIGH_UTILIZATION = 8, PT_HIGHER_UTILIZATION = 16,
	// PT_UP_STREAM_UTILIZATION = 32 } PROBLEM_TYPE;
	[PInvokeData("ndhelper.h", MSDNShortId = "NE:ndhelper.tagPROBLEM_TYPE")]
	[Flags]
	public enum PROBLEM_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// </summary>
		PT_INVALID = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// A low-health problem exists within the component itself. No problems were found within local components on which this component depends.
		/// </para>
		/// </summary>
		PT_LOW_HEALTH = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>A low-health problem exists within local components on which this component depends.</para>
		/// </summary>
		PT_LOWER_HEALTH = 2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The low-health problem is in the out-of-box components this component depends on.</para>
		/// </summary>
		PT_DOWN_STREAM_HEALTH = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>
		/// The component's resource is being highly utilized. No high utilization was found within local components on which this component depends.
		/// </para>
		/// </summary>
		PT_HIGH_UTILIZATION = 8,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>The causes of the component's high-utilization problem are from local components that depend on it.</para>
		/// </summary>
		PT_HIGHER_UTILIZATION = 16,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// <para>The causes of the component's high-utilization problem are from upstream network components that depend on it.</para>
		/// </summary>
		PT_UP_STREAM_UTILIZATION = 32,
	}

	/// <summary>The <c>REPAIR_STATUS</c> enumeration describes the result of a helper class attempting a repair option.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ne-ndhelper-repair_status typedef enum tagREPAIR_STATUS {
	// RS_NOT_IMPLEMENTED = 0, RS_REPAIRED, RS_UNREPAIRED, RS_DEFERRED, RS_USER_ACTION } REPAIR_STATUS;
	[PInvokeData("ndhelper.h", MSDNShortId = "NE:ndhelper.tagREPAIR_STATUS")]
	public enum REPAIR_STATUS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The helper class does not have a repair option implemented.</para>
		/// </summary>
		RS_NOT_IMPLEMENTED,

		/// <summary>The helper class has repaired a problem.</summary>
		RS_REPAIRED,

		/// <summary>The helper class has attempted to repair a problem but validation indicates the repair operation has not succeeded.</summary>
		RS_UNREPAIRED,

		/// <summary>The helper class is unable to perform the repair at this time.</summary>
		RS_DEFERRED,

		/// <summary>The helper class needs the user to perform an action before the repair can continue.</summary>
		RS_USER_ACTION,
	}

	/// <summary>interface implemented by Extensible Helper Class</summary>
	[ComImport, Guid("c0b35748-ebf5-11d8-bbe9-505054503030"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INetDiagExtensibleHelper
	{
		/// <summary/>
		/// <param name="celt"></param>
		/// <param name="rgKeyAttributes"></param>
		/// <param name="pcelt"></param>
		/// <param name="prgMatchValues"></param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT ResolveAttributes([In] uint celt, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HELPER_ATTRIBUTE[] rgKeyAttributes,
			out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out HELPER_ATTRIBUTE[]? prgMatchValues);
	}

	/// <summary>
	/// The <c>INetDiagHelper</c> interface provides methods that capture and provide information associated with diagnoses and resolution of
	/// network-related issues.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nn-ndhelper-inetdiaghelper
	[PInvokeData("ndhelper.h", MSDNShortId = "NN:ndhelper.INetDiagHelper")]
	[ComImport, Guid("c0b35746-ebf5-11d8-bbe9-505054503030"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INetDiagHelper
	{
		/// <summary>
		/// The <c>Initialize</c> method passes in attributes to the Helper Class Extension from the hypothesis. The helper class should
		/// store these parameters for use in the main diagnostics functions. This method must be called before any diagnostics function.
		/// </summary>
		/// <param name="celt">A pointer to a count of elements in <c>HELPER_ATTRIBUTE</c> array.</param>
		/// <param name="rgAttributes">A reference to the HELPER_ATTRIBUTE array.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>The Initialize method is required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-initialize HRESULT Initialize( [in] ULONG
		// celt, HELPER_ATTRIBUTE [] rgAttributes );
		[PreserveSig]
		HRESULT Initialize([In] uint celt, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HELPER_ATTRIBUTE[] rgAttributes);

		/// <summary>
		/// The <c>GetDiagnosticsInfo</c> method enables the Helper Class Extension instance to provide an estimate of how long the diagnosis
		/// may take.
		/// </summary>
		/// <param name="ppInfo">A pointer to a pointer to a DiagnosticsInfo structure.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>The GetDiagnosticsInfo method is required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getdiagnosticsinfo HRESULT
		// GetDiagnosticsInfo( [out] DiagnosticsInfo **ppInfo );
		[PreserveSig]
		unsafe HRESULT GetDiagnosticsInfo(out DiagnosticsInfo* ppInfo);

		/// <summary>The <c>GetKeyAttributes</c> method retrieves the key attributes of the Helper Class Extension.</summary>
		/// <param name="pcelt">A pointer to a count of elements in the <c>HELPER_ATTRIBUTE</c> array.</param>
		/// <param name="pprgAttributes">A pointer to an array of HELPER_ATTRIBUTE structures.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getkeyattributes HRESULT GetKeyAttributes(
		// [out] ULONG *pcelt, [out] HELPER_ATTRIBUTE **pprgAttributes );
		[PreserveSig]
		HRESULT GetKeyAttributes(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HELPER_ATTRIBUTE[]? pprgAttributes);

		/// <summary>
		/// The <c>LowHealth</c> method enables the Helper Class Extension to check whether the component being diagnosed is healthy.
		/// </summary>
		/// <param name="pwszInstanceDescription">
		/// A pointer to a null-terminated string containing the user-friendly description of the information being diagnosed. For example,
		/// if a class were to diagnosis a connectivity issue with an IP address, the <c>pwszInstanceDescription</c> parameter would contain
		/// the host name.
		/// </param>
		/// <param name="ppwszDescription">
		/// A pointer to a null-terminated string containing the description of the issue found if the component is found to be unhealthy.
		/// </param>
		/// <param name="pDeferredTime">
		/// A pointer to the time, in seconds, to be deferred if the diagnosis cannot be started immediately. This is used when the
		/// <c>pStatus</c> parameter is set to <c>DS_DEFERRED</c>.
		/// </param>
		/// <param name="pStatus">A pointer to the DIAGNOSIS_STATUS that is returned from the diagnosis.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>
		/// <para>The LowHealth method is required when building a Helper Class Extension.</para>
		/// <para>
		/// If LowHealth returns <c>DS_CONFIRMED</c>, <c>ppwszDescription</c> will also contain a user-friendly description of the diagnosis
		/// result. The out parameter <c>pDeferredTime</c> contains the number of seconds this diagnosis needs to be deferred if pStatus
		/// returns <c>DS_DEFERRED</c>.
		/// </para>
		/// <para>
		/// When LowHealth is confirmed, it may also optionally generate hypotheses in the GetLowerHypotheses method for other helper classes
		/// if the problem may be caused by other components. If not confirmed, NDF may further diagnose the problem by calling HighUtilization.
		/// </para>
		/// <para>
		/// LowHealth may also return <c>DS_INDETERMINATE</c> if it is unable to diagnose the problem, but cannot confirm that the component
		/// is healthy. In this case, NDF will treat it as <c>DS_CONFIRMED</c> if none of the other hypotheses are confirmed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-lowhealth HRESULT LowHealth( [in] LPCWSTR
		// pwszInstanceDescription, [out] LPWSTR *ppwszDescription, [out] long *pDeferredTime, [out] DIAGNOSIS_STATUS *pStatus );
		[PreserveSig]
		HRESULT LowHealth([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszInstanceDescription,
			[MarshalAs(UnmanagedType.LPWStr)] out string? ppwszDescription, out long pDeferredTime, out DIAGNOSIS_STATUS pStatus);

		/// <summary>
		/// The <c>HighUtilization</c> method enables the Helper Class Extension to check whether the corresponding component is highly utilized.
		/// </summary>
		/// <param name="pwszInstanceDescription">
		/// A pointer to a null-terminated string containing the user-friendly description of the information being diagnosed. For example,
		/// if a class were to diagnosis a connectivity issue with an IP address, the <c>pwszInstanceDescription</c> parameter would contain
		/// the host name.
		/// </param>
		/// <param name="ppwszDescription">
		/// A pointer to a null-terminated string containing the description of high utilization diagnosis result.
		/// </param>
		/// <param name="pDeferredTime">
		/// A pointer to the time, in seconds, to be deferred if the diagnosis cannot be started immediately. This is used when the
		/// <c>pStatus</c> parameter is set to <c>DS_DEFERRED</c>.
		/// </param>
		/// <param name="pStatus">A pointer to the DIAGNOSIS_STATUS that is returned from the diagnosis.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-highutilization HRESULT HighUtilization(
		// [in] LPCWSTR pwszInstanceDescription, [out] LPWSTR *ppwszDescription, [out] long *pDeferredTime, [out] DIAGNOSIS_STATUS *pStatus );
		[PreserveSig]
		HRESULT HighUtilization([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszInstanceDescription,
			[MarshalAs(UnmanagedType.LPWStr)] out string? ppwszDescription, out long pDeferredTime, out DIAGNOSIS_STATUS pStatus);

		/// <summary>
		/// The <c>GetLowerHypotheses</c> method asks the Helper Class Extension to generate hypotheses for possible causes of low health in
		/// the local components that depend on it.
		/// </summary>
		/// <param name="pcelt">A pointer to a count of elements in the <c>HYPOTHESIS</c> array.</param>
		/// <param name="pprgHypotheses">A pointer to a HYPOTHESIS array.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getlowerhypotheses HRESULT
		// GetLowerHypotheses( [out] ULONG *pcelt, [out] HYPOTHESIS **pprgHypotheses );
		[PreserveSig]
		HRESULT GetLowerHypotheses(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HYPOTHESIS[]? pprgHypotheses);

		/// <summary>
		/// The <c>GetDownStreamHypotheses</c> method asks the Helper Class Extension to generate hypotheses for possible causes of low
		/// health in the downstream network components it depends on.
		/// </summary>
		/// <param name="pcelt">A pointer to a count of elements in the HYPOTHESIS array.</param>
		/// <param name="pprgHypotheses">A pointer to an array of HYPOTHESIS structures.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getdownstreamhypotheses HRESULT
		// GetDownStreamHypotheses( [out] ULONG *pcelt, [out] HYPOTHESIS **pprgHypotheses );
		[PreserveSig]
		HRESULT GetDownStreamHypotheses(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HYPOTHESIS[]? pprgHypotheses);

		/// <summary>
		/// The <c>GetHigherHypotheses</c> method asks the Helper Class Extension to generate hypotheses for possible causes of high
		/// utilization in the local components that depend on it.
		/// </summary>
		/// <param name="pcelt">A pointer to a count of elements in the HYPOTHESIS array.</param>
		/// <param name="pprgHypotheses">A pointer to an array of HYPOTHESIS structures.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-gethigherhypotheses HRESULT
		// GetHigherHypotheses( [out] ULONG *pcelt, [out] HYPOTHESIS **pprgHypotheses );
		[PreserveSig]
		HRESULT GetHigherHypotheses(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HYPOTHESIS[]? pprgHypotheses);

		/// <summary>
		/// The <c>GetUpStreamHypotheses</c> method asks the Helper Class Extension to generate hypotheses for possible causes of high
		/// utilization in the upstream network components that depend on it.
		/// </summary>
		/// <param name="pcelt">A pointer to a count of elements in the <c>HYPOTHESIS</c> array.</param>
		/// <param name="pprgHypotheses">A pointer to a HYPOTHESIS array.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getupstreamhypotheses HRESULT
		// GetUpStreamHypotheses( [out] ULONG *pcelt, [out] HYPOTHESIS **pprgHypotheses );
		[PreserveSig]
		HRESULT GetUpStreamHypotheses(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HYPOTHESIS[]? pprgHypotheses);

		/// <summary>The <c>Repair</c> method performs a repair specified by the input parameter.</summary>
		/// <param name="pInfo">A pointer to a RepairInfo structure.</param>
		/// <param name="pDeferredTime">
		/// A pointer to the time, in seconds, to be deferred if the repair cannot be started immediately. This is only valid when the
		/// pStatus parameter is set to <c>DS_DEFERRED</c>.
		/// </param>
		/// <param name="pStatus">A pointer to the REPAIR_STATUS that is returned from the repair.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-repair HRESULT Repair( [in] RepairInfo
		// *pInfo, [out] long *pDeferredTime, [out] REPAIR_STATUS *pStatus );
		[PreserveSig]
		HRESULT Repair(in RepairInfo pInfo, out long pDeferredTime, out REPAIR_STATUS pStatus);

		/// <summary>
		/// The <c>Validate</c> method is called by NDF after a repair is successfully completed in order to validate that a previously
		/// diagnosed problem has been fixed.
		/// </summary>
		/// <param name="problem">The PROBLEM_TYPE that the helper class has previously diagnosed.</param>
		/// <param name="pDeferredTime">
		/// A pointer to the time to be deferred, in seconds, if the diagnosis cannot be started immediately. This is used only when the
		/// pStatus member is set to <c>DS_DEFERRED</c>.
		/// </param>
		/// <param name="pStatus">A pointer to the DIAGNOSIS_STATUS that is returned from the diagnosis.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is not required when building a Helper Class Extension.</para>
		/// <para>
		/// This method only returns an error code if it encounters failures that impede validation. If necessary, the <c>pStatus</c>
		/// parameter is the expected way to communicate that the component is still in low health. <c>DS_REJECTED</c> is used to indicate
		/// that the issue has been resolved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-validate HRESULT Validate( [in]
		// PROBLEM_TYPE problem, [out] long *pDeferredTime, [out] REPAIR_STATUS *pStatus );
		[PreserveSig]
		HRESULT Validate([In] PROBLEM_TYPE problem, out long pDeferredTime, out REPAIR_STATUS pStatus);

		/// <summary>
		/// The <c>GetRepairInfo</c> method retrieves the repair information that the Helper Class Extension has for a given problem type.
		/// </summary>
		/// <param name="problem">A PROBLEM_TYPE value that specifies the problem type that the helper class has previously diagnosed.</param>
		/// <param name="pcelt">A pointer to a count of elements in the <c>RepairInfo</c> array.</param>
		/// <param name="ppInfo">A pointer to an array of RepairInfo structures.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getrepairinfo HRESULT GetRepairInfo( [in]
		// PROBLEM_TYPE problem, [out] ULONG *pcelt, [out] RepairInfo **ppInfo );
		[PreserveSig]
		HRESULT GetRepairInfo([In] PROBLEM_TYPE problem, out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out RepairInfo[]? ppInfo);

		/// <summary>The <c>GetLifeTime</c> method retrieves the lifetime of the Helper Class Extension instance.</summary>
		/// <param name="pLifeTime">A pointer to a LIFE_TIME structure.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is not required when building a Helper Class Extension.</para>
		/// <para>
		/// Lifetime data is used to limit the time scope of a problem instance. This is particularly useful when doing history-based
		/// diagnoses such as tracing and logging where it can be used in scoping down the diagnosis to events that occurred during the
		/// specified time interval.
		/// </para>
		/// <para>
		/// For example, Windows Filtering Platform (WFP) helper classes use lifetime to determine which filter blocked a packet by checking
		/// the trace log. By default, a lifetime of a helper class instance inherits the lifetime of its dependent helper class instance.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getlifetime HRESULT GetLifeTime( [out]
		// LIFE_TIME *pLifeTime );
		[PreserveSig]
		HRESULT GetLifeTime(out LIFE_TIME pLifeTime);

		/// <summary>
		/// The <c>SetLifeTime</c> method is called by NDF to set the start and end time of interest to diagnostics so that the Helper Class
		/// Extension can limit its diagnosis to events within that time period.
		/// </summary>
		/// <param name="lifeTime">A LIFE_TIME structure.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-setlifetime HRESULT SetLifeTime( [in]
		// LIFE_TIME lifeTime );
		[PreserveSig]
		HRESULT SetLifeTime([In] LIFE_TIME lifeTime);

		/// <summary>The <c>GetCacheTime</c> method specifies the time when cached results of a diagnosis and repair operation have expired.</summary>
		/// <param name="pCacheTime">A pointer to a FILETIME structure.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is not required when building a Helper Class Extension.</para>
		/// <para>
		/// The default behavior is to return the current time so that the results will not be cached. Setting a cache time can increase
		/// diagnosis efficiency since NDF will not call on the extension to re-diagnose an issue unless the cache time has expired.
		/// </para>
		/// <para>
		/// The <c>FILETIME</c> structure is a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getcachetime HRESULT GetCacheTime( [out]
		// FILETIME *pCacheTime );
		[PreserveSig]
		HRESULT GetCacheTime(out FILETIME pCacheTime);

		/// <summary>
		/// The <c>GetAttributes</c> method retrieves additional information about a problem that the helper class extension has diagnosed.
		/// </summary>
		/// <param name="pcelt">A pointer to a count of elements in the <c>HELPER_ATTRIBUTE</c> array.</param>
		/// <param name="pprgAttributes">A pointer to an array of HELPER_ATTRIBUTE structures.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_NOTIMPL</c></term>
		/// <term>This optional method is not implemented.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is not required when building a Helper Class Extension.</para>
		/// <para>
		/// During the process of diagnosis and repair, a helper class may optionally return attributes to NDF that improve NDF's handling of
		/// the diagnosis. The predefined attributes that can be returned to NDF are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>werperameter (Type: AT_UINT32)</term>
		/// <term>
		/// When diagnosis fails, an optional attribute for additional helper class specific Windows Error Reporting (WER) bucketing parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>werfile (Type: AT_STRING)</term>
		/// <term>An optional attribute for adding helper class-specific files to Windows Error Reporting (WER) reports.</term>
		/// </item>
		/// <item>
		/// <term>rootcauseid (Type: AT_GUID)</term>
		/// <term>
		/// Helper Classes can often diagnose more than one problem at once. Analysis of the problem encountered can be improved in NDF if
		/// the extension returns a HelperAttribute of type AT_GUID with the pszName parameter set to rootcauseid and the Guid field set to a
		/// GUID identifying the specific problem encountered. These GUIDs are custom defined by the helper extension.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-getattributes HRESULT GetAttributes( [out]
		// ULONG *pcelt, [out] HELPER_ATTRIBUTE **pprgAttributes );
		[PreserveSig]
		HRESULT GetAttributes(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HELPER_ATTRIBUTE[]? pprgAttributes);

		/// <summary>The <c>Cancel</c> method cancels an ongoing diagnosis or repair.</summary>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>The <c>Cancel</c> method is required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-cancel HRESULT Cancel();
		[PreserveSig]
		HRESULT Cancel();

		/// <summary>
		/// The <c>Cleanup</c> method allows the Helper Class Extension to clean up resources following a diagnosis or repair operation.
		/// </summary>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ABORT</c></term>
		/// <term>The diagnosis or repair operation has been canceled.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the failures encountered in the function.</para>
		/// </returns>
		/// <remarks>The <c>Cleanup</c> method is required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelper-cleanup HRESULT Cleanup();
		[PreserveSig]
		HRESULT Cleanup();
	}

	/// <summary>
	/// The <c>INetDiagHelperEx</c> interface provides methods that extend on the INetDiagHelper interface to capture and provide information
	/// associated with diagnoses and resolution of network-related issues.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nn-ndhelper-inetdiaghelperex
	[PInvokeData("ndhelper.h", MSDNShortId = "NN:ndhelper.INetDiagHelperEx")]
	[ComImport, Guid("972DAB4D-E4E3-4fc6-AE54-5F65CCDE4A15"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INetDiagHelperEx
	{
		/// <summary>
		/// The <c>ReconfirmLowHealth</c> method is used to add a second Low Health pass after hypotheses have been diagnosed and before
		/// repairs are retrieved. This method allows the helper class to see the diagnostics results and to change the diagnosis if needed.
		/// The method is only called if a diagnosis is not rejected and hypotheses were generated.
		/// </summary>
		/// <param name="celt">The number of HypothesisResult structures pointed to by <c>pResults</c>.</param>
		/// <param name="pResults">
		/// Pointer to HypothesisResult structure(s) containing the HYPOTHESIS information obtained via the GetLowerHypotheses method along
		/// with the status of that hypothesis. Includes one <c>HypothesisResult</c> structure for each hypothesis generated by the helper
		/// class's call to <c>GetLowerHypotheses</c>.
		/// </param>
		/// <param name="ppwszUpdatedDescription">An updated description of the incident being diagnosed.</param>
		/// <param name="pUpdatedStatus">A DIAGNOSIS_STATUS value which indicates the status of the incident.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// </list>
		/// <para>Any result other than S_OK will be interpreted as an error and will cause the function results to be discarded.</para>
		/// </returns>
		/// <remarks>This method is not required when building a Helper Class Extension.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelperex-reconfirmlowhealth HRESULT
		// ReconfirmLowHealth( [in] ULONG celt, [in] HypothesisResult *pResults, [out] LPWSTR *ppwszUpdatedDescription, [out]
		// DIAGNOSIS_STATUS *pUpdatedStatus );
		[PreserveSig]
		HRESULT ReconfirmLowHealth([In] uint celt, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HypothesisResult[] pResults,
			[MarshalAs(UnmanagedType.LPWStr)] out string ppwszUpdatedDescription, out DIAGNOSIS_STATUS pUpdatedStatus);

		/// <summary>
		/// The <c>SetUtilities</c> method is used by the Network Diagnostics Framework (NDF). This method is reserved for system use.
		/// </summary>
		/// <param name="pUtilities">Reserved for system use.</param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>This method is reserved for system use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelperex-setutilities HRESULT SetUtilities( [in]
		// INetDiagHelperUtilFactory *pUtilities );
		[PreserveSig]
		HRESULT SetUtilities([In] INetDiagHelperUtilFactory pUtilities);

		/// <summary>
		/// The <c>ReproduceFailure</c> method is used by the Network Diagnostics Framework (NDF). This method is reserved for system use.
		/// </summary>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>This method is reserved for system use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelperex-reproducefailure HRESULT ReproduceFailure();
		[PreserveSig]
		HRESULT ReproduceFailure();
	}

	/// <summary>
	/// The <c>INetDiagHelperInfo</c> interface provides a method that is called by the Network Diagnostics Framework (NDF) when it needs to
	/// validate that it has the necessary information for a helper class and that it has chosen the correct helper class.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nn-ndhelper-inetdiaghelperinfo
	[PInvokeData("ndhelper.h", MSDNShortId = "NN:ndhelper.INetDiagHelperInfo")]
	[ComImport, Guid("c0b35747-ebf5-11d8-bbe9-505054503030"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INetDiagHelperInfo
	{
		/// <summary>The <c>GetAttributeInfo</c> method retrieves the list of key parameters needed by the Helper Class Extension.</summary>
		/// <param name="pcelt">A pointer to a count of elements in the array pointed to by <c>pprgAttributeInfos</c>.</param>
		/// <param name="pprgAttributeInfos">A pointer to an array of HelperAttributeInfo structures that contain helper class key parameters.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term><c>S_OK</c></term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term><c>E_OUTOFMEMORY</c></term>
		/// <term>There is not enough memory available to complete this operation.</term>
		/// </item>
		/// <item>
		/// <term><c>E_INVALIDARG</c></term>
		/// <term>One or more parameters has not been provided correctly.</term>
		/// </item>
		/// <item>
		/// <term><c>E_ACCESSDENIED</c></term>
		/// <term>The caller does not have sufficient privileges to perform the diagnosis or repair operation.</term>
		/// </item>
		/// </list>
		/// <para>Helper Class Extensions may return HRESULTS that are specific to the diagnoses or repairs.</para>
		/// </returns>
		/// <remarks>
		/// The key parameter list is used by NDF to determine whether enough information is available for the extension to perform
		/// diagnosis. If the hypothesis to call the extension lacks a key attribute, the extension will not be called. Optional attributes
		/// will not be returned by this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelperinfo-getattributeinfo HRESULT
		// GetAttributeInfo( [out] ULONG *pcelt, [out] HelperAttributeInfo **pprgAttributeInfos );
		[PreserveSig]
		HRESULT GetAttributeInfo(out uint pcelt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out HelperAttributeInfo[]? pprgAttributeInfos);
	}

	/// <summary>
	/// The <c>INetDiagHelperUtilFactory</c> interface provides a reserved method that is used by the Network Diagnostics Framework (NDF).
	/// This interface is reserved for system use.
	/// </summary>
	/// <remarks>This interface is reserved for system use.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nn-ndhelper-inetdiaghelperutilfactory
	[PInvokeData("ndhelper.h", MSDNShortId = "NN:ndhelper.INetDiagHelperUtilFactory")]
	[ComImport, Guid("104613FB-BC57-4178-95BA-88809698354A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INetDiagHelperUtilFactory
	{
		/// <summary>
		/// The CreateUtilityInstance method is used by the Network Diagnostics Framework (NDF). This method is reserved for system use.
		/// </summary>
		/// <param name="riid">Reserved for system use.</param>
		/// <param name="ppvObject">Reserved for system use.</param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>This method is reserved for system use.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/nf-ndhelper-inetdiaghelperutilfactory-createutilityinstance HRESULT
		// CreateUtilityInstance( [in] REFIID riid, [out] void **ppvObject );
		[PreserveSig]
		HRESULT CreateUtilityInstance(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvObject);
	}

	/// <summary>The <c>DiagnosticsInfo</c> structure contains the estimate of diagnosis time, and flags for invocation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ns-ndhelper-diagnosticsinfo typedef struct tagDiagnosticsInfo { long cost;
	// ULONG flags; } DiagnosticsInfo, *PDiagnosticsInfo;
	[PInvokeData("ndhelper.h", MSDNShortId = "NS:ndhelper.tagDiagnosticsInfo")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DiagnosticsInfo
	{
		/// <summary>
		/// <para>Type: <c>long</c></para>
		/// <para>
		/// The length of time, in seconds, that the diagnosis should take to complete. A value of zero or a negative value means the cost is
		/// negligible. Any positive value will cause the engine to adjust the overall diagnostics process.
		/// </para>
		/// </summary>
		public long cost;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved.</para>
		/// </summary>
		public DF flags;
	}

	/// <summary>The <c>HelperAttributeInfo</c> structure contains the name of the helper attribute and its type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ns-ndhelper-helperattributeinfo typedef struct tagHelperAttributeInfo {
	// LPWSTR pwszName; ATTRIBUTE_TYPE type; } HelperAttributeInfo, *PHelperAttributeInfo;
	[PInvokeData("ndhelper.h", MSDNShortId = "NS:ndhelper.tagHelperAttributeInfo")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HelperAttributeInfo
	{
		/// <summary>
		/// <para>Type: <c>[string] LPWSTR</c></para>
		/// <para>Pointer to a null-terminated string that contains the name of the helper attribute.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszName;

		/// <summary>
		/// <para>Type: <c>ATTRIBUTE_TYPE</c></para>
		/// <para>The type of helper attribute.</para>
		/// </summary>
		public ATTRIBUTE_TYPE type;
	}

	/// <summary>
	/// The <c>HYPOTHESIS</c> structure contains data used to submit a hypothesis to NDF for another helper class. The name of the helper
	/// class, the number of parameters that the helper class requires, and the parameters to pass to the helper class are contained in this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ns-ndhelper-hypothesis typedef struct tagHYPOTHESIS { LPWSTR
	// pwszClassName; LPWSTR pwszDescription; ULONG celt; PHELPER_ATTRIBUTE rgAttributes; } HYPOTHESIS, *PHYPOTHESIS;
	[PInvokeData("ndhelper.h", MSDNShortId = "NS:ndhelper.tagHYPOTHESIS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HYPOTHESIS
	{
		/// <summary>
		/// <para>Type: <c>[string] LPWSTR</c></para>
		/// <para>A pointer to a null-terminated string that contains the name of the helper class.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszClassName;

		/// <summary>
		/// <para>Type: <c>[string] LPWSTR</c></para>
		/// <para>
		/// A pointer to a null-terminated string that contains a user-friendly description of the data being passed to the helper class..
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszDescription;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The count of attributes in this hypothesis.</para>
		/// </summary>
		public uint celt;

		/// <summary>
		/// <para>Type: <c>[size_is(celt)]PHELPER_ATTRIBUTE[ ]</c></para>
		/// <para>A pointer to an array of HELPER_ATTRIBUTE structures that contains key attributes for this hypothesis.</para>
		/// </summary>
		public IntPtr rgAttributes;
	}

	/// <summary>
	/// The <c>HypothesisResult</c> structure contains information about a hypothesis returned from a helper class. The hypothesis is
	/// obtained via a call to GetLowerHypotheses.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndhelper/ns-ndhelper-hypothesisresult typedef struct tagHypothesisResult {
	// HYPOTHESIS hypothesis; DIAGNOSIS_STATUS pathStatus; } HypothesisResult;
	[PInvokeData("ndhelper.h", MSDNShortId = "NS:ndhelper.tagHypothesisResult")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HypothesisResult
	{
		/// <summary>
		/// <para>Type: <c>HYPOTHESIS</c></para>
		/// <para>Information for a specific hypothesis.</para>
		/// </summary>
		public HYPOTHESIS hypothesis;

		/// <summary>
		/// <para>Type: <c>DIAGNOSIS_STATUS</c></para>
		/// <para>The status of the child helper class and its children.</para>
		/// <para>
		/// If the hypothesis or any of its children indicated <c>DS_CONFIRMED</c> in a call to LowHealth, then this value will be
		/// <c>DS_CONFIRMED</c>. If no problems exist in such a call, the value will be <c>DS_REJECTED</c>. The value will be
		/// <c>DS_INDETERMINATE</c> if the health of the component is not clear.
		/// </para>
		/// </summary>
		public DIAGNOSIS_STATUS pathStatus;
	}
}