using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Determines the concurrency model used for incoming calls to objects created by this thread. This concurrency model can be either apartment-threaded
		/// or multithreaded.
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
		/// The STGFMT enumeration values specify the format of a storage object and are used in the StgCreateStorageEx and StgOpenStorageEx functions in the stgfmt parameter. This value, in combination with the value in the riid parameter, is used to determine the file format and the interface implementation to use.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380330")]
		public enum STGFMT
		{
			/// <summary>Indicates that the file must be a compound file.</summary>
			STGFMT_STORAGE = 0,
			/// <summary>Undocumented.</summary>
			STGFMT_NATIVE = 1,
			/// <summary>Indicates that the file must not be a compound file. This element is only valid when using the StgCreateStorageEx or StgOpenStorageEx functions to access the NTFS file system implementation of the IPropertySetStorage interface. Therefore, these functions return an error if the riid parameter does not specify the IPropertySetStorage interface, or if the specified file is not located on an NTFS file system volume.</summary>
			STGFMT_FILE = 3,
			/// <summary>Indicates that the system will determine the file type and use the appropriate structured storage or property set implementation. This value cannot be used with the StgCreateStorageEx function.</summary>
			STGFMT_ANY = 4,
			/// <summary>Indicates that the file must be a compound file, and is similar to the STGFMT_STORAGE flag, but indicates that the compound-file form of the compound-file implementation must be used. For more information, see Compound File Implementation Limits.</summary>
			STGFMT_DOCFILE = 5
		}

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-cogetinterfaceandreleasestream
		// HRESULT CoGetInterfaceAndReleaseStream( LPSTREAM pStm, REFIID iid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "b529f65f-3208-4594-a772-d1cad3727dc1")]
		public static extern HRESULT CoGetInterfaceAndReleaseStream(IStream pStm, in Guid iid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>
		/// Initializes the COM library for use by the calling thread, sets the thread's concurrency model, and creates a new apartment for the thread if one is required.
		/// <para>
		/// You should call Windows::Foundation::Initialize to initialize the thread instead of CoInitializeEx if you want to use the Windows Runtime APIs or if
		/// you want to use both COM and Windows Runtime components. Windows::Foundation::Initialize is sufficient to use for COM components.
		/// </para>
		/// </summary>
		/// <param name="pvReserved">This parameter is reserved and must be NULL.</param>
		/// <param name="coInit">
		/// The concurrency model and initialization options for the thread. Values for this parameter are taken from the COINIT enumeration. Any combination of
		/// values from COINIT can be used, except that the COINIT_APARTMENTTHREADED and COINIT_MULTITHREADED flags cannot both be set. The default is COINIT_MULTITHREADED.
		/// </param>
		/// <returns>
		/// <list type="table">
		/// <listheader><term>Return code</term><term>Description</term></listheader>
		/// <item><term>S_OK</term><defintion>The COM library was initialized successfully on this thread.</defintion></item>
		/// <item><term>S_FALSE</term><defintion>The COM library is already initialized on this thread.</defintion></item>
		/// <item><term>RPC_E_CHANGED_MODE</term><defintion>A previous call to CoInitializeEx specified the concurrency model for this thread as multithreaded apartment (MTA). This could also indicate that a change from neutral-threaded apartment to single-threaded apartment has occurred.</defintion></item>
		/// </list>
		/// </returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms695279")]
		public static extern HRESULT CoInitializeEx([Optional] IntPtr pvReserved, COINIT coInit);

		/// <summary>Registers security and sets the default security values for the process.</summary>
		/// <param name="pSecDesc">
		/// The access permissions that a server will use to receive calls. This parameter is used by COM only when a server calls <c>CoInitializeSecurity</c>.
		/// Its value is a pointer to one of three types: an AppID, an <c>IAccessControl</c> object, or a <c>SECURITY_DESCRIPTOR</c>, in absolute format. See the
		/// Remarks section for more information.
		/// </param>
		/// <param name="cAuthSvc">
		/// The count of entries in the asAuthSvc parameter. This parameter is used by COM only when a server calls <c>CoInitializeSecurity</c>. If this
		/// parameter is 0, no authentication services will be registered and the server cannot receive secure calls. A value of -1 tells COM to choose which
		/// authentication services to register, and if this is the case, the asAuthSvc parameter must be <c>NULL</c>. However, Schannel will never be chosen as
		/// an authentication service by the server if this parameter is -1.
		/// </param>
		/// <param name="asAuthSvc">
		/// An array of authentication services that a server is willing to use to receive a call. This parameter is used by COM only when a server calls
		/// <c>CoInitializeSecurity</c>. For more information, see <c>SOLE_AUTHENTICATION_SERVICE</c>.
		/// </param>
		/// <param name="pReserved1">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="dwAuthnLevel">
		/// The default authentication level for the process. Both servers and clients use this parameter when they call <c>CoInitializeSecurity</c>. COM will
		/// fail calls that arrive with a lower authentication level. By default, all proxies will use at least this authentication level. This value should
		/// contain one of the authentication level constants. By default, all calls to <c>IUnknown</c> are made at this level.
		/// </param>
		/// <param name="dwImpLevel">
		/// <para>
		/// The default impersonation level for proxies. The value of this parameter is used only when the process is a client. It should be a value from the
		/// impersonation level constants, except for RPC_C_IMP_LEVEL_DEFAULT, which is not for use with <c>CoInitializeSecurity</c>.
		/// </para>
		/// <para>
		/// Outgoing calls from the client always use the impersonation level as specified. (It is not negotiated.) Incoming calls to the client can be at any
		/// impersonation level. By default, all <c>IUnknown</c> calls are made with this impersonation level, so even security-aware applications should set
		/// this level carefully. To determine which impersonation levels each authentication service supports, see the description of the authentication
		/// services in COM and Security Packages. For more information about impersonation levels, see Impersonation.
		/// </para>
		/// </param>
		/// <param name="pAuthList">
		/// A pointer to <c>SOLE_AUTHENTICATION_LIST</c>, which is an array of <c>SOLE_AUTHENTICATION_INFO</c> structures. This list indicates the information
		/// for each authentication service that a client can use to call a server. This parameter is used by COM only when a client calls <c>CoInitializeSecurity</c>.
		/// </param>
		/// <param name="dwCapabilities">
		/// Additional capabilities of the client or server, specified by setting one or more <c>EOLE_AUTHENTICATION_CAPABILITIES</c> values. Some of these value
		/// cannot be used simultaneously, and some cannot be set when particular authentication services are being used. For more information about these flags,
		/// see the Remarks section.
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
		/// The asAuthSvc parameter was not NULL, and none of the authentication services in the list could be registered. Check the results saved in asAuthSvc
		/// for authentication service–specific error codes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_OUT_OF_MEMORY</term>
		/// <term>Out of memory.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT CoInitializeSecurity( _In_opt_ PSECURITY_DESCRIPTOR pSecDesc, _In_ LONG cAuthSvc, _In_opt_ SOLE_AUTHENTICATION_SERVICE *asAuthSvc, _In_opt_ void *pReserved1, _In_ DWORD dwAuthnLevel, _In_ DWORD dwImpLevel, _In_opt_ void *pAuthList, _In_ DWORD dwCapabilities, _In_opt_ void *pReserved3);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms693736(v=vs.85).aspx
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-comarshalinterface
		// HRESULT CoMarshalInterface( LPSTREAM pStm, REFIID riid, LPUNKNOWN pUnk, DWORD dwDestContext, LPVOID pvDestContext, DWORD mshlflags );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-comarshalinterthreadinterfaceinstream
		// HRESULT CoMarshalInterThreadInterfaceInStream( REFIID riid, LPUNKNOWN pUnk, LPSTREAM *ppStm );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "c9ab8713-8604-4f0b-a11b-bdfb7d595d95")]
		public static extern HRESULT CoMarshalInterThreadInterfaceInStream(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk, out IStream ppStm);

		/// <summary>
		/// Closes the COM library on the current thread, unloads all DLLs loaded by the thread, frees any other resources that the thread maintains, and forces
		/// all RPC connections on the thread to close.
		/// </summary>
		[DllImport(Lib.Ole32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "ms688715")]
		public static extern void CoUninitialize();

		/// <summary>
		/// Initializes a newly created proxy using data written into the stream by a previous call to the CoMarshalInterface function, and
		/// returns an interface pointer to that proxy.
		/// </summary>
		/// <param name="pStm">A pointer to the stream from which the interface is to be unmarshaled.</param>
		/// <param name="riid">A reference to the identifier of the interface to be unmarshaled. For <c>IID_NULL</c>, the returned interface is the one defined
		/// by the stream, objref.iid.</param>
		/// <param name="ppv">The address of pointer variable that receives the interface pointer requested in <paramref name="riid" />. Upon successful return,
		/// <paramref name="ppv" /> contains the requested interface pointer for the unmarshaled interface.</param>
		/// <returns>
		/// <para>This function can return the standard return value E_FAIL, errors returned by CoCreateInstance, and the following values.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>S_OK</term>
		///     <term>The interface pointer was unmarshaled successfully.</term>
		///   </item>
		///   <item>
		///     <term>STG_E_INVALIDPOINTER</term>
		///     <term>pStm is an invalid pointer.</term>
		///   </item>
		///   <item>
		///     <term>CO_E_NOTINITIALIZED</term>
		///     <term>The CoInitialize or OleInitialize function was not called on the current thread before this function was called.</term>
		///   </item>
		///   <item>
		///     <term>CO_E_OBJNOTCONNECTED</term>
		///     <term>
		/// The object application has been disconnected from the remoting system (for example, as a result of a call to the
		/// CoDisconnectObject function).
		/// </term>
		///   </item>
		///   <item>
		///     <term>REGDB_E_CLASSNOTREG</term>
		///     <term>An error occurred reading the registration database.</term>
		///   </item>
		///   <item>
		///     <term>E_NOINTERFACE</term>
		///     <term>The final QueryInterface of this function for the requested interface returned E_NOINTERFACE.</term>
		///   </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		///   <c>Important</c> Security Note: Calling this method with untrusted data is a security risk. Call this method only with trusted
		/// data. For more information, see Untrusted Data Security Risks.
		/// </para>
		/// <para>The <c>CoUnmarshalInterface</c> function performs the following tasks:</para>
		/// <list type="number">
		///   <item>
		///     <term>Reads from the stream the CLSID to be used to create an instance of the proxy.</term>
		///   </item>
		///   <item>
		///     <term>
		/// Gets an IMarshal pointer to the proxy that is to do the unmarshaling. If the object uses COM's default marshaling implementation,
		/// the pointer thus obtained is to an instance of the generic proxy object. If the marshaling is occurring between two threads in
		/// the same process, the pointer is to an instance of the in-process free threaded marshaler. If the object provides its own
		/// marshaling code, <c>CoUnmarshalInterface</c> calls the CoCreateInstance function, passing the CLSID it read from the marshaling
		/// stream. <c>CoCreateInstance</c> creates an instance of the object's proxy and returns an <c>IMarshal</c> interface pointer to the proxy.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// Using whichever IMarshal interface pointer it has acquired, the function then calls IMarshal::UnmarshalInterface and, if
		/// appropriate, IMarshal::ReleaseMarshalData.
		/// </term>
		///   </item>
		/// </list>
		/// <para>
		/// The primary caller of this function is COM itself, from within interface proxies or stubs that unmarshal an interface pointer.
		/// There are, however, some situations in which you might call <c>CoUnmarshalInterface</c>. For example, if you are implementing a
		/// stub, your implementation would call <c>CoUnmarshalInterface</c> when the stub receives an interface pointer as a parameter in a
		/// method call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/combaseapi/nf-combaseapi-counmarshalinterface
		// HRESULT CoUnmarshalInterface( LPSTREAM pStm, REFIID riid, LPVOID *ppv );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("combaseapi.h", MSDNShortId = "d0eac0da-2f41-40c4-b756-31bc22752c17")]
		public static extern HRESULT CoUnmarshalInterface(IStream pStm, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

		/// <summary>Returns a pointer to an implementation of IBindCtx (a bind context object). This object stores information about a particular moniker-binding operation.</summary>
		/// <param name="reserved">This parameter is reserved and must be 0.</param>
		/// <param name="ppbc">Address of an IBindCtx* pointer variable that receives the interface pointer to the new bind context object. When the function is successful, the caller is responsible for calling Release on the bind context. A NULL value for the bind context indicates that an error occurred.</param>
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-createfilemoniker
		// HRESULT CreateFileMoniker( LPCOLESTR lpszPathName, LPMONIKER *ppmk );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/objbase/nf-objbase-getrunningobjecttable
		// HRESULT GetRunningObjectTable( DWORD reserved, LPRUNNINGOBJECTTABLE *pprot );
		[DllImport(Lib.Ole32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("objbase.h", MSDNShortId = "65d9cf7d-cc8a-4199-9a4a-7fd67ef8872d")]
		public static extern HRESULT GetRunningObjectTable([Optional] uint reserved, out IRunningObjectTable pprot);

		/// <summary>The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.</para></summary>
		/// <param name="pwcsName">A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL. If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000:  Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in the transacted mode.</param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader><term>Parameter Values</term><term>Meaning</term></listheader>
		/// <item><term>STGFMT_DOCFILE</term><description>0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is not an integer multiple of the underlying disk's physical sector size, this operation will fail.</description></item>
		/// <item><term>All other values of stgfmt</term><description>Must be 0.</description></item>
		/// </list></param>
		/// <param name="pStgOptions">The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter. The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.</param>
		/// <param name="pSecurityDescriptor">Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:  Value must be NULL.</para></param>
		/// <param name="riid">A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage interface or the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, [In] IntPtr pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The StgCreateStorageEx function creates a new storage object using a provided implementation for the IStorage or IPropertySetStorage interfaces. To open an existing file, use the StgOpenStorageEx function instead.
		/// <para>Applications written for Windows 2000, Windows Server 2003 and Windows XP must use StgCreateStorageEx rather than StgCreateDocfile to take advantage of the enhanced Windows 2000 and Windows XP Structured Storage features.</para></summary>
		/// <param name="pwcsName">A pointer to the path of the file to create. It is passed uninterpreted to the file system. This can be a relative name or NULL. If NULL, a temporary file is allocated with a unique name. If non-NULL, the string size must not exceed MAX_PATH characters.
		/// <para>Windows 2000:  Unlike the CreateFile function, you cannot exceed the MAX_PATH limit by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to use when opening the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion takes place when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in the transacted mode.</param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends on the value of the stgfmt parameter.
		/// <list type="table">
		/// <listheader><term>Parameter Values</term><term>Meaning</term></listheader>
		/// <item><term>STGFMT_DOCFILE</term><description>0, or FILE_FLAG_NO_BUFFERING.For more information, see CreateFile.If the sector size of the file, specified in pStgOptions, is not an integer multiple of the underlying disk's physical sector size, this operation will fail.</description></item>
		/// <item><term>All other values of stgfmt</term><description>Must be 0.</description></item>
		/// </list></param>
		/// <param name="pStgOptions">The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. If the stgfmt parameter is set to STGFMT_DOCFILE, pStgOptions points to the STGOPTIONS structure, which specifies features of the storage object, such as the sector size. This parameter may be NULL, which creates a storage object with a default sector size of 512 bytes. If non-NULL, the ulSectorSize member must be set to either 512 or 4096. If set to 4096, STGM_SIMPLE may not be specified in the grfMode parameter. The usVersion member must be set before calling StgCreateStorageEx. For more information, see STGOPTIONS.</param>
		/// <param name="pSecurityDescriptor">Enables the ACLs to be set when the file is created. If not NULL, needs to be a pointer to the SECURITY_ATTRIBUTES structure. See CreateFile for information on how to set ACLs on files.
		/// <para>Windows Server 2003, Windows 2000 Server, Windows XP and Windows 2000 Professional:  Value must be NULL.</para></param>
		/// <param name="riid">A value that specifies the interface identifier (IID) of the interface pointer to return. This IID may be for the IStorage interface or the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">A pointer to an interface pointer variable that receives a pointer for an interface on the new storage object; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380328")]
		public static extern HRESULT StgCreateStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode,
			STGFMT stgfmt, FileFlagsAndAttributes grfAttrs, in STGOPTIONS pStgOptions, PSECURITY_DESCRIPTOR pSecurityDescriptor, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>The StgIsStorageFile function indicates whether a particular disk file contains a storage object.</summary>
		/// <param name="pwcsName">Pointer to the null-terminated Unicode string name of the disk file to be examined. The pwcsName parameter is passed uninterpreted to the underlying file system.</param>
		/// <returns>
		/// <list>
		/// <item><term>S_OK</term><description>Indicates that the file contains a storage object.</description></item>
		/// <item><term>S_FALSE</term><description>Indicates that the file does not contain a storage object.</description></item>
		/// <item><term>STG_E_FILENOTFOUND</term><description>Indicates that the file was not found.</description></item>
		/// </list>
		/// <para>StgIsStorageFile function can also return any file system errors or system errors wrapped in an HRESULT. See Error Handling Strategies and Handling Unknown Errors</para></returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380334")]
		public static extern HRESULT StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

		/// <summary>The StgOpenStorage function opens an existing root storage object in the file system. Use this function to open compound files. Do not use it to open directories, files, or summary catalogs. Nested storage objects can only be opened using their parent IStorage::OpenStorage method.
		/// <note type="note">Applications should use the new function, StgOpenStorageEx, instead of StgOpenStorage, to take advantage of the enhanced and Windows Structured Storage features. This function, StgOpenStorage, still exists for compatibility with applications running on Windows 2000.</note></summary>
		/// <param name="pwcsName">A pointer to the path of the null-terminated Unicode string file that contains the storage object to open. This parameter is ignored if the pstgPriority parameter is not NULL.</param>
		/// <param name="pstgPriority">A pointer to the IStorage interface that should be NULL. If not NULL, this parameter is used as described below in the Remarks section. After StgOpenStorage returns, the storage object specified in pStgPriority may have been released and should no longer be used.</param>
		/// <param name="grfMode">Specifies the access mode to use to open the storage object.</param>
		/// <param name="snbExclude">If not NULL, pointer to a block of elements in the storage to be excluded as the storage object is opened. The exclusion occurs regardless of whether a snapshot copy happens on the open. Can be NULL.</param>
		/// <param name="reserved">Indicates reserved for future use; must be zero.</param>
		/// <param name="ppstgOpen">A pointer to a IStorage* pointer variable that receives the interface pointer to the opened storage.</param>
		/// <returns>The StgOpenStorage function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380341")]
		public static extern HRESULT StgOpenStorage([MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
			IStorage pstgPriority, STGM grfMode, [In] SNB snbExclude, [Optional] uint reserved, out IStorage ppstgOpen);

		/// <summary>STGs the open storage ex.</summary>
		/// <param name="pwcsName">A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed MAX_PATH characters.
		/// <para>Windows Server 2003 and Windows XP/2000:  Unlike the CreateFile function, the MAX_PATH limit cannot be exceeded by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion occurs when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in transacted mode.
		/// <para>If the storage object is opened in direct mode(STGM_DIRECT) with access to either STGM_WRITE or STGM_READWRITE, the sharing mode must be STGM_SHARE_EXCLUSIVE unless the STGM_DIRECT_SWMR mode is specified.For more information, see the Remarks section.If the storage object is opened in direct mode with access to STGM_READ, the sharing mode must be either STGM_SHARE_EXCLUSIVE or STGM_SHARE_DENY_WRITE, unless STGM_PRIORITY or STGM_DIRECT_SWMR is specified.For more information, see the Remarks section.</para>
		/// <para>The mode in which a file is opened can affect implementation performance.For more information, see Compound File Implementation Limits.</para></param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends upon the value of the stgfmt parameter. STGFMT_DOCFILE must be zero (0) or FILE_FLAG_NO_BUFFERING. For more information about this value, see CreateFile. If the sector size of the file, specified in pStgOptions, is not an integer multiple of the physical sector size of the underlying disk, then this operation will fail. All other values of stgfmt must be zero.</param>
		/// <param name="pStgOptions">A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. The usVersion member must be set before calling StgOpenStorageEx. For more information, see the STGOPTIONS structure.</param>
		/// <param name="reserved2">Reserved; must be zero.</param>
		/// <param name="riid">A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for IID_IStorage to obtain the IStorage interface or for IID_IPropertySetStorage to obtain the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380342")]
		public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt,
			FileFlagsAndAttributes grfAttrs, ref STGOPTIONS pStgOptions, [Optional] IntPtr reserved2, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>STGs the open storage ex.</summary>
		/// <param name="pwcsName">A pointer to the path of the null-terminated Unicode string file that contains the storage object. This string size cannot exceed MAX_PATH characters.
		/// <para>Windows Server 2003 and Windows XP/2000:  Unlike the CreateFile function, the MAX_PATH limit cannot be exceeded by using the "\\?\" prefix.</para></param>
		/// <param name="grfMode">A value that specifies the access mode to open the new storage object. For more information, see STGM Constants. If the caller specifies transacted mode together with STGM_CREATE or STGM_CONVERT, the overwrite or conversion occurs when the commit operation is called for the root storage. If IStorage::Commit is not called for the root storage object, previous contents of the file will be restored. STGM_CREATE and STGM_CONVERT cannot be combined with the STGM_NOSNAPSHOT flag, because a snapshot copy is required when a file is overwritten or converted in transacted mode.
		/// <para>If the storage object is opened in direct mode(STGM_DIRECT) with access to either STGM_WRITE or STGM_READWRITE, the sharing mode must be STGM_SHARE_EXCLUSIVE unless the STGM_DIRECT_SWMR mode is specified.For more information, see the Remarks section.If the storage object is opened in direct mode with access to STGM_READ, the sharing mode must be either STGM_SHARE_EXCLUSIVE or STGM_SHARE_DENY_WRITE, unless STGM_PRIORITY or STGM_DIRECT_SWMR is specified.For more information, see the Remarks section.</para>
		/// <para>The mode in which a file is opened can affect implementation performance.For more information, see Compound File Implementation Limits.</para></param>
		/// <param name="stgfmt">A value that specifies the storage file format. For more information, see the STGFMT enumeration.</param>
		/// <param name="grfAttrs">A value that depends upon the value of the stgfmt parameter. STGFMT_DOCFILE must be zero (0) or FILE_FLAG_NO_BUFFERING. For more information about this value, see CreateFile. If the sector size of the file, specified in pStgOptions, is not an integer multiple of the physical sector size of the underlying disk, then this operation will fail. All other values of stgfmt must be zero.</param>
		/// <param name="pStgOptions">A pointer to an STGOPTIONS structure that contains data about the storage object opened. The pStgOptions parameter is valid only if the stgfmt parameter is set to STGFMT_DOCFILE. The usVersion member must be set before calling StgOpenStorageEx. For more information, see the STGOPTIONS structure.</param>
		/// <param name="reserved2">Reserved; must be zero.</param>
		/// <param name="riid">A value that specifies the GUID of the interface pointer to return. Can also be the header-specified value for IID_IStorage to obtain the IStorage interface or for IID_IPropertySetStorage to obtain the IPropertySetStorage interface.</param>
		/// <param name="ppObjectOpen">The address of an interface pointer variable that receives a pointer for an interface on the storage object opened; contains NULL if operation failed.</param>
		/// <returns>This function can also return any file system errors or system errors wrapped in an HRESULT. For more information, see Error Handling Strategies and Handling Unknown Errors.</returns>
		[DllImport(Lib.Ole32, ExactSpelling = true, SetLastError = false)]
		[PInvokeData("Objbase.h", MSDNShortId = "aa380342")]
		public static extern HRESULT StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt,
			FileFlagsAndAttributes grfAttrs, [Optional] IntPtr pStgOptions, [Optional] IntPtr reserved2, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object ppObjectOpen);

		/// <summary>
		/// The STGOPTIONS structure specifies features of the storage object, such as sector size, in the StgCreateStorageEx and StgOpenStorageEx functions.
		/// </summary>
		[PInvokeData("Objbase.h", MSDNShortId = "aa380344")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STGOPTIONS
		{
			/// <summary>Specifies the version of the STGOPTIONS structure. It is set to STGOPTIONS_VERSION.
			/// <note>When usVersion is set to 1, the ulSectorSize member can be set.This is useful when creating a large-sector documentation file.However, when usVersion is set to 1, the pwcsTemplateFile member cannot be used.</note>
			/// <para>In Windows 2000 and later:  STGOPTIONS_VERSION can be set to 1 for version 1.</para>
			/// <para>In Windows XP and later:  STGOPTIONS_VERSION can be set to 2 for version 2.</para>
			/// <para>For operating systems prior to Windows 2000:  STGOPTIONS_VERSION will be set to 0 for version 0.</para></summary>
			public ushort usVersion;
			/// <summary>Reserved for future use; must be zero.</summary>
			public ushort reserved;
			/// <summary>Specifies the sector size of the storage object. The default is 512 bytes.</summary>
			public uint ulSectorSize;
			/// <summary>Specifies the name of a file whose Encrypted File System (EFS) metadata will be transferred to a newly created Structured Storage file. This member is valid only when STGFMT_DOCFILE is used with StgCreateStorageEx.
			/// <para>In Windows XP and later:  The pwcsTemplateFile member is only valid if version 2 or later is specified in the usVersion member.</para></summary>
			public string pwcsTemplateFile;
		}
	}
}