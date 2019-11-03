using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.PInvoke
{
	/// <summary>
	/// Contains flag bits that are specific to the resource type, as indicated in the following table. Flags can be bitwise-ORed together as appropriate.
	/// </summary>
	[PInvokeData("wdm.h")]
	[Flags]
	public enum CM_RESOURCE : ushort
	{
		CM_RESOURCE_INTERRUPT_LEVEL_SENSITIVE = 0x00,
		CM_RESOURCE_INTERRUPT_LATCHED = 0x01,
		CM_RESOURCE_INTERRUPT_MESSAGE = 0x02,
		CM_RESOURCE_INTERRUPT_POLICY_INCLUDED = 0x04,
		CM_RESOURCE_INTERRUPT_SECONDARY_INTERRUPT = 0x10,
		CM_RESOURCE_INTERRUPT_WAKE_HINT = 0x20,
		CM_RESOURCE_INTERRUPT_LEVEL_LATCHED_BITS = 0x0001,
		CM_RESOURCE_INTERRUPT_MESSAGE_TOKEN = 0xFFFE,
		CM_RESOURCE_MEMORY_READ_WRITE = 0x0000,
		CM_RESOURCE_MEMORY_READ_ONLY = 0x0001,
		CM_RESOURCE_MEMORY_WRITE_ONLY = 0x0002,
		CM_RESOURCE_MEMORY_WRITEABILITY_MASK = 0x0003,
		CM_RESOURCE_MEMORY_PREFETCHABLE = 0x0004,
		CM_RESOURCE_MEMORY_COMBINEDWRITE = 0x0008,
		CM_RESOURCE_MEMORY_24 = 0x0010,
		CM_RESOURCE_MEMORY_CACHEABLE = 0x0020,
		CM_RESOURCE_MEMORY_WINDOW_DECODE = 0x0040,
		CM_RESOURCE_MEMORY_BAR = 0x0080,
		CM_RESOURCE_MEMORY_COMPAT_FOR_INACCESSIBLE_RANGE = 0x0100,
		CM_RESOURCE_MEMORY_LARGE = 0x0E00,
		CM_RESOURCE_MEMORY_LARGE_40 = 0x0200,
		CM_RESOURCE_MEMORY_LARGE_48 = 0x0400,
		CM_RESOURCE_MEMORY_LARGE_64 = 0x0800,
		CM_RESOURCE_PORT_MEMORY = 0x0000,
		CM_RESOURCE_PORT_IO = 0x0001,
		CM_RESOURCE_PORT_10_BIT_DECODE = 0x0004,
		CM_RESOURCE_PORT_12_BIT_DECODE = 0x0008,
		CM_RESOURCE_PORT_16_BIT_DECODE = 0x0010,
		CM_RESOURCE_PORT_POSITIVE_DECODE = 0x0020,
		CM_RESOURCE_PORT_PASSIVE_DECODE = 0x0040,
		CM_RESOURCE_PORT_WINDOW_DECODE = 0x0080,
		CM_RESOURCE_PORT_BAR = 0x0100,
		CM_RESOURCE_DMA_8 = 0x0000,
		CM_RESOURCE_DMA_16 = 0x0001,
		CM_RESOURCE_DMA_32 = 0x0002,
		CM_RESOURCE_DMA_8_AND_16 = 0x0004,
		CM_RESOURCE_DMA_BUS_MASTER = 0x0008,
		CM_RESOURCE_DMA_TYPE_A = 0x0010,
		CM_RESOURCE_DMA_TYPE_B = 0x0020,
		CM_RESOURCE_DMA_TYPE_F = 0x0040,
		CM_RESOURCE_DMA_V3 = 0x0080,
		DMAV3_TRANFER_WIDTH_8 = 0x00,
		DMAV3_TRANFER_WIDTH_16 = 0x01,
		DMAV3_TRANFER_WIDTH_32 = 0x02,
		DMAV3_TRANFER_WIDTH_64 = 0x03,
		DMAV3_TRANFER_WIDTH_128 = 0x04,
		DMAV3_TRANFER_WIDTH_256 = 0x05,
		CM_RESOURCE_CONNECTION_CLASS_GPIO = 0x01,
		CM_RESOURCE_CONNECTION_CLASS_SERIAL = 0x02,
		CM_RESOURCE_CONNECTION_CLASS_FUNCTION_CONFIG = 0x03,
		CM_RESOURCE_CONNECTION_TYPE_GPIO_IO = 0x02,
		CM_RESOURCE_CONNECTION_TYPE_SERIAL_I2C = 0x01,
		CM_RESOURCE_CONNECTION_TYPE_SERIAL_SPI = 0x02,
		CM_RESOURCE_CONNECTION_TYPE_SERIAL_UART = 0x03,
		CM_RESOURCE_CONNECTION_TYPE_FUNCTION_CONFIG = 0x01,
	}

	/// <summary>Indicates whether the described resource can be shared.</summary>
	[PInvokeData("wdm.h")]
	public enum CM_SHARE_DISPOSITION : byte
	{
		/// <summary>Undetermined.</summary>
		CmResourceShareUndetermined = 0,

		/// <summary>The device requires exclusive use of the resource.</summary>
		CmResourceShareDeviceExclusive,

		/// <summary>The driver requires exclusive use of the resource. (Not supported for WDM drivers.)</summary>
		CmResourceShareDriverExclusive,

		/// <summary>The resource can be shared without restriction.</summary>
		CmResourceShareShared
	}

	/// <summary>
	/// Identifies the resource type. The constant value specified for Type indicates which structure within the u union is valid, as
	/// indicated in the following table. (These flags are used within both CM_PARTIAL_RESOURCE_DESCRIPTOR and IO_RESOURCE_DESCRIPTOR
	/// structures, except where noted.)
	/// </summary>
	[PInvokeData("wdm.h")]
	[Flags]
	public enum CmResourceType : byte
	{
		/// <summary>No value is set.</summary>
		CmResourceTypeNull = 0,

		/// <summary>u.Port</summary>
		CmResourceTypePort = 1,

		/// <summary>
		/// u.Interrupt or u.MessageInterrupt. If the CM_RESOURCE_INTERRUPT_MESSAGE flag of Flags is set, use u.MessageInterrupt; otherwise,
		/// use u.Interrupt.
		/// </summary>
		CmResourceTypeInterrupt = 2,

		/// <summary>u.Memory</summary>
		CmResourceTypeMemory = 3,

		/// <summary>u.Dma (if CM_RESOURCE_DMA_V3 is not set) or u.DmaV3 (if CM_RESOURCE_DMA_V3 flag is set)</summary>
		CmResourceTypeDma = 4,

		/// <summary>u.DeviceSpecificData(Not used within IO_RESOURCE_DESCRIPTOR.)</summary>
		CmResourceTypeDeviceSpecific = 5,

		/// <summary>u.BusNumber</summary>
		CmResourceTypeBusNumber = 6,

		/// <summary>
		/// One of u.Memory40, u.Memory48, or u.Memory64.The CM_RESOURCE_MEMORY_LARGE_XXX flags set in the Flags member determines which
		/// structure is used.
		/// </summary>
		CmResourceTypeMemoryLarge = 7,

		/// <summary>Not used.</summary>
		CmResourceTypeNonArbitrated = 128,

		/// <summary>Reserved for system use.</summary>
		CmResourceTypeConfigData = 128,

		/// <summary>u.DevicePrivate</summary>
		CmResourceTypeDevicePrivate = 129,

		/// <summary>u.DevicePrivate</summary>
		CmResourceTypePcCardConfig = 130,

		/// <summary>u.DevicePrivate</summary>
		CmResourceTypeMfCardConfig = 131,

		/// <summary>u.Connection</summary>
		CmResourceTypeConnection = 132,
	}

	/// <summary>The <c>INTERFACE_TYPE</c> enumeration indicates the bus type.</summary>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ne-wdm-_interface_type typedef enum _INTERFACE_TYPE {
	// InterfaceTypeUndefined, Internal, Isa, Eisa, MicroChannel, TurboChannel, PCIBus, VMEBus, NuBus, PCMCIABus, CBus, MPIBus, MPSABus,
	// ProcessorInternal, InternalPowerBus, PNPISABus, PNPBus, Vmcs, ACPIBus, MaximumInterfaceType } INTERFACE_TYPE, *PINTERFACE_TYPE;
	[PInvokeData("wdm.h", MSDNShortId = "4d20f3fd-d06e-420b-af69-9ef34addc611")]
	public enum INTERFACE_TYPE
	{
		/// <summary>Indicates that the interface type is undefined.</summary>
		InterfaceTypeUndefined = -1,

		/// <summary>For internal use only.</summary>
		Internal,

		/// <summary>Indicates that the interface is published by the ISA bus driver.</summary>
		Isa,

		/// <summary>Indicates that the interface is published by the EISA bus driver.</summary>
		Eisa,

		/// <summary>Indicates that the interface is published by the MicroChannel bus driver.</summary>
		MicroChannel,

		/// <summary>Indicates that the interface is published by the TurboChannel bus driver.</summary>
		TurboChannel,

		/// <summary>Indicates that the interface is published by the PCI bus driver.</summary>
		PCIBus,

		/// <summary>Indicates that the interface is published by the VME bus driver.</summary>
		VMEBus,

		/// <summary>Indicates that the interface is published by the NuBus driver.</summary>
		NuBus,

		/// <summary>Indicates that the interface is published by the PCMCIA bus driver.</summary>
		PCMCIABus,

		/// <summary>Indicates that the interface is published by the Cbus driver.</summary>
		CBus,

		/// <summary>Indicates that the interface is published by the MPI bus driver.</summary>
		MPIBus,

		/// <summary>Indicates that the interface is published by the MPSA bus driver.</summary>
		MPSABus,

		/// <summary>Indicates that the interface is published by the ISA bus driver.</summary>
		ProcessorInternal,

		/// <summary>
		/// Indicates that the interface is published for an internal power bus. Some devices have power control ports that allow them to
		/// share power control with other devices. The Windows architecture represents these devices as slots on a virtual bus called an
		/// "internal power bus."
		/// </summary>
		InternalPowerBus,

		/// <summary>Indicates that the interface is published by the PNPISA bus driver.</summary>
		PNPISABus,

		/// <summary>Indicates that the interface is published by the PNP bus driver.</summary>
		PNPBus,

		/// <summary>Reserved for use by the operating system.</summary>
		Vmcs,

		/// <summary>
		/// Indicates that the interface is published by the ACPI bus driver. The ACPI bus driver enumerates devices that are described in
		/// the ACPI firmware of the hardware platform. These devices might physically reside on buses that are controlled by other bus
		/// drivers, but the ACPI bus driver must enumerate these devices because the other bus drivers cannot detect them. This interface
		/// type is defined starting with Windows 8.
		/// </summary>
		ACPIBus,

		/// <summary>Marks the upper limit of the possible bus types.</summary>
		MaximumInterfaceType,
	}

	/// <summary>
	/// <para>
	/// The <c>CM_FULL_RESOURCE_DESCRIPTOR</c> structure specifies a set of system hardware resources of various types, assigned to a device
	/// that is connected to a specific bus. This structure is contained within a CM_RESOURCE_LIST structure.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_cm_full_resource_descriptor typedef struct
	// _CM_FULL_RESOURCE_DESCRIPTOR { INTERFACE_TYPE InterfaceType; ULONG BusNumber; CM_PARTIAL_RESOURCE_LIST PartialResourceList; }
	// CM_FULL_RESOURCE_DESCRIPTOR, *PCM_FULL_RESOURCE_DESCRIPTOR;
	[PInvokeData("wdm.h", MSDNShortId = "e405c545-da0c-4b47-84c2-dd26d746da94")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CM_FULL_RESOURCE_DESCRIPTOR
	{
		/// <summary>
		/// Specifies the type of bus to which the device is connected. This must be one of the types defined by INTERFACE_TYPE, in Wdm.h or
		/// Ntddk.h. (Not used by WDM drivers.)
		/// </summary>
		public INTERFACE_TYPE InterfaceType;

		/// <summary>
		/// The system-assigned, driver-supplied, zero-based number of the bus to which the device is connected. (Not used by WDM drivers.)
		/// </summary>
		public uint BusNumber;

		/// <summary>A CM_PARTIAL_RESOURCE_LIST structure.</summary>
		public CM_PARTIAL_RESOURCE_LIST PartialResourceList;
	}

	/// <summary>
	/// The <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> structure specifies one or more system hardware resources, of a single type, assigned to a
	/// device. This structure is used to create an array within a CM_PARTIAL_RESOURCE_LIST structure.
	/// </summary>
	/// <remarks>
	/// A <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> structure can describe either a raw (bus-relative) resource or a translated (system physical)
	/// resource, depending on the routine or IRP with which it is being used. For more information, see Raw and Translated Resources and IRP_MN_START_DEVICE.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_cm_partial_resource_descriptor typedef struct
	// _CM_PARTIAL_RESOURCE_DESCRIPTOR { UCHAR Type; UCHAR ShareDisposition; USHORT Flags; union { struct { long Start; ULONG Length; }
	// Generic; struct { long Start; ULONG Length; } Port; struct { #if ... USHORT Level; USHORT Group; #else ULONG Level; #endif ULONG
	// Vector; UIntPtr Affinity; } Interrupt; struct { union { struct { USHORT Group; USHORT Reserved; USHORT MessageCount; ULONG Vector;
	// UIntPtr Affinity; } Raw; struct { #if ... USHORT Level; USHORT Group; #else ULONG Level; #endif ULONG Vector; UIntPtr Affinity; }
	// Translated; } DUMMYUNIONNAME; } MessageInterrupt; struct { long Start; ULONG Length; } Memory; struct { ULONG Channel; ULONG Port;
	// ULONG Reserved1; } Dma; struct { ULONG Channel; ULONG RequestLine; UCHAR TransferWidth; UCHAR Reserved1; UCHAR Reserved2; UCHAR
	// Reserved3; } DmaV3; struct { ULONG Data[3]; } DevicePrivate; struct { ULONG Start; ULONG Length; ULONG Reserved; } BusNumber; struct {
	// ULONG DataSize; ULONG Reserved1; ULONG Reserved2; } DeviceSpecificData; struct { long Start; ULONG Length40; } Memory40; struct { long
	// Start; ULONG Length48; } Memory48; struct { long Start; ULONG Length64; } Memory64; struct { UCHAR Class; UCHAR Type; UCHAR Reserved1;
	// UCHAR Reserved2; ULONG IdLowPart; ULONG IdHighPart; } Connection; } u; } CM_PARTIAL_RESOURCE_DESCRIPTOR, *PCM_PARTIAL_RESOURCE_DESCRIPTOR;
	[PInvokeData("wdm.h", MSDNShortId = "96bf7bab-b8f5-439c-8717-ea6956ed0213")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CM_PARTIAL_RESOURCE_DESCRIPTOR
	{
		public const ulong CM_RESOURCE_MEMORY_LARGE_40_MAXLEN = 0x000000FFFFFFFF00;
		public const ulong CM_RESOURCE_MEMORY_LARGE_48_MAXLEN = 0x0000FFFFFFFF0000;
		public const ulong CM_RESOURCE_MEMORY_LARGE_64_MAXLEN = 0xFFFFFFFF00000000;

		/// <summary>
		/// <para>
		/// Identifies the resource type. The constant value specified for <c>Type</c> indicates which structure within the <c>u</c> union is
		/// valid, as indicated in the following table. (These flags are used within both <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> and
		/// IO_RESOURCE_DESCRIPTOR structures, except where noted.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Type value</term>
		/// <term>u member substructure</term>
		/// </listheader>
		/// <item>
		/// <term>CmResourceTypePort</term>
		/// <term>u.Port</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeInterrupt</term>
		/// <term>
		/// u.Interrupt or u.MessageInterrupt.If the CM_RESOURCE_INTERRUPT_MESSAGE flag of Flags is set, use u.MessageInterrupt; otherwise,
		/// use u.Interrupt.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeMemory</term>
		/// <term>u.Memory</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeMemoryLarge</term>
		/// <term>
		/// One of u.Memory40, u.Memory48, or u.Memory64.The CM_RESOURCE_MEMORY_LARGE_XXX flags set in the Flags member determines which
		/// structure is used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeDma</term>
		/// <term>u.Dma (if CM_RESOURCE_DMA_V3 is not set) or u.DmaV3 (if CM_RESOURCE_DMA_V3 flag is set)</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeDevicePrivate</term>
		/// <term>u.DevicePrivate</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeBusNumber</term>
		/// <term>u.BusNumber</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeDeviceSpecific</term>
		/// <term>u.DeviceSpecificData(Not used within IO_RESOURCE_DESCRIPTOR.)</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypePcCardConfig</term>
		/// <term>u.DevicePrivate</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeMfCardConfig</term>
		/// <term>u.DevicePrivate</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeConnection</term>
		/// <term>u.Connection</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeConfigData</term>
		/// <term>Reserved for system use.</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeNonArbitrated</term>
		/// <term>Not used.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CmResourceType Type;

		/// <summary>
		/// <para>Indicates whether the described resource can be shared. Valid constant values are listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CmResourceShareDeviceExclusive</term>
		/// <term>The device requires exclusive use of the resource.</term>
		/// </item>
		/// <item>
		/// <term>CmResourceShareDriverExclusive</term>
		/// <term>The driver requires exclusive use of the resource. (Not supported for WDM drivers.)</term>
		/// </item>
		/// <item>
		/// <term>CmResourceShareShared</term>
		/// <term>The resource can be shared without restriction.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CM_SHARE_DISPOSITION ShareDisposition;

		/// <summary>
		/// <para>
		/// Contains flag bits that are specific to the resource type, as indicated in the following table. Flags can be bitwise-ORed
		/// together as appropriate.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Resource type</term>
		/// <term>Flag</term>
		/// <term>Definition</term>
		/// </listheader>
		/// <item>
		/// <term>CmResourceTypePort</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_MEMORY</term>
		/// <term>The device is accessed in memory address space.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_IO</term>
		/// <term>The device is accessed in I/O address space.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_10_BIT_DECODE</term>
		/// <term>The device decodes 10 bits of the port address.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_12_BIT_DECODE</term>
		/// <term>The device decodes 12 bits of the port address.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_16_BIT_DECODE</term>
		/// <term>The device decodes 16 bits of the port address.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_POSITIVE_DECODE</term>
		/// <term>
		/// The device uses "positive decode" instead of "subtractive decode". (In general, PCI devices use positive decode and ISA buses use
		/// subtractive decode.)
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_PASSIVE_DECODE</term>
		/// <term>The device decodes the port but the driver does not use it.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_PORT_WINDOW_DECODE</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeInterrupt</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_LEVEL_SENSITIVE</term>
		/// <term>The IRQ line is level-triggered. (These IRQs are usually sharable.)</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_LATCHED</term>
		/// <term>The IRQ line is edge-triggered.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_MESSAGE</term>
		/// <term>
		/// If this flag is set, the interrupt is a message-signaled interrupt. Otherwise, the interrupt is a line-based interrupt. This flag
		/// can be set starting with Windows Vista.
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_POLICY_INCLUDED</term>
		/// <term>Not used with the CM_PARTIAL_RESOURCE_DESCRIPTOR structure. For more information about this flag, see IO_RESOURCE_DESCRIPTOR.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_SECONDARY_INTERRUPT</term>
		/// <term>
		/// The interrupt is a secondary interrupt. This flag can be set starting with Windows 8. For more information about secondary
		/// interrupts, see GPIO Interrupts.
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_INTERRUPT_WAKE_HINT</term>
		/// <term>
		/// The interrupt is capable of waking the operating system from a low-power idle state or a system sleep state. This flag can be set
		/// starting with Windows 8. For more information about wake capabilities, see Enabling Device Wake-Up.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeMemory</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_READ_WRITE</term>
		/// <term>The memory range is readable and writable.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_READ_ONLY</term>
		/// <term>The memory range is read-only.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_WRITE_ONLY</term>
		/// <term>The memory range is write-only.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_PREFETCHABLE</term>
		/// <term>The memory range is prefetchable.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_COMBINEDWRITE</term>
		/// <term>Combined-write caching is allowed.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_24</term>
		/// <term>The device uses 24-bit addressing.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_CACHEABLE</term>
		/// <term>The memory range is cacheable.</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeMemoryLarge</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_LARGE_40</term>
		/// <term>The memory descriptor uses the u.Memory40 member.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_LARGE_48</term>
		/// <term>The memory descriptor uses the u.Memory48 member.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_MEMORY_LARGE_64</term>
		/// <term>The memory descriptor uses the u.Memory64 member.</term>
		/// </item>
		/// <item>
		/// <term>CmResourceTypeDma</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_8</term>
		/// <term>8-bit DMA channel</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_16</term>
		/// <term>16-bit DMA channel</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_32</term>
		/// <term>32-bit DMA channel</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_8_AND_16</term>
		/// <term>8-bit and 16-bit DMA channel</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_BUS_MASTER</term>
		/// <term>The device supports bus master DMA transfers.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_TYPE_A</term>
		/// <term>Type A DMA</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_TYPE_B</term>
		/// <term>Type B DMA</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_TYPE_F</term>
		/// <term>Type F DMA</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>CM_RESOURCE_DMA_V3</term>
		/// <term>Use the DmaV3 member instead of the Dma member. The DmaV3 member is available starting with Windows 8.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CM_RESOURCE Flags;

		/// <summary>The union</summary>
		public union u;

		[StructLayout(LayoutKind.Explicit)]
		public struct union
		{
			/// <summary>The generic</summary>
			[FieldOffset(0)]
			public Generic Generic;

			/// <summary>The port</summary>
			[FieldOffset(0)]
			public Generic Port;

			/// <summary>The interrupt</summary>
			[FieldOffset(0)]
			public Interrupt Interrupt;

			/// <summary>The message interrupt raw</summary>
			[FieldOffset(0)]
			public MessageInterruptRaw MessageInterruptRaw;

			/// <summary>The message interrupt translated</summary>
			[FieldOffset(0)]
			public Interrupt MessageInterruptTranslated;

			/// <summary>The memory</summary>
			[FieldOffset(0)]
			public Generic Memory;

			/// <summary>The dma</summary>
			[FieldOffset(0)]
			public Dma Dma;

			/// <summary>The dma v3</summary>
			[FieldOffset(0)]
			public DmaV3 DmaV3;

			/// <summary>The device private</summary>
			[FieldOffset(0)]
			public DevicePrivate DevicePrivate;

			/// <summary>The bus number</summary>
			[FieldOffset(0)]
			public BusNumber BusNumber;

			/// <summary>The device specific data</summary>
			[FieldOffset(0)]
			public DeviceSpecificData DeviceSpecificData;

			/// <summary>The memory40</summary>
			[FieldOffset(0)]
			public Memory40 Memory40;

			/// <summary>The memory48</summary>
			[FieldOffset(0)]
			public Memory48 Memory48;

			/// <summary>The memory64</summary>
			[FieldOffset(0)]
			public Memory64 Memory64;

			/// <summary>The connection</summary>
			[FieldOffset(0)]
			public Connection Connection;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Generic
		{
			/// <summary>
			/// <para>
			/// For raw resources: Specifies the bus-relative physical address of the lowest of a range of contiguous I/O port addresses
			/// allocated to the device.
			/// </para>
			/// <para>
			/// For translated resources: Specifies the system physical address of the lowest of a range of contiguous I/O port addresses
			/// allocated to the device.
			/// </para>
			/// <para>For more information about raw and translated resources, see Remarks.</para>
			/// </summary>
			public long Start;

			/// <summary>The length, in bytes, of the range of allocated I/O port addresses.</summary>
			public uint Length;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct Interrupt
		{
			/// <summary>The level</summary>
			public ushort Level;

			/// <summary>
			/// Specifies the processor group number. This member exists only if the NT_PROCESSOR_GROUPS constant is defined at compile time.
			/// This member can be nonzero only on Windows 7 and later versions of Windows. The <c>Group</c> and <c>Affinity</c> members
			/// together specify a group affinity that indicates which processors the device can interrupt. To specify an affinity for any
			/// group, set <c>Group</c> to ALL_PROCESSOR_GROUPS.
			/// </summary>
			public ushort Group;

			/// <summary>
			/// <para>For raw resources: Specifies the device's bus-specific interrupt vector (if appropriate for the platform and bus).</para>
			/// <para>For translated resources: Specifies the global system interrupt vector assigned to the device.</para>
			/// <para>For more information about raw and translated resources, see Remarks.</para>
			/// </summary>
			public uint Vector;

			/// <summary>
			/// Contains a <c>UIntPtr</c>-typed bitmask value indicating the set of processors the device can interrupt. To indicate that the
			/// device can interrupt any processor, this member is set to -1.
			/// </summary>
			public UIntPtr Affinity;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct MessageInterruptRaw
		{
			/// <summary>
			/// Specifies a processor group number. This member exists only if NT_PROCESSOR_GROUPS is defined at compile time. This member
			/// can be nonzero only on Windows 7 and later versions of Windows. The <c>Group</c> and <c>Affinity</c> members together specify
			/// a group affinity that indicates which processors can receive the device's interrupts. To specify an affinity for any group,
			/// set <c>Group</c> to ALL_PROCESSOR_GROUPS.
			/// </summary>
			public ushort Group;

			/// <summary>Specifies the number of message-signaled interrupts generated for this driver.</summary>
			public ushort MessageCount;

			/// <summary>Specifies the device's interrupt vector.</summary>
			public uint Vector;

			/// <summary>Specifies a UIntPtr value that indicates the processors that receive the device's interrupts.</summary>
			public UIntPtr Affinity;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Dma
		{
			/// <summary>Specifies the number of the DMA channel on a system DMA controller that the device can use.</summary>
			public uint Channel;

			/// <summary>Specifies the number of the DMA port that an MCA-type device can use.</summary>
			public uint Port;

			/// <summary>Not used.</summary>
			public uint Reserved1;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct DmaV3
		{
			/// <summary>Specifies the number of the DMA channel on the system DMA controller that is allocated to the device.</summary>
			public uint Channel;

			/// <summary>Specifies the number of the request line on the system DMA controller that is allocated to the device.</summary>
			public uint RequestLine;

			/// <summary>
			/// Specifies the width, in bits, of the data bus that the system DMA controller that is allocated to the device uses to transfer
			/// data to or from the device.
			/// </summary>
			public byte TransferWidth;

			/// <summary>Not used.</summary>
			public byte Reserved1;

			/// <summary>Not used.</summary>
			public byte Reserved2;

			/// <summary>Not used.</summary>
			public byte Reserved3;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DevicePrivate
		{
			private uint data0, data1, data2;

			/// <summary>The data</summary>
			public uint[] Data
			{
				get => new[] {data0, data1, data2};
				set
				{
					data0 = value[0];
					data1 = value[1];
					data2 = value[2];
				}
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BusNumber
		{
			/// <summary>Specifies the lowest-numbered of a range of contiguous buses allocated to the device.</summary>
			public uint Start;

			/// <summary>Specifies the number of buses allocated to the device.</summary>
			public uint Length;

			/// <summary>Not used.</summary>
			public uint Reserved;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct DeviceSpecificData
		{
			/// <summary>Specifies the number of bytes appended to the end of the <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> structure.</summary>
			public uint DataSize;

			/// <summary>Not used.</summary>
			public uint Reserved1;

			/// <summary>Not used.</summary>
			public uint Reserved2;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Memory40
		{
			/// <summary>
			/// <para>
			/// For raw resources: Specifies the bus-relative physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>
			/// For translated resources: Specifies the system physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>For more information about raw and translated resources, see Remarks.</para>
			/// </summary>
			public long Start;

			/// <summary>
			/// Contains the high 32 bits of the 40-bit length, in bytes, of the range of allocated memory addresses. The lowest 8 bits are
			/// treated as zero.
			/// </summary>
			public uint Length40;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Memory48
		{
			/// <summary>
			/// <para>
			/// For raw resources: Specifies the bus-relative physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>
			/// For translated resources: Specifies the system physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>For more information about raw and translated resources, see Remarks.</para>
			/// </summary>
			public long Start;

			/// <summary>
			/// Contains the high 32 bits of the 48-bit length, in bytes, of the range of allocated memory addresses. The lowest 16 bits are
			/// treated as zero.
			/// </summary>
			public uint Length48;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct Memory64
		{
			/// <summary>
			/// <para>
			/// For raw resources: Specifies the bus-relative physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>
			/// For translated resources: Specifies the system physical address of the lowest of a range of contiguous memory addresses that
			/// are allocated to the device.
			/// </para>
			/// <para>For more information about raw and translated resources, see Remarks.</para>
			/// </summary>
			public long Start;

			/// <summary>
			/// Contains the high 32 bits of the 64-bit length, in bytes, of the range of allocated memory addresses. The lowest 32 bits are
			/// treated as zero.
			/// </summary>
			public uint Length64;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct Connection
		{
			/// <summary>
			/// <para>Specifies the connection class. This member is set to one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_CLASS_GPIO</term>
			/// <term>Access the device through one or more pins on a GPIO controller.</term>
			/// </item>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_CLASS_SERIAL</term>
			/// <term>Access the device through a serial bus or serial port.</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte Class;

			/// <summary>
			/// <para>Specifies the connection type.</para>
			/// <para>If <c>Class</c> = CM_RESOURCE_CONNECTION_CLASS_GPIO, <c>Type</c> is set to the following value.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_TYPE_GPIO_IO</term>
			/// <term>Access the device through GPIO pins that are configured for I/O.</term>
			/// </item>
			/// </list>
			/// <para>If <c>Class</c> = CM_RESOURCE_CONNECTION_CLASS_SERIAL, <c>Type</c> is set to one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_TYPE_SERIAL_I2C</term>
			/// <term>The device is connected to an I²C bus.</term>
			/// </item>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_TYPE_SERIAL_SPI</term>
			/// <term>The device is connected to an SPI bus.</term>
			/// </item>
			/// <item>
			/// <term>CM_RESOURCE_CONNECTION_TYPE_SERIAL_UART</term>
			/// <term>The device is connected to a serial port.</term>
			/// </item>
			/// </list>
			/// </summary>
			public byte Type;

			/// <summary>Not used.</summary>
			public byte Reserved1;

			/// <summary>Not used.</summary>
			public byte Reserved2;

			/// <summary>Contains the lower 32 bits of the 64-bit connection ID.</summary>
			public uint IdLowPart;

			/// <summary>Contains the upper 32 bits of the 64-bit connection ID.</summary>
			public uint IdHighPart;
		}
	}

	/// <summary>
	/// <para>
	/// The <c>CM_PARTIAL_RESOURCE_LIST</c> structure specifies a set of system hardware resources, of various types, assigned to a device.
	/// This structure is contained within a CM_FULL_RESOURCE_DESCRIPTOR structure.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is the header for an array of <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> structures. The <c>PartialDescriptors</c> member
	/// contains the first element in this array, and the <c>Count</c> member specifies the total number of array elements. If the array
	/// contains more than one element, the remaining elements in the array immediately follow the <c>CM_PARTIAL_RESOURCE_LIST</c> structure
	/// in memory. The total number of bytes occupied by the <c>CM_PARTIAL_RESOURCE_LIST</c> structure and any array elements that follow
	/// this structure is <c>sizeof</c>( <c>CM_PARTIAL_RESOURCE_LIST</c>) + ( <c>Count</c> - 1) * <c>sizeof</c>( <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c>).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_cm_partial_resource_list typedef struct
	// _CM_PARTIAL_RESOURCE_LIST { USHORT Version; USHORT Revision; ULONG Count; CM_PARTIAL_RESOURCE_DESCRIPTOR PartialDescriptors[1]; }
	// CM_PARTIAL_RESOURCE_LIST, *PCM_PARTIAL_RESOURCE_LIST;
	[PInvokeData("wdm.h", MSDNShortId = "f16b26f5-1f32-4c2e-83ec-0a0f79a4be85")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CM_PARTIAL_RESOURCE_LIST : IMarshalDirective
	{
		/// <summary>The version number of this structure. This value should be 1.</summary>
		public ushort Version;

		/// <summary>The revision of this structure. This value should be 1.</summary>
		public ushort Revision;

		/// <summary>The number of elements contained in the <c>PartialDescriptors</c> array.</summary>
		public uint Count;

		/// <summary>The first element in an array of one or more CM_PARTIAL_RESOURCE_DESCRIPTOR structures.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public CM_PARTIAL_RESOURCE_DESCRIPTOR[] PartialDescriptors;

		MarshalDirectiveActivator IMarshalDirective.GetActivator() => (p, s) => p != IntPtr.Zero ? new SafeAnysizeStruct<CM_PARTIAL_RESOURCE_LIST>(p, s, nameof(Count)).Value : default;
		SafeAllocatedMemoryHandle IMarshalDirective.ToNative() => new SafeAnysizeStruct<CM_PARTIAL_RESOURCE_LIST>(this, nameof(Count));
	}

	/// <summary>The <c>CM_RESOURCE_LIST</c> structure specifies all of the system hardware resources assigned to a device.</summary>
	/// <remarks>
	/// <para>
	/// This structure describes the assignment of hardware resources to a device. An IRP_MN_START_DEVICE IRP uses this structure to specify
	/// the resources that the Plug and Play manager assigns to a device. Drivers for legacy devices use this structure to pass their
	/// resource requirements to the IoReportResourceForDetection routine. For more information about hardware resource allocation, see
	/// Hardware Resources.
	/// </para>
	/// <para>
	/// The <c>CM_RESOURCE_LIST</c> structure is a header for a larger data structure, of variable size, that contains one or more full
	/// resource descriptors. All of the data in this larger structure occupies a contiguous block of memory. Each full resource descriptor
	/// occupies a subblock within the larger block.
	/// </para>
	/// <para>
	/// A full resource descriptor begins with a CM_FULL_RESOURCE_DESCRIPTOR structure, which serves as a header for an array of
	/// CM_PARTIAL_RESOURCE_DESCRIPTOR structures. The length of this array determines the size of the full resource descriptor. The last
	/// member in the <c>CM_FULL_RESOURCE_DESCRIPTOR</c> structure is a CM_PARTIAL_RESOURCE_LIST structure that contains, as its last member,
	/// the first element in this array. If the array contains more than one element, the remaining elements immediately follow, in memory,
	/// the end of the <c>CM_PARTIAL_RESOURCE_LIST</c> structure, which is also the end of the <c>CM_FULL_RESOURCE_DESCRIPTOR</c> structure.
	/// </para>
	/// <para>
	/// Driver code can use pointer arithmetic to step from one full resource descriptor to the next. For example, if a parameter named list
	/// is a pointer to the <c>CM_FULL_RESOURCE_DESCRIPTOR</c> structure at the start of one full resource descriptor, list can be updated to
	/// point to the start of the next full resource descriptor as follows:
	/// </para>
	/// <para>
	/// In this example, is a pointer to the start of the <c>CM_PARTIAL_RESOURCE_DESCRIPTOR</c> array, and is the number of elements in the
	/// array. For more information about the <c>PartialDescriptors</c> and <c>Count</c> members, see CM_PARTIAL_RESOURCE_LIST. #### Examples
	/// All PnP drivers must handle IRP_MN_START_DEVICE IRPs. Typically, a driver's handler for this IRP walks the lists of assigned
	/// resources that are pointed to by the <c>Parameters.StartDevice.AllocatedResources</c> and
	/// <c>Parameters.StartDevice.AllocatedResourcesTranslated</c> members of the IO_STACK_LOCATION structure in the IRP. The following code
	/// example contains a function—named GetAssignedResources—that is called in the handler to walk each list. This function verifies that
	/// the required resources are specified in the list, and configures the device to use the resources. The GetAssignedResources function
	/// returns <c>TRUE</c> if it succeeds. Otherwise, it returns <c>FALSE</c> (probably from the <c>switch</c> statement, although the
	/// details are omitted to simplify the code example).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_cm_resource_list typedef struct _CM_RESOURCE_LIST {
	// ULONG Count; CM_FULL_RESOURCE_DESCRIPTOR List[1]; } CM_RESOURCE_LIST, *PCM_RESOURCE_LIST;
	[PInvokeData("wdm.h", MSDNShortId = "01f31255-a4f7-4a16-9238-a7391bb850d1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CM_RESOURCE_LIST : IMarshalDirective
	{
		/// <summary>
		/// The number of full resource descriptors that are specified by this <c>CM_RESOURCE_LIST</c> structure. The <c>List</c> member is
		/// the header for the first full resource descriptor. For WDM drivers, <c>Count</c> is always 1.
		/// </summary>
		public uint Count;

		/// <summary>
		/// The CM_FULL_RESOURCE_DESCRIPTOR structure that serves as the header for the first full resource descriptor. If the
		/// <c>CM_RESOURCE_LIST</c> structure contains more than one full resource descriptor, the second full resource descriptor
		/// immediately follows the first in memory, and so on. The size of each full resource descriptor depends on the length of the
		/// CM_PARTIAL_RESOURCE_DESCRIPTOR array that it contains. For more information, see the following Remarks section.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public CM_FULL_RESOURCE_DESCRIPTOR[] List;

		MarshalDirectiveActivator IMarshalDirective.GetActivator() => (p, s) => p != IntPtr.Zero ? new SafeAnysizeStruct<CM_RESOURCE_LIST>(p, s, nameof(Count)).Value : default;
		SafeAllocatedMemoryHandle IMarshalDirective.ToNative() => new SafeAnysizeStruct<CM_RESOURCE_LIST>(this, nameof(Count));
	}
}