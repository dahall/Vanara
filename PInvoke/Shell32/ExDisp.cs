// Work in progress, may not ever complete as it is so poorly supported anymore.

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/*
		/// <summary>Contains values used by the <c>IWebBrowser2::Navigate</c> and <c>IWebBrowser2::Navigate2</c> methods.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa768360(v=vs.85)
		[Guid("14EE5380-A378-11cf-A731-00A0C9082637"), PInvokeData("Exdisp.h")]
		[Flags]
		public enum BrowserNavConstants : uint
		{
			[Description("Open in new window")] navOpenInNewWindow = 0x0001,
			[Description("Exclude from history list")] navNoHistory = 0x0002,
			[Description("Don't read from cache")] navNoReadFromCache = 0x0004,
			[Description("Don't write from cache")] navNoWriteToCache = 0x0008,
			[Description("Try other sites on failure")] navAllowAutosearch = 0x0010,
			[Description("OpenBrowserBar")] navBrowserBar = 0x0020,
			[Description("Hyperlink")] navHyperlink = 0x0040,
			[Description("Enforce restricted zone")] navEnforceRestricted = 0x0080,
			[Description("Apply new window management")] navNewWindowsManaged = 0x0100,
			[Description("Untrusted download")] navUntrustedForDownload = 0x0200,
			[Description("Trusted for ActiveX prompt")] navTrustedForActiveX = 0x0400,
			[Description("Open in new tab")] navOpenInNewTab = 0x0800,
			[Description("Open in a background tab")] navOpenInBackgroundTab = 0x1000,
			[Description("Maintain the wordwheel text")] navKeepWordWheelText = 0x2000,
			[Description("Virtual tab across MIC levels")] navVirtualTab = 0x4000,
			[Description("Block x-domain redirects")] navBlockRedirectsXDomain = 0x8000,
			[Description("Force open in foreground tab")] navOpenNewForegroundTab = 0x10000,
			[Description("Travel Log nav with screenshot")] navTravelLogScreenshot = 0x20000,
			[Description("Defer unload of virtual tab")] navDeferUnload = 0x40000,
			[Description("Speculative navigate")] navSpeculative = 0x80000,
			[Description("Suggest open in new window")] navSuggestNewWindow = 0x100000,
			[Description("Suggest open in new tab")] navSuggestNewTab = 0x200000,
			[Description("Reserved")] navReserved1 = 0x400000,
			[Description("HP navigation")] navHomepageNavigate = 0x800000,
			[Description("Treat nav as refresh")] navRefresh = 0x1000000,
			[Description("Host initiated navigation")] navHostNavigation = 0x2000000,
			[Description("Reserved")] navReserved2 = 0x4000000,
			[Description("Reserved")] navReserved3 = 0x8000000,
			[Description("Reserved")] navReserved4 = 0x10000000,
			[Description("Reserved")] navReserved5 = 0x20000000,
			[Description("Reserved")] navReserved6 = 0x40000000,
			[Description("Reserved")] navReserved7 = 0x80000000,
		}

		/// <summary>Values used by the <c>DWebBrowserEvents2::CommandStateChange</c> event.</summary>
		/// <remarks>
		/// Windows Internet Explorer 8 <c>CSC_UPDATECOMMANDS</c> is defined as shown, with an <c>int</c> cast, as of Internet Explorer 8.
		/// For earlier versions of Windows Internet Explorer, the constant is defined as , without the cast.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa768361(v=vs.85)
		[Guid("34A226E0-DF30-11CF-89A9-00A0C9054129"), Description("Constants for WebBrowser CommandStateChange")]
		[PInvokeData("Exdisp.h")]
		[Flags]
		public enum CommandStateChangeConstants : uint
		{
			[Description("Command Change")] CSC_UPDATECOMMANDS = 0xFFFFFFFF,
			[Description("Navigate Forward")] CSC_NAVIGATEFORWARD = 0x00000001,
			[Description("Navigate Back")] CSC_NAVIGATEBACK = 0x00000002,
		}

		/// <summary>Flags passed to the <c>DWebBrowserEvents2::NewProcess</c> event that describe why a new process has been created.</summary>
		// https://msdn.microsoft.com/en-us/ie/cc304373(v=vs.94)
		[PInvokeData("Exdisp.h")]
		[Guid("A8317D46-03CB-4975-AE94-85E9F2E1D020")]
		public enum NewProcessCauseConstants
		{
			/// <summary>
			/// The browser determined that a new browser session was required under protected-mode rules. The session was created in a new,
			/// hidden, non-navigated process.
			/// </summary>
			ProtectedModeRedirect = 1
		}

		/// <summary>Contains values used with the Refresh2 and IWebBrowser2::Refresh2 methods.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/aa768363(v=vs.85)
		[PInvokeData("Exdisp.h")]
		[Guid("C317C261-A991-11cf-A731-00A0C9082637")]
		public enum RefreshConstants
		{
			[Description("Refresh normal")] REFRESH_NORMAL = 0,  //== OLECMDIDF_REFRESH_NORMAL
			[Description("Refresh if expired")] REFRESH_IFEXPIRED = 1,  //== OLECMDIDF_REFRESH_IFEXPIRED
			[Description("Refresh completely")] REFRESH_COMPLETELY = 3   //== OLECMDIDF_REFRESH_COMPLETELY
		}

		/// <summary>Contains values used by the SetSecureLockIcon event.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/bb268232(v=vs.85)
		[PInvokeData("Exdisp.h")]
		[Guid("65507BE0-91A8-11D3-A845-009027220E6D")]
		public enum SecureLockIconConstants
		{
			/// <summary>There is no security encryption present.</summary>
			secureLockIconUnsecure,
			/// <summary>There are multiple security encryption methods present.</summary>
			secureLockIconMixed,
			/// <summary>The security encryption level is not known.</summary>
			secureLockIconSecureUnknownBits,
			/// <summary>There is 40-bit security encryption present.</summary>
			secureLockIconSecure40Bit,
			/// <summary>There is 56-bit security encryption present.</summary>
			secureLockIconSecure56Bit,
			/// <summary>There is Fortezza security encryption present.</summary>
			secureLockIconSecureFortezza,
			/// <summary>There is 128-bit security encryption present.</summary>
			secureLockIconSecure128Bit
		}
		*/

		/// <summary>Specifies options for finding window in the Shell windows collection.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/exdisp/ne-exdisp-shellwindowfindwindowoptions typedef enum
		// ShellWindowFindWindowOptions { SWFO_NEEDDISPATCH, SWFO_INCLUDEPENDING, SWFO_COOKIEPASSED } ;
		[PInvokeData("exdisp.h", MSDNShortId = "2459ab16-56c0-4812-bc61-4a17978b04f3")]
		[Guid("7716A370-38CA-11D0-A48B-00A0C90A8F39")]
		public enum ShellWindowFindWindowOptions
		{
			/// <summary>Causes IShellWindows::FindWindowSW to interpret pvarLoc as a cookie rather than a PIDL.</summary>
			SWFO_COOKIEPASSED = 4,

			/// <summary>Include windows that were registered with IShellWindows::RegisterPending.</summary>
			SWFO_INCLUDEPENDING = 2,

			/// <summary>The window must have an IDispatch interface.</summary>
			SWFO_NEEDDISPATCH = 1
		}

		/// <summary>Specifies types of Shell windows.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/exdisp/ne-exdisp-shellwindowtypeconstants typedef enum
		// ShellWindowTypeConstants { SWC_EXPLORER, SWC_BROWSER, SWC_3RDPARTY, SWC_CALLBACK, SWC_DESKTOP } ;
		[PInvokeData("exdisp.h", MSDNShortId = "79d4fcf3-5256-4e21-ab9a-94605e1d742f")]
		[Guid("F41E6981-28E5-11D0-82B4-00A0C90C29C5")]
		public enum ShellWindowTypeConstants
		{
			/// <summary>A non-Microsoft browser window.</summary>
			SWC_3RDPARTY = 2,

			/// <summary>An Internet Explorer (Iexplore.exe) browser window.</summary>
			SWC_BROWSER = 1,

			/// <summary>A creation callback window.</summary>
			SWC_CALLBACK = 4,

			/// <summary>Windows Vista and later. The Windows desktop.</summary>
			SWC_DESKTOP = 8,

			/// <summary>An Windows Explorer (Explorer.exe) window.</summary>
			SWC_EXPLORER = 0
		}

		/*
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("55136806-B2DE-11D1-B9F2-00A0C98BC547")]
		public interface DShellNameSpaceEvents
		{
			[PreserveSig, DispId(1)]
			void FavoritesSelectionChange([In] int cItems, [In] int hItem, [In, MarshalAs(UnmanagedType.BStr)] string strName, [In, MarshalAs(UnmanagedType.BStr)] string strUrl, [In] int cVisits, [In, MarshalAs(UnmanagedType.BStr)] string strDate, [In, MarshalAs(UnmanagedType.Bool)] bool fAvailableOffline);

			[PreserveSig, DispId(2)]
			void SelectionChange();

			[PreserveSig, DispId(3)]
			void DoubleClick();

			[PreserveSig, DispId(4)]
			void Initialized();
		}

		[ComImport, Guid("FE4106E0-399A-11D0-A48C-00A0C90A8F39"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
		public interface DShellWindowsEvents
		{
			[PreserveSig, DispId(200)]
			void WindowRegistered([In] int lCookie);

			[PreserveSig, DispId(0xc9)]
			void WindowRevoked([In] int lCookie);
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B")]
		public interface DWebBrowserEvents
		{
			[PreserveSig, DispId(100)]
			void BeforeNavigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [Optional] int Flags, [MarshalAs(UnmanagedType.BStr), Optional] string TargetFrameName,
				[MarshalAs(UnmanagedType.Struct)] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

			[PreserveSig, DispId(0x65)]
			void NavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[PreserveSig, DispId(0x66)]
			void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

			[PreserveSig, DispId(0x6c)]
			void ProgressChange([In] int Progress, [In] int ProgressMax);

			[PreserveSig, DispId(0x68)]
			void DownloadComplete();

			[PreserveSig, DispId(0x69)]
			void CommandStateChange([In] CommandStateChangeConstants Command, [In, MarshalAs(UnmanagedType.VariantBool)] bool Enable);

			[PreserveSig, DispId(0x6a)]
			void DownloadBegin();

			[PreserveSig, DispId(0x6b)]
			void NewWindow([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
				[In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

			[PreserveSig, DispId(0x71)]
			void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

			[PreserveSig, DispId(200)]
			void FrameBeforeNavigate([In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
				[MarshalAs(UnmanagedType.Struct)] ref object PostData, [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

			[PreserveSig, DispId(0xc9)]
			void FrameNavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[PreserveSig, DispId(0xcc)]
			void FrameNewWindow([In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
				[In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Processed);

			[PreserveSig, DispId(0x67)]
			void Quit([In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);

			[PreserveSig, DispId(0x6d)]
			void WindowMove();

			[PreserveSig, DispId(110)]
			void WindowResize();

			[PreserveSig, DispId(0x6f)]
			void WindowActivate();

			[PreserveSig, DispId(0x70)]
			void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string Property);
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
		public interface DWebBrowserEvents2
		{
			[PreserveSig, DispId(0x66)]
			void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

			[PreserveSig, DispId(0x6c)]
			void ProgressChange([In] int Progress, [In] int ProgressMax);

			[PreserveSig, DispId(0x69)]
			void CommandStateChange([In] int Command, [In] bool Enable);

			[PreserveSig, DispId(0x6a)]
			void DownloadBegin();

			[PreserveSig, DispId(0x68)]
			void DownloadComplete();

			[PreserveSig, DispId(0x71)]
			void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);

			[PreserveSig, DispId(0x70)]
			void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string szProperty);

			[PreserveSig, DispId(250)]
			void BeforeNavigate2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, MarshalAs(UnmanagedType.Struct)] ref object Headers, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0xfb)]
			void NewWindow2([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0xfc)]
			void NavigateComplete2([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);

			[PreserveSig, DispId(0x103)]
			void DocumentComplete([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL);

			[PreserveSig, DispId(0xfd)]
			void OnQuit();

			[PreserveSig, DispId(0xfe)]
			void OnVisible([In] bool Visible);

			[PreserveSig, DispId(0xff)]
			void OnToolBar([In] bool ToolBar);

			[PreserveSig, DispId(0x100)]
			void OnMenuBar([In] bool MenuBar);

			[PreserveSig, DispId(0x101)]
			void OnStatusBar([In] bool StatusBar);

			[PreserveSig, DispId(0x102)]
			void OnFullScreen([In] bool FullScreen);

			[PreserveSig, DispId(260)]
			void OnTheaterMode([In] bool TheaterMode);

			[PreserveSig, DispId(0x106)]
			void WindowSetResizable([In] bool Resizable);

			[PreserveSig, DispId(0x108)]
			void WindowSetLeft([In] int Left);

			[PreserveSig, DispId(0x109)]
			void WindowSetTop([In] int Top);

			[PreserveSig, DispId(0x10a)]
			void WindowSetWidth([In] int Width);

			[PreserveSig, DispId(0x10b)]
			void WindowSetHeight([In] int Height);

			[PreserveSig, DispId(0x107)]
			void WindowClosing([In] bool IsChildWindow, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0x10c)]
			void ClientToHostWindow([In, Out] ref int CX, [In, Out] ref int CY);

			[PreserveSig, DispId(0x10d)]
			void SetSecureLockIcon([In] int SecureLockIcon);

			[PreserveSig, DispId(270)]
			void FileDownload([In] bool ActiveDocument, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0x10f)]
			void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, MarshalAs(UnmanagedType.Struct)] ref object Frame, [In, MarshalAs(UnmanagedType.Struct)] ref object StatusCode, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0xe1)]
			void PrintTemplateInstantiation([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);

			[PreserveSig, DispId(0xe2)]
			void PrintTemplateTeardown([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp);

			[PreserveSig, DispId(0xe3)]
			void UpdatePageStatus([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object nPage, [In, MarshalAs(UnmanagedType.Struct)] ref object fDone);

			[PreserveSig, DispId(0x110)]
			void PrivacyImpactedStateChange([In] bool bImpacted);

			[PreserveSig, DispId(0x111)]
			void NewWindow3([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out] ref bool Cancel, [In] uint dwFlags, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[PreserveSig, DispId(0x11a)]
			void SetPhishingFilterStatus([In] int PhishingFilterStatus);

			[PreserveSig, DispId(0x11b)]
			void WindowStateChanged([In] uint dwWindowStateFlags, [In] uint dwValidFlagsMask);

			[PreserveSig, DispId(0x11c)]
			void NewProcess([In] int lCauseFlag, [In, MarshalAs(UnmanagedType.IDispatch)] object pWB2, [In, Out] ref bool Cancel);

			[PreserveSig, DispId(0x11d)]
			void ThirdPartyUrlBlocked([In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In] uint dwCount);

			[PreserveSig, DispId(0x11e)]
			void RedirectXDomainBlocked([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In, MarshalAs(UnmanagedType.Struct)] ref object StartURL, [In, MarshalAs(UnmanagedType.Struct)] ref object RedirectURL, [In, MarshalAs(UnmanagedType.Struct)] ref object Frame, [In, MarshalAs(UnmanagedType.Struct)] ref object StatusCode);

			[PreserveSig, DispId(290)]
			void BeforeScriptExecute([In, MarshalAs(UnmanagedType.IDispatch)] object pDispWindow);

			[PreserveSig, DispId(0x120)]
			void WebWorkerStarted([In] uint dwUniqueID, [In, MarshalAs(UnmanagedType.BStr)] string bstrWorkerLabel);

			[PreserveSig, DispId(0x121)]
			void WebWorkerFinsihed([In] uint dwUniqueID);
		}

		[PInvokeData("ExDisp.h")]
		[ComImport, Guid("F3470F24-15FD-11D2-BB2E-00805FF7EFCA"), CoClass(typeof(CScriptErrorList))]
		public interface IScriptErrorList
		{
			[DispId(10)]
			void advanceError();

			[DispId(11)]
			void retreatError();

			[DispId(12)]
			int canAdvanceError();

			[DispId(13)]
			int canRetreatError();

			[DispId(14)]
			int getErrorLine();

			[DispId(15)]
			int getErrorChar();

			[DispId(0x10)]
			int getErrorCode();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x11)]
			string getErrorMsg();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x12)]
			string getErrorUrl();

			[DispId(0x17)]
			int getAlwaysShowLockState();

			[DispId(0x13)]
			int getDetailsPaneOpen();

			[DispId(20)]
			void setDetailsPaneOpen(int fDetailsPaneOpen);

			[DispId(0x15)]
			int getPerErrorDisplay();

			[DispId(0x16)]
			void setPerErrorDisplay(int fPerErrorDisplay);
		}

		[ComImport, Guid("55136804-B2DE-11D1-B9F2-00A0C98BC547"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
		public interface IShellFavoritesNameSpace
		{
			[DispId(1)]
			void MoveSelectionUp();

			[DispId(2)]
			void MoveSelectionDown();

			[DispId(3)]
			void ResetSort();

			[DispId(4)]
			void NewFolder();

			[DispId(5)]
			void Synchronize();

			[DispId(6)]
			void Import();

			[DispId(7)]
			void Export();

			[DispId(8)]
			void InvokeContextMenuCommand([In, MarshalAs(UnmanagedType.BStr)] string strCommand);

			[DispId(9)]
			void MoveSelectionTo();

			[DispId(10)]
			bool SubscriptionsEnabled { [DispId(10)] get; }

			[DispId(11)]
			bool CreateSubscriptionForSelection();

			[DispId(12)]
			bool DeleteSubscriptionForSelection();

			[DispId(13)]
			void SetRoot([In, MarshalAs(UnmanagedType.BStr)] string bstrFullPath);
		}

		[ComImport, Guid("E572D3C9-37BE-4AE2-825D-D521763E3108"), CoClass(typeof(ShellNameSpace))]
		public interface IShellNameSpace : IShellFavoritesNameSpace
		{
			[DispId(1)]
			void MoveSelectionUp();

			[DispId(2)]
			void MoveSelectionDown();

			[DispId(3)]
			void ResetSort();

			[DispId(4)]
			void NewFolder();

			[DispId(5)]
			void Synchronize();

			[DispId(6)]
			void Import();

			[DispId(7)]
			void Export();

			[DispId(8)]
			void InvokeContextMenuCommand([In, MarshalAs(UnmanagedType.BStr)] string strCommand);

			[DispId(9)]
			void MoveSelectionTo();

			[DispId(10)]
			bool SubscriptionsEnabled { [DispId(10)] get; }

			[DispId(11)]
			bool CreateSubscriptionForSelection();

			[DispId(12)]
			bool DeleteSubscriptionForSelection();

			[DispId(13)]
			void SetRoot([In, MarshalAs(UnmanagedType.BStr)] string bstrFullPath);

			[DispId(14)]
			int EnumOptions { [DispId(14)] get; [param: In] [DispId(14)] set; }

			[DispId(15)]
			object SelectedItem { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(15)] get; [param: In, MarshalAs(UnmanagedType.IDispatch)] [DispId(15)] set; }

			[DispId(0x10)]
			object Root { [return: MarshalAs(UnmanagedType.Struct)] [DispId(0x10)] get; [param: In, MarshalAs(UnmanagedType.Struct)] [DispId(0x10)] set; }

			[DispId(0x11)]
			int Depth { [DispId(0x11)] get; [param: In] [DispId(0x11)] set; }

			[DispId(0x12)]
			uint Mode { [DispId(0x12)] get; [param: In] [DispId(0x12)] set; }

			[DispId(0x13)]
			uint Flags { [DispId(0x13)] get; [param: In] [DispId(0x13)] set; }

			[DispId(20)]
			uint TVFlags { [DispId(20)] get; [param: In] [DispId(20)] set; }

			[DispId(0x15)]
			string Columns { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x15)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x15)] set; }

			[DispId(0x16)]
			int CountViewTypes { [DispId(0x16)] get; }

			[DispId(0x17)]
			void SetViewType([In] int iType);

			[return: MarshalAs(UnmanagedType.IDispatch)]
			[DispId(0x18)]
			object SelectedItems();

			[DispId(0x19)]
			void Expand([In, MarshalAs(UnmanagedType.Struct)] object var, int iDepth);

			[DispId(0x1a)]
			void UnselectAll();
		}

		[ComImport, Guid("729FE2F8-1EA8-11D1-8F85-00C04FC2FBE1")]
		public interface IShellUIHelper
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);
		}

		[ComImport, Guid("A7FE6EDA-1932-4281-B881-87B31B8BC52C")]
		public interface IShellUIHelper2 : IShellUIHelper
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();
		}

		[ComImport, Guid("528DF2EC-D419-40BC-9B6D-DCDBF9C1B25D")]
		public interface IShellUIHelper3 : IShellUIHelper2
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();
		}

		[ComImport, Guid("B36E6A53-8073-499E-824C-D776330A333E")]
		public interface IShellUIHelper4 : IShellUIHelper3
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();
		}

		[ComImport, Guid("A2A08B09-103D-4D3F-B91C-EA455CA82EFA")]
		public interface IShellUIHelper5 : IShellUIHelper4
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3e)]
			object msProvisionNetworks([In, MarshalAs(UnmanagedType.BStr)] string bstrProvisioningXml);

			[DispId(0x3f)]
			void msReportSafeUrl();

			[DispId(0x40)]
			void msSiteModeRefreshBadge();

			[DispId(0x41)]
			void msSiteModeClearBadge();

			[DispId(0x42)]
			void msDiagnoseConnectionUILess();

			[DispId(0x43)]
			void msLaunchNetworkClientHelp();

			[DispId(0x44)]
			void msChangeDefaultBrowser([In] bool fChange);
		}

		[ComImport, Guid("987A573E-46EE-4E89-96AB-DDF7F8FDC98C")]
		public interface IShellUIHelper6 : IShellUIHelper5
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3e)]
			object msProvisionNetworks([In, MarshalAs(UnmanagedType.BStr)] string bstrProvisioningXml);

			[DispId(0x3f)]
			void msReportSafeUrl();

			[DispId(0x40)]
			void msSiteModeRefreshBadge();

			[DispId(0x41)]
			void msSiteModeClearBadge();

			[DispId(0x42)]
			void msDiagnoseConnectionUILess();

			[DispId(0x43)]
			void msLaunchNetworkClientHelp();

			[DispId(0x44)]
			void msChangeDefaultBrowser([In] bool fChange);

			[DispId(0x45)]
			void msStopPeriodicTileUpdate();

			[DispId(70)]
			void msStartPeriodicTileUpdate([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x4b)]
			void msStartPeriodicTileUpdateBatch([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x47)]
			void msClearTile();

			[DispId(0x48)]
			void msEnableTileNotificationQueue([In] bool fChange);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x49)]
			object msPinnedSiteState();

			[DispId(0x4c)]
			void msEnableTileNotificationQueueForSquare150x150([In] bool fChange);

			[DispId(0x4d)]
			void msEnableTileNotificationQueueForWide310x150([In] bool fChange);

			[DispId(0x4e)]
			void msEnableTileNotificationQueueForSquare310x310([In] bool fChange);

			[DispId(0x4f)]
			void msScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationXml, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationTag, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object expirationTime);

			[DispId(80)]
			void msRemoveScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId);

			[DispId(0x51)]
			void msStartPeriodicBadgeUpdate([In, MarshalAs(UnmanagedType.BStr)] string pollingUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x52)]
			void msStopPeriodicBadgeUpdate();

			[DispId(0x4a)]
			void msLaunchInternetOptions();
		}

		[ComImport, Guid("60E567C8-9573-4AB2-A264-637C6C161CB1")]
		public interface IShellUIHelper7 : IShellUIHelper6
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3e)]
			object msProvisionNetworks([In, MarshalAs(UnmanagedType.BStr)] string bstrProvisioningXml);

			[DispId(0x3f)]
			void msReportSafeUrl();

			[DispId(0x40)]
			void msSiteModeRefreshBadge();

			[DispId(0x41)]
			void msSiteModeClearBadge();

			[DispId(0x42)]
			void msDiagnoseConnectionUILess();

			[DispId(0x43)]
			void msLaunchNetworkClientHelp();

			[DispId(0x44)]
			void msChangeDefaultBrowser([In] bool fChange);

			[DispId(0x45)]
			void msStopPeriodicTileUpdate();

			[DispId(70)]
			void msStartPeriodicTileUpdate([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x4b)]
			void msStartPeriodicTileUpdateBatch([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x47)]
			void msClearTile();

			[DispId(0x48)]
			void msEnableTileNotificationQueue([In] bool fChange);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x49)]
			object msPinnedSiteState();

			[DispId(0x4c)]
			void msEnableTileNotificationQueueForSquare150x150([In] bool fChange);

			[DispId(0x4d)]
			void msEnableTileNotificationQueueForWide310x150([In] bool fChange);

			[DispId(0x4e)]
			void msEnableTileNotificationQueueForSquare310x310([In] bool fChange);

			[DispId(0x4f)]
			void msScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationXml, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationTag, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object expirationTime);

			[DispId(80)]
			void msRemoveScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId);

			[DispId(0x51)]
			void msStartPeriodicBadgeUpdate([In, MarshalAs(UnmanagedType.BStr)] string pollingUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x52)]
			void msStopPeriodicBadgeUpdate();

			[DispId(0x4a)]
			void msLaunchInternetOptions();

			[DispId(0x55)]
			void SetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString, [In] bool vfFlag);

			[DispId(0x54)]
			bool GetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString);

			[DispId(0x56)]
			void SetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString, [In] uint dwValue);

			[DispId(0x57)]
			uint GetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString);

			[DispId(0x5c)]
			void ResetAllExperimentalFlagsAndValues();

			[DispId(0x59)]
			bool GetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(90)]
			void SetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool flag);

			[DispId(0x58)]
			bool HasNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(0x5b)]
			void LaunchIE([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool automated);
		}

		[ComImport, Guid("66DEBCF2-05B0-4F07-B49B-B96241A65DB2")]
		public interface IShellUIHelper8 : IShellUIHelper7
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3e)]
			object msProvisionNetworks([In, MarshalAs(UnmanagedType.BStr)] string bstrProvisioningXml);

			[DispId(0x3f)]
			void msReportSafeUrl();

			[DispId(0x40)]
			void msSiteModeRefreshBadge();

			[DispId(0x41)]
			void msSiteModeClearBadge();

			[DispId(0x42)]
			void msDiagnoseConnectionUILess();

			[DispId(0x43)]
			void msLaunchNetworkClientHelp();

			[DispId(0x44)]
			void msChangeDefaultBrowser([In] bool fChange);

			[DispId(0x45)]
			void msStopPeriodicTileUpdate();

			[DispId(70)]
			void msStartPeriodicTileUpdate([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x4b)]
			void msStartPeriodicTileUpdateBatch([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x47)]
			void msClearTile();

			[DispId(0x48)]
			void msEnableTileNotificationQueue([In] bool fChange);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x49)]
			object msPinnedSiteState();

			[DispId(0x4c)]
			void msEnableTileNotificationQueueForSquare150x150([In] bool fChange);

			[DispId(0x4d)]
			void msEnableTileNotificationQueueForWide310x150([In] bool fChange);

			[DispId(0x4e)]
			void msEnableTileNotificationQueueForSquare310x310([In] bool fChange);

			[DispId(0x4f)]
			void msScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationXml, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationTag, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object expirationTime);

			[DispId(80)]
			void msRemoveScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId);

			[DispId(0x51)]
			void msStartPeriodicBadgeUpdate([In, MarshalAs(UnmanagedType.BStr)] string pollingUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x52)]
			void msStopPeriodicBadgeUpdate();

			[DispId(0x4a)]
			void msLaunchInternetOptions();

			[DispId(0x55)]
			void SetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString, [In] bool vfFlag);

			[DispId(0x54)]
			bool GetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString);

			[DispId(0x56)]
			void SetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString, [In] uint dwValue);

			[DispId(0x57)]
			uint GetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString);

			[DispId(0x5c)]
			void ResetAllExperimentalFlagsAndValues();

			[DispId(0x59)]
			bool GetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(90)]
			void SetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool flag);

			[DispId(0x58)]
			bool HasNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(0x5b)]
			void LaunchIE([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool automated);

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5d)]
			string GetCVListData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5e)]
			string GetCVListLocalData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5f)]
			string GetEMIEListData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x60)]
			string GetEMIEListLocalData();

			[DispId(0x61)]
			void OpenFavoritesPane();

			[DispId(0x62)]
			void OpenFavoritesSettings();

			[DispId(0x63)]
			void LaunchInHVSI([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);
		}

		[ComImport, Guid("6CDF73B0-7F2F-451F-BC0F-63E0F3284E54"), CoClass(typeof(ShellUIHelper))]
		public interface IShellUIHelper9 : IShellUIHelper8
		{
			[DispId(1)]
			void ResetFirstBootMode();

			[DispId(2)]
			void ResetSafeMode();

			[DispId(3)]
			void RefreshOfflineDesktop();

			[DispId(4)]
			void AddFavorite([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Title);

			[DispId(5)]
			void AddChannel([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(6)]
			void AddDesktopComponent([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Type, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Left, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Top, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Width, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Height);

			[DispId(7)]
			bool IsSubscribed([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(8)]
			void NavigateAndFind([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string strQuery, [In, MarshalAs(UnmanagedType.Struct)] ref object varTargetFrame);

			[DispId(9)]
			void ImportExportFavorites([In] bool fImport, [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

			[DispId(10)]
			void AutoCompleteSaveForm([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Form);

			[DispId(11)]
			void AutoScan([In, MarshalAs(UnmanagedType.BStr)] string strSearch, [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarTargetFrame);

			[DispId(12)]
			void AutoCompleteAttach([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Reserved);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(13)]
			object ShowBrowserUI([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarIn);

			[DispId(14)]
			void AddSearchProvider([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(15)]
			void RunOnceShown();

			[DispId(0x10)]
			void SkipRunOnce();

			[DispId(0x11)]
			void CustomizeSettings([In] bool fSQM, [In] bool fPhishing, [In, MarshalAs(UnmanagedType.BStr)] string bstrLocale);

			[DispId(0x12)]
			bool SqmEnabled();

			[DispId(0x13)]
			bool PhishingEnabled();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(20)]
			string BrandImageUri();

			[DispId(0x15)]
			void SkipTabsWelcome();

			[DispId(0x16)]
			void DiagnoseConnection();

			[DispId(0x17)]
			void CustomizeClearType([In] bool fSet);

			[DispId(0x18)]
			uint IsSearchProviderInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x19)]
			bool IsSearchMigrated();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1a)]
			string DefaultSearchProvider();

			[DispId(0x1b)]
			void RunOnceRequiredSettingsComplete([In] bool fComplete);

			[DispId(0x1c)]
			bool RunOnceHasShown();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x1d)]
			string SearchGuideUrl();

			[DispId(30)]
			void AddService([In, MarshalAs(UnmanagedType.BStr)] string URL);

			[DispId(0x1f)]
			uint IsServiceInstalled([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Verb);

			[DispId(0x25)]
			bool InPrivateFilteringEnabled();

			[DispId(0x20)]
			void AddToFavoritesBar([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string Title, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Type);

			[DispId(0x21)]
			void BuildNewTabPage();

			[DispId(0x22)]
			void SetRecentlyClosedVisible([In] bool fVisible);

			[DispId(0x23)]
			void SetActivitiesVisible([In] bool fVisible);

			[DispId(0x24)]
			void ContentDiscoveryReset();

			[DispId(0x26)]
			bool IsSuggestedSitesEnabled();

			[DispId(0x27)]
			void EnableSuggestedSites([In] bool fEnable);

			[DispId(40)]
			void NavigateToSuggestedSites([In, MarshalAs(UnmanagedType.BStr)] string bstrRelativeUrl);

			[DispId(0x29)]
			void ShowTabsHelp();

			[DispId(0x2a)]
			void ShowInPrivateHelp();

			[DispId(0x2b)]
			bool msIsSiteMode();

			[DispId(0x2f)]
			void msSiteModeShowThumbBar();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x30)]
			object msSiteModeAddThumbBarButton([In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x2e)]
			void msSiteModeUpdateThumbBarButton([In, MarshalAs(UnmanagedType.Struct)] object ButtonID, [In] bool fEnabled, [In] bool fVisible);

			[DispId(0x2c)]
			void msSiteModeSetIconOverlay([In, MarshalAs(UnmanagedType.BStr)] string IconUrl, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarDescription);

			[DispId(0x2d)]
			void msSiteModeClearIconOverlay();

			[DispId(0x31)]
			void msAddSiteMode();

			[DispId(0x33)]
			void msSiteModeCreateJumpList([In, MarshalAs(UnmanagedType.BStr)] string bstrHeader);

			[DispId(0x34)]
			void msSiteModeAddJumpListItem([In, MarshalAs(UnmanagedType.BStr)] string bstrName, [In, MarshalAs(UnmanagedType.BStr)] string bstrActionUri, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarWindowType);

			[DispId(0x35)]
			void msSiteModeClearJumpList();

			[DispId(0x38)]
			void msSiteModeShowJumpList();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x36)]
			object msSiteModeAddButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.BStr)] string bstrIconURL, [In, MarshalAs(UnmanagedType.BStr)] string bstrTooltip);

			[DispId(0x37)]
			void msSiteModeShowButtonStyle([In, MarshalAs(UnmanagedType.Struct)] object uiButtonID, [In, MarshalAs(UnmanagedType.Struct)] object uiStyleID);

			[DispId(0x3a)]
			void msSiteModeActivate();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3b)]
			object msIsSiteModeFirstRun([In] bool fPreserveState);

			[DispId(0x39)]
			void msAddTrackingProtectionList([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, MarshalAs(UnmanagedType.BStr)] string bstrFilterName);

			[DispId(60)]
			bool msTrackingProtectionEnabled();

			[DispId(0x3d)]
			bool msActiveXFilteringEnabled();

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x3e)]
			object msProvisionNetworks([In, MarshalAs(UnmanagedType.BStr)] string bstrProvisioningXml);

			[DispId(0x3f)]
			void msReportSafeUrl();

			[DispId(0x40)]
			void msSiteModeRefreshBadge();

			[DispId(0x41)]
			void msSiteModeClearBadge();

			[DispId(0x42)]
			void msDiagnoseConnectionUILess();

			[DispId(0x43)]
			void msLaunchNetworkClientHelp();

			[DispId(0x44)]
			void msChangeDefaultBrowser([In] bool fChange);

			[DispId(0x45)]
			void msStopPeriodicTileUpdate();

			[DispId(70)]
			void msStartPeriodicTileUpdate([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x4b)]
			void msStartPeriodicTileUpdateBatch([In, MarshalAs(UnmanagedType.Struct)] object pollingUris, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x47)]
			void msClearTile();

			[DispId(0x48)]
			void msEnableTileNotificationQueue([In] bool fChange);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x49)]
			object msPinnedSiteState();

			[DispId(0x4c)]
			void msEnableTileNotificationQueueForSquare150x150([In] bool fChange);

			[DispId(0x4d)]
			void msEnableTileNotificationQueueForWide310x150([In] bool fChange);

			[DispId(0x4e)]
			void msEnableTileNotificationQueueForSquare310x310([In] bool fChange);

			[DispId(0x4f)]
			void msScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationXml, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId, [In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationTag, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object expirationTime);

			[DispId(80)]
			void msRemoveScheduledTileNotification([In, MarshalAs(UnmanagedType.BStr)] string bstrNotificationId);

			[DispId(0x51)]
			void msStartPeriodicBadgeUpdate([In, MarshalAs(UnmanagedType.BStr)] string pollingUri, [In, Optional, MarshalAs(UnmanagedType.Struct)] object startTime, [In, Optional, MarshalAs(UnmanagedType.Struct)] object uiUpdateRecurrence);

			[DispId(0x52)]
			void msStopPeriodicBadgeUpdate();

			[DispId(0x4a)]
			void msLaunchInternetOptions();

			[DispId(0x55)]
			void SetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString, [In] bool vfFlag);

			[DispId(0x54)]
			bool GetExperimentalFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrFlagString);

			[DispId(0x56)]
			void SetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString, [In] uint dwValue);

			[DispId(0x57)]
			uint GetExperimentalValue([In, MarshalAs(UnmanagedType.BStr)] string bstrValueString);

			[DispId(0x5c)]
			void ResetAllExperimentalFlagsAndValues();

			[DispId(0x59)]
			bool GetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(90)]
			void SetNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool flag);

			[DispId(0x58)]
			bool HasNeedIEAutoLaunchFlag([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(0x5b)]
			void LaunchIE([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] bool automated);

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5d)]
			string GetCVListData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5e)]
			string GetCVListLocalData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x5f)]
			string GetEMIEListData();

			[return: MarshalAs(UnmanagedType.BStr)]
			[DispId(0x60)]
			string GetEMIEListLocalData();

			[DispId(0x61)]
			void OpenFavoritesPane();

			[DispId(0x62)]
			void OpenFavoritesSettings();

			[DispId(0x63)]
			void LaunchInHVSI([In, MarshalAs(UnmanagedType.BStr)] string bstrUrl);

			[DispId(0x67)]
			uint GetOSSku();
		}
		*/

		/// <summary>Provides access to the collection of open Shell windows.</summary>
		/// <remarks>
		/// <para>
		/// A Shell window is a window that has been registered by calling IShellWindows::Register or IShellWindows::RegisterPending. Upon
		/// registration, the specified window is added to the collection of Shell windows, and granted a cookie that uniquely identifies the
		/// window within the collection. A window can be un-registered by calling IShellWindows::Revoke.
		/// </para>
		/// <para>
		/// The Shell windows collection includes file explorer windows and web browser windows Internet Explorer and 3rd-party web
		/// browsers). Normally each Shell window implements IDispatch; IShellWindows::Item and IShellWindows::FindWindowSW provide ways to
		/// access a Shell window's <c>IDispatch</c> interface. For more information, see Dispatch Interface and Automation Functions.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>IID</term>
		/// <term>IID_IShellWindows (85CB6900-4D95-11CF-960C-0080C7F4EE85)</term>
		/// </listheader>
		/// <item>
		/// <term>CLSID</term>
		/// <term>CLSID_ShellWindows (9BA05972-F6A8-11CF-A442-00A0C90A8F39)</term>
		/// </item>
		/// </list>
		/// <para>The following example shows how to retrieve an <c>IShellWindows</c> instance.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/exdisp/nn-exdisp-ishellwindows
		[PInvokeData("exdisp.h", MSDNShortId = "e609c8b6-2b2e-4188-894c-5c85960206ea")]
		[ComImport, Guid("85CB6900-4D95-11CF-960C-0080C7F4EE85"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), CoClass(typeof(ShellWindows))]
		public interface IShellWindows
		{
			/// <summary>Gets the number of windows in the Shell windows collection.</summary>
			/// <value>Returns a <see cref="int"/> value.</value>
			[DispId(0x60020000)]
			int Count { [DispId(0x60020000)] get; }

			/// <summary>Returns the registered Shell window for a specified index.</summary>
			/// <param name="index">
			/// A VARIANT of type VT_UI4, VT_I2, or VT_I4. If the type is VT_UI4, the value of index is interpreted as a member of
			/// ShellWindowTypeConstants; in this case, Item returns the window that is closest to the foreground window and has a matching
			/// type. If the type is VT_I, or VT_I4, index is treated as an index into the Shell windows collection.
			/// </param>
			/// <returns>A reference to the window's IDispatch interface, or NULL if the specified window was not found.</returns>
			[return: MarshalAs(UnmanagedType.IDispatch)]
			[DispId(0)]
			object Item([In, Optional, MarshalAs(UnmanagedType.Struct)] object index);

			/// <summary>Retrieves an enumerator for the collection of Shell windows.</summary>
			/// <returns>When this method returns, contains an interface pointer to an object that implements the IEnumVARIANT interface.</returns>
			[DispId(-4)]
			IEnumVARIANT GetEnumerator();

			/// <summary>Registers an open window as a Shell window; the window is specified by handle.</summary>
			/// <param name="pid">The window's IDispatch interface.</param>
			/// <param name="HWND">A handle that specifies the window to register.</param>
			/// <param name="swClass">A member of ShellWindowTypeConstants that specifies the type of window.</param>
			/// <returns>The window's cookie.</returns>
			[DispId(0x60020003)]
			int Register([In, MarshalAs(UnmanagedType.IDispatch)] object pid, [In] int HWND, [In] ShellWindowTypeConstants swClass);

			/// <summary>Registers a pending window as a Shell window; the window is specified by an absolute PIDL.</summary>
			/// <param name="lThreadId">TBD</param>
			/// <param name="pvarloc">
			/// A VARIANT of type VT_VARIANT | VT_BYREF. Set the value of pvarloc to an absolute PIDL (PIDLIST_ABSOLUTE) that specifies the
			/// window to register.
			/// </param>
			/// <param name="pvarlocRoot">Must be NULL or of type VT_EMPTY.</param>
			/// <param name="swClass">A member of ShellWindowTypeConstants that specifies the type of window.</param>
			/// <returns>The window's cookie.</returns>
			[DispId(0x60020004)]
			int RegisterPending([In] int lThreadId, [In, MarshalAs(UnmanagedType.Struct)] in object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] in object pvarlocRoot, [In] ShellWindowTypeConstants swClass);

			/// <summary>Revokes a Shell window's registration and removes the window from the Shell windows collection.</summary>
			/// <param name="lCookie">The cookie that identifies the window to un-register.</param>
			[DispId(0x60020005)]
			void Revoke([In] int lCookie);

			/// <summary>Occurs when a Shell window is navigated to a new location.</summary>
			/// <param name="lCookie">The cookie that identifies the window.</param>
			/// <param name="pvarloc">
			/// A VARIANT of type VT_VARIANT | VT_BYREF. Set the value of pvarLoc to an absolute PIDL (PIDLIST_ABSOLUTE) that specifies the
			/// new location.
			/// </param>
			[DispId(0x60020006)]
			void OnNavigate([In] int lCookie, [In, MarshalAs(UnmanagedType.Struct)] ref object pvarloc);

			/// <summary>Occurs when a Shell window's activation state changes.</summary>
			/// <param name="lCookie">The cookie that identifies the window.</param>
			/// <param name="fActive">TRUE if the window is being activated; FALSE if the window is being deactivated.</param>
			[DispId(0x60020007)]
			void OnActivated([In] int lCookie, [In] bool fActive);

			/// <summary>Finds a window in the Shell windows collection and returns the window's handle and IDispatch interface.</summary>
			/// <param name="pvarloc">
			/// A VARIANT of type VT_VARIANT | VT_BYREF. Set the value of pvarLoc to an absolute PIDL (PIDLIST_ABSOLUTE) that specifies the
			/// window to find. (See remarks.)
			/// </param>
			/// <param name="pvarlocRoot">Must be NULL or of type VT_EMPTY.</param>
			/// <param name="swClass">One or more ShellWindowTypeConstants flags that specify window types to include in the search.</param>
			/// <param name="pHWND">A handle for the window matching the specified search criteria, or NULL if no such window was found.</param>
			/// <param name="swfwOptions">One or more ShellWindowFindWindowOptions flags that specify search options.</param>
			/// <returns>A reference to the window's IDispatch interface, or NULL if no such window was found.</returns>
			[return: MarshalAs(UnmanagedType.IDispatch)]
			[DispId(0x60020008)]
			object FindWindowSW([In, MarshalAs(UnmanagedType.Struct)] in object pvarloc, [In, MarshalAs(UnmanagedType.Struct)] in object pvarlocRoot, [In] ShellWindowTypeConstants swClass, out int pHWND, [In] ShellWindowFindWindowOptions swfwOptions);

			/// <summary>Occurs when a new Shell window is created for a frame.</summary>
			/// <param name="lCookie">The cookie that identifies the window.</param>
			/// <param name="punk">The address of the new window's IUnknown interface.</param>
			[DispId(0x60020009)]
			void OnCreated([In] int lCookie, [In, MarshalAs(UnmanagedType.IUnknown)] object punk);

			/// <summary>Deprecated. Always returns S_OK.</summary>
			/// <param name="fAttach">Not used.</param>
			[DispId(0x6002000a), Obsolete]
			void ProcessAttachDetach([In] bool fAttach);
		}

		/*
		[ComImport, Guid("EAB22AC1-30C1-11CF-A7EB-0000C05BAE0B"), CoClass(typeof(WebBrowser_V1))]
		public interface IWebBrowser
		{
			[DispId(100)]
			void GoBack();

			[DispId(0x65)]
			void GoForward();

			[DispId(0x66)]
			void GoHome();

			[DispId(0x67)]
			void GoSearch();

			[DispId(0x68)]
			void Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Headers);

			[DispId(-550)]
			void Refresh();

			[DispId(0x69)]
			void Refresh2([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Level);

			[DispId(0x6a)]
			void Stop();

			[DispId(200)]
			object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }

			[DispId(0xc9)]
			object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }

			[DispId(0xca)]
			object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }

			[DispId(0xcb)]
			object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }

			[DispId(0xcc)]
			bool TopLevelContainer { [DispId(0xcc)] get; }

			[DispId(0xcd)]
			string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }

			[DispId(0xce)]
			int Left { [DispId(0xce)] get; [param: In] [DispId(0xce)] set; }

			[DispId(0xcf)]
			int Top { [DispId(0xcf)] get; [param: In] [DispId(0xcf)] set; }

			[DispId(0xd0)]
			int Width { [DispId(0xd0)] get; [param: In] [DispId(0xd0)] set; }

			[DispId(0xd1)]
			int Height { [DispId(0xd1)] get; [param: In] [DispId(0xd1)] set; }

			[DispId(210)]
			string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }

			[DispId(0xd3)]
			string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }

			[DispId(0xd4)]
			bool Busy { [DispId(0xd4)] get; }
		}

		[ComImport, Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"), CoClass(typeof(WebBrowser)), CoClass(typeof(ShellBrowserWindow))]
		public interface IWebBrowser2 : IWebBrowserApp
		{
			[DispId(100)]
			void GoBack();

			[DispId(0x65)]
			void GoForward();

			[DispId(0x66)]
			void GoHome();

			[DispId(0x67)]
			void GoSearch();

			[DispId(0x68)]
			void Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Headers);

			[DispId(-550)]
			void Refresh();

			[DispId(0x69)]
			void Refresh2([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Level);

			[DispId(0x6a)]
			void Stop();

			[DispId(200)]
			object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }

			[DispId(0xc9)]
			object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }

			[DispId(0xca)]
			object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }

			[DispId(0xcb)]
			object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }

			[DispId(0xcc)]
			bool TopLevelContainer { [DispId(0xcc)] get; }

			[DispId(0xcd)]
			string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }

			[DispId(0xce)]
			int Left { [DispId(0xce)] get; [param: In] [DispId(0xce)] set; }

			[DispId(0xcf)]
			int Top { [DispId(0xcf)] get; [param: In] [DispId(0xcf)] set; }

			[DispId(0xd0)]
			int Width { [DispId(0xd0)] get; [param: In] [DispId(0xd0)] set; }

			[DispId(0xd1)]
			int Height { [DispId(0xd1)] get; [param: In] [DispId(0xd1)] set; }

			[DispId(210)]
			string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }

			[DispId(0xd3)]
			string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }

			[DispId(0xd4)]
			bool Busy { [DispId(0xd4)] get; }

			[DispId(300)]
			void Quit();

			[DispId(0x12d)]
			void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);

			[DispId(0x12e)]
			void PutProperty([In, MarshalAs(UnmanagedType.BStr)] string Property, [In, MarshalAs(UnmanagedType.Struct)] object vtValue);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x12f)]
			object GetProperty([In, MarshalAs(UnmanagedType.BStr)] string Property);

			[DispId(0)]
			string Name { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }

			[DispId(-515)]
			int HWND { [DispId(-515)] get; }

			[DispId(400)]
			string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(400)] get; }

			[DispId(0x191)]
			string Path { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x191)] get; }

			[DispId(0x192)]
			bool Visible { [DispId(0x192)] get; [param: In] [DispId(0x192)] set; }

			[DispId(0x193)]
			bool StatusBar { [DispId(0x193)] get; [param: In] [DispId(0x193)] set; }

			[DispId(0x194)]
			string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] set; }

			[DispId(0x195)]
			int ToolBar { [DispId(0x195)] get; [param: In] [DispId(0x195)] set; }

			[DispId(0x196)]
			bool MenuBar { [DispId(0x196)] get; [param: In] [DispId(0x196)] set; }

			[DispId(0x197)]
			bool FullScreen { [DispId(0x197)] get; [param: In] [DispId(0x197)] set; }

			[DispId(500)]
			void Navigate2([In, MarshalAs(UnmanagedType.Struct)] ref object URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Headers);

			[DispId(0x1f5)]
			OLECMDF QueryStatusWB([In] OLECMDID cmdID);

			[DispId(0x1f6)]
			void ExecWB([In] OLECMDID cmdID, [In] OLECMDEXECOPT cmdexecopt, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvaIn, [In, Out, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvaOut);

			[DispId(0x1f7)]
			void ShowBrowserBar([In, MarshalAs(UnmanagedType.Struct)] ref object pvaClsid, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarShow, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object pvarSize);

			[DispId(-525)]
			tagREADYSTATE ReadyState { [DispId(-525), TypeLibFunc(4)] get; }

			[DispId(550)]
			bool Offline { [DispId(550)] get; [param: In] [DispId(550)] set; }

			[DispId(0x227)]
			bool Silent { [DispId(0x227)] get; [param: In] [DispId(0x227)] set; }

			[DispId(0x228)]
			bool RegisterAsBrowser { [DispId(0x228)] get; [param: In] [DispId(0x228)] set; }

			[DispId(0x229)]
			bool RegisterAsDropTarget { [DispId(0x229)] get; [param: In] [DispId(0x229)] set; }

			[DispId(0x22a)]
			bool TheaterMode { [DispId(0x22a)] get; [param: In] [DispId(0x22a)] set; }

			[DispId(0x22b)]
			bool AddressBar { [DispId(0x22b)] get; [param: In] [DispId(0x22b)] set; }

			[DispId(0x22c)]
			bool Resizable { [DispId(0x22c)] get; [param: In] [DispId(0x22c)] set; }
		}

		[ComImport, Guid("0002DF05-0000-0000-C000-000000000046")]
		public interface IWebBrowserApp : IWebBrowser
		{
			[DispId(100)]
			void GoBack();

			[DispId(0x65)]
			void GoForward();

			[DispId(0x66)]
			void GoHome();

			[DispId(0x67)]
			void GoSearch();

			[DispId(0x68)]
			void Navigate([In, MarshalAs(UnmanagedType.BStr)] string URL, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Flags, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object TargetFrameName, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object PostData, [In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Headers);

			[DispId(-550)]
			void Refresh();

			[DispId(0x69)]
			void Refresh2([In, Optional, MarshalAs(UnmanagedType.Struct)] ref object Level);

			[DispId(0x6a)]
			void Stop();

			[DispId(200)]
			object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }

			[DispId(0xc9)]
			object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }

			[DispId(0xca)]
			object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }

			[DispId(0xcb)]
			object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }

			[DispId(0xcc)]
			bool TopLevelContainer { [DispId(0xcc)] get; }

			[DispId(0xcd)]
			string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }

			[DispId(0xce)]
			int Left { [DispId(0xce)] get; [param: In] [DispId(0xce)] set; }

			[DispId(0xcf)]
			int Top { [DispId(0xcf)] get; [param: In] [DispId(0xcf)] set; }

			[DispId(0xd0)]
			int Width { [DispId(0xd0)] get; [param: In] [DispId(0xd0)] set; }

			[DispId(0xd1)]
			int Height { [DispId(0xd1)] get; [param: In] [DispId(0xd1)] set; }

			[DispId(210)]
			string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }

			[DispId(0xd3)]
			string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }

			[DispId(0xd4)]
			bool Busy { [DispId(0xd4)] get; }

			[DispId(300)]
			void Quit();

			[DispId(0x12d)]
			void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);

			[DispId(0x12e)]
			void PutProperty([In, MarshalAs(UnmanagedType.BStr)] string Property, [In, MarshalAs(UnmanagedType.Struct)] object vtValue);

			[return: MarshalAs(UnmanagedType.Struct)]
			[DispId(0x12f)]
			object GetProperty([In, MarshalAs(UnmanagedType.BStr)] string Property);

			[DispId(0)]
			string Name { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }

			[DispId(-515)]
			int HWND { [DispId(-515)] get; }

			[DispId(400)]
			string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(400)] get; }

			[DispId(0x191)]
			string Path { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x191)] get; }

			[DispId(0x192)]
			bool Visible { [DispId(0x192)] get; [param: In] [DispId(0x192)] set; }

			[DispId(0x193)]
			bool StatusBar { [DispId(0x193)] get; [param: In] [DispId(0x193)] set; }

			[DispId(0x194)]
			string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] get; [param: In, MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] set; }

			[DispId(0x195)]
			int ToolBar { [DispId(0x195)] get; [param: In] [DispId(0x195)] set; }

			[DispId(0x196)]
			bool MenuBar { [DispId(0x196)] get; [param: In] [DispId(0x196)] set; }

			[DispId(0x197)]
			bool FullScreen { [DispId(0x197)] get; [param: In] [DispId(0x197)] set; }
		}

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("EFD01300-160F-11D2-BB2E-00805FF7EFCA")]
		public class CScriptErrorList { }

		[ComImport, ClassInterface(ClassInterfaceType.None), ComSourceInterfaces("Vanara.PInvoke.Shell32.DWebBrowserEvents2\0Vanara.PInvoke.Shell32.DWebBrowserEvents\0"), Guid("0002DF01-0000-0000-C000-000000000046")]
		public class InternetExplorer { }

		[ComImport, ComSourceInterfaces("Vanara.PInvoke.Shell32.DWebBrowserEvents2\0Vanara.PInvoke.Shell32.DWebBrowserEvents\0"), Guid("D5E8041D-920F-45E9-B8FB-B1DEB82C6E5E"), ClassInterface(ClassInterfaceType.None)]
		public class InternetExplorerMedium { }

		[ComImport, Guid("C08AFD90-F2A1-11D1-8455-00A0C91F3880"), ComSourceInterfaces("Vanara.PInvoke.Shell32.DWebBrowserEvents2\0Vanara.PInvoke.Shell32.DWebBrowserEvents\0"), ClassInterface(ClassInterfaceType.None)]
		public class ShellBrowserWindow { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("55136805-B2DE-11D1-B9F2-00A0C98BC547"), ComSourceInterfaces("Vanara.PInvoke.Shell32.DShellNameSpaceEvents\0")]
		public class ShellNameSpace { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1")]
		public class ShellUIHelper { }
		*/

		/// <summary>CoClass for IShellWindows</summary>
		[ComImport, Guid("9BA05972-F6A8-11CF-A442-00A0C90A8F39"), ClassInterface(ClassInterfaceType.None)]
		public class ShellWindows { }

		/*
		[ComImport, ComSourceInterfaces("Vanara.PInvoke.Shell32.DWebBrowserEvents2\0Vanara.PInvoke.Shell32.DWebBrowserEvents\0"), Guid("8856F961-340A-11D0-A96B-00C04FD705A2"), ClassInterface(ClassInterfaceType.None)]
		public class WebBrowser { }

		[ComImport, ClassInterface(ClassInterfaceType.None), Guid("EAB22AC3-30C1-11CF-A7EB-0000C05BAE0B"), ComSourceInterfaces("Vanara.PInvoke.Shell32.DWebBrowserEvents\0Vanara.PInvoke.Shell32.DWebBrowserEvents2\0")]
		public class WebBrowser_V1 { }
		*/
	}
}