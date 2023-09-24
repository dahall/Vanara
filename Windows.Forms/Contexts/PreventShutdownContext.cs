using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms.Forms;

/// <summary>Used to define a set of operations within which any shutdown request will be met with a reason why this application is blocking it.</summary>
/// <remarks>This is to be used in either a 'using' statement or for the life of the application.
/// <para>To use for the life of the form, define a class field:
/// <code lang="cs">
/// private PreventShutdownContext disallowShutdown;
/// 
/// protected override void OnHandleCreated(EventArgs e)
/// {
///    base.OnHandleCreated(e);
///    disallowShutdown = new PreventShutdownContext(this, "Application defined message goes here.");
/// }
/// </code></para>
/// <para>To use this for a section of code:
/// <code lang="cs">
/// using (new PreventShutdownContext(this, "This app is super busy right now."))
/// {
///    // Do something that can't be interrupted...
/// }
/// </code></para></remarks>
public class PreventShutdownContext : IDisposable
{
	private const int WM_QUERYENDSESSION = 0x11;
	private HandleRef href;

	/// <summary>Initializes a new instance of the <see cref="PreventShutdownContext" /> class.</summary>
	/// <param name="window">The <see cref="Form" /> that contains a valid window handle.</param>
	/// <param name="reason">The reason the application must block system shutdown. Because users are typically in a hurry when shutting down the system, they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. Therefore, it is important that your reason strings are short and clear.</param>
	/// <param name="tryToPreventShutdown">If set to <see langword="true" />, this class will return false to the WM_QUERYENDSESSION by handling the e.Cancel response to Form.FormClosing.</param>
	/// <exception cref="SystemException">The system is configured to bypass showing application reasons for preventing shutdown.</exception>
	public PreventShutdownContext(Form window, string reason, bool tryToPreventShutdown = false)
	{
		if ((Microsoft.Win32.Registry.GetValue(@"HKEY_USERS\.DEFAULT\Control Panel\Desktop", "AutoEndTasks", 0) is uint v1 && v1 == 1) ||
			(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "AutoEndTasks", 0) is uint v2 && v2 == 1))
			throw new SystemException("The system is configured to bypass showing application reasons for preventing shutdown.");
		href = new HandleRef(window, window.Handle);
		if (tryToPreventShutdown)
			window.FormClosing += (s, e) => e.Cancel = true;
		Reason = reason;
	}

	/// <summary>The reason the application must block system shutdown. Because users are typically in a hurry when shutting down the system, they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. Therefore, it is important that your reason strings are short and clear.</summary>
	/// <value>The reason string.</value>
	public string Reason
	{
		get
		{
			if (!ShutdownBlockReasonQuery(href.Handle, out var reason))
				Win32Error.ThrowLastError();
			return reason;
		}
		set
		{
			if (value == null) value = string.Empty;
			if (ShutdownBlockReasonQuery(href.Handle, out var _))
				ShutdownBlockReasonDestroy(href.Handle);
			if (!ShutdownBlockReasonCreate(href.Handle, value))
				Win32Error.ThrowLastError();
		}
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		ShutdownBlockReasonDestroy(href.Handle);
	}
}