using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The state of the other mouse buttons plus the SHIFT and CTRL keys.</summary>
		[PInvokeData("winuser.h")]
		[Flags]
		public enum MouseButtonState
		{
			/// <summary>The left mouse button is down.</summary>
			MK_LBUTTON = 0x0001,

			/// <summary>The right mouse button is down.</summary>
			MK_RBUTTON = 0x0002,

			/// <summary>The SHIFT key is down.</summary>
			MK_SHIFT = 0x0004,

			/// <summary>The CTRL key is down.</summary>
			MK_CONTROL = 0x0008,

			/// <summary>The middle mouse button is down.</summary>
			MK_MBUTTON = 0x0010,

			/// <summary>The XBUTTON1 button is down.</summary>
			MK_XBUTTON1 = 0x0020,

			/// <summary>The XBUTTON2 button is down.</summary>
			MK_XBUTTON2 = 0x0040,
		}

		/// <summary>The services requested in a <see cref="TRACKMOUSEEVENT"/> structure.</summary>
		[Flags]
		public enum TME : uint
		{
			/// <summary>
			/// The caller wants to cancel a prior tracking request. The caller should also specify the type of tracking that it wants to
			/// cancel. For example, to cancel hover tracking, the caller must pass the TME_CANCEL and TME_HOVER flags.
			/// </summary>
			TME_CANCEL = 0x80000000,

			/// <summary>
			/// The caller wants hover notification. Notification is delivered as a WM_MOUSEHOVER message.
			/// <para>If the caller requests hover tracking while hover tracking is already active, the hover timer will be reset.</para>
			/// <para>This flag is ignored if the mouse pointer is not over the specified window or area.</para>
			/// </summary>
			TME_HOVER = 0x00000001,

			/// <summary>
			/// The caller wants leave notification. Notification is delivered as a WM_MOUSELEAVE message. If the mouse is not over the
			/// specified window or area, a leave notification is generated immediately and no further tracking is performed.
			/// </summary>
			TME_LEAVE = 0x00000002,

			/// <summary>
			/// The caller wants hover and leave notification for the nonclient areas. Notification is delivered as WM_NCMOUSEHOVER and
			/// WM_NCMOUSELEAVE messages.
			/// </summary>
			TME_NONCLIENT = 0x00000010,

			/// <summary>
			/// The function fills in the structure instead of treating it as a tracking request. The structure is filled such that had that
			/// structure been passed to TrackMouseEvent, it would generate the current tracking. The only anomaly is that the hover time-out
			/// returned is always the actual time-out and not HOVER_DEFAULT, if HOVER_DEFAULT was specified during the original
			/// TrackMouseEvent request.
			/// </summary>
			TME_QUERY = 0x40000000,
		}

		/// <summary>Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time.</summary>
		/// <param name="lpEventTrack">
		/// <para>Type: <c>LPTRACKMOUSEEVENT</c></para>
		/// <para>A pointer to a <c>TRACKMOUSEEVENT</c> structure that contains tracking information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero .</para>
		/// <para>If the function fails, return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TrackMouseEvent( _Inout_ LPTRACKMOUSEEVENT lpEventTrack); https://msdn.microsoft.com/en-us/library/windows/desktop/ms646265(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms646265")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

		/// <summary>
		/// Used by the TrackMouseEvent function to track when the mouse pointer leaves a window or hovers over a window for a specified
		/// amount of time.
		/// </summary>
		[PInvokeData("Winuser.h", MSDNShortId = "ms645604")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TRACKMOUSEEVENT
		{
			/// <summary>The size of the TRACKMOUSEEVENT structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>The services requested</summary>
			public TME dwFlags;

			/// <summary>A handle to the window to track.</summary>
			public HWND hwndTrack;

			/// <summary>
			/// The hover time-out (if TME_HOVER was specified in dwFlags), in milliseconds. Can be HOVER_DEFAULT, which means to use the
			/// system default hover time-out.
			/// </summary>
			public uint dwHoverTime;
		}
	}
}