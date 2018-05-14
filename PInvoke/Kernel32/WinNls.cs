using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		public const ushort LANG_INVARIANT = 0x7f;
		public const ushort LANG_NEUTRAL = 0;
		/// <summary>Name of an invariant locale that provides stable locale and calendar data.</summary>
		public const string LOCALE_NAME_INVARIANT = "";
		/// <summary>Maximum length of a locale name. The maximum number of characters allowed for this string is 85, including a terminating null character.</summary>
		public const int LOCALE_NAME_MAX_LENGTH = 85;
		/// <summary>Name of the current operating system locale.</summary>
		public const string LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";
		/// <summary>
		/// Name of the current user locale, matching the preference set in the regional and language options portion of Control Panel. This locale can be
		/// different from the locale for the current user interface language.
		/// </summary>
		public const string LOCALE_NAME_USER_DEFAULT = null;
		public const ushort SORT_DEFAULT = 0;
		public const ushort SUBLANG_CUSTOM_DEFAULT = 0x03;
		public const ushort SUBLANG_CUSTOM_UNSPECIFIED = 0x04;
		public const ushort SUBLANG_DEFAULT = 0x01;
		public const ushort SUBLANG_NEUTRAL = 0;
		public const ushort SUBLANG_SYS_DEFAULT = 0x02;
		public const ushort SUBLANG_UI_CUSTOM_DEFAULT = 0x05;

		public static readonly ushort LANG_SYSTEM_DEFAULT = MAKELANGID(LANG_NEUTRAL, SUBLANG_SYS_DEFAULT);
		public static readonly ushort LANG_USER_DEFAULT = MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT);
		public static readonly uint LOCALE_CUSTOM_DEFAULT = MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_CUSTOM_DEFAULT), SORT_DEFAULT);
		public static readonly uint LOCALE_CUSTOM_UI_DEFAULT = MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_UI_CUSTOM_DEFAULT), SORT_DEFAULT);
		public static readonly uint LOCALE_CUSTOM_UNSPECIFIED = MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_CUSTOM_UNSPECIFIED), SORT_DEFAULT);
		public static readonly uint LOCALE_INVARIANT = MAKELCID(MAKELANGID(LANG_INVARIANT, SUBLANG_NEUTRAL), SORT_DEFAULT);
		public static readonly uint LOCALE_NEUTRAL = MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), SORT_DEFAULT);
		public static readonly uint LOCALE_SYSTEM_DEFAULT = MAKELCID(LANG_SYSTEM_DEFAULT, SORT_DEFAULT);
		public static readonly uint LOCALE_USER_DEFAULT = MAKELCID(LANG_USER_DEFAULT, SORT_DEFAULT);

		/// <summary>
		/// An application-defined callback function that processes enumerated calendar information provided by the <c>EnumCalendarInfo</c> function. The
		/// CALINFO_ENUMPROC type defines a pointer to this callback function. <c>EnumCalendarInfoProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpCalendarInfoString">
		/// Pointer to a buffer containing a null-terminated calendar information string. This string is formatted according to the calendar type passed to <c>EnumCalendarInfo</c>.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumCalendarInfoProc( _In_ LPTSTR lpCalendarInfoString); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317806(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317806")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumCalendarInfoProc(string lpCalendarInfoString);

		/// <summary>
		/// An application-defined callback function that processes enumerated calendar information provided by the <c>EnumCalendarInfoEx</c> function. The
		/// CALINFO_ENUMPROCEX type defines a pointer to this callback function. <c>EnumCalendarInfoProcEx</c> is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="lpCalendarInfoString">
		/// Pointer to a buffer containing a null-terminated calendar information string. This string is formatted according to the calendar type passed to <c>EnumCalendarInfoEx</c>.
		/// </param>
		/// <param name="Calendar"><c>Calendar identifier</c> that specifies the calendar associated with the supplied information.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumCalendarInfoProcEx( _In_ LPTSTR lpCalendarInfoString, _In_ CALID Calendar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317807(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317807")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumCalendarInfoProcEx(string lpCalendarInfoString, uint Calendar);

		/// <summary>
		/// An application-defined callback function that processes enumerated calendar information provided by the <c>EnumCalendarInfoExEx</c> function. The
		/// CALINFO_ENUMPROCEXEX type defines a pointer to this callback function. <c>EnumCalendarInfoProcExEx</c> is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="lpCalendarInfoString">
		/// Pointer to a buffer containing a null-terminated calendar information string. This string is formatted according to the calendar type passed to <c>EnumCalendarInfoExEx</c>.
		/// </param>
		/// <param name="Calendar"><c>Calendar identifier</c> that specifies the calendar associated with the specified information.</param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <param name="lParam">
		/// An application-provided input parameter of <c>EnumCalendarInfoExEx</c>. This value is especially useful for multi-threaded applications, since it can
		/// be used to pass thread-specific data to this callback function.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumCalendarInfoProcExEx( _In_ LPWSTR lpCalendarInfoString, _In_ CALID Calendar, _In_ LPWSTR lpReserved, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317808(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317808")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumCalendarInfoProcExEx(string lpCalendarInfoString, uint Calendar, string lpReserved, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated code page information provided by the <c>EnumSystemCodePages</c> function. The
		/// CODEPAGE_ENUMPROC type defines a pointer to this callback function. <c>EnumCodePagesProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpCodePageString">Pointer to a buffer containing a null-terminated code page identifier string.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumCodePagesProc( _In_ LPTSTR lpCodePageString); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317809(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317809")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumCodePagesProc(string lpCodePageString);

		/// <summary>
		/// An application-defined callback function that processes date format information provided by the <c>EnumDateFormats</c> function. The DATEFMT_ENUMPROC
		/// type defines a pointer to this callback function. <c>EnumDateFormatsProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpDateFormatString">
		/// Pointer to a buffer containing a null-terminated date format string. This string is a long or short date format, depending on the value of the
		/// dwFlags parameter of <c>EnumDateFormats</c>.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumDateFormatsProc( _In_ LPTSTR lpDateFormatString); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317813(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317813")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumDateFormatsProc(string lpDateFormatString);

		/// <summary>
		/// An application-defined callback function that processes enumerated date format information provided by the <c>EnumDateFormatsEx</c> function. The
		/// DATEFMT_ENUMPROCEX type defines a pointer to this callback function. <c>EnumDateFormatsProcEx</c> is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="lpDateFormatString">
		/// Pointer to a buffer containing a null-terminated date format string. This string is a long or short date format, depending on the value of the
		/// dwFlags parameter of <c>EnumDateFormatsEx</c>.
		/// </param>
		/// <param name="CalendarID"><c>Calendar identifier</c> associated with the date format string.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumDateFormatsProcEx( _In_ LPTSTR lpDateFormatString, _In_ CALID CalendarID); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317814(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317814")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumDateFormatsProcEx(string lpDateFormatString, uint CalendarID);

		/// <summary>
		/// An application-defined function that processes enumerated date format information provided by the <c>EnumDateFormatsExEx</c> function. The
		/// DATEFMT_ENUMPROCEXEX type defines a pointer to this callback function. <c>EnumDateFormatsProcExEx</c> is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="lpDateFormatString">
		/// Pointer to a buffer containing a null-terminated date format string. This string is a long or short date format, depending on the value of the
		/// dwFlags parameter passed to <c>EnumDateFormatsExEx</c>.
		/// </param>
		/// <param name="CalendarID"><c>Calendar identifier</c> associated with the specified date format string.</param>
		/// <param name="lParam">
		/// An application-provided input parameter of <c>EnumDateFormatsExEx</c>. This parameter is especially useful for multi-threaded applications, since it
		/// can be used to pass thread-specific data to this callback function.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumDateFormatsProcExEx( _In_ LPWSTR lpDateFormatString, _In_ CALID CalendarID, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317815(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317815")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumDateFormatsProcExEx(string lpDateFormatString, uint CalendarID, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated geographical location information provided by the <c>EnumSystemGeoID</c> function.
		/// The GEO_ENUMPROC type defines a pointer to this callback function. <c>EnumGeoInfoProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="GeoId">Identifier of the geographical location to check.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumGeoInfoProc( _In_ GEOID GeoId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317817(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317817")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumGeoInfoProc(int GeoId);

		/// <summary>
		/// An application-defined callback function that processes enumerated language group locale information provided by the <c>EnumLanguageGroupLocales</c>
		/// function. The LANGGROUPLOCALE_ENUMPROC type defines a pointer to this callback function. <c>EnumLanguageGroupLocalesProc</c> is a placeholder for the
		/// application-defined function name.
		/// </summary>
		/// <param name="LanguageGroup">Identifier of the language group. This parameter can have one of the following values:</param>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="lpLocaleString">Pointer to a buffer containing a null-terminated locale identifier string.</param>
		/// <param name="lParam">Application-defined value passed to the <c>EnumLanguageGroupLocales</c> function. This parameter can be used for error checking.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumLanguageGroupLocalesProc( _In_ LGRPID LanguageGroup, _In_ LCID Locale, _In_ LPTSTR lpLocaleString, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317820(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317820")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumLanguageGroupLocalesProc(LGRPID LanguageGroup, uint Locale, string lpLocaleString, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated language group information provided by the <c>EnumSystemLanguageGroups</c>
		/// function. The LANGUAGEGROUP_ENUMPROC type defines a pointer to this callback function. <c>EnumLanguageGroupsProc</c> is a placeholder for the
		/// application-defined function name.
		/// </summary>
		/// <param name="LanguageGroup">Language group identifier. This parameter can have one of the following values:</param>
		/// <param name="lpLanguageGroupString">Pointer to a buffer containing a null-terminated language group identifier string.</param>
		/// <param name="lpLanguageGroupNameString">Pointer to a buffer containing a null-terminated language group name string.</param>
		/// <param name="dwFlags">
		/// <para>Flag specifying whether the language group identifier is supported or installed. This parameter can have one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term/>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>LGRPID_INSTALLED = 1</term>
		/// <term>Language group identifier is installed.</term>
		/// </item>
		/// <item>
		/// <term>LGRPID_SUPPORTED = 2</term>
		/// <term>Language group identifier is both supported and installed.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lParam">Application-defined parameter. This parameter can be used for error checking.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumLanguageGroupsProc( _In_ LGRPID LanguageGroup, _In_ LPTSTR lpLanguageGroupString, _In_ LPTSTR lpLanguageGroupNameString, _In_ DWORD
		// dwFlags, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317821(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317821")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumLanguageGroupsProc(LGRPID LanguageGroup, string lpLanguageGroupString, string lpLanguageGroupNameString, LGRPID_FLAGS dwFlags, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated locale information provided by the <c>EnumSystemLocales</c> function. The
		/// LOCALE_ENUMPROC type defines a pointer to this callback function. <c>EnumLocalesProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpLocaleString">Pointer to a buffer containing a null-terminated locale identifier string.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumLocalesProc( _In_ LPTSTR lpLocaleString); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317822(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317822")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumLocalesProc(string lpLocaleString);

		/// <summary>
		/// An application-defined callback function that processes enumerated locale information provided by the <c>EnumSystemLocalesEx</c> function. The
		/// LOCALE_ENUMPROCEX type defines a pointer to this callback function. <c>EnumLocalesProcEx</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpLocaleString">Pointer to a buffer containing a null-terminated locale name string.</param>
		/// <param name="dwFlags">
		/// Flags defining locale information. Values for this parameter can include a binary OR of flags, but some flag combinations never occur. If the
		/// application specifies LOCALE_WINDOWS or LOCALE_ALTERNATE_SORTS, it can also specify LOCALE_REPLACEMENT so that the <c>EnumSystemLocalesEx</c>
		/// function can test to see if the locale is a replacement.
		/// </param>
		/// <param name="lParam">
		/// An application-provided input parameter of <c>EnumSystemLocalesEx</c>. This value is especially useful for multi-threaded applications, since it can
		/// be used to pass thread-specific data to this callback function.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumLocalesProcEx( _In_ LPWSTR lpLocaleString, _In_ DWORD dwFlags, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317823(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317823")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumLocalesProcEx(string lpLocaleString, LOCALE_FLAGS dwFlags, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated time format information provided by the <c>EnumTimeFormats</c> function. The
		/// TIMEFMT_ENUMPROC type defines a pointer to this callback function. <c>EnumTimeFormatsProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpTimeFormatString">Pointer to a buffer containing a null-terminated time format string.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumTimeFormatsProc( _In_ LPTSTR lpTimeFormatString); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317832(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317832")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumTimeFormatsProc(string lpTimeFormatString);

		/// <summary>
		/// An application-defined callback function that processes enumerated time format information provided by the <c>EnumTimeFormatsEx</c> function. The
		/// TIMEFMT_ENUMPROCEX type defines a pointer to this callback function. <c>EnumTimeFormatsProcEx</c> is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="lpTimeFormatString">Pointer to a buffer containing a null-terminated time format string.</param>
		/// <param name="lParam">
		/// An application-provided input parameter of <c>EnumTimeFormatsEx</c>. This value is especially useful for multi-threaded applications, since it can be
		/// used to pass thread-specific data to this callback function.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumTimeFormatsProcEx( _In_ LPWSTR lpTimeFormatString, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317833(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317833")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumTimeFormatsProcEx(string lpTimeFormatString, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated user interface language information provided by the <c>EnumUILanguages</c>
		/// function. The UILANGUAGE_ENUMPROC type defines a pointer to this callback function. <c>EnumUILanguagesProc</c> is a placeholder for the
		/// application-defined function name.
		/// </summary>
		/// <param name="lpUILanguageString">
		/// Pointer to a buffer containing a null-terminated string representing a user interface language identifier or language name, depending on the value
		/// for the dwFlags parameter passed in the call to <c>EnumUILanguages</c>.
		/// </param>
		/// <param name="lParam">Application-defined value.</param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK EnumUILanguagesProc( _In_ LPTSTR lpUILanguageString, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317835(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317835")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool EnumUILanguagesProc(string lpUILanguageString, IntPtr lParam);

		/// <summary>
		/// An application-defined callback function that processes enumerated geographical location information provided by the <c>EnumSystemGeoNames</c>
		/// function. The <c>GEO_ENUMNAMEPROC</c> type defines a pointer to this callback function. Geo_EnumNameProc is a placeholder for the application-defined
		/// function name.
		/// </summary>
		/// <param name="GeoName">
		/// A two-letter International Organization for Standardization (ISO) 3166-1 code or numeric United Nations (UN) Series M, Number 49 (M.49) code for a
		/// geographical location that is available on the operating system.
		/// </param>
		/// <param name="data">
		/// Application-specific information that was specified by the data parameter when the application called the <c>EnumSystemGeoNames</c> function.
		/// </param>
		/// <returns>Returns <c>TRUE</c> to continue enumeration or <c>FALSE</c> otherwise.</returns>
		// BOOL CALLBACK Geo_EnumNameProc( _In_ PWSTR GeoName, LPARAM data); https://msdn.microsoft.com/en-us/library/windows/desktop/mt826488(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "mt826488")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool Geo_EnumNameProc(string GeoName, IntPtr data);

		/// <summary>Type of calendar information to retrieve.</summary>
		[Flags]
		public enum CALTYPE : uint
		{
			CAL_NOUSEROVERRIDE = LCTYPE.LOCALE_NOUSEROVERRIDE,
			CAL_USE_CP_ACP = LCTYPE.LOCALE_USE_CP_ACP,
			CAL_RETURN_NUMBER = LCTYPE.LOCALE_RETURN_NUMBER,
			CAL_RETURN_GENITIVE_NAMES = LCTYPE.LOCALE_RETURN_GENITIVE_NAMES,
			CAL_ICALINTVALUE = 0x00000001,
			CAL_SCALNAME = 0x00000002,
			CAL_IYEAROFFSETRANGE = 0x00000003,
			CAL_SERASTRING = 0x00000004,
			CAL_SSHORTDATE = 0x00000005,
			CAL_SLONGDATE = 0x00000006,
			CAL_SDAYNAME1 = 0x00000007,
			CAL_SDAYNAME2 = 0x00000008,
			CAL_SDAYNAME3 = 0x00000009,
			CAL_SDAYNAME4 = 0x0000000a,
			CAL_SDAYNAME5 = 0x0000000b,
			CAL_SDAYNAME6 = 0x0000000c,
			CAL_SDAYNAME7 = 0x0000000d,
			CAL_SABBREVDAYNAME1 = 0x0000000e,
			CAL_SABBREVDAYNAME2 = 0x0000000f,
			CAL_SABBREVDAYNAME3 = 0x00000010,
			CAL_SABBREVDAYNAME4 = 0x00000011,
			CAL_SABBREVDAYNAME5 = 0x00000012,
			CAL_SABBREVDAYNAME6 = 0x00000013,
			CAL_SABBREVDAYNAME7 = 0x00000014,
			CAL_SMONTHNAME1 = 0x00000015,
			CAL_SMONTHNAME2 = 0x00000016,
			CAL_SMONTHNAME3 = 0x00000017,
			CAL_SMONTHNAME4 = 0x00000018,
			CAL_SMONTHNAME5 = 0x00000019,
			CAL_SMONTHNAME6 = 0x0000001a,
			CAL_SMONTHNAME7 = 0x0000001b,
			CAL_SMONTHNAME8 = 0x0000001c,
			CAL_SMONTHNAME9 = 0x0000001d,
			CAL_SMONTHNAME10 = 0x0000001e,
			CAL_SMONTHNAME11 = 0x0000001f,
			CAL_SMONTHNAME12 = 0x00000020,
			CAL_SMONTHNAME13 = 0x00000021,
			CAL_SABBREVMONTHNAME1 = 0x00000022,
			CAL_SABBREVMONTHNAME2 = 0x00000023,
			CAL_SABBREVMONTHNAME3 = 0x00000024,
			CAL_SABBREVMONTHNAME4 = 0x00000025,
			CAL_SABBREVMONTHNAME5 = 0x00000026,
			CAL_SABBREVMONTHNAME6 = 0x00000027,
			CAL_SABBREVMONTHNAME7 = 0x00000028,
			CAL_SABBREVMONTHNAME8 = 0x00000029,
			CAL_SABBREVMONTHNAME9 = 0x0000002a,
			CAL_SABBREVMONTHNAME10 = 0x0000002b,
			CAL_SABBREVMONTHNAME11 = 0x0000002c,
			CAL_SABBREVMONTHNAME12 = 0x0000002d,
			CAL_SABBREVMONTHNAME13 = 0x0000002e,
			CAL_SYEARMONTH = 0x0000002f,
			CAL_ITWODIGITYEARMAX = 0x00000030,
			CAL_SSHORTESTDAYNAME1 = 0x00000031,
			CAL_SSHORTESTDAYNAME2 = 0x00000032,
			CAL_SSHORTESTDAYNAME3 = 0x00000033,
			CAL_SSHORTESTDAYNAME4 = 0x00000034,
			CAL_SSHORTESTDAYNAME5 = 0x00000035,
			CAL_SSHORTESTDAYNAME6 = 0x00000036,
			CAL_SSHORTESTDAYNAME7 = 0x00000037,
			CAL_SMONTHDAY = 0x00000038,
			CAL_SABBREVERASTRING = 0x00000039,
			CAL_SRELATIVELONGDATE = 0x0000003a,
			CAL_SENGLISHERANAME = 0x0000003b,
			CAL_SENGLISHABBREVERANAME = 0x0000003c,
		}

		/// <summary>Flag specifying the code pages to enumerate.</summary>
		public enum CP_FLAGS
		{
			/// <summary>Enumerate only installed code pages.</summary>
			CP_INSTALLED = 1,
			/// <summary>Enumerate all supported code pages.</summary>
			CP_SUPPORTED = 2
		}

		/// <summary>Flag specifying date formats.</summary>
		[Flags]
		public enum DATE_FORMAT
		{
			/// <summary>Use short date formats. This value cannot be used with any of the other flag values.</summary>
			DATE_SHORTDATE = 0x00000001,
			/// <summary>Use long date formats. This value cannot be used with any of the other flag values.</summary>
			DATE_LONGDATE = 0x00000002,
			/// <summary>
			/// Use the alternate calendar, if one exists, to format the date string. If this flag is set, the function uses the default format for that
			/// alternate calendar, rather than using any user overrides. The user overrides will be used only in the event that there is no default format for
			/// the specified alternate calendar.
			/// </summary>
			DATE_USE_ALT_CALENDAR = 0x00000004,
			/// <summary>Use year/month formats. This value cannot be used with any of the other flag values.</summary>
			DATE_YEARMONTH = 0x00000008,
			/// <summary>Add marks for left-to-right reading layout. This value cannot be used with DATE_RTLREADING.</summary>
			DATE_LTRREADING = 0x00000010,
			/// <summary>Add marks for right-to-left reading layout. This value cannot be used with DATE_LTRREADING</summary>
			DATE_RTLREADING = 0x00000020,
			/// <summary>
			/// <c>Windows 7 and later:</c> Detect the need for right-to-left and left-to-right reading layout using the locale and calendar information, and add
			/// marks accordingly. This value cannot be used with DATE_LTRREADING or DATE_RTLREADING. DATE_AUTOLAYOUT is preferred over DATE_LTRREADING and
			/// DATE_RTLREADING because it uses the locales and calendars to determine the correct addition of marks.
			/// </summary>
			DATE_AUTOLAYOUT = 0x00000040,
			/// <summary>Use month/day formats. This value cannot be used with any of the other flag values.</summary>
			DATE_MONTHDAY = 0x00000080,
		}

		/// <summary>Flags specifying options for script retrieval.</summary>
		public enum GetStringScriptsFlag
		{
			/// <summary>
			/// Ignores any inherited or common characters in the input string indicated by lpString. Neither "Qaii" nor "Zyyy" appears in the script string,
			/// even if the input string contains such characters.
			/// </summary>
			GSS_IGNORE_INHERITED_COMMON = 0x0000,
			/// <summary>
			/// Retrieve "Qaii" (INHERITED) and "Zyyy" (COMMON) script information. This flag does not affect the processing of unassigned characters. These
			/// characters in the input string always cause a "Zzzz" (UNASSIGNED script) to appear in the script string.
			/// </summary>
			GSS_ALLOW_INHERITED_COMMON = 0x0001,
		}

		/// <summary>Flags specifying conversion options.</summary>
		[Flags]
		public enum IDN_FLAGS
		{
			/// <summary>
			/// Allow unassigned code points to be included in the input string. The default is to not allow unassigned code points, and fail with an extended
			/// error code of ERROR_INVALID_NAME.This flag allows the function to process characters that are not currently legal in IDNs, but might be legal in
			/// later versions of the IDNA standard. If your application encodes unassigned code points as Punycode, the resulting domain names should be
			/// illegal. Security can be compromised if a later version of IDNA makes these names legal or if an application filters out the illegal characters
			/// to try to create a legal domain name. For more information, see Handling Internationalized Domain Names (IDNs).
			/// </summary>
			IDN_ALLOW_UNASSIGNED = 0x01,
			/// <summary>
			/// Filter out ASCII characters that are not allowed in STD3 names. The only ASCII characters allowed in the input Unicode string are letters,
			/// digits, and the hyphen-minus. The string cannot begin or end with the hyphen-minus. The function fails if the input Unicode string contains ASCII
			/// characters, such as &amp;quot;[&amp;quot;, &amp;quot;]&amp;quot;, or &amp;quot;/&amp;quot;, that cannot occur in domain names.The function fails
			/// if the input Unicode string contains control characters (U+0001 through U+0020) or the &amp;quot;delete&amp;quot; character (U+007F). In either
			/// case, this flag has no effect on the non-ASCII characters that are allowed in the Unicode string.
			/// </summary>
			IDN_USE_STD3_ASCII_RULES = 0x02,
			/// <summary>
			/// Starting with Windows 8: Enable EAI algorithmic fallback for the local parts of email addresses (such as &amp;lt;local&amp;gt;@microsoft.com).
			/// The default is for this function to fail when an email address has an invalid address or syntax.An application can set this flag to enable Email
			/// Address Internationalization (EAI) to return a discoverable fallback address, if possible. For more information, see the IETF Email Address
			/// Internationalization (eai) Charter.
			/// </summary>
			IDN_EMAIL_ADDRESS = 0x04,
			/// <summary>Starting with Windows 8: Disable the validation and mapping of Punycode.</summary>
			IDN_RAW_PUNYCODE = 0x08,
		}

		/// <summary>Flags specifying the locale identifiers to enumerate.</summary>
		[Flags]
		public enum LCID_FLAGS
		{
			/// <summary>Enumerate only installed locale identifiers. This value cannot be used with LCID_SUPPORTED.</summary>
			LCID_INSTALLED = 0x00000001,
			/// <summary>Enumerate all supported locale identifiers. This value cannot be used with LCID_INSTALLED.</summary>
			LCID_SUPPORTED = 0x00000002,
			/// <summary>
			/// Enumerate only the alternate sort locale identifiers. If this value is used with either LCID_INSTALLED or LCID_SUPPORTED, the installed or
			/// supported locales are retrieved, as well as the alternate sort locale identifiers.
			/// </summary>
			LCID_ALTERNATE_SORTS = 0x00000004,
		}

		/// <summary>Flag specifying the type of transformation to use during string mapping or the type of sort key to generate.</summary>
		[Flags]
		public enum LCMAP
		{
			/// <summary>For locales and scripts capable of handling uppercase and lowercase, map all characters to lowercase.</summary>
			LCMAP_LOWERCASE = 0x00000100,
			/// <summary>For locales and scripts capable of handling uppercase and lowercase, map all characters to uppercase.</summary>
			LCMAP_UPPERCASE = 0x00000200,
			/// <summary>Windows 7: Map all characters to title case, in which the first letter of each major word is capitalized.</summary>
			LCMAP_TITLECASE = 0x00000300,
			/// <summary>
			/// Produce a normalized sort key. If the LCMAP_SORTKEY flag is not specified, the function performs string mapping. For details of sort key
			/// generation and string mapping, see the Remarks section.
			/// </summary>
			LCMAP_SORTKEY = 0x00000400,
			/// <summary>Use byte reversal. For example, if the application passes in 0x3450 0x4822, the result is 0x5034 0x2248.</summary>
			LCMAP_BYTEREV = 0x00000800,
			/// <summary>Map all katakana characters to hiragana. This flag and LCMAP_KATAKANA are mutually exclusive.</summary>
			LCMAP_HIRAGANA = 0x00100000,
			/// <summary>Map all hiragana characters to katakana. This flag and LCMAP_HIRAGANA are mutually exclusive.</summary>
			LCMAP_KATAKANA = 0x00200000,
			/// <summary>Use narrow characters where applicable. This flag and LCMAP_FULLWIDTH are mutually exclusive.</summary>
			LCMAP_HALFWIDTH = 0x00400000,
			/// <summary>
			/// Use Unicode (wide) characters where applicable. This flag and LCMAP_HALFWIDTH are mutually exclusive. With this flag, the mapping may use
			/// Normalization Form C even if an input character is already full-width. For example, the string "は゛" (which is already full-width) is normalized
			/// to "ば". See Unicode normalization forms.
			/// </summary>
			LCMAP_FULLWIDTH = 0x00800000,
			/// <summary>
			/// Use linguistic rules for casing, instead of file system rules (default). This flag is valid with LCMAP_LOWERCASE or LCMAP_UPPERCASE only.
			/// </summary>
			LCMAP_LINGUISTIC_CASING = 0x01000000,
			/// <summary>Map traditional Chinese characters to simplified Chinese characters. This flag and LCMAP_TRADITIONAL_CHINESE are mutually exclusive.</summary>
			LCMAP_SIMPLIFIED_CHINESE = 0x02000000,
			/// <summary>Map simplified Chinese characters to traditional Chinese characters. This flag and LCMAP_SIMPLIFIED_CHINESE are mutually exclusive.</summary>
			LCMAP_TRADITIONAL_CHINESE = 0x04000000,
		}

		/// <summary>Locale Types.</summary>
		[Flags]
		public enum LCTYPE : uint
		{
			LOCALE_NOUSEROVERRIDE = 0x80000000,
			LOCALE_USE_CP_ACP = 0x40000000,
			LOCALE_RETURN_NUMBER = 0x20000000,
			LOCALE_RETURN_GENITIVE_NAMES = 0x10000000,
			LOCALE_ALLOW_NEUTRAL_NAMES = 0x08000000,
			LOCALE_SLOCALIZEDDISPLAYNAME = 0x00000002,
			LOCALE_SENGLISHDISPLAYNAME = 0x00000072,
			LOCALE_SNATIVEDISPLAYNAME = 0x00000073,
			LOCALE_SLOCALIZEDLANGUAGENAME = 0x0000006f,
			LOCALE_SENGLISHLANGUAGENAME = 0x00001001,
			LOCALE_SNATIVELANGUAGENAME = 0x00000004,
			LOCALE_SLOCALIZEDCOUNTRYNAME = 0x00000006,
			LOCALE_SENGLISHCOUNTRYNAME = 0x00001002,
			LOCALE_SNATIVECOUNTRYNAME = 0x00000008,
			LOCALE_IDIALINGCODE = 0x00000005,
			LOCALE_SLIST = 0x0000000C,
			LOCALE_IMEASURE = 0x0000000D,
			LOCALE_SDECIMAL = 0x0000000E,
			LOCALE_STHOUSAND = 0x0000000F,
			LOCALE_SGROUPING = 0x00000010,
			LOCALE_IDIGITS = 0x00000011,
			LOCALE_ILZERO = 0x00000012,
			LOCALE_INEGNUMBER = 0x00001010,
			LOCALE_SNATIVEDIGITS = 0x00000013,
			LOCALE_SCURRENCY = 0x00000014,
			LOCALE_SINTLSYMBOL = 0x00000015,
			LOCALE_SMONDECIMALSEP = 0x00000016,
			LOCALE_SMONTHOUSANDSEP = 0x00000017,
			LOCALE_SMONGROUPING = 0x00000018,
			LOCALE_ICURRDIGITS = 0x00000019,
			LOCALE_ICURRENCY = 0x0000001B,
			LOCALE_INEGCURR = 0x0000001C,
			LOCALE_SSHORTDATE = 0x0000001F,
			LOCALE_SLONGDATE = 0x00000020,
			LOCALE_STIMEFORMAT = 0x00001003,
			LOCALE_SAM = 0x00000028,
			LOCALE_SPM = 0x00000029,
			LOCALE_ICALENDARTYPE = 0x00001009,
			LOCALE_IOPTIONALCALENDAR = 0x0000100B,
			LOCALE_IFIRSTDAYOFWEEK = 0x0000100C,
			LOCALE_IFIRSTWEEKOFYEAR = 0x0000100D,
			LOCALE_SDAYNAME1 = 0x0000002A,
			LOCALE_SDAYNAME2 = 0x0000002B,
			LOCALE_SDAYNAME3 = 0x0000002C,
			LOCALE_SDAYNAME4 = 0x0000002D,
			LOCALE_SDAYNAME5 = 0x0000002E,
			LOCALE_SDAYNAME6 = 0x0000002F,
			LOCALE_SDAYNAME7 = 0x00000030,
			LOCALE_SABBREVDAYNAME1 = 0x00000031,
			LOCALE_SABBREVDAYNAME2 = 0x00000032,
			LOCALE_SABBREVDAYNAME3 = 0x00000033,
			LOCALE_SABBREVDAYNAME4 = 0x00000034,
			LOCALE_SABBREVDAYNAME5 = 0x00000035,
			LOCALE_SABBREVDAYNAME6 = 0x00000036,
			LOCALE_SABBREVDAYNAME7 = 0x00000037,
			LOCALE_SMONTHNAME1 = 0x00000038,
			LOCALE_SMONTHNAME2 = 0x00000039,
			LOCALE_SMONTHNAME3 = 0x0000003A,
			LOCALE_SMONTHNAME4 = 0x0000003B,
			LOCALE_SMONTHNAME5 = 0x0000003C,
			LOCALE_SMONTHNAME6 = 0x0000003D,
			LOCALE_SMONTHNAME7 = 0x0000003E,
			LOCALE_SMONTHNAME8 = 0x0000003F,
			LOCALE_SMONTHNAME9 = 0x00000040,
			LOCALE_SMONTHNAME10 = 0x00000041,
			LOCALE_SMONTHNAME11 = 0x00000042,
			LOCALE_SMONTHNAME12 = 0x00000043,
			LOCALE_SMONTHNAME13 = 0x0000100E,
			LOCALE_SABBREVMONTHNAME1 = 0x00000044,
			LOCALE_SABBREVMONTHNAME2 = 0x00000045,
			LOCALE_SABBREVMONTHNAME3 = 0x00000046,
			LOCALE_SABBREVMONTHNAME4 = 0x00000047,
			LOCALE_SABBREVMONTHNAME5 = 0x00000048,
			LOCALE_SABBREVMONTHNAME6 = 0x00000049,
			LOCALE_SABBREVMONTHNAME7 = 0x0000004A,
			LOCALE_SABBREVMONTHNAME8 = 0x0000004B,
			LOCALE_SABBREVMONTHNAME9 = 0x0000004C,
			LOCALE_SABBREVMONTHNAME10 = 0x0000004D,
			LOCALE_SABBREVMONTHNAME11 = 0x0000004E,
			LOCALE_SABBREVMONTHNAME12 = 0x0000004F,
			LOCALE_SABBREVMONTHNAME13 = 0x0000100F,
			LOCALE_SPOSITIVESIGN = 0x00000050,
			LOCALE_SNEGATIVESIGN = 0x00000051,
			LOCALE_IPOSSIGNPOSN = 0x00000052,
			LOCALE_INEGSIGNPOSN = 0x00000053,
			LOCALE_IPOSSYMPRECEDES = 0x00000054,
			LOCALE_IPOSSEPBYSPACE = 0x00000055,
			LOCALE_INEGSYMPRECEDES = 0x00000056,
			LOCALE_INEGSEPBYSPACE = 0x00000057,
			LOCALE_FONTSIGNATURE = 0x00000058,
			LOCALE_SISO639LANGNAME = 0x00000059,
			LOCALE_SISO3166CTRYNAME = 0x0000005A,
			LOCALE_IPAPERSIZE = 0x0000100A,
			LOCALE_SENGCURRNAME = 0x00001007,
			LOCALE_SNATIVECURRNAME = 0x00001008,
			LOCALE_SYEARMONTH = 0x00001006,
			LOCALE_SSORTNAME = 0x00001013,
			LOCALE_IDIGITSUBSTITUTION = 0x00001014,
			LOCALE_SNAME = 0x0000005c,
			LOCALE_SDURATION = 0x0000005d,
			LOCALE_SSHORTESTDAYNAME1 = 0x00000060,
			LOCALE_SSHORTESTDAYNAME2 = 0x00000061,
			LOCALE_SSHORTESTDAYNAME3 = 0x00000062,
			LOCALE_SSHORTESTDAYNAME4 = 0x00000063,
			LOCALE_SSHORTESTDAYNAME5 = 0x00000064,
			LOCALE_SSHORTESTDAYNAME6 = 0x00000065,
			LOCALE_SSHORTESTDAYNAME7 = 0x00000066,
			LOCALE_SISO639LANGNAME2 = 0x00000067,
			LOCALE_SISO3166CTRYNAME2 = 0x00000068,
			LOCALE_SNAN = 0x00000069,
			LOCALE_SPOSINFINITY = 0x0000006a,
			LOCALE_SNEGINFINITY = 0x0000006b,
			LOCALE_SSCRIPTS = 0x0000006c,
			LOCALE_SPARENT = 0x0000006d,
			LOCALE_SCONSOLEFALLBACKNAME = 0x0000006e,
			LOCALE_IREADINGLAYOUT = 0x00000070,
			LOCALE_INEUTRAL = 0x00000071,
			LOCALE_INEGATIVEPERCENT = 0x00000074,
			LOCALE_IPOSITIVEPERCENT = 0x00000075,
			LOCALE_SPERCENT = 0x00000076,
			LOCALE_SPERMILLE = 0x00000077,
			LOCALE_SMONTHDAY = 0x00000078,
			LOCALE_SSHORTTIME = 0x00000079,
			LOCALE_SOPENTYPELANGUAGETAG = 0x0000007a,
			LOCALE_SSORTLOCALE = 0x0000007b,
			LOCALE_SRELATIVELONGDATE = 0x0000007c,
			LOCALE_SSHORTESTAM = 0x0000007e,
			LOCALE_SSHORTESTPM = 0x0000007f,
			LOCALE_IDEFAULTCODEPAGE = 0x0000000B,
			LOCALE_IDEFAULTANSICODEPAGE = 0x00001004,
			LOCALE_IDEFAULTMACCODEPAGE = 0x00001011,
			LOCALE_IDEFAULTEBCDICCODEPAGE = 0x00001012,
			LOCALE_ILANGUAGE = 0x00000001,
			LOCALE_SABBREVLANGNAME = 0x00000003,
			LOCALE_SABBREVCTRYNAME = 0x00000007,
			LOCALE_IGEOID = 0x0000005B,
			LOCALE_IDEFAULTLANGUAGE = 0x00000009,
			LOCALE_IDEFAULTCOUNTRY = 0x0000000A,
			LOCALE_IINTLCURRDIGITS = 0x0000001A,
			LOCALE_SDATE = 0x0000001D,
			LOCALE_STIME = 0x0000001E,
			LOCALE_IDATE = 0x00000021,
			LOCALE_ILDATE = 0x00000022,
			LOCALE_ITIME = 0x00000023,
			LOCALE_ITIMEMARKPOSN = 0x00001005,
			LOCALE_ICENTURY = 0x00000024,
			LOCALE_ITLZERO = 0x00000025,
			LOCALE_IDAYLZERO = 0x00000026,
			LOCALE_IMONLZERO = 0x00000027,
			LOCALE_SKEYBOARDSTOINSTALL = 0x0000005e,
			LOCALE_SLANGUAGE = LOCALE_SLOCALIZEDDISPLAYNAME,
			LOCALE_SLANGDISPLAYNAME = LOCALE_SLOCALIZEDLANGUAGENAME,
			LOCALE_SENGLANGUAGE = LOCALE_SENGLISHLANGUAGENAME,
			LOCALE_SNATIVELANGNAME = LOCALE_SNATIVELANGUAGENAME,
			LOCALE_SCOUNTRY = LOCALE_SLOCALIZEDCOUNTRYNAME,
			LOCALE_SENGCOUNTRY = LOCALE_SENGLISHCOUNTRYNAME,
			LOCALE_SNATIVECTRYNAME = LOCALE_SNATIVECOUNTRYNAME,
			LOCALE_ICOUNTRY = LOCALE_IDIALINGCODE,
			LOCALE_S1159 = LOCALE_SAM,
			LOCALE_S2359 = LOCALE_SPM,
		}

		/// <summary>Language Group Identifier.</summary>
		public enum LGRPID : uint
		{
			/// <summary>Western Europe & U.S.</summary>
			LGRPID_WESTERN_EUROPE = 0x0001,
			/// <summary>Central Europe</summary>
			LGRPID_CENTRAL_EUROPE = 0x0002,
			/// <summary>Baltic</summary>
			LGRPID_BALTIC = 0x0003,
			/// <summary>Greek</summary>
			LGRPID_GREEK = 0x0004,
			/// <summary>Cyrillic</summary>
			LGRPID_CYRILLIC = 0x0005,
			/// <summary>Turkic</summary>
			LGRPID_TURKIC = 0x0006,
			/// <summary>Turkish</summary>
			LGRPID_TURKISH = 0x0006,
			/// <summary>Japanese</summary>
			LGRPID_JAPANESE = 0x0007,
			/// <summary>Korean</summary>
			LGRPID_KOREAN = 0x0008,
			/// <summary>Traditional Chinese</summary>
			LGRPID_TRADITIONAL_CHINESE = 0x0009,
			/// <summary>Simplified Chinese</summary>
			LGRPID_SIMPLIFIED_CHINESE = 0x000a,
			/// <summary>Thai</summary>
			LGRPID_THAI = 0x000b,
			/// <summary>Hebrew</summary>
			LGRPID_HEBREW = 0x000c,
			/// <summary>Arabic</summary>
			LGRPID_ARABIC = 0x000d,
			/// <summary>Vietnamese</summary>
			LGRPID_VIETNAMESE = 0x000e,
			/// <summary>Indic</summary>
			LGRPID_INDIC = 0x000f,
			/// <summary>Georgian</summary>
			LGRPID_GEORGIAN = 0x0010,
			/// <summary>Armenian</summary>
			LGRPID_ARMENIAN = 0x0011,
		}

		/// <summary>Flag specifying whether the language group identifier is supported or installed.</summary>
		public enum LGRPID_FLAGS
		{
			/// <summary>Language group identifier is installed.</summary>
			LGRPID_INSTALLED = 0x00000001,
			/// <summary>Language group identifier is both supported and installed.</summary>
			LGRPID_SUPPORTED = 0x00000002,
		}

		/// <summary>Flags identifying the locales to enumerate.</summary>
		[Flags]
		public enum LOCALE_FLAGS
		{
			/// <summary>
			/// Windows Vista and later: Enumerate all locales. Using this constant is equivalent to using LOCALE_WINDOWS | LOCALE_SUPPLEMENTAL |
			/// LOCALE_ALTERNATE_SORTS | LOCALE_NEUTRALDATA.
			/// </summary>
			LOCALE_ALL = 0,
			/// <summary>
			/// Windows Vista and later: Enumerate all locales that come with the operating system, including replacement locales, but excluding alternate sorts.
			/// For more information, see Custom Locales.
			/// </summary>
			LOCALE_WINDOWS = 0x00000001,
			/// <summary>Windows Vista and later: Enumerate supplemental locales.</summary>
			LOCALE_SUPPLEMENTAL = 0x00000002,
			/// <summary>Windows Vista and later: Enumerate only the alternate sorts, locales with a nonzero sort order identifier.</summary>
			LOCALE_ALTERNATE_SORTS = 0x00000004,
			/// <summary>Windows Vista and later: Enumerate replacement locales. This constant is valid input only for EnumLocalesProcEx.</summary>
			LOCALE_REPLACEMENT = 0x00000008,
			/// <summary>Windows 7 and later: Neutral locale data, that is, data defined by language only. Country/region data uses the default.</summary>
			LOCALE_NEUTRALDATA = 0x00000010,
			/// <summary>Windows 7 and later: Locale data specified by both language and country/region.</summary>
			LOCALE_SPECIFICDATA = 0x00000020,
		}

		/// <summary>Flags controlling currency format.</summary>
		public enum LOCALE_FORMAT_FLAG : uint
		{
			/// <summary>Formats the string using user overrides to the default currency format for the locale.</summary>
			LOCALE_UNSPECIFIED = 0,
			/// <summary>Format the string using the system default currency format for the specified locale.</summary>
			LOCALE_NOUSEROVERRIDE = 0x80000000
		}

		/// <summary>Flags indicating attributes of the input language list.</summary>
		[Flags]
		public enum MUI_LANGUAGE
		{
			/// <summary>The language is fully localized.</summary>
			MUI_FULL_LANGUAGE = 1,
			/// <summary>The language is fully localized.</summary>
			MUI_PARTIAL_LANGUAGE = 2,
			/// <summary>The language is an LIP language.</summary>
			MUI_LIP_LANGUAGE = 4,
			/// <summary>The language is installed on this computer.</summary>
			MUI_LANGUAGE_INSTALLED = 32,
			/// <summary>The language is appropriately licensed for the current user.</summary>
			MUI_LANGUAGE_LICENSED = 64,
		}

		/// <summary>Flags identifying language format and filtering.</summary>
		[Flags]
		public enum MUI_LANGUAGE_ENUM
		{
			/// <summary>Pass the language identifier in the language string to the callback function.</summary>
			MUI_LANGUAGE_ID = 4,
			/// <summary>Pass the language name in the language string to the callback function.</summary>
			MUI_LANGUAGE_NAME = 8
		}

		/// <summary>Flags specifying the information to retrieve in <c>GetFileMUIInfo</c>.</summary>
		[Flags]
		public enum MUI_QUERY
		{
			/// <summary>
			/// Retrieve one of the following values in the dwFileType member of FILEMUIINFO:
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL: The specified input file does not have resource configuration data. Thus it is neither an LN file nor a
			///                                    language-specific resource file. This type of file is typical for older executable files. If this file type is
			///                                    specified, the function will not retrieve useful information for the other types.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MUI_FILETYPE_LANGUAGE_NEUTRAL_MAIN. The input file is an LN file.</term>
			/// </item>
			/// <item>
			/// <term>MUI_FILETYPE_LANGUAGE_NEUTRAL_MUI. The input file is a language-specific resource file associated with an LN file.</term>
			/// </item>
			/// </list>
			/// </summary>
			MUI_QUERY_TYPE = 0x001,
			/// <summary>
			/// Retrieve the resource checksum of the input file in the pChecksum member of FILEMUIINFO. If the input file does not have resource configuration
			/// data, this member of the structure contains 0.
			/// </summary>
			MUI_QUERY_CHECKSUM = 0x002,
			/// <summary>
			/// Retrieve the language associated with the input file. For a language-specific resource file, this flag requests the associated language. For an
			/// LN file, this flag requests the language of the ultimate fallback resources for the module, which can be either in the LN file or in a separate
			/// language-specific resource file referenced by the resource configuration data of the LN file. For more information, see the Remarks section.
			/// </summary>
			MUI_QUERY_LANGUAGE_NAME = 0x004,
			/// <summary>
			/// Retrieve lists of resource types in the language-specific resource files and LN files as they are specified in the resource configuration data.
			/// See the Remarks section for a way to access this information.
			/// </summary>
			MUI_QUERY_RESOURCE_TYPES = 0x008,
		}

		/// <summary>Specifies the supported normalization forms.</summary>
		// typedef enum _NORM_FORM { NormalizationOther = 0, NormalizationC = 0x1, NormalizationD = 0x2, NormalizationKC = 0x5, NormalizationKD = 0x6} NORM_FORM; https://msdn.microsoft.com/en-us/library/windows/desktop/dd319094(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd319094")]
		public enum NORM_FORM
		{
			/// <summary>Not supported.</summary>
			NormalizationOther = 0,
			/// <summary>
			/// Unicode normalization form C, canonical composition. Transforms each decomposed grouping, consisting of a base character plus combining
			/// characters, to the canonical precomposed equivalent. For example, A + ¨ becomes Ä.
			/// </summary>
			NormalizationC = 1,
			/// <summary>
			/// Unicode normalization form D, canonical decomposition. Transforms each precomposed character to its canonical decomposed equivalent. For example,
			/// Ä becomes A + ¨.
			/// </summary>
			NormalizationD = 2,
			/// <summary>
			/// Unicode normalization form KC, compatibility composition. Transforms each base plus combining characters to the canonical precomposed equivalent
			/// and all compatibility characters to their equivalents. For example, the ligature ﬁ becomes f + i; similarly, A + ¨ + ﬁ + n becomes Ä + f + i + n.
			/// </summary>
			NormalizationKC = 5,
			/// <summary>
			/// Unicode normalization form KD, compatibility decomposition. Transforms each precomposed character to its canonical decomposed equivalent and all
			/// compatibility characters to their equivalents. For example, Ä + ﬁ + n becomes A + ¨ + f + i + n.
			/// </summary>
			NormalizationKD = 6,
		}

		/// <summary>Specifies the geographical location class.</summary>
		// enum SYSGEOCLASS { GEOCLASS_NATION = 16, GEOCLASS_REGION = 14, GEOCLASS_ALL = 0 }; https://msdn.microsoft.com/en-us/library/windows/desktop/dd374070(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd374070")]
		public enum SYSGEOCLASS
		{
			/// <summary>Class for nation geographical location identifiers.</summary>
			GEOCLASS_NATION = 16,
			/// <summary>Class for region geographical location identifiers.</summary>
			GEOCLASS_REGION = 14,
			/// <summary><c>Starting with Windows 8:</c> Class for all geographical location identifiers.</summary>
			GEOCLASS_ALL = 0
		}

		/// <summary>Defines the type of geographical location information requested in the <c>GetGeoInfo</c> or <c>GetGeoInfoEx</c> function.</summary>
		// enum SYSGEOTYPE { GEO_NATION = 0x0001, GEO_LATITUDE = 0x0002, GEO_LONGITUDE = 0x0003, GEO_ISO2 = 0x0004, GEO_ISO3 = 0x0005, GEO_RFC1766 = 0x0006,
		// GEO_LCID = 0x0007, GEO_FRIENDLYNAME = 0x0008, GEO_OFFICIALNAME = 0x0009, GEO_TIMEZONES = 0x000A, GEO_OFFICIALLANGUAGES = 0x000B, GEO_ISO_UN_NUMBER =
		// 0x000C, GEO_PARENT = 0x000D, GEO_DIALINGCODE = 0x000E, GEO_CURRENCYCODE = 0x000F, GEO_CURRENCYSYMBOL = 0x0010, GEO_NAME = 0x0011, GEO_ID = 0x000E }; https://msdn.microsoft.com/en-us/library/windows/desktop/dd374071(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd374071")]
		public enum SYSGEOTYPE
		{
			/// <summary>
			/// <para>The geographical location identifier (GEOID) of a nation. This value is stored in a long integer.</para>
			/// <para><c>Starting with Windows 10, version 1709:</c> This value is not supported for the <c>GetGeoInfoEx</c> function, and should not be used.</para>
			/// </summary>
			GEO_NATION = 1,
			/// <summary>The latitude of the location. This value is stored in a floating-point number.</summary>
			GEO_LATITUDE,
			/// <summary>The longitude of the location. This value is stored in a floating-point number.</summary>
			GEO_LONGITUDE,
			/// <summary>The ISO 2-letter country/region code. This value is stored in a string.</summary>
			GEO_ISO2,
			/// <summary>The ISO 3-letter country/region code. This value is stored in a string.</summary>
			GEO_ISO3,
			/// <summary>
			/// <para>
			/// The name for a string, compliant with RFC 4646 (starting with Windows Vista), that is derived from the <c>GetGeoInfo</c> parameters language and GeoId.
			/// </para>
			/// <para><c>Starting with Windows 10, version 1709:</c> This value is not supported for the <c>GetGeoInfoEx</c> function, and should not be used.</para>
			/// </summary>
			GEO_RFC1766,
			/// <summary>
			/// <para>A locale identifier derived using <c>GetGeoInfo</c>.</para>
			/// <para><c>Starting with Windows 10, version 1709:</c> This value is not supported for the <c>GetGeoInfoEx</c> function, and should not be used.</para>
			/// </summary>
			GEO_LCID,
			/// <summary>The friendly name of the nation, for example, Germany. This value is stored in a string.</summary>
			GEO_FRIENDLYNAME,
			/// <summary>The official name of the nation, for example, Federal Republic of Germany. This value is stored in a string.</summary>
			GEO_OFFICIALNAME,
			/// <summary>Not implemented.</summary>
			GEO_TIMEZONES,
			/// <summary>Not implemented.</summary>
			GEO_OFFICIALLANGUAGES,
			/// <summary><c>Starting with Windows 8:</c> The ISO 3-digit country/region code. This value is stored in a string.</summary>
			GEO_ISO_UN_NUMBER,
			/// <summary>
			/// <c>Starting with Windows 8:</c> The geographical location identifier of the parent region of a country/region. This value is stored in a string.
			/// </summary>
			GEO_PARENT,
			/// <summary>
			/// <c>Starting with Windows 10, version 1709:</c> The dialing code to use with telephone numbers in the geographic location. For example, 1 for the
			/// United States.
			/// </summary>
			GEO_DIALINGCODE,
			/// <summary>
			/// <c>Starting with Windows 10, version 1709:</c> The three-letter code for the currency that the geographic location uses. For example, USD for
			/// United States dollars.
			/// </summary>
			GEO_CURRENCYCODE,
			/// <summary>
			/// <c>Starting with Windows 10, version 1709:</c> The symbol for the currency that the geographic location uses. For example, the dollar sign ($).
			/// </summary>
			GEO_CURRENCYSYMBOL,
			/// <summary>
			/// <para>
			/// <c>Starting with Windows 10, version 1709:</c> The two-letter International Organization for Standardization (ISO) 3166-1 code or numeric United
			/// Nations (UN) Series M, Number 49 (M.49) code for the geographic region.
			/// </para>
			/// <para>
			/// For information about two-letter ISO 3166-1 codes, see Country Codes - ISO 3166. For information about numeric UN M.49 codes, see Standard
			/// country or area codes for statistical use (M49).
			/// </para>
			/// </summary>
			GEO_NAME,
			/// <summary>
			/// <c>Starting with Windows 10, version 1709:</c> The Windows geographical location identifiers (GEOID) for the region. This value is provided for
			/// backward compatibility. Do not use this value in new applications, but use <c>GEO_NAME</c> instead.
			/// </summary>
			GEO_ID,
		}

		/// <summary>Specifies NLS function capabilities.</summary>
		// enum SYSNLS_FUNCTION { COMPARE_STRING = 0x0001 }; https://msdn.microsoft.com/en-us/library/windows/desktop/dd374072(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd374072")]
		public enum SYSNLS_FUNCTION
		{
			/// <summary>
			/// Value indicating comparison of two strings in the manner of the CompareString function or LCMapString with the LCMAP_SORTKEY flag specified.
			/// </summary>
			COMPARE_STRING = 0x0001
		}

		/// <summary>The time format.</summary>
		[Flags]
		public enum TIME_FORMAT_ENUM
		{
			/// <summary>Use the current user's long time format.</summary>
			USE_CURRENT = 0,
			/// <summary>Windows 7 and later: Use the current user's short time format.</summary>
			TIME_NOSECONDS = 2,
			/// <summary>
			/// Specified with the ANSI version of this function, EnumTimeFormatsA (not recommended), to use the system default Windows ANSI code page (ACP)
			/// instead of the locale code page.
			/// </summary>
			LOCAL_USE_CP_ACP = 0x40000000
		}

		/// <summary>Flags specifying script verification options.</summary>
		public enum VS_FLAGS
		{
			/// <summary>No flags</summary>
			NONE,
			/// <summary>Allow &amp;quot;Latn&amp;quot; (Latin script) in the test list even if it is not in the locale list.</summary>
			VS_ALLOW_LATIN
		}

		/// <summary>Converts a default locale value to an actual locale identifier.</summary>
		/// <param name="Locale">
		/// <para>
		/// Default locale identifier value to convert. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <returns>
		/// <para>Returns the appropriate locale identifier if successful.</para>
		/// <para>
		/// This function returns the value of the Locale parameter if it does not succeed. The function fails when the Locale value is not one of the default
		/// values listed above.
		/// </para>
		/// </returns>
		// LCID ConvertDefaultLocale( _In_ LCID Locale); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317768(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317768")]
		public static extern uint ConvertDefaultLocale(uint Locale);

		/// <summary>Enumerates calendar information for a specified locale.</summary>
		/// <param name="pCalInfoEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumCalendarInfoProc</c>.</param>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which to retrieve calendar information. You can use the <c>MAKELCID</c> macro to create a locale
		/// identifier or use one of the following predefined values.
		/// </param>
		/// <param name="Calendar">
		/// <c>Calendar identifier</c> that specifies the calendar for which information is requested. Note that this identifier can be ENUM_ALL_CALENDARS, to
		/// enumerate all calendars that are associated with the locale.
		/// </param>
		/// <param name="CalType">
		/// Type of calendar information. For more information, see Calendar Type Information. Only one calendar type can be specified per call to this function,
		/// except where noted.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumCalendarInfo( _In_ CALINFO_ENUMPROC pCalInfoEnumProc, _In_ LCID Locale, _In_ CALID Calendar, _In_ CALTYPE CalType); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317803(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317803")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumCalendarInfo(EnumCalendarInfoProc lpCalInfoEnumProc, uint Locale, uint Calendar, CALTYPE CalType);

		/// <summary>Enumerates calendar information for a locale specified by identifier.</summary>
		/// <param name="pCalInfoEnumProcEx">Pointer to an application-defined callback function. For more information, see <c>EnumCalendarInfoProcEx</c>.</param>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale for which to retrieve calendar information. You can use the <c>MAKELCID</c> macro to create an identifier
		/// or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="Calendar">
		/// <c>Calendar identifier</c> that specifies the calendar for which information is requested. Note that this identifier can be ENUM_ALL_CALENDARS, to
		/// enumerate all calendars that are associated with the locale.
		/// </param>
		/// <param name="CalType">
		/// Type of calendar information. For more information, see Calendar Type Information. Only one calendar type can be specified per call to this function,
		/// except where noted.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumCalendarInfoEx( _In_ CALINFO_ENUMPROCEX pCalInfoEnumProcEx, _In_ LCID Locale, _In_ CALID Calendar, _In_ CALTYPE CalType); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317804(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317804")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumCalendarInfoEx(EnumCalendarInfoProcEx lpCalInfoEnumProcEx, uint Locale, uint Calendar, CALTYPE CalType);

		/// <summary>Enumerates calendar information for a locale specified by name.</summary>
		/// <param name="pCalInfoEnumProcExEx">Pointer to an application-defined callback function. For more information, see <c>EnumCalendarInfoProcExEx</c>.</param>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="Calendar">
		/// <c>Calendar identifier</c> that specifies the calendar for which information is requested. Note that this identifier can be ENUM_ALL_CALENDARS, to
		/// enumerate all calendars that are associated with the locale.
		/// </param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <param name="CalType">
		/// Type of calendar information. For more information, see Calendar Type Information. Only one calendar type can be specified per call to this function,
		/// except where noted.
		/// </param>
		/// <param name="lParam">Application-provided parameter to pass to the callback function. This value is especially useful for multi-threaded applications.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumCalendarInfoExEx( _In_ CALINFO_ENUMPROCEXEX pCalInfoEnumProcExEx, _In_opt_ LPCWSTR lpLocaleName, _In_ CALID Calendar, _In_opt_ LPCWSTR
		// lpReserved, _In_ CALTYPE CalType, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317805(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317805")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumCalendarInfoExEx(EnumCalendarInfoProcExEx pCalInfoEnumProcExEx, string lpLocaleName, uint Calendar, string lpReserved, CALTYPE CalType, IntPtr lParam);

		/// <summary>Enumerates the long date, short date, or year/month formats that are available for a specified locale.</summary>
		/// <param name="lpDateFmtEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumDateFormatsProc</c>.</param>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which to retrieve date format information. You can use the <c>MAKELCID</c> macro to create an
		/// identifier or use one of the following predefined values.
		/// </param>
		/// <param name="dwFlags">Flag specifying date formats. For detailed definitions, see the dwFlags parameter of <c>EnumDateFormatsExEx</c>.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumDateFormats( _In_ DATEFMT_ENUMPROC lpDateFmtEnumProc, _In_ LCID Locale, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317810(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317810")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDateFormats(EnumDateFormatsProc lpDateFmtEnumProc, uint Locale, DATE_FORMAT dwFlags);

		/// <summary>Enumerates the long date, short date, or year/month formats that are available for a specified locale.</summary>
		/// <param name="lpDateFmtEnumProcEx">Pointer to an application-defined callback function. For more information, see <c>EnumDateFormatsProcEx</c>.</param>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale for which to retrieve date format information. You can use the <c>MAKELCID</c> macro to create an
		/// identifier or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="dwFlags">Flag specifying date formats. For detailed definitions, see the dwFlags parameter of <c>EnumDateFormatsExEx</c>.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumDateFormatsEx( _In_ DATEFMT_ENUMPROCEX lpDateFmtEnumProcEx, _In_ LCID Locale, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317811(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317811")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDateFormatsEx(EnumDateFormatsProcEx lpDateFmtEnumProcEx, uint Locale, DATE_FORMAT dwFlags);

		/// <summary>Enumerates the long date, short date, or year/month formats that are available for a locale specified by name.</summary>
		/// <param name="lpDateFmtEnumProcExEx">Pointer to an application-defined callback function. For more information, see <c>EnumDateFormatsProcExEx</c>.</param>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// <para>Flag specifying date formats. The application can supply one of the following values or the LOCALE_USE_CP_ACP constant.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DATE_SHORTDATE</term>
		/// <term>Use short date formats. This value cannot be used with any of the other flag values.</term>
		/// </item>
		/// <item>
		/// <term>DATE_LONGDATE</term>
		/// <term>Use long date formats. This value cannot be used with any of the other flag values.</term>
		/// </item>
		/// <item>
		/// <term>DATE_YEARMONTH</term>
		/// <term>Use year/month formats. This value cannot be used with any of the other flag values.</term>
		/// </item>
		/// <item>
		/// <term>DATE_MONTHDAY</term>
		/// <term>Use month/day formats. This value cannot be used with any of the other flag values.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lParam">An application-provided parameter to pass to the callback function. This value is especially useful for multi-threaded applications.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumDateFormatsExEx( _In_ DATEFMT_ENUMPROCEXEX lpDateFmtEnumProcExEx, _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317812(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317812")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDateFormatsExEx(EnumDateFormatsProcExEx lpDateFmtEnumProcExEx, string lpLocaleName, DATE_FORMAT dwFlags, IntPtr lParam);

		/// <summary>Enumerates the locales in a specified language group.</summary>
		/// <param name="lpLangGroupLocaleEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumLanguageGroupLocalesProc</c>.</param>
		/// <param name="LanguageGroup">Identifier of the language group for which to enumerate locales. This parameter can have one of the following values:</param>
		/// <param name="dwFlags">Reserved; must be 0.</param>
		/// <param name="lParam">
		/// An application-defined value to pass to the callback function. This value can be used for error checking. It can also be used to ensure thread safety
		/// in the callback function.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumLanguageGroupLocales( _In_ LANGGROUPLOCALE_ENUMPROC lpLangGroupLocaleEnumProc, _In_ LGRPID LanguageGroup, _In_ DWORD dwFlags, _In_ LONG_PTR
		// lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317819(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317819")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumLanguageGroupLocales(EnumLanguageGroupLocalesProc lpLangGroupLocaleEnumProc, LGRPID LanguageGroup, [Optional] uint dwFlags, IntPtr lParam);

		/// <summary>Enumerates the code pages that are either installed on or supported by an operating system.</summary>
		/// <param name="lpCodePageEnumProc">
		/// Pointer to an application-defined callback function. The <c>EnumSystemCodePages</c> function enumerates code pages by making repeated calls to this
		/// callback function. For more information, see <c>EnumCodePagesProc</c>.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flag specifying the code pages to enumerate. This parameter can have one of the following values, which are mutually exclusive.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CP_INSTALLED</term>
		/// <term>Enumerate only installed code pages.</term>
		/// </item>
		/// <item>
		/// <term>CP_SUPPORTED</term>
		/// <term>Enumerate all supported code pages.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumSystemCodePages( _In_ CODEPAGE_ENUMPROC lpCodePageEnumProc, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317825(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317825")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemCodePages(EnumCodePagesProc lpCodePageEnumProc, CP_FLAGS dwFlags);

		/// <summary>
		/// <para>
		/// [ <c>EnumSystemGeoID</c> is available for use in the operating systems specified in the Requirements section. It may be altered or unavailable in
		/// subsequent versions. Instead, use <c>EnumSystemGeoNames</c>.]
		/// </para>
		/// <para>Enumerates the geographical location identifiers (type GEOID) that are available on the operating system.</para>
		/// </summary>
		/// <param name="GeoClass">
		/// Geographical location class for which to enumerate the identifiers. At present, only GEOCLASS_NATION is supported. This type causes the function to
		/// enumerate all geographical identifiers for nations on the operating system.
		/// </param>
		/// <param name="ParentGeoId">Reserved. This parameter must be 0.</param>
		/// <param name="lpGeoEnumProc">
		/// Pointer to the application-defined callback function <c>EnumGeoInfoProc</c>. The <c>EnumSystemGeoID</c> function makes repeated calls to this
		/// callback function until it returns <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumSystemGeoID( _In_ GEOCLASS GeoClass, _In_ GEOID ParentGeoId, _In_ GEO_ENUMPROC lpGeoEnumProc); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317826(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317826")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemGeoID(SYSGEOCLASS GeoClass, [Optional] int ParentGeoId, EnumGeoInfoProc lpGeoEnumProc);

		/// <summary>
		/// Enumerates the two-letter International Organization for Standardization (ISO) 3166-1 codes or numeric United Nations (UN) Series M, Number 49 (M.49)
		/// codes for geographical locations that are available on the operating system.
		/// </summary>
		/// <param name="geoClass">The geographical location class for which to enumerate the available two-letter ISO 3166-1 or numeric UN M.49 codes.</param>
		/// <param name="geoEnumProc">
		/// Pointer to the application-defined callback function Geo_EnumNameProc. The <c>EnumSystemGeoNames</c> function calls this callback function for each
		/// of the two-letter ISO 3166-1 or numeric UN M.49 codes for geographical locations that are available on the operating system until callback function
		/// returns <c>FALSE</c>.
		/// </param>
		/// <param name="data">Application-specific information to pass to the callback function that the genEnumProc parameter specifies.</param>
		/// <returns>
		/// <para>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, call <c>GetLastError</c>, which can return one of the
		/// following error codes:
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The values supplied for flags were not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter value was not valid.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI EnumSystemGeoNames( _In_ GEOCLASS geoClass, _In_ GEO_ENUMNAMEPROC geoEnumProc, _In_opt_ LPARAM data); https://msdn.microsoft.com/en-us/library/windows/desktop/mt826465(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "mt826465")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemGeoNames(SYSGEOCLASS geoClass, Geo_EnumNameProc geoEnumProc, IntPtr data);

		/// <summary>Enumerates the language groups that are either installed on or supported by an operating system.</summary>
		/// <param name="lpLanguageGroupEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumLanguageGroupsProc</c>.</param>
		/// <param name="dwFlags">
		/// <para>Flags specifying the language group identifiers to enumerate. This parameter can have one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LGRPID_INSTALLED</term>
		/// <term>Enumerate only installed language group identifiers.</term>
		/// </item>
		/// <item>
		/// <term>LGRPID_SUPPORTED</term>
		/// <term>Enumerate all supported language group identifiers.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// Application-defined value to pass to the callback function. This parameter can be used in error checking. It can also be used to ensure thread safety
		/// in the callback function.
		/// </param>
		/// <returns>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return one of the following error codes:
		/// </returns>
		// BOOL EnumSystemLanguageGroups( _In_ LANGUAGEGROUP_ENUMPROC lpLanguageGroupEnumProc, _In_ DWORD dwFlags, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317827(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317827")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemLanguageGroups(EnumLanguageGroupsProc lpLanguageGroupEnumProc, LGRPID_FLAGS dwFlags, IntPtr lParam);

		/// <summary>Enumerates the locales that are either installed on or supported by an operating system.</summary>
		/// <param name="lpLocaleEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumLocalesProc</c>.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags specifying the locale identifiers to enumerate. The flags can be used singly or combined using a binary OR. If the application specifies 0 for
		/// this parameter, the function behaves as for LCID_SUPPORTED.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LCID_INSTALLED</term>
		/// <term>Enumerate only installed locale identifiers. This value cannot be used with LCID_SUPPORTED.</term>
		/// </item>
		/// <item>
		/// <term>LCID_SUPPORTED</term>
		/// <term>Enumerate all supported locale identifiers. This value cannot be used with LCID_INSTALLED.</term>
		/// </item>
		/// <item>
		/// <term>LCID_ALTERNATE_SORTS</term>
		/// <term>
		/// Enumerate only the alternate sort locale identifiers. If this value is used with either LCID_INSTALLED or LCID_SUPPORTED, the installed or supported
		/// locales are retrieved, as well as the alternate sort locale identifiers.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumSystemLocales( _In_ LOCALE_ENUMPROC lpLocaleEnumProc, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317828(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317828")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemLocales(EnumLocalesProc lpLocaleEnumProc, LCID_FLAGS dwFlags);

		/// <summary>Enumerates the locales that are either installed on or supported by an operating system.</summary>
		/// <param name="lpLocaleEnumProcEx">
		/// Pointer to an application-defined callback function. The <c>EnumSystemLocalesEx</c> function enumerates locales by making repeated calls to this
		/// callback function. For more information, see <c>EnumLocalesProcEx</c>.
		/// </param>
		/// <param name="dwFlags">
		/// Flags identifying the locales to enumerate. The flags can be used singly or combined using a binary OR. If the application specifies 0 for this
		/// parameter, the function behaves as for LOCALE_ALL.
		/// </param>
		/// <param name="lParam">An application-provided parameter to be passed to the callback function. This is especially useful for multi-threaded applications.</param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumSystemLocalesEx( _In_ LOCALE_ENUMPROCEX lpLocaleEnumProcEx, _In_ DWORD dwFlags, _In_ LPARAM lParam, _In_opt_ LPVOID lpReserved); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317829(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317829")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumSystemLocalesEx(EnumLocalesProcEx lpLocaleEnumProcEx, LOCALE_FLAGS dwFlags, IntPtr lParam, [Optional] IntPtr lpReserved);

		/// <summary>Enumerates the time formats that are available for a locale specified by identifier.</summary>
		/// <param name="lpTimeFmtEnumProc">Pointer to an application-defined callback function. For more information, see <c>EnumTimeFormatsProc</c>.</param>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which to retrieve time format information. You can use the <c>MAKELCID</c> macro to create a locale
		/// identifier or use one of the following predefined values.
		/// </param>
		/// <param name="dwFlags">
		/// <para>The time format. This parameter can specify a combination of any of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Use the current user's long time format.</term>
		/// </item>
		/// <item>
		/// <term>TIME_NOSECONDS</term>
		/// <term>Windows 7 and later: Use the current user's short time format.</term>
		/// </item>
		/// <item>
		/// <term>LOCAL_USE_CP_ACP</term>
		/// <term>
		/// Specified with the ANSI version of this function, EnumTimeFormatsA (not recommended), to use the system default Windows ANSI code page (ACP) instead
		/// of the locale code page.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumTimeFormats( _In_ TIMEFMT_ENUMPROC lpTimeFmtEnumProc, _In_ LCID Locale, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317830(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317830")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumTimeFormats(EnumTimeFormatsProc lpTimeFmtEnumProc, uint Locale, TIME_FORMAT_ENUM dwFlags);

		/// <summary>Enumerates the time formats that are available for a locale specified by name.</summary>
		/// <param name="lpTimeFmtEnumProcEx">Pointer to an application-defined callback function. For more information, see <c>EnumTimeFormatsProcEx</c>.</param>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// The time format. Set to 0 to use the current user's long time format, or TIME_NOSECONDS (starting with Windows 7) to use the short time format.
		/// </param>
		/// <param name="lParam">An application-provided parameter to be passed to the callback function. This is especially useful for multi-threaded applications.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL EnumTimeFormatsEx( _In_ TIMEFMT_ENUMPROCEX lpTimeFmtEnumProcEx, _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317831(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317831")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumTimeFormatsEx(EnumTimeFormatsProcEx lpTimeFmtEnumProcEx, string lpLocaleName, TIME_FORMAT_ENUM dwFlags, IntPtr lParam);

		/// <summary>
		/// Enumerates the user interface languages that are available on the operating system and calls the callback function with every language in the list.
		/// </summary>
		/// <param name="lpUILanguageEnumProc">
		/// Pointer to an application-defined <c>EnumUILanguagesProc</c> callback function. <c>EnumUILanguages</c> calls this function repeatedly to enumerate
		/// the languages in the list.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying language format and filtering. The following flags specify the format of the language to pass to the callback function. The format
		/// flags are mutually exclusive, and MUI_LANGUAGE_ID is the default.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Pass the language identifier in the language string to the callback function.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Pass the language name in the language string to the callback function.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following flags specify the filtering for the function to use in enumerating the languages. The filtering flags are mutually exclusive, and the
		/// default is MUI_LICENSED_LANGUAGES.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_ALL_INSTALLED_LANGUAGES</term>
		/// <term>Enumerate all installed languages available to the operating system.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LICENSED_LANGUAGES</term>
		/// <term>Enumerate all installed languages that are available and licensed for use.</term>
		/// </item>
		/// <item>
		/// <term>MUI_GROUP_POLICY</term>
		/// <term>Enumerate all installed languages that are available and licensed, and that are allowed by the group policy.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// <c>Windows Vista and later:</c> The application can set dwFlags to 0, or to one or more of the specified flags. A setting of 0 causes the parameter
		/// value to default to MUI_LANGUAGE_ID | MUI_LICENSED_LANGUAGES.
		/// </para>
		/// <para><c>Windows 2000, Windows XP, Windows Server 2003:</c> The application must set dwFlags to 0.</para>
		/// </param>
		/// <param name="lParam">Application-defined value.</param>
		/// <returns>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return one of the following error codes:
		/// </returns>
		// BOOL EnumUILanguages( _In_ UILANGUAGE_ENUMPROC lpUILanguageEnumProc, _In_ DWORD dwFlags, _In_ LONG_PTR lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/dd317834(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd317834")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumUILanguages(EnumUILanguagesProc lpUILanguageEnumProc, MUI_LANGUAGE_ENUM dwFlags, IntPtr lParam);

		/// <summary>Locates a Unicode string (wide characters) or its equivalent in another Unicode string for a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create an identifier or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="dwFindNLSStringFlags">
		/// Flags specifying details of the find operation. For detailed definitions, see the dwFindNLSStringFlags parameter of <c>FindNLSStringEx</c>.
		/// </param>
		/// <param name="lpStringSource">Pointer to the source string, in which the function searches for the string specified by lpStringValue.</param>
		/// <param name="cchSource">
		/// Size, in characters excluding the terminating null character, of the string indicated by lpStringSource. The application cannot specify 0 or any
		/// negative number other than -1 for this parameter. The application specifies -1 if the source string is null-terminated and the function should
		/// calculate the size automatically.
		/// </param>
		/// <param name="lpStringValue">Pointer to the search string, for which the function searches in the source string.</param>
		/// <param name="cchValue">
		/// Size, in characters excluding the terminating null character, of the string indicated by lpStringValue. The application cannot specify 0 or any
		/// negative number other than -1 for this parameter. The application specifies -1 if the search string is null-terminated and the function should
		/// calculate the size automatically.
		/// </param>
		/// <param name="pcchFound">
		/// Pointer to a buffer containing the length of the string that the function finds. For details, see the pcchFound parameter of <c>FindNLSStringEx</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns a 0-based index into the source string indicated by lpStringSource if successful. In combination with the value in pcchFound, this index
		/// provides the exact location of the entire found string in the source string. A return value of 0 is an error-free index into the source string, and
		/// the matching string is in the source string at offset 0.
		/// </para>
		/// <para>
		/// The function returns -1 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int FindNLSString( _In_ LCID Locale, _In_ DWORD dwFindNLSStringFlags, _In_ LPCWSTR lpStringSource, _In_ int cchSource, _In_ LPCWSTR lpStringValue,
		// _In_ int cchValue, _Out_opt_ LPINT pcchFound); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318056(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318056")]
		public static extern int FindNLSString(uint Locale, COMPARE_STRING dwFindNLSStringFlags, string lpStringSource, int cchSource, string lpStringValue, int cchValue, out int pcchFound);

		/// <summary>Locates a Unicode string (wide characters) or its equivalent in another Unicode string for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFindNLSStringFlags">
		/// <para>
		/// Flags specifying details of the find operation. These flags are mutually exclusive, with FIND_FROMSTART being the default. The application can
		/// specify just one of the find flags with any of the filtering flags defined in the next table. If the application does not specify a flag, the
		/// function uses the default comparison for the specified locale. As discussed in Handling Sorting in Your Applications, there is no binary comparison mode.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FIND_FROMSTART</term>
		/// <term>Search the string, starting with the first character of the string.</term>
		/// </item>
		/// <item>
		/// <term>FIND_FROMEND</term>
		/// <term>Search the string in the reverse direction, starting with the last character of the string.</term>
		/// </item>
		/// <item>
		/// <term>FIND_STARTSWITH</term>
		/// <term>Test to find out if the value specified by lpStringValue is the first value in the source string indicated by lpStringSource.</term>
		/// </item>
		/// <item>
		/// <term>FIND_ENDSWITH</term>
		/// <term>Test to find out if the value specified by lpStringValue is the last value in the source string indicated by lpStringSource.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>The application can use the filtering flags defined below in combination with a find flag.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LINGUISTIC_IGNORECASE</term>
		/// <term>Ignore case in the search, as linguistically appropriate. For more information, see the Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>LINGUISTIC_IGNOREDIACRITIC</term>
		/// <term>Ignore diacritics, as linguistically appropriate. For more information, see the Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNORECASE</term>
		/// <term>Ignore case in the search. For more information, see the Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNOREKANATYPE</term>
		/// <term>Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNORENONSPACE</term>
		/// <term>Ignore nonspacing characters. For more information, see the Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNORESYMBOLS</term>
		/// <term>Ignore symbols and punctuation.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNOREWIDTH</term>
		/// <term>
		/// Ignore the difference between half-width and full-width characters, for example, C a t == cat. The full-width form is a formatting distinction used
		/// in Chinese and Japanese scripts.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NORM_LINGUISTIC_CASING</term>
		/// <term>Use linguistic rules for casing, instead of file system rules (default). For more information, see the Remarks section.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpStringSource">Pointer to the source string, in which the function searches for the string specified by lpStringValue.</param>
		/// <param name="cchSource">
		/// Size, in characters excluding the terminating null character, of the string indicated by lpStringSource. The application cannot specify 0 or any
		/// negative number other than -1 for this parameter. The application specifies -1 if the source string is null-terminated and the function should
		/// calculate the size automatically.
		/// </param>
		/// <param name="lpStringValue">Pointer to the search string, for which the function searches in the source string.</param>
		/// <param name="cchValue">
		/// Size, in characters excluding the terminating null character, of the string indicated by lpStringValue. The application cannot specify 0 or any
		/// negative number other than -1 for this parameter. The application specifies -1 if the search string is null-terminated and the function should
		/// calculate the size automatically.
		/// </param>
		/// <param name="pcchFound">
		/// <para>
		/// Pointer to a buffer containing the length of the string that the function finds. The string can be either longer or shorter than the search string.
		/// If the function fails to find the search string, this parameter is not modified.
		/// </para>
		/// <para>
		/// The function can retrieve <c>NULL</c> in this parameter. In this case, the function makes no indication if the length of the found string differs
		/// from the length of the source string.
		/// </para>
		/// <para>Note that the value of pcchFound is often identical to the value provided in cchValue, but can differ in the following cases:</para>
		/// </param>
		/// <param name="lpVersionInformation">Reserved; must be <c>NULL</c>.</param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <param name="sortHandle">Reserved; must be 0.</param>
		/// <returns>
		/// <para>
		/// Returns a 0-based index into the source string indicated by lpStringSource if successful. In combination with the value in pcchFound, this index
		/// provides the exact location of the entire found string in the source string. A return value of 0 is an error-free index into the source string, and
		/// the matching string is in the source string at offset 0.
		/// </para>
		/// <para>
		/// The function returns -1 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int FindNLSStringEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFindNLSStringFlags, _In_ LPCWSTR lpStringSource, _In_ int cchSource, _In_ LPCWSTR
		// lpStringValue, _In_ int cchValue, _Out_opt_ LPINT pcchFound, _In_opt_ LPNLSVERSIONINFO lpVersionInformation, _In_opt_ LPVOID lpReserved, _In_opt_
		// LPARAM sortHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318059(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318059")]
		public static extern int FindNLSStringEx(string lpLocaleName, COMPARE_STRING dwFindNLSStringFlags, string lpStringSource, int cchSource, string lpStringValue, int cchValue, out int pcchFound, [Optional] IntPtr lpVersionInformation, [Optional] IntPtr lpReserved, [Optional] IntPtr sortHandle);

		/// <summary>Retrieves the current Windows ANSI code page identifier for the operating system.</summary>
		/// <returns>
		/// Returns the current Windows ANSI code page (ACP) identifier for the operating system. See Code Page Identifiers for a list of identifiers for Windows
		/// ANSI code pages and other code pages.
		/// </returns>
		// UINT GetACP(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318070(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318070")]
		public static extern uint GetACP();

		/// <summary>
		/// Retrieves information about a calendar for a locale specified by identifier. <note type="note">For interoperability reasons, the application should
		/// prefer the GetCalendarInfoEx function to GetCalendarInfo because Microsoft is migrating toward the use of locale names instead of locale identifiers
		/// for new locales. Any application that runs only on Windows Vista and later should use GetCalendarInfoEx.</note>
		/// </summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which to retrieve calendar information. You can use the MAKELCID macro to create a locale identifier
		/// or use one of the following predefined values.
		/// </param>
		/// <param name="Calendar">Calendar identifier.</param>
		/// <param name="CalType">
		/// <para>Type of information to retrieve. For more information, see Calendar Type Information.</para>
		/// <para>CAL_USE_CP_ACP is relevant only for the ANSI version of this function.</para>
		/// <para>
		/// For CAL_NOUSEROVERRIDE, the function ignores any value set by <c>SetCalendarInfo</c> and uses the database settings for the current system default
		/// locale. This type is relevant only in the combination CAL_NOUSEROVERRIDE | CAL_ITWODIGITYEARMAX. CAL_ITWODIGITYEARMAX is the only value that can be
		/// set by <c>SetCalendarInfo</c>.
		/// </para>
		/// </param>
		/// <param name="lpCalData">
		/// Pointer to a buffer in which this function retrieves the requested data as a string. If CAL_RETURN_NUMBER is specified in CalType, this parameter
		/// must retrieve NULL.
		/// </param>
		/// <param name="cchData">
		/// Size, in characters, of the lpCalData buffer. The application can set this parameter to 0 to return the required size for the calendar data buffer.
		/// In this case, the lpCalData parameter is not used. If CAL_RETURN_NUMBER is specified for CalType, the value of cchData must be 0.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a variable that receives the requested data as a number. If CAL_RETURN_NUMBER is specified in CalType, then lpValue must not be NULL. If
		/// CAL_RETURN_NUMBER is not specified in CalType, then lpValue must be NULL.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the lpCalData buffer if successful. If the function succeeds, cchData is set to 0, and
		/// CAL_RETURN_NUMBER is not specified, the return value is the size of the buffer required to hold the locale information. If the function succeeds,
		/// cchData is set to 0, and CAL_RETURN_NUMBER is specified, the return value is the size of the value written to the lpValue parameter. This size is
		/// always 2.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCalendarInfo( _In_ LCID Locale, _In_ CALID Calendar, _In_ CALTYPE CalType, _Out_opt_ LPTSTR lpCalData, _In_ int cchData, _Out_opt_ LPDWORD
		// lpValue); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318072(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318072")]
		public static extern int GetCalendarInfo(uint Locale, uint Calendar, CALTYPE CalType, [Out] StringBuilder lpCalData, int cchData, out uint lpValue);

		/// <summary>Retrieves information about a calendar for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="Calendar">Calendar identifier.</param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <param name="CalType">
		/// <para>Type of information to retrieve. For more information, see Calendar Type Information.</para>
		/// <para>
		/// For CAL_NOUSEROVERRIDE, the function ignores any value set by <c>SetCalendarInfo</c> and uses the database settings for the current system default
		/// locale. This type is relevant only in the combination CAL_NOUSEROVERRIDE | CAL_ITWODIGITYEARMAX. CAL_ITWODIGITYEARMAX is the only value that can be
		/// set by <c>SetCalendarInfo</c>.
		/// </para>
		/// </param>
		/// <param name="lpCalData">
		/// Pointer to a buffer in which this function retrieves the requested data as a string. If CAL_RETURN_NUMBER is specified in CalType, this parameter
		/// must retrieve <c>NULL</c>.
		/// </param>
		/// <param name="cchData">
		/// Size, in characters, of the lpCalData buffer. The application can set this parameter to 0 to return the required size for the calendar data buffer.
		/// In this case, the lpCalData parameter is not used. If CAL_RETURN_NUMBER is specified for CalType, the value of cchData must be 0.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a variable that receives the requested data as a number. If CAL_RETURN_NUMBER is specified in CalType, then lpValue must not be
		/// <c>NULL</c>. If CAL_RETURN_NUMBER is not specified in CalType, then lpValue must be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the lpCalData buffer if successful. If the function succeeds, cchData is set to 0, and
		/// CAL_RETURN_NUMBER is not specified, the return value is the size of the buffer required to hold the locale information. If the function succeeds,
		/// cchData is set to 0, and CAL_RETURN_NUMBER is specified, the return value is the size of the value written to the lpValue parameter. This size is
		/// always 2.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCalendarInfoEx( _In_opt_ LPCWSTR lpLocaleName, _In_ CALID Calendar, _In_opt_ LPCWSTR lpReserved, _In_ CALTYPE CalType, _Out_opt_ LPWSTR
		// lpCalData, _In_ int cchData, _Out_opt_ LPDWORD lpValue); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318075(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318075")]
		public static extern int GetCalendarInfoEx(string lpLocaleName, uint Calendar, string lpReserved, CALTYPE CalType, [Out] StringBuilder lpCalData, int cchData, out uint lpValue);

		/// <summary>Retrieves information about any valid installed or available code page.</summary>
		/// <param name="CodePage">Identifier for the code page for which to retrieve information. For details, see the CodePage parameter of <c>GetCPInfoEx</c>.</param>
		/// <param name="lpCPInfo">Pointer to a <c>CPINFO</c> structure that receives information about the code page. See the Remarks section.</param>
		/// <returns>
		/// Returns 1 if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can return one of the
		/// following error codes:
		/// </returns>
		// BOOL GetCPInfo( _In_ UINT CodePage, _Out_ LPCPINFO lpCPInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318078(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318078")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCPInfo(uint CodePage, out CPINFO lpCPInfo);

		/// <summary>Retrieves information about any valid installed or available code page.</summary>
		/// <param name="CodePage">
		/// <para>
		/// Identifier for the code page for which to retrieve information. The application can specify the code page identifier for any installed or available
		/// code page, or one of the following predefined values. See Code Page Identifiers for a list of identifiers for ANSI and other code pages.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CP_ACP</term>
		/// <term>Use the system default Windows ANSI code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_MACCP</term>
		/// <term>Use the system default Macintosh code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_OEMCP</term>
		/// <term>Use the system default OEM code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_THREAD_ACP</term>
		/// <term>Use the current thread&amp;#39;s ANSI code page.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="dwFlags">Reserved; must be 0.</param>
		/// <param name="lpCPInfoEx">Pointer to a <c>CPINFOEX</c> structure that receives information about the code page.</param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL GetCPInfoEx( _In_ UINT CodePage, _In_ DWORD dwFlags, _Out_ LPCPINFOEX lpCPInfoEx); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318081(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318081")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCPInfoEx(uint CodePage, [Optional] uint dwFlags, out CPINFOEX lpCPInfoEx);

		/// <summary>Formats a number string as a currency string for a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which this function formats the currency string. You can use the <c>MAKELCID</c> macro to create a
		/// locale identifier or use one of the following predefined values.
		/// </param>
		/// <param name="dwFlags">
		/// Flags controlling currency format. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case, the function
		/// formats the string using user overrides to the default currency format for the locale. If lpFormat is set to <c>NULL</c>, the application can specify
		/// LOCALE_NOUSEROVERRIDE to format the string using the system default currency format for the specified locale.
		/// </param>
		/// <param name="lpValue">For details, see the lpValue parameter of <c>GetCurrencyFormatEx</c>.</param>
		/// <param name="lpFormat">
		/// Pointer to a <c>CURRENCYFMT</c> structure that contains currency formatting information. All members of the structure must contain appropriate
		/// values. The application can set this parameter to <c>NULL</c> if function is to use the currency format of the specified locale. If this parameter is
		/// not set to <c>NULL</c>, the function uses the specified locale only for formatting information not specified in the <c>CURRENCYFMT</c> structure, for
		/// example, the string value for the negative sign used by the locale.
		/// </param>
		/// <param name="lpCurrencyStr">Pointer to a buffer in which this function retrieves the formatted currency string.</param>
		/// <param name="cchCurrency">
		/// Size, in characters, of the lpCurrencyStr buffer. The application sets this parameter to 0 if the function is to return the size of the buffer
		/// required to hold the formatted currency string. In this case, the lpCurrencyStr parameter is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpCurrencyStr if successful. If the cchCurrency parameter is set to 0, the
		/// function returns the size of the buffer required to hold the formatted currency string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCurrencyFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_ LPCTSTR lpValue, _In_opt_ const CURRENCYFMT *lpFormat, _Out_opt_ LPTSTR
		// lpCurrencyStr, _In_ int cchCurrency); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318083(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318083")]
		public static extern int GetCurrencyFormat(uint Locale, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [In] ref CURRENCYFMT lpFormat, [Out] StringBuilder lpCurrencyStr, int cchCurrency);

		/// <summary>Formats a number string as a currency string for a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale for which this function formats the currency string. You can use the <c>MAKELCID</c> macro to create a
		/// locale identifier or use one of the following predefined values.
		/// </param>
		/// <param name="dwFlags">
		/// Flags controlling currency format. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case, the function
		/// formats the string using user overrides to the default currency format for the locale. If lpFormat is set to <c>NULL</c>, the application can specify
		/// LOCALE_NOUSEROVERRIDE to format the string using the system default currency format for the specified locale.
		/// </param>
		/// <param name="lpValue">For details, see the lpValue parameter of <c>GetCurrencyFormatEx</c>.</param>
		/// <param name="lpFormat">
		/// Pointer to a <c>CURRENCYFMT</c> structure that contains currency formatting information. All members of the structure must contain appropriate
		/// values. The application can set this parameter to <c>NULL</c> if function is to use the currency format of the specified locale. If this parameter is
		/// not set to <c>NULL</c>, the function uses the specified locale only for formatting information not specified in the <c>CURRENCYFMT</c> structure, for
		/// example, the string value for the negative sign used by the locale.
		/// </param>
		/// <param name="lpCurrencyStr">Pointer to a buffer in which this function retrieves the formatted currency string.</param>
		/// <param name="cchCurrency">
		/// Size, in characters, of the lpCurrencyStr buffer. The application sets this parameter to 0 if the function is to return the size of the buffer
		/// required to hold the formatted currency string. In this case, the lpCurrencyStr parameter is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpCurrencyStr if successful. If the cchCurrency parameter is set to 0, the
		/// function returns the size of the buffer required to hold the formatted currency string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCurrencyFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_ LPCTSTR lpValue, _In_opt_ const CURRENCYFMT *lpFormat, _Out_opt_ LPTSTR
		// lpCurrencyStr, _In_ int cchCurrency); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318083(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318083")]
		public static extern int GetCurrencyFormat(uint Locale, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [Optional] IntPtr lpFormat, [Out] StringBuilder lpCurrencyStr, int cchCurrency);

		/// <summary>Formats a number string as a currency string for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// Flags controlling the operation of the function. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case,
		/// the function formats the string using user overrides to the default currency format for the locale. If lpFormat is set to <c>NULL</c>, the
		/// application can specify LOCALE_NOUSEROVERRIDE to format the string using the system default currency format for the specified locale.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a null-terminated string containing the number string to format. This string can contain only the following characters. All other
		/// characters are invalid. The function returns an error if the string deviates from these rules.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a <c>CURRENCYFMT</c> structure that contains currency formatting information. All members of the structure must contain appropriate
		/// values. The application can set this parameter to <c>NULL</c> if function is to use the currency format of the specified locale. If this parameter is
		/// not set to <c>NULL</c>, the function uses the specified locale only for formatting information not specified in the <c>CURRENCYFMT</c> structure, for
		/// example, the string value for the negative sign used by the locale.
		/// </param>
		/// <param name="lpCurrencyStr">Pointer to a buffer in which this function retrieves the formatted currency string.</param>
		/// <param name="cchCurrency">
		/// Size, in characters, of the lpCurrencyStr buffer. The application can set this parameter to 0 to return the size of the buffer required to hold the
		/// formatted currency string. In this case, the buffer indicated by lpCurrencyStr is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpCurrencyStr if successful. If the cchCurrency parameter is 0, the function
		/// returns the size of the buffer required to hold the formatted currency string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCurrencyFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_ LPCWSTR lpValue, _In_opt_ const CURRENCYFMT *lpFormat, _Out_opt_
		// LPWSTR lpCurrencyStr, _In_ int cchCurrency); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318084(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318084")]
		public static extern int GetCurrencyFormatEx(string lpLocaleName, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [In] ref CURRENCYFMT lpFormat, [Out] StringBuilder lpCurrencyStr, int cchCurrency);

		/// <summary>Formats a number string as a currency string for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// Flags controlling the operation of the function. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case,
		/// the function formats the string using user overrides to the default currency format for the locale. If lpFormat is set to <c>NULL</c>, the
		/// application can specify LOCALE_NOUSEROVERRIDE to format the string using the system default currency format for the specified locale.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a null-terminated string containing the number string to format. This string can contain only the following characters. All other
		/// characters are invalid. The function returns an error if the string deviates from these rules.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a <c>CURRENCYFMT</c> structure that contains currency formatting information. All members of the structure must contain appropriate
		/// values. The application can set this parameter to <c>NULL</c> if function is to use the currency format of the specified locale. If this parameter is
		/// not set to <c>NULL</c>, the function uses the specified locale only for formatting information not specified in the <c>CURRENCYFMT</c> structure, for
		/// example, the string value for the negative sign used by the locale.
		/// </param>
		/// <param name="lpCurrencyStr">Pointer to a buffer in which this function retrieves the formatted currency string.</param>
		/// <param name="cchCurrency">
		/// Size, in characters, of the lpCurrencyStr buffer. The application can set this parameter to 0 to return the size of the buffer required to hold the
		/// formatted currency string. In this case, the buffer indicated by lpCurrencyStr is not used.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpCurrencyStr if successful. If the cchCurrency parameter is 0, the function
		/// returns the size of the buffer required to hold the formatted currency string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetCurrencyFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_ LPCWSTR lpValue, _In_opt_ const CURRENCYFMT *lpFormat, _Out_opt_
		// LPWSTR lpCurrencyStr, _In_ int cchCurrency); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318084(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318084")]
		public static extern int GetCurrencyFormatEx(string lpLocaleName, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [Optional] IntPtr lpFormat, [Out] StringBuilder lpCurrencyStr, int cchCurrency);

		/// <summary>Formats a duration of time as a time string for a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale for which this function formats the duration. You can use the <c>MAKELCID</c> macro to create a locale
		/// identifier or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="dwFlags">
		/// Flags specifying function options. If lpFormat is not set to <c>NULL</c>, this parameter must be set to 0. If lpFormat is set to <c>NULL</c>, your
		/// application can specify LOCALE_NOUSEROVERRIDE to format the string using the system default duration format for the specified locale.
		/// </param>
		/// <param name="lpDuration">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the time duration information to format. If this pointer is <c>NULL</c>, the function ignores
		/// this parameter and uses ullDuration.
		/// </param>
		/// <param name="ullDuration">
		/// 64-bit unsigned integer that represents the number of 100-nanosecond intervals in the duration. If both lpDuration and ullDuration are present,
		/// lpDuration takes precedence. If lpDuration is set to <c>NULL</c> and ullDuration is set to 0, the duration is zero.
		/// </param>
		/// <param name="lpFormat">Pointer to the format string. For details, see the lpFormat parameter of <c>GetDurationFormatEx</c>.</param>
		/// <param name="lpDurationStr">
		/// <para>Pointer to the buffer in which the function retrieves the duration string.</para>
		/// <para>
		/// Alternatively, this parameter can contain <c>NULL</c> if cchDuration is set to 0. In this case, the function returns the required size for the
		/// duration string buffer.
		/// </para>
		/// </param>
		/// <param name="cchDuration">
		/// <para>Size, in characters, of the buffer indicated by lpDurationStr.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to 0. In this case, the function retrieves <c>NULL</c> in lpDurationStr and returns the
		/// required size for the duration string buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpDurationStr if successful. If lpDurationStr is set to <c>NULL</c> and
		/// cchDuration is set to 0, the function returns the required size for the duration string buffer, including the null terminating character. For
		/// example, if 10 characters are written to the buffer, the function returns 11 to include the terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetDurationFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpDuration, _In_ ULONGLONG ullDuration, _In_opt_ LPCWSTR
		// lpFormat, _Out_opt_ LPWSTR lpDurationStr, _In_ int cchDuration); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318091(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318091")]
		public static extern int GetDurationFormat(uint Locale, LOCALE_FORMAT_FLAG dwFlags, [In] ref SYSTEMTIME lpDuration, ulong ullDuration, string lpFormat, [Out] StringBuilder lpDurationStr, int cchDuration);

		/// <summary>Formats a duration of time as a time string for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// Flags specifying function options. If lpFormat is not set to <c>NULL</c>, this parameter must be set to 0. If lpFormat is set to <c>NULL</c>, your
		/// application can specify LOCALE_NOUSEROVERRIDE to format the string using the system default duration format for the specified locale.
		/// </param>
		/// <param name="lpDuration">
		/// Pointer to a <c>SYSTEMTIME</c> structure that contains the time duration information to format. The application sets this parameter to <c>NULL</c> if
		/// the function is to ignore it and use ullDuration.
		/// </param>
		/// <param name="ullDuration">
		/// 64-bit unsigned integer that represents the number of 100-nanosecond intervals in the duration. If both lpDuration and ullDuration are set, the
		/// lpDuration parameter takes precedence. If lpDuration is set to <c>NULL</c> and ullDuration is set to 0, the duration is 0.
		/// </param>
		/// <param name="lpFormat">
		/// <para>
		/// Pointer to the format string with characters as shown below. The application can set this parameter to <c>NULL</c> if the function is to format the
		/// string according to the duration format for the specified locale. If lpFormat is not set to <c>NULL</c>, the function uses the locale only for
		/// information not specified in the format picture string.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>d</term>
		/// <term>days</term>
		/// </item>
		/// <item>
		/// <term>h or H</term>
		/// <term>hours</term>
		/// </item>
		/// <item>
		/// <term>hh or HH</term>
		/// <term>hours; if less than ten, prepend a leading zero</term>
		/// </item>
		/// <item>
		/// <term>m</term>
		/// <term>minutes</term>
		/// </item>
		/// <item>
		/// <term>mm</term>
		/// <term>minutes; if less than ten, prepend a leading zero</term>
		/// </item>
		/// <item>
		/// <term>s</term>
		/// <term>seconds</term>
		/// </item>
		/// <item>
		/// <term>ss</term>
		/// <term>seconds; if less than ten, prepend a leading zero</term>
		/// </item>
		/// <item>
		/// <term>f</term>
		/// <term>fractions of a second</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpDurationStr">
		/// <para>Pointer to the buffer in which the function retrieves the duration string.</para>
		/// <para>
		/// Alternatively, this parameter retrieves <c>NULL</c> if cchDuration is set to 0. In this case, the function returns the required size for the duration
		/// string buffer.
		/// </para>
		/// </param>
		/// <param name="cchDuration">
		/// <para>Size, in characters, of the buffer indicated by lpDurationStr.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to 0. In this case, the function retrieves <c>NULL</c> in lpDurationStr and returns the
		/// required size for the duration string buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpDurationStr if successful. If lpDurationStr is set to <c>NULL</c> and
		/// cchDuration is set to 0, the function returns the required size for the duration string buffer, including the terminating null character. For
		/// example, if 10 characters are written to the buffer, the function returns 11 to include the terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetDurationFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_opt_ const SYSTEMTIME *lpDuration, _In_ ULONGLONG ullDuration,
		// _In_opt_ LPCWSTR lpFormat, _Out_opt_ LPWSTR lpDurationStr, _In_ int cchDuration); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318092(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318092")]
		public static extern int GetDurationFormatEx(string lpLocaleName, LOCALE_FORMAT_FLAG dwFlags, [In] ref SYSTEMTIME lpDuration, ulong ullDuration, string lpFormat, [Out] StringBuilder lpDurationStr, int cchDuration);

		/// <summary>Retrieves resource-related information about a file.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags specifying the information to retrieve. Any combination of the following flags is allowed. The default value of the flags is MUI_QUERY_TYPE | MUI_QUERY_CHECKSUM.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_QUERY_TYPE</term>
		/// <term>Retrieve one of the following values in the dwFileType member of FILEMUIINFO:</term>
		/// </item>
		/// <item>
		/// <term>MUI_QUERY_CHECKSUM</term>
		/// <term>
		/// Retrieve the resource checksum of the input file in the pChecksum member of FILEMUIINFO. If the input file does not have resource configuration data,
		/// this member of the structure contains 0.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_QUERY_LANGUAGE_NAME</term>
		/// <term>
		/// Retrieve the language associated with the input file. For a language-specific resource file, this flag requests the associated language. For an LN
		/// file, this flag requests the language of the ultimate fallback resources for the module, which can be either in the LN file or in a separate
		/// language-specific resource file referenced by the resource configuration data of the LN file. For more information, see the Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_QUERY_RESOURCE_TYPES</term>
		/// <term>
		/// Retrieve lists of resource types in the language-specific resource files and LN files as they are specified in the resource configuration data. See
		/// the Remarks section for a way to access this information.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pcwszFilePath">
		/// Pointer to a null-terminated string indicating the path to the file. Typically the file is either an LN file or a language-specific resource file. If
		/// it is not one of these types, the only significant value that the function retrieves is MUI_FILETYPE_NOT_LANGUAGE_NEUTRAL. The function only
		/// retrieves this value if the MUI_QUERY_RESOURCE_TYPES flag is set.
		/// </param>
		/// <param name="pFileMUIInfo">
		/// <para>
		/// Pointer to a buffer containing file information in a <c>FILEMUIINFO</c> structure and possibly in data following that structure. The information
		/// buffer might have to be much larger than the size of the structure itself. Depending on flag settings, the function can store considerable
		/// information following the structure, at offsets retrieved in the structure. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c> if pcbFileMUIInfo is set to 0. In this case, the function retrieves the required
		/// size for the information buffer in pcbFileMUIInfo.
		/// </para>
		/// </param>
		/// <param name="pcbFileMUIInfo">
		/// <para>
		/// Pointer to the buffer size, in bytes, for the file information indicated by pFileMUIInfo. On successful return from the function, this parameter
		/// contains the size of the retrieved file information buffer and the <c>FILEMUIINFO</c> structure that contains it.
		/// </para>
		/// <para>
		/// Alternatively, the application can set this parameter to 0 if it sets <c>NULL</c> in pFileMUIInfo. In this case, the function retrieves the required
		/// file information buffer size in pcbFileMUIInfo. To allocate the correct amount of memory, this value should be added to the size of the
		/// <c>FILEMUIINFO</c> structure itself.
		/// </para>
		/// </param>
		/// <returns>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>.</returns>
		// BOOL GetFileMUIInfo( _In_ DWORD dwFlags, _In_ PCWSTR pcwszFilePath, _Inout_opt_ PFILEMUIINFO pFileMUIInfo, _Inout_ DWORD *pcbFileMUIInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318095(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318095")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileMUIInfo(MUI_QUERY dwFlags, string pcwszFilePath, ref FILEMUIINFO pFileMUIInfo, ref uint pcbFileMUIInfo);

		/// <summary>
		/// Retrieves the path to all language-specific resource files associated with the supplied LN file. The application must call this function repeatedly
		/// to get the path for each resource file.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying language format and filtering. The following flags specify the format of the language indicated by pwszLanguage. The flags are
		/// mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language string in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language string in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following flags specify the filtering for the function to use in locating language-specific resource files if pwszLanguage is set to <c>NULL</c>.
		/// The filtering flags are mutually exclusive, and the default is MUI_USER_PREFERRED_UI_LANGUAGES.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_USE_SEARCH_ALL_LANGUAGES</term>
		/// <term>
		/// Retrieve all language-specific resource files for the path indicated by pcwszFilePath, without considering file licensing. This flag is relevant only
		/// if the application supplies a null string for pwszLanguage.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_USER_PREFERRED_UI_LANGUAGES</term>
		/// <term>
		/// Retrieve only the files that implement languages in the fallback list. Successive calls enumerate the successive fallbacks, in the appropriate order.
		/// The first file indicated by the output value of pcchFileMUIPath should be the best fit. This flag is relevant only if the application supplies a null
		/// string for pwszLanguage.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_USE_INSTALLED_LANGUAGES</term>
		/// <term>
		/// Retrieve only the files for the languages installed on the computer. This flag is relevant only if the application supplies a null string for pwszLanguage.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following flags allow the user to indicate the type of file that is specified by pcwszFilePath so that the function can determine if it must add
		/// ".mui" to the file name. The flags are mutually exclusive. If the application passes both flags, the function fails. If the application passes
		/// neither flag, the function checks the file in the root folder to verify the file type and decide on file naming.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANG_NEUTRAL_PE_FILE</term>
		/// <term>
		/// Do not verify the file passed in pcwszFilePath and append &amp;quot;.mui&amp;quot; to the file name before processing. For example, change Abc.exe to Abc.exe.mui.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_NON_LANG_NEUTRAL_FILE</term>
		/// <term>
		/// Do not verify the file passed in pcwszFilePath and do not append &amp;quot;.mui&amp;quot; to the file name before processing. For example, use
		/// Abc.txt or Abc.chm.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pcwszFilePath">
		/// Pointer to a null-terminated string specifying a file path. The path is either for an existing LN file or for a file such as a .txt, .inf, or .msc
		/// file. If the file is an LN file, the function looks for files containing the associated language-specific resources. For all other types of files,
		/// the function seeks files that correspond exactly to the file name and path indicated. Your application can overwrite the behavior of the file type
		/// check by using the MUI_LANG_NEUTRAL_PE_FILE or MUI_NON_LANG_NEUTRAL_FILE flag. For more information, see the Remarks section.
		/// </param>
		/// <param name="pwszLanguage">
		/// <para>
		/// Pointer to a buffer containing a language string. On input, this buffer contains the language identifier or language name for which the application
		/// should find language-specific resource files, depending on the settings of dwFlags. On successful return from the function, this parameter contains
		/// the language of the language-specific resource file that the function has found.
		/// </para>
		/// <para>
		/// Alternatively, the application can set this parameter to <c>NULL</c>, with the value referenced by pcchLanguage set to 0. In this case, the function
		/// retrieves the required buffer size in pcchLanguage.
		/// </para>
		/// </param>
		/// <param name="pcchLanguage">
		/// Pointer to the buffer size, in characters, for the language string indicated by pwszLanguage. If the application sets the value referenced by this
		/// parameter to 0 and passes <c>NULL</c> for pwszLanguage, then the required buffer size will be returned in pcchLanguage and the returned buffer size
		/// is always LOCALE_NAME_MAX_LENGTH, because the function is typically called multiple times in succession. The function cannot determine the exact size
		/// of the language name for all successive calls, and cannot extend the buffer on subsequent calls. Thus LOCALE_NAME_MAX_LENGTH is the only safe maximum.
		/// </param>
		/// <param name="pwszFileMUIPath">
		/// <para>
		/// Pointer to a buffer containing the path to the language-specific resource file. It is strongly recommended to allocate this buffer to be of size MAX_PATH.
		/// </para>
		/// <para>
		/// Alternatively, this parameter can retrieve <c>NULL</c> if the value referenced by pcchFileMUIPath is set to 0. In this case, the function retrieves
		/// the required size for the file path buffer in pcchFileMUIPath.
		/// </para>
		/// </param>
		/// <param name="pcchFileMUIPath">
		/// Pointer to the buffer size, in characters, for the file path indicated by pwszFileMUIPath. On successful return from the function, this parameter
		/// indicates the size of the retrieved file path. If the application sets the value referenced by this parameter to 0, the function retrieves
		/// <c>NULL</c> for pwszFileMUIPath, the required buffer size will be returned in pcchFileMUIPath and the returned buffer size is always MAX_PATH,
		/// because the function is typically called multiple times in succession. The function cannot determine the exact size of the path for all successive
		/// calls, and cannot extend the buffer on subsequent calls. Thus MAX_PATH is the only safe maximum.
		/// </param>
		/// <param name="pululEnumerator">
		/// Pointer to an enumeration variable. The first time this function is called, the value of the variable should be 0. Between subsequent calls, the
		/// application should not change the value of this parameter. After the function retrieves all possible language-specific resource file paths, it
		/// returns <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. If the function fails, the output parameters do not change.</para>
		/// <para>To get extended error information, the application can call <c>GetLastError</c>, which can return the following error codes:</para>
		/// </returns>
		// BOOL GetFileMUIPath( _In_ DWORD dwFlags, _In_ PCWSTR pcwszFilePath, _Inout_opt_ PWSTR pwszLanguage, _Inout_ PULONG pcchLanguage, _Out_opt_ PWSTR
		// pwszFileMUIPath, _Inout_ PULONG pcchFileMUIPath, _Inout_ PULONGLONG pululEnumerator); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318097(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318097")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileMUIPath(MUI_LANGUAGE_ENUM dwFlags, string pcwszFilePath, StringBuilder pwszLanguage, ref uint pcchLanguage, StringBuilder pwszFileMUIPath, ref uint pcchFileMUIPath, ref ulong pululEnumerator);

		/// <summary>
		/// <para>
		/// [ <c>GetGeoInfo</c> is available for use in the operating systems specified in the Requirements section. It may be altered or unavailable in
		/// subsequent versions. Instead, use <c>GetGeoInfoEx</c>.]
		/// </para>
		/// <para>Retrieves information about a specified geographical location.</para>
		/// </summary>
		/// <param name="Location">
		/// Identifier for the geographical location for which to get information. For more information, see Table of Geographical Locations. You can obtain the
		/// available values by calling <c>EnumSystemGeoID</c>.
		/// </param>
		/// <param name="GeoType">
		/// <para>
		/// Type of information to retrieve. Possible values are defined by the <c>SYSGEOTYPE</c> enumeration. If the value of GeoType is GEO_LCID, the function
		/// retrieves a locale identifier. If the value of GeoType is GEO_RFC1766, the function retrieves a string name that is compliant with RFC 4646 (Windows
		/// Vista). For more information, see the Remarks section.
		/// </para>
		/// <para><c>Windows XP:</c> When GeoType is set to GEO_LCID, the retrieved string is an 8-digit hexadecimal value.</para>
		/// <para><c>Windows Me:</c> When GeoType is set to GEO_LCID, the retrieved string is a decimal value.</para>
		/// </param>
		/// <param name="lpGeoData">Pointer to the buffer in which this function retrieves the information.</param>
		/// <param name="cchData">
		/// Size of the buffer indicated by lpGeoData. The size is the number of bytes for the ANSI version of the function, or the number of words for the
		/// Unicode version. The application can set this parameter to 0 if the function is to return the required size of the buffer.
		/// </param>
		/// <param name="LangId">
		/// Identifier for the language, used with the value of Location. The application can set this parameter to 0, with GEO_RFC1766 or GEO_LCID specified for
		/// GeoType. This setting causes the function to retrieve the language identifier by calling <c>GetUserDefaultLangID</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of bytes (ANSI) or words (Unicode) of geographical location information retrieved in the output buffer. If cchData is set to 0,
		/// the function returns the required size for the buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetGeoInfo( _In_ GEOID Location, _In_ GEOTYPE GeoType, _Out_opt_ LPTSTR lpGeoData, _In_ int cchData, _In_ LANGID LangId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318099(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318099")]
		public static extern int GetGeoInfo(int Location, SYSGEOTYPE GeoType, [Out] StringBuilder lpGeoData, int cchData, ushort LangId);

		/// <summary>
		/// Retrieves information about a geographic location that you specify by using a two-letter International Organization for Standardization (ISO) 3166-1
		/// code or numeric United Nations (UN) Series M, Number 49 (M.49) code.
		/// </summary>
		/// <param name="location">
		/// The two-letter ISO 3166-1 or numeric UN M.49 code for the geographic location for which to get information. To get the codes that are available on
		/// the operating system, call EnumSystemGeoNames.
		/// </param>
		/// <param name="geoType">The type of information you want to retrieve. Possible values are defined by the SYSGEOTYPE enumeration.</param>
		/// <param name="geoData">A pointer to the buffer in which GetGeoInfoEx should write the requested information.</param>
		/// <param name="geoDataCount">
		/// The size of the buffer to which the GeoData parameter points, in characters. Set this parameter to 0 to specify that the function should only return
		/// the size of the buffer required to store the requested information without writing the requested information to the buffer.
		/// </param>
		/// <returns>
		/// The number of bytes of geographical location information that the function wrote the output buffer. If geoDataCount is 0, the function returns the
		/// size of the buffer required to hold the information without writing the information to the buffer.
		/// <para>0 indicates that the function did not succeed.To get extended error information, call GetLastError.</para>
		/// </returns>
		// int WINAPI GetGeoInfoEx( _In_ PWSTR location, _In_ GEOTYPE geoType, _Out_opt_ PWSTR geoData, _In_ int geoDataCount ); https://msdn.microsoft.com/en-us/library/windows/desktop/mt826489(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "mt826489")]
		public static extern int GetGeoInfoEx(string location, SYSGEOTYPE geoType, [Out] StringBuilder geoData, int geoDataCount);

		/// <summary>Retrieves information about a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// Locale identifier for which to retrieve information. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </param>
		/// <param name="LCType">The locale information to retrieve. For detailed definitions, see the LCType parameter of <c>GetLocaleInfoEx</c>.</param>
		/// <param name="lpLCData">
		/// Pointer to a buffer in which this function retrieves the requested locale information. This pointer is not used if cchData is set to 0. For more
		/// information, see the Remarks section.
		/// </param>
		/// <param name="cchData">
		/// Size, in TCHAR values, of the data buffer indicated by lpLCData. Alternatively, the application can set this parameter to 0. In this case, the
		/// function does not use the lpLCData parameter and returns the required buffer size, including the terminating null character.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the locale data buffer if successful and cchData is a nonzero value. If the function succeeds, cchData
		/// is nonzero, and LOCALE_RETURN_NUMBER is specified, the return value is the size of the integer retrieved in the data buffer; that is, 2 for the
		/// Unicode version of the function or 4 for the ANSI version. If the function succeeds and the value of cchData is 0, the return value is the required
		/// size, in characters including a null character, for the locale data buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetLocaleInfo( _In_ LCID Locale, _In_ LCTYPE LCType, _Out_opt_ LPTSTR lpLCData, _In_ int cchData); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318101(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318101")]
		public static extern int GetLocaleInfo(uint Locale, LCTYPE LCType, [Out] StringBuilder lpLCData, int cchData);

		/// <summary>Retrieves information about a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="LCType">
		/// <para>
		/// The locale information to retrieve. For possible values, see the "Constants Used in the LCType Parameter of GetLocaleInfo, GetLocaleInfoEx, and
		/// SetLocaleInfo" section in Locale Information Constants. Note that only one piece of locale information can be specified per call.
		/// </para>
		/// <para>
		/// The application can use the binary OR operator to combine LOCALE_RETURN_NUMBER with any other allowed constant. In this case, the function retrieves
		/// the value as a number instead of a string. The buffer that receives the value must be at least the length of a DWORD value, which is 2.
		/// </para>
		/// <para>If LCType is set to LOCALE_IOPTIONALCALENDAR, the function retrieves only the first alternate calendar.</para>
		/// <para>
		/// Starting with Windows Vista, your applications should not use LOCALE_ILANGUAGE in the LCType parameter to avoid failure or retrieval of unexpected
		/// data. Instead, it is recommended for your applications to call <c>GetLocaleInfoEx</c>.
		/// </para>
		/// </param>
		/// <param name="lpLCData">
		/// Pointer to a buffer in which this function retrieves the requested locale information. This pointer is not used if cchData is set to 0.
		/// </param>
		/// <param name="cchData">
		/// Size, in characters, of the data buffer indicated by lpLCData. Alternatively, the application can set this parameter to 0. In this case, the function
		/// does not use the lpLCData parameter and returns the required buffer size, including the terminating null character.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the locale data buffer if successful and cchData is a nonzero value. If the function succeeds, cchData
		/// is nonzero, and LOCALE_RETURN_NUMBER is specified, the return value is the size of the integer retrieved in the data buffer, that is, 2. If the
		/// function succeeds and the value of cchData is 0, the return value is the required size, in characters including a null character, for the locale data buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetLocaleInfoEx( _In_opt_ LPCWSTR lpLocaleName, _In_ LCTYPE LCType, _Out_opt_ LPWSTR lpLCData, _In_ int cchData); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318103(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318103")]
		public static extern int GetLocaleInfoEx(string lpLocaleName, LCTYPE LCType, [Out] StringBuilder lpLCData, int cchData);

		/// <summary>Retrieves information about the current version of a specified NLS capability for a locale specified by identifier.</summary>
		/// <param name="Function">The NLS capability to query. This value must be COMPARE_STRING. See the <c>SYSNLS_FUNCTION</c> enumeration.</param>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create an identifier or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista and later:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="lpVersionInformation">
		/// Pointer to an <c>NLSVERSIONINFO</c> structure. The application must initialize the <c>dwNLSVersionInfoSize</c> member to .
		/// </param>
		/// <returns>
		/// Returns <c>TRUE</c> if and only if the application has supplied valid values in lpVersionInformation, or <c>FALSE</c> otherwise. To get extended
		/// error information, the application can call <c>GetLastError</c>, which can return one of the following error codes:
		/// </returns>
		// BOOL GetNLSVersion( _In_ NLS_FUNCTION Function, _In_ LCID Locale, _Inout_ LPNLSVERSIONINFO lpVersionInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318105(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318105")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNLSVersion(SYSNLS_FUNCTION Function, uint Locale, ref NLSVERSIONINFO lpVersionInformation);

		/// <summary>Retrieves information about the current version of a specified NLS capability for a locale specified by name.</summary>
		/// <param name="function">The NLS capability to query. This value must be COMPARE_STRING. See the <c>SYSNLS_FUNCTION</c> enumeration.</param>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="lpVersionInformation">
		/// Pointer to an <c>NLSVERSIONINFOEX</c> structure. The application must initialize the <c>dwNLSVersionInfoSize</c> member to .
		/// </param>
		/// <returns>
		/// Returns <c>TRUE</c> if and only if the application has supplied valid values in lpVersionInformation, or <c>FALSE</c> otherwise. To get extended
		/// error information, the application can call <c>GetLastError</c>, which can return one of the following error codes:
		/// </returns>
		// BOOL GetNLSVersionEx( _In_ NLS_FUNCTION function, _In_opt_ LPCWSTR lpLocaleName, _Inout_ LPNLSVERSIONINFOEX lpVersionInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318107(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318107")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNLSVersionEx(SYSNLS_FUNCTION function, string lpLocaleName, ref NLSVERSIONINFOEX lpVersionInformation);

		/// <summary>Formats a number string as a number string customized for a locale specified by identifier.</summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </param>
		/// <param name="dwFlags">
		/// Flags controlling the operation of the function. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case,
		/// the function formats the string using user overrides to the default number format for the locale. If lpFormat is set to <c>NULL</c>, the application
		/// can specify LOCALE_NOUSEROVERRIDE to format the string using the system default number format for the specified locale.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a null-terminated string containing the number string to format. This string can only contain the following characters. All other
		/// characters are invalid. The function returns an error if the string indicated by lpValue deviates from these rules.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a <c>NUMBERFMT</c> structure that contains number formatting information, with all members set to appropriate values. If this parameter
		/// does is not set to <c>NULL</c>, the function uses the locale only for formatting information not specified in the structure, for example, the
		/// locale-specific string value for the negative sign.
		/// </param>
		/// <param name="lpNumberStr">Pointer to a buffer in which this function retrieves the formatted number string.</param>
		/// <param name="cchNumber">
		/// Size, in TCHAR values, for the number string buffer indicated by lpNumberStr. Alternatively, the application can set this parameter to 0. In this
		/// case, the function returns the required size for the number string buffer, and does not use the lpNumberStr parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of TCHAR values retrieved in the buffer indicated by lpNumberStr if successful. If the cchNumber parameter is set to 0, the
		/// function returns the number of characters required to hold the formatted number string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetNumberFormat( _In_ LCID Locale, _In_ DWORD dwFlags, _In_ LPCTSTR lpValue, _In_opt_ const NUMBERFMT *lpFormat, _Out_opt_ LPTSTR lpNumberStr,
		// _In_ int cchNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318110(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318110")]
		public static extern int GetNumberFormat(uint Locale, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [In] ref NUMBERFMT lpFormat, [Out] StringBuilder lpNumberStr, int cchNumber);

		/// <summary>Formats a number string as a number string customized for a locale specified by name.</summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// Flags controlling the operation of the function. The application must set this parameter to 0 if lpFormat is not set to <c>NULL</c>. In this case,
		/// the function formats the string using user overrides to the default number format for the locale. If lpFormat is set to <c>NULL</c>, the application
		/// can specify LOCALE_NOUSEROVERRIDE to format the string using the system default number format for the specified locale.
		/// </param>
		/// <param name="lpValue">
		/// Pointer to a null-terminated string containing the number string to format. This string can only contain the following characters. All other
		/// characters are invalid. The function returns an error if the string indicated by lpValue deviates from these rules.
		/// </param>
		/// <param name="lpFormat">
		/// Pointer to a <c>NUMBERFMT</c> structure that contains number formatting information, with all members set to appropriate values. If the application
		/// does not set this parameter to <c>NULL</c>, the function uses the locale only for formatting information not specified in the structure, for example,
		/// the locale string value for the negative sign.
		/// </param>
		/// <param name="lpNumberStr">
		/// Pointer to a buffer in which this function retrieves the formatted number string. Alternatively, this parameter contains <c>NULL</c> if cchNumber is
		/// set to 0. In this case, the function returns the required size for the number string buffer.
		/// </param>
		/// <param name="cchNumber">
		/// Size, in characters, for the number string buffer indicated by lpNumberStr. Alternatively, the application can set this parameter to 0. In this case,
		/// the function returns the required size for the number string buffer and does not use the lpNumberStr parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the buffer indicated by lpNumberStr if successful. If the cchNumber parameter is set to 0, the function
		/// returns the number of characters required to hold the formatted number string, including a terminating null character.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetNumberFormatEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwFlags, _In_ LPCWSTR lpValue, _In_opt_ const NUMBERFMT *lpFormat, _Out_opt_ LPWSTR
		// lpNumberStr, _In_ int cchNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318113(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318113")]
		public static extern int GetNumberFormatEx(string lpLocaleName, LOCALE_FORMAT_FLAG dwFlags, [In] string lpValue, [In] ref NUMBERFMT lpFormat, [Out] StringBuilder lpNumberStr, int cchNumber);

		/// <summary>Returns the current original equipment manufacturer (OEM) code page identifier for the operating system.</summary>
		/// <returns>Returns the current OEM code page identifier for the operating system.</returns>
		// UINT GetOEMCP(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318114(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318114")]
		public static extern uint GetOEMCP();

		/// <summary>Retrieves the process preferred UI languages. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying the language format to use for the process preferred UI languages. The flags are mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language strings in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language strings in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">Pointer to the number of languages retrieved in pwszLanguagesBuffer.</param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>
		/// Optional. Pointer to a double null-terminated multi-string buffer in which the function retrieves an ordered, null-delimited list in preference
		/// order, starting with the most preferable.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to <c>NULL</c> and pcchLanguagesBuffer is set to 0, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer. The required size includes the two null characters.
		/// </para>
		/// </param>
		/// <param name="pcchLanguagesBuffer">
		/// <para>
		/// Pointer to the size, in characters, for the language buffer indicated by pwszLanguagesBuffer. On successful return from the function, the parameter
		/// contains the size of the retrieved language buffer.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to 0 and pwszLanguagesBuffer is set to <c>NULL</c>, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return one of the following error codes:
		/// </para>
		/// <para>
		/// If the process preferred UI language list is empty or if the languages specified for the process are not valid, the function succeeds and returns an
		/// empty multistring in pwszLanguagesBuffer and 2 in the pcchLanguagesBuffer parameter.
		/// </para>
		/// </returns>
		// BOOL GetProcessPreferredUILanguages( _In_ DWORD dwFlags, _Out_ PULONG pulNumLanguages, _Out_opt_ PZZWSTR pwszLanguagesBuffer, _Inout_ PULONG
		// pcchLanguagesBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318115(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318115")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, out uint pulNumLanguages, IntPtr pwszLanguagesBuffer, ref uint pcchLanguagesBuffer);

		/// <summary>Provides a list of scripts used in the specified Unicode string.</summary>
		/// <param name="dwFlags">
		/// <para>Flags specifying options for script retrieval.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GSS_ALLOW_INHERITED_COMMON</term>
		/// <term>
		/// Retrieve "Qaii" (INHERITED) and "Zyyy" (COMMON) script information. This flag does not affect the processing of unassigned characters. These
		/// characters in the input string always cause a "Zzzz" (UNASSIGNED script) to appear in the script string.
		/// </term>
		/// </item>
		/// </list>
		/// <note type="note">By default, GetStringScripts ignores any inherited or common characters in the input string indicated by lpString. If
		/// GSS_ALLOW_INHERITED_COMMON is not set, neither "Qaii" nor "Zyyy" appears in the script string, even if the input string contains such characters. If
		/// GSS_ALLOW_INHERITED_COMMON is set, and if the input string contains inherited and/or common characters, "Qaii" and/or "Zyyy", respectively, appear in
		/// the script string. See the Remarks section.</note>
		/// </para>
		/// </param>
		/// <param name="lpString">Pointer to the Unicode string to analyze.</param>
		/// <param name="cchString">
		/// Size, in characters, of the Unicode string indicated by lpString. The application sets this parameter to -1 if the Unicode string is null-terminated.
		/// If the application sets this parameter to 0, the function retrieves a null Unicode string (L"\0") in lpScripts and returns 1.
		/// </param>
		/// <param name="lpScripts">
		/// <para>
		/// Pointer to a buffer in which this function retrieves a null-terminated string representing a list of scripts, using the 4-character notation used in
		/// ISO 15924. Each script name consists of four Latin characters, and the names are retrieved in alphabetical order. Each name, including the last, is
		/// followed by a semicolon.
		/// </para>
		/// <para>
		/// Alternatively, this parameter contains <c>NULL</c> if cchScripts is set to 0. In this case, the function returns the required size for the script buffer.
		/// </para>
		/// </param>
		/// <param name="cchScripts">
		/// <para>Size, in characters, of the script buffer indicated by lpScripts.</para>
		/// <para>
		/// Alternatively, the application can set this parameter to 0. In this case, the function retrieves <c>NULL</c> in lpScripts and returns the required
		/// size for the script buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in the output buffer, including a terminating null character, if successful and cchScripts is set to a
		/// nonzero value. The function returns 1 to indicate that no script has been found, for example, when the input string only contains COMMON or INHERITED
		/// characters and GSS_ALLOW_INHERITED_COMMON is not set. Given that each found script adds five characters (four characters + delimiter), a simple
		/// mathematical operation provides the script count as (return_code - 1) / 5.
		/// </para>
		/// <para>
		/// If the function succeeds and the value of cchScripts is 0, the function returns the required size, in characters including a terminating null
		/// character, for the script buffer. The script count is as described above.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetStringScripts( _In_ DWORD dwFlags, _In_ LPCWSTR lpString, _In_ int cchString, _Out_opt_ LPWSTR lpScripts, _In_ int cchScripts); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318116(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318116")]
		public static extern int GetStringScripts(GetStringScriptsFlag dwFlags, string lpString, int cchString, [Out] StringBuilder lpScripts, int cchScripts);

		/// <summary>Returns the language identifier for the system locale.</summary>
		/// <returns>
		/// <para>
		/// Returns the language identifier for the system locale. This is the language used when displaying text in programs that do not support Unicode. It is
		/// set by the Administrator under <c>Control Panel</c> &gt; <c>Clock, Language, and Region</c> &gt; <c>Change date, time, or number formats</c> &gt;
		/// <c>Administrative</c> tab.
		/// </para>
		/// <para>For more information on language identifiers, see Language Identifier Constants and Strings.</para>
		/// </returns>
		// LANGID GetSystemDefaultLangID(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318120(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318120")]
		public static extern ushort GetSystemDefaultLangID();

		/// <summary>Returns the locale identifier for the system locale.</summary>
		/// <returns>Returns the locale identifier for the system default locale, identified by LOCALE_SYSTEM_DEFAULT.</returns>
		// LCID GetSystemDefaultLCID(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318121(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318121")]
		public static extern uint GetSystemDefaultLCID();

		/// <summary>Retrieves the system default locale name.</summary>
		/// <param name="lpLocaleName">Pointer to a buffer in which this function retrieves the locale name.</param>
		/// <param name="cchLocaleName">
		/// Size, in characters, of the output buffer indicated by lpLocaleName. The maximum possible character length of a locale name (including a terminating
		/// null character) is the value of LOCALE_NAME_MAX_LENGTH. This is the recommended size.
		/// </param>
		/// <returns>
		/// <para>Returns a value greater than 0 that indicates the length of the locale name, including the terminating null character, if successful.</para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetSystemDefaultLocaleName( _Out_ LPWSTR lpLocaleName, _In_ int cchLocaleName); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318122(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318122")]
		public static extern int GetSystemDefaultLocaleName([Out] StringBuilder lpLocaleName, int cchLocaleName);

		/// <summary>
		/// Retrieves the language identifier for the system default UI language of the operating system, also known as the "install language" on Windows Vista
		/// and later. For more information, see User Interface Language Management.
		/// </summary>
		/// <returns>Returns the language identifier for the system default UI language of the operating system. For more information, see the Remarks section.</returns>
		// LANGID GetSystemDefaultUILanguage(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318123(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318123")]
		public static extern ushort GetSystemDefaultUILanguage();

		/// <summary>Retrieves the system preferred UI languages. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying language format and filtering. The following flags specify the format to use for the system preferred UI languages. The flags are
		/// mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language strings in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language strings in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following flag specifies whether the function is to validate the list of languages (default) or retrieve the system preferred UI languages list
		/// exactly as it is stored in the registry.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_MACHINE_LANGUAGE_SETTINGS</term>
		/// <term>
		/// Retrieve the stored system preferred UI languages list, checking only to ensure that each language name corresponds to a valid NLS locale. If this
		/// flag is not set, the function retrieves the system preferred UI languages in pwszLanguagesBuffer, as long as the list is non-empty and meets the
		/// validation criteria. Otherwise, the function retrieves the system default user interface language in the language buffer.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">Pointer to the number of languages retrieved in pwszLanguagesBuffer.</param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>
		/// Optional. Pointer to a buffer in which this function retrieves an ordered, null-delimited system preferred UI languages list, in the format specified
		/// by dwFlags. This list ends with two null characters.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to <c>NULL</c> and pcchLanguagesBuffer is set to 0, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer. The required size includes the two null characters
		/// </para>
		/// </param>
		/// <param name="pcchLanguagesBuffer">
		/// <para>
		/// Pointer to the size, in characters, for the language buffer indicated by pwszLanguagesBuffer. On successful return from the function, the parameter
		/// contains the size of the retrieved language buffer.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to 0 and pwszLanguagesBuffer is set to <c>NULL</c>, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return one of the following error codes:
		/// </para>
		/// <para>If the function fails for any other reason, the parameters pulNumLanguages and pcchLanguagesBuffer are undefined.</para>
		/// </returns>
		// BOOL GetSystemPreferredUILanguages( _In_ DWORD dwFlags, _Out_ PULONG pulNumLanguages, _Out_opt_ PZZWSTR pwszLanguagesBuffer, _Inout_ PULONG
		// pcchLanguagesBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318124(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318124")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSystemPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, out uint pulNumLanguages, IntPtr pwszLanguagesBuffer, ref uint pcchLanguagesBuffer);

		/// <summary>Returns the locale identifier of the current locale for the calling thread.</summary>
		/// <returns>
		/// <para>Returns the locale identifier of the locale associated with the current thread.</para>
		/// <para>
		/// <c>Windows Vista</c>: This function can return the identifier of a custom locale. If the current thread locale is a custom locale, the function
		/// returns LOCALE_CUSTOM_DEFAULT. If the current thread locale is a supplemental custom locale, the function can return LOCALE_CUSTOM_UNSPECIFIED. All
		/// supplemental locales share this locale identifier.
		/// </para>
		/// </returns>
		// LCID GetThreadLocale(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318127(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318127")]
		public static extern uint GetThreadLocale();

		/// <summary>Retrieves the thread preferred UI languages for the current thread. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying language format and filtering. The following flags specify the language format to use for the thread preferred UI languages. The
		/// flags are mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language strings in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language strings in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>The following flags specify filtering for the function to use in retrieving the thread preferred UI languages. The default flag is MUI_MERGE_USER_FALLBACK.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_MERGE_SYSTEM_FALLBACK</term>
		/// <term>
		/// Use the system fallback to retrieve a list that corresponds exactly to the language list used by the resource loader. This flag can be used only in
		/// combination with MUI_MERGE_USER_FALLBACK. Using the flags in combination alters the usual effect of MUI_MERGE_USER_FALLBACK by including fallback and
		/// neutral languages in the list.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_MERGE_USER_FALLBACK</term>
		/// <term>
		/// Retrieve a composite list consisting of the thread preferred UI languages, followed by process preferred UI languages, followed by any user preferred
		/// UI languages that are distinct from these, followed by the system default UI language, if it is not already in the list. If the user preferred UI
		/// languages list is empty, the function retrieves the system preferred UI languages. This flag cannot be combined with MUI_THREAD_LANGUAGES.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_THREAD_LANGUAGES</term>
		/// <term>
		/// Retrieve only the thread preferred UI languages for the current thread, or an empty list if no preferred languages are set for the current thread.
		/// This flag cannot be combined with MUI_MERGE_USER_FALLBACK or MUI_MERGE_SYSTEM_FALLBACK.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_UI_FALLBACK</term>
		/// <term>
		/// Retrieve a complete thread preferred UI languages list along with associated fallback and neutral languages. Use of this flag is equivalent to
		/// combining MUI_MERGE_SYSTEM_FALLBACK and MUI_MERGE_USER_FALLBACK. (Applicable only for Windows 7 and later).
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">Pointer to the number of languages retrieved in pwszLanguagesBuffer.</param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>
		/// Optional. Pointer to a buffer in which this function retrieves an ordered, null-delimited thread preferred UI languages list, in the format specified
		/// by dwFlags. This list ends with two null characters.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to <c>NULL</c> and pcchLanguagesBuffer is set to 0, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer. The required size includes the two null characters.
		/// </para>
		/// </param>
		/// <param name="pcchLanguagesBuffer">
		/// <para>
		/// Pointer to the size, in characters, for the language buffer indicated by pwszLanguagesBuffer. On successful return from the function, the parameter
		/// contains the size of the retrieved language buffer.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to 0 and pwszLanguagesBuffer is set to <c>NULL</c>, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// returns one of the following error codes:
		/// </para>
		/// <para>If the function fails for any other reason, the parameters pulNumLanguages and pcchLanguagesBuffer are undefined.</para>
		/// </returns>
		// BOOL GetThreadPreferredUILanguages( _In_ DWORD dwFlags, _Out_ PULONG pulNumLanguages, _Out_opt_ PZZWSTR pwszLanguagesBuffer, _Inout_ PULONG
		// pcchLanguagesBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318128(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318128")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThreadPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, out uint pulNumLanguages, IntPtr pwszLanguagesBuffer, ref uint pcchLanguagesBuffer);

		/// <summary>Returns the language identifier of the first user interface language for the current thread.</summary>
		/// <returns>
		/// Returns the identifier for a language explicitly associated with the thread by <c>SetThreadUILanguage</c> or <c>SetThreadPreferredUILanguages</c>.
		/// Alternatively, if no language has been explicitly associated with the current thread, the identifier can indicate a user or system user interface language.
		/// </returns>
		// LANGID GetThreadUILanguage(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318129(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318129")]
		public static extern ushort GetThreadUILanguage();

		/// <summary>Retrieves a variety of information about an installed UI language:</summary>
		/// <param name="dwFlags">
		/// <para>Flags defining the format of the specified language. The flags are mutually exclusive, and the default is MUI_LANGUAGE_NAME.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language strings in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language strings in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pwmszLanguage">
		/// Pointer to languages for which the function is to retrieve information. This parameter indicates an ordered, null-delimited list of language
		/// identifiers or language names, depending on the flag setting. For information on the use of this parameter, see the Remarks section.
		/// </param>
		/// <param name="pwszFallbackLanguages">
		/// <para>
		/// Pointer to a buffer in which this function retrieves an ordered, null-delimited list of fallback languages, formatted as defined by the setting for
		/// dwFlags. This list ends with two null characters.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to <c>NULL</c> and pcchLanguagesBuffer is set to 0, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer. The required size includes the two null characters.
		/// </para>
		/// </param>
		/// <param name="pcchFallbackLanguages">
		/// <para>
		/// Pointer to the size, in characters, for the language buffer indicated by pwszFallbackLanguages. On successful return from the function, the parameter
		/// contains the size of the retrieved language buffer.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to 0 and pwszLanguagesBuffer is set to <c>NULL</c>, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer.
		/// </para>
		/// </param>
		/// <param name="pdwAttributes">
		/// <para>
		/// Pointer to flags indicating attributes of the input language list. The function always retrieves the flag characterizing the last language listed.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_FULL_LANGUAGE</term>
		/// <term>The language is fully localized.</term>
		/// </item>
		/// <item>
		/// <term>MUI_PARTIAL_LANGUAGE</term>
		/// <term>The language is partially localized.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LIP_LANGUAGE</term>
		/// <term>The language is an LIP language.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>In addition, pdwAttributes includes one or both of the following flags, as appropriate.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_INSTALLED</term>
		/// <term>The language is installed on this computer.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_LICENSED</term>
		/// <term>The language is appropriately licensed for the current user.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return the following error codes:
		/// </para>
		/// <para>If <c>GetLastError</c> returns any other error code, the parameters pcchFallbackLanguages and pdwAttributes are undefined.</para>
		/// </returns>
		// BOOL GetUILanguageInfo( _In_ DWORD dwFlags, _In_ PCZZWSTR pwmszLanguage, _Out_opt_ PZZWSTR pwszFallbackLanguages, _Inout_opt_ PDWORD
		// pcchFallbackLanguages, _Out_ PDWORD pdwAttributes); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318133(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318133")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUILanguageInfo(MUI_LANGUAGE_ENUM dwFlags, IntPtr pwmszLanguage, IntPtr pwszFallbackLanguages, ref uint pcchFallbackLanguages, out MUI_LANGUAGE pdwAttributes);

		/// <summary>
		/// Retrieves the two-letter International Organization for Standardization (ISO) 3166-1 code or numeric United Nations (UN) Series M, Number 49 (M.49)
		/// code for the default geographical location of the user.
		/// </summary>
		/// <param name="geoName">
		/// Pointer to a buffer in which this function should write the null-terminated two-letter ISO 3166-1 or numeric UN M.49 code for the default geographic
		/// location of the user.
		/// </param>
		/// <param name="geoNameCount">
		/// The size of the buffer that the geoName parameter specifies. If this value is zero, the function only returns the number of characters that function
		/// would copy to the output buffer, but does not write the name of the default geographic location of the user to the buffer.
		/// </param>
		/// <returns>
		/// <para>
		/// The number of characters the function would copy to the output buffer, if the value of the geoNameCount parameter is zero. Otherwise, the number of
		/// characters that the function copied to the buffer that the geoName parameter specifies.
		/// </para>
		/// <para>
		/// Zero indicates that the function failed. To get extended error information, call <c>GetLastError</c>, which can return one of the following error codes:
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter value was not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BADDB</term>
		/// <term>The function could not read information from the registry.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>The buffer that the geoName parameter specifies is too small for the string.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// int WINAPI GetUserDefaultGeoName( _Out_ LPWSTR geoName, _In_ geoNameCount int); https://msdn.microsoft.com/en-us/library/windows/desktop/mt826490(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "mt826490")]
		public static extern int GetUserDefaultGeoName([Out] StringBuilder geoName, int geoNameCount);

		/// <summary>Returns the language identifier of the Region Format setting for the current user.</summary>
		/// <returns>
		/// <para>
		/// Returns the language identifier for the current user as set under <c>Control Panel</c> &gt; <c>Clock, Language, and Region</c> &gt; <c>Change date,
		/// time, or number formats</c> &gt; <c>Formats</c> tab &gt; <c>Format</c> dropdown.
		/// </para>
		/// <para>For more information on language identifiers, see Language Identifier Constants and Strings.</para>
		/// </returns>
		// LANGID GetUserDefaultLangID(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318134(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318134")]
		public static extern ushort GetUserDefaultLangID();

		/// <summary>Returns the locale identifier for the user default locale.</summary>
		/// <returns>
		/// Returns the locale identifier for the user default locale, represented as LOCALE_USER_DEFAULT. If the user default locale is a custom locale, this
		/// function always returns LOCALE_CUSTOM_DEFAULT, regardless of the custom locale that is selected. For example, whether the user locale is Hawaiian
		/// (US), haw-US, or Fijiian (Fiji), fj-FJ, the function returns the same value.
		/// </returns>
		// LCID GetUserDefaultLCID(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318135(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318135")]
		public static extern uint GetUserDefaultLCID();

		/// <summary>Retrieves the user default locale name.</summary>
		/// <param name="lpLocaleName">Pointer to a buffer in which this function retrieves the locale name.</param>
		/// <param name="cchLocaleName">
		/// Size, in characters, of the buffer indicated by lpLocaleName. The maximum possible length of a locale name, including a terminating null character,
		/// is LOCALE_NAME_MAX_LENGTH. This is the recommended size to supply in this parameter.
		/// </param>
		/// <returns>
		/// <para>Returns the size of the buffer containing the locale name, including the terminating null character, if successful.</para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int GetUserDefaultLocaleName( _Out_ LPWSTR lpLocaleName, _In_ int cchLocaleName); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318136(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318136")]
		public static extern int GetUserDefaultLocaleName([Out] StringBuilder lpLocaleName, int cchLocaleName);

		/// <summary>
		/// Returns the language identifier for the user UI language for the current user. If the current user has not set a language,
		/// <c>GetUserDefaultUILanguage</c> returns the preferred language set for the system. If there is no preferred language set for the system, then the
		/// system default UI language (also known as "install language") is returned. For more information about the user UI language, see User Interface
		/// Language Management.
		/// </summary>
		/// <returns>Returns the language identifier for the user UI language for the current user.</returns>
		// LANGID GetUserDefaultUILanguage(void); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318137(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318137")]
		public static extern ushort GetUserDefaultUILanguage();

		/// <summary>
		/// <para>
		/// [ <c>GetUserGeoID</c> is available for use in the operating systems specified in the Requirements section. It may be altered or unavailable in
		/// subsequent versions. Instead, use <c>GetUserDefaultGeoName</c>.]
		/// </para>
		/// <para>Retrieves information about the geographical location of the user. For more information, see Table of Geographical Locations.</para>
		/// </summary>
		/// <param name="GeoClass">Geographical location class to return. Possible values are defined by the <c>SYSGEOCLASS</c> enumeration.</param>
		/// <returns>
		/// <para>Returns the geographical location identifier of the user if <c>SetUserGeoID</c> has been called before to set the identifier.</para>
		/// <para>If no geographical location identifier has been set for the user, the function returns GEOID_NOT_AVAILABLE.</para>
		/// </returns>
		// GEOID GetUserGeoID( _In_ GEOCLASS GeoClass); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318138(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318138")]
		public static extern int GetUserGeoID(SYSGEOCLASS GeoClass);

		/// <summary>Retrieves information about the user preferred UI languages. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying language format and filtering. The following flags specify the language format to use for the user preferred UI languages list. The
		/// flags are mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>Retrieve the language strings in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>Retrieve the language strings in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">Pointer to the number of languages retrieved in pwszLanguagesBuffer.</param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>
		/// Optional. Pointer to a buffer in which this function retrieves an ordered, null-delimited user preferred UI languages list, in the format specified
		/// by dwflags. This list ends with two null characters.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to <c>NULL</c> and pcchLanguagesBuffer is set to 0, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer. The required size includes the two null characters.
		/// </para>
		/// </param>
		/// <param name="pcchLanguagesBuffer">
		/// <para>
		/// Pointer to the size, in characters, for the language buffer indicated by pwszLanguagesBuffer. On successful return from the function, the parameter
		/// contains the size of the retrieved language buffer.
		/// </para>
		/// <para>
		/// Alternatively if this parameter is set to 0 and pwszLanguagesBuffer is set to <c>NULL</c>, the function retrieves the required size of the language
		/// buffer in pcchLanguagesBuffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return one of the following error codes:
		/// </para>
		/// <para>If the function fails for any other reason, the values of pulNumLanguages and pcchLanguagesBuffer are undefined.</para>
		/// </returns>
		// BOOL GetUserPreferredUILanguages( _In_ DWORD dwFlags, _Out_ PULONG pulNumLanguages, _Out_opt_ PZZWSTR pwszLanguagesBuffer, _Inout_ PULONG
		// pcchLanguagesBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318139(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318139")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUserPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, out uint pulNumLanguages, IntPtr pwszLanguagesBuffer, ref uint pcchLanguagesBuffer);

		/// <summary>
		/// Converts an internationalized domain name (IDN) or another internationalized label to a Unicode (wide character) representation of the ASCII string
		/// that represents the name in the Punycode transfer encoding syntax.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Flags specifying conversion options. The following table lists the possible values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDN_ALLOW_UNASSIGNED</term>
		/// <term>
		/// Allow unassigned code points to be included in the input string. The default is to not allow unassigned code points, and fail with an extended error
		/// code of ERROR_INVALID_NAME.This flag allows the function to process characters that are not currently legal in IDNs, but might be legal in later
		/// versions of the IDNA standard. If your application encodes unassigned code points as Punycode, the resulting domain names should be illegal. Security
		/// can be compromised if a later version of IDNA makes these names legal or if an application filters out the illegal characters to try to create a
		/// legal domain name. For more information, see Handling Internationalized Domain Names (IDNs).
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDN_USE_STD3_ASCII_RULES</term>
		/// <term>
		/// Filter out ASCII characters that are not allowed in STD3 names. The only ASCII characters allowed in the input Unicode string are letters, digits,
		/// and the hyphen-minus. The string cannot begin or end with the hyphen-minus. The function fails if the input Unicode string contains ASCII characters,
		/// such as &amp;quot;[&amp;quot;, &amp;quot;]&amp;quot;, or &amp;quot;/&amp;quot;, that cannot occur in domain names.The function fails if the input
		/// Unicode string contains control characters (U+0001 through U+0020) or the &amp;quot;delete&amp;quot; character (U+007F). In either case, this flag
		/// has no effect on the non-ASCII characters that are allowed in the Unicode string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDN_EMAIL_ADDRESS</term>
		/// <term>
		/// Starting with Windows 8: Enable EAI algorithmic fallback for the local parts of email addresses (such as &amp;lt;local&amp;gt;@microsoft.com). The
		/// default is for this function to fail when an email address has an invalid address or syntax.An application can set this flag to enable Email Address
		/// Internationalization (EAI) to return a discoverable fallback address, if possible. For more information, see the IETF Email Address
		/// Internationalization (eai) Charter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IDN_RAW_PUNYCODE</term>
		/// <term>Starting with Windows 8: Disable the validation and mapping of Punycode.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpUnicodeCharStr">Pointer to a Unicode string representing an IDN or another internationalized label.</param>
		/// <param name="cchUnicodeChar">Count of characters in the input Unicode string indicated by lpUnicodeCharStr.</param>
		/// <param name="lpASCIICharStr">
		/// Pointer to a buffer that receives a Unicode string consisting only of characters in the ASCII character set. On return from this function, the buffer
		/// contains the ASCII string equivalent of the string provided in lpUnicodeCharStr under Punycode. Alternatively, the function can retrieve <c>NULL</c>
		/// for this parameter, if cchASCIIChar is set to 0. In this case, the function returns the size required for this buffer.
		/// </param>
		/// <param name="cchASCIIChar">
		/// Size of the buffer indicated by lpASCIICharStr. The application can set the parameter to 0 to retrieve <c>NULL</c> in lpASCIICharStr.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in lpASCIICharStr if successful. The retrieved string is null-terminated only if the input Unicode string
		/// is null-terminated.
		/// </para>
		/// <para>
		/// If the function succeeds and the value of cchASCIIChar is 0, the function returns the required size, in characters including a terminating null
		/// character if it was part of the input buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int IdnToAscii( _In_ DWORD dwFlags, _In_ LPCWSTR lpUnicodeCharStr, _In_ int cchUnicodeChar, _Out_opt_ LPWSTR lpASCIICharStr, _In_ int cchASCIIChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318149(v=vs.85).aspx
		[DllImport(Lib.Normaliz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318149")]
		public static extern int IdnToAscii(IDN_FLAGS dwFlags, string lpUnicodeCharStr, int cchUnicodeChar, [Out] StringBuilder lpASCIICharStr, int cchASCIIChar);

		/// <summary>
		/// Converts an internationalized domain name (IDN) or another internationalized label to the NamePrep form specified by Network Working Group RFC 3491,
		/// but does not perform the additional conversion to Punycode. For more information and links to related draft standards, see Handling Internationalized
		/// Domain Names (IDNs).
		/// </summary>
		/// <param name="dwFlags">Flags specifying conversion options. For detailed definitions, see the dwFlags parameter of <c>IdnToAscii</c>.</param>
		/// <param name="lpUnicodeCharStr">Pointer to a Unicode string representing an IDN or another internationalized label.</param>
		/// <param name="cchUnicodeChar">Count of Unicode characters in the input Unicode string indicated by lpUnicodeCharStr.</param>
		/// <param name="lpNameprepCharStr">
		/// Pointer to a buffer that receives a version of the input Unicode string converted through NamePrep processing. Alternatively, the function can
		/// retrieve <c>NULL</c> for this parameter, if cchNameprepChar is set to 0. In this case, the function returns the size required for this buffer.
		/// </param>
		/// <param name="cchNameprepChar">
		/// Size, in characters, of the buffer indicated by lpNameprepCharStr. The application can set the size to 0 to retrieve <c>NULL</c> in lpNameprepCharStr
		/// and have the function return the required buffer size.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in lpNameprepCharStr if successful. The retrieved string is null-terminated only if the input Unicode
		/// string is null-terminated.
		/// </para>
		/// <para>
		/// If the function succeeds and the value of cchNameprepChar is 0, the function returns the required size, in characters including a terminating null
		/// character if it was part of the input buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int IdnToNameprepUnicode( _In_ DWORD dwFlags, _In_ LPCWSTR lpUnicodeCharStr, _In_ int cchUnicodeChar, _Out_opt_ LPWSTR lpNameprepCharStr, _In_ int
		// cchNameprepChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318150(v=vs.85).aspx
		[DllImport(Lib.Normaliz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318150")]
		public static extern int IdnToNameprepUnicode(IDN_FLAGS dwFlags, string lpUnicodeCharStr, int cchUnicodeChar, [Out] StringBuilder lpNameprepCharStr, int cchNameprepChar);

		/// <summary>
		/// Converts the Punycode form of an internationalized domain name (IDN) or another internationalized label to the normal Unicode UTF-16 encoding syntax.
		/// </summary>
		/// <param name="dwFlags">Flags specifying conversion options. For detailed definitions, see the dwFlags parameter of <c>IdnToAscii</c>.</param>
		/// <param name="lpASCIICharStr">
		/// Pointer to a string representing the Punycode encoding of an IDN or another internationalized label. This string must consist only of ASCII
		/// characters, and can include Punycode-encoded Unicode. The function decodes Punycode values to their UTF-16 values.
		/// </param>
		/// <param name="cchASCIIChar">Count of characters in the input string indicated by lpASCIICharStr.</param>
		/// <param name="lpUnicodeCharStr">
		/// Pointer to a buffer that receives a normal Unicode UTF-16 encoding equivalent to the Punycode value of the input string. Alternatively, the function
		/// can retrieve <c>NULL</c> for this parameter, if cchUnicodeChar set to 0. In this case, the function returns the size required for this buffer.
		/// </param>
		/// <param name="cchUnicodeChar">
		/// Size, in characters, of the buffer indicated by lpUnicodeCharStr. The application can set the size to 0 to retrieve <c>NULL</c> in lpUnicodeCharStr
		/// and have the function return the required buffer size.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters retrieved in lpUnicodeCharStr if successful. The retrieved string is null-terminated only if the input string is null-terminated.
		/// </para>
		/// <para>
		/// If the function succeeds and the value of cchUnicodeChar is 0, the function returns the required size, in characters including a terminating null
		/// character if it was part of the input buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int IdnToUnicode( _In_ DWORD dwFlags, _In_ LPCWSTR lpASCIICharStr, _In_ int cchASCIIChar, _Out_opt_ LPWSTR lpUnicodeCharStr, _In_ int cchUnicodeChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318151(v=vs.85).aspx
		[DllImport(Lib.Normaliz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318151")]
		public static extern int IdnToUnicode(IDN_FLAGS dwFlags, string lpASCIICharStr, int cchASCIIChar, [Out] StringBuilder lpUnicodeCharStr, int cchUnicodeChar);

		/// <summary>
		/// Determines if a specified character is a lead byte for the system default Windows ANSI code page ( <c>CP_ACP</c>). A lead byte is the first byte of a
		/// two-byte character in a double-byte character set (DBCS) for the code page.
		/// </summary>
		/// <param name="TestChar">The character to test.</param>
		/// <returns>
		/// Returns a nonzero value if the test character is potentially a lead byte. The function returns 0 if the test character is not a lead byte or if it is
		/// a single-byte character. To get extended error information, the application can call <c>GetLastError</c>.
		/// </returns>
		// BOOL IsDBCSLeadByte( _In_ BYTE TestChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318664(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318664")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsDBCSLeadByte(byte TestChar);

		/// <summary>
		/// Determines if a specified character is potentially a lead byte. A lead byte is the first byte of a two-byte character in a double-byte character set
		/// (DBCS) for the code page.
		/// </summary>
		/// <param name="CodePage">
		/// <para>
		/// Identifier of the code page used to check lead byte ranges. This parameter can be one of the code page identifiers defined in Unicode and Character
		/// Set Constants or one of the following predefined values. This function validates lead byte values only in code pages 932, 936, 949, 950, and 1361.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CP_ACP</term>
		/// <term>Use system default Windows ANSI code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_MACCP</term>
		/// <term>Use the system default Macintosh code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_OEMCP</term>
		/// <term>Use system default OEM code page.</term>
		/// </item>
		/// <item>
		/// <term>CP_THREAD_ACP</term>
		/// <term>Use the Windows ANSI code page for the current thread.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="TestChar">The character to test.</param>
		/// <returns>
		/// Returns a nonzero value if the byte is a lead byte. The function returns 0 if the byte is not a lead byte or if the character is a single-byte
		/// character. To get extended error information, the application can call <c>GetLastError</c>.
		/// </returns>
		// BOOL IsDBCSLeadByteEx( _In_ UINT CodePage, _In_ BYTE TestChar); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318667(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318667")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsDBCSLeadByteEx(uint CodePage, byte TestChar);

		/// <summary>Determines if each character in a string has a defined result for a specified NLS capability.</summary>
		/// <param name="Function">NLS capability to query. This value must be COMPARE_STRING. See the <c>SYSNLS_FUNCTION</c> enumeration.</param>
		/// <param name="dwFlags">Flags defining the function. Must be 0.</param>
		/// <param name="lpVersionInformation">
		/// Pointer to an <c>NLSVERSIONINFO</c> structure containing version information. Typically, the information is obtained by calling <c>GetNLSVersion</c>.
		/// The application sets this parameter to <c>NULL</c> if the function is to use the current version.
		/// </param>
		/// <param name="lpString">Pointer to the UTF-16 string to examine.</param>
		/// <param name="cchStr">
		/// <para>
		/// Number of UTF-16 characters in the string indicated by lpString. This count can include a terminating null character. If the terminating null
		/// character is included in the character count, it does not affect the checking behavior because the terminating null character is always defined.
		/// </para>
		/// <para>The application should supply -1 to indicate that the string is null-terminated. In this case, the function itself calculates the string length.</para>
		/// </param>
		/// <returns>
		/// Returns <c>TRUE</c> if successful, only if the input string is valid, or <c>FALSE</c> otherwise. To get extended error information, the application
		/// can call <c>GetLastError</c>, which can return one of the following error codes:
		/// </returns>
		// BOOL IsNLSDefinedString( _In_ NLS_FUNCTION Function, _In_ DWORD dwFlags, _In_ LPNLSVERSIONINFO lpVersionInformation, _In_ LPCWSTR lpString, _In_ INT
		// cchStr); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318669(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318669")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsNLSDefinedString(SYSNLS_FUNCTION Function, [Optional] uint dwFlags, ref NLSVERSIONINFO lpVersionInformation, string lpString, int cchStr);

		/// <summary>
		/// Verifies that a string is normalized according to Unicode 4.0 TR#15. For more information, see Using Unicode Normalization to Represent Strings.
		/// </summary>
		/// <param name="NormForm">Normalization form to use. <c>NORM_FORM</c> specifies the standard Unicode normalization forms.</param>
		/// <param name="lpString">Pointer to the string to test.</param>
		/// <param name="cwLength">
		/// Length, in characters, of the input string, including a null terminating character. If this value is -1, the function assumes the string to be
		/// null-terminated and calculates the length automatically.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the input string is already normalized to the appropriate form, or <c>FALSE</c> otherwise. To get extended error information,
		/// the application can call <c>GetLastError</c>, which can return one of the following error codes:
		/// </para>
		/// <para>If you need to reliably determine <c>FALSE</c> from an error condition, then it must call <c>SetLastError</c>(ERROR_SUCCESS).</para>
		/// </returns>
		// BOOL IsNormalizedString( _In_ NORM_FORM NormForm, _In_ LPCWSTR lpString, _In_ int cwLength); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318671(v=vs.85).aspx
		[DllImport(Lib.Normaliz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318671")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsNormalizedString(NORM_FORM NormForm, string lpString, int cwLength);

		/// <summary>Determines if a specified code page is valid.</summary>
		/// <param name="CodePage">Code page identifier for the code page to check.</param>
		/// <returns>Returns a nonzero value if the code page is valid, or 0 if the code page is invalid.</returns>
		// BOOL IsValidCodePage( _In_ UINT CodePage); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318674(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318674")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidCodePage(uint CodePage);

		/// <summary>Determines if a language group is installed or supported on the operating system. For more information, see NLS Terminology.</summary>
		/// <param name="LanguageGroup">Identifier of language group to validate. This parameter can have one of the following values:</param>
		/// <param name="dwFlags">
		/// <para>Flag specifying the validity test to apply to the language group identifier. This parameter can be set to one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LGRPID_INSTALLED</term>
		/// <term>Determine if language group identifier is both supported and installed.</term>
		/// </item>
		/// <item>
		/// <term>LGRPID_SUPPORTED</term>
		/// <term>Determine if language group identifier is supported.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>Returns <c>TRUE</c> if the language group identifier passes the specified validity test, or <c>FALSE</c> otherwise.</returns>
		// BOOL IsValidLanguageGroup( _In_ LGRPID LanguageGroup, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318677(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318677")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidLanguageGroup(LGRPID LanguageGroup, LGRPID_FLAGS dwFlags);

		/// <summary>
		/// <para>
		/// [ <c>IsValidLocale</c> is available for use in the operating systems specified in the Requirements section. It may be altered or unavailable in
		/// subsequent versions. Instead, use <c>IsValidLocaleName</c> to determine the validity of a supplemental locale.]
		/// </para>
		/// <para>Determines if the specified locale is installed or supported on the operating system. For more information, see Locales and Languages.</para>
		/// </summary>
		/// <param name="Locale">
		/// Locale identifier of the locale to validate. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flag specifying the validity test to apply to the locale identifier. This parameter can have one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LCID_INSTALLED</term>
		/// <term>Determine if the locale identifier is both supported and installed.</term>
		/// </item>
		/// <item>
		/// <term>LCID_SUPPORTED</term>
		/// <term>Determine if the locale identifier is supported.</term>
		/// </item>
		/// <item>
		/// <term>0x39</term>
		/// <term>
		/// Do not use. Instead, use LCID_INSTALLED.Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP and Windows 2000: Setting dwFlags to 0x39
		/// is a special case that can behave like LCID_INSTALLED for some locales on some versions of Windows.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>Returns a nonzero value if the locale identifier passes the specified validity test. The function returns 0 if it does not succeed.</returns>
		// BOOL IsValidLocale( _In_ LCID Locale, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318679(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318679")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidLocale(uint Locale, LCID_FLAGS dwFlags);

		/// <summary>Determines if the specified locale name is valid for a locale that is installed or supported on the operating system.</summary>
		/// <param name="lpLocaleName">Pointer to the locale name to validate.</param>
		/// <returns>Returns a nonzero value if the locale name is valid, or returns 0 for an invalid name.</returns>
		// BOOL IsValidLocaleName( _In_ LPCWSTR lpLocaleName); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318681(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318681")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidLocaleName(string lpLocaleName);

		/// <summary>Determines if the NLS version is valid for a given NLS function.</summary>
		/// <param name="function">The NLS capability to query. This value must be COMPARE_STRING. See the <c>SYSNLS_FUNCTION</c> enumeration.</param>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="lpVersionInformation">
		/// Pointer to an <c>NLSVERSIONINFOEX</c> structure. The application must initialize the <c>dwNLSVersionInfoSize</c> member to .
		/// </param>
		/// <returns>Returns a nonzero value if the NLS version is valid, or zero if the version is invalid.</returns>
		// DWORD IsValidNLSVersion( _In_ NLS_FUNCTION function, _In_opt_ LPCWSTR lpLocaleName, _In_ LPNLSVERSIONINFOEX lpVersionInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706739(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "hh706739")]
		public static extern uint IsValidNLSVersion(SYSNLS_FUNCTION function, string lpLocaleName, ref NLSVERSIONINFOEX lpVersionInformation);

		/// <summary>Converts a locale identifier to a locale name.</summary>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier to translate. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following predefined values.
		/// </para>
		/// <para><c>Windows Vista:</c> The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="lpName">Pointer to a buffer in which this function retrieves the locale name, or one of the following predefined values.</param>
		/// <param name="cchName">
		/// <para>
		/// Size, in characters, of the locale name buffer. The maximum possible length of a locale name, including a terminating null character, is
		/// LOCALE_NAME_MAX_LENGTH. This is the recommended size to supply for this parameter.
		/// </para>
		/// <para>Alternatively, the application can set this parameter to 0. In this case, the function returns the required size for the locale name buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para><c>Before Windows 7:</c> Reserved; should always be 0.</para>
		/// <para><c>Starting with Windows 7:</c> Can be set to LOCALE_ALLOW_NEUTRAL_NAMES to allow the return of a neutral name.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the count of characters, including the terminating null character, in the locale name if successful. If the function succeeds and the value
		/// of cchName is 0, the return value is the required size, in characters (including nulls), for the locale name buffer.
		/// </para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int LCIDToLocaleName( _In_ LCID Locale, _Out_opt_ LPWSTR lpName, _In_ int cchName, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318698(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318698")]
		public static extern int LCIDToLocaleName(uint Locale, [Out] StringBuilder lpName, int cchName, LCTYPE dwFlags);

		/// <summary>
		/// For a locale specified by identifier, maps one input character string to another using a specified transformation, or generates a sort key for the
		/// input string.
		/// </summary>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </para>
		/// <para>The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="dwMapFlags">
		/// Flags specifying the type of transformation to use during string mapping or the type of sort key to generate. For detailed definitions, see the
		/// dwMapFlags parameter of <c>LCMapStringEx</c>.
		/// </param>
		/// <param name="lpSrcStr">Pointer to a source string that the function maps or uses for sort key generation. This string cannot have a size of 0.</param>
		/// <param name="cchSrc">
		/// <para>
		/// Size, in characters, of the source string indicated by lpSrcStr. The size of the source string can include the terminating null character, but does
		/// not have to. If the terminating null character is included, the mapping behavior of the function is not greatly affected because the terminating null
		/// character is considered to be unsortable and always maps to itself.
		/// </para>
		/// <para>
		/// The application can set the parameter to any negative value to specify that the source string is null-terminated. In this case, if <c>LCMapString</c>
		/// is being used in its string-mapping mode, the function calculates the string length itself, and null-terminates the mapped string indicated by lpDestStr.
		/// </para>
		/// <para>The application cannot set this parameter to 0.</para>
		/// </param>
		/// <param name="lpDestStr">
		/// Pointer to a buffer in which this function retrieves the mapped string or a sort key. When the application uses this function to generate a sort key,
		/// the destination string can contain an odd number of bytes. The LCMAP_BYTEREV flag only reverses an even number of bytes. The last byte
		/// (odd-positioned) in the sort key is not reversed.
		/// </param>
		/// <param name="cchDest">
		/// <para>
		/// Size, in characters, of the destination string indicated by lpDestStr. If the application is using the function for string mapping, it supplies a
		/// character count for this parameter. If space for a terminating null character is included in cchSrc, cchDest must also include space for a
		/// terminating null character.
		/// </para>
		/// <para>
		/// If the application is using the function to generate a sort key, it supplies a byte count for the size. This byte count must include space for the
		/// sort key 0x00 terminator.
		/// </para>
		/// <para>
		/// The application can set cchDest to 0. In this case, the function does not use the lpDestStr parameter and returns the required buffer size for the
		/// mapped string or sort key.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the number of characters or bytes in the translated string or sort key, including a terminating null character, if successful. If the
		/// function succeeds and the value of cchDest is 0, the return value is the size of the buffer required to hold the translated string or sort key,
		/// including a terminating null character.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int LCMapString( _In_ LCID Locale, _In_ DWORD dwMapFlags, _In_ LPCTSTR lpSrcStr, _In_ int cchSrc, _Out_opt_ LPTSTR lpDestStr, _In_ int cchDest); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318700(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318700")]
		public static extern int LCMapString(uint Locale, uint dwMapFlags, [In] string lpSrcStr, int cchSrc, [Out] StringBuilder lpDestStr, int cchDest);

		/// <summary>
		/// For a locale specified by name, maps an input character string to another using a specified transformation, or generates a sort key for the input string.
		/// </summary>
		/// <param name="lpLocaleName">Pointer to a locale name, or one of the following predefined values.</param>
		/// <param name="dwMapFlags">
		/// <para>
		/// Flag specifying the type of transformation to use during string mapping or the type of sort key to generate. This parameter can have the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LCMAP_BYTEREV</term>
		/// <term>Use byte reversal. For example, if the application passes in 0x3450 0x4822, the result is 0x5034 0x2248.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_FULLWIDTH</term>
		/// <term>
		/// Use Unicode (wide) characters where applicable. This flag and LCMAP_HALFWIDTH are mutually exclusive. With this flag, the mapping may use
		/// Normalization Form C even if an input character is already full-width. For example, the string &amp;quot;は゛&amp;quot; (which is already full-width)
		/// is normalized to &amp;quot;ば&amp;quot;. See Unicode normalization forms.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LCMAP_HALFWIDTH</term>
		/// <term>Use narrow characters where applicable. This flag and LCMAP_FULLWIDTH are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_HIRAGANA</term>
		/// <term>Map all katakana characters to hiragana. This flag and LCMAP_KATAKANA are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_KATAKANA</term>
		/// <term>Map all hiragana characters to katakana. This flag and LCMAP_HIRAGANA are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_LINGUISTIC_CASING</term>
		/// <term>Use linguistic rules for casing, instead of file system rules (default). This flag is valid with LCMAP_LOWERCASE or LCMAP_UPPERCASE only.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_LOWERCASE</term>
		/// <term>For locales and scripts capable of handling uppercase and lowercase, map all characters to lowercase.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_SIMPLIFIED_CHINESE</term>
		/// <term>Map traditional Chinese characters to simplified Chinese characters. This flag and LCMAP_TRADITIONAL_CHINESE are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_SORTKEY</term>
		/// <term>
		/// Produce a normalized sort key. If the LCMAP_SORTKEY flag is not specified, the function performs string mapping. For details of sort key generation
		/// and string mapping, see the Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LCMAP_TITLECASE</term>
		/// <term>Windows 7: Map all characters to title case, in which the first letter of each major word is capitalized.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_TRADITIONAL_CHINESE</term>
		/// <term>Map simplified Chinese characters to traditional Chinese characters. This flag and LCMAP_SIMPLIFIED_CHINESE are mutually exclusive.</term>
		/// </item>
		/// <item>
		/// <term>LCMAP_UPPERCASE</term>
		/// <term>For locales and scripts capable of handling uppercase and lowercase, map all characters to uppercase.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following flags can be used alone, with one another, or with the LCMAP_SORTKEY and/or LCMAP_BYTEREV flags. However, they cannot be combined with
		/// the other flags listed above.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NORM_IGNORENONSPACE</term>
		/// <term>Ignore nonspacing characters. For many scripts (notably Latin scripts), NORM_IGNORENONSPACE coincides with LINGUISTIC_IGNOREDIACRITIC.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNORESYMBOLS</term>
		/// <term>Ignore symbols and punctuation.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>The flags listed below are used only with the LCMAP_SORTKEY flag.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LINGUISTIC_IGNORECASE</term>
		/// <term>Ignore case, as linguistically appropriate.</term>
		/// </item>
		/// <item>
		/// <term>LINGUISTIC_IGNOREDIACRITIC</term>
		/// <term>Ignore nonspacing characters, as linguistically appropriate.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNORECASE</term>
		/// <term>Ignore case. For many scripts (notably Latin scripts), NORM_IGNORECASE coincides with LINGUISTIC_IGNORECASE.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNOREKANATYPE</term>
		/// <term>Do not differentiate between hiragana and katakana characters. Corresponding hiragana and katakana characters compare as equal.</term>
		/// </item>
		/// <item>
		/// <term>NORM_IGNOREWIDTH</term>
		/// <term>
		/// Ignore the difference between half-width and full-width characters, for example, C a t == cat. The full-width form is a formatting distinction used
		/// in Chinese and Japanese scripts.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NORM_LINGUISTIC_CASING</term>
		/// <term>Use linguistic rules for casing, instead of file system rules (default).</term>
		/// </item>
		/// <item>
		/// <term>SORT_DIGITSASNUMBERS</term>
		/// <term>Windows 7: Treat digits as numbers during sorting, for example, sort &amp;quot;2&amp;quot; before &amp;quot;10&amp;quot;.</term>
		/// </item>
		/// <item>
		/// <term>SORT_STRINGSORT</term>
		/// <term>Treat punctuation the same as symbols.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpSrcStr">Pointer to a source string that the function maps or uses for sort key generation. This string cannot have a size of 0.</param>
		/// <param name="cchSrc">
		/// <para>
		/// Size, in characters, of the source string indicated by lpSrcStr. The size of the source string can include the terminating null character, but does
		/// not have to. If the terminating null character is included, the mapping behavior of the function is not greatly affected because the terminating null
		/// character is considered to be unsortable and always maps to itself.
		/// </para>
		/// <para>
		/// The application can set this parameter to any negative value to specify that the source string is null-terminated. In this case, if
		/// <c>LCMapStringEx</c> is being used in its string-mapping mode, the function calculates the string length itself, and null-terminates the mapped
		/// string indicated by lpDestStr.
		/// </para>
		/// <para>The application cannot set this parameter to 0.</para>
		/// </param>
		/// <param name="lpDestStr">
		/// Pointer to a buffer in which this function retrieves the mapped string or sort key. If the application specifies LCMAP_SORTKEY, the function stores a
		/// sort key in the buffer as an opaque array of byte values that can include embedded 0 bytes.
		/// </param>
		/// <param name="cchDest">
		/// <para>
		/// Size, in characters, of the buffer indicated by lpDestStr. If the application is using the function for string mapping, it supplies a character count
		/// for this parameter. If space for a terminating null character is included in cchSrc, cchDest must also include space for a terminating null character.
		/// </para>
		/// <para>
		/// If the application is using the function to generate a sort key, it supplies a byte count for the size. This byte count must include space for the
		/// sort key 0x00 terminator.
		/// </para>
		/// <para>
		/// The application can set cchDest to 0. In this case, the function does not use the lpDestStr parameter and returns the required buffer size for the
		/// mapped string or sort key.
		/// </para>
		/// </param>
		/// <param name="lpVersionInformation">
		/// <para>
		/// Pointer to an <c>NLSVERSIONINFOEX</c> structure that contains the version information about the relevant NLS capability; usually retrieved from <c>GetNLSVersionEx</c>.
		/// </para>
		/// <para><c>Windows Vista, Windows 7:</c> Reserved; must set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="lpReserved">Reserved; must be <c>NULL</c>.</param>
		/// <param name="sortHandle">Reserved; must be 0.</param>
		/// <returns>
		/// <para>
		/// Returns the number of characters or bytes in the translated string or sort key, including a terminating null character, if successful. If the
		/// function succeeds and the value of cchDest is 0, the return value is the size of the buffer required to hold the translated string or sort key,
		/// including a terminating null character if the input was null terminated.
		/// </para>
		/// <para>
		/// This function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int LCMapStringEx( _In_opt_ LPCWSTR lpLocaleName, _In_ DWORD dwMapFlags, _In_ LPCWSTR lpSrcStr, _In_ int cchSrc, _Out_opt_ LPWSTR lpDestStr, _In_ int
		// cchDest, _In_opt_ LPNLSVERSIONINFO lpVersionInformation, _In_opt_ LPVOID lpReserved, _In_opt_ LPARAM sortHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318702(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318702")]
		public static extern int LCMapStringEx(string lpLocaleName, uint dwMapFlags, string lpSrcStr, int cchSrc, [Out] StringBuilder lpDestStr, int cchDest, ref NLSVERSIONINFO lpVersionInformation, [Optional] IntPtr lpReserved, [Optional] IntPtr sortHandle);

		/// <summary>Converts a locale name to a locale identifier.</summary>
		/// <param name="lpName">Pointer to a null-terminated string representing a locale name, or one of the following predefined values.</param>
		/// <param name="dwFlags">
		/// <para><c>Prior to Windows 7:</c> Reserved; should always be 0.</para>
		/// <para><c>Beginning in Windows 7:</c> Can be set to LOCALE_ALLOW_NEUTRAL_NAMES to allow the return of a neutral LCID.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the locale identifier corresponding to the locale name if successful. If the supplied locale name corresponds to a custom locale that is the
		/// user default, this function returns LOCALE_CUSTOM_DEFAULT. If the locale name corresponds to a custom locale that is not the user default, the
		/// function returns LOCALE_CUSTOM_UNSPECIFIED.
		/// </para>
		/// <para>If the locale provided is a transient locale or a CLDR (Unicode Common Locale Data Repository) locale, then the LCID returned is 0x1000.</para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// LCID LocaleNameToLCID( _In_ LPCWSTR lpName, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd318711(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd318711")]
		public static extern uint LocaleNameToLCID(string lpName, LCTYPE dwFlags);

		/// <summary>Creates a language identifier from a primary language identifier and a sublanguage identifier.</summary>
		/// <param name="usPrimaryLanguage">
		/// Primary language identifier. This identifier can be a predefined value or a value for a user-defined primary language. For a user-defined language,
		/// the identifier is a value in the range 0x0200 to 0x03FF. All other values are reserved for operating system use. For more information, see Language
		/// Identifier Constants and Strings.
		/// </param>
		/// <param name="usSubLanguage">
		/// Sublanguage identifier. This parameter can be a predefined sublanguage identifier or a user-defined sublanguage. For a user-defined sublanguage, the
		/// identifier is a value in the range 0x20 to 0x3F. All other values are reserved for operating system use. For more information, see Language
		/// Identifier Constants and Strings.
		/// </param>
		/// <returns>Returns the language identifier.</returns>
		// WORD MAKELANGID( USHORT usPrimaryLanguage, USHORT usSubLanguage); https://msdn.microsoft.com/en-us/library/windows/desktop/dd373908(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "dd373908")]
		public static ushort MAKELANGID(ushort p, ushort s) => (ushort)(s << 10 | PRIMARYLANGID(p));

		/// <summary>Creates a locale identifier from a language identifier and a sort order identifier.</summary>
		/// <param name="wLanguageID">
		/// Language identifier. This identifier is a combination of a primary language identifier and a sublanguage identifier and is usually created by using
		/// the <c>MAKELANGID</c> macro.
		/// </param>
		/// <param name="wSortID">Sort order identifier.</param>
		/// <returns>Returns the locale identifier.</returns>
		// DWORD MAKELCID( WORD wLanguageID, WORD wSortID); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319052(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "dd319052")]
		public static uint MAKELCID(ushort lgid, ushort srtid) => Macros.MAKELONG((ushort)(srtid & 0xf), lgid);

		/// <summary>Constructs a locale identifier (LCID) from a language identifier, a sort order identifier, and the sort version.</summary>
		/// <param name="wLanguageID">
		/// Language identifier. This parameter is a combination of a primary language identifier and a sublanguage identifier and is usually created by using
		/// the <c>MAKELANGID</c> macro.
		/// </param>
		/// <param name="wSortID">Sort order identifier.</param>
		/// <param name="wSortVersion">Reserved; must be 0.</param>
		/// <returns>Returns the LCID.</returns>
		// DWORD MAKESORTLCID( WORD wLanguageID, WORD wSortID, WORD wSortVersion); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319053(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "dd319053")]
		public static uint MAKESORTLCID(ushort lgid, ushort srtid, ushort ver) => MAKELCID(lgid, srtid) | (((uint)ver & 0xf) << 20);

		/// <summary>
		/// Normalizes characters of a text string according to Unicode 4.0 TR#15. For more information, see Using Unicode Normalization to Represent Strings.
		/// </summary>
		/// <param name="NormForm">Normalization form to use. <c>NORM_FORM</c> specifies the standard Unicode normalization forms.</param>
		/// <param name="lpSrcString">Pointer to the non-normalized source string.</param>
		/// <param name="cwSrcLength">
		/// Length, in characters, of the buffer containing the source string. The application can set this parameter to -1 if the function should assume the
		/// string to be null-terminated and calculate the length automatically.
		/// </param>
		/// <param name="lpDstString">
		/// Pointer to a buffer in which the function retrieves the destination string. Alternatively, this parameter contains <c>NULL</c> if cwDstLength is set
		/// to 0.
		/// </param>
		/// <param name="cwDstLength">
		/// Length, in characters, of the buffer containing the destination string. Alternatively, the application can set this parameter to 0 to request the
		/// function to return the required size for the destination buffer.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the length of the normalized string in the destination buffer. If cwDstLength is set to 0, the function returns the estimated buffer length
		/// required to do the actual conversion.
		/// </para>
		/// <para>
		/// If the string in the input buffer is null-terminated or if cwSrcLength is -1, the string written to the destination buffer is null-terminated and the
		/// returned string length includes the terminating null character.
		/// </para>
		/// <para>
		/// The function returns a value that is less than or equal to 0 if it does not succeed. To get extended error information, the application can call
		/// <c>GetLastError</c>, which can return one of the following error codes:
		/// </para>
		/// </returns>
		// int NormalizeString( _In_ NORM_FORM NormForm, _In_ LPCWSTR lpSrcString, _In_ int cwSrcLength, _Out_opt_ LPWSTR lpDstString, _In_ int cwDstLength); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319093(v=vs.85).aspx
		[DllImport(Lib.Normaliz, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd319093")]
		public static extern int NormalizeString(NORM_FORM NormForm, string lpSrcString, int cwSrcLength, [Out] StringBuilder lpDstString, int cwDstLength);

		/// <summary>Extracts a primary language identifier from a language identifier.</summary>
		/// <param name="lgid">
		/// Language identifier. This value is a combination of a primary language identifier and a sublanguage identifier and is usually created by using the
		/// <c>MAKELANGID</c> macro.
		/// </param>
		/// <returns>
		/// Returns the primary language identifier. It can be one of the predefined primary language identifiers or a user-defined primary language identifier.
		/// For more information, see <c>MAKELANGID</c>.
		/// </returns>
		// WORD PRIMARYLANGID( WORD lgid); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319102(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "dd319102")]
		public static ushort PRIMARYLANGID(ushort lgid) => (ushort)(lgid & 0x3ff);

		/// <summary>Finds a possible locale name match for the supplied name.</summary>
		/// <param name="lpNameToResolve">Pointer to a name to resolve, for example, "en-FJ" for English (Fiji).</param>
		/// <param name="lpLocaleName">
		/// Pointer to a buffer in which this function retrieves the locale name that is the match for the input name. For example, the match for the name
		/// "en-FJ" is "en-US" for English (United States).
		/// </param>
		/// <param name="cchLocaleName">
		/// Size, in characters, of the buffer indicated by lpLocaleName. The maximum possible length of a locale name, including a terminating null character,
		/// is the value of LOCALE_NAME_MAX_LENGTH. This is the recommended size to supply in this parameter.
		/// </param>
		/// <returns>
		/// <para>Returns the size of the buffer containing the locale name, including the terminating null character, if successful.</para>
		/// <para>
		/// The function returns 0 if it does not succeed. To get extended error information, the application can call <c>GetLastError</c>, which can return one
		/// of the following error codes:
		/// </para>
		/// </returns>
		// int ResolveLocaleName( _In_opt_ LPCWSTR lpNameToResolve, _Out_opt_ LPWSTR lpLocaleName, _In_ int cchLocaleName); https://msdn.microsoft.com/en-us/library/windows/desktop/dd319112(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd319112")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ResolveLocaleName(string lpNameToResolve, [Out] StringBuilder lpLocaleName, int cchLocaleName);

		/// <summary>Sets an item of locale information for a calendar. For more information, see Date and Calendar.</summary>
		/// <param name="Locale">
		/// <para>
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </para>
		/// <para>The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="Calendar"><c>Calendar identifier</c> for the calendar for which to set information.</param>
		/// <param name="CalType">
		/// <para>
		/// Type of calendar information to set. Only the following CALTYPE values are valid for this function. The CAL_USE_CP_ACP constant is only meaningful
		/// for the ANSI version of the function.
		/// </para>
		/// <para>
		/// The application can specify only one calendar identifier per call to this function. An exception can be made if the application uses the binary OR
		/// operator to combine CAL_USE_CP_ACP with any valid CALTYPE value defined in Calendar Type Information.
		/// </para>
		/// </param>
		/// <param name="lpCalData">
		/// Pointer to a null-terminated calendar information string. The information must be in the format of the specified calendar type.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL SetCalendarInfo( _In_ LCID Locale, _In_ CALID Calendar, _In_ CALTYPE CalType, _In_ LPCTSTR lpCalData); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374048(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374048")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCalendarInfo(uint Locale, uint Calendar, CALTYPE CalType, [In] string lpCalData);

		/// <summary>Sets an item of information in the user override portion of the current locale. This function does not set the system defaults.</summary>
		/// <param name="Locale">
		/// <para>
		/// For the ANSI version of the function, the locale identifier of the locale with the code page used when interpreting the lpLCData information. For the
		/// Unicode version, this parameter is ignored.
		/// </para>
		/// <para>You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following predefined values.</para>
		/// <para>The following custom locale identifiers are also supported.</para>
		/// </param>
		/// <param name="LCType">
		/// Type of locale information to set. For valid constants see "Constants Used in the LCType Parameter of GetLocaleInfo, GetLocaleInfoEx, and
		/// SetLocaleInfo" section of Locale Information Constants. The application can specify only one value per call, but it can use the binary OR operator to
		/// combine LOCALE_USE_CP_ACP with any other constant.
		/// </param>
		/// <param name="lpLCData">
		/// Pointer to a null-terminated string containing the locale information to set. The information must be in the format specific to the specified
		/// constant. The application uses a Unicode string for the Unicode version of the function, and an ANSI string for the ANSI version.
		/// </param>
		/// <returns>
		/// Returns a nonzero value if successful, or 0 otherwise. To get extended error information, the application can call <c>GetLastError</c>, which can
		/// return one of the following error codes:
		/// </returns>
		// BOOL SetLocaleInfo( _In_ LCID Locale, _In_ LCTYPE LCType, _In_ LPCTSTR lpLCData); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374049(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374049")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetLocaleInfo(uint Locale, LCTYPE LCType, [In] string lpLCData);

		/// <summary>Sets the process preferred UI languages for the application process. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>
		/// Flags identifying the language format to use for the process preferred UI languages. The flags are mutually exclusive, and the default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>We recommend that you use MUI_LANGUAGE_NAME instead of MUI_LANGUAGE_ID.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>The input parameter language strings are in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>The input parameter language strings are in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>
		/// Pointer to a double null-terminated multi-string buffer that contains an ordered, null-delimited list in decreasing order of preference. If there are
		/// more than five languages in the buffer, the function only sets the first five valid languages.
		/// </para>
		/// <para>
		/// Alternatively, this parameter can contain <c>NULL</c> if no language list is required. In this case, the function clears the preferred UI languages
		/// for the process.
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">
		/// Pointer to the number of languages that has been set in the process language list from the input buffer, up to a maximum of five.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To get extended error information, the application can call <c>GetLastError</c>, which
		/// can return the following error code:
		/// </para>
		/// <para>
		/// If the process preferred UI languages list is empty or if the languages specified for the process are not valid, the function succeeds and sets 0 in
		/// the pulNumLanguages parameter.
		/// </para>
		/// </returns>
		// BOOL SetProcessPreferredUILanguages( _In_ DWORD dwFlags, _In_opt_ PCZZWSTR pwszLanguagesBuffer, _Out_opt_ PULONG pulNumLanguages); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374050(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374050")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, IntPtr pwszLanguagesBuffer, out uint pulNumLanguages);

		/// <summary>Sets the current locale of the calling thread.</summary>
		/// <param name="Locale">
		/// Locale identifier that specifies the locale. You can use the <c>MAKELCID</c> macro to create a locale identifier or use one of the following
		/// predefined values.
		/// </param>
		/// <returns>The function should return an LCID on success. This is the LCID of the previous thread locale.</returns>
		// BOOL SetThreadLocale( _In_ LCID Locale); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374051(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374051")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadLocale(uint Locale);

		/// <summary>Sets the thread preferred UI languages for the current thread. For more information, see User Interface Language Management.</summary>
		/// <param name="dwFlags">
		/// <para>Flags identifying format and filtering for the languages to set.</para>
		/// <para>
		/// The following format flags specify the language format to use for the thread preferred UI languages. The flags are mutually exclusive, and the
		/// default is MUI_LANGUAGE_NAME.
		/// </para>
		/// <para>We recommend that you use MUI_LANGUAGE_NAME instead of MUI_LANGUAGE_ID.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_LANGUAGE_ID</term>
		/// <term>The input parameter language strings are in language identifier format.</term>
		/// </item>
		/// <item>
		/// <term>MUI_LANGUAGE_NAME</term>
		/// <term>The input parameter language strings are in language name format.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// The following filtering flags specify filtering for the language list. The flags are mutually exclusive. By default, neither
		/// MUI_COMPLEX_SCRIPT_FILTER nor MUI_CONSOLE_FILTER is set. For more information about the filtering flags, see the Remarks section.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MUI_COMPLEX_SCRIPT_FILTER</term>
		/// <term>
		/// GetThreadPreferredUILanguages should replace with the appropriate fallback all languages having complex scripts. When this flag is specified, NULL
		/// must be passed for all other parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_CONSOLE_FILTER</term>
		/// <term>
		/// GetThreadPreferredUILanguages should replace with the appropriate fallback all languages that cannot display properly in a console window with the
		/// current operating system settings. When this flag is specified, NULL must be passed for all other parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MUI_RESET_FILTERS</term>
		/// <term>
		/// Reset the filtering for the language list by removing any other filter settings. When this flag is specified, NULL must be passed for all other
		/// parameters. After setting this flag, the application can call GetThreadPreferredUILanguages to retrieve the complete unfiltered list.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pwszLanguagesBuffer">
		/// <para>Pointer to a double null-terminated multi-string buffer that contains an ordered, null-delimited list, in the format specified by dwFlags.</para>
		/// <para>
		/// To clear the thread preferred UI languages list, an application sets this parameter to a null string or an empty double null-terminated string. If an
		/// application clears a language list, it should specify either a format flag or 0 for the dwFlags parameter.
		/// </para>
		/// <para>
		/// When the application specifies one of the filtering flags, it must set this parameter to <c>NULL</c>. In this case, the function succeeds, but does
		/// not reset the thread preferred languages.
		/// </para>
		/// </param>
		/// <param name="pulNumLanguages">
		/// Pointer to the number of languages that the function has set in the thread preferred UI languages list. When the application specifies one of the
		/// filtering flags, the function must set this parameter to <c>NULL</c>.
		/// </param>
		/// <returns>Returns <c>TRUE</c> if the function succeeds or <c>FALSE</c> otherwise.</returns>
		// BOOL SetThreadPreferredUILanguages( _In_ DWORD dwFlags, _In_opt_ PCZZWSTR pwszLanguagesBuffer, _Out_opt_ PULONG pulNumLanguages); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374052(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374052")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadPreferredUILanguages(MUI_LANGUAGE_ENUM dwFlags, IntPtr pwszLanguagesBuffer, out uint pulNumLanguages);

		/// <summary>
		/// <para>Sets the user interface language for the current thread.</para>
		/// <para>
		/// <c>Windows Vista and later:</c> This function cannot clear the thread preferred UI languages list. Your MUI application should call
		/// <c>SetThreadPreferredUILanguages</c> to clear the language list.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> This function is limited to allowing the operating system to identify and set a value that is safe to use on the Windows console.
		/// </para>
		/// </summary>
		/// <param name="LangId">
		/// <para>Language identifier for the user interface language for the thread.</para>
		/// <para>
		/// <c>Windows Vista and later:</c> The application can specify a language identifier of 0 or a nonzero identifier. For more information, see the Remarks section.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The application can only set this parameter to 0. This setting causes the function to select the language that best supports the
		/// console display. For more information, see the Remarks section.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns the input language identifier if successful. If the input identifier is nonzero, the function returns that value. If the language identifier
		/// is 0, the function always succeeds and returns the identifier of the language that best supports the Windows console. See the Remarks section.
		/// </para>
		/// <para>
		/// If the input language identifier is nonzero and the function fails, the return value differs from the input language identifier. To get extended
		/// error information, the application can call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// LANGID SetThreadUILanguage( _In_ LANGID LangId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374053(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374053")]
		public static extern uint SetThreadUILanguage(uint LangId);

		/// <summary>
		/// <para>
		/// [ <c>SetUserGeoID</c> is available for use in the operating systems specified in the Requirements section. It may be altered or unavailable in
		/// subsequent versions. Instead, use <c>SetUserGeoName</c>.]
		/// </para>
		/// <para>Sets the geographical location identifier for the user. This identifier should have one of the values described in Table of Geographical Locations.</para>
		/// </summary>
		/// <param name="GeoId">Identifier for the geographical location of the user.</param>
		/// <returns>
		/// <para>Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise.</para>
		/// <para>
		/// <c>Windows XP, Windows Server 2003</c>: This function does not supply extended error information. Thus it is not appropriate for an application to
		/// call <c>GetLastError</c> after this function. If the application does call <c>GetLastError</c>, it can return a value set by some previously called function.
		/// </para>
		/// <para>If this function does not succeed, the application can call <c>GetLastError</c>, which can return one of the following error codes:</para>
		/// </returns>
		// BOOL SetUserGeoID( _In_ GEOID GeoId); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374055(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374055")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetUserGeoID(int GeoId);

		/// <summary>
		/// Sets the geographic location for the current user to the specified two-letter International Organization for Standardization (ISO) 3166-1 code or
		/// numeric United Nations (UN) Series M, Number 49 (M.49) code.
		/// </summary>
		/// <param name="geoName">
		/// The two-letter ISO 3166-1 or numeric UN M.49 code for the geographic location to set for the current user. To get the codes that are available on the
		/// operating system, call EnumSystemGeoNames.
		/// </param>
		/// <returns>Returns TRUE if successful or FALSE otherwise.</returns>
		// BOOL WINAPI SetUserGeoName(_In_ PWSTR geoName); https://msdn.microsoft.com/en-us/library/windows/desktop/mt812045(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "mt812045")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetUserGeoName(string geoName);

		/// <summary>Extracts a sublanguage identifier from a language identifier.</summary>
		/// <param name="lgid">
		/// Language identifier. You can supply predefined values for this parameter, or create an identifier using the <c>MAKELANGID</c> macro.
		/// </param>
		/// <returns>Returns a sublanguage identifier. This can be a predefined sublanguage identifier or a user-defined sublanguage identifier.</returns>
		// WORD SUBLANGID( WORD lgid); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374066(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "dd374066")]
		public static ushort SUBLANGID(ushort lgid) => (ushort)(lgid >> 10);

		/// <summary>Compares two enumerated lists of scripts.</summary>
		/// <param name="dwFlags">
		/// <para>Flags specifying script verification options.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VS_ALLOW_LATIN</term>
		/// <term>Allow &amp;quot;Latn&amp;quot; (Latin script) in the test list even if it is not in the locale list.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpLocaleScripts">
		/// Pointer to the locale list, the enumerated list of scripts for a given locale. This list is typically populated by calling <c>GetLocaleInfoEx</c>
		/// with LCType set to LOCALE_SSCRIPTS.
		/// </param>
		/// <param name="cchLocaleScripts">
		/// Size, in characters, of the string indicated by lpLocaleScripts. The application sets this parameter to -1 if the string is null-terminated. If this
		/// parameter is set to 0, the function fails.
		/// </param>
		/// <param name="lpTestScripts">Pointer to the test list, a second enumerated list of scripts. This list is typically populated by calling <c>GetStringScripts</c>.</param>
		/// <param name="cchTestScripts">
		/// Size, in characters, of the string indicated by lpTestScripts. The application sets this parameter to -1 if the string is null-terminated. If this
		/// parameter is set to 0, the function fails.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>TRUE</c> if the test list is non-empty and all items in the list are also included in the locale list. The function still returns
		/// <c>TRUE</c> if the locale list contains more scripts than the test list, but all the test list scripts must be contained in the locale list. If
		/// VS_ALLOW_LATIN is specified in dwFlags, the function behaves as if "Latn;" is always in the locale list.
		/// </para>
		/// <para>
		/// In all other cases, the function returns <c>FALSE</c>. This return can indicate that the test list contains an item that is not in the locale list,
		/// or it can indicate an error. To distinguish between these two cases, the application should call <c>GetLastError</c>, which can return one of the
		/// following error codes:
		/// </para>
		/// </returns>
		// BOOL VerifyScripts( _In_ DWORD dwFlags, _In_ LPCWSTR lpLocaleScripts, _In_ int cchLocaleScripts, _In_ LPCWSTR lpTestScripts, _In_ int cchTestScripts); https://msdn.microsoft.com/en-us/library/windows/desktop/dd374129(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Winnls.h", MSDNShortId = "dd374129")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VerifyScripts(VS_FLAGS dwFlags, string lpLocaleScripts, int cchLocaleScripts, string lpTestScripts, int cchTestScripts);

		/// <summary>Contains information about a code page. This structure is used by the <c>GetCPInfo</c> function.</summary>
		// typedef struct _cpinfo { UINT MaxCharSize; BYTE DefaultChar[MAX_DEFAULTCHAR]; BYTE LeadByte[MAX_LEADBYTES];} CPINFO, *LPCPINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/dd317780(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317780")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CPINFO
		{
			/// <summary>
			/// Maximum length, in bytes, of a character in the code page. The length can be 1 for a single-byte character set (SBCS), 2 for a double-byte
			/// character set (DBCS), or a value larger than 2 for other character set types. The function cannot use the size to distinguish an SBCS or a DBCS
			/// from other character sets because of other factors, for example, the use of ISCII or ISO-2022-xx code pages.
			/// </summary>
			public uint MaxCharSize;
			/// <summary>
			/// Default character used when translating character strings to the specific code page. This character is used by the <c>WideCharToMultiByte</c>
			/// function if an explicit default character is not specified. The default is usually the "?" character for the code page.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public byte[] DefaultChar;
			/// <summary>
			/// A fixed-length array of lead byte ranges, for which the number of lead byte ranges is variable. If the code page has no lead bytes, every element
			/// of the array is set to <c>NULL</c>. If the code page has lead bytes, the array specifies a starting value and an ending value for each range.
			/// Ranges are inclusive, and the maximum number of ranges for any code page is five. The array uses two bytes to describe each range, with two null
			/// bytes as a terminator after the last range.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
			public byte[] LeadByte;
		}

		/// <summary>Contains information about a code page. This structure is used by the <c>GetCPInfoEx</c> function.</summary>
		// typedef struct _cpinfoex { UINT MaxCharSize; BYTE DefaultChar[MAX_DEFAULTCHAR]; BYTE LeadByte[MAX_LEADBYTES]; WCHAR UnicodeDefaultChar; UINT CodePage;
		// TCHAR CodePageName[MAX_PATH];} CPINFOEX, *LPCPINFOEX; https://msdn.microsoft.com/en-us/library/windows/desktop/dd317781(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317781")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct CPINFOEX
		{
			/// <summary>
			/// Maximum length, in bytes, of a character in the code page. The length can be 1 for a single-byte character set (SBCS), 2 for a double-byte
			/// character set (DBCS), or a value larger than 2 for other character set types. The function cannot use the size to distinguish an SBCS or a DBCS
			/// from other character sets because of other factors, for example, the use of ISCII or ISO-2022-xx code pages.
			/// </summary>
			public uint MaxCharSize;
			/// <summary>
			/// Default character used when translating character strings to the specific code page. This character is used by the <c>WideCharToMultiByte</c>
			/// function if an explicit default character is not specified. The default is usually the "?" character for the code page.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public byte[] DefaultChar;
			/// <summary>
			/// A fixed-length array of lead byte ranges, for which the number of lead byte ranges is variable. If the code page has no lead bytes, every element
			/// of the array is set to <c>NULL</c>. If the code page has lead bytes, the array specifies a starting value and an ending value for each range.
			/// Ranges are inclusive, and the maximum number of ranges for any code page is five. The array uses two bytes to describe each range, with two null
			/// bytes as a terminator after the last range.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
			public char UnicodeDefaultChar;
			/// <summary>
			/// Code page value. This value reflects the code page passed to the <c>GetCPInfoEx</c> function. See Code Page Identifiers for a list of ANSI and
			/// other code pages.
			/// </summary>
			public uint CodePage;
			/// <summary>
			/// Full name of the code page. Note that this name is localized and is not guaranteed for uniqueness or consistency between operating system
			/// versions or computers.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string CodePageName;
		}

		/// <summary>
		/// Contains information that defines the format of a currency string. The <c>GetCurrencyFormat</c> function uses this information to customize a
		/// currency string for a specified locale.
		/// </summary>
		// typedef struct _currencyfmt { UINT NumDigits; UINT LeadingZero; UINT Grouping; LPTSTR lpDecimalSep; LPTSTR lpThousandSep; UINT NegativeOrder; UINT
		// PositiveOrder; LPTSTR lpCurrencySymbol;} CURRENCYFMT, *LPCURRENCYFMT; https://msdn.microsoft.com/en-us/library/windows/desktop/dd317784(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd317784")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CURRENCYFMT
		{
			/// <summary>Number of fractional digits. This number is equivalent to LOCALE_ICURRDIGITS.</summary>
			public uint NumDigits;
			/// <summary>Value indicating if leading zeros should be used in decimal fields. This value is equivalent to LOCALE_ILZERO.</summary>
			public uint LeadingZero;
			/// <summary>
			/// Number of digits in each group of numbers to the left of the decimal separator specified by <c>lpDecimalSep</c>. The most significant grouping
			/// digit indicates the number of digits in the least significant group immediately to the left of the decimal separator. Each subsequent grouping
			/// digit indicates the next significant group of digits to the left of the previous group. If the last value supplied is not 0, the remaining groups
			/// repeat the last group. Typical examples of settings for this member are: 0 to group digits as in 123456789.00; 3 to group digits as in
			/// 123,456,789.00; and 32 to group digits as in 12,34,56,789.00.
			/// </summary>
			public uint Grouping;
			/// <summary>Pointer to a null-terminated decimal separator string.</summary>
			public string lpDecimalSep;
			/// <summary>Pointer to a null-terminated thousand separator string.</summary>
			public string lpThousandSep;
			/// <summary>Negative currency mode. This mode is equivalent to LOCALE_INEGCURR.</summary>
			public uint NegativeOrder;
			/// <summary>Positive currency mode. This mode is equivalent to LOCALE_ICURRENCY.</summary>
			public uint PositiveOrder;
			/// <summary>Pointer to a null-terminated currency symbol string.</summary>
			public string lpCurrencySymbol;
		}

		/// <summary>
		/// Contains information about a file, related to its use with MUI. Most of this data is stored in the resource configuration data for the particular
		/// file. When this structure is retrieved by <c>GetFileMUIInfo</c>, not all fields are necessarily filled in. The fields used depend on the flags that
		/// the application has passed to that function.
		/// </summary>
		// typedef struct _FILEMUIINFO { DWORD dwSize; DWORD dwVersion; DWORD dwFileType; BYTE pChecksum[16]; BYTE pServiceChecksum[16]; DWORD
		// dwLanguageNameOffset; DWORD dwTypeIDMainSize; DWORD dwTypeIDMainOffset; DWORD dwTypeNameMainOffset; DWORD dwTypeIDMUISize; DWORD dwTypeIDMUIOffset;
		// DWORD dwTypeNameMUIOffset; BYTE abBuffer[8];} FILEMUIINFO, *PFILEMUIINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/dd318039(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd318039")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILEMUIINFO
		{
			/// <summary>Size of the structure, including the buffer, which can be extended past the 8 bytes declared. The minimum value allowed is .</summary>
			public uint dwSize;
			/// <summary>Version of the structure. The current version is 0x001.</summary>
			public uint dwVersion;
			/// <summary>The file type. Possible values are:</summary>
			public uint dwFileType;
			/// <summary>Pointer to a 128-bit checksum for the file, if it is either an LN file or a language-specific resource file.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] pChecksum;
			/// <summary>Pointer to a 128-bit checksum for the file, used for servicing.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] pServiceChecksum;
			/// <summary>
			/// Offset, in bytes, from the beginning of the structure to the language name string for a language-specific resource file, or to the ultimate
			/// fallback language name string for an LN file.
			/// </summary>
			public uint dwLanguageNameOffset;
			/// <summary>
			/// Size of the array for which the offset is indicated by dwTypeIDMainOffset. The size also corresponds to the number of strings in the multi-string
			/// array indicated by dwTypeNameMainOffset.
			/// </summary>
			public uint dwTypeIDMainSize;
			/// <summary>Offset, in bytes, from the beginning of the structure to a DWORD array enumerating the resource types contained in the LN file.</summary>
			public uint dwTypeIDMainOffset;
			/// <summary>
			/// Offset, in bytes, from the beginning of the structure to a series of null-terminated strings in a multi-string array enumerating the resource
			/// names contained in the LN file.
			/// </summary>
			public uint dwTypeNameMainOffset;
			/// <summary>
			/// Size of the array with the offset indicated by dwTypeIDMUIOffset. The size also corresponds to the number of strings in the series of strings
			/// indicated by dwTypeNameMUIOffset.
			/// </summary>
			public uint dwTypeIDMUISize;
			/// <summary>Offset, in bytes, from the beginning of the structure to a DWORD array enumerating the resource types contained in the LN file.</summary>
			public uint dwTypeIDMUIOffset;
			/// <summary>
			/// Offset, in bytes, from the beginning of the structure to a multi-string array enumerating the resource names contained in the LN file.
			/// </summary>
			public uint dwTypeNameMUIOffset;
			/// <summary>Remainder of the allocated memory for this structure. See the Remarks section for correct use of this array.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public byte[] abBuffer;
		}

		/// <summary>
		/// <para>Deprecated. Contains version information about an NLS capability.</para>
		/// <para>Starting with Windows 8, your app should use <c>NLSVERSIONINFOEX</c> instead of <c>NLSVERSIONINFO</c>.</para>
		/// </summary>
		// typedef struct _nlsversioninfo { DWORD dwNLSVersionInfoSize; DWORD dwNLSVersion; DWORD dwDefinedVersion;} NLSVERSIONINFO, *LPNLSVERSIONINFO; https://msdn.microsoft.com/en-us/library/windows/desktop/dd319086(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd319086")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NLSVERSIONINFO
		{
			/// <summary>Size, in bytes, of the structure.</summary>
			public uint dwNLSVersionInfoSize;
			/// <summary>
			/// NLS version. This value is used to track changes and additions to the set of code points that have the indicated capability for a particular
			/// locale. The value is locale-specific, and increments when the capability changes. For example, using the COMPARE_STRING capability defined by the
			/// <c>SYSNLS_FUNCTION</c> enumeration, the version changes if sorting weights are assigned to code points that previously had no weights defined for
			/// the locale.
			/// </summary>
			public uint dwNLSVersion;
			/// <summary>
			/// Defined version. This value is used to track changes in the repertoire of Unicode code points. The value increments when the Unicode repertoire
			/// is extended, for example, if more characters are defined.
			/// </summary>
			public uint dwDefinedVersion;
		}

		/// <summary>Contains version information about an NLS capability.</summary>
		// typedef struct _nlsversioninfoex { DWORD dwNLSVersionInfoSize; DWORD dwNLSVersion; DWORD dwDefinedVersion; DWORD dwEffectiveId; GUID
		// guidCustomVersion;} NLSVERSIONINFOEX, *LPNLSVERSIONINFOEX; https://msdn.microsoft.com/en-us/library/windows/desktop/dd319087(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd319087")]
		public struct NLSVERSIONINFOEX
		{
			/// <summary>
			/// <para>
			/// Defined version. This value is used to track changes in the repertoire of Unicode code points. The value increments when the Unicode repertoire
			/// is extended, for example, if more characters are defined.
			/// </para>
			/// <para><c>Starting with Windows 8:</c> Deprecated. Use <c>dwNLSVersion</c> instead.</para>
			/// </summary>
			public uint dwDefinedVersion;
			/// <summary>
			/// <para>
			/// Identifier of the sort order used for the input locale for the represented version. For example, for a custom locale en-Mine that uses 0409 for a
			/// sort order identifier, this member contains "0409". If this member specifies a "real" sort, <c>guidCustomVersion</c> is set to an empty GUID.
			/// </para>
			/// <para><c>Starting with Windows 8:</c> Deprecated. Use <c>guidCustomVersion</c> instead.</para>
			/// </summary>
			public uint dwEffectiveId;
			/// <summary>
			/// Version. This value is used to track changes and additions to the set of code points that have the indicated capability for a particular locale.
			/// The value is locale-specific, and increments when the capability changes. For example, using the COMPARE_STRING capability defined by the
			/// <c>SYSNLS_FUNCTION</c> enumeration, the version changes if sorting weights are assigned to code points that previously had no weights defined for
			/// the locale.
			/// </summary>
			public uint dwNLSVersion;
			/// <summary>Size, in bytes, of the structure.</summary>
			public uint dwNLSVersionInfoSize;
			/// <summary>Unique GUID for the behavior of a custom sort used by the locale for the represented version.</summary>
			public Guid guidCustomVersion;
		}

		/// <summary>
		/// Contains information that defines the format of a number string. The <c>GetNumberFormat</c> function uses this information to customize a number
		/// string for a specified locale.
		/// </summary>
		// typedef struct _numberfmt { UINT NumDigits; UINT LeadingZero; UINT Grouping; LPTSTR lpDecimalSep; LPTSTR lpThousandSep; UINT NegativeOrder;}
		// NUMBERFMT, *LPNUMBERFMT; https://msdn.microsoft.com/en-us/library/windows/desktop/dd319095(v=vs.85).aspx
		[PInvokeData("Winnls.h", MSDNShortId = "dd319095")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NUMBERFMT
		{
			/// <summary>Number of fractional digits. This value is equivalent to the locale information specified by the value LOCALE_IDIGITS.</summary>
			public uint NumDigits;
			/// <summary>
			/// A value indicating if leading zeros should be used in decimal fields. This value is equivalent to the locale information specified by the value LOCALE_ILZERO.
			/// </summary>
			public uint LeadingZero;
			/// <summary>
			/// Number of digits in each group of numbers to the left of the decimal separator specified by <c>lpDecimalSep</c>. Values in the range 0 through 9
			/// and 32 are valid. The most significant grouping digit indicates the number of digits in the least significant group immediately to the left of
			/// the decimal separator. Each subsequent grouping digit indicates the next significant group of digits to the left of the previous group. If the
			/// last value supplied is not 0, the remaining groups repeat the last group. Typical examples of settings for this member are: 0 to group digits as
			/// in 123456789.00; 3 to group digits as in 123,456,789.00; and 32 to group digits as in 12,34,56,789.00.
			/// </summary>
			public uint Grouping;
			/// <summary>Pointer to a null-terminated decimal separator string.</summary>
			public string lpDecimalSep;
			/// <summary>Pointer to a null-terminated thousand separator string.</summary>
			public string lpThousandSep;
			/// <summary>Negative number mode. This mode is equivalent to the locale information specified by the value LOCALE_INEGNUMBER.</summary>
			public uint NegativeOrder;
		}
	}
}