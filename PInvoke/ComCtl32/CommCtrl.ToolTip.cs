using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary/>
		public const int TTN_FIRST = -520;

		/// <summary>Specify the icon to be displayed.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760414")]
		public enum ToolTipIcon
		{
			/// <summary>No icon.</summary>
			TTI_NONE = 0,

			/// <summary>Info icon.</summary>
			TTI_INFO = 1,

			/// <summary>Warning icon</summary>
			TTI_WARNING = 2,

			/// <summary>Error Icon</summary>
			TTI_ERROR = 3,

			/// <summary>Large error Icon</summary>
			TTI_INFO_LARGE = 4,

			/// <summary>Large error Icon</summary>
			TTI_WARNING_LARGE = 5,

			/// <summary>Large error Icon</summary>
			TTI_ERROR_LARGE = 6,
		}

		/// <summary>Flags that control the tooltip display.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760256")]
		[Flags]
		public enum ToolTipInfoFlags : uint
		{
			/// <summary>Indicates that the uId member is the window handle to the tool. If this flag is not set, uId is the tool's identifier.</summary>
			TTF_IDISHWND = 0x0001,

			/// <summary>Centers the tooltip window below the tool specified by the uId member.</summary>
			TTF_CENTERTIP = 0x0002,

			/// <summary>Indicates that the tooltip text will be displayed in the opposite direction to the text in the parent window.</summary>
			TTF_RTLREADING = 0x0004,

			/// <summary>
			/// Indicates that the tooltip control should subclass the tool's window to intercept messages, such as WM_MOUSEMOVE. If this
			/// flag is not set, you must use the TTM_RELAYEVENT message to forward messages to the tooltip control. For a list of messages
			/// that a tooltip control processes, see TTM_RELAYEVENT.
			/// </summary>
			TTF_SUBCLASS = 0x0010,

			/// <summary>
			/// Positions the tooltip window next to the tool to which it corresponds and moves the window according to coordinates supplied
			/// by the TTM_TRACKPOSITION messages. You must activate this type of tool using the TTM_TRACKACTIVATE message.
			/// </summary>
			TTF_TRACK = 0x0020,

			/// <summary>
			/// Positions the tooltip window at the same coordinates provided by TTM_TRACKPOSITION. This flag must be used with the TTF_TRACK flag.
			/// </summary>
			TTF_ABSOLUTE = 0x0080,

			/// <summary>
			/// Causes the tooltip control to forward mouse event messages to the parent window. This is limited to mouse events that occur
			/// within the bounds of the tooltip window.
			/// </summary>
			TTF_TRANSPARENT = 0x0100,

			/// <summary>
			/// Version 6.0 and later. Indicates that links in the tooltip text should be parsed.
			/// <para>
			/// Note that Comctl32.dll version 6 is not redistributable but it is included in Windows or later. To use Comctl32.dll version
			/// 6, specify it in a manifest. For more information on manifests, see Enabling Visual Styles.
			/// </para>
			/// </summary>
			TTF_PARSELINKS = 0x1000,

			/// <summary>The TTF di setitem</summary>
			TTF_DI_SETITEM = 0x8000, // valid only on the TTN_NEEDTEXT callback
		}

		/// <summary>Tooltip Control Messages</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760542")]
		public enum ToolTipMessage
		{
			/// <summary>Activates or deactivates a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Activation flag. If this parameter is <c>TRUE</c>, the tooltip control is activated. If it is <c>FALSE</c>, the tooltip
			/// control is deactivated.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-activate
			TTM_ACTIVATE = WindowMessage.WM_USER + 1,

			/// <summary>Sets the initial, pop-up, and reshow durations for a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Flag that specifies which time value to set. This parameter can be one of the following values</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TTDT_AUTOPOP</c></term>
			/// <term>
			/// Set the amount of time a tooltip window remains visible if the pointer is stationary within a tool's bounding rectangle. To
			/// return the autopop delay time to its default value, set <c>lParam</c> to -1.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>TTDT_INITIAL</c></term>
			/// <term>
			/// Set the amount of time a pointer must remain stationary within a tool's bounding rectangle before the tooltip window appears.
			/// To return the initial delay time to its default value, set <c>lParam</c> to -1.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>TTDT_RESHOW</c></term>
			/// <term>
			/// Set the amount of time it takes for subsequent tooltip windows to appear as the pointer moves from one tool to another. To
			/// return the reshow delay time to its default value, set <c>lParam</c> to -1.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>TTDT_AUTOMATIC</c></term>
			/// <term>
			/// Set all three delay times to default proportions. The autopop time will be ten times the initial time and the reshow time
			/// will be one fifth the initial time. If this flag is set, use a positive value of <c>lParam</c> to specify the initial time,
			/// in milliseconds. Set <c>lParam</c> to a negative value to return all three delay times to their default values.
			/// </term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>The <c>LOWORD</c> specifies the delay time, in milliseconds. The <c>HIWORD</c> must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>
			/// <para>
			/// The default delay times are based on the double-click time. For the default double-click time of 500 ms, the initial,
			/// autopop, and reshow delay times are 500ms, 5000ms, and 100ms respectively. The following code fragment uses the
			/// <c>GetDoubleClickTime</c> function to determine the three delay times for any system.
			/// </para>
			/// <para>
			/// <code>initial = GetDoubleClickTime(); autopop = GetDoubleClickTime() * 10; reshow = GetDoubleClickTime() / 5;</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-setdelaytime
			TTM_SETDELAYTIME = WindowMessage.WM_USER + 3,

			/// <summary>Registers a tool with a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure containing information that the tooltip control needs to display text for the tool.
			/// The <c>cbSize</c> member of this structure must be filled in before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-addtool
			TTM_ADDTOOL = WindowMessage.WM_USER + 50,

			/// <summary>Removes a tool from a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure. The <c>hwnd</c> and <c>uId</c> members identify the tool to remove, and the
			/// <c>cbSize</c> member must specify the size of the structure. All other members are ignored.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-deltool
			TTM_DELTOOL = WindowMessage.WM_USER + 51,

			/// <summary>Sets a new bounding rectangle for a tool.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure. The <c>hwnd</c> and <c>uId</c> members identify a tool, and the <c>rect</c> member
			/// specifies the new bounding rectangle. The <c>cbSize</c> member of this structure must be filled in before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-newtoolrect
			TTM_NEWTOOLRECT = WindowMessage.WM_USER + 52,

			/// <summary>Passes a mouse message to a tooltip control for processing.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Must be zero. <c>Windows 7 and later:</c> If the position of the tooltip is offset from the cursor position (in order not be
			/// obstructed by a finger or pointing device), this parameter can contain extra information taken from the <c>WM_MOUSEMOVE</c>
			/// message. Retrieve this extra information with <c>GetMessageExtraInfo</c>.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to an <c>MSG</c> structure that contains the message to relay.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// <remarks>
			/// <para>A tooltip control processes only the following messages passed to it by the <c>TTM_RELAYEVENT</c> message:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>WM_LBUTTONDOWN</term>
			/// </item>
			/// <item>
			/// <term>WM_LBUTTONUP</term>
			/// </item>
			/// <item>
			/// <term>WM_MBUTTONDOWN</term>
			/// </item>
			/// <item>
			/// <term>WM_MBUTTONUP</term>
			/// </item>
			/// <item>
			/// <term>WM_MOUSEMOVE</term>
			/// </item>
			/// <item>
			/// <term>WM_NCMOUSEMOVE</term>
			/// </item>
			/// <item>
			/// <term>WM_RBUTTONDOWN</term>
			/// </item>
			/// <item>
			/// <term>WM_RBUTTONUP</term>
			/// </item>
			/// </list>
			/// <para>All other messages are ignored.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-relayevent
			TTM_RELAYEVENT = WindowMessage.WM_USER + 7, // Win7: wParam = GetMessageExtraInfo() when relaying WM_MOUSEMOVE

			/// <summary>Retrieves the information that a tooltip control maintains about a tool.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure. When sending the message, the <c>hwnd</c> and <c>uId</c> members identify a tool, and
			/// the <c>cbSize</c> member must specify the size of the structure. When using this message to retrieve the tooltip text, ensure
			/// that the <c>lpszText</c> member of the <c>TOOLINFO</c> structure points to a valid buffer of adquate size
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
			/// <remarks>If the tooltip control includes the tool, the <c>TOOLINFO</c> structure receives information about the tool.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettoolinfo
			TTM_GETTOOLINFO = WindowMessage.WM_USER + 53,

			/// <summary>Sets the information that a tooltip control maintains for a tool.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure that specifies the information to set. The <c>cbSize</c> member of this structure must
			/// be set before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			/// <remarks>
			/// <para>
			/// Some internal properties of a tool are established when the tool is created, and are not recomputed when a
			/// <c>TTM_SETTOOLINFO</c> message is sent. If you simply assign values to a <c>TOOLINFO</c> structure and pass it to the tooltip
			/// control with a <c>TTM_SETTOOLINFO</c> message, these properties may be lost. Instead, your application should first request
			/// the tool's current <c>TOOLINFO</c> structure by sending the tooltip control a <c>TTM_GETTOOLINFO</c> message. Then, modify
			/// the members of this structure as needed and pass it back to the tooltip control with <c>TTM_SETTOOLINFO</c>.
			/// </para>
			/// <para>
			/// When calling <c>TTM_SETTOOLINFO</c>, the string pointed to by the <c>lpszText</c> member of the <c>TOOLINFO</c> structure
			/// must not exceed 80 <c>TCHARs</c> in length, including the terminating <c>NULL</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-settoolinfo
			TTM_SETTOOLINFO = WindowMessage.WM_USER + 54,

			/// <summary>
			/// Tests a point to determine whether it is within the bounding rectangle of the specified tool and, if it is, retrieves
			/// information about the tool.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TTHITTESTINFO</c> structure. When sending the message, the <c>hwnd</c> member must specify the handle to a
			/// tool and the <c>pt</c> member must specify the coordinates of a point. If the return value is <c>TRUE</c>, the <c>ti</c>
			/// member (a <c>TOOLINFO</c> structure) receives information about the tool that occupies the point. The <c>cbSize</c> member of
			/// the <c>ti</c> structure must be filled in before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if the tool occupies the specified point, or <c>FALSE</c> otherwise.</para>
			/// <remarks>
			/// This message must be sent when the tool has the TTF_TRACK flag set. For more information on this flag, see <c>TOOLINFO</c>.
			/// TTM_HITTEST will fail if TTF_TRACK is not set, regardless if the hit point is in the tools rectangle or not.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-hittest
			TTM_HITTEST = WindowMessage.WM_USER + 55,

			/// <summary>Retrieves the information a tooltip control maintains about a tool.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>The number of **TCHARs**, including the terminating **NULL**, to copy to the buffer pointed to by **lpszText**.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a <c>TOOLINFO</c> structure. Set the <c>cbSize</c> member of this structure to
			/// <code>sizeof(TOOLINFO)</code>
			/// before sending this message. Set the <c>hwnd</c> and <c>uId</c> members to identify the tool for which to retrieve
			/// information. Allocate a buffer of size specified by wParam. Set the <c>lpszText</c> member to point to the buffer to receive
			/// the tool text.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettext
			TTM_GETTEXT = WindowMessage.WM_USER + 56,

			/// <summary>Sets the tooltip text for a tool.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure. The <c>hinst</c> and <c>lpszText</c> members must specify the instance handle and the
			/// address of the text. The <c>hwnd</c> and <c>uId</c> members identify the tool to update. The <c>cbSize</c> member of this
			/// structure must be filled in before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-updatetiptext
			TTM_UPDATETIPTEXT = WindowMessage.WM_USER + 57,

			/// <summary>Retrieves a count of the tools maintained by a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a count of tools.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettoolcount
			TTM_GETTOOLCOUNT = WindowMessage.WM_USER + 13,

			/// <summary>
			/// Retrieves the information that a tooltip control maintains about the current tool that is, the tool for which the tooltip is
			/// currently displaying text.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Zero-based index of the tool for which to retrieve information.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure that receives information about the tool. Set the <c>cbSize</c> member of this
			/// structure to sizeof(TOOLINFO) before sending this message. Allocate a buffer. Set the <c>lpszText</c> member to point to the
			/// buffer to receive the tool text. There is no way to determine the required buffer size. However, tool text, as returned at
			/// the <c>lpszText</c> member of the <c>TOOLINFO</c> structure, has a maximum length of 80 <c>TCHARs</c>, including the
			/// terminating <c>NULL</c>. If the text exceeds this length, it is truncated.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>FALSE</c> whether or not a tool was enumerated.</para>
			/// <remarks>
			/// <c>Security Warning:</c> Using this message might compromise the security of your program. This message does not provide a
			/// way for the message receiver to know the size of the buffer or to specify the size of the buffer. You should review the
			/// Security Considerations: Microsoft Windows Controls before continuing.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-enumtools
			TTM_ENUMTOOLS = WindowMessage.WM_USER + 58,

			/// <summary>Retrieves the information for the current tool in a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure that receives information about the current tool. If this value is <c>NULL</c>, the
			/// return value indicates the existence of the current tool without actually retrieving the tool information. If this value is
			/// not <c>NULL</c>, the <c>cbSize</c> member of the <c>TOOLINFO</c> structure must be filled in before sending this message.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns nonzero if successful, or zero otherwise. If lParam is <c>NULL</c>, returns nonzero if a current tool exists, or zero otherwise.
			/// </para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-getcurrenttool
			TTM_GETCURRENTTOOL = WindowMessage.WM_USER + 59,

			/// <summary>
			/// Allows a subclass procedure to cause a tooltip to display text for a window other than the one beneath the mouse cursor.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a <c>POINT</c> structure that defines the point to be checked.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// The return value is the handle to the window that contains the point, or <c>NULL</c> if no window exists at the specified point.
			/// </para>
			/// <remarks>
			/// This message is intended to be processed by an application that subclasses a tooltip. It is not intended to be sent by an
			/// application. A tooltip sends this message to itself before displaying the text for a window. By changing the coordinates of
			/// the point specified by lParam, the subclass procedure can cause the tooltip to display text for a window other than the one
			/// beneath the mouse cursor.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-windowfrompoint
			TTM_WINDOWFROMPOINT = WindowMessage.WM_USER + 16,

			/// <summary>Activates or deactivates a tracking tooltip.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Value specifying whether tracking is being activated or deactivated. This value can be one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TRUE</c></term>
			/// <term>Activate tracking.</term>
			/// </item>
			/// <item>
			/// <term><c>FALSE</c></term>
			/// <term>Deactivate tracking.</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>TOOLINFO</c> structure that identifies the tool to which this message applies. The <c>hwnd</c> and <c>uId</c>
			/// members identify the tool, and the <c>cbSize</c> member specifies the size of the structure. All other members are ignored.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-trackactivate
			TTM_TRACKACTIVATE = WindowMessage.WM_USER + 17, // wParam = TRUE/FALSE start end  lparam = LPTOOLINFO

			/// <summary>Sets the position of a tracking tooltip.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// The <c>LOWORD</c> specifies the x-coordinate of the point at which the tracking tooltip will be displayed, in screen
			/// coordinates. The <c>HIWORD</c> specifies the y-coordinate of the point at which the tracking tooltip will be displayed, in
			/// screen coordinates.
			/// </para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>
			/// The tooltip control chooses where to display the tooltip window based on the coordinates you provide with this message. This
			/// causes the tooltip window to appear beside the tool to which it corresponds. To have tooltip windows displayed at specific
			/// coordinates, include the TTF_ABSOLUTE flag in the <c>uFlags</c> member of the <c>TOOLINFO</c> structure when adding the tool.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-trackposition
			TTM_TRACKPOSITION = WindowMessage.WM_USER + 18, // lParam = dwPos

			/// <summary>Sets the background color in a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>New background color.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>When visual styles are enabled, this message has no effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-settipbkcolor
			TTM_SETTIPBKCOLOR = WindowMessage.WM_USER + 19,

			/// <summary>Sets the text color in a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>New text color.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>When visual styles are enabled, this message has no effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-settiptextcolor
			TTM_SETTIPTEXTCOLOR = WindowMessage.WM_USER + 20,

			/// <summary>Retrieves the initial, pop-up, and reshow durations currently set for a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Flag that specifies which duration value will be retrieved. This parameter can have one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TTDT_AUTOPOP</c></term>
			/// <term>
			/// Retrieve the amount of time the tooltip window remains visible if the pointer is stationary within a tool's bounding rectangle.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>TTDT_INITIAL</c></term>
			/// <term>
			/// Retrieve the amount of time the pointer must remain stationary within a tool's bounding rectangle before the tooltip window appears.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>TTDT_RESHOW</c></term>
			/// <term>
			/// Retrieve the amount of time it takes for subsequent tooltip windows to appear as the pointer moves from one tool to another.
			/// </term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns and INT value with the specified duration in milliseconds.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-getdelaytime
			TTM_GETDELAYTIME = WindowMessage.WM_USER + 21,

			/// <summary>Retrieves the background color in a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a <c>COLORREF</c> value that represents the background color.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettipbkcolor
			TTM_GETTIPBKCOLOR = WindowMessage.WM_USER + 22,

			/// <summary>Retrieves the text color in a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a <c>COLORREF</c> value that represents the text color.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettiptextcolor
			TTM_GETTIPTEXTCOLOR = WindowMessage.WM_USER + 23,

			/// <summary>Sets the maximum width for a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Maximum tooltip window width, or -1 to allow any width.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns the previous maximum tooltip width.</para>
			/// <remarks>
			/// The maximum width value does not indicate a tooltip window's actual width. Rather, if a tooltip string exceeds the maximum
			/// width, the control breaks the text into multiple lines, using spaces to determine line breaks. If the text cannot be
			/// segmented into multiple lines, it is displayed on a single line, which may exceed the maximum tooltip width.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-setmaxtipwidth
			TTM_SETMAXTIPWIDTH = WindowMessage.WM_USER + 24,

			/// <summary>Retrieves the maximum width for a tooltip window.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns an <c>INT</c> value that represents the maximum tooltip width, in pixels. If no maximum width was set previously, the
			/// message returns -1.
			/// </para>
			/// <remarks>
			/// The maximum tooltip width value does not indicate a tooltip window's actual width. Rather, if a tooltip string exceeds the
			/// maximum width, the control breaks the text into multiple lines, using spaces to determine line breaks. If the text cannot be
			/// segmented into multiple lines, it will be displayed on a single line. The length of this line may exceed the maximum tooltip width.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-getmaxtipwidth
			TTM_GETMAXTIPWIDTH = WindowMessage.WM_USER + 25,

			/// <summary>
			/// Sets the top, left, bottom, and right margins for a tooltip window. A margin is the distance, in pixels, between the tooltip
			/// window border and the text contained within the tooltip window.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>RECT</c> structure that contains the margin information to be set. The members of the <c>RECT</c> structure
			/// do not define a bounding rectangle. For the purpose of this message, the structure members are interpreted as follows:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>top</c></term>
			/// <term>Distance between top border and top of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>left</c></term>
			/// <term>Distance between left border and left end of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>bottom</c></term>
			/// <term>Distance between bottom border and bottom of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>right</c></term>
			/// <term>Distance between right border and right end of tooltip text, in pixels.</term>
			/// </item>
			/// </list>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>
			/// This message has no effect when the application runs on Windows Vista and visual styles are enabled for the tooltip. You can
			/// disable visual styles for the tooltip by using <c>SetWindowTheme</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-setmargin
			TTM_SETMARGIN = WindowMessage.WM_USER + 26, // lParam = lprc

			/// <summary>
			/// Retrieves the top, left, bottom, and right margins set for a tooltip window. A margin is the distance, in pixels, between the
			/// tooltip window border and the text contained within the tooltip window.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>
			/// Pointer to a <c>RECT</c> structure that will receive the margin information. The members of the <c>RECT</c> structure do not
			/// define a bounding rectangle. For the purpose of this message, the structure members are interpreted as follows:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>top</c></term>
			/// <term>Distance between top border and top of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>left</c></term>
			/// <term>Distance between left border and left end of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>bottom</c></term>
			/// <term>Distance between bottom border and bottom of tooltip text, in pixels.</term>
			/// </item>
			/// <item>
			/// <term><c>right</c></term>
			/// <term>Distance between right border and right end of tooltip text, in pixels.</term>
			/// </item>
			/// </list>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			/// <remarks>All four margins default to zero when you create the tooltip control.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-getmargin
			TTM_GETMARGIN = WindowMessage.WM_USER + 27, // lParam = lprc

			/// <summary>Removes a displayed tooltip window from view.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-pop
			TTM_POP = WindowMessage.WM_USER + 28,

			/// <summary>Forces the current tooltip to be redrawn.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this message is not used.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-update
			TTM_UPDATE = WindowMessage.WM_USER + 29,

			/// <summary>Returns the width and height of a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to the tooltip <c>TOOLINFO</c> structure.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Returns the width of the tooltip in the low word and the height in the high word if successful. Otherwise, it returns <c>FALSE</c>.
			/// </para>
			/// <remarks>
			/// If the TTF_TRACK and TTF_ABSOLUTE flags are set in the <c>uFlags</c> member of the tooltip <c>TOOLINFO</c> structure, this
			/// message can be used to help position the tooltip accurately.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-getbubblesize
			TTM_GETBUBBLESIZE = WindowMessage.WM_USER + 30,

			/// <summary>
			/// Calculates a tooltip control's text display rectangle from its window rectangle, or the tooltip window rectangle needed to
			/// display a specified text display rectangle.
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Value that specifies which operation to perform. If <c>TRUE</c>, lParam is used to specify a text-display rectangle and it
			/// receives the corresponding window rectangle. If <c>FALSE</c>, lParam is used to specify a window rectangle and it receives
			/// the corresponding text display rectangle.
			/// </para>
			/// <para><em>lParam</em></para>
			/// <para><c>RECT</c> structure to hold either a tooltip window rectangle or a text display rectangle.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns a nonzero value if the rectangle is successfully adjusted, and returns zero if an error occurs.</para>
			/// <remarks>
			/// <para>
			/// This message is particularly useful when you want to use a tooltip control to display the full text of a string that is
			/// usually truncated. It is commonly used with listview and treeview controls. You typically send this message in response to a
			/// TTN_SHOW notification code so that you can position the tooltip control properly.
			/// </para>
			/// <para>
			/// The tooltip window rectangle is somewhat larger than the text display rectangle that bounds the tooltip string. The window
			/// origin is also offset up and to the left from the origin of the text display rectangle. To position the text display
			/// rectangle, you must calculate the corresponding window rectangle and use that rectangle to position the tooltip.
			/// <c>TTM_ADJUSTRECT</c> handles this calculation for you.
			/// </para>
			/// <para>
			/// If you set wParam to <c>TRUE</c>, <c>TTM_ADJUSTRECT</c> takes the size and position of the desired tooltip text display
			/// rectangle, and passes back the size and position of the tooltip window needed to display the text in the specified position.
			/// If you set wParam to <c>FALSE</c>, you can specify a tooltip window rectangle and <c>TTM_ADJUSTRECT</c> will return the size
			/// and position of its text rectangle.
			/// </para>
			/// <para>
			/// The following code fragment illustrates the use of the <c>TTM_ADJUSTRECT</c> message to position a tooltip control to display
			/// the full text of a control's string in place of a truncated string. The application-defined <c>GetMyItemRect</c> function
			/// returns the text rectangle that will be needed to display the tooltip text directly over the truncated string. The details of
			/// how this function is implemented will depend on the particular control. <c>TTM_ADJUSTRECT</c> is used to send this text
			/// rectangle to the tooltip control. It returns an appropriately sized and positioned window rectangle that is then used to
			/// position the tooltip window.
			/// </para>
			/// <para>
			/// <code>case TTN_SHOW: if (MyStringIsTruncated) { RECT rc; GetMyItemRect(&amp;rc); SendMessage(hwndToolTip, TTM_ADJUSTRECT, TRUE, (LPARAM)&amp;rc); SetWindowPos(hwndToolTip, NULL, rc.left, rc.top, 0, 0, SWP_NOSIZE|SWP_NOZORDER|SWP_NOACTIVATE); }</code>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-adjustrect
			TTM_ADJUSTRECT = WindowMessage.WM_USER + 31,

			/// <summary>Adds a standard icon and title string to a tooltip.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>
			/// Set wParam to one of the following values to specify the icon to be displayed. As of Windows XP SP2 and later, this parameter
			/// can also contain an <c>HICON</c> value. Any value greater than TTI_ERROR is assumed to be an <c>HICON</c>.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>TTI_NONE</c></term>
			/// <term>No icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_INFO</c></term>
			/// <term>Info icon.</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_WARNING</c></term>
			/// <term>Warning icon</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_ERROR</c></term>
			/// <term>Error Icon</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_INFO_LARGE</c></term>
			/// <term>Large error Icon</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_WARNING_LARGE</c></term>
			/// <term>Large error Icon</term>
			/// </item>
			/// <item>
			/// <term><c>TTI_ERROR_LARGE</c></term>
			/// <term>Large error Icon</term>
			/// </item>
			/// </list>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to the title string. You must assign a value to lParam.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>Returns <c>TRUE</c> if successful, <c>FALSE</c> if not.</para>
			/// <remarks>
			/// <para>
			/// The title of a tooltip appears above the text, in a different font. It is not sufficient to have a title; the tooltip must
			/// have text as well, or it is not displayed.
			/// </para>
			/// <para>When wParam contains an <c>HICON</c>, a copy of the icon is created by the tooltip window.</para>
			/// <para>
			/// When calling <c>TTM_SETTITLE</c>, the string pointed to by lParam must not exceed 100 <c>TCHARs</c> in length, including the
			/// terminating <c>NULL</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-settitle
			TTM_SETTITLE = WindowMessage.WM_USER + 33, // wParam = TTI_*, lParam = wchar* szTitle

			/// <summary>Causes the tooltip to display at the coordinates of the last mouse message.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is not used.</para>
			/// <remarks>
			/// <para>Note</para>
			/// <para>
			/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
			/// Enabling Visual Styles.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-popup
			TTM_POPUP = WindowMessage.WM_USER + 34,

			/// <summary>Retrieve information concerning the title of a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a <c>TTGETTITLE</c> structure that contains information about a tooltip title.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is not used.</para>
			/// <remarks>
			/// <para>Note</para>
			/// <para>
			/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
			/// Enabling Visual Styles.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-gettitle
			TTM_GETTITLE = WindowMessage.WM_USER + 35, // wParam = 0, lParam = TTGETTITLE*

			/// <summary>Sets the visual style of a tooltip control.</summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>wParam</em></para>
			/// <para>Must be zero.</para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to a Unicode string that contains the tooltip visual style to set.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value is not used.</para>
			/// <remarks>
			/// <para>Note</para>
			/// <para>
			/// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see
			/// Enabling Visual Styles.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttm-setwindowtheme
			TTM_SETWINDOWTHEME = CommonControlMessage.CCM_SETWINDOWTHEME
		}

		/// <summary>Tooltip Control Notifications</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "ff486070")]
		public enum ToolTipNotification
		{
			/// <summary>
			/// <para>
			/// Sent by a tooltip control to retrieve information needed to display a tooltip window. This notification code is sent in the
			/// form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TTN_GETDISPINFO lpnmtdi = (LPNMTTDISPINFO) lParam;</code>
			/// </para>
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to an <c>NMTTDISPINFO</c> structure that identifies the tool that needs text and receives the requested information.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this notification is not used.</para>
			/// <remarks>
			/// Fill the structure's appropriate members to return the requested information to the tooltip control. If your message handler
			/// sets the <c>uFlags</c> member of the <c>NMTTDISPINFO</c> structure to TTF_DI_SETITEM, the tooltip control stores the
			/// information and will not request it again.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttn-getdispinfo
			TTN_GETDISPINFO = TTN_FIRST - 10,

			/// <summary>
			/// <para>
			/// Notifies the owner window that a tooltip control is about to be displayed. This notification code is sent in the form of a
			/// <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TTN_SHOW pnmh = (LPNMHDR) lParam;</code>
			/// </para>
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to an <c>NMHDR</c> structure.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>
			/// Version 4.70. To display the tooltip in its default location, return zero. To customize the tooltip position, reposition the
			/// tooltip window with the <c>SetWindowPos</c> function and return <c>TRUE</c>.
			/// </para>
			/// <para>
			/// <para>Note</para>
			/// <para>For versions earlier than 4.70, there is no return value.</para>
			/// </para>
			/// <remarks>
			/// A tooltip window rectangle is somewhat larger than its text display rectangle, and its origin is offset up and to the left.
			/// If you need to accurately position the text display rectangle of a tooltip, the <c>TTM_ADJUSTRECT</c> message converts a text
			/// display rectangle into the corresponding tooltip window rectangle and vice versa.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttn-show
			TTN_SHOW = TTN_FIRST - 1,

			/// <summary>
			/// <para>
			/// Notifies the owner window that a tooltip is about to be hidden. This notification code is sent in the form of a
			/// <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TTN_POP pnmh = (LPNMHDR) lParam;</code>
			/// </para>
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to an <c>NMHDR</c> structure.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>No return value.</para>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttn-pop
			TTN_POP = TTN_FIRST - 2,

			/// <summary>
			/// <para>
			/// Sent when a text link inside a balloon tooltip is clicked. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TTN_LINKCLICK</code>
			/// </para>
			/// </summary>
			/// <para><strong>Returns</strong></para>
			/// <para>Return value not used.</para>
			/// <remarks>
			/// <para>
			/// Following is an example of when this notification is sent. Assume that your balloon tooltip contains the following text,
			/// "This is a link". When "link" is clicked, the tooltip control sends a TTN_LINKCLICK notification code.
			/// </para>
			/// <para>
			/// <para>Note</para>
			/// <para>
			/// To use this notification code, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on
			/// manifests, see Enabling Visual Styles.
			/// </para>
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttn-linkclick
			TTN_LINKCLICK = TTN_FIRST - 3,

			/// <summary>
			/// <para>
			/// Sent by a tooltip control to retrieve information needed to display a tooltip window. This notification code is identical to
			/// TTN_GETDISPINFO. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.
			/// </para>
			/// <para>
			/// <code>TTN_NEEDTEXT lpnmtdi = (LPNMTTDISPINFO) lParam;</code>
			/// </para>
			/// </summary>
			/// <para><strong>Parameters</strong></para>
			/// <para><em>lParam</em></para>
			/// <para>Pointer to an <c>NMTTDISPINFO</c> structure that identifies the tool that needs text and receives the requested information.</para>
			/// <para><strong>Returns</strong></para>
			/// <para>The return value for this notification is not used.</para>
			/// <remarks>
			/// Fill the structure's appropriate members to return the requested information to the tooltip control. If your message handler
			/// sets the <c>uFlags</c> member of the <c>NMTTDISPINFO</c> structure to TTF_DI_SETITEM, the tooltip control stores the
			/// information and will not request it again.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/controls/ttn-needtext
			TTN_NEEDTEXT = TTN_GETDISPINFO,
		}

		/// <summary>
		/// Contains information used in handling the TTN_GETDISPINFO notification code. This structure supersedes the TOOLTIPTEXT structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760258")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NMTTDISPINFO
		{
			/// <summary>NMHDR structure that contains additional information about the notification.</summary>
			public NMHDR hdr;

			/// <summary>
			/// Pointer to a null-terminated string that will be displayed as the tooltip text. If hinst specifies an instance handle, this
			/// member must be the identifier of a string resource.
			/// </summary>
			public string lpszText;

			/// <summary>
			/// Buffer that receives the tooltip text. An application can copy the text to this buffer instead of specifying a string address
			/// or string resource. For tooltip text that exceeds 80 TCHARs, see comments in the remarks section of this document.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr, SizeConst = 80)]
			public string szText;

			/// <summary>
			/// Handle to the instance that contains a string resource to be used as the tooltip text. If lpszText is the address of the
			/// tooltip text string, this member must be NULL.
			/// </summary>
			public HINSTANCE hinst;

			/// <summary>
			/// Flags that indicates how to interpret the idFrom member of the included NMHDR structure.
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TTF_IDISHWND</term>
			/// <description>If this flag is set, idFrom is the tool's handle. Otherwise, it is the tool's identifier.</description>
			/// </item>
			/// <item>
			/// <term>TTF_RTLREADING</term>
			/// <description>
			/// Windows can be mirrored to display languages such as Hebrew or Arabic that read right-to-left (RTL). Normally, tooltip text
			/// is read in same direction as the text in its parent window. To have a tooltip read in the opposite direction from its parent
			/// window, add the TTF_RTLREADING flag to the uFlags member when processing the notification.
			/// </description>
			/// </item>
			/// <item>
			/// <term>TTF_DI_SETITEM</term>
			/// <description>
			/// Version 4.70. If you add this flag to uFlags while processing the notification, the tooltip control will retain the supplied
			/// information and not request it again.
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			public ToolTipInfoFlags uFlags;

			/// <summary>Version 4.70. Application-defined data associated with the tool.</summary>
			public IntPtr lParam;
		}

		/// <summary>The TOOLINFO structure contains information about a tool in a tooltip control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760256")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TOOLINFO
		{
			/// <summary>Size of this structure, in bytes. This member must be specified.</summary>
			public uint cbSize;

			/// <summary>Flags that control the tooltip display. This member can be a combination of the following values:</summary>
			public ToolTipInfoFlags uFlags;

			/// <summary>
			/// Handle to the window that contains the tool. If lpszText includes the LPSTR_TEXTCALLBACK value, this member identifies the
			/// window that receives the TTN_GETDISPINFO notification codes.
			/// </summary>
			public HWND hwnd;

			/// <summary>
			/// Application-defined identifier of the tool. If uFlags includes the TTF_IDISHWND flag, uId must specify the window handle to
			/// the tool.
			/// </summary>
			public IntPtr uId;

			/// <summary>
			/// The bounding rectangle coordinates of the tool. The coordinates are relative to the upper-left corner of the client area of
			/// the window identified by hwnd. If uFlags includes the TTF_IDISHWND flag, this member is ignored.
			/// </summary>
			public RECT rect;

			/// <summary>
			/// Handle to the instance that contains the string resource for the tool. If lpszText specifies the identifier of a string
			/// resource, this member is used.
			/// </summary>
			public HINSTANCE hinst;

			/// <summary>
			/// Pointer to the buffer that contains the text for the tool, or identifier of the string resource that contains the text. This
			/// member is sometimes used to return values. If you need to examine the returned value, must point to a valid buffer of
			/// sufficient size. Otherwise, it can be set to NULL. If lpszText is set to LPSTR_TEXTCALLBACK, the control sends the
			/// TTN_GETDISPINFO notification code to the owner window to retrieve the text.
			/// </summary>
			public StrPtrAuto lpszText;

			/// <summary>Version 4.70 and later. A 32-bit application-defined value that is associated with the tool.</summary>
			public IntPtr lParam;

			/// <summary>Reserved. Must be set to NULL.</summary>
			public IntPtr lpReserved;
		}

		/// <summary>Provides information about the title of a tooltip control.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760260")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TTGETTITLE
		{
			/// <summary>DWORD that specifies size of structure. Set to sizeof(TTGETTITLE).</summary>
			public uint dwSize;

			/// <summary>UINT that specifies the tooltip icon.</summary>
			public ToolTipIcon uTitleBitmap;

			/// <summary>UINT that specifies the number of characters in the title.</summary>
			public uint cch;

			/// <summary>Pointer to a wide character string that contains the title.</summary>
			public StrPtrUni pszTitle;
		}

		/// <summary>
		/// Contains information that a tooltip control uses to determine whether a point is in the bounding rectangle of the specified tool.
		/// If the point is in the rectangle, the structure receives information about the tool.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760262")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TTHITTESTINFO
		{
			/// <summary>Handle to the tool or window with the specified tool.</summary>
			public HWND hwnd;

			/// <summary>Client coordinates of the point to test.</summary>
			public POINT pt;

			/// <summary>
			/// TOOLINFO structure. If the point specified by pt is in the tool specified by hwnd, this structure receives information about
			/// the tool. The cbSize member of this structure must be filled in before sending this message.
			/// </summary>
			public TOOLINFO ti;
		}
	}
}