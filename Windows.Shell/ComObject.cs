using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using IDropTarget = Vanara.PInvoke.Ole32.IDropTarget;

namespace Vanara.Windows.Shell
{
	public abstract class ComObject : IDisposable, IObjectWithSite
	{
		private bool disposedValue = false;
		private ComMessageLoop msgLoop;

		public ComObject() => CoAddRefServerProcess();

		public virtual object Site { get; set; }

		public virtual object QueryInterface(in Guid riid) => ShellUtil.QueryInterface(this, riid);

		public void QueueNonBlockingCallback(Action callback) => msgLoop?.QueueAppCallback(callback);

		public void QuitMessageLoop() => msgLoop?.Quit();

		public void RunMessageLoop()
		{
			if (msgLoop == null) return;
			msgLoop = new ComMessageLoop();
			msgLoop.RunMessageLoop();
		}

		void IDisposable.Dispose() => Dispose(true);

		HRESULT IObjectWithSite.GetSite(in Guid riid, out object ppvSite)
		{
			ppvSite = null;
			return Site is null ? HRESULT.E_FAIL : ShellUtil.QueryInterface(Site, riid, out ppvSite);
		}

		HRESULT IObjectWithSite.SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkSite)
		{
			Site = pUnkSite;
			return HRESULT.S_OK;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					QuitMessageLoop();
					CoReleaseServerProcess();
				}
				disposedValue = true;
			}
		}
	}

	public abstract class ComDropTarget : ComObject, IDropTarget
	{
		private DataObject lastDataObject;
		private DROPEFFECT lastEffect;

		HRESULT IDropTarget.DragEnter(IDataObject pDataObj, uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
			OnDragEnter(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			return HRESULT.S_OK;
		}

		HRESULT IDropTarget.DragLeave()
		{
			OnDragLeave(EventArgs.Empty);
			return HRESULT.S_OK;
		}

		HRESULT IDropTarget.DragOver(uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(null, grfKeyState, pt, pdwEffect);
			OnDragOver(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			return HRESULT.S_OK;
		}

		HRESULT IDropTarget.Drop(IDataObject pDataObj, uint grfKeyState, Point pt, ref DROPEFFECT pdwEffect)
		{
			var arg = CreateDragEventArgs(pDataObj, grfKeyState, pt, pdwEffect);
			OnDragDrop(arg);
			lastEffect = pdwEffect = (DROPEFFECT)arg.Effect;
			return HRESULT.S_OK;
		}

		protected virtual void OnDragDrop(DragEventArgs drgevent)
		{
		}

		protected virtual void OnDragEnter(DragEventArgs drgevent)
		{
		}

		protected virtual void OnDragLeave(EventArgs drgevent)
		{
		}

		protected virtual void OnDragOver(DragEventArgs drgevent)
		{
		}

		private DragEventArgs CreateDragEventArgs(IDataObject pDataObj, uint grfKeyState, Point pt, DROPEFFECT pdwEffect)
		{
			var data = pDataObj == null ? lastDataObject : new DataObject(pDataObj);
			var drgevent = new DragEventArgs(data, (int)grfKeyState, pt.X, pt.Y, (DragDropEffects)pdwEffect, (DragDropEffects)lastEffect);
			lastDataObject = data;
			return drgevent;
		}
	}
}