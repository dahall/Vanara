using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke
{
	/// <summary>Items from the CfgMgr32.dll</summary>
	public static partial class CfgMgr32
	{
		/// <summary/>
		public static readonly uint BusNumberType_Range = (uint)Marshal.SizeOf(typeof(BUSNUMBER_RANGE));

		/// <summary/>
		public static readonly uint DType_Range = (uint)Marshal.SizeOf(typeof(DMA_RANGE));

		/// <summary/>
		public static readonly uint IOType_Range = (uint)Marshal.SizeOf(typeof(IO_RANGE));

		/// <summary/>
		public static readonly uint IRQType_Range = (uint)Marshal.SizeOf(typeof(IRQ_RANGE));

		/// <summary/>
		public static readonly uint MType_Range = (uint)Marshal.SizeOf(typeof(MEM_RANGE));

		/// <summary>
		/// The BUSNUMBER_DES structure is used for specifying either a resource list or a resource requirements list that describes bus
		/// number usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		/// <remarks>The BUSNUMBER_DES structure is included as a member of the BUSNUMBER_RESOURCE structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-busnumber_des typedef struct BusNumber_Des_s { DWORD
		// BUSD_Count; DWORD BUSD_Type; DWORD BUSD_Flags; ULONG BUSD_Alloc_Base; ULONG BUSD_Alloc_End; } BUSNUMBER_DES, *PBUSNUMBER_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.BusNumber_Des_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BUSNUMBER_DES
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the BUSNUMBER_RANGE array that is included in the BUSNUMBER_RESOURCE structure.</para>
			/// </summary>
			public uint BUSD_Count;

			/// <summary>Must be set to the constant value <see cref="BusNumberType_Range"/>.</summary>
			public uint BUSD_Type;

			/// <summary>Not used.</summary>
			public uint BUSD_Flags;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The lowest-numbered of a range of contiguous bus numbers allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public uint BUSD_Alloc_Base;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The highest-numbered of a range of contiguous bus numbers allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public uint BUSD_Alloc_End;
		}

		/// <summary>
		/// The BUSNUMBER_RANGE structure specifies a resource requirements list that describes bus number usage for a device instance. For
		/// more information about resource requirements lists, see Hardware Resources.
		/// </summary>
		/// <remarks>The BUSNUMBER_RANGE structure is included as a member of the BUSNUMBER_RESOURCE structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-busnumber_range typedef struct BusNumber_Range_s { ULONG
		// BUSR_Min; ULONG BUSR_Max; ULONG BUSR_nBusNumbers; ULONG BUSR_Flags; } BUSNUMBER_RANGE, *PBUSNUMBER_RANGE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.BusNumber_Range_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct BUSNUMBER_RANGE
		{
			/// <summary>The lowest-numbered of a range of contiguous bus numbers that can be allocated to the device.</summary>
			public uint BUSR_Min;

			/// <summary>The highest-numbered of a range of contiguous bus numbers that can be allocated to the device.</summary>
			public uint BUSR_Max;

			/// <summary>The number of contiguous bus numbers required by the device.</summary>
			public uint BUSR_nBusNumbers;

			/// <summary>Not used.</summary>
			public uint BUSR_Flags;
		}

		/// <summary>
		/// The BUSNUMBER_RESOURCE structure specifies either a resource list or a resource requirements list that describes bus number
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-busnumber_resource typedef struct BusNumber_Resource_s {
		// BUSNUMBER_DES BusNumber_Header; BUSNUMBER_RANGE BusNumber_Data[ANYSIZE_ARRAY]; } BUSNUMBER_RESOURCE, *PBUSNUMBER_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.BusNumber_Resource_s")]
		[StructLayout(LayoutKind.Sequential)]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<BUSNUMBER_RESOURCE>), "*")]
		public struct BUSNUMBER_RESOURCE
		{
			/// <summary>A BUSNUMBER_DES structure.</summary>
			public BUSNUMBER_DES BusNumber_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>A BUSNUMBER_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public BUSNUMBER_RANGE[] BusNumber_Data;
		}

		/// <summary>This is a device notification event data structure.</summary>
		/// <remarks>
		/// The notification callback supplied to CM_Register_Notification receives a pointer to a structure of type
		/// <c>CM_NOTIFY_EVENT_DATA</c> in the callback's EventData parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_event_data typedef struct _CM_NOTIFY_EVENT_DATA
		// { CM_NOTIFY_FILTER_TYPE FilterType; DWORD Reserved; union { struct { GUID ClassGuid; WCHAR SymbolicLink[ANYSIZE_ARRAY]; }
		// DeviceInterface; struct { GUID EventGuid; LONG NameOffset; DWORD DataSize; BYTE Data[ANYSIZE_ARRAY]; } DeviceHandle; struct {
		// WCHAR InstanceId[ANYSIZE_ARRAY]; } DeviceInstance; } u; } CM_NOTIFY_EVENT_DATA, *PCM_NOTIFY_EVENT_DATA;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CM_NOTIFY_EVENT_DATA")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct CM_NOTIFY_EVENT_DATA
		{
			/// <summary>
			/// The <c>CM_NOTIFY_FILTER_TYPE</c> from the CM_NOTIFY_FILTER structure that was used in the registration that generated this
			/// notification event data.
			/// </summary>
			public CM_NOTIFY_FILTER_TYPE FilterType;

			/// <summary>Reserved. Must be 0.</summary>
			public uint Reserved;

			/// <summary>
			/// A union that contains information about the notification event data. To determine which member of the union to examine,
			/// check the <c>FilterType</c> of the event data.
			/// </summary>
			public UNION u;

			/// <summary>
			/// A union that contains information about the notification event data. To determine which member of the union to examine,
			/// check the <c>FilterType</c> of the event data.
			/// </summary>
			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
			public struct UNION
			{
				/// <summary>Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE</c>.</summary>
				[FieldOffset(0)]
				public DEVICEINTERFACE DeviceInterface;

				/// <summary>
				/// Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE</c> and the
				/// notification action is <c>CM_NOTIFY_ACTION_DEVICECUSTOMEVENT</c>.
				/// </summary>
				[FieldOffset(0)]
				public DEVICEHANDLE DeviceHandle;

				/// <summary>Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE</c>.</summary>
				[FieldOffset(0)]
				public DEVICEINSTANCE DeviceInstance;

				/// <summary>Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE</c>.</summary>
				public unsafe struct DEVICEINTERFACE
				{
					/// <summary>
					/// The GUID of the device interface class for the device interface to which the notification event data pertains.
					/// </summary>
					public Guid ClassGuid;

					/// <summary>The symbolic link path of the device interface to which the notification event data pertains.</summary>
					public fixed char SymbolicLink[1];
				}

				/// <summary>
				/// Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE</c> and the
				/// notification action is <c>CM_NOTIFY_ACTION_DEVICECUSTOMEVENT</c>.
				/// </summary>
				public unsafe struct DEVICEHANDLE
				{
					/// <summary>The GUID for the custom event.</summary>
					public Guid EventGuid;

					/// <summary>The offset of an optional string buffer. Usage depends on the contract for the <c>EventGuid</c>.</summary>
					public int NameOffset;

					/// <summary>The number of bytes that can be read from the <c>Data</c> member.</summary>
					public uint DataSize;

					/// <summary>Optional binary data. Usage depends on the contract for the <c>EventGuid</c>.</summary>
					public fixed byte Data[1];
				}

				/// <summary>Examine this part of the union when the <c>FilterType</c> is <c>CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE</c>.</summary>
				public unsafe struct DEVICEINSTANCE
				{
					/// <summary>The device instance ID of the device to which the notification event data pertains.</summary>
					public fixed char InstanceId[1];
				}
			}
		}

		/// <summary>Device notification filter structure</summary>
		/// <remarks>
		/// When the driver calls the CM_Register_Notificationfunction, it supplies a pointer to a <c>CM_NOTIFY_FILTER</c> structure in the
		/// pFilter parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cm_notify_filter typedef struct _CM_NOTIFY_FILTER { DWORD
		// cbSize; DWORD Flags; CM_NOTIFY_FILTER_TYPE FilterType; DWORD Reserved; union { struct { GUID ClassGuid; } DeviceInterface; struct
		// { HANDLE hTarget; } DeviceHandle; struct { WCHAR InstanceId[MAX_DEVICE_ID_LEN]; } DeviceInstance; } u; } CM_NOTIFY_FILTER, *PCM_NOTIFY_FILTER;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CM_NOTIFY_FILTER")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
		public struct CM_NOTIFY_FILTER
		{
			/// <summary>Initializes a new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.</summary>
			/// <param name="deviceInterfaceClassGuid">The GUID of the device interface class for which to receive notifications.</param>
			public CM_NOTIFY_FILTER(Guid deviceInterfaceClassGuid) : this()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CM_NOTIFY_FILTER));
				FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE;
				u.DeviceInterface_ClassGuid = deviceInterfaceClassGuid;
			}

			/// <summary>Initializes a new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.</summary>
			/// <param name="hTargetDevice">A handle to the device for which to receive notifications.</param>
			public CM_NOTIFY_FILTER(IntPtr hTargetDevice) : this()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CM_NOTIFY_FILTER));
				FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE;
				u.DeviceHandle_hTarget = hTargetDevice;
			}

			/// <summary>Initializes a new instance of the <see cref="CM_NOTIFY_FILTER"/> struct.</summary>
			/// <param name="deviceInstanceId">The device instance ID for the device for which to receive notifications.</param>
			public CM_NOTIFY_FILTER(string deviceInstanceId) : this()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CM_NOTIFY_FILTER));
				FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE;
				u.DeviceInstance_InstanceId = deviceInstanceId;
			}

			/// <summary>The size of the structure.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>A combination of zero or more of the following flags:</para>
			/// <para>CM_NOTIFY_FILTER_FLAG_ALL_INTERFACE_CLASSES</para>
			/// <para>
			/// Register to receive notifications for PnP events for all device interface classes. The memory at
			/// <c>pFilter-&gt;u.DeviceInterface.ClassGuid</c> must be zeroes. Do not use this flag with
			/// CM_NOTIFY_FILTER_FLAG_ALL_DEVICE_INSTANCES. This flag is only valid if <c>pFilter-&gt;FilterType</c> is CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE.
			/// </para>
			/// <para>CM_NOTIFY_FILTER_FLAG_ALL_DEVICE_INSTANCES</para>
			/// <para>
			/// Register to receive notifications for PnP events for all devices. <c>pFilter-&gt;u.DeviceInstance.InstanceId</c> must be an
			/// empty string. Do not use this flag with CM_NOTIFY_FILTER_FLAG_ALL_INTERFACE_CLASSES. This flag is only valid if
			/// <c>pFilter-&gt;FilterType</c> is CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE.
			/// </para>
			/// </summary>
			public CM_NOTIFY_FILTER_FLAG Flags;

			/// <summary>
			/// <para>Must be one of the following values:</para>
			/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE</para>
			/// <para>
			/// Register for notifications for device interface events. <c>pFilter-&gt;u.DeviceInterface.ClassGuid</c> should be filled in
			/// with the GUID of the device interface class to receive notifications for.
			/// </para>
			/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEHANDLE</para>
			/// <para>
			/// Register for notifications for device handle events. <c>pFilter-&gt;u.DeviceHandle.hTarget</c> must be filled in with a
			/// handle to the device to receive notifications for.
			/// </para>
			/// <para>CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE</para>
			/// <para>
			/// Register for notifications for device instance events. <c>pFilter-&gt;u.DeviceInstance.InstanceId</c> should be filled in
			/// with the device instance ID of the device to receive notifications for.
			/// </para>
			/// </summary>
			public CM_NOTIFY_FILTER_TYPE FilterType;

			/// <summary>Set to 0.</summary>
			public uint Reserved;

			/// <summary>A union that contains information about the device to receive notifications for.</summary>
			public UNION u;

			/// <summary>Gets an instance of this structure set to filter all devices.</summary>
			public static readonly CM_NOTIFY_FILTER AllDevices = new()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CM_NOTIFY_FILTER)),
				Flags = CM_NOTIFY_FILTER_FLAG.CM_NOTIFY_FILTER_FLAG_ALL_DEVICE_INSTANCES,
				FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINSTANCE
			};

			/// <summary>Gets an instance of this structure set to filter all device interface classes.</summary>
			public static readonly CM_NOTIFY_FILTER AllInterfaces = new()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CM_NOTIFY_FILTER)),
				Flags = CM_NOTIFY_FILTER_FLAG.CM_NOTIFY_FILTER_FLAG_ALL_INTERFACE_CLASSES,
				FilterType = CM_NOTIFY_FILTER_TYPE.CM_NOTIFY_FILTER_TYPE_DEVICEINTERFACE
			};

			/// <summary>A union that contains information about the device to receive notifications for.</summary>
			[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
			public unsafe struct UNION
			{
				/// <summary>The GUID of the device interface class for which to receive notifications.</summary>
				[FieldOffset(0)]
				public Guid DeviceInterface_ClassGuid;

				/// <summary>A handle to the device for which to receive notifications.</summary>
				[FieldOffset(0)]
				public IntPtr DeviceHandle_hTarget;

				[FieldOffset(0)]
				private fixed char iid[MAX_DEVICE_ID_LEN];

				/// <summary>The device instance ID for the device for which to receive notifications.</summary>
				public string DeviceInstance_InstanceId
				{
					get
					{
						fixed (char* p = iid)
							return new string(p);
					}
					set
					{
						if (value is null) throw new ArgumentNullException(nameof(DeviceInstance_InstanceId));
						if (value.Length >= MAX_DEVICE_ID_LEN) throw new ArgumentException($"String length exceeds maximum of {MAX_DEVICE_ID_LEN - 1} characters.", nameof(DeviceInstance_InstanceId));
						for (int i = 0; i < value.Length; i++)
							iid[i] = value[i];
						iid[value.Length] = '\0';
					}
				}
			}
		}

		/// <summary>The CONFLICT_DETAILS structure is used as a parameter to the CM_Get_Resource_Conflict_Details function.</summary>
		/// <remarks>
		/// <para>Note</para>
		/// <para>
		/// The cfgmgr32.h header defines CONFLICT_DETAILS as an alias which automatically selects the ANSI or Unicode version of this
		/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that
		/// not encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions
		/// for Function Prototypes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-conflict_details_a typedef struct _CONFLICT_DETAILS_A {
		// ULONG CD_ulSize; ULONG CD_ulMask; DEVINST CD_dnDevInst; RES_DES CD_rdResDes; ULONG CD_ulFlags; CHAR CD_szDescription[MAX_PATH]; }
		// CONFLICT_DETAILS_A, *PCONFLICT_DETAILS_A;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32._CONFLICT_DETAILS_A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CONFLICT_DETAILS
		{
			/// <summary>Size, in bytes, of the CONFLICT_DETAILS structure.</summary>
			public uint CD_ulSize;

			/// <summary>
			/// <para>
			/// One or more bit flags supplied by the caller of <c>CM_Get_Resource_Conflict_Details</c>. The bit flags are described in the
			/// following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>CM_CDMASK_DEVINST</term>
			/// <term>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_dnDevInst member.</term>
			/// </item>
			/// <item>
			/// <term>CM_CDMASK_RESDES</term>
			/// <term>Not used.</term>
			/// </item>
			/// <item>
			/// <term>CM_CDMASK_FLAGS</term>
			/// <term>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_ulFlags member.</term>
			/// </item>
			/// <item>
			/// <term>CM_CDMASK_DESCRIPTION</term>
			/// <term>If set, CM_Get_Resource_Conflict_Details supplies a value for the CD_szDescription member.</term>
			/// </item>
			/// </list>
			/// </summary>
			public CM_CDMASK CD_ulMask;

			/// <summary>
			/// If CM_CDMASK_DEVINST is set in <c>CD_ulMask</c>, this member will receive a handle to a device instance that has conflicting
			/// resources. If a handle is not obtainable, the member receives -1.
			/// </summary>
			public uint CD_dnDevInst;

			/// <summary>Not used.</summary>
			public RES_DES CD_rdResDes;

			/// <summary>
			/// <para>If CM_CDMASK_FLAGS is set in <c>CD_ulMask</c>, this member can receive bit flags listed in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>CM_CDFLAGS_DRIVER</term>
			/// <term>
			/// If set, the string contained in the CD_szDescription member represents a driver name instead of a device name, and
			/// CD_dnDevInst is -1.
			/// </term>
			/// </item>
			/// <item>
			/// <term>CM_CDFLAGS_ROOT_OWNED</term>
			/// <term>If set, the conflicting resources are owned by the root device (that is, the HAL), and CD_dnDevInst is -1.</term>
			/// </item>
			/// <item>
			/// <term>CM_CDFLAGS_RESERVED</term>
			/// <term>If set, the owner of the conflicting resources cannot be determined, and CD_dnDevInst is -1.</term>
			/// </item>
			/// </list>
			/// </summary>
			public CM_CDFLAGS CD_ulFlags;

			/// <summary>
			/// If CM_CDMASK_DESCRIPTION is set in <c>CD_ulMask</c>, this member will receive a NULL-terminated text string representing a
			/// description of the device that owns the resources. If CM_CDFLAGS_DRIVER is set in <c>CD_ulFlags</c>, this string represents
			/// a driver name. If CM_CDFLAGS_ROOT_OWNED or CM_CDFLAGS_RESERVED is set, the string value is <c>NULL</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 /*MAX_PATH*/)]
			public string CD_szDescription;

			/// <summary>Gets a default value for the structure with the size field set.</summary>
			public static readonly CONFLICT_DETAILS Default = new() { CD_ulSize = (uint)Marshal.SizeOf(typeof(CONFLICT_DETAILS)) };
		}

		/// <summary>
		/// The CS_DES structure is used for specifying a resource list that describes device class-specific resource usage for a device
		/// instance. For more information about resource lists, see Hardware Resources.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The data block identified by <c>CSD_LegacyDataSize</c> and <c>CSD_LegacyDataOffset</c> can contain legacy, class-specific data,
		/// as stored in the <c>DeviceSpecificData</c> member of a CM_PARTIAL_RESOURCE_DESCRIPTOR structure, if the structure's <c>Type</c>
		/// member is <c>CmResourceTypeDeviceSpecific</c>.
		/// </para>
		/// <para>
		/// The class-specific signature identified by <c>CSD_SignatureLength</c> and <c>CSD_Signature</c> can contain additional
		/// class-specific device identification information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cs_des typedef struct CS_Des_s { DWORD
		// CSD_SignatureLength; DWORD CSD_LegacyDataOffset; DWORD CSD_LegacyDataSize; DWORD CSD_Flags; GUID CSD_ClassGuid; BYTE
		// CSD_Signature[ANYSIZE_ARRAY]; } CS_DES, *PCS_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.CS_Des_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<CS_DES>), nameof(CSD_SignatureLength))]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct CS_DES
		{
			/// <summary>The number of elements in the byte array specified by <c>CSD_Signature</c>.</summary>
			public uint CSD_SignatureLength;

			/// <summary>
			/// Offset, in bytes, from the beginning of the <c>CSD_Signature</c> array to the beginning of a block of data. For example, if
			/// the data block follows the signature array, and if the signature array length is 16 bytes, then the value for
			/// <c>CSD_LegacyDataOffset</c> should be 16.
			/// </summary>
			public uint CSD_LegacyDataOffset;

			/// <summary>Length, in bytes, of the data block whose offset is specified by <c>CSD_LegacyDataOffset</c>.</summary>
			public uint CSD_LegacyDataSize;

			/// <summary>Not used.</summary>
			public uint CSD_Flags;

			/// <summary>
			/// A globally unique identifier (GUID) identifying a device setup class. If both <c>CSD_SignatureLength</c> and
			/// <c>CSD_LegacyDataSize</c> are zero, the GUID is null.
			/// </summary>
			public Guid CSD_ClassGuid;

			/// <summary>A byte array containing a class-specific signature.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public byte[] CSD_Signature;
		}

		/// <summary>
		/// The CS_RESOURCE structure is used for specifying a resource list that describes device class-specific resource usage for a
		/// device instance. For more information about resource lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-cs_resource typedef struct CS_Resource_s { CS_DES
		// CS_Header; } CS_RESOURCE, *PCS_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.CS_Resource_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct CS_RESOURCE
		{
			/// <summary>A CS_DES structure.</summary>
			public CS_DES CS_Header;
		}

		/// <summary>
		/// The DMA_DES structure is used for specifying either a resource list or a resource requirements list that describes direct memory
		/// access (DMA) channel usage for a device instance. For more information about resource lists and resource requirements lists, see
		/// Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-dma_des typedef struct DMA_Des_s { DWORD DD_Count; DWORD
		// DD_Type; DWORD DD_Flags; ULONG DD_Alloc_Chan; } DMA_DES, *PDMA_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.DMA_Des_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DMA_DES
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the DMA_RESOURCE structure.</para>
			/// </summary>
			public uint DD_Count;

			/// <summary>Must be set to the constant value <c>DType_Range</c>.</summary>
			public uint DD_Type;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>Channel Width Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_BYTE</term>
			/// <term>8-bit DMA channel.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_WORD</term>
			/// <term>16-bit DMA channel.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_DWORD</term>
			/// <term>32-bit DMA channel.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_BYTE_AND_WORD</term>
			/// <term>8-bit and 16-bit DMA channel.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mDD_Width</term>
			/// <term>Bitmask for the bits within DD_Flags that specify the channel width value.</term>
			/// </item>
			/// <item>
			/// <term>Bus Mastering Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_NoBusMaster</term>
			/// <term>No bus mastering.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_BusMaster</term>
			/// <term>Bus mastering.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mDD_BusMaster</term>
			/// <term>Bitmask for the bits within DD_Flags that specify the bus mastering value.</term>
			/// </item>
			/// <item>
			/// <term>DMA Type Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_TypeStandard</term>
			/// <term>Standard DMA.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_TypeA</term>
			/// <term>Type A DMA.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_TypeB</term>
			/// <term>Type B DMA.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fDD_TypeF</term>
			/// <term>Type F DMA.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mDD_Type</term>
			/// <term>Bitmask for the bits within DD_Flags that specify the DMA type value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DMA_DES_FLAGS DD_Flags;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The DMA channel allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Not used.</para>
			/// </summary>
			public uint DD_Alloc_Chan;
		}

		/// <summary>
		/// The DMA_RANGE structure specifies a resource requirements list that describes DMA channel usage for a device instance. For more
		/// information about resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-dma_range typedef struct DMA_Range_s { ULONG DR_Min;
		// ULONG DR_Max; ULONG DR_Flags; } DMA_RANGE, *PDMA_RANGE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.DMA_Range_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DMA_RANGE
		{
			/// <summary>The lowest-numbered DMA channel that can be allocated to the device.</summary>
			public uint DR_Min;

			/// <summary>The highest-numbered DMA channel that can be allocated to the device.</summary>
			public uint DR_Max;

			/// <summary>One bit flag from DMA_DES structure.</summary>
			public uint DR_Flags;
		}

		/// <summary>
		/// The DMA_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes DMA
		/// channel usage for a device instance. For more information about resource list and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-dma_resource typedef struct DMA_Resource_s { DMA_DES
		// DMA_Header; DMA_RANGE DMA_Data[ANYSIZE_ARRAY]; } DMA_RESOURCE, *PDMA_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.DMA_Resource_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DMA_RESOURCE>), "*")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DMA_RESOURCE
		{
			/// <summary>A DMA_DES structure.</summary>
			public DMA_DES DMA_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>A DMA_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public DMA_RANGE[] DMA_Data;
		}

		/// <summary>
		/// The IO_DES structure is used for specifying either a resource list or a resource requirements list that describes I/O port usage
		/// for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-io_des typedef struct IO_Des_s { DWORD IOD_Count; DWORD
		// IOD_Type; DWORDLONG IOD_Alloc_Base; DWORDLONG IOD_Alloc_End; DWORD IOD_DesFlags; } IO_DES, *PIO_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IO_Des_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct IO_DES
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the IO_RANGE array that is included in the IO_RESOURCE structure.</para>
			/// </summary>
			public uint IOD_Count;

			/// <summary>Must be set to the constant value <c>IOType_Range</c>.</summary>
			public uint IOD_Type;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The lowest-numbered of a range of contiguous I/O port addresses allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public ulong IOD_Alloc_Base;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The highest-numbered of a range of contiguous I/O port addresses allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public ulong IOD_Alloc_End;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>Port Type Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_IO</term>
			/// <term>The device is accessed in I/O address space.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_Memory</term>
			/// <term>The device is accessed in memory address space.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_PortType</term>
			/// <term>Bitmask for the bits within IOD_DesFlags that specify the port type value.</term>
			/// </item>
			/// <item>
			/// <term>Decode Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_10_BIT_DECODE</term>
			/// <term>The device decodes 10 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_12_BIT_DECODE</term>
			/// <term>The device decodes 12 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_16_BIT_DECODE</term>
			/// <term>The device decodes 16 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_POSITIVE_DECODE</term>
			/// <term>The device uses "positive decode" instead of "subtractive decode."</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIOD_DECODE</term>
			/// <term>Bitmask for the bits within IOD_DesFlags that specify the decode value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IO_DES_FLAGS IOD_DesFlags;
		}

		/// <summary>
		/// The IO_RANGE structure specifies a resource requirements list that describes I/O port usage for a device instance. For more
		/// information about resource requirements lists, see Hardware Resources.
		/// </summary>
		/// <remarks>
		/// The flags specified for <c>IOR_Alias</c> have the same interpretation as the address decoding flags specified for
		/// <c>IOD_DesFlags</c>. (However, the two sets of flags are not equivalent in assigned values and cannot be used interchangeably.)
		/// A resource requirements list can be specified using either set of flags, but using decode flags in <c>IOD_DesFlags</c> is
		/// recommended. If address decoding flags are specified using both <c>IOD_DesFlags</c> and <c>IOR_Alias</c>, contents of the latter
		/// overrides the former.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-io_range typedef struct IO_Range_s { DWORDLONG IOR_Align;
		// DWORD IOR_nPorts; DWORDLONG IOR_Min; DWORDLONG IOR_Max; DWORD IOR_RangeFlags; DWORDLONG IOR_Alias; } IO_RANGE, *PIO_RANGE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IO_Range_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct IO_RANGE
		{
			/// <summary>Mask used to specify the port address boundary on which the first allocated I/O port address must be aligned.</summary>
			public ulong IOR_Align;

			/// <summary>The number of I/O port addresses required by the device.</summary>
			public uint IOR_nPorts;

			/// <summary>The lowest-numbered of a range of contiguous I/O port addresses that can be allocated to the device.</summary>
			public ulong IOR_Min;

			/// <summary>The highest-numbered of a range of contiguous I/O port addresses that can be allocated to the device.</summary>
			public ulong IOR_Max;

			/// <summary>One bit flag from IO_DES structure. For more information, see the following <c>Remarks</c> section.</summary>
			public uint IOR_RangeFlags;

			/// <summary>
			/// <para>One of the bit flags described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>IO_ALIAS_10_BIT_DECODE</term>
			/// <term>The device decodes 10 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term>IO_ALIAS_12_BIT_DECODE</term>
			/// <term>The device decodes 12 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term>IO_ALIAS_16_BIT_DECODE</term>
			/// <term>The device decodes 16 bits of the port address.</term>
			/// </item>
			/// <item>
			/// <term>IO_ALIAS_POSITIVE_DECODE</term>
			/// <term>The device uses "positive decode" instead of "subtractive decode."</term>
			/// </item>
			/// </list>
			/// <para>For more information, see the following <c>Remarks</c> section.</para>
			/// </summary>
			public ulong IOR_Alias;
		}

		/// <summary>
		/// The IO_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes I/O port
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-io_resource typedef struct IO_Resource_s { IO_DES
		// IO_Header; IO_RANGE IO_Data[ANYSIZE_ARRAY]; } IO_RESOURCE, *PIO_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IO_Resource_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IO_RESOURCE>), "*")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct IO_RESOURCE
		{
			/// <summary>An IO_DES structure.</summary>
			public IO_DES IO_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>An IO_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IO_RANGE[] IO_Data;
		}

		/// <summary>
		/// The IRQ_DES structure is used for specifying either a resource list or a resource requirements list that describes IRQ line
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-irq_des_32 typedef struct IRQ_Des_32_s { DWORD
		// IRQD_Count; DWORD IRQD_Type; #if ... USHORT IRQD_Flags; USHORT IRQD_Group; #else DWORD IRQD_Flags; #endif ULONG IRQD_Alloc_Num;
		// ULONG32 IRQD_Affinity; } IRQ_DES_32, *PIRQ_DES_32;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IRQ_Des_32_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IRQ_DES_32
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the IRQ_RANGE array that is included in the IRQ_RESOURCE structure.</para>
			/// </summary>
			public uint IRQD_Count;

			/// <summary>Must be set to the constant value <c>IRQType_Range</c>.</summary>
			public uint IRQD_Type;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>Sharing Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Exclusive</term>
			/// <term>The IRQ line cannot be shared.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Share</term>
			/// <term>The IRQ line can be shared.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mIRQD_Share</term>
			/// <term>Bitmask for the bits within IRQD_Flags that specify the sharing value.</term>
			/// </item>
			/// <item>
			/// <term>Triggering Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Level</term>
			/// <term>The IRQ line is level-triggered.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Edge</term>
			/// <term>The IRQ line is edge-triggered.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mIRQD_Edge_Level</term>
			/// <term>Bitmask for the bits within IRQD_Flags that specify the triggering value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IRQD_FLAGS IRQD_Flags;

			/// <summary>Group number of interrupt target.</summary>
			public ushort IRQD_Group;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The number of the IRQ line that is allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Not used.</para>
			/// </summary>
			public uint IRQD_Alloc_Num;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>
			/// A bitmask representing the processor affinity of the IRQ line that is allocated to the device. Bit zero represents the first
			/// processor, bit two the second, and so on. Set this value to -1 to represent all processors.
			/// </para>
			/// <para>For a resource requirements list:</para>
			/// <para>Not used.</para>
			/// </summary>
			public uint IRQD_Affinity;
		}

		/// <summary>
		/// The IRQ_DES structure is used for specifying either a resource list or a resource requirements list that describes IRQ line
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-irq_des_64 typedef struct IRQ_Des_64_s { DWORD
		// IRQD_Count; DWORD IRQD_Type; #if ... USHORT IRQD_Flags; USHORT IRQD_Group; #else DWORD IRQD_Flags; #endif ULONG IRQD_Alloc_Num;
		// ULONG64 IRQD_Affinity; } IRQ_DES_64, *PIRQ_DES_64;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IRQ_Des_64_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IRQ_DES_64
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the IRQ_RESOURCE structure.</para>
			/// </summary>
			public uint IRQD_Count;

			/// <summary>Must be set to the constant value <c>IRQType_Range</c>.</summary>
			public uint IRQD_Type;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>Sharing Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Exclusive</term>
			/// <term>The IRQ line cannot be shared.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Share</term>
			/// <term>The IRQ line can be shared.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mIRQD_Share</term>
			/// <term>Bitmask for the bits within IRQD_Flags that specify the sharing value.</term>
			/// </item>
			/// <item>
			/// <term>Triggering Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Level</term>
			/// <term>The IRQ line is level-triggered.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fIRQD_Edge</term>
			/// <term>The IRQ line is edge-triggered.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mIRQD_Edge_Level</term>
			/// <term>Bitmask for the bits within IRQD_Flags that specify the triggering value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IRQD_FLAGS IRQD_Flags;

			/// <summary>Group number of interrupt target.</summary>
			public ushort IRQD_Group;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The number of the IRQ line that is allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Not used.</para>
			/// </summary>
			public uint IRQD_Alloc_Num;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>
			/// A bitmask representing the processor affinity of the IRQ line that is allocated to the device. Bit zero represents the first
			/// processor, bit two the second, and so on. Set this value to -1 to represent all processors.
			/// </para>
			/// <para>For a resource requirements list:</para>
			/// <para>Not used.</para>
			/// </summary>
			public ulong IRQD_Affinity;
		}

		/// <summary>
		/// The IRQ_RANGE structure specifies a resource requirements list that describes IRQ line usage for a device instance. For more
		/// information about resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-irq_range typedef struct IRQ_Range_s { ULONG IRQR_Min;
		// ULONG IRQR_Max; #if ... USHORT IRQR_Flags; USHORT IRQR_Rsvdz; #else ULONG IRQR_Flags; #endif } IRQ_RANGE, *PIRQ_RANGE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IRQ_Range_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IRQ_RANGE
		{
			/// <summary>The lowest-numbered of a range of contiguous IRQ lines that can be allocated to the device.</summary>
			public uint IRQR_Min;

			/// <summary>The highest-numbered of a range of contiguous IRQ lines that can be allocated to the device.</summary>
			public uint IRQR_Max;

			/// <summary>One bit flag from IRQ_DES structure.</summary>
			public IRQD_FLAGS IRQR_Flags;

			/// <summary/>
			public ushort IRQR_Rsvdz;
		}

		/// <summary>
		/// The IRQ_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes IRQ line
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-irq_resource_32 typedef struct IRQ_Resource_32_s {
		// IRQ_DES_32 IRQ_Header; IRQ_RANGE IRQ_Data[ANYSIZE_ARRAY]; } IRQ_RESOURCE_32, *PIRQ_RESOURCE_32;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IRQ_Resource_32_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IRQ_RESOURCE_32>), "*")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IRQ_RESOURCE_32
		{
			/// <summary>An IRQ_DES structure.</summary>
			public IRQ_DES_32 IRQ_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>An IRQ_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IRQ_RANGE[] IRQ_Data;
		}

		/// <summary>
		/// The IRQ_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes IRQ line
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-irq_resource_64 typedef struct IRQ_Resource_64_s {
		// IRQ_DES_64 IRQ_Header; IRQ_RANGE IRQ_Data[ANYSIZE_ARRAY]; } IRQ_RESOURCE_64, *PIRQ_RESOURCE_64;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.IRQ_Resource_64_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IRQ_RESOURCE_64>), "*")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct IRQ_RESOURCE_64
		{
			/// <summary>An IRQ_DES structure.</summary>
			public IRQ_DES_64 IRQ_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>An IRQ_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IRQ_RANGE[] IRQ_Data;
		}

		/// <summary>
		/// The MEM_DES structure is used for specifying either a resource list or a resource requirements list that describes memory usage
		/// for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-mem_des typedef struct Mem_Des_s { DWORD MD_Count; DWORD
		// MD_Type; DWORDLONG MD_Alloc_Base; DWORDLONG MD_Alloc_End; DWORD MD_Flags; DWORD MD_Reserved; } MEM_DES, *PMEM_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.Mem_Des_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MEM_DES
		{
			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>The number of elements in the MEM_RANGE array that is included in the MEM_RESOURCE structure.</para>
			/// </summary>
			public uint MD_Count;

			/// <summary>Must be set to the constant value <c>MType_Range</c>.</summary>
			public uint MD_Type;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The lowest-numbered of a range of contiguous physical memory addresses allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public ulong MD_Alloc_Base;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>The highest-numbered of a range of contiguous physical memory addresses allocated to the device.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>Zero.</para>
			/// </summary>
			public ulong MD_Alloc_End;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>Read-Only Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_ROM</term>
			/// <term>The specified memory range is read-only.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_RAM</term>
			/// <term>The specified memory range is not read-only.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_MemoryType</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the read-only attribute.</term>
			/// </item>
			/// <item>
			/// <term>Write-Only Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_ReadDisallowed</term>
			/// <term>The specified memory range is write-only.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_ReadAllowed</term>
			/// <term>The specified memory range is not write-only.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_Readable</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the write-only attribute.</term>
			/// </item>
			/// <item>
			/// <term>Address Size Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_24</term>
			/// <term>24-bit addressing (not used).</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_32</term>
			/// <term>32-bit addressing.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_32_24</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the address size.</term>
			/// </item>
			/// <item>
			/// <term>Prefetch Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_PrefetchAllowed</term>
			/// <term>The specified memory range can be prefetched.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_PrefetchDisallowed</term>
			/// <term>The specified memory range cannot be prefetched.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_Prefetchable</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the prefetch ability.</term>
			/// </item>
			/// <item>
			/// <term>Caching Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_Cacheable</term>
			/// <term>The specified memory range can be cached.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_NonCacheable</term>
			/// <term>The specified memory range cannot be cached.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_Cacheable</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the caching ability.</term>
			/// </item>
			/// <item>
			/// <term>Combined-Write Caching Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_CombinedWriteAllowed</term>
			/// <term>Combined-write caching is allowed.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fMD_CombinedWriteDisallowed</term>
			/// <term>Combined-write caching is not allowed.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mMD_CombinedWrite</term>
			/// <term>Bitmask for the bit within MD_Flags that specifies the combine-write caching ability.</term>
			/// </item>
			/// </list>
			/// </summary>
			public MEM_DES_FLAGS MD_Flags;

			/// <summary>For internal use only.</summary>
			public uint MD_Reserved;
		}

		/// <summary>
		/// The MEM_RANGE structure specifies a resource requirements list that describes memory usage for a device instance. For more
		/// information about resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-mem_range typedef struct Mem_Range_s { DWORDLONG
		// MR_Align; ULONG MR_nBytes; DWORDLONG MR_Min; DWORDLONG MR_Max; DWORD MR_Flags; DWORD MR_Reserved; } MEM_RANGE, *PMEM_RANGE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.Mem_Range_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MEM_RANGE
		{
			/// <summary>Mask used to specify the memory address boundary on which the first allocated memory address must be aligned.</summary>
			public ulong MR_Align;

			/// <summary>The number of bytes of memory required by the device.</summary>
			public uint MR_nBytes;

			/// <summary>The lowest-numbered of a range of contiguous memory addresses that can be allocated to the device.</summary>
			public ulong MR_Min;

			/// <summary>The highest-numbered of a range of contiguous memory addresses that can be allocated to the device.</summary>
			public ulong MR_Max;

			/// <summary>One bit flag from MEM_DES structure.</summary>
			public MEM_DES_FLAGS MR_Flags;

			/// <summary>For internal use only.</summary>
			public uint MR_Reserved;
		}

		/// <summary>
		/// The MEM_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes memory
		/// usage for a device instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-mem_resource typedef struct Mem_Resource_s { MEM_DES
		// MEM_Header; MEM_RANGE MEM_Data[ANYSIZE_ARRAY]; } MEM_RESOURCE, *PMEM_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.Mem_Resource_s")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<MEM_RESOURCE>), "*")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct MEM_RESOURCE
		{
			/// <summary>A MEM_DES structure.</summary>
			public MEM_DES MEM_Header;

			/// <summary>
			/// <para>For a resource list:</para>
			/// <para>Zero.</para>
			/// <para>For a resource requirements list:</para>
			/// <para>A MEM_RANGE array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public MEM_RANGE[] MEM_Data;
		}

		/// <summary>
		/// The MFCARD_DES structure is used for specifying either a resource list or a resource requirements list that describes resource
		/// usage by one of the hardware functions provided by an instance of a multifunction device. For more information about resource
		/// lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-mfcard_des typedef struct MfCard_Des_s { DWORD PMF_Count;
		// DWORD PMF_Type; DWORD PMF_Flags; BYTE PMF_ConfigOptions; BYTE PMF_IoResourceIndex; BYTE PMF_Reserved[2]; DWORD
		// PMF_ConfigRegisterBase; } MFCARD_DES, *PMFCARD_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.MfCard_Des_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MFCARD_DES
		{
			/// <summary>Must be 1.</summary>
			public uint PMF_Count;

			/// <summary>Not used.</summary>
			public uint PMF_Type;

			/// <summary>
			/// <para>One bit flag is defined, as described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>fPMF_AUDIO_ENABLE</term>
			/// <term>If set, audio is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint PMF_Flags;

			/// <summary>Contents of the 8-bit PCMCIA Configuration Option Register.</summary>
			public byte PMF_ConfigOptions;

			/// <summary>
			/// Zero-based index indicating the IO_RESOURCE structure that describes the I/O resources for the hardware function being
			/// described by this MFCARD_DES structure.
			/// </summary>
			public byte PMF_IoResourceIndex;

			/// <summary>Not used.</summary>
			public ushort PMF_Reserved;

			/// <summary>Offset from the beginning of the card's attribute memory space to the base configuration register address.</summary>
			public uint PMF_ConfigRegisterBase;
		}

		/// <summary>
		/// The MFCARD_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes
		/// resource usage by one of the hardware functions provided by an instance of a multifunction device. For more information about
		/// resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-mfcard_resource typedef struct MfCard_Resource_s {
		// MFCARD_DES MfCard_Header; } MFCARD_RESOURCE, *PMFCARD_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.MfCard_Resource_s")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MFCARD_RESOURCE
		{
			/// <summary>A MFCARD_DES structure.</summary>
			public MFCARD_DES MfCard_Header;
		}

		/// <summary>
		/// The PCCARD_DES structure is used for specifying either a resource list or a resource requirements list that describes resource
		/// usage by a PC Card instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-pccard_des typedef struct PcCard_Des_s { DWORD PCD_Count;
		// DWORD PCD_Type; DWORD PCD_Flags; BYTE PCD_ConfigIndex; BYTE PCD_Reserved[3]; DWORD PCD_MemoryCardBase1; DWORD
		// PCD_MemoryCardBase2; DWORD PCD_MemoryCardBase[PCD_MAX_MEMORY]; WORD PCD_MemoryFlags[PCD_MAX_MEMORY]; BYTE
		// PCD_IoFlags[PCD_MAX_IO]; } PCCARD_DES, *PPCCARD_DES;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.PcCard_Des_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct PCCARD_DES
		{
			private const int PCD_MAX_MEMORY = 2;
			private const int PCD_MAX_IO = 2;

			/// <summary>Must be 1.</summary>
			public uint PCD_Count;

			/// <summary>Not used.</summary>
			public uint PCD_Type;

			/// <summary>
			/// <para>One bit flag from each of the flag sets described in the following table.</para>
			/// <list type="table">
			/// <listheader>
			/// <term/>
			/// <term>Flag</term>
			/// <term>Definition</term>
			/// </listheader>
			/// <item>
			/// <term>I/O Addressing Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fPCD_IO_8</term>
			/// <term>The device uses 8-bit I/O addressing.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fPCD_IO_16</term>
			/// <term>The device uses 16-bit I/O addressing.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mPCD_IO_8_16</term>
			/// <term>Bitmask for the bit within PCD_Flags that specifies 8-bit or 16-bit I/O addressing.</term>
			/// </item>
			/// <item>
			/// <term>Memory Addressing Flags</term>
			/// <term/>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fPCD_MEM_8</term>
			/// <term>The device uses 8-bit memory addressing.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>fPCD_MEM_16</term>
			/// <term>The device uses 16-bit memory addressing.</term>
			/// </item>
			/// <item>
			/// <term/>
			/// <term>mPCD_MEM_8_16</term>
			/// <term>Bitmask for the bit within PCD_Flags that specifies 8-bit or 16-bit memory addressing.</term>
			/// </item>
			/// </list>
			/// </summary>
			public PCD_FLAGS PCD_Flags;

			/// <summary>The 8-bit index value used to locate the device's configuration.</summary>
			public byte PCD_ConfigIndex;

			/// <summary>Not used.</summary>
			public byte PCD_Reserved1;

			/// <summary>Not used.</summary>
			public ushort PCD_Reserved2;

			/// <summary>Optional, card base address of the first memory window.</summary>
			public uint PCD_MemoryCardBase1;

			/// <summary>Optional, card base address of the second memory window.</summary>
			public uint PCD_MemoryCardBase2;

			/// <summary>This member is currently unused.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = PCD_MAX_MEMORY)]
			public uint[] PCD_MemoryCardBase;

			/// <summary>This member is currently unused.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = PCD_MAX_MEMORY)]
			public ushort[] PCD_MemoryFlags;

			/// <summary>This member is currently unused.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = PCD_MAX_IO)]
			public byte[] PCD_IoFlags;
		}

		/// <summary>
		/// The PCCARD_RESOURCE structure is used for specifying either a resource list or a resource requirements list that describes
		/// resource usage by a PC Card instance. For more information about resource lists and resource requirements lists, see Hardware Resources.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/ns-cfgmgr32-pccard_resource typedef struct PcCard_Resource_s {
		// PCCARD_DES PcCard_Header; } PCCARD_RESOURCE, *PPCCARD_RESOURCE;
		[PInvokeData("cfgmgr32.h", MSDNShortId = "NS:cfgmgr32.PcCard_Resource_s")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct PCCARD_RESOURCE
		{
			/// <summary>A PCCARD_DES structure.</summary>
			public PCCARD_DES PcCard_Header;
		}
	}
}