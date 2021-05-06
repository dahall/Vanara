using System;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the SetupAPI.dll</summary>
	public static partial class SetupAPI
	{
		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_AdditionalSoftwareRequested = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 19);

		/// <summary>
		/// <para>The DEVPKEY_Device_Address device property represents the bus-specific address of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Address</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_ADDRESS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_Address to the address of the device on its bus. For information about the
		/// interpretation of a device address, see the <c>DevicePropertyAddress</c> value of the DeviceProperty parameter of <c>IoGetDeviceProperty</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Address.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Address property
		/// key. Instead, you can use the corresponding SPDRP_ADDRESS identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-address
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Address = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 30);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_AssignedToGuest = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 24);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_BaseContainerId device property represents the GUID value of the base container identifier (ID) .The Windows
		/// Plug and Play (PnP) manager assigns this value to the device node (devnode).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_BaseContainerId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_BASE_CONTAINERID</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The PnP manager determines the container ID for a devnode by using one of the following methods:</para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>For more information about these methods, see How Container IDs are Generated.</para>
		/// <para>
		/// Regardless of how the container ID value is obtained, the PnP manager assigns the value to the DEVPKEY_Device_BaseContainerId
		/// property of the devnode.
		/// </para>
		/// <para>
		/// The DEVPKEY_Device_BaseContainerId property can be used to force the grouping of a new devnode with other devnodes that exists
		/// in the system. This lets you use the new devnode as the parent (or base) container ID for other related devnodes. To do this,
		/// you must first obtain the DEVPKEY_Device_BaseContainerID GUID of the existing devnode. Then, you must return the container ID
		/// GUID of the new devnode in response to an <c>IRP_MN_QUERY_ID</c> query request that has the <c>Parameters.QueryId.IdType</c>
		/// field set to <c>BusQueryContainerID</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> The value that is returned by a query of the DEVPKEY_Device_BaseContainerId or <c>DEVPKEY_Device_ContainerId</c>
		/// properties can be different for the same devnode.
		/// </para>
		/// <para>
		/// <c>Note</c> Do not use the DEVPKEY_Device_BaseContainerId property to reconstruct device container groupings in the system. Use
		/// the <c>DEVPKEY_Device_ContainerId</c> property instead.
		/// </para>
		/// <para>For more information about container IDs, see Container IDs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-basecontainerid
		[CorrespondingType(typeof(Guid), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_BaseContainerId = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 38);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_BiosDeviceName = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 10);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_BusNumber device property represents the number that identifies the bus instance that a device instance is
		/// attached to.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_BusNumber</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_BUSNUMBER</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_BusNumber to the value of the BusNumber member of the <c>PNP_BUS_INFORMATION</c>
		/// structure that a bus driver returns in response to an <c>IRP_MN_QUERY_BUS_INFORMATION</c> request.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_BusNumber.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_BusNumber
		/// property key. Instead, you can use the corresponding SPDRP_BUSNUMBER identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-busnumber
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_BusNumber = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 23);

		/// <summary>
		/// <para>The DEVPKEY_Device_BusRelations device property represents the <c>bus relations</c> for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_BusRelations</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_BusRelations.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-busrelations
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_BusRelations = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 7);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_BusReportedDeviceDesc device property represents a string value that was reported by the bus driver for the
		/// device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_BusReportedDeviceDesc</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_BusReportedDeviceDesc is set by Windows Plug and Play (PnP) with the string value that is reported
		/// by the bus driver for a device instance. The bus driver returns this value when queried with <c>IRP_MN_QUERY_DEVICE_TEXT</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_BusReportedDeviceDesc.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-busreporteddevicedesc
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_BusReportedDeviceDesc = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 4);

		/// <summary>
		/// <para>The DEVPKEY_Device_BusTypeGuid device property represents the GUID that identifies the bus type of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_BusTypeGuid</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_BUSTYPEGUID</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_BusTypeGuid to the value of the BusTypeGuid member of the <c>PNP_BUS_INFORMATION</c>
		/// structure that a bus driver returns in response to an <c>IRP_MN_QUERY_BUS_INFORMATION</c> request.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_BusTypeGuid.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_BusTypeGuid
		/// property key. Instead, you can use the corresponding SPDRP_BUSTYPEGUID identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-bustypeguid
		[CorrespondingType(typeof(Guid), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_BusTypeGuid = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 21);

		/// <summary>
		/// <para>The DEVPKEY_Device_Capabilities device property represents the capabilities of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Capabilities</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_CAPABILITIES</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_Capabilities to the capability value that the device driver returns in response to an
		/// <c>IRP_MN_QUERY_CAPABILITIES</c> request for device capability information. The value of DEVPKEY_Device_Capabilities is a
		/// bitwise OR of the CM_DEVCAP_Xxx capability flags that are defined in Cfgmgr32.h. The device capabilities that these flags
		/// represent correspond to a subset of the members of the <c>DEVICE_CAPABILITIES</c> structure.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Capabilities.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Capabilities
		/// property key. Instead, you can use the corresponding SPDRP_CAPABILITIES identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-capabilities
		[CorrespondingType(typeof(CM_DEVCAP), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Capabilities = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 17);

		/// <summary>
		/// <para>The DEVPKEY_Device_Characteristics device property represents the characteristics of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Characteristics</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_CHARACTERISTICS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_Characteristics is a bitwise OR of the FILE_Xxx file characteristic flags that are defined in Wdm.h
		/// and Ntddk.h. For more information about the device characteristic flags, see the DeviceCharacteristics parameter of
		/// <c>IoCreateDevice</c> and Specifying Device Characteristics.
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_Device_Characteristics by using an <c>INF AddReg directive</c> that is included in the <c>INF
		/// DDInstall.HW section</c> that installs a device.
		/// </para>
		/// <para>You can retrieve the value of DEVPKEY_Device_Characteristics by calling <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Characteristics
		/// property key. Instead, you can use the corresponding SPDRP_CHARACTERISTICS identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-characteristics
		[CorrespondingType(typeof(CM_FILE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Characteristics = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 29);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Children device property represents a list of the device instance IDs for the devices that are children of a
		/// device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Children</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Children.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-children
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Children = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 9);

		/// <summary></summary>
		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Class device property represents the name of the device setup class that a device instance belongs to.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Class</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_CLASS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of the DEVPKEY_Device_Class property is set by the class-name value that is supplied by the Class directive in the
		/// <c>INF Version section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Class.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Class property
		/// key. Instead, you can use the corresponding SPDRP_CLASS identifier to access the value of the property on these earlier versions
		/// of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing Device
		/// Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-class
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Class = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 9);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_ClassGuid device property represents the GUID of the device setup class that a device instance belongs to.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ClassGuid</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_CLASSGUID</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_ClassGuid is set by the INF ClassGUID directive that is supplied by the <c>INF Version section</c>
		/// of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_ClassGuid.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_ClassGuid
		/// property key. Instead, you can use the corresponding SPDRP_CLASSGUID identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-classguid
		[CorrespondingType(typeof(Guid), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ClassGuid = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 10);

		/// <summary>
		/// <para>The DEVPKEY_DEVICE_CompatibleIds device property represents the list of compatible identifiers for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_CompatibleIds</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Internal data format</term>
		/// <term>"compatible-id1\0compatible-id2\0...compatible-idn\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_COMPATIBLEIDS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DEVICE_CompatibleIds is set by the compatible-id entry values that are supplied for a device in the <c>INF
		/// Models section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_DEVICE_CompatibleIds.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_CompatibleIds
		/// property key. Instead, you can use the corresponding SPDRP_COMPATIBLEIDS identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-compatibleids
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_CompatibleIds = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 4);

		/// <summary>
		/// <para>The DEVPKEY_Device_ConfigFlags device property represents the configuration flags that are set for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ConfigFlags</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_CONFIGFLAGS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_ConfigFlags is set during a device installation to indicate the current configuration of a device.
		/// </para>
		/// <para>The configuration flags are for internal use only.</para>
		/// <para>
		/// You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_ConfigFlags and call
		/// <c>SetupDiSetDeviceProperty</c> to set DEVPKEY_Device_ConfigFlags.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-configflags
		[CorrespondingType(typeof(CONFIGFLAG))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ConfigFlags = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 12);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ConfigurationId = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 7);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_ContainerId device property is used by the Plug and Play (PnP) manager to group one or more device nodes
		/// (devnodes) into a device container that represents an instance of a physical device.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ContainerId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7, the PnP manager uses the device container and its identifier (ContainerID) to group one or more
		/// devnodes that originated from and belong to each instance of a particular physical device. The ContainerID for a device instance
		/// is referenced through the DEVPKEY_Device_ContainerId device property.
		/// </para>
		/// <para>
		/// When you group all the devnodes that originated from an instance of a single device into containers, you accomplish the
		/// following results:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>
		/// The DEVPKEY_Device_ContainerId can be used to determine the device container grouping of devnodes in a system. For a given
		/// devnode, you can determine all the devnodes that belong to the same container by completing the following steps:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// </list>
		/// <para><c>Note</c> All devnodes that belong to a container on a given bus type must share the same ContainerID value.</para>
		/// <para>For more information about ContainerIDs, see Container IDs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-containerid
		[CorrespondingType(typeof(Guid), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ContainerId = new(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c, 2);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_DebuggerSafe = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 12);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_DependencyDependents = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 21);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_DependencyProviders = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 20);

		/// <summary>
		/// <para>The DEVPKEY_Device_DeviceDesc device property represents a description of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DeviceDesc</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_DEVICEDESC</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DeviceDesc is set by the device-description entry value that is supplied by the <c>INF Models
		/// section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_DEVICE_DeviceDesc.</para>
		/// <para>
		/// You can retrieve the value of the <c>DEVPKEY_NAME</c> device instance property to retrieve the name of the device as it should
		/// appear in a user interface item.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DeviceDesc
		/// property key. Instead, these earlier versions of Windows use the corresponding SPDRP_DEVICEDESC identifier to access the value
		/// of the property. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-devicedesc
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DeviceDesc = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 2);

		/// <summary>
		/// <para>The DEVPKEY_Device_DevNodeStatus device property represents the status of a device node (devnode).</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DevNodeStatus</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The value of DEVPKEY_Device_DevNodeStatus is a bitwise OR of the DN_Xxx bit flags that are defined in Cfg.h.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DevNodeStatus.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to access the
		/// status of a device instance on these earlier versions of Windows, see Retrieving the Status and Problem Code for a Device Instance.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-devnodestatus
		[CorrespondingType(typeof(DN), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DevNodeStatus = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 2);

		/// <summary>
		/// <para>The DEVPKEY_Device_DevType device property represents the device type of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DevType</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_DEVTYPE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_DevType to the value of the DeviceType member of the <c>DEVICE_OBJECT</c> structure for
		/// a device instance. The value of DEVPKEY_Device_DevType is one of the system-defined device type values that are listed in
		/// Specifying Device Types.
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_Device_DevType by using an <c>INF AddReg directive</c> that is included in the <c>INF
		/// DDInstall.HW section</c> in the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DevType.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DevType property
		/// key. Instead, you can use the corresponding SPDRP_DEVTYPE identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-devtype
		[CorrespondingType(typeof(FILE_DEVICE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DevType = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 27);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DHP_Rebalance_Policy device property represents a value that indicates whether a device will participate in
		/// resource rebalancing following a dynamic hardware partitioning (DHP) processor hot-add operation.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DHP_Rebalance_Policy</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by applications and services.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// On a dynamically partitionable server that is running Windows Server 2008 or later versions of Windows Server, the operating
		/// system initiates a system-wide resource rebalance whenever a new processor is dynamically added to the system. The
		/// DEVPKEY_Device_DHP_Rebalance_Policy device property determines whether a device participates in such a resource rebalance. The
		/// device participates in resource rebalancing under the following circumstances:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The DEVPKEY_Device_DHP_Rebalance_Policy device property does not exist.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device property exists and the value of the device property is not set.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device property exists and the value of the device property is set to 2.</para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the DEVPKEY_Device_DHP_Rebalance_Policy device property exists and the value of the property is set to 1, the device will not
		/// participate in resource rebalancing when a new processor is dynamically added to the system.
		/// </para>
		/// <para>A device's device setup class is specified in the <c>INF Version Section</c> of the device's INF file.</para>
		/// <para>
		/// The default behavior for devices in the Network Adapter (Class = Net) device setup class is that members of the class do not
		/// participate in resource rebalancing when a new processor is dynamically added to the system. The default behavior for devices in
		/// all other device setup classes is that members participate in resource rebalancing when a new processor is dynamically added to
		/// the system.
		/// </para>
		/// <para>
		/// This device property does not affect whether a device will participate in a resource rebalance that is initiated for other reasons.
		/// </para>
		/// <para>You can access the DEVPKEY_Device_DHP_Rebalance_Policy property by calling <c>SetupDiGetDeviceProperty</c> and <c>SetupDiSetDeviceProperty</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-dhp-rebalance-policy
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_DHP_Rebalance_Policy = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 2);

		/// <summary>
		/// <para>The DEVPKEY_Device_Driver device property represents the registry entry name of the driver key for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Driver</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_DRIVER</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_Driver after it installs a driver for device.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Driver.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Driver property
		/// key. Instead, you can use the corresponding SPDRP_DRIVER identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driver
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Driver = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 11);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverCoInstallers device property represents a list of DLL names, and entry points in the DLLs, that are
		/// registered as co-installers for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverCoInstallers</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"AbcCoInstall.dll,AbcCoInstallEntryPoint\0...AbcCoInstall.dll, AbcCoInstallEntryPoin\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_COINSTALLERS_32 CoInstallers32</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DriverCoInstallers is supplied by the <c>INF DDInstall.Coinstallers</c> section in the INF file that
		/// installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverCoInstallers.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_DriverCoInstallers property key. On these earlier versions of Windows, you can access the value of this property
		/// by accessing the corresponding <c>CoInstallers32</c> registry value under the software key for the device instance. For
		/// information about how to access this property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-drivercoinstallers
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverCoInstallers = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 11);

		/// <summary>
		/// <para>
		/// The PKEY_Device_DriverDate device property represents the date of the driver that is currently installed for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverDate</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_FILETIME</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_DRIVERDATEDATA DriverDateData</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DriverDate is supplied by the <c>INF DriverVer directive</c> that is included in the <c>INF Version
		/// section</c> of an INF file that installs a device or by a device-specific INF <c>DriverVer</c> directive that is included in the
		/// <c>INF DDInstall section</c> that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverDate property.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DriverDate
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>DriverDateData</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverdate
		[CorrespondingType(typeof(FILETIME), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverDate = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 2);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverDesc device property represents the description of the driver that is installed for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverDesc</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_DRVDESC DriverDesc</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DriverDesc is set by the device-description entry value that is supplied by the <c>INF Models
		/// section</c> of the INF file that installs a device.
		/// </para>
		/// <para>
		/// The value of DEVPKEY_Device_DriverDesc is not displayed in an end-user dialog box or used for any reason by the operating system.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverDesc.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_LocationPaths
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>DriverDesc</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverdesc
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverDesc = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 4);

		/// <summary>
		/// <para>The PKEY_Device_DriverInfPath device property represents the name of the INF file that installed a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverInfPath</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_INFPATH InfPath</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_DriverInfPath. A copy of the INF file that installed a device is located in the system
		/// INF file directory. The name of the INF file copy is OemNnn.inf, where Nnn is a decimal number from 0 through 9999.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverInfPath.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DriverInfPath
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>InfPath</c> registry value under the software key for the device instance. For information about how to access this property
		/// value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverinfpath
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverInfPath = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 5);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverInfSection device property represents the name of the <c>INF DDInstall section</c> that installs the
		/// driver for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverInfSection</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_INFSECTION InfSection</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of the PKEY_Device_DriverInfSection property.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of PKEY_Device_DriverInfSection.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the PKEY_Device_DriverInfSection
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>InfSection</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverinfsection
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverInfSection = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 6);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverInfSectionExt device driver property represents the platform extension of the <c>INF DDInstall
		/// section</c> that installs the driver for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverInfSectionExt</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_INFSECTIONEXT InfSectionExt</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_DriverInfSectionExt.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverInfSectionExt.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_DriverInfSectionExt property key. On these earlier versions of Windows, you can access the value of this property
		/// by accessing the corresponding <c>InfSectionExt</c> registry value under the software key for the device instance. For
		/// information about how to access this property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverinfsectionext
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverInfSectionExt = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 7);

		/// <summary>
		/// <para>The DEVPKEY_Device_DriverLogoLevel device property represents the Microsoft Windows Logo level for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverLogoLevel</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_UINT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_DriverLogoLevel.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverLogoLevel.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverlogolevel
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverLogoLevel = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 15);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverProblemDesc = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 11);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverPropPageProvider device property represents the name of a DLL, and an entry point in the DLL, that is
		/// registered as a property page provider for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverPropPageProvider</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_ENUMPROPPAGES_32 EnumPropPages32</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_Device_DriverPropPageProvider by using an <c>INF AddReg directive</c> that is included the
		/// <c>INF DDInstall section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can retrieve the value of DEVPKEY_Device_DriverPropPageProvider by calling <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_DriverPropPageProvider property key. On these earlier versions of Windows, you can access the value of this
		/// property by accessing the corresponding <c>EnumPropPages32</c> registry value under the software key for the device instance.
		/// For information about how to access this property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverproppageprovider
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverPropPageProvider = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 10);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_DriverProvider device property represents the name of the provider of the driver package for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverProvider</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_PROVIDER_NAME ProviderName</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DriverProvider is supplied by the <c>Provider</c> directive that is included in the <c>INF Version
		/// section</c> of a device INF file.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverProvider.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DriverProvider
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>ProviderName</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverprovider
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverProvider = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 9);

		/// <summary>
		/// <para>The DEVPKEY_Device_DriverRank device property represents the rank of the driver that is installed for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverRank</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_UINT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_DriverRank.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_DriverRank.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DriverRank
		/// property key. For information about how to access this property on these earlier versions of Windows, see Accessing Device
		/// Driver Properties.
		/// </para>
		/// <para>For information about driver rank, see How Windows Ranks Drivers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverrank
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverRank = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 14);

		/// <summary>
		/// <para>
		/// The PKEY_Device_DriverVersion device property represents the version of the driver that is currently installed on a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_DriverVersion</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_DRIVERVERSION DriverVersion</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_DriverVersion is supplied by the <c>INF DriverVer directive</c> that is included in the <c>INF
		/// Version section</c> of an INF file that installs a device or is supplied by a device-specific INF <c>DriverVer</c> directive
		/// that is included in the <c>INF DDInstall section</c> that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of PKEY_Device_DriverVersion.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_DriverVersion
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>DriverVersion</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-driverversion
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_DriverVersion = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 3);

		/// <summary>
		/// <para>The DEVPKEY_Device_EjectionRelations device property represents the <c>ejection relations</c> for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_EjectionRelations</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_EjectionRelations.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-ejectionrelations
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_EjectionRelations = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 4);

		/// <summary>
		/// <para>The DEVPKEY_Device_EnumeratorName device property represents the name of the enumerator for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_EnumeratorName</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_ENUMERATOR_NAME</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_EnumeratorName to the name of the enumerator for a device.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_EnumeratorName.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_EnumeratorName
		/// property key. Instead, you can use the corresponding SPDRP_ENUMERATOR_NAME identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-enumeratorname
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_EnumeratorName = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 24);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Exclusive device property represents a Boolean value that determines whether a device instance can be opened
		/// for exclusive use.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Exclusive</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_EXCLUSIVE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of the DEVPKEY_Device_Exclusive property is DEVPROP_TRUE if the device can be opened for exclusive use. Otherwise, the
		/// value of the property is DEVPROP_FALSE.
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_Device_Exclusive by using an <c>INF AddReg directive</c> that is included in the <c>INF
		/// DDInstall.HW section</c> that installs a device.
		/// </para>
		/// <para>You can retrieve or set the value of DEVPKEY_Device_Exclusive by calling <c>SetupDiGetDeviceProperty</c> and <c>SetupDiSetDeviceProperty</c>.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Exclusive
		/// property key. Instead, you can use the corresponding SPDRP_EXCLUSIVE identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-exclusive
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Exclusive = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 28);

		/// <summary></summary>
		[CorrespondingType(typeof(ulong))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ExtendedAddress = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 23);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ExtendedConfigurationIds = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 15);

		/// <summary></summary>
		[CorrespondingType(typeof(FILETIME))]
		public static readonly DEVPROPKEY DEVPKEY_Device_FirmwareDate = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 17);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_FirmwareRevision = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 19);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_FirmwareVersion = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 18);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_FirstInstallDate device property specifies the time stamp when the device instance was first installed in the system.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_FirstInstallDate</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_FILETIME</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_FirstInstallDate with the time stamp that specifies when the device instance was first
		/// installed in the system.
		/// </para>
		/// <para>
		/// <c>Note</c> Unlike the <c>DEVPKEY_Device_InstallDate</c> property, the value of the DEVPKEY_Device_FirstInstallDate property
		/// does not change with each successive update of the device driver. For example, a driver that was updated through Windows Update
		/// does not change the value of this property,
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_FirstInstallDate property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-firstinstalldate
		[CorrespondingType(typeof(FILETIME), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_FirstInstallDate = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 101);

		/// <summary>
		/// <para>The DEVPKEY_Device_FriendlyName device property represents the friendly name of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_FriendlyName</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_FRIENDLYNAME</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can use the <c>DEVPKEY_NAME</c> device property instead of DEVPKEY_Device_FriendlyName to display the name that identifies a
		/// device instance in a user interface display.
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_Device_FriendlyName by using an <c>INF AddReg directive</c> that is included in the <c>INF
		/// DDInstall.HW section</c> in the INF file that installs a device.
		/// </para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_Device_FriendlyName by calling <c>SetupDiGetDeviceProperty</c> or you can set this
		/// property by calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_FriendlyName
		/// property key. Instead, you can use the corresponding SPDRP_FRIENDLYNAME identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-friendlyname
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_FriendlyName = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 14);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_FriendlyNameAttributes = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 3);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_GenericDriverInstalled device property represents a Boolean value that indicates whether the driver installed
		/// for a device instance provides only basic device functionality.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_GenericDriverInstalled</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_GenericDriverInstalled.</para>
		/// <para>
		/// The value of DEVPKEY_Device_GenericDriverInstalled is set to DEVPROP_TRUE to indicate that a basic driver is installed.
		/// Otherwise, the value of the property is set to DEVPROP_FALSE.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_GenericDriverInstalled.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-genericdriverinstalled
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_GenericDriverInstalled = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 18);

		/// <summary>
		/// <para>The DEVPKEY_DEVICE_HardwareIds device property represents the list of hardware identifiers for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_HardwareIds</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"hw-id1\0hw-id2\0...hw-idn\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_HARDWAREID</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DEVICE_HardwareIds is set by the hw-id entry values for a device that are supplied by the <c>INF Models
		/// section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_DEVICE_HardwareIds.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DEVICE_HardwareIds
		/// property key. Instead, you can use the corresponding SPDRP_HARDWAREID identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-hardwareids
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_HardwareIds = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 3);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_HasProblem = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 6);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_InLocalMachineContainer = new(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c, 4);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_InstallDate device property specifies the time stamp when the device instance was last installed in the system.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_InstallDate</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_FILETIME</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_InstallDate with the time stamp that specifies when the device instance was last
		/// installed in the system.
		/// </para>
		/// <para>
		/// This time stamp value changes for each successive update of the device driver. For example, this time stamp reports the date and
		/// time when the device driver was last updated through Windows Update.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_FirstInstallDate property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-installdate
		[CorrespondingType(typeof(FILETIME), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_InstallDate = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 100);

		/// <summary>
		/// <para>The DEVPKEY_Device_InstallState device property represents the installation state of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_InstallState</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_UINT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_INSTALL_STATE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_InstallState to one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h.
		/// The CM_INSTALL_STATE_Xxx values correspond to the <c>DEVICE_INSTALL_STATE</c> enumeration values.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_InstallState.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_Device_InstallState property key.
		/// Instead, you can use the corresponding SPDRP_INSTALL_STATE identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-installstate
		[CorrespondingType(typeof(CM_INSTALL_STATE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_InstallState = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 36);

		/// <summary>
		/// <para>The DEVPKEY_Device_InstanceId device property represents the device instance identifier of a device.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_InstanceId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The value of DEVPKEY_Device_InstanceId is set internally by Windows during the installation of a device instance.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_InstanceId for a device instance.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_InstanceId
		/// property key. For information about how to retrieve a device instance identifier on these earlier versions of Windows, see
		/// Retrieving a Device Instance Identifier.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-instanceid
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_InstanceId = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 256);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_IsAssociateableByUserAction = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 7);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_IsPresent = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 5);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_IsRebootRequired = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 16);

		/// <summary></summary>
		[CorrespondingType(typeof(FILETIME))]
		public static readonly DEVPROPKEY DEVPKEY_Device_LastArrivalDate = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 102);

		/// <summary></summary>
		[CorrespondingType(typeof(FILETIME))]
		public static readonly DEVPROPKEY DEVPKEY_Device_LastRemovalDate = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 103);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Legacy device property represents a Boolean value that indicates whether a device is a root-enumerated device
		/// that the Plug and Play (PnP) manager automatically created when the non-PnP driver for the device was loaded.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Legacy</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The PnP manager sets the value of DEVPKEY_Device_Reported to DEVPROP_TRUE if the PnP manager automatically created the device as
		/// a root-enumerated device when the non-PnP driver for the device was loaded. Otherwise, the PnP manager sets the value of the
		/// property to DEVPROP_FALSE.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Legacy.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-legacy
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Legacy = new(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e, 3);

		/// <summary>
		/// <para>The DEVPKEY_Device_LegacyBusType device property represents the legacy bus number of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_LegacyBusType</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_LEGACYBUSTYPE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_LegacyBusType to the value of the LegacyBusType member of the
		/// <c>PNP_BUS_INFORMATION</c> structure that a bus driver returns in response to an <c>IRP_MN_QUERY_BUS_INFORMATION</c> request.
		/// The value of DEVPKEY_Device_LegacyBusType is one of <c>INTERFACE_TYPE</c> enumerator values that are defined in Wdm.h and Ntddk.h.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_LegacyBusType.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_LegacyBusType
		/// property key. Instead, you can use the corresponding SPDRP_LEGACYBUSTYPE identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-legacybustype
		[CorrespondingType(typeof(INTERFACE_TYPE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_LegacyBusType = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 22);

		/// <summary>
		/// <para>The DEVPKEY_Device_LocationInfo device property represents the bus-specific physical location of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_LocationInfo</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_LOCATION_INFORMATION</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_LocationInfo to the value that the bus driver returns for a device instance in response
		/// to an <c>IRP_MN_QUERY_DEVICE_TEXT</c> IRP.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> and <c>SetupDiGetDeviceProperty</c> to retrieve and set the value of DEVPKEY_Device_LocationInfo.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_LocationInfo
		/// property key. Instead, you can use the corresponding SPDRP_LOCATION_INFORMATION identifier to access the value of the property
		/// on these earlier versions of Windows. For information about how to access this property value on these earlier versions of
		/// Windows, see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-locationinfo
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_LocationInfo = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 15);

		/// <summary>
		/// <para>The DEVPKEY_Device_LocationPaths device property represents the location of a device instance in the device tree.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_LocationPaths</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_LOCATION_PATHS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Windows sets the value of DEVPKEY_Device_LocationPaths.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_LocationPaths.</para>
		/// <para>
		/// Windows Server 2003 supports this property, but does not support the DEVPKEY_Device_LocationPaths property key. Instead, you can
		/// use the corresponding SPDRP_LOCATION_PATHS identifier to access the value of the property on Windows Server 2003. For
		/// information about how to access this property value on Windows Server 2003, see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-locationpaths
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_LocationPaths = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 37);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_LowerFilters device property represents a list of the service names of the lower-level filter drivers that
		/// are installed for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_LowerFilters</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_LOWERFILTERS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of the DEVPKEY_Device_LowerFilters property is set when a lower-level device filter driver is installed for a device.
		/// For more information about how to install a device filter driver, see Installing a Filter Driver.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> and <c>SetupDiSetDeviceProperty</c> to retrieve and set the value of DEVPKEY_Device_LowerFilters.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_LowerFilters
		/// property key. Instead, you can use the corresponding SPDRP_LOWERFILTERS identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-lowerfilters
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_LowerFilters = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 20);

		/// <summary>
		/// <para>The DEVPKEY_DEVICE_Manufacturer device property represents the name of the manufacturer of a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Manufacturer</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_MFG</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DEVICE_Manufacturer is set by the manufacturer-identifier entry value for a device that is supplied by the
		/// <c>INF Manufacturer section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_DEVICE_Manufacturer.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Manufacturer
		/// property key. Instead, you can use the corresponding SPDRP_MFG identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-manufacturer
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Manufacturer = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 13);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ManufacturerAttributes = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 4);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_MatchingDeviceId device property represents the hardware ID or compatible ID that Windows uses to install a
		/// device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_MatchingDeviceId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_MATCHINGDEVICEID MatchingDeviceId</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_MatchingDeviceId. The hardware IDs and compatible IDs for a device are supplied by the
		/// device-description entries that are included in the <c>INF Models section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of PKEY_Device_MatchingDeviceId.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_MatchingDeviceId
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>MatchingDeviceId</c> registry value under the software key for the device instance. For information about how to access this
		/// property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-matchingdeviceid
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_MatchingDeviceId = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 8);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Model = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 39);

		/// <summary>
		/// <para>The DEVPKEY_Device_ModelId device property matches a device to a device metadata package.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ModelId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The DEVPKEY_Device_ModelId device property provides support for IHVs and OEMs to uniquely identify devices that share the same
		/// manufacturer and model. By using a model identifier (ModelID), OEMs and IHVs can match the device model that they distribute to
		/// their own branded device metadata package.
		/// </para>
		/// <para>
		/// The DEVPKEY_Device_ModelId device property contains the value of the <c>ModelID</c> XML element from the device's metadata
		/// package. When the device is installed, this PKEY is populated with the ModelID GUID value as reported by the device.
		/// </para>
		/// <para>For more information, see Device Metadata Packages.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-modelid
		[CorrespondingType(typeof(Guid))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ModelId = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 2);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_NoConnectSound device property represents a Boolean value that indicates whether to suppress the sound that
		/// the Microsoft Windows operating system plays to indicate that a removable device arrived or was removed.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_NoConnectSound</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_NoConnectSound is set to DEVPROP_TRUE to suppress playing sound. Otherwise, the value of the
		/// property is set to DEVPROP_FALSE.
		/// </para>
		/// <para>
		/// The DEVPKEY_Device_NoConnectSound property is typically set by an <c>INF AddProperty directive</c> in the INF file for a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> or <c>SetupDiSetDeviceProperty</c> to retrieve or set the value of DEVPKEY_Device_NoConnectSound.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-noconnectsound
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_NoConnectSound = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 17);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Numa_Node = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 3);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Numa_Proximity_Domain = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 1);

		/// <summary>
		/// <para>The DEVPKEY_Device_Parent device property represents the device instance identifier of the parent for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Parent</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Parent property.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-parent
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Parent = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 8);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_PDOName device property represents the name of the physical device object (PDO) that represents a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_PDOName</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_PHYSICAL_DEVICE_OBJECT_NAME</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_PDOName to the name of the physical name object (PDO) that represents a device. For
		/// more information about PDO names, see the DeviceName parameter that is used with the <c>IoCreateDevice</c> routine.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_PDOName.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_PDOName property
		/// key. Instead, you can use the corresponding SPDRP_PHYSICAL_DEVICE_OBJECT_NAME identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-pdoname
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_PDOName = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 16);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_PhysicalDeviceLocation device property encapsulates the physical device location information provided by a
		/// device's firmware to Windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_PhysicalDeviceLocation</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BINARY</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_PHYSICAL_DEVICE_LOCATION</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_PhysicalDeviceLocation with the physical device location information. The format of the
		/// information is defined in the ACPI 4.0a Specification, section 6.1.6.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_PhysicalDeviceLocation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-physicaldevicelocation
		[CorrespondingType(typeof(byte[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_PhysicalDeviceLocation = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 9);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_PostInstallInProgress = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 13);

		/// <summary>
		/// <para>The DEVPKEY_Device_PowerData device property represents power information about a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_PowerData</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BINARY</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_DEVICE_POWER_DATA</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_PowerData. The value of DEVPKEY_Device_PowerData contains a <c>CM_POWER_DATA</c> structure.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_PowerData.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_PowerData
		/// property key. Instead, you can use the corresponding SPDRP_DEVICE_POWER_DATA identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-powerdata
		[CorrespondingType(typeof(CM_POWER_DATA), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_PowerData = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 32);

		/// <summary>
		/// <para>The DEVPKEY_Device_PowerRelations device property represents the <c>power relations</c> for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_PowerRelations</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_PowerRelations.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-powerrelations
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_PowerRelations = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 6);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_PresenceNotForDevice = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 5);

		/// <summary>
		/// <para>The DEVPKEY_Device_ProblemCode device property represents the problem code for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ProblemCode</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The value of DEVPKEY_Device_ProblemCode is one of the CM_PROB_Xxx problem codes that are defined in Cfg.h.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_ProblemCode.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to access the
		/// problem code for a device instance on these earlier versions of Windows, see Retrieving the Status and Problem Code for a Device Instance.
		/// </para>
		/// <para>
		/// For info on finding problem status in Device Manager or the kernel debugger, see Retrieving the Status and Problem Code for a
		/// Device Instance.
		/// </para>
		/// <para>For additional information that may help with the problem code, see <c>DEVPKEY_Device_ProblemStatus</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-problemcode
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ProblemCode = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 3);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_ProblemStatus device property is an NTSTATUS value that is set when a problem code is generated. It provides
		/// more context on why the problem code was set. If no additional context is available, ProblemStatus shows as STATUS_SUCCESS (0x00000000).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ProblemStatus</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_NTSTATUS</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For info on finding problem status in Device Manager or the kernel debugger, see Retrieving the Status and Problem Code for a
		/// Device Instance.
		/// </para>
		/// <para>For more info about NTSTATUS values, see Using NTSTATUS Values.</para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_ProblemStatus.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-problemstatus
		[CorrespondingType(typeof(NTStatus), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ProblemStatus = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 12);

		/// <summary>
		/// <para>The DEVPKEY_Device_RemovalPolicy device property represents the current removal policy for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_RemovalPolicy</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_REMOVAL_POLICY</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_RemovalPolicy to one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_RemovalPolicy property.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_Device_RemovalPolicy property key.
		/// Instead, you can use the corresponding SPDRP_REMOVAL_POLICY identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-removalpolicy
		[CorrespondingType(typeof(CM_REMOVAL_POLICY), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_RemovalPolicy = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 33);

		/// <summary>
		/// <para>The DEVPKEY_Device_RemovalPolicyDefault device property represents the default removal policy for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_RemovalPolicyDefault</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_REMOVAL_POLICY_HW_DEFAULT</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_RemovalPolicyDefault to one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_RemovalPolicyDefault.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_Device_RemovalPolicyDefault property
		/// key. Instead, you can use the corresponding SPDRP_REMOVAL_POLICY_HW_DEFAULT identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-removalpolicydefault
		[CorrespondingType(typeof(CM_REMOVAL_POLICY), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_RemovalPolicyDefault = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 34);

		/// <summary>
		/// <para>The DEVPKEY_Device_RemovalPolicyOverride device property represents the removal policy override for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_RemovalPolicyOverride</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_REMOVAL_POLICY_OVERRIDE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>The value of DEVPKEY_Device_RemovalPolicyOverride is one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.</para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_Device_RemovalPolicyOverride by calling <c>SetupDiGetDeviceProperty</c> or you can also
		/// set this value by calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_Device_RemovalPolicyOverride property
		/// key. Instead, you can use the corresponding SPDRP_REMOVAL_POLICY_OVERRIDE identifier to access the value of the property on
		/// these earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows,
		/// see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-removalpolicyoverride
		[CorrespondingType(typeof(CM_REMOVAL_POLICY))]
		public static readonly DEVPROPKEY DEVPKEY_Device_RemovalPolicyOverride = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 35);

		/// <summary>
		/// <para>The DEVPKEY_Device_RemovalRelations device property represents the <c>removal relations</c> for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_RemovalRelations</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_RemovalRelations.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-removalrelations
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_RemovalRelations = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 5);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Reported device property represents a Boolean value that indicates whether a device instance is a
		/// root-enumerated device that the driver for the device reported to the Plug and Play (PnP) manager by calling <c>IoReportDetectedDevice</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Reported</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The PnP manager sets the value of DEVPKEY_Device_Reported to DEVPROP_TRUE if the device is a root-enumerated device that the
		/// driver for the device reported to the PnP manager by calling IoReportDetectedDevice. Otherwise, the PnP manager sets the value
		/// of the property to DEVPROP_FALSE.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Reported.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-reported
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Reported = new(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e, 2);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ReportedDeviceIdsHash = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 8);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_ResourcePickerExceptions device property represents the resource conflicts that are allowed for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ResourcePickerExceptions</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_RESOURCE_PICKER_EXCEPTIONS ResourcePickerExceptions</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_Device_ResourcePickerExceptions by using an <c>INF AddReg directive</c> that is included in the
		/// <c>INF DDInstall section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can retrieve the value of DEVPKEY_Device_ResourcePickerExceptions by calling <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_ResourcePickerExceptions property key. On these earlier versions of Windows, you can access the value of this
		/// property by accessing the corresponding <c>ResourcePickerExceptions</c> registry value under the software key for the device
		/// instance. For information about how to access this property value on these earlier versions of Windows, see Accessing Device
		/// Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-resourcepickerexceptions
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ResourcePickerExceptions = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 13);

		/// <summary>
		/// <para>The DEVPKEY_Device_ResourcePickerTags device property represents resource picker tags for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_ResourcePickerTags</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value identifier and registry value name</term>
		/// <term>REGSTR_VAL_RESOURCE_PICKER_TAGS ResourcePickerTags</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_Device_ResourcePickerTags by using an <c>INF AddReg directive</c> that is included in the
		/// <c>INF DDInstall section</c> of the INF file that installs a device.
		/// </para>
		/// <para>You can retrieve the value of PKEY_Device_ResourcePickerTags by calling <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_ResourcePickerTags property key. On these earlier versions of Windows, you can access the value of this property
		/// by accessing the corresponding <c>ResourcePickerTags</c> registry value under the software key for the device instance. For
		/// information about how to access this property value on these earlier versions of Windows, see Accessing Device Driver Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-resourcepickertags
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_ResourcePickerTags = new(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 12);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_SafeRemovalRequired device property represents a Boolean value that indicates whether a hot-plug device
		/// instance requires safe removal from the computer.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_SafeRemovalRequired</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If this property for a hot-plug device instance has a value of DEVPROP_TRUE, the device instance requires safe removal from the
		/// computer. In this case, Windows displays the <c>Safely Remove Hardware</c> icon in the notification area on the right side of
		/// the taskbar. When the user clicks this icon, the system starts the <c>Safely Remove Hardware</c> program. By using this program,
		/// the user can instruct the system to prepare the device instance for removal before it can be surprise-removed from the computer.
		/// </para>
		/// <para>
		/// <c>Note</c> If the device instance is a removable media device, such as an optical disk drive, the device instance must have
		/// media inserted and must have the DEVPKEY_Device_SafeRemovalRequired property value of DEVPROP_TRUE. If both are true, the device
		/// instance is displayed in the <c>Safely Remove Hardware</c> program.
		/// </para>
		/// <para>
		/// Windows Plug and Play (PnP) determines that the hot-plug device instance requires safe removal from the system if the following
		/// are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The device instance is currently connected to the system.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device instance is either started or can be ejected automatically by the system.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// The CM_DEVCAP_SURPRISEREMOVALOK device capability bit for the device instance is not set. For more information about device
		/// capabilities, see <c>SetupDiGetDeviceRegistryProperty</c>.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device instance does not have the <c>DEVPKEY_Device_SafeRemovalRequiredOverride</c> device property set to DEVPROP_FALSE.</para>
		/// <para>
		/// <c>Note</c> PnP unconditionally determines that the hot-plug device requires safe removal if the
		/// DEVPKEY_Device_SafeRemovalRequiredOverride device property is set to DEVPROP_TRUE.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// The device instance is either directly removable from its parent device instance or has a removable ancestor in its device tree.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_SafeRemovalRequired.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-saferemovalrequired
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_SafeRemovalRequired = new(0xafd97640, 0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55, 2);

		/// <summary>
		/// <para>The DEVPKEY_Device_SafeRemovalRequiredOverride device property represents the safe removal override for the device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_SafeRemovalRequiredOverride</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This device property can be used to override the result of the heuristic that Windows Plug and Play (PnP) uses to calculate the
		/// value of the <c>DEVPKEY_Device_SafeRemovalRequired</c> device property. This override is performed as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SafeRemovalRequiredOverride device property is set to DEVPROP_TRUE and the device instance is removable or
		/// has a removable ancestor, PnP sets the DEVPKEY_Device_SafeRemovalRequired device property to DEVPROP_TRUE and does not use the heuristic.
		/// </para>
		/// <para>
		/// <c>Note</c> A device instance is considered removable if its removable device capability is set. For more information, see
		/// Overview of the Removable Device Capability.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SafeRemovalRequiredOverride device property is set to DEVPROP_TRUE and the device instance (or an
		/// ancestor) is not removable, PnP sets the DEVPKEY_Device_SafeRemovalRequired to DEVPROP_FALSE and does not use the heuristic.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SafeRemovalRequiredOverride device property is either not set or set to DEVPROP_FALSE, PnP sets the
		/// DEVPKEY_Device_SafeRemovalRequired device property to a value that is determined by using the heuristic.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You can retrieve the value of DEVPKEY_Device_SafeRemovalRequiredOverride by calling <c>SetupDiGetDeviceProperty</c>. You can
		/// also set this value by calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-saferemovalrequiredoverride
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_SafeRemovalRequiredOverride = new(0xafd97640, 0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55, 3);

		/// <summary>
		/// <para>The DEVPKEY_Device_Security device property represents a security descriptor structure for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Security</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_SECURITY_DESCRIPTOR</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_SECURITY</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_Device_Security by using an <c>INF AddReg directive</c> that is included in the <c>INF
		/// DDInstall.HW section</c> of the INF file that installs a device.
		/// </para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_Device_Security by calling <c>SetupDiGetDeviceProperty</c> or you can set this property by
		/// calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Security property
		/// key. Instead, you can use the corresponding SPDRP_SECURITY identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-security
		[CorrespondingType(typeof(byte[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Security = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 25);

		/// <summary>
		/// <para>The DEVPKEY_Device_SecuritySDS device property represents a security descriptor string for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_SecuritySDS</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_SECURITY_SDS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can retrieve the value of DEVPKEY_Device_SecuritySDS by calling <c>SetupDiGetDeviceProperty</c> or you can also set his
		/// value by calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_SecuritySDS
		/// property key. Instead, you can use the corresponding SPDRP_SECURITY_SDS identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-securitysds
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_SecuritySDS = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 26);

		/// <summary>
		/// <para>The DEVPKEY_Device_Service device property represents the name of the service that is installed for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Service</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_SERVICE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_Device_Service is set by the service-name entry value that is supplied by the <c>INF AddService
		/// directive</c> in the INF file that installs a service for a device.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Service.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_Service property
		/// key. Instead, you can use the corresponding SPDRP_SERVICE identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-service
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Service = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 6);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_SessionId device property represents a value that indicates the Terminal Services sessions that a device
		/// instance can be accessed in.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_SessionId</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_UINT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by applications and services.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The Terminal Server feature supports Plug and Play (PnP) device redirection. Device redirection determines whether a device can
		/// be accessed by applications and services within all Terminal Services sessions or whether a device can be accessed only within a
		/// particular Terminal Services session. The accessibility of a device within a Terminal Services session is determined by the
		/// setting of DEVPKEY_Device_SessionId for a device, as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SessionId property does not exist, or the property exists, but the value of the property is not set, the
		/// device can be accessed in all active Terminal Services sessions.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SessionId property exists and the value of the property is set to a nonzero Terminal Services l session
		/// identifier, the device can be accessed only in the Terminal Services session indicated by the Terminal Services session identifier.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the DEVPKEY_Device_SessionId property exists and the value of the property is set to zero, the device can be accessed only by
		/// services. Session zero is a special session in which only services can run.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>You can access the DEVPKEY_Device_SessionId property by calling <c>SetupDiGetDeviceProperty</c> and <c>SetupDiSetDeviceProperty</c>.</para>
		/// <para>Windows Server 2003, Windows XP, and Windows 2000 do not support this property.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-sessionid
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_Device_SessionId = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 6);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_ShowInUninstallUI = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 8);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_Siblings device property represents a list of the device instance IDs for the devices that are siblings of a
		/// device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_Siblings</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Not applicable</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_Siblings.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support this property. For information about how to retrieve
		/// device relations properties on these earlier versions of Windows, see Retrieving Device Relations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-siblings
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_Siblings = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 10);

		/// <summary></summary>
		[CorrespondingType(typeof(int))]
		public static readonly DEVPROPKEY DEVPKEY_Device_SignalStrength = new(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 6);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_Device_SoftRestartSupported = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 22);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_Stack = new(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 14);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_TransportRelations = new(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 11);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_UINumber device property represents a number for the device instance that can be displayed in a user
		/// interface item.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_UINumber</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_UI_NUMBER</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Windows sets the value of DEVPKEY_Device_UINumber to the value of the UINumber member of the <c>DEVICE_CAPABILITIES</c>
		/// structure for a device instance. The bus driver for a device instance returns this value in response to an
		/// <c>IRP_MN_QUERY_CAPABILITIES</c> request.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> to retrieve the value of DEVPKEY_Device_UINumber.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_UINumber property
		/// key. Instead, you can use the corresponding SPDRP_UI_NUMBER identifier to access the value of the property on these earlier
		/// versions of Windows. For information about how to access this property value on these earlier versions of Windows, see Accessing
		/// Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-uinumber
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_Device_UINumber = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 18);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_UINumberDescFormat device property represents a <c>printf</c>-compatible format string that you should use to
		/// display the value of the DEVPKEY_DEVICE_UINumber device property for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_UINumberDescFormat</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_UI_NUMBER_DESC_FORMAT</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can retrieve the value of DDEVPKEY_Device_UINumberDescFormat by calling <c>SetupDiGetDeviceProperty</c> or you can also set
		/// this value by calling <c>SetupDiSetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_Device_UINumberDescFormat property key. Instead, you can use the corresponding SPDRP_UI_NUMBER_DESC_FORMAT identifier to
		/// access the value of the property on these earlier versions of Windows. For information about how to access this property value
		/// on these earlier versions of Windows, see Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-uinumberdescformat
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_Device_UINumberDescFormat = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 31);

		/// <summary>
		/// <para>
		/// The DEVPKEY_Device_UpperFilters device property represents a list of the service names of the upper-level filter drivers that
		/// are installed for a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_Device_UpperFilters</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPDRP_Xxx identifier</term>
		/// <term>SPDRP_UPPERFILTERS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of the DEVPKEY_Device_UpperFilters property is set when an upper-level device filter driver is installed for a device.
		/// For more information about how to install a device filter driver, see Installing a Filter Driver.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceProperty</c> and <c>SetupDiGetDeviceProperty</c> to retrieve and set the value of DEVPKEY_Device_UpperFilters.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_Device_UpperFilters
		/// property key. Instead, you can use the corresponding SPDRP_UPPERFILTERS identifier to access the value of the property on these
		/// earlier versions of Windows. For information about how to access this property value on these earlier versions of Windows, see
		/// Accessing Device Instance SPDRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-device-upperfilters
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_Device_UpperFilters = new(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 19);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_Characteristics device property represents the default device characteristics of all devices in a device
		/// setup class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_Characteristics</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_INT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers after a device setup class is installed</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_CHARACTERISTICS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// DEVPKEY_DeviceClass_Characteristics should only be set when a device setup class is installed and not modified later. For
		/// information about how to install a device setup class and setting this property, see <c>INF ClassInstall32 Section</c> and the
		/// information about the registry entry value <c>DeviceCharacteristics</c> that is provided in the "Special value-entry-name
		/// Keywords" section of <c>INF AddReg Directive</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_Characteristics.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_DeviceClass_Characteristics property
		/// key. On these earlier versions of Windows, you can use the SPCRP_CHARACTERISTICS identifier to access the value of this
		/// property. For information about how to access the value of this property, see Retrieving Device Setup Class SPCRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-characteristics
		[CorrespondingType(typeof(CM_FILE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_Characteristics = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 29);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_ClassCoInstallers device property represents a list of the class co-installers that are installed for a
		/// device setup class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_ClassCoInstallers</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"coinstaller1.dll,coinstaller1-entry-point\0…coinstallerN.dll,coinstallerN-entry-point\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>HLM\System\CurrentControlSet\Control\CoDeviceInstallers{device-setup-class-guid}</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>Each class installer in the class co-installer list is identified by its DLL and entry point.</para>
		/// <para>For information about how to install a class co-installer, see Registering a Class Co-installer.</para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_DeviceClass_ClassCoInstallers by calling <c>SetupDiGetClassProperty</c> or
		/// <c>SetupDiGetClassPropertyEx</c>. You can set DEVPKEY_DeviceClass_ClassCoInstallers by calling <c>SetupDiSetClassProperty</c> or <c>SetupDiSetClassPropertyEx</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_ClassCoInstallers property key. For information about how to access the corresponding information on these
		/// earlier versions of Windows, see Accessing the Co-installers Registry Entry Value of a Device Setup Class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-classcoinstallers
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_ClassCoInstallers = new(0x713d1703, 0xa2e2, 0x49f5, 0x92, 0x14, 0x56, 0x47, 0x2e, 0xf3, 0xda, 0x5c, 2);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_ClassInstaller device property represents the class installer for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_ClassInstaller</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"class-installer.dll,class-entry-point"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>Installer32</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_ClassInstaller is the value of the <c>Installer32</c> registry value under the class registry
		/// key. This entry contains the name of the class installer DLL and the installer's entry point for the device setup class.
		/// </para>
		/// <para>
		/// The <c>Installer32</c> registry value for a device setup class can be set by an <c>INF AddReg directive</c> that is included in
		/// the <c>INF ClassInstall32 Section</c> of the INF file that installs a device setup class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_ClassInstaller.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_ClassInstaller property key. You can access the value of this property by accessing the corresponding
		/// <c>Installer32</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-classinstaller
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_ClassInstaller = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 5);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_ClassName device property represents the class name of a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_ClassName</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_ClassName is set by the <c>Class</c> directive that is included in the <c>INF Version
		/// section</c> that installs the device setup class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_ClassName.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_ClassName
		/// property key. For information about how to access the name of a device setup class on Windows Server 2003, Windows XP, and
		/// Windows 2000, see Accessing the Friendly Name and Class Name of a Device Setup Class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-classname
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_ClassName = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 3);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_DefaultService device property represents the name of the default service for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_DefaultService</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>Default Service</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If a default service is installed for a device setup class and a device does not install a device-specific service, the <c>INF
		/// ClassInstall32.Services section</c> of the INF file that installs the class installs the class default service for the device.
		/// </para>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_DefaultService is the value of the <c>Default Service</c> registry value under the class
		/// registry key.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_DefaultService.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_DefaultService property key. You can access the value of this property by accessing the corresponding
		/// <c>Default Service</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-defaultservice
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_DefaultService = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 11);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_DevType device property represents the default device type for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_DevType</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_UINT32</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers after a device setup class is installed</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_DEVTYPE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_DeviceClass_DevType when an installation application installs a device setup class. For
		/// information about how to install a device setup class and setting this property, see <c>INF ClassInstall32 Section</c> and the
		/// information about the registry entry value <c>DeviceType</c> that is provided in the "Special value-entry-name Keywords" section
		/// of <c>INF AddReg Directive</c>.
		/// </para>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_DevType is one of the FILE_DEVICE_Xxx values that are defined in Wdm.h and Ntddk.h. For more
		/// information about device types, see the DeviceType parameter of the <c>IoCreateDevice</c> function.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_DevType.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_DeviceClass_DevType property key. On
		/// these earlier versions of Windows, you can use the SPCRP_DEVTYPE identifier to access the value of this property. For
		/// information about how to access the value of this property, see Retrieving Device Setup Class SPCRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-devtype
		[CorrespondingType(typeof(FILE_DEVICE), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_DevType = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 27);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_DHPRebalanceOptOut device property represents a value that indicates whether an entire device class will
		/// participate in resource rebalancing after a dynamic hardware partitioning (DHP) processor hot-add operation has occurred.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_DHPRebalanceOptOut</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by applications and services.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// <para><c>Remarks</c></para>
		/// <para>
		/// On a dynamically partitionable server that is running Windows Server 2008 or later versions of Windows Server, the operating
		/// system initiates a system-wide resource rebalance whenever a new processor is dynamically added to the system. The device class
		/// participates in resource rebalancing under the following circumstances:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The DEVPKEY_DeviceClass_DHPRebalanceOptOut device property does not exist.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device property exists and the value of the device property is not set.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The device property exists and the value of the device property is set to <c>FALSE</c>.</para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the DEVPKEY_DeviceClass_DHPRebalanceOptOut device property exists and the value of the property is set to <c>TRUE</c>, the
		/// device class does not participate in resource rebalancing when a new processor is dynamically added to the system.
		/// </para>
		/// <para>A device's device setup class is specified in the <c>INF Version Section</c> of the device's INF file.</para>
		/// <para>
		/// The default value for this property for the Network Adapter (Class = Net) is <c>TRUE</c>. The default value for this property
		/// for all other device setup classes is <c>FALSE</c>.
		/// </para>
		/// <para>
		/// This device property does not affect whether a device class participates in a resource rebalance that is initiated for other reasons.
		/// </para>
		/// <para>You can access the DEVPKEY_DeviceClass_DHPRebalanceOptOut property by calling <c>SetupDiGetClassProperty</c> and <c>SetupDiSetClassProperty</c>.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-dhprebalanceoptout
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_DHPRebalanceOptOut = new(0xd14d3ef3, 0x66cf, 0x4ba2, 0x9d, 0x38, 0x0d, 0xdb, 0x37, 0xab, 0x47, 0x01, 2);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_Exclusive device property represents a Boolean flag that indicates whether devices that are members of a
		/// device setup class are exclusive devices.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_Exclusive</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers after a device setup class is installed</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_EXCLUSIVE</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_DeviceClass_Exclusive when an installation application installs a device setup class. For
		/// information about how to install a device setup class and setting this property, see <c>INF ClassInstall32 Section</c> and the
		/// information about the registry value <c>Exclusive</c> that is provided in the "Special value-entry-name Keywords" section of
		/// <c>INF AddReg Directive</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_Exclusive.</para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_DeviceClass_Exclusive property key. On
		/// these earlier versions of Windows, you can use the SPCRP_EXCLUSIVE identifier to access the value of this property. For
		/// information about how to access the value of this property, see Retrieving Device Setup Class SPCRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-exclusive
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_Exclusive = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 28);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_Icon device property represents the icon for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_Icon</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_Icon is set by an <c>INF AddReg directive</c> that is included in the <c>INF ClassInstall32
		/// section</c> that installs the class. To set the value of DEVPKEY_DeviceClass_Icon, use an <c>AddReg</c> directive to set the
		/// <c>Icon</c> registry entry value for the class.
		/// </para>
		/// <para>
		/// The <c>Icon</c> entry value is an integer number in string format. If the number is negative, the absolute value of the number
		/// is the resource identifier of the icon in setupapi.dll. If the number is positive, the number is the resource identifier of the
		/// icon in the class installer DLL, if there is a class installer, or the class property page provider, if there is no class
		/// installer and there is a property page provider. A value of zero is not valid.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_Icon.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_Icon
		/// property key. For information about how to access the mini-icon for a device setup class on Windows Server 2003, Windows XP, and
		/// Windows 2000, see Accessing Icon Properties of a Device Setup Class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-icon
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_Icon = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 4);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_IconPath device property represents an icon list for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_IconPath</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>IconPath</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_IconPath.</para>
		/// <para>
		/// A DEVPKEY_DeviceClass_IconPath value is a REG_MULTI_SZ-typed list of icon resource specifiers in the format that is used by the
		/// Windows shell. The format of an icon resource specifier is "executable-file-path,resource-identifier," where
		/// executable-file-path contains the fully qualified path of the file on a computer that contains the icon resource and
		/// resource-identifier specifies an integer that identifies the resource. For example, the icon resource specifier
		/// "%SystemRoot%\system32\DLL1.dll,-12" contains the executable file path "%SystemRoot%\system32\DLL1.dll" and the resource
		/// identifier "-12".
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not support this property. For information about how to access icon
		/// information for a device setup class on these versions of Windows, see Accessing Icon Properties of a Device Setup Class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-iconpath
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_IconPath = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 12);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_LowerFilters device property represents a list of the service names of the lower-level filter drivers
		/// that are installed for a device setup class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_LowerFilters</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"service-name1\0service-name2\0…service-nameN\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers after a class filter is installed</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_LOWERFILTERS</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>LowerFilters</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_LowerFilters is set when a class filter driver is installed. For more information about how to
		/// install a class filter driver, see Installing a Filter Driver and <c>INF ClassInstall32 Section</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_LowerFilters.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_LowerFilters
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>LowerFilters</c> registry value under the class registry key. For information about how to access this property value on
		/// these earlier versions of Windows, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-lowerfilters
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_LowerFilters = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 20);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_Name device property represents the friendly name of a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_Name</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_Name is set by an <c>INF AddReg directive</c> that is included in the <c>INF ClassInstall32
		/// section</c> that installs the class. To set the friendly name for a class, use an <c>AddReg</c> directive to set the
		/// <c>(Default)</c> registry entry value for the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_Name.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_Name
		/// property key. For information about how to access the friendly name of a device setup class on Windows Server 2003, Windows XP,
		/// and Windows 2000, see Accessing the Friendly Name and Class Name of a Device Setup Class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-name
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_Name = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 2);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_NoDisplayClass device property represents a Boolean flag that controls whether devices in a device setup
		/// class are displayed by the Device Manager.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_NoDisplayClass</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>NoDisplayClass</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value of DEVPKEY_DeviceClass_NoDisplayClass is set to DEVPROP_TRUE, Device Manager does not display devices in the device
		/// setup class. If this value is not set to DEVPROP_TRUE, the Device Manager does display devices in the device setup class.
		/// </para>
		/// <para>
		/// The <c>NoDisplayClass</c> registry value for a device setup class can be set by an <c>INF AddReg directive</c> that is included
		/// in the <c>INF ClassInstall32 section</c> of the INF file that installs the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_NoDisplayClass.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_NoDisplayClass property key. You can access the value of this property by accessing the corresponding
		/// <c>NoDisplayClass</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-nodisplayclass
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_NoDisplayClass = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 8);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_NoInstallClass device setup class property represents a Boolean flag that controls whether devices in a
		/// device setup class are displayed in the <c>Add Hardware Wizard</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_NoInstallClass</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>NoInstallClass</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Setting the value of DEVPKEY_DeviceClass_NoInstallClass to DEVPROP_TRUE indicates that installation of devices in the class does
		/// not require end-user interaction. If this value is not set to DEVPROP_TRUE, the Add Hardware Wizard does display devices for the
		/// device setup class.
		/// </para>
		/// <para>
		/// The <c>NoInstallClass</c> registry value for a device setup class can be set by an <c>INF AddReg directive</c> that is included
		/// in the <c>INF ClassInstall32 section</c> of the INF file that installs the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_NoInstallClass.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_NoInstallClass property key. You can access the value of this property by accessing the corresponding
		/// <c>NoInstallClass</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-noinstallclass
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_NoInstallClass = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 7);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_NoUseClass device property represents a Boolean flag that controls whether the Plug and Play (PnP)
		/// manager and SetupAPI use the device setup class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_NoUseClass</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>NoUseClass</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value of DEVPKEY_DeviceClass_NoUseClass is set to <c>1</c>, the PnP manager and SetupAPI do not use the device setup
		/// class. Otherwise, they do use the device setup class.
		/// </para>
		/// <para>
		/// The <c>NoUseClass</c> registry value for a device setup class is set by an <c>INF AddReg directive</c> that is included in the
		/// <c>INF ClassInstall32 section</c> of the INF file that installs the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_NoUseClass.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_NoUseClass
		/// property key. You can access the value of this property by accessing the corresponding <c>NoUseClass</c> registry value under
		/// the class registry key. For information about how to access value entries under the class registry key, see Accessing Registry
		/// Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-nouseclass
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_NoUseClass = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 10);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_PropPageProvider device property represents the property page provider for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_PropPageProvider</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"prop-provider.dll,provider-entry-point"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>EnumPropPages32</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_PropPageProvider is the value of the <c>EnumPropPages32</c> registry value under the class
		/// registry key. This value contains the name of the class property page provider DLL and the provider's entry point for the device
		/// setup class.
		/// </para>
		/// <para>
		/// The <c>EnumPropPages32</c> registry value for a device setup class can set by an <c>INF AddReg directive</c> that is included in
		/// the <c>INF ClassInstall32 section</c> of the INF file that installs the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_PropPageProvider.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_PropPageProvider property key. You can access the value of this property by accessing the corresponding
		/// <c>EnumPropPages32</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-proppageprovider
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_PropPageProvider = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 6);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_Security device property represents a security descriptor structure for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_Security</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_SECURITY_DESCRIPTOR</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_SECURITY</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_DeviceClass_Security either during or after an installation application installs a device setup
		/// class. For more information about how to set this property, see Creating Secure Device Installations.
		/// </para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_DeviceClass_Security by calling <c>SetupDiGetClassProperty</c> or
		/// <c>SetupDiGetClassPropertyEx</c>. You can set DEVPKEY_DeviceClass_Security by calling <c>SetupDiSetClassProperty</c> or <c>SetupDiSetClassPropertyEx</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_DeviceClass_Security property key. On
		/// these earlier versions of Windows, you can use the SPCRP_SECURITY identifier to access the value of this property. For
		/// information about how to access the value of this property, see Retrieving Device Setup Class SPCRP_Xxx Properties and Setting
		/// Device Setup Class SPCRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-security
		[CorrespondingType(typeof(byte[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_Security = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 25);

		/// <summary>
		/// <para>The DEVPKEY_DeviceClass_SecuritySDS device property represents a security descriptor string for a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_SecuritySDS</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_SECURITY_SDS</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_DeviceClass_SecuritySDS either during or after an installation application installs a device
		/// setup class. For more information about how to set this property, see Creating Secure Device Installations.
		/// </para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_DeviceClass_SecuritySDS by calling <c>SetupDiGetClassProperty</c> or
		/// <c>SetupDiGetClassPropertyEx</c>. You can set DEVPKEY_DeviceClass_SecuritySDS by calling <c>SetupDiSetClassProperty</c> or <c>SetupDiSetClassPropertyEx</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003 and Windows XP support this property, but do not support the DEVPKEY_DeviceClass_SecuritySDS property key.
		/// On these earlier versions of Windows, you can use the SPCRP_SECURITY_SDS identifier to access the value of this property. For
		/// information about how to access the value of this property, see Retrieving Device Setup Class SPCRP_Xxx Properties and Setting
		/// Device Setup Class SPCRP_Xxx Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-securitysds
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_SecuritySDS = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 26);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_SilentInstall device property represents a Boolean flag that controls whether devices in a device setup
		/// class should be installed, if possible, without displaying any user interface items.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_SilentInstall</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>SilentInstall</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value of DEVPKEY_DeviceClass_SilentInstall is set to DEVPROP_TRUE, Windows installs a driver for a device without
		/// displaying any user interface items if the driver is already preinstalled in the driver store. Otherwise, Windows does not
		/// suppress the display of user interface items.
		/// </para>
		/// <para>
		/// The <c>SilentInstall</c> registry value for a device setup class can be set by an <c>INF AddReg directive</c> that is included
		/// in the <c>INF ClassInstall32 section</c> of the INF file that installs the class.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_SilentInstall.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceClass_SilentInstall property key. You can access the value of this property by accessing the corresponding
		/// <c>SilentInstall</c> registry value under the class registry key. For information about how to access value entries under the
		/// class registry key, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-silentinstall
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_SilentInstall = new(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 9);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceClass_UpperFilters device property represents a list of the service names of the upper-level filter drivers
		/// that are installed for a device setup class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceClass_UpperFilters</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>"service-name1\0service-name2\0…service-nameN\0\0"</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers after a class filter is installed</term>
		/// </item>
		/// <item>
		/// <term>Corresponding SPCRP_Xxx identifier</term>
		/// <term>SPCRP_UPPERFILTERS</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>UpperFilters</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The value of DEVPKEY_DeviceClass_UpperFilters is set when a class filter driver is installed. For more information about how to
		/// install a class filter driver, see Installing a Filter Driver and <c>INF ClassInstall32 Section</c>.
		/// </para>
		/// <para>You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_DeviceClass_UpperFilters.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceClass_UpperFilters
		/// property key. On these earlier versions of Windows, you can access the value of this property by accessing the corresponding
		/// <c>UpperFilters</c> registry value under the class registry key. For information about how to access this property value on
		/// these earlier versions of Windows, see Accessing Registry Entry Values Under the Class Registry Key.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceclass-upperfilters
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceClass_UpperFilters = new(0x4321918b, 0xf69e, 0x470d, 0xa5, 0xde, 0x4d, 0x88, 0xc7, 0x5a, 0xd2, 0x4b, 19);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Address = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 51);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_AlwaysShowDeviceAsConnected = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 101);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_AssociationArray = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 80);

		/// <summary></summary>
		[CorrespondingType(typeof(Guid))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_BaselineExperienceId = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 78);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Category = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 90);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Category_Desc_Plural = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 92);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Category_Desc_Singular = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 91);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Category_Icon = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 93);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_CategoryGroup_Desc = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 94);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_CategoryGroup_Icon = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 95);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_ConfigFlags = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 105);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_CustomPrivilegedPackageFamilyNames = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 107);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_DeviceDescription1 = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 81);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_DeviceDescription2 = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 82);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_DeviceFunctionSubRank = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 100);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_DiscoveryMethod = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 52);

		/// <summary></summary>
		[CorrespondingType(typeof(Guid))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_ExperienceId = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 89);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_FriendlyName = new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 12288);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_HasProblem = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 83);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Icon = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 57);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_InstallInProgress = new(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 9);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsAuthenticated = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 54);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsConnected = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 55);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsDefaultDevice = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 86);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsDeviceUniquelyIdentifiable = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 79);

		// DE
		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsEncrypted = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 53);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsLocalMachine = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 70);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsMetadataSearchInProgress = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 72);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsNetworkDevice = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 85);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsNotInterestingForDisplay = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 74);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsPaired = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 56);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsRebootRequired = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 108);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsSharedDevice = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 84);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_IsShowInDisconnectedState = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 68);

		/// <summary></summary>
		[CorrespondingType(typeof(FILETIME))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Last_Connected = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 67);

		/// <summary></summary>
		[CorrespondingType(typeof(FILETIME))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Last_Seen = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 66);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_LaunchDeviceStageFromExplorer = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 77);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_LaunchDeviceStageOnDeviceConnect = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 76);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Manufacturer = new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8192);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_MetadataCabinet = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 87);

		/// <summary></summary>
		[CorrespondingType(typeof(byte[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_MetadataChecksum = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 73);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_MetadataPath = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 71);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_ModelName = new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8194);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_ModelNumber = new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8195);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_PrimaryCategory = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 97);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_PrivilegedPackageFamilyNames = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 106);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_RequiresPairingElevation = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 88);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_RequiresUninstallElevation = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 99);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_UnpairUninstall = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 98);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceContainer_Version = new(0x78c34fc8, 0x104a, 0x4aca, 0x9e, 0xa4, 0x52, 0x4d, 0x52, 0x99, 0x6e, 0x57, 65);

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_AlwaysShowDeviceAsConnected = DEVPKEY_DeviceContainer_AlwaysShowDeviceAsConnected;

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceDisplay_Category device property represents one or more functional categories that apply to a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceDisplay_Category</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers.</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Device categories for a physical device are specified through the <c>DeviceCategory</c> XML element in a device metadata
		/// package. Each instance of that device in a system inherits the device categories for that physical device.
		/// </para>
		/// <para>
		/// Each physical device can have one or more functional categories specified in the device metadata package. Each category is used
		/// by Windows Devices and Printers to group the device instance into one of the recognized device categories.
		/// </para>
		/// <para>
		/// Multifunction devices would typically identify multiple functional categories for each hardware function that the device
		/// supports. For example, a multifunction device could identify functional categories for printer, fax, scanner, and removable
		/// storage device functionality.
		/// </para>
		/// <para>
		/// The first functional category string in the <c>DEVPROP_TYPE_STRING_LIST</c> specifies the physical device's primary functional
		/// category. The primary functional category is defined by the independent hardware vendor (IHV) to specify how the device is
		/// advertised, packaged, sold, and ultimately identified by users.
		/// </para>
		/// <para>
		/// If the DEVPKEY_DeviceDisplay_Category device property specifies more than one functional category string, the remaining strings
		/// that follow the first string specifies the physical device's secondary functional categories.
		/// </para>
		/// <para>
		/// The <c>Devices and Printers</c> user interface in Control Panel displays the primary and secondary functional categories of the
		/// device instance. These categories are displayed in the order that is specified in the DEVPKEY_DeviceDisplay_Category device property.
		/// </para>
		/// <para>You can access the DEVPKEY_DeviceDisplay_Category property by calling <c>SetupDiGetDeviceProperty</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-devicedisplay-category
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_Category = DEVPKEY_DeviceContainer_Category;

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_DiscoveryMethod = DEVPKEY_DeviceContainer_DiscoveryMethod;

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_IsNetworkDevice = DEVPKEY_DeviceContainer_IsNetworkDevice;

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_IsNotInterestingForDisplay = DEVPKEY_DeviceContainer_IsNotInterestingForDisplay;

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_IsShowInDisconnectedState = DEVPKEY_DeviceContainer_IsShowInDisconnectedState;

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_RequiresUninstallElevation = DEVPKEY_DeviceContainer_RequiresUninstallElevation;

		/// <summary></summary>
		[CorrespondingType(typeof(bool))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceDisplay_UnpairUninstall = DEVPKEY_DeviceContainer_UnpairUninstall;

		/// <summary>
		/// <para>The DEVPKEY_DeviceInterface_ClassGuid device property represents the GUID that identifies a device interface class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceInterface_ClassGuid</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_GUID</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The format of {device-interface-class} key value is "{nnnnnnnn-nnnn-nnnn-nnnn-nnnnnnnnnnnn}", where each n is a hexadecimal digit.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceInterfaceProperty</c> to retrieve the value of DEVPKEY_DeviceInterface_ClassGuid.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceInterface_ClassGuid property key. For information about how to retrieve the class GUID of a device interface on
		/// these earlier versions of Windows, see the information about how to use <c>SetupDiEnumDeviceInterfaces</c> that is provided in
		/// Accessing Device Interface Properties.
		/// </para>
		/// <para>
		/// For information about how to install and accessing device interfaces, see Device Interface Classes and the <c>INF AddInterface Directive</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceinterface-classguid
		[CorrespondingType(typeof(Guid), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_ClassGuid = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 4);

		/// <summary>
		/// <para>
		/// The <c>DeviceInterfaceEnabled</c> device property represents a Boolean flag that indicates whether a device interface is enabled.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceInterface_Enabled</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the value of DEVPKEY_DeviceInterface_Enabled is DEVPROP_TRUE, the interface is enabled. Otherwise, the interface is not enabled.
		/// </para>
		/// <para>You can call <c>SetupDiGetDeviceInterfaceProperty</c> to retrieve the value of DEVPKEY_DeviceInterface_Enabled.</para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the DEVPKEY_DeviceInterface_Enabled
		/// property key. For information about how to retrieve the activity status of a device interface on these earlier versions of
		/// Windows, see the information about how to use <c>SetupDiEnumDeviceInterfaces</c> that is provided in Accessing Device Interface Properties.
		/// </para>
		/// <para>For more information about device interfaces, see Device Interface Classes and the <c>INF AddInterface Directive</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceinterface-enabled
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_Enabled = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 3);

		/// <summary>
		/// <para>The DEVPKEY_DeviceInterface_FriendlyName device property represents the friendly name of a device interface.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceInterface_FriendlyName</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Corresponding registry value name</term>
		/// <term>FriendlyName</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>FriendlyName</c> registry value for a device interface class is set by an <c>INF AddInterface directive</c> that is
		/// included in the <c>INF DDInstall.Interface section</c> of the INF file that installs a device interface.
		/// </para>
		/// <para>
		/// Windows sets the value of the <c>DEVPKEY_NAME</c> device property for an interface to the value of
		/// DEVPKEY_DeviceInterface_FriendlyName. To identify a device interface in a user interface item, use the value of DEVPKEY_NAME for
		/// the device interface instead of the value of DEVPKEY_DeviceInterface_FriendlyName.
		/// </para>
		/// <para>
		/// You can retrieve the value of the DEVPKEY_DeviceInterface_FriendlyName by calling <c>SetupDiGetDeviceInterfaceProperty</c> and
		/// set it by calling <c>SetupDiSetDeviceInterfaceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceInterface_FriendlyName property key. You can access the value of this property by accessing the corresponding
		/// <c>FriendlyName</c> registry entry value for the device interface. For information about how to access a registry entry value
		/// for a device interface, see Accessing Device Interface Properties.
		/// </para>
		/// <para>For information about device interfaces, see Device Interface Classes and the <c>INF AddInterface Directive</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceinterface-friendlyname
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_FriendlyName = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 2);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_ReferenceString = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 5);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceInterface_Restricted device interface property indicates that the device interface on which it is present and
		/// set to TRUE, should be treated with privileged access by system components that honor the setting.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceInterface_Restricted</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_BOOLEAN</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>You can call <c>SetupDiGetDeviceInterfaceProperty</c> to retrieve the value of DEVPKEY_DeviceInterface_Restricted.</remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceinterface-restricted
		[CorrespondingType(typeof(bool), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_Restricted = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 6);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_SchematicName = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 9);

		/// <summary></summary>
		[CorrespondingType(typeof(string[]))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterface_UnrestrictedAppCapabilities = new(0x026e516e, 0xb814, 0x414b, 0x83, 0xcd, 0x85, 0x6d, 0x6f, 0xef, 0x48, 0x22, 8);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DeviceInterfaceClass_DefaultInterface device property represents the symbolic link name of the default device
		/// interface for a device interface class.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DeviceInterfaceClass_DefaultInterface</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read and write access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>No</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For information about how to install and using device interfaces, see Device Interface Classes and the <c>INF AddInterface Directive</c>.
		/// </para>
		/// <para>
		/// You can retrieve the value of DEVPKEY_DeviceInterfaceClass_DefaultInterface by calling <c>SetupDiGetDeviceInterfaceProperty</c>.
		/// You can set DEVPKEY_DeviceInterfaceClass_DefaultInterface by calling <c>SetupDiSetDeviceInterfaceProperty</c>.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 support this property, but do not support the
		/// DEVPKEY_DeviceInterfaceClass_DefaultInterface property key. For information about how to access the default interface of a
		/// device interface class on these earlier versions of Windows, see Accessing Device Interface Class Properties.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-deviceinterface-defaultinterface
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterfaceClass_DefaultInterface = new(0x14c83a99, 0x0b3f, 0x44b7, 0xbe, 0x4c, 0xa1, 0x78, 0xd3, 0x99, 0x05, 0x64, 2);

		/// <summary></summary>
		[CorrespondingType(typeof(string))]
		public static readonly DEVPROPKEY DEVPKEY_DeviceInterfaceClass_Name = new(0x14c83a99, 0x0b3f, 0x44b7, 0xbe, 0x4c, 0xa1, 0x78, 0xd3, 0x99, 0x05, 0x64, 3);

		/// <summary></summary>
		[CorrespondingType(typeof(uint))]
		public static readonly DEVPROPKEY DEVPKEY_DevQuery_ObjectType = new(0x13673f42, 0xa3d6, 0x49f6, 0xb4, 0xda, 0xae, 0x46, 0xe0, 0xc5, 0x23, 0x7c, 2);

		/// <summary>
		/// <para>The DEVPKEY_DrvPkg_BrandingIcon device property represents a list of icons that associate a device instance with a vendor.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_BrandingIcon</term>
		/// </listheader>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>A branding icon can be specified as an .ico file or as a resource within an executable file.</para>
		/// <para>The format of an icon list is the same as that described for the <c>DEVPKEY_DrvPkg_Icon</c> device property.</para>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_BrandingIcon by an <c>INF AddProperty directive</c> that is included in the <c>INF
		/// DDInstall section</c> of the INF file that installs a device. You can retrieve the value of DEVPKEY_DrvPkg_BrandingIcon by
		/// calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-brandingicon
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_BrandingIcon = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 7);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DrvPkg_DetailedDescription device property represents a detailed description of the capabilities of a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_DetailedDescription</term>
		/// </listheader>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Data format</term>
		/// <term>Limited set of XML tags</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The detailed description string is in XML format. XML format makes it possible for Windows to format the display of the
		/// information based on the following subset of supported Hypertext Markup Language (HTML) tags. The operation of these tags
		/// resembles the operation of HTML tags.
		/// </para>
		/// <para>Heading level tags &lt;h1&gt;, &lt;h2&gt;, &lt;h3&gt;</para>
		/// <para>List tags &lt;ul&gt;, &lt;ol&gt;, &lt;li&gt;</para>
		/// <para>Paragraph tag &lt;p&gt;</para>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_DetailedDescription by an <c>INF AddProperty directive</c> that is included in the
		/// <c>INF DDInstall section</c> of the INF file that installs the device. You can retrieve the value of
		/// DEVPKEY_DrvPkg_DetailedDescription by calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// The following is an example of how to use an INF <c>AddProperty</c> directive to set the value of
		/// DEVPKEY_DrvPkg_DetailedDescription for a device instance that is installed by an INF DDInstall section "SampleDDInstallSection":
		/// </para>
		/// <para>
		/// <code>[SampleDDinstallSection] ... AddProperty=SampleAddPropertySection ... [SampleAddPropertySection] DeviceDetailedDescription,,,,"&lt;xml&gt;&lt;h1&gt;Microsoft DiscoveryCam 530&lt;/h1&gt;&lt;h2&gt;Overview&lt;h2&gt;The Microsoft DiscoveryCam is great.&lt;p&gt;Really.&lt;p&gt;&lt;h2&gt;Features&lt;/h2&gt;The Microsoft DiscoveryCam has three features.&lt;ol&gt;&lt;li&gt;Feature 1&lt;/li&gt;&lt;li&gt;Feature 2&lt;/li&gt;&lt;li&gt;Feature 3&lt;/li&gt;&lt;/ol&gt;&lt;/xml&gt;" ...</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-detaileddescription
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_DetailedDescription = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 4);

		/// <summary>
		/// <para>The DEVPKEY_DrvPkg_DocumentationLink device property represents a URL to the documentation for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_DocumentationLink</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The documentation link URL should be a link to a file that contains information about a device. This property is intended to
		/// provide Web-accessible documentation for a device. The file can be an HTML page, a .pdf file, a .doc file, or other file type.
		/// The only restriction is that all the documentation content must be contained within the URL-specified file. For example, an
		/// *.htm file that is self-contained is valid, an *.htm file that refers to other graphics files is not valid, and an *.mta Web
		/// archive file that contains referenced graphic files is valid.
		/// </para>
		/// <para>
		/// The URL can contain parameters. For example, the following URL contains a <c>prod</c> parameter that supplies the value
		/// "DSC530", a <c>rev</c> parameter that supplies the value "34", and a <c>type</c> parameter that supplies the value "doc":
		/// </para>
		/// <para>
		/// <code>http://www.microsoft.com/redirect?prod=DSC530&amp;rev=34&amp;type=docs</code>
		/// </para>
		/// <para>
		/// Microsoft does not provide Web hosting or redirection for a webpage that is specified by a DEVPKEY_DrvPkg_DocumentationLink
		/// property value. The URL must link to a webpage that is maintained by the driver package provider.
		/// </para>
		/// <para>
		/// When a user clicks the website link that is displayed in Setup-generated end-user dialog box, Windows adds the following
		/// information to the HTTP request that includes the URL supplied by DEVPKEY_DrvPkg_DocumentationLink:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The Windows version, as specified by a <c>pver</c> parameter. For example, "pver=6.0" specifies Windows Vista.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// The stock keeping unit (SKU), as specified by the <c>sbp</c> parameter, which can be set to per or pro. For example, "sbp=pro"
		/// specifies the professional edition.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// The local identifier (LCID), as specified by the <c>olcid</c> parameter. For example, "olcid=0x409" specifies the English
		/// (Standard) language.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// The most specific hardware identifier for a device, as specified by the <c>pnpid</c> parameter. For example,
		/// "pnpid=PCI%5CVEN_8086%26DEV_2533%26SUBSYS_00000000%26REV_04" specifies the hardware identifier for a PCI device.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>For privacy reasons, user information and the serial number of device is not included in the HTTP request.</para>
		/// <para>
		/// <code>The following example shows the type of HTTP request that would be sent to a web server: http://www.microsoft.com/redirect?prod=DSC530&amp;rev34&amp;type=docs&amp;pver=6.0&amp;spb=pro&amp;olcid=0x409&amp;pnpid=PCI%5CVEN_8086%26DEV_2533%26SUBSYS_00000000%26REV_04</code>
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_DocumentationLink by an <c>INF AddProperty directive</c> that is included in the <c>INF
		/// DDInstall section</c> of the INF file that installs the device. You can retrieve the value of
		/// DEVPKEY_DrvPkg_DocumentationLinkproperty by calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// The following is an example of how to use an INF <c>AddProperty</c> directive to set the value of
		/// DEVPKEY_DrvPkg_DocumentationLink for a device that is installed by an INF DDInstall section "SampleDDInstallSection":
		/// </para>
		/// <para>
		/// <code>[SampleDDinstallSection] ... AddProperty=SampleAddPropertySection ... [SampleAddPropertySection] DeviceDocumentationLink,,,,"http://www.microsoft.com/redirect?prod=DSC530&amp;rev34&amp;type="docs" ...</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-documentationlink
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_DocumentationLink = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 5);

		/// <summary>
		/// <para>
		/// The DEVPKEY_DrvPkg_Icon device property represents a list of device icons that Windows uses to visually represent a device instance.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_Icon</term>
		/// </listheader>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING_LIST</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Each icon in the list is specified by a path of an icon file (*.ico) or a reference to an icon resource in an executable file.
		/// </para>
		/// <para>
		/// The first icon in the list is used as the default. Additional icons can be supplied that provide different visual
		/// representations of a device. Windows includes a user interface that allows a user to select which icon Windows displays. For
		/// example, the Microsoft DiscoveryCam 530 is available in blue, green, and red. Microsoft supplies an icon for each color. Windows
		/// uses the blue icon by default because it is the first one in the list. However, Windows users can also choose the green icon or
		/// the red icon.
		/// </para>
		/// <para>
		/// The icon list is a NULL-separated list of icon specifiers. An icon specifier is either a path of an icon file (*.ico) or an
		/// icon-resource specifier, as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The format of the path to an icon file is DirectoryPath\filename.ico.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>An icon-resource specifier has the following entries:</para>
		/// <para>
		/// The first character of icon-resource specifier is the at sign (@) followed by the path of an executable file (an *.exe or a
		/// *.dll file), followed by a comma separator (,), and then the resource-identifier entry.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For example, the icon specifier"@shell32.dll,-30" represents the executable file "shell32.dll" and the resource identifier "-30".
		/// </para>
		/// <para>A resource identifier must be an integer value, which corresponds to a resource within the executable file, as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>
		/// If the supplied identifier is negative, Windows uses the resource in the executable file whose identifier is equal to the
		/// absolute value of the supplied identifier.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the supplied identifier is zero, Windows uses the resource in the executable file whose identifier has the lowest value in
		/// the execuable file.
		/// </para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>
		/// If the supplied identifier is positive, for example, the value n, Windows uses the resource in the executable file whose
		/// identifier is the n+1 lowest value in the executable file. For example, if the value of n is 1, Windows uses the resource whose
		/// identifier has the second lowest value in the executable file.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_Icon by an <c>INF AddProperty directive</c> that is included in the <c>INF DDInstall
		/// section</c> of the INF file that installs the device. You can retrieve the value of DEVPKEY_DrvPkg_Icon by calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// The following is an example of how to use an INF <c>AddProperty</c> directive to set DEVPKEY_DrvPkg_Icon for a device that is
		/// installed by an INF DDInstall section "SampleDDInstallSection":
		/// </para>
		/// <para>
		/// <code>[SampleDDinstallSection] ... AddProperty=SampleAddPropertySection ... [SampleAddPropertySection] DeviceIcon,,,,"SomeResource.dll,-2","SomeIcon.icon" ...</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-icon
		[CorrespondingType(typeof(string[]), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_Icon = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 6);

		/// <summary>
		/// <para>The DEVPKEY_DrvPkg_Model device driver package property represents the model name for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_Model</term>
		/// </listheader>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_Model by an <c>INF AddProperty directive</c> that is included in the <c>INF DDInstall
		/// section</c> of the INF file that installs the device. You can retrieve the value of the DEVPKEY_DrvPkg_Model property by calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// The following is an example of how to use an INF <c>AddProperty</c> directive to set the value of DEVPKEY_DrvPkg_Model for a
		/// device that is installed by an INF DDInstall section "SampleDDInstallSection":
		/// </para>
		/// <para>
		/// <code>[SampleDDinstallSection] ... AddProperty=SampleAddPropertySection ... [SampleAddPropertySection] DeviceModel,,,,"DSC-530" ...</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-model
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_Model = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 2);

		/// <summary>
		/// <para>The DEVPKEY_DrvPkg_VendorWebSite device property represents a vendor URL for a device instance.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Property key</term>
		/// <term>DEVPKEY_DrvPkg_VendorWebSite</term>
		/// </item>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING"&gt;</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The URL can be a link to the root of the vendor website, a webpage within a website, or a redirection page. The URL can also
		/// contain parameters, for example, the following URL contains a <c>prod</c> parameter that supplies the product identifier
		/// "DSC530" and a <c>rev</c> parameter that supplies the number "34":
		/// </para>
		/// <para>
		/// <code>http://www.microsoft.com/redirect?prod=DSC530&amp;rev=34</code>
		/// </para>
		/// <para>
		/// You can set the value of DEVPKEY_DrvPkg_VendorWebSite by an <c>INF AddProperty directive</c> that is included in the <c>INF
		/// DDInstall section</c> of the INF file that installs the device. You can retrieve the value of DEVPKEY_DrvPkg_VendorWebSite by
		/// calling <c>SetupDiGetDeviceProperty</c>.
		/// </para>
		/// <para>
		/// The following is an example of how to use an INF <c>AddProperty</c> directive to set the DEVPKEY_DrvPkg_VendorWebSite property
		/// value for a device that is installed by an INF DDInstall section "SampleDDInstallSection":
		/// </para>
		/// <para>
		/// <code>[SampleDDinstallSection] ... AddProperty=SampleAddPropertySection ... [SampleAddPropertySection] DeviceVendorWebsite,,,,"http://www.microsoft.com/redirect?prod=DSC530&amp;rev=34" ...</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-drvpkg-vendorwebsite
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_DrvPkg_VendorWebSite = new(0xcf73bb51, 0x3abf, 0x44a2, 0x85, 0xe0, 0x9a, 0x3d, 0xc7, 0xa1, 0x21, 0x32, 3);

		/// <summary>
		/// <para>The DEVPKEY_NAME device property represents the name of a device setup class.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Property key</term>
		/// <term>DEVPKEY_NAME</term>
		/// </listheader>
		/// <item>
		/// <term>Property-data-type identifier</term>
		/// <term>DEVPROP_TYPE_STRING</term>
		/// </item>
		/// <item>
		/// <term>Property access</term>
		/// <term>Read-only access by installation applications and installers</term>
		/// </item>
		/// <item>
		/// <term>Localized?</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>You can use the value of DEVPKEY_NAME to identify a device setup class to an end-user in a user interface item.</para>
		/// <para>
		/// If DEVPKEY_DeviceClass_Name is set, the value of DEVPKEY_NAME is the same as the value of the <c>DEVPKEY_DeviceClass_Name</c>
		/// device property. Otherwise, the DEVPKEY_NAME value is the same as the value of the <c>DEVPKEY_DeviceClass_ClassName</c> device property.
		/// </para>
		/// <para>
		/// You can call <c>SetupDiGetClassProperty</c> or <c>SetupDiGetClassPropertyEx</c> to retrieve the value of DEVPKEY_NAME for a
		/// device setup class.
		/// </para>
		/// <para>
		/// Windows Server 2003, Windows XP, and Windows 2000 do not directly support a corresponding name property. However, these earlier
		/// versions of Windows do support properties that correspond to DEVPKEY_DeviceClass_Name and DEVPKEY_DeviceClass_ClassName.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/install/devpkey-name--device-setup-class-
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		public static readonly DEVPROPKEY DEVPKEY_NAME = new(0xb725f130, 0x47ef, 0x101a, 0xa5, 0xf1, 0x02, 0x60, 0x8c, 0x9e, 0xeb, 0xac, 10);
	}
}