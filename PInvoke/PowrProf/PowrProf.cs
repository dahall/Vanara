using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class PowrProf
{
	/// <summary>An application's DeviceNotifyCallbackRoutine callback function is used for receiving power notifications.</summary>
	/// <param name="Context">The context provided when registering for the power notification.</param>
	/// <param name="Type">The type of power event that caused this notification.</param>
	/// <param name="Setting">The value of this parameter depends on the type of notification subscribed to.</param>
	/// <returns>This function returns a Windows error code.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nc-powrprof-device_notify_callback_routine
	// DEVICE_NOTIFY_CALLBACK_ROUTINE DeviceNotifyCallbackRoutine; ULONG DeviceNotifyCallbackRoutine( PVOID Context, ULONG Type, PVOID
	// Setting ) {...}
	[PInvokeData("powrprof.h", MSDNShortId = "5734FDEE-E330-4115-AFA5-725114023A5A")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate Win32Error DeviceNotifyCallbackRoutine(IntPtr Context, uint Type, IntPtr Setting);

	/// <summary>A callback function to be called for each power scheme enumerated in <see cref="EnumPwrSchemes"/>.</summary>
	/// <param name="uiIndex"/>
	/// <param name="dwName"/>
	/// <param name="sName"/>
	/// <param name="dwDesc"/>
	/// <param name="sDesc"/>
	/// <param name="pp">The power policy scheme.</param>
	/// <param name="lParam"/>
	/// <returns>
	/// To continue until all power schemes have been enumerated, the callback function must return TRUE. To stop the enumeration, the
	/// callback function must return FALSE.
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PWRSCHEMESENUMPROC(uint uiIndex, uint dwName, string sName, uint dwDesc, string sDesc, in POWER_POLICY pp, IntPtr lParam);

	private delegate Win32Error PwrReadMemFunc(HKEY h, IntPtr a, IntPtr b, IntPtr c, IntPtr d, ref uint e);

	/// <summary>The global flags constants are used to enable or disable user power policy options.</summary>
	[PInvokeData("powrprof.h", MSDNShortId = "0e89ae66-a889-4929-b028-125fcef5c89c")]
	[Flags]
	public enum GlobalFlags : uint
	{
		/// <summary>Enables or disables multiple battery display in the system Power Meter.</summary>
		EnableMultiBatteryDisplay = 0x02,

		/// <summary>Enables or disables requiring password logon when the system resumes from standby or hibernate.</summary>
		EnablePasswordLogon = 0x04,

		/// <summary>
		/// Enables or disables the battery meter icon in the system tray. When this flag is cleared, the battery meter icon is not displayed.
		/// </summary>
		EnableSysTrayBatteryMeter = 0x01,

		/// <summary>
		/// Enables or disables support for dimming the video display when the system changes from running on AC power to running on
		/// battery power.
		/// </summary>
		EnableVideoDimDisplay = 0x10,

		/// <summary>Enables or disables wake on ring support.</summary>
		EnableWakeOnRing = 0x08,
	}

	/// <summary>
	/// These flags tell us how to interpret a query of device power. Use these (or a combination of these) for the
	/// QueryInterpretationFlags parameter sent into DevicePowerEnumDevices().
	/// </summary>
	[PInvokeData("powrprof.h", MSDNShortId = "bb67634c-69d9-4194-ac27-4f9740d73a1a")]
	[Flags]
	public enum PDQUERY : uint
	{
		/// <summary>Return a hardware ID string rather than friendly device name.</summary>
		DEVICEPOWER_HARDWAREID = 0x80000000,

		/// <summary>Ignore devices not currently present in the system.</summary>
		DEVICEPOWER_FILTER_DEVICES_PRESENT = 0x20000000,

		/// <summary>Perform an AND operation on QueryFlags.</summary>
		DEVICEPOWER_AND_OPERATION = 0x40000000,

		/// <summary>Check whether the device is currently enabled to wake the system from a sleep state.</summary>
		DEVICEPOWER_FILTER_WAKEENABLED = 0x08000000,

		/// <summary>Find a device whose name matches the string passed in pReturnBuffer and check its capabilities against QueryFlags.</summary>
		DEVICEPOWER_FILTER_ON_NAME = 0x02000000,

		/// <summary>Only preform the query on devices that are actual hardware.</summary>
		DEVICEPOWER_FILTER_HARDWARE = 0x10000000,

		/// <summary>Only preform the query on devices that are capable of being programmed to wake the system from a sleep state.</summary>
		DEVICEPOWER_FILTER_WAKEPROGRAMMABLE = 0x04000000,
	}

	/// <summary>Flags for <see cref="DevicePowerSetDeviceState"/>.</summary>
	[PInvokeData("powrprof.h", MSDNShortId = "300842ae-d7d4-42c2-959c-e1713f466d32")]
	[Flags]
	public enum PDSET
	{
		/// <summary>Enables the specified device to wake the system.</summary>
		DEVICEPOWER_SET_WAKEENABLED = 0x00000001,

		/// <summary>Stops the specified device from being able to wake the system.</summary>
		DEVICEPOWER_CLEAR_WAKEENABLED = 0x00000002,
	}

	/// <summary>Power attributes.</summary>
	[PInvokeData("powrprof.h", MSDNShortId = "9f430da2-7c8d-43e2-ab8a-d9af1bb7538f")]
	[Flags]
	public enum POWER_ATTR
	{
		/// <summary>Hide this power setting.</summary>
		POWER_ATTRIBUTE_HIDE = 0x00000001,

		/// <summary>Undocumented.</summary>
		POWER_ATTRIBUTE_SHOW_AOAC = 0x00000002
	}

	/// <summary>Enumeration values used by PowerEnumerate and PowerSettingAccessCheck.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ne-powrprof-_power_data_accessor typedef enum _POWER_DATA_ACCESSOR {
	// ACCESS_AC_POWER_SETTING_INDEX, ACCESS_DC_POWER_SETTING_INDEX, ACCESS_FRIENDLY_NAME, ACCESS_DESCRIPTION,
	// ACCESS_POSSIBLE_POWER_SETTING, ACCESS_POSSIBLE_POWER_SETTING_FRIENDLY_NAME, ACCESS_POSSIBLE_POWER_SETTING_DESCRIPTION,
	// ACCESS_DEFAULT_AC_POWER_SETTING, ACCESS_DEFAULT_DC_POWER_SETTING, ACCESS_POSSIBLE_VALUE_MIN, ACCESS_POSSIBLE_VALUE_MAX,
	// ACCESS_POSSIBLE_VALUE_INCREMENT, ACCESS_POSSIBLE_VALUE_UNITS, ACCESS_ICON_RESOURCE, ACCESS_DEFAULT_SECURITY_DESCRIPTOR,
	// ACCESS_ATTRIBUTES, ACCESS_SCHEME, ACCESS_SUBGROUP, ACCESS_INDIVIDUAL_SETTING, ACCESS_ACTIVE_SCHEME, ACCESS_CREATE_SCHEME,
	// ACCESS_AC_POWER_SETTING_MAX, ACCESS_DC_POWER_SETTING_MAX, ACCESS_AC_POWER_SETTING_MIN, ACCESS_DC_POWER_SETTING_MIN,
	// ACCESS_PROFILE, ACCESS_OVERLAY_SCHEME, ACCESS_ACTIVE_OVERLAY_SCHEME } POWER_DATA_ACCESSOR, *PPOWER_DATA_ACCESSOR;
	[PInvokeData("powrprof.h", MSDNShortId = "4b3f8f89-2ade-4594-b055-b1873e74cda6")]
	public enum POWER_DATA_ACCESSOR
	{
		/// <summary>Used with PowerSettingAccessCheck to check for group policy overrides for AC power settings.</summary>
		ACCESS_AC_POWER_SETTING_INDEX,

		/// <summary>Used with PowerSettingAccessCheck to check for group policy overrides for DC power settings.</summary>
		ACCESS_DC_POWER_SETTING_INDEX,

		/// <summary/>
		ACCESS_FRIENDLY_NAME,

		/// <summary/>
		ACCESS_DESCRIPTION,

		/// <summary/>
		ACCESS_POSSIBLE_POWER_SETTING,

		/// <summary/>
		ACCESS_POSSIBLE_POWER_SETTING_FRIENDLY_NAME,

		/// <summary/>
		ACCESS_POSSIBLE_POWER_SETTING_DESCRIPTION,

		/// <summary/>
		ACCESS_DEFAULT_AC_POWER_SETTING,

		/// <summary/>
		ACCESS_DEFAULT_DC_POWER_SETTING,

		/// <summary/>
		ACCESS_POSSIBLE_VALUE_MIN,

		/// <summary/>
		ACCESS_POSSIBLE_VALUE_MAX,

		/// <summary/>
		ACCESS_POSSIBLE_VALUE_INCREMENT,

		/// <summary/>
		ACCESS_POSSIBLE_VALUE_UNITS,

		/// <summary/>
		ACCESS_ICON_RESOURCE,

		/// <summary/>
		ACCESS_DEFAULT_SECURITY_DESCRIPTOR,

		/// <summary/>
		ACCESS_ATTRIBUTES,

		/// <summary>
		/// Used to enumerate power schemes with PowerEnumerate and with PowerSettingAccessCheck to check for restricted access to
		/// specific power schemes.
		/// </summary>
		ACCESS_SCHEME,

		/// <summary>Used to enumerate subgroups with PowerEnumerate.</summary>
		ACCESS_SUBGROUP,

		/// <summary>Used to enumerate individual power settings with PowerEnumerate.</summary>
		ACCESS_INDIVIDUAL_SETTING,

		/// <summary>Used with PowerSettingAccessCheck to check for group policy overrides for active power schemes.</summary>
		ACCESS_ACTIVE_SCHEME,

		/// <summary>Used with PowerSettingAccessCheck to check for restricted access for creating power schemes.</summary>
		ACCESS_CREATE_SCHEME,

		/// <summary/>
		ACCESS_AC_POWER_SETTING_MAX,

		/// <summary/>
		ACCESS_DC_POWER_SETTING_MAX,

		/// <summary/>
		ACCESS_AC_POWER_SETTING_MIN,

		/// <summary/>
		ACCESS_DC_POWER_SETTING_MIN,

		/// <summary/>
		ACCESS_PROFILE,

		/// <summary/>
		ACCESS_OVERLAY_SCHEME,

		/// <summary/>
		ACCESS_ACTIVE_OVERLAY_SCHEME,
	}

	/// <summary>
	/// <para>
	/// [ <c>CanUserWritePwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use
	/// PowerSettingAccessCheck instead.]
	/// </para>
	/// <para>Determines whether the current user has sufficient privilege to write a power scheme.</para>
	/// </summary>
	/// <returns>
	/// <para>If the current user has sufficient privilege to write a power scheme, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
	/// include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The current user does not have sufficient privilege to write a power scheme.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function is useful if your application is impersonating a user.</para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-canuserwritepwrscheme BOOLEAN CanUserWritePwrScheme( );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "3989da98-aa01-4c63-a74c-ce7ba18278c1")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool CanUserWritePwrScheme();

	/// <summary>
	/// <para>
	/// [ <c>DeletePwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be altered
	/// or unavailable in subsequent versions. Applications written for Windows Vista and later should use PowerDeleteScheme instead.]
	/// </para>
	/// <para>Deletes the specified power scheme.</para>
	/// </summary>
	/// <param name="uiID">The index of the power scheme to be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Applications can call <c>DeletePwrScheme</c> to permanently delete a power scheme. An attempt to delete the currently active
	/// power scheme fails with the last error set to ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-deletepwrscheme BOOLEAN DeletePwrScheme( UINT uiID );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "c9513835-00c4-4260-a8b6-d947539c9dd1")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool DeletePwrScheme(uint uiID);

	/// <summary>Frees all nodes in the device list and destroys the device list.</summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-devicepowerclose BOOLEAN DevicePowerClose( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "60f871bc-08b7-41d1-ba37-688ab68fb9b3")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool DevicePowerClose();

	/// <summary>Enumerates devices on the system that meet the specified criteria.</summary>
	/// <param name="QueryIndex">The index of the requested device. For initial calls, this value should be zero.</param>
	/// <param name="QueryInterpretationFlags">
	/// <para>The criteria applied to the search results.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICEPOWER_HARDWAREID 0x80000000</term>
	/// <term>Return a hardware ID string rather than friendly device name.</term>
	/// </item>
	/// <item>
	/// <term>DEVICEPOWER_FILTER_DEVICES_PRESENT 0x20000000</term>
	/// <term>Ignore devices not currently present in the system.</term>
	/// </item>
	/// <item>
	/// <term>DEVICEPOWER_AND_OPERATION 0x40000000</term>
	/// <term>Perform an AND operation on QueryFlags.</term>
	/// </item>
	/// <item>
	/// <term>DEVICEPOWER_FILTER_WAKEENABLED 0x08000000</term>
	/// <term>Check whether the device is currently enabled to wake the system from a sleep state.</term>
	/// </item>
	/// <item>
	/// <term>DEVICEPOWER_FILTER_ON_NAME 0x02000000</term>
	/// <term>Find a device whose name matches the string passed in pReturnBuffer and check its capabilities against QueryFlags.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="QueryFlags">
	/// <para>The query criteria.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PDCAP_D0_SUPPORTED 0x00000001</term>
	/// <term>The device supports system power state D0.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_D1_SUPPORTED 0x00000002</term>
	/// <term>The device supports system power state D1.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_D2_SUPPORTED 0x00000004</term>
	/// <term>The device supports system power state D2.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_D3_SUPPORTED 0x00000008</term>
	/// <term>The device supports system power state D3.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S0_SUPPORTED 0x00010000</term>
	/// <term>The device supports system sleep state S0.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S1_SUPPORTED 0x00020000</term>
	/// <term>The device supports system sleep state S1.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S2_SUPPORTED 0x00040000</term>
	/// <term>The device supports system sleep state S2.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S3_SUPPORTED 0x00080000</term>
	/// <term>The device supports system sleep state S3.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S4_SUPPORTED 0x01000000</term>
	/// <term>The device supports system sleep state S4.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_S5_SUPPORTED 0x02000000</term>
	/// <term>The device supports system sleep state S5.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_D0_SUPPORTED 0x00000010</term>
	/// <term>The device supports waking from system power state D0.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_D1_SUPPORTED 0x00000020</term>
	/// <term>The device supports waking from system power state D1.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_D2_SUPPORTED 0x00000040</term>
	/// <term>The device supports waking from system power state D2.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_D3_SUPPORTED 0x00000080</term>
	/// <term>The device supports waking from system power state D3.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_S0_SUPPORTED 0x00100000</term>
	/// <term>The device supports waking from system sleep state S0.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_S1_SUPPORTED 0x00200000</term>
	/// <term>The device supports waking from system sleep state S1.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_S2_SUPPORTED 0x00400000</term>
	/// <term>The device supports waking from system sleep state S2.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WAKE_FROM_S3_SUPPORTED 0x00800000</term>
	/// <term>The device supports waking from system sleep state S3.</term>
	/// </item>
	/// <item>
	/// <term>PDCAP_WARM_EJECT_SUPPORTED 0x00000100</term>
	/// <term>The device supports warm eject.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReturnBuffer">Pointer to a buffer that receives the requested information.</param>
	/// <param name="pBufferSize">
	/// <para>The size, in bytes, of the return buffer.</para>
	/// <para><c>Note</c> If pReturnBuffer is <c>NULL</c>, pBufferSize will be filled with the size needed to return the data.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The values of the QueryFlags parameter may be combined to query for devices that support two or more criteria. For example; if
	/// <c>PDCAP_D3_SUPPORTED</c> | <c>PDCAP_D1_SUPPORTED</c> is passed as the QueryFlags parameter, the function will query for devices
	/// that support either D3 or D1.
	/// </para>
	/// <para>
	/// QueryFlags also may be combined with QueryInterpretationFlags set to <c>DEVICEPOWER_AND_OPERATION</c> to produce a query of
	/// devices that support all of the requested criteria. For example; if <c>PDCAP_D3_SUPPORTED</c> | <c>PDCAP_D1_SUPPORTED</c> is
	/// passed as the QueryFlags parameter and <c>DEVICEPOWER_AND_OPERATION</c> is passed as the QueryInterpretationFlags parameter, the
	/// function will query devices that support both D3 and D1.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Using the Device Power API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-devicepowerenumdevices BOOLEAN DevicePowerEnumDevices(
	// ULONG QueryIndex, ULONG QueryInterpretationFlags, ULONG QueryFlags, PBYTE pReturnBuffer, PULONG pBufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "bb67634c-69d9-4194-ac27-4f9740d73a1a")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool DevicePowerEnumDevices(uint QueryIndex, PDQUERY QueryInterpretationFlags, PDCAP QueryFlags, StringBuilder pReturnBuffer, ref uint pBufferSize);

	/// <summary>Initializes a device list by querying all the devices.</summary>
	/// <param name="DebugMask">Reserved; must be 0.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-devicepoweropen BOOLEAN DevicePowerOpen( ULONG DebugMask );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "1f0e8ee6-cd9e-468a-ba9a-f11e17852f89")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool DevicePowerOpen(uint DebugMask = 0);

	/// <summary>Modifies the specified data on the specified device.</summary>
	/// <param name="DeviceDescription">The name or hardware identifier string of the device to be modified.</param>
	/// <param name="SetFlags">
	/// <para>The properties of the device that are to be modified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DEVICEPOWER_SET_WAKEENABLED 0x00000001</term>
	/// <term>Enables the specified device to wake the system.</term>
	/// </item>
	/// <item>
	/// <term>DEVICEPOWER_CLEAR_WAKEENABLED 0x00000002</term>
	/// <term>Stops the specified device from being able to wake the system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SetData">Reserved, must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-devicepowersetdevicestate DWORD
	// DevicePowerSetDeviceState( LPCWSTR DeviceDescription, ULONG SetFlags, PVOID SetData );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "300842ae-d7d4-42c2-959c-e1713f466d32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DevicePowerSetDeviceState([MarshalAs(UnmanagedType.LPWStr)] string DeviceDescription, PDSET SetFlags, IntPtr SetData = default);

	/// <summary>
	/// <para>
	/// [ <c>EnumPwrSchemes</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. Applications written for Windows Vista and later should use PowerEnumerate instead.]
	/// </para>
	/// <para>
	/// Enumerates all power schemes. For each power scheme enumerated, the function calls a callback function with information about the
	/// power scheme.
	/// </para>
	/// </summary>
	/// <param name="lpfn">
	/// <para>A pointer to a callback function to be called for each power scheme enumerated. For more information, see Remarks.</para>
	/// </param>
	/// <param name="lParam">
	/// <para>A user-defined value to be passed to the callback function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For each power scheme enumerated, the callback function is called with the following parameters:</para>
	/// <para>
	/// The sName and sDesc parameters are null-terminated Unicode strings. The pp parameter is a pointer to a POWER_POLICY structure
	/// containing the power policy scheme. To continue until all power schemes have been enumerated, the callback function must return
	/// <c>TRUE</c>. To stop the enumeration, the callback function must return <c>FALSE</c>.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-enumpwrschemes BOOLEAN EnumPwrSchemes(
	// PWRSCHEMESENUMPROC lpfn, LPARAM lParam );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "5e9e10b4-84c3-40ec-8de9-220d13795403")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool EnumPwrSchemes(PWRSCHEMESENUMPROC lpfn, [Optional] IntPtr lParam);

	/// <summary>
	/// <para>
	/// [ <c>GetActivePwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use PowerGetActiveScheme instead.]
	/// </para>
	/// <para>Retrieves the index of the active power scheme.</para>
	/// </summary>
	/// <param name="puiID">A pointer to a variable that receives the index of the active power scheme.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The active power scheme remains active until either the user sets a new power scheme using the Power Options control panel
	/// program, or an application calls the SetActivePwrScheme function.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-getactivepwrscheme BOOLEAN GetActivePwrScheme( PUINT
	// puiID );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "2a321372-40ff-4292-8b66-db3f794e5f53")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool GetActivePwrScheme(out uint puiID);

	/// <summary>Retrieves the current system power policy settings.</summary>
	/// <param name="pGlobalPowerPolicy">
	/// A pointer to a GLOBAL_POWER_POLICY structure that receives the current global power policy settings.
	/// </param>
	/// <param name="pPowerPolicy">
	/// A pointer to a POWER_POLICY structure that receives the power policy settings that are unique to the active power scheme.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To update the current power policy settings, call the WriteGlobalPwrPolicy or WritePwrScheme functions.</para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-getcurrentpowerpolicies BOOLEAN GetCurrentPowerPolicies(
	// PGLOBAL_POWER_POLICY pGlobalPowerPolicy, PPOWER_POLICY pPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "9a834fb6-35ae-4d36-885c-0d81cd39e9a6")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool GetCurrentPowerPolicies(out GLOBAL_POWER_POLICY pGlobalPowerPolicy, out POWER_POLICY pPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>GetPwrDiskSpindownRange</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Retrieves the disk spin-down range.</para>
	/// </summary>
	/// <param name="puiMax">The maximum disk spin-down time, in seconds.</param>
	/// <param name="puiMin">The minimum disk spin-down time, in seconds.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Starting with Windows Vista, power management configuration of the system's hard disk drives is controlled through the
	/// GUID_DISK_SUBGROUP power settings subgroup. Use the PowerEnumerate function to enumerate individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-getpwrdiskspindownrange BOOLEAN GetPwrDiskSpindownRange(
	// PUINT puiMax, PUINT puiMin );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "c56f679d-512a-4bf9-89dc-8905bba8c6ce")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool GetPwrDiskSpindownRange(out uint puiMax, out uint puiMin);

	/// <summary>
	/// <para>
	/// [ <c>IsPwrHibernateAllowed</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use GetPwrCapabilities instead.]
	/// </para>
	/// <para>Determines whether the computer supports hibernation.</para>
	/// </summary>
	/// <returns>
	/// If the computer supports hibernation (power state S4) and the file Hiberfil.sys is present on the system, the function returns
	/// <c>TRUE</c>. Otherwise, the function returns <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This information is also available through the CallNtPowerInformation function. The value is returned in the <c>SystemS4</c>
	/// member of the SYSTEM_POWER_CAPABILITIES structure.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-ispwrhibernateallowed BOOLEAN IsPwrHibernateAllowed( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "fe9d06a8-c021-4cf4-9782-04519f370c5b")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool IsPwrHibernateAllowed();

	/// <summary>
	/// <para>
	/// [ <c>IsPwrShutdownAllowed</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Determines whether the computer supports the soft off power state.</para>
	/// </summary>
	/// <returns>
	/// If the computer supports soft off (power state S5), the function returns <c>TRUE</c>. Otherwise, the function returns <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This information is also available through the CallNtPowerInformation function. The value is returned in the <c>SystemS5</c>
	/// member of the SYSTEM_POWER_CAPABILITIES structure.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, computers must support the soft off power state. Therefore, this function is relevant only to
	/// Windows Server 2003 and earlier operating systems.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-ispwrshutdownallowed BOOLEAN IsPwrShutdownAllowed( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "e48d6f67-225b-40f7-902b-0e65112303b9")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool IsPwrShutdownAllowed();

	/// <summary>
	/// <para>
	/// [ <c>IsPwrSuspendAllowed</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use GetPwrCapabilities instead.]
	/// </para>
	/// <para>Determines whether the computer supports the sleep states.</para>
	/// </summary>
	/// <returns>
	/// If the computer supports the sleep states (S1, S2, and S3), the function returns <c>TRUE</c>. Otherwise, the function returns <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This information is also available through the CallNtPowerInformation function. Check the <c>SystemS1</c>, <c>SystemS2</c>, and
	/// <c>SystemS3</c> members of the SYSTEM_POWER_CAPABILITIES structure.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-ispwrsuspendallowed BOOLEAN IsPwrSuspendAllowed( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "66ef2402-b1b8-432e-b47d-240d255fc907")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool IsPwrSuspendAllowed();

	/// <summary>
	/// Determines if the current user has access to the data for the specified power scheme so that it could be restored if necessary.
	/// </summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powercanrestoreindividualdefaultpowerscheme DWORD
	// PowerCanRestoreIndividualDefaultPowerScheme( const GUID *SchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "8f29c993-b237-4302-a48b-05368ead9a44")]
	public static extern Win32Error PowerCanRestoreIndividualDefaultPowerScheme(in Guid SchemeGuid);

	/// <summary>Creates a possible setting value for a specified power setting.</summary>
	/// <param name="RootSystemPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h.</para>
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being created.</param>
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting being created.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powercreatepossiblesetting DWORD
	// PowerCreatePossibleSetting( HKEY RootSystemPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG
	// PossibleSettingIndex );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "a7297dbe-8ea5-4097-a0b3-2740f99acbaf")]
	public static extern Win32Error PowerCreatePossibleSetting([Optional] HKEY RootSystemPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint PossibleSettingIndex);

	/// <summary>Creates a setting value for a specified power setting.</summary>
	/// <param name="RootSystemPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h.</para>
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being created.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powercreatesetting DWORD PowerCreateSetting( HKEY
	// RootSystemPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "84b46096-a83b-4041-8ecb-e95c6189480b")]
	public static extern Win32Error PowerCreateSetting([Optional] HKEY RootSystemPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid);

	/// <summary>Deletes the specified power scheme from the database.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerdeletescheme DWORD PowerDeleteScheme( HKEY
	// RootPowerKey, const GUID *SchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "5f9969a1-e598-4ca8-a5b8-f8bb3410223d")]
	public static extern Win32Error PowerDeleteScheme([Optional] HKEY RootPowerKey, in Guid SchemeGuid);

	/// <summary>
	/// <para>
	/// Determines the computer role for Windows 7, Windows Server 2008 R2, Windows Vista or Windows Server 2008. To specify a different
	/// platform, use the PowerDeterminePlatformRoleEx function.
	/// </para>
	/// <para>To query additional power platform roles defined after Windows 7 and Windows Server 2008 R2, use PowerDeterminePlatformRoleEx.</para>
	/// </summary>
	/// <returns>
	/// <para>The return value is one of the values from the POWER_PLATFORM_ROLE enumeration.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function reads the ACPI Fixed ACPI Description Table (FADT) to determine the OEM preferred computer role. If that
	/// information is not available, the function looks for a battery. If at least one battery is available, the function returns
	/// <c>PlatformRoleMobile</c>. If no batteries are available, the function returns <c>PlatformRoleDesktop</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> This API has a newer version. To query additional power platform roles defined after Windows 7 and Windows Server
	/// 2008 R2, use PowerDeterminePlatformRoleEx.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerdetermineplatformrole POWER_PLATFORM_ROLE
	// PowerDeterminePlatformRole( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "a0311454-3908-49a6-95c0-c118dca259ac")]
	public static extern POWER_PLATFORM_ROLE PowerDeterminePlatformRole();

	/// <summary>Duplicates an existing power scheme.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SourceSchemeGuid">The identifier of the power scheme that is to be duplicated.</param>
	/// <param name="DestinationSchemeGuid">
	/// The address of a pointer to a <c>GUID</c>. If the pointer contains <c>NULL</c>, the function allocates memory for a new
	/// <c>GUID</c> and puts the address of this memory in the pointer. The caller can free this memory using LocalFree.
	/// </param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0 (0x0)</term>
	/// <term>The power scheme was successfully duplicated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87 (0x57)</term>
	/// <term>One of the parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_EXISTS 183 (0xB7)</term>
	/// <term>The DestinationSchemeGuid parameter refers to an existing power scheme. PowerDeleteScheme can be used to delete this scheme.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerduplicatescheme DWORD PowerDuplicateScheme( HKEY
	// RootPowerKey, const GUID *SourceSchemeGuid, GUID **DestinationSchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "e58dee69-309c-4b52-bf28-f54b300801b9")]
	public static extern Win32Error PowerDuplicateScheme([Optional] HKEY RootPowerKey, in Guid SourceSchemeGuid, out SafeLocalHandle DestinationSchemeGuid);

	/// <summary>
	/// Enumerates the specified elements in a power scheme. This function is normally called in a loop incrementing the Index parameter
	/// to retrieve subkeys until they've all been enumerated.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">
	/// The identifier of the power scheme. If this parameter is <c>NULL</c>, an enumeration of the power policies is returned.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. If this parameter is <c>NULL</c>, an enumeration of settings under the <c>PolicyGuid</c> key is returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUID fea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup will be part of the default power scheme.</term>
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
	/// <param name="AccessFlags">
	/// <para>A set of flags that specifies what will be enumerated</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ACCESS_SCHEME 16</term>
	/// <term>Enumerate power schemes. The SchemeGuid and SubgroupOfPowerSettingsGuid parameters will be ignored.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SUBGROUP 17</term>
	/// <term>Enumerate subgroups under SchemeGuid. The SubgroupOfPowerSettingsGuid parameter will be ignored.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_INDIVIDUAL_SETTING 18</term>
	/// <term>
	/// Enumerate individual power settings under SchemeGuid\SubgroupOfPowerSettingsGuid. To enumerate power settings directly under the
	/// SchemeGuid key, use NO_SUBGROUP_GUID as the SubgroupOfPowerSettingsGuid parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Index">The zero-based index of the scheme, subgroup, or setting that is being enumerated.</param>
	/// <param name="Buffer">
	/// A pointer to a variable to receive the elements. If this parameter is <c>NULL</c>, the function retrieves the size of the buffer required.
	/// </param>
	/// <param name="BufferSize">
	/// A pointer to a variable that on input contains the size of the buffer pointed to by the Buffer parameter. If the Buffer parameter
	/// is <c>NULL</c> or if the BufferSize is not large enough, the function will return <c>ERROR_MORE_DATA</c> and the variable
	/// receives the required buffer size.
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed. If the buffer size passed
	/// in the BufferSize parameter is too small, or if the Buffer parameter is <c>NULL</c>, <c>ERROR_MORE_DATA</c> will be returned and
	/// the <c>DWORD</c> pointed to by the BufferSize parameter will be filled in with the required buffer size.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerenumerate DWORD PowerEnumerate( HKEY RootPowerKey,
	// const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, POWER_DATA_ACCESSOR AccessFlags, ULONG Index, UCHAR *Buffer,
	// DWORD *BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "5b2c8263-d916-4909-be56-ec784537bdc3")]
	public static extern Win32Error PowerEnumerate([Optional] HKEY RootPowerKey, [Optional, In] IntPtr SchemeGuid, [Optional, In] IntPtr SubGroupOfPowerSettingsGuid, POWER_DATA_ACCESSOR AccessFlags, uint Index, IntPtr Buffer, ref uint BufferSize);

	/// <summary>
	/// Enumerates the specified elements in a power scheme. This function is normally called in a loop incrementing the Index parameter
	/// to retrieve subkeys until they've all been enumerated.
	/// </summary>
	/// <param name="SchemeGuid">
	/// The identifier of the power scheme. If this parameter is <c>NULL</c>, an enumeration of the power policies is returned.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. If this parameter is <c>NULL</c>, an enumeration of settings under the <c>PolicyGuid</c> key is returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NO_SUBGROUP_GUID fea3413e-7e05-4911-9a71-700331f1c294</term>
	/// <term>Settings in this subgroup will be part of the default power scheme.</term>
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
	/// <param name="AccessFlags">
	/// <para>A set of flags that specifies what will be enumerated</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ACCESS_SCHEME 16</term>
	/// <term>Enumerate power schemes. The SchemeGuid and SubgroupOfPowerSettingsGuid parameters will be ignored.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SUBGROUP 17</term>
	/// <term>Enumerate subgroups under SchemeGuid. The SubgroupOfPowerSettingsGuid parameter will be ignored.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_INDIVIDUAL_SETTING 18</term>
	/// <term>
	/// Enumerate individual power settings under SchemeGuid\SubgroupOfPowerSettingsGuid. To enumerate power settings directly under the
	/// SchemeGuid key, use NO_SUBGROUP_GUID as the SubgroupOfPowerSettingsGuid parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed. If the buffer size passed
	/// in the BufferSize parameter is too small, or if the Buffer parameter is <c>NULL</c>, <c>ERROR_MORE_DATA</c> will be returned and
	/// the <c>DWORD</c> pointed to by the BufferSize parameter will be filled in with the required buffer size.
	/// </returns>
	public static IEnumerable<T> PowerEnumerate<T>(Guid? SchemeGuid, Guid? SubGroupOfPowerSettingsGuid, POWER_DATA_ACCESSOR AccessFlags = (POWER_DATA_ACCESSOR)(-1)) where T : struct
	{
		if (AccessFlags == (POWER_DATA_ACCESSOR)(-1))
			AccessFlags = SchemeGuid is null ? POWER_DATA_ACCESSOR.ACCESS_SCHEME : (SubGroupOfPowerSettingsGuid is null ? POWER_DATA_ACCESSOR.ACCESS_SUBGROUP : POWER_DATA_ACCESSOR.ACCESS_INDIVIDUAL_SETTING);
		var l = new List<T>();
		PwrGuidTsl(SchemeGuid, SubGroupOfPowerSettingsGuid, null, (p1, p2, p3) => {
			var checkSize = true;
			for (var i = 0U; ; i++)
			{
				var sz = 0U;
				var err = PowerEnumerate(default, p1, p2, AccessFlags, i, IntPtr.Zero, ref sz);
				if (err == Win32Error.ERROR_NO_MORE_ITEMS)
					break;
				if (err != Win32Error.ERROR_MORE_DATA)
					return err;
				if (checkSize && sz < Marshal.SizeOf(typeof(T))) throw new ArgumentException("Size mismatch between returned value and size of T.", nameof(T));
				checkSize = false;
				using (var mem = new SafeHGlobalHandle((int)sz))
				{
					err = PowerEnumerate(default, p1, p2, AccessFlags, i, (IntPtr)mem, ref sz);
					if (err.Failed) return err;
					l.Add(mem.ToStructure<T>());
				}
			}
			return Win32Error.ERROR_SUCCESS;
		}).ThrowIfFailed();
		return l;
	}

	/// <summary>Imports a power scheme from a file.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="ImportFileNamePath">The path to a power scheme backup file created by <c>PowerCfg.Exe /Export</c>.</param>
	/// <param name="DestinationSchemeGuid">
	/// A pointer to a pointer to a <c>GUID</c>. If the pointer contains <c>NULL</c>, the function allocates memory for a new <c>GUID</c>
	/// and puts the address of this memory in the pointer. The caller can free this memory using LocalFree.
	/// </param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerimportpowerscheme DWORD PowerImportPowerScheme(
	// HKEY RootPowerKey, LPCWSTR ImportFileNamePath, GUID **DestinationSchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "84ba8cb6-13ad-459b-b154-c495aaeb67f3")]
	public static extern Win32Error PowerImportPowerScheme([Optional] HKEY RootPowerKey, [MarshalAs(UnmanagedType.LPWStr)] string ImportFileNamePath, out SafeLocalHandle DestinationSchemeGuid);

	/// <summary>Queries whether the specified power setting represents a range of possible values.</summary>
	/// <param name="SubKeyGuid">The identifier of the subkey to search.</param>
	/// <param name="SettingGuid">The identifier of the power setting to query.</param>
	/// <returns>
	/// <para>TRUE if the registry key specified by SubKeyGuid represents a single power setting.</para>
	/// <para>If the registry key specified by SubKeyGuid represents a range, this function returns FALSE.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerissettingrangedefined BOOLEAN
	// PowerIsSettingRangeDefined( const GUID *SubKeyGuid, const GUID *SettingGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "7babaf7b-ecb3-4b29-917e-2ed63bad4a38")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool PowerIsSettingRangeDefined(in Guid SubKeyGuid, in Guid SettingGuid);

	/// <summary>Retrieves the default AC index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemePersonalityGuid">
	/// The identifier for the scheme personality for this power setting. A power setting can have different default values depending on
	/// the power scheme personality.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to retrieve the setting for the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier for the single power setting.</param>
	/// <param name="AcDefaultIndex">A pointer to a variable that receives the default AC index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// DWORD WINAPI PowerReadACDefaultIndex( _In_opt_ HKEY RootPowerKey, _In_ const GUID *SchemePersonalityGuid, _In_opt_ const GUID
	// *SubGroupOfPowerSettingsGuid, _In_ const GUID *PowerSettingGuid, _Out_ LPDWORD AcDefaultIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372733(v=vs.85).aspx
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("PowrProf.h", MSDNShortId = "aa372733")]
	public static extern Win32Error PowerReadACDefaultIndex([Optional] HKEY RootPowerKey, in Guid SchemePersonalityGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint AcDefaultIndex);

	/// <summary>Retrieves the AC index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="AcValueIndex">A pointer to a variable that receives the AC value index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadacvalueindex DWORD PowerReadACValueIndex( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, LPDWORD AcValueIndex );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "e8760e78-78cd-4652-94b1-f42a72df5db2")]
	public static extern Win32Error PowerReadACValueIndex([Optional] HKEY RootPowerKey, in Guid SchemeGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint AcValueIndex);

	/// <summary>Retrieves the default DC index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemePersonalityGuid">
	/// The identifier of the scheme personality for this power setting. A power setting can have different default values depending on
	/// the power scheme personality.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to retrieve the setting for the default power scheme.
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
	/// <param name="DcDefaultIndex">A pointer to a variable that receives the default DC index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// DWORD WINAPI PowerReadDCDefaultIndex( _In_opt_ HKEY RootPowerKey, _In_ const GUID *SchemePersonalityGuid, _In_opt_ const GUID
	// *SubGroupOfPowerSettingsGuid, _In_ const GUID *PowerSettingGuid, _Out_ LPDWORD DcDefaultIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372736(v=vs.85).aspx
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("PowrProf.h", MSDNShortId = "aa372736")]
	public static extern Win32Error PowerReadDCDefaultIndex([Optional] HKEY RootPowerKey, in Guid SchemePersonalityGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint DcDefaultIndex);

	/// <summary>Retrieves the DC value index of the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>The identifier of the subgroup of power settings. Use <c>NO_SUBGROUP_GUID</c> to refer to the default power scheme.</para>
	/// <para>These values are the subgroup values included with Windows.</para>
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
	/// <param name="DcValueIndex">A pointer to a variable that receives the DC value index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreaddcvalueindex DWORD PowerReadDCValueIndex( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, LPDWORD DcValueIndex );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "91ba83bd-3e28-4933-a1ad-0cd8414fee37")]
	public static extern Win32Error PowerReadDCValueIndex([Optional] HKEY RootPowerKey, in Guid SchemeGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint DcValueIndex);

	/// <summary>
	/// Retrieves the description for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c>
	/// but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the description of the power scheme
	/// will be returned. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid
	/// parameter is <c>NULL</c>, the description of the subgroup will be returned. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and
	/// PowerSettingGuid parameters are not <c>NULL</c>, the description of the power setting will be returned.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the description. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size. The strings returned are all wide (Unicode) strings.
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
	/// specified by the BufferSize parameter is too small, the function returns <c>ERROR_SUCCESS</c> and the <c>DWORD</c> pointed to by
	/// the BufferSize parameter is filled in with the required buffer size.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreaddescription
	// DWORD PowerReadDescription( HKEY RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PUCHAR Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "3c264f4f-fd1b-466b-ba76-fe78593a3628")]
	public static extern Win32Error PowerReadDescription([Optional] HKEY RootPowerKey, [In] IntPtr SchemeGuid, [In] IntPtr SubGroupOfPowerSettingsGuid, [In] IntPtr PowerSettingGuid, IntPtr Buffer, ref uint BufferSize);

	/// <summary>
	/// Retrieves the description for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c>
	/// but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the description of the power scheme
	/// will be returned. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid
	/// parameter is <c>NULL</c>, the description of the subgroup will be returned. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and
	/// PowerSettingGuid parameters are not <c>NULL</c>, the description of the power setting will be returned.
	/// </summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <returns>
	/// The description.
	/// </returns>
	[PInvokeData("powrprof.h", MSDNShortId = "3c264f4f-fd1b-466b-ba76-fe78593a3628")]
	public static string PowerReadDescription([In] Guid? SchemeGuid = null, [In] Guid? SubGroupOfPowerSettingsGuid = null, [In] Guid? PowerSettingGuid = null) =>
		PwrReadMem(PowerReadDescription, SchemeGuid, SubGroupOfPowerSettingsGuid, PowerSettingGuid)?.ToString(-1) ?? string.Empty;

	/// <summary>
	/// Retrieves the friendly name for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c>
	/// but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the friendly name of the power scheme
	/// will be returned. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid
	/// parameter is <c>NULL</c>, the friendly name of the subgroup will be returned. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and
	/// PowerSettingGuid parameters are not <c>NULL</c>, the friendly name of the power setting will be returned.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>The subgroup of power settings. Use <c>NO_SUBGROUP_GUID</c> to refer to the default power scheme.</para>
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the friendly name. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size. The strings returned are all wide (Unicode) strings.
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadfriendlyname DWORD PowerReadFriendlyName( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PUCHAR Buffer,
	// LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "e6e46bbf-f9be-4dee-8976-df48bb1ccdf4")]
	public static extern Win32Error PowerReadFriendlyName([Optional] HKEY RootPowerKey, [In] IntPtr SchemeGuid, [In] IntPtr SubGroupOfPowerSettingsGuid, [In] IntPtr PowerSettingGuid, IntPtr Buffer, ref uint BufferSize);

	/// <summary>
	/// Retrieves the friendly name for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c>
	/// but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the friendly name of the power scheme
	/// will be returned. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid
	/// parameter is <c>NULL</c>, the friendly name of the subgroup will be returned. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and
	/// PowerSettingGuid parameters are not <c>NULL</c>, the friendly name of the power setting will be returned.
	/// </summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid"><para>The subgroup of power settings. Use <c>NO_SUBGROUP_GUID</c> to refer to the default power scheme.</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Value</term>
	///     <term>Meaning</term>
	///   </listheader>
	///   <item>
	///     <term>NO_SUBGROUP_GUID fea3413e-7e05-4911-9a71-700331f1c294</term>
	///     <term>Settings in this subgroup are part of the default power scheme.</term>
	///   </item>
	///   <item>
	///     <term>GUID_DISK_SUBGROUP 0012ee47-9041-4b5d-9b77-535fba8b1442</term>
	///     <term>Settings in this subgroup control power management configuration of the system's hard disk drives.</term>
	///   </item>
	///   <item>
	///     <term>GUID_SYSTEM_BUTTON_SUBGROUP 4f971e89-eebd-4455-a8de-9e59040e7347</term>
	///     <term>Settings in this subgroup control configuration of the system power buttons.</term>
	///   </item>
	///   <item>
	///     <term>GUID_PROCESSOR_SETTINGS_SUBGROUP 54533251-82be-4824-96c1-47b60b740d00</term>
	///     <term>Settings in this subgroup control configuration of processor power management features.</term>
	///   </item>
	///   <item>
	///     <term>GUID_VIDEO_SUBGROUP 7516b95f-f776-4464-8c53-06167f40cc99</term>
	///     <term>Settings in this subgroup control configuration of the video power management features.</term>
	///   </item>
	///   <item>
	///     <term>GUID_BATTERY_SUBGROUP e73a048d-bf27-4f12-9731-8b2076e8891f</term>
	///     <term>Settings in this subgroup control battery alarm trip points and actions.</term>
	///   </item>
	///   <item>
	///     <term>GUID_SLEEP_SUBGROUP 238C9FA8-0AAD-41ED-83F4-97BE242C8F20</term>
	///     <term>Settings in this subgroup control system sleep settings.</term>
	///   </item>
	///   <item>
	///     <term>GUID_PCIEXPRESS_SETTINGS_SUBGROUP 501a4d13-42af-4429-9fd1-a8218c268e20</term>
	///     <term>Settings in this subgroup control PCI Express settings.</term>
	///   </item>
	/// </list></param>
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <returns>The friendly name.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadfriendlyname DWORD PowerReadFriendlyName( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PUCHAR Buffer,
	// LPDWORD BufferSize );
	[PInvokeData("powrprof.h", MSDNShortId = "e6e46bbf-f9be-4dee-8976-df48bb1ccdf4")]
	public static string PowerReadFriendlyName([In] Guid? SchemeGuid = null, [In] Guid? SubGroupOfPowerSettingsGuid = null, [In] Guid? PowerSettingGuid = null) =>
		PwrReadMem(PowerReadFriendlyName, SchemeGuid, SubGroupOfPowerSettingsGuid, PowerSettingGuid)?.ToString(-1) ?? string.Empty;

	/// <summary>
	/// Retrieves the icon resource for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c>
	/// but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the friendly name of the power scheme
	/// will be returned. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid
	/// parameter is <c>NULL</c>, the friendly name of the subgroup will be returned. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and
	/// PowerSettingGuid parameters are not <c>NULL</c>, the friendly name of the power setting will be returned.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the icon resource. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadiconresourcespecifier DWORD
	// PowerReadIconResourceSpecifier( HKEY RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID
	// *PowerSettingGuid, PUCHAR Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "d9454acd-7a4a-4f54-b614-beee8763f1ef")]
	public static extern Win32Error PowerReadIconResourceSpecifier([Optional] HKEY RootPowerKey, [In] IntPtr SchemeGuid, [In] IntPtr SubGroupOfPowerSettingsGuid, [In] IntPtr PowerSettingGuid, IntPtr Buffer, ref uint BufferSize);

	/// <summary>Retrieves the description for one of the possible choices of a power setting value.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the description. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size. The strings returned are all wide (Unicode) strings.
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
	/// specified by the BufferSize parameter is too small,
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadpossibledescription DWORD
	// PowerReadPossibleDescription( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG
	// PossibleSettingIndex, PUCHAR Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "e803dc6b-706a-49fc-8c8d-ba9b0ccf8491")]
	public static extern Win32Error PowerReadPossibleDescription([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint PossibleSettingIndex, StringBuilder Buffer, ref uint BufferSize);

	/// <summary>Retrieves the friendly name for one of the possible choices of a power setting value.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the friendly name. If this parameter is <c>NULL</c>, the BufferSize parameter receives the
	/// required buffer size. The strings returned are all wide (Unicode) strings.
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
	/// specified by the BufferSize parameter is too small,
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadpossiblefriendlyname DWORD
	// PowerReadPossibleFriendlyName( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG
	// PossibleSettingIndex, PUCHAR Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "38f3c5f4-ec65-47f0-b15c-36cd2b1e2813")]
	public static extern Win32Error PowerReadPossibleFriendlyName([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint PossibleSettingIndex, StringBuilder Buffer, ref uint BufferSize);

	/// <summary>Retrieves the value for a possible value of a power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PossibleSettingIndex">The zero-based index of the possible setting.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the value. If this parameter is <c>NULL</c>, the BufferSize parameter receives the required
	/// buffer size.
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
	/// specified by the BufferSize parameter is too small,
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadpossiblevalue DWORD PowerReadPossibleValue(
	// HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, PULONG Type, ULONG PossibleSettingIndex,
	// PUCHAR Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "453f3db0-537d-4f24-a62c-d12b44b5e019")]
	public static extern Win32Error PowerReadPossibleValue([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out REG_VALUE_TYPE Type, uint PossibleSettingIndex, IntPtr Buffer, ref uint BufferSize);

	/// <summary>
	/// Returns the current attribute of the specified power setting. If the SubGroupGuid parameter is <c>NULL</c> then the attribute for
	/// PowerSettingGuid is returned. If the PowerSettingGuid parameter is <c>NULL</c> then the attribute for SubGroupGuid is returned.
	/// If both the SubGroupGuid and PowerSettingGuid parameters are valid then the return value is the combination (bitwise OR) of the
	/// attributes of the subgroup and the power setting.
	/// </summary>
	/// <param name="SubGroupGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
	/// </para>
	/// <para>These values are the subgroup values included with Windows.</para>
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <returns>
	/// <para>
	/// Returns the current power setting attributes of the specified power setting. The attribute is a combination of the attributes of
	/// the power setting and the attributes of its subgroup.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>POWER_ATTRIBUTE_HIDE 1</term>
	/// <term>Hide this power setting.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadsettingattributes DWORD
	// PowerReadSettingAttributes( const GUID *SubGroupGuid, const GUID *PowerSettingGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "9f430da2-7c8d-43e2-ab8a-d9af1bb7538f")]
	public static extern POWER_ATTR PowerReadSettingAttributes(in Guid SubGroupGuid, in Guid PowerSettingGuid);

	/// <summary>
	/// Retrieves the increment for valid values between the power settings minimum and maximum. If the power setting is not defined with
	/// a range of possible values then this function will return an error.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="ValueIncrement">A pointer to a variable that receives the increment for the specified power setting.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadvalueincrement DWORD PowerReadValueIncrement(
	// HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, LPDWORD ValueIncrement );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "f5aa19c5-67ea-4a87-be87-b3bf3d9dd5a4")]
	public static extern Win32Error PowerReadValueIncrement([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint ValueIncrement);

	/// <summary>Retrieves the maximum value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="ValueMaximum">A pointer to a variable that receives the maximum for the specified power setting.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadvaluemax DWORD PowerReadValueMax( HKEY
	// RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, LPDWORD ValueMaximum );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "577c7726-cba5-492b-9c9b-bbd815a70ddf")]
	public static extern Win32Error PowerReadValueMax([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint ValueMaximum);

	/// <summary>Retrieves the minimum value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="ValueMinimum">A pointer to a variable that receives the minimum value for the specified power setting.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadvaluemin DWORD PowerReadValueMin( HKEY
	// RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, LPDWORD ValueMinimum );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "4a28cc2e-359b-45b3-8d2f-2f88baebb9c1")]
	public static extern Win32Error PowerReadValueMin([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, out uint ValueMinimum);

	/// <summary>
	/// Reads the string used to describe the units of a power setting that supports a range of values. For example "minutes" may be used
	/// to describe a timeout setting.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives the string. If this parameter is <c>NULL</c>, the BufferSize parameter receives the required
	/// buffer size. The strings returned are all wide (Unicode) strings.
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
	/// specified by the BufferSize parameter is too small,
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreadvalueunitsspecifier DWORD
	// PowerReadValueUnitsSpecifier( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, UCHAR
	// *Buffer, LPDWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "48ad80b7-f89a-4dad-a991-056ce41d6975")]
	public static extern Win32Error PowerReadValueUnitsSpecifier([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, StringBuilder Buffer, ref uint BufferSize);

	/// <summary>Deletes the specified power setting.</summary>
	/// <param name="PowerSettingSubKeyGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting to be deleted.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerremovepowersetting DWORD PowerRemovePowerSetting(
	// const GUID *PowerSettingSubKeyGuid, const GUID *PowerSettingGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "f78e3dfa-549c-4536-a486-cafc43717ee9")]
	public static extern Win32Error PowerRemovePowerSetting(in Guid PowerSettingSubKeyGuid, in Guid PowerSettingGuid);

	/// <summary>
	/// Replaces the default power schemes with the current user's power schemes. This allows an administrator to change the default
	/// power schemes for the system. Replacing the default schemes enables users to use the <c>Restore Defaults</c> option in the
	/// Control Panel <c>Power Options</c> application to restore customized power scheme defaults instead of the original Windows power
	/// scheme defaults.
	/// </summary>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>The caller must be a member of the local Administrators group.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreplacedefaultpowerschemes DWORD
	// PowerReplaceDefaultPowerSchemes( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "0d028ed9-3505-4f08-b064-14cbc8172ce0")]
	public static extern Win32Error PowerReplaceDefaultPowerSchemes();

	/// <summary>Notifies the operating system of thermal events.</summary>
	/// <param name="Event">The thermal event structure, THERMAL_EVENT.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// <para>
	/// Thermal managers call the <c>PowerReportThermalEvent</c> routine to notify the operating system of a thermal event so that the
	/// event can be recorded in the system event log.
	/// </para>
	/// <para>
	/// Before calling <c>PowerReportThermalEvent</c>, the thermal manager sets the members of the THERMAL_EVENT structure to describe
	/// the thermal event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerreportthermalevent DWORD PowerReportThermalEvent(
	// PTHERMAL_EVENT Event );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "DD3DE1B2-17C1-4FF8-9DF8-BEF35933D913")]
	public static extern Win32Error PowerReportThermalEvent(in THERMAL_EVENT Event);

	/// <summary>
	/// Replaces the power schemes for the system with default power schemes. All current power schemes and settings are deleted and
	/// replaced with the default system power schemes.
	/// </summary>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>The caller must be a member of the local Administrators group.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerrestoredefaultpowerschemes DWORD
	// PowerRestoreDefaultPowerSchemes( );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "6d0a6167-34de-439b-afb4-2536c715905c")]
	public static extern Win32Error PowerRestoreDefaultPowerSchemes();

	/// <summary>Replaces a specific power scheme for the current user with one from the default user (stored in <c>HKEY_USERS</c>&lt;b&gt;.Default)</summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerrestoreindividualdefaultpowerscheme DWORD
	// PowerRestoreIndividualDefaultPowerScheme( const GUID *SchemeGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "f1a9cfb1-1b56-4873-994b-7fe929fdc86c")]
	public static extern Win32Error PowerRestoreIndividualDefaultPowerScheme(in Guid SchemeGuid);

	/// <summary>Queries for a group policy override for specified power settings.</summary>
	/// <param name="AccessFlags">
	/// <para>The type of access to check for group policy overrides.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ACCESS_AC_POWER_SETTING_INDEX 0 (0x0)</term>
	/// <term>Check for overrides on AC power settings.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_DC_POWER_SETTING_INDEX 1 (0x1)</term>
	/// <term>Check for overrides on DC power settings.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SCHEME 16 (0x10)</term>
	/// <term>Check for restrictions on specific power schemes.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_ACTIVE_SCHEME 19 (0x13)</term>
	/// <term>Check for restrictions on active power schemes.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_CREATE_SCHEME 20 (0x14)</term>
	/// <term>Check for restrictions on creating or restoring power schemes.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PowerGuid">The identifier of the power setting.</param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0 (0x0)</term>
	/// <term>The specified power setting is not currently overridden by a group policy.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY 1260 (0x4EC)</term>
	/// <term>This program is blocked by group policy. For more information, contact your system administrator.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_REMOTE_DISALLOWED 1640 (0x668)</term>
	/// <term>Only Administrators can remotely access power settings.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powersettingaccesscheck DWORD PowerSettingAccessCheck(
	// POWER_DATA_ACCESSOR AccessFlags, const GUID *PowerGuid );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "0b89c189-b162-44d4-aa50-d78385e40c27")]
	public static extern Win32Error PowerSettingAccessCheck(POWER_DATA_ACCESSOR AccessFlags, in Guid PowerGuid);

	/// <summary>Queries for a group policy override for specified power settings and specifies the requested access for the setting.</summary>
	/// <param name="AccessFlags">
	/// <para>The type of access to check for group policy overrides.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ACCESS_AC_POWER_SETTING_INDEX 0 (0x0)</term>
	/// <term>Check for overrides on AC power settings.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_DC_POWER_SETTING_INDEX 1 (0x1)</term>
	/// <term>Check for overrides on DC power settings.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_SCHEME 16 (0x10)</term>
	/// <term>Check for restrictions on specific power schemes.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_ACTIVE_SCHEME 19 (0x13)</term>
	/// <term>Check for restrictions on active power schemes.</term>
	/// </item>
	/// <item>
	/// <term>ACCESS_CREATE_SCHEME 20 (0x14)</term>
	/// <term>Check for restrictions on creating or restoring power schemes.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PowerGuid">The identifier of the power setting.</param>
	/// <param name="AccessType">
	/// <para>The type of security access for the setting. For more information, see Registry Key Security and Access Rights.</para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KEY_READ</term>
	/// <term>Combines the STANDARD_RIGHTS_READ, KEY_QUERY_VALUE, KEY_ENUMERATE_SUB_KEYS, and KEY_NOTIFY values.</term>
	/// </item>
	/// <item>
	/// <term>KEY_WRITE</term>
	/// <term>Combines the STANDARD_RIGHTS_WRITE, KEY_SET_VALUE, and KEY_CREATE_SUB_KEY access rights.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS 0 (0x0)</term>
	/// <term>The specified power setting is not currently overridden by a group policy.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY 1260 (0x4EC)</term>
	/// <term>This program is blocked by group policy. For more information, contact your system administrator.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_REMOTE_DISALLOWED 1640 (0x668)</term>
	/// <term>Only Administrators can remotely access power settings.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powersettingaccesscheckex DWORD
	// PowerSettingAccessCheckEx( POWER_DATA_ACCESSOR AccessFlags, const GUID *PowerGuid, REGSAM AccessType );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "dad9cca9-5961-48b5-b7d0-4828eca3364b")]
	public static extern Win32Error PowerSettingAccessCheckEx(POWER_DATA_ACCESSOR AccessFlags, in Guid PowerGuid, uint AccessType);

	/// <summary>Sets the default AC index of the specified power setting.</summary>
	/// <param name="RootSystemPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemePersonalityGuid">
	/// The identifier of the scheme personality for this power setting. A power setting can have different default values depending on
	/// the power scheme personality.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="DefaultAcIndex">The default AC index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwriteacdefaultindex DWORD PowerWriteACDefaultIndex(
	// HKEY RootSystemPowerKey, const GUID *SchemePersonalityGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid,
	// DWORD DefaultAcIndex );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "37fd6ddd-3b63-47c8-8ede-63d7e589523d")]
	public static extern Win32Error PowerWriteACDefaultIndex([Optional] HKEY RootSystemPowerKey, in Guid SchemePersonalityGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint DefaultAcIndex);

	/// <summary>Sets the default DC index of the specified power setting.</summary>
	/// <param name="RootSystemPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemePersonalityGuid">
	/// The identifier of the scheme personality for this power setting. A power setting can have different default values depending on
	/// the power scheme personality.
	/// </param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="DefaultDcIndex">The default DC index.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	// DWORD WINAPI PowerWriteDCDefaultIndex( _In_opt_ HKEY RootSystemPowerKey, _In_ const GUID *SchemePersonalityGuid, _In_opt_ const
	// GUID *SubGroupOfPowerSettingsGuid, _In_ const GUID *PowerSettingGuid, _In_ DWORD DefaultDcIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa372767(v=vs.85).aspx
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("PowrProf.h", MSDNShortId = "aa372767")]
	public static extern Win32Error PowerWriteDCDefaultIndex([Optional] HKEY RootSystemPowerKey, in Guid SchemePersonalityGuid, [Optional] in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, [In] uint DefaultDcIndex);

	/// <summary>Sets the description for the specified power setting, subgroup, or scheme.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The description, in wide (Unicode) characters.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// <para>
	/// If the SchemeGuid parameter is not <c>NULL</c> but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are
	/// <c>NULL</c>, the description of the power scheme will be set. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are
	/// not <c>NULL</c> and the PowerSettingGuid parameter is <c>NULL</c>, the description of the subgroup will be set. If the
	/// SchemeGuid, SubGroupOfPowerSettingsGuid, and PowerSettingGuid parameters are not <c>NULL</c>, the description of the power
	/// setting will be set.
	/// </para>
	/// <para>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritedescription DWORD PowerWriteDescription( HKEY
	// RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, UCHAR *Buffer, DWORD
	// BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "42ee26ac-1a9c-4390-92e8-879b401168c7")]
	public static extern Win32Error PowerWriteDescription([Optional] HKEY RootPowerKey, [In] IntPtr SchemeGuid, [In] IntPtr SubGroupOfPowerSettingsGuid, [In] IntPtr PowerSettingGuid, string Buffer, uint BufferSize);

	/// <summary>Sets the description for the specified power setting, subgroup, or scheme.</summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The description, in wide (Unicode) characters.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// <para>
	/// If the SchemeGuid parameter is not <c>NULL</c> but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are
	/// <c>NULL</c>, the description of the power scheme will be set. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are
	/// not <c>NULL</c> and the PowerSettingGuid parameter is <c>NULL</c>, the description of the subgroup will be set. If the
	/// SchemeGuid, SubGroupOfPowerSettingsGuid, and PowerSettingGuid parameters are not <c>NULL</c>, the description of the power
	/// setting will be set.
	/// </para>
	/// <para>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</para>
	/// </remarks>
	[PInvokeData("powrprof.h", MSDNShortId = "42ee26ac-1a9c-4390-92e8-879b401168c7")]
	public static Win32Error PowerWriteDescription([In] Guid? SchemeGuid, [In] Guid? SubGroupOfPowerSettingsGuid, [In] Guid? PowerSettingGuid, string Buffer) =>
		PwrGuidTsl(SchemeGuid, SubGroupOfPowerSettingsGuid, PowerSettingGuid, (p1, p2, p3) => PowerWriteDescription(default, p1, p2, p3, Buffer, (uint)(Buffer.Length + 1) * 2));

	/// <summary>
	/// Sets the friendly name for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c> but
	/// both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the friendly name of the power scheme will
	/// be set. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid parameter is
	/// <c>NULL</c>, the friendly name of the subgroup will be set. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and PowerSettingGuid
	/// parameters are not <c>NULL</c>, the friendly name of the power setting will be set.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The friendly name, in wide (Unicode) characters.</param>
	/// <param name="BufferSize">
	/// The size of the friendly name specified by the Buffer parameter, including the terminating <c>NULL</c> character.
	/// </param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritefriendlyname DWORD PowerWriteFriendlyName(
	// HKEY RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, UCHAR *Buffer,
	// DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "3d81f634-8095-49c6-a5fe-6fe5e33bf0aa")]
	public static extern Win32Error PowerWriteFriendlyName([Optional] HKEY RootPowerKey, [In] IntPtr SchemeGuid, [In] IntPtr SubGroupOfPowerSettingsGuid, [In] IntPtr PowerSettingGuid, string Buffer, uint BufferSize);

	/// <summary>
	/// Sets the friendly name for the specified power setting, subgroup, or scheme. If the SchemeGuid parameter is not <c>NULL</c> but
	/// both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are <c>NULL</c>, the friendly name of the power scheme will
	/// be set. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are not <c>NULL</c> and the PowerSettingGuid parameter is
	/// <c>NULL</c>, the friendly name of the subgroup will be set. If the SchemeGuid, SubGroupOfPowerSettingsGuid, and PowerSettingGuid
	/// parameters are not <c>NULL</c>, the friendly name of the power setting will be set.
	/// </summary>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The friendly name, in wide (Unicode) characters.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	[PInvokeData("powrprof.h", MSDNShortId = "3d81f634-8095-49c6-a5fe-6fe5e33bf0aa")]
	public static Win32Error PowerWriteFriendlyName([In] Guid? SchemeGuid, [In] Guid? SubGroupOfPowerSettingsGuid, [In] Guid? PowerSettingGuid, string Buffer) =>
		PwrGuidTsl(SchemeGuid, SubGroupOfPowerSettingsGuid, PowerSettingGuid, (p1, p2, p3) => PowerWriteFriendlyName(default, p1, p2, p3, Buffer, (uint)(Buffer.Length + 1) * 2));

	/// <summary>Sets the icon resource for the specified power setting, subgroup, or scheme.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SchemeGuid">The identifier of the power scheme.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The icon resource.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>
	/// <para>
	/// If the SchemeGuid parameter is not <c>NULL</c> but both the SubGroupOfPowerSettingsGuid and PowerSettingGuid parameters are
	/// <c>NULL</c>, the friendly name of the power scheme will be set. If the SchemeGuid and SubGroupOfPowerSettingsGuid parameters are
	/// not <c>NULL</c> and the PowerSettingGuid parameter is <c>NULL</c>, the friendly name of the subgroup will be set. If the
	/// SchemeGuid, SubGroupOfPowerSettingsGuid, and PowerSettingGuid parameters are not <c>NULL</c>, the friendly name of the power
	/// setting will be set.
	/// </para>
	/// <para>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwriteiconresourcespecifier DWORD
	// PowerWriteIconResourceSpecifier( HKEY RootPowerKey, const GUID *SchemeGuid, const GUID *SubGroupOfPowerSettingsGuid, const GUID
	// *PowerSettingGuid, UCHAR *Buffer, DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "968b068a-f62a-4148-b96c-48f47218f368")]
	public static extern Win32Error PowerWriteIconResourceSpecifier([Optional] HKEY RootPowerKey, in Guid SchemeGuid, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, IntPtr Buffer, uint BufferSize);

	/// <summary>Sets the description for one of the possible choices of a power setting value.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PowerSettingGuid">The identifier of the power setting that is being used.</param>
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting.</param>
	/// <param name="Buffer">The description, in wide (Unicode) characters.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritepossibledescription DWORD
	// PowerWritePossibleDescription( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG
	// PossibleSettingIndex, UCHAR *Buffer, DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "5dce4dc1-d8af-41b8-bef0-8f11b246960f")]
	public static extern Win32Error PowerWritePossibleDescription([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, [Optional] in Guid PowerSettingGuid, uint PossibleSettingIndex, string Buffer, uint BufferSize);

	/// <summary>Sets the friendly name for the specified possible setting of a power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting.</param>
	/// <param name="Buffer">The friendly name, in wide (Unicode) characters.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritepossiblefriendlyname DWORD
	// PowerWritePossibleFriendlyName( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG
	// PossibleSettingIndex, UCHAR *Buffer, DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "981e813b-f3c8-44d2-ac1f-ca74f4795c85")]
	public static extern Win32Error PowerWritePossibleFriendlyName([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, [Optional] in Guid PowerSettingGuid, uint PossibleSettingIndex, string Buffer, uint BufferSize);

	/// <summary>Sets the value for a possible value of a power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Type">The type of data for the value. The possible values are listed in Registry Value Types.</param>
	/// <param name="PossibleSettingIndex">The zero-based index for the possible setting.</param>
	/// <param name="Buffer">The value for the possible setting.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritepossiblevalue DWORD PowerWritePossibleValue(
	// HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, ULONG Type, ULONG PossibleSettingIndex,
	// UCHAR *Buffer, DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "1c1e2707-fe5e-4199-85c9-c30deca917c5")]
	public static extern Win32Error PowerWritePossibleValue([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, [Optional] in Guid PowerSettingGuid, REG_VALUE_TYPE Type, uint PossibleSettingIndex, IntPtr Buffer, uint BufferSize);

	/// <summary>
	/// Sets the power attributes of a power key. If the PowerSettingGuid parameter is <c>NULL</c> then the attribute for SubGroupGuid is
	/// set, otherwise the attribute for PowerSettingGuid is set.
	/// </summary>
	/// <param name="SubGroupGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Attributes">
	/// <para>The attributes to be associated with the specified power setting.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>POWER_ATTRIBUTE_HIDE 1</term>
	/// <term>Hide this power setting.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritesettingattributes DWORD
	// PowerWriteSettingAttributes( const GUID *SubGroupGuid, const GUID *PowerSettingGuid, DWORD Attributes );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "9c18f79a-809b-4e48-a749-5de061566362")]
	public static extern Win32Error PowerWriteSettingAttributes(in Guid SubGroupGuid, in Guid PowerSettingGuid, POWER_ATTR Attributes);

	/// <summary>Sets the increment for valid values between the power settings minimum and maximum.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="ValueIncrement">The increment to be set.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritevalueincrement DWORD PowerWriteValueIncrement(
	// HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, DWORD ValueIncrement );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "8de6b470-dc6c-4539-8766-3c07a2700cf8")]
	public static extern Win32Error PowerWriteValueIncrement([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint ValueIncrement);

	/// <summary>Sets the maximum value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="ValueMaximum">The maximum value to be set.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritevaluemax DWORD PowerWriteValueMax( HKEY
	// RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, DWORD ValueMaximum );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "5a633d49-0d25-4073-b7a7-d1bdef1b8697")]
	public static extern Win32Error PowerWriteValueMax([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint ValueMaximum);

	/// <summary>Sets the minimum value for the specified power setting.</summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="ValueMinimum">The minimum value to be set.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritevaluemin DWORD PowerWriteValueMin( HKEY
	// RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, DWORD ValueMinimum );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "a50861f7-4236-4692-839a-071081e09ccf")]
	public static extern Win32Error PowerWriteValueMin([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, uint ValueMinimum);

	/// <summary>
	/// Writes the string used to describe the units of a power setting that supports a range of values. For example "minutes" may be
	/// used to describe a timeout setting.
	/// </summary>
	/// <param name="RootPowerKey">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="SubGroupOfPowerSettingsGuid">
	/// <para>
	/// The subgroup of power settings. This parameter can be one of the following values defined in WinNT.h. Use <c>NO_SUBGROUP_GUID</c>
	/// to refer to the default power scheme.
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
	/// <param name="Buffer">The units specifier, in wide (Unicode) characters.</param>
	/// <param name="BufferSize">The size of the buffer pointed to by the Buffer parameter.</param>
	/// <returns>Returns <c>ERROR_SUCCESS</c> (zero) if the call was successful, and a nonzero value if the call failed.</returns>
	/// <remarks>Changes to the settings for the active power scheme do not take effect until you call the PowerSetActiveScheme function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-powerwritevalueunitsspecifier DWORD
	// PowerWriteValueUnitsSpecifier( HKEY RootPowerKey, const GUID *SubGroupOfPowerSettingsGuid, const GUID *PowerSettingGuid, UCHAR
	// *Buffer, DWORD BufferSize );
	[DllImport(Lib.PowrProf, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("powrprof.h", MSDNShortId = "d9a81077-23e8-4bae-8e70-ffaaaf1ecda3")]
	public static extern Win32Error PowerWriteValueUnitsSpecifier([Optional] HKEY RootPowerKey, in Guid SubGroupOfPowerSettingsGuid, in Guid PowerSettingGuid, string Buffer, uint BufferSize);

	/// <summary>
	/// <para>
	/// [ <c>ReadGlobalPwrPolicy</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Retrieves the current global power policy settings.</para>
	/// </summary>
	/// <param name="pGlobalPowerPolicy">A pointer to a GLOBAL_POWER_POLICY structure that receives the information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The GLOBAL_POWER_POLICY structure contains policy settings that are common to all power schemes. This structure contains both
	/// user and computer policy settings.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, use the PowerEnumerate function to enumerate power settings for a specified scheme and the power
	/// read functions to retrieve individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-readglobalpwrpolicy BOOLEAN ReadGlobalPwrPolicy(
	// PGLOBAL_POWER_POLICY pGlobalPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "65da3d9f-b688-4d41-9da0-05159297d169")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool ReadGlobalPwrPolicy(out GLOBAL_POWER_POLICY pGlobalPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>ReadProcessorPwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Retrieves the processor power policy settings for the specified power scheme.</para>
	/// </summary>
	/// <param name="uiID">The index of the power scheme to be read.</param>
	/// <param name="pMachineProcessorPowerPolicy">
	/// A pointer to a MACHINE_PROCESSOR_POWER_POLICY structure that receives the processor power policy settings.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The MACHINE_PROCESSOR_POWER_POLICY structure contains processor power policy settings for use while the system is running on AC
	/// power or battery power.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, power management configuration of the system's processor is controlled through the
	/// GUID_PROCESSOR_SETTINGS_SUBGROUP power settings subgroup. Use the PowerEnumerate function to enumerate individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-readprocessorpwrscheme BOOLEAN ReadProcessorPwrScheme(
	// UINT uiID, PMACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "740095a7-9def-48a3-9cbb-1da91b052321")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool ReadProcessorPwrScheme(uint uiID, out MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>ReadPwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be altered or
	/// unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Retrieves the power policy settings that are unique to the specified power scheme.</para>
	/// </summary>
	/// <param name="uiID">The index of the power scheme to be read.</param>
	/// <param name="pPowerPolicy">A pointer to a POWER_POLICY structure that receives the power policy settings.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the power scheme specified does not exist, the function returns <c>FALSE</c>.</para>
	/// <para>
	/// To retrieve information about the power policy settings currently in use by the system, call the GetActivePwrScheme function. To
	/// retrieve additional information about the current power policy settings, call the CallNtPowerInformation function.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, use the PowerEnumerate function to enumerate power settings for a specified scheme and the power
	/// read functions to retrieve individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-readpwrscheme BOOLEAN ReadPwrScheme( UINT uiID,
	// PPOWER_POLICY pPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "a8d93820-b652-4358-8039-8987fac95dca")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool ReadPwrScheme(uint uiID, out POWER_POLICY pPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>SetActivePwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Applications written for Windows Vista and later should use PowerSetActiveScheme instead.]
	/// </para>
	/// <para>Sets the active power scheme.</para>
	/// </summary>
	/// <param name="uiID">The index of the power scheme to be activated.</param>
	/// <param name="pGlobalPowerPolicy">
	/// A pointer to an optional GLOBAL_POWER_POLICY structure, which provides global power policy settings to be merged with the power
	/// scheme when it becomes active.
	/// </param>
	/// <param name="pPowerPolicy">
	/// A pointer to an optional POWER_POLICY structure, which provides power policy settings to be merged with the power scheme when it
	/// becomes active.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use this function to make long-term changes to the system configuration. To temporarily keep the system running while an
	/// application is performing a task, use the SetThreadExecutionState function.
	/// </para>
	/// <para>If the power scheme specified by uiID does not exist, the function returns zero.</para>
	/// <para>
	/// If lpGlobalPowerPolicy is <c>NULL</c>, the function uses the current global power policy settings set by WriteGlobalPwrPolicy.
	/// Otherwise, the settings in the specified structure replace the current global power policy settings.
	/// </para>
	/// <para>
	/// If lpPowerPolicy is <c>NULL</c>, the function uses the current power policy settings for the power scheme. Otherwise, the
	/// settings in the specified structure replace the current power policy settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-setactivepwrscheme BOOLEAN SetActivePwrScheme( UINT
	// uiID, PGLOBAL_POWER_POLICY pGlobalPowerPolicy, PPOWER_POLICY pPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "f449ff0d-5c22-4c6d-8c88-dc18258a8c6d")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool SetActivePwrScheme(uint uiID, in GLOBAL_POWER_POLICY pGlobalPowerPolicy, in POWER_POLICY pPowerPolicy);

	/// <summary>
	/// Suspends the system by shutting power down. Depending on the Hibernate parameter, the system either enters a suspend (sleep)
	/// state or hibernation (S4).
	/// </summary>
	/// <param name="bHibernate">
	/// If this parameter is <c>TRUE</c>, the system hibernates. If the parameter is <c>FALSE</c>, the system is suspended.
	/// </param>
	/// <param name="bForce">This parameter has no effect.</param>
	/// <param name="bWakeupEventsDisabled">
	/// If this parameter is <c>TRUE</c>, the system disables all wake events. If the parameter is <c>FALSE</c>, any system wake events
	/// remain enabled.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege. To enable the <c>SE_SHUTDOWN_NAME</c> privilege, use the
	/// AdjustTokenPrivileges function. For more information, see Changing Privileges in a Token.
	/// </para>
	/// <para>
	/// An application may use <c>SetSuspendState</c> to transition the system from the working state to the standby (sleep), or
	/// optionally, hibernate (S4) state. This function is similar to the SetSystemPowerState function.
	/// </para>
	/// <para>
	/// For more information on using PowrProf.h, see Power Schemes. For information about events that can wake the system, see System
	/// Wake-up Events.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-setsuspendstate BOOLEAN SetSuspendState( BOOLEAN
	// bHibernate, BOOLEAN bForce, BOOLEAN bWakeupEventsDisabled );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "63cb6574-8c0d-4bcb-832c-7088447a5c04")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool SetSuspendState([MarshalAs(UnmanagedType.U1)] bool bHibernate, [MarshalAs(UnmanagedType.U1)] bool bForce, [MarshalAs(UnmanagedType.U1)] bool bWakeupEventsDisabled);

	/// <summary>
	/// <para>
	/// [ <c>WriteGlobalPwrPolicy</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Writes global power policy settings.</para>
	/// </summary>
	/// <param name="pGlobalPowerPolicy">
	/// A pointer to a GLOBAL_POWER_POLICY structure that contains the power policy settings to be written.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The function replaces any existing global power policy settings. Each user has a separate global power scheme, which contains
	/// power policy settings that apply to all power schemes for that user.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, use the PowerEnumerate function to enumerate power settings for a specified scheme and the power
	/// write functions to write individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-writeglobalpwrpolicy BOOLEAN WriteGlobalPwrPolicy(
	// PGLOBAL_POWER_POLICY pGlobalPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "293dc3a5-5e6b-4709-8439-67d2339740e7")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool WriteGlobalPwrPolicy(in GLOBAL_POWER_POLICY pGlobalPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>WriteProcessorPwrScheme</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. See Remarks.]
	/// </para>
	/// <para>Writes processor power policy settings for the specified power scheme.</para>
	/// </summary>
	/// <param name="uiID">The index of the power scheme to be written.</param>
	/// <param name="pMachineProcessorPowerPolicy">
	/// A pointer to a MACHINE_PROCESSOR_POWER_POLICY structure that contains the power policy settings to be written.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This change does not affect the current system power policy. To apply this change to the current system power policy, call the
	/// SetActivePwrScheme function, using the index of this power scheme.
	/// </para>
	/// <para>
	/// Starting with Windows Vista, power management configuration of the system's processor is controlled through the
	/// GUID_PROCESSOR_SETTINGS_SUBGROUP power settings subgroup. Use the PowerEnumerate function to enumerate individual settings.
	/// </para>
	/// <para>For more information on using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-writeprocessorpwrscheme BOOLEAN WriteProcessorPwrScheme(
	// UINT uiID, PMACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "70e18f50-4774-4a7c-8fe0-7fd6a54aaa90")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool WriteProcessorPwrScheme(uint uiID, in MACHINE_PROCESSOR_POWER_POLICY pMachineProcessorPowerPolicy);

	/// <summary>
	/// <para>
	/// [ <c>WritePwrScheme</c> is no longer available for use as of Windows Vista. Instead, use the PowerEnumerate function to enumerate
	/// power settings for a specified scheme, and the power write functions to write individual settings.]
	/// </para>
	/// <para>Writes policy settings that are unique to the specified power scheme.</para>
	/// </summary>
	/// <param name="puiID">
	/// The index of the power scheme to be written. If a power scheme with the same index already exists, it is replaced. Otherwise, a
	/// new power scheme is created.
	/// </param>
	/// <param name="lpszSchemeName">The name of the power scheme.</param>
	/// <param name="lpszDescription">The description of the power scheme.</param>
	/// <param name="lpScheme">A pointer to a POWER_POLICY structure that contains the power policy settings to be written.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This change does not affect the current system power policy. To apply this change to the current system power policy, call the
	/// SetActivePwrScheme function with the index of this power scheme.
	/// </para>
	/// <para>
	/// Power policy schemes written using <c>WritePwrScheme</c> are permanently stored in the system registry hives, and remain
	/// available for use in the Power Options control panel program, or by subsequent calls to the power scheme API. To permanently
	/// remove a power scheme from the system, call the DeletePwrScheme function.
	/// </para>
	/// <para>For more information about using PowrProf.h, see Power Schemes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/nf-powrprof-writepwrscheme BOOLEAN WritePwrScheme( PUINT puiID,
	// LPCWSTR lpszSchemeName, LPCWSTR lpszDescription, PPOWER_POLICY lpScheme );
	[DllImport(Lib.PowrProf, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("powrprof.h", MSDNShortId = "b9233601-6848-41c4-bb58-27decad60ba5")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool WritePwrScheme(ref uint puiID, [MarshalAs(UnmanagedType.LPWStr)] string lpszSchemeName, [MarshalAs(UnmanagedType.LPWStr)] string lpszDescription, in POWER_POLICY lpScheme);

	private static unsafe TRet PwrGuidTsl<TRet>(Guid? g1, Guid? g2, Guid? g3, Func<IntPtr, IntPtr, IntPtr, TRet> f)
	{
		var guids = new Guid[] { g1.GetValueOrDefault(), g2.GetValueOrDefault(), g3.GetValueOrDefault() };
		fixed (Guid* ptrs = guids)
			return f(g1.HasValue ? (IntPtr)(void*)&ptrs[0] : IntPtr.Zero, g2.HasValue ? (IntPtr)(void*)&ptrs[1] : IntPtr.Zero, g3.HasValue ? (IntPtr)(void*)&ptrs[2] : IntPtr.Zero);
	}

	private static SafeHGlobalHandle PwrReadMem(PwrReadMemFunc f, Guid? g1, Guid? g2, Guid? g3)
	{
		return PwrGuidTsl(g1, g2, g3, (p1, p2, p3) => {
			var sz = 0U;
			var err = f(HKEY.NULL, p1, p2, p3, IntPtr.Zero, ref sz);
			if (err.Failed)
			{
				if (err == Win32Error.ERROR_FILE_NOT_FOUND) return null;
				if (err != Win32Error.ERROR_MORE_DATA) throw err.GetException();
			}
			var p = new SafeHGlobalHandle((int)sz);
			f(HKEY.NULL, p1, p2, p3, (IntPtr)p, ref sz).ThrowIfFailed();
			return p;
		});
	}

	/// <summary>Contains parameters used when registering for a power notification.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-device_notify_subscribe_parameters typedef struct
	// _DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS { PDEVICE_NOTIFY_CALLBACK_ROUTINE Callback; PVOID Context; }
	// DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS, *PDEVICE_NOTIFY_SUBSCRIBE_PARAMETERS;
	[PInvokeData("powrprof.h", MSDNShortId = "749F7C6F-1A42-43DE-921E-C3654034570D")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS
	{
		/// <summary>Indicates the callback function that will be called when the application receives the notification.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DeviceNotifyCallbackRoutine Callback;

		/// <summary>The context of the application registering for the notification.</summary>
		public IntPtr Context;
	}

	/// <summary>
	/// Contains global computer power policy settings that apply to all power schemes for all users. This structure is part of the
	/// GLOBAL_POWER_POLICY structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_global_machine_power_policy typedef struct
	// _GLOBAL_MACHINE_POWER_POLICY { ULONG Revision; SYSTEM_POWER_STATE LidOpenWakeAc; SYSTEM_POWER_STATE LidOpenWakeDc; ULONG
	// BroadcastCapacityResolution; } GLOBAL_MACHINE_POWER_POLICY, *PGLOBAL_MACHINE_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "79b57da4-0125-427b-aec7-7ca4c9bfb870")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GLOBAL_MACHINE_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling GetCurrentPowerPolicies or ReadGlobalPwrPolicy before using a
		/// <c>GLOBAL_MACHINE_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// The maximum power state (highest Sx value) from which a lid-open event should wake the system when running on AC power. This
		/// member must be one of the SYSTEM_POWER_STATE enumeration type values. A value of <c>PowerSystemUnspecified</c> indicates that
		/// a lid-open event does not wake the system.
		/// </summary>
		public SYSTEM_POWER_STATE LidOpenWakeAc;

		/// <summary>
		/// The maximum power state (highest Sx value) from which a lid-open event should wake the system when running on battery. This
		/// member must be one of the SYSTEM_POWER_STATE enumeration type values. A value of <c>PowerSystemUnspecified</c> indicates that
		/// a lid-open event does not wake the system.
		/// </summary>
		public SYSTEM_POWER_STATE LidOpenWakeDc;

		/// <summary>
		/// The resolution of change in the current battery capacity that should cause the system to be notified of a system power state
		/// changed event.
		/// </summary>
		public uint BroadcastCapacityResolution;
	}

	/// <summary>Contains global power policy settings that apply to all power schemes.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_global_power_policy typedef struct _GLOBAL_POWER_POLICY
	// { GLOBAL_USER_POWER_POLICY user; GLOBAL_MACHINE_POWER_POLICY mach; } GLOBAL_POWER_POLICY, *PGLOBAL_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "5c177093-0c16-4a84-9212-f2376de6965b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GLOBAL_POWER_POLICY
	{
		/// <summary>A GLOBAL_USER_POWER_POLICY structure that defines the global user power policy settings.</summary>
		public GLOBAL_USER_POWER_POLICY user;

		/// <summary>A GLOBAL_MACHINE_POWER_POLICY structure that defines the global computer power policy settings.</summary>
		public GLOBAL_MACHINE_POWER_POLICY mach;
	}

	/// <summary>
	/// Contains global user power policy settings that apply to all power schemes for a user. This structure is part of the
	/// GLOBAL_POWER_POLICY structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_global_user_power_policy typedef struct
	// _GLOBAL_USER_POWER_POLICY { ULONG Revision; POWER_ACTION_POLICY PowerButtonAc; POWER_ACTION_POLICY PowerButtonDc;
	// POWER_ACTION_POLICY SleepButtonAc; POWER_ACTION_POLICY SleepButtonDc; POWER_ACTION_POLICY LidCloseAc; POWER_ACTION_POLICY
	// LidCloseDc; SYSTEM_POWER_LEVEL DischargePolicy[NUM_DISCHARGE_POLICIES]; ULONG GlobalFlags; } GLOBAL_USER_POWER_POLICY, *PGLOBAL_USER_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "0e89ae66-a889-4929-b028-125fcef5c89c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GLOBAL_USER_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling GetCurrentPowerPolicies or ReadGlobalPwrPolicy before using a
		/// <c>GLOBAL_USER_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the power button is pressed and the system is running on
		/// AC power.
		/// </summary>
		public POWER_ACTION_POLICY PowerButtonAc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the power button is pressed and the system is running on
		/// battery power.
		/// </summary>
		public POWER_ACTION_POLICY PowerButtonDc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the sleep button is pressed and the system is running on
		/// AC power.
		/// </summary>
		public POWER_ACTION_POLICY SleepButtonAc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the sleep button is pressed and the system is running on
		/// battery power.
		/// </summary>
		public POWER_ACTION_POLICY SleepButtonDc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the lid is closed and the system is running on AC power.
		/// </summary>
		public POWER_ACTION_POLICY LidCloseAc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when the lid is closed and the system is running on battery power.
		/// </summary>
		public POWER_ACTION_POLICY LidCloseDc;

		/// <summary>An array of SYSTEM_POWER_LEVEL structures that defines the actions to take at system battery discharge events.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public SYSTEM_POWER_LEVEL[] DischargePolicy;

		/// <summary>
		/// <para>
		/// A flag that enables or disables miscellaneous user power policy settings. This member can be one or more of the values
		/// described in Global Flags Constants.
		/// </para>
		/// </summary>
		public GlobalFlags GlobalFlags;
	}

	/// <summary>
	/// Contains computer power policy settings that are unique to each power scheme on the computer. This structure is part of the
	/// POWER_POLICY structure.
	/// </summary>
	/// <remarks>
	/// <c>DozeS4TimeoutAc</c> and <c>DozeS4TimeoutDc</c> correspond to the <c>DozeS4Timeout</c> member of SYSTEM_POWER_POLICY. These
	/// values are merged from the machine power policy to the system power policy when the SetActivePwrScheme function is called to
	/// apply a power scheme.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_machine_power_policy typedef struct
	// _MACHINE_POWER_POLICY { ULONG Revision; SYSTEM_POWER_STATE MinSleepAc; SYSTEM_POWER_STATE MinSleepDc; SYSTEM_POWER_STATE
	// ReducedLatencySleepAc; SYSTEM_POWER_STATE ReducedLatencySleepDc; ULONG DozeTimeoutAc; ULONG DozeTimeoutDc; ULONG DozeS4TimeoutAc;
	// ULONG DozeS4TimeoutDc; UCHAR MinThrottleAc; UCHAR MinThrottleDc; UCHAR pad1[2]; POWER_ACTION_POLICY OverThrottledAc;
	// POWER_ACTION_POLICY OverThrottledDc; } MACHINE_POWER_POLICY, *PMACHINE_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "41dca573-a73d-430c-9bd3-083e72aecbdc")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MACHINE_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling GetCurrentPowerPolicies or ReadPwrScheme before using a
		/// <c>MACHINE_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// The minimum system power state (lowest Sx value) to enter on a system sleep action when running on AC power. This member must
		/// be one of the SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE MinSleepAc;

		/// <summary>
		/// The minimum system power state (lowest Sx value) to enter on a system sleep action when running on battery power. This member
		/// must be one of the SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE MinSleepDc;

		/// <summary>
		/// The maximum system power state (highest Sx value) to enter on a system sleep action when running on AC power, and when there
		/// are outstanding latency requirements. This member must be one of the SYSTEM_POWER_STATE enumeration type values. If an
		/// application calls RequestWakeupLatency with LT_LOWEST_LATENCY, <c>ReducedLatencySleepAc</c> is used in place of <c>MaxSleepAc</c>.
		/// </summary>
		public SYSTEM_POWER_STATE ReducedLatencySleepAc;

		/// <summary>
		/// The maximum system power state (highest Sx value) to enter on a system sleep action when running on battery power, and when
		/// there are outstanding latency requirements. This member must be one of the SYSTEM_POWER_STATE enumeration type values. If an
		/// application calls RequestWakeupLatency with LT_LOWEST_LATENCY, <c>ReducedLatencySleepAc</c> is used in place of <c>MaxSleepAc</c>.
		/// </summary>
		public SYSTEM_POWER_STATE ReducedLatencySleepDc;

		/// <summary>This member is ignored.</summary>
		public uint DozeTimeoutAc;

		/// <summary>This member is ignored.</summary>
		public uint DozeTimeoutDc;

		/// <summary>
		/// Time to wait between entering the suspend state and entering the hibernate sleeping state when the system is running on AC
		/// power, in seconds. A value of zero indicates never hibernate.
		/// </summary>
		public uint DozeS4TimeoutAc;

		/// <summary>
		/// Time to wait between entering the suspend state and entering the hibernate sleeping state when the system is running on
		/// battery power, in seconds. A value of zero indicates never hibernate.
		/// </summary>
		public uint DozeS4TimeoutDc;

		/// <summary>
		/// The minimum throttle setting allowed before being over-throttled when the system is running on AC power. Thermal conditions
		/// would be the only reason for going below the minimum setting. When the processor is over-throttled, the system will initiate
		/// the <c>OverThrottledAc</c> policy. Note that the power policy manager has a hard-coded policy to initiate a
		/// CriticalShutdownOff whenever any thermal zone indicates a critical thermal condition. Range: 0-100.
		/// </summary>
		public byte MinThrottleAc;

		/// <summary>
		/// The minimum throttle setting allowed before being over-throttled when the system is running on battery power. Thermal
		/// conditions would be the only reason for going below the minimum setting. When the processor is over-throttled, the system
		/// will initiate the <c>OverThrottledDc</c> policy. Note that the power policy manager has a hard-coded policy to initiate a
		/// CriticalShutdownOff whenever any thermal zone indicates a critical thermal condition. Range: 0-100.
		/// </summary>
		public byte MinThrottleDc;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private readonly byte[] pad1;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when a processor has become over-throttled (as defined by the
		/// <c>MinThrottleAc</c> member) when the system is running on AC power.
		/// </summary>
		public POWER_ACTION_POLICY OverThrottledAc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the action to take when a processor has become over-throttled (as defined by the
		/// <c>MinThrottleDc</c> member) when the system is running on battery power.
		/// </summary>
		public POWER_ACTION_POLICY OverThrottledDc;
	}

	/// <summary>Contains processor power policy settings that apply while the system is running on AC power or battery power.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_machine_processor_power_policy typedef struct
	// _MACHINE_PROCESSOR_POWER_POLICY { ULONG Revision; PROCESSOR_POWER_POLICY ProcessorPolicyAc; PROCESSOR_POWER_POLICY
	// ProcessorPolicyDc; } MACHINE_PROCESSOR_POWER_POLICY, *PMACHINE_PROCESSOR_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "54403b81-97bc-4f2b-8721-48c9f69e2773")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct MACHINE_PROCESSOR_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling ReadProcessorPwrScheme before using a
		/// <c>MACHINE_PROCESSOR_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// A PROCESSOR_POWER_POLICY structure that defines the processor power policy settings used while the computer is running on AC power.
		/// </summary>
		public PROCESSOR_POWER_POLICY ProcessorPolicyAc;

		/// <summary>
		/// A PROCESSOR_POWER_POLICY structure that defines the processor power policy settings used while the computer is running on
		/// battery power.
		/// </summary>
		public PROCESSOR_POWER_POLICY ProcessorPolicyDc;
	}

	/// <summary>Contains power policy settings that are unique to each power scheme.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_power_policy typedef struct _POWER_POLICY {
	// USER_POWER_POLICY user; MACHINE_POWER_POLICY mach; } POWER_POLICY, *PPOWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "ba49fca6-04b6-4627-a653-07c3fc0dab22")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct POWER_POLICY
	{
		/// <summary>A USER_POWER_POLICY structure that defines user power policy settings.</summary>
		public USER_POWER_POLICY user;

		/// <summary>A MACHINE_POWER_POLICY structure that defines computer power policy settings.</summary>
		public MACHINE_POWER_POLICY mach;
	}

	/// <summary>Contains a thermal event.</summary>
	/// <remarks>
	/// Drivers use the <c>THERMAL_EVENT</c> structure to specify a thermal event. By calling the PowerReportThermalEvent routine, the
	/// operating system can record the thermal event in the system event log.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_thermal_event typedef struct _THERMAL_EVENT { ULONG
	// Version; ULONG Size; ULONG Type; ULONG Temperature; ULONG TripPointTemperature; LPWSTR Initiator; } THERMAL_EVENT, *PTHERMAL_EVENT;
	[PInvokeData("powrprof.h", MSDNShortId = "80B6A494-AED6-4EF0-8B69-4AA5DA6BCBB3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct THERMAL_EVENT
	{
		/// <summary>The current structure version level, <c>THERMAL_EVENT_VERSION</c>.</summary>
		public uint Version;

		/// <summary>The size of the structure.</summary>
		public uint Size;

		/// <summary>
		/// One of the thermal event values from Ntpoapi.h: <c>THERMAL_EVENT_SHUTDOWN</c>, <c>THERMAL_EVENT_HIBERNATE</c>, or <c>THERMAL_EVENT_UNSPECIFIED</c>.
		/// </summary>
		public uint Type;

		/// <summary>
		/// The temperature, in tenths of a degree Kelvin, that the sensor was at after crossing the trip point (or zero if unknown).
		/// </summary>
		public uint Temperature;

		/// <summary>The temperature, in tenths of a degree Kelvin, of the trip point (or zero if unknown).</summary>
		public uint TripPointTemperature;

		/// <summary>A pointer to a NULL-terminated, wide-character string that identifies the sensor whose threshold was crossed.</summary>
		public string Initiator;
	}

	/// <summary>
	/// Contains power policy settings that are unique to each power scheme for a user. This structure is part of the POWER_POLICY structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/powrprof/ns-powrprof-_user_power_policy typedef struct _USER_POWER_POLICY {
	// ULONG Revision; POWER_ACTION_POLICY IdleAc; POWER_ACTION_POLICY IdleDc; ULONG IdleTimeoutAc; ULONG IdleTimeoutDc; UCHAR
	// IdleSensitivityAc; UCHAR IdleSensitivityDc; UCHAR ThrottlePolicyAc; UCHAR ThrottlePolicyDc; SYSTEM_POWER_STATE MaxSleepAc;
	// SYSTEM_POWER_STATE MaxSleepDc; ULONG Reserved[2]; ULONG VideoTimeoutAc; ULONG VideoTimeoutDc; ULONG SpindownTimeoutAc; ULONG
	// SpindownTimeoutDc; BOOLEAN OptimizeForPowerAc; BOOLEAN OptimizeForPowerDc; UCHAR FanThrottleToleranceAc; UCHAR
	// FanThrottleToleranceDc; UCHAR ForcedThrottleAc; UCHAR ForcedThrottleDc; } USER_POWER_POLICY, *PUSER_POWER_POLICY;
	[PInvokeData("powrprof.h", MSDNShortId = "616c45f6-ec80-42d9-a485-e9e778f2b971")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USER_POWER_POLICY
	{
		/// <summary>
		/// The current structure revision level. Set this value by calling GetCurrentPowerPolicies or ReadPwrScheme before using a
		/// <c>USER_POWER_POLICY</c> structure to set power policy.
		/// </summary>
		public uint Revision;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the system power action to initiate when the system is running on AC (utility)
		/// power and the system idle timer expires.
		/// </summary>
		public POWER_ACTION_POLICY IdleAc;

		/// <summary>
		/// A POWER_ACTION_POLICY structure that defines the system power action to initiate when the system is running on battery power
		/// and the system idle timer expires.
		/// </summary>
		public POWER_ACTION_POLICY IdleDc;

		/// <summary>
		/// <para>
		/// The time that the level of system activity must remain below the idle detection threshold before the system idle timer
		/// expires when running on AC (utility) power, in seconds.
		/// </para>
		/// <para>
		/// This member is ignored if the system is performing an automated resume because there is no user present. To temporarily keep
		/// the system running while an application is performing a task, use the SetThreadExecutionState function.
		/// </para>
		/// </summary>
		public uint IdleTimeoutAc;

		/// <summary>
		/// <para>
		/// The time that the level of system activity must remain below the idle detection threshold before the system idle timer
		/// expires when running on battery power, in seconds.
		/// </para>
		/// <para>
		/// This member is ignored if the system is performing an automated resume because there is no user present. To temporarily keep
		/// the system running while an application is performing a task, use the SetThreadExecutionState function.
		/// </para>
		/// </summary>
		public uint IdleTimeoutDc;

		/// <summary>
		/// The level of system activity that defines the threshold for idle detection when the system is running on AC (utility) power,
		/// expressed as a percentage.
		/// </summary>
		public byte IdleSensitivityAc;

		/// <summary>
		/// The level of system activity that defines the threshold for idle detection when the system is running on battery power,
		/// expressed as a percentage.
		/// </summary>
		public byte IdleSensitivityDc;

		/// <summary>The processor dynamic throttling policy to use when the system is running on AC (utility) power.</summary>
		public byte ThrottlePolicyAc;

		/// <summary>The processor dynamic throttling policy to use when the system is running on battery power.</summary>
		public byte ThrottlePolicyDc;

		/// <summary>
		/// The maximum system sleep state when the system is running on AC (utility) power. This member must be one of the
		/// SYSTEM_POWER_STATE enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE MaxSleepAc;

		/// <summary>
		/// The maximum system sleep state when the system is running on battery power. This member must be one of the SYSTEM_POWER_STATE
		/// enumeration type values.
		/// </summary>
		public SYSTEM_POWER_STATE MaxSleepDc;

		/// <summary>Reserved.</summary>
		/// <value>The <see cref="System.UInt32"/>.</value>
		/// <returns></returns>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		private readonly uint[] Reserved;

		/// <summary>
		/// <para>The time before the display is turned off when the system is running on AC (utility) power, in seconds.</para>
		/// </summary>
		public uint VideoTimeoutAc;

		/// <summary>
		/// <para>The time before the display is turned off when the system is running on battery power, in seconds.</para>
		/// </summary>
		public uint VideoTimeoutDc;

		/// <summary>
		/// <para>The time before power to fixed disk drives is turned off when the system is running on AC (utility) power, in seconds.</para>
		/// </summary>
		public uint SpindownTimeoutAc;

		/// <summary>
		/// <para>The time before power to fixed disk drives is turned off when the system is running on battery power, in seconds.</para>
		/// </summary>
		public uint SpindownTimeoutDc;

		/// <summary>
		/// <para>
		/// If this member is <c>TRUE</c>, the system will turn on cooling fans and run the processor at full speed when passive cooling
		/// is specified and the system is running on AC (utility) power. This causes the operating system to be biased toward using the
		/// fan and running the processor at full speed.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool OptimizeForPowerAc;

		/// <summary>
		/// <para>
		/// If this member is <c>TRUE</c>, the system will turn on cooling fans and run the processor at full speed when passive cooling
		/// is specified and the system is running on battery power. This causes the operating system to be biased toward using the fan
		/// and running the processor at full speed.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool OptimizeForPowerDc;

		/// <summary>
		/// <para>
		/// The lower limit that the processor may be throttled down to prior to turning on system fans in response to a thermal event
		/// while the system is operating on AC (utility) power, expressed as a percentage.
		/// </para>
		/// </summary>
		public byte FanThrottleToleranceAc;

		/// <summary>
		/// <para>
		/// The lower limit that the processor may be throttled down to prior to turning on system fans in response to a thermal event
		/// while the system is operating on battery power, expressed as a percentage.
		/// </para>
		/// </summary>
		public byte FanThrottleToleranceDc;

		/// <summary>
		/// <para>
		/// The processor throttle level to be imposed by the system while the computer is running on AC (utility) power, expressed as a percentage.
		/// </para>
		/// </summary>
		public byte ForcedThrottleAc;

		/// <summary>
		/// <para>
		/// The processor throttle level to be imposed by the system while the computer is running on battery power, expressed as a percentage.
		/// </para>
		/// </summary>
		public byte ForcedThrottleDc;
	}
}