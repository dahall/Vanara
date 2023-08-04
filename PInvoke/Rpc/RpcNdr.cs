namespace Vanara.PInvoke;

/// <summary>Items from the Rpc.dll</summary>
public static partial class Rpc
{
	/// <summary/>
	/// <returns/>
	public unsafe delegate int SERVER_ROUTINE();

	/// <summary>The <c>NdrClientCall2</c> function is the client-side entry point for the /Oicf mode stub.</summary>
	/// <param name="pStubDescriptor">
	/// Pointer to the MIDL-generated MIDL_STUB_DESC structure that contains information about the description of the remote interface.
	/// </param>
	/// <param name="pFormat">Pointer to the MIDL-generated procedure format string that describes the method and parameters.</param>
	/// <param name="pArguments">Pointer to the client-side calling stack.</param>
	/// <returns>
	/// <para>
	/// Return value of the remote call. The maximum size of a return value is equivalent to the register size of the system. MIDL
	/// switches to the /Os mode stub if the return value size is larger than the register size.
	/// </para>
	/// <para>Depending on the method definition, this function can throw an exception if there is a network or server failure.</para>
	/// </returns>
	/// <remarks>
	/// The <c>NdrClientCall2</c> function is used by all /Oicf mode client-side stubs. The <c>NdrClientCall2</c> function transmits all
	/// [in] data to the remote server, and upon receipt of the response packet, returns the [out] value to the client-side application.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcndr/nf-rpcndr-ndrclientcall2 CLIENT_CALL_RETURN RPC_VAR_ENTRY
	// NdrClientCall2( PMIDL_STUB_DESC pStubDescriptor, PFORMAT_STRING pFormat, ... );
	[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("rpcndr.h", MSDNShortId = "NF:rpcndr.NdrClientCall2")]
	public static extern IntPtr NdrClientCall2(/*PMIDL_STUB_DESC*/ IntPtr pStubDescriptor, /*PFORMAT_STRING*/ IntPtr pFormat, IntPtr pArguments);

	/// <summary>Converts a value to a four-byte array.</summary>
	/// <param name="s">The value.</param>
	/// <returns>The byte array.</returns>
	public static byte[] NdrFcLong(int s) => new[] { (byte)(s & 0xff), (byte)((s & 0x0000ff00) >> 8), (byte)((s & 0x00ff0000) >> 16), (byte)(s >> 24) };

	/// <summary>Converts a value to a two-byte array.</summary>
	/// <param name="s">The value.</param>
	/// <returns>The byte array.</returns>
	public static byte[] NdrFcShort(int s) => new[] { (byte)(s & 0xff), (byte)(s >> 8) };

