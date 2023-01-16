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
	/// <param name="mainWindow">The window instance.</param>
	/// <returns>
	/// The result of <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> or <see cref="GetMessage(out MSG, HWND, uint, uint)"/>.
	/// </returns>
	int Run(IWindowCore mainWindow = null);
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
	public int Run(IWindowCore mainWindow = null)
	{
		if (mainWindow is not null)
			mainWindow.Destroyed += onDestroy;

		try
		{
			return RunLoop();
		}
		finally
		{
			if (mainWindow is not null)
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
	/// <summary>Occurs after <see cref="DispatchMessage(in MSG)"/>.</summary>
	public event MsgPumpDelegate PostProcess;

	/// <summary>Occurs after <see cref="TranslateMessage(in MSG)"/> and determines if message should be dispatched.</summary>
	public event MsgPumpPredicateDelegate PostTranslate;

	/// <summary>
	/// Occurs after <see cref="PeekMessage(out MSG, HWND, uint, uint, PM)"/> and determines if message should be translated or dispatched.
	/// </summary>
	public event MsgPumpPredicateDelegate PreProcess;

	/// <inhertdoc/>
	protected override int RunLoop()
	{
		MSG msg;
		do
		{
			if (PeekMessage(out msg, default, 0, 0, PM.PM_REMOVE) && (PreProcess?.Invoke(ref msg) ?? true))
			{
				TranslateMessage(msg);
				if (PostTranslate?.Invoke(ref msg) ?? true)
					DispatchMessage(msg);
				PostProcess?.Invoke(ref msg);
			}
		} while (Macros.LOWORD(msg.message) != quitMsg);
		return 0;
	}
}