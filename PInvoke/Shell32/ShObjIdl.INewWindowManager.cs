namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Flags used by INewWindowManager::EvaluateNewWindow. These values are factors in the decision of whether to display a pop-up window.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-nwmf typedef enum NWMF { NWMF_UNLOADING,
	// NWMF_USERINITED, NWMF_FIRST, NWMF_OVERRIDEKEY, NWMF_SHOWHELP, NWMF_HTMLDIALOG, NWMF_FROMDIALOGCHILD, NWMF_USERREQUESTED,
	// NWMF_USERALLOWED, NWMF_FORCEWINDOW, NWMF_FORCETAB, NWMF_SUGGESTWINDOW, NWMF_SUGGESTTAB, NWMF_INACTIVETAB } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.NWMF")]
	public enum NWMF
	{
		/// <summary>
		/// The page is unloading. This flag is set in response to the onbeforeunload and onunload events. Some pages load pop-up
		/// windows when you leave them, not when you enter. This flag is used to identify those situations.
		/// </summary>
		NWMF_UNLOADING = 0x1,

		/// <summary>
		/// The call to INewWindowManager::EvaluateNewWindow is the result of a user-initiated action (a mouse click or key press). Use
		/// this flag in conjunction with the NWMF_FIRST_USERINITED flag to determine whether the call is a direct or indirect result of
		/// the user-initiated action.
		/// </summary>
		NWMF_USERINITED = 0x2,

		/// <summary>
		/// When NWMF_USERINITED is present, this flag indicates that the call to INewWindowManager::EvaluateNewWindow is the first
		/// query that results from this user-initiated action. Always use this flag in conjunction with NWMF_USERINITED.
		/// </summary>
		NWMF_FIRST = 0x4,

		/// <summary>
		/// The override key (ALT) was pressed. The override key is used to bypass the pop-up manager—allowing all pop-up windows to
		/// display—and must be held down at the time that INewWindowManager::EvaluateNewWindow is called.
		/// </summary>
		NWMF_OVERRIDEKEY = 0x8,

		/// <summary>
		/// The new window attempting to load is the result of a call to the showHelp method. Help is sometimes displayed in a separate
		/// window, and this flag is valuable in those cases.
		/// </summary>
		NWMF_SHOWHELP = 0x10,

		/// <summary>The new window is a dialog box that displays HTML content.</summary>
		NWMF_HTMLDIALOG = 0x20,

		/// <summary>
		/// The EvaluateNewWindow method is being called from an HTML dialog. The new window should not show the UI in the parent window.
		/// </summary>
		NWMF_FROMDIALOGCHILD = 0x40,

		/// <summary>
		/// The new windows was definitely requested by the user, either by selecting Open in New Window from a context menu or pressing
		/// Shift and clicking a link.
		/// </summary>
		NWMF_USERREQUESTED = 0x80,

		/// <summary>The call to the EvaluateNewWindow method is the result of the user requesting a replay that resulted in a refresh.</summary>
		NWMF_USERALLOWED = 0x100,

		/// <summary>The new window should be forced to open in a new window rather than a tab.</summary>
		NWMF_FORCEWINDOW = 0x10000,

		/// <summary>The new window should be forced to open in a new tab.</summary>
		NWMF_FORCETAB = 0x20000,

		/// <summary>
		/// The new window should open in a new tab unless NWMF_FORCEtab is also present, indicating that user wants the window to open
		/// as a window.
		/// </summary>
		NWMF_SUGGESTWINDOW = 0x40000,

		/// <summary>
		/// The new window should open in a new tab unless NWMF_FORCEWINDOW is also present, indicating that user wants the window to
		/// open as a window.
		/// </summary>
		NWMF_SUGGESTTAB = 0x80000,

		/// <summary>The EvaluateNewWindow method is being called from an inactive tab.</summary>
		NWMF_INACTIVETAB = 0x100000,
	}

	/// <summary>
	/// Exposes a method that determines whether a window that is launched by another window should be displayed or blocked, allowing
	/// control of pop-up windows.
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>
	/// Implement <c>INewWindowManager</c> when your application hosts a WebBrowser control and you want to include pop-up management functionality.
	/// </para>
	/// <para>
	/// When you implement <c>INewWindowManager</c>, you can override some or all of the Windows Internet Explorer pop-up blocking
	/// logic. To use the default Internet Explorer pop-up blocking logic, implement INewWindowManager::EvaluateNewWindow to return
	/// E_FAIL. This instructs the WebBrowser control to use the default Internet Explorer implementation. Alternately, the application
	/// hosting the WebBrowser control can call CoInternetSetFeatureEnabled with the <c>FEATURE_WEBOC_POPUPMANAGEMENT</c> flag for the
	/// same result.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-inewwindowmanager
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.INewWindowManager")]
	[ComImport, Guid("D2BC4C84-3F72-4a52-A604-7BCBF3982CBB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface INewWindowManager
	{
		/// <summary>
		/// Accepts data about a new window that is attempting to display and determines whether that window should be allowed to open
		/// based on the user's preferences.
		/// </summary>
		/// <param name="pszUrl">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a buffer that contains the URL of the content that will be displayed in the new window.</para>
		/// </param>
		/// <param name="pszName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a buffer that contains the name of the new window. This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pszUrlContext">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a buffer that contains the URL that has issued the command to open the new window.</para>
		/// </param>
		/// <param name="pszFeatures">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>A pointer to a buffer that contains the feature string for the new window. This value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="fReplace">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A boolean value used when the new content specified in pszUrl is loaded into the existing window instead of creating a new
		/// one. <c>TRUE</c> if the new document should replace the current document in the history list; <c>FALSE</c> if the new
		/// document should be given a new entry.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A flag or flags from the NWMF enumeration that provide situational information about the call to open the new window. This
		/// value can be 0 if no flags are needed.
		/// </para>
		/// </param>
		/// <param name="dwUserActionTime">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The tick count when the last user action occurred. To find out how long ago the action occurred, call GetTickCount and
		/// compare the result with the value in this parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns standard error codes, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Allow display of the window.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Block display of the window.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>
		/// When you implement INewWindowManager for a hosted WebBrowser control, this value instructs the WebBrowser control to use the
		/// default implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-inewwindowmanager-evaluatenewwindow HRESULT
		// EvaluateNewWindow( LPCWSTR pszUrl, LPCWSTR pszName, LPCWSTR pszUrlContext, LPCWSTR pszFeatures, BOOL fReplace, DWORD dwFlags,
		// DWORD dwUserActionTime );
		[PreserveSig]
		HRESULT EvaluateNewWindow([MarshalAs(UnmanagedType.LPWStr)] string pszUrl, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszName,
			[MarshalAs(UnmanagedType.LPWStr)] string pszUrlContext, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszFeatures,
			[MarshalAs(UnmanagedType.Bool)] bool fReplace, NWMF dwFlags, uint dwUserActionTime);
	}
}