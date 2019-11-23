using System;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="ButtonBase"/>.</summary>
	public static partial class ButtonExtension
	{
		/// <summary>Sets a value that determines if the shield icon is shown on the button to indicate that elevation is required.</summary>
		/// <param name="btn">The <see cref="ButtonBase"/> instance.</param>
		/// <param name="required">
		/// If set to <see langword="true"/>, the shield icon will be shown on the button. If <see langword="false"/>, the button will
		/// display normally.
		/// </param>
		/// <exception cref="PlatformNotSupportedException">This method is only support on Windows Vista and later.</exception>
		public static void SetElevationRequiredState(this ButtonBase btn, bool required = true)
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				if (!btn.IsHandleCreated) return;
				if (required) btn.FlatStyle = FlatStyle.System;
				SendMessage(btn.Handle, (uint)ButtonMessage.BCM_SETSHIELD, IntPtr.Zero, required ? new IntPtr(1) : IntPtr.Zero);
				btn.Invalidate();
			}
			else
				throw new PlatformNotSupportedException();
		}
	}
}