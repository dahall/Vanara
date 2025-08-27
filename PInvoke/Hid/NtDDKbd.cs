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

	//KEYBOARD_ATTRIBUTES
	//KEYBOARD_EXTENDED_ATTRIBUTES
	//KEYBOARD_INDICATOR_PARAMETERS
	//KEYBOARD_INDICATOR_TRANSLATION
	//KEYBOARD_TYPEMATIC_PARAMETERS
	//KEYBOARD_UNIT_ID_PARAMETER
}