using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke;

/// <summary>Items from the NewDev.dll</summary>
public static partial class NewDev
{
	private const string Lib_NewDev = "newdev.dll";

	/// <summary>Flags for <see cref="DiInstallDevice(HWND, HDEVINFO, in SP_DEVINFO_DATA, in SP_DRVINFO_DATA_V2, DIID_FLAG, out bool)"/>.</summary>
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiInstallDevice")]
	[Flags]
	public enum DIID_FLAG : uint
	{
		/// <summary>
		/// If the caller does not specify a driver (DriverInfoData is set to <c>NULL</c>) and <c>DiInstallDevice</c> does not locate a
		/// preinstalled driver that matches the specified device. Instead, <c>DiInstallDevice</c> displays the Found New Hardware
		/// wizard for the device.
		/// </summary>
		DIIDFLAG_SHOWSEARCHUI = 0x00000001,

		/// <summary>
		/// <c>DiInstallDevice</c> does not start finish-install wizard pages or finish-install actions. The caller of
		/// <c>DiInstallDevice</c> must start these operations. The caller should only specify this flag if the caller requires that
		/// finish-install wizard pages be invoked in the context of a caller-supplied user interface component.
		/// </summary>
		DIIDFLAG_NOFINISHINSTALLUI = 0x00000002,

		/// <summary>
		/// <c>DiInstallDevice</c> attempts to install a null driver on the specified device. If this flag is set,
		/// <c>DiInstallDevice</c> does not use the DriverInfoData parameter. <c>DiInstallDevice</c> removes all device settings and, if
		/// the device cannot run in raw mode, the function sets the status of the device to <c>CM_PROB_FAILED_INSTALL</c>. If
		/// <c>DiInstallDevice</c> cannot install a null driver, the resulting state of the device is the same as if the device was
		/// connected for the first time to the computer and Windows did not locate a driver for the device.
		/// </summary>
		DIIDFLAG_INSTALLNULLDRIVER = 0x00000004,

		/// <summary>
		/// Any additional INF file specified via a CopyINF directive will be installed on any device it is applicable to. Any failure
		/// in installing an additional INF will not cause the primary INF's installation to fail.
		/// </summary>
		DIIDFLAG_INSTALLCOPYINFDRIVERS = 0x00000008,
	}

	/// <summary>Flags for <see cref="DiInstallDriver"/></summary>
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiInstallDriverA")]
	[Flags]
	public enum DIIRFLAG : uint
	{
		/// <summary>Don't copy inf, it has been published</summary>
		DIIRFLAG_INF_ALREADY_COPIED = 0x00000001,   // Don't copy inf, it has been published

		/// <summary>
		/// Installs the specified driver on a matching device whether the driver is a better match for the device than the driver that
		/// is currently installed on the device.
		/// </summary>
		DIIRFLAG_FORCE_INF = 0x00000002,

		/// <summary>limit installs on hw using the inf</summary>
		DIIRFLAG_HW_USING_THE_INF = 0x00000004,   // limit installs on hw using the inf

		/// <summary>Perform a hotpatch service pack install</summary>
		DIIRFLAG_HOTPATCH = 0x00000008,   // Perform a hotpatch service pack install

		/// <summary>install w/o backup and no rollback</summary>
		DIIRFLAG_NOBACKUP = 0x00000010,   // install w/o backup and no rollback

		/// <summary>Pre-install inf, if possible</summary>
		DIIRFLAG_PRE_CONFIGURE_INF = 0x00000020,   // Pre-install inf, if possible

		/// <summary/>
		DIIRFLAG_INSTALL_AS_SET = 0x00000040,
	}

	/// <summary>Flags for <see cref="DiUninstallDriver"/>.</summary>
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiUninstallDriverW")]
	[Flags]
	public enum DIURFLAG : uint
	{
		/// <summary>
		/// Removes the driver package from any devices it is installed on, but does not remove the drive package from the Driver Store.
		/// </summary>
		DIURFLAG_NO_REMOVE_INF = 0x00000001
	}

	/// <summary>Flags for <see cref="UpdateDriverForPlugAndPlayDevices"/>.</summary>
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.UpdateDriverForPlugAndPlayDevicesA")]
	[Flags]
	public enum INSTALLFLAG
	{
		/// <summary>
		/// <para>
		/// If this flag is set and the function finds a device that matches the HardwareId value, the function installs new drivers for
		/// the device whether better drivers already exist on the computer.
		/// </para>
		/// <para>
		/// <c>Important</c> Use this flag only with extreme caution. Setting this flag can cause an older driver to be installed over a
		/// newer driver, if a user runs the vendor's application after newer drivers are available.
		/// </para>
		/// </summary>
		INSTALLFLAG_FORCE = 0x00000001,

		/// <summary>
		/// <para>
		/// If this flag is set, the function will not copy, rename, or delete any installation files. Use of this flag should be
		/// limited to environments in which file access is restricted or impossible, such as an "embedded" operating system.
		/// </para>
		/// </summary>
		INSTALLFLAG_READONLY = 0x00000002,

		/// <summary>
		/// <para>
		/// If this flag is set, the function will return <c>FALSE</c> when any attempt to display UI is detected. Set this flag only if
		/// the function will be called from a component (such as a service) that cannot display UI.
		/// </para>
		/// <para><c>Note</c> If this flag is set and a UI display is attempted, the device can be left in an indeterminate state.</para>
		/// </summary>
		INSTALLFLAG_NONINTERACTIVE = 0x00000004,
	}

	/// <summary>Flags for <see cref="DiRollbackDriver"/></summary>
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiRollbackDriver")]
	[Flags]
	public enum ROLLBACK_FLAG : uint
	{
		/// <summary>Suppresses the display of user interface components that are associated with a driver rollback.</summary>
		ROLLBACK_FLAG_NO_UI = 0x00000001
	}

