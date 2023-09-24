#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

public static partial class User32
{
	public static HINSTANCE GetWindowInstance(HWND hwnd) => GetWindowLong<HINSTANCE>(hwnd, WindowLongFlags.GWLP_HINSTANCE);
	public static WindowStyles GetWindowStyle(HWND hwnd) => GetWindowLong<WindowStyles>(hwnd, WindowLongFlags.GWL_STYLE);
	public static WindowStylesEx GetWindowExStyle(HWND hwnd) => GetWindowLong<WindowStylesEx>(hwnd, WindowLongFlags.GWL_EXSTYLE);
	public static HWND GetWindowOwner(HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_OWNER);
	public static HWND GetFirstChild(HWND hwnd) => GetTopWindow(hwnd);
	public static HWND GetFirstSibling(HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDFIRST);
	public static HWND GetLastSibling(HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDLAST);
	public static HWND GetNextSibling(HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDNEXT);
	public static HWND GetPrevSibling(HWND hwnd) => GetWindow(hwnd, GetWindowCmd.GW_HWNDPREV);
	public static int GetWindowID(HWND hwnd) => GetDlgCtrlID(hwnd);
	public static bool IsMinimized(HWND hwnd) => IsIconic(hwnd);
	public static bool IsMaximized(HWND hwnd) => IsZoomed(hwnd);
	public static bool IsRestored(HWND hwnd) => (GetWindowStyle(hwnd) & (WindowStyles.WS_MINIMIZE | WindowStyles.WS_MAXIMIZE)) == 0L;
	public static HFONT GetWindowFont(HWND hwnd) => (HFONT)SendMessage(hwnd, WindowMessage.WM_GETFONT);
	//public static void CheckDefDlgRecursion(ref bool fRecursion) { if (fRecursion) { fRecursion = false; return false; } }
	public static bool IsLButtonDown() => GetKeyState((int)VK.VK_LBUTTON) < 0;
	public static bool IsRButtonDown() => GetKeyState((int)VK.VK_RBUTTON) < 0;
	public static bool IsMButtonDown() => GetKeyState((int)VK.VK_MBUTTON) < 0;
	public static HWND SetWindowRedraw(HWND hwnd, BOOL fRedraw) => SendMessage(hwnd, WindowMessage.WM_SETREDRAW, (IntPtr)fRedraw);
	public static WindowProc SubclassWindow(HWND hwnd, WindowProc lpfn) => (WindowProc)Marshal.GetDelegateForFunctionPointer(SetWindowLong(hwnd, WindowLongFlags.GWLP_WNDPROC, Marshal.GetFunctionPointerForDelegate(lpfn)), typeof(WindowProc));
	public static HWND SetWindowFont(HWND hwnd, HFONT hfont, BOOL fRedraw) => SendMessage(hwnd, WindowMessage.WM_SETFONT, (IntPtr)hfont, (IntPtr)fRedraw);
	public static int MapWindowRect(HWND hwndFrom, HWND hwndTo, ref RECT lprc) => MapWindowPoints(hwndFrom, hwndTo, ref lprc);
	public static WindowProc SubclassDialog(HWND hwndDlg, WindowProc lpfn) => (WindowProc)Marshal.GetDelegateForFunctionPointer(SetWindowLong(hwndDlg, WindowLongFlags.DWLP_DLGPROC, Marshal.GetFunctionPointerForDelegate(lpfn)), typeof(WindowProc));
	public static bool SetDlgMsgResult(HWND hwnd, WindowMessage msg, BOOL result) => (msg is WindowMessage.WM_CTLCOLORMSGBOX or WindowMessage.WM_CTLCOLOREDIT or WindowMessage.WM_CTLCOLORLISTBOX or WindowMessage.WM_CTLCOLORBTN or WindowMessage.WM_CTLCOLORDLG or WindowMessage.WM_CTLCOLORSCROLLBAR or WindowMessage.WM_CTLCOLORSTATIC or WindowMessage.WM_COMPAREITEM or WindowMessage.WM_VKEYTOITEM or WindowMessage.WM_CHARTOITEM or WindowMessage.WM_QUERYDRAGICON or WindowMessage.WM_INITDIALOG) ?
		result :
		SetWindowLong(hwnd, WindowLongFlags.DWLP_MSGRESULT, (IntPtr)result) != IntPtr.Zero;
	public static IntPtr DefDlgProcEx(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, ref bool pfRecursion) { pfRecursion = true; return DefDlgProc(hwnd, msg, wParam, lParam); }
}