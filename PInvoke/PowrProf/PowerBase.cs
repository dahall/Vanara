using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class PowrProf
	{
		/// <summary>Indicates power level information.</summary>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-power_information_level typedef enum {
		// SystemPowerPolicyAc, SystemPowerPolicyDc, VerifySystemPolicyAc, VerifySystemPolicyDc, SystemPowerCapabilities, SystemBatteryState,
		// SystemPowerStateHandler, ProcessorStateHandler, SystemPowerPolicyCurrent, AdministratorPowerPolicy, SystemReserveHiberFile,
		// ProcessorInformation, SystemPowerInformation, ProcessorStateHandler2, LastWakeTime, LastSleepTime, SystemExecutionState,
		// SystemPowerStateNotifyHandler, ProcessorPowerPolicyAc, ProcessorPowerPolicyDc, VerifyProcessorPowerPolicyAc,
		// VerifyProcessorPowerPolicyDc, ProcessorPowerPolicyCurrent, SystemPowerStateLogging, SystemPowerLoggingEntry, SetPowerSettingValue,
		// NotifyUserPowerSetting, PowerInformationLevelUnused0, SystemMonitorHiberBootPowerOff, SystemVideoState,
		// TraceApplicationPowerMessage, TraceApplicationPowerMessageEnd, ProcessorPerfStates, ProcessorIdleStates, ProcessorCap,
		// SystemWakeSource, SystemHiberFileInformation, TraceServicePowerMessage, ProcessorLoad, PowerShutdownNotification,
		// MonitorCapabilities, SessionPowerInit, SessionDisplayState, PowerRequestCreate, PowerRequestAction, GetPowerRequestList,
		// ProcessorInformationEx, NotifyUserModeLegacyPowerEvent, GroupPark, ProcessorIdleDomains, WakeTimerList, SystemHiberFileSize,
		// ProcessorIdleStatesHv, ProcessorPerfStatesHv, ProcessorPerfCapHv, ProcessorSetIdle, LogicalProcessorIdling, UserPresence,
		// PowerSettingNotificationName, GetPowerSettingValue, IdleResiliency, SessionRITState, SessionConnectNotification,
		// SessionPowerCleanup, SessionLockState, SystemHiberbootState, PlatformInformation, PdcInvocation, MonitorInvocation,
		// FirmwareTableInformationRegistered, SetShutdownSelectedTime, SuspendResumeInvocation, PlmPowerRequestCreate, ScreenOff,
		// CsDeviceNotification, PlatformRole, LastResumePerformance, DisplayBurst, ExitLatencySamplingPercentage, RegisterSpmPowerSettings,
		// PlatformIdleStates, ProcessorIdleVeto, PlatformIdleVeto, SystemBatteryStatePrecise, ThermalEvent, PowerRequestActionInternal,
		// BatteryDeviceState, PowerInformationInternal, ThermalStandby, SystemHiberFileType, PhysicalPowerButtonPress,
		// QueryPotentialDripsConstraint, EnergyTrackerCreate, EnergyTrackerQuery, UpdateBlackBoxRecorder, PowerInformationLevelMaximum } POWER_INFORMATION_LEVEL;
		[PInvokeData("wdm.h", MSDNShortId = "DCAB0482-C0E3-4F75-B5A7-FB8DFFA89D6F")]
		public enum POWER_INFORMATION_LEVEL
		{
			/// <summary>Indicates SystemPowerPolicyAc.</summary>
			SystemPowerPolicyAc,

			/// <summary>Indicates SystemPowerPolicyDc.</summary>
			SystemPowerPolicyDc,

			/// <summary>Indicates VerifySystemPolicyAc.</summary>
			VerifySystemPolicyAc,

			/// <summary>Indicates VerifySystemPolicyDc.</summary>
			VerifySystemPolicyDc,

			/// <summary>Indicates the power capabilities of the system.</summary>
			SystemPowerCapabilities,

			/// <summary>Indicates the system's battery state.</summary>
			SystemBatteryState,

			/// <summary>Indicates the system's power state handler.</summary>
			SystemPowerStateHandler,

			/// <summary>Indicates the processor state handler.</summary>
			ProcessorStateHandler,

			/// <summary>Indicates the system's current power policy.</summary>
			SystemPowerPolicyCurrent,

			/// <summary>Indicates the administrator's power policy.</summary>
			AdministratorPowerPolicy,

			/// <summary>Indicates the SystemReserveHiberFile.</summary>
			SystemReserveHiberFile,

			/// <summary>Indicates the processor information.</summary>
			ProcessorInformation,

			/// <summary>Indicates the system power information.</summary>
			SystemPowerInformation,

			/// <summary>Indicates the processor state handler.</summary>
			ProcessorStateHandler2,

			/// <summary>Indicates the last wake time.</summary>
			LastWakeTime,

			/// <summary>Indicates the last sleep time.</summary>
			LastSleepTime,

			/// <summary>Indicates the system execution state.</summary>
			SystemExecutionState,

			/// <summary>Indicates the system power state notify handler.</summary>
			SystemPowerStateNotifyHandler,

			/// <summary>Indicates ProcessorPowerPolicyAc.</summary>
			ProcessorPowerPolicyAc,

			/// <summary>Indicates ProcessorPowerPolicyDc.</summary>
			ProcessorPowerPolicyDc,

			/// <summary>Indicates VerifyProcessorPowerPolicyAc.</summary>
			VerifyProcessorPowerPolicyAc,

			/// <summary>Indicates VerifyProcessorPowerPolicyDc.</summary>
			VerifyProcessorPowerPolicyDc,

			/// <summary>Indicates the current processor power policy.</summary>
			ProcessorPowerPolicyCurrent,

			/// <summary>Indicates SystemPowerStateLogging.</summary>
			SystemPowerStateLogging,

			/// <summary>Indicates SystemPowerLoggingEntry.</summary>
			SystemPowerLoggingEntry,

			/// <summary>Indicates that the power setting value is set.</summary>
			SetPowerSettingValue,

			/// <summary>Indicates that the user should be notified of the power setting.</summary>
			NotifyUserPowerSetting,

			/// <summary>Indicates that the power information level is unused.</summary>
			PowerInformationLevelUnused0,

			/// <summary>Indicates that the system monitor boot power is off.</summary>
			SystemMonitorHiberBootPowerOff,

			/// <summary>Indicates the system video state.</summary>
			SystemVideoState,

			/// <summary>Indicates the trace application power message.</summary>
			TraceApplicationPowerMessage,

			/// <summary>Indicates the end of the trace application power message.</summary>
			TraceApplicationPowerMessageEnd,

			/// <summary>Indicates the processor performance states.</summary>
			ProcessorPerfStates,

			/// <summary>Indicates the processor idle states.</summary>
			ProcessorIdleStates,

			/// <summary>Indicates the processor cap.</summary>
			ProcessorCap,

			/// <summary>Indicates the system wake source.</summary>
			SystemWakeSource,

			/// <summary>Indicates the system's hibernation file information.</summary>
			SystemHiberFileInformation,

			/// <summary>Indicates the trace service power message.</summary>
			TraceServicePowerMessage,

			/// <summary>Indicates the processor load.</summary>
			ProcessorLoad,

			/// <summary>Indicates the power shutdown notification.</summary>
			PowerShutdownNotification,

			/// <summary>Indicates the monitor's capabilities.</summary>
			MonitorCapabilities,

			/// <summary>Indicates the session power has been initialized.</summary>
			SessionPowerInit,

			/// <summary>Indicates the session display state.</summary>
			SessionDisplayState,

			/// <summary>Indicates that a power request has been created.</summary>
			PowerRequestCreate,

			/// <summary>Indicates the action of the power request.</summary>
			PowerRequestAction,

			/// <summary>Indicates that the power request list should be queued.</summary>
			GetPowerRequestList,

			/// <summary>Indicates ProcessorInformationEx.</summary>
			ProcessorInformationEx,

			/// <summary>Indicates that a notification should be created for the user mode legacy power event.</summary>
			NotifyUserModeLegacyPowerEvent,

			/// <summary>Indicates the group park.</summary>
			GroupPark,

			/// <summary>Indicates the processor's idle domains.</summary>
			ProcessorIdleDomains,

			/// <summary>Indicates the wake timer list.</summary>
			WakeTimerList,

			/// <summary>Indicates the system's hibernation file size.</summary>
			SystemHiberFileSize,

			/// <summary>Indicates the processor's idle states.</summary>
			ProcessorIdleStatesHv,

			/// <summary>Indicates the processor's performance states.</summary>
			ProcessorPerfStatesHv,

			/// <summary>Indicates the processor's performance capabilities.</summary>
			ProcessorPerfCapHv,

			/// <summary>Indicates that the processor has been set to idle.</summary>
			ProcessorSetIdle,

			/// <summary>Indicates that the processor is idling.</summary>
			LogicalProcessorIdling,

			/// <summary>Indicates the user presence.</summary>
			UserPresence,

			/// <summary>Indicates the power setting notification name.</summary>
			PowerSettingNotificationName,

			/// <summary>Indicates that the power setting value should be queued.</summary>
			GetPowerSettingValue,

			/// <summary>Indicates the idle resiliency.</summary>
			IdleResiliency,

			/// <summary>Indicates the session's RIT state.</summary>
			SessionRITState,

			/// <summary>Indicates the session's connect notification.</summary>
			SessionConnectNotification,

			/// <summary>Indicates the session's power cleanup.</summary>
			SessionPowerCleanup,

			/// <summary>Indicates the session's lock state.</summary>
			SessionLockState,

			/// <summary>Indicates the system's hibernation boot state.</summary>
			SystemHiberbootState,

			/// <summary>Indicates the platform information.</summary>
			PlatformInformation,

			/// <summary>Indicates the pdc invocation.</summary>
			PdcInvocation,

			/// <summary>Indicates the monitor invocation.</summary>
			MonitorInvocation,

			/// <summary>Indicates the registered firmware table information.</summary>
			FirmwareTableInformationRegistered,

			/// <summary>Indicates that the shutdown time should be set.</summary>
			SetShutdownSelectedTime,

			/// <summary>Indicates SuspendResumeInvocation.</summary>
			SuspendResumeInvocation,

			/// <summary>Indicates that the power request has been created.</summary>
			PlmPowerRequestCreate,

			/// <summary>Indicates that the screen is off.</summary>
			ScreenOff,

			/// <summary>Indicates the device notification.</summary>
			CsDeviceNotification,

			/// <summary>Indicates the platform role.</summary>
			PlatformRole,

			/// <summary>Indicates the last time performance was resumed.</summary>
			LastResumePerformance,

			/// <summary>Indicates display burst.</summary>
			DisplayBurst,

			/// <summary>Indicates the latency sampling percentage.</summary>
			ExitLatencySamplingPercentage,

			/// <summary>Indicates that the power settings are registered.</summary>
			RegisterSpmPowerSettings,

			/// <summary>Indicates the platform's idle states.</summary>
			PlatformIdleStates,

			/// <summary>Indicates the processor's idle veto.</summary>
			ProcessorIdleVeto,

			/// <summary>Indicates the platform's idle veto.</summary>
			PlatformIdleVeto,

			/// <summary>Indicates the system's battery state.</summary>
			SystemBatteryStatePrecise,

			/// <summary>Indicates the thermal event.</summary>
			ThermalEvent,

			/// <summary>Indicates the internal power request action.</summary>
			PowerRequestActionInternal,

			/// <summary>Indicates the battery's device state.</summary>
			BatteryDeviceState,

			/// <summary>Indicates the internal power information.</summary>
			PowerInformationInternal,

			/// <summary>Indicates thermal standby.</summary>
			ThermalStandby,

			/// <summary>Indicates the system's hibernation file type.</summary>
			SystemHiberFileType,

			/// <summary>Indicates a physical power button press.</summary>
			PhysicalPowerButtonPress,

			/// <summary>Indicates the potential drips constraint.</summary>
			QueryPotentialDripsConstraint,

			/// <summary>Indicates that the energy tracker is created.</summary>
			EnergyTrackerCreate,

			/// <summary>Indicates that the energy tracker is queried.</summary>
			EnergyTrackerQuery,

			/// <summary>Indicates that the black box recorder is updated.</summary>
			UpdateBlackBoxRecorder,

			/// <summary>Indicates the maximum power level.</summary>
			PowerInformationLevelMaximum,
		}

		/// <summary>
		/// The version of the POWER_PLATFORM_ROLE enumeration for the platform used by <see cref="PowerDeterminePlatformRoleEx"/>.
		/// </summary>
		[PInvokeData("powerbase.h", MSDNShortId = "64b597d3-ca7a-4ff7-8527-72c3625147cd")]
		public enum PowerPlatformRoleVersion
		{
			/// <summary>The version of the POWER_PLATFORM_ROLE enumeration for Windows 7, Windows Server 2008 R2, Windows Vista or Windows Server 2008.
			/// <para>Calling PowerDeterminePlatformRoleEx with this value returns the same result as calling PowerDeterminePlatformRole on Windows 7, Windows Server 2008 R2, Windows Vista or Windows Server 2008.</para></summary>
			POWER_PLATFORM_ROLE_V1 = 1,

			/// <summary>The version of the POWER_PLATFORM_ROLE enumeration for Windows 8 and Windows Server 2012.</summary>
			POWER_PLATFORM_ROLE_V2 = 2
		}

		/// <summary>Flags for <see cref="PowerRegisterSuspendResumeNotification"/>.</summary>
		[PInvokeData("powerbase.h", MSDNShortId = "3b39ec3a-417c-4ce4-a581-ed967f1baec9")]
		public enum RegisterSuspendResumeNotificationFlags
		{
			/// <summary>The Recipient parameter is a pointer to a callback function to call when the power setting changes.</summary>
			DEVICE_NOTIFY_CALLBACK = 2
		}

		/// <summary>Sets or retrieves power information.</summary>
		/// <param name="InformationLevel">
		/// <para>
		/// The information level requested. This value indicates the specific power information to be set or retrieved. This parameter must
		/// be one of the following <c>POWER_INFORMATION_LEVEL</c> enumeration type values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AdministratorPowerPolicy 9</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>LastSleepTime 15</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a ULONGLONG that specifies the interrupt-time count, in 100-nanosecond units, at the last system sleep time.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LastWakeTime 14</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a ULONGLONG that specifies the interrupt-time count, in 100-nanosecond units, at the last system wake time.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessorInformation 11</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer receives
		/// one PROCESSOR_POWER_INFORMATION structure for each processor that is installed on the system. Use the GetSystemInfo function to
		/// retrieve the number of processors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ProcessorPowerPolicyAc 18</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>ProcessorPowerPolicyCurrent 22</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>ProcessorPowerPolicyDc 19</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SystemBatteryState 5</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a SYSTEM_BATTERY_STATE structure containing information about the current system battery.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemExecutionState 16</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer receives
		/// a ULONG value containing the system execution state buffer. This value may contain any combination of the following values:
		/// ES_SYSTEM_REQUIRED, ES_DISPLAY_REQUIRED, or ES_USER_PRESENT. For more information, see the SetThreadExecutionState function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemPowerCapabilities 4</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL, otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a SYSTEM_POWER_CAPABILITIES structure containing the current system power capabilities. This information represents the
		/// currently supported power capabilities. It may change as drivers are installed in the system. For example, installation of legacy
		/// device drivers that do not support power management disables all system sleep states.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemPowerInformation 12</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a SYSTEM_POWER_INFORMATION structure. Applications can use this level to retrieve information about the idleness of the system.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemPowerPolicyAc 0</term>
		/// <term>
		/// If lpInBuffer is not NULL, the function applies the SYSTEM_POWER_POLICY values passed in lpInBuffer to the current system power
		/// policy used while the system is running on AC (utility) power. The lpOutputBuffer buffer receives a SYSTEM_POWER_POLICY structure
		/// containing the current system power policy used while the system is running on AC (utility) power.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemPowerPolicyCurrent 8</term>
		/// <term>
		/// The lpInBuffer parameter must be NULL; otherwise, the function returns ERROR_INVALID_PARAMETER. The lpOutputBuffer buffer
		/// receives a SYSTEM_POWER_POLICY structure containing the current system power policy used while the system is running on AC
		/// (utility) power.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemPowerPolicyDc 1</term>
		/// <term>
		/// If lpInBuffer is not NULL, the function applies the SYSTEM_POWER_POLICY values passed in lpInBuffer to the current system power
		/// policy used while the system is running on battery power. The lpOutputBuffer buffer receives a SYSTEM_POWER_POLICY structure
		/// containing the current system power policy used while the system is running on battery power.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SystemReserveHiberFile 10</term>
		/// <term>
		/// If lpInBuffer is not NULL and the current user has sufficient privileges, the function commits or decommits the storage required
		/// to hold the hibernation image on the boot volume. The lpInBuffer parameter must point to a BOOLEAN value indicating the desired
		/// request. If the value is TRUE, the hibernation file is reserved; if the value is FALSE, the hibernation file is removed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VerifyProcessorPowerPolicyAc 20</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>VerifyProcessorPowerPolicyDc 21</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>VerifySystemPolicyAc 2</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// <item>
		/// <term>VerifySystemPolicyDc 3</term>
		/// <term>This information level is not supported.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="InputBuffer">
		/// A pointer to an optional input buffer. The data type of this buffer depends on the information level requested in the
		/// InformationLevel parameter.
		/// </param>
		/// <param name="InputBufferLength">The size of the input buffer, in bytes.</param>
		/// <param name="OutputBuffer">
		/// A pointer to an optional output buffer. The data type of this buffer depends on the information level requested in the
		/// InformationLevel parameter. If the buffer is too small to contain the information, the function returns STATUS_BUFFER_TOO_SMALL.
		/// </param>
		/// <param name="OutputBufferLength">
		/// The size of the output buffer, in bytes. Depending on the information level requested, this may be a variably sized buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, the return value can be one the following status codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Status</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_BUFFER_TOO_SMALL</term>
		/// <term>The output buffer is of insufficient size to contain the data to be returned.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_ACCESS_DENIED</term>
		/// <term>The caller had insufficient access rights to perform the requested action.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Changes made to the current system power policy using <c>CallNtPowerInformation</c> are immediate, but they are not persistent;
		/// that is, the changes are not stored as part of a power scheme. Any changes to system power policy made with
		/// <c>CallNtPowerInformation</c> may be overwritten by changes to a policy scheme made by the user in the Power Options control
		/// panel program, or by subsequent calls to WritePwrScheme, SetActivePwrScheme, or other power scheme functions.
		/// </para>
		/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/powerbase/nf-powerbase-callntpowerinformation NTSTATUS
		// CallNtPowerInformation( POWER_INFORMATION_LEVEL InformationLevel, PVOID InputBuffer, ULONG InputBufferLength, PVOID OutputBuffer,
		// ULONG OutputBufferLength );
		[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("powerbase.h", MSDNShortId = "adc0052d-e2dd-4c55-996c-6af8f5987d79")]
		public static extern NTStatus CallNtPowerInformation(POWER_INFORMATION_LEVEL InformationLevel, IntPtr InputBuffer, uint InputBufferLength, IntPtr OutputBuffer, uint OutputBufferLength);

		/// <summary>Retrieves information about the system power capabilities.</summary>
		/// <param name="lpspc">A pointer to a SYSTEM_POWER_CAPABILITIES structure that receives the information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function retrieves detailed information about the current system power management hardware resources and capabilities. This
		/// includes information about the presence of hardware features such as power buttons, lid switches, and batteries. Other details
		/// returned include information about current power management capabilities and configurations that can change dynamically, such as
		/// the minimum sleep state currently supported, which may change as new drivers are introduced into the system, or the presence of
		/// the system hibernation file.
		/// </para>
		/// <para>This information is also available through the CallNtPowerInformation function, using the SystemPowerCapabilities level.</para>
		/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/powerbase/nf-powerbase-getpwrcapabilities BOOLEAN GetPwrCapabilities(
		// PSYSTEM_POWER_CAPABILITIES lpspc );
		[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("powerbase.h", MSDNShortId = "bb5cec5f-8d45-4158-824a-023f92af9b69")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool GetPwrCapabilities(out SYSTEM_POWER_CAPABILITIES lpspc);

		/// <summary>Determines the computer role for the specified platform.</summary>
		/// <param name="Version">
		/// <para>The version of the POWER_PLATFORM_ROLE enumeration for the platform. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POWER_PLATFORM_ROLE_VERSION</term>
		/// <term>The version of the POWER_PLATFORM_ROLE enumeration for the current build target.</term>
		/// </item>
		/// <item>
		/// <term>POWER_PLATFORM_ROLE_V1</term>
		/// <term>
		/// The version of the POWER_PLATFORM_ROLE enumeration for Windows 7, Windows Server 2008 R2, Windows Vista or Windows Server 2008.
		/// Calling PowerDeterminePlatformRoleEx with this value returns the same result as calling PowerDeterminePlatformRole on Windows 7,
		/// Windows Server 2008 R2, Windows Vista or Windows Server 2008.
		/// </term>
		/// </item>
		/// <item>
		/// <term>POWER_PLATFORM_ROLE_V2</term>
		/// <term>The version of the POWER_PLATFORM_ROLE enumeration for Windows 8 and Windows Server 2012.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The return value is one of the values from the specified version of the POWER_PLATFORM_ROLE enumeration.</returns>
		/// <remarks>
		/// <para>
		/// This function reads the ACPI Fixed ACPI Description Table (FADT) to determine the OEM preferred computer role. If that
		/// information is not available, the function looks for a battery. If at least one battery is available, the function returns
		/// <c>PlatformRoleMobile</c>. If no batteries are available, the function returns <c>PlatformRoleDesktop</c>.
		/// </para>
		/// <para>
		/// If the OEM preferred computer role is not supported on the platform specified by the caller, the function returns the closest
		/// supported value. For example, calling the <c>PowerDeterminePlatformRoleEx</c> function with a Version of
		/// <c>POWER_PLATFORM_ROLE_V1</c> on a tablet device returns <c>PlatformRoleMobile</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/powerbase/nf-powerbase-powerdetermineplatformroleex POWER_PLATFORM_ROLE
		// PowerDeterminePlatformRoleEx( ULONG Version );
		[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("powerbase.h", MSDNShortId = "64b597d3-ca7a-4ff7-8527-72c3625147cd")]
		public static extern POWER_PLATFORM_ROLE PowerDeterminePlatformRoleEx(PowerPlatformRoleVersion Version);

		/// <summary>Registers to receive notification when the system is suspended or resumed.</summary>
		/// <param name="Flags">This parameter must be <c>DEVICE_NOTIFY_CALLBACK</c>.</param>
		/// <param name="Recipient">
		/// This parameter is a pointer to a DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS structure. In this case, the callback function is
		/// DeviceNotifyCallbackRoutine. When the <c>Callback</c> function executes, the Type parameter is set indicating the type of event
		/// that occurred. Possible values include <c>PBT_APMSUSPEND</c>, <c>PBT_APMRESUMESUSPEND</c>, and <c>PBT_APMRESUMEAUTOMATIC</c> -
		/// see Power Management Events for more info. The Setting parameter is not used with suspend/resume notifications.
		/// </param>
		/// <param name="RegistrationHandle">A handle to the registration. Use this handle to unregister for notifications.</param>
		/// <returns>Returns ERROR_SUCCESS (zero) if the call was successful, and a nonzero value if the call failed.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/powerbase/nf-powerbase-powerregistersuspendresumenotification DWORD
		// PowerRegisterSuspendResumeNotification( DWORD Flags, HANDLE Recipient, PHPOWERNOTIFY RegistrationHandle );
		[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("powerbase.h", MSDNShortId = "3b39ec3a-417c-4ce4-a581-ed967f1baec9")]
		public static extern Win32Error PowerRegisterSuspendResumeNotification(RegisterSuspendResumeNotificationFlags Flags, in DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS Recipient, out SafeHPOWERNOTIFY RegistrationHandle);

		/// <summary>Cancels a registration to receive notification when the system is suspended or resumed.</summary>
		/// <param name="RegistrationHandle">
		/// A handle to a registration obtained by calling the PowerRegisterSuspendResumeNotification function.
		/// </param>
		/// <returns>Returns ERROR_SUCCESS (zero) if the call was successful, and a nonzero value if the call failed.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/powerbase/nf-powerbase-powerunregistersuspendresumenotification DWORD
		// PowerUnregisterSuspendResumeNotification( HPOWERNOTIFY RegistrationHandle );
		[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("powerbase.h", MSDNShortId = "5680e6bd-1694-4d5f-94ea-41b24149c741")]
		public static extern Win32Error PowerUnregisterSuspendResumeNotification(HANDLE RegistrationHandle);

		/// <summary>Provides a <see cref="SafeHandle"/> for a registered power suspend/resume notification that is disposed using <see cref="PowerUnregisterSuspendResumeNotification"/>.</summary>
		public class SafeHPOWERSRNOTIFY : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHPOWERSRNOTIFY"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPOWERSRNOTIFY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHPOWERSRNOTIFY"/> class.</summary>
			private SafeHPOWERSRNOTIFY() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => PowerUnregisterSuspendResumeNotification(handle).Succeeded;
		}
	}
}