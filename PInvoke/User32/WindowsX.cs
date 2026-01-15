#pragma warning disable CS0612 // Type or member is obsolete
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using LPARAM = System.IntPtr;
using LRESULT = System.IntPtr;
using WPARAM = System.IntPtr;

namespace Vanara.PInvoke;

public static partial class User32
{
	private const int CTLCOLOR_BTN = 3;

	private const int CTLCOLOR_DLG = 4;

	private const int CTLCOLOR_EDIT = 1;

	private const int CTLCOLOR_LISTBOX = 2;

	private const int CTLCOLOR_MSGBOX = 0;

	private const int CTLCOLOR_SCROLLBAR = 5;

	private const int CTLCOLOR_STATIC = 6;

	public static void FORWARD_WM_ACTIVATE(HWND hwnd, uint state, HWND hwndActDeact, bool fMinimized, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
									=> fn(hwnd, (int)WindowMessage.WM_ACTIVATE, MAKELPARAM(state, (BOOL)fMinimized), (LPARAM)hwndActDeact);

	public static void FORWARD_WM_ACTIVATEAPP(HWND hwnd, bool fActivate, uint dwThreadId, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_ACTIVATEAPP, (WPARAM)(BOOL)fActivate, (LPARAM)dwThreadId);

	public static void FORWARD_WM_ASKCBFORMATNAME(HWND hwnd, int cchMax, string rgchName, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_ASKCBFORMATNAME, (WPARAM)cchMax, (LPARAM)new SafePSTR(rgchName));

	public static void FORWARD_WM_CANCELMODE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CANCELMODE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_CHANGECBCHAIN(HWND hwnd, HWND hwndRemove, HWND hwndNext, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CHANGECBCHAIN, (WPARAM)hwndRemove, (LPARAM)hwndNext);

	public static void FORWARD_WM_CHAR(HWND hwnd, char ch, ushort cRepeat, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CHAR, (WPARAM)ch, MAKELPARAM(cRepeat, 0));

	public static void FORWARD_WM_CHAR(HWND hwnd, char ch, WM_KEY_LPARAM lp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CHAR, (WPARAM)ch, lp);

	public static int FORWARD_WM_CHARTOITEM(HWND hwnd, uint ch, HWND hwndListBox, int iCaret, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (int)fn(hwnd, (int)WindowMessage.WM_CHARTOITEM, MAKELPARAM(ch, iCaret), (LPARAM)hwndListBox);

	public static void FORWARD_WM_CHILDACTIVATE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CHILDACTIVATE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_CLEAR(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CLEAR, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_CLOSE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_COMMAND(HWND hwnd, int id, HWND hwndCtl, uint codeNotify, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_COMMAND, MAKELPARAM(id, codeNotify), (LPARAM)hwndCtl);

	public static void FORWARD_WM_COMMNOTIFY(HWND hwnd, int cid, uint flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_COMMNOTIFY, (WPARAM)cid, MAKELPARAM(flags, 0));

	public static void FORWARD_WM_COMPACTING(HWND hwnd, uint compactRatio, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_COMPACTING, (WPARAM)compactRatio, IntPtr.Zero);

	public static int FORWARD_WM_COMPAREITEM(HWND hwnd, in COMPAREITEMSTRUCT lpCompareItem, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (int)fn(hwnd, (int)WindowMessage.WM_COMPAREITEM, (WPARAM)lpCompareItem.CtlID, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpCompareItem));

	public static void FORWARD_WM_CONTEXTMENU(HWND hwnd, HWND hwndContext, uint xPos, uint yPos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CONTEXTMENU, (WPARAM)hwndContext, MAKELPARAM(xPos, yPos));

	public static void FORWARD_WM_COPY(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_COPY, IntPtr.Zero, IntPtr.Zero);

	public static bool FORWARD_WM_COPYDATA(HWND hwnd, HWND hwndFrom, in COPYDATASTRUCT pcds, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_COPYDATA, (WPARAM)hwndFrom, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(pcds));

	public static bool FORWARD_WM_CREATE(HWND hwnd, in CREATESTRUCT lpCreateStruct, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_CREATE, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpCreateStruct));

	public static HBRUSH FORWARD_WM_CTLCOLORBTN(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORBTN, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLORDLG(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORDLG, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLOREDIT(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLOREDIT, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLORLISTBOX(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORLISTBOX, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLORMSGBOX(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORMSGBOX, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLORSCROLLBAR(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORSCROLLBAR, (WPARAM)hdc, (LPARAM)hwndChild);

	public static HBRUSH FORWARD_WM_CTLCOLORSTATIC(HWND hwnd, HDC hdc, HWND hwndChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HBRUSH)fn(hwnd, (int)WindowMessage.WM_CTLCOLORSTATIC, (WPARAM)hdc, (LPARAM)hwndChild);

	public static void FORWARD_WM_CUT(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_CUT, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_DEADCHAR(HWND hwnd, char ch, ushort cRepeat, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DEADCHAR, (WPARAM)ch, MAKELPARAM(cRepeat, 0));

	public static void FORWARD_WM_DEADCHAR(HWND hwnd, char ch, WM_KEY_LPARAM lp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DEADCHAR, (WPARAM)ch, lp);

	public static void FORWARD_WM_DELETEITEM(HWND hwnd, in DELETEITEMSTRUCT lpDeleteItem, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DELETEITEM, (WPARAM)lpDeleteItem.CtlID, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpDeleteItem));

	public static void FORWARD_WM_DESTROY(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DESTROY, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_DESTROYCLIPBOARD(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DESTROYCLIPBOARD, IntPtr.Zero, IntPtr.Zero);

	public static bool FORWARD_WM_DEVICECHANGE(HWND hwnd, uint uEvent, uint dwEventData, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_DEVICECHANGE, (WPARAM)uEvent, (LPARAM)dwEventData);

	public static void FORWARD_WM_DEVMODECHANGE(HWND hwnd, string lpszDeviceName, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DEVMODECHANGE, IntPtr.Zero, new SafePSTR(lpszDeviceName));

	public static void FORWARD_WM_DISPLAYCHANGE(HWND hwnd, uint bitsPerPixel, uint cxScreen, uint cyScreen, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DISPLAYCHANGE, (WPARAM)bitsPerPixel, MAKELPARAM(cxScreen, cyScreen));

	public static void FORWARD_WM_DRAWCLIPBOARD(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DRAWCLIPBOARD, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_DRAWITEM(HWND hwnd, in DRAWITEMSTRUCT lpDrawItem, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DRAWITEM, (WPARAM)lpDrawItem.CtlID, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpDrawItem));

	public static void FORWARD_WM_DROPFILES(HWND hwnd, HDROP hdrop, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_DROPFILES, (WPARAM)hdrop, IntPtr.Zero);

	public static void FORWARD_WM_ENABLE(HWND hwnd, bool fEnable, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_ENABLE, (WPARAM)(BOOL)fEnable, IntPtr.Zero);

	public static void FORWARD_WM_ENDSESSION(HWND hwnd, bool fEnding, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_ENDSESSION, (WPARAM)(BOOL)fEnding, IntPtr.Zero);

	public static void FORWARD_WM_ENTERIDLE(HWND hwnd, uint source, HWND hwndSource, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_ENTERIDLE, (WPARAM)source, (LPARAM)hwndSource);

	public static bool FORWARD_WM_ERASEBKGND(HWND hwnd, HDC hdc, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_ERASEBKGND, (WPARAM)hdc, IntPtr.Zero);

	public static void FORWARD_WM_FONTCHANGE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);

	public static DLGC FORWARD_WM_GETDLGCODE(HWND hwnd, in MSG? lpmsg, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (DLGC)fn(hwnd, (int)WindowMessage.WM_GETDLGCODE, lpmsg.HasValue ? lpmsg.Value.wParam : IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpmsg));

	public static HFONT FORWARD_WM_GETFONT(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HFONT)fn(hwnd, (int)WindowMessage.WM_GETFONT, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_GETMINMAXINFO(HWND hwnd, in MINMAXINFO lpMinMaxInfo, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_GETMINMAXINFO, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpMinMaxInfo));

	public static int FORWARD_WM_GETTEXT(HWND hwnd, int cchTextMax, string lpszText, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (int)fn(hwnd, (int)WindowMessage.WM_GETTEXT, (WPARAM)cchTextMax, new SafePSTR(lpszText));

	public static int FORWARD_WM_GETTEXTLENGTH(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (int)fn(hwnd, (int)WindowMessage.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_HOTKEY(HWND hwnd, int idHotKey, uint fuModifiers, uint vk, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_HOTKEY, (WPARAM)idHotKey, MAKELPARAM(fuModifiers, vk));

	public static void FORWARD_WM_HSCROLL(HWND hwnd, HWND hwndCtl, uint code, int pos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_HSCROLL, MAKELPARAM(code, pos), (LPARAM)hwndCtl);

	public static void FORWARD_WM_HSCROLLCLIPBOARD(HWND hwnd, HWND hwndCBViewer, uint code, int pos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_HSCROLLCLIPBOARD, (WPARAM)hwndCBViewer, MAKELPARAM(code, pos));

	public static bool FORWARD_WM_ICONERASEBKGND(HWND hwnd, HDC hdc, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_ICONERASEBKGND, (WPARAM)hdc, IntPtr.Zero);

	public static bool FORWARD_WM_INITDIALOG(HWND hwnd, HWND hwndFocus, LPARAM lParam, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_INITDIALOG, (WPARAM)hwndFocus, lParam);

	public static void FORWARD_WM_INITMENU(HWND hwnd, HMENU hMenu, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_INITMENU, (WPARAM)hMenu, IntPtr.Zero);

	public static void FORWARD_WM_INITMENUPOPUP(HWND hwnd, HMENU hMenu, uint item, bool fSystemMenu, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_INITMENUPOPUP, (WPARAM)hMenu, MAKELPARAM(item, (uint)(BOOL)fSystemMenu));

	public static void FORWARD_WM_KEYDOWN(HWND hwnd, VK vk, ushort cRepeat, ushort flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_KEYDOWN, (WPARAM)vk, MAKELPARAM(cRepeat, flags));

	public static void FORWARD_WM_KEYDOWN(HWND hwnd, VK vk, WM_KEY_LPARAM lp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_KEYDOWN, (WPARAM)vk, lp);

	public static void FORWARD_WM_KEYUP(HWND hwnd, uint vk, ushort cRepeat, ushort flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_KEYUP, (WPARAM)vk, MAKELPARAM(cRepeat, flags));

	public static void FORWARD_WM_KEYUP(HWND hwnd, uint vk, WM_KEY_LPARAM lp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_KEYUP, (WPARAM)vk, lp);

	public static void FORWARD_WM_KILLFOCUS(HWND hwnd, HWND hwndNewFocus, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_KILLFOCUS, (WPARAM)hwndNewFocus, IntPtr.Zero);

	public static void FORWARD_WM_LBUTTONDOWN(HWND hwnd, bool fDoubleClick, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_LBUTTONDBLCLK : (uint)WindowMessage.WM_LBUTTONDOWN, (WPARAM)state, pt);

	public static void FORWARD_WM_LBUTTONUP(HWND hwnd, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_LBUTTONUP, (WPARAM)state, pt);

	public static void FORWARD_WM_MBUTTONDOWN(HWND hwnd, bool fDoubleClick, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_MBUTTONDBLCLK : (uint)WindowMessage.WM_MBUTTONDOWN, (WPARAM)state, pt);

	public static void FORWARD_WM_MBUTTONUP(HWND hwnd, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MBUTTONUP, (WPARAM)state, pt);

	public static void FORWARD_WM_MDIACTIVATE(HWND hwnd, bool fActive, HWND hwndActivate, HWND hwndDeactivate, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MDIACTIVATE, (WPARAM)hwndDeactivate, (LPARAM)hwndActivate);

	public static bool FORWARD_WM_MDICASCADE(HWND hwnd, uint cmd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_MDICASCADE, (WPARAM)cmd, IntPtr.Zero);

	public static HWND FORWARD_WM_MDICREATE(HWND hwnd, in MDICREATESTRUCT lpmcs, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HWND)fn(hwnd, (int)WindowMessage.WM_MDICREATE, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpmcs));

	public static void FORWARD_WM_MDIDESTROY(HWND hwnd, HWND hwndDestroy, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MDIDESTROY, (WPARAM)hwndDestroy, IntPtr.Zero);

	public static HWND FORWARD_WM_MDIGETACTIVE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HWND)fn(hwnd, (int)WindowMessage.WM_MDIGETACTIVE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_MDIICONARRANGE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MDIICONARRANGE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_MDIMAXIMIZE(HWND hwnd, HWND hwndMaximize, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MDIMAXIMIZE, (WPARAM)hwndMaximize, IntPtr.Zero);

	public static HWND FORWARD_WM_MDINEXT(HWND hwnd, HWND hwndCur, bool fPrev, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HWND)fn(hwnd, (int)WindowMessage.WM_MDINEXT, (WPARAM)hwndCur, (LPARAM)(BOOL)fPrev);

	public static void FORWARD_WM_MDIRESTORE(HWND hwnd, HWND hwndRestore, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MDIRESTORE, (WPARAM)hwndRestore, IntPtr.Zero);

	public static HMENU FORWARD_WM_MDISETMENU(HWND hwnd, bool fRefresh, HMENU hmenuFrame, HMENU hmenuWindow, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HMENU)fn(hwnd, (int)WindowMessage.WM_MDISETMENU, (WPARAM)(fRefresh ? hmenuFrame : HMENU.NULL), (LPARAM)hmenuWindow);

	public static bool FORWARD_WM_MDITILE(HWND hwnd, uint cmd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_MDITILE, (WPARAM)cmd, IntPtr.Zero);

	public static void FORWARD_WM_MEASUREITEM(HWND hwnd, in MEASUREITEMSTRUCT lpMeasureItem, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MEASUREITEM, (WPARAM)lpMeasureItem.CtlID, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpMeasureItem));

	public static WM_MENUCHAR_RETURN FORWARD_WM_MENUCHAR(HWND hwnd, char ch, MenuFlags flags, HMENU hmenu, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (WM_MENUCHAR_RETURN)fn(hwnd, (int)WindowMessage.WM_MENUCHAR, MAKELPARAM(flags, ch), (LPARAM)hmenu);

	public static void FORWARD_WM_MENUSELECT(HWND hwnd, HMENU hmenu, int item, HMENU hmenuPopup, MenuFlags flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MENUSELECT, MAKELPARAM(item, flags), (LPARAM)((hmenu != HMENU.NULL) ? hmenu : hmenuPopup));

	public static MouseActivateCode FORWARD_WM_MOUSEACTIVATE(HWND hwnd, HWND hwndTopLevel, HitTestValues codeHitTest, uint msg, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (MouseActivateCode)fn(hwnd, (int)WindowMessage.WM_MOUSEACTIVATE, (WPARAM)hwndTopLevel, MAKELPARAM(codeHitTest, msg));

	public static void FORWARD_WM_MOUSEMOVE(HWND hwnd, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MOUSEMOVE, (WPARAM)state, pt);

	public static void FORWARD_WM_MOUSEWHEEL(HWND hwnd, short distance, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MOUSEWHEEL, new MOUSEWHEEL(distance, state), pt);

	public static void FORWARD_WM_MOVE(HWND hwnd, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_MOVE, IntPtr.Zero, pt);

	public static bool FORWARD_WM_NCACTIVATE(HWND hwnd, bool fActive, HWND hwndActDeact, bool fMinimized, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_NCACTIVATE, (WPARAM)(BOOL)fActive, IntPtr.Zero);

	public static WVR FORWARD_WM_NCCALCSIZE(HWND hwnd, bool fCalcValidRects, in NCCALCSIZE_PARAMS lpcsp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (WVR)fn(hwnd, (int)WindowMessage.WM_NCCALCSIZE, (WPARAM)(BOOL)fCalcValidRects, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpcsp));

	public static bool FORWARD_WM_NCCREATE(HWND hwnd, in CREATESTRUCT lpCreateStruct, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_NCCREATE, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpCreateStruct));

	public static void FORWARD_WM_NCDESTROY(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCDESTROY, IntPtr.Zero, IntPtr.Zero);

	public static HitTestValues FORWARD_WM_NCHITTEST(HWND hwnd, short x, short y, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HitTestValues)fn(hwnd, (int)WindowMessage.WM_NCHITTEST, IntPtr.Zero, new POINTS(x, y));

	public static void FORWARD_WM_NCLBUTTONDOWN(HWND hwnd, bool fDoubleClick, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_NCLBUTTONDBLCLK : (uint)WindowMessage.WM_NCLBUTTONDOWN, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCLBUTTONUP(HWND hwnd, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCLBUTTONUP, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCMBUTTONDOWN(HWND hwnd, bool fDoubleClick, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_NCMBUTTONDBLCLK : (uint)WindowMessage.WM_NCMBUTTONDOWN, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCMBUTTONUP(HWND hwnd, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCMBUTTONUP, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCMOUSEMOVE(HWND hwnd, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCMOUSEMOVE, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCPAINT(HWND hwnd, HRGN hrgn, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCPAINT, (WPARAM)hrgn, IntPtr.Zero);

	public static void FORWARD_WM_NCRBUTTONDOWN(HWND hwnd, bool fDoubleClick, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_NCRBUTTONDBLCLK : (uint)WindowMessage.WM_NCRBUTTONDOWN, (WPARAM)codeHitTest, new POINTS(x, y));

	public static void FORWARD_WM_NCRBUTTONUP(HWND hwnd, short x, short y, HitTestValues codeHitTest, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_NCRBUTTONUP, (WPARAM)codeHitTest, new POINTS(x, y));

	public static HWND FORWARD_WM_NEXTDLGCTL(HWND hwnd, HWND hwndSetFocus, bool fNext, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HWND)fn(hwnd, (int)WindowMessage.WM_NEXTDLGCTL, (WPARAM)hwndSetFocus, (LPARAM)(BOOL)fNext);

	public static void FORWARD_WM_PAINT(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PAINT, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_PAINTCLIPBOARD(HWND hwnd, HWND hwndCBViewer, in PAINTSTRUCT lpPaintStruct, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PAINTCLIPBOARD, (WPARAM)hwndCBViewer, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpPaintStruct));

	public static void FORWARD_WM_PALETTECHANGED(HWND hwnd, HWND hwndPaletteChange, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PALETTECHANGED, (WPARAM)hwndPaletteChange, IntPtr.Zero);

	public static void FORWARD_WM_PALETTEISCHANGING(HWND hwnd, HWND hwndPaletteChange, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PALETTEISCHANGING, (WPARAM)hwndPaletteChange, IntPtr.Zero);

	public static void FORWARD_WM_PARENTNOTIFY(HWND hwnd, uint msg, HWND hwndChild, int idChild, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PARENTNOTIFY, MAKELPARAM(msg, idChild), (LPARAM)hwndChild);

	public static void FORWARD_WM_PASTE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_PASTE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_POWER(HWND hwnd, int code, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_POWER, (WPARAM)code, IntPtr.Zero);

	public static HICON FORWARD_WM_QUERYDRAGICON(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HICON)fn(hwnd, (int)WindowMessage.WM_QUERYDRAGICON, IntPtr.Zero, IntPtr.Zero);

	public static bool FORWARD_WM_QUERYENDSESSION(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_QUERYENDSESSION, IntPtr.Zero, IntPtr.Zero);

	public static bool FORWARD_WM_QUERYNEWPALETTE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_QUERYNEWPALETTE, IntPtr.Zero, IntPtr.Zero);

	public static bool FORWARD_WM_QUERYOPEN(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_QUERYOPEN, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_QUEUESYNC(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_QUEUESYNC, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_QUIT(HWND hwnd, int exitCode, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_QUIT, (WPARAM)exitCode, IntPtr.Zero);

	public static void FORWARD_WM_RBUTTONDOWN(HWND hwnd, bool fDoubleClick, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, fDoubleClick ? (uint)WindowMessage.WM_RBUTTONDBLCLK : (uint)WindowMessage.WM_RBUTTONDOWN, (WPARAM)state, pt);

	public static void FORWARD_WM_RBUTTONUP(HWND hwnd, MouseButtonState state, POINTS pt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_RBUTTONUP, (WPARAM)state, pt);

	public static void FORWARD_WM_RENDERALLFORMATS(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_RENDERALLFORMATS, IntPtr.Zero, IntPtr.Zero);

	public static HANDLE FORWARD_WM_RENDERFORMAT(HWND hwnd, uint fmt, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (HANDLE)fn(hwnd, (int)WindowMessage.WM_RENDERFORMAT, (WPARAM)fmt, IntPtr.Zero);

	public static bool FORWARD_WM_SETCURSOR(HWND hwnd, HWND hwndCursor, HitTestValues codeHitTest, uint msg, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_SETCURSOR, (WPARAM)hwndCursor, MAKELPARAM(codeHitTest, msg));

	public static void FORWARD_WM_SETFOCUS(HWND hwnd, HWND hwndOldFocus, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SETFOCUS, (WPARAM)hwndOldFocus, IntPtr.Zero);

	public static void FORWARD_WM_SETFONT(HWND hwnd, HFONT hfont, bool fRedraw, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SETFONT, (WPARAM)hfont, (LPARAM)(BOOL)fRedraw);

	public static void FORWARD_WM_SETREDRAW(HWND hwnd, bool fRedraw, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SETREDRAW, (WPARAM)(BOOL)fRedraw, IntPtr.Zero);

	public static void FORWARD_WM_SETTEXT(HWND hwnd, string lpszText, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SETTEXT, IntPtr.Zero, new SafePSTR(lpszText));

	public static void FORWARD_WM_SHOWWINDOW(HWND hwnd, bool fShow, uint status, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SHOWWINDOW, (WPARAM)(BOOL)fShow, (LPARAM)status);

	public static void FORWARD_WM_SIZE(HWND hwnd, WM_SIZE_WPARAM state, SIZES sz, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SIZE, (WPARAM)state, sz);

	public static void FORWARD_WM_SIZECLIPBOARD(HWND hwnd, HWND hwndCBViewer, in RECT lprc, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SIZECLIPBOARD, (WPARAM)hwndCBViewer, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lprc));

	public static void FORWARD_WM_SPOOLERSTATUS(HWND hwnd, uint status, ushort cJobInQueue, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SPOOLERSTATUS, (WPARAM)status, MAKELPARAM(cJobInQueue, 0));

	public static void FORWARD_WM_SYSCHAR(HWND hwnd, char ch, ushort cRepeat, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSCHAR, (WPARAM)ch, MAKELPARAM(cRepeat, 0));

	public static void FORWARD_WM_SYSCHAR(HWND hwnd, char ch, WM_KEY_LPARAM klp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSCHAR, (WPARAM)ch, klp);

	public static void FORWARD_WM_SYSCOLORCHANGE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSCOLORCHANGE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_SYSCOMMAND(HWND hwnd, uint cmd, short x, short y, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSCOMMAND, (WPARAM)cmd, MAKELPARAM(x, y));

	public static void FORWARD_WM_SYSDEADCHAR(HWND hwnd, char ch, ushort cRepeat, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSDEADCHAR, (WPARAM)ch, MAKELPARAM(cRepeat, 0));

	public static void FORWARD_WM_SYSDEADCHAR(HWND hwnd, char ch, WM_KEY_LPARAM klp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSDEADCHAR, (WPARAM)ch, klp);

	public static void FORWARD_WM_SYSKEYDOWN(HWND hwnd, VK vk, ushort cRepeat, ushort flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSKEYDOWN, (WPARAM)vk, MAKELPARAM(cRepeat, flags));

	public static void FORWARD_WM_SYSKEYDOWN(HWND hwnd, VK vk, WM_KEY_LPARAM klp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSKEYDOWN, (WPARAM)vk, klp);

	public static void FORWARD_WM_SYSKEYUP(HWND hwnd, VK vk, WM_KEY_LPARAM klp, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSKEYUP, (WPARAM)vk, klp);

	public static void FORWARD_WM_SYSKEYUP(HWND hwnd, VK vk, ushort cRepeat, ushort flags, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_SYSKEYUP, (WPARAM)vk, MAKELPARAM(cRepeat, flags));

	public static void FORWARD_WM_SYSTEMERROR(HWND hwnd, int errCode, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
	{ }

	public static void FORWARD_WM_TIMECHANGE(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_TIMECHANGE, IntPtr.Zero, IntPtr.Zero);

	public static void FORWARD_WM_TIMER(HWND hwnd, uint id, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_TIMER, (WPARAM)id, IntPtr.Zero);

	public static void FORWARD_WM_UNDO(HWND hwnd, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_UNDO, IntPtr.Zero, IntPtr.Zero);

	public static int FORWARD_WM_VKEYTOITEM(HWND hwnd, uint vk, HWND hwndListBox, int iCaret, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (int)fn(hwnd, (int)WindowMessage.WM_VKEYTOITEM, MAKELPARAM(vk, iCaret), (LPARAM)hwndListBox);

	public static void FORWARD_WM_VSCROLL(HWND hwnd, HWND hwndCtl, uint code, int pos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_VSCROLL, MAKELPARAM((uint)(int)code, (uint)pos), (LPARAM)hwndCtl);

	public static void FORWARD_WM_VSCROLLCLIPBOARD(HWND hwnd, HWND hwndCBViewer, uint code, int pos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_VSCROLLCLIPBOARD, (WPARAM)hwndCBViewer, MAKELPARAM(code, pos));

	public static void FORWARD_WM_WINDOWPOSCHANGED(HWND hwnd, in WINDOWPOS lpwpos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_WINDOWPOSCHANGED, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpwpos));

	public static bool FORWARD_WM_WINDOWPOSCHANGING(HWND hwnd, in WINDOWPOS lpwpos, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> (BOOL)fn(hwnd, (int)WindowMessage.WM_WINDOWPOSCHANGING, IntPtr.Zero, (LPARAM)SafeCoTaskMemHandle.CreateFromStructure(lpwpos));

	public static void FORWARD_WM_WININICHANGE(HWND hwnd, string lpszSectionName, Func<HWND, uint, WPARAM, LPARAM, LRESULT> fn)
		=> fn(hwnd, (int)WindowMessage.WM_WININICHANGE, IntPtr.Zero, new SafePSTR(lpszSectionName));

	public static (WPARAM wp, LPARAM lp) GET_EM_LINESCROLL_MPS(WPARAM vert, LPARAM horz) => (horz, vert);

	public static LPARAM GET_EM_SETSEL_END(WPARAM wp, LPARAM lp) => lp;

	public static (WPARAM wp, LPARAM lp) GET_EM_SETSEL_MPS(int iStart, LPARAM iEnd) => ((WPARAM)iStart, iEnd);

	public static int GET_EM_SETSEL_START(WPARAM wp, LPARAM lp) => (int)wp;

	public static LPARAM GET_LPARAM(WPARAM wp, LPARAM lp) => lp;

	public static bool GET_WM_ACTIVATE_FMINIMIZED(WPARAM wp, LPARAM lp) => (BOOL)(uint)HIWORD(wp);

	public static HWND GET_WM_ACTIVATE_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_ACTIVATE_MPS(ushort s, BOOL fmin, HWND hwnd) => (MAKELPARAM(s, fmin), (LPARAM)hwnd);

	public static ushort GET_WM_ACTIVATE_STATE(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static HWND GET_WM_CHANGECBCHAIN_HWNDNEXT(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static ushort GET_WM_CHARTOITEM_CHAR(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static HWND GET_WM_CHARTOITEM_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_CHARTOITEM_MPS(ushort ch, ushort pos, HWND hwnd) => (MAKELPARAM(pos, ch), (LPARAM)hwnd);

	public static ushort GET_WM_CHARTOITEM_POS(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static ushort GET_WM_COMMAND_CMD(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static HWND GET_WM_COMMAND_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static ushort GET_WM_COMMAND_ID(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static (WPARAM wp, LPARAM lp) GET_WM_COMMAND_MPS(ushort id, HWND hwnd, ushort cmd) => (MAKELPARAM(id, cmd), (LPARAM)hwnd);

	public static HDC GET_WM_CTLCOLOR_HDC(WPARAM wp, LPARAM lp, uint msg) => (HDC)wp;

	public static HWND GET_WM_CTLCOLOR_HWND(WPARAM wp, LPARAM lp, uint msg) => (HWND)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_CTLCOLOR_MPS(HDC hdc, HWND hwnd, ushort type) => ((WPARAM)hdc, (LPARAM)hwnd);

	public static ushort GET_WM_CTLCOLOR_MSG(ushort type) => (ushort)((uint)WindowMessage.WM_CTLCOLORMSGBOX + type);

	public static ushort GET_WM_CTLCOLOR_TYPE(WPARAM wp, LPARAM lp, uint msg) => (ushort)(msg - (uint)WindowMessage.WM_CTLCOLORMSGBOX);

	public static ushort GET_WM_HSCROLL_CODE(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static HWND GET_WM_HSCROLL_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_HSCROLL_MPS(ushort code, ushort pos, HWND hwnd) => (MAKELPARAM(code, pos), (LPARAM)hwnd);

	public static ushort GET_WM_HSCROLL_POS(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static bool GET_WM_MDIACTIVATE_FACTIVATE(HWND hwnd, WPARAM wp, LPARAM lp) => lp == (LPARAM)hwnd;

	public static HWND GET_WM_MDIACTIVATE_HWNDACTIVATE(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static HWND GET_WM_MDIACTIVATE_HWNDDEACT(WPARAM wp, LPARAM lp) => (HWND)wp;

	public static (WPARAM wp, LPARAM lp) GET_WM_MDIACTIVATE_MPS(BOOL f, HWND hwndD, HWND hwndA) => ((WPARAM)hwndA, IntPtr.Zero);

	public static (WPARAM wp, LPARAM lp) GET_WM_MDISETMENU_MPS(HMENU hmenuF, HMENU hmenuW) => ((WPARAM)hmenuF, (LPARAM)hmenuW);

	public static char GET_WM_MENUCHAR_CHAR(WPARAM wp, LPARAM lp) => WPARAM_TO_CHARCODE(wp);

	public static bool GET_WM_MENUCHAR_FMENU(WPARAM wp, LPARAM lp) => (BOOL)(uint)HIWORD(wp);

	public static HMENU GET_WM_MENUCHAR_HMENU(WPARAM wp, LPARAM lp) => (HMENU)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_MENUCHAR_MPS(ushort ch, HMENU hmenu, BOOL f) => (MAKELPARAM(ch, f), (LPARAM)hmenu);

	public static ushort GET_WM_MENUSELECT_CMD(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static uint GET_WM_MENUSELECT_FLAGS(WPARAM wp, LPARAM lp) => (uint)(int)(short)HIWORD(wp);

	public static HMENU GET_WM_MENUSELECT_HMENU(WPARAM wp, LPARAM lp) => (HMENU)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_MENUSELECT_MPS(ushort cmd, uint f, HMENU hmenu) => (MAKELPARAM(cmd, f), (LPARAM)hmenu);

	public static HWND GET_WM_PARENTNOTIFY_HWNDCHILD(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static ushort GET_WM_PARENTNOTIFY_ID(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static (WPARAM wp, LPARAM lp) GET_WM_PARENTNOTIFY_MPS(ushort msg, ushort id, HWND hwnd) => (MAKELPARAM(id, msg), (LPARAM)hwnd);

	public static ushort GET_WM_PARENTNOTIFY_MSG(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static int GET_WM_PARENTNOTIFY_X(WPARAM wp, LPARAM lp) => (short)LOWORD(lp);

	public static int GET_WM_PARENTNOTIFY_Y(WPARAM wp, LPARAM lp) => (short)HIWORD(lp);

	public static (WPARAM wp, LPARAM lp) GET_WM_PARENTNOTIFY2_MPS(ushort msg, short x, short y) => (MAKELPARAM(0, msg), MAKELPARAM(x, y));

	public static int GET_WM_VKEYTOITEM_CODE(WPARAM wp, LPARAM lp) => (short)LOWORD(wp);

	public static HWND GET_WM_VKEYTOITEM_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static ushort GET_WM_VKEYTOITEM_ITEM(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static (WPARAM wp, LPARAM lp) GET_WM_VKEYTOITEM_MPS(int code, ushort item, HWND hwnd) => (MAKELPARAM(item, code), (LPARAM)hwnd);

	public static ushort GET_WM_VSCROLL_CODE(WPARAM wp, LPARAM lp) => LOWORD(wp);

	public static HWND GET_WM_VSCROLL_HWND(WPARAM wp, LPARAM lp) => (HWND)lp;

	public static (WPARAM wp, LPARAM lp) GET_WM_VSCROLL_MPS(ushort code, ushort pos, HWND hwnd) => (MAKELPARAM(code, pos), (LPARAM)hwnd);

	public static ushort GET_WM_VSCROLL_POS(WPARAM wp, LPARAM lp) => HIWORD(wp);

	public static WPARAM GET_WPARAM(WPARAM wp, LPARAM lp) => wp;

	public static LRESULT HANDLE_WM_ACTIVATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, HWND, bool> fn)
	{
		fn(hwnd, LOWORD(wParam), (HWND)lParam, (BOOL)(uint)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ACTIVATEAPP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, uint> fn)
	{
		fn(hwnd, (BOOL)wParam, (uint)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ASKCBFORMATNAME(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int, string?> fn)
	{
		fn(hwnd, (int)wParam, StringHelper.GetString(lParam, CharSet.Ansi));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CANCELMODE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CHANGECBCHAIN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam, (HWND)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CHAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, char, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, WPARAM_TO_CHARCODE(wParam), new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CHARTOITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, HWND, int, int> fn)
		=> (LRESULT)(uint)fn(hwnd, LOWORD(wParam), (HWND)lParam, (short)HIWORD(wParam));

	public static LRESULT HANDLE_WM_CHILDACTIVATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CLEAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CLOSE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COMMAND(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int, HWND, uint> fn)
	{
		fn(hwnd, LOWORD(wParam), (HWND)lParam, HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COMMNOTIFY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int, uint> fn)
	{
		fn(hwnd, (int)wParam, LOWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COMPACTING(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint> fn)
	{
		fn(hwnd, (uint)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COMPAREITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, COMPAREITEMSTRUCT, int> fn)
	{ unsafe { return (LRESULT)(uint)fn(hwnd, *(COMPAREITEMSTRUCT*)(void*)lParam); } }

	public static LRESULT HANDLE_WM_CONTEXTMENU(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, uint, uint> fn)
	{
		fn(hwnd, (HWND)wParam, (uint)(int)(short)LOWORD(lParam), (uint)(int)(short)HIWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COPY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_COPYDATA(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, COPYDATASTRUCT, bool> fn)
	{
		unsafe { fn(hwnd, (HWND)wParam, *(COPYDATASTRUCT*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_CREATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, CREATESTRUCT, bool> fn)
	{ unsafe { return (BOOL)fn(hwnd, lParam.ToStructure<CREATESTRUCT>()); } }

	public static LRESULT HANDLE_WM_CTLCOLORBTN(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_BTN);

	public static LRESULT HANDLE_WM_CTLCOLORDLG(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_DLG);

	public static LRESULT HANDLE_WM_CTLCOLOREDIT(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_EDIT);

	public static LRESULT HANDLE_WM_CTLCOLORLISTBOX(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_LISTBOX);

	public static LRESULT HANDLE_WM_CTLCOLORMSGBOX(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_MSGBOX);

	public static LRESULT HANDLE_WM_CTLCOLORSCROLLBAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_SCROLLBAR);

	public static LRESULT HANDLE_WM_CTLCOLORSTATIC(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, HWND, int, HBRUSH> fn)
		=> (IntPtr)fn(hwnd, (HDC)wParam, (HWND)lParam, CTLCOLOR_STATIC);

	public static LRESULT HANDLE_WM_CUT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DEADCHAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, char, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, WPARAM_TO_CHARCODE(wParam), new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DELETEITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, DELETEITEMSTRUCT> fn)
	{
		unsafe { fn(hwnd, *(DELETEITEMSTRUCT*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DESTROY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DESTROYCLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DEVICECHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, uint, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (uint)wParam, (uint)lParam);

	public static LRESULT HANDLE_WM_DEVMODECHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, string?> fn)
	{
		fn(hwnd, StringHelper.GetString(lParam, CharSet.Ansi));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DISPLAYCHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, uint, uint> fn)
	{
		fn(hwnd, (uint)wParam, LOWORD(lParam), HIWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DRAWCLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DRAWITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, DRAWITEMSTRUCT> fn)
	{
		unsafe { fn(hwnd, *(DRAWITEMSTRUCT*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_DROPFILES(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HDROP> fn)
	{
		fn(hwnd, (HDROP)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ENABLE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool> fn)
	{
		fn(hwnd, (BOOL)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ENDSESSION(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool> fn)
	{
		fn(hwnd, (BOOL)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ENTERIDLE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, HWND> fn)
	{
		fn(hwnd, (uint)wParam, (HWND)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ERASEBKGND(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (HDC)wParam);

	public static LRESULT HANDLE_WM_FONTCHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_GETDLGCODE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, MSG, uint> fn)
	{ unsafe { return (LRESULT)fn(hwnd, *(MSG*)(void*)lParam); } }

	public static LRESULT HANDLE_WM_GETFONT(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HFONT> fn)
		=> (IntPtr)fn(hwnd);

	public static LRESULT HANDLE_WM_GETMINMAXINFO(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MINMAXINFO> fn)
	{
		unsafe { fn(hwnd, *(MINMAXINFO*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_GETTEXT(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, int, string?, int> fn)
		=> (LRESULT)(uint)fn(hwnd, (int)wParam, StringHelper.GetString(lParam, CharSet.Ansi));

	public static LRESULT HANDLE_WM_GETTEXTLENGTH(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, int> fn)
		=> (LRESULT)(uint)fn(hwnd);

	public static LRESULT HANDLE_WM_HOTKEY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int, uint, uint> fn)
	{
		fn(hwnd, (int)wParam, LOWORD(lParam), HIWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_HSCROLL(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, SBCMD, int> fn)
	{
		fn(hwnd, (HWND)lParam, (SBCMD)LOWORD(wParam), (short)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_HSCROLLCLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, SBCMD, int> fn)
	{
		fn(hwnd, (HWND)lParam, (SBCMD)LOWORD(wParam), (short)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_ICONERASEBKGND(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HDC, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (HDC)wParam);

	public static LRESULT HANDLE_WM_INITDIALOG(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, LPARAM, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (HWND)wParam, lParam);

	public static LRESULT HANDLE_WM_INITMENU(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HMENU> fn)
	{
		fn(hwnd, (HMENU)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_INITMENUPOPUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HMENU, uint, bool> fn)
	{
		fn(hwnd, (HMENU)wParam, LOWORD(lParam), (BOOL)(uint)HIWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_KEYDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, VK, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, (VK)(int)wParam, lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_KEYUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, VK, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, (VK)(int)wParam, lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_KILLFOCUS(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_LBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, true, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_LBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, false, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_LBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, true, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, false, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDIACTIVATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, HWND, HWND> fn)
	{
		fn(hwnd, lParam == (LPARAM)hwnd, (HWND)lParam, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDICASCADE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (uint)wParam);

	public static LRESULT HANDLE_WM_MDICREATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, MDICREATESTRUCT, HWND> fn)
	{ unsafe { return (LRESULT)fn(hwnd, lParam.ToStructure<MDICREATESTRUCT>()); } }

	public static LRESULT HANDLE_WM_MDIDESTROY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDIGETACTIVE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND> fn)
		=> (IntPtr)fn(hwnd);

	public static LRESULT HANDLE_WM_MDIICONARRANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDIMAXIMIZE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDINEXT(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, bool, HWND> fn)
		=> (LRESULT)fn(hwnd, (HWND)wParam, (BOOL)lParam);

	public static LRESULT HANDLE_WM_MDIRESTORE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MDISETMENU(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool, HMENU, HMENU, HMENU> fn)
		=> (IntPtr)fn(hwnd, (BOOL)wParam, (HMENU)wParam, (HMENU)lParam);

	public static LRESULT HANDLE_WM_MDITILE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (uint)wParam);

	public static LRESULT HANDLE_WM_MEASUREITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MEASUREITEMSTRUCT> fn)
	{
		unsafe { fn(hwnd, *(MEASUREITEMSTRUCT*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MENUCHAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, char, MenuFlags, HMENU, WM_MENUCHAR_LRESULT> fn)
		=> (LRESULT)fn(hwnd, WPARAM_TO_CHARCODE(wParam), (MenuFlags)HIWORD(wParam), (HMENU)lParam);

	public static LRESULT HANDLE_WM_MENUSELECT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HMENU, int, HMENU, MenuFlags> fn)
	{
		fn(hwnd, (HMENU)lParam, ((HIWORD(wParam) & (int)MenuFlags.MF_POPUP) != 0) ? 0 : LOWORD(wParam), ((HIWORD(wParam) & (int)MenuFlags.MF_POPUP) != 0) ? GetSubMenu((HMENU)lParam, LOWORD(wParam)) : HMENU.NULL, (MenuFlags)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MOUSEACTIVATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, HitTestValues, uint, MouseActivateCode> fn)
		=> (LRESULT)fn(hwnd, (HWND)wParam, (HitTestValues)LOWORD(lParam), HIWORD(lParam));

	public static LRESULT HANDLE_WM_MOUSEMOVE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MOUSEWHEEL(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MOUSEWHEEL, POINTS> fn)
	{
		fn(hwnd, wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_MOVE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, POINTS> fn)
	{
		fn(hwnd, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCACTIVATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool, HWND, bool, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (BOOL)wParam, HWND.NULL, false);

	public static LRESULT HANDLE_WM_NCCALCSIZE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool, NCCALCSIZE_PARAMS, WVR> fn)
		=> (LRESULT)fn(hwnd, (BOOL)wParam, lParam.ToStructure<NCCALCSIZE_PARAMS>());

	public static unsafe LRESULT HANDLE_WM_NCCREATE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, CREATESTRUCT, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, lParam.ToStructure<CREATESTRUCT>());

	public static LRESULT HANDLE_WM_NCDESTROY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCHITTEST(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, POINTS, HitTestValues> fn)
		=> (LRESULT)fn(hwnd, (POINTS)lParam);

	public static LRESULT HANDLE_WM_NCLBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, true, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCLBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, false, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCLBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, POINTS, HitTestValues> fn)
	{
		fn(hwnd, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCMBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, true, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCMBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, false, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCMBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, POINTS, HitTestValues> fn)
	{
		fn(hwnd, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCMOUSEMOVE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, POINTS, HitTestValues> fn)
	{
		fn(hwnd, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCPAINT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HRGN> fn)
	{
		fn(hwnd, (HRGN)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCRBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, true, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCRBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, POINTS, HitTestValues> fn)
	{
		fn(hwnd, false, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NCRBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, POINTS, HitTestValues> fn)
	{
		fn(hwnd, (POINTS)lParam, (HitTestValues)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_NEXTDLGCTL(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, bool, HWND> fn)
		=> (IntPtr)fn(hwnd, (HWND)wParam, (BOOL)lParam);

	public static LRESULT HANDLE_WM_PAINT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_PAINTCLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, PAINTSTRUCT> fn)
	{
		unsafe { fn(hwnd, (HWND)wParam, GlobalLock((HGLOBAL)lParam).ToStructure<PAINTSTRUCT>()); }
		_ = GlobalUnlock((HGLOBAL)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_PALETTECHANGED(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_PALETTEISCHANGING(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_PARENTNOTIFY(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, HWND, int> fn)
	{
		fn(hwnd, LOWORD(wParam), (HWND)lParam, (int)(uint)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_PASTE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_POWER(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int> fn)
	{
		fn(hwnd, (int)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_QUERYDRAGICON(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HICON> fn)
		=> (LRESULT)fn(hwnd);

	public static LRESULT HANDLE_WM_QUERYENDSESSION(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool> fn)
		=> MAKELPARAM((uint)(BOOL)fn(hwnd), 0);

	public static LRESULT HANDLE_WM_QUERYNEWPALETTE(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool> fn)
		=> MAKELPARAM(fn(hwnd) ? 1 : 0, 0);

	public static LRESULT HANDLE_WM_QUERYOPEN(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, bool> fn)
		=> MAKELPARAM((uint)(BOOL)fn(hwnd), 0);

	public static LRESULT HANDLE_WM_QUEUESYNC(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_QUIT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int> fn)
	{
		fn(hwnd, (int)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_RBUTTONDBLCLK(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, true, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_RBUTTONDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, false, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_RBUTTONUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, MouseButtonState, POINTS> fn)
	{
		fn(hwnd, (MouseButtonState)wParam, (POINTS)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_RENDERALLFORMATS(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_RENDERFORMAT(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, HANDLE> fn)
		=> (IntPtr)fn(hwnd, (uint)wParam);

	public static LRESULT HANDLE_WM_SETCURSOR(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, HWND, uint, uint, bool> fn)
		=> (LRESULT)(BOOL)fn(hwnd, (HWND)wParam, LOWORD(lParam), HIWORD(lParam));

	public static LRESULT HANDLE_WM_SETFOCUS(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND> fn)
	{
		fn(hwnd, (HWND)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SETFONT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HFONT, bool> fn)
	{
		fn(hwnd, (HFONT)wParam, (BOOL)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SETREDRAW(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool> fn)
	{
		fn(hwnd, (BOOL)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SETTEXT(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, string?> fn)
	{
		fn(hwnd, StringHelper.GetString(lParam, CharSet.Ansi));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SHOWWINDOW(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, bool, uint> fn)
	{
		fn(hwnd, (BOOL)wParam, (uint)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SIZE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, WM_SIZE_WPARAM, SIZES> fn)
	{
		fn(hwnd, (WM_SIZE_WPARAM)wParam, (SIZES)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SIZECLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, RECT> fn)
	{
		unsafe { fn(hwnd, (HWND)wParam, *(RECT*)(void*)GlobalLock((HGLOBAL)lParam)); }
		_ = GlobalUnlock((HGLOBAL)lParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SPOOLERSTATUS(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, int> fn)
	{
		fn(hwnd, (uint)wParam, (short)LOWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSCHAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, char, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, WPARAM_TO_CHARCODE(wParam), new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSCOLORCHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSCOMMAND(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint, int, int> fn)
	{
		fn(hwnd, (uint)wParam, (short)LOWORD(lParam), (short)HIWORD(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSDEADCHAR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, char, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, WPARAM_TO_CHARCODE(wParam), new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSKEYDOWN(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, VK, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, (VK)(int)wParam, new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSKEYUP(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, VK, WM_KEY_LPARAM> fn)
	{
		fn(hwnd, (VK)(int)wParam, new WM_KEY_LPARAM(lParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_SYSTEMERROR(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, int> fn) => IntPtr.Zero;

	public static LRESULT HANDLE_WM_TIMECHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_TIMER(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, uint> fn)
	{
		fn(hwnd, (uint)wParam);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_UNDO(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND> fn)
	{
		fn(hwnd);
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_VKEYTOITEM(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, uint, HWND, int, int> fn)
		=> (LRESULT)(uint)fn(hwnd, LOWORD(wParam), (HWND)lParam, (short)HIWORD(wParam));

	public static LRESULT HANDLE_WM_VSCROLL(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, SBCMD, int> fn)
	{
		fn(hwnd, (HWND)lParam, (SBCMD)LOWORD(wParam), (short)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_VSCROLLCLIPBOARD(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, HWND, SBCMD, int> fn)
	{
		fn(hwnd, (HWND)lParam, (SBCMD)LOWORD(wParam), (short)HIWORD(wParam));
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_WINDOWPOSCHANGED(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, WINDOWPOS> fn)
	{
		unsafe { fn(hwnd, *(WINDOWPOS*)(void*)lParam); }
		return IntPtr.Zero;
	}

	public static LRESULT HANDLE_WM_WINDOWPOSCHANGING(HWND hwnd, WPARAM wParam, LPARAM lParam, Func<HWND, WINDOWPOS, bool> fn)
	{ unsafe { return (LRESULT)(BOOL)fn(hwnd, *(WINDOWPOS*)(void*)lParam); } }

	public static LRESULT HANDLE_WM_WININICHANGE(HWND hwnd, WPARAM wParam, LPARAM lParam, Action<HWND, string?> fn)
	{
		fn(hwnd, StringHelper.GetString(lParam, CharSet.Ansi));
		return IntPtr.Zero;
	}
}