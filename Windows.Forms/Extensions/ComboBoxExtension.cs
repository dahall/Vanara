using System;
using System.Windows.Forms;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions;

/// <summary>Extension methods for <see cref="ComboBox"/>.</summary>
public static partial class ComboBoxExtension
{
	/// <summary>Sets the text displayed on a <see cref="ComboBox"/> when no item has been selected.</summary>
	/// <param name="cb">The <see cref="ComboBox"/> instance.</param>
	/// <param name="cueBannerText">The cue banner text.</param>
	/// <exception cref="PlatformNotSupportedException">This method is only support on Windows Vista and later.</exception>
	public static void SetCueBanner(this ComboBox cb, string cueBannerText)
	{
		if (Environment.OSVersion.Version.Major >= 6)
		{
			if (!cb.IsHandleCreated) return;
			SendMessage(cb.Handle, (uint)ComboBoxMessage.CB_SETCUEBANNER, IntPtr.Zero, cueBannerText);
			cb.Invalidate();
		}
		else
			throw new PlatformNotSupportedException();
	}
}