using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		/// <summary>Status bar text drawing flags.</summary>
		[Flags]
		public enum SBT
		{
			/// <summary>Prevents borders from being drawn around the specified text.</summary>
			SBT_NOBORDERS = 0x0100,

			/// <summary>Draws highlighted borders that make the text stand out.</summary>
			SBT_POPOUT = 0x0200,

			/// <summary>
			/// Indicates that the string pointed to by pszText will be displayed in the opposite direction to the text in the parent window.
			/// </summary>
			SBT_RTLREADING = 0x0400,

			/// <summary>Tab characters are ignored.</summary>
			SBT_NOTABPARSING = 0x0800,

			/// <summary>The text is drawn by the parent window.</summary>
			SBT_OWNERDRAW = 0x1000,
		}

		/// <summary>
		/// <para>The <c>DrawStatusText</c> function draws the specified text in the style of a status window with borders.</para>
		/// </summary>
		/// <param name="hDC">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Handle to the display context for the window.</para>
		/// </param>
		/// <param name="lprc">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a RECT structure that contains the position, in client coordinates, of the rectangle in which the text is drawn. The
		/// function draws the borders just inside the edges of the specified rectangle.
		/// </para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string that specifies the text to display. Tab characters in the string determine whether the string
		/// is left-aligned, right-aligned, or centered.
		/// </para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Text drawing flags. This parameter can be a combination of these values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SBT_NOBORDERS</term>
		/// <term>Prevents borders from being drawn around the specified text.</term>
		/// </item>
		/// <item>
		/// <term>SBT_POPOUT</term>
		/// <term>Draws highlighted borders that make the text stand out.</term>
		/// </item>
		/// <item>
		/// <term>SBT_RTLREADING</term>
		/// <term>
		/// Indicates that the string pointed to by pszText will be displayed in the opposite direction to the text in the parent window.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Normal windows display text left-to-right (LTR). Windows can be mirrored to display languages such as Hebrew or Arabic that read
		/// right-to-left (RTL). Normally, the pszText string will be displayed in the same direction as the text in its parent window. If
		/// SBT_RTLREADING is set, the pszText string will read in the opposite direction from the text in the parent window.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/commctrl/nf-commctrl-drawstatustexta
		// void DrawStatusTextA( HDC hDC, LPCRECT lprc, LPCSTR pszText, UINT uFlags );
		[DllImport(Lib.ComCtl32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760763")]
		public static extern void DrawStatusText(HDC hdc, in RECT lprc, string pszText, SBT uFlags);

		/// <summary>
		/// Processes <c>WM_MENUSELECT</c> and <c>WM_COMMAND</c> messages and displays Help text about the current menu in the specified
		/// status window.
		/// </summary>
		/// <param name="uMsg">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Message being processed. This can be either <c>WM_MENUSELECT</c> or <c>WM_COMMAND</c>.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c><c>WPARAM</c></c></para>
		/// <para>wParam of the message specified in uMsg.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c><c>LPARAM</c></c></para>
		/// <para>lParam of the message specified in uMsg.</para>
		/// </param>
		/// <param name="hMainMenu">
		/// <para>Type: <c><c>HMENU</c></c></para>
		/// <para>Handle to the application's main menu.</para>
		/// </param>
		/// <param name="hInst">
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>Handle to the module that contains the string resources.</para>
		/// </param>
		/// <param name="hwndStatus">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle to the status window.</para>
		/// </param>
		/// <param name="lpwIDs">
		/// <para>Type: <c>LPUINT</c></para>
		/// <para>
		/// Pointer to an array of values that contains pairs of string resource identifiers and menu handles. The function searches the
		/// array for the handle to the selected menu and, if found, uses the corresponding resource identifier to load the appropriate Help string.
		/// </para>
		/// </param>
		/// <returns>No return value.</returns>
		// void MenuHelp( UINT uMsg, WPARAM wParam, LPARAM lParam, HMENU hMainMenu, HINSTANCE hInst, HWND hwndStatus, LPUINT lpwIDs); https://msdn.microsoft.com/en-us/library/windows/desktop/bb760765(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760765")]
		public static extern void MenuHelp(uint uMsg, IntPtr wParam, IntPtr lParam, HMENU hMainMenu, HINSTANCE hInst, HWND hwndStatus, IntPtr lpwIDs);
	}
}