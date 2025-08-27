#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>
	/// Valid bits for the PowerCapabilities REG_DWORD that can be put in the devnode indicating the presence of their respecitve power keys
	/// on the device
	/// </summary>
	[Flags]
	public enum I8042_BUTTONS
	{
		I8042_POWER_SYS_BUTTON = 0x0001,
		I8042_SLEEP_SYS_BUTTON = 0x0002,
		I8042_WAKE_SYS_BUTTON = 0x0004,
		I8042_SYS_BUTTONS = I8042_POWER_SYS_BUTTON | I8042_SLEEP_SYS_BUTTON | I8042_WAKE_SYS_BUTTON,
	}

	/// <summary>Synchronous reads and writes during kb initialization</summary>
	public enum I8042_PORT_TYPE
	{
		PortTypeData = 0,
		PortTypeCommand
	}

	public enum MOUSE_RESET_SUBSTATE
	{
		ExpectingReset = 0,
		ExpectingResetId,
		ExpectingGetDeviceIdACK,
		ExpectingGetDeviceIdValue,

		ExpectingSetResolutionDefaultACK,
		ExpectingSetResolutionDefaultValueACK,

		ExpectingSetResolutionACK,
		ExpectingSetResolutionValueACK,
		ExpectingSetScaling1to1ACK,
		ExpectingSetScaling1to1ACK2,
		ExpectingSetScaling1to1ACK3,
		ExpectingReadMouseStatusACK,
		ExpectingReadMouseStatusByte1,
		ExpectingReadMouseStatusByte2,
		ExpectingReadMouseStatusByte3,

		StartPnPIdDetection,

		ExpectingLoopSetSamplingRateACK,
		ExpectingLoopSetSamplingRateValueACK,

		ExpectingPnpIdByte1,
		ExpectingPnpIdByte2,
		ExpectingPnpIdByte3,
		ExpectingPnpIdByte4,
		ExpectingPnpIdByte5,
		ExpectingPnpIdByte6,
		ExpectingPnpIdByte7,

		EnableWheel,
		Enable5Buttons,

		ExpectingGetDeviceId2ACK,
		ExpectingGetDeviceId2Value,

		ExpectingSetSamplingRateACK,
		ExpectingSetSamplingRateValueACK,

		ExpectingEnableACK,

		ExpectingFinalResolutionACK,
		ExpectingFinalResolutionValueACK,

		ExpectingGetDeviceIdDetectACK,
		ExpectingGetDeviceIdDetectValue,

		CustomHookStateMinimum = 100,
		CustomHookStateMaximum = 999,

		I8042ReservedMinimum = 1000
	}

	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_CONTROLLER_WRITE_BUFFER request is not supported.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None</para>
	/// <para>Input buffer length</para>
	/// <para>None</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to STATUS_NOT_SUPPORTED.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_controller_write_buffer
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_CONTROLLER_WRITE_BUFFER")]
	public static uint IOCTL_INTERNAL_I8042_CONTROLLER_WRITE_BUFFER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0FF2, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_HOOK_KEYBOARD request does the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Adds an initialization callback routine to the I8042prt keyboard initialization routine</description>
	/// </item>
	/// <item>
	/// <description>Adds an ISR callback routine to the I8042prt keyboard ISR</description>
	/// </item>
	/// </list>
	/// <para>The initialization and ISR callbacks are optional and are provided by an upper-level filter driver for a PS/2-style keyboard device.</para>
	/// <para>After I8042prt receives an <c>IOCTL_INTERNAL_KEYBOARD_CONNECT</c> request, it sends a synchronous IOCTL_INTERNAL_I8042_HOOK_KEYBOARD request to the top of the keyboard device stack.</para>
	/// <para>After Kbfiltr receives the hook keyboard request, Kbfiltr filters the request in the following way:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Saves the upper-level information passed to Kbfiltr, which includes the context of an upper-level device object, a pointer to an initialization callback, and a pointer to an ISR callback</description>
	/// </item>
	/// <item>
	/// <description>Replaces the upper-level information with its own</description>
	/// </item>
	/// <item>
	/// <description>Saves the context of I8042prt and pointers to callbacks that the Kbfiltr ISR callback can use</description>
	/// </item>
	/// </list>
	/// <para>For more information about this request and the callbacks, see the following topics:</para>
	/// <list />
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to an INTERNAL_I8042_HOOK_KEYBOARD structure. This structure includes the following members:</para>
	/// <para>Input buffer length</para>
	/// <para>The <b>Parameters.DeviceIoControl.InputBufferLength</b> member is set to a value that is greater than or equal to the size, in bytes, of an <c>INTERNAL_I8042_HOOK_KEYBOARD</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is less than the size, in bytes, of an INTERNAL_I8042_HOOK_KEYBOARD structure.</para>
	/// <para><b>STATUS_SUCCESS</b></para>
	/// <para>The request completed successfully.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_hook_keyboard
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_HOOK_KEYBOARD")]
	public static uint IOCTL_INTERNAL_I8042_HOOK_KEYBOARD => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0FF0, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_HOOK_MOUSE request adds an ISR callback routine to the I8042prt mouse ISR. The ISR callback is optional and is provided by an upper-level mouse filter driver.</para>
	/// <para>I8042prt sends this request after it receives an <c>IOCTL_INTERNAL_MOUSE_CONNECT</c> request. I8042prt sends a synchronous IOCTL_INTERNAL_I8042_HOOK_MOUSE request to the top of the mouse device stack.</para>
	/// <para>After Moufiltr receives the hook mouse request, it filters the request in the following way:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Saves the upper-level information passed to Moufiltr, which includes the context of an upper-level device object and a pointer to an ISR callback</description>
	/// </item>
	/// <item>
	/// <description>Replaces the upper-level information with its own</description>
	/// </item>
	/// <item>
	/// <description>Saves the context of I8042prt and pointers to callbacks that the Moufiltr ISR callbacks can use</description>
	/// </item>
	/// </list>
	/// <para>For more information about this request and the callbacks, see the following topics:</para>
	/// <list />
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>The <b>Parameters.DeviceIoControl.InputBufferLength</b> member is set to a value greater than or equal to the size, in bytes, of an <c>INTERNAL_I8042_HOOK_MOUSE</c> structure.</para>
	/// <para>The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to an INTERNAL_I8042_HOOK_MOUSE structure that is allocated and set initially by I8042prt.</para>
	/// <para>Input buffer length</para>
	/// <para>The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to an INTERNAL_I8042_HOOK_MOUSE structure that is allocated and set initially by I8042prt.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is less than the size, in bytes, of an INTERNAL_I8042_HOOK_MOUSE structure.</para>
	/// <para><b>STATUS_SUCCESS</b></para>
	/// <para>The request completed successfully.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_hook_mouse
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_HOOK_MOUSE")]
	public static uint IOCTL_INTERNAL_I8042_HOOK_MOUSE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0FF0, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_KEYBOARD_START_INFORMATION request passes a pointer to a keyboard interrupt object. I8042prt sends this request synchronously to the top of the device stack after the keyboard interrupt object is created. Upper-level filter drivers that need to synchronize their callback operation with the I8042prt keyboard ISR can use the pointer to the keyboard interrupt object.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>AssociatedIrp.SystemBuffer</b> points to a buffer allocated by I8042prt to input an <c>INTERNAL_I8042_START_INFORMATION</c> structure.</para>
	/// <para>Input buffer length</para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> specifies the size, in bytes, of an <c>INTERNAL_I8042_START_INFORMATION</c> structure.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Information</b> member is set to zero.</para>
	/// <para>The <b>Status</b> member is set to STATUS_SUCCESS.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_keyboard_start_information
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_KEYBOARD_START_INFORMATION")]
	public static uint IOCTL_INTERNAL_I8042_KEYBOARD_START_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0FF3, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_KEYBOARD_WRITE_BUFFER request writes data to the i8042 port controller to control operation of a keyboard device. A filter driver can use this request to control the operation of a keyboard.</para>
	/// <para>I8042prt synchronizes write buffer requests and other keyboard requests that write to the i8042 port controller, including <c>IOCTL_KEYBOARD_SET_INDICATORS</c> and <c>IOCTL_KEYBOARD_SET_TYPEMATIC</c>. I8042prt synchronizes the actual write of data with the keyboard ISR.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to a client-allocated buffer which inputs the data to write to an i8042 port controller.</para>
	/// <para>Input buffer length</para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is set to the number of bytes in the input buffer, which must be greater than one.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_DEVICE_NOT_READY</b></para>
	/// <para>The keyboard interrupt is not initialized.</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para>The input parameters are not valid.</para>
	/// <para><b>STATUS_IO_TIMEOUT</b></para>
	/// <para>The request timed out.</para>
	/// <para><b>STATUS_SUCCESS</b></para>
	/// <para>The request completed successfully.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_keyboard_write_buffer
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_KEYBOARD_WRITE_BUFFER")]
	public static uint IOCTL_INTERNAL_I8042_KEYBOARD_WRITE_BUFFER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0FF1, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_MOUSE_START_INFORMATION request passes a pointer to a mouse interrupt object. I8042prt sends this request synchronously to the top of the device stack after the mouse interrupt object is created. Upper-level filter drivers that need to synchronize their callback operation with the mouse ISR can use the pointer to the mouse interrupt object.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to an input buffer allocated by I8042prt to input an <c>INTERNAL_I8042_START_INFORMATION</c> structure.</para>
	/// <para>Input buffer length</para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> specifies the size, in bytes, of an INTERNAL_I8042_START_INFORMATION structure.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Information</b> member is set to zero.</para>
	/// <para>The <b>Status</b> member is set to STATUS_SUCCESS.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_mouse_start_information
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_MOUSE_START_INFORMATION")]
	public static uint IOCTL_INTERNAL_I8042_MOUSE_START_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0FF3, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
	/// <summary>
	/// <para>The IOCTL_INTERNAL_I8042_MOUSE_WRITE_BUFFER request writes data to the i8042 port controller to control operation of a mouse device. An upper-level filter driver can use this request to control the operation of a mouse.</para>
	/// <para>I8042prt synchronizes write buffer requests with one another. I8042prt synchronizes the actual write of data with the mouse ISR.</para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para><b>Parameters.DeviceIoControl.Type3InputBuffer</b> points to a client-allocated buffer that supplies the data to write to an i8042 port controller.</para>
	/// <para>Input buffer length</para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is set to the number of bytes in the input buffer, which must be greater than 1.</para>
	/// <para>Output buffer</para>
	/// <para>None</para>
	/// <para>Output buffer length</para>
	/// <para>None</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_DEVICE_NOT_READY</b></para>
	/// <para>The mouse interrupt is not initialized.</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para>The input parameters are not valid.</para>
	/// <para><b>STATUS_IO_TIMEOUT</b></para>
	/// <para>The request timed out.</para>
	/// <para><b>STATUS_SUCCESS</b></para>
	/// <para>The request completed successfully.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ni-ntdd8042-ioctl_internal_i8042_mouse_write_buffer
	[PInvokeData("ntdd8042.h", MSDNShortId = "NI:ntdd8042.IOCTL_INTERNAL_I8042_MOUSE_WRITE_BUFFER")]
	public static uint IOCTL_INTERNAL_I8042_MOUSE_WRITE_BUFFER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0FF1, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>INTERNAL_I8042_HOOK_KEYBOARD is used by I8042prt to connect optional callback routines that supplement keyboard initialization and the keyboard ISR. The callbacks can be supplied by an optional, vendor-supplied, upper-level filter driver.</summary>
	/// <remarks>
	/// <para>This structure is only used with an <c>IOCTL_INTERNAL_I8042_HOOK_KEYBOARD</c> request.</para>
	/// <para><b>Context</b>, <b>InitializationRoutine</b>, and <b>IsrRoutine</b> can be supplied by an optional, vendor-supplied, upper-level filter driver.</para>
	/// <para><b>IsrWritePort</b>, <b>QueueKeyboardPacket</b>, and <b>CallContext</b> are supplied by I8042prt.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ns-ntdd8042-_internal_i8042_hook_keyboard
	// typedef struct _INTERNAL_I8042_HOOK_KEYBOARD { OUT PVOID Context; OUT PI8042_KEYBOARD_INITIALIZATION_ROUTINE InitializationRoutine; OUT PI8042_KEYBOARD_ISR IsrRoutine;
	// IN PI8042_ISR_WRITE_PORT IsrWritePort; IN PI8042_QUEUE_PACKET QueueKeyboardPacket; IN PVOID CallContext; } INTERNAL_I8042_HOOK_KEYBOARD, *PINTERNAL_I8042_HOOK_KEYBOARD;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NS:ntdd8042._INTERNAL_I8042_HOOK_KEYBOARD")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct INTERNAL_I8042_HOOK_KEYBOARD
	{
		/// <summary>Pointer, if non-<b>NULL</b>, to the context that must be used with the <b>InitializationRoutine</b> and <b>IsrRoutine</b> routines. Otherwise, <b>Context</b> is <b>NULL</b>.</summary>
		public IntPtr Context;
		/// <summary>Pointer, if non-<b>NULL</b>, to an optional <c>PI8042_KEYBOARD_INITIALIZATION_ROUTINE</c>callback. I8042prt uses this callback to initialize a device after the device is reset. Otherwise, <b>IntializatonRoutine</b> is <b>NULL</b>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_KEYBOARD_INITIALIZATION_ROUTINE InitializationRoutine;
		/// <summary>Pointer, if non-<b>NULL</b>, to an optional <c>PI8042_KEYBOARD_ISR</c> callback that customizes the operation of the I8042prt keyboard ISR. Otherwise, <b>IsrRoutine </b>is <b>NULL</b>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_KEYBOARD_ISR IsrRoutine;
		/// <summary>Pointer to the system-supplied <c>PI8042_ISR_WRITE_PORT</c> callback, which writes data to a keyboard.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_ISR_WRITE_PORT IsrWritePort;
		/// <summary>Pointer to the system-supplied <c>PI8042_QUEUE_PACKET</c> callback, which queues a keyboard input data packet for processing by the keyboard's ISR deferred procedure call.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_QUEUE_PACKET QueueKeyboardPacket;
		/// <summary>Pointer to the context that must be used with the <b>IsrWritePort</b> and <b>QueueKeyboardPacket</b> routines.</summary>
		public IntPtr CallContext;
	}

	/// <summary>INTERNAL_I8042_HOOK_MOUSE is used by I8042prt to connect an optional callback routine that supplements the operation of the mouse ISR. The callback can be supplied by an optional, vendor-supplied, upper-level filter driver.</summary>
	/// <remarks>
	/// <para>This structure is only used with an <c>IOCTL_INTERNAL_I8042_HOOK_MOUSE</c> request.</para>
	/// <para><b>Context</b>, <b>InitializationRoutine</b>, and <b>IsrRoutine</b> can be supplied by an optional, vendor-supplied, upper-level filter driver.</para>
	/// <para><b>IsrWritePort</b>, <b>QueueMousePacket</b>, and <b>CallContext</b> are supplied by I8042prt.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ns-ntdd8042-_internal_i8042_hook_mouse
	// typedef struct _INTERNAL_I8042_HOOK_MOUSE { OUT PVOID Context; OUT PI8042_MOUSE_ISR IsrRoutine; IN PI8042_ISR_WRITE_PORT IsrWritePort; IN PI8042_QUEUE_PACKET QueueMousePacket; IN PVOID CallContext; } INTERNAL_I8042_HOOK_MOUSE, *PINTERNAL_I8042_HOOK_MOUSE;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NS:ntdd8042._INTERNAL_I8042_HOOK_MOUSE")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct INTERNAL_I8042_HOOK_MOUSE
	{
		/// <summary>Pointer, if non-<b>NULL</b>, to the context that must be used with the <b>IsrRoutine</b> routine. Otherwise, <b>Context</b> is <b>NULL</b>.</summary>
		public IntPtr Context;
		/// <summary>Pointer, if non-<b>NULL</b>, to an optional <c>PI8042_MOUSE_ISR</c> callback that customizes the operation of the I8042prt mouse ISR. Otherwise, <b>IsrRoutine </b>is <b>NULL</b>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_MOUSE_ISR IsrRoutine;
		/// <summary>Pointer to the system-supplied mouse <c>PI8042_ISR_WRITE_PORT</c> callback, which writes data to a mouse.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_ISR_WRITE_PORT IsrWritePort;
		/// <summary>Pointer to the system-supplied mouse <c>PI8042_QUEUE_PACKET</c> callback, which queues a mouse input data packet for processing by the mouse's ISR deferred procedure call.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PI8042_QUEUE_PACKET QueueMousePacket;
		/// <summary>Pointer to the context that must be used with the <b>IsrWritePort</b> and <b>QueueMousePacket</b> routines.</summary>
		public IntPtr CallContext;
	}

	/// <summary>INTERNAL_I8042_START_INFORMATION specifies the <c>interrupt object</c> that an optional, vendor-supplied, upper-level filter device driver can use to synchronize its operation with an I8042prt ISR.</summary>
	/// <remarks>This structure is used with <c>IOCTL_INTERNAL_I8042_KEYBOARD_START_INFORMATION</c> and <c>IOCTL_INTERNAL_I8042_MOUSE_START_INFORMATION</c> requests.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ns-ntdd8042-_internal_i8042_start_information
	// typedef struct _INTERNAL_I8042_START_INFORMATION { ULONG Size; PKINTERRUPT InterruptObject; ULONG Reserved[8]; } INTERNAL_I8042_START_INFORMATION, *PINTERNAL_I8042_START_INFORMATION;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NS:ntdd8042._INTERNAL_I8042_START_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct INTERNAL_I8042_START_INFORMATION
	{
		/// <summary>Specifies the size, in bytes, of an INTERNAL_I8042_START_INFORMATION structure.</summary>
		public uint Size;
		/// <summary>Pointer to an interrupt object. I8042prt supplies the interrupt object.</summary>
		public IntPtr InterruptObject;
		/// <summary>Reserved for future use.</summary>
		public unsafe fixed uint Reserved[8];
	}

	/// <summary>The KEYBOARD_SCAN_STATE enumeration type indicates the scan state of an input byte from a keyboard.</summary>
	/// <remarks>This enumeration type is used as input to an optional <c>KbFilter_IsrHook</c> routine, which can be supplied by a vendor-supplied keyboard filter driver.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ne-ntdd8042-_keyboard_scan_state
	// typedef enum _KEYBOARD_SCAN_STATE { Normal, GotE0, GotE1 } KEYBOARD_SCAN_STATE, *PKEYBOARD_SCAN_STATE;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NE:ntdd8042._KEYBOARD_SCAN_STATE")]
	public enum KEYBOARD_SCAN_STATE
	{
		/// <summary>
		///   <para>Indicates that the current byte is a</para>
		///   <para>Normal</para>
		///   <para>scan code (a nonextended code).</para>
		/// </summary>
		Normal,
		/// <summary>Indicates that the current byte is an E0 extended scan code.</summary>
		GotE0,
		/// <summary>Indicates that the current byte is an E1 extended scan code.</summary>
		GotE1,
	}

	/// <summary>The MOUSE_STATE enumeration type identifies the current state of input from a mouse.</summary>
	/// <remarks>The MOUSE_STATE enumerator is used as input to a <c>PI8042_MOUSE_ISR</c> callback.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ne-ntdd8042-_mouse_state
	// typedef enum _MOUSE_STATE { MouseIdle, XMovement, YMovement, ZMovement, MouseExpectingACK, MouseResetting } MOUSE_STATE, *PMOUSE_STATE;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NE:ntdd8042._MOUSE_STATE")]
	public enum MOUSE_STATE
	{
		/// <summary>Indicates that the next input byte from a mouse should be a status byte that specifies the button state and the sign and overflow bits for the x and y movement.</summary>
		MouseIdle,
		/// <summary>Indicates that the next input byte from a mouse should be a byte that specifies movement data in the x-direction.</summary>
		XMovement,
		/// <summary>Indicates that the next input byte from a mouse should be a byte that specifies movement data in the y-direction.</summary>
		YMovement,
		/// <summary>Indicates that the next input byte from a mouse should be a byte that specifies movement data in the z-direction (generated by a wheel mouse).</summary>
		ZMovement,
		/// <summary>Indicates that the next input byte from a mouse should be an acknowledgment from an enable mouse command.</summary>
		MouseExpectingACK,
		/// <summary>Indicates that I8042prt is resetting the mouse.</summary>
		MouseResetting,
	}

	/// <summary>OUTPUT_PACKET contains information about the data that is being written to a keyboard or mouse device by I8042prt.</summary>
	/// <remarks>This structure is used with a <c>PI8042_KEYBOARD_ISR</c> callback routine and a <c>PI8042_MOUSE_ISR</c> callback routine.</remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/ns-ntdd8042-_output_packet
	// typedef struct _OUTPUT_PACKET { PUCHAR Bytes; ULONG CurrentByte; ULONG ByteCount; TRANSMIT_STATE State; } OUTPUT_PACKET, *POUTPUT_PACKET;
	[PInvokeData("ntdd8042.h", MSDNShortId = "NS:ntdd8042._OUTPUT_PACKET")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct OUTPUT_PACKET
	{
		/// <summary>Pointer to an array of bytes being written to an i8042 port device.</summary>
		public IntPtr Bytes;
		/// <summary>Specifies the index of the next byte to write.</summary>
		public uint CurrentByte;
		/// <summary>Specifies the number of bytes in the array of bytes located at <b>Bytes</b>.</summary>
		public uint ByteCount;
		/// <summary>Specifies one of the following write states:</summary>
		public TRANSMIT_STATE State;
	}

	/// <summary>Specifies one of the following write states:</summary>
	[PInvokeData("ntdd8042.h", MSDNShortId = "NS:ntdd8042._OUTPUT_PACKET")]
	public enum TRANSMIT_STATE
	{
		/// <summary>Identifies that a write is not in progress.</summary>
		Idle = 0,
		/// <summary>Identifies that a write is in progress.</summary>
		SendingBytes
	}

	/// <summary>The PI8042_ISR_WRITE_PORT-typed callback routine writes data to an i8042 port. I8042prt provides this callback.</summary>
	/// <param name="Context">Pointer to the function device object that represents a keyboard or mouse device.</param>
	/// <param name="Value">Specifies the data to write to an i8042 port.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The PI8042_ISR_WRITE_PORT callback should only be called by a <c>PI8042_KEYBOARD_ISR</c> callback or a <c>PI8042_MOUSE_ISR</c> callback. I8042prt calls a vendor-supplied ISR callback for a device in the corresponding I8042prt device ISR.</para>
	/// <para>I8042prt specifies the keyboard write port callback in the <b>IsrWritePort</b> member of the <c>INTERNAL_I8042_HOOK_KEYBOARD</c> structure that I8042prt uses with an <c>IOCTL_INTERNAL_I8042_HOOK_KEYBOARD</c> request.</para>
	/// <para>I8042prt specifies the mouse write port callback in the <b>IsrWritePort</b> member of the <c>INTERNAL_I8042_HOOK_MOUSE</c> structure that I8042prt uses with an <c>IOCTL_INTERNAL_I8042_HOOK_KEYBOARD</c> request.</para>
	/// <para>The PI8042_ISR_WRITE_PORT callback runs in kernel mode at the same IRQL as the I8042prt ISR for the device.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_isr_write_port
	// PI8042_ISR_WRITE_PORT Pi8042IsrWritePort; VOID Pi8042IsrWritePort( [in] PVOID Context, [in] UCHAR Value ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_ISR_WRITE_PORT")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void PI8042_ISR_WRITE_PORT([In] IntPtr Context, byte Value);

	/// <summary>A PI8042_KEYBOARD_INITIALIZATION_ROUTINE-typed callback routine supplements the default initialization of a keyboard device by I8042prt.</summary>
	/// <param name="InitializationContext">Pointer to the filter device object of the driver that supplies the callback.</param>
	/// <param name="SynchFuncContext">Pointer to the context for the callbacks that are pointed to by <i>ReadPort</i> and <i>Writeport.</i></param>
	/// <param name="ReadPort">Pointer to a <c>PI8042_SYNCH_READ_PORT</c> callback that reads from the port.</param>
	/// <param name="WritePort">Pointer to a <c>PI8042_SYNCH_WRITE_PORT</c> callback that writes to the port.</param>
	/// <param name="TurnTranslationOn">Specifies whether to turn translation on or off. If <i>TranslationOn</i> is <b>TRUE</b>, translation is turned on; otherwise, translation is turned off.</param>
	/// <returns>A PI8042_KEYBOARD_INITIALIZATION_ROUTINE callback returns an appropriate NTSTATUS code.</returns>
	/// <remarks>
	/// <para>An upper-level keyboard filter driver can provide a PI8042_KEYBOARD_INITIALIZATION_ROUTINE callback.</para>
	/// <para>If an upper-level keyboard filter driver supplies an initialization callback, I8042prt calls the filter initialization callback when I8042prt initializes the keyboard. Default keyboard initialization includes the following operations: reset the keyboard, set the typematic rate and delay, and set the light-emitting diodes (LED).</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_keyboard_initialization_routine
	// PI8042_KEYBOARD_INITIALIZATION_ROUTINE Pi8042KeyboardInitializationRoutine; NTSTATUS Pi8042KeyboardInitializationRoutine( [in] PVOID
	// InitializationContext, [in] PVOID SynchFuncContext, [in] PI8042_SYNCH_READ_PORT ReadPort, [in] PI8042_SYNCH_WRITE_PORT WritePort,
	// [out] PBOOLEAN TurnTranslationOn ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_KEYBOARD_INITIALIZATION_ROUTINE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus PI8042_KEYBOARD_INITIALIZATION_ROUTINE([In] IntPtr InitializationContext, [In] IntPtr SynchFuncContext,
		[In] PI8042_SYNCH_READ_PORT ReadPort, [In] PI8042_SYNCH_WRITE_PORT WritePort, [MarshalAs(UnmanagedType.U1)] out bool TurnTranslationOn);

	/// <summary>A PI8042_KEYBOARD_ISR-typed callback routine customizes the operation of the I8042prt keyboard ISR.</summary>
	/// <param name="IsrContext">Pointer to the filter device object of the driver that supplies a callback.</param>
	/// <param name="CurrentInput">Pointer to the input <c>KEYBOARD_INPUT_DATA</c> structure that is being constructed by the ISR.</param>
	/// <param name="CurrentOutput">Pointer to an <c>OUTPUT_PACKET</c> structure, which specifies an array of bytes that is being written to the hardware device.</param>
	/// <param name="StatusByte">Specifies the status byte that is read from I/O port 60 when an interrupt occurs.</param>
	/// <param name="Byte">Specifies the data byte that is read from I/O port 64 when an interrupt occurs.</param>
	/// <param name="ContinueProcessing">Specifies, if <b>TRUE</b>, that processing in the I8042prt keyboard ISR will continue after this callback completes. Otherwise, processing does not continue.</param>
	/// <param name="ScanState">Pointer to a <c>KEYBOARD_SCAN_STATE</c> enumeration value, which identifies the keyboard scan state.</param>
	/// <returns>A PI8042_KEYBOARD_ISR callback returns <b>TRUE</b> if the I8042prt keyboard ISR should continue; otherwise it returns <b>FALSE</b>.</returns>
	/// <remarks>
	/// <para>A PI8042_KEYBOARD_ISR callback is not needed if the default operation of the I8042prt keyboard ISR is sufficient.</para>
	/// <para>An optional, vendor-supplied, upper-level keyboard filter driver can provide a PI8042_KEYBOARD_ISR callback. The I8042prt ISR calls the callback after it validates the interrupt and reads the scan code.</para>
	/// <para>The PI8042_KEYBOARD_ISR callback runs in kernel mode at the IRQL of the I8042prt keyboard ISR.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_keyboard_isr PI8042_KEYBOARD_ISR
	// Pi8042KeyboardIsr; BOOLEAN Pi8042KeyboardIsr( [in] PVOID IsrContext, [in] PKEYBOARD_INPUT_DATA CurrentInput, [in] POUTPUT_PACKET
	// CurrentOutput, [in] UCHAR StatusByte, [in] PUCHAR Byte, [out] PBOOLEAN ContinueProcessing, [in] PKEYBOARD_SCAN_STATE ScanState ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_KEYBOARD_ISR")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PI8042_KEYBOARD_ISR([In] IntPtr IsrContext, in KEYBOARD_INPUT_DATA CurrentInput,
		in OUTPUT_PACKET CurrentOutput, byte StatusByte, in byte Byte, [MarshalAs(UnmanagedType.U1)] out bool ContinueProcessing,
		in KEYBOARD_SCAN_STATE ScanState);

	/// <summary>A PI8042_MOUSE_ISR-typed callback routine customizes the operation of the I8042prt mouse ISR.</summary>
	/// <param name="IsrContext">Pointer to the filter device object of the driver that supplies this callback.</param>
	/// <param name="CurrentInput">Pointer to the input <c>MOUSE_INPUT_DATA</c> structure being constructed by the ISR.</param>
	/// <param name="CurrentOutput">Pointer to an <c>OUTPUT_PACKET</c> structure, which specifies an array of bytes being written to the hardware device.</param>
	/// <param name="StatusByte">Specifies a status byte that is read from I/O port 60 when the interrupt occurs.</param>
	/// <param name="Byte">Specifies a data byte that is read from I/O port 64 when the interrupt occurs.</param>
	/// <param name="ContinueProcessing">Specifies, if <b>TRUE</b>, that processing in the I8042prt mouse ISR will continue after this callback completes. Otherwise, processing does not continue.</param>
	/// <param name="MouseState">Pointer to a <c>MOUSE_STATE</c> enumeration value, which identifies the state of mouse input.</param>
	/// <param name="ResetSubState">Pointer to MOUSE_RESET_SUBSTATE enumeration value, which identifies the mouse reset substate. See the Remarks section.</param>
	/// <returns>A PI8042_MOUSE_ISR callback returns <b>TRUE</b> if the I8042prt mouse ISR should continue; otherwise it returns <b>FALSE</b>.</returns>
	/// <remarks>
	/// <para>A PI8042_MOUSE_ISR callback is not needed if the default operation of the I8042prt mouse ISR is sufficient.</para>
	/// <para>An upper-level keyboard filter driver can provide a mouse ISR callback. After the I8042prt mouse ISR validates the interrupt, it calls the mouse ISR callback.</para>
	/// <para>To reset a mouse, I8042prt goes through a sequence of operational substates, each one of which is identified by a MOUSE_RESET_SUBSTATE enumeration value. For more information about how I8042prt resets a mouse and the corresponding mouse reset substates, see the documentation of MOUSE_RESET_SUBSTATE in ntdd8042.h.</para>
	/// <para>A PI8042_MOUSE_ISR callback runs in kernel mode at the IRQL of the I8042prt mouse ISR.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_mouse_isr PI8042_MOUSE_ISR Pi8042MouseIsr;
	// BOOLEAN Pi8042MouseIsr( [in] PVOID IsrContext, [in] PMOUSE_INPUT_DATA CurrentInput, [in] POUTPUT_PACKET CurrentOutput, [in] UCHAR
	// StatusByte, [in] PUCHAR Byte, [in, out] PBOOLEAN ContinueProcessing, [in] PMOUSE_STATE MouseState, [in] PMOUSE_RESET_SUBSTATE
	// ResetSubState ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_MOUSE_ISR")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool PI8042_MOUSE_ISR([In] IntPtr IsrContext, in MOUSE_INPUT_DATA CurrentInput, in OUTPUT_PACKET CurrentOutput,
		byte StatusByte, in byte Byte, [MarshalAs(UnmanagedType.U1)] ref bool ContinueProcessing, in MOUSE_STATE MouseState,
		in MOUSE_RESET_SUBSTATE ResetSubState);

	/// <summary>The PI8042_QUEUE_PACKET-typed callback routine queues an input data packet for processing by the ISR DPC of a keyboard or mouse device. I8042prt provides this callback.</summary>
	/// <param name="Context">Pointer to the function device object that represents a keyboard or mouse device.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>The PI8042_QUEUE_PACKET callback should only be called by a <c>PI8042_KEYBOARD_ISR</c> callback or a<c>PI8042_MOUSE_ISR</c> callback. I8042prt calls a vendor-supplied ISR callback in the corresponding I8042prt device ISR.</para>
	/// <para>I8042prt specifies the queue packet callback for a keyboard in the <b>QueueKeyboardPacket</b> member of the <c>INTERNAL_I8042_HOOK_KEYBOARD</c> structure that I8042prt uses with an <c>IOCTL_INTERNAL_I8042_HOOK_KEYBOARD</c> request.</para>
	/// <para>I8042prt specifies the queue packet callback for a mouse in the <b>QueueMousePacket</b> member of an <c>INTERNAL_I8042_HOOK_MOUSE</c> structure that I8042prt uses with an <c>IOCTL_INTERNAL_I8042_HOOK_MOUSE</c> request.</para>
	/// <para>The PI8042_QUEUE_PACKET callback runs in kernel mode at the same IRQL as the I8042prt ISR for the device.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_queue_packet
	// PI8042_QUEUE_PACKET Pi8042QueuePacket; VOID Pi8042QueuePacket( [in] PVOID Context ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_QUEUE_PACKET")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void PI8042_QUEUE_PACKET([In] IntPtr Context);

	/// <summary>The PI8042_SYNCH_READ_PORT-typed callback routine does a synchronized read from an i8042 port. I8042prt supplies this callback.</summary>
	/// <param name="Context">Pointer to a context supplied by I8042prt.</param>
	/// <param name="Value">Pointer to the UCHAR value returned by the routine.</param>
	/// <param name="WaitForACK">Not used.</param>
	/// <returns>
	/// <para>The PI8042_SYNCH_READ_PORT callback returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>STATUS_SUCCESS</b></description>
	/// <description>The routine successfully returned a byte.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_IO_TIMEOUT</b></description>
	/// <description>The hardware was not ready for a read access.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The PI8042_SYNCH_READ_PORT callback can only be used in a <c>PI8042_KEYBOARD_INITIALIZATION_ROUTINE</c> callback. I8042prt specifies the read port callback in the <i>ReadPort</i> parameter that I8042prt inputs to a keyboard initialization routine.</para>
	/// <para>The routine polls the hardware until a read is returned by the hardware or an internal time-out occurs.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_synch_read_port
	// PI8042_SYNCH_READ_PORT Pi8042SynchReadPort; NTSTATUS Pi8042SynchReadPort( [in] PVOID Context, [out] PUCHAR Value, [in] BOOLEAN WaitForACK ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_SYNCH_READ_PORT")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus PI8042_SYNCH_READ_PORT([In] IntPtr Context, [Out] IntPtr Value, [MarshalAs(UnmanagedType.U1)] bool WaitForACK);

	/// <summary>The PI8042_SYNCH_READ_PORT-typed callback routine does a synchronized write to an i8042 port. I8042prt supplies this routine.</summary>
	/// <param name="Context">Pointer to a context supplied by I8042prt.</param>
	/// <param name="Value">Specifies the UCHAR value to write to an i8042 port.</param>
	/// <param name="WaitForACK">Specifies, if <b>TRUE</b>, that the routine waits until the write is acknowledged by the i8042 port. Otherwise, the routine returns without waiting for an acknowledgment from the port.</param>
	/// <returns>
	/// <para>The PI8042_SYNCH_WRITE_PORT callback returns one of the following status values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>STATUS_SUCCESS</b></description>
	/// <description>The routine successfully wrote a byte to an i8042 port.</description>
	/// </item>
	/// <item>
	/// <description><b>STATUS_IO_TIMEOUT</b></description>
	/// <description>The hardware was not ready for a write access.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The PI8042_SYNCH_READ_PORT callback can only be used in a <c>PI8042_KEYBOARD_INITIALIZATION_ROUTINE</c> callback. I8042prt specifies the write port callback in the <i>WritePort</i> parameter that I8042prt inputs to a keyboard initialization routine.</para>
	/// <para>The routine polls the hardware until a read is returned by the hardware or an internal time-out occurs.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdd8042/nc-ntdd8042-pi8042_synch_write_port
	// PI8042_SYNCH_WRITE_PORT Pi8042SynchWritePort; NTSTATUS Pi8042SynchWritePort( [in] PVOID Context, [in] UCHAR Value, [in] BOOLEAN WaitForACK ) {...}
	[PInvokeData("ntdd8042.h", MSDNShortId = "NC:ntdd8042.PI8042_SYNCH_WRITE_PORT")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate NTStatus PI8042_SYNCH_WRITE_PORT([In] IntPtr Context, byte Value, [MarshalAs(UnmanagedType.U1)] bool WaitForACK);
}