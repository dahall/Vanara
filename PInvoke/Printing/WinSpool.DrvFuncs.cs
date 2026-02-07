using Microsoft.Win32;
using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Contains functions, structures and constants from winspool.h.</summary>
public static partial class WinSpool
{
	/// <summary>
	/// The printer driver and all the files in the printer driver directory must be added. The file time stamps are ignored when
	/// dwFlags has a value of IPDFP_COPY_ALL_FILES.
	/// </summary>
	public const uint IPDFP_COPY_ALL_FILES = 0x00000001;

	/// <summary>The options for copying the driver files.</summary>
	[PInvokeData("winspool.h", MSDNShortId = "472adb7d-39cc-4c76-b96c-610ff9d276ad")]
	[Flags]
	public enum APD
	{
		/// <summary>
		/// Add the printer driver only if all the files in the printer-driver directory are newer than any corresponding files
		/// currently in use.
		/// </summary>
		APD_STRICT_UPGRADE = 0x00000001,

		/// <summary>
		/// Add the printer driver only if all the files in the printer-driver directory are older than any corresponding files
		/// currently in use.
		/// </summary>
		APD_STRICT_DOWNGRADE = 0x00000002,

		/// <summary>
		/// Add the printer driver and copy all the files in the printer-driver directory. The file time stamps are ignored with this option.
		/// </summary>
		APD_COPY_ALL_FILES = 0x00000004,

		/// <summary>
		/// Add the printer driver and copy the files in the printer-driver directory that are newer than any corresponding files that
		/// are currently in use. This flag emulates the behavior of AddPrinterDriver.
		/// </summary>
		APD_COPY_NEW_FILES = 0x00000008,

		/// <summary>
		/// Add the printer driver using the fully qualified file names specified in the DRIVER_INFO_6 structure. This flag is ORed in
		/// conjunction with one of the other copy flags. If this flag is set, AddPrinterDriverEx will fail if the files do not exist
		/// where they are specified to exist by the DRIVER_INFO_6 structure. The files do not need to be copied to the system's
		/// printer-driver directory. See the Remarks. Windows 2000: This flag is not supported.
		/// </summary>
		APD_COPY_FROM_DIRECTORY = 0x00000010,
	}

	/// <summary>The options for deleting files and versions of the driver.</summary>
	[PInvokeData("winspool.h", MSDNShortId = "1a3d7c7f-1d45-4877-a8f7-a77f40e3c319")]
	[Flags]
	public enum DPD
	{
		/// <summary>Removes any unused driver files.</summary>
		DPD_DELETE_UNUSED_FILES = 0x00000001,

		/// <summary>
		/// Deletes the version specified in dwVersionFlag. This does not ensure that the driver will be removed from the list of
		/// supported drivers for the server.
		/// </summary>
		DPD_DELETE_SPECIFIC_VERSION = 0x00000002,

		/// <summary>
		/// Deletes the driver only if all its associated files can be removed. The delete operation fails if any of the driver's files
		/// are being used by some other installed driver.
		/// </summary>
		DPD_DELETE_ALL_FILES = 0x00000004,
	}

	/// <summary>Options for <c>UploadPrinterDriverPackage</c>.</summary>
	[PInvokeData("winspool.h", MSDNShortId = "dd3b3a3b-8ded-44ae-85dd-e630bc62e898")]
	[Flags]
	public enum UPDP
	{
		/// <summary>The UI will not be shown during the upload.</summary>
		UPDP_SILENT_UPLOAD = 0x00000001,

		/// <summary>The files will be uploaded even if the package is already in the server's driver store.</summary>
		UPDP_UPLOAD_ALWAYS = 0x00000002,

		/// <summary>
		/// The server's driver store will be checked before upload to see if the package is already there. This setting is ignored if
		/// UPDP_UPLOAD_ALWAYS is set.
		/// </summary>
		UPDP_CHECK_DRIVERSTORE = 0x00000004,
	}

	/// <summary>The <c>AddMonitor</c> function installs a local port monitor and links the configuration, data, and monitor files.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the monitor should be installed. For
	/// systems that support only local installation of monitors, this string should be <c>NULL</c>.
	/// </param>
	/// <param name="Level">The version of the structure to which pMonitors points. This value must be 2.</param>
	/// <param name="pMonitors">
	/// <para>
	/// A pointer to a <c>MONITOR_INFO_2</c> structure. If the <c>pEnvironment</c> member of the pMonitors structure is <c>NULL</c>, the
	/// current environment of the caller (client), not of the destination (server), is used.
	/// </para>
	/// <para>
	/// Note that the call will fail if the environment does not match the environment of the server, that is, you can only add a
	/// monitor that was written for the architecture of the server.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before an application calls the <c>AddMonitor</c> function, all files required by the monitor must be copied to the SYSTEM32 directory.
	/// </para>
	/// <para>To determine the port monitors that are currently installed, call the <c>EnumMonitors</c> function.</para>
	/// <para>To remove a monitor added by <c>AddMonitor</c>, call the <c>DeleteMonitor</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addmonitor BOOL AddMonitor( _In_ StrPtrAuto pName, _In_ DWORD Level, _In_
	// LPBYTE pMonitors );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "6a556422-5360-42d2-b177-dba0498c06d8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddMonitor([Optional] string? pName, uint Level, [In] IntPtr pMonitors);

