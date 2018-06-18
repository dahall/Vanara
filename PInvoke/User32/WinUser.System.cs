using System;
using System.Runtime.InteropServices;
using System.Text;

// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The shutdown type for the <see cref="ExitWindowsEx"/> method.</summary>
		[Flags]
		public enum ExitWindowsFlags
		{
			/// <summary>
			/// Shuts down all processes running in the logon session of the process that called the ExitWindowsEx function. Then it logs the user off.
			/// <para>This flag can be used only by processes running in an interactive user's logon session.</para>
			/// </summary>
			EWX_LOGOFF = 0x00000000,
			/// <summary>
			/// Shuts down the system to a point at which it is safe to turn off the power. All file buffers have been flushed to disk, and all running processes
			/// have stopped.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// <para>
			/// Specifying this flag will not turn off the power even if the system supports the power-off feature. You must specify EWX_POWEROFF to do this.
			/// </para>
			/// <para>Windows XP with SP1: If the system supports the power-off feature, specifying this flag turns off the power.</para>
			/// </summary>
			EWX_SHUTDOWN = 0x00000001,
			/// <summary>
			/// Shuts down the system and then restarts the system.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_REBOOT = 0x00000002,
			/// <summary>
			/// This flag has no effect if terminal services is enabled. Otherwise, the system does not send the WM_QUERYENDSESSION message. This can cause
			/// applications to lose data. Therefore, you should only use this flag in an emergency.
			/// </summary>
			EWX_FORCE = 0x00000004,
			/// <summary>
			/// Shuts down the system and turns off the power. The system must support the power-off feature.
			/// <para>The calling process must have the SE_SHUTDOWN_NAME privilege. For more information, see the following Remarks section.</para>
			/// </summary>
			EWX_POWEROFF = 0x00000008,
			/// <summary>
			/// Forces processes to terminate if they do not respond to the WM_QUERYENDSESSION or WM_ENDSESSION message within the timeout interval. For more
			/// information, see the Remarks.
			/// </summary>
			EWX_FORCEIFHUNG = 0x00000010,
			/// <summary>The ewx quickresolve</summary>
			EWX_QUICKRESOLVE = 0x00000020,
			/// <summary>
			/// Shuts down the system and then restarts it, as well as any applications that have been registered for restart using the
			/// RegisterApplicationRestart function. These application receive the WM_QUERYENDSESSION message with lParam set to the ENDSESSION_CLOSEAPP value.
			/// For more information, see Guidelines for Applications.
			/// </summary>
			EWX_RESTARTAPPS = 0x00000040,
			/// <summary>
			/// Beginning with Windows 8: You can prepare the system for a faster startup by combining the EWX_HYBRID_SHUTDOWN flag with the EWX_SHUTDOWN flag.
			/// </summary>
			EWX_HYBRID_SHUTDOWN = 0x00400000,
			/// <summary>When combined with the EWX_REBOOT flag, will reboot to the boot options.</summary>
			EWX_BOOTOPTIONS = 0x01000000,
		}

		/// <summary>The system metric or configuration setting to be retrieved by <see cref="GetSystemMetrics"/>.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "ms724385")]
		public enum SystemMetric
		{
			/// <summary>The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.</summary>
			SM_ARRANGE = 56,
			/// <summary>The value that specifies how the system is started:
			/// <para>0 Normal boot</para>
			/// <para>1 Fail-safe boot</para>
			/// <para>2 Fail-safe with network boot</para>
			/// <para>A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.</para>
			/// </summary>
			SM_CLEANBOOT = 67,
			/// <summary>The number of display monitors on a desktop. For more information, see the Remarks section in this topic.</summary>
			SM_CMONITORS = 80,
			/// <summary>The number of buttons on a mouse, or zero if no mouse is installed.</summary>
			SM_CMOUSEBUTTONS = 43,
			/// <summary>Reflects the state of the laptop or slate mode, 0 for Slate Mode and non-zero otherwise. When this system metric changes, the system sends a broadcast message via WM_SETTINGCHANGE with "ConvertibleSlateMode" in the LPARAM. Note that this system metric doesn't apply to desktop PCs. In that case, use GetAutoRotationState.</summary>
			SM_CONVERTIBLESLATEMODE = 0x2003,
			/// <summary>The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.</summary>
			SM_CXBORDER = 5,
			/// <summary>The width of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
			SM_CXCURSOR = 13,
			/// <summary>This value is the same as SM_CXFIXEDFRAME.</summary>
			SM_CXDLGFRAME = 7,
			/// <summary>The width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also occur within a specified time.
			/// <para>To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.</para></summary>
			SM_CXDOUBLECLK = 36,
			/// <summary>The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.</summary>
			SM_CXDRAG = 68,
			/// <summary>The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.</summary>
			SM_CXEDGE = 45,
			/// <summary>The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
			/// <para>This value is the same as SM_CXDLGFRAME.</para></summary>
			SM_CXFIXEDFRAME = 7,
			/// <summary>The width of the left and right edges of the focus rectangle that the DrawFocusRect draws. This value is in pixels.
			/// <para>Windows 2000:  This value is not supported.</para></summary>
			SM_CXFOCUSBORDER = 83,
			/// <summary>This value is the same as SM_CXSIZEFRAME.</summary>
			SM_CXFRAME = 32,
			/// <summary>The width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.</summary>
			SM_CXFULLSCREEN = 16,
			/// <summary>The width of the arrow bitmap on a horizontal scroll bar, in pixels.</summary>
			SM_CXHSCROLL = 21,
			/// <summary>The width of the thumb box in a horizontal scroll bar, in pixels.</summary>
			SM_CXHTHUMB = 10,
			/// <summary>The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions that SM_CXICON and SM_CYICON specifies.</summary>
			SM_CXICON = 11,
			/// <summary>The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.</summary>
			SM_CXICONSPACING = 38,
			/// <summary>The default width, in pixels, of a maximized top-level window on the primary display monitor.</summary>
			SM_CXMAXIMIZED = 61,
			/// <summary>The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.</summary>
			SM_CXMAXTRACK = 59,
			/// <summary>The width of the default menu check-mark bitmap, in pixels.</summary>
			SM_CXMENUCHECK = 71,
			/// <summary>The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</summary>
			SM_CXMENUSIZE = 54,
			/// <summary>The minimum width of a window, in pixels.</summary>
			SM_CXMIN = 28,
			/// <summary>The width of a minimized window, in pixels.</summary>
			SM_CXMINIMIZED = 57,
			/// <summary>The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CXMINIMIZED.</summary>
			SM_CXMINSPACING = 47,
			/// <summary>The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.</summary>
			SM_CXMINTRACK = 34,
			/// <summary>The amount of border padding for captioned windows, in pixels.
			/// <para>Windows XP/2000:  This value is not supported.</para></summary>
			SM_CXPADDEDBORDER = 92,
			/// <summary>The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).</summary>
			SM_CXSCREEN = 0,
			/// <summary>The width of a button in a window caption or title bar, in pixels.</summary>
			SM_CXSIZE = 30,
			/// <summary>The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
			/// <para>This value is the same as SM_CXFRAME.</para></summary>
			SM_CXSIZEFRAME = 32,
			/// <summary>The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</summary>
			SM_CXSMICON = 49,
			/// <summary>The width of small caption buttons, in pixels.</summary>
			SM_CXSMSIZE = 52,
			/// <summary>The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.</summary>
			SM_CXVIRTUALSCREEN = 78,
			/// <summary>The width of a vertical scroll bar, in pixels.</summary>
			SM_CXVSCROLL = 2,
			/// <summary>The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.</summary>
			SM_CYBORDER = 6,
			/// <summary>The height of a caption area, in pixels.</summary>
			SM_CYCAPTION = 4,
			/// <summary>The height of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
			SM_CYCURSOR = 14,
			/// <summary>This value is the same as SM_CYFIXEDFRAME.</summary>
			SM_CYDLGFRAME = 8,
			/// <summary>The height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also occur within a specified time.
			/// <para>To set the height of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.</para></summary>
			SM_CYDOUBLECLK = 37,
			/// <summary>The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. If this value is negative, it is subtracted from above the mouse-down point and added below it.</summary>
			SM_CYDRAG = 69,
			/// <summary>The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.</summary>
			SM_CYEDGE = 46,
			/// <summary>The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
			/// <para>This value is the same as SM_CYDLGFRAME.</para></summary>
			SM_CYFIXEDFRAME = 8,
			/// <summary>The height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.
			/// <para>Windows 2000:  This value is not supported.</para></summary>
			SM_CYFOCUSBORDER = 84,
			/// <summary>This value is the same as SM_CYSIZEFRAME.</summary>
			SM_CYFRAME = 33,
			/// <summary>The height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.</summary>
			SM_CYFULLSCREEN = 17,
			/// <summary>The height of a horizontal scroll bar, in pixels.</summary>
			SM_CYHSCROLL = 3,
			/// <summary>The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.</summary>
			SM_CYICON = 12,
			/// <summary>The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.</summary>
			SM_CYICONSPACING = 39,
			/// <summary>For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.</summary>
			SM_CYKANJIWINDOW = 18,
			/// <summary>The default height, in pixels, of a maximized top-level window on the primary display monitor.</summary>
			SM_CYMAXIMIZED = 62,
			/// <summary>The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.</summary>
			SM_CYMAXTRACK = 60,
			/// <summary>The height of a single-line menu bar, in pixels.</summary>
			SM_CYMENU = 15,
			/// <summary>The height of the default menu check-mark bitmap, in pixels.</summary>
			SM_CYMENUCHECK = 72,
			/// <summary>The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</summary>
			SM_CYMENUSIZE = 55,
			/// <summary>The minimum height of a window, in pixels.</summary>
			SM_CYMIN = 29,
			/// <summary>The height of a minimized window, in pixels.</summary>
			SM_CYMINIMIZED = 58,
			/// <summary>The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CYMINIMIZED.</summary>
			SM_CYMINSPACING = 48,
			/// <summary>The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.</summary>
			SM_CYMINTRACK = 35,
			/// <summary>The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).</summary>
			SM_CYSCREEN = 1,
			/// <summary>The height of a button in a window caption or title bar, in pixels.</summary>
			SM_CYSIZE = 31,
			/// <summary>The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border.
			/// <para>This value is the same as SM_CYFRAME.</para></summary>
			SM_CYSIZEFRAME = 33,
			/// <summary>The height of a small caption, in pixels.</summary>
			SM_CYSMCAPTION = 51,
			/// <summary>The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</summary>
			SM_CYSMICON = 50,
			/// <summary>The height of small caption buttons, in pixels.</summary>
			SM_CYSMSIZE = 53,
			/// <summary>The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.</summary>
			SM_CYVIRTUALSCREEN = 79,
			/// <summary>The height of the arrow bitmap on a vertical scroll bar, in pixels.</summary>
			SM_CYVSCROLL = 20,
			/// <summary>The height of the thumb box in a vertical scroll bar, in pixels.</summary>
			SM_CYVTHUMB = 9,
			/// <summary>Nonzero if User32.dll supports DBCS; otherwise, 0.</summary>
			SM_DBCSENABLED = 42,
			/// <summary>Nonzero if the debug version of User.exe is installed; otherwise, 0.</summary>
			SM_DEBUG = 22,
			/// <summary>Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started; otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. For more information, see Remarks.
			/// <para>Windows Server 2008, Windows Vista and Windows XP/2000:  This value is not supported.</para></summary>
			SM_DIGITIZER = 94,
			/// <summary>Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0.
			/// <para>SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode application. To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page. Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some components like fonts or registry settings may not be present.</para></summary>
			SM_IMMENABLED = 82,
			/// <summary>Nonzero if there are digitizers in the system; otherwise, 0.
			/// <para>SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts the hardware can provide.</para>
			/// <para>Windows Server 2008, Windows Vista and Windows XP/2000:  This value is not supported.</para></summary>
			SM_MAXIMUMTOUCHES = 95,
			/// <summary>Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.</summary>
			SM_MEDIACENTER = 87,
			/// <summary>Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.</summary>
			SM_MENUDROPALIGNMENT = 40,
			/// <summary>Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.</summary>
			SM_MIDEASTENABLED = 74,
			/// <summary>Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because some systems detect the presence of the port instead of the presence of a mouse.</summary>
			SM_MOUSEPRESENT = 19,
			/// <summary>Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.</summary>
			SM_MOUSEHORIZONTALWHEELPRESENT = 91,
			/// <summary>Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.</summary>
			SM_MOUSEWHEELPRESENT = 75,
			/// <summary>The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.</summary>
			SM_NETWORK = 63,
			/// <summary>Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.</summary>
			SM_PENWINDOWS = 41,
			/// <summary>This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is being remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0.
			/// <para>You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to control a remote session. When a session is being remotely controlled, another user can view the contents of that session and potentially interact with it.</para></summary>
			SM_REMOTECONTROL = 0x2001,
			/// <summary>This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session, the return value is 0.
			/// <para>Windows Server 2003 and Windows XP:  The console session is not necessarily the physical console. For more information, see WTSGetActiveConsoleSessionId.</para></summary>
			SM_REMOTESESSION = 0x1000,
			/// <summary>Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those bits can be located in different places in a pixel color value.</summary>
			SM_SAMEDISPLAYFORMAT = 81,
			/// <summary>This system metric should be ignored; it always returns 0.</summary>
			SM_SECURE = 44,
			/// <summary>The build number if the system is Windows Server 2003 R2; otherwise, 0.</summary>
			SM_SERVERR2 = 89,
			/// <summary>Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in audible form; otherwise, 0.</summary>
			SM_SHOWSOUNDS = 70,
			/// <summary>Nonzero if the current session is shutting down; otherwise, 0.
			/// <para>Windows 2000:  This value is not supported.</para></summary>
			SM_SHUTTINGDOWN = 0x2000,
			/// <summary>Nonzero if the computer has a low-end (slow) processor; otherwise, 0.</summary>
			SM_SLOWMACHINE = 73,
			/// <summary>Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.</summary>
			SM_STARTER = 88,
			/// <summary>Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.</summary>
			SM_SWAPBUTTON = 23,
			/// <summary>Reflects the state of the docking mode, 0 for Undocked Mode and non-zero otherwise. When this system metric changes, the system sends a broadcast message via WM_SETTINGCHANGE with "SystemDockMode" in the LPARAM.</summary>
			SM_SYSTEMDOCKED = 0x2004,
			/// <summary>Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.</summary>
			SM_TABLETPC = 86,
			/// <summary>The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.</summary>
			SM_XVIRTUALSCREEN = 76,
			/// <summary>The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CYVIRTUALSCREEN metric is the height of the virtual screen.</summary>
			SM_YVIRTUALSCREEN = 77,
		}

		/// <summary>
		/// The ExitWindowsEx function either logs off the current user, shuts down the system, or shuts down and restarts the system. It sends the
		/// WM_QUERYENDSESSION message to all applications to determine if they can be terminated.
		/// </summary>
		/// <param name="uFlags">Specifies the type of shutdown.</param>
		/// <param name="dwReason">The reason for initiating the shutdown.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. <br></br><br>If the function fails, the return value is zero. To get extended error
		/// information, call Marshal.GetLastWin32Error.</br>
		/// </returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ExitWindowsEx(ExitWindowsFlags uFlags, SystemShutDownReason dwReason);

		/// <summary>
		/// <para>Retrieves the specified system metric or system configuration setting.</para>
		/// <para>Note that all dimensions retrieved by <c>GetSystemMetrics</c> are in pixels.</para>
		/// </summary>
		/// <param name="nIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The system metric or configuration setting to be retrieved. This parameter can be one of the following values. Note that all SM_CX* values are widths
		/// and all SM_CY* values are heights. Also note that all settings designed to return Boolean data represent <c>TRUE</c> as any nonzero value, and
		/// <c>FALSE</c> as a zero value.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SM_ARRANGE56</term>
		/// <term>The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.</term>
		/// </item>
		/// <item>
		/// <term>SM_CLEANBOOT67</term>
		/// <term>
		/// The value that specifies how the system is started: A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CMONITORS80</term>
		/// <term>The number of display monitors on a desktop. For more information, see the Remarks section in this topic.</term>
		/// </item>
		/// <item>
		/// <term>SM_CMOUSEBUTTONS43</term>
		/// <term>The number of buttons on a mouse, or zero if no mouse is installed.</term>
		/// </item>
		/// <item>
		/// <term>SM_CONVERTIBLESLATEMODE0x2003</term>
		/// <term>
		/// Reflects the state of the laptop or slate mode, 0 for Slate Mode and non-zero otherwise. When this system metric changes, the system sends a
		/// broadcast message via WM_SETTINGCHANGE with &amp;quot;ConvertibleSlateMode&amp;quot; in the LPARAM. Note that this system metric doesn&amp;#39;t
		/// apply to desktop PCs. In that case, use GetAutoRotationState.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXBORDER5</term>
		/// <term>The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXCURSOR13</term>
		/// <term>The width of a cursor, in pixels. The system cannot create cursors of other sizes.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXDLGFRAME7</term>
		/// <term>This value is the same as SM_CXFIXEDFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXDOUBLECLK36</term>
		/// <term>
		/// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the
		/// rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also
		/// occur within a specified time. To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXDRAG68</term>
		/// <term>
		/// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to
		/// click and release the mouse button easily without unintentionally starting a drag operation. If this value is negative, it is subtracted from the
		/// left of the mouse-down point and added to the right of it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXEDGE45</term>
		/// <term>The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXFIXEDFRAME7</term>
		/// <term>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the
		/// horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border. This value is the same as SM_CXDLGFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXFOCUSBORDER83</term>
		/// <term>
		/// The width of the left and right edges of the focus rectangle that the DrawFocusRect draws. This value is in pixels. Windows 2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXFRAME32</term>
		/// <term>This value is the same as SM_CXSIZEFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXFULLSCREEN16</term>
		/// <term>
		/// The width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen
		/// that is not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXHSCROLL21</term>
		/// <term>The width of the arrow bitmap on a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXHTHUMB10</term>
		/// <term>The width of the thumb box in a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXICON11</term>
		/// <term>The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions that SM_CXICON and SM_CYICON specifies.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXICONSPACING38</term>
		/// <term>
		/// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when
		/// arranged. This value is always greater than or equal to SM_CXICON.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMAXIMIZED61</term>
		/// <term>The default width, in pixels, of a maximized top-level window on the primary display monitor.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMAXTRACK59</term>
		/// <term>
		/// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot
		/// drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMENUCHECK71</term>
		/// <term>The width of the default menu check-mark bitmap, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMENUSIZE54</term>
		/// <term>The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMIN28</term>
		/// <term>The minimum width of a window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINIMIZED57</term>
		/// <term>The width of a minimized window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINSPACING47</term>
		/// <term>
		/// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always
		/// greater than or equal to SM_CXMINIMIZED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXMINTRACK34</term>
		/// <term>
		/// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can
		/// override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXPADDEDBORDER92</term>
		/// <term>The amount of border padding for captioned windows, in pixels.Windows XP/2000: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSCREEN0</term>
		/// <term>The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: .</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSIZE30</term>
		/// <term>The width of a button in a window caption or title bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSIZEFRAME32</term>
		/// <term>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal
		/// border, and SM_CYSIZEFRAME is the height of the vertical border. This value is the same as SM_CXFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXSMICON49</term>
		/// <term>The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSMSIZE52</term>
		/// <term>The width of small caption buttons, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXVIRTUALSCREEN78</term>
		/// <term>
		/// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_XVIRTUALSCREEN metric is the
		/// coordinates for the left side of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CXVSCROLL2</term>
		/// <term>The width of a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYBORDER6</term>
		/// <term>The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYCAPTION4</term>
		/// <term>The height of a caption area, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYCURSOR14</term>
		/// <term>The height of a cursor, in pixels. The system cannot create cursors of other sizes.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYDLGFRAME8</term>
		/// <term>This value is the same as SM_CYFIXEDFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYDOUBLECLK37</term>
		/// <term>
		/// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the
		/// rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also occur
		/// within a specified time. To set the height of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYDRAG69</term>
		/// <term>
		/// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to click
		/// and release the mouse button easily without unintentionally starting a drag operation. If this value is negative, it is subtracted from above the
		/// mouse-down point and added below it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYEDGE46</term>
		/// <term>The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYFIXEDFRAME8</term>
		/// <term>
		/// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the
		/// horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.This value is the same as SM_CYDLGFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYFOCUSBORDER84</term>
		/// <term>
		/// The height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels.Windows 2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYFRAME33</term>
		/// <term>This value is the same as SM_CYSIZEFRAME.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYFULLSCREEN17</term>
		/// <term>
		/// The height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen
		/// not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYHSCROLL3</term>
		/// <term>The height of a horizontal scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYICON12</term>
		/// <term>The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYICONSPACING39</term>
		/// <term>
		/// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when
		/// arranged. This value is always greater than or equal to SM_CYICON.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYKANJIWINDOW18</term>
		/// <term>For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMAXIMIZED62</term>
		/// <term>The default height, in pixels, of a maximized top-level window on the primary display monitor.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMAXTRACK60</term>
		/// <term>
		/// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot
		/// drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENU15</term>
		/// <term>The height of a single-line menu bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENUCHECK72</term>
		/// <term>The height of the default menu check-mark bitmap, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENUSIZE55</term>
		/// <term>The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMIN29</term>
		/// <term>The minimum height of a window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINIMIZED58</term>
		/// <term>The height of a minimized window, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINSPACING48</term>
		/// <term>
		/// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is
		/// always greater than or equal to SM_CYMINIMIZED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYMINTRACK35</term>
		/// <term>
		/// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can
		/// override this value by processing the WM_GETMINMAXINFO message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYSCREEN1</term>
		/// <term>The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: .</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSIZE31</term>
		/// <term>The height of a button in a window caption or title bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSIZEFRAME33</term>
		/// <term>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal
		/// border, and SM_CYSIZEFRAME is the height of the vertical border. This value is the same as SM_CYFRAME.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMCAPTION51</term>
		/// <term>The height of a small caption, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMICON50</term>
		/// <term>The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMSIZE53</term>
		/// <term>The height of small caption buttons, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYVIRTUALSCREEN79</term>
		/// <term>
		/// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_YVIRTUALSCREEN metric is
		/// the coordinates for the top of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_CYVSCROLL20</term>
		/// <term>The height of the arrow bitmap on a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYVTHUMB9</term>
		/// <term>The height of the thumb box in a vertical scroll bar, in pixels.</term>
		/// </item>
		/// <item>
		/// <term>SM_DBCSENABLED42</term>
		/// <term>Nonzero if User32.dll supports DBCS; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_DEBUG22</term>
		/// <term>Nonzero if the debug version of User.exe is installed; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_DIGITIZER94</term>
		/// <term>
		/// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started; otherwise, 0. The return
		/// value is a bitmask that specifies the type of digitizer input supported by the device. For more information, see Remarks.Windows Server 2008, Windows
		/// Vista and Windows XP/2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_IMMENABLED82</term>
		/// <term>
		/// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. SM_IMMENABLED indicates whether the system is ready to use a
		/// Unicode-based IME on a Unicode application. To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page.
		/// Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some components like fonts or registry settings may not be present.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MAXIMUMTOUCHES95</term>
		/// <term>
		/// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum number of contacts
		/// supported by every digitizer in the system. If the system has only single-touch digitizers, the return value is 1. If the system has multi-touch
		/// digitizers, the return value is the number of simultaneous contacts the hardware can provide.Windows Server 2008, Windows Vista and Windows XP/2000:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MEDIACENTER87</term>
		/// <term>Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.</term>
		/// </item>
		/// <item>
		/// <term>SM_MENUDROPALIGNMENT40</term>
		/// <term>Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.</term>
		/// </item>
		/// <item>
		/// <term>SM_MIDEASTENABLED74</term>
		/// <term>Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.</term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEPRESENT19</term>
		/// <term>
		/// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because some systems detect the
		/// presence of the port instead of the presence of a mouse.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEHORIZONTALWHEELPRESENT91</term>
		/// <term>Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_MOUSEWHEELPRESENT75</term>
		/// <term>Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_NETWORK63</term>
		/// <term>The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>SM_PENWINDOWS41</term>
		/// <term>Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.</term>
		/// </item>
		/// <item>
		/// <term>SM_REMOTECONTROL0x2001</term>
		/// <term>
		/// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is being remotely controlled. Its
		/// value is nonzero if the current session is remotely controlled; otherwise, 0.You can use terminal services management tools such as Terminal Services
		/// Manager (tsadmin.msc) and shadow.exe to control a remote session. When a session is being remotely controlled, another user can view the contents of
		/// that session and potentially interact with it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_REMOTESESSION0x1000</term>
		/// <term>
		/// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the
		/// return value is nonzero. If the calling process is associated with the Terminal Services console session, the return value is 0. Windows Server 2003
		/// and Windows XP: The console session is not necessarily the physical console. For more information, see WTSGetActiveConsoleSessionId.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SAMEDISPLAYFORMAT81</term>
		/// <term>
		/// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, but different color formats.
		/// For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those bits can be located in different places in a
		/// pixel color value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SECURE44</term>
		/// <term>This system metric should be ignored; it always returns 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SERVERR289</term>
		/// <term>The build number if the system is Windows Server 2003 R2; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SHOWSOUNDS70</term>
		/// <term>
		/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in
		/// audible form; otherwise, 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_SHUTTINGDOWN0x2000</term>
		/// <term>Nonzero if the current session is shutting down; otherwise, 0. Windows 2000: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SM_SLOWMACHINE73</term>
		/// <term>Nonzero if the computer has a low-end (slow) processor; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_STARTER88</term>
		/// <term>Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SWAPBUTTON23</term>
		/// <term>Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.</term>
		/// </item>
		/// <item>
		/// <term>SM_SYSTEMDOCKED0x2004</term>
		/// <term>
		/// Reflects the state of the docking mode, 0 for Undocked Mode and non-zero otherwise. When this system metric changes, the system sends a broadcast
		/// message via WM_SETTINGCHANGE with &amp;quot;SystemDockMode&amp;quot; in the LPARAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_TABLETPC86</term>
		/// <term>
		/// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista or Windows 7 and the
		/// Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer input supported by a device running
		/// Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_XVIRTUALSCREEN76</term>
		/// <term>
		/// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CXVIRTUALSCREEN
		/// metric is the width of the virtual screen.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SM_YVIRTUALSCREEN77</term>
		/// <term>
		/// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CYVIRTUALSCREEN
		/// metric is the height of the virtual screen.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type:</para>
		/// <para>If the function succeeds, the return value is the requested system metric or configuration setting.</para>
		/// <para>If the function fails, the return value is 0. <c>GetLastError</c> does not provide extended error information.</para>
		/// </returns>
		// int WINAPI GetSystemMetrics( _In_ int nIndex);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms724385(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms724385")]
		public static extern int GetSystemMetrics(SystemMetric nIndex);

		/// <summary>Locks the workstation's display, protecting it from unauthorized use.</summary>
		/// <returns>0 on failure, non-zero for success</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LockWorkStation();

		/// <summary>Indicates that the system cannot be shut down and sets a reason string to be displayed to the user if system shutdown is initiated.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">
		/// The reason the application must block system shutdown. This string will be truncated for display purposes after MAX_STR_BLOCKREASON characters.
		/// </param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonCreate(HandleRef hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);

		/// <summary>Indicates that the system can be shut down and frees the reason string.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonDestroy(HandleRef hWnd);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="pwszBuff">
		/// A pointer to a buffer that receives the reason string. If this parameter is NULL, the function retrieves the number of characters in the reason string.
		/// </param>
		/// <param name="pcchBuff">
		/// A pointer to a variable that specifies the size of the pwszBuff buffer, in characters. If the function succeeds, this variable receives the number of
		/// characters copied into the buffer, including the null-terminating character. If the buffer is too small, the variable receives the required buffer
		/// size, in characters, not including the null-terminating character.
		/// </param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShutdownBlockReasonQuery(HandleRef hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, ref uint pcchBuff);

		/// <summary>Retrieves the reason string set by the <see cref="ShutdownBlockReasonCreate"/> function.</summary>
		/// <param name="hWnd">A handle to the main window of the application.</param>
		/// <param name="reason">On success, receives the reason string.</param>
		/// <returns>
		/// If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		public static bool ShutdownBlockReasonQuery(HandleRef hWnd, out string reason)
		{
			uint sz = 0;
			reason = null;
			if (!ShutdownBlockReasonQuery(hWnd, null, ref sz)) return false;
			var sb = new StringBuilder((int)sz);
			if (!ShutdownBlockReasonQuery(hWnd, sb, ref sz)) return false;
			reason = sb.ToString();
			return true;
		}
	}
}