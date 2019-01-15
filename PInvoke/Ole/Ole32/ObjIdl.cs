using System;
using System.Collections.Generic;
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
		/// <para>Specifies various capabilities in CoInitializeSecurity and IClientSecurity::SetBlanket (or its helper function CoSetProxyBlanket).</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// When the EOAC_APPID flag is set, CoInitializeSecurity looks for the authentication level under the AppID. If the authentication
		/// level is not found, it looks for the default authentication level. If the default authentication level is not found, it generates
		/// a default authentication level of connect. If the authentication level is not RPC_C_AUTHN_LEVEL_NONE, <c>CoInitializeSecurity</c>
		/// looks for the access permission value under the AppID. If not found, it looks for the default access permission value. If not
		/// found, it generates a default access permission. All the other security settings are determined the same way as for a legacy application.
		/// </para>
		/// <para>
		/// If the AppID is NULL, <c>CoInitializeSecurity</c> looks up the application .exe name in the registry and uses the AppID stored
		/// there. If the AppID does not exist, the machine defaults are used.
		/// </para>
		/// <para>
		/// The IClientSecurity::SetBlanket method and CoSetProxyBlanket function return an error if any of the following flags are set in
		/// the capabilities parameter: EOAC_SECURE_REFS, EOAC_ACCESS_CONTROL, EOAC_APPID, EOAC_DYNAMIC, EOAC_REQUIRE_FULLSIC,
		/// EOAC_DISABLE_AAA, or EOAC_NO_CUSTOM_MARSHAL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidlbase/ne-objidlbase-tageole_authentication_capabilities typedef enum
		// tagEOLE_AUTHENTICATION_CAPABILITIES { EOAC_NONE , EOAC_MUTUAL_AUTH , EOAC_STATIC_CLOAKING , EOAC_DYNAMIC_CLOAKING ,
		// EOAC_ANY_AUTHORITY , EOAC_MAKE_FULLSIC , EOAC_DEFAULT , EOAC_SECURE_REFS , EOAC_ACCESS_CONTROL , EOAC_APPID , EOAC_DYNAMIC ,
		// EOAC_REQUIRE_FULLSIC , EOAC_AUTO_IMPERSONATE , EOAC_DISABLE_AAA , EOAC_NO_CUSTOM_MARSHAL , EOAC_RESERVED1 } EOLE_AUTHENTICATION_CAPABILITIES;
		[PInvokeData("objidlbase.h", MSDNShortId = "cf3396d0-6674-4f12-bd4a-227a8d32bc92")]
		[Flags]
		public enum EOLE_AUTHENTICATION_CAPABILITIES : uint
		{
			/// <summary>Indicates that no capability flags are set.</summary>
			EOAC_NONE = 0x0000,

			/// <summary>
			/// If this flag is specified, it will be ignored. Support for mutual authentication is automatically provided by some
			/// authentication services. See COM and Security Packages for more information.
			/// </summary>
			EOAC_MUTUAL_AUTH = 0x0001,

			/// <summary>
			/// Sets static cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
			/// However, the client's identity is determined on the first call on each proxy (if SetBlanket is not called) and each time
			/// CoSetProxyBlanket is called on the proxy. For more information about static cloaking, see Cloaking. CoInitializeSecurity and
			/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
			/// authentication service.
			/// </summary>
			EOAC_STATIC_CLOAKING = 0x0020,

			/// <summary>
			/// Sets dynamic cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
			/// On each call to a proxy, the current thread token is examined to determine whether the client's identity has changed
			/// (incurring an additional performance cost) and the client is authenticated again only if necessary. Dynamic cloaking can be
			/// set by clients only. For more information about dynamic cloaking, see Cloaking. CoInitializeSecurity and
			/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
			/// authentication service.
			/// </summary>
			EOAC_DYNAMIC_CLOAKING = 0x0040,

			/// <summary>This flag is obsolete.</summary>
			EOAC_ANY_AUTHORITY = 0x0080,

			/// <summary>
			/// Causes DCOM to send Schannel server principal names in fullsic format to clients as part of the default security negotiation.
			/// The name is extracted from the server certificate. For more information about the fullsic form, see Principal Names.
			/// </summary>
			EOAC_MAKE_FULLSIC = 0x0100,

			/// <summary>
			/// Tells DCOM to use the valid capabilities from the call to CoInitializeSecurity. If CoInitializeSecurity was not called,
			/// EOAC_NONE will be used for the capabilities flag. This flag can be set only by clients in a call to
			/// IClientSecurity::SetBlanket or CoSetProxyBlanket.
			/// </summary>
			EOAC_DEFAULT = 0x0800,

			/// <summary>
			/// Authenticates distributed reference count calls to prevent malicious users from releasing objects that are still being used.
			/// If this flag is set, which can be done only in a call to CoInitializeSecurity by the client, the authentication level (in
			/// dwAuthnLevel) cannot be set to none. The server always authenticates Release calls. Setting this flag prevents an
			/// authenticated client from releasing the objects of another authenticated client. It is recommended that clients always set
			/// this flag, although performance is affected because of the overhead associated with the extra security.
			/// </summary>
			EOAC_SECURE_REFS = 0x0002,

			/// <summary>
			/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to a GUID that is an AppID. The
			/// CoInitializeSecurity function looks up the AppID in the registry and reads the security settings from there. If this flag is
			/// set, all other parameters to CoInitializeSecurity are ignored and must be zero. Only the server can set this flag. For more
			/// information about this capability flag, see the Remarks section below. CoInitializeSecurity returns an error if both the
			/// EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
			/// </summary>
			EOAC_APPID = 0x0008,

			/// <summary>
			/// Specifying this flag helps protect server security when using DCOM or COM+. It reduces the chances of executing arbitrary
			/// DLLs because it allows the marshaling of only CLSIDs that are implemented in Ole32.dll, ComAdmin.dll, ComSvcs.dll, or Es.dll,
			/// or that implement the CATID_MARSHALER category ID. Any service that is critical to system operation should set this flag.
			/// </summary>
			EOAC_NO_CUSTOM_MARSHAL = 0x2000,

			/// <summary/>
			EOAC_RESERVED1 = 0x4000,

			/// <summary>
			/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to an IAccessControl interface on an access
			/// control object. When DCOM makes security checks, it calls IAccessControl::IsAccessAllowed. This flag is set only by the
			/// server. CoInitializeSecurity returns an error if both the EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
			/// </summary>
			EOAC_ACCESS_CONTROL = 0x0004,

			/// <summary>Reserved.</summary>
			EOAC_DYNAMIC = 0x0010,

			/// <summary>
			/// Causes DCOM to fail CoSetProxyBlanket calls where an Schannel principal name is specified in any format other than fullsic.
			/// This flag is currently for clients only. For more information about the fullsic form, see Principal Names.
			/// </summary>
			EOAC_REQUIRE_FULLSIC = 0x0200,

			/// <summary>Reserved.</summary>
			EOAC_AUTO_IMPERSONATE = 0x0400,

			/// <summary>
			/// Causes any activation where a server process would be launched under the caller's identity (activate-as-activator) to fail
			/// with E_ACCESSDENIED. This value, which can be specified only in a call to CoInitializeSecurity by the client, allows an
			/// application that runs under a privileged account (such as LocalSystem) to help prevent its identity from being used to launch
			/// untrusted components. An activation call that uses CLSCTX_ENABLE_AAA of the CLSCTX enumeration will allow
			/// activate-as-activator activations for that call.
			/// </summary>
			EOAC_DISABLE_AAA = 0x1000,
		}

		/// <summary>Flags used by <see cref="IRunningObjectTable.Register"/></summary>
		[PInvokeData("wtypes.h")]
		[Flags]
		public enum ROTFLAGS
		{
			/// <summary>When set, indicates a strong registration for the object.</summary>
			ROTFLAGS_REGISTRATIONKEEPSALIVE = 0x1,

			/// <summary>
			/// When set, any client can connect to the running object through its entry in the ROT.When not set, only clients in the window
			/// station that registered the object can connect to it.
			/// </summary>
			ROTFLAGS_ALLOWANYCLIENT = 0x2,
		}

		/// <summary>
		/// The IEnumSTATSTG interface enumerates an array of STATSTG structures. These structures contain statistical data about open
		/// storage, stream, or byte array objects.
		/// </summary>
		[ComImport, Guid("0000000D-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Objidl.h", MSDNShortId = "aa379217")]
		public interface IEnumSTATSTG
		{
			/// <summary>
			/// The Next method retrieves a specified number of STATSTG structures, that follow in the enumeration sequence. If there are
			/// fewer than the requested number of STATSTG structures that remain in the enumeration sequence, it retrieves the remaining
			/// STATSTG structures.
			/// </summary>
			/// <param name="celt">The number of STATSTG structures requested.</param>
			/// <param name="rgelt">An array of STATSTG structures returned.</param>
			/// <param name="pceltFetched">The number of STATSTG structures retrieved in the rgelt parameter.</param>
			/// <returns>
			/// This method supports the following return values: S_OK = The number of STATSTG structures returned is equal to the number
			/// specified in the celt parameter. S_FALSE = The number of STATSTG structures returned is less than the number specified in the
			/// celt parameter.
			/// </returns>
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Next([In] uint celt,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] STATSTG[] rgelt,
				out uint pceltFetched);

			/// <summary>Skips a specified number of STATSTG structures in the enumeration sequence.</summary>
			/// <param name="celt">The number of STATSTG structures to skip.</param>
			/// <returns>
			/// This method supports the following return values: S_OK = The specified number of STATSTG structures that were successfully
			/// skipped. S_FALSE = The number of STATSTG structures skipped is less than the celt parameter.
			/// </returns>
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning of the STATSTG structure array.</summary>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Reset();

			/// <summary>Creates a new enumerator that contains the same enumeration state as the current STATSTG structure enumerator.</summary>
			/// <returns>An IEnumSTATSTG interface pointer.</returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumSTATSTG Clone();
		}

		/// <summary>
		/// Enumerates objects with the IUnknown interface. It can be used to enumerate through the objects in a component containing
		/// multiple objects.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ienumunknown
		[PInvokeData("objidl.h", MSDNShortId = "5aaed96f-39c1-4201-80d0-a2a8a177b65e")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000100-0000-0000-C000-000000000046")]
		public interface IEnumUnknown
		{
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
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-next HRESULT Next( ULONG celt, IUnknown
			// **rgelt, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, ref IntPtr rgelt, out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-reset HRESULT Reset( );
			void Reset();

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later time.
			/// The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumunknown-clone HRESULT Clone( IEnumUnknown **ppenum );
			IEnumUnknown Clone();
		}

		/// <summary>
		/// Manages access to the running object table (ROT), a globally accessible look-up table on each workstation. A workstation's ROT
		/// keeps track of those objects that can be identified by a moniker and that are currently running on the workstation. When a client
		/// tries to bind a moniker to an object, the moniker checks the ROT to see if the object is already running; this allows the moniker
		/// to bind to the current instance instead of loading a new one.
		/// </summary>
		/// <remarks>
		/// <para>The ROT contains entries of the following form: (pmkObjectName, pUnkObject).</para>
		/// <para>
		/// The pmkObjectName element is a pointer to the moniker that identifies the running object. The pUnkObject element is a pointer to
		/// the running object itself. During the binding process, monikers consult the pmkObjectName entries in the ROT to see whether an
		/// object is already running.
		/// </para>
		/// <para>
		/// Objects that can be named by monikers must be registered with the ROT when they are loaded and their registration must be revoked
		/// when they are no longer running.
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
			/// When set, any client can connect to the running object through its entry in the ROT. When not set, only clients in the window
			/// station that registered the object can connect to it.
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
			/// RunAs) must not set this flag in its call to <c>Register</c>. For details on installing services, see Installing as a Service Application.
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
			/// If you are writing a server application, you should register an object with the ROT when it begins running, typically in your
			/// implementation of IOleObject::DoVerb. The object must be registered under its full moniker, which requires getting the
			/// moniker of its container document using IOleClientSite::GetMoniker. You should also revoke and re-register the object in your
			/// implementation of IOleObject::SetMoniker, which is called if the container document is renamed.
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
			/// A moniker provider (hands out monikers identifying its objects to make them accessible to others) must call the <c>Revoke</c>
			/// method to revoke the registration of its objects when it stops running. It must have previously called
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
			/// <param name="ppunkObject">
			/// A pointer to an IUnknown pointer variable that receives the interface pointer to the running object. When successful, the
			/// implementation calls AddRef on the object; it is the caller's responsibility to call Release. If the object is not running or
			/// if an error occurs, the implementation sets *ppunkObject to <c>NULL</c>.
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
			/// Generally, you call the <c>IRunningObjectTable::GetObject</c> method only if you are writing your own moniker class (that is,
			/// implementing the IMoniker interface). You typically call this method from your implementation of IMoniker::BindToObject.
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
			/// successful, the implementation calls AddRef on the enumerator; it is the caller's responsibility to call Release. If an error
			/// occurs; the implementation sets *ppenumMoniker to <c>NULL</c>.
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
		/// The IStorage interface supports the creation and management of structured storage objects. Structured storage allows hierarchical
		/// storage of information within a single file, and is often referred to as "a file system within a file". Elements of a structured
		/// storage object are storages and streams. Storages are analogous to directories, and streams are analogous to files. Within a
		/// structured storage there will be a primary storage object that may contain substorages, possibly nested, and streams. Storages
		/// provide the structure of the object, and streams contain the data, which is manipulated through the IStream interface.
		/// <para>
		/// The IStorage interface provides methods for creating and managing the root storage object, child storage objects, and stream
		/// objects. These methods can create, open, enumerate, move, copy, rename, or delete the elements in the storage object.
		/// </para>
		/// <para>
		/// An application must release its IStorage pointers when it is done with the storage object to deallocate memory used. There are
		/// also methods for changing the date and time of an element.
		/// </para>
		/// <para>
		/// There are a number of different modes in which a storage object and its elements can be opened, determined by setting values from
		/// STGM Constants. One aspect of this is how changes are committed. You can set direct mode, in which changes to an object are
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
			/// name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f characters, serving as
			/// the first character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a
			/// structured storage restriction.
			/// </param>
			/// <param name="grfMode">
			/// Specifies the access mode to use when opening the newly created stream. For more information and descriptions of the possible
			/// values, see STGM Constants.
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
			/// A string that contains the name of the newly created storage object. The name can be used later to reopen the storage object.
			/// The name must not exceed 31 characters in length, not including the string terminator. The 000 through 01f characters,
			/// serving as the first character of the stream/storage name, are reserved for use by OLE. This is a compound file restriction,
			/// not a structured storage restriction.
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
			/// A string that contains the name of the storage object to open. The 000 through 01f characters, serving as the first character
			/// of the stream/storage name, are reserved for use by OLE. This is a compound file restriction, not a structured storage
			/// restriction. It is ignored if pstgPriority is non-NULL.
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
				[In, MarshalAs(UnmanagedType.Interface)] IStorage pstgPriority,
				[In] STGM grfMode,
				[In] SNB snbExclude,
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
			void CopyTo([In] uint ciidExclude,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] rgiidExclude,
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
			/// capacity to return any error codes upon failure. Therefore, calling Release without first calling Commit causes indeterminate results.
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
			IEnumSTATSTG EnumElements([In] uint reserved1, [In, Optional] IntPtr reserved2, [In, Optional] uint reserved3);

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
			/// Either the new modification time as the first element of the array for the element or NULL if the modification time is not to
			/// be modified.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetElementTimes([In, MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pctime,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] patime,
				[In, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] FILETIME[] pmtime);

			/// <summary>The SetClass method assigns the specified class identifier (CLSID) to this storage object.</summary>
			/// <param name="clsid">The CLSID that is to be associated with the storage object.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetClass(in Guid clsid);

			/// <summary>
			/// The SetStateBits method stores up to 32 bits of state information in this storage object. This method is reserved for future use.
			/// </summary>
			/// <param name="grfStateBits">
			/// Specifies the new values of the bits to set. No legal values are defined for these bits; they are all reserved for future use
			/// and must not be used by applications.
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
		/// Identifies an authentication service, authorization service, and the authentication information for the specified authentication service.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_info typedef struct
		// tagSOLE_AUTHENTICATION_INFO { DWORD dwAuthnSvc; DWORD dwAuthzSvc; void *pAuthInfo; } SOLE_AUTHENTICATION_INFO, *PSOLE_AUTHENTICATION_INFO;
		[PInvokeData("objidl.h", MSDNShortId = "23beb1b1-e4b7-4282-9868-5caf40a69a61")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_INFO
		{
			/// <summary>
			/// <para>The authentication service. This member can be a single value from the Authentication Service Constants.</para>
			/// </summary>
			public RPC_C_AUTHN_LEVEL dwAuthnSvc;

			/// <summary>
			/// <para>The authorization service. This member can be a single value from the Authorization Constants.</para>
			/// </summary>
			public RPC_C_AUTHZ dwAuthzSvc;

			/// <summary>
			/// <para>A pointer to the authentication information, whose type is specific to the authentication service identified by <c>dwAuthnSvc</c>.</para>
			/// <para>
			/// For Schannel (RPC_C_AUTHN_GSS_SCHANNEL), this member either points to a CERT_CONTEXT structure that contains the client's
			/// X.509 certificate or is <c>NULL</c> if the client has no certificate or wishes to remain anonymous to the server.
			/// </para>
			/// <para>
			/// For NTLMSSP (RPC_C_AUTHN_WINNT) and Kerberos (RPC_C_AUTHN_GSS_KERBEROS), this member points to a SEC_WINNT_AUTH_IDENTITY or
			/// SEC_WINNT_AUTH_IDENTITY_EX structure that contains the user name and password.
			/// </para>
			/// <para>
			/// For Snego (RPC_C_AUTHN_GSS_NEGOTIATE), this member is either <c>NULL</c>, points to a SEC_WINNT_AUTH_IDENTITY structure, or
			/// points to a SEC_WINNT_AUTH_IDENTITY_EX structure. If it is <c>NULL</c>, Snego will pick a list of authentication services
			/// based on those available on the client computer. If it points to a <c>SEC_WINNT_AUTH_IDENTITY_EX</c> structure, the
			/// structure's <c>PackageList</c> member must point to a string containing a comma-separated list of authentication service
			/// names and the <c>PackageListLength</c> member must give the number of bytes in the <c>PackageList</c> string. If
			/// <c>PackageList</c> is <c>NULL</c>, all calls using Snego will fail.
			/// </para>
			/// <para>
			/// For authentication services not registered with DCOM, <c>pAuthInfo</c> must be set to <c>NULL</c> and DCOM will use the
			/// process identity to represent the client. For more information, see COM and Security Packages.
			/// </para>
			/// </summary>
			public IntPtr pAuthInfo;
		}

		/// <summary>
		/// Indicates the default authentication information to use with each authentication service. When DCOM negotiates the default
		/// authentication service for a proxy, it picks the default authentication information from this list.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_list typedef struct
		// tagSOLE_AUTHENTICATION_LIST { DWORD cAuthInfo; SOLE_AUTHENTICATION_INFO *aAuthInfo; } SOLE_AUTHENTICATION_LIST, *PSOLE_AUTHENTICATION_LIST;
		[PInvokeData("objidl.h", MSDNShortId = "21f7aef3-b6be-41cc-a6ed-16d3778e3cee")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_LIST
		{
			/// <summary>
			/// <para>The count of pointers in the array pointed to by <c>aAuthInfo</c>.</para>
			/// </summary>
			public uint cAuthInfo;

			/// <summary>
			/// An array of SOLE_AUTHENTICATION_INFO structures. Each of these structures contains an identifier for an authentication
			/// service, an identifier for the authorization service, and a pointer to authentication information to use with the specified
			/// authentication service.
			/// </summary>
			public IntPtr aAuthInfo;
		}

		/// <summary>
		/// <para>Identifies an authentication service that a server is willing to use to communicate to a client.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ns-objidl-tagsole_authentication_service typedef struct
		// tagSOLE_AUTHENTICATION_SERVICE { DWORD dwAuthnSvc; DWORD dwAuthzSvc; OLECHAR *pPrincipalName; HRESULT hr; } SOLE_AUTHENTICATION_SERVICE;
		[PInvokeData("objidl.h", MSDNShortId = "77fd15d7-54d4-4812-93d3-13a671e7afff")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SOLE_AUTHENTICATION_SERVICE
		{
			/// <summary>
			/// <para>The authentication service. This member can be a single value from the Authentication Service Constants.</para>
			/// </summary>
			public RPC_C_AUTHN_LEVEL dwAuthnSvc;

			/// <summary>
			/// <para>The authorization service. This member can be a single value from the Authorization Constants.</para>
			/// </summary>
			public RPC_C_AUTHZ dwAuthzSvc;

			/// <summary>
			/// The principal name to be used with the authentication service. If the principal name is <c>NULL</c>, the current user
			/// identifier is assumed. A <c>NULL</c> principal name is allowed for NTLMSSP, Kerberos, and Snego authentication services but
			/// may not work for other authentication services. For Schannel, this member must point to a CERT_CONTEXT structure that
			/// contains the server's certificate; if it <c>NULL</c> and if a certificate for the current user does not exist,
			/// RPC_E_NO_GOOD_SECURITY_PACKAGES is returned.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pPrincipalName;

			/// <summary>
			/// When used in CoInitializeSecurity, set on return to indicate the status of the call to register the authentication services.
			/// </summary>
			public HRESULT hr;
		}

		/// <summary>
		/// A string name block (SNB) is a pointer to an array of pointers to strings, that ends in a NULL pointer. String name blocks are
		/// used by the IStorage interface and by function calls that open storage objects. The strings point to contained storage objects or
		/// streams that are to be excluded in the open calls.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public class SNB : IDisposable
		{
			private SafeCoTaskMemHandle ptr;

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