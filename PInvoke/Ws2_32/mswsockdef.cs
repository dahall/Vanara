global using PRIO_BUF = System.IntPtr;
global using RIO_BUFFERID = System.IntPtr;
global using RIO_CQ = System.IntPtr;
global using RIO_RQ = System.IntPtr;

using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Ws2_32
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const int RIO_MAX_CQ_SIZE = 0x8000000;
	public static readonly RIO_CQ RIO_CORRUPT_CQ = (RIO_CQ)unchecked((int)0xFFFFFFFF);
	public static readonly RIO_BUFFERID RIO_INVALID_BUFFERID = (RIO_BUFFERID)unchecked((int)0xFFFFFFFF);
	public static readonly RIO_CQ RIO_INVALID_CQ = (RIO_CQ)0;
	public static readonly RIO_RQ RIO_INVALID_RQ = (RIO_RQ)0;
	public static readonly uint SIO_SET_COMPATIBILITY_MODE = _WSAIOW(IOC_VENDOR, 300);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>A set of flags that modify the behavior of the <c>RIOSendEx</c> function.</summary>
	[PInvokeData("mswsockdef.h", MSDNShortId = "NC:mswsock.LPFN_RIORECEIVE")]
	[Flags]
	public enum RIO_MSG
	{
		/// <summary>
		/// The request should not trigger the <c>RIONotify</c> function when request completion is inserted into its completion queue.
		/// </summary>
		RIO_MSG_DONT_NOTIFY = 0x00000001,

		/// <summary>
		/// <para>
		/// The request does not need to be executed immediately. This will insert the request into the request queue, but it may or may not
		/// trigger the execution of the request.
		/// </para>
		/// <para>
		/// Sending data may be delayed until a send request is made on the <c>RIO_RQ</c> passed in the <c>SocketQueue</c> parameter without
		/// the <c>RIO_MSG_DEFER</c> flag set. To trigger execution for all sends in a send queue, call the <c>RIOSend</c> or
		/// <c>RIOSendEx</c> function without the <c>RIO_MSG_DEFER</c> flag set. <c>Note</c> The send request is charged against the
		/// outstanding I/O capacity on the <c>RIO_RQ</c> passed in the <c>SocketQueue</c> parameter regardless of whether
		/// <c>RIO_MSG_DEFER</c> is set.
		/// </para>
		/// </summary>
		RIO_MSG_DEFER = 0x00000002,

		/// <summary>
		/// Causes the recv call to only complete when the buffer slice supplied is full, an error occurs, or the connection is terminated.
		/// </summary>
		RIO_MSG_WAITALL = 0x00000004,

		/// <summary>
		/// <para>Previous requests added with <c>RIO_MSG_DEFER</c> flag will be committed.</para>
		/// <para>
		/// When the <c>RIO_MSG_COMMIT_ONLY</c> flag is set, no other flags may be specified. When the <c>RIO_MSG_COMMIT_ONLY</c> flag is
		/// set, the <c>pData</c>, <c>pLocalAddress</c>, <c>pRemoteAddress</c>, <c>pControlContext</c>, <c>pFlags</c>, and
		/// <c>RequestContext</c> parameters must be NULL and the <c>DataBufferCount</c> parameter must be zero.
		/// </para>
		/// <para>
		/// This flag would normally be used occasionally after a number of requests were issued with the <c>RIO_MSG_DEFER</c> flag set. This
		/// eliminates the need when using the <c>RIO_MSG_DEFER</c> flag to make the last request without the <c>RIO_MSG_DEFER</c> flag,
		/// which causes the last request to complete much slower than other requests.
		/// </para>
		/// <para>
		/// Unlike other calls to the <c>RIOSendEx</c> function, when the <c>RIO_MSG_COMMIT_ONLY</c> flag is set calls to the
		/// <c>RIOSendEx</c> function do not need to be serialized. For a single <c>RIO_RQ</c>, the <c>RIOSendEx</c> function can be called
		/// with <c>RIO_MSG_COMMIT_ONLY</c> on one thread while calling the <c>RIOSendEx</c> function on another thread.
		/// </para>
		/// </summary>
		RIO_MSG_COMMIT_ONLY = 0x00000008,
	}

	/// <summary>
	/// The <c>RIO_BUF</c> structure specifies a portion of a registered buffer used for sending or receiving network data with the Winsock
	/// registered I/O extensions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The Winsock registered I/O extensions often operate on portions of registered buffers sometimes called buffer slices. The
	/// <c>RIO_BUF</c> structure is used by an application that needs to use a small amount of registered memory for sending or receiving
	/// network data. The application can often increase performance by registering one large buffer and then using small chunks of the
	/// buffer as needed. The <c>RIO_BUF</c> structure may describe any contiguous segment of memory contained in a single buffer registration.
	/// </para>
	/// <para>
	/// A pointer to a <c>RIO_BUF</c> structure is passed as the <c>pData</c> parameter to the RIOSend, RIOSendEx, RIOReceive, and
	/// RIOReceiveEx functions to send or receive network data.
	/// </para>
	/// <para>
	/// An application cannot resize a registered buffer simply by using a buffer slice with values larger than the original buffer that was
	/// registered using the RIORegisterBuffer function.
	/// </para>
	/// <para>
	/// The <c>RIO_BUF</c> structure is defined in the <c>Mswsockdef.h</c> header file which is automatically included in the
	/// <c>Mswsock.h</c> header file. The <c>Mswsockdef.h</c> header file should never be used directly.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsockdef/ns-mswsockdef-rio_buf typedef struct _RIO_BUF { RIO_BUFFERID BufferId;
	// ULONG Offset; ULONG Length; } RIO_BUF, *PRIO_BUF;
	[PInvokeData("mswsockdef.h", MSDNShortId = "NS:mswsockdef._RIO_BUF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RIO_BUF
	{
		/// <summary>The registered buffer descriptor for a Winsock registered I/O buffer used with send and receive requests.</summary>
		public RIO_BUFFERID BufferId;

		/// <summary>
		/// The offset, in bytes, into the buffer specified by the <c>BufferId</c> member. An <c>Offset</c> value of zero points to the
		/// beginning of the buffer
		/// </summary>
		public uint Offset;

		/// <summary>A length, in bytes, of the buffer to use from the <c>Offset</c> member.</summary>
		public uint Length;
	}

	/// <summary>
	/// The <c>RIORESULT</c> structure contains data used to indicate request completion results used with the Winsock registered I/O extensions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>RIORESULT</c> structure defines the data format used to indicate request completion by the Winsock registered I/O extensions.
	/// An application requests completion indications by allocating an array of <c>RIORESULT</c> structures and passing the array of
	/// <c>RIORESULT</c> structures to the RIODequeueCompletion function along with the element count. The application need not perform any
	/// initialization of the <c>RIORESULT</c> structure elements before calling the <c>RIODequeueCompletion</c> function.
	/// </para>
	/// <para>
	/// The <c>SocketContext</c> member of the <c>RIORESULT</c> structure can be used by an application to identify the RIO_CQ object or the
	/// associated application object on which the Winsock registered I/O request was issued. The <c>RequestContext</c> member of the
	/// <c>RIORESULT</c> structure can similarly be used to identify the particular Winsock registered I/O request that was completed.
	/// </para>
	/// <para>
	/// The <c>RIORESULT</c> structure is defined in the <c>Mswsockdef.h</c> header file which is automatically included in the
	/// <c>Mswsock.h</c> header file. The <c>Mswsockdef.h</c> header file should never be used directly.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsockdef/ns-mswsockdef-rioresult typedef struct _RIORESULT { LONG Status; ULONG
	// BytesTransferred; ULONGLONG SocketContext; ULONGLONG RequestContext; } RIORESULT, *PRIORESULT;
	[PInvokeData("mswsockdef.h", MSDNShortId = "NS:mswsockdef._RIORESULT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RIORESULT
	{
		/// <summary>The completion status of the Winsock registered I/O request.</summary>
		public int Status;

		/// <summary>The number of bytes sent or received in the I/O request.</summary>
		public uint BytesTransferred;

		/// <summary>An application-provided context specified in call to the RIOCreateRequestQueue function.</summary>
		public ulong SocketContext;

		/// <summary>
		/// An application-provided context specified with the registered I/O request to the RIOReceive, RIOReceiveEx, RIOSend, and RIOSendEx functions.
		/// </summary>
		public ulong RequestContext;
	}
}