using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	internal class ShellBrowser : IShellBrowser, IOleCommandTarget, Shell32.IServiceProvider
	{
		private readonly ShellView shellView;

		internal ShellBrowser(ShellView view) => shellView = view ?? throw new ArgumentNullException(nameof(view));

		HRESULT IShellBrowser.BrowseObject(IntPtr pidl, SBSP wFlags)
		{
			if (wFlags.IsFlagSet(SBSP.SBSP_PARENT))
			{
				shellView.NavigateParent();
			}
			else if (wFlags.IsFlagSet(SBSP.SBSP_NAVIGATEBACK))
			{
				shellView.NavigateBack();
			}
			else if (wFlags.IsFlagSet(SBSP.SBSP_NAVIGATEFORWARD))
			{
				shellView.NavigateForward();
			}
			else
			{
				shellView.Navigate(new ShellFolder(pidl));
			}
			return HRESULT.S_OK;
		}

		HRESULT IShellBrowser.ContextSensitiveHelp(bool fEnterMode) => HRESULT.E_NOTIMPL;

		HRESULT Ole32.IOleWindow.ContextSensitiveHelp(bool fEnterMode) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.EnableModelessSB(bool fEnable) => HRESULT.E_NOTIMPL;

		HRESULT IOleCommandTarget.Exec(in Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, in object pvaIn, ref object pvaOut) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.GetControlWindow(FCW id, out HWND phwnd)
		{
			phwnd = HWND.NULL;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT IShellBrowser.GetViewStateStream(STGM grfMode, out IStream ppStrm)
		{
			ppStrm = null;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT IShellBrowser.GetWindow(out HWND phwnd)
		{
			phwnd = shellView.shellViewWindow;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT Ole32.IOleWindow.GetWindow(out HWND phwnd) => shellView.iObj.GetWindow(out phwnd);

		HRESULT IShellBrowser.InsertMenusSB(HMENU hmenuShared, ref Ole32.OLEMENUGROUPWIDTHS lpMenuWidths) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.OnViewWindowActive(IShellView ppshv) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.QueryActiveShellView(out IShellView ppshv)
		{
			ppshv = null;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT Shell32.IServiceProvider.QueryService(in Guid guidService, in Guid riid, out IntPtr ppvObject)
		{
			if (riid == typeof(IOleCommandTarget).GUID)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IOleCommandTarget));
				return HRESULT.S_OK;
			}
			else if (riid == typeof(IShellBrowser).GUID)
			{
				ppvObject = Marshal.GetComInterfaceForObject(this, typeof(IShellBrowser));
				return HRESULT.S_OK;
			}
			else
			{
				ppvObject = IntPtr.Zero;
				return HRESULT.E_NOINTERFACE;
			}
		}

		HRESULT IOleCommandTarget.QueryStatus(in Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, OLECMDTEXT pCmdText) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.RemoveMenusSB(HMENU hmenuShared) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.SendControlMsg(FCW id, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr pret)
		{
			pret = default;
			return HRESULT.E_NOTIMPL;
		}

		HRESULT IShellBrowser.SetMenuSB(HMENU hmenuShared, IntPtr holemenuRes, HWND hwndActiveObject) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.SetStatusTextSB(string pszStatusText) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.SetToolbarItems(ComCtl32.TBBUTTON[] lpButtons, uint nButtons, FCT uFlags) => HRESULT.E_NOTIMPL;

		HRESULT IShellBrowser.TranslateAcceleratorSB(ref MSG pmsg, ushort wID) => HRESULT.E_NOTIMPL;
	}
}