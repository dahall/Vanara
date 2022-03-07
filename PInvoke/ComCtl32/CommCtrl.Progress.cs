using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Progress Bar Messages</summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-progress-bar-control-reference-messages
		[PInvokeData("Commctrl.h")]
		public enum ProgressMessage
		{
			/// <summary>Sets the minimum and maximum values for a progress bar and redraws the bar to reflect the new range.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// The <c>LOWORD</c> specifies the minimum range value, and the <c>HIWORD</c> specifies the maximum range value. The minimum
			/// range value must not be negative. By default, the minimum value is zero. The maximum range value must be greater than the
			/// minimum range value. By default, the maximum range value is 100.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the previous range values if successful, or zero otherwise. The <c>LOWORD</c> specifies the previous minimum value,
			/// and the <c>HIWORD</c> specifies the previous maximum value.
			/// </para>
			/// <remarks>
			/// <para>
			/// If you do not set the range values, the system sets the minimum value to 0 and the maximum value to 100. Because this message
			/// expresses the range as a 16-bit unsigned integer, it can extend from 0 to 65,535. The minimum value in the range can be from
			/// 0 to 65,535. Likewise, the maximum value can be from 0 to 65,535.
			/// </para>
			/// <para>To set a larger range, call <c>PBM_SETRANGE32</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setrange
			PBM_SETRANGE = WindowMessage.WM_USER + 1,

			/// <summary>Sets the current position for a progress bar and redraws the bar to reflect the new position.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Signed integer that becomes the new position.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous position.</para>
			/// <remarks>
			/// <para>If wParam is outside the range of the control, the position is set to the closest boundary.</para>
			/// <para>Do not send this message to a control that has the <c>PBS_MARQUEE</c> style.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setpos
			PBM_SETPOS = WindowMessage.WM_USER + 2,

			/// <summary>
			/// Advances the current position of a progress bar by a specified increment and redraws the bar to reflect the new position.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Amount to advance the position.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous position.</para>
			/// <remarks>
			/// <para>If the increment results in a value outside the range of the control, the position is set to the nearest boundary.</para>
			/// <para>The behavior of this message is undefined if it is sent to a control that has the <c>PBS_MARQUEE</c> style.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-deltapos
			PBM_DELTAPOS = WindowMessage.WM_USER + 3,

			/// <summary>
			/// Specifies the step increment for a progress bar. The step increment is the amount by which the progress bar increases its
			/// current position whenever it receives a <c>PBM_STEPIT</c> message. By default, the step increment is set to 10.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>New step increment.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous step increment.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setstep
			PBM_SETSTEP = WindowMessage.WM_USER + 4,

			/// <summary>
			/// Advances the current position for a progress bar by the step increment and redraws the bar to reflect the new position. An
			/// application sets the step increment by sending the <c>PBM_SETSTEP</c> message.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous position.</para>
			/// <remarks>
			/// When the position exceeds the maximum range value, this message resets the current position so that the progress indicator
			/// starts over again from the beginning.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-stepit
			PBM_STEPIT = WindowMessage.WM_USER + 5,

			/// <summary>
			/// Sets the minimum and maximum values for a progress bar to 32-bit values, and redraws the bar to reflect the new range.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Minimum range value. By default, the minimum value is zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Maximum range value. This value must be greater than wParam. By default, the maximum value is 100.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns a <c>DWORD</c> value that holds the previous 16-bit low limit in its <c>LOWORD</c> and the previous 16-bit high limit
			/// in its <c>HIWORD</c>. If the previous ranges were 32-bit values, the return value consists of the <c>LOWORD</c> s of both
			/// 32-bit limits.
			/// </para>
			/// <remarks>To retrieve the entire high and low 32-bit values, use the <c>PBM_GETRANGE</c> message.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setrange32
			PBM_SETRANGE32 = WindowMessage.WM_USER + 6,  // lParam = high, wParam = low

			/// <summary>Retrieves information about the current high and low limits of a given progress bar control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Flag value specifying which limit value is to be used as the message's return value. This parameter can be one of the
			/// following values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c><c>TRUE</c></c></term>
			/// <term>Return the low limit.</term>
			/// </item>
			/// <item>
			/// <term><c><c>FALSE</c></c></term>
			/// <term>Return the high limit.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>PBRANGE</c> structure that is to be filled with the high and low limits of the progress bar control. If this
			/// parameter is set to <c>NULL</c>, the control will return only the limit specified by wParam.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns an INT that represents the limit value specified by wParam. If lParam is not <c>NULL</c>, lParam must point to a
			/// <c>PBRANGE</c> structure that is to be filled with both limit values.
			/// </para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getrange
			PBM_GETRANGE = WindowMessage.WM_USER + 7,  // wParam = return (TRUE ? low : high). lParam = PPBRANGE or NULL

			/// <summary>Retrieves the current position of the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a <c>UINT</c> value that represents the current position of the progress bar.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getpos
			PBM_GETPOS = WindowMessage.WM_USER + 8,

			/// <summary>Sets the color of the progress indicator bar in the progress bar control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// The <c>COLORREF</c> value that specifies the new progress indicator bar color. Specifying the CLR_DEFAULT value causes the
			/// progress bar to use its default progress indicator bar color.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the previous progress indicator bar color, or CLR_DEFAULT if the progress indicator bar color is the default color.
			/// </para>
			/// <remarks>When visual styles are enabled, this message has no effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setbarcolor
			PBM_SETBARCOLOR = WindowMessage.WM_USER + 9,  // lParam = bar color

			/// <summary>Sets the background color in the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// <c>COLORREF</c> value that specifies the new background color. Specify the CLR_DEFAULT value to cause the progress bar to use
			/// its default background color.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous background color, or CLR_DEFAULT if the background color is the default color.</para>
			/// <remarks>When visual styles are enabled, this message has no effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setbkcolor
			PBM_SETBKCOLOR = CommonControlMessage.CCM_SETBKCOLOR,  // lParam = bkColor

			/// <summary>Sets the progress bar to marquee mode. This causes the progress bar to move like a marquee.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Indicates whether to turn the marquee mode on or off.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Time, in milliseconds, between marquee animation updates. If this parameter is zero, the marquee animation is updated every
			/// 30 milliseconds.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Always returns <c>TRUE</c>.</para>
			/// <remarks>
			/// <para>
			/// Use this message when you do not know the amount of progress toward completion but wish to indicate that progress is being made.
			/// </para>
			/// <para>Send the <c>PBM_SETMARQUEE</c> message to start or stop the animation.</para>
			/// <para>
			/// <para>Note</para>
			/// <para>You must set the control style to <c>PBS_MARQUEE</c> before attempting to start the animation.</para>
			/// </para>
			/// <para>
			/// <para>Note</para>
			/// <para>This message requires ComCtl32.dll version 6.00 or later.</para>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setmarquee
			PBM_SETMARQUEE = WindowMessage.WM_USER + 10,

			/// <summary>
			/// Retrieves the step increment from a progress bar. The step increment is the amount by which the progress bar increases its
			/// current position whenever it receives a <c>PBM_STEPIT</c> message. By default, the step increment is set to 10.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the current step increment.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getstep
			PBM_GETSTEP = WindowMessage.WM_USER + 13,

			/// <summary>Gets the background color of the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the background color of the progress bar.</para>
			/// <remarks>
			/// <para>This is the color set by the <c>PBM_SETBKCOLOR</c> message. The default value is CLR_DEFAULT, which is defined in commctrl.h.</para>
			/// <para>This function only affects the classic mode, not any visual style.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getbkcolor
			PBM_GETBKCOLOR = WindowMessage.WM_USER + 14,

			/// <summary>Gets the color of the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the color of the progress bar.</para>
			/// <remarks>
			/// <para>
			/// This is the color set by the <c>PBM_SETBARCOLOR</c> message. The default value is CLR_DEFAULT, which is defined in commctrl.h.
			/// </para>
			/// <para>This function only affects the classic mode, not any visual style.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getbarcolor
			PBM_GETBARCOLOR = WindowMessage.WM_USER + 15,

			/// <summary>Sets the state of the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>State of the progress bar that is being set. One of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>PBST_NORMAL</c></term>
			/// <term>In progress.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_ERROR</c></term>
			/// <term>Error.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_PAUSED</c></term>
			/// <term>Paused.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous state.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-setstate
			PBM_SETSTATE = WindowMessage.WM_USER + 16, // wParam = PBST_[State] (NORMAL, ERROR, PAUSED)

			/// <summary>Gets the state of the progress bar.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the current state of the progress bar. One of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term><c>PBST_NORMAL</c></term>
			/// <term>In progress.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_ERROR</c></term>
			/// <term>Error.</term>
			/// </item>
			/// <item>
			/// <term><c>PBST_PAUSED</c></term>
			/// <term>Paused.</term>
			/// </item>
			/// </list>
			// https://docs.microsoft.com/en-us/windows/win32/controls/pbm-getstate
			PBM_GETSTATE = WindowMessage.WM_USER + 17,
		}

		/// <summary>State of the progress bar used in PBM_SETSTATE and PBM_GETSTATE messages.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760850")]
		public enum ProgressState
		{
			/// <summary>In progress</summary>
			PBST_NORMAL = 0x0001,

			/// <summary>Error.</summary>
			PBST_ERROR = 0x0002,

			/// <summary>Paused.</summary>
			PBST_PAUSED = 0x0003,
		}

		/// <summary>The following control styles are supported by Progress Bar controls:</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760820")]
		[Flags]
		public enum ProgressStyle
		{
			/// <summary>
			/// Version 4.70 or later. The progress bar displays progress status in a smooth scrolling bar instead of the default segmented
			/// bar. <note type="note">This style is supported only in the Windows Classic theme. All other themes override this style.</note>
			/// </summary>
			PBS_SMOOTH = 0x01,

			/// <summary>Version 4.70 or later. The progress bar displays progress status vertically, from bottom to top.</summary>
			PBS_VERTICAL = 0x04,

			/// <summary>
			/// Version 6.0 or later. The progress indicator does not grow in size but instead moves repeatedly along the length of the bar,
			/// indicating activity without specifying what proportion of the progress is complete. <note type="note">Comctl32.dll version 6
			/// is not redistributable but it is included in Windows or later. To use Comctl32.dll version 6, specify it in a manifest. For
			/// more information on manifests, see Enabling Visual Styles.</note>
			/// </summary>
			PBS_MARQUEE = 0x08,

			/// <summary>
			/// Version 6.0 or later and Windows Vista. Determines the animation behavior that the progress bar should use when moving
			/// backward (from a higher value to a lower value). If this is set, then a "smooth" transition will occur, otherwise the control
			/// will "jump" to the lower value.
			/// </summary>
			PBS_SMOOTHREVERSE = 0x10,
		}

		/// <summary>
		/// Contains information about the high and low limits of a progress bar control. This structure is used with the PBM_GETRANGE message.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760822")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PBRANGE
		{
			/// <summary>Low limit for the progress bar control. This is a signed integer.</summary>
			public int iLow;

			/// <summary>High limit for the progress bar control. This is a signed integer.</summary>
			public int iHigh;
		}
	}
}