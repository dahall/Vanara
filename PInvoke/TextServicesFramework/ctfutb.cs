using System;
using System.Runtime.InteropServices;
using LPARAM = System.IntPtr;

using WPARAM = System.IntPtr;

namespace Vanara.PInvoke
{
	public static partial class MSCTF
	{
		/// <summary>Specifies how the system language bar item should display the icon.</summary>
		[PInvokeData("ctfutb.h")]
		public enum TF_DTLBI : uint
		{
			/// <summary>The system language bar item should display a default icon for the item.</summary>
			TF_DTLBI_NONE = 0,

			/// <summary>The system language bar item should display the icon specified for the language profile.</summary>
			TF_DTLBI_USEPROFILEICON = 0x00000001,
		}

		/// <summary>
		/// The <c>TF_LBI_*</c> constants are used with the ITfLangBarItemSink::OnUpdate method to indicate which language bar items changed.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-lbi--constants
		[PInvokeData("ctfutb.h")]
		[Flags]
		public enum TF_LBI : uint
		{
			/// <summary>The icon of the item has changed. The language bar calls ITfLangBarItemButton::GetIcon in response to this notification.</summary>
			TF_LBI_ICON = 0x00000001,

			/// <summary>
			/// The text of a button or bitmap button item has changed. The language bar calls ITfLangBarItemButton::GetText or
			/// ITfLangBarItemBitmapButton::GetText, whichever is appropriate, in response to this notification.
			/// </summary>
			TF_LBI_TEXT = 0x00000002,

			/// <summary>
			/// The tooltip text of the item changed. The language bar calls ITfLangBarItem::GetTooltipString in response to this notification.
			/// </summary>
			TF_LBI_TOOLTIP = 0x00000004,

			/// <summary>
			/// The bitmap of a bitmap or bitmap button item changed. The language bar calls ITfLangBarItemBitmap::DrawBitmap or
			/// ITfLangBarItemBitmapButton::DrawBitmap, whichever is appropriate, in response to this notification.
			/// </summary>
			TF_LBI_BITMAP = 0x00000008,

			/// <summary>
			/// The information for a balloon item changed. The language bar calls ITfLangBarItemBalloon::GetBalloonInfo in response to this notification.
			/// </summary>
			TF_LBI_BALLOON = 0x00000010,

			/// <summary>The item status changed. The language bar calls ITfLangBarItem::GetStatus in response to this notification.</summary>
			TF_LBI_STATUS = 0x00010000,

			/// <summary>Combines TF_LBI_BITMAP and TF_LBI_TOOLTIP.</summary>
			TF_LBI_BMPALL = TF_LBI_BITMAP | TF_LBI_TOOLTIP,

			/// <summary>Combines TF_LBI_BITMAP, TF_LBI_TEXT and TF_LBI_TOOLTIP.</summary>
			TF_LBI_BMPBTNALL = TF_LBI_BITMAP | TF_LBI_TEXT | TF_LBI_TOOLTIP,

			/// <summary>Combines TF_LBI_ICON, TF_LBI_TEXT and TF_LBI_TOOLTIP.</summary>
			TF_LBI_BTNALL = TF_LBI_ICON | TF_LBI_TEXT | TF_LBI_TOOLTIP,
		}

		/// <summary>
		/// <para>
		/// The <c>TF_LBI_STATUS_*</c> constants indicate the status of a language bar item. These values are used with the
		/// ITfLangBarItem::GetStatus method.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TF_LBI_STATUS_HIDDEN 0x00000001</term>
		/// <term>The item is hidden. This style is ignored if the item does not include the TF_LBI_STYLE_HIDDENSTATUSCONTROL style.</term>
		/// </item>
		/// <item>
		/// <term>TF_LBI_STATUS_DISABLED 0x00000002</term>
		/// <term>The item is disabled.</term>
		/// </item>
		/// <item>
		/// <term>TF_LBI_STATUS_BTN_TOGGLED 0x00010000</term>
		/// <term>
		/// The item is in the toggled or pressed state. This style is ignored if the item does not include the TF_LBI_STYLE_BTN_TOGGLE style.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-lbi-status--constants
		[PInvokeData("ctfutb.h")]
		[Flags]
		public enum TF_LBI_STATUS : uint
		{
			/// <summary>
			/// The item is hidden. This style is ignored if the item does not include the TF_LBI_STYLE_HIDDENSTATUSCONTROL style.
			/// </summary>
			TF_LBI_STATUS_HIDDEN = 0x00000001,

			/// <summary>The item is disabled.</summary>
			TF_LBI_STATUS_DISABLED = 0x00000002,

			/// <summary>
			/// The item is in the toggled or pressed state. This style is ignored if the item does not include the TF_LBI_STYLE_BTN_TOGGLE style.
			/// </summary>
			TF_LBI_STATUS_BTN_TOGGLED = 0x00010000,
		}

		/// <summary>
		/// <para>
		/// The <c>TF_LBI_STYLE_*</c> constants are used in the <c>dwStyle</c> member of the TF_LANGBARITEMINFO structure to specify the
		/// style of a language bar item.
		/// </para>
		/// <para>
		/// If this style is combined with TF_LBI_STYLE_BTN_BUTTON, a drop-down arrow will be displayed for the item in addition to the
		/// text. The drop-down arrow functions as the menu button and clicking it will cause <c>ITfLangBarItemButton::InitMenu</c> to be
		/// called. Clicking the text portion of the button will cause <c>ITfLangBarItemButton::OnClick</c> to be called.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-lbi-style--constants
		[PInvokeData("ctfutb.h")]
		[Flags]
		public enum TF_LBI_STYLE
		{
			/// <summary>
			/// The item can be hidden or shown dynamically using the TF_LBI_STATUS_HIDDEN value in the ITfLangBarItem::GetStatus method. If
			/// this value is not present, the item cannot be hidden in this manner.
			/// </summary>
			TF_LBI_STYLE_HIDDENSTATUSCONTROL = 0x00000001,

			/// <summary>
			/// The item will be displayed in the notification icon tray in addition to the language bar. This flag is not currently supported.
			/// </summary>
			TF_LBI_STYLE_SHOWNINTRAY = 0x00000002,

			/// <summary>
			/// The language bar is hidden if all items in the language bar contain this style. If any item in the language bar does not
			/// contain this style, the language bar is displayed.
			/// </summary>
			TF_LBI_STYLE_HIDEONNOOTHERITEMS = 0x00000004,

			/// <summary>
			/// The item will only be displayed in the notification icon tray and not in the language bar. This flag is not currently supported.
			/// </summary>
			TF_LBI_STYLE_SHOWNINTRAYONLY = 0x00000008,

			/// <summary>
			/// The item is not displayed in the toolbar until it is selected from the language bar options menu. This flag is ignored if
			/// the TF_LBI_STYLE_HIDDENSTATUSCONTROL is set or the user has already changed the hidden/shown state using the language bar
			/// options menu.
			/// </summary>
			TF_LBI_STYLE_HIDDENBYDEFAULT = 0x00000010,

			/// <summary>
			/// Any black pixel within the icon will be converted to the text color of the selected theme. The icon must be monochrome.
			/// </summary>
			TF_LBI_STYLE_TEXTCOLORICON = 0x00000020,

			/// <summary>The item is a push button. ITfLangBarItemButton::OnClick is called when the item is pressed.</summary>
			TF_LBI_STYLE_BTN_BUTTON = 0x00010000,

			/// <summary>
			/// The item is a menu. ITfLangBarItemButton::InitMenu is called when the item is pressed.
			/// <para>
			/// If this style is combined with TF_LBI_STYLE_BTN_BUTTON, a drop-down arrow will be displayed for the item in addition to the
			/// text. The drop-down arrow functions as the menu button and clicking it will cause ITfLangBarItemButton::InitMenu to be
			/// called. Clicking the text portion of the button will cause ITfLangBarItemButton::OnClick to be called.
			/// </para>
			/// </summary>
			TF_LBI_STYLE_BTN_MENU = 0x00020000,

			/// <summary>
			/// The item is a toggle button and operates similar to a check box. ITfLangBarItemButton::OnClick is called when the item is pressed.
			/// </summary>
			TF_LBI_STYLE_BTN_TOGGLE = 0x00040000,
		}

		/// <summary>
		/// The <c>TF_LBMENUF_*</c> constants are used in the ITfMenu::AddMenuItem method to specify the characteristics of a menu item in
		/// the language bar.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-lbmenuf--constants
		[PInvokeData("ctfutb.h")]
		[Flags]
		public enum TF_LBMENUF : uint
		{
			/// <summary>The menu item is checked.</summary>
			TF_LBMENUF_CHECKED = 0x01,

			/// <summary>The menu item is a submenu.</summary>
			TF_LBMENUF_SUBMENU = 0x02,

			/// <summary>The menu item is a separator.</summary>
			TF_LBMENUF_SEPARATOR = 0x04,

			/// <summary>The menu item is a radio check mark.</summary>
			TF_LBMENUF_RADIOCHECKED = 0x08,

			/// <summary>The menu item is disabled.</summary>
			TF_LBMENUF_GRAYED = 0x10,
		}

