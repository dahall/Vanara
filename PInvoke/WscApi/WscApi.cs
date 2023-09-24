using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Items from the WscApi.dll.</summary>
public static partial class WscApi
{
	private const string Lib_Wscapi = "wscapi.dll";

	/// <summary>Defines all the services that are monitored by Windows Security Center (WSC).</summary>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// WSC_SECURITY_PROVIDER::WSC_SECURITY_PROVIDER_ANTISPYWARE should be used only in operating systems prior to Windows 10, version 1607.
	/// As of Windows 10, version 1607, WSC continues to track the status for antivirus, but not for anti-spyware.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wscapi/ne-wscapi-wsc_security_provider typedef enum _WSC_SECURITY_PROVIDER {
	// WSC_SECURITY_PROVIDER_FIREWALL = 0x1, WSC_SECURITY_PROVIDER_AUTOUPDATE_SETTINGS = 0x2, WSC_SECURITY_PROVIDER_ANTIVIRUS = 0x4,
	// WSC_SECURITY_PROVIDER_ANTISPYWARE = 0x8, WSC_SECURITY_PROVIDER_INTERNET_SETTINGS = 0x10, WSC_SECURITY_PROVIDER_USER_ACCOUNT_CONTROL =
	// 0x20, WSC_SECURITY_PROVIDER_SERVICE = 0x40, WSC_SECURITY_PROVIDER_NONE = 0, WSC_SECURITY_PROVIDER_ALL } WSC_SECURITY_PROVIDER, *PWSC_SECURITY_PROVIDER;
	[PInvokeData("wscapi.h", MSDNShortId = "NE:wscapi._WSC_SECURITY_PROVIDER")]
	[Flags]
	public enum WSC_SECURITY_PROVIDER
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>None of the items that WSC monitors.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>The aggregation of all firewalls for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_FIREWALL = 0x01,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The automatic update settings for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_AUTOUPDATE_SETTINGS = 0x02,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The aggregation of all antivirus products for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_ANTIVIRUS = 0x04,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// <para>The aggregation of all anti-spyware products for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_ANTISPYWARE = 0x08,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>The settings that restrict the access of web sites in each of the Internet zones for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_INTERNET_SETTINGS = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x20</para>
		/// <para>The User Account Control (UAC) settings for this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_USER_ACCOUNT_CONTROL = 0x20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x40</para>
		/// <para>The running state of the WSC service on this computer.</para>
		/// </summary>
		WSC_SECURITY_PROVIDER_SERVICE = 0x40,