	/// <summary>The <c>AddMonitor</c> function installs a local port monitor and links the configuration, data, and monitor files.</summary>
	/// <typeparam name="T">The type of the structure to which pMonitors points. This value must be <c>MONITOR_INFO_2</c>.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the monitor should be installed. For
	/// systems that support only local installation of monitors, this string should be <c>NULL</c>.
	/// </param>
	/// <param name="pMonitors">
	/// <para>
	/// A <c>MONITOR_INFO_2</c> structure. If the <c>pEnvironment</c> member of the pMonitors structure is <c>NULL</c>, the current
	/// environment of the caller (client), not of the destination (server), is used.
	/// </para>
	/// <para>
	/// Note that the call will fail if the environment does not match the environment of the server, that is, you can only add a
	/// monitor that was written for the architecture of the server.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before an application calls the <c>AddMonitor</c> function, all files required by the monitor must be copied to the SYSTEM32 directory.
	/// </para>
	/// <para>To determine the port monitors that are currently installed, call the <c>EnumMonitors</c> function.</para>
	/// <para>To remove a monitor added by <c>AddMonitor</c>, call the <c>DeleteMonitor</c> function.</para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "6a556422-5360-42d2-b177-dba0498c06d8")]
	public static bool AddMonitor<T>([Optional] string? pName, in T pMonitors) where T : struct
	{
		if (!TryGetLevel<T>("MONITOR_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(AddMonitor)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pMonitors);
		return AddMonitor(pName, lvl, mem);
	}

	/// <summary>
	/// The <c>AddPort</c> function adds the name of a port to the list of supported ports. The <c>AddPort</c> function is exported by
	/// the port monitor.
	/// </summary>
	/// <param name="pName">
	/// A pointer to a zero-terminated string that specifies the name of the server to which the port is connected. If this parameter is
	/// <c>NULL</c>, the port is local.
	/// </param>
	/// <param name="hWnd">A handle to the parent window of the <c>AddPort</c> dialog box.</param>
	/// <param name="pMonitorName">A pointer to a zero-terminated string that specifies the monitor associated with the port.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>AddPort</c> function browses the network to find existing ports, and displays a dialog box for the user. The
	/// <c>AddPort</c> function should validate the port name entered by the user by calling <c>EnumPorts</c> to ensure that no
	/// duplicate names exist.
	/// </para>
	/// <para>
	/// The caller of the <c>AddPort</c> function must have SERVER_ACCESS_ADMINISTER access to the server to which the port is connected.
	/// </para>
	/// <para>
	/// To add a port without displaying a dialog box, call the <c>XcvData</c> function instead of <c>AddPort</c>. For more information
	/// about <c>XcvData</c>, see the Microsoft Windows Driver Development Kit (DDK).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addport BOOL AddPort( _In_ StrPtrAuto pName, _In_ HWND hWnd, _In_ StrPtrAuto
	// pMonitorName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "9191d507-9167-4488-a4b4-286590a8a62a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPort([Optional] string? pName, HWND hWnd, string pMonitorName);

	/// <summary>
	/// <para>
	/// The <c>AddPrinterDriver</c> function installs a local or remote printer driver and associates the configuration, data, and
	/// driver files.
	/// </para>
	/// <para>
	/// For more flexibility in installing or upgrading printer drivers, use the <c>AddPrinterDriverEx</c> function because it allows
	/// strict upgrade, strict downgrade, copying of newer files only, and copying of all files (regardless of the file time stamps).
	/// </para>
	/// </summary>
	/// <param name="pName">
	/// <para>A pointer to a null-terminated string that specifies the name of the server on which the driver should be installed.</para>
	/// <para>If pName is <c>NULL</c>, the driver will be installed locally.</para>
	/// </param>
	/// <param name="Level">
	/// <para>The version of the structure to which pDriverInfo points.</para>
	/// <para>This value can be 2, 3, 4, 6, or 8.</para>
	/// </param>
	/// <param name="pDriverInfo">
	/// <para>A pointer to a structure containing printer driver information. This depends on the value of Level.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Printer Drive Structure</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>pEnvironment</c> member of the structure pointed to by pDriverInfo is <c>NULL</c>, the current environment of the
	/// caller/client (not of the destination/server) is used.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before an application calls the <c>AddPrinterDriver</c> function, all files required by the driver must be copied to the
	/// system's printer-driver directory. An application can retrieve the name of this directory by calling the
	/// <c>GetPrinterDriverDirectory</c> function.
	/// </para>
	/// <para>An application can determine which printer drivers are currently installed by calling the <c>EnumPrinterDrivers</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinterdriver BOOL AddPrinterDriver( _In_ StrPtrAuto pName, _In_ DWORD
	// Level, _In_ LPBYTE pDriverInfo );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "0f762800-f5a5-40ea-8be1-7fd8bda23788")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrinterDriver([Optional] string? pName, uint Level, [In] IntPtr pDriverInfo);

	/// <summary>
	/// The <c>AddPrinterDriverEx</c> function installs a local or remote printer driver and links the configuration, data, and driver
	/// files. Besides having the capabilities of <c>AddPrinterDriver</c>, it also has options that permit strict upgrade, strict
	/// downgrade, copying of newer files only, and copying of all files (regardless of file time stamps).
	/// </summary>
	/// <typeparam name="T">The type of the structure containing printer driver information.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the driver should be installed. If this
	/// parameter is <c>NULL</c>, the function installs the driver on the local computer.
	/// </param>
	/// <param name="pDriverInfo">
	/// <para>A structure containing printer driver information. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value of Level</term>
	/// <term>DRIVER_INFO_* Structure</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>pEnvironment</c> member of the structure pointed to by pDriverInfo is <c>NULL</c>, the function uses the current
	/// environment of the caller/client, not the environment of the destination/server.
	/// </para>
	/// </param>
	/// <param name="dwFileCopyFlags">
	/// <para>The options for copying the driver files. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>APD_COPY_ALL_FILES</term>
	/// <term>
	/// Add the printer driver and copy all the files in the printer-driver directory. The file time stamps are ignored with this option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_COPY_FROM_DIRECTORY</term>
	/// <term>
	/// Add the printer driver using the fully qualified file names specified in the DRIVER_INFO_6 structure. This flag is ORed in
	/// conjunction with one of the other copy flags. If this flag is set, AddPrinterDriverEx will fail if the files do not exist where
	/// they are specified to exist by the DRIVER_INFO_6 structure. The files do not need to be copied to the system's printer-driver
	/// directory. See the Remarks. Windows 2000: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_COPY_NEW_FILES</term>
	/// <term>
	/// Add the printer driver and copy the files in the printer-driver directory that are newer than any corresponding files that are
	/// currently in use. This flag emulates the behavior of AddPrinterDriver.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_STRICT_DOWNGRADE</term>
	/// <term>
	/// Add the printer driver only if all the files in the printer-driver directory are older than any corresponding files currently in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_STRICT_UPGRADE</term>
	/// <term>
	/// Add the printer driver only if all the files in the printer-driver directory are newer than any corresponding files currently in use.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>
	/// If the printer driver is known to have problems working with the operating system, <c>AddPrinterDriverEx</c> will fail with one
	/// of the following error codes:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_PRINTER_DRIVER_BLOCKED</term>
	/// <term>The driver does not work on the operating system.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PRINTER_DRIVER_WARNED</term>
	/// <term>
	/// The driver is unreliable on the operating system. However, if APD_INSTALL_WARNED_DRIVER is specified, the driver is installed
	/// and no warning is given.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For more information, see the Remarks.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before calling the <c>AddPrinterDriverEx</c> function, all files required by the driver must be copied to the system's
	/// printer-driver directory. To retrieve the name of this directory, call the <c>GetPrinterDriverDirectory</c> function.
	/// </para>
	/// <para>To determine which printer drivers are currently installed, call the <c>EnumPrinterDrivers</c> function.</para>
	/// <para>
	/// If the printer driver has been successfully added, the function calls the DrvDriverEvent (DRIVER_EVENT_INITIALIZE, Level,
	/// DRIVER_INFO_*, lparam ) function to allow the driver to perform any initializations required during the installation of a
	/// printer driver. For more information about <c>DrvDriverEvent</c>, see the Microsoft Windows Driver Development Kit (DDK)
	/// </para>
	/// <para>
	/// The driver should not use a UI call during the call to <c>DrvDriverEvent</c>. To do UI-related jobs, the installer should either
	/// use the VendorSetup entry in the printer's .inf file or, for Plug and Play devices, the installer can use a device-specific
	/// co-installer. For more information about VendorSetup, see the DDK.
	/// </para>
	/// <para>
	/// The files that are referenced in the <c>DRIVER_INFO_6</c> structure must be local to the machine from which the call is made. A
	/// file name can be a UNC name as long as the UNC name is the local machine.
	/// </para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "472adb7d-39cc-4c76-b96c-610ff9d276ad")]
	public static bool AddPrinterDriverEx<T>([Optional] string? pName, in T pDriverInfo, APD dwFileCopyFlags = APD.APD_COPY_NEW_FILES) where T : struct
	{
		if (!TryGetLevel<T>("DRIVER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(AddPrinterDriverEx)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pDriverInfo);
		return AddPrinterDriverEx(pName, lvl, mem, dwFileCopyFlags);
	}

	/// <summary>
	/// The <c>AddPrinterDriverEx</c> function installs a local or remote printer driver and links the configuration, data, and driver
	/// files. Besides having the capabilities of <c>AddPrinterDriver</c>, it also has options that permit strict upgrade, strict
	/// downgrade, copying of newer files only, and copying of all files (regardless of file time stamps).
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the driver should be installed. If this
	/// parameter is <c>NULL</c>, the function installs the driver on the local computer.
	/// </param>
	/// <param name="Level">The version of the structure to which pDriverInfo points. This value can be 2, 3, 4, 6, or 8.</param>
	/// <param name="pDriverInfo">
	/// <para>A pointer to a structure containing printer driver information. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value of Level</term>
	/// <term>DRIVER_INFO_* Structure</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>pEnvironment</c> member of the structure pointed to by pDriverInfo is <c>NULL</c>, the function uses the current
	/// environment of the caller/client, not the environment of the destination/server.
	/// </para>
	/// </param>
	/// <param name="dwFileCopyFlags">
	/// <para>The options for copying the driver files. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>APD_COPY_ALL_FILES</term>
	/// <term>
	/// Add the printer driver and copy all the files in the printer-driver directory. The file time stamps are ignored with this option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_COPY_FROM_DIRECTORY</term>
	/// <term>
	/// Add the printer driver using the fully qualified file names specified in the DRIVER_INFO_6 structure. This flag is ORed in
	/// conjunction with one of the other copy flags. If this flag is set, AddPrinterDriverEx will fail if the files do not exist where
	/// they are specified to exist by the DRIVER_INFO_6 structure. The files do not need to be copied to the system's printer-driver
	/// directory. See the Remarks. Windows 2000: This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_COPY_NEW_FILES</term>
	/// <term>
	/// Add the printer driver and copy the files in the printer-driver directory that are newer than any corresponding files that are
	/// currently in use. This flag emulates the behavior of AddPrinterDriver.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_STRICT_DOWNGRADE</term>
	/// <term>
	/// Add the printer driver only if all the files in the printer-driver directory are older than any corresponding files currently in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term>APD_STRICT_UPGRADE</term>
	/// <term>
	/// Add the printer driver only if all the files in the printer-driver directory are newer than any corresponding files currently in use.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>
	/// If the printer driver is known to have problems working with the operating system, <c>AddPrinterDriverEx</c> will fail with one
	/// of the following error codes:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_PRINTER_DRIVER_BLOCKED</term>
	/// <term>The driver does not work on the operating system.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PRINTER_DRIVER_WARNED</term>
	/// <term>
	/// The driver is unreliable on the operating system. However, if APD_INSTALL_WARNED_DRIVER is specified, the driver is installed
	/// and no warning is given.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For more information, see the Remarks.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before calling the <c>AddPrinterDriverEx</c> function, all files required by the driver must be copied to the system's
	/// printer-driver directory. To retrieve the name of this directory, call the <c>GetPrinterDriverDirectory</c> function.
	/// </para>
	/// <para>To determine which printer drivers are currently installed, call the <c>EnumPrinterDrivers</c> function.</para>
	/// <para>
	/// If the printer driver has been successfully added, the function calls the DrvDriverEvent (DRIVER_EVENT_INITIALIZE, Level,
	/// DRIVER_INFO_*, lparam ) function to allow the driver to perform any initializations required during the installation of a
	/// printer driver. For more information about <c>DrvDriverEvent</c>, see the Microsoft Windows Driver Development Kit (DDK)
	/// </para>
	/// <para>
	/// The driver should not use a UI call during the call to <c>DrvDriverEvent</c>. To do UI-related jobs, the installer should either
	/// use the VendorSetup entry in the printer's .inf file or, for Plug and Play devices, the installer can use a device-specific
	/// co-installer. For more information about VendorSetup, see the DDK.
	/// </para>
	/// <para>
	/// The files that are referenced in the <c>DRIVER_INFO_6</c> structure must be local to the machine from which the call is made. A
	/// file name can be a UNC name as long as the UNC name is the local machine.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprinterdriverex BOOL AddPrinterDriverEx( _In_ StrPtrAuto pName, _In_
	// DWORD Level, _Inout_ LPBYTE pDriverInfo, _In_ DWORD dwFileCopyFlags );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "472adb7d-39cc-4c76-b96c-610ff9d276ad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrinterDriverEx([Optional] string? pName, uint Level, [In, Out] IntPtr pDriverInfo, APD dwFileCopyFlags);

	/// <summary>
	/// The <c>AddPrintProcessor</c> function installs a print processor on the specified server and adds the print-processor name to
	/// the list of supported print processors.
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the print processor should be installed. If
	/// this parameter is <c>NULL</c>, the print processor is installed locally.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the caller/client (not of the destination/server) is used.
	/// </param>
	/// <param name="pPathName">
	/// A pointer to a null-terminated string that specifies the name of the file that contains the print processor. This file must be
	/// in the system print-processor directory.
	/// </param>
	/// <param name="pPrintProcessorName">A pointer to a null-terminated string that specifies the name of the print processor.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// Before calling the <c>AddPrintProcessor</c> function, an application should verify that the file containing the print processor
	/// is stored in the system print-processor directory. An application can retrieve the name of the system print-processor directory
	/// by calling the <c>GetPrintProcessorDirectory</c> function.
	/// </para>
	/// <para>An application can determine the name of existing print processors by calling the <c>EnumPrintProcessors</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprintprocessor BOOL AddPrintProcessor( _In_ StrPtrAuto pName, _In_ StrPtrAuto
	// pEnvironment, _In_ StrPtrAuto pPathName, _In_ StrPtrAuto pPrintProcessorName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "99899cee-f74d-4405-8ea5-616e3769aba9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrintProcessor([Optional] string? pName, [Optional] string? pEnvironment, string pPathName, string pPrintProcessorName);

	/// <summary>
	/// The <c>AddPrintProvidor</c> function installs a local print provider and links the configuration, data, and provider files.
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the provider should be installed. For
	/// systems that only support local installation of providers, this parameter should be <c>NULL</c>.
	/// </param>
	/// <param name="Level">
	/// <para>The level of the structure to which pProviderInfo points. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>Function uses a PROVIDOR_INFO_1 structure.</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>Function uses a PROVIDOR_INFO_2 structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pProviderInfo">A pointer to a print provider structure, as indicated by Level.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before an application calls the <c>AddPrintProvidor</c> function, all files required by the provider must be copied to the
	/// SYSTEM32 directory.
	/// </para>
	/// <para>A provider added by <c>AddPrintProvidor</c> may be removed by calling <c>DeletePrintProvidor</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/addprintprovidor BOOL AddPrintProvidor( _In_ StrPtrAuto pName, _In_ DWORD
	// Level, _In_ LPBYTE pProviderInfo );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "f34549c3-0474-48ba-9307-5b36f02dbe1c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddPrintProvidor([Optional] string? pName, uint Level, [In] IntPtr pProviderInfo);

	/// <summary>
	/// The <c>AddPrintProvidor</c> function installs a local print provider and links the configuration, data, and provider files.
	/// </summary>
	/// <typeparam name="T">The type of the structure containing print provider information.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the provider should be installed. For
	/// systems that only support local installation of providers, this parameter should be <c>NULL</c>.
	/// </param>
	/// <param name="pProviderInfo">
	/// <para>A print provider structure. It can be one of the following.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Function uses a PROVIDOR_INFO_1 structure.</term>
	/// </item>
	/// <item>
	/// <term>Function uses a PROVIDOR_INFO_2 structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <exception cref="System.ArgumentException"></exception>
	/// <remarks>
	/// <para>
	/// Before an application calls the <c>AddPrintProvidor</c> function, all files required by the provider must be copied to the
	/// SYSTEM32 directory.
	/// </para>
	/// <para>A provider added by <c>AddPrintProvidor</c> may be removed by calling <c>DeletePrintProvidor</c>.</para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "f34549c3-0474-48ba-9307-5b36f02dbe1c")]
	public static bool AddPrintProvidor<T>([Optional] string? pName, in T pProviderInfo) where T : struct
	{
		if (!TryGetLevel<T>("PROVIDOR_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(AddPrintProvidor)} cannot process a structure of type {typeof(T).Name}.");
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(pProviderInfo);
		return AddPrintProvidor(pName, lvl, mem);
	}

	/// <summary>
	/// The <c>CorePrinterDriverInstalled</c> function reports whether a core printer driver with a specified GUID, date, and version is installed.
	/// </summary>
	/// <param name="pszServer">
	/// Pointer to a constant, null-terminated string that specifies the name of the print server. Use <c>NULL</c> for the local computer.
	/// </param>
	/// <param name="pszEnvironment">
	/// Pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This can
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="CoreDriverGUID">The GUID of the core printer driver.</param>
	/// <param name="ftDriverDate">The date of the core printer driver.</param>
	/// <param name="dwlDriverVersion">The version of the core printer driver.</param>
	/// <param name="pbDriverInstalled">A pointer to <c>TRUE</c> if the driver, or a newer version, is installed, <c>FALSE</c> otherwise.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/coreprinterdriverinstalled HRESULT CorePrinterDriverInstalled( _In_
	// LPCTSTR pszServer, _In_ LPCTSTR pszEnvironment, _In_ GUID CoreDriverGUID, _In_ FILETIME ftDriverDate, _In_ DWORDLONG
	// dwlDriverVersion, _Out_ BOOL *pbDriverInstalled );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "fb859aca-bb7b-495d-bd38-16ffa084c240")]
	public static extern HRESULT CorePrinterDriverInstalled([Optional] string? pszServer, [Optional] string? pszEnvironment, Guid CoreDriverGUID, FILETIME ftDriverDate, ulong dwlDriverVersion, [MarshalAs(UnmanagedType.Bool)] out bool pbDriverInstalled);

	/// <summary>The <c>DeleteMonitor</c> function removes a port monitor added by the <c>AddMonitor</c> function.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server from which the monitor is to be removed. If this
	/// parameter is <c>NULL</c>, the port monitor is removed locally.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment from which the monitor is to be removed (for example,
	/// Windows x86, Windows IA64, or Windows x64). If this parameter is <c>NULL</c>, the monitor is removed from the current
	/// environment of the calling application and client machine (not of the destination application and print server).
	/// </param>
	/// <param name="pMonitorName">A pointer to a null-terminated string that specifies the name of the monitor to be removed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The caller must have SeLoadDriverPrivilege.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deletemonitor BOOL DeleteMonitor( _In_ StrPtrAuto pName, _In_ StrPtrAuto
	// pEnvironment, _In_ StrPtrAuto pMonitorName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "32548d4f-830a-471d-8a72-c0f62f43ffa2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteMonitor([Optional] string? pName, [Optional] string? pEnvironment, string pMonitorName);

	/// <summary>The <c>DeletePort</c> function displays a dialog box that allows the user to delete a port name.</summary>
	/// <param name="pName">
	/// A pointer to a zero-terminated string that specifies the name of the server for which the port should be deleted. If this
	/// parameter is <c>NULL</c>, a local port is deleted.
	/// </param>
	/// <param name="hWnd">A handle to the parent window of the port-deletion dialog box.</param>
	/// <param name="pPortName">A pointer to a zero-terminated string that specifies the name of the port that should be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>An application can retrieve the names of valid ports by calling the <c>EnumPorts</c> function.</para>
	/// <para>The <c>DeletePort</c> function returns an error if a printer is currently connected to the specified port.</para>
	/// <para>
	/// The caller of the <c>DeletePort</c> function must have SERVER_ACCESS_ADMINISTER access to the server to which the port is connected.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteport BOOL DeletePort( _In_ StrPtrAuto pName, _In_ HWND hWnd, _In_
	// StrPtrAuto pPortName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "5f5788c2-c781-4106-abd2-98556d0a22de")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePort([Optional] string? pName, HWND hWnd, string pPortName);

	/// <summary>
	/// <para>
	/// The <c>DeletePrinterDriver</c> function removes the specified printer-driver name from the list of names of supported drivers on
	/// a server.
	/// </para>
	/// <para>
	/// To delete the files associated with the driver in addition to removing the specified printer-driver name from the list of names
	/// of supported drivers for a server, use the <c>DeletePrinterDriverEx</c> function.
	/// </para>
	/// <para>
	/// <c>DeletePrinterDriver</c> deletes a driver only if no version of the driver is in use for the specified environment.
	/// <c>DeletePrinterDriverEx</c> can delete specific versions of the driver.
	/// </para>
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server from which the driver is to be deleted. If this
	/// parameter is <c>NULL</c>, the printer-driver name will be removed locally.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment from which the driver is to be deleted (for example,
	/// Windows x86, Windows IA64, or Windows x64). If this parameter is <c>NULL</c>, the driver name is deleted from the current
	/// environment of the calling application and client machine (not of the destination application and print server).
	/// </param>
	/// <param name="pDriverName">A pointer to a null-terminated string specifying the name of the driver that should be deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have the SeLoadDriverPrivilege.</para>
	/// <para>
	/// The <c>DeletePrinterDriver</c> function does not delete the associated files, it merely removes the driver name from the list
	/// returned by the <c>EnumPrinterDrivers</c> function.
	/// </para>
	/// <para>Before calling <c>DeletePrinterDriver</c>, you must delete all printer objects that use the printer driver.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterdriver BOOL DeletePrinterDriver( _In_ StrPtrAuto pName, _In_
	// StrPtrAuto pEnvironment, _In_ StrPtrAuto pDriverName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b159bd8b-3416-44a5-91bf-c0447ed6b465")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrinterDriver([Optional] string? pName, [Optional] string? pEnvironment, string pDriverName);

	/// <summary>
	/// The <c>DeletePrinterDriverEx</c> function removes the specified printer-driver name from the list of names of supported drivers
	/// on a server and deletes the files associated with the driver. This function can also delete specific versions of the driver.
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server from which the driver is to be deleted. If this
	/// parameter is <c>NULL</c>, the function deletes the printer-driver from the local computer.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment from which the driver is to be deleted (for example,
	/// Windows NT x86, Windows IA64, or Windows x64). If this parameter is <c>NULL</c>, the driver name is deleted from the current
	/// environment of the calling application and client computer (not of the destination application and print server).
	/// </param>
	/// <param name="pDriverName">A pointer to a null-terminated string specifying the name of the driver to delete.</param>
	/// <param name="dwDeleteFlag">
	/// <para>The options for deleting files and versions of the driver. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DPD_DELETE_SPECIFIC_VERSION</term>
	/// <term>
	/// Deletes the version specified in dwVersionFlag. This does not ensure that the driver will be removed from the list of supported
	/// drivers for the server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DPD_DELETE_UNUSED_FILES</term>
	/// <term>Removes any unused driver files.</term>
	/// </item>
	/// <item>
	/// <term>DPD_DELETE_ALL_FILES</term>
	/// <term>
	/// Deletes the driver only if all its associated files can be removed. The delete operation fails if any of the driver's files are
	/// being used by some other installed driver.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If DPD_DELETE_SPECIFIC_VERSION is not specified, the function deletes all versions of the driver if none of them is in use. If
	/// neither DPD_DELETE_UNUSED_FILES nor DPD_DELETE_ALL_FILES is specified, the function does not delete driver files.
	/// </para>
	/// </param>
	/// <param name="dwVersionFlag">
	/// The version of the driver to be deleted. This parameter can be 0, 1, 2 or 3. This parameter is used only if dwDeleteFlag
	/// includes the DPD_DELETE_SPECIFIC_VERSION flag.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before the function deletes the driver files, it calls the driver's <c>DrvDriverEvent</c> function, allowing the driver to
	/// remove any private files that are not used. For more information about <c>DrvDriverEvent</c>, see the Microsoft Windows Driver
	/// Development Kit (DDK).
	/// </para>
	/// <para>If the driver files are currently loaded, the function moves them to a temp directory and marks them for deletion on restart.</para>
	/// <para>Before calling <c>DeletePrinterDriverEx</c>, you must delete all printer objects that use the printer driver.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterdriverex BOOL DeletePrinterDriverEx( _In_ StrPtrAuto pName,
	// _In_ StrPtrAuto pEnvironment, _In_ StrPtrAuto pDriverName, _In_ DWORD dwDeleteFlag, _In_ DWORD dwVersionFlag );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "1a3d7c7f-1d45-4877-a8f7-a77f40e3c319")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrinterDriverEx([Optional] string? pName, [Optional] string? pEnvironment, string pDriverName, DPD dwDeleteFlag, uint dwVersionFlag = 0);

	/// <summary>Deletes a printer driver package from the driver store.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server from which the driver package is
	/// being deleted. A <c>NULL</c> pointer value means the local computer.
	/// </param>
	/// <param name="pszInfPath">A pointer to a constant, null-terminated string that specifies the path to the driver's *.inf file.</param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This
	/// can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>S_OK, if the operation succeeds.</para>
	/// <para>E_ACCESSDENIED, if the package was shipped with Windows.</para>
	/// <para>HRESULT_CODE(ERROR_PRINT_DRIVER_PACKAGE_IN_USE), if the package is being used.</para>
	/// <para>Otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>The driver store is typically %windir%\inf or %windir%\System32\DriverStore\FileRepository.</para>
	/// <para>A driver package that shipped with Windows cannot be removed with this function.</para>
	/// <para>The user must have printer administration privileges.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprinterdriverpackage HRESULT DeletePrinterDriverPackage( _In_
	// LPCTSTR pszServer, _In_ LPCTSTR pszInfPath, _In_ LPCTSTR pszEnvironment );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "a43a94d1-097e-457c-bce9-d4c434ecfa93")]
	public static extern HRESULT DeletePrinterDriverPackage([Optional] string? pszServer, string pszInfPath, [Optional] string? pszEnvironment);

	/// <summary>The <c>DeletePrintProcessor</c> function removes a print processor added by the <c>AddPrintProcessor</c> function.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server from which the processor is to be removed. If this
	/// parameter is <c>NULL</c>, the printer processor is removed locally.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment from which the processor is to be removed (for example,
	/// Windows NT x86, Windows IA64, or Windows x64). If this parameter is <c>NULL</c>, the processor is removed from the current
	/// environment of the calling application and client machine (not of the destination application and print server). <c>NULL</c> is
	/// the recommended value, as it provides maximum portability.
	/// </param>
	/// <param name="pPrintProcessorName">A pointer to a null-terminated string that specifies the name of the processor to be removed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The caller must have the SeLoadDriverPrivilege.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprintprocessor BOOL DeletePrintProcessor( _In_ StrPtrAuto pName, _In_
	// StrPtrAuto pEnvironment, _In_ StrPtrAuto pPrintProcessorName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "65c77874-aa2c-4b4c-b218-fad361270a3e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrintProcessor([Optional] string? pName, [Optional] string? pEnvironment, string pPrintProcessorName);

	/// <summary>The <c>DeletePrintProvidor</c> function removes a print provider added by the <c>AddPrintProvidor</c> function.</summary>
	/// <param name="pName">Reserved; must be <c>NULL</c>.</param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment from which the provider is to be removed (for example,
	/// Windows NT x86, Windows IA64, or Windows x64). If this parameter is <c>NULL</c>, the provider is removed from the current
	/// environment of the calling application and client machine (not of the destination application and print server). <c>NULL</c> is
	/// the recommended value because it provides maximum portability.
	/// </param>
	/// <param name="pPrintProviderName">A pointer to a null-terminated string that specifies the name of the provider to be removed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/deleteprintprovidor BOOL DeletePrintProvidor( _In_ StrPtrAuto pName, _In_
	// StrPtrAuto pEnvironment, _In_ StrPtrAuto pPrintProviderName );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "b7104f9a-111c-4904-a355-063bb4cc81f1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeletePrintProvidor([Optional] string? pName, [Optional] string? pEnvironment, string pPrintProviderName);

	/// <summary>Retrieves GUID, version, and date of all core printer drivers and the path to their packages.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server. Use <c>NULL</c> for the local computer.
	/// </param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This
	/// can be <c>NULL</c>.
	/// </param>
	/// <returns>A sequence of <c>CORE_PRINTER_DRIVER</c> structures.</returns>
	/// <remarks>
	/// This is a blocking or synchronous function and might not return immediately. How quickly this function returns depends on
	/// run-time factors such as network status, print server configuration, and printer driver implementation factors that are
	/// difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </remarks>
	public static IEnumerable<CORE_PRINTER_DRIVER> EnumCorePrinterDrivers([Optional] string? pszServer, [Optional] string? pszEnvironment)
	{
		const string subKey32 = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\PackageInstallation\Windows NT x86\CorePrinterDrivers";
		const string subKey64 = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Print\PackageInstallation\Windows x64\CorePrinterDrivers";

		var is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
		using var baseKey = string.IsNullOrEmpty(pszServer) ? null : RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, pszServer!);
		using var reg = (baseKey ?? Registry.LocalMachine).OpenSubKey(is64bit ? subKey64 : subKey32, false);// RegistryKeyPermissionCheck.ReadSubTree, RegistryRights.EnumerateSubKeys);
		var keys = reg?.GetSubKeyNames();
		if (keys?.Length == 0) return new CORE_PRINTER_DRIVER[0];
		var drvs = new CORE_PRINTER_DRIVER[keys!.Length];
		GetCorePrinterDrivers(pszServer, pszEnvironment, keys, (uint)keys.Length, drvs).ThrowIfFailed();
		return drvs;
	}

	/// <summary>The <c>EnumMonitors</c> function retrieves information about the port monitors installed on the specified server.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the monitors reside. If this parameter is
	/// <c>NULL</c>, the local monitors are enumerated.
	/// </param>
	/// <param name="Level">
	/// <para>The version of the structure pointed to by pMonitors.</para>
	/// <para>This value can be 1 or 2.</para>
	/// </param>
	/// <param name="pMonitors">
	/// <para>
	/// A pointer to a buffer that receives an array of structures. The buffer must be large enough to store the strings referenced by
	/// the structure members.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumMonitors</c> with cbBuf set to zero. <c>EnumMonitors</c> fails,
	/// <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer
	/// required to hold the array of structures and their data.
	/// </para>
	/// <para>
	/// The buffer receives an array of <c>MONITOR_INFO_1</c> structures if Level is 1, or <c>MONITOR_INFO_2</c> structures if Level is 2.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pMonitors.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied if the function succeeds or the number of bytes required if
	/// cbBuf is too small.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of structures that were returned in the buffer pointed to by pMonitors.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enummonitors BOOL EnumMonitors( _In_ StrPtrAuto pName, _In_ DWORD Level,
	// _Out_ LPBYTE pMonitors, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "4d4fbed2-193f-426c-8463-eeb6b1eaf316")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumMonitors([Optional] string? pName, uint Level, IntPtr pMonitors, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumMonitors</c> function retrieves information about the port monitors installed on the specified server.</summary>
	/// <typeparam name="T">The type of form information to enumerate. This must be either <c>MONITOR_INFO_1</c> or <c>MONITOR_INFO_2</c>.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the monitors reside. If this parameter is
	/// <c>NULL</c>, the local monitors are enumerated.
	/// </param>
	/// <returns>A sequence of <c>MONITOR_INFO_1</c> structures or <c>MONITOR_INFO_2</c> structures.</returns>
	/// <exception cref="System.ArgumentException"></exception>
	[PInvokeData("winspool.h", MSDNShortId = "4d4fbed2-193f-426c-8463-eeb6b1eaf316")]
	public static IEnumerable<T> EnumMonitors<T>([Optional] string? pName) where T : struct =>
		WSEnum<T>("MONITOR_INFO_", (uint l, IntPtr p, uint cb, out uint pcb, out uint c) => EnumMonitors(pName, l, p, cb, out pcb, out c));

	/// <summary>The <c>EnumPorts</c> function enumerates the ports that are available for printing on a specified server.</summary>
	/// <param name="pName">
	/// <para>A pointer to a null-terminated string that specifies the name of the server whose printer ports you want to enumerate.</para>
	/// <para>If pName is <c>NULL</c>, the function enumerates the local machine's printer ports.</para>
	/// </param>
	/// <param name="Level">
	/// The type of information returned in the pPorts buffer. If Level is 1, pPorts receives an array of <c>PORT_INFO_1</c> structures.
	/// If Level is 2, pPorts receives an array of <c>PORT_INFO_2</c> structures.
	/// </param>
	/// <param name="pPorts">
	/// <para>
	/// A pointer to a buffer that receives an array of <c>PORT_INFO_1</c> or <c>PORT_INFO_2</c> structures. Each structure contains
	/// data that describes an available printer port. The buffer must be large enough to store the strings pointed to by the structure members.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumPorts</c> with cbBuf set to zero. <c>EnumPorts</c> fails, <c>GetLastError</c>
	/// returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer required to hold the
	/// array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pPorts.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied to the pPorts buffer. If the buffer is too small, the function
	/// fails and the variable receives the number of bytes required.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of <c>PORT_INFO_1</c> or <c>PORT_INFO_2</c> structures returned in the pPorts
	/// buffer. This is the number of printer ports that are available on the specified server.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>The <c>EnumPorts</c> function can succeed even if the server specified by pName does not have a printer defined.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumports BOOL EnumPorts( _In_ StrPtrAuto pName, _In_ DWORD Level, _Out_
	// LPBYTE pPorts, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "72ea0e35-bf26-4c12-9451-8f6941990d82")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumPorts([Optional] string? pName, uint Level, IntPtr pPorts, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumPorts</c> function enumerates the ports that are available for printing on a specified server.</summary>
	/// <typeparam name="T">The type of form information to enumerate. This must be either <c>PORT_INFO_1</c> or <c>PORT_INFO_2</c>.</typeparam>
	/// <param name="pName">
	/// <para>A pointer to a null-terminated string that specifies the name of the server whose printer ports you want to enumerate.</para>
	/// <para>If pName is <c>NULL</c>, the function enumerates the local machine's printer ports.</para>
	/// </param>
	/// <returns>A sequence of <c>PORT_INFO_1</c> structures or <c>PORT_INFO_2</c> structures.</returns>
	/// <remarks>The <c>EnumPorts</c> function can succeed even if the server specified by pName does not have a printer defined.</remarks>
	[PInvokeData("winspool.h", MSDNShortId = "72ea0e35-bf26-4c12-9451-8f6941990d82")]
	public static IEnumerable<T> EnumPorts<T>([Optional] string? pName) where T : struct =>
		WSEnum<T>("PORT_INFO_", (uint l, IntPtr p, uint cb, out uint pcb, out uint c) => EnumPorts(pName, l, p, cb, out pcb, out c));

	/// <summary>The <c>EnumPrinterDrivers</c> function enumerates the printer drivers installed on a specified printer server.</summary>
	/// <param name="pName">
	/// <para>A pointer to a null-terminated string that specifies the name of the server on which the printer drivers are enumerated.</para>
	/// <para>If pName is <c>NULL</c>, the function enumerates the local printer drivers.</para>
	/// </param>
	/// <param name="pEnvironment">
	/// <para>
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, Windows x64, or
	/// Windows NT R4000). If this parameter is <c>NULL</c>, the function uses the current environment of the caller/client (not of the destination/server).
	/// </para>
	/// <para>
	/// If the pEnvironment string specifies "all", <c>EnumPrinterDrivers</c> enumerates printer drivers for all platforms installed on
	/// the specified server.
	/// </para>
	/// </param>
	/// <param name="Level">
	/// <para>The type of information structure returned in the pDriverInfo buffer. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>DRIVER_INFO_1</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>DRIVER_INFO_5</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDriverInfo">
	/// <para>
	/// A pointer to a buffer that receives an array of DRIVER_INFO_* structures, as specified by Level. Each structure contains data
	/// that describes an available printer driver. The buffer must be large enough to receive the array of structures and any strings
	/// or other data to which the structure members point.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumPrinterDrivers</c> with cbBuf set to zero. <c>EnumPrinterDrivers</c> fails,
	/// <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer
	/// required to hold the array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pDriverInfo</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied to the pDriverInfo buffer if the function succeeds. If the
	/// buffer is too small, the function fails and the variable receives the number of bytes required.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of structures returned in the pDriverInfo buffer. This is the number of printer
	/// drivers installed on the specified print server.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprinterdrivers BOOL EnumPrinterDrivers( _In_ StrPtrAuto pName, _In_
	// StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pDriverInfo, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD
	// pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "fa3d8cf4-70bc-4362-833e-e4217ed5d43b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumPrinterDrivers([Optional] string? pName, [Optional] string? pEnvironment, uint Level, IntPtr pDriverInfo, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumPrinterDrivers</c> function enumerates the printer drivers installed on a specified printer server.</summary>
	/// <typeparam name="T">
	/// The type of form information to enumerate. This must be either <c>DRIVER_INFO_1</c>, <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>,
	/// <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, <c>DRIVER_INFO_6</c>, or <c>DRIVER_INFO_8</c>.
	/// </typeparam>
	/// <param name="pName">
	/// <para>A pointer to a null-terminated string that specifies the name of the server on which the printer drivers are enumerated.</para>
	/// <para>If pName is <c>NULL</c>, the function enumerates the local printer drivers.</para>
	/// </param>
	/// <param name="pEnvironment">
	/// <para>
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, Windows x64, or
	/// Windows NT R4000). If this parameter is <c>NULL</c>, the function uses the current environment of the caller/client (not of the destination/server).
	/// </para>
	/// <para>
	/// If the pEnvironment string specifies "all", <c>EnumPrinterDrivers</c> enumerates printer drivers for all platforms installed on
	/// the specified server.
	/// </para>
	/// </param>
	/// <returns>
	/// A sequence of <c>DRIVER_INFO_1</c>, <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>,
	/// <c>DRIVER_INFO_6</c>, or <c>DRIVER_INFO_8</c> structures.
	/// </returns>
	[PInvokeData("winspool.h", MSDNShortId = "fa3d8cf4-70bc-4362-833e-e4217ed5d43b")]
	public static IEnumerable<T> EnumPrinterDrivers<T>([Optional] string? pName, [Optional] string? pEnvironment) where T : struct =>
		WSEnum<T>("DRIVER_INFO_", (uint l, IntPtr p, uint cb, out uint pcb, out uint c) => EnumPrinterDrivers(pName, pEnvironment, l, p, cb, out pcb, out c));

	/// <summary>The <c>EnumPrintProcessorDatatypes</c> function enumerates the data types that a specified print processor supports.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the print processor resides. If this
	/// parameter is <c>NULL</c>, the data types for the local print processor are enumerated.
	/// </param>
	/// <param name="pPrintProcessorName">
	/// A pointer to a null-terminated string that specifies the name of the print processor whose data types are enumerated.
	/// </param>
	/// <param name="Level">The type of information returned in the pDatatypes buffer. This parameter must be 1.</param>
	/// <param name="pDatatypes">
	/// <para>
	/// A pointer to a buffer that receives an array of <c>DATATYPES_INFO_1</c> structures. Each structure describes an available data
	/// type. The buffer must be large enough to receive the array of structures and any strings or other data to which the structure
	/// members point.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumPrintProcessorDatatypes</c> with cbBuf set to zero.
	/// <c>EnumPrintProcessorDatatypes</c> fails, <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter
	/// returns the size, in bytes, of the buffer required to hold the array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pDatatypes.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied to the pDatatypes buffer if the function succeeds. If the
	/// buffer is too small, the function fails and the variable receives the number of bytes required.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of structures returned in the pDatatypes buffer. This is the number of
	/// supported data types.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>v</para>
	/// <para>Starting with Windows Vista, the data type information from remote print servers is retrieved from a local cache.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprintprocessordatatypes BOOL EnumPrintProcessorDatatypes( _In_
	// StrPtrAuto pName, _In_ StrPtrAuto pPrintProcessorName, _In_ DWORD Level, _Out_ LPBYTE pDatatypes, _In_ DWORD cbBuf, _Out_ LPDWORD
	// pcbNeeded, _Out_ LPDWORD pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "27b6e074-d303-446b-9e5f-6cfa55c30d26")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumPrintProcessorDatatypes([Optional] string? pName, string pPrintProcessorName, uint Level, IntPtr pDatatypes, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumPrintProcessorDatatypes</c> function enumerates the data types that a specified print processor supports.</summary>
	/// <typeparam name="T">The type of form information to enumerate. This must be <c>DATATYPES_INFO_1</c>.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the print processor resides. If this
	/// parameter is <c>NULL</c>, the data types for the local print processor are enumerated.
	/// </param>
	/// <param name="pPrintProcessorName">
	/// A pointer to a null-terminated string that specifies the name of the print processor whose data types are enumerated.
	/// </param>
	/// <returns>A sequence of <c>DATATYPES_INFO_1</c> structures.</returns>
	/// <remarks>Starting with Windows Vista, the data type information from remote print servers is retrieved from a local cache.</remarks>
	[PInvokeData("winspool.h", MSDNShortId = "27b6e074-d303-446b-9e5f-6cfa55c30d26")]
	public static IEnumerable<T> EnumPrintProcessorDatatypes<T>(string pPrintProcessorName, [Optional] string? pName) where T : struct =>
		WSEnum<T>("DATATYPES_INFO_", (uint l, IntPtr p, uint cb, out uint pcb, out uint c) => EnumPrintProcessorDatatypes(pName, pPrintProcessorName, l, p, cb, out pcb, out c));

	/// <summary>The <c>EnumPrintProcessors</c> function enumerates the print processors installed on the specified server.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the print processors reside. If this
	/// parameter is <c>NULL</c>, the local print processors are enumerated.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="Level">The type of information returned in the pPrintProcessorInfo buffer. This parameter must be 1.</param>
	/// <param name="pPrintProcessorInfo">
	/// <para>
	/// A pointer to a buffer that receives an array of <c>PRINTPROCESSOR_INFO_1</c> structures. Each structure describes an available
	/// print processor. The buffer must be large enough to receive the array of structures and any strings to which the structure
	/// members point.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>EnumPrintProcessors</c> with cbBuf set to zero. <c>EnumPrintProcessors</c> fails,
	/// <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer
	/// required to hold the array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the buffer pointed to by pPrintProcessorInfo.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a variable that receives the number of bytes copied to the pPrintProcessorInfo buffer if the function succeeds. If
	/// the buffer is too small, the function fails and the variable receives the number of bytes required.
	/// </param>
	/// <param name="pcReturned">
	/// A pointer to a variable that receives the number of structures returned in the pPrintProcessorInfo buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/enumprintprocessors BOOL EnumPrintProcessors( _In_ StrPtrAuto pName, _In_
	// StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pPrintProcessorInfo, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded, _Out_ LPDWORD
	// pcReturned );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "98c9185c-c89d-4b4e-8c1e-7e22b315f188")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnumPrintProcessors([Optional] string? pName, [Optional] string? pEnvironment, uint Level, IntPtr pPrintProcessorInfo, uint cbBuf, out uint pcbNeeded, out uint pcReturned);

	/// <summary>The <c>EnumPrintProcessors</c> function enumerates the print processors installed on the specified server.</summary>
	/// <typeparam name="T">The type of form information to enumerate. This must be <c>PRINTPROCESSOR_INFO_1</c>.</typeparam>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the print processors reside. If this
	/// parameter is <c>NULL</c>, the local print processors are enumerated.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <returns>A sequence of <c>PRINTPROCESSOR_INFO_1</c> structures.</returns>
	[PInvokeData("winspool.h", MSDNShortId = "98c9185c-c89d-4b4e-8c1e-7e22b315f188")]
	public static IEnumerable<T> EnumPrintProcessors<T>([Optional] string? pName, [Optional] string? pEnvironment) where T : struct
	{
		if (!TryGetLevel<T>("PRINTPROCESSOR_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(EnumPrintProcessors)} cannot process a structure of type {typeof(T).Name}.");
		if (!EnumPrintProcessors(pName, pEnvironment, lvl, default, 0, out var bytes, out var count))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (bytes == 0)
			return new T[0];
		using var mem = new SafeCoTaskMemHandle(bytes);
		if (!EnumPrintProcessors(pName, pEnvironment, lvl, mem, mem.Size, out bytes, out count))
			Win32Error.ThrowLastError();
		return mem.ToArray<T>((int)count);
	}

	/// <summary>Retrieves GUID, version, and date of the specified core printer drivers and the path to their packages.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server. Use <c>NULL</c> for the local computer.
	/// </param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="pszzCoreDriverDependencies">A list of strings with the GUIDs of the core printer drivers.</param>
	/// <param name="cCorePrinterDrivers">The number of strings in pszzCoreDriverDependencies.</param>
	/// <param name="pCorePrinterDrivers">A pointer to an array of one or more <c>CORE_PRINTER_DRIVER</c> structures.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// This is a blocking or synchronous function and might not return immediately. How quickly this function returns depends on
	/// run-time factors such as network status, print server configuration, and printer driver implementation factors that are
	/// difficult to predict when writing an application. Calling this function from a thread that manages interaction with the user
	/// interface could make the application appear to be unresponsive.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getcoreprinterdrivers HRESULT GetCorePrinterDrivers( _In_ LPCTSTR
	// pszServer, _In_ LPCTSTR pszEnvironment, _In_ LPCTSTR pszzCoreDriverDependencies, _In_ DWORD cCorePrinterDrivers, _Out_
	// PCORE_PRINTER_DRIVER pCorePrinterDrivers );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "98acad48-cd42-4d2b-be58-81c1366f6912")]
	public static extern HRESULT GetCorePrinterDrivers([Optional] string? pszServer, [Optional] string? pszEnvironment,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] string[] pszzCoreDriverDependencies,
		uint cCorePrinterDrivers, [Out] CORE_PRINTER_DRIVER[] pCorePrinterDrivers);

	/// <summary>
	/// The <c>GetPrinterDriver</c> function retrieves driver data for the specified printer. If the driver is not installed on the
	/// local computer, <c>GetPrinterDriver</c> installs it.
	/// </summary>
	/// <param name="hPrinter">
	/// A handle to the printer for which the driver data should be retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="Level">
	/// <para>The printer driver structure returned in the pDriverInfo buffer. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>DRIVER_INFO_1</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>DRIVER_INFO_5</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDriverInfo">
	/// <para>
	/// A pointer to a buffer that receives a structure containing information about the driver, as specified by Level. The buffer must
	/// be large enough to store the strings pointed to by the structure members.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>GetPrinterDriver</c> with cbBuf set to zero. <c>GetPrinterDriver</c> fails,
	/// <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and the pcbNeeded parameter returns the size, in bytes, of the buffer
	/// required to hold the array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the array at which pDriverInfo points.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that receives the number of bytes copied if the function succeeds or the number of bytes required if cbBuf
	/// is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>For a non-existent driver, the function returns ERROR_UNKNOWN_PRINTER_DRIVER.</para>
	/// </returns>
	/// <remarks>
	/// The <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, and <c>DRIVER_INFO_6</c> structures
	/// contain the file name or the full path and file name of the printer driver in the <c>pDriverPath</c> member. An application can
	/// use the path and file name to load a printer driver by calling the <c>LoadLibrary</c> function and supplying the path and file
	/// name as the single argument.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdriver BOOL GetPrinterDriver( _In_ HANDLE hPrinter, _In_
	// StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pDriverInfo, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "93f859b4-1005-4359-8029-9536d6eeb7e7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrinterDriver(HPRINTER hPrinter, [Optional] string? pEnvironment, uint Level, IntPtr pDriverInfo, uint cbBuf, out uint pcbNeeded);

	/// <summary>
	/// The <c>GetPrinterDriver</c> function retrieves driver data for the specified printer. If the driver is not installed on the
	/// local computer, <c>GetPrinterDriver</c> installs it.
	/// </summary>
	/// <typeparam name="T">
	/// The type of driver information to enumerate. This must be either <c>DRIVER_INFO_1</c>, <c>DRIVER_INFO_2</c>,
	/// <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, <c>DRIVER_INFO_6</c>, or <c>DRIVER_INFO_8</c>.
	/// </typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer for which the driver data should be retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <returns>A structure containing information about the driver, as specified by <typeparamref name="T"/>.</returns>
	/// <remarks>
	/// The <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, and <c>DRIVER_INFO_6</c> structures
	/// contain the file name or the full path and file name of the printer driver in the <c>pDriverPath</c> member. An application can
	/// use the path and file name to load a printer driver by calling the <c>LoadLibrary</c> function and supplying the path and file
	/// name as the single argument.
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "93f859b4-1005-4359-8029-9536d6eeb7e7")]
	public static T GetPrinterDriver<T>(HPRINTER hPrinter, [Optional] string? pEnvironment) where T : struct
	{
		if (!TryGetLevel<T>("DRIVER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(GetPrinterDriver)} cannot process a structure of type {typeof(T).Name}.");
		if (!GetPrinterDriver(hPrinter, pEnvironment, lvl, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!GetPrinterDriver(hPrinter, pEnvironment, lvl, mem, mem.Size, out sz))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>
	/// The <c>GetPrinterDriver2</c> function retrieves driver data for the specified printer. If the driver is not installed on the
	/// local computer, <c>GetPrinterDriver2</c> installs it and displays any user interface to the specified window.
	/// </summary>
	/// <param name="hWnd">
	/// A handle of the window that will be used as the parent window of any user interface, such as a dialog box, that the driver
	/// displays during installation. If the value of this parameter is <c>NULL</c>, the driver's user interface will still be displayed
	/// to the user during installation, but it will not have a parent window.
	/// </param>
	/// <param name="hPrinter">
	/// A handle to the printer for which the driver data should be retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="Level">
	/// <para>The printer driver structure returned in the pDriverInfo buffer. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>DRIVER_INFO_1</term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>DRIVER_INFO_2</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>DRIVER_INFO_3</term>
	/// </item>
	/// <item>
	/// <term>4</term>
	/// <term>DRIVER_INFO_4</term>
	/// </item>
	/// <item>
	/// <term>5</term>
	/// <term>DRIVER_INFO_5</term>
	/// </item>
	/// <item>
	/// <term>6</term>
	/// <term>DRIVER_INFO_6</term>
	/// </item>
	/// <item>
	/// <term>8</term>
	/// <term>DRIVER_INFO_8</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pDriverInfo">
	/// <para>
	/// A pointer to a buffer that receives a structure containing information about the driver, as specified by Level. The buffer must
	/// be large enough to store the strings pointed to by the structure members.
	/// </para>
	/// <para>
	/// To determine the required buffer size, call <c>GetPrinterDriver2</c> with cbBuf set to zero. <c>GetPrinterDriver2</c> fails,
	/// <c>GetLastError</c> returns <c>ERROR_INSUFFICIENT_BUFFER</c>, and the pcbNeeded parameter returns the size, in bytes, of the
	/// buffer required to hold the array of structures and their data.
	/// </para>
	/// </param>
	/// <param name="cbBuf">The size, in bytes, of the array at which pDriverInfo points.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that receives the number of bytes copied if the function succeeds or the number of bytes required if cbBuf
	/// is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get the return status, call <c>GetLastError</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, <c>DRIVER_INFO_6</c>, and
	/// <c>DRIVER_INFO_8</c> structures contain the file name or the full path and file name of the printer driver in the
	/// <c>pDriverPath</c> member. An application can use the path and file name to load a printer driver by calling the
	/// <c>LoadLibrary</c> function and supplying the path and file name as the single argument.
	/// </para>
	/// <para>The ANSI version of this function, <c>GetPrinterDriver2A</c> is not supported and returns <c>ERROR_NOT_SUPPORTED</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdriver2 BOOL GetPrinterDriver2( _In_opt_ HWND hWnd, _In_
	// HANDLE hPrinter, _In_opt_ StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pDriverInfo, _In_ DWORD cbBuf, _Out_ LPDWORD
	// pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "0d482d28-7668-4734-ba71-5b355c18ddec")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrinterDriver2([Optional] HWND hWnd, HPRINTER hPrinter, [Optional] string? pEnvironment, uint Level, [Optional] IntPtr pDriverInfo, [Optional] uint cbBuf, out uint pcbNeeded);

	/// <summary>
	/// The <c>GetPrinterDriver2</c> function retrieves driver data for the specified printer. If the driver is not installed on the
	/// local computer, <c>GetPrinterDriver2</c> installs it and displays any user interface to the specified window.
	/// </summary>
	/// <typeparam name="T">
	/// The type of driver information to enumerate. This must be either <c>DRIVER_INFO_1</c>, <c>DRIVER_INFO_2</c>,
	/// <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, <c>DRIVER_INFO_6</c>, or <c>DRIVER_INFO_8</c>.
	/// </typeparam>
	/// <param name="hPrinter">
	/// A handle to the printer for which the driver data should be retrieved. Use the <c>OpenPrinter</c> or <c>AddPrinter</c> function
	/// to retrieve a printer handle.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="hWnd">
	/// A handle of the window that will be used as the parent window of any user interface, such as a dialog box, that the driver
	/// displays during installation. If the value of this parameter is <c>NULL</c>, the driver's user interface will still be displayed
	/// to the user during installation, but it will not have a parent window.
	/// </param>
	/// <returns>A structure containing information about the driver, as specified by <typeparamref name="T"/>.</returns>
	/// <exception cref="System.ArgumentException"></exception>
	/// <remarks>
	/// <para>
	/// The <c>DRIVER_INFO_2</c>, <c>DRIVER_INFO_3</c>, <c>DRIVER_INFO_4</c>, <c>DRIVER_INFO_5</c>, <c>DRIVER_INFO_6</c>, and
	/// <c>DRIVER_INFO_8</c> structures contain the file name or the full path and file name of the printer driver in the
	/// <c>pDriverPath</c> member. An application can use the path and file name to load a printer driver by calling the
	/// <c>LoadLibrary</c> function and supplying the path and file name as the single argument.
	/// </para>
	/// <para>The ANSI version of this function, <c>GetPrinterDriver2A</c> is not supported and returns <c>ERROR_NOT_SUPPORTED</c>.</para>
	/// </remarks>
	[PInvokeData("winspool.h", MSDNShortId = "0d482d28-7668-4734-ba71-5b355c18ddec")]
	public static T GetPrinterDriver2<T>(HPRINTER hPrinter, [Optional] string? pEnvironment, [Optional] HWND hWnd) where T : struct
	{
		if (!TryGetLevel<T>("DRIVER_INFO_", out var lvl))
			throw new ArgumentException($"{nameof(GetPrinterDriver2)} cannot process a structure of type {typeof(T).Name}.");
		if (!GetPrinterDriver2(hWnd, hPrinter, pEnvironment, lvl, default, 0, out var sz))
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using var mem = new SafeCoTaskMemHandle(sz);
		if (!GetPrinterDriver2(hWnd, hPrinter, pEnvironment, lvl, mem, mem.Size, out sz))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>The <c>GetPrinterDriverDirectory</c> function retrieves the path of the printer-driver directory.</summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server on which the printer driver resides. If this
	/// parameter is <c>NULL</c>, the local driver-directory path is retrieved.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="Level">The structure level. This value must be 1.</param>
	/// <param name="pDriverDirectory">A pointer to a buffer that receives the path.</param>
	/// <param name="cbBuf">The size of the buffer to which pDriverDirectory points.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that specifies the number of bytes copied if the function succeeds, or the number of bytes required if
	/// cbBuf is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdriverdirectory BOOL GetPrinterDriverDirectory( _In_ StrPtrAuto
	// pName, _In_ StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pDriverDirectory, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "69c9cc87-d7e3-496a-b631-b3ae30cdb3fd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrinterDriverDirectory([Optional] string? pName, [Optional] string? pEnvironment, uint Level, StringBuilder? pDriverDirectory, int cbBuf, out int pcbNeeded);

	/// <summary>Retrieves the path to the specified printer driver package on a print server.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server. Use <c>NULL</c> for the local computer.
	/// </param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="pszLanguage">
	/// A pointer to a constant, null-terminated string that specifies the Multilingual User Interface language for the driver being
	/// installed. This can be <c>NULL</c>.
	/// </param>
	/// <param name="pszPackageID">A pointer to a constant, null-terminated string that specifies the ID of the driver package.</param>
	/// <param name="pszDriverPackageCab">
	/// A pointer to a null-terminated string that specifies the path to the cabinet file for the driver package. This can be
	/// <c>NULL</c>. See Remarks.
	/// </param>
	/// <param name="cchDriverPackageCab">The size, in characters, of the pszDriverPackageCab buffer. This can be <c>NULL</c>.</param>
	/// <param name="pcchRequiredSize">A pointer to the required size of the pszDriverPackageCab buffer.</param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain a value for cchDriverPackageCab, call the function with <c>NULL</c> as the value of pszDriverPackageCab. Use the value
	/// returned in pcchRequiredSize as the value of cchDriverPackageCab and call the function again.
	/// </para>
	/// <para>The pszPackageID is typically obtained from a call to <c>GetCorePrinterDrivers</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprinterdriverpackagepath HRESULT GetPrinterDriverPackagePath( _In_
	// LPCTSTR pszServer, _In_ LPCTSTR pszEnvironment, _In_ LPCTSTR pszLanguage, _In_ LPCTSTR pszPackageID, _Inout_ StrPtrAuto
	// pszDriverPackageCab, _In_ DWORD cchDriverPackageCab, _Out_ LPDWORD pcchRequiredSize );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "e88e984b-d2c0-43b4-8f70-b05ec202ab14")]
	public static extern HRESULT GetPrinterDriverPackagePath([Optional] string? pszServer, [Optional] string? pszEnvironment, [Optional] string? pszLanguage,
		string pszPackageID, StringBuilder? pszDriverPackageCab, int cchDriverPackageCab, out int pcchRequiredSize);

	/// <summary>
	/// The <c>GetPrintProcessorDirectory</c> function retrieves the path to the print processor directory on the specified server.
	/// </summary>
	/// <param name="pName">
	/// A pointer to a null-terminated string that specifies the name of the server. If this parameter is <c>NULL</c>, a local path is returned.
	/// </param>
	/// <param name="pEnvironment">
	/// A pointer to a null-terminated string that specifies the environment (for example, Windows x86, Windows IA64, or Windows x64).
	/// If this parameter is <c>NULL</c>, the current environment of the calling application and client machine (not of the destination
	/// application and print server) is used.
	/// </param>
	/// <param name="Level">The structure level. This value must be 1.</param>
	/// <param name="pPrintProcessorInfo">
	/// A pointer to a buffer that receives the path. Note that, for operating systems prior to Windows Server 2003 SP 1, the path is in
	/// the local format for the server, not the true remote format. For example, the path is given as
	/// "%Windir%\System32\Spool\Prtprocs\%Environment%" instead of "\\ServerName\Print$\Prtprocs\%Environment%", even when called for a
	/// remote server. For the operating systems Windows Server 2003 SP 1 and later, the true remote path is returned.
	/// </param>
	/// <param name="cbBuf">The size of the buffer pointed to by pPrintProcessorInfo.</param>
	/// <param name="pcbNeeded">
	/// A pointer to a value that specifies the number of bytes copied if the function succeeds, or the number of bytes required if
	/// cbBuf is too small.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/getprintprocessordirectory BOOL GetPrintProcessorDirectory( _In_ StrPtrAuto
	// pName, _In_ StrPtrAuto pEnvironment, _In_ DWORD Level, _Out_ LPBYTE pPrintProcessorInfo, _In_ DWORD cbBuf, _Out_ LPDWORD pcbNeeded );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "a2443cfd-e5ba-41c6-aaf4-45051a3d0e26")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPrintProcessorDirectory([Optional] string? pName, [Optional] string? pEnvironment, uint Level, StringBuilder? pPrintProcessorInfo, int cbBuf, out int pcbNeeded);

	/// <summary>Installs a printer driver from a driver package that is in the print server's driver store.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server. <c>NULL</c> means the local computer.
	/// </param>
	/// <param name="pszInfPath">
	/// A pointer to a constant, null-terminated string that specifies the driver store path to the print driver's .inf file.
	/// <c>NULL</c> means the driver is in an inf file that shipped with Windows.
	/// </param>
	/// <param name="pszDriverName">A pointer to a constant, null-terminated string that specifies the name of the driver.</param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the processor architecture (for example, Windows NT x86). This
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// This can only be 0 or IPDFP_COPY_ALL_FILES. A value of 0 means that the printer driver must be added and any files in the
	/// printer driver directory that are newer than corresponding files currently in use must be copied. A value of
	/// IPDFP_COPY_ALL_FILES means the printer driver and all the files in the printer driver directory must be added. The file time
	/// stamps are ignored when dwFlags has a value of IPDFP_COPY_ALL_FILES.
	/// </param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>The driver store is typically either %windir%\inf or %windir%\System32\DriverStore\FileRepository.</para>
	/// <para><c>InstallPrinterDriverFromPackage</c> also installs other files in the package, such as color profiles and print processors.</para>
	/// <para>
	/// Users must have printer administration rights to install either on a remote computer or on the local computer when the user is
	/// logged in with Terminal Services.
	/// </para>
	/// <para>Only signed packages can be installed on a remote computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/installprinterdriverfrompackage HRESULT InstallPrinterDriverFromPackage(
	// _In_ LPCTSTR pszServer, _In_ LPCTSTR pszInfPath, _In_ LPCTSTR pszDriverName, _In_ LPCTSTR pszEnvironment, _In_ DWORD dwFlags );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "5906d9c6-9fbf-4ec6-81ce-112a9ef6d7c0")]
	public static extern HRESULT InstallPrinterDriverFromPackage([Optional] string? pszServer, [Optional] string? pszInfPath, string pszDriverName, [Optional] string? pszEnvironment, uint dwFlags);

	/// <summary>Uploads a printer driver to the print server's driver store so that it can be installed by calling <c>InstallPrinterDriverFromPackage</c>.</summary>
	/// <param name="pszServer">
	/// A pointer to a constant, null-terminated string that specifies the name of the print server. Use <c>NULL</c> if the server is
	/// the local computer.
	/// </param>
	/// <param name="pszInfPath">
	/// A pointer to a constant ,null-terminated string that specifies the source path to the driver's .inf file.
	/// </param>
	/// <param name="pszEnvironment">
	/// A pointer to a constant, null-terminated string that specifies the server's processor architecture (for example, Windows NT
	/// x86). This can be <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This can be any of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UPDP_SILENT_UPLOAD</term>
	/// <term>The UI will not be shown during the upload.</term>
	/// </item>
	/// <item>
	/// <term>UPDP_UPLOAD_ALWAYS</term>
	/// <term>The files will be uploaded even if the package is already in the server's driver store.</term>
	/// </item>
	/// <item>
	/// <term>UPDP_CHECK_DRIVERSTORE</term>
	/// <term>
	/// The server's driver store will be checked before upload to see if the package is already there. This setting is ignored if
	/// UPDP_UPLOAD_ALWAYS is set.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwnd">A handle to the copying user interface.</param>
	/// <param name="pszDestInfPath">A pointer to the destination path, in the driver store, to which the driver's .inf file was copied.</param>
	/// <param name="pcchDestInfPath">
	/// On input, specifies the size, in characters, of the pszDestInfPath buffer. On output, receives the size, in characters, of the
	/// path string, including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>If the operation succeeds, the return value is S_OK, otherwise the <c>HRESULT</c> will contain an error code.</para>
	/// <para>For more information about COM error codes, see Error Handling.</para>
	/// </returns>
	/// <remarks>
	/// <para>The driver store is typically either %windir%\inf or %windir%\System32\DriverStore\FileRepository.</para>
	/// <para>Only one package at a time can be uploaded. If a package is dependent on others, they must be uploaded separately.</para>
	/// <para>Only signed driver packages can be uploaded.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/uploadprinterdriverpackage HRESULT UploadPrinterDriverPackage( _In_
	// LPCTSTR pszServer, _In_ LPCTSTR pszInfPath, _In_ LPCTSTR pszEnvironment, _In_ DWORD dwFlags, _In_ HWND hwnd, _Out_ StrPtrAuto
	// pszDestInfPath, _Inout_ PULONG pcchDestInfPath );
	[DllImport(Lib.Winspool, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("winspool.h", MSDNShortId = "dd3b3a3b-8ded-44ae-85dd-e630bc62e898")]
	public static extern HRESULT UploadPrinterDriverPackage([Optional] string? pszServer, string pszInfPath, [Optional] string? pszEnvironment, UPDP dwFlags, HWND hwnd, StringBuilder pszDestInfPath, ref uint pcchDestInfPath);
}