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
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the current logical position of the trackbar's slider.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getpos
			TBM_GETPOS = WindowMessage.WM_USER,

			/// <summary>Retrieves the minimum position for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the minimum position in the trackbar's range of minimum to maximum slider positions.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getrangemin
			TBM_GETRANGEMIN = WindowMessage.WM_USER + 1,

			/// <summary>Retrieves the maximum position for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the maximum position in the trackbar's range of minimum to maximum slider positions.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getrangemax
			TBM_GETRANGEMAX = WindowMessage.WM_USER + 2,

			/// <summary>
			/// Retrieves the logical position of a tick mark in a trackbar. The logical position can be any of the integer values in the
			/// trackbar's range of minimum to maximum slider positions.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Zero-based index identifying a tick mark. Valid indexes are in the range from zero to two less than the tick count returned
			/// by the <c>TBM_GETNUMTICS</c> message.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the logical position of the specified tick mark, or -1 if wParam does not specify a valid index.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-gettic
			TBM_GETTIC = WindowMessage.WM_USER + 3,

			/// <summary>Sets a tick mark in a trackbar at the specified logical position.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Position of the tick mark. This parameter can be any of the integer values in the trackbar's range of minimum to maximum
			/// slider positions.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if the tick mark is set, or <c>FALSE</c> otherwise.</para>
			/// </summary>
			/// <remarks>
			/// A trackbar creates its own first and last tick marks. Do not use this message to set the first and last tick marks.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-settic
			TBM_SETTIC = WindowMessage.WM_USER + 4,

			/// <summary>Sets the current logical position of the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the message redraws the control with the slider at the position given by
			/// lParam. If this parameter is <c>FALSE</c>, the message does not redraw the slider at the new position. Note that the message
			/// sets the value of the slider position (as returned by the <c>TBM_GETPOS</c> message) regardless of the wParam parameter.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// New logical position of the slider. Valid logical positions are the integer values in the trackbar's range of minimum to
			/// maximum slider positions. If this value is outside the control's maximum and minimum range, the position is set to the
			/// maximum or minimum value.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setpos
			TBM_SETPOS = WindowMessage.WM_USER + 5,

			/// <summary>Sets the range of minimum and maximum logical positions for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the trackbar is redrawn after the range is set. If this parameter is
			/// <c>FALSE</c>, the message sets the range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>The <c>LOWORD</c> specifies the minimum position for the slider, and the <c>HIWORD</c> specifies the maximum position.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// If the current slider position is outside the new range, the <c>TBM_SETRANGE</c> message sets the slider position to the new
			/// maximum or minimum value.
			/// </para>
			/// <para>
			/// Because this message takes two 16-bit unsigned integer values, the maximum range that this message can specify is from 0 to
			/// 65,535. To specify larger range values, use the <c>TBM_SETRANGEMIN</c> and <c>TBM_SETRANGEMAX</c> messages.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setrange
			TBM_SETRANGE = WindowMessage.WM_USER + 6,

			/// <summary>Sets the minimum logical position for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the message redraws the trackbar after the range is set. If this parameter is
			/// <c>FALSE</c>, the message sets the range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Minimum position for the slider.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// If the current slider position is less than the new minimum, the <c>TBM_SETRANGEMIN</c> message sets the slider position to
			/// the new minimum value.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setrangemin
			TBM_SETRANGEMIN = WindowMessage.WM_USER + 7,

			/// <summary>Sets the maximum logical position for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the trackbar is redrawn after the range is set. If this parameter is
			/// <c>FALSE</c>, the message sets the range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Maximum position for the slider.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// If the current slider position is greater than the new maximum, the <c>TBM_SETRANGEMAX</c> message sets the slider position
			/// to the new maximum value.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setrangemax
			TBM_SETRANGEMAX = WindowMessage.WM_USER + 8,

			/// <summary>
			/// Removes the current tick marks from a trackbar. This message does not remove the first and last tick marks, which are created
			/// automatically by the trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the trackbar is redrawn after the tick marks are cleared. If this parameter is
			/// <c>FALSE</c>, the message clears the tick marks but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-cleartics
			TBM_CLEARTICS = WindowMessage.WM_USER + 9,

			/// <summary>Sets the starting and ending positions for the available selection range in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the message redraws the trackbar after the selection range is set. If this
			/// parameter is <c>FALSE</c>, the message sets the selection range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// The <c>LOWORD</c> specifies the starting logical position for the selection range, and the <c>HIWORD</c> specifies the ending
			/// logical position.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// <para>This message is ignored if the trackbar does not have the <c>TBS_ENABLESELRANGE</c> style.</para>
			/// <para><c>TBM_SETSEL</c> allows you to restrict the pointer to only a portion of the range available to the progress bar.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setsel
			TBM_SETSEL = WindowMessage.WM_USER + 10,

			/// <summary>
			/// Sets the starting logical position of the current selection range in a trackbar. This message is ignored if the trackbar does
			/// not have the <c>TBS_ENABLESELRANGE</c> style.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the message redraws the trackbar after the selection range is set. If this
			/// parameter is <c>FALSE</c>, the message sets the selection range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Starting position of the selection range.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setselstart
			TBM_SETSELSTART = WindowMessage.WM_USER + 11,

			/// <summary>
			/// Sets the ending logical position of the current selection range in a trackbar. This message is ignored if the trackbar does
			/// not have the <c>TBS_ENABLESELRANGE</c> style.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Redraw flag. If this parameter is <c>TRUE</c>, the message redraws the trackbar after the selection range is set. If this
			/// parameter is <c>FALSE</c>, the message sets the selection range but does not redraw the trackbar.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Ending logical position of the selection range.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setselend
			TBM_SETSELEND = WindowMessage.WM_USER + 12,

			/// <summary>Retrieves the address of an array that contains the positions of the tick marks for a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the address of an array of <c>DWORD</c> values. The elements of the array specify the logical positions of the
			/// trackbar's tick marks, not including the first and last tick marks created by the trackbar. The logical positions can be any
			/// of the integer values in the trackbar's range of minimum to maximum slider positions.
			/// </para>
			/// </summary>
			/// <remarks>
			/// The number of elements in the array is two less than the tick count returned by the <c>TBM_GETNUMTICS</c> message. Note that
			/// the values in the array may include duplicate positions and may not be in sequential order. The returned pointer is valid
			/// until you change the trackbar's tick marks.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getptics
			TBM_GETPTICS = WindowMessage.WM_USER + 14,

			/// <summary>Retrieves the current physical position of a tick mark in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Zero-based index identifying a tick mark. The positions of the first and last tick marks are not directly available via this message.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the distance, in client coordinates, from the left or top of the trackbar's client area to the specified tick mark.
			/// The return value is the x-coordinate of the tick mark for a horizontal trackbar or the y-coordinate for a vertical trackbar.
			/// If wParam is not a valid index, the return value is -1.
			/// </para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// Because the first and last tick marks are not available through this message, valid indexes are offset from their tick
			/// position on the trackbar. If the difference between <c>TBM_GETRANGEMIN</c> and <c>TBM_GETRANGEMAX</c> is less than two, then
			/// there is no valid index and this message will fail.
			/// </para>
			/// <para>
			/// The following illustrates the relation between the ticks on a trackbar, the ticks available through this message, and their
			/// zero-based indexes.
			/// </para>
			/// <para>
			/// <code>0 1 2 3 4 5 6 7 8 9 // Tick positions seen on the trackbar. 1 2 3 4 5 6 7 8 // Tick positions whose position can be identified. 0 1 2 3 4 5 6 7 // Index numbers for the identifiable positions.</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getticpos
			TBM_GETTICPOS = WindowMessage.WM_USER + 15,

			/// <summary>Retrieves the number of tick marks in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// If no tick flag is set, it returns 2 for the beginning and ending ticks. If <c>TBS_NOTICKS</c> is set, it returns zero.
			/// Otherwise, it takes the difference between the range minimum and maximum, divides by the tick frequency, and adds 2.
			/// </para>
			/// </summary>
			/// <remarks>
			/// The <c>TBM_GETNUMTICS</c> message counts all of the tick marks, including the first and last tick marks created by the trackbar.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getnumtics
			TBM_GETNUMTICS = WindowMessage.WM_USER + 16,

			/// <summary>Retrieves the starting position of the current selection range in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the starting position of the current selection range.</para>
			/// </summary>
			/// <remarks>
			/// A trackbar can have a selection range only if you specified the <c>TBS_ENABLESELRANGE</c> style when you created it.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getselstart
			TBM_GETSELSTART = WindowMessage.WM_USER + 17,

			/// <summary>Retrieves the ending position of the current selection range in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the ending position of the current selection range.</para>
			/// </summary>
			/// <remarks>
			/// A trackbar can have a selection range only if you specified the <c>TBS_ENABLESELRANGE</c> style when you created it.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getselend
			TBM_GETSELEND = WindowMessage.WM_USER + 18,

			/// <summary>Clears the current selection range in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Redraw flag. If this parameter is <c>TRUE</c>, the trackbar is redrawn after the selection is cleared.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// A trackbar can have a selection range only if you specified the <c>TBS_ENABLESELRANGE</c> style when you created it.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-clearsel
			TBM_CLEARSEL = WindowMessage.WM_USER + 19,

			/// <summary>
			/// Sets the interval frequency for tick marks in a trackbar. For example, if the frequency is set to two, a tick mark is
			/// displayed for every other increment in the trackbar's range. The default setting for the frequency is one; that is, every
			/// increment in the range is associated with a tick mark.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Frequency of the tick marks.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>The trackbar must have the <c>TBS_AUTOTICKS</c> style to use this message.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setticfreq
			TBM_SETTICFREQ = WindowMessage.WM_USER + 20,

			/// <summary>
			/// Sets the number of logical positions the trackbar's slider moves in response to keyboard input, such as the or keys, or mouse
			/// input, such as clicks in the trackbar's channel. The logical positions are the integer increments in the trackbar's range of
			/// minimum to maximum slider positions.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>New page size.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the previous page size.</para>
			/// </summary>
			/// <remarks>
			/// The trackbar also sends a <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> message with the TB_PAGEUP and TB_PAGEDOWN notification
			/// codes to its parent window when it receives keyboard or mouse input that scrolls the page.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setpagesize
			TBM_SETPAGESIZE = WindowMessage.WM_USER + 21,

			/// <summary>
			/// Retrieves the number of logical positions the trackbar's slider moves in response to keyboard input, such as the or keys, or
			/// mouse input, such as clicks in the trackbar's channel. The logical positions are the integer increments in the trackbar's
			/// range of minimum to maximum slider positions.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the page size for the trackbar.</para>
			/// </summary>
			/// <remarks>
			/// The trackbar also sends a <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> message with the TB_PAGEUP and TB_PAGEDOWN notification
			/// codes to its parent window when it receives keyboard or mouse input that scrolls the page.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getpagesize
			TBM_GETPAGESIZE = WindowMessage.WM_USER + 22,

			/// <summary>
			/// Sets the number of logical positions the trackbar's slider moves in response to keyboard input from the arrow keys, such as
			/// the or keys. The logical positions are the integer increments in the trackbar's range of minimum to maximum slider positions.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>New line size.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the previous line size.</para>
			/// </summary>
			/// <remarks>
			/// <para>The default setting for the line size is 1.</para>
			/// <para>
			/// The trackbar also sends a <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> message with the TB_LINEUP and TB_LINEDOWN notification
			/// codes to its parent window when the user presses the arrow keys.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setlinesize
			TBM_SETLINESIZE = WindowMessage.WM_USER + 23,

			/// <summary>
			/// Retrieves the number of logical positions the trackbar's slider moves in response to keyboard input from the arrow keys, such
			/// as the or keys. The logical positions are the integer increments in the trackbar's range of minimum to maximum slider positions.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a 32-bit value that specifies the line size for the trackbar.</para>
			/// </summary>
			/// <remarks>
			/// <para>The default setting for the line size is 1.</para>
			/// <para>
			/// The trackbar also sends a <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> message with the TB_LINEUP and TB_LINEDOWN notification
			/// codes to its parent window when the user presses the arrow keys.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getlinesize
			TBM_GETLINESIZE = WindowMessage.WM_USER + 24,

			/// <summary>Retrieves the size and position of the bounding rectangle for the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>RECT</c> structure. The message fills this structure with the bounding rectangle of the trackbar's slider in
			/// client coordinates of the trackbar's window.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getthumbrect
			TBM_GETTHUMBRECT = WindowMessage.WM_USER + 25,

			/// <summary>
			/// Retrieves the size and position of the bounding rectangle for a trackbar's channel. (The channel is the area over which the
			/// slider moves. It contains the highlight when a range is selected.)
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>RECT</c> structure. The message fills this structure with the channel's bounding rectangle, in client
			/// coordinates of the trackbar's window.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getchannelrect
			TBM_GETCHANNELRECT = WindowMessage.WM_USER + 26,

			/// <summary>
			/// Sets the length of the slider in a trackbar. This message is ignored if the trackbar does not have the <c>TBS_FIXEDLENGTH</c> style.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Length, in pixels, of the slider.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setthumblength
			TBM_SETTHUMBLENGTH = WindowMessage.WM_USER + 27,

			/// <summary>Retrieves the length of the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the length, in pixels, of the slider.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getthumblength
			TBM_GETTHUMBLENGTH = WindowMessage.WM_USER + 28,

			/// <summary>Assigns a tooltip control to a trackbar control.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Handle to an existing tooltip control.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// </summary>
			/// <remarks>
			/// When a trackbar control is created with the <c>TBS_TOOLTIPS</c> style, it creates a default tooltip control that appears next
			/// to the slider, displaying the slider's current position.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-settooltips
			TBM_SETTOOLTIPS = WindowMessage.WM_USER + 29,

			/// <summary>Retrieves the handle to the tooltip control assigned to the trackbar, if any.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the handle to the tooltip control assigned to the trackbar, or <c>NULL</c> if tooltips are not in use. If the
			/// trackbar control does not use the <c>TBS_TOOLTIPS</c> style, the return value is <c>NULL</c>.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-gettooltips
			TBM_GETTOOLTIPS = WindowMessage.WM_USER + 30,

			/// <summary>
			/// Positions a tooltip control used by a trackbar control. Trackbar controls that use the <c>TBS_TOOLTIPS</c> style display tooltips.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Value representing the location at which to display the tooltip control. This value can be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TBTS_TOP</c></term>
			/// <term>The tooltip control will be positioned above the trackbar. This flag is for use with horizontal trackbars.</term>
			/// </item>
			/// <item>
			/// <term><c>TBTS_LEFT</c></term>
			/// <term>The tooltip control will be positioned to the left of the trackbar. This flag is for use with vertical trackbars.</term>
			/// </item>
			/// <item>
			/// <term><c>TBTS_BOTTOM</c></term>
			/// <term>The tooltip control will be positioned below the trackbar. This flag is for use with horizontal trackbars.</term>
			/// </item>
			/// <item>
			/// <term><c>TBTS_RIGHT</c></term>
			/// <term>The tooltip control will be positioned to the right of the trackbar. This flag is for use with vertical trackbars.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns a value that represents the tooltip control's previous location. The return value equals one of the possible values
			/// for wParam.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-settipside
			TBM_SETTIPSIDE = WindowMessage.WM_USER + 31,

			/// <summary>
			/// Assigns a window as the buddy window for a trackbar control. Trackbar buddy windows are automatically displayed in a location
			/// relative to the control's orientation (horizontal or vertical).
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Value specifying the location at which to display the buddy window. This value can be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TRUE</c></term>
			/// <term>
			/// The buddy will appear to the left of the trackbar if the trackbar control uses the <c>TBS_HORZ</c> style. If the trackbar
			/// uses the <c>TBS_VERT</c> style, the buddy appears above the trackbar control.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>FALSE</c></term>
			/// <term>
			/// The buddy will appear to the right of the trackbar if the trackbar control uses the <c>TBS_HORZ</c> style. If the trackbar
			/// uses the <c>TBS_VERT</c> style, the buddy appears below the trackbar control.
			/// </term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Handle to the window that will be set as the trackbar control's buddy.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the handle to the window that was previously assigned to the control at that location.</para>
			/// </summary>
			/// <remarks>
			/// <para>Note</para>
			/// <para>
			/// Trackbar controls support up to two buddy windows. This can be useful when you must display text or images at each end of the control.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setbuddy
			TBM_SETBUDDY = WindowMessage.WM_USER + 32,

			/// <summary>
			/// Retrieves the handle to a trackbar control buddy window at a given location. The specified location is relative to the
			/// control's orientation (horizontal or vertical).
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Value indicating which buddy window handle will be retrieved, by relative location. This value can be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c><c>TRUE</c></c></term>
			/// <term>
			/// Retrieves the handle to the buddy to the left of the trackbar. If the trackbar control uses the <c>TBS_VERT</c> style, the
			/// message will retrieve the buddy above the trackbar.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c><c>FALSE</c></c></term>
			/// <term>
			/// Retrieves the handle to the buddy to the right of the trackbar. If the trackbar control uses the <c>TBS_VERT</c> style, the
			/// message will retrieve the buddy below the trackbar.
			/// </term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the handle to the buddy window at the location specified by wParam, or <c>NULL</c> if no buddy window exists at that location.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getbuddy
			TBM_GETBUDDY = WindowMessage.WM_USER + 33,

			/// <summary>Sets the current logical position of the slider in a trackbar.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>wParam is unused.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// New logical position of the slider. Valid logical positions are the integer values in the trackbar's range of minimum to
			/// maximum slider positions. If this value is outside the control's maximum and minimum range, the position is set to the
			/// maximum or minimum value.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// </summary>
			/// <remarks>
			/// Calling <c>TBM_SETPOSNOTIFY</c> will set the trackbar slider location like <c>TBM_SETPOS</c> would, but it will also cause
			/// the trackbar to notify its parent of a move via a <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> message.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setposnotify
			TBM_SETPOSNOTIFY = WindowMessage.WM_USER + 34,

			/// <summary>
			/// Sets the Unicode character format flag for the control. This message allows you to change the character set used by the
			/// control at run time rather than having to re-create the control.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Determines the character set that is used by the control. If this value is nonzero, the control will use Unicode characters.
			/// If this value is zero, the control will use ANSI characters.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous Unicode format flag for the control.</para>
			/// </summary>
			/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-setunicodeformat
			TBM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,

			/// <summary>Retrieves the Unicode character format flag for the control.
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this
			/// value is zero, the control is using ANSI characters.
			/// </para>
			/// </summary>
			/// <remarks>See the remarks for <c>CCM_GETUNICODEFORMAT</c> for a discussion of this message.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/tbm-getunicodeformat
			TBM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT
		}

		/// <summary>Notification messages for trackbar.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760172")]
		public enum TrackBarNotification
		{
			/// <summary>
			/// <para>
			/// Notifies that the thumb position on a trackbar is changing. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TRBN_THUMBPOSCHANGING lpNMTrbThumbPosChanging = (NMTRBTHUMBPOSCHANGING*) lParam;</code>
			/// </para>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>NMTRBTHUMBPOSCHANGING</c> structure. The caller is responsible for allocating this structure and setting its
			/// members, including the members of the contained <c>NMHDR</c> structure.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Return <c>TRUE</c> to prevent the thumb from moving to the specified position.</para>
			/// </summary>
			/// <remarks>Send this notification to clients that do not listen for <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> messages.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/trbn-thumbposchanging
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