	/// <summary/>
	[PInvokeData("rpcndr.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDL_SERVER_INFO
	{
		/// <summary/>
		public IntPtr /* PMIDL_STUB_DESC        */ pStubDesc;

		/// <summary/>
		public IntPtr /* const SERVER_ROUTINE*  */ DispatchTable;

		/// <summary/>
		public IntPtr /* PFORMAT_STRING         */ ProcString;

		/// <summary/>
		public IntPtr /* const unsigned short*  */ FmtStringOffset;

		/// <summary/>
		public IntPtr /* const STUB_THUNK*      */ ThunkTable;

		/// <summary/>
		public IntPtr /* PRPC_SYNTAX_IDENTIFIER */ pTransferSyntax;

		/// <summary/>
		public IntPtr /* ULONG_PTR              */ nCount;

		/// <summary/>
		public IntPtr /* PMIDL_SYNTAX_INFO      */ pSyntaxInfo;
	}

	/// <summary>
	/// The <c>MIDL_STUB_DESC</c> structure is a MIDL-generated structure that contains information about the interface stub regarding
	/// RPC calls between the client and server.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/rpcndr/ns-rpcndr-midl_stub_desc typedef struct _MIDL_STUB_DESC { void
	// *RpcInterfaceInformation; void * )(size_t) *(pfnAllocate; void()(void *) * pfnFree; union { handle_t *pAutoHandle; handle_t
	// *pPrimitiveHandle; PGENERIC_BINDING_INFO pGenericBindingInfo; } IMPLICIT_HANDLE_INFO; const NDR_RUNDOWN *apfnNdrRundownRoutines;
	// const GENERIC_BINDING_ROUTINE_PAIR *aGenericBindingRoutinePairs; const EXPR_EVAL *apfnExprEval; const XMIT_ROUTINE_QUINTUPLE
	// *aXmitQuintuple; const unsigned char *pFormatTypes; int fCheckBounds; unsigned long Version; MALLOC_FREE_STRUCT
	// *pMallocFreeStruct; long MIDLVersion; const COMM_FAULT_OFFSETS *CommFaultOffsets; const USER_MARSHAL_ROUTINE_QUADRUPLE
	// *aUserMarshalQuadruple; const NDR_NOTIFY_ROUTINE *NotifyRoutineTable; ULONG_PTR mFlags; const NDR_CS_ROUTINES *CsRoutineTables;
	// void *ProxyServerInfo; const NDR_EXPR_DESC *pExprInfo; } MIDL_STUB_DESC;
	[PInvokeData("rpcndr.h", MSDNShortId = "NS:rpcndr._MIDL_STUB_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MIDL_STUB_DESC
	{
		/// <summary>
		/// For a nonobject RPC interface on the server-side, it points to an RPC server interface structure. On the client-side, it
		/// points to an RPC client interface structure. It is null for an object interface.
		/// </summary>
		public IntPtr RpcInterfaceInformation;

		/// <summary>
		/// Memory allocation function to be used by the stub. Set to midl_user_allocate for nonobject interface and NdrOleAllocate for
		/// object interface.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public Func<SizeT, IntPtr> pfnAllocate;

		/// <summary>
		/// Memory-free function to be used by the stub. Set to midl_user_free for nonobject interface and NdrOleFree for object interface.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public Action<IntPtr> pfnFree;

		/// <summary>
		/// <para>The union contains one of the following handles.</para>
		/// <list type="bullet">
		/// <item>Pointer to the implicit auto handle for the RPC call.</item>
		/// <item>Pointer to the implicit primitive handle for the RPC call.</item>
		/// <item>Pointer to the information about the implicit generic handle.</item>
		/// </list>
		/// </summary>
		public IntPtr pImplicitHandleInfo;

		/// <summary>Array of context handle rundown functions.</summary>
		public IntPtr apfnNdrRundownRoutines;

		/// <summary>Array of function pointers to bind and unbind function pairs for the implicit generic handle.</summary>
		public IntPtr aGenericBindingRoutinePairs;

		/// <summary>
		/// Array of function pointers to expression evaluator functions used to evaluate MIDL complex conformance and varying
		/// descriptions. For example, size_is(param1 + param2).
		/// </summary>
		public IntPtr apfnExprEval;

		/// <summary>Array of an array of function pointers for user-defined transmit_as and represent_as types.</summary>
		public IntPtr aXmitQuintuple;

		/// <summary>Pointer to the type format description.</summary>
		public IntPtr pFormatTypes;

		/// <summary>Flag describing the user-specified /error MIDL compiler option.</summary>
		public int fCheckBounds;

		/// <summary>NDR version required for the stub.</summary>
		public uint Version;

		/// <summary>
		/// Pointer to the MALLOC_FREE_STRUCT structure which contains the allocate and free function pointers. Use if the
		/// enable_allocate MIDL attribute is specified.
		/// </summary>
		public IntPtr pMallocFreeStruct;

		/// <summary>Version of the MIDL compiler used to compile the .idl file.</summary>
		public long MIDLVersion;

		/// <summary>Array of stack offsets for parameters with comm_status or fault_status attributes.</summary>
		public IntPtr CommFaultOffsets;

		/// <summary>Array of an array of function pointers for user-defined user_marshal and wire_marshal types.</summary>
		public IntPtr aUserMarshalQuadruple;

		/// <summary>Array of notification function pointers for methods with the notify or notify_flag attribute specified.</summary>
		public IntPtr NotifyRoutineTable;

		/// <summary>
		/// <para>Flag describing the attributes of the stub</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPCFLG_HAS_MULTI_SYNTAXES</term>
		/// <term>Set if the stub supports multiple transfer syntaxes.</term>
		/// </item>
		/// <item>
		/// <term>RPCFLG_HAS_CALLBACK</term>
		/// <term>Set if the interface contains callback functions.</term>
		/// </item>
		/// <item>
		/// <term>RPC_INTERFACE_HAS_PIPES</term>
		/// <term>Set if the interface contains a method that uses pipes.</term>
		/// </item>
		/// </list>
		/// </summary>
		public UIntPtr mFlags;

		/// <summary>Unused.</summary>
		public IntPtr CsRoutineTables;

		/// <summary/>
		public IntPtr ProxyServerInfo;

		/// <summary/>
		public IntPtr pExprInfo;
	}
}