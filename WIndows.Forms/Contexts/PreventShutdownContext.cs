using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Forms.Forms
{
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
		private HandleRef href;

		/// <summary>Initializes a new instance of the <see cref="PreventShutdownContext"/> class.</summary>
		/// <param name="window">The <see cref="Form"/> or <see cref="Control"/> that contains a valid window handle.</param>
		/// <param name="reason">The reason the application must block system shutdown. Because users are typically in a hurry when shutting down the system, they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. Therefore, it is important that your reason strings are short and clear.</param>
		public PreventShutdownContext(Control window, string reason)
		{
			href = new HandleRef(window, window.Handle);
			Reason = reason;
		}

		/// <summary>The reason the application must block system shutdown. Because users are typically in a hurry when shutting down the system, they may spend only a few seconds looking at the shutdown reasons that are displayed by the system. Therefore, it is important that your reason strings are short and clear.</summary>
		/// <value>The reason string.</value>
		public string Reason
		{
			get
			{
				if (!ShutdownBlockReasonQuery(href, out var reason))
					Win32Error.ThrowLastError();
				return reason;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (ShutdownBlockReasonQuery(href, out var _))
					ShutdownBlockReasonDestroy(href);
				if (!ShutdownBlockReasonCreate(href, value))
					Win32Error.ThrowLastError();
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			ShutdownBlockReasonDestroy(href);
		}
	}
}