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
		public enum ACTIVATIONTYPE
		{
			ACTIVATIONTYPE_UNCATEGORIZED = 0x0,
			ACTIVATIONTYPE_FROM_MONIKER = 0x1,
			ACTIVATIONTYPE_FROM_DATA = 0x2,
			ACTIVATIONTYPE_FROM_STORAGE = 0x4,
			ACTIVATIONTYPE_FROM_STREAM = 0x8,
			ACTIVATIONTYPE_FROM_FILE = 0x10
		}

		/// <summary>Controls aspects of moniker binding operations.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ne-objidl-tagbind_flags typedef enum tagBIND_FLAGS {
		// BIND_MAYBOTHERUSER, BIND_JUSTTESTEXISTENCE } BIND_FLAGS;
		[PInvokeData("objidl.h", MSDNShortId = "e8884e82-5de2-4a1f-b79c-d431afe9e87e")]
		[Flags]
		public enum BIND_FLAGS
		{
			/// <summary>
			/// If this flag is specified, the moniker implementation can interact with the end user. Otherwise, the moniker implementation
			/// should not interact with the user in any way, such as by asking for a password for a network volume that needs mounting. If
			/// prohibited from interacting with the user when it otherwise would, a moniker implementation can use a different algorithm
			/// that does not require user interaction, or it can fail with the error MK_E_MUSTBOTHERUSER.
			/// </summary>
			BIND_MAYBOTHERUSER = 1,

			/// <summary>
			/// If this flag is specified, the caller is not interested in having the operation carried out, but only in learning whether the
			/// operation could have been carried out had this flag not been specified. For example, this flag lets the caller indicate only
			/// an interest in finding out whether an object actually exists by using this flag in a IMoniker::BindToObject call. Moniker
			/// implementations can, however, ignore this possible optimization and carry out the operation in full. Callers must be able to
			/// deal with both cases.
			/// </summary>
			BIND_JUSTTESTEXISTENCE = 2,
		}

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

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000017-0000-0000-C000-000000000046")]
		public interface IActivationFilter
		{
			Guid HandleActivation(ACTIVATIONTYPE dwActivationType, in Guid rclsid);
		}

		/// <summary>Marks an interface as agile across apartments.</summary>
		/// <remarks>
		/// <para>
		/// The <c>IAgileObject</c> interface is a marker interface that indicates that an object is free threaded and can be called from any apartment.
		/// </para>
		/// <para>
		/// Unlike what happens when aggregating the Free Threaded Marshaler (FTM), implementing the <c>IAgileObject</c> interface doesn't
		/// affect what happens when marshaling a call. Instead, the <c>IAgileObject</c> interface is recognized by the Global Interface
		/// Table (GIT). When an object that implements the <c>IAgileObject</c> interface is placed in the GIT and localized to another
		/// apartment, the object is called directly in the new apartment, rather than marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-iagileobject
		[PInvokeData("objidl.h", MSDNShortId = "787A22DE-AEAB-4570-BB97-C49D656E5D40")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("94ea2b94-e9cc-49e0-c0ff-ee64ca8f5b90")]
		public interface IAgileObject
		{
		}

		/// <summary>Enables retrieving an agile reference to an object.</summary>
		/// <remarks>Call the RoGetAgileReference function to create an agile reference to an object.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-iagilereference
		[PInvokeData("objidl.h", MSDNShortId = "51787A45-BCDE-4028-A338-1C16F2DE79AD")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("C03F6A43-65A4-9818-987E-E0B810D2A6F2")]
		public interface IAgileReference
		{
			/// <summary>Gets the interface ID of an agile reference to an object.</summary>
			/// <param name="riid">The riid.</param>
			/// <returns>On successful completion, *ppvObjectReference is a pointer to the interface specified by riid.</returns>
			/// <remarks>
			/// Call the RoGetAgileReference function to create an agile reference to an object. Call the <c>Resolve</c> method to localize
			/// the object into the apartment in which <c>Resolve</c> is called.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-iagilereference-resolve%28q_%29 HRESULT __clrcall
			// Resolve( Q **pp, );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object Resolve(in Guid riid);
		}

		/// <summary>
		/// Provides access to a bind context, which is an object that stores information about a particular moniker binding operation.
		/// </summary>
		/// <remarks>
		/// <para>A bind context includes the following information:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A BIND_OPTS structure containing a set of parameters that do not change during the binding operation. When a composite moniker is
		/// bound, each component uses the same bind context, so it acts as a mechanism for passing the same parameters to each component of
		/// a composite moniker.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A set of pointers to objects that the binding operation has activated. The bind context holds pointers to these bound objects,
		/// keeping them loaded and thus eliminating redundant activations if the objects are needed again during subsequent binding operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A pointer to the running object table (ROT) on the same computer as the process that started the bind operation. Moniker
		/// implementations that need to access the ROT should use the IBindCtx::GetRunningObjectTable method rather than using the
		/// GetRunningObjectTable function. This allows future enhancements to the system's <c>IBindCtx</c> implementation to modify binding behavior.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A table of interface pointers, each associated with a string key. This capability enables moniker implementations to store
		/// interface pointers under a well-known string so that they can later be retrieved from the bind context. For example, OLE defines
		/// several string keys ("ExceededDeadline", "ConnectManually", and so on) that can be used to store a pointer to the object that
		/// caused an error during a binding operation.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ibindctx
		[PInvokeData("objidl.h", MSDNShortId = "e4c8abb5-0c89-44dd-8d95-efbfcc999b46")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000000e-0000-0000-C000-000000000046")]
		public interface IBindCtxV
		{
			/// <summary>
			/// Registers an object with the bind context to ensure that the object remains active until the bind context is released.
			/// </summary>
			/// <param name="punk">A pointer to the IUnknown interface on the object that is being registered as bound.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// Those writing a new moniker class (through an implementation of the IMoniker interface) should call this method whenever the
			/// implementation activates an object. This happens most often in the course of binding a moniker, but it can also happen while
			/// retrieving a moniker's display name, parsing a display name into a moniker, or retrieving the time that an object was last modified.
			/// </para>
			/// <para>
			/// <c>RegisterObjectBound</c> calls AddRef to create an additional reference to the object. You must, however, still release
			/// your own copy of the pointer. Calling this method twice for the same object creates two references to that object. You can
			/// release a reference obtained through a call to this method by calling IBindCtx::RevokeObjectBound. All references held by the
			/// bind context are released when the bind context itself is released.
			/// </para>
			/// <para>
			/// Calling <c>RegisterObjectBound</c> to register an object with a bind context keeps the object active until the bind context
			/// is released. Reusing a bind context in a subsequent binding operation (either for another piece of the same composite moniker
			/// or for a different moniker) can make the subsequent binding operation more efficient because it doesn't have to reload that
			/// object. This, however, improves performance only if the subsequent binding operation requires some of the same objects as the
			/// original one, so you need to balance the possible performance improvement of reusing a bind context against the costs of
			/// keeping objects activated unnecessarily.
			/// </para>
			/// <para>
			/// IBindCtx does not provide a method to retrieve a pointer to an object registered using <c>RegisterObjectBound</c>. Assuming
			/// the object has registered itself with the running object table, moniker implementations can call
			/// IRunningObjectTable::GetObject to retrieve a pointer to the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-registerobjectbound HRESULT
			// RegisterObjectBound( IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "84d49231-5fdd-4a89-8e76-1f0e56bc553f")]
			[PreserveSig]
			HRESULT RegisterObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Removes the object from the bind context, undoing a previous call to RegisterObjectBound.</summary>
			/// <param name="punk">A pointer to the IUnknown interface on the object to be removed.</param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The object was released successfully.</term>
			/// </item>
			/// <item>
			/// <term>MK_E_NOTBOUND</term>
			/// <term>The object was not previously registered.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>You would rarely call this method. It is documented primarily for completeness.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-revokeobjectbound HRESULT RevokeObjectBound(
			// IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "c49421a3-1733-4f54-8e30-d23641f13c38")]
			[PreserveSig]
			HRESULT RevokeObjectBound([In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>Releases all pointers to all objects that were previously registered by calls to RegisterObjectBound.</summary>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks>
			/// <para>
			/// You rarely call this method directly. The system's IBindCtx implementation calls this method when the pointer to the
			/// <c>IBindCtx</c> interface on the bind context is released (the bind context is released). If a bind context is not released,
			/// all of the registered objects remain active.
			/// </para>
			/// <para>
			/// If the same object has been registered more than once, this method calls the Release method on the object the number of times
			/// it was registered.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-releaseboundobjects HRESULT
			// ReleaseBoundObjects( );
			[PInvokeData("objidl.h", MSDNShortId = "12107633-6e7f-4d41-8e5c-5739cff98552")]
			[PreserveSig]
			HRESULT ReleaseBoundObjects();

			/// <summary>Sets new values for the binding parameters stored in the bind context.</summary>
			/// <param name="pbindopts">A pointer to a BIND_OPTS, BIND_OPTS2, or BIND_OPTS3 structure containing the binding parameters.</param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// A bind context contains a block of parameters that are common to most IMoniker operations. These parameters do not change as
			/// the operation moves from piece to piece of a composite moniker.
			/// </para>
			/// <para>Subsequent binding operations can call IBindCtx::GetBindOptions to retrieve these parameters.</para>
			/// <para>Notes to Callers</para>
			/// <para>This method can be called by moniker clients (those who use monikers to acquire interface pointers to objects).</para>
			/// <para>
			/// When you first create a bind context by using the CreateBindCtx function, the fields of the BIND_OPTS structure are
			/// initialized to the following values:
			/// </para>
			/// <para>
			/// You can use the <c>IBindCtx::SetBindOptions</c> method to modify these values before using the bind context, if you want
			/// values other than the defaults.
			/// </para>
			/// <para>
			/// <c>SetBindOptions</c> copies the members of the specified structure, but not the COSERVERINFO structure and the pointers it
			/// contains. Callers may not free these pointers until the bind context is released.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-setbindoptions HRESULT SetBindOptions(
			// BIND_OPTS *pbindopts );
			[PInvokeData("objidl.h", MSDNShortId = "9dcce48e-567e-42b4-8df2-2bc861cb5fcb")]
			[PreserveSig]
			HRESULT SetBindOptions([In] BIND_OPTS_V pbindopts);

			/// <summary>Retrieves the binding options stored in this bind context.</summary>
			/// <param name="pbindopts">
			/// A pointer to an initialized structure that receives the current binding parameters on return. See BIND_OPTS, BIND_OPTS2, and BIND_OPTS3.
			/// </param>
			/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// A bind context contains a block of parameters that are common to most IMoniker operations and that do not change as the
			/// operation moves from piece to piece of a composite moniker.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You typically call this method if you are writing your own moniker class. (This requires that you implement the IMoniker
			/// interface.) You call this method to retrieve the parameters specified by the moniker client.
			/// </para>
			/// <para>
			/// You must initialize the structure that is filled in by this method. Before calling this method, you must initialize the
			/// <c>cbStruct</c> member to the size of the structure.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getbindoptions HRESULT GetBindOptions(
			// BIND_OPTS *pbindopts );
			[PInvokeData("objidl.h", MSDNShortId = "ccb239ee-922f-4e66-8aca-7651c0243a2b")]
			[PreserveSig]
			HRESULT GetBindOptions([In, Out] BIND_OPTS_V pbindopts);

			/// <summary>
			/// Retrieves an interface pointer to the running object table (ROT) for the computer on which this bind context is running.
			/// </summary>
			/// <param name="pprot">
			/// The address of a IRunningObjectTable* pointer variable that receives the interface pointer to the running object table. If an
			/// error occurs, *pprot is set to <c>NULL</c>. If *pprot is non- <c>NULL</c>, the implementation calls AddRef on the running
			/// table object; it is the caller's responsibility to call Release.
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// The running object table is a globally accessible table on each computer. It keeps track of all the objects that are
			/// currently running on the computer.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Typically, those implementing a new moniker class (through an implementation of IMoniker interface) call
			/// <c>GetRunningObjectTable</c>. It is useful to call this method in an implementation of IMoniker::BindToObject or
			/// IMoniker::IsRunning to check whether an object is currently running. You can also call this method in the implementation of
			/// IMoniker::GetTimeOfLastChange to learn when a running object was last modified.
			/// </para>
			/// <para>
			/// Moniker implementations should call this method instead of using the <c>GetRunningObjectTable</c> function. This makes it
			/// possible for future implementations of IBindCtx to modify binding behavior.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getrunningobjecttable HRESULT
			// GetRunningObjectTable( IRunningObjectTable **pprot );
			[PInvokeData("objidl.h", MSDNShortId = "26938d07-d772-4e72-a6aa-57dd2f2cece1")]
			[PreserveSig]
			HRESULT GetRunningObjectTable(out IRunningObjectTable pprot);

			/// <summary>Associates an object with a string key in the bind context's string-keyed table of pointers.</summary>
			/// <param name="pszKey">The bind context string key under which the object is being registered. Key string comparison is case-sensitive.</param>
			/// <param name="punk">
			/// <para>A pointer to the IUnknown interface on the object that is to be registered.</para>
			/// <para>The method calls AddRef on the pointer.</para>
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between
			/// a moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under
			/// a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>Binding operations subsequent to the use of this method can use IBindCtx::GetObjectParam to retrieve the stored pointer.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// <c>RegisterObjectParam</c> is useful to those implementing a new moniker class (through an implementation of IMoniker) and to
			/// moniker clients (those who use monikers to bind to objects).
			/// </para>
			/// <para>
			/// In implementing a new moniker class, you call this method when an error occurs during moniker binding to inform the caller of
			/// the cause of the error. The key that you would obtain with a call to this method would depend on the error condition.
			/// Following is a list of common moniker binding errors, describing for each the keys that would be appropriate:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// MK_E_EXCEEDEDDEADLINEâ€”If a binding operation exceeds its deadline because a given object is not running, you should
			/// register the object's moniker using the first unused key from the list: "ExceededDeadline", "ExceededDeadline1",
			/// "ExceededDeadline2", and so on. If the caller later finds the moniker in the running object table, the caller can retry the
			/// binding operation.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// MK_E_CONNECTMANUALLYâ€”The "ConnectManually" key indicates a moniker whose binding requires assistance from the end user. To
			/// request that the end user manually connect to the object, the caller can retry the binding operation after showing the
			/// moniker's display name. Common reasons for this error are that a password is needed or that a floppy needs to be mounted.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// E_CLASSNOTFOUNDâ€”The "ClassNotFound" key indicates a moniker whose class could not be found. (The server for the object
			/// identified by this moniker could not be located.) If this key is used for an OLE compound-document object, the caller can use
			/// IMoniker::BindToStorage to bind to the object and then try to carry out a <c>Treat As...</c> or <c>Convert To...</c>
			/// operation to associate the object with a different server. If this is successful, the caller can retry the binding operation.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// A moniker client with detailed knowledge of the implementation of the moniker can also call this method to pass private
			/// information to that implementation.
			/// </para>
			/// <para>
			/// You can define new strings as keys for storing pointers. By convention, you should use key names that begin with the string
			/// form of the CLSID of the moniker class. (See the StringFromCLSID function.)
			/// </para>
			/// <para>
			/// If the pszKey parameter matches the name of an existing key in the bind context's table, the new object replaces the existing
			/// object in the table.
			/// </para>
			/// <para>When you register an object using this method, the object is not released until one of the following occurs:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>It is replaced in the table by another object with the same key.</term>
			/// </item>
			/// <item>
			/// <term>It is removed from the table by a call to IBindCtx::RevokeObjectParam.</term>
			/// </item>
			/// <item>
			/// <term>The bind context is released. All registered objects are released when the bind context is released.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-registerobjectparam HRESULT
			// RegisterObjectParam( LPOLESTR pszKey, IUnknown *punk );
			[PInvokeData("objidl.h", MSDNShortId = "7ee2b5b2-9b9c-41f1-8e58-7432ebc0f9ed")]
			[PreserveSig]
			HRESULT RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [In, MarshalAs(UnmanagedType.Interface)] object punk);

			/// <summary>
			/// Retrieves an interface pointer to the object associated with the specified key in the bind context's string-keyed table of pointers.
			/// </summary>
			/// <param name="pszKey">The bind context string key to be searched for. Key string comparison is case-sensitive.</param>
			/// <param name="ppunk">
			/// The address of an IUnknown* pointer variable that receives the interface pointer to the object associated with pszKey. When
			/// successful, the implementation calls AddRef on *ppunk. It is the caller's responsibility to call Release. If an error occurs,
			/// the implementation sets *ppunk to <c>NULL</c>.
			/// </param>
			/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
			/// <remarks>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between
			/// a moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under
			/// a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// The pointer this method retrieves must have previously been inserted into the table using the IBindCtx::RegisterObjectParam method.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Objects using monikers to locate other objects can call this method when a binding operation fails to get specific
			/// information about the error that occurred. Depending on the error, it may be possible to correct the situation and retry the
			/// binding operation. See IBindCtx::RegisterObjectParam for more information.
			/// </para>
			/// <para>
			/// Moniker implementations can call this method to handle situations where a caller initiates a binding operation and requests
			/// specific information. By convention, the implementer should use key names that begin with the string form of the CLSID of a
			/// moniker class. (See the StringFromCLSID function.)
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-getobjectparam HRESULT GetObjectParam( LPOLESTR
			// pszKey, IUnknown **ppunk );
			[PInvokeData("objidl.h", MSDNShortId = "8f423495-7a34-4901-968e-1fe204680d8a")]
			[PreserveSig]
			HRESULT GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

			/// <summary>
			/// Retrieves a pointer to an interface that can be used to enumerate the keys of the bind context's string-keyed table of pointers.
			/// </summary>
			/// <param name="ppenum">
			/// The address of an IEnumString* pointer variable that receives the interface pointer to the enumerator. If an error occurs,
			/// *ppenum is set to <c>NULL</c>. If *ppenum is non- <c>NULL</c>, the implementation calls AddRef on *ppenum; it is the caller's
			/// responsibility to call Release.
			/// </param>
			/// <returns>This method can return the standard return values E_OUTOFMEMORY and S_OK.</returns>
			/// <remarks>
			/// <para>The keys returned by the enumerator are the ones previously specified in calls to IBindCtx::RegisterObjectParam.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between
			/// a moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under
			/// a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// In the system implementation of the IBindCtx interface, this method is not implemented. Therefore, calling this method
			/// results in a return value of E_NOTIMPL.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-enumobjectparam HRESULT EnumObjectParam(
			// IEnumString **ppenum );
			[PInvokeData("objidl.h", MSDNShortId = "9e799ce4-e9b3-4b31-98a0-2167a0c19848")]
			[PreserveSig]
			HRESULT EnumObjectParam(out IEnumString ppenum);

			/// <summary>
			/// Removes the specified key and its associated pointer from the bind context's string-keyed table of objects. The key must have
			/// previously been inserted into the table with a call to RegisterObjectParam.
			/// </summary>
			/// <param name="pszKey">The bind context string key to be removed. Key string comparison is case-sensitive.</param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The specified key was removed successfully.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The object was not previously registered.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A bind context maintains a table of interface pointers, each associated with a string key. This enables communication between
			/// a moniker implementation and the caller that initiated the binding operation. One party can store an interface pointer under
			/// a string known to both parties so that the other party can later retrieve it from the bind context.
			/// </para>
			/// <para>
			/// This method is used to remove an entry from the table. If the specified key is found, the bind context also releases its
			/// reference to the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ibindctx-revokeobjectparam HRESULT RevokeObjectParam(
			// LPOLESTR pszKey );
			[PInvokeData("objidl.h", MSDNShortId = "e7dbf9c8-0ecf-4076-8bec-4da457c60cee")]
			[PreserveSig]
			HRESULT RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
		}

		/// <summary>Supports setting COM+ context properties.</summary>
		/// <remarks>An instance of this interface for the current context can be obtained using CoGetObjectContext.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-icontext
		[PInvokeData("objidl.h", MSDNShortId = "89c41d9c-186c-4927-990d-92aa501f7d35")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000001c0-0000-0000-C000-000000000046")]
		public interface IContext
		{
			/// <summary>Adds the specified context property to the object context.</summary>
			/// <param name="rpolicyId">A GUID that uniquely identifies this context property.</param>
			/// <param name="flags">This parameter is reserved and must be zero.</param>
			/// <param name="pUnk">A pointer to the context property to be added.</param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-setproperty HRESULT SetProperty( REFGUID
			// rpolicyId, CPFLAGS flags, IUnknown *pUnk );
			void SetProperty(in Guid rpolicyId, [Optional] uint flags, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);

			/// <summary>Removes the specified context property from the context.</summary>
			/// <param name="rPolicyId">The GUID that uniquely identifies the context property to be removed.</param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-removeproperty HRESULT RemoveProperty( REFGUID
			// rPolicyId );
			void RemoveProperty(in Guid rPolicyId);

			/// <summary>Retrieves the specified context property from the context.</summary>
			/// <param name="rGuid">The GUID that uniquely identifies the context property to be retrieved.</param>
			/// <param name="pFlags">The address of the variable that receives the flags associated with the property.</param>
			/// <returns>The address of the variable that receives the IUnknown interface pointer of the requested context property.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-getproperty HRESULT GetProperty( REFGUID rGuid,
			// CPFLAGS *pFlags, IUnknown **ppUnk );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetProperty(in Guid rGuid, out uint pFlags);

			/// <summary>
			/// Returns an IEnumContextProps interface pointer that can be used to enumerate the context properties in this context.
			/// </summary>
			/// <returns>The address of the variable that receives the new IEnumContextProps interface pointer.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-enumcontextprops HRESULT EnumContextProps(
			// IEnumContextProps **ppEnumContextProps );
			IEnumContextProps EnumContextProps();
		}

		/// <summary>Provides a mechanism for enumerating the context properties associated with a COM+ object context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ienumcontextprops
		[PInvokeData("objidl.h", MSDNShortId = "64591e45-5478-4360-8c1f-08b09b5aef8e")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000001c1-0000-0000-C000-000000000046")]
		public interface IEnumContextProps
		{
			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="pContextProperties">
			/// <para>An array of enumerated items.</para>
			/// <para>
			/// The enumerator is responsible for allocating any memory, and the caller is responsible for freeing it. If celt is greater
			/// than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-next HRESULT Next( ULONG celt,
			// ContextProperty *pContextProperties, ULONG *pceltFetched );
			[PreserveSig]
			HRESULT Next(uint celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ContextProperty[] pContextProperties,
				 out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-skip HRESULT Skip( ULONG celt );
			[PreserveSig]
			HRESULT Skip(uint celt);

			/// <summary>
			/// <para>Resets the enumeration sequence to the beginning.</para>
			/// </summary>
			/// <returns>
			/// <para>The return value is S_OK.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-reset HRESULT Reset( );
			void Reset();

			/// <summary>
			/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
			/// <para>
			/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later time.
			/// The caller must release this new enumerator separately from the first enumerator.
			/// </para>
			/// </summary>
			/// <returns>A pointer to the cloned enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-clone HRESULT Clone( IEnumContextProps
			// **ppEnumContextProps );
			IEnumContextProps Clone();

			/// <summary>Retrieves the number of context properties in the context.</summary>
			/// <returns>The count of items in the sequence.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-count HRESULT Count( ULONG *pcelt );
			uint Count();
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

		/// <summary>Allocates, frees, and manages memory.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-imalloc
		[PInvokeData("objidl.h", MSDNShortId = "047f281e-2665-4d6d-9a0b-918cd3339447")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000002-0000-0000-C000-000000000046")]
		public interface IMalloc
		{
			/// <summary>Allocates a block of memory.</summary>
			/// <param name="cb">The size of the memory block to be allocated, in bytes.</param>
			/// <returns>
			/// <para>If the method succeeds, the return value is a pointer to the allocated block of memory. Otherwise, it is <c>NULL</c>.</para>
			/// <para>
			/// Applications should always check the return value from this method, even when requesting small amounts of memory, because
			/// there is no guarantee the memory will be allocated.
			/// </para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The initial contents of the returned memory block are undefined, there is no guarantee that the block has been initialized,
			/// so you should initialize it in your code. The allocated block may be larger than cb bytes because of the space required for
			/// alignment and for maintenance information.
			/// </para>
			/// <para>
			/// If cb is zero, <c>Alloc</c> allocates a zero-length item and returns a valid pointer to that item. If there is insufficient
			/// memory available, <c>Alloc</c> returns <c>NULL</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-alloc void * Alloc( SIZE_T cb );
			[PreserveSig]
			IntPtr Alloc(SizeT cb);

			/// <summary>Changes the size of a previously allocated block of memory.</summary>
			/// <param name="pv">
			/// A pointer to the block of memory to be reallocated. This parameter can be <c>NULL</c>, as discussed in the Remarks section below.
			/// </param>
			/// <param name="cb">
			/// The size of the memory block to be reallocated, in bytes. This parameter can be 0, as discussed in the Remarks section below.
			/// </param>
			/// <returns>If the method succeeds, the return value is a pointer to the reallocated block of memory. Otherwise, it is <c>NULL</c>.</returns>
			/// <remarks>
			/// <para>
			/// This method reallocates a block of memory, but does not guarantee that its contents are initialized. Therefore, the caller is
			/// responsible for subsequently initializing the memory. The allocated block may be larger than cb bytes because of the space
			/// required for alignment and for maintenance information.
			/// </para>
			/// <para>
			/// The pv argument points to the beginning of the block. If pv is <c>NULL</c>, <c>Realloc</c> allocates a new memory block in
			/// the same way that IMalloc::Alloc does. If pv is not <c>NULL</c>, it should be a pointer returned by a prior call to <c>Alloc</c>.
			/// </para>
			/// <para>
			/// The cb argument specifies the size of the new block, in bytes. The contents of the block are unchanged up to the shorter of
			/// the new and old sizes, although the new block can be in a different location. Because the new block can be in a different
			/// memory location, the pointer returned by <c>Realloc</c> is not guaranteed to be the pointer passed through the pv argument.
			/// If pv is not <c>NULL</c> and cb is zero, the memory pointed to by pv is freed.
			/// </para>
			/// <para>
			/// <c>Realloc</c> returns a void pointer to the reallocated (and possibly moved) block of memory. The return value is
			/// <c>NULL</c> if the size is zero and the buffer argument is not <c>NULL</c>, or if there is not enough memory available to
			/// expand the block to the specified size. In the first case, the original block is freed; in the second, the original block is unchanged.
			/// </para>
			/// <para>
			/// The storage space pointed to by the return value is guaranteed to be suitably aligned for storage of any type of object. To
			/// get a pointer to a type other than <c>void</c>, use a type cast on the return value.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-realloc void * Realloc( void *pv, SIZE_T cb );
			[PreserveSig]
			IntPtr Realloc([In, Optional] IntPtr pv, SizeT cb);

			/// <summary>Frees a previously allocated block of memory.</summary>
			/// <param name="pv">A pointer to the memory block to be freed. If this parameter is <c>NULL</c>, this method has no effect.</param>
			/// <remarks>
			/// This method frees a block of memory previously allocated through a call to IMalloc::Alloc or IMalloc::Realloc. The number of
			/// bytes freed equals the number of bytes that were allocated. After the call, the block of memory pointed to by pv is invalid
			/// and can no longer be used.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-free void Free( void *pv );
			[PreserveSig]
			void Free([In, Optional] IntPtr pv);

			/// <summary>Retrieves the size of a previously allocated block of memory.</summary>
			/// <param name="pv">A pointer to the block of memory.</param>
			/// <returns>The size of the allocated memory block in bytes or, if pv is a <c>NULL</c> pointer, -1.</returns>
			/// <remarks>
			/// To get the size in bytes of a memory block, the block must have been previously allocated with IMalloc::Alloc or
			/// IMalloc::Realloc. The size returned is the actual size of the allocation, which may be greater than the size requested when
			/// the allocation was made.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-getsize SIZE_T GetSize( void *pv );
			[PreserveSig]
			SizeT GetSize([In, Optional] IntPtr pv);

			/// <summary>Determines whether this allocator was used to allocate the specified block of memory.</summary>
			/// <param name="pv">A pointer to the block of memory. If this parameter is a <c>NULL</c> pointer, -1 is returned.</param>
			/// <returns>
			/// <para>This method can return the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>The block of memory was allocated by this allocator.</term>
			/// </item>
			/// <item>
			/// <term>0</term>
			/// <term>The block of memory was not allocated by this allocator.</term>
			/// </item>
			/// <item>
			/// <term>-1</term>
			/// <term>This method cannot determine whether this allocator allocated the block of memory.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-didalloc int DidAlloc( void *pv );
			[PreserveSig]
			int DidAlloc([In, Optional] IntPtr pv);

			/// <summary>
			/// Minimizes the heap as much as possible by releasing unused memory to the operating system, coalescing adjacent free blocks,
			/// and committing free pages.
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imalloc-heapminimize void HeapMinimize( );
			[PreserveSig]
			void HeapMinimize();
		}

		/// <summary>Enables a COM object to define and manage the marshaling of its interface pointers.</summary>
		/// <remarks>
		/// <para>
		/// Marshaling is the process of packaging data into packets for transmission to a different process or computer. Unmarshaling is the
		/// process of recovering that data at the receiving end. In any given call, method arguments are marshaled and unmarshaled in one
		/// direction, while return values are marshaled and unmarshaled in the other.
		/// </para>
		/// <para>
		/// Although marshaling applies to all data types, interface pointers require special handling. The fundamental problem is how client
		/// code running in one address space can correctly dereference a pointer to an interface on an object residing in a different
		/// address space. The COM solution is for a client application to communicate with the original object through a surrogate object,
		/// or proxy, which lives in the client's process. The proxy holds a reference to an interface on the original object and hands the
		/// client a pointer to an interface on itself. When the client calls an interface method on the original object, its call is
		/// actually going to the proxy. Therefore, from the client's point of view, all calls are in-process.
		/// </para>
		/// <para>
		/// On receiving a call, the proxy marshals the method arguments and through some means of interprocess communication, such as RPC,
		/// passes them along to code in the server process, which unmarshals the arguments and passes them to the original object. This same
		/// code marshals return values for transmission back to the proxy, which unmarshals the values and passes them to the client application.
		/// </para>
		/// <para>
		/// <c>IMarshal</c> provides methods for creating, initializing, and managing a proxy in a client process; it does not dictate how
		/// the proxy should communicate with the original object. The COM default implementation of <c>IMarshal</c> uses RPC. When you
		/// implement this interface yourself, you are free to choose any method of interprocess communication you deem to be appropriate for
		/// your application—shared memory, named pipe, window handle, RPC—in short, whatever works.
		/// </para>
		/// <para>IMarshal Default Implementation</para>
		/// <para>
		/// COM uses its own internal implementation of the <c>IMarshal</c> interface to marshal any object that does not provide its own
		/// implementation. COM makes this determination by querying the object for <c>IMarshal</c>. If the interface is missing, COM
		/// defaults to its internal implementation.
		/// </para>
		/// <para>
		/// The COM default implementation of <c>IMarshal</c> uses a generic proxy for each object and creates individual stubs and proxies,
		/// as they are needed, for each interface implemented on the object. This mechanism is necessary because COM cannot know in advance
		/// what particular interfaces a given object may implement. Developers who do not use COM default marshaling, electing instead to
		/// write their own proxy and marshaling routines, know at compile time all the interfaces to be found on their objects and therefore
		/// understand exactly what marshaling code is required. COM, in providing marshaling support for all objects, must do so at run time.
		/// </para>
		/// <para>
		/// The interface proxy resides in the client process; the interface stub resides in the server. Together, each pair handles all
		/// marshaling for the interface. The job of each interface proxy is to marshal arguments and unmarshal return values and out
		/// parameters that are passed back and forth in subsequent calls to its interface. The job of each interface stub is to unmarshal
		/// function arguments and pass them along to the original object and then marshal the return values and out parameters that the
		/// object returns.
		/// </para>
		/// <para>
		/// Proxy and stub communicate by means of an RPC (remote procedure call) channel, which utilizes the system's RPC infrastructure for
		/// interprocess communication. The RPC channel implements a single interface, IRpcChannelBuffer, to which both interface proxies and
		/// stubs hold a pointer. The proxy and stub call the interface to obtain a marshaling packet, send the data to their counterpart,
		/// and destroy the packet when they are done. The interface stub also holds a pointer to the original object.
		/// </para>
		/// <para>
		/// For any given interface, the proxy and stub are both implemented as instances of the same class, which is listed for each
		/// interface in the system registry under the label <c>ProxyStubClsid32</c>. This entry maps the interface's IID to the <c>CLSID</c>
		/// of its proxy and stub objects. When COM needs to marshal an interface, it looks in the system registry to obtain the appropriate
		/// <c>CLSID</c>. The server identified by this <c>CLSID</c> implements both the interface proxy and interface stub.
		/// </para>
		/// <para>
		/// Most often, the class to which this <c>CLSID</c> refers is automatically generated by a tool whose input is a description of the
		/// function signatures and semantics of a given interface, written in some interface description language. While using such a
		/// language is highly recommended and encouraged for accuracy's sake, doing so is not required. Proxies and stubs are merely COM
		/// components used by the RPC infrastructure and, as such, can be written in any manner desired, as long as the correct external
		/// contracts are upheld. The programmer who designs a new interface is responsible for ensuring that all interface proxies and stubs
		/// that ever exist agree on the representation of their marshaled data.
		/// </para>
		/// <para>
		/// When created, interface proxies are always aggregated into a larger proxy, which represents the object as a whole. This object
		/// proxy also aggregates the COM generic proxy object, which is known as the proxy manager. The proxy manager implements two
		/// interfaces: IUnknown and <c>IMarshal</c>. All of the other interfaces that may be implemented on an object are exposed in its
		/// object proxy through the aggregation of individual interface proxies. A client holding a pointer to the object proxy "believes"
		/// it holds a pointer to the actual object.
		/// </para>
		/// <para>
		/// A proxy representing the object as a whole is required in the client process so that a client can distinguish calls to the same
		/// interfaces implemented on entirely different objects. Such a requirement does not exist in the server process, however, where the
		/// object itself resides, because all interface stubs communicate only with the objects for which they were created. No other
		/// connection is possible.
		/// </para>
		/// <para>
		/// Interface stubs, by contrast with interface proxies, are not aggregated because there is no need that they appear to some
		/// external client to be part of a larger whole. When connected, an interface stub is given a pointer to the server object to which
		/// it should forward method invocations that it receives. Although it is useful to refer conceptually to a stub manager, meaning
		/// whatever pieces of code and state in the server-side RPC infrastructure that service the remoting of a given object, there is no
		/// direct requirement that the code and state take any particular, well-specified form.
		/// </para>
		/// <para>
		/// The first time a client requests a pointer to an interface on a particular object, COM loads an IClassFactory stub in the server
		/// process and uses it to marshal the first pointer back to the client. In the client process, COM loads the generic proxy for the
		/// class factory object and calls its implementation of <c>IMarshal</c> to unmarshal that first pointer. COM then creates the first
		/// interface proxy and hands it a pointer to the RPC channel. Finally, COM returns the <c>IClassFactory</c> pointer to the client,
		/// which uses it to call IClassFactory::CreateInstance, passing it a reference to the interface.
		/// </para>
		/// <para>
		/// Back in the server process, COM now creates a new instance of the object, along with a stub for the requested interface. This
		/// stub marshals the interface pointer back to the client process, where another object proxy is created, this time for the object
		/// itself. Also created is a proxy for the requested interface, a pointer to which is returned to the client. With subsequent calls
		/// to other interfaces on the object, COM will load the appropriate interface stubs and proxies as needed.
		/// </para>
		/// <para>
		/// When a new interface proxy is created, COM hands it a pointer to the proxy manager's implementation of IUnknown, to which it
		/// delegates all QueryInterface calls. Each interface proxy implements two interfaces of its own: the interface it represents and
		/// IRpcProxyBuffer. The interface proxy exposes its own interface directly to clients, which can obtain its pointer by calling
		/// <c>QueryInterface</c> on the proxy manager. Only COM, however, can call <c>IRpcProxyBuffer</c>, which is used to connect and
		/// disconnect the proxy to the RPC channel. A client cannot query an interface proxy to obtain a pointer to the
		/// <c>IRpcProxyBuffer</c> interface.
		/// </para>
		/// <para>
		/// On the server side, each interface stub implements IRpcStubBuffer. The server code acting as a stub manager calls
		/// IRpcStubBuffer::Connect and passes the interface stub the IUnknown pointer of its object.
		/// </para>
		/// <para>
		/// When an interface proxy receives a method invocation, it obtains a marshaling packet from its RPC channel through a call to
		/// IRpcChannelBuffer::GetBuffer. The process of marshaling the arguments will copy data into the buffer. When marshaling is
		/// complete, the interface proxy invokes IRpcChannelBuffer::SendReceive to send the marshaled packet to the corresponding interface
		/// stub. When <c>IRpcChannelBuffer::SendReceive</c> returns, the buffer into which the arguments were marshaled will have been
		/// replaced by a new buffer containing the return values marshaled from the interface stub. The interface proxy unmarshals the
		/// return values, invokes IRpcChannelBuffer::FreeBuffer to free the buffer, and then returns the return values to the original
		/// caller of the method.
		/// </para>
		/// <para>
		/// It is the implementation of IRpcChannelBuffer::SendReceive that actually sends the request to the server process and that knows
		/// how to identify the server process and, within that process, the object to which the request should be sent. The channel
		/// implementation also knows how to forward the request on to the appropriate stub manager in that process. The interface stub
		/// unmarshals the arguments from the provided buffer, invokes the indicated method on the server object, and marshals the return
		/// values back into a new buffer allocated by a call to IRpcChannelBuffer::GetBuffer. The channel then transmits the return data
		/// packet back to the interface proxy, which is still in the middle of <c>IRpcChannelBuffer::SendReceive</c>, which returns to the
		/// interface proxy.
		/// </para>
		/// <para>
		/// A particular instance of an interface proxy can be used to service more than one interface, as long as the following conditions
		/// are met:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The IIDs of the affected interfaces must be mapped to the appropriate ProxyStubClsid in the system registry.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The interface proxy must support calls to QueryInterface from one supported interface to the other interfaces, as usual, as well
		/// as from IUnknown and IRpcProxyBuffer.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// A single instance of an interface stub can also service more than one interface, but only if that set of interfaces has a strict
		/// single-inheritance relationship. This restriction exists because the stub can direct method invocations to multiple interfaces
		/// only where it knows in advance which methods are implemented on which interfaces.
		/// </para>
		/// <para>
		/// At various times, proxies and stubs will have need to allocate or free memory. Interface proxies, for example, will need to
		/// allocate memory in which to return out parameters to their caller. In this respect, interface proxies and interface stubs are
		/// just normal COM components, in that they should use the standard task allocator. (See CoGetMalloc.)
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-imarshal
		[PInvokeData("objidl.h", MSDNShortId = "e6f08949-f27d-4aba-adff-eaf9c356a928")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000003-0000-0000-C000-000000000046")]
		public interface IMarshal
		{
			/// <summary>Retrieves the CLSID of the unmarshaling code.</summary>
			/// <param name="riid">A reference to the identifier of the interface to be marshaled.</param>
			/// <param name="pv">
			/// A pointer to the interface to be marshaled; can be <c>NULL</c> if the caller does not have a pointer to the desired interface.
			/// </param>
			/// <param name="dwDestContext">
			/// The destination context where the specified interface is to be unmarshaled. Possible values come from the enumeration MSHCTX.
			/// Unmarshaling can occur either in another apartment of the current process (MSHCTX_INPROC) or in another process on the same
			/// computer as the current process (MSHCTX_LOCAL).
			/// </param>
			/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
			/// <param name="mshlflags">
			/// Indicates whether the data to be marshaled is to be transmitted back to the client process, the typical caseâ€”or written to
			/// a global table, where it can be retrieved by multiple clients. Possible values come from the MSHLFLAGS enumeration.
			/// </param>
			/// <returns>A pointer that receives the CLSID to be used to create a proxy in the client process.</returns>
			/// <remarks>
			/// <para>
			/// This method is called indirectly, in a call to CoMarshalInterface, by whatever code in the server process is responsible for
			/// marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of several
			/// interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include the
			/// IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a pointer is
			/// called the marshaling stub.
			/// </para>
			/// <para>
			/// To create a proxy for an object, COM requires two pieces of information from the original object: the amount of data to be
			/// written to the marshaling stream and the proxy's CLSID.
			/// </para>
			/// <para>The marshaling stub obtains these two pieces of information with successive calls to CoGetMarshalSizeMax and CoMarshalInterface.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The marshaling stub calls the object's implementation of this method to obtain the CLSID to be used in creating an instance
			/// of the proxy. The client, upon receiving the CLSID, loads the DLL listed for it in the system registry.
			/// </para>
			/// <para>
			/// You do not explicitly call this method if you are implementing existing COM interfaces or using the Microsoft Interface
			/// Definition Language (MIDL) to define your own interfaces. In either case, the stub automatically makes the call. See Defining
			/// COM Interfaces.
			/// </para>
			/// <para>
			/// If you are not using MIDL to define your own interface, your stub must call this method, either directly or indirectly, to
			/// get the CLSID that the client-side COM library needs to create a proxy for the object implementing the interface.
			/// </para>
			/// <para>
			/// If the caller has a pointer to the interface to be marshaled, it should, as a matter of efficiency, use the pv parameter to
			/// pass that pointer. In this way, an implementation that may use such a pointer to determine the appropriate CLSID for the
			/// proxy does not have to call QueryInterface on itself. If a caller does not have a pointer to the interface to be marshaled,
			/// it can pass <c>NULL</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// COM calls <c>GetUnmarshalClass</c> to obtain the CLSID to be used for creating a proxy in the client process. The CLSID to be
			/// used for a proxy is normally not that of the original object, but one you will have generated (using the Guidgen.exe tool)
			/// specifically for your proxy object.
			/// </para>
			/// <para>
			/// Implement this method for each object that provides marshaling for one or more of its interfaces. The code responsible for
			/// marshaling the object writes the CLSID, along with the marshaling data, to a stream; COM extracts the CLSID and data from the
			/// stream on the receiving side.
			/// </para>
			/// <para>
			/// If your proxy implementation consists simply of copying the entire original object into the client process, thereby
			/// eliminating the need to forward calls to the original object, the CLSID returned would be the same as that of the original
			/// object. This strategy, of course, is advisable only for objects that are not expected to change.
			/// </para>
			/// <para>
			/// If the pv parameter is <c>NULL</c> and your implementation needs an interface pointer, it can call QueryInterface on the
			/// current object to get it. The pv parameter exists merely to improve efficiency.
			/// </para>
			/// <para>
			/// To ensure that your implementation of <c>GetUnmarshalClass</c> continues to work properly as new destination contexts are
			/// supported in the future, delegate marshaling to the COM default implementation for all dwDestContext values that your
			/// implementation does not handle. To delegate marshaling to the COM default implementation, call the CoGetStandardMarshal function.
			/// </para>
			/// <para>
			/// <c>Note</c> The <c>ThreadingModel</c> registry value must be <c>Both</c> for an in-process server that implements the CLSID
			/// returned from the <c>GetUnmarshalClass</c> method. For more information, see InprocServer32.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-getunmarshalclass HRESULT GetUnmarshalClass(
			// REFIID riid, void *pv, DWORD dwDestContext, void *pvDestContext, DWORD mshlflags, CLSID *pCid );
			Guid GetUnmarshalClass(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object pv, [In] MSHCTX dwDestContext,
				[In, Optional] IntPtr pvDestContext, [In] MSHLFLAGS mshlflags);

			/// <summary>Retrieves the maximum size of the buffer that will be needed during marshaling.</summary>
			/// <param name="riid">A reference to the identifier of the interface to be marshaled.</param>
			/// <param name="pv">The interface pointer to be marshaled. This parameter can be <c>NULL</c>.</param>
			/// <param name="dwDestContext">
			/// The destination context where the specified interface is to be unmarshaled. Possible values come from the enumeration MSHCTX.
			/// Unmarshaling can occur either in another apartment of the current process (MSHCTX_INPROC) or in another process on the same
			/// computer as the current process (MSHCTX_LOCAL).
			/// </param>
			/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
			/// <param name="mshlflags">
			/// Indicates whether the data to be marshaled is to be transmitted back to the client processâ€”the typical caseâ€”or written to
			/// a global table, where it can be retrieved by multiple clients. Possible values come from the MSHLFLAGS enumeration.
			/// </param>
			/// <param name="pSize">Size of the p.</param>
			/// <returns>A pointer to a variable that receives the maximum size of the buffer.</returns>
			/// <remarks>
			/// <para>
			/// This method is called indirectly, in a call to CoGetMarshalSizeMax, by whatever code in the server process is responsible for
			/// marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of several
			/// interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include the
			/// IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a pointer is
			/// called the marshaling stub.
			/// </para>
			/// <para>
			/// To create a proxy for an object, COM requires two pieces of information from the original object: the amount of data to be
			/// written to the marshaling stream and the proxy's CLSID.
			/// </para>
			/// <para>The marshaling stub obtains these two pieces of information with successive calls to CoGetMarshalSizeMax and CoMarshalInterface.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The marshaling stub, through a call to CoGetMarshalSizeMax, calls the object's implementation of this method to preallocate
			/// the stream buffer that will be passed to MarshalInterface.
			/// </para>
			/// <para>
			/// You do not explicitly call this method if you are implementing existing COM interfaces or using the Microsoft Interface
			/// Definition Language (MIDL) to define your own custom interfaces. In either case, the MIDL-generated stub automatically makes
			/// the call.
			/// </para>
			/// <para>
			/// If you are not using MIDL to define your own interface (see Defining COM Interfaces), your marshaling stub does not have to
			/// call <c>GetMarshalSizeMax</c>, although doing so is highly recommended. An object knows better than an interface stub what
			/// the maximum size of a marshaling data packet is likely to be. Therefore, unless you are providing an automatically growing
			/// stream that is so efficient that the overhead of expanding it is insignificant, you should call this method even when
			/// implementing your own interfaces.
			/// </para>
			/// <para>
			/// The value returned by this method is guaranteed to be valid only as long as the internal state of the object being marshaled
			/// does not change. Therefore, the actual marshaling should be done immediately after this function returns, or the stub runs
			/// the risk that the object, because of some change in state, might require more memory to marshal than it originally indicated.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Your implementation of MarshalInterface will use the preallocated buffer to write marshaling data into the stream. If the
			/// buffer is too small, the marshaling operation will fail. Therefore, the value returned by this method must be a conservative
			/// estimate of the amount of data that will be needed to marshal the interface. Violation of this requirement should be treated
			/// as a catastrophic error.
			/// </para>
			/// <para>
			/// In a subsequent call to MarshalInterface, your IMarshal implementation cannot rely on the caller actually having called
			/// <c>GetMarshalSizeMax</c> beforehand. It must still be wary of STG_E_MEDIUMFULL errors returned by the stream and be prepared
			/// to handle them gracefully.
			/// </para>
			/// <para>
			/// To ensure that your implementation of <c>GetMarshalSizeMax</c> will continue to work properly as new destination contexts are
			/// supported in the future, delegate marshaling to the COM default implementation for all dwDestContext values that your
			/// implementation does not understand. To delegate marshaling to the COM default implementation, call the CoGetStandardMarshal function.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-getmarshalsizemax HRESULT GetMarshalSizeMax(
			// REFIID riid, void *pv, DWORD dwDestContext, void *pvDestContext, DWORD mshlflags, DWORD *pSize );
			uint GetMarshalSizeMax(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object pv, [In] MSHCTX dwDestContext,
				[In, Optional] IntPtr pvDestContext, [In] MSHLFLAGS mshlflags);

			/// <summary>Marshals an interface pointer.</summary>
			/// <param name="pStm">A pointer to the stream to be used during marshaling.</param>
			/// <param name="riid">
			/// A reference to the identifier of the interface to be marshaled. This interface must be derived from the IUnknown interface.
			/// </param>
			/// <param name="pv">
			/// A pointer to the interface pointer to be marshaled. This parameter can be <c>NULL</c> if the caller does not have a pointer
			/// to the desired interface.
			/// </param>
			/// <param name="dwDestContext">
			/// The destination context where the specified interface is to be unmarshaled. Possible values for dwDestContext come from the
			/// enumeration MSHCTX. Currently, unmarshaling can occur either in another apartment of the current process (MSHCTX_INPROC) or
			/// in another process on the same computer as the current process (MSHCTX_LOCAL).
			/// </param>
			/// <param name="pvDestContext">This parameter is reserved and must be 0.</param>
			/// <param name="mshlflags">
			/// Indicates whether the data to be marshaled is to be transmitted back to the client process—the typical case—or written to a
			/// global table, where it can be retrieved by multiple clients. Possible values come from the MSHLFLAGS enumeration.
			/// </param>
			/// <remarks>
			/// <para>
			/// This method is called indirectly, in a call to CoMarshalInterface, by whatever code in the server process is responsible for
			/// marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of several
			/// interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include the
			/// IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a pointer is
			/// called the marshaling stub.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Typically, rather than calling <c>MarshalInterface</c> directly, your marshaling stub instead should call the
			/// CoMarshalInterface function, which contains a call to this method. The stub makes this call to command an object to write its
			/// marshaling data into a stream. The stub then either passes the marshaling data back to the client process or writes it to a
			/// global table, where it can be unmarshaled by multiple clients. The stub's call to <c>CoMarshalInterface</c> is normally
			/// preceded by a call to CoGetMarshalSizeMax to get the maximum size of the stream buffer into which the marshaling data will be written.
			/// </para>
			/// <para>
			/// You do not explicitly call this method if you are implementing existing COM interfaces or defining your own interfaces using
			/// the Microsoft Interface Definition Language (MIDL). In either case, the MIDL-generated stub automatically makes the call.
			/// </para>
			/// <para>
			/// If you are not using MIDL to define your own interface, your marshaling stub must call this method, either directly or
			/// indirectly. Your stub implementation should call <c>MarshalInterface</c> immediately after its previous call to
			/// IMarshal::GetMarshalSizeMax returns. Because the value returned by <c>GetMarshalSizeMax</c> is guaranteed to be valid only as
			/// long as the internal state of the object being marshaled does not change, a delay in calling <c>MarshalInterface</c> runs the
			/// risk that the object will require a larger stream buffer than originally indicated.
			/// </para>
			/// <para>
			/// If the caller has a pointer to the interface to be marshaled, it should, as a matter of efficiency, use the pv parameter to
			/// pass that pointer. In this way, an implementation that may use such a pointer to determine the appropriate CLSID for the
			/// proxy does not have to call QueryInterface on itself. If a caller does not have a pointer to the interface to be marshaled,
			/// it can pass <c>NULL</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Your implementation of <c>MarshalInterface</c> must write to the stream whatever data is needed to initialize the proxy on
			/// the receiving side. Such data would include a reference to the interface to be marshaled, a MSHLFLAGS value specifying
			/// whether the data should be returned to the client process or written to a global table, and whatever is needed to connect to
			/// the object, such as a named pipe, handle to a window, or pointer to an RPC channel.
			/// </para>
			/// <para>
			/// Your implementation should not assume that the stream is large enough to hold all the data. Rather, it should gracefully
			/// handle a STG_E_MEDIUMFULL error. Just before exiting, your implementation should position the seek pointer in the stream
			/// immediately after the last byte of data written.
			/// </para>
			/// <para>
			/// If the pv parameter is <c>NULL</c> and your implementation needs an interface pointer, it can call QueryInterface on the
			/// current object to get it. The pv parameter exists merely to improve efficiency.
			/// </para>
			/// <para>
			/// To ensure that your implementation of <c>MarshalInterface</c> continues to work properly as new destination contexts are
			/// supported in the future, delegate marshaling to the COM default implementation for all dwDestContext values that your
			/// implementation does not handle. To delegate marshaling to the COM default implementation, call the CoGetStandardMarshal
			/// helper function.
			/// </para>
			/// <para>
			/// Using the MSHLFLAGS enumeration, callers can specify whether an interface pointer is to be marshaled back to a single client
			/// or written to a global table, where it can be unmarshaled by multiple clients. You must make sure that your object can handle
			/// calls from the multiple proxies that might be created from the same initialization data.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-marshalinterface HRESULT MarshalInterface(
			// IStream *pStm, REFIID riid, void *pv, DWORD dwDestContext, void *pvDestContext, DWORD mshlflags );
			void MarshalInterface([In] IStream pStm, in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object pv,
				[In] MSHCTX dwDestContext, [In, Optional] IntPtr pvDestContext, [In] MSHLFLAGS mshlflags);

			/// <summary>Unmarshals an interface pointer.</summary>
			/// <param name="pStm">A pointer to the stream from which the interface pointer is to be unmarshaled.</param>
			/// <param name="riid">A reference to the identifier of the interface to be unmarshaled.</param>
			/// <returns>
			/// The address of pointer variable that receives the interface pointer. Upon successful return, *ppv contains the requested
			/// interface pointer of the interface to be unmarshaled.
			/// </returns>
			/// <remarks>
			/// <para>The COM library in the process where unmarshaling is to occur calls the proxy's implementation of this method.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You do not call this method directly. There are, however, some situations in which you might call it indirectly through a
			/// call to CoUnmarshalInterface. For example, if you are implementing a stub, your implementation would call
			/// <c>CoUnmarshalInterface</c> when the stub receives an interface pointer as a parameter in a method call.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The proxy's implementation should read the data written to the stream by the original object's implementation of
			/// IMarshal::MarshalInterface and use that data to initialize the proxy object whose CLSID was returned by the marshaling stub's
			/// call to the original object's implementation of IMarshal::GetUnmarshalClass.
			/// </para>
			/// <para>
			/// To return the appropriate interface pointer, the proxy implementation can simply call QueryInterface on itself, passing the
			/// riid and ppv parameters. However, your implementation of <c>UnmarshalInterface</c> is free to create a different object and,
			/// if necessary, return a pointer to it.
			/// </para>
			/// <para>
			/// Just before exiting, even if exiting with an error, your implementation should reposition the seek pointer in the stream
			/// immediately after the last byte of data read.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-unmarshalinterface HRESULT UnmarshalInterface(
			// IStream *pStm, REFIID riid, void **ppv );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object UnmarshalInterface([In] IStream pStm, in Guid riid);

			/// <summary>Destroys a marshaled data packet.</summary>
			/// <param name="pStm">A pointer to a stream that contains the data packet to be destroyed.</param>
			/// <remarks>
			/// <para>
			/// If an object's marshaled data packet does not get unmarshaled in the client process space and the packet is no longer needed,
			/// the client calls <c>ReleaseMarshalData</c> on the proxy's IMarshal implementation to instruct the object to destroy the data
			/// packet. The call occurs within the CoReleaseMarshalData function. The data packet serves as an additional reference on the
			/// object, and releasing the data is like releasing an interface pointer by calling Release.
			/// </para>
			/// <para>
			/// If the marshaled data packet somehow does not arrive in the client process or if <c>ReleaseMarshalData</c> is not
			/// successfully re-created in the proxy, COM can call this method on the object itself.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You will rarely if ever have occasion to call this method yourself. A possible exception would be if you were to implement
			/// IMarshal on a class factory for a class object on which you are also implementing <c>IMarshal</c>. In this case, if you were
			/// marshaling the object to a table where it could be retrieved by multiple clients, you might, as part of your unmarshaling
			/// routine, call <c>ReleaseMarshalData</c> to release the data packet for each proxy.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If your implementation stores state information about marshaled data packets, you can use this method to release the state
			/// information associated with the data packet represented by pStm. Your implementation should also position the seek pointer in
			/// the stream past the last byte of data.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-releasemarshaldata HRESULT ReleaseMarshalData(
			// IStream *pStm );
			void ReleaseMarshalData([In] IStream pStm);

			/// <summary>
			/// Releases all connections to an object. The object's server calls the object's implementation of this method prior to shutting down.
			/// </summary>
			/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
			/// <remarks>
			/// <para>This method is implemented on the object, not the proxy.</para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The usual case in which this method is called occurs when an end user forcibly closes a COM server that has one or more
			/// running objects that implement IMarshal. Prior to shutting down, the server calls the CoDisconnectObject function to release
			/// external connections to all its running objects. For each object that implements <c>IMarshal</c>, however, this function
			/// calls <c>DisconnectObject</c> so that each object that manages its own marshaling can take steps to notify its proxy that it
			/// is about to shut down.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// As part of its normal shutdown code, a server should call CoDisconnectObject, which in turn calls <c>DisconnectObject</c>, on
			/// each of its running objects that implements IMarshal.
			/// </para>
			/// <para>
			/// The outcome of any implementation of this method should be to enable a proxy to respond to all subsequent calls from its
			/// client by returning RPC_E_DISCONNECTED or CO_E_OBJNOTCONNECTED rather than attempting to forward the calls on to the original
			/// object. It is up to the client to destroy the proxy.
			/// </para>
			/// <para>
			/// If you are implementing this method for an immutable object, such as a moniker, your implementation does not need to do
			/// anything because such objects are typically copied whole into the client's address space. Therefore, they have neither a
			/// proxy nor a connection to the original object. For more information on marshaling immutable objects, see the "When to
			/// Implement" section of the IMarshal topic.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-disconnectobject HRESULT DisconnectObject(
			// DWORD dwReserved );
			void DisconnectObject([In, Optional] uint dwReserved);
		}

		/// <summary>Marks an object that doesn't support being marshaled or stored in the Global Interface Table.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-inomarshal
		[PInvokeData("objidl.h", MSDNShortId = "6C82B08D-C8AF-4FB6-988C-CD7F9BABEE92")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("ecc8691b-c1db-4dc0-855e-65f6c551af49")]
		public interface INoMarshal
		{
		}

		/// <summary>Performs various operations on contexts.</summary>
		/// <seealso cref="IContext"/>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-iobjcontext
		[PInvokeData("objidl.h", MSDNShortId = "983615a1-cfa2-4137-8c7e-42e2ef6923a8")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000001c6-0000-0000-C000-000000000046")]
		public interface IObjContext : IContext
		{
			/// <summary>Adds the specified context property to the object context.</summary>
			/// <param name="rpolicyId">A GUID that uniquely identifies this context property.</param>
			/// <param name="flags">This parameter is reserved and must be zero.</param>
			/// <param name="pUnk">A pointer to the context property to be added.</param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-setproperty HRESULT SetProperty( REFGUID
			// rpolicyId, CPFLAGS flags, IUnknown *pUnk );
			new void SetProperty(in Guid rpolicyId, [Optional] uint flags, [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);

			/// <summary>Removes the specified context property from the context.</summary>
			/// <param name="rPolicyId">The GUID that uniquely identifies the context property to be removed.</param>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-removeproperty HRESULT RemoveProperty( REFGUID
			// rPolicyId );
			new void RemoveProperty(in Guid rPolicyId);

			/// <summary>Retrieves the specified context property from the context.</summary>
			/// <param name="rGuid">The GUID that uniquely identifies the context property to be retrieved.</param>
			/// <param name="pFlags">The address of the variable that receives the flags associated with the property.</param>
			/// <returns>The address of the variable that receives the IUnknown interface pointer of the requested context property.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-getproperty HRESULT GetProperty( REFGUID rGuid,
			// CPFLAGS *pFlags, IUnknown **ppUnk );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetProperty(in Guid rGuid, out uint pFlags);

			/// <summary>
			/// Returns an IEnumContextProps interface pointer that can be used to enumerate the context properties in this context.
			/// </summary>
			/// <returns>The address of the variable that receives the new IEnumContextProps interface pointer.</returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-enumcontextprops HRESULT EnumContextProps(
			// IEnumContextProps **ppEnumContextProps );
			new IEnumContextProps EnumContextProps();

			void Reserved1();

			void Reserved2();

			void Reserved3();

			void Reserved4();

			void Reserved5();

			void Reserved6();

			void Reserved7();
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
		/// Used to dynamically load new DLL servers into an existing surrogate and free the surrogate when it is no longer needed.
		/// </summary>
		/// <remarks>
		/// A surrogate is an EXE process into which a DLL server can be loaded to give the DLL server the advantages of an EXE server
		/// without the coding overhead. It can also allow independent DLL servers to be located together within a single process, reducing
		/// the total number of processes needed. DLL servers are easy to write using standard development tools, like Microsoft Visual
		/// Studio, and running them in a surrogate process provides the benefits of an executable implementation, including fault isolation,
		/// the ability to serve multiple clients simultaneously, and allowing the server to provide services to remote clients in a
		/// distributed environment.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-isurrogate
		[PInvokeData("objidl.h", MSDNShortId = "fbed0514-3646-4744-aa7a-4a98f1a12cc0")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000022-0000-0000-C000-000000000046")]
		public interface ISurrogate
		{
			/// <summary>
			/// Loads a DLL server into the implementing surrogate. COM calls this method when there is an activation request for the DLL
			/// server's class, if the class is registered as DllSurrogate.
			/// </summary>
			/// <param name="Clsid">The CLSID of the DLL server to be loaded.</param>
			/// <remarks>
			/// <para>Upon receiving a load request through <c>LoadDllServer</c>, the surrogate must perform the following steps:</para>
			/// <list type="number">
			/// <item>
			/// <term>Create a class factory object that supports IUnknown, IClassFactory, and IMarshal.</term>
			/// </item>
			/// <item>
			/// <term>Call CoRegisterClassObject to register the new class factory object as the class factory for the requested CLSID.</term>
			/// </item>
			/// </list>
			/// <para>
			/// This class factory's implementation of IClassFactory::CreateInstance will create an instance of the requested CLSID method by
			/// calling CoGetClassObject to get the class factory which creates an actual object for the given CLSID.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isurrogate-loaddllserver HRESULT LoadDllServer( REFCLSID
			// Clsid );
			void LoadDllServer(in Guid Clsid);

			/// <summary>Unloads a DLL server.</summary>
			/// <remarks>
			/// <para>
			/// COM calls <c>FreeSurrogate</c> when there are no more DLL servers running in the surrogate process. When <c>FreeSurrogate</c>
			/// is called, the method must properly revoke all of the class factories registered in the surrogate, and then cause the
			/// surrogate process to exit.
			/// </para>
			/// <para>
			/// Surrogate processes must call the CoFreeUnusedLibraries function periodically to unload DLL servers that are no longer in
			/// use. The surrogate process assumes this responsibility, which would normally be the client's responsibility.
			/// <c>CoFreeUnusedLibraries</c> calls the DllCanUnloadNow function on any loaded DLL servers. Because
			/// <c>CoFreeUnusedLibraries</c> depends on the existence and proper implementation of <c>DllCanUnloadNow</c> in DLL servers, it
			/// is not guaranteed to unload all DLL servers that should be unloaded --not every server implements <c>DllCanUnloadNow</c>, and
			/// this function is unreliable for free-threaded DLLs. Additionally, the surrogate has no way of being informed when all DLL
			/// servers are gone. COM, however, can determine when all DLL servers have been unloaded, and will then call the
			/// <c>FreeSurrogate</c> method.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isurrogate-freesurrogate HRESULT FreeSurrogate( );
			void FreeSurrogate();
		}

		/// <summary>Structure returned by IEnumContextProps::Enum</summary>
		[PInvokeData("objidl.h", MSDNShortId = "64591e45-5478-4360-8c1f-08b09b5aef8e")]
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ienumcontextprops-next
		[StructLayout(LayoutKind.Sequential)]
		public struct ContextProperty
		{
			public Guid policyId;
			public uint flags;
			public IntPtr pUnk;
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
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that are
		/// suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
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
			/// STGM constants. The binding operation uses these flags in the call to IPersistFile::Load when loading the file. If the object
			/// is already running, these flags are ignored by the binding operation. The CreateBindCtx function initializes this field to STGM_READWRITE.
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

			/// <summary>Performs an implicit conversion from <see cref="System.Runtime.InteropServices.ComTypes.BIND_OPTS"/> to <see cref="BIND_OPTS_V"/>.</summary>
			/// <param name="bo">The <see cref="BIND_OPTS"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BIND_OPTS_V(System.Runtime.InteropServices.ComTypes.BIND_OPTS bo) =>
				new BIND_OPTS_V() { grfFlags = (BIND_FLAGS)bo.grfFlags, grfMode = (STGM)bo.grfFlags, dwTickCountDeadline = (uint)bo.dwTickCountDeadline };
		}

		/// <summary>Contains parameters used during a moniker-binding operation.</summary>
		/// <remarks>
		/// <para>
		/// A <c>BIND_OPTS2</c> structure is stored in a bind context; the same bind context is used by each component of a composite moniker
		/// during binding, allowing the same parameters to be passed to all components of a composite moniker. See IBindCtx for more
		/// information about bind contexts.
		/// </para>
		/// <para>
		/// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values for the
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that are
		/// suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
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
			/// This member provides additional information on how the link should be resolved. See the documentation of the fFlags parameter
			/// in IShellLink::Resolve.
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
		/// A <c>BIND_OPTS3</c> structure is stored in a bind context; the same bind context is used by each component of a composite moniker
		/// during binding, allowing the same parameters to be passed to all components of a composite moniker. See IBindCtx for more
		/// information about bind contexts.
		/// </para>
		/// <para>
		/// Moniker clients (use a moniker to acquire an interface pointer to an object) typically do not need to specify values for the
		/// members of this structure. The CreateBindCtx function creates a bind context with the bind options set to default values that are
		/// suitable for most situations; the BindMoniker function does the same thing when creating a bind context for use in binding a
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