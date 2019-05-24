using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
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
		// APTTYPEQUALIFIER_NA_ON_IMPLICIT_MTA, APTTYPEQUALIFIER_NA_ON_MAINSTA, APTTYPEQUALIFIER_APPLICATION_STA, APTTYPEQUALIFIER_RESERVED_1
		// } APTTYPEQUALIFIER;
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
			/// When an implicit MTA thread creates or invokes a COM in-process object using the "Neutral" threading model, the COM apartment
			/// type of the thread switches from the implicit MTA type to a Neutral apartment type. This qualifier informs the API caller
			/// that the thread has switched from the implicit MTA apartment type to the NA type.
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
		/// To indicate that more than one context is acceptable, you can combine multiple values with Boolean ORs. The contexts are tried in
		/// the order in which they are listed.
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
		/// whatsoever, the request to activate and initialize is forwarded to the computer where the persistent state resides. (Refer to the
		/// remote activation functions listed in the See Also section for details.)
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
		/// If the flags include CLSCTX_INPROC_HANDLER, the class code in the DLL found under the class's InprocHandler32 key is used if this
		/// key exists. The class code will run within the same process as the caller.
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
		/// If the flag is set to CLSCTX_REMOTE_SERVER and an additional COSERVERINFO parameter to the function specifies a particular remote
		/// computer, a request to activate is forwarded to this remote computer with flags modified to set to CLSCTX_LOCAL_SERVER. The class
		/// code will run in its own process on this specific computer, which must be different from that of the caller.
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

		/// <summary>
		/// Closes the COM library on the current thread, unloads all DLLs loaded by the thread, frees any other resources that the thread
		/// maintains, and forces all RPC connections on the thread to close.
		/// </summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms688715")]
		public static extern void CoUninitialize();

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

		/// <summary>Represents an interface in a query for multiple interfaces.</summary>
		/// <remarks>
		/// To optimize network performance, most remote activation functions take an array of <c>MULTI_QI</c> structures rather than just a
		/// single IID as input and a single pointer to the requested interface on the object as output, as do local activation functions.
		/// This allows a set of pointers to interfaces to be returned from the same object in a single round-trip to the server. In network
		/// scenarios, requesting multiple interfaces at the time of object construction can save considerable time over using a number of
		/// calls to QueryInterface for unique interfaces, each of which would require a round-trip to the server.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagmulti_qi typedef struct tagMULTI_QI { const IID *pIID;
		// IUnknown *pItf; HRESULT hr; } MULTI_QI;
		[PInvokeData("objidl.h", MSDNShortId = "845040c9-fad4-4ac8-856d-d35edbf48ec9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MULTI_QI
		{
			/// <summary>A pointer to an interface identifier.</summary>
			public IntPtr pIID;

			/// <summary>A pointer to the interface requested in <c>pIID</c>. This member must be <c>NULL</c> on input.</summary>
			public IntPtr pItf;

			/// <summary>
			/// The return value of the QueryInterface call to locate the requested interface. Common return values include S_OK and
			/// E_NOINTERFACE. This member must be 0 on input.
			/// </summary>
			public HRESULT hr;
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
		/// To specify that Kerberos, rather than NTLMSSP, is used for machine remote activation. A nondefault client identity may or may not
		/// be specified.
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
		/// Starting with Windows XP with Service Pack 2 (SP2), dwAuthnLevel is the maximum of RPC_C_AUTHN_LEVEL_CONNECT and the process-wide
		/// authentication level of the client process that is issuing the activation request. For earlier versions of the operating system,
		/// this is RPC_C_AUTHN_LEVEL_CONNECT.
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
}