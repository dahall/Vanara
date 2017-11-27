using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value.
		/// </summary>
		private const uint WM_USER = 0x0400;

		/// <summary>
		/// Specifies an application-defined callback function used to send messages to, and process messages from, a Browse dialog box displayed in response to
		/// a call to SHBrowseForFolder.
		/// </summary>
		/// <param name="hwnd">The window handle of the browse dialog box.</param>
		/// <param name="uMsg">The dialog box event that generated the message.</param>
		/// <param name="lParam">
		/// A value whose meaning depends on the event specified in uMsg as follows:
		/// <list type="table">
		/// <listheader><term>uMsg</term><definition>lParam</definition></listheader>
		/// <item><term>BFFM_INITIALIZED</term><definition>Not used, value is NULL.</definition></item>
		/// <item><term>BFFM_IUNKNOWN</term><definition>A pointer to an IUnknown interface.</definition></item>
		/// <item><term>BFFM_SELCHANGED</term><definition>A PIDL that identifies the newly selected item.</definition></item>
		/// <item><term>BFFM_VALIDATEFAILED</term><definition>A pointer to a string that contains the invalid name. An application can use this data in an error dialog informing the user that the name was not valid.</definition></item>
		/// </list>
		/// </param>
		/// <param name="lpData">An application-defined value that was specified in the lParam member of the BROWSEINFO structure used in the call to SHBrowseForFolder.</param>
		/// <returns>
		/// Returns zero except in the case of BFFM_VALIDATEFAILED. For that flag, returns zero to dismiss the dialog or nonzero to keep the dialog displayed.
		/// </returns>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762598")]
		public delegate int BrowseCallbackProc(IntPtr hwnd, BrowseForFolderMessages uMsg, IntPtr lParam, IntPtr lpData);

		/// <summary>Enumeration with dialog messages used by the SHBrowseForFolder dialog box.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb762598")]
		public enum BrowseForFolderMessages : uint
		{
			BFFM_INITIALIZED = 1,
			BFFM_SELCHANGED = 2,
			BFFM_VALIDATEFAILEDA = 3,
			BFFM_VALIDATEFAILEDW = 4,
			BFFM_IUNKNOWN = 5,
			BFFM_SETSTATUSTEXTA = WM_USER + 100,
			BFFM_ENABLEOK = WM_USER + 101,
			BFFM_SETSELECTIONA = WM_USER + 102,
			BFFM_SETSELECTIONW = WM_USER + 103,
			BFFM_SETSTATUSTEXTW = WM_USER + 104,
			BFFM_SETOKTEXT = WM_USER + 105,
			BFFM_SETEXPANDED = WM_USER + 106
		}

		/// <summary>Flags enumeration to specify the dialog style.</summary>
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773205")]
		[Flags]
		public enum BrowseInfoFlag : uint
		{
			/// <summary>
			/// Only return file system directories. If the user selects folders that are not part of the file system, the OK button is grayed. <note>The OK
			/// button remains enabled for "\\server" items, as well as "\\server\share" and directory items. However, if the user selects a "\\server" item,
			/// passing the PIDL returned by SHBrowseForFolder to SHGetPathFromIDList fails.</note>
			/// </summary>
			BIF_RETURNONLYFSDIRS = 0x0001,

			/// <summary>Do not include network folders below the domain level in the dialog box's tree view control.</summary>
			BIF_DONTGOBELOWDOMAIN = 0x0002,

			/// <summary>
			/// Include a status area in the dialog box. The callback function can set the status text by sending messages to the dialog box. This flag is not
			/// supported when BIF_NEWDIALOGSTYLE is specified.
			/// </summary>
			BIF_STATUSTEXT = 0x0004,

			/// <summary>
			/// Only return file system ancestors. An ancestor is a subfolder that is beneath the root folder in the namespace hierarchy. If the user selects an
			/// ancestor of the root folder that is not part of the file system, the OK button is grayed.
			/// </summary>
			BIF_RETURNFSANCESTORS = 0x0008,

			/// <summary>Version 4.71. Include an edit control in the browse dialog box that allows the user to type the name of an item.</summary>
			BIF_EDITBOX = 0x0010,

			/// <summary>
			/// Version 4.71. If the user types an invalid name into the edit box, the browse dialog box calls the application's BrowseCallbackProc with the
			/// BFFM_VALIDATEFAILED message. This flag is ignored if BIF_EDITBOX is not specified.
			/// </summary>
			BIF_VALIDATE = 0x0020,

			/// <summary>
			/// Version 5.0. Use the new user interface. Setting this flag provides the user with a larger dialog box that can be resized. The dialog box has
			/// several new capabilities, including: drag-and-drop capability within the dialog box, reordering, shortcut menus, new folders, delete, and other
			/// shortcut menu commands. <note>If COM is initialized through CoInitializeEx with the COINIT_MULTITHREADED flag set, SHBrowseForFolder fails if
			/// BIF_NEWDIALOGSTYLE is passed.</note>
			/// </summary>
			BIF_NEWDIALOGSTYLE = 0x0040,

			/// <summary>
			/// Version 5.0. Use the new user interface, including an edit box. This flag is equivalent to BIF_EDITBOX | BIF_NEWDIALOGSTYLE. <note>If COM is
			/// initialized through CoInitializeEx with the COINIT_MULTITHREADED flag set, SHBrowseForFolder fails if BIF_USENEWUI is passed.</note>
			/// </summary>
			BIF_USENEWUI = BIF_NEWDIALOGSTYLE | BIF_EDITBOX,

			/// <summary>
			/// Version 5.0. The browse dialog box can display URLs. The BIF_USENEWUI and BIF_BROWSEINCLUDEFILES flags must also be set. If any of these three
			/// flags are not set, the browser dialog box rejects URLs. Even when these flags are set, the browse dialog box displays URLs only if the folder
			/// that contains the selected item supports URLs. When the folder's IShellFolder::GetAttributesOf method is called to request the selected item's
			/// attributes, the folder must set the SFGAO_FOLDER attribute flag. Otherwise, the browse dialog box will not display the URL.
			/// </summary>
			BIF_BROWSEINCLUDEURLS = 0x0080,

			/// <summary>
			/// Version 6.0. When combined with BIF_NEWDIALOGSTYLE, adds a usage hint to the dialog box, in place of the edit box. BIF_EDITBOX overrides this flag.
			/// </summary>
			BIF_UAHINT = 0x0100,

			/// <summary>Version 6.0. Do not include the New Folder button in the browse dialog box.</summary>
			BIF_NONEWFOLDERBUTTON = 0x0200,

			/// <summary>Version 6.0. When the selected item is a shortcut, return the PIDL of the shortcut itself rather than its target.</summary>
			BIF_NOTRANSLATETARGETS = 0x0400,

			/// <summary>Only return computers. If the user selects anything other than a computer, the OK button is grayed.</summary>
			BIF_BROWSEFORCOMPUTER = 0x1000,

			/// <summary>
			/// Only allow the selection of printers. If the user selects anything other than a printer, the OK button is grayed.
			/// <para>
			/// In Windows XP and later systems, the best practice is to use a Windows XP-style dialog, setting the root of the dialog to the Printers and Faxes
			/// folder (CSIDL_PRINTERS).
			/// </para>
			/// </summary>
			BIF_BROWSEFORPRINTER = 0x2000,

			/// <summary>Version 4.71. The browse dialog box displays files as well as folders.</summary>
			BIF_BROWSEINCLUDEFILES = 0x4000,

			/// <summary>
			/// Version 5.0. The browse dialog box can display sharable resources on remote systems. This is intended for applications that want to expose remote
			/// shares on a local system. The BIF_NEWDIALOGSTYLE flag must also be set.
			/// </summary>
			BIF_SHAREABLE = 0x8000,

			/// <summary>Windows 7 and later. Allow folder junctions such as a library or a compressed file with a .zip file name extension to be browsed.</summary>
			BIF_BROWSEFILEJUNCTIONS = 0x00010000
		}

		/// <summary>Contains parameters for the <see cref="SHBrowseForFolder"/> function and receives information about the folder selected by the user.</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
		[PInvokeData("Shlobj.h", MSDNShortId = "bb773205")]
		public struct BROWSEINFO
		{
			/// <summary>A handle to the owner window for the dialog box.</summary>
			public IntPtr hwndOwner;

			/// <summary>
			/// A PIDL that specifies the location of the root folder from which to start browsing. Only the specified folder and its subfolders in the namespace
			/// hierarchy appear in the dialog box. This member can be NULL; in that case, a default location is used.
			/// </summary>
			public IntPtr pidlRoot;

			/// <summary>
			/// Pointer to a buffer to receive the display name of the folder selected by the user. The size of this buffer is assumed to be MAX_PATH characters.
			/// </summary>
			public IntPtr pszDisplayName;

			/// <summary>
			/// Pointer to a null-terminated string that is displayed above the tree view control in the dialog box. This string can be used to specify
			/// instructions to the user.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpszTitle;

			/// <summary>
			/// Flags that specify the options for the dialog box. This member can be 0 or a combination of the following values. Version numbers refer to the
			/// minimum version of Shell32.dll required for SHBrowseForFolder to recognize flags added in later releases.
			/// </summary>
			public BrowseInfoFlag ulFlags;

			/// <summary>
			/// Pointer to an application-defined function that the dialog box calls when an event occurs. For more information, see the BrowseCallbackProc
			/// function. This member can be NULL.
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)] public BrowseCallbackProc lpfn;

			/// <summary>An application-defined value that the dialog box passes to the callback function, if one is specified in <see cref="lpfn"/>.</summary>
			public IntPtr lParam;

			/// <summary>An integer value that receives the index of the image associated with the selected folder, stored in the system image list.</summary>
			public int iImage;

			/// <summary>
			/// Initializes a new instance of the <see cref="BROWSEINFO"/> struct.
			/// </summary>
			/// <param name="hWnd">A handle to the owner window for the dialog box.</param>
			/// <param name="rootPidl">A PIDL that specifies the location of the root folder from which to start browsing.</param>
			/// <param name="title">The string that is displayed above the tree view control in the dialog box.</param>
			/// <param name="flags">Flags that specify the options for the dialog box.</param>
			/// <param name="callback">The callback function that the dialog box calls when an event occurs..</param>
			/// <param name="displayNameBuffer">Buffer that receives the display name of the folder selected by the user.</param>
			public BROWSEINFO(IntPtr hWnd, IntPtr rootPidl, string title, BrowseInfoFlag flags, BrowseCallbackProc callback, SafeCoTaskMemString displayNameBuffer)
			{
				hwndOwner = hWnd;
				pidlRoot = rootPidl;
				pszDisplayName = (IntPtr)displayNameBuffer;
				lpszTitle = title;
				ulFlags = flags;
				lpfn = callback;
				lParam = IntPtr.Zero;
				iImage = 0;
			}

			/// <summary>
			/// Gets the display name.
			/// </summary>
			/// <value>
			/// The display name.
			/// </value>
			public string DisplayName => Marshal.PtrToStringAuto(pszDisplayName);
		}
	}
}