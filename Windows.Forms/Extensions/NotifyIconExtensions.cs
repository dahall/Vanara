using System.Drawing;
using System.Windows.Forms;
using Vanara.Extensions.Reflection;
using Vanara.PInvoke;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="NotifyIcon"/>.</summary>
	public static partial class NotifyIconExtensions
	{
		/// <summary>Gets the screen coordinates of the bounding rectangle of a notification icon.</summary>
		/// <param name="trayIcon">The <see cref="NotifyIcon"/> instance to process.</param>
		/// <returns>
		/// A <see cref="Rectangle"/> structure that, when this function returns successfully, receives the coordinates of the icon.
		/// </returns>
		public static Rectangle GetBounds(this NotifyIcon trayIcon)
		{
			// Super sketchy way of doing this, but it works
			var iconid = trayIcon.GetFieldValue<uint>("id");
			NativeWindow win = trayIcon.GetFieldValue<NativeWindow>("window");
			var nii = new Shell32.NOTIFYICONIDENTIFIER(win.Handle, iconid);
			Shell32.Shell_NotifyIconGetRect(nii, out RECT loc).ThrowIfFailed();
			return loc;
		}
	}
}
