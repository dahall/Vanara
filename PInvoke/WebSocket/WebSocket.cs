using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the WebSocket.dll.</summary>
public static partial class WebSocket
{
	/// <summary/>
	public const int WEB_SOCKET_MAX_CLOSE_REASON_LENGTH = 123;
	private const string Lib_Websocket = "websocket.dll";

	/// <summary>The <c>WEB_SOCKET_ACTION</c> enumeration specifies actions to be taken by WebSocket applications.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ne-websocket-web_socket_action typedef enum _WEB_SOCKET_ACTION {
	// WEB_SOCKET_NO_ACTION = 0, WEB_SOCKET_SEND_TO_NETWORK_ACTION = 1, WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION = 2,
	// WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION = 3, WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION = 4 } WEB_SOCKET_ACTION, *PWEB_SOCKET_ACTION;
	[PInvokeData("websocket.h", MSDNShortId = "NE:websocket._WEB_SOCKET_ACTION")]
	public enum WEB_SOCKET_ACTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>There are no actions to process.</para>
		/// </summary>
		WEB_SOCKET_NO_ACTION = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates the application should send the buffers to a network.</para>
		/// </summary>
		WEB_SOCKET_SEND_TO_NETWORK_ACTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Indicates the operation queued by WebSocketSend is complete. The application context returned by WebSocketCompleteAction for this
		/// send operation is no longer needed, therefore it should be freed.
		/// </para>
		/// </summary>
		WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates the application should fill the buffers with data from a network.</para>
		/// </summary>
		WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// Indicates the operation queued by WebSocketReceive is complete. The application context returned by WebSocketCompleteAction for
		/// this receive operation is no longer needed, therefore it should be freed.
		/// </para>
		/// </summary>
		WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION,
	}

	/// <summary>The <c>WEB_SOCKET_ACTION_QUEUE</c> enumeration specifies the action types returned by WebSocketGetAction.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ne-websocket-web_socket_action_queue typedef enum
	// _WEB_SOCKET_ACTION_QUEUE { WEB_SOCKET_SEND_ACTION_QUEUE = 0x1, WEB_SOCKET_RECEIVE_ACTION_QUEUE = 0x2, WEB_SOCKET_ALL_ACTION_QUEUE } WEB_SOCKET_ACTION_QUEUE;
	[PInvokeData("websocket.h", MSDNShortId = "NE:websocket._WEB_SOCKET_ACTION_QUEUE")]
	[Flags]
	public enum WEB_SOCKET_ACTION_QUEUE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>WebSocketGetAction</para>
		/// <para>will return only send-related actions.</para>
		/// </summary>
		WEB_SOCKET_SEND_ACTION_QUEUE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>WebSocketGetAction</para>
		/// <para>will return receive-related actions as well as internal send actions (reply to a ping frame).</para>
		/// </summary>
		WEB_SOCKET_RECEIVE_ACTION_QUEUE = 0x2,

		/// <summary>
		/// <para>WebSocketGetAction</para>
		/// <para>will return all actions.</para>
		/// </summary>
		WEB_SOCKET_ALL_ACTION_QUEUE = 0x3,
	}

	/// <summary>The <c>WEB_SOCKET_BUFFER_TYPE</c> enumeration specifies the bit values used to construct the WebSocket frame header.</summary>
	/// <remarks>
	/// <para>
	/// Please note that the FRAGMENT and MESSAGE buffer types may not correspond to how the message appears (or is framed) on the wire. For
	/// example, when a single unfragmented 1000-byte message is received, WebSocket.dll may return multiple FRAGMENT buffer types followed
	/// by a single MESSAGE buffer type (with the sizes adding up to 1000).
	/// </para>
	/// <para>
	/// Extension WebSocket frame headers (allowing reserved bits to be set by extensions) may be constructed by setting the high bit (MSB)
	/// and low bit (LSB) to 0. The remaining 9 lowest bits can then be used to form the custom frame header in place of the
	/// <c>WEB_SOCKET_BUFFER_TYPE</c> enumeration values.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ne-websocket-web_socket_buffer_type typedef enum _WEB_SOCKET_BUFFER_TYPE
	// { WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE = 0x80000000, WEB_SOCKET_UTF8_FRAGMENT_BUFFER_TYPE = 0x80000001,
	// WEB_SOCKET_BINARY_MESSAGE_BUFFER_TYPE = 0x80000002, WEB_SOCKET_BINARY_FRAGMENT_BUFFER_TYPE = 0x80000003, WEB_SOCKET_CLOSE_BUFFER_TYPE
	// = 0x80000004, WEB_SOCKET_PING_PONG_BUFFER_TYPE = 0x80000005, WEB_SOCKET_UNSOLICITED_PONG_BUFFER_TYPE = 0x80000006 } WEB_SOCKET_BUFFER_TYPE;
	[PInvokeData("websocket.h", MSDNShortId = "NE:websocket._WEB_SOCKET_BUFFER_TYPE")]
	public enum WEB_SOCKET_BUFFER_TYPE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000000</para>
		/// <para>Indicates the buffer contains the last, and possibly only, part of a UTF8 message.</para>
		/// </summary>
		WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE = 0x80000000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000001</para>
		/// <para>Indicates the buffer contains part of a UTF8 message.</para>
		/// </summary>
		WEB_SOCKET_UTF8_FRAGMENT_BUFFER_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000002</para>
		/// <para>Indicates the buffer contains the last, and possibly only, part of a binary message.</para>
		/// </summary>
		WEB_SOCKET_BINARY_MESSAGE_BUFFER_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000003</para>
		/// <para>Indicates the buffer contains part of a binary message.</para>
		/// </summary>
		WEB_SOCKET_BINARY_FRAGMENT_BUFFER_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000004</para>
		/// <para>Indicates the buffer contains a close message.</para>
		/// </summary>
		WEB_SOCKET_CLOSE_BUFFER_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000005</para>
		/// <para>
		/// Indicates the buffer contains a ping or pong message. When sending, this value means 'ping', when processing received data, this
		/// value means 'pong'.
		/// </para>
		/// </summary>
		WEB_SOCKET_PING_PONG_BUFFER_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x80000006</para>
		/// <para>Indicates the buffer contains an unsolicited pong message.</para>
		/// </summary>
		WEB_SOCKET_UNSOLICITED_PONG_BUFFER_TYPE,
	}

	/// <summary>The <c>WEB_SOCKET_CLOSE_STATUS</c> enumeration specifies the WebSocket close status as defined by WSPROTO.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ne-websocket-web_socket_close_status typedef enum
	// _WEB_SOCKET_CLOSE_STATUS { WEB_SOCKET_SUCCESS_CLOSE_STATUS = 1000, WEB_SOCKET_ENDPOINT_UNAVAILABLE_CLOSE_STATUS = 1001,
	// WEB_SOCKET_PROTOCOL_ERROR_CLOSE_STATUS = 1002, WEB_SOCKET_INVALID_DATA_TYPE_CLOSE_STATUS = 1003, WEB_SOCKET_EMPTY_CLOSE_STATUS = 1005,
	// WEB_SOCKET_ABORTED_CLOSE_STATUS = 1006, WEB_SOCKET_INVALID_PAYLOAD_CLOSE_STATUS = 1007, WEB_SOCKET_POLICY_VIOLATION_CLOSE_STATUS =
	// 1008, WEB_SOCKET_MESSAGE_TOO_BIG_CLOSE_STATUS = 1009, WEB_SOCKET_UNSUPPORTED_EXTENSIONS_CLOSE_STATUS = 1010,
	// WEB_SOCKET_SERVER_ERROR_CLOSE_STATUS = 1011, WEB_SOCKET_SECURE_HANDSHAKE_ERROR_CLOSE_STATUS = 1015 } WEB_SOCKET_CLOSE_STATUS;
	[PInvokeData("websocket.h", MSDNShortId = "NE:websocket._WEB_SOCKET_CLOSE_STATUS")]
	public enum WEB_SOCKET_CLOSE_STATUS : ushort
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1000</para>
		/// <para>Close completed successfully.</para>
		/// </summary>
		WEB_SOCKET_SUCCESS_CLOSE_STATUS = 1000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1001</para>
		/// <para>The endpoint is going away and thus closing the connection.</para>
		/// </summary>
		WEB_SOCKET_ENDPOINT_UNAVAILABLE_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1002</para>
		/// <para>Peer detected protocol error and it is closing the connection.</para>
		/// </summary>
		WEB_SOCKET_PROTOCOL_ERROR_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1003</para>
		/// <para>The endpoint cannot receive this type of data.</para>
		/// </summary>
		WEB_SOCKET_INVALID_DATA_TYPE_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1005</para>
		/// <para>No close status</para>
		/// <para>code was provided.</para>
		/// </summary>
		WEB_SOCKET_EMPTY_CLOSE_STATUS = 1005,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1006</para>
		/// <para>The</para>
		/// <para>connection was closed without sending or</para>
		/// <para>receiving a close frame.</para>
		/// </summary>
		WEB_SOCKET_ABORTED_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1007</para>
		/// <para>Data within a message is not consistent with the type of the message.</para>
		/// </summary>
		WEB_SOCKET_INVALID_PAYLOAD_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1008</para>
		/// <para>The message violates an endpoint's policy.</para>
		/// </summary>
		WEB_SOCKET_POLICY_VIOLATION_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1009</para>
		/// <para>The message sent was too large to process.</para>
		/// </summary>
		WEB_SOCKET_MESSAGE_TOO_BIG_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1010</para>
		/// <para>
		/// A client endpoint expected the server to negotiate one or more extensions, but the server didn't return them in the response
		/// message of the WebSocket handshake.
		/// </para>
		/// </summary>
		WEB_SOCKET_UNSUPPORTED_EXTENSIONS_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1011</para>
		/// <para>An unexpected condition prevented the server from</para>
		/// <para>fulfilling the request.</para>
		/// </summary>
		WEB_SOCKET_SERVER_ERROR_CLOSE_STATUS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1015</para>
		/// <para>The</para>
		/// <para>TLS handshake could not be completed.</para>
		/// </summary>
		WEB_SOCKET_SECURE_HANDSHAKE_ERROR_CLOSE_STATUS = 1015,
	}

	/// <summary>The <c>WEB_SOCKET_PROPERTY_TYPE</c> enumeration specifies a WebSocket property type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ne-websocket-web_socket_property_type typedef enum
	// _WEB_SOCKET_PROPERTY_TYPE { WEB_SOCKET_RECEIVE_BUFFER_SIZE_PROPERTY_TYPE = 0, WEB_SOCKET_SEND_BUFFER_SIZE_PROPERTY_TYPE = 1,
	// WEB_SOCKET_DISABLE_MASKING_PROPERTY_TYPE = 2, WEB_SOCKET_ALLOCATED_BUFFER_PROPERTY_TYPE = 3,
	// WEB_SOCKET_DISABLE_UTF8_VERIFICATION_PROPERTY_TYPE = 4, WEB_SOCKET_KEEPALIVE_INTERVAL_PROPERTY_TYPE = 5,
	// WEB_SOCKET_SUPPORTED_VERSIONS_PROPERTY_TYPE = 6 } WEB_SOCKET_PROPERTY_TYPE;
	[PInvokeData("websocket.h", MSDNShortId = "NE:websocket._WEB_SOCKET_PROPERTY_TYPE")]
	public enum WEB_SOCKET_PROPERTY_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Property type:</para>
		/// <para>ULONG</para>
		/// <para>The WebSocket property is the internal receive buffer size. The buffer cannot be smaller than 256 bytes.</para>
		/// <para>The default is 4096.</para>
		/// <para>Used with WebSocketCreateClientHandle and WebSocketCreateServerHandle.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		WEB_SOCKET_RECEIVE_BUFFER_SIZE_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Property type:</para>
		/// <para>ULONG</para>
		/// <para>The WebSocket property is the internal send buffer size. The buffer cannot be smaller than 256 bytes.</para>
		/// <para>The default is 4096 on a handle created with WebSocketCreateClientHandle, and 16 on a handle created with WebSocketCreateServerHandle.</para>
		/// <para>Used with WebSocketCreateClientHandle and WebSocketCreateServerHandle.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		WEB_SOCKET_SEND_BUFFER_SIZE_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Property type:</para>
		/// <para>BOOL</para>
		/// <para>
		/// The WebSocket property is the disabling of the mask bit in client frames. On the client, this property sets the mask key to 0. On
		/// the server, this property allows the server to accept client frames with the mask bit set to 0. This property may have serious
		/// security implications.
		/// </para>
		/// <para>By default, this property is not used and masking is enabled.</para>
		/// <para>Used with WebSocketCreateClientHandle and WebSocketCreateServerHandle.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		WEB_SOCKET_DISABLE_MASKING_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Property type:</para>
		/// <para>PVOID</para>
		/// <para>
		/// The WebSocket property is the buffer that is used as an internal buffer. If the passed buffer is not used, the WebSocket library
		/// will take care of buffer management.
		/// </para>
		/// <para>
		/// The passed buffer must be aligned to an 8-byte boundary and be greater in size than the receive buffer size + send buffer size +
		/// 256 bytes.
		/// </para>
		/// <para>Used with WebSocketCreateClientHandle and WebSocketCreateServerHandle.</para>
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		WEB_SOCKET_ALLOCATED_BUFFER_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Property type:</para>
		/// <para>BOOL</para>
		/// <para>The WebSocket property disables UTF-8 verification.</para>
		/// <para>Used with WebSocketCreateClientHandle and WebSocketCreateServerHandle.</para>
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		WEB_SOCKET_DISABLE_UTF8_VERIFICATION_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Property type:</para>
		/// <para>ULONG</para>
		/// <para>
		/// The WebSocket property is the interval, in milliseconds, to send a keep-alive packet over the connection. The default interval is
		/// 30000 (30 seconds). The minimum interval is 15000 (15 seconds).
		/// </para>
		/// <note type="note">The default value for the keep-alive interval is read from
		/// <c>HKLM:\SOFTWARE\Microsoft\WebSocket\KeepaliveInterval</c>. If a value is not set, the default value of 30000 will be used. It
		/// is not possible to have a lower keepalive interval than 15000 milliseconds. If a lower value is set, 15000 milliseconds will be used.</note>
		/// <para>Used with WebSocketGetGlobalProperty.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		WEB_SOCKET_KEEPALIVE_INTERVAL_PROPERTY_TYPE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Property type:</para>
		/// <para>ULONG array</para>
		/// <para>The WebSocket property is the versions of the WebSocket protocol that are supported.</para>
		/// <para>Used with WebSocketGetGlobalProperty.</para>
		/// </summary>
		[CorrespondingType(typeof(uint[]))]
		WEB_SOCKET_SUPPORTED_VERSIONS_PROPERTY_TYPE,
	}

	/// <summary>
	/// The <c>WebSocketAbortHandle</c> function aborts a WebSocket session handle created by WebSocketCreateClientHandle or WebSocketCreateServerHandle.
	/// </summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <c>WebSocketAbortHandle</c> aborts a WEB_SOCKET_HANDLE session handle and any calls to WebSocketSend or WebSocketReceive will return
	/// error when called with an aborted handle. <c>WebSocketAbortHandle</c> is a no-op if the WebSocket handshake has not been completed
	/// and the session handle has not been initialized. Any send/receive operations that were queued using <c>WebSocketSend</c> or
	/// <c>WebSocketReceive</c> will be ready to process using WebSocketGetAction, but attempts to queue additional operations using the
	/// aborted handle will result in error.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketaborthandle void WebSocketAbortHandle( [in]
	// WEB_SOCKET_HANDLE hWebSocket );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketAbortHandle")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern void WebSocketAbortHandle([In] WEB_SOCKET_HANDLE hWebSocket);

	/// <summary>The <c>WebSocketBeginClientHandshake</c> function begins the client-side handshake.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle.</para>
	/// </param>
	/// <param name="pszSubprotocols">
	/// <para>Type: <c>PCSTR*</c></para>
	/// <para>
	/// Pointer to an array of sub-protocols chosen by the application. Once the client-server handshake is complete, the application must
	/// use the sub-protocol returned by WebSocketEndClientHandshake. Must contain one subprotocol per entry.
	/// </para>
	/// </param>
	/// <param name="ulSubprotocolCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of sub-protocols in <c>pszSubprotocols</c>.</para>
	/// </param>
	/// <param name="pszExtensions">
	/// <para>Type: <c>PCSTR*</c></para>
	/// <para>
	/// Pointer to an array of extensions chosen by the application. Once the client-server handshake is complete, the application must use
	/// the extension returned by WebSocketEndClientHandshake. Must contain one extension per entry.
	/// </para>
	/// </param>
	/// <param name="ulExtensionCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of extensions in <c>pszExtensions</c>.</para>
	/// </param>
	/// <param name="pInitialHeaders">
	/// <para>Type: <c>const PWEB_SOCKET_HTTP_HEADER</c></para>
	/// <para>
	/// Pointer to an array of WEB_SOCKET_HTTP_HEADER structures that contain the request headers to be sent by the application. The array
	/// must include the <c>Host HTTP</c> header as defined in RFC 2616.
	/// </para>
	/// </param>
	/// <param name="ulInitialHeaderCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of request headers in <c>pInitialHeaders</c>.</para>
	/// </param>
	/// <param name="pAdditionalHeaders">
	/// <para>Type: <c>PWEB_SOCKET_HTTP_HEADER</c></para>
	/// <para>
	/// On successful output, pointer to an array of WEB_SOCKET_HTTP_HEADER structures that contain the request headers to be sent by the
	/// application. If any of these headers were specified in <c>pInitialHeaders</c>, the header must be replaced.
	/// </para>
	/// </param>
	/// <param name="pulAdditionalHeaderCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>On successful output, number of response headers in <c>pAdditionalHeaders</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// To complete the client-side handshake, applications must call WebSocketEndClientHandshake. Once the client-server handshake is
	/// complete, the application may use the session functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketbeginclienthandshake HRESULT
	// WebSocketBeginClientHandshake( [in] WEB_SOCKET_HANDLE hWebSocket, [in, optional] PCSTR *pszSubprotocols, [in] ULONG
	// ulSubprotocolCount, [in, optional] PCSTR *pszExtensions, [in] ULONG ulExtensionCount, [in, optional] const PWEB_SOCKET_HTTP_HEADER
	// pInitialHeaders, [in] ULONG ulInitialHeaderCount, [out] PWEB_SOCKET_HTTP_HEADER *pAdditionalHeaders, [out] ULONG
	// *pulAdditionalHeaderCount );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketBeginClientHandshake")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketBeginClientHandshake([In] WEB_SOCKET_HANDLE hWebSocket, [In, Optional, MarshalAs(UnmanagedType.LPStr)] string pszSubprotocols,
		[Optional] uint ulSubprotocolCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string pszExtensions, [Optional] uint ulExtensionCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] WEB_SOCKET_HTTP_HEADER[] pInitialHeaders, [Optional] uint ulInitialHeaderCount,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)] out WEB_SOCKET_HTTP_HEADER[] pAdditionalHeaders, out uint pulAdditionalHeaderCount);

	/// <summary>The <c>WebSocketBeginServerHandshake</c> function begins the server-side handshake.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateServerHandle.</para>
	/// </param>
	/// <param name="pszSubprotocolSelected">
	/// <para>Type: <c>PCSTR</c></para>
	/// <para>A pointer to a sub-protocol value chosen by the application. Must contain one subprotocol.</para>
	/// </param>
	/// <param name="pszExtensionSelected">
	/// <para>Type: <c>PCSTR*</c></para>
	/// <para>A pointer to a list of extensions chosen by the application. Must contain one extension per entry.</para>
	/// </param>
	/// <param name="ulExtensionSelectedCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of extensions in <c>pszExtensionSelected</c>.</para>
	/// </param>
	/// <param name="pRequestHeaders">
	/// <para>Type: <c>const PWEB_SOCKET_HTTP_HEADER</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_HTTP_HEADER structures that contain the request headers received by the application.</para>
	/// </param>
	/// <param name="ulRequestHeaderCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of request headers in <c>pRequestHeaders</c>.</para>
	/// </param>
	/// <param name="pResponseHeaders">
	/// <para>Type: <c>PWEB_SOCKET_HTTP_HEADER*</c></para>
	/// <para>
	/// On successful output, a pointer to an array or WEB_SOCKET_HTTP_HEADER structures that contain the response headers to be sent by the application.
	/// </para>
	/// </param>
	/// <param name="pulResponseHeaderCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>On successful output, number of response headers in <c>pResponseHeaders</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_FORMAT</c></term>
	/// <term>Protocol data had an invalid format.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To complete the server-side handshake, applications must call WebSocketEndServerHandshake or any of the session functions. Once the
	/// client-server handshake is complete, the application may use the session functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketbeginserverhandshake HRESULT
	// WebSocketBeginServerHandshake( [in] WEB_SOCKET_HANDLE hWebSocket, [in, optional] PCSTR pszSubprotocolSelected, [in, optional] PCSTR
	// *pszExtensionSelected, [in] ULONG ulExtensionSelectedCount, [in] const PWEB_SOCKET_HTTP_HEADER pRequestHeaders, [in] ULONG
	// ulRequestHeaderCount, [out] PWEB_SOCKET_HTTP_HEADER *pResponseHeaders, [out] ULONG *pulResponseHeaderCount );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketBeginServerHandshake")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketBeginServerHandshake([In] WEB_SOCKET_HANDLE hWebSocket,
		[In, Optional, MarshalAs(UnmanagedType.LPStr)] string pszSubprotocolSelected,
		[In, Optional, MarshalAs(UnmanagedType.LPStr)] string pszExtensionSelected, [Optional] uint ulExtensionSelectedCount,
		[In, MarshalAs(UnmanagedType.LPArray)] WEB_SOCKET_HTTP_HEADER[] pRequestHeaders, uint ulRequestHeaderCount,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] out WEB_SOCKET_HTTP_HEADER[] pResponseHeaders, out uint pulResponseHeaderCount);

	/// <summary>The <c>WebSocketCompleteAction</c> function completes an action started by WebSocketGetAction.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <param name="pvActionContext">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Pointer to an action context handle that was returned by a previous call to WebSocketGetAction.</para>
	/// </param>
	/// <param name="ulBytesTransferred">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>
	/// Number of bytes transferred for the WEB_SOCKET_SEND_TO_NETWORK_ACTION or <c>WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION</c> actions. This
	/// value must be 0 for all other actions.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each call to WebSocketGetAction must be paired with a call to <c>WebSocketCompleteAction</c>. For the following network actions, I/O
	/// errors can occur:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// WEB_SOCKET_SEND_TO_NETWORK_ACTION: if <c>ulBytesTransferred</c> is different than the sum all buffer lengths returned from
	///                                    WebSocketGetAction the current send action is canceled and the next call to
	///                                    <c>WebSocketGetAction</c> will return <c>WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION</c> even if not
	///                                    all buffers passed to WebSocketSend were processed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION: if <c>ulBytesTransferred</c> is 0, the current receive action is canceled and the next call
	///                                         to WebSocketGetAction will return <c>WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION</c> even if
	///                                         not all buffers passed to WebSocketReceive were processed.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketcompleteaction void WebSocketCompleteAction( [in]
	// WEB_SOCKET_HANDLE hWebSocket, [in] PVOID pvActionContext, [in] ULONG ulBytesTransferred );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketCompleteAction")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern void WebSocketCompleteAction([In] WEB_SOCKET_HANDLE hWebSocket, [In] IntPtr pvActionContext,
		uint ulBytesTransferred);

	/// <summary>The <c>WebSocketCreateClientHandle</c> function creates a client-side WebSocket session handle.</summary>
	/// <param name="pProperties">
	/// <para>Type: <c>const PWEB_SOCKET_PROPERTY</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_PROPERTY structures that contain WebSocket session-related properties.</para>
	/// </param>
	/// <param name="ulPropertyCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of properties in <c>pProperties</c>.</para>
	/// </param>
	/// <param name="phWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE*</c></para>
	/// <para>On successful output, pointer to a newly allocated client-side WebSocket session handle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketcreateclienthandle HRESULT
	// WebSocketCreateClientHandle( [in] const PWEB_SOCKET_PROPERTY pProperties, [in] ULONG ulPropertyCount, [out] WEB_SOCKET_HANDLE
	// *phWebSocket );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketCreateClientHandle")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketCreateClientHandle(
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] WEB_SOCKET_PROPERTY[] pProperties,
		uint ulPropertyCount, out SafeWEB_SOCKET_HANDLE phWebSocket);

	/// <summary>The <c>WebSocketCreateServerHandle</c> function creates a server-side WebSocket session handle.</summary>
	/// <param name="pProperties">
	/// <para>Type: <c>const PWEB_SOCKET_PROPERTY</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_PROPERTY structures that contain WebSocket session-related properties.</para>
	/// </param>
	/// <param name="ulPropertyCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of properties in <c>pProperties</c>.</para>
	/// </param>
	/// <param name="phWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE*</c></para>
	/// <para>On successful output, pointer to a newly allocated server-side WebSocket session handle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketcreateserverhandle HRESULT
	// WebSocketCreateServerHandle( [in] const PWEB_SOCKET_PROPERTY pProperties, [in] ULONG ulPropertyCount, [out] WEB_SOCKET_HANDLE
	// *phWebSocket );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketCreateServerHandle")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketCreateServerHandle(
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] WEB_SOCKET_PROPERTY[] pProperties,
		uint ulPropertyCount, out SafeWEB_SOCKET_HANDLE phWebSocket);

	/// <summary>
	/// The <c>WebSocketDeleteHandle</c> function deletes a WebSocket session handle created by WebSocketCreateClientHandle or WebSocketCreateServerHandle.
	/// </summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>Any use of a deleted WEB_SOCKET_HANDLE session handle may result in an access violation.</para>
	/// <para>
	/// Before an application deletes a session handle, it must ensure that all operations have been processed. Applications may use
	/// WebSocketAbortHandle to abort any queued operations before calling <c>WebSocketDeleteHandle</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketdeletehandle void WebSocketDeleteHandle( [in]
	// WEB_SOCKET_HANDLE hWebSocket );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketDeleteHandle")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern void WebSocketDeleteHandle([In] WEB_SOCKET_HANDLE hWebSocket);

	/// <summary>The <c>WebSocketEndClientHandshake</c> function completes the client-side handshake.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle.</para>
	/// </param>
	/// <param name="pResponseHeaders">
	/// <para>Type: <c>const PWEB_SOCKET_HTTP_HEADER</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_HTTP_HEADER structures that contain the response headers received by the application.</para>
	/// </param>
	/// <param name="ulReponseHeaderCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of response headers in <c>pResponseHeaders</c>.</para>
	/// </param>
	/// <param name="pulSelectedExtensions">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On input, pointer to an array allocated by the application. On successful output, pointer to an array of numbers that represent the
	/// extensions chosen by the server during the client-server handshake. These number are the zero-based indices into the extensions array
	/// passed to <c>pszExtensions</c> in WebSocketBeginClientHandshake.
	/// </para>
	/// </param>
	/// <param name="pulSelectedExtensionCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On input, number of extensions allocated in <c>pulSelectedExtensions</c>. This must be at least equal to the number passed to
	/// <c>ulExtensionCount</c> in <c>WebSocketEndClientHandshake</c>. On successful output, number of extensions returned in <c>pulSelectedExtensions</c>.
	/// </para>
	/// </param>
	/// <param name="pulSelectedSubprotocol">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On successful output, pointer to a number that represents the sub-protocol chosen by the server during the client-server handshake.
	/// This number is the zero-based index into the sub-protocols array passed to <c>pszSubprotocols</c> in WebSocketBeginClientHandshake.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_FORMAT</c></term>
	/// <term>Protocol data had an invalid format.</term>
	/// </item>
	/// <item>
	/// <term><c>E_UNSUPPORTED_SUBPROTOCOL</c></term>
	/// <term>Server does not accept any of the sub-protocols specified by the application.</term>
	/// </item>
	/// <item>
	/// <term><c>E_UNSUPPORTED_EXTENSION</c></term>
	/// <term>Server does not accept extensions specified by the application.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function must be called to complete the client-side handshake after a previous call to WebSocketBeginClientHandshake. Once the
	/// client-server handshake is complete, the application may use the session functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketendclienthandshake HRESULT
	// WebSocketEndClientHandshake( [in] WEB_SOCKET_HANDLE hWebSocket, [in] const PWEB_SOCKET_HTTP_HEADER pResponseHeaders, [in] ULONG
	// ulReponseHeaderCount, [in, out, optional] ULONG *pulSelectedExtensions, [in, out, optional] ULONG *pulSelectedExtensionCount, [in,
	// out, optional] ULONG *pulSelectedSubprotocol );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketEndClientHandshake")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketEndClientHandshake([In] WEB_SOCKET_HANDLE hWebSocket,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] WEB_SOCKET_HTTP_HEADER[] pResponseHeaders,
		uint ulReponseHeaderCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pulSelectedExtensions,
		ref uint pulSelectedExtensionCount, out uint pulSelectedSubprotocol);

	/// <summary>The <c>WebSocketEndClientHandshake</c> function completes the client-side handshake.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle.</para>
	/// </param>
	/// <param name="pResponseHeaders">
	/// <para>Type: <c>const PWEB_SOCKET_HTTP_HEADER</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_HTTP_HEADER structures that contain the response headers received by the application.</para>
	/// </param>
	/// <param name="ulReponseHeaderCount">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>Number of response headers in <c>pResponseHeaders</c>.</para>
	/// </param>
	/// <param name="pulSelectedExtensions">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On input, pointer to an array allocated by the application. On successful output, pointer to an array of numbers that represent the
	/// extensions chosen by the server during the client-server handshake. These number are the zero-based indices into the extensions array
	/// passed to <c>pszExtensions</c> in WebSocketBeginClientHandshake.
	/// </para>
	/// </param>
	/// <param name="pulSelectedExtensionCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On input, number of extensions allocated in <c>pulSelectedExtensions</c>. This must be at least equal to the number passed to
	/// <c>ulExtensionCount</c> in <c>WebSocketEndClientHandshake</c>. On successful output, number of extensions returned in <c>pulSelectedExtensions</c>.
	/// </para>
	/// </param>
	/// <param name="pulSelectedSubprotocol">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On successful output, pointer to a number that represents the sub-protocol chosen by the server during the client-server handshake.
	/// This number is the zero-based index into the sub-protocols array passed to <c>pszSubprotocols</c> in WebSocketBeginClientHandshake.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_FORMAT</c></term>
	/// <term>Protocol data had an invalid format.</term>
	/// </item>
	/// <item>
	/// <term><c>E_UNSUPPORTED_SUBPROTOCOL</c></term>
	/// <term>Server does not accept any of the sub-protocols specified by the application.</term>
	/// </item>
	/// <item>
	/// <term><c>E_UNSUPPORTED_EXTENSION</c></term>
	/// <term>Server does not accept extensions specified by the application.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function must be called to complete the client-side handshake after a previous call to WebSocketBeginClientHandshake. Once the
	/// client-server handshake is complete, the application may use the session functions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketendclienthandshake HRESULT
	// WebSocketEndClientHandshake( [in] WEB_SOCKET_HANDLE hWebSocket, [in] const PWEB_SOCKET_HTTP_HEADER pResponseHeaders, [in] ULONG
	// ulReponseHeaderCount, [in, out, optional] ULONG *pulSelectedExtensions, [in, out, optional] ULONG *pulSelectedExtensionCount, [in,
	// out, optional] ULONG *pulSelectedSubprotocol );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketEndClientHandshake")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketEndClientHandshake([In] WEB_SOCKET_HANDLE hWebSocket,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] WEB_SOCKET_HTTP_HEADER[] pResponseHeaders,
		uint ulReponseHeaderCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pulSelectedExtensions,
		[In, Optional] IntPtr pulSelectedExtensionCount, [In, Optional] IntPtr pulSelectedSubprotocol);

	/// <summary>The <c>WebSocketEndServerHandshake</c> function completes the server-side handshake.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateServerHandle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// This function may be called to complete the server-side handshake after a previous call to WebSocketBeginServerHandshake; however,
	/// calling this function is optional and applications may use the session functions without first calling this function. This function
	/// frees all internal handshake related structures and allocates data session buffers. All operations handled by this function will be
	/// performed internally even if the function is not called.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketendserverhandshake HRESULT
	// WebSocketEndServerHandshake( [in] WEB_SOCKET_HANDLE hWebSocket );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketEndServerHandshake")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketEndServerHandshake([In] WEB_SOCKET_HANDLE hWebSocket);

	/// <summary>The <c>WebSocketGetAction</c> function returns an action from a call to WebSocketSend, WebSocketReceive or WebSocketCompleteAction.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <param name="eActionQueue">
	/// <para>Type: <c>WEB_SOCKET_ACTION_QUEUE</c></para>
	/// <para>Enumeration that specifies whether to query the send queue, the receive queue, or both.</para>
	/// </param>
	/// <param name="pDataBuffers">
	/// <para>Type: <c>WEB_SOCKET_BUFFER*</c></para>
	/// <para>Pointer to an array of WEB_SOCKET_BUFFER structures that contain WebSocket buffer data.</para>
	/// <para>
	/// <c>Note</c> Do not allocate or deallocate memory for WEB_SOCKET_BUFFER structures, because they will be overwritten by
	/// <c>WebSocketGetAction</c>. The memory for buffers returned by <c>WebSocketGetAction</c> are managed by the library.
	/// </para>
	/// </param>
	/// <param name="pulDataBufferCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// On input, pointer to a value that specifies the number of elements in <c>pDataBuffers</c>. On successful output, number of elements
	/// that were actually returned in <c>pDataBuffers</c>.
	/// </para>
	/// </param>
	/// <param name="pAction">
	/// <para>Type: <c>WEB_SOCKET_ACTION*</c></para>
	/// <para>
	/// On successful output, pointer to a WEB_SOCKET_ACTION enumeration that specifies the action returned from the query to the queue
	/// defines in <c>eActionQueue</c>.
	/// </para>
	/// </param>
	/// <param name="pBufferType">
	/// <para>Type: <c>WEB_SOCKET_BUFFER_TYPE*</c></para>
	/// <para>
	/// On successful output, pointer to a WEB_SOCKET_BUFFER_TYPE enumeration that specifies the type of Web Socket buffer data returned in <c>pDataBuffers</c>.
	/// </para>
	/// </param>
	/// <param name="pvApplicationContext">
	/// <para>Type: <c>PVOID*</c></para>
	/// <para>
	/// On successful output, pointer to an application context handle. The context returned here was initially passed to WebSocketSend or
	/// WebSocketReceive. <c>pvApplicationContext</c> is not set if <c>pAction</c> is WEB_SOCKET_NO_ACTION or
	/// WEB_SOCKET_SEND_TO_NETWORK_ACTION when sending a pong in response to receiving a ping.
	/// </para>
	/// </param>
	/// <param name="pvActionContext">
	/// <para>Type: <c>PVOID*</c></para>
	/// <para>On successful output, pointer to an action context handle. This handle is passed into a subsequent call WebSocketCompleteAction.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_FORMAT</c></term>
	/// <term>Protocol data had invalid format. This is only returned for receive operations.</term>
	/// </item>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_OPERATION</c></term>
	/// <term>Protocol performed invalid operations. This is only returned for receive operations.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Each call to <c>WebSocketGetAction</c> must be paired with a call to WebSocketCompleteAction.</para>
	/// <para>
	/// If the <c>ulBytesTransferred</c> parameter of WebSocketCompleteAction is different than the sum of all buffer lengths for the
	/// WEB_SOCKET_SEND_TO_NETWORK_ACTION action or is zero for the <c>WEB_SOCKET_RECEIVE_FROM_NETWORK_ACTION</c> action, the WebSocket
	/// application will not send or receive all of the data requested.
	/// </para>
	/// <para><c>WebSocketGetAction</c> will return in <c>pAction</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WEB_SOCKET_INDICATE_SEND_COMPLETE_ACTION once an operation queued by WebSocketSend is completed.</term>
	/// </item>
	/// <item>
	/// <term>WEB_SOCKET_INDICATE_RECEIVE_COMPLETE_ACTION once an operation queued by WebSocketReceive is completed.</term>
	/// </item>
	/// </list>
	/// <para>
	/// There may be only one outstanding send and receive operation at a time, so the next action will be returned once the previous one has
	/// been completed using WebSocketCompleteAction.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketgetaction HRESULT WebSocketGetAction( [in]
	// WEB_SOCKET_HANDLE hWebSocket, [in] WEB_SOCKET_ACTION_QUEUE eActionQueue, [in, out] WEB_SOCKET_BUFFER *pDataBuffers, [in, out] ULONG
	// *pulDataBufferCount, [out] WEB_SOCKET_ACTION *pAction, [out] WEB_SOCKET_BUFFER_TYPE *pBufferType, [out, optional] PVOID
	// *pvApplicationContext, [out] PVOID *pvActionContext );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketGetAction")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketGetAction([In] WEB_SOCKET_HANDLE hWebSocket, [In] WEB_SOCKET_ACTION_QUEUE eActionQueue,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] WEB_SOCKET_BUFFER[] pDataBuffers,
		ref uint pulDataBufferCount, out WEB_SOCKET_ACTION pAction, out WEB_SOCKET_BUFFER_TYPE pBufferType,
		out IntPtr pvApplicationContext, out IntPtr pvActionContext);

	/// <summary>The <c>WebSocketGetGlobalProperty</c> function gets a single WebSocket property.</summary>
	/// <param name="eType">
	/// <para>Type: <c>WEB_SOCKET_PROPERTY</c></para>
	/// <para>A WebSocket property.</para>
	/// </param>
	/// <param name="pvValue">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A pointer to the property value. The pointer must have an alignment compatible with the type of the property.</para>
	/// </param>
	/// <param name="ulSize">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>The size, in bytes, of the property pointed to by <c>pvValue</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketgetglobalproperty HRESULT
	// WebSocketGetGlobalProperty( [in] WEB_SOCKET_PROPERTY_TYPE eType, [in, out] PVOID pvValue, [in, out] ULONG *ulSize );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketGetGlobalProperty")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketGetGlobalProperty([In] WEB_SOCKET_PROPERTY_TYPE eType, [In, Out] IntPtr pvValue,
		ref uint ulSize);

	/// <summary>The <c>WebSocketGetGlobalProperty</c> function gets a single WebSocket property.</summary>
	/// <param name="eType">
	/// <para>Type: <c>WEB_SOCKET_PROPERTY</c></para>
	/// <para>A WebSocket property.</para>
	/// </param>
	/// <param name="pvValue">
	/// <para>The property value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketGetGlobalProperty")]
	public static HRESULT WebSocketGetGlobalProperty<T>([In] WEB_SOCKET_PROPERTY_TYPE eType, out T pvValue)
	{
		if (typeof(T).IsArray)
		{
			using SafeCoTaskMemHandle mem = new(1024);
			uint sz = mem.Size;
			HRESULT ret = WebSocketGetGlobalProperty(eType, mem, ref sz);
			Type elemType = typeof(T).GetElementType();
			int elemSz = Marshal.SizeOf(elemType);
			pvValue = ret.Succeeded ? (T)(object)mem.DangerousGetHandle().ToArray(elemType, mem.Size / elemSz, 0, sz) : default;
			return ret;
		}
		else
		{
			using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure<T>();
			uint sz = mem.Size;
			HRESULT ret = WebSocketGetGlobalProperty(eType, mem, ref sz);
			pvValue = ret.Succeeded ? mem.ToStructure<T>() : default;
			return ret;
		}
	}

	/// <summary>The <c>WebSocketReceive</c> function adds a receive operation to the protocol component operation queue.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <param name="pBuffer">
	/// <para>Type: <c>WEB_SOCKET_BUFFER*</c></para>
	/// <para>
	/// A pointer to an array of WEB_SOCKET_BUFFER structures that WebSocket data will be written to when it is returned by
	/// WebSocketGetAction. If <c>NULL</c>, <c>WebSocketGetAction</c> will return an internal buffer that enables zero-copy scenarios.
	/// </para>
	/// <para>
	/// <c>Note</c> Once WEB_SOCKET_INDICATE_RECEIVE_COMPLETE is returned by WebSocketGetAction for this action, the memory pointer to by
	/// <c>pBuffer</c> can be reclaimed.
	/// </para>
	/// </param>
	/// <param name="pvContext">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A pointer to an application context handle that will be returned by a subsequent call to WebSocketGetAction.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_OPERATION</c></term>
	/// <term>Protocol performed an invalid operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketreceive HRESULT WebSocketReceive( [in]
	// WEB_SOCKET_HANDLE hWebSocket, [in, optional] WEB_SOCKET_BUFFER *pBuffer, [in, optional] PVOID pvContext );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketReceive")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketReceive([In] WEB_SOCKET_HANDLE hWebSocket,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] WEB_SOCKET_BUFFER[] pBuffer, [In, Optional] IntPtr pvContext);

	/// <summary>The <c>WebSocketSend</c> function adds a send operation to the protocol component operation queue.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>WEB_SOCKET_HANDLE</c></para>
	/// <para>WebSocket session handle returned by a previous call to WebSocketCreateClientHandle or WebSocketCreateServerHandle.</para>
	/// </param>
	/// <param name="BufferType">
	/// <para>Type: <c>WEB_SOCKET_BUFFER_TYPE</c></para>
	/// <para>The type of WebSocket buffer data to send in <c>pBuffer</c>.</para>
	/// </param>
	/// <param name="pBuffer">
	/// <para>Type: <c>WEB_SOCKET_BUFFER*</c></para>
	/// <para>
	/// A pointer to an array of WEB_SOCKET_BUFFER structures that contains WebSocket buffer data to send. If <c>BufferType</c> is
	/// WEB_SOCKET_PING_PONG_BUFFER_TYPE or WEB_SOCKET_UNSOLICITED_PONG_BUFFER_TYPE, <c>pBuffer</c> must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> Once WEB_SOCKET_INDICATE_SEND_COMPLETE is returned by WebSocketGetAction for this action, the memory pointer to by
	/// <c>pBuffer</c> can be reclaimed.
	/// </para>
	/// </param>
	/// <param name="Context">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A pointer to an application context handle that will be returned by a subsequent call to WebSocketGetAction.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>If the function succeeds, it returns <c>S_OK</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>E_INVALID_PROTOCOL_OPERATION</c></term>
	/// <term>Protocol performed an invalid operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>After an application sends a WEB_SOCKET_CLOSE_BUFFER_TYPE WebSocket buffer successfully, it can only send control frames.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/nf-websocket-websocketsend HRESULT WebSocketSend( [in] WEB_SOCKET_HANDLE
	// hWebSocket, [in] WEB_SOCKET_BUFFER_TYPE BufferType, [in, optional] WEB_SOCKET_BUFFER *pBuffer, [in, optional] PVOID Context );
	[PInvokeData("websocket.h", MSDNShortId = "NF:websocket.WebSocketSend")]
	[DllImport(Lib_Websocket, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WebSocketSend([In] WEB_SOCKET_HANDLE hWebSocket, [In] WEB_SOCKET_BUFFER_TYPE BufferType,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] WEB_SOCKET_BUFFER[] pBuffer, [In, Optional] IntPtr Context);

	/// <summary>The <c>WEB_SOCKET_BUFFER</c> structure contains data for a specific WebSocket action.</summary>
	/// <remarks>
	/// Application must use the <c>Data</c> struct for all buffer types except <c>WEB_SOCKET_CLOSE_BUFFER_TYPE</c>. The <c>CloseStatus</c>
	/// struct is used for <c>WEB_SOCKET_CLOSE_BUFFER_TYPE</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ns-websocket-web_socket_buffer typedef union _WEB_SOCKET_BUFFER { struct
	// { PBYTE pbBuffer; ULONG ulBufferLength; } Data; struct { PBYTE pbReason; ULONG ulReasonLength; USHORT usStatus; } CloseStatus; }
	// WEB_SOCKET_BUFFER, *PWEB_SOCKET_BUFFER;
	[PInvokeData("websocket.h", MSDNShortId = "NS:websocket._WEB_SOCKET_BUFFER")]
	[StructLayout(LayoutKind.Explicit)]
	public struct WEB_SOCKET_BUFFER
	{
		/// <summary/>
		[FieldOffset(0)]
		public DATA Data;

		/// <summary/>
		[FieldOffset(0)]
		public CLOSESTATUS CloseStatus;

		/// <summary/>
		public struct DATA
		{
			/// <summary>Type: PBYTE Pointer to the WebSocket buffer data.</summary>
			public IntPtr pbBuffer;

			/// <summary>Type: ULONG Length, in bytes, of the buffer pointed to by pbBuffer.</summary>
			public uint ulBufferLength;
		}

		/// <summary/>
		public struct CLOSESTATUS
		{
			/// <summary>
			/// Type: PBYTE A point to a UTF-8 string that represents the reason the connection is closed. If ulReasonLength is 0, this must
			///       be NULL.
			/// </summary>
			public IntPtr pbReason;

			/// <summary>
			/// Type: ULONG Length, in bytes, of the buffer pointed to by pbReason. It cannot exceed WEB_SOCKET_MAX_CLOSE_REASON_LENGTH (123 bytes).
			/// </summary>
			public uint ulReasonLength;

			/// <summary>WEB_SOCKET_CLOSE_STATUS enumeration that specifies the WebSocket status.</summary>
			public WEB_SOCKET_CLOSE_STATUS usStatus;
		}

		/// <summary>Initializes a new instance of the <see cref="WEB_SOCKET_BUFFER"/> struct.</summary>
		/// <param name="mem">The WebSocket buffer data.</param>
		public WEB_SOCKET_BUFFER(SafeAllocatedMemoryHandle mem)
		{
			CloseStatus = default;
			Data.pbBuffer = mem;
			Data.ulBufferLength = mem.Size;
		}

		/// <summary>Initializes a new instance of the <see cref="WEB_SOCKET_BUFFER"/> struct.</summary>
		/// <param name="reason">A UTF-8 string that represents the reason the connection is closed.</param>
		/// <param name="closeStatus">The WebSocket status.</param>
		public WEB_SOCKET_BUFFER(SafeAllocatedMemoryHandle reason, WEB_SOCKET_CLOSE_STATUS closeStatus)
		{
			Data = default;
			CloseStatus.pbReason = reason ?? IntPtr.Zero;
			CloseStatus.ulReasonLength = reason?.Size ?? 0;
			CloseStatus.usStatus = closeStatus;
		}
	}

	/// <summary>Provides a handle to a WebSocket.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct WEB_SOCKET_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="WEB_SOCKET_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public WEB_SOCKET_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="WEB_SOCKET_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static WEB_SOCKET_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(WEB_SOCKET_HANDLE h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="WEB_SOCKET_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(WEB_SOCKET_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="WEB_SOCKET_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WEB_SOCKET_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(WEB_SOCKET_HANDLE h1, WEB_SOCKET_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(WEB_SOCKET_HANDLE h1, WEB_SOCKET_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is WEB_SOCKET_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>The <c>WEB_SOCKET_HTTP_HEADER</c> structure contains an HTTP header.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ns-websocket-web_socket_http_header typedef struct
	// _WEB_SOCKET_HTTP_HEADER { PCHAR pcName; ULONG ulNameLength; PCHAR pcValue; ULONG ulValueLength; } WEB_SOCKET_HTTP_HEADER, *PWEB_SOCKET_HTTP_HEADER;
	[PInvokeData("websocket.h", MSDNShortId = "NS:websocket._WEB_SOCKET_HTTP_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WEB_SOCKET_HTTP_HEADER
	{
		/// <summary>
		/// <para>Type: <c>PCHAR</c></para>
		/// <para>A pointer to the HTTP header name. The name must not contain a colon character.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pcName;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Length, in characters, of the HTTP header pointed to by <c>pcName</c>.</para>
		/// </summary>
		public uint ulNameLength;

		/// <summary>
		/// <para>Type: <c>PCHAR</c></para>
		/// <para>A pointer to the HTTP header value.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pcValue;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Length, in characters, of the HTTP value pointed to by <c>pcValue</c>.</para>
		/// </summary>
		public uint ulValueLength;

		/// <summary>Initializes a new instance of the <see cref="WEB_SOCKET_HTTP_HEADER"/> struct.</summary>
		/// <param name="name">The HTTP header name.</param>
		/// <param name="value">The header value.</param>
		public WEB_SOCKET_HTTP_HEADER(string name, string value)
		{
			pcName = name;
			ulNameLength = (uint)name.Length;
			pcValue = value;
			ulValueLength = (uint)value.Length;
		}
	}

	/// <summary>The <c>WEB_SOCKET_PROPERTY</c> structure contains a single WebSocket property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/websocket/ns-websocket-web_socket_property typedef struct _WEB_SOCKET_PROPERTY {
	// WEB_SOCKET_PROPERTY_TYPE Type; PVOID pvValue; ULONG ulValueSize; } WEB_SOCKET_PROPERTY, *PWEB_SOCKET_PROPERTY;
	[PInvokeData("websocket.h", MSDNShortId = "NS:websocket._WEB_SOCKET_PROPERTY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WEB_SOCKET_PROPERTY
	{
		/// <summary>
		/// <para>Type: <c>WEB_SOCKET_PROPERTY_TYPE</c></para>
		/// <para>The WebSocket property type.</para>
		/// </summary>
		public WEB_SOCKET_PROPERTY_TYPE Type;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>A pointer to the value to set. The pointer must have an alignment compatible with the type of the property.</para>
		/// </summary>
		public IntPtr pvValue;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The size, in bytes, of the property pointed to by <c>pvValue</c>.</para>
		/// </summary>
		public uint ulValueSize;

		/// <summary>Initializes a new instance of the <see cref="WEB_SOCKET_PROPERTY"/> struct.</summary>
		/// <param name="type">The WebSocket property type.</param>
		/// <param name="value">The value to set.</param>
		public WEB_SOCKET_PROPERTY(WEB_SOCKET_PROPERTY_TYPE type, SafeAllocatedMemoryHandle value)
		{
			Type = type;
			pvValue = value;
			ulValueSize = value.Size;
		}
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WEB_SOCKET_HANDLE"/> that is disposed using <see cref="WebSocketDeleteHandle"/>.</summary>
	public class SafeWEB_SOCKET_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeWEB_SOCKET_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public SafeWEB_SOCKET_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWEB_SOCKET_HANDLE"/> class.</summary>
		private SafeWEB_SOCKET_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeWEB_SOCKET_HANDLE"/> to <see cref="WEB_SOCKET_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WEB_SOCKET_HANDLE(SafeWEB_SOCKET_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { WebSocketDeleteHandle(handle); return true; }
	}
}