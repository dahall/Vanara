namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Flags used by <see cref="WinHelp"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "fce80bac-2a44-46e7-a87a-ef93f4599807")]
	public enum HelpCmd : uint
	{
		/// <summary>Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file.</summary>
		[CorrespondingType(typeof(int))]
		HELP_CONTEXT = 0x0001,

		/// <summary>
		/// Informs Windows Help that it is no longer needed. If no other applications have asked for help, Windows closes Windows Help.
		/// </summary>
		HELP_QUIT = 0x0002,

		/// <summary>
		/// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward
		/// compatibility. New applications should use the HELP_FINDER command.
		/// </summary>
		HELP_INDEX = 0x0003,

		/// <summary>
		/// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward
		/// compatibility. New applications should provide a .cnt file and use the HELP_FINDER command.
		/// </summary>
		HELP_CONTENTS = 0x0003,

		/// <summary>Displays help on how to use Windows Help, if the Winhlp32.hlp file is available.</summary>
		HELP_HELPONHELP = 0x0004,

		/// <summary>
		/// Displays the index of the specified help file. An application should use this value only for help files with a single index.
		/// It should not use this value with HELP_SETINDEX.
		/// </summary>
		[CorrespondingType(typeof(int))]
		HELP_SETINDEX = 0x0005,

		/// <summary>
		/// Specifies the Contents topic. Windows Help displays this topic when the user clicks the Contents button if the Help file does
		/// not have an associated .cnt file.
		/// </summary>
		[CorrespondingType(typeof(int))]
		HELP_SETCONTENTS = 0x0005,

		/// <summary>
		/// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file in a pop-up window.
		/// </summary>
		[CorrespondingType(typeof(int))]
		HELP_CONTEXTPOPUP = 0x0008,

		/// <summary>
		/// Ensures that Windows Help is displaying the correct Help file. If the incorrect Help file is being displayed, Windows Help
		/// opens the correct one; otherwise, there is no action.
		/// </summary>
		HELP_FORCEFILE = 0x0009,

		/// <summary>
		/// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than
		/// one match, displays the Index with the topics listed in the Topics Found list box.
		/// </summary>
		[CorrespondingType(typeof(string))]
		HELP_KEY = 0x0101,

		/// <summary>Executes a Help macro or macro string.</summary>
		[CorrespondingType(typeof(string))]
		HELP_COMMAND = 0x0102,

		/// <summary>
		/// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than
		/// one match, displays the Topics Found dialog box. To display the index without passing a keyword, use a pointer to an empty string.
		/// </summary>
		[CorrespondingType(typeof(string))]
		HELP_PARTIALKEY = 0x0105,

		/// <summary>Displays the topic specified by a keyword in an alternative keyword table.</summary>
		[CorrespondingType(typeof(MULTIKEYHELP))]
		HELP_MULTIKEY = 0x0201,

		/// <summary>Displays the Windows Help window, if it is minimized or in memory, and sets its size and position as specified.</summary>
		[CorrespondingType(typeof(HELPWININFO))]
		HELP_SETWINPOS = 0x0203,

		/// <summary>
		/// Displays the Help menu for the selected window, then displays the topic for the selected control in a pop-up window.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		HELP_CONTEXTMENU = 0x000a,

		/// <summary>Displays the Help Topics dialog box.</summary>
		HELP_FINDER = 0x000b,

		/// <summary>Displays the topic for the control identified by the hWndMain parameter in a pop-up window.</summary>
		[CorrespondingType(typeof(byte[]))]
		HELP_WM_HELP = 0x000c,

		/// <summary>Sets the position of the subsequent pop-up window.</summary>
		[CorrespondingType(typeof(int))]
		HELP_SETPOPUP_POS = 0x000d,

		/// <summary>
		/// Indicates that a command is for a training card instance of Windows Help. Combine this command with other commands using the
		/// bitwise OR operator.
		/// </summary>
		HELP_TCARD = 0x8000,

		/// <summary>
		/// The user clicked an authorable button. The dwActionData parameter contains a long integer specified by the Help author.
		/// </summary>
		HELP_TCARD_DATA = 0x0010,

		/// <summary>Another application has requested training cards.</summary>
		HELP_TCARD_OTHER_CALLER = 0x0011,
	}

	/// <summary>
	/// Launches Windows Help (Winhelp.exe) and passes additional data that indicates the nature of the help requested by the application.
	/// </summary>
	/// <param name="hWndMain">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// A handle to the window requesting help. The <c>WinHelp</c> function uses this handle to keep track of which applications have
	/// requested help. If the uCommand parameter specifies <c>HELP_CONTEXTMENU</c> or <c>HELP_WM_HELP</c>, hWndMain identifies the
	/// control requesting help.
	/// </para>
	/// </param>
	/// <param name="lpszHelp">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// The address of a null-terminated string containing the path, if necessary, and the name of the Help file that <c>WinHelp</c> is
	/// to display.
	/// </para>
	/// <para>
	/// The file name can be followed by an angle bracket (&gt;) and the name of a secondary window if the topic is to be displayed in a
	/// secondary window rather than in the primary window. You must define the name of the secondary window in the [WINDOWS] section of
	/// the Help project (.hpj) file.
	/// </para>
	/// </param>
	/// <param name="uCommand">
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The type of help requested. For a list of possible values and how they affect the value to place in the dwData parameter, see the
	/// Remarks section.
	/// </para>
	/// </param>
	/// <param name="dwData">
	/// <para>Type: <c>ULONG_PTR</c></para>
	/// <para>
	/// Additional data. The value used depends on the value of the uCommand parameter. For a list of possible dwData values, see the
	/// Remarks section.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>Returns nonzero if successful, or zero otherwise. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before closing the window that requested help, the application must call <c>WinHelp</c> with the uCommand parameter set to
	/// HELP_QUIT. Until all applications have done this, Windows Help will not terminate. Note that calling Windows Help with the
	/// HELP_QUIT command is not necessary if you used the HELP_CONTEXTPOPUP command to start Windows Help.
	/// </para>
	/// <para>This function fails if called from any context but the current user.</para>
	/// <para>The following table shows the possible values for the uCommand parameter and the corresponding formats of the dwData parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>uCommand</term>
	/// <term>Action</term>
	/// <term>dwData</term>
	/// </listheader>
	/// <item>
	/// <term>HELP_COMMAND</term>
	/// <term>Executes a Help macro or macro string.</term>
	/// <term>
	/// Address of a string that specifies the name of the Help macro(s) to run. If the string specifies multiple macro names, the names
	/// must be separated by semicolons. You must use the short form of the macro name for some macros because Windows Help does not
	/// support the long name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HELP_CONTENTS</term>
	/// <term>
	/// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward
	/// compatibility. New applications should provide a .cnt file and use the HELP_FINDER command.
	/// </term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_CONTEXT</term>
	/// <term>Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file.</term>
	/// <term>Contains the context identifier for the topic.</term>
	/// </item>
	/// <item>
	/// <term>HELP_CONTEXTMENU</term>
	/// <term>Displays the Help menu for the selected window, then displays the topic for the selected control in a pop-up window.</term>
	/// <term>
	/// Address of an array of DWORD pairs. The first DWORD in each pair is the control identifier, and the second is the context
	/// identifier for the topic. The array must be terminated by a pair of zeros {0,0}. If you do not want to add Help to a particular
	/// control, set its context identifier to -1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HELP_CONTEXTPOPUP</term>
	/// <term>
	/// Displays the topic identified by the specified context identifier defined in the [MAP] section of the .hpj file in a pop-up window.
	/// </term>
	/// <term>Contains the context identifier for a topic.</term>
	/// </item>
	/// <item>
	/// <term>HELP_FINDER</term>
	/// <term>Displays the Help Topics dialog box.</term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_FORCEFILE</term>
	/// <term>
	/// Ensures that Windows Help is displaying the correct Help file. If the incorrect Help file is being displayed, Windows Help opens
	/// the correct one; otherwise, there is no action.
	/// </term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_HELPONHELP</term>
	/// <term>Displays help on how to use Windows Help, if the Winhlp32.hlp file is available.</term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_INDEX</term>
	/// <term>
	/// Displays the topic specified by the Contents option in the [OPTIONS] section of the .hpj file. This command is for backward
	/// compatibility. New applications should use the HELP_FINDER command.
	/// </term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_KEY</term>
	/// <term>
	/// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than one
	/// match, displays the Index with the topics listed in the Topics Found list box.
	/// </term>
	/// <term>Address of a keyword string. Multiple keywords must be separated by semicolons.</term>
	/// </item>
	/// <item>
	/// <term>HELP_MULTIKEY</term>
	/// <term>Displays the topic specified by a keyword in an alternative keyword table.</term>
	/// <term>Address of a MULTIKEYHELP structure that specifies a table footnote character and a keyword.</term>
	/// </item>
	/// <item>
	/// <term>HELP_PARTIALKEY</term>
	/// <term>
	/// Displays the topic in the keyword table that matches the specified keyword, if there is an exact match. If there is more than one
	/// match, displays the Topics Found dialog box. To display the index without passing a keyword, use a pointer to an empty string.
	/// </term>
	/// <term>Address of a keyword string. Multiple keywords must be separated by semicolons.</term>
	/// </item>
	/// <item>
	/// <term>HELP_QUIT</term>
	/// <term>
	/// Informs Windows Help that it is no longer needed. If no other applications have asked for help, Windows closes Windows Help.
	/// </term>
	/// <term>Ignored; set to 0.</term>
	/// </item>
	/// <item>
	/// <term>HELP_SETCONTENTS</term>
	/// <term>
	/// Specifies the Contents topic. Windows Help displays this topic when the user clicks the Contents button if the Help file does not
	/// have an associated .cnt file.
	/// </term>
	/// <term>Contains the context identifier for the Contents topic.</term>
	/// </item>
	/// <item>
	/// <term>HELP_SETPOPUP_POS</term>
	/// <term>Sets the position of the subsequent pop-up window.</term>
	/// <term>
	/// Contains the position data. Use MAKELONG to concatenate the horizontal and vertical coordinates into a single value. The pop-up
	/// window is positioned as if the mouse cursor were at the specified point when the pop-up window was invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HELP_SETWINPOS</term>
	/// <term>Displays the Windows Help window, if it is minimized or in memory, and sets its size and position as specified.</term>
	/// <term>Address of a HELPWININFO structure that specifies the size and position of either a primary or secondary Help window.</term>
	/// </item>
	/// <item>
	/// <term>HELP_TCARD</term>
	/// <term>
	/// Indicates that a command is for a training card instance of Windows Help. Combine this command with other commands using the
	/// bitwise OR operator.
	/// </term>
	/// <term>Depends on the command with which this command is combined.</term>
	/// </item>
	/// <item>
	/// <term>HELP_WM_HELP</term>
	/// <term>Displays the topic for the control identified by the hWndMain parameter in a pop-up window.</term>
	/// <term>
	/// Address of an array of DWORD pairs. The first DWORD in each pair is a control identifier, and the second is a context identifier
	/// for a topic. The array must be terminated by a pair of zeros {0,0}. If you do not want to add Help to a particular control, set
	/// its context identifier to -1.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-winhelpa BOOL WinHelpA( HWND hWndMain, LPCSTR lpszHelp,
	// UINT uCommand, ULONG_PTR dwData );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "fce80bac-2a44-46e7-a87a-ef93f4599807")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHelp(HWND hWndMain, string lpszHelp, HelpCmd uCommand, [Optional] IntPtr dwData);

	/// <summary>
	/// Contains the size and position of either a primary or secondary Help window. An application can set this information by calling
	/// the WinHelp function with the HELP_SETWINPOS value.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Windows Help divides the display into 1024 units in both the X and Y directions. To create a secondary window that fills the
	/// upper-left quadrant of the display, for example, an application would specify zero for the <c>x</c> and <c>y</c> members and 512
	/// for the <c>dx</c> and <c>dy</c> members.
	/// </para>
	/// <para>
	/// To calculate <c>wStructSize</c> properly, the actual size of the string to be stored at <c>rgchMember</c> must be known. Since
	/// sizeof(HELPWININFO) includes two <c>TCHARs</c> by definition, they must be taken into account in the final total. The following
	/// example shows the proper calculation of an instance of <c>wStructSize</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taghelpwininfoa typedef struct tagHELPWININFOA { int
	// wStructSize; int x; int y; int dx; int dy; int wMax; CHAR rgchMember[2]; } HELPWININFOA, *PHELPWININFOA, *LPHELPWININFOA;
	[PInvokeData("winuser.h", MSDNShortId = "0de0bf84-66f3-44bc-b4de-c2de7ca90cb2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct HELPWININFO
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The size of this structure, in bytes.</para>
		/// </summary>
		public int wStructSize;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>X-coordinate of the upper-left corner of the window, in screen coordinates.</para>
		/// </summary>
		public int x;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Y-coordinate of the upper-left corner of the window, in screen coordinates.</para>
		/// </summary>
		public int y;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The width of the window, in pixels.</para>
		/// </summary>
		public int dx;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The height of the window, in pixels.</para>
		/// </summary>
		public int dy;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Options for display of the window. Several values also determine the activation (focus) state of the window or other windows.
		/// This member must be one of the following values.
		/// </para>
		/// <para>SW_HIDE</para>
		/// <para>Hides the window and passes activation to another window.</para>
		/// <para>SW_MINIMIZE</para>
		/// <para>Minimizes the specified window and activates the top-level window in the z-order.</para>
		/// <para>SW_RESTORE</para>
		/// <para>Same as <c>SW_SHOWNORMAL</c>.</para>
		/// <para>SW_SHOW</para>
		/// <para>Activates a window and displays it in its current size and position.</para>
		/// <para>SW_SHOWMAXIMIZED</para>
		/// <para>Activates the window and displays it as a maximized window.</para>
		/// <para>SW_SHOWMINIMIZED</para>
		/// <para>Activates the window and displays it as an icon.</para>
		/// <para>SW_SHOWMINNOACTIVE</para>
		/// <para>Displays the window as an icon. The window that is currently active remains active.</para>
		/// <para>SW_SHOWNA</para>
		/// <para>Displays the window in its current state. The window that is currently active remains active.</para>
		/// <para>SW_SHOWNOACTIVATE</para>
		/// <para>Displays a window in its most recent size and position. The window that is currently active remains active.</para>
		/// <para>SW_SHOWNORMAL</para>
		/// <para>
		/// Activates and displays the window. Whether the window is minimized or maximized, Windows restores it to its original size and position.
		/// </para>
		/// </summary>
		public ShowWindowCommand wMax;

		/// <summary>
		/// <para>Type: <c>TCHAR[2]</c></para>
		/// <para>The name of the window.</para>
		/// </summary>
		/// <value>The <see cref="System.Byte"/>.</value>
		/// <returns></returns>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
		public string rgchMember;
	}

	/// <summary>Specifies a keyword to search for and the keyword table to be searched by Windows Help.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmultikeyhelpa typedef struct tagMULTIKEYHELPA { #if ...
	// DWORD mkSize; #else WORD mkSize; #endif CHAR mkKeylist; CHAR szKeyphrase[1]; } MULTIKEYHELPA, *PMULTIKEYHELPA, *LPMULTIKEYHELPA;
	[PInvokeData("winuser.h", MSDNShortId = "5fe0cd44-196c-4d9a-b9f8-2a97a92f2545")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MULTIKEYHELP
	{
		/// <summary>The mk size</summary>
		public uint mkSize;

		/// <summary>
		/// <para>Type: <c>TCHAR</c></para>
		/// <para>A single character that identifies the keyword table to search.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string mkKeylist;

		/// <summary>
		/// <para>Type: <c>TCHAR[1]</c></para>
		/// <para>A null-terminated text string that specifies the keyword to locate in the keyword table.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 253)]
		public string szKeyphrase;
	}
}