		/// <summary>All of the items that the WSC monitors.</summary>
		WSC_SECURITY_PROVIDER_ALL = WSC_SECURITY_PROVIDER_FIREWALL | WSC_SECURITY_PROVIDER_AUTOUPDATE_SETTINGS | WSC_SECURITY_PROVIDER_ANTIVIRUS | WSC_SECURITY_PROVIDER_INTERNET_SETTINGS | WSC_SECURITY_PROVIDER_USER_ACCOUNT_CONTROL | WSC_SECURITY_PROVIDER_SERVICE,
	}

	/// <summary>Defines the possible states for any service monitored by Windows Security Center (WSC).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wscapi/ne-wscapi-wsc_security_provider_health typedef enum
	// _WSC_SECURITY_PROVIDER_HEALTH { WSC_SECURITY_PROVIDER_HEALTH_GOOD, WSC_SECURITY_PROVIDER_HEALTH_NOTMONITORED,
	// WSC_SECURITY_PROVIDER_HEALTH_POOR, WSC_SECURITY_PROVIDER_HEALTH_SNOOZE } WSC_SECURITY_PROVIDER_HEALTH, *PWSC_SECURITY_PROVIDER_HEALTH;
	[PInvokeData("wscapi.h", MSDNShortId = "NE:wscapi._WSC_SECURITY_PROVIDER_HEALTH")]
	public enum WSC_SECURITY_PROVIDER_HEALTH
	{
		/// <summary>The status of the security provider category is good and does not need user attention.</summary>
		WSC_SECURITY_PROVIDER_HEALTH_GOOD,

		/// <summary>The status of the security provider category is not monitored by WSC.</summary>
		WSC_SECURITY_PROVIDER_HEALTH_NOTMONITORED,

		/// <summary>The status of the security provider category is poor and the computer may be at risk.</summary>
		WSC_SECURITY_PROVIDER_HEALTH_POOR,

		/// <summary>The security provider category is in snooze state. Snooze indicates that WSC is not actively protecting the computer.</summary>
		WSC_SECURITY_PROVIDER_HEALTH_SNOOZE,
	}

	/// <summary>
	/// Gets the aggregate health state of the security provider categories represented by the specified WSC_SECURITY_PROVIDER enumeration values.
	/// </summary>
	/// <param name="Providers">
	/// One or more of the values in the WSC_SECURITY_PROVIDER enumeration. To specify more than one value, combine the individual values by
	/// performing a bitwise OR operation.
	/// </param>
	/// <param name="pHealth">
	/// A pointer to a variable that takes the value of one of the members of the WSC_SECURITY_PROVIDER_HEALTH enumeration. If more than one
	/// provider is specified in the <c>Providers</c> parameter, the value of this parameter is the health of the least healthy of the
	/// specified provider categories.
	/// </param>
	/// <returns>
	/// Returns <c>S_OK</c> if the function succeeds, otherwise returns an error code. If the WSC service is not running, the return value is
	/// always <c>S_FALSE</c> and the <c>pHealth</c> out parameter is always set to <c>WSC_SECURITY_PROVIDER_HEALTH_POOR</c>.
	/// </returns>
	/// <remarks>
	/// <para>Note</para>
	/// <para>
	/// WSC_SECURITY_PROVIDER::WSC_SECURITY_PROVIDER_ANTISPYWARE should be used only in operating systems prior to Windows 10, version 1607.
	/// As of Windows 10, version 1607, WSC continues to track the status for antivirus, but not for anti-spyware.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wscapi/nf-wscapi-wscgetsecurityproviderhealth HRESULT
	// WscGetSecurityProviderHealth( [in] DWORD Providers, [out] PWSC_SECURITY_PROVIDER_HEALTH pHealth );
	[PInvokeData("wscapi.h", MSDNShortId = "NF:wscapi.WscGetSecurityProviderHealth")]
	[DllImport(Lib_Wscapi, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WscGetSecurityProviderHealth(WSC_SECURITY_PROVIDER Providers, out WSC_SECURITY_PROVIDER_HEALTH pHealth);

	/// <summary>
	/// Registers a callback function to be run when Windows Security Center (WSC) detects a change that could affect the health of one of
	/// the security providers.
	/// </summary>
	/// <param name="Reserved">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="phCallbackRegistration">
	/// A pointer to a handle to the callback registration. When you are finished using the callback function, unregister it by calling the
	/// WscUnRegisterChanges function.
	/// </param>
	/// <param name="lpCallbackAddress">
	/// A pointer to the application-defined function to be called when a change to the WSC service occurs. This function is also called when
	/// the WSC service is started or stopped.
	/// </param>
	/// <param name="pContext">
	/// A pointer to a variable to be passed as the <c>lpParameter</c> parameter to the function pointed to by the <c>lpCallbackAddress</c> parameter.
	/// </param>
	/// <returns>Returns S_OK if the function succeeds, otherwise returns an error code.</returns>
	/// <remarks>
	/// When you want to cease receiving notification to your callback method, you can unregister it by calling the WscUnRegisterChanges function.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wscapi/nf-wscapi-wscregisterforchanges HRESULT WscRegisterForChanges( [in] LPVOID
	// Reserved, [out] PHANDLE phCallbackRegistration, [in] LPTHREAD_START_ROUTINE lpCallbackAddress, [in] PVOID pContext );
	[PInvokeData("wscapi.h", MSDNShortId = "NF:wscapi.WscRegisterForChanges")]
	[DllImport(Lib_Wscapi, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WscRegisterForChanges([In, Optional] IntPtr Reserved, out HANDLE phCallbackRegistration,
		[In] ThreadProc lpCallbackAddress, [In, Optional] IntPtr pContext);

	/// <summary>Cancels a callback registration that was made by a call to the WscRegisterForChanges function.</summary>
	/// <param name="hRegistrationHandle">
	/// The handle to the registration context returned as the <c>phCallbackRegistration</c> of the WscRegisterForChanges function.
	/// </param>
	/// <returns>Returns <c>S_OK</c> if the function succeeds, otherwise returns an error code.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wscapi/nf-wscapi-wscunregisterchanges HRESULT WscUnRegisterChanges( [in] HANDLE
	// hRegistrationHandle );
	[PInvokeData("wscapi.h", MSDNShortId = "NF:wscapi.WscUnRegisterChanges")]
	[DllImport(Lib_Wscapi, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT WscUnRegisterChanges([In] HANDLE hRegistrationHandle);
}