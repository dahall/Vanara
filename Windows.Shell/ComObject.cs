using System;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>
	/// Base class for all COM objects which handles calling AddRef and Release for the assembly, connection to IClassFactory, implements
	/// IObjectWithSite, using an internal message loop, and a mechanism to issue a non-blocking call to itself. Once implemented, you only
	/// need to implement your own interfaces. The IClassFactory implementation can get any derived interfaces through casting for calls to
	/// its QueryInterface method. If you want more control, override the QueryInterface method in this class.
	/// </summary>
	/// <seealso cref="System.IDisposable"/>
	/// <seealso cref="Vanara.PInvoke.Shell32.IObjectWithSite"/>
	public abstract class ComObject : IDisposable, IObjectWithSite
	{
		private bool disposedValue = false;
		private ComMessageLoop msgLoop;

		/// <summary>Initializes a new instance of the <see cref="ComObject"/> class.</summary>
		public ComObject() => CoAddRefServerProcess();

		/// <summary>Gets or sets the site exposed by <see cref="IObjectWithSite"/>.</summary>
		/// <value>The site object.</value>
		public virtual object Site { get; set; }

		/// <summary>Creates an uninitialized object.</summary>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be used to communicate with the newly created object. This parameter is
		/// generally the IID of the initializing interface.
		/// </param>
		/// <returns>
		/// The interface pointer requested in <paramref name="riid"/>. If the object does not support the interface specified in
		/// <paramref name="riid"/>, the implementation must return <see langword="null"/>.
		/// </returns>
		public virtual object QueryInterface(in Guid riid) => ShellUtil.QueryInterface(this, riid);

		/// <summary>Queues a non-blocking callback. This is useful in situations where a method cannot block an implemented method but further processing is needed. For example, IDropTarget::DragDrop and IExecuteCommand::Execute.</summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="tag">An optional object that will be passed to the callback.</param>
		public void QueueNonBlockingCallback(Action<object> callback, [Optional] object tag) => msgLoop?.QueueAppCallback(callback, tag);

		/// <summary>Quits the message loop by sending PostQuitMessage.</summary>
		/// <param name="exitCode">The exit code.</param>
		public void QuitMessageLoop(int exitCode = 0) => msgLoop?.Quit(exitCode);

		/// <summary>Runs the message loop.</summary>
		public void RunMessageLoop()
		{
			if (msgLoop == null || msgLoop.Running) return;
			msgLoop = new ComMessageLoop();
			msgLoop.RunMessageLoop();
		}

		/// <inheritdoc/>
		void IDisposable.Dispose() => Dispose(true);

		/// <inheritdoc/>
		HRESULT IObjectWithSite.GetSite(in Guid riid, out object ppvSite)
		{
			ppvSite = null;
			return Site is null ? HRESULT.E_FAIL : ShellUtil.QueryInterface(Site, riid, out ppvSite);
		}

		/// <inheritdoc/>
		HRESULT IObjectWithSite.SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkSite)
		{
			Site = pUnkSite;
			return HRESULT.S_OK;
		}

		/// <summary>Releases the unmanaged resources used by this object, and optionally releases the managed resources.</summary>
		/// <param name="disposing"><see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
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
}