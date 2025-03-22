using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Rpc;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>
	/// Identifies one of the marshaling context attributes that you can query by using the GetMarshalingContextAttribute method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-co_marshaling_context_attributes typedef enum
	// CO_MARSHALING_CONTEXT_ATTRIBUTES { CO_MARSHALING_SOURCE_IS_APP_CONTAINER, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_1,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_2, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_3,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_4, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_5,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_6, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_7,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_8, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_9,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_10, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_11,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_12, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_13,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_14, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_15,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_16, CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_17,
	// CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_18 } ;
	[PInvokeData("objidl.h", MSDNShortId = "NE:objidl.CO_MARSHALING_CONTEXT_ATTRIBUTES")]
	public enum CO_MARSHALING_CONTEXT_ATTRIBUTES
	{
		/// <summary>
		/// This attribute is a boolean value, with 0 representing TRUE and nonzero representing FALSE. You can safely cast the value of
		/// the result to BOOL, but it isn't safe for the caller to cast a BOOL* to ULONG_PTR* for the pAttributeValue parameter, or for
		/// the implementation to cast pAttributeValue to BOOL* when setting it.
		/// </summary>
		CO_MARSHALING_SOURCE_IS_APP_CONTAINER,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_1,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_2,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_3,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_4,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_5,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_6,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_7,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_8,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_9,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_10,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_11,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_12,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_13,

		/// <summary/>
		CO_MARSHALING_CONTEXT_ATTRIBUTE_RESERVED_14,
	}

	/// <summary>Specifies various capabilities in CoInitializeSecurity and IClientSecurity::SetBlanket (or its helper function CoSetProxyBlanket).</summary>
	/// <remarks>
	/// <para>
	/// When the EOAC_APPID flag is set, CoInitializeSecurity looks for the authentication level under the AppID. If the authentication
	/// level is not found, it looks for the default authentication level. If the default authentication level is not found, it
	/// generates a default authentication level of connect. If the authentication level is not RPC_C_AUTHN_LEVEL_NONE,
	/// <c>CoInitializeSecurity</c> looks for the access permission value under the AppID. If not found, it looks for the default access
	/// permission value. If not found, it generates a default access permission. All the other security settings are determined the
	/// same way as for a legacy application.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/ne-objidlbase-eole_authentication_capabilities typedef enum
	// tagEOLE_AUTHENTICATION_CAPABILITIES { EOAC_NONE, EOAC_MUTUAL_AUTH, EOAC_STATIC_CLOAKING, EOAC_DYNAMIC_CLOAKING,
	// EOAC_ANY_AUTHORITY, EOAC_MAKE_FULLSIC, EOAC_DEFAULT, EOAC_SECURE_REFS, EOAC_ACCESS_CONTROL, EOAC_APPID, EOAC_DYNAMIC,
	// EOAC_REQUIRE_FULLSIC, EOAC_AUTO_IMPERSONATE, EOAC_DISABLE_AAA, EOAC_NO_CUSTOM_MARSHAL, EOAC_RESERVED1 } EOLE_AUTHENTICATION_CAPABILITIES;
	[PInvokeData("objidlbase.h", MSDNShortId = "NE:objidlbase.tagEOLE_AUTHENTICATION_CAPABILITIES")]
	[Flags]
	public enum EOLE_AUTHENTICATION_CAPABILITIES
	{
		/// <summary>Indicates that no capability flags are set.</summary>
		EOAC_NONE = 0x0,

		/// <summary>
		/// If this flag is specified, it will be ignored. Support for mutual authentication is automatically provided by some
		/// authentication services. See COM and Security Packages for more information.
		/// </summary>
		EOAC_MUTUAL_AUTH = 0x1,

		/// <summary>
		/// Sets static cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's identity.
		/// However, the client's identity is determined on the first call on each proxy (if SetBlanket is not called) and each time
		/// CoSetProxyBlanket is called on the proxy. For more information about static cloaking, see Cloaking.CoInitializeSecurity and
		/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
		/// authentication service.
		/// </summary>
		EOAC_STATIC_CLOAKING = 0x20,

		/// <summary>
		/// Sets dynamic cloaking. When this flag is set, DCOM uses the thread token (if present) when determining the client's
		/// identity. On each call to a proxy, the current thread token is examined to determine whether the client's identity has
		/// changed (incurring an additional performance cost) and the client is authenticated again only if necessary. Dynamic cloaking
		/// can be set by clients only. For more information about dynamic cloaking, see Cloaking.CoInitializeSecurity and
		/// IClientSecurity::SetBlanket return errors if both cloaking flags are set or if either flag is set when Schannel is the
		/// authentication service.
		/// </summary>
		EOAC_DYNAMIC_CLOAKING = 0x40,

		/// <summary>This flag is obsolete.</summary>
		EOAC_ANY_AUTHORITY = 0x80,

		/// <summary>
		/// Causes DCOM to send Schannel server principal names in fullsic format to clients as part of the default security
		/// negotiation. The name is extracted from the server certificate. For more information about the fullsic form, see Principal Names.
		/// </summary>
		EOAC_MAKE_FULLSIC = 0x100,

		/// <summary>
		/// Tells DCOM to use the valid capabilities from the call to CoInitializeSecurity. If CoInitializeSecurity was not called,
		/// EOAC_NONE will be used for the capabilities flag. This flag can be set only by clients in a call to
		/// IClientSecurity::SetBlanket or CoSetProxyBlanket.
		/// </summary>
		EOAC_DEFAULT = 0x800,

		/// <summary>
		/// Authenticates distributed reference count calls to prevent malicious users from releasing objects that are still being used.
		/// If this flag is set, which can be done only in a call to CoInitializeSecurity by the client, the authentication level (in
		/// dwAuthnLevel) cannot be set to none.The server always authenticates Release calls. Setting this flag prevents an
		/// authenticated client from releasing the objects of another authenticated client. It is recommended that clients always set
		/// this flag, although performance is affected because of the overhead associated with the extra security.
		/// </summary>
		EOAC_SECURE_REFS = 0x2,

		/// <summary>
		/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to an IAccessControl interface on an access
		/// control object. When DCOM makes security checks, it calls IAccessControl::IsAccessAllowed. This flag is set only by the
		/// server.CoInitializeSecurity returns an error if both the EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
		/// </summary>
		EOAC_ACCESS_CONTROL = 0x4,

		/// <summary>
		/// Indicates that the pSecDesc parameter to CoInitializeSecurity is a pointer to a GUID that is an AppID. The
		/// CoInitializeSecurity function looks up the AppID in the registry and reads the security settings from there. If this flag is
		/// set, all other parameters to CoInitializeSecurity are ignored and must be zero. Only the server can set this flag. For more
		/// information about this capability flag, see the Remarks section below.CoInitializeSecurity returns an error if both the
		/// EOAC_APPID and EOAC_ACCESS_CONTROL flags are set.
		/// </summary>
		EOAC_APPID = 0x8,

		/// <summary>Reserved.</summary>
		EOAC_DYNAMIC = 0x10,

		/// <summary>
		/// Causes DCOM to fail CoSetProxyBlanket calls where an Schannel principal name is specified in any format other than fullsic.
		/// This flag is currently for clients only. For more information about the fullsic form, see Principal Names.
		/// </summary>
		EOAC_REQUIRE_FULLSIC = 0x200,

		/// <summary>Reserved.</summary>
		EOAC_AUTO_IMPERSONATE = 0x400,

		/// <summary>
		/// Causes any activation where a server process would be launched under the caller's identity (activate-as-activator) to fail
		/// with E_ACCESSDENIED. This value, which can be specified only in a call to CoInitializeSecurity by the client, allows an
		/// application that runs under a privileged account (such as LocalSystem) to help prevent its identity from being used to
		/// launch untrusted components.An activation call that uses CLSCTX_ENABLE_AAA of the CLSCTX enumeration will allow
		/// activate-as-activator activations for that call.
		/// </summary>
		EOAC_DISABLE_AAA = 0x1000,

		/// <summary>
		/// Specifying this flag helps protect server security when using DCOM or COM+. It reduces the chances of executing arbitrary
		/// DLLs because it allows the marshaling of only CLSIDs that are implemented in Ole32.dll, ComAdmin.dll, ComSvcs.dll, or
		/// Es.dll, or that implement the CATID_MARSHALER category ID. Any service that is critical to system operation should set this flag.
		/// </summary>
		EOAC_NO_CUSTOM_MARSHAL = 0x2000,

		/// <summary/>
		EOAC_RESERVED1 = 0x4000,
	}

	/// <summary>Specifies the type of external connection existing on an embedded object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/ne-objidlbase-extconn typedef enum tagEXTCONN { EXTCONN_STRONG,
	// EXTCONN_WEAK, EXTCONN_CALLABLE } EXTCONN;
	[PInvokeData("objidlbase.h", MSDNShortId = "NE:objidlbase.tagEXTCONN")]
	[Flags]
	public enum EXTCONN
	{
		/// <summary>
		/// The external connection is a link. If this value is specified, the external connection must keep the object alive until all
		/// strong external connections are cleared through IExternalConnection::ReleaseConnection.
		/// </summary>
		EXTCONN_STRONG = 0x0001,

		/// <summary>This value is not used.</summary>
		EXTCONN_WEAK = 0x0002,

		/// <summary>This value is not used.</summary>
		EXTCONN_CALLABLE = 0x0004,
	}

	/// <summary>
	/// The <c>LOCKTYPE</c> enumeration values indicate the type of locking requested for the specified range of bytes. The values are
	/// used in the ILockBytes::LockRegion and IStream::LockRegion methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/ne-objidl-taglocktype typedef enum tagLOCKTYPE { LOCK_WRITE,
	// LOCK_EXCLUSIVE, LOCK_ONLYONCE } LOCKTYPE;
	[PInvokeData("objidl.h", MSDNShortId = "5d84fb08-aa4f-4918-a0de-550b02cb5287")]
	[Flags]
	public enum LOCKTYPE
	{
		/// <summary>
		/// If this lock is granted, the specified range of bytes can be opened and read any number of times, but writing to the locked
		/// range is prohibited except for the owner that was granted this lock.
		/// </summary>
		LOCK_WRITE = 1,

		/// <summary>
		/// If this lock is granted, writing to the specified range of bytes is prohibited except by the owner that was granted this lock.
		/// </summary>
		LOCK_EXCLUSIVE = 2,

		/// <summary>
		/// If this lock is granted, no other LOCK_ONLYONCE lock can be obtained on the range. Usually this lock type is an alias for
		/// some other lock type. Thus, specific implementations can have additional behavior associated with this lock type.
		/// </summary>
		LOCK_ONLYONCE = 4,
	}

	/// <summary>An identifier of the property to be queried or set.</summary>
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcOptions")]
	[Flags]
	public enum RPCOPT_PROPERTIES
	{
		/// <summary>Controls how long your machine will attempt to establish RPC communications with another before failing.</summary>
		[CorrespondingType(typeof(RCP_C_BINDING_TIMEOUT), CorrespondingAction.GetSet)]
		COMBND_RPCTIMEOUT = 0x01,

		/// <summary>Describes the degree of remoteness of the RPC connection.</summary>
		[CorrespondingType(typeof(RPCOPT_SERVER_LOCALITY_VALUES), CorrespondingAction.Get)]
		COMBND_SERVER_LOCALITY = 0x02,

		/// <summary>Reserved.</summary>
		COMBND_RESERVED1 = 0x04,

		/// <summary>Reserved.</summary>
		COMBND_RESERVED2 = 0x05,

		/// <summary>Reserved.</summary>
		COMBND_RESERVED3 = 0x08,

		/// <summary>Reserved.</summary>
		COMBND_RESERVED4 = 0x10,
	}

	/// <summary>Describes the degree of remoteness of the RPC connection.</summary>
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcOptions")]
	public enum RPCOPT_SERVER_LOCALITY_VALUES
	{
		/// <summary>The counterpart is in the same process as the client.</summary>
		SERVER_LOCALITY_PROCESS_LOCAL = 0,

		/// <summary>The counterpart is on the same computer as the client but in a different process.</summary>
		SERVER_LOCALITY_MACHINE_LOCAL = 1,

		/// <summary>The counterpart is on a remote computer.</summary>
		SERVER_LOCALITY_REMOTE = 2
	}

	/// <summary>
	/// The <c>STREAM_SEEK</c> enumeration values specify the origin from which to calculate the new seek-pointer location. They are
	/// used for the dworigin parameter in the IStream::Seek method. The new seek position is calculated using this value and the
	/// dlibMove parameter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-stream_seek typedef enum tagSTREAM_SEEK { STREAM_SEEK_SET,
	// STREAM_SEEK_CUR, STREAM_SEEK_END } STREAM_SEEK;
	[PInvokeData("objidl.h", MSDNShortId = "NE:objidl.tagSTREAM_SEEK")]
	public enum STREAM_SEEK
	{
		/// <summary>
		/// The new seek pointer is an offset relative to the beginning of the stream. In this case, the dlibMove parameter is the new
		/// seek position relative to the beginning of the stream.
		/// </summary>
		STREAM_SEEK_SET,

		/// <summary>
		/// The new seek pointer is an offset relative to the current seek pointer location. In this case, the dlibMove parameter is the
		/// signed displacement from the current seek position.
		/// </summary>
		STREAM_SEEK_CUR,

		/// <summary>
		/// The new seek pointer is an offset relative to the end of the stream. In this case, the dlibMove parameter is the new seek
		/// position relative to the end of the stream.
		/// </summary>
		STREAM_SEEK_END,
	}

	/// <summary>Indicates whether a particular thread supports a message loop.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ne-objidl-thdtype typedef enum _THDTYPE { THDTYPE_BLOCKMESSAGES,
	// THDTYPE_PROCESSMESSAGES } THDTYPE;
	[PInvokeData("objidl.h", MSDNShortId = "NE:objidl._THDTYPE")]
	public enum THDTYPE
	{
		/// <summary>The thread does not support a message loop. This behavior is associated with multithreaded apartments.</summary>
		THDTYPE_BLOCKMESSAGES,

		/// <summary>The thread supports a message loop. This behavior is associated with single-threaded apartments.</summary>
		THDTYPE_PROCESSMESSAGES,
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("objidl.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000017-0000-0000-C000-000000000046")]
	public interface IActivationFilter
	{
		/// <summary>Handles the activation.</summary>
		/// <param name="dwActivationType">Type of the activation.</param>
		/// <param name="rclsid">The CLSID.</param>
		/// <param name="pReplacementClsId">The replacement CLSID.</param>
		/// <returns>An appropriate error response.</returns>
		[PreserveSig]
		HRESULT HandleActivation(ACTIVATIONTYPE dwActivationType, in Guid rclsid, out Guid pReplacementClsId);
	}

	/// <summary>Creates a call object for processing calls to the methods of an asynchronous interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nn-objidlbase-icallfactory
	[PInvokeData("objidlbase.h", MSDNShortId = "NN:objidlbase.ICallFactory")]
	[ComImport, Guid("1c733a30-2a1c-11ce-ade5-00aa0044773d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICallFactory
	{
		/// <summary>Creates an instance of the call object that corresponds to a specified asynchronous interface.</summary>
		/// <param name="riid">A reference to the identifier for the asynchronous interface.</param>
		/// <param name="pCtrlUnk">
		/// A pointer to the controlling IUnknown of the call object. If this parameter is not <c>NULL</c>, the call object is
		/// aggregated in the specified object. If this parameter is <c>NULL</c>, the call object is not aggregated.
		/// </param>
		/// <param name="riid2">The identifier of an interface on the call object. Typical values are IID_IUnknown and IID_ISynchronize.</param>
		/// <param name="ppv">The address of a pointer to the interface specified by riid2. This parameter cannot be <c>NULL</c>.</param>
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
		/// <term>The call object was created successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The riid parameter does not reference the identifier for the asynchronous interface, such as IID_AsyncIEventSourceCallback.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icallfactory-createcall HRESULT CreateCall( REFIID riid,
		// IUnknown *pCtrlUnk, REFIID riid2, IUnknown **ppv );
		[PreserveSig]
		HRESULT CreateCall(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object? pCtrlUnk,
			in Guid riid2, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppv);
	}

	/// <summary>
	/// Manages cancellation requests on an outbound method call and monitors the current state of that method call on the server thread.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-icancelmethodcalls
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ICancelMethodCalls")]
	[ComImport, Guid("00000029-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICancelMethodCalls
	{
		/// <summary>Requests that a method call be canceled.</summary>
		/// <param name="ulSeconds">
		/// The number of seconds to wait for the server to complete the outbound call after the client requests cancellation.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The cancellation request was made.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_CALL_CANCELED</term>
		/// <term>The call was already canceled.</term>
		/// </item>
		/// <item>
		/// <term>CO_E_CANCEL_DISABLED</term>
		/// <term>Call cancellation is not enabled on the thread that is processing the call.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CALL_COMPLETE</term>
		/// <term>The call was completed during the timeout interval.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Cancel</c> method only issues a cancel request. A return value of S_OK does not mean that the call was canceled, only
		/// that an attempt was made to cancel the call. The behavior of the cancel object on receiving a cancel request is entirely at
		/// the discretion of the implementer.
		/// </para>
		/// <para>If a method that returns an <c>HRESULT</c> is canceled, the return value will be RPC_S_CALL_CANCELED.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icancelmethodcalls-cancel HRESULT Cancel( ULONG ulSeconds );
		[PreserveSig]
		HRESULT Cancel([In] uint ulSeconds);

		/// <summary>Determines whether a call has been canceled.</summary>
		/// <returns>If the call was canceled, the return value is RPC_E_CALL_CANCELED. Otherwise, it is RPC_S_CALLPENDING.</returns>
		/// <remarks>
		/// <para>
		/// The server object calls <c>TestCancel</c> to determine if the call has been canceled. If the call has been canceled, the
		/// server should clean up the necessary resources and return control to the client.
		/// </para>
		/// <para>This method can be called from both the client and the server.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icancelmethodcalls-testcancel HRESULT TestCancel();
		[PreserveSig]
		HRESULT TestCancel();
	}

	/// <summary>Provides a mechanism to intercept and modify calls when the COM engine processes the calls.</summary>
	[PInvokeData("objidlbase.h")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1008c4a0-7613-11cf-9af1-0020af6e72f4")]
	public interface IChannelHook
	{
		/// <summary/>
		[PreserveSig]
		void ClientGetSize(in Guid uExtent, in Guid riid, out uint pDataSize);

		/// <summary/>
		[PreserveSig]
		void ClientFillBuffer(in Guid uExtent, in Guid riid, ref uint pDataSize, IntPtr pDataBuffer);

		/// <summary/>
		[PreserveSig]
		void ClientNotify(in Guid uExtent, in Guid riid, uint cbDataSize, IntPtr pDataBuffer, uint lDataRep, HRESULT hrFault);

		/// <summary/>
		[PreserveSig]
		void ServerNotify(in Guid uExtent, in Guid riid, uint cbDataSize, IntPtr pDataBuffer, uint lDataRep);

		/// <summary/>
		[PreserveSig]
		void ServerGetSize(in Guid uExtent, in Guid riid, HRESULT hrFault, out uint pDataSize);

		/// <summary/>
		[PreserveSig]
		void ServerFillBuffer(in Guid uExtent, in Guid riid, ref uint pDataSize, IntPtr pDataBuffer, HRESULT hrFault);
	}

	/// <summary>Gives the client control over the security settings for each individual interface proxy of an object.</summary>
	/// <remarks>
	/// <para>
	/// Every object has one proxy manager, and every proxy manager exposes the <c>IClientSecurity</c> interface automatically.
	/// Therefore, the client can query the proxy manager of an object for <c>IClientSecurity</c>, using any interface pointer on the
	/// object. If the QueryInterface call succeeds, the <c>IClientSecurity</c> pointer can be used to call an <c>IClientSecurity</c>
	/// method, passing a pointer to the interface proxy that the client is interested in. If a call to <c>QueryInterface</c> for
	/// <c>IClientSecurity</c> fails, either the object is implemented in-process or it is remoted by a custom marshaler that does not
	/// support security. (A custom marshaler can support security by offering the <c>IClientSecurity</c> interface to the client.)
	/// </para>
	/// <para>
	/// The interface proxies passed as parameters to <c>IClientSecurity</c> methods must be from the same object as the
	/// <c>IClientSecurity</c> interface. That is, each object has a distinct <c>IClientSecurity</c> interface; calling
	/// <c>IClientSecurity</c> on one object and passing a proxy to another object will not work. Also, you cannot pass an interface to
	/// an <c>IClientSecurity</c> method if the interface does not use a proxy. This means that interfaces implemented locally by the
	/// proxy manager cannot be passed to <c>IClientSecurity</c> methods, except for IUnknown, which is the exception to this rule.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iclientsecurity
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IClientSecurity")]
	[ComImport, Guid("0000013D-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IClientSecurity
	{
		/// <summary>Retrieves authentication information the client uses to make calls on the specified proxy.</summary>
		/// <param name="pProxy">
		/// A pointer to the proxy. This parameter cannot be <c>NULL</c>. For more information, see the Remarks section.
		/// </param>
		/// <param name="pAuthnSvc">
		/// The current authentication service. This will be a single value taken from the list of authentication service constants.
		/// This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pAuthzSvc">
		/// The current authorization service. This will be a single value taken from the list of authorization constants. This
		/// parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pServerPrincName">
		/// The current principal name. The string will be allocated by the callee using the CoTaskMemAlloc function and must be freed
		/// by the caller using the CoTaskMemFree function. Note that the actual principal name is returned. The EOAC_MAKE_FULLSIC flag
		/// is not accepted to convert the prinicpal name. If the caller specifies <c>NULL</c>, the current principal name is not retrieved.
		/// </param>
		/// <param name="pAuthnLevel">
		/// The current authentication level. This will be a single value taken from the list of authentication level constants. If this
		/// parameter is <c>NULL</c>, the current authentication level is not retrieved.
		/// </param>
		/// <param name="pImpLevel">
		/// The current impersonation level. This will be a single value taken from the list of impersonation level constants. If this
		/// parameter is <c>NULL</c>, the current impersonation level is not retrieved.
		/// </param>
		/// <param name="pAuthInfo">
		/// <para>
		/// A pointer to a handle indicating the identity of the client that was passed to the last IClientSecurity::SetBlanket call (or
		/// the default value). Default values are only valid until the proxy is released. If the caller specifies <c>NULL</c>, the
		/// client identity is not retrieved.
		/// </para>
		/// <para>
		/// The format of the structure that the returned handle refers to depends on the authentication service. For NTLMSSP and
		/// Kerberos, if the client specified a structure in the pAuthInfo parameter to CoInitializeSecurity, that value is returned.
		/// For Schannel, if a certificate for the client could be retrieved from the certificate manager, that value is returned here.
		/// Otherwise, <c>NULL</c> is returned. Because this points to the value itself and is not a copy, it should not be manipulated
		/// or freed.
		/// </para>
		/// </param>
		/// <param name="pCapabilites">
		/// The capabilities of the proxy. These flags are defined in the EOLE_AUTHENTICATION_CAPABILITIES enumeration. If this
		/// parameter is <c>NULL</c>, the current capability flags are not retrieved.
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
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to create the pServerPrincName buffer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>QueryBlanket</c> is called by the client to retrieve the authentication information COM will use on calls made from the
		/// specified interface proxy. With a pointer to an interface on the proxy, the client would first call QueryInterface for a
		/// pointer to IClientSecurity; then, with this pointer, the client would call <c>QueryBlanket</c>, followed by releasing the
		/// pointer. This sequence of calls is encapsulated in the helper function CoQueryProxyBlanket.
		/// </para>
		/// <para>
		/// In pProxy, you pass an interface pointer. However, you cannot pass a pointer to an interface that does not use a proxy. Thus
		/// you cannot pass a pointer to an interface that has the local keyword in its interface definition since no proxy is created
		/// for such an interface. IUnknown is the exception to this rule.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iclientsecurity-queryblanket HRESULT QueryBlanket(
		// IUnknown *pProxy, DWORD *pAuthnSvc, DWORD *pAuthzSvc, OLECHAR **pServerPrincName, DWORD *pAuthnLevel, DWORD *pImpLevel, void
		// **pAuthInfo, DWORD *pCapabilites );
		[PreserveSig]
		HRESULT QueryBlanket([In, MarshalAs(UnmanagedType.IUnknown)] object pProxy, out RPC_C_AUTHN pAuthnSvc, out RPC_C_AUTHZ pAuthzSvc,
			[MarshalAs(UnmanagedType.LPWStr)] out string pServerPrincName, out RPC_C_AUTHN_LEVEL pAuthnLevel, out RPC_C_IMP_LEVEL pImpLevel,
			out IntPtr pAuthInfo, out EOLE_AUTHENTICATION_CAPABILITIES pCapabilites);

		/// <summary>
		/// <para>Sets the authentication information (the security blanket) that will be used to make calls on the specified proxy.</para>
		/// <para>
		/// This setting overrides the process default settings for the specified proxy. Calling this method changes the security values
		/// for all other users of the specified proxy.
		/// </para>
		/// </summary>
		/// <param name="pProxy">A pointer to the proxy.</param>
		/// <param name="dwAuthnSvc">
		/// The authentication service. This will be a single value taken from the list of authentication service constants. If no
		/// authentication is required, use RPC_C_AUTHN_NONE. If RPC_C_AUTHN_DEFAULT is specified, COM will pick an authentication
		/// service following its normal security blanket negotiation algorithm.
		/// </param>
		/// <param name="dwAuthzSvc">
		/// The authorization service. This will be a single value taken from the list of authorization constants. If
		/// RPC_C_AUTHZ_DEFAULT is specified, COM will pick an authorization service following its normal security blanket negotiation
		/// algorithm. If NTLMSSP, Kerberos, or Schannel is used as the authentication service, RPC_C_AUTHZ_NONE should be used as the
		/// authorization service.
		/// </param>
		/// <param name="pServerPrincName">
		/// <para>
		/// The server principal name. If COLE_DEFAULT_PRINCIPAL is specified, DCOM will pick a principal name using its security
		/// blanket negotiation algorithm. If Kerberos is used as the authentication service, this parameter must be the correct
		/// principal name of the server or the call will fail.
		/// </para>
		/// <para>
		/// If Schannel is used as the authentication service, this value must be one of the msstd or fullsic forms described in
		/// Principal Names, or <c>NULL</c> if you do not want mutual authentication.
		/// </para>
		/// <para>
		/// Generally, specifying <c>NULL</c> will not reset server principal name on the proxy, rather, the previous setting will be
		/// retained. You must exercise care when using <c>NULL</c> as pServerPrincName when selecting a different authentication
		/// service for the proxy, because there is no guarantee that the previously set principal name would be valid for the newly
		/// selected authentication service.
		/// </para>
		/// </param>
		/// <param name="dwAuthnLevel">
		/// The authentication level. This will be a single value taken from the list of authentication level constants. If
		/// RPC_C_AUTHN_LEVEL_DEFAULT is specified, COM will pick an authentication level following its normal security blanket
		/// negotiation algorithm. If this value is set to RPC_C_AUTHN_LEVEL_NONE, the authentication service must be RPC_C_AUTHN_NONE.
		/// Each authentication service may choose to use a higher security authentication level than the one specified.
		/// </param>
		/// <param name="dwImpLevel">
		/// The impersonation level. This will be a single value taken from the list of impersonation level constants. If
		/// RPC_C_IMP_LEVEL_DEFAULT is specified, COM will pick an impersonation level following its normal security blanket negotiation
		/// algorithm. If you are using NTLMSSP remotely, this value must be RPC_C_IMP_LEVEL_IMPERSONATE or RPC_C_IMP_LEVEL_IDENTIFY.
		/// When using NTLMSSP on the same computer, RPC_C_IMP_LEVEL_DELEGATE is also supported. For Kerberos, this value can be
		/// RPC_C_IMP_LEVEL_IDENTIFY, RPC_C_IMP_LEVEL_IMPERSONATE, or RPC_C_IMP_LEVEL_DELEGATE. For Schannel, this value must be RPC_C_IMP_LEVEL_IMPERSONATE.
		/// </param>
		/// <param name="pAuthInfo">
		/// <para>
		/// An RPC_AUTH_IDENTITY_HANDLE value that indicates the identity of the client. This parameter is not used for calls on the
		/// same computer. If pAuthInfo is <c>NULL</c>, COM uses the current proxy identity, which is either the process token, the
		/// impersonation token, or the authentication identity from the CoInitializeSecurity function. If the handle is not
		/// <c>NULL</c>, that identity is used. The format of the structure referred to by the handle depends on the provider of the
		/// authentication service.
		/// </para>
		/// <para>
		/// For NTLMSSP or Kerberos, the structure is a SEC_WINNT_AUTH_IDENTITY or SEC_WINNT_AUTH_IDENTITY_EX structure. If the client
		/// obtains the credentials set on the proxy by calling CoQueryProxyBlanket, it must ensure that the memory remains valid and
		/// unchanged until a different identity is set on the proxy or all proxies on the object are released.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, COM uses the current proxy identity (which is either the process token or the
		/// impersonation token). If the handle refers to a structure, that identity is used.
		/// </para>
		/// <para>
		/// For Schannel, this parameter must either be a pointer to a CERT_CONTEXT structure that contains the client's X.509
		/// certificate, or <c>NULL</c> if the client wishes to make an anonymous connection to the server. If a certificate is
		/// specified, the caller must not free it as long as any proxy to the object exists in the current apartment.
		/// </para>
		/// <para>
		/// For Snego, this member is either <c>NULL</c>, points to a SEC_WINNT_AUTH_IDENTITY structure, or points to a
		/// SEC_WINNT_AUTH_IDENTITY_EX structure. If it is <c>NULL</c>, Snego will pick a list of authentication services based on those
		/// available on the client computer. If it points to a <c>SEC_WINNT_AUTH_IDENTITY_EX</c> structure, the structure's
		/// <c>PackageList</c> member must point to a string containing a comma-separated list of authentication service names and the
		/// <c>PackageListLength</c> member must give the number of bytes in the <c>PackageList</c> string. If <c>PackageList</c> is
		/// <c>NULL</c>, all calls using Snego will fail.
		/// </para>
		/// <para>
		/// If COLE_DEFAULT_AUTHINFO is specified, COM will pick the authentication information following its normal security blanket
		/// negotiation algorithm.
		/// </para>
		/// <para><c>SetBlanket</c> will return an error if both pAuthInfo is set and one of the cloaking flags is set in dwCapabilities.</para>
		/// </param>
		/// <param name="dwCapabilities">
		/// The capabilities of this proxy. Capability flags are defined in the EOLE_AUTHENTICATION_CAPABILITIES enumeration. The only
		/// flags that can be set through this method are EOAC_MUTUAL_AUTH, EOAC_STATIC_CLOAKING, EOAC_DYNAMIC_CLOAKING,
		/// EOAC_ANY_AUTHORITY (this flag is deprecated), EOAC_MAKE_FULLSIC, and EOAC_DEFAULT. Either EOAC_STATIC_CLOAKING or
		/// EOAC_DYNAMIC_CLOAKING can be set if pAuthInfo is not set and Schannel is not the authentication service. (See Cloaking for
		/// more information.) If any capability flags other than those mentioned here are indicated, <c>SetBlanket</c> will return an error.
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
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SetBlanket</c> sets the authentication information that will be used to make calls on the specified interface proxy. The
		/// values specified here override the values chosen by automatic security. Calling this method changes the security values for
		/// all other users of the specified proxy. If you want the changes to apply only to a particular instance of a proxy, call
		/// IClientSecurity::CopyProxy to make a private copy of the proxy and then call <c>SetBlanket</c> on the copy.
		/// </para>
		/// <para>
		/// Whenever this method is called, DCOM will set the identity on the proxy, and future calls made using this proxy will use
		/// this identity. Calls in progress when <c>SetBlanket</c> is called will use the authentication information on the proxy at
		/// the time the call was started. If pAuthInfo is <c>NULL</c>, the proxy identity defaults to the current process token (unless
		/// an authentication identity was specified on a call to CoInitializeSecurity). See Cloaking to learn how the cloaking flags
		/// affect the proxy when pAuthInfo is <c>NULL</c>.
		/// </para>
		/// <para>
		/// By default, COM will choose the first available authentication service and authorization service available on both the
		/// client and server computers and the principal name that the server registered for that authentication service. Currently,
		/// COM will not try another authentication service if the first fails.
		/// </para>
		/// <para>
		/// When the default constant for dwImpLevel is specified in <c>SetBlanket</c>, the parameter defaults to the value specified to
		/// CoInitializeSecurity. If <c>CoInitializeSecurity</c> is not called, it defaults to RPC_C_IMP_LEVEL_IDENTIFY.
		/// </para>
		/// <para>
		/// The initial value for dwAuthnLevel on a proxy will be the higher of the value set on the client's call to
		/// CoInitializeSecurity and the server's call to <c>CoInitializeSecurity</c>. For any process that did not call
		/// <c>CoInitializeSecurity</c>, the default authentication level is RPC_C_AUTHN_CONNECT.
		/// </para>
		/// <para>
		/// The default authentication and impersonation level for processes that do not call CoInitializeSecurity can be set with DCOMCNFG.
		/// </para>
		/// <para>
		/// If EOAC_DEFAULT is specified for dwCapabilities, the valid capabilities from CoInitializeSecurity will be used. If
		/// <c>CoInitializeSecurity</c> was not called, EOAC_NONE will be used for the capabilities flag.
		/// </para>
		/// <para>
		/// If <c>SetBlanket</c> is called simultaneously on two threads on the same proxy, only one set of changes will be applied. If
		/// <c>SetBlanket</c> and <c>CRpcOptions::Set</c> are called simultaneously on two threads on the same proxy, both changes may
		/// be applied or only one may be applied.
		/// </para>
		/// <para>
		/// Security information cannot be set on local interfaces such as the IClientSecurity interface. However, since that interface
		/// is only supported locally, there is no need for security. IUnknown and IMultiQI are special cases. The location
		/// implementation makes remote calls to support these interfaces. <c>SetBlanket</c> can be used for <c>IUnknown</c>.
		/// <c>IMultiQI</c> will use the security settings on <c>IUnknown</c>.
		/// </para>
		/// <para>
		/// To change one <c>SetBlanket</c> parameter without having to deal with the others, one can specify the default constants for
		/// the other parameters. Applications can change a parameter (such as the authentication level) and ignore the other
		/// parameters, including the authentication service, by setting all other parameters to the default constants.
		/// </para>
		/// <para>
		/// Note that it is important to set all unused parameters to the default constants because the default value is often not
		/// obvious. In particular, if you set the authentication service to the default, you should set the authentication information
		/// and principal name to the default. The reasons for this are twofold: First, the type of the authentication information
		/// depends on the authentication service DCOM chooses. Second, because DCOM needs to pass some complex authentication
		/// information for certain authentication services, if you set the authentication service to default and the authentication
		/// information to <c>NULL</c>, you might get a security setting that will not work.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iclientsecurity-setblanket HRESULT SetBlanket( IUnknown
		// *pProxy, DWORD dwAuthnSvc, DWORD dwAuthzSvc, OLECHAR *pServerPrincName, DWORD dwAuthnLevel, DWORD dwImpLevel, void
		// *pAuthInfo, DWORD dwCapabilities );
		[PreserveSig]
		HRESULT SetBlanket([In, MarshalAs(UnmanagedType.IUnknown)] object pProxy, RPC_C_AUTHN dwAuthnSvc, RPC_C_AUTHZ dwAuthzSvc,
			[MarshalAs(UnmanagedType.LPWStr)] string? pServerPrincName, RPC_C_AUTHN_LEVEL dwAuthnLevel, RPC_C_IMP_LEVEL dwImpLevel,
			[In, Optional] IntPtr pAuthInfo, EOLE_AUTHENTICATION_CAPABILITIES dwCapabilities);

		/// <summary>Makes a private copy of the proxy for the specified interface.</summary>
		/// <param name="pProxy">A pointer to the interface whose proxy is to be copied. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="ppCopy">
		/// A pointer to the IUnknown interface pointer that receives the copy of the proxy. This parameter cannot be <c>NULL</c>.
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
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CopyProxy</c> is called by the client to make a private copy of the proxy for the specified interface. The proxy copy has
		/// default values for the authentication information. Its authentication information can be changed through a call to
		/// IClientSecurity::SetBlanket without affecting any other clients of the original proxy. The copy has one reference, and the
		/// caller of <c>CopyProxy</c> must ensure that the proxy copy gets freed.
		/// </para>
		/// <para>
		/// Local interfaces, such as IUnknown and IClientSecurity, cannot be copied. You cannot duplicate a proxy manager using <c>CopyProxy</c>.
		/// </para>
		/// <para>
		/// Copies of the same proxy have a special relationship with respect to QueryInterface. Given a proxy, a, of the IA interface
		/// of a remote object, suppose a copy of a is created, called b. In this case, calling <c>QueryInterface</c> from the b proxy
		/// for IID_IA will not retrieve the IA interface on b, but the one on a, the original proxy.
		/// </para>
		/// <para>
		/// Notice that anyone can query for a proxy and change security on it using SetBlanket. However, when you have made a copy of a
		/// proxy, no one can get the copy unless you give it to them. Only people who have the copy can set security on it.
		/// </para>
		/// <para>
		/// The helper function CoCopyProxy encapsulates a QueryInterface call for a pointer to IClientSecurity, a call to
		/// <c>CopyProxy</c> with the IClientSecurity pointer, and the release of the <c>IClientSecurity</c> pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iclientsecurity-copyproxy HRESULT CopyProxy( IUnknown
		// *pProxy, IUnknown **ppCopy );
		[PreserveSig]
		HRESULT CopyProxy([In, MarshalAs(UnmanagedType.IUnknown)] object pProxy, [MarshalAs(UnmanagedType.IUnknown)] out object ppCopy);
	}

	/// <summary>
	/// Enables you to obtain the following information about the apartment and thread that the caller is executing in: apartment type,
	/// thread type, and thread GUID. It also allows you to specify a thread GUID.
	/// </summary>
	/// <remarks>An instance of this interface for the current context can be obtained using CoGetObjectContext.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-icomthreadinginfo
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IComThreadingInfo")]
	[ComImport, Guid("000001ce-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IComThreadingInfo
	{
		/// <summary>Retrieves the type of apartment in which the caller is executing.</summary>
		/// <param name="pAptType">A points to an APTTYPE enumeration value that characterizes the caller's apartment.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The caller is not executing in an apartment.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icomthreadinginfo-getcurrentapartmenttype HRESULT
		// GetCurrentApartmentType( APTTYPE *pAptType );
		[PreserveSig]
		HRESULT GetCurrentApartmentType(out APTTYPE pAptType);

		/// <summary>Retrieves the type of thread in which the caller is executing.</summary>
		/// <param name="pThreadType">A pointer to a THDTYPE enumeration value that characterizes the caller's thread.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The caller is not executing in an apartment.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icomthreadinginfo-getcurrentthreadtype HRESULT
		// GetCurrentThreadType( THDTYPE *pThreadType );
		[PreserveSig]
		HRESULT GetCurrentThreadType(out THDTYPE pThreadType);

		/// <summary>Retrieves the GUID of the thread in which the caller is executing.</summary>
		/// <param name="pguidLogicalThreadId">A pointer to the GUID of the caller's thread.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The caller is not executing in an apartment.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icomthreadinginfo-getcurrentlogicalthreadid HRESULT
		// GetCurrentLogicalThreadId( GUID *pguidLogicalThreadId );
		[PreserveSig]
		HRESULT GetCurrentLogicalThreadId(out Guid pguidLogicalThreadId);

		/// <summary>Sets the GUID of the thread in which the caller is executing.</summary>
		/// <param name="rguid">A reference to a GUID for the caller's thread.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The caller is not executing in an apartment.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-icomthreadinginfo-setcurrentlogicalthreadid HRESULT
		// SetCurrentLogicalThreadId( REFGUID rguid );
		[PreserveSig]
		HRESULT SetCurrentLogicalThreadId(in Guid rguid);
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-getproperty HRESULT GetProperty( REFGUID
		// rGuid, CPFLAGS *pFlags, IUnknown **ppUnk );
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
	public interface IEnumContextProps : Vanara.Collections.ICOMEnum<ContextProperty>
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
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ContextProperty[] pContextProperties,
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
		/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
		/// time. The caller must release this new enumerator separately from the first enumerator.
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
	/// Enumerate strings. <c>LPWSTR</c> is the type that indicates a pointer to a zero-terminated string of wide, or Unicode, characters.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ienumstring
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IEnumString")]
	[ComImport, Guid("00000101-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumStringV : Vanara.Collections.ICOMEnum<string>
	{
		/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">
		/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
		/// retrieves the remaining elements.
		/// </param>
		/// <param name="rgelt">
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
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ienumstring-next HRESULT Next( ULONG celt, LPOLESTR
		// *rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rgelt, out uint pceltFetched);

		/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of items to be skipped.</param>
		/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ienumstring-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <remarks>
		/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
		/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
		/// guarantee this condition.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ienumstring-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
		/// <para>
		/// This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later
		/// time. The caller must release this new enumerator separately from the first enumerator.
		/// </para>
		/// </summary>
		/// <returns>A pointer to the cloned enumerator object.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-ienumstring-clone HRESULT Clone( IEnumString **ppenum );
		IEnumStringV Clone();
	}

	/// <summary>
	/// Manages a server object's count of marshaled, or external, connections. A server that maintains such a count can detect when it
	/// has no external connections and shut itself down in an orderly fashion.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <c>IExternalConnection</c> is most commonly implemented on server objects, to enable the orderly shutdown of a link to an
	/// embedded object following a silent update. Objects that do not implement <c>IExternalConnection</c> risk losing data in such a
	/// situation: When the final link client releases the embedded (server) object, the last external connection on the object's stub
	/// manager is released, causing the stub manager to release its pointers to interfaces on the embedded object and initiate shutdown
	/// of the object. At this point, the server object calls IOleClientSite::SaveObject on the link container, and the link container's
	/// return call to IPersistStorage::Save fails because the stub manager no longer has a pointer to the embedded object. Any unsaved
	/// changes to the server object's data would then be lost.
	/// </para>
	/// <para>
	/// If the server object implements <c>IExternalConnection</c>, however, its stub manager will not release its connection to the
	/// object when the last external connection is released. Instead, it will stay connected until the object is ready to destroy itself.
	/// </para>
	/// <para>
	/// In standard marshaling, to increment the object's count of external connections, COM calls IExternalConnection::AddConnection on
	/// the object when the object is first marshaled. The stub manager calls the methods of <c>IExternalConnection</c> on the object as
	/// subsequent external connections are obtained and released. When the object's count of external connections goes to zero, the
	/// object can save its data and then revoke itself from the running object table and do whatever else is necessary to reduce its
	/// object reference count to zero.
	/// </para>
	/// <para>
	/// An object that implements <c>IExternalConnection</c> should explicitly call CoDisconnectObject on itself when its external
	/// reference count drops to 0. This call will cause the stub manager to call Release on the object so that the object can destroy itself.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iexternalconnection
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IExternalConnection")]
	[ComImport, Guid("00000019-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IExternalConnection
	{
		/// <summary>Increments the count of an object's strong external connections.</summary>
		/// <param name="extconn">
		/// The type of external connection to the object. The only type of external connection currently supported by this interface is
		/// strong, which means that the object must remain alive as long as this external connection exists. Strong external
		/// connections are represented by the value EXTCONN_STRONG, which is defined in the enumeration EXTCONN.
		/// </param>
		/// <param name="reserved">
		/// Information about the connection. This parameter is reserved for use by OLE. Its value can be zero, but not necessarily.
		/// Therefore, implementations of <c>AddConnection</c> should not contain blocks of code whose execution depends on whether a
		/// zero value is returned.
		/// </param>
		/// <returns>The method returns the count of connections. This value is intended to be used only for debugging purposes.</returns>
		/// <remarks>
		/// <para>
		/// An object created by a EXE object server relies on its stub manager to call <c>AddConnection</c> whenever a link client
		/// activates and therefore creates an external lock on the object. When the link client breaks the connection, the stub manager
		/// calls IExternalConnection::ReleaseConnection to release the lock.
		/// </para>
		/// <para>
		/// DLL object applications exist in the same process space as their objects, so they do not use RPC (remote procedure calls)
		/// and do not have stub managers to keep track of external connections. Therefore, DLL servers that support external links to
		/// their objects must implement IExternalConnection so that link clients can directly call the interface to inform them when
		/// connections are added or released.
		/// </para>
		/// <para>The following is a typical implementation for the <c>AddConnection</c> method.</para>
		/// <para>
		/// <code>DWORD MyInterface::AddConnection(DWORD extconn, DWORD dwReserved) { return extconn &amp; EXTCONN_STRONG ? ++m_cStrong : 0; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iexternalconnection-addconnection DWORD AddConnection(
		// DWORD extconn, DWORD reserved );
		[PreserveSig]
		uint AddConnection(EXTCONN extconn, [In, Optional] uint reserved);

		/// <summary>Decrements the count of an object's strong external connections.</summary>
		/// <param name="extconn">
		/// The type of external connection to the object. The only type of external connection currently supported by this interface is
		/// strong, which means that the object must remain alive as long as this external connection exists. Strong external
		/// connections are represented by the value EXTCONN_STRONG, which is defined in the enumeration EXTCONN.
		/// </param>
		/// <param name="reserved">
		/// Information about the connection. This parameter is reserved for use by OLE. Its value can be zero, but not necessarily.
		/// Therefore, implementations of <c>ReleaseConnection</c> should not contain blocks of code whose execution depends on whether
		/// a zero value is returned.
		/// </param>
		/// <param name="fLastReleaseCloses">
		/// This parameter is <c>TRUE</c> if the connection being released is the last external lock on the object, and therefore the
		/// object should close. Otherwise, the object should remain open until closed by the user or another process.
		/// </param>
		/// <returns>The method returns the count of connections. This value is intended to be used only for debugging purposes.</returns>
		/// <remarks>
		/// If fLastReleaseCloses equals <c>TRUE</c>, calling <c>ReleaseConnection</c> causes the object to shut itself down. Calling
		/// this method is the only way in which a DLL object, running in the same process space as the container application, will know
		/// when to close following a silent update.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iexternalconnection-releaseconnection DWORD
		// ReleaseConnection( DWORD extconn, DWORD reserved, BOOL fLastReleaseCloses );
		[PreserveSig]
		uint ReleaseConnection(EXTCONN extconn, [Optional] uint reserved, [MarshalAs(UnmanagedType.Bool)] bool fLastReleaseCloses);
	}

	/// <summary>Marks an interface as eligible for fast rundown behavior.</summary>
	/// <remarks>
	/// <para>
	/// A Component Object Model (COM) object implements the <c>IFastRundown</c> marker interface to opt into the fast rundown behavior.
	/// </para>
	/// <para>
	/// All Windows Store app processes, as well as the broker processes RuntimeBroker.exe and PickerHost.exe, apply fast rundown at the
	/// process level, which means that all objects in any of these processes are subjected to fast rundown automatically. Desktop
	/// processes don't get this behavior by default and must opt in at the process level. Specific objects opt in by implementing the
	/// <c>IFastRundown</c> marker interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ifastrundown
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IFastRundown")]
	[ComImport, Guid("00000040-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFastRundown
	{
	}

	/// <summary>
	/// Enables any apartment in a process to get access to an interface implemented on an object in any other apartment in the process.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IGlobalInterfaceTable</c> interface is an efficient way for a process to store an interface pointer in a memory location
	/// that can be accessed from multiple apartments within the process, such as processwide variables and agile (free-threaded
	/// marshaled) objects containing interface pointers to other objects.
	/// </para>
	/// <para>
	/// An agile object is unaware of the underlying COM infrastructure in which it runsâ€”in other words, what apartment, context, and
	/// thread it is executing on. The object may be holding on to interfaces that are specific to an apartment or context. For this
	/// reason, calling these interfaces from wherever the agile component is executing may not always work properly. The global
	/// interface table avoids this problem by guaranteeing that a valid proxy (or direct pointer) to the object is used, based on where
	/// the agile object is executing.
	/// </para>
	/// <para>
	/// The global interface table is not portable across process or machine boundaries, so it cannot be used in place of the normal
	/// parameter-passing mechanism.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iglobalinterfacetable
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IGlobalInterfaceTable")]
	[ComImport, Guid("00000146-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGlobalInterfaceTable
	{
		/// <summary>
		/// Registers the specified interface on an object residing in one apartment of a process as a global interface, enabling other
		/// apartments access to that interface.
		/// </summary>
		/// <param name="pUnk">
		/// An interface pointer of type riid on the object on which the interface to be registered as global is implemented.
		/// </param>
		/// <param name="riid">The IID of the interface to be registered as global.</param>
		/// <param name="pdwCookie">
		/// An identifier that can be used by another apartment to get access to a pointer to the interface being registered. The value
		/// of an invalid cookie is 0.
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
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Called in the apartment in which an object resides to register one of the object's interfaces as a global interface. This
		/// method supplies a pointer to a cookie that other apartments can use in a call to the GetInterfaceFromGlobal method to get a
		/// pointer to that interface.
		/// </para>
		/// <para>
		/// The interface pointer may be a pointer to an in-process object, or it may be a pointer to a proxy for an object residing in
		/// another apartment, in another process, or on another computer.
		/// </para>
		/// <para>The apartment that calls this method must remain alive until the corresponding call to RevokeInterfaceFromGlobal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iglobalinterfacetable-registerinterfaceinglobal HRESULT
		// RegisterInterfaceInGlobal( IUnknown *pUnk, REFIID riid, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT RegisterInterfaceInGlobal([In, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] object pUnk, in Guid riid, out uint pdwCookie);

		/// <summary>Revokes the registration of an interface in the global interface table.</summary>
		/// <param name="dwCookie">Identifies the interface whose global registration is to be revoked.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The parameter is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Call this method when an interface registered in the global interface table object no longer needs to be accessed by other
		/// apartments in the same process. This method can be called by any apartment in the process, including apartments other than
		/// the one that registered the interface in the global interface table.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iglobalinterfacetable-revokeinterfacefromglobal HRESULT
		// RevokeInterfaceFromGlobal( DWORD dwCookie );
		[PreserveSig]
		HRESULT RevokeInterfaceFromGlobal([In] uint dwCookie);

		/// <summary>
		/// Retrieves a pointer to an interface on an object that is usable by the calling apartment. This interface must be currently
		/// registered in the global interface table.
		/// </summary>
		/// <param name="dwCookie">Identifies the interface (and its object), and is retrieved through a call to IGlobalInterfaceTable::RegisterInterfaceInGlobal.</param>
		/// <param name="riid">The IID of the interface.</param>
		/// <param name="ppv">A pointer to the pointer for the requested interface.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After an interface has been registered in the global interface table, an apartment can get a pointer to this interface by
		/// calling the <c>GetInterfaceFromGlobal</c> method with the supplied cookie. This pointer to the interface can be used in the
		/// calling apartment but not by other apartments in the process.
		/// </para>
		/// <para>
		/// The application is responsible for coordinating access to the global variable during calls to
		/// IGlobalInterfaceTable::RevokeInterfaceFromGlobal. That is, the application should ensure that one thread does not call
		/// <c>RevokeInterfaceFromGlobal</c> while another thread is calling <c>GetInterfaceFromGlobal</c> with the same cookie.
		/// Multiple calls to <c>GetInterfaceFromGlobal</c> for the same cookie are permitted.
		/// </para>
		/// <para>
		/// The <c>GetInterfaceFromGlobal</c> method calls AddRef on the pointer obtained in the ppv parameter. It is the caller's
		/// responsibility to call Release on this pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iglobalinterfacetable-getinterfacefromglobal HRESULT
		// GetInterfaceFromGlobal( DWORD dwCookie, REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT GetInterfaceFromGlobal([In] uint dwCookie, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);
	}

	/// <summary>
	/// Used exclusively in lightweight client-side handlers that require access to some of the internal interfaces on the proxy.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Handlers that need access to some of the internal interfaces on the proxy manager have to go through the <c>IInternalUnknown</c>
	/// interface. This prevents the handlers from blindly delegating and exposing the aggregatee's internal interfaces outside of the
	/// aggregate. These interfaces include IClientSecurity and IMultiQI. If the handler wants to expose <c>IClientSecurity</c> or
	/// <c>IMultiQI</c>, the handler should implement these interfaces itself and delegate to the proxy manager's implementation of
	/// these interfaces when appropriate.
	/// </para>
	/// <para>
	/// For the IClientSecurity interface, if the client tries to set the security on an interface that the handler has exposed, the
	/// handler should set the security on the underlying network interface proxy.
	/// </para>
	/// <para>
	/// For the IMultiQI interface, the handler should fill in the interfaces it knows about and then forward the call to the proxy
	/// manager to fill in the rest of the interfaces.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nn-objidlbase-iinternalunknown
	[PInvokeData("objidlbase.h", MSDNShortId = "NN:objidlbase.IInternalUnknown")]
	[ComImport, Guid("00000021-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IInternalUnknown
	{
		/// <summary>Retrieves pointers to the supported internal interfaces on an object.</summary>
		/// <param name="riid">The identifier of the internal interface being requested.</param>
		/// <param name="ppv">
		/// The address of a pointer variable that receives the interface pointer requested in the riid parameter. Upon successful
		/// return, *ppv contains the requested interface pointer to the object. If the object does not support the interface, *ppv is
		/// set to <c>NULL</c>.
		/// </param>
		/// <returns>This method returns S_OK if the interface is supported, and E_NOINTERFACE otherwise.</returns>
		/// <remarks>
		/// This method is similar to the IUnknown::QueryInterface method, except that the COM proxy manager, when aggregated, will not
		/// expose some interfaces through <c>QueryInterface</c>. Instead, those internal interfaces must be exposed through <c>QueryInternalInterface</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iinternalunknown-queryinternalinterface HRESULT
		// QueryInternalInterface( REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT QueryInternalInterface(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);
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
		/// This method reallocates a block of memory, but does not guarantee that its contents are initialized. Therefore, the caller
		/// is responsible for subsequently initializing the memory. The allocated block may be larger than cb bytes because of the
		/// space required for alignment and for maintenance information.
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
	/// Marshaling is the process of packaging data into packets for transmission to a different process or computer. Unmarshaling is
	/// the process of recovering that data at the receiving end. In any given call, method arguments are marshaled and unmarshaled in
	/// one direction, while return values are marshaled and unmarshaled in the other.
	/// </para>
	/// <para>
	/// Although marshaling applies to all data types, interface pointers require special handling. The fundamental problem is how
	/// client code running in one address space can correctly dereference a pointer to an interface on an object residing in a
	/// different address space. The COM solution is for a client application to communicate with the original object through a
	/// surrogate object, or proxy, which lives in the client's process. The proxy holds a reference to an interface on the original
	/// object and hands the client a pointer to an interface on itself. When the client calls an interface method on the original
	/// object, its call is actually going to the proxy. Therefore, from the client's point of view, all calls are in-process.
	/// </para>
	/// <para>
	/// On receiving a call, the proxy marshals the method arguments and through some means of interprocess communication, such as RPC,
	/// passes them along to code in the server process, which unmarshals the arguments and passes them to the original object. This
	/// same code marshals return values for transmission back to the proxy, which unmarshals the values and passes them to the client application.
	/// </para>
	/// <para>
	/// <c>IMarshal</c> provides methods for creating, initializing, and managing a proxy in a client process; it does not dictate how
	/// the proxy should communicate with the original object. The COM default implementation of <c>IMarshal</c> uses RPC. When you
	/// implement this interface yourself, you are free to choose any method of interprocess communication you deem to be appropriate
	/// for your application—shared memory, named pipe, window handle, RPC—in short, whatever works.
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
	/// write their own proxy and marshaling routines, know at compile time all the interfaces to be found on their objects and
	/// therefore understand exactly what marshaling code is required. COM, in providing marshaling support for all objects, must do so
	/// at run time.
	/// </para>
	/// <para>
	/// The interface proxy resides in the client process; the interface stub resides in the server. Together, each pair handles all
	/// marshaling for the interface. The job of each interface proxy is to marshal arguments and unmarshal return values and out
	/// parameters that are passed back and forth in subsequent calls to its interface. The job of each interface stub is to unmarshal
	/// function arguments and pass them along to the original object and then marshal the return values and out parameters that the
	/// object returns.
	/// </para>
	/// <para>
	/// Proxy and stub communicate by means of an RPC (remote procedure call) channel, which utilizes the system's RPC infrastructure
	/// for interprocess communication. The RPC channel implements a single interface, IRpcChannelBuffer, to which both interface
	/// proxies and stubs hold a pointer. The proxy and stub call the interface to obtain a marshaling packet, send the data to their
	/// counterpart, and destroy the packet when they are done. The interface stub also holds a pointer to the original object.
	/// </para>
	/// <para>
	/// For any given interface, the proxy and stub are both implemented as instances of the same class, which is listed for each
	/// interface in the system registry under the label <c>ProxyStubClsid32</c>. This entry maps the interface's IID to the
	/// <c>CLSID</c> of its proxy and stub objects. When COM needs to marshal an interface, it looks in the system registry to obtain
	/// the appropriate <c>CLSID</c>. The server identified by this <c>CLSID</c> implements both the interface proxy and interface stub.
	/// </para>
	/// <para>
	/// Most often, the class to which this <c>CLSID</c> refers is automatically generated by a tool whose input is a description of the
	/// function signatures and semantics of a given interface, written in some interface description language. While using such a
	/// language is highly recommended and encouraged for accuracy's sake, doing so is not required. Proxies and stubs are merely COM
	/// components used by the RPC infrastructure and, as such, can be written in any manner desired, as long as the correct external
	/// contracts are upheld. The programmer who designs a new interface is responsible for ensuring that all interface proxies and
	/// stubs that ever exist agree on the representation of their marshaled data.
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
	/// interfaces implemented on entirely different objects. Such a requirement does not exist in the server process, however, where
	/// the object itself resides, because all interface stubs communicate only with the objects for which they were created. No other
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
		/// The destination context where the specified interface is to be unmarshaled. Possible values come from the enumeration
		/// MSHCTX. Unmarshaling can occur either in another apartment of the current process (MSHCTX_INPROC) or in another process on
		/// the same computer as the current process (MSHCTX_LOCAL).
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
		/// marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of
		/// several interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include
		/// the IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a
		/// pointer is called the marshaling stub.
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
		/// Definition Language (MIDL) to define your own interfaces. In either case, the stub automatically makes the call. See
		/// Defining COM Interfaces.
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
		/// COM calls <c>GetUnmarshalClass</c> to obtain the CLSID to be used for creating a proxy in the client process. The CLSID to
		/// be used for a proxy is normally not that of the original object, but one you will have generated (using the Guidgen.exe
		/// tool) specifically for your proxy object.
		/// </para>
		/// <para>
		/// Implement this method for each object that provides marshaling for one or more of its interfaces. The code responsible for
		/// marshaling the object writes the CLSID, along with the marshaling data, to a stream; COM extracts the CLSID and data from
		/// the stream on the receiving side.
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
		Guid GetUnmarshalClass(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pv, [In] MSHCTX dwDestContext,
			[In, Optional] IntPtr pvDestContext, [In] MSHLFLAGS mshlflags);

		/// <summary>Retrieves the maximum size of the buffer that will be needed during marshaling.</summary>
		/// <param name="riid">A reference to the identifier of the interface to be marshaled.</param>
		/// <param name="pv">The interface pointer to be marshaled. This parameter can be <c>NULL</c>.</param>
		/// <param name="dwDestContext">
		/// The destination context where the specified interface is to be unmarshaled. Possible values come from the enumeration
		/// MSHCTX. Unmarshaling can occur either in another apartment of the current process (MSHCTX_INPROC) or in another process on
		/// the same computer as the current process (MSHCTX_LOCAL).
		/// </param>
		/// <param name="pvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <param name="mshlflags">
		/// Indicates whether the data to be marshaled is to be transmitted back to the client processâ€”the typical caseâ€”or written
		/// to a global table, where it can be retrieved by multiple clients. Possible values come from the MSHLFLAGS enumeration.
		/// </param>
		/// <returns>A pointer to a variable that receives the maximum size of the buffer.</returns>
		/// <remarks>
		/// <para>
		/// This method is called indirectly, in a call to CoGetMarshalSizeMax, by whatever code in the server process is responsible
		/// for marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of
		/// several interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include
		/// the IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a
		/// pointer is called the marshaling stub.
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
		/// To ensure that your implementation of <c>GetMarshalSizeMax</c> will continue to work properly as new destination contexts
		/// are supported in the future, delegate marshaling to the COM default implementation for all dwDestContext values that your
		/// implementation does not understand. To delegate marshaling to the COM default implementation, call the CoGetStandardMarshal function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-getmarshalsizemax HRESULT GetMarshalSizeMax(
		// REFIID riid, void *pv, DWORD dwDestContext, void *pvDestContext, DWORD mshlflags, DWORD *pSize );
		uint GetMarshalSizeMax(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pv, [In] MSHCTX dwDestContext,
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
		/// marshaling a pointer to an interface on an object. This marshaling code is usually a stub generated by COM for one of
		/// several interfaces that can marshal a pointer to an interface implemented on an entirely different object. Examples include
		/// the IClassFactory and IOleItemContainer interfaces. For purposes of discussion, the code responsible for marshaling a
		/// pointer is called the marshaling stub.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Typically, rather than calling <c>MarshalInterface</c> directly, your marshaling stub instead should call the
		/// CoMarshalInterface function, which contains a call to this method. The stub makes this call to command an object to write
		/// its marshaling data into a stream. The stub then either passes the marshaling data back to the client process or writes it
		/// to a global table, where it can be unmarshaled by multiple clients. The stub's call to <c>CoMarshalInterface</c> is normally
		/// preceded by a call to CoGetMarshalSizeMax to get the maximum size of the stream buffer into which the marshaling data will
		/// be written.
		/// </para>
		/// <para>
		/// You do not explicitly call this method if you are implementing existing COM interfaces or defining your own interfaces using
		/// the Microsoft Interface Definition Language (MIDL). In either case, the MIDL-generated stub automatically makes the call.
		/// </para>
		/// <para>
		/// If you are not using MIDL to define your own interface, your marshaling stub must call this method, either directly or
		/// indirectly. Your stub implementation should call <c>MarshalInterface</c> immediately after its previous call to
		/// IMarshal::GetMarshalSizeMax returns. Because the value returned by <c>GetMarshalSizeMax</c> is guaranteed to be valid only
		/// as long as the internal state of the object being marshaled does not change, a delay in calling <c>MarshalInterface</c> runs
		/// the risk that the object will require a larger stream buffer than originally indicated.
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
		/// or written to a global table, where it can be unmarshaled by multiple clients. You must make sure that your object can
		/// handle calls from the multiple proxies that might be created from the same initialization data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-marshalinterface HRESULT MarshalInterface(
		// IStream *pStm, REFIID riid, void *pv, DWORD dwDestContext, void *pvDestContext, DWORD mshlflags );
		void MarshalInterface([In] IStream pStm, in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pv,
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
		/// IMarshal::MarshalInterface and use that data to initialize the proxy object whose CLSID was returned by the marshaling
		/// stub's call to the original object's implementation of IMarshal::GetUnmarshalClass.
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
		/// If an object's marshaled data packet does not get unmarshaled in the client process space and the packet is no longer
		/// needed, the client calls <c>ReleaseMarshalData</c> on the proxy's IMarshal implementation to instruct the object to destroy
		/// the data packet. The call occurs within the CoReleaseMarshalData function. The data packet serves as an additional reference
		/// on the object, and releasing the data is like releasing an interface pointer by calling Release.
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
		/// information associated with the data packet represented by pStm. Your implementation should also position the seek pointer
		/// in the stream past the last byte of data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-imarshal-releasemarshaldata HRESULT ReleaseMarshalData(
		// IStream *pStm );
		void ReleaseMarshalData([In] IStream pStm);

		/// <summary>
		/// Releases all connections to an object. The object's server calls the object's implementation of this method prior to
		/// shutting down.
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
		/// As part of its normal shutdown code, a server should call CoDisconnectObject, which in turn calls <c>DisconnectObject</c>,
		/// on each of its running objects that implements IMarshal.
		/// </para>
		/// <para>
		/// The outcome of any implementation of this method should be to enable a proxy to respond to all subsequent calls from its
		/// client by returning RPC_E_DISCONNECTED or CO_E_OBJNOTCONNECTED rather than attempting to forward the calls on to the
		/// original object. It is up to the client to destroy the proxy.
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

	/// <summary>Provides additional information about the marshaling context to custom-marshaled objects and unmarshalers.</summary>
	/// <remarks>
	/// Implement <c>IMarshalingStream</c> interface if you have IStream implementations that call the marshaling APIs and provide the
	/// correct value of any of the attributes. This is essential only for <c>IStream</c> implementations that are used in hybrid policy processes.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-imarshalingstream
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IMarshalingStream")]
	[ComImport, Guid("D8F2F5E6-6102-4863-9F26-389A4676EFDE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMarshalingStream : IStreamV
	{
		/// <summary>
		/// The <c>Read</c> method reads a specified number of bytes from the stream object into memory, starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">A pointer to the buffer which the stream data is read into.</param>
		/// <param name="cb">The number of bytes of data to read from the stream object.</param>
		/// <param name="pcbRead">
		/// <para>A pointer to a <c>ULONG</c> variable that receives the actual number of bytes read from the stream object.</para>
		/// <para><c>Note</c> The number of bytes read may be zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method reads bytes from this stream object into memory. The stream object must be opened in <c>STGM_READ</c> mode. This
		/// method adjusts the seek pointer by the actual number of bytes read.
		/// </para>
		/// <para>The number of bytes actually read is also returned in the pcbRead parameter.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The actual number of bytes read can be less than the number of bytes requested if an error occurs or if the end of the
		/// stream is reached during the read operation. The number of bytes returned should always be compared to the number of bytes
		/// requested. If the number of bytes returned is less than the number of bytes requested, it usually means the <c>Read</c>
		/// method attempted to read past the end of the stream.
		/// </para>
		/// <para>The application should handle both a returned error and <c>S_OK</c> return values on end-of-stream read operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-read HRESULT Read( void *pv, ULONG
		// cb, ULONG *pcbRead );
		[PInvokeData("objidl.h", MSDNShortId = "934a90bb-5ed0-4d80-9906-352ad8586655")]
		[PreserveSig]
		new HRESULT Read(byte[] pv, uint cb, out uint pcbRead);

		/// <summary>
		/// The <c>Write</c> method writes a specified number of bytes into the stream object starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">
		/// A pointer to the buffer that contains the data that is to be written to the stream. A valid pointer must be provided for
		/// this parameter even when cb is zero.
		/// </param>
		/// <param name="cb">The number of bytes of data to attempt to write into the stream. This value can be zero.</param>
		/// <param name="pcbWritten">
		/// A pointer to a <c>ULONG</c> variable where this method writes the actual number of bytes written to the stream object. The
		/// caller can set this pointer to <c>NULL</c>, in which case this method does not provide the actual number of bytes written.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ISequentialStream::Write</c> writes the specified data to a stream object. The seek pointer is adjusted for the number of
		/// bytes actually written. The number of bytes actually written is returned in the pcbWritten parameter. If the byte count is
		/// zero bytes, the write operation has no effect.
		/// </para>
		/// <para>
		/// If the seek pointer is currently past the end of the stream and the byte count is nonzero, this method increases the size of
		/// the stream to the seek pointer and writes the specified bytes starting at the seek pointer. The fill bytes written to the
		/// stream are not initialized to any particular value. This is the same as the end-of-file behavior in the MS-DOS FAT file system.
		/// </para>
		/// <para>
		/// With a zero byte count and a seek pointer past the end of the stream, this method does not create the fill bytes to increase
		/// the stream to the seek pointer. In this case, you must call the IStream::SetSize method to increase the size of the stream
		/// and write the fill bytes.
		/// </para>
		/// <para>The pcbWritten parameter can have a value even if an error occurs.</para>
		/// <para>
		/// In the COM-provided implementation, stream objects are not sparse. Any fill bytes are eventually allocated on the disk and
		/// assigned to the stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-write HRESULT Write( const void *pv,
		// ULONG cb, ULONG *pcbWritten );
		[PInvokeData("objidl.h", MSDNShortId = "f0323dda-6c31-4411-bf20-9650162109c0")]
		[PreserveSig]
		new HRESULT Write(byte[] pv, uint cb, out uint pcbWritten);

		/// <summary>
		/// The <c>Seek</c> method changes the seek pointer to a new location. The new location is relative to either the beginning of
		/// the stream, the end of the stream, or the current seek pointer.
		/// </summary>
		/// <param name="dlibMove">
		/// The displacement to be added to the location indicated by the dwOrigin parameter. If dwOrigin is <c>STREAM_SEEK_SET</c>,
		/// this is interpreted as an unsigned value rather than a signed value.
		/// </param>
		/// <param name="dwOrigin">
		/// The origin for the displacement specified in dlibMove. The origin can be the beginning of the file (
		/// <c>STREAM_SEEK_SET</c>), the current seek pointer ( <c>STREAM_SEEK_CUR</c>), or the end of the file (
		/// <c>STREAM_SEEK_END</c>). For more information about values, see the STREAM_SEEK enumeration.
		/// </param>
		/// <param name="plibNewPosition">
		/// <para>A pointer to the location where this method writes the value of the new seek pointer from the beginning of the stream.</para>
		/// <para>You can set this pointer to <c>NULL</c>. In this case, this method does not provide the new seek pointer.</para>
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// <c>IStream::Seek</c> changes the seek pointer so that subsequent read and write operations can be performed at a different
		/// location in the stream object. It is an error to seek before the beginning of the stream. It is not, however, an error to
		/// seek past the end of the stream. Seeking past the end of the stream is useful for subsequent write operations, as the stream
		/// byte range will be extended to the new seek position immediately before the write is complete.
		/// </para>
		/// <para>
		/// You can also use this method to obtain the current value of the seek pointer by calling this method with the dwOrigin
		/// parameter set to <c>STREAM_SEEK_CUR</c> and the dlibMove parameter set to 0 so that the seek pointer is not changed. The
		/// current seek pointer is returned in the plibNewPosition parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-seek HRESULT Seek( LARGE_INTEGER dlibMove, DWORD
		// dwOrigin, ULARGE_INTEGER *plibNewPosition );
		[PreserveSig]
		new HRESULT Seek(long dlibMove, STREAM_SEEK dwOrigin, out ulong plibNewPosition);

		/// <summary>The <c>SetSize</c> method changes the size of the stream object.</summary>
		/// <param name="libNewSize">Specifies the new size, in bytes, of the stream.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// <c>IStream::SetSize</c> changes the size of the stream object. Call this method to preallocate space for the stream. If the
		/// libNewSize parameter is larger than the current stream size, the stream is extended to the indicated size by filling the
		/// intervening space with bytes of undefined value. This operation is similar to the ISequentialStream::Write method if the
		/// seek pointer is past the current end of the stream.
		/// </para>
		/// <para>If the libNewSize parameter is smaller than the current stream, the stream is truncated to the indicated size.</para>
		/// <para>The seek pointer is not affected by the change in stream size.</para>
		/// <para>Calling <c>IStream::SetSize</c> can be an effective way to obtain a large chunk of contiguous space.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-setsize HRESULT SetSize( ULARGE_INTEGER
		// libNewSize );
		[PreserveSig]
		new HRESULT SetSize(long libNewSize);

		/// <summary>
		/// The <c>CopyTo</c> method copies a specified number of bytes from the current seek pointer in the stream to the current seek
		/// pointer in another stream.
		/// </summary>
		/// <param name="pstm">
		/// A pointer to the destination stream. The stream pointed to by pstm can be a new stream or a clone of the source stream.
		/// </param>
		/// <param name="cb">The number of bytes to copy from the source stream.</param>
		/// <param name="pcbRead">
		/// A pointer to the location where this method writes the actual number of bytes read from the source. You can set this pointer
		/// to <c>NULL</c>. In this case, this method does not provide the actual number of bytes read.
		/// </param>
		/// <param name="pcbWritten">
		/// A pointer to the location where this method writes the actual number of bytes written to the destination. You can set this
		/// pointer to <c>NULL</c>. In this case, this method does not provide the actual number of bytes written.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CopyTo</c> method copies the specified bytes from one stream to another. It can also be used to copy a stream to
		/// itself. The seek pointer in each stream instance is adjusted for the number of bytes read or written. This method is
		/// equivalent to reading cb bytes into memory using ISequentialStream::Read and then immediately writing them to the
		/// destination stream using ISequentialStream::Write, although <c>IStream::CopyTo</c> will be more efficient.
		/// </para>
		/// <para>The destination stream can be a clone of the source stream created by calling the IStream::Clone method.</para>
		/// <para>
		/// If <c>IStream::CopyTo</c> returns an error, you cannot assume that the seek pointers are valid for either the source or
		/// destination. Additionally, the values of pcbRead and pcbWritten are not meaningful even though they are returned.
		/// </para>
		/// <para>If <c>IStream::CopyTo</c> returns successfully, the actual number of bytes read and written are the same.</para>
		/// <para>
		/// To copy the remainder of the source from the current seek pointer, specify the maximum large integer value for the cb
		/// parameter. If the seek pointer is the beginning of the stream, this operation copies the entire stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-copyto HRESULT CopyTo( IStream *pstm,
		// ULARGE_INTEGER cb, ULARGE_INTEGER *pcbRead, ULARGE_INTEGER *pcbWritten );
		[PreserveSig]
		new HRESULT CopyTo(IStream pstm, long cb, out ulong pcbRead, out ulong pcbWritten);

		/// <summary>
		/// The <c>Commit</c> method ensures that any changes made to a stream object open in transacted mode are reflected in the
		/// parent storage. If the stream object is open in direct mode, <c>IStream::Commit</c> has no effect other than flushing all
		/// memory buffers to the next-level storage object. The COM compound file implementation of streams does not support opening
		/// streams in transacted mode.
		/// </summary>
		/// <param name="grfCommitFlags">
		/// Controls how the changes for the stream object are committed. See the STGC enumeration for a definition of these values.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>Commit</c> method ensures that changes to a stream object opened in transacted mode are reflected in the parent
		/// storage. Changes that have been made to the stream since it was opened or last committed are reflected to the parent storage
		/// object. If the parent is opened in transacted mode, the parent may revert at a later time, rolling back the changes to this
		/// stream object. The compound file implementation does not support the opening of streams in transacted mode, so this method
		/// has very little effect other than to flush memory buffers. For more information, see IStream - Compound File Implementation.
		/// </para>
		/// <para>
		/// If the stream is open in direct mode, this method ensures that any memory buffers have been flushed out to the underlying
		/// storage object. This is much like a flush in traditional file systems.
		/// </para>
		/// <para>
		/// The <c>IStream::Commit</c> method is useful on a direct mode stream when the implementation of the IStream interface is a
		/// wrapper for underlying file system APIs. In this case, <c>IStream::Commit</c> would be connected to the file system's flush call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-commit HRESULT Commit( DWORD grfCommitFlags );
		[PreserveSig]
		new HRESULT Commit(STGC grfCommitFlags);

		/// <summary>
		/// The <c>Revert</c> method discards all changes that have been made to a transacted stream since the last IStream::Commit
		/// call. On streams open in direct mode and streams using the COM compound file implementation of <c>IStream::Revert</c>, this
		/// method has no effect.
		/// </summary>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>The <c>Revert</c> method discards changes made to a transacted stream since the last commit operation.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-revert HRESULT Revert();
		[PreserveSig]
		new HRESULT Revert();

		/// <summary>
		/// The <c>LockRegion</c> method restricts access to a specified range of bytes in the stream. Supporting this functionality is
		/// optional since some file systems do not provide it.
		/// </summary>
		/// <param name="libOffset">Integer that specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Integer that specifies the length of the range, in bytes, to be restricted.</param>
		/// <param name="dwLockType">Specifies the restrictions being requested on accessing the range.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The byte range of the stream can be extended. Locking an extended range for the stream is useful as a method of
		/// communication between different instances of the stream without changing data that is actually part of the stream.
		/// </para>
		/// <para>
		/// Three types of locking can be supported: locking to exclude other writers, locking to exclude other readers or writers, and
		/// locking that allows only one requester to obtain a lock on the given range, which is usually an alias for one of the other
		/// two lock types. A given stream instance might support either of the first two types, or both. The lock type is specified by
		/// dwLockType, using a value from the LOCKTYPE enumeration.
		/// </para>
		/// <para>
		/// Any region locked with <c>IStream::LockRegion</c> must later be explicitly unlocked by calling IStream::UnlockRegion with
		/// exactly the same values for the libOffset, cb, and dwLockType parameters. The region must be unlocked before the stream is
		/// released. Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Since the type of locking supported is optional and can vary in different implementations of IStream, you must provide code
		/// to deal with the STG_E_INVALIDFUNCTION error.
		/// </para>
		/// <para>
		/// The <c>LockRegion</c> method has no effect in the compound file implementation, because the implementation does not support
		/// range locking.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Support for this method is optional for implementations of stream objects since it may not be supported by the underlying
		/// file system. The type of locking supported is also optional. The STG_E_INVALIDFUNCTION error is returned if the requested
		/// type of locking is not supported.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-lockregion HRESULT LockRegion( ULARGE_INTEGER
		// libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PreserveSig]
		new HRESULT LockRegion(long libOffset, long cb, LOCKTYPE dwLockType);

		/// <summary>
		/// The <c>UnlockRegion</c> method removes the access restriction on a range of bytes previously restricted with IStream::LockRegion.
		/// </summary>
		/// <param name="libOffset">Specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Specifies, in bytes, the length of the range to be restricted.</param>
		/// <param name="dwLockType">Specifies the access restrictions previously placed on the range.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <c>IStream::UnlockRegion</c> unlocks a region previously locked with the IStream::LockRegion method. Locked regions must
		/// later be explicitly unlocked by calling <c>IStream::UnlockRegion</c> with exactly the same values for the libOffset, cb, and
		/// dwLockType parameters. The region must be unlocked before the stream is released. Two adjacent regions cannot be locked
		/// separately and then unlocked with a single unlock call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-unlockregion HRESULT UnlockRegion( ULARGE_INTEGER
		// libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PreserveSig]
		new HRESULT UnlockRegion(long libOffset, long cb, LOCKTYPE dwLockType);

		/// <summary>The <c>Stat</c> method retrieves the STATSTG structure for this stream.</summary>
		/// <param name="pstatstg">Pointer to a STATSTG structure where this method places information about this stream object.</param>
		/// <param name="grfStatFlag">
		/// Specifies that this method does not return some of the members in the STATSTG structure, thus saving a memory allocation
		/// operation. Values are taken from the STATFLAG enumeration.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <c>IStream::Stat</c> retrieves a pointer to the STATSTG structure that contains information about this open stream. When
		/// this stream is within a structured storage and IStorage::EnumElements is called, it creates an enumerator object with the
		/// IEnumSTATSTG interface on it, which can be called to enumerate the storages and streams through the <c>STATSTG</c>
		/// structures associated with each of them.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-stat HRESULT Stat( STATSTG *pstatstg, DWORD
		// grfStatFlag );
		[PreserveSig]
		new HRESULT Stat(out STATSTG pstatstg, STATFLAG grfStatFlag);

		/// <summary>
		/// The <c>Clone</c> method creates a new stream object with its own seek pointer that references the same bytes as the original stream.
		/// </summary>
		/// <param name="ppstm">
		/// When successful, pointer to the location of an IStream pointer to the new stream object. If an error occurs, this parameter
		/// is <c>NULL</c>.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>Clone</c> method creates a new stream object for accessing the same bytes but using a separate seek pointer. The new
		/// stream object sees the same data as the source-stream object. Changes written to one object are immediately visible in the
		/// other. Range locking is shared between the stream objects.
		/// </para>
		/// <para>
		/// The initial setting of the seek pointer in the cloned stream instance is the same as the current setting of the seek pointer
		/// in the original stream at the time of the clone operation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-clone HRESULT Clone( IStream **ppstm );
		[PreserveSig]
		new HRESULT Clone(out IStream? ppstm);

		/// <summary>Gets information about the marshaling context.</summary>
		/// <param name="attribute">The attribute to query.</param>
		/// <param name="pAttributeValue">The value of attribute.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>Each possible value of the attribute parameter is paired with the data type of the attribute this identifies.</para>
		/// <para>You can query the following attributes with this method.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Values</term>
		/// </listheader>
		/// <item>
		/// <term>CO_MARSHALING_SOURCE_IS_APP_CONTAINER</term>
		/// <term>
		/// This attribute is a boolean value, with 0 representing TRUE and nonzero representing FALSE. You can safely cast the value of
		/// the result to BOOL, but it isn't safe for the caller to cast a BOOL* to ULONG_PTR* for the pAttributeValue parameter, or for
		/// the implementation to cast pAttributeValue to BOOL* when setting it.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-imarshalingstream-getmarshalingcontextattribute HRESULT
		// GetMarshalingContextAttribute( CO_MARSHALING_CONTEXT_ATTRIBUTES attribute, ULONG_PTR *pAttributeValue );
		[PreserveSig]
		HRESULT GetMarshalingContextAttribute(CO_MARSHALING_CONTEXT_ATTRIBUTES attribute, out IntPtr pAttributeValue);
	}

	/// <summary>
	/// Enables a client to query an object proxy, or handler, for multiple interfaces by using a single RPC call. By using this
	/// interface, instead of relying on separate calls to IUnknown::QueryInterface, clients can reduce the number of RPC calls that
	/// have to cross thread, process, or machine boundaries and, therefore, the amount of time required to obtain the requested
	/// interface pointers.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-imultiqi
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IMultiQI")]
	[ComImport, Guid("00000020-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMultiQI
	{
		/// <summary>
		/// <para>Retrieves pointers to multiple supported interfaces on an object.</para>
		/// <para>
		/// Calling this method is equivalent to issuing a series of separate QueryInterface calls except that you do not incur the
		/// overhead of a corresponding number of RPC calls. In multithreaded applications and distributed environments, keeping RPC
		/// calls to a minimum is essential for optimal performance.
		/// </para>
		/// </summary>
		/// <param name="cMQIs">The number of elements in the pMQIs array.</param>
		/// <param name="pMQIs">An array of MULTI_QI structures. For more information, see Remarks.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method retrieved pointers to all requested interfaces.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The method retrieved pointers to some, but not all, of the requested interfaces.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The method retrieved pointers to none of the requested interfaces.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryMultipleInterfaces</c> method takes as input an array of MULTI_QI structures. Each structure specifies an
		/// interface IID and contains two additional members for receiving an interface pointer and return value.
		/// </para>
		/// <para>
		/// This method obtains as many requested interface pointers as possible directly from the object proxy. For each interface not
		/// implemented on the proxy, the method calls the server to obtain a pointer. Upon receiving an interface pointer from the
		/// server, the method builds a corresponding interface proxy and returns its pointer along with pointers to the interfaces it
		/// already implements.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A caller should begin by querying the object proxy for the IMultiQI interface. If the object proxy returns a pointer to this
		/// interface, the caller should then create a MULTI_QI structure for each interface it wants to obtain. Each structure should
		/// specify an interface IID and set its <c>pItf</c> member to <c>NULL</c>. Failure to set the <c>pItf</c> member to <c>NULL</c>
		/// will cause the object proxy to ignore the structure.
		/// </para>
		/// <para>
		/// On return, <c>QueryMultipleInterfaces</c> writes the requested interface pointer and a return value into each MULTI_QI
		/// structure in the client's array. The <c>pItf</c> member receives the pointer; the <c>hr</c> member receives the return value.
		/// </para>
		/// <para>
		/// If the value returned from a call to <c>QueryMultipleInterfaces</c> is S_OK, then pointers were returned for all requested interfaces.
		/// </para>
		/// <para>
		/// If the return value is E_NOINTERFACE, then pointers were returned for none of the requested interfaces. If the return value
		/// is S_FALSE, then pointers to one or more requested interfaces were not returned. In this event, the client should check the
		/// <c>hr</c> member of each MULTI_QI structure to determine which interfaces were acquired and which were not.
		/// </para>
		/// <para>
		/// If a client knows ahead of time that it will be using several of an object's interfaces, it can call
		/// <c>QueryMultipleInterfaces</c> up front and then, later, if a QueryInterface is done for one of the interfaces already
		/// acquired through <c>QueryMultipleInterfaces</c>, no RPC call will be necessary.
		/// </para>
		/// <para>
		/// On return, the caller should check the <c>hr</c> member of each MULTI_QI structure to determine which interface pointers
		/// were and were not returned.
		/// </para>
		/// <para>The client is responsible for releasing each of the acquired interfaces by calling Release.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-imultiqi-querymultipleinterfaces HRESULT
		// QueryMultipleInterfaces( ULONG cMQIs, MULTI_QI *pMQIs );
		[PreserveSig]
		HRESULT QueryMultipleInterfaces([In] uint cMQIs, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] MULTI_QI[] pMQIs);
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-getproperty HRESULT GetProperty( REFGUID
		// rGuid, CPFLAGS *pFlags, IUnknown **ppUnk );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		new object GetProperty(in Guid rGuid, out uint pFlags);

		/// <summary>
		/// Returns an IEnumContextProps interface pointer that can be used to enumerate the context properties in this context.
		/// </summary>
		/// <returns>The address of the variable that receives the new IEnumContextProps interface pointer.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-icontext-enumcontextprops HRESULT EnumContextProps(
		// IEnumContextProps **ppEnumContextProps );
		new IEnumContextProps EnumContextProps();

		/// <summary/>
		void Reserved1();

		/// <summary/>
		void Reserved2();

		/// <summary/>
		void Reserved3();

		/// <summary/>
		void Reserved4();

		/// <summary/>
		void Reserved5();

		/// <summary/>
		void Reserved6();

		/// <summary/>
		void Reserved7();
	}

	/// <summary>Specifies the process initialization time-out interval.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iprocessinitcontrol
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IProcessInitControl")]
	[ComImport, Guid("72380d55-8d2b-43a3-8513-2b6ef31434e9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProcessInitControl
	{
		/// <summary>Sets the process initialization time-out.</summary>
		/// <param name="dwSecondsRemaining">
		/// The number of seconds after this method is called before process initialization times out.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iprocessinitcontrol-resetinitializertimeout
		// HRESULT ResetInitializerTimeout( DWORD dwSecondsRemaining );
		[PreserveSig]
		HRESULT ResetInitializerTimeout(uint dwSecondsRemaining);
	}

	/// <summary>Provides custom methods for the creation of COM object proxies and stubs. This interface is not marshalable.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ipsfactorybuffer
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IPSFactoryBuffer")]
	[ComImport, Guid("D5F569D0-593B-101A-B569-08002B2DBF7A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPSFactoryBuffer
	{
		/// <summary>Creates a proxy for the specified remote interface.</summary>
		/// <param name="pUnkOuter">A controlling IUnknown interface; used for aggregation.</param>
		/// <param name="riid">The identifier of the interface to proxy.</param>
		/// <param name="ppProxy">A pointer to an IRpcProxyBuffer interface to control marshaling.</param>
		/// <param name="ppv">A pointer to the interface specified by riid.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>The IUnknown implementation of the IRpcProxyBuffer interface must not delegate to the outer controlling <c>IUnknown</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-ipsfactorybuffer-createproxy HRESULT CreateProxy(
		// IUnknown *pUnkOuter, REFIID riid, IRpcProxyBuffer **ppProxy, void **ppv );
		[PreserveSig]
		HRESULT CreateProxy([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, in Guid riid, out IRpcProxyBuffer ppProxy,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppv);

		/// <summary>Creates a stub for the remote use of the specified interface.</summary>
		/// <param name="riid">The identifier of the interface for which a stub is to be created.</param>
		/// <param name="pUnkServer">A controlling IUnknown interface; used for aggregation.</param>
		/// <param name="ppStub">A pointer to an IRpcStubBuffer interface pointer to control marshaling.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-ipsfactorybuffer-createstub HRESULT CreateStub(
		// REFIID riid, IUnknown *pUnkServer, IRpcStubBuffer **ppStub );
		[PreserveSig]
		HRESULT CreateStub(in Guid riid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkServer, out IRpcStubBuffer ppStub);
	}

	/// <summary>Marshals data between a COM client proxy and a COM server stub.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irpcchannelbuffer
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcChannelBuffer")]
	[ComImport, Guid("D5F56B60-593B-101A-B569-08002B2DBF7A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRpcChannelBuffer
	{
		/// <summary>Retrieves a buffer into which data can be marshaled for transmission.</summary>
		/// <param name="pMessage">A pointer to an RPCOLEMESSAGE data structure.</param>
		/// <param name="riid">A reference to the identifier of the interface to be marshaled.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcchannelbuffer-getbuffer HRESULT GetBuffer(
		// RPCOLEMESSAGE *pMessage, REFIID riid );
		[PreserveSig]
		HRESULT GetBuffer(ref RPCOLEMESSAGE pMessage, in Guid riid);

		/// <summary>Sends a method invocation across an RPC channel to the server stub.</summary>
		/// <param name="pMessage">A pointer to an RPCOLEMESSAGE structure that has been populated with marshaled data.</param>
		/// <param name="pStatus">If not <c>NULL</c>, set to 0 on successful execution.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// Before invoking this method, the GetBuffer method must have been invoked to allocate a channel buffer. Upon return, the
		/// <c>dataRepresentation</c> buffer of the RPCOLEMESSAGE structure will have been modified to include the data returned by the
		/// method invoked on the server. If the invocation was successful, the RPC channel buffer has been freed; otherwise the caller
		/// must free it explicitly by calling FreeBuffer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcchannelbuffer-sendreceive HRESULT
		// SendReceive( RPCOLEMESSAGE *pMessage, ULONG *pStatus );
		[PreserveSig]
		HRESULT SendReceive(ref RPCOLEMESSAGE pMessage, [Out, Optional] IntPtr pStatus);

		/// <summary>Frees a previously allocated RPC channel buffer.</summary>
		/// <param name="pMessage">A pointer to an RPCOLEMESSAGE data structure.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcchannelbuffer-freebuffer HRESULT FreeBuffer(
		// RPCOLEMESSAGE *pMessage );
		[PreserveSig]
		HRESULT FreeBuffer(ref RPCOLEMESSAGE pMessage);

		/// <summary>Retrieves the destination context for the RPC channel.</summary>
		/// <param name="pdwDestContext">
		/// The destination context in which the interface is unmarshaled. Possible values come from the MSHCTX enumeration.
		/// </param>
		/// <param name="ppvDestContext">This parameter is reserved and must be <c>NULL</c>.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcchannelbuffer-getdestctx HRESULT GetDestCtx( DWORD
		// *pdwDestContext, void **ppvDestContext );
		[PreserveSig]
		HRESULT GetDestCtx(out MSHCTX pdwDestContext, [Optional] IntPtr ppvDestContext);

		/// <summary>Determines whether the RPC channel is connected.</summary>
		/// <returns>If the RPC channel exists, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcchannelbuffer-isconnected HRESULT IsConnected();
		[PreserveSig]
		HRESULT IsConnected();
	}

	/// <summary>
	/// Enables callers to set or query the values of various properties that control how COM handles remote procedure calls (RPC).
	/// </summary>
	/// <remarks>
	/// <para>
	/// Using this interface, callers can set or query the COMBND_RPCTIMEOUT property, which controls how long your machine will attempt
	/// to establish RPC communications with another before failing. The property can have any one of the values enumerated in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_C_BINDING_INFINITE_TIMEOUT</term>
	/// <term>Keep trying to establish communications with no timeout.</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_BINDING_MIN_TIMEOUT</term>
	/// <term>Try to establish communications for the minimum time required by the protocol. This value favors performance over reliability.</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_BINDING_DEFAULT_TIMEOUT</term>
	/// <term>Try to establish communications for the default time. The value strikes a balance between performance and reliability.</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_BINDING_MAX_TIMEOUT</term>
	/// <term>Try to establish communications for the maximum time allowed by the protocol. This value favors reliability over performance.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irpcoptions
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcOptions")]
	[ComImport, Guid("00000144-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRpcOptions
	{
		/// <summary>Sets the value of an RPC binding option property.</summary>
		/// <param name="pPrx">A pointer to the proxy whose property is being set.</param>
		/// <param name="dwProperty">An identifier of the property to be set, which must be COMBND_RPCTIMEOUT.</param>
		/// <param name="dwValue">The new value of the property.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>See IRpcOptions for a table of the possible values of the COMBND_RPCTIMEOUT property.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcoptions-set HRESULT Set( IUnknown *pPrx,
		// RPCOPT_PROPERTIES dwProperty, ULONG_PTR dwValue );
		[PreserveSig]
		HRESULT Set([In, MarshalAs(UnmanagedType.IUnknown)] object pPrx, RPCOPT_PROPERTIES dwProperty, [In] IntPtr dwValue);

		/// <summary>Retrieves the value of an RPC binding option property.</summary>
		/// <param name="pPrx">A pointer to the proxy whose property is being queried.</param>
		/// <param name="dwProperty">
		/// An identifier of the property to be queried, which must be COMBND_RPCTIMEOUT or COMBND_SERVER_LOCALITY (this flag is
		/// available starting with Windows Server 2003.)
		/// </param>
		/// <param name="pdwValue">A pointer to the property value.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// While the COMBND_RPCTIMEOUT property can also be set using the Set method, the COMBND_SERVER_LOCALITY property can only be queried.
		/// </para>
		/// <para>See IRpcOptions for a table of the possible values of the COMBND_RPCTIMEOUT property.</para>
		/// <para>
		/// The possible values of the COMBND_SERVER_LOCALITY property, which describes the degree of remoteness of the RPC connection,
		/// are enumerated in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SERVER_LOCALITY_PROCESS_LOCAL</term>
		/// <term>The counterpart is in the same process as the client.</term>
		/// </item>
		/// <item>
		/// <term>SERVER_LOCALITY_MACHINE_LOCAL</term>
		/// <term>The counterpart is on the same computer as the client but in a different process.</term>
		/// </item>
		/// <item>
		/// <term>SERVER_LOCALITY_REMOTE</term>
		/// <term>The counterpart is on a remote computer.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcoptions-query HRESULT Query( IUnknown *pPrx,
		// RPCOPT_PROPERTIES dwProperty, ULONG_PTR *pdwValue );
		[PreserveSig]
		HRESULT Query([In, MarshalAs(UnmanagedType.IUnknown)] object pPrx, [In] RPCOPT_PROPERTIES dwProperty, out IntPtr pdwValue);
	}

	/// <summary>Controls the RPC proxy used to marshal data between COM components.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irpcproxybuffer
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcProxyBuffer")]
	[ComImport, Guid("D5F56A34-593B-101A-B569-08002B2DBF7A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRpcProxyBuffer
	{
		/// <summary>Initializes a client proxy, binding it to the specified RPC channel.</summary>
		/// <param name="pRpcChannelBuffer">A pointer to the IRpcChannelBuffer interface that the proxy uses to marshal data.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcproxybuffer-connect HRESULT Connect(
		// IRpcChannelBuffer *pRpcChannelBuffer );
		[PreserveSig]
		HRESULT Connect([In] IRpcChannelBuffer pRpcChannelBuffer);

		/// <summary>Disconnects a client proxy from any RPC channel to which it is connected.</summary>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcproxybuffer-disconnect void Disconnect();
		[PreserveSig]
		void Disconnect();
	}

	/// <summary>Controls the RPC stub used to marshal data between COM components.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-irpcstubbuffer
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IRpcStubBuffer")]
	[ComImport, Guid("D5F56AFC-593B-101A-B569-08002B2DBF7A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRpcStubBuffer
	{
		/// <summary>Initializes a server stub, binding it to the specified interface.</summary>
		/// <param name="pUnkServer">A pointer to the interface.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-connect HRESULT Connect( IUnknown
		// *pUnkServer );
		[PreserveSig]
		HRESULT Connect([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkServer);

		/// <summary>Disconnects a server stub from any interface to which it is connected.</summary>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-disconnect void Disconnect();
		[PreserveSig]
		void Disconnect();

		/// <summary>Invokes the interface that a stub represents.</summary>
		/// <param name="_prpcmsg">A pointer to an RPCOLEMESSAGE data structure containing the marshaled invocation arguments.</param>
		/// <param name="_pRpcChannelBuffer">A pointer to an IRpcChannelBuffer interface that controls an RPC marshaling channel.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-irpcstubbuffer-invoke HRESULT Invoke(
		// RPCOLEMESSAGE *_prpcmsg, IRpcChannelBuffer *_pRpcChannelBuffer );
		[PreserveSig]
		HRESULT Invoke(ref RPCOLEMESSAGE _prpcmsg, [In] IRpcChannelBuffer _pRpcChannelBuffer);

		/// <summary>Determines whether a stub is designed to handle the unmarshaling of a particular interface.</summary>
		/// <param name="riid">The IID of the interface. This parameter cannot be IID_IUnknown.</param>
		/// <returns>
		/// If the stub can handle the indicated interface, then this method returns an IRpcStubBuffer pointer for that interface;
		/// otherwise, it returns <c>NULL</c>.
		/// </returns>
		/// <remarks>
		/// <para>
		/// When presented with the need to remote a new IID on a given object, the RPC run time typically calls this method on all the
		/// presently-connected interface stubs in an attempt to locate one that can handle the marshaling for the request before it
		/// goes to the trouble of creating a new stub.
		/// </para>
		/// <para>
		/// As in IPSFactoryBuffer::CreateStub, if a stub is presently connected to a server object, then not only must this method
		/// verify that the stub can handle the indicated interface, but it must also verify (using QueryInterface) that the connected
		/// server object in fact supports the indicated interface. Depending on the IID and previous interface servicing requests, it
		/// may have already done so.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-isiidsupported IRpcStubBuffer *
		// IsIIDSupported( REFIID riid );
		[PreserveSig]
		IRpcStubBuffer? IsIIDSupported(in Guid riid);

		/// <summary>Retrieves the total number of references that a stub has on the server object to which it is connected.</summary>
		/// <returns>This method returns the total number of references that a stub has on the server object to which it is connected.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-countrefs ULONG CountRefs();
		[PreserveSig]
		uint CountRefs();

		/// <summary>Retrieves a pointer to the interface that a stub represents.</summary>
		/// <param name="ppv">A pointer to the interface that the stub represents.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-debugserverqueryinterface HRESULT
		// DebugServerQueryInterface( void **ppv );
		[PreserveSig]
		HRESULT DebugServerQueryInterface(out IntPtr ppv);

		/// <summary>Releases an interface pointer that was previously returned by DebugServerQueryInterface.</summary>
		/// <param name="pv">A pointer to the interface that the caller no longer needs.</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-irpcstubbuffer-debugserverrelease void
		// DebugServerRelease( void *pv );
		[PreserveSig]
		void DebugServerRelease([In] IntPtr pv);
	}

	/// <summary>
	/// The <c>ISequentialStream</c> interface supports simplified sequential access to stream objects. The IStream interface inherits
	/// its Read and Write methods from <c>ISequentialStream</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-isequentialstream
	[PInvokeData("objidlbase.h", MSDNShortId = "c1d33800-d2f1-4942-92fa-e115f524c23c")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0c733a30-2a1c-11ce-ade5-00aa0044773d")]
	public interface ISequentialStream
	{
		/// <summary>
		/// The <c>Read</c> method reads a specified number of bytes from the stream object into memory, starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">A pointer to the buffer which the stream data is read into.</param>
		/// <param name="cb">The number of bytes of data to read from the stream object.</param>
		/// <param name="pcbRead">
		/// <para>A pointer to a <c>ULONG</c> variable that receives the actual number of bytes read from the stream object.</para>
		/// <para><c>Note</c> The number of bytes read may be zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method reads bytes from this stream object into memory. The stream object must be opened in <c>STGM_READ</c> mode. This
		/// method adjusts the seek pointer by the actual number of bytes read.
		/// </para>
		/// <para>The number of bytes actually read is also returned in the pcbRead parameter.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The actual number of bytes read can be less than the number of bytes requested if an error occurs or if the end of the
		/// stream is reached during the read operation. The number of bytes returned should always be compared to the number of bytes
		/// requested. If the number of bytes returned is less than the number of bytes requested, it usually means the <c>Read</c>
		/// method attempted to read past the end of the stream.
		/// </para>
		/// <para>The application should handle both a returned error and <c>S_OK</c> return values on end-of-stream read operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-read HRESULT Read( void *pv, ULONG
		// cb, ULONG *pcbRead );
		[PInvokeData("objidl.h", MSDNShortId = "934a90bb-5ed0-4d80-9906-352ad8586655")]
		[PreserveSig]
		HRESULT Read(byte[] pv, uint cb, out uint pcbRead);

		/// <summary>
		/// The <c>Write</c> method writes a specified number of bytes into the stream object starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">
		/// A pointer to the buffer that contains the data that is to be written to the stream. A valid pointer must be provided for
		/// this parameter even when cb is zero.
		/// </param>
		/// <param name="cb">The number of bytes of data to attempt to write into the stream. This value can be zero.</param>
		/// <param name="pcbWritten">
		/// A pointer to a <c>ULONG</c> variable where this method writes the actual number of bytes written to the stream object. The
		/// caller can set this pointer to <c>NULL</c>, in which case this method does not provide the actual number of bytes written.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ISequentialStream::Write</c> writes the specified data to a stream object. The seek pointer is adjusted for the number of
		/// bytes actually written. The number of bytes actually written is returned in the pcbWritten parameter. If the byte count is
		/// zero bytes, the write operation has no effect.
		/// </para>
		/// <para>
		/// If the seek pointer is currently past the end of the stream and the byte count is nonzero, this method increases the size of
		/// the stream to the seek pointer and writes the specified bytes starting at the seek pointer. The fill bytes written to the
		/// stream are not initialized to any particular value. This is the same as the end-of-file behavior in the MS-DOS FAT file system.
		/// </para>
		/// <para>
		/// With a zero byte count and a seek pointer past the end of the stream, this method does not create the fill bytes to increase
		/// the stream to the seek pointer. In this case, you must call the IStream::SetSize method to increase the size of the stream
		/// and write the fill bytes.
		/// </para>
		/// <para>The pcbWritten parameter can have a value even if an error occurs.</para>
		/// <para>
		/// In the COM-provided implementation, stream objects are not sparse. Any fill bytes are eventually allocated on the disk and
		/// assigned to the stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-write HRESULT Write( const void *pv,
		// ULONG cb, ULONG *pcbWritten );
		[PInvokeData("objidl.h", MSDNShortId = "f0323dda-6c31-4411-bf20-9650162109c0")]
		[PreserveSig]
		HRESULT Write(byte[] pv, uint cb, out uint pcbWritten);
	}

	/// <summary>Used by a server to help authenticate the client and to manage impersonation of the client.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iserversecurity
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IServerSecurity")]
	[ComImport, Guid("0000013E-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IServerSecurity
	{
		/// <summary>Retrieves information about the client that invoked one of the server's methods.</summary>
		/// <param name="pAuthnSvc">
		/// A pointer to the current authentication service. This will be a single value taken from the list of authentication service
		/// constants. If the caller specifies <c>NULL</c>, the current authentication service is not retrieved.
		/// </param>
		/// <param name="pAuthzSvc">
		/// A pointer to a variable that receives the current authorization service. This will be a single value from the list of
		/// authorization constants. If the caller specifies <c>NULL</c>, the current authorization service is not retrieved.
		/// </param>
		/// <param name="pServerPrincName">
		/// The current principal name. The string will be allocated by the callee using CoTaskMemAlloc, and must be freed by the caller
		/// using CoTaskMemFree. By default, Schannel principal names will be in the msstd form. The fullsic form will be returned if
		/// EOAC_MAKE_FULLSIC is specified in the pCapabilities parameter. For more information on the msstd and fullsic forms, see
		/// Principal Names. If the caller specifies <c>NULL</c>, the current principal name is not retrieved.
		/// </param>
		/// <param name="pAuthnLevel">
		/// A pointer to a variable that receives the current authentication level. This will be a single value taken from the list of
		/// authentication level constants. If the caller specifies <c>NULL</c>, the current authentication level is not retrieved.
		/// </param>
		/// <param name="pImpLevel">This parameter must be <c>NULL</c>.</param>
		/// <param name="pPrivs">
		/// The privilege information for the client application. The format of the structure that the handle refers to depends on the
		/// authentication service. The application should not write or free the memory. The information is only valid for the duration
		/// of the current call. For NTLMSSP, and Kerberos, this is a SEC_WINNT_AUTH_IDENTITY or SEC_WINNT_AUTH_IDENTITY_EX structure.
		/// For Schannel, this is a CERT_CONTEXT structure that represents the client's certificate. If the client has no certificate,
		/// <c>NULL</c> is returned. If the caller specifies <c>NULL</c>, the current privilege information is not retrieved.
		/// </param>
		/// <param name="pCapabilities">
		/// The capabilities of the call. To request that the principal name be returned in fullsic form if Schannel is the
		/// authentication service, the caller can set the EOAC_MAKE_FULLSIC flag in this parameter. If the caller specifies
		/// <c>NULL</c>, the current capabilities are not retrieved.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <c>QueryBlanket</c> is used by the server to find out about the client that invoked one of its methods. To get a pointer to
		/// IServerSecurity for the current call on the current thread, call CoGetCallContext, specifying IID_IServerSecurity. This
		/// interface pointer may only be used in the same apartment as the call for the duration of the call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iserversecurity-queryblanket HRESULT QueryBlanket( DWORD
		// *pAuthnSvc, DWORD *pAuthzSvc, OLECHAR **pServerPrincName, DWORD *pAuthnLevel, DWORD *pImpLevel, void **pPrivs, DWORD
		// *pCapabilities );
		[PreserveSig]
		HRESULT QueryBlanket(out RPC_C_AUTHN pAuthnSvc, out RPC_C_AUTHZ pAuthzSvc, [MarshalAs(UnmanagedType.LPWStr)] out string pServerPrincName,
			out RPC_C_AUTHN_LEVEL pAuthnLevel, out RPC_C_IMP_LEVEL pImpLevel, out IntPtr pPrivs, ref uint pCapabilities);

		/// <summary>Enables a server to impersonate a client for the duration of a call.</summary>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>
		/// Usually, a method executes on a thread that uses the access token of the process. However, when impersonating a client, the
		/// server runs in the client's security context so that the server has access to the resources that the client has access to.
		/// When impersonation is necessary, the server calls the <c>ImpersonateClient</c> method to cause an access token representing
		/// the client's credentials to be assigned to the current thread. This thread token is used for access checks. RevertToSelf
		/// restores the current thread's access token.
		/// </para>
		/// <para>
		/// What the server can do on behalf of the client depends on the impersonation level set by the client, which is specified
		/// using one of the impersonation level constants. The server may impersonate the client on an encrypted call at identify,
		/// impersonate, or delegate level. For information about these levels of impersonation, see Impersonation Levels.
		/// </para>
		/// <para>
		/// The identity presented to a server called during impersonation depends on the type of cloaking value, if any, that is set by
		/// the client. For more information, see Cloaking.
		/// </para>
		/// <para>At the end of each method call, COM will call RevertToSelf if the application does not.</para>
		/// <para>
		/// Traditionally, impersonation information is not nested â€“ the last call to any impersonation mechanism overrides any
		/// previous impersonation. However, in the apartment model, impersonation is maintained during nested calls. Thus if the server
		/// A receives a call from B, impersonates, calls C, receives a call from D, impersonates, reverts, and receives the reply from
		/// C, the impersonation token will be set back to B, not A.
		/// </para>
		/// <para>For information on using impersonation with asynchronous calls, see Impersonation and Asynchronous Calls.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iserversecurity-impersonateclient HRESULT ImpersonateClient();
		[PreserveSig]
		HRESULT ImpersonateClient();

		/// <summary>Restores the authentication information of a thread to what it was before impersonation began.</summary>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>
		/// <c>RevertToSelf</c> restores the authentication information on a thread to the authentication information on the thread
		/// before impersonation began. If the server does not call <c>RevertToSelf</c> before the end of the current call, it will be
		/// called automatically by COM.
		/// </para>
		/// <para>
		/// When ImpersonateClient is called on a thread that is not currently impersonating, COM saves the token currently on the
		/// thread. A subsequent call to <c>RevertToSelf</c> restores the saved token, and IsImpersonating will then return
		/// <c>FALSE</c>. This means that if a series of impersonation calls are made using different IServerSecurity objects,
		/// <c>RevertToSelf</c> will restore the token that was on the thread when the first call to <c>ImpersonateClient</c> was made.
		/// Also, only one <c>RevertToSelf</c> call is needed to undo any number of <c>ImpersonateClient</c> calls.
		/// </para>
		/// <para>
		/// This method will only revert impersonation changes made by ImpersonateClient. If the thread token is modified by other means
		/// (through the SetThreadToken or RpcImpersonateClient functions) the result of this function is undefined.
		/// </para>
		/// <para>
		/// <c>RevertToSelf</c> affects only the current method invocation. If there are nested method invocations, each invocation can
		/// have its own impersonation token and DCOM will correctly restore the impersonation token before returning to them
		/// (regardless of whether CoRevertToSelf or <c>RevertToSelf</c> was called).
		/// </para>
		/// <para>
		/// It is important to understand that an instance of IServerSecurity is valid on any thread in the apartment until the call
		/// represented by <c>IServerSecurity</c> completes. However, impersonation is local to a particular thread for the duration of
		/// the current call on that thread. Therefore, if two threads in the same apartment use the same <c>IServerSecurity</c>
		/// instance to call ImpersonateClient, one thread can call <c>RevertToSelf</c> without affecting the other.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iserversecurity-reverttoself HRESULT RevertToSelf();
		[PreserveSig]
		HRESULT RevertToSelf();

		/// <summary>Indicates whether the server is currently impersonating the client.</summary>
		/// <returns>If the thread is currently impersonating, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-iserversecurity-isimpersonating BOOL IsImpersonating();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsImpersonating();
	}

	/// <summary>Retrieves the CLSID identifying the handler to be used in the destination process during standard marshaling.</summary>
	/// <remarks>
	/// <para>
	/// An object that uses OLE's default implementation of IMarshal does not provide its own proxy but, by implementing
	/// <c>IStdMarshalInfo</c>, can nevertheless specify a handler to be loaded in the client process. Such a handler would typically
	/// handle certain requests in-process and use OLE's default marshaling to delegate others back to the original object.
	/// </para>
	/// <para>
	/// To create an instance of an object in some client process, COM must first determine whether the object uses default marshaling
	/// or its own implementation. If the object uses default marshaling, COM then queries the object to determine whether it uses a
	/// special handler or, simply, OLE's default proxy. To get the CLSID of the handler to be loaded, COM queries the object for
	/// <c>IStdMarshalInfo</c> and then the IPersist interface. If neither interface is supported, a standard handler is used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-istdmarshalinfo
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IStdMarshalInfo")]
	[ComImport, Guid("00000018-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStdMarshalInfo
	{
		/// <summary>Retrieves the CLSID of the object handler to be used in the destination process during standard marshaling.</summary>
		/// <param name="dwDestContext">
		/// The destination context, that is, the process in which the unmarshaling will be done. Possible values are taken from the
		/// enumeration MSHCTX.
		/// </param>
		/// <param name="pvDestContext">This parameter must be <c>NULL</c>.</param>
		/// <param name="pClsid">A pointer to the handler's CLSID.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Your implementation of <c>IStdMarshalInfo::GetClassForHandler</c> must return your own CLSID. This enables an object to be
		/// created by a different server.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istdmarshalinfo-getclassforhandler HRESULT
		// GetClassForHandler( DWORD dwDestContext, void *pvDestContext, CLSID *pClsid );
		[PreserveSig]
		HRESULT GetClassForHandler([In] MSHCTX dwDestContext, [In, Optional] IntPtr pvDestContext, out Guid pClsid);
	}

	/// <summary>
	/// <para>
	/// The <c>IStream</c> interface lets you read and write data to stream objects. Stream objects contain the data in a structured
	/// storage object, where storages provide the structure. Simple data can be written directly to a stream but, most frequently,
	/// streams are elements nested within a storage object. They are similar to standard files.
	/// </para>
	/// <para>
	/// The <c>IStream</c> interface defines methods similar to the MS-DOS FAT file functions. For example, each stream object has its
	/// own access rights and a seek pointer. The main difference between a DOS file and a stream object is that in the latter case,
	/// streams are opened using an <c>IStream</c> interface pointer rather than a file handle.
	/// </para>
	/// <para>
	/// The methods in this interface present your object's data as a contiguous sequence of bytes that you can read or write. There are
	/// also methods for committing and reverting changes on streams that are open in transacted mode and methods for restricting access
	/// to a range of bytes in the stream.
	/// </para>
	/// <para>
	/// Streams can remain open for long periods of time without consuming file-system resources. The IUnknown::Release method is
	/// similar to a close function on a file. Once released, the stream object is no longer valid and cannot be used.
	/// </para>
	/// <para>
	/// Clients of asynchronous monikers can choose between a data-pull or data-push model for driving an asynchronous
	/// IMoniker::BindToStorage operation and for receiving asynchronous notifications. See URL Monikers for more information. The
	/// following table compares the behavior of asynchronous ISequentialStream::Read and IStream::Seek calls returned in
	/// IBindStatusCallback::OnDataAvailable in these two download models:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>IStream method call</term>
	/// <term>Behavior in data-pull model</term>
	/// <term>Behavior in data-push model</term>
	/// </listheader>
	/// <item>
	/// <term>Read is called to read partial data (that is, not all the available data)</term>
	/// <term>
	/// Returns S_OK. The client must continue to read all available data before returning from IBindStatusCallback::OnDataAvailable or
	/// else the bind operation is blocked. (that is, read until S_FALSE or E_PENDING is returned)
	/// </term>
	/// <term>
	/// Returns S_OK. Even if the client returns from IBindStatusCallback::OnDataAvailable at this point the bind operation continues
	/// and IBindStatusCallback::OnDataAvailable will be called again repeatedly until the binding finishes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Read is called to read all the available data</term>
	/// <term>
	/// Returns E_PENDING if the bind operation has not completed, and IBindStatusCallback::OnDataAvailable will be called again when
	/// more data is available.
	/// </term>
	/// <term>Same as data-pull model.</term>
	/// </item>
	/// <item>
	/// <term>Read is called to read all the available data and the bind operation is over (end of file)</term>
	/// <term>Returns S_FALSE. There will be a subsequent call to IBindStatusCallback::OnDataAvailable with the grfBSC flag set to BSCF_LASTDATANOTIFICATION.</term>
	/// <term>Same as data-pull model.</term>
	/// </item>
	/// <item>
	/// <term>Seek is called</term>
	/// <term>Seek does not work in data-pull model</term>
	/// <term>Seek does not work in data-push model.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For general information on this topic, see Asynchronous Monikers and Data-Pull-Model versus Data Push-Model for more specific
	/// information. Also, see Managing Memory Allocation for details on COM's rules for managing memory.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-istream
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.IStream")]
	[ComImport, Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IStreamV : ISequentialStream
	{
		/// <summary>
		/// The <c>Read</c> method reads a specified number of bytes from the stream object into memory, starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">A pointer to the buffer which the stream data is read into.</param>
		/// <param name="cb">The number of bytes of data to read from the stream object.</param>
		/// <param name="pcbRead">
		/// <para>A pointer to a <c>ULONG</c> variable that receives the actual number of bytes read from the stream object.</para>
		/// <para><c>Note</c> The number of bytes read may be zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method reads bytes from this stream object into memory. The stream object must be opened in <c>STGM_READ</c> mode. This
		/// method adjusts the seek pointer by the actual number of bytes read.
		/// </para>
		/// <para>The number of bytes actually read is also returned in the pcbRead parameter.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The actual number of bytes read can be less than the number of bytes requested if an error occurs or if the end of the
		/// stream is reached during the read operation. The number of bytes returned should always be compared to the number of bytes
		/// requested. If the number of bytes returned is less than the number of bytes requested, it usually means the <c>Read</c>
		/// method attempted to read past the end of the stream.
		/// </para>
		/// <para>The application should handle both a returned error and <c>S_OK</c> return values on end-of-stream read operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-read HRESULT Read( void *pv, ULONG
		// cb, ULONG *pcbRead );
		[PInvokeData("objidl.h", MSDNShortId = "934a90bb-5ed0-4d80-9906-352ad8586655")]
		[PreserveSig]
		new HRESULT Read(byte[] pv, uint cb, out uint pcbRead);

		/// <summary>
		/// The <c>Write</c> method writes a specified number of bytes into the stream object starting at the current seek pointer.
		/// </summary>
		/// <param name="pv">
		/// A pointer to the buffer that contains the data that is to be written to the stream. A valid pointer must be provided for
		/// this parameter even when cb is zero.
		/// </param>
		/// <param name="cb">The number of bytes of data to attempt to write into the stream. This value can be zero.</param>
		/// <param name="pcbWritten">
		/// A pointer to a <c>ULONG</c> variable where this method writes the actual number of bytes written to the stream object. The
		/// caller can set this pointer to <c>NULL</c>, in which case this method does not provide the actual number of bytes written.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>ISequentialStream::Write</c> writes the specified data to a stream object. The seek pointer is adjusted for the number of
		/// bytes actually written. The number of bytes actually written is returned in the pcbWritten parameter. If the byte count is
		/// zero bytes, the write operation has no effect.
		/// </para>
		/// <para>
		/// If the seek pointer is currently past the end of the stream and the byte count is nonzero, this method increases the size of
		/// the stream to the seek pointer and writes the specified bytes starting at the seek pointer. The fill bytes written to the
		/// stream are not initialized to any particular value. This is the same as the end-of-file behavior in the MS-DOS FAT file system.
		/// </para>
		/// <para>
		/// With a zero byte count and a seek pointer past the end of the stream, this method does not create the fill bytes to increase
		/// the stream to the seek pointer. In this case, you must call the IStream::SetSize method to increase the size of the stream
		/// and write the fill bytes.
		/// </para>
		/// <para>The pcbWritten parameter can have a value even if an error occurs.</para>
		/// <para>
		/// In the COM-provided implementation, stream objects are not sparse. Any fill bytes are eventually allocated on the disk and
		/// assigned to the stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isequentialstream-write HRESULT Write( const void *pv,
		// ULONG cb, ULONG *pcbWritten );
		[PInvokeData("objidl.h", MSDNShortId = "f0323dda-6c31-4411-bf20-9650162109c0")]
		[PreserveSig]
		new HRESULT Write(byte[] pv, uint cb, out uint pcbWritten);

		/// <summary>
		/// The <c>Seek</c> method changes the seek pointer to a new location. The new location is relative to either the beginning of
		/// the stream, the end of the stream, or the current seek pointer.
		/// </summary>
		/// <param name="dlibMove">
		/// The displacement to be added to the location indicated by the dwOrigin parameter. If dwOrigin is <c>STREAM_SEEK_SET</c>,
		/// this is interpreted as an unsigned value rather than a signed value.
		/// </param>
		/// <param name="dwOrigin">
		/// The origin for the displacement specified in dlibMove. The origin can be the beginning of the file (
		/// <c>STREAM_SEEK_SET</c>), the current seek pointer ( <c>STREAM_SEEK_CUR</c>), or the end of the file (
		/// <c>STREAM_SEEK_END</c>). For more information about values, see the STREAM_SEEK enumeration.
		/// </param>
		/// <param name="plibNewPosition">
		/// <para>A pointer to the location where this method writes the value of the new seek pointer from the beginning of the stream.</para>
		/// <para>You can set this pointer to <c>NULL</c>. In this case, this method does not provide the new seek pointer.</para>
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// <c>IStream::Seek</c> changes the seek pointer so that subsequent read and write operations can be performed at a different
		/// location in the stream object. It is an error to seek before the beginning of the stream. It is not, however, an error to
		/// seek past the end of the stream. Seeking past the end of the stream is useful for subsequent write operations, as the stream
		/// byte range will be extended to the new seek position immediately before the write is complete.
		/// </para>
		/// <para>
		/// You can also use this method to obtain the current value of the seek pointer by calling this method with the dwOrigin
		/// parameter set to <c>STREAM_SEEK_CUR</c> and the dlibMove parameter set to 0 so that the seek pointer is not changed. The
		/// current seek pointer is returned in the plibNewPosition parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-seek HRESULT Seek( LARGE_INTEGER dlibMove, DWORD
		// dwOrigin, ULARGE_INTEGER *plibNewPosition );
		[PreserveSig]
		HRESULT Seek(long dlibMove, STREAM_SEEK dwOrigin, out ulong plibNewPosition);

		/// <summary>The <c>SetSize</c> method changes the size of the stream object.</summary>
		/// <param name="libNewSize">Specifies the new size, in bytes, of the stream.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// <c>IStream::SetSize</c> changes the size of the stream object. Call this method to preallocate space for the stream. If the
		/// libNewSize parameter is larger than the current stream size, the stream is extended to the indicated size by filling the
		/// intervening space with bytes of undefined value. This operation is similar to the ISequentialStream::Write method if the
		/// seek pointer is past the current end of the stream.
		/// </para>
		/// <para>If the libNewSize parameter is smaller than the current stream, the stream is truncated to the indicated size.</para>
		/// <para>The seek pointer is not affected by the change in stream size.</para>
		/// <para>Calling <c>IStream::SetSize</c> can be an effective way to obtain a large chunk of contiguous space.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-setsize HRESULT SetSize( ULARGE_INTEGER
		// libNewSize );
		[PreserveSig]
		HRESULT SetSize(long libNewSize);

		/// <summary>
		/// The <c>CopyTo</c> method copies a specified number of bytes from the current seek pointer in the stream to the current seek
		/// pointer in another stream.
		/// </summary>
		/// <param name="pstm">
		/// A pointer to the destination stream. The stream pointed to by pstm can be a new stream or a clone of the source stream.
		/// </param>
		/// <param name="cb">The number of bytes to copy from the source stream.</param>
		/// <param name="pcbRead">
		/// A pointer to the location where this method writes the actual number of bytes read from the source. You can set this pointer
		/// to <c>NULL</c>. In this case, this method does not provide the actual number of bytes read.
		/// </param>
		/// <param name="pcbWritten">
		/// A pointer to the location where this method writes the actual number of bytes written to the destination. You can set this
		/// pointer to <c>NULL</c>. In this case, this method does not provide the actual number of bytes written.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>CopyTo</c> method copies the specified bytes from one stream to another. It can also be used to copy a stream to
		/// itself. The seek pointer in each stream instance is adjusted for the number of bytes read or written. This method is
		/// equivalent to reading cb bytes into memory using ISequentialStream::Read and then immediately writing them to the
		/// destination stream using ISequentialStream::Write, although <c>IStream::CopyTo</c> will be more efficient.
		/// </para>
		/// <para>The destination stream can be a clone of the source stream created by calling the IStream::Clone method.</para>
		/// <para>
		/// If <c>IStream::CopyTo</c> returns an error, you cannot assume that the seek pointers are valid for either the source or
		/// destination. Additionally, the values of pcbRead and pcbWritten are not meaningful even though they are returned.
		/// </para>
		/// <para>If <c>IStream::CopyTo</c> returns successfully, the actual number of bytes read and written are the same.</para>
		/// <para>
		/// To copy the remainder of the source from the current seek pointer, specify the maximum large integer value for the cb
		/// parameter. If the seek pointer is the beginning of the stream, this operation copies the entire stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-copyto HRESULT CopyTo( IStream *pstm,
		// ULARGE_INTEGER cb, ULARGE_INTEGER *pcbRead, ULARGE_INTEGER *pcbWritten );
		[PreserveSig]
		HRESULT CopyTo(IStream pstm, long cb, out ulong pcbRead, out ulong pcbWritten);

		/// <summary>
		/// The <c>Commit</c> method ensures that any changes made to a stream object open in transacted mode are reflected in the
		/// parent storage. If the stream object is open in direct mode, <c>IStream::Commit</c> has no effect other than flushing all
		/// memory buffers to the next-level storage object. The COM compound file implementation of streams does not support opening
		/// streams in transacted mode.
		/// </summary>
		/// <param name="grfCommitFlags">
		/// Controls how the changes for the stream object are committed. See the STGC enumeration for a definition of these values.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>Commit</c> method ensures that changes to a stream object opened in transacted mode are reflected in the parent
		/// storage. Changes that have been made to the stream since it was opened or last committed are reflected to the parent storage
		/// object. If the parent is opened in transacted mode, the parent may revert at a later time, rolling back the changes to this
		/// stream object. The compound file implementation does not support the opening of streams in transacted mode, so this method
		/// has very little effect other than to flush memory buffers. For more information, see IStream - Compound File Implementation.
		/// </para>
		/// <para>
		/// If the stream is open in direct mode, this method ensures that any memory buffers have been flushed out to the underlying
		/// storage object. This is much like a flush in traditional file systems.
		/// </para>
		/// <para>
		/// The <c>IStream::Commit</c> method is useful on a direct mode stream when the implementation of the IStream interface is a
		/// wrapper for underlying file system APIs. In this case, <c>IStream::Commit</c> would be connected to the file system's flush call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-commit HRESULT Commit( DWORD grfCommitFlags );
		[PreserveSig]
		HRESULT Commit(STGC grfCommitFlags);

		/// <summary>
		/// The <c>Revert</c> method discards all changes that have been made to a transacted stream since the last IStream::Commit
		/// call. On streams open in direct mode and streams using the COM compound file implementation of <c>IStream::Revert</c>, this
		/// method has no effect.
		/// </summary>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>The <c>Revert</c> method discards changes made to a transacted stream since the last commit operation.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-revert HRESULT Revert();
		[PreserveSig]
		HRESULT Revert();

		/// <summary>
		/// The <c>LockRegion</c> method restricts access to a specified range of bytes in the stream. Supporting this functionality is
		/// optional since some file systems do not provide it.
		/// </summary>
		/// <param name="libOffset">Integer that specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Integer that specifies the length of the range, in bytes, to be restricted.</param>
		/// <param name="dwLockType">Specifies the restrictions being requested on accessing the range.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The byte range of the stream can be extended. Locking an extended range for the stream is useful as a method of
		/// communication between different instances of the stream without changing data that is actually part of the stream.
		/// </para>
		/// <para>
		/// Three types of locking can be supported: locking to exclude other writers, locking to exclude other readers or writers, and
		/// locking that allows only one requester to obtain a lock on the given range, which is usually an alias for one of the other
		/// two lock types. A given stream instance might support either of the first two types, or both. The lock type is specified by
		/// dwLockType, using a value from the LOCKTYPE enumeration.
		/// </para>
		/// <para>
		/// Any region locked with <c>IStream::LockRegion</c> must later be explicitly unlocked by calling IStream::UnlockRegion with
		/// exactly the same values for the libOffset, cb, and dwLockType parameters. The region must be unlocked before the stream is
		/// released. Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Since the type of locking supported is optional and can vary in different implementations of IStream, you must provide code
		/// to deal with the STG_E_INVALIDFUNCTION error.
		/// </para>
		/// <para>
		/// The <c>LockRegion</c> method has no effect in the compound file implementation, because the implementation does not support
		/// range locking.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Support for this method is optional for implementations of stream objects since it may not be supported by the underlying
		/// file system. The type of locking supported is also optional. The STG_E_INVALIDFUNCTION error is returned if the requested
		/// type of locking is not supported.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-lockregion HRESULT LockRegion( ULARGE_INTEGER
		// libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PreserveSig]
		HRESULT LockRegion(long libOffset, long cb, LOCKTYPE dwLockType);

		/// <summary>
		/// The <c>UnlockRegion</c> method removes the access restriction on a range of bytes previously restricted with IStream::LockRegion.
		/// </summary>
		/// <param name="libOffset">Specifies the byte offset for the beginning of the range.</param>
		/// <param name="cb">Specifies, in bytes, the length of the range to be restricted.</param>
		/// <param name="dwLockType">Specifies the access restrictions previously placed on the range.</param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <c>IStream::UnlockRegion</c> unlocks a region previously locked with the IStream::LockRegion method. Locked regions must
		/// later be explicitly unlocked by calling <c>IStream::UnlockRegion</c> with exactly the same values for the libOffset, cb, and
		/// dwLockType parameters. The region must be unlocked before the stream is released. Two adjacent regions cannot be locked
		/// separately and then unlocked with a single unlock call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-unlockregion HRESULT UnlockRegion( ULARGE_INTEGER
		// libOffset, ULARGE_INTEGER cb, DWORD dwLockType );
		[PreserveSig]
		HRESULT UnlockRegion(long libOffset, long cb, LOCKTYPE dwLockType);

		/// <summary>The <c>Stat</c> method retrieves the STATSTG structure for this stream.</summary>
		/// <param name="pstatstg">Pointer to a STATSTG structure where this method places information about this stream object.</param>
		/// <param name="grfStatFlag">
		/// Specifies that this method does not return some of the members in the STATSTG structure, thus saving a memory allocation
		/// operation. Values are taken from the STATFLAG enumeration.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <c>IStream::Stat</c> retrieves a pointer to the STATSTG structure that contains information about this open stream. When
		/// this stream is within a structured storage and IStorage::EnumElements is called, it creates an enumerator object with the
		/// IEnumSTATSTG interface on it, which can be called to enumerate the storages and streams through the <c>STATSTG</c>
		/// structures associated with each of them.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-stat HRESULT Stat( STATSTG *pstatstg, DWORD
		// grfStatFlag );
		[PreserveSig]
		HRESULT Stat(out STATSTG pstatstg, STATFLAG grfStatFlag);

		/// <summary>
		/// The <c>Clone</c> method creates a new stream object with its own seek pointer that references the same bytes as the original stream.
		/// </summary>
		/// <param name="ppstm">
		/// When successful, pointer to the location of an IStream pointer to the new stream object. If an error occurs, this parameter
		/// is <c>NULL</c>.
		/// </param>
		/// <returns>This method can return one of these values.</returns>
		/// <remarks>
		/// <para>
		/// The <c>Clone</c> method creates a new stream object for accessing the same bytes but using a separate seek pointer. The new
		/// stream object sees the same data as the source-stream object. Changes written to one object are immediately visible in the
		/// other. Range locking is shared between the stream objects.
		/// </para>
		/// <para>
		/// The initial setting of the seek pointer in the cloned stream instance is the same as the current setting of the seek pointer
		/// in the original stream at the time of the clone operation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-istream-clone HRESULT Clone( IStream **ppstm );
		[PreserveSig]
		HRESULT Clone(out IStream? ppstm);
	}

	/// <summary>
	/// Used to dynamically load new DLL servers into an existing surrogate and free the surrogate when it is no longer needed.
	/// </summary>
	/// <remarks>
	/// A surrogate is an EXE process into which a DLL server can be loaded to give the DLL server the advantages of an EXE server
	/// without the coding overhead. It can also allow independent DLL servers to be located together within a single process, reducing
	/// the total number of processes needed. DLL servers are easy to write using standard development tools, like Microsoft Visual
	/// Studio, and running them in a surrogate process provides the benefits of an executable implementation, including fault
	/// isolation, the ability to serve multiple clients simultaneously, and allowing the server to provide services to remote clients
	/// in a distributed environment.
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
		/// This class factory's implementation of IClassFactory::CreateInstance will create an instance of the requested CLSID method
		/// by calling CoGetClassObject to get the class factory which creates an actual object for the given CLSID.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isurrogate-loaddllserver HRESULT LoadDllServer(
		// REFCLSID Clsid );
		void LoadDllServer(in Guid Clsid);

		/// <summary>Unloads a DLL server.</summary>
		/// <remarks>
		/// <para>
		/// COM calls <c>FreeSurrogate</c> when there are no more DLL servers running in the surrogate process. When
		/// <c>FreeSurrogate</c> is called, the method must properly revoke all of the class factories registered in the surrogate, and
		/// then cause the surrogate process to exit.
		/// </para>
		/// <para>
		/// Surrogate processes must call the CoFreeUnusedLibraries function periodically to unload DLL servers that are no longer in
		/// use. The surrogate process assumes this responsibility, which would normally be the client's responsibility.
		/// <c>CoFreeUnusedLibraries</c> calls the DllCanUnloadNow function on any loaded DLL servers. Because
		/// <c>CoFreeUnusedLibraries</c> depends on the existence and proper implementation of <c>DllCanUnloadNow</c> in DLL servers, it
		/// is not guaranteed to unload all DLL servers that should be unloaded --not every server implements <c>DllCanUnloadNow</c>,
		/// and this function is unreliable for free-threaded DLLs. Additionally, the surrogate has no way of being informed when all
		/// DLL servers are gone. COM, however, can determine when all DLL servers have been unloaded, and will then call the
		/// <c>FreeSurrogate</c> method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-isurrogate-freesurrogate HRESULT FreeSurrogate( );
		void FreeSurrogate();
	}

	/// <summary>
	/// Provides asynchronous communication between objects about the occurrence of an event. Objects that implement <c>ISynchronize</c>
	/// can receive indications that an event has occurred, and they can respond to queries about the event. In this way, clients can
	/// make sure that one request has been processed before they submit a subsequent request that depends on completion of the first one.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-isynchronize
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ISynchronize")]
	[ComImport, Guid("00000030-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISynchronize
	{
		/// <summary>
		/// Waits for the synchronization object to be signaled or for a specified timeout period to elapse, whichever comes first.
		/// </summary>
		/// <param name="dwFlags">The wait options. Possible values are taken from the COWAIT_FLAGS enumeration.</param>
		/// <param name="dwMilliseconds">
		/// The time this call will wait before returning, in milliseconds. If this parameter is INFINITE, the caller will wait until
		/// the synchronization object is signaled, no matter how long it takes. If this parameter is 0, the method returns immediately.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_FAIL, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The synchronization object was signaled.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_CALLPENDING</term>
		/// <term>The time-out period elapsed before the synchronization object was signaled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the caller is waiting in a single-thread apartment, <c>Wait</c> enters the COM modal loop. If the caller is waiting in a
		/// multithread apartment, the caller is blocked until <c>Wait</c> returns.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isynchronize-wait HRESULT Wait( DWORD dwFlags, DWORD
		// dwMilliseconds );
		[PreserveSig]
		HRESULT Wait(COWAIT_FLAGS dwFlags, uint dwMilliseconds);

		/// <summary>Sets the synchronization object to the signaled state and causes pending wait operations to return S_OK.</summary>
		/// <returns>This method returns S_OK to indicate that the method completed successfully.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-isynchronize-signal HRESULT Signal();
		[PreserveSig]
		HRESULT Signal();

		/// <summary>Sets the synchronization object to the nonsignaled state.</summary>
		/// <returns>This method returns S_OK to indicate that the method completed successfully.</returns>
		/// <remarks>
		/// <para>
		/// The ISynchronize::Wait method implemented on a standard event object (CLSID_StdEvent) automatically calls <c>Reset</c> when
		/// the synchronization object has been signaled.
		/// </para>
		/// <para>
		/// The implementation of ISynchronize::Wait on the manual reset event object (CLSID_ManualResetEvent) does not automatically
		/// call <c>Reset</c>. A server object usually calls <c>Reset</c> from a method that clients call after they detect that the
		/// synchronization object was signaled.
		/// </para>
		/// <para>
		/// In general, it is the server's responsibility to call <c>Reset</c>. If, however, the client needs to begin with the
		/// synchronization object in an unsignaled state, the client should call <c>Reset</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-isynchronize-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();
	}

	/// <summary>Manages a group of unsignaled synchronization objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nn-objidlbase-isynchronizecontainer
	[PInvokeData("objidlbase.h", MSDNShortId = "NN:objidlbase.ISynchronizeContainer")]
	[ComImport, Guid("00000033-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISynchronizeContainer
	{
		/// <summary>Adds a synchronization object to the container.</summary>
		/// <param name="pSync">A pointer to the synchronization object to be added to the container. See ISynchronize.</param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_FAIL, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_OUT_OF_RESOURCES</term>
		/// <term>The synchronization object container is full.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>A synchronization container can hold pointers to as many as 63 synchronization objects.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isynchronizecontainer-addsynchronize HRESULT
		// AddSynchronize( ISynchronize *pSync );
		[PreserveSig]
		HRESULT AddSynchronize([In] ISynchronize pSync);

		/// <summary>
		/// Waits for any synchronization object in the container to be signaled or for a specified timeout period to elapse, whichever
		/// comes first.
		/// </summary>
		/// <param name="dwFlags">
		/// The wait options. Possible values are taken from the COWAIT_FLAGS enumeration. COWAIT_WAITALL is not a valid setting for
		/// this method.
		/// </param>
		/// <param name="dwTimeOut">
		/// The time this call will wait before returning, in milliseconds. If this parameter is INFINITE, the caller will wait until a
		/// synchronization object is signaled, no matter how long it takes. If this parameter is 0, the method returns immediately.
		/// </param>
		/// <param name="ppSync">
		/// A pointer to an ISynchronize interface pointer on the synchronization object that was signaled. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_FAIL, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The synchronization object was signaled.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_TIMEOUT</term>
		/// <term>The time-out period elapsed before the synchronization object was signaled.</term>
		/// </item>
		/// <item>
		/// <term>RPC_E_NO_SYNC</term>
		/// <term>There are no synchronization objects in the container.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the caller is waiting in a single-thread apartment, <c>WaitMultiple</c> enters the COM modal loop. If the caller is
		/// waiting in a multithread apartment, the caller is blocked until <c>WaitMultiple</c> returns.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-isynchronizecontainer-waitmultiple HRESULT WaitMultiple(
		// DWORD dwFlags, DWORD dwTimeOut, ISynchronize **ppSync );
		[PreserveSig]
		HRESULT WaitMultiple([In] COWAIT_FLAGS dwFlags, [In] uint dwTimeOut, out ISynchronize ppSync);
	}

	/// <summary>
	/// <para>Assigns an event handle to a synchronization object.</para>
	/// <para>
	/// The synchronization object can use a handle to manage its activities. For example, the wait functions use handles to identify
	/// the event they control. Thus, the logic of the ISynchronize::Signal method on an event synchronization object can pass its
	/// handle to the SetEvent function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nn-objidlbase-isynchronizeevent
	[PInvokeData("objidlbase.h", MSDNShortId = "NN:objidlbase.ISynchronizeEvent")]
	[ComImport, Guid("00000032-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISynchronizeEvent : ISynchronizeHandle
	{
		/// <summary>Assigns an event handle to a synchronization object.</summary>
		/// <param name="ph">A pointer to the event handle.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-isynchronizeevent-seteventhandle HRESULT
		// SetEventHandle( HANDLE *ph );
		[PreserveSig]
		HRESULT SetEventHandle(in HANDLE ph);
	}

	/// <summary>Retrieves a handle associated with a synchronization object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-isynchronizehandle
	[PInvokeData("objidl.h", MSDNShortId = "NN:objidl.ISynchronizeHandle")]
	[ComImport, Guid("00000031-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISynchronizeHandle
	{
		/// <summary>Retrieves a handle to the synchronization object.</summary>
		/// <param name="ph">A pointer to the variable that receives a handle to the synchronization object.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/nf-objidlbase-isynchronizehandle-gethandle HRESULT GetHandle(
		// HANDLE *ph );
		[PreserveSig]
		HRESULT GetHandle(out HANDLE ph);
	}

	/// <summary>Represents an interface in a query for multiple interfaces.</summary>
	/// <remarks>
	/// To optimize network performance, most remote activation functions take an array of <c>MULTI_QI</c> structures rather than just a
	/// single IID as input and a single pointer to the requested interface on the object as output, as do local activation functions.
	/// This allows a set of pointers to interfaces to be returned from the same object in a single round-trip to the server. In network
	/// scenarios, requesting multiple interfaces at the time of object construction can save considerable time over using a number of
	/// calls to QueryInterface for unique interfaces, each of which would require a round-trip to the server.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidl/ns-objidl-multi_qi typedef struct tagMULTI_QI { const IID *pIID;
	// IUnknown *pItf; HRESULT hr; } MULTI_QI;
	[PInvokeData("objidl.h", MSDNShortId = "NS:objidl.tagMULTI_QI")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MULTI_QI
	{
		/// <summary>A pointer to an interface identifier.</summary>
		public GuidPtr pIID;

		/// <summary>A pointer to the interface requested in <c>pIID</c>. This member must be <c>NULL</c> on input.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public object? pItf;

		/// <summary>
		/// The return value of the QueryInterface call to locate the requested interface. Common return values include S_OK and
		/// E_NOINTERFACE. This member must be 0 on input.
		/// </summary>
		public HRESULT hr;
	}

	/// <summary>Contains marshaling invocation arguments and return values between COM components.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/objidlbase/ns-objidlbase-rpcolemessage typedef struct tagRPCOLEMESSAGE { void
	// *reserved1; RPCOLEDATAREP dataRepresentation; void *Buffer; ULONG cbBuffer; ULONG iMethod; void *reserved2[5]; ULONG rpcFlags; } RPCOLEMESSAGE;
	[PInvokeData("objidlbase.h", MSDNShortId = "NS:objidlbase.tagRPCOLEMESSAGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RPCOLEMESSAGE
	{
		/// <summary>This member is reserved.</summary>
		public IntPtr reserved1;

		/// <summary>The data representation with which the data was marshaled.</summary>
		public uint dataRepresentation;

		/// <summary>A buffer for marshaled data.</summary>
		public IntPtr Buffer;

		/// <summary>The size of the buffer, in bytes.</summary>
		public uint cbBuffer;

		/// <summary>The number of the method to be invoked.</summary>
		public uint iMethod;

		/// <summary>This member is reserved.</summary>
		public IntPtr reserved2_1;

		/// <summary>This member is reserved.</summary>
		public IntPtr reserved2_2;

		/// <summary>This member is reserved.</summary>
		public IntPtr reserved2_3;

		/// <summary>This member is reserved.</summary>
		public IntPtr reserved2_4;

		/// <summary>This member is reserved.</summary>
		public IntPtr reserved2_5;

		/// <summary>Status flags for the RPC connection.</summary>
		public uint rpcFlags;
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
	public class SOLE_AUTHENTICATION_LIST : IArrayStruct<SOLE_AUTHENTICATION_INFO>
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
		public string? pPrincipalName;

		/// <summary>
		/// When used in CoInitializeSecurity, set on return to indicate the status of the call to register the authentication services.
		/// </summary>
		public HRESULT hr;
	}

	/// <summary>Unmanaged memory methods for IMalloc.</summary>
	/// <seealso cref="IMemoryMethods"/>
	public sealed class IMallocMemoryMethods : MemoryMethodsBase
	{
		[ThreadStatic]
		internal static Lazy<IMalloc> malloc = new(() => GetMalloc());

		/// <summary>Gets a static instance of this class.</summary>
		/// <value>The instance.</value>
		public static IMemoryMethods Instance { get; } = new IMallocMemoryMethods();

		/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public override IntPtr AllocMem(int size) => (malloc?.Value ?? GetMalloc()).Alloc(size);

		/// <summary>Frees the memory associated with a handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		public override void FreeMem(IntPtr hMem) => (malloc?.Value ?? GetMalloc()).Free(hMem);

		/// <summary>Retrieves the size of a previously allocated block of memory.</summary>
		/// <param name="hMem">A pointer to the block of memory.</param>
		/// <returns>The size of the allocated memory block in bytes or, if <paramref name="hMem"/> is a NULL pointer, -1.</returns>
		public SizeT GetSize(IntPtr hMem) => (malloc?.Value ?? GetMalloc()).GetSize(hMem);

		/// <summary>Gets the reallocation method.</summary>
		/// <param name="hMem">A memory handle.</param>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public override IntPtr ReAllocMem(IntPtr hMem, int size) => (malloc?.Value ?? GetMalloc()).Realloc(hMem, size);

		private static IMalloc GetMalloc(uint dwMemContext = 1) { CoGetMalloc(dwMemContext, out var m).ThrowIfFailed(); return m; }
	}

	/// <summary>Safe handle to IMalloc memory.</summary>
	public class SafeIMallocHandle : SafeMemoryHandleExt<IMallocMemoryMethods>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeIMallocHandle(SizeT size = default) : base(size) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		public SafeIMallocHandle(IntPtr handle, SizeT size = default, bool ownsHandle = true) : base(handle, size <= 0 ? mm.GetSize(handle) : size, ownsHandle) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeIMallocHandle(byte[] bytes) : base(bytes) { }

		/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>SafeMemoryHandleExt object to an native (unmanaged) string</returns>
		public SafeIMallocHandle(string s, CharSet charSet = CharSet.Unicode) : base(s, charSet) { }

		/// <summary>Initializes a new instance of the <see cref="SafeIMallocHandle"/> class.</summary>
		[ExcludeFromCodeCoverage]
		internal SafeIMallocHandle() : base(0) { }

		/// <summary>Represents a NULL memory pointer.</summary>
		public static SafeIMallocHandle Null => new(IntPtr.Zero, 0, false);

		/// <inheritdoc/>
		public override SizeT Size { get => sz = mm.GetSize(handle); set => base.Size = value; }

		/// <summary>
		/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
		/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY
		/// structures with attribute StructLayout of LayoutKind.Sequential are supported.
		/// </summary>
		/// <typeparam name="T">Type of the trailing array of structures</typeparam>
		/// <param name="values">Collection of structure objects</param>
		/// <param name="count">
		/// Number of items in <paramref name="values"/>. Setting this value to -1 will cause the method to get the count by iterating
		/// through <paramref name="values"/>.
		/// </param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
		/// <returns><see cref="SafeIMallocHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
		public static SafeIMallocHandle CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) =>
			new(InteropExtensions.MarshalToPtr(count < 0 ? values : values.Take(count), mm.AllocMem, out int s, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// <see cref="SafeIMallocHandle"/> object to an native (unmanaged) array of strings stored using the <paramref name="packing"/>
		/// model and the character set defined by <paramref name="charSet"/>.
		/// </returns>
		public static SafeIMallocHandle CreateFromStringList(IEnumerable<string?> values, StringListPackMethod packing = StringListPackMethod.Concatenated,
			CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out int s, charSet, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
		/// <typeparam name="T">Native type</typeparam>
		/// <param name="value">The value.</param>
		/// <returns><see cref="SafeIMallocHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
		public static SafeIMallocHandle CreateFromStructure<T>(in T? value = default) => new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out int s), s);

		/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeIMallocHandle"/> where it owns the reference.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeIMallocHandle(IntPtr ptr) => new(ptr, 0, true);
	}
}