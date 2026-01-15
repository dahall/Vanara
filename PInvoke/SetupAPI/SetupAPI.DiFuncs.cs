using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Items from the SetupAPI.dll</summary>
public static partial class SetupAPI
{
	/// <summary>A comparison callback function to use in duplicate detection.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device to register. The
	/// device information set must not contain any remote elements.
	/// </param>
	/// <param name="NewDeviceData">The new device data.</param>
	/// <param name="ExistingDeviceData">The existing device data.</param>
	/// <param name="CompareContext">
	/// A pointer to a caller-supplied context buffer that is passed into the callback function. This parameter is ignored if
	/// CompareProc is not specified.
	/// </param>
	/// <returns>
	/// The compare function must return ERROR_DUPLICATE_FOUND if it finds that the two devices are duplicates. Otherwise, it should
	/// return NO_ERROR. If some other error is encountered, the callback function should return the appropriate ERROR_* code to
	/// indicate the failure.
	/// </returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	public delegate Win32Error PSP_DETSIG_CMPPROC([In] HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA NewDeviceData,
		in SP_DEVINFO_DATA ExistingDeviceData, [In, Optional] IntPtr CompareContext);

	/// <summary>
	/// The <c>SetupDiAskForOEMDisk</c> function displays a dialog that asks the user for the path of an OEM installation disk.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local computer. This set contains a device information element that represents the
	/// device that is being installed.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiAskForOEMDisk</c> associates the driver with the
	/// device that is being installed. If this parameter is <c>NULL</c>, <c>SetupDiAskForOEMDisk</c> associates the driver with the
	/// global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful and the <c>DriverPath</c> field of the SP_DEVINSTALLPARAMS structure is
	/// updated to reflect the new path. If the user cancels the dialog, the function returns <c>FALSE</c> and a call to GetLastError
	/// returns ERROR_CANCELLED.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiAskForOEMDisk</c> allows the user to browse local and network drives for OEM installation files. However,
	/// <c>SetupDiAskForOEMDisk</c> is primarily designed to obtain the path of an OEM driver on a local computer before selecting and
	/// installing the driver for a device on that computer.
	/// </para>
	/// <para>
	/// Although this function will not fail if the device information set if for a remote computer, the result is of limited use
	/// because the device information set cannot subsequently be used with DIF_Xxx installation requests or <c>SetupDi</c> Xxx
	/// functions that do not support operations on a remote computer.
	/// </para>
	/// <para>
	/// In particular, the device information set cannot be used as input with a DIF_SELECTDEVICE installation request to select a
	/// driver for a device, followed by a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiaskforoemdisk WINSETUPAPI BOOL
	// SetupDiAskForOEMDisk( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiAskForOEMDisk")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiAskForOEMDisk(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiAskForOEMDisk</c> function displays a dialog that asks the user for the path of an OEM installation disk.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local computer. This set contains a device information element that represents the
	/// device that is being installed.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiAskForOEMDisk</c> associates the driver with the
	/// device that is being installed. If this parameter is <c>NULL</c>, <c>SetupDiAskForOEMDisk</c> associates the driver with the
	/// global class driver list for DeviceInfoSet.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful and the <c>DriverPath</c> field of the SP_DEVINSTALLPARAMS structure is
	/// updated to reflect the new path. If the user cancels the dialog, the function returns <c>FALSE</c> and a call to GetLastError
	/// returns ERROR_CANCELLED.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiAskForOEMDisk</c> allows the user to browse local and network drives for OEM installation files. However,
	/// <c>SetupDiAskForOEMDisk</c> is primarily designed to obtain the path of an OEM driver on a local computer before selecting and
	/// installing the driver for a device on that computer.
	/// </para>
	/// <para>
	/// Although this function will not fail if the device information set if for a remote computer, the result is of limited use
	/// because the device information set cannot subsequently be used with DIF_Xxx installation requests or <c>SetupDi</c> Xxx
	/// functions that do not support operations on a remote computer.
	/// </para>
	/// <para>
	/// In particular, the device information set cannot be used as input with a DIF_SELECTDEVICE installation request to select a
	/// driver for a device, followed by a DIF_INSTALLDEVICE installation request to install a device on a remote computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiaskforoemdisk WINSETUPAPI BOOL
	// SetupDiAskForOEMDisk( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiAskForOEMDisk")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiAskForOEMDisk(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiBuildClassInfoList</c> function returns a list of setup class GUIDs that identify the classes that are installed
	/// on a local computer.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// Flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in the list.
	/// Can be a combination of the following values:
	/// </para>
	/// <para>DIBCI_NOINSTALLCLASS</para>
	/// <para>Exclude a class if it has the <c>NoInstallClass</c> value entry in its registry key.</para>
	/// <para>DIBCI_NODISPLAYCLASS</para>
	/// <para>Exclude a class if it has the <c>NoDisplayClass</c> value entry in its registry key.</para>
	/// </param>
	/// <param name="ClassGuidList">
	/// A pointer to a GUID-typed array that receives a list of setup class GUIDs. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="ClassGuidListSize">
	/// The number of GUIDs in the array that is pointed to by the ClassGuildList parameter. If ClassGuidList is <c>NULL</c>,
	/// ClassGuidSize must be zero.
	/// </param>
	/// <param name="RequiredSize">
	/// <para>
	/// A pointer to a DWORD-typed variable that receives the number of GUIDs that are returned (if the number is less than or equal to
	/// the size, in GUIDs, of the array that is pointed to by the ClassGuidList parameter).
	/// </para>
	/// <para>
	/// If this number is greater than the size of the ClassGuidList array, it indicates how large the ClassGuidList array must be in
	/// order to contain all the class GUIDs.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To retrieve the number of classes that are installed on a local computer, call <c>SetupDiBuildClassInfoList</c> with
	/// ClassGuidList set to <c>NULL</c> and ClassGuidSize set to zero. In response to such a call, the function returns the number of
	/// classes in <c>*</c> RequiredSize.
	/// </para>
	/// <para>
	/// <c>SetupDiBuildClassInfoList</c> does not return a class GUID for a class if the <c>NoUseClass</c> value entry exists in the
	/// registry key of the class.
	/// </para>
	/// <para>To retrieve the list of setup class GUIDs installed on a remote system use SetupDiBuildClassInfoListEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdibuildclassinfolist WINSETUPAPI BOOL
	// SetupDiBuildClassInfoList( DWORD Flags, LPGUID ClassGuidList, DWORD ClassGuidListSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiBuildClassInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiBuildClassInfoList(DIBCI Flags, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[]? ClassGuidList,
		uint ClassGuidListSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiBuildClassInfoListEx</c> function returns a list of setup class GUIDs that includes every class installed on the
	/// local system or a remote system.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// Flags used to control exclusion of classes from the list. If no flags are specified, all setup classes are included in the list.
	/// Can be a combination of the following values:
	/// </para>
	/// <para>DIBCI_NOINSTALLCLASS</para>
	/// <para>Exclude a class if it has the <c>NoInstallClass</c> value entry in its registry key.</para>
	/// <para>DIBCI_NODISPLAYCLASS</para>
	/// <para>Exclude a class if it has the <c>NoDisplayClass</c> value entry in its registry key.</para>
	/// </param>
	/// <param name="ClassGuidList">A pointer to a buffer that receives a list of setup class GUIDs.</param>
	/// <param name="ClassGuidListSize">Supplies the number of GUIDs in the ClassGuildList array.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable that receives the number of GUIDs returned. If this number is greater than the size of the
	/// ClassGuidList, the number indicates how large the ClassGuidList array must be in order to contain the list.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote computer from which to retrieve installed setup
	/// classes. This parameter is optional and can be <c>NULL</c>. If MachineName is <c>NULL</c>, this function builds a list of
	/// classes installed on the local computer.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdibuildclassinfolistexa WINSETUPAPI BOOL
	// SetupDiBuildClassInfoListExA( DWORD Flags, LPGUID ClassGuidList, DWORD ClassGuidListSize, PDWORD RequiredSize, PCSTR MachineName,
	// PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiBuildClassInfoListExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiBuildClassInfoListEx(DIBCI Flags, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[]? ClassGuidList,
		uint ClassGuidListSize, out uint RequiredSize, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, IntPtr Reserved = default);

	/// <summary>
	/// The <c>SetupDiBuildDriverInfoList</c> function builds a list of drivers that is associated with a specific device or with the
	/// global class driver list for a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set to contain the driver list, either globally for all device information elements or
	/// specifically for a single device information element. The device information set must not contain remote device information elements.
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>
	/// A pointer to an SP_DEVINFO_DATA structure for the device information element in DeviceInfoSet that represents the device for
	/// which to build a driver list. This parameter is optional and can be <c>NULL</c>. If this parameter is specified, the list is
	/// associated with the specified device. If this parameter is <c>NULL</c>, the list is associated with the global class driver list
	/// for DeviceInfoSet.
	/// </para>
	/// <para>
	/// If the class of this device is updated because of building a compatible driver list, DeviceInfoData. <c>ClassGuid</c> is updated
	/// upon return.
	/// </para>
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to build. Must be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPDIT_CLASSDRIVER</term>
	/// <term>Build a list of class drivers. If DeviceInfoData is NULL, this driver list type must be specified.</term>
	/// </item>
	/// <item>
	/// <term>SPDIT_COMPATDRIVER</term>
	/// <term>Build a list of compatible drivers. DeviceInfoData must not be NULL if this driver list type is specified.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The device information set should be for a local computer because <c>SetupDiBuildDriverInfoList</c> searches for drivers only on
	/// a local computer. If the device information set is for a remote computer, the function returns <c>TRUE</c> but does not actually
	/// update the existing driver list for the device information set or, if supplied, the driver list for the device information element.
	/// </para>
	/// <para>
	/// The caller can set <c>Flags</c> in the SP_DEVINSTALL_PARAMS that are associated with the device information set or with a
	/// specific device (DeviceInfoData) to control how the list is built. For example, the caller can set the
	/// <c>DI_FLAGSEX_ALLOWEXCLUDEDDRVS</c> flag to include drivers that are marked Exclude From Select.
	/// </para>
	/// <para>
	/// A driver is "Exclude From Select" if either it is marked <c>ExcludeFromSelect</c> in the INF file or it is a driver for a device
	/// whose whole setup class is marked <c>NoInstallClass</c> or <c>NoUseClass</c> in the class installer INF file. Drivers for PnP
	/// devices are typically "Exclude From Select"; PnP devices should not be manually installed. To build a list of driver files for a
	/// PnP device a caller of <c>SetupDiBuildDriverInfoList</c> must set this flag.
	/// </para>
	/// <para>
	/// The <c>DriverPath</c> in the SP_DEVINSTALL_PARAMS contains either a path of a directory that contain INF files or a path of a
	/// specific INF file. If <c>DI_ENUMSINGLEINF</c> is set, <c>DriverPath</c> contains a path of a single INF file. If
	/// <c>DriverPath</c> is <c>NULL</c>, this function builds the driver list from the default INF file location, %SystemRoot%\inf.
	/// </para>
	/// <para>
	/// After this function has built the specified driver list, the caller can enumerate the elements of the list by calling SetupDiEnumDriverInfo.
	/// </para>
	/// <para>
	/// If the driver list is associated with a device instance (that is, DeviceInfoData is specified), the resulting list is composed
	/// of drivers that have the same class as the device instance with which they are associated. If this is a global class driver list
	/// (that is, DriverType is <c>SPDIT_CLASSDRIVER</c> and DeviceInfoData is not specified), the class that is used when building the
	/// list is the class associated with the device information set. If the device information set has no associated class, drivers of
	/// all classes are used when building the list.
	/// </para>
	/// <para>Another thread can terminate the building of a driver list by a call to SetupDiCancelDriverInfoSearch.</para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer. This function only searches for local drivers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdibuilddriverinfolist WINSETUPAPI BOOL
	// SetupDiBuildDriverInfoList( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiBuildDriverInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiBuildDriverInfoList(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, SPDIT DriverType);

	/// <summary>
	/// The <c>SetupDiBuildDriverInfoList</c> function builds a list of drivers that is associated with a specific device or with the
	/// global class driver list for a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set to contain the driver list, either globally for all device information elements or
	/// specifically for a single device information element. The device information set must not contain remote device information elements.
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>
	/// A pointer to an SP_DEVINFO_DATA structure for the device information element in DeviceInfoSet that represents the device for
	/// which to build a driver list. This parameter is optional and can be <c>NULL</c>. If this parameter is specified, the list is
	/// associated with the specified device. If this parameter is <c>NULL</c>, the list is associated with the global class driver list
	/// for DeviceInfoSet.
	/// </para>
	/// <para>
	/// If the class of this device is updated because of building a compatible driver list, DeviceInfoData. <c>ClassGuid</c> is updated
	/// upon return.
	/// </para>
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to build. Must be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPDIT_CLASSDRIVER</term>
	/// <term>Build a list of class drivers. If DeviceInfoData is NULL, this driver list type must be specified.</term>
	/// </item>
	/// <item>
	/// <term>SPDIT_COMPATDRIVER</term>
	/// <term>Build a list of compatible drivers. DeviceInfoData must not be NULL if this driver list type is specified.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The device information set should be for a local computer because <c>SetupDiBuildDriverInfoList</c> searches for drivers only on
	/// a local computer. If the device information set is for a remote computer, the function returns <c>TRUE</c> but does not actually
	/// update the existing driver list for the device information set or, if supplied, the driver list for the device information element.
	/// </para>
	/// <para>
	/// The caller can set <c>Flags</c> in the SP_DEVINSTALL_PARAMS that are associated with the device information set or with a
	/// specific device (DeviceInfoData) to control how the list is built. For example, the caller can set the
	/// <c>DI_FLAGSEX_ALLOWEXCLUDEDDRVS</c> flag to include drivers that are marked Exclude From Select.
	/// </para>
	/// <para>
	/// A driver is "Exclude From Select" if either it is marked <c>ExcludeFromSelect</c> in the INF file or it is a driver for a device
	/// whose whole setup class is marked <c>NoInstallClass</c> or <c>NoUseClass</c> in the class installer INF file. Drivers for PnP
	/// devices are typically "Exclude From Select"; PnP devices should not be manually installed. To build a list of driver files for a
	/// PnP device a caller of <c>SetupDiBuildDriverInfoList</c> must set this flag.
	/// </para>
	/// <para>
	/// The <c>DriverPath</c> in the SP_DEVINSTALL_PARAMS contains either a path of a directory that contain INF files or a path of a
	/// specific INF file. If <c>DI_ENUMSINGLEINF</c> is set, <c>DriverPath</c> contains a path of a single INF file. If
	/// <c>DriverPath</c> is <c>NULL</c>, this function builds the driver list from the default INF file location, %SystemRoot%\inf.
	/// </para>
	/// <para>
	/// After this function has built the specified driver list, the caller can enumerate the elements of the list by calling SetupDiEnumDriverInfo.
	/// </para>
	/// <para>
	/// If the driver list is associated with a device instance (that is, DeviceInfoData is specified), the resulting list is composed
	/// of drivers that have the same class as the device instance with which they are associated. If this is a global class driver list
	/// (that is, DriverType is <c>SPDIT_CLASSDRIVER</c> and DeviceInfoData is not specified), the class that is used when building the
	/// list is the class associated with the device information set. If the device information set has no associated class, drivers of
	/// all classes are used when building the list.
	/// </para>
	/// <para>Another thread can terminate the building of a driver list by a call to SetupDiCancelDriverInfoSearch.</para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer. This function only searches for local drivers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdibuilddriverinfolist WINSETUPAPI BOOL
	// SetupDiBuildDriverInfoList( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiBuildDriverInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiBuildDriverInfoList(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, SPDIT DriverType = SPDIT.SPDIT_CLASSDRIVER);

	/// <summary>
	/// The <c>SetupDiCallClassInstaller</c> function calls the appropriate class installer, and any registered co-installers, with the
	/// specified installation request (DIF code).
	/// </summary>
	/// <param name="InstallFunction">
	/// <para>
	/// The device installation request (DIF request) to pass to the co-installers and class installer. DIF codes have the format
	/// <c>DIF_XXX</c> and are defined in Setupapi.h. See Device Installation Function Codes for more information.
	/// </para>
	/// <para>
	/// <c>Note</c> For certain DIF requests, the caller must be a member of the Administrators group. For such DIF requests, this
	/// requirement is listed on the reference page for the associated default handler.
	/// </para>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local computer. This set contains a device installation element which represents
	/// the device for which to perform the specified installation function.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in the DeviceInfoSet that represents the
	/// device for which to perform the specified installation function. This parameter is optional and can be set to <c>NULL</c>. If
	/// this parameter is specified, <c>SetupDiCallClassInstaller</c> performs the specified function on the DeviceInfoData element. If
	/// DeviceInfoData is <c>NULL</c>, <c>SetupDiCallClassInstaller</c> calls the installers for the setup class that is associated with DeviceInfoSet.
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </para>
	/// <para>
	/// When GetLastError returns <c>ERROR_IN_WOW64</c>, this means that the calling application is a 32-bit application attempting to
	/// execute in a 64-bit environment, which is not allowed.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiCallClassInstaller</c> calls the class installer and any co-installers that are registered for a device or a device
	/// setup class. This function loads the installers if they are not yet loaded. The function also calls the default handler for the
	/// DIF request, if there is a default handler and if the installers return a status indicating that the default handler should be called.
	/// </para>
	/// <para>
	/// Device installation applications call this function with a variety of device installation function codes (DIF codes). The
	/// function ensures that all the appropriate installers and default handlers are called, in the correct order, for a given DIF
	/// request. For more information, see Handling DIF Codes.
	/// </para>
	/// <para>
	/// After <c>SetupDiCallClassInstaller</c> returns <c>TRUE</c>, the device installation application must call
	/// SetupDiGetDeviceInstallParams to obtain an SP_DEVINSTALL_PARAMS structure. If the structure's <c>DI_NEEDREBOOT</c> or
	/// <c>DI_NEEDRESTART</c> flag is set, the caller must prompt the user to restart the system. For example, the caller can do this by
	/// calling SetupPromptReboot.
	/// </para>
	/// <para>
	/// However, be aware that a device installation application should request a system restart one time at most. Therefore, any device
	/// installation application that creates multiple calls to <c>SetupDiCallClassInstaller</c> and SetupDiGetDeviceInstallParams
	/// should save the <c>DI_NEEDREBOOT</c> and <c>DI_NEEDRESTART</c> flags after each call. However, it should prompt the user only
	/// after the last call returns.
	/// </para>
	/// <para>
	/// In response to a DIF code supplied by <c>SetupDiCallClassInstaller</c>, class installers and co-installers might perform
	/// operations that require the system to be restarted. In such situations, the installer or co-installer should do the following:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call SetupDiGetDeviceInstallParams to obtain the SP_DEVINSTALL_PARAMS structure.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DI_NEEDREBOOT</c> or <c>DI_NEEDRESTART</c> flag in the structure's Flags member.</term>
	/// </item>
	/// <item>
	/// <term>Call SetupDiSetDeviceInstallParams, supplying the updated SP_DEVINSTALL_PARAMS structure, to save the revised Flags member.</term>
	/// </item>
	/// </list>
	/// <para>
	/// After <c>SetupDiCallClassInstaller</c> returns, the device installation application that called it should call
	/// SetupDiGetDeviceInstallParams, check the flags, and request a restart if necessary.
	/// </para>
	/// <para>The device information set specified by DeviceInfoSet must only contain elements for devices on the local computer.</para>
	/// <para>For information about the design and operation of co-installers, see Writing a Co-installer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicallclassinstaller WINSETUPAPI BOOL
	// SetupDiCallClassInstaller( DI_FUNCTION InstallFunction, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCallClassInstaller")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCallClassInstaller(DI_FUNCTION InstallFunction, HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiCallClassInstaller</c> function calls the appropriate class installer, and any registered co-installers, with the
	/// specified installation request (DIF code).
	/// </summary>
	/// <param name="InstallFunction">
	/// <para>
	/// The device installation request (DIF request) to pass to the co-installers and class installer. DIF codes have the format
	/// <c>DIF_XXX</c> and are defined in Setupapi.h. See Device Installation Function Codes for more information.
	/// </para>
	/// <para>
	/// <c>Note</c> For certain DIF requests, the caller must be a member of the Administrators group. For such DIF requests, this
	/// requirement is listed on the reference page for the associated default handler.
	/// </para>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local computer. This set contains a device installation element which represents
	/// the device for which to perform the specified installation function.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in the DeviceInfoSet that represents the
	/// device for which to perform the specified installation function. This parameter is optional and can be set to <c>NULL</c>. If
	/// this parameter is specified, <c>SetupDiCallClassInstaller</c> performs the specified function on the DeviceInfoData element. If
	/// DeviceInfoData is <c>NULL</c>, <c>SetupDiCallClassInstaller</c> calls the installers for the setup class that is associated with DeviceInfoSet.
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </para>
	/// <para>
	/// When GetLastError returns <c>ERROR_IN_WOW64</c>, this means that the calling application is a 32-bit application attempting to
	/// execute in a 64-bit environment, which is not allowed.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiCallClassInstaller</c> calls the class installer and any co-installers that are registered for a device or a device
	/// setup class. This function loads the installers if they are not yet loaded. The function also calls the default handler for the
	/// DIF request, if there is a default handler and if the installers return a status indicating that the default handler should be called.
	/// </para>
	/// <para>
	/// Device installation applications call this function with a variety of device installation function codes (DIF codes). The
	/// function ensures that all the appropriate installers and default handlers are called, in the correct order, for a given DIF
	/// request. For more information, see Handling DIF Codes.
	/// </para>
	/// <para>
	/// After <c>SetupDiCallClassInstaller</c> returns <c>TRUE</c>, the device installation application must call
	/// SetupDiGetDeviceInstallParams to obtain an SP_DEVINSTALL_PARAMS structure. If the structure's <c>DI_NEEDREBOOT</c> or
	/// <c>DI_NEEDRESTART</c> flag is set, the caller must prompt the user to restart the system. For example, the caller can do this by
	/// calling SetupPromptReboot.
	/// </para>
	/// <para>
	/// However, be aware that a device installation application should request a system restart one time at most. Therefore, any device
	/// installation application that creates multiple calls to <c>SetupDiCallClassInstaller</c> and SetupDiGetDeviceInstallParams
	/// should save the <c>DI_NEEDREBOOT</c> and <c>DI_NEEDRESTART</c> flags after each call. However, it should prompt the user only
	/// after the last call returns.
	/// </para>
	/// <para>
	/// In response to a DIF code supplied by <c>SetupDiCallClassInstaller</c>, class installers and co-installers might perform
	/// operations that require the system to be restarted. In such situations, the installer or co-installer should do the following:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call SetupDiGetDeviceInstallParams to obtain the SP_DEVINSTALL_PARAMS structure.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DI_NEEDREBOOT</c> or <c>DI_NEEDRESTART</c> flag in the structure's Flags member.</term>
	/// </item>
	/// <item>
	/// <term>Call SetupDiSetDeviceInstallParams, supplying the updated SP_DEVINSTALL_PARAMS structure, to save the revised Flags member.</term>
	/// </item>
	/// </list>
	/// <para>
	/// After <c>SetupDiCallClassInstaller</c> returns, the device installation application that called it should call
	/// SetupDiGetDeviceInstallParams, check the flags, and request a restart if necessary.
	/// </para>
	/// <para>The device information set specified by DeviceInfoSet must only contain elements for devices on the local computer.</para>
	/// <para>For information about the design and operation of co-installers, see Writing a Co-installer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicallclassinstaller WINSETUPAPI BOOL
	// SetupDiCallClassInstaller( DI_FUNCTION InstallFunction, HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCallClassInstaller")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCallClassInstaller(DI_FUNCTION InstallFunction, HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiCancelDriverInfoSearch</c> function cancels a driver list search that is currently in progress in a different thread.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for which a driver list is being built.</param>
	/// <returns>
	/// If a driver list search is underway for the specified device information set when this function is called, the search is
	/// terminated. <c>SetupDiCancelDriverInfoSearch</c> returns <c>TRUE</c> when the termination is confirmed. Otherwise, it returns
	/// <c>FALSE</c> and a call to GetLastError returns ERROR_INVALID_HANDLE.
	/// </returns>
	/// <remarks>
	/// <c>SetupDiCancelDriverInfoSearch</c> is a synchronous call. Therefore, it does not return until the driver search thread
	/// responds to the termination request.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicanceldriverinfosearch WINSETUPAPI BOOL
	// SetupDiCancelDriverInfoSearch( HDEVINFO DeviceInfoSet );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCancelDriverInfoSearch")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCancelDriverInfoSearch(HDEVINFO DeviceInfoSet);

	/// <summary>The <c>SetupDiChangeState</c> function is the default handler for the DIF_PROPERTYCHANGE installation request.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set for the local computer. This set contains a device information element that represents the
	/// device whose state is to be changed.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT
	/// parameter because DeviceInfoData. <c>DevInst</c> might be updated with a new handle value upon return.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para><c>SetupDiChangeState</c> changes the state of an installed device.</para>
	/// <para>The caller of <c>SetupDiChangeState</c> must be a member of the Administrators group.</para>
	/// <para>
	/// <c>Note</c> Only a class installer should call <c>SetupDiChangeState</c> and only in those situations where the class installer
	/// must perform property change operations after <c>SetupDiChangeState</c> completes the default property change operation. In such
	/// situations, the class installer must directly call <c>SetupDiChangeState</c> when the installer processes a DIF_PROPERTYCHANGE
	/// request. For more information about calling the default handler, see Calling Default DIF Code Handlers.
	/// </para>
	/// <para>
	/// Callers of <c>SetupDiChangeState</c> must specify a DICS_XXX flag in the SP_PROPCHANGE_PARAMS for the device element that
	/// indicates the type of state change to perform on the device. Callers of this function must set the appropriate fields in the
	/// SP_PROPCHANGE_PARAMS and call SetupDiSetClassInstallParams before calling this function.
	/// </para>
	/// <para>
	/// If you specify the DICS_FLAG_CONFIGSPECIFIC flag in the SP_PROPCHANGE_PARAMS then you must fill in the <c>HwProfile</c> field. A
	/// value of zero for <c>HwProfile</c> indicates the current profile.
	/// </para>
	/// <para>
	/// To enable/disable a device in the current hardware profile, set the DICS_FLAG_CONFIGSPECIFIC flag in the SP_PROPCHANGE_PARAMS.
	/// To enable/disable a device globally, such as in both the docked and undocked hardware profiles, set the DICS_FLAG_GLOBAL flag.
	/// </para>
	/// <para>This function does the following:</para>
	/// <para>
	/// Callers of this function should not specify DICS_STOP or DICS_START in the SP_PROPCHANGE_PARAMS. Use DICS_PROPCHANGE to stop and
	/// restart a device to cause changes in the device's configuration to take effect.
	/// </para>
	/// <para>
	/// If DI_DONOTCALLCONFIGMG is set for a device, you should not call <c>SetupDiChangeState</c> for the device but should instead set
	/// the DI_NEEDREBOOT flag.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdichangestate WINSETUPAPI BOOL SetupDiChangeState(
	// HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiChangeState")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiChangeState(HDEVINFO DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiClassGuidsFromName</c> function retrieves the GUID(s) associated with the specified class name. This list is built
	/// based on the classes currently installed on the system.
	/// </summary>
	/// <param name="ClassName">The name of the class for which to retrieve the class GUID.</param>
	/// <param name="ClassGuidList">A pointer to an array to receive the list of GUIDs associated with the specified class name.</param>
	/// <param name="ClassGuidListSize">The number of GUIDs in the ClassGuidList array.</param>
	/// <param name="RequiredSize">
	/// Supplies a pointer to a variable that receives the number of GUIDs associated with the class name. If this number is greater
	/// than the size of the ClassGuidList buffer, the number indicates how large the array must be in order to store all the GUIDs.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>Call <c>SetupDiClassGuidsFromNameEx</c> to retrieve the class GUIDs for a class on a remote computer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiclassguidsfromnamea WINSETUPAPI BOOL
	// SetupDiClassGuidsFromNameA( PCSTR ClassName, LPGUID ClassGuidList, DWORD ClassGuidListSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiClassGuidsFromNameA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiClassGuidsFromName(string ClassName,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[]? ClassGuidList, uint ClassGuidListSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiClassGuidsFromNameEx</c> function retrieves the GUIDs associated with the specified class name. This resulting
	/// list contains the classes currently installed on a local or remote computer.
	/// </summary>
	/// <param name="ClassName">The name of the class for which to retrieve the class GUIDs.</param>
	/// <param name="ClassGuidList">A pointer to an array to receive the list of GUIDs associated with the specified class name.</param>
	/// <param name="ClassGuidListSize">The number of GUIDs in the ClassGuidList array.</param>
	/// <param name="RequiredSize">
	/// A pointer to a variable that receives the number of GUIDs associated with the class name. If this number is greater than the
	/// size of the ClassGuidList buffer, the number indicates how large the array must be in order to store all the GUIDs.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote system from which to retrieve the GUIDs. This parameter
	/// is optional and can be <c>NULL</c>. If MachineName is <c>NULL</c>, the local system name is used.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// Class names are not guaranteed to be unique; only GUIDs are unique. Therefore, one class name can return more than one GUID.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiclassguidsfromnameexa WINSETUPAPI BOOL
	// SetupDiClassGuidsFromNameExA( PCSTR ClassName, LPGUID ClassGuidList, DWORD ClassGuidListSize, PDWORD RequiredSize, PCSTR
	// MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiClassGuidsFromNameExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiClassGuidsFromNameEx(string ClassName,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] Guid[]? ClassGuidList, uint ClassGuidListSize, out uint RequiredSize,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, IntPtr Reserved = default);

	/// <summary>The <c>SetupDiClassNameFromGuid</c> function retrieves the class name associated with a class GUID.</summary>
	/// <param name="ClassGuid">A pointer to the class GUID for the class name to retrieve.</param>
	/// <param name="ClassName">
	/// A pointer to a buffer that receives the NULL-terminated string that contains the name of the class that is specified by the
	/// pointer in the ClassGuid parameter.
	/// </param>
	/// <param name="ClassNameSize">
	/// The size, in characters, of the buffer that is pointed to by the ClassName parameter. The maximum size, in characters, of a
	/// NULL-terminated class name is MAX_CLASS_NAME_LEN. For more information about the class name size, see the following
	/// <c>Remarks</c> section.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable that receives the number of characters that are required to store the requested NULL-terminated class
	/// name. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>Call <c>SetupDiClassNameFromGuidEx</c> to retrieve the name for a class on a remote computer.</para>
	/// <para>
	/// <c>SetupDiClassNameFromGuid</c> does not enforce a restriction on the length of the class name that it can return. This function
	/// returns the required size for a NULL-terminated class name even if it is greater than MAX_CLASS_NAME_LEN. However,
	/// MAX_CLASS_NAME_LEN is the maximum length of a valid NULL-terminated class name. A caller should never need a buffer that is
	/// larger than MAX_CLASS_NAME_LEN. For more information about class names, see the description of the <c>Class</c> entry of an INF
	/// Version section.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiclassnamefromguida WINSETUPAPI BOOL
	// SetupDiClassNameFromGuidA( const GUID *ClassGuid, PSTR ClassName, DWORD ClassNameSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiClassNameFromGuidA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiClassNameFromGuid(in Guid ClassGuid, StringBuilder ClassName, uint ClassNameSize, out uint RequiredSize);

	/// <summary>The <c>SetupDiClassNameFromGuid</c> function retrieves the class name associated with a class GUID.</summary>
	/// <param name="ClassGuid">A pointer to the class GUID for the class name to retrieve.</param>
	/// <param name="ClassName">
	/// Receives the string that contains the name of the class that is specified by the pointer in the ClassGuid parameter.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>Call <c>SetupDiClassNameFromGuidEx</c> to retrieve the name for a class on a remote computer.</remarks>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiClassNameFromGuidA")]
	public static bool SetupDiClassNameFromGuid(Guid ClassGuid, out string ClassName) =>
		FunctionHelper.CallMethodWithStrBuf((StringBuilder? sb, ref uint sz) => SetupDiClassNameFromGuid(ClassGuid, sb!, sz, out sz), out ClassName!);

	/// <summary>
	/// The <c>SetupDiClassNameFromGuidEx</c> function retrieves the class name associated with a class GUID. The class can be installed
	/// on a local or remote computer.
	/// </summary>
	/// <param name="ClassGuid">The class GUID of the class name to retrieve.</param>
	/// <param name="ClassName">
	/// A pointer to a string buffer that receives the NULL-terminated name of the class for the specified GUID.
	/// </param>
	/// <param name="ClassNameSize">The size, in characters, of the ClassName buffer.</param>
	/// <param name="RequiredSize">
	/// The number of characters required to store the class name (including a terminating null). RequiredSize is always less than MAX_CLASS_NAME_LEN.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a remote system on which the class is installed. This parameter
	/// is optional and can be <c>NULL</c>. If MachineName is <c>NULL</c>, the local system name is used.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdiclassnamefromguidexa WINSETUPAPI BOOL
	// SetupDiClassNameFromGuidExA( const GUID *ClassGuid, PSTR ClassName, DWORD ClassNameSize, PDWORD RequiredSize, PCSTR MachineName,
	// PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiClassNameFromGuidExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiClassNameFromGuidEx(in Guid ClassGuid, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder ClassName,
		uint ClassNameSize, out uint RequiredSize, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, IntPtr Reserved = default);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfo</c> function creates a new device information element and adds it as a new member to the
	/// specified device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for the local computer.</param>
	/// <param name="DeviceName">
	/// A pointer to a NULL-terminated string that supplies either a full device instance ID (for example, "Root*PNP0500\0000") or a
	/// root-enumerated device ID without the enumerator prefix and instance identifier suffix (for example, "*PNP0500"). The
	/// root-enumerated device identifier can be used only if the DICD_GENERATE_ID flag is specified in the CreationFlags parameter.
	/// </param>
	/// <param name="ClassGuid">
	/// A pointer to the device setup class GUID for the device. If the device setup class of the device is not known, set *ClassGuid to
	/// a GUID_NULL structure.
	/// </param>
	/// <param name="DeviceDescription">
	/// A pointer to a NULL-terminated string that supplies the text description of the device. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to installing the device. This handle is optional
	/// and can be <c>NULL</c>.
	/// </param>
	/// <param name="CreationFlags">
	/// <para>
	/// A variable of type DWORD that controls how the device information element is created. Can be a combination of the following values:
	/// </para>
	/// <para>DICD_GENERATE_ID</para>
	/// <para>
	/// If this flag is specified, DeviceName contains only a Root-enumerated device ID and the system uses that ID to generate a full
	/// device instance ID for the new device information element.
	/// </para>
	/// <para>
	/// Call <c>SetupDiGetDeviceInstanceId</c> to retrieve the device instance ID that was generated for this device information element.
	/// </para>
	/// <para>DICD_INHERIT_CLASSDRVS</para>
	/// <para>
	/// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with the
	/// device information set. In addition, if there is a selected driver for the device information set, that same driver is selected
	/// for the new device information element.
	/// </para>
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to a SP_DEVINFO_DATA structure that receives the new device information element. This pointer is optional and can be
	/// <c>NULL</c>. If the structure is supplied, the caller must set the <c>cbSize</c> member of this structure to <c>sizeof(</c>
	/// SP_DEVINFO_DATA <c>)</c> before calling the function. For more information, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// If this device instance is being added to a set that has an associated class, the device class must be the same or the call
	/// fails. In this case, a call to GetLastError returns ERROR_CLASS_MISMATCH.
	/// </para>
	/// <para>
	/// If the specified device instance is the same as an existing device instance key in the registry, the call fails. In this case, a
	/// call to GetLastError returns ERROR_DEVINST_ALREADY_EXISTS. This occurs only if the DICD_GENERATE_ID flag is not set.
	/// </para>
	/// <para>
	/// If the new device information element was successfully created but the caller-supplied DeviceInfoData buffer is invalid, the
	/// function returns <c>FALSE</c>. In this case, a call to GetLastError returns ERROR_INVALID_USER_BUFFER. However, the device
	/// information element will have been added as a new member of the set already.
	/// </para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfoa WINSETUPAPI BOOL
	// SetupDiCreateDeviceInfoA( HDEVINFO DeviceInfoSet, PCSTR DeviceName, const GUID *ClassGuid, PCSTR DeviceDescription, HWND
	// hwndParent, DWORD CreationFlags, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCreateDeviceInfo(HDEVINFO DeviceInfoSet, [In, MarshalAs(UnmanagedType.LPTStr)] string DeviceName,
		in Guid ClassGuid, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? DeviceDescription, [In, Optional] HWND hwndParent,
		DICD CreationFlags, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfo</c> function creates a new device information element and adds it as a new member to the
	/// specified device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set for the local computer.</param>
	/// <param name="DeviceName">
	/// A pointer to a NULL-terminated string that supplies either a full device instance ID (for example, "Root*PNP0500\0000") or a
	/// root-enumerated device ID without the enumerator prefix and instance identifier suffix (for example, "*PNP0500"). The
	/// root-enumerated device identifier can be used only if the DICD_GENERATE_ID flag is specified in the CreationFlags parameter.
	/// </param>
	/// <param name="ClassGuid">
	/// A pointer to the device setup class GUID for the device. If the device setup class of the device is not known, set *ClassGuid to
	/// a GUID_NULL structure.
	/// </param>
	/// <param name="DeviceDescription">
	/// A pointer to a NULL-terminated string that supplies the text description of the device. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to installing the device. This handle is optional
	/// and can be <c>NULL</c>.
	/// </param>
	/// <param name="CreationFlags">
	/// <para>
	/// A variable of type DWORD that controls how the device information element is created. Can be a combination of the following values:
	/// </para>
	/// <para>DICD_GENERATE_ID</para>
	/// <para>
	/// If this flag is specified, DeviceName contains only a Root-enumerated device ID and the system uses that ID to generate a full
	/// device instance ID for the new device information element.
	/// </para>
	/// <para>
	/// Call <c>SetupDiGetDeviceInstanceId</c> to retrieve the device instance ID that was generated for this device information element.
	/// </para>
	/// <para>DICD_INHERIT_CLASSDRVS</para>
	/// <para>
	/// If this flag is specified, the resulting device information element inherits the class driver list, if any, associated with the
	/// device information set. In addition, if there is a selected driver for the device information set, that same driver is selected
	/// for the new device information element.
	/// </para>
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to a SP_DEVINFO_DATA structure that receives the new device information element. This pointer is optional and can be
	/// <c>NULL</c>. If the structure is supplied, the caller must set the <c>cbSize</c> member of this structure to <c>sizeof(</c>
	/// SP_DEVINFO_DATA <c>)</c> before calling the function. For more information, see the following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by making a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// If this device instance is being added to a set that has an associated class, the device class must be the same or the call
	/// fails. In this case, a call to GetLastError returns ERROR_CLASS_MISMATCH.
	/// </para>
	/// <para>
	/// If the specified device instance is the same as an existing device instance key in the registry, the call fails. In this case, a
	/// call to GetLastError returns ERROR_DEVINST_ALREADY_EXISTS. This occurs only if the DICD_GENERATE_ID flag is not set.
	/// </para>
	/// <para>
	/// If the new device information element was successfully created but the caller-supplied DeviceInfoData buffer is invalid, the
	/// function returns <c>FALSE</c>. In this case, a call to GetLastError returns ERROR_INVALID_USER_BUFFER. However, the device
	/// information element will have been added as a new member of the set already.
	/// </para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfoa WINSETUPAPI BOOL
	// SetupDiCreateDeviceInfoA( HDEVINFO DeviceInfoSet, PCSTR DeviceName, const GUID *ClassGuid, PCSTR DeviceDescription, HWND
	// hwndParent, DWORD CreationFlags, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCreateDeviceInfo(HDEVINFO DeviceInfoSet, [In, MarshalAs(UnmanagedType.LPTStr)] string DeviceName,
		in Guid ClassGuid, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? DeviceDescription, [In, Optional] HWND hwndParent,
		DICD CreationFlags, IntPtr DeviceInfoData = default);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfoList</c> function creates an empty device information set and optionally associates the set with a
	/// device setup class and a top-level window.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the <c>GUID</c> of the device setup class to associate with the newly created device information set. If this
	/// parameter is specified, only devices of this class can be included in this device information set. If this parameter is set to
	/// <c>NULL</c>, the device information set is not associated with a specific device setup class.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to non-device-specific actions (such as a
	/// select-device dialog box that uses the global class driver list). This handle is optional and can be <c>NULL</c>. If a specific
	/// top-level window is not required, set hwndParent to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns a handle to an empty device information set if it is successful. Otherwise, it returns
	/// <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must delete the returned device information set when it is no longer needed by calling <c>SetupDiDestroyDeviceInfoList</c>.</para>
	/// <para>To create a device information list for a remote computer use SetupDiCreateDeviceInfoListEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfolist WINSETUPAPI HDEVINFO
	// SetupDiCreateDeviceInfoList( const GUID *ClassGuid, HWND hwndParent );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoList")]
	public static extern SafeHDEVINFO SetupDiCreateDeviceInfoList(in Guid ClassGuid, [In, Optional] HWND hwndParent);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfoList</c> function creates an empty device information set and optionally associates the set with a
	/// device setup class and a top-level window.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the <c>GUID</c> of the device setup class to associate with the newly created device information set. If this
	/// parameter is specified, only devices of this class can be included in this device information set. If this parameter is set to
	/// <c>NULL</c>, the device information set is not associated with a specific device setup class.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to non-device-specific actions (such as a
	/// select-device dialog box that uses the global class driver list). This handle is optional and can be <c>NULL</c>. If a specific
	/// top-level window is not required, set hwndParent to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns a handle to an empty device information set if it is successful. Otherwise, it returns
	/// <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must delete the returned device information set when it is no longer needed by calling <c>SetupDiDestroyDeviceInfoList</c>.</para>
	/// <para>To create a device information list for a remote computer use SetupDiCreateDeviceInfoListEx.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfolist WINSETUPAPI HDEVINFO
	// SetupDiCreateDeviceInfoList( const GUID *ClassGuid, HWND hwndParent );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoList")]
	public static extern SafeHDEVINFO SetupDiCreateDeviceInfoList([In, Optional] IntPtr ClassGuid, [In, Optional] HWND hwndParent);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfoList</c> function creates an empty device information set on a remote or a local computer and
	/// optionally associates the set with a device setup class .
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the device setup class to associate with the newly created device information set. If this parameter is
	/// specified, only devices of this class can be included in this device information set. If this parameter is set to <c>NULL</c>,
	/// the device information set is not associated with a specific device setup class.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to non-device-specific actions (such as a
	/// select-device dialog box that uses the global class driver list). This handle is optional and can be <c>NULL</c>. If a specific
	/// top-level window is not required, set hwndParent to <c>NULL</c>.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a computer on a network. If a name is specified, only devices on
	/// that computer can be created and opened in this device information set. If this parameter is set to <c>NULL</c>, the device
	/// information set is for devices on the local computer.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns a handle to an empty device information set if it is successful. Otherwise, it returns
	/// INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must delete the returned device information set when it is no longer needed by calling SetupDiDestroyDeviceInfoList.</para>
	/// <para>
	/// If the device information set is for devices on a remote computer (MachineName is not <c>NULL</c>), all subsequent operations on
	/// this set or any of its elements must use routines that support device information sets with remote elements. The <c>SetupDi</c>
	/// Xxx routines that do not provide this support, such as SetupDiCallClassInstaller, have a statement to that effect in their
	/// reference page.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfolistexa WINSETUPAPI HDEVINFO
	// SetupDiCreateDeviceInfoListExA( const GUID *ClassGuid, HWND hwndParent, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoListExA")]
	public static extern SafeHDEVINFO SetupDiCreateDeviceInfoListEx(in Guid ClassGuid, [In, Optional] HWND hwndParent,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInfoList</c> function creates an empty device information set on a remote or a local computer and
	/// optionally associates the set with a device setup class .
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the device setup class to associate with the newly created device information set. If this parameter is
	/// specified, only devices of this class can be included in this device information set. If this parameter is set to <c>NULL</c>,
	/// the device information set is not associated with a specific device setup class.
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to use for any user interface that is related to non-device-specific actions (such as a
	/// select-device dialog box that uses the global class driver list). This handle is optional and can be <c>NULL</c>. If a specific
	/// top-level window is not required, set hwndParent to <c>NULL</c>.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that contains the name of a computer on a network. If a name is specified, only devices on
	/// that computer can be created and opened in this device information set. If this parameter is set to <c>NULL</c>, the device
	/// information set is for devices on the local computer.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns a handle to an empty device information set if it is successful. Otherwise, it returns
	/// INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must delete the returned device information set when it is no longer needed by calling SetupDiDestroyDeviceInfoList.</para>
	/// <para>
	/// If the device information set is for devices on a remote computer (MachineName is not <c>NULL</c>), all subsequent operations on
	/// this set or any of its elements must use routines that support device information sets with remote elements. The <c>SetupDi</c>
	/// Xxx routines that do not provide this support, such as SetupDiCallClassInstaller, have a statement to that effect in their
	/// reference page.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinfolistexa WINSETUPAPI HDEVINFO
	// SetupDiCreateDeviceInfoListExA( const GUID *ClassGuid, HWND hwndParent, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInfoListExA")]
	public static extern SafeHDEVINFO SetupDiCreateDeviceInfoListEx([In, Optional] IntPtr ClassGuid, [In, Optional] HWND hwndParent,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiCreateDeviceInterface</c> function registers a device interface on a local system or a remote system.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set. This set contains a device information element that represents the device for which to
	/// register an interface. This handle is typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="InterfaceClassGuid">A pointer to a class GUID that specifies the interface class for the new interface.</param>
	/// <param name="ReferenceString">
	/// A pointer to a NULL-terminated string that supplies a reference string. This pointer is optional and can be <c>NULL</c>.
	/// Reference strings are used only by a few bus drivers that use device interfaces as placeholders for software devices that are
	/// created on demand.
	/// </param>
	/// <param name="CreationFlags">Reserved. Must be zero.</param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to a caller-initialized SP_DEVICE_INTERFACE_DATA structure to receive information about the new device interface. This
	/// pointer is optional and can be <c>NULL</c>. If the structure is supplied, the caller must set the <c>cbSize</c> member of this
	/// structure to <c>sizeof(</c> SP_DEVICE_INTERFACE_DATA <c>)</c> before calling this function. For more information, see the
	/// following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <c>SetupDiCreateDeviceInterface</c> returns <c>TRUE</c> if the function completed without error. If the function completed with
	/// an error, it returns <c>FALSE</c> and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiCreateDeviceInterface</c> registers an interface for a device. If a device has more than one interface, call this
	/// function once for each interface being registered.
	/// </para>
	/// <para>
	/// If this function successfully registers an interface for the device that corresponds to the specified device information
	/// element, it also adds the interface to the interface list that is associated with the device information element in the
	/// specified device information set.
	/// </para>
	/// <para>
	/// Before a registered interface can be used by applications and other system components the interface must be enabled by the
	/// driver for the device.
	/// </para>
	/// <para>
	/// This function creates a registry key for the new device interface. Callers of this function can access nonvolatile storage under
	/// this key using SetupDiOpenDeviceInterfaceRegKey.
	/// </para>
	/// <para>
	/// If <c>SetupDiCreateDeviceInterface</c> successfully creates a new device interface, but the caller-supplied buffer in the
	/// DeviceInterfaceData parameter is invalid, this function will return <c>FALSE</c> and a subsequent call to GetLastError will
	/// return ERROR_INVALID_USER_BUFFER. However, the function does create and register the new device interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinterfacea WINSETUPAPI BOOL
	// SetupDiCreateDeviceInterfaceA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const GUID *InterfaceClassGuid, PCSTR
	// ReferenceString, DWORD CreationFlags, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInterfaceA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCreateDeviceInterface(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in Guid InterfaceClassGuid,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? ReferenceString, [In, Optional] uint CreationFlags,
		ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>The <c>SetupDiCreateDeviceInterface</c> function registers a device interface on a local system or a remote system.</summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set. This set contains a device information element that represents the device for which to
	/// register an interface. This handle is typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="InterfaceClassGuid">A pointer to a class GUID that specifies the interface class for the new interface.</param>
	/// <param name="ReferenceString">
	/// A pointer to a NULL-terminated string that supplies a reference string. This pointer is optional and can be <c>NULL</c>.
	/// Reference strings are used only by a few bus drivers that use device interfaces as placeholders for software devices that are
	/// created on demand.
	/// </param>
	/// <param name="CreationFlags">Reserved. Must be zero.</param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to a caller-initialized SP_DEVICE_INTERFACE_DATA structure to receive information about the new device interface. This
	/// pointer is optional and can be <c>NULL</c>. If the structure is supplied, the caller must set the <c>cbSize</c> member of this
	/// structure to <c>sizeof(</c> SP_DEVICE_INTERFACE_DATA <c>)</c> before calling this function. For more information, see the
	/// following <c>Remarks</c> section.
	/// </param>
	/// <returns>
	/// <c>SetupDiCreateDeviceInterface</c> returns <c>TRUE</c> if the function completed without error. If the function completed with
	/// an error, it returns <c>FALSE</c> and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiCreateDeviceInterface</c> registers an interface for a device. If a device has more than one interface, call this
	/// function once for each interface being registered.
	/// </para>
	/// <para>
	/// If this function successfully registers an interface for the device that corresponds to the specified device information
	/// element, it also adds the interface to the interface list that is associated with the device information element in the
	/// specified device information set.
	/// </para>
	/// <para>
	/// Before a registered interface can be used by applications and other system components the interface must be enabled by the
	/// driver for the device.
	/// </para>
	/// <para>
	/// This function creates a registry key for the new device interface. Callers of this function can access nonvolatile storage under
	/// this key using SetupDiOpenDeviceInterfaceRegKey.
	/// </para>
	/// <para>
	/// If <c>SetupDiCreateDeviceInterface</c> successfully creates a new device interface, but the caller-supplied buffer in the
	/// DeviceInterfaceData parameter is invalid, this function will return <c>FALSE</c> and a subsequent call to GetLastError will
	/// return ERROR_INVALID_USER_BUFFER. However, the function does create and register the new device interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinterfacea WINSETUPAPI BOOL
	// SetupDiCreateDeviceInterfaceA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const GUID *InterfaceClassGuid, PCSTR
	// ReferenceString, DWORD CreationFlags, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInterfaceA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiCreateDeviceInterface(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in Guid InterfaceClassGuid,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? ReferenceString, uint CreationFlags = 0, IntPtr DeviceInterfaceData = default);

	/// <summary>
	/// The <c>SetupDiCreateDeviceInterfaceRegKey</c> function creates a registry key for storing information about a device interface
	/// and returns a handle to the key.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains the interface for which to create a registry key. The device information set
	/// must not contain remote elements.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface in DeviceInfoSet. This pointer is
	/// possibly returned by SetupDiCreateDeviceInterface.
	/// </param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <param name="samDesired">
	/// The registry security access that the caller requests for the key that is being created. For information about registry security
	/// access values of type REGSAM, see the Microsoft Windows SDK documentation.
	/// </param>
	/// <param name="InfHandle">
	/// The handle to an open INF file that contains a DDInstall section to be executed for the newly-created key. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is not <c>NULL</c>, InfSectionName must be specified as well.
	/// </param>
	/// <param name="InfSectionName">
	/// A pointer to the name of an INF DDInstall section in the INF file that is specified by InfHandle. This section is executed for
	/// the newly created key. This parameter is optional and can be <c>NULL</c>. If this parameter is specified, InfHandle must be
	/// specified as well.
	/// </param>
	/// <returns>
	/// If <c>SetupDiCreateDeviceInterfaceRegKey</c> succeeds, the function returns a handle to the requested registry key in which
	/// interface information can be stored and retrieved. If <c>SetupDiCreateDeviceInterfaceRegKey</c> fails, the function returns
	/// INVALID_HANDLE_VALUE. Call GetLastError to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// If the requested key for the device interface already exists, <c>SetupDiCreateDeviceInterfaceRegKey</c> returns a handle to that
	/// key; otherwise, <c>SetupDiCreateDeviceInterfaceRegKey</c> creates a new nonvolatile registry key for the specified device
	/// interface. Callers of this function can store private configuration data for the device interface in this key. The driver for
	/// the device can access this key using <c>Io</c> Xxx routines.
	/// </para>
	/// <para>Close the handle returned from this function by calling RegCloseKey.</para>
	/// <para>
	/// For installations that use layout files (specified by the <c>LayoutFile</c> entry in an INF Version section), the layout file
	/// must be opened by a call to <c>SetupOpenAppendInfFile</c> (described in Windows SDK documentation) before
	/// <c>SetupDiCreateDeviceInterfaceRegKey</c> is called.
	/// </para>
	/// <para>The device information set specified by DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedeviceinterfaceregkeya WINSETUPAPI HKEY
	// SetupDiCreateDeviceInterfaceRegKeyA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, DWORD Reserved,
	// REGSAM samDesired, HINF InfHandle, PCSTR InfSectionName );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDeviceInterfaceRegKeyA")]
	public static extern SafeRegistryHandle SetupDiCreateDeviceInterfaceRegKey(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		[Optional] uint Reserved, System.Security.AccessControl.RegistryRights samDesired, [In, Optional] HINF InfHandle,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? InfSectionName);

	/// <summary>
	/// The <c>SetupDiCreateDevRegKey</c> function creates a registry key for device-specific configuration information and returns a
	/// handle to the key.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to a device information set that contains a device information element that represents the device for which to create a
	/// registry key.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="Scope">
	/// <para>
	/// The scope of the registry key to be created. The scope determines where the information is stored. The key created can be global
	/// or hardware profile-specific. Can be one of the following values:
	/// </para>
	/// <para>DICS_FLAG_GLOBAL</para>
	/// <para>
	/// Create a key to store global configuration information. This information is not specific to a particular hardware profile. On
	/// NT-based operating systems this creates a key that is rooted at <c>HKEY_LOCAL_MACHINE</c>. The exact key opened depends on the
	/// value of the KeyType parameter.
	/// </para>
	/// <para>DICS_FLAG_CONFIGSPECIFIC</para>
	/// <para>
	/// Create a key to store hardware profile-specific configuration information. This key is rooted at one of the hardware-profile
	/// specific branches, instead of <c>HKEY_LOCAL_MACHINE</c>.
	/// </para>
	/// </param>
	/// <param name="HwProfile">
	/// The hardware profile for which to create a key if HwProfileFlags is set to SPDICS_FLAG_CONFIGSPECIFIC. If HwProfile is 0, the
	/// key for the current hardware profile is created. If HwProfileFlags is SPDICS_FLAG_GLOBAL, HwProfile is ignored.
	/// </param>
	/// <param name="KeyType">
	/// <para>The type of registry storage key to create. Can be one of the following values:</para>
	/// <para>DIREG_DEV</para>
	/// <para>Create a hardware key for the device.</para>
	/// <para>DIREG_DRV</para>
	/// <para>Create a software key for the device.</para>
	/// </param>
	/// <param name="InfHandle">
	/// The handle to an open INF file that contains an INF DDInstall section to be executed for the newly created key. This parameter
	/// is optional and can be <c>NULL</c>. If this parameter is specified, InfSectionName must be specified as well.
	/// </param>
	/// <param name="InfSectionName">
	/// The name of an INF DDInstall section in the INF file specified by InfHandle. This section is executed for the newly created key.
	/// This parameter is optional and can be <c>NULL</c>. If this parameter is specified, InfHandle must be specified as well.
	/// </param>
	/// <returns>
	/// If <c>SetupDiCreateDevRegKey</c> succeeds, the function returns a handle to the specified registry key in which device-specific
	/// configuration data can be stored and retrieved. If <c>SetupDiCreateDevRegKey</c> fails, the function returns
	/// INVALID_HANDLE_VALUE. Call GetLastError to get extended error information.
	/// </returns>
	/// <remarks>
	/// <para>The caller of <c>SetupDiCreateDevRegKey</c> must be a member of the Administrators group.</para>
	/// <para>Close the handle returned from <c>SetupDiCreateDevRegKey</c> by calling RegCloseKey.</para>
	/// <para>
	/// If the specified key already exists, <c>SetupDiCreateDevRegKey</c> returns a handle to that key. Otherwise,
	/// <c>SetupDiCreateDevRegKey</c> creates the specified key and returns a handle to the new key. For Windows Server 2003 and later
	/// versions of Windows, the key handle has KEY_READ and KEY_WRITE access only. For previous Windows versions, this handle has
	/// KEY_ALL_ACCESS access.
	/// </para>
	/// <para>
	/// The specified device instance must be registered before <c>SetupDiCreateDevRegKey</c> is called. Note, however, that the
	/// operating system automatically registers PnP device instances. For information about how to register non-PnP device instances,
	/// see SetupDiRegisterDeviceInfo.
	/// </para>
	/// <para>
	/// For installations that use layout files (specified by the <c>LayoutFile</c> entry in an INF Version section), the layout file
	/// must be opened by a call to <c>SetupOpenAppendInfFile</c> (described in the Microsoft Windows SDK documentation) before
	/// <c>SetupDiCreateDevRegKey</c> is called.
	/// </para>
	/// <para>
	/// If the supplied device information set contains device information elements for a remote system, and InfHandle and
	/// InfSectionName are also specified, the create request will fail, and a subsequent call to GetLastError will return ERROR_REMOTE_REQUEST_UNSUPPORTED.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdicreatedevregkeya WINSETUPAPI HKEY
	// SetupDiCreateDevRegKeyA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Scope, DWORD HwProfile, DWORD KeyType,
	// HINF InfHandle, PCSTR InfSectionName );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiCreateDevRegKeyA")]
	public static extern SafeRegistryHandle SetupDiCreateDevRegKey(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, DICS_FLAG Scope,
		uint HwProfile, DIREG KeyType, [In, Optional] HINF InfHandle, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? InfSectionName);

	/// <summary>
	/// The <c>SetupDiDeleteDeviceInfo</c> function deletes a device information element from a device information set. This function
	/// does not delete the actual device.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to the device information set that contains the device information element to delete.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that represents the device information element in DeviceInfoSet to delete.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// If the specified device information element is in use (for example, by a wizard page), the function fails. In this case, a call
	/// to GetLastError returns ERROR_DEVINFO_DATA_LOCKED. This happens if a handle to a wizard page is retrieved with a call to
	/// SetupDiGetWizardPage with this device information element specified and the DIWP_FLAG_USE_DEVINFO_DATA flag set. To delete this
	/// device information element, you must first close the wizard's HPROPSHEETPAGE handle.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdideletedeviceinfo WINSETUPAPI BOOL
	// SetupDiDeleteDeviceInfo( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDeleteDeviceInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDeleteDeviceInfo(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>The <c>SetupDiDeleteDeviceInterfaceData</c> function deletes a device interface from a device information set.</summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to the device information set that contains the interface to delete. This handle is typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet to delete. This structure is
	/// typically returned by SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <returns>
	/// <c>SetupDiDeleteDeviceInterfaceData</c> returns <c>TRUE</c> if the function completed without error. If the function completed
	/// with an error, it returns <c>FALSE</c> and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <c>SetupDiDeleteDeviceInterfaceData</c> deletes a device interface element from a device information set. This function has no
	/// effect on the device interface or the underlying device.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdideletedeviceinterfacedata WINSETUPAPI BOOL
	// SetupDiDeleteDeviceInterfaceData( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDeleteDeviceInterfaceData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDeleteDeviceInterfaceData(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>
	/// The <c>SetupDiDeleteDeviceInterfaceRegKey</c> function deletes the registry subkey that is used by applications and drivers to
	/// store interface-specific information.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains the interface for which to delete interface-specific information in the
	/// registry. The device information set must not contain remote elements.
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the device interface in DeviceInfoSet. This pointer is
	/// possibly returned by SetupDiCreateDeviceInterface or SetupDiEnumDeviceInterfaces.
	/// </param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <returns>
	/// <c>SetupDiDeleteDeviceInterfaceRegKey</c> returns <c>TRUE</c> if it is successful; otherwise, it returns <c>FALSE</c> and the
	/// logged error can be retrieved with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>
	/// <c>SetupDiDeleteDeviceInterfaceRegKey</c> deletes the subkey used by drivers and applications to store information about the
	/// device interface instance. This subkey was created by SetupDiCreateDeviceInterfaceRegKey or by the driver's call to an
	/// associated I/O manager routine. <c>SetupDiDeleteDeviceInterfaceRegKey</c> does not affect the main registry key for the device
	/// interface instance nor any other subkeys that may have been created.
	/// </para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdideletedeviceinterfaceregkey WINSETUPAPI BOOL
	// SetupDiDeleteDeviceInterfaceRegKey( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData, DWORD Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDeleteDeviceInterfaceRegKey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDeleteDeviceInterfaceRegKey(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, uint Reserved = 0);

	/// <summary>
	/// The <c>SetupDiDeleteDevRegKey</c> function deletes specified user-accessible registry keys that are associated with a device
	/// information element.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set that contains a device information element that represents the device for which to delete
	/// registry keys. The device information set must not contain remote elements.
	/// </param>
	/// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
	/// <param name="Scope">
	/// <para>
	/// The scope of the registry key to delete. The scope indicates where the information is located. The key can be global or hardware
	/// profile-specific. Can be one of the following values:
	/// </para>
	/// <para>DICS_FLAG_GLOBAL</para>
	/// <para>Delete the key that stores global configuration information.</para>
	/// <para>DICS_FLAG_CONFIGSPECIFIC</para>
	/// <para>Delete the key that stores hardware profile-specific configuration information.</para>
	/// </param>
	/// <param name="HwProfile">
	/// If Scope is set to DICS_FLAG_CONFIGSPECIFIC, the HwProfile parameter specifies the hardware profile for which to delete the
	/// registry key. If HwProfile is 0, the key for the current hardware profile is deleted. If HwProfile is 0xFFFFFFFF, the registry
	/// key for all hardware profiles is deleted.
	/// </param>
	/// <param name="KeyType">
	/// <para>The type of registry storage key to delete. Can be one of the following values:</para>
	/// <para>DIREG_DEV</para>
	/// <para>Delete the device's hardware key.</para>
	/// <para>DIREG_DRV</para>
	/// <para>Delete the device's software key.</para>
	/// <para>DIREG_BOTH</para>
	/// <para>Delete both the hardware and software keys for the device.</para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The caller of this function must be a member of the Administrators group.</para>
	/// <para>The DeviceInfoSet must only contain elements on the local computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdideletedevregkey WINSETUPAPI BOOL
	// SetupDiDeleteDevRegKey( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD Scope, DWORD HwProfile, DWORD KeyType );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDeleteDevRegKey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDeleteDevRegKey(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, DICS_FLAG Scope, uint HwProfile, DIREG KeyType);

	/// <summary>
	/// The <c>SetupDiDestroyClassImageList</c> function destroys a class image list that was built by a call to
	/// SetupDiGetClassImageList or SetupDiGetClassImageListEx.
	/// </summary>
	/// <param name="ClassImageListData">A pointer to an SP_CLASSIMAGELIST_DATA structure that contains the class image list to destroy.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroyclassimagelist WINSETUPAPI BOOL
	// SetupDiDestroyClassImageList( PSP_CLASSIMAGELIST_DATA ClassImageListData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDestroyClassImageList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDestroyClassImageList(in SP_CLASSIMAGELIST_DATA ClassImageListData);

	/// <summary>The <c>SetupDiDestroyDeviceInfoList</c> function deletes a device information set and frees all associated memory.</summary>
	/// <param name="DeviceInfoSet">A handle to the device information set to delete.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroydeviceinfolist WINSETUPAPI BOOL
	// SetupDiDestroyDeviceInfoList( HDEVINFO DeviceInfoSet );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDestroyDeviceInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDestroyDeviceInfoList(HDEVINFO DeviceInfoSet);

	/// <summary>The <c>SetupDiDestroyDriverInfoList</c> function deletes a driver list.</summary>
	/// <param name="DeviceInfoSet">A handle to a device information set that contains the driver list to delete.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiDestroyDriverInfoList</c> deletes the driver
	/// list for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiDestroyDriverInfoList</c> deletes the global class
	/// driver list that is associated with DeviceInfoSet.
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to delete, which must be one of the following values:</para>
	/// <para>SPDIT_CLASSDRIVER</para>
	/// <para>Delete a list of class drivers. If DeviceInfoData is <c>NULL</c>, this driver list type must be specified.</para>
	/// <para>SPDIT_COMPATDRIVER</para>
	/// <para>
	/// Delete a list of compatible drivers for the specified device. DeviceInfoData must be specified if this driver list type is specified.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>If the currently selected driver is a member of the list being deleted, the selection is reset.</para>
	/// <para>
	/// If a class driver list is being deleted, the DI_FLAGSEX_DIDINFOLIST and DI_DIDCLASS flags are reset for the corresponding device
	/// information set or device information element. The DI_MULTMFGS flags is also reset.
	/// </para>
	/// <para>
	/// If a compatible driver list is being destroyed, the DI_FLAGSEX_DIDCOMPATINFO and DI_DIDCOMPAT flags are reset for the
	/// corresponding device information element.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroydriverinfolist WINSETUPAPI BOOL
	// SetupDiDestroyDriverInfoList( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDestroyDriverInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDestroyDriverInfoList(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, SPDIT DriverType);

	/// <summary>The <c>SetupDiDestroyDriverInfoList</c> function deletes a driver list.</summary>
	/// <param name="DeviceInfoSet">A handle to a device information set that contains the driver list to delete.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is
	/// optional and can be set to <c>NULL</c>. If this parameter is specified, <c>SetupDiDestroyDriverInfoList</c> deletes the driver
	/// list for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiDestroyDriverInfoList</c> deletes the global class
	/// driver list that is associated with DeviceInfoSet.
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to delete, which must be one of the following values:</para>
	/// <para>SPDIT_CLASSDRIVER</para>
	/// <para>Delete a list of class drivers. If DeviceInfoData is <c>NULL</c>, this driver list type must be specified.</para>
	/// <para>SPDIT_COMPATDRIVER</para>
	/// <para>
	/// Delete a list of compatible drivers for the specified device. DeviceInfoData must be specified if this driver list type is specified.
	/// </para>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>If the currently selected driver is a member of the list being deleted, the selection is reset.</para>
	/// <para>
	/// If a class driver list is being deleted, the DI_FLAGSEX_DIDINFOLIST and DI_DIDCLASS flags are reset for the corresponding device
	/// information set or device information element. The DI_MULTMFGS flags is also reset.
	/// </para>
	/// <para>
	/// If a compatible driver list is being destroyed, the DI_FLAGSEX_DIDCOMPATINFO and DI_DIDCOMPAT flags are reset for the
	/// corresponding device information element.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroydriverinfolist WINSETUPAPI BOOL
	// SetupDiDestroyDriverInfoList( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDestroyDriverInfoList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiDestroyDriverInfoList(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, SPDIT DriverType = SPDIT.SPDIT_CLASSDRIVER);

	/// <summary>The <c>SetupDiDrawMiniIcon</c> function draws the specified mini-icon at the location requested.</summary>
	/// <param name="hdc">The handle to the device context in which the mini-icon will be drawn.</param>
	/// <param name="rc">The rectangle in the specified device context handle to draw the mini-icon in.</param>
	/// <param name="MiniIconIndex">
	/// <para>
	/// The index of the mini-icon, as retrieved from SetupDiLoadClassIcon or SetupDiGetClassBitmapIndex. The following predefined
	/// indexes for devices can be used:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Class</term>
	/// <term>Index</term>
	/// </listheader>
	/// <item>
	/// <term>Computer/System</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>Display/Monitor</term>
	/// <term>2</term>
	/// </item>
	/// <item>
	/// <term>Network Adapter</term>
	/// <term>3</term>
	/// </item>
	/// <item>
	/// <term>Mouse</term>
	/// <term>5</term>
	/// </item>
	/// <item>
	/// <term>Keyboard</term>
	/// <term>6</term>
	/// </item>
	/// <item>
	/// <term>Sound</term>
	/// <term>8</term>
	/// </item>
	/// <item>
	/// <term>FDC/HDC</term>
	/// <term>9</term>
	/// </item>
	/// <item>
	/// <term>Ports</term>
	/// <term>10</term>
	/// </item>
	/// <item>
	/// <term>Printer</term>
	/// <term>14</term>
	/// </item>
	/// <item>
	/// <term>Network Transport</term>
	/// <term>15</term>
	/// </item>
	/// <item>
	/// <term>Network Client</term>
	/// <term>16</term>
	/// </item>
	/// <item>
	/// <term>Network Service</term>
	/// <term>17</term>
	/// </item>
	/// <item>
	/// <term>Unknown</term>
	/// <term>18</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Flags">
	/// <para>These flags control the drawing operation. The LOWORD contains the actual flags defined as follows:</para>
	/// <para>DMI_MASK</para>
	/// <para>Draw the mini-icon's mask into HDC.</para>
	/// <para>DMI_BKCOLOR</para>
	/// <para>
	/// Use the system color index specified in the HIWORD of Flags as the background color. If this flag is not set, COLOR_WINDOW is used.
	/// </para>
	/// <para>DMI_USERECT</para>
	/// <para>If set, <c>SetupDiDrawMiniIcon</c> uses the supplied rectangle and stretches the icon to fit.</para>
	/// </param>
	/// <returns>
	/// This function returns the offset from the left side of rc where the string should start. If the draw operation fails, the
	/// function returns zero.
	/// </returns>
	/// <remarks>
	/// <para>By default, the icon is centered vertically and forced against the left side of the specified rectangle.</para>
	/// <para>
	/// <c>SetupDiDrawMiniIcon</c> draws the 16-bit version of the icon that is specified by the MiniIconIndex parameter. Instead of
	/// <c>SetupDiDrawMiniIcon</c>, you should use SetupDiLoadClassIcon together with <c>DrawIcon</c> or <c>DrawIconEx</c> to draw the
	/// 32-bit version of the icon. The following is an example of how to use <c>DrawIconEx</c> to display an icon:
	/// </para>
	/// <para>
	/// <code>HICON hIcon; if (SetupDiLoadClassIcon(&amp;GUID_DEVCLASS_USB, &amp;hIcon, NULL)) { DrawIconEx(hDC, 0, 0, hIcon, GetSystemMetrics(SM_CXSMICON),GetSystemMetrics(SM_CYSMICON), 0, NULL, DI_NORMAL); DestroyIcon(hIcon); }</code>
	/// </para>
	/// <para>
	/// For more information about DrawIcon or DrawIconEx, refer to the Microsoft Windows Software Development Kit (SDK) for Windows 7
	/// and .NET Framework 4.0 documentation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidrawminiicon WINSETUPAPI INT SetupDiDrawMiniIcon(
	// HDC hdc, RECT rc, INT MiniIconIndex, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiDrawMiniIcon")]
	public static extern int SetupDiDrawMiniIcon(HDC hdc, RECT rc, int MiniIconIndex, DMI Flags);

	/// <summary>
	/// The <c>SetupDiEnumDeviceInfo</c> function returns a SP_DEVINFO_DATA structure that specifies a device information element in a
	/// device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set for which to return an SP_DEVINFO_DATA structure that represents a device information element.
	/// </param>
	/// <param name="MemberIndex">A zero-based index of the device information element to retrieve.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure to receive information about an enumerated device information element. The caller must
	/// set DeviceInfoData. <c>cbSize</c> to
	/// <code>sizeof(SP_DEVINFO_DATA)</code>
	/// .
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Repeated calls to this function return a device information element for a different device. This function can be called
	/// repeatedly to get information about all devices in the device information set.
	/// </para>
	/// <para>
	/// To enumerate device information elements, an installer should initially call <c>SetupDiEnumDeviceInfo</c> with the MemberIndex
	/// parameter set to 0. The installer should then increment MemberIndex and call <c>SetupDiEnumDeviceInfo</c> until there are no
	/// more values (the function fails and a call to GetLastError returns <c>ERROR_NO_MORE_ITEMS</c>).
	/// </para>
	/// <para>
	/// Call SetupDiEnumDeviceInterfaces to get a context structure for a device interface element (versus a device information element).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinfo WINSETUPAPI BOOL
	// SetupDiEnumDeviceInfo( HDEVINFO DeviceInfoSet, DWORD MemberIndex, PSP_DEVINFO_DATA DeviceInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiEnumDeviceInfo(HDEVINFO DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);

	/// <summary>
	/// The <c>SetupDiEnumDeviceInfo</c> function returns a sequence of SP_DEVINFO_DATA structures that specifies a device informations
	/// element in a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set for which to return the SP_DEVINFO_DATA structures that represents device information elements.
	/// </param>
	/// <returns>A sequence of SP_DEVINFO_DATA structures with information about enumerated device information elements.</returns>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInfo")]
	public static IEnumerable<SP_DEVINFO_DATA> SetupDiEnumDeviceInfo(HDEVINFO DeviceInfoSet)
	{
		var data = StructHelper.InitWithSize<SP_DEVINFO_DATA>();
		for (uint i = 0; SetupDiEnumDeviceInfo(DeviceInfoSet, i, ref data); i++)
			yield return data;
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
	}

	/// <summary>
	/// The <c>SetupDiEnumDeviceInterfaces</c> function enumerates the device interfaces that are contained in a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains the device interfaces for which to return information. This handle is
	/// typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiEnumDeviceInterfaces</c> constrains the enumeration
	/// to the interfaces that are supported by the specified device. If this parameter is <c>NULL</c>, repeated calls to
	/// <c>SetupDiEnumDeviceInterfaces</c> return information about the interfaces that are associated with all the device information
	/// elements in DeviceInfoSet. This pointer is typically returned by SetupDiEnumDeviceInfo.
	/// </param>
	/// <param name="InterfaceClassGuid">A pointer to a GUID that specifies the device interface class for the requested interface.</param>
	/// <param name="MemberIndex">
	/// <para>
	/// A zero-based index into the list of interfaces in the device information set. The caller should call this function first with
	/// MemberIndex set to zero to obtain the first interface. Then, repeatedly increment MemberIndex and retrieve an interface until
	/// this function fails and GetLastError returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If DeviceInfoData specifies a particular device, the MemberIndex is relative to only the interfaces exposed by that device.</para>
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to a caller-allocated buffer that contains, on successful return, a completed SP_DEVICE_INTERFACE_DATA structure that
	/// identifies an interface that meets the search parameters. The caller must set DeviceInterfaceData. <c>cbSize</c> to
	/// <c>sizeof</c>(SP_DEVICE_INTERFACE_DATA) before calling this function.
	/// </param>
	/// <returns>
	/// <c>SetupDiEnumDeviceInterfaces</c> returns <c>TRUE</c> if the function completed without error. If the function completed with
	/// an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Repeated calls to this function return an SP_DEVICE_INTERFACE_DATA structure for a different device interface. This function can
	/// be called repeatedly to get information about interfaces in a device information set that are associated with a particular
	/// device information element or that are associated with all device information elements.
	/// </para>
	/// <para>
	/// DeviceInterfaceData points to a structure that identifies a requested device interface. To get detailed information about an
	/// interface, call SetupDiGetDeviceInterfaceDetail. The detailed information includes the name of the device interface that can be
	/// passed to a Win32 function such as CreateFile (described in Microsoft Windows SDK documentation) to get a handle to the interface.
	/// </para>
	/// <para>See System Defined Device Interface Classes for a list of available device interface classes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinterfaces WINSETUPAPI BOOL
	// SetupDiEnumDeviceInterfaces( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const GUID *InterfaceClassGuid, DWORD
	// MemberIndex, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInterfaces")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in Guid InterfaceClassGuid,
		uint MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>
	/// The <c>SetupDiEnumDeviceInterfaces</c> function enumerates the device interfaces that are contained in a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains the device interfaces for which to return information. This handle is
	/// typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiEnumDeviceInterfaces</c> constrains the enumeration
	/// to the interfaces that are supported by the specified device. If this parameter is <c>NULL</c>, repeated calls to
	/// <c>SetupDiEnumDeviceInterfaces</c> return information about the interfaces that are associated with all the device information
	/// elements in DeviceInfoSet. This pointer is typically returned by SetupDiEnumDeviceInfo.
	/// </param>
	/// <param name="InterfaceClassGuid">A pointer to a GUID that specifies the device interface class for the requested interface.</param>
	/// <param name="MemberIndex">
	/// <para>
	/// A zero-based index into the list of interfaces in the device information set. The caller should call this function first with
	/// MemberIndex set to zero to obtain the first interface. Then, repeatedly increment MemberIndex and retrieve an interface until
	/// this function fails and GetLastError returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>If DeviceInfoData specifies a particular device, the MemberIndex is relative to only the interfaces exposed by that device.</para>
	/// </param>
	/// <param name="DeviceInterfaceData">
	/// A pointer to a caller-allocated buffer that contains, on successful return, a completed SP_DEVICE_INTERFACE_DATA structure that
	/// identifies an interface that meets the search parameters. The caller must set DeviceInterfaceData. <c>cbSize</c> to
	/// <c>sizeof</c>(SP_DEVICE_INTERFACE_DATA) before calling this function.
	/// </param>
	/// <returns>
	/// <c>SetupDiEnumDeviceInterfaces</c> returns <c>TRUE</c> if the function completed without error. If the function completed with
	/// an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Repeated calls to this function return an SP_DEVICE_INTERFACE_DATA structure for a different device interface. This function can
	/// be called repeatedly to get information about interfaces in a device information set that are associated with a particular
	/// device information element or that are associated with all device information elements.
	/// </para>
	/// <para>
	/// DeviceInterfaceData points to a structure that identifies a requested device interface. To get detailed information about an
	/// interface, call SetupDiGetDeviceInterfaceDetail. The detailed information includes the name of the device interface that can be
	/// passed to a Win32 function such as CreateFile (described in Microsoft Windows SDK documentation) to get a handle to the interface.
	/// </para>
	/// <para>See System Defined Device Interface Classes for a list of available device interface classes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinterfaces WINSETUPAPI BOOL
	// SetupDiEnumDeviceInterfaces( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const GUID *InterfaceClassGuid, DWORD
	// MemberIndex, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInterfaces")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, in Guid InterfaceClassGuid,
		uint MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

	/// <summary>
	/// The <c>SetupDiEnumDeviceInterfaces</c> function enumerates the device interfaces that are contained in a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A pointer to a device information set that contains the device interfaces for which to return information. This handle is
	/// typically returned by SetupDiGetClassDevs.
	/// </param>
	/// <param name="InterfaceClassGuid">A GUID that specifies the device interface class for the requested interface.</param>
	/// <param name="DeviceInfoData">
	/// A nullable reference to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This
	/// parameter is optional and can be <see langword="null"/>. If this parameter is specified, <c>SetupDiEnumDeviceInterfaces</c>
	/// constrains the enumeration to the interfaces that are supported by the specified device, otherwise all interfaces are returned.
	/// </param>
	/// <returns>A sequence of completed SP_DEVICE_INTERFACE_DATA structures that identify the interfaces that meets the search parameters.</returns>
	/// <remarks>
	/// <para>
	/// Each value returned is a structure that identifies a requested device interface. To get detailed information about an interface,
	/// call <see cref="SetupDiGetDeviceInterfaceDetail(HDEVINFO, in SP_DEVICE_INTERFACE_DATA, IntPtr, uint, out uint, ref
	/// SP_DEVINFO_DATA)"/>. The detailed information includes the name of the device interface that can be passed to a Win32 function
	/// such as CreateFile (described in Microsoft Windows SDK documentation) to get a handle to the interface.
	/// </para>
	/// <para>See System Defined Device Interface Classes for a list of available device interface classes.</para>
	/// </remarks>
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInterfaces")]
	public static IEnumerable<SP_DEVICE_INTERFACE_DATA> SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, Guid InterfaceClassGuid,
		SP_DEVINFO_DATA? DeviceInfoData = null)
	{
		using SafeCoTaskMemStruct<SP_DEVINFO_DATA> dvidata = DeviceInfoData;
		var data = new SP_DEVICE_INTERFACE_DATA { cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA)) };
		for (uint i = 0; true; i++)
		{
			if (!SetupDiEnumDeviceInterfaces(DeviceInfoSet, dvidata, InterfaceClassGuid, i, ref data))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
				yield break;
			}
			yield return data;
		}
	}

	/// <summary>The <c>SetupDiEnumDriverInfo</c> function enumerates the members of a driver list.</summary>
	/// <param name="DeviceInfoSet">A handle to the device information set that contains the driver list to enumerate.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiEnumDriverInfo</c> enumerates a driver list for the
	/// specified device. If this parameter is <c>NULL</c>, <c>SetupDiEnumDriverInfo</c> enumerates the global class driver list that is
	/// associated with DeviceInfoSet (this list is of type SPDIT_CLASSDRIVER).
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to enumerate, which must be one of the following values:</para>
	/// <para>SPDIT_CLASSDRIVER</para>
	/// <para>Enumerate a class driver list. This driver list type must be specified if DeviceInfoData is not specified.</para>
	/// <para>SPDIT_COMPATDRIVER</para>
	/// <para>
	/// Enumerate a list of compatible drivers for the specified device. This driver list type can be specified only if DeviceInfoData
	/// is also specified.
	/// </para>
	/// </param>
	/// <param name="MemberIndex">The zero-based index of the driver information member to retrieve.</param>
	/// <param name="DriverInfoData">
	/// A pointer to a caller-initialized SP_DRVINFO_DATA structure that receives information about the enumerated driver. The caller
	/// must set DriverInfoData. <c>cbSize</c> to <c>sizeof(</c> SP_DRVINFO_DATA <c>)</c> before calling <c>SetupDiEnumDriverInfo</c>.
	/// If the <c>cbSize</c> member is not properly set, <c>SetupDiEnumDriverInfo</c> will return <c>FALSE</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate driver information set members, an installer should first call <c>SetupDiEnumDriverInfo</c> with the MemberIndex
	/// parameter set to 0. It should then increment MemberIndex and call <c>SetupDiEnumDriverInfo</c> until there are no more values.
	/// When there are no more values, the function fails and a call to GetLastError returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>
	/// If you do not properly initialize the <c>cbSize</c> member of the SP_DRVINFO_DATA structure that is supplied by the pointer
	/// DriverInfoData, the function will fail and log the error ERROR_INVALID_USER_BUFFER.
	/// </para>
	/// <para>
	/// To build a list of drivers associated with a specific device or with the global class driver list for a device information set
	/// first use SetupDiBuildDriverInfoList then pass that list to <c>SetupDiEnumDriverInfo</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdriverinfoa WINSETUPAPI BOOL
	// SetupDiEnumDriverInfoA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType, DWORD MemberIndex,
	// PSP_DRVINFO_DATA_A DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDriverInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiEnumDriverInfo(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, SPDIT DriverType,
		uint MemberIndex, ref SP_DRVINFO_DATA_V2 DriverInfoData);

	/// <summary>The <c>SetupDiEnumDriverInfo</c> function enumerates the members of a driver list.</summary>
	/// <param name="DeviceInfoSet">A handle to the device information set that contains the driver list to enumerate.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiEnumDriverInfo</c> enumerates a driver list for the
	/// specified device. If this parameter is <c>NULL</c>, <c>SetupDiEnumDriverInfo</c> enumerates the global class driver list that is
	/// associated with DeviceInfoSet (this list is of type SPDIT_CLASSDRIVER).
	/// </param>
	/// <param name="DriverType">
	/// <para>The type of driver list to enumerate, which must be one of the following values:</para>
	/// <para>SPDIT_CLASSDRIVER</para>
	/// <para>Enumerate a class driver list. This driver list type must be specified if DeviceInfoData is not specified.</para>
	/// <para>SPDIT_COMPATDRIVER</para>
	/// <para>
	/// Enumerate a list of compatible drivers for the specified device. This driver list type can be specified only if DeviceInfoData
	/// is also specified.
	/// </para>
	/// </param>
	/// <param name="MemberIndex">The zero-based index of the driver information member to retrieve.</param>
	/// <param name="DriverInfoData">
	/// A pointer to a caller-initialized SP_DRVINFO_DATA structure that receives information about the enumerated driver. The caller
	/// must set DriverInfoData. <c>cbSize</c> to <c>sizeof(</c> SP_DRVINFO_DATA <c>)</c> before calling <c>SetupDiEnumDriverInfo</c>.
	/// If the <c>cbSize</c> member is not properly set, <c>SetupDiEnumDriverInfo</c> will return <c>FALSE</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate driver information set members, an installer should first call <c>SetupDiEnumDriverInfo</c> with the MemberIndex
	/// parameter set to 0. It should then increment MemberIndex and call <c>SetupDiEnumDriverInfo</c> until there are no more values.
	/// When there are no more values, the function fails and a call to GetLastError returns ERROR_NO_MORE_ITEMS.
	/// </para>
	/// <para>
	/// If you do not properly initialize the <c>cbSize</c> member of the SP_DRVINFO_DATA structure that is supplied by the pointer
	/// DriverInfoData, the function will fail and log the error ERROR_INVALID_USER_BUFFER.
	/// </para>
	/// <para>
	/// To build a list of drivers associated with a specific device or with the global class driver list for a device information set
	/// first use SetupDiBuildDriverInfoList then pass that list to <c>SetupDiEnumDriverInfo</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdriverinfoa WINSETUPAPI BOOL
	// SetupDiEnumDriverInfoA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DWORD DriverType, DWORD MemberIndex,
	// PSP_DRVINFO_DATA_A DriverInfoData );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDriverInfoA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiEnumDriverInfo(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, SPDIT DriverType,
		uint MemberIndex, ref SP_DRVINFO_DATA_V2 DriverInfoData);

	/// <summary>
	/// The <c>SetupDiGetActualModelsSection</c> function retrieves the appropriate decorated INF Models section to use when installing
	/// a device from a device INF file.
	/// </summary>
	/// <param name="Context">
	/// A pointer to an INF file context that specifies a manufacturer-identifier entry in an INF Manufacturer section of an INF file.
	/// The manufacturer-identifier entry specifies an INF Models section name and optionally specifies TargetOSVersion decorations for
	/// the Models section name. For information about INF files and an INF file context, see the Platform SDK topics on using INF files
	/// and the INFCONTEXT structure.
	/// </param>
	/// <param name="AlternatePlatformInfo">
	/// A pointer to an SP_ALTPLATFORM_INFO structure that supplies information about a Windows version and processor architecture. The
	/// <c>cbSize</c> member of this structure must be set to <c>sizeof(</c> SP_ALTPLATFORM_INFO_V2 <c>)</c>. This parameter is optional
	/// and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="InfSectionWithExt">
	/// A pointer to a buffer that receives a string that contains the decorated INF Models section name and a NULL terminator. If
	/// AlternatePlatformInfo is not supplied, the decorated INF Models section name applies to the current platform; otherwise the name
	/// applies to the specified alternative platform. This parameter is optional and can be set to <c>NULL</c>. If this parameter is
	/// <c>NULL</c>, the function returns <c>TRUE</c> and sets RequiredSize to the size, in characters, that is required to return the
	/// decorated Models section name and a terminating NULL character.
	/// </param>
	/// <param name="InfSectionWithExtSize">
	/// The size, in characters, of the DecoratedModelsSection buffer. If DecoratedModelsSection is <c>NULL</c>, this parameter must be
	/// set to zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-type variable that receives the size, in characters, of the DecoratedModelsSection buffer that is required
	/// to retrieve the decorated Models section name and a terminating NULL character. This parameter is optional and can be set to <c>NULL</c>.
	/// </param>
	/// <param name="Reserved">Reserved for internal system use. This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <c>SetupDiGetActualModelsSection</c> returns <c>TRUE</c> if the operation succeeds. Otherwise, the function returns <c>FALSE</c>
	/// and the logged error can be retrieved with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiGetActualModelsSection</c> determines which TargetOSVersion fields in the manufacturer-identifier entry (supplied by
	/// Context) apply to the current platform, if AlternatePlatformInfo is not supplied, or to an alternative platform, if alternative
	/// platform information is supplied. <c>SetupDiGetActualModelsSection</c> selects the most appropriate platform based on all the
	/// TargetOSVersion fields, appends the TargetOSVersion string to the INF Models section name, and returns the decorated INF Models
	/// section name to the caller. In a manufacturer-identifier entry, the operating system major version is specified by the
	/// OSMajorVersion field and the operating system minor version is specified by the OSMinorVersion field.
	/// </para>
	/// <para>For information about retrieving an INF DDInstall section for a device, see SetupDiGetActualSectionToInstall.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetactualmodelssectiona WINSETUPAPI BOOL
	// SetupDiGetActualModelsSectionA( PINFCONTEXT Context, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PSTR InfSectionWithExt, DWORD
	// InfSectionWithExtSize, PDWORD RequiredSize, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetActualModelsSectionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetActualModelsSection(in INFCONTEXT Context, [In, Optional] IntPtr AlternatePlatformInfo,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? InfSectionWithExt, uint InfSectionWithExtSize,
		out uint RequiredSize, IntPtr Reserved = default);

	/// <summary>
	/// The <c>SetupDiGetActualSectionToInstall</c> function retrieves the appropriate INF DDInstall section to use when installing a
	/// device from a device INF file on a local computer.
	/// </summary>
	/// <param name="InfHandle">The handle to the INF file that contains the DDInstall section.</param>
	/// <param name="InfSectionName">
	/// A pointer to the DDInstall section name (as specified in an INF Models section). The maximum length of the section name, in
	/// characters, is 254.
	/// </param>
	/// <param name="InfSectionWithExt">
	/// A pointer to a character buffer to receive the DDInstall section name, its platform extension, and a NULL terminator. This is
	/// the decorated section name that should be used for installation. If this parameter is <c>NULL</c>, InfSectionWithExtSize must be
	/// zero. If this parameter is <c>NULL</c>, the function returns <c>TRUE</c> and sets RequiredSize to the size, in characters, that
	/// is required to return the DDInstall section name, its platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="InfSectionWithExtSize">
	/// The size, in characters, of the InfSectionWithExt buffer. If InfSectionWithExt is <c>NULL</c>, this parameter must be zero.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to the variable that receives the size, in characters, that is required to return the DDInstall section name, the
	/// platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="Extension">
	/// A pointer to a variable that receives a pointer to the '.' character that marks the start of the extension in the
	/// InfSectionWithExt buffer. If the InfSectionWithExt buffer is not supplied or is too small, this parameter is not set. Set this
	/// parameter to <c>NULL</c> if a pointer to the extension is not required.
	/// </param>
	/// <returns>
	/// If the function is successful, it returns <c>TRUE</c>. If the function fails, it returns <c>FALSE</c>. To get extended error
	/// information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function supports the extensions to DDInstall section names that are used to specify OS-specific and architecture-specific
	/// installation behaviors for a device. For information about these extensions, see Creating INF Files for Multiple Platforms and
	/// Operating Systems. <c>SetupDiGetActualSectionToInstall</c> searches for a DDInstall section name that matches the local computer
	/// in the manner described below.
	/// </para>
	/// <para>
	/// The function first searches in the specified INF file for a decorated install section name that matches the specified name and
	/// has an extension that matches the operating system and processor architecture of the local computer. If, for example, you
	/// specify a section name of <c>InstallSec</c>, the function searches for one of the following decorated names, depending on the
	/// processor architecture of the local computer:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>For a computer that is based on the x86 processor architecture, the function searches for the decorated name <c>InstallSec.ntx86</c>.</term>
	/// </item>
	/// <item>
	/// <term>For a computer that is based on the x64 processor architecture, the function searches for the decorated name <c>InstallSec.ntamd64</c>.</term>
	/// </item>
	/// <item>
	/// <term>For a computer that is based on the Itanium processor architecture, the function searches for the decorated name <c>InstallSec.ntia64</c>.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function finds a match for the name, operating system, and processor architecture, it terminates the search and returns
	/// the corresponding decorated name. If the function does not find such a match, the function searches for a section whose name is
	/// <c>InstallSec.NT</c>. If the function finds a match for <c>InstallSec.NT</c>, it terminates the search and returns this name. If
	/// the function does not find a match for either of the above searches, it returns <c>InstallSec</c>, but does not verify that the
	/// INF file contains an install section whose name is <c>InstallSec</c>.
	/// </para>
	/// <para>
	/// The DDInstall section name is used as the base for <c>Hardware</c> and <c>Services</c> section names. For example, if the
	/// DDInstall section name that is found is <c>InstallSec.NTX86</c>, the <c>Services</c> section name must be named <c>InstallSec.NTX86.Services</c>.
	/// </para>
	/// <para>
	/// The original DDInstall section name that is specified in the driver node is written to the driver's registry key's
	/// <c>InfSection</c> value entry. The extension that was found is stored in the key as the REG_SZ value <c>InfSectionExt</c>. For example:
	/// </para>
	/// <para>
	/// <code>InfSection : REG_SZ : "InstallSec" InfSectionExt : REG_SZ : ".NTX86"</code>
	/// </para>
	/// <para>
	/// If a driver is not selected for the specified device information element, a null driver is installed. Upon return, the flags in
	/// the device's SP_DEVINSTALL_PARAMS structure indicate whether the system should be restarted or rebooted to cause the device to start.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetactualsectiontoinstalla WINSETUPAPI BOOL
	// SetupDiGetActualSectionToInstallA( HINF InfHandle, PCSTR InfSectionName, PSTR InfSectionWithExt, DWORD InfSectionWithExtSize,
	// PDWORD RequiredSize, PSTR *Extension );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetActualSectionToInstallA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetActualSectionToInstall(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string InfSectionName,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? InfSectionWithExt, [Optional] uint InfSectionWithExtSize,
		out uint RequiredSize, out PTSTR Extension);

	/// <summary>
	/// The <c>SetupDiGetActualSectionToInstallEx</c> function retrieves the name of the INF DDInstall section that installs a device
	/// for a specified operating system and processor architecture.
	/// </summary>
	/// <param name="InfHandle">A handle to the INF file that contains the DDInstall section.</param>
	/// <param name="InfSectionName">
	/// A pointer to the DDInstall section name (as specified in an INF Models section). The maximum length of the section name, in
	/// characters, is 254.
	/// </param>
	/// <param name="AlternatePlatformInfo">
	/// <para>
	/// A pointer, if non- <c>NULL</c>, to an SP_ALTPLATFORM_INFO structure. This structure is used to specify an operating system and
	/// processor architecture that is different from that on the local computer. To return the DDInstall section name for the local
	/// computer, set this parameter to <c>NULL</c>. Otherwise, provide an SP_ALTPLATFORM structure and set its members as follows:
	/// </para>
	/// <para>cbSize</para>
	/// <para>Set to the size, in bytes, of an SP_ALTPLATFORM_INFO structure.</para>
	/// <para>Platform</para>
	/// <para>Set to VER_PLATFORM_WIN32_NT for Windows XP and later versions of Windows.</para>
	/// <para>MajorVersion</para>
	/// <para>Not used.</para>
	/// <para>MinorVersion</para>
	/// <para>Not Used.</para>
	/// <para>ProcessorArchitecture</para>
	/// <para>Set one of the following processor architecture constants.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Processor Architecture Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_INTEL</term>
	/// <term>The alternative platform is an x86-based processor architecture.</term>
	/// </item>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_IA64</term>
	/// <term>The alternative platform is an Itanium-based processor architecture.</term>
	/// </item>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_AMD64</term>
	/// <term>The alternative platform is an x64-based processor architecture.</term>
	/// </item>
	/// </list>
	/// <para>Reserved</para>
	/// <para>Set to zero.</para>
	/// </param>
	/// <param name="InfSectionWithExt">
	/// A pointer to a character buffer to receive the DDInstall section name, its platform extension, and a NULL terminator. This is
	/// the decorated section name that should be used for installation. If this parameter is <c>NULL</c>, the function returns
	/// <c>TRUE</c> and sets RequiredSize to the size, in characters, that is required to return the DDInstall section name, its
	/// platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="InfSectionWithExtSize">
	/// The size, in characters, of the buffer that is pointed to by the InfSectionWithExt parameter. The maximum length of a
	/// NULL-terminated INF section name, in characters, is MAX_INF_SECTION_NAME_LENGTH.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to the variable that receives the size, in characters, that is required to return the DDInstall section name, the
	/// platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="Extension">
	/// A pointer to a variable that receives a pointer to the '.' character that marks the start of the extension in the
	/// InfSectionWithExt buffer. If the InfSectionWithExt buffer is not supplied or is too small, this parameter is not set. Set this
	/// parameter to <c>NULL</c> if a pointer to the extension is not required.
	/// </param>
	/// <param name="Reserved">Reserved for internal use only. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// If the function is successful, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiGetActualSectionToInstallEx</c> is an extended form of SetupDiGetActualSectionToInstall. These functions support the
	/// extensions to DDInstall section names that are used to specify OS-specific and architecture-specific installation actions for a
	/// device. For information about these extensions, see Creating INF Files for Multiple Platforms and Operating Systems.
	/// </para>
	/// <para>
	/// If you do not supply alternative platform information with a call to <c>SetupDiGetActualSectionToInstallEx</c>, the function
	/// performs the same operation as <c>SetupDiGetActualSectionToInstall</c>. The latter function searches for the specified install
	/// section name using the platform information for the local computer.
	/// </para>
	/// <para>
	/// If you supply alternative platform information with a call to <c>SetupDiGetActualSectionToInstallEx</c>, the function does the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you specify a platform of VER_PLATFORM_WIN32_NT, the function first searches in the specified INF file for a decorated
	/// install section name that matches the name, operating system, and processor architecture that you specify. If, for example, you
	/// specify an install section name of <c>InstallSec</c>, the function searches for one of the following decorated names, depending
	/// on the specified processor architecture:
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetactualsectiontoinstallexa WINSETUPAPI BOOL
	// SetupDiGetActualSectionToInstallExA( HINF InfHandle, PCSTR InfSectionName, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PSTR
	// InfSectionWithExt, DWORD InfSectionWithExtSize, PDWORD RequiredSize, PSTR *Extension, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetActualSectionToInstallExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetActualSectionToInstallEx(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string InfSectionName,
		[In, Optional] IntPtr AlternatePlatformInfo, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? InfSectionWithExt,
		uint InfSectionWithExtSize, out uint RequiredSize, out PTSTR Extension, IntPtr Reserved = default);

	/// <summary>
	/// The <c>SetupDiGetActualSectionToInstallEx</c> function retrieves the name of the INF DDInstall section that installs a device
	/// for a specified operating system and processor architecture.
	/// </summary>
	/// <param name="InfHandle">A handle to the INF file that contains the DDInstall section.</param>
	/// <param name="InfSectionName">
	/// A pointer to the DDInstall section name (as specified in an INF Models section). The maximum length of the section name, in
	/// characters, is 254.
	/// </param>
	/// <param name="AlternatePlatformInfo">
	/// <para>
	/// A pointer, if non- <c>NULL</c>, to an SP_ALTPLATFORM_INFO structure. This structure is used to specify an operating system and
	/// processor architecture that is different from that on the local computer. To return the DDInstall section name for the local
	/// computer, set this parameter to <c>NULL</c>. Otherwise, provide an SP_ALTPLATFORM structure and set its members as follows:
	/// </para>
	/// <para>cbSize</para>
	/// <para>Set to the size, in bytes, of an SP_ALTPLATFORM_INFO structure.</para>
	/// <para>Platform</para>
	/// <para>Set to VER_PLATFORM_WIN32_NT for Windows XP and later versions of Windows.</para>
	/// <para>MajorVersion</para>
	/// <para>Not used.</para>
	/// <para>MinorVersion</para>
	/// <para>Not Used.</para>
	/// <para>ProcessorArchitecture</para>
	/// <para>Set one of the following processor architecture constants.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Processor Architecture Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_INTEL</term>
	/// <term>The alternative platform is an x86-based processor architecture.</term>
	/// </item>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_IA64</term>
	/// <term>The alternative platform is an Itanium-based processor architecture.</term>
	/// </item>
	/// <item>
	/// <term>PROCESSOR_ARCHITECTURE_AMD64</term>
	/// <term>The alternative platform is an x64-based processor architecture.</term>
	/// </item>
	/// </list>
	/// <para>Reserved</para>
	/// <para>Set to zero.</para>
	/// </param>
	/// <param name="InfSectionWithExt">
	/// A pointer to a character buffer to receive the DDInstall section name, its platform extension, and a NULL terminator. This is
	/// the decorated section name that should be used for installation. If this parameter is <c>NULL</c>, the function returns
	/// <c>TRUE</c> and sets RequiredSize to the size, in characters, that is required to return the DDInstall section name, its
	/// platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="InfSectionWithExtSize">
	/// The size, in characters, of the buffer that is pointed to by the InfSectionWithExt parameter. The maximum length of a
	/// NULL-terminated INF section name, in characters, is MAX_INF_SECTION_NAME_LENGTH.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to the variable that receives the size, in characters, that is required to return the DDInstall section name, the
	/// platform extension, and a terminating NULL character.
	/// </param>
	/// <param name="Extension">
	/// A pointer to a variable that receives a pointer to the '.' character that marks the start of the extension in the
	/// InfSectionWithExt buffer. If the InfSectionWithExt buffer is not supplied or is too small, this parameter is not set. Set this
	/// parameter to <c>NULL</c> if a pointer to the extension is not required.
	/// </param>
	/// <param name="Reserved">Reserved for internal use only. Must be set to <c>NULL</c>.</param>
	/// <returns>
	/// If the function is successful, it returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>SetupDiGetActualSectionToInstallEx</c> is an extended form of SetupDiGetActualSectionToInstall. These functions support the
	/// extensions to DDInstall section names that are used to specify OS-specific and architecture-specific installation actions for a
	/// device. For information about these extensions, see Creating INF Files for Multiple Platforms and Operating Systems.
	/// </para>
	/// <para>
	/// If you do not supply alternative platform information with a call to <c>SetupDiGetActualSectionToInstallEx</c>, the function
	/// performs the same operation as <c>SetupDiGetActualSectionToInstall</c>. The latter function searches for the specified install
	/// section name using the platform information for the local computer.
	/// </para>
	/// <para>
	/// If you supply alternative platform information with a call to <c>SetupDiGetActualSectionToInstallEx</c>, the function does the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If you specify a platform of VER_PLATFORM_WIN32_NT, the function first searches in the specified INF file for a decorated
	/// install section name that matches the name, operating system, and processor architecture that you specify. If, for example, you
	/// specify an install section name of <c>InstallSec</c>, the function searches for one of the following decorated names, depending
	/// on the specified processor architecture:
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetactualsectiontoinstallexa WINSETUPAPI BOOL
	// SetupDiGetActualSectionToInstallExA( HINF InfHandle, PCSTR InfSectionName, PSP_ALTPLATFORM_INFO AlternatePlatformInfo, PSTR
	// InfSectionWithExt, DWORD InfSectionWithExtSize, PDWORD RequiredSize, PSTR *Extension, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetActualSectionToInstallExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetActualSectionToInstallEx(HINF InfHandle, [MarshalAs(UnmanagedType.LPTStr)] string InfSectionName,
		in SP_ALTPLATFORM_INFO AlternatePlatformInfo, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? InfSectionWithExt,
		uint InfSectionWithExtSize, out uint RequiredSize, out PTSTR Extension, IntPtr Reserved = default);

	/// <summary>The <c>SetupDiGetClassBitmapIndex</c> function retrieves the index of the mini-icon supplied for the specified class.</summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the device setup class for which to retrieve the mini-icon. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="MiniIconIndex">
	/// A pointer to a variable of type INT that receives the index of the mini-icon for the specified device setup class. If the
	/// ClassGuid parameter is <c>NULL</c> or if there is no mini-icon for the specified class, <c>SetupDiGetClassBitmapIndex</c>
	/// returns the index of the mini-icon for the Unknown device setup class.
	/// </param>
	/// <returns>
	/// If there is a min-icon for the specified device setup class, <c>SetupDiGetClassBitmapIndex</c> returns <c>TRUE</c>. Otherwise,
	/// this function returns <c>FALSE</c> and the logged error can be retrieved with a call to GetLastError. If the ClassGuid parameter
	/// is <c>NULL</c>, or if there is no mini-icon for the specified class, the function returns <c>FALSE</c> and GetLastError returns ERROR_NO_DEVICE_ICON.
	/// </returns>
	/// <remarks>For a list of the device setup class mini-icons and their corresponding indexes, see SetupDiDrawMiniIcon.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassbitmapindex WINSETUPAPI BOOL
	// SetupDiGetClassBitmapIndex( const GUID *ClassGuid, PINT MiniIconIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassBitmapIndex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassBitmapIndex(in Guid ClassGuid, out int MiniIconIndex);

	/// <summary>The <c>SetupDiGetClassBitmapIndex</c> function retrieves the index of the mini-icon supplied for the specified class.</summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the device setup class for which to retrieve the mini-icon. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="MiniIconIndex">
	/// A pointer to a variable of type INT that receives the index of the mini-icon for the specified device setup class. If the
	/// ClassGuid parameter is <c>NULL</c> or if there is no mini-icon for the specified class, <c>SetupDiGetClassBitmapIndex</c>
	/// returns the index of the mini-icon for the Unknown device setup class.
	/// </param>
	/// <returns>
	/// If there is a min-icon for the specified device setup class, <c>SetupDiGetClassBitmapIndex</c> returns <c>TRUE</c>. Otherwise,
	/// this function returns <c>FALSE</c> and the logged error can be retrieved with a call to GetLastError. If the ClassGuid parameter
	/// is <c>NULL</c>, or if there is no mini-icon for the specified class, the function returns <c>FALSE</c> and GetLastError returns ERROR_NO_DEVICE_ICON.
	/// </returns>
	/// <remarks>For a list of the device setup class mini-icons and their corresponding indexes, see SetupDiDrawMiniIcon.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassbitmapindex WINSETUPAPI BOOL
	// SetupDiGetClassBitmapIndex( const GUID *ClassGuid, PINT MiniIconIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassBitmapIndex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassBitmapIndex([In, Optional] IntPtr ClassGuid, out int MiniIconIndex);

	/// <summary>
	/// The <c>SetupDiGetClassDescription</c> function retrieves the class description associated with the specified setup class GUID.
	/// </summary>
	/// <param name="ClassGuid">The GUID of the setup class whose description is to be retrieved.</param>
	/// <param name="ClassDescription">A pointer to a character buffer that receives the class description.</param>
	/// <param name="ClassDescriptionSize">The size, in characters, of the ClassDescription buffer.</param>
	/// <param name="RequiredSize">
	/// A pointer to variable of type DWORD that receives the size, in characters, that is required to store the class description
	/// (including a NULL terminator). RequiredSize is always less than LINE_LEN. This parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>Call <c>SetupDiGetClassDescriptionEx</c> to retrieve the description of a setup class installed on a remote computer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdescriptiona WINSETUPAPI BOOL
	// SetupDiGetClassDescriptionA( const GUID *ClassGuid, PSTR ClassDescription, DWORD ClassDescriptionSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDescriptionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassDescription(in Guid ClassGuid, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder ClassDescription,
		uint ClassDescriptionSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetClassDescriptionEx</c> function retrieves the description of a setup class installed on a local or remote computer.
	/// </summary>
	/// <param name="ClassGuid">A pointer to the GUID for the setup class whose description is to be retrieved.</param>
	/// <param name="ClassDescription">A pointer to a character buffer that receives the class description.</param>
	/// <param name="ClassDescriptionSize">
	/// The size, in characters, of the buffer that is pointed to by the ClassDescription parameter. The maximum length, in characters,
	/// of a NULL-terminated class description is LINE_LEN. For more information, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a DWORD-typed variable that receives the size, in characters, that is required to store the requested
	/// NULL-terminated class description. This pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a NULL-terminated string that supplies the name of a remote computer on which the setup class resides. This pointer
	/// is optional and can be <c>NULL</c>. If the class is installed on a local computer, set the pointer to <c>NULL</c>.
	/// </param>
	/// <param name="Reserved">Reserved for system use. A caller of this function must set this parameter to <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If there is a friendly name in the registry key for the class, this routine returns the friendly name. Otherwise, this routine
	/// returns the class name.
	/// </para>
	/// <para>
	/// <c>SetupDiGetClassDescriptionEx</c> does not enforce a restriction on the length of the class description that it can return.
	/// This function returns the required size for a NULL-terminated class description even if it is greater than LINE_LEN. However,
	/// LINE_LEN is the maximum length of a valid NULL-terminated class description. A caller should never need a buffer that is larger
	/// than LINE_LEN.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdescriptionexa WINSETUPAPI BOOL
	// SetupDiGetClassDescriptionExA( const GUID *ClassGuid, PSTR ClassDescription, DWORD ClassDescriptionSize, PDWORD RequiredSize,
	// PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDescriptionExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassDescriptionEx(in Guid ClassGuid, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder ClassDescription,
		uint ClassDescriptionSize, out uint RequiredSize, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, IntPtr Reserved = default);

	/// <summary>
	/// The <c>SetupDiGetClassDevPropertySheets</c> function retrieves handles to the property sheets of a device information element or
	/// of the device setup class of a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set for which to return property sheet handles. If DeviceInfoData does not specify a device
	/// information element in the device information set, the device information set must have an associated device setup class.
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet.</para>
	/// <para>
	/// This parameter is optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetClassDevPropertySheets</c>
	/// retrieves the property sheets handles that are associated with the specified device. If this parameter is <c>NULL</c>,
	/// <c>SetupDiGetClassDevPropertySheets</c> retrieves the property sheets handles that are associated with the device setup class
	/// specified in DeviceInfoSet.
	/// </para>
	/// </param>
	/// <param name="PropertySheetHeader">
	/// <para>
	/// A pointer to a PROPERTYSHEETHEADER structure. See the <c>Remarks</c> section for information about the caller-supplied array of
	/// property sheet handles that is associated with this structure.
	/// </para>
	/// <para>For more documentation on this structure and property sheets in general, see the Microsoft Windows SDK.</para>
	/// </param>
	/// <param name="PropertySheetHeaderPageListSize">
	/// The maximum number of handles that the caller-supplied array of property sheet handles can hold.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of property sheets that are associated with the specified device
	/// information element or the device setup class of the specified device information set. The pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="PropertySheetType">
	/// <para>A flag that indicates one of the following types of property sheets.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property sheet type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIGCDP_FLAG_ADVANCED</term>
	/// <term>Advanced property sheets.</term>
	/// </item>
	/// <item>
	/// <term>DIGCDP_FLAG_BASIC</term>
	/// <term>
	/// Basic property sheets. Supported only in Microsoft Windows 95 and Windows 98. Do not use in Windows 2000 and later versions of Windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIGCDP_FLAG_REMOTE_ADVANCED</term>
	/// <term>Advanced property sheets on a remote computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if successful. Otherwise, the function returns <c>FALSE</c>. Call GetLastError to obtain the
	/// error code.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A PROPERTYSHEETHEADER structure contains two members that are associated with a caller-supplied array that the function uses to
	/// return the handles of property sheets. The <c>phpages</c> member is a pointer to a caller-supplied array of property sheet
	/// handles, and the input value of the <c>nPages</c> member specifies the number of handles that are already contained in the
	/// handle array. The function adds property sheet handles to the handle array beginning with the array element whose array index is
	/// the input value of <c>nPages</c>. The function adds handles to the array in consecutive order until either the array is full or
	/// the handles of all the requested property sheet pages have been added to the array. The maximum number of property sheet handles
	/// that the function can return is equal to (PropertySheetHeaderPageListSize - (input value of <c>nPages</c>)).
	/// </para>
	/// <para>If the handle array is large enough to hold the handles of all the requested property sheet pages, the function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Adds the handles to the handle array.</term>
	/// </item>
	/// <item>
	/// <term>Sets <c>nPages</c> to the total number of handles in the array.</term>
	/// </item>
	/// <item>
	/// <term>Sets RequiredSize to the number of handles that it returns.</term>
	/// </item>
	/// <item>
	/// <term>Returns <c>TRUE</c>.</term>
	/// </item>
	/// </list>
	/// <para>If the handle array is not large enough to hold the handles of all the specified property sheet pages, the function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Adds as many handles as the array can hold.</term>
	/// </item>
	/// <item>
	/// <term>Sets <c>nPages</c> to PropertySheetHeaderPageListSize.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Sets RequiredSize to the total number of requested property sheet pages. The number of handles that are not returned by the
	/// function is equal to (RequiredSize - PropertySheetHeaderPageListSize - (input value of <c>nPages</c>)).
	/// </term>
	/// </item>
	/// <item>
	/// <term>Sets the error code to ERROR_INSUFFICIENT_BUFFER.</term>
	/// </item>
	/// <item>
	/// <term>Returns <c>FALSE</c>.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevpropertysheetsa WINSETUPAPI BOOL
	// SetupDiGetClassDevPropertySheetsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, LPPROPSHEETHEADERA
	// PropertySheetHeader, DWORD PropertySheetHeaderPageListSize, PDWORD RequiredSize, DWORD PropertySheetType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevPropertySheetsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassDevPropertySheets(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[In] IntPtr PropertySheetHeader, uint PropertySheetHeaderPageListSize, out uint RequiredSize, DIGCDP_FLAG PropertySheetType);

	/// <summary>
	/// The <c>SetupDiGetClassDevPropertySheets</c> function retrieves handles to the property sheets of a device information element or
	/// of the device setup class of a device information set.
	/// </summary>
	/// <param name="DeviceInfoSet">
	/// A handle to the device information set for which to return property sheet handles. If DeviceInfoData does not specify a device
	/// information element in the device information set, the device information set must have an associated device setup class.
	/// </param>
	/// <param name="DeviceInfoData">
	/// <para>A pointer to an SP_DEVINFO_DATA structure that specifies a device information element in DeviceInfoSet.</para>
	/// <para>
	/// This parameter is optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetClassDevPropertySheets</c>
	/// retrieves the property sheets handles that are associated with the specified device. If this parameter is <c>NULL</c>,
	/// <c>SetupDiGetClassDevPropertySheets</c> retrieves the property sheets handles that are associated with the device setup class
	/// specified in DeviceInfoSet.
	/// </para>
	/// </param>
	/// <param name="PropertySheetHeader">
	/// <para>
	/// A pointer to a PROPERTYSHEETHEADER structure. See the <c>Remarks</c> section for information about the caller-supplied array of
	/// property sheet handles that is associated with this structure.
	/// </para>
	/// <para>For more documentation on this structure and property sheets in general, see the Microsoft Windows SDK.</para>
	/// </param>
	/// <param name="PropertySheetHeaderPageListSize">
	/// The maximum number of handles that the caller-supplied array of property sheet handles can hold.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of property sheets that are associated with the specified device
	/// information element or the device setup class of the specified device information set. The pointer is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="PropertySheetType">
	/// <para>A flag that indicates one of the following types of property sheets.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property sheet type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DIGCDP_FLAG_ADVANCED</term>
	/// <term>Advanced property sheets.</term>
	/// </item>
	/// <item>
	/// <term>DIGCDP_FLAG_BASIC</term>
	/// <term>
	/// Basic property sheets. Supported only in Microsoft Windows 95 and Windows 98. Do not use in Windows 2000 and later versions of Windows.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DIGCDP_FLAG_REMOTE_ADVANCED</term>
	/// <term>Advanced property sheets on a remote computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if successful. Otherwise, the function returns <c>FALSE</c>. Call GetLastError to obtain the
	/// error code.
	/// </returns>
	/// <remarks>
	/// <para>
	/// A PROPERTYSHEETHEADER structure contains two members that are associated with a caller-supplied array that the function uses to
	/// return the handles of property sheets. The <c>phpages</c> member is a pointer to a caller-supplied array of property sheet
	/// handles, and the input value of the <c>nPages</c> member specifies the number of handles that are already contained in the
	/// handle array. The function adds property sheet handles to the handle array beginning with the array element whose array index is
	/// the input value of <c>nPages</c>. The function adds handles to the array in consecutive order until either the array is full or
	/// the handles of all the requested property sheet pages have been added to the array. The maximum number of property sheet handles
	/// that the function can return is equal to (PropertySheetHeaderPageListSize - (input value of <c>nPages</c>)).
	/// </para>
	/// <para>If the handle array is large enough to hold the handles of all the requested property sheet pages, the function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Adds the handles to the handle array.</term>
	/// </item>
	/// <item>
	/// <term>Sets <c>nPages</c> to the total number of handles in the array.</term>
	/// </item>
	/// <item>
	/// <term>Sets RequiredSize to the number of handles that it returns.</term>
	/// </item>
	/// <item>
	/// <term>Returns <c>TRUE</c>.</term>
	/// </item>
	/// </list>
	/// <para>If the handle array is not large enough to hold the handles of all the specified property sheet pages, the function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Adds as many handles as the array can hold.</term>
	/// </item>
	/// <item>
	/// <term>Sets <c>nPages</c> to PropertySheetHeaderPageListSize.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Sets RequiredSize to the total number of requested property sheet pages. The number of handles that are not returned by the
	/// function is equal to (RequiredSize - PropertySheetHeaderPageListSize - (input value of <c>nPages</c>)).
	/// </term>
	/// </item>
	/// <item>
	/// <term>Sets the error code to ERROR_INSUFFICIENT_BUFFER.</term>
	/// </item>
	/// <item>
	/// <term>Returns <c>FALSE</c>.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevpropertysheetsa WINSETUPAPI BOOL
	// SetupDiGetClassDevPropertySheetsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, LPPROPSHEETHEADERA
	// PropertySheetHeader, DWORD PropertySheetHeaderPageListSize, PDWORD RequiredSize, DWORD PropertySheetType );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevPropertySheetsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassDevPropertySheets(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		[In] IntPtr PropertySheetHeader, uint PropertySheetHeaderPageListSize, out uint RequiredSize, DIGCDP_FLAG PropertySheetType);

	/// <summary>
	/// The <c>SetupDiGetClassDevs</c> function returns a handle to a device information set that contains requested device information
	/// elements for a local computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be <c>NULL</c>. For more
	/// information about how to set ClassGuid, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="Enumerator">
	///   <para>A pointer to a NULL-terminated string that specifies:</para>
	///   <list type="bullet">
	///     <item>
	/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the value's globally unique
	/// identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for
	/// PnP values include "USB," "PCMCIA," and "SCSI".
	/// </item>
	///     <item>A PnP device instance ID. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.</item>
	///   </list>
	///   <para>
	/// This pointer is optional and can be NULL. If an enumeration value is not used to select devices, set Enumerator to NULL. For more
	/// information about how to set the Enumerator value, see the following <c>Remarks</c> section.
	/// </para>
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the device
	/// information set. This handle is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	///   <para>
	/// A variable of type DWORD that specifies control options that filter the device information elements that are added to the device
	/// information set. This parameter can be a bitwise OR of zero or more of the following flags. For more information about combining
	/// these flags, see the following <c>Remarks</c> section.
	/// </para>
	///   <list type="bullet">
	///     <item>DIGCF_ALLCLASSES</item>
	///     <item>Return a list of installed devices for all device setup classes or all device interface classes.</item>
	///     <item>DIGCF_DEVICEINTERFACE</item>
	///     <item>Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags parameter if the Enumerator parameter specifies a device instance ID. </item>
	///     <item>DIGCF_DEFAULT</item>
	///     <item>Return only the device that is associated with the system default device interface, if one is set, for the specified device interface classes. </item>
	///     <item>DIGCF_PRESENT</item>
	///     <item>Return only devices that are currently present in a system.</item>
	///     <item>DIGCF_PROFILE</item>
	///     <item>Return only devices that are a part of the current hardware profile.</item>
	///   </list>
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiGetClassDevs</c> returns a handle to a device information set that contains all installed
	/// devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	///   <para>
	/// The caller of <c>SetupDiGetClassDevs</c> must delete the returned device information set when it is no longer needed by calling SetupDiDestroyDeviceInfoList.
	/// </para>
	///   <para>Call SetupDiGetClassDevsEx to retrieve the devices for a class on a remote computer.</para>
	///   <para>Device Setup Class Control Options</para>
	///   <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns devices for all device setup classes or
	/// only for a specified device setup class:
	/// </para>
	///   <list type="bullet">
	///     <item>To return devices for all device setup classes, set the DIGCF_ALLCLASSES flag, and set the ClassGuid parameter to <c>NULL</c>.</item>
	///     <item>
	/// To return devices only for a specific device setup class, do not set DIGCF_ALLCLASSES, and use ClassGuid to supply the GUID of the
	/// device setup class.
	/// </item>
	///   </list>
	///   <para>
	/// In addition, you can use the following filtering options in combination with one another to further restrict which devices are returned:
	/// </para>
	///   <list type="bullet">
	///     <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	///     <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	///     <item>
	/// To return devices only for a specific PnP enumerator, use the Enumerator parameter to supply the GUID or symbolic name of the
	/// enumerator. If Enumerator is <c>NULL</c>, <c>SetupDiGetClassDevs</c> returns devices for all PnP enumerators.
	/// </item>
	///   </list>
	///   <para>Device Interface Class Control Options</para>
	///   <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns devices that support any device interface
	/// class or only devices that support a specified device interface class:
	/// </para>
	///   <list type="bullet">
	///     <item>
	/// To return devices that support a device interface of any class, set the DIGCF_DEVICEINTERFACE flag, set the
	/// DIGCF_ALLCLASSES flag, and set ClassGuid to <c>NULL</c>. The function adds to the device information set a device information element
	/// that represents such a device and then adds to the device information element a device interface list that contains all the device
	/// interfaces that the device supports.
	/// </item>
	///     <item>
	/// To return only devices that support a device interface of a specified class, set the DIGCF_DEVICEINTERFACE flag and use the ClassGuid
	/// parameter to supply the class GUID of the device interface class. The function adds to the device information set a device
	/// information element that represents such a device and then adds a device interface of the specified class to the device interface
	/// list for that device information element.
	/// </item>
	///   </list>
	///   <para>
	/// In addition, you can use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns only devices that
	/// support the system default interface for device interface classes:
	/// </para>
	///   <list type="bullet">
	///     <item>
	/// To return only the device that supports the system default interface, if one is set, for a specified device
	/// interface class, set the DIGCF_DEVICEINTERFACE flag, set the DIGCF_DEFAULT flag, and use ClassGuid to supply the class GUID of the
	/// device interface class. The function adds to the device information set a device information element that represents such a device
	/// and then adds the system default interface to the device interface list for that device information element.
	/// </item>
	///     <item>
	/// To return a device that supports a system default interface for an unspecified device interface class, set the DIGCF_DEVICEINTERFACE
	/// flag, set the DIGCF_ALLCLASSES flag, set the DIGCF_DEFAULT flag, and set ClassGuid to <c>NULL</c>. The function adds to the device
	/// information set a device information element that represents such a device and then adds the system default interface to the device
	/// interface list for that device information element.
	/// </item>
	///   </list>
	///   <para>You can also use the following options in combination with the other options to further restrict which devices are returned:</para>
	///   <list type="bullet">
	///     <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	///     <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	///     <item>
	/// To return only a specific device, set the DIGCF_DEVICEINTERFACE flag and use the Enumerator parameter to supply the device instance
	/// ID of the device. To include all possible devices, set Enumerator to <c>NULL</c>.
	/// </item>
	///   </list>
	///   <para>Examples</para>
	///   <para>The following are some examples of how to use the <c>SetupDiGetClassDevs</c> function.</para>
	///   <para>
	///     <c>Example 1:</c> Build a list of all devices in the system, including devices that are not currently present.</para>
	///   <para>
	///     <span id="cbc_1" codelanguage="CSharp" x-lang="CSharp"></span>
	///     <div class="highlight-title">
	///       <span tabindex="0" class="highlight-copycode"></span>C#</div>
	///     <div class="code">
	///       <pre xml:space="preserve">Handle = SetupDiGetClassDevs(NULL, NULL, NULL, DIGCF_ALLCLASSES);</pre>
	///     </div>
	///   </para>
	///   <para>
	///     <c>Example 2:</c> Build a list of all devices that are present in the system.</para>
	///   <para>
	///     <span id="cbc_2" codelanguage="CSharp" x-lang="CSharp"></span>
	///     <div class="highlight-title">
	///       <span tabindex="0" class="highlight-copycode"></span>C#</div>
	///     <div class="code">
	///       <pre xml:space="preserve">Handle = SetupDiGetClassDevs(NULL, NULL, NULL, DIGCF_ALLCLASSES | DIGCF_PRESENT);</pre>
	///     </div>
	///   </para>
	///   <para>
	///     <c>Example 3:</c> Build a list of all devices that are present in the system that are from the network adapter device setup class.
	/// </para>
	///   <para>
	///     <span id="cbc_3" codelanguage="CSharp" x-lang="CSharp"></span>
	///     <div class="highlight-title">
	///       <span tabindex="0" class="highlight-copycode"></span>C#</div>
	///     <div class="code">
	///       <pre xml:space="preserve">Handle = SetupDiGetClassDevs(&amp;GUID_DEVCLASS_NET, NULL, NULL, DIGCF_PRESENT);</pre>
	///     </div>
	///   </para>
	///   <para>
	///     <c>Example 4:</c> Build a list of all devices that are present in the system that have enabled an interface from the storage volume
	/// device interface class.
	/// </para>
	///   <para>
	///     <span id="cbc_4" codelanguage="CSharp" x-lang="CSharp"></span>
	///     <div class="highlight-title">
	///       <span tabindex="0" class="highlight-copycode"></span>C#</div>
	///     <div class="code">
	///       <pre xml:space="preserve">Handle = SetupDiGetClassDevs(&amp;GUID_DEVINTERFACE_VOLUME, NULL, NULL, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);</pre>
	///     </div>
	///   </para>
	///   <para>
	///     <c>Example 5:</c> Build a list of all devices that are present in the system but do not belong to any known device setup class
	/// (Windows Vista and later versions of Windows).
	/// </para>
	///   <para>
	///     <note type="note">You cannot set the ClassGuid parameter to GUID_DEVCLASS_UNKNOWN to detect devices with an unknown setup class. Instead,
	/// you must follow this example.</note>
	///   </para>
	///   <para>
	///     <span id="cbc_5" codelanguage="CSharp" x-lang="CSharp"></span>
	///     <div class="highlight-title">
	///       <span tabindex="0" class="highlight-copycode"></span>C#</div>
	///     <div class="code">
	///       <pre xml:space="preserve">DeviceInfoSet = SetupDiGetClassDevs(
	///                                  NULL,
	///                                  NULL,
	///                                  NULL,
	///                                  DIGCF_ALLCLASSES | DIGCF_PRESENT);
	/// ZeroMemory(&amp;DeviceInfoData, <span class="highlight-keyword">sizeof</span>(SP_DEVINFO_DATA));
	/// DeviceInfoData.cbSize = <span class="highlight-keyword">sizeof</span>(SP_DEVINFO_DATA);
	/// DeviceIndex = <span class="highlight-number">0</span>;
	/// <span class="highlight-keyword">while</span> (SetupDiEnumDeviceInfo(
	///                           DeviceInfoSet,
	///                           DeviceIndex,
	///                           &amp;DeviceInfoData)) {
	///  DeviceIndex++;
	///  <span class="highlight-keyword">if</span> (!SetupDiGetDeviceProperty(
	///                                DeviceInfoSet,
	///                                &amp;DeviceInfoData,
	///                                &amp;DEVPKEY_Device_Class,
	///                                &amp;PropType,
	///                                (PBYTE)&amp;DevGuid,
	///                                <span class="highlight-keyword">sizeof</span>(GUID),
	///                                &amp;Size,
	///                                <span class="highlight-number">0</span>) || PropType != DEVPROP_TYPE_GUID) {
	///      Error = GetLastError();
	///      <span class="highlight-keyword">if</span> (Error == ERROR_NOT_FOUND) {
	///          \\
	///          \\ This device has an unknown device setup <span class="highlight-keyword">class</span>.
	///          \\
	///          }
	///      }
	///  }
	/// <span class="highlight-keyword">if</span> (DeviceInfoSet) {
	///  SetupDiDestroyDeviceInfoList(DeviceInfoSet);
	///  }</pre>
	///     </div>
	///   </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw WINSETUPAPI HDEVINFO
	// SetupDiGetClassDevsW( const GUID *ClassGuid, PCWSTR Enumerator, HWND hwndParent, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevsW")]
	public static extern SafeHDEVINFO SetupDiGetClassDevs(in Guid ClassGuid, [In, Optional] string? Enumerator, [In, Optional] HWND hwndParent, DIGCF Flags);

	/// <summary>
	/// The <c>SetupDiGetClassDevs</c> function returns a handle to a device information set that contains requested device information
	/// elements for a local computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be <c>NULL</c>. For
	/// more information about how to set ClassGuid, see the following <c>Remarks</c> section.
	/// </param>
	/// <param name="Enumerator">
	/// <para>A pointer to a NULL-terminated string that specifies:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the value's globally unique identifier (GUID) or
	/// symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for PnP values
	/// include "USB," "PCMCIA," and "SCSI".
	/// </term>
	/// </item>
	/// <item>
	/// <term>A PnP device instance ID. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.</term>
	/// </item>
	/// </list>
	/// <para>This pointer is optional and can be</para>
	/// <para>NULL</para>
	/// <para>. If an</para>
	/// <para>enumeration</para>
	/// <para>value is not used to select devices, set</para>
	/// <para>Enumerator</para>
	/// <para>to</para>
	/// <para>NULL</para>
	/// <para>For more information about how to set the Enumerator value, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the
	/// device information set. This handle is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A variable of type DWORD that specifies control options that filter the device information elements that are added to the device
	/// information set. This parameter can be a bitwise OR of zero or more of the following flags. For more information about combining
	/// these flags, see the following <c>Remarks</c> section.
	/// </para>
	/// <para>DIGCF_ALLCLASSES</para>
	/// <para>Return a list of installed devices for all device setup classes or all device interface classes.</para>
	/// <para>DIGCF_DEVICEINTERFACE</para>
	/// <para>
	/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags
	/// parameter if the Enumerator parameter specifies a device instance ID.
	/// </para>
	/// <para>DIGCF_DEFAULT</para>
	/// <para>
	/// Return only the device that is associated with the system default device interface, if one is set, for the specified device
	/// interface classes.
	/// </para>
	/// <para>DIGCF_PRESENT</para>
	/// <para>Return only devices that are currently present in a system.</para>
	/// <para>DIGCF_PROFILE</para>
	/// <para>Return only devices that are a part of the current hardware profile.</para>
	/// </param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiGetClassDevs</c> returns a handle to a device information set that contains all installed
	/// devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of <c>SetupDiGetClassDevs</c> must delete the returned device information set when it is no longer needed by calling
	/// <see cref="SetupDiDestroyDeviceInfoList"/>.
	/// </para>
	/// <para>Call SetupDiGetClassDevsEx to retrieve the devices for a class on a remote computer.</para>
	/// <para>Device Setup Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns devices for all device setup classes
	/// or only for a specified device setup class:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>To return devices for all device setup classes, set the DIGCF_ALLCLASSES flag, and set the ClassGuid parameter to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// To return devices only for a specific device setup class, do not set DIGCF_ALLCLASSES, and use ClassGuid to supply the GUID of
	/// the device setup class.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In addition, you can use the following filtering options in combination with one another to further restrict which devices are returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</term>
	/// </item>
	/// <item>
	/// <term>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</term>
	/// </item>
	/// <item>
	/// <term>
	/// To return devices only for a specific PnP enumerator, use the Enumerator parameter to supply the GUID or symbolic name of the
	/// enumerator. If Enumerator is <c>NULL</c>, <c>SetupDiGetClassDevs</c> returns devices for all PnP enumerators.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Device Interface Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns devices that support any device
	/// interface class or only devices that support a specified device interface class:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To return devices that support a device interface of any class, set the DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES
	/// flag, and set ClassGuid to <c>NULL</c>. The function adds to the device information set a device information element that
	/// represents such a device and then adds to the device information element a device interface list that contains all the device
	/// interfaces that the device supports.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To return only devices that support a device interface of a specified class, set the DIGCF_DEVICEINTERFACE flag and use the
	/// ClassGuid parameter to supply the class GUID of the device interface class. The function adds to the device information set a
	/// device information element that represents such a device and then adds a device interface of the specified class to the device
	/// interface list for that device information element.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In addition, you can use the following filtering options to control whether <c>SetupDiGetClassDevs</c> returns only devices that
	/// support the system default interface for device interface classes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To return only the device that supports the system default interface, if one is set, for a specified device interface class, set
	/// the DIGCF_DEVICEINTERFACE flag, set the DIGCF_DEFAULT flag, and use ClassGuid to supply the class GUID of the device interface
	/// class. The function adds to the device information set a device information element that represents such a device and then adds
	/// the system default interface to the device interface list for that device information element.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To return a device that supports a system default interface for an unspecified device interface class, set the
	/// DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES flag, set the DIGCF_DEFAULT flag, and set ClassGuid to <c>NULL</c>. The
	/// function adds to the device information set a device information element that represents such a device and then adds the system
	/// default interface to the device interface list for that device information element.
	/// </term>
	/// </item>
	/// </list>
	/// <para>You can also use the following options in combination with the other options to further restrict which devices are returned:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</term>
	/// </item>
	/// <item>
	/// <term>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</term>
	/// </item>
	/// <item>
	/// <term>
	/// To return only a specific device, set the DIGCF_DEVICEINTERFACE flag and use the Enumerator parameter to supply the device
	/// instance ID of the device. To include all possible devices, set Enumerator to <c>NULL</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>The following are some examples of how to use the <c>SetupDiGetClassDevs</c> function.</para>
	/// <para><c>Example 1:</c> Build a list of all devices in the system, including devices that are not currently present.</para>
	/// <para>
	/// <code>Handle = SetupDiGetClassDevs(NULL, NULL, NULL, DIGCF_ALLCLASSES);</code>
	/// </para>
	/// <para><c>Example 2:</c> Build a list of all devices that are present in the system.</para>
	/// <para>
	/// <code>Handle = SetupDiGetClassDevs(NULL, NULL, NULL, DIGCF_ALLCLASSES | DIGCF_PRESENT);</code>
	/// </para>
	/// <para>
	/// <c>Example 3:</c> Build a list of all devices that are present in the system that are from the network adapter device setup class.
	/// </para>
	/// <para>
	/// <code>Handle = SetupDiGetClassDevs(&amp;GUID_DEVCLASS_NET, NULL, NULL, DIGCF_PRESENT);</code>
	/// </para>
	/// <para>
	/// <c>Example 4:</c> Build a list of all devices that are present in the system that have enabled an interface from the storage
	/// volume device interface class.
	/// </para>
	/// <para>
	/// <code>Handle = SetupDiGetClassDevs(&amp;GUID_DEVINTERFACE_VOLUME, NULL, NULL, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);</code>
	/// </para>
	/// <para>
	/// <c>Example 5:</c> Build a list of all devices that are present in the system but do not belong to any known device setup class
	/// (Windows Vista and later versions of Windows).
	/// </para>
	/// <para>
	/// <c>Note</c> You cannot set the ClassGuid parameter to GUID_DEVCLASS_UNKNOWN to detect devices with an unknown setup class.
	/// Instead, you must follow this example.
	/// </para>
	/// <para>
	/// <code>DeviceInfoSet = SetupDiGetClassDevs( NULL, NULL, NULL, DIGCF_ALLCLASSES | DIGCF_PRESENT); ZeroMemory(&amp;DeviceInfoData, sizeof(SP_DEVINFO_DATA)); DeviceInfoData.cbSize = sizeof(SP_DEVINFO_DATA); DeviceIndex = 0; while (SetupDiEnumDeviceInfo( DeviceInfoSet, DeviceIndex, &amp;DeviceInfoData)) { DeviceIndex++; if (!SetupDiGetDeviceProperty( DeviceInfoSet, &amp;DeviceInfoData, &amp;DEVPKEY_Device_Class, &amp;PropType, (PBYTE)&amp;DevGuid, sizeof(GUID), &amp;Size, 0) || PropType != DEVPROP_TYPE_GUID) { Error = GetLastError(); if (Error == ERROR_NOT_FOUND) { \\ \\ This device has an unknown device setup class. \\ } } } if (DeviceInfoSet) { SetupDiDestroyDeviceInfoList(DeviceInfoSet); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw WINSETUPAPI HDEVINFO
	// SetupDiGetClassDevsW( const GUID *ClassGuid, PCWSTR Enumerator, HWND hwndParent, DWORD Flags );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevsW")]
	public static extern SafeHDEVINFO SetupDiGetClassDevs([In, Optional] IntPtr ClassGuid, [In, Optional] string? Enumerator,
		[In, Optional] HWND hwndParent, DIGCF Flags);

	/// <summary>
	/// The <c>SetupDiGetClassDevsEx</c> function returns a handle to a device information set that contains requested device
	/// information elements for a local or a remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be <c>NULL</c>. If
	/// a GUID value is not used to select devices, set ClassGuid to <c>NULL</c>. For more information about how to use ClassGuid, see
	/// the following <c>Remarks</c> section.
	/// </param>
	/// <param name="Enumerator">
	/// <para>A pointer to a NULL-terminated string that specifies:</para>
	/// <list type="bullet">
	/// <item>
	/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier (GUID)
	/// or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names for PnP
	/// enumerators include "USB", "PCMCIA", and "SCSI".
	/// </item>
	/// <item>A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter</item>
	/// </list>
	/// <para>This pointer is optional and can be NULL. If an Enumerator value is not used to select devices, set Enumerator to NULL.</para>
	/// <para>For more information about how to set the Enumerator value, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the
	/// device information set. This handle is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A variable of type DWORD that specifies control options that filter the device information elements that are added to the device
	/// information set. This parameter can be a bitwise OR of one or more of the following flags. For more information about combining
	/// these control options, see the following <c>Remarks</c> section.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>DIGCF_ALLCLASSES</term>
	/// <description>Return a list of installed devices for the specified device setup classes or device interface classes.</description>
	/// </item>
	/// <item>
	/// <term>DIGCF_DEVICEINTERFACE</term>
	/// <description>
	/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags
	/// parameter if the Enumerator parameter specifies a device instance ID.
	/// </description>
	/// </item>
	/// <item>
	/// <term>DIGCF_DEFAULT</term>
	/// <description>
	/// Return only the device that is associated with the system default device interface, if one is set, for the specified device
	/// interface classes.
	/// </description>
	/// </item>
	/// <item>
	/// <term>DIGCF_PRESENT</term>
	/// <description>Return only devices that are currently present.</description>
	/// </item>
	/// <item>
	/// <term>DIGCF_PROFILE</term>
	/// <description>Return only devices that are a part of the current hardware profile.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// The handle to an existing device information set to which <c>SetupDiGetClassDevsEx</c> adds the requested device information
	/// elements. This parameter is optional and can be set to <c>NULL</c>. For more information about using this parameter, see the
	/// following <c>Remarks</c> section.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a constant string that contains the name of a remote computer on which the devices reside. A value of <c>NULL</c>
	/// for MachineName specifies that the device is installed on the local computer.
	/// </param>
	/// <param name="Reserved">Reserved for internal use. This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiGetClassDevsEx</c> returns a handle to a device information set that contains all installed
	/// devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of <c>SetupDiGetClassDevsEx</c> must delete the returned device information set when it is no longer needed by
	/// calling SetupDiDestroyDeviceInfoList.
	/// </para>
	/// <para>
	/// If DeviceInfoSet is <c>NULL</c>, <c>SetupDiGetClassDevsEx</c> creates a new device information set that contains the retrieved
	/// device information elements and returns a handle to the new device information set. If the caller requests that the function
	/// retrieve devices for a device setup class that is supplied by the ClassGuid parameter, the function sets the device setup class
	/// of the new device information set to the supplied class GUID.
	/// </para>
	/// <para>
	/// If DeviceInfoSet is not set to <c>NULL</c>, the function adds the retrieved device information elements to the device
	/// information set that is associated with the supplied handle, and returns the supplied handle. If ClassGuid supplies a device
	/// setup class, the device setup class of the supplied device information set must be set to the supplied class GUID.
	/// </para>
	/// <para>Device Setup Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns devices for all device setup classes
	/// or only for a specified device setup class:
	/// </para>
	/// <list type="bullet">
	/// <item>To return devices for all device setup classes, set the DIGCF_ALLCLASSES flag and set the ClassGuid parameter to <c>NULL</c>.</item>
	/// <item>
	/// To return devices only for a specific device setup class, do not set DIGCF_ALLCLASSES and use ClassGuid to supply the GUID of
	/// the device setup class.
	/// </item>
	/// </list>
	/// <para>In addition, you can use the following filtering options to further restrict which devices are returned.</para>
	/// <list type="bullet">
	/// <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	/// <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	/// <item>
	/// To return devices for a specific PnP enumerator only, use the Enumerator parameter to supply the GUID or symbolic name of the
	/// enumerator. If Enumerator is <c>NULL</c>, <c>SetupDiGetClassDevsEx</c> returns devices for all PnP enumerators.
	/// </item>
	/// </list>
	/// <para>Device Interface Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns devices that support any device
	/// interface class or only devices that support a specified device interface class:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// To return devices that support a device interface of any class, set the DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES
	/// flag, and set ClassGuid to <c>NULL</c>. The function adds to the device information set a device information element that
	/// represents such a device, and then adds to the device information element a device interface list that contains all the device
	/// interfaces that the device supports.
	/// </item>
	/// <item>
	/// To return only devices that support a device interface of a specified class, set the DIGCF_DEVICEINTERFACE flag and use the
	/// ClassGuid parameter to supply the class GUID of the device interface class. The function adds to the device information set a
	/// device information element that represents such a device, and then adds a device interface of the specified class to the device
	/// interface list for that device information element.
	/// </item>
	/// </list>
	/// <para>
	/// In addition, you can use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns only devices
	/// that support the system default interface for device interface classes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// To return only the device that supports the system default interface, if one is set, for a specified device interface class, set
	/// the DIGCF_DEVICEINTERFACE flag, set the DIGCF_DEFAULT flag, and use ClassGuid to supply the class GUID of the device interface
	/// class. The function adds to the device information set a device information element that represents such a device, and then adds
	/// the system default interface to the device interface list for that device information element.
	/// </item>
	/// <item>
	/// To return a device that supports a system default interface for an unspecified device interface class, set the
	/// DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES flag, set the DIGCF_DEFAULT flag, and set ClassGuid to <c>NULL</c>. The
	/// function adds to the device information set a device information element that represents such a device, and then adds the system
	/// default interface to the device interface list for that device information element.
	/// </item>
	/// </list>
	/// <para>You can also use the following options in combination with the other options to further restrict which devices are returned.</para>
	/// <list type="bullet">
	/// <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	/// <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	/// <item>
	/// To return only a specific device, set the DIGCF_DEVICEINTERFACE flag and use the Enumerator parameter to supply the device
	/// instance ID of the device. To include all possible devices, set Enumerator to <c>NULL</c>.
	/// </item>
	/// </list>
	/// <para>Retrieving Devices in a Device Setup Class That Support a Device Interface Class</para>
	/// <para>
	/// An installer can use <c>SetupDiGetClassDevsEx</c> to retrieve a list of devices of a particular device setup class that support
	/// a device interface of a specified device interface class. For example, to retrieve a list of all devices on a local computer
	/// that support a device interface in the "mounted device" interface class and that are members of the "Volume" device setup class,
	/// an installer should perform the following operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// Call SetupDiCreateDeviceInfoList to create an empty device information set for the "Volume" device setup class. Set ClassGuid to
	/// a pointer to the class GUID for the "Volume" device setup class and set hwndParent as appropriate. In response to such a call,
	/// the function will return a handle to type HDEVINFO to the device information set.
	/// </item>
	/// <item>
	/// <para>Call <c>SetupDiGetClassDevsEx</c> with the following settings:</para>
	/// <list type="bullet">
	/// <item>Set ClassGuid to a pointer to the class GUID of the "mounted device" device interface class.</item>
	/// <item>Set Flags to DIGCF_DEVICEINTERFACE.</item>
	/// <item>Set DeviceInfoSet to the HDEVINFO handle obtained in step (1).</item>
	/// <item>Set hwndParent as appropriate and the remaining parameters to NULL.</item>
	/// </list>
	/// </item>
	/// </list>
	/// <para>
	/// In an operation of this type, <c>SetupDiGetClassDevsEx</c> returns a device if the device setup class of the device is the same
	/// as the supplied device information set and if the device supports a device interface whose class is the same as the specified
	/// device interface class.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsexa WINSETUPAPI HDEVINFO
	// SetupDiGetClassDevsExA( const GUID *ClassGuid, PCSTR Enumerator, HWND hwndParent, DWORD Flags, HDEVINFO DeviceInfoSet, PCSTR
	// MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevsExA")]
	public static extern SafeHDEVINFO SetupDiGetClassDevsEx(in Guid ClassGuid, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? Enumerator,
		[In, Optional] HWND hwndParent, DIGCF Flags, [In, Optional] HDEVINFO DeviceInfoSet,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiGetClassDevsEx</c> function returns a handle to a device information set that contains requested device
	/// information elements for a local or a remote computer.
	/// </summary>
	/// <param name="ClassGuid">
	/// A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be <c>NULL</c>. If
	/// a GUID value is not used to select devices, set ClassGuid to <c>NULL</c>. For more information about how to use ClassGuid, see
	/// the following <c>Remarks</c> section.
	/// </param>
	/// <param name="Enumerator">
	/// <para>A pointer to a NULL-terminated string that specifies:</para>
	/// <list type="bullet">
	/// <item>
	/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier (GUID)
	/// or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names for PnP
	/// enumerators include "USB", "PCMCIA", and "SCSI".
	/// </item>
	/// <item>A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter</item>
	/// </list>
	/// <para>This pointer is optional and can be NULL. If an Enumerator value is not used to select devices, set Enumerator to NULL.</para>
	/// <para>For more information about how to set the Enumerator value, see the following <c>Remarks</c> section.</para>
	/// </param>
	/// <param name="hwndParent">
	/// A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the
	/// device information set. This handle is optional and can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A variable of type DWORD that specifies control options that filter the device information elements that are added to the device
	/// information set. This parameter can be a bitwise OR of one or more of the following flags. For more information about combining
	/// these control options, see the following <c>Remarks</c> section.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>DIGCF_ALLCLASSES</term>
	/// <description>Return a list of installed devices for the specified device setup classes or device interface classes.</description>
	/// </item>
	/// <item>
	/// <term>DIGCF_DEVICEINTERFACE</term>
	/// <description>
	/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags
	/// parameter if the Enumerator parameter specifies a device instance ID.
	/// </description>
	/// </item>
	/// <item>
	/// <term>DIGCF_DEFAULT</term>
	/// <description>
	/// Return only the device that is associated with the system default device interface, if one is set, for the specified device
	/// interface classes.
	/// </description>
	/// </item>
	/// <item>
	/// <term>DIGCF_PRESENT</term>
	/// <description>Return only devices that are currently present.</description>
	/// </item>
	/// <item>
	/// <term>DIGCF_PROFILE</term>
	/// <description>Return only devices that are a part of the current hardware profile.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DeviceInfoSet">
	/// The handle to an existing device information set to which <c>SetupDiGetClassDevsEx</c> adds the requested device information
	/// elements. This parameter is optional and can be set to <c>NULL</c>. For more information about using this parameter, see the
	/// following <c>Remarks</c> section.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to a constant string that contains the name of a remote computer on which the devices reside. A value of <c>NULL</c>
	/// for MachineName specifies that the device is installed on the local computer.
	/// </param>
	/// <param name="Reserved">Reserved for internal use. This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// If the operation succeeds, <c>SetupDiGetClassDevsEx</c> returns a handle to a device information set that contains all installed
	/// devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended
	/// error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller of <c>SetupDiGetClassDevsEx</c> must delete the returned device information set when it is no longer needed by
	/// calling SetupDiDestroyDeviceInfoList.
	/// </para>
	/// <para>
	/// If DeviceInfoSet is <c>NULL</c>, <c>SetupDiGetClassDevsEx</c> creates a new device information set that contains the retrieved
	/// device information elements and returns a handle to the new device information set. If the caller requests that the function
	/// retrieve devices for a device setup class that is supplied by the ClassGuid parameter, the function sets the device setup class
	/// of the new device information set to the supplied class GUID.
	/// </para>
	/// <para>
	/// If DeviceInfoSet is not set to <c>NULL</c>, the function adds the retrieved device information elements to the device
	/// information set that is associated with the supplied handle, and returns the supplied handle. If ClassGuid supplies a device
	/// setup class, the device setup class of the supplied device information set must be set to the supplied class GUID.
	/// </para>
	/// <para>Device Setup Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns devices for all device setup classes
	/// or only for a specified device setup class:
	/// </para>
	/// <list type="bullet">
	/// <item>To return devices for all device setup classes, set the DIGCF_ALLCLASSES flag and set the ClassGuid parameter to <c>NULL</c>.</item>
	/// <item>
	/// To return devices only for a specific device setup class, do not set DIGCF_ALLCLASSES and use ClassGuid to supply the GUID of
	/// the device setup class.
	/// </item>
	/// </list>
	/// <para>In addition, you can use the following filtering options to further restrict which devices are returned.</para>
	/// <list type="bullet">
	/// <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	/// <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	/// <item>
	/// To return devices for a specific PnP enumerator only, use the Enumerator parameter to supply the GUID or symbolic name of the
	/// enumerator. If Enumerator is <c>NULL</c>, <c>SetupDiGetClassDevsEx</c> returns devices for all PnP enumerators.
	/// </item>
	/// </list>
	/// <para>Device Interface Class Control Options</para>
	/// <para>
	/// Use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns devices that support any device
	/// interface class or only devices that support a specified device interface class:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// To return devices that support a device interface of any class, set the DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES
	/// flag, and set ClassGuid to <c>NULL</c>. The function adds to the device information set a device information element that
	/// represents such a device, and then adds to the device information element a device interface list that contains all the device
	/// interfaces that the device supports.
	/// </item>
	/// <item>
	/// To return only devices that support a device interface of a specified class, set the DIGCF_DEVICEINTERFACE flag and use the
	/// ClassGuid parameter to supply the class GUID of the device interface class. The function adds to the device information set a
	/// device information element that represents such a device, and then adds a device interface of the specified class to the device
	/// interface list for that device information element.
	/// </item>
	/// </list>
	/// <para>
	/// In addition, you can use the following filtering options to control whether <c>SetupDiGetClassDevsEx</c> returns only devices
	/// that support the system default interface for device interface classes:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// To return only the device that supports the system default interface, if one is set, for a specified device interface class, set
	/// the DIGCF_DEVICEINTERFACE flag, set the DIGCF_DEFAULT flag, and use ClassGuid to supply the class GUID of the device interface
	/// class. The function adds to the device information set a device information element that represents such a device, and then adds
	/// the system default interface to the device interface list for that device information element.
	/// </item>
	/// <item>
	/// To return a device that supports a system default interface for an unspecified device interface class, set the
	/// DIGCF_DEVICEINTERFACE flag, set the DIGCF_ALLCLASSES flag, set the DIGCF_DEFAULT flag, and set ClassGuid to <c>NULL</c>. The
	/// function adds to the device information set a device information element that represents such a device, and then adds the system
	/// default interface to the device interface list for that device information element.
	/// </item>
	/// </list>
	/// <para>You can also use the following options in combination with the other options to further restrict which devices are returned.</para>
	/// <list type="bullet">
	/// <item>To return only devices that are present in the system, set the DIGCF_PRESENT flag.</item>
	/// <item>To return only devices that are part of the current hardware profile, set the DIGCF_PROFILE flag.</item>
	/// <item>
	/// To return only a specific device, set the DIGCF_DEVICEINTERFACE flag and use the Enumerator parameter to supply the device
	/// instance ID of the device. To include all possible devices, set Enumerator to <c>NULL</c>.
	/// </item>
	/// </list>
	/// <para>Retrieving Devices in a Device Setup Class That Support a Device Interface Class</para>
	/// <para>
	/// An installer can use <c>SetupDiGetClassDevsEx</c> to retrieve a list of devices of a particular device setup class that support
	/// a device interface of a specified device interface class. For example, to retrieve a list of all devices on a local computer
	/// that support a device interface in the "mounted device" interface class and that are members of the "Volume" device setup class,
	/// an installer should perform the following operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// Call SetupDiCreateDeviceInfoList to create an empty device information set for the "Volume" device setup class. Set ClassGuid to
	/// a pointer to the class GUID for the "Volume" device setup class and set hwndParent as appropriate. In response to such a call,
	/// the function will return a handle to type HDEVINFO to the device information set.
	/// </item>
	/// <item>
	/// <para>Call <c>SetupDiGetClassDevsEx</c> with the following settings:</para>
	/// <list type="bullet">
	/// <item>Set ClassGuid to a pointer to the class GUID of the "mounted device" device interface class.</item>
	/// <item>Set Flags to DIGCF_DEVICEINTERFACE.</item>
	/// <item>Set DeviceInfoSet to the HDEVINFO handle obtained in step (1).</item>
	/// <item>Set hwndParent as appropriate and the remaining parameters to NULL.</item>
	/// </list>
	/// </item>
	/// </list>
	/// <para>
	/// In an operation of this type, <c>SetupDiGetClassDevsEx</c> returns a device if the device setup class of the device is the same
	/// as the supplied device information set and if the device supports a device interface whose class is the same as the specified
	/// device interface class.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsexa WINSETUPAPI HDEVINFO
	// SetupDiGetClassDevsExA( const GUID *ClassGuid, PCSTR Enumerator, HWND hwndParent, DWORD Flags, HDEVINFO DeviceInfoSet, PCSTR
	// MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassDevsExA")]
	public static extern SafeHDEVINFO SetupDiGetClassDevsEx([In, Optional] IntPtr ClassGuid, [In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? Enumerator,
		[In, Optional] HWND hwndParent, DIGCF Flags, [In, Optional] HDEVINFO DeviceInfoSet,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>The <c>SetupDiGetClassImageIndex</c> function retrieves the index within the class image list of a specified class.</summary>
	/// <param name="ClassImageListData">
	/// A pointer to an SP_CLASSIMAGELIST_DATA structure that describes a class image list that includes the image for the device setup
	/// class that is specified by the ClassGuid parameter.
	/// </param>
	/// <param name="ClassGuid">
	/// A pointer to the GUID of the device setup class for which to retrieve the index of the class image in the specified class image list.
	/// </param>
	/// <param name="ImageIndex">
	/// A pointer to an INT-typed variable that receives the index of the specified class image in the class image list.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// If the specified device setup class is not included in the specified class image list, <c>SetupDiGetClassImageIndex</c> returns
	/// the image index for the Unknown device setup class in the ImageIndex parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassimageindex WINSETUPAPI BOOL
	// SetupDiGetClassImageIndex( PSP_CLASSIMAGELIST_DATA ClassImageListData, const GUID *ClassGuid, PINT ImageIndex );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassImageIndex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassImageIndex(in SP_CLASSIMAGELIST_DATA ClassImageListData, in Guid ClassGuid, out int ImageIndex);

	/// <summary>
	/// The <c>SetupDiGetClassImageList</c> function builds an image list that contains bitmaps for every installed class and returns
	/// the list in a data structure.
	/// </summary>
	/// <param name="ClassImageListData">
	/// A pointer to an SP_CLASSIMAGELIST_DATA structure to receive information regarding the class image list, including a handle to
	/// the image list. The <c>cbSize</c> field of this structure must be initialized with the size of the structure, in bytes, before
	/// calling this function or it will fail.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The image list built by this function should be destroyed by calling SetupDiDestroyClassImageList.</para>
	/// <para>Call SetupDiGetClassImageListEx to retrieve the image list for classes installed on a remote computer.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassimagelist WINSETUPAPI BOOL
	// SetupDiGetClassImageList( PSP_CLASSIMAGELIST_DATA ClassImageListData );
	[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassImageList")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassImageList(ref SP_CLASSIMAGELIST_DATA ClassImageListData);

	/// <summary>
	/// The <c>SetupDiGetClassImageListEx</c> function builds an image list of bitmaps for every class installed on a local or remote system.
	/// </summary>
	/// <param name="ClassImageListData">
	/// A pointer to an SP_CLASSIMAGELIST_DATA structure to receive information regarding the class image list, including a handle to
	/// the image list. The <c>cbSize</c> field of this structure must be initialized with the size of the structure, in bytes, before
	/// calling this function or it will fail.
	/// </param>
	/// <param name="MachineName">
	/// A pointer to NULL-terminated string that supplies the name of a remote system for whose classes <c>SetupDiGetClassImageListEx
	/// must build</c> the bitmap. This parameter is optional and can be <c>NULL</c>. If MachineName is <c>NULL</c>,
	/// <c>SetupDiGetClassImageListEx</c> builds the list for the local system.
	/// </param>
	/// <param name="Reserved">Must be <c>NULL</c>.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// by a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The image list built by this function should be destroyed by calling SetupDiDestroyClassImageList.</para>
	/// <para>
	/// <c>Note</c> Class-specific icons on a remote computer can only be displayed if the class is also present on the local computer.
	/// Thus, if the remote computer has class X, but class X is not installed locally, then the generic (unknown) icon will be returned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassimagelistexa WINSETUPAPI BOOL
	// SetupDiGetClassImageListExA( PSP_CLASSIMAGELIST_DATA ClassImageListData, PCSTR MachineName, PVOID Reserved );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassImageListExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassImageListEx(ref SP_CLASSIMAGELIST_DATA ClassImageListData,
		[In, Optional, MarshalAs(UnmanagedType.LPTStr)] string? MachineName, [In, Optional] IntPtr Reserved);

	/// <summary>
	/// The <c>SetupDiGetClassInstallParams</c> function retrieves class installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to a device information set that contains the class install parameters to retrieve.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specified a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetClassInstallParams</c> retrieves the class
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiGetClassInstallParams</c>
	/// retrieves the class install parameters for the global class driver list that is associated with DeviceInfoSet.
	/// </param>
	/// <param name="ClassInstallParams">
	/// A pointer to a buffer that contains an SP_CLASSINSTALL_HEADER structure. This structure must have its <c>cbSize</c> member set
	/// to <c>sizeof(</c> SP_CLASSINSTALL_HEADER <c>)</c> on input or the buffer is considered to be invalid. On output, the
	/// <c>InstallFunction</c> member is filled with the device installation function code for the class installation parameters being
	/// retrieved. If the buffer is large enough, it also receives the class installation parameters structure specific to the function
	/// code. If ClassInstallParams is not specified, ClassInstallParamsSize must be 0.
	/// </param>
	/// <param name="ClassInstallParamsSize">
	/// The size, in bytes, of the ClassInstallParams buffer. If the buffer is supplied, it must be at least as large as <c>sizeof(</c>
	/// SP_CLASSINSTALL_HEADER <c>)</c>. If the buffer is not supplied, ClassInstallParamsSize must be 0.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of bytes required to store the class install parameters. This
	/// parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// The class install parameters are specific to a particular device installation function code that is stored in the
	/// <c>ClassInstallHeader</c> field located at the beginning of the ClassInstallParams buffer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetClassInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_CLASSINSTALL_HEADER
	// ClassInstallParams, DWORD ClassInstallParamsSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassInstallParams(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
		[In, Optional] IntPtr ClassInstallParams, uint ClassInstallParamsSize, out uint RequiredSize);

	/// <summary>
	/// The <c>SetupDiGetClassInstallParams</c> function retrieves class installation parameters for a device information set or a
	/// particular device information element.
	/// </summary>
	/// <param name="DeviceInfoSet">A handle to a device information set that contains the class install parameters to retrieve.</param>
	/// <param name="DeviceInfoData">
	/// A pointer to an SP_DEVINFO_DATA structure that specified a device information element in DeviceInfoSet. This parameter is
	/// optional and can be <c>NULL</c>. If this parameter is specified, <c>SetupDiGetClassInstallParams</c> retrieves the class
	/// installation parameters for the specified device. If this parameter is <c>NULL</c>, <c>SetupDiGetClassInstallParams</c>
	/// retrieves the class install parameters for the global class driver list that is associated with DeviceInfoSet.
	/// </param>
	/// <param name="ClassInstallParams">
	/// A pointer to a buffer that contains an SP_CLASSINSTALL_HEADER structure. This structure must have its <c>cbSize</c> member set
	/// to <c>sizeof(</c> SP_CLASSINSTALL_HEADER <c>)</c> on input or the buffer is considered to be invalid. On output, the
	/// <c>InstallFunction</c> member is filled with the device installation function code for the class installation parameters being
	/// retrieved. If the buffer is large enough, it also receives the class installation parameters structure specific to the function
	/// code. If ClassInstallParams is not specified, ClassInstallParamsSize must be 0.
	/// </param>
	/// <param name="ClassInstallParamsSize">
	/// The size, in bytes, of the ClassInstallParams buffer. If the buffer is supplied, it must be at least as large as <c>sizeof(</c>
	/// SP_CLASSINSTALL_HEADER <c>)</c>. If the buffer is not supplied, ClassInstallParamsSize must be 0.
	/// </param>
	/// <param name="RequiredSize">
	/// A pointer to a variable of type DWORD that receives the number of bytes required to store the class install parameters. This
	/// parameter is optional and can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// The function returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c> and the logged error can be retrieved
	/// with a call to GetLastError.
	/// </returns>
	/// <remarks>
	/// The class install parameters are specific to a particular device installation function code that is stored in the
	/// <c>ClassInstallHeader</c> field located at the beginning of the ClassInstallParams buffer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassinstallparamsa WINSETUPAPI BOOL
	// SetupDiGetClassInstallParamsA( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, PSP_CLASSINSTALL_HEADER
	// ClassInstallParams, DWORD ClassInstallParamsSize, PDWORD RequiredSize );
	[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetClassInstallParamsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetupDiGetClassInstallParams(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData,
		[In, Optional] IntPtr ClassInstallParams, uint ClassInstallParamsSize, out uint RequiredSize);

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDEVINFO"/> that is disposed using <see cref="SetupDiDestroyDeviceInfoList"/>.</summary>
	public class SafeHDEVINFO : SafeHANDLE
	{
		private readonly Lazy<SP_DEVINFO_LIST_DETAIL_DATA> detail;

		/// <summary>Initializes a new instance of the <see cref="SafeHDEVINFO"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHDEVINFO(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) => detail = new Lazy<SP_DEVINFO_LIST_DETAIL_DATA>(GetDetail);

		/// <summary>Initializes a new instance of the <see cref="SafeHDEVINFO"/> class.</summary>
		private SafeHDEVINFO() : base() => detail = new Lazy<SP_DEVINFO_LIST_DETAIL_DATA>(GetDetail);

		/// <summary>
		/// If the device information set is for a remote computer, this member is a configuration manager machine handle for the remote
		/// computer. If the device information set is for the local computer, this member is <c>HANDLE.NULL</c>.
		/// </summary>
		public HANDLE MachineHandle => detail.Value.RemoteMachineHandle;

		/// <summary>
		/// A string that contains the name of the remote computer. If the device information set is for the local computer, this member
		/// is <see langword="null"/>.
		/// </summary>
		public string? MachineName => detail.Value.RemoteMachineName == "" ? null : detail.Value.RemoteMachineName;

		/// <summary>
		/// The setup class GUID that is associated with the device information set or <see langword="null"/> if there is no associated
		/// setup class.
		/// </summary>
		public Guid? ClassGuid => detail.Value.ClassGuid == Guid.Empty ? null : detail.Value.ClassGuid;

		/// <summary>
		/// Returns a handle to a device information set that contains requested device information elements for a local or a remote computer.
		/// </summary>
		/// <param name="classGuid">
		/// The GUID for a device setup class or a device interface class. This value is optional and can be <c>NULL</c>. If a GUID
		/// value is not used to select devices, set ClassGuid to <c>NULL</c>.
		/// </param>
		/// <param name="pnpFilter">
		/// <para>A pointer to a NULL-terminated string that specifies:</para>
		/// <list type="bullet">
		/// <item>
		/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier
		/// (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names
		/// for PnP enumerators include "USB", "PCMCIA", and "SCSI".
		/// </item>
		/// <item>
		/// A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter
		/// </item>
		/// </list>
		/// <para>
		/// This pointer is optional and can be NULL. If an Enumerator value is not used to select devices, set Enumerator to NULL.
		/// </para>
		/// </param>
		/// <param name="flags">
		/// <para>
		/// A value that specifies control options that filter the device information elements that are added to the device information set.
		/// </para>
		/// </param>
		/// <param name="machineName">
		/// A string that contains the name of a remote computer on which the devices reside. A value of <c>NULL</c> for MachineName
		/// specifies that the device is installed on the local computer.
		/// </param>
		/// <returns>
		/// If the operation succeeds, <c>SetupDiGetClassDevsEx</c> returns a handle to a device information set that contains all
		/// installed devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE.
		/// To get extended error information, call GetLastError.
		/// </returns>
		/// <remarks>See <see cref="SetupDiGetClassDevsEx(in Guid, string, HWND, DIGCF, HDEVINFO, string, IntPtr)"/> for more detail.</remarks>
		public static SafeHDEVINFO Create(Guid? classGuid, DIGCF flags = DIGCF.DIGCF_PRESENT, string? pnpFilter = null, string? machineName = null)
		{
			if (classGuid.HasValue)
				return Win32Error.ThrowLastErrorIfInvalid(SetupDiGetClassDevsEx(classGuid.Value, pnpFilter, default, flags, default, machineName));
			else
				return Win32Error.ThrowLastErrorIfInvalid(SetupDiGetClassDevsEx(IntPtr.Zero, pnpFilter, default, flags, default, machineName));
		}

		/// <summary>
		/// Creates an empty device information set on a remote or a local computer and optionally associates the set with a device
		/// setup class.
		/// </summary>
		/// <param name="classGuid">
		/// The GUID of the device setup class to associate with the newly created device information set. If this parameter is
		/// specified, only devices of this class can be included in this device information set. If this parameter is set to <see
		/// langword="null"/> the device information set is not associated with a specific device setup class.
		/// </param>
		/// <param name="machineName">
		/// A string that contains the name of a computer on a network. If a name is specified, only devices on that computer can be
		/// created and opened in this device information set. If this parameter is set to <see langword="null"/>, the device
		/// information set is for devices on the local computer.
		/// </param>
		/// <returns>A handle to an empty device information set.</returns>
		/// <remarks>
		/// If the device information set is for devices on a remote computer (MachineName is not <c>NULL</c>), all subsequent
		/// operations on this set or any of its elements must use routines that support device information sets with remote elements.
		/// The <c>SetupDi</c> Xxx routines that do not provide this support, such as SetupDiCallClassInstaller, have a statement to
		/// that effect in their reference page.
		/// </remarks>
		public static SafeHDEVINFO CreateEmpty(Guid? classGuid = null, string? machineName = null)
		{
			if (classGuid.HasValue)
				return Win32Error.ThrowLastErrorIfInvalid(SetupDiCreateDeviceInfoListEx(classGuid.Value, default, machineName));
			else
				return Win32Error.ThrowLastErrorIfInvalid(SetupDiCreateDeviceInfoListEx(IntPtr.Zero, default, machineName));
		}

		/// <summary>Performs an implicit conversion from <see cref="SafeHDEVINFO"/> to <see cref="HDEVINFO"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDEVINFO(SafeHDEVINFO h) => h.handle;

		/// <summary>Adjusts the current handle to include additional requested device information elements.</summary>
		/// <param name="classGuid">
		/// The GUID for a device setup class or a device interface class. This value is optional and can be <c>NULL</c>. If a GUID
		/// value is not used to select devices, set ClassGuid to <c>NULL</c>.
		/// </param>
		/// <param name="pnpFilter">
		/// <para>A pointer to a NULL-terminated string that specifies:</para>
		/// <list type="bullet">
		/// <item>
		/// An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the enumerator's globally unique identifier
		/// (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP enumerator. Other examples of symbolic names
		/// for PnP enumerators include "USB", "PCMCIA", and "SCSI".
		/// </item>
		/// <item>
		/// A PnP device instance IDs. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter
		/// </item>
		/// </list>
		/// <para>
		/// This pointer is optional and can be NULL. If an Enumerator value is not used to select devices, set Enumerator to NULL.
		/// </para>
		/// </param>
		/// <param name="flags">
		/// <para>
		/// A value that specifies control options that filter the device information elements that are added to the device information set.
		/// </para>
		/// </param>
		/// <returns>
		/// If the operation succeeds, <c>SetupDiGetClassDevsEx</c> returns a handle to a device information set that contains all
		/// installed devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE.
		/// To get extended error information, call GetLastError.
		/// </returns>
		/// <remarks>See <see cref="SetupDiGetClassDevsEx(in Guid, string, HWND, DIGCF, HDEVINFO, string, IntPtr)"/> for more detail.</remarks>
		public void Adjust(Guid? classGuid, DIGCF flags = DIGCF.DIGCF_ALLCLASSES, string? pnpFilter = null)
		{
			SafeHDEVINFO hNew;
			if (classGuid.HasValue)
				hNew = SetupDiGetClassDevsEx(classGuid.Value, pnpFilter, default, flags, handle, MachineName);
			else
				hNew = SetupDiGetClassDevsEx(IntPtr.Zero, pnpFilter, default, flags, handle, MachineName);
			Win32Error.ThrowLastErrorIfInvalid(hNew);
			SetHandle(hNew.handle);
			hNew.SetHandleAsInvalid();
		}

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => SetupDiDestroyDeviceInfoList(handle);

		private SP_DEVINFO_LIST_DETAIL_DATA GetDetail()
		{
			SP_DEVINFO_LIST_DETAIL_DATA data = new() { cbSize = IntPtr.Size == 4 ? 550U : (uint)Marshal.SizeOf(typeof(SP_DEVINFO_LIST_DETAIL_DATA)) };
			Win32Error.ThrowLastErrorIfFalse(SetupDiGetDeviceInfoListDetail(handle, ref data));
			return data;
		}
	}
}