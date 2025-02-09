﻿namespace Vanara.PInvoke;

/// <summary>Platform invokable enumerated types, constants and functions from windows.h</summary>
public static partial class Macros
{
	/// <summary>Aligns a number to the neighboring multiple.</summary>
	/// <param name="value">The value to align.</param>
	/// <param name="pow2">A number that is a power of 2 (e.g. 2, 4, 8, 16, ...).</param>
	/// <returns>
	/// A value that is aligned to the next multiple of <paramref name="pow2"/>. This value may be the same as <paramref name="value"/>.
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">pow2 - Parameter must be a power of 2.</exception>
	public static long ALIGN_TO_MULTIPLE(long value, int pow2) =>
		// Ensure pow2 is a power of 2
		pow2 == 0 || (pow2 & (pow2 - 1)) != 0
			? throw new ArgumentOutOfRangeException(nameof(pow2), "Parameter must be a power of 2.")
			: (value + pow2 - 1) & (~((long)pow2 - 1));

	/// <summary>Retrieves the signed x-coordinate from the specified <c>LPARAM</c> value.</summary>
	/// <param name="lp">The value to be converted.</param>
	/// <returns>The signed x-coordinate.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windowsx/nf-windowsx-get_x_lparam
	// void GET_X_LPARAM( lp );
	[PInvokeData("windowsx.h")]
	public static int GET_X_LPARAM(IntPtr lp) => unchecked((short)(long)lp);

	/// <summary>Retrieves the signed y-coordinate from the given <c>LPARAM</c> value.</summary>
	/// <param name="lp">The value to be converted.</param>
	/// <returns>The signed y-coordinate.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/windowsx/nf-windowsx-get_y_lparam
	// void GET_Y_LPARAM( lp );
	[PInvokeData("windowsx.h")]
	public static int GET_Y_LPARAM(IntPtr lp) => unchecked((short)((long)lp >> 16));

	/// <summary>Retrieves the high-order byte from the given 16-bit value.</summary>
	/// <param name="wValue">The value to be converted.</param>
	/// <returns>The return value is the high-order byte of the specified value.</returns>
	public static byte HIBYTE(ushort wValue) => (byte)((wValue >> 8) & 0xff);

	/// <summary>Gets the high 8-bytes from a <see cref="long"/> value.</summary>
	/// <param name="lValue">The <see cref="long"/> value.</param>
	/// <returns>The high 8-bytes as a <see cref="int"/>.</returns>
	public static int HighPart(this long lValue) => unchecked((int)(lValue >> 32));

	/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the high-order word of the specified value.</returns>
	public static ushort HIWORD(uint dwValue) => (ushort)((dwValue >> 16) & 0xffff);

	/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the high-order word of the specified value.</returns>
	public static ushort HIWORD(IntPtr dwValue) => unchecked((ushort)((long)dwValue >> 16));

	/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the high-order word of the specified value.</returns>
	public static ushort HIWORD(UIntPtr dwValue) => unchecked((ushort)((ulong)dwValue >> 16));

	/// <summary>Determines whether a value is an integer identifier for a resource.</summary>
	/// <param name="ptr">The pointer to be tested whether it contains an integer resource identifier.</param>
	/// <returns>If the value is a resource identifier, the return value is TRUE. Otherwise, the return value is FALSE.</returns>
	[PInvokeData("WinBase.h", MSDNShortId = "ms648028")]
	public static bool IS_INTRESOURCE(IntPtr ptr) => unchecked((ulong)ptr.ToInt64()) >> 16 == 0;

	/// <summary>Retrieves the low-order byte from the given 16-bit value.</summary>
	/// <param name="wValue">The value to be converted.</param>
	/// <returns>The return value is the low-order byte of the specified value.</returns>
	public static byte LOBYTE(ushort wValue) => (byte)(wValue & 0xff);

	/// <summary>Gets the lower 8-bytes from a <see cref="long"/> value.</summary>
	/// <param name="lValue">The <see cref="long"/> value.</param>
	/// <returns>The lower 8-bytes as a <see cref="uint"/>.</returns>
	public static uint LowPart(this long lValue) => (uint)(lValue & 0xffffffff);

	/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the low-order word of the specified value.</returns>
	public static ushort LOWORD(uint dwValue) => (ushort)(dwValue & 0xffff);

	/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the low-order word of the specified value.</returns>
	public static ushort LOWORD(IntPtr dwValue) => unchecked((ushort)(long)dwValue);

	/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The return value is the low-order word of the specified value.</returns>
	public static ushort LOWORD(UIntPtr dwValue) => unchecked((ushort)(ulong)dwValue);

	/// <summary>Converts the specified atom into a pointer, so it can be passed to functions which accept either atoms or strings.</summary>
	/// <param name="i">The numeric value to be made into an integer atom. This parameter can be either an integer atom or a string atom.</param>
	/// <returns>A pointer with the atom as the low-order word.</returns>
	/// <remarks>Although the return value of the <c>MAKEINTATOM</c> macro is cast as an <c>LPTSTR</c> value, it cannot be used as a string pointer except when it is passed to atom-management functions that require an <c>LPTSTR</c> argument.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-makeintatom
	// void MAKEINTATOM( i );
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.MAKEINTATOM")]
	public static IntPtr MAKEINTATOM(ushort i) => new(unchecked((int)MAKELONG(i, 0)));

	/// <summary>
	/// Converts an integer value to a resource type compatible with the resource-management functions. This macro is used in place of a
	/// string containing the name of the resource.
	/// </summary>
	/// <param name="id">The integer value to be converted.</param>
	/// <returns>The return value is string representation of the integer value.</returns>
	[PInvokeData("WinUser.h", MSDNShortId = "ms648029")]
	public static ResourceId MAKEINTRESOURCE(int id) => id;

	/// <summary>Creates a LONG value by concatenating the specified values.</summary>
	/// <param name="wLow">The low-order word of the new value.</param>
	/// <param name="wHigh">The high-order word of the new value.</param>
	/// <returns>The return value is a LONG value.</returns>
	public static uint MAKELONG(IConvertible wLow, IConvertible wHigh) => (wHigh.ToUInt32(null) << 16) | (wLow.ToUInt32(null) & 0xffff);

	/// <summary>Creates a LONG64 value by concatenating the specified values.</summary>
	/// <param name="dwLow">The low-order double word of the new value.</param>
	/// <param name="dwHigh">The high-order double word of the new value.</param>
	/// <returns>The return value is a LONG64 value.</returns>
	public static long MAKELONG64(IConvertible dwLow, int dwHigh) => ((long)dwHigh << 32) | (dwLow.ToInt64(null) & 0xffffffff);

	/// <summary>Creates a LONG64 value by concatenating the specified values.</summary>
	/// <param name="dwLow">The low-order double word of the new value.</param>
	/// <param name="dwHigh">The high-order double word of the new value.</param>
	/// <returns>The return value is a LONG64 value.</returns>
	public static ulong MAKELONG64(IConvertible dwLow, IConvertible dwHigh) => (dwHigh.ToUInt64(null) << 32) | (dwLow.ToUInt64(null) & 0xffffffff);

	/// <summary>Creates a value for use as an lParam parameter in a message. The macro concatenates the specified values.</summary>
	/// <param name="wLow">The low-order word of the new value.</param>
	/// <param name="wHigh">The high-order word of the new value.</param>
	/// <returns>The return value is an LPARAM value.</returns>
	public static IntPtr MAKELPARAM(IConvertible wLow, IConvertible wHigh) => new(MAKELONG(wLow, wHigh));

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