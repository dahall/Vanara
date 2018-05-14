using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Retrieves an integer associated with a key in the specified section of an initialization file.</summary>
		/// <param name="lpAppName">The name of the section in the initialization file.</param>
		/// <param name="lpKeyName">
		/// The name of the key whose value is to be retrieved. This value is in the form of a string; the <c>GetPrivateProfileInt</c> function converts the
		/// string into an integer and returns the integer.
		/// </param>
		/// <param name="nDefault">The default value to return if the key name cannot be found in the initialization file.</param>
		/// <param name="lpFileName">
		/// The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
		/// </param>
		/// <returns>
		/// The return value is the integer equivalent of the string following the specified key name in the specified initialization file. If the key is not
		/// found, the return value is the specified default value.
		/// </returns>
		// UINT WINAPI GetPrivateProfileInt( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ INT nDefault, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724345(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724345")]
		public static extern uint GetPrivateProfileInt([In] string lpAppName, [In] string lpKeyName, int nDefault, [In] string lpFileName);

		/// <summary>Retrieves all the keys and values for the specified section of an initialization file.</summary>
		/// <param name="lpAppName">The name of the section in the initialization file.</param>
		/// <param name="lpReturnedString">
		/// A pointer to a buffer that receives the key name and value pairs associated with the named section. The buffer is filled with one or more
		/// null-terminated strings; the last string is followed by a second null character.
		/// </param>
		/// <param name="nSize">
		/// The size of the buffer pointed to by the lpReturnedString parameter, in characters. The maximum profile section size is 32,767 characters.
		/// </param>
		/// <param name="lpFileName">
		/// The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
		/// </param>
		/// <returns>
		/// The return value specifies the number of characters copied to the buffer, not including the terminating null character. If the buffer is not large
		/// enough to contain all the key name and value pairs associated with the named section, the return value is equal to nSize minus two.
		/// </returns>
		// DWORD WINAPI GetPrivateProfileSection( _In_ LPCTSTR lpAppName, _Out_ LPTSTR lpReturnedString, _In_ DWORD nSize, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724348(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724348")]
		public static extern uint GetPrivateProfileSection([In] string lpAppName, [Out] StringBuilder lpReturnedString, uint nSize, [In] string lpFileName);

		/// <summary>Retrieves the names of all sections in an initialization file.</summary>
		/// <param name="lpszReturnBuffer">
		/// A pointer to a buffer that receives the section names associated with the named file. The buffer is filled with one or more <c>null</c>-terminated
		/// strings; the last string is followed by a second <c>null</c> character.
		/// </param>
		/// <param name="nSize">The size of the buffer pointed to by the lpszReturnBuffer parameter, in characters.</param>
		/// <param name="lpFileName">
		/// The name of the initialization file. If this parameter is <c>NULL</c>, the function searches the Win.ini file. If this parameter does not contain a
		/// full path to the file, the system searches for the file in the Windows directory.
		/// </param>
		/// <returns>
		/// The return value specifies the number of characters copied to the specified buffer, not including the terminating <c>null</c> character. If the
		/// buffer is not large enough to contain all the section names associated with the specified initialization file, the return value is equal to the size
		/// specified by nSize minus two.
		/// </returns>
		// DWORD WINAPI GetPrivateProfileSectionNames( _Out_ LPTSTR lpszReturnBuffer, _In_ DWORD nSize, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724352(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724352")]
		public static extern uint GetPrivateProfileSectionNames([Out] StringBuilder lpszReturnBuffer, uint nSize, [In] string lpFileName);

		/// <summary>Retrieves a string from the specified section in an initialization file.</summary>
		/// <param name="lpAppName">
		/// The name of the section containing the key name. If this parameter is <c>NULL</c>, the <c>GetPrivateProfileString</c> function copies all section
		/// names in the file to the supplied buffer.
		/// </param>
		/// <param name="lpKeyName">
		/// The name of the key whose associated string is to be retrieved. If this parameter is <c>NULL</c>, all key names in the section specified by the
		/// lpAppName parameter are copied to the buffer specified by the lpReturnedString parameter.
		/// </param>
		/// <param name="lpDefault">
		/// <para>
		/// A default string. If the lpKeyName key cannot be found in the initialization file, <c>GetPrivateProfileString</c> copies the default string to the
		/// lpReturnedString buffer. If this parameter is <c>NULL</c>, the default is an empty string, "".
		/// </para>
		/// <para>
		/// Avoid specifying a default string with trailing blank characters. The function inserts a <c>null</c> character in the lpReturnedString buffer to
		/// strip any trailing blanks.
		/// </para>
		/// </param>
		/// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
		/// <param name="nSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
		/// <param name="lpFileName">
		/// The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
		/// </param>
		/// <returns>
		/// <para>The return value is the number of characters copied to the buffer, not including the terminating <c>null</c> character.</para>
		/// <para>
		/// If neither lpAppName nor lpKeyName is <c>NULL</c> and the supplied destination buffer is too small to hold the requested string, the string is
		/// truncated and followed by a <c>null</c> character, and the return value is equal to nSize minus one.
		/// </para>
		/// <para>
		/// If either lpAppName or lpKeyName is <c>NULL</c> and the supplied destination buffer is too small to hold all the strings, the last string is
		/// truncated and followed by two <c>null</c> characters. In this case, the return value is equal to nSize minus two.
		/// </para>
		/// <para>
		/// In the event the initialization file specified by lpFileName is not found, or contains invalid values, this function will set <c>errorno</c> with a
		/// value of '0x2' (File Not Found). To retrieve extended error information, call GetLastError.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetPrivateProfileString( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ LPCTSTR lpDefault, _Out_ LPTSTR lpReturnedString, _In_
		// DWORD nSize, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724353(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724353")]
		public static extern uint GetPrivateProfileString([In] string lpAppName, [In] string lpKeyName, [In] string lpDefault, [Out] StringBuilder lpReturnedString, uint nSize, [In] string lpFileName);

		/// <summary>
		/// Retrieves the data associated with a key in the specified section of an initialization file. As it retrieves the data, the function calculates a
		/// checksum and compares it with the checksum calculated by the <c>WritePrivateProfileStruct</c> function when the data was added to the file.
		/// </summary>
		/// <param name="lpszSection">The name of the section in the initialization file.</param>
		/// <param name="lpszKey">The name of the key whose data is to be retrieved.</param>
		/// <param name="lpStruct">A pointer to the buffer that receives the data associated with the file, section, and key names.</param>
		/// <param name="uSizeStruct">The size of the buffer pointed to by the lpStruct parameter, in bytes.</param>
		/// <param name="szFile">
		/// The name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL WINAPI GetPrivateProfileStruct( _In_ LPCTSTR lpszSection, _In_ LPCTSTR lpszKey, _Out_ LPVOID lpStruct, _In_ UINT uSizeStruct, _In_ LPCTSTR
		// szFile); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724356(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724356")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPrivateProfileStruct([In] string lpszSection, [In] string lpszKey, IntPtr lpStruct, uint uSizeStruct, [In] string szFile);

		/// <summary>Retrieves an integer from a key in the specified section of the Win.ini file.</summary>
		/// <param name="lpAppName">The name of the section containing the key name.</param>
		/// <param name="lpKeyName">
		/// The name of the key whose value is to be retrieved. This value is in the form of a string; the <c>GetProfileInt</c> function converts the string into
		/// an integer and returns the integer.
		/// </param>
		/// <param name="nDefault">The default value to return if the key name cannot be found in the initialization file.</param>
		/// <returns>
		/// The return value is the integer equivalent of the string following the key name in Win.ini. If the function cannot find the key, the return value is
		/// the default value. If the value of the key is less than zero, the return value is zero.
		/// </returns>
		// UINT WINAPI GetProfileInt( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ INT nDefault); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724360(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724360")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern uint GetProfileInt([In] string lpAppName, [In] string lpKeyName, int nDefault);

		/// <summary>Retrieves all the keys and values for the specified section of the Win.ini file.</summary>
		/// <param name="lpAppName">The name of the section in the Win.ini file.</param>
		/// <param name="lpReturnedString">
		/// A pointer to a buffer that receives the keys and values associated with the named section. The buffer is filled with one or more null-terminated
		/// strings; the last string is followed by a second null character.
		/// </param>
		/// <param name="nSize">
		/// The size of the buffer pointed to by the lpReturnedString parameter, in characters. The maximum profile section size is 32,767 characters.
		/// </param>
		/// <returns>
		/// The return value specifies the number of characters copied to the specified buffer, not including the terminating null character. If the buffer is
		/// not large enough to contain all the keys and values associated with the named section, the return value is equal to the size specified by nSize minus two.
		/// </returns>
		// DWORD WINAPI GetProfileSection( _In_ LPCTSTR lpAppName, _Out_ LPTSTR lpReturnedString, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724363(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724363")]
		public static extern uint GetProfileSection([In] string lpAppName, [Out] StringBuilder lpReturnedString, uint nSize);

		/// <summary>Retrieves the string associated with a key in the specified section of the Win.ini file.</summary>
		/// <param name="lpAppName">
		/// The name of the section containing the key. If this parameter is <c>NULL</c>, the function copies all section names in the file to the supplied buffer.
		/// </param>
		/// <param name="lpKeyName">
		/// The name of the key whose associated string is to be retrieved. If this parameter is <c>NULL</c>, the function copies all keys in the given section
		/// to the supplied buffer. Each string is followed by a <c>null</c> character, and the final string is followed by a second <c>null</c> character.
		/// </param>
		/// <param name="lpDefault">
		/// <para>
		/// A default string. If the lpKeyName key cannot be found in the initialization file, <c>GetProfileString</c> copies the default string to the
		/// lpReturnedString buffer. If this parameter is <c>NULL</c>, the default is an empty string, "".
		/// </para>
		/// <para>
		/// Avoid specifying a default string with trailing blank characters. The function inserts a <c>null</c> character in the lpReturnedString buffer to
		/// strip any trailing blanks.
		/// </para>
		/// </param>
		/// <param name="lpReturnedString">A pointer to a buffer that receives the character string.</param>
		/// <param name="nSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
		/// <returns>
		/// <para>The return value is the number of characters copied to the buffer, not including the <c>null</c>-terminating character.</para>
		/// <para>
		/// If neither lpAppName nor lpKeyName is <c>NULL</c> and the supplied destination buffer is too small to hold the requested string, the string is
		/// truncated and followed by a <c>null</c> character, and the return value is equal to nSize minus one.
		/// </para>
		/// <para>
		/// If either lpAppName or lpKeyName is <c>NULL</c> and the supplied destination buffer is too small to hold all the strings, the last string is
		/// truncated and followed by two <c>null</c> characters. In this case, the return value is equal to nSize minus two.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetProfileString( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ LPCTSTR lpDefault, _Out_ LPTSTR lpReturnedString, _In_ DWORD
		// nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724366(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724366")]
		public static extern uint GetProfileString([In] string lpAppName, [In] string lpKeyName, [In] string lpDefault, [Out] StringBuilder lpReturnedString, uint nSize);

		/// <summary>Replaces the keys and values for the specified section in an initialization file.</summary>
		/// <param name="lpAppName">The name of the section in which data is written. This section name is typically the name of the calling application.</param>
		/// <param name="lpString">The new key names and associated values that are to be written to the named section. This string is limited to 65,535 bytes.</param>
		/// <param name="lpFileName">
		/// <para>
		/// The name of the initialization file. If this parameter does not contain a full path for the file, the function searches the Windows directory for the
		/// file. If the file does not exist and lpFileName does not contain a full path, the function creates the file in the Windows directory.
		/// </para>
		/// <para>
		/// If the file exists and was created using Unicode characters, the function writes Unicode characters to the file. Otherwise, the function creates a
		/// file using ANSI characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI WritePrivateProfileSection( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpString, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725500(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725500")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WritePrivateProfileSection([In] string lpAppName, [In] string lpString, [In] string lpFileName);

		/// <summary>Copies a string into the specified section of an initialization file.</summary>
		/// <param name="lpAppName">
		/// The name of the section to which the string will be copied. If the section does not exist, it is created. The name of the section is
		/// case-independent; the string can be any combination of uppercase and lowercase letters.
		/// </param>
		/// <param name="lpKeyName">
		/// The name of the key to be associated with a string. If the key does not exist in the specified section, it is created. If this parameter is
		/// <c>NULL</c>, the entire section, including all entries within the section, is deleted.
		/// </param>
		/// <param name="lpString">
		/// A <c>null</c>-terminated string to be written to the file. If this parameter is <c>NULL</c>, the key pointed to by the lpKeyName parameter is deleted.
		/// </param>
		/// <param name="lpFileName">
		/// <para>The name of the initialization file.</para>
		/// <para>
		/// If the file was created using Unicode characters, the function writes Unicode characters to the file. Otherwise, the function writes ANSI characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function successfully copies the string to the initialization file, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, or if it flushes the cached version of the most recently accessed initialization file, the return value is zero. To get
		/// extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI WritePrivateProfileString( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ LPCTSTR lpString, _In_ LPCTSTR lpFileName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725501(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725501")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WritePrivateProfileString([In] string lpAppName, [In] string lpKeyName, [In] string lpString, [In] string lpFileName);

		/// <summary>
		/// Copies data into a key in the specified section of an initialization file. As it copies the data, the function calculates a checksum and appends it
		/// to the end of the data. The <c>GetPrivateProfileStruct</c> function uses the checksum to ensure the integrity of the data.
		/// </summary>
		/// <param name="lpszSection">
		/// The name of the section to which the string will be copied. If the section does not exist, it is created. The name of the section is case
		/// independent, the string can be any combination of uppercase and lowercase letters.
		/// </param>
		/// <param name="lpszKey">
		/// The name of the key to be associated with a string. If the key does not exist in the specified section, it is created. If this parameter is
		/// <c>NULL</c>, the entire section, including all keys and entries within the section, is deleted.
		/// </param>
		/// <param name="lpStruct">The data to be copied. If this parameter is <c>NULL</c>, the key is deleted.</param>
		/// <param name="uSizeStruct">The size of the buffer pointed to by the lpStruct parameter, in bytes.</param>
		/// <param name="szFile">
		/// <para>The name of the initialization file. If this parameter is <c>NULL</c>, the information is copied into the Win.ini file.</para>
		/// <para>
		/// If the file was created using Unicode characters, the function writes Unicode characters to the file. Otherwise, the function writes ANSI characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function successfully copies the string to the initialization file, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, or if it flushes the cached version of the most recently accessed initialization file, the return value is zero. To get
		/// extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI WritePrivateProfileStruct( _In_ LPCTSTR lpszSection, _In_ LPCTSTR lpszKey, _In_ LPVOID lpStruct, _In_ UINT uSizeStruct, _In_ LPCTSTR
		// szFile); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725502(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725502")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WritePrivateProfileStruct([In] string lpszSection, [In] string lpszKey, [In] IntPtr lpStruct, uint uSizeStruct, [In] string szFile);

		/// <summary>
		/// Replaces the contents of the specified section in the Win.ini file with specified keys and values. If Win.ini uses Unicode characters, the function
		/// writes Unicode characters to the file. Otherwise, the function writes ANSI characters.
		/// </summary>
		/// <param name="lpAppName">The name of the section. This section name is typically the name of the calling application.</param>
		/// <param name="lpString">
		/// <para>The new key names and associated values that are to be written to the named section. This string is limited to 65,535 bytes.</para>
		/// <para>
		/// If the file exists and was created using Unicode characters, the function writes Unicode characters to the file. Otherwise, the function creates a
		/// file using ANSI characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI WriteProfileSection( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725503(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725503")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WriteProfileSection([In] string lpAppName, [In] string lpString);

		/// <summary>
		/// Copies a string into the specified section of the Win.ini file. If Win.ini uses Unicode characters, the function writes Unicode characters to the
		/// file. Otherwise, the function writes ANSI characters.
		/// </summary>
		/// <param name="lpAppName">
		/// The section to which the string is to be copied. If the section does not exist, it is created. The name of the section is not case-sensitive; the
		/// string can be any combination of uppercase and lowercase letters.
		/// </param>
		/// <param name="lpKeyName">
		/// The key to be associated with the string. If the key does not exist in the specified section, it is created. If this parameter is <c>NULL</c>, the
		/// entire section, including all entries in the section, is deleted.
		/// </param>
		/// <param name="lpString">
		/// A <c>null</c>-terminated string to be written to the file. If this parameter is <c>NULL</c>, the key pointed to by the lpKeyName parameter is deleted.
		/// </param>
		/// <returns>
		/// <para>If the function successfully copies the string to the Win.ini file, the return value is nonzero.</para>
		/// <para>If the function fails, or if it flushes the cached version of Win.ini, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI WriteProfileString( _In_ LPCTSTR lpAppName, _In_ LPCTSTR lpKeyName, _In_ LPCTSTR lpString); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725504(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725504")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WriteProfileString([In] string lpAppName, [In] string lpKeyName, [In] string lpString);
	}
}