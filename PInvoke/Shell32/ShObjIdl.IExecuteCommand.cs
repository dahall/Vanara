using System;
using System.Drawing;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Exposes methods that set a given state or parameter related to the command verb, as well as a method to invoke that verb.
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>
		/// Implement this interface when you choose it as your method to invoke the verb to perform an action on selected items. The items
		/// are passed as a Shell item array through IObjectWithSelection::SetSelection, so the object must also implement IObjectWithSelection.
		/// </para>
		/// <para>When to Use</para>
		/// <para>
		/// Do not call the methods of <c>IExecuteCommand</c> directly. Windows Explorer calls your <c>IExecuteCommand</c> methods when the
		/// user wants to perform an action on the items.
		/// </para>
		/// <para>
		/// Note that, apart from Execute, the methods of this interface pass system information to the handler. The system itself calls
		/// these methods, setting the parameters appropriately based on system settings and conditions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iexecutecommand
		[PInvokeData("shobjidl_core.h", MSDNShortId = "a3432f1a-dd33-4e0d-8b26-1312bb5151f7")]
		[ComImport, Guid("7F9185B0-CB92-43c5-80A9-92277A4F7B54"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IExecuteCommand
		{
			/// <summary>Sets a value based on the current state of the keys CTRL and SHIFT.</summary>
			/// <param name="grfKeyState">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>One or both of the following flags to indicate whether the key is pressed.</para>
			/// <para>MK_CONTROL</para>
			/// <para>The CTRL key is pressed.</para>
			/// <para>MK_SHIFT</para>
			/// <para>The SHIFT key is pressed.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setkeystate HRESULT
			// SetKeyState( DWORD grfKeyState );
			[PreserveSig]
			HRESULT SetKeyState(User32.MouseButtonState grfKeyState);

			/// <summary>Provides parameter values for the verb.</summary>
			/// <param name="pszParameters">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a string that contains parameter values. The format and contents of this string is determined by the verb that is
			/// to be invoked.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setparameters HRESULT
			// SetParameters( LPCWSTR pszParameters );
			[PreserveSig]
			HRESULT SetParameters([In, MarshalAs(UnmanagedType.LPWStr)] string pszParameters);

			/// <summary>Sets the coordinates of a point used for display.</summary>
			/// <param name="pt">
			/// <para>Type: <c>POINT</c></para>
			/// <para>
			/// The screen coordinates at which the user right-clicked to invoke the shortcut menu from which a command was chosen.
			/// Applications can use this information to present any UI. This is particularly useful in a multi-monitor situation. The
			/// default position is the center of the default monitor.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setposition HRESULT
			// SetPosition( POINT pt );
			[PreserveSig]
			HRESULT SetPosition(Point pt);

			/// <summary>Sets the specified window's visual state.</summary>
			/// <param name="nShow">
			/// <para>Type: <c>int</c></para>
			/// <para>One of the following flags to indicate how the window is to be shown.</para>
			/// <para>SW_HIDE</para>
			/// <para>Hides the window and activates another window.</para>
			/// <para>SW_MAXIMIZE</para>
			/// <para>Maximizes the specified window.</para>
			/// <para>SW_MINIMIZE</para>
			/// <para>Minimizes the specified window and activates the next top-level window in the z-order.</para>
			/// <para>SW_RESTORE</para>
			/// <para>
			/// Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and
			/// position. An application should specify this flag when restoring a minimized window.
			/// </para>
			/// <para>SW_SHOW</para>
			/// <para>Activates the window and displays it in its current size and position.</para>
			/// <para>SW_SHOWDEFAULT</para>
			/// <para>
			/// Sets the show state based on the information specified in the STARTUPINFO structure passed to the CreateProcess function that
			/// started the application. An application should call ShowWindow with this flag to set the initial visual state of its main window.
			/// </para>
			/// <para>SW_SHOWMAXIMIZED</para>
			/// <para>Activates the window and displays it as a maximized window.</para>
			/// <para>SW_SHOWMINIMIZED</para>
			/// <para>Activates the window and displays it as a minimized window.</para>
			/// <para>SW_SHOWMINNOACTIVE</para>
			/// <para>Displays the window as a minimized window. The active window remains active.</para>
			/// <para>SW_SHOWNA</para>
			/// <para>Displays the window in its current state. The active window remains active.</para>
			/// <para>SW_SHOWNOACTIVATE</para>
			/// <para>Displays a window in its most recent size and position. The active window remains active.</para>
			/// <para>SW_SHOWNORMAL</para>
			/// <para>
			/// Default state. Activates and displays a window. If the window is minimized or maximized, Windows restores it to its original
			/// size and position. An application should specify this flag when it displays the window for the first time.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setshowwindow HRESULT
			// SetShowWindow( int nShow );
			[PreserveSig]
			HRESULT SetShowWindow(ShowWindowCommand nShow);

			/// <summary>Indicates whether any UI associated with the selected Shell item should be displayed.</summary>
			/// <param name="fNoShowUI">
			/// <para>Type: <c>BOOL</c></para>
			/// <para><c>TRUE</c> to block display of any associated UI; <c>FALSE</c> to display the UI. <c>FALSE</c> is the default value.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setnoshowui HRESULT
			// SetNoShowUI( BOOL fNoShowUI );
			[PreserveSig]
			HRESULT SetNoShowUI([MarshalAs(UnmanagedType.Bool)] bool fNoShowUI);

			/// <summary>Sets a new working directory.</summary>
			/// <param name="pszDirectory">
			/// <para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated string with the fully qualified path of the new working directory. If this value is <c>NULL</c>,
			/// the current working directory is used.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-setdirectory HRESULT
			// SetDirectory( LPCWSTR pszDirectory );
			[PreserveSig]
			HRESULT SetDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pszDirectory);

			/// <summary>Invoke the verb on the selected items. Call this method after you have called the other methods of this interface.</summary>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iexecutecommand-execute HRESULT Execute( );
			[PreserveSig]
			HRESULT Execute();
		}

		/// <summary>
		/// Exposes a single method used to initialize objects that implement IExplorerCommandState, IExecuteCommand or IDropTarget with the
		/// application-specified command name and its registered properties.
		/// </summary>
		/// <remarks>
		/// <para>When to Implement</para>
		/// <para>Implement <c>IInitializeCommand</c> in the following situations.</para>
		/// <list type="bullet">
		///   <item>
		///     <term>
		/// Implement this interface to differentiate between related commands that share implementations of IExplorerCommandState,
		/// IDropTarget or IExecuteCommand. Differentiation is made through the command name passed in IInitializeCommand::Initialize.
		/// Commands can also use <c>Initialize</c> to pass a specific property bag for the command, using properties the command has placed
		/// in the registry.
		/// </term>
		///   </item>
		/// </list>
		/// <para>When to Use</para>
		/// <para>
		/// Do not call the method of <c>IInitializeCommand</c> directly. Windows Explorer calls this method when a verb object that
		/// implements this interface is invoked.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-iinitializecommand
		[PInvokeData("shobjidl_core.h", MSDNShortId = "e5a2a4d3-2488-4da2-aaab-c27461859d9f")]
		[ComImport, Guid("85075acf-231f-40ea-9610-d26b7b58f638"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IInitializeCommand
		{
			/// <summary>
			/// Initialize objects that share an implementation of IExplorerCommandState, IExecuteCommand or IDropTarget with the
			/// application-specified command name and its registered properties.
			/// </summary>
			/// <param name="pszCommandName"><para>Type: <c>LPCWSTR</c></para>
			/// <para>
			/// Pointer to a string that contains the command name (the name of the command key as found in the registry). For instance, if
			/// the command is registered under <c>...</c>&lt;b&gt;shell&lt;b&gt;MyCommand, pszCommandName points to "MyCommand".
			/// </para></param>
			/// <param name="ppb"><para>Type: <c>IPropertyBag*</c></para>
			/// <para>
			/// Pointer to an IPropertyBag instance that can be used to read the properties related to the command in the registry. For
			/// example, a command may registry a string property under its <c>...</c>&lt;b&gt;shell&lt;b&gt;MyCommand subkey.
			/// </para></param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-iinitializecommand-initialize
			// HRESULT Initialize( LPCWSTR pszCommandName, IPropertyBag *ppb );
			[PreserveSig]
			HRESULT Initialize([In, MarshalAs(UnmanagedType.LPWStr)] string pszCommandName, [In] IPropertyBag ppb);
		}
	}
}