using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>
	/// <para>
	/// Device Name - this string is the name of the device. It is the name that should be passed to NtOpenFile when accessing the device.
	/// </para>
	/// <para>Note:  For devices that support multiple units, it should be suffixed with the Ascii representation of the unit number.</para>
	/// </summary>
	public const string DD_KEYBOARD_DEVICE_NAME = "\\Device\\KeyboardClass";

	/// <summary>
	/// <para>
	/// Device Name - this string is the name of the device. It is the name that should be passed to NtOpenFile when accessing the device.
	/// </para>
	/// <para>Note:  For devices that support multiple units, it should be suffixed with the Ascii representation of the unit number.</para>
	/// </summary>
	public const string DD_KEYBOARD_DEVICE_NAME_U = "\\Device\\KeyboardClass";

	/// <summary/>
	public const byte KEYBOARD_EXTENDED_ATTRIBUTES_STRUCT_VERSION_1 = 1;

	/// <summary>
	/// The default amount of time that must elapse, in milliseconds, after a key is pressed and continuously held down, before the character
	/// output from a keyboard begins to repeat.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_DELAY_DEFAULT = 250;

	/// <summary>
	/// The maximum amount of time that must elapse, in milliseconds, after a key is pressed and continuously held down, before the character
	/// output from a keyboard begins to repeat.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_DELAY_MAXIMUM = 1000;

	/// <summary>
	/// The minimum amount of time that must elapse, in milliseconds, after a key is pressed and continuously held down, before the character
	/// output from a keyboard begins to repeat.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_DELAY_MINIMUM = 250;

	/// <summary>
	/// The default rate at which character output from a keyboard repeats, in characters per second, after a key is pressed and continuously
	/// held down.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_RATE_DEFAULT = 30;

	/// <summary>
	/// The maximum rate at which character output from a keyboard repeats, in characters per second, after a key is pressed and continuously
	/// held down.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_RATE_MAXIMUM = 30;

	/// <summary>
	/// The minimum rate at which character output from a keyboard repeats, in characters per second, after a key is pressed and continuously
	/// held down.
	/// </summary>
	public const ushort KEYBOARD_TYPEMATIC_RATE_MINIMUM = 2;

	/// <summary>Declare the GUID that represents the device interface for keyboards.</summary>
	public static readonly Guid GUID_DEVINTERFACE_KEYBOARD = new(0x884b96c3, 0x56ef, 0x11d1, 0xbc, 0x8c, 0x00, 0xa0, 0xc9, 0x14, 0x05, 0xdd);

	/// <summary>
	/// Specifies a bitwise OR of one or more of the following flags that indicate whether a key was pressed or released, and other
	/// miscellaneous information.
	/// </summary>
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INPUT_DATA")]
	[Flags]
	public enum KEYBOARD_INPUT_FLAGS : ushort
	{
		/// <summary>The key was pressed.</summary>
		KEY_MAKE = 0x00,

		/// <summary>The key was released.</summary>
		KEY_BREAK = 0x01,

		/// <summary>Extended scan code used to indicate special keyboard functions.</summary>
		KEY_E0 = 0x02,

		/// <summary>Extended scan code used to indicate special keyboard functions.</summary>
		KEY_E1 = 0x04,

		/// <summary/>
		KEY_TERMSRV_SET_LED = 8,

		/// <summary/>
		KEY_TERMSRV_SHADOW = 0x10,

		/// <summary/>
		KEY_TERMSRV_VKPACKET = 0x20,

		/// <summary/>
		KEY_RIM_VKEY = 0x40,

		/// <summary/>
		KEY_FROM_KEYBOARD_OVERRIDER = 0x80,

		/// <summary/>
		KEY_UNICODE_SEQUENCE_ITEM = 0x100,

		/// <summary/>
		KEY_UNICODE_SEQUENCE_END = 0x200,
	}

	/// <summary>LED flags</summary>
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INDICATOR_PARAMETERS")]
	[Flags]
	public enum LED_FLAGS : ushort
	{
		/// <summary>Used by a Terminal Server.</summary>
		KEYBOARD_LED_INJECTED = 0x8000, //Used by Terminal Server

		/// <summary>Used by a Terminal Server.</summary>
		KEYBOARD_SHADOW = 0x4000, //Used by Terminal Server

		/// <summary>Japanese keyboard</summary>
		KEYBOARD_KANA_LOCK_ON = 8, // Japanese keyboard

		/// <summary>CAPS LOCK LED is on.</summary>
		KEYBOARD_CAPS_LOCK_ON = 4,

		/// <summary>NUM LOCK LED is on.</summary>
		KEYBOARD_NUM_LOCK_ON = 2,

		/// <summary>SCROLL LOCK LED is on.</summary>
		KEYBOARD_SCROLL_LOCK_ON = 1,
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("ntddkbd.h")]
	public static uint IOCTL_KEYBOARD_INSERT_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0040, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_QUERY_ATTRIBUTES request returns information about the keyboard attributes.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_ATTRIBUTES</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer that I8042prt uses to output a <c>KEYBOARD_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>KEYBOARD_ATTRIBUTES</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_query_attributes
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_QUERY_ATTRIBUTES")]
	public static uint IOCTL_KEYBOARD_QUERY_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0000, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_QUERY_EXTENDED_ATTRIBUTES request returns information about the extended keyboard attributes.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_EXTENDED_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_EXTENDED_ATTRIBUTES</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer that I8042prt uses to output a
	/// <c>KEYBOARD_EXTENDED_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>KEYBOARD_EXTENDED_ATTRIBUTES</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_query_extended_attributes
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_QUERY_EXTENDED_ATTRIBUTES")]
	public static uint IOCTL_KEYBOARD_QUERY_EXTENDED_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0080, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	[PInvokeData("ntddkbd.h")]
	public static uint IOCTL_KEYBOARD_QUERY_IME_STATUS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0400, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>
	/// The IOCTL_KEYBOARD_QUERY_INDICATOR_TRANSLATION request returns information about the mapping between scan codes and keyboard indicators.
	/// </para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// device-specific <c>KEYBOARD_INDICATOR_TRANSLATION</c> structure. This structure includes a variable-sized array of INDICATOR_LIST
	/// members that is device-specific.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_INDICATOR_TRANSLATION</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer that I8042prt uses to output a
	/// <c>KEYBOARD_INDICATOR_TRANSLATION</c> structure. This structure includes a variable-sized array of INDICATOR_LIST members that is device-specific.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>KEYBOARD_INDICATOR_TRANSLATION</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_query_indicator_translation
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_QUERY_INDICATOR_TRANSLATION")]
	public static uint IOCTL_KEYBOARD_QUERY_INDICATOR_TRANSLATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0020, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_QUERY_INDICATORS request returns information about the keyboard indicators.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer that I8042prt uses to output a
	/// <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_query_indicators
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_QUERY_INDICATORS")]
	public static uint IOCTL_KEYBOARD_QUERY_INDICATORS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0010, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_QUERY_TYPEMATIC request returns the keyboard typematic settings.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.OutputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated output buffer that I8042prt uses to output a
	/// <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_query_typematic
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_QUERY_TYPEMATIC")]
	public static uint IOCTL_KEYBOARD_QUERY_TYPEMATIC => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0008, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	[PInvokeData("ntddkbd.h")]
	public static uint IOCTL_KEYBOARD_SET_IME_STATUS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0401, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_SET_INDICATORS request sets the keyboard indicators.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer that inputs a <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.
	/// The client sets the indicator parameters in this structure.
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_set_indicators
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_SET_INDICATORS")]
	public static uint IOCTL_KEYBOARD_SET_INDICATORS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0002, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_KEYBOARD_SET_TYPEMATIC request sets the keyboard typematic settings.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to a client-allocated buffer to input a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure. The
	/// client sets the typematic parameters in this structure.
	/// </para>
	/// <para>
	/// <b>Parameters.DeviceIoControl.InputBufferLength</b> is set to a value greater than or equal to the size, in bytes, of a
	/// <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ni-ntddkbd-ioctl_keyboard_set_typematic
	[PInvokeData("ntddkbd.h", MSDNShortId = "NI:ntddkbd.IOCTL_KEYBOARD_SET_TYPEMATIC")]
	public static uint IOCTL_KEYBOARD_SET_TYPEMATIC => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0001, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Specifies a device-specific, variable-length array of INDICATOR_LIST structures.</summary>
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INDICATOR_TRANSLATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INDICATOR_LIST
	{
		/// <summary>Specifies the make scan code that is generated when a key is pressed.</summary>
		public ushort MakeCode;

		/// <summary>
		/// Specifies the LED indicator that corresponds to the <b>MakeCode</b> scan code. For information about the flags, see the
		/// <b>LedFlags</b> member of the <c>KEYBOARD_INDICATOR_PARAMETERS</c> structure.
		/// </summary>
		public ushort IndicatorFlags;
	}

	/// <summary>Specifies the attributes of a keyboard.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used with a <c>IOCTL_KEYBOARD_QUERY_ATTRIBUTES IOCTL</c> request to return information about the attributes that a
	/// keyboard supports.
	/// </para>
	/// <para>
	/// For more information about keyboard types, subtypes, scan code modes, and related keyboard layouts, see <c>Keyboard and mouse HID
	/// client drivers</c> in our drivers documentation.
	/// </para>
	/// <para>
	/// More details can also be found in the kbd.h, ntdd8042.h and ntddkbd.h headers in the Windows SDK, the <c>USB HID to PS/2 Scan Code
	/// Translation Table</c> specification from Microsoft, and the <c>Keyboard Layout Samples</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_attributes typedef struct _KEYBOARD_ATTRIBUTES {
	// KEYBOARD_ID KeyboardIdentifier; USHORT KeyboardMode; USHORT NumberOfFunctionKeys; USHORT NumberOfIndicators; USHORT NumberOfKeysTotal;
	// ULONG InputDataQueueLength; KEYBOARD_TYPEMATIC_PARAMETERS KeyRepeatMinimum; KEYBOARD_TYPEMATIC_PARAMETERS KeyRepeatMaximum; }
	// KEYBOARD_ATTRIBUTES, *PKEYBOARD_ATTRIBUTES;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_ATTRIBUTES
	{
		/// <summary>Specifies the keyboard type and subtype in a KEYBOARD_ID structure:</summary>
		public KEYBOARD_ID KeyboardIdentifier;

		/// <summary>Specifies the scan code mode. See the <c>Remarks</c> section.</summary>
		public ushort KeyboardMode;

		/// <summary>Specifies the number of function keys that a keyboard supports.</summary>
		public ushort NumberOfFunctionKeys;

		/// <summary>Specifies the number of LED indicators that a keyboard supports.</summary>
		public ushort NumberOfIndicators;

		/// <summary>Specifies the number of keys that a keyboard supports.</summary>
		public ushort NumberOfKeysTotal;

		/// <summary>Specifies the size, in bytes, of the input data queue used by the keyboard port driver.</summary>
		public uint InputDataQueueLength;

		/// <summary>
		/// Specifies the minimum possible value for the keyboard typematic rate and delay in a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.
		/// </summary>
		public KEYBOARD_TYPEMATIC_PARAMETERS KeyRepeatMinimum;

		/// <summary>
		/// Specifies the maximum possible value for the keyboard typematic rate and delay in a <c>KEYBOARD_TYPEMATIC_PARAMETERS</c> structure.
		/// </summary>
		public KEYBOARD_TYPEMATIC_PARAMETERS KeyRepeatMaximum;
	}

	/// <summary>KEYBOARD_EXTENDED_ATTRIBUTES specifies the extended attributes of a keyboard.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used with a <c>IOCTL_KEYBOARD_QUERY_EXTENDED_ATTRIBUTES</c> request to return information about the extended
	/// attributes that a keyboard supports.
	/// </para>
	/// <para>
	/// This information comes from HID Keyboard Report Descriptor described in <c>HID Usage Table Review Request 42: Consumer Page Keyboard
	/// Assist Controls</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_extended_attributes typedef struct
	// _KEYBOARD_EXTENDED_ATTRIBUTES { UCHAR Version; UCHAR FormFactor; UCHAR KeyType; UCHAR PhysicalLayout; UCHAR
	// VendorSpecificPhysicalLayout; UCHAR IETFLanguageTagIndex; UCHAR ImplementedInputAssistControls; } KEYBOARD_EXTENDED_ATTRIBUTES, *PKEYBOARD_EXTENDED_ATTRIBUTES;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_EXTENDED_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_EXTENDED_ATTRIBUTES
	{
		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>The version of this structure.</para>
		/// <para>Only <b>KEYBOARD_EXTENDED_ATTRIBUTES_STRUCT_VERSION_1</b> supported.</para>
		/// </summary>
		public byte Version;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>Keyboard Form Factor (Usage ID: 0x2C1).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>0x00</description>
		/// <description>Unknown Form Factor.</description>
		/// </item>
		/// <item>
		/// <description>0x01</description>
		/// <description>Full‐Size keyboard.</description>
		/// </item>
		/// <item>
		/// <description>0x02</description>
		/// <description>Compact keyboard. Such keyboards are less than 13” wide.</description>
		/// </item>
		/// </list>
		/// </summary>
		public byte FormFactor;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>Keyboard Key Type (Usage ID: 0x2C2).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>0x00</description>
		/// <description>Unknown Key Type.</description>
		/// </item>
		/// <item>
		/// <description>0x01</description>
		/// <description>Full‐travel keys.</description>
		/// </item>
		/// <item>
		/// <description>0x02</description>
		/// <description>Low‐travel keys such as those on laptop keyboards.</description>
		/// </item>
		/// <item>
		/// <description>0x03</description>
		/// <description>Zero‐travel or virtual keys.</description>
		/// </item>
		/// </list>
		/// </summary>
		public byte KeyType;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>Keyboard Physical Layout (Usage ID: 0x2C3).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>0x00</description>
		/// <description>Unknown Layout</description>
		/// </item>
		/// <item>
		/// <description>0x01</description>
		/// <description>101 (e.g., US)</description>
		/// </item>
		/// <item>
		/// <description>0x02</description>
		/// <description>103 (Korea)</description>
		/// </item>
		/// <item>
		/// <description>0x03</description>
		/// <description>102 (e.g., German)</description>
		/// </item>
		/// <item>
		/// <description>0x04</description>
		/// <description>104 (e.g., ABNT Brazil)</description>
		/// </item>
		/// <item>
		/// <description>0x05</description>
		/// <description>106 (DOS/V Japan)</description>
		/// </item>
		/// <item>
		/// <description>0x06</description>
		/// <description>Vendor‐specific – If specified, <b>VendorSpecificPhysicalLayout</b> must also be specified.</description>
		/// </item>
		/// </list>
		/// <para>
		/// This value does not refer to the legend set printed on the keys, but only to the physical keyset layout, defined by the relative
		/// location and shape of the textual keys in relation to each other. This value indicates which of the de facto standard physical
		/// layouts to which the keyboard conforms. These layouts are commonly understood.
		/// </para>
		/// </summary>
		public byte PhysicalLayout;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>A numeric identifier of the particular Vendor‐specific Keyboard Physical Layout (Usage ID: 0x2C4).</para>
		/// <para>
		/// Values for this field are defined by the hardware vendor but 0x00 is defined to not specify a Vendor‐specific Keyboard Physical
		/// Layout. If non‐zero, <b>PhysicalLayout</b> must have value 0x06. If this identifier is 0x00, <b>PhysicalLayout</b> must not have
		/// the value 0x06.
		/// </para>
		/// </summary>
		public byte VendorSpecificPhysicalLayout;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>String index of a String Descriptor having an IETF Language Tag (Usage ID: 0x2C5).</para>
		/// <para>
		/// Actual string can be obtained via <c>IOCTL_HID_GET_INDEXED_STRING</c> IOCTL in kernel-mode drivers or
		/// <c>HidD_GetIndexedString</c> call in user-mode applications.
		/// </para>
		/// <para>
		/// This Language Tag specifies the intended primary locale of the keyboard legend set, conformant to <c>IETF BCP 47</c> or its successor.
		/// </para>
		/// <para>
		/// If an appropriate IETF Language Tag is not available, such as for custom, adaptive or new layouts, the value is set to 0x00.
		/// </para>
		/// </summary>
		public byte IETFLanguageTagIndex;

		/// <summary>
		/// <para>Type: <b>UCHAR</b></para>
		/// <para>Bitmap for physically implemented input assist controls. (Usage ID: 0x2C6).</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Bit</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>All 0</description>
		/// <description>No Keyboard Input Assist controls are implemented.</description>
		/// </item>
		/// <item>
		/// <description>Bit 0</description>
		/// <description>Previous Suggestion</description>
		/// </item>
		/// <item>
		/// <description>Bit 1</description>
		/// <description>Next Suggestion</description>
		/// </item>
		/// <item>
		/// <description>Bit 2</description>
		/// <description>Previous Suggestion Group</description>
		/// </item>
		/// <item>
		/// <description>Bit 3</description>
		/// <description>Next Suggestion Group</description>
		/// </item>
		/// <item>
		/// <description>Bit 4</description>
		/// <description>Accept Suggestion</description>
		/// </item>
		/// <item>
		/// <description>Bit 5</description>
		/// <description>Cancel Suggestion</description>
		/// </item>
		/// <item>
		/// <description/>
		/// <description>All other bits reserved.</description>
		/// </item>
		/// </list>
		/// </summary>
		public BitField<byte> ImplementedInputAssistControls;
	}

	/// <summary></summary>
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_ID
	{
		/// <summary>
		/// <para>Specifies the keyboard type.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>0x4</description>
		/// <description>Enhanced 101- or 102-key keyboards (and compatibles)</description>
		/// </item>
		/// <item>
		/// <description>0x7</description>
		/// <description>Japanese Keyboard</description>
		/// </item>
		/// <item>
		/// <description>0x8</description>
		/// <description>Korean Keyboard</description>
		/// </item>
		/// <item>
		/// <description>0x51</description>
		/// <description>Unknown type or HID keyboard</description>
		/// </item>
		/// </list>
		/// </summary>
		public byte Type;

		/// <summary>Specifies the keyboard subtype, which is a vendor-specific value.</summary>
		public byte Subtype;
	}

	/// <summary>KEYBOARD_INDICATOR_PARAMETERS specifies the state of a keyboard's indicator LEDs.</summary>
	/// <remarks>
	/// This structure is used with <c>IOCTL_KEYBOARD_QUERY_INDICATORS</c> and <c>IOCTL_KEYBOARD_SET_INDICATORS</c> requests to query and set
	/// keyboard indicator LEDs.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_indicator_parameters typedef struct
	// _KEYBOARD_INDICATOR_PARAMETERS { USHORT UnitId; USHORT LedFlags; } KEYBOARD_INDICATOR_PARAMETERS, *PKEYBOARD_INDICATOR_PARAMETERS;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INDICATOR_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_INDICATOR_PARAMETERS
	{
		/// <summary>
		/// Specifies the unit number of a keyboard device. A keyboard device name has the format \Device\KeyboardPort <i>N</i>, where the
		/// suffix <i>N</i> is the unit number of the device. For example, a device, whose name is \Device\KeyboardPort0, has a unit number
		/// of zero, and a device, whose name is \Device\KeyboardPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;

		/// <summary>
		/// <para>Specifies a bitwise OR of zero or more of the following LED flags:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>LED Flag</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>KEYBOARD_CAPS_LOCK_ON</description>
		/// <description>CAPS LOCK LED is on.</description>
		/// </item>
		/// <item>
		/// <description>KEYBOARD_LED_INJECTED</description>
		/// <description>Used by a Terminal Server.</description>
		/// </item>
		/// <item>
		/// <description>KEYBOARD_NUM_LOCK_ON</description>
		/// <description>NUM LOCK LED is on.</description>
		/// </item>
		/// <item>
		/// <description>KEYBOARD_SCROLL_LOCK_ON</description>
		/// <description>SCROLL LOCK LED is on.</description>
		/// </item>
		/// <item>
		/// <description>KEYBOARD_SHADOW</description>
		/// <description>Used by a Terminal Server.</description>
		/// </item>
		/// </list>
		/// </summary>
		public ushort LedFlags;
	}

	/// <summary>
	/// KEYBOARD_INDICATOR_TRANSLATION specifies a device-specific, variable length array of mappings between keyboard scan codes and LED indicators.
	/// </summary>
	/// <remarks>
	/// This structure is used with an <c>IOCTL_KEYBOARD_QUERY_INDICATOR_TRANSLATION</c> request to obtain indicator translation information.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_indicator_translation typedef struct
	// _KEYBOARD_INDICATOR_TRANSLATION { USHORT NumberOfIndicatorKeys; INDICATOR_LIST IndicatorList[1]; } KEYBOARD_INDICATOR_TRANSLATION, *PKEYBOARD_INDICATOR_TRANSLATION;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INDICATOR_TRANSLATION")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<KEYBOARD_INDICATOR_TRANSLATION>), nameof(NumberOfIndicatorKeys))]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_INDICATOR_TRANSLATION
	{
		/// <summary>Specifies the number of elements in the <b>IndicatorList</b> array.</summary>
		public ushort NumberOfIndicatorKeys;

		/// <summary>Specifies a device-specific, variable-length array of INDICATOR_LIST structures.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public INDICATOR_LIST[] IndicatorList;
	}

	/// <summary>KEYBOARD_INPUT_DATA contains one packet of keyboard input data.</summary>
	/// <remarks>
	/// In response to an <c>IRP_MJ_READ (Kbdclass)</c> request, Kbdclass transfers zero or more <b>KEYBOARD_INPUT_DATA</b> structures from
	/// its internal data queue to the Win32 subsystem buffer.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_input_data typedef struct _KEYBOARD_INPUT_DATA {
	// USHORT UnitId; USHORT MakeCode; USHORT Flags; USHORT Reserved; ULONG ExtraInformation; } KEYBOARD_INPUT_DATA, *PKEYBOARD_INPUT_DATA;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_INPUT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct KEYBOARD_INPUT_DATA
	{
		/// <summary>
		/// Specifies the unit number of a keyboard device. A keyboard device name has the format \Device\KeyboardPort <i>N</i>, where the
		/// suffix <i>N</i> is the unit number of the device. For example, a device, whose name is \Device\KeyboardPort0, has a unit number
		/// of zero, and a device, whose name is \Device\KeyboardPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;

		/// <summary>Specifies the scan code associated with a key press.</summary>
		public ushort MakeCode;

		/// <summary>
		/// <para>
		/// Specifies a bitwise OR of one or more of the following flags that indicate whether a key was pressed or released, and other
		/// miscellaneous information.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>KEY_MAKE</description>
		/// <description>The key was pressed.</description>
		/// </item>
		/// <item>
		/// <description>KEY_BREAK</description>
		/// <description>The key was released.</description>
		/// </item>
		/// <item>
		/// <description>KEY_E0</description>
		/// <description>Extended scan code used to indicate special keyboard functions.</description>
		/// </item>
		/// <item>
		/// <description>KEY_E1</description>
		/// <description>Extended scan code used to indicate special keyboard functions.</description>
		/// </item>
		/// </list>
		/// </summary>
		public KEYBOARD_INPUT_FLAGS Flags;

		/// <summary>Reserved for operating system use.</summary>
		public ushort Reserved;

		/// <summary>Specifies device-specific information associated with a keyboard event.</summary>
		public uint ExtraInformation;
	}

	/// <summary>KEYBOARD_TYPEMATIC_PARAMETERS specifies a keyboard's typematic settings.</summary>
	/// <remarks>
	/// This structure is used with IOCTL_KEYBOARD_QUERY_TYPEMATIC and IOCTL_KEYBOARD_SET_TYPEMATIC requests to query and set a keyboard's
	/// typematic settings.
	/// </remarks>
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_TYPEMATIC_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_TYPEMATIC_PARAMETERS
	{
		/// <summary>
		/// Specifies the unit number of a keyboard device. A keyboard device name has the format \Device\KeyboardPortN, where the suffix N
		/// is the unit number of the device. For example, a device, whose name is \Device\KeyboardPort0, has a unit number of zero, and a
		/// device, whose name is \Device\KeyboardPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;

		/// <summary>
		/// Specifies the rate at which character output from a keyboard repeats, in characters per second, after a key is pressed and
		/// continuously held down. The minimum possible value is KEYBOARD_TYPEMATIC_RATE_MINIMUM and the maximum possible value is
		/// KEYBOARD_TYPEMATIC_RATE_MAXIMUM. The default value is KEYBOARD_TYPEMATIC_RATE_DEFAULT.
		/// </summary>
		public ushort Rate;

		/// <summary>
		/// Specifies the amount of time that must elapse, in milliseconds, after a key is pressed and continuously held down, before the
		/// character output from a keyboard begins to repeat. The minimum possible delay is KEYBOARD_TYPEMATIC_DELAY_MINIMUM and the maximum
		/// possible delay is KEYBOARD_TYPEMATIC_DELAY_MAXIMUM. The default value is KEYBOARD_TYPEMATIC_DELAY_DEFAULT.
		/// </summary>
		public ushort Delay;
	}

	/// <summary>KEYBOARD_UNIT_ID_PARAMETER specifies the unit ID that Kbdclass assigns to a keyboard.</summary>
	/// <remarks>Although this structure is used with IOCTL_KEYBOARD_QUERY_Xxx requests, Kbdclass does not use the <b>UnitId</b> value.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddkbd/ns-ntddkbd-keyboard_unit_id_parameter typedef struct
	// _KEYBOARD_UNIT_ID_PARAMETER { USHORT UnitId; } KEYBOARD_UNIT_ID_PARAMETER, *PKEYBOARD_UNIT_ID_PARAMETER;
	[PInvokeData("ntddkbd.h", MSDNShortId = "NS:ntddkbd._KEYBOARD_UNIT_ID_PARAMETER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KEYBOARD_UNIT_ID_PARAMETER
	{
		/// <summary>
		/// Specifies the unit number of a keyboard device. A keyboard device name has the format \Device\KeyboardPort <i>N</i>, where the
		/// suffix <i>N</i> is the unit number of the device. For example, a device, whose name is \Device\KeyboardPort0, has a unit number
		/// of zero, and a device, whose name is \Device\KeyboardPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;
	}
}