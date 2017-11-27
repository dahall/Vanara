using System;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from windows.h</summary>
	public static partial class Macros
	{
		/// <summary>Retrieves the high-order byte from the given 16-bit value.</summary>
		/// <param name="wValue">The value to be converted.</param>
		/// <returns>The return value is the high-order byte of the specified value.</returns>
		public static byte HIBYTE(ushort wValue) => (byte)((wValue >> 8) & 0xff);

		/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the high-order word of the specified value.</returns>
		public static ushort HIWORD(uint dwValue) => (ushort)((dwValue >> 16) & 0xffff);

		/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the high-order word of the specified value.</returns>
		public static ushort HIWORD(IntPtr dwValue) => HIWORD((uint)Convert.ToUInt64(dwValue.ToInt64()));

		/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the high-order word of the specified value.</returns>
		public static ushort HIWORD(UIntPtr dwValue) => HIWORD((uint)dwValue.ToUInt64());

		/// <summary>Retrieves the low-order byte from the given 16-bit value.</summary>
		/// <param name="wValue">The value to be converted.</param>
		/// <returns>The return value is the low-order byte of the specified value.</returns>
		public static byte LOBYTE(ushort wValue) => (byte)(wValue & 0xff);

		/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the low-order word of the specified value.</returns>
		public static ushort LOWORD(uint dwValue) => (ushort)(dwValue & 0xffff);

		/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the low-order word of the specified value.</returns>
		public static ushort LOWORD(IntPtr dwValue) => LOWORD((uint)Convert.ToUInt64(dwValue.ToInt64()));

		/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The return value is the low-order word of the specified value.</returns>
		public static ushort LOWORD(UIntPtr dwValue) => LOWORD((uint)dwValue.ToUInt64());

		/// <summary>Creates a LONG value by concatenating the specified values.</summary>
		/// <param name="wLow">The low-order word of the new value.</param>
		/// <param name="wHigh">The high-order word of the new value.</param>
		/// <returns>The return value is a LONG value.</returns>
		public static uint MAKELONG(ushort wLow, ushort wHigh) => ((uint)wHigh << 16) | ((uint)wLow & 0xffff);

		/// <summary>Creates a LONG64 value by concatenating the specified values.</summary>
		/// <param name="dwLow">The low-order double word of the new value.</param>
		/// <param name="dwHigh">The high-order double word of the new value.</param>
		/// <returns>The return value is a LONG64 value.</returns>
		public static ulong MAKELONG64(uint dwLow, uint dwHigh) => ((ulong)dwHigh << 32) | ((ulong)dwLow & 0xffffffff);

		/// <summary>Creates a value for use as an lParam parameter in a message. The macro concatenates the specified values.</summary>
		/// <param name="wLow">The low-order word of the new value.</param>
		/// <param name="wHigh">The high-order word of the new value.</param>
		/// <returns>The return value is an LPARAM value.</returns>
		public static IntPtr MAKELPARAM(ushort wLow, ushort wHigh) => new IntPtr(MAKELONG(wLow, wHigh));

		/// <summary>Creates a WORD value by concatenating the specified values.</summary>
		/// <param name="bLow">The low-order byte of the new value.</param>
		/// <param name="bHigh">The high-order byte of the new value.</param>
		/// <returns>The return value is a WORD value.</returns>
		public static ushort MAKEWORD(byte bLow, byte bHigh) => (ushort)(bHigh << 8 | bLow & 0xff);

		/// <summary>Retrieves the high-order 16-bit value from the specified 32-bit value.</summary>
		/// <param name="iValue">The value to be converted.</param>
		/// <returns>The return value is the high-order 16-bit value of the specified value.</returns>
		public static short SignedHIWORD(int iValue) => (short)((iValue >> 16) & 0xffff);

		/// <summary>Retrieves the high-order 16-bit value from the specified 32-bit value.</summary>
		/// <param name="iValue">The value to be converted.</param>
		/// <returns>The return value is the high-order 16-bit value of the specified value.</returns>
		public static short SignedHIWORD(IntPtr iValue) => SignedHIWORD(unchecked((int)iValue.ToInt64()));

		/// <summary>Retrieves the low-order 16-bit value from the specified 32-bit value.</summary>
		/// <param name="iValue">The value to be converted.</param>
		/// <returns>The return value is the low-order 16-bit value of the specified value.</returns>
		public static short SignedLOWORD(int iValue) => (short)(iValue & 0xffff);

		/// <summary>Retrieves the low-order 16-bit value from the specified 32-bit value.</summary>
		/// <param name="iValue">The value to be converted.</param>
		/// <returns>The return value is the low-order 16-bit value of the specified value.</returns>
		public static short SignedLOWORD(IntPtr iValue) => SignedLOWORD(unchecked((int)iValue.ToInt64()));

		/// <summary>Determines whether a value is an integer identifier for a resource.</summary>
		/// <param name="ptr">The pointer to be tested whether it contains an integer resource identifier.</param>
		/// <returns>If the value is a resource identifier, the return value is TRUE. Otherwise, the return value is FALSE.</returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms648028")]
		public static bool IS_INTRESOURCE(IntPtr ptr) => ptr.ToInt64() >> 16 == 0;

		/// <summary>
		/// Converts an integer value to a resource type compatible with the resource-management functions. This macro is used in place of a string containing
		/// the name of the resource.
		/// </summary>
		/// <param name="id">The integer value to be converted.</param>
		/// <returns>The return value is string representation of the integer value.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "ms648029")]
		public static SafeResourceId MAKEINTRESOURCE(int id) => new SafeResourceId(id);
	}

	//public static T GetLParam<T>(this System.Windows.Forms.Message msg) => (T)msg.GetLParam(typeof(T));

	/*private static int GetEmbeddedNullStringLengthAnsi(string s)
	{
		int index = s.IndexOf('\0');
		if (index > -1)
		{
			string str = s.Substring(0, index);
			string str2 = s.Substring(index + 1);
			return ((GetPInvokeStringLength(str) + GetEmbeddedNullStringLengthAnsi(str2)) + 1);
		}
		return GetPInvokeStringLength(s);
	}

	public static int GetPInvokeStringLength(string s)
	{
		if (string.IsNullOrEmpty(s))
			return 0;
		if (Marshal.SystemDefaultCharSize == 2)
			return s.Length;
		if (s.IndexOf('\0') > -1)
			return GetEmbeddedNullStringLengthAnsi(s);
		return lstrlen(s);
	}*/
}