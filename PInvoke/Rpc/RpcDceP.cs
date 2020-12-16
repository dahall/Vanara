using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the Rpc.dll</summary>
	public static partial class Rpc
	{
		/// <summary>Dispatch function delegate.</summary>
		/// <param name="Message">The message.</param>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void RPC_DISPATCH_FUNCTION(ref RPC_MESSAGE Message);

		/// <summary>
		/// <para>
		/// [The <c>I_RpcBindingInqLocalClientPID</c> function is available for use in the operating systems specified in the Requirements
		/// section. Instead, call RpcServerInqCallAttributes.]
		/// </para>
		/// <para>The <c>I_RpcBindingInqLocalClientPID</c> function obtains a client process ID.</para>
		/// </summary>
		/// <param name="Binding">
		/// <c>RPC_BINDING_HANDLE</c> that specifies the binding handle for an explicit RPC binding from the client to a server application.
		/// </param>
		/// <param name="Pid">Contains the process ID of the client that issued the call upon return.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RPC_S_OK</term>
		/// <term>The function call was successful.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_NO_CALL_ACTIVE</term>
		/// <term>The current thread does not have an active RPC call.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_INVALID_BINDING</term>
		/// <term>The RPC binding handle is invalid.</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> For a list of valid error codes, see RPC Return Values.</para>
		/// </returns>
		/// <remarks>
		/// The client process ID is only returned in ClientBinding when the "ncalrpc" protocol sequence is used. Until the process
		/// terminates, the process ID value uniquely identifies it on the client. When the process terminates, the process ID can be used
		/// by new processes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/rpcdcep/nf-rpcdcep-i_rpcbindinginqlocalclientpid RPC_STATUS
		// I_RpcBindingInqLocalClientPID( RPC_BINDING_HANDLE Binding, unsigned long *Pid );
		[DllImport(Lib_rpcrt4, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("rpcdcep.h", MSDNShortId = "NF:rpcdcep.I_RpcBindingInqLocalClientPID")]
		public static extern Win32Error I_RpcBindingInqLocalClientPID(RPC_BINDING_HANDLE Binding, out uint Pid);

		/// <summary>
		/// <para>
		/// The <c>RPC_CLIENT_INTERFACE</c> structure is part of the private interface between the run-time libraries and the stubs. Most
		/// distributed applications that use Microsoft RPC do not need this structure.
		/// </para>
		/// <para>The data structure is defined in the header file Rpcdcep.h. See the header file for syntax block and member definitions.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/rpcdcep/ns-rpcdcep-rpc_client_interface typedef struct _RPC_CLIENT_INTERFACE {
		// unsigned int Length; RPC_SYNTAX_IDENTIFIER InterfaceId; RPC_SYNTAX_IDENTIFIER TransferSyntax; PRPC_DISPATCH_TABLE DispatchTable;
		// unsigned int RpcProtseqEndpointCount; PRPC_PROTSEQ_ENDPOINT RpcProtseqEndpoint; ULONG_PTR Reserved; void const *InterpreterInfo;
		// unsigned int Flags; } RPC_CLIENT_INTERFACE, *PRPC_CLIENT_INTERFACE;
		[PInvokeData("rpcdcep.h", MSDNShortId = "NS:rpcdcep._RPC_CLIENT_INTERFACE")]
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct RPC_CLIENT_INTERFACE
		{
			/// <summary/>
			public uint Length;

			/// <summary/>
			public RPC_SYNTAX_IDENTIFIER InterfaceId;

			/// <summary/>
			public RPC_SYNTAX_IDENTIFIER TransferSyntax;

			/// <summary/>
			public RPC_DISPATCH_TABLE* DispatchTable;

			/// <summary/>
			public uint RpcProtseqEndpointCount;

			/// <summary/>
			public RPC_PROTSEQ_ENDPOINT* RpcProtseqEndpoint;

			/// <summary/>
			public UIntPtr Reserved;

			/// <summary/>
			public IntPtr InterpreterInfo;

			/// <summary/>
			public uint Flags;
		}

		/// <summary>
		/// <para>
		/// The <c>RPC_DISPATCH_TABLE</c> structure is part of the private interface between the run-time libraries and the stubs. Most
		/// distributed applications that use Microsoft RPC do not need this structure.
		/// </para>
		/// <para>The structure is defined in the header file Rpcdcep.h. See the header file for syntax block and member definitions.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/rpcdcep/ns-rpcdcep-rpc_dispatch_table typedef struct { unsigned int
		// DispatchTableCount; RPC_DISPATCH_FUNCTION *DispatchTable; LONG_PTR Reserved; } RPC_DISPATCH_TABLE, *PRPC_DISPATCH_TABLE;
		[PInvokeData("rpcdcep.h", MSDNShortId = "NS:rpcdcep.__unnamed_struct_0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_DISPATCH_TABLE
		{
			/// <summary/>
			public uint DispatchTableCount;

			/// <summary/>
			public IntPtr DispatchTable;

			/// <summary/>
			public IntPtr Reserved;

			/// <summary/>
			public IntPtr[] GetDispatchTable() => DispatchTable.ToArray<IntPtr>((int)DispatchTableCount);
		}

		/// <summary>The <c>RPC_MESSAGE</c> structure contains information shared between NDR and the rest of the RPC or OLE runtime.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/rpcdcep/ns-rpcdcep-rpc_message typedef struct _RPC_MESSAGE {
		// RPC_BINDING_HANDLE Handle; unsigned long DataRepresentation; void *Buffer; unsigned int BufferLength; unsigned int ProcNum;
		// PRPC_SYNTAX_IDENTIFIER TransferSyntax; void *RpcInterfaceInformation; void *ReservedForRuntime; RPC_MGR_EPV *ManagerEpv; void
		// *ImportContext; unsigned long RpcFlags; } RPC_MESSAGE, *PRPC_MESSAGE;
		[PInvokeData("rpcdcep.h", MSDNShortId = "NS:rpcdcep._RPC_MESSAGE")]
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct RPC_MESSAGE
		{
			/// <summary>Reserved.</summary>
			public RPC_BINDING_HANDLE Handle;

			/// <summary>Data representation of the network buffer as defined by the NDR specification.</summary>
			public uint DataRepresentation;

			/// <summary>Pointer to the beginning of the network buffer.</summary>
			public IntPtr Buffer;

			/// <summary>Size, in bytes, of <c>Buffer</c>.</summary>
			public uint BufferLength;

			/// <summary>Reserved.</summary>
			public uint ProcNum;

			/// <summary>Reserved.</summary>
			public RPC_SYNTAX_IDENTIFIER* TransferSyntax;

			/// <summary>Reserved.</summary>
			public IntPtr RpcInterfaceInformation;

			/// <summary>Reserved.</summary>
			public IntPtr ReservedForRuntime;

			/// <summary>Reserved.</summary>
			public IntPtr ManagerEpv;

			/// <summary>Reserved.</summary>
			public IntPtr ImportContext;

			/// <summary>Reserved.</summary>
			public uint RpcFlags;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_PROTSEQ_ENDPOINT
		{
			/// <summary/>
			public StrPtrAnsi RpcProtocolSequence;

			/// <summary/>
			public StrPtrAnsi Endpoint;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct RPC_SERVER_INTERFACE
		{
			/// <summary/>
			public uint Length;

			/// <summary/>
			public RPC_SYNTAX_IDENTIFIER InterfaceId;

			/// <summary/>
			public RPC_SYNTAX_IDENTIFIER TransferSyntax;

			/// <summary/>
			public RPC_DISPATCH_TABLE* DispatchTable;

			/// <summary/>
			public uint RpcProtseqEndpointCount;

			/// <summary/>
			public RPC_PROTSEQ_ENDPOINT* RpcProtseqEndpoint;

			/// <summary/>
			public IntPtr DefaultManagerEpv;

			/// <summary/>
			public IntPtr InterpreterInfo;

			/// <summary/>
			public uint Flags;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_SYNTAX_IDENTIFIER
		{
			/// <summary/>
			public Guid SyntaxGUID;

			/// <summary/>
			public RPC_VERSION SyntaxVersion;

			/// <summary>Initializes a new instance of the <see cref="RPC_SYNTAX_IDENTIFIER"/> struct.</summary>
			/// <param name="syntax">The syntax.</param>
			/// <param name="majVer">The maj ver.</param>
			/// <param name="minVer">The minimum ver.</param>
			public RPC_SYNTAX_IDENTIFIER(in Guid syntax, ushort majVer, ushort minVer = 0)
			{
				SyntaxGUID = syntax;
				SyntaxVersion = new RPC_VERSION { MajorVersion = majVer, MinorVersion = minVer };
			}
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct RPC_VERSION
		{
			/// <summary/>
			public ushort MajorVersion;

			/// <summary/>
			public ushort MinorVersion;
		}
	}
}