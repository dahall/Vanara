using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the SetupAPI.dll</summary>
	public static partial class SetupAPI
	{
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
			FunctionHelper.CallMethodWithStrBuf((StringBuilder sb, ref uint sz) => SetupDiClassNameFromGuid(ClassGuid, sb, sz, out sz), out ClassName);

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
			var data = new SP_DEVINFO_DATA { cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA)) };
			for (uint i = 0; true; i++)
			{
				if (!SetupDiEnumDeviceInfo(DeviceInfoSet, i, ref data))
				{
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
					yield break;
				}
				yield return data;
			}
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
		public static extern bool SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in Guid InterfaceClassGuid, uint MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

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
		public static extern bool SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, [In, Optional] IntPtr DeviceInfoData, in Guid InterfaceClassGuid, uint MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

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
		/// call <see cref="SetupDiGetDeviceInterfaceDetail"/>. The detailed information includes the name of the device interface that can
		/// be passed to a Win32 function such as CreateFile (described in Microsoft Windows SDK documentation) to get a handle to the interface.
		/// </para>
		/// <para>See System Defined Device Interface Classes for a list of available device interface classes.</para>
		/// </remarks>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiEnumDeviceInterfaces")]
		public static IEnumerable<SP_DEVICE_INTERFACE_DATA> SetupDiEnumDeviceInterfaces(HDEVINFO DeviceInfoSet, Guid InterfaceClassGuid, SP_DEVINFO_DATA? DeviceInfoData = null)
		{
			using var dvidata = DeviceInfoData.HasValue ? new SafeCoTaskMemStruct<SP_DEVINFO_DATA>(DeviceInfoData.Value) : SafeCoTaskMemStruct<SP_DEVINFO_DATA>.Null;
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
		/// The caller of <c>SetupDiGetClassDevs</c> must delete the returned device information set when it is no longer needed by calling SetupDiDestroyDeviceInfoList.
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
		public static extern SafeHDEVINFO SetupDiGetClassDevs(in Guid ClassGuid, [In, Optional] string Enumerator, [In, Optional] HWND hwndParent, DIGCF Flags);

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
		public static extern SafeHDEVINFO SetupDiGetClassDevs([In, Optional] IntPtr ClassGuid, [In, Optional] string Enumerator, [In, Optional] HWND hwndParent, DIGCF Flags);

		/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
		/// <param name="DeviceInfoSet">
		/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
		/// returned by SetupDiGetClassDevs.
		/// </param>
		/// <param name="DeviceInterfaceData">
		/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details.
		/// A pointer of this type is typically returned by SetupDiEnumDeviceInterfaces.
		/// </param>
		/// <param name="DeviceInterfaceDetailData">
		/// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive information about the specified interface. This parameter
		/// is optional and can be <c>NULL</c>. This parameter must be <c>NULL</c> if DeviceInterfaceDetailSize is zero. If this parameter
		/// is specified, the caller must set DeviceInterfaceDetailData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA)
		/// before calling this function. The <c>cbSize</c> member always contains the size of the fixed part of the data structure, not a
		/// size reflecting the variable-length string at the end.
		/// </param>
		/// <param name="DeviceInterfaceDetailDataSize">
		/// <para>
		/// The size of the DeviceInterfaceDetailData buffer. The buffer must be at least ( <c>offsetof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA,
		/// <c>DevicePath</c>) + <c>sizeof</c>(TCHAR)) bytes, to contain the fixed part of the structure and a single <c>NULL</c> to
		/// terminate an empty MULTI_SZ string.
		/// </para>
		/// <para>This parameter must be zero if DeviceInterfaceDetailData is <c>NULL</c>.</para>
		/// </param>
		/// <param name="RequiredSize">
		/// A pointer to a variable of type DWORD that receives the required size of the DeviceInterfaceDetailData buffer. This size
		/// includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path
		/// string. This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <param name="DeviceInfoData">
		/// A pointer to a buffer that receives information about the device that supports the requested interface. The caller must set
		/// DeviceInfoData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
		/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
		/// </returns>
		/// <remarks>
		/// <para>Using this function to get details about an interface is typically a two-step process:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Get the required buffer size. Call <c>SetupDiGetDeviceInterfaceDetail</c> with a <c>NULL</c> DeviceInterfaceDetailData pointer,
		/// a DeviceInterfaceDetailDataSize of zero, and a valid RequiredSize variable. In response to such a call, this function returns
		/// the required buffer size at RequiredSize and fails with GetLastError returning ERROR_INSUFFICIENT_BUFFER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Allocate an appropriately sized buffer and call the function again to get the interface details.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The interface detail returned by this function consists of a device path that can be passed to Win32 functions such as
		/// CreateFile. Do not attempt to parse the device path symbolic name. The device path can be reused across system starts.
		/// </para>
		/// <para>
		/// <c>SetupDiGetDeviceInterfaceDetail</c> can be used to get just the DeviceInfoData. If the interface exists but
		/// DeviceInterfaceDetailData is <c>NULL</c>, this function fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and the
		/// DeviceInfoData structure is filled with information about the device that exposes the interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
		// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
		// PSP_DEVINFO_DATA DeviceInfoData );
		[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
			[Out, Optional] IntPtr DeviceInterfaceDetailData, uint DeviceInterfaceDetailDataSize, out uint RequiredSize, ref SP_DEVINFO_DATA DeviceInfoData);

		/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
		/// <param name="DeviceInfoSet">
		/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
		/// returned by SetupDiGetClassDevs.
		/// </param>
		/// <param name="DeviceInterfaceData">
		/// A pointer to an SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details.
		/// A pointer of this type is typically returned by SetupDiEnumDeviceInterfaces.
		/// </param>
		/// <param name="DeviceInterfaceDetailData">
		/// A pointer to an SP_DEVICE_INTERFACE_DETAIL_DATA structure to receive information about the specified interface. This parameter
		/// is optional and can be <c>NULL</c>. This parameter must be <c>NULL</c> if DeviceInterfaceDetailSize is zero. If this parameter
		/// is specified, the caller must set DeviceInterfaceDetailData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA)
		/// before calling this function. The <c>cbSize</c> member always contains the size of the fixed part of the data structure, not a
		/// size reflecting the variable-length string at the end.
		/// </param>
		/// <param name="DeviceInterfaceDetailDataSize">
		/// <para>
		/// The size of the DeviceInterfaceDetailData buffer. The buffer must be at least ( <c>offsetof</c>(SP_DEVICE_INTERFACE_DETAIL_DATA,
		/// <c>DevicePath</c>) + <c>sizeof</c>(TCHAR)) bytes, to contain the fixed part of the structure and a single <c>NULL</c> to
		/// terminate an empty MULTI_SZ string.
		/// </para>
		/// <para>This parameter must be zero if DeviceInterfaceDetailData is <c>NULL</c>.</para>
		/// </param>
		/// <param name="RequiredSize">
		/// A pointer to a variable of type DWORD that receives the required size of the DeviceInterfaceDetailData buffer. This size
		/// includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path
		/// string. This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <param name="DeviceInfoData">
		/// A pointer to a buffer that receives information about the device that supports the requested interface. The caller must set
		/// DeviceInfoData <c>.cbSize</c> to <c>sizeof</c>(SP_DEVINFO_DATA). This parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
		/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
		/// </returns>
		/// <remarks>
		/// <para>Using this function to get details about an interface is typically a two-step process:</para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Get the required buffer size. Call <c>SetupDiGetDeviceInterfaceDetail</c> with a <c>NULL</c> DeviceInterfaceDetailData pointer,
		/// a DeviceInterfaceDetailDataSize of zero, and a valid RequiredSize variable. In response to such a call, this function returns
		/// the required buffer size at RequiredSize and fails with GetLastError returning ERROR_INSUFFICIENT_BUFFER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Allocate an appropriately sized buffer and call the function again to get the interface details.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The interface detail returned by this function consists of a device path that can be passed to Win32 functions such as
		/// CreateFile. Do not attempt to parse the device path symbolic name. The device path can be reused across system starts.
		/// </para>
		/// <para>
		/// <c>SetupDiGetDeviceInterfaceDetail</c> can be used to get just the DeviceInfoData. If the interface exists but
		/// DeviceInterfaceDetailData is <c>NULL</c>, this function fails, GetLastError returns ERROR_INSUFFICIENT_BUFFER, and the
		/// DeviceInfoData structure is filled with information about the device that exposes the interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
		// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
		// PSP_DEVINFO_DATA DeviceInfoData );
		[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
			[Out, Optional] IntPtr DeviceInterfaceDetailData, uint DeviceInterfaceDetailDataSize, out uint RequiredSize, IntPtr DeviceInfoData = default);

		/// <summary>The <c>SetupDiGetDeviceInterfaceDetail</c> function returns details about a device interface.</summary>
		/// <param name="DeviceInfoSet">
		/// A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically
		/// returned by SetupDiGetClassDevs.
		/// </param>
		/// <param name="DeviceInterfaceData">
		/// An SP_DEVICE_INTERFACE_DATA structure that specifies the interface in DeviceInfoSet for which to retrieve details. This value is
		/// typically returned by SetupDiEnumDeviceInterfaces.
		/// </param>
		/// <param name="DeviceInterfacePath">
		/// A string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
		/// </param>
		/// <param name="DeviceInfoData">Receives information about the device that supports the requested interface.</param>
		/// <returns>
		/// <c>SetupDiGetDeviceInterfaceDetail</c> returns <c>TRUE</c> if the function completed without error. If the function completed
		/// with an error, <c>FALSE</c> is returned and the error code for the failure can be retrieved by calling GetLastError.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetaila WINSETUPAPI BOOL
		// SetupDiGetDeviceInterfaceDetailA( HDEVINFO DeviceInfoSet, PSP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
		// PSP_DEVICE_INTERFACE_DETAIL_DATA_A DeviceInterfaceDetailData, DWORD DeviceInterfaceDetailDataSize, PDWORD RequiredSize,
		// PSP_DEVINFO_DATA DeviceInfoData );
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDeviceInterfaceDetailA")]
		public static bool SetupDiGetDeviceInterfaceDetail(HDEVINFO DeviceInfoSet, in SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, out string DeviceInterfacePath, out SP_DEVINFO_DATA DeviceInfoData)
		{
			SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, DeviceInterfaceData, default, 0, out var sz);
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
			using var mem = new SafeSP_DEVICE_INTERFACE_DETAIL_DATA(sz);
			DeviceInfoData = new SP_DEVINFO_DATA { cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA)) };
			var ret = SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, DeviceInterfaceData, mem, sz, out sz, ref DeviceInfoData);
			DeviceInterfacePath = ret ? mem.DevicePath : null;
			return ret;
		}

		/// <summary>The <c>SetupDiGetDeviceProperty</c> function retrieves a device instance property.</summary>
		/// <param name="DeviceInfoSet">
		/// A handle to a device information set that contains a device instance for which to retrieve a device instance property.
		/// </param>
		/// <param name="DeviceInfoData">
		/// A pointer to the SP_DEVINFO_DATA structure that represents the device instance for which to retrieve a device instance property.
		/// </param>
		/// <param name="PropertyKey">
		/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
		/// </param>
		/// <param name="PropertyType">
		/// A pointer to a DEVPROPTYPE-typed variable that receives the property-data-type identifier of the requested device instance
		/// property, where the property-data-type identifier is the bitwise OR between a base-data-type identifier and, if the base-data
		/// type is modified, a property-data-type modifier.
		/// </param>
		/// <param name="PropertyBuffer">
		/// A pointer to a buffer that receives the requested device instance property. <c>SetupDiGetDeviceProperty</c> retrieves the
		/// requested property only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>. If
		/// the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetDeviceProperty</c> returns the size of the
		/// property, in bytes, in *RequiredSize.
		/// </param>
		/// <param name="PropertyBufferSize">
		/// The size, in bytes, of the PropertyBuffer buffer. If PropertyBuffer is set to <c>NULL</c>, PropertyBufferSize must be set to zero.
		/// </param>
		/// <param name="RequiredSize">
		/// A pointer to a DWORD-typed variable that receives the size, in bytes, of either the device instance property if the property is
		/// retrieved or the required buffer size if the buffer is not large enough. This pointer can be set to <c>NULL</c>.
		/// </param>
		/// <param name="Flags">This parameter must be set to zero.</param>
		/// <returns>
		/// <para>
		/// <c>SetupDiGetDeviceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
		/// error can be retrieved by calling GetLastError.
		/// </para>
		/// <para>The following table includes some of the more common error codes that this function might log.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The value of Flags is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_REG_PROPERTY</term>
		/// <term>The property key that is supplied by PropertyKey is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>An unspecified internal data value was not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL and PropertBufferSize is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DEVINST</term>
		/// <term>The device instance that is specified by DevInfoData does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The PropertyBuffer buffer is too small to hold the requested property value, or an internal data buffer that was passed to a
		/// system call was too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was not enough system memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>The requested device property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The caller does not have Administrator privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>SetupDiGetDeviceProperty</c> is part of the unified device property model.</para>
		/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>To obtain the device property keys that represent the device properties that are set for a device instance, call SetupDiGetDevicePropertyKeys.</para>
		/// <para>To set a device instance property, call SetupDiSetDeviceProperty.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdevicepropertyw WINSETUPAPI BOOL
		// SetupDiGetDevicePropertyW( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, const DEVPROPKEY *PropertyKey, DEVPROPTYPE
		// *PropertyType, PBYTE PropertyBuffer, DWORD PropertyBufferSize, PDWORD RequiredSize, DWORD Flags );
		[DllImport(Lib_SetupAPI, SetLastError = true, CharSet = CharSet.Unicode)]
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetupDiGetDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in DEVPROPKEY PropertyKey,
			out DEVPROPTYPE PropertyType, [Out, Optional] IntPtr PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize, uint Flags = 0);

		/// <summary>The <c>SetupDiGetDeviceProperty</c> function retrieves a device instance property.</summary>
		/// <param name="DeviceInfoSet">
		/// A handle to a device information set that contains a device instance for which to retrieve a device instance property.
		/// </param>
		/// <param name="DeviceInfoData">
		/// A pointer to the SP_DEVINFO_DATA structure that represents the device instance for which to retrieve a device instance property.
		/// </param>
		/// <param name="PropertyKey">
		/// A pointer to a DEVPROPKEY structure that represents the device property key of the requested device instance property.
		/// </param>
		/// <param name="Value">
		/// A pointer to a buffer that receives the requested device instance property. <c>SetupDiGetDeviceProperty</c> retrieves the
		/// requested property only if the buffer is large enough to hold all the property value data. The pointer can be <c>NULL</c>. If
		/// the pointer is set to <c>NULL</c> and RequiredSize is supplied, <c>SetupDiGetDeviceProperty</c> returns the size of the
		/// property, in bytes, in *RequiredSize.
		/// </param>
		/// <returns>
		/// <para>
		/// <c>SetupDiGetDeviceProperty</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
		/// error can be retrieved by calling GetLastError.
		/// </para>
		/// <para>The following table includes some of the more common error codes that this function might log.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The value of Flags is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_REG_PROPERTY</term>
		/// <term>The property key that is supplied by PropertyKey is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>An unspecified internal data value was not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>A user buffer is not valid. One possibility is that PropertyBuffer is NULL and PropertBufferSize is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DEVINST</term>
		/// <term>The device instance that is specified by DevInfoData does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The PropertyBuffer buffer is too small to hold the requested property value, or an internal data buffer that was passed to a
		/// system call was too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was not enough system memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>The requested device property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The caller does not have Administrator privileges.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>SetupDiGetDeviceProperty</c> is part of the unified device property model.</para>
		/// <para>SetupAPI supports only a Unicode version of <c>SetupDiGetDeviceProperty</c>.</para>
		/// <para>To obtain the device property keys that represent the device properties that are set for a device instance, call SetupDiGetDevicePropertyKeys.</para>
		/// <para>To set a device instance property, call SetupDiSetDeviceProperty.</para>
		/// </remarks>
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyW")]
		public static bool SetupDiGetDeviceProperty(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData, in DEVPROPKEY PropertyKey, out object Value)
		{
			Value = null;
			if (!SetupDiGetDeviceProperty(DeviceInfoSet, DeviceInfoData, PropertyKey, out _, default, 0, out var sz) && Win32Error.GetLastError() != Win32Error.ERROR_INSUFFICIENT_BUFFER)
				return false;
			using var mem = new SafeCoTaskMemHandle(sz);
			if (SetupDiGetDeviceProperty(DeviceInfoSet, DeviceInfoData, PropertyKey, out var propType, mem, mem.Size, out _))
			{
				switch (propType)
				{
					case DEVPROPTYPE.DEVPROP_TYPE_EMPTY:
					case DEVPROPTYPE.DEVPROP_TYPE_NULL:
						Value = null;
						return true;

					case DEVPROPTYPE.DEVPROP_TYPE_SECURITY_DESCRIPTOR:
						Value = new System.Security.AccessControl.RawSecurityDescriptor(mem.GetBytes(0, mem.Size), 0);
						return true;

					case DEVPROPTYPE.DEVPROP_TYPE_STRING_INDIRECT:
						Value = mem.ToString(-1, CharSet.Unicode);
						return true;

					case DEVPROPTYPE.DEVPROP_TYPE_STRING_LIST:
						Value = mem.ToStringEnum(CharSet.Unicode).ToArray();
						return true;

					default:
						(DEVPROPTYPE type, DEVPROPTYPE mod) spt = propType.Split();
						var type = CorrespondingTypeAttribute.GetCorrespondingTypes(spt.type).FirstOrDefault();
						if (type is not null)
						{
							Value = spt.mod switch
							{
								0 => mem.DangerousGetHandle().Convert(mem.Size, type, CharSet.Unicode),
								DEVPROPTYPE.DEVPROP_TYPEMOD_ARRAY => mem.DangerousGetHandle().ToArray(type, mem.Size / Marshal.SizeOf(type), 0, mem.Size),
								_ => null
							};
							if (Value is not null)
								return true;
						}
						break;
				}
			}
			return false;
		}

		/// <summary>
		/// The <c>SetupDiGetDevicePropertyKeys</c> function retrieves an array of the device property keys that represent the device
		/// properties that are set for a device instance.
		/// </summary>
		/// <param name="DeviceInfoSet">
		/// A handle to a device information set. This device information set contains the device instance for which this function retrieves
		/// an array of device property keys. The property keys represent the device properties that are set for the device instance.
		/// </param>
		/// <param name="DeviceInfoData">
		/// A pointer to an SP_DEVINFO_DATA structure that represents the device instance for which to retrieve the requested array of
		/// device property keys.
		/// </param>
		/// <param name="PropertyKeyArray">
		/// A pointer to a buffer that receives an array of DEVPROPKEY-typed values, where each value is a device property key that
		/// represents a device property that is set for the device instance. The pointer is optional and can be <c>NULL</c>. For more
		/// information, see the <c>Remarks</c> section later in this topic.
		/// </param>
		/// <param name="PropertyKeyCount">
		/// The size, in DEVPROPKEY-typed values, of the PropertyKeyArray buffer. If PropertyKeyArray is set to <c>NULL</c>,
		/// PropertyKeyCount must be set to zero.
		/// </param>
		/// <param name="RequiredPropertyKeyCount">
		/// A pointer to a DWORD-typed variable that receives the number of requested device property keys. The pointer is optional and can
		/// be set to <c>NULL</c>.
		/// </param>
		/// <param name="Flags">This parameter must be set to zero.</param>
		/// <returns>
		/// <para>
		/// <c>SetupDiGetDevicePropertyKeys</c> returns <c>TRUE</c> if it is successful. Otherwise, it returns <c>FALSE</c>, and the logged
		/// error can be retrieved by calling GetLastError.
		/// </para>
		/// <para>The following table includes some of the more common error codes that this function might log.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The value of Flags is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>The device information set that is specified by DevInfoSet is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A supplied parameter is not valid. One possibility is that the device information element is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>An internal data value is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>A user buffer is not valid. One possibility is that PropertyKeyArray is NULL and PropertKeyCount is not zero.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DEVINST</term>
		/// <term>The device instance that is specified by DevInfoData does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>The PropertyKeyArray buffer is too small to hold all the requested property keys.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was not enough system memory available to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>SetupDiGetDevicePropertyKeys</c> is part of the unified device property model.</para>
		/// <para>
		/// If the ProperKeyArray buffer is not large enough to hold all the requested property keys, <c>SetupDiGetDevicePropertyKeys</c>
		/// does not retrieve any property keys and returns ERROR_INSUFFICIENT_BUFFER. If the caller supplied a RequiredPropertyKeyCount
		/// pointer, <c>SetupDiGetDevicePropertyKeys</c> sets the value of *RequiredPropertyKeyCount to the required size, in
		/// DEVPROPKEY-typed values, of the PropertyKeyArray buffer.
		/// </para>
		/// <para>To retrieve a device instance property, call SetupDiGetDeviceProperty, and to set a device instance property, call SetupDiSetDeviceProperty.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdevicepropertykeys WINSETUPAPI BOOL
		// SetupDiGetDevicePropertyKeys( HDEVINFO DeviceInfoSet, PSP_DEVINFO_DATA DeviceInfoData, DEVPROPKEY *PropertyKeyArray, DWORD
		// PropertyKeyCount, PDWORD RequiredPropertyKeyCount, DWORD Flags );
		[DllImport(Lib_SetupAPI, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("setupapi.h", MSDNShortId = "NF:setupapi.SetupDiGetDevicePropertyKeys")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetupDiGetDevicePropertyKeys(HDEVINFO DeviceInfoSet, in SP_DEVINFO_DATA DeviceInfoData,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DEVPROPKEY[] PropertyKeyArray, uint PropertyKeyCount,
			out uint RequiredPropertyKeyCount, uint Flags = 0);

		/*
		SetupDiAskForOEMDisk
		SetupDiBuildClassInfoList
		SetupDiBuildClassInfoListExA
		SetupDiBuildClassInfoListExW
		SetupDiBuildDriverInfoList
		SetupDiCallClassInstaller
		SetupDiCancelDriverInfoSearch
		SetupDiChangeState
		SetupDiClassGuidsFromNameA
		SetupDiClassGuidsFromNameExA
		SetupDiClassGuidsFromNameExW
		SetupDiClassGuidsFromNameW
		SetupDiClassNameFromGuidExA
		SetupDiClassNameFromGuidExW
		SetupDiCreateDeviceInfoA
		SetupDiCreateDeviceInfoList
		SetupDiCreateDeviceInfoListExA
		SetupDiCreateDeviceInfoListExW
		SetupDiCreateDeviceInfoW
		SetupDiCreateDeviceInterfaceA
		SetupDiCreateDeviceInterfaceRegKeyA
		SetupDiCreateDeviceInterfaceRegKeyW
		SetupDiCreateDeviceInterfaceW
		SetupDiCreateDevRegKeyA
		SetupDiCreateDevRegKeyW
		SetupDiDeleteDeviceInfo
		SetupDiDeleteDeviceInterfaceData
		SetupDiDeleteDeviceInterfaceRegKey
		SetupDiDeleteDevRegKey
		SetupDiDestroyClassImageList
		SetupDiDestroyDriverInfoList
		SetupDiDrawMiniIcon
		SetupDiEnumDriverInfoA
		SetupDiEnumDriverInfoW
		SetupDiGetActualModelsSectionA
		SetupDiGetActualModelsSectionW
		SetupDiGetActualSectionToInstallA
		SetupDiGetActualSectionToInstallExA
		SetupDiGetActualSectionToInstallExW
		SetupDiGetActualSectionToInstallW
		SetupDiGetClassBitmapIndex
		SetupDiGetClassDescriptionA
		SetupDiGetClassDescriptionExA
		SetupDiGetClassDescriptionExW
		SetupDiGetClassDescriptionW
		SetupDiGetClassDevPropertySheetsA
		SetupDiGetClassDevPropertySheetsW
		SetupDiGetClassDevsExA
		SetupDiGetClassDevsExW
		SetupDiGetClassImageIndex
		SetupDiGetClassImageList
		SetupDiGetClassImageListExA
		SetupDiGetClassImageListExW
		SetupDiGetClassInstallParamsA
		SetupDiGetClassInstallParamsW
		SetupDiGetClassPropertyExW
		SetupDiGetClassPropertyKeys
		SetupDiGetClassPropertyKeysExW
		SetupDiGetClassPropertyW
		SetupDiGetClassRegistryPropertyA
		SetupDiGetClassRegistryPropertyW
		SetupDiGetCustomDevicePropertyA
		SetupDiGetCustomDevicePropertyW
		SetupDiGetDeviceInfoListClass
		SetupDiGetDeviceInfoListDetailA
		SetupDiGetDeviceInfoListDetailW
		SetupDiGetDeviceInstallParamsA
		SetupDiGetDeviceInstallParamsW
		SetupDiGetDeviceInstanceIdA
		SetupDiGetDeviceInstanceIdW
		SetupDiGetDeviceInterfaceAlias
		SetupDiGetDeviceInterfacePropertyKeys
		SetupDiGetDeviceInterfacePropertyW
		SetupDiGetDevicePropertyKeys
		SetupDiGetDeviceRegistryPropertyA
		SetupDiGetDeviceRegistryPropertyW
		SetupDiGetDriverInfoDetailA
		SetupDiGetDriverInfoDetailW
		SetupDiGetDriverInstallParamsA
		SetupDiGetDriverInstallParamsW
		SetupDiGetHwProfileFriendlyNameA
		SetupDiGetHwProfileFriendlyNameExA
		SetupDiGetHwProfileFriendlyNameExW
		SetupDiGetHwProfileFriendlyNameW
		SetupDiGetHwProfileList
		SetupDiGetHwProfileListExA
		SetupDiGetHwProfileListExW
		SetupDiGetINFClassA
		SetupDiGetINFClassW
		SetupDiGetSelectedDevice
		SetupDiGetSelectedDriverA
		SetupDiGetSelectedDriverW
		SetupDiInstallClassA
		SetupDiInstallClassExA
		SetupDiInstallClassExW
		SetupDiInstallClassW
		SetupDiInstallDevice
		SetupDiInstallDeviceInterfaces
		SetupDiInstallDriverFiles
		SetupDiLoadClassIcon
		SetupDiLoadDeviceIcon
		SetupDiOpenClassRegKey
		SetupDiOpenClassRegKeyExA
		SetupDiOpenClassRegKeyExW
		SetupDiOpenDeviceInfoA
		SetupDiOpenDeviceInfoW
		SetupDiOpenDeviceInterfaceA
		SetupDiOpenDeviceInterfaceRegKey
		SetupDiOpenDeviceInterfaceW
		SetupDiOpenDevRegKey
		SetupDiRegisterCoDeviceInstallers
		SetupDiRegisterDeviceInfo
		SetupDiRemoveDevice
		SetupDiRemoveDeviceInterface
		SetupDiRestartDevices
		SetupDiSelectBestCompatDrv
		SetupDiSelectDevice
		SetupDiSelectOEMDrv
		SetupDiSetClassInstallParamsA
		SetupDiSetClassInstallParamsW
		SetupDiSetClassPropertyExW
		SetupDiSetClassPropertyW
		SetupDiSetClassRegistryPropertyA
		SetupDiSetClassRegistryPropertyW
		SetupDiSetDeviceInstallParamsA
		SetupDiSetDeviceInstallParamsW
		SetupDiSetDeviceInterfaceDefault
		SetupDiSetDeviceInterfacePropertyW
		SetupDiSetDevicePropertyW
		SetupDiSetDeviceRegistryPropertyA
		SetupDiSetDeviceRegistryPropertyW
		SetupDiSetDriverInstallParamsA
		SetupDiSetDriverInstallParamsW
		SetupDiSetSelectedDevice
		SetupDiSetSelectedDriverA
		SetupDiSetSelectedDriverW
		SetupDiUnremoveDevice
		*/
	}
}