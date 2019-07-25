using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The AC power status.</summary>
		public enum AC_STATUS : byte
		{
			/// <summary>Offline</summary>
			AC_OFFLINE = 0,

			/// <summary>Online</summary>
			AC_ONLINE = 1,

			/// <summary>On backup power.</summary>
			AC_LINE_BACKUP_POWER = 2,

			/// <summary>Unknown status</summary>
			AC_UNKNOWN = 255
		}

		/// <summary>The battery charge status.</summary>
		[Flags]
		public enum BATTERY_STATUS : byte
		{
			/// <summary>High—the battery capacity is at more than 66 percent</summary>
			BATTERY_HIGH = 1,

			/// <summary>Low—the battery capacity is at less than 33 percent</summary>
			BATTERY_LOW = 2,

			/// <summary>Critical—the battery capacity is at less than five percent</summary>
			BATTERY_CRITICAL = 4,

			/// <summary>Charging</summary>
			BATTERY_CHARGING = 8,

			/// <summary>No system battery</summary>
			BATTERY_NONE = 128,

			/// <summary>Unknown status—unable to read the battery flag information</summary>
			BATTERY_UNKNOWN = 255
		}

		/// <summary>The latency requirement for the time is takes to wake the computer.</summary>
		public enum LATENCY_TIME
		{
			/// <summary>Any latency (default).</summary>
			LT_DONT_CARE,

			/// <summary>PowerSystemSleeping1 state (equivalent to ACPI state S0 and APM state Working).</summary>
			LT_LOWEST_LATENCY,
		}

		/// <summary>
		/// Retrieves the current power state of the specified device. This function cannot be used to query the power state of a display device.
		/// </summary>
		/// <param name="hDevice">A handle to an object on the device, such as a file or socket, or a handle to the device itself.</param>
		/// <param name="pfOn">
		/// A pointer to the variable that receives the power state. This value is <c>TRUE</c> if the device is in the working state.
		/// Otherwise, it is <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL WINAPI GetDevicePowerState( _In_ HANDLE hDevice, _Out_ BOOL *pfOn); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372690(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa372690")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetDevicePowerState([In] IntPtr hDevice, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfOn);

		/// <summary>
		/// Retrieves the power status of the system. The status indicates whether the system is running on AC or DC power, whether the
		/// battery is currently charging, how much battery life remains, and if battery saver is on or off.
		/// </summary>
		/// <param name="lpSystemPowerStatus">A pointer to a <c>SYSTEM_POWER_STATUS</c> structure that receives status information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetSystemPowerStatus( _Out_ LPSYSTEM_POWER_STATUS lpSystemPowerStatus); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372693(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa372693")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS lpSystemPowerStatus);

		/// <summary>Determines the current state of the computer.</summary>
		/// <returns>
		/// If the system was restored to the working state automatically and the user is not active, the function returns <c>TRUE</c>.
		/// Otherwise, the function returns <c>FALSE</c>.
		/// </returns>
		// BOOL WINAPI IsSystemResumeAutomatic(void); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372708(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa372708")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsSystemResumeAutomatic();

		/// <summary>
		/// <para>
		/// [ <c>RequestWakeupLatency</c> is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// Has no effect and returns <c>STATUS_NOT_SUPPORTED</c>. This function is provided only for compatibility with earlier versions of Windows.
		/// </para>
		/// <para><c>Windows Server 2008 and Windows Vista:</c> Has no effect and always returns success.</para>
		/// </summary>
		/// <param name="latency">
		/// <para>The latency requirement for the time is takes to wake the computer. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LT_LOWEST_LATENCY1</term>
		/// <term>PowerSystemSleeping1 state (equivalent to ACPI state S0 and APM state Working).</term>
		/// </item>
		/// <item>
		/// <term>LT_DONT_CARE0</term>
		/// <term>Any latency (default).</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>The return value is nonzero.</returns>
		// BOOL WINAPI RequestWakeupLatency( _In_ LATENCY_TIME latency); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373199(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa373199")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RequestWakeupLatency(LATENCY_TIME latency);

		/// <summary>
		/// <para>
		/// [ <c>SetSystemPowerState</c> is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use SetSuspendState instead.]
		/// </para>
		/// <para>
		/// Suspends the system by shutting power down. Depending on the ForceFlag parameter, the function either suspends operation
		/// immediately or requests permission from all applications and device drivers before doing so.
		/// </para>
		/// </summary>
		/// <param name="fSuspend">
		/// If this parameter is <c>TRUE</c>, the system is suspended. If the parameter is <c>FALSE</c>, the system hibernates.
		/// </param>
		/// <param name="fForce">This parameter has no effect.</param>
		/// <returns>
		/// <para>If power has been suspended and subsequently restored, the return value is nonzero.</para>
		/// <para>If the system was not suspended, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege. To enable the <c>SE_SHUTDOWN_NAME</c> privilege, use the
		/// AdjustTokenPrivileges function. For more information, see Changing Privileges in a Token.
		/// </para>
		/// <para>
		/// If any application or driver denies permission to suspend operation, the function broadcasts a PBT_APMQUERYSUSPENDFAILED event to
		/// each application and driver. If power is suspended, this function returns only after system operation is resumed and related
		/// WM_POWERBROADCAST messages have been broadcast to all applications and drivers.
		/// </para>
		/// <para>This function is similar to the SetSuspendState function.</para>
		/// <para>
		/// To compile an application that uses this function, define the _WIN32_WINNT macro as 0x0400 or later. For more information, see
		/// Using the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-setsystempowerstate BOOL SetSystemPowerState( BOOL fSuspend,
		// BOOL fForce );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "58cf4e29-2a2e-499a-85ce-0034f4323cfe")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSystemPowerState([MarshalAs(UnmanagedType.Bool)] bool fSuspend, [MarshalAs(UnmanagedType.Bool), Optional] bool fForce);

		/// <summary>Contains information about the power status of the system.</summary>
		// typedef struct _SYSTEM_POWER_STATUS { BYTE ACLineStatus; BYTE BatteryFlag; BYTE BatteryLifePercent; BYTE SystemStatusFlag; DWORD
		// BatteryLifeTime; DWORD BatteryFullLifeTime;} SYSTEM_POWER_STATUS, *LPSYSTEM_POWER_STATUS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa373232(v=vs.85).aspx
		[PInvokeData("Winbase.h", MSDNShortId = "aa373232")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct SYSTEM_POWER_STATUS
		{
			/// <summary>
			/// <para>The AC power status. This member can be one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Offline</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>Online</term>
			/// </item>
			/// <item>
			/// <term>255</term>
			/// <term>Unknown status</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public AC_STATUS ACLineStatus;

			/// <summary>
			/// <para>The battery charge status. This member can contain one or more of the following flags.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>1</term>
			/// <term>High—the battery capacity is at more than 66 percent</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>Low—the battery capacity is at less than 33 percent</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>Critical—the battery capacity is at less than five percent</term>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <term>Charging</term>
			/// </item>
			/// <item>
			/// <term>128</term>
			/// <term>No system battery</term>
			/// </item>
			/// <item>
			/// <term>255</term>
			/// <term>Unknown status—unable to read the battery flag information</term>
			/// </item>
			/// </list>
			/// </para>
			/// <para>The value is zero if the battery is not being charged and the battery capacity is between low and high.</para>
			/// </summary>
			public BATTERY_STATUS BatteryFlag;

			/// <summary>
			/// The percentage of full battery charge remaining. This member can be a value in the range 0 to 100, or 255 if status is unknown.
			/// </summary>
			public byte BatteryLifePercent;

			/// <summary>
			/// <para>
			/// The status of battery saver. To participate in energy conservation, avoid resource intensive tasks when battery saver is on.
			/// To be notified when this value changes, call the <c>RegisterPowerSettingNotification</c> function with the <c>power setting
			/// GUID</c>, <c>GUID_POWER_SAVING_STATUS</c>.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Battery saver is off.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>Battery saver on. Save energy where possible.</term>
			/// </item>
			/// </list>
			/// </para>
			/// <para>For general information about battery saver, see battery saver (in the hardware component guidelines).</para>
			/// </summary>
			public byte SystemStatusFlag;

			/// <summary>
			/// The number of seconds of battery life remaining, or –1 if remaining seconds are unknown or if the device is connected to AC power.
			/// </summary>
			public uint BatteryLifeTime;

			/// <summary>
			/// The number of seconds of battery life when at full charge, or –1 if full battery lifetime is unknown or if the device is
			/// connected to AC power.
			/// </summary>
			public uint BatteryFullLifeTime;
		}
	}
}