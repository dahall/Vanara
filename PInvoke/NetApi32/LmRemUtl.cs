using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>
	/// A set of bit flags indicating the features of interest in <c>OptionsWanted</c> or features supported <c>OptionsSupported</c> in <see cref="NetRemoteComputerSupports"/>.
	/// </summary>
	[PInvokeData("lmremutl.h", MSDNShortId = "e807489a-250e-4d4c-adb6-eff8ac30603b")]
	[Flags]
	public enum RemoteSupportFlags : uint
	{
		/// <summary>Requests Remote Administration Protocol support.</summary>
		SUPPORTS_REMOTE_ADMIN_PROTOCOL = 0x00000002,

		/// <summary>Requests RPC support.</summary>
		SUPPORTS_RPC = 0x00000004,

		/// <summary>Requests Security Account Manager (SAM) support.</summary>
		SUPPORTS_SAM_PROTOCOL = 0x00000008,

		/// <summary>Requests Unicode standard support.</summary>
		SUPPORTS_UNICODE = 0x00000010,

		/// <summary>
		/// Requests support for the first three values listed in this table. If UNICODE is defined by the calling application, requests
		/// the four features listed previously.
		/// </summary>
		SUPPORTS_LOCAL = 0x00000020,

		/// <summary>Requests all supported options.</summary>
		SUPPORTS_ANY = 0xFFFFFFFF,
	}

	/// <summary>
	/// The <c>NetRemoteComputerSupports</c> function queries the redirector to retrieve the optional features the remote system
	/// supports. Features include Unicode, Remote Procedure Call (RPC), and Remote Administration Protocol support. The function
	/// establishes a network connection if one does not exist.
	/// </summary>
	/// <param name="UncServerName">
	/// Pointer to a constant string that specifies the name of the remote server to query. If this parameter is <c>NULL</c>, the local
	/// computer is used.
	/// </param>
	/// <param name="OptionsWanted">
	/// <para>
	/// Specifies a value that contains a set of bit flags indicating the features of interest. This parameter must be at least one of
	/// the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SUPPORTS_REMOTE_ADMIN_PROTOCOL</term>
	/// <term>Requests Remote Administration Protocol support.</term>
	/// </item>
	/// <item>
	/// <term>SUPPORTS_RPC</term>
	/// <term>Requests RPC support.</term>
	/// </item>
	/// <item>
	/// <term>SUPPORTS_SAM_PROTOCOL</term>
	/// <term>Requests Security Account Manager (SAM) support.</term>
	/// </item>
	/// <item>
	/// <term>SUPPORTS_UNICODE</term>
	/// <term>Requests Unicode standard support.</term>
	/// </item>
	/// <item>
	/// <term>SUPPORTS_LOCAL</term>
	/// <term>
	/// Requests support for the first three values listed in this table. If UNICODE is defined by the calling application, requests the
	/// four features listed previously.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="OptionsSupported">
	/// <para>
	/// Pointer to a value that receives a set of bit flags. The flags indicate which features specified by the OptionsWanted parameter
	/// are implemented on the computer specified by the UncServerName parameter. (All other bits are set to zero.)
	/// </para>
	/// <para>The value of this parameter is valid only when the <c>NetRemoteComputerSupports</c> function returns NERR_Success.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Either the OptionsWanted parameter or the OptionsSupported parameter is NULL; both parameters are required.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>No special group membership is required to successfully execute the <c>NetRemoteComputerSupports</c> function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmremutl/nf-lmremutl-netremotecomputersupports NET_API_STATUS
	// NET_API_FUNCTION NetRemoteComputerSupports( IN LPCWSTR UncServerName, IN DWORD OptionsWanted, OUT LPDWORD OptionsSupported );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmremutl.h", MSDNShortId = "e807489a-250e-4d4c-adb6-eff8ac30603b")]
	public static extern Win32Error NetRemoteComputerSupports([MarshalAs(UnmanagedType.LPWStr), Optional] string? UncServerName, RemoteSupportFlags OptionsWanted, out RemoteSupportFlags OptionsSupported);

	/// <summary>The <c>NetRemoteTOD</c> function returns the time of day information from a specified server.</summary>
	/// <param name="UncServerName">
	/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
	/// this parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="BufferPtr">
	/// Pointer to the address that receives the TIME_OF_DAY_INFO information structure. This buffer is allocated by the system and must
	/// be freed using the NetApiBufferFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the <c>NetRemoteTOD</c> function.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve and print the current date and time with a call to the <c>NetRemoteTOD</c>
	/// function. To do this, the sample uses the TIME_OF_DAY_INFO structure. Finally, the sample frees the memory allocated for the
	/// information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmremutl/nf-lmremutl-netremotetod NET_API_STATUS NET_API_FUNCTION
	// NetRemoteTOD( LPCWSTR UncServerName, LPBYTE *BufferPtr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmremutl.h", MSDNShortId = "5a935e09-f188-4ee1-b998-c67488475baa")]
	public static extern Win32Error NetRemoteTOD([MarshalAs(UnmanagedType.LPWStr), Optional] string? UncServerName, out SafeNetApiBuffer BufferPtr);

	/// <summary>The <c>TIME_OF_DAY_INFO</c> structure contains information about the time of day from a remote server.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmremutl/ns-lmremutl-_time_of_day_info typedef struct _TIME_OF_DAY_INFO {
	// DWORD tod_elapsedt; DWORD tod_msecs; DWORD tod_hours; DWORD tod_mins; DWORD tod_secs; DWORD tod_hunds; LONG tod_timezone; DWORD
	// tod_tinterval; DWORD tod_day; DWORD tod_month; DWORD tod_year; DWORD tod_weekday; } TIME_OF_DAY_INFO, *PTIME_OF_DAY_INFO, *LPTIME_OF_DAY_INFO;
	[PInvokeData("lmremutl.h", MSDNShortId = "bf89f071-5c04-40c2-a7b7-4e59fc9eaa02")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TIME_OF_DAY_INFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of seconds since 00:00:00, January 1, 1970, GMT.</para>
		/// </summary>
		public uint tod_elapsedt;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of milliseconds from an arbitrary starting point (system reset).</para>
		/// <para>
		/// Typically, this member is read twice, once when the process begins and again at the end. To determine the elapsed time
		/// between the process's start and finish, you can subtract the first value from the second.
		/// </para>
		/// </summary>
		public uint tod_msecs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current hour. Valid values are 0 through 23.</para>
		/// </summary>
		public uint tod_hours;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current minute. Valid values are 0 through 59.</para>
		/// </summary>
		public uint tod_mins;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current second. Valid values are 0 through 59.</para>
		/// </summary>
		public uint tod_secs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current hundredth second (0.01 second). Valid values are 0 through 99.</para>
		/// </summary>
		public uint tod_hunds;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The time zone of the server. This value is calculated, in minutes, from Greenwich Mean Time (GMT). For time zones west of
		/// Greenwich, the value is positive; for time zones east of Greenwich, the value is negative. A value of –1 indicates that the
		/// time zone is undefined.
		/// </para>
		/// </summary>
		public int tod_timezone;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The time interval for each tick of the clock. Each integral integer represents one ten-thousandth second (0.0001 second).</para>
		/// </summary>
		public uint tod_tinterval;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The day of the month. Valid values are 1 through 31.</para>
		/// </summary>
		public uint tod_day;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The month of the year. Valid values are 1 through 12.</para>
		/// </summary>
		public uint tod_month;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The year.</para>
		/// </summary>
		public uint tod_year;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The day of the week. Valid values are 0 through 6, where 0 is Sunday, 1 is Monday, and so on.</para>
		/// </summary>
		public uint tod_weekday;
	}
}