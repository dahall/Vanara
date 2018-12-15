using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The exception maximum parameters</summary>
		public const int EXCEPTION_MAXIMUM_PARAMETERS = 15;

		/// <summary>
		/// An application-defined function that passes unhandled exceptions to the debugger, if the process is being debugged. Otherwise, it
		/// optionally displays an Application Error message box and causes the exception handler to be executed. This function can be called
		/// only from within the filter expression of an exception handler.
		/// </summary>
		/// <param name="ExceptionInfo">
		/// A pointer to an EXCEPTION_POINTERS structure that specifies a description of the exception and the processor context at the time
		/// of the exception. This pointer is the return value of a call to the GetExceptionInformation function.
		/// </param>
		/// <returns>
		/// The function returns one of the following values.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EXCEPTION_CONTINUE_SEARCH = 0x0</term>
		/// <term>The process is being debugged, so the exception should be passed (as second chance) to the application's debugger.</term>
		/// </item>
		/// <item>
		/// <term>EXCEPTION_EXECUTE_HANDLER = 0x1</term>
		/// <term>
		/// If the SEM_NOGPFAULTERRORBOX flag was specified in a previous call to SetErrorMode, no Application Error message box is
		/// displayed. The function returns control to the exception handler, which is free to take any appropriate action.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		public delegate EXCEPTION_FLAG PTOP_LEVEL_EXCEPTION_FILTER(in EXCEPTION_POINTERS ExceptionInfo);

		/// <summary>
		/// An application-defined function that serves as a vectored exception handler. Specify this address when calling the
		/// AddVectoredExceptionHandler function.
		/// </summary>
		/// <param name="ExceptionInfo">A pointer to an EXCEPTION_POINTERS structure that receives the exception record.</param>
		/// <returns>
		/// To return control to the point at which the exception occurred, return EXCEPTION_CONTINUE_EXECUTION (0xffffffff). To continue the
		/// handler search, return EXCEPTION_CONTINUE_SEARCH (0x0).
		/// </returns>
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate int PVECTORED_EXCEPTION_HANDLER(ref EXCEPTION_POINTERS ExceptionInfo);

		/// <summary>Exception flags</summary>
		public enum EXCEPTION_FLAG : uint
		{
			/// <summary>Indicates a continuable exception.</summary>
			EXCEPTION_CONTINUABLE = 0,
			/// <summary>
			/// Proceed with normal execution of UnhandledExceptionFilter. That means obeying the SetErrorMode flags, or invoking the
			/// Application Error pop-up message box.
			/// </summary>
			EXCEPTION_CONTINUE_SEARCH = 0x0000,
			/// <summary>Indicates a noncontinuable exception.</summary>
			EXCEPTION_NONCONTINUABLE = 0x0001,
			/// <summary>
			/// Return from UnhandledExceptionFilter and execute the associated exception handler. This usually results in process termination.
			/// </summary>
			EXCEPTION_EXECUTE_HANDLER = 0x0001,
			EXCEPTION_UNWINDING = 0x0002,
			EXCEPTION_EXIT_UNWIND = 0x0004,
			EXCEPTION_STACK_INVALID = 0x0008,
			EXCEPTION_NESTED_CALL = 0x0010,
			EXCEPTION_TARGET_UNWIND = 0x0020,
			EXCEPTION_COLLIDED_UNWIND = 0x0040,
			EXCEPTION_UNWIND = 0x0066,
			/// <summary>
			/// Return from UnhandledExceptionFilter and continue execution from the point of the exception. Note that the filter function is
			/// free to modify the continuation state by modifying the exception information supplied through its LPEXCEPTION_POINTERS parameter.
			/// </summary>
			EXCEPTION_CONTINUE_EXECUTION = 0xFFFFFFFF,
			EXCEPTION_CHAIN_END = 0xFFFFFFFF,
		}

		/// <summary>Flags that control the behavior of <see cref="RaiseFailFastException"/>.</summary>
		public enum FAIL_FAST_FLAGS : uint
		{
			/// <summary>None.</summary>
			NONE = 0,
			/// <summary>
			/// Causes RaiseFailFastException to set the ExceptionAddress of EXCEPTION_RECORD to the return address of this function (the
			/// next instruction in the caller after the call to RaiseFailFastException). This function will set the exception address only
			/// if ExceptionAddress is not NULL.
			/// </summary>
			FAIL_FAST_GENERATE_EXCEPTION_ADDRESS = 0x1,
		}

		/// <summary>
		/// Flags passed to the <see cref="FormatMessage(uint, string[], HINSTANCE, FormatMessageFlags, uint)"/> method.
		/// </summary>
		[PInvokeData("winbase.h")]
		[Flags]
		public enum FormatMessageFlags
		{
			/// <summary>
			/// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at
			/// the address specified by lpBuffer. The nSize parameter specifies the minimum number of TCHARs to allocate for an output
			/// message buffer. The caller should use the LocalFree function to free the buffer when it is no longer needed.
			/// <para>
			/// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError
			/// will return ERROR_MORE_DATA.
			/// </para>
			/// <para>
			/// In previous versions of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10
			/// this value can be used.
			/// </para>
			/// <para>
			/// Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then FormatMessage will not
			/// automatically fail with an error of ERROR_MORE_DATA.
			/// </para>
			/// <para>
			/// Windows 10: LocalFree is not in the modern SDK, so it cannot be used to free the result buffer. Instead, use HeapFree
			/// (GetProcessHeap(), allocatedMessage). In this case, this is the same as calling LocalFree on memory.
			/// </para>
			/// <para>
			/// Important: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE. FormatMessage() uses LMEM_FIXED, so HeapFree can
			///            be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100,

			/// <summary>
			/// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments. This
			/// flag cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
			/// </summary>
			FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000,

			/// <summary>
			/// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is
			/// NULL, the current process's application image file will be searched. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
			/// <para>If the module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.</para>
			/// </summary>
			FORMAT_MESSAGE_FROM_HMODULE = 0x800,

			/// <summary>
			/// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition
			/// may contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with <see
			/// cref="FORMAT_MESSAGE_FROM_HMODULE"/> or <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/>.
			/// </summary>
			FORMAT_MESSAGE_FROM_STRING = 0x400,

			/// <summary>
			/// The function should search the system message-table resource(s) for the requested message. If this flag is specified with
			/// <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>, the function searches the system message table if the message is not found in the
			/// module specified by lpSource. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
			/// <para>
			/// If this flag is specified, an application can pass the result of the GetLastError function to retrieve the message text for a
			/// system-defined error.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_FROM_SYSTEM = 0x1000,

			/// <summary>
			/// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is
			/// useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
			/// </summary>
			FORMAT_MESSAGE_IGNORE_INSERTS = 0x200,

			/// <summary>
			/// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the
			/// message definition text into the output buffer. The function generates no new line breaks.
			/// <para>
			/// Without this flag set: There are no output line width restrictions. The function stores line breaks that are in the message
			/// definition text into the output buffer. It specifies the maximum number of characters in an output line. The function ignores
			/// regular line breaks in the message definition text. The function never splits a string delimited by white space across a line
			/// break. The function stores hard-coded line breaks in the message definition text into the output buffer. Hard-coded line
			/// breaks are coded with the %n escape sequence.
			/// </para>
			/// </summary>
			FORMAT_MESSAGE_MAX_WIDTH_MASK = 0xff
		}

		/// <summary>Registers a vectored continue handler.</summary>
		/// <param name="FirstHandler">
		/// The order in which the handler should be called. If the parameter is nonzero, the handler is the first handler to be called. If
		/// the parameter is zero, the handler is the last handler to be called.
		/// </param>
		/// <param name="VectoredHandler">A pointer to the handler to be called. For more information, see VectoredHandler.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the exception handler.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// PVOID WINAPI AddVectoredContinueHandler( _In_ ULONG FirstHandler, _In_ PVECTORED_EXCEPTION_HANDLER VectoredHandler);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679273")]
		public static extern SafeContinueHandlerHandle AddVectoredContinueHandler(uint FirstHandler, PVECTORED_EXCEPTION_HANDLER VectoredHandler);

		/// <summary>Registers a vectored exception handler.</summary>
		/// <param name="FirstHandler">
		/// The order in which the handler should be called. If the parameter is nonzero, the handler is the first handler to be called. If
		/// the parameter is zero, the handler is the last handler to be called.
		/// </param>
		/// <param name="VectoredHandler">A pointer to the handler to be called. For more information, see <c>VectoredHandler</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the exception handler.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// PVOID WINAPI AddVectoredExceptionHandler( _In_ ULONG FirstHandler, _In_ PVECTORED_EXCEPTION_HANDLER VectoredHandler);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679274")]
		public static extern SafeExceptionHandlerHandle AddVectoredExceptionHandler(uint FirstHandler, PVECTORED_EXCEPTION_HANDLER VectoredHandler);

		/// <summary>
		/// Displays a message box and terminates the application when the message box is closed. If the system is running with a debug
		/// version of Kernel32.dll, the message box gives the user the opportunity to terminate the application or to cancel the message box
		/// and return to the application that called <c>FatalAppExit</c>.
		/// </summary>
		/// <param name="uAction">This parameter must be zero.</param>
		/// <param name="lpMessageText">The null-terminated string that is displayed in the message box.</param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI FatalAppExit( _In_ UINT uAction, _In_ LPCTSTR lpMessageText); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679336(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679336")]
		public static extern void FatalAppExit(uint uAction, string lpMessageText);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer
		/// passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the
		/// function to search the system's message table resource(s) for the message definition. The function finds the message definition
		/// in a message table resource based on a message identifier and a language identifier. The function copies the formatted message
		/// text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function
		/// handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORMAT_MESSAGE_ALLOCATE_BUFFER0x00000100</term>
		/// <term>
		/// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the
		/// address specified by lpBuffer. The lpBuffer parameter is a pointer to an LPTSTR; you must cast the pointer to an LPTSTR (for
		/// example, ). The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller
		/// should use the LocalFree function to free the buffer when it is no longer needed.If the length of the formatted message exceeds
		/// 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.In previous versions
		/// of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
		/// Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then FormatMessage will not
		/// automatically fail with an error of ERROR_MORE_DATA.Windows 10: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE.
		/// FormatMessage() uses LMEM_FIXED, so HeapFree can be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_ARGUMENT_ARRAY0x00002000</term>
		/// <term>
		/// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.This flag
		/// cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		/// <term>
		/// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL,
		/// the current process's application image file will be searched. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If the
		/// module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		/// <term>
		/// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may
		/// contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with
		/// FORMAT_MESSAGE_FROM_HMODULE or FORMAT_MESSAGE_FROM_SYSTEM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_SYSTEM0x00001000</term>
		/// <term>
		/// The function should search the system message-table resource(s) for the requested message. If this flag is specified with
		/// FORMAT_MESSAGE_FROM_HMODULE, the function searches the system message table if the message is not found in the module specified
		/// by lpSource. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If this flag is specified, an application can pass the
		/// result of the GetLastError function to retrieve the message text for a system-defined error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_IGNORE_INSERTS0x00000200</term>
		/// <term>
		/// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is
		/// useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The low-order byte of dwFlags can specify the maximum width of a formatted output line. The following are possible values of the
		/// low-order byte.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// There are no output line width restrictions. The function stores line breaks that are in the message definition text into the
		/// output buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_MAX_WIDTH_MASK0x000000FF</term>
		/// <term>
		/// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the
		/// message definition text into the output buffer. The function generates no new line breaks.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the low-order byte is a nonzero value other than <c>FORMAT_MESSAGE_MAX_WIDTH_MASK</c>, it specifies the maximum number of
		/// characters in an output line. The function ignores regular line breaks in the message definition text. The function never splits
		/// a string delimited by white space across a line break. The function stores hard-coded line breaks in the message definition text
		/// into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
		/// </para>
		/// </param>
		/// <param name="lpSource">
		/// <para>The location of the message definition. The type of this parameter depends upon the settings in the dwFlags parameter.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>dwFlags Setting</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		/// <term>A handle to the module that contains the message table to search.</term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		/// <term>Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>If neither of these flags is set in dwFlags, then lpSource is ignored.</para>
		/// </param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</param>
		/// <param name="dwLanguageId">
		/// <para>The language identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</para>
		/// <para>
		/// If you pass a specific <c>LANGID</c> in this parameter, <c>FormatMessage</c> will return a message for that <c>LANGID</c> only.
		/// If the function cannot find a message for that <c>LANGID</c>, it sets Last-Error to <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>. If you
		/// pass in zero, <c>FormatMessage</c> looks for a message for <c>LANGIDs</c> in the following order:
		/// </para>
		/// <para>
		/// If <c>FormatMessage</c> does not locate a message for any of the preceding <c>LANGIDs</c>, it returns any language message string
		/// that is present. If that fails, it returns <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>.
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c>, the function allocates a buffer using the <c>LocalAlloc</c> function, and places the
		/// pointer to the buffer at the address specified in lpBuffer.
		/// </para>
		/// <para>This buffer cannot be larger than 64K bytes.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>
		/// If the <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> flag is not set, this parameter specifies the size of the output buffer, in
		/// <c>TCHARs</c>. If <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> is set, this parameter specifies the minimum number of <c>TCHARs</c> to
		/// allocate for an output buffer.
		/// </para>
		/// <para>The output buffer cannot be larger than 64K bytes.</para>
		/// </param>
		/// <param name="Arguments">
		/// <para>
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value
		/// in the Arguments array; a %2 indicates the second argument; and so on.
		/// </para>
		/// <para>
		/// The interpretation of each value depends on the formatting information associated with the insert in the message definition. The
		/// default is to treat each value as a pointer to a null-terminated string.
		/// </para>
		/// <para>
		/// By default, the Arguments parameter is of type <c>va_list*</c>, which is a language- and implementation-specific data type for
		/// describing a variable number of arguments. The state of the <c>va_list</c> argument is undefined upon return from the function.
		/// To use the <c>va_list</c> again, destroy the variable argument list pointer using <c>va_end</c> and reinitialize it with <c>va_start</c>.
		/// </para>
		/// <para>
		/// If you do not have a pointer of type <c>va_list*</c>, then specify the <c>FORMAT_MESSAGE_ARGUMENT_ARRAY</c> flag and pass a
		/// pointer to an array of <c>DWORD_PTR</c> values; those values are input to the message formatted as the insert values. Each insert
		/// must have a corresponding element in the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of <c>TCHARs</c> stored in the output buffer, excluding the terminating
		/// null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI FormatMessage( _In_ DWORD dwFlags, _In_opt_ LPCVOID lpSource, _In_ DWORD dwMessageId, _In_ DWORD dwLanguageId, _Out_
		// LPTSTR lpBuffer, _In_ DWORD nSize, _In_opt_ va_list *Arguments); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679351(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static extern int FormatMessage(FormatMessageFlags dwFlags, HINSTANCE lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, string[] Arguments);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer
		/// passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the
		/// function to search the system's message table resource(s) for the message definition. The function finds the message definition
		/// in a message table resource based on a message identifier and a language identifier. The function copies the formatted message
		/// text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function
		/// handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORMAT_MESSAGE_ALLOCATE_BUFFER0x00000100</term>
		/// <term>
		/// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the
		/// address specified by lpBuffer. The lpBuffer parameter is a pointer to an LPTSTR; you must cast the pointer to an LPTSTR (for
		/// example, ). The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller
		/// should use the LocalFree function to free the buffer when it is no longer needed.If the length of the formatted message exceeds
		/// 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.In previous versions
		/// of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
		/// Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then FormatMessage will not
		/// automatically fail with an error of ERROR_MORE_DATA.Windows 10: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE.
		/// FormatMessage() uses LMEM_FIXED, so HeapFree can be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_ARGUMENT_ARRAY0x00002000</term>
		/// <term>
		/// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.This flag
		/// cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		/// <term>
		/// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL,
		/// the current process's application image file will be searched. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If the
		/// module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		/// <term>
		/// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may
		/// contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with
		/// FORMAT_MESSAGE_FROM_HMODULE or FORMAT_MESSAGE_FROM_SYSTEM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_SYSTEM0x00001000</term>
		/// <term>
		/// The function should search the system message-table resource(s) for the requested message. If this flag is specified with
		/// FORMAT_MESSAGE_FROM_HMODULE, the function searches the system message table if the message is not found in the module specified
		/// by lpSource. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If this flag is specified, an application can pass the
		/// result of the GetLastError function to retrieve the message text for a system-defined error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_IGNORE_INSERTS0x00000200</term>
		/// <term>
		/// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is
		/// useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The low-order byte of dwFlags can specify the maximum width of a formatted output line. The following are possible values of the
		/// low-order byte.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// There are no output line width restrictions. The function stores line breaks that are in the message definition text into the
		/// output buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_MAX_WIDTH_MASK0x000000FF</term>
		/// <term>
		/// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the
		/// message definition text into the output buffer. The function generates no new line breaks.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the low-order byte is a nonzero value other than <c>FORMAT_MESSAGE_MAX_WIDTH_MASK</c>, it specifies the maximum number of
		/// characters in an output line. The function ignores regular line breaks in the message definition text. The function never splits
		/// a string delimited by white space across a line break. The function stores hard-coded line breaks in the message definition text
		/// into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
		/// </para>
		/// </param>
		/// <param name="lpSource">
		/// <para>The location of the message definition. The type of this parameter depends upon the settings in the dwFlags parameter.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>dwFlags Setting</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		/// <term>A handle to the module that contains the message table to search.</term>
		/// </item>
		/// <item>
		/// <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		/// <term>Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>If neither of these flags is set in dwFlags, then lpSource is ignored.</para>
		/// </param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</param>
		/// <param name="dwLanguageId">
		/// <para>The language identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</para>
		/// <para>
		/// If you pass a specific <c>LANGID</c> in this parameter, <c>FormatMessage</c> will return a message for that <c>LANGID</c> only.
		/// If the function cannot find a message for that <c>LANGID</c>, it sets Last-Error to <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>. If you
		/// pass in zero, <c>FormatMessage</c> looks for a message for <c>LANGIDs</c> in the following order:
		/// </para>
		/// <para>
		/// If <c>FormatMessage</c> does not locate a message for any of the preceding <c>LANGIDs</c>, it returns any language message string
		/// that is present. If that fails, it returns <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>.
		/// </para>
		/// </param>
		/// <param name="lpBuffer">
		/// <para>
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c>, the function allocates a buffer using the <c>LocalAlloc</c> function, and places the
		/// pointer to the buffer at the address specified in lpBuffer.
		/// </para>
		/// <para>This buffer cannot be larger than 64K bytes.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>
		/// If the <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> flag is not set, this parameter specifies the size of the output buffer, in
		/// <c>TCHARs</c>. If <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> is set, this parameter specifies the minimum number of <c>TCHARs</c> to
		/// allocate for an output buffer.
		/// </para>
		/// <para>The output buffer cannot be larger than 64K bytes.</para>
		/// </param>
		/// <param name="Arguments">
		/// <para>
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value
		/// in the Arguments array; a %2 indicates the second argument; and so on.
		/// </para>
		/// <para>
		/// The interpretation of each value depends on the formatting information associated with the insert in the message definition. The
		/// default is to treat each value as a pointer to a null-terminated string.
		/// </para>
		/// <para>
		/// By default, the Arguments parameter is of type <c>va_list*</c>, which is a language- and implementation-specific data type for
		/// describing a variable number of arguments. The state of the <c>va_list</c> argument is undefined upon return from the function.
		/// To use the <c>va_list</c> again, destroy the variable argument list pointer using <c>va_end</c> and reinitialize it with <c>va_start</c>.
		/// </para>
		/// <para>
		/// If you do not have a pointer of type <c>va_list*</c>, then specify the <c>FORMAT_MESSAGE_ARGUMENT_ARRAY</c> flag and pass a
		/// pointer to an array of <c>DWORD_PTR</c> values; those values are input to the message formatted as the insert values. Each insert
		/// must have a corresponding element in the array.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of <c>TCHARs</c> stored in the output buffer, excluding the terminating
		/// null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, string[] Arguments);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a buffer
		/// passed into the function. It can come from a message table resource in an already-loaded module. Or the caller can ask the
		/// function to search the system's message table resource(s) for the message definition. The function finds the message definition
		/// in a message table resource based on a message identifier and a language identifier. The function copies the formatted message
		/// text to an output buffer, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="dwFlags"><para>
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function
		/// handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>
		///   <list type="table">
		///     <listheader>
		///       <term>Value</term>
		///       <term>Meaning</term>
		///     </listheader>
		///     <item>
		///       <term>FORMAT_MESSAGE_ALLOCATE_BUFFER0x00000100</term>
		///       <term>
		/// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the
		/// address specified by lpBuffer. The lpBuffer parameter is a pointer to an LPTSTR; you must cast the pointer to an LPTSTR (for
		/// example, ). The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller
		/// should use the LocalFree function to free the buffer when it is no longer needed.If the length of the formatted message exceeds
		/// 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.In previous versions
		/// of Windows, this value was not available for use when compiling Windows Store apps. As of Windows 10 this value can be used.
		/// Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then FormatMessage will not
		/// automatically fail with an error of ERROR_MORE_DATA.Windows 10: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE.
		/// FormatMessage() uses LMEM_FIXED, so HeapFree can be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_ARGUMENT_ARRAY0x00002000</term>
		///       <term>
		/// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.This flag
		/// cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		///       <term>
		/// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL,
		/// the current process's application image file will be searched. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If the
		/// module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		///       <term>
		/// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may
		/// contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with
		/// FORMAT_MESSAGE_FROM_HMODULE or FORMAT_MESSAGE_FROM_SYSTEM.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_FROM_SYSTEM0x00001000</term>
		///       <term>
		/// The function should search the system message-table resource(s) for the requested message. If this flag is specified with
		/// FORMAT_MESSAGE_FROM_HMODULE, the function searches the system message table if the message is not found in the module specified
		/// by lpSource. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.If this flag is specified, an application can pass the
		/// result of the GetLastError function to retrieve the message text for a system-defined error.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_IGNORE_INSERTS0x00000200</term>
		///       <term>
		/// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is
		/// useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
		/// </term>
		///     </item>
		///   </list>
		/// </para>
		/// <para>
		/// The low-order byte of dwFlags can specify the maximum width of a formatted output line. The following are possible values of the
		/// low-order byte.
		/// </para>
		/// <para>
		///   <list type="table">
		///     <listheader>
		///       <term>Value</term>
		///       <term>Meaning</term>
		///     </listheader>
		///     <item>
		///       <term>0</term>
		///       <term>
		/// There are no output line width restrictions. The function stores line breaks that are in the message definition text into the
		/// output buffer.
		/// </term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_MAX_WIDTH_MASK0x000000FF</term>
		///       <term>
		/// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the
		/// message definition text into the output buffer. The function generates no new line breaks.
		/// </term>
		///     </item>
		///   </list>
		/// </para>
		/// <para>
		/// If the low-order byte is a nonzero value other than <c>FORMAT_MESSAGE_MAX_WIDTH_MASK</c>, it specifies the maximum number of
		/// characters in an output line. The function ignores regular line breaks in the message definition text. The function never splits
		/// a string delimited by white space across a line break. The function stores hard-coded line breaks in the message definition text
		/// into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
		/// </para></param>
		/// <param name="lpSource"><para>The location of the message definition. The type of this parameter depends upon the settings in the dwFlags parameter.</para>
		/// <para>
		///   <list type="table">
		///     <listheader>
		///       <term>dwFlags Setting</term>
		///       <term>Meaning</term>
		///     </listheader>
		///     <item>
		///       <term>FORMAT_MESSAGE_FROM_HMODULE0x00000800</term>
		///       <term>A handle to the module that contains the message table to search.</term>
		///     </item>
		///     <item>
		///       <term>FORMAT_MESSAGE_FROM_STRING0x00000400</term>
		///       <term>Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.</term>
		///     </item>
		///   </list>
		/// </para>
		/// <para>If neither of these flags is set in dwFlags, then lpSource is ignored.</para></param>
		/// <param name="dwMessageId">The message identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</param>
		/// <param name="dwLanguageId"><para>The language identifier for the requested message. This parameter is ignored if dwFlags includes <c>FORMAT_MESSAGE_FROM_STRING</c>.</para>
		/// <para>
		/// If you pass a specific <c>LANGID</c> in this parameter, <c>FormatMessage</c> will return a message for that <c>LANGID</c> only.
		/// If the function cannot find a message for that <c>LANGID</c>, it sets Last-Error to <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>. If you
		/// pass in zero, <c>FormatMessage</c> looks for a message for <c>LANGIDs</c> in the following order:
		/// </para>
		/// <para>
		/// If <c>FormatMessage</c> does not locate a message for any of the preceding <c>LANGIDs</c>, it returns any language message string
		/// that is present. If that fails, it returns <c>ERROR_RESOURCE_LANG_NOT_FOUND</c>.
		/// </para></param>
		/// <param name="lpBuffer"><para>
		/// A pointer to a buffer that receives the null-terminated string that specifies the formatted message. If dwFlags includes
		/// <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c>, the function allocates a buffer using the <c>LocalAlloc</c> function, and places the
		/// pointer to the buffer at the address specified in lpBuffer.
		/// </para>
		/// <para>This buffer cannot be larger than 64K bytes.</para></param>
		/// <param name="nSize"><para>
		/// If the <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> flag is not set, this parameter specifies the size of the output buffer, in
		/// <c>TCHARs</c>. If <c>FORMAT_MESSAGE_ALLOCATE_BUFFER</c> is set, this parameter specifies the minimum number of <c>TCHARs</c> to
		/// allocate for an output buffer.
		/// </para>
		/// <para>The output buffer cannot be larger than 64K bytes.</para></param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of <c>TCHARs</c> stored in the output buffer, excluding the terminating
		/// null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI FormatMessage( _In_ DWORD dwFlags, _In_opt_ LPCVOID lpSource, _In_ DWORD dwMessageId, _In_ DWORD dwLanguageId, _Out_
		// LPTSTR lpBuffer, _In_ DWORD nSize, _In_opt_ va_list *Arguments); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679351(v=vs.85).aspx
		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		private static extern int FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, __arglist);

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message
		/// table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s)
		/// for the message definition. The function finds the message definition in a message table resource based on a message identifier
		/// and a language identifier. The function returns the formatted message text, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="id">The message identifier for the requested message.</param>
		/// <param name="args">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value
		/// in the Arguments array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting
		/// information associated with the insert in the message definition. Each insert must have a corresponding element in the array.
		/// </param>
		/// <param name="hLib">A handle to the module that contains the message table to search.</param>
		/// <param name="flags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function
		/// handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <param name="langId">
		/// The language identifier for the requested message. If you pass a specific LANGID in this parameter, FormatMessage will return a
		/// message for that LANGID only. If the function cannot find a message for that LANGID, it sets Last-Error to
		/// ERROR_RESOURCE_LANG_NOT_FOUND. If you pass in zero, FormatMessage looks for a message for LANGIDs in the following order:
		/// Language neutral Thread LANGID, based on the thread's locale value User default LANGID, based on the user's default locale value
		/// System default LANGID, based on the system default locale value US English If FormatMessage does not locate a message for any of
		/// the preceding LANGIDs, it returns any language message string that is present. If that fails, it returns ERROR_RESOURCE_LANG_NOT_FOUND.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information,
		/// call GetLastError.
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms679351")]
		public static string FormatMessage(uint id, string[] args = null, HINSTANCE hLib = default, FormatMessageFlags flags = 0, uint langId = 0)
		{
			flags &= ~FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING;
			flags |= FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER | FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM;
			if (!hLib.IsNull) flags |= FormatMessageFlags.FORMAT_MESSAGE_FROM_HMODULE;
			if (args != null && args.Length > 0 && !flags.IsFlagSet(FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS)) flags |= FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;
			var ptr = IntPtr.Zero;
			var ret = FormatMessage(flags, hLib, id, langId, ref ptr, 0, args);
			if (ret == 0) Win32Error.ThrowLastError();
			return new SafeLocalHandle(ptr, 0).ToString(-1);
		}

		/// <summary>
		/// Formats a message string. The function requires a message definition as input. The message definition can come from a message
		/// table resource in an already-loaded module. Or the caller can ask the function to search the system's message table resource(s)
		/// for the message definition. The function finds the message definition in a message table resource based on a message identifier
		/// and a language identifier. The function returns the formatted message text, processing any embedded insert sequences if requested.
		/// </summary>
		/// <param name="formatString">
		/// Pointer to a string that consists of unformatted message text. It will be scanned for inserts and formatted accordingly.
		/// </param>
		/// <param name="args">
		/// An array of values that are used as insert values in the formatted message. A %1 in the format string indicates the first value
		/// in the Arguments array; a %2 indicates the second argument; and so on. The interpretation of each value depends on the formatting
		/// information associated with the insert in the message definition. Each insert must have a corresponding element in the array.
		/// </param>
		/// <param name="flags">
		/// The formatting options, and how to interpret the lpSource parameter. The low-order byte of dwFlags specifies how the function
		/// handles line breaks in the output buffer. The low-order byte can also specify the maximum width of a formatted output line.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the string that specifies the formatted message. To get extended error information,
		/// call GetLastError.
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

		/// <summary>Retrieves the error mode for the current process.</summary>
		/// <returns>
		/// <para>The process error mode. This function returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEM_FAILCRITICALERRORS0x0001</term>
		/// <term>
		/// The system does not display the critical-error-handler message box. Instead, the system sends the error to the calling process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOALIGNMENTFAULTEXCEPT0x0004</term>
		/// <term>
		/// The system automatically fixes memory alignment faults and makes them invisible to the application. It does this for the calling
		/// process and any descendant processes. This feature is only supported by certain processor architectures. For more information,
		/// see SetErrorMode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOGPFAULTERRORBOX0x0002</term>
		/// <term>The system does not display the Windows Error Reporting dialog.</term>
		/// </item>
		/// <item>
		/// <term>SEM_NOOPENFILEERRORBOX0x8000</term>
		/// <term>
		/// The system does not display a message box when it fails to find a file. Instead, the error is returned to the calling process.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// UINT WINAPI GetErrorMode(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms679355(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679355")]
		public static extern uint GetErrorMode();

		/// <summary>
		/// <para>
		/// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads
		/// do not overwrite each other's last-error code.
		/// </para>
		/// <para><c>Visual Basic:</c> Applications should call <c>err.LastDllError</c> instead of <c>GetLastError</c>.</para>
		/// </summary>
		/// <returns>
		/// <para>The return value is the calling thread's last-error code.</para>
		/// <para>
		/// The Return Value section of the documentation for each function that sets the last-error code notes the conditions under which
		/// the function sets the last-error code. Most functions that set the thread's last-error code set it when they fail. However, some
		/// functions also set the last-error code when they succeed. If the function is not documented to set the last-error code, the value
		/// returned by this function is simply the most recent last-error code to have been set; some functions set the last-error code to 0
		/// on success and others do not.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetLastError(void);// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679360(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms679360")]
		public static extern Win32Error GetLastError();

		/// <summary>Retrieves the error mode for the calling thread.</summary>
		/// <returns>
		/// <para>The process error mode. This function returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEM_FAILCRITICALERRORS = 0x0001</term>
		/// <term>
		/// The system does not display the critical-error-handler message box. Instead, the system sends the error to the calling process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOGPFAULTERRORBOX = 0x0002</term>
		/// <term>The system does not display the Windows Error Reporting dialog.</term>
		/// </item>
		/// <item>
		/// <term>SEM_NOOPENFILEERRORBOX = 0x8000</term>
		/// <term>
		/// The system does not display a message box when it fails to find a file. Instead, the error is returned to the calling process.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd553629")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadErrorMode(uint dwNewMode, out uint lpOldMode);

		/// <summary>Raises an exception in the calling thread.</summary>
		/// <param name="dwExceptionCode">
		/// <para>
		/// An application-defined exception code of the exception being raised. The filter expression and exception-handler block of an
		/// exception handler can use the <c>GetExceptionCode</c> function to retrieve this value.
		/// </para>
		/// <para>
		/// Note that the system will clear bit 28 of dwExceptionCode before displaying a message This bit is a reserved exception bit, used
		/// by the system for its own purposes.
		/// </para>
		/// </param>
		/// <param name="dwExceptionFlags">
		/// The exception flags. This can be either zero to indicate a continuable exception, or EXCEPTION_NONCONTINUABLE to indicate a
		/// noncontinuable exception. Any attempt to continue execution after a noncontinuable exception causes the
		/// EXCEPTION_NONCONTINUABLE_EXCEPTION exception.
		/// </param>
		/// <param name="nNumberOfArguments">
		/// The number of arguments in the lpArguments array. This value must not exceed EXCEPTION_MAXIMUM_PARAMETERS. This parameter is
		/// ignored if lpArguments is <c>NULL</c>.
		/// </param>
		/// <param name="lpArguments">
		/// An array of arguments. This parameter can be <c>NULL</c>. These arguments can contain any application-defined data that needs to
		/// be passed to the filter expression of the exception handler.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// void WINAPI RaiseException( _In_ DWORD dwExceptionCode, _In_ DWORD dwExceptionFlags, _In_ DWORD nNumberOfArguments, _In_ const ULONG_PTR
		// *lpArguments); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680552(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680552")]
		public static extern void RaiseException(uint dwExceptionCode, EXCEPTION_FLAG dwExceptionFlags, uint nNumberOfArguments, [In] IntPtr lpArguments);

		/// <summary>
		/// Raises an exception that bypasses all exception handlers (frame or vector based). Raising this exception terminates the
		/// application and invokes Windows Error Reporting, if Windows Error Reporting is enabled.
		/// </summary>
		/// <param name="pExceptionRecord">
		/// <para>
		/// A pointer to an <c>EXCEPTION_RECORD</c> structure that contains the exception information. You must specify the
		/// <c>ExceptionAddress</c> and <c>ExceptionCode</c> members.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function creates an exception record and sets the <c>ExceptionCode</c> member to
		/// STATUS_FAIL_FAST_EXCEPTION. The function will also set the <c>ExceptionAddress</c> member if the dwFlags parameter contains the
		/// FAIL_FAST_GENERATE_EXCEPTION_ADDRESS flag.
		/// </para>
		/// </param>
		/// <param name="pContextRecord">
		/// A pointer to a <c>CONTEXT</c> structure that contains the context information. If <c>NULL</c>, this function generates the
		/// context (however, the context will not exactly match the context of the caller).
		/// </param>
		/// <param name="dwFlags">
		/// <para>You can specify zero or the following flag that control this function's behavior:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FAIL_FAST_GENERATE_EXCEPTION_ADDRESS0x1</term>
		/// <term>
		/// Causes RaiseFailFastException to set the ExceptionAddress of EXCEPTION_RECORD to the return address of this function (the next
		/// instruction in the caller after the call to RaiseFailFastException). This function will set the exception address only if
		/// ExceptionAddress is not NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI RaiseFailFastException( _In_opt_ PEXCEPTION_RECORD pExceptionRecord, _In_opt_ PCONTEXT pContextRecord, _In_ DWORD
		// dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd941688(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd941688")]
		public static extern void RaiseFailFastException(ref EXCEPTION_RECORD pExceptionRecord, IntPtr pContextRecord, FAIL_FAST_FLAGS dwFlags);

		/// <summary>Unregisters a vectored continue handler.</summary>
		/// <param name="Handler">
		/// A pointer to a vectored exception handler previously registered using the <c>AddVectoredContinueHandler</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// ULONG WINAPI RemoveVectoredContinueHandler( _In_ PVOID Handler); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680567(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680567")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveVectoredContinueHandler([In] IntPtr Handler);

		/// <summary>Unregisters a vectored exception handler.</summary>
		/// <param name="Handler">
		/// A handle to the vectored exception handler previously registered using the <c>AddVectoredExceptionHandler</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// ULONG WINAPI RemoveVectoredExceptionHandler( _In_ PVOID Handler);
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680571")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RemoveVectoredExceptionHandler([In] IntPtr Handler);

		/// <summary>Restores the last-error code for the calling thread.</summary>
		/// <param name="dwErrCode">The last-error code for the thread.</param>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "")]
		public static extern void RestoreLastError(uint dwErrCode);

		/// <summary>
		/// Controls whether the system will handle the specified types of serious errors or whether the process will handle them.
		/// </summary>
		/// <param name="uMode">
		/// <para>The process error mode. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Use the system default, which is to display all error dialog boxes.</term>
		/// </item>
		/// <item>
		/// <term>SEM_FAILCRITICALERRORS0x0001</term>
		/// <term>
		/// The system does not display the critical-error-handler message box. Instead, the system sends the error to the calling
		/// process.Best practice is that all applications call the process-wide SetErrorMode function with a parameter of
		/// SEM_FAILCRITICALERRORS at startup. This is to prevent error mode dialogs from hanging the application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOALIGNMENTFAULTEXCEPT0x0004</term>
		/// <term>
		/// The system automatically fixes memory alignment faults and makes them invisible to the application. It does this for the calling
		/// process and any descendant processes. This feature is only supported by certain processor architectures. For more information,
		/// see the Remarks section. After this value is set for a process, subsequent attempts to clear the value are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOGPFAULTERRORBOX0x0002</term>
		/// <term>The system does not display the Windows Error Reporting dialog.</term>
		/// </item>
		/// <item>
		/// <term>SEM_NOOPENFILEERRORBOX0x8000</term>
		/// <term>
		/// The OpenFile function does not display a message box when it fails to find a file. Instead, the error is returned to the caller.
		/// This error mode overrides the OF_PROMPT flag.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>The return value is the previous state of the error-mode bit flags.</returns>
		// UINT WINAPI SetErrorMode( _In_ UINT uMode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680621(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680621")]
		public static extern uint SetErrorMode(uint uMode);

		/// <summary>Sets the last-error code for the calling thread.</summary>
		/// <param name="dwErrCode">The last-error code for the thread.</param>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680627")]
		public static extern void SetLastError(uint dwErrCode);

		/// <summary>
		/// Controls whether the system will handle the specified types of serious errors or whether the calling thread will handle them.
		/// </summary>
		/// <param name="dwNewMode">
		/// <para>The thread error mode. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Use the system default, which is to display all error dialog boxes.</term>
		/// </item>
		/// <item>
		/// <term>SEM_FAILCRITICALERRORS0x0001</term>
		/// <term>
		/// The system does not display the critical-error-handler message box. Instead, the system sends the error to the calling
		/// thread.Best practice is that all applications call the process-wide SetErrorMode function with a parameter of
		/// SEM_FAILCRITICALERRORS at startup. This is to prevent error mode dialogs from hanging the application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEM_NOGPFAULTERRORBOX0x0002</term>
		/// <term>The system does not display the Windows Error Reporting dialog.</term>
		/// </item>
		/// <item>
		/// <term>SEM_NOOPENFILEERRORBOX0x8000</term>
		/// <term>
		/// The OpenFile function does not display a message box when it fails to find a file. Instead, the error is returned to the caller.
		/// This error mode overrides the OF_PROMPT flag.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpOldMode">
		/// If the function succeeds, this parameter is set to the thread's previous error mode. This parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL SetThreadErrorMode( _In_ DWORD dwNewMode, _Out_ LPDWORD lpOldMode); https://msdn.microsoft.com/en-us/library/windows/desktop/dd553630(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd553630")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadErrorMode(uint dwNewMode, out uint lpOldMode);

		/// <summary>
		/// <para>Enables an application to supersede the top-level exception handler of each thread of a process.</para>
		/// <para>
		/// After calling this function, if an exception occurs in a process that is not being debugged, and the exception makes it to the
		/// unhandled exception filter, that filter will call the exception filter function specified by the lpTopLevelExceptionFilter parameter.
		/// </para>
		/// </summary>
		/// <param name="lpTopLevelExceptionFilter">
		/// <para>
		/// A pointer to a top-level exception filter function that will be called whenever the <c>UnhandledExceptionFilter</c> function gets
		/// control, and the process is not being debugged. A value of <c>NULL</c> for this parameter specifies default handling within <c>UnhandledExceptionFilter</c>.
		/// </para>
		/// <para>
		/// The filter function has syntax similar to that of <c>UnhandledExceptionFilter</c>: It takes a single parameter of type
		/// <c>LPEXCEPTION_POINTERS</c>, has a WINAPI calling convention, and returns a value of type <c>LONG</c>. The filter function should
		/// return one of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EXCEPTION_EXECUTE_HANDLER0x1</term>
		/// <term>Return from UnhandledExceptionFilter and execute the associated exception handler. This usually results in process termination.</term>
		/// </item>
		/// <item>
		/// <term>EXCEPTION_CONTINUE_EXECUTION0xffffffff</term>
		/// <term>
		/// Return from UnhandledExceptionFilter and continue execution from the point of the exception. Note that the filter function is
		/// free to modify the continuation state by modifying the exception information supplied through its LPEXCEPTION_POINTERS parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EXCEPTION_CONTINUE_SEARCH0x0</term>
		/// <term>
		/// Proceed with normal execution of UnhandledExceptionFilter. That means obeying the SetErrorMode flags, or invoking the Application
		/// Error pop-up message box.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// The <c>SetUnhandledExceptionFilter</c> function returns the address of the previous exception filter established with the
		/// function. A <c>NULL</c> return value means that there is no current top-level exception handler.
		/// </returns>
		// LPTOP_LEVEL_EXCEPTION_FILTER WINAPI SetUnhandledExceptionFilter( _In_ LPTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter); https://msdn.microsoft.com/en-us/library/windows/desktop/ms680634(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms680634")]
		public static extern PTOP_LEVEL_EXCEPTION_FILTER SetUnhandledExceptionFilter(PTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter);

		/// <summary>Undocumented.</summary>
		/// <param name="FailedAllocationSize">Size of the failed allocation.</param>
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "")]
		public static extern void TerminateProcessOnMemoryExhaustion(SizeT FailedAllocationSize);

		/// <summary>
		/// An application-defined function that passes unhandled exceptions to the debugger, if the process is being debugged. Otherwise, it
		/// optionally displays an <c>Application Error</c> message box and causes the exception handler to be executed. This function can be
		/// called only from within the filter expression of an exception handler.
		/// </summary>
		/// <param name="ExceptionInfo">
		/// A pointer to an <c>EXCEPTION_POINTERS</c> structure that specifies a description of the exception and the processor context at
		/// the time of the exception. This pointer is the return value of a call to the <c>GetExceptionInformation</c> function.
		/// </param>
		/// <returns>
		/// <para>The function returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EXCEPTION_CONTINUE_SEARCH0x0</term>
		/// <term>The process is being debugged, so the exception should be passed (as second chance) to the application's debugger.</term>
		/// </item>
		/// <item>
		/// <term>EXCEPTION_EXECUTE_HANDLER0x1</term>
		/// <term>
		/// If the SEM_NOGPFAULTERRORBOX flag was specified in a previous call to SetErrorMode, no Application Error message box is
		/// displayed. The function returns control to the exception handler, which is free to take any appropriate action.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// LONG WINAPI UnhandledExceptionFilter( _In_ struct _EXCEPTION_POINTERS *ExceptionInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681401(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms681401")]
		public static extern EXCEPTION_FLAG UnhandledExceptionFilter(in EXCEPTION_POINTERS ExceptionInfo);

		/// <summary>
		/// Contains an exception record with a machine-independent description of an exception and a context record with a machine-dependent
		/// description of the processor context at the time of the exception.
		/// </summary>
		// typedef struct _EXCEPTION_POINTERS { PEXCEPTION_RECORD ExceptionRecord; PCONTEXT ContextRecord;} EXCEPTION_POINTERS, *PEXCEPTION_POINTERS;
		[PInvokeData("WinNT.h", MSDNShortId = "ms679331")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EXCEPTION_POINTERS
		{
			/// <summary>A pointer to an <c>EXCEPTION_RECORD</c> structure that contains a machine-independent description of the exception.</summary>
			public IntPtr ExceptionRecord;
			/// <summary>
			/// A pointer to a <c>CONTEXT</c> structure that contains a processor-specific description of the state of the processor at the
			/// time of the exception.
			/// </summary>
			public IntPtr ContextRecord;
		}

		/// <summary>Describes an exception.</summary>
		// typedef struct _EXCEPTION_RECORD { DWORD ExceptionCode; DWORD ExceptionFlags; struct _EXCEPTION_RECORD *ExceptionRecord; PVOID
		// ExceptionAddress; DWORD NumberParameters; ULONG_PTR ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS];} EXCEPTION_RECORD, *PEXCEPTION_RECORD;
		[PInvokeData("WinNT.h", MSDNShortId = "aa363082")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EXCEPTION_RECORD
		{
			/// <summary>
			/// The exception flags. This member can be either zero, indicating a continuable exception, or <c>EXCEPTION_NONCONTINUABLE</c>
			/// indicating a noncontinuable exception. Any attempt to continue execution after a noncontinuable exception causes the
			/// <c>EXCEPTION_NONCONTINUABLE_EXCEPTION</c> exception.
			/// </summary>
			public uint ExceptionCode;
			/// <summary>
			/// The exception flags. This member can be either zero, indicating a continuable exception, or <c>EXCEPTION_NONCONTINUABLE</c>
			/// indicating a noncontinuable exception. Any attempt to continue execution after a noncontinuable exception causes the
			/// <c>EXCEPTION_NONCONTINUABLE_EXCEPTION</c> exception.
			/// </summary>
			public EXCEPTION_FLAG ExceptionFlags;
			/// <summary>
			/// A pointer to an associated <c>EXCEPTION_RECORD</c> structure. Exception records can be chained together to provide additional
			/// information when nested exceptions occur.
			/// </summary>
			public IntPtr ExceptionRecord;
			/// <summary>The address where the exception occurred.</summary>
			public IntPtr ExceptionAddress;
			/// <summary>
			/// The number of parameters associated with the exception. This is the number of defined elements in the
			/// <c>ExceptionInformation</c> array.
			/// </summary>
			public uint NumberParameters;
			/// <summary>
			/// <para>
			/// An array of additional arguments that describe the exception. The <c>RaiseException</c> function can specify this array of
			/// arguments. For most exception codes, the array elements are undefined. The following table describes the exception codes
			/// whose array elements are defined.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Exception code</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EXCEPTION_ACCESS_VIOLATION</term>
			/// <term>
			/// The first element of the array contains a read-write flag that indicates the type of operation that caused the access
			/// violation. If this value is zero, the thread attempted to read the inaccessible data. If this value is 1, the thread
			/// attempted to write to an inaccessible address. If this value is 8, the thread causes a user-mode data execution prevention
			/// (DEP) violation.The second array element specifies the virtual address of the inaccessible data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>EXCEPTION_IN_PAGE_ERROR</term>
			/// <term>
			/// The first element of the array contains a read-write flag that indicates the type of operation that caused the access
			/// violation. If this value is zero, the thread attempted to read the inaccessible data. If this value is 1, the thread
			/// attempted to write to an inaccessible address. If this value is 8, the thread causes a user-mode data execution prevention
			/// (DEP) violation. The second array element specifies the virtual address of the inaccessible data.The third array element
			/// specifies the underlying NTSTATUS code that resulted in the exception.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = EXCEPTION_MAXIMUM_PARAMETERS, ArraySubType = UnmanagedType.SysUInt)]
			public UIntPtr[] ExceptionInformation;
		}

		/// <summary>A safe handle for continue handler handles.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafeContinueHandlerHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeContinueHandlerHandle"/> class.</summary>
			public SafeContinueHandlerHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeContinueHandlerHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			public SafeContinueHandlerHandle(IntPtr handle) : base(handle, RemoveVectoredContinueHandler) { }
		}

		/// <summary>A safe handle for exception handler handles.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafeExceptionHandlerHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeExceptionHandlerHandle"/> class.</summary>
			public SafeExceptionHandlerHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeExceptionHandlerHandle"/> class.</summary>
			/// <param name="handle">The handle.</param>
			public SafeExceptionHandlerHandle(IntPtr handle) : base(handle, RemoveVectoredExceptionHandler) { }
		}
	}
}