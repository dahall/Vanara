using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/*/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message table resource in an
		/// already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function
		/// finds the message definition in a message table resource based on a message identifier and a language identifier. The function returns the formatted
		/// message text, processing any embedded insert sequences if requested. </summary> <param name="formatString">Pointer to a string that consists of
		/// unformatted message text. It will be scanned for inserts and formatted accordingly.</param> <param name="args"> An array of values that are used as
		/// insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments array; a %2 indicates the second
		/// argument; and so on. The interpretation of each value depends on the formatting information associated with the insert in the message definition.
		/// Each insert must have a corresponding element in the array. </param> <param name="flags"> The formatting options, and how to interpret the lpSource
		/// parameter. The low-order byte of dwFlags specifies how the function handles line breaks in the output buffer. The low-order byte can also specify the
		/// maximum width of a formatted output line. </param> <returns> If the function succeeds, the return value is the string that specifies the formatted
		/// message. To get extended error information, call GetLastError. </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		private static string FormatMessage(string formatString, object[] args, FormatMessageFlags flags = 0)
		{
			if (string.IsNullOrEmpty(formatString) || args == null || args.Length == 0 || flags.IsFlagSet(FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS)) return formatString;
			flags &= ~(FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM);
			flags |= FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING | FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;
			var ptr = IntPtr.Zero;
			var s = new SafeCoTaskMemString(formatString);
			var m = new DynamicMethod("FormatMessage", typeof(void), new Type[0], typeof(Kernel32), true);
			var il = m.GetILGenerator();

			// TODO: Finish work here to push args onto stack and dynamically call method.
			il.Emit(OpCodes.Ldstr, formatString);
			il.Emit(OpCodes.Ldind_I, 0);
			il.Emit(OpCodes.Ldind_U4, 0);
			il.Emit(OpCodes.Ldind_U4, 0);
			il.EmitCall(OpCodes.Call, typeof(Kernel32).GetMethod("FormatMessage", BindingFlags.Public | BindingFlags.Static), new Type[] { typeof(string), typeof(IntPtr), typeof(uint), typeof(uint), typeof(int) });
			il.Emit(OpCodes.Pop);
			il.Emit(OpCodes.Ret);

			//var action = (Action)m.CreateDelegate(Action);
			//action.Invoke();

			//if (ret == 0) Win32Error.ThrowLastError();
			return new SafeLocalHandle(ptr, 0).ToString(-1);
		}*/

		/// <summary>Determines the length of the specified string (not including the terminating null character).</summary>
		/// <param name="lpString">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The null-terminated string to be checked.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>The function returns the length of the string, in characters. If lpString is <c>NULL</c>, the function returns 0.</para>
		/// </returns>
		// int WINAPI lstrlen( _In_ LPCTSTR lpString);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms647492(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms647492")]
		public static extern int lstrlen(string s);

		/// <summary>
		/// Multiplies two 32-bit values and then divides the 64-bit result by a third 32-bit value. The final result is rounded to the nearest integer.
		/// </summary>
		/// <param name="nNumber">The multiplicand.</param>
		/// <param name="nNumerator">The multiplier.</param>
		/// <param name="nDenominator">The number by which the result of the multiplication operation is to be divided.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the result of the multiplication and division, rounded to the nearest integer. If the result is a
		/// positive half integer (ends in .5), it is rounded up. If the result is a negative half integer, it is rounded down.
		/// </para>
		/// <para>If either an overflow occurred or nDenominator was 0, the return value is -1.</para>
		/// </returns>
		// int MulDiv( _In_ int nNumber, _In_ int nNumerator, _In_ int nDenominator); https://msdn.microsoft.com/en-us/library/windows/desktop/aa383718(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa383718")]
		public static extern int MulDiv(int nNumber, int nNumerator, int nDenominator);

		/// <summary>SafeHandle instance using <see cref="CloseHandle"/> upon disposal.</summary>
		public class SafeObjectHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeObjectHandle"/> class.</summary>
			public SafeObjectHandle() : this(IntPtr.Zero) { }
			/// <summary>Initializes a new instance of the <see cref="SafeObjectHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			public SafeObjectHandle(IntPtr handle) : base(handle, CloseHandle) { }
		}
	}
}