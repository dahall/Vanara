using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Registers the application to receive power setting notifications for the specific power setting event.</summary>
		/// <param name="hRecipient">
		/// Handle indicating where the power setting notifications are to be sent. For interactive applications, the Flags parameter should
		/// be zero, and the hRecipient parameter should be a window handle. For services, the Flags parameter should be one, and the
		/// hRecipient parameter should be a <c>SERVICE_STATUS_HANDLE</c> as returned from RegisterServiceCtrlHandlerEx.
		/// </param>
		/// <param name="PowerSettingGuid">
		/// The <c>GUID</c> of the power setting for which notifications are to be sent. For more information see Registering for Power Events.
		/// </param>
		/// <param name="Flags">
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DEVICE_NOTIFY_WINDOW_HANDLE 0</term>
		/// <term>Notifications are sent using WM_POWERBROADCAST messages with a wParam parameter of PBT_POWERSETTINGCHANGE.</term>
		/// </item>
		/// <item>
		/// <term>DEVICE_NOTIFY_SERVICE_HANDLE 1</term>
		/// <term>
		/// Notifications are sent to the HandlerEx callback function with a dwControl parameter of SERVICE_CONTROL_POWEREVENT and a
		/// dwEventType of PBT_POWERSETTINGCHANGE.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// Returns a notification handle for unregistering for power notifications. If the function fails, the return value is NULL. To get
		/// extended error information, call GetLastError.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerpowersettingnotification HPOWERNOTIFY
		// RegisterPowerSettingNotification( IN HANDLE hRecipient, IN LPCGUID PowerSettingGuid, IN DWORD Flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "e072222e-da66-4b36-a38f-f4b618eaa391")]
		public static extern SafeHPOWERSETTINGNOTIFY RegisterPowerSettingNotification([In] HANDLE hRecipient, in Guid PowerSettingGuid, [In] DEVICE_NOTIFY Flags);

		/// <summary>
		/// Registers to receive notification when the system is suspended or resumed. Similar to PowerRegisterSuspendResumeNotification, but
		/// operates in user mode and can take a window handle.
		/// </summary>
		/// <param name="hRecipient">
		/// <para>
		/// This parameter contains parameters for subscribing to a power notification or a window handle representing the subscribing process.
		/// </para>
		/// <para>
		/// If Flags is <c>DEVICE_NOTIFY_CALLBACK</c>, hRecipient is interpreted as a pointer to a DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
		/// structure. In this case, the callback function is DeviceNotifyCallbackRoutine. When the <c>Callback</c> function executes, the
		/// Type parameter is set indicating the type of event that occurred. Possible values include <c>PBT_APMSUSPEND</c>,
		/// <c>PBT_APMRESUMESUSPEND</c>, and <c>PBT_APMRESUMEAUTOMATIC</c> - see Power Management Events for more info. The Setting parameter
		/// is not used with suspend/resume notifications.
		/// </para>
		/// <para>If Flags is <c>DEVICE_NOTIFY_WINDOW_HANDLE</c>, hRecipient is a handle to the window to deliver events to.</para>
		/// </param>
		/// <param name="Flags">This parameter can be <c>DEVICE_NOTIFY_WINDOW_HANDLE</c> or <c>DEVICE_NOTIFY_CALLBACK</c>.</param>
		/// <returns>
		/// <para>A handle to the registration. Use this handle to unregister for notifications.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registersuspendresumenotification HPOWERNOTIFY
		// RegisterSuspendResumeNotification( IN HANDLE hRecipient, IN DWORD Flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "6cd42d32-07e9-4cbd-83f9-6146b1cb54db")]
		public static extern SafeHSUSPRESUMENOTIFY RegisterSuspendResumeNotification([In] HANDLE hRecipient, [In] DEVICE_NOTIFY Flags);

		/// <summary>Unregisters the power setting notification.</summary>
		/// <param name="Handle">The handle returned from the RegisterPowerSettingNotification function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregisterpowersettingnotification BOOL
		// UnregisterPowerSettingNotification( IN HPOWERNOTIFY Handle );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "de1509f5-cf4c-448e-bb3b-08da6be53bfa")]
		[return: MarshalAs(UnmanagedType.Bool)] public static extern bool UnregisterPowerSettingNotification([In] HANDLE Handle);

		/// <summary>
		/// Cancels a registration to receive notification when the system is suspended or resumed. Similar to
		/// PowerUnregisterSuspendResumeNotification but operates in user mode.
		/// </summary>
		/// <param name="Handle">A handle to a registration obtained by calling the RegisterSuspendResumeNotification function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregistersuspendresumenotification BOOL
		// UnregisterSuspendResumeNotification( IN HPOWERNOTIFY Handle );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "d9307452-9670-4e9c-9df8-6a3b41d0bd2e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterSuspendResumeNotification([In] HANDLE Handle);

		/// <summary>Provides a <see cref="SafeHandle"/> for <c>HPOWERNOTIFY</c> that is disposed using <see cref="UnregisterPowerSettingNotification"/>.</summary>
		public class SafeHPOWERSETTINGNOTIFY : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHPOWERSETTINGNOTIFY"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPOWERSETTINGNOTIFY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHPOWERSETTINGNOTIFY"/> class.</summary>
			private SafeHPOWERSETTINGNOTIFY() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => UnregisterPowerSettingNotification(handle);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <c>HPOWERNOTIFY</c> that is disposed using <see cref="UnregisterSuspendResumeNotification"/>.</summary>
		public class SafeHSUSPRESUMENOTIFY : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHSUSPRESUMENOTIFY"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHSUSPRESUMENOTIFY(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHSUSPRESUMENOTIFY"/> class.</summary>
			private SafeHSUSPRESUMENOTIFY() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => UnregisterSuspendResumeNotification(handle);
		}

		/*
		CallNtPowerInformation
		CanUserWritePwrScheme
		DeletePwrScheme
		DeviceNotifyCallbackRoutine
		DevicePowerClose
		DevicePowerEnumDevices
		DevicePowerOpen
		DevicePowerSetDeviceState
		EnumPwrSchemes
		EFFECTIVE_POWER_MODE_CALLBACK
		GetActivePwrScheme
		GetCurrentPowerPolicies
		GetDevicePowerState
		GetPwrCapabilities
		GetPwrDiskSpindownRange
		GetSystemPowerStatus
		IsPwrHibernateAllowed
		IsPwrShutdownAllowed
		IsPwrSuspendAllowed
		IsSystemResumeAutomatic
		PowerCanRestoreIndividualDefaultPowerScheme
		PowerClearRequest
		PowerCreatePossibleSetting
		PowerCreateRequest
		PowerCreateSetting
		PowerDeleteScheme
		PowerDeterminePlatformRole
		PowerDeterminePlatformRoleEx
		PowerDuplicateScheme
		PowerEnumerate
		PowerGetActiveScheme
		PowerImportPowerScheme
		PowerIsSettingRangeDefined
		PowerReadACDefaultIndex
		PowerReadACValue
		PowerReadACValueIndex
		PowerReadDCDefaultIndex
		PowerReadDCValue
		PowerReadDCValueIndex
		PowerReadDescription
		PowerReadFriendlyName
		PowerReadIconResourceSpecifier
		PowerReadPossibleDescription
		PowerReadPossibleFriendlyName
		PowerReadPossibleValue
		PowerReadSettingAttributes
		PowerReadValueIncrement
		PowerReadValueMax
		PowerReadValueMin
		PowerReadValueUnitsSpecifier
		PowerRegisterForEffectivePowerModeNotifications
		PowerRegisterSuspendResumeNotification
		PowerRemovePowerSetting
		PowerReplaceDefaultPowerSchemes
		PowerReportThermalEvent
		PowerRestoreDefaultPowerSchemes
		PowerRestoreIndividualDefaultPowerScheme
		PowerSetActiveScheme
		PowerSetRequest
		PowerSettingAccessCheck
		PowerSettingAccessCheckEx
		PowerSettingRegisterNotification
		PowerSettingUnregisterNotification
		PowerUnregisterFromEffectivePowerModeNotifications
		PowerUnregisterSuspendResumeNotification
		PowerWriteACDefaultIndex
		PowerWriteACValueIndex
		PowerWriteDCDefaultIndex
		PowerWriteDCValueIndex
		PowerWriteDescription
		PowerWriteFriendlyName
		PowerWriteIconResourceSpecifier
		PowerWritePossibleDescription
		PowerWritePossibleFriendlyName
		PowerWritePossibleValue
		PowerWriteSettingAttributes
		PowerWriteValueIncrement
		PowerWriteValueMax
		PowerWriteValueMin
		PowerWriteValueUnitsSpecifier
		ReadGlobalPwrPolicy
		ReadProcessorPwrScheme
		ReadPwrScheme
		RequestWakeupLatency
		SetActivePwrScheme
		SetSuspendState
		SetSystemPowerState
		SetThreadExecutionState
		WriteGlobalPwrPolicy
		WriteProcessorPwrScheme
		WritePwrScheme
		*/
	}
}