using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Flags specifying time format options.</summary>
		[Flags]
		public enum TIME_FORMAT : uint
		{
			/// <summary>Do not use minutes or seconds.</summary>
			TIME_NOMINUTESORSECONDS = 1,
			/// <summary>Do not use seconds.</summary>
			TIME_NOSECONDS = 2,
			/// <summary>Do not use a time marker.</summary>
			TIME_NOTIMEMARKER = 4,
			/// <summary>Always use a 24-hour time format.</summary>
			TIME_FORCE24HOURFORMAT = 8,
			/// <summary>
			/// Windows Me/98, Windows 2000: System default Windows ANSI code page (ACP) instead of the locale code page used for string translation. See Code
			/// Page Identifiers for a list of ANSI and other code pages.
			/// </summary>
			LOCAL_USE_CP_ACP = 0x40000000,
			/// <summary>
			/// No user override. In several functions, for example, GetLocaleInfo and GetLocaleInfoEx, this constant causes the function to bypass any user
			/// override and use the system default value for any other constant specified in the function call. The information is retrieved from the locale
			/// database, even if the identifier indicates the current locale and the user has changed some of the values using the Control Panel, or if an
			/// application has changed these values by using SetLocaleInfo. If this constant is not specified, any values that the user has configured from the
			/// Control Panel or that an application has configured using SetLocaleInfo take precedence over the database settings for the current system default locale.
			/// </summary>
			LOCALE_NOUSEROVERRIDE = 0x80000000
		}

		/// <summary>
		/// Formats a date as a date string for a locale specified by the locale identifier. The function formats either a specified date or the local system date.
		/// </summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale this function formats the date string for. You can use the <c>MAKELCID</c> macro to create a locale
		/// identifier or use one of the following predefined values.
		/// </param>
		/// <param name="dwFlags">Flags specifying date format options. For detailed definitions, see the dwFlags parameter of <c>GetDateFormatEx</c>.</param>
		/// <param name="lpDate">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the date information to format. The application sets this parameter to <c>NULL</c> if the
		/// function is to use the current local system date.
		/// </param>
		/// <param name="lpFormat">
		/// <para>
		/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in Day, Month, Year, and
		/// Era Format Pictures.
		/// </para>
		/// <para>
		/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and month names for the
		/// locale. The application can set this parameter to <c>NULL</c> to format the string according to the date format for the specified locale.
		/// </para>
		/// </param>
		/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
		/// <param name="cchDate">
		/// Size, in characters, of the lpDateStr buffer. The application can set this parameter to 0 to return the buffer size required to hold the formatted
		/// date string. In this case, the buffer indicated by lpDateStr is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters written to the lpDateStr buffer if successful. If the cchDate parameter is set to 0, the function returns the number
		/// of characters required to hold the formatted date string, including the terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetDateFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpDate, _In_opt_ LPCTSTR lpFormat, _Out_opt_ LPTSTR lpDateStr,
		// _In_ int cchDate); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318086(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Datetimeapi.h", MSDNShortId = "dd318086")]
		public static extern int GetDateFormat(uint Locale, DATE_FORMAT dwFlags, [In] ref SYSTEMTIME lpDate, [In] string lpFormat, [Out] StringBuilder lpDateStr, int cchDate);

		/// <summary>Formats a date as a date string for a locale specified by name. The function formats either a specified date or the local system date.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags specifying various function options that can be set if lpFormat is set to <c>NULL</c>. The application can specify a combination of the
		/// following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DATE_AUTOLAYOUT</term>
		/// <term>
		/// Windows 7 and later: Detect the need for right-to-left and left-to-right reading layout using the locale and calendar information, and add marks
		/// accordingly. This value cannot be used with DATE_LTRREADING or DATE_RTLREADING. DATE_AUTOLAYOUT is preferred over DATE_LTRREADING and DATE_RTLREADING
		/// because it uses the locales and calendars to determine the correct addition of marks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DATE_LONGDATE</term>
		/// <term>Use the long date format. This value cannot be used with DATE_MONTHDAY, DATE_SHORTDATE, or DATE_YEARMONTH.</term>
		/// </item>
		/// <item>
		/// <term>DATE_LTRREADING</term>
		/// <term>Add marks for left-to-right reading layout. This value cannot be used with DATE_RTLREADING.</term>
		/// </item>
		/// <item>
		/// <term>DATE_RTLREADING</term>
		/// <term>Add marks for right-to-left reading layout. This value cannot be used with DATE_LTRREADING</term>
		/// </item>
		/// <item>
		/// <term>DATE_SHORTDATE</term>
		/// <term>Use the short date format. This is the default. This value cannot be used with DATE_MONTHDAY, DATE_LONGDATE, or DATE_YEARMONTH.</term>
		/// </item>
		/// <item>
		/// <term>DATE_USE_ALT_CALENDAR</term>
		/// <term>
		/// Use the alternate calendar, if one exists, to format the date string. If this flag is set, the function uses the default format for that alternate
		/// calendar, rather than using any user overrides. The user overrides will be used only in the event that there is no default format for the specified
		/// alternate calendar.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DATE_YEARMONTH</term>
		/// <term>Windows Vista: Use the year/month format. This value cannot be used with DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE.</term>
		/// </item>
		/// <item>
		/// <term>DATE_MONTHDAY</term>
		/// <term>
		/// Windows 10: Use the combination of month and day formats appropriate for the specified locale. This value cannot be used with DATE_YEARMONTH,
		/// DATE_SHORTDATE, or DATE_LONGDATE.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the application does not specify DATE_YEARMONTH, DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE, and lpFormat is set to <c>NULL</c>,
		/// DATE_SHORTDATE is the default.
		/// </para>
		/// </param>
		/// <param name="lpDate">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the date information to format. The application can set this parameter to <c>NULL</c> if the
		/// function is to use the current local system date.
		/// </param>
		/// <param name="lpFormat">
		/// <para>
		/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in Day, Month, Year, and
		/// Era Format Pictures.
		/// </para>
		/// <para>For example, to get the date string "Wed, Aug 31 94", the application uses the picture string "ddd',' MMM dd yy".</para>
		/// <para>
		/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and month names for the
		/// locale. The application can set this parameter to <c>NULL</c> to format the string according to the date format for the specified locale.
		/// </para>
		/// </param>
		/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
		/// <param name="cchDate">
		/// Size, in characters, of the lpDateStr buffer. The application can set this parameter to 0 to return the buffer size required to hold the formatted
		/// date string. In this case, the buffer indicated by lpDateStr is not used.
		/// </param>
		/// <param name="lpCalendar">Reserved; must set to <c>NULL</c>.</param>
		/// <returns>
		/// <para>
		/// Returns the number of characters written to the lpDateStr buffer if successful. If the cchDate parameter is set to 0, the function returns the number
		/// of characters required to hold the formatted date string, including the terminating null character.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetDateFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpDate, _In_opt_ LPCWSTR lpFormat, _Out_opt_ LPWSTR
		// lpDateStr, _In_ int cchDate, _In_opt_ LPCWSTR lpCalendar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318088(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Datetimeapi.h", MSDNShortId = "dd318088")]
		public static extern int GetDateFormatEx(string lpLocaleName, DATE_FORMAT dwFlags, [In] ref SYSTEMTIME lpDate, [In] string lpFormat, [Out] StringBuilder lpDateStr, int cchDate);

		/// <summary>
		/// Formats time as a time string for a locale specified by identifier. The function formats either a specified time or the local system time.
		/// </summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </param>
		/// <param name="dwFlags">Flags specifying time format options. For detailed definitions see the dwFlags parameter of <c>GetTimeFormatEx</c>.</param>
		/// <param name="lpTime">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the time information to format. The application can set this parameter to <c>NULL</c> if the
		/// function is to use the current local system time.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function formats the string
		/// according to the time format of the specified locale. If the application does not set the parameter to <c>NULL</c>, the function uses the locale only
		/// for information not specified in the format picture string, for example, the locale-specific time markers. For information about the format picture
		/// string, see the Remarks section.
		/// </param>
		/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
		/// <param name="cchTime">
		/// Size, in TCHAR values, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter to 0. In this case,
		/// the function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of TCHAR values retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the function returns the
		/// size of the buffer required to hold the formatted time string, including a terminating null character.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetTimeFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpTime, _In_opt_ LPCTSTR lpFormat, _Out_opt_ LPTSTR lpTimeStr,
		// _In_ int cchTime); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318130(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Datetimeapi.h", MSDNShortId = "dd318130")]
		public static extern int GetTimeFormat(uint Locale, TIME_FORMAT dwFlags, [In] ref SYSTEMTIME lpTime, [In] string lpFormat, [Out] StringBuilder lpTimeStr, int cchTime);

		/// <summary>Formats time as a time string for a locale specified by name. The function formats either a specified time or the local system time.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// <para>Flags specifying time format options. The application can specify a combination of the following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TIME_NOMINUTESORSECONDS</term>
		/// <term>Do not use minutes or seconds.</term>
		/// </item>
		/// <item>
		/// <term>TIME_NOSECONDS</term>
		/// <term>Do not use seconds.</term>
		/// </item>
		/// <item>
		/// <term>TIME_NOTIMEMARKER</term>
		/// <term>Do not use a time marker.</term>
		/// </item>
		/// <item>
		/// <term>TIME_FORCE24HOURFORMAT</term>
		/// <term>Always use a 24-hour time format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpTime">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the time information to format. The application can set this parameter to <c>NULL</c> if the
		/// function is to use the current local system time.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function formats the string
		/// according to the time format of the specified locale. If the application does not set the parameter to <c>NULL</c>, the function uses the locale only
		/// for information not specified in the format picture string, for example, the locale-specific time markers. For information about the format picture
		/// string, see the Remarks section.
		/// </param>
		/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
		/// <param name="cchTime">
		/// Size, in characters, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter to 0. In this case, the
		/// function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the function returns the size
		/// of the buffer required to hold the formatted time string, including a terminating null character.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetTimeFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpTime, _In_opt_ LPCWSTR lpFormat, _Out_opt_ LPWSTR
		// lpTimeStr, _In_ int cchTime); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318131(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Datetimeapi.h", MSDNShortId = "dd318131")]
		public static extern int GetTimeFormatEx(string lpLocaleName, TIME_FORMAT dwFlags, [In] ref SYSTEMTIME lpTime, [In] string lpFormat, [Out] StringBuilder lpTimeStr, int cchTime);
	}
}