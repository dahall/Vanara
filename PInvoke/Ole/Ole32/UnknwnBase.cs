using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>Enables a class of objects to be created.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/unknwnbase/nn-unknwnbase-iclassfactory
		[PInvokeData("unknwnbase.h", MSDNShortId = "f624f833-2b69-43bc-92cd-c4ecbe6051c5")]
		[ComImport, Guid("00000001-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IClassFactory
		{
			/// <summary>Creates an uninitialized object.</summary>
			/// <param name="pUnkOuter">
			/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the
			/// aggregate. Otherwise, this parameter must be <c>NULL</c>.
			/// </param>
			/// <param name="riid">
			/// A reference to the identifier of the interface to be used to communicate with the newly created object. If pUnkOuter is
			/// <c>NULL</c>, this parameter is generally the IID of the initializing interface; if pUnkOuter is non- <c>NULL</c>, riid must
			/// be IID_IUnknown.
			/// </param>
			/// <param name="ppvObject">
			/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObject
			/// contains the requested interface pointer. If the object does not support the interface specified in riid, the implementation
			/// must set *ppvObject to <c>NULL</c>.
			/// </param>
			/// <param name="LockServer">The lock server.</param>
			/// <param name="">The .</param>
			/// <param name="fLock">The f lock.</param>
			/// <returns>
			/// <para>
			/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The specified object was created.</term>
			/// </item>
			/// <item>
			/// <term>CLASS_E_NOAGGREGATION</term>
			/// <term>The pUnkOuter parameter was non-NULL and the object does not support aggregation.</term>
			/// </item>
			/// <item>
			/// <term>E_NOINTERFACE</term>
			/// <term>The object that ppvObject points to does not support the interface identified by riid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A COM server's implementation of <c>CreateInstance</c> must return a reference to an object contained in an apartment that
			/// belongs to the server's DCOM resolver. It must not return a reference to an object that is contained in a remote apartment.
			/// </para>
			/// <para>
			/// The IClassFactory interface is always on a class object. The <c>CreateInstance</c> method creates an uninitialized object of
			/// the class identified with the specified CLSID. When an object is created in this way, the CLSID must be registered in the
			/// system registry with the CoRegisterClassObject function.
			/// </para>
			/// <para>
			/// The pUnkOuter parameter indicates whether the object is being created as part of an aggregate. Object definitions are not
			/// required to support aggregation â€” they must be specifically designed and implemented to support it.
			/// </para>
			/// <para>
			/// The riid parameter specifies the IID (interface identifier) of the interface through which you will communicate with the new
			/// object. If pUnkOuter is non- <c>NULL</c> (indicating aggregation), the value of the riid parameter must be IID_IUnknown. If
			/// the object is not part of an aggregate, riid often specifies the interface though which the object will be initialized.
			/// </para>
			/// <para>
			/// For OLE embeddings, the initialization interface is IPersistStorage, but in other situations, other interfaces are used. To
			/// initialize the object, there must be a subsequent call to an appropriate method in the initializing interface. Common
			/// initialization functions include IPersistStorage::InitNew (for new, blank embeddable components), IPersistStorage::Load (for
			/// reloaded embeddable components), IPersistStream::Load, (for objects stored in a stream object) or IPersistFile::Load (for
			/// objects stored in a file).
			/// </para>
			/// <para>
			/// In general, if an application supports only one class of objects, and the class object is registered for single use, only one
			/// object can be created. The application must not create other objects, and a request to do so should return an error from
			/// <c>IClassFactory::CreateInstance</c>. The same is true for applications that support multiple classes, each with a class
			/// object registered for single use; a call to <c>CreateInstance</c> for one class followed by a call to <c>CreateInstance</c>
			/// for any of the classes that should return an error.
			/// </para>
			/// <para>
			/// To avoid returning an error, applications that support multiple classes with single-use class objects can revoke the
			/// registered class object of the first class by calling CoRevokeClassObject when a request for instantiating a second is
			/// received. For example, suppose there are two classes, A and B. When <c>CreateInstance</c> is called for class A, revoke the
			/// class object for B. When B is created, revoke the class object for A. This solution complicates shutdown because one of the
			/// class objects might have already been revoked (and cannot be revoked twice).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/unknwn/nf-unknwn-iclassfactory-createinstance HRESULT CreateInstance(
			// IUnknown *pUnkOuter, REFIID riid, void **ppvObject );
			HRESULT CreateInstance([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvObject);

			/// <summary>Locks an object application open in memory. This enables instances to be created more quickly.</summary>
			/// <param name="fLock">If <c>TRUE</c>, increments the lock count; if <c>FALSE</c>, decrements the lock count.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// <c>IClassFactory::LockServer</c> controls whether an object's server is kept in memory. Keeping the application alive in
			/// memory allows instances to be created more quickly.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Most clients do not need to call this method. It is provided only for those clients that require special performance in
			/// creating multiple instances of their objects.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If the lock count is zero, there are no more objects in use, and the application is not under user control, the server can be
			/// closed. One way to implement <c>LockServer</c> is to call the CoLockObjectExternal function.
			/// </para>
			/// <para>
			/// The process that locks the object application is responsible for unlocking it. After the class object is released, there is
			/// no mechanism that guarantees the caller connection to the same class later (as in the case where a class object is registered
			/// as single-use). It is important to count all calls, not just the last one, to <c>LockServer</c>, because calls must be
			/// balanced before attempting to release the pointer to the IClassFactory interface on the class object or an error results. For
			/// every call to <c>LockServer</c> with fLock set to <c>TRUE</c>, there must be a call to <c>LockServer</c> with fLock set to
			/// <c>FALSE</c>. When the lock count and the class object reference count are both zero, the class object can be freed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/unknwnbase/nf-unknwnbase-iclassfactory-lockserver HRESULT LockServer(
			// BOOL fLock );
			HRESULT LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
		}

		/// <summary>
		/// <para>Enables a class factory object, in any sort of object server, to control object creation through licensing.</para>
		/// <para>
		/// This interface is an extension to IClassFactory. This extension enables a class factory executing on a licensed machine to
		/// provide a license key that can be used later to create an object instance on an unlicensed machine. Such considerations are
		/// important for objects like controls that are used to build applications on a licensed machine. Subsequently, the application
		/// built must be able to run on an unlicensed machine. The license key gives only that one client application the right to
		/// instantiate objects through <c>IClassFactory2</c> when a full machine license does not exist.
		/// </para>
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Ole32.IClassFactory"/>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nn-ocidl-iclassfactory2
		[PInvokeData("ocidl.h", MSDNShortId = "c49c7612-3b1f-4535-baf3-8458b3f34f95")]
		[ComImport, Guid("B196B28F-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IClassFactory2 : IClassFactory
		{
			/// <summary>Creates an uninitialized object.</summary>
			/// <param name="pUnkOuter">
			/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the
			/// aggregate. Otherwise, this parameter must be <c>NULL</c>.
			/// </param>
			/// <param name="riid">
			/// A reference to the identifier of the interface to be used to communicate with the newly created object. If pUnkOuter is
			/// <c>NULL</c>, this parameter is generally the IID of the initializing interface; if pUnkOuter is non- <c>NULL</c>, riid must
			/// be IID_IUnknown.
			/// </param>
			/// <param name="ppvObject">
			/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObject
			/// contains the requested interface pointer. If the object does not support the interface specified in riid, the implementation
			/// must set *ppvObject to <c>NULL</c>.
			/// </param>
			/// <param name="LockServer">The lock server.</param>
			/// <param name="">The .</param>
			/// <param name="fLock">The f lock.</param>
			/// <returns>
			/// <para>
			/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The specified object was created.</term>
			/// </item>
			/// <item>
			/// <term>CLASS_E_NOAGGREGATION</term>
			/// <term>The pUnkOuter parameter was non-NULL and the object does not support aggregation.</term>
			/// </item>
			/// <item>
			/// <term>E_NOINTERFACE</term>
			/// <term>The object that ppvObject points to does not support the interface identified by riid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A COM server's implementation of <c>CreateInstance</c> must return a reference to an object contained in an apartment that
			/// belongs to the server's DCOM resolver. It must not return a reference to an object that is contained in a remote apartment.
			/// </para>
			/// <para>
			/// The IClassFactory interface is always on a class object. The <c>CreateInstance</c> method creates an uninitialized object of
			/// the class identified with the specified CLSID. When an object is created in this way, the CLSID must be registered in the
			/// system registry with the CoRegisterClassObject function.
			/// </para>
			/// <para>
			/// The pUnkOuter parameter indicates whether the object is being created as part of an aggregate. Object definitions are not
			/// required to support aggregation â€” they must be specifically designed and implemented to support it.
			/// </para>
			/// <para>
			/// The riid parameter specifies the IID (interface identifier) of the interface through which you will communicate with the new
			/// object. If pUnkOuter is non- <c>NULL</c> (indicating aggregation), the value of the riid parameter must be IID_IUnknown. If
			/// the object is not part of an aggregate, riid often specifies the interface though which the object will be initialized.
			/// </para>
			/// <para>
			/// For OLE embeddings, the initialization interface is IPersistStorage, but in other situations, other interfaces are used. To
			/// initialize the object, there must be a subsequent call to an appropriate method in the initializing interface. Common
			/// initialization functions include IPersistStorage::InitNew (for new, blank embeddable components), IPersistStorage::Load (for
			/// reloaded embeddable components), IPersistStream::Load, (for objects stored in a stream object) or IPersistFile::Load (for
			/// objects stored in a file).
			/// </para>
			/// <para>
			/// In general, if an application supports only one class of objects, and the class object is registered for single use, only one
			/// object can be created. The application must not create other objects, and a request to do so should return an error from
			/// <c>IClassFactory::CreateInstance</c>. The same is true for applications that support multiple classes, each with a class
			/// object registered for single use; a call to <c>CreateInstance</c> for one class followed by a call to <c>CreateInstance</c>
			/// for any of the classes that should return an error.
			/// </para>
			/// <para>
			/// To avoid returning an error, applications that support multiple classes with single-use class objects can revoke the
			/// registered class object of the first class by calling CoRevokeClassObject when a request for instantiating a second is
			/// received. For example, suppose there are two classes, A and B. When <c>CreateInstance</c> is called for class A, revoke the
			/// class object for B. When B is created, revoke the class object for A. This solution complicates shutdown because one of the
			/// class objects might have already been revoked (and cannot be revoked twice).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/unknwn/nf-unknwn-iclassfactory-createinstance HRESULT CreateInstance(
			// IUnknown *pUnkOuter, REFIID riid, void **ppvObject );
			new HRESULT CreateInstance([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvObject);

			/// <summary>Locks an object application open in memory. This enables instances to be created more quickly.</summary>
			/// <param name="fLock">If <c>TRUE</c>, increments the lock count; if <c>FALSE</c>, decrements the lock count.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// <c>IClassFactory::LockServer</c> controls whether an object's server is kept in memory. Keeping the application alive in
			/// memory allows instances to be created more quickly.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Most clients do not need to call this method. It is provided only for those clients that require special performance in
			/// creating multiple instances of their objects.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If the lock count is zero, there are no more objects in use, and the application is not under user control, the server can be
			/// closed. One way to implement <c>LockServer</c> is to call the CoLockObjectExternal function.
			/// </para>
			/// <para>
			/// The process that locks the object application is responsible for unlocking it. After the class object is released, there is
			/// no mechanism that guarantees the caller connection to the same class later (as in the case where a class object is registered
			/// as single-use). It is important to count all calls, not just the last one, to <c>LockServer</c>, because calls must be
			/// balanced before attempting to release the pointer to the IClassFactory interface on the class object or an error results. For
			/// every call to <c>LockServer</c> with fLock set to <c>TRUE</c>, there must be a call to <c>LockServer</c> with fLock set to
			/// <c>FALSE</c>. When the lock count and the class object reference count are both zero, the class object can be freed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/unknwnbase/nf-unknwnbase-iclassfactory-lockserver HRESULT LockServer(
			// BOOL fLock );
			new HRESULT LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);

			/// <summary>Retrieves information about the licensing capabilities of this class factory.</summary>
			/// <param name="pLicInfo">A pointer to the caller-allocated LICINFO structure to be filled on output.</param>
			/// <returns>
			/// <para>This method can return the standard return values E_UNEXPECTED, as well as the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The LICINFO structure was successfully filled in.</term>
			/// </item>
			/// <item>
			/// <term>E_POINTER</term>
			/// <term>The address in pLicInfo is not valid. For example, it may be NULL.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// E_NOTIMPL is not allowed as a return value because this method provides critical information for the client of a licensed
			/// class factory.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-getlicinfo HRESULT GetLicInfo( LICINFO
			// *pLicInfo );
			[PreserveSig]
			HRESULT GetLicInfo(ref LICINFO pLicInfo);

			/// <summary>Creates a license key that the caller can save and use later to create an instance of the licensed object.</summary>
			/// <param name="dwReserved">This parameter is reserved and must be zero.</param>
			/// <returns>
			/// A pointer to the caller-allocated variable that receives the callee-allocated license key on successful return from this
			/// method. This parameter is set to <c>NULL</c> on any failure.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The caller can save the license key for subsequent calls to IClassFactory2::CreateInstanceLic to create objects on an
			/// otherwise unlicensed machine.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The caller must free the <c>BSTR</c> with the SysFreeString function when the key is no longer needed. The value of
			/// fRuntimeKeyAvail is returned through a previous call to IClassFactory2::GetLicInfo.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// This method allocates the <c>BSTR</c> key with SysAllocString or SysAllocStringLen, and the caller becomes responsible for
			/// this <c>BSTR</c> after this method returns successfully.
			/// </para>
			/// <para>This method need not be implemented when a class factory does not support run-time license keys.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-requestlickey HRESULT RequestLicKey( DWORD
			// dwReserved, BSTR *pBstrKey );
			[return: MarshalAs(UnmanagedType.BStr)]
			string RequestLicKey(uint dwReserved = 0);

			/// <summary>
			/// Creates an instance of the licensed object for the specified license key. This method is the only possible means to create an
			/// object on an otherwise unlicensed machine.
			/// </summary>
			/// <param name="pUnkOuter">
			/// A pointer to the controlling IUnknown interface on the outer unknown if this object is being created as part of an aggregate.
			/// If the object is not part of an aggregate, this parameter must be <c>NULL</c>.
			/// </param>
			/// <param name="pUnkReserved">This parameter is unused and must be <c>NULL</c>.</param>
			/// <param name="riid">A reference to the identifier of the interface to be used to communicate with the newly created object.</param>
			/// <param name="bstrKey">
			/// Run-time license key previously obtained from IClassFactory2::RequestLicKey that is required to create an object.
			/// </param>
			/// <returns>
			/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains
			/// the requested interface pointer. If an error occurs, the implementation must set *ppvObj to <c>NULL</c>.
			/// </returns>
			/// <remarks>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If the class factory does not provide a license key (that is, IClassFactory2::RequestLicKey returns E_NOTIMPL and the
			/// <c>fRuntimeKeyAvail</c> member in LICINFO is set to <c>FALSE</c> in IClassFactory2::GetLicInfo), then this method can also
			/// return E_NOTIMPL. In such cases, the class factory is implementing IClassFactory2 simply to specify whether the machine is
			/// licensed at all through the <c>fLicVerified</c> member of <c>LICINFO</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-createinstancelic HRESULT
			// CreateInstanceLic( IUnknown *pUnkOuter, IUnknown *pUnkReserved, REFIID riid, BSTR bstrKey, PVOID *ppvObj );
			[return: MarshalAs(UnmanagedType.Interface)]
			object CreateInstanceLic([In, MarshalAs(UnmanagedType.Interface)] object pUnkOuter, [In, MarshalAs(UnmanagedType.Interface)] object pUnkReserved,
				in Guid riid, [In, MarshalAs(UnmanagedType.BStr)] string bstrKey);
		}

		/// <summary>
		/// <para>
		/// Contains parameters that describe the licensing behavior of a class factory that supports licensing. The structure is filled by
		/// calling the IClassFactory2::GetLicInfo method.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/ns-ocidl-taglicinfo typedef struct tagLICINFO { LONG cbLicInfo; BOOL
		// fRuntimeKeyAvail; BOOL fLicVerified; } LICINFO, *LPLICINFO;
		[PInvokeData("ocidl.h", MSDNShortId = "a90d82f3-8dc4-4b1d-81f7-9d3a19e74314")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct LICINFO
		{
			/// <summary>
			/// <para>The size of the structure, in bytes.</para>
			/// </summary>
			public int cbLicInfo;

			/// <summary>
			/// <para>
			/// Indicates whether this class factory allows the creation of its objects on an unlicensed machine through the use of a license
			/// key. If <c>TRUE</c>, IClassFactory2::RequestLicKey can be called to obtain the key. If <c>FALSE</c>, objects can be created
			/// only on a fully licensed machine.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fRuntimeKeyAvail;

			/// <summary>
			/// <para>
			/// Indicates whether a full machine license exists such that calls to IClassFactory::CreateInstance and
			/// IClassFactory2::RequestLicKey will succeed. If <c>TRUE</c>, the full machine license exists. Thus, objects can be created
			/// freely. and a license key is available if <c>fRuntimeKeyAvail</c> is also <c>TRUE</c>. If <c>FALSE</c>, this class factory
			/// cannot create any instances of objects on this machine unless the proper license key is passed to IClassFactory2::CreateInstanceLic.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fLicVerified;
		}
	}
}