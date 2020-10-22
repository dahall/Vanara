using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Specifies options for the RoGetAgileReference function.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/ne-combaseapi-agilereferenceoptions typedef enum
		// AgileReferenceOptions { AGILEREFERENCE_DEFAULT, AGILEREFERENCE_DELAYEDMARSHAL } ;
		[PInvokeData("combaseapi.h", MSDNShortId = "F46FD597-F278-4DA8-BC94-26836684AD7E")]
		public enum AgileReferenceOptions
		{
			/// <summary>
			/// Use the default marshaling behavior, which is to marshal interfaces when an agile reference to the interface is obtained.
			/// </summary>
			AGILEREFERENCE_DEFAULT,

			/// <summary>
			/// Marshaling happens on demand. Use this option only in situations where it's known that an object is only resolved from the
			/// same apartment in which it was registered.
			/// </summary>
			AGILEREFERENCE_DELAYEDMARSHAL
		}

		/// <summary>
		/// <para>Specifies the behavior of the CoWaitForMultipleHandles function.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/ne-combaseapi-tagcowait_flags typedef enum tagCOWAIT_FLAGS {
		// COWAIT_DEFAULT, COWAIT_WAITALL, COWAIT_ALERTABLE, COWAIT_INPUTAVAILABLE, COWAIT_DISPATCH_CALLS, COWAIT_DISPATCH_WINDOW_MESSAGES } COWAIT_FLAGS;
		[PInvokeData("combaseapi.h", MSDNShortId = "e6f8300c-f74b-4383-8ee5-519a0ed0b358")]
		[Flags]
		public enum COWAIT_FLAGS
		{
			/// <summary>Dispatch calls needed for marshaling without dispatching arbitrary calls.</summary>
			COWAIT_DEFAULT = 0,

			/// <summary>
			/// If set, the call to CoWaitForMultipleHandles will return S_OK only when all handles associated with the synchronization
			/// object have been signaled and an input event has been received, all at the same time. In this case, the behavior of
			/// CoWaitForMultipleHandles corresponds to the behavior of the MsgWaitForMultipleObjectsEx function with the dwFlags parameter
			/// set to MWMO_WAITALL. If COWAIT_WAITALL is not set, the call to CoWaitForMultipleHandles will return S_OK as soon as any
			/// handle associated with the synchronization object has been signaled, regardless of whether an input event is received.
			/// </summary>
			COWAIT_WAITALL = 1,

			/// <summary>
			/// If set, the call to CoWaitForMultipleHandles will return S_OK if an asynchronous procedure call (APC) has been queued to the
			/// calling thread with a call to the QueueUserAPC function, even if no handle has been signaled.
			/// </summary>
			COWAIT_ALERTABLE = 2,

			/// <summary>
			/// If set, the call to CoWaitForMultipleHandles will return S_OK if input exists for the queue, even if the input has been seen
			/// (but not removed) using a call to another function, such as PeekMessage.
			/// </summary>
			COWAIT_INPUTAVAILABLE = 4,

			/// <summary>
			/// Dispatch calls from CoWaitForMultipleHandles in an ASTA. Default is no call dispatch. This value has no meaning in other
			/// apartment types and is ignored.
			/// </summary>
			COWAIT_DISPATCH_CALLS = 8,

			/// <summary>
			/// Enables dispatch of window messages from CoWaitForMultipleHandles in an ASTA or STA. Default in ASTA is no window messages
			/// dispatched, default in STA is only a small set of special-cased messages dispatched. The value has no meaning in MTA and is ignored.
			/// </summary>
			COWAIT_DISPATCH_WINDOW_MESSAGES = 0x10,
		}

		/// <summary>Provides flags for the CoWaitForMultipleObjects function.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/ne-combaseapi-cwmo_flags typedef enum CWMO_FLAGS { CWMO_DEFAULT,
		// CWMO_DISPATCH_CALLS, CWMO_DISPATCH_WINDOW_MESSAGES } ;
		[PInvokeData("combaseapi.h", MSDNShortId = "5FE605A9-DE92-4CD9-9390-6C9F5189A7CB")]
		[Flags]
		public enum CWMO_FLAGS
		{
			/// <summary>No call dispatch.</summary>
			CWMO_DEFAULT = 0,

			/// <summary>Dispatch calls from CoWaitForMultipleObjects (default is no call dispatch).</summary>
			CWMO_DISPATCH_CALLS = 1,

			/// <summary/>
			CWMO_DISPATCH_WINDOW_MESSAGES = 2,
		}

		/// <summary>
		/// <para>Controls the type of connections to a class object.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// In CoRegisterClassObject, members of both the <c>REGCLS</c> and the CLSCTX enumerations, taken together, determine how the class
		/// object is registered.
		/// </para>
		/// <para>
		/// An EXE surrogate (in which DLL servers are run) calls CoRegisterClassObject to register a class factory using a new <c>REGCLS</c>
		/// value, REGCLS_SURROGATE.
		/// </para>
		/// <para>
		/// All class factories for DLL surrogates should be registered with REGCLS_SURROGATE set. Do not set REGCLS_SINGLUSE or
		/// REGCLS_MULTIPLEUSE when you register a surrogate for DLL servers.
		/// </para>
		/// <para>
		/// The following table summarizes the allowable <c>REGCLS</c> value combinations and the object registrations affected by the combinations.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term/>
		/// <term>REGCLS_SINGLEUSE</term>
		/// <term>REGCLS_MULTIPLEUSE</term>
		/// <term>REGCLS_MULTI_SEPARATE</term>
		/// <term>Other</term>
		/// </listheader>
		/// <item>
		/// <term>CLSCTX_INPROC_SERVER</term>
		/// <term>Error</term>
		/// <term>In-process</term>
		/// <term>In-process</term>
		/// <term>Error</term>
		/// </item>
		/// <item>
		/// <term>CLSCTX_LOCAL_SERVER</term>
		/// <term>Local</term>
		/// <term>In-process/local</term>
		/// <term>Local</term>
		/// <term>Error</term>
		/// </item>
		/// <item>
		/// <term>Both of the above</term>
		/// <term>Error</term>
		/// <term>In-process/local</term>
		/// <term>In-process/local</term>
		/// <term>Error</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Error</term>
		/// <term>Error</term>
		/// <term>Error</term>
		/// <term>Error</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/ne-combaseapi-tagregcls typedef enum tagREGCLS { REGCLS_SINGLEUSE,
		// REGCLS_MULTIPLEUSE, REGCLS_MULTI_SEPARATE, REGCLS_SUSPENDED, REGCLS_SURROGATE, REGCLS_AGILE } REGCLS;
		[PInvokeData("combaseapi.h", MSDNShortId = "16bca8e0-9999-4d51-b7f0-87deb7619d89")]
		[Flags]
		public enum REGCLS
		{
			/// <summary>
			/// After an application is connected to a class object with CoGetClassObject, the class object is removed from public view so
			/// that no other applications can connect to it. This value is commonly used for single document interface (SDI) applications.
			/// Specifying this value does not affect the responsibility of the object application to call CoRevokeClassObject; it must
			/// always call CoRevokeClassObject when it is finished with an object class.
			/// </summary>
			REGCLS_SINGLEUSE = 0,

			/// <summary>
			/// Multiple applications can connect to the class object through calls to CoGetClassObject. If both the REGCLS_MULTIPLEUSE and
			/// CLSCTX_LOCAL_SERVER are set in a call to CoRegisterClassObject, the class object is also automatically registered as an
			/// in-process server, whether CLSCTX_INPROC_SERVER is explicitly set.
			/// </summary>
			REGCLS_MULTIPLEUSE = 1,

			/// <summary>
			/// Useful for registering separate CLSCTX_LOCAL_SERVER and CLSCTX_INPROC_SERVER class factories through calls to
			/// CoGetClassObject. If REGCLS_MULTI_SEPARATE is set, each execution context must be set separately; CoRegisterClassObject does
			/// not automatically register an out-of-process server (for which CLSCTX_LOCAL_SERVER is set) as an in-process server. This
			/// allows the EXE to create multiple instances of the object for in-process needs, such as self embeddings, without disturbing
			/// its CLSCTX_LOCAL_SERVER registration. If an EXE registers a REGCLS_MULTI_SEPARATE class factory and a CLSCTX_INPROC_SERVER
			/// class factory, instance creation calls that specify CLSCTX_INPROC_SERVER in the CLSCTX parameter executed by the EXE would be
			/// satisfied locally without approaching the SCM. This mechanism is useful when the EXE uses functions such as OleCreate and
			/// OleLoad to create embeddings, but at the same does not wish to launch a new instance of itself for the self-embedding case.
			/// The distinction is important for embeddings because the default handler aggregates the proxy manager by default and the
			/// application should override this default behavior by calling OleCreateEmbeddingHelper for the self-embedding case. If your
			/// application need not distinguish between the local and inproc case, you need not register your class factory using
			/// REGCLS_MULTI_SEPARATE. In fact, the application incurs an extra network round trip to the SCM when it registers its
			/// MULTIPLEUSE class factory as MULTI_SEPARATE and does not register another class factory as INPROC_SERVER.
			/// </summary>
			REGCLS_MULTI_SEPARATE = 2,

			/// <summary>
			/// Suspends registration and activation requests for the specified CLSID until there is a call to CoResumeClassObjects. This is
			/// used typically to register the CLSIDs for servers that can register multiple class objects to reduce the overall registration
			/// time, and thus the server application startup time, by making a single call to the SCM, no matter how many CLSIDs are
			/// registered for the server.
			/// </summary>
			REGCLS_SUSPENDED = 4,

			/// <summary>
			/// The class object is a surrogate process used to run DLL servers. The class factory registered by the surrogate process is not
			/// the actual class factory implemented by the DLL server, but a generic class factory implemented by the surrogate. This
			/// generic class factory delegates instance creation and marshaling to the class factory of the DLL server running in the
			/// surrogate. For further information on DLL surrogates, see the DllSurrogate registry value.
			/// </summary>
			REGCLS_SURROGATE = 8,

			/// <summary>
			/// The class object aggregates the free-threaded marshaler and will be made visible to all inproc apartments. Can be used
			/// together with other flags. For example, REGCLS_AGILE | REGCLS_MULTIPLEUSE to register a class object that can be used
			/// multiple times from different apartments. Without other flags, behavior will retain REGCLS_SINGLEUSE semantics in that only
			/// one instance can be generated.
			/// </summary>
			REGCLS_AGILE = 0x10,
		}

		/// <summary>Flags used by CoGetStdMarshalEx.</summary>
		[PInvokeData("combaseapi.h", MSDNShortId = "405c5ff3-8702-48b3-9be9-df4a9461696e")]
		public enum STDMSHLFLAGS
		{
			/// <summary>Indicates a client-side (handler) aggregated standard marshaler.</summary>
			SMEXF_HANDLER = 0x0,

			/// <summary>Indicates a server-side aggregated standard marshaler.</summary>
			SMEXF_SERVER = 0x01,
		}

		/// <summary>Looks up a CLSID in the registry, given a ProgID.</summary>
		/// <param name="lpszProgID">A pointer to the ProgID whose CLSID is requested.</param>
		/// <param name="lpclsid">Receives a pointer to the retrieved CLSID on return.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The CLSID was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CLASSSTRING</term>
		/// <term>The registered CLSID for the ProgID is invalid.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_WRITEREGDB</term>
		/// <term>An error occurred writing the CLSID to the registry. See Remarks below.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Given a ProgID, <c>CLSIDFromProgID</c> looks up its associated CLSID in the registry. If the ProgID cannot be found in the
		/// registry, <c>CLSIDFromProgID</c> creates an OLE 1 CLSID for the ProgID and a CLSID entry in the registry. Because of the
		/// restrictions placed on OLE 1 CLSID values, <c>CLSIDFromProgID</c> and CLSIDFromString are the only two functions that can be used
		/// to generate a CLSID for an OLE 1 object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-clsidfromprogid HRESULT CLSIDFromProgID( LPCOLESTR
		// lpszProgID, LPCLSID lpclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "89fb20af-65bf-4ed4-9f71-eb707ee8eb09")]
		public static extern HRESULT CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid lpclsid);

		/// <summary>
		/// <para>Triggers automatic installation if the COMClassStore policy is enabled.</para>
		/// <para>
		/// This is analogous to the behavior of CoCreateInstance when neither CLSCTX_ENABLE_CODE_DOWNLOAD nor CLSCTX_NO_CODE_DOWNLOAD are specified.
		/// </para>
		/// </summary>
		/// <param name="lpszProgID">A pointer to the ProgID whose CLSID is requested.</param>
		/// <param name="lpclsid">Receives a pointer to the retrieved CLSID on return.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The CLSID was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CLASSSTRING</term>
		/// <term>The registered CLSID for the ProgID is invalid.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_WRITEREGDB</term>
		/// <term>An error occurred writing the CLSID to the registry. See Remarks below.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// CLSCTX_ENABLE_CODE_DOWNLOAD enables automatic installation of missing classes through IntelliMirror/Application Management from
		/// the Active Directory. If this flag is not specified, the COMClassStore Policy ("Download missing COM components") determines the
		/// behavior (default: no download).
		/// </para>
		/// <para>
		/// If the COMClassStore Policy enables automatic installation, CLSCTX_NO_CODE_DOWNLOAD can be used to explicitly disallow download
		/// for an activation.
		/// </para>
		/// <para>If either of the following registry values are enabled (meaning set to 1), automatic download of missing classes is enabled:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\App Management</c>\ <c>COMClassStore</c></term>
		/// </item>
		/// <item>
		/// <term><c>HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\App Management</c>\ <c>COMClassStore</c></term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-clsidfromprogidex HRESULT CLSIDFromProgIDEx(
		// LPCOLESTR lpszProgID, LPCLSID lpclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "2f937ac1-b214-482a-af4b-8cc8c0c585c3")]
		public static extern HRESULT CLSIDFromProgIDEx([MarshalAs(UnmanagedType.LPWStr)] string lpszProgID, out Guid lpclsid);

		/// <summary>Converts a string generated by the StringFromCLSID function back into the original CLSID.</summary>
		/// <param name="lpsz">The string representation of the CLSID.</param>
		/// <param name="pclsid">A pointer to the CLSID.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NOERROR</term>
		/// <term>The CLSID was obtained successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CLASSSTRING</term>
		/// <term>The class string was improperly formatted.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>The CLSID corresponding to the class string was not found in the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>The registry could not be opened for reading.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-clsidfromstring HRESULT CLSIDFromString( LPCOLESTR
		// lpsz, LPCLSID pclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "36cc9037-480f-491f-a9bb-5aa1e707781e")]
		public static extern HRESULT CLSIDFromString([MarshalAs(UnmanagedType.LPWStr)] string lpsz, out Guid pclsid);

		/// <summary>Increments a global per-process reference count.</summary>
		/// <returns>The current reference count.</returns>
		/// <remarks>
		/// <para>
		/// Servers can call <c>CoAddRefServerProcess</c> to increment a global per-process reference count. This function is particularly
		/// helpful to servers that are implemented with multiple threads, either multi-apartmented or free-threaded. Servers of these types
		/// must coordinate the decision to shut down with activation requests across multiple threads. Calling <c>CoAddRefServerProcess</c>
		/// increments a global per-process reference count, and calling CoReleaseServerProcess decrements that count.
		/// </para>
		/// <para>
		/// When that count reaches zero, OLE automatically calls CoSuspendClassObjects, which prevents new activation requests from coming
		/// in. This permits the server to deregister its class objects from its various threads without worry that another activation
		/// request may come in. New activation requests result in launching a new instance of the local server process.
		/// </para>
		/// <para>
		/// The simplest way for a local server application to make use of these functions is to call <c>CoAddRefServerProcess</c> in the
		/// constructor for each of its instance objects, and in each of its IClassFactory::LockServer methods when the fLock parameter is
		/// <c>TRUE</c>. The server application should also call CoReleaseServerProcess in the destruction of each of its instance objects,
		/// and in each of its <c>LockServer</c> methods when the fLock parameter is <c>FALSE</c>. Finally, the server application should pay
		/// attention to the return code from <c>CoReleaseServerProcess</c> and if it returns 0, the server application should initiate its
		/// cleanup, which, for a server with multiple threads, typically means that it should signal its various threads to exit their
		/// message loops and call CoRevokeClassObject and CoUninitialize.
		/// </para>
		/// <para>
		/// If these functions are used at all, they must be called in both the object instances and the LockServer method, otherwise the
		/// server application may be shut down prematurely. In-process servers typically should not call <c>CoAddRefServerProcess</c> or CoReleaseServerProcess.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coaddrefserverprocess ULONG CoAddRefServerProcess( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "79887f9d-cad1-492a-b406-d1753ffaf82b")]
		public static extern uint CoAddRefServerProcess();

		/// <summary>Adds an unmarshaler CLSID to the allowed list for the calling process only.</summary>
		/// <param name="clsid">The CLSID of the unmarshaler to be added to the per-process allowed list.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Don't call the <c>CoAllowUnmarshalerCLSID</c> function until after CoInitializeSecurity has been called in the current process.
		/// </para>
		/// <para>
		/// The <c>CoAllowUnmarshalerCLSID</c> function provides more granular control over unmarshaling policy than is provided by the
		/// policy options. If the process applies any unmarshaling policy, the effect of the <c>CoAllowUnmarshalerCLSID</c> function is to
		/// make the policy comparatively weaker. For this reason, only call <c>CoAllowUnmarshalerCLSID</c> when the security impact is well
		/// understood. Usually, this is used to facilitate applying a stronger unmarshaling policy option for the broad attack surface
		/// reduction this provides, when a specific unmarshaler CLSID not allowed by that option is needed due to other constraints.
		/// </para>
		/// <para>
		/// For example, it's appropriate to call the <c>CoAllowUnmarshalerCLSID</c> function when an unmarshaler is known or believed to
		/// have a vulnerability but is required by an app. Also, it's appropriate to call <c>CoAllowUnmarshalerCLSID</c> if the unmarshaler
		/// is used in multiple processes, but only as part of an uncommon feature. Don't use the <c>CoAllowUnmarshalerCLSID</c> function as
		/// a replacement for hardening the unmarshaler.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coallowunmarshalerclsid HRESULT
		// CoAllowUnmarshalerCLSID( REFCLSID clsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "4655C6B6-02CE-42B2-A157-0C0325D1BE52")]
		public static extern HRESULT CoAllowUnmarshalerCLSID(in Guid clsid);

		/// <summary>Requests cancellation of an outbound DCOM method call pending on a specified thread.</summary>
		/// <param name="dwThreadId">
		/// The identifier of the thread on which the pending DCOM call is to be canceled. If this parameter is 0, the call is on the current thread.
		/// </param>
		/// <param name="ulTimeout">
		/// The number of seconds <c>CoCancelCall</c> waits for the server to complete the outbound call after the client requests cancellation.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The cancellation request was made.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>There is no cancel object corresponding to the specified thread.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CANCEL_DISABLED</term>
		/// <term>Call cancellation is not enabled on the specified thread.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CALL_COMPLETE</term>
		/// <term>The call was completed during the timeout interval.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CALL_CANCELED</term>
		/// <term>The call was already canceled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoCancelCall</c> calls CoGetCancelObject and then ICancelMethodCalls::Cancel on the cancel object for the call being executed.
		/// </para>
		/// <para>This function does not locate cancel objects for asynchronous calls.</para>
		/// <para>
		/// The object server can determine if the call has been canceled by periodically calling CoTestCancel. If the call has been
		/// canceled, the object server should clean up and return control to the client.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocancelcall HRESULT CoCancelCall( DWORD dwThreadId,
		// ULONG ulTimeout );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "1707261c-2d8d-4f35-865d-61c8870c0624")]
		public static extern HRESULT CoCancelCall(uint dwThreadId, uint ulTimeout);

		/// <summary>Makes a private copy of the specified proxy.</summary>
		/// <param name="pProxy">A pointer to the IUnknown interface on the proxy to be copied. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppCopy">
		/// Address of the pointer variable that receives the interface pointer to the copy of the proxy. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoCopyProxy</c> makes a private copy of the specified proxy. Typically, this function is called when a client needs to change
		/// the authentication information of its proxy through a call to either CoSetProxyBlanket or IClientSecurity::SetBlanket without
		/// changing this information for other clients. <c>CoSetProxyBlanket</c> affects all the users of an instance of a proxy, so
		/// creating a private copy of the proxy through a call to <c>CoCopyProxy</c> and then calling <c>CoSetProxyBlanket</c> (or
		/// <c>IClientSecurity::SetBlanket</c>) using the copy eliminates the problem.
		/// </para>
		/// <para>This helper function encapsulates the following sequence of common calls (error handling excluded):</para>
		/// <para>Local interfaces may not be copied. IUnknown and IClientSecurity are examples of existing local interfaces.</para>
		/// <para>
		/// Copies of the same proxy have a special relationship with respect to QueryInterface. Given a proxy, a, of the IA interface of a
		/// remote object, suppose a copy of a is created, called b. In this case, calling <c>QueryInterface</c> from the b proxy for IID_IA
		/// will not retrieve the IA interface on b, but the one on a, the original proxy with the "default" security settings for the IA interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocopyproxy HRESULT CoCopyProxy( IUnknown *pProxy,
		// IUnknown **ppCopy );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "26de7bac-8745-40c0-be0a-dcec88a3ecaf")]
		public static extern HRESULT CoCopyProxy([MarshalAs(UnmanagedType.IUnknown)] object pProxy, [MarshalAs(UnmanagedType.IUnknown)] out object ppCopy);

		/// <summary>Creates an aggregatable object capable of context-dependent marshaling.</summary>
		/// <param name="punkOuter">A pointer to the aggregating object's controlling IUnknown.</param>
		/// <param name="ppunkMarshal">Address of the pointer variable that receives the interface pointer to the aggregatable marshaler.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_OUTOFMEMORY, as well as the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The marshaler was created.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoCreateFreeThreadedMarshaler</c> function enables an object to efficiently marshal interface pointers between threads in
		/// the same process. If your objects do not support interthread marshaling, you have no need to call this function. It is intended
		/// for use by free-threaded DLL servers that must be accessed directly by all threads in a process, even those threads associated
		/// with single-threaded apartments. It custom-marshals the real memory pointer over into other apartments as a bogus "proxy" and
		/// thereby gives direct access to all callers, even if they are not free-threaded.
		/// </para>
		/// <para>The <c>CoCreateFreeThreadedMarshaler</c> function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>Creates a free-threaded marshaler object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Aggregates this marshaler to the object specified by the punkOuter parameter. This object is normally the one whose interface
		/// pointers are to be marshaled.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The aggregating object's implementation of IMarshal should delegate QueryInterface calls for IID_IMarshal to the IUnknown of the
		/// free-threaded marshaler. Upon receiving a call, the free-threaded marshaler performs the following tasks:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Checks the destination context specified by the CoMarshalInterface function's dwDestContext parameter.</term>
		/// </item>
		/// <item>
		/// <term>If the destination context is MSHCTX_INPROC, copies the interface pointer into the marshaling stream.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the destination context is any other value, finds or creates an instance of COM's default (standard) marshaler and delegates
		/// marshaling to it.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Values for dwDestContext come from the MSHCTX enumeration. MSHCTX_INPROC indicates that the interface pointer is to be marshaled
		/// between different threads in the same process. Because both threads have access to the same address space, the client thread can
		/// dereference the pointer directly rather than having to direct calls to a proxy. In all other cases, a proxy is required, so
		/// <c>CoCreateFreeThreadedMarshaler</c> delegates the marshaling job to COM's default implementation.
		/// </para>
		/// <para>
		/// Great care should be exercised in using the <c>CoCreateFreeThreadedMarshaler</c> function. This is because the performance of
		/// objects which aggregate the free-threaded marshaler is obtained through a calculated violation of the rules of COM, with the
		/// ever-present risk of undefined behavior unless the object operates within certain restrictions. The most important restrictions are:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A free-threaded marshaler object cannot hold direct pointers to interfaces on an object that does not aggregate the free-threaded
		/// marshaler as part of its state. If the object were to use direct references to ordinary single-threaded aggregate objects, it may
		/// break their single threaded property. If the object were to use direct references to ordinary multithreaded aggregate objects,
		/// these objects can behave in ways that show no sensitivity to the needs of direct single-threaded aggregate clients. For example,
		/// these objects can spin new threads and pass parameters to the threads that are references to ordinary single-threaded aggregate objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A free-threaded marshaler object cannot hold references to proxies to objects in other apartments. Proxies are sensitive to the
		/// threading model and can return RPC_E_WRONG_THREAD if called by the wrong client.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocreatefreethreadedmarshaler HRESULT
		// CoCreateFreeThreadedMarshaler( LPUNKNOWN punkOuter, LPUNKNOWN *ppunkMarshal );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "f97a2a39-7291-4a1d-b770-0a34f7f5b60f")]
		public static extern HRESULT CoCreateFreeThreadedMarshaler([MarshalAs(UnmanagedType.IUnknown)] object punkOuter, [MarshalAs(UnmanagedType.IUnknown)] out object ppunkMarshal);

		/// <summary>Creates a GUID, a unique 128-bit integer used for CLSIDs and interface identifiers.</summary>
		/// <param name="pguid">A pointer to the requested GUID.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The GUID was successfully created.</term>
		/// </item>
		/// </list>
		/// <para>Errors returned by UuidCreate are wrapped as an <c>HRESULT</c>.</para>
		/// </returns>
		/// <remarks>
		/// The <c>CoCreateGuid</c> function calls the RPC function UuidCreate, which creates a GUID, a globally unique 128-bit integer. Use
		/// <c>CoCreateGuid</c> when you need an absolutely unique number that you will use as a persistent identifier in a distributed
		/// environment.To a very high degree of certainty, this function returns a unique value – no other invocation, on the same or any
		/// other system (networked or not), should return the same value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cocreateguid HRESULT CoCreateGuid( GUID *pguid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "8d5cedea-8c2b-4918-99db-1a000989f178")]
		public static extern HRESULT CoCreateGuid(out Guid pguid);

		/// <summary>
		/// <para>Creates a single uninitialized object of the class associated with a specified CLSID.</para>
		/// <para>
		/// Call <c>CoCreateInstance</c> when you want to create only one object on the local system. To create a single object on a remote
		/// system, call the CoCreateInstanceEx function. To create multiple objects based on a single CLSID, call the CoGetClassObject function.
		/// </para>
		/// </summary>
		/// <param name="rclsid">The CLSID associated with the data and code that will be used to create the object.</param>
		/// <param name="pUnkOuter">
		/// If <c>NULL</c>, indicates that the object is not being created as part of an aggregate. If non- <c>NULL</c>, pointer to the
		/// aggregate object's IUnknown interface (the controlling <c>IUnknown</c>).
		/// </param>
		/// <param name="dwClsContext">
		/// Context in which the code that manages the newly created object will run. The values are taken from the enumeration CLSCTX.
		/// </param>
		/// <param name="riid">A reference to the identifier of the interface to be used to communicate with the object.</param>
		/// <param name="ppv">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppv contains the
		/// requested interface pointer. Upon failure, *ppv contains <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>An instance of the specified object class was successfully created.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>
		/// A specified class is not registered in the registration database. Also can indicate that the type of server you requested in the
		/// CLSCTX enumeration is not registered or the values for the server types in the registry are corrupt.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>This class cannot be created as part of an aggregate.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>
		/// The specified class does not implement the requested interface, or the controlling IUnknown does not expose the requested interface.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The ppv parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoCreateInstance</c> function provides a convenient shortcut by connecting to the class object associated with the
		/// specified CLSID, creating an uninitialized instance, and releasing the class object. As such, it encapsulates the following functionality:
		/// </para>
		/// <para>
		/// It is convenient to use <c>CoCreateInstance</c> when you need to create only a single instance of an object on the local machine.
		/// If you are creating an instance on remote computer, call CoCreateInstanceEx. When you are creating multiple instances, it is more
		/// efficient to obtain a pointer to the class object's IClassFactory interface and use its methods as needed. In the latter case,
		/// you should use the CoGetClassObject function.
		/// </para>
		/// <para>
		/// In the CLSCTX enumeration, you can specify the type of server used to manage the object. The constants can be
		/// CLSCTX_INPROC_SERVER, CLSCTX_INPROC_HANDLER, CLSCTX_LOCAL_SERVER, CLSCTX_REMOTE_SERVER or any combination of these values. The
		/// constant CLSCTX_ALL is defined as the combination of all four. For more information about the use of one or a combination of
		/// these constants, see CLSCTX.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocreateinstance HRESULT CoCreateInstance( REFCLSID
		// rclsid, LPUNKNOWN pUnkOuter, DWORD dwClsContext, REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "7295a55b-12c7-4ed0-a7a4-9ecee16afdec")]
		public static extern HRESULT CoCreateInstance(in Guid rclsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object pUnkOuter,
			CLSCTX dwClsContext, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppv);

		/// <summary>
		/// <para>Creates an instance of a specific class on a specific computer.</para>
		/// </summary>
		/// <param name="Clsid">
		/// <para>The CLSID of the object to be created.</para>
		/// </param>
		/// <param name="punkOuter">
		/// <para>
		/// If this parameter non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used
		/// as the new instance's controlling IUnknown. Aggregation is currently not supported cross-process or cross-computer. When
		/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwClsCtx">
		/// <para>A value from the CLSCTX enumeration.</para>
		/// </param>
		/// <param name="pServerInfo">
		/// <para>
		/// Information about the computer on which to instantiate the object. See COSERVERINFO. This parameter can be <c>NULL</c>, in which
		/// case the object is instantiated on the local computer or at the computer specified in the registry under the class's
		/// RemoteServerName value, according to the interpretation of the dwClsCtx parameter.
		/// </para>
		/// </param>
		/// <param name="dwCount">
		/// <para>The number of structures in pResults. This value must be greater than 0.</para>
		/// </param>
		/// <param name="pResults">
		/// <para>
		/// An array of MULTI_QI structures. Each structure has three members: the identifier for a requested interface ( <c>pIID</c>), the
		/// location to return the interface pointer ( <c>pItf</c>) and the return value of the call to QueryInterface ( <c>hr</c>).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates success.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>
		/// A specified class is not registered in the registration database. Also can indicate that the type of server you requested in the
		/// CLSCTX enumeration is not registered or the values for the server types in the registry are corrupt.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>This class cannot be created as part of an aggregate.</term>
		/// </item>
		/// <item>
		/// <term>CO_S_NOTALLINTERFACES</term>
		/// <term>
		/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each of
		/// the MULTI_QI structures in pResults indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>None of the interfaces requested in the pResults array were successfully retrieved.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoCreateInstanceEx</c> creates a single uninitialized object associated with the given CLSID on a specified remote computer.
		/// This is an extension of the function CoCreateInstance, which creates an object on the local computer only. In addition, rather
		/// than requesting a single interface and obtaining a single pointer to that interface, <c>CoCreateInstanceEx</c> makes it possible
		/// to specify an array of structures, each pointing to an interface identifier (IID) on input, and, on return, containing (if
		/// available) a pointer to the requested interface and the return value of the QueryInterface call for that interface. This permits
		/// fewer round trips between computers.
		/// </para>
		/// <para>
		/// This function encapsulates three calls: first, to CoGetClassObject to connect to the class object associated with the specified
		/// CLSID, specifying the location of the class; second, to IClassFactory::CreateInstance to create an uninitialized instance, and
		/// finally, to IClassFactory::Release, to release the class object.
		/// </para>
		/// <para>
		/// The object so created must still be initialized through a call to one of the initialization interfaces (such as
		/// IPersistStorage::Load). Two functions, CoGetInstanceFromFile and CoGetInstanceFromIStorage encapsulate both the instance creation
		/// and initialization from the obvious sources.
		/// </para>
		/// <para>
		/// The COSERVERINFO structure passed as the pServerInfo parameter contains the security settings that COM will use when creating a
		/// new instance of the specified object. Note that this parameter does not influence the security settings used when making method
		/// calls on the instantiated object. Those security settings are configurable, on a per-interface basis, with the CoSetProxyBlanket
		/// function. Also see, IClientSecurity::SetBlanket.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocreateinstanceex HRESULT CoCreateInstanceEx(
		// REFCLSID Clsid, IUnknown *punkOuter, DWORD dwClsCtx, COSERVERINFO *pServerInfo, DWORD dwCount, MULTI_QI *pResults );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "3b414b95-e8d2-42e8-b4f2-5cc5189a3d08")]
		public static extern HRESULT CoCreateInstanceEx(in Guid Clsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object punkOuter,
			CLSCTX dwClsCtx, [Optional] COSERVERINFO pServerInfo, uint dwCount,
			[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] MULTI_QI[] pResults);

		/// <summary>Creates an instance of a specific class on a specific computer from within an app container.</summary>
		/// <param name="Clsid">The CLSID of the object to be created.</param>
		/// <param name="punkOuter">
		/// If this parameter non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used
		/// as the new instance's controlling IUnknown. Aggregation is currently not supported cross-process or cross-computer. When
		/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
		/// </param>
		/// <param name="dwClsCtx">A value from the CLSCTX enumeration.</param>
		/// <param name="reserved">Reserved for future use.</param>
		/// <param name="dwCount">The number of structures in pResults. This value must be greater than 0.</param>
		/// <param name="pResults">
		/// An array of MULTI_QI structures. Each structure has three members: the identifier for a requested interface ( <c>pIID</c>), the
		/// location to return the interface pointer ( <c>pItf</c>) and the return value of the call to QueryInterface ( <c>hr</c>).
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates success.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>
		/// A specified class is not registered in the registration database, or the class is not supported in the app container. Also can
		/// indicate that the type of server you requested in the CLSCTX enumeration is not registered or the values for the server types in
		/// the registry are corrupt.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>This class cannot be created as part of an aggregate.</term>
		/// </item>
		/// <item>
		/// <term>CO_S_NOTALLINTERFACES</term>
		/// <term>
		/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each of
		/// the MULTI_QI structures in pResults indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>None of the interfaces requested in the pResults array were successfully retrieved.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CoCreateInstanceFromApp</c> function is the same as the CoCreateInstanceEx function, with the following differences.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The <c>CoCreateInstanceFromApp</c> function reads class registrations only from application contexts, and from the
		/// HKLM\SOFTWARE\Classes\CLSID registry hive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Only built-in classes that are supported in the app container are supplied. Attempts to activate unsupported classes, including
		/// all classes installed by 3rd-party code as well as many Windows classes, result in error code <c>REGDB_E_CLASSNOTREG</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The <c>CoCreateInstanceFromApp</c> function is available to Windows Store apps. Desktop applications can call this function, but
		/// they have the same restrictions as Windows Store apps.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cocreateinstancefromapp HRESULT
		// CoCreateInstanceFromApp( REFCLSID Clsid, IUnknown *punkOuter, DWORD dwClsCtx, PVOID reserved, DWORD dwCount, MULTI_QI *pResults );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "1C773D78-5B33-44FE-A09B-AB8087F678A1")]
		public static extern HRESULT CoCreateInstanceFromApp(in Guid Clsid, [MarshalAs(UnmanagedType.IUnknown)] object punkOuter, uint dwClsCtx, IntPtr reserved, uint dwCount, ref MULTI_QI pResults);

		/// <summary>
		/// Locates the implementation of a Component Object Model (COM) interface in a server process given an interface to a proxied object.
		/// </summary>
		/// <param name="dwClientPid">The process ID of the process that contains the proxy.</param>
		/// <param name="ui64ProxyAddress">
		/// The address of an interface on a proxy to the object. ui64ProxyAddress is considered a 64-bit value type, rather than a pointer
		/// to a 64-bit value, and isn't a pointer to an object in the debugger process. Instead, this address is passed to the
		/// ReadProcessMemory function.
		/// </param>
		/// <param name="pServerInformation">A structure that contains the process ID, the thread ID, and the address of the server.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The server information was successfully retrieved.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The caller is an app container, or the developer license is not installed.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_INVALID_IPID</term>
		/// <term>ui64ProxyAddress does not point to a proxy.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoDecodeProxy</c> function is a COM API that enables native debuggers to locate the implementation of a COM interface in a
		/// server process given an interface on a proxy to the object.
		/// </para>
		/// <para>
		/// Also, the <c>CoDecodeProxy</c> function enables the debugger to monitor cross-apartment function calls and fail such calls when appropriate.
		/// </para>
		/// <para>
		/// You can call the <c>CoDecodeProxy</c> function from a 32-bit or 64-bit process. ui64ProxyAddress can be a 32-bit or 64-bit
		/// address. The <c>CoDecodeProxy</c> function returns a 32-bit or 64-bit address in the pServerInformation field. If it returns a
		/// 64-bit address, you should pass the address to the ReadProcessMemory function only from a 64-bit process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-codecodeproxy HRESULT CoDecodeProxy( DWORD
		// dwClientPid, UINT64 ui64ProxyAddress, PServerInformation pServerInformation );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "C61C68B1-78CA-4052-9E24-629AB4083B86")]
		public static extern HRESULT CoDecodeProxy(uint dwClientPid, ulong ui64ProxyAddress, IntPtr pServerInformation);

		/// <summary>Releases the increment made by a previous call to the CoIncrementMTAUsage function.</summary>
		/// <param name="Cookie">A <c>PVOID</c> variable that was set by a previous call to the CoIncrementMTAUsage function.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Cookie must be a valid value returned by a successful previous call to the CoIncrementMTAUsage function. If the overall count of
		/// MTA usage reaches 0, including both through this API and through the CoInitializeEx and CoUninitialize functions, the system
		/// frees resources related to MTA support.
		/// </para>
		/// <para>
		/// You can call CoIncrementMTAUsage from one thread and <c>CoDecrementMTAUsage</c> from another as long as a cookie previously
		/// returned by <c>CoIncrementMTAUsage</c> is passed to <c>CoDecrementMTAUsage</c>.
		/// </para>
		/// <para>
		/// Don't call <c>CoDecrementMTAUsage</c> during process shutdown or inside dllmain. You can call <c>CoDecrementMTAUsage</c> before
		/// the call to start the shutdown process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-codecrementmtausage HRESULT CoDecrementMTAUsage(
		// CO_MTA_USAGE_COOKIE Cookie );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "66AA2783-7F24-41BB-911B-D452DF54C003")]
		public static extern HRESULT CoDecrementMTAUsage(CO_MTA_USAGE_COOKIE Cookie);

		/// <summary>
		/// Undoes the action of a call to CoEnableCallCancellation. Disables cancellation of synchronous calls on the calling thread when
		/// all calls to <c>CoEnableCallCancellation</c> are balanced by calls to <c>CoDisableCallCancellation</c>.
		/// </summary>
		/// <param name="pReserved">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Call cancellation was successfully disabled on the thread.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CANCEL_DISABLED</term>
		/// <term>
		/// There have been more successful calls to CoEnableCallCancellation on the thread than there have been calls to
		/// CoDisableCallCancellation. Cancellation is still enabled on the thread.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When call cancellation is enabled on a thread, marshaled synchronous calls from that thread to objects on the same computer can
		/// suffer serious performance degradation. By default, then, synchronous calls cannot be canceled, even if a cancel object is
		/// available. To enable call cancellation, you must call CoEnableCallCancellation first.
		/// </para>
		/// <para>
		/// When call cancellation is disabled, attempts to gain a pointer to a call object will fail. If the calling thread already has a
		/// pointer to a call object, calls on that object will fail.
		/// </para>
		/// <para>
		/// Unless you want to enable call cancellation on a thread at all times, you should pair calls to CoEnableCallCancellation with
		/// calls to <c>CoDisableCallCancellation</c>. Call cancellation is disabled only if each successful call to
		/// <c>CoEnableCallCancellation</c> is balanced by a successful call to <c>CoDisableCallCancellation</c>.
		/// </para>
		/// <para>
		/// A call will be cancelable or not depending on the state of the thread at the time the call was made. Subsequently enabling or
		/// disabling call cancellation has no effect on any calls that are pending on the thread.
		/// </para>
		/// <para>
		/// If a thread is uninitialized and then reinitialized by calls to CoUninitialize and CoInitialize, call cancellation is disabled on
		/// the thread, even if it was enabled when the thread was uninitialized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-codisablecallcancellation HRESULT
		// CoDisableCallCancellation( LPVOID pReserved );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "33d99eab-a0bf-4e4d-93a4-5c03c41cebbb")]
		public static extern HRESULT CoDisableCallCancellation([Optional] IntPtr pReserved);

		/// <summary>
		/// <para>
		/// Disconnects all proxy connections that are being maintained on behalf of all interface pointers that point to objects in the
		/// current context.
		/// </para>
		/// <para>
		/// This function blocks connections until all objects are successfully disconnected or the time-out expires. Only the context that
		/// actually manages the objects should call <c>CoDisconnectContext</c>.
		/// </para>
		/// </summary>
		/// <param name="dwTimeout">
		/// The time in milliseconds after which <c>CoDisconnectContext</c> returns even if the proxy connections for all objects have not
		/// been disconnected. INFINITE is an acceptable value for this parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, and E_OUTOFMEMORY, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The proxy connections for all objects were successfully disconnected.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_TIMEOUT</term>
		/// <term>Not all proxy connections were successfully deleted in the time specified in dwTimeout.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTSUPPORTED</term>
		/// <term>The current context cannot be disconnected.</term>
		/// </item>
		/// <item>
		/// <term>CONTEXT_E_WOULD_DEADLOCK</term>
		/// <term>
		/// An object tried to call CoDisconnectContext on the context it is residing in. This would cause the function to time-out and
		/// deadlock if dwTimeout were set to INFINITE.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoDisconnectContext</c> function is used to support unloading services in shared service hosts where you must unload your
		/// service's binaries without affecting other COM servers that are running in the same process. If you control the process lifetime
		/// and you do not unload until the process exits, the COM infrastructure will perform the necessary cleanup automatically and you do
		/// not have to call this function.
		/// </para>
		/// <para>
		/// The <c>CoDisconnectContext</c> function enables a server to correctly disconnect all external clients of all objects in the
		/// current context. Default contexts cannot be disconnected. To use <c>CoDisconnectContext</c>, you must first create a context that
		/// can be disconnected and register your class factories for objects from which you want to disconnect within that context. You can
		/// do this with the IContextCallback interface.
		/// </para>
		/// <para>
		/// If <c>CoDisconnectContext</c> returns RPC_E_TIMEOUT, this does not indicate that the function did not disconnect the objects, but
		/// that not all disconnections could be completed in the time specified by dwTimeout because of outstanding calls on the objects.
		/// All objects will be disconnected after all calls on them have been completed.
		/// </para>
		/// <para>
		/// It is not safe to unload the DLL that hosts the service until <c>CoDisconnectContext</c> returns S_OK. If the function returns
		/// RPC_E_TIMEOUT, the service may perform other clean-up. The service must call the function until it returns S_OK, and then it can
		/// safely unload its DLL.
		/// </para>
		/// <para>The <c>CoDisconnectContext</c> function performs the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Calls CoDisconnectObject on all objects in the current context.</term>
		/// </item>
		/// <item>
		/// <term>Blocks until all objects have been disconnected or the time-out has expired.</term>
		/// </item>
		/// </list>
		/// <para>The <c>CoDisconnectContext</c> function has the following limitations:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Asynchronous COM calls are not supported.</term>
		/// </item>
		/// <item>
		/// <term>In-process objects must be registered and enabled using the CLSCTX_LOCAL_SERVER flag, or they will not be disconnected.</term>
		/// </item>
		/// <item>
		/// <term>COM+ is not supported.</term>
		/// </item>
		/// <item>
		/// <term>
		/// COM interface pointers are context-sensitive. Therefore, any interface pointer created in the context to be disconnected can only
		/// be used within that context.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-codisconnectcontext HRESULT CoDisconnectContext(
		// DWORD dwTimeout );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "faacb583-285a-4ec6-9700-22320e87de6e")]
		public static extern HRESULT CoDisconnectContext(uint dwTimeout);

		/// <summary>
		/// <para>
		/// Disconnects all remote process connections being maintained on behalf of all the interface pointers that point to a specified object.
		/// </para>
		/// <para>Only the process that actually manages the object should call <c>CoDisconnectObject</c>.</para>
		/// </summary>
		/// <param name="pUnk">A pointer to any interface derived from IUnknown on the object to be disconnected.</param>
		/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
		/// <returns>This function returns S_OK to indicate that all connections to remote processes were successfully deleted.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CoDisconnectObject</c> function enables a server to correctly disconnect all external clients to the object specified by pUnk.
		/// </para>
		/// <para>It performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Checks to see whether the object to be disconnected implements the IMarshal interface. If so, it gets the pointer to that
		/// interface; if not, it gets a pointer to the standard marshaler's (i.e., COM's) <c>IMarshal</c> implementation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Using whichever IMarshal interface pointer it has acquired, the function then calls IMarshal::DisconnectObject to disconnect all
		/// out-of-process clients.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// An object's client does not call <c>CoDisconnectObject</c> to disconnect itself from the server (clients should use
		/// IUnknown::Release for this purpose). Rather, an OLE server calls <c>CoDisconnectObject</c> to forcibly disconnect an object's
		/// clients, usually in response to a user closing the server application.
		/// </para>
		/// <para>
		/// Similarly, an OLE container that supports external links to its embedded objects can call <c>CoDisconnectObject</c> to destroy
		/// those links. Again, this call is normally made in response to a user closing the application. The container should first call
		/// IOleObject::Close for all its OLE objects, each of which should send IAdviseSink::OnClose notifications to their various clients.
		/// Then the container can call <c>CoDisconnectObject</c> to close any existing connections.
		/// </para>
		/// <para>
		/// <c>CoDisconnectObject</c> does not necessarily disconnect out-of-process clients immediately. If any marshaled calls are pending
		/// on the server object, <c>CoDisconnectObject</c> disconnects the object only when those calls have returned. In the meantime,
		/// <c>CoDisconnectObject</c> sets a flag that causes any new marshaled calls to return CO_E_OBJNOTCONNECTED.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-codisconnectobject HRESULT CoDisconnectObject(
		// LPUNKNOWN pUnk, DWORD dwReserved );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "4293316a-bafe-4fca-ad6a-68d8e99c8fba")]
		public static extern HRESULT CoDisconnectObject([MarshalAs(UnmanagedType.IUnknown)] object pUnk, uint dwReserved = 0);

		/// <summary>Enables cancellation of synchronous calls on the calling thread.</summary>
		/// <param name="pReserved">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>This function can return the standard return values S_OK, E_FAIL, E_INVALIDARG, and E_OUTOFMEMORY.</returns>
		/// <remarks>
		/// <para>
		/// When call cancellation is enabled on a thread, marshaled synchronous calls from that thread to objects on the same computer can
		/// suffer serious performance degradation. By default, synchronous calls cannot be canceled, even if a cancel object is available.
		/// To enable call cancellation, you must call <c>CoEnableCallCancellation</c> first.
		/// </para>
		/// <para>
		/// Unless you want to enable call cancellation on a thread at all times, you should pair calls to <c>CoEnableCallCancellation</c>
		/// with calls to CoDisableCallCancellation. Call cancellation is disabled only if <c>CoDisableCallCancellation</c> has been called
		/// once for each time <c>CoEnableCallCancellation</c> was called successfully.
		/// </para>
		/// <para>
		/// A call will be cancelable or not depending on the state of the thread at the time the call was made. Subsequently enabling or
		/// disabling call cancellation has no effect on any calls that are pending on the thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coenablecallcancellation HRESULT
		// CoEnableCallCancellation( LPVOID pReserved );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "59b66f33-486e-49c3-9fb8-0eab93146ed9")]
		public static extern HRESULT CoEnableCallCancellation(IntPtr pReserved = default);

		/// <summary>
		/// <para>Returns the current time as a FILETIME structure.</para>
		/// <para><c>Note</c> This function is provided for compatibility with 16-bit Windows.</para>
		/// </summary>
		/// <param name="lpFileTime">A pointer to the FILETIME structure that receives the current time.</param>
		/// <returns>This function returns S_OK to indicate success.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cofiletimenow HRESULT CoFileTimeNow( FILETIME
		// *lpFileTime );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "00083429-1d61-4a0b-bb73-82158869466d")]
		public static extern HRESULT CoFileTimeNow(out FILETIME lpFileTime);

		/// <summary>
		/// <para>Unloads any DLLs that are no longer in use, probably because the DLL no longer has any instantiated COM objects outstanding.</para>
		/// <para><c>Note</c> This function is provided for compatibility with 16-bit Windows.</para>
		/// </summary>
		/// <remarks>
		/// Applications can call <c>CoFreeUnusedLibraries</c> periodically to free resources. It is most efficient to call it either at the
		/// top of a message loop or in some idle-time task. <c>CoFreeUnusedLibraries</c> internally calls DllCanUnloadNow for DLLs that
		/// implement and export that function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cofreeunusedlibraries void CoFreeUnusedLibraries( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "188e9a3b-39cc-454e-af65-4ac797e275d4")]
		public static extern void CoFreeUnusedLibraries();

		/// <summary>Unloads any DLLs that are no longer in use and whose unload delay has expired.</summary>
		/// <param name="dwUnloadDelay">
		/// The delay in milliseconds between the time that the DLL has stated it can be unloaded until it becomes a candidate to unload.
		/// Setting this parameter to INFINITE uses the system default delay (10 minutes). Setting this parameter to 0 forces the unloading
		/// of any DLLs without any delay.
		/// </param>
		/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
		/// <remarks>
		/// <para>
		/// COM supplies functions to reclaim memory held by DLLs containing components. The most commonly used function is
		/// CoFreeUnusedLibraries. <c>CoFreeUnusedLibraries</c> does not immediately release DLLs that have no active object. There is a
		/// 10-minute delay for multithreaded apartments (MTAs) and neutral apartments (NAs). For single-threaded apartments (STAs), there is
		/// no delay.
		/// </para>
		/// <para>
		/// The 10-minute delay for CoFreeUnusedLibraries is to avoid multithread race conditions caused by unloading a component DLL. This
		/// default delay may be too long for many applications.
		/// </para>
		/// <para>
		/// COM maintains a list of active DLLs that have had components loaded for the apartments that can be hosted on the thread where
		/// this function is called. When <c>CoFreeUnusedLibrariesEx</c> is called, each DLL on that list has its DllCanUnloadNow function
		/// called. If <c>DllCanUnloadNow</c> returns S_FALSE (or is not exported), this DLL is not ready to be unloaded. If
		/// <c>DllCanUnloadNow</c> returns S_OK, this DLL is moved off the active list to a "candidate-for-unloading" list.
		/// </para>
		/// <para>
		/// Adding the DLL to the candidate-for-unloading list time-stamps the DLL dwUnloadDelay milliseconds from when this move occurs.
		/// When <c>CoFreeUnusedLibrariesEx</c> (or CoFreeUnusedLibraries) is called again, at least dwUnloadDelay milliseconds from the call
		/// that moved the DLL to the candidate-for-unloading list, the DLL is actually freed from memory. If COM uses the component DLL
		/// while the DLL is on the candidate-for-unloading list, it is moved back to the active list.
		/// </para>
		/// <para>
		/// Setting dwUnloadDelay to 0 may have unexpected consequences. The component DLL may need some time for cleanup after it returns
		/// from the DllCanUnloadNow function. For example, if the DLL had its own worker threads, using a value of 0 would most likely lead
		/// to a problem because the code executing on these threads would be unmapped, caused by the unloading of the DLL before the worker
		/// threads have a chance to exit. Also, using too brief of a value for dwUnloadDelay can lead to performance issues because there is
		/// more overhead in reloading a DLL than letting it page out.
		/// </para>
		/// <para>
		/// This behavior is triggered by the DLL supplying components with threading models set to Free, Neutral, or Both. For a threading
		/// model set to Apartment (or if no threading model is specified), dwUnloadDelay is treated as 0 because these components are tied
		/// to the single thread hosting the apartment.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cofreeunusedlibrariesex void
		// CoFreeUnusedLibrariesEx( DWORD dwUnloadDelay, DWORD dwReserved );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "01660e9d-d8f2-40ef-a6d6-b80f0140ab5f")]
		public static extern void CoFreeUnusedLibrariesEx(uint dwUnloadDelay, uint dwReserved = 0);

		/// <summary>Returns the current apartment type and type qualifier.</summary>
		/// <param name="pAptType">APTTYPE enumeration value that specifies the type of the current apartment.</param>
		/// <param name="pAptQualifier">APTTYPEQUALIFIER enumeration value that specifies the type qualifier of the current apartment.</param>
		/// <returns>
		/// <para>Returns S_OK if the call succeeded. Otherwise, one of the following error codes is returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The call could not successfully query the current apartment type and type qualifier.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// An invalid parameter value was supplied to the function. Specifically, one or both of the parameters were set to NULL by the caller.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>CoInitialize or CoInitializeEx was not called on this thread prior to calling CoGetApartmentType.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>On Windows platforms prior to Windows 7, the following actions must be taken on a thread to query the apartment type:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Call CoGetContextToken to obtain the current context token.</term>
		/// </item>
		/// <item>
		/// <term>Cast the context token to an IUnknown* pointer.</term>
		/// </item>
		/// <item>
		/// <term>Call the QueryInterface method on that pointer to obtain the IComThreadingInfo interface.</term>
		/// </item>
		/// <item>
		/// <term>Call the GetCurrentApartmentType method of the IComThreadingInfo interface to obtain the current apartment type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In multithreaded scenarios, there is a race condition which can potentially cause an Access Violation within the process when
		/// executing the above sequence of operations. The <c>CoGetApartmentType</c> function is recommended as it does not potentially
		/// incur the Access Violation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetapartmenttype HRESULT CoGetApartmentType(
		// APTTYPE *pAptType, APTTYPEQUALIFIER *pAptQualifier );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "ab0b6008-397f-4210-ba26-1a041b709722")]
		public static extern HRESULT CoGetApartmentType(out APTTYPE pAptType, out APTTYPEQUALIFIER pAptQualifier);

		/// <summary>Retrieves the context of the current call on the current thread.</summary>
		/// <param name="riid">
		/// Interface identifier (IID) of the call context that is being requested. If you are using the default call context supported by
		/// standard marshaling, IID_IServerSecurity is available. For COM+ applications using role-based security, IID_ISecurityCallContext
		/// is available.
		/// </param>
		/// <param name="ppInterface">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppInterface contains
		/// the requested interface pointer.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The context was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The call context does not support the interface specified by riid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>CoGetCallContext</c> retrieves the context of the current call on the current thread. The riid parameter specifies the
		/// interface on the context to be retrieved. This is one of the functions provided to give the server access to any contextual
		/// information of the caller.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcallcontext HRESULT CoGetCallContext( REFIID
		// riid, void **ppInterface );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "b82e32c0-840d-402e-90d5-ff678c51faf1")]
		public static extern HRESULT CoGetCallContext(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object ppInterface);

		/// <summary>Returns a pointer to a <c>DWORD</c> that contains the apartment ID of the caller's thread.</summary>
		/// <param name="lpdwTID">
		/// Receives the apartment ID of the caller's thread. For a single threaded apartment (STA), this is the current thread ID. For a
		/// multithreaded apartment (MTA), the value is 0. For a neutral apartment (NA), the value is -1.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_TRUE</term>
		/// <term>The caller's thread ID is set and the caller is in the same process.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The caller's thread ID is set and the caller is in a different process.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The caller's thread ID was not set.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the caller is not running on the same computer, this function does not return the apartment ID and the return value is S_FALSE.
		/// </para>
		/// <para>
		/// There is no guarantee that the information returned from this API is not tampered with, so do not use the ID that is returned to
		/// make security decisions. The ID can only be used for logging and diagnostic purposes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcallertid HRESULT CoGetCallerTID( LPDWORD
		// lpdwTID );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "3a34001b-6286-4103-ae9f-700ea101dc17")]
		public static extern HRESULT CoGetCallerTID(out uint lpdwTID);

		/// <summary>
		/// Obtains a pointer to a call control interface, normally ICancelMethodCalls, on the cancel object corresponding to an outbound COM
		/// method call pending on the same or another client thread.
		/// </summary>
		/// <param name="dwThreadId">
		/// The identifier of the thread on which the pending COM call is to be canceled. If this parameter is 0, the call is on the current thread.
		/// </param>
		/// <param name="iid">
		/// The globally unique identifier of an interface on the cancel object for the call to be canceled. This argument is usually IID_ICancelMethodCalls.
		/// </param>
		/// <param name="ppUnk">Receives the address of a pointer to the interface specified by riid.</param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The call control object was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object on which the call is executing does not support the interface specified by riid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If two or more calls are pending on the same thread through nested calls, the thread ID may not be sufficient to identify the
		/// call to be canceled. In this case, <c>CoGetCancelObject</c> returns a cancel interface corresponding to the innermost call that
		/// is pending on the thread and has registered a cancel object.
		/// </para>
		/// <para>This function does not locate cancel objects for asynchronous calls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcancelobject HRESULT CoGetCancelObject( DWORD
		// dwThreadId, REFIID iid, void **ppUnk );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "d38161af-d662-4430-99b7-6563efda6f4e")]
		public static extern HRESULT CoGetCancelObject(uint dwThreadId, in Guid iid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppUnk);

		/// <summary>
		/// <para>
		/// Provides a pointer to an interface on a class object associated with a specified CLSID. <c>CoGetClassObject</c> locates, and if
		/// necessary, dynamically loads the executable code required to do this.
		/// </para>
		/// <para>
		/// Call <c>CoGetClassObject</c> directly to create multiple objects through a class object for which there is a CLSID in the system
		/// registry. You can also retrieve a class object from a specific remote computer. Most class objects implement the IClassFactory
		/// interface. You would then call CreateInstance to create an uninitialized object. It is not always necessary to go through this
		/// process however. To create a single object, call the CoCreateInstanceEx function, which allows you to create an instance on a
		/// remote machine. This replaces the CoCreateInstance function, which can still be used to create an instance on a local computer.
		/// Both functions encapsulate connecting to the class object, creating the instance, and releasing the class object. Two other
		/// functions, CoGetInstanceFromFile and CoGetInstanceFromIStorage, provide both instance creation on a remote system and object
		/// activation. There are numerous functions and interface methods whose purpose is to create objects of a single type and provide a
		/// pointer to an interface on that object.
		/// </para>
		/// </summary>
		/// <param name="rclsid">The CLSID associated with the data and code that you will use to create the objects.</param>
		/// <param name="dwClsContext">
		/// The context in which the executable code is to be run. To enable a remote activation, include CLSCTX_REMOTE_SERVER. For more
		/// information on the context values and their use, see the CLSCTX enumeration.
		/// </param>
		/// <param name="pvReserved">
		/// A pointer to computer on which to instantiate the class object. If this parameter is <c>NULL</c>, the class object is
		/// instantiated on the current computer or at the computer specified under the class's RemoteServerName key, according to the
		/// interpretation of the dwClsCtx parameter. See COSERVERINFO.
		/// </param>
		/// <param name="riid">
		/// Reference to the identifier of the interface, which will be supplied in ppv on successful return. This interface will be used to
		/// communicate with the class object. Typically this value is IID_IClassFactory, although other values â€“ such as
		/// IID_IClassFactory2 which supports a form of licensing â€“ are allowed. All OLE-defined interface IIDs are defined in the OLE
		/// header files as IID_interfacename, where interfacename is the name of the interface.
		/// </param>
		/// <param name="ppv">
		/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppv contains the
		/// requested interface pointer.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Location and connection to the specified class object was successful.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>
		/// The CLSID is not properly registered. This error can also indicate that the value you specified in dwClsContext is not in the registry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>
		/// Either the object pointed to by ppv does not support the interface identified by riid, or the QueryInterface operation on the
		/// class object returned E_NOINTERFACE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading the registration database.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_DLLNOTFOUND</term>
		/// <term>Either the in-process DLL or handler DLL was not found (depending on the context).</term>
		/// </item>
		/// <item>
		/// <term>CO_E_APPNOTFOUND</term>
		/// <term>The executable (.exe) was not found (CLSCTX_LOCAL_SERVER only).</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>There was a general access failure on load.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_ERRORINDLL</term>
		/// <term>There is an error in the executable image.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_APPDIDNTREG</term>
		/// <term>The executable was launched, but it did not register the class object (and it may have shut down).</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A class object in OLE is an intermediate object that supports an interface that permits operations common to a group of objects.
		/// The objects in this group are instances derived from the same object definition represented by a single CLSID. Usually, the
		/// interface implemented on a class object is IClassFactory, through which you can create object instances of a given definition (class).
		/// </para>
		/// <para>
		/// A call to <c>CoGetClassObject</c> creates, initializes, and gives the caller access (through a pointer to an interface specified
		/// with the riid parameter) to the class object. The class object is the one associated with the CLSID that you specify in the
		/// rclsid parameter. The details of how the system locates the associated code and data within a computer are transparent to the
		/// caller, as is the dynamic loading of any code that is not already loaded.
		/// </para>
		/// <para>
		/// If the class context is CLSCTX_REMOTE_SERVER, indicating remote activation is required, the COSERVERINFO structure provided in
		/// the pServerInfo parameter allows you to specify the computer on which the server is located. For information on the algorithm
		/// used to locate a remote server when pServerInfo is <c>NULL</c>, refer to the CLSCTX enumeration.
		/// </para>
		/// <para>There are two places to find a CLSID for a class:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The registry holds an association between CLSIDs and file suffixes, and between CLSIDs and file signatures for determining the
		/// class of an object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>When an object is saved to persistent storage, its CLSID is stored with its data.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To create and initialize embedded or linked OLE document objects, it is not necessary to call <c>CoGetClassObject</c> directly.
		/// Instead, call the OleCreate or <c>OleCreate</c> XXX function. These functions encapsulate the entire object instantiation and
		/// initialization process, and call, among other functions, <c>CoGetClassObject</c>.
		/// </para>
		/// <para>
		/// The riid parameter specifies the interface the client will use to communicate with the class object. In most cases, this
		/// interface is IClassFactory. This provides access to the CreateInstance method, through which the caller can then create an
		/// uninitialized object of the kind specified in its implementation. All classes registered in the system with a CLSID must
		/// implement IClassFactory.
		/// </para>
		/// <para>
		/// In rare cases, however, you may want to specify some other interface that defines operations common to a set of objects. For
		/// example, in the way OLE implements monikers, the interface on the class object is IParseDisplayName, used to transform the
		/// display name of an object into a moniker.
		/// </para>
		/// <para>
		/// The dwClsContext parameter specifies the execution context, allowing one CLSID to be associated with different pieces of code in
		/// different execution contexts. The CLSCTX enumeration specifies the available context flags. <c>CoGetClassObject</c> consults (as
		/// appropriate for the context indicated) both the registry and the class objects that are currently registered by calling the
		/// CoRegisterClassObject function.
		/// </para>
		/// <para>
		/// To release a class object, use the class object's Release method. The function CoRevokeClassObject is to be used only to remove a
		/// class object's CLSID from the system registry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetclassobject HRESULT CoGetClassObject( REFCLSID
		// rclsid, DWORD dwClsContext, LPVOID pvReserved, REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "65e758ce-50a4-49e8-b3b2-0cd148d2781a")]
		public static extern HRESULT CoGetClassObject(in Guid rclsid, CLSCTX dwClsContext, IntPtr pvReserved, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppv);

		/// <summary>Returns a pointer to an implementation of IObjContext for the current context.</summary>
		/// <param name="pToken">A pointer to an implementation of IObjContext for the current context.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The token was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The caller did not pass a valid token pointer variable.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>The caller is not in an initialized apartment.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcontexttoken HRESULT CoGetContextToken(
		// ULONG_PTR *pToken );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "1218d928-ca3f-4bdc-9a00-ea4c214175a9")]
		public static extern HRESULT CoGetContextToken([MarshalAs(UnmanagedType.IUnknown)] out IObjContext pToken);

		/// <summary>Returns the logical thread identifier of the current physical thread.</summary>
		/// <param name="pguid">A pointer to a GUID that contains the logical thread ID on return.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The logical thread ID was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An invalid pointer was passed in for the pguid parameter.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>A memory allocation failed during the operation of the function.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function retrieves the identifier of the current logical thread under which this physical thread is operating. The current
		/// physical thread takes on the logical thread identifier of any client thread that makes a COM call into this application.
		/// Similarly, the logical thread identifier of the current physical thread is used to denote the causality for outgoing COM calls
		/// from this physical thread.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcurrentlogicalthreadid HRESULT
		// CoGetCurrentLogicalThreadId( GUID *pguid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "eced2f1e-9f2b-476c-bea8-945fb4804a89")]
		public static extern HRESULT CoGetCurrentLogicalThreadId(out Guid pguid);

		/// <summary>
		/// Returns a value that is unique to the current thread. <c>CoGetCurrentProcess</c> can be used to avoid thread ID reuse problems.
		/// </summary>
		/// <returns>The function returns the unique identifier of the current thread.</returns>
		/// <remarks>
		/// <para>
		/// Using the value returned from a call to <c>CoGetCurrentProcess</c> can help you in maintaining tables that are keyed by threads
		/// or in uniquely identifying a thread to other threads or processes.
		/// </para>
		/// <para>
		/// <c>CoGetCurrentProcess</c> returns a value that is effectively unique, because it is not used again until 2³² more threads have
		/// been created on the current workstation or until the workstation is restarted.
		/// </para>
		/// <para>
		/// The value returned by <c>CoGetCurrentProcess</c> will uniquely identify the same thread for the life of the caller. Because
		/// thread IDs can be reused without notice as threads are created and destroyed, this value is more reliable than the value returned
		/// by the GetCurrentThreadId function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetcurrentprocess DWORD CoGetCurrentProcess( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "46b0448f-f1c5-4da7-8489-bbd6d0fab79e")]
		public static extern uint CoGetCurrentProcess();

		/// <summary>Retrieves a reference to the default context of the specified apartment.</summary>
		/// <param name="aptType">
		/// <para>The apartment type of the default context that is being requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>APTTYPE_CURRENT -1</term>
		/// <term>The caller's apartment.</term>
		/// </item>
		/// <item>
		/// <term>APTTYPE_MTA 1</term>
		/// <term>The multithreaded apartment for the current process.</term>
		/// </item>
		/// <item>
		/// <term>APTTYPE_NA 2</term>
		/// <term>The neutral apartment for the current process.</term>
		/// </item>
		/// <item>
		/// <term>APTTYPE_MAINSTA 3</term>
		/// <term>The main single-threaded apartment for the current process.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The APTTYPE value APTTYPE_STA (0) is not supported. A process can contain multiple single-threaded apartments, each with its own
		/// context, so <c>CoGetDefaultContext</c> could not determine which STA is of interest. Therefore, this function returns
		/// E_INVALIDARG if APTTYPE_STA is specified.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// The interface identifier (IID) of the interface that is being requested on the default context. Typically, the caller requests
		/// IID_IObjectContext. The default context does not support all of the normal object context interfaces.
		/// </param>
		/// <param name="ppv">
		/// A reference to the interface specified by riid on the default context. If the object's component is non-configured, (that is, the
		/// object's component has not been imported into a COM+ application), or if the <c>CoGetDefaultContext</c> function is called from a
		/// constructor or an IUnknown method, this parameter is set to a <c>NULL</c> pointer.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>The caller is not in an initialized apartment.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object context does not support the interface specified by riid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every COM apartment has a special context called the default context. A default context is different from all the other,
		/// non-default contexts in an apartment because it does not provide runtime services. It does not support all of the normal object
		/// context interfaces.
		/// </para>
		/// <para>
		/// The default context is also used by instances of non-configured COM components, (that is, components that have not been part of a
		/// COM+ application), when they are created from an apartment that does not support their threading model. In other words, if a COM
		/// object creates an instance of a non-configured component and the new object cannot be added to its creator's context because of
		/// its threading model, the new object is instead added to the default context of an apartment that supports its threading model.
		/// </para>
		/// <para>
		/// An object should never pass an IObjectContext reference to another object. If you pass an <c>IObjectContext</c> reference to
		/// another object, it is no longer a valid reference.
		/// </para>
		/// <para>
		/// When an object obtains a reference to an IObjectContext, it must release the <c>IObjectContext</c> object when it is finished
		/// with it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetdefaultcontext HRESULT CoGetDefaultContext(
		// APTTYPE aptType, REFIID riid, void **ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "97a0e7da-e8bb-4bde-a8ba-35c90a1351d2")]
		public static extern HRESULT CoGetDefaultContext(APTTYPE aptType, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);

		/// <summary>
		/// Unmarshals a buffer containing an interface pointer and releases the stream when an interface pointer has been marshaled from
		/// another thread to the calling thread.
		/// </summary>
		/// <param name="pStm">A pointer to the IStream interface on the stream to be unmarshaled.</param>
		/// <param name="iid">A reference to the identifier of the interface requested from the unmarshaled object.</param>
		/// <param name="ppv">
		/// The address of pointer variable that receives the interface pointer requested in <paramref name="iid"/>. Upon successful return,
		/// <paramref name="ppv"/> contains the requested interface pointer to the unmarshaled interface.
		/// </param>
		/// <returns>
		/// This function can return the standard return values S_OK and E_INVALIDARG, as well as any of the values returned by CoUnmarshalInterface.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Important</c> Security Note: Calling this method with untrusted data is a security risk. Call this method only with trusted
		/// data. For more information, see Untrusted Data Security Risks.
		/// </para>
		/// <para>The <c>CoGetInterfaceAndReleaseStream</c> function performs the following tasks:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Calls CoUnmarshalInterface to unmarshal an interface pointer previously passed in a call to CoMarshalInterThreadInterfaceInStream.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Releases the stream pointer. Even if the unmarshaling fails, the stream is still released because there is no effective way to
		/// recover from a failure of this kind.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetinterfaceandreleasestream HRESULT
		// CoGetInterfaceAndReleaseStream( LPSTREAM pStm, REFIID iid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "b529f65f-3208-4594-a772-d1cad3727dc1")]
		public static extern HRESULT CoGetInterfaceAndReleaseStream(IStream pStm, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>
		/// Retrieves a pointer to the default OLE task memory allocator (which supports the system implementation of the IMalloc interface)
		/// so applications can call its methods to manage memory.
		/// </summary>
		/// <param name="dwMemContext">This parameter must be 1.</param>
		/// <param name="ppMalloc">
		/// The address of an <c>IMalloc*</c> pointer variable that receives the interface pointer to the memory allocator.
		/// </param>
		/// <returns>This function can return the standard return values S_OK, E_INVALIDARG, and E_OUTOFMEMORY.</returns>
		/// <remarks>
		/// The pointer to the IMalloc interface pointer received through the ppMalloc parameter cannot be used from a remote process; each
		/// process must have its own allocator.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetmalloc HRESULT CoGetMalloc( DWORD dwMemContext,
		// LPMALLOC *ppMalloc );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "d1d09fbe-ca5c-4480-b807-3afcc043ccb9")]
		public static extern HRESULT CoGetMalloc(uint dwMemContext, out IMalloc ppMalloc);

		/// <summary>
		/// Returns an upper bound on the number of bytes needed to marshal the specified interface pointer to the specified object.
		/// </summary>
		/// <param name="pulSize">
		/// A pointer to the upper-bound value on the size, in bytes, of the data packet to be written to the marshaling stream. If this
		/// parameter is 0, the size of the packet is unknown.
		/// </param>
		/// <param name="riid">
		/// A reference to the identifier of the interface whose pointer is to be marshaled. This interface must be derived from the IUnknown interface.
		/// </param>
		/// <param name="pUnk">A pointer to the interface to be marshaled. This interface must be derived from the IUnknown interface.</param>
		/// <param name="dwDestContext">
		/// The destination context where the specified interface is to be unmarshaled. Values for dwDestContext come from the enumeration MSHCTX.
		/// </param>
		/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="mshlflags">
		/// Indicates whether the data to be marshaled is to be transmitted back to the client processthe normal case or written to a global
		/// table, where it can be retrieved by multiple clients. Values come from the enumeration MSHLFLAGS.
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The upper bound was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>Before this function can be called, either the CoInitialize or OleInitialize function must be called.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Queries the object for an IMarshal pointer or, if the object does not implement <c>IMarshal</c>, gets a pointer to COM's standard marshaler.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Using the pointer obtained in the preceding item, calls IMarshal::GetMarshalSizeMax.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Adds to the value returned by the call to GetMarshalSizeMax the size of the marshaling data header and, possibly, that of the
		/// proxy CLSID to obtain the maximum size in bytes of the amount of data to be written to the marshaling stream.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You do not explicitly call this function unless you are implementing IMarshal, in which case your marshaling stub should call
		/// this function to get the correct size of the data packet to be marshaled.
		/// </para>
		/// <para>
		/// The value returned by this method is guaranteed to be valid only as long as the internal state of the object being marshaled does
		/// not change. Therefore, the actual marshaling should be done immediately after this function returns, or the stub runs the risk
		/// that the object, because of some change in state, might require more memory to marshal than it originally indicated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetmarshalsizemax HRESULT CoGetMarshalSizeMax(
		// ULONG *pulSize, REFIID riid, LPUNKNOWN pUnk, DWORD dwDestContext, LPVOID pvDestContext, DWORD mshlflags );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c04c736c-8efe-438b-9d21-8b6ad53d36e7")]
		public static extern HRESULT CoGetMarshalSizeMax(ref uint pulSize, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
			MSHCTX dwDestContext, [Optional] IntPtr pvDestContext, MSHLFLAGS mshlflags);

		/// <summary>Returns the context for the current object.</summary>
		/// <param name="riid">
		/// <para>A reference to the ID of an interface that is implemented on the context object.</para>
		/// <para>For objects running within COM applications, IID_IComThreadingInfo, IID_IContext, and IID_IContextCallback are available.</para>
		/// <para>
		/// For objects running within COM+ applications, IID_IObjectContext, IID_IObjectContextActivity IID_IObjectContextInfo, and
		/// IID_IContextState are available.
		/// </para>
		/// </param>
		/// <param name="ppv">The address of a pointer to the interface specified by riid on the context object.</param>
		/// <returns>
		/// <para>This function can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The object context was successfully retrieved.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The requested interface was not available.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>Before this function can be called, the CoInitializeEx function must be called on the current thread.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoGetObjectContext</c> retrieves the context for the object from which it is called, and returns a pointer to an interface
		/// that can be used to manipulate context properties. Context properties are used to provide services to configured components
		/// running within COM+ applications.
		/// </para>
		/// <para>
		/// For components running within COM applications, the following interfaces are supported for accessing context properties:
		/// IComThreadingInfo, IContext, and IContextCallback.
		/// </para>
		/// <para>
		/// For components running within COM+ applications, the following interfaces are supported for accessing context properties:
		/// IObjectContext, IObjectContextActivity, IObjectContextInfo, and IContextState.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetobjectcontext HRESULT CoGetObjectContext(
		// REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "97a0c6c3-a011-44dc-b428-aabdad7d4364")]
		public static extern HRESULT CoGetObjectContext(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object ppv);

		/// <summary>Returns the CLSID of the DLL that implements the proxy and stub for the specified interface.</summary>
		/// <param name="riid">The interface whose proxy/stub CLSID is to be returned.</param>
		/// <param name="pClsid">Specifies where to store the proxy/stub CLSID for the interface specified by riid.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The proxy/stub CLSID was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to complete this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>CoGetPSClsid</c> function looks at the <c>HKEY_CLASSES_ROOT</c>&lt;b&gt;Interfaces&lt;i&gt;{string form of
		/// riid}&lt;b&gt;ProxyStubClsid32 key in the registry to determine the CLSID of the DLL to load in order to create the proxy and
		/// stub for the interface specified by riid. This function also returns the CLSID for any interface IID registered by
		/// CoRegisterPSClsid within the current process.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetpsclsid HRESULT CoGetPSClsid( REFIID riid,
		// CLSID *pClsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "dfe6b514-a80a-4adb-bf43-d9a7d0e5f4a3")]
		public static extern HRESULT CoGetPSClsid(in Guid riid, out Guid pClsid);

		/// <summary>
		/// Creates a default, or standard, marshaling object in either the client process or the server process, depending on the caller,
		/// and returns a pointer to that object's IMarshal implementation.
		/// </summary>
		/// <param name="riid">
		/// A reference to the identifier of the interface whose pointer is to be marshaled. This interface must be derived from the IUnknown interface.
		/// </param>
		/// <param name="pUnk">A pointer to the interface to be marshaled.</param>
		/// <param name="dwDestContext">
		/// The destination context where the specified interface is to be unmarshaled. Values come from the enumeration MSHCTX. Unmarshaling
		/// can occur either in another apartment of the current process (MSHCTX_INPROC) or in another process on the same computer as the
		/// current process (MSHCTX_LOCAL).
		/// </param>
		/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="mshlflags">
		/// Indicates whether the data to be marshaled is to be transmitted back to the client process (the normal case) or written to a
		/// global table where it can be retrieved by multiple clients. Values come from the MSHLFLAGS enumeration.
		/// </param>
		/// <param name="ppMarshal">
		/// The address of <c>IMarshal*</c> pointer variable that receives the interface pointer to the standard marshaler.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The IMarshal instance was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>Before this function can be called, the CoInitialize or OleInitialize function must be called on the current thread.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoGetStandardMarshal</c> function creates a default, or standard, marshaling object in either the client process or the
		/// server process, as may be necessary, and returns that object's IMarshal pointer to the caller. If you implement <c>IMarshal</c>,
		/// you may want your implementation to call <c>CoGetStandardMarshal</c> as a way of delegating to COM's default implementation any
		/// destination contexts that you do not fully understand or want to handle. Otherwise, you can ignore this function, which COM calls
		/// as part of its internal marshaling procedures.
		/// </para>
		/// <para>
		/// When the COM library in the client process receives a marshaled interface pointer, it looks for a CLSID to be used in creating a
		/// proxy for the purposes of unmarshaling the packet. If the packet does not contain a CLSID for the proxy, COM calls
		/// <c>CoGetStandardMarshal</c>, passing a <c>NULL</c> pUnk value. This function creates a standard proxy in the client process and
		/// returns a pointer to that proxy's implementation of IMarshal. COM uses this pointer to call CoUnmarshalInterface to retrieve the
		/// pointer to the requested interface.
		/// </para>
		/// <para>
		/// If your OLE server application's implementation of IMarshal calls <c>CoGetStandardMarshal</c>, you should pass both the IID of
		/// (riid), and a pointer to (pUnk), the interface being requested.
		/// </para>
		/// <para>This function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>Determines whether pUnk is <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If pUnk is <c>NULL</c>, creates a standard interface proxy in the client process for the specified riid and returns the proxy's
		/// IMarshal pointer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If pUnk is not <c>NULL</c>, checks to see if a marshaler for the object already exists, creates a new one if necessary, and
		/// returns the marshaler's IMarshal pointer.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetstandardmarshal HRESULT CoGetStandardMarshal(
		// REFIID riid, LPUNKNOWN pUnk, DWORD dwDestContext, LPVOID pvDestContext, DWORD mshlflags, LPMARSHAL *ppMarshal );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "0cb74adc-e192-4ae5-9267-02c79e301681")]
		public static extern HRESULT CoGetStandardMarshal(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk,
			MSHCTX dwDestContext, [Optional] IntPtr pvDestContext, MSHLFLAGS mshlflags, out IMarshal ppMarshal);

		/// <summary>Creates an aggregated standard marshaler for use with lightweight client-side handlers.</summary>
		/// <param name="pUnkOuter">A pointer to the controlling IUnknown.</param>
		/// <param name="smexflags">
		/// <para>
		/// One of two values indicating whether the aggregated standard marshaler is on the client side or the server side. These flags are
		/// defined in the <c>STDMSHLFLAGS</c> enumeration.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SMEXF_SERVER 0x01</term>
		/// <term>Indicates a server-side aggregated standard marshaler.</term>
		/// </item>
		/// <item>
		/// <term>SMEXF_HANDLER 0x0</term>
		/// <term>Indicates a client-side (handler) aggregated standard marshaler.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppUnkInner">
		/// On successful return, address of pointer to the IUnknown interface on the newly-created aggregated standard marshaler. If an
		/// error occurs, this value is <c>NULL</c>.
		/// </param>
		/// <returns>This function returns S_OK.</returns>
		/// <remarks>
		/// The server calls <c>CoGetStdMarshalEx</c> passing in the flag SMEXF_SERVER. This creates a server side standard marshaler (known
		/// as a stub manager). The handler calls <c>CoGetStdMarshalEx</c> passing in the flag SMEXF_HANDLER. This creates a client side
		/// standard marshaler (known as a proxy manager). Note that when calling this function, the handler must pass the original
		/// controlling unknown that was passed to the handler when the handler was created. This will be the system implemented controlling
		/// unknown. Failure to pass the correct IUnknown results in an error returned. On success, the ppUnkInner returned is the
		/// controlling unknown of the inner object. The server and handler must keep this pointer, and may use it to call
		/// IUnknown::QueryInterface for the IMarshal interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetstdmarshalex HRESULT CoGetStdMarshalEx(
		// LPUNKNOWN pUnkOuter, DWORD smexflags, LPUNKNOWN *ppUnkInner );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "405c5ff3-8702-48b3-9be9-df4a9461696e")]
		public static extern HRESULT CoGetStdMarshalEx([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, STDMSHLFLAGS smexflags,
			[MarshalAs(UnmanagedType.IUnknown)] out object ppUnkInner);

		/// <summary>Returns the CLSID of an object that can emulate the specified object.</summary>
		/// <param name="clsidOld">The CLSID of the object that can be emulated (treated as) an object with a different CLSID.</param>
		/// <param name="pClsidNew">
		/// A pointer to where the CLSID that can emulate clsidOld objects is retrieved. This parameter cannot be <c>NULL</c>. If there is no
		/// emulation information for clsidOld objects, the clsidOld parameter is supplied.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values, as well as any error values returned by the CLSIDFromString function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>A new CLSID was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>There is no emulation information for the clsidOld parameter, so the pClsidNew parameter is set to clsidOld.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>CoGetTreatAsClass</c> returns the TreatAs entry in the registry for the specified object. The <c>TreatAs</c> entry, if set, is
		/// the CLSID of a registered object (an application) that can emulate the object in question. The <c>TreatAs</c> entry is set
		/// through a call to the CoTreatAsClass function. Emulation allows an application to open and edit an object of a different format,
		/// while retaining the original format of the object. Objects of the original CLSID are activated and treated as objects of the
		/// second CLSID. When the object is saved, this may result in loss of edits not supported by the original format. If there is no
		/// <c>TreatAs</c> entry for the specified object, this function returns the CLSID of the original object (clsidOld).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogettreatasclass HRESULT CoGetTreatAsClass(
		// REFCLSID clsidOld, LPCLSID pClsidNew );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "f95fefe6-dc37-45f4-93be-87c996990ab9")]
		public static extern HRESULT CoGetTreatAsClass(in Guid clsidOld, out Guid pClsidNew);

		/// <summary>Enables the server to impersonate the client of the current call for the duration of the call.</summary>
		/// <returns>This function supports the standard return values, including S_OK.</returns>
		/// <remarks>
		/// <para>
		/// This method allows the server to impersonate the client of the current call for the duration of the call. If you do not call
		/// CoRevertToSelf, COM reverts automatically for you. This function will fail unless the object is being called with
		/// RPC_C_AUTHN_LEVEL_CONNECT or higher authentication in effect (which is any authentication level except RPC_C_AUTHN_LEVEL_NONE).
		/// This function encapsulates the following sequence of common calls (error handling excluded):
		/// </para>
		/// <para>
		/// <c>CoImpersonateClient</c> encapsulates the process of getting a pointer to an instance of IServerSecurity that contains data
		/// about the current call, calling its ImpersonateClient method, and then releasing the pointer. One call to CoRevertToSelf (or
		/// IServerSecurity::RevertToSelf) will undo any number of calls to impersonate the client.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coimpersonateclient HRESULT CoImpersonateClient( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a3cbfbbc-fc6f-4d1b-8460-1e3351cd32d7")]
		public static extern HRESULT CoImpersonateClient();

		/// <summary>Keeps MTA support active when no MTA threads are running.</summary>
		/// <param name="pCookie">
		/// Address of a <c>PVOID</c> variable that receives the cookie for the CoDecrementMTAUsage function, or <c>NULL</c> if the call fails.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CoIncrementMTAUsage</c> function enables clients to create MTA workers and wait on them for completion before exiting the process.
		/// </para>
		/// <para>
		/// The <c>CoIncrementMTAUsage</c> function ensures that the system doesn't free resources related to MTA support., even if the MTA
		/// thread count goes to 0.
		/// </para>
		/// <para>On success, call the CoDecrementMTAUsage once only. On failure, don't call the <c>CoDecrementMTAUsage</c> function.</para>
		/// <para>
		/// Don't call <c>CoIncrementMTAUsage</c> during process shutdown or inside dllmain. You can call <c>CoIncrementMTAUsage</c> before
		/// the call to start the shutdown process.
		/// </para>
		/// <para>
		/// You can call <c>CoIncrementMTAUsage</c> from one thread and CoDecrementMTAUsage from another as long as a cookie previously
		/// returned by <c>CoIncrementMTAUsage</c> is passed to <c>CoDecrementMTAUsage</c>.
		/// </para>
		/// <para>
		/// <c>CoIncrementMTAUsage</c> creates the MTA, if the MTA does not already exist. <c>CoIncrementMTAUsage</c> puts the current thread
		/// into the MTA, if the current thread is not already in an apartment
		/// </para>
		/// <para>You can use <c>CoIncrementMTAUsage</c> when:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>You want a server to keep the MTA alive even when all worker threads are idle.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Your API implementation requires COM to be initialized, but has no information about whether the current thread is already in an
		/// apartment, and does not need the current thread to go into a particular apartment.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coincrementmtausage HRESULT CoIncrementMTAUsage(
		// CO_MTA_USAGE_COOKIE *pCookie );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "EFE6E66A-96A3-4B51-92DD-1CE84B1F0185")]
		public static extern HRESULT CoIncrementMTAUsage(out CO_MTA_USAGE_COOKIE pCookie);

		/// <summary>
		/// <para>Tells the service control manager to flush any cached RPC binding handles for the specified computer.</para>
		/// <para>Only administrators may call this function.</para>
		/// </summary>
		/// <param name="pszMachineName">
		/// The computer name for which binding handles should be flushed, or an empty string to signify that all handles in the cache should
		/// be flushed.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates success.</term>
		/// </item>
		/// <item>
		/// <term>CO_S_MACHINENAMENOTFOUND</term>
		/// <term>
		/// Indicates that the specified computer name was not found or that the binding handle cache was empty, indicating that an empty
		/// string was passed instead of a specific computer name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>Indicates the caller was not an administrator for this computer.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Indicates that a NULL value was passed for pszMachineName.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The OLE Service Control Manager is used by COM to send component activation requests to other machines. To do this, the OLE
		/// Service Control Manager maintains a cache of RPC binding handles to send activation requests to computer, keyed by computer name.
		/// Under normal circumstances, this works well, but in some scenarios, such as Web farms and load-balancing situations, the ability
		/// to purge this cache of specific handles might be needed in order to facilitate rebinding to a different physical server by the
		/// same name. <c>CoInvalidateRemoteMachineBindings</c> is used for this purpose.
		/// </para>
		/// <para>
		/// The OLE Service Control Manager will flush unused binding handles over time. It is not necessary to call
		/// <c>CoInvalidateRemoteMachineBindings</c> to do this.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coinvalidateremotemachinebindings HRESULT
		// CoInvalidateRemoteMachineBindings( LPOLESTR pszMachineName );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "6d0fa512-a9e9-44ff-929d-00b9c826da99")]
		public static extern HRESULT CoInvalidateRemoteMachineBindings([In, MarshalAs(UnmanagedType.LPWStr)] string pszMachineName);

		/// <summary>Determines whether a remote object is connected to the corresponding in-process object.</summary>
		/// <param name="pUnk">A pointer to the controlling IUnknown interface on the remote object.</param>
		/// <returns>
		/// If the object is not remote or if it is remote and still connected, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.
		/// </returns>
		/// <remarks>
		/// The <c>CoIsHandlerConnected</c> function determines the status of a remote object. You can use it to determine when to release a
		/// remote object. You specify the remote object by giving the function a pointer to its controlling IUnknown interface (the pUnk
		/// parameter). A value of <c>TRUE</c> returned from the function indicates either that the specified object is not remote, or that
		/// it is remote and is still connected to its remote handler. A value of <c>FALSE</c> returned from the function indicates that the
		/// object is remote but is no longer connected to its remote handler; in this case, the caller should respond by releasing the object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coishandlerconnected BOOL CoIsHandlerConnected(
		// LPUNKNOWN pUnk );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "f58bdec6-3709-439d-9867-0022a069c53d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CoIsHandlerConnected([In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);

		/// <summary>Called either to lock an object to ensure that it stays in memory, or to release such a lock.</summary>
		/// <param name="pUnk">A pointer to the IUnknown interface on the object to be locked or unlocked.</param>
		/// <param name="fLock">
		/// Indicates whether the object is to be locked or released. If this parameter is <c>TRUE</c>, the object is kept in memory,
		/// independent of <c>AddRef</c>/ <c>Release</c> operations, registrations, or revocations. If this parameter is <c>FALSE</c>, the
		/// lock previously set with a call to this function is released.
		/// </param>
		/// <param name="fLastUnlockReleases">
		/// <para>
		/// If the lock is the last reference that is supposed to keep an object alive, specify <c>TRUE</c> to release all pointers to the
		/// object (there may be other references that are not supposed to keep it alive). Otherwise, specify <c>FALSE</c>.
		/// </para>
		/// <para>If fLock is <c>TRUE</c>, this parameter is ignored.</para>
		/// </param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CoLockObjectExternal</c> function must be called in the process in which the object actually resides (the EXE process, not
		/// the process in which handlers may be loaded).
		/// </para>
		/// <para>
		/// The <c>CoLockObjectExternal</c> function prevents the reference count of an object from going to zero, thereby "locking" it into
		/// existence until the lock is released. The same function (with different parameters) releases the lock. The lock is implemented by
		/// having the system call IUnknown::AddRef on the object. The system then waits to call IUnknown::Release on the object until a
		/// later call to <c>CoLockObjectExternal</c> with fLock set to <c>FALSE</c>. This function can be used to maintain a reference count
		/// on the object on behalf of the end user, because it acts outside of the object, as does the user.
		/// </para>
		/// <para>
		/// The end user has explicit control over the lifetime of an application, even if there are external locks on it. That is, if a user
		/// decides to close the application, it must shut down. In the presence of external locks (such as the lock set by
		/// <c>CoLockObjectExternal</c>), the application can call the CoDisconnectObject function to force these connections to close prior
		/// to shutdown.
		/// </para>
		/// <para>
		/// Calling <c>CoLockObjectExternal</c> sets a strong lock on an object. A strong lock keeps an object in memory, while a weak lock
		/// does not. Strong locks are required, for example, during a silent update to an OLE embedding. The embedded object's container
		/// must remain in memory until the update process is complete. There must also be a strong lock on an application object to ensure
		/// that the application stays alive until it has finished providing services to its clients. All external references place a strong
		/// reference lock on an object.
		/// </para>
		/// <para>The <c>CoLockObjectExternal</c> function is typically called in the following situations:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Object servers should call <c>CoLockObjectExternal</c> with both fLock and fLastLockReleases set to <c>TRUE</c> when they become
		/// visible. This call creates a strong lock on behalf of the user. When the application is closing, free the lock with a call to
		/// <c>CoLockObjectExternal</c>, setting fLock to <c>FALSE</c> and fLastLockReleases to <c>TRUE</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A call to <c>CoLockObjectExternal</c> on the server can also be used in the implementation of IOleContainer::LockContainer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// There are several things to be aware of when you use <c>CoLockObjectExternal</c> in the implementation of LockContainer. An
		/// embedded object would call <c>LockContainer</c> on its container to keep it running (to lock it) in the absence of other reasons
		/// to keep it running. When the embedded object becomes visible, the container must weaken its connection to the embedded object
		/// with a call to the OleSetContainedObject function, so other connections can affect the object.
		/// </para>
		/// <para>
		/// Unless an application manages all aspects of its application and document shutdown completely with calls to
		/// <c>CoLockObjectExternal</c>, the container must keep a private lock count in LockContainer so that it exits when the lock count
		/// reaches zero and the container is invisible. Maintaining all aspects of shutdown, and thereby avoiding keeping a private lock
		/// count, means that <c>CoLockObjectExternal</c> should be called whenever one of the following conditions occur:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>A document is created and destroyed or made visible or invisible.</term>
		/// </item>
		/// <item>
		/// <term>An application is started and shut down by the user.</term>
		/// </item>
		/// <item>
		/// <term>A pseudo-object is created and destroyed.</term>
		/// </item>
		/// </list>
		/// <para>For debugging purposes, it may be useful to keep a count of the number of external locks (and unlocks) set on the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-colockobjectexternal HRESULT CoLockObjectExternal(
		// LPUNKNOWN pUnk, BOOL fLock, BOOL fLastUnlockReleases );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "36eb55f1-06de-49ad-8a8d-91693ca92e99")]
		public static extern HRESULT CoLockObjectExternal([In, MarshalAs(UnmanagedType.IUnknown)] object pUnk,
			[MarshalAs(UnmanagedType.Bool)] bool fLock, [MarshalAs(UnmanagedType.Bool)] bool fLastUnlockReleases);

		/// <summary>
		/// <para>Marshals an <c>HRESULT</c> to the specified stream, from which it can be unmarshaled using the CoUnmarshalHresult function.</para>
		/// </summary>
		/// <param name="pstm">
		/// <para>A pointer to the marshaling stream. See IStream.</para>
		/// </param>
		/// <param name="hresult">
		/// <para>The <c>HRESULT</c> in the originating process.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The HRESULT was marshaled successfully.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPOINTER</term>
		/// <term>A bad pointer was specified for pstm.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_MEDIUMFULL</term>
		/// <term>The medium is full.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An <c>HRESULT</c> is process-specific, so an <c>HRESULT</c> that is valid in one process might not be valid in another. If you
		/// are writing your own implementation of IMarshal and need to marshal an <c>HRESULT</c> from one process to another, either as a
		/// parameter or a return code, you must call this function. In other circumstances, you will have no need to call this function.
		/// </para>
		/// <para>This function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>Writes an <c>HRESULT</c> to a stream.</term>
		/// </item>
		/// <item>
		/// <term>Returns an IStream pointer to that stream.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-comarshalhresult HRESULT CoMarshalHresult( LPSTREAM
		// pstm, HRESULT hresult );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "37aaf404-49ca-4881-a369-44c5288abf1d")]
		public static extern HRESULT CoMarshalHresult(IStream pstm, HRESULT hresult);

		/// <summary>Writes into a stream the data required to initialize a proxy object in some client process.</summary>
		/// <param name="pStm">A pointer to the stream to be used during marshaling. See IStream.</param>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be marshaled. This interface must be derived from the IUnknown interface.
		/// </param>
		/// <param name="pUnk">A pointer to the interface to be marshaled. This interface must be derived from the IUnknown interface.</param>
		/// <param name="dwDestContext">
		/// The destination context where the specified interface is to be unmarshaled. The possible values come from the enumeration MSHCTX.
		/// Currently, unmarshaling can occur in another apartment of the current process (MSHCTX_INPROC), in another process on the same
		/// computer as the current process (MSHCTX_LOCAL), or in a process on a different computer (MSHCTX_DIFFERENTMACHINE).
		/// </param>
		/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="mshlflags">
		/// The flags that specify whether the data to be marshaled is to be transmitted back to the client process (the typical case) or
		/// written to a global table, where it can be retrieved by multiple clients. The possibles values come from the MSHLFLAGS enumeration.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_OUTOFMEMORY, and E_UNEXPECTED, the stream-access error values
		/// returned by IStream, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The HRESULT was marshaled successfully.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>The CoInitialize or OleInitialize function was not called on the current thread before this function was called.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CoMarshalInterface</c> function marshals the interface referred to by riid on the object whose IUnknown implementation is
		/// pointed to by pUnk. To do so, the <c>CoMarshalInterface</c> function performs the following tasks:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Queries the object for a pointer to the IMarshal interface. If the object does not implement <c>IMarshal</c>, meaning that it
		/// relies on COM to provide marshaling support, <c>CoMarshalInterface</c> gets a pointer to COM's default implementation of <c>IMarshal</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Gets the CLSID of the object's proxy by calling IMarshal::GetUnmarshalClass, using whichever IMarshal interface pointer has been returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Writes the CLSID of the proxy to the stream to be used for marshaling.</term>
		/// </item>
		/// <item>
		/// <term>Marshals the interface pointer by calling IMarshal::MarshalInterface.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The COM library in the client process calls the CoUnmarshalInterface function to extract the data and initialize the proxy.
		/// Before calling <c>CoUnmarshalInterface</c>, seek back to the original position in the stream.
		/// </para>
		/// <para>
		/// If you are implementing existing COM interfaces or defining your own interfaces using the Microsoft Interface Definition Language
		/// (MIDL), the MIDL-generated proxies and stubs call <c>CoMarshalInterface</c> for you. If you are writing your own proxies and
		/// stubs, your proxy code and stub code should each call <c>CoMarshalInterface</c> to correctly marshal interface pointers. Calling
		/// IMarshal directly from your proxy and stub code is not recommended.
		/// </para>
		/// <para>
		/// If you are writing your own implementation of IMarshal, and your proxy needs access to a private object, you can include an
		/// interface pointer to that object as part of the data you write to the stream. In such situations, if you want to use COM's
		/// default marshaling implementation when passing the interface pointer, you can call <c>CoMarshalInterface</c> on the object to do so.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-comarshalinterface HRESULT CoMarshalInterface(
		// LPSTREAM pStm, REFIID riid, LPUNKNOWN pUnk, DWORD dwDestContext, LPVOID pvDestContext, DWORD mshlflags );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "04ca1217-eac1-43e2-b736-8d7522ce8592")]
		public static extern HRESULT CoMarshalInterface(IStream pStm, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] object pUnk, MSHCTX dwDestContext, [Optional] IntPtr pvDestContext, MSHLFLAGS mshlflags);

		/// <summary>Marshals an interface pointer from one thread to another thread in the same process.</summary>
		/// <param name="riid">A reference to the identifier of the interface to be marshaled.</param>
		/// <param name="pUnk">A pointer to the interface to be marshaled, which must be derived from IUnknown. This parameter can be <c>NULL</c>.</param>
		/// <param name="ppStm">
		/// The address of the IStream* pointer variable that receives the interface pointer to the stream that contains the marshaled interface.
		/// </param>
		/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CoMarshalInterThreadInterfaceInStream</c> function enables an object to easily and reliably marshal an interface pointer
		/// to another thread in the same process. The stream returned in the ppStm parameter is guaranteed to behave correctly when a client
		/// running in the receiving thread attempts to unmarshal the pointer. The client can then call the CoGetInterfaceAndReleaseStream to
		/// unmarshal the interface pointer and release the stream object.
		/// </para>
		/// <para>The <c>CoMarshalInterThreadInterfaceInStream</c> function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>Creates a stream object.</term>
		/// </item>
		/// <item>
		/// <term>Passes the stream object's IStream pointer to CoMarshalInterface.</term>
		/// </item>
		/// <item>
		/// <term>Returns the IStream pointer to the caller.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-comarshalinterthreadinterfaceinstream HRESULT
		// CoMarshalInterThreadInterfaceInStream( REFIID riid, LPUNKNOWN pUnk, LPSTREAM *ppStm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c9ab8713-8604-4f0b-a11b-bdfb7d595d95")]
		public static extern HRESULT CoMarshalInterThreadInterfaceInStream(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk, out IStream ppStm);

		/// <summary>Retrieves a list of the authentication services registered when the process called CoInitializeSecurity.</summary>
		/// <param name="pcAuthSvc">A pointer to a variable that receives the number of entries returned in the asAuthSvc array.</param>
		/// <param name="asAuthSvc">
		/// A pointer to an array of SOLE_AUTHENTICATION_SERVICE structures. The list is allocated through a call to the CoTaskMemAlloc
		/// function. The caller must free the list when finished with it by calling the CoTaskMemFree function.
		/// </param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// <c>CoQueryAuthenticationServices</c> retrieves a list of the authentication services currently registered. If the process calls
		/// CoInitializeSecurity, these are the services registered through that call. If the application does not call it,
		/// <c>CoInitializeSecurity</c> is called automatically by COM, registering the default security package, the first time an interface
		/// is marshaled or unmarshaled.
		/// </para>
		/// <para>
		/// This function returns only the authentication services registered with CoInitializeSecurity. It does not return all of the
		/// authentication services installed on the computer, but EnumerateSecurityPackages does. <c>CoQueryAuthenticationServices</c> is
		/// primarily useful for custom marshalers, to determine which principal names an application can use.
		/// </para>
		/// <para>
		/// Different authentication services support different levels of security. For example, NTLMSSP does not support delegation or
		/// mutual authentication while Kerberos does. The application is responsible only for registering authentication services that
		/// provide the features the application needs. This function provides a way to find out which services have been registered with CoInitializeSecurity.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coqueryauthenticationservices HRESULT
		// CoQueryAuthenticationServices( DWORD *pcAuthSvc, SOLE_AUTHENTICATION_SERVICE **asAuthSvc );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "e9e7c5a3-70ec-4a68-ac21-1ab6774d140f")]
		public static extern HRESULT CoQueryAuthenticationServices(out uint pcAuthSvc, out SafeCoTaskMemHandle asAuthSvc);

		/// <summary>Retrieves a list of the authentication services registered when the process called CoInitializeSecurity.</summary>
		/// <returns>
		/// An array of SOLE_AUTHENTICATION_SERVICE structures.
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoQueryAuthenticationServices</c> retrieves a list of the authentication services currently registered. If the process calls
		/// CoInitializeSecurity, these are the services registered through that call. If the application does not call it,
		/// <c>CoInitializeSecurity</c> is called automatically by COM, registering the default security package, the first time an interface
		/// is marshaled or unmarshaled.
		/// </para>
		/// <para>
		/// This function returns only the authentication services registered with CoInitializeSecurity. It does not return all of the
		/// authentication services installed on the computer, but EnumerateSecurityPackages does. <c>CoQueryAuthenticationServices</c> is
		/// primarily useful for custom marshalers, to determine which principal names an application can use.
		/// </para>
		/// <para>
		/// Different authentication services support different levels of security. For example, NTLMSSP does not support delegation or
		/// mutual authentication while Kerberos does. The application is responsible only for registering authentication services that
		/// provide the features the application needs. This function provides a way to find out which services have been registered with CoInitializeSecurity.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coqueryauthenticationservices HRESULT
		[PInvokeData("combaseapi.h", MSDNShortId = "e9e7c5a3-70ec-4a68-ac21-1ab6774d140f")]
		public static SOLE_AUTHENTICATION_SERVICE[] CoQueryAuthenticationServices() { CoQueryAuthenticationServices(out var c, out var a).ThrowIfFailed(); return a.ToArray<SOLE_AUTHENTICATION_SERVICE>((int)c); }

		/// <summary>
		/// Called by the server to find out about the client that invoked the method executing on the current thread. This is a helper
		/// function for IServerSecurity::QueryBlanket.
		/// </summary>
		/// <param name="pAuthnSvc">
		/// A pointer to a variable that receives the current authentication service. This will be a single value taken from the
		/// authentication service constants. If the caller specifies <c>NULL</c>, the current authentication service is not retrieved.
		/// </param>
		/// <param name="pAuthzSvc">
		/// A pointer to a variable that receives the current authorization service. This will be a single value taken from the authorization
		/// constants. If the caller specifies <c>NULL</c>, the current authorization service is not retrieved.
		/// </param>
		/// <param name="pServerPrincName">The string builder.</param>
		/// <param name="pAuthnLevel">
		/// A pointer to a variable that receives the current authentication level. This will be a single value taken from the authentication
		/// level constants. If the caller specifies <c>NULL</c>, the current authentication level is not retrieved.
		/// </param>
		/// <param name="pImpLevel">This parameter must be <c>NULL</c>.</param>
		/// <param name="pPrivs">
		/// A pointer to a handle that receives the privilege information for the client application. The format of the structure that the
		/// handle refers to depends on the authentication service. The application should not write or free the memory. The information is
		/// valid only for the duration of the current call. For NTLMSSP and Kerberos, this is a string identifying the client principal. For
		/// Schannel, this is a CERT_CONTEXT structure that represents the client's certificate. If the client has no certificate,
		/// <c>NULL</c> is returned. If the caller specifies <c>NULL</c>, the current privilege information is not retrieved. See RPC_AUTHZ_HANDLE.
		/// </param>
		/// <param name="pCapabilities">
		/// A pointer to return flags indicating capabilities of the call. To request that the principal name be returned in fullsic form if
		/// Schannel is the authentication service, the caller can set the EOAC_MAKE_FULLSIC flag in this parameter. If the caller specifies
		/// <c>NULL</c>, the current capabilities are not retrieved.
		/// </param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// <c>CoQueryClientBlanket</c> is called by the server to get security information about the client that invoked the method
		/// executing on the current thread. This function encapsulates the following sequence of common calls (error handling excluded):
		/// </para>
		/// <para>
		/// This sequence calls CoGetCallContext to get a pointer to IServerSecurity and, with the resulting pointer, calls
		/// IServerSecurity::QueryBlanket and then releases the pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coqueryclientblanket HRESULT CoQueryClientBlanket(
		// DWORD *pAuthnSvc, DWORD *pAuthzSvc, LPOLESTR *pServerPrincName, DWORD *pAuthnLevel, DWORD *pImpLevel, RPC_AUTHZ_HANDLE *pPrivs,
		// DWORD *pCapabilities );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "58a2c121-c324-4c33-aaca-490b5a09738c")]
		public static extern HRESULT CoQueryClientBlanket(out RPC_C_AUTHN pAuthnSvc, out RPC_C_AUTHZ pAuthzSvc, [MarshalAs(UnmanagedType.LPWStr)] out string pServerPrincName,
			out RPC_C_AUTHN_LEVEL pAuthnLevel, out RPC_C_IMP_LEVEL pImpLevel, out RPC_AUTHZ_HANDLE pPrivs, ref EOLE_AUTHENTICATION_CAPABILITIES pCapabilities);

		/// <summary>
		/// Retrieves the authentication information the client uses to make calls on the specified proxy. This is a helper function for IClientSecurity::QueryBlanket.
		/// </summary>
		/// <param name="pProxy">
		/// A pointer indicating the proxy to query. This parameter cannot be <c>NULL</c>. For more information, see the Remarks section.
		/// </param>
		/// <param name="pwAuthnSvc">
		/// A pointer to a variable that receives the current authentication level. This will be a single value taken from the authentication
		/// level constants. If the caller specifies <c>NULL</c>, the current authentication level is not retrieved.
		/// </param>
		/// <param name="pAuthzSvc">
		/// A pointer to a variable that receives the current authorization service. This will be a single value taken from the authorization
		/// constants. If the caller specifies <c>NULL</c>, the current authorization service is not retrieved.
		/// </param>
		/// <param name="pServerPrincName">
		/// The current principal name. The string will be allocated by the callee using CoTaskMemAlloc, and must be freed by the caller
		/// using CoTaskMemFree. The EOAC_MAKE_FULLSIC flag is not accepted in the pCapabilities parameter. For more information about the
		/// msstd and fullsic forms, see Principal Names. If the caller specifies <c>NULL</c>, the current principal name is not retrieved.
		/// </param>
		/// <param name="pAuthnLevel">
		/// A pointer to a variable that receives the current authentication level. This will be a single value taken from the authentication
		/// level constants. If the caller specifies <c>NULL</c>, the current authentication level is not retrieved.
		/// </param>
		/// <param name="pImpLevel">
		/// A pointer to a variable that receives the current impersonation level. This will be a single value taken from the impersonation
		/// level constants. If the caller specifies <c>NULL</c>, the current impersonation level is not retrieved.
		/// </param>
		/// <param name="pAuthInfo">
		/// A pointer to a handle that receives the identity of the client that was passed to the last IClientSecurity::SetBlanket call (or
		/// the default value). Default values are only valid until the proxy is released. If the caller specifies <c>NULL</c>, the client
		/// identity is not retrieved. The format of the structure that the handle refers to depends on the authentication service. The
		/// application should not write or free the memory. For NTLMSSP and Kerberos, if the client specified a structure in the pAuthInfo
		/// parameter to CoInitializeSecurity, that value is returned. For Schannel, if a certificate for the client could be retrieved from
		/// the certificate manager, that value is returned here. Otherwise, <c>NULL</c> is returned. See RPC_AUTH_IDENTITY_HANDLE.
		/// </param>
		/// <param name="pCapabilites">
		/// A pointer to a variable that receives the capabilities of the proxy. If the caller specifies <c>NULL</c>, the current capability
		/// flags are not retrieved.
		/// </param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// <c>CoQueryProxyBlanket</c> is called by the client to retrieve the authentication information COM will use on calls made from the
		/// specified proxy. This function encapsulates the following sequence of common calls (error handling excluded):
		/// </para>
		/// <para>
		/// This sequence calls QueryInterface on the proxy to get a pointer to IClientSecurity, and with the resulting pointer, calls
		/// IClientSecurity::QueryBlanket and then releases the pointer.
		/// </para>
		/// <para>
		/// In pProxy, you can pass any proxy, such as a proxy you get through a call to CoCreateInstance or CoUnmarshalInterface, or you can
		/// pass an interface pointer. It can be any interface. You cannot pass a pointer to something that is not a proxy. Therefore, you
		/// can't pass a pointer to an interface that has the local keyword in its interface definition because no proxy is created for such
		/// an interface. IUnknown is the exception to this rule.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coqueryproxyblanket HRESULT CoQueryProxyBlanket(
		// IUnknown *pProxy, DWORD *pwAuthnSvc, DWORD *pAuthzSvc, LPOLESTR *pServerPrincName, DWORD *pAuthnLevel, DWORD *pImpLevel,
		// RPC_AUTH_IDENTITY_HANDLE *pAuthInfo, DWORD *pCapabilites );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "e613e06a-0900-413e-bde2-39ce1612fed1")]
		public static extern HRESULT CoQueryProxyBlanket([In, MarshalAs(UnmanagedType.IUnknown)] object pProxy, out RPC_C_AUTHN pAuthnLevel,
			out RPC_C_AUTHZ pAuthzSvc, SafeCoTaskMemString pServerPrincName, out RPC_C_AUTHN_LEVEL pwAuthnSvc, out RPC_C_IMP_LEVEL pImpLevel,
			out RPC_AUTH_IDENTITY_HANDLE pAuthInfo, ref EOLE_AUTHENTICATION_CAPABILITIES pCapabilites);

		/// <summary>Registers a process-wide filter to process activation requests.</summary>
		/// <param name="pActivationFilter">Pointer to the filter to register.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>This registers one and only one process-wide filter.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coregisteractivationfilter HRESULT
		// CoRegisterActivationFilter( IActivationFilter *pActivationFilter );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "4189633F-9B14-4EAD-84BD-F74355376164")]
		public static extern HRESULT CoRegisterActivationFilter([In] IActivationFilter pActivationFilter);

		/// <summary>Registers an EXE class object with OLE so other applications can connect to it.</summary>
		/// <param name="rclsid">The CLSID to be registered.</param>
		/// <param name="pUnk">A pointer to the IUnknown interface on the class object whose availability is being published.</param>
		/// <param name="dwClsContext">
		/// The context in which the executable code is to be run. For information on these context values, see the CLSCTX enumeration.
		/// </param>
		/// <param name="flags">
		/// Indicates how connections are made to the class object. For information on these flags, see the REGCLS enumeration.
		/// </param>
		/// <param name="lpdwRegister">
		/// A pointer to a value that identifies the class object registered; later used by the CoRevokeClassObject function to revoke the registration.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The class object was registered successfully.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// EXE object applications should call <c>CoRegisterClassObject</c> on startup. It can also be used to register internal objects for
		/// use by the same EXE or other code (such as DLLs) that the EXE uses. Only EXE object applications call
		/// <c>CoRegisterClassObject</c>. Object handlers or DLL object applications do not call this function — instead, they must implement
		/// and export the DllGetClassObject function.
		/// </para>
		/// <para>
		/// At startup, a multiple-use EXE object application must create a class object (with the IClassFactory interface on it), and call
		/// <c>CoRegisterClassObject</c> to register the class object. Object applications that support several different classes (such as
		/// multiple types of embeddable objects) must allocate and register a different class object for each.
		/// </para>
		/// <para>
		/// Multiple registrations of the same class object are independent and do not produce an error. Each subsequent registration yields
		/// a unique key in lpdwRegister.
		/// </para>
		/// <para>
		/// Multiple document interface (MDI) applications must register their class objects. Single document interface (SDI) applications
		/// must register their class objects only if they can be started by means of the <c>/Embedding</c> switch.
		/// </para>
		/// <para>
		/// The server for a class object should call CoRevokeClassObject to revoke the class object (remove its registration) when all of
		/// the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>There are no existing instances of the object definition.</term>
		/// </item>
		/// <item>
		/// <term>There are no locks on the class object.</term>
		/// </item>
		/// <item>
		/// <term>The application providing services to the class object is not under user control (not visible to the user on the display).</term>
		/// </item>
		/// </list>
		/// <para>
		/// After the class object is revoked, when its reference count reaches zero, the class object can be released, allowing the
		/// application to exit. Note that <c>CoRegisterClassObject</c> calls IUnknown::AddRef and CoRevokeClassObject calls
		/// IUnknown::Release, so the two functions form an <c>AddRef</c>/ <c>Release</c> pair.
		/// </para>
		/// <para>
		/// As of Windows Server 2003, if a COM object application is registered as a service, COM verifies the registration. COM makes sure
		/// the process ID of the service, in the service control manager (SCM), matches the process ID of the registering process. If not,
		/// COM fails the registration. If the COM object application runs in the system account with no registry key, COM treats the objects
		/// application identity as Launching User.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coregisterclassobject HRESULT CoRegisterClassObject(
		// REFCLSID rclsid, LPUNKNOWN pUnk, DWORD dwClsContext, DWORD flags, LPDWORD lpdwRegister );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "d27bfa6c-194a-41f1-8fcf-76c4dff14a8a")]
		public static extern HRESULT CoRegisterClassObject(in Guid rclsid, [MarshalAs(UnmanagedType.IUnknown)] object pUnk, CLSCTX dwClsContext, REGCLS flags, out uint lpdwRegister);

		/// <summary>
		/// Enables a downloaded DLL to register its custom interfaces within its running process so that the marshaling code will be able to
		/// marshal those interfaces.
		/// </summary>
		/// <param name="riid">A pointer to the IID of the interface to be registered.</param>
		/// <param name="rclsid">
		/// A pointer to the CLSID of the DLL that contains the proxy/stub code for the custom interface specified by riid.
		/// </param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// Typically, the code responsible for marshaling an interface pointer into the current running process reads the
		/// <c>HKEY_CLASSES_ROOT\Interfaces</c> section of the registry to obtain the CLSID of the DLL containing the ProxyStub code to be
		/// loaded. To obtain the ProxyStub CLSIDs for an existing interface, the code calls the CoGetPSClsid function.
		/// </para>
		/// <para>
		/// In some cases, however, it may be desirable or necessary for an in-process handler or in-process server to make its custom
		/// interfaces available without writing to the registry. A DLL downloaded across a network may not even have permission to access
		/// the local registry, and because the code originated on another computer, the user, for security purposes, may want to run it in a
		/// restricted environment. Or a DLL may have custom interfaces that it uses to talk to a remote server and may also include the
		/// ProxyStub code for those interfaces. In such cases, a DLL needs an alternative way to register its interfaces.
		/// <c>CoRegisterPSClsid</c>, used in conjunction with CoRegisterClassObject, provides that alternative.
		/// </para>
		/// <para>Examples</para>
		/// <para>A DLL would typically call <c>CoRegisterPSClsid</c> as shown in the following code fragment.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coregisterpsclsid HRESULT CoRegisterPSClsid( REFIID
		// riid, REFCLSID rclsid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a73dbd6d-d3f2-48d7-b053-b62f2f18f2d6")]
		public static extern HRESULT CoRegisterPSClsid(in Guid riid, in Guid rclsid);

		/// <summary>Registers the surrogate process through its ISurrogate interface pointer.</summary>
		/// <param name="pSurrogate">A pointer to the ISurrogate interface on the surrogate process to be registered.</param>
		/// <returns>This function returns S_OK to indicate that the surrogate process was registered successfully.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CoRegisterSurrogate</c> function sets a global interface pointer to the ISurrogate interface implemented on the surrogate
		/// process. This pointer is set in the ole32 DLL loaded in the surrogate process. COM uses this global pointer in ole32 to call the
		/// methods of <c>ISurrogate</c>. This function is usually called by the surrogate implementation when it is launched.
		/// </para>
		/// <para>
		/// As of Windows Server 2003, if a COM object application is registered as a service, COM verifies the registration. COM makes sure
		/// the process ID of the service, in the service control manager (SCM), matches the process ID of the registering process. If not,
		/// COM fails the registration.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coregistersurrogate HRESULT CoRegisterSurrogate(
		// LPSURROGATE pSurrogate );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "4d1c6ca6-ab21-429c-9433-7c95d9e757b5")]
		public static extern HRESULT CoRegisterSurrogate(ISurrogate pSurrogate);

		/// <summary>Destroys a previously marshaled data packet.</summary>
		/// <param name="pStm">A pointer to the stream that contains the data packet to be destroyed. See IStream.</param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The data packet was successfully destroyed.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPOINTER</term>
		/// <term>An error related to the pStm parameter.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>The CoInitialize or OleInitialize function was not called on the current thread before this function was called.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Important</c> Security Note: Calling this method with untrusted data is a security risk. Call this method only with trusted
		/// data. For more information, see Untrusted Data Security Risks.
		/// </para>
		/// <para>The <c>CoReleaseMarshalData</c> function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>The function reads a CLSID from the stream.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If COM's default marshaling implementation is being used, the function gets an IMarshal pointer to an instance of the standard
		/// unmarshaler. If custom marshaling is being used, the function creates a proxy by calling the CoCreateInstance function, passing
		/// the CLSID it read from the stream, and requests an <c>IMarshal</c> interface pointer to the newly created proxy.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Using whichever IMarshal interface pointer it has acquired, the function calls IMarshal::ReleaseMarshalData.</term>
		/// </item>
		/// </list>
		/// <para>
		/// You typically do not call this function. The only situation in which you might need to call this function is if you use custom
		/// marshaling (write and use your own implementation of IMarshal). Examples of when <c>CoReleaseMarshalData</c> should be called
		/// include the following situations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>An attempt was made to unmarshal the data packet, but it failed.</term>
		/// </item>
		/// <item>
		/// <term>A marshaled data packet was removed from a global table.</term>
		/// </item>
		/// </list>
		/// <para>
		/// As an analogy, the data packet can be thought of as a reference to the original object, just as if it were another interface
		/// pointer being held on the object. Like a real interface pointer, that data packet must be released at some point. The use of
		/// IMarshal::ReleaseMarshalData to release data packets is analogous to the use of IUnknown::Release to release interface pointers.
		/// </para>
		/// <para>
		/// Note that you do not need to call <c>CoReleaseMarshalData</c> after a successful call of the CoUnmarshalInterface function; that
		/// function releases the marshal data as part of the processing that it does.
		/// </para>
		/// <para>
		/// <c>Important</c> You must call the <c>CoReleaseMarshalData</c> function in the same apartment that called CoMarshalInterface to
		/// marshal the object into the stream. Failure to do this may cause the object reference held by the marshaled packet in the stream
		/// to be leaked.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coreleasemarshaldata HRESULT CoReleaseMarshalData(
		// LPSTREAM pStm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a642a20f-3a3c-46bc-b833-e424dab3a16d")]
		public static extern HRESULT CoReleaseMarshalData(IStream pStm);

		/// <summary>Decrements the global per-process reference count.</summary>
		/// <returns>
		/// If the server application should initiate its cleanup, the function returns 0; otherwise, the function returns a nonzero value.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Servers can call <c>CoReleaseServerProcess</c> to decrement a global per-process reference count incremented through a call to CoAddRefServerProcess.
		/// </para>
		/// <para>
		/// When that count reaches zero, OLE automatically calls CoSuspendClassObjects, which prevents new activation requests from coming
		/// in. This permits the server to deregister its class objects from its various threads without worry that another activation
		/// request may come in. New activation requests result in launching a new instance of the local server process.
		/// </para>
		/// <para>
		/// The simplest way for a local server application to make use of these functions is to call CoAddRefServerProcess in the
		/// constructor for each of its instance objects, and in each of its IClassFactory::LockServer methods when the fLock parameter is
		/// <c>TRUE</c>. The server application should also call <c>CoReleaseServerProcess</c> in the destructor of each of its instance
		/// objects, and in each of its <c>IClassFactory::LockServer</c> methods when the fLock parameter is <c>FALSE</c>. Finally, the
		/// server application must check the return code from <c>CoReleaseServerProcess</c>; if it returns 0, the server application should
		/// initiate its cleanup. This typically means that a server with multiple threads should signal its various threads to exit their
		/// message loops and call CoRevokeClassObject and CoUninitialize.
		/// </para>
		/// <para>
		/// If these APIs are used at all, they must be called in both the object instances and the LockServer method, otherwise the server
		/// application may be shutdown prematurely. In-process Servers typically should not call CoAddRefServerProcess or <c>CoReleaseServerProcess</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coreleaseserverprocess ULONG CoReleaseServerProcess( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "b28d41e2-4144-413d-9963-14f2d4dc8876")]
		public static extern uint CoReleaseServerProcess();

		/// <summary>
		/// Called by a server that can register multiple class objects to inform the SCM about all registered classes, and permits
		/// activation requests for those class objects.
		/// </summary>
		/// <returns>This function returns S_OK to indicate that the CLSID was retrieved successfully.</returns>
		/// <remarks>
		/// <para>
		/// Servers that can register multiple class objects call <c>CoResumeClassObjects</c> once, after having first called
		/// CoRegisterClassObject, specifying REGCLS_LOCAL_SERVER | REGCLS_SUSPENDED for each CLSID the server supports. This function causes
		/// OLE to inform the SCM about all the registered classes, and begins letting activation requests into the server process.
		/// </para>
		/// <para>
		/// This reduces the overall registration time, and thus the server application startup time, by making a single call to the SCM, no
		/// matter how many CLSIDs are registered for the server. Another advantage is that if the server has multiple apartments with
		/// different CLSIDs registered in different apartments, or is a free-threaded server, no activation requests will come in until the
		/// server calls <c>CoResumeClassObjects</c>. This gives the server a chance to register all of its CLSIDs and get properly set up
		/// before having to deal with activation requests, and possibly shutdown requests.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coresumeclassobjects HRESULT CoResumeClassObjects( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c2b6e8d8-99a1-4af3-9881-bfe6932e4a76")]
		public static extern HRESULT CoResumeClassObjects();

		/// <summary>Restores the authentication information on a thread of execution.</summary>
		/// <returns>This function supports the standard return values, including S_OK to indicate success.</returns>
		/// <remarks>
		/// <para>
		/// <c>CoRevertToSelf</c>, which is a helper function that calls IServerSecurity::RevertToSelf, restores the authentication
		/// information on a thread to the authentication information on the thread before impersonation began.
		/// </para>
		/// <para><c>CoRevertToSelf</c> encapsulates the following common sequence of calls (error handling excluded):</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coreverttoself HRESULT CoRevertToSelf( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "8061ddbe-ed21-47f7-9ac4-b3ec910ff89d")]
		public static extern HRESULT CoRevertToSelf();

		/// <summary>
		/// Informs OLE that a class object, previously registered with the CoRegisterClassObject function, is no longer available for use.
		/// </summary>
		/// <param name="dwRegister">A token previously returned from the CoRegisterClassObject function.</param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The class object was revoked successfully.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A successful call to <c>CoRevokeClassObject</c> means that the class object has been removed from the global class object table
		/// (although it does not release the class object). If other clients still have pointers to the class object and have caused the
		/// reference count to be incremented by calls to IUnknown::AddRef, the reference count will not be zero. When this occurs,
		/// applications may benefit if subsequent calls (with the obvious exceptions of <c>AddRef</c> and IUnknown::Release) to the class
		/// object fail. Note that CoRegisterClassObject calls <c>AddRef</c> and <c>CoRevokeClassObject</c> calls <c>Release</c>, so the two
		/// functions form an <c>AddRef</c>/ <c>Release</c> pair.
		/// </para>
		/// <para>
		/// An object application must call <c>CoRevokeClassObject</c> to revoke registered class objects before exiting the program. Class
		/// object implementers should call <c>CoRevokeClassObject</c> as part of the release sequence. You must specifically revoke the
		/// class object even when you have specified the flags value REGCLS_SINGLEUSE in a call to CoRegisterClassObject, indicating that
		/// only one application can connect to the class object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-corevokeclassobject HRESULT CoRevokeClassObject(
		// DWORD dwRegister );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "90b9b9ca-b5b2-48f5-8c2a-b478b6daa7ec")]
		public static extern HRESULT CoRevokeClassObject(uint dwRegister);

		/// <summary>
		/// Sets (registers) or resets (unregisters) a cancel object for use during subsequent cancel operations on the current thread.
		/// </summary>
		/// <param name="pUnk">
		/// Pointer to the IUnknown interface on the cancel object to be set or reset on the current thread. If this parameter is
		/// <c>NULL</c>, the topmost cancel object is reset.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The cancel object was successfully set or reset.</term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The cancel object cannot be set or reset at this time because of a block on cancel operations.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For objects that support standard marshaling, the proxy object begins marshaling a method call by calling
		/// <c>CoSetCancelObject</c> to register a cancel object for the current thread.
		/// </para>
		/// <para>
		/// <c>CoSetCancelObject</c> calls QueryInterface for ICancelMethodCalls on the cancel object. If the cancel object does not
		/// implement <c>ICancelMethodCalls</c>, <c>CoSetCancelObject</c> fails with E_NOINTERFACE. To disable cancel operations on a
		/// custom-marshaled interface, the implementation of ICancelMethodCalls::Cancel should do nothing but return E_NOTIMPL, E_FAIL, or
		/// some other appropriate value.
		/// </para>
		/// <para><c>CoSetCancelObject</c> calls AddRef on objects that it registers and Release on objects that it unregisters.</para>
		/// <para><c>CoSetCancelObject</c> does not set or reset cancel objects for asynchronous methods.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cosetcancelobject HRESULT CoSetCancelObject(
		// IUnknown *pUnk );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "0978e252-2206-4597-abf2-fe0dac32efc4")]
		public static extern HRESULT CoSetCancelObject([In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);

		/// <summary>
		/// Sets the authentication information that will be used to make calls on the specified proxy. This is a helper function for IClientSecurity::SetBlanket.
		/// </summary>
		/// <param name="pProxy">The proxy to be set.</param>
		/// <param name="dwAuthnSvc">
		/// The authentication service to be used. For a list of possible values, see Authentication Service Constants. Use RPC_C_AUTHN_NONE
		/// if no authentication is required. If RPC_C_AUTHN_DEFAULT is specified, DCOM will pick an authentication service following its
		/// normal security blanket negotiation algorithm.
		/// </param>
		/// <param name="dwAuthzSvc">
		/// The authorization service to be used. For a list of possible values, see Authorization Constants. If RPC_C_AUTHZ_DEFAULT is
		/// specified, DCOM will pick an authorization service following its normal security blanket negotiation algorithm. RPC_C_AUTHZ_NONE
		/// should be used as the authorization service if NTLMSSP, Kerberos, or Schannel is used as the authentication service.
		/// </param>
		/// <param name="pServerPrincName">
		/// <para>
		/// The server principal name to be used with the authentication service. If COLE_DEFAULT_PRINCIPAL is specified, DCOM will pick a
		/// principal name using its security blanket negotiation algorithm. If Kerberos is used as the authentication service, this value
		/// must not be <c>NULL</c>. It must be the correct principal name of the server or the call will fail.
		/// </para>
		/// <para>
		/// If Schannel is used as the authentication service, this value must be one of the msstd or fullsic forms described in Principal
		/// Names, or <c>NULL</c> if you do not want mutual authentication.
		/// </para>
		/// <para>
		/// Generally, specifying <c>NULL</c> will not reset the server principal name on the proxy; rather, the previous setting will be
		/// retained. You must be careful when using <c>NULL</c> as pServerPrincName when selecting a different authentication service for
		/// the proxy, because there is no guarantee that the previously set principal name would be valid for the newly selected
		/// authentication service.
		/// </para>
		/// </param>
		/// <param name="dwAuthnLevel">
		/// The authentication level to be used. For a list of possible values, see Authentication Level Constants. If
		/// RPC_C_AUTHN_LEVEL_DEFAULT is specified, DCOM will pick an authentication level following its normal security blanket negotiation
		/// algorithm. If this value is none, the authentication service must also be none.
		/// </param>
		/// <param name="dwImpLevel">
		/// The impersonation level to be used. For a list of possible values, see Impersonation Level Constants. If RPC_C_IMP_LEVEL_DEFAULT
		/// is specified, DCOM will pick an impersonation level following its normal security blanket negotiation algorithm. If NTLMSSP is
		/// the authentication service, this value must be RPC_C_IMP_LEVEL_IMPERSONATE or RPC_C_IMP_LEVEL_IDENTIFY. NTLMSSP also supports
		/// delegate-level impersonation (RPC_C_IMP_LEVEL_DELEGATE) on the same computer. If Schannel is the authentication service, this
		/// parameter must be RPC_C_IMP_LEVEL_IMPERSONATE.
		/// </param>
		/// <param name="pAuthInfo">
		/// <para>
		/// A pointer to an <c>RPC_AUTH_IDENTITY_HANDLE</c> value that establishes the identity of the client. The format of the structure
		/// referred to by the handle depends on the provider of the authentication service.
		/// </para>
		/// <para>
		/// For calls on the same computer, RPC logs on the user with the supplied credentials and uses the resulting token for the method call.
		/// </para>
		/// <para>
		/// For NTLMSSP or Kerberos, the structure is a SEC_WINNT_AUTH_IDENTITY or SEC_WINNT_AUTH_IDENTITY_EX structure. The client can
		/// discard pAuthInfo after calling the API. RPC does not keep a copy of the pAuthInfo pointer, and the client cannot retrieve it
		/// later in the CoQueryProxyBlanket method.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, DCOM uses the current proxy identity (which is either the process token or the impersonation
		/// token). If the handle refers to a structure, that identity is used.
		/// </para>
		/// <para>
		/// For Schannel, this parameter must be either a pointer to a CERT_CONTEXT structure that contains the client's X.509 certificate or
		/// is <c>NULL</c> if the client wishes to make an anonymous connection to the server. If a certificate is specified, the caller must
		/// not free it as long as any proxy to the object exists in the current apartment.
		/// </para>
		/// <para>
		/// For Snego, this member is either <c>NULL</c>, points to a SEC_WINNT_AUTH_IDENTITY structure, or points to a
		/// SEC_WINNT_AUTH_IDENTITY_EX structure. If it is <c>NULL</c>, Snego will pick a list of authentication services based on those
		/// available on the client computer. If it points to a <c>SEC_WINNT_AUTH_IDENTITY_EX</c> structure, the structure's
		/// <c>PackageList</c> member must point to a string containing a comma-separated list of authentication service names and the
		/// <c>PackageListLength</c> member must give the number of bytes in the <c>PackageList</c> string. If <c>PackageList</c> is
		/// <c>NULL</c>, all calls using Snego will fail.
		/// </para>
		/// <para>
		/// If COLE_DEFAULT_AUTHINFO is specified for this parameter, DCOM will pick the authentication information following its normal
		/// security blanket negotiation algorithm.
		/// </para>
		/// <para><c>CoSetProxyBlanket</c> will fail if pAuthInfo is set and one of the cloaking flags is set in the dwCapabilities parameter.</para>
		/// </param>
		/// <param name="dwCapabilities">
		/// The capabilities of this proxy. For a list of possible values, see the EOLE_AUTHENTICATION_CAPABILITIES enumeration. The only
		/// flags that can be set through this function are EOAC_MUTUAL_AUTH, EOAC_STATIC_CLOAKING, EOAC_DYNAMIC_CLOAKING, EOAC_ANY_AUTHORITY
		/// (this flag is deprecated), EOAC_MAKE_FULLSIC, and EOAC_DEFAULT. Either EOAC_STATIC_CLOAKING or EOAC_DYNAMIC_CLOAKING can be set
		/// if pAuthInfo is not set and Schannel is not the authentication service. (See Cloaking for more information.) If any capability
		/// flags other than those mentioned here are set, <c>CoSetProxyBlanket</c> will fail.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CoSetProxyBlanket</c> sets the authentication information that will be used to make calls on the specified proxy. This
		/// function encapsulates the following sequence of common calls (error handling excluded).
		/// </para>
		/// <para>
		/// This sequence calls QueryInterface on the proxy to get a pointer to IClientSecurity, and with the resulting pointer, calls
		/// IClientSecurity::SetBlanket and then releases the pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cosetproxyblanket HRESULT CoSetProxyBlanket(
		// IUnknown *pProxy, DWORD dwAuthnSvc, DWORD dwAuthzSvc, OLECHAR *pServerPrincName, DWORD dwAuthnLevel, DWORD dwImpLevel,
		// RPC_AUTH_IDENTITY_HANDLE pAuthInfo, DWORD dwCapabilities );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c2e5e681-8fa5-4b02-b59d-ba796eb0dccf")]
		public static extern HRESULT CoSetProxyBlanket([In, MarshalAs(UnmanagedType.IUnknown)] object pProxy, RPC_C_AUTHN dwAuthnSvc,
			RPC_C_AUTHZ dwAuthzSvc, string pServerPrincName, RPC_C_AUTHN_LEVEL dwAuthnLevel, RPC_C_IMP_LEVEL dwImpLevel,
			RPC_AUTH_IDENTITY_HANDLE pAuthInfo, EOLE_AUTHENTICATION_CAPABILITIES dwCapabilities);

		/// <summary>Prevents any new activation requests from the SCM on all class objects registered within the process.</summary>
		/// <returns>This function returns S_OK to indicate that the activation of class objects was successfully suspended.</returns>
		/// <remarks>
		/// <c>CoSuspendClassObjects</c> prevents any new activation requests from the SCM on all class objects registered within the
		/// process. Even though a process may call this function, the process still must call the CoRevokeClassObject function for each
		/// CLSID it has registered, in the apartment it registered in. Applications typically do not need to call this function, which is
		/// generally only called internally by OLE when used in conjunction with the CoReleaseServerProcess function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cosuspendclassobjects HRESULT CoSuspendClassObjects( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a9e526f8-b7c1-47ec-a6ab-91690d93119e")]
		public static extern HRESULT CoSuspendClassObjects();

		/// <summary>Switches the call context object used by CoGetCallContext.</summary>
		/// <param name="pNewObject">
		/// A pointer to an interface on the new call context object. COM stores this pointer without adding a reference to the pointer until
		/// <c>CoSwitchCallContext</c> is called with another object. This parameter may be <c>NULL</c> if you are calling
		/// <c>CoSwitchCallContext</c> to switch back to the original call context but there was no original call context.
		/// </param>
		/// <param name="ppOldObject">
		/// The address of pointer variable that receives a pointer to the call context object of the call currently in progress. This value
		/// is returned so that the original call context can be restored by the custom marshaller. The returned pointer will be <c>NULL</c>
		/// if there was no call in progress.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUT_OF_MEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Custom marshallers call <c>CoSwitchCallContext</c> to change the call context object used by the CoGetCallContext function.
		/// Before dispatching an arriving call, custom marshallers call <c>CoSwitchCallContext</c>, specifying the new context object. After
		/// sending a reply, they must restore the original call context by calling <c>CoSwitchCallContext</c> again, this time passing a
		/// pointer to the original context object.
		/// </para>
		/// <para>
		/// <c>CoSwitchCallContext</c> does not add a reference to the new context object. Custom marshallers must ensure that the lifetime
		/// of their context object continues throughout their call and until the call to restore the original context. Custom marshallers
		/// should not release the value that they placed into the ppOldObject parameter when they set their context.
		/// </para>
		/// <para>Call context objects provided by custom marshallers should support the IServerSecurity interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-coswitchcallcontext HRESULT CoSwitchCallContext(
		// IUnknown *pNewObject, IUnknown **ppOldObject );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "146855a2-97ec-4e71-88dc-316eaa1a24a0")]
		public static extern HRESULT CoSwitchCallContext([In, MarshalAs(UnmanagedType.IUnknown)] object pNewObject,
			[MarshalAs(UnmanagedType.IUnknown)] out object ppOldObject);

		/// <summary>Allocates a block of task memory in the same way that IMalloc::Alloc does.</summary>
		/// <param name="cb">The size of the memory block to be allocated, in bytes.</param>
		/// <returns>If the function succeeds, it returns the allocated memory block. Otherwise, it returns <c>NULL</c>.</returns>
		/// <remarks>
		/// <para>
		/// <c>CoTaskMemAlloc</c> uses the default allocator to allocate a memory block in the same way that IMalloc::Alloc does. It is not
		/// necessary to call the CoGetMalloc function before calling <c>CoTaskMemAlloc</c>.
		/// </para>
		/// <para>
		/// The initial contents of the returned memory block are undefined – there is no guarantee that the block has been initialized. The
		/// allocated block may be larger than cb bytes because of the space required for alignment and for maintenance information.
		/// </para>
		/// <para>
		/// If cb is 0, <c>CoTaskMemAlloc</c> allocates a zero-length item and returns a valid pointer to that item. If there is insufficient
		/// memory available, <c>CoTaskMemAlloc</c> returns <c>NULL</c>. Applications should always check the return value from this
		/// function, even when requesting small amounts of memory, because there is no guarantee that the memory will be allocated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemalloc LPVOID CoTaskMemAlloc( SIZE_T cb );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c4cb588d-9482-4f90-a92e-75b604540d5c")]
		public static extern IntPtr CoTaskMemAlloc(SizeT cb);

		/// <summary>Frees a block of task memory previously allocated through a call to the CoTaskMemAlloc or CoTaskMemRealloc function.</summary>
		/// <param name="pv">A pointer to the memory block to be freed. If this parameter is <c>NULL</c>, the function has no effect.</param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// <para>The <c>CoTaskMemFree</c> function uses the default OLE allocator.</para>
		/// <para>
		/// The number of bytes freed equals the number of bytes that were originally allocated or reallocated. After the call, the memory
		/// block pointed to by pv is invalid and can no longer be used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemfree void CoTaskMemFree( _Frees_ptr_opt_
		// LPVOID pv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "3d0af12e-fc74-4ef7-b2dd-e9da5d0483c7")]
		public static extern void CoTaskMemFree(IntPtr pv);

		/// <summary>Changes the size of a previously allocated block of task memory.</summary>
		/// <param name="pv">A pointer to the memory block to be reallocated. This parameter can be <c>NULL</c>, as discussed in Remarks.</param>
		/// <param name="cb">The size of the memory block to be reallocated, in bytes. This parameter can be 0, as discussed in Remarks.</param>
		/// <returns>If the function succeeds, it returns the reallocated memory block. Otherwise, it returns <c>NULL</c>.</returns>
		/// <remarks>
		/// <para>
		/// This function changes the size of a previously allocated memory block in the same way that IMalloc::Realloc does. It is not
		/// necessary to call the CoGetMalloc function to get a pointer to the OLE allocator before calling <c>CoTaskMemRealloc</c>.
		/// </para>
		/// <para>
		/// The pv parameter points to the beginning of the memory block. If pv is <c>NULL</c>, <c>CoTaskMemRealloc</c> allocates a new
		/// memory block in the same way as the CoTaskMemAlloc function. If pv is not <c>NULL</c>, it should be a pointer returned by a prior
		/// call to <c>CoTaskMemAlloc</c>.
		/// </para>
		/// <para>
		/// The cb parameter specifies the size of the new block. The contents of the block are unchanged up to the shorter of the new and
		/// old sizes, although the new block can be in a different location. Because the new block can be in a different memory location,
		/// the pointer returned by <c>CoTaskMemRealloc</c> is not guaranteed to be the pointer passed through the pv argument. If pv is not
		/// <c>NULL</c> and cb is 0, then the memory pointed to by pv is freed.
		/// </para>
		/// <para>
		/// <c>CoTaskMemRealloc</c> returns a void pointer to the reallocated (and possibly moved) memory block. The return value is
		/// <c>NULL</c> if the size is 0 and the buffer argument is not <c>NULL</c>, or if there is not enough memory available to expand the
		/// block to the specified size. In the first case, the original block is freed; in the second case, the original block is unchanged.
		/// </para>
		/// <para>
		/// The storage space pointed to by the return value is guaranteed to be suitably aligned for storage of any type of object. To get a
		/// pointer to a type other than <c>void</c>, use a type cast on the return value.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-cotaskmemrealloc LPVOID CoTaskMemRealloc( LPVOID pv,
		// SIZE_T cb );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "83014a3e-198d-4b4b-91aa-0c0804c8e1bf")]
		public static extern IntPtr CoTaskMemRealloc(IntPtr pv, SizeT cb);

		/// <summary>
		/// <para>Determines whether the call being executed on the server has been canceled by the client.</para>
		/// </summary>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_S_CALLPENDING</term>
		/// <term>The call is still pending and has not yet been canceled by the client.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CALL_CANCELED</term>
		/// <term>The call has been canceled by the client.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Server objects should call <c>CoTestCancel</c> at least once before returning to detect client cancellation requests. Doing so
		/// can save the server unnecessary work if the client has issued a cancellation request, and it can reduce the client's wait time if
		/// it has set the cancel timeout as RPC_C_CANCEL_INFINITE_TIMEOUT. Furthermore, if the server object detects a cancellation request
		/// before returning from a pending call, it can clean up any memory, marshaled interfaces, or handles it has created or obtained.
		/// </para>
		/// <para>
		/// <c>CoTestCancel</c> calls CoGetCallContext to obtain the ICancelMethodCalls interface on the current cancel object and then calls
		/// ICancelMethodCalls::TestCancel. Objects that implement custom marshaling should first call CoSwitchCallContext to install the
		/// appropriate call context object.
		/// </para>
		/// <para>This function does not test cancellation for asynchronous calls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cotestcancel HRESULT CoTestCancel( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "9432621a-be31-4b8b-83b6-069539ba06b4")]
		public static extern HRESULT CoTestCancel();

		/// <summary>Unmarshals an <c>HRESULT</c> type from the specified stream.</summary>
		/// <param name="pstm">A pointer to the stream from which the <c>HRESULT</c> is to be unmarshaled.</param>
		/// <param name="phresult">A pointer to the unmarshaled <c>HRESULT</c>.</param>
		/// <returns>
		/// <para>This function can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The HRESULT was unmarshaled successfully.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPOINTER</term>
		/// <term>pStm is an invalid pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You do not explicitly call this function unless you are performing custom marshaling (that is, writing your own implementation of
		/// IMarshal), and your implementation needs to unmarshal an <c>HRESULT</c>.
		/// </para>
		/// <para>
		/// You must use <c>CoUnmarshalHresult</c> to unmarshal <c>HRESULT</c> values previously marshaled by a call to the CoMarshalHresult function.
		/// </para>
		/// <para>This function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>an <c>HRESULT</c> from a stream.</term>
		/// </item>
		/// <item>
		/// <term>Returns the <c>HRESULT</c>.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-counmarshalhresult HRESULT CoUnmarshalHresult(
		// LPSTREAM pstm, HRESULT *phresult );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a45ef72c-d385-4012-9683-7d2cc6d68b6d")]
		public static extern HRESULT CoUnmarshalHresult(IStream pstm, out HRESULT phresult);

		/// <summary>
		/// Initializes a newly created proxy using data written into the stream by a previous call to the CoMarshalInterface function, and
		/// returns an interface pointer to that proxy.
		/// </summary>
		/// <param name="pStm">A pointer to the stream from which the interface is to be unmarshaled.</param>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be unmarshaled. For <c>IID_NULL</c>, the returned interface is the one defined
		/// by the stream, objref.iid.
		/// </param>
		/// <param name="ppv">
		/// The address of pointer variable that receives the interface pointer requested in <paramref name="riid"/>. Upon successful return,
		/// <paramref name="ppv"/> contains the requested interface pointer for the unmarshaled interface.
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return value E_FAIL, errors returned by CoCreateInstance, and the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The interface pointer was unmarshaled successfully.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPOINTER</term>
		/// <term>pStm is an invalid pointer.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOTINITIALIZED</term>
		/// <term>The CoInitialize or OleInitialize function was not called on the current thread before this function was called.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_OBJNOTCONNECTED</term>
		/// <term>
		/// The object application has been disconnected from the remoting system (for example, as a result of a call to the
		/// CoDisconnectObject function).
		/// </term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>An error occurred reading the registration database.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The final QueryInterface of this function for the requested interface returned E_NOINTERFACE.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Important</c> Security Note: Calling this method with untrusted data is a security risk. Call this method only with trusted
		/// data. For more information, see Untrusted Data Security Risks.
		/// </para>
		/// <para>The <c>CoUnmarshalInterface</c> function performs the following tasks:</para>
		/// <list type="number">
		/// <item>
		/// <term>Reads from the stream the CLSID to be used to create an instance of the proxy.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Gets an IMarshal pointer to the proxy that is to do the unmarshaling. If the object uses COM's default marshaling implementation,
		/// the pointer thus obtained is to an instance of the generic proxy object. If the marshaling is occurring between two threads in
		/// the same process, the pointer is to an instance of the in-process free threaded marshaler. If the object provides its own
		/// marshaling code, <c>CoUnmarshalInterface</c> calls the CoCreateInstance function, passing the CLSID it read from the marshaling
		/// stream. <c>CoCreateInstance</c> creates an instance of the object's proxy and returns an <c>IMarshal</c> interface pointer to the proxy.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Using whichever IMarshal interface pointer it has acquired, the function then calls IMarshal::UnmarshalInterface and, if
		/// appropriate, IMarshal::ReleaseMarshalData.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The primary caller of this function is COM itself, from within interface proxies or stubs that unmarshal an interface pointer.
		/// There are, however, some situations in which you might call <c>CoUnmarshalInterface</c>. For example, if you are implementing a
		/// stub, your implementation would call <c>CoUnmarshalInterface</c> when the stub receives an interface pointer as a parameter in a
		/// method call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-counmarshalinterface HRESULT CoUnmarshalInterface(
		// LPSTREAM pStm, REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "d0eac0da-2f41-40c4-b756-31bc22752c17")]
		public static extern HRESULT CoUnmarshalInterface(IStream pStm, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Waits for specified handles to be signaled or for a specified timeout period to elapse.</summary>
		/// <param name="dwFlags">The wait options. Possible values are taken from the COWAIT_FLAGS enumeration.</param>
		/// <param name="dwTimeout">The timeout period, in milliseconds.</param>
		/// <param name="cHandles">The number of elements in the pHandles array.</param>
		/// <param name="pHandles">An array of handles.</param>
		/// <param name="lpdwindex">
		/// <para>
		/// A pointer to a variable that, when the returned status is S_OK, receives a value indicating the event that caused the function to
		/// return. This value is usually the index into pHandles for the handle that was signaled.
		/// </para>
		/// <para>
		/// If pHandles includes one or more handles to mutex objects, a value between WAIT_ABANDONED_0 and (WAIT_ABANDONED_0 + nCountâ€“ 1)
		/// indicates the index into pHandles for the mutex that was abandoned.
		/// </para>
		/// <para>
		/// If the COWAIT_ALERTABLE flag is set in dwFlags, a value of WAIT_IO_COMPLETION indicates the wait was ended by one or more
		/// user-mode asynchronous procedure calls (APC) queued to the thread.
		/// </para>
		/// <para>See WaitForMultipleObjectsEx for more information.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <para>
		/// <c>Note</c> The return value of <c>CoWaitForMultipleHandles</c> can be nondeterministic if the COWAIT_ALERTABLE flag is set in
		/// dwFlags, or if pHandles includes one or more handles to mutex objects. The recommended workaround is to call
		/// SetLastError(ERROR_SUCCESS) before <c>CoWaitForMultipleHandles</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The required handle or handles were signaled.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>pHandles was NULL, lpdwindex was NULL, or dwFlags was not a value from the COWAIT_FLAGS enumeration.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_NO_SYNC</term>
		/// <term>The value of pHandles was 0.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALLPENDING</term>
		/// <term>The timeout period elapsed before the required handle or handles were signaled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Depending on which flags are set in the dwFlags parameter, <c>CoWaitForMultipleHandles</c> blocks the calling thread until one of
		/// the following events occurs:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// One or all of the handles is signaled. In the case of mutex objects, this condition is also satisfied by a mutex being abandoned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>An asynchronous procedure call (APC) has been queued to the calling thread with a call to the QueueUserAPC function.</term>
		/// </item>
		/// <item>
		/// <term>The timeout period expires.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller resides in a single-thread apartment, <c>CoWaitForMultipleHandles</c> enters the COM modal loop, and the thread's
		/// message loop will continue to dispatch messages using the thread's message filter. If no message filter is registered for the
		/// thread, the default COM message processing is used.
		/// </para>
		/// <para>
		/// If the calling thread resides in a multithread apartment (MTA), <c>CoWaitForMultipleHandles</c> calls the
		/// WaitForMultipleObjectsEx function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cowaitformultiplehandles HRESULT
		// CoWaitForMultipleHandles( DWORD dwFlags, DWORD dwTimeout, ULONG cHandles, LPHANDLE pHandles, LPDWORD lpdwindex );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "3eeecd34-aa94-4a48-8b41-167a71b52860")]
		public static extern HRESULT CoWaitForMultipleHandles(COWAIT_FLAGS dwFlags, uint dwTimeout, uint cHandles, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] pHandles, out uint lpdwindex);

		/// <summary>
		/// A replacement for CoWaitForMultipleHandles. This replacement API hides the options for <c>CoWaitForMultipleHandles</c> that are
		/// not supported in ASTA.
		/// </summary>
		/// <param name="dwFlags">
		/// CWMO_FLAGS flag controlling whether call/window message reentrancy is enabled from this wait. By default, neither COM calls nor
		/// window messages are dispatched from <c>CoWaitForMultipleObjects</c> in ASTA.
		/// </param>
		/// <param name="dwTimeout">The timeout in milliseconds of the wait.</param>
		/// <param name="cHandles">The length of the pHandles array. Must be &lt;= 56.</param>
		/// <param name="pHandles">An array of handles to waitable kernel objects.</param>
		/// <param name="lpdwindex">Receives the index of the handle that satisfied the wait.</param>
		/// <returns>
		/// Same return values as CoWaitForMultipleHandles, except the ASTA-specific CO_E_NOTSUPPORTED cases instead return E_INVALIDARG from
		/// all apartment types.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cowaitformultipleobjects HRESULT
		// CoWaitForMultipleObjects( DWORD dwFlags, DWORD dwTimeout, ULONG cHandles, const HANDLE *pHandles, LPDWORD lpdwindex );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "7A14E4F4-20F0-43FF-8D64-9AAC34B8D56F")]
		public static extern HRESULT CoWaitForMultipleObjects(CWMO_FLAGS dwFlags, uint dwTimeout, uint cHandles, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] pHandles, out uint lpdwindex);

		/// <summary>
		/// <para>
		/// The <c>CreateStreamOnHGlobal</c> function creates a stream object that uses an HGLOBAL memory handle to store the stream
		/// contents. This object is the OLE-provided implementation of the IStream interface.
		/// </para>
		/// <para>
		/// The returned stream object supports both reading and writing, is not transacted, and does not support region locking. The object
		/// calls the GlobalReAlloc function to grow the memory block as required.
		/// </para>
		/// <para>
		/// <c>Tip</c> Consider using the SHCreateMemStream function, which produces better performance, or for Windows Store apps, consider
		/// using InMemoryRandomAccessStream.
		/// </para>
		/// </summary>
		/// <param name="hGlobal">
		/// A memory handle allocated by the GlobalAlloc function, or if <c>NULL</c> a new handle is to be allocated instead. The handle must
		/// be allocated as moveable and nondiscardable.
		/// </param>
		/// <param name="fDeleteOnRelease">
		/// A value that indicates whether the underlying handle for this stream object should be automatically freed when the stream object
		/// is released. If set to <c>FALSE</c>, the caller must free the hGlobal after the final release. If set to <c>TRUE</c>, the final
		/// release will automatically free the hGlobal parameter.
		/// </param>
		/// <param name="ppstm">
		/// The address of IStream* pointer variable that receives the interface pointer to the new stream object. Its value cannot be <c>NULL</c>.
		/// </param>
		/// <returns>This function supports the standard return values E_INVALIDARG and E_OUTOFMEMORY, as well as the following.</returns>
		/// <remarks>
		/// <para>If hGlobal is <c>NULL</c>, the function allocates a new memory handle and the stream is initially empty.</para>
		/// <para>
		/// If hGlobal is not <c>NULL</c>, the initial contents of the stream are the current contents of the memory block. Thus,
		/// <c>CreateStreamOnHGlobal</c> can be used to open an existing stream in memory. The memory handle and its contents are undisturbed
		/// by the creation of the new stream object.
		/// </para>
		/// <para>
		/// The initial size of the stream is the size of hGlobal as returned by the GlobalSize function. Because of rounding, this is not
		/// necessarily the same size that was originally allocated for the handle. If the logical size of the stream is important, follow
		/// the call to this function with a call to the IStream::SetSize method.
		/// </para>
		/// <para>The new stream object’s initial seek position is the beginning of the stream.</para>
		/// <para>
		/// After creating the stream object with <c>CreateStreamOnHGlobal</c>, call GetHGlobalFromStream to retrieve the memory handle
		/// associated with the stream object.
		/// </para>
		/// <para>
		/// If a memory handle is passed to <c>CreateStreamOnHGlobal</c> or if GetHGlobalFromStream is called, the memory handle of this
		/// function can be directly accessed by the caller while it is still in use by the stream object. Appropriate caution should be
		/// exercised in the use of this capability and its implications:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Do not free the hGlobal memory handle during the lifetime of the stream object. IStream::Release must be called before freeing
		/// the memory handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Do not call GlobalReAlloc to change the size of the memory handle during the lifetime of the stream object or its clones. This
		/// may cause application crashes or memory corruption. Avoid creating multiple stream objects separately on the same memory handle,
		/// because the IStream::Write and IStream::SetSize methods may internally call <c>GlobalReAlloc</c>. The IStream::Clone method can
		/// be used to create a new stream object based on the same memory handle that will properly coordinate its access with the original
		/// stream object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If possible, avoid accessing the memory block during the lifetime of the stream object, because the object may internally call
		/// GlobalReAlloc and do not make assumptions about its size and location. If the memory block must be accessed, the memory access
		/// calls should be surrounded by calls to GlobalLock and GlobalUnLock.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Avoid calling the object’s methods while you have the memory handle locked with GlobalLock. This can cause method calls to fail unpredictably.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller sets the fDeleteOnRelease parameter to <c>FALSE</c>, then the caller must also free the hGlobal after the final
		/// release. If the caller sets the fDeleteOnRelease parameter to <c>TRUE</c>, the final release will automatically free the hGlobal.
		/// </para>
		/// <para>
		/// The memory handle passed as the hGlobal parameter must be allocated as movable and nondiscardable, as shown in the following example:
		/// </para>
		/// <para>
		/// <c>CreateStreamOnHGlobal</c> will accept a memory handle allocated with GMEM_FIXED, but this usage is not recommended. HGLOBALs
		/// allocated with <c>GMEM_FIXED</c> are not really handles and their value can change when they are reallocated. If the memory
		/// handle was allocated with <c>GMEM_FIXED</c> and fDeleteOnRelease is <c>FALSE</c>, the caller must call GetHGlobalFromStream to
		/// get the correct handle in order to free it.
		/// </para>
		/// <para>
		/// Prior to Windows 7 and Windows Server 2008 R2, this implementation did not zero memory when calling GlobalReAlloc to grow the
		/// memory block. Increasing the size of the stream with IStream::SetSize or by writing to a location past the current end of the
		/// stream may leave portions of the newly allocated memory uninitialized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-createstreamonhglobal HRESULT CreateStreamOnHGlobal(
		// HGLOBAL hGlobal, BOOL fDeleteOnRelease, LPSTREAM *ppstm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "413c107b-a943-4c02-9c00-aea708e876d7")]
		public static extern HRESULT CreateStreamOnHGlobal(IntPtr hGlobal, [MarshalAs(UnmanagedType.Bool)] bool fDeleteOnRelease, out IStream ppstm);

		/// <summary>
		/// <para>Determines whether the DLL that implements this function is in use. If not, the caller can unload the DLL from memory.</para>
		/// <para>
		/// OLE does not provide this function. DLLs that support the OLE Component Object Model (COM) should implement and export <c>DllCanUnloadNow</c>.
		/// </para>
		/// </summary>
		/// <returns>If the function succeeds, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// A call to <c>DllCanUnloadNow</c> determines whether the DLL from which it is exported is still in use. A DLL is no longer in use
		/// when it is not managing any existing objects (the reference count on all of its objects is 0).
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should not have to call <c>DllCanUnloadNow</c> directly. OLE calls it only through a call to the CoFreeUnusedLibraries
		/// function. When it returns S_OK, <c>CoFreeUnusedLibraries</c> frees the DLL.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// You must implement <c>DllCanUnloadNow</c> in, and export it from, DLLs that are to be dynamically loaded through a call to the
		/// CoGetClassObject function. (You also need to implement and export the DllGetClassObject function in the same DLL).
		/// </para>
		/// <para>
		/// If a DLL loaded through a call to CoGetClassObject fails to export <c>DllCanUnloadNow</c>, the DLL will not be unloaded until the
		/// application calls the CoUninitialize function to release the OLE libraries.
		/// </para>
		/// <para><c>DllCanUnloadNow</c> should return S_FALSE if there are any existing references to objects that the DLL manages.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-dllcanunloadnow HRESULT DllCanUnloadNow( );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a47df9eb-97cb-4875-a121-1dabe7bc9db6")]
		public static extern HRESULT DllCanUnloadNow();

		/// <summary>
		/// <para>Retrieves the class object from a DLL object handler or object application.</para>
		/// <para>
		/// OLE does not provide this function. DLLs that support the OLE Component Object Model (COM) must implement
		/// <c>DllGetClassObject</c> in OLE object handlers or DLL applications.
		/// </para>
		/// </summary>
		/// <param name="rclsid">The CLSID that will associate the correct data and code.</param>
		/// <param name="riid">
		/// A reference to the identifier of the interface that the caller is to use to communicate with the class object. Usually, this is
		/// IID_IClassFactory (defined in the OLE headers as the interface identifier for IClassFactory).
		/// </param>
		/// <param name="ppv">
		/// The address of a pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppv contains
		/// the requested interface pointer. If an error occurs, the interface pointer is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The object was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_CLASSNOTAVAILABLE</term>
		/// <term>The DLL does not support the class (object definition).</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a call to the CoGetClassObject function finds the class object that is to be loaded in a DLL, <c>CoGetClassObject</c> uses the
		/// DLL's exported <c>DllGetClassObject</c> function.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should not call <c>DllGetClassObject</c> directly. When an object is defined in a DLL, CoGetClassObject calls the
		/// CoLoadLibrary function to load the DLL, which, in turn, calls <c>DllGetClassObject</c>.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>You need to implement <c>DllGetClassObject</c> in (and export it from) DLLs that support COM.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following is an example (in C++) of an implementation of <c>DllGetClassObject</c>. In this example, <c>DllGetClassObject</c>
		/// creates a class object and calls its QueryInterface method to retrieve a pointer to the interface requested in riid. The
		/// implementation releases the reference it holds to the IClassFactory interface because it returns a reference-counted pointer to
		/// <c>IClassFactory</c> to the caller.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-dllgetclassobject HRESULT DllGetClassObject(
		// REFCLSID rclsid, REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "42c08149-c251-47f7-a81f-383975d7081c")]
		public static extern HRESULT DllGetClassObject(in Guid rclsid, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppv);

		/// <summary>
		/// The <c>FreePropVariantArray</c> function calls PropVariantClear on each of the PROPVARIANT structures in the rgvars array to make
		/// the value zero for each of the members of the array.
		/// </summary>
		/// <param name="cVariants">Count of elements in the PROPVARIANT array (rgvars).</param>
		/// <param name="rgvars">
		/// Pointer to an initialized array of PROPVARIANT structures for which any deallocatable elements are to be freed. On exit, all
		/// zeroes are written to the <c>PROPVARIANT</c> structure (thus tagging them as VT_EMPTY).
		/// </param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// <c>FreePropVariantArray</c> calls PropVariantClear on an array of PROPVARIANT structures to clear all the valid members. All
		/// valid <c>PROPVARIANT</c> structures are freed. If any of the <c>PROPVARIANT</c> structures contain illegal VT types, valid
		/// members are freed and the function returns STG_E_INVALIDPARAMETER.
		/// </para>
		/// <para>Passing <c>NULL</c> for rgvars is legal, and produces a return code of S_OK.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-freepropvariantarray?redirectedfrom=MSDN HRESULT
		// FreePropVariantArray( ULONG cVariants, PROPVARIANT *rgvars );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "2eefb57e-9311-46e1-9eed-e25aa3b5afaa")]
		public static extern HRESULT FreePropVariantArray(uint cVariants, PROPVARIANT rgvars);

		/// <summary>
		/// The <c>GetHGlobalFromStream</c> function retrieves the global memory handle to a stream that was created through a call to the
		/// CreateStreamOnHGlobal function.
		/// </summary>
		/// <param name="pstm">IStream pointer to the stream object previously created by a call to the CreateStreamOnHGlobal function.</param>
		/// <param name="phglobal">Pointer to the current memory handle used by the specified stream object.</param>
		/// <returns>This function returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// The handle <c>GetHGlobalFromStream</c> returns may be different from the original handle due to intervening GlobalReAlloc calls.
		/// </para>
		/// <para>This function can be called only from within the same process from which the byte array was created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-gethglobalfromstream HRESULT GetHGlobalFromStream(
		// LPSTREAM pstm, HGLOBAL *phglobal );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "79e39345-7a20-4b0f-bceb-f62de13d3260")]
		public static extern HRESULT GetHGlobalFromStream(IStream pstm, out IntPtr phglobal);

		/// <summary>Converts a string generated by the StringFromIID function back into the original interface identifier (IID).</summary>
		/// <param name="lpsz">A pointer to the string representation of the IID.</param>
		/// <param name="lpiid">A pointer to the requested IID on return.</param>
		/// <returns>This function can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// The function converts the interface identifier in a way that guarantees different interface identifiers will always be converted
		/// to different strings.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-iidfromstring HRESULT IIDFromString( LPCOLESTR lpsz,
		// LPIID lpiid );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "7fa72a65-68f8-438e-8a0c-6e0e0208420d")]
		public static extern HRESULT IIDFromString([MarshalAs(UnmanagedType.LPWStr)] string lpsz, out Guid lpiid);

		/// <summary>Retrieves the ProgID for a given CLSID.</summary>
		/// <param name="clsid">The CLSID for which the ProgID is to be requested.</param>
		/// <param name="lplpszProgID">
		/// The address of a pointer variable that receives the ProgID string. The string that represents clsid includes enclosing braces.
		/// </param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The ProgID was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_CLASSNOTREG</term>
		/// <term>Class not registered in the registry.</term>
		/// </item>
		/// <item>
		/// <term>REGDB_E_READREGDB</term>
		/// <term>There was an error reading from the registry.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every OLE object class listed in the <c>Insert Object</c> dialog box must have a programmatic identifier (ProgID), a string that
		/// uniquely identifies a given class, stored in the registry. In addition to determining the eligibility for the <c>Insert
		/// Object</c> dialog box, the ProgID can be used as an identifier in a macro programming language to identify a class. Finally, the
		/// ProgID is also the class name used for an object of an OLE class that is placed in an OLE 1 container.
		/// </para>
		/// <para>
		/// <c>ProgIDFromCLSID</c> uses entries in the registry to do the conversion. OLE application authors are responsible for ensuring
		/// that the registry is configured correctly in the application's setup program.
		/// </para>
		/// <para>
		/// The ProgID string must be different than the class name of any OLE 1 application, including the OLE 1 version of the same
		/// application, if there is one. In addition, a ProgID string must not contain more than 39 characters, start with a digit, or,
		/// except for a single period, contain any punctuation (including underscores).
		/// </para>
		/// <para>
		/// The ProgID must never be shown to the user in the user interface. If you need a short displayable string for an object, call IOleObject::GetUserType.
		/// </para>
		/// <para>
		/// Call the CLSIDFromProgID function to find the CLSID associated with a given ProgID. Be sure to free the returned ProgID when you
		/// are finished with it by calling the CoTaskMemFree function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-progidfromclsid HRESULT ProgIDFromCLSID( REFCLSID
		// clsid, LPOLESTR *lplpszProgID );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("combaseapi.h", MSDNShortId = "a863cbc2-f8ab-468a-8254-b273077a6a2b")]
		public static extern HRESULT ProgIDFromCLSID(in Guid clsid, [MarshalAs(UnmanagedType.LPWStr)] out string lplpszProgID);

		/// <summary>Creates an agile reference for an object specified by the given interface.</summary>
		/// <param name="options">The options.</param>
		/// <param name="riid">The interface ID of the object for which an agile reference is being obtained.</param>
		/// <param name="pUnk">
		/// Pointer to the interface to be encapsulated in an agile reference. It must be the same type as riid. It may be a pointer to an
		/// in-process object or a pointer to a proxy of an object.
		/// </param>
		/// <param name="ppAgileReference">
		/// The agile reference for the object. Call the Resolve method to localize the object into the apartment in which <c>Resolve</c> is called.
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The options parameter in invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The agile reference couldn't be constructed due to an out-of-memory condition.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The pUnk parameter doesn't support the interface ID specified by the riid parameter.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_NOT_SUPPORTED</term>
		/// <term>The object implements the INoMarshal interface.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Call the <c>RoGetAgileReference</c> function on an existing object to request an agile reference to the object. The object may or
		/// may not be agile, but the returned IAgileReference is agile. The agile reference can be passed to another apartment within the
		/// same process, where the original object is retrieved by using the <c>IAgileReference</c> interface.
		/// </para>
		/// <para>
		/// This is conceptually similar to the existing Global Interface Table (GIT). Rather than interacting with the GIT, an
		/// IAgileReference is obtained and used to retrieve the object directly. Just as the GIT is per-process only, agile references are
		/// per-process and can't be marshaled.
		/// </para>
		/// <para>
		/// The agile reference feature provides a performance improvement over the GIT. The agile reference performs eager marshaling by
		/// default, which saves a cross-apartment call in cases where the object is retrieved from the agile reference in an apartment
		/// that's different from where the agile reference was created. For additional performance improvement, users of the
		/// <c>RoGetAgileReference</c> function can use the same interface to create an IAgileReference and resolve the original object. This
		/// saves an additional QueryInterface call to obtain the desired interface from the resolved object.
		/// </para>
		/// <para>
		/// For example, you have a non-agile object named CDemoExample, which implements the IDemo and IExample interfaces. Call the
		/// <c>RoGetAgileReference</c> function and pass the object, with IID_IDemo. You get back an IAgileReference interface pointer, which
		/// is agile, so you can pass it to a different apartment. In the other apartment, call the Resolve method, with IID_IExample. You
		/// get back an IExample pointer that you can use within this apartment. This IExample pointer is an IExample proxy that's connected
		/// to the original CDemoExample object. The agile reference handles the complexity of operations like manually marshaling to a
		/// stream and unmarshaling on the other side of the apartment boundary.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-rogetagilereference HRESULT RoGetAgileReference(
		// AgileReferenceOptions options , REFIID riid, IUnknown *pUnk, IAgileReference **ppAgileReference );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "D16224C7-1BB7-46F5-B66C-54D0B9679006")]
		public static extern HRESULT RoGetAgileReference(AgileReferenceOptions options, in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk, out IAgileReference ppAgileReference);

		/// <summary>Converts a CLSID into a string of printable characters. Different CLSIDs always convert to different strings.</summary>
		/// <param name="rclsid">The CLSID to be converted.</param>
		/// <param name="lplpsz">
		/// The address of a pointer variable that receives a pointer to the resulting string. The string that represents rclsid includes
		/// enclosing braces.
		/// </param>
		/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// <c>StringFromCLSID</c> calls the StringFromGUID2 function to convert a globally unique identifier (GUID) into a string of
		/// printable characters.
		/// </para>
		/// <para>The caller is responsible for freeing the memory allocated for the string by calling the CoTaskMemFree function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromclsid HRESULT StringFromCLSID( REFCLSID
		// rclsid, LPOLESTR *lplpsz );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "61210ebd-cbf3-4e78-b077-53d2779053eb")]
		public static extern HRESULT StringFromCLSID(in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] out string lplpsz);

		/// <summary>Converts a globally unique identifier (GUID) into a string of printable characters.</summary>
		/// <param name="rguid">The GUID to be converted.</param>
		/// <param name="lpsz">
		/// A pointer to a caller-allocated string variable to receive the resulting string. The string that represents rguid includes
		/// enclosing braces.
		/// </param>
		/// <param name="cchMax">The number of characters available in the lpsz buffer.</param>
		/// <returns>
		/// If the function succeeds, the return value is the number of characters in the returned string, including the null terminator. If
		/// the buffer is too small to contain the string, the return value is 0.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromguid2 int StringFromGUID2( REFGUID rguid,
		// LPOLESTR lpsz, int cchMax );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "5f437658-b749-416b-805a-2afdac682660")]
		public static extern int StringFromGUID2(in Guid rguid, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder lpsz, int cchMax);

		/// <summary>Converts an interface identifier into a string of printable characters.</summary>
		/// <param name="rclsid">The interface identifier to be converted.</param>
		/// <param name="lplpsz">
		/// The address of a pointer variable that receives a pointer to the resulting string. The string that represents rclsid includes
		/// enclosing braces.
		/// </param>
		/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		/// <remarks>The caller is responsible for freeing the memory allocated for the string by calling the CoTaskMemFree function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/combaseapi/nf-combaseapi-stringfromiid HRESULT StringFromIID( REFIID rclsid,
		// LPOLESTR *lplpsz );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "92e59631-0675-4bca-bcd4-a1f83ab6ec8a")]
		public static extern HRESULT StringFromIID(in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] out string lplpsz);

	}
}