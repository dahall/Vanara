using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Items from the ComDlg32.dll</summary>
public static partial class ComDlg32
{
	/// <summary>
	/// A set of bit flags that you can use to initialize the Color dialog box. When the dialog box returns, it sets these flags to
	/// indicate the user's input.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagCHOOSECOLORA~r1")]
	[Flags]
	public enum CC
	{
		/// <summary>Causes the dialog box to display all available colors in the set of basic colors.</summary>
		CC_ANYCOLOR = 0x00000100,

		/// <summary>
		/// Enables the hook procedure specified in the lpfnHook member of this structure. This flag is used only to initialize the
		/// dialog box.
		/// </summary>
		CC_ENABLEHOOK = 0x00000010,

		/// <summary>
		/// The hInstance and lpTemplateName members specify a dialog box template to use in place of the default template. This flag is
		/// used only to initialize the dialog box.
		/// </summary>
		CC_ENABLETEMPLATE = 0x00000020,

		/// <summary>
		/// The hInstance member identifies a data block that contains a preloaded dialog box template. The system ignores the
		/// lpTemplateName member if this flag is specified. This flag is used only to initialize the dialog box.
		/// </summary>
		CC_ENABLETEMPLATEHANDLE = 0x00000040,

		/// <summary>
		/// Causes the dialog box to display the additional controls that allow the user to create custom colors. If this flag is not
		/// set, the user must click the Define Custom Color button to display the custom color controls.
		/// </summary>
		CC_FULLOPEN = 0x00000002,

		/// <summary>Disables the Define Custom Color button.</summary>
		CC_PREVENTFULLOPEN = 0x00000004,

		/// <summary>Causes the dialog box to use the color specified in the rgbResult member as the initial color selection.</summary>
		CC_RGBINIT = 0x00000001,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </summary>
		CC_SHOWHELP = 0x00000008,

		/// <summary>Causes the dialog box to display only solid colors in the set of basic colors.</summary>
		CC_SOLIDCOLOR = 0x00000080,
	}

	/// <summary>
	/// An error code returned by the CommDlgExtendedError function.
	/// </summary>
	/// <remarks>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CDERR</term>
	/// <term>General error codes that can be returned for any of the common dialog box functions.</term>
	/// </item>
	/// <item>
	/// <term>PDERR</term>
	/// <term>Error codes returned for the PrintDlg function.</term>
	/// </item>
	/// <item>
	/// </item>
	/// <item>
	/// <term>CFERR</term>
	/// <term>Error codes returned for the ChooseFont function.</term>
	/// </item>
	/// <item>
	/// <term>FNERR</term>
	/// <term>Error codes returned for the GetOpenFileName and GetSaveFileName functions.</term>
	/// </item>
	/// <item>
	/// <term>FRERR</term>
	/// <term>Error codes returned for the FindText and ReplaceText functions.</term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("cderr.h")]
	public enum ERR : uint
	{
		/// <summary>
		/// The dialog box could not be created. The common dialog box function's call to the DialogBox function failed. For example,
		/// this error occurs if the common dialog box call specifies an invalid window handle.
		/// </summary>
		CDERR_DIALOGFAILURE = 0xFFFF,

		/// <summary>
		/// The common dialog box function failed to find a specified resource.
		/// </summary>
		CDERR_FINDRESFAILURE = 0x0006,

		/// <summary>
		///  The common dialog box function failed during initialization. This error often occurs when sufficient memory is not available.
		/// </summary>
		CDERR_INITIALIZATION = 0x0002,

		/// <summary>
		/// The common dialog box function failed to load a specified resource.
		/// </summary>
		CDERR_LOADRESFAILURE = 0x0007,

		/// <summary>
		/// The common dialog box function failed to load a specified string.
		/// </summary>
		CDERR_LOADSTRFAILURE = 0x0005,

		/// <summary>
		/// The common dialog box function failed to lock a specified resource.
		/// </summary>
		CDERR_LOCKRESFAILURE = 0x0008,

		/// <summary>
		/// The common dialog box function was unable to allocate memory for internal structures.
		/// </summary>
		CDERR_MEMALLOCFAILURE = 0x0009,

		/// <summary>
		/// The common dialog box function was unable to lock the memory associated with a handle.
		/// </summary>
		CDERR_MEMLOCKFAILURE = 0x000A,

		/// <summary>
		/// The <c>ENABLETEMPLATE</c> flag was set in the <c>Flags</c> member of the initialization structure for the corresponding common
		/// dialog box, but you failed to provide a corresponding instance handle.
		/// </summary>
		CDERR_NOHINSTANCE = 0x0004,

		/// <summary>
		/// The <c>ENABLEHOOK</c> flag was set in the <c>Flags</c> member of the initialization structure for the corresponding common
		/// dialog box, but you failed to provide a pointer to a corresponding hook procedure.
		/// </summary>
		CDERR_NOHOOK = 0x000B,

		/// <summary>
		/// The <c>ENABLETEMPLATE</c> flag was set in the <c>Flags</c> member of the initialization structure for the corresponding common dialog
		/// box, but you failed to provide a corresponding template.
		/// </summary>
		CDERR_NOTEMPLATE = 0x0003,

		/// <summary>
		/// The RegisterWindowMessage function returned an error code when it was called by the common dialog box function.
		/// </summary>
		CDERR_REGISTERMSGFAIL = 0x000C,

		/// <summary>
		/// The <c>lStructSize</c> member of the initialization structure for the corresponding common dialog box is invalid.
		/// </summary>
		CDERR_STRUCTSIZE = 0x0001,

		/// <summary>
		/// The PrintDlg function failed when it attempted to create an information context.
		/// </summary>
		PDERR_CREATEICFAILURE = 0x100A,

		/// <summary>
		/// You called the PrintDlg function with the <c>DN_DEFAULTPRN</c> flag specified in the <c>wDefault</c> member of the <c>DEVNAMES</c> structure,
		/// but the printer described by the other structure members did not match the current default printer. This error occurs when
		/// you store the <c>DEVNAMES</c> structure, and the user changes the default printer by using the Control Panel.
		/// <para>To use the printer described by the <c>DEVNAMES</c> structure, clear the <c>DN_DEFAULTPRN</c> flag and call PrintDlg again.</para>
		/// <para>To use the default printer, replace the <c>DEVNAMES</c> structure (and the structure, if one exists) with <c>NULL</c>; and call PrintDlg again.</para>
		/// </summary>
		PDERR_DEFAULTDIFFERENT = 0x100C,

		/// <summary>
		/// The data in the <c>DEVMODE</c> and <c>DEVNAMES</c> structures describes two different printers.
		/// </summary>
		PDERR_DNDMMISMATCH = 0x1009,

		/// <summary>
		/// The printer driver failed to initialize a <c>DEVMODE</c> structure.
		/// </summary>
		PDERR_GETDEVMODEFAIL = 0x1005,

		/// <summary>
		/// The PrintDlg function failed during initialization, and there is no more specific extended error code to describe the failure.
		/// This is the generic default error code for the function.
		/// </summary>
		PDERR_INITFAILURE = 0x1006,

		/// <summary>
		/// The PrintDlg function failed to load the device driver for the specified printer.
		/// </summary>
		PDERR_LOADDRVFAILURE = 0x1004,

		/// <summary>
		/// A default printer does not exist.
		/// </summary>
		PDERR_NODEFAULTPRN = 0x1008,

		/// <summary>
		/// No printer drivers were found.
		/// </summary>
		PDERR_NODEVICES = 0x1007,

		/// <summary>
		/// The PrintDlg function failed to parse the strings in the [devices] section of the WIN.INI file.
		/// </summary>
		PDERR_PARSEFAILURE = 0x1002,

		/// <summary>
		/// The [devices] section of the WIN.INI file did not contain an entry for the requested printer.
		/// </summary>
		PDERR_PRINTERNOTFOUND = 0x100B,

		/// <summary>
		/// The <c>PD_RETURNDEFAULT</c> flag was specified in the Flags member of the <c>PRINTDLG</c> structure, but the <c>hDevMode</c> or <c>hDevNames</c> member was not <c>NULL</c>.
		/// </summary>
		PDERR_RETDEFFAILURE = 0x1003,

		/// <summary>
		/// The PrintDlg function failed to load the required resources.
		/// </summary>
		PDERR_SETUPFAILURE = 0x1001,

		/// <summary>
		/// The size specified in the <c>nSizeMax</c> member of the <c>CHOOSEFONT</c> structure is less than the size specified in the <c>nSizeMin</c> member.
		/// </summary>
		CFERR_MAXLESSTHANMIN = 0x2002,

		/// <summary>
		/// No fonts exist.
		/// </summary>
		CFERR_NOFONTS = 0x2001,

		/// <summary>
		/// The buffer pointed to by the <c>lpstrFile</c> member of the <c>OPENFILENAME</c> structure is too small for the file name specified
		/// by the user. The first two bytes of the <c>lpstrFile</c> buffer contain an integer value specifying the size required to receive
		/// the full name, in characters.
		/// </summary>
		FNERR_BUFFERTOOSMALL = 0x3003,

		/// <summary>
		/// A file name is invalid.
		/// </summary>
		FNERR_INVALIDFILENAME = 0x3002,

		/// <summary>
		/// An attempt to subclass a list box failed because sufficient memory was not available.
		/// </summary>
		FNERR_SUBCLASSFAILURE = 0x3001,

		/// <summary>
		/// A member of the <c>FINDREPLACE</c> structure points to an invalid buffer.
		/// </summary>
		FRERR_BUFFERLENGTHZERO = 0x4001,
	}

	/// <summary>
	/// A set of bit flags that you can use to initialize the Font dialog box. When the dialog box returns, it sets these flags to
	/// indicate the user input.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagCHOOSEFONTA")]
	[Flags]
	public enum CF : uint
	{
		/// <summary>
		/// Causes the dialog box to display the Apply button. You should provide a hook procedure to process WM_COMMAND messages for
		/// the Apply button. The hook procedure can send the WM_CHOOSEFONT_GETLOGFONT message to the dialog box to retrieve the address
		/// of the structure that contains the current selections for the font.
		/// </summary>
		CF_APPLY = 0x00000200,

		/// <summary>
		/// This flag is obsolete. To limit font selections to all scripts except those that use the OEM or Symbol character sets, use
		/// CF_SCRIPTSONLY. To get the original CF_ANSIONLY behavior, use CF_SELECTSCRIPT and specify ANSI_CHARSET in the lfCharSet
		/// member of the LOGFONT structure pointed to by lpLogFont.
		/// </summary>
		CF_ANSIONLY = 0x00000400,

		/// <summary>
		/// This flag is ignored for font enumeration.
		/// <para>
		/// Windows Vista and Windows XP/2000: Causes the dialog box to list the available printer and screen fonts. The hDC member is a
		/// handle to the device context or information context associated with the printer. This flag is a combination of the
		/// CF_SCREENFONTS and CF_PRINTERFONTS flags.
		/// </para>
		/// </summary>
		CF_BOTH = 0x00000003,

		/// <summary>
		/// Causes the dialog box to display the controls that allow the user to specify strikeout, underline, and text color options.
		/// If this flag is set, you can use the rgbColors member to specify the initial text color. You can use the lfStrikeOut and
		/// lfUnderline members of the structure pointed to by lpLogFont to specify the initial settings of the strikeout and underline
		/// check boxes. ChooseFont can use these members to return the user's selections.
		/// </summary>
		CF_EFFECTS = 0x00000100,

		/// <summary>Enables the hook procedure specified in the lpfnHook member of this structure.</summary>
		CF_ENABLEHOOK = 0x00000008,

		/// <summary>
		/// Indicates that the hInstance and lpTemplateName members specify a dialog box template to use in place of the default template.
		/// </summary>
		CF_ENABLETEMPLATE = 0x00000010,

		/// <summary>
		/// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template. The system
		/// ignores the lpTemplateName member if this flag is specified.
		/// </summary>
		CF_ENABLETEMPLATEHANDLE = 0x00000020,

		/// <summary>ChooseFont should enumerate and allow selection of only fixed-pitch fonts.</summary>
		CF_FIXEDPITCHONLY = 0x00004000,

		/// <summary>
		/// ChooseFont should indicate an error condition if the user attempts to select a font or style that is not listed in the
		/// dialog box.
		/// </summary>
		CF_FORCEFONTEXIST = 0x00010000,

		/// <summary>
		/// ChooseFont should additionally display fonts that are set to Hide in Fonts Control Panel.
		/// <para>Windows Vista and Windows XP/2000: This flag is not supported until Windows 7.</para>
		/// </summary>
		CF_INACTIVEFONTS = 0x02000000,

		/// <summary>ChooseFont should use the structure pointed to by the lpLogFont member to initialize the dialog box controls.</summary>
		CF_INITTOLOGFONTSTRUCT = 0x00000040,

		/// <summary>ChooseFont should select only font sizes within the range specified by the nSizeMin and nSizeMax members.</summary>
		CF_LIMITSIZE = 0x00002000,

		/// <summary>Same as the CF_NOVECTORFONTS flag.</summary>
		CF_NOOEMFONTS = 0x00000800,

		/// <summary>
		/// When using a LOGFONT structure to initialize the dialog box controls, use this flag to prevent the dialog box from
		/// displaying an initial selection for the font name combo box. This is useful when there is no single font name that applies
		/// to the text selection.
		/// </summary>
		CF_NOFACESEL = 0x00080000,

		/// <summary>
		/// Disables the Script combo box. When this flag is set, the lfCharSet member of the LOGFONT structure is set to
		/// DEFAULT_CHARSET when ChooseFont returns. This flag is used only to initialize the dialog box.
		/// </summary>
		CF_NOSCRIPTSEL = 0x00800000,

		/// <summary>ChooseFont should not display or allow selection of font simulations.</summary>
		CF_NOSIMULATIONS = 0x00001000,

		/// <summary>
		/// When using a structure to initialize the dialog box controls, use this flag to prevent the dialog box from displaying an
		/// initial selection for the Font Size combo box. This is useful when there is no single font size that applies to the text selection.
		/// </summary>
		CF_NOSIZESEL = 0x00200000,

		/// <summary>
		/// When using a LOGFONT structure to initialize the dialog box controls, use this flag to prevent the dialog box from
		/// displaying an initial selection for the Font Style combo box. This is useful when there is no single font style that applies
		/// to the text selection.
		/// </summary>
		CF_NOSTYLESEL = 0x00100000,

		/// <summary>ChooseFont should not allow vector font selections.</summary>
		CF_NOVECTORFONTS = 0x00000800,

		/// <summary>Causes the Font dialog box to list only horizontally oriented fonts.</summary>
		CF_NOVERTFONTS = 0x01000000,

		/// <summary>
		/// This flag is ignored for font enumeration.
		/// <para>
		/// Windows Vista and Windows XP/2000: Causes the dialog box to list only the fonts supported by the printer associated with the
		/// device context or information context identified by the hDC member. It also causes the font type description label to appear
		/// at the bottom of the Font dialog box.
		/// </para>
		/// </summary>
		CF_PRINTERFONTS = 0x00000002,

		/// <summary>
		/// Specifies that ChooseFont should allow only the selection of scalable fonts. Scalable fonts include vector fonts, scalable
		/// printer fonts, TrueType fonts, and fonts scaled by other technologies.
		/// </summary>
		CF_SCALABLEONLY = 0x00020000,

		/// <summary>
		/// This flag is ignored for font enumeration.
		/// <para>Windows Vista and Windows XP/2000: Causes the dialog box to list only the screen fonts supported by the system.</para>
		/// </summary>
		CF_SCREENFONTS = 0x00000001,

		/// <summary>
		/// ChooseFont should allow selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.
		/// This supersedes the CF_ANSIONLY value.
		/// </summary>
		CF_SCRIPTSONLY = 0x00000400,

		/// <summary>
		/// When specified on input, only fonts with the character set identified in the lfCharSet member of the LOGFONT structure are
		/// displayed. The user will not be allowed to change the character set specified in the Scripts combo box.
		/// </summary>
		CF_SELECTSCRIPT = 0x00400000,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </summary>
		CF_SHOWHELP = 0x00000004,

		/// <summary>ChooseFont should only enumerate and allow the selection of TrueType fonts.</summary>
		CF_TTONLY = 0x00040000,

		/// <summary>
		/// The lpszStyle member is a pointer to a buffer that contains style data that ChooseFont should use to initialize the Font
		/// Style combo box. When the user closes the dialog box, ChooseFont copies style data for the user's selection to this buffer.
		/// <para>
		/// Note To globalize your application, you should specify the style by using the lfWeight and lfItalic members of the LOGFONT
		/// structure pointed to by lpLogFont. The style name may change depending on the system user interface language.
		/// </para>
		/// </summary>
		CF_USESTYLE = 0x00000080,

		/// <summary>
		/// Obsolete. ChooseFont ignores this flag.
		/// <para>
		/// Windows Vista and Windows XP/2000: ChooseFont should allow only the selection of fonts available on both the printer and the
		/// display. If this flag is specified, the CF_SCREENSHOTS and CF_PRINTERFONTS, or CF_BOTH flags should also be specified.
		/// </para>
		/// </summary>
		CF_WYSIWYG = 0x00008000,
	}

	/// <summary>Indicates whether the strings contained in the DEVNAMES structure identify the default printer.</summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagDEVNAMES")]
	[Flags]
	public enum DN : ushort
	{
		/// <summary>
		/// The DN_DEFAULTPRN flag is used if the default printer was selected. If a specific printer is selected, the flag is not used.
		/// </summary>
		DN_DEFAULTPRN = 1
	}

	/// <summary>
	/// A set of bit flags you can use to initialize the dialog box. When the dialog box returns, it sets these flags to indicate the
	/// user's input.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagOFNA")]
	[Flags]
	public enum OFN
	{
		/// <summary>
		/// The File Name list box allows multiple selections. If you also set the OFN_EXPLORER flag, the dialog box uses the
		/// Explorer-style user interface; otherwise, it uses the old-style user interface.
		/// <para>
		/// If the user selects more than one file, the lpstrFile buffer returns the path to the current directory followed by the file
		/// names of the selected files. The nFileOffset member is the offset, in bytes or characters, to the first file name, and the
		/// nFileExtension member is not used. For Explorer-style dialog boxes, the directory and file name strings are NULL separated,
		/// with an extra NULL character after the last file name. This format enables the Explorer-style dialog boxes to return long
		/// file names that include spaces. For old-style dialog boxes, the directory and file name strings are separated by spaces and
		/// the function uses short file names for file names with spaces. You can use the FindFirstFile function to convert between
		/// long and short file names.
		/// </para>
		/// <para>
		/// If you specify a custom template for an old-style dialog box, the definition of the File Name list box must contain the
		/// LBS_EXTENDEDSEL value.
		/// </para>
		/// </summary>
		OFN_ALLOWMULTISELECT = 0x00000200,

