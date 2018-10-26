using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>
		/// Indicate flags used by IExplorerPaneVisibility::GetPaneState to get the current state of the given Windows Explorer pane.
		/// </summary>
		[Flags]
		[PInvokeData("Shobjidl.h", MSDNShortId = "4caa2fe7-5bb3-4940-a429-fd32128eea84")]
		public enum EXPLORERPANESTATE
		{
			/// <summary>Do not make any modifications to the pane.</summary>
			EPS_DONTCARE = 0x0000,

			/// <summary>Set the default state of the pane to "on", but respect any user-modified persisted state.</summary>
			EPS_DEFAULT_ON = 0x0001,

			/// <summary>Set the default state of the pane to "off".</summary>
			EPS_DEFAULT_OFF = 0x0002,

			/// <summary>Unused.</summary>
			EPS_STATEMASK = 0xFFFF,

			/// <summary>Ignore any persisted state from the user, but the user can still modify the state.</summary>
			EPS_INITIALSTATE = 0x00010000,

			/// <summary>
			/// Users cannot modify the state, that is, they do not have the ability to show or hide the given pane. This option implies EPS_INITIALSTATE.
			/// </summary>
			EPS_FORCE = 0x00020000,
		}

		/// <summary>
		/// Used in Windows Explorer by an IShellFolder implementation to give suggestions to the view about what panes are visible.
		/// Additionally, an IExplorerBrowser host can use this interface to provide information about pane visibility. The host should
		/// implement QueryService with SID_ExplorerPaneVisibility as the service ID. The host must be in the site chain.
		/// <para>
		/// The IExplorerPaneVisibility implementation is retrieved from the Shell folder.The Shell folder, in turn, is retrieved from the
		/// view.A namespace extension can elect to provide a custom view(IShellView) rather than using the system folder view object
		/// (DefView). In that case, the IShellView implementation must include an implementation of IFolderView::GetFolder to return the
		/// IExplorerPaneVisibility object.
		/// </para>
		/// <para>
		/// A namespace extension can provide a custom view by implementing IShellView itself rather than using the system folder view object
		/// (DefView). In that case, the IShellView implementation must include an implementation of IFolderView::GetFolder to make use of IExplorerPaneVisibility.
		/// </para>
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e07010ec-bc17-44c0-97b0-46c7c95b9edc")]
		[PInvokeData("Shobjidl.h", MSDNShortId = "b940adc2-dfef-49c5-b86c-d0da83db0aad")]
		public interface IExplorerPaneVisibility
		{
			/// <summary>
			/// <para>Gets the visibility state of the given Windows Explorer pane.</para>
			/// </summary>
			/// <param name="ep">
			/// <para>Type: <c>REFEXPLORERPANE</c></para>
			/// <para>
			/// A reference to a GUID that uniquely identifies a Windows Explorer pane. One of the following constants as defined in Shlguid.h.
			/// </para>
			/// <para>EP_NavPane (cb316b22-25f7-42b8-8a09-540d23a43c2f)</para>
			/// <para>The pane on the left side of the Windows Explorer window that hosts the folders tree and <c>Favorites</c>.</para>
			/// <para>EP_Commands (d9745868-ca5f-4a76-91cd-f5a129fbb076)</para>
			/// <para><c>Commands</c> module along the top of the Windows Explorer window.</para>
			/// <para>EP_Commands_Organize (72e81700-e3ec-4660-bf24-3c3b7b648806)</para>
			/// <para><c>Organize</c> menu within the commands module.</para>
			/// <para>EP_Commands_View (21f7c32d-eeaa-439b-bb51-37b96fd6a943)</para>
			/// <para><c>View</c> menu within the commands module.</para>
			/// <para>EP_DetailsPane (43abf98b-89b8-472d-b9ce-e69b8229f019)</para>
			/// <para>Pane showing metadata along the bottom of the Windows Explorer window.</para>
			/// <para>EP_PreviewPane (893c63d1-45c8-4d17-be19-223be71be365)</para>
			/// <para>Pane on the right of the Windows Explorer window that shows a large reading preview of the file.</para>
			/// <para>EP_QueryPane (65bcde4f-4f07-4f27-83a7-1afca4df7ddd)</para>
			/// <para>Quick filter buttons to aid in a search.</para>
			/// <para>EP_AdvQueryPane (b4e9db8b-34ba-4c39-b5cc-16a1bd2c411c)</para>
			/// <para>Additional fields and options to aid in a search.</para>
			/// <para>EP_StatusBar (65fe56ce-5cfe-4bc4-ad8a-7ae3fe7e8f7c)</para>
			/// <para><c>Introduced in Windows 8</c>: A status bar that indicates the progress of some process, such as copying or downloading.</para>
			/// <para>EP_Ribbon (d27524a8-c9f2-4834-a106-df8889fd4f37)</para>
			/// <para>
			/// <c>Introduced in Windows 8</c>: The ribbon, which is the control that replaced menus and toolbars at the top of many
			/// Microsoft applications.
			/// </para>
			/// </param>
			/// <param name="peps">
			/// <para>Type: <c>EXPLORERPANESTATE*</c></para>
			/// <para>
			/// When this method returns, contains the visibility state of the given Windows Explorer pane as one of the EXPLORERPANESTATE constants.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// If the implementer does not care about the state of a given pane and therefore does not want to change it, then the
			/// implementer should return a success code for the method and EPS_DONTCARE for the parameter. If the method fails, it is
			/// treated as if EPS_DONTCARE was returned for the parameter.
			/// </remarks>
			[PInvokeData("shobjidl_core.h", MSDNShortId = "6c051cdc-b7f9-48dc-ba32-38f0f1ee5fda")]
			[PreserveSig]
			HRESULT GetPaneState(in Guid ep, ref EXPLORERPANESTATE peps);
		}

		/// <summary>Constant GUIDs used by IExplorerPaneVisibility::GetPaneState.</summary>
		public static class IExplorerPaneVisibilityConstants
		{
			/// <summary>Additional fields and options to aid in a search.</summary>
			public readonly static Guid EP_AdvQueryPane = new Guid("{b4e9db8b-34ba-4c39-b5cc-16a1bd2c411c}");

			/// <summary>Commands module along the top of the Windows Explorer window.</summary>
			public readonly static Guid EP_Commands = new Guid("{d9745868-ca5f-4a76-91cd-f5a129fbb076}");

			/// <summary>Organize menu within the commands module.</summary>
			public readonly static Guid EP_Commands_Organize = new Guid("{72e81700-e3ec-4660-bf24-3c3b7b648806}");

			/// <summary>View menu within the commands module.</summary>
			public readonly static Guid EP_Commands_View = new Guid("{21f7c32d-eeaa-439b-bb51-37b96fd6a943}");

			/// <summary>Pane showing metadata along the bottom of the Windows Explorer window.</summary>
			public readonly static Guid EP_DetailsPane = new Guid("{43abf98b-89b8-472d-b9ce-e69b8229f019}");

			/// <summary>The pane on the left side of the Windows Explorer window that hosts the folders tree and Favorites.</summary>
			public readonly static Guid EP_NavPane = new Guid("{cb316b22-25f7-42b8-8a09-540d23a43c2f}");

			/// <summary>Pane on the right of the Windows Explorer window that shows a large reading preview of the file.</summary>
			public readonly static Guid EP_PreviewPane = new Guid("{893c63d1-45c8-4d17-be19-223be71be365}");

			/// <summary>Quick filter buttons to aid in a search.</summary>
			public readonly static Guid EP_QueryPane = new Guid("{65bcde4f-4f07-4f27-83a7-1afca4df7ddd}");

			/// <summary>
			/// Introduced in Windows 8: The ribbon, which is the control that replaced menus and toolbars at the top of many Microsoft applications.
			/// </summary>
			public readonly static Guid EP_Ribbon = new Guid("{D27524A8-C9F2-4834-A106-DF8889FD4F37}");

			/// <summary>Introduced in Windows 8: A status bar that indicates the progress of some process, such as copying or downloading.</summary>
			public readonly static Guid EP_StatusBar = new Guid("{65fe56ce-5cfe-4bc4-ad8a-7ae3fe7e8f7c}");
		}
	}
}