using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Values that are used in activation calls to indicate the execution contexts in which an object is to be run. These values are
		/// also used in calls to CoRegisterClassObject to indicate the set of execution contexts in which a class object is to be made
		/// available for requests to construct instances.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Values from the <c>CLSCTX</c> enumeration are used in activation calls (CoCreateInstance, CoCreateInstanceEx, CoGetClassObject,
		/// and so on) to indicate the preferred execution contextsâ€”in-process, local, or remoteâ€”in which an object is to be run. They
		/// are also used in calls to CoRegisterClassObject to indicate the set of execution contexts in which a class object is to be made
		/// available for requests to construct instances ( <c>IClassFactory::CreateInstance</c>).
		/// </para>
		/// <para>
		/// To indicate that more than one context is acceptable, you can combine multiple values with Boolean ORs. The contexts are tried in
		/// the order in which they are listed.
		/// </para>
		/// <para>
		/// Given a set of <c>CLSCTX</c> flags, the execution context to be used depends on the availability of registered class codes and
		/// other parameters according to the following algorithm.
		/// </para>
		/// <list type="number">
		///   <item>
		///     <term>
		/// If the call specifies one of the following, CLSCTX_REMOTE_SERVER is implied and is added to the list of flags: The second case
		/// allows applications written prior to the release of distributed COM to be the configuration of classes for remote activation to
		/// be used by client applications available prior to DCOM and the CLSCTX_REMOTE_SERVER flag. The cases in which there would be no
		/// explicit COSERVERINFO structure are when the value is specified as <c>NULL</c> or when it is not one of the function parameters
		/// (as in calls to CoCreateInstance and CoGetClassObject).
		/// </term>
		///   </item>
		///   <item>
		///     <term>If the explicit COSERVERINFO parameter indicates the current computer, CLSCTX_REMOTE_SERVER is removed if present.</term>
		///   </item>
		/// </list>
		/// <para>The rest of the processing proceeds by looking at the value(s) in the following sequence:</para>
		/// <list type="number">
		///   <item>
		///     <term>
		/// If the flags include CLSCTX_REMOTE_SERVER and no COSERVERINFO parameter is specified and if the activation request indicates a
		/// persistent state from which to initialize the object (with CoGetInstanceFromFile, CoGetInstanceFromIStorage, or, for a file
		/// moniker, in a call to IMoniker::BindToObject) and the class has an ActivateAtStorage subkey or no class registry information
		/// whatsoever, the request to activate and initialize is forwarded to the computer where the persistent state resides. (Refer to the
		/// remote activation functions listed in the See Also section for details.)
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If the flags include CLSCTX_INPROC_SERVER, the class code in the DLL found under the class's InprocServer32 key is used if this
		/// key exists. The class code will run within the same process as the caller.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If the flags include CLSCTX_INPROC_HANDLER, the class code in the DLL found under the class's InprocHandler32 key is used if this
		/// key exists. The class code will run within the same process as the caller.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If the flags include CLSCTX_LOCAL_SERVER, the class code in the service found under the class's LocalService key is used if this
		/// key exists. If no service is specified but an EXE is specified under that same key, the class code associated with that EXE is
		/// used. The class code (in either case) will be run in a separate service process on the same computer as the caller.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If the flag is set to CLSCTX_REMOTE_SERVER and an additional COSERVERINFO parameter to the function specifies a particular remote
		/// computer, a request to activate is forwarded to this remote computer with flags modified to set to CLSCTX_LOCAL_SERVER. The class
		/// code will run in its own process on this specific computer, which must be different from that of the caller.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// Finally, if the flags include CLSCTX_REMOTE_SERVER and no COSERVERINFO parameter is specified and if a computer name is given
		/// under the class's RemoteServerName named-value, the request to activate is forwarded to this remote computer with the flags
		/// modified to be set to CLSCTX_LOCAL_SERVER. The class code will run in its own process on this specific computer, which must be
		/// different from that of the caller.
		/// </term>
		///   </item>
		/// </list>
		/// <para>CLSCTX_ACTIVATE_32_BIT_SERVER and CLSCTX_ACTIVATE_64_BIT_SERVER</para>
		/// <para>
		/// The 64-bit versions of Windows introduce two new flags: CLSCTX_ACTIVATE_32_BIT_SERVER and CLSCTX_ACTIVATE_64_BIT_SERVER. On a
		/// 64-bit computer, a 32-bit and 64-bit version of the same COM server may coexist. When a client requests an activation of an
		/// out-of-process server, these <c>CLSCTX</c> flags allow the client to specify a 32-bit or a 64-bit version of the server.
		/// </para>
		/// <para>
		/// Usually, a client will not care whether it uses a 32-bit or a 64-bit version of the server. However, if the server itself loads
		/// an additional in-process server, then it and the in-process server must both be either 32-bit or 64-bit. For example, suppose
		/// that the client wants to use a server "A", which in turn loads an in-process server "B". If only a 32-bit version of server "B"
		/// is available, then the client must specify the 32-bit version of server "A". If only a 64-bit version of server "B" is available,
		/// then the client must specify the 64-bit version of server "A".
		/// </para>
		/// <para>
		/// A server can specify its own architecture preference via the PreferredServerBitness registry key, but the client's preference,
		/// specified via a CLSCTX_ACTIVATE_32_BIT_SERVER or CLSCTX_ACTIVATE_64_BIT_SERVER flag, will override the server's preference. If
		/// the client does not specify a preference, then the server's preference will be used.
		/// </para>
		/// <para>If neither the client nor the server specifies a preference, then:</para>
		/// <list type="bullet">
		///   <item>
		///     <term>
		/// If the computer that hosts the server is running Windows Server 2003 with Service Pack 1 (SP1) or a later system, then COM will
		/// try to match the server architecture to the client architecture. In other words, for a 32-bit client, COM will activate a 32-bit
		/// server if available; otherwise it will activate a 64-bit version of the server. For a 64-bit client, COM will activate a 64-bit
		/// server if available; otherwise it will activate a 32-bit server.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If the computer that hosts the server is running Windows XP or Windows Server 2003 without SP1 or later installed, then COM will
		/// prefer a 64-bit version of the server if available; otherwise it will activate a 32-bit version of the server.
		/// </term>
		///   </item>
		/// </list>
		/// <para>
		/// If a <c>CLSCTX</c> enumeration has both the CLSCTX_ACTIVATE_32_BIT_SERVER and CLSCTX_ACTIVATE_64_BIT_SERVER flags set, then it is
		/// invalid and the activation will return E_INVALIDARG.
		/// </para>
		/// <para>
		/// The following table shows the results of the various combinations of client architectures and client settings and server
		/// architectures and server settings.
		/// </para>
		/// <para>
		/// The flags CLSCTX_ACTIVATE_32_BIT_SERVER and CLSCTX_ACTIVATE_64_BIT_SERVER flow across computer boundaries. If the computer that
		/// hosts the server is running the 64-bit Windows, then it will honor these flags; otherwise it will ignore them.
		/// </para>
		/// <list type="table">
		///   <listheader>
		///     <term />
		///     <term>32-bit client, no flag</term>
		///     <term>64-bit client, no flag</term>
		///     <term>32-bit client, 32-bit flag¹</term>
		///     <term>32-bit client, 64-bit flag²</term>
		///     <term>64-bit client, 32-bit flag¹</term>
		///     <term>64-bit client, 64-bit flag²</term>
		///   </listheader>
		///   <item>
		///     <term>32-bit server, match client registry value³</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///   </item>
		///   <item>
		///     <term>32-bit server, 32-bit registry value⁴</term>
		///     <term>32-bit server</term>
		///     <term>32-bit server</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///   </item>
		///   <item>
		///     <term>32-bit server, 64-bit registry value⁵</term>
		///     <term>See ⁸</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///   </item>
		///   <item>
		///     <term>32-bit server, no registry value⁶</term>
		///     <term>32-bit server</term>
		///     <term>64/32⁹</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///   </item>
		///   <item>
		///     <term>32-bit server, no registry value (before Windows Server 2003 with SP1)⁷</term>
		///     <term>64/32⁹</term>
		///     <term>64/32⁹</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///     <term>32-bit server</term>
		///     <term>See ⁸</term>
		///   </item>
		///   <item>
		///     <term>64-bit server, match client registry value³</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///   </item>
		///   <item>
		///     <term>64-bit server, 32-bit registry value⁴</term>
		///     <term>See ⁸</term>
		///     <term>See ⁸</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///   </item>
		///   <item>
		///     <term>64-bit server, 64-bit registry value⁵</term>
		///     <term>64-bit server</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///   </item>
		///   <item>
		///     <term>64-bit server, no registry value⁶</term>
		///     <term>32/64¹⁰</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///   </item>
		///   <item>
		///     <term>64-bit server, no registry value (before Windows Server 2003 with SP1)⁷</term>
		///     <term>64-bit server</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///     <term>See ⁸</term>
		///     <term>64-bit server</term>
		///   </item>
		/// </list>
		/// <para>
		///   <c>PreferredServerBitness</c> PreferredServerBitness <c>PreferredServerBitness</c><c>PreferredServerBitness</c><c>PreferredServerBitness</c><c>PreferredServerBitness</c></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wtypesbase/ne-wtypesbase-tagclsctx typedef enum tagCLSCTX {
		// CLSCTX_INPROC_SERVER, CLSCTX_INPROC_HANDLER, CLSCTX_LOCAL_SERVER, CLSCTX_INPROC_SERVER16, CLSCTX_REMOTE_SERVER,
		// CLSCTX_INPROC_HANDLER16, CLSCTX_RESERVED1, CLSCTX_RESERVED2, CLSCTX_RESERVED3, CLSCTX_RESERVED4, CLSCTX_NO_CODE_DOWNLOAD,
		// CLSCTX_RESERVED5, CLSCTX_NO_CUSTOM_MARSHAL, CLSCTX_ENABLE_CODE_DOWNLOAD, CLSCTX_NO_FAILURE_LOG, CLSCTX_DISABLE_AAA,
		// CLSCTX_ENABLE_AAA, CLSCTX_FROM_DEFAULT_CONTEXT, CLSCTX_ACTIVATE_X86_SERVER, CLSCTX_ACTIVATE_32_BIT_SERVER,
		// CLSCTX_ACTIVATE_64_BIT_SERVER, CLSCTX_ENABLE_CLOAKING, CLSCTX_APPCONTAINER, CLSCTX_ACTIVATE_AAA_AS_IU, CLSCTX_RESERVED6,
		// CLSCTX_ACTIVATE_ARM32_SERVER, CLSCTX_PS_DLL } CLSCTX;
		[PInvokeData("wtypesbase.h", MSDNShortId = "dcb82ff2-56e4-4c7e-a621-7ffd0f1a9d8e")]
		[Flags]
		public enum CLSCTX : uint
		{
			/// <summary>
			/// The code that creates and manages objects of this class is a DLL that runs in the same process as the caller of the function
			/// specifying the class context.
			/// </summary>
			CLSCTX_INPROC_SERVER = 0x00000001,

			/// <summary>
			/// The code that manages objects of this class is an in-process handler. This is a DLL that runs in the client process and
			/// implements client-side structures of this class when instances of the class are accessed remotely.
			/// </summary>
			CLSCTX_INPROC_HANDLER = 0x00000002,

			/// <summary>
			/// The EXE code that creates and manages objects of this class runs on same machine but is loaded in a separate process space.
			/// </summary>
			CLSCTX_LOCAL_SERVER = 0x00000004,

			/// <summary>Obsolete.</summary>
			CLSCTX_INPROC_SERVER16 = 0x00000008,

			/// <summary>
			/// A remote context. The LocalServer32 or LocalService code that creates and manages objects of this class is run on a different computer.
			/// </summary>
			CLSCTX_REMOTE_SERVER = 0x00000010,

			/// <summary>Obsolete.</summary>
			CLSCTX_INPROC_HANDLER16 = 0x00000020,

			/// <summary>Reserved.</summary>
			CLSCTX_RESERVED1 = 0x00000040,

			/// <summary>Reserved.</summary>
			CLSCTX_RESERVED2 = 0x00000080,

			/// <summary>Reserved.</summary>
			CLSCTX_RESERVED3 = 0x00000100,

			/// <summary>Reserved.</summary>
			CLSCTX_RESERVED4 = 0x00000200,

			/// <summary>
			/// Disaables the downloading of code from the directory service or the Internet. This flag cannot be set at the same time as CLSCTX_ENABLE_CODE_DOWNLOAD.
			/// </summary>
			CLSCTX_NO_CODE_DOWNLOAD = 0x00000400,

			/// <summary>Reserved.</summary>
			CLSCTX_RESERVED5 = 0x00000800,

			/// <summary>Specify if you want the activation to fail if it uses custom marshalling.</summary>
			CLSCTX_NO_CUSTOM_MARSHAL = 0x00001000,

			/// <summary>
			/// Enables the downloading of code from the directory service or the Internet. This flag cannot be set at the same time as CLSCTX_NO_CODE_DOWNLOAD.
			/// </summary>
			CLSCTX_ENABLE_CODE_DOWNLOAD = 0x00002000,

			/// <summary>
			/// The CLSCTX_NO_FAILURE_LOG can be used to override the logging of failures in CoCreateInstanceEx. If the
			/// ActivationFailureLoggingLevel is created, the following values can determine the status of event logging:
			/// </summary>
			CLSCTX_NO_FAILURE_LOG = 0x00004000,

			/// <summary>
			/// Disables activate-as-activator (AAA) activations for this activation only. This flag overrides the setting of the
			/// EOAC_DISABLE_AAA flag from the EOLE_AUTHENTICATION_CAPABILITIES enumeration. This flag cannot be set at the same time as
			/// CLSCTX_ENABLE_AAA. Any activation where a server process would be launched under the caller's identity is known as an
			/// activate-as-activator (AAA) activation. Disabling AAA activations allows an application that runs under a privileged account
			/// (such as LocalSystem) to help prevent its identity from being used to launch untrusted components. Library applications that
			/// use activation calls should always set this flag during those calls. This helps prevent the library application from being
			/// used in an escalation-of-privilege security attack. This is the only way to disable AAA activations in a library application
			/// because the EOAC_DISABLE_AAA flag from the EOLE_AUTHENTICATION_CAPABILITIES enumeration is applied only to the server process
			/// and not to the library application. Windows 2000: This flag is not supported.
			/// </summary>
			CLSCTX_DISABLE_AAA = 0x00008000,

			/// <summary>
			/// Enables activate-as-activator (AAA) activations for this activation only. This flag overrides the setting of the
			/// EOAC_DISABLE_AAA flag from the EOLE_AUTHENTICATION_CAPABILITIES enumeration. This flag cannot be set at the same time as
			/// CLSCTX_DISABLE_AAA. Any activation where a server process would be launched under the caller's identity is known as an
			/// activate-as-activator (AAA) activation. Enabling this flag allows an application to transfer its identity to an activated
			/// component. Windows 2000: This flag is not supported.
			/// </summary>
			CLSCTX_ENABLE_AAA = 0x00010000,

			/// <summary>Begin this activation from the default context of the current apartment.</summary>
			CLSCTX_FROM_DEFAULT_CONTEXT = 0x00020000,

			/// <summary/>
			CLSCTX_ACTIVATE_X86_SERVER = 0x00040000,

			/// <summary>Activate or connect to a 32-bit version of the server; fail if one is not registered.</summary>
			CLSCTX_ACTIVATE_32_BIT_SERVER = CLSCTX_ACTIVATE_X86_SERVER,

			/// <summary>Activate or connect to a 64 bit version of the server; fail if one is not registered.</summary>
			CLSCTX_ACTIVATE_64_BIT_SERVER = 0x00080000,

			/// <summary>
			/// When this flag is specified, COM uses the impersonation token of the thread, if one is present, for the activation request
			/// made by the thread. When this flag is not specified or if the thread does not have an impersonation token, COM uses the
			/// process token of the thread's process for the activation request made by the thread. Windows Vista or later: This flag is supported.
			/// </summary>
			CLSCTX_ENABLE_CLOAKING = 0x00100000,

			/// <summary/>
			CLSCTX_APPCONTAINER = 0x400000,
			
			/// <summary/>
			CLSCTX_ACTIVATE_AAA_AS_IU = 0x800000,
			
			/// <summary/>
			CLSCTX_RESERVED6 = 0x1000000,

			/// <summary/>
			CLSCTX_ACTIVATE_ARM32_SERVER = 0x2000000,

			/// <summary>Used for loading Proxy/Stub DLLs.</summary>
			CLSCTX_PS_DLL = 0x80000000
		}

		/// <summary>
		/// Determines the concurrency model used for incoming calls to objects created by this thread. This concurrency model can be either
		/// apartment-threaded or multithreaded.
		/// </summary>
		[Flags]
		[PInvokeData("Objbase.h", MSDNShortId = "ms678505")]
		public enum COINIT
		{
			/// <summary>Initializes the thread for apartment-threaded object concurrency (see Remarks).</summary>
			COINIT_APARTMENTTHREADED = 0x2,

			/// <summary>Initializes the thread for multithreaded object concurrency (see Remarks).</summary>
			COINIT_MULTITHREADED = 0x0,

			/// <summary>Disables DDE for OLE1 support.</summary>
			COINIT_DISABLE_OLE1DDE = 0x4,

			/// <summary>Increase memory usage in an attempt to increase performance.</summary>
			COINIT_SPEED_OVER_MEMORY = 0x8
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

		/// <summary>
		/// The STGFMT enumeration values specify the format of a storage object and are used in the StgCreateStorageEx and StgOpenStorageEx
		/// functions in the stgfmt parameter. This value, in combination with the value in the riid parameter, is used to determine the file
		/// format and the interface implementation to use.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380330")]
		public enum STGFMT
		{
			/// <summary>Indicates that the file must be a compound file.</summary>
			STGFMT_STORAGE = 0,

			/// <summary>Undocumented.</summary>
			STGFMT_NATIVE = 1,

			/// <summary>
			/// Indicates that the file must not be a compound file. This element is only valid when using the StgCreateStorageEx or
			/// StgOpenStorageEx functions to access the NTFS file system implementation of the IPropertySetStorage interface. Therefore,
			/// these functions return an error if the riid parameter does not specify the IPropertySetStorage interface, or if the specified
			/// file is not located on an NTFS file system volume.
			/// </summary>
			STGFMT_FILE = 3,

			/// <summary>
			/// Indicates that the system will determine the file type and use the appropriate structured storage or property set
			/// implementation. This value cannot be used with the StgCreateStorageEx function.
			/// </summary>
			STGFMT_ANY = 4,

			/// <summary>
			/// Indicates that the file must be a compound file, and is similar to the STGFMT_STORAGE flag, but indicates that the
			/// compound-file form of the compound-file implementation must be used. For more information, see Compound File Implementation Limits.
			/// </summary>
			STGFMT_DOCFILE = 5
		}

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
		/// Initializes the COM library for use by the calling thread, sets the thread's concurrency model, and creates a new apartment for
		/// the thread if one is required.
		/// <para>
		/// You should call Windows::Foundation::Initialize to initialize the thread instead of CoInitializeEx if you want to use the Windows
		/// Runtime APIs or if you want to use both COM and Windows Runtime components. Windows::Foundation::Initialize is sufficient to use
		/// for COM components.
		/// </para>
		/// </summary>
		/// <param name="pvReserved">This parameter is reserved and must be NULL.</param>
		/// <param name="coInit">
		/// The concurrency model and initialization options for the thread. Values for this parameter are taken from the COINIT enumeration.
		/// Any combination of values from COINIT can be used, except that the COINIT_APARTMENTTHREADED and COINIT_MULTITHREADED flags cannot
		/// both be set. The default is COINIT_MULTITHREADED.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <defintion>The COM library was initialized successfully on this thread.</defintion>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <defintion>The COM library is already initialized on this thread.</defintion>
		/// </item>
		/// <item>
		/// <term>RPC_E_CHANGED_MODE</term>
		/// <defintion>A previous call to CoInitializeEx specified the concurrency model for this thread as multithreaded apartment (MTA).
		/// This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.</defintion>
		/// </item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms695279")]
		public static extern HRESULT CoInitializeEx([Optional] IntPtr pvReserved, COINIT coInit);

		/// <summary>Registers security and sets the default security values for the process.</summary>
		/// <param name="pSecDesc">
		/// The access permissions that a server will use to receive calls. This parameter is used by COM only when a server calls
		/// <c>CoInitializeSecurity</c>. Its value is a pointer to one of three types: an AppID, an <c>IAccessControl</c> object, or a
		/// <c>SECURITY_DESCRIPTOR</c>, in absolute format. See the Remarks section for more information.
		/// </param>
		/// <param name="cAuthSvc">
		/// The count of entries in the asAuthSvc parameter. This parameter is used by COM only when a server calls
		/// <c>CoInitializeSecurity</c>. If this parameter is 0, no authentication services will be registered and the server cannot receive
		/// secure calls. A value of -1 tells COM to choose which authentication services to register, and if this is the case, the asAuthSvc
		/// parameter must be <c>NULL</c>. However, Schannel will never be chosen as an authentication service by the server if this
		/// parameter is -1.
		/// </param>
		/// <param name="asAuthSvc">
		/// An array of authentication services that a server is willing to use to receive a call. This parameter is used by COM only when a
		/// server calls <c>CoInitializeSecurity</c>. For more information, see <c>SOLE_AUTHENTICATION_SERVICE</c>.
		/// </param>
		/// <param name="pReserved1">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="dwAuthnLevel">
		/// The default authentication level for the process. Both servers and clients use this parameter when they call
		/// <c>CoInitializeSecurity</c>. COM will fail calls that arrive with a lower authentication level. By default, all proxies will use
		/// at least this authentication level. This value should contain one of the authentication level constants. By default, all calls to
		/// <c>IUnknown</c> are made at this level.
		/// </param>
		/// <param name="dwImpLevel">
		/// <para>
		/// The default impersonation level for proxies. The value of this parameter is used only when the process is a client. It should be
		/// a value from the impersonation level constants, except for RPC_C_IMP_LEVEL_DEFAULT, which is not for use with <c>CoInitializeSecurity</c>.
		/// </para>
		/// <para>
		/// Outgoing calls from the client always use the impersonation level as specified. (It is not negotiated.) Incoming calls to the
		/// client can be at any impersonation level. By default, all <c>IUnknown</c> calls are made with this impersonation level, so even
		/// security-aware applications should set this level carefully. To determine which impersonation levels each authentication service
		/// supports, see the description of the authentication services in COM and Security Packages. For more information about
		/// impersonation levels, see Impersonation.
		/// </para>
		/// </param>
		/// <param name="pAuthList">
		/// A pointer to <c>SOLE_AUTHENTICATION_LIST</c>, which is an array of <c>SOLE_AUTHENTICATION_INFO</c> structures. This list
		/// indicates the information for each authentication service that a client can use to call a server. This parameter is used by COM
		/// only when a client calls <c>CoInitializeSecurity</c>.
		/// </param>
		/// <param name="dwCapabilities">
		/// Additional capabilities of the client or server, specified by setting one or more <c>EOLE_AUTHENTICATION_CAPABILITIES</c> values.
		/// Some of these value cannot be used simultaneously, and some cannot be set when particular authentication services are being used.
		/// For more information about these flags, see the Remarks section.
		/// </param>
		/// <param name="pReserved3">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
		/// <para>
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
		/// <term>RPC_E_TOO_LATE</term>
		/// <term>CoInitializeSecurity has already been called.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_NO_GOOD_SECURITY_PACKAGES</term>
		/// <term>
		/// The asAuthSvc parameter was not NULL, and none of the authentication services in the list could be registered. Check the results
		/// saved in asAuthSvc for authentication service–specific error codes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUT_OF_MEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT CoInitializeSecurity( _In_opt_ PSECURITY_DESCRIPTOR pSecDesc, _In_ LONG cAuthSvc, _In_opt_ SOLE_AUTHENTICATION_SERVICE
		// *asAuthSvc, _In_opt_ void *pReserved1, _In_ DWORD dwAuthnLevel, _In_ DWORD dwImpLevel, _In_opt_ void *pAuthList, _In_ DWORD
		// dwCapabilities, _In_opt_ void *pReserved3); https://msdn.microsoft.com/en-us/library/windows/desktop/ms693736(v=vs.85).aspx
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms693736")]
		public static extern HRESULT CoInitializeSecurity([Optional] IntPtr pSecDesc, int cAuthSvc, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SOLE_AUTHENTICATION_SERVICE[] asAuthSvc,
			[Optional] IntPtr pReserved1, RPC_C_AUTHN_LEVEL dwAuthnLevel, RPC_C_IMP_LEVEL dwImpLevel, in SOLE_AUTHENTICATION_LIST pAuthList, EOLE_AUTHENTICATION_CAPABILITIES dwCapabilities,
			[Optional] IntPtr pReserved3);

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
		/// Closes the COM library on the current thread, unloads all DLLs loaded by the thread, frees any other resources that the thread
		/// maintains, and forces all RPC connections on the thread to close.
		/// </summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms688715")]
		public static extern void CoUninitialize();

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

		/// <summary>
		/// Returns a pointer to an implementation of IBindCtx (a bind context object). This object stores information about a particular
		/// moniker-binding operation.
		/// </summary>
		/// <param name="reserved">This parameter is reserved and must be 0.</param>
		/// <param name="ppbc">
		/// Address of an IBindCtx* pointer variable that receives the interface pointer to the new bind context object. When the function is
		/// successful, the caller is responsible for calling Release on the bind context. A NULL value for the bind context indicates that
		/// an error occurred.
		/// </param>
		/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms678542")]
		public static extern HRESULT CreateBindCtx([Optional] uint reserved, out IBindCtx ppbc);

		/// <summary>Creates a file moniker based on the specified path.</summary>
		/// <param name="lpszPathName">
		/// <para>The path on which this moniker is to be based.</para>
		/// <para>
		/// This parameter can specify a relative path, a UNC path, or a drive-letter-based path. If based on a relative path, the resulting
		/// moniker must be composed onto another file moniker before it can be bound.
		/// </para>
		/// </param>
		/// <param name="ppmk">
		/// The address of an IMoniker* pointer variable that receives the interface pointer to the new file moniker. When successful, the
		/// function has called AddRef on the file moniker and the caller is responsible for calling Release. When an error occurs, the value
		/// of the interface pointer is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This function can return the standard return value E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The moniker was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>MK_E_SYNTAX</term>
		/// <term>There was an error in the syntax of the path.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateFileMoniker</c> creates a moniker for an object that is stored in a file. A moniker provider (an object that provides
		/// monikers to other objects) can call this function to create a moniker to identify a file-based object that it controls, and can
		/// then make the pointer to this moniker available to other objects. An object identified by a file moniker must also implement the
		/// IPersistFile interface so it can be loaded when a file moniker is bound.
		/// </para>
		/// <para>
		/// When each object resides in its own file, as in an OLE server application that supports linking only to file-based documents in
		/// their entirety, file monikers are the only type of moniker necessary. To identify objects smaller than a file, the moniker
		/// provider must use another type of moniker (such as an item moniker) in addition to file monikers, creating a composite moniker.
		/// Composite monikers would be needed in an OLE server application that supports linking to objects smaller than a document (such as
		/// sections of a document or embedded objects).
		/// </para>
		/// <para>
		/// A file moniker can be composed to the right only of another file moniker when the first moniker is based on an absolute path and
		/// the other is a relative path, resulting in a single file moniker based on the combination of the two paths. A moniker composed to
		/// the right of another moniker must be a refinement of that moniker, and the file moniker represents the largest unit of storage.
		/// To identify objects stored within a file, you would compose other types of monikers (usually item monikers) to the right of a
		/// file moniker.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-createfilemoniker HRESULT CreateFileMoniker( LPCOLESTR
		// lpszPathName, LPMONIKER *ppmk );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("objbase.h", MSDNShortId = "d9677fa0-cda0-4b63-a21f-1fd0e27c8f3f")]
		public static extern HRESULT CreateFileMoniker([MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, out IMoniker ppmk);

		/// <summary>Returns a pointer to the IRunningObjectTable interface on the local running object table (ROT).</summary>
		/// <param name="reserved">This parameter is reserved and must be 0.</param>
		/// <param name="pprot">
		/// The address of an IRunningObjectTable* pointer variable that receives the interface pointer to the local ROT. When the function
		/// is successful, the caller is responsible for calling Release on the interface pointer. If an error occurs, *pprot is undefined.
		/// </param>
		/// <returns>This function can return the standard return values E_UNEXPECTED and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// Each workstation has a local ROT that maintains a table of the objects that have been registered as running on that computer.
		/// This function returns an IRunningObjectTable interface pointer, which provides access to that table.
		/// </para>
		/// <para>
		/// Moniker providers, which hand out monikers that identify objects so they are accessible to others, should call
		/// <c>GetRunningObjectTable</c>. Use the interface pointer returned by this function to register your objects when they begin
		/// running, to record the times that those objects are modified, and to revoke their registrations when they stop running. See the
		/// IRunningObjectTable interface for more information.
		/// </para>
		/// <para>
		/// Compound-document link sources are the most common example of moniker providers. These include server applications that support
		/// linking to their documents (or portions of a document) and container applications that support linking to embeddings within their
		/// documents. Server applications that do not support linking can also use the ROT to cooperate with container applications that
		/// support linking to embeddings.
		/// </para>
		/// <para>
		/// If you are implementing the IMoniker interface to write a new moniker class, and you need an interface pointer to the ROT, call
		/// IBindCtx::GetRunningObjectTable rather than the <c>GetRunningObjectTable</c> function. This allows future implementations of the
		/// IBindCtx interface to modify binding behavior.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-getrunningobjecttable HRESULT GetRunningObjectTable( DWORD
		// reserved, LPRUNNINGOBJECTTABLE *pprot );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("objbase.h", MSDNShortId = "65d9cf7d-cc8a-4199-9a4a-7fd67ef8872d")]
		public static extern HRESULT GetRunningObjectTable([Optional] uint reserved, out IRunningObjectTable pprot);

		/// <summary>
		/// The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or
		/// IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>
		/// Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than
		/// StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL.
		/// If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000: Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If
		/// the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot
		/// copy is required when a file is overwritten or converted in the transacted mode.
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter Values</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STGFMT_DOCFILE</term>
		/// <description>
		/// 0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is
		/// not an integer multiple of the underlying disk's physical sector size, this operation will fail.
		/// </description>
		/// </item>
		/// <item>
		/// <term>All other values of stgfmt</term>
		/// <description>Must be 0.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pStgOptions">
		/// The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to
		/// STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the
		/// sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the
		/// ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter.
		/// The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.
		/// </param>
		/// <param name="pSecurityDescriptor">
		/// Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See
		/// CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional: Value must be NULL.</para>
		/// </param>
		/// <param name="riid">
		/// A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage
		/// interface or the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if
		/// operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or
		/// IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>
		/// Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than
		/// StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.
		/// </para>
		/// </summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL.
		/// If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000: Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If
		/// the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the
		/// commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents
		/// of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot
		/// copy is required when a file is overwritten or converted in the transacted mode.
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter Values</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STGFMT_DOCFILE</term>
		/// <description>
		/// 0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is
		/// not an integer multiple of the underlying disk's physical sector size, this operation will fail.
		/// </description>
		/// </item>
		/// <item>
		/// <term>All other values of stgfmt</term>
		/// <description>Must be 0.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pStgOptions">
		/// The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to
		/// STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the
		/// sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the
		/// ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter.
		/// The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.
		/// </param>
		/// <param name="pSecurityDescriptor">
		/// Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See
		/// CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional: Value must be NULL.</para>
		/// </param>
		/// <param name="riid">
		/// A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage
		/// interface or the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if
		/// operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, in STGOPTIONS pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The StgIsStorageFile function indicates whether a particular disk file contains a storage object.</summary>
		/// <param name="pwcsName">
		/// Pointer to the null-terminated Unicode string name of the disk file to be examined. The pwcsName parameter is passed
		/// uninterpreted to the underlying file system.
		/// </param>
		/// <returns>
		/// <list>
		/// <item>
		/// <term>S_OK</term>
		/// <description>Indicates that the file contains a storage object.</description>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <description>Indicates that the file does not contain a storage object.</description>
		/// </item>
		/// <item>
		/// <term>STG_E_FILENOTFOUND</term>
		/// <description>Indicates that the file was not found.</description>
		/// </item>
		/// </list>
		/// <para>
		/// StgIsStorageFile function can also return any file system errors or system errors wrapped in an HRESULT. See Error Handling
		/// Strategies and Handling Unknown Errors
		/// </para>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380334")]
		public static extern HRESULT StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

		/// <summary>
		/// The StgOpenStorage function opens an existing root storage object in the file system. Use this function to open compound files.
		/// Do not use it to open directories, files, or summary catalogs. Nested storage objects can only be opened using their parent
		/// IStorage::OpenStorage method. <note type="note">Applications should use the new function, StgOpenStorageEx, instead of
		/// StgOpenStorage, to take advantage of the enhanced and Windows Structured Storage features. This function, StgOpenStorage, still
		/// exists for compatibility with applications running on Windows 2000.</note>
		/// </summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the null-terminated Unicode string file that contains the storage object to open. This parameter is
		/// ignored if the pstgPriority parameter is not NULL.
		/// </param>
		/// <param name="pstgPriority">
		/// A pointer to the IStorage interface that should be NULL. If not NULL, this parameter is used as described below in the Remarks
		/// section. After StgOpenStorage returns, the storage object specified in pStgPriority may have been released and should no longer
		/// be used.
		/// </param>
		/// <param name="grfMode">Specifies the access mode to use to open the storage object.</param>
		/// <param name="snbExclude">
		/// If not NULL, pointer to a block of elements in the storage to be excluded as the storage object is opened. The exclusion occurs
		/// regardless of whether a snapshot copy happens on the open. Can be NULL.
		/// </param>
		/// <param name="reserved">Indicates reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to a IStorage* pointer variable that receives the interface pointer to the opened storage.</param>
		/// <returns>
		/// The StgOpenStorage function can also return any file system errors or system errors wrapped in an HRESULT. For more information,
		/// see Error Handling Strategies and Handling Unknown Errors.
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380341")]
		public static extern HRESULT StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
			IStorage pstgPriority, STGM grfMode, [In] SNB snbExclude, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>STGs the open storage ex.</summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed
		/// MAX_PATH characters.
		/// <para>
		/// Windows Server 2003 and Windows XP/2000: Unlike the CreateFile function, the MAX_PATH limit cannot be exceeded by using the
		/// "\\?\" prefix.
		/// </para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller
		/// specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion occurs when the commit operation
		/// is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will
		/// be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required
		/// when a file is overwritten or converted in transacted mode.
		/// <para>
		/// If the storage object is opened in direct mode(STGM_DIRECT) with access to either STGM_WRITE or STGM_READWRITE, the sharing mode
		/// must be STGM_SHARE_EXCLUSIVE unless the STGM_DIRECT_SWMR mode is specified.For more information, see the Remarks section.If the
		/// storage object is opened in direct mode with access to STGM_READ, the sharing mode must be either STGM_SHARE_EXCLUSIVE or
		/// STGM_SHARE_DENY_WRITE, unless STGM_PRIORITY or STGM_DIRECT_SWMR is specified.For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// The mode in which a file is opened can affect implementation performance.For more information, see Compound File Implementation Limits.
		/// </para>
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// A value that depends upon the value of the stgfmt parameter. STGFMT_DOCFILE must be zero (0) or FILE_FLAG_NO_BUFFERING. For more
		/// information about this value, see CreateFile. If the sector size of the file, specified in pStgOptions, is not an integer
		/// multiple of the physical sector size of the underlying disk, then this operation will fail. All other values of stgfmt must be zero.
		/// </param>
		/// <param name="pStgOptions">
		/// A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only
		/// if the stgfmt parameter is set to STGFMT_DOCFILE. The usVersion member must be set before calling StgOpenStorageEx. For more
		/// information, see the STGOPTIONS structure.
		/// </param>
		/// <param name="reserved2">Reserved; must be zero.</param>
		/// <param name="riid">
		/// A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for IID_IStorage to
		/// obtain the IStorage interface or for IID_IPropertySetStorage to obtain the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains NULL
		/// if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380342")]
		public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt,
			FileFlagsAndAttributes grfAttrs, ref STGOPTIONS pStgOptions, [Optional] IntPtr reserved2, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>STGs the open storage ex.</summary>
		/// <param name="pwcsName">
		/// A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed
		/// MAX_PATH characters.
		/// <para>
		/// Windows Server 2003 and Windows XP/2000: Unlike the CreateFile function, the MAX_PATH limit cannot be exceeded by using the
		/// "\\?\" prefix.
		/// </para>
		/// </param>
		/// <param name="grfMode">
		/// A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller
		/// specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion occurs when the commit operation
		/// is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will
		/// be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required
		/// when a file is overwritten or converted in transacted mode.
		/// <para>
		/// If the storage object is opened in direct mode(STGM_DIRECT) with access to either STGM_WRITE or STGM_READWRITE, the sharing mode
		/// must be STGM_SHARE_EXCLUSIVE unless the STGM_DIRECT_SWMR mode is specified.For more information, see the Remarks section.If the
		/// storage object is opened in direct mode with access to STGM_READ, the sharing mode must be either STGM_SHARE_EXCLUSIVE or
		/// STGM_SHARE_DENY_WRITE, unless STGM_PRIORITY or STGM_DIRECT_SWMR is specified.For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// The mode in which a file is opened can affect implementation performance.For more information, see Compound File Implementation Limits.
		/// </para>
		/// </param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">
		/// A value that depends upon the value of the stgfmt parameter. STGFMT_DOCFILE must be zero (0) or FILE_FLAG_NO_BUFFERING. For more
		/// information about this value, see CreateFile. If the sector size of the file, specified in pStgOptions, is not an integer
		/// multiple of the physical sector size of the underlying disk, then this operation will fail. All other values of stgfmt must be zero.
		/// </param>
		/// <param name="pStgOptions">
		/// A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only
		/// if the stgfmt parameter is set to STGFMT_DOCFILE. The usVersion member must be set before calling StgOpenStorageEx. For more
		/// information, see the STGOPTIONS structure.
		/// </param>
		/// <param name="reserved2">Reserved; must be zero.</param>
		/// <param name="riid">
		/// A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for IID_IStorage to
		/// obtain the IStorage interface or for IID_IPropertySetStorage to obtain the IPropertySetStorage interface.
		/// </param>
		/// <param name="ppObjectOpen">
		/// The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains NULL
		/// if operation failed.
		/// </param>
		/// <returns>
		/// This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error
		/// Handling Strategies and Handling Unknown Errors.
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380342")]
		public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt,
			FileFlagsAndAttributes grfAttrs, [Optional] IntPtr pStgOptions, [Optional] IntPtr reserved2, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// The STGOPTIONS structure specifies features of the storage object, such as sector size, in the StgCreateStorageEx and
		/// StgOpenStorageEx functions.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380344")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STGOPTIONS
		{
			/// <summary>
			/// Specifies the version of the STGOPTIONS structure. It is set to STGOPTIONS_VERSION. <note>When usVersion is set to 1, the
			/// ulSectorSize member can be set.This is useful when creating a large-sector documentation file.However, when usVersion is set
			/// to 1, the pwcsTemplateFile member cannot be used.</note>
			/// <para>In Windows 2000 and later: STGOPTIONS_VERSION can be set to 1 for version 1.</para>
			/// <para>In Windows XP and later: STGOPTIONS_VERSION can be set to 2 for version 2.</para>
			/// <para>For operating systems prior to Windows 2000: STGOPTIONS_VERSION will be set to 0 for version 0.</para>
			/// </summary>
			public ushort usVersion;

			/// <summary>Reserved for future use; must be zero.</summary>
			public ushort reserved;

			/// <summary>Specifies the sector size of the storage object. The default is 512 bytes.</summary>
			public uint ulSectorSize;

			/// <summary>
			/// Specifies the name of a file whose Encrypted File System (EFS) metadata will be transferred to a newly created Structured
			/// Storage file. This member is valid only when STGFMT_DOCFILE is used with StgCreateStorageEx.
			/// <para>
			/// In Windows XP and later: The pwcsTemplateFile member is only valid if version 2 or later is specified in the usVersion member.
			/// </para>
			/// </summary>
			public string pwcsTemplateFile;
		}
	}
}