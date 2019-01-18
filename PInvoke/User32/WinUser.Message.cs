using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// Used to define private messages for use by private window classes, usually of the form OCM__BASE+x, where x is an integer value.
		/// </summary>
		public const uint OCM__BASE = (WM_USER + 0x1c00);

		/// <summary>Used to define private messages, usually of the form WM_APP+x, where x is an integer value.</summary>
		public const uint WM_APP = 0x8000;

		/// <summary>
		/// Used to define private messages for use by private window classes, usually of the form WM_USER+x, where x is an integer value.
		/// </summary>
		public const uint WM_USER = 0x0400;

		/// <summary>
		/// An application-defined callback function used with the SendMessageCallback function. The system passes the message to the
		/// callback function after passing the message to the destination window procedure. The <c>SENDASYNCPROC</c> type defines a pointer
		/// to this callback function. SendAsyncProc is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="hwnd">
		/// A handle to the window whose window procedure received the message.
		/// <para>
		/// If the SendMessageCallback function was called with its hwnd parameter set to HWND_BROADCAST, the system calls the SendAsyncProc
		/// function once for each top-level window.
		/// </para>
		/// </param>
		/// <param name="uMsg">The message.</param>
		/// <param name="dwData">An application-defined value sent from the SendMessageCallback function.</param>
		/// <param name="lResult">The result of the message processing.This value depends on the message.</param>
		/// <remarks>
		/// <para>
		/// You install a SendAsyncProc application-defined callback function by passing a <c>SENDASYNCPROC</c> pointer to the
		/// SendMessageCallback function.
		/// </para>
		/// <para>
		/// The callback function is only called when the thread that called SendMessageCallback calls GetMessage, PeekMessage, or WaitMessage.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-sendasyncproc SENDASYNCPROC Sendasyncproc; void
		// Sendasyncproc(_In_ HWND hwnd, _In_ UINT uMsg, _In_ ULONG_PTR dwData, _In_ LRESULT lResult);
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("winuser.h")]
		public delegate void Sendasyncproc(HWND hwnd, uint uMsg, UIntPtr dwData, IntPtr lResult);

		/// <summary>Flags used by BroadcastSystemMessage and BroadcastSystemMessageEx.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum BSF
		{
			/// <summary>Enables the recipient to set the foreground window while processing the message.</summary>
			BSF_ALLOWSFW = 0x00000080,

			/// <summary>Flushes the disk after each recipient processes the message.</summary>
			BSF_FLUSHDISK = 0x00000004,

			/// <summary>Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.</summary>
			BSF_FORCEIFHUNG = 0x00000020,

			/// <summary>
			/// Does not send the message to windows that belong to the current task. This prevents an application from receiving its own message.
			/// </summary>
			BSF_IGNORECURRENTTASK = 0x00000002,

			/// <summary>
			/// Forces a non-responsive application to time out. If one of the recipients times out, do not continue broadcasting the message.
			/// </summary>
			BSF_NOHANG = 0x00000008,

			/// <summary>Waits for a response to the message, as long as the recipient is not being unresponsive. Does not time out.</summary>
			BSF_NOTIMEOUTIFNOTHUNG = 0x00000040,

			/// <summary>Posts the message. Do not use in combination with BSF_QUERY.</summary>
			BSF_POSTMESSAGE = 0x00000010,

			/// <summary>
			/// Sends the message to one recipient at a time, sending to a subsequent recipient only if the current recipient returns TRUE.
			/// </summary>
			BSF_QUERY = 0x00000001,

			/// <summary>Sends the message using SendNotifyMessage function. Do not use in combination with BSF_QUERY.</summary>
			BSF_SENDNOTIFYMESSAGE = 0x00000100,

			/// <summary/>
			BSF_RETURNHDESK = 0x00000200,

			/// <summary/>
			BSF_LUID = 0x00000400,
		}

		/// <summary>System message info flags used by BroadcastSystemMessage and BroadcastSystemMessageEx.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum BSM
		{
			/// <summary>Broadcast to all system components.</summary>
			BSM_ALLCOMPONENTS = 0x00000000,

			/// <summary>Broadcast to all desktops. Requires the SE_TCB_NAME privilege.</summary>
			BSM_ALLDESKTOPS = 0x00000010,

			/// <summary>Broadcast to applications.</summary>
			BSM_APPLICATIONS = 0x00000008,

			/// <summary/>
			BSM_VXDS = 0x00000001,

			/// <summary/>
			BSM_NETDRIVER = 0x00000002,

			/// <summary/>
			BSM_INSTALLABLEDRIVERS = 0x00000004,
		}

		/// <summary>Return values from InSendMessageEx</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum ISMEX
		{
			/// <summary>The message was not sent.</summary>
			ISMEX_NOSEND = 0x00000000,

			/// <summary>The message was sent using the SendMessageCallback function. The thread that sent the message is not blocked.</summary>
			ISMEX_CALLBACK = 0x00000004,

			/// <summary>The message was sent using the SendNotifyMessage function. The thread that sent the message is not blocked.</summary>
			ISMEX_NOTIFY = 0x00000002,

			/// <summary>The window procedure has processed the message. The thread that sent the message is no longer blocked.</summary>
			ISMEX_REPLIED = 0x00000008,

			/// <summary>
			/// The message was sent using the SendMessage or SendMessageTimeout function. If ISMEX_REPLIED is not set, the thread that sent
			/// the message is blocked.
			/// </summary>
			ISMEX_SEND = 0x00000001,
		}

		/// <summary>Flags used by PeekMessage.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum PM
		{
			/// <summary>Messages are not removed from the queue after processing by PeekMessage.</summary>
			M_NOREMOVE = 0x0000,

			/// <summary>Messages are removed from the queue after processing by PeekMessage.</summary>
			PM_REMOVE = 0x0001,

			/// <summary>
			/// Prevents the system from releasing any thread that is waiting for the caller to go idle (see WaitForInputIdle).
			/// <para>Combine this value with either PM_NOREMOVE or PM_REMOVE.</para>
			/// </summary>
			PM_NOYIELD = 0x0002,

			/// <summary>Process mouse and keyboard messages.</summary>
			PM_QS_INPUT = (QS.QS_INPUT << 16),

			/// <summary>Process all posted messages, including timers and hotkeys.</summary>
			PM_QS_POSTMESSAGE = ((QS.QS_POSTMESSAGE | QS.QS_HOTKEY | QS.QS_TIMER) << 16),

			/// <summary>Process paint messages.</summary>
			PM_QS_PAINT = (QS.QS_PAINT << 16),

			/// <summary>Process all sent messages.</summary>
			PM_QS_SENDMESSAGE = (QS.QS_SENDMESSAGE << 16),
		}

		/// <summary>Flags used GetQueueStatus.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum QS
		{
			/// <summary>An input, WM_TIMER, WM_PAINT, WM_HOTKEY, or posted message is in the queue.</summary>
			QS_ALLEVENTS = (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY),

			/// <summary>Any message is in the queue.</summary>
			QS_ALLINPUT = (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE),

			/// <summary>A posted message (other than those listed here) is in the queue.</summary>
			QS_ALLPOSTMESSAGE = 0x0100,

			/// <summary>A WM_HOTKEY message is in the queue.</summary>
			QS_HOTKEY = 0x0080,

			/// <summary>An input message is in the queue.</summary>
			QS_INPUT = (QS_MOUSE | QS_KEY | QS_RAWINPUT | QS_TOUCH | QS_POINTER),

			/// <summary>A WM_KEYUP, WM_KEYDOWN, WM_SYSKEYUP, or WM_SYSKEYDOWN message is in the queue.</summary>
			QS_KEY = 0x0001,

			/// <summary>A WM_MOUSEMOVE message or mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).</summary>
			QS_MOUSE = (QS_MOUSEMOVE | QS_MOUSEBUTTON),

			/// <summary>A mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).</summary>
			QS_MOUSEBUTTON = 0x0004,

			/// <summary>A WM_MOUSEMOVE message is in the queue.</summary>
			QS_MOUSEMOVE = 0x0002,

			/// <summary>A WM_PAINT message is in the queue.</summary>
			QS_PAINT = 0x0020,

			/// <summary>A posted message (other than those listed here) is in the queue.</summary>
			QS_POSTMESSAGE = 0x0008,

			/// <summary>
			/// A raw input message is in the queue. For more information, see Raw Input.
			/// <para>Windows 2000: This flag is not supported.</para>
			/// </summary>
			QS_RAWINPUT = 0x0400,

			/// <summary>A message sent by another thread or application is in the queue.</summary>
			QS_SENDMESSAGE = 0x0040,

			/// <summary>A WM_TIMER message is in the queue.</summary>
			QS_TIMER = 0x0010,

			/// <summary/>
			QS_TOUCH = 0x0800,

			/// <summary/>
			QS_POINTER = 0x1000,
		}

		/// <summary>Flags used by the SendMessageTimeout function.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum SMTO
		{
			/// <summary>
			/// The function returns without waiting for the time-out period to elapse if the receiving thread appears to not respond or "hangs."
			/// </summary>
			SMTO_ABORTIFHUNG = 0x0002,

			/// <summary>Prevents the calling thread from processing any other requests until the function returns.</summary>
			SMTO_BLOCK = 0x0001,

			/// <summary>The calling thread is not prevented from processing other requests while waiting for the function to return.</summary>
			SMTO_NORMAL = 0x0000,

			/// <summary>The function does not enforce the time-out period as long as the receiving thread is processing messages.</summary>
			SMTO_NOTIMEOUTIFNOTHUNG = 0x0008,

			/// <summary>
			/// The function should return 0 if the receiving window is destroyed or its owning thread dies while the message is being processed.
			/// </summary>
			SMTO_ERRORONEXIT = 0x0020,
		}

		/// <summary>
		/// <para>
		/// Sends a message to the specified recipients. The recipients can be applications, installable drivers, network drivers,
		/// system-level device drivers, or any combination of these system components.
		/// </para>
		/// <para>To receive additional information if the request is defined, use the BroadcastSystemMessageEx function.</para>
		/// </summary>
		/// <param name="flags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The broadcast option. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BSF_ALLOWSFW 0x00000080</term>
		/// <term>Enables the recipient to set the foreground window while processing the message.</term>
		/// </item>
		/// <item>
		/// <term>BSF_FLUSHDISK 0x00000004</term>
		/// <term>Flushes the disk after each recipient processes the message.</term>
		/// </item>
		/// <item>
		/// <term>BSF_FORCEIFHUNG 0x00000020</term>
		/// <term>Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.</term>
		/// </item>
		/// <item>
		/// <term>BSF_IGNORECURRENTTASK 0x00000002</term>
		/// <term>
		/// Does not send the message to windows that belong to the current task. This prevents an application from receiving its own message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_NOHANG 0x00000008</term>
		/// <term>
		/// Forces a non-responsive application to time out. If one of the recipients times out, do not continue broadcasting the message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_NOTIMEOUTIFNOTHUNG 0x00000040</term>
		/// <term>Waits for a response to the message, as long as the recipient is not being unresponsive. Does not time out.</term>
		/// </item>
		/// <item>
		/// <term>BSF_POSTMESSAGE 0x00000010</term>
		/// <term>Posts the message. Do not use in combination with BSF_QUERY.</term>
		/// </item>
		/// <item>
		/// <term>BSF_QUERY 0x00000001</term>
		/// <term>
		/// Sends the message to one recipient at a time, sending to a subsequent recipient only if the current recipient returns TRUE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_SENDNOTIFYMESSAGE 0x00000100</term>
		/// <term>Sends the message using SendNotifyMessage function. Do not use in combination with BSF_QUERY.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpInfo">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>A pointer to a variable that contains and receives information about the recipients of the message.</para>
		/// <para>
		/// When the function returns, this variable receives a combination of these values identifying which recipients actually received
		/// the message.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the function broadcasts to all components.</para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BSM_ALLCOMPONENTS 0x00000000</term>
		/// <term>Broadcast to all system components.</term>
		/// </item>
		/// <item>
		/// <term>BSM_ALLDESKTOPS 0x00000010</term>
		/// <term>Broadcast to all desktops. Requires the SE_TCB_NAME privilege.</term>
		/// </item>
		/// <item>
		/// <term>BSM_APPLICATIONS 0x00000008</term>
		/// <term>Broadcast to applications.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>long</c></c></para>
		/// <para>If the function succeeds, the return value is a positive value.</para>
		/// <para>If the function is unable to broadcast the message, the return value is –1.</para>
		/// <para>
		/// If the dwFlags parameter is <c>BSF_QUERY</c> and at least one recipient returned <c>BROADCAST_QUERY_DENY</c> to the corresponding
		/// message, the return value is zero. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If <c>BSF_QUERY</c> is not specified, the function sends the specified message to all requested recipients, ignoring values
		/// returned by those recipients.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Terminating a Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-broadcastsystemmessage long BroadcastSystemMessage( DWORD
		// flags, LPDWORD lpInfo, UINT Msg, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern long BroadcastSystemMessage(BSF flags, ref BSM lpInfo, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// <para>
		/// Sends a message to the specified recipients. The recipients can be applications, installable drivers, network drivers,
		/// system-level device drivers, or any combination of these system components.
		/// </para>
		/// <para>This function is similar to BroadcastSystemMessage except that this function can return more information from the recipients.</para>
		/// </summary>
		/// <param name="flags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The broadcast option. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BSF_ALLOWSFW 0x00000080</term>
		/// <term>Enables the recipient to set the foreground window while processing the message.</term>
		/// </item>
		/// <item>
		/// <term>BSF_FLUSHDISK 0x00000004</term>
		/// <term>Flushes the disk after each recipient processes the message.</term>
		/// </item>
		/// <item>
		/// <term>BSF_FORCEIFHUNG 0x00000020</term>
		/// <term>Continues to broadcast the message, even if the time-out period elapses or one of the recipients is not responding.</term>
		/// </item>
		/// <item>
		/// <term>BSF_IGNORECURRENTTASK 0x00000002</term>
		/// <term>
		/// Does not send the message to windows that belong to the current task. This prevents an application from receiving its own message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_LUID 0x00000400</term>
		/// <term>
		/// If BSF_LUID is set, the message is sent to the window that has the same LUID as specified in the luid member of the BSMINFO
		/// structure. Windows 2000: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_NOHANG 0x00000008</term>
		/// <term>
		/// Forces a non-responsive application to time out. If one of the recipients times out, do not continue broadcasting the message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_NOTIMEOUTIFNOTHUNG 0x00000040</term>
		/// <term>Waits for a response to the message, as long as the recipient is not being unresponsive. Does not time out.</term>
		/// </item>
		/// <item>
		/// <term>BSF_POSTMESSAGE 0x00000010</term>
		/// <term>Posts the message. Do not use in combination with BSF_QUERY.</term>
		/// </item>
		/// <item>
		/// <term>BSF_RETURNHDESK 0x00000200</term>
		/// <term>
		/// If access is denied and both this and BSF_QUERY are set, BSMINFO returns both the desktop handle and the window handle. If access
		/// is denied and only BSF_QUERY is set, only the window handle is returned by BSMINFO. Windows 2000: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_QUERY 0x00000001</term>
		/// <term>
		/// Sends the message to one recipient at a time, sending to a subsequent recipient only if the current recipient returns TRUE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BSF_SENDNOTIFYMESSAGE 0x00000100</term>
		/// <term>Sends the message using SendNotifyMessage function. Do not use in combination with BSF_QUERY.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpInfo">
		/// <para>Type: <c>LPDWORD</c></para>
		/// <para>A pointer to a variable that contains and receives information about the recipients of the message.</para>
		/// <para>
		/// When the function returns, this variable receives a combination of these values identifying which recipients actually received
		/// the message.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the function broadcasts to all components.</para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BSM_ALLCOMPONENTS 0x00000000</term>
		/// <term>Broadcast to all system components.</term>
		/// </item>
		/// <item>
		/// <term>BSM_ALLDESKTOPS 0x00000010</term>
		/// <term>Broadcast to all desktops. Requires the SE_TCB_NAME privilege.</term>
		/// </item>
		/// <item>
		/// <term>BSM_APPLICATIONS 0x00000008</term>
		/// <term>Broadcast to applications.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="pbsmInfo">
		/// <para>Type: <c>PBSMINFO</c></para>
		/// <para>A pointer to a BSMINFO structure that contains additional information if the request is denied and dwFlags is set to <c>BSF_QUERY</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>long</c></c></para>
		/// <para>If the function succeeds, the return value is a positive value.</para>
		/// <para>If the function is unable to broadcast the message, the return value is –1.</para>
		/// <para>
		/// If the dwFlags parameter is <c>BSF_QUERY</c> and at least one recipient returned <c>BROADCAST_QUERY_DENY</c> to the corresponding
		/// message, the return value is zero. To get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If <c>BSF_QUERY</c> is not specified, the function sends the specified message to all requested recipients, ignoring values
		/// returned by those recipients.
		/// </para>
		/// <para>
		/// If the caller's thread is on a desktop other than that of the window that denied the request, the caller must call
		/// SetThreadDesktop <c>(hdesk)</c> to query anything on that window. Also, the caller must call CloseDesktop on the returned
		/// <c>hdesk</c> handle.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-broadcastsystemmessageexa long BroadcastSystemMessageExA(
		// DWORD flags, LPDWORD lpInfo, UINT Msg, WPARAM wParam, LPARAM lParam, PBSMINFO pbsmInfo );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		public static extern long BroadcastSystemMessageEx(BSF flags, ref BSM lpInfo, uint Msg, IntPtr wParam, IntPtr lParam, ref BSMINFO pbsmInfo);

		/// <summary>
		/// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage function.
		/// </summary>
		/// <param name="lpMsg">
		/// <para>Type: <c>const MSG*</c></para>
		/// <para>A pointer to a structure that contains the message.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
		/// <para>
		/// The return value specifies the value returned by the window procedure. Although its meaning depends on the message being
		/// dispatched, the return value generally is ignored.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The MSG structure must contain valid message values. If the <paramref name="lpMsg"/> parameter points to a WM_TIMER message and
		/// the lParam parameter of the <c>WM_TIMER</c> message is not <c>NULL</c>, lParam points to a function that is called instead of the
		/// window procedure.
		/// </para>
		/// <para>
		/// Note that the application is responsible for retrieving and dispatching input messages to the dialog box. Most applications use
		/// the main message loop for this. However, to permit the user to move to and to select controls by using the keyboard, the
		/// application must call IsDialogMessage. For more information, see Dialog Box Keyboard Interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Message Loop.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-dispatchmessage LRESULT DispatchMessage( const MSG *lpMsg );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		public static extern IntPtr DispatchMessage(in MSG lpMsg);

		/// <summary>Determines whether there are mouse-button or keyboard messages in the calling thread's message queue.</summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the queue contains one or more new mouse-button or keyboard messages, the return value is nonzero.</para>
		/// <para>If there are no new mouse-button or keyboard messages in the queue, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getinputstate BOOL GetInputState( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetInputState();

		/// <summary>
		/// <para>
		/// Retrieves a message from the calling thread's message queue. The function dispatches incoming sent messages until a posted
		/// message is available for retrieval.
		/// </para>
		/// <para>Unlike <c>GetMessage</c>, the PeekMessage function does not wait for a message to be posted before returning.</para>
		/// </summary>
		/// <param name="lpMsg">
		/// <para>Type: <c>LPMSG</c></para>
		/// <para>A pointer to an MSG structure that receives message information from the thread's message queue.</para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose messages are to be retrieved. The window must belong to the current thread.</para>
		/// <para>
		/// If hWnd is <c>NULL</c>, <c>GetMessage</c> retrieves messages for any window that belongs to the current thread, and any messages
		/// on the current thread's message queue whose <c>hwnd</c> value is <c>NULL</c> (see the MSG structure). Therefore if hWnd is
		/// <c>NULL</c>, both window messages and thread messages are processed.
		/// </para>
		/// <para>
		/// If hWnd is -1, <c>GetMessage</c> retrieves only messages on the current thread's message queue whose <c>hwnd</c> value is
		/// <c>NULL</c>, that is, thread messages as posted by PostMessage (when the hWnd parameter is <c>NULL</c>) or PostThreadMessage.
		/// </para>
		/// </param>
		/// <param name="wMsgFilterMin">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The integer value of the lowest message value to be retrieved. Use <c>WM_KEYFIRST</c> (0x0100) to specify the first keyboard
		/// message or <c>WM_MOUSEFIRST</c> (0x0200) to specify the first mouse message.
		/// </para>
		/// <para>Use WM_INPUT here and in wMsgFilterMax to specify only the <c>WM_INPUT</c> messages.</para>
		/// <para>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, <c>GetMessage</c> returns all available messages (that is, no range filtering
		/// is performed).
		/// </para>
		/// </param>
		/// <param name="wMsgFilterMax">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The integer value of the highest message value to be retrieved. Use <c>WM_KEYLAST</c> to specify the last keyboard message or
		/// <c>WM_MOUSELAST</c> to specify the last mouse message.
		/// </para>
		/// <para>Use WM_INPUT here and in wMsgFilterMin to specify only the <c>WM_INPUT</c> messages.</para>
		/// <para>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, <c>GetMessage</c> returns all available messages (that is, no range filtering
		/// is performed).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function retrieves a message other than WM_QUIT, the return value is nonzero.</para>
		/// <para>If the function retrieves the WM_QUIT message, the return value is zero.</para>
		/// <para>
		/// If there is an error, the return value is -1. For example, the function fails if hWnd is an invalid window handle or lpMsg is an
		/// invalid pointer. To get extended error information, call GetLastError.
		/// </para>
		/// <para>Because the return value can be nonzero, zero, or -1, avoid code like this:</para>
		/// <para>
		/// The possibility of a -1 return value in the case that hWnd is an invalid parameter (such as referring to a window that has
		/// already been destroyed) means that such code can lead to fatal application errors. Instead, use code like this:
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>An application typically uses the return value to determine whether to end the main message loop and exit the program.</para>
		/// <para>
		/// The <c>GetMessage</c> function retrieves messages associated with the window identified by the hWnd parameter or any of its
		/// children, as specified by the IsChild function, and within the range of message values given by the wMsgFilterMin and
		/// wMsgFilterMax parameters. Note that an application can only use the low word in the wMsgFilterMin and wMsgFilterMax parameters;
		/// the high word is reserved for the system.
		/// </para>
		/// <para>
		/// Note that <c>GetMessage</c> always retrieves WM_QUIT messages, no matter which values you specify for wMsgFilterMin and wMsgFilterMax.
		/// </para>
		/// <para>
		/// During this call, the system delivers pending, non-queued messages, that is, messages sent to windows owned by the calling thread
		/// using the SendMessage, SendMessageCallback, SendMessageTimeout, or SendNotifyMessage function. Then the first queued message that
		/// matches the specified filter is retrieved. The system may also process internal events. If no filter is specified, messages are
		/// processed in the following order:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Sent messages</term>
		/// </item>
		/// <item>
		/// <term>Posted messages</term>
		/// </item>
		/// <item>
		/// <term>Input (hardware) messages and system internal events</term>
		/// </item>
		/// <item>
		/// <term>Sent messages (again)</term>
		/// </item>
		/// <item>
		/// <term>WM_PAINT messages</term>
		/// </item>
		/// <item>
		/// <term>WM_TIMER messages</term>
		/// </item>
		/// </list>
		/// <para>To retrieve input messages before posted messages, use the wMsgFilterMin and wMsgFilterMax parameters.</para>
		/// <para><c>GetMessage</c> does not remove WM_PAINT messages from the queue. The messages remain in the queue until processed.</para>
		/// <para>
		/// If a top-level window stops responding to messages for more than several seconds, the system considers the window to be not
		/// responding and replaces it with a ghost window that has the same z-order, location, size, and visual attributes. This allows the
		/// user to move it, resize it, or even close the application. However, these are the only actions available because the application
		/// is actually not responding. When in the debugger mode, the system does not generate a ghost window.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The output is in the mode of the window that the message is targeting. The
		/// calling thread is not taken into consideration.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Message Loop.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmessage BOOL GetMessage( LPMSG lpMsg, HWND hWnd, UINT
		// wMsgFilterMin, UINT wMsgFilterMax );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetMessage(out MSG lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

		/// <summary>
		/// Retrieves the extra message information for the current thread. Extra message information is an application- or driver-defined
		/// value associated with the current thread's message queue.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>LPARAM</c></c></para>
		/// <para>The return value specifies the extra information. The meaning of the extra information is device specific.</para>
		/// </returns>
		/// <remarks>To set a thread's extra message information, use the SetMessageExtraInfo function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmessageextrainfo LPARAM GetMessageExtraInfo( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern IntPtr GetMessageExtraInfo();

		/// <summary>
		/// <para>Retrieves the cursor position for the last message retrieved by the GetMessage function.</para>
		/// <para>To determine the current position of the cursor, use the GetCursorPos function.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>DWORD</c></c></para>
		/// <para>
		/// The return value specifies the x- and y-coordinates of the cursor position. The x-coordinate is the low order <c>short</c> and
		/// the y-coordinate is the high-order <c>short</c>.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As noted above, the x-coordinate is in the low-order <c>short</c> of the return value; the y-coordinate is in the high-order
		/// <c>short</c> (both represent signed values because they can take negative values on systems with multiple monitors). If the
		/// return value is assigned to a variable, you can use the MAKEPOINTS macro to obtain a POINTS structure from the return value. You
		/// can also use the GET_X_LPARAM or GET_Y_LPARAM macro to extract the x- or y-coordinate.
		/// </para>
		/// <para>
		/// <c>Important</c> Do not use the LOWORD or HIWORD macros to extract the x- and y- coordinates of the cursor position because these
		/// macros return incorrect results on systems with multiple monitors. Systems with multiple monitors can have negative x- and y-
		/// coordinates, and <c>LOWORD</c> and <c>HIWORD</c> treat the coordinates as unsigned quantities.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmessagepos DWORD GetMessagePos( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern uint GetMessagePos();

		/// <summary>
		/// Retrieves the message time for the last message retrieved by the GetMessage function. The time is a long integer that specifies
		/// the elapsed time, in milliseconds, from the time the system was started to the time the message was created (that is, placed in
		/// the thread's message queue).
		/// </summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>LONG</c></c></para>
		/// <para>The return value specifies the message time.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The return value from the <c>GetMessageTime</c> function does not necessarily increase between subsequent messages, because the
		/// value wraps to wraps to the minimum value for a long integer if the timer count exceeds the maximum value for a long integer.
		/// </para>
		/// <para>
		/// To calculate time delays between messages, subtract the time of the first message from the time of the second message (ignoring
		/// overflow) and compare the result of the subtraction against the desired delay amount.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getmessagetime LONG GetMessageTime( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern int GetMessageTime();

		/// <summary>Retrieves the type of messages found in the calling thread's message queue.</summary>
		/// <param name="flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The types of messages for which to check. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>QS_ALLEVENTS (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY)</term>
		/// <term>An input, WM_TIMER, WM_PAINT, WM_HOTKEY, or posted message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_ALLINPUT (QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE)</term>
		/// <term>Any message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_ALLPOSTMESSAGE 0x0100</term>
		/// <term>A posted message (other than those listed here) is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_HOTKEY 0x0080</term>
		/// <term>A WM_HOTKEY message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_INPUT (QS_MOUSE | QS_KEY | QS_RAWINPUT)</term>
		/// <term>An input message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_KEY 0x0001</term>
		/// <term>A WM_KEYUP, WM_KEYDOWN, WM_SYSKEYUP, or WM_SYSKEYDOWN message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_MOUSE (QS_MOUSEMOVE | QS_MOUSEBUTTON)</term>
		/// <term>A WM_MOUSEMOVE message or mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).</term>
		/// </item>
		/// <item>
		/// <term>QS_MOUSEBUTTON 0x0004</term>
		/// <term>A mouse-button message (WM_LBUTTONUP, WM_RBUTTONDOWN, and so on).</term>
		/// </item>
		/// <item>
		/// <term>QS_MOUSEMOVE 0x0002</term>
		/// <term>A WM_MOUSEMOVE message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_PAINT 0x0020</term>
		/// <term>A WM_PAINT message is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_POSTMESSAGE 0x0008</term>
		/// <term>A posted message (other than those listed here) is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_RAWINPUT 0x0400</term>
		/// <term>A raw input message is in the queue. For more information, see Raw Input. Windows 2000: This flag is not supported.</term>
		/// </item>
		/// <item>
		/// <term>QS_SENDMESSAGE 0x0040</term>
		/// <term>A message sent by another thread or application is in the queue.</term>
		/// </item>
		/// <item>
		/// <term>QS_TIMER 0x0010</term>
		/// <term>A WM_TIMER message is in the queue.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>DWORD</c></c></para>
		/// <para>
		/// The high-order word of the return value indicates the types of messages currently in the queue. The low-order word indicates the
		/// types of messages that have been added to the queue and that are still in the queue since the last call to the
		/// <c>GetQueueStatus</c>, GetMessage, or PeekMessage function.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The presence of a QS_ flag in the return value does not guarantee that a subsequent call to the GetMessage or PeekMessage
		/// function will return a message. <c>GetMessage</c> and <c>PeekMessage</c> perform some internal filtering that may cause the
		/// message to be processed internally. For this reason, the return value from <c>GetQueueStatus</c> should be considered only a hint
		/// as to whether <c>GetMessage</c> or <c>PeekMessage</c> should be called.
		/// </para>
		/// <para>
		/// The <c>QS_ALLPOSTMESSAGE</c> and <c>QS_POSTMESSAGE</c> flags differ in when they are cleared. <c>QS_POSTMESSAGE</c> is cleared
		/// when you call GetMessage or PeekMessage, whether or not you are filtering messages. <c>QS_ALLPOSTMESSAGE</c> is cleared when you
		/// call <c>GetMessage</c> or <c>PeekMessage</c> without filtering messages (wMsgFilterMin and wMsgFilterMax are 0). This can be
		/// useful when you call <c>PeekMessage</c> multiple times to get messages in different ranges.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getqueuestatus DWORD GetQueueStatus( UINT flags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern uint GetQueueStatus(QS flags);

		/// <summary>
		/// <para>
		/// Determines whether the current window procedure is processing a message that was sent from another thread (in the same process or
		/// a different process) by a call to the SendMessage function.
		/// </para>
		/// <para>To obtain additional information about how the message was sent, use the InSendMessageEx function.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>
		/// If the window procedure is processing a message sent to it from another thread using the SendMessage function, the return value
		/// is nonzero.
		/// </para>
		/// <para>
		/// If the window procedure is not processing a message sent to it from another thread using the SendMessage function, the return
		/// value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-insendmessage BOOL InSendMessage( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InSendMessage();

		/// <summary>
		/// Determines whether the current window procedure is processing a message that was sent from another thread (in the same process or
		/// a different process).
		/// </summary>
		/// <param name="lpReserved">
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>Reserved; must be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>DWORD</c></c></para>
		/// <para>
		/// If the message was not sent, the return value is <c>ISMEX_NOSEND</c> (0x00000000). Otherwise, the return value is one or more of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ISMEX_CALLBACK 0x00000004</term>
		/// <term>The message was sent using the SendMessageCallback function. The thread that sent the message is not blocked.</term>
		/// </item>
		/// <item>
		/// <term>ISMEX_NOTIFY 0x00000002</term>
		/// <term>The message was sent using the SendNotifyMessage function. The thread that sent the message is not blocked.</term>
		/// </item>
		/// <item>
		/// <term>ISMEX_REPLIED 0x00000008</term>
		/// <term>The window procedure has processed the message. The thread that sent the message is no longer blocked.</term>
		/// </item>
		/// <item>
		/// <term>ISMEX_SEND 0x00000001</term>
		/// <term>
		/// The message was sent using the SendMessage or SendMessageTimeout function. If ISMEX_REPLIED is not set, the thread that sent the
		/// message is blocked.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>To determine if the sender is blocked, use the following test:</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-insendmessageex DWORD InSendMessageEx( LPVOID lpReserved );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern ISMEX InSendMessageEx(IntPtr lpReserved);

		/// <summary>
		/// Dispatches incoming sent messages, checks the thread message queue for a posted message, and retrieves the message (if any exist).
		/// </summary>
		/// <param name="lpMsg">
		/// <para>Type: <c>LPMSG</c></para>
		/// <para>A pointer to an MSG structure that receives message information.</para>
		/// </param>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose messages are to be retrieved. The window must belong to the current thread.</para>
		/// <para>
		/// If hWnd is <c>NULL</c>, <c>PeekMessage</c> retrieves messages for any window that belongs to the current thread, and any messages
		/// on the current thread's message queue whose <c>hwnd</c> value is <c>NULL</c> (see the MSG structure). Therefore if hWnd is
		/// <c>NULL</c>, both window messages and thread messages are processed.
		/// </para>
		/// <para>
		/// If hWnd is -1, <c>PeekMessage</c> retrieves only messages on the current thread's message queue whose <c>hwnd</c> value is
		/// <c>NULL</c>, that is, thread messages as posted by PostMessage (when the hWnd parameter is <c>NULL</c>) or PostThreadMessage.
		/// </para>
		/// </param>
		/// <param name="wMsgFilterMin">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The value of the first message in the range of messages to be examined. Use <c>WM_KEYFIRST</c> (0x0100) to specify the first
		/// keyboard message or <c>WM_MOUSEFIRST</c> (0x0200) to specify the first mouse message.
		/// </para>
		/// <para>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, <c>PeekMessage</c> returns all available messages (that is, no range filtering
		/// is performed).
		/// </para>
		/// </param>
		/// <param name="wMsgFilterMax">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The value of the last message in the range of messages to be examined. Use <c>WM_KEYLAST</c> to specify the last keyboard message
		/// or <c>WM_MOUSELAST</c> to specify the last mouse message.
		/// </para>
		/// <para>
		/// If wMsgFilterMin and wMsgFilterMax are both zero, <c>PeekMessage</c> returns all available messages (that is, no range filtering
		/// is performed).
		/// </para>
		/// </param>
		/// <param name="wRemoveMsg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies how messages are to be handled. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PM_NOREMOVE 0x0000</term>
		/// <term>Messages are not removed from the queue after processing by PeekMessage.</term>
		/// </item>
		/// <item>
		/// <term>PM_REMOVE 0x0001</term>
		/// <term>Messages are removed from the queue after processing by PeekMessage.</term>
		/// </item>
		/// <item>
		/// <term>PM_NOYIELD 0x0002</term>
		/// <term>
		/// Prevents the system from releasing any thread that is waiting for the caller to go idle (see WaitForInputIdle). Combine this
		/// value with either PM_NOREMOVE or PM_REMOVE.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// By default, all message types are processed. To specify that only certain message should be processed, specify one or more of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PM_QS_INPUT (QS_INPUT &lt;&lt; 16)</term>
		/// <term>Process mouse and keyboard messages.</term>
		/// </item>
		/// <item>
		/// <term>PM_QS_PAINT (QS_PAINT &lt;&lt; 16)</term>
		/// <term>Process paint messages.</term>
		/// </item>
		/// <item>
		/// <term>PM_QS_POSTMESSAGE ((QS_POSTMESSAGE | QS_HOTKEY | QS_TIMER) &lt;&lt; 16)</term>
		/// <term>Process all posted messages, including timers and hotkeys.</term>
		/// </item>
		/// <item>
		/// <term>PM_QS_SENDMESSAGE (QS_SENDMESSAGE &lt;&lt; 16)</term>
		/// <term>Process all sent messages.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If a message is available, the return value is nonzero.</para>
		/// <para>If no messages are available, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>PeekMessage</c> retrieves messages associated with the window identified by the hWnd parameter or any of its children as
		/// specified by the IsChild function, and within the range of message values given by the wMsgFilterMin and wMsgFilterMax
		/// parameters. Note that an application can only use the low word in the wMsgFilterMin and wMsgFilterMax parameters; the high word
		/// is reserved for the system.
		/// </para>
		/// <para>
		/// Note that <c>PeekMessage</c> always retrieves WM_QUIT messages, no matter which values you specify for wMsgFilterMin and wMsgFilterMax.
		/// </para>
		/// <para>
		/// During this call, the system delivers pending, non-queued messages, that is, messages sent to windows owned by the calling thread
		/// using the SendMessage, SendMessageCallback, SendMessageTimeout, or SendNotifyMessage function. Then the first queued message that
		/// matches the specified filter is retrieved. The system may also process internal events. If no filter is specified, messages are
		/// processed in the following order:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Sent messages</term>
		/// </item>
		/// <item>
		/// <term>Posted messages</term>
		/// </item>
		/// <item>
		/// <term>Input (hardware) messages and system internal events</term>
		/// </item>
		/// <item>
		/// <term>Sent messages (again)</term>
		/// </item>
		/// <item>
		/// <term>WM_PAINT messages</term>
		/// </item>
		/// <item>
		/// <term>WM_TIMER messages</term>
		/// </item>
		/// </list>
		/// <para>To retrieve input messages before posted messages, use the wMsgFilterMin and wMsgFilterMax parameters.</para>
		/// <para>
		/// The <c>PeekMessage</c> function normally does not remove WM_PAINT messages from the queue. <c>WM_PAINT</c> messages remain in the
		/// queue until they are processed. However, if a <c>WM_PAINT</c> message has a <c>NULL</c> update region, <c>PeekMessage</c> does
		/// remove it from the queue.
		/// </para>
		/// <para>
		/// If a top-level window stops responding to messages for more than several seconds, the system considers the window to be not
		/// responding and replaces it with a ghost window that has the same z-order, location, size, and visual attributes. This allows the
		/// user to move it, resize it, or even close the application. However, these are the only actions available because the application
		/// is actually not responding. When an application is being debugged, the system does not generate a ghost window.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The output is in the mode of the window that the message is targeting. The
		/// calling thread is not taken into consideration.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Examining a Message Queue.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-peekmessagea BOOL PeekMessageA( LPMSG lpMsg, HWND hWnd,
		// UINT wMsgFilterMin, UINT wMsgFilterMax, UINT wRemoveMsg );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out MSG lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax, PM wRemoveMsg);

		/// <summary>
		/// <para>
		/// Places (posts) a message in the message queue associated with the thread that created the specified window and returns without
		/// waiting for the thread to process the message.
		/// </para>
		/// <para>To post a message in the message queue associated with a thread, use the PostThreadMessage function.</para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose window procedure is to receive the message. The following values have special meanings.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HWND_BROADCAST ((HWND)0xffff)</term>
		/// <term>
		/// The message is posted to all top-level windows in the system, including disabled or invisible unowned windows, overlapped
		/// windows, and pop-up windows. The message is not posted to child windows.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NULL</term>
		/// <term>
		/// The function behaves like a call to PostThreadMessage with the dwThreadId parameter set to the identifier of the current thread.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Starting with Windows Vista, message posting is subject to UIPI. The thread of a process can post messages only to message queues
		/// of threads in processes of lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be posted.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. <c>GetLastError</c>
		/// returns <c>ERROR_NOT_ENOUGH_QUOTA</c> when the limit is hit.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).</para>
		/// <para>Messages in a message queue are retrieved by calls to the GetMessage or PeekMessage function.</para>
		/// <para>
		/// Applications that need to communicate using <c>HWND_BROADCAST</c> should use the RegisterWindowMessage function to obtain a
		/// unique message for inter-application communication.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// <para>
		/// If you send a message in the range below WM_USER to the asynchronous message functions ( <c>PostMessage</c>, SendNotifyMessage,
		/// and SendMessageCallback), its message parameters cannot include pointers. Otherwise, the operation will fail. The functions will
		/// return before the receiving thread has had a chance to process the message and the sender will free the memory before it is used.
		/// </para>
		/// <para>Do not post the WM_QUIT message using <c>PostMessage</c>; use the PostQuitMessage function.</para>
		/// <para>
		/// An accessibility application can use <c>PostMessage</c> to post WM_APPCOMMAND messages to the shell to launch applications. This
		/// functionality is not guaranteed to work for other types of applications.
		/// </para>
		/// <para>
		/// There is a limit of 10,000 posted messages per message queue. This limit should be sufficiently large. If your application
		/// exceeds the limit, it should be redesigned to avoid consuming so many system resources. To adjust this limit, modify the
		/// following registry key.
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE</c><c>SOFTWARE</c><c>Microsoft</c><c>Windows NT</c><c>CurrentVersion</c><c>Windows</c><c>USERPostMessageLimit</c></para>
		/// <para>The minimum acceptable value is 4000.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to post a private window message using the <c>PostMessage</c> function. Assume you defined a
		/// private window message called <c>WM_COMPLETE</c>:
		/// </para>
		/// <para>You can post a message to the message queue associated with the thread that created the specified window as shown below:</para>
		/// <para>For more examples, see Initiating a Data Link.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-postmessagea BOOL PostMessageA( HWND hWnd, UINT Msg,
		// WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PostMessage(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a WM_DESTROY message.
		/// </summary>
		/// <param name="nExitCode">
		/// <para>Type: <c>int</c></para>
		/// <para>The application exit code. This value is used as the wParam parameter of the WM_QUIT message.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>PostQuitMessage</c> function posts a WM_QUIT message to the thread's message queue and returns immediately; the function
		/// simply indicates to the system that the thread is requesting to quit at some time in the future.
		/// </para>
		/// <para>
		/// When the thread retrieves the WM_QUIT message from its message queue, it should exit its message loop and return control to the
		/// system. The exit value returned to the system must be the wParam parameter of the <c>WM_QUIT</c> message.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Posting a Message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-postquitmessage void PostQuitMessage( int nExitCode );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern void PostQuitMessage(int nExitCode);

		/// <summary>
		/// Posts a message to the message queue of the specified thread. It returns without waiting for the thread to process the message.
		/// </summary>
		/// <param name="idThread">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The identifier of the thread to which the message is to be posted.</para>
		/// <para>
		/// The function fails if the specified thread does not have a message queue. The system creates a thread's message queue when the
		/// thread makes its first call to one of the User or GDI functions. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// Message posting is subject to UIPI. The thread of a process can post messages only to posted-message queues of threads in
		/// processes of lesser or equal integrity level.
		/// </para>
		/// <para>
		/// This thread must have the <c>SE_TCB_NAME</c> privilege to post a message to a thread that belongs to a process with the same
		/// locally unique identifier (LUID) but is in a different desktop. Otherwise, the function fails and returns <c>ERROR_INVALID_THREAD_ID</c>.
		/// </para>
		/// <para>
		/// This thread must either belong to the same desktop as the calling thread or to a process with the same LUID. Otherwise, the
		/// function fails and returns <c>ERROR_INVALID_THREAD_ID</c>.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The type of message to be posted.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. <c>GetLastError</c>
		/// returns <c>ERROR_INVALID_THREAD_ID</c> if idThread is not a valid thread identifier, or if the thread specified by idThread does
		/// not have a message queue. <c>GetLastError</c> returns <c>ERROR_NOT_ENOUGH_QUOTA</c> when the message limit is hit.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).</para>
		/// <para>
		/// The thread to which the message is posted must have created a message queue, or else the call to <c>PostThreadMessage</c> fails.
		/// Use the following method to handle this situation.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Create an event object, then create the thread.</term>
		/// </item>
		/// <item>
		/// <term>Use the WaitForSingleObject function to wait for the event to be set to the signaled state before calling <c>PostThreadMessage</c>.</term>
		/// </item>
		/// <item>
		/// <term>
		/// In the thread to which the message will be posted, call PeekMessage as shown here to force the system to create the message queue.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Set the event, to indicate that the thread is ready to receive posted messages.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The thread to which the message is posted retrieves the message by calling the GetMessage or PeekMessage function. The
		/// <c>hwnd</c> member of the returned MSG structure is <c>NULL</c>.
		/// </para>
		/// <para>
		/// Messages sent by <c>PostThreadMessage</c> are not associated with a window. As a general rule, messages that are not associated
		/// with a window cannot be dispatched by the DispatchMessage function. Therefore, if the recipient thread is in a modal loop (as
		/// used by MessageBox or DialogBox), the messages will be lost. To intercept thread messages while in a modal loop, use a
		/// thread-specific hook.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// <para>
		/// There is a limit of 10,000 posted messages per message queue. This limit should be sufficiently large. If your application
		/// exceeds the limit, it should be redesigned to avoid consuming so many system resources. To adjust this limit, modify the
		/// following registry key.
		/// </para>
		/// <para><c>HKEY_LOCAL_MACHINE</c><c>SOFTWARE</c><c>Microsoft</c><c>Windows NT</c><c>CurrentVersion</c><c>Windows</c><c>USERPostMessageLimit</c></para>
		/// <para>The minimum acceptable value is 4000.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-postthreadmessagea BOOL PostThreadMessageA( DWORD
		// idThread, UINT Msg, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PostThreadMessage(uint idThread, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Defines a new window message that is guaranteed to be unique throughout the system. The message value can be used when sending or
		/// posting messages.
		/// </summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The message to be registered.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>UINT</c></c></para>
		/// <para>If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>RegisterWindowMessage</c> function is typically used to register messages for communicating between two cooperating applications.
		/// </para>
		/// <para>
		/// If two different applications register the same message string, the applications return the same message value. The message
		/// remains registered until the session ends.
		/// </para>
		/// <para>
		/// Only use <c>RegisterWindowMessage</c> when more than one application must process the same message. For sending private messages
		/// within a window class, an application can use any integer in the range WM_USER through 0x7FFF. (Messages in this range are
		/// private to a window class, not to an application. For example, predefined control classes such as <c>BUTTON</c>, <c>EDIT</c>,
		/// <c>LISTBOX</c>, and <c>COMBOBOX</c> may use values in this range.)
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Finding Text.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerwindowmessagea UINT RegisterWindowMessageA( LPCSTR
		// lpString );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		public static extern uint RegisterWindowMessage(string lpString);

		/// <summary>Replies to a message sent from another thread by the SendMessage function.</summary>
		/// <param name="lResult">
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>The result of the message processing. The possible values are based on the message sent.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the calling thread was processing a message sent from another thread or process, the return value is nonzero.</para>
		/// <para>If the calling thread was not processing a message sent from another thread or process, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// By calling this function, the window procedure that receives the message allows the thread that called SendMessage to continue to
		/// run as though the thread receiving the message had returned control. The thread that calls the <c>ReplyMessage</c> function also
		/// continues to run.
		/// </para>
		/// <para>
		/// If the message was not sent through SendMessage or if the message was sent by the same thread, <c>ReplyMessage</c> has no effect.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Sending a Message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-replymessage BOOL ReplyMessage( LRESULT lResult );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReplyMessage(IntPtr lResult);

		/// <summary>
		/// <para>
		/// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window procedure for the specified
		/// window and does not return until the window procedure has processed the message.
		/// </para>
		/// <para>
		/// To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a
		/// thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// <para>
		/// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of
		/// lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
		/// <para>The return value specifies the result of the message processing; it depends on the message sent.</para>
		/// </returns>
		/// <remarks>
		/// <para>When a message is blocked by UIPI the last error, retrieved with GetLastError, is set to 5 (access denied).</para>
		/// <para>
		/// Applications that need to communicate using <c>HWND_BROADCAST</c> should use the RegisterWindowMessage function to obtain a
		/// unique message for inter-application communication.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// <para>
		/// If the specified window was created by the calling thread, the window procedure is called immediately as a subroutine. If the
		/// specified window was created by a different thread, the system switches to that thread and calls the appropriate window
		/// procedure. Messages sent between threads are processed only when the receiving thread executes message retrieval code. The
		/// sending thread is blocked until the receiving thread processes the message. However, the sending thread will process incoming
		/// non-queued messages while waiting for its message to be processed. To prevent this, use SendMessageTimeout with SMTO_BLOCK set.
		/// For more information on non-queued messages, see Non-queued Messages.
		/// </para>
		/// <para>
		/// An accessibility application can use <c>SendMessage</c> to send WM_APPCOMMAND messages to the shell to launch applications. This
		/// functionality is not guaranteed to work for other types of applications.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Displaying Keyboard Input.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-sendmessage LRESULT SendMessage( HWND hWnd, UINT Msg,
		// WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		public static extern IntPtr SendMessage(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. It calls the window procedure for the specified window and returns
		/// immediately if the window belongs to another thread. After the window procedure processes the message, the system calls the
		/// specified callback function, passing the result of the message processing and an application-defined value to the callback function.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lpResultCallBack">
		/// <para>Type: <c>SENDASYNCPROC</c></para>
		/// <para>
		/// A pointer to a callback function that the system calls after the window procedure processes the message. For more information,
		/// see SendAsyncProc.
		/// </para>
		/// <para>
		/// If hWnd is <c>HWND_BROADCAST</c> ((HWND)0xffff), the system calls the SendAsyncProc callback function once for each top-level window.
		/// </para>
		/// </param>
		/// <param name="dwData">
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An application-defined value to be sent to the callback function pointed to by the lpCallBack parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the target window belongs to the same thread as the caller, then the window procedure is called synchronously, and the
		/// callback function is called immediately after the window procedure returns. If the target window belongs to a different thread
		/// from the caller, then the callback function is called only when the thread that called <c>SendMessageCallback</c> also calls
		/// GetMessage, PeekMessage, or WaitMessage.
		/// </para>
		/// <para>
		/// If you send a message in the range below WM_USER to the asynchronous message functions (PostMessage, SendNotifyMessage, and
		/// <c>SendMessageCallback</c>), its message parameters cannot include pointers. Otherwise, the operation will fail. The functions
		/// will return before the receiving thread has had a chance to process the message and the sender will free the memory before it is used.
		/// </para>
		/// <para>
		/// Applications that need to communicate using <c>HWND_BROADCAST</c> should use the RegisterWindowMessage function to obtain a
		/// unique message for inter-application communication.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-sendmessagecallbacka BOOL SendMessageCallbackA( HWND hWnd,
		// UINT Msg, WPARAM wParam, LPARAM lParam, SENDASYNCPROC lpResultCallBack, ULONG_PTR dwData );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SendMessageCallback(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam, Sendasyncproc lpResultCallBack, UIntPtr dwData);

		/// <summary>Sends the specified message to one or more windows.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window whose window procedure will receive the message.</para>
		/// <para>
		/// If this parameter is <c>HWND_BROADCAST</c> ((HWND)0xffff), the message is sent to all top-level windows in the system, including
		/// disabled or invisible unowned windows. The function does not return until each window has timed out. Therefore, the total wait
		/// time can be up to the value of uTimeout multiplied by the number of top-level windows.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Any additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Any additional message-specific information.</para>
		/// </param>
		/// <param name="fuFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The behavior of this function. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SMTO_ABORTIFHUNG 0x0002</term>
		/// <term>
		/// The function returns without waiting for the time-out period to elapse if the receiving thread appears to not respond or "hangs."
		/// </term>
		/// </item>
		/// <item>
		/// <term>SMTO_BLOCK 0x0001</term>
		/// <term>Prevents the calling thread from processing any other requests until the function returns.</term>
		/// </item>
		/// <item>
		/// <term>SMTO_NORMAL 0x0000</term>
		/// <term>The calling thread is not prevented from processing other requests while waiting for the function to return.</term>
		/// </item>
		/// <item>
		/// <term>SMTO_NOTIMEOUTIFNOTHUNG 0x0008</term>
		/// <term>The function does not enforce the time-out period as long as the receiving thread is processing messages.</term>
		/// </item>
		/// <item>
		/// <term>SMTO_ERRORONEXIT 0x0020</term>
		/// <term>
		/// The function should return 0 if the receiving window is destroyed or its owning thread dies while the message is being processed.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="uTimeout">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The duration of the time-out period, in milliseconds. If the message is a broadcast message, each window can use the full
		/// time-out period. For example, if you specify a five second time-out period and there are three top-level windows that fail to
		/// process the message, you could have up to a 15 second delay.
		/// </para>
		/// </param>
		/// <param name="lpdwResult">
		/// <para>Type: <c>PDWORD_PTR</c></para>
		/// <para>The result of the message processing. The value of this parameter depends on the message that is specified.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>LRESULT</c></c></para>
		/// <para>
		/// If the function succeeds, the return value is nonzero. <c>SendMessageTimeout</c> does not provide information about individual
		/// windows timing out if <c>HWND_BROADCAST</c> is used.
		/// </para>
		/// <para>
		/// If the function fails or times out, the return value is 0. To get extended error information, call GetLastError. If
		/// <c>GetLastError</c> returns <c>ERROR_TIMEOUT</c>, then the function timed out.
		/// </para>
		/// <para><c>Windows 2000:</c> If GetLastError returns 0, then the function timed out.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The function calls the window procedure for the specified window and, if the specified window belongs to a different thread, does
		/// not return until the window procedure has processed the message or the specified time-out period has elapsed. If the window
		/// receiving the message belongs to the same queue as the current thread, the window procedure is called directly—the time-out value
		/// is ignored.
		/// </para>
		/// <para>
		/// This function considers that a thread is not responding if it has not called GetMessage or a similar function within five seconds.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-sendmessagetimeouta LRESULT SendMessageTimeoutA( HWND
		// hWnd, UINT Msg, WPARAM wParam, LPARAM lParam, UINT fuFlags, UINT uTimeout, PDWORD_PTR lpdwResult );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		public static extern IntPtr SendMessageTimeout(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam, SMTO fuFlags, uint uTimeout, ref IntPtr lpdwResult);

		/// <summary>
		/// Sends the specified message to a window or windows. If the window was created by the calling thread, <c>SendNotifyMessage</c>
		/// calls the window procedure for the window and does not return until the window procedure has processed the message. If the window
		/// was created by a different thread, <c>SendNotifyMessage</c> passes the message to the window procedure and returns immediately;
		/// it does not wait for the window procedure to finish processing the message.
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// </param>
		/// <param name="Msg">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>Additional message-specific information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you send a message in the range below WM_USER to the asynchronous message functions (PostMessage, <c>SendNotifyMessage</c>,
		/// and SendMessageCallback), its message parameters cannot include pointers. Otherwise, the operation will fail. The functions will
		/// return before the receiving thread has had a chance to process the message and the sender will free the memory before it is used.
		/// </para>
		/// <para>
		/// Applications that need to communicate using <c>HWND_BROADCAST</c> should use the RegisterWindowMessage function to obtain a
		/// unique message for inter-application communication.
		/// </para>
		/// <para>
		/// The system only does marshaling for system messages (those in the range 0 to (WM_USER-1)). To send other messages (those &gt;=
		/// <c>WM_USER</c>) to another process, you must do custom marshaling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-sendnotifymessagea BOOL SendNotifyMessageA( HWND hWnd,
		// UINT Msg, WPARAM wParam, LPARAM lParam );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SendNotifyMessage(HWND hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Sets the extra message information for the current thread. Extra message information is an application- or driver-defined value
		/// associated with the current thread's message queue. An application can use the GetMessageExtraInfo function to retrieve a
		/// thread's extra message information.
		/// </summary>
		/// <param name="lParam">
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>The value to be associated with the current thread.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>LPARAM</c></c></para>
		/// <para>The return value is the previous value associated with the current thread.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setmessageextrainfo LPARAM SetMessageExtraInfo( LPARAM
		// lParam );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern IntPtr SetMessageExtraInfo(IntPtr lParam);

		/// <summary>
		/// Translates virtual-key messages into character messages. The character messages are posted to the calling thread's message queue,
		/// to be read the next time the thread calls the GetMessage or PeekMessage function.
		/// </summary>
		/// <param name="lpMsg">
		/// <para>Type: <c>const MSG*</c></para>
		/// <para>
		/// A pointer to an MSG structure that contains message information retrieved from the calling thread's message queue by using the
		/// GetMessage or PeekMessage function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>
		/// If the message is translated (that is, a character message is posted to the thread's message queue), the return value is nonzero.
		/// </para>
		/// <para>
		/// If the message is WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, the return value is nonzero, regardless of the translation.
		/// </para>
		/// <para>
		/// If the message is not translated (that is, a character message is not posted to the thread's message queue), the return value is zero.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>TranslateMessage</c> function does not modify the message pointed to by the lpMsg parameter.</para>
		/// <para>
		/// WM_KEYDOWN and WM_KEYUP combinations produce a WM_CHAR or WM_DEADCHAR message. WM_SYSKEYDOWN and WM_SYSKEYUP combinations produce
		/// a WM_SYSCHAR or WM_SYSDEADCHAR message.
		/// </para>
		/// <para><c>TranslateMessage</c> produces WM_CHAR messages only for keys that are mapped to ASCII characters by the keyboard driver.</para>
		/// <para>
		/// If applications process virtual-key messages for some other purpose, they should not call <c>TranslateMessage</c>. For instance,
		/// an application should not call <c>TranslateMessage</c> if the TranslateAccelerator function returns a nonzero value. Note that
		/// the application is responsible for retrieving and dispatching input messages to the dialog box. Most applications use the main
		/// message loop for this. However, to permit the user to move to and to select controls by using the keyboard, the application must
		/// call IsDialogMessage. For more information, see Dialog Box Keyboard Interface.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Message Loop.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-translatemessage BOOL TranslateMessage( const MSG *lpMsg );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TranslateMessage(in MSG lpMsg);

		/// <summary>
		/// Yields control to other threads when a thread has no other messages in its message queue. The <c>WaitMessage</c> function
		/// suspends the thread and does not return until a new message is placed in the thread's message queue.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// Note that <c>WaitMessage</c> does not return if there is unread input in the message queue after the thread has called a function
		/// to check the queue. This is because functions such as PeekMessage, GetMessage, GetQueueStatus, <c>WaitMessage</c>,
		/// MsgWaitForMultipleObjects, and MsgWaitForMultipleObjectsEx check the queue and then change the state information for the queue so
		/// that the input is no longer considered new. A subsequent call to <c>WaitMessage</c> will not return until new input of the
		/// specified type arrives. The existing unread input (received prior to the last time the thread checked the queue) is ignored.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-waitmessage BOOL WaitMessage( );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WaitMessage();

		/// <summary>Contains information about a window that denied a request from BroadcastSystemMessageEx.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-__unnamed_struct_2 typedef struct { UINT cbSize; HDESK
		// hdesk; HWND hwnd; LUID luid; } BSMINFO, *PBSMINFO;
		[PInvokeData("winuser.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BSMINFO
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The size, in bytes, of this structure.</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>HDESK</c></para>
			/// <para>
			/// A desktop handle to the window specified by <c>hwnd</c>. This value is returned only if BroadcastSystemMessageEx specifies
			/// <c>BSF_RETURNHDESK</c> and <c>BSF_QUERY</c>.
			/// </para>
			/// </summary>
			public HDESK hdesk;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that denied the request. This value is returned if BroadcastSystemMessageEx specifies <c>BSF_QUERY</c>.</para>
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// <para>Type: <c>LUID</c></para>
			/// <para>A locally unique identifier (LUID) for the window.</para>
			/// </summary>
			public uint luid;
		}
	}
}