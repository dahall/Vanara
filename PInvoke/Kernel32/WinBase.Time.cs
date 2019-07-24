using System.Runtime.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Converts MS-DOS date and time values to a file time.</summary>
		/// <param name="wFatDate">
		/// <para>The MS-DOS date. The date is a packed value with the following format.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0-4</term>
		/// <term>Day of the month (1–31)</term>
		/// </item>
		/// <item>
		/// <term>5-8</term>
		/// <term>Month (1 = January, 2 = February, and so on)</term>
		/// </item>
		/// <item>
		/// <term>9-15</term>
		/// <term>Year offset from 1980 (add 1980 to get actual year)</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="wFatTime">
		/// <para>The MS-DOS time. The time is a packed value with the following format.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0-4</term>
		/// <term>Second divided by 2</term>
		/// </item>
		/// <item>
		/// <term>5-10</term>
		/// <term>Minute (0–59)</term>
		/// </item>
		/// <item>
		/// <term>11-15</term>
		/// <term>Hour (0–23 on a 24-hour clock)</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpFileTime">A pointer to a <c>FILETIME</c> structure that receives the converted file time.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DosDateTimeToFileTime( _In_ WORD wFatDate, _In_ WORD wFatTime, _Out_ LPFILETIME lpFileTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724247(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724247")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DosDateTimeToFileTime(ushort wFatDate, ushort wFatTime, out FILETIME lpFileTime);

		/// <summary>Converts a file time to MS-DOS date and time values.</summary>
		/// <param name="lpFileTime">A pointer to a <c>FILETIME</c> structure containing the file time to convert to MS-DOS date and time format.</param>
		/// <param name="lpFatDate">
		/// <para>A pointer to a variable to receive the MS-DOS date. The date is a packed value with the following format.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0–4</term>
		/// <term>Day of the month (1–31)</term>
		/// </item>
		/// <item>
		/// <term>5–8</term>
		/// <term>Month (1 = January, 2 = February, etc.)</term>
		/// </item>
		/// <item>
		/// <term>9-15</term>
		/// <term>Year offset from 1980 (add 1980 to get actual year)</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpFatTime">
		/// <para>A pointer to a variable to receive the MS-DOS time. The time is a packed value with the following format.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0–4</term>
		/// <term>Second divided by 2</term>
		/// </item>
		/// <item>
		/// <term>5–10</term>
		/// <term>Minute (0–59)</term>
		/// </item>
		/// <item>
		/// <term>11–15</term>
		/// <term>Hour (0–23 on a 24-hour clock)</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI FileTimeToDosDateTime( _In_ const FILETIME *lpFileTime, _Out_ LPWORD lpFatDate, _Out_ LPWORD lpFatTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724274(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ms724274")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FileTimeToDosDateTime(in FILETIME lpFileTime, out ushort lpFatDate, out ushort lpFatTime);

		/// <summary>
		/// Gets a range, expressed in years, for which a <c>DYNAMIC_TIME_ZONE_INFORMATION</c> has valid entries. Use the returned value to
		/// identify the specific years to request when calling <c>GetTimeZoneInformationForYear</c> to retrieve time zone information for a
		/// time zone that experiences annual boundary changes due to daylight saving time adjustments.
		/// </summary>
		/// <param name="lpTimeZoneInformation">Specifies settings for a time zone and dynamic daylight saving time.</param>
		/// <param name="FirstYear">The year that marks the beginning of the range to pass to <c>GetTimeZoneInformationForYear</c>.</param>
		/// <param name="LastYear">The year that marks the end of the range to pass to <c>GetTimeZoneInformationForYear</c>.</param>
		/// <returns>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The system cannot find the effective years.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameter values is not valid.</term>
		/// </item>
		/// <item>
		/// <term>Any other value</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// DWORD WINAPI GetDynamicTimeZoneInformationEffectiveYears( _In_ const PDYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, _Out_
		// LPDWORD FirstYear, _Out_ LPDWORD LastYear); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706894(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "hh706894")]
		public static extern Win32Error GetDynamicTimeZoneInformationEffectiveYears(in DYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation, out uint FirstYear, out uint LastYear);
	}
}