using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>A basic implementation of IShellBrowser, IOleCommandTarget and ICommDlgBrowser.</summary>
	/// <remarks>
	///   <para>This implementation used a <see cref="ShellView" /> to implement:</para>
	///   <list type="bullet">
	///     <item>BrowseObject</item>
	///     <item>GetWindow</item>
	///     <item>OnDefaultCommand</item>
	///     <item>OnStateChange</item>
	///   </list>
	/// </remarks>
	/// <seealso cref="IShellBrowser" />
	/// <seealso cref="IOleCommandTarget" />
	/// <seealso cref="Shell32.IServiceProvider" />
	/// <seealso cref="ICommDlgBrowser" />
	[ComVisible(true), ClassInterface(ClassInterfaceType.None)]
	internal class ShellBrowser : IShellBrowser, IOleCommandTarget, Shell32.IServiceProvider, ICommDlgBrowser
	{
		/// <summary>The <see cref="ShellView"/> instance from initialization.</summary>
		protected readonly ShellView shellView;

		/// <summary>Initializes a new instance of the <see cref="ShellBrowser"/> class with a <see cref="ShellView"/> instance.</summary>
		/// <param name="view">The <see cref="ShellView"/> instance.</param>
		/// <exception cref="ArgumentNullException">view</exception>
		public ShellBrowser(ShellView view) => shellView = view ?? throw new ArgumentNullException(nameof(view));

		/// <summary>Gets or sets the progress bar associated with the view.</summary>
		/// <value>The progress bar.</value>
		public ProgressBar ProgressBar { get; set; }

#if NETFRAMEWORK || NETCOREAPP3_0
		/// <summary>Gets or sets the status bar associated with the view.</summary>
		/// <value>The status bar.</value>
		public StatusBar StatusBar { get; set; }

		/// <summary>Gets or sets the tool bar associated with the view.</summary>
		/// <value>The tool bar.</value>
		public ToolBar ToolBar { get; set; }
#endif

		/// <summary>Gets or sets the TreeView associated with the view.</summary>
		/// <value>The TreeView.</value>
		public TreeView TreeView { get; set; }

		/// <inheritdoc/>
		public virtual HRESULT BrowseObject(IntPtr pidl, SBSP wFlags)
		{
			switch (wFlags)
			{
				case var f when f.IsFlagSet(SBSP.SBSP_NAVIGATEBACK):
					shellView.NavigateBack();
					break;
				case var f when f.IsFlagSet(SBSP.SBSP_NAVIGATEFORWARD):
					shellView.NavigateForward();
					break;
				case var f when f.IsFlagSet(SBSP.SBSP_PARENT):
					shellView.NavigateParent();
					break;
				case var f when f.IsFlagSet(SBSP.SBSP_RELATIVE):
					if (ShellItem.Open(shellView.CurrentFolder.IShellFolder, pidl) is ShellFolder sf)
						shellView.Navigate(sf);
					break;
				default:
					shellView.Navigate(new ShellFolder(pidl));
					break;
			}
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public virtual HRESULT ContextSensitiveHelp(bool fEnterMode) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT EnableModelessSB(bool fEnable) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT Exec(in Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, in object pvaIn, ref object pvaOut) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT GetControlWindow(FCW id, out HWND phwnd)
		{
			phwnd = id switch
			{
				FCW.FCW_PROGRESS => CheckAndLoad(ProgressBar),
#if NETFRAMEWORK || NETCOREAPP3_0
				FCW.FCW_STATUS => CheckAndLoad(StatusBar),
				FCW.FCW_TOOLBAR => CheckAndLoad(ToolBar),
#endif
				FCW.FCW_TREE => CheckAndLoad(TreeView),
				_ => HWND.NULL,
			};
			return phwnd.IsNull ? HRESULT.E_NOTIMPL : HRESULT.S_OK;

			static HWND CheckAndLoad(Control c) => c != null && c.IsHandleCreated ? c.Handle : HWND.NULL;
		}

		/// <inheritdoc/>
		public virtual HRESULT GetViewStateStream(STGM grfMode, out IStream ppStrm)
		{
			ppStrm = null;
			return HRESULT.E_NOTIMPL;
		}

		/// <inheritdoc/>
		public virtual HRESULT GetWindow(out HWND phwnd)
		{
			phwnd = shellView.shellViewWindow;
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public virtual HRESULT IncludeObject(IShellView ppshv, IntPtr pidl) => shellView.IncludeItem(pidl) ? HRESULT.S_OK : HRESULT.S_FALSE;

		/// <inheritdoc/>
		public virtual HRESULT InsertMenusSB(HMENU hmenuShared, ref Ole32.OLEMENUGROUPWIDTHS lpMenuWidths) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT OnDefaultCommand(IShellView ppshv)
		{
			var selected = shellView.SelectedItems;

			if (selected.Length > 0 && selected[0].IsFolder)
			{
				try { shellView.Navigate(selected[0] is ShellFolder f ? f : selected[0].Parent); }
				catch { }
			}
			else
			{
				shellView.OnDoubleClick(EventArgs.Empty);
			}

			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public virtual HRESULT OnStateChange(IShellView ppshv, CDBOSC uChange)
		{
			if (uChange == CDBOSC.CDBOSC_SELCHANGE)
				shellView.OnSelectionChanged();
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public virtual HRESULT OnViewWindowActive(IShellView ppshv) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT QueryActiveShellView(out IShellView ppshv)
		{
			ppshv = null;
			return HRESULT.E_NOTIMPL;
		}

		/// <inheritdoc/>
		public virtual HRESULT QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject)
		{
			var lriid = riid;
			var i = GetType().GetInterfaces().FirstOrDefault(i => i.IsCOMObject && i.GUID == lriid);
			if (i is null)
			{
				ppvObject = IntPtr.Zero;
				return HRESULT.E_NOINTERFACE;
			}

			ppvObject = Marshal.GetComInterfaceForObject(this, i);
			return HRESULT.S_OK;
		}

		/// <inheritdoc/>
		public virtual HRESULT QueryStatus(in Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, OLECMDTEXT pCmdText) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT RemoveMenusSB(HMENU hmenuShared) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT SendControlMsg(FCW id, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr pret)
		{
			pret = default;
			return HRESULT.E_NOTIMPL;
		}

		/// <inheritdoc/>
		public virtual HRESULT SetMenuSB(HMENU hmenuShared, IntPtr holemenuRes, HWND hwndActiveObject) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT SetStatusTextSB(string pszStatusText) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT SetToolbarItems(ComCtl32.TBBUTTON[] lpButtons, uint nButtons, FCT uFlags) => HRESULT.E_NOTIMPL;

		/// <inheritdoc/>
		public virtual HRESULT TranslateAcceleratorSB(ref MSG pmsg, ushort wID) => HRESULT.E_NOTIMPL;
	}
}