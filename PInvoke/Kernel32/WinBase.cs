using System;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags passed to the <see cref=Vanara.PInvokee.FormatMessage(FormatMessageFlags,SafeLibraryHandle,int,int,System.IntPtr,int,string[])"/> method.</summary>
		[PInvokeData("winbase.h")]
		[Flags]
		public enum FormatMessageFlags
		{
			/// <summary>
			/// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the address specified
			/// by lpBuffer. The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller should use the
			/// LocalFree function to free the buffer when it is no longer needed.
			/// <para>
			/// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.
			/// </para>
			/// <para>
			/// In previous versions of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
			/// </para>
			/// <para>
			/// Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then FormatMessage will not automatically fail
			/// with an error of ERROR_MORE_DATA.
			/// </para>
			/// <para>
			/// Windows 10: LocalFree is not in the modern SDK, so it cannot be used to free the result buffer. Instead, use HeapFree (GetProcessHeap(),
			/// allocatedMessage). In this case, this is the same as calling LocalFree on memory.
			/// </para>
			/// <para>
			/// Important: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE. FormatMessage() uses LMEM_FIXED, so HeapFree can be used. If
			///            LMEM_MOVABLE is used, HeapFree cannot be used.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100,

			/// <summary>
			/// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments. This flag cannot be used
			/// with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
			/// </summary>
			FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000,

			/// <summary>
			/// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL, the current
			/// process's application image file will be searched. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
			/// <para>If the module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.</para>
			/// </summary>
			FORMAT_MESSAGE_FROM_HMODULE = 0x800,

			/// <summary>
			/// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may contain insert
			/// sequences, just as the message text in a message table resource may. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_HMODULE"/> or <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/>.
			/// </summary>
			FORMAT_MESSAGE_FROM_STRING = 0x400,

			/// <summary>
			/// The function should search the system message-table resource(s) for the requested message. If this flag is specified with
			/// <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>, the function searches the system message table if the message is not found in the module specified by
			/// lpSource. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
			/// <para>
			/// If this flag is specified, an application can pass the result of the GetLastError function to retrieve the message text for a system-defined error.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_FROM_SYSTEM = 0x1000,

			/// <summary>
			/// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is useful for fetching
			/// a message for later formatting. If this flag is set, the Arguments parameter is ignored.
			/// </summary>
			FORMAT_MESSAGE_IGNORE_INSERTS = 0x200,

			/// <summary>
			/// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the message definition
			/// text into the output buffer. The function generates no new line breaks.
			/// <para>
			/// Without this flag set: There are no output line width restrictions. The function stores line breaks that are in the message definition text into
			/// the output buffer. It specifies the maximum number of characters in an output line. The function ignores regular line breaks in the message
			/// definition text. The function never splits a string delimited by white space across a line break. The function stores hard-coded line breaks in
			/// the message definition text into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_MAX_WIDTH_MASK = 0xff
		}

		/// <summary>The memory allocation attributes.</summary>
		[PInvokeData("MinWinBase.h")]
		[Flags]
		public enum LocalMemoryFlags
		{
			/// <summary>Allocates fixed memory. The return value is a pointer to the memory object.</summary>
			LMEM_FIXED = 0x0000,
			/// <summary>
			/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap. The return value is a
			/// handle to the memory object. To translate the handle to a pointer, use the LocalLock function. This value cannot be combined with LMEM_FIXED.
			/// </summary>
			LMEM_MOVEABLE = 0x0002,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_NOCOMPACT = 0x0010,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_NODISCARD = 0x0020,
			/// <summary>Initializes memory contents to zero.</summary>
			LMEM_ZEROINIT = 0x0040,
			/// <summary>
			/// If the LMEM_MODIFY flag is specified in LocalReAlloc, this parameter modifies the attributes of the memory object, and the uBytes parameter is ignored.
			/// </summary>
			LMEM_MODIFY = 0x0080,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_DISCARDABLE = 0x0F00,
			/// <summary>Valid flags.</summary>
			LMEM_VALID_FLAGS = 0x0F72,
			/// <summary>Indicates that the local handle is not valid</summary>
			LMEM_INVALID_HANDLE = 0x8000,
			/// <summary>Combines LMEM_MOVEABLE and LMEM_ZEROINIT.</summary>
			LHND = (LMEM_MOVEABLE | LMEM_ZEROINIT),
			/// <summary>Combines LMEM_FIXED and LMEM_ZEROINIT.</summary>
			LPTR = (LMEM_FIXED | LMEM_ZEROINIT),
			/// <summary>Same as LMEM_MOVEABLE.</summary>
			NONZEROLHND = (LMEM_MOVEABLE),
			/// <summary>Same as LMEM_FIXED.</summary>
			NONZEROLPTR = (LMEM_FIXED)
		}

		/// <summary>Closes an open object handle.</summary>
		/// <param name="hObject">A valid handle to an open object.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms724211")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr hObject);

		/// <summary>Converts a file time to system time format. System time is based on Coordinated Universal Time (UTC).</summary>
		/// <param name="lpFileTime">
		/// A pointer to a FILETIME structure containing the file time to be converted to system (UTC) date and time format. This value must be less than
		/// 0x8000000000000000. Otherwise, the function fails.
		/// </param>
		/// <param name="lpSystemTime">A pointer to a SYSTEMTIME structure to receive the converted file time.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("FileAPI.h", MSDNShortId = "ms724280")]
		[DllImport(Lib.Kernel32, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FileTimeToSystemTime(ref FILETIME lpFileTime, ref SYSTEMTIME lpSystemTime);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the
		/// function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message
		/// table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and
		/// a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <param name="lpSource">
		/// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text. It will be scanned for
		/// inserts and formatted accordingly. If neither of these flags is set in dwFlags, then lpSource is ignored.
		/// </param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.</param>
		/// <param name="dwLanguageId">
		/// The language identifier for the requested message. This parameter is ignored if dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>. If you pass a specific LANGID in this parameter, FormatMessage will return a message for
		/// that LANGID only. If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND. If you pass in zero,
		/// FormatMessage looks for a message for LANGIDs in the following order: Language neutral Thread LANGID, based on the thread's locale value User default
		/// LANGID, based on the user's default locale value System default LANGID, based on the system default locale value US English If FormatMessage does not
		/// locate a message for any of the preceding LANGIDs, it returns any language message string that is present. If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
		/// </param>
		/// <param name="lpBuffer">
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer using the LocalAlloc function, and places the
		/// pointer to the buffer at the address specified in lpBuffer. This buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="nSize">
		/// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, this parameter specifies the size of the output buffer, in
		/// TCHARs. If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, this parameter specifies the minimum number of TCHARs to allocate
		/// for an output buffer. The output buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="arguments">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition.The default is to treat each value as a pointer to a null-terminated string. By default, the Arguments parameter is
		/// of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list
		/// argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and
		/// reinitialize it with va_start. If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer
		/// to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element
		/// in the array.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character. If the
		/// function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static extern int FormatMessage(FormatMessageFlags dwFlags, SafeLibraryHandle lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
			uint nSize, string[] arguments);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the
		/// function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message
		/// table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and
		/// a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <param name="lpSource">
		/// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text. It will be scanned for
		/// inserts and formatted accordingly. If neither of these flags is set in dwFlags, then lpSource is ignored.
		/// </param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.</param>
		/// <param name="dwLanguageId">
		/// The language identifier for the requested message. This parameter is ignored if dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>. If you pass a specific LANGID in this parameter, FormatMessage will return a message for
		/// that LANGID only. If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND. If you pass in zero,
		/// FormatMessage looks for a message for LANGIDs in the following order: Language neutral Thread LANGID, based on the thread's locale value User default
		/// LANGID, based on the user's default locale value System default LANGID, based on the system default locale value US English If FormatMessage does not
		/// locate a message for any of the preceding LANGIDs, it returns any language message string that is present. If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
		/// </param>
		/// <param name="lpBuffer">
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer using the LocalAlloc function, and places the
		/// pointer to the buffer at the address specified in lpBuffer. This buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="nSize">
		/// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, this parameter specifies the size of the output buffer, in
		/// TCHARs. If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, this parameter specifies the minimum number of TCHARs to allocate
		/// for an output buffer. The output buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="arguments">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition.The default is to treat each value as a pointer to a null-terminated string. By default, the Arguments parameter is
		/// of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list
		/// argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and
		/// reinitialize it with va_start. If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer
		/// to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element
		/// in the array.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character. If the
		/// function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
			uint nSize, string[] arguments);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer passed into the
		/// function. It can come from a message table resource in an already-loaded module. Or the caller can ask the function to search the system's message
		/// table resource(s) for the message definition. The function finds the message definition in a message table resource based on a message identifier and
		/// a language identifier. The function copies the formatted message text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <param name="lpSource">
		/// The location of the message definition. The type of this parameter depends upon the settings in the <paramref name="dwFlags"/> parameter. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE"/>: A handle to the module that contains the message table to search. If
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>: Pointer to a string that consists of unformatted message text. It will be scanned for
		/// inserts and formatted accordingly. If neither of these flags is set in dwFlags, then lpSource is ignored.
		/// </param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.</param>
		/// <param name="dwLanguageId">
		/// The language identifier for the requested message. This parameter is ignored if dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>. If you pass a specific LANGID in this parameter, FormatMessage will return a message for
		/// that LANGID only. If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND. If you pass in zero,
		/// FormatMessage looks for a message for LANGIDs in the following order: Language neutral Thread LANGID, based on the thread's locale value User default
		/// LANGID, based on the user's default locale value System default LANGID, based on the system default locale value US English If FormatMessage does not
		/// locate a message for any of the preceding LANGIDs, it returns any language message string that is present. If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
		/// </param>
		/// <param name="lpBuffer">
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the function allocates a buffer using the LocalAlloc function, and places the
		/// pointer to the buffer at the address specified in lpBuffer. This buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="nSize">
		/// If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, this parameter specifies the size of the output buffer, in
		/// TCHARs. If <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, this parameter specifies the minimum number of TCHARs to allocate
		/// for an output buffer. The output buffer cannot be larger than 64K bytes.
		/// </param>
		/// <param name="arguments">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition.The default is to treat each value as a pointer to a null-terminated string. By default, the Arguments parameter is
		/// of type va_list*, which is a language- and implementation-specific data type for describing a variable number of arguments.The state of the va_list
		/// argument is undefined upon return from the function.To use the va_list again, destroy the variable argument list pointer using va_end and
		/// reinitialize it with va_start. If you do not have a pointer of type va_list*, then specify the FORMAT_MESSAGE_ARGUMENT_ARRAY flag and pass a pointer
		/// to an array of DWORD_PTR values; those values are input to the message formatted as the insert values.Each insert must have a corresponding element
		/// in the array.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the number of TCHARs stored in the output buffer, excluding the terminating null character. If the
		/// function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		private static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer,
			uint nSize, __arglist);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message table resource in an
		/// already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function
		/// finds the message definition in a message table resource based on a message identifier and a language identifier. The function returns the formatted
		/// message text, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="id">The message identifier for the requested message.</param>
		/// <param name="args">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition. Each insert must have a corresponding element in the array.
		/// </param>
		/// <param name="hLib">A handle to the module that contains the message table to search.</param>
		/// <param name="flags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <param name="langId">
		/// The language identifier for the requested message. If you pass a specific LANGID in this parameter, FormatMessage will return a message for that
		/// LANGID only. If the function cannot find a message for that LANGID, it sets Last-Error to ERROR_RESOURCE_LANG_NOT_FOUND. If you pass in zero,
		/// FormatMessage looks for a message for LANGIDs in the following order: Language neutral Thread LANGID, based on the thread's locale value User default
		/// LANGID, based on the user's default locale value System default LANGID, based on the system default locale value US English If FormatMessage does not
		/// locate a message for any of the preceding LANGIDs, it returns any language message string that is present. If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static string FormatMessage(uint id, string[] args = null, SafeLibraryHandle hLib = null, FormatMessageFlags flags = 0, uint langId = 0)
		{
			flags &= ~FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING;
			flags |= FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM;
			if (hLib != null) flags |= FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE;
			if (args != null && args.Length > 0 && !flags.IsFlagSet(FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS)) flags |= FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;
			var ptr = IntPtr.Zero;
			var ret = FormatMessage(flags, hLib ?? SafeLibraryHandle.Null, id, langId, ref ptr, 0, args);
			if (ret == 0) Win32Error.ThrowLastError();
			return new SafeLocalHandle(ptr, 0).ToString(-1);
		}

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message table resource in an
		/// already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function
		/// finds the message definition in a message table resource based on a message identifier and a language identifier. The function returns the formatted
		/// message text, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="formatString">Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</param>
		/// <param name="args">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition. Each insert must have a corresponding element in the array.
		/// </param>
		/// <param name="flags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static string FormatMessage(string formatString, string[] args, FormatMessageFlags flags = 0)
		{
			if (string.IsNullOrEmpty(formatString) || args == null || args.Length == 0 || flags.IsFlagSet(FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS)) return formatString;
			flags &= ~(FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM);
			flags |= FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING | FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;
			var ptr = IntPtr.Zero;
			var s = new SafeCoTaskMemString(formatString);
			var ret = FormatMessage(flags, (IntPtr)s, 0U, 0U, ref ptr, 0U, args);
			if (ret == 0) Win32Error.ThrowLastError();
			return new SafeLocalHandle(ptr, 0).ToString(-1);
		}

		/*/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message table resource in an
		/// already-loaded module. Or the caller can ask the function to search the system's message table resource(s) for the message definition. The function
		/// finds the message definition in a message table resource based on a message identifier and a language identifier. The function returns the formatted
		/// message text, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="formatString">Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</param>
		/// <param name="args">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value in the Arguments
		/// array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting information associated with the
		/// insert in the message definition. Each insert must have a corresponding element in the array.
		/// </param>
		/// <param name="flags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function handles line breaks in
		/// the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information, call GetLastError.
		/// </returns>
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

		/// <summary>
		/// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, the
		/// module is unloaded from the address space of the calling process and the handle is no longer valid.
		/// </summary>
		/// <param name="hModule">
		/// A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or GetModuleHandleEx function returns this handle.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a nonzero value.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683152")]
		public static extern bool FreeLibrary(IntPtr hModule);

		/// <summary>Retrieves a pseudo handle for the current process.</summary>
		/// <returns>The return value is a pseudo handle to the current process.</returns>
		/// <remarks>
		/// A pseudo handle is a special constant, currently (HANDLE)-1, that is interpreted as the current process handle. For compatibility with future
		/// operating systems, it is best to call GetCurrentProcess instead of hard-coding this constant value. The calling process can use a pseudo handle to
		/// specify its own process whenever a process handle is required. Pseudo handles are not inherited by child processes.
		/// <para>This handle has the PROCESS_ALL_ACCESS access right to the process object.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP: This handle has the maximum access allowed by the security descriptor of the process to the primary token of the process.
		/// </para>
		/// <para>
		/// A process can create a "real" handle to itself that is valid in the context of other processes, or that can be inherited by other processes, by
		/// specifying the pseudo handle as the source handle in a call to the DuplicateHandle function. A process can also use the OpenProcess function to open
		/// a real handle to itself.
		/// </para>
		/// <para>
		/// The pseudo handle need not be closed when it is no longer needed. Calling the <see cref="CloseHandle"/> function with a pseudo handle has no
		/// effect.If the pseudo handle is duplicated by DuplicateHandle, the duplicate handle must be closed.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683179")]
		public static extern IntPtr GetCurrentProcess();

		/// <summary>Retrieves a pseudo handle for the calling thread.</summary>
		/// <returns>The return value is a pseudo handle for the current thread.</returns>
		/// <remarks>
		/// A pseudo handle is a special constant that is interpreted as the current thread handle. The calling thread can use this handle to specify itself
		/// whenever a thread handle is required. Pseudo handles are not inherited by child processes.
		/// <para>This handle has the THREAD_ALL_ACCESS access right to the thread object. For more information, see Thread Security and Access Rights.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP: This handle has the maximum access allowed by the security descriptor of the thread to the primary token of the process.
		/// </para>
		/// <para>
		/// The function cannot be used by one thread to create a handle that can be used by other threads to refer to the first thread. The handle is always
		/// interpreted as referring to the thread that is using it. A thread can create a "real" handle to itself that can be used by other threads, or
		/// inherited by other processes, by specifying the pseudo handle as the source handle in a call to the DuplicateHandle function.
		/// </para>
		/// <para>
		/// The pseudo handle need not be closed when it is no longer needed. Calling the CloseHandle function with this handle has no effect. If the pseudo
		/// handle is duplicated by DuplicateHandle, the duplicate handle must be closed.
		/// </para>
		/// <para>
		/// Do not create a thread while impersonating a security context. The call will succeed, however the newly created thread will have reduced access
		/// rights to itself when calling GetCurrentThread. The access rights granted this thread will be derived from the access rights the impersonated user
		/// has to the process. Some access rights including THREAD_SET_THREAD_TOKEN and THREAD_GET_CONTEXT may not be present, leading to unexpected failures.
		/// </para>
		/// </remarks>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683182")]
		public static extern IntPtr GetCurrentThread();

		/// <summary>Retrieves the thread identifier of the calling thread.</summary>
		/// <returns>The return value is the thread identifier of the calling thread.</returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683183")]
		public static extern uint GetCurrentThreadId();

		/// <summary>
		/// Retrieves the fully qualified path for the file that contains the specified module. The module must have been loaded by the current process.
		/// <para>To locate the file for a module that was loaded by another process, use the GetModuleFileNameEx function.</para>
		/// </summary>
		/// <param name="hModule">
		/// A handle to the loaded module whose path is being requested. If this parameter is NULL, GetModuleFileName retrieves the path of the executable file
		/// of the current process.
		/// <para>
		/// The GetModuleFileName function does not retrieve the path for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information,
		/// see LoadLibraryEx.
		/// </para>
		/// </param>
		/// <param name="lpFilename">
		/// A pointer to a buffer that receives the fully qualified path of the module. If the length of the path is less than the size that the nSize parameter
		/// specifies, the function succeeds and the path is returned as a null-terminated string.
		/// <para>
		/// If the length of the path exceeds the size that the nSize parameter specifies, the function succeeds and the string is truncated to nSize characters
		/// including the terminating null character.
		/// </para>
		/// <para><c>Windows XP:</c> The string is truncated to nSize characters and is not null-terminated.</para>
		/// <para>
		/// The string returned will use the same format that was specified when the module was loaded. Therefore, the path can be a long or short file name, and
		/// can use the prefix "\\?\". For more information, see Naming a File.
		/// </para>
		/// </param>
		/// <param name="nSize">The size of the lpFilename buffer, in TCHARs.</param>
		/// <returns>
		/// If the function succeeds, the return value is the length of the string that is copied to the buffer, in characters, not including the terminating
		/// null character. If the buffer is too small to hold the module name, the string is truncated to nSize characters including the terminating null
		/// character, the function returns nSize, and the function sets the last error to ERROR_INSUFFICIENT_BUFFER.
		/// <para>
		/// <c>Windows XP:</c> If the buffer is too small to hold the module name, the function returns nSize. The last error code remains ERROR_SUCCESS. If
		/// nSize is zero, the return value is zero and the last error code is ERROR_SUCCESS.
		/// </para>
		/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
		/// </returns>
		[SecurityCritical, SuppressUnmanagedCodeSecurity, DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683197")]
		public static extern int GetModuleFileName(SafeLibraryHandle hModule, [Out] StringBuilder lpFilename, int nSize);

		/// <summary>
		/// Retrieves the fully qualified path for the file that contains the specified module. The module must have been loaded by the current process.
		/// <para>To locate the file for a module that was loaded by another process, use the GetModuleFileNameEx function.</para>
		/// </summary>
		/// <param name="hModule">
		/// A handle to the loaded module whose path is being requested. If this parameter is NULL, GetModuleFileName retrieves the path of the executable file
		/// of the current process.
		/// <para>
		/// The GetModuleFileName function does not retrieve the path for modules that were loaded using the LOAD_LIBRARY_AS_DATAFILE flag. For more information,
		/// see LoadLibraryEx.
		/// </para>
		/// </param>
		/// <returns>
		/// The string returned will use the same format that was specified when the module was loaded. Therefore, the path can be a long or short file name, and
		/// can use the prefix "\\?\". For more information, see Naming a File.
		/// </returns>
		[SecurityCritical]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683197")]
		public static string GetModuleFileName(SafeLibraryHandle hModule)
		{
			var buffer = new StringBuilder(MAX_PATH);
			Label_000B:
			var num1 = GetModuleFileName(hModule, buffer, buffer.Capacity);
			if (num1 == 0)
				throw new Win32Exception();
			if (num1 == buffer.Capacity && Marshal.GetLastWin32Error() == Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				buffer.EnsureCapacity(buffer.Capacity * 2);
				goto Label_000B;
			}
			return buffer.ToString();
		}

		/// <summary>The GetProcAddress function retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).</summary>
		/// <param name="hModule">
		/// Handle to the DLL module that contains the function or variable. The LoadLibrary or GetModuleHandle function returns this handle.
		/// </param>
		/// <param name="lpProcName">
		/// Pointer to a null-terminated string containing the function or variable name, or the function's ordinal value. If this parameter is an ordinal value,
		/// it must be in the low-order word; the high-order word must be zero.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the address of the exported function or variable. <br></br><br>If the function fails, the return value
		/// is NULL. To get extended error information, call Marshal.GetLastWin32Error.</br>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Ansi)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683212")]
		public static extern IntPtr GetProcAddress(SafeLibraryHandle hModule, string lpProcName);

		/// <summary>
		/// The GlobalLock function locks a global memory object and returns a pointer to the first byte of the object's memory block. GlobalLock function
		/// increments the lock count by one. Needed for the clipboard functions when getting the data from IDataObject
		/// </summary>
		/// <param name="hMem"></param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366584")]
		public static extern IntPtr GlobalLock(IntPtr hMem);

		/// <summary>The GlobalUnlock function decrements the lock count associated with a memory object.</summary>
		/// <param name="hMem"></param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366595")]
		public static extern bool GlobalUnlock(IntPtr hMem);

		/// <summary>
		/// Allocates the specified number of bytes from the heap. <note>The local functions have greater overhead and provide fewer features than other memory
		/// management functions. New applications should use the heap functions unless documentation states that a local function should be used. For more
		/// information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="uFlags">
		/// The memory allocation attributes. The default is the LMEM_FIXED value. This parameter can be one or more of the following values, except for the
		/// incompatible combinations that are specifically noted.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LHND</c>
		/// <para>0x0042</para>
		/// </term>
		/// <term>Combines LMEM_MOVEABLE and LMEM_ZEROINIT.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_FIXED</c>
		/// <para>0x0000</para>
		/// </term>
		/// <term>Allocates fixed memory. The return value is a pointer to the memory object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_MOVEABLE</c>
		/// <para>0x0002</para>
		/// </term>
		/// <term>
		/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
		/// <para>The return value is a handle to the memory object. To translate the handle to a pointer, use the LocalLock function.</para>
		/// <para>This value cannot be combined with LMEM_FIXED.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_ZEROINIT</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Initializes memory contents to zero.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LPTR</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Combines LMEM_FIXED and LMEM_ZEROINIT.</term>
		/// </item>
		/// <item>
		/// <term><c>NONZEROLHND</c></term>
		/// <term>Same as LMEM_MOVEABLE.</term>
		/// </item>
		/// <item>
		/// <term><c>NONZEROLPTR</c></term>
		/// <term>Same as LMEM_FIXED.</term>
		/// </item>
		/// </list>
		/// <para>The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>LMEM_DISCARDABLE</term>
		/// </item>
		/// <item>
		/// <term>LMEM_NOCOMPACT</term>
		/// </item>
		/// <item>
		/// <term>LMEM_NODISCARD</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="uBytes">
		/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies LMEM_MOVEABLE, the function returns a handle to a
		/// memory object that is marked as discarded.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL. To get
		/// extended error information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// Windows memory management does not provide a separate local heap and global heap. Therefore, the LocalAlloc and GlobalAlloc functions are essentially
		/// the same.
		/// <para>
		/// The movable-memory flags LHND, LMEM_MOVABLE, and NONZEROLHND add unnecessary overhead and require locking to be used safely. They should be avoided
		/// unless documentation specifically states that they should be used.
		/// </para>
		/// <para>
		/// New applications should use the heap functions unless the documentation specifically states that a local function should be used. For example, some
		/// Windows functions allocate memory that must be freed with LocalFree.
		/// </para>
		/// <para>
		/// If the heap does not contain sufficient free space to satisfy the request, LocalAlloc returns NULL. Because NULL is used to indicate an error,
		/// virtual address zero is never allocated. It is, therefore, easy to detect the use of a NULL pointer.
		/// </para>
		/// <para>
		/// If the LocalAlloc function succeeds, it allocates at least the amount requested. If the amount allocated is greater than the amount requested, the
		/// process can use the entire amount. To determine the actual number of bytes allocated, use the LocalSize function.
		/// </para>
		/// <para>To free the memory, use the LocalFree function. It is not safe to free memory allocated with LocalAlloc using GlobalFree.</para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366723")]
		public static extern IntPtr LocalAlloc(LocalMemoryFlags uFlags, UIntPtr uBytes);

		/// <summary>
		/// Frees the specified local memory object and invalidates its handle. <note>The local functions have greater overhead and provide fewer features than
		/// other memory management functions. New applications should use the heap functions unless documentation states that a local function should be used.
		/// For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">
		/// A handle to the local memory object. This handle is returned by either the LocalAlloc or LocalReAlloc function. It is not safe to free memory
		/// allocated with GlobalAlloc.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is NULL. If the function fails, the return value is equal to a handle to the local memory object. To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366730")]
		public static extern IntPtr LocalFree(IntPtr hMem);

		/// <summary>
		/// Changes the size or the attributes of a specified local memory object. The size can increase or decrease. <note>The local functions have greater
		/// overhead and provide fewer features than other memory management functions. New applications should use the heap functions unless documentation
		/// states that a local function should be used. For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">A handle to the local memory object to be reallocated. This handle is returned by either the LocalAlloc or LocalReAlloc function.</param>
		/// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies LMEM_MODIFY, this parameter is ignored.</param>
		/// <param name="uFlags">
		/// The reallocation options. If LMEM_MODIFY is specified, the function modifies the attributes of the memory object only (the uBytes parameter is
		/// ignored.) Otherwise, the function reallocates the memory object.
		/// <para>You can optionally combine LMEM_MODIFY with the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LMEM_MOVEABLE</c>
		/// <para>0x0002</para>
		/// </term>
		/// <term>
		/// Allocates fixed or movable memory.
		/// <para>
		/// If the memory is a locked LMEM_MOVEABLE memory block or a LMEM_FIXED memory block and this flag is not specified, the memory can only be reallocated
		/// in place.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the memory is a locked LMEM_MOVEABLE memory block or a LMEM_FIXED memory block and this flag is not specified, the memory can only be reallocated
		/// in place.
		/// </para>
		/// <para>If this parameter does not specify LMEM_MODIFY, you can use the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LMEM_ZEROINIT</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Causes the additional memory contents to be initialized to zero if the memory object is growing in size.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the reallocated memory object. If the function fails, the return value is NULL. To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366742")]
		public static extern IntPtr LocalReAlloc(IntPtr hMem, UIntPtr uBytes, LocalMemoryFlags uFlags);

		/// <summary>
		/// Retrieves the current size of the specified local memory object, in bytes. <note>The local functions have greater overhead and provide fewer features
		/// than other memory management functions. New applications should use the heap functions unless documentation states that a local function should be
		/// used. For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by the LocalAlloc, LocalReAlloc, or LocalHandle function.</param>
		/// <returns>
		/// If the function succeeds, the return value is the size of the specified local memory object, in bytes. If the specified handle is not valid or if the
		/// object has been discarded, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366745")]
		public static extern uint LocalSize(IntPtr hMem);

		/// <summary>Sets the last-error code for the calling thread.</summary>
		/// <param name="dwErrCode">The last-error code for the thread.</param>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680627")]
		public static extern void SetLastError(uint dwErrCode);

		/// <summary>Converts a system time to file time format. System time is based on Coordinated Universal Time (UTC).</summary>
		/// <param name="lpSystemTime">
		/// A pointer to a SYSTEMTIME structure that contains the system time to be converted from UTC to file time format. The wDayOfWeek member of the
		/// SYSTEMTIME structure is ignored.
		/// </param>
		/// <param name="lpFileTime">A pointer to a FILETIME structure to receive the converted system time.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724948")]
		public static extern bool SystemTimeToFileTime(ref SYSTEMTIME lpSystemTime, ref FILETIME lpFileTime);

		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms647492")]
		private static extern int lstrlen([In, MarshalAs(UnmanagedType.LPTStr)] string s);
	}
}
