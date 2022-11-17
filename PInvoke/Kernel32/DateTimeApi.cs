using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke;

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
		/// Windows Me/98, Windows 2000: System default Windows ANSI code page (ACP) instead of the locale code page used for string
		/// translation. See Code Page Identifiers for a list of ANSI and other code pages.
		/// </summary>
		LOCAL_USE_CP_ACP = 0x40000000,

		/// <summary>
		/// No user override. In several functions, for example, GetLocaleInfo and GetLocaleInfoEx, this constant causes the function to
		/// bypass any user override and use the system default value for any other constant specified in the function call. The
		/// information is retrieved from the locale database, even if the identifier indicates the current locale and the user has
		/// changed some of the values using the Control Panel, or if an application has changed these values by using SetLocaleInfo. If
		/// this constant is not specified, any values that the user has configured from the Control Panel or that an application has
		/// configured using SetLocaleInfo take precedence over the database settings for the current system default locale.
		/// </summary>
		LOCALE_NOUSEROVERRIDE = 0x80000000
	}

	/// <summary>
	/// Formats a date as a date string for a locale specified by the locale identifier. The function formats either a specified date or
	/// the local system date.
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale this function formats the date string for. You can use the MAKELCID macro to create a
	/// locale identifier or use one of the following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Flags specifying date format options. For detailed definitions, see the dwFlags parameter of GetDateFormatEx.</param>
	/// <param name="lpDate">
	/// Pointer to a SYSTEMTIME structure that contains the date information to format. The application sets this parameter to
	/// <c>NULL</c> if the function is to use the current local system date.
	/// </param>
	/// <param name="lpFormat">
	/// <para>
	/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in
	/// Day, Month, Year, and Era Format Pictures.
	/// </para>
	/// <para>
	/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and
	/// month names for the locale. The application can set this parameter to <c>NULL</c> to format the string according to the date
	/// format for the specified locale.
	/// </para>
	/// </param>
	/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
	/// <param name="cchDate">
	/// Size, in characters, of the lpDateStr buffer. The application can set this parameter to 0 to return the buffer size required to
	/// hold the formatted date string. In this case, the buffer indicated by lpDateStr is not used.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the lpDateStr buffer if successful. If the cchDate parameter is set to 0, the
	/// function returns the number of characters required to hold the formatted date string, including the terminating null character.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This API is being updated to support the May 2019 Japanese era change. If your application supports the Japanese
	/// calendar, you should validate that it properly handles the new era. See Prepare your application for the Japanese era change for
	/// more information.
	/// </para>
	/// <para>See Remarks for GetDateFormatEx.</para>
	/// <para>
	/// When the ANSI version of this function is used with a Unicode-only locale identifier, the function can succeed because the
	/// operating system uses the system code page. However, characters that are undefined in the system code page appear in the string
	/// as a question mark ("?").
	/// </para>
	/// <para>
	/// <c>Starting with Windows 8:</c><c>GetDateFormat</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformata int GetDateFormatA( LCID Locale,
	// DWORD dwFlags, const SYSTEMTIME *lpDate, LPCSTR lpFormat, LPSTR lpDateStr, int cchDate );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "546cede1-1702-403a-bba3-b5cd3b35a1bf")]
	public static extern int GetDateFormat(LCID Locale, DATE_FORMAT dwFlags, in SYSTEMTIME lpDate, [Optional] string lpFormat, [Optional] StringBuilder lpDateStr, int cchDate);

	/// <summary>
	/// Formats a date as a date string for a locale specified by the locale identifier. The function formats either a specified date or
	/// the local system date.
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale this function formats the date string for. You can use the MAKELCID macro to create a
	/// locale identifier or use one of the following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Flags specifying date format options. For detailed definitions, see the dwFlags parameter of GetDateFormatEx.</param>
	/// <param name="lpDate">
	/// Pointer to a SYSTEMTIME structure that contains the date information to format. The application sets this parameter to
	/// <c>NULL</c> if the function is to use the current local system date.
	/// </param>
	/// <param name="lpFormat">
	/// <para>
	/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in
	/// Day, Month, Year, and Era Format Pictures.
	/// </para>
	/// <para>
	/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and
	/// month names for the locale. The application can set this parameter to <c>NULL</c> to format the string according to the date
	/// format for the specified locale.
	/// </para>
	/// </param>
	/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
	/// <param name="cchDate">
	/// Size, in characters, of the lpDateStr buffer. The application can set this parameter to 0 to return the buffer size required to
	/// hold the formatted date string. In this case, the buffer indicated by lpDateStr is not used.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the lpDateStr buffer if successful. If the cchDate parameter is set to 0, the
	/// function returns the number of characters required to hold the formatted date string, including the terminating null character.
	/// </para>
	/// <para>
	/// The function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This API is being updated to support the May 2019 Japanese era change. If your application supports the Japanese
	/// calendar, you should validate that it properly handles the new era. See Prepare your application for the Japanese era change for
	/// more information.
	/// </para>
	/// <para>See Remarks for GetDateFormatEx.</para>
	/// <para>
	/// When the ANSI version of this function is used with a Unicode-only locale identifier, the function can succeed because the
	/// operating system uses the system code page. However, characters that are undefined in the system code page appear in the string
	/// as a question mark ("?").
	/// </para>
	/// <para>
	/// <c>Starting with Windows 8:</c><c>GetDateFormat</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-getdateformata int GetDateFormatA( LCID Locale,
	// DWORD dwFlags, const SYSTEMTIME *lpDate, LPCSTR lpFormat, LPSTR lpDateStr, int cchDate );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "546cede1-1702-403a-bba3-b5cd3b35a1bf")]
	public static extern int GetDateFormat(LCID Locale, DATE_FORMAT dwFlags, [In, Optional] IntPtr lpDate, [Optional] string lpFormat, [Optional] StringBuilder lpDateStr, int cchDate);

	/// <summary>
	/// <para>
	/// Formats a date as a date string for a locale specified by name. The function formats either a specified date or the local system date.
	/// </para>
	/// <para>
	/// <c>Note</c> This function can format data that changes between releases, for example, due to a custom locale. If your application
	/// must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// </summary>
	/// <param name="lpLocaleName">
	/// <para>Pointer to a locale name, or one of the following predefined values.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_NAME_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags specifying various function options that can be set if lpFormat is set to <c>NULL</c>. The application can specify a
	/// combination of the following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.
	/// </para>
	/// <para><c>Caution</c> Use of LOCALE_NOUSEROVERRIDE is strongly discouraged as it disables user preferences.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DATE_AUTOLAYOUT</term>
	/// <term>
	/// Windows 7 and later: Detect the need for right-to-left and left-to-right reading layout using the locale and calendar
	/// information, and add marks accordingly. This value cannot be used with DATE_LTRREADING or DATE_RTLREADING. DATE_AUTOLAYOUT is
	/// preferred over DATE_LTRREADING and DATE_RTLREADING because it uses the locales and calendars to determine the correct addition of marks.
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
	/// Use the alternate calendar, if one exists, to format the date string. If this flag is set, the function uses the default format
	/// for that alternate calendar, rather than using any user overrides. The user overrides will be used only in the event that there
	/// is no default format for the specified alternate calendar.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DATE_YEARMONTH</term>
	/// <term>Windows Vista: Use the year/month format. This value cannot be used with DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE.</term>
	/// </item>
	/// <item>
	/// <term>DATE_MONTHDAY</term>
	/// <term>
	/// Windows 10: Use the combination of month and day formats appropriate for the specified locale. This value cannot be used with
	/// DATE_YEARMONTH, DATE_SHORTDATE, or DATE_LONGDATE.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the application does not specify DATE_YEARMONTH, DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE, and lpFormat is set to
	/// <c>NULL</c>, DATE_SHORTDATE is the default.
	/// </para>
	/// </param>
	/// <param name="lpDate">
	/// Pointer to a SYSTEMTIME structure that contains the date information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system date.
	/// </param>
	/// <param name="lpFormat">
	/// <para>
	/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in
	/// Day, Month, Year, and Era Format Pictures.
	/// </para>
	/// <para>For example, to get the date string "Wed, Aug 31 94", the application uses the picture string "ddd',' MMM dd yy".</para>
	/// <para>
	/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and
	/// month names for the locale. The application can set this parameter to <c>NULL</c> to format the string according to the date
	/// format for the specified locale.
	/// </para>
	/// </param>
	/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
	/// <param name="cchDate">
	/// Size, in characters, of the lpDateStr buffer. The application can set this parameter to 0 to return the buffer size required to
	/// hold the formatted date string. In this case, the buffer indicated by lpDateStr is not used.
	/// </param>
	/// <param name="lpCalendar">Reserved; must set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the lpDateStr buffer if successful. If the cchDate parameter is set to 0, the
	/// function returns the number of characters required to hold the formatted date string, including the terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This API is being updated to support the May 2019 Japanese era change. If your application supports the Japanese
	/// calendar, you should validate that it properly handles the new era. See Prepare your application for the Japanese era change for
	/// more information.
	/// </para>
	/// <para>The earliest date supported by this function is January 1, 1601.</para>
	/// <para>The day name, abbreviated day name, month name, and abbreviated month name are all localized based on the locale identifier.</para>
	/// <para>
	/// The date values in the structure indicated by lpDate must be valid. The function checks each of the date values: year, month,
	/// day, and day of week. If the day of the week is incorrect, the function uses the correct value, and returns no error. If any of
	/// the other date values are outside the correct range, the function fails, and sets the last error to ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// The function ignores the time members of the SYSTEMTIME structure indicated by lpDate. These include <c>wHour</c>,
	/// <c>wMinute</c>, <c>wSecond</c>, and <c>wMilliseconds</c>.
	/// </para>
	/// <para>
	/// If the lpFormat parameter contains a bad format string, the function returns no errors, but just forms the best possible date
	/// string. For example, the only year pictures that are valid are L"yyyy" and L"yy", where the "L" indicates a Unicode (16-bit
	/// characters) string. If L"y" is passed in, the function assumes L"yy". If L"yyy" is passed in, the function assumes L"yyyy". If
	/// more than four date (L"dddd") or four month (L"MMMM") pictures are passed in, the function defaults to L"dddd" or L"MMMM".
	/// </para>
	/// <para>
	/// The application should enclose any text that should remain in its exact form in the date string within single quotation marks in
	/// the date format picture. The single quotation mark can also be used as an escape character to allow the single quotation mark
	/// itself to be displayed in the date string. However, the escape sequence must be enclosed within two single quotation marks. For
	/// example, to display the date as "May '93", the format string is: L"MMMM ''''yy". The first and last single quotation marks are
	/// the enclosing quotation marks. The second and third single quotation marks are the escape sequence to allow the single quotation
	/// mark to be displayed before the century.
	/// </para>
	/// <para>
	/// When the date picture contains both a numeric form of the day (either d or dd) and the full month name (MMMM), the genitive form
	/// of the month name is retrieved in the date string.
	/// </para>
	/// <para>
	/// To obtain the default short and long date format without performing any actual formatting, the application should use
	/// GetLocaleInfoEx with the LOCALE_SSHORTDATE or LOCALE_SLONGDATE constant. To get the date format for an alternate calendar, the
	/// application uses GetLocaleInfoEx with the LOCALE_IOPTIONALCALENDAR constant. To get the date format for a particular calendar,
	/// the application uses GetCalendarInfoEx, passing the appropriate Calendar Identifier. It can call EnumCalendarInfoEx or
	/// EnumDateFormatsEx to retrieve date formats for a particular calendar.
	/// </para>
	/// <para>
	/// This function can retrieve data from custom locales. Data is not guaranteed to be the same from computer to computer or between
	/// runs of an application. If your application must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// <para>
	/// The DATE_LONGDATE format includes two kinds of date patterns: patterns that include the day of the week and patterns that do not
	/// include the day of the week. For example, "Tuesday, October 18, 2016" or "October 18, 2016". If your application needs to ensure
	/// that dates use one of these kinds of patterns and not the other kind, your application should perform the following actions:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call the EnumDateFormatsExEx function to get all of the date formats for the DATE_LONGDATE format.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Look for the first date format passed to the callback function that you specified for EnumDateFormatsExEx that matches your
	/// requested calendar identifier and has a date format string that matches the requirements of your application. For example, look
	/// for the first date format that includes "dddd" if your application requires that the date include the full name of the day of the
	/// week, or look for the first date format that includes neither "ddd" nor "dddd" if your application requires that the date
	/// includes nether the abbreviated name nor the full name of the day of the week.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call the <c>GetDateFormatEx</c> function with the lpFormat parameter set to the date format string that you identified as the
	/// appropriate format in the callback function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the presence or absence of the day of the week in the long date format does not matter to your application, your application
	/// can call <c>GetDateFormatEx</c> directly without first enumerating all of the long date formats by calling EnumDateFormatsExEx.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> If your app passes language tags to this function from the Windows.Globalization namespace, it
	/// must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c><c>GetDateFormatEx</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatex int GetDateFormatEx( [in, optional]
	// LPCWSTR lpLocaleName, [in] DWORD dwFlags, [in, optional] const SYSTEMTIME *lpDate, [in, optional] LPCWSTR lpFormat, [out,
	// optional] LPWSTR lpDateStr, [in] int cchDate, [in, optional] LPCWSTR lpCalendar );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "791fb386-3cc5-410e-bfce-52598fdb10c9")]
	public static extern int GetDateFormatEx([Optional] string lpLocaleName, DATE_FORMAT dwFlags, in SYSTEMTIME lpDate,
		[Optional] string lpFormat, [Out, Optional] StringBuilder lpDateStr, int cchDate, [Optional] string lpCalendar);

	/// <summary>
	/// <para>
	/// Formats a date as a date string for a locale specified by name. The function formats either a specified date or the local system date.
	/// </para>
	/// <para>
	/// <c>Note</c> This function can format data that changes between releases, for example, due to a custom locale. If your application
	/// must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// </summary>
	/// <param name="lpLocaleName">
	/// <para>Pointer to a locale name, or one of the following predefined values.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_NAME_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags specifying various function options that can be set if <c>lpFormat</c> is set to <c>NULL</c>. The application can specify a
	/// combination of the following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.
	/// </para>
	/// <para><c>Caution</c> Use of LOCALE_NOUSEROVERRIDE is strongly discouraged as it disables user preferences.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>DATE_AUTOLAYOUT</c></term>
	/// <term>
	/// <c>Windows 7 and later:</c> Detect the need for right-to-left and left-to-right reading layout using the locale and calendar
	/// information, and add marks accordingly. This value cannot be used with DATE_LTRREADING or DATE_RTLREADING. DATE_AUTOLAYOUT is
	/// preferred over DATE_LTRREADING and DATE_RTLREADING because it uses the locales and calendars to determine the correct addition of marks.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>DATE_LONGDATE</c></term>
	/// <term>Use the long date format. This value cannot be used with DATE_MONTHDAY, DATE_SHORTDATE, or DATE_YEARMONTH.</term>
	/// </item>
	/// <item>
	/// <term><c>DATE_LTRREADING</c></term>
	/// <term>Add marks for left-to-right reading layout. This value cannot be used with DATE_RTLREADING.</term>
	/// </item>
	/// <item>
	/// <term><c>DATE_RTLREADING</c></term>
	/// <term>Add marks for right-to-left reading layout. This value cannot be used with DATE_LTRREADING</term>
	/// </item>
	/// <item>
	/// <term><c>DATE_SHORTDATE</c></term>
	/// <term>Use the short date format. This is the default. This value cannot be used with DATE_MONTHDAY, DATE_LONGDATE, or DATE_YEARMONTH.</term>
	/// </item>
	/// <item>
	/// <term><c>DATE_USE_ALT_CALENDAR</c></term>
	/// <term>
	/// Use the alternate calendar, if one exists, to format the date string. If this flag is set, the function uses the default format
	/// for that alternate calendar, rather than using any user overrides. The user overrides will be used only in the event that there
	/// is no default format for the specified alternate calendar.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>DATE_YEARMONTH</c></term>
	/// <term><c>Windows Vista:</c> Use the year/month format. This value cannot be used with DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE.</term>
	/// </item>
	/// <item>
	/// <term><c>DATE_MONTHDAY</c></term>
	/// <term>
	/// <c>Windows 10:</c> Use the combination of month and day formats appropriate for the specified locale. This value cannot be used
	/// with DATE_YEARMONTH, DATE_SHORTDATE, or DATE_LONGDATE.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the application does not specify DATE_YEARMONTH, DATE_MONTHDAY, DATE_SHORTDATE, or DATE_LONGDATE, and <c>lpFormat</c> is set
	/// to <c>NULL</c>, DATE_SHORTDATE is the default.
	/// </para>
	/// </param>
	/// <param name="lpDate">
	/// Pointer to a SYSTEMTIME structure that contains the date information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system date.
	/// </param>
	/// <param name="lpFormat">
	/// <para>
	/// Pointer to a format picture string that is used to form the date. Possible values for the format picture string are defined in
	/// Day, Month, Year, and Era Format Pictures.
	/// </para>
	/// <para>For example, to get the date string "Wed, Aug 31 94", the application uses the picture string "ddd',' MMM dd yy".</para>
	/// <para>
	/// The function uses the specified locale only for information not specified in the format picture string, for example, the day and
	/// month names for the locale. The application can set this parameter to <c>NULL</c> to format the string according to the date
	/// format for the specified locale.
	/// </para>
	/// </param>
	/// <param name="lpDateStr">Pointer to a buffer in which this function retrieves the formatted date string.</param>
	/// <param name="cchDate">
	/// Size, in characters, of the <c>lpDateStr</c> buffer. The application can set this parameter to 0 to return the buffer size
	/// required to hold the formatted date string. In this case, the buffer indicated by <c>lpDateStr</c> is not used.
	/// </param>
	/// <param name="lpCalendar">Reserved; must set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// Returns the number of characters written to the <c>lpDateStr</c> buffer if successful. If the <c>cchDate</c> parameter is set to
	/// 0, the function returns the number of characters required to hold the formatted date string, including the terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>Note</c> This API is being updated to support the May 2019 Japanese era change. If your application supports the Japanese
	/// calendar, you should validate that it properly handles the new era. See Prepare your application for the Japanese era change for
	/// more information.
	/// </para>
	/// <para>The earliest date supported by this function is January 1, 1601.</para>
	/// <para>The day name, abbreviated day name, month name, and abbreviated month name are all localized based on the locale identifier.</para>
	/// <para>
	/// The date values in the structure indicated by <c>lpDate</c> must be valid. The function checks each of the date values: year,
	/// month, day, and day of week. If the day of the week is incorrect, the function uses the correct value, and returns no error. If
	/// any of the other date values are outside the correct range, the function fails, and sets the last error to ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// The function ignores the time members of the SYSTEMTIME structure indicated by <c>lpDate</c>. These include <c>wHour</c>,
	/// <c>wMinute</c>, <c>wSecond</c>, and <c>wMilliseconds</c>.
	/// </para>
	/// <para>
	/// If the <c>lpFormat</c> parameter contains a bad format string, the function returns no errors, but just forms the best possible
	/// date string. For example, the only year pictures that are valid are L"yyyy" and L"yy", where the "L" indicates a Unicode (16-bit
	/// characters) string. If L"y" is passed in, the function assumes L"yy". If L"yyy" is passed in, the function assumes L"yyyy". If
	/// more than four date (L"dddd") or four month (L"MMMM") pictures are passed in, the function defaults to L"dddd" or L"MMMM".
	/// </para>
	/// <para>
	/// The application should enclose any text that should remain in its exact form in the date string within single quotation marks in
	/// the date format picture. The single quotation mark can also be used as an escape character to allow the single quotation mark
	/// itself to be displayed in the date string. However, the escape sequence must be enclosed within two single quotation marks. For
	/// example, to display the date as "May '93", the format string is: L"MMMM ''''yy". The first and last single quotation marks are
	/// the enclosing quotation marks. The second and third single quotation marks are the escape sequence to allow the single quotation
	/// mark to be displayed before the century.
	/// </para>
	/// <para>
	/// When the date picture contains both a numeric form of the day (either d or dd) and the full month name (MMMM), the genitive form
	/// of the month name is retrieved in the date string.
	/// </para>
	/// <para>
	/// To obtain the default short and long date format without performing any actual formatting, the application should use
	/// GetLocaleInfoEx with the LOCALE_SSHORTDATE or LOCALE_SLONGDATE constant. To get the date format for an alternate calendar, the
	/// application uses GetLocaleInfoEx with the LOCALE_IOPTIONALCALENDAR constant. To get the date format for a particular calendar,
	/// the application uses GetCalendarInfoEx, passing the appropriate Calendar Identifier. It can call EnumCalendarInfoEx or
	/// EnumDateFormatsEx to retrieve date formats for a particular calendar.
	/// </para>
	/// <para>
	/// This function can retrieve data from custom locales. Data is not guaranteed to be the same from computer to computer or between
	/// runs of an application. If your application must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// <para>
	/// The DATE_LONGDATE format includes two kinds of date patterns: patterns that include the day of the week and patterns that do not
	/// include the day of the week. For example, "Tuesday, October 18, 2016" or "October 18, 2016". If your application needs to ensure
	/// that dates use one of these kinds of patterns and not the other kind, your application should perform the following actions:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call the EnumDateFormatsExEx function to get all of the date formats for the DATE_LONGDATE format.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Look for the first date format passed to the callback function that you specified for EnumDateFormatsExEx that matches your
	/// requested calendar identifier and has a date format string that matches the requirements of your application. For example, look
	/// for the first date format that includes "dddd" if your application requires that the date include the full name of the day of the
	/// week, or look for the first date format that includes neither "ddd" nor "dddd" if your application requires that the date
	/// includes nether the abbreviated name nor the full name of the day of the week.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call the <c>GetDateFormatEx</c> function with the <c>lpFormat</c> parameter set to the date format string that you identified as
	/// the appropriate format in the callback function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the presence or absence of the day of the week in the long date format does not matter to your application, your application
	/// can call <c>GetDateFormatEx</c> directly without first enumerating all of the long date formats by calling EnumDateFormatsExEx.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> If your app passes language tags to this function from the Windows.Globalization namespace, it
	/// must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c><c>GetDateFormatEx</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/datetimeapi/nf-datetimeapi-getdateformatex int GetDateFormatEx( [in, optional]
	// LPCWSTR lpLocaleName, [in] DWORD dwFlags, [in, optional] const SYSTEMTIME *lpDate, [in, optional] LPCWSTR lpFormat, [out,
	// optional] LPWSTR lpDateStr, [in] int cchDate, [in, optional] LPCWSTR lpCalendar );
	[PInvokeData("datetimeapi.h", MSDNShortId = "NF:datetimeapi.GetDateFormatEx")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	public static extern int GetDateFormatEx([Optional] string lpLocaleName, DATE_FORMAT dwFlags, [In, Optional] IntPtr lpDate,
		[Optional] string lpFormat, [Out, Optional] StringBuilder lpDateStr, int cchDate, [Optional] string lpCalendar);

	/// <summary>
	/// <para>
	/// Formats time as a time string for a locale specified by identifier. The function formats either a specified time or the local
	/// system time.
	/// </para>
	/// <para>
	/// <c>Note</c> For interoperability reasons, the application should prefer the GetTimeFormatEx function to <c>GetTimeFormat</c>
	/// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales. Any application that
	/// will be run only on Windows Vista and later should use GetTimeFormatEx.
	/// </para>
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale. You can use the MAKELCID macro to create a locale identifier or use one of the
	/// following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Flags specifying time format options. For detailed definitions see the dwFlags parameter of GetTimeFormatEx.</param>
	/// <param name="lpTime">
	/// Pointer to a SYSTEMTIME structure that contains the time information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system time.
	/// </param>
	/// <param name="lpFormat">
	/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function
	/// formats the string according to the time format of the specified locale. If the application does not set the parameter to
	/// <c>NULL</c>, the function uses the locale only for information not specified in the format picture string, for example, the
	/// locale-specific time markers. For information about the format picture string, see the Remarks section.
	/// </param>
	/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
	/// <param name="cchTime">
	/// Size, in TCHAR values, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter
	/// to 0. In this case, the function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of TCHAR values retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the
	/// function returns the size of the buffer required to hold the formatted time string, including a terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY. Not enough storage was available to complete this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>See Remarks for GetTimeFormatEx.</para>
	/// <para>
	/// When the ANSI version of this function is used with a Unicode-only locale identifier, the function can succeed because the
	/// operating system uses the system code page. However, characters that are undefined in the system code page appear in the string
	/// as a question mark (?).
	/// </para>
	/// <para>
	/// <c>Starting with Windows 8:</c><c>GetTimeFormat</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-gettimeformata int GetTimeFormatA( LCID Locale,
	// DWORD dwFlags, const SYSTEMTIME *lpTime, LPCSTR lpFormat, LPSTR lpTimeStr, int cchTime );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "3db91d29-df97-4660-b3cd-0db5b42cfd01")]
	public static extern int GetTimeFormat(LCID Locale, TIME_FORMAT dwFlags, in SYSTEMTIME lpTime, [Optional] string lpFormat, [Optional] StringBuilder lpTimeStr, int cchTime);

	/// <summary>
	/// <para>
	/// Formats time as a time string for a locale specified by identifier. The function formats either a specified time or the local
	/// system time.
	/// </para>
	/// <para>
	/// <c>Note</c> For interoperability reasons, the application should prefer the GetTimeFormatEx function to <c>GetTimeFormat</c>
	/// because Microsoft is migrating toward the use of locale names instead of locale identifiers for new locales. Any application that
	/// will be run only on Windows Vista and later should use GetTimeFormatEx.
	/// </para>
	/// </summary>
	/// <param name="Locale">
	/// <para>
	/// Locale identifier that specifies the locale. You can use the MAKELCID macro to create a locale identifier or use one of the
	/// following predefined values.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_CUSTOM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UI_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_CUSTOM_UNSPECIFIED</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Flags specifying time format options. For detailed definitions see the dwFlags parameter of GetTimeFormatEx.</param>
	/// <param name="lpTime">
	/// Pointer to a SYSTEMTIME structure that contains the time information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system time.
	/// </param>
	/// <param name="lpFormat">
	/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function
	/// formats the string according to the time format of the specified locale. If the application does not set the parameter to
	/// <c>NULL</c>, the function uses the locale only for information not specified in the format picture string, for example, the
	/// locale-specific time markers. For information about the format picture string, see the Remarks section.
	/// </param>
	/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
	/// <param name="cchTime">
	/// Size, in TCHAR values, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter
	/// to 0. In this case, the function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of TCHAR values retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the
	/// function returns the size of the buffer required to hold the formatted time string, including a terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY. Not enough storage was available to complete this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>See Remarks for GetTimeFormatEx.</para>
	/// <para>
	/// When the ANSI version of this function is used with a Unicode-only locale identifier, the function can succeed because the
	/// operating system uses the system code page. However, characters that are undefined in the system code page appear in the string
	/// as a question mark (?).
	/// </para>
	/// <para>
	/// <c>Starting with Windows 8:</c><c>GetTimeFormat</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-gettimeformata int GetTimeFormatA( LCID Locale,
	// DWORD dwFlags, const SYSTEMTIME *lpTime, LPCSTR lpFormat, LPSTR lpTimeStr, int cchTime );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "3db91d29-df97-4660-b3cd-0db5b42cfd01")]
	public static extern int GetTimeFormat(LCID Locale, TIME_FORMAT dwFlags, [In, Optional] IntPtr lpTime, [Optional] string lpFormat, [Optional] StringBuilder lpTimeStr, int cchTime);

	/// <summary>
	/// <para>
	/// Formats time as a time string for a locale specified by name. The function formats either a specified time or the local system time.
	/// </para>
	/// <para>
	/// <c>Note</c> This function can format data that changes between releases, for example, due to a custom locale. If your application
	/// must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// </summary>
	/// <param name="lpLocaleName">
	/// <para>Pointer to a locale name, or one of the following predefined values.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_NAME_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags specifying time format options. The application can specify a combination of the following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.
	/// </para>
	/// <para><c>Caution</c> Use of LOCALE_NOUSEROVERRIDE is strongly discouraged as it disables user preferences.</para>
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
	/// </param>
	/// <param name="lpTime">
	/// Pointer to a SYSTEMTIME structure that contains the time information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system time.
	/// </param>
	/// <param name="lpFormat">
	/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function
	/// formats the string according to the time format of the specified locale. If the application does not set the parameter to
	/// <c>NULL</c>, the function uses the locale only for information not specified in the format picture string, for example, the
	/// locale-specific time markers. For information about the format picture string, see the Remarks section.
	/// </param>
	/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
	/// <param name="cchTime">
	/// Size, in characters, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter to
	/// 0. In this case, the function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the
	/// function returns the size of the buffer required to hold the formatted time string, including a terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY. Not enough storage was available to complete this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a time marker exists and the TIME_NOTIMEMARKER flag is not set, the function localizes the time marker based on the specified
	/// locale identifier. Examples of time markers are "AM" and "PM" for English (United States).
	/// </para>
	/// <para>
	/// The time values in the structure indicated by lpTime must be valid. The function checks each of the time values to determine that
	/// it is within the appropriate range of values. If any of the time values are outside the correct range, the function fails, and
	/// sets the last error to ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// The function ignores the date members of the SYSTEMTIME structure. These include: <c>wYear</c>, <c>wMonth</c>, <c>wDayOfWeek</c>,
	/// and <c>wDay</c>.
	/// </para>
	/// <para>
	/// If TIME_NOMINUTESORSECONDS or TIME_NOSECONDS is specified, the function removes the separators preceding the minutes and/or
	/// seconds members.
	/// </para>
	/// <para>If TIME_NOTIMEMARKER is specified, the function removes the separators preceding and following the time marker.</para>
	/// <para>
	/// If TIME_FORCE24HOURFORMAT is specified, the function displays any existing time marker, unless the TIME_NOTIMEMARKER flag is also set.
	/// </para>
	/// <para>The function does not include milliseconds as part of the formatted time string.</para>
	/// <para>
	/// The function returns no errors for a bad format string, but just forms the best possible time string. If more than two hour,
	/// minute, second, or time marker format pictures are passed in, the function defaults to two. For example, the only time marker
	/// pictures that are valid are "t" and "tt". If "ttt" is passed in, the function assumes "tt".
	/// </para>
	/// <para>
	/// To obtain the time format without performing any actual formatting, the application should use the GetLocaleInfoEx function,
	/// specifying LOCALE_STIMEFORMAT.
	/// </para>
	/// <para>
	/// The application can use the following elements to construct a format picture string. If spaces are used to separate the elements
	/// in the format string, these spaces appear in the same location in the output string. The letters must be in uppercase or
	/// lowercase as shown, for example, "ss", not "SS". Characters in the format string that are enclosed in single quotation marks
	/// appear in the same location and unchanged in the output string.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Picture</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>h</term>
	/// <term>Hours with no leading zero for single-digit hours; 12-hour clock</term>
	/// </item>
	/// <item>
	/// <term>hh</term>
	/// <term>Hours with leading zero for single-digit hours; 12-hour clock</term>
	/// </item>
	/// <item>
	/// <term>H</term>
	/// <term>Hours with no leading zero for single-digit hours; 24-hour clock</term>
	/// </item>
	/// <item>
	/// <term>HH</term>
	/// <term>Hours with leading zero for single-digit hours; 24-hour clock</term>
	/// </item>
	/// <item>
	/// <term>m</term>
	/// <term>Minutes with no leading zero for single-digit minutes</term>
	/// </item>
	/// <item>
	/// <term>mm</term>
	/// <term>Minutes with leading zero for single-digit minutes</term>
	/// </item>
	/// <item>
	/// <term>s</term>
	/// <term>Seconds with no leading zero for single-digit seconds</term>
	/// </item>
	/// <item>
	/// <term>ss</term>
	/// <term>Seconds with leading zero for single-digit seconds</term>
	/// </item>
	/// <item>
	/// <term>t</term>
	/// <term>One character time marker string, such as A or P</term>
	/// </item>
	/// <item>
	/// <term>tt</term>
	/// <term>Multi-character time marker string, such as AM or PM</term>
	/// </item>
	/// </list>
	/// <para>For example, to get the time string</para>
	/// <para>the application should use the picture string</para>
	/// <para>
	/// This function can retrieve data from custom locales. Data is not guaranteed to be the same from computer to computer or between
	/// runs of an application. If your application must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> If your app passes language tags to this function from the Windows.Globalization namespace, it
	/// must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c><c>GetTimeFormatEx</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-gettimeformatex int GetTimeFormatEx( LPCWSTR
	// lpLocaleName, DWORD dwFlags, const SYSTEMTIME *lpTime, LPCWSTR lpFormat, LPWSTR lpTimeStr, int cchTime );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "4d63888e-4496-4315-ac87-bf60c54daa37")]
	public static extern int GetTimeFormatEx([Optional] string lpLocaleName, TIME_FORMAT dwFlags, in SYSTEMTIME lpTime, [Optional] string lpFormat, [Optional] StringBuilder lpTimeStr, int cchTime);

	/// <summary>
	/// <para>
	/// Formats time as a time string for a locale specified by name. The function formats either a specified time or the local system time.
	/// </para>
	/// <para>
	/// <c>Note</c> This function can format data that changes between releases, for example, due to a custom locale. If your application
	/// must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// </summary>
	/// <param name="lpLocaleName">
	/// <para>Pointer to a locale name, or one of the following predefined values.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>LOCALE_NAME_INVARIANT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_SYSTEM_DEFAULT</term>
	/// </item>
	/// <item>
	/// <term>LOCALE_NAME_USER_DEFAULT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags specifying time format options. The application can specify a combination of the following values and LOCALE_USE_CP_ACP or LOCALE_NOUSEROVERRIDE.
	/// </para>
	/// <para><c>Caution</c> Use of LOCALE_NOUSEROVERRIDE is strongly discouraged as it disables user preferences.</para>
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
	/// </param>
	/// <param name="lpTime">
	/// Pointer to a SYSTEMTIME structure that contains the time information to format. The application can set this parameter to
	/// <c>NULL</c> if the function is to use the current local system time.
	/// </param>
	/// <param name="lpFormat">
	/// Pointer to a format picture to use to format the time string. If the application sets this parameter to <c>NULL</c>, the function
	/// formats the string according to the time format of the specified locale. If the application does not set the parameter to
	/// <c>NULL</c>, the function uses the locale only for information not specified in the format picture string, for example, the
	/// locale-specific time markers. For information about the format picture string, see the Remarks section.
	/// </param>
	/// <param name="lpTimeStr">Pointer to a buffer in which this function retrieves the formatted time string.</param>
	/// <param name="cchTime">
	/// Size, in characters, for the time string buffer indicated by lpTimeStr. Alternatively, the application can set this parameter to
	/// 0. In this case, the function returns the required size for the time string buffer, and does not use the lpTimeStr parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns the number of characters retrieved in the buffer indicated by lpTimeStr. If the cchTime parameter is set to 0, the
	/// function returns the size of the buffer required to hold the formatted time string, including a terminating null character.
	/// </para>
	/// <para>
	/// This function returns 0 if it does not succeed. To get extended error information, the application can call GetLastError, which
	/// can return one of the following error codes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER. A supplied buffer size was not large enough, or it was incorrectly set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS. The values supplied for flags were not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER. Any of the parameter values was invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY. Not enough storage was available to complete this operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a time marker exists and the TIME_NOTIMEMARKER flag is not set, the function localizes the time marker based on the specified
	/// locale identifier. Examples of time markers are "AM" and "PM" for English (United States).
	/// </para>
	/// <para>
	/// The time values in the structure indicated by lpTime must be valid. The function checks each of the time values to determine that
	/// it is within the appropriate range of values. If any of the time values are outside the correct range, the function fails, and
	/// sets the last error to ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// The function ignores the date members of the SYSTEMTIME structure. These include: <c>wYear</c>, <c>wMonth</c>, <c>wDayOfWeek</c>,
	/// and <c>wDay</c>.
	/// </para>
	/// <para>
	/// If TIME_NOMINUTESORSECONDS or TIME_NOSECONDS is specified, the function removes the separators preceding the minutes and/or
	/// seconds members.
	/// </para>
	/// <para>If TIME_NOTIMEMARKER is specified, the function removes the separators preceding and following the time marker.</para>
	/// <para>
	/// If TIME_FORCE24HOURFORMAT is specified, the function displays any existing time marker, unless the TIME_NOTIMEMARKER flag is also set.
	/// </para>
	/// <para>The function does not include milliseconds as part of the formatted time string.</para>
	/// <para>
	/// The function returns no errors for a bad format string, but just forms the best possible time string. If more than two hour,
	/// minute, second, or time marker format pictures are passed in, the function defaults to two. For example, the only time marker
	/// pictures that are valid are "t" and "tt". If "ttt" is passed in, the function assumes "tt".
	/// </para>
	/// <para>
	/// To obtain the time format without performing any actual formatting, the application should use the GetLocaleInfoEx function,
	/// specifying LOCALE_STIMEFORMAT.
	/// </para>
	/// <para>
	/// The application can use the following elements to construct a format picture string. If spaces are used to separate the elements
	/// in the format string, these spaces appear in the same location in the output string. The letters must be in uppercase or
	/// lowercase as shown, for example, "ss", not "SS". Characters in the format string that are enclosed in single quotation marks
	/// appear in the same location and unchanged in the output string.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Picture</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>h</term>
	/// <term>Hours with no leading zero for single-digit hours; 12-hour clock</term>
	/// </item>
	/// <item>
	/// <term>hh</term>
	/// <term>Hours with leading zero for single-digit hours; 12-hour clock</term>
	/// </item>
	/// <item>
	/// <term>H</term>
	/// <term>Hours with no leading zero for single-digit hours; 24-hour clock</term>
	/// </item>
	/// <item>
	/// <term>HH</term>
	/// <term>Hours with leading zero for single-digit hours; 24-hour clock</term>
	/// </item>
	/// <item>
	/// <term>m</term>
	/// <term>Minutes with no leading zero for single-digit minutes</term>
	/// </item>
	/// <item>
	/// <term>mm</term>
	/// <term>Minutes with leading zero for single-digit minutes</term>
	/// </item>
	/// <item>
	/// <term>s</term>
	/// <term>Seconds with no leading zero for single-digit seconds</term>
	/// </item>
	/// <item>
	/// <term>ss</term>
	/// <term>Seconds with leading zero for single-digit seconds</term>
	/// </item>
	/// <item>
	/// <term>t</term>
	/// <term>One character time marker string, such as A or P</term>
	/// </item>
	/// <item>
	/// <term>tt</term>
	/// <term>Multi-character time marker string, such as AM or PM</term>
	/// </item>
	/// </list>
	/// <para>For example, to get the time string</para>
	/// <para>the application should use the picture string</para>
	/// <para>
	/// This function can retrieve data from custom locales. Data is not guaranteed to be the same from computer to computer or between
	/// runs of an application. If your application must persist or transmit data, see Using Persistent Locale Data.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c> If your app passes language tags to this function from the Windows.Globalization namespace, it
	/// must first convert the tags by calling ResolveLocaleName.
	/// </para>
	/// <para>
	/// <c>Beginning in Windows 8:</c><c>GetTimeFormatEx</c> is declared in Datetimeapi.h. Before Windows 8, it was declared in Winnls.h.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/datetimeapi/nf-datetimeapi-gettimeformatex int GetTimeFormatEx( LPCWSTR
	// lpLocaleName, DWORD dwFlags, const SYSTEMTIME *lpTime, LPCWSTR lpFormat, LPWSTR lpTimeStr, int cchTime );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("datetimeapi.h", MSDNShortId = "4d63888e-4496-4315-ac87-bf60c54daa37")]
	public static extern int GetTimeFormatEx([Optional] string lpLocaleName, TIME_FORMAT dwFlags, [In, Optional] IntPtr lpTime, [Optional] string lpFormat, [Optional] StringBuilder lpTimeStr, int cchTime);
}