using System;
using System.Drawing;
using System.Runtime.InteropServices;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		[Flags]
		public enum HotKeyModifiers
		{
			MOD_NONE = 0,
			MOD_ALT = 0x0001,
			MOD_CONTROL = 0x0002,
			MOD_SHIFT = 0x0004,
			MOD_WIN = 0x0008,
			MOD_NOREPEAT = 0x4000,
		}

		[DllImport(Lib.User32, SetLastError = true)]
		public static extern int RegisterHotKey(HandleRef hWnd, int id, HotKeyModifiers fsModifiers, uint vk);

		[DllImport(Lib.User32, SetLastError = true)]
		public static extern int UnregisterHotKey(HandleRef hWnd, int id);

	}
}