using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

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
		[PreserveSig]
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
		[PreserveSig]
		HRESULT LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
	}
}