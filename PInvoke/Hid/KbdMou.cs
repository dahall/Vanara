using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class Hid
{
	/// <summary>Define the keyboard/mouse class device name strings.</summary>
	public const string DD_KEYBOARD_CLASS_BASE_NAME_U = "KeyboardClass";

	/// <summary>Define the keyboard/mouse resource class names.</summary>
	public const string DD_KEYBOARD_MOUSE_COMBO_RESOURCE_CLASS_NAME_U = "Keyboard/Pointer";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_KEYBOARD_PORT_BASE_NAME_U = "KeyboardPort";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_KEYBOARD_PORT_DEVICE_NAME = "\\Device\\KeyboardPort";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_KEYBOARD_PORT_DEVICE_NAME_U = "\\Device\\KeyboardPort";

	/// <summary>Define the keyboard/mouse resource class names.</summary>
	public const string DD_KEYBOARD_RESOURCE_CLASS_NAME_U = "Keyboard";

	/// <summary>Define the keyboard/mouse class device name strings.</summary>
	public const string DD_POINTER_CLASS_BASE_NAME_U = "PointerClass";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_POINTER_PORT_BASE_NAME_U = "PointerPort";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_POINTER_PORT_DEVICE_NAME = "\\Device\\PointerPort";

	/// <summary>Define the keyboard/mouse port device name strings.</summary>
	public const string DD_POINTER_PORT_DEVICE_NAME_U = "\\Device\\PointerPort";

	/// <summary>Define the keyboard/mouse resource class names.</summary>
	public const string DD_POINTER_RESOURCE_CLASS_NAME_U = "Pointer";

	/// <summary>Define the base values for the error log packet's UniqueErrorValue field.</summary>
	public const int I8042_ERROR_VALUE_BASE = 1000;

	/// <summary>Define the base values for the error log packet's UniqueErrorValue field.</summary>
	public const int INPORT_ERROR_VALUE_BASE = 2000;

	/// <summary>Define the maximum number of pointer/keyboard port names the port driver will use in an attempt to IoCreateDevice.</summary>
	public const int KEYBOARD_PORTS_MAXIMUM = 8;

	/// <summary>Define the maximum number of pointer/keyboard port names the port driver will use in an attempt to IoCreateDevice.</summary>
	public const int POINTER_PORTS_MAXIMUM = 8;

	/// <summary>Define the base values for the error log packet's UniqueErrorValue field.</summary>
	public const int SERIAL_MOUSE_ERROR_VALUE_BASE = 3000;

	/// <summary>
	/// A function driver calls the class service callback in its ISR dispatch completion routine. The class service callback transfers input
	/// data from the input data buffer of a device to the class data queue.
	/// </summary>
	/// <param name="NormalContext">Pointer to the class device object.</param>
	/// <param name="SystemArgument1">Pointer to the first keyboard input data packet in the input data buffer of the port device.</param>
	/// <param name="SystemArgument2">
	/// Pointer to the keyboard input data packet that immediately follows the last data packet in the input data buffer of the port device.
	/// </param>
	/// <param name="SystemArgument3">Pointer to the number of keyboard input data packets that are transferred by the routine.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para><b>Keyboard Class Service Callback</b></para>
	/// <para>Here is the definition of the keyboard class service callback routine.</para>
	/// <para>
	/// Kbdclass uses an <c>IOCTL_INTERNAL_KEYBOARD_CONNECT</c> request to connect its class service callback to a keyboard device. In this
	/// call, the driver sets its implementation in a <c>CONNECT_DATA</c> structure.
	/// </para>
	/// <para>
	/// <c>/* DeviceObject [in] Pointer to the class device object. InputDataStart [in] Pointer to the first keyboard input data packet in
	/// the input data buffer of the port device. InputDataEnd [in] Pointer to the keyboard input data packet that immediately follows the
	/// last data packet in the input data buffer of the port device. InputDataConsumed [in, out] Pointer to the number of keyboard input
	/// data packets that are transferred by the routine. */ VOID KeyboardClassServiceCallback( _In_ PDEVICE_OBJECT DeviceObject, _In_
	/// PKEYBOARD_INPUT_DATA InputDataStart, _In_ PKEYBOARD_INPUT_DATA InputDataEnd, _Inout_ PULONG InputDataConsumed );</c>
	/// </para>
	/// <para>
	/// <b>KeyboardClassServiceCallback</b> transfers input data from the input buffer of the device to the class data queue. This routine is
	/// called by the ISR dispatch completion routine of the function driver.
	/// </para>
	/// <para>
	/// <b>KeyboardClassServiceCallback</b> can be supplemented by a filter service callback that is provided by an upper-level keyboard
	/// filter driver. A filter service callback filters the keyboard data that is transferred to the class data queue. For example, the
	/// filter service callback can delete, transform, or insert data. <c>Kbfiltr</c>, the sample filter driver in code gallery, includes
	/// <b>KbFilter_ServiceCallback</b>, which is a template for a keyboard filter service callback.
	/// </para>
	/// <para><b>Mouse Class Service Callback</b></para>
	/// <para>
	/// Here is the <b>MouseClassServiceCallback</b> routine is the class service callback routine that is provided by Mouclass. The driver
	/// uses an <c>IOCTL_INTERNAL_MOUSE_CONNECT</c> request to connect its class service callback to a mouse device. In this call, the driver
	/// sets its implementation in a <c>CONNECT_DATA</c> structure.
	/// </para>
	/// <para>
	/// <c>/* DeviceObject [in] Pointer to the class device object. InputDataStart [in] Pointer to the first mouse input data packet in the
	/// input buffer of the port device. InputDataEnd [in] Pointer to the mouse input data packet that immediately follows the last data
	/// packet in the input data buffer of the port device. InputDataConsumed [in, out] Pointer to the number of mouse input data packets
	/// that are transferred by the routine. */ VOID MouseClassServiceCallback( _In_ PDEVICE_OBJECT DeviceObject, _In_ PMOUSE_INPUT_DATA
	/// InputDataStart, _In_ PMOUSE_INPUT_DATA InputDataEnd, _Inout_ PULONG InputDataConsumed ); );</c>
	/// </para>
	/// <para>
	/// <b>MouseClassServiceCallback</b> transfers input data from the input buffer of the device to the class data queue. This routine is
	/// called by the ISR dispatch completion routine of the function driver.
	/// </para>
	/// <para>
	/// <b>MouseClassServiceCallback</b> can be supplemented by a filter service callback that is provided by an upper-level mouse filter
	/// driver. A filter service callback can filter the mouse data that is transferred to the class data queue. For example, the filter
	/// service callback can delete, transform, or insert data. <c>Moufiltr</c>, the sample filter driver in the WDK, includes
	/// <b>MouFilter_ServiceCallback</b>, which is a template for a filter service callback.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/nc-kbdmou-pservice_callback_routine PSERVICE_CALLBACK_ROUTINE
	// PserviceCallbackRoutine; VOID PserviceCallbackRoutine( [in] PVOID NormalContext, [in] PVOID SystemArgument1, [in] PVOID
	// SystemArgument2, [in, out] PVOID SystemArgument3 ) {...}
	[PInvokeData("kbdmou.h", MSDNShortId = "NC:kbdmou.PSERVICE_CALLBACK_ROUTINE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void PSERVICE_CALLBACK_ROUTINE([In] IntPtr NormalContext, [In] IntPtr SystemArgument1, [In] IntPtr SystemArgument2, [In, Out] IntPtr SystemArgument3);

	/// <summary/>
	[Flags]
	public enum KBDMOU : uint
	{
		/// <summary/>
		KBDMOU_COULD_NOT_SEND_COMMAND = 0x0000,

		/// <summary/>
		KBDMOU_COULD_NOT_SEND_PARAM = 0x0001,

		/// <summary/>
		KBDMOU_NO_RESPONSE = 0x0002,

		/// <summary/>
		KBDMOU_INCORRECT_RESPONSE = 0x0004,
	}

	/// <summary>
	/// <para>
	/// The IOCTL_INTERNAL_KEYBOARD_CONNECT request connects the Kbdclass service to the keyboard device. Kbdclass sends this request down
	/// the keyboard device stack before it opens the keyboard device.
	/// </para>
	/// <para>After Kbfiltr received the keyboard connect request, Kbfiltr filters the connect request in the following way:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Saves a copy of Kbdclass's <c>CONNECT_DATA (Kbdclass)</c> structure that is passed to the filter driver by Kbdclass</description>
	/// </item>
	/// <item>
	/// <description>Substitutes its own connect information for the class driver connect information</description>
	/// </item>
	/// <item>
	/// <description>Sends the IOCTL_INTERNAL_KEYBOARD_CONNECT request down the device stack</description>
	/// </item>
	/// </list>
	/// <para>If the request is not successful, Kbfiltr completes the request with an appropriate error status.</para>
	/// <para>
	/// Kbfiltr provides a template for a filter service callback routine that can supplement the operation of
	/// <c>KeyboardClassServiceCallback</c>, the Kbdclass class service callback routine. The filter service callback can filter the input
	/// data that is transferred from the device input buffer to the class data queue.
	/// </para>
	/// <para>For more information about the connection of the Kbdclass service, see the following topics:</para>
	/// <list/>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> member points to a <b>CONNECT_DATA</b> structure that is allocated and set by Kbdclass.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.InputBufferLength</b> member is set to a value greater than or equal to the size, in bytes, of a
	/// CONNECT_DATA structure.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> member points to a <b>CONNECT_DATA</b> structure that is set by Kbfiltr.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of a <b>CONNECT_DATA</b> structure.</para>
	/// <para>Status block</para>
	/// <para>The <b>Information</b> member is set to zero.</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para><b></b></para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is less than the size, in bytes, of a CONNECT_DATA structure.</para>
	/// <para><b>STATUS_SHARING_VIOLATION</b></para>
	/// <para>Kbfiltr is already connected (the filter driver supports only one connect request).</para>
	/// <para><b>STATUS_SUCCESS</b></para>
	/// <para>The request completed successfully.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/ni-kbdmou-ioctl_internal_keyboard_connect
	[PInvokeData("kbdmou.h", MSDNShortId = "NI:kbdmou.IOCTL_INTERNAL_KEYBOARD_CONNECT")]
	public static uint IOCTL_INTERNAL_KEYBOARD_CONNECT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0080, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	public static uint IOCTL_INTERNAL_KEYBOARD_DISABLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0400, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>
	/// The IOCTL_INTERNAL_KEYBOARD_DISCONNECT request is completed with a status of STATUS_NOT_IMPLEMENTED. Note that a Plug and Play
	/// keyboard can be added or removed by the Plug and Play manager.
	/// </para>
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
	/// <para>The <b>Status</b> member is set to STATUS_NOT_IMPLEMENTED.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/ni-kbdmou-ioctl_internal_keyboard_disconnect
	[PInvokeData("kbdmou.h", MSDNShortId = "NI:kbdmou.IOCTL_INTERNAL_KEYBOARD_DISCONNECT")]
	public static uint IOCTL_INTERNAL_KEYBOARD_DISCONNECT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0100, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	public static uint IOCTL_INTERNAL_KEYBOARD_ENABLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_KEYBOARD, 0x0200, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>
	/// The IOCTL_INTERNAL_MOUSE_CONNECT request connects Mouclass service to a mouse device. Mouclass sends this request down the device
	/// stack before it opens a mouse device.
	/// </para>
	/// <para>After Moufiltr receives the mouse connect request, it filters the request in the following way:</para>
	/// <list type="number">
	/// <item>
	/// <description>Saves a copy of the <c>CONNECT_DATA (Mouclass)</c> structure that was passed to Moufiltr</description>
	/// </item>
	/// <item>
	/// <description>Substitutes its own connect information for the class driver connect information</description>
	/// </item>
	/// <item>
	/// <description>Sends the IOCTL_INTERNAL_MOUSE_CONNECT request down the device stack</description>
	/// </item>
	/// </list>
	/// <para>If the request is not successful, Moufiltr completes the request with an appropriate error status.</para>
	/// <para>
	/// Moufiltr provides a template for a filter service callback routine that can supplement the operation of
	/// <c>MouseClassServiceCallback</c>, the Mouclass service callback routine. The filter service callback can filter the input data that
	/// is transferred from the device input buffer to the class driver data queue.
	/// </para>
	/// <para>For more information about the connection of the Mouclass service, see the following topics:</para>
	/// <list/>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> member points to a CONNECT_DATA structure that is allocated and set by Mouclass.
	/// </para>
	/// <para>Input buffer length</para>
	/// <para>
	/// The <b>Parameters.DeviceIoControl.InputBufferLength</b> member is set to a value greater than or equal to the size, in bytes, of a
	/// CONNECT_DATA structure.
	/// </para>
	/// <para>Output buffer</para>
	/// <para>The <b>Parameters.DeviceIoControl.Type3InputBuffer</b> member points to a CONNECT_DATA structure that is set by Moufiltr.</para>
	/// <para>Output buffer length</para>
	/// <para>The size of a CONNECT_DATA structure.</para>
	/// <para>Status block</para>
	/// <para>The <b>Information</b> member is set to zero.</para>
	/// <para>The <b>Status</b> member is set to one of the following values:</para>
	/// <para><b>STATUS_INVALID_PARAMETER</b></para>
	/// <para><b>Parameters.DeviceIoControl.InputBufferLength</b> is less than the size, in bytes, of a CONNECT_DATA structure.</para>
	/// <para><b>STATUS_SHARING_VIOLATION</b></para>
	/// <para>Moufiltr is already connected (a filter driver supports only one connect request).</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/ni-kbdmou-ioctl_internal_mouse_connect
	[PInvokeData("kbdmou.h", MSDNShortId = "NI:kbdmou.IOCTL_INTERNAL_MOUSE_CONNECT")]
	public static uint IOCTL_INTERNAL_MOUSE_CONNECT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0080, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	public static uint IOCTL_INTERNAL_MOUSE_DISABLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0400, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>
	/// <para>
	/// The IOCTL_INTERNAL_MOUSE_DISCONNECT request is completed by Moufiltr with an error status of STATUS_NOT_IMPLEMENTED. (Note that a
	/// Plug and Play mouse device can be added or removed by the Plug and Play manager.)
	/// </para>
	/// <para>Major code</para>
	/// <para><c>IRP_MJ_INTERNAL_DEVICE_CONTROL</c></para>
	/// <para>Input buffer</para>
	/// <para>None.</para>
	/// <para>Input buffer length</para>
	/// <para>None.</para>
	/// <para>Output buffer</para>
	/// <para>None.</para>
	/// <para>Output buffer length</para>
	/// <para>None.</para>
	/// <para>Status block</para>
	/// <para>The <b>Status</b> member is set to STATUS_NOT_IMPLEMENTED.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/ni-kbdmou-ioctl_internal_mouse_disconnect
	[PInvokeData("kbdmou.h", MSDNShortId = "NI:kbdmou.IOCTL_INTERNAL_MOUSE_DISCONNECT")]
	public static uint IOCTL_INTERNAL_MOUSE_DISCONNECT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0100, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>Undocumented.</summary>
	public static uint IOCTL_INTERNAL_MOUSE_ENABLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_MOUSE, 0x0200, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

	/// <summary>CONNECT_DATA specifies information that Kbdclass and Mouclass use to connect to a keyboard or mouse port.</summary>
	/// <remarks>
	/// The keyboard class driver uses this structure with an <c>IOCTL_INTERNAL_KEYBOARD_CONNECT</c> request; the mouse class driver uses
	/// <c>IOCTL_INTERNAL_MOUSE_CONNECT</c> .
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/kbdmou/ns-kbdmou-_connect_data typedef struct _CONNECT_DATA { IN
	// PDEVICE_OBJECT ClassDeviceObject; IN PVOID ClassService; } CONNECT_DATA, *PCONNECT_DATA;
	[PInvokeData("kbdmou.h", MSDNShortId = "NS:kbdmou._CONNECT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONNECT_DATA
	{
		/// <summary>Pointer to an upper-level class <c>filter device object</c> (filter DO).</summary>
		public PDEVICE_OBJECT ClassDeviceObject;

		/// <summary>Specifies the class service routine. See <c>PSERVICE_CALLBACK_ROUTINE</c>.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PSERVICE_CALLBACK_ROUTINE? ClassService;
	}
}