		/// <summary>
		/// <para>The <c>TF_SFT_*</c> constants specify display settings of a floating language bar.</para>
		/// </summary>
		/// <remarks>
		/// The ITfLangBarMgr::ShowFloating method sets the result of a logical <c>OR</c> operation on one or more of these constants to
		/// specify the attributes of the language bar item.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/tsf/tf-sft--constants
		[PInvokeData("ctfutb.h")]
		[Flags]
		public enum TF_SFT : uint
		{
			/// <summary>
			/// Display the language bar as a floating window. This constant cannot be combined with the TF_SFT_DOCK, TF_SFT_MINIMIZED,
			/// TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants.
			/// </summary>
			TF_SFT_SHOWNORMAL = 0x00000001,

			/// <summary>
			/// Dock the language bar in its own task pane. This constant cannot be combined with the TF_SFT_SHOWNORMAL, TF_SFT_MINIMIZED,
			/// TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants. Available only on Windows XP.
			/// </summary>
			TF_SFT_DOCK = 0x00000002,

			/// <summary>
			/// Display the language bar as a single icon in the system tray. This constant cannot be combined with the TF_SFT_SHOWNORMAL,
			/// TF_SFT_DOCK, TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants. In Windows XP, use TF_SFT_DESKBAND instead.
			/// </summary>
			TF_SFT_MINIMIZED = 0x00000004,

			/// <summary>
			/// Hide the language bar. This constant cannot be combined with the TF_SFT_SHOWNORMAL, TF_SFT_DOCK, TF_SFT_MINIMIZED, or
			/// TF_SFT_DESKBAND constants.
			/// </summary>
			TF_SFT_HIDDEN = 0x00000008,

			/// <summary>Make the language bar opaque.</summary>
			TF_SFT_NOTRANSPARENCY = 0x00000010,

			/// <summary>Make the language bar partially transparent. Available only on Windows 2000 or later.</summary>
			TF_SFT_LOWTRANSPARENCY = 0x00000020,

			/// <summary>Make the language bar highly transparent. Available only on Windows 2000 or later.</summary>
			TF_SFT_HIGHTRANSPARENCY = 0x00000040,

			/// <summary>Display text labels next to language bar icons.</summary>
			TF_SFT_LABELS = 0x00000080,

			/// <summary>Hide language bar icon text labels.</summary>
			TF_SFT_NOLABELS = 0x00000100,

			/// <summary>Display text service icons on the taskbar when the language bar is minimized.</summary>
			TF_SFT_EXTRAICONSONMINIMIZED = 0x00000200,

			/// <summary>Hide text service icons on the taskbar when the language bar is minimized.</summary>
			TF_SFT_NOEXTRAICONSONMINIMIZED = 0x00000400,

			/// <summary>
			/// Dock the language bar in the righthand end of the system task bar (immediately left of the system tray/clock). This constant
			/// cannot be combined with the TF_SFT_SHOWNORMAL, TF_SFT_DOCK, TF_SFT_MINIMIZED, or TF_SFT_HIDDEN constants. Available only on
			/// Windows XP.
			/// </summary>
			TF_SFT_DESKBAND = 0x00000800,
		}

		/// <summary>Elements of the <c>TfLBBalloonStyle</c> enumeration are used to specify a language bar balloon style.</summary>
		/// <remarks>
		/// <para>The following image shows an example of a balloon with the TF_LB_BALLOON_RECO style.</para>
		/// <para>The following image shows an example of a balloon with the TF_LB_BALLOON_SHOW style.</para>
		/// <para>The following image shows an example of a balloon with the TF_LB_BALLOON_MISS style.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/ne-ctfutb-tflbballoonstyle
		[PInvokeData("ctfutb.h", MSDNShortId = "NE:ctfutb.__MIDL_ITfLangBarItemBalloon_0001")]
		[Guid("F399A969-9E97-4DDD-B974-2BFB934CFBC9")]
		public enum TfLBBalloonStyle : uint
		{
			/// <summary>This balloon style is used to represent a reconversion operation.</summary>
			TF_LB_BALLOON_RECO,

			/// <summary>This is a normal balloon style.</summary>
			TF_LB_BALLOON_SHOW,

			/// <summary>This balloon style is used to indicate that a command was not recognized.</summary>
			TF_LB_BALLOON_MISS,
		}

		/// <summary>Elements of the <c>TfLBIClick</c> enumeration specify which mouse button was used to click a toolbar item.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/ne-ctfutb-tflbiclick
		[PInvokeData("ctfutb.h", MSDNShortId = "NE:ctfutb.__MIDL___MIDL_itf_ctfutb_0000_0010_0001")]
		[Guid("8FB5F0CE-DFDD-4F0A-85B9-8988D8DD8FF2")]
		public enum TfLBIClick : uint
		{
			/// <summary>The user right-clicked the button.</summary>
			TF_LBI_CLK_RIGHT,

			/// <summary>The user left-clicked the button.</summary>
			TF_LBI_CLK_LEFT,
		}

