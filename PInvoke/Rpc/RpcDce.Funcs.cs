namespace Vanara.PInvoke;

/// <summary>Items from the Rpc.dll</summary>
public static partial class Rpc
{
	/// <summary>Passes back the principal name in fullsic format.</summary>
	public const uint RPC_C_FULL_CERT_CHAIN = 0x0001;

	/// <summary>The RPC QOS version.</summary>
	public const uint RPC_C_SECURITY_QOS_VERSION = 1;

	/// <summary>
	/// The RPC_AUTH_KEY_RETRIEVAL_FN function is a prototype for a function that specifies the address of a server-application-provided
	/// routine returning encryption keys.
	/// </summary>
	/// <param name="Arg"/>
	/// <param name="ServerPrincName">
	/// Pointer to the principal name to use for the server when authenticating remote procedure calls. The RPC run-time library uses
	/// the ServerPrincName parameter supplied to RpcServerRegisterAuthInfo.
	/// </param>
	/// <param name="KeyVer">
	/// Value that the RPC run-time library automatically provides for the key-version parameter. When the value is zero, the
	/// acquisition function must return the most recent key available.
	/// </param>
	/// <param name="Key">Pointer to a pointer to the authentication key returned by the user-supplied function.</param>
	/// <param name="Status"/>
	/// <returns>None</returns>
	/// <remarks>
	/// An authorization key–retrieval function specifies the address of a server-application-provided routine returning encryption keys.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nc-rpcdce-rpc_auth_key_retrieval_fn RPC_AUTH_KEY_RETRIEVAL_FN
	// RpcAuthKeyRetrievalFn; void RpcAuthKeyRetrievalFn( void *Arg, RPC_WSTR ServerPrincName, unsigned long KeyVer, void **Key,
	// RPC_STATUS *Status ) {...}
	[PInvokeData("rpcdce.h", MSDNShortId = "NC:rpcdce.RPC_AUTH_KEY_RETRIEVAL_FN")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void RPC_AUTH_KEY_RETRIEVAL_FN(IntPtr Arg, [MarshalAs(UnmanagedType.LPWStr)] string ServerPrincName, uint KeyVer, out IntPtr Key,
		out Win32Error Status);

	/// <summary>
	/// The <c>RPC_IF_CALLBACK_FN</c> is a prototype for a security-callback function that your application supplies. Your program can
	/// provide a callback function for each interface it defines.
	/// </summary>
	/// <param name="InterfaceUuid"/>
	/// <param name="Context"/>
	/// <returns>
	/// <para>
	/// The callback function should return RPC_S_OK if the client is allowed to call methods in this interface. Any other return code
	/// will cause the client to receive the exception RPC_S_ACCESS_DENIED.
	/// </para>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In some cases, the RPC run time may call the security-callback function more than once per client per interface. Be sure your
	/// callback function can handle this possibility.
	/// </para>
	/// <para>The security callback must be declared as RPC_ENTRY.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nc-rpcdce-rpc_if_callback_fn RPC_IF_CALLBACK_FN RpcIfCallbackFn;
	// RPC_STATUS RpcIfCallbackFn( RPC_IF_HANDLE InterfaceUuid, void *Context ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NC:rpcdce.RPC_IF_CALLBACK_FN")]
	public delegate Win32Error RPC_IF_CALLBACK_FN(RPC_IF_HANDLE InterfaceUuid, IntPtr Context);

	/// <summary>
	/// The <c>RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN</c> is a user-defined callback that can be implemented for each defined interface
	/// group. This callback is invoked by the RPC runtime when it detects that the idle state of an interface group has changed.
	/// </summary>
	/// <param name="IfGroup">
	/// A <c>RPC_INTERFACE_GROUP</c> from RpcServerInterfaceGroupCreate that defines the interface group for which the idle state has changed.
	/// </param>
	/// <param name="IdleCallbackContext"/>
	/// <param name="IsGroupIdle">
	/// <c>TRUE</c> if the interface group has just become idle. <c>FALSE</c> if the interface group was previously idle but has since
	/// received new activity.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// When a server registers an interface group, it provides a pointer to an idle callback function through which RPC will notify the
	/// application when the interface group’s idle state has changed. The server application can use this callback to attempt to
	/// deactivate the interface group when it becomes idle.
	/// </para>
	/// <para>RpcServerInterfaceGroupClose must not be called from this callback or deadlock can occur.</para>
	/// <para>
	/// Note that RPC server activity is not always visible to the server application. In some cases, simply having a client with an
	/// open connection to the server may keep it active even if no calls have been dispatched for a long period of time. Server
	/// applications must not rely on any correlation between the RPC runtime declaring that the group is idle and the time since the
	/// last call was dispatched.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nc-rpcdce-rpc_interface_group_idle_callback_fn
	// RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN RpcInterfaceGroupIdleCallbackFn; void RpcInterfaceGroupIdleCallbackFn( RPC_INTERFACE_GROUP
	// IfGroup, void *IdleCallbackContext, unsigned long IsGroupIdle ) {...}
	[PInvokeData("rpcdce.h", MSDNShortId = "NC:rpcdce.RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void RPC_INTERFACE_GROUP_IDLE_CALLBACK_FN(RPC_INTERFACE_GROUP IfGroup, IntPtr IdleCallbackContext, [MarshalAs(UnmanagedType.Bool)] bool IsGroupIdle);

	/// <summary>The RPC_MGMT_AUTHORIZATION_FN enables server programs to implement custom RPC authorization techniques.</summary>
	/// <param name="ClientBinding">Client/server binding handle.</param>
	/// <param name="RequestedMgmtOperation">
	/// <para>The value for RequestedMgmtOperation depends on the remote function requested, as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Called remote function</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RpcMgmtInqIfIds</term>
	/// <term>RPC_C_MGMT_INQ_IF_IDS</term>
	/// </item>
	/// <item>
	/// <term>RpcMgmtInqServerPrincName</term>
	/// <term>RPC_C_MGMT_INQ_PRINC_NAME</term>
	/// </item>
	/// <item>
	/// <term>RpcMgmtInqStats</term>
	/// <term>RPC_C_MGMT_INQ_STATS</term>
	/// </item>
	/// <item>
	/// <term>RpcMgmtIsServerListening</term>
	/// <term>RPC_C_MGMT_IS_SERVER_LISTEN</term>
	/// </item>
	/// <item>
	/// <term>RpcMgmtStopServerListening</term>
	/// <term>RPC_C_MGMT_STOP_SERVER_LISTEN</term>
	/// </item>
	/// </list>
	/// <para>The authorization function must handle all of these values.</para>
	/// </param>
	/// <param name="Status"/>
	/// <returns>
	/// Returns <c>TRUE</c> if the calling client is allowed access to the requested management function. If the authorization function
	/// returns <c>FALSE</c>, the management function cannot execute. In this case, the function returns a Status value to the client:
	/// </returns>
	/// <remarks>
	/// When a client requests one of the server's remote management functions, the server run-time library calls the authorization
	/// function with ClientBinding and RequestedMgmtOperation. The authorization function uses these parameters to determine whether
	/// the calling client can execute the requested management function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nc-rpcdce-rpc_mgmt_authorization_fn RPC_MGMT_AUTHORIZATION_FN
	// RpcMgmtAuthorizationFn; int RpcMgmtAuthorizationFn( RPC_BINDING_HANDLE ClientBinding, unsigned long RequestedMgmtOperation,
	// RPC_STATUS *Status ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NC:rpcdce.RPC_MGMT_AUTHORIZATION_FN")]
	public delegate BOOL RPC_MGMT_AUTHORIZATION_FN([In] RPC_BINDING_HANDLE ClientBinding, RPC_C_MGMT RequestedMgmtOperation, out Win32Error Status);

	/// <summary>
	/// The <c>RPC_OBJECT_INQ_FN</c> function is a prototype for a function that facilitates replacement of the default object UUID to
	/// type UUID mapping.
	/// </summary>
	/// <param name="ObjectUuid"/>
	/// <param name="TypeUuid"/>
	/// <param name="Status"/>
	/// <returns>None</returns>
	/// <remarks>
	/// You can replace the default mapping function that maps object UUIDs to type UUIDs by calling RpcObjectSetInqFn and supplying a
	/// pointer to a function of type RPC_OBJECT_INQ_FN. The supplied function must match the function prototype specified by the type
	/// definition: a function with three parameters and the function return value of void.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nc-rpcdce-rpc_object_inq_fn RPC_OBJECT_INQ_FN RpcObjectInqFn; void
	// RpcObjectInqFn( UUID *ObjectUuid, UUID *TypeUuid, RPC_STATUS *Status ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NC:rpcdce.RPC_OBJECT_INQ_FN")]
	public delegate void RPC_OBJECT_INQ_FN(in Guid ObjectUuid, out Guid TypeUuid, out Win32Error Status);

	/// <summary>The <c>DceErrorInqText</c> function returns the message text for a status code.</summary>
	/// <param name="RpcStatus">Status code to convert to a text string.</param>
	/// <param name="ErrorText">
	/// <para>Returns the text corresponding to the error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_ARG</term>
	/// <term>Unknown error code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns RPC_S_OK if it is successful, or an error code if not.</para>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// The <c>DceErrorInqText</c> routine fills the string pointed to by the ErrorText parameter with a null-terminated character
	/// string message for a particular status code.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-dceerrorinqtext RPC_STATUS DceErrorInqText( RPC_STATUS
	// RpcStatus, RPC_CSTR ErrorText );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.DceErrorInqText")]
	public static extern Win32Error DceErrorInqText(Win32Error RpcStatus, [MarshalAs(UnmanagedType.LPTStr)] string ErrorText);

	/// <summary>The <c>RpcBindingCopy</c> function copies binding information and creates a new binding handle.</summary>
	/// <param name="SourceBinding">Server binding handle whose referenced binding information is copied.</param>
	/// <param name="DestinationBinding">Returns a pointer to the server binding handle that refers to the copied binding information.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RpcBindingCopy</c> function copies the server-binding information referenced by the SourceBinding parameter.
	/// <c>RpcBindingCopy</c> uses the DestinationBinding parameter to return a new server binding handle for the copied binding
	/// information. <c>RpcBindingCopy</c> also copies the authentication information from the SourceBinding parameter to the
	/// DestinationBinding parameter.
	/// </para>
	/// <para>
	/// An application uses <c>RpcBindingCopy</c> when it wants to prevent a change being made to binding information by one thread from
	/// affecting the binding information used by other threads.
	/// </para>
	/// <para>
	/// Once an application calls <c>RpcBindingCopy</c>, operations performed on the SourceBinding binding handle do not affect the
	/// binding information referenced by the DestinationBinding binding handle. Similarly, operations performed on the
	/// DestinationBinding binding handle do not affect the binding information referenced by the SourceBinding binding handle.
	/// </para>
	/// <para>
	/// If an application wants one thread's changes to binding information to affect the binding information used by other threads, the
	/// application should share a single binding handle across the threads. In this case, the application is responsible for
	/// binding-handle concurrency control.
	/// </para>
	/// <para>
	/// When an application is finished using the binding handle specified by the DestinationBinding parameter, the application should
	/// call the RpcBindingFree function to release the memory used by the DestinationBinding binding handle and its referenced binding information.
	/// </para>
	/// <para><c>Note</c> Microsoft RPC supports <c>RpcBindingCopy</c> only in client applications, not in server applications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingcopy RPC_STATUS RpcBindingCopy( RPC_BINDING_HANDLE
	// SourceBinding, RPC_BINDING_HANDLE *DestinationBinding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingCopy")]
	public static extern Win32Error RpcBindingCopy(RPC_BINDING_HANDLE SourceBinding, out SafeRPC_BINDING_HANDLE DestinationBinding);

	/// <summary>The <c>RpcBindingCreate</c> function creates a new fast RPC binding handle based on a supplied template.</summary>
	/// <param name="Template">
	/// RPC_BINDING_HANDLE_TEMPLATE structure that describes the binding handle to be created by this call. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </param>
	/// <param name="Security">
	/// <para>
	/// RPC_BINDING_HANDLE_SECURITY structure that describes the security options for this binding handle. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </para>
	/// <para>
	/// This parameter is optional. If this parameter is set to <c>NULL</c>, the default security settings for
	/// RPC_BINDING_HANDLE_SECURITY will be used.
	/// </para>
	/// </param>
	/// <param name="Options">
	/// <para>
	/// RPC_BINDING_HANDLE_OPTIONS structure that describes additional options for the binding handle. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </para>
	/// <para>
	/// This parameter is optional. If this parameter is set to <c>NULL</c>, the default options for RPC_BINDING_HANDLE_OPTIONS will be used.
	/// </para>
	/// </param>
	/// <param name="Binding">
	/// RPC_BINDING_HANDLE structure that contains the newly-created binding handle. If this function did not return RPC_S_OK, then the
	/// contents of this structure are undefined. For non-local RPC calls, this handle must be passed to RpcBindingBind.
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns RPC_S_OK on success; otherwise, an RPC_S_* error code is returned. For information on these error codes,
	/// see RPC Return Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The binding handle was successfully created.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_CANNOT_SUPPORT</term>
	/// <term>An obsolete feature of RPC was requested for this binding handle.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>The RPC binding handle returned by this API can be used with any other functions that accepts a binding handle as a parameter.</para>
	/// <para>
	/// However, before any calls can be made on the binding handle, RpcBindingBind must be called to make the binding handle available
	/// for remote calls. The <c>RpcBindingCreate</c> API does not touch the network or attempt to communicate with the RPC server --
	/// rather, it simply builds an internal data structure based on the values supplied in the template. A successful return does not
	/// indicate that the RPC server is available, accessible, or correctly specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingcreatea RPC_STATUS RpcBindingCreateA(
	// RPC_BINDING_HANDLE_TEMPLATE_V1_A *Template, RPC_BINDING_HANDLE_SECURITY_V1_A *Security, RPC_BINDING_HANDLE_OPTIONS_V1 *Options,
	// RPC_BINDING_HANDLE *Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingCreateA")]
	public static extern Win32Error RpcBindingCreate(in RPC_BINDING_HANDLE_TEMPLATE_V1 Template, in RPC_BINDING_HANDLE_SECURITY_V1 Security, in RPC_BINDING_HANDLE_OPTIONS_V1 Options, out SafeRPC_BINDING_HANDLE Binding);

	/// <summary>The <c>RpcBindingCreate</c> function creates a new fast RPC binding handle based on a supplied template.</summary>
	/// <param name="Template">
	/// RPC_BINDING_HANDLE_TEMPLATE structure that describes the binding handle to be created by this call. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </param>
	/// <param name="Security">
	/// <para>
	/// RPC_BINDING_HANDLE_SECURITY structure that describes the security options for this binding handle. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </para>
	/// <para>
	/// This parameter is optional. If this parameter is set to <c>NULL</c>, the default security settings for
	/// RPC_BINDING_HANDLE_SECURITY will be used.
	/// </para>
	/// </param>
	/// <param name="Options">
	/// <para>
	/// RPC_BINDING_HANDLE_OPTIONS structure that describes additional options for the binding handle. This data may be overwritten
	/// during the call, so the API does not maintain a reference to this data. The caller must free the memory used by this structure
	/// when the API returns.
	/// </para>
	/// <para>
	/// This parameter is optional. If this parameter is set to <c>NULL</c>, the default options for RPC_BINDING_HANDLE_OPTIONS will be used.
	/// </para>
	/// </param>
	/// <param name="Binding">
	/// RPC_BINDING_HANDLE structure that contains the newly-created binding handle. If this function did not return RPC_S_OK, then the
	/// contents of this structure are undefined. For non-local RPC calls, this handle must be passed to RpcBindingBind.
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns RPC_S_OK on success; otherwise, an RPC_S_* error code is returned. For information on these error codes,
	/// see RPC Return Values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The binding handle was successfully created.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_CANNOT_SUPPORT</term>
	/// <term>An obsolete feature of RPC was requested for this binding handle.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>The RPC binding handle returned by this API can be used with any other functions that accepts a binding handle as a parameter.</para>
	/// <para>
	/// However, before any calls can be made on the binding handle, RpcBindingBind must be called to make the binding handle available
	/// for remote calls. The <c>RpcBindingCreate</c> API does not touch the network or attempt to communicate with the RPC server --
	/// rather, it simply builds an internal data structure based on the values supplied in the template. A successful return does not
	/// indicate that the RPC server is available, accessible, or correctly specified.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingcreatea RPC_STATUS RpcBindingCreateA(
	// RPC_BINDING_HANDLE_TEMPLATE_V1_A *Template, RPC_BINDING_HANDLE_SECURITY_V1_A *Security, RPC_BINDING_HANDLE_OPTIONS_V1 *Options,
	// RPC_BINDING_HANDLE *Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingCreateA")]
	public static extern Win32Error RpcBindingCreate(in RPC_BINDING_HANDLE_TEMPLATE_V1 Template, [In, Optional] IntPtr Security, [In, Optional] IntPtr Options, out SafeRPC_BINDING_HANDLE Binding);

	/// <summary>The <c>RpcBindingFree</c> function releases binding-handle resources.</summary>
	/// <param name="Binding">Pointer to the server binding to be freed.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RpcBindingFree</c> function releases memory used by a server binding handle. Referenced binding information that was
	/// dynamically created during program execution is released as well. An application calls the <c>RpcBindingFree</c> function when
	/// it is finished using the binding handle. RPC binding handles must not be freed until all calls using the handle have completed;
	/// failure to do so will cause unpredictable results.
	/// </para>
	/// <para>Binding handles are dynamically created by calling the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>RpcBindingCopy</term>
	/// </item>
	/// <item>
	/// <term>RpcBindingFromStringBinding</term>
	/// </item>
	/// <item>
	/// <term>RpcBindingServerFromClient</term>
	/// </item>
	/// <item>
	/// <term>RpcServerInqBindings</term>
	/// </item>
	/// <item>
	/// <term>RpcNsBindingImportNext</term>
	/// </item>
	/// <item>
	/// <term>RpcNsBindingSelect</term>
	/// </item>
	/// </list>
	/// <para>If the operation successfully frees the binding, the Binding parameter returns a value of <c>NULL</c>.</para>
	/// <para>
	/// <c>Note</c> Microsoft RPC supports <c>RpcBindingFree</c> only in client applications, or in server applications for binding
	/// handles generated with RpcBindingServerFromClient.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingfree RPC_STATUS RpcBindingFree( RPC_BINDING_HANDLE
	// *Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingFree")]
	public static extern Win32Error RpcBindingFree(ref RPC_BINDING_HANDLE Binding);

	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	private static extern Win32Error RpcBindingFree(ref IntPtr Binding);

	/// <summary>The <c>RpcBindingFree</c> function releases binding-handle resources.</summary>
	/// <param name="Binding">Pointer to the server binding to be freed.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RpcBindingFree</c> function releases memory used by a server binding handle. Referenced binding information that was
	/// dynamically created during program execution is released as well. An application calls the <c>RpcBindingFree</c> function when
	/// it is finished using the binding handle. RPC binding handles must not be freed until all calls using the handle have completed;
	/// failure to do so will cause unpredictable results.
	/// </para>
	/// <para>Binding handles are dynamically created by calling the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>RpcBindingCopy</term>
	/// </item>
	/// <item>
	/// <term>RpcBindingFromStringBinding</term>
	/// </item>
	/// <item>
	/// <term>RpcBindingServerFromClient</term>
	/// </item>
	/// <item>
	/// <term>RpcServerInqBindings</term>
	/// </item>
	/// <item>
	/// <term>RpcNsBindingImportNext</term>
	/// </item>
	/// <item>
	/// <term>RpcNsBindingSelect</term>
	/// </item>
	/// </list>
	/// <para>If the operation successfully frees the binding, the Binding parameter returns a value of <c>NULL</c>.</para>
	/// <para>
	/// <c>Note</c> Microsoft RPC supports <c>RpcBindingFree</c> only in client applications, or in server applications for binding
	/// handles generated with RpcBindingServerFromClient.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingfree RPC_STATUS RpcBindingFree( RPC_BINDING_HANDLE
	// *Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingFree")]
	public static extern Win32Error RpcBindingFree(SafeRPC_BINDING_HANDLE Binding);

	/// <summary>
	/// The <c>RpcBindingFromStringBinding</c> function returns a binding handle from a string representation of a binding handle.
	/// </summary>
	/// <param name="StringBinding">Pointer to a string representation of a binding handle.</param>
	/// <param name="Binding">Returns a pointer to the server binding handle.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_STRING_BINDING</term>
	/// <term>The string binding is not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
	/// <term>Protocol sequence not supported on this host.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_RPC_PROTSEQ</term>
	/// <term>The protocol sequence is not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_ENDPOINT_FORMAT</term>
	/// <term>The endpoint format is not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_STRING_TOO_LONG</term>
	/// <term>String too long.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_NET_ADDR</term>
	/// <term>The network address is not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_ARG</term>
	/// <term>The argument was not valid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_NAF_ID</term>
	/// <term>The network address family identifier is not valid.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RpcBindingFromStringBinding</c> function creates a server binding handle from a string representation of a binding
	/// handle. The StringBinding parameter does not have to contain an object UUID. In this case, the returned binding contains a nil
	/// UUID. If the provided StringBinding parameter does not contain an endpoint field, the returned Binding parameter is a
	/// partially-bound binding handle. If the provided StringBinding parameter contains an endpoint field, the endpoint is considered
	/// to be a well-known endpoint. If the provided StringBinding parameter does not contain a host address field, the returned Binding
	/// parameter references the local host.
	/// </para>
	/// <para>
	/// An application creates a string binding by calling the RpcStringBindingCompose function or by providing a character-string
	/// constant. The creation of a string binding by this method does not involve contact with the server. Success or failure of the
	/// API will not indicate server availability.
	/// </para>
	/// <para>
	/// When an application is finished using the Binding parameter, the application should call the RpcBindingFree function to release
	/// the memory used by the binding handle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingfromstringbinding RPC_STATUS
	// RpcBindingFromStringBinding( RPC_CSTR StringBinding, RPC_BINDING_HANDLE *Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingFromStringBinding")]
	public static extern Win32Error RpcBindingFromStringBinding([MarshalAs(UnmanagedType.LPTStr)] string StringBinding, out SafeRPC_BINDING_HANDLE Binding);

	/// <summary>
	/// A server application calls the <c>RpcBindingInqAuthClient</c> function to obtain the principal name or privilege attributes of
	/// the authenticated client that made the remote procedure call.
	/// </summary>
	/// <param name="ClientBinding">
	/// Client binding handle of the client that made the remote procedure call. This value can be zero. See Remarks.
	/// </param>
	/// <param name="Privs">
	/// <para>
	/// Returns a pointer to a handle to the privileged information for the client application that made the remote procedure call on
	/// the ClientBinding binding handle. For <c>ncalrpc</c> calls, Privs contains a string with the client's principal name.
	/// </para>
	/// <para>
	/// The data referenced by this parameter is read-only and should not be modified by the server application. If the server wants to
	/// preserve any of the returned data, the server must copy the data into server-allocated memory.
	/// </para>
	/// <para>
	/// The data that the Privs parameter points to comes directly from the SSP. Therefore, the format of the data is specific to the
	/// SSP. For more information on SSPs, see Security Support Providers (SSPs).
	/// </para>
	/// </param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Returns a pointer to a pointer to the server principal name specified by the server application that called the
	/// RpcServerRegisterAuthInfo function. The content of the returned name and its syntax are defined by the authentication service in
	/// use. For the SCHANNEL SSP, the principal name is in Microsoft-standard (msstd) format. For further information on msstd format,
	/// see Principal Names.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthClient</c> from returning the ServerPrincName parameter. In this case, the
	/// application does not call the RpcStringFree function.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// <para>
	/// Returns a pointer set to the level of authentication requested by the client application that made the remote procedure call on
	/// the ClientBinding binding handle.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthClient</c> from returning the AuthnLevel parameter.</para>
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>
	/// Returns a pointer set to the authentication service requested by the client application that made the remote procedure call on
	/// the ClientBinding binding handle. For a list of the RPC-supported authentication levels, see Authentication-Level Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthClient</c> from returning the AuthnSvc parameter.</para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>
	/// Returns a pointer set to the authorization service requested by the client application that made the remote procedure call on
	/// the ClientBinding binding handle.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthClient</c> from returning the AuthzSvc parameter. This parameter is not used
	/// by the RPC_C_AUTHN_WINNT authentication service. The returned value will always be RPC_C_AUTHZ_NONE.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_BINDING_HAS_NO_AUTH</term>
	/// <term>Binding has no authentication information.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server application calls the <c>RpcBindingInqAuthClient</c> function to obtain the principal name or privilege attributes of
	/// the authenticated client that made the remote procedure call. In addition, <c>RpcBindingInqAuthClient</c> returns the
	/// authentication service, authentication level, and server principal name specified by the client. The server can use the returned
	/// data for authorization purposes.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the returned ServerPrincName parameter. The application is responsible for calling
	/// the RpcStringFree function for the returned argument string.
	/// </para>
	/// <para>
	/// For synchronous RPC calls, the server application can use zero as the value for the ClientBinding parameter. Using zero
	/// retrieves the authentication and authorization information from the currently executing remote procedure call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqauthclient RPC_STATUS RpcBindingInqAuthClient(
	// RPC_BINDING_HANDLE ClientBinding, RPC_AUTHZ_HANDLE *Privs, RPC_WSTR *ServerPrincName, unsigned long *AuthnLevel, unsigned long
	// *AuthnSvc, unsigned long *AuthzSvc );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqAuthClient")]
	public static extern Win32Error RpcBindingInqAuthClient([In, Optional] RPC_BINDING_HANDLE ClientBinding, out RPC_AUTHZ_HANDLE Privs,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string ServerPrincName,
		out RPC_C_AUTHN_LEVEL AuthnLevel, out RPC_C_AUTHN AuthnSvc, out RPC_C_AUTHZ AuthzSvc);

	/// <summary>
	/// A server application calls the <c>RpcBindingInqAuthClientEx</c> function to obtain extended information about the client program
	/// that made the remote procedure call.
	/// </summary>
	/// <param name="ClientBinding">
	/// Client binding handle of the client that made the remote procedure call. This value can be zero. See Remarks.
	/// </param>
	/// <param name="Privs">
	/// <para>
	/// Returns a pointer to a handle to the privileged information for the client application that made the remote procedure call on
	/// the ClientBinding binding handle. For <c>ncalrpc</c> calls, Privs contains a string with the client's principal name.
	/// </para>
	/// <para>
	/// The server application must cast the Privs parameter to the data type specified by the AuthnSvc parameter. The data referenced
	/// by this argument is read-only and should not be modified by the server application. If the server wants to preserve any of the
	/// returned data, the server must copy the data into server-allocated memory.
	/// </para>
	/// <para>For more information on SSPs, see Security Support Providers (SSPs).</para>
	/// </param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Returns a pointer to a pointer to the server principal name specified by the server application that called the
	/// RpcServerRegisterAuthInfo function. The content of the returned name and its syntax are defined by the authentication service in
	/// use. For the SCHANNEL SSP, the principal name is in msstd format. For further information on msstd format, see Principal Names.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthClientEx</c> from returning the ServerPrincName parameter. In this case, the
	/// application does not call the RpcStringFree function.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// <para>
	/// Returns a pointer set to the level of authentication requested by the client application that made the remote procedure call on
	/// the ClientBinding binding handle. For a list of the RPC-supported authentication levels, see Authentication-Level Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthClientEx</c> from returning the AuthnLevel parameter.</para>
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>
	/// Returns a pointer set to the authentication service requested by the client application that made the remote procedure call on
	/// the ClientBinding binding handle. For a list of the RPC-supported authentication services, see Authentication-Service Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthClientEx</c> from returning the AuthnSvc parameter.</para>
	/// <para>
	/// <c>Note</c> AuthnSvc corresponds to the <c>SECURITY_STATUS</c> returned by QueryContextAttributes on each certificate-based SSP
	/// for <c>SECPKG_ATTR_DCE_INFO</c> or <c>SECPKG_ATTR_REMOTE_CERT_CONTEXT</c>.
	/// </para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>
	/// Returns a pointer set to the authorization service requested by the client application that made the remote procedure call on
	/// the Binding binding handle. For a list of the RPC-supported authorization services, see Authorization-Service Constants .
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthClientEx</c> from returning the AuthzSvc parameter. This parameter is not
	/// used by the RPC_C_AUTHN_WINNT authentication service. The returned value will always be RPC_S_AUTHZ_NONE.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Controls the format of the principal name. This parameter can be set to the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_C_FULL_CERT_CHAIN</term>
	/// <term>Passes back the principal name in fullsic format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_BINDING_HAS_NO_AUTH</term>
	/// <term>Binding has no authentication information.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server application calls the <c>RpcBindingInqAuthClientEx</c> function to obtain the principal name or privilege attributes of
	/// the authenticated client that made the remote procedure call. In addition, <c>RpcBindingInqAuthClientEx</c> returns the
	/// authentication service, authentication level, and server principal name specified by the client. The server can use the returned
	/// data for authorization purposes.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the returned ServerPrincName parameter. The application is responsible for calling
	/// the RpcStringFree function for the returned argument string.
	/// </para>
	/// <para>
	/// For synchronous RPC calls, the server application can use zero as the value for the ClientBinding parameter. Using zero
	/// retrieves the authentication and authorization information from the currently executing remote procedure call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqauthclientex RPC_STATUS
	// RpcBindingInqAuthClientEx( RPC_BINDING_HANDLE ClientBinding, RPC_AUTHZ_HANDLE *Privs, RPC_CSTR *ServerPrincName, unsigned long
	// *AuthnLevel, unsigned long *AuthnSvc, unsigned long *AuthzSvc, unsigned long Flags );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqAuthClientEx")]
	public static extern Win32Error RpcBindingInqAuthClientEx([In, Optional] RPC_BINDING_HANDLE ClientBinding, out RPC_AUTHZ_HANDLE Privs,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string ServerPrincName,
		out RPC_C_AUTHN_LEVEL AuthnLevel, out RPC_C_AUTHN AuthnSvc, out RPC_C_AUTHZ AuthzSvc, [Optional] uint Flags);

	/// <summary>The <c>RpcBindingInqAuthInfo</c> function returns authentication and authorization information from a binding handle.</summary>
	/// <param name="Binding">Server binding handle from which authentication and authorization information is returned.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Returns a pointer to a pointer to the expected principal name of the server referenced in Binding. The content of the returned
	/// name and its syntax are defined by the authentication service in use.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthInfo</c> from returning the ServerPrincName parameter. In this case, the
	/// application does not call the RpcStringFree function.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// <para>Returns a pointer set to the level of authentication used for remote procedure calls made using Binding. See Note.</para>
	/// <para>Specify a null value to prevent the function from returning the AuthnLevel parameter.</para>
	/// <para>
	/// The level returned in the AuthnLevel parameter may be different from the level specified when the client called the
	/// RpcBindingSetAuthInfo function. This discrepancy occurs when the RPC run-time library does not support the authentication level
	/// specified by the client and automatically upgrades to the next higher authentication level.
	/// </para>
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>Returns a pointer set to the authentication service specified for remote procedure calls made using Binding. See Note.</para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfo</c> from returning the AuthnSvc parameter.</para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Returns a pointer to a handle to the data structure that contains the client's authentication and authorization credentials
	/// specified for remote procedure calls made using Binding.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfo</c> from returning the AuthIdentity parameter.</para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>
	/// Returns a pointer set to the authorization service requested by the client application that made the remote procedure call on
	/// Binding See Note.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfo</c> from returning the AuthzSvc parameter.</para>
	/// <para><c>Note</c> For a list of the RPC-supported authentication services, see Authentication-Service Constants.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_BINDING_HAS_NO_AUTH</term>
	/// <term>Binding has no authentication information.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingInqAuthInfo</c> function to view the authentication and authorization information
	/// associated with a server binding handle. A similar function, RpcBindingInqAuthInfoEx additionally provides security
	/// quality-of-service information on the binding handle.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the returned ServerPrincName parameter. The application is responsible for calling
	/// the RpcStringFree function for that returned argument string.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqauthinfo RPC_STATUS RpcBindingInqAuthInfo(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR *ServerPrincName, unsigned long *AuthnLevel, unsigned long *AuthnSvc,
	// RPC_AUTH_IDENTITY_HANDLE *AuthIdentity, unsigned long *AuthzSvc );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqAuthInfo")]
	public static extern Win32Error RpcBindingInqAuthInfo([In] RPC_BINDING_HANDLE Binding,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string ServerPrincName,
		out RPC_C_AUTHN_LEVEL AuthnLevel, out RPC_C_AUTHN AuthnSvc, out RPC_AUTH_IDENTITY_HANDLE AuthIdentity, out RPC_C_AUTHZ AuthzSvc);

	/// <summary>
	/// The <c>RpcBindingInqAuthInfoEx</c> function returns authentication, authorization, and security quality-of-service information
	/// from a binding handle.
	/// </summary>
	/// <param name="Binding">Server binding handle from which authentication and authorization information is returned.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Returns a pointer to a pointer to the expected principal name of the server referenced in Binding. The content of the returned
	/// name and its syntax are defined by the authentication service in use.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the ServerPrincName parameter. In this case, the
	/// application does not call the RpcStringFree function.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// <para>
	/// Returns a pointer set to the level of authentication used for remote procedure calls made using Binding. For a list of the
	/// RPC-supported authentication levels, see Authentication-Level Constants. Specify a null value to prevent the function from
	/// returning the AuthnLevel parameter.
	/// </para>
	/// <para>
	/// The level returned in the AuthnLevel parameter may be different from the level specified when the client called the
	/// RpcBindingSetAuthInfoEx function. This discrepancy happens when the RPC run-time library does not support the authentication
	/// level specified by the client and automatically upgrades to the next higher authentication level.
	/// </para>
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>
	/// Returns a pointer set to the authentication service specified for remote procedure calls made using Binding. For a list of the
	/// RPC-supported authentication services, see Authentication-Service Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthnSvc parameter.</para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Returns a pointer to a handle to the data structure that contains the client's authentication and authorization credentials
	/// specified for remote procedure calls made using Binding.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthIdentity parameter.</para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>
	/// Returns a pointer set to the authorization service requested by the client application that made the remote procedure call on
	/// Binding. For a list of the RPC-supported authentication services, see Authentication-Service Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthzSvc parameter.</para>
	/// </param>
	/// <param name="RpcQosVersion">
	/// Passes value of current version (needed for forward compatibility if extensions are made to this function). Always set this
	/// parameter to RPC_C_SECURITY_QOS_VERSION.
	/// </param>
	/// <param name="SecurityQOS">Returns pointer to the RPC_SECURITY_QOS structure, which defines quality-of-service settings.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_BINDING_HAS_NO_AUTH</term>
	/// <term>Binding has no authentication information.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingInqAuthInfoEx</c> function to view the authentication and authorization information
	/// associated with a server binding handle. This function provides the ability to inquire about the security quality of service on
	/// the binding handle. It is otherwise identical to RpcBindingInqAuthInfo.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the returned ServerPrincName parameter. The application is responsible for calling
	/// the RpcStringFree function for that returned argument string.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqauthinfoexa RPC_STATUS RpcBindingInqAuthInfoExA(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR *ServerPrincName, unsigned long *AuthnLevel, unsigned long *AuthnSvc,
	// RPC_AUTH_IDENTITY_HANDLE *AuthIdentity, unsigned long *AuthzSvc, unsigned long RpcQosVersion, RPC_SECURITY_QOS *SecurityQOS );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqAuthInfoExA")]
	public static extern Win32Error RpcBindingInqAuthInfoEx([In] RPC_BINDING_HANDLE Binding,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string ServerPrincName,
		out RPC_C_AUTHN_LEVEL AuthnLevel, out RPC_C_AUTHN AuthnSvc, out RPC_AUTH_IDENTITY_HANDLE AuthIdentity, out RPC_C_AUTHZ AuthzSvc,
		uint RpcQosVersion, in RPC_SECURITY_QOS SecurityQOS);

	/// <summary>
	/// The <c>RpcBindingInqAuthInfoEx</c> function returns authentication, authorization, and security quality-of-service information
	/// from a binding handle.
	/// </summary>
	/// <param name="Binding">Server binding handle from which authentication and authorization information is returned.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Returns a pointer to a pointer to the expected principal name of the server referenced in Binding. The content of the returned
	/// name and its syntax are defined by the authentication service in use.
	/// </para>
	/// <para>
	/// Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the ServerPrincName parameter. In this case, the
	/// application does not call the RpcStringFree function.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// <para>
	/// Returns a pointer set to the level of authentication used for remote procedure calls made using Binding. For a list of the
	/// RPC-supported authentication levels, see Authentication-Level Constants. Specify a null value to prevent the function from
	/// returning the AuthnLevel parameter.
	/// </para>
	/// <para>
	/// The level returned in the AuthnLevel parameter may be different from the level specified when the client called the
	/// RpcBindingSetAuthInfoEx function. This discrepancy happens when the RPC run-time library does not support the authentication
	/// level specified by the client and automatically upgrades to the next higher authentication level.
	/// </para>
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>
	/// Returns a pointer set to the authentication service specified for remote procedure calls made using Binding. For a list of the
	/// RPC-supported authentication services, see Authentication-Service Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthnSvc parameter.</para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Returns a pointer to a handle to the data structure that contains the client's authentication and authorization credentials
	/// specified for remote procedure calls made using Binding.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthIdentity parameter.</para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>
	/// Returns a pointer set to the authorization service requested by the client application that made the remote procedure call on
	/// Binding. For a list of the RPC-supported authentication services, see Authentication-Service Constants.
	/// </para>
	/// <para>Specify a null value to prevent <c>RpcBindingInqAuthInfoEx</c> from returning the AuthzSvc parameter.</para>
	/// </param>
	/// <param name="RpcQosVersion">
	/// Passes value of current version (needed for forward compatibility if extensions are made to this function). Always set this
	/// parameter to RPC_C_SECURITY_QOS_VERSION.
	/// </param>
	/// <param name="SecurityQOS">Returns pointer to the RPC_SECURITY_QOS structure, which defines quality-of-service settings.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_BINDING_HAS_NO_AUTH</term>
	/// <term>Binding has no authentication information.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingInqAuthInfoEx</c> function to view the authentication and authorization information
	/// associated with a server binding handle. This function provides the ability to inquire about the security quality of service on
	/// the binding handle. It is otherwise identical to RpcBindingInqAuthInfo.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the returned ServerPrincName parameter. The application is responsible for calling
	/// the RpcStringFree function for that returned argument string.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqauthinfoexa RPC_STATUS RpcBindingInqAuthInfoExA(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR *ServerPrincName, unsigned long *AuthnLevel, unsigned long *AuthnSvc,
	// RPC_AUTH_IDENTITY_HANDLE *AuthIdentity, unsigned long *AuthzSvc, unsigned long RpcQosVersion, RPC_SECURITY_QOS *SecurityQOS );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqAuthInfoExA")]
	public static extern Win32Error RpcBindingInqAuthInfoEx([In] RPC_BINDING_HANDLE Binding,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string ServerPrincName,
		out RPC_C_AUTHN_LEVEL AuthnLevel, out RPC_C_AUTHN AuthnSvc, out RPC_AUTH_IDENTITY_HANDLE AuthIdentity, out RPC_C_AUTHZ AuthzSvc,
		uint RpcQosVersion, [In, Optional] IntPtr SecurityQOS);

	/// <summary>The <c>RpcBindingInqObject</c> function returns the object UUID from a binding handle.</summary>
	/// <param name="Binding">Client or server binding handle.</param>
	/// <param name="ObjectUuid">
	/// Returns a pointer to the object UUID found in the Binding parameter. ObjectUuid is a unique identifier of an object to which a
	/// remote procedure call can be made.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// An application calls the <c>RpcBindingInqObject</c> function to see the object UUID associated with a client or server binding handle.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqobject RPC_STATUS RpcBindingInqObject(
	// RPC_BINDING_HANDLE Binding, UUID *ObjectUuid );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqObject")]
	public static extern Win32Error RpcBindingInqObject(RPC_BINDING_HANDLE Binding, out Guid ObjectUuid);

	/// <summary>
	/// RPC client processes use <c>RpcBindingInqOption</c> to determine current values of the binding options for a given binding handle.
	/// </summary>
	/// <param name="hBinding">Server binding about which to determine binding-option values.</param>
	/// <param name="option">Binding handle property to inquire about.</param>
	/// <param name="pOptionValue">
	/// <para>Memory location to place the value for the specified Option</para>
	/// <para><c>Note</c> For a list of binding options and their possible values, see Binding Option Constants.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_CANNOT_SUPPORT</term>
	/// <term>The function is not supported for either the operating system or the transport.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// Client processes call <c>RpcBindingInqOption</c> to determine the current settings of the binding handle options. To inquire
	/// about authentication settings clients call the RpcBindingInqAuthClient function. .
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindinginqoption RPC_STATUS RpcBindingInqOption(
	// RPC_BINDING_HANDLE hBinding, unsigned long option, ULONG_PTR *pOptionValue );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingInqOption")]
	public static extern Win32Error RpcBindingInqOption(RPC_BINDING_HANDLE hBinding, RPC_C_OPT option, out IntPtr pOptionValue);

	/// <summary>
	/// The <c>RpcBindingReset</c> function resets a binding handle so that the host is specified but the server on that host is unspecified.
	/// </summary>
	/// <param name="Binding">Server binding handle to reset.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client calls the <c>RpcBindingReset</c> function to disassociate a particular server instance from the server binding handle
	/// specified in the Binding parameter. The <c>RpcBindingReset</c> function dissociates a server instance by removing the endpoint
	/// portion of the server address in the binding handle. The host remains unchanged in the binding handle. The result is a
	/// partially-bound server binding handle.
	/// </para>
	/// <para><c>RpcBindingReset</c> does not affect the Binding parameter's authentication information, if there is any.</para>
	/// <para>
	/// If a client is willing to be serviced by any compatible server instance on the host specified in the binding handle, the client
	/// calls the <c>RpcBindingReset</c> function before making a remote procedure call using the Binding binding handle. Clients must
	/// not call the <c>RpcBindingReset</c> function for binding handles on which calls are being executed.
	/// </para>
	/// <para>
	/// When the client makes the next remote procedure call using the reset (partially-bound) binding, the client's RPC run-time
	/// library uses a well-known endpoint from the client's interface specification, if any. Otherwise, the client's run-time library
	/// automatically communicates with the endpoint-mapping service on the specified remote host to obtain the endpoint of a compatible
	/// server from the endpoint-map database. If a compatible server is located, the RPC run-time library updates the binding with a
	/// new endpoint. If a compatible server is not found, the remote procedure call fails. For calls using a connection protocol
	/// (ncacn), the EPT_S_NOT_REGISTERED status code is returned to the client. For calls using a datagram protocol (ncadg), the
	/// RPC_S_COMM_FAILURE status code is returned to the client.
	/// </para>
	/// <para>
	/// Server applications should register all binding handles by calling RpcEpRegister and RpcEpRegisterNoReplace if the server wants
	/// to be available to clients that make a remote procedure call on a reset binding handle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingreset RPC_STATUS RpcBindingReset(
	// RPC_BINDING_HANDLE Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingReset")]
	public static extern Win32Error RpcBindingReset(RPC_BINDING_HANDLE Binding);

	/// <summary>
	/// An application calls <c>RpcBindingServerFromClient</c> to convert a client binding handle into a partially-bound server binding handle.
	/// </summary>
	/// <param name="ClientBinding">
	/// <para>
	/// Client binding handle to convert to a server binding handle. If a value of zero is specified, the server impersonates the client
	/// that is being served by this server thread.
	/// </para>
	/// <para><c>Note</c> This parameter cannot be <c>NULL</c> in Windows NT 4.0.</para>
	/// </param>
	/// <param name="ServerBinding">Returns a server binding handle.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_CANNOT_SUPPORT</term>
	/// <term>Cannot determine the client's host. See Remarks for a list of supported protocol sequences.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following protocol sequences support <c>RpcBindingServerFromClient</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ncadg_ip_udp</term>
	/// </item>
	/// <item>
	/// <term>ncadg_ipx</term>
	/// </item>
	/// <item>
	/// <term>ncacn_ip_tcp</term>
	/// </item>
	/// <item>
	/// <term>ncacn_spx.</term>
	/// </item>
	/// <item>
	/// <term>ncacn_np (effective with Windows 2000)</term>
	/// </item>
	/// <item>
	/// <term>ncacn_http</term>
	/// </item>
	/// <item>
	/// <term>ncalrpc</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application gets a client binding handle from the RPC run-time. When the remote procedure call arrives at a server, the
	/// run-time creates a client binding handle that contains information about the calling client. The run-time passes this handle to
	/// the server manager function as the first argument.
	/// </para>
	/// <para>Calling <c>RpcBindingServerFromClient</c> converts this client handle to a server handle that has these properties:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The server handle is a partially-bound handle. It contains a network address for the calling client, but lacks an endpoint.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The server handle contains the same object UUID used by the calling client. This can be the nil UUID. For more information on
	/// how a client specifies an object UUID for a call, see RpcBindingsetObject, RpcNsBindingImportBegin, RpcNsBindingLookupBegin, and RpcBindingFromStringBinding.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The server handle contains no authentication information.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The server application must call RpcBindingFree to free the resources used by the server binding handle once it is no longer needed.
	/// </para>
	/// <para>
	/// <c>Note</c> To query a client's address, an application starts by calling the RpcBindingServerFromClient function to obtain a
	/// partially bound server binding handle. The server binding handle can be used to obtain a string binding by invoking
	/// RpcBindingToStringBinding. The server can then call RpcStringBindingParse to extract the client's network address from the
	/// string binding.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingserverfromclient RPC_STATUS
	// RpcBindingServerFromClient( RPC_BINDING_HANDLE ClientBinding, RPC_BINDING_HANDLE *ServerBinding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingServerFromClient")]
	public static extern Win32Error RpcBindingServerFromClient([In, Optional] RPC_BINDING_HANDLE ClientBinding, out SafeRPC_BINDING_HANDLE ServerBinding);

	/// <summary>The <c>RpcBindingSetAuthInfo</c> function sets a binding handle's authentication and authorization information.</summary>
	/// <param name="Binding">Server binding handle to which authentication and authorization information is to be applied.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Pointer to the expected principal name of the server referenced by Binding. The content of the name and its syntax are defined
	/// by the authentication service in use.
	/// </para>
	/// <para>
	/// <c>Note</c> For the set of allowable target names for SSPs, please refer to the comments in the InitializeSecurityContext documentation.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// Level of authentication to be performed on remote procedure calls made using Binding. For a list of the RPC-supported
	/// authentication levels, see the list of Authentication-Level Constants.
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>Authentication service to use. See Note.</para>
	/// <para>Specify RPC_C_AUTHN_NONE to turn off authentication for remote procedure calls made using Binding.</para>
	/// <para>
	/// If RPC_C_AUTHN_DEFAULT is specified, the RPC run-time library uses the RPC_C_AUTHN_WINNT authentication service for remote
	/// procedure calls made using Binding.
	/// </para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Handle to the structure containing the client's authentication and authorization credentials appropriate for the selected
	/// authentication and authorization service.When using the RPC_C_AUTHN_WINNT authentication service AuthIdentity should be a
	/// pointer to a SEC_WINNT_AUTH_IDENTITY structure (defined in Rpcdce.h). Kerberos and Negotiate authentication services also use
	/// the <c>SEC_WINNT_AUTH_IDENTITY</c> structure.
	/// </para>
	/// <para>
	/// When you select the RPC_C_AUTHN_GSS_SCHANNEL authentication service, the AuthIdentity parameter should be a pointer to an
	/// <c>SCHANNEL_CRED</c> structure (defined in Schannel.h). Specify a null value to use the security login context for the current
	/// address space. Pass the value RPC_C_NO_CREDENTIALS to use an anonymous log-in context.
	/// </para>
	/// <para>
	/// <c>Note</c> When selecting the RPC_C_AUTHN_GSS_SCHANNEL authentication service, the AuthIdentity parameter may also be a pointer
	/// to a <c>SCH_CRED</c> structure. However, in Windows XP and later releases of Windows, the only acceptable structure to be passed
	/// as the AuthIdentity parameter for the RPC_C_AUTHN_GSS_SCHANNEL authentication service is the <c>SCHANNEL_CRED</c> structure.
	/// </para>
	/// </param>
	/// <param name="AuthzSvc">
	/// <para>Authorization service implemented by the server for the interface of interest. See Note.</para>
	/// <para>
	/// The validity and trustworthiness of authorization data, like any application data, depends on the authentication service and
	/// authentication level selected. This parameter is ignored when using the RPC_C_AUTHN_WINNT authentication service.
	/// </para>
	/// <para><c>Note</c> For more information, see Authentication-Service Constants.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_AUTHN_SERVICE</term>
	/// <term>Unknown authentication service.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingSetAuthInfo</c> function to set up a server binding handle for making authenticated
	/// remote procedure calls. A client is not required to call this function.
	/// </para>
	/// <para>
	/// Unless a client calls <c>RpcBindingSetAuthInfo</c>, no remote procedure calls on the Binding binding handle are authenticated. A
	/// server can call RpcBindingInqAuthClient from within a remote procedure call to determine whether that call has been authenticated.
	/// </para>
	/// <para>
	/// The <c>RpcBindingSetAuthInfo</c> function takes a snapshot of the credentials. Therefore, the memory dedicated to the
	/// AuthIdentity parameter can be freed before the binding handle.
	/// </para>
	/// <para>
	/// Due to varying requirements of different versions of Microsoft RPC, Microsoft recommends that your application maintain a
	/// pointer to the AuthIdentity parameter for as long as the binding handle exists. Doing so increases the application's portability.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> For Windows XP SP2 and Windows Server 2003 SP1, the pointer to the
	/// AuthIdentity parameter need not be maintained for the life of the binding handle. This pointer must only be maintained if
	/// subsequent calls to RpcBindingInqAuthInfo or RpcBindingInqAuthInfoEx are made.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>RpcBindingSetAuthInfo</c> function must not be called on a binding handle while an RPC call on the same
	/// handle is in progress. Doing so produces undefined results.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingsetauthinfo RPC_STATUS RpcBindingSetAuthInfo(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR ServerPrincName, unsigned long AuthnLevel, unsigned long AuthnSvc, RPC_AUTH_IDENTITY_HANDLE
	// AuthIdentity, unsigned long AuthzSvc );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingSetAuthInfo")]
	public static extern Win32Error RpcBindingSetAuthInfo(RPC_BINDING_HANDLE Binding,
		[MarshalAs(UnmanagedType.LPTStr)] string ServerPrincName, RPC_C_AUTHN_LEVEL AuthnLevel, RPC_C_AUTHN AuthnSvc,
		[In, Optional] RPC_AUTH_IDENTITY_HANDLE AuthIdentity, RPC_C_AUTHZ AuthzSvc);

	/// <summary>
	/// The <c>RpcBindingSetAuthInfoEx</c> function sets a binding handle's authentication, authorization, and security
	/// quality-of-service information.
	/// </summary>
	/// <param name="Binding">Server binding handle into which authentication and authorization information is set.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Pointer to the expected principal name of the server referenced by Binding. The content of the name and its syntax are defined
	/// by the authentication service in use.
	/// </para>
	/// <para>
	/// <c>Note</c> For the set of allowable target names for SSPs, please refer to the comments in the InitializeSecurityContext documentation.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// Level of authentication to be performed on remote procedure calls made using Binding. For a list of the RPC-supported
	/// authentication levels, see Authentication-Level Constants.
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>Authentication service to use.</para>
	/// <para>Specify RPC_C_AUTHN_NONE to turn off authentication for remote procedure calls made using Binding.</para>
	/// <para>
	/// If RPC_C_AUTHN_DEFAULT is specified, the RPC run-time library uses the RPC_C_AUTHN_WINNT authentication service for remote
	/// procedure calls made using Binding.
	/// </para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Handle for the structure that contains the client's authentication and authorization credentials appropriate for the selected
	/// authentication and authorization service.
	/// </para>
	/// <para>
	/// When using the RPC_C_AUTHN_WINNTauthentication service AuthIdentity should be a pointer to a SEC_WINNT_AUTH_IDENTITY structure
	/// (defined in Rpcdce.h). Kerberos and Negotiate authentication services also use the <c>SEC_WINNT_AUTH_IDENTITY</c> structure.
	/// </para>
	/// <para>
	/// Specify a null value to use the security login context for the current address space. Pass the value RPC_C_NO_CREDENTIALS to use
	/// an anonymous log-in context. Note that RPC_C_NO_CREDENTIALS is only valid if RPC_C_AUTHN_GSS_SCHANNEL is selected as the
	/// authentication service.
	/// </para>
	/// </param>
	/// <param name="AuthzSvc">
	/// Authorization service implemented by the server for the interface of interest. The validity and trustworthiness of authorization
	/// data, like any application data, depends on the authentication service and authentication level selected. This parameter is
	/// ignored when using the RPC_C_AUTHN_WINNT authentication service. See Note.
	/// </param>
	/// <param name="SecurityQos">TBD</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_AUTHN_SERVICE</term>
	/// <term>Unknown authentication service.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingSetAuthInfoEx</c> function to set up a server binding handle for making
	/// authenticated remote procedure calls. This function provides the capability to set security quality-of-service information on
	/// the binding handle. It is otherwise identical to RpcBindingSetAuthInfo.
	/// </para>
	/// <para>
	/// Unless a client calls <c>RpcBindingSetAuthInfoEx</c>, all remote procedure calls on Binding are unauthenticated. A client is not
	/// required to call this function.
	/// </para>
	/// <para>
	/// The <c>RpcBindingSetAuthInfoEx</c> function takes a snapshot of the credentials. Therefore, the memory dedicated to the
	/// AuthIdentity parameter can be freed before the binding handle. The exception to this is when your application uses
	/// <c>RpcBindingSetAuthInfoEx</c> with RPC_C_QOS_IDENTITY_DYNAMIC and also specifies a non- <c>NULL</c> value for AuthIdentity.
	/// </para>
	/// <para>
	/// <c>Note</c> The RpcBindingSetAuthInfo function must not be called on a binding handle while an RPC call on the same handle is in
	/// progress. Doing so produces undefined results.
	/// </para>
	/// <para>
	/// Due to the varying requirements of different versions of Microsoft RPC, Microsoft recommends that an application maintain a
	/// pointer to the AuthIdentity parameter for as long as the binding handle exists. Doing so increases the applications portability.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> For Windows XP SP2 and Windows Server 2003 SP1, the pointer to the
	/// AuthIdentity parameter need not be maintained for the life of the binding handle. This pointer must only be maintained if
	/// subsequent calls to RpcBindingInqAuthInfo or RpcBindingInqAuthInfoEx are made.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>ncalrpc</c> protocol sequence supports only RPC_C_AUTHN_WINNT, but does support mutual authentication; supply
	/// an SPN and request mutual authentication through the SecurityQOS parameter to achieve this.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingsetauthinfoexa RPC_STATUS RpcBindingSetAuthInfoExA(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR ServerPrincName, unsigned long AuthnLevel, unsigned long AuthnSvc, RPC_AUTH_IDENTITY_HANDLE
	// AuthIdentity, unsigned long AuthzSvc, RPC_SECURITY_QOS *SecurityQos );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingSetAuthInfoExA")]
	public static extern Win32Error RpcBindingSetAuthInfoEx(RPC_BINDING_HANDLE Binding, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? ServerPrincName,
		RPC_C_AUTHN_LEVEL AuthnLevel, RPC_C_AUTHN AuthnSvc, [In, Optional] RPC_AUTH_IDENTITY_HANDLE AuthIdentity, RPC_C_AUTHZ AuthzSvc, in RPC_SECURITY_QOS SecurityQos);

	/// <summary>
	/// The <c>RpcBindingSetAuthInfoEx</c> function sets a binding handle's authentication, authorization, and security
	/// quality-of-service information.
	/// </summary>
	/// <param name="Binding">Server binding handle into which authentication and authorization information is set.</param>
	/// <param name="ServerPrincName">
	/// <para>
	/// Pointer to the expected principal name of the server referenced by Binding. The content of the name and its syntax are defined
	/// by the authentication service in use.
	/// </para>
	/// <para>
	/// <c>Note</c> For the set of allowable target names for SSPs, please refer to the comments in the InitializeSecurityContext documentation.
	/// </para>
	/// </param>
	/// <param name="AuthnLevel">
	/// Level of authentication to be performed on remote procedure calls made using Binding. For a list of the RPC-supported
	/// authentication levels, see Authentication-Level Constants.
	/// </param>
	/// <param name="AuthnSvc">
	/// <para>Authentication service to use.</para>
	/// <para>Specify RPC_C_AUTHN_NONE to turn off authentication for remote procedure calls made using Binding.</para>
	/// <para>
	/// If RPC_C_AUTHN_DEFAULT is specified, the RPC run-time library uses the RPC_C_AUTHN_WINNT authentication service for remote
	/// procedure calls made using Binding.
	/// </para>
	/// </param>
	/// <param name="AuthIdentity">
	/// <para>
	/// Handle for the structure that contains the client's authentication and authorization credentials appropriate for the selected
	/// authentication and authorization service.
	/// </para>
	/// <para>
	/// When using the RPC_C_AUTHN_WINNTauthentication service AuthIdentity should be a pointer to a SEC_WINNT_AUTH_IDENTITY structure
	/// (defined in Rpcdce.h). Kerberos and Negotiate authentication services also use the <c>SEC_WINNT_AUTH_IDENTITY</c> structure.
	/// </para>
	/// <para>
	/// Specify a null value to use the security login context for the current address space. Pass the value RPC_C_NO_CREDENTIALS to use
	/// an anonymous log-in context. Note that RPC_C_NO_CREDENTIALS is only valid if RPC_C_AUTHN_GSS_SCHANNEL is selected as the
	/// authentication service.
	/// </para>
	/// </param>
	/// <param name="AuthzSvc">
	/// Authorization service implemented by the server for the interface of interest. The validity and trustworthiness of authorization
	/// data, like any application data, depends on the authentication service and authentication level selected. This parameter is
	/// ignored when using the RPC_C_AUTHN_WINNT authentication service. See Note.
	/// </param>
	/// <param name="SecurityQos">TBD</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_AUTHN_SERVICE</term>
	/// <term>Unknown authentication service.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A client application calls the <c>RpcBindingSetAuthInfoEx</c> function to set up a server binding handle for making
	/// authenticated remote procedure calls. This function provides the capability to set security quality-of-service information on
	/// the binding handle. It is otherwise identical to RpcBindingSetAuthInfo.
	/// </para>
	/// <para>
	/// Unless a client calls <c>RpcBindingSetAuthInfoEx</c>, all remote procedure calls on Binding are unauthenticated. A client is not
	/// required to call this function.
	/// </para>
	/// <para>
	/// The <c>RpcBindingSetAuthInfoEx</c> function takes a snapshot of the credentials. Therefore, the memory dedicated to the
	/// AuthIdentity parameter can be freed before the binding handle. The exception to this is when your application uses
	/// <c>RpcBindingSetAuthInfoEx</c> with RPC_C_QOS_IDENTITY_DYNAMIC and also specifies a non- <c>NULL</c> value for AuthIdentity.
	/// </para>
	/// <para>
	/// <c>Note</c> The RpcBindingSetAuthInfo function must not be called on a binding handle while an RPC call on the same handle is in
	/// progress. Doing so produces undefined results.
	/// </para>
	/// <para>
	/// Due to the varying requirements of different versions of Microsoft RPC, Microsoft recommends that an application maintain a
	/// pointer to the AuthIdentity parameter for as long as the binding handle exists. Doing so increases the applications portability.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> For Windows XP SP2 and Windows Server 2003 SP1, the pointer to the
	/// AuthIdentity parameter need not be maintained for the life of the binding handle. This pointer must only be maintained if
	/// subsequent calls to RpcBindingInqAuthInfo or RpcBindingInqAuthInfoEx are made.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>ncalrpc</c> protocol sequence supports only RPC_C_AUTHN_WINNT, but does support mutual authentication; supply
	/// an SPN and request mutual authentication through the SecurityQOS parameter to achieve this.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcbindingsetauthinfoexa RPC_STATUS RpcBindingSetAuthInfoExA(
	// RPC_BINDING_HANDLE Binding, RPC_CSTR ServerPrincName, unsigned long AuthnLevel, unsigned long AuthnSvc, RPC_AUTH_IDENTITY_HANDLE
	// AuthIdentity, unsigned long AuthzSvc, RPC_SECURITY_QOS *SecurityQos );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcBindingSetAuthInfoExA")]
	public static extern Win32Error RpcBindingSetAuthInfoEx(RPC_BINDING_HANDLE Binding, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? ServerPrincName,
		RPC_C_AUTHN_LEVEL AuthnLevel, RPC_C_AUTHN AuthnSvc, [In, Optional] RPC_AUTH_IDENTITY_HANDLE AuthIdentity, RPC_C_AUTHZ AuthzSvc,
		[In, Optional] IntPtr SecurityQos);

	/// <summary>
	/// The <c>RpcMgmtStopServerListening</c> function tells a server to stop listening for remote procedure calls. This function will
	/// not affect auto-listen interfaces. See RpcServerRegisterIfEx for more details.
	/// </summary>
	/// <param name="Binding">
	/// To direct a remote application to stop listening for remote procedure calls, specify a server binding handle for that
	/// application. To direct your own (local) application to stop listening for remote procedure calls, specify a value of <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_BINDING</term>
	/// <term>The binding handle was invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_WRONG_KIND_OF_BINDING</term>
	/// <term>This was the wrong kind of binding for the operation.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application calls the <c>RpcMgmtStopServerListening</c> function to direct a server to stop listening for remote procedure
	/// calls. If DontWait was <c>TRUE</c>, the application should call RpcMgmtWaitServerListen to wait for all calls to complete.
	/// </para>
	/// <para>
	/// When it receives a stop-listening request, the RPC run-time library stops accepting new remote procedure calls for all
	/// registered interfaces. Executing calls are allowed to complete, including callbacks. After all calls complete, this function
	/// signals RpcServerListen function that it must stop listening and return to the caller. If the DontWait parameter of
	/// <c>RpcServerListen</c> was set to <c>TRUE</c>, the application calls RpcMgmtWaitServerListen for all remaining calls to complete.
	/// </para>
	/// <para>
	/// <c>Note</c> From the client-side, <c>RpcMgmtStopServerListening</c> is disabled by default. To enable this function, create an
	/// authorization function in your server application that returns <c>TRUE</c> (to allow a remote shutdown) whenever
	/// <c>RpcMgmtStopServerListening</c> is called. Use RpcMgmtSetAuthorizationFn to give the client access to the management function.
	/// </para>
	/// <para>
	/// The server must be listening for remote procedure calls for this function to succeed. If the server is not listening, the
	/// function fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcmgmtstopserverlistening RPC_STATUS
	// RpcMgmtStopServerListening( RPC_BINDING_HANDLE Binding );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcMgmtStopServerListening")]
	public static extern Win32Error RpcMgmtStopServerListening([In, Optional] RPC_BINDING_HANDLE Binding);

	/// <summary>The <c>RpcMgmtWaitServerListen</c> function performs the wait operation usually associated with RpcServerListen.</summary>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>All remote procedure calls are complete.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_ALREADY_LISTENING</term>
	/// <term>Another thread has called RpcMgmtWaitServerListen and has not yet returned.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_NOT_LISTENING</term>
	/// <term>The server application must call RpcServerListen before calling RpcMgmtWaitServerListen.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the RpcServerListen flag parameter DontWait has a nonzero value, the RpcServerListen function returns to the server
	/// application without performing the wait operation. In this case, the wait can be performed by <c>RpcMgmtWaitServerListen</c>.
	/// </para>
	/// <para>
	/// Applications must call RpcServerListen with a nonzero value for the DontWait parameter before calling
	/// <c>RpcMgmtWaitServerListen</c>. The <c>RpcMgmtWaitServerListen</c> function returns after the server application calls
	/// RpcMgmtStopServerListening and all active remote procedure calls complete, or after a fatal error occurs in the RPC run-time library.
	/// </para>
	/// <para><c>Note</c><c>RpcMgmtWaitServerListen</c> is a Microsoft extension to the DCE API set.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcmgmtwaitserverlisten RPC_STATUS RpcMgmtWaitServerListen();
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcMgmtWaitServerListen")]
	public static extern Win32Error RpcMgmtWaitServerListen();

	/// <summary>
	/// The <c>RpcServerListen</c> function signals the RPC run-time library to listen for remote procedure calls. This function will
	/// not affect auto-listen interfaces; use RpcServerRegisterIfEx if you need that functionality.
	/// </summary>
	/// <param name="MinimumCallThreads">
	/// Hint to the RPC run time that specifies the minimum number of call threads that should be created and maintained in the given
	/// server. This value is only a hint and is interpreted differently in different versions of Windows. In Windows XP, this value is
	/// the number of previously created threads in each thread pool that the RPC run time creates. An application should specify one
	/// for this parameter, and defer thread creation decisions to the RPC run time.
	/// </param>
	/// <param name="MaxCalls">
	/// <para>
	/// Recommended maximum number of concurrent remote procedure calls the server can execute. To allow efficient performance, the RPC
	/// run-time libraries interpret the MaxCalls parameter as a suggested limit rather than as an absolute upper bound.
	/// </para>
	/// <para>Use RPC_C_LISTEN_MAX_CALLS_DEFAULT to specify the default value.</para>
	/// </param>
	/// <param name="DontWait">
	/// Flag controlling the return from <c>RpcServerListen</c>. A value of nonzero indicates that <c>RpcServerListen</c> should return
	/// immediately after completing function processing. A value of zero indicates that <c>RpcServerListen</c> should not return until
	/// the RpcMgmtStopServerListening function has been called and all remote calls have completed.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_ALREADY_LISTENING</term>
	/// <term>The server is already listening.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_NO_PROTSEQS_REGISTERED</term>
	/// <term>There are no protocol sequences registered.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_MAX_CALLS_TOO_SMALL</term>
	/// <term>The maximum calls value is too small.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server calls <c>RpcServerListen</c> when the server is ready to process remote procedure calls. RPC allows a server to
	/// simultaneously process multiple calls. The MaxCalls parameter recommends the maximum number of concurrent remote procedure calls
	/// the server should execute.
	/// </para>
	/// <para>
	/// The MaxCalls value should not be zero, and should be larger than MinimumCallThreads. Values larger than 0x7FFFFFFF are set to
	/// 0x7FFFFFFF without notice.
	/// </para>
	/// <para>
	/// <c>Windows XP/2000:</c> Setting the MaxCalls parameter to RPC_C_LISTEN_MAX_CALLS_DEFAULT removes the limit on concurrent remote
	/// procedure calls, rather than setting it to the constant-defined value of 1234. Removing the limit on maximum concurrent calls
	/// allows as many concurrent remote procedure calls as the computer can handle. This behavior enables increased efficiency in the
	/// RPC run time.
	/// </para>
	/// <para>
	/// A server application is responsible for concurrency control between the server manager routines because each routine executes in
	/// a separate thread.
	/// </para>
	/// <para>
	/// When the DontWait parameter has a value of zero, the RPC run-time library continues listening for remote procedure calls (that
	/// is, the routine does not return to the server application) until one of the following events occurs:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>One of the server application's manager routines calls RpcMgmtStopServerListening.</term>
	/// </item>
	/// <item>
	/// <term>A client calls a remote procedure provided by the server that directs the server to call RpcMgmtStopServerListening.</term>
	/// </item>
	/// <item>
	/// <term>A client calls RpcMgmtStopServerListening with a binding handle to the server.</term>
	/// </item>
	/// </list>
	/// <para>
	/// After it receives a stop-listening request, the RPC run-time library stops accepting new remote procedure calls for all
	/// registered interfaces. Executing calls are allowed to complete, including callbacks. After all calls complete,
	/// <c>RpcServerListen</c> returns to the caller.
	/// </para>
	/// <para>
	/// When the DontWait parameter has a nonzero value, <c>RpcServerListen</c> returns to the server immediately after processing all
	/// the instructions associated with the function. You can use the RpcMgmtWaitServerListen function to perform the wait operation
	/// usually associated with <c>RpcServerListen</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The Microsoft RPC implementation of <c>RpcServerListen</c> includes two additional parameters that do not appear in
	/// the DCE specification: DontWait and MinimumCallThreads.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserverlisten RPC_STATUS RpcServerListen( unsigned int
	// MinimumCallThreads, unsigned int MaxCalls, unsigned int DontWait );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerListen")]
	public static extern Win32Error RpcServerListen(uint MinimumCallThreads, uint MaxCalls, [MarshalAs(UnmanagedType.Bool)] bool DontWait);

	/// <summary>The <c>RpcServerRegisterAuthInfo</c> function registers authentication information with the RPC run-time library.</summary>
	/// <param name="ServerPrincName">
	/// Pointer to the principal name to use for the server when authenticating remote procedure calls using the service specified by
	/// the AuthnSvc parameter. The content of the name and its syntax are defined by the authentication service in use. For more
	/// information, see Principal Names.
	/// </param>
	/// <param name="AuthnSvc">Authentication service to use when the server receives a request for a remote procedure call.</param>
	/// <param name="GetKeyFn">
	/// <para>Address of a server-application-provided routine that returns encryption keys. See RPC_AUTH_KEY_RETRIEVAL_FN.</para>
	/// <para>
	/// Specify a <c>NULL</c> parameter value to use the default method of encryption-key acquisition. In this case, the authentication
	/// service specifies the default behavior. Set this parameter to <c>NULL</c> when using the RPC_C_AUTHN_WINNT authentication service.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Authentication service</term>
	/// <term>GetKeyFn</term>
	/// <term>Arg</term>
	/// <term>Run-time behavior</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_C_AUTHN_DPA</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_GSS_KERBEROS</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_GSS_NEGOTIATE</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_GSS_SCHANNEL</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_MQ</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_MSN</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_WINNT</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Does not support</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_DCE_PRIVATE</term>
	/// <term>NULL</term>
	/// <term>Non-null</term>
	/// <term>
	/// Uses default method of encryption-key acquisition from specified key table; specified argument is passed to default acquisition function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_DCE_PRIVATE</term>
	/// <term>Non-null</term>
	/// <term>NULL</term>
	/// <term>Uses specified encryption-key acquisition function to obtain keys from default key table.</term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_DCE_PRIVATE</term>
	/// <term>Non-null</term>
	/// <term>Non-null</term>
	/// <term>
	/// Uses specified encryption-key acquisition function to obtain keys from specified key table; specified argument is passed to
	/// acquisition function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RPC_C_AUTHN_DEC_PUBLIC</term>
	/// <term>Ignored</term>
	/// <term>Ignored</term>
	/// <term>Reserved for future use.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The RPC run-time library passes the ServerPrincName parameter value from <c>RpcServerRegisterAuthInfo</c> as the ServerPrincName
	/// parameter value to the GetKeyFn acquisition function. The RPC run-time library automatically provides a value for the key
	/// version (KeyVer) parameter. For a KeyVer parameter value of zero, the acquisition function must return the most recent key
	/// available. The retrieval function returns the authentication key in the Key parameter.
	/// </para>
	/// <para>
	/// If the acquisition function called from <c>RpcServerRegisterAuthInfo</c> returns a status other than RPC_S_OK, then this
	/// function fails and returns an error code to the server application. If the acquisition function called by the RPC run-time
	/// library while authenticating a client's remote procedure call request returns a status other than RPC_S_OK, the request fails
	/// and the RPC run-time library returns an error code to the client application.
	/// </para>
	/// </param>
	/// <param name="Arg">
	/// <para>
	/// Pointer to a parameter to pass to the GetKeyFn routine, if specified. This parameter can also be used to pass a pointer to an
	/// SCHANNEL_CRED structure to specify explicit credentials if the authentication service is set to SCHANNEL.
	/// </para>
	/// <para>
	/// If the Arg parameter is set to <c>NULL</c>, this function will use the default certificate or credential if it has been set up
	/// in the directory service.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_AUTHN_SERVICE</term>
	/// <term>The authentication service is unknown.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server application calls <c>RpcServerRegisterAuthInfo</c> to register an authentication service to use for authenticating
	/// remote procedure calls. A server calls this routine once for each authentication service the server wants to register. If the
	/// server calls this function more than once for a given authentication service, the results are undefined.
	/// </para>
	/// <para>
	/// The authentication service that a client application specifies (using RpcBindingSetAuthInfo or <c>RpcServerRegisterAuthInfo</c>)
	/// must be one of the authentication services specified by the server application. Otherwise, the client's remote procedure call
	/// fails and an RPC_S_UNKNOWN_AUTHN_SERVICE status code is returned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserverregisterauthinfo RPC_STATUS
	// RpcServerRegisterAuthInfo( RPC_CSTR ServerPrincName, unsigned long AuthnSvc, RPC_AUTH_KEY_RETRIEVAL_FN GetKeyFn, void *Arg );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerRegisterAuthInfo")]
	public static extern Win32Error RpcServerRegisterAuthInfo([MarshalAs(UnmanagedType.LPTStr)] string ServerPrincName, RPC_C_AUTHN AuthnSvc,
		[Optional, MarshalAs(UnmanagedType.FunctionPtr)] RPC_AUTH_KEY_RETRIEVAL_FN GetKeyFn, [In, Optional] IntPtr Arg);

	/// <summary>The <c>RpcServerRegisterIfEx</c> function registers an interface with the RPC run-time library.</summary>
	/// <param name="IfSpec">MIDL-generated structure indicating the interface to register.</param>
	/// <param name="MgrTypeUuid">
	/// Pointer to a type UUID to associate with the MgrEpv parameter. Specifying a <c>null</c> parameter value (or a nil UUID)
	/// registers IfSpec with a nil-type UUID.
	/// </param>
	/// <param name="MgrEpv">
	/// Manager routines' entry-point vector (EPV). To use the MIDL-generated default EPV, specify a <c>null</c> value. For more
	/// information, please see RPC_MGR_EPV.
	/// </param>
	/// <param name="Flags">Flags. For a list of flag values, see Interface Registration Flags.</param>
	/// <param name="MaxCalls">
	/// <para>
	/// Maximum number of concurrent remote procedure call requests the server can accept on an auto-listen interface. The MaxCalls
	/// parameters is only applicable on an auto-listen interface, and is ignored on interfaces that are not auto-listen. The RPC
	/// run-time library makes its best effort to ensure the server does not allow more concurrent call requests than the number of
	/// calls specified in MaxCalls. The actual number can be greater and can vary for each protocol sequence.
	/// </para>
	/// <para>
	/// Calls on other interfaces are governed by the value of the process-wide MaxCalls parameter specified in the RpcServerListen
	/// function call.
	/// </para>
	/// <para>
	/// If the number of concurrent calls is not a concern, you can achieve slightly better server-side performance by specifying the
	/// default value using RPC_C_LISTEN_MAX_CALLS_DEFAULT. Doing so relieves the RPC run-time environment from enforcing an unnecessary restriction.
	/// </para>
	/// </param>
	/// <param name="IfCallback">
	/// Security-callback function, or <c>NULL</c> for no callback. Each registered interface can have a different callback function.
	/// See Remarks for more details.
	/// </param>
	/// <returns>
	/// <para>Returns RPC_S_OK upon success.</para>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The parameters and effects of <c>RpcServerRegisterIfEx</c> subsume those of RpcServerRegisterIf. The difference is the ability
	/// to register an auto-listen interface and to specify a security-callback function.
	/// </para>
	/// <para>
	/// The server application code calls <c>RpcServerRegisterIfEx</c> to register an interface. To register an interface, the server
	/// provides the following information:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Interface specification</term>
	/// </item>
	/// <item>
	/// <term>Manager type UUID and manager EPV</term>
	/// </item>
	/// </list>
	/// <para>
	/// Specifying the RPC_IF_AUTOLISTEN flags marks the interface as an auto-listen interface. The run time begins listening for calls
	/// as soon as the interface is registered, and stops listening when the interface is unregistered. A call to RpcServerUnregisterIf
	/// for this interface will wait for the completion of all pending calls on this interface. Calls to RpcServerListen and
	/// RpcMgmtStopServerListening will not affect the interface, nor will a call to RpcServerUnregisterIf with IfSpec == <c>NULL</c>.
	/// This allows a DLL to register RPC interfaces or remove them from the registry without changing the main application's RPC state.
	/// </para>
	/// <para>
	/// Specifying a security-callback function allows the server application to restrict access to its interfaces on a per-client
	/// basis. Remember that, by default, security is optional; the server run time will dispatch unsecured calls even if the server has
	/// called RpcServerRegisterAuthInfo. If the server wants to accept only authenticated clients, an interface callback function must
	/// call the RpcBindingInqAuthClient or RpcGetAuthorizationContextForClient function to retrieve the security level, or attempt to
	/// impersonate the client with RpcImpersonateClient. It can also specify the RPC_IF_ALLOW_SECURE_ONLY flag in the interface flags.
	/// </para>
	/// <para>
	/// When a server application specifies a security-callback function for its interface(s), the RPC run time automatically rejects
	/// unauthenticated calls to that interface. In addition, the run-time records the interfaces that each client has used. When a
	/// client makes an RPC to an interface that it has not used during the current communication session, the RPC run-time library will
	/// call the interface's security-callback function. Specifying RPC_IF_ALLOW_CALLBACKS_WITH_NO_AUTH flag will prevent the automatic
	/// rejection of unauthenticated clients.
	/// </para>
	/// <para>For the signature for the callback function, see RPC_IF_CALLBACK_FN.</para>
	/// <para>
	/// The callback function should return RPC_S_OK if the client is allowed to call methods in this interface. Any other return code
	/// will cause the client to receive the exception RPC_S_ACCESS_DENIED.
	/// </para>
	/// <para>
	/// In some cases, the RPC run time may call the security-callback function more than once per client–per interface. Be sure your
	/// callback function can handle this possibility.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserverregisterifex RPC_STATUS RpcServerRegisterIfEx(
	// RPC_IF_HANDLE IfSpec, UUID *MgrTypeUuid, RPC_MGR_EPV *MgrEpv, unsigned int Flags, unsigned int MaxCalls, RPC_IF_CALLBACK_FN
	// *IfCallback );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerRegisterIfEx")]
	public static extern Win32Error RpcServerRegisterIfEx(RPC_IF_HANDLE IfSpec, in Guid MgrTypeUuid, [In] IntPtr MgrEpv, RPC_IF Flags, uint MaxCalls,
		[Optional, MarshalAs(UnmanagedType.FunctionPtr)] RPC_IF_CALLBACK_FN? IfCallback);

	/// <summary>The <c>RpcServerUnregisterIf</c> function removes an interface from the RPC run-time library registry.</summary>
	/// <param name="IfSpec">
	/// <para>Interface to remove from the registry.</para>
	/// <para>
	/// Specify a <c>null</c> value to remove all interfaces previously registered with the type UUID value specified in the MgrTypeUuid parameter.
	/// </para>
	/// </param>
	/// <param name="MgrTypeUuid">
	/// <para>
	/// Pointer to the type UUID of the manager entry-point vector (EPV) to remove from the registry. The value of MgrTypeUuid should be
	/// the same value as was provided in a call to the RpcServerRegisterIf function, RpcServerRegisterIf2 function, or the
	/// RpcServerRegisterIfEx function.
	/// </para>
	/// <para>
	/// Specify a <c>null</c> value to remove the interface specified in the IfSpec parameter for all previously registered type UUIDs
	/// from the registry.
	/// </para>
	/// <para>
	/// Specify a nil UUID to remove the MIDL-generated default manager EPV from the registry. In this case, all manager EPVs registered
	/// with a non-nil type UUID remain registered.
	/// </para>
	/// </param>
	/// <param name="WaitForCallsToComplete">
	/// <para>
	/// Flag that indicates whether to remove the interface from the registry immediately or to wait until all current calls are complete.
	/// </para>
	/// <para>
	/// Specify a value of zero to disregard calls in progress and remove the interface from the registry immediately. Specify any
	/// nonzero value to wait until all active calls complete.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_MGR_TYPE</term>
	/// <term>The manager type is unknown.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_IF</term>
	/// <term>The interface is unknown.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server calls <c>RpcServerUnregisterIf</c> to remove the association between an interface and a manager EPV. To specify the
	/// manager EPV to remove in the MgrTypeUuid parameter, provide the type UUID value that was specified in a call to
	/// RpcServerRegisterIf. After it is removed from the registry, an interface is no longer available to client applications.
	/// </para>
	/// <para>
	/// When an interface is removed from the registry, the RPC run-time library stops accepting new calls for that interface. Calls
	/// that are currently executing on the interface are allowed to complete, including callbacks.
	/// </para>
	/// <para>The following table summarizes the behavior of <c>RpcServerUnregisterIf</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IfSpec</term>
	/// <term>MgrTypeUuid</term>
	/// <term>Behavior</term>
	/// </listheader>
	/// <item>
	/// <term>Non-null</term>
	/// <term>Non-null</term>
	/// <term>Removes from the registry the manager EPV associated with the specified parameters.</term>
	/// </item>
	/// <item>
	/// <term>Non-null</term>
	/// <term>NULL</term>
	/// <term>Removes all manager EPVs associated with the IfSpec parameter.</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>Non-null</term>
	/// <term>Removes all manager EPVs associated with the MgrTypeUuid parameter.</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>
	/// Removes all manager EPVs. This call has the effect of preventing the server from receiving any new remote procedure calls
	/// because all the manager EPVs for all interfaces have been unregistered.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If the value of IfSpec is <c>NULL</c>, this function will leave auto-listen interfaces registered. Auto-listen
	/// interfaces must be removed from the registry individually. See RpcServerRegisterIfEx for more details.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserverunregisterif RPC_STATUS RpcServerUnregisterIf(
	// RPC_IF_HANDLE IfSpec, UUID *MgrTypeUuid, unsigned int WaitForCallsToComplete );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerUnregisterIf")]
	public static extern Win32Error RpcServerUnregisterIf([In, Optional] RPC_IF_HANDLE IfSpec, in Guid MgrTypeUuid, [MarshalAs(UnmanagedType.Bool)] bool WaitForCallsToComplete);

	/// <summary>The <c>RpcServerUnregisterIf</c> function removes an interface from the RPC run-time library registry.</summary>
	/// <param name="IfSpec">
	/// <para>Interface to remove from the registry.</para>
	/// <para>
	/// Specify a <c>null</c> value to remove all interfaces previously registered with the type UUID value specified in the MgrTypeUuid parameter.
	/// </para>
	/// </param>
	/// <param name="MgrTypeUuid">
	/// <para>
	/// Pointer to the type UUID of the manager entry-point vector (EPV) to remove from the registry. The value of MgrTypeUuid should be
	/// the same value as was provided in a call to the RpcServerRegisterIf function, RpcServerRegisterIf2 function, or the
	/// RpcServerRegisterIfEx function.
	/// </para>
	/// <para>
	/// Specify a <c>null</c> value to remove the interface specified in the IfSpec parameter for all previously registered type UUIDs
	/// from the registry.
	/// </para>
	/// <para>
	/// Specify a nil UUID to remove the MIDL-generated default manager EPV from the registry. In this case, all manager EPVs registered
	/// with a non-nil type UUID remain registered.
	/// </para>
	/// </param>
	/// <param name="WaitForCallsToComplete">
	/// <para>
	/// Flag that indicates whether to remove the interface from the registry immediately or to wait until all current calls are complete.
	/// </para>
	/// <para>
	/// Specify a value of zero to disregard calls in progress and remove the interface from the registry immediately. Specify any
	/// nonzero value to wait until all active calls complete.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_MGR_TYPE</term>
	/// <term>The manager type is unknown.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_UNKNOWN_IF</term>
	/// <term>The interface is unknown.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server calls <c>RpcServerUnregisterIf</c> to remove the association between an interface and a manager EPV. To specify the
	/// manager EPV to remove in the MgrTypeUuid parameter, provide the type UUID value that was specified in a call to
	/// RpcServerRegisterIf. After it is removed from the registry, an interface is no longer available to client applications.
	/// </para>
	/// <para>
	/// When an interface is removed from the registry, the RPC run-time library stops accepting new calls for that interface. Calls
	/// that are currently executing on the interface are allowed to complete, including callbacks.
	/// </para>
	/// <para>The following table summarizes the behavior of <c>RpcServerUnregisterIf</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IfSpec</term>
	/// <term>MgrTypeUuid</term>
	/// <term>Behavior</term>
	/// </listheader>
	/// <item>
	/// <term>Non-null</term>
	/// <term>Non-null</term>
	/// <term>Removes from the registry the manager EPV associated with the specified parameters.</term>
	/// </item>
	/// <item>
	/// <term>Non-null</term>
	/// <term>NULL</term>
	/// <term>Removes all manager EPVs associated with the IfSpec parameter.</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>Non-null</term>
	/// <term>Removes all manager EPVs associated with the MgrTypeUuid parameter.</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>
	/// Removes all manager EPVs. This call has the effect of preventing the server from receiving any new remote procedure calls
	/// because all the manager EPVs for all interfaces have been unregistered.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If the value of IfSpec is <c>NULL</c>, this function will leave auto-listen interfaces registered. Auto-listen
	/// interfaces must be removed from the registry individually. See RpcServerRegisterIfEx for more details.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserverunregisterif RPC_STATUS RpcServerUnregisterIf(
	// RPC_IF_HANDLE IfSpec, UUID *MgrTypeUuid, unsigned int WaitForCallsToComplete );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerUnregisterIf")]
	public static extern Win32Error RpcServerUnregisterIf([In, Optional] RPC_IF_HANDLE IfSpec, [In, Optional] IntPtr MgrTypeUuid, [MarshalAs(UnmanagedType.Bool)] bool WaitForCallsToComplete);

	/// <summary>
	/// The <c>RpcServerUseProtseqEp</c> function tells the RPC run-time library to use the specified protocol sequence combined with
	/// the specified endpoint for receiving remote procedure calls.
	/// </summary>
	/// <param name="Protseq">Pointer to a string identifier of the protocol sequence to register with the RPC run-time library.</param>
	/// <param name="MaxCalls">
	/// Backlog queue length for the <c>ncacn_ip_tcp</c> protocol sequence. All other protocol sequences ignore this parameter. Use
	/// RPC_C_PROTSEQ_MAX_REQS_DEFAULT to specify the default value. See Remarks.
	/// </param>
	/// <param name="Endpoint">
	/// Pointer to the endpoint-address information to use in creating a binding for the protocol sequence specified in the Protseq parameter.
	/// </param>
	/// <param name="SecurityDescriptor">
	/// Pointer to an optional parameter provided for the security subsystem. Used only for <c>ncacn_np</c> and <c>ncalrpc</c> protocol
	/// sequences. All other protocol sequences ignore this parameter. Using a security descriptor on the endpoint in order to make a
	/// server secure is not recommended. This parameter does not appear in the DCE specification for this API.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_PROTSEQ_NOT_SUPPORTED</term>
	/// <term>The protocol sequence is not supported on this host.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_RPC_PROTSEQ</term>
	/// <term>The protocol sequence is invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_ENDPOINT_FORMAT</term>
	/// <term>The endpoint format is invalid.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_OUT_OF_MEMORY</term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_DUPLICATE_ENDPOINT</term>
	/// <term>The endpoint is a duplicate.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_SECURITY_DESC</term>
	/// <term>The security descriptor is invalid.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A server application calls <c>RpcServerUseProtseqEp</c> to register one protocol sequence with the RPC run-time library. With
	/// each protocol sequence registration, <c>RpcServerUseProtseqEp</c> includes the specified endpoint-address information.
	/// </para>
	/// <para>
	/// To receive remote procedure call requests, a server must register at least one protocol sequence with the RPC run-time library.
	/// A server application can call this routine multiple times to register additional protocol sequences and endpoints. For each
	/// protocol sequence registered by a server, the RPC run-time library creates one or more endpoints through which the server
	/// receives remote procedure call requests. The RPC run-time library creates different endpoints for each protocol sequence.
	/// However, each interface in the process is accessible through any endpoint. For more information, see Writing a Secure RPC Client
	/// or Server.
	/// </para>
	/// <para>
	/// For MaxCalls, the value provided by the application is only a hint. The RPC run time or the Windows Sockets provider may
	/// override the value. For example, on Windows XP or Windows 2000 Professional, the value is limited to 5. Values greater than 5
	/// are ignored and 5 is used instead. On Windows Server 2003 and Windows 2000 Server, the value will be honored.
	/// </para>
	/// <para>
	/// Applications must be careful to pass reasonable values in MaxCalls. Large values on Server, Advanced Server, or Datacenter
	/// Server can cause a large amount of non-paged pool memory to be used. Using too small a value is also unfavorable, as it may
	/// result in TCP SYN packets being met by TCP RST from the server if the backlog queue gets exhausted. An application developer
	/// should balance memory footprint versus scalability requirements when determining the proper value for MaxCalls.
	/// </para>
	/// <para>
	/// When the computer is configured to use selective binding, successful return does not guarantee that the server has created
	/// endpoints for all the network interfaces present on the computer. The RPC run-time may not listen on some network interfaces
	/// depending on the selective binding settings. In addition, if an interface has not yet received an IP address using DHCP, the RPC
	/// server does not listen on the network interface until a DHCP address is assigned to it. A successful return implies that the
	/// server is listening on at least one network interface; the full list of the binding handles over which remote procedure calls
	/// can be received can be obtained with a call to the RpcServerInqBindings function.
	/// </para>
	/// <para>For more information, see Server-Side Binding and String Binding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcserveruseprotseqep RPC_STATUS RpcServerUseProtseqEp(
	// RPC_CSTR Protseq, unsigned int MaxCalls, RPC_CSTR Endpoint, void *SecurityDescriptor );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcServerUseProtseqEp")]
	public static extern Win32Error RpcServerUseProtseqEp([MarshalAs(UnmanagedType.LPTStr)] string Protseq, uint MaxCalls,
		[MarshalAs(UnmanagedType.LPTStr)] string Endpoint, IntPtr SecurityDescriptor);

	/// <summary>The <c>RpcStringBindingCompose</c> function creates a string binding handle.</summary>
	/// <param name="ObjUuid">
	/// Pointer to a <c>null</c>-terminated string representation of an object UUID. For example, the string
	/// 6B29FC40-CA47-1067-B31D-00DD010662DA represents a valid UUID.
	/// </param>
	/// <param name="ProtSeq">Pointer to a <c>null</c>-terminated string representation of a protocol sequence. See Note.</param>
	/// <param name="NetworkAddr">
	/// Pointer to a <c>null</c>-terminated string representation of a network address. The network-address format is associated with
	/// the protocol sequence. See Note.
	/// </param>
	/// <param name="Endpoint">
	/// Pointer to a <c>null</c>-terminated string representation of an endpoint. The endpoint format and content are associated with
	/// the protocol sequence. For example, the endpoint associated with the protocol sequence <c>ncacn_np</c> is a pipe name in the
	/// format \pipe\pipename. See Note.
	/// </param>
	/// <param name="Options">
	/// Pointer to a <c>null</c>-terminated string representation of network options. The option string is associated with the protocol
	/// sequence. See Note.
	/// </param>
	/// <param name="StringBinding">
	/// <para>Returns a pointer to a pointer to a <c>null</c>-terminated string representation of a binding handle.</para>
	/// <para>
	/// Specify a <c>NULL</c> value to prevent <c>RpcStringBindingCompose</c> from returning the StringBinding parameter. In this case,
	/// the application does not call RpcStringFree. See Note.
	/// </para>
	/// <para><c>Note</c> For more information, see String Binding.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// <item>
	/// <term>RPC_S_INVALID_STRING_UUID</term>
	/// <term>The string representation of the UUID is not valid.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application calls <c>RpcStringBindingCompose</c> routine to combine an object UUID, a protocol sequence, a network address,
	/// an endpoint and other network options into a string representation of a binding handle.
	/// </para>
	/// <para>
	/// The RPC run-time library allocates memory for the string returned in the StringBinding parameter. The application is responsible
	/// for calling RpcStringFree to deallocate that memory.
	/// </para>
	/// <para>Specify a <c>null</c> parameter value or provide an empty string (\0) for each input string that has no data.</para>
	/// <para>
	/// Literal backslash characters within C-language strings must be quoted. The actual C string for the server name for the
	/// <c>ncacn_np</c> protocol sequence appears as \\servername, and the actual C string for a pipe name appears as \pipe\pipename.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcstringbindingcompose RPC_STATUS RpcStringBindingCompose(
	// RPC_CSTR ObjUuid, RPC_CSTR ProtSeq, RPC_CSTR NetworkAddr, RPC_CSTR Endpoint, RPC_CSTR Options, RPC_CSTR *StringBinding );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcStringBindingCompose")]
	public static extern Win32Error RpcStringBindingCompose([Optional, MarshalAs(UnmanagedType.LPTStr)] string? ObjUuid,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? ProtSeq, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? NetworkAddr,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? Endpoint, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Options,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(RpcStringMarshaler))] out string StringBinding);

	/// <summary>The <c>RpcStringFree</c> function frees a character string allocated by the RPC run-time library.</summary>
	/// <param name="String">Pointer to a pointer to the character string to free.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RPC_S_OK</term>
	/// <term>The call succeeded.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
	/// </returns>
	/// <remarks>
	/// An application is responsible for calling <c>RpcStringFree</c> once for each character string allocated and returned by calls to
	/// other RPC run-time library routines.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcdce/nf-rpcdce-rpcstringfree RPC_STATUS RpcStringFree( RPC_CSTR *String );
	[DllImport(Lib_rpcrt4, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("rpcdce.h", MSDNShortId = "NF:rpcdce.RpcStringFree")]
	public static extern Win32Error RpcStringFree(ref IntPtr String);

	internal class RpcStringMarshaler : ICustomMarshaler
	{
		public void CleanUpManagedData(object ManagedObj) => throw new NotImplementedException();

		public void CleanUpNativeData(IntPtr pNativeData) => RpcStringFree(ref pNativeData);

		public int GetNativeDataSize() => IntPtr.Size;

		public IntPtr MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		public object MarshalNativeToManaged(IntPtr pNativeData) => StringHelper.GetString(pNativeData) ?? "";
	}

	/* TODO: Add these RPC functions
	 * 
	RpcBindingSetObject
	RpcBindingSetOption
	RpcBindingToStringBinding
	RpcBindingVectorFree
	RpcCancelThread
	RpcCancelThreadEx
	RpcEpRegister
	RpcEpRegisterNoReplace
	RpcEpResolveBinding
	RpcEpUnregister
	RpcExceptionFilter
	RpcIfIdVectorFree
	RpcIfInqId
	RpcImpersonateClient
	RpcImpersonateClientContainer
	RpcMgmtEnableIdleCleanup
	RpcMgmtEpEltInqBegin
	RpcMgmtEpEltInqDone
	RpcMgmtEpEltInqNext
	RpcMgmtEpUnregister
	RpcMgmtInqComTimeout
	RpcMgmtInqDefaultProtectLevel
	RpcMgmtInqIfIds
	RpcMgmtInqServerPrincName
	RpcMgmtInqStats
	RpcMgmtIsServerListening
	RpcMgmtSetAuthorizationFn
	RpcMgmtSetCancelTimeout
	RpcMgmtSetComTimeout
	RpcMgmtSetServerStackSize
	RpcMgmtStatsVectorFree
	RpcNetworkInqProtseqs
	RpcNetworkIsProtseqValid
	RpcNsBindingInqEntryName
	RpcObjectInqType
	RpcObjectSetInqFn
	RpcObjectSetType
	RpcProtseqVectorFree
	RpcRaiseException
	RpcRevertContainerImpersonation
	RpcRevertToSelf
	RpcRevertToSelfEx
	RpcServerCompleteSecurityCallback
	RpcServerInqBindingHandle
	RpcServerInqBindings
	RpcServerInqDefaultPrincName
	RpcServerInqIf
	RpcServerInterfaceGroupActivate
	RpcServerInterfaceGroupClose
	RpcServerInterfaceGroupCreate
	RpcServerInterfaceGroupDeactivate
	RpcServerInterfaceGroupInqBindings
	RpcServerRegisterIf
	RpcServerRegisterIf2
	RpcServerRegisterIf3
	RpcServerTestCancel
	RpcServerUnregisterIfEx
	RpcServerUseAllProtseqs
	RpcServerUseAllProtseqsEx
	RpcServerUseAllProtseqsIf
	RpcServerUseAllProtseqsIfEx
	RpcServerUseProtseq
	RpcServerUseProtseqEpEx
	RpcServerUseProtseqEx
	RpcServerUseProtseqIf
	RpcServerUseProtseqIfEx
	RpcSsDontSerializeContext
	RpcStringBindingParse
	RpcTestCancel
	UuidCompare
	UuidCreate
	UuidCreateNil
	UuidCreateSequential
	UuidEqual
	UuidFromString
	UuidHash
	UuidIsNil
	UuidToString
	*/
}