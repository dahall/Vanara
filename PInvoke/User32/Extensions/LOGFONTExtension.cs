using System;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions
{
	/// <summary>Extensions for the <see cref="LOGFONT"/> structure.</summary>
	public static class LOGFONTExtension
	{
		/// <summary>Gets the point size of the font.</summary>
		/// <param name="lf">The LOGFONT structure.</param>
		/// <returns>The point size of the font.</returns>
		public static float GetPointSize(this LOGFONT lf) => lf.lfHeight * 72L / (float)GetDevicePixelsPerInchY();

		/// <summary>Sets the point size of the font.</summary>
		/// <param name="lf">The LOGFONT structure.</param>
		/// <param name="value">The point size of the font.</param>
		public static void SetPointSize(this LOGFONT lf, float value) => lf.lfHeight = (int)Math.Round(-value * GetDevicePixelsPerInchY() / 72);

		private static int GetDevicePixelsPerInchY() => GetDeviceCaps(GetDC(GetDesktopWindow()), DeviceCap.LOGPIXELSY);
	}
}