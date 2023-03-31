using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class Shell32Methods
{
	[Test]
	public void CommandLineToArgvWTest()
	{
		const string cmd = "-d -s \"Str\" --hog";
		var h = CommandLineToArgvW(cmd, out var c);
		Assert.That(h.IsInvalid, Is.False);
		Assert.That(c, Is.EqualTo(4));
		Assert.That(h.ToStringEnum(c, System.Runtime.InteropServices.CharSet.Unicode), Is.Not.Empty);
		Assert.That(h.ToStringEnum(c, System.Runtime.InteropServices.CharSet.Unicode).First(), Is.EqualTo("-d"));

		Assert.That(CommandLineToArgvW(cmd).First(), Is.EqualTo("-d"));
		TestContext.WriteLine(string.Join(" | ", CommandLineToArgvW(cmd)));
	}

	//[Test]
	public void AssocCreateForClassesTest()
	{
		Assert.Fail("Not implemented.");
		//Assert.That(AssocCreateForClasses(), Is.Zero);
	}

	//[Test]
	public void AssocGetDetailsOfPropKeyTest()
	{
		Assert.Fail("Not implemented.");
		//Assert.That(AssocGetDetailsOfPropKey(), Is.Zero);
	}

	[Test]
	public void SHGetDesktopFolderTest()
	{
		Assert.That(SHGetDesktopFolder(out var sf), ResultIs.Successful);
		foreach (var sub in sf.EnumObjects())
		{
			string name = null;
			Assert.That(() => name = sf.GetDisplayNameOf(SHGDNF.SHGDN_NORMAL | SHGDNF.SHGDN_INFOLDER, sub), Throws.Nothing);
			TestContext.WriteLine(name);
		}
		Marshal.ReleaseComObject(sf);
	}

	[Test]
	public void SHEmptyRecycleBinTest()
	{
		// Create temp file and delete it to recycle bin
		var file = new TempFile();
		var ishi = SHCreateItemFromParsingName<IShellItem>(file.FullName);
		IFileOperation op = new();
		op.DeleteItem(ishi, default);
		op.PerformOperations();

		// Empty bin
		Assert.That(SHEmptyRecycleBin(default, "C:\\", SHERB.SHERB_NOCONFIRMATION | SHERB.SHERB_NOPROGRESSUI | SHERB.SHERB_NOSOUND), ResultIs.Successful);
	}

	[Test]
	public void EnumRecycleBinTest()
	{
		// Get IShellFolder for Desktop
		SHGetDesktopFolder(out var iDesktop).ThrowIfFailed();
		using var pDesktop = ComReleaserFactory.Create(iDesktop);

		// Get IShellFolder for Recycle Bin
		SHGetKnownFolderIDList(KNOWNFOLDERID.FOLDERID_RecycleBinFolder.Guid(), KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT, default, out var pIDL).ThrowIfFailed();
		using var pBin = ComReleaserFactory.Create(pDesktop.Item.BindToObject<IShellFolder>(pIDL));

		// Enum all items in bin
		foreach (var childPidl in pBin.Item.EnumObjects())
		{
			using var pItem = ComReleaserFactory.Create(SHCreateItemFromIDList<IShellItem>(childPidl));
			// use pItem.Item to access methods of IShellItem
			TestContext.WriteLine(pItem.Item.GetDisplayName(SIGDN.SIGDN_NORMALDISPLAY).ToString());
		}
	}

	//[Test]
	// Always fails
	public void IShellMenuTest()
	{
		Ole32.CoCreateInstance(typeof(MenuBand).GUID, default, Ole32.CLSCTX.CLSCTX_INPROC_SERVER, typeof(IShellMenu).GUID, out var ppv).ThrowIfFailed();
		using var ishmenu = ComReleaserFactory.Create(ppv as IShellMenu);
		Assert.IsNotNull(ishmenu.Item);
	}

	/*
	AssocCreateForClasses
	AssocGetDetailsOfPropKey
	CDefFolderMenu_Create2
	DragAcceptFiles
	DragFinish
	DragQueryFile
	DragQueryPoint
	DuplicateIcon
	ExtractAssociatedIcon
	ExtractAssociatedIconEx
	ExtractIcon
	ExtractIconEx
	FindExecutable
	GetCurrentProcessExplicitAppUserModelID
	GetFileNameFromBrowse
	InitNetworkAddressControl
	IsNetDrive
	IsUserAnAdmin
	OpenRegStream
	PathCleanupSpec
	PathGetShortPath
	PathIsExe
	PathIsSlow
	PathMakeUniqueName
	PathResolve
	PathYetAnotherMakeUniqueName
	PickIconDlg
	PifMgr_CloseProperties
	PifMgr_GetProperties
	PifMgr_OpenProperties
	PifMgr_SetProperties
	ReadCabinetState
	RealDriveType
	RestartDialog
	RestartDialogEx
	SetCurrentProcessExplicitAppUserModelID
	SHAddDefaultPropertiesByExt
	SHAddFromPropSheetExtArray
	SHAddToRecentDocs
	SHAlloc
	SHAppBarMessage
	SHAssocEnumHandlers
	SHAssocEnumHandlersForProtocolByApplication
	SHBindToFolderIDListParent
	SHBindToFolderIDListParentEx
	SHBindToObject
	SHBindToParent
	SHBrowseForFolder
	SHChangeNotification_Lock
	SHChangeNotification_Unlock
	SHChangeNotify
	SHChangeNotifyDeregister
	SHChangeNotifyRegister
	SHChangeNotifyRegisterThread
	SHCreateAssociationRegistration
	SHCreateDataObject
	SHCreateDefaultContextMenu
	SHCreateDefaultExtractIcon
	SHCreateDefaultPropertiesOp
	SHCreateDirectory
	SHCreateDirectoryEx
	SHCreateFileExtractIconW
	SHCreateItemFromIDList
	SHCreateItemFromParsingName
	SHCreateItemFromRelativeName
	SHCreateItemInKnownFolder
	SHCreateItemWithParent
	SHCreatePropSheetExtArray
	SHCreateShellFolderView
	SHCreateShellFolderViewEx
	SHCreateShellItem
	SHCreateShellItemArray
	SHCreateShellItemArrayFromDataObject
	SHCreateShellItemArrayFromIDLists
	SHCreateShellItemArrayFromShellItem
	SHCreateStdEnumFmtEtc
	SHDefExtractIcon
	SHDestroyPropSheetExtArray
	SHDoDragDrop
	Shell_GetCachedImageIndex
	Shell_GetImageLists
	Shell_MergeMenus
	Shell_NotifyIcon
	Shell_NotifyIconGetRect
	ShellAbout
	ShellExecute
	ShellExecuteEx
	SHEmptyRecycleBin
	SHEnumerateUnreadMailAccountsA
	SHEnumerateUnreadMailAccountsW
	SHEvaluateSystemCommandTemplate
	SHFileOperation
	SHFind_InitMenuPopup
	SHFindFiles
	SHFlushSFCache
	SHFormatDrive
	SHFree
	SHFreeNameMappings
	SHGetAttributesFromDataObject
	SHGetDataFromIDList
	SHGetDiskFreeSpaceA
	SHGetDiskFreeSpaceEx
	SHGetDiskFreeSpaceW
	SHGetDriveMedia
	SHGetFileInfo
	SHGetFolderLocation
	SHGetFolderPath
	SHGetFolderPathAndSubDir
	SHGetFolderPathEx
	SHGetIconOverlayIndex
	SHGetIDListFromObject
	SHGetImageList
	SHGetInstanceExplorer
	SHGetItemFromDataObject
	SHGetItemFromObject
	SHGetKnownFolderIDList
	SHGetKnownFolderItem
	SHGetKnownFolderPath
	SHGetLocalizedName
	SHGetNameFromIDList
	SHGetNewLinkInfo
	SHGetPathFromIDList
	SHGetPathFromIDListEx
	SHGetPropertyStoreForWindow
	SHGetPropertyStoreFromIDList
	SHGetPropertyStoreFromParsingName
	SHGetRealIDL
	SHGetSetFolderCustomSettings
	SHGetSetSettings
	SHGetSettings
	SHGetStockIconInfo
	SHGetTemporaryPropertyForItem
	SHGetUnreadMailCountW
	SHHandleUpdateImage
	SHInvokePrinterCommand
	SHIsFileAvailableOffline
	SHLimitInputEdit
	SHLoadInProc
	SHLoadNonloadedIconOverlayIdentifiers
	SHMapPIDLToSystemImageListIndex
	SHMultiFileProperties
	SHObjectProperties
	SHOpenFolderAndSelectItems
	SHOpenWithDialog
	SHParseDisplayName
	SHPathPrepareForWrite
	SHPropStgCreate
	SHPropStgReadMultiple
	SHPropStgWriteMultiple
	SHQueryRecycleBin
	SHQueryUserNotificationState
	SHRemoveLocalizedName
	SHReplaceFromPropSheetExtArray
	SHResolveLibrary
	SHRestricted
	SHSetDefaultProperties
	SHSetInstanceExplorer
	SHSetKnownFolderPath
	SHSetLocalizedName
	SHSetTemporaryPropertyForItem
	SHSetUnreadMailCountW
	SHShellFolderView_Message
	SHShowManageLibraryUI
	SHSimpleIDListFromPath
	SHTestTokenMembership
	SHUpdateImage
	SHValidateUNC
	SignalFileOpen
	StgMakeUniqueName
	Win32DeleteFile
	WriteCabinetState
	*/
}