		/// <summary>
		/// If the user specifies a file that does not exist, this flag causes the dialog box to prompt the user for permission to
		/// create the file. If the user chooses to create the file, the dialog box closes and the function returns the specified name;
		/// otherwise, the dialog box remains open. If you use this flag with the OFN_ALLOWMULTISELECT flag, the dialog box allows the
		/// user to specify only one nonexistent file.
		/// </summary>
		OFN_CREATEPROMPT = 0x00002000,

		/// <summary>
		/// Prevents the system from adding a link to the selected file in the file system directory that contains the user's most
		/// recently used documents. To retrieve the location of this directory, call the SHGetSpecialFolderLocation function with the
		/// CSIDL_RECENT flag.
		/// </summary>
		OFN_DONTADDTORECENT = 0x02000000,

		/// <summary>Enables the hook function specified in the lpfnHook member.</summary>
		OFN_ENABLEHOOK = 0x00000020,

		/// <summary>
		/// Causes the dialog box to send CDN_INCLUDEITEM notification messages to your OFNHookProc hook procedure when the user opens a
		/// folder. The dialog box sends a notification for each item in the newly opened folder. These messages enable you to control
		/// which items the dialog box displays in the folder's item list.
		/// </summary>
		OFN_ENABLEINCLUDENOTIFY = 0x00400000,

		/// <summary>
		/// Enables the Explorer-style dialog box to be resized using either the mouse or the keyboard. By default, the Explorer-style
		/// Open and Save As dialog boxes allow the dialog box to be resized regardless of whether this flag is set. This flag is
		/// necessary only if you provide a hook procedure or custom template. The old-style dialog box does not permit resizing.
		/// </summary>
		OFN_ENABLESIZING = 0x00800000,

		/// <summary>
		/// The lpTemplateName member is a pointer to the name of a dialog template resource in the module identified by the hInstance
		/// member. If the OFN_EXPLORER flag is set, the system uses the specified template to create a dialog box that is a child of
		/// the default Explorer-style dialog box. If the OFN_EXPLORER flag is not set, the system uses the template to create an
		/// old-style dialog box that replaces the default dialog box.
		/// </summary>
		OFN_ENABLETEMPLATE = 0x00000040,

		/// <summary>
		/// The hInstance member identifies a data block that contains a preloaded dialog box template. The system ignores
		/// lpTemplateName if this flag is specified. If the OFN_EXPLORER flag is set, the system uses the specified template to create
		/// a dialog box that is a child of the default Explorer-style dialog box. If the OFN_EXPLORER flag is not set, the system uses
		/// the template to create an old-style dialog box that replaces the default dialog box.
		/// </summary>
		OFN_ENABLETEMPLATEHANDLE = 0x00000080,

		/// <summary>
		/// Indicates that any customizations made to the Open or Save As dialog box use the Explorer-style customization methods. For
		/// more information, see Explorer-Style Hook Procedures and Explorer-Style Custom Templates.
		/// <para>
		/// By default, the Open and Save As dialog boxes use the Explorer-style user interface regardless of whether this flag is set.
		/// This flag is necessary only if you provide a hook procedure or custom template, or set the OFN_ALLOWMULTISELECT flag.
		/// </para>
		/// <para>
		/// If you want the old-style user interface, omit the OFN_EXPLORER flag and provide a replacement old-style template or hook
		/// procedure. If you want the old style but do not need a custom template or hook procedure, simply provide a hook procedure
		/// that always returns FALSE.
		/// </para>
		/// </summary>
		OFN_EXPLORER = 0x00080000,

		/// <summary>
		/// The user typed a file name extension that differs from the extension specified by lpstrDefExt. The function does not use
		/// this flag if lpstrDefExt is NULL.
		/// </summary>
		OFN_EXTENSIONDIFFERENT = 0x00000400,

		/// <summary>
		/// The user can type only names of existing files in the File Name entry field. If this flag is specified and the user enters
		/// an invalid name, the dialog box procedure displays a warning in a message box. If this flag is specified, the
		/// OFN_PATHMUSTEXIST flag is also used. This flag can be used in an Open dialog box. It cannot be used with a Save As dialog box.
		/// </summary>
		OFN_FILEMUSTEXIST = 0x00001000,

		/// <summary>
		/// Forces the showing of system and hidden files, thus overriding the user setting to show or not show hidden files. However, a
		/// file that is marked both system and hidden is not shown.
		/// </summary>
		OFN_FORCESHOWHIDDEN = 0x10000000,

		/// <summary>Hides the Read Only check box.</summary>
		OFN_HIDEREADONLY = 0x00000004,

		/// <summary>
		/// For old-style dialog boxes, this flag causes the dialog box to use long file names. If this flag is not specified, or if the
		/// OFN_ALLOWMULTISELECT flag is also set, old-style dialog boxes use short file names (8.3 format) for file names with spaces.
		/// Explorer-style dialog boxes ignore this flag and always display long file names.
		/// </summary>
		OFN_LONGNAMES = 0x00200000,

		/// <summary>
		/// Restores the current directory to its original value if the user changed the directory while searching for files.
		/// <para>This flag is ineffective for GetOpenFileName.</para>
		/// </summary>
		OFN_NOCHANGEDIR = 0x00000008,

		/// <summary>
		/// Directs the dialog box to return the path and file name of the selected shortcut (.LNK) file. If this value is not
		/// specified, the dialog box returns the path and file name of the file referenced by the shortcut.
		/// </summary>
		OFN_NODEREFERENCELINKS = 0x00100000,

		/// <summary>
		/// For old-style dialog boxes, this flag causes the dialog box to use short file names (8.3 format). Explorer-style dialog
		/// boxes ignore this flag and always display long file names.
		/// </summary>
		OFN_NOLONGNAMES = 0x00040000,

		/// <summary>Hides and disables the Network button.</summary>
		OFN_NONETWORKBUTTON = 0x00020000,

		/// <summary>The returned file does not have the Read Only check box selected and is not in a write-protected directory.</summary>
		OFN_NOREADONLYRETURN = 0x00008000,

		/// <summary>
		/// The file is not created before the dialog box is closed. This flag should be specified if the application saves the file on
		/// a create-nonmodify network share. When an application specifies this flag, the library does not check for write protection,
		/// a full disk, an open drive door, or network protection. Applications using this flag must perform file operations carefully,
		/// because a file cannot be reopened once it is closed.
		/// </summary>
		OFN_NOTESTFILECREATE = 0x00010000,

		/// <summary>
		/// The common dialog boxes allow invalid characters in the returned file name. Typically, the calling application uses a hook
		/// procedure that checks the file name by using the FILEOKSTRING message. If the text box in the edit control is empty or
		/// contains nothing but spaces, the lists of files and directories are updated. If the text box in the edit control contains
		/// anything else, nFileOffset and nFileExtension are set to values generated by parsing the text. No default extension is added
		/// to the text, nor is text copied to the buffer specified by lpstrFileTitle. If the value specified by nFileOffset is less
		/// than zero, the file name is invalid. Otherwise, the file name is valid, and nFileExtension and nFileOffset can be used as if
		/// the OFN_NOVALIDATE flag had not been specified.
		/// </summary>
		OFN_NOVALIDATE = 0x00000100,

		/// <summary>
		/// Causes the Save As dialog box to generate a message box if the selected file already exists. The user must confirm whether
		/// to overwrite the file.
		/// </summary>
		OFN_OVERWRITEPROMPT = 0x00000002,

		/// <summary>
		/// The user can type only valid paths and file names. If this flag is used and the user types an invalid path and file name in
		/// the File Name entry field, the dialog box function displays a warning in a message box.
		/// </summary>
		OFN_PATHMUSTEXIST = 0x00000800,

		/// <summary>
		/// Causes the Read Only check box to be selected initially when the dialog box is created. This flag indicates the state of the
		/// Read Only check box when the dialog box is closed.
		/// </summary>
		OFN_READONLY = 0x00000001,

		/// <summary>
		/// Specifies that if a call to the OpenFile function fails because of a network sharing violation, the error is ignored and the
		/// dialog box returns the selected file name. If this flag is not set, the dialog box notifies your hook procedure when a
		/// network sharing violation occurs for the file name specified by the user. If you set the OFN_EXPLORER flag, the dialog box
		/// sends the CDN_SHAREVIOLATION message to the hook procedure. If you do not set OFN_EXPLORER, the dialog box sends the
		/// SHAREVISTRING registered message to the hook procedure.
		/// </summary>
		OFN_SHAREAWARE = 0x00004000,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button. An Explorer-style dialog box sends a
		/// CDN_HELP notification message to your hook procedure when the user clicks the Help button.
		/// </summary>
		OFN_SHOWHELP = 0x00000010,
	}

	/// <summary>A set of bit flags you can use to initialize the dialog box.</summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagOFNA")]
	[Flags]
	public enum OFN_EX
	{
		/// <summary>
		/// If this flag is set, the places bar is not displayed. If this flag is not set, Explorer-style dialog boxes include a places
		/// bar containing icons for commonly-used folders, such as Favorites and Desktop.
		/// </summary>
		OFN_EX_NOPLACESBAR = 0x00000001,
	}

	/// <summary>Initializes the Print dialog box. When the dialog box returns, it sets these flags to indicate the user's input.</summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPDA")]
	[Flags]
	public enum PD
	{
		/// <summary>
		/// The default flag that indicates that the All radio button is initially selected. This flag is used as a placeholder to
		/// indicate that the PD_PAGENUMS and PD_SELECTION flags are not specified.
		/// </summary>
		PD_ALLPAGES = 0x00000000,

		/// <summary>
		/// If this flag is set, the Collate check box is selected.
		/// <para>
		/// If this flag is set when the PrintDlg function returns, the application must simulate collation of multiple copies. For more
		/// information, see the description of the PD_USEDEVMODECOPIESANDCOLLATE flag.
		/// </para>
		/// <para>See PD_NOPAGENUMS.</para>
		/// </summary>
		PD_COLLATE = 0x00000010,

		/// <summary>Disables the Print to File check box.</summary>
		PD_DISABLEPRINTTOFILE = 0x00080000,

		/// <summary>
		/// Enables the hook procedure specified in the lpfnPrintHook member. This enables the hook procedure for the Print dialog box.
		/// </summary>
		PD_ENABLEPRINTHOOK = 0x00001000,

		/// <summary>
		/// Indicates that the hInstance and lpPrintTemplateName members specify a replacement for the default Print dialog box template.
		/// </summary>
		PD_ENABLEPRINTTEMPLATE = 0x00004000,

		/// <summary>
		/// Indicates that the hPrintTemplate member identifies a data block that contains a preloaded dialog box template. This
		/// template replaces the default template for the Print dialog box. The system ignores the lpPrintTemplateName member if this
		/// flag is specified.
		/// </summary>
		PD_ENABLEPRINTTEMPLATEHANDLE = 0x00010000,

		/// <summary>
		/// Enables the hook procedure specified in the lpfnSetupHook member. This enables the hook procedure for the Print Setup dialog box.
		/// </summary>
		PD_ENABLESETUPHOOK = 0x00002000,

		/// <summary>
		/// Indicates that the hInstance and lpSetupTemplateName members specify a replacement for the default Print Setup dialog box template.
		/// </summary>
		PD_ENABLESETUPTEMPLATE = 0x00008000,

		/// <summary>
		/// Indicates that the hSetupTemplate member identifies a data block that contains a preloaded dialog box template. This
		/// template replaces the default template for the Print Setup dialog box. The system ignores the lpSetupTemplateName member if
		/// this flag is specified.
		/// </summary>
		PD_ENABLESETUPTEMPLATEHANDLE = 0x00020000,

		/// <summary>Hides the Print to File check box.</summary>
		PD_HIDEPRINTTOFILE = 0x00100000,

		/// <summary>Hides and disables the Network button.</summary>
		PD_NONETWORKBUTTON = 0x00200000,

		/// <summary>
		/// Disables the Pages radio button and the associated edit controls. Also, it causes the Collate check box to appear in the dialog.
		/// </summary>
		PD_NOPAGENUMS = 0x00000008,

		/// <summary>Disables the Selection radio button.</summary>
		PD_NOSELECTION = 0x00000004,

		/// <summary>Prevents the warning message from being displayed when there is no default printer.</summary>
		PD_NOWARNING = 0x00000080,

		/// <summary>
		/// If this flag is set, the Pages radio button is selected. If this flag is set when the PrintDlg function returns, the
		/// nFromPage and nToPage members indicate the starting and ending pages specified by the user.
		/// </summary>
		PD_PAGENUMS = 0x00000002,

		/// <summary>Causes the system to display the Print Setup dialog box rather than the Print dialog box.</summary>
		PD_PRINTSETUP = 0x00000040,

		/// <summary>
		/// If this flag is set, the Print to File check box is selected. If this flag is set when the PrintDlg function returns, the
		/// offset indicated by the wOutputOffset member of the DEVNAMES structure contains the string "FILE:". When you call the
		/// StartDoc function to start the printing operation, specify this "FILE:" string in the lpszOutput member of the DOCINFO
		/// structure. Specifying this string causes the print subsystem to query the user for the name of the output file.
		/// </summary>
		PD_PRINTTOFILE = 0x00000020,

		/// <summary>
		/// Causes PrintDlg to return a device context matching the selections the user made in the dialog box. The device context is
		/// returned in hDC.
		/// </summary>
		PD_RETURNDC = 0x00000100,

		/// <summary>
		/// If this flag is set, the PrintDlg function does not display the dialog box. Instead, it sets the hDevNames and hDevMode
		/// members to handles to DEVMODE and DEVNAMES structures that are initialized for the system default printer. Both hDevNames
		/// and hDevMode must be NULL, or PrintDlg returns an error.
		/// </summary>
		PD_RETURNDEFAULT = 0x00000400,

		/// <summary>
		/// Similar to the PD_RETURNDC flag, except this flag returns an information context rather than a device context. If neither
		/// PD_RETURNDC nor PD_RETURNIC is specified, hDC is undefined on output.
		/// </summary>
		PD_RETURNIC = 0x00000200,

		/// <summary>
		/// If this flag is set, the Selection radio button is selected. If neither PD_PAGENUMS nor PD_SELECTION is set, the All radio
		/// button is selected.
		/// </summary>
		PD_SELECTION = 0x00000001,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </summary>
		PD_SHOWHELP = 0x00000800,

		/// <summary>Same as PD_USEDEVMODECOPIESANDCOLLATE.</summary>
		PD_USEDEVMODECOPIES = 0x00040000,

		/// <summary>
		/// This flag indicates whether your application supports multiple copies and collation. Set this flag on input to indicate that
		/// your application does not support multiple copies and collation. In this case, the nCopies member of the PRINTDLG structure
		/// always returns 1, and PD_COLLATE is never set in the Flags member.
		/// <para>
		/// If this flag is not set, the application is responsible for printing and collating multiple copies. In this case, the
		/// nCopies member of the PRINTDLG structure indicates the number of copies the user wants to print, and the PD_COLLATE flag in
		/// the Flags member indicates whether the user wants collation.
		/// </para>
		/// <para>
		/// Regardless of whether this flag is set, an application can determine from nCopies and PD_COLLATE how many copies to render
		/// and whether to print them collated.
		/// </para>
		/// <para>
		/// If this flag is set and the printer driver does not support multiple copies, the Copies edit control is disabled. Similarly,
		/// if this flag is set and the printer driver does not support collation, the Collate check box is disabled.
		/// </para>
		/// <para>
		/// The dmCopies and dmCollate members of the DEVMODE structure contain the copies and collate information used by the printer
		/// driver. If this flag is set and the printer driver supports multiple copies, the dmCopies member indicates the number of
		/// copies requested by the user. If this flag is set and the printer driver supports collation, the dmCollate member of the
		/// DEVMODE structure indicates whether the user wants collation. If this flag is not set, the dmCopies member always returns 1,
		/// and the dmCollate member is always zero.
		/// </para>
		/// <para>
		/// Known issue on Windows 2000/XP/2003: If this flag is not set before calling PrintDlg, PrintDlg might swap nCopies and
		/// dmCopies values when it returns. The workaround for this issue is use dmCopies if its value is larger than 1, else, use
		/// nCopies, for you to to get the actual number of copies to be printed when PrintDlg returns.
		/// </para>
		/// </summary>
		PD_USEDEVMODECOPIESANDCOLLATE = 0x00040000,

		/// <summary/>
		PD_CURRENTPAGE = 0x00400000,

		/// <summary/>
		PD_NOCURRENTPAGE = 0x00800000,

		/// <summary/>
		PD_EXCLUSIONFLAGS = 0x01000000,

		/// <summary/>
		PD_USELARGETEMPLATE = 0x10000000,
	}

	/// <summary>
	/// A set of bit flags that can exclude items from the printer driver property pages in the Print property sheet. This value is used
	/// only if the PD_EXCLUSIONFLAGS flag is set in the Flags member. Exclusion flags should be used only if the item to be excluded
	/// will be included on either the General page or on an application-defined page in the Print property sheet.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPDEXA")]
	public enum PD_EXCL : uint
	{
		/// <summary>
		/// Excludes the Copies and Collate controls from the printer driver property pages in a Print property sheet. This flag should
		/// always be set when the application uses the default Copies and Collate controls provided by the lower portion of the General
		/// page of the Print property sheet.
		/// </summary>
		PD_EXCL_COPIESANDCOLLATE = DMFIELDS.DM_COPIES | DMFIELDS.DM_COLLATE
	}

	/// <summary>
	/// On input, set this member to zero. If the PrintDlgEx function returns S_OK, dwResultAction contains the outcome of the dialog.
	/// If PrintDlgEx returns an error, this member should be ignored.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPDEXA")]
	public enum PD_RESULT
	{
		/// <summary>The user clicked the Cancel button. The information in the PRINTDLGEX structure is unchanged.</summary>
		PD_RESULT_CANCEL = 0,

