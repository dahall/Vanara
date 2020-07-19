using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Specifies the values that indicate whether a control is visible and enabled. Used by members of the IFileDialogCustomize interface.
		/// </summary>
		[Flags]
		public enum CDCONTROLSTATEF : uint
		{
			/// <summary>The control is inactive and cannot be accessed by the user.</summary>
			CDCS_INACTIVE = 0x00000000,

			/// <summary>The control is active.</summary>
			CDCS_ENABLED = 0x00000001,

			/// <summary>The control is visible. The absence of this value indicates that the control is hidden.</summary>
			CDCS_VISIBLE = 0x00000002,

			/// <summary>Windows 7 and later. The control is visible and enabled.</summary>
			CDCS_ENABLEDVISIBLE = 0x00000003
		}

		/// <summary>Specifies list placement.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762502")]
		public enum FDAP : uint
		{
			/// <summary>The place is added to the bottom of the default list.</summary>
			FDAP_BOTTOM = 0,

			/// <summary>The place is added to the top of the default list.</summary>
			FDAP_TOP = 1
		}

		/// <summary>
		/// Specifies the values used by the IFileDialogEvents::OnShareViolation method to indicate an application's response to a sharing
		/// violation that occurs when a file is opened or saved.
		/// </summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb762504")]
		public enum FDE_SHAREVIOLATION_RESPONSE
		{
			/// <summary>
			/// The application has not handled the event. The dialog displays a UI that indicates that the file is in use and a different
			/// file must be chosen.
			/// </summary>
			FDESVR_DEFAULT,

			/// <summary>The application has determined that the file should be returned from the dialog.</summary>
			FDESVR_ACCEPT,

			/// <summary>The application has determined that the file should not be returned from the dialog.</summary>
			FDESVR_REFUSE
		}

		/// <summary>Defines the set of options available to an Open or Save dialog.</summary>
		[PInvokeData("Shobjidl.h", MSDNShortId = "dn457282")]
		[Flags]
		public enum FILEOPENDIALOGOPTIONS : uint
		{
			/// <summary>
			/// When saving a file, prompt before overwriting an existing file of the same name. This is a default value for the Save dialog.
			/// </summary>
			FOS_OVERWRITEPROMPT = 0x00000002,

			/// <summary>
			/// In the Save dialog, only allow the user to choose a file that has one of the file name extensions specified through IFileDialog::SetFileTypes.
			/// </summary>
			FOS_STRICTFILETYPES = 0x00000004,

			/// <summary>Don't change the current working directory.</summary>
			FOS_NOCHANGEDIR = 0x00000008,

			/// <summary>Present an Open dialog that offers a choice of folders rather than files.</summary>
			FOS_PICKFOLDERS = 0x00000020,

			/// <summary>
			/// Ensures that returned items are file system items (SFGAO_FILESYSTEM). Note that this does not apply to items returned by IFileDialog::GetCurrentSelection.
			/// </summary>
			FOS_FORCEFILESYSTEM = 0x00000040,

			/// <summary>
			/// Enables the user to choose any item in the Shell namespace, not just those with SFGAO_STREAM or SFAGO_FILESYSTEM attributes.
			/// This flag cannot be combined with FOS_FORCEFILESYSTEM.
			/// </summary>
			FOS_ALLNONSTORAGEITEMS = 0x00000080,

			/// <summary>
			/// Do not check for situations that would prevent an application from opening the selected file, such as sharing violations or
			/// access denied errors.
			/// </summary>
			FOS_NOVALIDATE = 0x00000100,

			/// <summary>
			/// Enables the user to select multiple items in the open dialog. Note that when this flag is set, the IFileOpenDialog interface
			/// must be used to retrieve those items.
			/// </summary>
			FOS_ALLOWMULTISELECT = 0x00000200,

			/// <summary>The item returned must be in an existing folder. This is a default value.</summary>
			FOS_PATHMUSTEXIST = 0x00000800,

			/// <summary>The item returned must exist. This is a default value for the Open dialog.</summary>
			FOS_FILEMUSTEXIST = 0x00001000,

			/// <summary>
			/// Prompt for creation if the item returned in the save dialog does not exist. Note that this does not actually create the item.
			/// </summary>
			FOS_CREATEPROMPT = 0x00002000,

			/// <summary>
			/// In the case of a sharing violation when an application is opening a file, call the application back through OnShareViolation
			/// for guidance. This flag is overridden by FOS_NOVALIDATE.
			/// </summary>
			FOS_SHAREAWARE = 0x00004000,

			/// <summary>Do not return read-only items. This is a default value for the Save dialog.</summary>
			FOS_NOREADONLYRETURN = 0x00008000,

			/// <summary>
			/// Do not test whether creation of the item as specified in the Save dialog will be successful. If this flag is not set, the
			/// calling application must handle errors, such as denial of access, discovered when the item is created.
			/// </summary>
			FOS_NOTESTFILECREATE = 0x00010000,

			/// <summary>
			/// Hide the list of places from which the user has recently opened or saved items. This value is not supported as of Windows 7.
			/// </summary>
			FOS_HIDEMRUPLACES = 0x00020000,

			/// <summary>
			/// Hide items shown by default in the view's navigation pane. This flag is often used in conjunction with the
			/// IFileDialog::AddPlace method, to hide standard locations and replace them with custom locations.
			/// <para>
			/// <c>Windows 7</c> and later. Hide all of the standard namespace locations (such as Favorites, Libraries, Computer, and
			/// Network) shown in the navigation pane.
			/// </para>
			/// <para>
			/// <c>Windows Vista.</c> Hide the contents of the Favorite Links tree in the navigation pane. Note that the category itself is
			/// still displayed, but shown as empty.
			/// </para>
			/// </summary>
			FOS_HIDEPINNEDPLACES = 0x00040000,

			/// <summary>
			/// Shortcuts should not be treated as their target items. This allows an application to open a .lnk file rather than what that
			/// file is a shortcut to.
			/// </summary>
			FOS_NODEREFERENCELINKS = 0x00100000,

			/// <summary>Do not add the item being opened or saved to the recent documents list (SHAddToRecentDocs).</summary>
			FOS_DONTADDTORECENT = 0x02000000,

			/// <summary>Include hidden and system items.</summary>
			FOS_FORCESHOWHIDDEN = 0x10000000,

			/// <summary>
			/// Indicates to the Save As dialog box that it should open in expanded mode. Expanded mode is the mode that is set and unset by
			/// clicking the button in the lower-left corner of the Save As dialog box that switches between Browse Folders and Hide Folders
			/// when clicked. This value is not supported as of Windows 7.
			/// </summary>
			FOS_DEFAULTNOMINIMODE = 0x20000000,

			/// <summary>Indicates to the Open dialog box that the preview pane should always be displayed.</summary>
			FOS_FORCEPREVIEWPANEON = 0x40000000,

			/// <summary>
			/// Indicates that the caller is opening a file as a stream (BHID_Stream), so there is no need to download that file.
			/// </summary>
			FOS_SUPPORTSTREAMABLEITEMS = 0x80000000
		}

		/// <summary>Indicates status of the merge process.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NF:shobjidl_core.IFileSyncMergeHandler.Merge")]
		public enum MERGE_UPDATE_STATUS
		{
			/// <summary>Indicates that the process has completed successfully.</summary>
			MUS_COMPLETE = 0,

			/// <summary>Indicates that additional input is required by the user for the process to complete.</summary>
			MUS_USERINPUTNEEDED = (MUS_COMPLETE + 1),

			/// <summary>Indicates that the process has failed.</summary>
			MUS_FAILED = (MUS_USERINPUTNEEDED + 1)
		}

		/// <summary>Used by methods of the ITransferSource and ITransferDestination interfaces to control their file operations.</summary>
		[Flags]
		public enum TRANSFER_SOURCE_FLAGS
		{
			/// <summary>Fail if the destination already exists, unless TSF_OVERWRITE_EXIST is specified. This is a default behavior.</summary>
			TSF_NORMAL = 0,

			/// <summary>Fail if the destination already exists, unless TSF_OVERWRITE_EXIST is specified. This is a default behavior</summary>
			TSF_FAIL_EXIST = 0,

			/// <summary>Rename with auto-name generation if the destination already exists.</summary>
			TSF_RENAME_EXIST = 0x1,

			/// <summary>Overwrite or merge with the destination.</summary>
			TSF_OVERWRITE_EXIST = 0x2,

			/// <summary>Allow creation of a decrypted destination.</summary>
			TSF_ALLOW_DECRYPTION = 0x4,

			/// <summary>No discretionary access control list (DACL), system access control list (SACL), or owner.</summary>
			TSF_NO_SECURITY = 0x8,

			/// <summary>
			/// Copy the creation time as part of the copy. This can be useful for a move operation that is being used as a copy and delete
			/// operation (TSF_MOVE_AS_COPY_DELETE).
			/// </summary>
			TSF_COPY_CREATION_TIME = 0x10,

			/// <summary>Copy the last write time as part of the copy.</summary>
			TSF_COPY_WRITE_TIME = 0x20,

			/// <summary>Assign write, read, and delete permissions as share mode.</summary>
			TSF_USE_FULL_ACCESS = 0x40,

			/// <summary>Recycle on file delete, if possible.</summary>
			TSF_DELETE_RECYCLE_IF_POSSIBLE = 0x80,

			/// <summary>Hard link to the desired source (not required). This avoids a normal copy operation.</summary>
			TSF_COPY_HARD_LINK = 0x100,

			/// <summary>Copy the localized name.</summary>
			TSF_COPY_LOCALIZED_NAME = 0x200,

			/// <summary>Move as a copy and delete operation.</summary>
			TSF_MOVE_AS_COPY_DELETE = 0x400,

			/// <summary>Suspend Shell events.</summary>
			TSF_SUSPEND_SHELLEVENTS = 0x800
		}

		/// <summary>Exposes methods that initialize, show, and get results from the common file dialog.</summary>
		/// <seealso cref="IModalWindow"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775966")]
		public interface IFileDialog : IModalWindow
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show([Optional] HWND parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			void SetFileTypes(uint cFileTypes,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that
			/// this is a one-based index, not zero-based.
			/// </param>
			void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in
			/// its cFileTypes parameter.
			/// </returns>
			uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identifying this event handler. When the client is finished with the dialog, that client must call the
			/// IFileDialog::Unadvise method with this value.
			/// </returns>
			uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the
			/// IFileDialog::Advise method.
			/// </param>
			void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>
			/// When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.
			/// </returns>
			FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to
			/// be selected when the dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file
			/// or folder selected in the view window, or something that the user has entered into the dialog's edit box. The latter case
			/// may require a parsing operation (cancelable by the user) that blocks the current thread.
			/// </returns>
			IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			SafeCoTaskMemString GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">
			/// A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.
			/// </param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg"
			/// is correct, while ".jpg" is not.
			/// </param>
			void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			void SetClientGuid(in Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);
		}

		/// <summary>
		/// Extends the IFileDialog interface by providing methods that allow the caller to name a specific, restricted location that can be
		/// browsed in the common file dialog as well as to specify alternate text to display as a label on the Cancel button.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.IFileDialog"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("61744fc7-85b5-4791-a9b0-272276309b13")]
		[PInvokeData("Shobjidl.h", MinClient = PInvokeClient.Windows7)]
		public interface IFileDialog2 : IFileDialog
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show([Optional] HWND parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			new void SetFileTypes(uint cFileTypes,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that
			/// this is a one-based index, not zero-based.
			/// </param>
			new void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in
			/// its cFileTypes parameter.
			/// </returns>
			new uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identifying this event handler. When the client is finished with the dialog, that client must call the
			/// IFileDialog::Unadvise method with this value.
			/// </returns>
			new uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the
			/// IFileDialog::Advise method.
			/// </param>
			new void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			new void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>
			/// When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.
			/// </returns>
			new FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to
			/// be selected when the dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			new IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file
			/// or folder selected in the view window, or something that the user has entered into the dialog's edit box. The latter case
			/// may require a parsing operation (cancelable by the user) that blocks the current thread.
			/// </returns>
			new IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			new SafeCoTaskMemString GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			new IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">
			/// A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.
			/// </param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			new void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg"
			/// is correct, while ".jpg" is not.
			/// </param>
			new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			new void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			new void SetClientGuid(in Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			new void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

			/// <summary>Replaces the default text "Cancel" on the common file dialog's Cancel button.</summary>
			/// <param name="pszLabel">Pointer to a string that contains the new text to display on the button.</param>
			void SetCancelButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>
			/// Specifies a top-level location from which to begin browsing a namespace, for instance in the Save dialog's Browse folder
			/// option. Users cannot navigate above this location.
			/// </summary>
			/// <param name="psi">Pointer to an IShellItem object that represents the navigation root.</param>
			void SetNavigationRoot([MarshalAs(UnmanagedType.Interface)] IShellItem psi);
		}

		/// <summary>
		/// Exposes methods that allow an application to be notified of events that are related to controls that the application has added
		/// to a common file dialog.
		/// </summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("36116642-D713-4b97-9B83-7484A9D00433")]
		[PInvokeData("Shobjidl.h")]
		public interface IFileDialogControlEvents
		{
			/// <summary>Called when [item selected].</summary>
			/// <param name="pfdc">The PFDC.</param>
			/// <param name="dwIDCtl">The dw identifier control.</param>
			/// <param name="dwIDItem">The dw identifier item.</param>
			/// <returns></returns>
			[PreserveSig]
			HRESULT OnItemSelected(IFileDialogCustomize pfdc, uint dwIDCtl, uint dwIDItem);

			/// <summary>Called when [button clicked].</summary>
			/// <param name="pfdc">The PFDC.</param>
			/// <param name="dwIDCtl">The dw identifier control.</param>
			/// <returns></returns>
			[PreserveSig]
			HRESULT OnButtonClicked(IFileDialogCustomize pfdc, uint dwIDCtl);

			/// <summary>Called when [check button toggled].</summary>
			/// <param name="pfdc">The PFDC.</param>
			/// <param name="dwIDCtl">The dw identifier control.</param>
			/// <param name="bChecked">if set to <c>true</c> [b checked].</param>
			/// <returns></returns>
			[PreserveSig]
			HRESULT OnCheckButtonToggled(IFileDialogCustomize pfdc, uint dwIDCtl, [MarshalAs(UnmanagedType.Bool)] bool bChecked);

			/// <summary>Called when [control activating].</summary>
			/// <param name="pfdc">The PFDC.</param>
			/// <param name="dwIDCtl">The dw identifier control.</param>
			/// <returns></returns>
			[PreserveSig]
			HRESULT OnControlActivating(IFileDialogCustomize pfdc, uint dwIDCtl);
		}

		/// <summary>Exposes methods that allow an application to add controls to a common file dialog.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, Guid("e6fdd21a-163f-4975-9c8c-a69f1ba37034"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFileDialogCustomize
		{
			/// <summary>Enables a drop-down list on the Open or Save button in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the drop-down list.</param>
			void EnableOpenDropDown(uint dwIDCtl);

			/// <summary>Adds a menu to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the menu to add.</param>
			/// <param name="pszLabel">A pointer to a buffer that contains the menu name as a null-terminated Unicode string.</param>
			void AddMenu(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Adds a button to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the button to add.</param>
			/// <param name="pszLabel">A pointer to a buffer that contains the button text as a null-terminated Unicode string.</param>
			void AddPushButton(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Adds a combo box to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the combo box to add.</param>
			void AddComboBox(uint dwIDCtl);

			/// <summary>Adds an option button (also known as radio button) group to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the option button group to add.</param>
			void AddRadioButtonList(uint dwIDCtl);

			/// <summary>Adds a check button (check box) to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the check button to add.</param>
			/// <param name="pszLabel">A pointer to a buffer that contains the button text as a null-terminated Unicode string.</param>
			/// <param name="bChecked">A BOOL indicating the current state of the check button. TRUE if checked; FALSE otherwise.</param>
			void AddCheckButton(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel, [MarshalAs(UnmanagedType.Bool)] bool bChecked);

			/// <summary>Adds an edit box control to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the edit box to add.</param>
			/// <param name="pszText">
			/// A pointer to a null-terminated Unicode string that provides the default text displayed in the edit box.
			/// </param>
			void AddEditBox(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Adds a separator to the dialog, allowing a visual separation of controls.</summary>
			/// <param name="dwIDCtl">The control ID of the separator.</param>
			void AddSeparator(uint dwIDCtl);

			/// <summary>Adds text content to the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the text to add.</param>
			/// <param name="pszText">A pointer to a buffer that contains the text as a null-terminated Unicode string.</param>
			void AddText(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text associated with a control, such as button text or an edit box label.</summary>
			/// <param name="dwIDCtl">The ID of the control whose text is to be changed.</param>
			/// <param name="pszLabel">A pointer to a buffer that contains the text as a null-terminated Unicode string.</param>
			void SetControlLabel(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the current visibility and enabled states of a given control.</summary>
			/// <param name="dwIDCtl">The ID of the control in question.</param>
			/// <returns>
			/// A variable that receives one or more values from the CDCONTROLSTATE enumeration that indicate the current state of the control.
			/// </returns>
			CDCONTROLSTATEF GetControlState(uint dwIDCtl);

			/// <summary>Sets the current visibility and enabled states of a given control.</summary>
			/// <param name="dwIDCtl">The ID of the control in question.</param>
			/// <param name="dwState">One or more values from the CDCONTROLSTATE enumeration that indicate the current state of the control.</param>
			void SetControlState(uint dwIDCtl, CDCONTROLSTATEF dwState);

			/// <summary>Gets the current text in an edit box control.</summary>
			/// <param name="dwIDCtl">The ID of the edit box.</param>
			/// <param name="ppszText">The address of a pointer to a buffer that receives the text as a null-terminated Unicode string.</param>
			void GetEditBoxText(uint dwIDCtl, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CoTaskMemStringMarshaler))] out string ppszText);

			/// <summary>Sets the text in an edit box control found in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the edit box.</param>
			/// <param name="pszText">A pointer to a buffer that contains the text as a null-terminated Unicode string.</param>
			void SetEditBoxText(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Gets the current state of a check button (check box) in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the check box.</param>
			/// <returns>A BOOL value that indicates whether the box is checked. TRUE means checked; FALSE, unchecked.</returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetCheckButtonState(uint dwIDCtl);

			/// <summary>Sets the state of a check button (check box) in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the check box.</param>
			/// <param name="bChecked">A BOOL value that indicates whether the box is checked. TRUE means checked; FALSE, unchecked.</param>
			void SetCheckButtonState(uint dwIDCtl, [MarshalAs(UnmanagedType.Bool)] bool bChecked);

			/// <summary>Adds an item to a container control in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control to which the item is to be added.</param>
			/// <param name="dwIDItem">The ID of the item.</param>
			/// <param name="pszLabel">
			/// A pointer to a buffer that contains the item's text, which can be either a label or, in the case of a drop-down list, the
			/// item itself. This text is a null-terminated Unicode string.
			/// </param>
			void AddControlItem(uint dwIDCtl, int dwIDItem, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Removes an item from a container control in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control from which the item is to be removed.</param>
			/// <param name="dwIDItem">The ID of the item.</param>
			void RemoveControlItem(uint dwIDCtl, int dwIDItem);

			/// <summary>Not implemented.</summary>
			/// <param name="dwIDCtl"></param>
			void RemoveAllControlItems(uint dwIDCtl);

			/// <summary>Gets the current state of an item in a container control found in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control.</param>
			/// <param name="dwIDItem">The ID of the item.</param>
			/// <returns>
			/// A pointer to a variable that receives one of more values from the CDCONTROLSTATE enumeration that indicate the current state
			/// of the control.
			/// </returns>
			CDCONTROLSTATEF GetControlItemState(uint dwIDCtl, int dwIDItem);

			/// <summary>Sets the current state of an item in a container control found in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control.</param>
			/// <param name="dwIDItem">The ID of the item.</param>
			/// <param name="dwState">One or more values from the CDCONTROLSTATE enumeration that indicate the new state of the control.</param>
			void SetControlItemState(uint dwIDCtl, int dwIDItem, CDCONTROLSTATEF dwState);

			/// <summary>Gets a particular item from specified container controls in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control.</param>
			/// <returns>The ID of the item that the user selected in the control.</returns>
			uint GetSelectedControlItem(uint dwIDCtl);

			/// <summary>Sets the selected state of a particular item in an option button group or a combo box found in the dialog.</summary>
			/// <param name="dwIDCtl">The ID of the container control.</param>
			/// <param name="dwIDItem">The ID of the item to display as selected in the control.</param>
			void SetSelectedControlItem(uint dwIDCtl, int dwIDItem);

			/// <summary>Declares a visual group in the dialog. Subsequent calls to any "add" method add those elements to this group.</summary>
			/// <param name="dwIDCtl">The ID of the visual group.</param>
			/// <param name="pszLabel">
			/// A pointer to a buffer that contains text, as a null-terminated Unicode string, that appears next to the visual group.
			/// </param>
			void StartVisualGroup(uint dwIDCtl, [MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Stops the addition of elements to a visual group in the dialog.</summary>
			void EndVisualGroup();

			/// <summary>Places a control in the dialog so that it stands out compared to other added controls.</summary>
			/// <param name="dwIDCtl">The ID of the control.</param>
			void MakeProminent(uint dwIDCtl);
		}

		/// <summary>Exposes methods that allow notification of events within a common file dialog.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("973510DB-7D7F-452B-8975-74A85828D354")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775876")]
		public interface IFileDialogEvents
		{
			/// <summary>Called just before the dialog is about to return with a result.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>
			/// Implementations should return S_OK to accept the current result in the dialog or S_FALSE to refuse it. In the case of
			/// S_FALSE, the dialog should remain open.
			/// </returns>
			/// <remarks>
			/// When this method is called, the IFileDialog::GetResult and GetResults methods can be called.
			/// <para>
			/// The application can use this callback method to perform additional validation before the dialog closes, or to prevent the
			/// dialog from closing. If the application prevents the dialog from closing, it should display a UI to indicate a cause. To
			/// obtain a parent HWND for the UI, obtain the IOleWindow interface through IFileDialog::QueryInterface and call IOleWindow::GetWindow.
			/// </para>
			/// <para>An application can also use this method to perform all of its work surrounding the opening or saving of files.</para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnFileOk(IFileDialog pfd);

			/// <summary>
			/// Called before IFileDialogEvents::OnFolderChange. This allows the implementer to stop navigation to a particular location.
			/// </summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psiFolder">A pointer to an interface that represents the folder to which the dialog is about to navigate.</param>
			/// <returns>
			/// Returns S_OK if successful, or an error value otherwise. A return value of S_OK or E_NOTIMPL indicates that the folder
			/// change can proceed.
			/// </returns>
			/// <remarks>
			/// The calling application can call IFileDialog::SetFolder during this callback to redirect navigation to an alternate folder.
			/// The actual navigation does not occur until IFileDialogEvents::OnFolderChanging has returned.
			/// <para>
			/// If the calling application simply prevents navigation to a particular folder, UI should be displayed with an explanation of
			/// the restriction. To obtain a parent HWND for the UI, obtain the IOleWindow interface through IFileDialog and call IOleWindow::GetWindow.
			/// </para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnFolderChanging(IFileDialog pfd, IShellItem psiFolder);

			/// <summary>Called when the user navigates to a new folder.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT OnFolderChange(IFileDialog pfd);

			/// <summary>Called when the user changes the selection in the dialog's view.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			[PreserveSig]
			HRESULT OnSelectionChange(IFileDialog pfd);

			/// <summary>Enables an application to respond to sharing violations that arise from Open or Save operations.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psi">A pointer to the interface that represents the item that has the sharing violation.</param>
			/// <param name="pResponse">
			/// A pointer to a value from the FDE_SHAREVIOLATION_RESPONSE enumeration indicating the response to the sharing violation.
			/// </param>
			/// <returns>
			/// The implementer should return E_NOTIMPL if this method is not implemented; S_OK or an appropriate error code otherwise.
			/// </returns>
			/// <remarks>
			/// The FOS_SHAREAWARE flag must be set through IFileDialog::SetOptions before this method is called.
			/// <para>
			/// A sharing violation could possibly arise when the application attempts to open a file, because the file could have been
			/// locked between the time that the dialog tested it and the application opened it.
			/// </para>
			/// </remarks>
			[PreserveSig]
			HRESULT OnShareViolation(IFileDialog pfd, IShellItem psi, out FDE_SHAREVIOLATION_RESPONSE pResponse);

			/// <summary>Called when the dialog is opened to notify the application of the initial chosen filetype.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
			/// <remarks>
			/// This method is called when the dialog is opened to notify the application of the initially chosen filetype. If the
			/// application has code in IFileDialogEvents that responds to type changes, it can respond to the type. For example, it could
			/// hide certain controls. The application controls the initial file type and could do its own checks, so this method is
			/// provided as a convenience.
			/// </remarks>
			[PreserveSig]
			HRESULT OnTypeChange(IFileDialog pfd);

			/// <summary>Called from the save dialog when the user chooses to overwrite a file.</summary>
			/// <param name="pfd">A pointer to the interface that represents the dialog.</param>
			/// <param name="psi">A pointer to the interface that represents the item that will be overwritten.</param>
			/// <param name="pResponse">
			/// A pointer to a value from the FDE_OVERWRITE_RESPONSE enumeration indicating the response to the potential overwrite action.
			/// </param>
			/// <returns>
			/// The implementer should return E_NOTIMPL if this method is not implemented; S_OK or an appropriate error code otherwise.
			/// </returns>
			/// <remarks>The FOS_OVERWRITEPROMPT flag must be set through IFileDialog::SetOptions before this method is called.</remarks>
			[PreserveSig]
			HRESULT OnOverwrite(IFileDialog pfd, IShellItem psi, out FDE_SHAREVIOLATION_RESPONSE pResponse);
		}

		/// <summary>Extends the IFileDialog interface by adding methods specific to the open dialog.</summary>
		/// <seealso cref="IFileDialog"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d57c7288-d4ad-4768-be02-9d969532d960"), CoClass(typeof(CFileOpenDialog))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775834")]
		public interface IFileOpenDialog : IFileDialog
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show([Optional] HWND parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			new void SetFileTypes(uint cFileTypes,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that
			/// this is a one-based index, not zero-based.
			/// </param>
			new void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in
			/// its cFileTypes parameter.
			/// </returns>
			new uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identifying this event handler. When the client is finished with the dialog, that client must call the
			/// IFileDialog::Unadvise method with this value.
			/// </returns>
			new uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the
			/// IFileDialog::Advise method.
			/// </param>
			new void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			new void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>
			/// When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.
			/// </returns>
			new FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to
			/// be selected when the dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			new IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file
			/// or folder selected in the view window, or something that the user has entered into the dialog's edit box. The latter case
			/// may require a parsing operation (cancelable by the user) that blocks the current thread.
			/// </returns>
			new IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			new SafeCoTaskMemString GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			new IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">
			/// A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.
			/// </param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			new void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg"
			/// is correct, while ".jpg" is not.
			/// </param>
			new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			new void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			new void SetClientGuid(in Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			new void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

			/// <summary>Gets the user's choices in a dialog that allows multiple selection.</summary>
			/// <returns>The address of a pointer to an IShellItemArray through which the items selected in the dialog can be accessed.</returns>
			IShellItemArray GetResults();

			/// <summary>
			/// Gets the currently selected items in the dialog. These items may be items selected in the view, or text selected in the file
			/// name edit box.
			/// </summary>
			/// <returns>The address of a pointer to an IShellItemArray through which the selected items can be accessed.</returns>
			IShellItemArray GetSelectedItems();
		}

		/// <summary>
		/// Exposes methods that provide a rich notification system used by callers of IFileOperation to monitor the details of the
		/// operations they are performing through that interface.
		/// </summary>
		[ComImport, Guid("04b0f1a7-9490-44bc-96e1-4296a31252e2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775722")]
		public interface IFileOperationProgressSink
		{
			/// <summary>Performs caller-implemented actions before any specific file operations are performed.</summary>
			[PreserveSig]
			HRESULT StartOperations();

			/// <summary>Performs caller-implemented actions after the last operation performed by the call to IFileOperation is complete.</summary>
			/// <param name="hrResult">
			/// The return value of the final operation. Note that this is not the HRESULT returned by one of the IFileOperation methods,
			/// which simply queue the operations. Instead, this is the result of the actual operation, such as copy, delete, or move.
			/// </param>
			[PreserveSig]
			HRESULT FinishOperations(HRESULT hrResult);

			/// <summary>Performs caller-implemented actions before the rename process for each item begins.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that control the operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the item to be renamed.</param>
			/// <param name="pszNewName">Pointer to the new display name of the item. This is a null-terminated, Unicode string.</param>
			[PreserveSig]
			HRESULT PreRenameItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			/// <summary>Performs caller-implemented actions after the rename process for each item is complete.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that were used during the rename operation. Some values can be set or changed during the
			/// rename operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the item before it was renamed.</param>
			/// <param name="pszNewName">
			/// Pointer to the new display name of the item. This is a null-terminated, Unicode string. Note that this might not be the name
			/// that you asked for, given collisions and other naming rules.
			/// </param>
			/// <param name="hrRename">
			/// The return value of the rename operation. Note that this is not the HRESULT returned by RenameItem, which simply queues the
			/// rename operation. Instead, this is the result of the actual rename operation.
			/// </param>
			/// <param name="psiNewlyCreated">Pointer to an IShellItem that represents the item with its new name.</param>
			[PreserveSig]
			HRESULT PostRenameItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HRESULT hrRename, IShellItem psiNewlyCreated);

			/// <summary>Performs caller-implemented actions before the move process for each item begins.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that control the operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the item to be moved.</param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder to contain the moved item.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be NULL. If NULL,
			/// the name of the destination item is the same as the source.
			/// </param>
			[PreserveSig]
			HRESULT PreMoveItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			/// <summary>Performs caller-implemented actions after the move process for each item is complete.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that were used during the move operation. Some values can be set or changed during the
			/// move operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder that contains the moved item.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to the name that was given to the item after it was moved. This is a null-terminated Unicode string. Note that this
			/// might not be the name that you asked for, given collisions and other naming rules.
			/// </param>
			/// <param name="hrMove">
			/// The return value of the move operation. Note that this is not the HRESULT returned by MoveItem, which simply queues the move
			/// operation. Instead, this is the result of the actual move.
			/// </param>
			/// <param name="psiNewlyCreated">Pointer to an IShellItem that represents the moved item in its new location.</param>
			[PreserveSig]
			HRESULT PostMoveItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HRESULT hrMove, IShellItem psiNewlyCreated);

			/// <summary>Performs caller-implemented actions before the copy process for each item begins.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that control the operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder to contain the copy of the item.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be NULL. If
			/// NULL, the name of the destination item is the same as the source.
			/// </param>
			[PreserveSig]
			HRESULT PreCopyItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			/// <summary>Performs caller-implemented actions after the copy process for each item is complete.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that were used during the copy operation. Some values can be set or changed during the
			/// copy operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the source item.</param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder to which the item was copied.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to the new name that was given to the item after it was copied. This is a null-terminated Unicode string. Note that
			/// this might not be the name that you asked for, given collisions and other naming rules.
			/// </param>
			/// <param name="hrCopy">
			/// The return value of the copy operation. Note that this is not the HRESULT returned by CopyItem, which simply queues the copy
			/// operation. Instead, this is the result of the actual copy.
			/// </param>
			/// <param name="psiNewlyCreated">Pointer to an IShellItem that represents the new copy of the item.</param>
			[PreserveSig]
			HRESULT PostCopyItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				HRESULT hrCopy, IShellItem psiNewlyCreated);

			/// <summary>Performs caller-implemented actions before the delete process for each item begins.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that control the operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the item to be deleted.</param>
			[PreserveSig]
			HRESULT PreDeleteItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem);

			/// <summary>Performs caller-implemented actions after the delete process for each item is complete.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that were used during the delete operation. Some values can be set or changed during the
			/// delete operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiItem">Pointer to an IShellItem that specifies the item that was deleted.</param>
			/// <param name="hrDelete">
			/// The return value of the delete operation. Note that this is not the HRESULT returned by DeleteItem, which simply queues the
			/// delete operation. Instead, this is the result of the actual deletion.
			/// </param>
			/// <param name="psiNewlyCreated">
			/// A pointer to an IShellItem that specifies the deleted item, now in the Recycle Bin. If the item was fully deleted, this
			/// value is NULL.
			/// </param>
			[PreserveSig]
			HRESULT PostDeleteItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiItem, HRESULT hrDelete, IShellItem psiNewlyCreated);

			/// <summary>Performs caller-implemented actions before the process to create a new item begins.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that control the operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder that will contain the new item.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to the file name of the new item, for instance Newfile.txt. This is a null-terminated, Unicode string.
			/// </param>
			[PreserveSig]
			HRESULT PreNewItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

			/// <summary>Performs caller-implemented actions after the new item is created.</summary>
			/// <param name="dwFlags">
			/// bitwise value that contains flags that were used during the creation operation. Some values can be set or changed during the
			/// creation operation. See TRANSFER_SOURCE_FLAGS for flag descriptions.
			/// </param>
			/// <param name="psiDestinationFolder">
			/// Pointer to an IShellItem that specifies the destination folder to which the new item was added.
			/// </param>
			/// <param name="pszNewName">
			/// Pointer to the file name of the new item, for instance Newfile.txt. This is a null-terminated, Unicode string.
			/// </param>
			/// <param name="pszTemplateName">
			/// Pointer to the name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the
			/// following locations:
			/// <list type="bullet">
			/// <item>
			/// <description>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</description>
			/// </item>
			/// <item>
			/// <description>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</description>
			/// </item>
			/// <item>
			/// <description>%SystemRoot%\shellnew</description>
			/// </item>
			/// </list>
			/// <para>
			/// This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the
			/// minimal content that an application wants to include in any new file.
			/// </para>
			/// <para>This parameter is normally NULL to specify a new, blank file.</para>
			/// </param>
			/// <param name="dwFileAttributes">The file attributes applied to the new item. One or more of the values found at GetFileAttributes.</param>
			/// <param name="hrNew">
			/// The return value of the creation operation. Note that this is not the HRESULT returned by NewItem, which simply queues the
			/// creation operation. Instead, this is the result of the actual creation.
			/// </param>
			/// <param name="psiNewItem">Pointer to an IShellItem that represents the new item.</param>
			[PreserveSig]
			HRESULT PostNewItem(TRANSFER_SOURCE_FLAGS dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName,
				[MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, uint dwFileAttributes, HRESULT hrNew, IShellItem psiNewItem);

			/// <summary>Updates the progress.</summary>
			/// <param name="iWorkTotal">The i work total.</param>
			/// <param name="iWorkSoFar">The i work so far.</param>
			[PreserveSig]
			HRESULT UpdateProgress(uint iWorkTotal, uint iWorkSoFar);

			/// <summary>Resets the timer.</summary>
			[Obsolete("This method is not supported.")]
			[PreserveSig]
			HRESULT ResetTimer();

			/// <summary>Pauses the timer.</summary>
			[Obsolete("This method is not supported.")]
			[PreserveSig]
			HRESULT PauseTimer();

			/// <summary>Resumes the timer.</summary>
			[Obsolete("This method is not supported.")]
			[PreserveSig]
			HRESULT ResumeTimer();
		}

		/// <summary>
		/// Extends the IFileDialog interface by adding methods specific to the save dialog, which include those that provide support for
		/// the collection of metadata to be persisted with the file.
		/// </summary>
		/// <seealso cref="IFileDialog"/>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("84bccd23-5fde-4cdb-aea4-af64b83d78ab"), CoClass(typeof(CFileSaveDialog))]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb775688")]
		public interface IFileSaveDialog : IFileDialog
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by canceling the operation.
			/// </returns>
			[PreserveSig]
			new HRESULT Show([Optional] HWND parent);

			/// <summary>Sets the file types that the dialog can open or save.</summary>
			/// <param name="cFileTypes">The number of elements in the array specified by rgFilterSpec.</param>
			/// <param name="rgFilterSpec">A pointer to an array of COMDLG_FILTERSPEC structures, each representing a file type.</param>
			new void SetFileTypes(uint cFileTypes,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] COMDLG_FILTERSPEC[] rgFilterSpec);

			/// <summary>Sets the file type that appears as selected in the dialog.</summary>
			/// <param name="iFileType">
			/// The index of the file type in the file type array passed to IFileDialog::SetFileTypes in its cFileTypes parameter. Note that
			/// this is a one-based index, not zero-based.
			/// </param>
			new void SetFileTypeIndex(uint iFileType);

			/// <summary>Gets the currently selected file type.</summary>
			/// <returns>
			/// A UINT value that receives the index of the selected file type in the file type array passed to IFileDialog::SetFileTypes in
			/// its cFileTypes parameter.
			/// </returns>
			new uint GetFileTypeIndex();

			/// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
			/// <param name="pfde">A pointer to an IFileDialogEvents implementation that will receive events from the dialog.</param>
			/// <returns>
			/// A DWORD value identiying this event handler. When the client is finished with the dialog, that client must call the
			/// IFileDialog::Unadvise method with this value.
			/// </returns>
			new uint Advise(IFileDialogEvents pfde);

			/// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
			/// <param name="dwCookie">
			/// The DWORD value that represents the event handler. This value is obtained through the pdwCookie parameter of the
			/// IFileDialog::Advise method.
			/// </param>
			new void Unadvise(uint dwCookie);

			/// <summary>Sets flags to control the behavior of the dialog.</summary>
			/// <param name="fos">One or more of the FILEOPENDIALOGOPTIONS values.</param>
			new void SetOptions(FILEOPENDIALOGOPTIONS fos);

			/// <summary>Gets the current flags that are set to control dialog behavior.</summary>
			/// <returns>
			/// When this method returns successfully, points to a value made up of one or more of the FILEOPENDIALOGOPTIONS values.
			/// </returns>
			new FILEOPENDIALOGOPTIONS GetOptions();

			/// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetDefaultFolder(IShellItem psi);

			/// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
			/// <param name="psi">A pointer to the interface that represents the folder.</param>
			new void SetFolder(IShellItem psi);

			/// <summary>
			/// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to
			/// be selected when the dialog is opened.
			/// </summary>
			/// <returns>The address of a pointer to the interface that represents the folder.</returns>
			new IShellItem GetFolder();

			/// <summary>Gets the user's current selection in the dialog.</summary>
			/// <returns>
			/// The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file
			/// or folder selected in the view window, or something that the user has entered into the dialog's edit box. The latter case
			/// may require a parsing operation (cancelable by the user) that blocks the current thread.
			/// </returns>
			new IShellItem GetCurrentSelection();

			/// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
			/// <param name="pszName">A pointer to the name of the file.</param>
			new void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);

			/// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
			/// <returns>The address of a pointer to a buffer that, when this method returns successfully, receives the text.</returns>
			new SafeCoTaskMemString GetFileName();

			/// <summary>Sets the title of the dialog.</summary>
			/// <param name="pszTitle">A pointer to a buffer that contains the title text.</param>
			new void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

			/// <summary>Sets the text of the Open or Save button.</summary>
			/// <param name="pszText">A pointer to a buffer that contains the button text.</param>
			new void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);

			/// <summary>Sets the text of the label next to the file name edit box.</summary>
			/// <param name="pszLabel">A pointer to a buffer that contains the label text.</param>
			new void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

			/// <summary>Gets the choice that the user made in the dialog.</summary>
			/// <returns>The address of a pointer to an IShellItem that represents the user's choice.</returns>
			new IShellItem GetResult();

			/// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
			/// <param name="psi">
			/// A pointer to an IShellItem that represents the folder to be made available to the user. This can only be a folder.
			/// </param>
			/// <param name="fdap">Specifies where the folder is placed within the list.</param>
			new void AddPlace(IShellItem psi, FDAP fdap);

			/// <summary>Sets the default extension to be added to file names.</summary>
			/// <param name="pszDefaultExtension">
			/// A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg"
			/// is correct, while ".jpg" is not.
			/// </param>
			new void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

			/// <summary>Closes the dialog.</summary>
			/// <param name="hr">The code that will be returned by Show to indicate that the dialog was closed before a selection was made.</param>
			new void Close([MarshalAs(UnmanagedType.Error)] HRESULT hr);

			/// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
			/// <param name="guid">The GUID to associate with this dialog state.</param>
			new void SetClientGuid(in Guid guid);

			/// <summary>Instructs the dialog to clear all persisted state information.</summary>
			new void ClearClientData();

			/// <summary>Sets the filter. <note>Deprecated. SetFilter is no longer available for use as of Windows 7.</note></summary>
			/// <param name="pFilter">A pointer to the IShellItemFilter that is to be set.</param>
			new void SetFilter([MarshalAs(UnmanagedType.Interface)] object pFilter);

			/// <summary>Sets an item to be used as the initial entry in a Save As dialog.</summary>
			/// <param name="psi">Pointer to an IShellItem that represents the item.</param>
			void SetSaveAsItem(IShellItem psi);

			/// <summary>Provides a property store that defines the default values to be used for the item being saved.</summary>
			/// <param name="pStore">Pointer to the interface that represents the property store that contains the associated metadata.</param>
			void SetProperties(PropSys.IPropertyStore pStore);

			/// <summary>Specifies which properties will be collected in the save dialog.</summary>
			/// <param name="pList">Pointer to the interface that represents the list of properties to collect. This parameter can be NULL.</param>
			/// <param name="fAppendDefault">
			/// TRUE to show default properties for the currently selected filetype in addition to the properties specified by pList. FALSE
			/// to show only properties specified by pList.
			/// </param>
			void SetCollectedProperties(PropSys.IPropertyDescriptionList pList, [MarshalAs(UnmanagedType.Bool)] bool fAppendDefault);

			/// <summary>Retrieves the set of property values for a saved item or an item in the process of being saved.</summary>
			/// <returns>Address of a pointer to an IPropertyStore that receives the property values.</returns>
			PropSys.IPropertyStore GetProperties();

			/// <summary>Applies a set of properties to an item using the Shell's copy engine.</summary>
			/// <param name="psi">
			/// Pointer to the IShellItem that represents the file being saved. This is usually the item retrieved by GetResult.
			/// </param>
			/// <param name="pStore">
			/// Pointer to the IPropertyStore that represents the property values to be applied to the file. This can be the property store
			/// returned by IFileSaveDialog::GetProperties.
			/// </param>
			/// <param name="hwnd">The handle of the application window.</param>
			/// <param name="pSink">
			/// Pointer to an optional IFileOperationProgressSink that the calling application can use if they want to be notified of the
			/// progress of the property stamping. This value may be NULL.
			/// </param>
			void ApplyProperties(IShellItem psi, PropSys.IPropertyStore pStore, HWND hwnd, IFileOperationProgressSink pSink);
		}

		/// <summary>Exposed methods to handle file sync operations between a local copy and a server copy of a file.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifilesyncmergehandler
		[ComImport, Guid("d97b5aac-c792-433c-975d-35c4eadc7a9d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IFileSyncMergeHandler
		{
			/// <summary>Merges changes between the local copy and server copy of a file.</summary>
			/// <param name="localFilePath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string containing the path to the local copy of the file.</para>
			/// </param>
			/// <param name="serverFilePath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>A pointer to a string containing the network path to the server copy of the file.</para>
			/// </param>
			/// <param name="updateStatus">
			/// <para>Type: <c>MERGE_UPDATE_STATUS*</c></para>
			/// <para>When this method returns, contains a pointer to one of the following values indicating status of the merge process.</para>
			/// <para>MUS_COMPLETE</para>
			/// <para>Indicates that the process has completed successfully.</para>
			/// <para>MUS_USERINPUTNEEDED</para>
			/// <para>Indicates that additional input is required by the user for the process to complete.</para>
			/// <para>MUS_FAILED</para>
			/// <para>Indicates that the process has failed.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesyncmergehandler-merge HRESULT Merge(
			// LPCWSTR localFilePath, LPCWSTR serverFilePath, MERGE_UPDATE_STATUS *updateStatus );
			void Merge([MarshalAs(UnmanagedType.LPWStr)] string localFilePath, [MarshalAs(UnmanagedType.LPWStr)] string serverFilePath, out MERGE_UPDATE_STATUS updateStatus);

			/// <summary>Displays a UI to resolve conflicts between the local copy and server copy of a file.</summary>
			/// <param name="localFilePath">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>The path of the file with the merge conflict.</para>
			/// </param>
			/// <param name="monitorToDisplayOn">
			/// <para>Type: <c>HMONITOR</c></para>
			/// <para>Indicates the monitor on which to display the UI.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesyncmergehandler-showresolveconflictuiasync
			// HRESULT ShowResolveConflictUIAsync( LPCWSTR localFilePath, HMONITOR monitorToDisplayOn );
			void ShowResolveConflictUIAsync([MarshalAs(UnmanagedType.LPWStr)] string localFilePath, HMONITOR monitorToDisplayOn);
		}

		/// <summary>Exposes a method that represents a modal window. This interface is used in the Windows XP Passport Wizard.</summary>
		[SuppressUnmanagedCodeSecurity]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "bb761686")]
		public interface IModalWindow
		{
			/// <summary>Launches the modal window.</summary>
			/// <param name="parent">The handle of the owner window. This value can be NULL.</param>
			/// <returns>
			/// If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following:
			/// HRESULT_FROM_WIN32(ERROR_CANCELLED) = The user closed the window by cancelling the operation.
			/// </returns>
			[PreserveSig]
			HRESULT Show([Optional] HWND parent);
		}

		/// <summary>Used generically to filter elements.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Shtypes.h", MSDNShortId = "bb773221")]
		public struct COMDLG_FILTERSPEC
		{
			/// <summary>A pointer to a buffer that contains the friendly name of the filter.</summary>
			public string pszName;

			/// <summary>A pointer to a buffer that contains the filter pattern.</summary>
			public string pszSpec;
		}

		/// <summary>Class interface for ITaskbarList and derivatives.</summary>
		[ComImport, Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7"), ClassInterface(ClassInterfaceType.None)]
		public class CFileOpenDialog { }

		/// <summary>Class interface for ITaskbarList and derivatives.</summary>
		[ComImport, Guid("C0B4E2F3-BA21-4773-8DBA-335EC946EB8B"), ClassInterface(ClassInterfaceType.None)]
		public class CFileSaveDialog { }
	}
}