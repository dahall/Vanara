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
	public const string DD_MOUSE_DEVICE_NAME = "\\Device\\PointerClass";

	/// <summary>
	/// <para>
	/// Device Name - this string is the name of the device. It is the name that should be passed to NtOpenFile when accessing the device.
	/// </para>
	/// <para>Note:  For devices that support multiple units, it should be suffixed with the Ascii representation of the unit number.</para>
	/// </summary>
	public const string DD_MOUSE_DEVICE_NAME_U = "\\Device\\PointerClass";

	/// <summary>Declare the GUID that represents the device interface for mice.</summary>
	public static readonly Guid GUID_DEVINTERFACE_MOUSE = new(0x378de44c, 0x56ef, 0x11d1, 0xbc, 0x8c, 0x00, 0xa0, 0xc9, 0x14, 0x05, 0xdd);

	/// <summary>Undocumented.</summary>
	public static uint IOCTL_MOUSE_INSERT_DATA = CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 1, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_MOUSE_QUERY_ATTRIBUTES request returns information about the mouse attributes.</para>
	/// <para>
	/// Mouclass copies the current stack location, sets the <b>MajorFunction</b> member of the new stack location to
	/// <c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c>, and sends this request down the device stack.
	/// </para>
	/// <para>For more information about this request, see <c>I8042prt Mouse Internal Device Control Requests</c>.</para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.InputBufferLength</b> member is set to zero or a value greater than or equal to the size, in bytes,
	/// of a <c>MOUSE_UNIT_ID_PARAMETER</c>. A value of zero specifies a default unit ID of zero.
	/// </para>
	/// <para>
	/// The <b>AssociatedIrp.SystemBuffer</b> member points to a client-allocated buffer that is used to input and output information. On
	/// input, <b>AssociatedIrp.SystemBuffer</b> points to a MOUSE_UNIT_ID_PARAMETER structure. The client sets the <b>UnitId</b> member of
	/// the input structure.
	/// </para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.OutputBufferLength</b> member specifies the size, in bytes, of an output buffer, which must be
	/// greater than or equal to the size in bytes of a <c>MOUSE_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>The size of a <c>MOUSE_UNIT_ID_PARAMETER</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>
	/// <b>AssociatedIrp.SystemBuffer</b> points to the client-allocated buffer that the lower-level drivers use to output a
	/// <c>MOUSE_ATTRIBUTES</c> structure.
	/// </para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <c>MOUSE_ATTRIBUTES</c> structure.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddmou/ni-ntddmou-ioctl_mouse_query_attributes
	[PInvokeData("ntddmou.h", MSDNShortId = "NI:ntddmou.IOCTL_MOUSE_QUERY_ATTRIBUTES")]
	public static uint IOCTL_MOUSE_QUERY_ATTRIBUTES = CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Specifies a bitwise OR of one or more of the following mouse indicator flags.</summary>
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_INPUT_DATA")]
	[Flags]
	public enum MOUSE_BUTTON_FLAG : ushort
	{
		/// <summary>The left mouse button changed to down.</summary>
		MOUSE_LEFT_BUTTON_DOWN = 0x0001,

		/// <summary>The left mouse button changed to up.</summary>
		MOUSE_LEFT_BUTTON_UP = 0x0002,

		/// <summary>The right mouse button changed to down.</summary>
		MOUSE_RIGHT_BUTTON_DOWN = 0x0004,

		/// <summary>The right mouse button changed to up.</summary>
		MOUSE_RIGHT_BUTTON_UP = 0x0008,

		/// <summary>The middle mouse button changed to down.</summary>
		MOUSE_MIDDLE_BUTTON_DOWN = 0x0010,

		/// <summary>The middle mouse button changed to up.</summary>
		MOUSE_MIDDLE_BUTTON_UP = 0x0020,

		/// <summary>The fourth mouse button changed to down.</summary>
		MOUSE_BUTTON_4_DOWN = 0x0040,

		/// <summary>The fourth mouse button changed to up.</summary>
		MOUSE_BUTTON_4_UP = 0x0080,

		/// <summary>The fifth mouse button changed to down.</summary>
		MOUSE_BUTTON_5_DOWN = 0x0100,

		/// <summary>The fifth mouse button changed to up.</summary>
		MOUSE_BUTTON_5_UP = 0x0200,

		/// <summary>Mouse wheel data is present.</summary>
		MOUSE_WHEEL = 0x0400,

		/// <summary>Mouse horizontal wheel data is present.</summary>
		MOUSE_HWHEEL = 0x0800,
	}

	/// <summary>Specifies one of the following types of mouse devices.</summary>
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_ATTRIBUTES")]
	[Flags]
	public enum MOUSE_IDENTIFIER : ushort
	{
		/// <summary>Inport (bus) mouse</summary>
		MOUSE_INPORT_HARDWARE = 0x1,

		/// <summary>i8042 port mouse</summary>
		MOUSE_I8042_HARDWARE = 0x2,

		/// <summary>Serial port mouse</summary>
		MOUSE_SERIAL_HARDWARE = 0x4,

		/// <summary>i8042 port ballpoint mouse</summary>
		BALLPOINT_I8042_HARDWARE = 0x8,

		/// <summary>Serial port ballpoint mouse</summary>
		BALLPOINT_SERIAL_HARDWARE = 0x10,

		/// <summary>i8042 port wheel mouse</summary>
		WHEELMOUSE_I8042_HARDWARE = 0x20,

		/// <summary>Serial port wheel mouse</summary>
		WHEELMOUSE_SERIAL_HARDWARE = 0x40,

		/// <summary>HIDClass mouse</summary>
		MOUSE_HID_HARDWARE = 0x80,

		/// <summary>HIDClass wheel mouse</summary>
		WHEELMOUSE_HID_HARDWARE = 0x100,

		/// <summary>Undocumented</summary>
		HORIZONTAL_WHEEL_PRESENT = 0x8000
	}

	/// <summary>Specifies a bitwise OR of one or more of the following mouse indicator flags.</summary>
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_INPUT_DATA")]
	[Flags]
	public enum MOUSE_INPUT_FLAG : ushort
	{
		/// <summary>The <b>LastX</b> and <b>LastY</b> are set relative to the previous location.</summary>
		MOUSE_MOVE_RELATIVE = 0x0000,

		/// <summary>The <b>LastX</b> and <b>LastY</b> values are set to absolute values.</summary>
		MOUSE_MOVE_ABSOLUTE = 0x0001,

		/// <summary>The mouse coordinates are mapped to the virtual desktop.</summary>
		MOUSE_VIRTUAL_DESKTOP = 0x0002,

		/// <summary>The mouse attributes have changed. The other data in the structure is not used.</summary>
		MOUSE_ATTRIBUTES_CHANGED = 0x0004,

		/// <summary>
		/// (Windows Vista and later) WM_MOUSEMOVE notification messages will not be coalesced. By default, these messages are coalesced. For
		/// more information about WM_MOUSEMOVE notification messages, see the Microsoft Software Development Kit (SDK) documentation
		/// </summary>
		MOUSE_MOVE_NOCOALESCE = 0x0008,
	}

	/// <summary>MOUSE_ATTRIBUTES specifies the attributes of a mouse device.</summary>
	/// <remarks>This structure is used with an <c>IOCTL_MOUSE_QUERY_ATTRIBUTES</c> request to obtain the attributes of a mouse.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddmou/ns-ntddmou-mouse_attributes typedef struct _MOUSE_ATTRIBUTES { USHORT
	// MouseIdentifier; USHORT NumberOfButtons; USHORT SampleRate; ULONG InputDataQueueLength; } MOUSE_ATTRIBUTES, *PMOUSE_ATTRIBUTES;
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MOUSE_ATTRIBUTES
	{
		/// <summary>
		/// <para>Specifies one of the following types of mouse devices.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Mouse type</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>BALLPOINT_I8042_HARDWARE</description>
		/// <description>i8042 port ballpoint mouse</description>
		/// </item>
		/// <item>
		/// <description>BALLPOINT_SERIAL_HARDWARE</description>
		/// <description>Serial port ballpoint mouse</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_HID_HARDWARE</description>
		/// <description>HIDClass mouse</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_I8042_HARDWARE</description>
		/// <description>i8042 port mouse</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_INPORT_HARDWARE</description>
		/// <description>Inport (bus) mouse</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_SERIAL_HARDWARE</description>
		/// <description>Serial port mouse</description>
		/// </item>
		/// <item>
		/// <description>WHEELMOUSE_HID_HARDWARE</description>
		/// <description>HIDClass wheel mouse</description>
		/// </item>
		/// <item>
		/// <description>WHEELMOUSE_I8042_HARDWARE</description>
		/// <description>i8042 port wheel mouse</description>
		/// </item>
		/// <item>
		/// <description>WHEELMOUSE_SERIAL_HARDWARE</description>
		/// <description>Serial port wheel mouse</description>
		/// </item>
		/// </list>
		/// </summary>
		public MOUSE_IDENTIFIER MouseIdentifier;

		/// <summary>
		/// Specifies the number of buttons supported by a mouse. A mouse can have from two to five buttons. The default value is MOUSE_NUMBER_OF_BUTTONS.
		/// </summary>
		public ushort NumberOfButtons;

		/// <summary>
		/// Specifies the rate, in reports per second, at which input from a PS/2 mouse is sampled. The default value is MOUSE_SAMPLE_RATE.
		/// This value is not used for USB devices.
		/// </summary>
		public ushort SampleRate;

		/// <summary>Specifies the size, in bytes, of the input data queue used by the port driver for a mouse device.</summary>
		public uint InputDataQueueLength;
	}

	/// <summary>MOUSE_INPUT_DATA contains one packet of mouse input data.</summary>
	/// <remarks>
	/// In response to <c>IRP_MJ_READ (Mouclass)</c> requests, Mouclass transfers zero or more <b>MOUSE_INPUT_DATA</b> structures from its
	/// internal data queue to the Microsoft Win32 subsystem buffer.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddmou/ns-ntddmou-mouse_input_data typedef struct _MOUSE_INPUT_DATA { USHORT
	// UnitId; USHORT Flags; union { ULONG Buttons; struct { USHORT ButtonFlags; USHORT ButtonData; }; }; ULONG RawButtons; LONG LastX; LONG
	// LastY; ULONG ExtraInformation; } MOUSE_INPUT_DATA, *PMOUSE_INPUT_DATA;
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_INPUT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct MOUSE_INPUT_DATA
	{
		/// <summary>
		/// Specifies the unit number of the mouse device. A mouse <c>device name</c> has the format \Device\PointerPort <i>N</i>, where the
		/// suffix <i>N</i> is the unit number of the device. For example, a device, whose name is \Device\PointerPort0, has a unit number of
		/// zero, and a device, whose name is \Device\PointerPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;

		/// <summary>
		/// <para>Specifies a bitwise OR of one or more of the following mouse indicator flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>MOUSE_MOVE_RELATIVE</description>
		/// <description>The <b>LastX</b> and <b>LastY</b> are set relative to the previous location.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_MOVE_ABSOLUTE</description>
		/// <description>The <b>LastX</b> and <b>LastY</b> values are set to absolute values.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_VIRTUAL_DESKTOP</description>
		/// <description>The mouse coordinates are mapped to the virtual desktop.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_ATTRIBUTES_CHANGED</description>
		/// <description>The mouse attributes have changed. The other data in the structure is not used.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_MOVE_NOCOALESCE</description>
		/// <description>
		/// (Windows Vista and later) WM_MOUSEMOVE notification messages will not be coalesced. By default, these messages are coalesced. For
		/// more information about WM_MOUSEMOVE notification messages, see the Microsoft Software Development Kit (SDK) documentation
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public MOUSE_INPUT_FLAG Flags;

		/// <summary>
		/// <para>Specifies the transition state of the mouse buttons.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>MOUSE_LEFT_BUTTON_DOWN</description>
		/// <description>The left mouse button changed to down.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_LEFT_BUTTON_UP</description>
		/// <description>The left mouse button changed to up.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_RIGHT_BUTTON_DOWN</description>
		/// <description>The right mouse button changed to down.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_RIGHT_BUTTON_UP</description>
		/// <description>The right mouse button changed to up.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_MIDDLE_BUTTON_DOWN</description>
		/// <description>The middle mouse button changed to down.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_MIDDLE_BUTTON_UP</description>
		/// <description>The middle mouse button changed to up.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_BUTTON_4_DOWN</description>
		/// <description>The fourth mouse button changed to down.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_BUTTON_4_UP</description>
		/// <description>The fourth mouse button changed to up.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_BUTTON_5_DOWN</description>
		/// <description>The fifth mouse button changed to down.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_BUTTON_5_UP</description>
		/// <description>The fifth mouse button changed to up.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_WHEEL</description>
		/// <description>Mouse wheel data is present.</description>
		/// </item>
		/// <item>
		/// <description>MOUSE_HWHEEL</description>
		/// <description>Mouse horizontal wheel data is present.</description>
		/// </item>
		/// </list>
		/// </summary>
		public MOUSE_BUTTON_FLAG ButtonFlags;

		/// <summary>Specifies mouse wheel data, if MOUSE_WHEEL is set in ButtonFlags.</summary>
		public ushort ButtonData;

		/// <summary>Specifies the raw state of the mouse buttons. The Win32 subsystem does not use this member.</summary>
		public uint RawButtons;

		/// <summary>Specifies the signed relative or absolute motion in the x direction.</summary>
		public int LastX;

		/// <summary>Specifies the signed relative or absolute motion in the y direction.</summary>
		public int LastY;

		/// <summary>Specifies device-specific information.</summary>
		public uint ExtraInformation;
	}

	/// <summary>MOUSE_UNIT_ID_PARAMETER specifies a unit ID that Mouclass assigns to a mouse.</summary>
	/// <remarks>
	/// Although this structure is used with an <c>IOCTL_MOUSE_QUERY_ATTRIBUTES</c> request, Mouclass does not use the <b>UnitId</b> value.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntddmou/ns-ntddmou-mouse_unit_id_parameter typedef struct _MOUSE_UNIT_ID_PARAMETER
	// { USHORT UnitId; } MOUSE_UNIT_ID_PARAMETER, *PMOUSE_UNIT_ID_PARAMETER;
	[PInvokeData("ntddmou.h", MSDNShortId = "NS:ntddmou._MOUSE_UNIT_ID_PARAMETER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MOUSE_UNIT_ID_PARAMETER
	{
		/// <summary>
		/// Specifies the unit number of the mouse device. A mouse <c>device name</c> has the format \Device\PointerPort <i>N</i>, where the
		/// suffix <i>N</i> is the unit number of the device. For example, a device, whose name is \Device\PointerPort0, has a unit number of
		/// zero, and a device, whose name is \Device\PointerPort1, has a unit number of one.
		/// </summary>
		public ushort UnitId;
	}
}