using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// Manages access to the running object table (ROT), a globally accessible look-up table on each workstation. A workstation's ROT
		/// keeps track of those objects that can be identified by a moniker and that are currently running on the workstation. When a
		/// client tries to bind a moniker to an object, the moniker checks the ROT to see if the object is already running; this allows the
		/// moniker to bind to the current instance instead of loading a new one.
		/// </summary>
		/// <remarks>
		/// <para>The ROT contains entries of the following form: (pmkObjectName, pUnkObject).</para>
		/// <para>
		/// The pmkObjectName element is a pointer to the moniker that identifies the running object. The pUnkObject element is a pointer to
		/// the running object itself. During the binding process, monikers consult the pmkObjectName entries in the ROT to see whether an
		/// object is already running.
		/// </para>
		/// <para>
		/// Objects that can be named by monikers must be registered with the ROT when they are loaded and their registration must be
		/// revoked when they are no longer running.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-irunningobjecttable
		[PInvokeData("objidl.h", MSDNShortId = "ff89bcb5-df6d-4325-b0e8-613217a68f42")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000010-0000-0000-C000-000000000046")]
		public interface IRunningObjectTable
		{
			/// <summary>Registers an object and its identifying moniker in the running object table (ROT).</summary>
			/// <param name="grfFlags">
			/// <para>
			/// Specifies whether the ROT's reference to punkObject is weak or strong and controls access to the object through its entry in
			/// the ROT. For details, see the Remarks section.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ROTFLAGS_REGISTRATIONKEEPSALIVE</term>
			/// <term>When set, indicates a strong registration for the object.</term>
			/// </item>
			/// <item>
			/// <term>ROTFLAGS_ALLOWANYCLIENT</term>
			/// <term>
			/// When set, any client can connect to the running object through its entry in the ROT. When not set, only clients in the
			/// window station that registered the object can connect to it.
			/// </term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="punkObject">A pointer to the object that is being registered as running.</param>
			/// <param name="pmkObjectName">A pointer to the moniker that identifies punkObject.</param>
			/// <returns>
			/// An identifier for this ROT entry that can be used in subsequent calls to IRunningObjectTable::Revoke or
			/// IRunningObjectTable::NoteChangeTime. The caller cannot specify <c>NULL</c> for this parameter. If an error occurs,
			/// *pdwRegister is set to zero.
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method registers a pointer to an object under a moniker that identifies the object. The moniker is used as the key when
			/// the table is searched with IRunningObjectTable::GetObject.
			/// </para>
			/// <para>
			/// When an object is registered, the ROT always calls AddRef on the object. For a weak registration
			/// (ROTFLAGS_REGISTRATIONKEEPSALIVE not set), the ROT will release the object whenever the last strong reference to the object
			/// is released. For a strong registration (ROTFLAGS_REGISTRATIONKEEPSALIVE set), the ROT prevents the object from being
			/// destroyed until the object's registration is explicitly revoked.
			/// </para>
			/// <para>
			/// A server registered as either LocalService or RunAs can set the ROTFLAGS_ALLOWANYCLIENT flag in its call to <c>Register</c>
			/// to allow any client to connect to it. A server setting this bit must have its executable name in the AppID section of the
			/// registry that refers to the AppID for the executable. An "activate as activator" server (not registered as LocalService or
			/// RunAs) must not set this flag in its call to <c>Register</c>. For details on installing services, see Installing as a
			/// Service Application.
			/// </para>
			/// <para>
			/// Registering a second object with the same moniker, or re-registering the same object with the same moniker, creates a second
			/// entry in the ROT. In this case, <c>Register</c> returns MK_S_MONIKERALREADYREGISTERED. Each call to <c>Register</c> must be
			/// matched by a call to IRunningObjectTable::Revoke because even duplicate entries have different pdwRegister identifiers. A
			/// problem with duplicate registrations is that there is no way to determine which object will be returned if the moniker is
			/// specified in a subsequent call to IRunningObjectTable::IsRunning.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// If you are a moniker provider (that is, you hand out monikers identifying your objects to make them accessible to others),
			/// you must call the <c>Register</c> method to register your objects when they begin running. You must also call this method if
			/// you rename your objects while they are loaded.
			/// </para>
			/// <para>
			/// The most common type of moniker provider is a compound-document link source. This includes server applications that support
			/// linking to their documents (or portions of a document) and container applications that support linking to embeddings within
			/// their documents. Server applications that do not support linking can also use the ROT to cooperate with container
			/// applications that support linking to embeddings.
			/// </para>
			/// <para>
			/// If you are writing a server application, you should register an object with the ROT when it begins running, typically in
			/// your implementation of IOleObject::DoVerb. The object must be registered under its full moniker, which requires getting the
			/// moniker of its container document using IOleClientSite::GetMoniker. You should also revoke and re-register the object in
			/// your implementation of IOleObject::SetMoniker, which is called if the container document is renamed.
			/// </para>
			/// <para>
			/// If you are writing a container application that supports linking to embeddings, you should register your document with the
			/// ROT when it is loaded. If your document is renamed, you should revoke and re-register it with the ROT and call
			/// IOleObject::SetMoniker for any embedded objects in the document to give them an opportunity to re-register themselves.
			/// </para>
			/// <para>
			/// Objects registered in the ROT must be explicitly revoked when the object is no longer running or when its moniker changes.
			/// This revocation is important because there is no way for the system to automatically remove entries from the ROT. You must
			/// cache the identifier that is written through pdwRegister and use it in a call to IRunningObjectTable::Revoke to revoke the
			/// registration. For a strong registration, a strong reference is released when the objects registration is revoked.
			/// </para>
			/// <para>
			/// As of Windows Server 2003, if there are stale entries that remain in the ROT due to unexpected server problems, COM will
			/// automatically remove these stale entries from the ROT.
			/// </para>
			/// <para>
			/// The system's implementation of <c>Register</c> calls IMoniker::Reduce on the pmkObjectName parameter to ensure that the
			/// moniker is fully reduced before registration. If an object is known by more than one fully reduced moniker, it should be
			/// registered under all such monikers.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-register HRESULT Register( DWORD
			// grfFlags, IUnknown *punkObject, IMoniker *pmkObjectName, DWORD *pdwRegister );
			uint Register([In] ROTFLAGS grfFlags, [In, MarshalAs(UnmanagedType.IUnknown)] object punkObject, [In] IMoniker pmkObjectName);

			/// <summary>Removes an entry from the running object table (ROT) that was previously registered by a call to IRunningObjectTable::Register.</summary>
			/// <param name="dwRegister">The identifier of the ROT entry to be revoked.</param>
			/// <returns>This method can return the standard return values E_INVALIDARG and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// This method undoes the effect of a call to IRunningObjectTable::Register, removing both the moniker and the pointer to the
			/// object identified by that moniker.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A moniker provider (hands out monikers identifying its objects to make them accessible to others) must call the
			/// <c>Revoke</c> method to revoke the registration of its objects when it stops running. It must have previously called
			/// IRunningObjectTable::Register and stored the identifier returned by that method; it uses that identifier when calling <c>Revoke</c>.
			/// </para>
			/// <para>
			/// The most common type of moniker provider is a compound-document link source. This includes server applications that support
			/// linking to their documents (or portions of a document) and container applications that support linking to embeddings within
			/// their documents. Server applications that do not support linking can also use the ROT to cooperate with container
			/// applications that support linking to embeddings.
			/// </para>
			/// <para>
			/// If you are writing a container application, you must revoke a document's registration when the document is closed. You must
			/// also revoke a document's registration before re-registering it when it is renamed.
			/// </para>
			/// <para>
			/// If you are writing a server application, you must revoke an object's registration when the object is closed. You must also
			/// revoke an object's registration before re-registering it when its container document is renamed (see IOleObject::SetMoniker).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-revoke HRESULT Revoke( DWORD
			// dwRegister );
			void Revoke([In] uint dwRegister);

			/// <summary>Determines whether the object identified by the specified moniker is currently running.</summary>
			/// <param name="pmkObjectName">A pointer to the IMoniker interface on the moniker.</param>
			/// <returns>If the object is in the running state, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</returns>
			/// <remarks>
			/// <para>
			/// This method simply indicates whether a object is running. To retrieve a pointer to a running object, use the
			/// IRunningObjectTable::GetObject method.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Generally, you call the <c>IsRunning</c> method only if you are writing your own moniker class (that is, implementing the
			/// IMoniker interface). You typically call this method from your implementation of IMoniker::IsRunning. However, you should do
			/// so only if the pmkToLeft parameter of <c>IMoniker::IsRunning</c> is <c>NULL</c>. Otherwise, you should call
			/// <c>IMoniker::IsRunning</c> on your pmkToLeft parameter instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-isrunning HRESULT IsRunning(
			// IMoniker *pmkObjectName );
			[PreserveSig]
			HRESULT IsRunning([In] IMoniker pmkObjectName);

			/// <summary>
			/// Determines whether the object identified by the specified moniker is running, and if it is, retrieves a pointer to that object.
			/// </summary>
			/// <param name="pmkObjectName">A pointer to the IMoniker interface on the moniker.</param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>Indicates that pmkObjectName was found in the ROT and a pointer was retrieved.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>
			/// There is no entry for pmkObjectName in the ROT, or that the object it identifies is no longer running (in which case, the
			/// entry is revoked).
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method checks the ROT for the moniker specified by pmkObjectName. If that moniker had previously been registered with a
			/// call to IRunningObjectTable::Register, this method returns the pointer that was registered at that time.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Generally, you call the <c>IRunningObjectTable::GetObject</c> method only if you are writing your own moniker class (that
			/// is, implementing the IMoniker interface). You typically call this method from your implementation of IMoniker::BindToObject.
			/// </para>
			/// <para>
			/// However, note that not all implementations of IMoniker::BindToObject need to call this method. If you expect your moniker to
			/// have a prefix (indicated by a non- <c>NULL</c> pmkToLeft parameter to <c>IMoniker::BindToObject</c>), you should not check
			/// the ROT. The reason for this is that only complete monikers are registered with the ROT, and if your moniker has a prefix,
			/// your moniker is part of a composite and thus not complete. Instead, your moniker should request services from the object
			/// identified by the prefix (for example, the container of the object identified by your moniker).
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-getobject HRESULT GetObject(
			// IMoniker *pmkObjectName, IUnknown **ppunkObject );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetObject([In] IMoniker pmkObjectName);

			/// <summary>
			/// Records the time that a running object was last modified. The object must have previously been registered with the running
			/// object table (ROT). This method stores the time of last change in the ROT.
			/// </summary>
			/// <param name="dwRegister">The identifier of the ROT entry of the changed object. This value was previously returned by IRunningObjectTable::Register.</param>
			/// <param name="pfiletime">A pointer to a FILETIME structure containing the object's last change time.</param>
			/// <returns>This method can return the standard return values E_INVALIDARG and S_OK.</returns>
			/// <remarks>
			/// <para>The time recorded by this method can be retrieved by calling IRunningObjectTable::GetTimeOfLastChange.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A moniker provider (hands out monikers identifying its objects to make them accessible to others) must call the
			/// <c>NoteChangeTime</c> method whenever its objects are modified. It must have previously called IRunningObjectTable::Register
			/// and stored the identifier returned by that method; it uses that identifier when calling <c>NoteChangeTime</c>.
			/// </para>
			/// <para>
			/// The most common type of moniker provider is a compound-document link source. This includes server applications that support
			/// linking to their documents (or portions of a document) and container applications that support linking to embeddings within
			/// their documents. Server applications that do not support linking can also use the ROT to cooperate with container
			/// applications that support linking to embeddings.
			/// </para>
			/// <para>
			/// When an object is first registered in the ROT, the ROT records its last change time as the value returned by calling
			/// IMoniker::GetTimeOfLastChange on the moniker being registered.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-notechangetime HRESULT
			// NoteChangeTime( DWORD dwRegister, FILETIME *pfiletime );
			void NoteChangeTime([In] uint dwRegister, in FILETIME pfiletime);

			/// <summary>Retrieves the time that an object was last modified.</summary>
			/// <param name="pmkObjectName">A pointer to the IMoniker interface on the moniker.</param>
			/// <returns>A pointer to a FILETIME structure that receives the object's last change time.</returns>
			/// <remarks>
			/// <para>
			/// This method returns the change time that was last reported for this object by a call to IRunningObjectTable::NoteChangeTime.
			/// If <c>NoteChangeTime</c> has not been called previously, the method returns the time that was recorded when the object was registered.
			/// </para>
			/// <para>
			/// This method is provided to enable checking whether a connection between two objects (represented by one object holding a
			/// moniker that identifies the other) is up-to-date. For example, if one object is holding cached information about the other
			/// object, this method can be used to check whether the object has been modified since the cache was last updated. See IMoniker::GetTimeOfLastChange.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Generally, you call <c>GetTimeOfLastChange</c> only if you are writing your own moniker class (that is, implementing the
			/// IMoniker interface). You typically call this method from your implementation of IMoniker::GetTimeOfLastChange. However, you
			/// should do so only if the pmkToLeft parameter of <c>IMoniker::GetTimeOfLastChange</c> is <c>NULL</c>. Otherwise, you should
			/// call <c>IMoniker::GetTimeOfLastChange</c> on your pmkToLeft parameter instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-gettimeoflastchange HRESULT
			// GetTimeOfLastChange( IMoniker *pmkObjectName, FILETIME *pfiletime );
			FILETIME GetTimeOfLastChange([In] IMoniker pmkObjectName);

			/// <summary>
			/// Creates and returns a pointer to an enumerator that can list the monikers of all the objects currently registered in the
			/// running object table (ROT).
			/// </summary>
			/// <returns>
			/// A pointer to an IEnumMoniker pointer variable that receives the interface pointer to the new enumerator for the ROT. When
			/// successful, the implementation calls AddRef on the enumerator; it is the caller's responsibility to call Release. If an
			/// error occurs; the implementation sets *ppenumMoniker to <c>NULL</c>.
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IRunningObjectTable::EnumRunning</c> must create and return a pointer to an IEnumMoniker interface on an enumerator
			/// object. The standard enumerator methods can then be called to enumerate the monikers currently registered in the registry.
			/// The enumerator cannot be used to enumerate monikers that are registered in the ROT after the enumerator has been created.
			/// </para>
			/// <para>
			/// The <c>EnumRunning</c> method is intended primarily for the use by the system in implementing the alert object table. Note
			/// that OLE 2 does not include an implementation of the alert object table.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-irunningobjecttable-enumrunning HRESULT EnumRunning(
			// IEnumMoniker **ppenumMoniker );
			IEnumMoniker EnumRunning();
		}

		/// <summary>
		/// The IStorage interface supports the creation and management of structured storage objects. Structured storage allows
		/// hierarchical storage of information within a single file, and is often referred to as "a file system within a file". Elements of
		/// a structured storage object are storages and streams. Storages are analogous to directories, and streams are analogous to files.
		/// Within a structured storage there will be a primary storage object that may contain substorages, possibly nested, and streams.
		/// Storages provide the structure of the object, and streams contain the data, which is manipulated through the IStream interface.
		/// <para>
		/// The IStorage interface provides methods for creating and managing the root storage object, child storage objects, and stream
		/// objects. These methods can create, open, enumerate, move, copy, rename, or delete the elements in the storage object.
		/// </para>
		/// <para>
		/// An application must release its IStorage pointers when it is done with the storage object to deallocate memory used. There are
		/// also methods for changing the date and time of an element.
		/// </para>
		/// <para>
		/// There are a number of different modes in which a storage object and its elements can be opened, determined by setting values
		/// from STGM Constants. One aspect of this is how changes are committed. You can set direct mode, in which changes to an object are
		/// immediately written to it, or transacted mode, in which changes are written to a buffer until explicitly committed. The IStorage
		/// interface provides methods for committing changes and reverting to the last-committed version. For example, a stream can be
		/// opened in read-only mode or read/write mode. For more information, see STGM Constants.
		/// </para>
		/// <para>Other methods provide access to information about a storage object and its elements through the STATSTG structure.</para>
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComConversionLoss, Guid("0000000B-0000-0000-C000-000000000046")]
		[PInvokeData("Objidl.h", MSDNShortId = "aa380015")]
		public interface IStorage
		{
			/// <summary>
			/// The CreateStream method creates and opens a stream object with the specified name contained in this storage object. All
			/// elements within a storage objects, both streams and other storage objects, are kept in the same name space.
			/// </summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the newly created stream. The name can be used later to open or reopen the stream. The
			/// name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f characters, serving
			/// as the first character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a
			/// structured storage restriction.
			/// </param>
			/// <param name="grfMode">
			/// Specifies the access mode to use when opening the newly created stream. For more information and descriptions of the
			/// possible values, see STGM Constants.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>On return, the new IStream interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream CreateStream([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In] STGM grfMode,
				[In, Optional] uint reserved1,
				[In, Optional] uint reserved2);

			/// <summary>The OpenStream method opens an existing stream object within this storage object in the specified access mode.</summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the stream to open. The 000 through 01f characters, serving as the first character of the
			/// stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a structured storage restriction.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be NULL.</param>
			/// <param name="grfMode">
			/// Specifies the access mode to be assigned to the open stream. For more information and descriptions of possible values, see
			/// STGM Constants. Other modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method in the compound
			/// file implementation.
			/// </param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>A IStream interface pointer to the newly opened stream object.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream OpenStream([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName, [In, Optional] IntPtr reserved1,
				[In] STGM grfMode,
				[In, Optional] uint reserved2);

			/// <summary>
			/// The CreateStorage method creates and opens a new storage object nested within this storage object with the specified name in
			/// the specified access mode.
			/// </summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the newly created storage object. The name can be used later to reopen the storage
			/// object. The name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f
			/// characters, serving as the first character of the stream/storage name, are reserved for use by OLE. This is a compound file
			/// restriction, not a structured storage restriction.
			/// </param>
			/// <param name="grfMode">
			/// A value that specifies the access mode to use when opening the newly created storage object. For more information and a
			/// description of possible values, see STGM Constants.
			/// </param>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be zero.</param>
			/// <returns>On return, the new IStorage interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStorage CreateStorage([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In] STGM grfMode,
				[In, Optional] uint reserved1,
				[In, Optional] uint reserved2);

			/// <summary>The OpenStorage method opens an existing storage object with the specified name in the specified access mode.</summary>
			/// <param name="pwcsName">
			/// A string that contains the name of the storage object to open. The 000 through 01f characters, serving as the first
			/// character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a structured
			/// storage restriction. It is ignored if pstgPriority is non-NULL.
			/// </param>
			/// <param name="pstgPriority">Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
			/// <param name="grfMode">
			/// Specifies the access mode to use when opening the storage object. For descriptions of the possible values, see STGM
			/// Constants. Other modes you choose must at least specify STGM_SHARE_EXCLUSIVE when calling this method.
			/// </param>
			/// <param name="snbExclude">Must be NULL. A non-NULL value will return STG_E_INVALIDPARAMETER.</param>
			/// <param name="reserved">Reserved for future use; must be zero.</param>
			/// <returns>On return, the IStorage interface pointer to the opened storage.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStorage OpenStorage([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, Optional, MarshalAs(UnmanagedType.Interface)] IStorage pstgPriority,
				[In] STGM grfMode,
				[In, Optional] SNB snbExclude,
				[In, Optional] uint reserved);

			/// <summary>The CopyTo method copies the entire contents of an open storage object to another storage object.</summary>
			/// <param name="ciidExclude">
			/// The number of elements in the array pointed to by rgiidExclude. If rgiidExclude is NULL, then ciidExclude is ignored.
			/// </param>
			/// <param name="rgiidExclude">
			/// An array of interface identifiers (IIDs) that either the caller knows about and does not want copied or that the storage
			/// object does not support, but whose state the caller will later explicitly copy. The array can include IStorage, indicating
			/// that only stream objects are to be copied, and IStream, indicating that only storage objects are to be copied. An array
			/// length of zero indicates that only the state exposed by the IStorage object is to be copied; all other interfaces on the
			/// object are to be ignored. Passing NULL indicates that all interfaces on the object are to be copied.
			/// </param>
			/// <param name="snbExclude">
			/// A string name block (refer to SNB) that specifies a block of storage or stream objects that are not to be copied to the
			/// destination. These elements are not created at the destination. If IID_IStorage is in the rgiidExclude array, this parameter
			/// is ignored. This parameter may be NULL.
			/// </param>
			/// <param name="pstgDest">
			/// A pointer to the open storage object into which this storage object is to be copied. The destination storage object can be a
			/// different implementation of the IStorage interface from the source storage object. Thus, IStorage::CopyTo can use only
			/// publicly available methods of the destination storage object. If pstgDest is open in transacted mode, it can be reverted by
			/// calling its IStorage::Revert method.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void CopyTo([In, Optional] uint ciidExclude,
				[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] rgiidExclude,
				[In] SNB snbExclude,
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgDest);

			/// <summary>
			/// The MoveElementTo method copies or moves a substorage or stream from this storage object to another storage object.
			/// </summary>
			/// <param name="pwcsName">A string that contains the name of the element in this storage object to be moved or copied.</param>
			/// <param name="pstgDest">IStorage pointer to the destination storage object.</param>
			/// <param name="pwcsNewName">A string that contains the new name for the element in its new storage object.</param>
			/// <param name="grfFlags">
			/// Specifies whether the operation should be a move (STGMOVE_MOVE) or a copy (STGMOVE_COPY). See the STGMOVE enumeration.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void MoveElementTo([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgDest, [In, MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName,
				[In] STGMOVE grfFlags);

			/// <summary>
			/// The Commit method ensures that any changes made to a storage object open in transacted mode are reflected in the parent
			/// storage. For nonroot storage objects in direct mode, this method has no effect. For a root storage, it reflects the changes
			/// in the actual device; for example, a file on disk. For a root storage object opened in direct mode, always call the
			/// IStorage::Commit method prior to Release. IStorage::Commit flushes all memory buffers to the disk for a root storage in
			/// direct mode and will return an error code upon failure. Although Release also flushes memory buffers to disk, it has no
			/// capacity to return any error codes upon failure. Therefore, calling Release without first calling Commit causes
			/// indeterminate results.
			/// </summary>
			/// <param name="grfCommitFlags">
			/// Controls how the changes are committed to the storage object. See the STGC enumeration for a definition of these values.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Commit([In] STGC grfCommitFlags);

			/// <summary>The Revert method discards all changes that have been made to the storage object since the last commit operation.</summary>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Revert();

			/// <summary>
			/// The EnumElements method retrieves a pointer to an enumerator object that can be used to enumerate the storage and stream
			/// objects contained within this storage object.
			/// </summary>
			/// <param name="reserved1">Reserved for future use; must be zero.</param>
			/// <param name="reserved2">Reserved for future use; must be <c>NULL</c>.</param>
			/// <param name="reserved3">Reserved for future use; must be zero.</param>
			/// <returns>The interface pointer to the new enumerator object.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumSTATSTG EnumElements([In, Optional] uint reserved1, [In, Optional] IntPtr reserved2, [In, Optional] uint reserved3);

			/// <summary>The DestroyElement method removes the specified storage or stream from this storage object.</summary>
			/// <param name="pwcsName">A string that contains the name of the storage or stream to be removed.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void DestroyElement([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

			/// <summary>The RenameElement method renames the specified substorage or stream in this storage object.</summary>
			/// <param name="pwcsOldName">A string that contains the name of the substorage or stream to be changed.</param>
			/// <param name="pwcsNewName">A string that contains the new name for the specified substorage or stream.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void RenameElement([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsOldName,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName);

			/// <summary>
			/// The SetElementTimes method sets the modification, access, and creation times of the specified storage element, if the
			/// underlying file system supports this method.
			/// </summary>
			/// <param name="pwcsName">
			/// The name of the storage object element whose times are to be modified. If NULL, the time is set on the root storage rather
			/// than one of its elements.
			/// </param>
			/// <param name="pctime">
			/// Either the new creation time as the first element of the array for the element or NULL if the creation time is not to be modified.
			/// </param>
			/// <param name="patime">
			/// Either the new access time as the first element of the array for the element or NULL if the access time is not to be modified.
			/// </param>
			/// <param name="pmtime">
			/// Either the new modification time as the first element of the array for the element or NULL if the modification time is not
			/// to be modified.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetElementTimes([In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pctime,
				[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] patime,
				[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pmtime);

			/// <summary>The SetClass method assigns the specified class identifier (CLSID) to this storage object.</summary>
			/// <param name="clsid">The CLSID that is to be associated with the storage object.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetClass(in Guid clsid);

			/// <summary>
			/// The SetStateBits method stores up to 32 bits of state information in this storage object. This method is reserved for future use.
			/// </summary>
			/// <param name="grfStateBits">
			/// Specifies the new values of the bits to set. No legal values are defined for these bits; they are all reserved for future
			/// use and must not be used by applications.
			/// </param>
			/// <param name="grfMask">A binary mask indicating which bits in grfStateBits are significant in this call.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetStateBits([In] uint grfStateBits, [In] uint grfMask);

			/// <summary>The Stat method retrieves the STATSTG structure for this open storage object.</summary>
			/// <param name="pstatstg">
			/// On return, pointer to a STATSTG structure where this method places information about the open storage object. This parameter
			/// is NULL if an error occurs.
			/// </param>
			/// <param name="grfStatFlag">
			/// Specifies that some of the members in the STATSTG structure are not returned, thus saving a memory allocation operation.
			/// Values are taken from the STATFLAG enumeration.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Stat(out STATSTG pstatstg, [In] STATFLAG grfStatFlag);
		}

		/// <summary>
		/// <para>[Use of ISurrogateService is not recommended; use IProcessInitControl instead.]</para>
		/// <para>Used to initialize, launch, and release a COM+ application. You can also refresh the catalog and shut down the process.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-isurrogateservice
		[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ISurrogateService")]
		[ComImport, Guid("000001d4-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ISurrogateService
		{
			/// <summary>Initializes the process server.</summary>
			/// <param name="rguidProcessID">The process ID of the server application.</param>
			/// <param name="pProcessLock">A pointer to an instance of the IProcessLock interface.</param>
			/// <param name="pfApplicationAware">Indicates whether the application is aware of the initialization.</param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_UNEXPECTED.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isurrogateservice-init HRESULT Init( REFGUID
			// rguidProcessID, IProcessLock *pProcessLock, BOOL *pfApplicationAware );
			[PreserveSig]
			HRESULT Init(in Guid rguidProcessID, IProcessLock pProcessLock, [MarshalAs(UnmanagedType.Bool)] out bool pfApplicationAware);

			/// <summary>Launches the application.</summary>
			/// <param name="rguidApplID">The application identifier.</param>
			/// <param name="appType">The application type, as described in Remarks.</param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_UNEXPECTED.</returns>
			/// <remarks>
			/// <para>The application type is defined by the following enum.</para>
			/// <para>
			/// <code>typedef enum tagApplicationType { ServerApplication, LibraryApplication } ApplicationType;</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isurrogateservice-applicationlaunch HRESULT
			// ApplicationLaunch( REFGUID rguidApplID, ApplicationType appType );
			[PreserveSig]
			HRESULT ApplicationLaunch(in Guid rguidApplID, ApplicationType appType);

			/// <summary>Releases the application.</summary>
			/// <param name="rguidApplID">The application identifier.</param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_UNEXPECTED.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isurrogateservice-applicationfree HRESULT
			// ApplicationFree( REFGUID rguidApplID );
			[PreserveSig]
			HRESULT ApplicationFree(in Guid rguidApplID);

			/// <summary>Refreshes the catalog.</summary>
			/// <param name="ulReserved">This parameter is reserved.</param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_UNEXPECTED.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isurrogateservice-catalogrefresh HRESULT CatalogRefresh(
			// ULONG ulReserved );
			[PreserveSig]
			HRESULT CatalogRefresh([Optional] uint ulReserved);

			/// <summary>Shuts down the process.</summary>
			/// <param name="shutdownType">The shutdown type, as described in Remarks.</param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_UNEXPECTED.</returns>
			/// <remarks>
			/// <para>The shutdown type is defined by the following enum.</para>
			/// <para>
			/// <code>typedef enum tagShutdownType { IdleShutdown, ForcedShutdown } ShutdownType;</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isurrogateservice-processshutdown HRESULT
			// ProcessShutdown( ShutdownType shutdownType );
			[PreserveSig]
			HRESULT ProcessShutdown(ShutdownType shutdownType);
		}

		/// <summary>Enumerates the values in a <see cref="IEnumContextProps"/> instance.</summary>
		/// <param name="e">The <see cref="IEnumContextProps"/> instance.</param>
		/// <returns>The enumerated values.</returns>
		public static IEnumerable<ContextProperty> Enumerate(this IEnumContextProps e) => Vanara.Collections.IEnumFromCom<ContextProperty>.Create(e);

		/// <summary>Enumerates the values in a <see cref="IEnumSTATSTG"/> instance.</summary>
		/// <param name="e">The <see cref="IEnumSTATSTG"/> instance.</param>
		/// <returns>The enumerated values.</returns>
		public static IEnumerable<STATSTG> Enumerate(this IEnumSTATSTG e) => Vanara.Collections.IEnumFromCom<STATSTG>.Create(e);

		/// <summary>Enumerates the values in a <see cref="IEnumUnknown"/> instance.</summary>
		/// <param name="e">The <see cref="IEnumUnknown"/> instance.</param>
		/// <returns>The enumerated values.</returns>
		public static IEnumerable<IntPtr> Enumerate(this IEnumUnknown e) => Vanara.Collections.IEnumFromCom<IntPtr>.Create(e);

		/// <summary>Enumerates the values in a <see cref="IEnumUnknown"/> instance.</summary>
		/// <typeparam name="T">
		/// The COM interface type to query for from each item in the collection. Note that if this type cannot be retrieved, an exception
		/// will be thrown.
		/// </typeparam>
		/// <param name="e">The <see cref="IEnumUnknown"/> instance.</param>
		/// <returns>The enumerated values.</returns>
		public static IEnumerable<T> Enumerate<T>(this IEnumUnknown e) where T : class => e.Enumerate().Select(p => p == IntPtr.Zero ? null : (T)Marshal.GetObjectForIUnknown(p));

		/// <summary>Structure returned by IEnumContextProps::Enum</summary>
		[PInvokeData("objidl.h", MSDNShortId = "64591e45-5478-4360-8c1f-08b09b5aef8e")]
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-next
		[StructLayout(LayoutKind.Sequential)]
		public struct ContextProperty
		{
			/// <summary/>
			public Guid policyId;

			/// <summary/>
			public uint flags;

			/// <summary/>
			public IntPtr pUnk;
		}

		/// <summary>
		/// Specifies information about the target device for which data is being composed. <c>DVTARGETDEVICE</c> contains enough
		/// information about a Windows target device so a handle to a device context ( <c>HDC</c>) can be created using the CreateDC function.
		/// </summary>
		/// <remarks>
		/// Some OLE 1 client applications incorrectly construct target devices by allocating too few bytes in the DEVMODE structure for the
		/// <c>DVTARGETDEVICE</c>. They typically only supply the number of bytes in the <c>dmSize</c> member of <c>DEVMODE</c>. The number
		/// of bytes to be allocated should be the sum of <c>dmSize</c> + <c>dmDriverExtra</c>. When a call is made to the CreateDC function
		/// with an incorrect target device, the printer driver tries to access the additional bytes and unpredictable results can occur. To
		/// help protect against a crash and make the additional bytes available, OLE pads the size of OLE 2 target devices created from OLE
		/// 1 target devices.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ns-objidl-dvtargetdevice typedef struct tagDVTARGETDEVICE { DWORD
		// tdSize; WORD tdDriverNameOffset; WORD tdDeviceNameOffset; WORD tdPortNameOffset; WORD tdExtDevmodeOffset; BYTE tdData[1]; } DVTARGETDEVICE;
		[PInvokeData("objidl.h", MSDNShortId = "724ff714-c170-4d06-92cb-e042e41c0af2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DVTARGETDEVICE
		{
			/// <summary>
			/// The size, in bytes, of the <c>DVTARGETDEVICE</c> structure. The initial size is included so the structure can be copied more easily.
			/// </summary>
			public uint tdSize;

			/// <summary>
			/// The offset, in bytes, from the beginning of the structure to the device driver name, which is stored as a NULL-terminated
			/// string in the <c>tdData</c> buffer.
			/// </summary>
			public ushort tdDriverNameOffset;

			/// <summary>
			/// The offset, in bytes, from the beginning of the structure to the device name, which is stored as a NULL-terminated string in
			/// the <c>tdData</c> buffer. This value can be zero to indicate no device name.
			/// </summary>
			public ushort tdDeviceNameOffset;

			/// <summary>
			/// The offset, in bytes, from the beginning of the structure to the port name, which is stored as a NULL-terminated string in
			/// the <c>tdData</c> buffer. This value can be zero to indicate no port name.
			/// </summary>
			public ushort tdPortNameOffset;

			/// <summary>The offset, in bytes, from the beginning of the structure to the DEVMODE structure retrieved by calling DocumentProperties.</summary>
			public ushort tdExtDevmodeOffset;

			private byte _tdData;
		}

		/// <summary>
		/// The <c>StorageLayout</c> structure describes a single block of data, including its name, location, and length. To optimize a
		/// compound file, an application or layout tool passes an array of <c>StorageLayout</c> structures in a call to ILayoutStorage::LayoutScript.
		/// </summary>
		/// <remarks>
		/// <para>An array of <c>StorageLayout</c> structures might appear as follows.</para>
		/// <para>
		/// <c>Note</c> The parameters cOffset and cBytes are <c>LARGE_INTEGER</c> structures, used to represent a 64-bit signed integer
		/// value as a union of two 32-bit members. The two 32-bit members must be represented as a <c>LARGE_INTEGER</c> structure with
		/// <c>DWORD</c> LowPart and <c>LONG</c> HighPart as the structure members. (LowPart specifies the low-order 32 bits and HighPart
		/// specifies the high-order 32 bits.) If your compiler has built-in support for 64-bit integers, use the <c>QuadPart</c> member of
		/// the <c>LARGE_INTEGER</c> structure to store the 64-bit integer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-storagelayout typedef struct tagStorageLayout { DWORD
		// LayoutType; OLECHAR *pwcsElementName; LARGE_INTEGER cOffset; LARGE_INTEGER cBytes; } StorageLayout;
		[PInvokeData("objidl.h", MSDNShortId = "1e4fb36d-077b-44bd-ab6e-8c122ec95a46")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct StorageLayout
		{
			/// <summary>
			/// The type of element to be written. Values are taken from the STGTY enumeration. <c>STGTY_STREAM</c> means read the block of
			/// data named by <c>pwcsElementName</c>. <c>STGTY_STORAGE</c> means open the storage specified in <c>pwcsElementName</c>.
			/// <c>STGTY_REPEAT</c> is used in multimedia applications to interface audio, video, text, and other elements. An opening
			/// <c>STGTY_REPEAT</c> value means that the elements that follow are to be repeated a specified number of times. The closing
			/// <c>STGTY_REPEAT</c> value marks the end of those elements that are to be repeated. Nested <c>STGTY_REPEAT</c> value pairs
			/// are permitted.
			/// </summary>
			public STGTY LayoutType;

			/// <summary>
			/// The null-terminated Unicode string name of the storage or stream. If the element is a substorage or embedded object, the
			/// fully qualified storage path must be specified; for example, "RootStorageName\SubStorageName\Substream".
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwcsElementName;

			/// <summary>
			/// <para>
			/// Where the value of the <c>LayoutType</c> member is <c>STGTY_STREAM</c>, this flag specifies the beginning offset into the
			/// steam named in the <c>pwscElementName</c> member.
			/// </para>
			/// <para>Where <c>LayoutType</c> is <c>STGTY_STORAGE</c>, this flag should be set to zero.</para>
			/// <para>Where <c>LayoutType</c> is <c>STGTY_REPEAT</c>, this flag should be set to zero.</para>
			/// </summary>
			public long cOffset;

			/// <summary>
			/// <para>Length, in bytes, of the data block named in <c>pwcsElementName</c>.</para>
			/// <para>
			/// Where <c>LayoutType</c> is <c>STGTY_STREAM</c>, <c>cBytes</c> specifies the number of bytes to read at <c>cOffset</c> from
			/// the stream named in <c>pwcsElementName</c>.
			/// </para>
			/// <para>Where <c>LayoutType</c> is <c>STGTY_STORAGE</c>, this flag is ignored.</para>
			/// <para>
			/// Where <c>LayoutType</c> is <c>STGTY_REPEAT</c>, a positive <c>cBytes</c> specifies the beginning of a repeat block.
			/// <c>STGTY_REPEAT</c> with zero <c>cBytes</c> marks the end of a repeat block.
			/// </para>
			/// <para>
			/// A beginning block value of <c>STG_TOEND</c> specifies that elements in a following block are to be repeated after each
			/// stream has been completely read.
			/// </para>
			/// </summary>
			public long cBytes;
		}

		/// <summary>
		/// <para>Contains parameters used during a moniker-binding operation.</para>
		/// <para>The BIND_OPTS2 or BIND_OPTS3 structure can be used in place of the <c>BIND_OPTS</c> structure.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// A <c>BIND_OPTS</c> structure is stored in a bind context; the same bind context is used by each component of a composite moniker
		/// during binding, allowing the same parameters to be passed to all components of a composite moniker. See IBindCtx for more
		/// information about bind contexts.
		/// </para>
		/// <para>
		/// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values for the
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that
		/// are suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
		/// moniker. If you want to modify the values of these bind options, you can do so by passing a <c>BIND_OPTS</c> structure to the
		/// IBindCtx::SetBindOptions method. Moniker implementers can pass a <c>BIND_OPTS</c> structure to the IBindCtx::GetBindOptions
		/// method to retrieve the values of these bind options.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagbind_opts typedef struct tagBIND_OPTS { DWORD cbStruct;
		// DWORD grfFlags; DWORD grfMode; DWORD dwTickCountDeadline; } BIND_OPTS, *LPBIND_OPTS;
		[PInvokeData("objidl.h", MSDNShortId = "764f09c9-ff20-4ae2-b94f-4b0a1e117e49")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class BIND_OPTS_V
		{
			/// <summary>The size of this structure, in bytes.</summary>
			public uint cbStruct;

			/// <summary>
			/// Flags that control aspects of moniker binding operations. This value is any combination of the bit flags in the BIND_FLAGS
			/// enumeration. The CreateBindCtx function initializes this member to zero.
			/// </summary>
			public BIND_FLAGS grfFlags;

			/// <summary>
			/// Flags that should be used when opening the file that contains the object identified by the moniker. Possible values are the
			/// STGM constants. The binding operation uses these flags in the call to IPersistFile::Load when loading the file. If the
			/// object is already running, these flags are ignored by the binding operation. The CreateBindCtx function initializes this
			/// field to STGM_READWRITE.
			/// </summary>
			public STGM grfMode;

			/// <summary>
			/// <para>
			/// The clock time by which the caller would like the binding operation to be completed, in milliseconds. This member lets the
			/// caller limit the execution time of an operation when speed is of primary importance. A value of zero indicates that there is
			/// no deadline. Callers most often use this capability when calling the IMoniker::GetTimeOfLastChange method, though it can be
			/// usefully applied to other operations as well. The CreateBindCtx function initializes this field to zero.
			/// </para>
			/// <para>
			/// Typical deadlines allow for a few hundred milliseconds of execution. This deadline is a recommendation, not a requirement;
			/// however, operations that exceed their deadline by a large amount may cause delays for the end user. Each moniker
			/// implementation should try to complete its operation by the deadline, or fail with the error MK_E_EXCEEDEDDEADLINE.
			/// </para>
			/// <para>
			/// If a binding operation exceeds its deadline because one or more objects that it needs are not running, the moniker
			/// implementation should register the objects responsible in the bind context using the IBindCtx::RegisterObjectParam. The
			/// objects should be registered under the parameter names "ExceededDeadline", "ExceededDeadline1", "ExceededDeadline2", and so
			/// on. If the caller later finds the object in the running object table, the caller can retry the binding operation.
			/// </para>
			/// <para>
			/// The GetTickCount function indicates the number of milliseconds since system startup, and wraps back to zero after 2^31
			/// milliseconds. Consequently, callers should be careful not to inadvertently pass a zero value (which indicates no deadline),
			/// and moniker implementations should be aware of clock wrapping problems.
			/// </para>
			/// </summary>
			public uint dwTickCountDeadline;

			/// <summary>Initializes a new instance of the <see cref="BIND_OPTS_V"/> class.</summary>
			public BIND_OPTS_V() => cbStruct = (uint)Marshal.SizeOf(typeof(BIND_OPTS_V));

			/// <summary>Performs an implicit conversion from <see cref="BIND_OPTS_V"/> to <see cref="System.Runtime.InteropServices.ComTypes.BIND_OPTS"/>.</summary>
			/// <param name="bo">The <see cref="BIND_OPTS_V"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator System.Runtime.InteropServices.ComTypes.BIND_OPTS(BIND_OPTS_V bo) =>
				new System.Runtime.InteropServices.ComTypes.BIND_OPTS { cbStruct = (int)bo.cbStruct, grfFlags = (int)bo.grfFlags, grfMode = (int)bo.grfFlags, dwTickCountDeadline = (int)bo.dwTickCountDeadline };

			/// <summary>
			/// Performs an implicit conversion from <see cref="System.Runtime.InteropServices.ComTypes.BIND_OPTS"/> to <see cref="BIND_OPTS_V"/>.
			/// </summary>
			/// <param name="bo">The <see cref="System.Runtime.InteropServices.ComTypes.BIND_OPTS"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BIND_OPTS_V(System.Runtime.InteropServices.ComTypes.BIND_OPTS bo) =>
				new BIND_OPTS_V() { grfFlags = (BIND_FLAGS)bo.grfFlags, grfMode = (STGM)bo.grfFlags, dwTickCountDeadline = (uint)bo.dwTickCountDeadline };
		}

		/// <summary>Contains parameters used during a moniker-binding operation.</summary>
		/// <remarks>
		/// <para>
		/// A <c>BIND_OPTS2</c> structure is stored in a bind context; the same bind context is used by each component of a composite
		/// moniker during binding, allowing the same parameters to be passed to all components of a composite moniker. See IBindCtx for
		/// more information about bind contexts.
		/// </para>
		/// <para>
		/// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values for the
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that
		/// are suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
		/// moniker. If you want to modify the values of these bind options, you can do so by passing a <c>BIND_OPTS2</c> structure to the
		/// IBindCtx::SetBindOptions method. Moniker implementers can pass a <c>BIND_OPTS2</c> structure to the IBindCtx::GetBindOptions
		/// method to retrieve the values of these bind options.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagbind_opts2 typedef struct tagBIND_OPTS2 { DWORD
		// dwTrackFlags; DWORD dwClassContext; LCID locale; COSERVERINFO *pServerInfo; base_class tagBIND_OPTS; } BIND_OPTS2, *LPBIND_OPTS2;
		[PInvokeData("objidl.h", MSDNShortId = "fb2aa8c1-dddc-480e-b544-61a1074125ef")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class BIND_OPTS2 : BIND_OPTS_V
		{
			/// <summary>
			/// <para>
			/// A moniker can use this value during link tracking. If the original persisted data that the moniker is referencing has been
			/// moved, the moniker can attempt to reestablish the link by searching for the original data though some adequate mechanism.
			/// This member provides additional information on how the link should be resolved. See the documentation of the fFlags
			/// parameter in IShellLink::Resolve.
			/// </para>
			/// <para>COM's file moniker implementation uses the shell link mechanism to reestablish links and passes these flags to IShellLink::Resolve.</para>
			/// </summary>
			public uint dwTrackFlags;

			/// <summary>
			/// The class context, taken from the CLSCTX enumeration, that is to be used for instantiating the object. Monikers typically
			/// pass this value to the dwClsContext parameter of CoCreateInstance.
			/// </summary>
			public CLSCTX dwClassContext;

			/// <summary>
			/// The LCID value indicating the client's preference for the locale to be used by the object to which they are binding. A
			/// moniker passes this value to IClassActivator::GetClassObject.
			/// </summary>
			public uint locale;

			/// <summary>
			/// A pointer to a COSERVERINFO structure. This member allows clients calling IMoniker::BindToObject to specify server
			/// information. Clients may pass a <c>BIND_OPTS2</c> structure to the IBindCtx::SetBindOptions method. If a server name is
			/// specified in the <c>COSERVERINFO</c> structure, the moniker bind will be forwarded to the specified computer.
			/// <c>SetBindOptions</c> only copies the struct members of <c>BIND_OPTS2</c>, not the <c>COSERVERINFO</c> structure and the
			/// pointers it contains. Callers may not free any of these pointers until the bind context is released. COM's new class moniker
			/// does not currently honor the <c>pServerInfo</c> flag.
			/// </summary>
			public IntPtr pServerInfo;

			/// <summary>Initializes a new instance of the <see cref="BIND_OPTS2"/> class.</summary>
			public BIND_OPTS2() => cbStruct = (uint)Marshal.SizeOf(typeof(BIND_OPTS2));
		}

		/// <summary>Contains parameters used during a moniker-binding operation.</summary>
		/// <remarks>
		/// <para>
		/// A <c>BIND_OPTS3</c> structure is stored in a bind context; the same bind context is used by each component of a composite
		/// moniker during binding, allowing the same parameters to be passed to all components of a composite moniker. See IBindCtx for
		/// more information about bind contexts.
		/// </para>
		/// <para>
		/// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values for the
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that
		/// are suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
		/// moniker. If you want to modify the values of these bind options, you can do so by passing a <c>BIND_OPTS3</c> structure to the
		/// IBindCtx::SetBindOptions method. Moniker implementers can pass a <c>BIND_OPTS3</c> structure to the IBindCtx::GetBindOptions
		/// method to retrieve the values of these bind options.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagbind_opts3 typedef struct tagBIND_OPTS3 { HWND hwnd;
		// base_class tagBIND_OPTS2; } BIND_OPTS3, *LPBIND_OPTS3;
		[PInvokeData("objidl.h", MSDNShortId = "7e668313-229a-4d04-b8a2-d5072c87a5b5")]
		[StructLayout(LayoutKind.Sequential)]
		public class BIND_OPTS3 : BIND_OPTS2
		{
			/// <summary>
			/// A handle to the window that becomes the owner of the elevation UI, if applicable. If <c>hwnd</c> is <c>NULL</c>, COM will
			/// call the GetActiveWindow function to find a window handle associated with the current thread. This case might occur if the
			/// client is a script, which cannot fill in a <c>BIND_OPTS3</c> structure. In this case, COM will try to use the window
			/// associated with the script thread.
			/// </summary>
			public HWND hwnd;

			/// <summary>Initializes a new instance of the <see cref="BIND_OPTS3"/> class.</summary>
			public BIND_OPTS3() => cbStruct = (uint)Marshal.SizeOf(typeof(BIND_OPTS3));
		}

		/// <summary>Simple generic implementation of <see cref="IEnumUnknown"/>.</summary>
		/// <typeparam name="T">The type to enumerate.</typeparam>
		/// <seealso cref="System.Collections.Generic.IReadOnlyList{T}"/>
		/// <seealso cref="Vanara.PInvoke.Ole32.IEnumUnknown"/>
		public class IEnumUnknownImpl<T> : IReadOnlyList<T>, IEnumUnknown where T : class
		{
			private int current = -1;
			private List<T> items;

			/// <summary>Initializes a new instance of the <see cref="IEnumUnknownImpl{T}"/> class using an existing enumeration.</summary>
			/// <param name="items">The items to enumerate.</param>
			/// <exception cref="ArgumentNullException">items</exception>
			public IEnumUnknownImpl(IEnumerable<T> items)
			{
				this.items = new List<T>(items ?? throw new ArgumentNullException(nameof(items)));
			}

			/// <summary>Gets the number of elements in the collection.</summary>
			/// <value>The number of elements in the collection.</value>
			public int Count => items.Count;

			/// <summary>Gets the element at the specified index in the read-only list.</summary>
			/// <value>The element at the specified index in the read-only list.</value>
			/// <param name="index">The zero-based index of the element to get.</param>
			public T this[int index] => items[index];

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="rgelt">
			/// <para>An array of enumerated items.</para>
			/// <para>
			/// The enumerator is responsible for calling AddRef, and the caller is responsible for calling Release through each pointer
			/// enumerated. If celt is greater than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many
			/// pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			/// <exception cref="ArgumentOutOfRangeException">rgelt - The length is not large enough for the requested number of items.</exception>
			public HRESULT Next(uint celt, IntPtr[] rgelt, out uint pceltFetched)
			{
				pceltFetched = 0;
				if (++current < items.Count)
				{
					pceltFetched = Math.Min((uint)(items.Count - current), celt);
					if (rgelt is null || rgelt.Length < pceltFetched)
						throw new ArgumentOutOfRangeException(nameof(rgelt), "The length is not large enough for the requested number of items.");
					for (int i = 0; i < pceltFetched; i++)
						rgelt[i] = Marshal.GetIUnknownForObject(items[current + i]);
					return HRESULT.S_OK;
				}
				return HRESULT.S_FALSE;
			}

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			public void Reset() => current = -1;

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			public HRESULT Skip(uint celt)
			{
				var temp = current + (int)celt;
				if (temp > items.Count - 1)
					return HRESULT.S_FALSE;
				current = temp;
				return HRESULT.S_OK;
			}

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
			/// time. The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			IEnumUnknown IEnumUnknown.Clone() => new IEnumUnknownImpl<T>(items);

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
		}

		/// <summary>Contains information about incoming calls.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ns-objidl-interfaceinfo typedef struct tagINTERFACEINFO { IUnknown
		// *pUnk; IID iid; WORD wMethod; } INTERFACEINFO, *LPINTERFACEINFO;
		[PInvokeData("objidl.h", MSDNShortId = "5c2c07bf-1c15-4f21-baef-103837ea24d0")]
		[StructLayout(LayoutKind.Sequential)]
		public class INTERFACEINFO
		{
			/// <summary>A pointer to the IUnknown interface on the object.</summary>
			[MarshalAs(UnmanagedType.IUnknown)] public object pUnk;

			/// <summary>The identifier of the requested interface.</summary>
			public Guid iid;

			/// <summary>The interface method.</summary>
			public ushort wMethod;
		}

		/// <summary>
		/// A string name block (SNB) is a pointer to an array of pointers to strings, that ends in a NULL pointer. String name blocks are
		/// used by the IStorage interface and by function calls that open storage objects. The strings point to contained storage objects
		/// or streams that are to be excluded in the open calls.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public class SNB : IDisposable
		{
			private readonly SafeCoTaskMemHandle ptr;

			/// <summary>Initializes a new instance of the <see cref="SNB"/> class.</summary>
			/// <param name="names">The list of names to associate with this instance.</param>
			public SNB(IEnumerable<string> names) => ptr = names == null ? SafeCoTaskMemHandle.Null : SafeCoTaskMemHandle.CreateFromStringList(names, StringListPackMethod.Packed, CharSet.Unicode);

			/// <summary>Prevents a default instance of the <see cref="SNB"/> class from being created.</summary>
			private SNB() { }

			/// <summary>Initializes a new instance of the <see cref="SNB"/> class.</summary>
			/// <param name="p">The native pointer.</param>
			private SNB(IntPtr p) => ptr = new SafeCoTaskMemHandle(p, 0, true);

			/// <summary>Gets the names.</summary>
			/// <value>The names.</value>
			public IEnumerable<string> Names => ptr.ToStringEnum(Count, CharSet.Unicode);

			private int Count => ptr.DangerousGetHandle().GetNulledPtrArrayLength();

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SNB"/>.</summary>
			/// <param name="p">The native pointer to take ownership of.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SNB(IntPtr p) => new SNB(p);

			/// <summary>Performs an implicit conversion from <see cref="IEnumerable{T}"/> to <see cref="SNB"/>.</summary>
			/// <param name="names">The names.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SNB(string[] names) => new SNB(names);

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose() => ptr?.Dispose();
		}
	}
}