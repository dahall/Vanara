using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		private const int TRBN_FIRST = -1501;

		/// <summary>Custom Draw values, for example, are specified in the dwItemSpec member of the NMCUSTOMDRAW structure.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760143")]
		public enum TrackBarCustomDraw
		{
			/// <summary>Identifies the channel that the trackbar control's thumb marker slides along.</summary>
			TBCD_CHANNEL = 0x0003,

			/// <summary>Identifies the trackbar control's thumb marker. This is the part of the control that the user moves.</summary>
			TBCD_THUMB = 0x0002,

			/// <summary>Identifies the tick marks that are displayed along the trackbar control's edge.</summary>
			TBCD_TICS = 0x0001,
		}

		/// <summary>Messages for trackbar.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "ff486075")]
		public enum TrackBarMessage
		{
			/// <summary>
			/// Retrieves the current logical position of the slider in a trackbar. The logical positions are the integer values in the
			/// trackbar's range of minimum to maximum slider positions.
			/// </summary>
			TBM_GETPOS = WindowMessage.WM_USER,

			/// <summary>Retrieves the minimum position for the slider in a trackbar.</summary>
			TBM_GETRANGEMIN = WindowMessage.WM_USER + 1,

			/// <summary>Retrieves the maximum position for the slider in a trackbar.</summary>
			TBM_GETRANGEMAX = WindowMessage.WM_USER + 2,

			/// <summary>
			/// Retrieves the logical position of a tick mark in a trackbar. The logical position can be any of the integer values in the
			/// trackbar's range of minimum to maximum slider positions.
			/// </summary>
			TBM_GETTIC = WindowMessage.WM_USER + 3,

			/// <summary>Sets a tick mark in a trackbar at the specified logical position.</summary>
			TBM_SETTIC = WindowMessage.WM_USER + 4,

			/// <summary>Sets the current logical position of the slider in a trackbar.</summary>
			TBM_SETPOS = WindowMessage.WM_USER + 5,

			/// <summary>Sets the range of minimum and maximum logical positions for the slider in a trackbar.</summary>
			TBM_SETRANGE = WindowMessage.WM_USER + 6,

			/// <summary>Sets the minimum logical position for the slider in a trackbar.</summary>
			TBM_SETRANGEMIN = WindowMessage.WM_USER + 7,

			/// <summary>Sets the maximum logical position for the slider in a trackbar.</summary>
			TBM_SETRANGEMAX = WindowMessage.WM_USER + 8,

			/// <summary>
			/// Removes the current tick marks from a trackbar. This message does not remove the first and last tick marks, which are created
			/// automatically by the trackbar.
			/// </summary>
			TBM_CLEARTICS = WindowMessage.WM_USER + 9,

			/// <summary>Sets the starting and ending positions for the available selection range in a trackbar.</summary>
			TBM_SETSEL = WindowMessage.WM_USER + 10,

			/// <summary>
			/// Sets the starting logical position of the current selection range in a trackbar. This message is ignored if the trackbar does
			/// not have the TBS_ENABLESELRANGE style.
			/// </summary>
			TBM_SETSELSTART = WindowMessage.WM_USER + 11,

			/// <summary>
			/// Sets the ending logical position of the current selection range in a trackbar. This message is ignored if the trackbar does
			/// not have the TBS_ENABLESELRANGE style.
			/// </summary>
			TBM_SETSELEND = WindowMessage.WM_USER + 12,

			/// <summary>Retrieves the address of an array that contains the positions of the tick marks for a trackbar.</summary>
			TBM_GETPTICS = WindowMessage.WM_USER + 14,

			/// <summary>Retrieves the current physical position of a tick mark in a trackbar.</summary>
			TBM_GETTICPOS = WindowMessage.WM_USER + 15,

			/// <summary>Retrieves the number of tick marks in a trackbar.</summary>
			TBM_GETNUMTICS = WindowMessage.WM_USER + 16,

			/// <summary>Retrieves the starting position of the current selection range in a trackbar.</summary>
			TBM_GETSELSTART = WindowMessage.WM_USER + 17,

			/// <summary>Retrieves the ending position of the current selection range in a trackbar.</summary>
			TBM_GETSELEND = WindowMessage.WM_USER + 18,

			/// <summary>Clears the current selection range in a trackbar.</summary>
			TBM_CLEARSEL = WindowMessage.WM_USER + 19,

			/// <summary>
			/// Sets the interval frequency for tick marks in a trackbar. For example, if the frequency is set to two, a tick mark is
			/// displayed for every other increment in the trackbar's range. The default setting for the frequency is one; that is, every
			/// increment in the range is associated with a tick mark.
			/// </summary>
			TBM_SETTICFREQ = WindowMessage.WM_USER + 20,

			/// <summary>
			/// Sets the number of logical positions the trackbar's slider moves in response to keyboard input, such as the or keys, or mouse
			/// input, such as clicks in the trackbar's channel. The logical positions are the integer increments in the trackbar's range of
			/// minimum to maximum slider positions.
			/// </summary>
			TBM_SETPAGESIZE = WindowMessage.WM_USER + 21,

			/// <summary>
			/// Retrieves the number of logical positions the trackbar's slider moves in response to keyboard input, such as the or keys, or
			/// mouse input, such as clicks in the trackbar's channel. The logical positions are the integer increments in the trackbar's
			/// range of minimum to maximum slider positions.
			/// </summary>
			TBM_GETPAGESIZE = WindowMessage.WM_USER + 22,

			/// <summary>
			/// Sets the number of logical positions the trackbar's slider moves in response to keyboard input from the arrow keys, such as
			/// the or keys. The logical positions are the integer increments in the trackbar's range of minimum to maximum slider positions.
			/// </summary>
			TBM_SETLINESIZE = WindowMessage.WM_USER + 23,

			/// <summary>
			/// Retrieves the number of logical positions the trackbar's slider moves in response to keyboard input from the arrow keys, such
			/// as the or keys. The logical positions are the integer increments in the trackbar's range of minimum to maximum slider positions.
			/// </summary>
			TBM_GETLINESIZE = WindowMessage.WM_USER + 24,

			/// <summary>Retrieves the size and position of the bounding rectangle for the slider in a trackbar.</summary>
			TBM_GETTHUMBRECT = WindowMessage.WM_USER + 25,

			/// <summary>
			/// Retrieves the size and position of the bounding rectangle for a trackbar's channel. (The channel is the area over which the
			/// slider moves. It contains the highlight when a range is selected.)
			/// </summary>
			TBM_GETCHANNELRECT = WindowMessage.WM_USER + 26,

			/// <summary>
			/// Sets the length of the slider in a trackbar. This message is ignored if the trackbar does not have the TBS_FIXEDLENGTH style.
			/// </summary>
			TBM_SETTHUMBLENGTH = WindowMessage.WM_USER + 27,

			/// <summary>Retrieves the length of the slider in a trackbar.</summary>
			TBM_GETTHUMBLENGTH = WindowMessage.WM_USER + 28,

			/// <summary>Assigns a tooltip control to a trackbar control.</summary>
			TBM_SETTOOLTIPS = WindowMessage.WM_USER + 29,

			/// <summary>Retrieves the handle to the tooltip control assigned to the trackbar, if any.</summary>
			TBM_GETTOOLTIPS = WindowMessage.WM_USER + 30,

			/// <summary>
			/// Positions a tooltip control used by a trackbar control. TrackBar controls that use the TBS_TOOLTIPS style display tooltips.
			/// </summary>
			TBM_SETTIPSIDE = WindowMessage.WM_USER + 31,

			/// <summary>
			/// Assigns a window as the buddy window for a trackbar control. TrackBar buddy windows are automatically displayed in a location
			/// relative to the control's orientation (horizontal or vertical).
			/// </summary>
			TBM_SETBUDDY = WindowMessage.WM_USER + 32,

			/// <summary>
			/// Retrieves the handle to a trackbar control buddy window at a given location. The specified location is relative to the
			/// control's orientation (horizontal or vertical).
			/// </summary>
			TBM_GETBUDDY = WindowMessage.WM_USER + 33,

			/// <summary>Sets the current logical position of the slider in a trackbar.</summary>
			TBM_SETPOSNOTIFY = WindowMessage.WM_USER + 34,

			/// <summary>
			/// Sets the Unicode character format flag for the control. This message allows you to change the character set used by the
			/// control at run time rather than having to re-create the control.
			/// </summary>
			TBM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,

			/// <summary>Retrieves the Unicode character format flag for the control.</summary>
			TBM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT
		}

		/// <summary>Notification messages for trackbar.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760172")]
		public enum TrackBarNotification
		{
			/// <summary>
			/// Notifies that the thumb position on a trackbar is changing. This notification code is sent in the form of a WM_NOTIFY message.
			/// </summary>
			/// <remarks>
			/// Send this notification to clients that do not listen for WM_HSCROLL or WM_VSCROLL messages.
			/// <para>lPara value</para>
			/// <para>
			/// Pointer to a NMTRBTHUMBPOSCHANGING structure. The caller is responsible for allocating this structure and setting its
			/// members, including the members of the contained NMHDR structure.
			/// </para>
			/// <para>Return value</para>
			/// <para>The return value is ignored.</para>
			/// </remarks>
			TRBN_THUMBPOSCHANGING = TRBN_FIRST
		}

		/// <summary>A notification code that indicates the user's interaction with the trackbar.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760153")]
		public enum TrackBarScrollNotification
		{
			/// <summary>The user pressed the LEFT ARROW (VK_LEFT) or UP ARROW (VK_UP) key.</summary>
			TB_LINEUP = 0,

			/// <summary>The user pressed the RIGHT ARROW (VK_RIGHT) or DOWN ARROW (VK_DOWN) key.</summary>
			TB_LINEDOWN = 1,

			/// <summary>The user clicked the channel above or to the left of the slider (VK_PRIOR).</summary>
			TB_PAGEUP = 2,

			/// <summary>The user clicked the channel below or to the right of the slider (VK_NEXT).</summary>
			TB_PAGEDOWN = 3,

			/// <summary>The trackbar received WM_LBUTTONUP following a TB_THUMBTRACK notification code.</summary>
			TB_THUMBPOSITION = 4,

			/// <summary>The user dragged the slider.</summary>
			TB_THUMBTRACK = 5,

			/// <summary>The user pressed the HOME key (VK_HOME).</summary>
			TB_TOP = 6,

			/// <summary>The user pressed the END key (VK_END).</summary>
			TB_BOTTOM = 7,

			/// <summary>The trackbar received WM_KEYUP, meaning that the user released a key that sent a relevant virtual key code.</summary>
			TB_ENDTRACK = 8,
		}

		/// <summary>The styles used with trackbar controls.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760147")]
		public enum TrackBarStyle
		{
			/// <summary>The trackbar control has a tick mark for each increment in its range of values.</summary>
			TBS_AUTOTICKS = 0x0001,

			/// <summary>The trackbar control is oriented vertically.</summary>
			TBS_VERT = 0x0002,

			/// <summary>The trackbar control is oriented horizontally. This is the default orientation.</summary>
			TBS_HORZ = 0x0000,

			/// <summary>The trackbar control displays tick marks above the control. This style is valid only with TBS_HORZ.</summary>
			TBS_TOP = 0x0004,

			/// <summary>The trackbar control displays tick marks below the control. This style is valid only with TBS_HORZ.</summary>
			TBS_BOTTOM = 0x0000,

			/// <summary>The trackbar control displays tick marks to the left of the control. This style is valid only with TBS_VERT.</summary>
			TBS_LEFT = 0x0004,

			/// <summary>The trackbar control displays tick marks to the right of the control. This style is valid only with TBS_VERT.</summary>
			TBS_RIGHT = 0x0000,

			/// <summary>
			/// The trackbar control displays tick marks on both sides of the control. This will be both top and bottom when used with
			/// TBS_HORZ or both left and right if used with TBS_VERT.
			/// </summary>
			TBS_BOTH = 0x0008,

			/// <summary>The trackbar control does not display any tick marks.</summary>
			TBS_NOTICKS = 0x0010,

			/// <summary>
			/// The trackbar control displays a selection range only. The tick marks at the starting and ending positions of a selection
			/// range are displayed as triangles (instead of vertical dashes), and the selection range is highlighted.
			/// </summary>
			TBS_ENABLESELRANGE = 0x0020,

			/// <summary>The trackbar control allows the size of the slider to be changed with the TBM_SETTHUMBLENGTH message.</summary>
			TBS_FIXEDLENGTH = 0x0040,

			/// <summary>The trackbar control does not display a slider.</summary>
			TBS_NOTHUMB = 0x0080,

			/// <summary>
			/// The trackbar control supports tooltips. When a trackbar control is created using this style, it automatically creates a
			/// default tooltip control that displays the slider's current position. You can change where the tooltips are displayed by using
			/// the TBM_SETTIPSIDE message.
			/// </summary>
			TBS_TOOLTIPS = 0x0100,

			/// <summary>
			/// This style bit is used for "reversed" trackbars, where a smaller number indicates "higher" and a larger number indicates
			/// "lower." It has no effect on the control; it is simply a label that can be checked to determine whether a trackbar is normal
			/// or reversed.
			/// </summary>
			TBS_REVERSED = 0x0200,

			/// <summary>
			/// By default, the trackbar control uses down equal to right and up equal to left. Use the TBS_DOWNISLEFT style to reverse the
			/// default, making down equal left and up equal right.
			/// </summary>
			TBS_DOWNISLEFT = 0x0400,

			/// <summary>TrackBar should notify parent before repositioning the slider due to user action (enables snapping).</summary>
			TBS_NOTIFYBEFOREMOVE = 0x0800,

			/// <summary>Background is painted by the parent via the WM_PRINTCLIENT message.</summary>
			TBS_TRANSPARENTBKGND = 0x1000
		}

		/// <summary>Value representing the location at which to display the tooltip control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760414")]
		public enum TrackBarTipSide
		{
			/// <summary>The tooltip control will be positioned above the trackbar. This flag is for use with horizontal trackbars.</summary>
			TBTS_TOP,

			/// <summary>The tooltip control will be positioned to the left of the trackbar. This flag is for use with vertical trackbars.</summary>
			TBTS_LEFT,

			/// <summary>The tooltip control will be positioned below the trackbar. This flag is for use with horizontal trackbars.</summary>
			TBTS_BOTTOM,

			/// <summary>The tooltip control will be positioned to the right of the trackbar. This flag is for use with vertical trackbars.</summary>
			TBTS_RIGHT,
		}

		/// <summary>Contains information about a trackbar change notification. This message is sent with the TRBN_THUMBPOSCHANGING notification.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760153")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NMTRBTHUMBPOSCHANGING
		{
			/// <summary>Position on trackbar.</summary>
			public uint dwPos;

			/// <summary>A NMHDR structure that describes the notification.</summary>
			public NMHDR hdr;

			/// <summary>
			/// Type of movement as one of the following values: TB_LINEUP, TB_LINEDOWN, TB_PAGEUP, TB_PAGEDOWN, TB_THUMBPOSITION,
			/// TB_THUMBTRACK, TB_TOP, TB_BOTTOM, or TB_ENDTRACK.
			/// </summary>
			public TrackBarScrollNotification nReason;
		}
	}
}