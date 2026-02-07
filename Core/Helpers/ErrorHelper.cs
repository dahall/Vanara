using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Functions to help get error messages from error codes.</summary>
public static class ErrorHelper
{
	private static readonly Dictionary<Type, Func<uint, string?, string>> lookupHelpers = [];

	/// <summary>
	/// Adds the field lookup helper for a given library. The default lookup helper uses <c>FormatMessage</c> to fetch the help string from
	/// the named module.
	/// </summary>
	/// <param name="helper">The helper function that takes the error code and module name and returns a help message.</param>
	public static void AddErrorMessageLookupFunction<TType>(Func<uint, string?, string> helper) => lookupHelpers[typeof(TType)] = helper;

	/// <summary>Gets the error message associated with an error value.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <param name="id">The identifier.</param>
	/// <param name="lib">
	/// The library or module name to provide a helper for. This should match the <c>lib</c> param used by <see
	/// cref="StaticFieldValueHash.AddFields{TType, TFieldType}(IEnumerable{ValueTuple{TFieldType, string}}, string?)"/>.
	/// </param>
	/// <returns>The description of the error code.</returns>
	public static string GetErrorMessage<TType, TFieldType>(TFieldType id, string? lib = null) where TFieldType : struct, IComparable, IConvertible
	{
		if (!lookupHelpers.TryGetValue(typeof(TType), out var lookupFunc))
			lookupFunc = FormatMessage;
		return lookupFunc(unchecked((uint)id.ToInt64(null)), lib ?? StaticFieldValueHash.GetFieldLib<TType, TFieldType>(id));
	}

	/// <summary>Formats the message.</summary>
	/// <param name="id">The error.</param>
	/// <param name="lib">The optional library.</param>
	/// <returns>The string.</returns>
	private static string FormatMessage(uint id, string? lib = null)
	{
		var flags = lib is null ? 0x1200U /*FORMAT_MESSAGE_IGNORE_INSERTS | FORMAT_MESSAGE_FROM_SYSTEM*/ : 0xA00U /*FORMAT_MESSAGE_IGNORE_INSERTS | FORMAT_MESSAGE_FROM_HMODULE*/;
		HINSTANCE hInst = lib is null ? default : LoadLibraryEx(lib, default, 0x1002 /*LOAD_LIBRARY_SEARCH_DEFAULT_DIRS | LOAD_LIBRARY_AS_DATAFILE*/);
		var buf = new StringBuilder(1024);
		try
		{
			do
			{
				if (0 != FormatMessage(flags, hInst, id, 0, buf, (uint)buf.Capacity, default))
					return buf.ToString();
				var lastError = unchecked((uint)Marshal.GetLastWin32Error());
				if (lastError is Win32Error.ERROR_MR_MID_NOT_FOUND or Win32Error.ERROR_MUI_FILE_NOT_FOUND or Win32Error.ERROR_RESOURCE_TYPE_NOT_FOUND)
					break;
				if (lastError != Win32Error.ERROR_INSUFFICIENT_BUFFER)
					((Win32Error)lastError).ThrowIfFailed();
				buf.Capacity *= 2;
			} while (true && buf.Capacity < 1024 * 16); // Don't go crazy
		}
		finally
		{
			if (hInst != default)
				FreeLibrary(hInst);
		}
		return string.Empty;
	}

	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	private static extern int FormatMessage(uint dwFlags, HINSTANCE lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, uint nSize, IntPtr Arguments);

	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FreeLibrary([In] HINSTANCE hLibModule);

	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	private static extern HINSTANCE LoadLibraryEx([MarshalAs(UnmanagedType.LPTStr)] string lpLibFileName, HANDLE hFile, uint dwFlags);
}