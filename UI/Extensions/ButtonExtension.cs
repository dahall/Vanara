using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	public static partial class ButtonExtension
	{
		public static void SetElevationRequiredState(this ButtonBase btn, bool required = true)
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				if (!btn.IsHandleCreated) return;
				if (required) btn.FlatStyle = FlatStyle.System;
				SendMessage(new HandleRef(btn, btn.Handle), (int)ButtonMessage.BCM_SETSHIELD, IntPtr.Zero, required ? new IntPtr(1) : IntPtr.Zero);
				btn.Invalidate();
			}
			else
				throw new PlatformNotSupportedException();
		}
	}
}