		/// <summary>
		/// The <c>ITfLangBarEventSink</c> interface is implemented by an application or text service and used by the language bar to supply
		/// notifications of certain events that occur in the language bar. The application or text service installs this event sink by
		/// calling ITfLangBarMgr::AdviseEventSink.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbareventsink
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarEventSink")]
		[ComImport, Guid("18A4E900-E0AE-11D2-AFDD-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfLangBarEventSink
		{
			/// <summary>Called when the thread the event sink was installed from receives the input focus.</summary>
			/// <param name="dwThreadId">Contains the current thread identifier. This is the same value returned from GetCurrentThreadId.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-onsetfocus HRESULT OnSetFocus( DWORD
			// dwThreadId );
			[PreserveSig]
			HRESULT OnSetFocus(uint dwThreadId);

			/// <summary>Not currently used.</summary>
			/// <param name="dwThreadId">Not currently used.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-onthreadterminate HRESULT
			// OnThreadTerminate( DWORD dwThreadId );
			[Obsolete("Not currently used.")]
			[PreserveSig]
			HRESULT OnThreadTerminate(uint dwThreadId);

			/// <summary>Called when a language bar item changes.</summary>
			/// <param name="dwThreadId">Contains the current thread identifier. This is the same value returned from GetCurrentThreadId.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-onthreaditemchange HRESULT
			// OnThreadItemChange( DWORD dwThreadId );
			[PreserveSig]
			HRESULT OnThreadItemChange(uint dwThreadId);

			/// <summary>Not currently used.</summary>
			/// <param name="dwThreadId">Not currently used.</param>
			/// <param name="uMsg">Not currently used.</param>
			/// <param name="wParam">Not currently used.</param>
			/// <param name="lParam">Not currently used.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-onmodalinput HRESULT OnModalInput(
			// DWORD dwThreadId, UINT uMsg, WPARAM wParam, LPARAM lParam );
			[Obsolete("Not currently used.")]
			[PreserveSig]
			HRESULT OnModalInput(uint dwThreadId, uint uMsg, [In] WPARAM wParam, [In] LPARAM lParam);

			/// <summary>Called when ITfLangBarMgr::ShowFloating is called.</summary>
			/// <param name="dwFlags">Contains the TF_SFT_* values passed to <c>ITfLangBarMgr::ShowFloating</c>.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-showfloating HRESULT ShowFloating(
			// DWORD dwFlags );
			[PreserveSig]
			HRESULT ShowFloating([In] TF_SFT dwFlags);

			/// <summary>Not currently used.</summary>
			/// <param name="dwThreadId">Not currently used.</param>
			/// <param name="rguid">Not currently used.</param>
			/// <param name="prc">Not currently used.</param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbareventsink-getitemfloatingrect HRESULT
			// GetItemFloatingRect( DWORD dwThreadId, REFGUID rguid, RECT *prc );
			[Obsolete("Not currently used.")]
			[PreserveSig]
			HRESULT GetItemFloatingRect(uint dwThreadId, in Guid rguid, out RECT prc);
		}

		/// <summary>
		/// The <c>ITfLangBarItem</c> interface is implemented by a language bar item provider and used by the language bar manager to
		/// obtain detailed information about the language bar item. An instance of this interface is provided to the language bar manager
		/// by the ITfLangBarItemMgr::AddItem method.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritem
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItem")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("73540D69-EDEB-4EE9-96C9-23AA30B25916")]
		public interface ITfLangBarItem
		{
			/// <summary>Obtains information about the language bar item.</summary>
			/// <param name="pInfo">Pointer to a TF_LANGBARITEMINFO structure that receives the language bar item information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getinfo HRESULT GetInfo(
			// TF_LANGBARITEMINFO *pInfo );
			[PreserveSig]
			HRESULT GetInfo(out TF_LANGBARITEMINFO pInfo);

			/// <summary>Obtains the status of a language bar item.</summary>
			/// <param name="pdwStatus">
			/// Pointer to a <c>DWORD</c> that receives zero or a combination of one or more of the TF_LBI_STATUS_* values that indicate the
			/// current status of the item.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pdwStatus is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getstatus HRESULT GetStatus( DWORD
			// *pdwStatus );
			[PreserveSig]
			HRESULT GetStatus(out TF_LBI_STATUS pdwStatus);

			/// <summary>Called to show or hide the language bar item.</summary>
			/// <param name="fShow">
			/// Contains a <c>BOOL</c> that indicates if the item should be shown or hidden. Contains a nonzero value if the item should be
			/// shown or zero otherwise.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support this method.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The language bar item implementation should update its visible status by modifying the value returned from
			/// ITfLangBarItem::GetStatus to include or exclude the TF_LBI_STATUS_HIDDEN status flag. The implementation then prompts
			/// language bar to obtain the new status value by calling ITfLangBarItemSink::OnUpdate with TF_LBI_STATUS.
			/// </para>
			/// <para>
			/// This method is only useful when the item has the TF_LBI_STYLE_HIDDENSTATUSCONTROL style. Without this style, only the
			/// language bar can show or hide the item.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-show HRESULT Show( BOOL fShow );
			[PreserveSig]
			HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Obtains the text to be displayed in the tooltip for the language bar item.</summary>
			/// <param name="pbstrToolTip">
			/// Pointer to a <c>BSTR</c> value that receives the tooltip string for the language bar item. This string must be allocated
			/// using the SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrToolTip is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support tooltip text.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-gettooltipstring HRESULT GetTooltipString(
			// BSTR *pbstrToolTip );
			[PreserveSig]
			HRESULT GetTooltipString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrToolTip);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemBalloon</c> interface is implemented by an application or text service and is used by the language bar
		/// manager to obtain information specific to a balloon item on the language bar.
		/// </para>
		/// <para>
		/// The language bar manager obtains an instance of this interface by calling QueryInterface on the ITfLangBarItem passed to
		/// ITfLangBarItemMgr::AddItem with IID_ITfLangBarItemBalloon.
		/// </para>
		/// </summary>
		/// <remarks>A language bar balloon acts as a pop-up notification on the language bar.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritemballoon
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemBalloon")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("01C2D285-D3C7-4B7B-B5B5-D97411D0C283")]
		public interface ITfLangBarItemBalloon : ITfLangBarItem
		{
			/// <summary>Obtains information about the language bar item.</summary>
			/// <param name="pInfo">Pointer to a TF_LANGBARITEMINFO structure that receives the language bar item information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getinfo HRESULT GetInfo(
			// TF_LANGBARITEMINFO *pInfo );
			[PreserveSig]
			new HRESULT GetInfo(out TF_LANGBARITEMINFO pInfo);

			/// <summary>Obtains the status of a language bar item.</summary>
			/// <param name="pdwStatus">
			/// Pointer to a <c>DWORD</c> that receives zero or a combination of one or more of the TF_LBI_STATUS_* values that indicate the
			/// current status of the item.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pdwStatus is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getstatus HRESULT GetStatus( DWORD
			// *pdwStatus );
			[PreserveSig]
			new HRESULT GetStatus(out TF_LBI_STATUS pdwStatus);

			/// <summary>Called to show or hide the language bar item.</summary>
			/// <param name="fShow">
			/// Contains a <c>BOOL</c> that indicates if the item should be shown or hidden. Contains a nonzero value if the item should be
			/// shown or zero otherwise.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support this method.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The language bar item implementation should update its visible status by modifying the value returned from
			/// ITfLangBarItem::GetStatus to include or exclude the TF_LBI_STATUS_HIDDEN status flag. The implementation then prompts
			/// language bar to obtain the new status value by calling ITfLangBarItemSink::OnUpdate with TF_LBI_STATUS.
			/// </para>
			/// <para>
			/// This method is only useful when the item has the TF_LBI_STYLE_HIDDENSTATUSCONTROL style. Without this style, only the
			/// language bar can show or hide the item.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-show HRESULT Show( BOOL fShow );
			[PreserveSig]
			new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Obtains the text to be displayed in the tooltip for the language bar item.</summary>
			/// <param name="pbstrToolTip">
			/// Pointer to a <c>BSTR</c> value that receives the tooltip string for the language bar item. This string must be allocated
			/// using the SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrToolTip is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support tooltip text.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-gettooltipstring HRESULT GetTooltipString(
			// BSTR *pbstrToolTip );
			[PreserveSig]
			new HRESULT GetTooltipString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrToolTip);

			/// <summary>Not currently used.</summary>
			/// <param name="click">Contains one of the TfLBIClick values that indicate which mouse button was used to click the balloon.</param>
			/// <param name="pt">
			/// Pointer to a Point structure that contains the position of the mouse cursor, in screen coordinates, at the
			/// time of the click event.
			/// </param>
			/// <param name="prcArea">Pointer to a RECT structure that contains the bounding rectangle, in screen coordinates, of the balloon.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemballoon-onclick HRESULT OnClick( TfLBIClick
			// click, Point pt, const RECT *prcArea );
			[Obsolete("Not currently used.")]
			[PreserveSig]
			HRESULT OnClick([In] TfLBIClick click, [In] POINT pt, in RECT prcArea);

			/// <summary>Obtains the preferred size,in pixels, of the balloon.</summary>
			/// <param name="pszDefault">Pointer to a SIZE structure that contains the default size, in pixels, of the balloon.</param>
			/// <param name="psz">
			/// Pointer to a <c>SIZE</c> structure that recevies the preferred balloon size, in pixels. The <c>cy</c> member of this
			/// structure is ignored.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This method is required. The balloon must supply the preferred size in response to this method.</para>
			/// <para>
			/// To obtain the font used to draw the balloon, call GetStockObject with DEFAULT_GUI_FONT. This font can be used to calculate
			/// the preferred balloon size at runtime.
			/// </para>
			/// <para>
			/// If the ballon text will not fit into the preferred size obtained from this method, the language bar truncates the text and
			/// adds an ellipses to the text.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemballoon-getpreferredsize HRESULT
			// GetPreferredSize( const SIZE *pszDefault, SIZE *psz );
			[PreserveSig]
			HRESULT GetPreferredSize(in SIZE pszDefault, out SIZE psz);

			/// <summary>Obtains information about the balloon.</summary>
			/// <param name="pInfo">Pointer to a TF_LBBALLOONINFO structure that receives the information about the balloon.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemballoon-getballooninfo HRESULT
			// GetBalloonInfo( TF_LBBALLOONINFO *pInfo );
			[PreserveSig]
			HRESULT GetBalloonInfo(out TF_LBBALLOONINFO pInfo);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemBitmap</c> interface is implemented by an application or text service and used by the language bar manager
		/// to obtain information specific to a bitmap item on the language bar.
		/// </para>
		/// <para>
		/// The language bar manager obtains an instance of this interface by calling QueryInterface on the ITfLangBarItem passed to
		/// ITfLangBarItemMgr::AddItem with IID_ITfLangBarItemBitmap.
		/// </para>
		/// </summary>
		/// <remarks>A language bar bitmap functions as a static item on the language bar that displays a bitmap.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritembitmap
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemBitmap")]
		[ComImport, Guid("73830352-D722-4179-ADA5-F045C98DF355"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfLangBarItemBitmap : ITfLangBarItem
		{
			/// <summary>Obtains information about the language bar item.</summary>
			/// <param name="pInfo">Pointer to a TF_LANGBARITEMINFO structure that receives the language bar item information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getinfo HRESULT GetInfo(
			// TF_LANGBARITEMINFO *pInfo );
			[PreserveSig]
			new HRESULT GetInfo(out TF_LANGBARITEMINFO pInfo);

			/// <summary>Obtains the status of a language bar item.</summary>
			/// <param name="pdwStatus">
			/// Pointer to a <c>DWORD</c> that receives zero or a combination of one or more of the TF_LBI_STATUS_* values that indicate the
			/// current status of the item.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pdwStatus is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getstatus HRESULT GetStatus( DWORD
			// *pdwStatus );
			[PreserveSig]
			new HRESULT GetStatus(out TF_LBI_STATUS pdwStatus);

			/// <summary>Called to show or hide the language bar item.</summary>
			/// <param name="fShow">
			/// Contains a <c>BOOL</c> that indicates if the item should be shown or hidden. Contains a nonzero value if the item should be
			/// shown or zero otherwise.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support this method.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The language bar item implementation should update its visible status by modifying the value returned from
			/// ITfLangBarItem::GetStatus to include or exclude the TF_LBI_STATUS_HIDDEN status flag. The implementation then prompts
			/// language bar to obtain the new status value by calling ITfLangBarItemSink::OnUpdate with TF_LBI_STATUS.
			/// </para>
			/// <para>
			/// This method is only useful when the item has the TF_LBI_STYLE_HIDDENSTATUSCONTROL style. Without this style, only the
			/// language bar can show or hide the item.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-show HRESULT Show( BOOL fShow );
			[PreserveSig]
			new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Obtains the text to be displayed in the tooltip for the language bar item.</summary>
			/// <param name="pbstrToolTip">
			/// Pointer to a <c>BSTR</c> value that receives the tooltip string for the language bar item. This string must be allocated
			/// using the SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrToolTip is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support tooltip text.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-gettooltipstring HRESULT GetTooltipString(
			// BSTR *pbstrToolTip );
			[PreserveSig]
			new HRESULT GetTooltipString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrToolTip);

			/// <summary>Not currently used.</summary>
			/// <param name="click">Contains one of the TfLBIClick values that indicate which mouse button was used to click the bitmap.</param>
			/// <param name="pt">
			/// Pointer to a Point structure that contains the position of the mouse cursor, in screen coordinates, at the
			/// time of the click event.
			/// </param>
			/// <param name="prcArea">Pointer to a RECT structure that contains the bounding rectangle, in screen coordinates, of the bitmap.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmap-onclick HRESULT OnClick( TfLBIClick
			// click, Point pt, const RECT *prcArea );
			[Obsolete("Not currently used.")]
			[PreserveSig]
			HRESULT OnClick([In] TfLBIClick click, [In] POINT pt, in RECT prcArea);

			/// <summary>Obtains the preferred size, in pixels, of the bitmap.</summary>
			/// <param name="pszDefault">Pointer to a SIZE structure that contains the default size, in pixels, of the bitmap.</param>
			/// <param name="psz">
			/// Pointer to a <c>SIZE</c> structure that receives the preferred size, in pixels, of the bitmap. The <c>cy</c> member of this
			/// structure is ignored.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmap-getpreferredsize HRESULT
			// GetPreferredSize( const SIZE *pszDefault, SIZE *psz );
			[PreserveSig]
			HRESULT GetPreferredSize(in SIZE pszDefault, out SIZE psz);

			/// <summary>Obtains the bitmap and mask for the bitmap item.</summary>
			/// <param name="bmWidth">Contains the width, in pixels, of the bitmap item.</param>
			/// <param name="bmHeight">Contains the height, in pixels, of the bitmap item.</param>
			/// <param name="dwFlags">Not currently used.</param>
			/// <param name="phbmp">Pointer to an HBITMAP value that receives the handle of the bitmap drawn for the bitmap item.</param>
			/// <param name="phbmpMask">
			/// <para>
			/// Pointer to an <c>HBITMAP</c> value that receives the handle of the mask bitmap. This is a monochrome bitmap that functions
			/// as a mask for phbmp. Each black pixel in this bitmap will cause the cooresponding pixel in phbmp to be displayed in its
			/// normal color. Every white pixel in this bitmap will cause the cooresponding pixel in phbmp to be displayed in the inverse of
			/// its normal color.
			/// </para>
			/// <para>
			/// To display the bitmap without any color conversion, create a monochrome bitmap the same size as phbmp and set each pixel to
			/// black (RGB(0, 0, 0)).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmap-drawbitmap HRESULT DrawBitmap( LONG
			// bmWidth, LONG bmHeight, DWORD dwFlags, HBITMAP *phbmp, HBITMAP *phbmpMask );
			[PreserveSig]
			HRESULT DrawBitmap(int bmWidth, int bmHeight, uint dwFlags, out HBITMAP phbmp, out HBITMAP phbmpMask);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemBitmapButton</c> interface is implemented by a language bar bitmap button provider and is used by the
		/// language bar manager to obtain information specific to a bitmap button item on the language bar.
		/// </para>
		/// <para>
		/// The language bar manager obtains an instance of this interface by calling QueryInterface on the ITfLangBarItem passed to
		/// ITfLangBarItemMgr::AddItem with IID_ITfLangBarItemBitmapButton.
		/// </para>
		/// </summary>
		/// <remarks>
		/// A language bar bitmap button functions as a button item on the language bar that displays text and a small bitmap. The bitmap
		/// displayed for the item should not be larger than the size of a small icon. Obtain these dimensions by calling GetSystemMetrics
		/// with SM_CXSMICON for the width and SM_CYSMICON for the height.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritembitmapbutton
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemBitmapButton")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A26A0525-3FAE-4FA0-89EE-88A964F9F1B5")]
		public interface ITfLangBarItemBitmapButton : ITfLangBarItem
		{
			/// <summary>Obtains information about the language bar item.</summary>
			/// <param name="pInfo">Pointer to a TF_LANGBARITEMINFO structure that receives the language bar item information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getinfo HRESULT GetInfo(
			// TF_LANGBARITEMINFO *pInfo );
			[PreserveSig]
			new HRESULT GetInfo(out TF_LANGBARITEMINFO pInfo);

			/// <summary>Obtains the status of a language bar item.</summary>
			/// <param name="pdwStatus">
			/// Pointer to a <c>DWORD</c> that receives zero or a combination of one or more of the TF_LBI_STATUS_* values that indicate the
			/// current status of the item.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pdwStatus is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getstatus HRESULT GetStatus( DWORD
			// *pdwStatus );
			[PreserveSig]
			new HRESULT GetStatus(out TF_LBI_STATUS pdwStatus);

			/// <summary>Called to show or hide the language bar item.</summary>
			/// <param name="fShow">
			/// Contains a <c>BOOL</c> that indicates if the item should be shown or hidden. Contains a nonzero value if the item should be
			/// shown or zero otherwise.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support this method.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The language bar item implementation should update its visible status by modifying the value returned from
			/// ITfLangBarItem::GetStatus to include or exclude the TF_LBI_STATUS_HIDDEN status flag. The implementation then prompts
			/// language bar to obtain the new status value by calling ITfLangBarItemSink::OnUpdate with TF_LBI_STATUS.
			/// </para>
			/// <para>
			/// This method is only useful when the item has the TF_LBI_STYLE_HIDDENSTATUSCONTROL style. Without this style, only the
			/// language bar can show or hide the item.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-show HRESULT Show( BOOL fShow );
			[PreserveSig]
			new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Obtains the text to be displayed in the tooltip for the language bar item.</summary>
			/// <param name="pbstrToolTip">
			/// Pointer to a <c>BSTR</c> value that receives the tooltip string for the language bar item. This string must be allocated
			/// using the SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrToolTip is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support tooltip text.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-gettooltipstring HRESULT GetTooltipString(
			// BSTR *pbstrToolTip );
			[PreserveSig]
			new HRESULT GetTooltipString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrToolTip);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_BUTTON style.</summary>
			/// <param name="click">Contains a TfLBIClick value that indicates which mouse button was used to click the button.</param>
			/// <param name="pt">
			/// Pointer to a Point structure that contains the position, in screen coordinates, of the mouse cursor at the
			/// time of the click event.
			/// </param>
			/// <param name="prcArea">Pointer to a RECT structure that contains the bounding rectangle, in screen coordinates, of the button.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-onclick HRESULT OnClick(
			// TfLBIClick click, Point pt, const RECT *prcArea );
			[PreserveSig]
			HRESULT OnClick([In] TfLBIClick click, [In] POINT pt, in RECT prcArea);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_MENU style.</summary>
			/// <param name="pMenu">
			/// Pointer to an ITfMenu interface that the language bar bitmap button uses to add items to the menu that the language bar
			/// displays for the button.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-initmenu HRESULT InitMenu(
			// ITfMenu *pMenu );
			[PreserveSig]
			HRESULT InitMenu([In] ITfMenu pMenu);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_MENU style.</summary>
			/// <param name="wID">Specifies the identifier of the menu item selected. This is the value passed for uId in ITfMenu::AddMenuItem.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-onmenuselect HRESULT
			// OnMenuSelect( UINT wID );
			[PreserveSig]
			HRESULT OnMenuSelect(uint wID);

			/// <summary>Obtains the preferred size, in pixels, of the bitmap.</summary>
			/// <param name="pszDefault">Pointer to a SIZE structure that contains the default size, in pixels, of the bitmap.</param>
			/// <param name="psz">
			/// Pointer to a SIZE structure that recevies the preferred size, in pixels, of the bitmap. The <c>cy</c> member of this
			/// structure is ignored.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The results of this method are not currently used. The bitmap for a bitmap button item should not be larger than the size of
			/// a small icon. Obtain these dimensions by calling GetSystemMetrics with SM_CXSMICON for the width and SM_CYSMICON for the height.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-getpreferredsize HRESULT
			// GetPreferredSize( const SIZE *pszDefault, SIZE *psz );
			[PreserveSig]
			HRESULT GetPreferredSize(in SIZE pszDefault, out SIZE psz);

			/// <summary>Obtains the bitmap and mask for the bitmap button item.</summary>
			/// <param name="bmWidth">Contains the width, in pixels, of the bitmap button item.</param>
			/// <param name="bmHeight">Contains the height, in pixels, of the bitmap button item.</param>
			/// <param name="dwFlags">Not currently used.</param>
			/// <param name="phbmp">Pointer to an <c>HBITMAP</c> value that receives the handle of the bitmap drawn for the bitmap item.</param>
			/// <param name="phbmpMask">
			/// <para>
			/// Pointer to an <c>HBITMAP</c> value that receives the handle of the mask bitmap. This is a monochrome bitmap that functions
			/// as a mask for phbmp. Each black pixel in this bitmap will cause the cooresponding pixel in phbmp to be displayed in its
			/// normal color. Each white pixel in this bitmap will cause the cooresponding pixel in phbmp to be displayed in the inverse of
			/// its normal color.
			/// </para>
			/// <para>
			/// To display the bitmap without color conversion, create a monochrome bitmap the same size as phbmp and set each pixel to
			/// black (RGB(0, 0, 0)).
			/// </para>
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-drawbitmap HRESULT DrawBitmap(
			// LONG bmWidth, LONG bmHeight, DWORD dwFlags, HBITMAP *phbmp, HBITMAP *phbmpMask );
			[PreserveSig]
			HRESULT DrawBitmap(int bmWidth, int bmHeight, [Optional] uint dwFlags, out HBITMAP phbmp, out HBITMAP phbmpMask);

			/// <summary>Obtains the text to be displayed for the bitmap button in the language bar.</summary>
			/// <param name="pbstrText">
			/// Pointer to a <c>BSTR</c> value that receives the string for the language bar item. This string must be allocated using the
			/// SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrText is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembitmapbutton-gettext HRESULT GetText( BSTR
			// *pbstrText );
			[PreserveSig]
			HRESULT GetText([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrText);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemButton</c> interface is implemented by a language bar button provider and used by the language bar manager
		/// to obtain information about a button item on the language bar.
		/// </para>
		/// <para>
		/// The language bar manager obtains an instance of this interface by calling QueryInterface on the ITfLangBarItem passed to ITfLangBarItemMgr::AddItem.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>A language bar button functions as a pushbutton, toggle button, or a menu on the language bar.</para>
		/// <para>
		/// If the button has the TF_LBI_STYLE_BTN_BUTTON style, the button acts as a pushbutton that the user can click with the mouse.
		/// When the user clicks the button, ITfLangBarItemButton::OnClick is called. ITfLangBarItemButton::InitMenu and
		/// ITfLangBarItemButton::OnMenuSelect are not used.
		/// </para>
		/// <para>
		/// If the button has the TF_LBI_STYLE_BTN_TOGGLE style, the button functions similar to a check box that the user can select or
		/// deselect with the mouse. When the user clicks the button, <c>ITfLangBarItemButton::OnClick</c> is called.
		/// <c>ITfLangBarItemButton::InitMenu</c> and <c>ITfLangBarItemButton::OnMenuSelect</c> are not used.
		/// </para>
		/// <para>
		/// If the button has the TF_LBI_STYLE_BTN_MENU style, the button acts like a top-level menu item. When the user clicks the button,
		/// <c>ITfLangBarItemButton::InitMenu</c> is called. If the user selects an item in the menu,
		/// <c>ITfLangBarItemButton::OnMenuSelect</c> is called. <c>ITfLangBarItemButton::OnClick</c> is not used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritembutton
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemButton")]
		[ComImport, Guid("28C7F1D0-DE25-11D2-AFDD-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfLangBarItemButton : ITfLangBarItem
		{
			/// <summary>Obtains information about the language bar item.</summary>
			/// <param name="pInfo">Pointer to a TF_LANGBARITEMINFO structure that receives the language bar item information.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pInfo is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getinfo HRESULT GetInfo(
			// TF_LANGBARITEMINFO *pInfo );
			[PreserveSig]
			new HRESULT GetInfo(out TF_LANGBARITEMINFO pInfo);

			/// <summary>Obtains the status of a language bar item.</summary>
			/// <param name="pdwStatus">
			/// Pointer to a <c>DWORD</c> that receives zero or a combination of one or more of the TF_LBI_STATUS_* values that indicate the
			/// current status of the item.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pdwStatus is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-getstatus HRESULT GetStatus( DWORD
			// *pdwStatus );
			[PreserveSig]
			new HRESULT GetStatus(out TF_LBI_STATUS pdwStatus);

			/// <summary>Called to show or hide the language bar item.</summary>
			/// <param name="fShow">
			/// Contains a <c>BOOL</c> that indicates if the item should be shown or hidden. Contains a nonzero value if the item should be
			/// shown or zero otherwise.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support this method.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The language bar item implementation should update its visible status by modifying the value returned from
			/// ITfLangBarItem::GetStatus to include or exclude the TF_LBI_STATUS_HIDDEN status flag. The implementation then prompts
			/// language bar to obtain the new status value by calling ITfLangBarItemSink::OnUpdate with TF_LBI_STATUS.
			/// </para>
			/// <para>
			/// This method is only useful when the item has the TF_LBI_STYLE_HIDDENSTATUSCONTROL style. Without this style, only the
			/// language bar can show or hide the item.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-show HRESULT Show( BOOL fShow );
			[PreserveSig]
			new HRESULT Show([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Obtains the text to be displayed in the tooltip for the language bar item.</summary>
			/// <param name="pbstrToolTip">
			/// Pointer to a <c>BSTR</c> value that receives the tooltip string for the language bar item. This string must be allocated
			/// using the SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrToolTip is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The language bar item does not support tooltip text.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritem-gettooltipstring HRESULT GetTooltipString(
			// BSTR *pbstrToolTip );
			[PreserveSig]
			new HRESULT GetTooltipString([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrToolTip);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_BUTTON style.</summary>
			/// <param name="click">Contains one of the TfLBIClick values that indicate which mouse button was used to click the button.</param>
			/// <param name="pt">
			/// Pointer to a Point structure that contains the position of the mouse cursor, in screen coordinates, at the
			/// time of the click event.
			/// </param>
			/// <param name="prcArea">Pointer to a RECT structure that contains the bounding rectangle, in screen coordinates, of the button.</param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembutton-onclick HRESULT OnClick( TfLBIClick
			// click, Point pt, const RECT *prcArea );
			[PreserveSig]
			HRESULT OnClick([In] TfLBIClick click, [In] POINT pt, in RECT prcArea);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_MENU style.</summary>
			/// <param name="pMenu">
			/// Pointer to an ITfMenu interface that the language bar button uses to add items to the menu that the language bar displays
			/// for the button.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembutton-initmenu HRESULT InitMenu( ITfMenu
			// *pMenu );
			[PreserveSig]
			HRESULT InitMenu([In] ITfMenu pMenu);

			/// <summary>This method is not used if the button item does not have the TF_LBI_STYLE_BTN_MENU style.</summary>
			/// <param name="wID">
			/// Specifies the identifier of the menu item selected. This is the value passed for the uId parameter in ITfMenu::AddMenuItem.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembutton-onmenuselect HRESULT OnMenuSelect(
			// UINT wID );
			[PreserveSig]
			HRESULT OnMenuSelect(uint wID);

			/// <summary>Obtains the icon to be displayed for the language bar button.</summary>
			/// <param name="phIcon">
			/// Pointer to an <c>HICON</c> value that receives the icon handle. Receives <c>NULL</c> if the button has no icon. The caller
			/// must free this icon when it is no longer required by calling <c>DestroyIcon</c>.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>phIcon is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The ideal size of the icon can be obtained by calling GetSystemMetrics(SM_CXSMICON) for the icon width and
			/// GetSystemMetrics(SM_CYSMICON) for the icon height.
			/// </para>
			/// <para>If the button has the TF_LBI_STYLE_TEXTCOLORICON style, the icon obtained by this method should be a monochrome icon.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembutton-geticon HRESULT GetIcon( HICON
			// *phIcon );
			[PreserveSig]
			HRESULT GetIcon(out HICON phIcon);

			/// <summary>Obtains the text to be displayed for the button in the language bar.</summary>
			/// <param name="pbstrText">
			/// Pointer to a <c>BSTR</c> that receives the string for the language bar item. This string must be allocated using the
			/// SysAllocString function. The caller must free this buffer when it is no longer required by calling SysFreeString.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>pbstrText is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>A memory allocation failure occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritembutton-gettext HRESULT GetText( BSTR
			// *pbstrText );
			[PreserveSig]
			HRESULT GetText([Out, MarshalAs(UnmanagedType.BStr)] out string pbstrText);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemMgr</c> interface is implemented by the language bar and used by a text service to manage items in the
		/// language bar.
		/// </para>
		/// <para>
		/// A text service obtains an instance of this interface by calling ITfThreadMgr::QueryInterface with IID_ITfLangBarItemMgr. An
		/// instance of this interface can also be created by calling CoCreateInstance with CLSID_TF_LangBarItemMgr.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritemmgr
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemMgr")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BA468C55-9956-4FB1-A59D-52A7DD7CC6AA"), CoClass(typeof(TF_LangBarItemMgr))]
		public interface ITfLangBarItemMgr
		{
			/// <summary>Obtains an enumerator that contains the items in the language bar.</summary>
			/// <returns>Pointer to an IEnumTfLangBarItems interface pointer that receives the enumerator object.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-enumitems HRESULT EnumItems(
			// IEnumTfLangBarItems **ppEnum );
			IEnumTfLangBarItems EnumItems();

			/// <summary>Obtains the ITfLangBarItem interface for an item in the language bar.</summary>
			/// <param name="rguid">
			/// GUID that identifies the item to obtain. This is the item GUID that the item supplies in ITfLangBarItem::GetInfo. This
			/// identifier can be a custom value or one of the predefined language bar items.
			/// </param>
			/// <returns>Pointer to an ITfLangBarItem interface pointer that receives the item interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-getitem HRESULT GetItem( REFGUID rguid,
			// ITfLangBarItem **ppItem );
			ITfLangBarItem GetItem(in Guid rguid);

			/// <summary>Adds an item to the language bar.</summary>
			/// <param name="punk">Pointer to the ITfLangBarItem object to add to the language bar.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-additem HRESULT AddItem( ITfLangBarItem
			// *punk );
			void AddItem([In] ITfLangBarItem punk);

			/// <summary>Removes an item from the language bar.</summary>
			/// <param name="punk">
			/// Pointer to the ITfLangBarItem object to remove from the language bar. The language bar will call ITfLangBarItem::GetInfo and
			/// use the item <c>GUID</c> to identify the item to remove.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-removeitem HRESULT RemoveItem(
			// ITfLangBarItem *punk );
			void RemoveItem([In] ITfLangBarItem punk);

			/// <summary>Installs a language bar item event sink for a language bar item.</summary>
			/// <param name="punk">Pointer to the ITfLangBarItemSink object to install.</param>
			/// <param name="pdwCookie">
			/// Pointer to a <c>DWORD</c> that receives an advise sink identification cookie. This cookie identifies the advise sink when it
			/// is removed with the ITfLangBarItemMgr::UnadviseItemSink or ITfLangBarItemMgr::UnadviseItemsSink method.
			/// </param>
			/// <param name="rguidItem">
			/// Contains the <c>GUID</c> that identifies the item to install the advise sink for. This is the item <c>GUID</c> that the item
			/// supplies in ITfLangBarItem::GetInfo. This can be a custom value or one of the predefined language bar items.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-adviseitemsink HRESULT AdviseItemSink(
			// ITfLangBarItemSink *punk, DWORD *pdwCookie, REFGUID rguidItem );
			void AdviseItemSink([In] ITfLangBarItemSink punk, out uint pdwCookie, in Guid rguidItem);

			/// <summary>Removes a language bar item event sink.</summary>
			/// <param name="dwCookie">
			/// Contains a DWORD that identifies the advise sink to remove. This cookie is obtained when the advise sink is installed with
			/// ITfLangBarItemMgr::AdviseItemSink or ITfLangBarItemMgr::AdviseItemsSink.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-unadviseitemsink HRESULT
			// UnadviseItemSink( DWORD dwCookie );
			void UnadviseItemSink(uint dwCookie);

			/// <summary>Obtains the bounding rectangle of an item on the language bar.</summary>
			/// <param name="dwThreadId">Not currently used. Must be zero.</param>
			/// <param name="rguid">
			/// Contains the <c>GUID</c> that identifies the item to obtain the bounding rectangle for. This is the item <c>GUID</c> that
			/// the item supplies in ITfLangBarItem::GetInfo. This can be a custom value or one of the predefined language bar items.
			/// </param>
			/// <returns>Pointer to a <c>RECT</c> structure that receives the bounding rectangle in screen coordinates.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-getitemfloatingrect HRESULT
			// GetItemFloatingRect( DWORD dwThreadId, REFGUID rguid, RECT *prc );
			RECT GetItemFloatingRect(uint dwThreadId, in Guid rguid);

			/// <summary>Obtains the status of one or more items on the language bar.</summary>
			/// <param name="ulCount">Specifies the number of items to obtain the status for.</param>
			/// <param name="prgguid">
			/// Pointer to an array of <c>GUID</c> s that identify the items obtain the status for. These are the item <c>GUID</c> s that
			/// the item supplies in ITfLangBarItem::GetInfo. This array must be at least ulCount elements in length.
			/// </param>
			/// <param name="pdwStatus">
			/// <para>
			/// Pointer to an array of <c>DWORD</c> values that receive the status of each item. Each element in this array receives zero or
			/// a combination of one or more of the TF_LBI_STATUS_* values. This array must be at least ulCount elements in length.
			/// </para>
			/// <para>
			/// The index of each status value cooresponds to the index of the item identifier in prgguid. For example, the element 0 in
			/// pdwStatus receives the for the item identified by element 0 of prgguid.
			/// </para>
			/// </param>
			/// <remarks>
			/// This method causes the ITfLangBarItem::GetStatus method of each language bar item identified by prgguid to be called.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-getitemsstatus HRESULT GetItemsStatus(
			// ULONG ulCount, const GUID *prgguid, DWORD *pdwStatus );
			void GetItemsStatus(uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] prgguid, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pdwStatus);

			/// <summary>Obtains the number of items in the language bar.</summary>
			/// <returns>Pointer to a <c>ULONG</c> that receives the number of items in the language bar.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-getitemnum HRESULT GetItemNum( ULONG
			// *pulCount );
			uint GetItemNum();

			/// <summary>Obtains the interface, information and status for one or more items in the language bar.</summary>
			/// <param name="ulCount">Specifies the number of items to obtain the status for.</param>
			/// <param name="ppItem">
			/// Pointer to an array of ITfLangBarItem interface pointers that receive the item interfaces. This array must be at least
			/// ulCount elements in length.
			/// </param>
			/// <param name="pInfo">
			/// [in, out] Pointer to an array of TF_LANGBARITEMINFO structures that receive the information for each item. This array must
			/// be at least ulCount elements in length.
			/// </param>
			/// <param name="pdwStatus">
			/// [in, out] Pointer to an array of <c>DWORD</c> values that receive the status of each item. Each element in this array
			/// receives zero or a combination of one or more of the TF_LBI_STATUS_* values. This array must be at least ulCount elements in length.
			/// </param>
			/// <param name="pcFetched">
			/// [in, out] Pointer to a ULONG that receives the number of items obtained by this method. This parameter can be <c>NULL</c> if
			/// this information is not required.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-getitems HRESULT GetItems( ULONG
			// ulCount, ITfLangBarItem **ppItem, TF_LANGBARITEMINFO *pInfo, DWORD *pdwStatus, ULONG *pcFetched );
			void GetItems(uint ulCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ITfLangBarItem[] ppItem, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TF_LANGBARITEMINFO[] pInfo,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] TF_LBI_STATUS[] pdwStatus, out uint pcFetched);

			/// <summary>Installs one or more language bar item event sinks for one or more language bar items.</summary>
			/// <param name="ulCount">Contains the number of advise sinks to install.</param>
			/// <param name="ppunk">
			/// Pointer to an array of ITfLangBarItemSink objects to install. This array must be at least ulCount elements in length.
			/// </param>
			/// <param name="pguidItem">
			/// Pointer to an array of <c>GUID</c> s that identify the items to install the advise sinks for. These are the item <c>GUID</c>
			/// s that the item supplies in ITfLangBarItem::GetInfo. This array must be at least ulCount elements in length.
			/// </param>
			/// <param name="pdwCookie">
			/// Pointer to an array of <c>DWORD</c> s that receive the cooresponding advise sink identification cookies. These cookies
			/// identify the advise sinks when they are removed with the ITfLangBarItemMgr::UnadviseItemSink or
			/// ITfLangBarItemMgr::UnadviseItemsSink method. This array must be at least ulCount elements in length.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-adviseitemssink HRESULT
			// AdviseItemsSink( ULONG ulCount, ITfLangBarItemSink **ppunk, const GUID *pguidItem, DWORD *pdwCookie );
			void AdviseItemsSink(uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ITfLangBarItemSink[] ppunk,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] pguidItem, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pdwCookie);

			/// <summary>Removes one or more language bar item event sinks.</summary>
			/// <param name="ulCount">Contains the number of advise sinks to install.</param>
			/// <param name="pdwCookie">
			/// Pointer to an array of <c>DWORD</c> s that identify the advise sinks to remove. These cookies are obtained when the advise
			/// sinks are installed with ITfLangBarItemMgr::AdviseItemSink or ITfLangBarItemMgr::AdviseItemsSink. This array must be at
			/// least ulCount elements in length.
			/// </param>
			/// <returns>This method has no return values.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemmgr-unadviseitemssink HRESULT
			// UnadviseItemsSink( ULONG ulCount, DWORD *pdwCookie );
			void UnadviseItemsSink(uint ulCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pdwCookie);
		}

		/// <summary>
		/// <para>
		/// The <c>ITfLangBarItemSink</c> interface is implemented by the language bar and used by a language bar item provider to notify
		/// the language bar of changes to a language bar item.
		/// </para>
		/// <para>
		/// The language bar item provider obtains an instance of this interface when the language bar calls the provider's
		/// ITfSource::AdviseSink with identifier IID_ITfLangBarItemSink.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbaritemsink
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarItemSink")]
		[ComImport, Guid("57DBE1A0-DE25-11D2-AFDD-00105A2799B5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfLangBarItemSink
		{
			/// <summary>Notifies the language bar of a change in a language bar item.</summary>
			/// <param name="dwFlags">
			/// Contains a set of flags that indicate changes in the language bar item. This can be a combination of one or more of the
			/// TF_LBI_* values.
			/// </param>
			/// <returns>
			/// <para>This method can return one of these values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The method was successful.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>An unspecified error occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// A language bar item should call this method when the internal state of the item changes. TSF will update the language bar
			/// user interface appropriately.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbaritemsink-onupdate HRESULT OnUpdate( DWORD
			// dwFlags );
			[PreserveSig]
			HRESULT OnUpdate([In] TF_LBI dwFlags);
		}

		/// <summary>
		/// The <c>ITfLangBarMgr</c> interface is implemented by the TSF manager and used by text services to manage event sink notification
		/// and configure floating language bar display settings. The interface ID is IID_ITfLangBarMgr.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itflangbarmgr
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfLangBarMgr")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("87955690-E627-11D2-8DDB-00105A2799B5"), CoClass(typeof(TF_LangBarMgr))]
		public interface ITfLangBarMgr
		{
			/// <summary>The <c>ITfLangBarMgr::AdviseEventSink</c> method advises a sink about a language bar event.</summary>
			/// <param name="pSink">Sink object to advise about the event.</param>
			/// <param name="hwnd">Reserved; must be <c>NULL</c>.</param>
			/// <param name="dwFlags">Reserved; must be 0.</param>
			/// <param name="pdwCookie">Pointer to an identifier for the connection.</param>
			/// <remarks>
			/// pdwCookie receives an identifier that should be passed to ITfLangBarMgr::UnadviseEventSink when the event sink is no longer required.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-adviseeventsink HRESULT AdviseEventSink(
			// ITfLangBarEventSink *pSink, HWND hwnd, DWORD dwFlags, DWORD *pdwCookie );
			void AdviseEventSink([In] ITfLangBarEventSink pSink, [In] HWND hwnd, [Optional] uint dwFlags, out uint pdwCookie);

			/// <summary>Uninstalls an advise event sink.</summary>
			/// <param name="dwCookie">
			/// A DWORD value that identifies the advise event sink to uninstall. This value is provided by a previous call to ITfLangBarMgr::AdviseEventSink.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-unadviseeventsink HRESULT
			// UnadviseEventSink( DWORD dwCookie );
			void UnadviseEventSink(uint dwCookie);

			/// <summary>Should not be used.</summary>
			/// <param name="dwThreadId"/>
			/// <param name="dwType"/>
			/// <param name="riid"/>
			/// <returns></returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-getthreadmarshalinterface HRESULT
			// GetThreadMarshalInterface( DWORD dwThreadId, DWORD dwType, REFIID riid, IUnknown **ppunk );
			[Obsolete("Should not be used.")]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetThreadMarshalInterface(uint dwThreadId, uint dwType, in Guid riid);

			/// <summary>Should not be used.</summary>
			/// <param name="dwThreadId"/>
			/// <param name="pplbi"/>
			/// <param name="pdwThreadid"/>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-getthreadlangbaritemmgr HRESULT
			// GetThreadLangBarItemMgr( DWORD dwThreadId, ITfLangBarItemMgr **pplbi, DWORD *pdwThreadid );
			[Obsolete("Should not be used.")]
			void GetThreadLangBarItemMgr(uint dwThreadId, out ITfLangBarItemMgr pplbi, out uint pdwThreadid);

			/// <summary>Should not be used.</summary>
			/// <param name="dwThreadId"/>
			/// <param name="ppaip"/>
			/// <param name="pdwThreadid"/>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-getinputprocessorprofiles HRESULT
			// GetInputProcessorProfiles( DWORD dwThreadId, ITfInputProcessorProfiles **ppaip, DWORD *pdwThreadid );
			[Obsolete("Should not be used.")]
			void GetInputProcessorProfiles(uint dwThreadId, out ITfInputProcessorProfiles ppaip, out uint pdwThreadid);

			/// <summary>Should not be used.</summary>
			/// <param name="pdwThreadId"/>
			/// <param name="fPrev"/>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-restorelastfocus HRESULT RestoreLastFocus(
			// DWORD *pdwThreadId, BOOL fPrev );
			[Obsolete("Should not be used.")]
			void RestoreLastFocus(out uint pdwThreadId, [In, MarshalAs(UnmanagedType.Bool)] bool fPrev);

			/// <summary>Should not be used.</summary>
			/// <param name="pSink"/>
			/// <param name="dwThreadId">Should not be used.</param>
			/// <param name="dwFlags">Should not be used.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-setmodalinput HRESULT SetModalInput(
			// ITfLangBarEventSink *pSink, DWORD dwThreadId, DWORD dwFlags );
			[Obsolete("Should not be used.")]
			void SetModalInput([In] ITfLangBarEventSink pSink, uint dwThreadId, uint dwFlags);

			/// <summary>Configures display settings for the floating language bar.</summary>
			/// <param name="dwFlags">
			/// <para>Specifies language bar display settings.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TF_SFT_SHOWNORMAL</term>
			/// <term>
			/// Display the language bar as a floating window. This constant cannot be combined with the TF_SFT_DOCK, TF_SFT_MINIMIZED,
			/// TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_DOCK</term>
			/// <term>
			/// Deprecated as of Windows Vista. Dock the language bar in its own task pane. This constant cannot be combined with the
			/// TF_SFT_SHOWNORMAL, TF_SFT_MINIMIZED, TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants. Available only on Windows XP.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_MINIMIZED</term>
			/// <term>
			/// Deprecated as of Windows Vista. Display the language bar as a single icon in the system tray. This constant cannot be
			/// combined with the TF_SFT_SHOWNORMAL, TF_SFT_DOCK, TF_SFT_HIDDEN, or TF_SFT_DESKBAND constants.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_HIDDEN</term>
			/// <term>
			/// Hide the language bar. This constant cannot be combined with the TF_SFT_SHOWNORMAL, TF_SFT_DOCK, TF_SFT_MINIMIZED, or
			/// TF_SFT_DESKBAND constants.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_NOTRANSPARENCY</term>
			/// <term>Make the language bar opaque.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_LOWTRANSPARENCY</term>
			/// <term>Make the language bar partially transparent. Available only on Windows 2000 or later.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_HIGHTRANSPARENCY</term>
			/// <term>Make the language bar highly transparent. Available only on Windows 2000 or later.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_LABELS</term>
			/// <term>Display text labels next to language bar icons.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_NOLABELS</term>
			/// <term>Hide language bar icon text labels.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_EXTRAICONSONMINIMIZED</term>
			/// <term>Display text service icons on the taskbar when the language bar is minimized.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_NOEXTRAICONSONMINIMIZED</term>
			/// <term>Hide text service icons on the taskbar when the language bar is minimized.</term>
			/// </item>
			/// <item>
			/// <term>TF_SFT_DESKBAND</term>
			/// <term>
			/// Dock the language bar in the system task bar. This constant cannot be combined with the TF_SFT_SHOWNORMAL, TF_SFT_DOCK,
			/// TF_SFT_MINIMIZED, or TF_SFT_HIDDEN constants. Available only on Windows XP.
			/// </term>
			/// </item>
			/// </list>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-showfloating HRESULT ShowFloating( DWORD
			// dwFlags );
			void ShowFloating([In] TF_SFT dwFlags);

			/// <summary>Obtains current language bar display settings.</summary>
			/// <returns>Indicates current language bar display settings. For a list of bitfield values, see ITfLangBarMgr::ShowFloating.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itflangbarmgr-getshowfloatingstatus HRESULT
			// GetShowFloatingStatus( DWORD *pdwFlags );
			TF_SFT GetShowFloatingStatus();
		}

		/// <summary>
		/// The <c>ITfMenu</c> interface is implemented by the language bar and used by a language bar button provider to add items to the
		/// menu that the language bar will display for the button.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itfmenu
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfMenu")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6F8A98E4-AAA0-4F15-8C5B-07E0DF0A3DD8")]
		public interface ITfMenu
		{
			/// <summary>Adds an item to the menu that the language bar will display for the button.</summary>
			/// <param name="uId">Contains the menu item identifier.</param>
			/// <param name="dwFlags">
			/// Contains zero or a combination of one or more of the TF_LBMENUF_* values that specify the type and state of the menu item.
			/// </param>
			/// <param name="hbmp">
			/// Contains the handle of the bitmap drawn for the menu item. If this is <c>NULL</c>, no bitmap is displayed for the menu item.
			/// </param>
			/// <param name="hbmpMask">
			/// <para>
			/// Contains the handle of the mask bitmap. This is a monochrome bitmap that functions as a mask for hbmp. Each black pixel in
			/// this bitmap will cause the corresponding pixel in hbmp to be displayed in its normal color. Each white pixel in this bitmap
			/// will cause the corresponding pixel in hbmp to be displayed in the inverse of its normal color.
			/// </para>
			/// <para>
			/// To have the bitmap displayed without any color conversion, create a monochrome bitmap the same size as hbmp and set each
			/// pixel to black (RGB(0, 0, 0)).
			/// </para>
			/// <para>If hbmp is <c>NULL</c>, this parameter is ignored.</para>
			/// </param>
			/// <param name="pch">
			/// Pointer to a <c>WCHAR</c> buffer that contains the text to be displayed for the menu item. The length of the text is
			/// specified by cch.
			/// </param>
			/// <param name="cch">Specifies the length, in <c>WCHAR</c>, of the menu item text in pch.</param>
			/// <param name="ppMenu">
			/// <para>
			/// [in, out] Pointer to an ITfMenu interface pointer that receives the submenu object. This parameter is not used and must be
			/// <c>NULL</c> if dwFlags does not contain <c>TF_LBMENUF_SUBMENU</c>.
			/// </para>
			/// <para>
			/// If the submenu item is successfully created, this parameter receives an ITfMenu object that the caller uses to add items to
			/// the submenu.
			/// </para>
			/// <para>
			/// If dwFlags contains <c>TF_LBMENUF_SUBMENU</c>, this value must be initialized to <c>NULL</c> prior to calling this method
			/// because, in most cases, this is a marshalled call. Not initializing this variable results in the marshaller attempting to
			/// access random memory.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfmenu-addmenuitem HRESULT AddMenuItem( UINT uId, DWORD
			// dwFlags, HBITMAP hbmp, HBITMAP hbmpMask, const WCHAR *pch, ULONG cch, ITfMenu **ppMenu );
			void AddMenuItem(uint uId, [In] TF_LBMENUF dwFlags, [In] HBITMAP hbmp, [In] HBITMAP hbmpMask, [MarshalAs(UnmanagedType.LPWStr)] string pch,
				uint cch, [MarshalAs(UnmanagedType.Interface), NullAllowed] out ITfMenu ppMenu);
		}

		/// <summary>
		/// The <c>ITfSystemDeviceTypeLangBarItem</c> interface is implemented by a system language bar item and used by an application or
		/// text service to control how the system item displays its icon. The application or text service obtains an instance of this
		/// interface by calling QueryInterface on the ITfLangBarItem object with IID_ITfSystemDeviceTypeLangBarItem.
		/// </summary>
		/// <remarks>Support for this interface is optional and must not be assumed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itfsystemdevicetypelangbaritem
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfSystemDeviceTypeLangBarItem")]
		[ComImport, Guid("45672EB9-9059-46A2-838D-4530355F6A77"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfSystemDeviceTypeLangBarItem
		{
			/// <summary>Modifies the type of icon displayed for a system language bar item.</summary>
			/// <param name="dwFlags">
			/// <para>Specifies how the system language bar item should display the icon. This can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The system language bar item should display a default icon for the item.</term>
			/// </item>
			/// <item>
			/// <term>TF_DTLBI_USEPROFILEICON</term>
			/// <term>The system language bar item should display the icon specified for the language profile.</term>
			/// </item>
			/// </list>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemdevicetypelangbaritem-seticonmode HRESULT
			// SetIconMode( DWORD dwFlags );
			void SetIconMode([In] TF_DTLBI dwFlags);

			/// <summary>Obtains the current icon display mode for a system language bar item.</summary>
			/// <returns>
			/// Pointer to a <c>DWORD</c> that receives the current icon display mode for a system language bar item. For more information
			/// about possible values, see the dwFlags parameter in ITfSystemDeviceTypeLangBarItem::SetIconMode.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemdevicetypelangbaritem-geticonmode HRESULT
			// GetIconMode( DWORD *pdwFlags );
			TF_DTLBI GetIconMode();
		}

		/// <summary>
		/// The <c>ITfSystemLangBarItem</c> interface is implemented by a system language bar menu and is used by a system language bar
		/// extension to modify the icon and/or tooltip string displayed for the menu. The extension can obtain an instance of this
		/// interface by by calling QueryInterface on the ITfLangBarItem object with IID_ITfSystemLangBarItem.
		/// </summary>
		/// <remarks>
		/// A system language bar menu is an object on the language bar that supports menu items added to it by third-partyextensions. The
		/// system item must support the ITfSource interface and support the IID_ITfSystemLangBarItemSink identifier in its
		/// ITfSource::AdviseSink implementation. The system item should also implement the <c>ITfSystemLangBarItem</c> interface. The
		/// system item uses the ITfSystemLangBarItemSink interface to enable the extension to add items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itfsystemlangbaritem
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfSystemLangBarItem")]
		[ComImport, Guid("1E13E9EC-6B33-4D4A-B5EB-8A92F029F356"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfSystemLangBarItem
		{
			/// <summary>Modifies the icon displayed for the system language bar menu.</summary>
			/// <param name="hIcon">Contains the handle to the new icon.</param>
			/// <remarks>
			/// In response to this method, the system language bar menu should call ITfLangBarItemSink::OnUpdate with TF_LBI_ICON to force
			/// the language bar to obtain the new icon.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritem-seticon HRESULT SetIcon( HICON hIcon );
			void SetIcon(in HICON hIcon);

			/// <summary>Modifies the tooltip text displayed for the system language bar menu.</summary>
			/// <param name="pchToolTip">A string that appears as a tooltip.</param>
			/// <param name="cch">Size, in characters, of the string.</param>
			/// <remarks>
			/// In response to this method, the system language bar menu should call ITfLangBarItemSink::OnUpdate with TF_LBI_TOOLTIP to
			/// force the language bar to obtain the new tooltip text.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritem-settooltipstring HRESULT
			// SetTooltipString( WCHAR *pchToolTip, ULONG cch );
			void SetTooltipString([In, MarshalAs(UnmanagedType.LPWStr)] string pchToolTip, uint cch);
		}

		/// <summary>
		/// The <c>ITfSystemLangBarItemSink</c> interface is implemented by a system language bar menu extension and used by a system
		/// language bar menu (host) to allow menu items to be added to an existing system language bar menu. The extension obtains an
		/// instance of this interface by calling QueryInterface on the ITfLangBarItem object with IID_ITfSystemLangBarItemSink. It can then
		/// pass the object to the host by calling ITfSource::AdviseSink.
		/// </summary>
		/// <remarks>
		/// A system language bar menu is an object on the language bar that supports menu items added to it by third-partyextensions. The
		/// system item must support the ITfSource interface and support the IID_ITfSystemLangBarItemSink identifier in its
		/// <c>ITfSource::AdviseSink</c> implementation. The system item should also implement the ITfSystemLangBarItem interface. The
		/// system item uses the <c>ITfSystemLangBarItemSink</c> interface to allow the extension to add its items.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itfsystemlangbaritemsink
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfSystemLangBarItemSink")]
		[ComImport, Guid("1449D9AB-13CF-4687-AA3E-8D8B18574396"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ITfSystemLangBarItemSink
		{
			/// <summary>Called to allow a system language bar item extension to add items to a system language bar menu.</summary>
			/// <param name="pMenu">
			/// Pointer to an ITfMenu interface that the system language bar item uses to add items to the system language bar menu.
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritemsink-initmenu HRESULT InitMenu(
			// ITfMenu *pMenu );
			void InitMenu([In] ITfMenu pMenu);

			/// <summary>Called when the user selects an item in the system menu added by the system language bar menu extension.</summary>
			/// <param name="wID">Specifies the identifier of the menu item selected. This is the value passed for uId in ITfMenu::AddMenuItem.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritemsink-onmenuselect HRESULT
			// OnMenuSelect( UINT wID );
			void OnMenuSelect(uint wID);
		}

		/// <summary>
		/// The <c>ITfSystemLangBarItemText</c> interface is implemented by a system language bar and is used by a system language bar
		/// extension to modify the description displayed for the menu. The extension can obtain an instance of this interface by calling
		/// the menu object QueryInterface method with IID_ITfSystemLangBarItem.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nn-ctfutb-itfsystemlangbaritemtext
		[PInvokeData("ctfutb.h", MSDNShortId = "NN:ctfutb.ITfSystemLangBarItemText")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("5C4CE0E5-BA49-4B52-AC6B-3B397B4F701F")]
		public interface ITfSystemLangBarItemText
		{
			/// <summary>
			/// The <c>ITfSystemLangBarItemText::SetItemText</c> method modifies the text displayed for the system language bar menu.
			/// </summary>
			/// <param name="pch">[in] A string that appears as a description.</param>
			/// <param name="cch">[in] Size, in characters, of the string.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritemtext-setitemtext HRESULT SetItemText(
			// const WCHAR *pch, ULONG cch );
			void SetItemText([In, MarshalAs(UnmanagedType.LPWStr)] string pch, uint cch);

			/// <summary>
			/// The <c>ITfSystemLangBarItemText::GetItemText</c> method obtains the text displayed for the system language bar menu.
			/// </summary>
			/// <returns>[out] A pointer to BSTR that contains the current description.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/nf-ctfutb-itfsystemlangbaritemtext-getitemtext HRESULT GetItemText(
			// BSTR *pbstrText );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetItemText();
		}

		/// <summary>The <c>TF_LANGBARITEMINFO</c> structure is used to hold information about a language bar item.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/ns-ctfutb-tf_langbariteminfo typedef struct TF_LANGBARITEMINFO { CLSID
		// clsidService; GUID guidItem; DWORD dwStyle; ULONG ulSort; WCHAR szDescription[32]; } TF_LANGBARITEMINFO;
		[PInvokeData("ctfutb.h", MSDNShortId = "NS:ctfutb.TF_LANGBARITEMINFO")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode), Guid("12A1D29F-A065-440C-9746-EB2002C8BD19")]
		public struct TF_LANGBARITEMINFO
		{
			/// <summary>
			/// Contains the <c>CLSID</c> of the text service that owns the language bar item. This can be CLSID_NULL if the item is not
			/// provided by a text service.
			/// </summary>
			public Guid clsidService;

			/// <summary>Contains a <c>GUID</c> value that identifies the language bar item.</summary>
			public Guid guidItem;

			/// <summary>Contains a combination of one or more of the TF_LBI_STYLE_* values.</summary>
			public TF_LBI_STYLE dwStyle;

			/// <summary>
			/// <para>
			/// Specifies the sort order of the language bar item, relative to other language bar items owned by the text service. A lower
			/// number indicates that the item will be displayed prior to an item with a higher sort number.
			/// </para>
			/// <para>
			/// This value is only used if <c>clsidService</c> identifies a registered text service. For more information about registering
			/// a text service, see ITfInputProcessorProfiles::Register.
			/// </para>
			/// </summary>
			public uint ulSort;

			/// <summary>
			/// Contains the description string for the item in Unicode format. The description string is displayed in the language bar
			/// options menu for menu items. This buffer can hold up to TF_LBI_DESC_MAXLEN characters.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string szDescription;
		}

		/// <summary>The <c>TF_LBBALLOONINFO</c> structure contains information about a language bar balloon item.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ctfutb/ns-ctfutb-tf_lbballooninfo typedef struct TF_LBBALLOONINFO {
		// TfLBBalloonStyle style; BSTR bstrText; } TF_LBBALLOONINFO;
		[PInvokeData("ctfutb.h", MSDNShortId = "NS:ctfutb.TF_LBBALLOONINFO")]
		[StructLayout(LayoutKind.Sequential, Pack = 4), Guid("37574483-5C50-4092-A55C-922E3A67E5B8")]
		public struct TF_LBBALLOONINFO
		{
			/// <summary>Contains one of the TfLBBalloonStyle values that specify the type of balloon to display.</summary>
			public TfLBBalloonStyle style;

			/// <summary>
			/// Contains a <c>BSTR</c> that contains the string for the balloon. This string must be allocated using the SysAllocString
			/// function. The caller free this buffer when it is no longer required by calling SysFreeString.
			/// </summary>
			[MarshalAs(UnmanagedType.BStr)]
			public string bstrText;
		}
	}
}