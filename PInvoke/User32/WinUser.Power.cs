namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>The following are the power management events:</summary>
	// https://docs.microsoft.com/en-us/windows/win32/power/power-management-events
	[PInvokeData("winuser.h", MSDNShortId = "2315e17f-f0c1-409c-b1c0-b3735c25c4c1")]
	public enum PowerBroadcastType
	{
		/// <summary>
		/// <para>
		/// [PBT_APMQUERYSUSPEND is available for use in the operating systems specified in the Requirements section. Support for this
		/// event was removed in Windows Vista. Use <c>SetThreadExecutionState</c> instead.]
		/// </para>
		/// <para>
		/// Requests permission to suspend the computer. An application that grants permission should carry out preparations for the
		/// suspension before returning.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// lParam: The action flags. If bit 0 is 1, the application can prompt the user for directions on how to prepare for the
		///         suspension; otherwise, the application must prepare without user interaction. All other bit values are reserved.
		/// </para>
		/// <para>Return: <c>TRUE</c> to grant the request to suspend. To deny the request, return <c>BROADCAST_QUERY_DENY</c>.</para>
		/// <para>
		/// An application should process this event as quickly as possible. The application can prompt the user for directions on how
		/// to prepare for suspension only if bit 0 in the Flags parameter is set. However, if this message is issued because the user
		/// is closing the laptop lid, it will not be possible to prompt the user. Applications should respect that the user expects a
		/// certain behavior when they close the laptop lid or press the power button and allow the transition to succeed.
		/// </para>
		/// <para>
		/// The system allows approximately 20 seconds for an application to remove the <c>WM_POWERBROADCAST</c> message that is sending
		/// the PBT_APMQUERYSUSPEND event from the application's message queue. If an application does not remove the message from its
		/// queue in less than 20 seconds, the system will assume that the application is in a non-responsive state, and that the
		/// application agrees to the sleep request. Applications that do not process their message queues may have their operations
		/// interrupted. After it removes the message from the message queue, an application can take as much time as needed to perform
		/// any required operations before entering the sleep state. Any operations that could take longer then 20 seconds should be
		/// performed at this time, since the system allows only 20 seconds for operations to complete during PBT_APMSUSPEND processing.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmquerysuspend
		PBT_APMQUERYSUSPEND = 0x0000,

		/// <summary>
		/// The PBT_APMQUERYSUSPEND message is sent to request permission to suspend the computer. An application that grants permission
		/// should carry out preparations for the suspension before returning. Return TRUE to grant the request to suspend. To deny the
		/// request, return BROADCAST_QUERY_DENY.
		/// </summary>
		[CorrespondingType(typeof(int))]
		PBT_APMQUERYSTANDBY = 0x0001,

		/// <summary>
		/// <para>
		/// [PBT_APMQUERYSUSPENDFAILED is available for use in the operating systems specified in the Requirements section. Support for
		/// this event was removed in Windows Vista. Use <c>SetThreadExecutionState</c> instead.]
		/// </para>
		/// <para>
		/// Notifies applications that permission to suspend the computer was denied. This event is broadcast if any application or
		/// driver returned <c>BROADCAST_QUERY_DENY</c> to a previous PBT_APMQUERYSUSPEND event.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>Applications typically respond to this event by resuming normal operation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmquerysuspendfailed
		[CorrespondingType(null)]
		PBT_APMQUERYSUSPENDFAILED = 0x0002,

		/// <summary>
		/// The PBT_APMQUERYSUSPENDFAILED message is sent to notify the application that suspension was denied by some other
		/// application. However, this message is only sent when we receive PBT_APMQUERY* before.
		/// </summary>
		PBT_APMQUERYSTANDBYFAILED = 0x0003,

		/// <summary>
		/// <para>
		/// Notifies applications that the computer is about to enter a suspended state. This event is typically broadcast when all
		/// applications and installable drivers have returned <c>TRUE</c> to a previous PBT_APMQUERYSUSPEND event.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>An application should process this event by completing all tasks necessary to save data.</para>
		/// <para>
		/// The system allows approximately two seconds for an application to handle this notification. If an application is still
		/// performing operations after its time allotment has expired, the system may interrupt the application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmsuspend
		[CorrespondingType(null)]
		PBT_APMSUSPEND = 0x0004,

		/// <summary>Undocumented.</summary>
		PBT_APMSTANDBY = 0x0005,

		/// <summary>
		/// <para>
		/// [PBT_APMRESUMECRITICAL is available for use in the operating systems specified in the Requirements section. Support for this
		/// event was removed in Windows Vista. Use PBT_APMRESUMEAUTOMATIC instead.]
		/// </para>
		/// <para>
		/// Notifies applications that the system has resumed operation. This event can indicate that some or all applications did not
		/// receive a PBT_APMSUSPEND event. For example, this event can be broadcast after a critical suspension caused by a failing battery.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>
		/// Because a critical suspension occurs without prior notification, resources and data previously available may not be present
		/// when the application receives this event. The application should attempt to restore its state to the best of its ability.
		/// While in a critical suspension, the system maintains the state of the DRAM and local hard disks, but may not maintain net
		/// connections. An application may need to take action with respect to files that were open on the network before critical suspension.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmresumecritical
		[CorrespondingType(null)]
		PBT_APMRESUMECRITICAL = 0x0006,

		/// <summary>
		/// <para>Notifies applications that the system has resumed operation after being suspended.</para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>
		/// An application can receive this event only if it received the PBT_APMSUSPEND event before the computer was suspended.
		/// Otherwise, the application will receive a PBT_APMRESUMECRITICAL event.
		/// </para>
		/// <para>
		/// If the system wakes due to user activity (such as pressing the power button) or if the system detects user interaction at
		/// the physical console (such as mouse or keyboard input) after waking unattended, the system first broadcasts the
		/// PBT_APMRESUMEAUTOMATIC event, then it broadcasts the PBT_APMRESUMESUSPEND event. In addition, the system turns on the
		/// display. Your application should reopen files that it closed when the system entered sleep and prepare for user input.
		/// </para>
		/// <para>
		/// If the system wakes due to an external wake signal (remote wake), the system broadcasts only the PBT_APMRESUMEAUTOMATIC
		/// event. The PBT_APMRESUMESUSPEND event is not sent.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmresumesuspend
		[CorrespondingType(null)]
		PBT_APMRESUMESUSPEND = 0x0007,

		/// <summary>
		/// The PBT_APMRESUMESTANDBY event is broadcast as a notification that the system has resumed operation after being standby.
		/// </summary>
		PBT_APMRESUMESTANDBY = 0x0008,

		/// <summary>
		/// <para>
		/// [PBT_APMBATTERYLOW is available for use in the operating systems specified in the Requirements section. Support for this
		/// event was removed in Windows Vista. Use PBT_APMPOWERSTATUSCHANGE instead.]
		/// </para>
		/// <para>Notifies applications that the battery power is low.</para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved, must be zero.</para>
		/// <para>No return value.</para>
		/// <para>
		/// This event is broadcast when a system's APM BIOS signals an APM battery low notification. Because some APM BIOS
		/// implementations do not provide notifications when batteries are low, this event may never be broadcast on some computers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmbatterylow
		[CorrespondingType(null)]
		PBT_APMBATTERYLOW = 0x0009,

		/// <summary>
		/// <para>
		/// Notifies applications of a change in the power status of the computer, such as a switch from battery power to A/C. The
		/// system also broadcasts this event when remaining battery power slips below the threshold specified by the user or if the
		/// battery power changes by a specified percentage.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>
		/// An application should process this event by calling the <c>GetSystemPowerStatus</c> function to retrieve the current power
		/// status of the computer. In particular, the application should check the <c>ACLineStatus</c>, <c>BatteryFlag</c>,
		/// <c>BatteryLifeTime</c>, and <c>BatteryLifePercent</c> members of the <c>SYSTEM_POWER_STATUS</c> structure for any changes.
		/// This event can occur when battery life drops to less than 5 minutes, or when the percentage of battery life drops below 10
		/// percent, or if the battery life changes by 3 percent.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmpowerstatuschange
		[CorrespondingType(null)]
		PBT_APMPOWERSTATUSCHANGE = 0x000A,

		/// <summary>
		/// <para>
		/// [PBT_APMOEMEVENT is available for use in the operating systems specified in the Requirements section. Support for this event
		/// was removed in Windows Vista.]
		/// </para>
		/// <para>Notifies applications that the APM BIOS has signaled an APM OEM event.</para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// lParam: The OEM-defined event code that was signaled by the system's APM BIOS. OEM event codes are in the range 0200h - 02FFh.
		/// </para>
		/// <para>No return value.</para>
		/// <para>
		/// Because not all APM BIOS implementations provide OEM event notifications, this event may never be broadcast on some computers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmoemevent
		[CorrespondingType(typeof(int))]
		PBT_APMOEMEVENT = 0x000B,

		/// <summary>
		/// <para>
		/// Notifies applications that the system is resuming from sleep or hibernation. This event is delivered every time the system
		/// resumes and does not indicate whether a user is present.
		/// </para>
		/// <para>
		/// A window receives this event through the <c>WM_POWERBROADCAST</c> message. The wParam and lParam parameters are set as
		/// described following.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>lParam: Reserved; must be zero.</para>
		/// <para>No return value.</para>
		/// <para>
		/// If the system detects any user activity after broadcasting PBT_APMRESUMEAUTOMATIC, it will broadcast a PBT_APMRESUMESUSPEND
		/// event to let applications know they can resume full interaction with the user.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-apmresumeautomatic
		[CorrespondingType(null)]
		PBT_APMRESUMEAUTOMATIC = 0x0012,

		/// <summary>
		/// Power setting change event sent with a <c>WM_POWERBROADCAST</c> window message or in a <c>HandlerEx</c> notification
		/// callback for services.
		/// </summary>
		/// <remarks>
		/// <para>lParam: Pointer to a <c>POWERBROADCAST_SETTING</c> structure.</para>
		/// <para>No return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/power/pbt-powersettingchange
		[CorrespondingType(typeof(POWERBROADCAST_SETTING?))]
		PBT_POWERSETTINGCHANGE = 0x8013,
	}

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
	/// Registers to receive notification when the system is suspended or resumed. Similar to PowerRegisterSuspendResumeNotification,
	/// but operates in user mode and can take a window handle.
	/// </summary>
	/// <param name="hRecipient">
	/// <para>
	/// This parameter contains parameters for subscribing to a power notification or a window handle representing the subscribing process.
	/// </para>
	/// <para>
	/// If Flags is <c>DEVICE_NOTIFY_CALLBACK</c>, hRecipient is interpreted as a pointer to a DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
	/// structure. In this case, the callback function is DeviceNotifyCallbackRoutine. When the <c>Callback</c> function executes, the
	/// Type parameter is set indicating the type of event that occurred. Possible values include <c>PBT_APMSUSPEND</c>,
	/// <c>PBT_APMRESUMESUSPEND</c>, and <c>PBT_APMRESUMEAUTOMATIC</c> - see Power Management Events for more info. The Setting
	/// parameter is not used with suspend/resume notifications.
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
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterPowerSettingNotification([In] HANDLE Handle);

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

	/// <summary>
	/// Sent with a power setting event and contains data about the specific change. For more information, see Registering for Power
	/// Events and Power Setting GUIDs.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-powerbroadcast_setting typedef struct { GUID PowerSetting;
	// DWORD DataLength; UCHAR Data[1]; } POWERBROADCAST_SETTING, *PPOWERBROADCAST_SETTING;
	[PInvokeData("winuser.h", MSDNShortId = "13fa8220-bad2-4bb6-b652-38fc11a31215")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<POWERBROADCAST_SETTING>), nameof(DataLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct POWERBROADCAST_SETTING
	{
		/// <summary>
		/// Indicates the power setting for which this notification is being delivered. For more info, see Power Setting GUIDs.
		/// </summary>
		public Guid PowerSetting;

		/// <summary>The size in bytes of the data in the Data member.</summary>
		public uint DataLength;

		/// <summary>The new value of the power setting. The type and possible values for this member depend on PowerSettng.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Data;

		/// <summary>Gets the data as an enumeration value.</summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <returns>The enum value in <see cref="Data"/>.</returns>
		public readonly TEnum GetEnumData<TEnum>() where TEnum : unmanaged, Enum => EnumExtensions.ToEnum<TEnum>(Data);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <c>HPOWERNOTIFY</c> that is disposed using <see cref="UnregisterPowerSettingNotification"/>.</summary>
	[AutoSafeHandle("UnregisterPowerSettingNotification(handle)")]
	public partial class SafeHPOWERSETTINGNOTIFY { }

	/// <summary>Provides a <see cref="SafeHandle"/> for <c>HPOWERNOTIFY</c> that is disposed using <see cref="UnregisterSuspendResumeNotification"/>.</summary>
	[AutoSafeHandle("UnregisterSuspendResumeNotification(handle)")]
	public partial class SafeHSUSPRESUMENOTIFY { }
}