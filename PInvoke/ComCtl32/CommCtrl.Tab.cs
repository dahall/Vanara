using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.Extensions;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public const int TCM_FIRST = 0x1300;
		public const int TCN_FIRST = -550;

		/// <summary>Variable that receives the results of a hit test.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
		[Flags]
		public enum TabControlHitTestFlags
		{
			/// <summary>The position is not over a tab.</summary>
			TCHT_NOWHERE = 0x0001,
			/// <summary>The position is over a tab's icon.</summary>
			TCHT_ONITEMICON = 0x0002,
			/// <summary>The position is over a tab's text.</summary>
			TCHT_ONITEMLABEL = 0x0004,
			/// <summary>The position is over a tab but not over its icon or its text. For owner-drawn tab controls, this value is specified if the position is anywhere over a tab.</summary>
			TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL,
		}

		/// <summary>Value that specifies which members of TCITEM to retrieve or set.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760554")]
		[Flags]
		public enum TabControlItemMask
		{
			/// <summary>The pszText member is valid.</summary>
			TCIF_TEXT = 0x0001,
			/// <summary>The iImage member is valid.</summary>
			TCIF_IMAGE = 0x0002,
			/// <summary>The string pointed to by pszText will be displayed in the direction opposite to the text in the parent window.</summary>
			TCIF_RTLREADING = 0x0004,
			/// <summary>The lParam member is valid.</summary>
			TCIF_PARAM = 0x0008,
			/// <summary>Version 4.70. The dwState member is valid.</summary>
			TCIF_STATE = 0x0010,
			/// <summary>All members are valid.</summary>
			TCIF_ALL = 0x001B,
		}

		/// <summary>
		/// Tab control items now support an item state to support the TCM_DESELECTALL message. Additionally, the TCITEM structure supports item state values.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760547")]
		[Flags]
		public enum TabControlItemStates
		{
			/// <summary>Version 4.70. The tab control item is selected. This state is only meaningful if the TCS_BUTTONS style flag has been set.</summary>
			TCIS_BUTTONPRESSED = 0x0001,
			/// <summary>Version 4.71. The tab control item is highlighted, and the tab and text are drawn using the current highlight color. When using high-color, this will be a true interpolation, not a dithered color.</summary>
			TCIS_HIGHLIGHTED = 0x0002,
			/// <summary>Look at all states.</summary>
			TCIS_ALL
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
		public enum TabControlMessage
		{
			TCM_GETIMAGELIST = TCM_FIRST + 2,
			TCM_SETIMAGELIST = TCM_FIRST + 3,
			TCM_GETITEMCOUNT = TCM_FIRST + 4,
			TCM_GETITEM = TCM_FIRST + 60,
			TCM_SETITEM = TCM_FIRST + 61,
			TCM_INSERTITEM = TCM_FIRST + 62,
			TCM_DELETEITEM = TCM_FIRST + 8,
			TCM_DELETEALLITEMS = TCM_FIRST + 9,
			TCM_GETITEMRECT = TCM_FIRST + 10,
			TCM_GETCURSEL = TCM_FIRST + 11,
			TCM_SETCURSEL = TCM_FIRST + 12,
			TCM_HITTEST = TCM_FIRST + 13,
			TCM_SETITEMEXTRA = TCM_FIRST + 14,
			TCM_ADJUSTRECT = TCM_FIRST + 40,
			TCM_SETITEMSIZE = TCM_FIRST + 41,
			TCM_REMOVEIMAGE = TCM_FIRST + 42,
			TCM_SETPADDING = TCM_FIRST + 43,
			TCM_GETROWCOUNT = TCM_FIRST + 44,
			TCM_GETTOOLTIPS = TCM_FIRST + 45,
			TCM_SETTOOLTIPS = TCM_FIRST + 46,
			TCM_GETCURFOCUS = TCM_FIRST + 47,
			TCM_SETCURFOCUS = TCM_FIRST + 48,
			TCM_SETMINTABWIDTH = TCM_FIRST + 49,
			TCM_DESELECTALL = TCM_FIRST + 50,
			TCM_HIGHLIGHTITEM = TCM_FIRST + 51,
			TCM_SETEXTENDEDSTYLE = TCM_FIRST + 52,  // optional wParam == mask
			TCM_GETEXTENDEDSTYLE = TCM_FIRST + 53,
			TCM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
			TCM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT
		}

		[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
		public enum TabControlNotification
		{
			TCN_KEYDOWN = TCN_FIRST - 0,
			TCN_SELCHANGE = TCN_FIRST - 1,
			TCN_SELCHANGING = TCN_FIRST - 2,
			TCN_GETOBJECT = TCN_FIRST - 3,
			TCN_FOCUSCHANGE = TCN_FIRST - 4,
		}

		/// <summary>This section lists supported tab control styles.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760549")]
		[Flags]
		public enum TabControlStyles
		{
			/// <summary>Version 4.70. Unneeded tabs scroll to the opposite side of the control when a tab is selected.</summary>
			TCS_SCROLLOPPOSITE = 0x0001,
			/// <summary>Version 4.70. Tabs appear at the bottom of the control. This value equals TCS_RIGHT. This style is not supported if you use ComCtl32.dll version 6.</summary>
			TCS_BOTTOM = 0x0002,
			/// <summary>Version 4.70. Tabs appear vertically on the right side of controls that use the TCS_VERTICAL style. This value equals TCS_BOTTOM. This style is not supported if you use visual styles.</summary>
			TCS_RIGHT = 0x0002,
			/// <summary>Version 4.70. Multiple tabs can be selected by holding down the CTRL key when clicking. This style must be used with the TCS_BUTTONS style.</summary>
			TCS_MULTISELECT = 0x0004,
			/// <summary>Version 4.71. Selected tabs appear as being indented into the background while other tabs appear as being on the same plane as the background. This style only affects tab controls with the TCS_BUTTONS style.</summary>
			TCS_FLATBUTTONS = 0x0008,
			/// <summary>Icons are aligned with the left edge of each fixed-width tab. This style can only be used with the TCS_FIXEDWIDTH style.</summary>
			TCS_FORCEICONLEFT = 0x0010,
			/// <summary>Labels are aligned with the left edge of each fixed-width tab; that is, the label is displayed immediately to the right of the icon instead of being centered. This style can only be used with the TCS_FIXEDWIDTH style, and it implies the TCS_FORCEICONLEFT style.</summary>
			TCS_FORCELABELLEFT = 0x0020,
			/// <summary>Version 4.70. Items under the pointer are automatically highlighted. You can check whether hot tracking is enabled by calling SystemParametersInfo.</summary>
			TCS_HOTTRACK = 0x0040,
			/// <summary>Version 4.70. Tabs appear at the left side of the control, with tab text displayed vertically. This style is valid only when used with the TCS_MULTILINE style. To make tabs appear on the right side of the control, also use the TCS_RIGHT style. This style is not supported if you use ComCtl32.dll version 6.</summary>
			TCS_VERTICAL = 0x0080,
			/// <summary>Tabs appear as tabs, and a border is drawn around the display area. This style is the default.</summary>
			TCS_TABS = 0x0000,
			/// <summary>Tabs appear as buttons, and no border is drawn around the display area.</summary>
			TCS_BUTTONS = 0x0100,
			/// <summary>Only one row of tabs is displayed. The user can scroll to see more tabs, if necessary. This style is the default.</summary>
			TCS_SINGLELINE = 0x0000,
			/// <summary>Multiple rows of tabs are displayed, if necessary, so all tabs are visible at once.</summary>
			TCS_MULTILINE = 0x0200,
			/// <summary>The width of each tab is increased, if necessary, so that each row of tabs fills the entire width of the tab control. This window style is ignored unless the TCS_MULTILINE style is also specified.</summary>
			TCS_RIGHTJUSTIFY = 0x0000,
			/// <summary>All tabs are the same width. This style cannot be combined with the TCS_RIGHTJUSTIFY style.</summary>
			TCS_FIXEDWIDTH = 0x0400,
			/// <summary>Rows of tabs will not be stretched to fill the entire width of the control. This style is the default.</summary>
			TCS_RAGGEDRIGHT = 0x0800,
			/// <summary>The tab control receives the input focus when clicked.</summary>
			TCS_FOCUSONBUTTONDOWN = 0x1000,
			/// <summary>The parent window is responsible for drawing tabs.</summary>
			TCS_OWNERDRAWFIXED = 0x2000,
			/// <summary>The tab control has a tooltip control associated with it.</summary>
			TCS_TOOLTIPS = 0x4000,
			/// <summary>The tab control does not receive the input focus when clicked.</summary>
			TCS_FOCUSNEVER = 0x8000,
		}

		/// <summary>
		/// The tab control now supports extended styles. These styles are manipulated using the TCM_GETEXTENDEDSTYLE and TCM_SETEXTENDEDSTYLE messages and should not be confused with extended window styles that are passed to CreateWindowEx.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760546")]
		[Flags]
		public enum TabControlStylesEx
		{
			/// <summary>Version 4.71. The tab control will draw separators between the tab items. This extended style only affects tab controls that have the TCS_BUTTONS and TCS_FLATBUTTONS styles. By default, creating the tab control with the TCS_FLATBUTTONS style sets this extended style. If you do not require separators, you should remove this extended style after creating the control.</summary>
			TCS_EX_FLATSEPARATORS = 0x00000001,
			/// <summary>Version 4.71. The tab control generates TCN_GETOBJECT notification codes to request a drop target object when an object is dragged over the tab items in the control. The application must call CoInitialize or OleInitialize before setting this style.</summary>
			TCS_EX_REGISTERDROP = 0x00000002
		}

		/// <summary>
		/// Contains information about a hit test. This structure supersedes the TC_HITTESTINFO structure.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760553")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TCHITTESTINFO
		{
			/// <summary>Position to hit test, in client coordinates.</summary>
			public Point pt;
			/// <summary>Variable that receives the results of a hit test. The tab control sets this member to one of the following values:</summary>
			public TabControlHitTestFlags flags;
		}

		/// <summary>
		/// Specifies or receives the attributes of a tab item. It is used with the TCM_INSERTITEM, TCM_GETITEM, and TCM_SETITEM messages. This structure
		/// supersedes the TC_ITEM structure.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760554")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class TCITEM : IDisposable
		{
			/// <summary>Value that specifies which members to retrieve or set.</summary>
			public TabControlItemMask mask;
			/// <summary>Version 4.70. Specifies the item's current state if information is being retrieved. If item information is being set, this member contains the state value to be set for the item. For a list of valid tab control item states, see Tab Control Item States. This member is ignored in the TCM_INSERTITEM message.</summary>
			public TabControlItemStates dwState;
			/// <summary>Version 4.70. Specifies which bits of the dwState member contain valid information. This member is ignored in the TCM_INSERTITEM message.</summary>
			public TabControlItemStates dwStateMask;
			/// <summary>Pointer to a null-terminated string that contains the tab text when item information is being set. If item information is being retrieved, this member specifies the address of the buffer that receives the tab text.</summary>
			public IntPtr pszText;
			/// <summary>Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information, this member is ignored.</summary>
			public uint cchTextMax;
			/// <summary>Index in the tab control's image list, or -1 if there is no image for the tab.</summary>
			public int iImage;
			/// <summary>Application-defined data associated with the tab control item. If more or less than 4 bytes of application-defined data exist per tab, an application must define a structure and use it instead of the TCITEM structure. The first member of the application-defined structure must be a TCITEMHEADER structure.</summary>
			public IntPtr lParam;

			/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
			public TCITEM(TabControlItemMask itemsToGet = TabControlItemMask.TCIF_ALL, TabControlItemStates statesToGet = TabControlItemStates.TCIS_ALL)
			{
				if ((itemsToGet & TabControlItemMask.TCIF_TEXT) != 0) pszText = StringHelper.AllocChars(cchTextMax = 1024);
			}

			/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public TCITEM(string text) { Text = text; }

			/// <summary>Gets or sets the text.</summary>
			/// <value>The text.</value>
			public string Text
			{
				get => Marshal.PtrToStringAuto(pszText);
				set
				{
					StringHelper.RefreshString(ref pszText, out cchTextMax, value);
					mask |= TabControlItemMask.TCIF_TEXT;
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				StringHelper.FreeString(pszText);
				cchTextMax = 0;
			}
		}

		/// <summary>
		/// Specifies or receives the attributes of a tab. It is used with the TCM_INSERTITEM, TCM_GETITEM, and TCM_SETITEM messages. This structure supersedes
		/// the TC_ITEMHEADER structure.
		/// </summary>
		/// <seealso cref="System.IDisposable"/>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760813")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public sealed class TCITEMHEADER : IDisposable
		{
			/// <summary>Value that specifies which members to retrieve or set.</summary>
			public TabControlItemMask mask;
			/// <summary>Version 4.70. Specifies the item's current state if information is being retrieved. If item information is being set, this member contains the state value to be set for the item. For a list of valid tab control item states, see Tab Control Item States. This member is ignored in the TCM_INSERTITEM message.</summary>
			public TabControlItemStates dwState;
			/// <summary>Version 4.70. Specifies which bits of the dwState member contain valid information. This member is ignored in the TCM_INSERTITEM message.</summary>
			public TabControlItemStates dwStateMask;
			/// <summary>Pointer to a null-terminated string that contains the tab text when item information is being set. If item information is being retrieved, this member specifies the address of the buffer that receives the tab text.</summary>
			public IntPtr pszText;
			/// <summary>Size in TCHARs of the buffer pointed to by the pszText member. If the structure is not receiving information, this member is ignored.</summary>
			public uint cchTextMax;
			/// <summary>Index in the tab control's image list, or -1 if there is no image for the tab.</summary>
			public int iImage;

			/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
			public TCITEMHEADER(TabControlItemMask itemsToGet = TabControlItemMask.TCIF_ALL, TabControlItemStates statesToGet = TabControlItemStates.TCIS_ALL)
			{
				if ((itemsToGet & TabControlItemMask.TCIF_TEXT) != 0) pszText = StringHelper.AllocChars(cchTextMax = 1024);
			}

			/// <summary>Initializes a new instance of the <see cref="TCITEM"/> class.</summary>
			/// <param name="text">The text.</param>
			public TCITEMHEADER(string text) { Text = text; }

			/// <summary>Gets or sets the text.</summary>
			/// <value>The text.</value>
			public string Text
			{
				get => Marshal.PtrToStringAuto(pszText);
				set
				{
					StringHelper.RefreshString(ref pszText, out cchTextMax, value);
					mask |= TabControlItemMask.TCIF_TEXT;
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				StringHelper.FreeString(pszText);
				cchTextMax = 0;
			}
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage(HandleRef hWnd, TabControlMessage Msg, int wParam, ref TCHITTESTINFO item) => User32_Gdi.SendMessage(hWnd, Msg, wParam, ref item);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="item">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage(HandleRef hWnd, TabControlMessage Msg, int wParam, TCITEM item) => User32_Gdi.SendMessage(hWnd, Msg, wParam, item);
	}
}