	/// <summary>
	/// The <c>DiInstallDevice</c> function installs a specified driver that is preinstalled in the driver store on a specified device
	/// that is present in the system.
	/// </summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiInstallDevice</c> uses to display any user interface component that is associated
	/// with installing the device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the specified device.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the specified device in the specified device information set.
	/// </param>
	/// <param name="DriverInfoData">
	/// An pointer to an SP_DRVINFO_DATA structure that specifies the driver to install on the specified device. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is <c>NULL</c>, <c>DiInstallDevice</c> searches the drivers
	/// preinstalled in the driver store for the driver that is the best match to the specified device, and, if one is found, installs
	/// the driver on the specified device.
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type <c>DWORD</c> that specifies zero or the following flag:</para>
	/// <para>DIIDFLAG_SHOWSEARCHUI</para>
	/// <para>
	/// If the caller does not specify a driver (DriverInfoData is set to <c>NULL</c>) and <c>DiInstallDevice</c> does not locate a
	/// preinstalled driver that matches the specified device. Instead, <c>DiInstallDevice</c> displays the Found New Hardware wizard
	/// for the device.
	/// </para>
	/// <para>DIIDFLAG_NOFINISHINSTALLUI</para>
	/// <para>
	/// <c>DiInstallDevice</c> does not start finish-install wizard pages or finish-install actions. The caller of
	/// <c>DiInstallDevice</c> must start these operations. The caller should only specify this flag if the caller requires that
	/// finish-install wizard pages be invoked in the context of a caller-supplied user interface component.
	/// </para>
	/// <para>DIIDFLAG_INSTALLNULLDRIVER</para>
	/// <para>
	/// <c>DiInstallDevice</c> attempts to install a null driver on the specified device. If this flag is set, <c>DiInstallDevice</c>
	/// does not use the DriverInfoData parameter. <c>DiInstallDevice</c> removes all device settings and, if the device cannot run in
	/// raw mode, the function sets the status of the device to <c>CM_PROB_FAILED_INSTALL</c>. If <c>DiInstallDevice</c> cannot install
	/// a null driver, the resulting state of the device is the same as if the device was connected for the first time to the computer
	/// and Windows did not locate a driver for the device.
	/// </para>
	/// <para>DIIDFLAG_INSTALLCOPYINFDRIVERS</para>
	/// <para>
	/// Any additional INF file specified via a CopyINF directive will be installed on any device it is applicable to. Any failure in
	/// installing an additional INF will not cause the primary INF's installation to fail.
	/// </para>
	/// </param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type <c>BOOL</c> that <c>DiInstallDevice</c> sets to indicate whether a system restart is required to
	/// complete the installation. This parameter is optional and can be set to <c>NULL</c>. If this parameter is supplied and a system
	/// restart is required to complete the installation, <c>DiInstallDevice</c> sets the value to <c>TRUE</c>. In this case, the caller
	/// is responsible for restarting the system. If this parameter is supplied and a system restart is not required,
	/// <c>DiInstallDevice</c> sets this parameter to <c>FALSE</c>. If this parameter is <c>NULL</c> and a system restart is required to
	/// complete the installation, <c>DiInstallDevice</c> displays a system restart dialog box.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiInstallDevice</c> returns <c>TRUE</c> if the function successfully installed the specified driver on the specified device.
	/// Otherwise, <c>DiInstallDevice</c> returns <c>FALSE</c> and the logged error can be retrieved by making a call to
	/// <c>GetLastError</c>. Some of the more common error values that <c>GetLastError</c> might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows Vista and Windows Server 2008 require that a calling
	/// process have Administrator privileges to install a driver on a device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value that is specified for Flags is not zero or a bitwise OR of the valid flags.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only call <c>DiInstallDevice</c> if it is necessary to install a specific driver on a specific device. Otherwise, use
	/// UpdateDriverForPlugAndPlayDevices or DiInstallDriver to install a driver for a device. For more information about which of these
	/// functions to call to install a driver on a device, see SetupAPI Functions that Simplify Driver Installation.
	/// </para>
	/// <para>
	/// Before calling <c>DiInstallDevice</c>, the caller must obtain an SP_DEVINFO_DATA structure to specify the device and,
	/// optionally, an SP_DRVINFO_DATA structure to specify a driver for the device.
	/// </para>
	/// <para>
	/// To create a device information set that contains the specified device and to obtain an SP_DEVINFO_DATA structure for the device,
	/// do one of the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Call SetupDiGetClassDevs to retrieve a device information set that contains the device and then call SetupDiEnumDeviceInfo to
	/// enumerate the devices in the device information set. On each call, <c>SetupDiEnumDeviceInfo</c> returns an SP_DEVINFO_DATA
	/// structure that represents the enumerated device in the device information set. To obtain specific information about the
	/// enumerated device, call SetupDiGetDeviceProperty and supply the <c>SP_DEVINFO_DATA</c> structure that is returned by <c>SetupDiEnumDeviceInfo</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call SetupDiOpenDeviceInfo to add a device with a known device instance ID to the device information set.
	/// <c>SetupDiOpenDeviceInfo</c> returns an SP_DEVINFO_DATA structure that represents the device in the device information set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve an SP_DRVINFO_DATA structure for a selected driver, call SetupDiBuildDriverInfoList to build a list of drivers for
	/// the device and then call SetupDiEnumDriverInfo to enumerate the elements of the driver list for the device. For each enumerated
	/// driver, <c>SetupDiEnumDriverInfo</c> retrieves an <c>SP_DRVINFO_DATA</c> structure that identifies the driver.
	/// SetupDiGetDriverInfoDetail can also be called to retrieve additional detail about an enumerated driver.
	/// </para>
	/// <para>
	/// In general, an installation application should set NeedReboot to <c>NULL</c>. This ensures that <c>DiInstallDevice</c> prompts
	/// the user to restart the system if a restart is required to complete the installation. An application should supply a NeedReboot
	/// pointer only in the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application must call <c>DiInstallDevice</c> several times to complete an installation. In this case, the application should
	/// record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiInstallDevice</c> and, if so, prompt the
	/// user to restart the system after the final call to <c>DiInstallDevice</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiInstallDevice</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application is a class installer, in which case, the class installer should set the <c>DI_NEEDREBOOT</c> flag in the
	/// <c>Flags</c> member of the SP_DEVINSTALL_PARAMS structure for a device.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-diinstalldevice BOOL DiInstallDevice( HWND hwndParent,
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA DriverInfoData, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiInstallDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiInstallDevice([In, Optional] HWND hwndParent, [In] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		in SP_DRVINFO_DATA_V2 DriverInfoData, DIID_FLAG Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>
	/// The <c>DiInstallDevice</c> function installs a specified driver that is preinstalled in the driver store on a specified device
	/// that is present in the system.
	/// </summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiInstallDevice</c> uses to display any user interface component that is associated
	/// with installing the device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the specified device.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the specified device in the specified device information set.
	/// </param>
	/// <param name="DriverInfoData">
	/// An pointer to an SP_DRVINFO_DATA structure that specifies the driver to install on the specified device. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is <c>NULL</c>, <c>DiInstallDevice</c> searches the drivers
	/// preinstalled in the driver store for the driver that is the best match to the specified device, and, if one is found, installs
	/// the driver on the specified device.
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type <c>DWORD</c> that specifies zero or the following flag:</para>
	/// <para>DIIDFLAG_SHOWSEARCHUI</para>
	/// <para>
	/// If the caller does not specify a driver (DriverInfoData is set to <c>NULL</c>) and <c>DiInstallDevice</c> does not locate a
	/// preinstalled driver that matches the specified device. Instead, <c>DiInstallDevice</c> displays the Found New Hardware wizard
	/// for the device.
	/// </para>
	/// <para>DIIDFLAG_NOFINISHINSTALLUI</para>
	/// <para>
	/// <c>DiInstallDevice</c> does not start finish-install wizard pages or finish-install actions. The caller of
	/// <c>DiInstallDevice</c> must start these operations. The caller should only specify this flag if the caller requires that
	/// finish-install wizard pages be invoked in the context of a caller-supplied user interface component.
	/// </para>
	/// <para>DIIDFLAG_INSTALLNULLDRIVER</para>
	/// <para>
	/// <c>DiInstallDevice</c> attempts to install a null driver on the specified device. If this flag is set, <c>DiInstallDevice</c>
	/// does not use the DriverInfoData parameter. <c>DiInstallDevice</c> removes all device settings and, if the device cannot run in
	/// raw mode, the function sets the status of the device to <c>CM_PROB_FAILED_INSTALL</c>. If <c>DiInstallDevice</c> cannot install
	/// a null driver, the resulting state of the device is the same as if the device was connected for the first time to the computer
	/// and Windows did not locate a driver for the device.
	/// </para>
	/// <para>DIIDFLAG_INSTALLCOPYINFDRIVERS</para>
	/// <para>
	/// Any additional INF file specified via a CopyINF directive will be installed on any device it is applicable to. Any failure in
	/// installing an additional INF will not cause the primary INF's installation to fail.
	/// </para>
	/// </param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type <c>BOOL</c> that <c>DiInstallDevice</c> sets to indicate whether a system restart is required to
	/// complete the installation. This parameter is optional and can be set to <c>NULL</c>. If this parameter is supplied and a system
	/// restart is required to complete the installation, <c>DiInstallDevice</c> sets the value to <c>TRUE</c>. In this case, the caller
	/// is responsible for restarting the system. If this parameter is supplied and a system restart is not required,
	/// <c>DiInstallDevice</c> sets this parameter to <c>FALSE</c>. If this parameter is <c>NULL</c> and a system restart is required to
	/// complete the installation, <c>DiInstallDevice</c> displays a system restart dialog box.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiInstallDevice</c> returns <c>TRUE</c> if the function successfully installed the specified driver on the specified device.
	/// Otherwise, <c>DiInstallDevice</c> returns <c>FALSE</c> and the logged error can be retrieved by making a call to
	/// <c>GetLastError</c>. Some of the more common error values that <c>GetLastError</c> might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows Vista and Windows Server 2008 require that a calling
	/// process have Administrator privileges to install a driver on a device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value that is specified for Flags is not zero or a bitwise OR of the valid flags.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only call <c>DiInstallDevice</c> if it is necessary to install a specific driver on a specific device. Otherwise, use
	/// UpdateDriverForPlugAndPlayDevices or DiInstallDriver to install a driver for a device. For more information about which of these
	/// functions to call to install a driver on a device, see SetupAPI Functions that Simplify Driver Installation.
	/// </para>
	/// <para>
	/// Before calling <c>DiInstallDevice</c>, the caller must obtain an SP_DEVINFO_DATA structure to specify the device and,
	/// optionally, an SP_DRVINFO_DATA structure to specify a driver for the device.
	/// </para>
	/// <para>
	/// To create a device information set that contains the specified device and to obtain an SP_DEVINFO_DATA structure for the device,
	/// do one of the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Call SetupDiGetClassDevs to retrieve a device information set that contains the device and then call SetupDiEnumDeviceInfo to
	/// enumerate the devices in the device information set. On each call, <c>SetupDiEnumDeviceInfo</c> returns an SP_DEVINFO_DATA
	/// structure that represents the enumerated device in the device information set. To obtain specific information about the
	/// enumerated device, call SetupDiGetDeviceProperty and supply the <c>SP_DEVINFO_DATA</c> structure that is returned by <c>SetupDiEnumDeviceInfo</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call SetupDiOpenDeviceInfo to add a device with a known device instance ID to the device information set.
	/// <c>SetupDiOpenDeviceInfo</c> returns an SP_DEVINFO_DATA structure that represents the device in the device information set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve an SP_DRVINFO_DATA structure for a selected driver, call SetupDiBuildDriverInfoList to build a list of drivers for
	/// the device and then call SetupDiEnumDriverInfo to enumerate the elements of the driver list for the device. For each enumerated
	/// driver, <c>SetupDiEnumDriverInfo</c> retrieves an <c>SP_DRVINFO_DATA</c> structure that identifies the driver.
	/// SetupDiGetDriverInfoDetail can also be called to retrieve additional detail about an enumerated driver.
	/// </para>
	/// <para>
	/// In general, an installation application should set NeedReboot to <c>NULL</c>. This ensures that <c>DiInstallDevice</c> prompts
	/// the user to restart the system if a restart is required to complete the installation. An application should supply a NeedReboot
	/// pointer only in the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application must call <c>DiInstallDevice</c> several times to complete an installation. In this case, the application should
	/// record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiInstallDevice</c> and, if so, prompt the
	/// user to restart the system after the final call to <c>DiInstallDevice</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiInstallDevice</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application is a class installer, in which case, the class installer should set the <c>DI_NEEDREBOOT</c> flag in the
	/// <c>Flags</c> member of the SP_DEVINSTALL_PARAMS structure for a device.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-diinstalldevice BOOL DiInstallDevice( HWND hwndParent,
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_DRVINFO_DATA DriverInfoData, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiInstallDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiInstallDevice([In, Optional] HWND hwndParent, [In] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[In, Optional] IntPtr DriverInfoData, DIID_FLAG Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>
	/// The <c>DiInstallDriver</c> function preinstalls a driver in the driver store and then installs the driver on devices present in
	/// the system that the driver supports.
	/// </summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiInstallDriver</c> uses to display any user interface component that is associated
	/// with installing the device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="InfPath">
	/// A pointer to a NULL-terminated string that supplies the fully qualified path of the INF file for the driver package.
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type DWORD that specifies zero or DIIRFLAG_FORCE_INF. Typically, this flag should be set to zero.</para>
	/// <para>
	/// If this flag is zero, <c>DiInstallDriver</c> only installs the specified driver on a device if the driver is a better match for
	/// a device than the driver that is currently installed on a device. However, if this flag is set to DIIRFLAG_FORCE_INF,
	/// <c>DiInstallDriver</c> installs the specified driver on a matching device whether the driver is a better match for the device
	/// than the driver that is currently installed on the device.
	/// </para>
	/// <para>
	/// <c>Caution</c> Forcing the installation of the driver can result in replacing a more compatible or newer driver with a less
	/// compatible or older driver.
	/// </para>
	/// <para>For information about how Windows selects a driver for a device, see</para>
	/// <para>How Windows Selects Drivers</para>
	/// <para>.</para>
	/// </param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type BOOL that <c>DiInstallDriver</c> sets to indicate whether a system is restart is required to
	/// complete the installation. This parameter is optional and can be <c>NULL</c>. If the parameter is supplied and a system restart
	/// is required to complete the installation, <c>DiInstallDriver</c> sets the value to <c>TRUE</c>. In this case, the caller must
	/// prompt the user to restart the system. If this parameter is supplied and a system restart is not required to complete the
	/// installation, <c>DiInstallDriver</c> sets the value to <c>FALSE</c>. If the parameter is <c>NULL</c> and a system restart is
	/// required to complete the installation, <c>DiInstallDriver</c> displays a system restart dialog box. For more information about
	/// this parameter, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiInstallDriver</c> returns <c>TRUE</c> if the function successfully preinstalled the specified driver package in the driver
	/// store. <c>DiInstallDriver</c> also returns <c>TRUE</c> if the function successfully installed the driver on one or more devices
	/// in the system. If the driver package is not successfully installed in the driver store, <c>DiInstallDriver</c> returns
	/// <c>FALSE</c> and the logged error can be retrieved by making call to <c>GetLastError</c>. Some of the more common error values
	/// that <c>GetLastError</c> might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the caller have Administrator privileges to
	/// preinstall a driver package in the driver store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The path of the specified INF file does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for Flags is not equal to zero or DIIRFLAG_FORCE_INF.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>DiInstallDriver</c> performs the following operations:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Preinstalls the driver package in the driver store. If there is an instance of the same driver package already preinstalled in
	/// the driver store, <c>DiInstallDriver</c> first removes that instance and then adds the new instance of the driver package to the
	/// driver store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Enumerates devices that are present in the system.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If Flags is equal to zero, installs the driver on a device only if the specified driver is a better match for the device than
	/// the driver that is currently installed on the device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If Flags is equal to DIIRFLAG_FORCE_INF, installs the driver on a device regardless of whether the driver package is the better
	/// match to the device than the driver that is currently installed on the device.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In general, an installation application should set NeedReboot to <c>NULL</c> to direct <c>DiInstallDriver</c> to prompt the user
	/// to restart the system if a restart is required to complete the installation. An application should supply a NeedReboot pointer
	/// only in the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application must call <c>DiInstallDriver</c> several times to complete an installation. In this case, the application should
	/// record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiInstallDriver</c> and, if so, prompt the
	/// user to restart the system after the final call to <c>DiInstallDriver</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiInstallDriver</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application is a class installer, in which case, the class installer should set the DI_NEEDREBOOT flag in the <c>Flags</c>
	/// member of the SP_DEVINSTALL_PARAMS structure for a device.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To install a selected driver on a selected device, call DiInstallDevice. For more info, see SetupAPI Functions that Simplify
	/// Driver Installation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-diinstalldrivera BOOL DiInstallDriverA( HWND hwndParent,
	// LPCSTR InfPath, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiInstallDriverA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiInstallDriver([In, Optional] HWND hwndParent, string InfPath, DIIRFLAG Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>The <c>DiRollbackDriver</c> function rolls back the driver that is installed on a specified device.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which driver
	/// rollback is performed.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the specific device in the specified device information set for which
	/// driver rollback is performed.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiRollbackDriver</c> uses to display any user interface component that is associated
	/// with a driver rollback for the specified device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A value of type DWORD that can be set to zero or ROLLBACK_FLAG_NO_UI.</para>
	/// <para>
	/// Typically, this flag should be set to zero, in which case <c>DiRollbackDriver</c> does not suppress the default user interface
	/// components that are associated with a driver rollback. However, if this flag is set to ROLLBACK_FLAG_NO_UI,
	/// <c>DiRollbackDriver</c> suppresses the display of user interface components that are associated with a driver rollback.
	/// </para>
	/// </param>
	/// <param name="NeedReboot">
	/// <para>
	/// A pointer to a value of type BOOL that <c>DiRollbackDriver</c> sets to indicate whether a system restart is required to complete
	/// the rollback. This parameter is optional and can be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the parameter is supplied and a system restart is required to complete the rollback, <c>DiRollbackDriver</c> sets the value
	/// to <c>TRUE</c>. In this case, the caller must prompt the user to restart the system. If this parameter is supplied and a system
	/// restart is not required to complete the installation, <c>DiRollbackDriver</c> sets the value to <c>FALSE</c>.
	/// </para>
	/// <para>
	/// If the parameter is <c>NULL</c> and a system restart is required to complete the rollback, <c>DiRollbackDriver</c> displays a
	/// system restart dialog box.
	/// </para>
	/// <para>For more information about this parameter, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiRollbackDriver</c> returns <c>TRUE</c> if the function successfully rolled back the driver for the device; otherwise,
	/// <c>DiRollbackDriver</c> returns <c>FALSE</c> and the logged error can be retrieved by making a call to <c>GetLastError</c>. Some
	/// of the more common error values that <c>GetLastError</c> might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the caller have Administrator privileges to
	/// roll back a driver package.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for Flags is not equal to zero or ROLLBACK_FLAG_NO_UI.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>A backup driver is not set for the device.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a previously installed backup driver is set for a device, a driver rollback for the device replaces the driver that is
	/// currently installed on the device with the backup driver. Windows maintains at most one backup driver for a device. Windows sets
	/// a driver as the backup driver for a device immediately after the driver is successfully installed on the device and Windows
	/// determines that the device is functioning correctly. However, if a driver does not install successfully on a device or the
	/// device does not function correctly after the installation, Windows does not set the driver as the backup driver for the device.
	/// For more information about driver rollback, see information about Device Manager in Help and Support Center.
	/// </para>
	/// <para>If the specified device has a backup driver, <c>DiRollbackDriver</c> performs the following operations:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// If Flags is set to zero, <c>DiRollbackDriver</c> prompts the user to confirm whether the backup driver should be installed.
	/// Otherwise, if Flags is set to ROLLBACK_FLAG_NO_UI, <c>DiRollbackDriver</c> installs the backup driver without prompting the user
	/// to confirm the installation of the backup driver.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>DiRollbackDriver</c> installs the backup driver. The driver is installed whether the backup driver is a better match for the
	/// device than the driver that is currently installed on the device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the driver that is replaced by the backup driver is not an inbox driver and is not installed on any other devices in the
	/// system, <c>DiRollbackDriver</c> removes the driver from the system. <c>DiRollbackDriver</c> removes the driver from the system
	/// because it is assumed that a user will replace a driver only if there is a problem with the driver.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the specified device does not have a backup driver, <c>DiRollbackDriver</c> calls <c>SetLastError</c> to set the error
	/// ERROR_NO_MORE_ITEMS, does not remove the currently installed driver, and returns <c>FALSE</c>.
	/// </para>
	/// <para>
	/// In general, installation applications should set NeedReboot to <c>NULL</c> so that the system will automatically initiate a
	/// system restart if a restart is required to complete the rollback. An application should supply a NeedReboot pointer only in the
	/// following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application must call <c>DiRollbackDriver</c> several times to complete an installation. In this case, the application
	/// should record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiRollbackDriver</c> and, if so,
	/// prompt the user to restart the system after the final call to <c>DiRollbackDriver</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiRollbackDriver</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To install a new driver for a device instead of rolling back the driver for the device, call DiInstallDriver or UpdateDriverForPlugAndPlayDevices.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-dirollbackdriver BOOL DiRollbackDriver( HDEVINFO
	// DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, HWND hwndParent, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiRollbackDriver")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiRollbackDriver([In] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, [In, Optional] HWND hwndParent,
		ROLLBACK_FLAG Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>The <c>DiShowUpdateDevice</c> function displays the Hardware Update wizard for a specified device.</summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiShowUpdateDevice</c> uses to display any user interface components that are
	/// associated with updating the specified device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to show
	/// the Hardware Update wizard.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the device for which to show the Hardware Update wizard.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type BOOL that <c>DiShowUpdateDevice</c> sets to indicate whether a system restart is required to
	/// complete the driver update. This parameter is optional and can be <c>NULL</c>. If the parameter is supplied and a system restart
	/// is required to complete the driver update, <c>DiShowUpdateDevice</c> sets the value to <c>TRUE</c>. In this case, the caller
	/// must prompt the user to restart the system. If this parameter is supplied and a system restart is not required to complete the
	/// installation, <c>DiShowUpdateDevice</c> sets the value to <c>FALSE</c>. If the parameter is <c>NULL</c> and a system restart is
	/// required to complete the driver update, <c>DiShowUpdateDevice</c> displays a system restart dialog box. For more information
	/// about this parameter, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiShowUpdateDevice</c> returns <c>TRUE</c> if the Hardware Update wizard successfully updated the driver for the specified
	/// device. Otherwise, <c>DiShowUpdateDevice</c> returns <c>FALSE</c> and the logged error can be retrieved by making a call to
	/// GetLastError. Some of the more common error values that GetLastError might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the calling process have Administrator
	/// privileges to update a driver package.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>The user canceled the Hardware Update wizard.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for Flags is not equal to zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>DiShowUpdateDevice</c> displays the Hardware Update wizard for the specified device instance. For information about how to
	/// update device drivers by using the Hardware Update wizard, see Help and Support Center.
	/// </para>
	/// <para>
	/// In general, installation applications should set NeedReboot to <c>NULL</c> so that the system will automatically initiate a
	/// system restart if a restart is required to complete a hardware update. An application should supply a NeedReboot pointer only in
	/// the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The installation application must call <c>DiShowUpdateDevice</c> several times to complete hardware updates. In this case, the
	/// application should record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiShowUpdateDevice</c>
	/// and, if so, prompt the user to restart the system after the final call to <c>DiShowUpdateDevice</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiShowUpdateDevice</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To roll back a driver for a device instead of invoking the Hardware Update wizard, call DiRollbackDriver.</para>
	/// <para>To install a new driver for a device instead of invoking the Hardware Update wizard, call DiInstallDriver or UpdateDriverForPlugAndPlayDevices.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-dishowupdatedevice BOOL DiShowUpdateDevice( HWND hwndParent,
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiShowUpdateDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiShowUpdateDevice([In, Optional] HWND hwndParent, HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		uint Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>The <c>DiShowUpdateDriver</c> function displays the Hardware Update wizard for a specified driver.</summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiShowUpdateDriver</c> uses to display any user interface components that are
	/// associated with updating the specified device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="FilePath">
	/// A pointer to a NULL-terminated string that supplies the fully qualified path of the INF file for the driver package.
	/// </param>
	/// <param name="Flags">This parameter must be set to zero.</param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type BOOL that <c>DiShowUpdateDriver</c> sets to indicate whether a system restart is required to
	/// complete the driver update. This parameter is optional and can be <c>NULL</c>. If the parameter is supplied and a system restart
	/// is required to complete the driver update, <c>DiShowUpdateDevice</c> sets the value to <c>TRUE</c>. In this case, the caller
	/// must prompt the user to restart the system. If this parameter is supplied and a system restart is not required to complete the
	/// installation, <c>DiShowUpdateDevice</c> sets the value to <c>FALSE</c>. If the parameter is <c>NULL</c> and a system restart is
	/// required to complete the driver update, <c>DiShowUpdateDevice</c> displays a system restart dialog box. For more information
	/// about this parameter, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiShowUpdateDriver</c> returns <c>TRUE</c> if the Hardware Update wizard successfully updated the driver for the specified
	/// device. Otherwise, <c>DiShowUpdateDevice</c> returns <c>FALSE</c> and the logged error can be retrieved by making a call to
	/// GetLastError. Some of the more common error values that GetLastError might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the calling process have Administrator
	/// privileges to update a driver package.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>The user canceled the Hardware Update wizard.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for Flags is not equal to zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiShowUpdateDriver")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiShowUpdateDriver([In, Optional] HWND hwndParent, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? FilePath,
		uint Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>
	/// <para>
	/// The <c>DiUninstallDevice</c> function uninstalls a device and removes its device node (devnode) from the system. This differs
	/// from using SetupDiCallClassInstaller with the DIF_REMOVE code because it attempts to uninstall the device node in addition to
	/// child devnodes that are present at the time of the call.
	/// </para>
	/// <para>
	/// Prior to Windows 8 any child devices that are not present at the time of the call will not be uninstalled. However, beginning
	/// with Windows 8, any child devices that are not present at the time of the call will be uninstalled.
	/// </para>
	/// </summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that is used to display any user interface component that is associated with the uninstallation
	/// request for the device. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element. This element represents the device to be
	/// uninstalled through this call.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the specified device in the specified device information set for which
	/// the uninstallation request is performed.
	/// </param>
	/// <param name="Flags">
	/// A value of type DWORD that specifies device uninstallation flags. Starting with Windows 7, this parameter must be set to zero.
	/// </param>
	/// <param name="NeedReboot">
	/// <para>
	/// A pointer to a value of type BOOL that <c>DiUninstallDevice</c> sets to indicate whether a system restart is required to
	/// complete the device uninstallation request. This parameter is optional and can be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the parameter is given and a system restart is required, <c>DiUninstallDevice</c> sets the value to <c>TRUE</c>. In this
	/// case, the application must prompt the user to restart the system. If this parameter is supplied and a system restart is not
	/// required, <c>DiUninstallDevice</c> sets the value to <c>FALSE</c>.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c> and a system restart is required to complete the device uninstallation,
	/// <c>DiUninstallDevice</c> displays a system restart dialog box.
	/// </para>
	/// <para>For more information about this parameter, see the <c>Remarks</c> section.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiUninstallDevice</c> returns <c>TRUE</c> if the function successfully uninstalled the top-level device node that represents
	/// the device. Otherwise, <c>DiUninstallDevice</c> returns <c>FALSE</c>, and the logged error can be retrieved by making a call to
	/// GetLastError. The following list shows some of the more common error values that <c>GetLastError</c> might return for this API:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the caller have Administrator privileges to
	/// uninstall devices.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value that is specified for the Flags parameter is not equal to zero.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The return value does not indicate that the removal of all child devnodes has succeeded or failed. Starting with
	/// Windows Vista, information about the status of the removal of child devnodes is available in the Setupapi.dev.log file. For more
	/// information about this file, see SetupAPI Text Logs.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>DiUninstallDevice</c> performs the same function as SetupDiCallClassInstaller when used with the DIF_REMOVE code. The key
	/// difference is that child devnodes for the top-level device are also deleted. <c>DiUninstallDevice</c> only returns failure if
	/// the top-level device node failed to be uninstalled, which is consistent with the behavior of <c>SetupDiCallClassInstaller</c>
	/// when used with the <c>DIF_REMOVE</c> code. Detailed information about whether child devnode uninstallation succeeded is
	/// available in the Setupapi.dev.log file.
	/// </para>
	/// <para>
	/// The device to be uninstalled is specified by providing a device information set that includes the referenced device, and a
	/// SP_DEVINFO_DATA structure for the specific device. These are provided in the DeviceInfoSet and DeviceInfoData parameters.
	/// </para>
	/// <para>
	/// To create a device information set that contains the specified device and to obtain an SP_DEVINFO_DATA structure for the device,
	/// complete one of the following tasks:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Call SetupDiGetClassDevs to retrieve a device information set that contains the device and then call SetupDiEnumDeviceInfo to
	/// enumerate the devices in the device information set. On each call, <c>SetupDiEnumDeviceInfo</c> returns an SP_DEVINFO_DATA
	/// structure that represents the enumerated device in the device information set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Call SetupDiEnumDeviceInfo to add a device with a known device instance ID to the device information set. SetupDiOpenDeviceInfo
	/// returns an SP_DEVINFO_DATA structure that represents the device in the device information set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In case the device uninstallation request requires a restart of the computer, <c>DiUninstallDevice</c> prompts the user to
	/// restart the system if the NeedReboot parameter is set to <c>NULL</c>. If there is any user interface window that the application
	/// is using, the hwndParent parameter should be set to the value of that window's handle.
	/// </para>
	/// <para>
	/// However, if the application manages the notification of a required system restart, it must set the NeedReboot parameter to a
	/// non- <c>NULL</c> value. <c>DiUninstallDevice</c> sets the NeedReboot parameter to <c>TRUE</c> or <c>FALSE</c>, depending on
	/// whether a system restart is required.
	/// </para>
	/// <para>The following list shows examples of why the application might manage the system restart:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application has to uninstall several devices. After all the devices are uninstalled, the application should prompt the user
	/// to restart the system if any call to <c>DiUninstallDevice</c> returned <c>TRUE</c> in the NeedReboot parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application requires some other operations to occur before the system can be restarted. If a system restart is required, the
	/// application should finish the required operations and then prompt the user to restart the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application is a class installer. In this case, the class installer should set the <c>DI_NEEDREBOOT</c> flag in the
	/// <c>Flags</c> member of the SP_DEVINSTALL_PARAMS structure for a device.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-diuninstalldevice BOOL DiUninstallDevice( HWND hwndParent,
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiUninstallDevice")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiUninstallDevice(HWND hwndParent, HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		uint Flags, [MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>
	/// The <c>DiUninstallDriver</c> function removes a driver from any devices it is installed on by installing those devices with
	/// another matching driver, if available, or the null driver if no other matching driver is available. Then the specified driver is
	/// removed from the driver store.
	/// </summary>
	/// <param name="hwndParent">
	/// A handle to the top-level window that <c>DiUninstallDriver</c> should use to display any user interface component that is
	/// associated with uninstalling the driver. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="InfPath">
	/// A pointer to a NULL-terminated string that supplies the fully qualified path of the INF file for the driver package.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A value of type DWORD that specifies zero or one or more of the following flags: DIURFLAG_NO_REMOVE_INF. Typically, this flag
	/// should be set to zero.
	/// </para>
	/// <para>
	/// If this flag is zero, <c>DiUninstallDriver</c> only uninstalls the specified driver from a device if the driver is a better
	/// match for a device than the driver that is currently installed on a device. However, if this flag is set to
	/// DIURFLAG_NO_REMOVE_INF, <c>DiUninstallDriver</c> removes the driver package from any devices it is installed on, but does not
	/// remove the drive package from the Driver Store.
	/// </para>
	/// <para>
	/// <c>Caution:</c> Forcing the uninstallation of the driver can result in replacing a more compatible or newer driver with a less
	/// compatible or older driver.
	/// </para>
	/// <para>For information about how Windows selects a driver for a device, see</para>
	/// <para>How Windows Selects Drivers</para>
	/// <para>.</para>
	/// </param>
	/// <param name="NeedReboot">
	/// A pointer to a value of type BOOL that <c>DiUninstallDriver</c> sets to indicate whether a system restart is required to
	/// complete the uninstallation. This parameter is optional and can be <c>NULL</c>. If the parameter is supplied and a system
	/// restart is required to complete the uninstallation, <c>DiUninstallDriver</c> sets the value to <c>TRUE</c>. In this case, the
	/// caller must prompt the user to restart the system. If this parameter is supplied and a system restart is not required to
	/// complete the uninstallation, <c>DiUninstallDriver</c> sets the value to <c>FALSE</c>. If the parameter is <c>NULL</c> and a
	/// system restart is required to complete the uninstallation, <c>DiUninstallDriver</c> displays a system restart dialog box. For
	/// more information about this parameter, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <para>
	/// <c>DiUninstallDriver</c> returns <c>TRUE</c> if the function successfully removes the driver package from any devices it is
	/// installed on and is successfully removed from the driver store of the system. If the driver package is not successfully
	/// uninstalled from the driver store, <c>DiUninstallDriver</c> returns <c>FALSE</c> and the logged error can be retrieved by making
	/// a call to <c>GetLastError</c>. Some of the more common error values that <c>GetLastError</c> might return are as follows:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The caller does not have Administrator privileges. By default, Windows requires that the caller have Administrator privileges to
	/// uninstall a driver package from the driver store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The path of the specified INF file does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for Flags is not equal to zero or DIURFLAG_NO_REMOVE_INF.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>
	/// The calling application is a 32-bit application that is attempting to execute in a 64-bit environment, which is not allowed. For
	/// more information, see Installing Devices on 64-Bit Systems.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In general, an uninstallation application should set NeedReboot to <c>NULL</c> to direct <c>DiUninstallDriver</c> to prompt the
	/// user to restart the system if a restart is required to complete the removal. An application should supply a NeedReboot pointer
	/// only in the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The application must call <c>DiUninstallDriver</c> several times to complete an uninstallation. In this case, the application
	/// should record whether a <c>TRUE</c> NeedReboot value is returned by any of the calls to <c>DiUninstallDriver</c> and, if so,
	/// prompt the user to restart the system after the final call to <c>DiUninstallDriver</c> returns.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The application must perform required operations, other than calling <c>DiUninstallDriver</c>, before a system restart should
	/// occur. If a system restart is required, the application should finish the required operations and then prompt the user to
	/// restart the system.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-diuninstalldriverw BOOL DiUninstallDriverW( HWND hwndParent,
	// LPCWSTR InfPath, DWORD Flags, PBOOL NeedReboot );
	[DllImport(Lib_NewDev, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.DiUninstallDriverW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DiUninstallDriver([In, Optional] HWND hwndParent, string InfPath, DIURFLAG Flags,
		[MarshalAs(UnmanagedType.Bool)] out bool NeedReboot);

	/// <summary>
	/// Given an INF file and a hardware ID, the <c>UpdateDriverForPlugAndPlayDevices</c> function installs updated drivers for devices
	/// that match the hardware ID.
	/// </summary>
	/// <param name="hwndParent">A handle to the top-level window to use for any UI related to installing devices.</param>
	/// <param name="HardwareId">
	/// A pointer to a NULL-terminated string that supplies the hardware identifier to match existing devices on the computer. The
	/// maximum length of a NULL-terminated hardware identifier is MAX_DEVICE_ID_LEN. For more information about hardware identifiers,
	/// see Device Identification Strings.
	/// </param>
	/// <param name="FullInfPath">
	/// A pointer to a NULL-terminated string that supplies the full path file name of an INF file. The files should be on the
	/// distribution media or in a vendor-created directory, not in a system location such as %SystemRoot%\inf.
	/// <c>UpdateDriverForPlugAndPlayDevices</c> copies driver files to the appropriate system locations if the installation is successful.
	/// </param>
	/// <param name="InstallFlags">
	/// <para>A caller-supplied value created by using OR to combine zero or more of the following bit flags:</para>
	/// <para>INSTALLFLAG_FORCE</para>
	/// <para>
	/// If this flag is set and the function finds a device that matches the HardwareId value, the function installs new drivers for the
	/// device whether better drivers already exist on the computer.
	/// </para>
	/// <para>
	/// <c>Important</c> Use this flag only with extreme caution. Setting this flag can cause an older driver to be installed over a
	/// newer driver, if a user runs the vendor's application after newer drivers are available.
	/// </para>
	/// <para>INSTALLFLAG_READONLY</para>
	/// <para>
	/// If this flag is set, the function will not copy, rename, or delete any installation files. Use of this flag should be limited to
	/// environments in which file access is restricted or impossible, such as an "embedded" operating system.
	/// </para>
	/// <para>INSTALLFLAG_NONINTERACTIVE</para>
	/// <para>
	/// If this flag is set, the function will return <c>FALSE</c> when any attempt to display UI is detected. Set this flag only if the
	/// function will be called from a component (such as a service) that cannot display UI.
	/// </para>
	/// <para><c>Note</c> If this flag is set and a UI display is attempted, the device can be left in an indeterminate state.</para>
	/// <para>The InstallFlags parameter is typically zero.</para>
	/// </param>
	/// <param name="bRebootRequired">
	/// <para>
	/// A pointer to a BOOL-typed variable that indicates whether a restart is required and who should prompt for it. This pointer is
	/// optional and can be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If the pointer is <c>NULL</c>, <c>UpdateDriverForPlugAndPlayDevices</c> prompts for a restart after installing drivers, if
	/// necessary. If the pointer is supplied, the function returns a BOOLEAN value that is <c>TRUE</c> if the system should be
	/// restarted. It is then the caller's responsibility to prompt for a restart.
	/// </para>
	/// <para>For more information, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <returns>
	/// <para>The function returns <c>TRUE</c> if a device was upgraded to the specified driver.</para>
	/// <para>
	/// Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved with a call to <c>GetLastError</c>. Possible error
	/// values returned by <c>GetLastError</c> are included in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The path that was specified for FullInfPath does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_IN_WOW64</term>
	/// <term>The calling application is a 32-bit application attempting to execute in a 64-bit environment, which is not allowed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>The value specified for InstallFlags is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_DEVINST</term>
	/// <term>The value specified for HardwareId does not match any device on the system. That is, the device is not plugged in.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>
	/// The function found a match for the HardwareId value, but the specified driver was not a better match than the current driver and
	/// the caller did not specify the INSTALLFLAG_FORCE flag.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>UpdateDriverForPlugAndPlayDevices</c> scans the devices on the system and attempts to install the drivers specified by
	/// FullInfPath for any devices that match the specified HardwareId value.
	/// </para>
	/// <para>
	/// The default behavior is to only install the specified drivers if they are better match than the currently installed drivers and
	/// the specified drivers are also a better match than any drivers in %SystemRoot%\inf. For more information, see How Windows
	/// Selects Drivers.
	/// </para>
	/// <para>
	/// <c>UpdateDriverForPlugAndPlayDevices</c> can also be used to determine whether the device with the specified HardwareId value is
	/// plugged in. For more information, see Writing a Device Installation Application.
	/// </para>
	/// <para>
	/// <c>UpdateDriverForPlugAndPlayDevices</c> sends an IRP_MN_QUERY_REMOVE_DEVICE request to the specified device, all the children
	/// of the device, and all other devices that are recursively part of the removal relations for the device. If any of these devices
	/// fail a query remove request, <c>UpdateDriverForPlugAndPlayDevices</c> sets the DI_NEEDREBOOT flag in the <c>Flags</c> member of
	/// the SP_DEVINSTALL_PARAMS structure for the device. For information about removal relations, see the
	/// IRP_MN_QUERY_DEVICE_RELATIONS request.
	/// </para>
	/// <para>
	/// Generally, device installation applications should supply <c>NULL</c> for bRebootRequired. So, the system will initiate a
	/// restart if necessary. An application should specify a pointer value only in the following cases:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The application must call <c>UpdateDriverForPlugAndPlayDevices</c> several times to complete an installation.</term>
	/// </item>
	/// <item>
	/// <term>The application must perform other operations before the restart (if required) occurs.</term>
	/// </item>
	/// <item>
	/// <term>The application is a class installer, which should set DI_NEEDREBOOT in SP_DEVINSTALL_PARAMS if a restart is needed.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the application must call <c>UpdateDriverForPlugAndPlayDevices</c> several times, it should save any <c>TRUE</c> restart
	/// status value received and then prompt for a restart after the final call has returned.
	/// </para>
	/// <para>
	/// If the function returns ERROR_IN_WOW64 in a 32-bit application, the application is executing on a 64-bit system, which is not
	/// allowed. For more information, see Installing Devices on 64-Bit Systems.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/newdev/nf-newdev-updatedriverforplugandplaydevicesa BOOL
	// UpdateDriverForPlugAndPlayDevicesA( HWND hwndParent, LPCSTR HardwareId, LPCSTR FullInfPath, DWORD InstallFlags, PBOOL
	// bRebootRequired );
	[DllImport(Lib_NewDev, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("newdev.h", MSDNShortId = "NF:newdev.UpdateDriverForPlugAndPlayDevicesA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateDriverForPlugAndPlayDevices([In, Optional] HWND hwndParent, string HardwareId,
		string FullInfPath, INSTALLFLAG InstallFlags, [MarshalAs(UnmanagedType.Bool)] out bool bRebootRequired);
}