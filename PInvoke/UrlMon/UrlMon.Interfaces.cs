using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	public static partial class UrlMon
	{
		/// <summary>
		/// Provides methods that enable the client program that is using an asynchronous moniker to control the progress of the bind operation.
		/// </summary>
		/// <remarks>
		/// <para>
		/// An asynchronous moniker calls the client's <c>IBindStatusCallback::OnStartBinding</c> method to provide the client program with
		/// a pointer to the <c>IBinding</c> interface.
		/// </para>
		/// <para>The IID for this interface is .</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775071(v%3Dvs.85)
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("79EAC9C0-BAF9-11CE-8C82-00AA004BA90B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBinding
		{
			/// <summary>Ends the bind operation.</summary>
			/// <remarks>
			/// <para>This method cannot be called from an implementation of the <c>OnStartBinding</c> method.</para>
			/// <para>
			/// After it aborts the bind operation, the client must release any pointers that were obtained during the binding. No
			/// <c>IBindStatusCallback</c> notifications are called, except <c>OnStopBinding</c>.
			/// </para>
			/// <para>The bind operation does not terminate by releasing the last <c>IBinding</c> interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775068(v=vs.85)
			// HRESULT Abort();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Abort();

			/// <summary>Suspends the bind operation.</summary>
			/// <remarks>
			/// This method is not currently implemented by the default asynchronous pluggable protocols provided by Windows Internet Explorer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775074(v=vs.85)
			// HRESULT Suspend();
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Suspend();

			/// <summary>
			/// <para>This method resumes the bind operation.</para>
			/// <para>Parameters</para>
			/// <para>None.</para>
			/// <para>Return Values</para>
			/// <para>Returns S_OK if successful or an error value otherwise.</para>
			/// <para>Remarks</para>
			/// <para>
			/// This method is not currently implemented by the default asynchronous pluggable protocols provided by Microsoft Internet Explorer.
			/// </para>
			/// <para>Requirements</para>
			/// <para><c>OS Versions:</c> Windows CE .NET 4.0 and later. <c>Header:</c> Urlmon.h, Urlmon.idl. <c>Link Library:</c> Urlmon.lib.</para>
			/// <para>Last updated on Saturday, April 10, 2004</para>
			/// <para>© 1992-2003 Microsoft Corporation. All rights reserved.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// This method is not currently implemented by the default asynchronous pluggable protocols provided by Microsoft Internet Explorer.
			/// </para>
			/// <para>Requirements</para>
			/// <para><c>OS Versions:</c> Windows CE .NET 4.0 and later. <c>Header:</c> Urlmon.h, Urlmon.idl. <c>Link Library:</c> Urlmon.lib.</para>
			/// <para>Last updated on Saturday, April 10, 2004</para>
			/// <para>© 1992-2003 Microsoft Corporation. All rights reserved.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms928797(v=msdn.10)
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Resume();

			/// <summary>Sets the priority of the bind operation.</summary>
			/// <param name="nPriority">
			/// A long integer value that contains the priority to set. This can be one of the values used by GetThreadPriority and SetThreadPriority.
			/// </param>
			/// <remarks>
			/// This method is not currently implemented by the default asynchronous pluggable protocols provided by Windows Internet Explorer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775073(v=vs.85)
			// HRESULT SetPriority( long nPriority );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetPriority([In] int nPriority);

			/// <summary>Gets the priority of the bind operation.</summary>
			/// <returns>
			/// The address of a long integer value that receives the current priority of the bind operation. This can be one of the values
			/// used by GetThreadPriority and SetThreadPriority.
			/// </returns>
			/// <remarks>
			/// This method is not currently implemented by the default asynchronous pluggable protocols that are provided by Windows
			/// Internet Explorer.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775070(v=vs.85)
			// HRESULT GetPriority( [out] long *pnPriority );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			int GetPriority();

			/// <summary>Gets the protocol-specific outcome of a bind operation.</summary>
			/// <param name="pclsidProtocol">[out]A pointer to the <c>CLSID</c> variable for the protocol used.</param>
			/// <param name="pdwResult">
			/// [out]A pointer to an unsigned long integer variable that contains the protocol-specific bind result string.
			/// </param>
			/// <param name="pszResult">[out]A pointer to the string variable that contains the protocol-specific bind result.</param>
			/// <param name="dwReserved">[in, out]Reserved. Must be set to 0.</param>
			/// <returns>Returns S_OK if successful, or E_INVALIDARG if one of the parameters is not valid.</returns>
			/// <remarks>
			/// This method typically is called by the client of an asynchronous moniker when the client's <c>OnStopBinding</c> method is called.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775069(v=vs.85)
			// HRESULT GetBindResult( [out] CLSID *pclsidProtocol, [out] DWORD *pdwResult, [out] LPOLESTR *pszResult, [in, out] DWORD
			// *pdwReserved );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void GetBindResult(out Guid pclsidProtocol, out uint pdwResult, [MarshalAs(UnmanagedType.LPWStr)] out string pszResult, [In, Out] ref uint dwReserved);
		}

		/// <summary>Accepts information on an asynchronous bind operation.</summary>
		/// <remarks>
		/// <para>
		/// A client that requests an asynchronous bind operation must provide a notification object, which exposes the
		/// <c>IBindStatusCallback</c> interface. The asynchronous moniker provides information on the bind operation to the client by
		/// calling notification methods on the client's <c>IBindStatusCallback</c> interface. This interface enables the client to pass
		/// additional bind information to the moniker by calling the <c>IBindStatusCallback::GetBindInfo</c> and
		/// <c>IBindStatusCallback::GetPriority</c> methods after receiving a call from IMoniker::BindToObject or IMoniker::BindToStorage.
		/// </para>
		/// <para>Only the last <c>IBindStatusCallback</c> interface that was registered is called.</para>
		/// <para>The IID for this interface is .</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775060%28v%3dvs.85%29
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("79eac9c1-baf9-11ce-8c82-00aa004ba90b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IBindStatusCallback
		{
			/// <summary>
			/// Notifies the client about the callback methods that it is registered to receive. This notification is a response to the
			/// flags the client requested in the <c>RegisterBindStatusCallback</c> function.
			/// </summary>
			/// <param name="dwReserved">Reserved. Must be set to 0.</param>
			/// <param name="pib">
			/// A pointer to the IBinding interface of the current bind operation. This cannot be NULL. The client can call AddRef on this
			/// pointer to keep a reference to the binding object.
			/// </param>
			/// <remarks>
			/// <para>
			/// Typically, asynchronous monikers call this method before the call to the IMoniker::BindToStorage method or the
			/// IMoniker::BindToObject method has returned.
			/// </para>
			/// <para>
			/// In the call to this method, the moniker also provides the client with a pointer to the <c>IBinding</c> interface for the
			/// binding object associated with the current bind operation. The client can use the <c>IBinding</c> interface to control the
			/// progress of the bind operation.
			/// </para>
			/// <para>
			/// To keep a reference to the binding object, the client must store the pointer to the <c>IBinding</c> interface and call
			/// AddRef on it. When the client no longer requires the reference, it must call Release on it. Note that calling Release does
			/// not cancel the bind operation; it frees the reference to the <c>IBinding</c> interface sent in the callback.
			/// </para>
			/// <para>
			/// Client applications that implement the <c>IBindStatusCallback</c> interface can return E_NOTIMPL or S_OK, if they don't want
			/// to receive this notification.
			/// </para>
			/// <para>
			/// The <c>Abort</c> method does not work properly in an implementation of <c>IBindStatusCallback::OnStartBinding</c>. To abort
			/// the binding, <c>IBindStatusCallback::OnStartBinding</c> should return E_FAIL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775065%28v%3dvs.85%29
			// HRESULT OnStartBinding( DWORD dwReserved, IBinding *pib );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnStartBinding([Optional] uint dwReserved, [In, MarshalAs(UnmanagedType.Interface)] IBinding pib);

			/// <summary>Gets the priority for the bind operation when it is called by an asynchronous moniker.</summary>
			/// <returns>
			/// A long integer value that indicates the priority of this bind operation. Priorities can be any of the constants defined for
			/// prioritizing threads. For details, see the Win32 documentation for SetThreadPriority and GetThreadPriority.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The moniker calls this method prior to initiating the bind operation, to get the priority for the bind operation. This
			/// method can be called at any time during the bind operation, if the moniker has to make new priority decisions.
			/// </para>
			/// <para>
			/// The moniker can use pnPriority to set the priority of a thread that is associated with a bind operation. Typically, it
			/// interprets the priority to perform its own scheduling among multiple bind operations. Note that the policy for determining
			/// priority for URL monikers is not yet determined. The moniker must not change the priority of the thread that is used to call
			/// IMoniker::BindToStorage or IMoniker::BindToObject.
			/// </para>
			/// <para>
			/// Applications that implement the <c>IBindStatusCallback</c> interface can return E_UNIMPL or S_OK, if they don't want to
			/// receive this notification.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775059(v=vs.85)
			// HRESULT GetPriority( [out] long *pnPriority );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			int GetPriority();

			/// <summary>This method is not implemented.</summary>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnLowResource([Optional] uint reserved);

			/// <summary>Indicates the progress of the bind operation.</summary>
			/// <param name="ulProgress">
			/// An unsigned long integer that contains the current progress of the bind operation relative to the expected maximum that is
			/// indicated in the ulProgressMax parameter.
			/// </param>
			/// <param name="ulProgressMax">
			/// An unsigned long integer that contains the expected maximum value of the ulProgress parameter for the duration of calls to
			/// IBindStatusCallback::OnProgress for this bind operation. Note that this value might change across calls to this method. A
			/// value of zero means that the maximum value of ulProgress is unknown; for example, in the IMoniker::BindToStorage method when
			/// the data download size is unknown.
			/// </param>
			/// <param name="ulStatusCode">
			/// An unsigned long integer that Additional information regarding the progress of the bind operation. This can be any of the
			/// BINDSTATUS values.
			/// </param>
			/// <param name="szStatusText">
			/// The address of a string value that contains the textual information that indicates the current progress of the bind
			/// operation. The text reflects the BINDSTATUS value of the ulStatusCode parameter and is appropriate for display in the user
			/// interface of the client.
			/// </param>
			/// <remarks>
			/// <para>
			/// The moniker calls this method repeatedly to indicate the current progress of the bind operation, typically, at reasonable
			/// intervals during a lengthy operation.
			/// </para>
			/// <para>
			/// The client can use the progress notification to provide progress information to the user from the ulProgress, ulProgressMax,
			/// and szStatusText parameters, or to make programmatic decisions based on the ulStatusCode parameter.
			/// </para>
			/// <para>
			/// Client applications that implement the <c>IBindStatusCallback</c> interface can return E_NOTIMPL or S_OK, if they don't have
			/// to receive this notification.
			/// </para>
			/// <para>
			/// Windows Internet Explorer 8. If ulStatusCode is set to <c>BINDSTATUS_64BIT_PROGRESS</c>, then szStatusText contains a string
			/// representing the progress of the download as two 64-bit numbers (representing ulProgress and ulProgressMax) separated by a comma.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775064(v=vs.85)
			// HRESULT OnProgress( unsigned long ulProgress, unsigned long ulProgressMax, unsigned long ulStatusCode, // LPCWSTR
			// szStatusText );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnProgress([In] uint ulProgress, [In] uint ulProgressMax, [In] BINDSTATUS ulStatusCode, [In, MarshalAs(UnmanagedType.LPWStr)] string szStatusText);

			/// <summary>This method indicates the end of the bind operation.</summary>
			/// <param name="hresult">Status code returned from the bind operation.</param>
			/// <param name="szError">
			/// Address of a string value that contains the status text. In case of error, this text describes the error. In the current
			/// implementation of URL monikers, this string is empty.
			/// </param>
			/// <remarks>
			/// <para>
			/// This method is always called, whether the bind operation succeeded, failed, or was aborted by a client. At this point the
			/// moniker client can use <c>IBinding::GetBindResult</c> to query for protocol-specific information about the outcome of the
			/// bind operation. When this method has completed, the moniker client must call <c>Release</c> on the <c>IBinding</c> pointer
			/// it received in <c>IBindStatusCallback::OnStartBinding</c>.
			/// </para>
			/// <para>
			/// Because URL monikers work asynchronously, the status code returned by <c>IBindStatusCallback::OnStopBinding</c> and the
			/// status code returned by the binding methods, such as <c>IMoniker::BindToStorage</c> and <c>IMoniker::BindToObject</c>, might differ.
			/// </para>
			/// <para>
			/// Client applications that implement the <c>IBindStatusCallback</c> interface can return E_UNIMPL or S_OK if they are not
			/// interested in receiving this notification.
			/// </para>
			/// </remarks>
			/// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/ms928805(v=msdn.10)
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnStopBinding([In] HRESULT hresult, [In, MarshalAs(UnmanagedType.LPWStr)] string szError);

			/// <summary>Provides information about how the bind operation is handled when it is called by an asynchronous moniker.</summary>
			/// <param name="grfBINDF">
			/// [out]The address of an unsigned integer value that contains a combination of values that are taken from the <c>BINDF</c>
			/// enumeration and indicate how the bind process is handled.
			/// </param>
			/// <param name="pbindinfo">
			/// [in, out]The address of the <c>BINDINFO</c> structure, which describes the client application's requirements for binding.
			/// </param>
			/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters are invalid.</returns>
			/// <remarks>
			/// <para>
			/// The moniker calls this method in its implementations of the IMoniker::BindToObject method and the IMoniker::BindToStorage
			/// method to get information about the specific bind operation.
			/// </para>
			/// <para>
			/// Asynchronous moniker clients should be aware that a moniker might call this method more than one time during a bind
			/// operation. A proper implementation of <c>IBindStatusCallback::GetBindInfo</c> prepares for this possibility. If data is
			/// returned in the pbindinfo parameter, the implementation should allocate the appropriate data (szExtraInfo or stgmedData) at
			/// the time of each call. In this way, if the callback isn't called, data isn't allocated; if the callback is called more than
			/// one time, it works correctly. The first time this callback is received by the asynchronous moniker client is prior to the
			/// call to IMoniker::BindToStorage or IMoniker::BindToObject.
			/// </para>
			/// <para>
			/// Even when the value of grfBindInfoF is BINDF_ASYNCHRONOUS, it is possible that the original call to IMoniker::BindToStorage
			/// or IMoniker::BindToObject might return synchronously, instead of returning the MK_S_ASYNCHRONOUS flag. Clients of
			/// asynchronous monikers should always prepare for this possibility. Specifically, to avoid memory leaks, it is important to
			/// make sure to release the pointer that is returned by a call to either method.
			/// </para>
			/// <para>
			/// One way to deal with this issue is to call your own implementation of <c>IBindStatusCallback::OnDataAvailable</c> or
			/// <c>IBindStatusCallback::OnObjectAvailable</c> to use the same code path (regardless of whether you bind synchronously or asynchronously).
			/// </para>
			/// <para>
			/// If the <c>BINDF_PULLDATA</c> value is not set in the grfBindInfoF parameter, Urlmon.dll sets the <c>BINDF_NEEDFILE</c>
			/// value. If BINDF_NEEDFILE is set, the binding of resources that cannot be cached (such as an HTTPS resource) fail.
			/// </para>
			/// <para>
			/// <c>Warning</c> The size of the <c>BINDINFO</c> structure changed with the release of Microsoft Internet Explorer 4.0.
			/// Developers must write code that checks the size of the <c>BINDINFO</c> structure that is passed into their implementation of
			/// this method before it writes to members of the structure. For more information, see Handling BINDINFO Structures.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775058(v=vs.85)
			// HRESULT GetBindInfo( [out] DWORD *grfBINDF, [in, out] BINDINFO *pbindinfo );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void GetBindInfo(out BINDF grfBINDF, [In, Out] ref BINDINFO pbindinfo);

			/// <summary>Provides data to the client as it becomes available during asynchronous bind operations.</summary>
			/// <param name="grfBSCF">
			/// [in]An unsigned long integer value from the <c>BSCF</c> enumeration that indicates the kind of data available.
			/// </param>
			/// <param name="dwSize">
			/// [in]An unsigned long integer value that contains the size, in bytes, of the total data available from the current bind operation.
			/// </param>
			/// <param name="pFormatetc">
			/// [in]The address of the FORMATETC structure that indicates the format of the available data. This parameter is used when the
			/// bind operation results from the IMoniker::BindToStorage method. If there is no format associated with the available data,
			/// pformatetc might contain CF_NULL. Each different call to <c>IBindStatusCallback::OnDataAvailable</c> can pass in a new value
			/// for this parameter; every call always points to the same data.
			/// </param>
			/// <param name="pStgmed">
			/// [in]The address of the STGMEDIUM structure that contains pointers to the interfaces (such as IStream and IStorage) that can
			/// be used to access the data. In the asynchronous case, client applications might receive a second pointer to the IStream or
			/// IStorage interface from the IMoniker::BindToStorage method. The client application must call Release on the interfaces to
			/// avoid memory leaks.
			/// </param>
			/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters are invalid.</returns>
			/// <remarks>
			/// <para>
			/// During asynchronous IMoniker::BindToStorage bind operations, an asynchronous moniker calls this method to provide data to
			/// the client as it becomes available.
			/// </para>
			/// <para>
			/// Note that the behavior of the storage returned in pstgmed depends on the <c>BINDF</c> flags returned in the
			/// <c>IBindStatusCallback::GetBindInfo</c> method. This storage can be asynchronous or blocking, and the bind operation can
			/// follow a data pull model or a data push model. For <c>BINDF</c> bind operations, it is not possible to seek backward into
			/// data streams that are provided in <c>IBindStatusCallback::OnDataAvailable</c>. On the other hand, for data push model bind
			/// operations, it is possible to seek back into a data stream, and to read any data that has been downloaded for an ongoing
			/// IMoniker::BindToStorage operation.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775061(v=vs.85)
			// HRESULT OnDataAvailable( DWORD grfBSCF, DWORD dwSize, FORMATETC *pformatetc, STGMEDIUM *pstgmed );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnDataAvailable([In] BSCF grfBSCF, [In] uint dwSize, in FORMATETC pFormatetc, in STGMEDIUM pStgmed);

			/// <summary>Passes the requested object interface pointer to the client.</summary>
			/// <param name="riid">[in]The interface identifier of the requested interface.</param>
			/// <param name="punk">
			/// [in]The address of the IUnknown interface on the object that is requested in the call to IMoniker::BindToObject. The client
			/// should call AddRef on this pointer to maintain a reference to the object.
			/// </param>
			/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters are invalid.</returns>
			/// <remarks>
			/// This method is called in response to an IMoniker::BindToObject operation. The method is never called for
			/// IMoniker::BindToStorage operations.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775063(v=vs.85)
			// HRESULT OnObjectAvailable( REFIID riid, IUnknown *punk );
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void OnObjectAvailable(in Guid riid, [In, MarshalAs(UnmanagedType.IUnknown)] object punk);
		}

		/// <summary>Implemented by the client application to create temporary pluggable protocol handlers.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767757(v%3Dvs.85)
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("79eac9e7-baf9-11ce-8c82-00aa004ba90b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInternetSession
		{
			/// <summary>Registers a temporary pluggable namespace handler on the current process.</summary>
			/// <param name="pCF">
			/// A pointer to an IClassFactory interface where an IInternetProtocol object can be created. The object's reference count is increased.
			/// </param>
			/// <param name="rclsid">A reference to the CLSID of the namespace. Passing CLSID_NULL is discouraged.</param>
			/// <param name="pwzProtocol">A string value that contains the protocol to be handled.</param>
			/// <param name="cPatterns">Unused. Set to 0.</param>
			/// <param name="ppwzPatterns">Unused. Set to NULL.</param>
			/// <param name="dwReserved">Reserved. Must be set to 0.</param>
			/// <remarks>
			/// <para>
			/// The <c>IInternetSession::RegisterNameSpace</c> method enables an interface to handle requests for the specified protocol
			/// namespace. A single interface can be registered multiple times for each namespace that it can handle. Because pluggable
			/// protocol handlers are not chained, only the last handler to be registered will be active; therefore, it is better to create
			/// a new namespace, rather than reuse an existing one.
			/// </para>
			/// <para>
			/// This method registers a pluggable namespace handler only on the current process; no other processes are affected by this
			/// method. An application can register a pluggable namespace handler for a particular period of time. When finished, it should
			/// call <c>IInternetSession::UnregisterNameSpace</c> to remove the registration.
			/// </para>
			/// <para>
			/// <c>Note</c> Registering namespace handlers for HTTP and HTTPS protocols is not recommended. Doing so within the Internet
			/// Explorer process incurs a performance penalty when browsing.
			/// </para>
			/// <para>
			/// The ppwzPatterns and cPatterns parameters are unused; the registered pluggable namespace handler is called for all protocol requests.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767759%28v%3dvs.85%29
			// HRESULT retVal = object.RegisterNameSpace(pCF, rclsid, pwzProtocol, cPatterns, ppwzPatterns, dwReserved);
			void RegisterNameSpace(IClassFactory pCF, in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string pwzProtocol, [Optional] uint cPatterns, [Optional, MarshalAs(UnmanagedType.LPWStr)] string ppwzPatterns, [Optional] uint dwReserved);

			/// <summary>Unregisters a temporary pluggable namespace handler.</summary>
			/// <param name="pCF">The address of the IClassFactory interface that created the handler.</param>
			/// <param name="pszProtocol">The address of a string value that contains the protocol that was handled.</param>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767763(v=vs.85)
			// HRESULT retVal = object.UnregisterNameSpace(pCF, pszProtocol);
			void UnregisterNameSpace(IClassFactory pCF, [MarshalAs(UnmanagedType.LPWStr)] string pszProtocol);

			/// <summary>Registers a temporary pluggable MIME filter on the current process.</summary>
			/// <param name="pCF">The address of an IClassFactory interface where an IInternetProtocol object can be created.</param>
			/// <param name="rclsid">A reference to the CLSID of the MIME handler.</param>
			/// <param name="pwzType">A string value that contains the MIME to register.</param>
			/// <remarks>
			/// <para>
			/// This method registers a pluggable MIME filter only on the current process. No other processes are affected by this method.
			/// </para>
			/// <para>
			/// An application can register a pluggable MIME filter for a particular period of time so that it can handle requests for some
			/// MIMEs by calling <c>IInternetSession::RegisterMimeFilter</c>. This method can be called multiple times by using the same
			/// interface to register the different MIME types it can handle.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767758(v=vs.85)
			// HRESULT retVal = object.RegisterMimeFilter(pCF, rclsid, pwzType);
			void RegisterMimeFilter(IClassFactory pCF, in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string pwzType);

			/// <summary>Unregisters a temporary pluggable MIME filter.</summary>
			/// <param name="pCF">The address of the IClassFactory interface that created the filter.</param>
			/// <param name="pwzType">A string value that indicates the MIME that the filter was handling.</param>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767762(v=vs.85)
			// HRESULT retVal = object.UnregisterMimeFilter(pCF, pwzType);
			void UnregisterMimeFilter(IClassFactory pCF, [MarshalAs(UnmanagedType.LPWStr)] string pwzType);

			/// <summary>This method is not implemented.</summary>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767754(v=vs.85)
			void CreateBinding(IntPtr pBC, [MarshalAs(UnmanagedType.LPWStr)] string szUrl, [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [MarshalAs(UnmanagedType.IUnknown)] out object ppUnk, [MarshalAs(UnmanagedType.IUnknown)] out object ppOInetProt, uint dwOption);

			/// <summary>This method is not implemented.</summary>
			void SetSessionOption(uint dwOption, IntPtr pBuffer, uint dwBufferLength, uint dwReserved);

			/// <summary>This method is not implemented.</summary>
			void GetSessionOption(uint dwOption, IntPtr pBuffer, ref uint pdwBufferLength, uint dwReserved);
		}

		/// <summary>
		/// Exposes methods and properties used to parse and build Uniform Resource Identifiers (URIs) in Windows Internet Explorer 7.
		/// </summary>
		/// <remarks>
		/// Once an <c>IUri</c> has been created, it cannot change its properties. Property values do not change between calls to the same object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775038(v=vs.85)?redirectedfrom=MSDN
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("A39EE748-6A27-4817-A6F2-13914BEF5890"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IUri
		{
			/// <summary>Returns the specified Uniform Resource Identifier (URI) property value in a new <c>BSTR</c>.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pbstrProperty">
			/// <para>[out]</para>
			/// <para>Address of a <c>BSTR</c> that receives the property value.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyBSTR</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>
			/// The pbstrProperty parameter will be set to a new <c>BSTR</c> containing the value of the specified string property. The
			/// caller should use SysFreeString to free the string.
			/// </para>
			/// <para>This method will return and set pbstrProperty to an empty string if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775026(v=vs.85)
			// HRESULT GetPropertyBSTR( Uri_PROPERTY uriProp, [out] BSTR *pbstrProperty, DWORD dwFlags );
			void GetPropertyBSTR([In] Uri_PROPERTY uriProp, [MarshalAs(UnmanagedType.BStr)] out string pbstrProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>
			/// Returns the string length of the specified Uniform Resource Identifier (URI) property. Call this function if you want the
			/// length but don't necessarily want to create a new <c>BSTR</c>.
			/// </summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pcchProperty">
			/// <para>[out]</para>
			/// <para>
			/// Address of a <c>DWORD</c> that is set to the length of the value of the string property excluding the <c>NULL</c> terminator.
			/// </para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyLength</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>This method will return and set pcchProperty to if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775028(v=vs.85)
			// HRESULT GetPropertyLength( Uri_PROPERTY uriProp, [out] DWORD *pcchProperty, DWORD dwFlags );
			void GetPropertyLength([In] Uri_PROPERTY uriProp, out uint pcchProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>Returns the specified numeric Uniform Resource Identifier (URI) property value.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pdwProperty">Address of a DWORD that is set to the value of the specified property.</param>
			/// <param name="dwFlags">Property-specific flags. Must be set to 0.</param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyDWORD</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a numeric property. This method will fail if the specified property isn't a <c>DWORD</c> property.
			/// </para>
			/// <para>This method will return and set pdwProperty to if the specified property doesn't exist in the URI.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775027(v=vs.85)
			// HRESULT GetPropertyDWORD( Uri_PROPERTY uriProp, [out] DWORD *pdwProperty, DWORD dwFlags );
			void GetPropertyDWORD([In] Uri_PROPERTY uriProp, out uint pdwProperty, [In] uint dwFlags);

			/// <summary>Determines if the specified property exists in the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a BOOL value. Set to TRUE if the specified property exists in the URI.</returns>
			/// <remarks><c>IUri::HasProperty</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775036(v=vs.85)
			// HRESULT HasProperty( Uri_PROPERTY uriProp, [out] BOOL *pfHasProperty );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool HasProperty([In] Uri_PROPERTY uriProp);

			/// <summary>Returns the entire canonicalized Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAbsoluteUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c> property.
			/// </para>
			/// <para>This property is not defined for relative URIs.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775013%28v%3dvs.85%29
			// HRESULT GetAbsoluteUri( [out] BSTR *pbstrAbsoluteUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetAbsoluteUri();

			/// <summary>Returns the user name, password, domain, and port.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAuthority</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_AUTHORITY</c> property.
			/// </para>
			/// <para>
			/// If user name and password are not specified, the separator characters (: and @) are removed. The trailing colon is also
			/// removed if the port number is not specified or is the default for the protocol scheme.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775014(v=vs.85)
			// HRESULT GetAuthority( [out] BSTR *pbstrAuthority );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetAuthority();

			/// <summary>Returns a Uniform Resource Identifier (URI) that can be used for display purposes.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDisplayUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The display URI combines protocol scheme, fully qualified domain name, port number (if not the default for the scheme), full
			/// resource path, query string, and fragment.
			/// </para>
			/// <para>
			/// <c>Note</c> The display URI may have additional formatting applied to it, such that the string produced by
			/// <c>IUri::GetDisplayUri</c> isn't necessarily a valid URI. For this reason, and since the userinfo is not present, the
			/// display URI should be used for viewing only; it should not be used for edit by the user, or as a form of transfer for URIs
			/// inside or between applications.
			/// </para>
			/// <para>
			/// If the scheme is known (for example, http, ftp, or file) then the display URI will hide credentials. However, if the URI
			/// uses an unknown scheme and supplies user name and password, the display URI will also contain the user name and password.
			/// </para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_DISPLAY_URI</c> property and no flags.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775015(v=vs.85)
			// HRESULT GetDisplayUri( [out] BSTR *pbstrDisplayString );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetDisplayUri();

			/// <summary>Returns the domain name (including top-level domain) only.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDomain</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_DOMAIN</c> property.
			/// </para>
			/// <para>
			/// If the URL contains only a plain hostname (for example, "http://example/") or a public suffix (for example,
			/// "http://co.uk/"), then <c>IUri::GetDomain</c> returns <c>NULL</c>. Use <c>IUri::GetHost</c> instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775016(v=vs.85)
			// HRESULT GetDomain( [out] BSTR *pbstrDomain );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetDomain();

			/// <summary>Returns the file name extension of the resource.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetExtension</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_EXTENSION</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775017(v=vs.85)
			// HRESULT GetExtension( [out] BSTR *pbstrExtension );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetExtension();

			/// <summary>Returns the text following a fragment marker (#), including the fragment marker itself.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_FRAGMENT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775018(v=vs.85)
			// HRESULT GetFragment( [out] BSTR *pbstrFragment );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetFragment();

			/// <summary>Returns the fully qualified domain name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_HOST</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775019(v=vs.85)
			// HRESULT GetHost( [out] BSTR *pbstrHost );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetHost();

			/// <summary>Returns the password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PASSWORD</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775021(v=vs.85)
			// HRESULT GetPassword( [out] BSTR *pbstrPassword );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPassword();

			/// <summary>Returns the path and resource name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_PATH</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775022(v=vs.85)
			// HRESULT GetPath( [out] BSTR *pbstrPath );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPath();

			/// <summary>Returns the path, resource name, and query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPathAndQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PATH_AND_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775023(v=vs.85)
			// HRESULT GetPathAndQuery( [out] BSTR *pbstrPathAndQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPathAndQuery();

			/// <summary>Returns the query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775029(v=vs.85)
			// HRESULT GetQuery( [out] BSTR *pbstrQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetQuery();

			/// <summary>Returns the entire original Uniform Resource Identifier (URI) input string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetRawUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_RAW_URI</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775030(v=vs.85)
			// HRESULT GetRawUri( [out] BSTR *pbstrRawUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetRawUri();

			/// <summary>Returns the protocol scheme name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_SCHEME_NAME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775032(v=vs.85)
			// HRESULT GetSchemeName( [out] BSTR *pbstrSchemeName );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetSchemeName();

			/// <summary>Returns the user name and password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetUserInfo</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_INFO</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775033(v=vs.85)
			// HRESULT GetUserInfo( [out] BSTR *pbstrUserInfo );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetUserInfo();

			/// <summary>Returns the user name as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_NAME</c> property.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775034(v=vs.85)
			// HRESULT GetUserName( [out] BSTR *pbstrUserName );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetUserName();

			/// <summary>Returns a value from the <c>Uri_HOST_TYPE</c> enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the Uri_HOST_TYPE enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHostType</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_HOST_TYPE</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775020(v=vs.85)
			// HRESULT GetHostType( [out] DWORD *pdwHostType );
			Uri_HOST_TYPE GetHostType();

			/// <summary>Returns the port number.</summary>
			/// <returns>Address of a DWORD that receives the port number value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPort</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the <c>Uri_PROPERTY_PORT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775024(v=vs.85)
			// HRESULT GetPort( [out] DWORD *pdwPort );
			uint GetPort();

			/// <summary>Returns a value from the URL_SCHEME enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the URL_SCHEME enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetScheme</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_SCHEME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775031(v=vs.85)
			// HRESULT GetScheme( [out] DWORD *pdwScheme );
			URL_SCHEME GetScheme();

			/// <summary>This method is not implemented.</summary>
			/// <returns/>
			URLZONE GetZone();

			/// <summary>Returns a bitmap of flags that indicate which Uniform Resource Identifier (URI) properties have been set.</summary>
			/// <returns>
			/// <para>[out]</para>
			/// <para>Address of a <c>DWORD</c> that receives a combination of the following flags:</para>
			/// <para><c>Uri_HAS_ABSOLUTE_URI</c> (0x00000000)</para>
			/// <para><c>Uri_PROPERTY_ABSOLUTE_URI</c> exists.</para>
			/// <para><c>Uri_HAS_AUTHORITY</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_AUTHORITY</c> exists.</para>
			/// <para><c>Uri_HAS_DISPLAY_URI</c> (0x00000002)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c> exists.</para>
			/// <para><c>Uri_HAS_DOMAIN</c> (0x00000004)</para>
			/// <para><c>Uri_PROPERTY_DOMAIN</c> exists.</para>
			/// <para><c>Uri_HAS_EXTENSION</c> (0x00000008)</para>
			/// <para><c>Uri_PROPERTY_EXTENSION</c> exists.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para><c>Uri_PROPERTY_FRAGMENT</c> exists.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para><c>Uri_PROPERTY_HOST</c> exists.</para>
			/// <para><c>Uri_HAS_HOST_TYPE</c> (0x00004000)</para>
			/// <para><c>Uri_PROPERTY_HOST_TYPE</c> exists.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para><c>Uri_PROPERTY_PASSWORD</c> exists.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para><c>Uri_PROPERTY_PATH</c> exists.</para>
			/// <para><c>Uri_HAS_PATH_AND_QUERY</c> (0x00001000)</para>
			/// <para><c>Uri_PROPERTY_PATH_AND_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_PORT</c> (0x00008000)</para>
			/// <para><c>Uri_PROPERTY_PORT</c> exists.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para><c>Uri_PROPERTY_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_RAW_URI</c> (0x00000200)</para>
			/// <para><c>Uri_PROPERTY_RAW_URI</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME</c> (0x00010000)</para>
			/// <para><c>Uri_PROPERTY_SCHEME</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME_NAME</c> (0x00000400)</para>
			/// <para><c>Uri_PROPERTY_SCHEME_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para><c>Uri_PROPERTY_USER_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_INFO</c> (0x00002000)</para>
			/// <para><c>Uri_PROPERTY_USER_INFO</c> exists.</para>
			/// <para><c>Uri_HAS_ZONE</c> (0x00020000)</para>
			/// <para><c>Uri_PROPERTY_ZONE</c> exists.</para>
			/// </returns>
			/// <remarks><c>IUri::GetProperties</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775025(v=vs.85)
			// HRESULT GetProperties( [out] LPDWORD pdwFlags );
			Uri_HAS GetProperties();

			/// <summary>Compares the logical content of two <c>IUri</c> objects.</summary>
			/// <returns>Address of a BOOL that is set to TRUE if the logical content of pUri is the same.</returns>
			/// <remarks>
			/// <para><c>IUri::IsEqual</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The comparison is case-insensitive. Comparing an <c>IUri</c> to itself will always return <c>TRUE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775037(v=vs.85)
			// HRESULT IsEqual( IUri *pUri, [out] BOOL *pfEqual );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsEqual([In] IUri pUri);
		}

		/// <summary>Exposes methods used to create a new <c>IUri</c> from an existing one.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775002(v=vs.85)
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("4221B2E1-8955-46c0-BD5B-DE9897565DE7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IUriBuilder
		{
			/// <summary>Returns a new <c>IUri</c> object based on modifications to the original <c>IUri</c>, using the original flags.</summary>
			/// <param name="dwAllowEncodingPropertyMask">
			/// <para>[in]</para>
			/// <para>
			/// <c>DWORD</c> that may contain a combination of the following flags, or zero. Reserved characters in these properties may be
			/// percent encoded, if required.
			/// </para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_USER_NAME</c>.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_PASSWORD</c>.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_HOST</c>.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_PATH</c>.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_QUERY</c>.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_FRAGMENT</c>.</para>
			/// </param>
			/// <param name="dwReserved">
			/// <para>[in]</para>
			/// <para>Reserved. Must be set to 0.</para>
			/// </param>
			/// <returns>
			/// <para>[out]</para>
			/// <para>Address of pointer variable of type <c>IUri</c> that receives the new object.</para>
			/// </returns>
			/// <remarks>
			/// <para><c>CreateUriSimple</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// If no changes are made, this method may return a pointer to the original <c>IUri</c> object (after incrementing the
			/// reference count).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774988(v=vs.85)
			// HRESULT CreateUriSimple( [in] DWORD dwAllowEncodingPropertyMask, [in] DWORD_PTR dwReserved, [out] IUri **ppIUri );
			IUri CreateUriSimple(Uri_HAS dwAllowEncodingPropertyMask, IntPtr dwReserved = default);

			/// <summary>Returns a new <c>IUri</c> object based on modifications to the original <c>IUri</c>.</summary>
			/// <param name="dwCreateFlags">
			/// [in] <c>DWORD</c> that combines flags, which control the creation of the <c>IUri</c> object. Refer to the <c>CreateUri</c>
			/// function for a description of these flags. Pass the value of to use the same flags as were specified when the original
			/// <c>IUri</c> object was created.
			/// </param>
			/// <param name="dwAllowEncodingPropertyMask">[in]Reserved. Must be set to 0.</param>
			/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
			/// <returns>[out]Address of pointer variable of type <c>IUri</c> that receives the new object.</returns>
			/// <remarks>
			/// <para><c>CreateUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// If no changes are made, this method may return a pointer to the original <c>IUri</c> object (after incrementing the
			/// reference count).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774987(v=vs.85)
			// HRESULT CreateUri( [in] DWORD dwCreateFlags, [in] DWORD dwAllowEncodingPropertyMask, [in] DWORD_PTR dwReserved, [out] IUri
			// **ppIUri );
			IUri CreateUri(Uri_CREATE dwCreateFlags, uint dwAllowEncodingPropertyMask = 0, IntPtr dwReserved = default);

			/// <summary>Returns a new <c>IUri</c> object based on modifications to the original <c>IUri</c>.</summary>
			/// <param name="dwCreateFlags">
			/// <para>[in]</para>
			/// <para>
			/// <c>DWORD</c> that combines flags, which control the creation of the <c>IUri</c> object. Refer to the <c>CreateUri</c>
			/// function for a description of these flags.
			/// </para>
			/// </param>
			/// <param name="dwUriBuilderFlags">
			/// <para>[in]</para>
			/// <para><c>DWORD</c> for flags specific to <c>IUriBuilder</c>, or zero.</para>
			/// <para><c>UriBuilder_USE_ORIGINAL_FLAGS</c> (0x00000001)</para>
			/// <para>Use the create flags from the original <c>IUri</c>, if they are available.</para>
			/// </param>
			/// <param name="dwAllowEncodingPropertyMask">
			/// <para>[in]</para>
			/// <para>
			/// <c>DWORD</c> that may contain a combination of the following flags, or zero. Reserved characters in the specified properties
			/// may be percent encoded, if required.
			/// </para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_USER_NAME</c>.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_PASSWORD</c>.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_HOST</c>.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_PATH</c>.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_QUERY</c>.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para>Allow encoding of <c>Uri_PROPERTY_FRAGMENT</c>.</para>
			/// </param>
			/// <param name="dwReserved">
			/// <para>[in]</para>
			/// <para>Reserved. Must be set to 0.</para>
			/// </param>
			/// <returns>
			/// <para>[out]</para>
			/// <para>Address of pointer variable of type <c>IUri</c> that receives the new object.</para>
			/// </returns>
			/// <remarks>
			/// <para><c>CreateUriWithFlags</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// If no changes are made, this method may return a pointer to the original <c>IUri</c> object (after incrementing the
			/// reference count).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774989(v=vs.85)
			// HRESULT CreateUriWithFlags( [in] DWORD dwCreateFlags, [in] DWORD dwUriBuilderFlags, [in] DWORD dwAllowEncodingPropertyMask,
			// [in] DWORD_PTR dwReserved, [out] IUri **ppIUri );
			IUri CreateUriWithFlags(Uri_CREATE dwCreateFlags, uint dwUriBuilderFlags, Uri_HAS dwAllowEncodingPropertyMask, IntPtr dwReserved = default);

			/// <summary>Returns the original <c>IUri</c>.</summary>
			/// <returns>
			/// Address to a pointer variable that receives the original IUri. The calling context must Release the interface when it is no
			/// longer needed.
			/// </returns>
			/// <remarks><c>GetIUri</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774992(v=vs.85)
			// HRESULT GetIUri( [out] IUri **ppIUri );
			IUri GetIUri();

			/// <summary>Sets the current <c>IUri</c>.</summary>
			/// <param name="pIUri">Pointer to an existing IUri interface.</param>
			/// <remarks>
			/// <para><c>SetIUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the current <c>IUri</c> invalidates all properties.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775006(v=vs.85)
			// HRESULT SetIUri( [in] IUri *pIUri );
			void SetIUri([In] IUri pIUri);

			/// <summary>Retrieves the value of the fragment component.</summary>
			/// <param name="pcchFragment">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzFragment.
			/// </param>
			/// <param name="ppwzFragment">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774990(v=vs.85)
			// HRESULT GetFragment( [out] DWORD *pcchFragment, [out] LPCWSTR *ppwzFragment );
			void GetFragment(out uint pcchFragment, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzFragment);

			/// <summary>Retrieves the value of the host component.</summary>
			/// <param name="pcchHost">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzHost.
			/// </param>
			/// <param name="ppwzHost">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774991(v=vs.85)
			// HRESULT GetHost( [out] DWORD *pcchHost, [out] LPCWSTR *ppwzHost );
			void GetHost(out uint pcchHost, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzHost);

			/// <summary>Retrieves the value of the password component.</summary>
			/// <param name="pcchPassword">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzPassword.
			/// </param>
			/// <param name="ppwzPassword">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774993(v=vs.85)
			// HRESULT GetPassword( [out] DWORD *pcchPassword, [out] LPCWSTR *ppwzPassword );
			void GetPassword(out uint pcchPassword, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzPassword);

			/// <summary>Retrieves the value of the path component.</summary>
			/// <param name="pcchPath">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzPath.
			/// </param>
			/// <param name="ppwzPath">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774994(v=vs.85)
			// HRESULT GetPath( [out] DWORD *pcchPath, [out] LPCWSTR *ppwzPath );
			void GetPath(out uint pcchPath, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzPath);

			/// <summary>Retrieves the value of the port component.</summary>
			/// <param name="pfHasPort">
			/// [out]Address of a variable of type <c>BOOL</c> that receives <c>TRUE</c> if the port property has been set, or <c>FALSE</c> otherwise.
			/// </param>
			/// <param name="pdwPort">[out]Address of a variable of type <c>DWORD</c> that receives the current value.</param>
			/// <remarks><c>GetPort</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774995(v=vs.85)
			// HRESULT GetPort( [out] BOOL *pfHasPort, [out] DWORD *pdwPort );
			void GetPort([MarshalAs(UnmanagedType.Bool)] out bool pfHasPort, out uint pdwPort);

			/// <summary>Retrieves the value of the query component.</summary>
			/// <param name="pcchQuery">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzQuery.
			/// </param>
			/// <param name="ppwzQuery">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774996(v=vs.85)
			// HRESULT GetQuery( [out] DWORD *pcchQuery, [out] LPCWSTR *ppwzQuery );
			void GetQuery(out uint pcchQuery, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzQuery);

			/// <summary>Retrieves the value of the protocol scheme name.</summary>
			/// <param name="pcchSchemeName">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzSchemeName.
			/// </param>
			/// <param name="ppwzSchemeName">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774997(v=vs.85)
			// HRESULT GetSchemeName( [out] DWORD *pcchSchemeName, [out] LPCWSTR *ppwzSchemeName );
			void GetSchemeName(out uint pcchSchemeName, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzSchemeName);

			/// <summary>Retrieves the value of the username component.</summary>
			/// <param name="pcchUserName">
			/// [out]Address of a variable of type <c>DWORD</c> that receives the length of the string returned in ppwzUserName.
			/// </param>
			/// <param name="ppwzUserName">[out]Address of a string variable that receives the current value.</param>
			/// <remarks>
			/// <para><c>GetUserName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The calling context must not free the returned pointer.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774998(v=vs.85)
			// HRESULT GetUserName( [out] DWORD *pcchUserName, [out] LPCWSTR *ppwzUserName );
			void GetUserName(out uint pcchUserName, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzUserName);

			/// <summary>Sets the fragment component.</summary>
			/// <param name="pwzNewValue">String variable that contains the new value, or NULL to remove the fragment component.</param>
			/// <remarks>
			/// <para><c>SetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the fragment component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c> and <c>Uri_PROPERTY_DISPLAY_URI</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775004(v=vs.85)
			// HRESULT SetFragment( [in] LPCWSTR pwzNewValue );
			void SetFragment([Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the host (fully qualify domain) component.</summary>
			/// <param name="pwzNewValue">String variable that contains the new value. Must be neither empty nor NULL.</param>
			/// <remarks>
			/// <para><c>SetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the host component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_AUTHORITY</c>, and <c>Uri_PROPERTY_DOMAIN</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775005(v=vs.85)
			// HRESULT SetHost( [in] LPCWSTR pwzNewValue );
			void SetHost([MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the password component.</summary>
			/// <param name="pwzNewValue">String variable the contains the new value, or NULL to remove the password component.</param>
			/// <remarks>
			/// <para><c>SetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the password component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c> and <c>Uri_PROPERTY_AUTHORITY</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775007(v=vs.85)
			// HRESULT SetPassword( [in] LPCWSTR pwzNewValue );
			void SetPassword([Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the path component.</summary>
			/// <param name="pwzNewValue">
			/// String variable that contains the new value, or NULL to remove the path component. Must specify an absolute path if not NULL.
			/// </param>
			/// <remarks>
			/// <para><c>SetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The path component also includes the resource (filename and extension).</para>
			/// <para>To specify a relative path, use <c>CoInternetCombineIUri</c>.</para>
			/// <para>Setting the path component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DISPLAY_URI</c>, and <c>Uri_PROPERTY_PATH_AND_QUERY</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775008(v=vs.85)
			// HRESULT SetPath( [in] LPCWSTR pwzNewValue );
			void SetPath([Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the port component.</summary>
			/// <param name="fHasPort">
			/// [in] <c>BOOL</c> that contains <c>TRUE</c> if a new port number is specified, or <c>FALSE</c> to use the default port for
			/// the protocol scheme.
			/// </param>
			/// <param name="dwNewValue">[in] <c>DWORD</c> that contains the new port value.</param>
			/// <remarks>
			/// <para><c>SetPort</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the port number invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DISPLAY_URI</c>, and <c>Uri_PROPERTY_AUTHORITY</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775009(v=vs.85)
			// HRESULT SetPort( [in] BOOL fHasPort, [in] DWORD dwNewValue );
			void SetPort([MarshalAs(UnmanagedType.Bool)] bool fHasPort, uint dwNewValue);

			/// <summary>Sets the query component.</summary>
			/// <param name="pwzNewValue">String variable that contains the new value, or NULL to remove the query component.</param>
			/// <remarks>
			/// <para><c>SetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the query component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DISPLAY_URI</c>, and <c>Uri_PROPERTY_PATH_AND_QUERY</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775010(v=vs.85)
			// HRESULT SetQuery( [in] LPCWSTR pwzNewValue );
			void SetQuery([Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the protocol scheme name.</summary>
			/// <param name="pwzNewValue">String variable that contains the new value. Must be neither empty nor NULL.</param>
			/// <remarks>
			/// <para><c>SetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the scheme name component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c> and <c>Uri_PROPERTY_DISPLAY_URI</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775011(v=vs.85)
			// HRESULT SetSchemeName( [in] LPCWSTR pwzNewValue );
			void SetSchemeName([MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Sets the username component.</summary>
			/// <param name="pwzNewValue">String variable that contains the new value, or NULL to remove the username component.</param>
			/// <remarks>
			/// <para><c>SetUserName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>Setting the username component invalidates <c>Uri_PROPERTY_ABSOLUTE_URI</c> and <c>Uri_PROPERTY_AUTHORITY</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775012(v=vs.85)
			// HRESULT SetUserName( [in] LPCWSTR pwzNewValue );
			void SetUserName([Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzNewValue);

			/// <summary>Removes the specified properties as well as any derived properties.</summary>
			/// <param name="dwPropertyMask">
			/// <para>[in]</para>
			/// <para><c>DWORD</c> that contains a combination of the following flags:</para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para>Remove <c>Uri_PROPERTY_USER_NAME</c>.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para>Remove <c>Uri_PROPERTY_PASSWORD</c>.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para>Remove <c>Uri_PROPERTY_HOST</c>.</para>
			/// <para><c>Uri_HAS_PORT</c> (0x00008000)</para>
			/// <para>Remove <c>Uri_PROPERTY_PORT</c>.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para>Remove <c>Uri_PROPERTY_PATH</c>.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para>Remove <c>Uri_PROPERTY_QUERY</c>.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para>Remove <c>Uri_PROPERTY_FRAGMENT</c>.</para>
			/// </param>
			/// <remarks>
			/// <para><c>RemoveProperties</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// Compound properties (such as <c>Uri_PROPERTY_AUTHORITY</c>, <c>Uri_PROPERTY_USER_INFO</c>, and
			/// <c>Uri_PROPERTY_PATH_AND_QUERY</c>) and sub-properties (such as <c>Uri_PROPERTY_DOMAIN</c> and
			/// <c>Uri_PROPERTY_EXTENSION</c>) are also removed when their associated property primitives are removed.
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c> and <c>Uri_PROPERTY_DISPLAY_URI</c> are also invalidated when subcomponents are modified.
			/// </para>
			/// <para>
			/// <c>Uri_PROPERTY_SCHEME</c> and <c>Uri_PROPERTY_SCHEME_NAME</c> cannot be removed. Use <c>SetSchemeName</c> to modify the
			/// scheme component.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775003(v=vs.85)
			// HRESULT RemoveProperties( [in] DWORD dwPropertyMask );
			void RemoveProperties(Uri_HAS dwPropertyMask);

			/// <summary>Returns <c>TRUE</c> if component values have been modified.</summary>
			/// <returns>A variable of type BOOL that receives TRUE if components have been modified, or FALSE otherwise.</returns>
			/// <remarks><c>HasBeenModified</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775001(v=vs.85)
			// HRESULT HasBeenModified( [out] BOOL *pfModified );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool HasBeenModified();
		}

		/*
		IAuthenticate
		IAuthenticateEx
		IBindHost
		IBinding
		IBindProtocol
		IBindStatusCallback
		IBindStatusCallbackEx
		ICatalogFileInfo
		ICodeInstall
		IHttpNegotiate
		IHttpNegotiate2
		IHttpNegotiate3
		IHttpSecurity
		IMonikerProp
		IPersistMoniker
		ISoftDistExt
		IUri
		IUriBuilderFactory
		IUriContainer
		IWindowForBindingUI
		IWinInetCacheAccess
		IWinInetCacheHints
		IWinInetCacheHints2
		IWinInetFileStream
		IWinInetHttpInfo
		IWinInetInfo
		*/
	}
}