		/// <summary>The user clicked the Print button. The PRINTDLGEX structure contains the information specified by the user.</summary>
		PD_RESULT_PRINT = 1,

		/// <summary>
		/// The user clicked the Apply button and later clicked the Cancel button. This indicates that the user wants to apply the
		/// changes made in the property sheet, but does not want to print yet. The PRINTDLGEX structure contains the information
		/// specified by the user at the time the Apply button was clicked.
		/// </summary>
		PD_RESULT_APPLY = 2
	}

	/// <summary>
	/// A set of bit flags that you can use to initialize the Page Setup dialog box. When the dialog box returns, it sets these flags to
	/// indicate the user's input.
	/// </summary>
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPSDA")]
	[Flags]
	public enum PSD
	{
		/// <summary>
		/// Sets the minimum values that the user can specify for the page margins to be the minimum margins allowed by the printer.
		/// This is the default. This flag is ignored if the PSD_MARGINS and PSD_MINMARGINS flags are also specified.
		/// </summary>
		PSD_DEFAULTMINMARGINS = 0x00000000,

		/// <summary>Disables the margin controls, preventing the user from setting the margins.</summary>
		PSD_DISABLEMARGINS = 0x00000010,

		/// <summary>Disables the orientation controls, preventing the user from setting the page orientation.</summary>
		PSD_DISABLEORIENTATION = 0x00000100,

		/// <summary>
		/// Prevents the dialog box from drawing the contents of the sample page. If you enable a PagePaintHook hook procedure, you can
		/// still draw the contents of the sample page.
		/// </summary>
		PSD_DISABLEPAGEPAINTING = 0x00080000,

		/// <summary>Disables the paper controls, preventing the user from setting page parameters such as the paper size and source.</summary>
		PSD_DISABLEPAPER = 0x00000200,

		/// <summary>
		/// Obsolete.
		/// <para>
		/// Windows XP/2000: Disables the Printer button, preventing the user from invoking a dialog box that contains additional
		/// printer setup information.
		/// </para>
		/// </summary>
		PSD_DISABLEPRINTER = 0x00000020,

		/// <summary>Enables the hook procedure specified in the lpfnPagePaintHook member.</summary>
		PSD_ENABLEPAGEPAINTHOOK = 0x00040000,

		/// <summary>Enables the hook procedure specified in the lpfnPageSetupHook member.</summary>
		PSD_ENABLEPAGESETUPHOOK = 0x00002000,

		/// <summary>
		/// Indicates that the hInstance and lpPageSetupTemplateName members specify a dialog box template to use in place of the
		/// default template.
		/// </summary>
		PSD_ENABLEPAGESETUPTEMPLATE = 0x00008000,

		/// <summary>
		/// Indicates that the hPageSetupTemplate member identifies a data block that contains a preloaded dialog box template. The
		/// system ignores the lpPageSetupTemplateName member if this flag is specified.
		/// </summary>
		PSD_ENABLEPAGESETUPTEMPLATEHANDLE = 0x00020000,

		/// <summary>
		/// Indicates that hundredths of millimeters are the unit of measurement for margins and paper size. The values in the rtMargin,
		/// rtMinMargin, and ptPaperSize members are in hundredths of millimeters. You can set this flag on input to override the
		/// default unit of measurement for the user's locale. When the function returns, the dialog box sets this flag to indicate the
		/// units used.
		/// </summary>
		PSD_INHUNDREDTHSOFMILLIMETERS = 0x00000008,

		/// <summary>
		/// Indicates that thousandths of inches are the unit of measurement for margins and paper size. The values in the rtMargin,
		/// rtMinMargin, and ptPaperSize members are in thousandths of inches. You can set this flag on input to override the default
		/// unit of measurement for the user's locale. When the function returns, the dialog box sets this flag to indicate the units used.
		/// </summary>
		PSD_INTHOUSANDTHSOFINCHES = 0x00000004,

		/// <summary>Reserved.</summary>
		PSD_INWININIINTLMEASURE = 0x00000000,

		/// <summary>
		/// Causes the system to use the values specified in the rtMargin member as the initial widths for the left, top, right, and
		/// bottom margins. If PSD_MARGINS is not set, the system sets the initial widths to one inch for all margins.
		/// </summary>
		PSD_MARGINS = 0x00000002,

		/// <summary>
		/// Causes the system to use the values specified in the rtMinMargin member as the minimum allowable widths for the left, top,
		/// right, and bottom margins. The system prevents the user from entering a width that is less than the specified minimum. If
		/// PSD_MINMARGINS is not specified, the system sets the minimum allowable widths to those allowed by the printer.
		/// </summary>
		PSD_MINMARGINS = 0x00000001,

		/// <summary>Hides and disables the Network button.</summary>
		PSD_NONETWORKBUTTON = 0x00200000,

		/// <summary>Prevents the system from displaying a warning message when there is no default printer.</summary>
		PSD_NOWARNING = 0x00000080,

		/// <summary>
		/// PageSetupDlg does not display the dialog box. Instead, it sets the hDevNames and hDevMode members to handles to DEVMODE and
		/// DEVNAMES structures that are initialized for the system default printer. PageSetupDlg returns an error if either hDevNames
		/// or hDevMode is not NULL.
		/// </summary>
		PSD_RETURNDEFAULT = 0x00000400,

		/// <summary>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </summary>
		PSD_SHOWHELP = 0x00000800,
	}

	/// <summary>
	/// Contains information the ChooseColor function uses to initialize the <c>Color</c> dialog box. After the user closes the dialog
	/// box, the system returns information about the user's selection in this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-choosecolora-r1 typedef struct tagCHOOSECOLORA { DWORD
	// lStructSize; HWND hwndOwner; HWND hInstance; COLORREF rgbResult; COLORREF *lpCustColors; DWORD Flags; LPARAM lCustData;
	// LPCCHOOKPROC lpfnHook; LPCSTR lpTemplateName; LPEDITMENU lpEditInfo; } CHOOSECOLORA, *LPCHOOSECOLORA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagCHOOSECOLORA~r1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CHOOSECOLOR
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length, in bytes, of the structure.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> if the
		/// dialog box has no owner.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// If the <c>CC_ENABLETEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to a memory
		/// object containing a dialog box template. If the <c>CC_ENABLETEMPLATE</c> flag is set, <c>hInstance</c> is a handle to a
		/// module that contains a dialog box template named by the <c>lpTemplateName</c> member. If neither
		/// <c>CC_ENABLETEMPLATEHANDLE</c> nor <c>CC_ENABLETEMPLATE</c> is set, this member is ignored.
		/// </para>
		/// </summary>
		public HWND hInstance;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// If the <c>CC_RGBINIT</c> flag is set, <c>rgbResult</c> specifies the color initially selected when the dialog box is
		/// created. If the specified color value is not among the available colors, the system selects the nearest solid color
		/// available. If <c>rgbResult</c> is zero or <c>CC_RGBINIT</c> is not set, the initially selected color is black. If the user
		/// clicks the <c>OK</c> button, <c>rgbResult</c> specifies the user's color selection. To create a COLORREF color value, use
		/// the RGB macro.
		/// </para>
		/// </summary>
		public COLORREF rgbResult;

