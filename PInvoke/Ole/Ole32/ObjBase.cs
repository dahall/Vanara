using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Rpc;
using BIND_OPTS = System.Runtime.InteropServices.ComTypes.BIND_OPTS;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Specifies different types of apartments.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ne-objidl-_apttype typedef enum _APTTYPE { APTTYPE_CURRENT,
	// APTTYPE_STA, APTTYPE_MTA, APTTYPE_NA, APTTYPE_MAINSTA } APTTYPE;
	[PInvokeData("objidl.h", MSDNShortId = "eae95b1f-3883-4334-aa7e-84e71e05fb24")]
	public enum APTTYPE
	{
		/// <summary>The current thread.</summary>
		APTTYPE_CURRENT = -1,

		/// <summary>A single-threaded apartment.</summary>
		APTTYPE_STA = 0,

		/// <summary>A multi-threaded apartment.</summary>
		APTTYPE_MTA = 1,

		/// <summary>A neutral apartment.</summary>
		APTTYPE_NA = 2,

		/// <summary>The main single-threaded apartment.</summary>
		APTTYPE_MAINSTA = 3,
	}

	/// <summary>Specifies the set of possible COM apartment type qualifiers.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidlbase/ne-objidlbase-apttypequalifier typedef enum _APTTYPEQUALIFIER {
	// APTTYPEQUALIFIER_NONE, APTTYPEQUALIFIER_IMPLICIT_MTA, APTTYPEQUALIFIER_NA_ON_MTA, APTTYPEQUALIFIER_NA_ON_STA,
	// APTTYPEQUALIFIER_NA_ON_IMPLICIT_MTA, APTTYPEQUALIFIER_NA_ON_MAINSTA, APTTYPEQUALIFIER_APPLICATION_STA,
	// APTTYPEQUALIFIER_RESERVED_1 } APTTYPEQUALIFIER;
	[PInvokeData("objidlbase.h", MSDNShortId = "ac28076d-d266-4939-b6c1-d56494ffbcd8")]
	public enum APTTYPEQUALIFIER
	{
		/// <summary>No qualifier information for the current COM apartment type is available.</summary>
		APTTYPEQUALIFIER_NONE = 0,

		/// <summary>
		/// This qualifier is only valid when the pAptType parameter of the CoGetApartmentType function specifies APTTYPE_MTA on return.
		/// A thread has an implicit MTA apartment type if it does not initialize the COM apartment itself, and if another thread has
		/// already initialized the MTA in the process. This qualifier informs the API caller that the MTA of the thread is implicitly
		/// inherited from other threads and is not initialized directly.
		/// </summary>
		APTTYPEQUALIFIER_IMPLICIT_MTA,

		/// <summary>
		/// This qualifier is only valid when the pAptType parameter of the CoGetApartmentType function contains APTTYPE_NA on return.
		/// When an MTA thread creates or invokes a COM in-process object using the "Neutral" threading model, the COM apartment type of
		/// the thread switches from MTA to a Neutral apartment type. This qualifier informs the API caller that the thread has switched
		/// from the MTA apartment type to the NA type.
		/// </summary>
		APTTYPEQUALIFIER_NA_ON_MTA,

		/// <summary>
		/// This qualifier is only valid when the pAptType parameter of the CoGetApartmentType function contains APTTYPE_NA on return.
		/// When an STA thread creates or invokes a COM in-process object using the "Neutral" threading model, the COM apartment type of
		/// the thread switches from STA to a Neutral apartment type. This qualifier informs the API caller that the thread has switched
		/// from the STA apartment type to the NA type.
		/// </summary>
		APTTYPEQUALIFIER_NA_ON_STA,

		/// <summary>
		/// This qualifier is only valid when the pAptType parameter of the CoGetApartmentType function contains APTTYPE_NA on return.
		/// When an implicit MTA thread creates or invokes a COM in-process object using the "Neutral" threading model, the COM
		/// apartment type of the thread switches from the implicit MTA type to a Neutral apartment type. This qualifier informs the API
		/// caller that the thread has switched from the implicit MTA apartment type to the NA type.
		/// </summary>
		APTTYPEQUALIFIER_NA_ON_IMPLICIT_MTA,

		/// <summary>
		/// This qualifier is only valid when the pAptType parameter of the CoGetApartmentType function contains APTTYPE_NA on return.
		/// When the main STA thread creates or invokes a COM in-process object using the "Neutral" threading model, the COM apartment
		/// type of the thread switches from the main STA type to a Neutral apartment type. This qualifier informs the API caller that
		/// the thread has switched from the main STA apartment type to the NA type.
		/// </summary>
		APTTYPEQUALIFIER_NA_ON_MAINSTA,

		/// <summary/>
		APTTYPEQUALIFIER_APPLICATION_STA,

		/// <summary/>
		APTTYPEQUALIFIER_RESERVED_1,
	}

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
	/// To indicate that more than one context is acceptable, you can combine multiple values with Boolean ORs. The contexts are tried
	/// in the order in which they are listed.
	/// </para>
	/// <para>
	/// Given a set of <c>CLSCTX</c> flags, the execution context to be used depends on the availability of registered class codes and
	/// other parameters according to the following algorithm.
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If the call specifies one of the following, CLSCTX_REMOTE_SERVER is implied and is added to the list of flags: The second case
	/// allows applications written prior to the release of distributed COM to be the configuration of classes for remote activation to
	/// be used by client applications available prior to DCOM and the CLSCTX_REMOTE_SERVER flag. The cases in which there would be no
	/// explicit COSERVERINFO structure are when the value is specified as <c>NULL</c> or when it is not one of the function parameters
	/// (as in calls to CoCreateInstance and CoGetClassObject).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the explicit COSERVERINFO parameter indicates the current computer, CLSCTX_REMOTE_SERVER is removed if present.</term>
	/// </item>
	/// </list>
	/// <para>The rest of the processing proceeds by looking at the value(s) in the following sequence:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If the flags include CLSCTX_REMOTE_SERVER and no COSERVERINFO parameter is specified and if the activation request indicates a
	/// persistent state from which to initialize the object (with CoGetInstanceFromFile, CoGetInstanceFromIStorage, or, for a file
	/// moniker, in a call to IMoniker::BindToObject) and the class has an ActivateAtStorage subkey or no class registry information
	/// whatsoever, the request to activate and initialize is forwarded to the computer where the persistent state resides. (Refer to
	/// the remote activation functions listed in the See Also section for details.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the flags include CLSCTX_INPROC_SERVER, the class code in the DLL found under the class's InprocServer32 key is used if this
	/// key exists. The class code will run within the same process as the caller.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the flags include CLSCTX_INPROC_HANDLER, the class code in the DLL found under the class's InprocHandler32 key is used if
	/// this key exists. The class code will run within the same process as the caller.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the flags include CLSCTX_LOCAL_SERVER, the class code in the service found under the class's LocalService key is used if this
	/// key exists. If no service is specified but an EXE is specified under that same key, the class code associated with that EXE is
	/// used. The class code (in either case) will be run in a separate service process on the same computer as the caller.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the flag is set to CLSCTX_REMOTE_SERVER and an additional COSERVERINFO parameter to the function specifies a particular
	/// remote computer, a request to activate is forwarded to this remote computer with flags modified to set to CLSCTX_LOCAL_SERVER.
	/// The class code will run in its own process on this specific computer, which must be different from that of the caller.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Finally, if the flags include CLSCTX_REMOTE_SERVER and no COSERVERINFO parameter is specified and if a computer name is given
	/// under the class's RemoteServerName named-value, the request to activate is forwarded to this remote computer with the flags
	/// modified to be set to CLSCTX_LOCAL_SERVER. The class code will run in its own process on this specific computer, which must be
	/// different from that of the caller.
	/// </term>
	/// </item>
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
	/// is available, then the client must specify the 32-bit version of server "A". If only a 64-bit version of server "B" is
	/// available, then the client must specify the 64-bit version of server "A".
	/// </para>
	/// <para>
	/// A server can specify its own architecture preference via the PreferredServerBitness registry key, but the client's preference,
	/// specified via a CLSCTX_ACTIVATE_32_BIT_SERVER or CLSCTX_ACTIVATE_64_BIT_SERVER flag, will override the server's preference. If
	/// the client does not specify a preference, then the server's preference will be used.
	/// </para>
	/// <para>If neither the client nor the server specifies a preference, then:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the computer that hosts the server is running Windows Server 2003 with Service Pack 1 (SP1) or a later system, then COM will
	/// try to match the server architecture to the client architecture. In other words, for a 32-bit client, COM will activate a 32-bit
	/// server if available; otherwise it will activate a 64-bit version of the server. For a 64-bit client, COM will activate a 64-bit
	/// server if available; otherwise it will activate a 32-bit server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the computer that hosts the server is running Windows XP or Windows Server 2003 without SP1 or later installed, then COM will
	/// prefer a 64-bit version of the server if available; otherwise it will activate a 32-bit version of the server.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a <c>CLSCTX</c> enumeration has both the CLSCTX_ACTIVATE_32_BIT_SERVER and CLSCTX_ACTIVATE_64_BIT_SERVER flags set, then it
	/// is invalid and the activation will return E_INVALIDARG.
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
	/// <listheader>
	/// <term/>
	/// <term>32-bit client, no flag</term>
	/// <term>64-bit client, no flag</term>
	/// <term>32-bit client, 32-bit flag¹</term>
	/// <term>32-bit client, 64-bit flag²</term>
	/// <term>64-bit client, 32-bit flag¹</term>
	/// <term>64-bit client, 64-bit flag²</term>
	/// </listheader>
	/// <item>
	/// <term>32-bit server, match client registry value³</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// </item>
	/// <item>
	/// <term>32-bit server, 32-bit registry value⁴</term>
	/// <term>32-bit server</term>
	/// <term>32-bit server</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// </item>
	/// <item>
	/// <term>32-bit server, 64-bit registry value⁵</term>
	/// <term>See ⁸</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// </item>
	/// <item>
	/// <term>32-bit server, no registry value⁶</term>
	/// <term>32-bit server</term>
	/// <term>64/32⁹</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// </item>
	/// <item>
	/// <term>32-bit server, no registry value (before Windows Server 2003 with SP1)⁷</term>
	/// <term>64/32⁹</term>
	/// <term>64/32⁹</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// <term>32-bit server</term>
	/// <term>See ⁸</term>
	/// </item>
	/// <item>
	/// <term>64-bit server, match client registry value³</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// </item>
	/// <item>
	/// <term>64-bit server, 32-bit registry value⁴</term>
	/// <term>See ⁸</term>
	/// <term>See ⁸</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// </item>
	/// <item>
	/// <term>64-bit server, 64-bit registry value⁵</term>
	/// <term>64-bit server</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// </item>
	/// <item>
	/// <term>64-bit server, no registry value⁶</term>
	/// <term>32/64¹⁰</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// </item>
	/// <item>
	/// <term>64-bit server, no registry value (before Windows Server 2003 with SP1)⁷</term>
	/// <term>64-bit server</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// <term>See ⁸</term>
	/// <term>64-bit server</term>
	/// </item>
	/// </list>
	/// <para><c>PreferredServerBitness</c> PreferredServerBitness <c>PreferredServerBitness</c><c>PreferredServerBitness</c><c>PreferredServerBitness</c><c>PreferredServerBitness</c></para>
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
		/// A remote context. The LocalServer32 or LocalService code that creates and manages objects of this class is run on a
		/// different computer.
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
		/// because the EOAC_DISABLE_AAA flag from the EOLE_AUTHENTICATION_CAPABILITIES enumeration is applied only to the server
		/// process and not to the library application. Windows 2000: This flag is not supported.
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
		CLSCTX_PS_DLL = 0x80000000,

		/// <summary>Combination of CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER.</summary>
		CLSCTX_INPROC = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER,

		/// <summary>Combination of CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER.</summary>
		CLSCTX_SERVER = CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,

		/// <summary>Combination of CLSCTX_SERVER | CLSCTX_INPROC_HANDLER.</summary>
		CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER,
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

	/// <summary>Determines the type of COM security descriptor to get when calling CoGetSystemSecurityPermissions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/ne-objbase-comsd typedef enum tagCOMSD { SD_LAUNCHPERMISSIONS,
	// SD_ACCESSPERMISSIONS, SD_LAUNCHRESTRICTIONS, SD_ACCESSRESTRICTIONS } COMSD;
	[PInvokeData("objbase.h", MSDNShortId = "FF783F27-D5EF-4927-9B7D-489271FBA9B3")]
	public enum COMSD
	{
		/// <summary>Machine-wide launch permissions.</summary>
		SD_LAUNCHPERMISSIONS,

		/// <summary>Machine-wide access permissions.</summary>
		SD_ACCESSPERMISSIONS,

		/// <summary>Machine-wide launch limits.</summary>
		SD_LAUNCHRESTRICTIONS,

		/// <summary>Machine-wide access limits.</summary>
		SD_ACCESSRESTRICTIONS,
	}

	/// <summary>
	/// The STGFMT enumeration values specify the format of a storage object and are used in the StgCreateStorageEx and StgOpenStorageEx
	/// functions in the stgfmt parameter. This value, in combination with the value in the riid parameter, is used to determine the
	/// file format and the interface implementation to use.
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
		/// these functions return an error if the riid parameter does not specify the IPropertySetStorage interface, or if the
		/// specified file is not located on an NTFS file system volume.
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
	/// Locates an object by means of its moniker, activates the object if it is inactive, and retrieves a pointer to the specified
	/// interface on that object.
	/// </summary>
	/// <param name="pmk">A pointer to the object's moniker. See IMoniker.</param>
	/// <param name="grfOpt">This parameter is reserved for future use and must be 0.</param>
	/// <param name="iidResult">The interface identifier to be used to communicate with the object.</param>
	/// <param name="ppvResult">
	/// The address of pointer variable that receives the interface pointer requested in iidResult. Upon successful return, *ppvResult
	/// contains the requested interface pointer. If an error occurs, *ppvResult is <c>NULL</c>. If the call is successful, the caller
	/// is responsible for releasing the pointer with a call to the object's IUnknown::Release method.
	/// </param>
	/// <returns>
	/// <para>
	/// This function can return the following error codes, or any of the error values returned by the IMoniker::BindToObject method.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was located and activated, if necessary, and a pointer to the requested interface was returned.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOOBJECT</term>
	/// <term>The object that the moniker object identified could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>BindMoniker</c> is a helper function supplied as a convenient way for a client that has the moniker of an object to obtain a
	/// pointer to one of that object's interfaces. <c>BindMoniker</c> packages the following calls:
	/// </para>
	/// <para>
	/// CreateBindCtx creates a bind context object that supports the system implementation of IBindContext. The pmk parameter is
	/// actually a pointer to the IMoniker implementation on a moniker object. This implementation's BindToObject method supplies the
	/// pointer to the requested interface pointer.
	/// </para>
	/// <para>
	/// If you have several monikers to bind in quick succession and if you know that those monikers will activate the same object, it
	/// may be more efficient to call the IMoniker::BindToObject method directly, which enables you to use the same bind context object
	/// for all the monikers. See the IBindCtx interface for more information.
	/// </para>
	/// <para>
	/// Container applications that allow their documents to contain linked objects are a special client that generally does not make
	/// direct calls to IMoniker methods. Instead, the client manipulates the linked objects through the IOleLink interface. The default
	/// handler implements this interface and calls the appropriate <c>IMoniker</c> methods as needed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-bindmoniker HRESULT BindMoniker( LPMONIKER pmk, DWORD
	// grfOpt, REFIID iidResult, LPVOID *ppvResult );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "5a022c39-fc2c-458b-9dfe-fed1255d49a4")]
	public static extern HRESULT BindMoniker(IMoniker pmk, [Optional] uint grfOpt, in Guid iidResult, [MarshalAs(UnmanagedType.IUnknown)] out object ppvResult);

	/// <summary>
	/// This function passes the foreground privilege (the privilege to set the foreground window) from one process to another. The
	/// process that has the foreground privilege can call this function to pass that privilege on to a local COM server process. Note
	/// that calling <c>CoAllowSetForegroundWindow</c> only confers the privilege; it does not set the foreground window itself.
	/// Foreground and focus are only taken away from the client application when the target COM server calls either SetForegroundWindow
	/// or another API that does so indirectly.
	/// </summary>
	/// <param name="pUnk">A pointer to the IUnknown interface on the proxy of the target COM server.</param>
	/// <param name="lpvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>This function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The method was successful.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The lpvReserved parameter is not NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The pUnk parameter does not support foreground window control.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The calling process does not currently possess the foreground privilege.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The system restricts which processes can call the SetForegroundWindow and AllowSetForegroundWindow functions to set the
	/// foreground window. As a result, an application is blocked from stealing the focus from another application even when the user is
	/// interacting with it. Use <c>CoAllowSetForegroundWindow</c> to pass on the foreground privilege from a process that has it to a
	/// process that does not yet have it. This can be done transitively: passing the privilege from one process to another, and then to
	/// another, and so on.
	/// </para>
	/// <para>
	/// <c>CoAllowSetForegroundWindow</c> enables a user that has a custom interface to get the same behavior that happens for OLE
	/// interfaces where a change of window is expected (primarily associated with linking and embedding).
	/// </para>
	/// <para>
	/// Behind the scenes, the IForegroundTransfer interface is used to yield the foreground window between processes. A standard
	/// COM-provided proxy already implements <c>IForegroundTransfer</c>, so you don't have to do any extra work if you're using a
	/// standard proxy. Just call <c>CoAllowSetForegroundWindow</c> to transfer the foreground privilege to any out-of-process COM object.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example demonstrates how a client process can create a local COM server, call <c>CoAllowSetForegroundWindow</c> to
	/// transfer the foreground privilege, and then call a function on the COM server that in turn directly or indirectly calls SetForegroundWindow.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coallowsetforegroundwindow HRESULT
	// CoAllowSetForegroundWindow( IUnknown *pUnk, LPVOID lpvReserved );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "a728aaad-3d7a-425c-b886-ba35c4fa54d0")]
	public static extern HRESULT CoAllowSetForegroundWindow([MarshalAs(UnmanagedType.IUnknown)] object pUnk, IntPtr lpvReserved = default);

	/// <summary>
	/// <para>Converts the MS-DOS representation of the time and date to a FILETIME structure used by Windows.</para>
	/// <para><c>Note</c> This function is provided for compatibility with 16-bit Windows.</para>
	/// </summary>
	/// <param name="nDosDate">The MS-DOS date.</param>
	/// <param name="nDosTime">The MS-DOS time.</param>
	/// <param name="lpFileTime">A pointer to the FILETIME structure.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>, probably because of invalid arguments.
	/// </returns>
	/// <remarks>
	/// <para>An MS-DOS date has the following format.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0-4</term>
	/// <term>Days of the month (1-31).</term>
	/// </item>
	/// <item>
	/// <term>5-8</term>
	/// <term>Months (1 = January, 2 = February, and so forth).</term>
	/// </item>
	/// <item>
	/// <term>9-15</term>
	/// <term>Year offset from 1980 (add 1980 to get actual year).</term>
	/// </item>
	/// </list>
	/// <para>An MS-DOS time has the following format.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>0-4</term>
	/// <term>Seconds divided by 2.</term>
	/// </item>
	/// <item>
	/// <term>5-10</term>
	/// <term>Minutes (0-59).</term>
	/// </item>
	/// <item>
	/// <term>11-15</term>
	/// <term>Hours (0-23 on a 24-hour clock).</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-codosdatetimetofiletime BOOL CoDosDateTimeToFileTime( WORD
	// nDosDate, WORD nDosTime, FILETIME *lpFileTime );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "eb7af6a3-7547-405e-b96e-3e68a1ac273b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CoDosDateTimeToFileTime(ushort nDosDate, ushort nDosTime, out FILETIME lpFileTime);

	/// <summary>
	/// <para>Converts a FILETIME into MS-DOS date and time values.</para>
	/// <para><c>Note</c> This function is provided for compatibility with 16-bit Windows.</para>
	/// </summary>
	/// <param name="lpFileTime">A pointer to the FILETIME structure.</param>
	/// <param name="lpDosDate">Receives the MS-DOS date.</param>
	/// <param name="lpDosTime">Receives the MS-DOS time.</param>
	/// <returns>If the function succeeds, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cofiletimetodosdatetime BOOL CoFileTimeToDosDateTime(
	// FILETIME *lpFileTime, LPWORD lpDosDate, LPWORD lpDosTime );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "38670fe7-10cf-44e2-a5f1-60ec43fd83b5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CoFileTimeToDosDateTime(in FILETIME lpFileTime, out ushort lpDosDate, out ushort lpDosTime);

	/// <summary>
	/// Frees all the DLLs that have been loaded with the CoLoadLibrary function (called internally by CoGetClassObject), regardless of
	/// whether they are currently in use.
	/// </summary>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// To unload libraries, <c>CoFreeAllLibraries</c> uses a list of loaded DLLs for each process that the COM library maintains. The
	/// CoUninitialize and OleUninitialize functions call <c>CoFreeAllLibraries</c> internally, so applications usually have no need to
	/// call this function directly.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cofreealllibraries void CoFreeAllLibraries( );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "20616c05-21c6-4895-a1b5-4bae1aa417c7")]
	public static extern void CoFreeAllLibraries();

	/// <summary>
	/// <para>Frees a library that, when loaded, was specified to be freed explicitly.</para>
	/// <para><c>Note</c> This function is provided for compatibility with 16-bit Windows.</para>
	/// </summary>
	/// <param name="hInst">A handle to the library module to be freed, as returned by the CoLoadLibrary function.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// The <c>CoFreeLibrary</c> function should be called to free a library that is to be freed explicitly. This is established when
	/// the library is loaded with the bAutoFree parameter of CoLoadLibrary set to <c>FALSE</c>. It is illegal to free a library
	/// explicitly when the corresponding <c>CoLoadLibrary</c> call specifies that it be freed automatically (the bAutoFree parameter is
	/// set to <c>TRUE</c>).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cofreelibrary void CoFreeLibrary( HINSTANCE hInst );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "3959e7d9-6220-474e-8f85-76f7f935727f")]
	public static extern void CoFreeLibrary(HINSTANCE hInst);

	/// <summary>Creates a new object and initializes it from a file using IPersistFile::Load.</summary>
	/// <param name="pServerInfo">
	/// A pointer to a COSERVERINFO structure that specifies the computer on which to instantiate the object and the authentication
	/// setting to be used. This parameter can be <c>NULL</c>, in which case the object is instantiated on the current computer, at the
	/// computer specified under the RemoteServerName registry value for the class, or at the computer where the pwszName file resides
	/// if the ActivateAtStorage value is specified for the class or there is no local registry information.
	/// </param>
	/// <param name="pClsid">
	/// A pointer to the class identifier of the object to be created. This parameter can be <c>NULL</c>, in which case there is a call
	/// to GetClassFile, using pwszName as its parameter to get the class of the object to be instantiated.
	/// </param>
	/// <param name="punkOuter">
	/// When non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used as the
	/// pointer to the new instance's controlling IUnknown. Aggregation is not supported cross-process or cross-computer. When
	/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
	/// </param>
	/// <param name="dwClsCtx">Values from the CLSCTX enumeration.</param>
	/// <param name="grfMode">Specifies how the file is to be opened. See STGM Constants.</param>
	/// <param name="pwszName">The file used to initialize the object with IPersistFile::Load. This parameter cannot be <c>NULL</c>.</param>
	/// <param name="dwCount">The number of structures in pResults. This parameter must be greater than 0.</param>
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
	/// <term>The function retrieved all of the interfaces successfully.</term>
	/// </item>
	/// <item>
	/// <term>CO_S_NOTALLINTERFACES</term>
	/// <term>
	/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each
	/// of the MULTI_QI structures indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
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
	/// <c>CoGetInstanceFromFile</c> creates a new object and initializes it from a file using IPersistFile::Load. The result of this
	/// function is similar to creating an instance with a call to CoCreateInstanceEx, followed by an initializing call to
	/// <c>IPersistFile::Load</c>, with the following important distinctions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Fewer network round trips are required by this function when instantiating an object on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>
	/// In the case where dwClsCtx is set to CLSCTX_REMOTE_SERVER and pServerInfo is <c>NULL</c>, if the class is registered with the
	/// ActivateAtStorage sub-key or has no associated registry information, this function will instantiate an object on the computer
	/// where pwszName resides, providing the least possible network traffic.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromfile HRESULT CoGetInstanceFromFile(
	// COSERVERINFO *pServerInfo, CLSID *pClsid, IUnknown *punkOuter, DWORD dwClsCtx, DWORD grfMode, OLECHAR *pwszName, DWORD dwCount,
	// MULTI_QI *pResults );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "f8a22f5f-a21f-49e7-bd6c-ca987206ee46")]
	public static extern HRESULT CoGetInstanceFromFile([Optional] COSERVERINFO pServerInfo, in Guid pClsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object punkOuter, CLSCTX dwClsCtx, STGM grfMode, [MarshalAs(UnmanagedType.LPWStr)] string pwszName, uint dwCount, [In, Out] MULTI_QI[] pResults);

	/// <summary>Creates a new object and initializes it from a file using IPersistFile::Load.</summary>
	/// <param name="pServerInfo">
	/// A pointer to a COSERVERINFO structure that specifies the computer on which to instantiate the object and the authentication
	/// setting to be used. This parameter can be <c>NULL</c>, in which case the object is instantiated on the current computer, at the
	/// computer specified under the RemoteServerName registry value for the class, or at the computer where the pwszName file resides
	/// if the ActivateAtStorage value is specified for the class or there is no local registry information.
	/// </param>
	/// <param name="pClsid">
	/// A pointer to the class identifier of the object to be created. This parameter can be <c>NULL</c>, in which case there is a call
	/// to GetClassFile, using pwszName as its parameter to get the class of the object to be instantiated.
	/// </param>
	/// <param name="punkOuter">
	/// When non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used as the
	/// pointer to the new instance's controlling IUnknown. Aggregation is not supported cross-process or cross-computer. When
	/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
	/// </param>
	/// <param name="dwClsCtx">Values from the CLSCTX enumeration.</param>
	/// <param name="grfMode">Specifies how the file is to be opened. See STGM Constants.</param>
	/// <param name="pwszName">The file used to initialize the object with IPersistFile::Load. This parameter cannot be <c>NULL</c>.</param>
	/// <param name="dwCount">The number of structures in pResults. This parameter must be greater than 0.</param>
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
	/// <term>The function retrieved all of the interfaces successfully.</term>
	/// </item>
	/// <item>
	/// <term>CO_S_NOTALLINTERFACES</term>
	/// <term>
	/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each
	/// of the MULTI_QI structures indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
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
	/// <c>CoGetInstanceFromFile</c> creates a new object and initializes it from a file using IPersistFile::Load. The result of this
	/// function is similar to creating an instance with a call to CoCreateInstanceEx, followed by an initializing call to
	/// <c>IPersistFile::Load</c>, with the following important distinctions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Fewer network round trips are required by this function when instantiating an object on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>
	/// In the case where dwClsCtx is set to CLSCTX_REMOTE_SERVER and pServerInfo is <c>NULL</c>, if the class is registered with the
	/// ActivateAtStorage sub-key or has no associated registry information, this function will instantiate an object on the computer
	/// where pwszName resides, providing the least possible network traffic.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromfile HRESULT CoGetInstanceFromFile(
	// COSERVERINFO *pServerInfo, CLSID *pClsid, IUnknown *punkOuter, DWORD dwClsCtx, DWORD grfMode, OLECHAR *pwszName, DWORD dwCount,
	// MULTI_QI *pResults );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "f8a22f5f-a21f-49e7-bd6c-ca987206ee46")]
	public static extern HRESULT CoGetInstanceFromFile([Optional] COSERVERINFO pServerInfo, [Optional] IntPtr pClsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object punkOuter, CLSCTX dwClsCtx, STGM grfMode, [MarshalAs(UnmanagedType.LPWStr)] string pwszName, uint dwCount, [In, Out] MULTI_QI[] pResults);

	/// <summary>Creates a new object and initializes it from a storage object through an internal call to IPersistFile::Load.</summary>
	/// <param name="pServerInfo">
	/// A pointer to a COSERVERINFO structure that specifies the computer on which to instantiate the object and the authentication
	/// setting to be used. This parameter can be <c>NULL</c>, in which case the object is instantiated on the current computer, at the
	/// computer specified under the RemoteServerName registry value for the class, or at the computer where the pstg storage object
	/// resides if the ActivateAtStorage value is specified for the class or there is no local registry information.
	/// </param>
	/// <param name="pClsid">
	/// A pointer to the class identifier of the object to be created. This parameter can be <c>NULL</c>, in which case there is a call
	/// to IStorage::Stat to find the class of the object.
	/// </param>
	/// <param name="punkOuter">
	/// When non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used as the
	/// pointer to the new instance's controlling IUnknown. Aggregation is not supported cross-process or cross-computer. When
	/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
	/// </param>
	/// <param name="dwClsCtx">Values from the CLSCTX enumeration.</param>
	/// <param name="pstg">
	/// A pointer to the storage object used to initialize the object with IPersistFile::Load. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="dwCount">The number of structures in pResults. This parameter must be greater than 0.</param>
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
	/// <term>The function retrieved all of the interfaces successfully.</term>
	/// </item>
	/// <item>
	/// <term>CO_S_NOTALLINTERFACES</term>
	/// <term>
	/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each
	/// of the MULTI_QI structures indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
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
	/// <c>CoGetInstanceFromIStorage</c> creates a new object and initializes it from a storage object using IPersistFile::Load. The
	/// result of this function is similar to creating an instance with a call to CoCreateInstanceEx, followed by an initializing call
	/// to <c>IPersistFile::Load</c>, with the following important distinctions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Fewer network round trips are required by this function when instantiating an object on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>
	/// In the case where dwClsCtx is set to CLSCTX_REMOTE_SERVER and pServerInfo is <c>NULL</c>, if the class is registered with the
	/// ActivateAtStorage value or has no associated registry information, this function will instantiate an object on the computer
	/// where pstg resides, providing the least possible network traffic.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromistorage HRESULT
	// CoGetInstanceFromIStorage( COSERVERINFO *pServerInfo, CLSID *pClsid, IUnknown *punkOuter, DWORD dwClsCtx, IStorage *pstg, DWORD
	// dwCount, MULTI_QI *pResults );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "6a77770c-b7e1-4d29-9c4b-331b5950a635")]
	public static extern HRESULT CoGetInstanceFromIStorage([Optional] COSERVERINFO pServerInfo, in Guid pClsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object punkOuter, CLSCTX dwClsCtx, IStorage pstg, uint dwCount, [In, Out] MULTI_QI[] pResults);

	/// <summary>Creates a new object and initializes it from a storage object through an internal call to IPersistFile::Load.</summary>
	/// <param name="pServerInfo">
	/// A pointer to a COSERVERINFO structure that specifies the computer on which to instantiate the object and the authentication
	/// setting to be used. This parameter can be <c>NULL</c>, in which case the object is instantiated on the current computer, at the
	/// computer specified under the RemoteServerName registry value for the class, or at the computer where the pstg storage object
	/// resides if the ActivateAtStorage value is specified for the class or there is no local registry information.
	/// </param>
	/// <param name="pClsid">
	/// A pointer to the class identifier of the object to be created. This parameter can be <c>NULL</c>, in which case there is a call
	/// to IStorage::Stat to find the class of the object.
	/// </param>
	/// <param name="punkOuter">
	/// When non- <c>NULL</c>, indicates the instance is being created as part of an aggregate, and punkOuter is to be used as the
	/// pointer to the new instance's controlling IUnknown. Aggregation is not supported cross-process or cross-computer. When
	/// instantiating an object out of process, CLASS_E_NOAGGREGATION will be returned if punkOuter is non- <c>NULL</c>.
	/// </param>
	/// <param name="dwClsCtx">Values from the CLSCTX enumeration.</param>
	/// <param name="pstg">
	/// A pointer to the storage object used to initialize the object with IPersistFile::Load. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="dwCount">The number of structures in pResults. This parameter must be greater than 0.</param>
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
	/// <term>The function retrieved all of the interfaces successfully.</term>
	/// </item>
	/// <item>
	/// <term>CO_S_NOTALLINTERFACES</term>
	/// <term>
	/// At least one, but not all of the interfaces requested in the pResults array were successfully retrieved. The hr member of each
	/// of the MULTI_QI structures indicates with S_OK or E_NOINTERFACE whether the specific interface was returned.
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
	/// <c>CoGetInstanceFromIStorage</c> creates a new object and initializes it from a storage object using IPersistFile::Load. The
	/// result of this function is similar to creating an instance with a call to CoCreateInstanceEx, followed by an initializing call
	/// to <c>IPersistFile::Load</c>, with the following important distinctions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Fewer network round trips are required by this function when instantiating an object on a remote computer.</term>
	/// </item>
	/// <item>
	/// <term>
	/// In the case where dwClsCtx is set to CLSCTX_REMOTE_SERVER and pServerInfo is <c>NULL</c>, if the class is registered with the
	/// ActivateAtStorage value or has no associated registry information, this function will instantiate an object on the computer
	/// where pstg resides, providing the least possible network traffic.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetinstancefromistorage HRESULT
	// CoGetInstanceFromIStorage( COSERVERINFO *pServerInfo, CLSID *pClsid, IUnknown *punkOuter, DWORD dwClsCtx, IStorage *pstg, DWORD
	// dwCount, MULTI_QI *pResults );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "6a77770c-b7e1-4d29-9c4b-331b5950a635")]
	public static extern HRESULT CoGetInstanceFromIStorage([Optional] COSERVERINFO pServerInfo, [Optional] IntPtr pClsid, [MarshalAs(UnmanagedType.IUnknown), Optional] object punkOuter, CLSCTX dwClsCtx, IStorage pstg, uint dwCount, [In, Out] MULTI_QI[] pResults);

	/// <summary>
	/// Converts a display name into a moniker that identifies the object named, and then binds to the object identified by the moniker.
	/// </summary>
	/// <param name="pszName">The display name of the object to be created.</param>
	/// <param name="pBindOptions">
	/// The binding options used to create a moniker that creates the actual object. For details, see BIND_OPTS. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="riid">A reference to the identifier of an interface that is implemented on the object to be created.</param>
	/// <param name="ppv">The address of a pointer to the interface specified by riid on the object that is created.</param>
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
	/// <term>The object was created successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_SYNTAX</term>
	/// <term>The pszName parameter is not a properly formed display name.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOOBJECT</term>
	/// <term>
	/// The object identified by this moniker, or some object identified by the composite moniker of which this moniker is a part, could
	/// not be found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_EXCEEDEDDEADLINE</term>
	/// <term>The binding operation could not be completed within the time limit specified by the BIND_OPTS structure passed in pBindOptions.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_CONNECTMANUALLY</term>
	/// <term>
	/// The binding operation requires assistance from the end user. The most common reasons for returning this value are that a
	/// password is needed or that a floppy needs to be mounted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_INTERMEDIATEINTERFACENOTSUPPORTED</term>
	/// <term>
	/// An intermediate object was found but it did not support an interface required to complete the binding operation. For example, an
	/// item moniker returns this value if its container does not support the IOleItemContainer interface.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks><c>CoGetObject</c> encapsulates calls to the COM library functions CreateBindCtx, MkParseDisplayName, and IMoniker::BindToObject.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetobject HRESULT CoGetObject( LPCWSTR pszName, BIND_OPTS
	// *pBindOptions, REFIID riid, void **ppv );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "0f5c9ef5-3918-4f93-bfd1-1017029b3dc1")]
	public static extern HRESULT CoGetObject([MarshalAs(UnmanagedType.LPWStr)] string pszName, in BIND_OPTS pBindOptions, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

	/// <summary>
	/// Converts a display name into a moniker that identifies the object named, and then binds to the object identified by the moniker.
	/// </summary>
	/// <param name="pszName">The display name of the object to be created.</param>
	/// <param name="pBindOptions">
	/// The binding options used to create a moniker that creates the actual object. For details, see BIND_OPTS. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="riid">A reference to the identifier of an interface that is implemented on the object to be created.</param>
	/// <param name="ppv">The address of a pointer to the interface specified by riid on the object that is created.</param>
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
	/// <term>The object was created successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_SYNTAX</term>
	/// <term>The pszName parameter is not a properly formed display name.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOOBJECT</term>
	/// <term>
	/// The object identified by this moniker, or some object identified by the composite moniker of which this moniker is a part, could
	/// not be found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_EXCEEDEDDEADLINE</term>
	/// <term>The binding operation could not be completed within the time limit specified by the BIND_OPTS structure passed in pBindOptions.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_CONNECTMANUALLY</term>
	/// <term>
	/// The binding operation requires assistance from the end user. The most common reasons for returning this value are that a
	/// password is needed or that a floppy needs to be mounted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_INTERMEDIATEINTERFACENOTSUPPORTED</term>
	/// <term>
	/// An intermediate object was found but it did not support an interface required to complete the binding operation. For example, an
	/// item moniker returns this value if its container does not support the IOleItemContainer interface.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks><c>CoGetObject</c> encapsulates calls to the COM library functions CreateBindCtx, MkParseDisplayName, and IMoniker::BindToObject.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetobject HRESULT CoGetObject( LPCWSTR pszName, BIND_OPTS
	// *pBindOptions, REFIID riid, void **ppv );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "0f5c9ef5-3918-4f93-bfd1-1017029b3dc1")]
	public static extern HRESULT CoGetObject([MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] BIND_OPTS_V pBindOptions, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

	/// <summary>
	/// Converts a display name into a moniker that identifies the object named, and then binds to the object identified by the moniker.
	/// </summary>
	/// <param name="pszName">The display name of the object to be created.</param>
	/// <param name="pBindOptions">
	/// The binding options used to create a moniker that creates the actual object. For details, see BIND_OPTS. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="riid">A reference to the identifier of an interface that is implemented on the object to be created.</param>
	/// <param name="ppv">The address of a pointer to the interface specified by riid on the object that is created.</param>
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
	/// <term>The object was created successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_SYNTAX</term>
	/// <term>The pszName parameter is not a properly formed display name.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOOBJECT</term>
	/// <term>
	/// The object identified by this moniker, or some object identified by the composite moniker of which this moniker is a part, could
	/// not be found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_EXCEEDEDDEADLINE</term>
	/// <term>The binding operation could not be completed within the time limit specified by the BIND_OPTS structure passed in pBindOptions.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_CONNECTMANUALLY</term>
	/// <term>
	/// The binding operation requires assistance from the end user. The most common reasons for returning this value are that a
	/// password is needed or that a floppy needs to be mounted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MK_E_INTERMEDIATEINTERFACENOTSUPPORTED</term>
	/// <term>
	/// An intermediate object was found but it did not support an interface required to complete the binding operation. For example, an
	/// item moniker returns this value if its container does not support the IOleItemContainer interface.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks><c>CoGetObject</c> encapsulates calls to the COM library functions CreateBindCtx, MkParseDisplayName, and IMoniker::BindToObject.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetobject HRESULT CoGetObject( LPCWSTR pszName, BIND_OPTS
	// *pBindOptions, REFIID riid, void **ppv );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "0f5c9ef5-3918-4f93-bfd1-1017029b3dc1")]
	public static extern HRESULT CoGetObject([MarshalAs(UnmanagedType.LPWStr)] string pszName, [Optional] IntPtr pBindOptions, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

	/// <summary>
	/// Returns the default values of the Security Descriptors of the machine-wide launch and access permissions, as well as launch and
	/// access limits.
	/// </summary>
	/// <param name="comSDType">
	/// A value from the COMSD enumeration. Specifies the type of the requested system security permissions, such as launch permissions,
	/// access permissions, launch restrictions, and access restrictions.
	/// </param>
	/// <param name="ppSD">
	/// Pointer to a caller-supplied variable that this routine sets to the address of a buffer containing the SECURITY_DESCRIPTOR for
	/// the system security permissions. Memory will be allocated by <c>CoGetSystemSecurityPermissions</c> and should be freed by caller
	/// with LocalFree.
	/// </param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Invalid parameter comSDType or ppSD.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>No connection to the resolver process.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Not enough memory for the security descriptor's allocation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cogetsystemsecuritypermissions HRESULT
	// CoGetSystemSecurityPermissions( COMSD comSDType, PSECURITY_DESCRIPTOR *ppSD );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "8210A6A0-B861-4E85-8E5A-1BF82A01C54E")]
	public static extern HRESULT CoGetSystemSecurityPermissions(COMSD comSDType, out AdvApi32.SafePSECURITY_DESCRIPTOR ppSD);

	/// <summary>
	/// <para>Initializes the COM library on the current thread and identifies the concurrency model as single-thread apartment (STA).</para>
	/// <para>New applications should call CoInitializeEx instead of CoInitialize.</para>
	/// <para>If you want to use the Windows Runtime, you must call Windows::Foundation::Initialize instead.</para>
	/// </summary>
	/// <param name="pvReserved">This parameter is reserved and must be <c>NULL</c>.</param>
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
	/// <term>The COM library was initialized successfully on this thread.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The COM library is already initialized on this thread.</term>
	/// </item>
	/// <item>
	/// <term>RPC_E_CHANGED_MODE</term>
	/// <term>
	/// A previous call to CoInitializeEx specified the concurrency model for this thread as multithread apartment (MTA). This could
	/// also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You need to initialize the COM library on a thread before you call any of the library functions except CoGetMalloc, to get a
	/// pointer to the standard allocator, and the memory allocation functions.
	/// </para>
	/// <para>
	/// After the concurrency model for a thread is set, it cannot be changed. A call to <c>CoInitialize</c> on an apartment that was
	/// previously initialized as multithreaded will fail and return RPC_E_CHANGED_MODE.
	/// </para>
	/// <para>
	/// CoInitializeEx provides the same functionality as <c>CoInitialize</c> and also provides a parameter to explicitly specify the
	/// thread's concurrency model. <c>CoInitialize</c> calls <c>CoInitializeEx</c> and specifies the concurrency model as single-thread
	/// apartment. Applications developed today should call <c>CoInitializeEx</c> rather than <c>CoInitialize</c>.
	/// </para>
	/// <para>
	/// Typically, the COM library is initialized on a thread only once. Subsequent calls to <c>CoInitialize</c> or CoInitializeEx on
	/// the same thread will succeed, as long as they do not attempt to change the concurrency model, but will return S_FALSE. To close
	/// the COM library gracefully, each successful call to <c>CoInitialize</c> or <c>CoInitializeEx</c>, including those that return
	/// S_FALSE, must be balanced by a corresponding call to CoUninitialize. However, the first thread in the application that calls
	/// <c>CoInitialize</c> with 0 (or <c>CoInitializeEx</c> with COINIT_APARTMENTTHREADED) must be the last thread to call
	/// <c>CoUninitialize</c>. Otherwise, subsequent calls to <c>CoInitialize</c> on the STA will fail and the application will not work.
	/// </para>
	/// <para>
	/// Because there is no way to control the order in which in-process servers are loaded or unloaded, do not call
	/// <c>CoInitialize</c>, CoInitializeEx, or CoUninitialize from the DllMain function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coinitialize HRESULT CoInitialize( LPVOID pvReserved );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "0f171cf4-87b9-43a6-97f2-80ed344fe376")]
	public static extern HRESULT CoInitialize(IntPtr pvReserved = default);

	/// <summary>
	/// Initializes the COM library for use by the calling thread, sets the thread's concurrency model, and creates a new apartment for
	/// the thread if one is required.
	/// <para>
	/// You should call Windows::Foundation::Initialize to initialize the thread instead of CoInitializeEx if you want to use the
	/// Windows Runtime APIs or if you want to use both COM and Windows Runtime components. Windows::Foundation::Initialize is
	/// sufficient to use for COM components.
	/// </para>
	/// </summary>
	/// <param name="pvReserved">This parameter is reserved and must be NULL.</param>
	/// <param name="coInit">
	/// The concurrency model and initialization options for the thread. Values for this parameter are taken from the COINIT
	/// enumeration. Any combination of values from COINIT can be used, except that the COINIT_APARTMENTTHREADED and
	/// COINIT_MULTITHREADED flags cannot both be set. The default is COINIT_MULTITHREADED.
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
	/// secure calls. A value of -1 tells COM to choose which authentication services to register, and if this is the case, the
	/// asAuthSvc parameter must be <c>NULL</c>. However, Schannel will never be chosen as an authentication service by the server if
	/// this parameter is -1.
	/// </param>
	/// <param name="asAuthSvc">
	/// An array of authentication services that a server is willing to use to receive a call. This parameter is used by COM only when a
	/// server calls <c>CoInitializeSecurity</c>. For more information, see <c>SOLE_AUTHENTICATION_SERVICE</c>.
	/// </param>
	/// <param name="pReserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwAuthnLevel">
	/// The default authentication level for the process. Both servers and clients use this parameter when they call
	/// <c>CoInitializeSecurity</c>. COM will fail calls that arrive with a lower authentication level. By default, all proxies will use
	/// at least this authentication level. This value should contain one of the authentication level constants. By default, all calls
	/// to <c>IUnknown</c> are made at this level.
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
	/// Additional capabilities of the client or server, specified by setting one or more <c>EOLE_AUTHENTICATION_CAPABILITIES</c>
	/// values. Some of these value cannot be used simultaneously, and some cannot be set when particular authentication services are
	/// being used. For more information about these flags, see the Remarks section.
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

	/// <summary>Determines whether the specified CLSID represents an OLE 1 object.</summary>
	/// <param name="rclsid">The CLSID to be checked.</param>
	/// <returns>If the CLSID refers to an OLE 1 object, the return value is <c>TRUE</c>; otherwise, it is <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// The <c>CoIsOle1Class</c> function determines whether an object class is from OLE 1. You can use it to prevent linking to
	/// embedded OLE 1 objects within a container, which OLE 1 objects do not support. After a container has determined that copied data
	/// represents an embedded object, the container code can call <c>CoIsOle1Class</c> to determine whether the embedded object is an
	/// OLE 1 object. If <c>CoIsOle1Class</c> returns <c>TRUE</c>, the container does not offer CF_LINKSOURCE as one of its clipboard
	/// formats. This is one of several OLE compatibility functions. The following compatibility functions, listed below, can be used to
	/// convert the storage formats of objects between OLE 1 and OLE.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>OleConvertIStorageToOLESTREAM</term>
	/// </item>
	/// <item>
	/// <term>OleConvertIStorageToOLESTREAMEx</term>
	/// </item>
	/// <item>
	/// <term>OleConvertOLESTREAMToIStorage</term>
	/// </item>
	/// <item>
	/// <term>OleConvertOLESTREAMToIStorageEx</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coisole1class BOOL CoIsOle1Class( REFCLSID rclsid );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "3f6a021d-c8fe-40dd-9c3a-30f22ad76ce3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CoIsOle1Class(in Guid rclsid);

	/// <summary>
	/// <para>Loads a specific DLL into the caller's process.</para>
	/// <para><c>CoLoadLibrary</c> is equivalent to LoadLibraryEx. <c>CoLoadLibrary</c> does not affect the lifetime of the library.</para>
	/// </summary>
	/// <param name="lpszLibName">The name of the library to be loaded.</param>
	/// <param name="bAutoFree">This parameter is maintained for compatibility with 16-bit applications, but is ignored.</param>
	/// <returns>If the function succeeds, the return value is a handle to the loaded library; otherwise, it is <c>NULL</c>.</returns>
	/// <remarks>
	/// <para>
	/// The CoGetClassObject function does not call <c>CoLoadLibrary</c>. <c>CoLoadLibrary</c> loads a DLL specified by the lpszLibName
	/// parameter into the process that called <c>CoGetClassObject</c>. Containers should not call <c>CoLoadLibrary</c> directly.
	/// </para>
	/// <para>
	/// Internally, a reference count is kept on the loaded DLL by using <c>CoLoadLibrary</c> to increment the count and the
	/// CoFreeLibrary function to decrement it.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coloadlibrary HINSTANCE CoLoadLibrary( LPOLESTR
	// lpszLibName, BOOL bAutoFree );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "be0d9e82-2438-488e-88c3-68dc7ac3e16f")]
	public static extern HINSTANCE CoLoadLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpszLibName, [MarshalAs(UnmanagedType.Bool)] bool bAutoFree = false);

	/// <summary>Registers a channel hook.</summary>
	/// <param name="ExtensionUuid">The extension to register.</param>
	/// <param name="pChannelHook">The channel hook to register.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coregisterchannelhook HRESULT CoRegisterChannelHook(
	// REFGUID ExtensionUuid, IChannelHook *pChannelHook );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "90281427-D0A3-4556-AF41-95DE7D000320")]
	public static extern HRESULT CoRegisterChannelHook(in Guid ExtensionUuid, IChannelHook pChannelHook);

	/// <summary>
	/// Registers an implementation of the IInitializeSpy interface. The <c>IInitializeSpy</c> interface is defied to allow developers
	/// to perform initialization and cleanup on COM apartments.
	/// </summary>
	/// <param name="pSpy">A pointer to an instance of the IInitializeSpy implementation.</param>
	/// <param name="puliCookie">The address at which to store a cookie that identifies this registration.</param>
	/// <returns>
	/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was successfully registered.</term>
	/// </item>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The object does not support IInitializeSpy.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CoRegisterInitializeSpy</c> function registers an implementation of the IInitializeSpy interface, which defines methods
	/// to be called when CoInitializeEx (or CoInitialize) or CoUninitialize is invoked.
	/// </para>
	/// <para>
	/// <c>CoRegisterInitializeSpy</c> calls QueryInterface for IID_InitializeSpy on pSpy. It stores the address of the returned
	/// interface pointer in thread-specific storage that is independent of the COM initialization state for this thread. On success, it
	/// stores in puliCookie a ULARGE_INTEGER cookie that represents this registration. Pass this cookie to CoRevokeInitializeSpy to
	/// revoke the registration.
	/// </para>
	/// <para>
	/// IInitializeSpy implementations must deal with nesting issues caused by calling CoInitializeEx or CoUninitialize from within a
	/// notification method. Notifications occur only after the registration happens on this thread. For example, if
	/// <c>CoInitializeEx</c> is called before <c>CoRegisterInitializeSpy</c>, then the PreInitialize and PostInitialize notification
	/// methods will not be called.
	/// </para>
	/// <para>
	/// Notification methods must not cause the failure of CoInitializeEx or CoUninitialize by throwing exceptions. Implementations of
	/// IInitializeSpy must not propagate exceptions to code that calls <c>CoInitializeEx</c> or <c>CoUninitialize</c>.
	/// </para>
	/// <para>
	/// It is unpredictable whether a call to <c>CoRegisterInitializeSpy</c> from within an IInitializeSpy method call will be effective
	/// during the current top-level (non-nested) call to CoInitializeEx or CoUninitialize. A registered implementation of
	/// <c>IInitializeSpy</c> will always be effective for future top-level calls to <c>CoInitializeEx</c> or <c>CoUninitialize</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coregisterinitializespy HRESULT CoRegisterInitializeSpy(
	// IInitializeSpy *pSpy, ULARGE_INTEGER *puliCookie );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "1fd5606e-0a15-429a-b656-4620b873bec5")]
	public static extern HRESULT CoRegisterInitializeSpy(IInitializeSpy pSpy, out ulong puliCookie);

	/// <summary>
	/// Registers an implementation of the IMallocSpy interface, thereafter requiring OLE to call its wrapper methods around every call
	/// to the corresponding IMalloc method.
	/// </summary>
	/// <param name="pMallocSpy">A pointer to an instance of the IMallocSpy implementation.</param>
	/// <returns>
	/// <para>This function can return the standard return value E_INVALIDARG, as well as the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was successfully registered.</term>
	/// </item>
	/// <item>
	/// <term>CO_E_OBJISREG</term>
	/// <term>The object is already registered.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CoRegisterMallocSpy</c> function registers the IMallocSpy object, which is used to debug calls to IMalloc methods. The
	/// function calls QueryInterface on the pointer pMallocSpy for the interface IID_IMallocSpy. This is to ensure that pMallocSpy
	/// really points to an implementation of <c>IMallocSpy</c>. By the rules of OLE, it is expected that a successful call to
	/// <c>QueryInterface</c> has added a reference (through the AddRef method) to the <c>IMallocSpy</c> object. That is,
	/// <c>CoRegisterMallocSpy</c> does not directly call <c>AddRef</c> on pMallocSpy, but fully expects that the <c>QueryInterface</c>
	/// call will.
	/// </para>
	/// <para>
	/// When the IMallocSpy object is registered, whenever there is a call to one of the IMalloc methods, OLE first calls the
	/// corresponding <c>IMallocSpy</c> pre-method. Then, after executing the <c>IMalloc</c> method, OLE calls the corresponding
	/// <c>IMallocSpy</c> post-method. For example, whenever there is a call to IMalloc::Alloc, from whatever source, OLE calls
	/// IMallocSpy::PreAlloc, calls <c>Alloc</c>, and after that allocation is completed, calls IMallocSpy::PostAlloc.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coregistermallocspy HRESULT CoRegisterMallocSpy(
	// LPMALLOCSPY pMallocSpy );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "28623c1f-e158-4cc5-8c7f-c13d7a65aa76")]
	public static extern HRESULT CoRegisterMallocSpy(IMallocSpy pMallocSpy);

	/// <summary>
	/// Registers with OLE the instance of an IMessageFilter interface, which is to be used for handling concurrency issues on the
	/// current thread. Only one message filter can be registered for each thread. Threads in multithreaded apartments cannot have
	/// message filters.
	/// </summary>
	/// <param name="lpMessageFilter">
	/// <para>
	/// A pointer to the IMessageFilter interface on the message filter. This message filter should be registered on the current thread,
	/// replacing the previous message filter (if any). This parameter can be <c>NULL</c>, indicating that no message filter should be
	/// registered on the current thread.
	/// </para>
	/// <para>Note that this function calls AddRef on the interface pointer to the message filter.</para>
	/// </param>
	/// <param name="lplpMessageFilter">
	/// Address of the IMessageFilter* pointer variable that receives the interface pointer to the previously registered message filter.
	/// If there was no previously registered message filter for the current thread, the value of *lplpMessageFilter is <c>NULL</c>.
	/// </param>
	/// <returns>If the instance was registered or revoked successfully, the return value is S_OK; otherwise, it is S_FALSE.</returns>
	/// <remarks>
	/// To revoke the registered message filter, pass the previous message filter (possibly <c>NULL</c>) as the lpMessageFilter
	/// parameter to <c>CoRegisterMessageFilter</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-coregistermessagefilter HRESULT CoRegisterMessageFilter(
	// LPMESSAGEFILTER lpMessageFilter, LPMESSAGEFILTER *lplpMessageFilter );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "caa5b277-ddbd-4ba9-892d-590d953b8433")]
	public static extern HRESULT CoRegisterMessageFilter(IMessageFilter lpMessageFilter, out IMessageFilter lplpMessageFilter);

	/// <summary>Revokes a registered implementation of the IInitializeSpy interface.</summary>
	/// <param name="uliCookie">A ULARGE_INTEGER cookie identifying the registration.</param>
	/// <returns>This function can return the standard return value E_INVALIDARG, as well as S_OK to indicate success.</returns>
	/// <remarks>
	/// <para>
	/// <c>CoRevokeInitializeSpy</c> can only revoke cookies issued by previous calls to CoRegisterInitializeSpy that were executed on
	/// the current thread. Using a cookie from another thread, or one that corresponds to an already revoked registration, will return E_INVALIDARG.
	/// </para>
	/// <para>
	/// It is unpredictable whether a call to <c>CoRevokeInitializeSpy</c> from within an IInitializeSpy method call will have an effect
	/// during the current top-level (non-nested) call to CoInitializeEx or CoUninitialize. The revocation will always have an effect
	/// after the current top-level call to <c>CoInitializeEx</c> or <c>CoUninitialize</c> returns.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-corevokeinitializespy HRESULT CoRevokeInitializeSpy(
	// ULARGE_INTEGER uliCookie );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "24b0bedd-421a-4215-8edc-9fdce53e3b44")]
	public static extern HRESULT CoRevokeInitializeSpy(ulong uliCookie);

	/// <summary>Revokes a registered IMallocSpy object.</summary>
	/// <returns>
	/// <para>This function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The object was revoked successfully.</term>
	/// </item>
	/// <item>
	/// <term>CO_E_OBJNOTREG</term>
	/// <term>No spy is currently registered.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>A spy is registered but there are outstanding allocations (not yet freed) made while this spy was active.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The IMallocSpy object is released when it is revoked. This release corresponds to the call to IUnknown::AddRef in the
	/// implementation of the QueryInterface function by the CoRegisterMallocSpy function. The implementation of the <c>IMallocSpy</c>
	/// interface should then do any appropriate cleanup.
	/// </para>
	/// <para>
	/// If the return code is E_ACCESSDENIED, there are still outstanding allocations that were made while the spy was active. In this
	/// case, the registered spy cannot be revoked at this time because it may have attached arbitrary headers and/or trailers to these
	/// allocations that only the spy knows about. Only the spy's PreFree (or PreRealloc) method knows how to account for these headers
	/// and trailers. Before returning E_ACCESSDENIED, <c>CoRevokeMallocSpy</c> notes internally that a revoke is pending. When the
	/// outstanding allocations have been freed, the revoke proceeds automatically, releasing the IMallocSpy object. Thus, it is
	/// necessary to call <c>CoRevokeMallocSpy</c> only once for each call to CoRegisterMallocSpy, even if E_ACCESSDENIED is returned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-corevokemallocspy HRESULT CoRevokeMallocSpy( );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "e1e984a2-2aee-452c-840c-42201ef5ee96")]
	public static extern HRESULT CoRevokeMallocSpy();

	/// <summary>Establishes or removes an emulation, in which objects of one class are treated as objects of a different class.</summary>
	/// <param name="clsidOld">The CLSID of the object to be emulated.</param>
	/// <param name="clsidNew">
	/// The CLSID of the object that should emulate the original object. This replaces any existing emulation for clsidOld. This
	/// parameter can be CLSID_NULL, in which case any existing emulation for clsidOld is removed.
	/// </param>
	/// <returns>
	/// <para>This function can return the standard return values E_INVALIDARG, as well as the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The emulation was successfully established or removed.</term>
	/// </item>
	/// <item>
	/// <term>REGDB_E_CLASSNOTREG</term>
	/// <term>The clsidOld parameter is not properly registered in the registration database.</term>
	/// </item>
	/// <item>
	/// <term>REGDB_E_READREGDB</term>
	/// <term>Error reading from registration database.</term>
	/// </item>
	/// <item>
	/// <term>REGDB_E_WRITEREGDB</term>
	/// <term>Error writing to registration database.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function sets the <c>TreatAs</c> entry in the registry for the specified object, allowing the object to be emulated by
	/// another application. Emulation allows an application to open and edit an object of a different format, while retaining the
	/// original format of the object. After this entry is set, whenever any function such as CoGetClassObject specifies the object's
	/// original CLSID (clsidOld), it is transparently forwarded to the new CLSID (clsidNew), thus launching the application associated
	/// with the <c>TreatAs</c> CLSID. When the object is saved, it can be saved in its native format, which may result in loss of edits
	/// not supported by the original format.
	/// </para>
	/// <para>If your application supports emulation, call <c>CoTreatAsClass</c> in the following situations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// In response to an end-user request (through a conversion dialog box) that a specified object be treated as an object of a
	/// different class (an object created under one application be run under another application, while retaining the original format information).
	/// </term>
	/// </item>
	/// <item>
	/// <term>In a setup program, to register that one class of objects be treated as objects of a different class.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An example of the first case is that an end user might wish to edit a spreadsheet created by one application using a different
	/// application that can read and write the spreadsheet format of the original application. For an application that supports
	/// emulation, <c>CoTreatAsClass</c> can be called to implement a <c>Treat As</c> option in a conversion dialog box.
	/// </para>
	/// <para>
	/// An example of the use of <c>CoTreatAsClass</c> in a setup program would be in an updated version of an application. When the
	/// application is updated, the objects created with the earlier version can be activated and treated as objects of the new version,
	/// while retaining the previous format information. This would allow you to give the user the option to convert when they save, or
	/// to save it in the previous format, possibly losing format information not available in the older version.
	/// </para>
	/// <para>
	/// One result of setting an emulation is that when you enumerate verbs, as in the IOleObject::EnumVerbs method implementation in
	/// the default handler, this would enumerate the verbs from clsidNew instead of clsidOld.
	/// </para>
	/// <para>
	/// To ensure that existing emulation information is removed when you install an application, your setup programs should call
	/// <c>CoTreatAsClass</c>, setting the clsidNew parameter to CLSID_NULL to remove any existing emulation for the classes they install.
	/// </para>
	/// <para>
	/// If there is no CLSID assigned to the <c>AutoTreatAs</c> key in the registry, setting clsidNew and clsidOld to the same value
	/// removes the <c>TreatAs</c> entry, so there is no emulation. If there is a CLSID assigned to the <c>AutoTreatAs</c> key, that
	/// CLSID is assigned to the <c>TreatAs</c> key.
	/// </para>
	/// <para><c>CoTreatAsClass</c> does not validate whether an appropriate registry entry for clsidNew currently exists.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-cotreatasclass HRESULT CoTreatAsClass( REFCLSID clsidOld,
	// REFCLSID clsidNew );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "d871879f-ec68-48e1-8ef6-364cf1447d0f")]
	public static extern HRESULT CoTreatAsClass(in Guid clsidOld, in Guid clsidNew);

	/// <summary>
	/// Closes the COM library on the current thread, unloads all DLLs loaded by the thread, frees any other resources that the thread
	/// maintains, and forces all RPC connections on the thread to close.
	/// </summary>
	[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
	[PInvokeData("Objbase.h", MSDNShortId = "ms688715")]
	public static extern void CoUninitialize();

	/// <summary>Creates and returns a new anti-moniker.</summary>
	/// <param name="ppmk">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the new anti-moniker. When successful, the
	/// function has called AddRef on the anti-moniker and the caller is responsible for calling Release. When an error occurs, the
	/// anti-moniker pointer is <c>NULL</c>.
	/// </param>
	/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// You would call this function only if you are writing your own moniker class (implementing the IMoniker interface). If you are
	/// writing a new moniker class that has no internal structure, you can use <c>CreateAntiMoniker</c> in your implementation of the
	/// IMoniker::Inverse method, and then check for an anti-moniker in your implementation of IMoniker::ComposeWith.
	/// </para>
	/// <para>
	/// Like the ".." directory, which acts as the inverse to any directory name just preceding it in a path, an anti-moniker acts as
	/// the inverse of a simple moniker that precedes it in a composite moniker. An anti-moniker is used as the inverse of simple
	/// monikers with no internal structure. For example, the system-provided implementations of file monikers, item monikers, and
	/// pointer monikers all use anti-monikers as their inverse; consequently, an anti-moniker composed to the right of one of these
	/// monikers composes to nothing.
	/// </para>
	/// <para>
	/// A moniker client (an object that is using a moniker to bind to another object) typically does not know the class of a given
	/// moniker, so the client cannot be sure that an anti-moniker is the inverse. Therefore, to get the inverse of a moniker, you would
	/// call IMoniker::Inverse rather than <c>CreateAntiMoniker</c>.
	/// </para>
	/// <para>To remove the last piece of a composite moniker, you would do the following:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Call IMoniker::Enum on the composite, specifying <c>FALSE</c> as the first parameter. This creates an enumerator that returns
	/// the component monikers in reverse order.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Use the enumerator to retrieve the last piece of the composite.</term>
	/// </item>
	/// <item>
	/// <term>Call IMoniker::Inverse on that moniker. The moniker returned by <c>Inverse</c> will remove the last piece of the composite.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createantimoniker HRESULT CreateAntiMoniker( LPMONIKER
	// *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "1f8fcbd6-8f05-4d32-af8a-d8de1b56dacf")]
	public static extern HRESULT CreateAntiMoniker(out IMoniker ppmk);

	/// <summary>
	/// Returns a pointer to an implementation of IBindCtx (a bind context object). This object stores information about a particular
	/// moniker-binding operation.
	/// </summary>
	/// <param name="reserved">This parameter is reserved and must be 0.</param>
	/// <param name="ppbc">
	/// Address of an IBindCtx* pointer variable that receives the interface pointer to the new bind context object. When the function
	/// is successful, the caller is responsible for calling Release on the bind context. A NULL value for the bind context indicates
	/// that an error occurred.
	/// </param>
	/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	[DllImport(Lib.Ole32, ExactSpelling = true)]
	[PInvokeData("Objbase.h", MSDNShortId = "ms678542")]
	public static extern HRESULT CreateBindCtx([Optional] uint reserved, out IBindCtx ppbc);

	/// <summary>Creates a class moniker that refers to the specified class.</summary>
	/// <param name="rclsid">A reference to the CLSID of the object type to which this moniker binds.</param>
	/// <param name="ppmk">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the new class moniker. On successful return,
	/// the function has called AddRef on the moniker and the caller is responsible for calling Release. When an error occurs, the value
	/// of the moniker pointer is <c>NULL</c>.
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
	/// <term>The moniker has been created successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The class moniker will support the binding to a fresh instance of the class identified by the CLSID in rclsid.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createclassmoniker HRESULT CreateClassMoniker( REFCLSID
	// rclsid, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "9361b2c1-ef26-4225-92ff-e0bef0285bc4")]
	public static extern HRESULT CreateClassMoniker(in Guid rclsid, out IMoniker ppmk);

	/// <summary>Retrieves a pointer to a new instance of an OLE-provided implementation of a data cache.</summary>
	/// <param name="pUnkOuter">
	/// If the cache is to be created as part of an aggregate, pointer to the controlling IUnknown of the aggregate. If not, the
	/// parameter should be <c>NULL</c>.
	/// </param>
	/// <param name="rclsid">CLSID used to generate icon labels. This value is typically CLSID_NULL.</param>
	/// <param name="iid">
	/// Reference to the identifier of the interface the caller wants to use to communicate with the cache. This value is typically
	/// IID_IOleCache (defined in the OLE headers to equal the interface identifier for IOleCache).
	/// </param>
	/// <param name="ppv">
	/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains the
	/// requested interface pointer to the supplied cache object.
	/// </param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_NOINTERFACE</term>
	/// <term>The interface represented by riid is not supported by the object. The parameter ppvObj is set to NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory for the operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The cache object created by <c>CreateDataCache</c> supports the IOleCache, IOleCache2, and IOleCacheControl interfaces for
	/// controlling the cache. It also supports the IPersistStorage, IDataObject (without advise sinks), IViewObject, and IViewObject2 interfaces.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createdatacache HRESULT CreateDataCache( LPUNKNOWN
	// pUnkOuter, REFCLSID rclsid, REFIID iid, LPVOID *ppv );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "8a64675b-1337-4555-b9a6-e19f9b987ba2")]
	public static extern HRESULT CreateDataCache([MarshalAs(UnmanagedType.IUnknown), Optional] object pUnkOuter, in Guid rclsid, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

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
	/// function has called AddRef on the file moniker and the caller is responsible for calling Release. When an error occurs, the
	/// value of the interface pointer is <c>NULL</c>.
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
	/// Composite monikers would be needed in an OLE server application that supports linking to objects smaller than a document (such
	/// as sections of a document or embedded objects).
	/// </para>
	/// <para>
	/// A file moniker can be composed to the right only of another file moniker when the first moniker is based on an absolute path and
	/// the other is a relative path, resulting in a single file moniker based on the combination of the two paths. A moniker composed
	/// to the right of another moniker must be a refinement of that moniker, and the file moniker represents the largest unit of
	/// storage. To identify objects stored within a file, you would compose other types of monikers (usually item monikers) to the
	/// right of a file moniker.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-createfilemoniker HRESULT CreateFileMoniker( LPCOLESTR
	// lpszPathName, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "d9677fa0-cda0-4b63-a21f-1fd0e27c8f3f")]
	public static extern HRESULT CreateFileMoniker([MarshalAs(UnmanagedType.LPWStr)] string lpszPathName, out IMoniker ppmk);

	/// <summary>Performs a generic composition of two monikers and supplies a pointer to the resulting composite moniker.</summary>
	/// <param name="pmkFirst">
	/// A pointer to the moniker to be composed to the left of the moniker that pmkRest points to. Can point to any kind of moniker,
	/// including a generic composite.
	/// </param>
	/// <param name="pmkRest">
	/// A pointer to the moniker to be composed to the right of the moniker to which pmkFirst points. Can point to any kind of moniker
	/// compatible with the type of the pmkRest moniker, including a generic composite.
	/// </param>
	/// <param name="ppmkComposite">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the composite moniker object that is the
	/// result of composing pmkFirst and pmkRest. This object supports the OLE composite moniker implementation of <c>IMoniker</c>. When
	/// successful, the function has called AddRef on the moniker and the caller is responsible for calling Release. If either pmkFirst
	/// or pmkRest are <c>NULL</c>, the supplied pointer is the one that is non- <c>NULL</c>. If both pmkFirst and pmkRest are
	/// <c>NULL</c>, or if an error occurs, the returned pointer is <c>NULL</c>.
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
	/// <term>The input monikers were composed successfully.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_SYNTAX</term>
	/// <term>
	/// The two monikers could not be composed due to an error in the syntax of a path (for example, if both pmkFirst and pmkRest are
	/// file monikers based on absolute paths).
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CreateGenericComposite</c> joins two monikers into one. The moniker classes being joined can be different, subject only to
	/// the rules of composition. Call this function only if you are writing a new moniker class by implementing the IMoniker interface,
	/// within an implementation of IMoniker::ComposeWith that includes generic composition capability.
	/// </para>
	/// <para>
	/// Moniker providers should call ComposeWith to compose two monikers together. Implementations of <c>ComposeWith</c> should (as do
	/// OLE implementations) attempt, when reasonable for the class, to perform non-generic compositions first, in which two monikers of
	/// the same class are combined. If this is not possible, the implementation can call <c>CreateGenericComposite</c> to do a generic
	/// composition, which combines two monikers of different classes, within the rules of composition. You can define new types of
	/// non-generic compositions if you write a new moniker class.
	/// </para>
	/// <para>
	/// During the process of composing the two monikers, <c>CreateGenericComposite</c> makes all possible simplifications. Consider the
	/// example where pmkFirst is the generic composite moniker, A + B + C, and pmkRest is the generic composite moniker, C -1 + B -1 +
	/// Z (where C -1 is the inverse of C). The function first composes C to C -1, which composes to nothing. Then it composes B and B
	/// -1 to nothing. Finally, it composes A to Z, and supplies a pointer to the generic composite moniker, A + Z.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-creategenericcomposite HRESULT CreateGenericComposite(
	// LPMONIKER pmkFirst, LPMONIKER pmkRest, LPMONIKER *ppmkComposite );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "7fe5b3ff-6e9b-4a28-93d3-52c76d3e8b77")]
	public static extern HRESULT CreateGenericComposite(IMoniker pmkFirst, IMoniker pmkRest, out IMoniker ppmkComposite);

	/// <summary>Creates an item moniker that identifies an object within a containing object (typically a compound document).</summary>
	/// <param name="lpszDelim">
	/// A pointer to a wide character string (two bytes per character) zero-terminated string containing the delimiter (typically "!")
	/// used to separate this item's display name from the display name of its containing object.
	/// </param>
	/// <param name="lpszItem">
	/// A pointer to a zero-terminated string indicating the containing object's name for the object being identified. This name can
	/// later be used to retrieve a pointer to the object in a call to IOleItemContainer::GetObject.
	/// </param>
	/// <param name="ppmk">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the item moniker. When successful, the
	/// function has called AddRef on the item moniker and the caller is responsible for calling Release. If an error occurs, the
	/// supplied interface pointer has a <c>NULL</c> value.
	/// </param>
	/// <returns>This function can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A moniker provider, which hands out monikers to identify its objects so they are accessible to other parties, would call
	/// <c>CreateItemMoniker</c> to identify its objects with item monikers. Item monikers are based on a string, and identify objects
	/// that are contained within another object and can be individually identified using a string. The containing object must also
	/// implement the IOleContainer interface.
	/// </para>
	/// <para>
	/// Most moniker providers are OLE applications that support linking. Applications that support linking to objects smaller than
	/// file-based documents, such as a server application that allows linking to a selection within a document, should use item
	/// monikers to identify the objects. Container applications that allow linking to embedded objects use item monikers to identify
	/// the embedded objects.
	/// </para>
	/// <para>
	/// The lpszItem parameter is the name used by the document to uniquely identify the object. For example, if the object being
	/// identified is a cell range in a spreadsheet, an appropriate name might be something like "A1:E7." An appropriate name when the
	/// object being identified is an embedded object might be something like "embedobj1." The containing object must provide an
	/// implementation of the IOleItemContainer interface that can interpret this name and locate the corresponding object. This allows
	/// the item moniker to be bound to the object it identifies.
	/// </para>
	/// <para>
	/// Item monikers are not used in isolation. They must be composed with a moniker that identifies the containing object as well. For
	/// example, if the object being identified is a cell range contained in a file-based document, the item moniker identifying that
	/// object must be composed with the file moniker identifying that document, resulting in a composite moniker that is the equivalent
	/// of "C:\work\sales.xls!A1:E7."
	/// </para>
	/// <para>
	/// Nested containers are allowed also, as in the case where an object is contained within an embedded object inside another
	/// document. The complete moniker of such an object would be the equivalent of "C:\work\report.doc!embedobj1!A1:E7." In this case,
	/// each containing object must call <c>CreateItemMoniker</c> and provide its own implementation of the IOleItemContainer interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createitemmoniker HRESULT CreateItemMoniker( LPCOLESTR
	// lpszDelim, LPCOLESTR lpszItem, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "339919ed-660c-4239-825b-7fa96c48e5cd")]
	public static extern HRESULT CreateItemMoniker([MarshalAs(UnmanagedType.LPWStr)] string lpszDelim, [MarshalAs(UnmanagedType.LPWStr)] string lpszItem, out IMoniker ppmk);

	/// <summary>Creates an OBJREF moniker based on a pointer to an object.</summary>
	/// <param name="punk">A pointer to the IUnknown interface on the object that the moniker is to represent.</param>
	/// <param name="ppmk">Address of a pointer to the IMoniker interface on the OBJREF moniker that was created.</param>
	/// <returns>This function can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
	/// <remarks>
	/// <para>Clients use OBJREF monikers to obtain a marshaled pointer to a running object in the servers address space.</para>
	/// <para>
	/// The server typically calls <c>CreateObjrefMoniker</c> to create an OBJREF moniker and then calls IMoniker::GetDisplayName, and
	/// finally releases the moniker. The display name for an OBJREF moniker is of the form:
	/// </para>
	/// <para>OBJREF:nnnnnnnn</para>
	/// <para>
	/// Where nnnnnnnn is an arbitrarily long base-64 encoding that encapsulates the computer location, process endpoint, and interface
	/// pointer ID (IPID) of the running object
	/// </para>
	/// <para>
	/// The display name can then be transferred to the client as text. For example, the display name can reside on an HTML page that
	/// the client downloads.
	/// </para>
	/// <para>
	/// The client can pass the display name to MkParseDisplayName, which creates an OBJREF moniker based on the display name. A call to
	/// the monikers IMoniker::BindToObject method then obtains a marshaled pointer to the running instance on the server.
	/// </para>
	/// <para>
	/// For example, a server-side COM component contained in an Active Server Page can create an OBJREF moniker, obtain its display
	/// name, and write the display name to the HTML output that is sent to the client browser. A script that runs on the client side
	/// can use the display name to get access to the running object itself. A client-side Visual Basic script, for instance, could
	/// store the display name in a variable called strMyName and include this line:
	/// </para>
	/// <para>
	/// The script engine internally makes the calls to MkParseDisplayName and IMoniker::BindToObject, and the script can then use
	/// objMyInstance to refer directly to the running object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createobjrefmoniker HRESULT CreateObjrefMoniker( LPUNKNOWN
	// punk, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "0a214a11-776c-4ef6-af68-a141398f853c")]
	public static extern HRESULT CreateObjrefMoniker([MarshalAs(UnmanagedType.IUnknown)] object punk, out IMoniker ppmk);

	/// <summary>Creates a pointer moniker based on a pointer to an object.</summary>
	/// <param name="punk">A pointer to an IUnknown interface on the object to be identified by the resulting moniker.</param>
	/// <param name="ppmk">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the new pointer moniker. When successful,
	/// the function has called AddRef on the moniker and the caller is responsible for calling Release. When an error occurs, the
	/// returned interface pointer has a <c>NULL</c> value.
	/// </param>
	/// <returns>This function can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
	/// <remarks>
	/// <para>
	/// A pointer moniker wraps an existing interface pointer in a moniker that can be passed to those interfaces that require monikers.
	/// Pointer monikers allow an object that has no persistent representation to participate in a moniker-binding operation.
	/// </para>
	/// <para>Pointer monikers are not commonly used, so this function is not often called.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-createpointermoniker HRESULT CreatePointerMoniker(
	// LPUNKNOWN punk, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "d4d40fd5-6035-4ddc-a443-01d32dcf4bca")]
	public static extern HRESULT CreatePointerMoniker([MarshalAs(UnmanagedType.IUnknown)] object punk, out IMoniker ppmk);

	/// <summary>Returns the CLSID associated with the specified file name.</summary>
	/// <param name="szFilename">A pointer to the filename for which you are requesting the associated CLSID.</param>
	/// <param name="pclsid">A pointer to the location where the associated CLSID is written on return.</param>
	/// <returns>
	/// <para>This function can return any of the file system errors, as well as the following values.</para>
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
	/// <term>MK_E_CANTOPENFILE</term>
	/// <term>Unable to open the specified file name.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_INVALIDEXTENSION</term>
	/// <term>The specified extension in the registry is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When given a file name, <c>GetClassFile</c> finds the CLSID associated with that file. Examples of its use are in the
	/// OleCreateFromFile function, which is passed a file name and requires an associated CLSID, and in the OLE implementation of
	/// IMoniker::BindToObject, which, when a link to a file-based document is activated, calls <c>GetClassFile</c> to locate the object
	/// application that can open the file.
	/// </para>
	/// <para><c>GetClassFile</c> uses the following strategies to determine an appropriate CLSID:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If the file contains a storage object, as determined by a call to the StgIsStorageFile function, <c>GetClassFile</c> returns the
	/// CLSID that was written with the IStorage::SetClass method.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the file is not a storage object, <c>GetClassFile</c> attempts to match various bits in the file against a pattern in the
	/// registry. A pattern in the registry can contain a series of entries of the form:
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the above strategies fail, <c>GetClassFile</c> searches for the <c>File Extension</c> key in the registry that corresponds to
	/// the .ext portion of the file name. If the database entry contains a valid CLSID, <c>GetClassFile</c> returns that CLSID.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If all strategies fail, the function returns MK_E_INVALIDEXTENSION.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-getclassfile HRESULT GetClassFile( LPCOLESTR szFilename,
	// CLSID *pclsid );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "dc3cb263-7b9a-45f9-8eab-3a88aa9392db")]
	public static extern HRESULT GetClassFile([MarshalAs(UnmanagedType.LPWStr)] string szFilename, out Guid pclsid);

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
	/// linking to their documents (or portions of a document) and container applications that support linking to embeddings within
	/// their documents. Server applications that do not support linking can also use the ROT to cooperate with container applications
	/// that support linking to embeddings.
	/// </para>
	/// <para>
	/// If you are implementing the IMoniker interface to write a new moniker class, and you need an interface pointer to the ROT, call
	/// IBindCtx::GetRunningObjectTable rather than the <c>GetRunningObjectTable</c> function. This allows future implementations of the
	/// IBindCtx interface to modify binding behavior.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-getrunningobjecttable HRESULT GetRunningObjectTable(
	// DWORD reserved, LPRUNNINGOBJECTTABLE *pprot );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "65d9cf7d-cc8a-4199-9a4a-7fd67ef8872d")]
	public static extern HRESULT GetRunningObjectTable([Optional] uint reserved, out IRunningObjectTable pprot);

	/// <summary>Determines whether two GUIDs are equal.</summary>
	/// <param name="rguid1">The first GUID.</param>
	/// <param name="rguid2">The second GUID.</param>
	/// <returns><see langword="true"/> if equal; <see langword="false"/> otherwise.</returns>
	/// <remarks><c>IsEqualGUID</c> is used by the IsEqualCLSID and IsEqualIID functions.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/guiddef/nf-guiddef-isequalguid void IsEqualGUID( rguid1, rguid2 );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("guiddef.h", MSDNShortId = "3580a0c4-e1f8-4bb7-ba66-c4702ecd11f1")]
	public static extern bool IsEqualGUID(Guid rguid1, Guid rguid2);

	/// <summary>
	/// <para>Converts a string into a moniker that identifies the object named by the string.</para>
	/// <para>
	/// This function is the inverse of the IMoniker::GetDisplayName operation, which retrieves the display name associated with a moniker.
	/// </para>
	/// </summary>
	/// <param name="pbc">A pointer to the IBindCtx interface on the bind context object to be used in this binding operation.</param>
	/// <param name="szUserName">A pointer to the display name to be parsed.</param>
	/// <param name="pchEaten">
	/// A pointer to the number of characters of szUserName that were consumed. If the function is successful, *pchEaten is the length
	/// of szUserName; otherwise, it is the number of characters successfully parsed.
	/// </param>
	/// <param name="ppmk">
	/// The address of the IMoniker* pointer variable that receives the interface pointer to the moniker that was built from szUserName.
	/// When successful, the function has called AddRef on the moniker and the caller is responsible for calling Release. If an error
	/// occurs, the specified interface pointer will contain as much of the moniker that the method was able to create before the error occurred.
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
	/// <term>The parse operation was successful and the moniker was created.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_SYNTAX</term>
	/// <term>Error in the syntax of a file name or an error in the syntax of the resulting composite moniker.</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function can also return any of the error values returned by IMoniker::BindToObject, IOleItemContainer::GetObject, or IParseDisplayName::ParseDisplayName.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MkParseDisplayName</c> function parses a human-readable name into a moniker that can be used to identify a link source.
	/// The resulting moniker can be a simple moniker (such as a file moniker), or it can be a generic composite made up of the
	/// component moniker pieces. For example, the display name "c:\mydir\somefile!item 1"
	/// </para>
	/// <para>
	/// could be parsed into the following generic composite moniker: FileMoniker based on "c:\mydir\somefile") + (ItemMoniker based on
	/// "item 1").
	/// </para>
	/// <para>
	/// The most common use of <c>MkParseDisplayName</c> is in the implementation of the standard <c>Links</c> dialog box, which allows
	/// an end user to specify the source of a linked object by typing in a string. You may also need to call <c>MkParseDisplayName</c>
	/// if your application supports a macro language that permits remote references (reference to elements outside of the document).
	/// </para>
	/// <para>
	/// Parsing a display name often requires activating the same objects that would be activated during a binding operation, so it can
	/// be just as expensive (in terms of performance) as binding. Objects that are bound during the parsing operation are cached in the
	/// bind context passed to the function. If you plan to bind the moniker returned by <c>MkParseDisplayName</c>, it is best to do so
	/// immediately after the function returns, using the same bind context, which removes the need to activate objects a second time.
	/// </para>
	/// <para>
	/// <c>MkParseDisplayName</c> parses as much of the display name as it understands into a moniker. The function then calls
	/// IMoniker::ParseDisplayName on the newly created moniker, passing the remainder of the display name. The moniker returned by
	/// <c>ParseDisplayName</c> is composed onto the end of the existing moniker and, if any of the display name remains unparsed,
	/// <c>ParseDisplayName</c> is called on the result of the composition. This process is repeated until the entire display name has
	/// been parsed.
	/// </para>
	/// <para>
	/// <c>MkParseDisplayName</c> attempts the following strategies to parse the beginning of the display name, using the first one that succeeds:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// The function looks in the Running Object Table for file monikers corresponding to all prefixes of the display name that consist
	/// solely of valid file name characters. This strategy can identify documents that are as yet unsaved.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The function checks the maximal prefix of the display name, which consists solely of valid file name characters, to see if an
	/// OLE 1 document is registered by that name. In this case, the returned moniker is an internal moniker provided by the OLE 1
	/// compatibility layer of OLE 2.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The function consults the file system to check whether a prefix of the display name matches an existing file. The file name can
	/// be drive-absolute, drive-relative, working-directory relative, or begin with an explicit network share name. This is the common case.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the initial character of the display name is '@', the function finds the longest string immediately following it that
	/// conforms to the legal ProgID syntax. The function converts this string to a CLSID using the CLSIDFromProgID function. If the
	/// CLSID represents an OLE 2 class, the function loads the corresponding class object and asks for an IParseDisplayName interface
	/// pointer. The resulting <c>IParseDisplayName</c> interface is then given the whole string to parse, starting with the '@'. If the
	/// CLSID represents an OLE 1 class, then the function treats the string following the ProgID as an OLE1/DDE link designator having
	/// filename|item syntax.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-mkparsedisplayname HRESULT MkParseDisplayName( LPBC pbc,
	// LPCOLESTR szUserName, ULONG *pchEaten, LPMONIKER *ppmk );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "ada46dd3-e2c5-4ff5-89bd-3805f98b247b")]
	public static extern HRESULT MkParseDisplayName(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string szUserName, ref uint pchEaten, out IMoniker ppmk);

	/// <summary>
	/// <para>
	/// Creates a new moniker based on the common prefix that this moniker (the one comprising the data of this moniker object) shares
	/// with another moniker.
	/// </para>
	/// <para>This function is intended to be called only in implementations of IMoniker::CommonPrefixWith.</para>
	/// </summary>
	/// <param name="pmkThis">
	/// A pointer to the IMoniker interface on one of the monikers for which a common prefix is sought; usually the moniker in which
	/// this call is used to implement IMoniker::CommonPrefixWith.
	/// </param>
	/// <param name="pmkOther">A pointer to the IMoniker interface on the moniker to be compared with the first moniker.</param>
	/// <param name="ppmkCommon">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the moniker based on the common prefix of
	/// pmkThis and pmkOther. When successful, the function has called AddRef on the moniker and the caller is responsible for calling
	/// Release. If an error occurs, the supplied interface pointer value is <c>NULL</c>.
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
	/// <term>A common prefix exists that is neither pmkThis nor pmkOther.</term>
	/// </item>
	/// <item>
	/// <term>MK_S_HIM</term>
	/// <term>The entire pmkOther moniker is a prefix of the pmkThis moniker.</term>
	/// </item>
	/// <item>
	/// <term>MK_S_ME</term>
	/// <term>The entire pmkThis moniker is a prefix of the pmkOther moniker.</term>
	/// </item>
	/// <item>
	/// <term>MK_S_US</term>
	/// <term>The pmkThis and pmkOther monikers are equal.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOPREFIX</term>
	/// <term>The monikers have no common prefix.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOTBINDABLE</term>
	/// <term>This function was called on a relative moniker. It is not meaningful to take the common prefix of relative monikers.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Your implementation of IMoniker::CommonPrefixWith should first check whether the other moniker is of a type that you recognize
	/// and handle in a special way. If not, you should call <c>MonikerCommonPrefixWith</c>, passing itself as pmkThis and the other
	/// moniker as pmkOther. <c>MonikerCommonPrefixWith</c> correctly handles the cases where either moniker is a generic composite.
	/// </para>
	/// <para>
	/// You should call this function only if pmkThis and pmkOther are both absolute monikers (where an absolute moniker is either a
	/// file moniker or a generic composite whose leftmost component is a file moniker, and where the file moniker represents an
	/// absolute path). Do not call this function on relative monikers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-monikercommonprefixwith HRESULT MonikerCommonPrefixWith(
	// LPMONIKER pmkThis, LPMONIKER pmkOther, LPMONIKER *ppmkCommon );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "6caa8c2e-c3d6-45d5-8efe-74d6a2c4a926")]
	public static extern HRESULT MonikerCommonPrefixWith(IMoniker pmkThis, IMoniker pmkOther, out IMoniker ppmkCommon);

	/// <summary>
	/// <para>
	/// Provides a moniker that, when composed onto the end of the first specified moniker (or one with a similar structure), yields the
	/// second specified moniker.
	/// </para>
	/// <para>This function is intended for use only by IMoniker::RelativePathTo implementations.</para>
	/// </summary>
	/// <param name="pmkSrc">
	/// A pointer to the IMoniker interface on the moniker that, when composed with the relative moniker to be created, produces
	/// pmkDest. This moniker identifies the "source" of the relative moniker to be created.
	/// </param>
	/// <param name="pmkDest">
	/// A pointer to the IMoniker interface on the moniker to be expressed relative to pmkSrc. This moniker identifies the destination
	/// of the relative moniker to be created.
	/// </param>
	/// <param name="ppmkRelPath">
	/// The address of an IMoniker* pointer variable that receives the interface pointer to the new relative moniker. When successful,
	/// the function has called AddRef on the moniker and the caller is responsible for calling Release. If an error occurs, the
	/// interface pointer value is <c>NULL</c>.
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be nonzero.</param>
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
	/// <term>A meaningful relative path has been returned.</term>
	/// </item>
	/// <item>
	/// <term>MK_S_HIM</term>
	/// <term>The only form of the relative path is the other moniker.</term>
	/// </item>
	/// <item>
	/// <term>MK_E_NOTBINDABLE</term>
	/// <term>
	/// The pmkSrc parameter is a relative moniker, such as an item moniker, and must be composed with the moniker of its container
	/// before a relative path can be determined.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Your implementation of IMoniker::RelativePathTo should first check whether the other moniker is of a type you recognize and
	/// handle in a special way. If not, you should call <c>MonikerRelativePathTo</c>, passing itself as pmkThis and the other moniker
	/// as pmkOther. <c>MonikerRelativePathTo</c> correctly handles the cases where either moniker is a generic composite.
	/// </para>
	/// <para>
	/// You should call this function only if pmkSrc and pmkDest are both absolute monikers, where an absolute moniker is either a file
	/// moniker or a generic composite whose leftmost component is a file moniker, and where the file moniker represents an absolute
	/// path. Do not call this function on relative monikers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objbase/nf-objbase-monikerrelativepathto HRESULT MonikerRelativePathTo(
	// LPMONIKER pmkSrc, LPMONIKER pmkDest, LPMONIKER *ppmkRelPath, BOOL dwReserved );
	[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("objbase.h", MSDNShortId = "55ab4db3-a94e-48ba-abe3-44963c35e062")]
	public static extern HRESULT MonikerRelativePathTo(IMoniker pmkSrc, IMoniker pmkDest, out IMoniker ppmkRelPath, [MarshalAs(UnmanagedType.Bool)] bool dwReserved = false);

	/// <summary>Provides a CO_MTA_USAGE_COOKIE.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CO_MTA_USAGE_COOKIE : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="CO_MTA_USAGE_COOKIE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public CO_MTA_USAGE_COOKIE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="CO_MTA_USAGE_COOKIE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static CO_MTA_USAGE_COOKIE NULL => new CO_MTA_USAGE_COOKIE(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="CO_MTA_USAGE_COOKIE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(CO_MTA_USAGE_COOKIE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="CO_MTA_USAGE_COOKIE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CO_MTA_USAGE_COOKIE(IntPtr h) => new CO_MTA_USAGE_COOKIE(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CO_MTA_USAGE_COOKIE h1, CO_MTA_USAGE_COOKIE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CO_MTA_USAGE_COOKIE h1, CO_MTA_USAGE_COOKIE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is CO_MTA_USAGE_COOKIE h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

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
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwcsTemplateFile;
	}

	/// <summary>Identifies a remote computer resource to the activation functions.</summary>
	/// <remarks>
	/// <para>
	/// The <c>COSERVERINFO</c> structure is used primarily to identify a remote system in object creation functions. Computer resources
	/// are named using the naming scheme of the network transport. By default, all UNC ("\server" or "server") and DNS names
	/// ("domain.com", "example.microsoft.com", or "135.5.33.19") names are allowed.
	/// </para>
	/// <para>
	/// If <c>pAuthInfo</c> is set to <c>NULL</c>, Snego will be used to negotiate an authentication service that will work between the
	/// client and server. However, a non- <c>NULL</c> COAUTHINFO structure can be specified for <c>pAuthInfo</c> to meet any one of the
	/// following needs:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To specify a different client identity for computer remote activations. The specified identity will be used for the launch
	/// permission check on the server rather than the real client identity.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To specify that Kerberos, rather than NTLMSSP, is used for machine remote activation. A nondefault client identity may or may
	/// not be specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>To request unsecure activation.</term>
	/// </item>
	/// <item>
	/// <term>To specify a proprietary authentication service.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>pAuthInfo</c> is not <c>NULL</c>, those values will be used to specify the authentication settings for the remote call.
	/// These settings will be passed to the RpcBindingSetAuthInfoEx function.
	/// </para>
	/// <para>
	/// If the pAuthInfo parameter is <c>NULL</c>, then dwAuthnLevel can be overridden by the authentication level set by the
	/// CoInitializeSecurity function. If the <c>CoInitializeSecurity</c> function isn't called, then the authentication level specified
	/// under the AppID registry key is used, if it exists.
	/// </para>
	/// <para>
	/// Starting with Windows XP with Service Pack 2 (SP2), dwAuthnLevel is the maximum of RPC_C_AUTHN_LEVEL_CONNECT and the
	/// process-wide authentication level of the client process that is issuing the activation request. For earlier versions of the
	/// operating system, this is RPC_C_AUTHN_LEVEL_CONNECT.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-_coserverinfo typedef struct _COSERVERINFO { DWORD
	// dwReserved1; LPWSTR pwszName; COAUTHINFO *pAuthInfo; DWORD dwReserved2; } COSERVERINFO;
	[PInvokeData("objidl.h", MSDNShortId = "88c94a7f-5cf0-4d61-833f-91cba45d8624")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class COSERVERINFO
	{
		/// <summary>This member is reserved and must be 0.</summary>
		public uint dwReserved1;

		/// <summary>The name of the computer.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszName;

		/// <summary>
		/// A pointer to a COAUTHINFO structure to override the default activation security for machine remote activations. Otherwise,
		/// set to <c>NULL</c> to indicate that default values should be used. For more information, see the Remarks section.
		/// </summary>
		public IntPtr pAuthInfo;

		/// <summary>This member is reserved and must be 0.</summary>
		public uint dwReserved2;
	}
}