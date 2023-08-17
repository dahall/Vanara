using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell;

/// <summary>Exposed methods from <see cref="ComObject"/>.</summary>
[ComVisible(false)]
public interface IComObject
{
	/// <summary>Creates an uninitialized object.</summary>
	/// <param name="riid">
	/// A reference to the identifier of the interface to be used to communicate with the newly created object. This parameter is
	/// generally the IID of the initializing interface.
	/// </param>
	/// <returns>
	/// The interface pointer requested in <paramref name="riid"/>. If the object does not support the interface specified in
	/// <paramref name="riid"/>, the implementation must return <see langword="null"/>.
	/// </returns>
	object? QueryInterface(in Guid riid);

	/// <summary>Quits the message loop by sending PostQuitMessage.</summary>
	/// <param name="exitCode">The exit code.</param>
	void QuitMessageLoop(int exitCode = 0);

	/// <summary>Runs the message loop.</summary>
	/// <param name="timeout">
	/// The time span after which the message loop will be terminated. If this value equals TimeSpan.Zero or is not specified, the
	/// message loop will run until the <see cref="QuitMessageLoop"/> method is called or the message loop receives a quit message.
	/// </param>
	void Run(TimeSpan timeout = default);
}

/// <summary>
/// Base class for all COM objects which handles calling AddRef and Release for the assembly, connection to IClassFactory, implements
/// IObjectWithSite, using an internal message loop, and a mechanism to issue a non-blocking call to itself. Once implemented, you only
/// need to implement your own interfaces. The IClassFactory implementation can get any derived interfaces through casting for calls to
/// its QueryInterface method. If you want more control, override the QueryInterface method in this class.
/// </summary>
/// <seealso cref="IDisposable"/>
/// <seealso cref="IObjectWithSite"/>
public abstract class ComObject : IComObject, IDisposable, IObjectWithSite
{
	private readonly CLSCTX ctx;
	private readonly REGCLS use;
	private bool disposedValue = false;
	private MessageLoop msgLoop = new();

	/// <summary>Initializes a new instance of the <see cref="ComObject"/> class.</summary>
	protected ComObject() : this(CLSCTX.CLSCTX_LOCAL_SERVER, REGCLS.REGCLS_MULTIPLEUSE | REGCLS.REGCLS_SUSPENDED)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="ComObject"/> class.</summary>
	/// <param name="classContext">The context within which the COM object is to be run.</param>
	/// <param name="classUse">Indicates how connections are made to the class object.</param>
	protected ComObject(CLSCTX classContext, REGCLS classUse)
	{
		ctx = classContext;
		use = classUse;
		CoAddRefServerProcess();
	}

	/// <summary>Gets or sets the site exposed by <see cref="IObjectWithSite"/>.</summary>
	/// <value>The site object.</value>
	public virtual object? Site { get; set; }

	/// <summary>
	/// Cancels the timeout specified in the <see cref="Run"/> method. This should be called when the application knows that it wants to
	/// keep running, for example when it receives the incoming call to invoke the verb.
	/// </summary>
	public void CancelTimeout() => msgLoop.CancelTimeout();

	/// <summary>Creates an uninitialized object.</summary>
	/// <param name="riid">
	/// A reference to the identifier of the interface to be used to communicate with the newly created object. This parameter is
	/// generally the IID of the initializing interface.
	/// </param>
	/// <returns>
	/// The interface pointer requested in <paramref name="riid"/>. If the object does not support the interface specified in
	/// <paramref name="riid"/>, the implementation must return <see langword="null"/>.
	/// </returns>
	public virtual object? QueryInterface(in Guid riid) => ShellUtil.QueryInterface(this, riid);

	/// <summary>
	/// Queues a non-blocking callback. This is useful in situations where a method cannot block an implemented method but further
	/// processing is needed. For example, IDropTarget::DragDrop and IExecuteCommand::Execute.
	/// </summary>
	/// <param name="callback">The callback method.</param>
	/// <param name="tag">An optional object that will be passed to the callback.</param>
	public void QueueNonBlockingCallback(Action<object?> callback, [Optional] object tag) => msgLoop.QueueCallback(callback, tag);

	/// <summary>Quits the message loop by sending PostQuitMessage.</summary>
	/// <param name="exitCode">The exit code.</param>
	public void QuitMessageLoop(int exitCode = 0) => msgLoop.Quit(exitCode);

	/// <summary>Runs the message loop.</summary>
	/// <param name="timeout">
	/// The time span after which the message loop will be terminated. If this value equals TimeSpan.Zero or is not specified, the
	/// message loop will run until the <see cref="QuitMessageLoop"/> method is called or the message loop receives a quit message.
	/// </param>
	public void Run(TimeSpan timeout = default)
	{
		if (msgLoop.Running) return;
		using (var cf = new ComClassFactory(this, ctx, use))
		{
			if (use.IsFlagSet(REGCLS.REGCLS_SUSPENDED))
				cf.Resume();
			msgLoop.Run(timeout);
		}
		System.Diagnostics.Debug.WriteLine("ComObject.Run ended.");
	}

	/// <inheritdoc/>
	void IDisposable.Dispose() => Dispose(true);

	/// <inheritdoc/>
	HRESULT IObjectWithSite.GetSite(in Guid riid, out object? ppvSite)
	{
		ppvSite = null;
		return Site is null ? HRESULT.E_FAIL : ShellUtil.QueryInterface(Site, riid, out ppvSite);
	}

	/// <inheritdoc/>
	HRESULT IObjectWithSite.SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object? pUnkSite)
	{
		Site = pUnkSite;
		return HRESULT.S_OK;
	}

	/// <summary>Releases the unmanaged resources used by this object, and optionally releases the managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
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