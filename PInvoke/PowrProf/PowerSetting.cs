namespace Vanara.PInvoke;

public static partial class PowrProf
{
	/// <summary>Function class for effective power mode callback.</summary>
	/// <param name="Mode">Indicates the effective power mode the system is running in</param>
	/// <param name="Context">User-specified opaque context. This context would have been passed in at registration in PowerRegisterForEffectivePowerModeNotifications.</param>
	/// <remarks>
	/// Immediately after registration, this callback will be invoked with the current value of the power setting. If the registration
	/// occurs while the power setting is changing, you may receive multiple callbacks; the last callback is the most recent update.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-effective_power_mode_callback void
	// EFFECTIVE_POWER_MODE_CALLBACK( EFFECTIVE_POWER_MODE Mode, VOID *Context );
	[PInvokeData("powersetting.h", MSDNShortId = "47DD6801-5120-44D3-9EE4-58CCDB4B933A")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void EFFECTIVE_POWER_MODE_CALLBACK(EFFECTIVE_POWER_MODE Mode, IntPtr Context);

	/// <summary>Flags for <see cref="PowerSettingRegisterNotification"/>.</summary>
	[PInvokeData("powersetting.h", MSDNShortId = "0fbca717-2367-4407-8094-3eb2b717b59c")]
	public enum DEVICE_NOTIFY
	{
		/// <summary>
		/// The Recipient parameter is a handle to a service.Use the CreateService or OpenService function to obtain this handle.
		/// </summary>
		DEVICE_NOTIFY_SERVICE_HANDLE = 1,

		/// <summary>The Recipient parameter is a pointer to a callback function to call when the power setting changes.</summary>
		DEVICE_NOTIFY_CALLBACK = 2,
	}

	/// <summary>Indicates the effective power mode the system is running.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/ne-powersetting-effective_power_mode typedef enum
	// EFFECTIVE_POWER_MODE { EffectivePowerModeBatterySaver, EffectivePowerModeBetterBattery, EffectivePowerModeBalanced,
	// EffectivePowerModeHighPerformance, EffectivePowerModeMaxPerformance, EffectivePowerModeInvalid } ;
	[PInvokeData("powersetting.h", MSDNShortId = "8FA09CC0-99E7-4B05-88A0-2AF406C7B60C")]
	public enum EFFECTIVE_POWER_MODE
	{
		/// <summary>The system is in battery saver mode.</summary>
		EffectivePowerModeBatterySaver,

		/// <summary>The system is in the better battery effective power mode.</summary>
		EffectivePowerModeBetterBattery,

		/// <summary>The system is in the balanced effective power mode.</summary>
		EffectivePowerModeBalanced,

		/// <summary>The system is in the high performance effective power mode.</summary>
		EffectivePowerModeHighPerformance,

		/// <summary>The system is in the maximum performance effective power mode.</summary>
		EffectivePowerModeMaxPerformance,

		/// <summary>The system is in an invalid effective power mode due to an internal error.</summary>
		EffectivePowerModeInvalid,
	}

	/// <summary>Retrieves the active power scheme and returns a <c>GUID</c> that identifies the scheme.</summary>
	/// <param name="UserRootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="ActivePolicyGuid">
	/// A pointer that receives a pointer to a <c>GUID</c> structure. Use the LocalFree function to free this memory.
	/// </param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powergetactivescheme DWORD
	// PowerGetActiveScheme( HKEY UserRootPowerKey, GUID **ActivePolicyGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "cd72562c-8987-40c1-89c7-04a95b5f1fd0")]
	public static extern Win32Error PowerGetActiveScheme([Optional] HKEY UserRootPowerKey, out SafeLocalHandle ActivePolicyGuid);

	/// <summary>Retrieves the active power scheme and returns a <c>GUID</c> that identifies the scheme.</summary>
	/// <param name="ActivePolicyGuid">Receives a <c>GUID</c> structure.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powergetactivescheme DWORD
	// PowerGetActiveScheme( HKEY UserRootPowerKey, GUID **ActivePolicyGuid );
	[PInvokeData("powersetting.h", MSDNShortId = "cd72562c-8987-40c1-89c7-04a95b5f1fd0")]
	public static Win32Error PowerGetActiveScheme(out Guid ActivePolicyGuid)
	{
		var err = PowerGetActiveScheme(default, out var h);
		ActivePolicyGuid = err.Succeeded ? h.ToStructure<Guid>() : default;
		return err;
	}

	/// <summary>Retrieves the AC power value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use
	/// <c>NO_SUBGROUP_GUID</c> to retrieve the setting for the default power scheme.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUID fea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup are part of the default power scheme.</term>
	/// </item>
	/// <item>
	/// <term>GUID_DISK_SUBGROUP 0012ee47-9041-4b5d-9b77-535fba8b1442</term>
	/// <term>Settings in this subgroup control power management configuration of the system's hard disk drives.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SYSTEM_BUTTON_SUBGROUP 4f971e89-eebd-4455-a8de-9e59040e7347</term>
	/// <term>Settings in this subgroup control configuration of the system power buttons.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PROCESSOR_SETTINGS_SUBGROUP 54533251-82be-4824-96c1-47b60b740d00</term>
	/// <term>Settings in this subgroup control configuration of processor power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_VIDEO_SUBGROUP 7516b95f-f776-4464-8c53-06167f40cc99</term>
	/// <term>Settings in this subgroup control configuration of the video power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_BATTERY_SUBGROUP e73a048d-bf27-4f12-9731-8b2076e8891f</term>
	/// <term>Settings in this subgroup control battery alarm trip points and actions.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SLEEP_SUBGROUP 238C9FA8-0AAD-41ED-83F4-97BE242C8F20</term>
	/// <term>Settings in this subgroup control system sleep settings.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PCIEXPRESS_SETTINGS_SUBGROUP 501a4d13-42af-4429-9fd1-a8218c268e20</term>
	/// <term>Settings in this subgroup control PCI Express settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PowerSettingGuid">The identifier of the power setting.</param>
	/// <param name="Type">
	/// A pointer to a variable that receives the type of data for the value. The possible values are listed in Registry Value Types.
	/// This parameter can be <c>NULL</c> and the type of data is not returned.
	/// </param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the data value. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size.
	/// </param>
	/// <param name="BufferSize">
	/// <para>A pointer to a variable that contains the size of the buffer pointed to by the Buffer parameter.</para>
	/// <para>
	/// If the Buffer parameter is <c>NULL</c>, the function returns ERROR_SUCCESS and the variable receives the required buffer size.
	/// </para>
	/// <para>
	/// If the specified buffer size is not large enough to hold the requested data, the function returns <c>ERROR_MORE_DATA</c> and the
	/// variable receives the required buffer size.
	/// </para>
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed. If the buffer size
	/// specified by the BufferSize parameter is too small, <c>ERROR_MORE_DATA</c> will be returned and the <c>DWORD</c> pointed to by
	/// the BufferSize parameter will be filled in with the required buffer size.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powerreadacvalue DWORD PowerReadACValue( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PULONG Type, LPBYTE
	// Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "b0afaf75-72cc-48a3-bbf2-0000cb85f2e2")]
	public static extern Win32Error PowerReadACValue([Optional] HKEY RootPowerKey, in Guid SchemeGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out REG_VALUE_TYPE Type, IntPtr Buffer, ref uint BufferSize);

	/// <summary>Retrieves the DC power value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use
	/// <c>NO_SUBGROUP_GUID</c> to retrieve the setting for the default power scheme.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUID fea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup are part of the default power scheme.</term>
	/// </item>
	/// <item>
	/// <term>GUID_DISK_SUBGROUP 0012ee47-9041-4b5d-9b77-535fba8b1442</term>
	/// <term>Settings in this subgroup control power management configuration of the system's hard disk drives.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SYSTEM_BUTTON_SUBGROUP 4f971e89-eebd-4455-a8de-9e59040e7347</term>
	/// <term>Settings in this subgroup control configuration of the system power buttons.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PROCESSOR_SETTINGS_SUBGROUP 54533251-82be-4824-96c1-47b60b740d00</term>
	/// <term>Settings in this subgroup control configuration of processor power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_VIDEO_SUBGROUP 7516b95f-f776-4464-8c53-06167f40cc99</term>
	/// <term>Settings in this subgroup control configuration of the video power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_BATTERY_SUBGROUP e73a048d-bf27-4f12-9731-8b2076e8891f</term>
	/// <term>Settings in this subgroup control battery alarm trip points and actions.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SLEEP_SUBGROUP 238C9FA8-0AAD-41ED-83F4-97BE242C8F20</term>
	/// <term>Settings in this subgroup control system sleep settings.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PCIEXPRESS_SETTINGS_SUBGROUP 501a4d13-42af-4429-9fd1-a8218c268e20</term>
	/// <term>Settings in this subgroup control PCI Express settings.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PowerSettingGuid">The identifier of the power setting.</param>
	/// <param name="Type">
	/// A pointer to a variable that receives the type of data for the value. The possible values are listed in Registry Value Types.
	/// This parameter can be <c>NULL</c> and the type of data is not returned.
	/// </param>
	/// <param name="Buffer">
	/// A pointer to a variable that receives the data value. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size.
	/// </param>
	/// <param name="BufferSize">
	/// <para>A pointer to a variable that contains the size of the buffer pointed to by the Buffer parameter.</para>
	/// <para>
	/// If the Buffer parameter is <c>NULL</c>, the function returns ERROR_SUCCESS and the variable receives the required buffer size.
	/// </para>
	/// <para>
	/// If the specified buffer size is not large enough to hold the requested data, the function returns <c>ERROR_MORE_DATA</c> and the
	/// variable receives the required buffer size.
	/// </para>
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed. If the buffer size
	/// specified by the BufferSize parameter is too small, <c>ERROR_MORE_DATA</c> will be returned and the <c>DWORD</c> pointed to by
	/// the BufferSize parameter will be filled in with the required buffer size.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powerreaddcvalue DWORD PowerReadDCValue( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PULONG Type, PUCHAR
	// Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "c439c478-e882-41bf-a95a-82d36382174b")]
	public static extern Win32Error PowerReadDCValue([Optional] HKEY RootPowerKey, in Guid SchemeGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out REG_VALUE_TYPE Type, IntPtr Buffer, ref uint BufferSize);

	/// <summary>Registers a callback to receive effective power mode change notifications.</summary>
	/// <param name="Version">
	/// <para>
	/// Supplies the maximum effective power mode version the caller understands. If the effective power mode comes from a later
	/// version, it is reduced to a compatible version that is then passed to the callback.
	/// </para>
	/// <para>As of Windows 10, version 1809 the only understood version is EFFECTIVE_POWER_MODE_V1.</para>
	/// </param>
	/// <param name="Callback">
	/// A pointer to the callback to call when the effective power mode changes. This will also be called once upon registration to
	/// supply the current mode. If multiple callbacks are registered using this API, those callbacks can be called concurrently.
	/// </param>
	/// <param name="Context">Caller-specified opaque context.</param>
	/// <param name="RegistrationHandle">A handle to the registration. Use this handle to unregister for notifications.</param>
	/// <returns>Returns S_OK (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// Immediately after registration, the callback will be invoked with the current value of the power setting. If the registration
	/// occurs while the power mode is changing, you may receive multiple callbacks; the last callback is the most recent update.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powerregisterforeffectivepowermodenotifications
	// HRESULT PowerRegisterForEffectivePowerModeNotifications( ULONG Version, EFFECTIVE_POWER_MODE_CALLBACK *Callback, VOID *Context,
	// VOID **RegistrationHandle );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "3C87643F-A8DA-4230-A216-8F46629BB6FB")]
	public static extern HRESULT PowerRegisterForEffectivePowerModeNotifications(uint Version, EFFECTIVE_POWER_MODE_CALLBACK Callback, IntPtr Context, out SafeEffectivePowerModeNotificationHandle RegistrationHandle);

	/// <summary>Sets the active power scheme for the current user.</summary>
	/// <param name="UserRootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powersetactivescheme DWORD
	// PowerSetActiveScheme( HKEY UserRootPowerKey, const GUID *SchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "e56bc3f4-2141-4be7-8479-12f8d59971af")]
	public static extern Win32Error PowerSetActiveScheme([Optional] HKEY UserRootPowerKey, in Guid SchemeGuid);

	/// <summary>Registers to receive notification when a power setting changes.</summary>
	/// <param name="SettingGuid">A GUID that represents the power setting.</param>
	/// <param name="Flags">
	/// <para>Information about the recipient of the notification. This parameter can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICE_NOTIFY_SERVICE_HANDLE</term>
	/// <term>The Recipient parameter is a handle to a service.Use the CreateService or OpenService function to obtain this handle.</term>
	/// </item>
	/// <item>
	/// <term>DEVICE_NOTIFY_CALLBACK</term>
	/// <term>The Recipient parameter is a pointer to a callback function to call when the power setting changes.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Recipient">A handle to the recipient of the notifications.</param>
	/// <param name="RegistrationHandle">A handle to the registration. Use this handle to unregister for notifications.</param>
	/// <returns>Returns ERROR_SUCCESS (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// Immediately after registration, the callback will be invoked with the current value of the power setting. If the registration
	/// occurs while the power setting is changing, you may receive multiple callbacks; the last callback is the most recent update.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powersettingregisternotification DWORD
	// PowerSettingRegisterNotification( LPCGUID SettingGuid, DWORD Flags, HANDLE Recipient, PHPOWERNOTIFY RegistrationHandle );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "0fbca717-2367-4407-8094-3eb2b717b59c")]
	public static extern Win32Error PowerSettingRegisterNotification(in Guid SettingGuid, DEVICE_NOTIFY Flags, in DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS Recipient, out SafeHPOWERNOTIFY RegistrationHandle);

	/// <summary>Cancels a registration to receive notification when a power setting changes.</summary>
	/// <param name="RegistrationHandle">A handle to a registration obtained by calling the PowerSettingRegisterNotification function.</param>
	/// <returns>Returns ERROR_SUCCESS (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powersettingunregisternotification DWORD
	// PowerSettingUnregisterNotification( HPOWERNOTIFY RegistrationHandle );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "9853c347-4528-43bb-8326-13bcd819b8a6")]
	public static extern Win32Error PowerSettingUnregisterNotification(HANDLE RegistrationHandle);

	/// <summary>
	/// Unregisters from effective power mode change notifications. This function is intended to be called from cleanup code and will
	/// wait for all callbacks to complete before unregistering.
	/// </summary>
	/// <param name="RegistrationHandle">
	/// The handle corresponding to a single power mode registration. This handle should have been saved by the caller after the call to
	/// PowerRegisterForEffectivePowerModeNotifications and passed in here.
	/// </param>
	/// <returns>Returns S_OK (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// Immediately after registration, the callback will be invoked with the current value of the power setting. If the registration
	/// occurs while the power setting is changing, you may receive multiple callbacks; the last callback is the most recent update.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powersetting/nf-powersetting-powerunregisterfromeffectivepowermodenotifications
	// HRESULT PowerUnregisterFromEffectivePowerModeNotifications( VOID *RegistrationHandle );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powersetting.h", MSDNShortId = "6E9AB09B-B082-406C-8F2D-43BEA04C19E0")]
	public static extern HRESULT PowerUnregisterFromEffectivePowerModeNotifications(HANDLE RegistrationHandle);

	/// <summary>Sets the AC value index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use
	/// <c>NO_SUBGROUP_GUID</c> to refer to the default power scheme.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUIDfea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup are part of the default power scheme.</term>
	/// </item>
	/// <item>
	/// <term>GUID_DISK_SUBGROUP0012ee47-9041-4b5d-9b77-535fba8b1442</term>
	/// <term>Settings in this subgroup control power management configuration of the system&amp;#39;s hard disk drives.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SYSTEM_BUTTON_SUBGROUP4f971e89-eebd-4455-a8de-9e59040e7347</term>
	/// <term>Settings in this subgroup control configuration of the system power buttons.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PROCESSOR_SETTINGS_SUBGROUP54533251-82be-4824-96c1-47b60b740d00</term>
	/// <term>Settings in this subgroup control configuration of processor power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_VIDEO_SUBGROUP7516b95f-f776-4464-8c53-06167f40cc99</term>
	/// <term>Settings in this subgroup control configuration of the video power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_BATTERY_SUBGROUPe73a048d-bf27-4f12-9731-8b2076e8891f</term>
	/// <term>Settings in this subgroup control battery alarm trip points and actions.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SLEEP_SUBGROUP238C9FA8-0AAD-41ED-83F4-97BE242C8F20</term>
	/// <term>Settings in this subgroup control system sleep settings.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PCIEXPRESS_SETTINGS_SUBGROUP501a4d13-42af-4429-9fd1-a8218c268e20</term>
	/// <term>Settings in this subgroup control PCI Express settings.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="PowerSettingGuid">The identifier of the power setting.</param>
	/// <param name="AcValueIndex">The AC value index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// DWORD WINAPI PowerWriteACValueIndex( _In_opt_ HKEY RootPowerKey, _In_ const GUID *SchemeGuid, _In_opt_ const GUID
	// *SubGroupOfPowerSettingsGuid, _In_opt_ const GUID *PowerSettingGuid, _In_ DWORD AcValueIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372765(v=vs.85).aspx
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Powersetting.h;", MSDNShortId = "aa372765")]
	public static extern Win32Error PowerWriteACValueIndex([In, Optional] HKEY RootPowerKey, in Guid SchemeGuid, [Optional] in Guid SubGroupOfPowerSettingsGuid, [Optional] in Guid PowerSettingGuid, uint AcValueIndex);

	/// <summary>Sets the DC index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use
	/// <c>NO_SUBGROUP_GUID</c> to refer to the default power scheme.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUIDfea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup are part of the default power scheme.</term>
	/// </item>
	/// <item>
	/// <term>GUID_DISK_SUBGROUP0012ee47-9041-4b5d-9b77-535fba8b1442</term>
	/// <term>Settings in this subgroup control power management configuration of the system&amp;#39;s hard disk drives.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SYSTEM_BUTTON_SUBGROUP4f971e89-eebd-4455-a8de-9e59040e7347</term>
	/// <term>Settings in this subgroup control configuration of the system power buttons.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PROCESSOR_SETTINGS_SUBGROUP54533251-82be-4824-96c1-47b60b740d00</term>
	/// <term>Settings in this subgroup control configuration of processor power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_VIDEO_SUBGROUP7516b95f-f776-4464-8c53-06167f40cc99</term>
	/// <term>Settings in this subgroup control configuration of the video power management features.</term>
	/// </item>
	/// <item>
	/// <term>GUID_BATTERY_SUBGROUPe73a048d-bf27-4f12-9731-8b2076e8891f</term>
	/// <term>Settings in this subgroup control battery alarm trip points and actions.</term>
	/// </item>
	/// <item>
	/// <term>GUID_SLEEP_SUBGROUP238C9FA8-0AAD-41ED-83F4-97BE242C8F20</term>
	/// <term>Settings in this subgroup control system sleep settings.</term>
	/// </item>
	/// <item>
	/// <term>GUID_PCIEXPRESS_SETTINGS_SUBGROUP501a4d13-42af-4429-9fd1-a8218c268e20</term>
	/// <term>Settings in this subgroup control PCI Express settings.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="PowerSettingGuid">The identifier of the power setting.</param>
	/// <param name="DcValueIndex">The DC value index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// DWORD WINAPI PowerWriteDCValueIndex( _In_opt_ HKEY RootPowerKey, _In_ const GUID *SchemeGuid, _In_opt_ const GUID
	// *SubGroupOfPowerSettingsGuid, _In_opt_ const GUID *PowerSettingGuid, _In_ DWORD DcValueIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372769(v=vs.85).aspx
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Powersetting.h;", MSDNShortId = "aa372769")]
	public static extern Win32Error PowerWriteDCValueIndex([Optional] HKEY RootPowerKey, in Guid SchemeGuid, [Optional] in Guid SubGroupOfPowerSettingsGuid, [Optional] in Guid PowerSettingGuid, uint DcValueIndex);

	/// <summary>
	/// Provides a <see cref="SafeHandle"/> for <see cref="PowerRegisterForEffectivePowerModeNotifications"/> that is disposed using <see cref="PowerUnregisterFromEffectivePowerModeNotifications"/>.
	/// </summary>
	public class SafeEffectivePowerModeNotificationHandle : SafeHANDLE
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SafeEffectivePowerModeNotificationHandle"/> class and assigns an existing handle.
		/// </summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeEffectivePowerModeNotificationHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeEffectivePowerModeNotificationHandle"/> class.</summary>
		private SafeEffectivePowerModeNotificationHandle() : base() { }

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PowerUnregisterFromEffectivePowerModeNotifications(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for a registered power notification that is disposed using <see cref="PowerSettingUnregisterNotification"/>.</summary>
	public class SafeHPOWERNOTIFY : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHPOWERNOTIFY"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHPOWERNOTIFY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHPOWERNOTIFY"/> class.</summary>
		private SafeHPOWERNOTIFY() : base() { }

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PowerSettingUnregisterNotification(handle).Succeeded;
	}
}