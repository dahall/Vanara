using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Extensions
{
	public static partial class ComboBoxExtension
	{
		public static void SetCueBanner(this ComboBox cb, string cueBannerText)
		{
			if (System.Environment.OSVersion.Version.Major >= 6)
			{
				if (!cb.IsHandleCreated) return;
				SendMessage(new HandleRef(cb, cb.Handle), (int)ComboBoxMessage.CB_SETCUEBANNER, IntPtr.Zero, cueBannerText);
				cb.Invalidate();
			}
			else
				throw new PlatformNotSupportedException();
		}
	}
}