		/// <summary>
		/// <para>Type: <c>COLORREF*</c></para>
		/// <para>
		/// A pointer to an array of 16 values that contain red, green, blue (RGB) values for the custom color boxes in the dialog box.
		/// If the user modifies these colors, the system updates the array with the new RGB values. To preserve new custom colors
		/// between calls to the ChooseColor function, you should allocate static memory for the array. To create a COLORREF color
		/// value, use the RGB macro.
		/// </para>
		/// </summary>
		public IntPtr lpCustColors;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that you can use to initialize the <c>Color</c> dialog box. When the dialog box returns, it sets these
		/// flags to indicate the user's input. This member can be a combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CC_ANYCOLOR 0x00000100</term>
		/// <term>Causes the dialog box to display all available colors in the set of basic colors.</term>
		/// </item>
		/// <item>
		/// <term>CC_ENABLEHOOK 0x00000010</term>
		/// <term>
		/// Enables the hook procedure specified in the lpfnHook member of this structure. This flag is used only to initialize the
		/// dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CC_ENABLETEMPLATE 0x00000020</term>
		/// <term>
		/// The hInstance and lpTemplateName members specify a dialog box template to use in place of the default template. This flag is
		/// used only to initialize the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CC_ENABLETEMPLATEHANDLE 0x00000040</term>
		/// <term>
		/// The hInstance member identifies a data block that contains a preloaded dialog box template. The system ignores the
		/// lpTemplateName member if this flag is specified. This flag is used only to initialize the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CC_FULLOPEN 0x00000002</term>
		/// <term>
		/// Causes the dialog box to display the additional controls that allow the user to create custom colors. If this flag is not
		/// set, the user must click the Define Custom Color button to display the custom color controls.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CC_PREVENTFULLOPEN 0x00000004</term>
		/// <term>Disables the Define Custom Color button.</term>
		/// </item>
		/// <item>
		/// <term>CC_RGBINIT 0x00000001</term>
		/// <term>Causes the dialog box to use the color specified in the rgbResult member as the initial color selection.</term>
		/// </item>
		/// <item>
		/// <term>CC_SHOWHELP 0x00000008</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CC_SOLIDCOLOR 0x00000080</term>
		/// <term>Causes the dialog box to display only solid colors in the set of basic colors.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CC Flags;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnHook</c> member. When the
		/// system sends the WM_INITDIALOG message to the hook procedure, the message's lParam parameter is a pointer to the
		/// <c>CHOOSECOLOR</c> structure specified when the dialog was created. The hook procedure can use this pointer to get the
		/// <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPCCHOOKPROC</c></para>
		/// <para>
		/// A pointer to a CCHookProc hook procedure that can process messages intended for the dialog box. This member is ignored
		/// unless the <c>CC_ENABLEHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		public LPCCHOOKPROC lpfnHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template is
		/// substituted for the standard dialog box template. For numbered dialog box resources, <c>lpTemplateName</c> can be a value
		/// returned by the MAKEINTRESOURCE macro. This member is ignored unless the <c>CC_ENABLETEMPLATE</c> flag is set in the
		/// <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpTemplateName;
	}

	/// <summary>
	/// Contains information that the ChooseFont function uses to initialize the <c>Font</c> dialog box. After the user closes the
	/// dialog box, the system returns information about the user's selection in this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-choosefonta typedef struct tagCHOOSEFONTA { DWORD
	// lStructSize; HWND hwndOwner; HDC hDC; LPLOGFONTA lpLogFont; INT iPointSize; DWORD Flags; COLORREF rgbColors; LPARAM lCustData;
	// LPCFHOOKPROC lpfnHook; LPCSTR lpTemplateName; HINSTANCE hInstance; PSTR lpszStyle; WORD nFontType; WORD ___MISSING_ALIGNMENT__;
	// INT nSizeMin; INT nSizeMax; } CHOOSEFONTA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagCHOOSEFONTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CHOOSEFONT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length of the structure, in bytes.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> if the
		/// dialog box has no owner.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>This member is ignored by the ChooseFont function.</para>
		/// <para>
		/// <c>Windows Vista and Windows XP/2000:</c> A handle to the device context or information context of the printer whose fonts
		/// will be listed in the dialog box. This member is used only if the <c>Flags</c> member specifies the <c>CF_PRINTERFONTS</c>
		/// or <c>CF_BOTH</c> flag; otherwise, this member is ignored.
		/// </para>
		/// </summary>
		public HDC hDC;

		/// <summary>
		/// <para>Type: <see cref="LOGFONT"/>*</para>
		/// <para>
		/// A pointer to a LOGFONT structure. If you set the <c>CF_INITTOLOGFONTSTRUCT</c> flag in the <c>Flags</c> member and
		/// initialize the other members, the ChooseFont function initializes the dialog box with a font that matches the <c>LOGFONT</c>
		/// members. If the user clicks the <c>OK</c> button, <c>ChooseFont</c> sets the members of the <c>LOGFONT</c> structure based
		/// on the user's selections.
		/// </para>
		/// </summary>
		public IntPtr lpLogFont;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The size of the selected font, in units of 1/10 of a point. The ChooseFont function sets this value after the user closes
		/// the dialog box.
		/// </para>
		/// </summary>
		public int iPointSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that you can use to initialize the <c>Font</c> dialog box. When the dialog box returns, it sets these
		/// flags to indicate the user input. This member can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CF_APPLY 0x00000200L</term>
		/// <term>
		/// Causes the dialog box to display the Apply button. You should provide a hook procedure to process WM_COMMAND messages for
		/// the Apply button. The hook procedure can send the WM_CHOOSEFONT_GETLOGFONT message to the dialog box to retrieve the address
		/// of the structure that contains the current selections for the font.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_ANSIONLY 0x00000400L</term>
		/// <term>
		/// This flag is obsolete. To limit font selections to all scripts except those that use the OEM or Symbol character sets, use
		/// CF_SCRIPTSONLY. To get the original CF_ANSIONLY behavior, use CF_SELECTSCRIPT and specify ANSI_CHARSET in the lfCharSet
		/// member of the LOGFONT structure pointed to by lpLogFont.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_BOTH 0x00000003</term>
		/// <term>
		/// This flag is ignored for font enumeration. Windows Vista and Windows XP/2000: Causes the dialog box to list the available
		/// printer and screen fonts. The hDC member is a handle to the device context or information context associated with the
		/// printer. This flag is a combination of the CF_SCREENFONTS and CF_PRINTERFONTS flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_EFFECTS 0x00000100L</term>
		/// <term>
		/// Causes the dialog box to display the controls that allow the user to specify strikeout, underline, and text color options.
		/// If this flag is set, you can use the rgbColors member to specify the initial text color. You can use the lfStrikeOut and
		/// lfUnderline members of the structure pointed to by lpLogFont to specify the initial settings of the strikeout and underline
		/// check boxes. ChooseFont can use these members to return the user's selections.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_ENABLEHOOK 0x00000008L</term>
		/// <term>Enables the hook procedure specified in the lpfnHook member of this structure.</term>
		/// </item>
		/// <item>
		/// <term>CF_ENABLETEMPLATE 0x00000010L</term>
		/// <term>
		/// Indicates that the hInstance and lpTemplateName members specify a dialog box template to use in place of the default template.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_ENABLETEMPLATEHANDLE 0x00000020L</term>
		/// <term>
		/// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template. The system
		/// ignores the lpTemplateName member if this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_FIXEDPITCHONLY 0x00004000L</term>
		/// <term>ChooseFont should enumerate and allow selection of only fixed-pitch fonts.</term>
		/// </item>
		/// <item>
		/// <term>CF_FORCEFONTEXIST 0x00010000L</term>
		/// <term>
		/// ChooseFont should indicate an error condition if the user attempts to select a font or style that is not listed in the
		/// dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_INACTIVEFONTS 0x02000000L</term>
		/// <term>
		/// ChooseFont should additionally display fonts that are set to Hide in Fonts Control Panel. Windows Vista and Windows XP/2000:
		/// This flag is not supported until Windows 7.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_INITTOLOGFONTSTRUCT 0x00000040L</term>
		/// <term>ChooseFont should use the structure pointed to by the lpLogFont member to initialize the dialog box controls.</term>
		/// </item>
		/// <item>
		/// <term>CF_LIMITSIZE 0x00002000L</term>
		/// <term>ChooseFont should select only font sizes within the range specified by the nSizeMin and nSizeMax members.</term>
		/// </item>
		/// <item>
		/// <term>CF_NOOEMFONTS 0x00000800L</term>
		/// <term>Same as the CF_NOVECTORFONTS flag.</term>
		/// </item>
		/// <item>
		/// <term>CF_NOFACESEL 0x00080000L</term>
		/// <term>
		/// When using a LOGFONT structure to initialize the dialog box controls, use this flag to prevent the dialog box from
		/// displaying an initial selection for the font name combo box. This is useful when there is no single font name that applies
		/// to the text selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_NOSCRIPTSEL 0x00800000L</term>
		/// <term>
		/// Disables the Script combo box. When this flag is set, the lfCharSet member of the LOGFONT structure is set to
		/// DEFAULT_CHARSET when ChooseFont returns. This flag is used only to initialize the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_NOSIMULATIONS 0x00001000L</term>
		/// <term>ChooseFont should not display or allow selection of font simulations.</term>
		/// </item>
		/// <item>
		/// <term>CF_NOSIZESEL 0x00200000L</term>
		/// <term>
		/// When using a structure to initialize the dialog box controls, use this flag to prevent the dialog box from displaying an
		/// initial selection for the Font Size combo box. This is useful when there is no single font size that applies to the text selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_NOSTYLESEL 0x00100000L</term>
		/// <term>
		/// When using a LOGFONT structure to initialize the dialog box controls, use this flag to prevent the dialog box from
		/// displaying an initial selection for the Font Style combo box. This is useful when there is no single font style that applies
		/// to the text selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_NOVECTORFONTS 0x00000800L</term>
		/// <term>ChooseFont should not allow vector font selections.</term>
		/// </item>
		/// <item>
		/// <term>CF_NOVERTFONTS 0x01000000L</term>
		/// <term>Causes the Font dialog box to list only horizontally oriented fonts.</term>
		/// </item>
		/// <item>
		/// <term>CF_PRINTERFONTS 0x00000002</term>
		/// <term>
		/// This flag is ignored for font enumeration. Windows Vista and Windows XP/2000: Causes the dialog box to list only the fonts
		/// supported by the printer associated with the device context or information context identified by the hDC member. It also
		/// causes the font type description label to appear at the bottom of the Font dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SCALABLEONLY 0x00020000L</term>
		/// <term>
		/// Specifies that ChooseFont should allow only the selection of scalable fonts. Scalable fonts include vector fonts, scalable
		/// printer fonts, TrueType fonts, and fonts scaled by other technologies.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SCREENFONTS 0x00000001</term>
		/// <term>
		/// This flag is ignored for font enumeration. Windows Vista and Windows XP/2000: Causes the dialog box to list only the screen
		/// fonts supported by the system.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SCRIPTSONLY 0x00000400L</term>
		/// <term>
		/// ChooseFont should allow selection of fonts for all non-OEM and Symbol character sets, as well as the ANSI character set.
		/// This supersedes the CF_ANSIONLY value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SELECTSCRIPT 0x00400000L</term>
		/// <term>
		/// When specified on input, only fonts with the character set identified in the lfCharSet member of the LOGFONT structure are
		/// displayed. The user will not be allowed to change the character set specified in the Scripts combo box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_SHOWHELP 0x00000004L</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_TTONLY 0x00040000L</term>
		/// <term>ChooseFont should only enumerate and allow the selection of TrueType fonts.</term>
		/// </item>
		/// <item>
		/// <term>CF_USESTYLE 0x00000080L</term>
		/// <term>
		/// The lpszStyle member is a pointer to a buffer that contains style data that ChooseFont should use to initialize the Font
		/// Style combo box. When the user closes the dialog box, ChooseFont copies style data for the user's selection to this buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CF_WYSIWYG 0x00008000L</term>
		/// <term>
		/// Obsolete. ChooseFont ignores this flag. Windows Vista and Windows XP/2000: ChooseFont should allow only the selection of
		/// fonts available on both the printer and the display. If this flag is specified, the CF_SCREENSHOTS and CF_PRINTERFONTS, or
		/// CF_BOTH flags should also be specified.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CF Flags;

		/// <summary>
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>
		/// If the <c>CF_EFFECTS</c> flag is set, <c>rgbColors</c> specifies the initial text color. When ChooseFont returns
		/// successfully, this member contains the RGB value of the text color that the user selected. To create a COLORREF color value,
		/// use the RGB macro.
		/// </para>
		/// </summary>
		public COLORREF rgbColors;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnHook</c> member. When the
		/// system sends the WM_INITDIALOG message to the hook procedure, the message's lParam parameter is a pointer to the CHOOSEFONT
		/// structure specified when the dialog was created. The hook procedure can use this pointer to get the <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPCFHOOKPROC</c></para>
		/// <para>
		/// A pointer to a CFHookProc hook procedure that can process messages intended for the dialog box. This member is ignored
		/// unless the <c>CF_ENABLEHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPCFHOOKPROC lpfnHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template is
		/// substituted for the standard dialog box template. For numbered dialog box resources, <c>lpTemplateName</c> can be a value
		/// returned by the MAKEINTRESOURCE macro. This member is ignored unless the <c>CF_ENABLETEMPLATE</c> flag is set in the
		/// <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpTemplateName;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>CF_ENABLETEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to a memory
		/// object containing a dialog box template. If the <c>CF_ENABLETEMPLATE</c> flag is set, <c>hInstance</c> is a handle to a
		/// module that contains a dialog box template named by the <c>lpTemplateName</c> member. If neither
		/// <c>CF_ENABLETEMPLATEHANDLE</c> nor <c>CF_ENABLETEMPLATE</c> is set, this member is ignored.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// The style data. If the <c>CF_USESTYLE</c> flag is specified, ChooseFont uses the data in this buffer to initialize the
		/// <c>Font Style</c> combo box. When the user closes the dialog box, <c>ChooseFont</c> copies the string in the <c>Font
		/// Style</c> combo box into this buffer.
		/// </para>
		/// </summary>
		public PTSTR lpszStyle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The type of the selected font when ChooseFont returns. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BOLD_FONTTYPE 0x0100</term>
		/// <term>
		/// The font weight is bold. This information is duplicated in the lfWeight member of the LOGFONT structure and is equivalent to FW_BOLD.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ITALIC_FONTTYPE 0x0200</term>
		/// <term>The italic font attribute is set. This information is duplicated in the lfItalic member of the LOGFONT structure.</term>
		/// </item>
		/// <item>
		/// <term>PRINTER_FONTTYPE 0x4000</term>
		/// <term>The font is a printer font.</term>
		/// </item>
		/// <item>
		/// <term>REGULAR_FONTTYPE 0x0400</term>
		/// <term>
		/// The font weight is normal. This information is duplicated in the lfWeight member of the LOGFONT structure and is equivalent
		/// to FW_REGULAR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SCREEN_FONTTYPE 0x2000</term>
		/// <term>The font is a screen font.</term>
		/// </item>
		/// <item>
		/// <term>SIMULATED_FONTTYPE 0x8000</term>
		/// <term>The font is simulated by the graphics device interface (GDI).</term>
		/// </item>
		/// </list>
		/// </summary>
		public ushort nFontType;

		/// <summary/>
		private ushort ___MISSING_ALIGNMENT__;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The minimum point size a user can select. ChooseFont recognizes this member only if the <c>CF_LIMITSIZE</c> flag is specified.
		/// </para>
		/// </summary>
		public int nSizeMin;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The maximum point size a user can select. ChooseFont recognizes this member only if the <c>CF_LIMITSIZE</c> flag is specified.
		/// </para>
		/// </summary>
		public int nSizeMax;
	}

	/// <summary>
	/// Contains strings that identify the driver, device, and output port names for a printer. These strings must be ANSI strings when
	/// the ANSI version of PrintDlg or PrintDlgEx is used, and must be Unicode strings when the Unicode version of <c>PrintDlg</c> or
	/// <c>PrintDlgEx</c> is used. The <c>PrintDlgEx</c> and <c>PrintDlg</c> functions use these strings to initialize the
	/// system-defined Print Property Sheet or Print Dialog Box. When the user closes the property sheet or dialog box, information
	/// about the selected printer is returned in this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-devnames typedef struct tagDEVNAMES { WORD wDriverOffset;
	// WORD wDeviceOffset; WORD wOutputOffset; WORD wDefault; } DEVNAMES;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagDEVNAMES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVNAMES
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The offset, in characters, from the beginning of this structure to a null-terminated string that contains the file name
		/// (without the extension) of the device driver. On input, this string is used to determine the printer to display initially in
		/// the dialog box.
		/// </para>
		/// </summary>
		public ushort wDriverOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The offset, in characters, from the beginning of this structure to the null-terminated string that contains the name of the device.
		/// </para>
		/// </summary>
		public ushort wDeviceOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The offset, in characters, from the beginning of this structure to the null-terminated string that contains the device name
		/// for the physical output medium (output port).
		/// </para>
		/// </summary>
		public ushort wOutputOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Indicates whether the strings contained in the <c>DEVNAMES</c> structure identify the default printer. This string is used
		/// to verify that the default printer has not changed since the last print operation. If any of the strings do not match, a
		/// warning message is displayed informing the user that the document may need to be reformatted. On output, the <c>wDefault</c>
		/// member is changed only if the <c>Print Setup</c> dialog box was displayed and the user chose the <c>OK</c> button. The
		/// <c>DN_DEFAULTPRN</c> flag is used if the default printer was selected. If a specific printer is selected, the flag is not
		/// used. All other flags in this member are reserved for internal use by the dialog box procedure for the <c>Print</c> property
		/// sheet or <c>Print</c> dialog box.
		/// </para>
		/// </summary>
		public DN wDefault;
	}

	/// <summary>
	/// Contains information that the FindText and ReplaceText functions use to initialize the <c>Find</c> and <c>Replace</c> dialog
	/// boxes. The FINDMSGSTRING registered message uses this structure to pass the user's search or replacement input to the owner
	/// window of a <c>Find</c> or <c>Replace</c> dialog box.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-findreplacea typedef struct tagFINDREPLACEA { DWORD
	// lStructSize; HWND hwndOwner; HINSTANCE hInstance; DWORD Flags; PSTR lpstrFindWhat; PSTR lpstrReplaceWith; WORD wFindWhatLen;
	// WORD wReplaceWithLen; LPARAM lCustData; LPFRHOOKPROC lpfnHook; LPCSTR lpTemplateName; } FINDREPLACEA, *LPFINDREPLACEA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagFINDREPLACEA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct FINDREPLACE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length, in bytes, of the structure.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. The window procedure of the specified window receives FINDMSGSTRING
		/// messages from the dialog box. This member can be any valid window handle, but it must not be <c>NULL</c>.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>FR_ENABLETEMPLATEHANDLE</c> flag is set in the <c>Flags</c>, <c>hInstance</c> is a handle to a memory object
		/// containing a dialog box template. If the <c>FR_ENABLETEMPLATE</c> flag is set, <c>hInstance</c> is a handle to a module that
		/// contains a dialog box template named by the <c>lpTemplateName</c> member. If neither flag is set, this member is ignored.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that you can use to initialize the dialog box. The dialog box sets these flags when it sends the
		/// FINDMSGSTRING registered message to indicate the user's input. This member can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FR_DIALOGTERM 0x00000040</term>
		/// <term>
		/// If set in a FINDMSGSTRING message, indicates that the dialog box is closing. When you receive a message with this flag set,
		/// the dialog box handle returned by the FindText or ReplaceText function is no longer valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_DOWN 0x00000001</term>
		/// <term>
		/// If set, the Down button of the direction radio buttons in a Find dialog box is selected indicating that you should search
		/// from the current location to the end of the document. If not set, the Up button is selected so you should search to the
		/// beginning of the document. You can set this flag to initialize the dialog box. If set in a FINDMSGSTRING message, indicates
		/// the user's selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_ENABLEHOOK 0x00000100</term>
		/// <term>Enables the hook function specified in the lpfnHook member. This flag is used only to initialize the dialog box.</term>
		/// </item>
		/// <item>
		/// <term>FR_ENABLETEMPLATE 0x00000200</term>
		/// <term>
		/// Indicates that the hInstance and lpTemplateName members specify a dialog box template to use in place of the default
		/// template. This flag is used only to initialize the dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_ENABLETEMPLATEHANDLE 0x00002000</term>
		/// <term>
		/// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template. The system
		/// ignores the lpTemplateName member if this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_FINDNEXT 0x00000008</term>
		/// <term>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Find Next button in a Find or Replace dialog box. The
		/// lpstrFindWhat member specifies the string to search for.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_HIDEUPDOWN 0x00004000</term>
		/// <term>If set when initializing a Find dialog box, hides the search direction radio buttons.</term>
		/// </item>
		/// <item>
		/// <term>FR_HIDEMATCHCASE 0x00008000</term>
		/// <term>If set when initializing a Find or Replace dialog box, hides the Match Case check box.</term>
		/// </item>
		/// <item>
		/// <term>FR_HIDEWHOLEWORD 0x00010000</term>
		/// <term>If set when initializing a Find or Replace dialog box, hides the Match Whole Word Only check box.</term>
		/// </item>
		/// <item>
		/// <term>FR_MATCHCASE 0x00000004</term>
		/// <term>
		/// If set, the Match Case check box is selected indicating that the search should be case-sensitive. If not set, the check box
		/// is unselected so the search should be case-insensitive. You can set this flag to initialize the dialog box. If set in a
		/// FINDMSGSTRING message, indicates the user's selection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_NOMATCHCASE 0x00000800</term>
		/// <term>If set when initializing a Find or Replace dialog box, disables the Match Case check box.</term>
		/// </item>
		/// <item>
		/// <term>FR_NOUPDOWN 0x00000400</term>
		/// <term>If set when initializing a Find dialog box, disables the search direction radio buttons.</term>
		/// </item>
		/// <item>
		/// <term>FR_NOWHOLEWORD 0x00001000</term>
		/// <term>If set when initializing a Find or Replace dialog box, disables the Whole Word check box.</term>
		/// </item>
		/// <item>
		/// <term>FR_REPLACE 0x00000010</term>
		/// <term>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Replace button in a Replace dialog box. The
		/// lpstrFindWhat member specifies the string to be replaced and the lpstrReplaceWith member specifies the replacement string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_REPLACEALL 0x00000020</term>
		/// <term>
		/// If set in a FINDMSGSTRING message, indicates that the user clicked the Replace All button in a Replace dialog box. The
		/// lpstrFindWhat member specifies the string to be replaced and the lpstrReplaceWith member specifies the replacement string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_SHOWHELP 0x00000080</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FR_WHOLEWORD 0x00000002</term>
		/// <term>
		/// If set, the Match Whole Word Only check box is selected indicating that you should search only for whole words that match
		/// the search string. If not set, the check box is unselected so you should also search for word fragments that match the
		/// search string. You can set this flag to initialize the dialog box. If set in a FINDMSGSTRING message, indicates the user's selection.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public FR Flags;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// The search string that the user typed in the <c>Find What</c> edit control. You must dynamically allocate the buffer or use
		/// a global or static array so it does not go out of scope before the dialog box closes. The buffer should be at least 80
		/// characters long. If the buffer contains a string when you initialize the dialog box, the string is displayed in the <c>Find
		/// What</c> edit control. If a FINDMSGSTRING message specifies the <c>FR_FINDNEXT</c> flag, <c>lpstrFindWhat</c> contains the
		/// string to search for. The <c>FR_DOWN</c>, <c>FR_WHOLEWORD</c>, and <c>FR_MATCHCASE</c> flags indicate the direction and type
		/// of search. If a <c>FINDMSGSTRING</c> message specifies the <c>FR_REPLACE</c> or <c>FR_REPLACE</c> flags,
		/// <c>lpstrFindWhat</c> contains the string to be replaced.
		/// </para>
		/// </summary>
		public PTSTR lpstrFindWhat;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// The replacement string that the user typed in the <c>Replace With</c> edit control. You must dynamically allocate the buffer
		/// or use a global or static array so it does not go out of scope before the dialog box closes. If the buffer contains a string
		/// when you initialize the dialog box, the string is displayed in the <c>Replace With</c> edit control.
		/// </para>
		/// <para>
		/// If a FINDMSGSTRING message specifies the <c>FR_REPLACE</c> or <c>FR_REPLACEALL</c> flags, <c>lpstrReplaceWith</c> contains
		/// the replacement string .
		/// </para>
		/// <para>The FindText function ignores this member.</para>
		/// </summary>
		public PTSTR lpstrReplaceWith;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The length, in bytes, of the buffer pointed to by the <c>lpstrFindWhat</c> member.</para>
		/// </summary>
		public ushort wFindWhatLen;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The length, in bytes, of the buffer pointed to by the <c>lpstrReplaceWith</c> member.</para>
		/// </summary>
		public ushort wReplaceWithLen;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnHook</c> member. When the
		/// system sends the WM_INITDIALOG message to the hook procedure, the message's lParam parameter is a pointer to the
		/// <c>FINDREPLACE</c> structure specified when the dialog was created. The hook procedure can use this pointer to get the
		/// <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPFRHOOKPROC</c></para>
		/// <para>
		/// A pointer to an FRHookProc hook procedure that can process messages intended for the dialog box. This member is ignored
		/// unless the <c>FR_ENABLEHOOK</c> flag is set in the <c>Flags</c> member. If the hook procedure returns <c>FALSE</c> in
		/// response to the WM_INITDIALOG message, the hook procedure must display the dialog box or else the dialog box will not be
		/// shown. To do this, first perform any other paint operations, and then call the ShowWindow and UpdateWindow functions.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPFRHOOKPROC? lpfnHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template is
		/// substituted for the standard dialog box template. For numbered dialog box resources, this can be a value returned by the
		/// MAKEINTRESOURCE macro. This member is ignored unless the <c>FR_ENABLETEMPLATE</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpTemplateName;
	}

	/// <summary>
	/// Contains information about a WM_NOTIFY message sent to an OFNHookProc hook procedure for an <c>Open</c> or <c>Save As</c> dialog
	/// box. The lParam parameter of the <c>WM_NOTIFY</c> message is a pointer to an <c>OFNOTIFY</c> structure.
	/// </summary>
	/// <remarks>
	/// Not all of the <c>Open</c> and <c>Save As</c> notification messages use the <c>OFNOTIFY</c> structure. The CDN_INCLUDEITEM
	/// notification message uses the OFNOTIFYEX structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-ofnotifya typedef struct _OFNOTIFYA { NMHDR hdr;
	// LPOPENFILENAMEA lpOFN; PSTR pszFile; } OFNOTIFYA, *LPOFNOTIFYA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg._OFNOTIFYA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OFNOTIFY
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>
		/// The <c>code</c> member of this structure can be one of the following notification messages that identify the message being
		/// sent: CDN_FILEOK, CDN_FOLDERCHANGE, CDN_HELP, CDN_INITDONE, CDN_SELCHANGE, CDN_SHAREVIOLATION, CDN_TYPECHANGE.
		/// </para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LPOPENFILENAME</c></para>
		/// <para>
		/// A pointer to the OPENFILENAME structure that was specified when the <c>Open</c> or <c>Save As</c> dialog box was created.
		/// For some of the notification messages, this structure contains additional information about the event that caused the notification.
		/// </para>
		/// </summary>
		public IntPtr lpOFN;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// The file name for which a network sharing violation has occurred. This member is valid only with the CDN_SHAREVIOLATION
		/// notification message.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pszFile;
	}

	/// <summary>Contains information about a CDN_INCLUDEITEM notification message.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-ofnotifyexa typedef struct _OFNOTIFYEXA { NMHDR hdr;
	// LPOPENFILENAMEA lpOFN; LPVOID psf; LPVOID pidl; } OFNOTIFYEXA, *LPOFNOTIFYEXA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg._OFNOTIFYEXA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OFNOTIFYEX
	{
		/// <summary>
		/// <para>Type: <c>NMHDR</c></para>
		/// <para>The <c>code</c> member of this structure identifies the notification message being sent.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>LPOPENFILENAME</c></para>
		/// <para>
		/// A pointer to an OPENFILENAME structure containing the values specified when the <c>Open</c> or <c>Save As</c> dialog box was created.
		/// </para>
		/// </summary>
		public IntPtr lpOFN;

		/// <summary>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>A pointer to the interface for the folder or shell name-space extension whose items are being enumerated.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public object psf;

		/// <summary>
		/// <para>Type: <c>LPVOID</c></para>
		/// <para>
		/// A pointer to an item identifier list that identifies an item in the container identified by the <c>psf</c> member. The item
		/// identifier is relative to the <c>psf</c> container.
		/// </para>
		/// </summary>
		public IntPtr pidl;
	}

	/// <summary>
	/// <para>
	/// [Starting with Windows Vista, the <c>Open</c> and <c>Save As</c> common dialog boxes have been superseded by the Common Item
	/// Dialog. We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.]
	/// </para>
	/// <para>
	/// Contains information that the GetOpenFileName and GetSaveFileName functions use to initialize an <c>Open</c> or <c>Save As</c>
	/// dialog box. After the user closes the dialog box, the system returns information about the user's selection in this structure.
	/// </para>
	/// </summary>
	/// <remarks>
	/// For compatibility reasons, the Places Bar is hidden if <c>Flags</c> is set to <c>OFN_ENABLEHOOK</c> and <c>lStructSize</c> is <c>OPENFILENAME_SIZE_VERSION_400</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-openfilenamea typedef struct tagOFNA { DWORD lStructSize;
	// HWND hwndOwner; HINSTANCE hInstance; LPCSTR lpstrFilter; PSTR lpstrCustomFilter; DWORD nMaxCustFilter; DWORD nFilterIndex; PSTR
	// lpstrFile; DWORD nMaxFile; PSTR lpstrFileTitle; DWORD nMaxFileTitle; LPCSTR lpstrInitialDir; LPCSTR lpstrTitle; DWORD Flags;
	// WORD nFileOffset; WORD nFileExtension; LPCSTR lpstrDefExt; LPARAM lCustData; LPOFNHOOKPROC lpfnHook; LPCSTR lpTemplateName;
	// LPEDITMENU lpEditInfo; LPCSTR lpstrPrompt; void *pvReserved; DWORD dwReserved; DWORD FlagsEx; } OPENFILENAMEA, *LPOPENFILENAMEA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagOFNA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OPENFILENAME
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The length, in bytes, of the structure. Use
		/// <code>sizeof (OPENFILENAME)</code>
		/// for this parameter.
		/// </para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> if the
		/// dialog box has no owner.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>OFN_ENABLETEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to a memory
		/// object containing a dialog box template. If the <c>OFN_ENABLETEMPLATE</c> flag is set, <c>hInstance</c> is a handle to a
		/// module that contains a dialog box template named by the <c>lpTemplateName</c> member. If neither flag is set, this member is
		/// ignored. If the <c>OFN_EXPLORER</c> flag is set, the system uses the specified template to create a dialog box that is a
		/// child of the default Explorer-style dialog box. If the <c>OFN_EXPLORER</c> flag is not set, the system uses the template to
		/// create an old-style dialog box that replaces the default dialog box.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A buffer containing pairs of null-terminated filter strings. The last string in the buffer must be terminated by two
		/// <c>NULL</c> characters.
		/// </para>
		/// <para>
		/// The first string in each pair is a display string that describes the filter (for example, "Text Files"), and the second
		/// string specifies the filter pattern (for example, ".TXT"). To specify multiple filter patterns for a single display string,
		/// use a semicolon to separate the patterns (for example, ".TXT;.DOC;.BAK"). A pattern string can be a combination of valid
		/// file name characters and the asterisk (*) wildcard character. Do not include spaces in the pattern string.
		/// </para>
		/// <para>
		/// The system does not change the order of the filters. It displays them in the <c>File Types</c> combo box in the order
		/// specified in <c>lpstrFilter</c>.
		/// </para>
		/// <para>If <c>lpstrFilter</c> is <c>NULL</c>, the dialog box does not display any filters.</para>
		/// <para>
		/// In the case of a shortcut, if no filter is set, GetOpenFileName and GetSaveFileName retrieve the name of the .lnk file, not
		/// its target. This behavior is the same as setting the <c>OFN_NODEREFERENCELINKS</c> flag in the <c>Flags</c> member. To
		/// retrieve a shortcut's target without filtering, use the string
		/// <code>"All Files\0*.*\0\0"</code>
		/// .
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrFilter;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// A static buffer that contains a pair of null-terminated filter strings for preserving the filter pattern chosen by the user.
		/// The first string is your display string that describes the custom filter, and the second string is the filter pattern
		/// selected by the user. The first time your application creates the dialog box, you specify the first string, which can be any
		/// nonempty string. When the user selects a file, the dialog box copies the current filter pattern to the second string. The
		/// preserved filter pattern can be one of the patterns specified in the <c>lpstrFilter</c> buffer, or it can be a filter
		/// pattern typed by the user. The system uses the strings to initialize the user-defined file filter the next time the dialog
		/// box is created. If the <c>nFilterIndex</c> member is zero, the dialog box uses the custom filter.
		/// </para>
		/// <para>If this member is <c>NULL</c>, the dialog box does not preserve user-defined filter patterns.</para>
		/// <para>
		/// If this member is not <c>NULL</c>, the value of the <c>nMaxCustFilter</c> member must specify the size, in characters, of
		/// the <c>lpstrCustomFilter</c> buffer.
		/// </para>
		/// </summary>
		public PTSTR lpstrCustomFilter;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in characters, of the buffer identified by <c>lpstrCustomFilter</c>. This buffer should be at least 40 characters
		/// long. This member is ignored if <c>lpstrCustomFilter</c> is <c>NULL</c> or points to a <c>NULL</c> string.
		/// </para>
		/// </summary>
		public uint nMaxCustFilter;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The index of the currently selected filter in the <c>File Types</c> control. The buffer pointed to by <c>lpstrFilter</c>
		/// contains pairs of strings that define the filters. The first pair of strings has an index value of 1, the second pair 2, and
		/// so on. An index of zero indicates the custom filter specified by <c>lpstrCustomFilter</c>. You can specify an index on input
		/// to indicate the initial filter description and filter pattern for the dialog box. When the user selects a file,
		/// <c>nFilterIndex</c> returns the index of the currently displayed filter. If <c>nFilterIndex</c> is zero and
		/// <c>lpstrCustomFilter</c> is <c>NULL</c>, the system uses the first filter in the <c>lpstrFilter</c> buffer. If all three
		/// members are zero or <c>NULL</c>, the system does not use any filters and does not show any files in the file list control of
		/// the dialog box.
		/// </para>
		/// </summary>
		public uint nFilterIndex;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>
		/// The file name used to initialize the <c>File Name</c> edit control. The first character of this buffer must be <c>NULL</c>
		/// if initialization is not necessary. When the GetOpenFileName or GetSaveFileName function returns successfully, this buffer
		/// contains the drive designator, path, file name, and extension of the selected file.
		/// </para>
		/// <para>
		/// If the <c>OFN_ALLOWMULTISELECT</c> flag is set and the user selects multiple files, the buffer contains the current
		/// directory followed by the file names of the selected files. For Explorer-style dialog boxes, the directory and file name
		/// strings are <c>NULL</c> separated, with an extra <c>NULL</c> character after the last file name. For old-style dialog boxes,
		/// the strings are space separated and the function uses short file names for file names with spaces. You can use the
		/// FindFirstFile function to convert between long and short file names. If the user selects only one file, the <c>lpstrFile</c>
		/// string does not have a separator between the path and file name.
		/// </para>
		/// <para>
		/// If the buffer is too small, the function returns <c>FALSE</c> and the CommDlgExtendedError function returns
		/// <c>FNERR_BUFFERTOOSMALL</c>. In this case, the first two bytes of the <c>lpstrFile</c> buffer contain the required size, in
		/// bytes or characters.
		/// </para>
		/// </summary>
		public PTSTR lpstrFile;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in characters, of the buffer pointed to by <c>lpstrFile</c>. The buffer must be large enough to store the path and
		/// file name string or strings, including the terminating <c>NULL</c> character. The GetOpenFileName and GetSaveFileName
		/// functions return <c>FALSE</c> if the buffer is too small to contain the file information. The buffer should be at least 256
		/// characters long.
		/// </para>
		/// </summary>
		public uint nMaxFile;

		/// <summary>
		/// <para>Type: <c>PTSTR</c></para>
		/// <para>The file name and extension (without path information) of the selected file. This member can be <c>NULL</c>.</para>
		/// </summary>
		public PTSTR lpstrFileTitle;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in characters, of the buffer pointed to by <c>lpstrFileTitle</c>. This member is ignored if <c>lpstrFileTitle</c>
		/// is <c>NULL</c>.
		/// </para>
		/// </summary>
		public uint nMaxFileTitle;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The initial directory. The algorithm for selecting the initial directory varies on different platforms.</para>
		/// <para><c>Windows 7:</c></para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// If <c>lpstrInitialDir</c> has the same value as was passed the first time the application used an <c>Open</c> or <c>Save
		/// As</c> dialog box, the path most recently selected by the user is used as the initial directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Otherwise, if <c>lpstrFile</c> contains a path, that path is the initial directory.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, if <c>lpstrInitialDir</c> is not <c>NULL</c>, it specifies the initial directory.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If <c>lpstrInitialDir</c> is <c>NULL</c> and the current directory contains any files of the specified filter types, the
		/// initial directory is the current directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the initial directory is the personal files directory of the current user.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the initial directory is the Desktop folder.</term>
		/// </item>
		/// </list>
		/// <para>Windows 2000/XP/Vista:</para>
		/// <list type="number">
		/// <item>
		/// <term>If <c>lpstrFile</c> contains a path, that path is the initial directory.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, <c>lpstrInitialDir</c> specifies the initial directory.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Otherwise, if the application has used an <c>Open</c> or <c>Save As</c> dialog box in the past, the path most recently used
		/// is selected as the initial directory. However, if an application is not run for a long time, its saved selected path is discarded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If <c>lpstrInitialDir</c> is <c>NULL</c> and the current directory contains any files of the specified filter types, the
		/// initial directory is the current directory.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the initial directory is the personal files directory of the current user.</term>
		/// </item>
		/// <item>
		/// <term>Otherwise, the initial directory is the Desktop folder.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrInitialDir;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// A string to be placed in the title bar of the dialog box. If this member is <c>NULL</c>, the system uses the default title
		/// (that is, <c>Save As</c> or <c>Open</c>).
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrTitle;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags you can use to initialize the dialog box. When the dialog box returns, it sets these flags to indicate
		/// the user's input. This member can be a combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OFN_ALLOWMULTISELECT 0x00000200</term>
		/// <term>
		/// The File Name list box allows multiple selections. If you also set the OFN_EXPLORER flag, the dialog box uses the
		/// Explorer-style user interface; otherwise, it uses the old-style user interface. If the user selects more than one file, the
		/// lpstrFile buffer returns the path to the current directory followed by the file names of the selected files. The nFileOffset
		/// member is the offset, in bytes or characters, to the first file name, and the nFileExtension member is not used. For
		/// Explorer-style dialog boxes, the directory and file name strings are NULL separated, with an extra NULL character after the
		/// last file name. This format enables the Explorer-style dialog boxes to return long file names that include spaces. For
		/// old-style dialog boxes, the directory and file name strings are separated by spaces and the function uses short file names
		/// for file names with spaces. You can use the FindFirstFile function to convert between long and short file names. If you
		/// specify a custom template for an old-style dialog box, the definition of the File Name list box must contain the
		/// LBS_EXTENDEDSEL value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_CREATEPROMPT 0x00002000</term>
		/// <term>
		/// If the user specifies a file that does not exist, this flag causes the dialog box to prompt the user for permission to
		/// create the file. If the user chooses to create the file, the dialog box closes and the function returns the specified name;
		/// otherwise, the dialog box remains open. If you use this flag with the OFN_ALLOWMULTISELECT flag, the dialog box allows the
		/// user to specify only one nonexistent file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_DONTADDTORECENT 0x02000000</term>
		/// <term>
		/// Prevents the system from adding a link to the selected file in the file system directory that contains the user's most
		/// recently used documents. To retrieve the location of this directory, call the SHGetSpecialFolderLocation function with the
		/// CSIDL_RECENT flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_ENABLEHOOK 0x00000020</term>
		/// <term>Enables the hook function specified in the lpfnHook member.</term>
		/// </item>
		/// <item>
		/// <term>OFN_ENABLEINCLUDENOTIFY 0x00400000</term>
		/// <term>
		/// Causes the dialog box to send CDN_INCLUDEITEM notification messages to your OFNHookProc hook procedure when the user opens a
		/// folder. The dialog box sends a notification for each item in the newly opened folder. These messages enable you to control
		/// which items the dialog box displays in the folder's item list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_ENABLESIZING 0x00800000</term>
		/// <term>
		/// Enables the Explorer-style dialog box to be resized using either the mouse or the keyboard. By default, the Explorer-style
		/// Open and Save As dialog boxes allow the dialog box to be resized regardless of whether this flag is set. This flag is
		/// necessary only if you provide a hook procedure or custom template. The old-style dialog box does not permit resizing.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_ENABLETEMPLATE 0x00000040</term>
		/// <term>
		/// The lpTemplateName member is a pointer to the name of a dialog template resource in the module identified by the hInstance
		/// member. If the OFN_EXPLORER flag is set, the system uses the specified template to create a dialog box that is a child of
		/// the default Explorer-style dialog box. If the OFN_EXPLORER flag is not set, the system uses the template to create an
		/// old-style dialog box that replaces the default dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_ENABLETEMPLATEHANDLE 0x00000080</term>
		/// <term>
		/// The hInstance member identifies a data block that contains a preloaded dialog box template. The system ignores
		/// lpTemplateName if this flag is specified. If the OFN_EXPLORER flag is set, the system uses the specified template to create
		/// a dialog box that is a child of the default Explorer-style dialog box. If the OFN_EXPLORER flag is not set, the system uses
		/// the template to create an old-style dialog box that replaces the default dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_EXPLORER 0x00080000</term>
		/// <term>
		/// Indicates that any customizations made to the Open or Save As dialog box use the Explorer-style customization methods. For
		/// more information, see Explorer-Style Hook Procedures and Explorer-Style Custom Templates. By default, the Open and Save As
		/// dialog boxes use the Explorer-style user interface regardless of whether this flag is set. This flag is necessary only if
		/// you provide a hook procedure or custom template, or set the OFN_ALLOWMULTISELECT flag. If you want the old-style user
		/// interface, omit the OFN_EXPLORER flag and provide a replacement old-style template or hook procedure. If you want the old
		/// style but do not need a custom template or hook procedure, simply provide a hook procedure that always returns FALSE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_EXTENSIONDIFFERENT 0x00000400</term>
		/// <term>
		/// The user typed a file name extension that differs from the extension specified by lpstrDefExt. The function does not use
		/// this flag if lpstrDefExt is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_FILEMUSTEXIST 0x00001000</term>
		/// <term>
		/// The user can type only names of existing files in the File Name entry field. If this flag is specified and the user enters
		/// an invalid name, the dialog box procedure displays a warning in a message box. If this flag is specified, the
		/// OFN_PATHMUSTEXIST flag is also used. This flag can be used in an Open dialog box. It cannot be used with a Save As dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_FORCESHOWHIDDEN 0x10000000</term>
		/// <term>
		/// Forces the showing of system and hidden files, thus overriding the user setting to show or not show hidden files. However, a
		/// file that is marked both system and hidden is not shown.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_HIDEREADONLY 0x00000004</term>
		/// <term>Hides the Read Only check box.</term>
		/// </item>
		/// <item>
		/// <term>OFN_LONGNAMES 0x00200000</term>
		/// <term>
		/// For old-style dialog boxes, this flag causes the dialog box to use long file names. If this flag is not specified, or if the
		/// OFN_ALLOWMULTISELECT flag is also set, old-style dialog boxes use short file names (8.3 format) for file names with spaces.
		/// Explorer-style dialog boxes ignore this flag and always display long file names.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_NOCHANGEDIR 0x00000008</term>
		/// <term>
		/// Restores the current directory to its original value if the user changed the directory while searching for files. This flag
		/// is ineffective for GetOpenFileName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_NODEREFERENCELINKS 0x00100000</term>
		/// <term>
		/// Directs the dialog box to return the path and file name of the selected shortcut (.LNK) file. If this value is not
		/// specified, the dialog box returns the path and file name of the file referenced by the shortcut.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_NOLONGNAMES 0x00040000</term>
		/// <term>
		/// For old-style dialog boxes, this flag causes the dialog box to use short file names (8.3 format). Explorer-style dialog
		/// boxes ignore this flag and always display long file names.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_NONETWORKBUTTON 0x00020000</term>
		/// <term>Hides and disables the Network button.</term>
		/// </item>
		/// <item>
		/// <term>OFN_NOREADONLYRETURN 0x00008000</term>
		/// <term>The returned file does not have the Read Only check box selected and is not in a write-protected directory.</term>
		/// </item>
		/// <item>
		/// <term>OFN_NOTESTFILECREATE 0x00010000</term>
		/// <term>
		/// The file is not created before the dialog box is closed. This flag should be specified if the application saves the file on
		/// a create-nonmodify network share. When an application specifies this flag, the library does not check for write protection,
		/// a full disk, an open drive door, or network protection. Applications using this flag must perform file operations carefully,
		/// because a file cannot be reopened once it is closed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_NOVALIDATE 0x00000100</term>
		/// <term>
		/// The common dialog boxes allow invalid characters in the returned file name. Typically, the calling application uses a hook
		/// procedure that checks the file name by using the FILEOKSTRING message. If the text box in the edit control is empty or
		/// contains nothing but spaces, the lists of files and directories are updated. If the text box in the edit control contains
		/// anything else, nFileOffset and nFileExtension are set to values generated by parsing the text. No default extension is added
		/// to the text, nor is text copied to the buffer specified by lpstrFileTitle. If the value specified by nFileOffset is less
		/// than zero, the file name is invalid. Otherwise, the file name is valid, and nFileExtension and nFileOffset can be used as if
		/// the OFN_NOVALIDATE flag had not been specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_OVERWRITEPROMPT 0x00000002</term>
		/// <term>
		/// Causes the Save As dialog box to generate a message box if the selected file already exists. The user must confirm whether
		/// to overwrite the file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_PATHMUSTEXIST 0x00000800</term>
		/// <term>
		/// The user can type only valid paths and file names. If this flag is used and the user types an invalid path and file name in
		/// the File Name entry field, the dialog box function displays a warning in a message box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_READONLY 0x00000001</term>
		/// <term>
		/// Causes the Read Only check box to be selected initially when the dialog box is created. This flag indicates the state of the
		/// Read Only check box when the dialog box is closed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_SHAREAWARE 0x00004000</term>
		/// <term>
		/// Specifies that if a call to the OpenFile function fails because of a network sharing violation, the error is ignored and the
		/// dialog box returns the selected file name. If this flag is not set, the dialog box notifies your hook procedure when a
		/// network sharing violation occurs for the file name specified by the user. If you set the OFN_EXPLORER flag, the dialog box
		/// sends the CDN_SHAREVIOLATION message to the hook procedure. If you do not set OFN_EXPLORER, the dialog box sends the
		/// SHAREVISTRING registered message to the hook procedure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>OFN_SHOWHELP 0x00000010</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button. An Explorer-style dialog box sends a
		/// CDN_HELP notification message to your hook procedure when the user clicks the Help button.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public OFN Flags;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The zero-based offset, in characters, from the beginning of the path to the file name in the string pointed to by
		/// <c>lpstrFile</c>. For the ANSI version, this is the number of bytes; for the Unicode version, this is the number of
		/// characters. For example, if <c>lpstrFile</c> points to the following string, "c:\dir1\dir2\file.ext", this member contains
		/// the value 13 to indicate the offset of the "file.ext" string. If the user selects more than one file, <c>nFileOffset</c> is
		/// the offset to the first file name.
		/// </para>
		/// </summary>
		public ushort nFileOffset;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The zero-based offset, in characters, from the beginning of the path to the file name extension in the string pointed to by
		/// <c>lpstrFile</c>. For the ANSI version, this is the number of bytes; for the Unicode version, this is the number of
		/// characters. Usually the file name extension is the substring which follows the last occurrence of the dot (".") character.
		/// For example, txt is the extension of the filename readme.txt, html the extension of readme.txt.html. Therefore, if
		/// <c>lpstrFile</c> points to the string "c:\dir1\dir2\readme.txt", this member contains the value 20. If <c>lpstrFile</c>
		/// points to the string "c:\dir1\dir2\readme.txt.html", this member contains the value 24. If <c>lpstrFile</c> points to the
		/// string "c:\dir1\dir2\readme.txt.html.", this member contains the value 29. If <c>lpstrFile</c> points to a string that does
		/// not contain any "." character such as "c:\dir1\dir2\readme", this member contains zero.
		/// </para>
		/// </summary>
		public ushort nFileExtension;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The default extension. GetOpenFileName and GetSaveFileName append this extension to the file name if the user fails to type
		/// an extension. This string can be any length, but only the first three characters are appended. The string should not contain
		/// a period (.). If this member is <c>NULL</c> and the user fails to type an extension, no extension is appended.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpstrDefExt;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnHook</c> member. When the
		/// system sends the WM_INITDIALOG message to the hook procedure, the message's lParam parameter is a pointer to the
		/// <c>OPENFILENAME</c> structure specified when the dialog box was created. The hook procedure can use this pointer to get the
		/// <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPOFNHOOKPROC</c></para>
		/// <para>
		/// A pointer to a hook procedure. This member is ignored unless the <c>Flags</c> member includes the <c>OFN_ENABLEHOOK</c> flag.
		/// </para>
		/// <para>
		/// If the <c>OFN_EXPLORER</c> flag is not set in the <c>Flags</c> member, <c>lpfnHook</c> is a pointer to an
		/// OFNHookProcOldStyle hook procedure that receives messages intended for the dialog box. The hook procedure returns
		/// <c>FALSE</c> to pass a message to the default dialog box procedure or <c>TRUE</c> to discard the message.
		/// </para>
		/// <para>
		/// If <c>OFN_EXPLORER</c> is set, <c>lpfnHook</c> is a pointer to an OFNHookProc hook procedure. The hook procedure receives
		/// notification messages sent from the dialog box. The hook procedure also receives messages for any additional controls that
		/// you defined by specifying a child dialog template. The hook procedure does not receive messages intended for the standard
		/// controls of the default dialog box.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPOFNHOOKPROC? lpfnHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog template resource in the module identified by the <c>hInstance</c> member. For numbered dialog box
		/// resources, this can be a value returned by the MAKEINTRESOURCE macro. This member is ignored unless the
		/// <c>OFN_ENABLETEMPLATE</c> flag is set in the <c>Flags</c> member. If the <c>OFN_EXPLORER</c> flag is set, the system uses
		/// the specified template to create a dialog box that is a child of the default Explorer-style dialog box. If the
		/// <c>OFN_EXPLORER</c> flag is not set, the system uses the template to create an old-style dialog box that replaces the
		/// default dialog box.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpTemplateName;

		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>This member is reserved.</para>
		/// </summary>
		private IntPtr pvReserved;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member is reserved.</para>
		/// </summary>
		private uint dwReserved;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A set of bit flags you can use to initialize the dialog box. Currently, this member can be zero or the following flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OFN_EX_NOPLACESBAR 0x00000001</term>
		/// <term>
		/// If this flag is set, the places bar is not displayed. If this flag is not set, Explorer-style dialog boxes include a places
		/// bar containing icons for commonly-used folders, such as Favorites and Desktop.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public OFN_EX FlagsEx;
	}

	/// <summary>
	/// Contains information the PageSetupDlg function uses to initialize the <c>Page Setup</c> dialog box. After the user closes the
	/// dialog box, the system returns information about the user-defined page parameters in this structure.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If the <c>PSD_INHUNDREDTHSOFMILLIMETERS</c> and <c>PSD_INTHOUSANDTHSOFINCHES</c> flags are not specified, the system queries the
	/// <c>LOCALE_IMEASURE</c> value of the default user locale to determine the unit of measure (either hundredths of millimeters or
	/// thousandths of inches) for the margin widths and paper size.
	/// </para>
	/// <para>
	/// If both <c>hDevNames</c> and <c>hDevMode</c> have valid handles and the printer name specified by the <c>wDeviceOffset</c>
	/// member of the DEVNAMES structure is not the same as the name specified by the <c>dmDeviceName</c> member of the DEVMODE
	/// structure, the system uses the name specified by <c>wDeviceOffset</c> by default.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-pagesetupdlga typedef struct tagPSDA { DWORD lStructSize;
	// HWND hwndOwner; HGLOBAL hDevMode; HGLOBAL hDevNames; DWORD Flags; POINT ptPaperSize; RECT rtMinMargin; RECT rtMargin; HINSTANCE
	// hInstance; LPARAM lCustData; LPPAGESETUPHOOK lpfnPageSetupHook; LPPAGEPAINTHOOK lpfnPagePaintHook; LPCSTR
	// lpPageSetupTemplateName; HGLOBAL hPageSetupTemplate; } PAGESETUPDLGA, *LPPAGESETUPDLGA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPSDA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PAGESETUPDLG
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of this structure.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> if the
		/// dialog box has no owner.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a global memory object that contains a DEVMODE structure. On input, if a handle is specified, the values in the
		/// corresponding <c>DEVMODE</c> structure are used to initialize the controls in the dialog box. On output, the dialog box sets
		/// <c>hDevMode</c> to a global memory handle to a <c>DEVMODE</c> structure that contains values specifying the user's
		/// selections. If the user's selections are not available, the dialog box sets <c>hDevMode</c> to <c>NULL</c>.
		/// </para>
		/// </summary>
		public HGLOBAL hDevMode;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a global memory object that contains a DEVNAMES structure. This structure contains three strings that specify
		/// the driver name, the printer name, and the output port name. On input, if a handle is specified, the strings in the
		/// corresponding <c>DEVNAMES</c> structure are used to initialize controls in the dialog box. On output, the dialog box sets
		/// <c>hDevNames</c> to a global memory handle to a <c>DEVNAMES</c> structure that contains strings specifying the user's
		/// selections. If the user's selections are not available, the dialog box sets <c>hDevNames</c> to <c>NULL</c>.
		/// </para>
		/// </summary>
		public HGLOBAL hDevNames;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that you can use to initialize the <c>Page Setup</c> dialog box. When the dialog box returns, it sets
		/// these flags to indicate the user's input. This member can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PSD_DEFAULTMINMARGINS 0x00000000</term>
		/// <term>
		/// Sets the minimum values that the user can specify for the page margins to be the minimum margins allowed by the printer.
		/// This is the default. This flag is ignored if the PSD_MARGINS and PSD_MINMARGINS flags are also specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_DISABLEMARGINS 0x00000010</term>
		/// <term>Disables the margin controls, preventing the user from setting the margins.</term>
		/// </item>
		/// <item>
		/// <term>PSD_DISABLEORIENTATION 0x00000100</term>
		/// <term>Disables the orientation controls, preventing the user from setting the page orientation.</term>
		/// </item>
		/// <item>
		/// <term>PSD_DISABLEPAGEPAINTING 0x00080000</term>
		/// <term>
		/// Prevents the dialog box from drawing the contents of the sample page. If you enable a PagePaintHook hook procedure, you can
		/// still draw the contents of the sample page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_DISABLEPAPER 0x00000200</term>
		/// <term>Disables the paper controls, preventing the user from setting page parameters such as the paper size and source.</term>
		/// </item>
		/// <item>
		/// <term>PSD_DISABLEPRINTER 0x00000020</term>
		/// <term>
		/// Obsolete. Windows XP/2000: Disables the Printer button, preventing the user from invoking a dialog box that contains
		/// additional printer setup information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_ENABLEPAGEPAINTHOOK 0x00040000</term>
		/// <term>Enables the hook procedure specified in the lpfnPagePaintHook member.</term>
		/// </item>
		/// <item>
		/// <term>PSD_ENABLEPAGESETUPHOOK 0x00002000</term>
		/// <term>Enables the hook procedure specified in the lpfnPageSetupHook member.</term>
		/// </item>
		/// <item>
		/// <term>PSD_ENABLEPAGESETUPTEMPLATE 0x00008000</term>
		/// <term>
		/// Indicates that the hInstance and lpPageSetupTemplateName members specify a dialog box template to use in place of the
		/// default template.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_ENABLEPAGESETUPTEMPLATEHANDLE 0x00020000</term>
		/// <term>
		/// Indicates that the hPageSetupTemplate member identifies a data block that contains a preloaded dialog box template. The
		/// system ignores the lpPageSetupTemplateName member if this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_INHUNDREDTHSOFMILLIMETERS 0x00000008</term>
		/// <term>
		/// Indicates that hundredths of millimeters are the unit of measurement for margins and paper size. The values in the rtMargin,
		/// rtMinMargin, and ptPaperSize members are in hundredths of millimeters. You can set this flag on input to override the
		/// default unit of measurement for the user's locale. When the function returns, the dialog box sets this flag to indicate the
		/// units used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_INTHOUSANDTHSOFINCHES 0x00000004</term>
		/// <term>
		/// Indicates that thousandths of inches are the unit of measurement for margins and paper size. The values in the rtMargin,
		/// rtMinMargin, and ptPaperSize members are in thousandths of inches. You can set this flag on input to override the default
		/// unit of measurement for the user's locale. When the function returns, the dialog box sets this flag to indicate the units used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_INWININIINTLMEASURE 0x00000000</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>PSD_MARGINS 0x00000002</term>
		/// <term>
		/// Causes the system to use the values specified in the rtMargin member as the initial widths for the left, top, right, and
		/// bottom margins. If PSD_MARGINS is not set, the system sets the initial widths to one inch for all margins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_MINMARGINS 0x00000001</term>
		/// <term>
		/// Causes the system to use the values specified in the rtMinMargin member as the minimum allowable widths for the left, top,
		/// right, and bottom margins. The system prevents the user from entering a width that is less than the specified minimum. If
		/// PSD_MINMARGINS is not specified, the system sets the minimum allowable widths to those allowed by the printer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_NONETWORKBUTTON 0x00200000</term>
		/// <term>Hides and disables the Network button.</term>
		/// </item>
		/// <item>
		/// <term>PSD_NOWARNING 0x00000080</term>
		/// <term>Prevents the system from displaying a warning message when there is no default printer.</term>
		/// </item>
		/// <item>
		/// <term>PSD_RETURNDEFAULT 0x00000400</term>
		/// <term>
		/// PageSetupDlg does not display the dialog box. Instead, it sets the hDevNames and hDevMode members to handles to DEVMODE and
		/// DEVNAMES structures that are initialized for the system default printer. PageSetupDlg returns an error if either hDevNames
		/// or hDevMode is not NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PSD_SHOWHELP 0x00000800</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PSD Flags;

		/// <summary>
		/// <para>Type: <c>POINT</c></para>
		/// <para>
		/// The dimensions of the paper selected by the user. The <c>PSD_INTHOUSANDTHSOFINCHES</c> or
		/// <c>PSD_INHUNDREDTHSOFMILLIMETERS</c> flag indicates the units of measurement.
		/// </para>
		/// </summary>
		public POINT ptPaperSize;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// The minimum allowable widths for the left, top, right, and bottom margins. The system ignores this member if the
		/// <c>PSD_MINMARGINS</c> flag is not set. These values must be less than or equal to the values specified in the
		/// <c>rtMargin</c> member. The <c>PSD_INTHOUSANDTHSOFINCHES</c> or <c>PSD_INHUNDREDTHSOFMILLIMETERS</c> flag indicates the
		/// units of measurement.
		/// </para>
		/// </summary>
		public RECT rtMinMargin;

		/// <summary>
		/// <para>Type: <c>RECT</c></para>
		/// <para>
		/// The widths of the left, top, right, and bottom margins. If you set the <c>PSD_MARGINS</c> flag, <c>rtMargin</c> specifies
		/// the initial margin values. When PageSetupDlg returns, <c>rtMargin</c> contains the margin widths selected by the user. The
		/// <c>PSD_INHUNDREDTHSOFMILLIMETERS</c> or <c>PSD_INTHOUSANDTHSOFINCHES</c> flag indicates the units of measurement.
		/// </para>
		/// </summary>
		public RECT rtMargin;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>PSD_ENABLEPAGESETUPTEMPLATE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to the
		/// application or module instance that contains the dialog box template named by the <c>lpPageSetupTemplateName</c> member.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnPageSetupHook</c> member.
		/// When the system sends the WM_INITDIALOG message to the hook procedure, the message's lParam parameter is a pointer to the
		/// <c>PAGESETUPDLG</c> structure specified when the dialog was created. The hook procedure can use this pointer to get the
		/// <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPPAGESETUPHOOK</c></para>
		/// <para>
		/// A pointer to a PageSetupHook hook procedure that can process messages intended for the dialog box. This member is ignored
		/// unless the <c>PSD_ENABLEPAGESETUPHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPPAGESETUPHOOK lpfnPageSetupHook;

		/// <summary>
		/// <para>Type: <c>LPPAGEPAINTHOOK</c></para>
		/// <para>
		/// A pointer to a PagePaintHook hook procedure that receives <c>WM_PSD_*</c> messages from the dialog box whenever the sample
		/// page is redrawn. By processing the messages, the hook procedure can customize the appearance of the sample page. This member
		/// is ignored unless the <c>PSD_ENABLEPAGEPAINTHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPPAGEPAINTHOOK? lpfnPagePaintHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template is
		/// substituted for the standard dialog box template. For numbered dialog box resources, <c>lpPageSetupTemplateName</c> can be a
		/// value returned by the MAKEINTRESOURCE macro. This member is ignored unless the <c>PSD_ENABLEPAGESETUPTEMPLATE</c> flag is
		/// set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpPageSetupTemplateName;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// If the <c>PSD_ENABLEPAGESETUPTEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hPageSetupTemplate</c> is a
		/// handle to a memory object containing a dialog box template.
		/// </para>
		/// </summary>
		public HGLOBAL hPageSetupTemplate;
	}

	/// <summary>
	/// Contains information that the PrintDlg function uses to initialize the Print Dialog Box. After the user closes the dialog box,
	/// the system uses this structure to return information about the user's selections.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If both <c>hDevMode</c> and <c>hDevNames</c> are <c>NULL</c>, PrintDlg initializes the dialog box using the current default
	/// printer. To initialize the dialog box for a different printer, use the <c>wDeviceOffset</c> member of the DEVNAMES structure to
	/// specify the name of the printer.
	/// </para>
	/// <para>
	/// Note that the <c>dmDeviceName</c> member of the DEVMODE structure also specifies a printer name. However, <c>dmDeviceName</c> is
	/// limited to 32 characters, and the <c>wDeviceOffset</c> name is not. If the <c>wDeviceOffset</c> and <c>dmDeviceName</c> names
	/// are not the same, PrintDlg initializes the dialog box using the printer specified by <c>wDeviceOffset</c>.
	/// </para>
	/// <para>
	/// If the <c>PD_RETURNDEFAULT</c> flag is set and both <c>hDevMode</c> and <c>hDevNames</c> are <c>NULL</c>, PrintDlg uses the
	/// <c>hDevNames</c> and <c>hDevMode</c> members to return information about the current default printer without displaying the
	/// dialog box.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-printdlga typedef struct tagPDA { DWORD lStructSize; HWND
	// hwndOwner; HGLOBAL hDevMode; HGLOBAL hDevNames; HDC hDC; DWORD Flags; WORD nFromPage; WORD nToPage; WORD nMinPage; WORD nMaxPage;
	// WORD nCopies; HINSTANCE hInstance; LPARAM lCustData; LPPRINTHOOKPROC lpfnPrintHook; LPSETUPHOOKPROC lpfnSetupHook; LPCSTR
	// lpPrintTemplateName; LPCSTR lpSetupTemplateName; HGLOBAL hPrintTemplate; HGLOBAL hSetupTemplate; } PRINTDLGA, *LPPRINTDLGA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPDA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTDLG
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The structure size, in bytes.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// A handle to the window that owns the dialog box. This member can be any valid window handle, or it can be <c>NULL</c> if the
		/// dialog box has no owner.
		/// </para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a movable global memory object that contains a DEVMODE structure. If <c>hDevMode</c> is not <c>NULL</c> on
		/// input, you must allocate a movable block of memory for the <c>DEVMODE</c> structure and initialize its members. The PrintDlg
		/// function uses the input data to initialize the controls in the dialog box. When <c>PrintDlg</c> returns, the <c>DEVMODE</c>
		/// members indicate the user's input.
		/// </para>
		/// <para>
		/// If <c>hDevMode</c> is <c>NULL</c> on input, PrintDlg allocates memory for the DEVMODE structure, initializes its members to
		/// indicate the user's input, and returns a handle that identifies it.
		/// </para>
		/// <para>
		/// If the device driver for the specified printer does not support extended device modes, <c>hDevMode</c> is <c>NULL</c> when
		/// PrintDlg returns.
		/// </para>
		/// <para>
		/// If the device name (specified by the <c>dmDeviceName</c> member of the DEVMODE structure) does not appear in the [devices]
		/// section of WIN.INI, PrintDlg returns an error.
		/// </para>
		/// <para>
		/// For more information about the <c>hDevMode</c> and <c>hDevNames</c> members, see the Remarks section at the end of this topic.
		/// </para>
		/// </summary>
		public HGLOBAL hDevMode;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a movable global memory object that contains a DEVNAMES structure. If <c>hDevNames</c> is not <c>NULL</c> on
		/// input, you must allocate a movable block of memory for the <c>DEVNAMES</c> structure and initialize its members. The
		/// PrintDlg function uses the input data to initialize the controls in the dialog box. When <c>PrintDlg</c> returns, the
		/// <c>DEVNAMES</c> members contain information for the printer chosen by the user. You can use this information to create a
		/// device context or an information context.
		/// </para>
		/// <para>
		/// The <c>hDevNames</c> member can be <c>NULL</c>, in which case, PrintDlg allocates memory for the DEVNAMES structure,
		/// initializes its members to indicate the user's input, and returns a handle that identifies it.
		/// </para>
		/// <para>
		/// For more information about the <c>hDevMode</c> and <c>hDevNames</c> members, see the Remarks section at the end of this topic.
		/// </para>
		/// </summary>
		public HGLOBAL hDevNames;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to a device context or an information context, depending on whether the <c>Flags</c> member specifies the
		/// <c>PD_RETURNDC</c> or <c>PC_RETURNIC</c> flag. If neither flag is specified, the value of this member is undefined. If both
		/// flags are specified, <c>PD_RETURNDC</c> has priority.
		/// </para>
		/// </summary>
		public HDC hDC;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Initializes the <c>Print</c> dialog box. When the dialog box returns, it sets these flags to indicate the user's input. This
		/// member can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PD_ALLPAGES 0x00000000</term>
		/// <term>
		/// The default flag that indicates that the All radio button is initially selected. This flag is used as a placeholder to
		/// indicate that the PD_PAGENUMS and PD_SELECTION flags are not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_COLLATE 0x00000010</term>
		/// <term>
		/// If this flag is set, the Collate check box is selected. If this flag is set when the PrintDlg function returns, the
		/// application must simulate collation of multiple copies. For more information, see the description of the
		/// PD_USEDEVMODECOPIESANDCOLLATE flag. See PD_NOPAGENUMS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_DISABLEPRINTTOFILE 0x00080000</term>
		/// <term>Disables the Print to File check box.</term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLEPRINTHOOK 0x00001000</term>
		/// <term>
		/// Enables the hook procedure specified in the lpfnPrintHook member. This enables the hook procedure for the Print dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLEPRINTTEMPLATE 0x00004000</term>
		/// <term>
		/// Indicates that the hInstance and lpPrintTemplateName members specify a replacement for the default Print dialog box template.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLEPRINTTEMPLATEHANDLE 0x00010000</term>
		/// <term>
		/// Indicates that the hPrintTemplate member identifies a data block that contains a preloaded dialog box template. This
		/// template replaces the default template for the Print dialog box. The system ignores the lpPrintTemplateName member if this
		/// flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLESETUPHOOK 0x00002000</term>
		/// <term>
		/// Enables the hook procedure specified in the lpfnSetupHook member. This enables the hook procedure for the Print Setup dialog box.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLESETUPTEMPLATE 0x00008000</term>
		/// <term>
		/// Indicates that the hInstance and lpSetupTemplateName members specify a replacement for the default Print Setup dialog box template.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLESETUPTEMPLATEHANDLE 0x00020000</term>
		/// <term>
		/// Indicates that the hSetupTemplate member identifies a data block that contains a preloaded dialog box template. This
		/// template replaces the default template for the Print Setup dialog box. The system ignores the lpSetupTemplateName member if
		/// this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_HIDEPRINTTOFILE 0x00100000</term>
		/// <term>Hides the Print to File check box.</term>
		/// </item>
		/// <item>
		/// <term>PD_NONETWORKBUTTON 0x00200000</term>
		/// <term>Hides and disables the Network button.</term>
		/// </item>
		/// <item>
		/// <term>PD_NOPAGENUMS 0x00000008</term>
		/// <term>
		/// Disables the Pages radio button and the associated edit controls. Also, it causes the Collate check box to appear in the dialog.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_NOSELECTION 0x00000004</term>
		/// <term>Disables the Selection radio button.</term>
		/// </item>
		/// <item>
		/// <term>PD_NOWARNING 0x00000080</term>
		/// <term>Prevents the warning message from being displayed when there is no default printer.</term>
		/// </item>
		/// <item>
		/// <term>PD_PAGENUMS 0x00000002</term>
		/// <term>
		/// If this flag is set, the Pages radio button is selected. If this flag is set when the PrintDlg function returns, the
		/// nFromPage and nToPage members indicate the starting and ending pages specified by the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_PRINTSETUP 0x00000040</term>
		/// <term>Causes the system to display the Print Setup dialog box rather than the Print dialog box.</term>
		/// </item>
		/// <item>
		/// <term>PD_PRINTTOFILE 0x00000020</term>
		/// <term>
		/// If this flag is set, the Print to File check box is selected. If this flag is set when the PrintDlg function returns, the
		/// offset indicated by the wOutputOffset member of the DEVNAMES structure contains the string "FILE:". When you call the
		/// StartDoc function to start the printing operation, specify this "FILE:" string in the lpszOutput member of the DOCINFO
		/// structure. Specifying this string causes the print subsystem to query the user for the name of the output file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNDC 0x00000100</term>
		/// <term>
		/// Causes PrintDlg to return a device context matching the selections the user made in the dialog box. The device context is
		/// returned in hDC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNDEFAULT 0x00000400</term>
		/// <term>
		/// If this flag is set, the PrintDlg function does not display the dialog box. Instead, it sets the hDevNames and hDevMode
		/// members to handles to DEVMODE and DEVNAMES structures that are initialized for the system default printer. Both hDevNames
		/// and hDevMode must be NULL, or PrintDlg returns an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNIC 0x00000200</term>
		/// <term>
		/// Similar to the PD_RETURNDC flag, except this flag returns an information context rather than a device context. If neither
		/// PD_RETURNDC nor PD_RETURNIC is specified, hDC is undefined on output.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_SELECTION 0x00000001</term>
		/// <term>
		/// If this flag is set, the Selection radio button is selected. If neither PD_PAGENUMS nor PD_SELECTION is set, the All radio
		/// button is selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_SHOWHELP 0x00000800</term>
		/// <term>
		/// Causes the dialog box to display the Help button. The hwndOwner member must specify the window to receive the HELPMSGSTRING
		/// registered messages that the dialog box sends when the user clicks the Help button.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_USEDEVMODECOPIES 0x00040000</term>
		/// <term>Same as PD_USEDEVMODECOPIESANDCOLLATE.</term>
		/// </item>
		/// <item>
		/// <term>PD_USEDEVMODECOPIESANDCOLLATE 0x00040000</term>
		/// <term>
		/// This flag indicates whether your application supports multiple copies and collation. Set this flag on input to indicate that
		/// your application does not support multiple copies and collation. In this case, the nCopies member of the PRINTDLG structure
		/// always returns 1, and PD_COLLATE is never set in the Flags member. If this flag is not set, the application is responsible
		/// for printing and collating multiple copies. In this case, the nCopies member of the PRINTDLG structure indicates the number
		/// of copies the user wants to print, and the PD_COLLATE flag in the Flags member indicates whether the user wants collation.
		/// Regardless of whether this flag is set, an application can determine from nCopies and PD_COLLATE how many copies to render
		/// and whether to print them collated. If this flag is set and the printer driver does not support multiple copies, the Copies
		/// edit control is disabled. Similarly, if this flag is set and the printer driver does not support collation, the Collate
		/// check box is disabled. The dmCopies and dmCollate members of the DEVMODE structure contain the copies and collate
		/// information used by the printer driver. If this flag is set and the printer driver supports multiple copies, the dmCopies
		/// member indicates the number of copies requested by the user. If this flag is set and the printer driver supports collation,
		/// the dmCollate member of the DEVMODE structure indicates whether the user wants collation. If this flag is not set, the
		/// dmCopies member always returns 1, and the dmCollate member is always zero. Known issue on Windows 2000/XP/2003: If this flag
		/// is not set before calling PrintDlg, PrintDlg might swap nCopies and dmCopies values when it returns. The workaround for this
		/// issue is use dmCopies if its value is larger than 1, else, use nCopies, for you to to get the actual number of copies to be
		/// printed when PrintDlg returns.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// To ensure that PrintDlg or PrintDlgEx returns the correct values in the <c>dmCopies</c> and <c>dmCollate</c> members of the
		/// DEVMODE structure, set <c>PD_RETURNDC</c> = <c>TRUE</c> and <c>PD_USEDEVMODECOPIESANDCOLLATE</c> = <c>TRUE</c>. In so doing,
		/// the <c>nCopies</c> member of the <c>PRINTDLG</c> structure is always 1 and <c>PD_COLLATE</c> is always <c>FALSE</c>.
		/// </para>
		/// <para>
		/// To ensure that PrintDlg or PrintDlgEx returns the correct values in <c>nCopies</c> and <c>PD_COLLATE</c>, set
		/// <c>PD_RETURNDC</c> = <c>TRUE</c> and <c>PD_USEDEVMODECOPIESANDCOLLATE</c> = <c>FALSE</c>. In so doing, <c>dmCopies</c> is
		/// always 1 and <c>dmCollate</c> is always <c>FALSE</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows 7, when you call PrintDlg or PrintDlgEx with <c>PD_RETURNDC</c> set to <c>TRUE</c> and
		/// <c>PD_USEDEVMODECOPIESANDCOLLATE</c> set to <c>FALSE</c>, the <c>PrintDlg</c> or <c>PrintDlgEx</c> function sets the number
		/// of copies in the <c>nCopies</c> member of the <c>PRINTDLG</c> structure, and it sets the number of copies in the structure
		/// represented by the hDC member of the <c>PRINTDLG</c> structure.
		/// </para>
		/// <para>
		/// When making calls to GDI, you must ignore the value of <c>nCopies</c>, consider the value as 1, and use the returned hDC to
		/// avoid printing duplicate copies.
		/// </para>
		/// </summary>
		public PD Flags;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The initial value for the starting page edit control.</para>
		/// <para>
		/// When PrintDlg returns, <c>nFromPage</c> is the starting page specified by the user. If the <c>Pages</c> radio button is
		/// selected when the user clicks the <c>Okay</c> button, <c>PrintDlg</c> sets the <c>PD_PAGENUMS</c> flag and does not return
		/// until the user enters a starting page value that is within the minimum to maximum page range.
		/// </para>
		/// <para>
		/// If the input value for either <c>nFromPage</c> or <c>nToPage</c> is outside the minimum/maximum range, PrintDlg returns an
		/// error only if the <c>PD_PAGENUMS</c> flag is specified; otherwise, it displays the dialog box but changes the out-of-range
		/// value to the minimum or maximum value.
		/// </para>
		/// </summary>
		public ushort nFromPage;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The initial value for the ending page edit control. When PrintDlg returns, <c>nToPage</c> is the ending page specified by
		/// the user. If the <c>Pages</c> radio button is selected when the use clicks the <c>Okay</c> button, <c>PrintDlg</c> sets the
		/// <c>PD_PAGENUMS</c> flag and does not return until the user enters an ending page value that is within the minimum to maximum
		/// page range.
		/// </para>
		/// </summary>
		public ushort nToPage;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The minimum value for the page range specified in the <c>From</c> and <c>To</c> page edit controls. If <c>nMinPage</c>
		/// equals <c>nMaxPage</c>, the <c>Pages</c> radio button and the starting and ending page edit controls are disabled.
		/// </para>
		/// </summary>
		public ushort nMinPage;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The maximum value for the page range specified in the <c>From</c> and <c>To</c> page edit controls.</para>
		/// </summary>
		public ushort nMaxPage;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The initial number of copies for the <c>Copies</c> edit control if <c>hDevMode</c> is <c>NULL</c>; otherwise, the
		/// <c>dmCopies</c> member of the DEVMODE structure contains the initial value. When PrintDlg returns, <c>nCopies</c> contains
		/// the actual number of copies to print. This value depends on whether the application or the printer driver is responsible for
		/// printing multiple copies. If the <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag is set in the <c>Flags</c> member, <c>nCopies</c>
		/// is always 1 on return, and the printer driver is responsible for printing multiple copies. If the flag is not set, the
		/// application is responsible for printing the number of copies specified by <c>nCopies</c>. For more information, see the
		/// description of the <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag.
		/// </para>
		/// </summary>
		public ushort nCopies;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>PD_ENABLEPRINTTEMPLATE</c> or <c>PD_ENABLESETUPTEMPLATE</c> flag is set in the <c>Flags</c> member,
		/// <c>hInstance</c> is a handle to the application or module instance that contains the dialog box template named by the
		/// <c>lpPrintTemplateName</c> or <c>lpSetupTemplateName</c> member.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>LPARAM</c></para>
		/// <para>
		/// Application-defined data that the system passes to the hook procedure identified by the <c>lpfnPrintHook</c> or
		/// <c>lpfnSetupHook</c> member. When the system sends the WM_INITDIALOG message to the hook procedure, the message's lParam
		/// parameter is a pointer to the <c>PRINTDLG</c> structure specified when the dialog was created. The hook procedure can use
		/// this pointer to get the <c>lCustData</c> value.
		/// </para>
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// <para>Type: <c>LPPRINTHOOKPROC</c></para>
		/// <para>
		/// A pointer to a PrintHookProc hook procedure that can process messages intended for the <c>Print</c> dialog box. This member
		/// is ignored unless the <c>PD_ENABLEPRINTHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPPRINTHOOKPROC? lpfnPrintHook;

		/// <summary>
		/// <para>Type: <c>LPSETUPHOOKPROC</c></para>
		/// <para>
		/// A pointer to a SetupHookProc hook procedure that can process messages intended for the <c>Print Setup</c> dialog box. This
		/// member is ignored unless the <c>PD_ENABLESETUPHOOK</c> flag is set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public LPSETUPHOOKPROC? lpfnSetupHook;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template replaces
		/// the default <c>Print</c> dialog box template. This member is ignored unless the <c>PD_ENABLEPRINTTEMPLATE</c> flag is set in
		/// the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpPrintTemplateName;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template replaces
		/// the default <c>Print Setup</c> dialog box template. This member is ignored unless the <c>PD_ENABLESETUPTEMPLATE</c> flag is
		/// set in the <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpSetupTemplateName;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// If the <c>PD_ENABLEPRINTTEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hPrintTemplate</c> is a handle to a
		/// memory object containing a dialog box template. This template replaces the default <c>Print</c> dialog box template.
		/// </para>
		/// </summary>
		public HGLOBAL hPrintTemplate;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// If the <c>PD_ENABLESETUPTEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hSetupTemplate</c> is a handle to a
		/// memory object containing a dialog box template. This template replaces the default <c>Print Setup</c> dialog box template.
		/// </para>
		/// </summary>
		public HGLOBAL hSetupTemplate;
	}

	/// <summary>
	/// Contains information that the PrintDlgEx function uses to initialize the Print property sheet. After the user closes the
	/// property sheet, the system uses this structure to return information about the user's selections.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If both <c>hDevMode</c> and <c>hDevNames</c> are <c>NULL</c>, PrintDlgEx initializes the property sheet using the current
	/// default printer. To initialize the property sheet for a different printer, use the <c>wDeviceOffset</c> member of the DEVNAMES
	/// structure to specify the name of the printer.
	/// </para>
	/// <para>
	/// Note that the <c>dmDeviceName</c> member of the DEVMODE structure also specifies a printer name. However, <c>dmDeviceName</c> is
	/// limited to 32 characters, and the <c>wDeviceOffset</c> name is not. If the <c>wDeviceOffset</c> and <c>dmDeviceName</c> names
	/// are not the same, PrintDlgEx initializes the property sheet using the printer specified by <c>wDeviceOffset</c>.
	/// </para>
	/// <para>
	/// If the PD_RETURNDEFAULT flag is set and both <c>hDevMode</c> and <c>hDevNames</c> are <c>NULL</c>, PrintDlgEx uses the
	/// <c>hDevNames</c> and <c>hDevMode</c> members to return information about the current default printer without displaying the
	/// dialog box.
	/// </para>
	/// <para>
	/// During the execution of PrintDlgEx, the DEVMODE and <c>DEVNAMES</c> structures that you specified in the <c>PRINTDLGEX</c>
	/// structure may not always contain current data. For this reason, application-specific property pages as well as
	/// IPrintDialogCallback routines for the initial page should use the IPrintDialogServices interface to retrieve information about
	/// the state of the current printer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-printdlgexa typedef struct tagPDEXA { DWORD lStructSize;
	// HWND hwndOwner; HGLOBAL hDevMode; HGLOBAL hDevNames; HDC hDC; DWORD Flags; DWORD Flags2; DWORD ExclusionFlags; DWORD nPageRanges;
	// DWORD nMaxPageRanges; LPPRINTPAGERANGE lpPageRanges; DWORD nMinPage; DWORD nMaxPage; DWORD nCopies; HINSTANCE hInstance; LPCSTR
	// lpPrintTemplateName; LPUNKNOWN lpCallback; DWORD nPropertyPages; HPROPSHEETPAGE *lphPropertyPages; DWORD nStartPage; DWORD
	// dwResultAction; } PRINTDLGEXA, *LPPRINTDLGEXA;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPDEXA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PRINTDLGEX
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The structure size, in bytes.</para>
		/// </summary>
		public uint lStructSize;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the window that owns the property sheet. This member must be a valid window handle; it cannot be <c>NULL</c>.</para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a movable global memory object that contains a DEVMODE structure. If <c>hDevMode</c> is not <c>NULL</c> on
		/// input, you must allocate a movable block of memory for the <c>DEVMODE</c> structure and initialize its members. The
		/// PrintDlgEx function uses the input data to initialize the controls in the property sheet. When <c>PrintDlgEx</c> returns,
		/// the <c>DEVMODE</c> members indicate the user's input.
		/// </para>
		/// <para>
		/// If <c>hDevMode</c> is <c>NULL</c> on input, PrintDlgEx allocates memory for the DEVMODE structure, initializes its members
		/// to indicate the user's input, and returns a handle that identifies it.
		/// </para>
		/// <para>
		/// For more information about the <c>hDevMode</c> and <c>hDevNames</c> members, see the Remarks section at the end of this topic.
		/// </para>
		/// </summary>
		public HGLOBAL hDevMode;

		/// <summary>
		/// <para>Type: <c>HGLOBAL</c></para>
		/// <para>
		/// A handle to a movable global memory object that contains a DEVNAMES structure. If <c>hDevNames</c> is not <c>NULL</c> on
		/// input, you must allocate a movable block of memory for the <c>DEVNAMES</c> structure and initialize its members. The
		/// PrintDlgEx function uses the input data to initialize the controls in the property sheet. When <c>PrintDlgEx</c> returns,
		/// the <c>DEVNAMES</c> members contain information for the printer chosen by the user. You can use this information to create a
		/// device context or an information context.
		/// </para>
		/// <para>
		/// The <c>hDevNames</c> member can be <c>NULL</c>, in which case, PrintDlgEx allocates memory for the DEVNAMES structure,
		/// initializes its members to indicate the user's input, and returns a handle that identifies it.
		/// </para>
		/// <para>
		/// For more information about the <c>hDevMode</c> and <c>hDevNames</c> members, see the Remarks section at the end of this topic.
		/// </para>
		/// </summary>
		public HGLOBAL hDevNames;

		/// <summary>
		/// <para>Type: <c>HDC</c></para>
		/// <para>
		/// A handle to a device context or an information context, depending on whether the <c>Flags</c> member specifies the
		/// <c>PD_RETURNDC</c> or <c>PC_RETURNIC</c> flag. If neither flag is specified, the value of this member is undefined. If both
		/// flags are specified, <c>PD_RETURNDC</c> has priority.
		/// </para>
		/// </summary>
		public HDC hDC;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that you can use to initialize the <c>Print</c> property sheet. When the PrintDlgEx function returns, it
		/// sets these flags to indicate the user's input. This member can be one or more of the following values.
		/// </para>
		/// <para>
		/// To ensure that PrintDlg or PrintDlgEx returns the correct values in the <c>dmCopies</c> and <c>dmCollate</c> members of the
		/// DEVMODE structure, set <c>PD_RETURNDC</c> = <c>TRUE</c> and <c>PD_USEDEVMODECOPIESANDCOLLATE</c> = <c>TRUE</c>. In so doing,
		/// the <c>nCopies</c> member of the PRINTDLG structure is always 1 and <c>PD_COLLATE</c> is always <c>FALSE</c>.
		/// </para>
		/// <para>
		/// To ensure that PrintDlg or PrintDlgEx returns the correct values in <c>nCopies</c> and <c>PD_COLLATE</c>, set
		/// <c>PD_RETURNDC</c> = <c>TRUE</c> and <c>PD_USEDEVMODECOPIESANDCOLLATE</c> = <c>FALSE</c>. In so doing, <c>dmCopies</c> is
		/// always 1 and <c>dmCollate</c> is always <c>FALSE</c>.
		/// </para>
		/// <para>
		/// Starting with Windows Vista, when you call PrintDlg or PrintDlgEx with <c>PD_RETURNDC</c> set to <c>TRUE</c> and
		/// <c>PD_USEDEVMODECOPIESANDCOLLATE</c> set to <c>FALSE</c>, the <c>PrintDlg</c> or <c>PrintDlgEx</c> function sets the number
		/// of copies in the <c>nCopies</c> member of the PRINTDLG structure, and it sets the number of copies in the structure
		/// represented by the <c>hDC</c> member of the <c>PRINTDLG</c> structure.
		/// </para>
		/// <para>
		/// When making calls to GDI, you must ignore the value of <c>nCopies</c>, consider the value as 1, and use the returned
		/// <c>hDC</c> to avoid printing duplicate copies.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PD_ALLPAGES 0x00000000</term>
		/// <term>
		/// The default flag that indicates that the All radio button is initially selected. This flag is used as a placeholder to
		/// indicate that the PD_PAGENUMS, PD_SELECTION, and PD_CURRENTPAGE flags are not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_COLLATE 0x00000010</term>
		/// <term>
		/// If this flag is set, the Collate check box is selected. If this flag is set when the PrintDlgEx function returns, the
		/// application must simulate collation of multiple copies. For more information, see the description of the
		/// PD_USEDEVMODECOPIESANDCOLLATE flag. See PD_NOPAGENUMS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_CURRENTPAGE 0x00400000</term>
		/// <term>
		/// If this flag is set, the Current Page radio button is selected. If none of the PD_PAGENUMS, PD_SELECTION, or PD_CURRENTPAGE
		/// flags is set, the All radio button is selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_DISABLEPRINTTOFILE 0x00080000</term>
		/// <term>Disables the Print to File check box.</term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLEPRINTTEMPLATE 0x00004000</term>
		/// <term>
		/// Indicates that the hInstance and lpPrintTemplateName members specify a replacement for the default dialog box template in
		/// the lower portion of the General page. The default template contains controls similar to those of the Print dialog box. The
		/// system uses the specified template to create a window that is a child of the General page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_ENABLEPRINTTEMPLATEHANDLE 0x00010000</term>
		/// <term>
		/// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template. This template
		/// replaces the default dialog box template in the lower portion of the General page. The system uses the specified template to
		/// create a window that is a child of the General page. The system ignores the lpPrintTemplateName member if this flag is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_EXCLUSIONFLAGS 0x01000000</term>
		/// <term>
		/// Indicates that the ExclusionFlags member identifies items to be excluded from the printer driver property pages. If this
		/// flag is not set, items will be excluded by default from the printer driver property pages. The exclusions prevent the
		/// duplication of items among the General page, any application-specified pages, and the printer driver pages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_HIDEPRINTTOFILE 0x00100000</term>
		/// <term>Hides the Print to File check box.</term>
		/// </item>
		/// <item>
		/// <term>PD_NOCURRENTPAGE 0x00800000</term>
		/// <term>Disables the Current Page radio button.</term>
		/// </item>
		/// <item>
		/// <term>PD_NOPAGENUMS 0x00000008</term>
		/// <term>
		/// Disables the Pages radio button and the associated edit controls. Also, it causes the Collate check box to appear in the dialog.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_NOSELECTION 0x00000004</term>
		/// <term>Disables the Selection radio button.</term>
		/// </item>
		/// <item>
		/// <term>PD_NOWARNING 0x00000080</term>
		/// <term>Prevents the warning message from being displayed when an error occurs.</term>
		/// </item>
		/// <item>
		/// <term>PD_PAGENUMS 0x00000002</term>
		/// <term>
		/// If this flag is set, the Pages radio button is selected. If none of the PD_PAGENUMS, PD_SELECTION, or PD_CURRENTPAGE flags
		/// is set, the All radio button is selected. If this flag is set when the PrintDlgEx function returns, the lpPageRanges member
		/// indicates the page ranges specified by the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_PRINTTOFILE 0x00000020</term>
		/// <term>
		/// If this flag is set, the Print to File check box is selected. If this flag is set when PrintDlgEx returns, the offset
		/// indicated by the wOutputOffset member of the DEVNAMES structure contains the string "FILE:". When you call the StartDoc
		/// function to start the printing operation, specify this "FILE:" string in the lpszOutput member of the DOCINFO structure.
		/// Specifying this string causes the print subsystem to query the user for the name of the output file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNDC 0x00000100</term>
		/// <term>
		/// Causes PrintDlgEx to return a device context matching the selections the user made in the property sheet. The device context
		/// is returned in hDC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNDEFAULT 0x00000400</term>
		/// <term>
		/// If this flag is set, the PrintDlgEx function does not display the property sheet. Instead, it sets the hDevNames and
		/// hDevMode members to handles to DEVNAMES and DEVMODE structures that are initialized for the system default printer. Both
		/// hDevNames and hDevMode must be NULL, or PrintDlgEx returns an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_RETURNIC 0x00000200</term>
		/// <term>
		/// Similar to the PD_RETURNDC flag, except this flag returns an information context rather than a device context. If neither
		/// PD_RETURNDC nor PD_RETURNIC is specified, hDC is undefined on output.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_SELECTION 0x00000001</term>
		/// <term>
		/// If this flag is set, the Selection radio button is selected. If none of the PD_PAGENUMS, PD_SELECTION, or PD_CURRENTPAGE
		/// flags is set, the All radio button is selected.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_USEDEVMODECOPIES 0x00040000</term>
		/// <term>Same as PD_USEDEVMODECOPIESANDCOLLATE.</term>
		/// </item>
		/// <item>
		/// <term>PD_USEDEVMODECOPIESANDCOLLATE 0x00040000</term>
		/// <term>
		/// This flag indicates whether your application supports multiple copies and collation. Set this flag on input to indicate that
		/// your application does not support multiple copies and collation. In this case, the nCopies member of the PRINTDLGEX
		/// structure always returns 1, and PD_COLLATE is never set in the Flags member. If this flag is not set, the application is
		/// responsible for printing and collating multiple copies. In this case, the nCopies member of the PRINTDLGEX structure
		/// indicates the number of copies the user wants to print, and the PD_COLLATE flag in the Flags member indicates whether the
		/// user wants collation. Regardless of whether this flag is set, an application can determine from nCopies and PD_COLLATE how
		/// many copies to render and whether to print them collated. If this flag is set and the printer driver does not support
		/// multiple copies, the Copies edit control is disabled. Similarly, if this flag is set and the printer driver does not support
		/// collation, the Collate check box is disabled. The dmCopies and dmCollate members of the DEVMODE structure contain the copies
		/// and collate information used by the printer driver. If this flag is set and the printer driver supports multiple copies, the
		/// dmCopies member indicates the number of copies requested by the user. If this flag is set and the printer driver supports
		/// collation, the dmCollate member of the DEVMODE structure indicates whether the user wants collation. If this flag is not
		/// set, the dmCopies member always returns 1, and the dmCollate member is always zero. In Windows versions prior to Windows
		/// Vista, if this flag is not set by the calling application and the dmCopies member of the DEVMODE structure is greater than
		/// 1, use that value for the number of copies; otherwise, use the value of the nCopies member of the PRINTDLGEX structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PD_USELARGETEMPLATE 0x10000000</term>
		/// <term>
		/// Forces the property sheet to use a large template for the General page. The larger template provides more space for
		/// applications that specify a custom template for the lower portion of the General page.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PD Flags;

		/// <summary>Type: <c>DWORD</c></summary>
		public uint Flags2;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that can exclude items from the printer driver property pages in the <c>Print</c> property sheet. This
		/// value is used only if the <c>PD_EXCLUSIONFLAGS</c> flag is set in the <c>Flags</c> member. Exclusion flags should be used
		/// only if the item to be excluded will be included on either the <c>General</c> page or on an application-defined page in the
		/// <c>Print</c> property sheet. This member can specify the following flag.
		/// </para>
		/// <para>PD_EXCL_COPIESANDCOLLATE</para>
		/// <para>
		/// Excludes the <c>Copies</c> and <c>Collate</c> controls from the printer driver property pages in a <c>Print</c> property
		/// sheet. This flag should always be set when the application uses the default <c>Copies</c> and <c>Collate</c> controls
		/// provided by the lower portion of the <c>General</c> page of the <c>Print</c> property sheet.
		/// </para>
		/// </summary>
		public PD_EXCL ExclusionFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// On input, set this member to the initial number of page ranges specified in the <c>lpPageRanges</c> array. When the
		/// PrintDlgEx function returns, <c>nPageRanges</c> indicates the number of user-specified page ranges stored in the
		/// <c>lpPageRanges</c> array. If the <c>PD_NOPAGENUMS</c> flag is specified, this value is not valid.
		/// </para>
		/// </summary>
		public uint nPageRanges;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in array elements, of the <c>lpPageRanges</c> buffer. This value indicates the maximum number of page ranges that
		/// can be stored in the array. If the <c>PD_NOPAGENUMS</c> flag is specified, this value is not valid. If the
		/// <c>PD_NOPAGENUMS</c> flag is not specified, this value must be greater than zero.
		/// </para>
		/// </summary>
		public uint nMaxPageRanges;

		/// <summary>
		/// <para>Type: <c>LPPRINTPAGERANGE</c></para>
		/// <para>
		/// Pointer to a buffer containing an array of PRINTPAGERANGE structures. On input, the array contains the initial page ranges
		/// to display in the <c>Pages</c> edit control. When the PrintDlgEx function returns, the array contains the page ranges
		/// specified by the user. If the <c>PD_NOPAGENUMS</c> flag is specified, this value is not valid. If the <c>PD_NOPAGENUMS</c>
		/// flag is not specified, <c>lpPageRanges</c> must be non- <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr lpPageRanges;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The minimum value for the page ranges specified in the <c>Pages</c> edit control. If the <c>PD_NOPAGENUMS</c> flag is
		/// specified, this value is not valid.
		/// </para>
		/// </summary>
		public uint nMinPage;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The maximum value for the page ranges specified in the <c>Pages</c> edit control. If the <c>PD_NOPAGENUMS</c> flag is
		/// specified, this value is not valid.
		/// </para>
		/// </summary>
		public uint nMaxPage;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Contains the initial number of copies for the <c>Copies</c> edit control if <c>hDevMode</c> is <c>NULL</c>; otherwise, the
		/// <c>dmCopies</c> member of the DEVMODE structure contains the initial value. When PrintDlgEx returns, <c>nCopies</c> contains
		/// the actual number of copies the application must print. This value depends on whether the application or the printer driver
		/// is responsible for printing multiple copies. If the <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag is set in the <c>Flags</c>
		/// member, <c>nCopies</c> is always 1 on return, and the printer driver is responsible for printing multiple copies. If the
		/// flag is not set, the application is responsible for printing the number of copies specified by <c>nCopies</c>. For more
		/// information, see the description of the <c>PD_USEDEVMODECOPIESANDCOLLATE</c> flag.
		/// </para>
		/// </summary>
		public uint nCopies;

		/// <summary>
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>
		/// If the <c>PD_ENABLEPRINTTEMPLATE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to the application
		/// or module instance that contains the dialog box template named by the <c>lpPrintTemplateName</c> member. If the
		/// <c>PD_ENABLEPRINTTEMPLATEHANDLE</c> flag is set in the <c>Flags</c> member, <c>hInstance</c> is a handle to a memory object
		/// containing a dialog box template. If neither of the template flags is set in the <c>Flags</c> member, <c>hInstance</c>
		/// should be <c>NULL</c>.
		/// </para>
		/// </summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the dialog box template resource in the module identified by the <c>hInstance</c> member. This template replaces
		/// the default dialog box template in the lower portion of the <c>General</c> page. The default template contains controls
		/// similar to those of the <c>Print</c> dialog box. This member is ignored unless the PD_ENABLEPRINTTEMPLATE flag is set in the
		/// <c>Flags</c> member.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpPrintTemplateName;

		/// <summary>
		/// <para>Type: <c>LPUNKNOWN</c></para>
		/// <para>A pointer to an application-defined callback object.</para>
		/// <para>
		/// The object should contain the IPrintDialogCallback class to receive messages for the child dialog box in the lower portion
		/// of the <c>General</c> page.
		/// </para>
		/// <para>
		/// The callback object should also contain the IObjectWithSite class to receive a pointer to the IPrintDialogServices
		/// interface. The PrintDlgEx function calls IUnknown::QueryInterface on the callback object for both
		/// <c>IID_IPrintDialogCallback</c> and <c>IID_IObjectWithSite</c> to determine which interfaces are supported.
		/// </para>
		/// <para>If you do not want to retrieve any of the callback information, set <c>lpCallback</c> to <c>NULL</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public object? lpCallback;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of property page handles in the <c>lphPropertyPages</c> array.</para>
		/// </summary>
		public uint nPropertyPages;

		/// <summary>
		/// <para>Type: <c>HPROPSHEETPAGE*</c></para>
		/// <para>
		/// Contains an array of property page handles to add to the <c>Print</c> property sheet. The additional property pages follow
		/// the <c>General</c> page. Use the CreatePropertySheetPage function to create these additional pages. When the PrintDlgEx
		/// function returns, all the <c>HPROPSHEETPAGE</c> handles in the <c>lphPropertyPages</c> array have been destroyed. If
		/// <c>nPropertyPages</c> is zero, <c>lphPropertyPages</c> should be <c>NULL</c>.
		/// </para>
		/// </summary>
		public IntPtr lphPropertyPages;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The property page that is initially displayed. To display the <c>General</c> page, specify <c>START_PAGE_GENERAL</c>.
		/// Otherwise, specify the zero-based index of a property page in the array specified in the <c>lphPropertyPages</c> member. For
		/// consistency, it is recommended that the property sheet always be started on the <c>General</c> page.
		/// </para>
		/// </summary>
		public uint nStartPage;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// On input, set this member to zero. If the PrintDlgEx function returns S_OK, <c>dwResultAction</c> contains the outcome of
		/// the dialog. If <c>PrintDlgEx</c> returns an error, this member should be ignored. The <c>dwResultAction</c> member can be
		/// one of the following values.
		/// </para>
		/// <para>PD_RESULT_APPLY</para>
		/// <para>
		/// The user clicked the <c>Apply</c> button and later clicked the <c>Cancel</c> button. This indicates that the user wants to
		/// apply the changes made in the property sheet, but does not want to print yet. The <c>PRINTDLGEX</c> structure contains the
		/// information specified by the user at the time the <c>Apply</c> button was clicked.
		/// </para>
		/// <para>PD_RESULT_CANCEL</para>
		/// <para>The user clicked the <c>Cancel</c> button. The information in the <c>PRINTDLGEX</c> structure is unchanged.</para>
		/// <para>PD_RESULT_PRINT</para>
		/// <para>
		/// The user clicked the <c>Print</c> button. The <c>PRINTDLGEX</c> structure contains the information specified by the user.
		/// </para>
		/// </summary>
		public PD_RESULT dwResultAction;
	}

	/// <summary>
	/// Represents a range of pages in a print job. A print job can have more than one page range. This information is supplied in the
	/// PRINTDLGEX structure when calling the PrintDlgEx function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-printpagerange typedef struct tagPRINTPAGERANGE { DWORD
	// nFromPage; DWORD nToPage; } PRINTPAGERANGE;
	[PInvokeData("commdlg.h", MSDNShortId = "NS:commdlg.tagPRINTPAGERANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PRINTPAGERANGE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The first page of the range.</para>
		/// </summary>
		public uint nFromPage;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The last page of the range.</para>
		/// </summary>
		public uint nToPage;
	}
}
