﻿using System.Threading;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Does not wait for the named pipe. If the named pipe is not available, the function returns an error.</summary>
	public const uint NMPWAIT_NOWAIT = 0x00000001;

	/// <summary>The time-out interval is the default value specified by the server process in the CreateNamedPipe function.</summary>
	public const uint NMPWAIT_USE_DEFAULT_WAIT = 0x00000000;

	/// <summary>The function does not return until an instance of the named pipe is available.</summary>
	public const uint NMPWAIT_WAIT_FOREVER = 0xffffffff;

	/// <summary>Values that can be used in the dwOpenMode parameter of <see cref="CreateNamedPipe"/>.</summary>
	[Flags]
	public enum PIPE_ACCESS : uint
	{
		/// <summary>
		/// The pipe is bi-directional; both server and client processes can read from and write to the pipe. This mode gives the server
		/// the equivalent of GENERIC_READ and GENERIC_WRITE access to the pipe. The client can specify GENERIC_READ or GENERIC_WRITE, or
		/// both, when it connects to the pipe using the CreateFile function.
		/// </summary>
		PIPE_ACCESS_DUPLEX = 0x00000003,

		/// <summary>
		/// The flow of data in the pipe goes from client to server only. This mode gives the server the equivalent of GENERIC_READ
		/// access to the pipe. The client must specify GENERIC_WRITE access when connecting to the pipe. If the client must read pipe
		/// settings by calling the GetNamedPipeInfo or GetNamedPipeHandleState functions, the client must specify GENERIC_WRITE and
		/// FILE_READ_ATTRIBUTES access when connecting to the pipe.
		/// </summary>
		PIPE_ACCESS_INBOUND = 0x00000001,

		/// <summary>
		/// The flow of data in the pipe goes from server to client only. This mode gives the server the equivalent of GENERIC_WRITE
		/// access to the pipe. The client must specify GENERIC_READ access when connecting to the pipe. If the client must change pipe
		/// settings by calling the SetNamedPipeHandleState function, the client must specify GENERIC_READ and FILE_WRITE_ATTRIBUTES
		/// access when connecting to the pipe.
		/// </summary>
		PIPE_ACCESS_OUTBOUND = 0x00000002,

		/// <summary>
		/// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds, but creation
		/// of the next instance fails with ERROR_ACCESS_DENIED.
		/// </summary>
		FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,

		/// <summary>
		/// Write-through mode is enabled. This mode affects only write operations on byte-type pipes and, then, only when the client and
		/// server processes are on different computers. If this mode is enabled, functions writing to a named pipe do not return until
		/// the data written is transmitted across the network and is in the pipe's buffer on the remote computer. If this mode is not
		/// enabled, the system enhances the efficiency of network operations by buffering data until a minimum number of bytes
		/// accumulate or until a maximum time elapses.
		/// </summary>
		FILE_FLAG_WRITE_THROUGH = 0x80000000,

		/// <summary>
		/// Overlapped mode is enabled. If this mode is enabled, functions performing read, write, and connect operations that may take a
		/// significant time to be completed can return immediately. This mode enables the thread that started the operation to perform
		/// other operations while the time-consuming operation executes in the background. For example, in overlapped mode, a thread can
		/// handle simultaneous input and output (I/O) operations on multiple instances of a pipe or perform simultaneous read and write
		/// operations on the same pipe handle. If overlapped mode is not enabled, functions performing read, write, and connect
		/// operations on the pipe handle do not return until the operation is finished. The ReadFileEx and WriteFileEx functions can
		/// only be used with a pipe handle in overlapped mode. The ReadFile, WriteFile, ConnectNamedPipe, and TransactNamedPipe
		/// functions can execute either synchronously or as overlapped operations.
		/// </summary>
		FILE_FLAG_OVERLAPPED = 0x40000000,

		/// <summary>The caller will have write access to the named pipe's discretionary access control list (ACL).</summary>
		WRITE_DAC = 0x00040000,

		/// <summary>The caller will have write access to the named pipe's owner.</summary>
		WRITE_OWNER = 0x00080000,

		/// <summary>
		/// The caller will have write access to the named pipe's SACL. For more information, see Access-Control Lists (ACLs) and SACL
		/// Access Right.
		/// </summary>
		ACCESS_SYSTEM_SECURITY = 0x01000000
	}

	/// <summary>The pipe mode.</summary>
	[Flags]
	public enum PIPE_TYPE : uint
	{
		/// <summary>
		/// Blocking mode is enabled. When the pipe handle is specified in the ReadFile, WriteFile, or ConnectNamedPipe function, the
		/// operations are not completed until there is data to read, all data is written, or a client is connected. Use of this mode can
		/// mean waiting indefinitely in some situations for a client process to perform an action.
		/// </summary>
		PIPE_WAIT = 0x00000000,

		/// <summary>
		/// Nonblocking mode is enabled. In this mode, ReadFile, WriteFile, and ConnectNamedPipe always return immediately. Note that
		/// nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should not be used to achieve
		/// asynchronous I/O with named pipes. For more information on asynchronous pipe I/O, see Synchronous and Overlapped Input and Output.
		/// </summary>
		PIPE_NOWAIT = 0x00000001,

		/// <summary>Data is read from the pipe as a stream of bytes. This mode can be used with either PIPE_TYPE_MESSAGE or PIPE_TYPE_BYTE.</summary>
		PIPE_READMODE_BYTE = 0x00000000,

		/// <summary>
		/// Data is read from the pipe as a stream of messages. This mode can be only used if PIPE_TYPE_MESSAGE is also specified.
		/// </summary>
		PIPE_READMODE_MESSAGE = 0x00000002,

		/// <summary>
		/// Data is written to the pipe as a stream of bytes. This mode cannot be used with PIPE_READMODE_MESSAGE. The pipe does not
		/// distinguish bytes written during different write operations.
		/// </summary>
		PIPE_TYPE_BYTE = 0x00000000,

		/// <summary>
		/// Data is written to the pipe as a stream of messages. The pipe treats the bytes written during each write operation as a
		/// message unit. The GetLastError function returns ERROR_MORE_DATA when a message is not read completely. This mode can be used
		/// with either PIPE_READMODE_MESSAGE or PIPE_READMODE_BYTE.
		/// </summary>
		PIPE_TYPE_MESSAGE = 0x00000004,

		/// <summary>Connections from remote clients can be accepted and checked against the security descriptor for the pipe.</summary>
		PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,

		/// <summary>Connections from remote clients are automatically rejected.</summary>
		PIPE_REJECT_REMOTE_CLIENTS = 0x00000008,

		/// <summary>The handle refers to the client end of a named pipe instance. This is the default.</summary>
		PIPE_CLIENT_END = 0x00000000,

		/// <summary>
		/// The handle refers to the server end of a named pipe instance. If this value is not specified, the handle refers to the client
		/// end of a named pipe instance.
		/// </summary>
		PIPE_SERVER_END = 0x00000001,
	}

	/// <summary>
	/// Connects to a message-type pipe (and waits if an instance of the pipe is not available), writes to and reads from the pipe, and
	/// then closes the pipe.
	/// </summary>
	/// <param name="lpNamedPipeName">The pipe name.</param>
	/// <param name="lpInBuffer">The data to be written to the pipe.</param>
	/// <param name="nInBufferSize">The size of the write buffer, in bytes.</param>
	/// <param name="lpOutBuffer">A pointer to the buffer that receives the data read from the pipe.</param>
	/// <param name="nOutBufferSize">The size of the read buffer, in bytes.</param>
	/// <param name="lpBytesRead">A pointer to a variable that receives the number of bytes read from the pipe.</param>
	/// <param name="nTimeOut">
	/// <para>
	/// The number of milliseconds to wait for the named pipe to be available. In addition to numeric values, the following special
	/// values can be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NMPWAIT_NOWAIT0x00000001</term>
	/// <term>Does not wait for the named pipe. If the named pipe is not available, the function returns an error.</term>
	/// </item>
	/// <item>
	/// <term>NMPWAIT_WAIT_FOREVER0xffffffff</term>
	/// <term>Waits indefinitely.</term>
	/// </item>
	/// <item>
	/// <term>NMPWAIT_USE_DEFAULT_WAIT0x00000000</term>
	/// <term>Uses the default time-out specified in a call to the CreateNamedPipe function.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the message written to the pipe by the server process is longer than nOutBufferSize, <c>CallNamedPipe</c> returns
	/// <c>FALSE</c>, and <c>GetLastError</c> returns ERROR_MORE_DATA. The remainder of the message is discarded, because
	/// <c>CallNamedPipe</c> closes the handle to the pipe before returning.
	/// </para>
	/// </returns>
	// BOOL WINAPI CallNamedPipe( _In_ LPCTSTR lpNamedPipeName, _In_ LPVOID lpInBuffer, _In_ DWORD nInBufferSize, _Out_ LPVOID
	// lpOutBuffer, _In_ DWORD nOutBufferSize, _Out_ LPDWORD lpBytesRead, _In_ DWORD nTimeOut); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365144(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365144")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CallNamedPipe(string lpNamedPipeName, [In] IntPtr lpInBuffer, uint nInBufferSize, [Out] IntPtr lpOutBuffer, uint nOutBufferSize,
		out uint lpBytesRead, uint nTimeOut);

	/// <summary>
	/// Enables a named pipe server process to wait for a client process to connect to an instance of a named pipe. A client process
	/// connects by calling either the <c>CreateFile</c> or <c>CallNamedPipe</c> function.
	/// </summary>
	/// <param name="hNamedPipe">
	/// A handle to the server end of a named pipe instance. This handle is returned by the <c>CreateNamedPipe</c> function.
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>A pointer to an <c>OVERLAPPED</c> structure.</para>
	/// <para>
	/// If hNamedPipe was opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must not be <c>NULL</c>. It must point to a valid
	/// <c>OVERLAPPED</c> structure. If hNamedPipe was opened with FILE_FLAG_OVERLAPPED and lpOverlapped is <c>NULL</c>, the function can
	/// incorrectly report that the connect operation is complete.
	/// </para>
	/// <para>
	/// If hNamedPipe was created with FILE_FLAG_OVERLAPPED and lpOverlapped is not <c>NULL</c>, the <c>OVERLAPPED</c> structure should
	/// contain a handle to a manual-reset event object (which the server can create by using the <c>CreateEvent</c> function).
	/// </para>
	/// <para>
	/// If hNamedPipe was not opened with FILE_FLAG_OVERLAPPED, the function does not return until a client is connected or an error
	/// occurs. Successful synchronous operations result in the function returning a nonzero value if a client connects after the
	/// function is called.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the operation is synchronous, <c>ConnectNamedPipe</c> does not return until the operation has completed. If the function
	/// succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// <para>
	/// If the operation is asynchronous, <c>ConnectNamedPipe</c> returns immediately. If the operation is still pending, the return
	/// value is zero and <c>GetLastError</c> returns ERROR_IO_PENDING. (You can use the <c>HasOverlappedIoCompleted</c> macro to
	/// determine when the operation has finished.) If the function fails, the return value is zero and <c>GetLastError</c> returns a
	/// value other than ERROR_IO_PENDING or ERROR_PIPE_CONNECTED.
	/// </para>
	/// <para>
	/// If a client connects before the function is called, the function returns zero and <c>GetLastError</c> returns
	/// ERROR_PIPE_CONNECTED. This can happen if a client connects in the interval between the call to <c>CreateNamedPipe</c> and the
	/// call to <c>ConnectNamedPipe</c>. In this situation, there is a good connection between client and server, even though the
	/// function returns zero.
	/// </para>
	/// </returns>
	// BOOL WINAPI ConnectNamedPipe( _In_ HANDLE hNamedPipe, _Inout_opt_ LPOVERLAPPED lpOverlapped); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365146(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365146")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern unsafe bool ConnectNamedPipe([In] HPIPE hNamedPipe, [Optional] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// Creates an instance of a named pipe and returns a handle for subsequent pipe operations. A named pipe server process uses this
	/// function either to create the first instance of a specific named pipe and establish its basic attributes or to create a new instance
	/// of an existing named pipe.
	/// </summary>
	/// <param name="lpName">
	/// <para>The unique pipe name. This string must have the following form:</para>
	/// <para>\\.\pipe\ <c>pipename</c></para>
	/// <para>
	/// The pipename part of the name can include any character other than a backslash, including numbers and special characters. The entire
	/// pipe name string can be up to 256 characters long. Pipe names are not case sensitive.
	/// </para>
	/// </param>
	/// <param name="dwOpenMode">
	/// <para>The open mode.</para>
	/// <para>The function fails if <c>dwOpenMode</c> specifies anything other than 0 or the flags listed in the following tables.</para>
	/// <para>
	/// This parameter must specify one of the following pipe access modes. The same mode must be specified for each instance of the pipe.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>PIPE_ACCESS_DUPLEX</c> 0x00000003</description>
	/// <description>
	/// The pipe is bi-directional; both server and client processes can read from and write to the pipe. This mode gives the server the
	/// equivalent of <c>GENERIC_READ</c> and <c>GENERIC_WRITE</c> access to the pipe. The client can specify <c>GENERIC_READ</c> or
	/// <c>GENERIC_WRITE</c>, or both, when it connects to the pipe using the CreateFile function.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_ACCESS_INBOUND</c> 0x00000001</description>
	/// <description>
	/// The flow of data in the pipe goes from client to server only. This mode gives the server the equivalent of <c>GENERIC_READ</c> access
	/// to the pipe. The client must specify <c>GENERIC_WRITE</c> access when connecting to the pipe. If the client must read pipe settings
	/// by calling the GetNamedPipeInfo or GetNamedPipeHandleState functions, the client must specify <c>GENERIC_WRITE</c> and
	/// <c>FILE_READ_ATTRIBUTES</c> access when connecting to the pipe.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_ACCESS_OUTBOUND</c> 0x00000002</description>
	/// <description>
	/// The flow of data in the pipe goes from server to client only. This mode gives the server the equivalent of <c>GENERIC_WRITE</c>
	/// access to the pipe. The client must specify <c>GENERIC_READ</c> access when connecting to the pipe. If the client must change pipe
	/// settings by calling the SetNamedPipeHandleState function, the client must specify <c>GENERIC_READ</c> and
	/// <c>FILE_WRITE_ATTRIBUTES</c> access when connecting to the pipe.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter can also include one or more of the following flags, which enable the write-through and overlapped modes. These modes
	/// can be different for different instances of the same pipe.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>FILE_FLAG_FIRST_PIPE_INSTANCE</c> 0x00080000</description>
	/// <description>
	/// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds, but creation of the
	/// next instance fails with <c>ERROR_ACCESS_DENIED</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>FILE_FLAG_WRITE_THROUGH</c> 0x80000000</description>
	/// <description>
	/// Write-through mode is enabled. This mode affects only write operations on byte-type pipes and, then, only when the client and server
	/// processes are on different computers. If this mode is enabled, functions writing to a named pipe do not return until the data written
	/// is transmitted across the network and is in the pipe's buffer on the remote computer. If this mode is not enabled, the system
	/// enhances the efficiency of network operations by buffering data until a minimum number of bytes accumulate or until a maximum time elapses.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>FILE_FLAG_OVERLAPPED</c> 0x40000000</description>
	/// <description>
	/// Overlapped mode is enabled. If this mode is enabled, functions performing read, write, and connect operations that may take a
	/// significant time to be completed can return immediately. This mode enables the thread that started the operation to perform other
	/// operations while the time-consuming operation executes in the background. For example, in overlapped mode, a thread can handle
	/// simultaneous input and output (I/O) operations on multiple instances of a pipe or perform simultaneous read and write operations on
	/// the same pipe handle. If overlapped mode is not enabled, functions performing read, write, and connect operations on the pipe handle
	/// do not return until the operation is finished. The ReadFileEx and WriteFileEx functions can only be used with a pipe handle in
	/// overlapped mode. The ReadFile, WriteFile, ConnectNamedPipe, and TransactNamedPipe functions can execute either synchronously or as
	/// overlapped operations.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// This parameter can include any combination of the following security access modes. These modes can be different for different
	/// instances of the same pipe.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Mode</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>WRITE_DAC</c> 0x00040000L</description>
	/// <description>The caller will have write access to the named pipe's discretionary access control list (ACL).</description>
	/// </item>
	/// <item>
	/// <description><c>WRITE_OWNER</c> 0x00080000L</description>
	/// <description>The caller will have write access to the named pipe's owner.</description>
	/// </item>
	/// <item>
	/// <description><c>ACCESS_SYSTEM_SECURITY</c> 0x01000000L</description>
	/// <description>
	/// The caller will have write access to the named pipe's SACL. For more information, see Access-Control Lists (ACLs) and SACL Access Right.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwPipeMode">
	/// <para>The pipe mode.</para>
	/// <para>The function fails if <c>dwPipeMode</c> specifies anything other than 0 or the flags listed in the following tables.</para>
	/// <para>One of the following type modes can be specified. The same type mode must be specified for each instance of the pipe.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>PIPE_TYPE_BYTE</c> 0x00000000</description>
	/// <description>
	/// Data is written to the pipe as a stream of bytes. This mode cannot be used with PIPE_READMODE_MESSAGE. The pipe does not distinguish
	/// bytes written during different write operations.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_TYPE_MESSAGE</c> 0x00000004</description>
	/// <description>
	/// Data is written to the pipe as a stream of messages. The pipe treats the bytes written during each write operation as a message unit.
	/// The GetLastError function returns <c>ERROR_MORE_DATA</c> when a message is not read completely. This mode can be used with either
	/// <c>PIPE_READMODE_MESSAGE</c> or <c>PIPE_READMODE_BYTE</c>.
	/// </description>
	/// </item>
	/// </list>
	/// <para>One of the following read modes can be specified. Different instances of the same pipe can specify different read modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Mode</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PIPE_READMODE_BYTE</c> 0x00000000</description>
	/// <description>
	/// Data is read from the pipe as a stream of bytes. This mode can be used with either <c>PIPE_TYPE_MESSAGE</c> or <c>PIPE_TYPE_BYTE</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_READMODE_MESSAGE</c> 0x00000002</description>
	/// <description>
	/// Data is read from the pipe as a stream of messages. This mode can be only used if <c>PIPE_TYPE_MESSAGE</c> is also specified.
	/// </description>
	/// </item>
	/// </list>
	/// <para>One of the following wait modes can be specified. Different instances of the same pipe can specify different wait modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>PIPE_WAIT</c> 0x00000000</description>
	/// <description>
	/// Blocking mode is enabled. When the pipe handle is specified in the ReadFile, WriteFile, or ConnectNamedPipe function, the operations
	/// are not completed until there is data to read, all data is written, or a client is connected. Use of this mode can mean waiting
	/// indefinitely in some situations for a client process to perform an action.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_NOWAIT</c> 0x00000001</description>
	/// <description>
	/// Nonblocking mode is enabled. In this mode, ReadFile, WriteFile, and ConnectNamedPipe always return immediately. Note that nonblocking
	/// mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should not be used to achieve asynchronous I/O with
	/// named pipes. For more information on asynchronous pipe I/O, see Synchronous and Overlapped Input and Output.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// One of the following remote-client modes can be specified. Different instances of the same pipe can specify different remote-client modes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Mode</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PIPE_ACCEPT_REMOTE_CLIENTS</c> 0x00000000</description>
	/// <description>Connections from remote clients can be accepted and checked against the security descriptor for the pipe.</description>
	/// </item>
	/// <item>
	/// <description><c>PIPE_REJECT_REMOTE_CLIENTS</c> 0x00000008</description>
	/// <description>Connections from remote clients are automatically rejected.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="nMaxInstances">
	/// <para>
	/// The maximum number of instances that can be created for this pipe. The first instance of the pipe can specify this value; the same
	/// number must be specified for other instances of the pipe. Acceptable values are in the range 1 through
	/// <c>PIPE_UNLIMITED_INSTANCES</c> (255).
	/// </para>
	/// <para>
	/// If this parameter is <c>PIPE_UNLIMITED_INSTANCES</c>, the number of pipe instances that can be created is limited only by the
	/// availability of system resources. If <c>nMaxInstances</c> is greater than <c>PIPE_UNLIMITED_INSTANCES</c>, the return value is
	/// <c>INVALID_HANDLE_VALUE</c> and GetLastError returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="nOutBufferSize">
	/// The number of bytes to reserve for the output buffer. For a discussion on sizing named pipe buffers, see the following Remarks section.
	/// </param>
	/// <param name="nInBufferSize">
	/// The number of bytes to reserve for the input buffer. For a discussion on sizing named pipe buffers, see the following Remarks section.
	/// </param>
	/// <param name="nDefaultTimeOut">
	/// <para>
	/// The default time-out value, in milliseconds, if the WaitNamedPipe function specifies <c>NMPWAIT_USE_DEFAULT_WAIT</c>. Each instance
	/// of a named pipe must specify the same value.
	/// </para>
	/// <para>A value of zero will result in a default time-out of 50 milliseconds.</para>
	/// </param>
	/// <param name="lpSecurityAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new named pipe and determines whether child
	/// processes can inherit the returned handle. If <c>lpSecurityAttributes</c> is <c>NULL</c>, the named pipe gets a default security
	/// descriptor and the handle cannot be inherited. The ACLs in the default security descriptor for a named pipe grant full control to the
	/// LocalSystem account, administrators, and the creator owner. They also grant read access to members of the Everyone group and the
	/// anonymous account.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the server end of a named pipe instance.</para>
	/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To create an instance of a named pipe by using <c>CreateNamedPipe</c>, the user must have <c>FILE_CREATE_PIPE_INSTANCE</c> access to
	/// the named pipe object. If a new named pipe is being created, the access control list (ACL) from the security attributes parameter
	/// defines the discretionary access control for the named pipe.
	/// </para>
	/// <para>
	/// All instances of a named pipe must specify the same pipe type (byte-type or message-type), pipe access (duplex, inbound, or
	/// outbound), instance count, and time-out value. If different values are used, this function fails and GetLastError returns <c>ERROR_ACCESS_DENIED</c>.
	/// </para>
	/// <para>
	/// A client process connects to a named pipe by using the CreateFile or CallNamedPipe function. The client side of a named pipe starts
	/// out in byte mode, even if the server side is in message mode. To avoid problems receiving data, set the client side to message mode
	/// as well. To change the mode of the pipe, the pipe client must open a read-only pipe with <c>GENERIC_READ</c> and
	/// <c>FILE_WRITE_ATTRIBUTES</c> access.
	/// </para>
	/// <para>
	/// The pipe server should not perform a blocking read operation until the pipe client has started. Otherwise, a race condition can
	/// occur. This typically occurs when initialization code, such as the C run-time, needs to lock and examine inherited handles.
	/// </para>
	/// <para>
	/// Every time a named pipe is created, the system creates the inbound and/or outbound buffers using nonpaged pool, which is the physical
	/// memory used by the kernel. The number of pipe instances (as well as objects such as threads and processes) that you can create is
	/// limited by the available nonpaged pool. Each read or write request requires space in the buffer for the read or write data, plus
	/// additional space for the internal data structures.
	/// </para>
	/// <para>
	/// The input and output buffer sizes are advisory. The actual buffer size reserved for each end of the named pipe is either the system
	/// default, the system minimum or maximum, or the specified size rounded up to the next allocation boundary. The buffer size specified
	/// should be small enough that your process will not run out of nonpaged pool, but large enough to accommodate typical requests.
	/// </para>
	/// <para>
	/// Whenever a pipe write operation occurs, the system first tries to charge the memory against the pipe write quota. If the remaining
	/// pipe write quota is enough to fulfill the request, the write operation completes immediately. If the remaining pipe write quota is
	/// too small to fulfill the request, the system will try to expand the buffers to accommodate the data using nonpaged pool reserved for
	/// the process. The write operation will block until the data is read from the pipe so that the additional buffer quota can be released.
	/// Therefore, if your specified buffer size is too small, the system will grow the buffer as needed, but the downside is that the
	/// operation will block. If the operation is overlapped, a system thread is blocked; otherwise, the application thread is blocked.
	/// </para>
	/// <para>
	/// To free resources used by a named pipe, the application should always close handles when they are no longer needed, which is
	/// accomplished either by calling the CloseHandle function or when the process associated with the instance handles ends. Note that an
	/// instance of a named pipe may have more than one handle associated with it. An instance of a named pipe is always deleted when the
	/// last handle to the instance of the named pipe is closed.
	/// </para>
	/// <para>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP process
	/// that's part of the same app. Also, named pipes must use the syntax for the pipe name.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Multithreaded Pipe Server.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createnamedpipea HANDLE CreateNamedPipeA( [in] LPCSTR lpName,
	// [in] DWORD dwOpenMode, [in] DWORD dwPipeMode, [in] DWORD nMaxInstances, [in] DWORD nOutBufferSize, [in] DWORD nInBufferSize, [in]
	// DWORD nDefaultTimeOut, [in, optional] LPSECURITY_ATTRIBUTES lpSecurityAttributes );
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.CreateNamedPipeA")]
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern SafeHPIPE CreateNamedPipe(string lpName, PIPE_ACCESS dwOpenMode, PIPE_TYPE dwPipeMode, uint nMaxInstances, uint nOutBufferSize,
		uint nInBufferSize, uint nDefaultTimeOut, [In, Optional] SECURITY_ATTRIBUTES? lpSecurityAttributes);

	/// <summary>Creates an anonymous pipe, and returns handles to the read and write ends of the pipe.</summary>
	/// <param name="hReadPipe">A pointer to a variable that receives the read handle for the pipe.</param>
	/// <param name="hWritePipe">A pointer to a variable that receives the write handle for the pipe.</param>
	/// <param name="lpPipeAttributes">
	/// <para>
	/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that determines whether the returned handle can be inherited by child
	/// processes. If lpPipeAttributes is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new pipe. If lpPipeAttributes is
	/// <c>NULL</c>, the pipe gets a default security descriptor. The ACLs in the default security descriptor for a pipe come from the
	/// primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="nSize">
	/// The size of the buffer for the pipe, in bytes. The size is only a suggestion; the system uses the value to calculate an
	/// appropriate buffering mechanism. If this parameter is zero, the system uses the default buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI CreatePipe( _Out_ PHANDLE hReadPipe, _Out_ PHANDLE hWritePipe, _In_opt_ LPSECURITY_ATTRIBUTES lpPipeAttributes, _In_
	// DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365152(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365152")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreatePipe(out SafeHPIPE hReadPipe, out SafeHPIPE hWritePipe, [In, Optional] SECURITY_ATTRIBUTES? lpPipeAttributes, [In, Optional] uint nSize);

	/// <summary>Disconnects the server end of a named pipe instance from a client process.</summary>
	/// <param name="hNamedPipe">
	/// A handle to an instance of a named pipe. This handle must be created by the <c>CreateNamedPipe</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI DisconnectNamedPipe( _In_ HANDLE hNamedPipe); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365166(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365166")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DisconnectNamedPipe([In] HPIPE hNamedPipe);

	/// <summary>Retrieves the client computer name for the specified named pipe.</summary>
	/// <param name="Pipe">A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</param>
	/// <param name="ClientComputerName">The computer name.</param>
	/// <param name="ClientComputerNameLength">The size of the <c>ClientComputerName</c> buffer, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP process
	/// that's part of the same app. Also, named pipes must use the syntax for the pipe name.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnamedpipeclientcomputernamea BOOL
	// GetNamedPipeClientComputerNameA( [in] HANDLE Pipe, [out] LPSTR ClientComputerName, [in] ULONG ClientComputerNameLength );
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.GetNamedPipeClientComputerNameA")]
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeClientComputerName(HPIPE Pipe, [Out] StringBuilder ClientComputerName, uint ClientComputerNameLength);

	/// <summary>
	/// <para>Retrieves the client process identifier for the specified named pipe.</para>
	/// </summary>
	/// <param name="Pipe">
	/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
	/// </param>
	/// <param name="ClientProcessId">
	/// <para>The process identifier.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
	/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeclientprocessid BOOL
	// GetNamedPipeClientProcessId( HANDLE Pipe, PULONG ClientProcessId );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "7001eb89-3d91-44e3-b245-b19e8ab5f9fe")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeClientProcessId(HPIPE Pipe, out uint ClientProcessId);

	/// <summary>
	/// <para>Retrieves the client session identifier for the specified named pipe.</para>
	/// </summary>
	/// <param name="Pipe">
	/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
	/// </param>
	/// <param name="ClientSessionId">
	/// <para>The session identifier.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
	/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeclientsessionid BOOL
	// GetNamedPipeClientSessionId( HANDLE Pipe, PULONG ClientSessionId );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "b3ea0b7f-fead-4369-b87a-2f522a2a1984")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeClientSessionId(HPIPE Pipe, out uint ClientSessionId);

	/// <summary>
	/// Retrieves information about a specified named pipe. The information returned can vary during the lifetime of an instance of the
	/// named pipe.
	/// </summary>
	/// <param name="hNamedPipe">
	/// <para>
	/// A handle to the named pipe for which information is wanted. The handle must have GENERIC_READ access for a read-only or
	/// read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a write-only pipe.
	/// </para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpState">
	/// <para>
	/// A pointer to a variable that indicates the current state of the handle. This parameter can be <c>NULL</c> if this information is
	/// not needed. Either or both of the following values can be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_NOWAIT0x00000001</term>
	/// <term>The pipe handle is in nonblocking mode. If this flag is not specified, the pipe handle is in blocking mode.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_READMODE_MESSAGE0x00000002</term>
	/// <term>The pipe handle is in message-read mode. If this flag is not specified, the pipe handle is in byte-read mode.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpCurInstances">
	/// A pointer to a variable that receives the number of current pipe instances. This parameter can be <c>NULL</c> if this information
	/// is not required.
	/// </param>
	/// <param name="lpMaxCollectionCount">
	/// A pointer to a variable that receives the maximum number of bytes to be collected on the client's computer before transmission to
	/// the server. This parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and
	/// server processes are on the same computer. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpCollectDataTimeout">
	/// A pointer to a variable that receives the maximum time, in milliseconds, that can pass before a remote named pipe transfers
	/// information over the network. This parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named
	/// pipe or if client and server processes are on the same computer. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpUserName">
	/// <para>
	/// A pointer to a buffer that receives the user name string associated with the client application. The server can only retrieve
	/// this information if the client opened the pipe with SECURITY_IMPERSONATION access.
	/// </para>
	/// <para>
	/// This parameter must be <c>NULL</c> if the specified pipe handle is to the client end of a named pipe. This parameter can be
	/// <c>NULL</c> if this information is not required.
	/// </para>
	/// </param>
	/// <param name="nMaxUserNameSize">
	/// The size of the buffer specified by the lpUserName parameter, in <c>TCHARs</c>. This parameter is ignored if lpUserName is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetNamedPipeHandleState( _In_ HANDLE hNamedPipe, _Out_opt_ LPDWORD lpState, _Out_opt_ LPDWORD lpCurInstances,
	// _Out_opt_ LPDWORD lpMaxCollectionCount, _Out_opt_ LPDWORD lpCollectDataTimeout, _Out_opt_ LPTSTR lpUserName, _In_ DWORD
	// nMaxUserNameSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365443(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa365443")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeHandleState([In] HPIPE hNamedPipe, out PIPE_TYPE lpState, out uint lpCurInstances, [Optional] IntPtr lpMaxCollectionCount,
		[Optional] IntPtr lpCollectDataTimeout, [Optional] StringBuilder? lpUserName, [Optional] uint nMaxUserNameSize);

	/// <summary>
	/// Retrieves information about a specified named pipe. The information returned can vary during the lifetime of an instance of the
	/// named pipe.
	/// </summary>
	/// <param name="hNamedPipe">
	/// <para>
	/// A handle to the named pipe for which information is wanted. The handle must have GENERIC_READ access for a read-only or
	/// read/write pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a write-only pipe.
	/// </para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpState">
	/// <para>
	/// A pointer to a variable that indicates the current state of the handle. This parameter can be <c>NULL</c> if this information is
	/// not needed. Either or both of the following values can be specified.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_NOWAIT0x00000001</term>
	/// <term>The pipe handle is in nonblocking mode. If this flag is not specified, the pipe handle is in blocking mode.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_READMODE_MESSAGE0x00000002</term>
	/// <term>The pipe handle is in message-read mode. If this flag is not specified, the pipe handle is in byte-read mode.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpCurInstances">
	/// A pointer to a variable that receives the number of current pipe instances. This parameter can be <c>NULL</c> if this information
	/// is not required.
	/// </param>
	/// <param name="lpMaxCollectionCount">
	/// A pointer to a variable that receives the maximum number of bytes to be collected on the client's computer before transmission to
	/// the server. This parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and
	/// server processes are on the same computer. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpCollectDataTimeout">
	/// A pointer to a variable that receives the maximum time, in milliseconds, that can pass before a remote named pipe transfers
	/// information over the network. This parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named
	/// pipe or if client and server processes are on the same computer. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpUserName">
	/// <para>
	/// A pointer to a buffer that receives the user name string associated with the client application. The server can only retrieve
	/// this information if the client opened the pipe with SECURITY_IMPERSONATION access.
	/// </para>
	/// <para>
	/// This parameter must be <c>NULL</c> if the specified pipe handle is to the client end of a named pipe. This parameter can be
	/// <c>NULL</c> if this information is not required.
	/// </para>
	/// </param>
	/// <param name="nMaxUserNameSize">
	/// The size of the buffer specified by the lpUserName parameter, in <c>TCHARs</c>. This parameter is ignored if lpUserName is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetNamedPipeHandleState( _In_ HANDLE hNamedPipe, _Out_opt_ LPDWORD lpState, _Out_opt_ LPDWORD lpCurInstances,
	// _Out_opt_ LPDWORD lpMaxCollectionCount, _Out_opt_ LPDWORD lpCollectDataTimeout, _Out_opt_ LPTSTR lpUserName, _In_ DWORD
	// nMaxUserNameSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365443(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365443")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeHandleState([In] HPIPE hNamedPipe, out PIPE_TYPE lpState, out uint lpCurInstances, out uint lpMaxCollectionCount,
		out uint lpCollectDataTimeout, [Optional] StringBuilder? lpUserName, [Optional] uint nMaxUserNameSize);

	/// <summary>Retrieves information about the specified named pipe.</summary>
	/// <param name="hNamedPipe">
	/// <para>
	/// A handle to the named pipe instance. The handle must have GENERIC_READ access to the named pipe for a read-only or read/write
	/// pipe, or it must have GENERIC_WRITE and FILE_READ_ATTRIBUTES access for a write-only pipe.
	/// </para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpFlags">
	/// <para>
	/// A pointer to a variable that receives the type of the named pipe. This parameter can be <c>NULL</c> if this information is not
	/// required. Otherwise, this parameter can be one or more of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_CLIENT_END0x00000000</term>
	/// <term>The handle refers to the client end of a named pipe instance. This is the default.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_SERVER_END0x00000001</term>
	/// <term>
	/// The handle refers to the server end of a named pipe instance. If this value is not specified, the handle refers to the client end
	/// of a named pipe instance.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PIPE_TYPE_BYTE0x00000000</term>
	/// <term>The named pipe is a byte pipe. This is the default.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_TYPE_MESSAGE0x00000004</term>
	/// <term>The named pipe is a message pipe. If this value is not specified, the pipe is a byte pipe.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpOutBufferSize">
	/// A pointer to a variable that receives the size of the buffer for outgoing data, in bytes. If the buffer size is zero, the buffer
	/// is allocated as needed. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpInBufferSize">
	/// A pointer to a variable that receives the size of the buffer for incoming data, in bytes. If the buffer size is zero, the buffer
	/// is allocated as needed. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <param name="lpMaxInstances">
	/// A pointer to a variable that receives the maximum number of pipe instances that can be created. If the variable is set to
	/// PIPE_UNLIMITED_INSTANCES (255), the number of pipe instances that can be created is limited only by the availability of system
	/// resources. This parameter can be <c>NULL</c> if this information is not required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetNamedPipeInfo( _In_ HANDLE hNamedPipe, _Out_opt_ LPDWORD lpFlags, _Out_opt_ LPDWORD lpOutBufferSize, _Out_opt_
	// LPDWORD lpInBufferSize, _Out_opt_ LPDWORD lpMaxInstances); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365445(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365445")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeInfo([In] HPIPE hNamedPipe, out PIPE_TYPE lpFlags, out uint lpOutBufferSize, out uint lpInBufferSize, out uint lpMaxInstances);

	/// <summary>
	/// <para>Retrieves the server process identifier for the specified named pipe.</para>
	/// </summary>
	/// <param name="Pipe">
	/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
	/// </param>
	/// <param name="ServerProcessId">
	/// <para>The process identifier.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
	/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeserverprocessid BOOL
	// GetNamedPipeServerProcessId( HANDLE Pipe, PULONG ServerProcessId );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "1ee33a66-a71c-4c34-b907-aab7860294c4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeServerProcessId([In] HPIPE Pipe, out uint ServerProcessId);

	/// <summary>
	/// <para>Retrieves the server session identifier for the specified named pipe.</para>
	/// </summary>
	/// <param name="Pipe">
	/// <para>A handle to an instance of a named pipe. This handle must be created by the CreateNamedPipe function.</para>
	/// </param>
	/// <param name="ServerSessionId">
	/// <para>The session identifier.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Windows 10, version 1709:</c> Pipes are only supported within an app-container; ie, from one UWP process to another UWP
	/// process that's part of the same app. Also, named pipes must use the syntax "\.\pipe\LOCAL" for the pipe name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getnamedpipeserversessionid BOOL
	// GetNamedPipeServerSessionId( HANDLE Pipe, PULONG ServerSessionId );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "cd628d6d-aa13-4762-893b-42f6cf7a2ba6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNamedPipeServerSessionId([In] HPIPE Pipe, out uint ServerSessionId);

	/// <summary>
	/// Copies data from a named or anonymous pipe into a buffer without removing it from the pipe. It also returns information about
	/// data in the pipe.
	/// </summary>
	/// <param name="hNamedPipe">
	/// A handle to the pipe. This parameter can be a handle to a named pipe instance, as returned by the <c>CreateNamedPipe</c> or
	/// <c>CreateFile</c> function, or it can be a handle to the read end of an anonymous pipe, as returned by the <c>CreatePipe</c>
	/// function. The handle must have GENERIC_READ access to the pipe.
	/// </param>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives data read from the pipe. This parameter can be <c>NULL</c> if no data is to be read.
	/// </param>
	/// <param name="nBufferSize">
	/// The size of the buffer specified by the lpBuffer parameter, in bytes. This parameter is ignored if lpBuffer is <c>NULL</c>.
	/// </param>
	/// <param name="lpBytesRead">
	/// A pointer to a variable that receives the number of bytes read from the pipe. This parameter can be <c>NULL</c> if no data is to
	/// be read.
	/// </param>
	/// <param name="lpTotalBytesAvail">
	/// A pointer to a variable that receives the total number of bytes available to be read from the pipe. This parameter can be
	/// <c>NULL</c> if no data is to be read.
	/// </param>
	/// <param name="lpBytesLeftThisMessage">
	/// A pointer to a variable that receives the number of bytes remaining in this message. This parameter will be zero for byte-type
	/// named pipes or for anonymous pipes. This parameter can be <c>NULL</c> if no data is to be read.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI PeekNamedPipe( _In_ HANDLE hNamedPipe, _Out_opt_ LPVOID lpBuffer, _In_ DWORD nBufferSize, _Out_opt_ LPDWORD
	// lpBytesRead, _Out_opt_ LPDWORD lpTotalBytesAvail, _Out_opt_ LPDWORD lpBytesLeftThisMessage); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365779(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365779")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PeekNamedPipe([In] HPIPE hNamedPipe, [Out, Optional] IntPtr lpBuffer, [Optional] uint nBufferSize,
		out uint lpBytesRead, out uint lpTotalBytesAvail, out uint lpBytesLeftThisMessage);

	/// <summary>
	/// Copies data from a named or anonymous pipe into a buffer without removing it from the pipe. It also returns information about
	/// data in the pipe.
	/// </summary>
	/// <param name="hNamedPipe">
	/// A handle to the pipe. This parameter can be a handle to a named pipe instance, as returned by the <c>CreateNamedPipe</c> or
	/// <c>CreateFile</c> function, or it can be a handle to the read end of an anonymous pipe, as returned by the <c>CreatePipe</c>
	/// function. The handle must have GENERIC_READ access to the pipe.
	/// </param>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives data read from the pipe. This parameter can be <c>NULL</c> if no data is to be read.
	/// </param>
	/// <param name="nBufferSize">
	/// The size of the buffer specified by the lpBuffer parameter, in bytes. This parameter is ignored if lpBuffer is <c>NULL</c>.
	/// </param>
	/// <param name="lpBytesRead">
	/// A pointer to a variable that receives the number of bytes read from the pipe. This parameter can be <c>NULL</c> if no data is to
	/// be read.
	/// </param>
	/// <param name="lpTotalBytesAvail">
	/// A pointer to a variable that receives the total number of bytes available to be read from the pipe. This parameter can be
	/// <c>NULL</c> if no data is to be read.
	/// </param>
	/// <param name="lpBytesLeftThisMessage">
	/// A pointer to a variable that receives the number of bytes remaining in this message. This parameter will be zero for byte-type
	/// named pipes or for anonymous pipes. This parameter can be <c>NULL</c> if no data is to be read.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI PeekNamedPipe( _In_ HANDLE hNamedPipe, _Out_opt_ LPVOID lpBuffer, _In_ DWORD nBufferSize, _Out_opt_ LPDWORD
	// lpBytesRead, _Out_opt_ LPDWORD lpTotalBytesAvail, _Out_opt_ LPDWORD lpBytesLeftThisMessage); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365779(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365779")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PeekNamedPipe([In] HPIPE hNamedPipe, [Out] byte[] lpBuffer, uint nBufferSize, out uint lpBytesRead, out uint lpTotalBytesAvail, out uint lpBytesLeftThisMessage);

	/// <summary>
	/// Sets the read mode and the blocking mode of the specified named pipe. If the specified handle is to the client end of a named
	/// pipe and if the named pipe server process is on a remote computer, the function can also be used to control local buffering.
	/// </summary>
	/// <param name="hNamedPipe">
	/// <para>
	/// A handle to the named pipe instance. This parameter can be a handle to the server end of the pipe, as returned by the
	/// <c>CreateNamedPipe</c> function, or to the client end of the pipe, as returned by the <c>CreateFile</c> function. The handle must
	/// have GENERIC_WRITE access to the named pipe for a write-only or read/write pipe, or it must have GENERIC_READ and
	/// FILE_WRITE_ATTRIBUTES access for a read-only pipe.
	/// </para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpMode">
	/// <para>
	/// The new pipe mode. The mode is a combination of a read-mode flag and a wait-mode flag. This parameter can be <c>NULL</c> if the
	/// mode is not being set. Specify one of the following modes.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_READMODE_BYTE0x00000000</term>
	/// <term>Data is read from the pipe as a stream of bytes. This mode is the default if no read-mode flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_READMODE_MESSAGE0x00000002</term>
	/// <term>Data is read from the pipe as a stream of messages. The function fails if this flag is specified for a byte-type pipe.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>One of the following wait modes can be specified.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_WAIT0x00000000</term>
	/// <term>
	/// Blocking mode is enabled. This mode is the default if no wait-mode flag is specified. When a blocking mode pipe handle is
	/// specified in the ReadFile, WriteFile, or ConnectNamedPipe function, operations are not finished until there is data to read, all
	/// data is written, or a client is connected. Use of this mode can mean waiting indefinitely in some situations for a client process
	/// to perform an action.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PIPE_NOWAIT0x00000001</term>
	/// <term>
	/// Nonblocking mode is enabled. In this mode, ReadFile, WriteFile, and ConnectNamedPipe always return immediately. Note that
	/// nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should not be used to achieve
	/// asynchronous input and output (I/O) with named pipes.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpMaxCollectionCount">
	/// The maximum number of bytes collected on the client computer before transmission to the server. This parameter must be
	/// <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and server processes are on the same
	/// machine. This parameter is ignored if the client process specifies the FILE_FLAG_WRITE_THROUGH flag in the <c>CreateFile</c>
	/// function when the handle was created. This parameter can be <c>NULL</c> if the collection count is not being set.
	/// </param>
	/// <param name="lpCollectDataTimeout">
	/// The maximum time, in milliseconds, that can pass before a remote named pipe transfers information over the network. This
	/// parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and server processes
	/// are on the same computer. This parameter is ignored if the client process specified the FILE_FLAG_WRITE_THROUGH flag in the
	/// <c>CreateFile</c> function when the handle was created. This parameter can be <c>NULL</c> if the collection count is not being set.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetNamedPipeHandleState( _In_ HANDLE hNamedPipe, _In_opt_ LPDWORD lpMode, _In_opt_ LPDWORD lpMaxCollectionCount,
	// _In_opt_ LPDWORD lpCollectDataTimeout); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365787(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365787")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetNamedPipeHandleState([In] HPIPE hNamedPipe, in uint lpMode, in uint lpMaxCollectionCount, in uint lpCollectDataTimeout);

	/// <summary>
	/// Sets the read mode and the blocking mode of the specified named pipe. If the specified handle is to the client end of a named
	/// pipe and if the named pipe server process is on a remote computer, the function can also be used to control local buffering.
	/// </summary>
	/// <param name="hNamedPipe">
	/// <para>
	/// A handle to the named pipe instance. This parameter can be a handle to the server end of the pipe, as returned by the
	/// <c>CreateNamedPipe</c> function, or to the client end of the pipe, as returned by the <c>CreateFile</c> function. The handle must
	/// have GENERIC_WRITE access to the named pipe for a write-only or read/write pipe, or it must have GENERIC_READ and
	/// FILE_WRITE_ATTRIBUTES access for a read-only pipe.
	/// </para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpMode">
	/// <para>
	/// The new pipe mode. The mode is a combination of a read-mode flag and a wait-mode flag. This parameter can be <c>NULL</c> if the
	/// mode is not being set. Specify one of the following modes.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_READMODE_BYTE0x00000000</term>
	/// <term>Data is read from the pipe as a stream of bytes. This mode is the default if no read-mode flag is specified.</term>
	/// </item>
	/// <item>
	/// <term>PIPE_READMODE_MESSAGE0x00000002</term>
	/// <term>Data is read from the pipe as a stream of messages. The function fails if this flag is specified for a byte-type pipe.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>One of the following wait modes can be specified.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PIPE_WAIT0x00000000</term>
	/// <term>
	/// Blocking mode is enabled. This mode is the default if no wait-mode flag is specified. When a blocking mode pipe handle is
	/// specified in the ReadFile, WriteFile, or ConnectNamedPipe function, operations are not finished until there is data to read, all
	/// data is written, or a client is connected. Use of this mode can mean waiting indefinitely in some situations for a client process
	/// to perform an action.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PIPE_NOWAIT0x00000001</term>
	/// <term>
	/// Nonblocking mode is enabled. In this mode, ReadFile, WriteFile, and ConnectNamedPipe always return immediately. Note that
	/// nonblocking mode is supported for compatibility with Microsoft LAN Manager version 2.0 and should not be used to achieve
	/// asynchronous input and output (I/O) with named pipes.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpMaxCollectionCount">
	/// The maximum number of bytes collected on the client computer before transmission to the server. This parameter must be
	/// <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and server processes are on the same
	/// machine. This parameter is ignored if the client process specifies the FILE_FLAG_WRITE_THROUGH flag in the <c>CreateFile</c>
	/// function when the handle was created. This parameter can be <c>NULL</c> if the collection count is not being set.
	/// </param>
	/// <param name="lpCollectDataTimeout">
	/// The maximum time, in milliseconds, that can pass before a remote named pipe transfers information over the network. This
	/// parameter must be <c>NULL</c> if the specified pipe handle is to the server end of a named pipe or if client and server processes
	/// are on the same computer. This parameter is ignored if the client process specified the FILE_FLAG_WRITE_THROUGH flag in the
	/// <c>CreateFile</c> function when the handle was created. This parameter can be <c>NULL</c> if the collection count is not being set.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetNamedPipeHandleState( _In_ HANDLE hNamedPipe, _In_opt_ LPDWORD lpMode, _In_opt_ LPDWORD lpMaxCollectionCount,
	// _In_opt_ LPDWORD lpCollectDataTimeout); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365787(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365787")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetNamedPipeHandleState([In] HPIPE hNamedPipe, [In, Optional] IntPtr lpMode, [In, Optional] IntPtr lpMaxCollectionCount, [In, Optional] IntPtr lpCollectDataTimeout);

	/// <summary>
	/// Combines the functions that write a message to and read a message from the specified named pipe into a single network operation.
	/// </summary>
	/// <param name="hNamedPipe">
	/// <para>A handle to the named pipe returned by the <c>CreateNamedPipe</c> or <c>CreateFile</c> function.</para>
	/// <para>This parameter can also be a handle to an anonymous pipe, as returned by the <c>CreatePipe</c> function.</para>
	/// </param>
	/// <param name="lpInBuffer">A pointer to the buffer containing the data to be written to the pipe.</param>
	/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
	/// <param name="lpOutBuffer">A pointer to the buffer that receives the data read from the pipe.</param>
	/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
	/// <param name="lpBytesRead">
	/// <para>A pointer to the variable that receives the number of bytes read from the pipe.</para>
	/// <para>If lpOverlapped is <c>NULL</c>, lpBytesRead cannot be <c>NULL</c>.</para>
	/// <para>
	/// If lpOverlapped is not <c>NULL</c>, lpBytesRead can be <c>NULL</c>. If this is an overlapped read operation, you can get the
	/// number of bytes read by calling <c>GetOverlappedResult</c>. If hNamedPipe is associated with an I/O completion port, you can get
	/// the number of bytes read by calling <c>GetQueuedCompletionStatus</c>.
	/// </para>
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>A pointer to an <c>OVERLAPPED</c> structure. This structure is required if hNamedPipe was opened with FILE_FLAG_OVERLAPPED.</para>
	/// <para>
	/// If hNamedPipe was opened with FILE_FLAG_OVERLAPPED, the lpOverlapped parameter must not be <c>NULL</c>. It must point to a valid
	/// <c>OVERLAPPED</c> structure. If hNamedPipe was created with FILE_FLAG_OVERLAPPED and lpOverlapped is <c>NULL</c>, the function
	/// can incorrectly report that the operation is complete.
	/// </para>
	/// <para>
	/// If hNamedPipe was opened with FILE_FLAG_OVERLAPPED and lpOverlapped is not <c>NULL</c>, <c>TransactNamedPipe</c> is executed as
	/// an overlapped operation. The <c>OVERLAPPED</c> structure should contain a manual-reset event object (which can be created by
	/// using the <c>CreateEvent</c> function). If the operation cannot be completed immediately, <c>TransactNamedPipe</c> returns
	/// <c>FALSE</c> and <c>GetLastError</c> returns ERROR_IO_PENDING. In this situation, the event object is set to the nonsignaled
	/// state before <c>TransactNamedPipe</c> returns, and it is set to the signaled state when the transaction has finished. Also, you
	/// can be notified when an overlapped operation completes by using the <c>GetQueuedCompletionStatus</c> or
	/// <c>GetQueuedCompletionStatusEx</c> functions. In this case, you do not need to assign the manual-reset event in the
	/// <c>OVERLAPPED</c> structure, and the completion happens against hNamedPipe in the same way as an asynchronous read or write
	/// operation. For more information about overlapped operations, see Pipes.
	/// </para>
	/// <para>
	/// If hNamedPipe was not opened with FILE_FLAG_OVERLAPPED, <c>TransactNamedPipe</c> does not return until the operation is complete.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the message to be read is longer than the buffer specified by the nOutBufferSize parameter, <c>TransactNamedPipe</c> returns
	/// <c>FALSE</c> and the <c>GetLastError</c> function returns ERROR_MORE_DATA. The remainder of the message can be read by a
	/// subsequent call to <c>ReadFile</c>, <c>ReadFileEx</c>, or <c>PeekNamedPipe</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI TransactNamedPipe( _In_ HANDLE hNamedPipe, _In_ LPVOID lpInBuffer, _In_ DWORD nInBufferSize, _Out_ LPVOID lpOutBuffer,
	// _In_ DWORD nOutBufferSize, _Out_ LPDWORD lpBytesRead, _Inout_opt_ LPOVERLAPPED lpOverlapped); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365790(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa365790")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern unsafe bool TransactNamedPipe([In] HPIPE hNamedPipe, [In] IntPtr lpInBuffer, uint nInBufferSize, [Out] IntPtr lpOutBuffer,
		uint nOutBufferSize, out uint lpBytesRead, [Optional] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// Waits until either a time-out interval elapses or an instance of the specified named pipe is available for connection (that is,
	/// the pipe's server process has a pending <c>ConnectNamedPipe</c> operation on the pipe).
	/// </summary>
	/// <param name="lpNamedPipeName">
	/// <para>
	/// The name of the named pipe. The string must include the name of the computer on which the server process is executing. A period
	/// may be used for the servername if the pipe is local. The following pipe name format is used:
	/// </para>
	/// <para>\\servername\pipe\pipename</para>
	/// </param>
	/// <param name="nTimeOut">
	/// <para>
	/// The number of milliseconds that the function will wait for an instance of the named pipe to be available. You can used one of the
	/// following values instead of specifying a number of milliseconds.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NMPWAIT_USE_DEFAULT_WAIT0x00000000</term>
	/// <term>The time-out interval is the default value specified by the server process in the CreateNamedPipe function.</term>
	/// </item>
	/// <item>
	/// <term>NMPWAIT_WAIT_FOREVER0xffffffff</term>
	/// <term>The function does not return until an instance of the named pipe is available.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If an instance of the pipe is available before the time-out interval elapses, the return value is nonzero.</para>
	/// <para>
	/// If an instance of the pipe is not available before the time-out interval elapses, the return value is zero. To get extended error
	/// information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI WaitNamedPipe( _In_ LPCTSTR lpNamedPipeName, _In_ DWORD nTimeOut); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365800(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("namedpipeapi.h", MSDNShortId = "aa365800")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WaitNamedPipe(string lpNamedPipeName, uint nTimeOut);
}