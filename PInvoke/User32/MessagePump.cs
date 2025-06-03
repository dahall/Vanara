using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

/// <summary>Delegate for a method that processes a <see cref="MSG"/> structure.</summary>
/// <param name="msg">The <see cref="MSG"/> structure to process.</param>
public delegate void MsgPumpDelegate(ref MSG msg);

/// <summary>
/// Delegate for a method that processes a <see cref="MSG"/> structure and returns a value determining if the next step should be processed.
/// </summary>
/// <param name="msg">The <see cref="MSG"/> structure to process.</param>
/// <returns><see langword="true"/> if the pump should proceed; otherwise <see langword="false"/>.</returns>
public delegate bool MsgPumpPredicateDelegate(ref MSG msg);

/// <summary>Interface defining a message pump.</summary>
public interface IMessagePump
{
	/// <summary>Runs the message pump on the optionally specified window.</summary>
	/// <returns>
	/// The result of <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> or <see cref="GetMessage(out MSG, HWND, uint, uint)"/>.
	/// </returns>
	int Run();

	/// <summary>Runs the message pump on the optionally specified window.</summary>
	/// <param name="mainWindow">
	/// The window instance that is used to watch for a destroyed event so <see cref="PostQuitMessage(int)"/> can be called.
	/// </param>
	/// <returns>
	/// The result of <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> or <see cref="GetMessage(out MSG, HWND, uint, uint)"/>.
	/// </returns>
	int Run(IWindowInstance mainWindow);
}

/// <summary>An interface that represents a Win32 window with created and destroyed events.</summary>
public interface IWindowInstance
{
	/// <summary>Occurs when the window has been destroyed.</summary>
	event Action Destroyed;

	/// <summary>Gets the window handle.</summary>
	/// <value>The window handle.</value>
	HWND Handle { get; }
}

/// <summary>A basic message pump to use independently or with a window instance.</summary>
/// <example>
/// Simple example of a window creation and message pump.
/// <code>using (var win = new BasicMessageWindow() { Text = "Title", Visible = true })
///     return new MessagePump().Run(win);</code></example>
/// <seealso cref="IMessagePump" />
public class MessagePump : IMessagePump
{
	/// <summary>Easy access to WM_QUIT value.</summary>
	protected const ushort quitMsg = (ushort)WindowMessage.WM_QUIT;

	/// <inhertdoc/>
	public int Run() => Run(null);

	/// <inhertdoc/>
	public int Run(IWindowInstance? mainWindow)
	{
		if (mainWindow is not null and not WindowBase)
			mainWindow.Destroyed += onDestroy;

		try
		{
			return RunLoop();
		}
		finally
		{
			if (mainWindow is not null and not WindowBase)
				mainWindow.Destroyed -= onDestroy;
		}
		static void onDestroy() => PostQuitMessage(0);
	}

	/// <summary>Defines and executes the message pump.</summary>
	/// <returns>
	/// The result of <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> or <see cref="GetMessage(out MSG, HWND, uint, uint)"/>.
	/// </returns>
	protected virtual int RunLoop()
	{
		int bRet;
		while ((bRet = GetMessage(out MSG msg)) != 0)
		{
			if (bRet == -1)
				Win32Error.ThrowLastError();
			TranslateMessage(msg);
			DispatchMessage(msg);
		}
		return bRet;
	}
}

/// <summary>A message pump with events to process each step to use independently or with a window instance.</summary>
/// <seealso cref="MessagePump"/>
public class ExaminedMessagePump : MessagePump
{
	/// <summary>Initializes a new instance of the <see cref="ExaminedMessagePump"/> class.</summary>
	/// <param name="preProcess">A delegate that is called immediately after <c>GetMessage</c> whose result determines if <c>TranslateMessage</c> is called.</param>
	/// <param name="postTranslate">A delegate that is called immediately after <c>TranslateMessage</c> whose result determines if <c>DispatchMessage</c> is called.</param>
	/// <param name="postProcess">A delegate that is called after each <c>DispatchMessage</c>.</param>
	public ExaminedMessagePump(MsgPumpPredicateDelegate? preProcess = null, MsgPumpPredicateDelegate? postTranslate = null, MsgPumpDelegate? postProcess = null)
	{
		if (preProcess is not null) PreProcess += preProcess;
		if (postTranslate is not null) PostTranslate += postTranslate;
		if (postProcess is not null) PostProcess += postProcess;
	}

	/// <summary>Occurs after <see cref="DispatchMessage(in MSG)"/>.</summary>
	public event MsgPumpDelegate? PostProcess;

	/// <summary>Occurs after <see cref="TranslateMessage(in MSG)"/> and determines if message should be dispatched.</summary>
	public event MsgPumpPredicateDelegate? PostTranslate;

	/// <summary>
	/// Occurs after <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> and determines if message should be translated or dispatched.
	/// </summary>
	public event MsgPumpPredicateDelegate? PreProcess;

	/// <inhertdoc/>
	protected override int RunLoop()
	{
		int bRet;
		while ((bRet = GetMessage(out MSG msg)) != 0)
		{
			if (bRet == -1)
				Win32Error.ThrowLastError();
			if (PreProcess?.Invoke(ref msg) ?? true)
			{
				TranslateMessage(msg);
				if (PostTranslate?.Invoke(ref msg) ?? true)
					DispatchMessage(msg);
			}
			PostProcess?.Invoke(ref msg);
		}
		return bRet;
	}
}

/// <summary>Represents a message pump that processes Windows messages and supports keyboard accelerators.</summary>
/// <remarks>
/// This class extends the functionality of a standard message pump by integrating an accelerator table, allowing the application to handle
/// keyboard shortcuts efficiently. It processes messages in a loop, invoking pre-processing, post-processing, and accelerator key handling
/// as needed.
/// </remarks>
public class MessagePumpWithAccelerators : MessagePump
{
	/// <summary>Initializes a new instance of the <see cref="MessagePumpWithAccelerators"/> class.</summary>
	/// <param name="hWndParent">The handle to the parent window of the message pump.</param>
	/// <param name="hAccel">The handle to the accelerator table associated with the application.</param>
	public MessagePumpWithAccelerators(HWND hWndParent, HACCEL hAccel = default)
	{
		AcceleratorTableHandle = hAccel;
		ParentWindowHandle = hWndParent;
	}

	/// <summary>Gets or sets the handle to the accelerator table associated with the application.</summary>
	public virtual HACCEL AcceleratorTableHandle { get; set; }

	/// <summary>Gets or sets the handle to the parent window of the message pump.</summary>
	public virtual HWND ParentWindowHandle { get; set; }

	/// <inheritdoc/>
	protected override int RunLoop()
	{
		int bRet;
		while ((bRet = GetMessage(out MSG msg)) != 0)
		{
			if (bRet == -1)
				Win32Error.ThrowLastError();
			if (AcceleratorTableHandle.IsNull || TranslateAccelerator(ParentWindowHandle, AcceleratorTableHandle, msg) == 0)
			{
				TranslateMessage(msg);
				DispatchMessage(msg);
			}
		}
		return bRet;
	}
}