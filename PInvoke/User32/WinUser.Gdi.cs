using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	/// <summary>User32.dll function with GDI params.</summary>
	public static partial class User32
	{
		/// <summary/>
		public const int OCM_NOTIFY = 0x204E; // WM_NOTIFY + WM_REFLECT

		/// <summary>Flags used by <see cref="ChangeDisplaySettings(in DEVMODE, ChangeDisplaySettingsFlags)"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "208bf1cc-c03c-4d03-92e4-32fcf856b4d8")]
		[Flags]
		public enum ChangeDisplaySettingsFlags
		{
			/// <summary>The graphics mode for the current screen will be changed dynamically.</summary>
			CDS_DEFAULT = 0,

			/// <summary>
			/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry.
			/// The mode information is stored in the USER profile.
			/// </summary>
			CDS_UPDATEREGISTRY = 0x00000001,

			/// <summary>The system tests if the requested graphics mode could be set.</summary>
			CDS_TEST = 0x00000002,

			/// <summary>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</summary>
			CDS_FULLSCREEN = 0x00000004,

			/// <summary>
			/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
			/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
			/// </summary>
			CDS_GLOBAL = 0x00000008,

			/// <summary>This device will become the primary device.</summary>
			CDS_SET_PRIMARY = 0x00000010,

			/// <summary>When set, the lParam parameter is a pointer to a VIDEOPARAMETERS structure.</summary>
			CDS_VIDEOPARAMETERS = 0x00000020,

			/// <summary>Enables settings changes to unsafe graphics modes.</summary>
			CDS_ENABLE_UNSAFE_MODES = 0x00000100,

			/// <summary>Disables settings changes to unsafe graphics modes.</summary>
			CDS_DISABLE_UNSAFE_MODES = 0x00000200,

			/// <summary>The settings should be changed, even if the requested settings are the same as the current settings.</summary>
			CDS_RESET = 0x40000000,

			/// <summary>Undocumented</summary>
			CDS_RESET_EX = 0x20000000,

			/// <summary>
			/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
			/// CDS_UPDATEREGISTRY flag.
			/// </summary>
			CDS_NORESET = 0x10000000,
		}

		/// <summary>Options for CopyImage.</summary>
		[Flags]
		public enum CopyImageOptions
		{
			/// <summary>
			/// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which
			/// case the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
			/// </summary>
			LR_COPYRETURNORG = 0x00000004,

			/// <summary>Deletes the original image after creating the copy.</summary>
			LR_COPYDELETEORG = 0x00000008,

			/// <summary>
			/// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This
			/// is useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this
			/// flag, CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource
			/// file closest to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with
			/// the LR_SHARED flag.
			/// </summary>
			LR_COPYFROMRESOURCE = 0x00004000,

			/// <summary>
			/// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible
			/// bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.
			/// </summary>
			LR_CREATEDIBSECTION = 0x00002000,

			/// <summary>
			/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are
			/// set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource
			/// size. If the resource contains multiple images, the function uses the size of the first image.
			/// </summary>
			LR_DEFAULTSIZE = 0x00000040,

			/// <summary>Loads the image in black and white.</summary>
			LR_MONOCHROME = 0x00000001,
		}

		/// <summary>Flags used by <see cref="GetDCEx"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "590cf928-0ad6-43f8-97e9-1dafbcfa9f49")]
		[Flags]
		public enum DCX
		{
			/// <summary>Returns a DC that corresponds to the window rectangle rather than the client rectangle.</summary>
			DCX_WINDOW = 0x00000001,

			/// <summary>Returns a DC from the cache, rather than the OWNDC or CLASSDC window. Essentially overrides CS_OWNDC and CS_CLASSDC.</summary>
			DCX_CACHE = 0x00000002,

			/// <summary>This flag is ignored.</summary>
			DCX_NORESETATTRS = 0x00000004,

			/// <summary>Excludes the visible regions of all child windows below the window identified by hWnd.</summary>
			DCX_CLIPCHILDREN = 0x00000008,

			/// <summary>Excludes the visible regions of all sibling windows above the window identified by hWnd.</summary>
			DCX_CLIPSIBLINGS = 0x00000010,

			/// <summary>
			/// Uses the visible region of the parent window. The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin
			/// is set to the upper-left corner of the window identified by hWnd.
			/// </summary>
			DCX_PARENTCLIP = 0x00000020,

			/// <summary>The clipping region identified by hrgnClip is excluded from the visible region of the returned DC.</summary>
			DCX_EXCLUDERGN = 0x00000040,

			/// <summary>The clipping region identified by hrgnClip is intersected with the visible region of the returned DC.</summary>
			DCX_INTERSECTRGN = 0x00000080,

			/// <summary>Returns a region that excludes the window's update region.</summary>
			DCX_EXCLUDEUPDATE = 0x00000100,

			/// <summary>Returns a region that includes the window's update region.</summary>
			DCX_INTERSECTUPDATE = 0x00000200,

			/// <summary>
			/// Allows drawing even if there is a LockWindowUpdate call in effect that would otherwise exclude this window. Used for drawing
			/// during tracking.
			/// </summary>
			DCX_LOCKWINDOWUPDATE = 0x00000400,

			/// <summary>
			/// When specified with DCX_INTERSECTUPDATE, causes the device context to be completely validated.
			/// <para>Using this function with both DCX_INTERSECTUPDATE and DCX_VALIDATE is identical to using the BeginPaint function.</para>
			/// </summary>
			DCX_VALIDATE = 0x00200000,
		}

		/// <summary>Flags for <see cref="GetGuiResources"/></summary>
		[PInvokeData("winuser.h", MSDNShortId = "55fbb7e8-79b4-4011-b522-25ea5a928b86")]
		[Flags]
		public enum GR
		{
			/// <summary>Return the count of GDI objects.</summary>
			GR_GDIOBJECTS = 0,

			/// <summary>
			/// Return the peak count of GDI objects.
			/// <para>
			/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows 7 and
			/// Windows Server 2008 R2.
			/// </para>
			/// </summary>
			GR_GDIOBJECTS_PEAK = 2,

			/// <summary>Return the count of USER objects.</summary>
			GR_USEROBJECTS = 1,

			/// <summary>
			/// Return the peak count of USER objects.
			/// <para>
			/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows 7 and
			/// Windows Server 2008 R2.
			/// </para>
			/// </summary>
			GR_USEROBJECTS_PEAK = 4,
		}

		/// <summary>Values to use a return codes when handling the WM_HCHITTEST message.</summary>
		public enum HitTestValues : short
		{
			/// <summary>In the border of a window that does not have a sizing border.</summary>
			HTBORDER = 18,

			/// <summary>In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).</summary>
			HTBOTTOM = 15,

			/// <summary>
			/// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
			/// </summary>
			HTBOTTOMLEFT = 16,

			/// <summary>
			/// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
			/// </summary>
			HTBOTTOMRIGHT = 17,

			/// <summary>In a title bar.</summary>
			HTCAPTION = 2,

			/// <summary>In a client area.</summary>
			HTCLIENT = 1,

			/// <summary>In a Close button.</summary>
			HTCLOSE = 20,

			/// <summary>
			/// On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function
			/// produces a system beep to indicate an error).
			/// </summary>
			HTERROR = -2,

			/// <summary>In a size box (same as HTSIZE).</summary>
			HTGROWBOX = 4,

			/// <summary>In a Help button.</summary>
			HTHELP = 21,

			/// <summary>In a horizontal scroll bar.</summary>
			HTHSCROLL = 6,

			/// <summary>In the left border of a resizable window (the user can click the mouse to resize the window horizontally).</summary>
			HTLEFT = 10,

			/// <summary>In a menu.</summary>
			HTMENU = 5,

			/// <summary>In a Maximize button.</summary>
			HTMAXBUTTON = 9,

			/// <summary>In a Minimize button.</summary>
			HTMINBUTTON = 8,

			/// <summary>On the screen background or on a dividing line between windows.</summary>
			HTNOWHERE = 0,

			/* /// <summary>Not implemented.</summary>
			HTOBJECT = 19, */

			/// <summary>In a Minimize button.</summary>
			HTREDUCE = HTMINBUTTON,

			/// <summary>In the right border of a resizable window (the user can click the mouse to resize the window horizontally).</summary>
			HTRIGHT = 11,

			/// <summary>In a size box (same as HTGROWBOX).</summary>
			HTSIZE = HTGROWBOX,

			/// <summary>In a window menu or in a Close button in a child window.</summary>
			HTSYSMENU = 3,

			/// <summary>In the upper-horizontal border of a window.</summary>
			HTTOP = 12,

			/// <summary>In the upper-left corner of a window border.</summary>
			HTTOPLEFT = 13,

			/// <summary>In the upper-right corner of a window border.</summary>
			HTTOPRIGHT = 14,

			/// <summary>
			/// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the
			/// same thread until one of them returns a code that is not HTTRANSPARENT).
			/// </summary>
			HTTRANSPARENT = -1,

			/// <summary>In the vertical scroll bar.</summary>
			HTVSCROLL = 7,

			/// <summary>In a Maximize button.</summary>
			HTZOOM = HTMAXBUTTON,
		}

		/// <summary>
		/// Flags used for <see cref="GetWindowLong"/> and <see cref="SetWindowLong(HWND, WindowLongFlags, int)"/> methods to retrieve information about a window.
		/// </summary>
		public enum WindowLongFlags
		{
			/// <summary>The extended window styles</summary>
			GWL_EXSTYLE = -20,

			/// <summary>The application instance handle</summary>
			GWL_HINSTANCE = -6,

			/// <summary>The parent window handle</summary>
			GWL_HWNDPARENT = -8,

			/// <summary>The window identifier</summary>
			GWL_ID = -12,

			/// <summary>The window styles</summary>
			GWL_STYLE = -16,

			/// <summary>The window user data</summary>
			GWL_USERDATA = -21,

			/// <summary>The window procedure address or handle</summary>
			GWL_WNDPROC = -4,

			/// <summary>The dialog user data</summary>
			DWLP_USER = 0x8,

			/// <summary>The dialog procedure message result</summary>
			DWLP_MSGRESULT = 0x0,

			/// <summary>The dialog procedure address or handle</summary>
			DWLP_DLGPROC = 0x4
		}

		/// <summary>
		/// <para>
		/// The <c>ChangeDisplaySettings</c> function changes the settings of the default display device to the specified graphics mode.
		/// </para>
		/// <para>To change the settings of a specified display device, use the ChangeDisplaySettingsEx function.</para>
		/// <para>
		/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32
		/// bits per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8
		/// still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates
		/// these modes but still runs in 32-bit color mode.
		/// </para>
		/// </summary>
		/// <param name="lpDevMode">
		/// <para>
		/// A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is <c>NULL</c>, all the values currently in
		/// the registry will be used for the display setting. Passing <c>NULL</c> for the lpDevMode parameter and 0 for the dwFlags
		/// parameter is the easiest way to return to the default mode after a dynamic mode change.
		/// </para>
		/// <para>
		/// The <c>dmSize</c> member of DEVMODE must be initialized to the size, in bytes, of the <c>DEVMODE</c> structure. The
		/// <c>dmDriverExtra</c> member of <c>DEVMODE</c> must be initialized to indicate the number of bytes of private driver data
		/// following the <c>DEVMODE</c> structure. In addition, you can use any or all of the following members of the <c>DEVMODE</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dmBitsPerPel</term>
		/// <term>Bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>dmPelsWidth</term>
		/// <term>Pixel width</term>
		/// </item>
		/// <item>
		/// <term>dmPelsHeight</term>
		/// <term>Pixel height</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFlags</term>
		/// <term>Mode flags</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFrequency</term>
		/// <term>Mode frequency</term>
		/// </item>
		/// <item>
		/// <term>dmPosition</term>
		/// <term>Position of the device in a multi-monitor configuration.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to using one or more of the preceding DEVMODE members, you must also set one or more of the following values in the
		/// <c>dmFields</c> member to change the display setting.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Indicates how the graphics mode should be changed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The graphics mode for the current screen will be changed dynamically.</term>
		/// </item>
		/// <item>
		/// <term>CDS_FULLSCREEN</term>
		/// <term>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</term>
		/// </item>
		/// <item>
		/// <term>CDS_GLOBAL</term>
		/// <term>
		/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
		/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_NORESET</term>
		/// <term>
		/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
		/// CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_RESET</term>
		/// <term>The settings should be changed, even if the requested settings are the same as the current settings.</term>
		/// </item>
		/// <item>
		/// <term>CDS_SET_PRIMARY</term>
		/// <term>This device will become the primary device.</term>
		/// </item>
		/// <item>
		/// <term>CDS_TEST</term>
		/// <term>The system tests if the requested graphics mode could be set.</term>
		/// </item>
		/// <item>
		/// <term>CDS_UPDATEREGISTRY</term>
		/// <term>
		/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The
		/// mode information is stored in the USER profile.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Specifying CDS_TEST allows an application to determine which graphics modes are actually valid, without causing the system to
		/// change to that graphics mode.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and it is possible to change the graphics mode dynamically, the information is stored in the
		/// registry and DISP_CHANGE_SUCCESSFUL is returned. If it is not possible to change the graphics mode dynamically, the information
		/// is stored in the registry and DISP_CHANGE_RESTART is returned.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and the information could not be stored in the registry, the graphics mode is not changed and
		/// DISP_CHANGE_NOTUPDATED is returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The <c>ChangeDisplaySettings</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DISP_CHANGE_SUCCESSFUL</term>
		/// <term>The settings change was successful.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADDUALVIEW</term>
		/// <term>The settings change was unsuccessful because the system is DualView capable.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADFLAGS</term>
		/// <term>An invalid set of flags was passed in.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADMODE</term>
		/// <term>The graphics mode is not supported.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADPARAM</term>
		/// <term>An invalid parameter was passed in. This can include an invalid flag or combination of flags.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_FAILED</term>
		/// <term>The display driver failed the specified graphics mode.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_NOTUPDATED</term>
		/// <term>Unable to write settings to the registry.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_RESTART</term>
		/// <term>The computer must be restarted for the graphics mode to work.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To ensure that the DEVMODE structure passed to <c>ChangeDisplaySettings</c> is valid and contains only values supported by the
		/// display driver, use the <c>DEVMODE</c> returned by the EnumDisplaySettings function.
		/// </para>
		/// <para>
		/// When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications with the following
		/// message parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameters</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>wParam</term>
		/// <term>New bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>LOWORD(lParam)</term>
		/// <term>New pixel width</term>
		/// </item>
		/// <item>
		/// <term>HIWORD(lParam)</term>
		/// <term>New pixel height</term>
		/// </item>
		/// </list>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changedisplaysettingsa LONG ChangeDisplaySettingsA(
		// DEVMODEA *lpDevMode, DWORD dwFlags );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "208bf1cc-c03c-4d03-92e4-32fcf856b4d8")]
		public static extern int ChangeDisplaySettings(in DEVMODE lpDevMode, ChangeDisplaySettingsFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>ChangeDisplaySettings</c> function changes the settings of the default display device to the specified graphics mode.
		/// </para>
		/// <para>To change the settings of a specified display device, use the ChangeDisplaySettingsEx function.</para>
		/// <para>
		/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32
		/// bits per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8
		/// still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates
		/// these modes but still runs in 32-bit color mode.
		/// </para>
		/// </summary>
		/// <param name="lpDevMode">
		/// <para>
		/// A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is <c>NULL</c>, all the values currently in
		/// the registry will be used for the display setting. Passing <c>NULL</c> for the lpDevMode parameter and 0 for the dwFlags
		/// parameter is the easiest way to return to the default mode after a dynamic mode change.
		/// </para>
		/// <para>
		/// The <c>dmSize</c> member of DEVMODE must be initialized to the size, in bytes, of the <c>DEVMODE</c> structure. The
		/// <c>dmDriverExtra</c> member of <c>DEVMODE</c> must be initialized to indicate the number of bytes of private driver data
		/// following the <c>DEVMODE</c> structure. In addition, you can use any or all of the following members of the <c>DEVMODE</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dmBitsPerPel</term>
		/// <term>Bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>dmPelsWidth</term>
		/// <term>Pixel width</term>
		/// </item>
		/// <item>
		/// <term>dmPelsHeight</term>
		/// <term>Pixel height</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFlags</term>
		/// <term>Mode flags</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFrequency</term>
		/// <term>Mode frequency</term>
		/// </item>
		/// <item>
		/// <term>dmPosition</term>
		/// <term>Position of the device in a multi-monitor configuration.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to using one or more of the preceding DEVMODE members, you must also set one or more of the following values in the
		/// <c>dmFields</c> member to change the display setting.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Indicates how the graphics mode should be changed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The graphics mode for the current screen will be changed dynamically.</term>
		/// </item>
		/// <item>
		/// <term>CDS_FULLSCREEN</term>
		/// <term>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</term>
		/// </item>
		/// <item>
		/// <term>CDS_GLOBAL</term>
		/// <term>
		/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
		/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_NORESET</term>
		/// <term>
		/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
		/// CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_RESET</term>
		/// <term>The settings should be changed, even if the requested settings are the same as the current settings.</term>
		/// </item>
		/// <item>
		/// <term>CDS_SET_PRIMARY</term>
		/// <term>This device will become the primary device.</term>
		/// </item>
		/// <item>
		/// <term>CDS_TEST</term>
		/// <term>The system tests if the requested graphics mode could be set.</term>
		/// </item>
		/// <item>
		/// <term>CDS_UPDATEREGISTRY</term>
		/// <term>
		/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The
		/// mode information is stored in the USER profile.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Specifying CDS_TEST allows an application to determine which graphics modes are actually valid, without causing the system to
		/// change to that graphics mode.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and it is possible to change the graphics mode dynamically, the information is stored in the
		/// registry and DISP_CHANGE_SUCCESSFUL is returned. If it is not possible to change the graphics mode dynamically, the information
		/// is stored in the registry and DISP_CHANGE_RESTART is returned.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and the information could not be stored in the registry, the graphics mode is not changed and
		/// DISP_CHANGE_NOTUPDATED is returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The <c>ChangeDisplaySettings</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DISP_CHANGE_SUCCESSFUL</term>
		/// <term>The settings change was successful.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADDUALVIEW</term>
		/// <term>The settings change was unsuccessful because the system is DualView capable.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADFLAGS</term>
		/// <term>An invalid set of flags was passed in.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADMODE</term>
		/// <term>The graphics mode is not supported.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADPARAM</term>
		/// <term>An invalid parameter was passed in. This can include an invalid flag or combination of flags.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_FAILED</term>
		/// <term>The display driver failed the specified graphics mode.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_NOTUPDATED</term>
		/// <term>Unable to write settings to the registry.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_RESTART</term>
		/// <term>The computer must be restarted for the graphics mode to work.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To ensure that the DEVMODE structure passed to <c>ChangeDisplaySettings</c> is valid and contains only values supported by the
		/// display driver, use the <c>DEVMODE</c> returned by the EnumDisplaySettings function.
		/// </para>
		/// <para>
		/// When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications with the following
		/// message parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameters</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>wParam</term>
		/// <term>New bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>LOWORD(lParam)</term>
		/// <term>New pixel width</term>
		/// </item>
		/// <item>
		/// <term>HIWORD(lParam)</term>
		/// <term>New pixel height</term>
		/// </item>
		/// </list>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changedisplaysettingsa LONG ChangeDisplaySettingsA(
		// DEVMODEA *lpDevMode, DWORD dwFlags );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "208bf1cc-c03c-4d03-92e4-32fcf856b4d8")]
		public static extern int ChangeDisplaySettings([Optional] IntPtr lpDevMode, ChangeDisplaySettingsFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>ChangeDisplaySettingsEx</c> function changes the settings of the specified display device to the specified graphics mode.
		/// </para>
		/// <para>
		/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32
		/// bits per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8
		/// still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates
		/// these modes but still runs in 32-bit color mode.
		/// </para>
		/// </summary>
		/// <param name="lpszDeviceName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the display device whose graphics mode will change. Only display device
		/// names as returned by EnumDisplayDevices are valid. See <c>EnumDisplayDevices</c> for further information on the names associated
		/// with these display devices.
		/// </para>
		/// <para>
		/// The lpszDeviceName parameter can be <c>NULL</c>. A <c>NULL</c> value specifies the default display device. The default device can
		/// be determined by calling EnumDisplayDevices and checking for the DISPLAY_DEVICE_PRIMARY_DEVICE flag.
		/// </para>
		/// </param>
		/// <param name="lpDevMode">
		/// <para>
		/// A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is <c>NULL</c>, all the values currently in
		/// the registry will be used for the display setting. Passing <c>NULL</c> for the lpDevMode parameter and 0 for the dwFlags
		/// parameter is the easiest way to return to the default mode after a dynamic mode change.
		/// </para>
		/// <para>
		/// The <c>dmSize</c> member must be initialized to the size, in bytes, of the DEVMODE structure. The <c>dmDriverExtra</c> member
		/// must be initialized to indicate the number of bytes of private driver data following the <c>DEVMODE</c> structure. In addition,
		/// you can use any of the following members of the <c>DEVMODE</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dmBitsPerPel</term>
		/// <term>Bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>dmPelsWidth</term>
		/// <term>Pixel width</term>
		/// </item>
		/// <item>
		/// <term>dmPelsHeight</term>
		/// <term>Pixel height</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFlags</term>
		/// <term>Mode flags</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFrequency</term>
		/// <term>Mode frequency</term>
		/// </item>
		/// <item>
		/// <term>dmPosition</term>
		/// <term>Position of the device in a multi-monitor configuration.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to using one or more of the preceding DEVMODE members, you must also set one or more of the following values in the
		/// <c>dmFields</c> member to change the display settings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DM_BITSPERPEL</term>
		/// <term>Use the dmBitsPerPel value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSWIDTH</term>
		/// <term>Use the dmPelsWidth value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSHEIGHT</term>
		/// <term>Use the dmPelsHeight value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFLAGS</term>
		/// <term>Use the dmDisplayFlags value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFREQUENCY</term>
		/// <term>Use the dmDisplayFrequency value.</term>
		/// </item>
		/// <item>
		/// <term>DM_POSITION</term>
		/// <term>Use the dmPosition value.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hwnd">Reserved; must be <c>NULL</c>.</param>
		/// <param name="dwflags">
		/// <para>Indicates how the graphics mode should be changed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The graphics mode for the current screen will be changed dynamically.</term>
		/// </item>
		/// <item>
		/// <term>CDS_FULLSCREEN</term>
		/// <term>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</term>
		/// </item>
		/// <item>
		/// <term>CDS_GLOBAL</term>
		/// <term>
		/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
		/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_NORESET</term>
		/// <term>
		/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
		/// CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_RESET</term>
		/// <term>The settings should be changed, even if the requested settings are the same as the current settings.</term>
		/// </item>
		/// <item>
		/// <term>CDS_SET_PRIMARY</term>
		/// <term>This device will become the primary device.</term>
		/// </item>
		/// <item>
		/// <term>CDS_TEST</term>
		/// <term>The system tests if the requested graphics mode could be set.</term>
		/// </item>
		/// <item>
		/// <term>CDS_UPDATEREGISTRY</term>
		/// <term>
		/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The
		/// mode information is stored in the USER profile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_VIDEOPARAMETERS</term>
		/// <term>When set, the lParam parameter is a pointer to a VIDEOPARAMETERS structure.</term>
		/// </item>
		/// <item>
		/// <term>CDS_ENABLE_UNSAFE_MODES</term>
		/// <term>Enables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// <item>
		/// <term>CDS_DISABLE_UNSAFE_MODES</term>
		/// <term>Disables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Specifying CDS_TEST allows an application to determine which graphics modes are actually valid, without causing the system to
		/// change to them.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and it is possible to change the graphics mode dynamically, the information is stored in the
		/// registry and DISP_CHANGE_SUCCESSFUL is returned. If it is not possible to change the graphics mode dynamically, the information
		/// is stored in the registry and DISP_CHANGE_RESTART is returned.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and the information could not be stored in the registry, the graphics mode is not changed and
		/// DISP_CHANGE_NOTUPDATED is returned.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// If dwFlags is <c>CDS_VIDEOPARAMETERS</c>, lParam is a pointer to a VIDEOPARAMETERS structure. Otherwise lParam must be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>The <c>ChangeDisplaySettingsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DISP_CHANGE_SUCCESSFUL</term>
		/// <term>The settings change was successful.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADDUALVIEW</term>
		/// <term>The settings change was unsuccessful because the system is DualView capable.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADFLAGS</term>
		/// <term>An invalid set of flags was passed in.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADMODE</term>
		/// <term>The graphics mode is not supported.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADPARAM</term>
		/// <term>An invalid parameter was passed in. This can include an invalid flag or combination of flags.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_FAILED</term>
		/// <term>The display driver failed the specified graphics mode.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_NOTUPDATED</term>
		/// <term>Unable to write settings to the registry.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_RESTART</term>
		/// <term>The computer must be restarted for the graphics mode to work.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To ensure that the DEVMODE structure passed to <c>ChangeDisplaySettingsEx</c> is valid and contains only values supported by the
		/// display driver, use the <c>DEVMODE</c> returned by the EnumDisplaySettings function.
		/// </para>
		/// <para>
		/// When adding a display monitor to a multiple-monitor system programmatically, set <c>DEVMODE.dmFields</c> to DM_POSITION and
		/// specify a position (in <c>DEVMODE.dmPosition</c>) for the monitor you are adding that is adjacent to at least one pixel of the
		/// display area of an existing monitor. To detach the monitor, set <c>DEVMODE.dmFields</c> to DM_POSITION but set
		/// <c>DEVMODE.dmPelsWidth</c> and <c>DEVMODE.dmPelsHeight</c> to zero. For more information, see Multiple Display Monitors.
		/// </para>
		/// <para>
		/// When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications with the following
		/// message parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameters</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>wParam</term>
		/// <term>New bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>LOWORD(lParam)</term>
		/// <term>New pixel width</term>
		/// </item>
		/// <item>
		/// <term>HIWORD(lParam)</term>
		/// <term>New pixel height</term>
		/// </item>
		/// </list>
		/// <para>
		/// To change the settings for more than one display at the same time, first call <c>ChangeDisplaySettingsEx</c> for each device
		/// individually to update the registry without applying the changes. Then call <c>ChangeDisplaySettingsEx</c> once more, with a
		/// <c>NULL</c> device, to apply the changes. For example, to change the settings for two displays, do the following:
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changedisplaysettingsexa LONG ChangeDisplaySettingsExA(
		// LPCSTR lpszDeviceName, DEVMODEA *lpDevMode, HWND hwnd, DWORD dwflags, LPVOID lParam );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "1448e04c-1452-4eab-bda4-4d249cb67a24")]
		public static extern int ChangeDisplaySettingsEx([Optional] string lpszDeviceName, in DEVMODE lpDevMode, [Optional] HWND hwnd, [Optional] ChangeDisplaySettingsFlags dwflags, [Optional] IntPtr lParam);

		/// <summary>
		/// <para>
		/// The <c>ChangeDisplaySettingsEx</c> function changes the settings of the specified display device to the specified graphics mode.
		/// </para>
		/// <para>
		/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32
		/// bits per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8
		/// still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates
		/// these modes but still runs in 32-bit color mode.
		/// </para>
		/// </summary>
		/// <param name="lpszDeviceName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the display device whose graphics mode will change. Only display device
		/// names as returned by EnumDisplayDevices are valid. See <c>EnumDisplayDevices</c> for further information on the names associated
		/// with these display devices.
		/// </para>
		/// <para>
		/// The lpszDeviceName parameter can be <c>NULL</c>. A <c>NULL</c> value specifies the default display device. The default device can
		/// be determined by calling EnumDisplayDevices and checking for the DISPLAY_DEVICE_PRIMARY_DEVICE flag.
		/// </para>
		/// </param>
		/// <param name="lpDevMode">
		/// <para>
		/// A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is <c>NULL</c>, all the values currently in
		/// the registry will be used for the display setting. Passing <c>NULL</c> for the lpDevMode parameter and 0 for the dwFlags
		/// parameter is the easiest way to return to the default mode after a dynamic mode change.
		/// </para>
		/// <para>
		/// The <c>dmSize</c> member must be initialized to the size, in bytes, of the DEVMODE structure. The <c>dmDriverExtra</c> member
		/// must be initialized to indicate the number of bytes of private driver data following the <c>DEVMODE</c> structure. In addition,
		/// you can use any of the following members of the <c>DEVMODE</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dmBitsPerPel</term>
		/// <term>Bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>dmPelsWidth</term>
		/// <term>Pixel width</term>
		/// </item>
		/// <item>
		/// <term>dmPelsHeight</term>
		/// <term>Pixel height</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFlags</term>
		/// <term>Mode flags</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFrequency</term>
		/// <term>Mode frequency</term>
		/// </item>
		/// <item>
		/// <term>dmPosition</term>
		/// <term>Position of the device in a multi-monitor configuration.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to using one or more of the preceding DEVMODE members, you must also set one or more of the following values in the
		/// <c>dmFields</c> member to change the display settings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DM_BITSPERPEL</term>
		/// <term>Use the dmBitsPerPel value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSWIDTH</term>
		/// <term>Use the dmPelsWidth value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSHEIGHT</term>
		/// <term>Use the dmPelsHeight value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFLAGS</term>
		/// <term>Use the dmDisplayFlags value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFREQUENCY</term>
		/// <term>Use the dmDisplayFrequency value.</term>
		/// </item>
		/// <item>
		/// <term>DM_POSITION</term>
		/// <term>Use the dmPosition value.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hwnd">Reserved; must be <c>NULL</c>.</param>
		/// <param name="dwflags">
		/// <para>Indicates how the graphics mode should be changed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The graphics mode for the current screen will be changed dynamically.</term>
		/// </item>
		/// <item>
		/// <term>CDS_FULLSCREEN</term>
		/// <term>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</term>
		/// </item>
		/// <item>
		/// <term>CDS_GLOBAL</term>
		/// <term>
		/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
		/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_NORESET</term>
		/// <term>
		/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
		/// CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_RESET</term>
		/// <term>The settings should be changed, even if the requested settings are the same as the current settings.</term>
		/// </item>
		/// <item>
		/// <term>CDS_SET_PRIMARY</term>
		/// <term>This device will become the primary device.</term>
		/// </item>
		/// <item>
		/// <term>CDS_TEST</term>
		/// <term>The system tests if the requested graphics mode could be set.</term>
		/// </item>
		/// <item>
		/// <term>CDS_UPDATEREGISTRY</term>
		/// <term>
		/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The
		/// mode information is stored in the USER profile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_VIDEOPARAMETERS</term>
		/// <term>When set, the lParam parameter is a pointer to a VIDEOPARAMETERS structure.</term>
		/// </item>
		/// <item>
		/// <term>CDS_ENABLE_UNSAFE_MODES</term>
		/// <term>Enables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// <item>
		/// <term>CDS_DISABLE_UNSAFE_MODES</term>
		/// <term>Disables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Specifying CDS_TEST allows an application to determine which graphics modes are actually valid, without causing the system to
		/// change to them.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and it is possible to change the graphics mode dynamically, the information is stored in the
		/// registry and DISP_CHANGE_SUCCESSFUL is returned. If it is not possible to change the graphics mode dynamically, the information
		/// is stored in the registry and DISP_CHANGE_RESTART is returned.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and the information could not be stored in the registry, the graphics mode is not changed and
		/// DISP_CHANGE_NOTUPDATED is returned.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// If dwFlags is <c>CDS_VIDEOPARAMETERS</c>, lParam is a pointer to a VIDEOPARAMETERS structure. Otherwise lParam must be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>The <c>ChangeDisplaySettingsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DISP_CHANGE_SUCCESSFUL</term>
		/// <term>The settings change was successful.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADDUALVIEW</term>
		/// <term>The settings change was unsuccessful because the system is DualView capable.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADFLAGS</term>
		/// <term>An invalid set of flags was passed in.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADMODE</term>
		/// <term>The graphics mode is not supported.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADPARAM</term>
		/// <term>An invalid parameter was passed in. This can include an invalid flag or combination of flags.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_FAILED</term>
		/// <term>The display driver failed the specified graphics mode.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_NOTUPDATED</term>
		/// <term>Unable to write settings to the registry.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_RESTART</term>
		/// <term>The computer must be restarted for the graphics mode to work.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To ensure that the DEVMODE structure passed to <c>ChangeDisplaySettingsEx</c> is valid and contains only values supported by the
		/// display driver, use the <c>DEVMODE</c> returned by the EnumDisplaySettings function.
		/// </para>
		/// <para>
		/// When adding a display monitor to a multiple-monitor system programmatically, set <c>DEVMODE.dmFields</c> to DM_POSITION and
		/// specify a position (in <c>DEVMODE.dmPosition</c>) for the monitor you are adding that is adjacent to at least one pixel of the
		/// display area of an existing monitor. To detach the monitor, set <c>DEVMODE.dmFields</c> to DM_POSITION but set
		/// <c>DEVMODE.dmPelsWidth</c> and <c>DEVMODE.dmPelsHeight</c> to zero. For more information, see Multiple Display Monitors.
		/// </para>
		/// <para>
		/// When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications with the following
		/// message parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameters</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>wParam</term>
		/// <term>New bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>LOWORD(lParam)</term>
		/// <term>New pixel width</term>
		/// </item>
		/// <item>
		/// <term>HIWORD(lParam)</term>
		/// <term>New pixel height</term>
		/// </item>
		/// </list>
		/// <para>
		/// To change the settings for more than one display at the same time, first call <c>ChangeDisplaySettingsEx</c> for each device
		/// individually to update the registry without applying the changes. Then call <c>ChangeDisplaySettingsEx</c> once more, with a
		/// <c>NULL</c> device, to apply the changes. For example, to change the settings for two displays, do the following:
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changedisplaysettingsexa LONG ChangeDisplaySettingsExA(
		// LPCSTR lpszDeviceName, DEVMODEA *lpDevMode, HWND hwnd, DWORD dwflags, LPVOID lParam );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "1448e04c-1452-4eab-bda4-4d249cb67a24")]
		public static extern int ChangeDisplaySettingsEx([Optional] string lpszDeviceName, [Optional] IntPtr lpDevMode, [Optional] HWND hwnd, [Optional] ChangeDisplaySettingsFlags dwflags, [Optional] IntPtr lParam);

		/// <summary>
		/// <para>
		/// The <c>ChangeDisplaySettingsEx</c> function changes the settings of the specified display device to the specified graphics mode.
		/// </para>
		/// <para>
		/// <c>Note</c> Apps that you design to target Windows 8 and later can no longer query or set display modes that are less than 32
		/// bits per pixel (bpp); these operations will fail. These apps have a compatibility manifest that targets Windows 8. Windows 8
		/// still supports 8-bit and 16-bit color modes for desktop apps that were built without a Windows 8 manifest; Windows 8 emulates
		/// these modes but still runs in 32-bit color mode.
		/// </para>
		/// </summary>
		/// <param name="lpszDeviceName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the display device whose graphics mode will change. Only display device
		/// names as returned by EnumDisplayDevices are valid. See <c>EnumDisplayDevices</c> for further information on the names associated
		/// with these display devices.
		/// </para>
		/// <para>
		/// The lpszDeviceName parameter can be <c>NULL</c>. A <c>NULL</c> value specifies the default display device. The default device can
		/// be determined by calling EnumDisplayDevices and checking for the DISPLAY_DEVICE_PRIMARY_DEVICE flag.
		/// </para>
		/// </param>
		/// <param name="lpDevMode">
		/// <para>
		/// A pointer to a DEVMODE structure that describes the new graphics mode. If lpDevMode is <c>NULL</c>, all the values currently in
		/// the registry will be used for the display setting. Passing <c>NULL</c> for the lpDevMode parameter and 0 for the dwFlags
		/// parameter is the easiest way to return to the default mode after a dynamic mode change.
		/// </para>
		/// <para>
		/// The <c>dmSize</c> member must be initialized to the size, in bytes, of the DEVMODE structure. The <c>dmDriverExtra</c> member
		/// must be initialized to indicate the number of bytes of private driver data following the <c>DEVMODE</c> structure. In addition,
		/// you can use any of the following members of the <c>DEVMODE</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>dmBitsPerPel</term>
		/// <term>Bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>dmPelsWidth</term>
		/// <term>Pixel width</term>
		/// </item>
		/// <item>
		/// <term>dmPelsHeight</term>
		/// <term>Pixel height</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFlags</term>
		/// <term>Mode flags</term>
		/// </item>
		/// <item>
		/// <term>dmDisplayFrequency</term>
		/// <term>Mode frequency</term>
		/// </item>
		/// <item>
		/// <term>dmPosition</term>
		/// <term>Position of the device in a multi-monitor configuration.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In addition to using one or more of the preceding DEVMODE members, you must also set one or more of the following values in the
		/// <c>dmFields</c> member to change the display settings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DM_BITSPERPEL</term>
		/// <term>Use the dmBitsPerPel value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSWIDTH</term>
		/// <term>Use the dmPelsWidth value.</term>
		/// </item>
		/// <item>
		/// <term>DM_PELSHEIGHT</term>
		/// <term>Use the dmPelsHeight value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFLAGS</term>
		/// <term>Use the dmDisplayFlags value.</term>
		/// </item>
		/// <item>
		/// <term>DM_DISPLAYFREQUENCY</term>
		/// <term>Use the dmDisplayFrequency value.</term>
		/// </item>
		/// <item>
		/// <term>DM_POSITION</term>
		/// <term>Use the dmPosition value.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hwnd">Reserved; must be <c>NULL</c>.</param>
		/// <param name="dwflags">
		/// <para>Indicates how the graphics mode should be changed. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The graphics mode for the current screen will be changed dynamically.</term>
		/// </item>
		/// <item>
		/// <term>CDS_FULLSCREEN</term>
		/// <term>The mode is temporary in nature. If you change to and from another desktop, this mode will not be reset.</term>
		/// </item>
		/// <item>
		/// <term>CDS_GLOBAL</term>
		/// <term>
		/// The settings will be saved in the global settings area so that they will affect all users on the machine. Otherwise, only the
		/// settings for the user are modified. This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_NORESET</term>
		/// <term>
		/// The settings will be saved in the registry, but will not take effect. This flag is only valid when specified with the
		/// CDS_UPDATEREGISTRY flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_RESET</term>
		/// <term>The settings should be changed, even if the requested settings are the same as the current settings.</term>
		/// </item>
		/// <item>
		/// <term>CDS_SET_PRIMARY</term>
		/// <term>This device will become the primary device.</term>
		/// </item>
		/// <item>
		/// <term>CDS_TEST</term>
		/// <term>The system tests if the requested graphics mode could be set.</term>
		/// </item>
		/// <item>
		/// <term>CDS_UPDATEREGISTRY</term>
		/// <term>
		/// The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry. The
		/// mode information is stored in the USER profile.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CDS_VIDEOPARAMETERS</term>
		/// <term>When set, the lParam parameter is a pointer to a VIDEOPARAMETERS structure.</term>
		/// </item>
		/// <item>
		/// <term>CDS_ENABLE_UNSAFE_MODES</term>
		/// <term>Enables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// <item>
		/// <term>CDS_DISABLE_UNSAFE_MODES</term>
		/// <term>Disables settings changes to unsafe graphics modes.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Specifying CDS_TEST allows an application to determine which graphics modes are actually valid, without causing the system to
		/// change to them.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and it is possible to change the graphics mode dynamically, the information is stored in the
		/// registry and DISP_CHANGE_SUCCESSFUL is returned. If it is not possible to change the graphics mode dynamically, the information
		/// is stored in the registry and DISP_CHANGE_RESTART is returned.
		/// </para>
		/// <para>
		/// If CDS_UPDATEREGISTRY is specified and the information could not be stored in the registry, the graphics mode is not changed and
		/// DISP_CHANGE_NOTUPDATED is returned.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// If dwFlags is <c>CDS_VIDEOPARAMETERS</c>, lParam is a pointer to a VIDEOPARAMETERS structure. Otherwise lParam must be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>The <c>ChangeDisplaySettingsEx</c> function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DISP_CHANGE_SUCCESSFUL</term>
		/// <term>The settings change was successful.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADDUALVIEW</term>
		/// <term>The settings change was unsuccessful because the system is DualView capable.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADFLAGS</term>
		/// <term>An invalid set of flags was passed in.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADMODE</term>
		/// <term>The graphics mode is not supported.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_BADPARAM</term>
		/// <term>An invalid parameter was passed in. This can include an invalid flag or combination of flags.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_FAILED</term>
		/// <term>The display driver failed the specified graphics mode.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_NOTUPDATED</term>
		/// <term>Unable to write settings to the registry.</term>
		/// </item>
		/// <item>
		/// <term>DISP_CHANGE_RESTART</term>
		/// <term>The computer must be restarted for the graphics mode to work.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To ensure that the DEVMODE structure passed to <c>ChangeDisplaySettingsEx</c> is valid and contains only values supported by the
		/// display driver, use the <c>DEVMODE</c> returned by the EnumDisplaySettings function.
		/// </para>
		/// <para>
		/// When adding a display monitor to a multiple-monitor system programmatically, set <c>DEVMODE.dmFields</c> to DM_POSITION and
		/// specify a position (in <c>DEVMODE.dmPosition</c>) for the monitor you are adding that is adjacent to at least one pixel of the
		/// display area of an existing monitor. To detach the monitor, set <c>DEVMODE.dmFields</c> to DM_POSITION but set
		/// <c>DEVMODE.dmPelsWidth</c> and <c>DEVMODE.dmPelsHeight</c> to zero. For more information, see Multiple Display Monitors.
		/// </para>
		/// <para>
		/// When the display mode is changed dynamically, the WM_DISPLAYCHANGE message is sent to all running applications with the following
		/// message parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameters</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>wParam</term>
		/// <term>New bits per pixel</term>
		/// </item>
		/// <item>
		/// <term>LOWORD(lParam)</term>
		/// <term>New pixel width</term>
		/// </item>
		/// <item>
		/// <term>HIWORD(lParam)</term>
		/// <term>New pixel height</term>
		/// </item>
		/// </list>
		/// <para>
		/// To change the settings for more than one display at the same time, first call <c>ChangeDisplaySettingsEx</c> for each device
		/// individually to update the registry without applying the changes. Then call <c>ChangeDisplaySettingsEx</c> once more, with a
		/// <c>NULL</c> device, to apply the changes. For example, to change the settings for two displays, do the following:
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-changedisplaysettingsexa LONG ChangeDisplaySettingsExA(
		// LPCSTR lpszDeviceName, DEVMODEA *lpDevMode, HWND hwnd, DWORD dwflags, LPVOID lParam );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "1448e04c-1452-4eab-bda4-4d249cb67a24")]
		public static extern int ChangeDisplaySettingsEx([Optional] string lpszDeviceName, in DEVMODE lpDevMode, [Optional] HWND hwnd, [Optional] ChangeDisplaySettingsFlags dwflags, in VIDEOPARAMETERS lParam);

		/// <summary>
		/// Creates a new image (icon, cursor, or bitmap) and copies the attributes of the specified image to the new one. If necessary, the
		/// function stretches the bits to fit the desired size of the new image.
		/// </summary>
		/// <param name="h">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the image to be copied.</para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The type of image to be copied. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_BITMAP 0</term>
		/// <term>Copies a bitmap.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_CURSOR 2</term>
		/// <term>Copies a cursor.</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_ICON 1</term>
		/// <term>Copies an icon.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cx">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired width, in pixels, of the image. If this is zero, then the returned image will have the same width as the original hImage.
		/// </para>
		/// </param>
		/// <param name="cy">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The desired height, in pixels, of the image. If this is zero, then the returned image will have the same height as the original hImage.
		/// </para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LR_COPYDELETEORG 0x00000008</term>
		/// <term>Deletes the original image after creating the copy.</term>
		/// </item>
		/// <item>
		/// <term>LR_COPYFROMRESOURCE 0x00004000</term>
		/// <term>
		/// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This is
		/// useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this flag,
		/// CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource file closest
		/// to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with the LR_SHARED flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_COPYRETURNORG 0x00000004</term>
		/// <term>
		/// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which case
		/// the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_CREATEDIBSECTION 0x00002000</term>
		/// <term>
		/// If this is set and a new bitmap is created, the bitmap is created as a DIB section. Otherwise, the bitmap image is created as a
		/// device-dependent bitmap. This flag is only valid if uType is IMAGE_BITMAP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_DEFAULTSIZE 0x00000040</term>
		/// <term>
		/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set
		/// to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size.
		/// If the resource contains multiple images, the function uses the size of the first image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_MONOCHROME 0x00000001</term>
		/// <term>Creates a new monochrome image.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>If the function succeeds, the return value is the handle to the newly created image.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you are finished using the resource, you can release its associated memory by calling one of the functions in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Resource</term>
		/// <term>Release function</term>
		/// </listheader>
		/// <item>
		/// <term>Bitmap</term>
		/// <term>DeleteObject</term>
		/// </item>
		/// <item>
		/// <term>Cursor</term>
		/// <term>DestroyCursor</term>
		/// </item>
		/// <item>
		/// <term>Icon</term>
		/// <term>DestroyIcon</term>
		/// </item>
		/// </list>
		/// <para>
		/// The system automatically deletes the resource when its process terminates, however, calling the appropriate function saves memory
		/// and decreases the size of the process's working set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-copyimage HANDLE CopyImage( HANDLE h, UINT type, int cx,
		// int cy, UINT flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h")]
		public static extern HANDLE CopyImage(HANDLE h, LoadImageType type, int cx, int cy, CopyImageOptions flags);

		/// <summary>
		/// The DrawText function draws formatted text in the specified rectangle. It formats the text according to the specified method
		/// (expanding tabs, justifying characters, breaking lines, and so forth).
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lpchText">
		/// A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated.
		/// If uFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer
		/// containing the string should be large enough to accommodate these extra characters.
		/// </param>
		/// <param name="nCount">
		/// The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a
		/// null-terminated string and DrawText computes the character count automatically.
		/// </param>
		/// <param name="lpRect">
		/// A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.
		/// </param>
		/// <param name="uFormat">The method of formatting the text.</param>
		/// <returns>
		/// If the function succeeds, the return value is the height of the text in logical units. If DT_VCENTER or DT_BOTTOM is specified,
		/// the return value is the offset from lpRect-&gt;top to the bottom of the drawn text. If the function fails, the return value is zero.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd162498")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int DrawText(HDC hDC, string lpchText, int nCount, in RECT lpRect, DrawTextFlags uFormat);

		/// <summary>
		/// The DrawText function draws formatted text in the specified rectangle. It formats the text according to the specified method
		/// (expanding tabs, justifying characters, breaking lines, and so forth).
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lpchText">
		/// A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated.
		/// If uFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer
		/// containing the string should be large enough to accommodate these extra characters.
		/// </param>
		/// <param name="nCount">
		/// The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a
		/// null-terminated string and DrawText computes the character count automatically.
		/// </param>
		/// <param name="lpRect">
		/// A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.
		/// </param>
		/// <param name="uFormat">The method of formatting the text.</param>
		/// <returns>
		/// If the function succeeds, the return value is the height of the text in logical units. If DT_VCENTER or DT_BOTTOM is specified,
		/// the return value is the offset from lpRect-&gt;top to the bottom of the drawn text. If the function fails, the return value is zero.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd162498")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int DrawText(HDC hDC, StringBuilder lpchText, int nCount, in RECT lpRect, DrawTextFlags uFormat);

		/// <summary>The <c>DrawTextEx</c> function draws formatted text in the specified rectangle.</summary>
		/// <param name="hdc">A handle to the device context in which to draw.</param>
		/// <param name="lpchText">
		/// <para>A pointer to the string that contains the text to draw. If the cchText parameter is -1, the string must be null-terminated.</para>
		/// <para>
		/// If dwDTFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer
		/// containing the string should be large enough to accommodate these extra characters.
		/// </para>
		/// </param>
		/// <param name="cchText">
		/// The length of the string pointed to by lpchText. If cchText is -1, then the lpchText parameter is assumed to be a pointer to a
		/// null-terminated string and <c>DrawTextEx</c> computes the character count automatically.
		/// </param>
		/// <param name="lprc">
		/// A pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.
		/// </param>
		/// <param name="format">
		/// <para>The formatting options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DT_BOTTOM</term>
		/// <term>Justifies the text to the bottom of the rectangle. This value is used only with the DT_SINGLELINE value.</term>
		/// </item>
		/// <item>
		/// <term>DT_CALCRECT</term>
		/// <term>
		/// Determines the width and height of the rectangle. If there are multiple lines of text, DrawTextEx uses the width of the rectangle
		/// pointed to by the lprc parameter and extends the base of the rectangle to bound the last line of text. If there is only one line
		/// of text, DrawTextEx modifies the right side of the rectangle so that it bounds the last character in the line. In either case,
		/// DrawTextEx returns the height of the formatted text, but does not draw the text.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_CENTER</term>
		/// <term>Centers text horizontally in the rectangle.</term>
		/// </item>
		/// <item>
		/// <term>DT_EDITCONTROL</term>
		/// <term>
		/// Duplicates the text-displaying characteristics of a multiline edit control. Specifically, the average character width is
		/// calculated in the same manner as for an edit control, and the function does not display a partially visible last line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_END_ELLIPSIS</term>
		/// <term>
		/// For displayed text, replaces the end of a string with ellipses so that the result fits in the specified rectangle. Any word (not
		/// at the end of the string) that goes beyond the limits of the rectangle is truncated without ellipses. The string is not modified
		/// unless the DT_MODIFYSTRING flag is specified. Compare with DT_PATH_ELLIPSIS and DT_WORD_ELLIPSIS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_EXPANDTABS</term>
		/// <term>Expands tab characters. The default number of characters per tab is eight.</term>
		/// </item>
		/// <item>
		/// <term>DT_EXTERNALLEADING</term>
		/// <term>
		/// Includes the font external leading in line height. Normally, external leading is not included in the height of a line of text.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_HIDEPREFIX</term>
		/// <term>
		/// Ignores the ampersand (&amp;) prefix character in the text. The letter that follows will not be underlined, but other
		/// mnemonic-prefix characters are still processed. Example: input string: "A&amp;bc&amp;&amp;d" normal: "Ac&amp;d" DT_HIDEPREFIX:
		/// "Abc&amp;d" Compare with DT_NOPREFIX and DT_PREFIXONLY.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_INTERNAL</term>
		/// <term>Uses the system font to calculate text metrics.</term>
		/// </item>
		/// <item>
		/// <term>DT_LEFT</term>
		/// <term>Aligns text to the left.</term>
		/// </item>
		/// <item>
		/// <term>DT_MODIFYSTRING</term>
		/// <term>
		/// Modifies the specified string to match the displayed text. This value has no effect unless DT_END_ELLIPSIS or DT_PATH_ELLIPSIS is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_NOCLIP</term>
		/// <term>Draws without clipping. DrawTextEx is somewhat faster when DT_NOCLIP is used.</term>
		/// </item>
		/// <item>
		/// <term>DT_NOFULLWIDTHCHARBREAK</term>
		/// <term>
		/// Prevents a line break at a DBCS (double-wide character string), so that the line-breaking rule is equivalent to SBCS strings. For
		/// example, this can be used in Korean windows, for more readability of icon labels. This value has no effect unless DT_WORDBREAK is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_NOPREFIX</term>
		/// <term>
		/// Turns off processing of prefix characters. Normally, DrawTextEx interprets the ampersand (&amp;) mnemonic-prefix character as a
		/// directive to underscore the character that follows, and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a
		/// directive to print a single ampersand. By specifying DT_NOPREFIX, this processing is turned off. Compare with DT_HIDEPREFIX and DT_PREFIXONLY
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_PATH_ELLIPSIS</term>
		/// <term>
		/// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified
		/// rectangle. If the string contains backslash (\) characters, DT_PATH_ELLIPSIS preserves as much as possible of the text after the
		/// last backslash. The string is not modified unless the DT_MODIFYSTRING flag is specified. Compare with DT_END_ELLIPSIS and DT_WORD_ELLIPSIS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_PREFIXONLY</term>
		/// <term>
		/// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character. Does not draw any
		/// character in the string. Example: input string: "A&amp;bc&amp;&amp;d" normal: "Ac&amp;d" PREFIXONLY: " _ " Compare with
		/// DT_NOPREFIX and DT_HIDEPREFIX.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_RIGHT</term>
		/// <term>Aligns text to the right.</term>
		/// </item>
		/// <item>
		/// <term>DT_RTLREADING</term>
		/// <term>
		/// Layout in right-to-left reading order for bidirectional text when the font selected into the hdc is a Hebrew or Arabic font. The
		/// default reading order for all text is left-to-right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_SINGLELINE</term>
		/// <term>Displays text on a single line only. Carriage returns and line feeds do not break the line.</term>
		/// </item>
		/// <item>
		/// <term>DT_TABSTOP</term>
		/// <term>
		/// Sets tab stops. The DRAWTEXTPARAMS structure pointed to by the lpDTParams parameter specifies the number of average character
		/// widths per tab stop.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_TOP</term>
		/// <term>Justifies the text to the top of the rectangle.</term>
		/// </item>
		/// <item>
		/// <term>DT_VCENTER</term>
		/// <term>Centers text vertically. This value is used only with the DT_SINGLELINE value.</term>
		/// </item>
		/// <item>
		/// <term>DT_WORDBREAK</term>
		/// <term>
		/// Breaks words. Lines are automatically broken between words if a word extends past the edge of the rectangle specified by the lprc
		/// parameter. A carriage return-line feed sequence also breaks the line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_WORD_ELLIPSIS</term>
		/// <term>Truncates any word that does not fit in the rectangle and adds ellipses. Compare with DT_END_ELLIPSIS and DT_PATH_ELLIPSIS.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpdtp">
		/// A pointer to a DRAWTEXTPARAMS structure that specifies additional formatting options. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the text height in logical units. If DT_VCENTER or DT_BOTTOM is specified, the
		/// return value is the offset from to the bottom of the drawn text
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DrawTextEx</c> function supports only fonts whose escapement and orientation are both zero.</para>
		/// <para>The text alignment mode for the device context must include the TA_LEFT, TA_TOP, and TA_NOUPDATECP flags.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawtextexa int DrawTextExA( HDC hdc, LPSTR lpchText, int
		// cchText, LPRECT lprc, UINT format, LPDRAWTEXTPARAMS lpdtp );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "77b9973b-77f1-4508-a021-52d61d576c23")]
		public static extern int DrawTextEx(HDC hdc, string lpchText, int cchText, in RECT lprc, DrawTextFlags format, [Optional] DRAWTEXTPARAMS lpdtp);

		/// <summary>The <c>DrawTextEx</c> function draws formatted text in the specified rectangle.</summary>
		/// <param name="hdc">A handle to the device context in which to draw.</param>
		/// <param name="lpchText">
		/// <para>A pointer to the string that contains the text to draw. If the cchText parameter is -1, the string must be null-terminated.</para>
		/// <para>
		/// If dwDTFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer
		/// containing the string should be large enough to accommodate these extra characters.
		/// </para>
		/// </param>
		/// <param name="cchText">
		/// The length of the string pointed to by lpchText. If cchText is -1, then the lpchText parameter is assumed to be a pointer to a
		/// null-terminated string and <c>DrawTextEx</c> computes the character count automatically.
		/// </param>
		/// <param name="lprc">
		/// A pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be formatted.
		/// </param>
		/// <param name="format">
		/// <para>The formatting options. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DT_BOTTOM</term>
		/// <term>Justifies the text to the bottom of the rectangle. This value is used only with the DT_SINGLELINE value.</term>
		/// </item>
		/// <item>
		/// <term>DT_CALCRECT</term>
		/// <term>
		/// Determines the width and height of the rectangle. If there are multiple lines of text, DrawTextEx uses the width of the rectangle
		/// pointed to by the lprc parameter and extends the base of the rectangle to bound the last line of text. If there is only one line
		/// of text, DrawTextEx modifies the right side of the rectangle so that it bounds the last character in the line. In either case,
		/// DrawTextEx returns the height of the formatted text, but does not draw the text.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_CENTER</term>
		/// <term>Centers text horizontally in the rectangle.</term>
		/// </item>
		/// <item>
		/// <term>DT_EDITCONTROL</term>
		/// <term>
		/// Duplicates the text-displaying characteristics of a multiline edit control. Specifically, the average character width is
		/// calculated in the same manner as for an edit control, and the function does not display a partially visible last line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_END_ELLIPSIS</term>
		/// <term>
		/// For displayed text, replaces the end of a string with ellipses so that the result fits in the specified rectangle. Any word (not
		/// at the end of the string) that goes beyond the limits of the rectangle is truncated without ellipses. The string is not modified
		/// unless the DT_MODIFYSTRING flag is specified. Compare with DT_PATH_ELLIPSIS and DT_WORD_ELLIPSIS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_EXPANDTABS</term>
		/// <term>Expands tab characters. The default number of characters per tab is eight.</term>
		/// </item>
		/// <item>
		/// <term>DT_EXTERNALLEADING</term>
		/// <term>
		/// Includes the font external leading in line height. Normally, external leading is not included in the height of a line of text.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_HIDEPREFIX</term>
		/// <term>
		/// Ignores the ampersand (&amp;) prefix character in the text. The letter that follows will not be underlined, but other
		/// mnemonic-prefix characters are still processed. Example: input string: "A&amp;bc&amp;&amp;d" normal: "Ac&amp;d" DT_HIDEPREFIX:
		/// "Abc&amp;d" Compare with DT_NOPREFIX and DT_PREFIXONLY.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_INTERNAL</term>
		/// <term>Uses the system font to calculate text metrics.</term>
		/// </item>
		/// <item>
		/// <term>DT_LEFT</term>
		/// <term>Aligns text to the left.</term>
		/// </item>
		/// <item>
		/// <term>DT_MODIFYSTRING</term>
		/// <term>
		/// Modifies the specified string to match the displayed text. This value has no effect unless DT_END_ELLIPSIS or DT_PATH_ELLIPSIS is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_NOCLIP</term>
		/// <term>Draws without clipping. DrawTextEx is somewhat faster when DT_NOCLIP is used.</term>
		/// </item>
		/// <item>
		/// <term>DT_NOFULLWIDTHCHARBREAK</term>
		/// <term>
		/// Prevents a line break at a DBCS (double-wide character string), so that the line-breaking rule is equivalent to SBCS strings. For
		/// example, this can be used in Korean windows, for more readability of icon labels. This value has no effect unless DT_WORDBREAK is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_NOPREFIX</term>
		/// <term>
		/// Turns off processing of prefix characters. Normally, DrawTextEx interprets the ampersand (&amp;) mnemonic-prefix character as a
		/// directive to underscore the character that follows, and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a
		/// directive to print a single ampersand. By specifying DT_NOPREFIX, this processing is turned off. Compare with DT_HIDEPREFIX and DT_PREFIXONLY
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_PATH_ELLIPSIS</term>
		/// <term>
		/// For displayed text, replaces characters in the middle of the string with ellipses so that the result fits in the specified
		/// rectangle. If the string contains backslash (\) characters, DT_PATH_ELLIPSIS preserves as much as possible of the text after the
		/// last backslash. The string is not modified unless the DT_MODIFYSTRING flag is specified. Compare with DT_END_ELLIPSIS and DT_WORD_ELLIPSIS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_PREFIXONLY</term>
		/// <term>
		/// Draws only an underline at the position of the character following the ampersand (&amp;) prefix character. Does not draw any
		/// character in the string. Example: input string: "A&amp;bc&amp;&amp;d" normal: "Ac&amp;d" PREFIXONLY: " _ " Compare with
		/// DT_NOPREFIX and DT_HIDEPREFIX.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_RIGHT</term>
		/// <term>Aligns text to the right.</term>
		/// </item>
		/// <item>
		/// <term>DT_RTLREADING</term>
		/// <term>
		/// Layout in right-to-left reading order for bidirectional text when the font selected into the hdc is a Hebrew or Arabic font. The
		/// default reading order for all text is left-to-right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_SINGLELINE</term>
		/// <term>Displays text on a single line only. Carriage returns and line feeds do not break the line.</term>
		/// </item>
		/// <item>
		/// <term>DT_TABSTOP</term>
		/// <term>
		/// Sets tab stops. The DRAWTEXTPARAMS structure pointed to by the lpDTParams parameter specifies the number of average character
		/// widths per tab stop.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_TOP</term>
		/// <term>Justifies the text to the top of the rectangle.</term>
		/// </item>
		/// <item>
		/// <term>DT_VCENTER</term>
		/// <term>Centers text vertically. This value is used only with the DT_SINGLELINE value.</term>
		/// </item>
		/// <item>
		/// <term>DT_WORDBREAK</term>
		/// <term>
		/// Breaks words. Lines are automatically broken between words if a word extends past the edge of the rectangle specified by the lprc
		/// parameter. A carriage return-line feed sequence also breaks the line.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DT_WORD_ELLIPSIS</term>
		/// <term>Truncates any word that does not fit in the rectangle and adds ellipses. Compare with DT_END_ELLIPSIS and DT_PATH_ELLIPSIS.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpdtp">
		/// A pointer to a DRAWTEXTPARAMS structure that specifies additional formatting options. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the text height in logical units. If DT_VCENTER or DT_BOTTOM is specified, the
		/// return value is the offset from to the bottom of the drawn text
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DrawTextEx</c> function supports only fonts whose escapement and orientation are both zero.</para>
		/// <para>The text alignment mode for the device context must include the TA_LEFT, TA_TOP, and TA_NOUPDATECP flags.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawtextexa int DrawTextExA( HDC hdc, LPSTR lpchText, int
		// cchText, LPRECT lprc, UINT format, LPDRAWTEXTPARAMS lpdtp );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "77b9973b-77f1-4508-a021-52d61d576c23")]
		public static extern int DrawTextEx(HDC hdc, StringBuilder lpchText, int cchText, in RECT lprc, DrawTextFlags format, [Optional] DRAWTEXTPARAMS lpdtp);

		/// <summary>
		/// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire
		/// screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data
		/// structure, whose values are used internally by GDI.
		/// </summary>
		/// <param name="ptr">
		/// A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the DC for the specified window's client area. If the function fails,
		/// the return value is NULL.
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/dd144871(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "dd144871")]
		public static extern SafeHDC GetDC(HWND ptr);

		/// <summary>
		/// <para>
		/// The <c>GetDCEx</c> function retrieves a handle to a device context (DC) for the client area of a specified window or for the
		/// entire screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque
		/// data structure, whose values are used internally by GDI.
		/// </para>
		/// <para>
		/// This function is an extension to the GetDC function, which gives an application more control over how and whether clipping occurs
		/// in the client area.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window whose DC is to be retrieved. If this value is <c>NULL</c>, <c>GetDCEx</c> retrieves the DC for the entire screen.
		/// </param>
		/// <param name="hrgnClip">
		/// A clipping region that may be combined with the visible region of the DC. If the value of flags is DCX_INTERSECTRGN or
		/// DCX_EXCLUDERGN, then the operating system assumes ownership of the region and will automatically delete it when it is no longer
		/// needed. In this case, the application should not use or delete the region after a successful call to <c>GetDCEx</c>.
		/// </param>
		/// <param name="flags">
		/// <para>Specifies how the DC is created. This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DCX_WINDOW</term>
		/// <term>Returns a DC that corresponds to the window rectangle rather than the client rectangle.</term>
		/// </item>
		/// <item>
		/// <term>DCX_CACHE</term>
		/// <term>Returns a DC from the cache, rather than the OWNDC or CLASSDC window. Essentially overrides CS_OWNDC and CS_CLASSDC.</term>
		/// </item>
		/// <item>
		/// <term>DCX_PARENTCLIP</term>
		/// <term>
		/// Uses the visible region of the parent window. The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin is
		/// set to the upper-left corner of the window identified by hWnd.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DCX_CLIPSIBLINGS</term>
		/// <term>Excludes the visible regions of all sibling windows above the window identified by hWnd.</term>
		/// </item>
		/// <item>
		/// <term>DCX_CLIPCHILDREN</term>
		/// <term>Excludes the visible regions of all child windows below the window identified by hWnd.</term>
		/// </item>
		/// <item>
		/// <term>DCX_NORESETATTRS</term>
		/// <term>This flag is ignored.</term>
		/// </item>
		/// <item>
		/// <term>DCX_LOCKWINDOWUPDATE</term>
		/// <term>
		/// Allows drawing even if there is a LockWindowUpdate call in effect that would otherwise exclude this window. Used for drawing
		/// during tracking.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DCX_EXCLUDERGN</term>
		/// <term>The clipping region identified by hrgnClip is excluded from the visible region of the returned DC.</term>
		/// </item>
		/// <item>
		/// <term>DCX_INTERSECTRGN</term>
		/// <term>The clipping region identified by hrgnClip is intersected with the visible region of the returned DC.</term>
		/// </item>
		/// <item>
		/// <term>DCX_INTERSECTUPDATE</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// <item>
		/// <term>DCX_VALIDATE</term>
		/// <term>Reserved; do not use.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the DC for the specified window.</para>
		/// <para>
		/// If the function fails, the return value is <c>NULL</c>. An invalid value for the hWnd parameter will cause the function to fail.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Unless the display DC belongs to a window class, the ReleaseDC function must be called to release the DC after painting. Also,
		/// <c>ReleaseDC</c> must be called from the same thread that called <c>GetDCEx</c>. The number of DCs is limited only by available memory.
		/// </para>
		/// <para>
		/// The function returns a handle to a DC that belongs to the window's class if CS_CLASSDC, CS_OWNDC or CS_PARENTDC was specified as
		/// a style in the WNDCLASS structure when the class was registered.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdcex HDC GetDCEx( HWND hWnd, HRGN hrgnClip, DWORD flags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "590cf928-0ad6-43f8-97e9-1dafbcfa9f49")]
		public static extern HDC GetDCEx(HWND hWnd, HRGN hrgnClip, DCX flags);

		/// <summary>Retrieves the count of handles to graphical user interface (GUI) objects in use by the specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right. For more information, see
		/// Process Security and Access Rights.
		/// </param>
		/// <param name="uiFlags">
		/// <para>The GUI object type. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GR_GDIOBJECTS 0</term>
		/// <term>Return the count of GDI objects.</term>
		/// </item>
		/// <item>
		/// <term>GR_GDIOBJECTS_PEAK 2</term>
		/// <term>
		/// Return the peak count of GDI objects. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not
		/// supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GR_USEROBJECTS 1</term>
		/// <term>Return the count of USER objects.</term>
		/// </item>
		/// <item>
		/// <term>GR_USEROBJECTS_PEAK 4</term>
		/// <term>
		/// Return the peak count of USER objects. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not
		/// supported until Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the count of handles to GUI objects in use by the process. If no GUI objects are in
		/// use, the return value is zero.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// A process without a graphical user interface does not use GUI resources, therefore, <c>GetGuiResources</c> will return zero.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getguiresources DWORD GetGuiResources( HANDLE hProcess,
		// DWORD uiFlags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "55fbb7e8-79b4-4011-b522-25ea5a928b86")]
		public static extern uint GetGuiResources(HPROCESS hProcess, GR uiFlags);

		/// <summary>
		/// Retrieves the current color of the specified display element. Display elements are the parts of a window and the display that
		/// appear on the system display screen.
		/// </summary>
		/// <param name="nIndex">The display element whose color is to be retrieved.</param>
		/// <returns>
		/// The function returns the red, green, blue (RGB) color value of the given element.
		/// <para>
		/// If the nIndex parameter is out of range, the return value is zero.Because zero is also a valid RGB value, you cannot use
		/// GetSysColor to determine whether a system color is supported by the current platform.Instead, use the GetSysColorBrush function,
		/// which returns NULL if the color is not supported.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "ms724371")]
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		public static extern COLORREF GetSysColor(SystemColorIndex nIndex);

		/// <summary>
		/// The GetSysColorBrush function retrieves a handle identifying a logical brush that corresponds to the specified color index.
		/// </summary>
		/// <param name="nIndex">
		/// A color index. This value corresponds to the color used to paint one of the window elements. See GetSysColor for system color
		/// index values.
		/// </param>
		/// <returns>
		/// he return value identifies a logical brush if the nIndex parameter is supported by the current platform. Otherwise, it returns NULL.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd144927")]
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		public static extern HBRUSH GetSysColorBrush(SystemColorIndex nIndex);

		/// <summary>
		/// The <c>GetTabbedTextExtent</c> function computes the width and height of a character string. If the string contains one or more
		/// tab characters, the width of the string is based upon the specified tab stops. The <c>GetTabbedTextExtent</c> function uses the
		/// currently selected font to compute the dimensions of the string.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="lpString">A pointer to a character string.</param>
		/// <param name="chCount">
		/// The length of the text string. For the ANSI function it is a BYTE count and for the Unicode function it is a WORD count. Note
		/// that for the ANSI function, characters in SBCS code pages take one byte each, while most characters in DBCS code pages take two
		/// bytes; for the Unicode function, most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are one
		/// WORD while Unicode surrogates are two WORDs.
		/// </param>
		/// <param name="nTabPositions">The number of tab-stop positions in the array pointed to by the lpnTabStopPositions parameter.</param>
		/// <param name="lpnTabStopPositions">
		/// A pointer to an array containing the tab-stop positions, in device units. The tab stops must be sorted in increasing order; the
		/// smallest x-value should be the first item in the array.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the dimensions of the string in logical units. The height is in the high-order word
		/// and the width is in the low-order word.
		/// </para>
		/// <para>
		/// If the function fails, the return value is 0. <c>GetTabbedTextExtent</c> will fail if hDC is invalid and if nTabPositions is less
		/// than 0.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The current clipping region does not affect the width and height returned by the <c>GetTabbedTextExtent</c> function.</para>
		/// <para>
		/// Because some devices do not place characters in regular cell arrays (that is, they kern the characters), the sum of the extents
		/// of the characters in a string may not be equal to the extent of the string.
		/// </para>
		/// <para>
		/// If the nTabPositions parameter is zero and the lpnTabStopPositions parameter is <c>NULL</c>, tabs are expanded to eight times the
		/// average character width.
		/// </para>
		/// <para>
		/// If nTabPositions is 1, the tab stops are separated by the distance specified by the first value in the array to which
		/// lpnTabStopPositions points.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gettabbedtextextenta DWORD GetTabbedTextExtentA( HDC hdc,
		// LPCSTR lpString, int chCount, int nTabPositions, const INT *lpnTabStopPositions );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "3444bb8d-4a30-47d4-b211-01f7cba39975")]
		public static extern uint GetTabbedTextExtent(HDC hdc, string lpString, int chCount, int nTabPositions, [In] int[] lpnTabStopPositions);

		/// <summary>
		/// The <c>GetTabbedTextExtent</c> function computes the width and height of a character string. If the string contains one or more
		/// tab characters, the width of the string is based upon the specified tab stops. The <c>GetTabbedTextExtent</c> function uses the
		/// currently selected font to compute the dimensions of the string.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="lpString">A pointer to a character string.</param>
		/// <param name="lpnTabStopPositions">
		/// A pointer to an array containing the tab-stop positions, in device units. The tab stops must be sorted in increasing order; the
		/// smallest x-value should be the first item in the array.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the dimensions of the string in logical units.</para>
		/// <para>
		/// If the function fails, the return value is Size.Empty. <c>GetTabbedTextExtent</c> will fail if hDC is invalid and if
		/// nTabPositions is less than 0.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The current clipping region does not affect the width and height returned by the <c>GetTabbedTextExtent</c> function.</para>
		/// <para>
		/// Because some devices do not place characters in regular cell arrays (that is, they kern the characters), the sum of the extents
		/// of the characters in a string may not be equal to the extent of the string.
		/// </para>
		/// <para>
		/// If the nTabPositions parameter is zero and the lpnTabStopPositions parameter is <c>NULL</c>, tabs are expanded to eight times the
		/// average character width.
		/// </para>
		/// <para>
		/// If nTabPositions is 1, the tab stops are separated by the distance specified by the first value in the array to which
		/// lpnTabStopPositions points.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gettabbedtextextenta DWORD GetTabbedTextExtentA( HDC hdc,
		// LPCSTR lpString, int chCount, int nTabPositions, const INT *lpnTabStopPositions );
		[PInvokeData("winuser.h", MSDNShortId = "3444bb8d-4a30-47d4-b211-01f7cba39975")]
		public static Size GetTabbedTextExtent(HDC hdc, string lpString, int[] lpnTabStopPositions)
		{
			var ret = GetTabbedTextExtent(hdc, lpString, lpString?.Length ?? 0, lpnTabStopPositions?.Length ?? 0, lpnTabStopPositions);
			return new Size(Macros.LOWORD(ret), Macros.HIWORD(ret));
		}

		/// <summary>The <c>GetUserObjectSecurity</c> function retrieves security information for the specified user object.</summary>
		/// <param name="hObj">A handle to the user object for which to return security information.</param>
		/// <param name="pSIRequested">A pointer to a SECURITY_INFORMATION value that specifies the security information being requested.</param>
		/// <param name="pSID">
		/// A pointer to a SECURITY_DESCRIPTOR structure in self-relative format that contains the requested information when the function
		/// returns. This buffer must be aligned on a 4-byte boundary.
		/// </param>
		/// <param name="nLength">The length, in bytes, of the buffer pointed to by the pSD parameter.</param>
		/// <param name="lpnLengthNeeded">
		/// A pointer to a variable to receive the number of bytes required to store the complete security descriptor. If this variable's
		/// value is greater than the value of the nLength parameter when the function returns, the function returns <c>FALSE</c> and none of
		/// the security descriptor is copied to the buffer. Otherwise, the entire security descriptor is copied.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To read the owner, group, or discretionary access control list (DACL) from the user object's security descriptor, the calling
		/// process must have been granted READ_CONTROL access when the handle was opened.
		/// </para>
		/// <para>
		/// To read the system access control list (SACL) from the security descriptor, the calling process must have been granted
		/// ACCESS_SYSTEM_SECURITY access when the handle was opened. The correct way to get this access is to enable the SE_SECURITY_NAME
		/// privilege in the caller's current token, open the handle for ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Starting an Interactive Client Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getuserobjectsecurity BOOL GetUserObjectSecurity( HANDLE
		// hObj, PSECURITY_INFORMATION pSIRequested, PSECURITY_DESCRIPTOR pSID, DWORD nLength, LPDWORD lpnLengthNeeded );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "998c2520-7833-4efd-a794-b13b528f0485")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUserObjectSecurity(HANDLE hObj, in SECURITY_INFORMATION pSIRequested, PSECURITY_DESCRIPTOR pSID,
			uint nLength, out uint lpnLengthNeeded);

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus four; for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the
		/// third 32-bit integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern int GetWindowLong(HWND hWnd, WindowLongFlags nIndex);

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		public static IntPtr GetWindowLongAuto(HWND hWnd, WindowLongFlags nIndex)
		{
			IntPtr ret;
			if (IntPtr.Size == 4)
				ret = (IntPtr)GetWindowLong(hWnd, nIndex);
			else
				ret = GetWindowLongPtr(hWnd, nIndex);
			if (ret == IntPtr.Zero)
				throw new System.ComponentModel.Win32Exception();
			return ret;
		}

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern IntPtr GetWindowLongPtr(HWND hWnd, WindowLongFlags nIndex);

		/// <summary>
		/// <para>
		/// [ <c>LoadBitmap</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
		/// unavailable in subsequent versions. Instead, use LoadImage and DrawFrameControl.]
		/// </para>
		/// <para>The <c>LoadBitmap</c> function loads the specified bitmap resource from a module's executable file.</para>
		/// </summary>
		/// <param name="hInstance">A handle to the instance of the module whose executable file contains the bitmap to be loaded.</param>
		/// <param name="lpBitmapName">
		/// A pointer to a null-terminated string that contains the name of the bitmap resource to be loaded. Alternatively, this parameter
		/// can consist of the resource identifier in the low-order word and zero in the high-order word. The MAKEINTRESOURCE macro can be
		/// used to create this value.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to the specified bitmap.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the bitmap pointed to by the lpBitmapName parameter does not exist or there is insufficient memory to load the bitmap, the
		/// function fails.
		/// </para>
		/// <para>
		/// <c>LoadBitmap</c> creates a compatible bitmap of the display, which cannot be selected to a printer. To load a bitmap that you
		/// can select to a printer, call LoadImage and specify LR_CREATEDIBSECTION to create a DIB section. A DIB section can be selected to
		/// any device.
		/// </para>
		/// <para>
		/// An application can use the <c>LoadBitmap</c> function to access predefined bitmaps. To do so, the application must set the
		/// hInstance parameter to <c>NULL</c> and the lpBitmapName parameter to one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bitmap name</term>
		/// <term>Bitmap name</term>
		/// </listheader>
		/// <item>
		/// <term>OBM_BTNCORNERS</term>
		/// <term>OBM_OLD_RESTORE</term>
		/// </item>
		/// <item>
		/// <term>OBM_BTSIZE</term>
		/// <term>OBM_OLD_RGARROW</term>
		/// </item>
		/// <item>
		/// <term>OBM_CHECK</term>
		/// <term>OBM_OLD_UPARROW</term>
		/// </item>
		/// <item>
		/// <term>OBM_CHECKBOXES</term>
		/// <term>OBM_OLD_ZOOM</term>
		/// </item>
		/// <item>
		/// <term>OBM_CLOSE</term>
		/// <term>OBM_REDUCE</term>
		/// </item>
		/// <item>
		/// <term>OBM_COMBO</term>
		/// <term>OBM_REDUCED</term>
		/// </item>
		/// <item>
		/// <term>OBM_DNARROW</term>
		/// <term>OBM_RESTORE</term>
		/// </item>
		/// <item>
		/// <term>OBM_DNARROWD</term>
		/// <term>OBM_RESTORED</term>
		/// </item>
		/// <item>
		/// <term>OBM_DNARROWI</term>
		/// <term>OBM_RGARROW</term>
		/// </item>
		/// <item>
		/// <term>OBM_LFARROW</term>
		/// <term>OBM_RGARROWD</term>
		/// </item>
		/// <item>
		/// <term>OBM_LFARROWD</term>
		/// <term>OBM_RGARROWI</term>
		/// </item>
		/// <item>
		/// <term>OBM_LFARROWI</term>
		/// <term>OBM_SIZE</term>
		/// </item>
		/// <item>
		/// <term>OBM_MNARROW</term>
		/// <term>OBM_UPARROW</term>
		/// </item>
		/// <item>
		/// <term>OBM_OLD_CLOSE</term>
		/// <term>OBM_UPARROWD</term>
		/// </item>
		/// <item>
		/// <term>OBM_OLD_DNARROW</term>
		/// <term>OBM_UPARROWI</term>
		/// </item>
		/// <item>
		/// <term>OBM_OLD_LFARROW</term>
		/// <term>OBM_ZOOM</term>
		/// </item>
		/// <item>
		/// <term>OBM_OLD_REDUCE</term>
		/// <term>OBM_ZOOMD</term>
		/// </item>
		/// </list>
		/// <para>Bitmap names that begin with OBM_OLD represent bitmaps used by 16-bit versions of Windows earlier than 3.0.</para>
		/// <para>
		/// For an application to use any of the OBM_ constants, the constant OEMRESOURCE must be defined before the Windows.h header file is included.
		/// </para>
		/// <para>The application must call the DeleteObject function to delete each bitmap handle returned by the <c>LoadBitmap</c> function.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Example of Menu-Item Bitmaps in Using Menus.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadbitmapa HBITMAP LoadBitmapA( HINSTANCE hInstance,
		// LPCSTR lpBitmapName );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "5eed5f78-deaf-4b23-986e-4802dc05936c")]
		public static extern SafeHBITMAP LoadBitmap(HINSTANCE hInstance, [In] SafeResourceId lpBitmapName);

		/// <summary>
		/// The <c>ReleaseDC</c> function releases a device context (DC), freeing it for use by other applications. The effect of the
		/// <c>ReleaseDC</c> function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose DC is to be released.</param>
		/// <param name="hDC">A handle to the DC to be released.</param>
		/// <returns>
		/// <para>The return value indicates whether the DC was released. If the DC was released, the return value is 1.</para>
		/// <para>If the DC was not released, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The application must call the <c>ReleaseDC</c> function for each call to the GetWindowDC function and for each call to the GetDC
		/// function that retrieves a common DC.
		/// </para>
		/// <para>
		/// An application cannot use the <c>ReleaseDC</c> function to release a DC that was created by calling the CreateDC function;
		/// instead, it must use the DeleteDC function. <c>ReleaseDC</c> must be called from the same thread that called GetDC.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Scaling an Image.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-releasedc int ReleaseDC( HWND hWnd, HDC hDC );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c4f48f1e-4a37-4330-908e-2ac5c65e1a1d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReleaseDC(HWND hWnd, HDC hDC);

		/// <summary>
		/// <para>
		/// Sets the colors for the specified display elements. Display elements are the various parts of a window and the display that
		/// appear on the system display screen.
		/// </para>
		/// </summary>
		/// <param name="cElements">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of display elements in the lpaElements array.</para>
		/// </param>
		/// <param name="lpaElements">
		/// <para>Type: <c>const INT*</c></para>
		/// <para>An array of integers that specify the display elements to be changed. For a list of display elements, see GetSysColor.</para>
		/// </param>
		/// <param name="lpaRgbValues">
		/// <para>Type: <c>const COLORREF*</c></para>
		/// <para>
		/// An array of COLORREF values that contain the new red, green, blue (RGB) color values for the display elements in the array
		/// pointed to by the lpaElements parameter.
		/// </para>
		/// <para>To generate a COLORREF, use the RGB macro.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetSysColors</c> function sends a WM_SYSCOLORCHANGE message to all windows to inform them of the change in color. It also
		/// directs the system to repaint the affected portions of all currently visible windows.
		/// </para>
		/// <para>
		/// It is best to respect the color settings specified by the user. If you are writing an application to enable the user to change
		/// the colors, then it is appropriate to use this function. However, this function affects only the current session. The new colors
		/// are not saved when the system terminates.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates the use of the GetSysColor and <c>SetSysColors</c> functions. First, the example uses
		/// <c>GetSysColor</c> to retrieve the colors of the window background and active caption and displays the red, green, blue (RGB)
		/// values in hexadecimal notation. Next, example uses <c>SetSysColors</c> to change the color of the window background to light gray
		/// and the active title bars to dark purple. After a 10-second delay, the example restores the previous colors for these elements
		/// using SetSysColors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setsyscolors BOOL SetSysColors( int cElements, CONST INT
		// *lpaElements, CONST COLORREF *lpaRgbValues );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "41a7a96c-f9d1-44e3-a7e1-fd7d155c4ed0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSysColors(int cElements, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4, SizeConst = 0)] SystemColorIndex[] lpaElements, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 0)] COLORREF[] lpaRgbValues);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		public static IntPtr SetWindowLong(HWND hWnd, WindowLongFlags nIndex, IntPtr dwNewLong)
		{
			IntPtr ret;
			if (IntPtr.Size == 4)
				ret = (IntPtr)SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
			else
				ret = SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			if (ret == IntPtr.Zero)
				throw new System.ComponentModel.Win32Exception();
			return ret;
		}

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		public static int SetWindowLong(HWND hWnd, WindowLongFlags nIndex, int dwNewLong)
		{
			IntPtr ret;
			if (IntPtr.Size == 4)
				ret = (IntPtr)SetWindowLongPtr32(hWnd, nIndex, (IntPtr)dwNewLong);
			else
				ret = SetWindowLongPtr64(hWnd, nIndex, (IntPtr)dwNewLong);
			if (ret == IntPtr.Zero)
				throw new System.ComponentModel.Win32Exception();
			return ret.ToInt32();
		}

		/// <summary>
		/// The <c>TabbedTextOut</c> function writes a character string at a specified location, expanding tabs to the values specified in an
		/// array of tab-stop positions. Text is written in the currently selected font, background color, and text color.
		/// </summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="x">The x-coordinate of the starting point of the string, in logical units.</param>
		/// <param name="y">The y-coordinate of the starting point of the string, in logical units.</param>
		/// <param name="lpString">
		/// A pointer to the character string to draw. The string does not need to be zero-terminated, since nCount specifies the length of
		/// the string.
		/// </param>
		/// <param name="chCount">The length of the string pointed to by lpString.</param>
		/// <param name="nTabPositions">The number of values in the array of tab-stop positions.</param>
		/// <param name="lpnTabStopPositions">
		/// A pointer to an array containing the tab-stop positions, in logical units. The tab stops must be sorted in increasing order; the
		/// smallest x-value should be the first item in the array.
		/// </param>
		/// <param name="nTabOrigin">The x-coordinate of the starting position from which tabs are expanded, in logical units.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the dimensions, in logical units, of the string. The height is in the high-order
		/// word and the width is in the low-order word.
		/// </para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the nTabPositions parameter is zero and the lpnTabStopPositions parameter is <c>NULL</c>, tabs are expanded to eight times the
		/// average character width.
		/// </para>
		/// <para>
		/// If nTabPositions is 1, the tab stops are separated by the distance specified by the first value in the lpnTabStopPositions array.
		/// </para>
		/// <para>
		/// If the lpnTabStopPositions array contains more than one value, a tab stop is set for each value in the array, up to the number
		/// specified by nTabPositions.
		/// </para>
		/// <para>
		/// The nTabOrigin parameter allows an application to call the <c>TabbedTextOut</c> function several times for a single line. If the
		/// application calls <c>TabbedTextOut</c> more than once with the nTabOrigin set to the same value each time, the function expands
		/// all tabs relative to the position specified by nTabOrigin.
		/// </para>
		/// <para>
		/// By default, the current position is not used or updated by the <c>TabbedTextOut</c> function. If an application needs to update
		/// the current position when it calls <c>TabbedTextOut</c>, the application can call the SetTextAlign function with the wFlags
		/// parameter set to TA_UPDATECP. When this flag is set, the system ignores the X and Y parameters on subsequent calls to the
		/// <c>TabbedTextOut</c> function, using the current position instead.
		/// </para>
		/// <para><c>Note</c> For Windows Vista and later, <c>TabbedTextOut</c> ignores text alignment when it draws text.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-tabbedtextouta LONG TabbedTextOutA( HDC hdc, int x, int y,
		// LPCSTR lpString, int chCount, int nTabPositions, const INT *lpnTabStopPositions, int nTabOrigin );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "1cb78a75-752d-4e06-afdf-cd797f209114")]
		public static extern int TabbedTextOut(HDC hdc, int x, int y, string lpString, int chCount, [Optional] int nTabPositions, [In, Optional] int[] lpnTabStopPositions, int nTabOrigin);

		/// <summary>
		/// The <c>WindowFromDC</c> function returns a handle to the window associated with the specified display device context (DC). Output
		/// functions that use the specified device context draw into this window.
		/// </summary>
		/// <param name="hDC">Handle to the device context from which a handle to the associated window is to be retrieved.</param>
		/// <returns>
		/// The return value is a handle to the window associated with the specified DC. If no window is associated with the specified DC,
		/// the return value is <c>NULL</c>.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-windowfromdc HWND WindowFromDC( HDC hDC );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "57ecec82-03be-4d1a-84cf-6b64131af19d")]
		public static extern HWND WindowFromDC(HDC hDC);

		private static SafeCoTaskMemHandle GetPtr<T>(in T val) => SafeCoTaskMemHandle.CreateFromStructure(val);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		private static IntPtr SendMessageUnmanaged<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, in TWP wParam, ref TLP lParam)
			where TEnum : struct, IConvertible where TWP : unmanaged where TLP : unmanaged
		{
			var m = (uint)Convert.ChangeType(msg, typeof(uint));
			unsafe
			{
				fixed (void* wp = &wParam, lp = &lParam)
				{
					return (IntPtr)SendMessageUnsafe((void*)(IntPtr)hWnd, m, wp, lp);
				}
			}
		}

		/// <summary>
		/// The <c>SetUserObjectSecurity</c> function sets the security of a user object. This can be, for example, a window or a DDE conversation.
		/// </summary>
		/// <param name="hObj">A handle to a user object for which security information is set.</param>
		/// <param name="pSIRequested">
		/// <para>
		/// A pointer to a value that indicates the components of the security descriptor to set. This parameter can be a combination of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Sets the discretionary access control list (DACL) of the object. The handle specified by hObj must have WRITE_DAC access, or the
		/// calling process must be the owner of the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GROUP_SECURITY_INFORMATION</term>
		/// <term>Sets the primary group security identifier (SID) of the object.</term>
		/// </item>
		/// <item>
		/// <term>OWNER_SECURITY_INFORMATION</term>
		/// <term>
		/// Sets the SID of the owner of the object. The handle specified by hObj must have WRITE_OWNER access, or the calling process must
		/// be the owner of the object or have the SE_TAKE_OWNERSHIP_NAME privilege enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Sets the system access control list (SACL) of the object. The handle specified by hObj must have ACCESS_SYSTEM_SECURITY access.
		/// To obtain ACCESS_SYSTEM_SECURITY access
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pSID">
		/// <para>A pointer to a SECURITY_DESCRIPTOR structure that contains the new security information.</para>
		/// <para>This buffer must be aligned on a 4-byte boundary.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetUserObjectSecurity</c> function applies changes specified in a security descriptor to the security descriptor assigned
		/// to a user object. The security descriptor of the object must be in self-relative form. If necessary, this function allocates
		/// additional memory to increase the size of the security descriptor.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Starting an Interactive Client Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setuserobjectsecurity BOOL SetUserObjectSecurity( HANDLE
		// hObj, PSECURITY_INFORMATION pSIRequested, PSECURITY_DESCRIPTOR pSID );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "219e41b8-9ac7-4747-a585-b6b9df6a1c9c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetUserObjectSecurity(HANDLE hObj, in SECURITY_INFORMATION pSIRequested, PSECURITY_DESCRIPTOR pSID);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLong")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		private static extern int SetWindowLongPtr32(HWND hWnd, WindowLongFlags nIndex, IntPtr dwNewLong);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLongPtr")]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		private static extern IntPtr SetWindowLongPtr64(HWND hWnd, WindowLongFlags nIndex, IntPtr dwNewLong);

		/// <summary>
		/// Grants or denies access to a handle to a User object to a job that has a user-interface restriction. When access is granted, all
		/// processes associated with the job can subsequently recognize and use the handle. When access is denied, the processes can no
		/// longer use the handle. For more information see User Objects.
		/// </summary>
		/// <param name="hUserHandle">A handle to the User object.</param>
		/// <param name="hJob">
		/// A handle to the job to be granted access to the User handle. The CreateJobObject or OpenJobObject function returns this handle.
		/// </param>
		/// <param name="bGrant">
		/// If this parameter is TRUE, all processes associated with the job can recognize and use the handle. If the parameter is FALSE, the
		/// processes cannot use the handle.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>UserHandleGrantAccess</c> function can be called only from a process not associated with the job specified by the hJob
		/// parameter. The User handle must not be owned by a process or thread associated with the job.
		/// </para>
		/// <para>
		/// To create user-interface restrictions, call the SetInformationJobObject function with the JobObjectBasicUIRestrictions job
		/// information class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-userhandlegrantaccess BOOL UserHandleGrantAccess( HANDLE
		// hUserHandle, HANDLE hJob, BOOL bGrant );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "6e7a6cfc-f881-43cc-a5af-b97e0bf14bf4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UserHandleGrantAccess(HANDLE hUserHandle, HANDLE hJob, [MarshalAs(UnmanagedType.Bool)] bool bGrant);

		/// <summary>Contains information about a window's maximized size and position and its minimum and maximum tracking size.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MINMAXINFO
		{
			/// <summary>Reserved; do not use.</summary>
			public Point reserved;

			/// <summary>
			/// The maximized width (x member) and the maximized height (y member) of the window. For top-level windows, this value is based
			/// on the width of the primary monitor.
			/// </summary>
			public Size maxSize;

			/// <summary>
			/// The position of the left side of the maximized window (x member) and the position of the top of the maximized window (y
			/// member). For top-level windows, this value is based on the position of the primary monitor.
			/// </summary>
			public Point maxPosition;

			/// <summary>
			/// The minimum tracking width (x member) and the minimum tracking height (y member) of the window. This value can be obtained
			/// programmatically from the system metrics SM_CXMINTRACK and SM_CYMINTRACK (see the GetSystemMetrics function).
			/// </summary>
			public Size minTrackSize;

			/// <summary>
			/// The maximum tracking width (x member) and the maximum tracking height (y member) of the window. This value is based on the
			/// size of the virtual screen and can be obtained programmatically from the system metrics SM_CXMAXTRACK and SM_CYMAXTRACK (see
			/// the GetSystemMetrics function).
			/// </summary>
			public Size maxTrackSize;
		}

		/// <summary>Contains information about the size and position of a window.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPOS
		{
			/// <summary>A handle to the window.</summary>
			public HWND hwnd;

			/// <summary>
			/// The position of the window in Z order (front-to-back position). This member can be a handle to the window behind which this
			/// window is placed, or can be one of the special values listed with the SetWindowPos function.
			/// </summary>
			public HWND hwndInsertAfter;

			/// <summary>The position of the left edge of the window.</summary>
			public int x;

			/// <summary>The position of the top edge of the window.</summary>
			public int y;

			/// <summary>The window width, in pixels.</summary>
			public int cx;

			/// <summary>The window height, in pixels.</summary>
			public int cy;

			/// <summary>The window position. This member can be one or more of the following values.</summary>
			public SetWindowPosFlags flags;
		}

		/// <summary>Special window handles</summary>
		public static class SpecialWindowHandles
		{
			/// <summary>
			/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its
			/// topmost status and is placed at the bottom of all other windows.
			/// </summary>
			public static HWND HWND_BOTTOM = new IntPtr(1);

			/// <summary>
			/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window
			/// is already a non-topmost window.
			/// </summary>
			public static HWND HWND_NOTOPMOST = new IntPtr(-2);

			/// <summary>Places the window at the top of the Z order.</summary>
			public static HWND HWND_TOP = new IntPtr(0);

			/// <summary>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</summary>
			public static HWND HWND_TOPMOST = new IntPtr(-1);
		}

		/// <summary>The <c>DRAWTEXTPARAMS</c> structure contains extended formatting options for the DrawTextEx function.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagdrawtextparams typedef struct tagDRAWTEXTPARAMS { UINT
		// cbSize; int iTabLength; int iLeftMargin; int iRightMargin; UINT uiLengthDrawn; } DRAWTEXTPARAMS, *LPDRAWTEXTPARAMS;
		[PInvokeData("winuser.h", MSDNShortId = "d3b89ce2-9a05-42af-b03e-24e1c4d6ef1d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class DRAWTEXTPARAMS
		{
			/// <summary>Initializes a new instance of the <see cref="DRAWTEXTPARAMS"/> class.</summary>
			/// <param name="tabLength">The size of each tab stop, in units equal to the average character width.</param>
			/// <param name="leftMargin">The left margin, in units equal to the average character width.</param>
			/// <param name="rightMargin">The right margin, in units equal to the average character width.</param>
			public DRAWTEXTPARAMS(int tabLength = 0, int leftMargin = 0, int rightMargin = 0)
			{
				cbSize = (uint)Marshal.SizeOf(typeof(DRAWTEXTPARAMS));
				iTabLength = tabLength;
				iLeftMargin = leftMargin;
				iRightMargin = rightMargin;
			}

			/// <summary>The structure size, in bytes.</summary>
			public uint cbSize;

			/// <summary>The size of each tab stop, in units equal to the average character width.</summary>
			public int iTabLength;

			/// <summary>The left margin, in units equal to the average character width.</summary>
			public int iLeftMargin;

			/// <summary>The right margin, in units equal to the average character width.</summary>
			public int iRightMargin;

			/// <summary>
			/// Receives the number of characters processed by DrawTextEx, including white-space characters. The number can be the length of
			/// the string or the index of the first line that falls below the drawing area. Note that <c>DrawTextEx</c> always processes the
			/// entire string if the DT_NOCLIP formatting flag is specified.
			/// </summary>
			public uint uiLengthDrawn;
		}
	}
}