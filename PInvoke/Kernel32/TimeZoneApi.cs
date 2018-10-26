using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Time Zone information.</summary>
		public enum TZID : uint
		{
			/// <summary>
			/// Daylight saving time is not used in the current time zone, because there are no transition dates or automatic adjustment for daylight saving time
			/// is disabled.
			/// </summary>
			TIME_ZONE_ID_UNKNOWN = 0,
			/// <summary>The system is operating in the range covered by the StandardDate member of the TIME_ZONE_INFORMATION structure.</summary>
			TIME_ZONE_ID_STANDARD = 1,
			/// <summary>The system is operating in the range covered by the DaylightDate member of the TIME_ZONE_INFORMATION structure.</summary>
			TIME_ZONE_ID_DAYLIGHT = 2,
			/// <summary>The time zone identifier is invalid.</summary>
			TIME_ZONE_ID_INVALID = 0xFFFFFFFF
		}

		/// <summary>
		/// <para>
		/// Enumerates DYNAMIC_TIME_ZONE_INFORMATION entries stored in the registry. This information is used to support time zones that
		/// experience annual boundary changes due to daylight saving time adjustments. Use the information returned by this function when
		/// calling GetDynamicTimeZoneInformationEffectiveYears to retrieve the specific range of years to pass to GetTimeZoneInformationForYear.
		/// </para>
		/// </summary>
		/// <param name="dwIndex">
		/// <para>Index value that represents the location of a DYNAMIC_TIME_ZONE_INFORMATION entry.</para>
		/// </param>
		/// <param name="lpTimeZoneInformation">
		/// <para>Specifies settings for a time zone and dynamic daylight saving time.</para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/timezoneapi/nf-timezoneapi-enumdynamictimezoneinformation
		// DWORD EnumDynamicTimeZoneInformation( const DWORD dwIndex, PDYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("timezoneapi.h", MSDNShortId = "EBB2366A-86FE-4764-B7F9-5D305993CE0A")]
		public static extern uint EnumDynamicTimeZoneInformation(uint dwIndex, out DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation);

		/// <summary>
		/// Enumerates DYNAMIC_TIME_ZONE_INFORMATION entries stored in the registry. This information is used to support time zones that
		/// experience annual boundary changes due to daylight saving time adjustments. Use the information returned by this function when
		/// calling GetDynamicTimeZoneInformationEffectiveYears to retrieve the specific range of years to pass to GetTimeZoneInformationForYear.
		/// </summary>
		/// <returns>An enumeration of settings for a time zone and dynamic daylight saving time.</returns>
		public static IEnumerable<DYNAMIC_TIME_ZONE_INFORMATION> EnumDynamicTimeZoneInformation()
		{
			var i = 0U;
			while (EnumDynamicTimeZoneInformation(i++, out var tz) != 0)
				yield return tz;
		}

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
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FileTimeToSystemTime(in FILETIME lpFileTime, out SYSTEMTIME lpSystemTime);

		/// <summary>
		/// Retrieves the current time zone and dynamic daylight saving time settings. These settings control the translations between Coordinated Universal Time
		/// (UTC) and local time.
		/// </summary>
		/// <param name="pTimeZoneInformation">A pointer to a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> structure.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TIME_ZONE_ID_UNKNOWN0</term>
		/// <term>Daylight saving time is not used in the current time zone, because there are no transition dates.</term>
		/// </item>
		/// <item>
		/// <term>TIME_ZONE_ID_STANDARD1</term>
		/// <term>The system is operating in the range covered by the StandardDate member of the DYNAMIC_TIME_ZONE_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>TIME_ZONE_ID_DAYLIGHT2</term>
		/// <term>The system is operating in the range covered by the DaylightDate member of the DYNAMIC_TIME_ZONE_INFORMATION structure.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>If the function fails, it returns TIME_ZONE_ID_INVALID. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI GetDynamicTimeZoneInformation( _Out_ PDYNAMIC_TIME_ZONE_INFORMATION pTimeZoneInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724318(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724318")]
		public static extern int GetDynamicTimeZoneInformation(out DYNAMIC_TIME_ZONE_INFORMATION pTimeZoneInformation);

		/// <summary>
		/// <para>Retrieves the current time zone settings. These settings control the translations between Coordinated Universal Time (UTC) and local time.</para>
		/// <para>
		/// To support boundaries for daylight saving time that change from year to year, use the <c>GetDynamicTimeZoneInformation</c> or
		/// <c>GetTimeZoneInformationForYear</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpTimeZoneInformation">A pointer to a <c>TIME_ZONE_INFORMATION</c> structure to receive the current settings.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TIME_ZONE_ID_UNKNOWN0</term>
		/// <term>
		/// Daylight saving time is not used in the current time zone, because there are no transition dates or automatic adjustment for daylight saving time is disabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TIME_ZONE_ID_STANDARD1</term>
		/// <term>The system is operating in the range covered by the StandardDate member of the TIME_ZONE_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>TIME_ZONE_ID_DAYLIGHT2</term>
		/// <term>The system is operating in the range covered by the DaylightDate member of the TIME_ZONE_INFORMATION structure.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>
		/// If the function fails for other reasons, such as an out of memory error, it returns TIME_ZONE_ID_INVALID. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// DWORD WINAPI GetTimeZoneInformation( _Out_ LPTIME_ZONE_INFORMATION lpTimeZoneInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724421(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724421")]
		public static extern TZID GetTimeZoneInformation(out TIME_ZONE_INFORMATION lpTimeZoneInformation);

		/// <summary>
		/// Retrieves the time zone settings for the specified year and time zone. These settings control the translations between Coordinated Universal Time
		/// (UTC) and local time.
		/// </summary>
		/// <param name="wYear">The year for which the time zone settings are to be retrieved. The wYear parameter must be a local time value.</param>
		/// <param name="pdtzi">
		/// A pointer to a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> structure that specifies the time zone. To populate this parameter, call
		/// <c>EnumDynamicTimeZoneInformation</c> with the index of the time zone you want. If this parameter is <c>NULL</c>, the current time zone is used.
		/// </param>
		/// <param name="ptzi">A pointer to a <c>TIME_ZONE_INFORMATION</c> structure that receives the time zone settings.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetTimeZoneInformationForYear( _In_ USHORT wYear, _In_opt_ PDYNAMIC_TIME_ZONE_INFORMATION pdtzi, _Out_ LPTIME_ZONE_INFORMATION ptzi); https://msdn.microsoft.com/en-us/library/windows/desktop/bb540851(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "bb540851")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetTimeZoneInformationForYear(ushort wYear, in DYNAMIC_TIME_ZONE_INFORMATION pdtzi, out TIME_ZONE_INFORMATION ptzi);

		/// <summary>
		/// Sets the current time zone and dynamic daylight saving time settings. These settings control translations from Coordinated Universal Time (UTC) to
		/// local time.
		/// </summary>
		/// <param name="lpTimeZoneInformation">A pointer to a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetDynamicTimeZoneInformation( _In_ const DYNAMIC_TIME_ZONE_INFORMATION *lpTimeZoneInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724932(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724932")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDynamicTimeZoneInformation(in DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation);

		/// <summary>
		/// <para>
		/// Sets the current time zone settings. These settings control translations from Coordinated Universal Time (UTC) to local time.
		/// </para>
		/// <para>
		/// To support boundaries for daylight saving time that change from year to year, use the <c>SetDynamicTimeZoneInformation</c> function.
		/// </para>
		/// </summary>
		/// <param name="lpTimeZoneInformation">A pointer to a <c>TIME_ZONE_INFORMATION</c> structure that contains the new settings.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SetTimeZoneInformation( _In_ const TIME_ZONE_INFORMATION *lpTimeZoneInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724944(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724944")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetTimeZoneInformation(in TIME_ZONE_INFORMATION lpTimeZoneInformation);

		/// <summary>Converts a system time to file time format. System time is based on Coordinated Universal Time (UTC).</summary>
		/// <param name="lpSystemTime">
		/// A pointer to a SYSTEMTIME structure that contains the system time to be converted from UTC to file time format. The wDayOfWeek member of the
		/// SYSTEMTIME structure is ignored.
		/// </param>
		/// <param name="lpFileTime">A pointer to a FILETIME structure to receive the converted system time.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true), SuppressUnmanagedCodeSecurity]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724948")]
		public static extern bool SystemTimeToFileTime(in SYSTEMTIME lpSystemTime, out FILETIME lpFileTime);

		/// <summary>Converts a time in Coordinated Universal Time (UTC) to a specified time zone's corresponding local time.</summary>
		/// <param name="lpTimeZone">
		/// <para>A pointer to a <c>TIME_ZONE_INFORMATION</c> structure that specifies the time zone of interest.</para>
		/// <para>If lpTimeZone is <c>NULL</c>, the function uses the currently active time zone.</para>
		/// </param>
		/// <param name="lpUniversalTime">
		/// A pointer to a <c>SYSTEMTIME</c> structure that specifies the UTC time to be converted. The function converts this universal time to the specified
		/// time zone's corresponding local time.
		/// </param>
		/// <param name="lpLocalTime">A pointer to a <c>SYSTEMTIME</c> structure that receives the local time.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero, and the function sets the members of the <c>SYSTEMTIME</c> structure pointed to by lpLocalTime
		/// to the appropriate local time values.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI SystemTimeToTzSpecificLocalTime( _In_opt_ LPTIME_ZONE_INFORMATION lpTimeZone, _In_ LPSYSTEMTIME lpUniversalTime, _Out_ LPSYSTEMTIME lpLocalTime);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724949")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemTimeToTzSpecificLocalTime(in TIME_ZONE_INFORMATION lpTimeZone,
			in SYSTEMTIME lpUniversalTime, [Out] out SYSTEMTIME lpLocalTime);

		/// <summary>
		/// Converts a time in Coordinated Universal Time (UTC) with dynamic daylight saving time settings to a specified time zone's corresponding local time.
		/// </summary>
		/// <param name="lpTimeZoneInformation">
		/// A pointer to a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> structure that specifies the time zone and dynamic daylight saving time.
		/// </param>
		/// <param name="lpUniversalTime">
		/// A pointer to a <c>SYSTEMTIME</c> structure that specifies the UTC time to be converted. The function converts this universal time to the specified
		/// time zone's corresponding local time.
		/// </param>
		/// <param name="lpUniversalTime">A pointer to a <c>SYSTEMTIME</c> structure that receives the local time.</param>
		/// <returns>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI SystemTimeToTzSpecificLocalTimeEx( _In_opt_ const DYNAMIC_TIME_ZONE_INFORMATION* lpTimeZoneInformation, _In_ const SYSTEMTIME*
		// lpUniversalTime, _Out_ LPSYSTEMTIME lpLocalTime ); https://msdn.microsoft.com/en-us/library/windows/desktop/jj206642(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "jj206642")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemTimeToTzSpecificLocalTimeEx(in DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, in SYSTEMTIME lpUniversalTime, out SYSTEMTIME lpLocalTime);

		/// <summary>
		/// <para>Converts a local time to a time in Coordinated Universal Time (UTC).</para>
		/// </summary>
		/// <param name="lpTimeZoneInformation">
		/// <para>A pointer to a <c>TIME_ZONE_INFORMATION</c> structure that specifies the time zone for the time specified in lpLocalTime.</para>
		/// <para>If lpTimeZoneInformation is <c>NULL</c>, the function uses the currently active time zone.</para>
		/// </param>
		/// <param name="lpLocalTime">
		/// <para>
		/// A pointer to a <c>SYSTEMTIME</c> structure that specifies the local time to be converted. The function converts this time to the corresponding UTC time.
		/// </para>
		/// </param>
		/// <param name="lpUniversalTime">
		/// <para>A pointer to a <c>SYSTEMTIME</c> structure that receives the UTC time.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero, and the function sets the members of the <c>SYSTEMTIME</c> structure pointed to by
		/// lpUniversalTime to the appropriate values.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TzSpecificLocalTimeToSystemTime( _In_opt_ LPTIME_ZONE_INFORMATION lpTimeZoneInformation, _In_ LPSYSTEMTIME lpLocalTime, _Out_ LPSYSTEMTIME lpUniversalTime);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725485")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TzSpecificLocalTimeToSystemTime(in TIME_ZONE_INFORMATION lpTimeZoneInformation, in SYSTEMTIME lpLocalTime, [Out] out SYSTEMTIME lpUniversalTime);

		/// <summary>Converts a local time to a time with dynamic daylight saving time settings to Coordinated Universal Time (UTC).</summary>
		/// <param name="lpTimeZoneInformation">
		/// A pointer to a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> structure that specifies the time zone and dynamic daylight saving time.
		/// </param>
		/// <param name="lpLocalTime">
		/// A pointer to a <c>SYSTEMTIME</c> structure that specifies the local time to be converted. The function converts this time to the corresponding UTC time.
		/// </param>
		/// <param name="lpUniversalTime">A pointer to a <c>SYSTEMTIME</c> structure that receives the UTC time.</param>
		/// <returns>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</returns>
		// BOOL WINAPI TzSpecificLocalTimeToSystemTimeEx( _In_opt_ const DYNAMIC_TIME_ZONE_INFORMATION *lpTimeZoneInformation, _In_ const SYSTEMTIME
		// *lpLocalTime, _Out_ LPSYSTEMTIME lpUniversalTime); https://msdn.microsoft.com/en-us/library/windows/desktop/jj206643(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "jj206643")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TzSpecificLocalTimeToSystemTimeEx(in DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, in SYSTEMTIME lpLocalTime, out SYSTEMTIME lpUniversalTime);

		/// <summary>Specifies settings for a time zone and dynamic daylight saving time.</summary>
		// typedef struct _TIME_DYNAMIC_ZONE_INFORMATION { LONG Bias; WCHAR StandardName[32]; SYSTEMTIME StandardDate; LONG StandardBias; WCHAR DaylightName[32];
		// SYSTEMTIME DaylightDate; LONG DaylightBias; WCHAR TimeZoneKeyName[128]; BOOLEAN DynamicDaylightTimeDisabled;} DYNAMIC_TIME_ZONE_INFORMATION,
		// *PDYNAMIC_TIME_ZONE_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724253(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms724253")]
		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
		public struct DYNAMIC_TIME_ZONE_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The current bias for local time translation on this computer, in minutes. The bias is the difference, in minutes, between Coordinated Universal
			/// Time (UTC) and local time. All translations between UTC and local time are based on the following formula:
			/// </para>
			/// <para>UTC = local time + bias</para>
			/// <para>This member is required.</para>
			/// </summary>
			public int Bias;
			/// <summary>
			/// A description for standard time. For example, "EST" could indicate Eastern Standard Time. The string will be returned unchanged by the
			/// <c>GetDynamicTimeZoneInformation</c> function. This string can be empty.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string StandardName;
			/// <summary>
			/// <para>
			/// A <c>SYSTEMTIME</c> structure that contains a date and local time when the transition from daylight saving time to standard time occurs on this
			/// operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the
			/// <c>wMonth</c> member in the <c>SYSTEMTIME</c> structure must be zero. If this date is specified, the <c>DaylightDate</c> member of this structure
			/// must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
			/// </para>
			/// <para>
			/// To select the correct day in the month, set the <c>wYear</c> member to zero, the <c>wHour</c> and <c>wMinute</c> members to the transition time,
			/// the <c>wDayOfWeek</c> member to the appropriate weekday, and the <c>wDay</c> member to indicate the occurrence of the day of the week within the
			/// month (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
			/// </para>
			/// <para>
			/// Using this notation, specify 02:00 on the first Sunday in April as follows: <c>wHour</c> = 2, <c>wMonth</c> = 4, <c>wDayOfWeek</c> = 0,
			/// <c>wDay</c> = 1. Specify 02:00 on the last Thursday in October as follows: <c>wHour</c> = 2, <c>wMonth</c> = 10, <c>wDayOfWeek</c> = 4,
			/// <c>wDay</c> = 5.
			/// </para>
			/// <para>
			/// If the <c>wYear</c> member is not zero, the transition date is absolute; it will only occur one time. Otherwise, it is a relative date that
			/// occurs yearly.
			/// </para>
			/// </summary>
			public SYSTEMTIME StandardDate;
			/// <summary>
			/// <para>
			/// The bias value to be used during local time translations that occur during standard time. This member is ignored if a value for the
			/// <c>StandardDate</c> member is not supplied.
			/// </para>
			/// <para>
			/// This value is added to the value of the <c>Bias</c> member to form the bias used during standard time. In most time zones, the value of this
			/// member is zero.
			/// </para>
			/// </summary>
			public int StandardBias;
			/// <summary>
			/// A description for daylight saving time (DST). For example, "PDT" could indicate Pacific Daylight Time. The string will be returned unchanged by
			/// the <c>GetDynamicTimeZoneInformation</c> function. This string can be empty.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DaylightName;
			/// <summary>
			/// <para>
			/// A <c>SYSTEMTIME</c> structure that contains a date and local time when the transition from standard time to daylight saving time occurs on this
			/// operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the
			/// <c>wMonth</c> member in the <c>SYSTEMTIME</c> structure must be zero. If this date is specified, the <c>StandardDate</c> member in this structure
			/// must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
			/// </para>
			/// <para>
			/// To select the correct day in the month, set the <c>wYear</c> member to zero, the <c>wHour</c> and <c>wMinute</c> members to the transition time,
			/// the <c>wDayOfWeek</c> member to the appropriate weekday, and the <c>wDay</c> member to indicate the occurrence of the day of the week within the
			/// month (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
			/// </para>
			/// <para>
			/// If the <c>wYear</c> member is not zero, the transition date is absolute; it will only occur one time. Otherwise, it is a relative date that
			/// occurs yearly.
			/// </para>
			/// </summary>
			public SYSTEMTIME DaylightDate;
			/// <summary>
			/// <para>
			/// The bias value to be used during local time translations that occur during daylight saving time. This member is ignored if a value for the
			/// <c>DaylightDate</c> member is not supplied.
			/// </para>
			/// <para>
			/// This value is added to the value of the <c>Bias</c> member to form the bias used during daylight saving time. In most time zones, the value of
			/// this member is –60.
			/// </para>
			/// </summary>
			public int DaylightBias;
			/// <summary>The name of the time zone registry key on the local computer. For more information, see Remarks.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string TimeZoneKeyName;
			/// <summary>
			/// <para>
			/// Indicates whether dynamic daylight saving time is disabled. Setting this member to <c>TRUE</c> disables dynamic daylight saving time, causing the
			/// system to use a fixed set of transition dates.
			/// </para>
			/// <para>
			/// To restore dynamic daylight saving time, call the <c>SetDynamicTimeZoneInformation</c> function with <c>DynamicDaylightTimeDisabled</c> set to
			/// <c>FALSE</c>. The system will read the transition dates for the current year at the next time update, the next system reboot, or the end of the
			/// calendar year (whichever comes first.)
			/// </para>
			/// <para>
			/// When calling the <c>GetDynamicTimeZoneInformation</c> function, this member is <c>TRUE</c> if the time zone was set using the
			/// <c>SetTimeZoneInformation</c> function instead of <c>SetDynamicTimeZoneInformation</c> or if the user has disabled this feature using the Date
			/// and Time application in Control Panel.
			/// </para>
			/// <para>
			/// To disable daylight saving time, set this member to <c>TRUE</c>, clear the <c>StandardDate</c> and <c>DaylightDate</c> members, and call
			/// <c>SetDynamicTimeZoneInformation</c>. To restore daylight saving time, call <c>SetDynamicTimeZoneInformation</c> with
			/// <c>DynamicDaylightTimeDisabled</c> set to <c>FALSE</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)]
			public bool DynamicDaylightTimeDisabled;
		}

		/// <summary>
		/// <para>Specifies settings for a time zone.</para>
		/// </summary>
		// typedef struct _TIME_ZONE_INFORMATION { LONG Bias; WCHAR StandardName[32]; SYSTEMTIME StandardDate; LONG StandardBias; WCHAR DaylightName[32];
		// SYSTEMTIME DaylightDate; LONG DaylightBias;} TIME_ZONE_INFORMATION, *PTIME_ZONE_INFORMATION;
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms725481")]
		public struct TIME_ZONE_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The current bias for local time translation on this computer, in minutes. The bias is the difference, in minutes, between Coordinated Universal
			/// Time (UTC) and local time. All translations between UTC and local time are based on the following formula:
			/// </para>
			/// <para>UTC = local time + bias</para>
			/// <para>This member is required.</para>
			/// </summary>
			public int Bias;
			/// <summary>
			/// <para>
			/// A description for standard time. For example, "EST" could indicate Eastern Standard Time. The string will be returned unchanged by the
			/// <c>GetTimeZoneInformation</c> function. This string can be empty.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string StandardName;
			/// <summary>
			/// <para>
			/// A <c>SYSTEMTIME</c> structure that contains a date and local time when the transition from daylight saving time to standard time occurs on this
			/// operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the
			/// <c>wMonth</c> member in the <c>SYSTEMTIME</c> structure must be zero. If this date is specified, the <c>DaylightDate</c> member of this structure
			/// must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
			/// </para>
			/// <para>
			/// To select the correct day in the month, set the <c>wYear</c> member to zero, the <c>wHour</c> and <c>wMinute</c> members to the transition time,
			/// the <c>wDayOfWeek</c> member to the appropriate weekday, and the <c>wDay</c> member to indicate the occurrence of the day of the week within the
			/// month (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
			/// </para>
			/// <para>
			/// Using this notation, specify 02:00 on the first Sunday in April as follows: <c>wHour</c> = 2, <c>wMonth</c> = 4, <c>wDayOfWeek</c> = 0,
			/// <c>wDay</c> = 1. Specify 02:00 on the last Thursday in October as follows: <c>wHour</c> = 2, <c>wMonth</c> = 10, <c>wDayOfWeek</c> = 4,
			/// <c>wDay</c> = 5.
			/// </para>
			/// <para>
			/// If the <c>wYear</c> member is not zero, the transition date is absolute; it will only occur one time. Otherwise, it is a relative date that
			/// occurs yearly.
			/// </para>
			/// </summary>
			public SYSTEMTIME StandardDate;
			/// <summary>
			/// <para>
			/// The bias value to be used during local time translations that occur during standard time. This member is ignored if a value for the
			/// <c>StandardDate</c> member is not supplied.
			/// </para>
			/// <para>
			/// This value is added to the value of the <c>Bias</c> member to form the bias used during standard time. In most time zones, the value of this
			/// member is zero.
			/// </para>
			/// </summary>
			public int StandardBias;
			/// <summary>
			/// <para>
			/// A description for daylight saving time. For example, "PDT" could indicate Pacific Daylight Time. The string will be returned unchanged by the
			/// <c>GetTimeZoneInformation</c> function. This string can be empty.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DaylightName;
			/// <summary>
			/// <para>
			/// A <c>SYSTEMTIME</c> structure that contains a date and local time when the transition from standard time to daylight saving time occurs on this
			/// operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the
			/// <c>wMonth</c> member in the <c>SYSTEMTIME</c> structure must be zero. If this date is specified, the <c>StandardDate</c> member in this structure
			/// must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
			/// </para>
			/// <para>
			/// To select the correct day in the month, set the <c>wYear</c> member to zero, the <c>wHour</c> and <c>wMinute</c> members to the transition time,
			/// the <c>wDayOfWeek</c> member to the appropriate weekday, and the <c>wDay</c> member to indicate the occurrence of the day of the week within the
			/// month (1 to 5, where 5 indicates the final occurrence during the month if that day of the week does not occur 5 times).
			/// </para>
			/// <para>
			/// If the <c>wYear</c> member is not zero, the transition date is absolute; it will only occur one time. Otherwise, it is a relative date that
			/// occurs yearly.
			/// </para>
			/// </summary>
			public SYSTEMTIME DaylightDate;
			/// <summary>
			/// <para>
			/// The bias value to be used during local time translations that occur during daylight saving time. This member is ignored if a value for the
			/// <c>DaylightDate</c> member is not supplied.
			/// </para>
			/// <para>
			/// This value is added to the value of the <c>Bias</c> member to form the bias used during daylight saving time. In most time zones, the value of
			/// this member is –60.
			/// </para>
			/// </summary>
			public int DaylightBias;
		}
	}
}